Imports System.IO
Imports System.Data
Imports ClosedXML.Excel
Imports System.Diagnostics
Imports System.Linq

Public Class OP_PayrollGeneralReport
    Private Sub OP_PayrollGeneralReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CL As New CL_Payroll
        Dim dt As DataTable = CL.GetApprovedWeeks()

        Dim filaVacia As DataRow = dt.NewRow()
        filaVacia("StartDate") = DBNull.Value
        filaVacia("EndDate") = DBNull.Value
        filaVacia("Semana") = "Seleccione una semana"
        dt.Rows.InsertAt(filaVacia, 0)

        If dt.Rows.Count = 1 Then
            MessageBox.Show("No hay semanas de nómina aprobadas disponibles.", "Sin semanas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        CB_Week.DisplayMember = "Semana"
        CB_Week.ValueMember = "StartDate"
        CB_Week.DataSource = dt
        CB_Week.SelectedIndex = 0
    End Sub

    Private Sub CB_Week_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Week.SelectedIndexChanged
        If CB_Week.SelectedItem Is Nothing Then Exit Sub

        Dim rowView As DataRowView = DirectCast(CB_Week.SelectedItem, DataRowView)

        If IsDBNull(rowView("StartDate")) Then
            DGV_ReportGeneral.DataSource = Nothing
            Exit Sub
        End If

        Dim startDate As Date = CDate(rowView("StartDate"))
        Dim endDate As Date = CDate(rowView("EndDate"))

        Dim CL As New CL_Payroll
        Dim dt As DataTable = CL.GetApprovedPayrollByWeek(startDate, endDate)

        DGV_ReportGeneral.AutoGenerateColumns = True
        DGV_ReportGeneral.DataSource = dt

        AplicarEncabezadosReporte()
        AplicarFormatoMoneda()

        DGV_ReportGeneral.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub AplicarFormatoMoneda()
        Dim columnasMoneda As String() = {
        "BaseSalary", "DailySalary", "ExtraS", "ExtraD", "ExtraT",
        "LunchBonus", "ProductivityBonus", "AttitudeBonus", "Savings",
        "TransportBonus", "LoanDiscount", "AttitudeBonusFinal", "ProductivityBonusFinal",
        "PlantBonusAmount", "TransportBetweenEmployeesBonus", "BotoneroTempFinal",
        "BotoneroFijoFinal", "LoanAmount", "LoanPaid", "LoanBalance", "InfonavitAmount",
        "AbsenceHoursDiscount", "DebtAmount", "DebtDiscount", "DebtBalance",
        "TransferAmount", "CashAmount", "TotalNeto"
    }

        For Each nombreCol As String In columnasMoneda
            If DGV_ReportGeneral.Columns.Contains(nombreCol) Then
                DGV_ReportGeneral.Columns(nombreCol).DefaultCellStyle.Format = "C2"
            End If
        Next
    End Sub

    Private Sub AplicarEncabezadosReporte()
        Dim nombres As New Dictionary(Of String, String) From {
        {"EmployeeID", "No."},
        {"StartDate", "Fecha Inicio"},
        {"EndDate", "Fecha Fin"},
        {"Company", "Empresa"},
        {"FullName", "Nombre Completo"},
        {"Position", "Posición"},
        {"BaseSalary", "S. Base"},
        {"DailySalary", "S. Diario"},
        {"AbsencesMonth", "Faltas en el Mes"},
        {"ExtraS", "Ext. S"},
        {"ExtraD", "Ext. D"},
        {"ExtraT", "Ext. T"},
        {"LunchHours", "H. Comida"},
        {"LunchBonus", "B. Comida"},
        {"ProductivityBonus", "Bono Prod."},
        {"AttitudeBonus", "Bono BP"},
        {"Savings", "Ahorro"},
        {"TransportDays", "D. Transporte"},
        {"TransportBonus", "Transporte"},
        {"LoanDiscount", "Desc. Prest."},
        {"AttitudeBonusFinal", "Bono BP Final"},
        {"ProductivityBonusFinal", "Bono Prod. Final"},
        {"PlantBonusAmount", "Monto Bono P. P."},
        {"TransportBetweenEmployeesBonus", "Transporte entre Empleados"},
        {"BotoneroTempFinal", "Botonero Temp Final"},
        {"BotoneroFijoFinal", "Botonero Fijo Final"},
        {"LoanAmount", "Prestado"},
        {"LoanPaid", "Pagado"},
        {"LoanBalance", "Saldo a pagar"},
        {"HasInfonavit", "Infonavit"},
        {"InfonavitAmount", "Monto infonavit"},
        {"AbsenceHours", "No. Horas A."},
        {"AbsenceHoursDiscount", "Desc. Horas A."},
        {"DebtAmount", "Monto adeudo"},
        {"DebtDiscount", "Desc. por adeudo"},
        {"DebtBalance", "Saldo adeudo"},
        {"TransferAmount", "Monto a transferir"},
        {"CashAmount", "Monto en efectivo"},
        {"TotalNeto", "Calculado"},
        {"PlantName", "Planta"}
    }

        Dim ocultas As String() = {"PayrollID", "CreatedBy", "BatchID"}

        For Each col As DataGridViewColumn In DGV_ReportGeneral.Columns
            If ocultas.Contains(col.Name) Then
                col.Visible = False
            ElseIf nombres.ContainsKey(col.Name) Then
                col.HeaderText = nombres(col.Name)
            End If
        Next
    End Sub

    Private Sub BT_ExportExcel_Click(sender As Object, e As EventArgs) Handles BT_ExportExcel.Click
        If CB_Week.SelectedItem Is Nothing Then Exit Sub

        Dim rowView As DataRowView = DirectCast(CB_Week.SelectedItem, DataRowView)

        If IsDBNull(rowView("StartDate")) Then
            MessageBox.Show("Selecciona una semana antes de exportar.", "Falta semana", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim startDate As Date = CDate(rowView("StartDate"))
        Dim endDate As Date = CDate(rowView("EndDate"))

        Dim CL As New CL_Payroll
        Dim dt As DataTable = CL.GetApprovedPayrollByWeek(startDate, endDate)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No hay registros para esta semana.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim columnasMoneda As String() = {
        "BaseSalary", "DailySalary", "ExtraS", "ExtraD", "ExtraT",
        "LunchBonus", "ProductivityBonus", "AttitudeBonus", "Savings",
        "TransportBonus", "LoanDiscount", "AttitudeBonusFinal", "ProductivityBonusFinal",
        "PlantBonusAmount", "TransportBetweenEmployeesBonus", "BotoneroTempFinal",
        "BotoneroFijoFinal", "LoanAmount", "LoanPaid", "LoanBalance", "InfonavitAmount",
        "AbsenceHoursDiscount", "DebtAmount", "DebtDiscount", "DebtBalance",
        "TransferAmount", "CashAmount", "TotalNeto"
    }

        Try
            Using workbook As New XLWorkbook()
                Dim ws = workbook.Worksheets.Add("Nómina General")

                For col As Integer = 0 To dt.Columns.Count - 1
                    Dim cell = ws.Cell(1, col + 1)
                    cell.Value = dt.Columns(col).ColumnName
                    cell.Style.Font.Bold = True
                Next

                For row As Integer = 0 To dt.Rows.Count - 1
                    For col As Integer = 0 To dt.Columns.Count - 1
                        Dim valor = dt.Rows(row)(col)
                        Dim celda = ws.Cell(row + 2, col + 1)

                        If columnasMoneda.Contains(dt.Columns(col).ColumnName) AndAlso Not IsDBNull(valor) Then
                            celda.Value = Convert.ToDouble(valor)
                            celda.Style.NumberFormat.Format = "$#,##0.00"
                        Else
                            celda.Value = valor?.ToString()
                        End If
                    Next
                Next

                ws.Columns().AdjustToContents()

                Dim sfd As New SaveFileDialog()
                sfd.Filter = "Excel Files|*.xlsx"
                sfd.FileName = $"Nomina_General_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}"

                If sfd.ShowDialog() = DialogResult.OK Then
                    workbook.SaveAs(sfd.FileName)
                    MessageBox.Show("Archivo Excel generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Process.Start("explorer.exe", $"/select,""{sfd.FileName}""")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al generar Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class