Imports System.Diagnostics.Metrics
Imports System.Drawing
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Bibliography
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Math
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Microsoft.Identity.Client

Public Class OP_SEL_MainWeekReportSalaryCalculation
    Dim SelectedEmployeeID As Integer = 0
    Dim PlantId As Integer = 0
    Dim PlantName As String = ""
    Dim ReleasePayment As Boolean = True

    Private Sub OP_SEL_MainWeekReportSalaryCalculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LB_Progress.Text = ""
        DTP_WeekSelector.Value = Today
        LB_StartDate.Visible = False
        DTP_StartDate.Visible = False
        LB_EndDate.Visible = False
        DTP_EndDate.Visible = False
        BT_FinalConfirmation.Enabled = False
        CB_Confirmation.Enabled = False
        DTP_WeekSelector.Enabled = False

        Dim report As New CL_Plants()

        CB_Plants.DataSource = report.Get_ListOfPlants()
        CB_Plants.DisplayMember = "Nombre"
        CB_Plants.ValueMember = "ID"
        CB_Plants.SelectedIndex = 0
        TB_ProdPlant.Enabled = False
    End Sub

    Private Sub BT_LoadInfo_Click(sender As Object, e As EventArgs) Handles BT_LoadInfo.Click
        LB_Progress.Text = "Conectando con los servicios de la nube para descargar información..."
        LB_Progress.Refresh()
        LoadWeekInformation()
    End Sub

    'Get plants list
    Private Sub CB_Plants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Plants.SelectedIndexChanged

        If CB_Plants.SelectedValue Is Nothing Then Exit Sub
        If TypeOf CB_Plants.SelectedValue IsNot Integer Then Exit Sub

        Dim idPlant As Integer = CInt(CB_Plants.SelectedValue)

        If idPlant = 0 Then
            Exit Sub
        End If


        If idPlant = 1 Then
            PlantId = idPlant
            PlantName = "Sin planta asignada"
            TB_ProdPlant.Enabled = False
            DTP_WeekSelector.Enabled = True
        Else
            Dim Plant As New CL_Plants()
            Dim SelectedPlant As DataTable = Plant.Get_OnePlant(idPlant)

            If SelectedPlant.Rows.Count = 0 Then Exit Sub

            For Each item As DataRow In SelectedPlant.Rows
                PlantId = idPlant
                PlantName = item(1)
                TB_ProdPlant.Enabled = True
            Next
        End If


    End Sub

    'validate plant performance 80/90
    Private Function ValidarProdPlant() As Boolean
        Dim valor As String = TB_ProdPlant.Text.Trim()

        If valor = "80" OrElse valor = "90" Then
            Return True
        Else
            MessageBox.Show("Solo se permiten los valores 80 o 90.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TB_ProdPlant.Focus()
            TB_ProdPlant.SelectAll()
            Return False
        End If
    End Function

    Private Function GetWeekRange(selectedDate As Date) As Tuple(Of Date, Date)

        Dim startDate As Date = selectedDate

        While startDate.DayOfWeek <> DayOfWeek.Thursday
            startDate = startDate.AddDays(-1)
        End While

        Dim endDate As Date = startDate.AddDays(6)

        Return Tuple.Create(startDate, endDate)

    End Function

    Private Sub LoadWeekInformation()

        Dim weekRange = GetWeekRange(DTP_WeekSelector.Value)

        Dim startDate As Date = weekRange.Item1
        Dim endDate As Date = weekRange.Item2

        Dim RecordsByEmployee As New CL_RecordsByEmployee
        Dim dt As DataTable
        If PlantId = 1 Then
            dt = RecordsByEmployee.Get_WeekRecordsWithoutPlant(startDate, endDate)
        Else
            dt = RecordsByEmployee.Get_WeekRecords(startDate, endDate, PlantId)
        End If

        DTP_StartDate.Value = startDate
        DTP_StartDate.Enabled = False
        DTP_EndDate.Value = endDate
        DTP_EndDate.Enabled = False

        BuildWeeklyGrid_Movements(dt, startDate)

    End Sub

    Private Sub BuildWeeklyGrid_Movements(sourceTable As DataTable, startDate As Date)

        If DTP_WeekSelector.Value = Date.Today Then
            Exit Sub
        End If

        Dim EmployeesInfo As New DataTable

        '----- 0 - Definición de Columnas fijas
        ' 0
        EmployeesInfo.Columns.Add("Empresa")
        ' 1
        EmployeesInfo.Columns.Add("ID planta")
        ' 2
        EmployeesInfo.Columns.Add("Nombre de Planta")
        ' 3
        EmployeesInfo.Columns.Add("No.")
        ' 4
        EmployeesInfo.Columns.Add("Nombre Completo")
        ' 5
        EmployeesInfo.Columns.Add("Posición")
        ' 6
        EmployeesInfo.Columns.Add("Tipo")
        ' 7
        EmployeesInfo.Columns.Add("S. Base")

        ' 8-14
        'Columnas de la semana
        For i = 0 To 6
            'dt.Columns.Add(startDate.AddDays(i).ToString("ddd dd"))
            EmployeesInfo.Columns.Add(startDate.AddDays(i).ToString("dd/MM/yyyy"))
        Next

        'Lista de empleados únicos
        Dim employees = sourceTable.DefaultView.ToTable(True, "Empresa", "ID Planta", "Nombre de Planta", "ID Empleado", "Nombre Completo", "Posición", "Tipo de empleado", "Salario Base")

        For Each emp As DataRow In employees.Rows

            Dim newRow = EmployeesInfo.NewRow()

            newRow("Empresa") = emp("Empresa")
            newRow("Id Planta") = emp("ID Planta")
            newRow("Nombre de Planta") = emp("Nombre de Planta")
            newRow("No.") = emp("ID Empleado")
            newRow("Nombre Completo") = emp("Nombre Completo")
            newRow("Posición") = emp("Posición")
            newRow("Tipo") = emp("Tipo de empleado")
            newRow("S. Base") = emp("Salario Base")

            For i = 0 To 6 ' Week Days

                Dim currentDate = startDate.AddDays(i)

                Dim found = sourceTable.Select("[ID Empleado]=" & emp("ID Empleado") & " AND DREMPL_DATE = #" & currentDate.ToString("yyyy-MM-dd") & "#")

                'If there are records then check for delay justification
                If found.Length > 0 Then
                    ' Priorizar PG (500), PSG (510), Vacaciones (520), FJ (130) sobre otros registros
                    Dim priorityMoves() As Integer = {500, 510, 520, 130}
                    Dim priorityRecord As DataRow = found.FirstOrDefault(Function(r) priorityMoves.Contains(CInt(r("MOVE_ID"))))
                    Dim selectedRecord As DataRow = If(priorityRecord IsNot Nothing, priorityRecord, found(0))
                    Dim moveID As Integer = CInt(selectedRecord("MOVE_ID"))

                    'Dim moveID As Integer = CInt(found(0)("MOVE_ID"))

                    If moveID = 100 Or moveID = 110 Then ' tuvo Asistencia
                        Dim EmployeeRecord As New CL_RecordsByEmployee
                        EmployeeRecord.EMPL_ID = CInt(emp("ID Empleado"))
                        EmployeeRecord.DREMPL_DATE = currentDate.ToString("yyyy-MM-dd")
                        Dim DelayJustified As Integer = 140 ' Retardo Justificado - Registro Manual

                        Dim EmployeeRecords140 As DataTable = EmployeeRecord.Get_CheckDelayJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        If EmployeeRecords140.Rows.Count > 0 Then
                            newRow(i + 8) = 140 ' Retardo Justificado
                        Else
                            newRow(i + 8) = found(0)("MOVE_ID")
                        End If
                    ElseIf moveID = 60 Then ' Tuvo falta
                        'If there are records then check for absence justification
                        Dim EmployeeRecord As New CL_RecordsByEmployee
                        EmployeeRecord.EMPL_ID = CInt(emp("ID Empleado"))
                        EmployeeRecord.DREMPL_DATE = currentDate.ToString("yyyy-MM-dd")
                        Dim DelayJustified As Integer = 130 ' Retardo Justificado - Registro Manual

                        Dim EmployeeRecords130 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        If EmployeeRecords130.Rows.Count > 0 Then
                            newRow(i + 8) = 130 ' Jornada Completa - Falta Justificada
                        Else
                            Dim AbsenceWithSalary As Integer = 500 ' Permiso con goce - Registro Manual

                            'Let's see if there is a permission or vacations
                            Dim EmployeeRecords500 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), AbsenceWithSalary)
                            If EmployeeRecords500.Rows.Count > 0 Then
                                newRow(i + 8) = 500 ' Permiso con goce
                            Else
                                Dim AbsenceWithoutSalary As Integer = 510 ' Permiso sin goce - Registro Manual

                                'Let's see if there is a permission or vacations
                                Dim EmployeeRecords510 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), AbsenceWithoutSalary)
                                If EmployeeRecords510.Rows.Count > 0 Then
                                    newRow(i + 8) = 510 ' Permiso con goce
                                Else
                                    Dim AbsenceForVacation As Integer = 520 ' Falta por vacaciones - Registro Manual

                                    'Let's see if there is a permission or vacations
                                    Dim EmployeeRecords520 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), AbsenceForVacation)
                                    If EmployeeRecords520.Rows.Count > 0 Then
                                        newRow(i + 8) = 520 ' vacaciones
                                    Else
                                        newRow(i + 8) = found(0)("MOVE_ID")
                                    End If
                                End If
                            End If
                        End If

                        'Dim EmployeeRecords130 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        'If EmployeeRecords130.Rows.Count > 0 Then
                        '    newRow(i + 6) = 130 ' Jornada Completa - Falta Justificada
                        'Else
                        '    newRow(i + 6) = found(0)("MOVE_ID")
                        'End If
                    Else
                        newRow(i + 8) = found(0)("MOVE_ID")
                    End If
                End If


            Next

            EmployeesInfo.Rows.Add(newRow)

        Next
        '----- 1.- Add Column to DGV
        EmployeesInfo.Columns.Add("Faltas en el Mes", GetType(Integer))
        EmployeesInfo.Columns.Add("S. Diario", GetType(String))
        EmployeesInfo.Columns.Add("Ext. S", GetType(String))
        EmployeesInfo.Columns.Add("Ext. D", GetType(String))
        EmployeesInfo.Columns.Add("Ext. T", GetType(String))
        EmployeesInfo.Columns.Add("Monto por Asistencias", GetType(String))
        'EmployeesInfo.Columns.Add("No. H. Extra", GetType(Decimal))
        'EmployeesInfo.Columns.Add("Tipo P. Extra", GetType(String))
        EmployeesInfo.Columns.Add("No. H. D", GetType(Decimal))
        EmployeesInfo.Columns.Add("Tipo. P. D", GetType(String))
        EmployeesInfo.Columns.Add("Monto H. D", GetType(String))
        EmployeesInfo.Columns.Add("No. H. T", GetType(Decimal))
        EmployeesInfo.Columns.Add("Tipo. P. T", GetType(String))
        EmployeesInfo.Columns.Add("Monto H. T", GetType(String))
        EmployeesInfo.Columns.Add("H. Comida", GetType(Decimal))
        EmployeesInfo.Columns.Add("B. Comida", GetType(String))
        EmployeesInfo.Columns.Add("Monto Total Comida", GetType(String))
        EmployeesInfo.Columns.Add("Bono BP", GetType(String))
        EmployeesInfo.Columns.Add("Bono Prod.", GetType(String))
        EmployeesInfo.Columns.Add("Amonest..", GetType(Decimal))
        EmployeesInfo.Columns.Add("Bono Prod. Neto", GetType(String))
        EmployeesInfo.Columns.Add("Amonest. por Falta", GetType(String))
        EmployeesInfo.Columns.Add("Bono Prod. Final", GetType(String))
        EmployeesInfo.Columns.Add("Ahorro", GetType(String))
        EmployeesInfo.Columns.Add("Bono P. P.", GetType(String))
        EmployeesInfo.Columns.Add("Monto Bono P. P.", GetType(String))
        EmployeesInfo.Columns.Add("D. Transporte", GetType(Decimal))
        EmployeesInfo.Columns.Add("Transporte", GetType(String))
        EmployeesInfo.Columns.Add("Transporte entre Empleados", GetType(String))
        EmployeesInfo.Columns.Add("Monto B. Botonero Temp", GetType(String))
        EmployeesInfo.Columns.Add("Monto B. Botonero Fijo", GetType(String))
        EmployeesInfo.Columns.Add("Fecha inicio", GetType(Date))
        EmployeesInfo.Columns.Add("Fecha Fin", GetType(Date))
        EmployeesInfo.Columns.Add("Prestado", GetType(String))
        EmployeesInfo.Columns.Add("Pagado", GetType(String))
        EmployeesInfo.Columns.Add("Saldo a pagar", GetType(String))
        EmployeesInfo.Columns.Add("Desc. Prest.", GetType(String))
        EmployeesInfo.Columns.Add("Infonavit", GetType(Boolean))
        EmployeesInfo.Columns.Add("Monto infonavit", GetType(String))
        EmployeesInfo.Columns.Add("Monto adeudo", GetType(String))
        EmployeesInfo.Columns.Add("Desc. por adeudo", GetType(String))
        EmployeesInfo.Columns.Add("Saldo adeudo", GetType(String))
        EmployeesInfo.Columns.Add("Monto a transferir", GetType(String))
        EmployeesInfo.Columns.Add("Calculado", GetType(String))
        EmployeesInfo.Columns.Add("Monto en efectivo", GetType(String))

        DGV_CompleteWeekInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        '------ 1 - Definición de atributos en columnas 
        ' 0 - 5 : 0 -> 7
        DGV_CompleteWeekInfo.DataSource = EmployeesInfo
        DGV_CompleteWeekInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DGV_CompleteWeekInfo.Columns("Empresa").Width = 220
        DGV_CompleteWeekInfo.Columns("ID Planta").Width = 60
        DGV_CompleteWeekInfo.Columns("Nombre de Planta").Width = 180
        DGV_CompleteWeekInfo.Columns("No.").Width = 40
        DGV_CompleteWeekInfo.Columns("Nombre Completo").Width = 180
        DGV_CompleteWeekInfo.Columns("Posición").Width = 150
        DGV_CompleteWeekInfo.Columns("Tipo").Width = 60
        DGV_CompleteWeekInfo.Columns("S. Base").Width = 65
        DGV_CompleteWeekInfo.Columns("S. Base").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' 6 - 12 : 8:14
        'Centra las columnas de los días
        For i = 8 To 14
            DGV_CompleteWeekInfo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGV_CompleteWeekInfo.Columns(i).Width = 70
        Next

        '----- 2.- Adit Width 
        DGV_CompleteWeekInfo.Columns("Faltas en el Mes").Width = 100
        DGV_CompleteWeekInfo.Columns("Faltas en el Mes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Faltas en el Mes").ToolTipText = "Número de faltas durante el mes actual."
        DGV_CompleteWeekInfo.Columns("Faltas en el Mes").DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(CByte(255), CByte(0), CByte(0))
        DGV_CompleteWeekInfo.Columns("Faltas en el Mes").DefaultCellStyle.Font = New System.Drawing.Font(DGV_CompleteWeekInfo.Font, FontStyle.Bold)

        DGV_CompleteWeekInfo.Columns("S. Diario").Width = 65
        DGV_CompleteWeekInfo.Columns("S. Diario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGV_CompleteWeekInfo.Columns("Monto por Asistencias").Width = 90
        DGV_CompleteWeekInfo.Columns("Monto por Asistencias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto por Asistencias").ToolTipText = "Monto ganado por los días que sí asistió"
        'DGV_CompleteWeekInfo.Columns("No. H. Extra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DGV_CompleteWeekInfo.Columns("No. H. Extra").Width = 50
        'DGV_CompleteWeekInfo.Columns("No. H. Extra").ToolTipText = "Número de horas extras"

        'DGV_CompleteWeekInfo.Columns("Tipo P. Extra").Width = 60
        'DGV_CompleteWeekInfo.Columns("Tipo P. Extra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DGV_CompleteWeekInfo.Columns("Tipo P. Extra").ToolTipText = "Tipo de pago Doble/Triple"

        DGV_CompleteWeekInfo.Columns("No. H. D").Width = 65
        DGV_CompleteWeekInfo.Columns("No. H. D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("No. H. D").ToolTipText = "Cantidad de horas extras Doble"

        DGV_CompleteWeekInfo.Columns("Tipo. P. D").Width = 60
        DGV_CompleteWeekInfo.Columns("Tipo. P. D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Tipo. P. D").ToolTipText = "Tipo de hora extra doble"

        DGV_CompleteWeekInfo.Columns("Monto H. D").Width = 80
        DGV_CompleteWeekInfo.Columns("Monto H. D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto H. D").ToolTipText = "Monto de horas extra dobles"

        DGV_CompleteWeekInfo.Columns("No. H. T").Width = 65
        DGV_CompleteWeekInfo.Columns("No. H. T").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("No. H. T").ToolTipText = "Cantidad de horas extras Triple"

        DGV_CompleteWeekInfo.Columns("Tipo. P. T").Width = 60
        DGV_CompleteWeekInfo.Columns("Tipo. P. T").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Tipo. P. T").ToolTipText = "Tipo de hora extra triple"

        DGV_CompleteWeekInfo.Columns("Monto H. T").Width = 80
        DGV_CompleteWeekInfo.Columns("Monto H. T").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto H. T").ToolTipText = "Monto de horas extra triples"

        DGV_CompleteWeekInfo.Columns("Ext. S").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Ext. S").Width = 50
        DGV_CompleteWeekInfo.Columns("Ext. S").ToolTipText = "Salario diario"

        DGV_CompleteWeekInfo.Columns("Ext. D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Ext. D").Width = 50
        DGV_CompleteWeekInfo.Columns("Ext. D").ToolTipText = "Salario diario doble"

        DGV_CompleteWeekInfo.Columns("Ext. T").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Ext. T").Width = 50
        DGV_CompleteWeekInfo.Columns("Ext. T").ToolTipText = "Salario diario triple"

        DGV_CompleteWeekInfo.Columns("H. Comida").Width = 70
        DGV_CompleteWeekInfo.Columns("H. Comida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("H. Comida").ToolTipText = "Horas de comida"

        DGV_CompleteWeekInfo.Columns("B. Comida").Width = 70
        DGV_CompleteWeekInfo.Columns("B. Comida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("B. Comida").ToolTipText = "Bono de comida"

        DGV_CompleteWeekInfo.Columns("Monto Total Comida").Width = 90
        DGV_CompleteWeekInfo.Columns("Monto Total Comida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto Total Comida").ToolTipText = "Horas de comida, costo por hora"

        DGV_CompleteWeekInfo.Columns("Bono BP").Width = 70
        DGV_CompleteWeekInfo.Columns("Bono BP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Bono BP").ToolTipText = "Bono de actitud y buenas practicas"

        DGV_CompleteWeekInfo.Columns("Bono Prod.").Width = 80
        DGV_CompleteWeekInfo.Columns("Bono Prod.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Bono Prod.").ToolTipText = "Bono de Productividad"

        DGV_CompleteWeekInfo.Columns("Bono Prod. Neto").Width = 90
        DGV_CompleteWeekInfo.Columns("Bono Prod. Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Bono Prod. Neto").ToolTipText = "Bono de Productividad después de descuento por amonestaciones"

        DGV_CompleteWeekInfo.Columns("Amonest..").Width = 70
        DGV_CompleteWeekInfo.Columns("Amonest..").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Amonest..").ToolTipText = "Número de amonestaciones"

        DGV_CompleteWeekInfo.Columns("Amonest. por Falta").Width = 100
        DGV_CompleteWeekInfo.Columns("Amonest. por Falta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Amonest. por Falta").ToolTipText = "Días de amonestación que se generarán automáticamente al confirmar la nómina, por las faltas injustificadas de esta semana"

        DGV_CompleteWeekInfo.Columns("Bono Prod. Final").Width = 110
        DGV_CompleteWeekInfo.Columns("Bono Prod. Final").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Bono Prod. Final").ToolTipText = "Monto real del bono de productividad que se está pagando esta semana, ya descontando faltas y amonestaciones pendientes"

        DGV_CompleteWeekInfo.Columns("Ahorro").Width = 50
        DGV_CompleteWeekInfo.Columns("Ahorro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Ahorro").ToolTipText = "Cantidad a Ahorrar"

        DGV_CompleteWeekInfo.Columns("Bono P. P.").Width = 70
        DGV_CompleteWeekInfo.Columns("Bono P. P.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Bono P. P.").ToolTipText = "Bono de productividad de planta"

        DGV_CompleteWeekInfo.Columns("Monto Bono P. P.").Width = 90
        DGV_CompleteWeekInfo.Columns("Monto Bono P. P.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Monto Bono P. P.").ToolTipText = "Monto real del 80%/90% de productividad de planta"

        DGV_CompleteWeekInfo.Columns("D. Transporte").Width = 90
        DGV_CompleteWeekInfo.Columns("D. Transporte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("D. Transporte").ToolTipText = "Días de transporte"

        DGV_CompleteWeekInfo.Columns("Transporte").Width = 70
        DGV_CompleteWeekInfo.Columns("Transporte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Transporte").ToolTipText = "Monto de bono de transporte"

        DGV_CompleteWeekInfo.Columns("Transporte entre Empleados").Width = 80
        DGV_CompleteWeekInfo.Columns("Transporte entre Empleados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Transporte entre Empleados").ToolTipText = "Transporte entre Empleados"

        DGV_CompleteWeekInfo.Columns("Monto B. Botonero Temp").Width = 80
        DGV_CompleteWeekInfo.Columns("Monto B. Botonero Temp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto B. Botonero Temp").ToolTipText = "Monto temnporal de bono botonero."

        DGV_CompleteWeekInfo.Columns("Monto B. Botonero Fijo").Width = 80
        DGV_CompleteWeekInfo.Columns("Monto B. Botonero Fijo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto B. Botonero Fijo").ToolTipText = "Monto fijo de bono botonero."

        DGV_CompleteWeekInfo.Columns("Fecha inicio").Width = 80
        DGV_CompleteWeekInfo.Columns("Fecha inicio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Fecha inicio").ToolTipText = "Fecha inicio"

        DGV_CompleteWeekInfo.Columns("Fecha fin").Width = 80
        DGV_CompleteWeekInfo.Columns("Fecha fin").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Fecha fin").ToolTipText = "Fecha fin"

        DGV_CompleteWeekInfo.Columns("Prestado").Width = 70
        DGV_CompleteWeekInfo.Columns("Prestado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Prestado").ToolTipText = "Monto Prestado"

        DGV_CompleteWeekInfo.Columns("Pagado").Width = 70
        DGV_CompleteWeekInfo.Columns("Pagado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Pagado").ToolTipText = "Monto Pagado"

        DGV_CompleteWeekInfo.Columns("Saldo a pagar").Width = 90
        DGV_CompleteWeekInfo.Columns("Saldo a pagar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Saldo a pagar").ToolTipText = "Saldo a pagar"

        DGV_CompleteWeekInfo.Columns("Desc. Prest.").Width = 80
        DGV_CompleteWeekInfo.Columns("Desc. Prest.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Desc. Prest.").ToolTipText = "Monto a descontar"

        DGV_CompleteWeekInfo.Columns("Calculado").Width = 100
        DGV_CompleteWeekInfo.Columns("Calculado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Calculado").ToolTipText = "Monto calculado"

        DGV_CompleteWeekInfo.Columns("Monto a transferir").Width = 120
        DGV_CompleteWeekInfo.Columns("Monto a transferir").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto a transferir").ToolTipText = "Monto a transferir"

        DGV_CompleteWeekInfo.Columns("Monto en efectivo").Width = 120
        DGV_CompleteWeekInfo.Columns("Monto en efectivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto en efectivo").ToolTipText = "Monto calculado menos monto a transferir"

        DGV_CompleteWeekInfo.Columns("Infonavit").Width = 60
        DGV_CompleteWeekInfo.Columns("Infonavit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Infonavit").ToolTipText = "¿El empleado tiene infonavit?"

        DGV_CompleteWeekInfo.Columns("Monto infonavit").Width = 100
        DGV_CompleteWeekInfo.Columns("Monto infonavit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto infonavit").ToolTipText = "Monto a descontar por infonavit"

        DGV_CompleteWeekInfo.Columns("Monto adeudo").Width = 100
        DGV_CompleteWeekInfo.Columns("Monto adeudo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Monto adeudo").ToolTipText = "Monto acumulado por adeudo a empresa"

        DGV_CompleteWeekInfo.Columns("Desc. por adeudo").Width = 100
        DGV_CompleteWeekInfo.Columns("Desc. por adeudo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Desc. por adeudo").ToolTipText = "Cantidad a descontar por adeudo"

        DGV_CompleteWeekInfo.Columns("Saldo adeudo").Width = 100
        DGV_CompleteWeekInfo.Columns("Saldo adeudo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Saldo adeudo").ToolTipText = "saldo por adeudos"

        PaintCells()
        GetAdditionalValues()

        'in case of DGV has record, we activate the checkbox to be able to release
        If DGV_CompleteWeekInfo.Rows.Count > 0 And ReleasePayment = True Then
            CB_Confirmation.Enabled = True
            For i As Integer = 0 To 7
                DGV_CompleteWeekInfo.Columns(i).Frozen = True
            Next
        End If

    End Sub

    Private Sub PaintCells()

        For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows

            For i = 8 To DGV_CompleteWeekInfo.Columns.Count - 1

                Dim value = row.Cells(i).Value

                If value Is Nothing OrElse value Is DBNull.Value Then Continue For

                Dim moveID As Integer = Convert.ToInt32(value)

                Select Case moveID
                    Case 60
                        row.Cells(i).Value = "F" ' FI -Falta Injustificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(229), CByte(204))
                        row.Cells(i).ToolTipText = "Falta"
                    Case 70
                        row.Cells(i).Value = "A" ' JC- Jornada Completa
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 80
                        row.Cells(i).Value = "A" ' JC-T Jornada completa con tolerancia
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 85
                        row.Cells(i).Value = "A" 'JC-TA Jornada Completa con Tiempo Adicional
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 90
                        row.Cells(i).Value = "A" 'JI-EP-SA Jornada Incompleta - Entrada Puntual y Salida Anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 100
                        row.Cells(i).Value = "R" 'JI-ER-SA Jornada Incompleta - Entrada con retardo salida anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case 110
                        row.Cells(i).Value = "R" 'JI-ER-SP Jornada Incompleta - Entrada con retardo salida puntual
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case 120
                        row.Cells(i).Value = "A" 'JI-ET-SA Jornada Incompleta - Entrada con tolerancia salida anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 122
                        row.Cells(i).Value = "A" 'JI-ET-SA Jornada Incompleta - Entrada con tolerancia salida anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 130
                        row.Cells(i).Value = "FJ" 'JC-FJ Jornada Completa - Falta Justificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(128), CByte(128))
                        row.Cells(i).ToolTipText = "Falta Justificada"
                    Case 140
                        row.Cells(i).Value = "R" ' RJ Retardo Justificado
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case 500
                        row.Cells(i).Value = "PG" ' PG Permiso con goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Permiso con goce"
                    Case 510
                        row.Cells(i).Value = "PSG" ' Permiso sin goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(127), CByte(255), CByte(212))
                        row.Cells(i).ToolTipText = "Permiso sin goce"
                    Case 520
                        row.Cells(i).Value = "V" ' V Vacaciones
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(192), CByte(128))
                        row.Cells(i).ToolTipText = "Vacaciones"
                End Select

            Next

        Next

    End Sub

    Private Sub PaintCells_Sorted()

        For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows

            For i = 6 To DGV_CompleteWeekInfo.Columns.Count - 1

                Dim value = row.Cells(i).Value

                If value Is Nothing OrElse value Is DBNull.Value Then Continue For

                Dim moveID As String = value

                Select Case moveID
                    Case "F"
                        row.Cells(i).Value = "F" ' FI -Falta Injustificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(128), CByte(0))
                        row.Cells(i).ToolTipText = "Falta"
                    Case "A"
                        row.Cells(i).Value = "A" ' JC- Jornada Completa
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case "R"
                        row.Cells(i).Value = "R" 'JI-ER-SA Jornada Incompleta - Entrada con retardo salida anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case "FJ"
                        row.Cells(i).Value = "FJ" 'JC-FJ Jornada Completa - Falta Justificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(128), CByte(128))
                        row.Cells(i).ToolTipText = "Falta Justificada"
                    Case "PG"
                        row.Cells(i).Value = "PG" ' PG Permiso con goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Permiso con goce"
                    Case "PSG"
                        row.Cells(i).Value = "PSG" ' Permiso sin goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(127), CByte(255), CByte(212))
                        row.Cells(i).ToolTipText = "Permiso sin goce"
                    Case "V"
                        row.Cells(i).Value = "V" ' V Vacaciones
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(224), CByte(192))
                        row.Cells(i).ToolTipText = "Vacaciones"
                End Select

            Next

        Next

    End Sub

    Private Sub DTP_WeekSelector_MouseLeave(sender As Object, e As EventArgs)
        DTP_StartDate.Visible = True
        LB_StartDate.Visible = True
        DTP_EndDate.Visible = True
        LB_EndDate.Visible = True
    End Sub

    Private Sub DTP_WeekSelector_ValueChanged_1(sender As Object, e As EventArgs) Handles DTP_WeekSelector.ValueChanged
        If TB_ProdPlant.Text <> "" Then

            Dim weekRange = GetWeekRange(DTP_WeekSelector.Value)

            Dim startDate As Date = weekRange.Item1
            Dim endDate As Date = weekRange.Item2

            DTP_StartDate.Value = startDate
            DTP_StartDate.Enabled = False
            DTP_EndDate.Value = endDate
            DTP_EndDate.Enabled = False

            DTP_StartDate.Visible = True
            DTP_EndDate.Visible = True
            LB_StartDate.Visible = True
            LB_EndDate.Visible = True
        End If

    End Sub

    Private Sub GetAdditionalValues()
        Dim CumulativesEmployees As DataTable = Get_CumulativesByEmployee()
        Dim CounterLine As Integer = 0

        'Scroll trough the list of employees into the DGV
        Dim EmpleadosAlerta As New List(Of String)
        For Each EmployeeCum As DataRow In CumulativesEmployees.Rows
            LB_Progress.Text = "Descargando y analizando información del empleado: " & DGV_CompleteWeekInfo.Item("Nombre Completo", CounterLine).Value
            LB_Progress.Refresh()
            Dim LunchHourAmmount As Decimal = 0.0
            Dim ProductGoodPract As Decimal = 0.0
            Dim ProductivityAmmount As Decimal = 0.0
            Dim AttitudeGoodPract As Decimal = 0.0
            Dim SavingAmmount As Decimal = 0.0
            Dim PaymentAmmount As Decimal = 0.0
            Dim PropPlantAmmount_1 As Decimal = 0.0
            Dim PropPlantAmmount_2 As Decimal = 0.0
            Dim ProdPlantTotalAmmount As Decimal = 0.0
            Dim BotoneroAmmount As Decimal = 0.0
            Dim TransportAmmount As Decimal = 0.0
            Dim BonoProdNeto As Decimal = 0.0

            Dim CounterOfDays As Integer = 0
            Dim EmployeeID As Integer = CInt(EmployeeCum(0))
            Dim CounterA As Integer = CInt(EmployeeCum(2))
            Dim CounterR As Integer = CInt(EmployeeCum(4))
            Dim CounterF As Integer = CInt(EmployeeCum(6))
            Dim CounterFJ As Integer = CInt(EmployeeCum(8))
            Dim CounterPG As Integer = CInt(EmployeeCum(10))
            Dim CounterPSG As Integer = CInt(EmployeeCum(12))
            Dim CounterV As Integer = CInt(EmployeeCum(14))

            'Let's paint the SUNDAY cell
            If CounterA = 6 Then
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(11).Value = "A"
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(11).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
            Else
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(11).Value = "NC"
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(11).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(230), CByte(153))
            End If

            'Get employee information
            Dim Employees = New CL_Employee
            Dim EmployeesCompleteInformation As DataTable = Employees.Get_EmployeesInfoByID(EmployeeID)

            Dim infonavit As Boolean = False
            Dim NewSalary As Decimal = 0.0
            Dim DailySalary As Decimal = 0.0
            Dim BaseSalary As Decimal = 0.0
            Dim SundaySalary As Decimal = 0.0
            Dim ExtraS As Decimal = 0.0
            Dim ExtraD As Decimal = 0.0
            Dim Extrat As Decimal = 0.0

            'Get employee's base salary 
            For Each EmployeeCompleteInformation As DataRow In EmployeesCompleteInformation.Rows
                BaseSalary = EmployeeCompleteInformation(9)
                If EmployeeCompleteInformation.IsNull(11) Then
                    infonavit = False
                Else
                    infonavit = EmployeeCompleteInformation(11)
                End If

            Next

            'infonavit
            DGV_CompleteWeekInfo.Item("Infonavit", CounterLine).Value = infonavit

            'Obtain sunday salary
            SundaySalary = (BaseSalary / 7)
            DailySalary = (BaseSalary / 7)
            Dim BaseSalaryFor6Days As Decimal = (DailySalary * 6) '7 días, incluyendo el domingo
            'BaseSalary = (DailySalary * 6)

            '----- 3.- asign value 

            'Get lunch hours by employee
            Dim AbsenceByEmploee = New CL_RecordsByEmployee
            Dim AbsenceRecords As DataTable = AbsenceByEmploee.Get_AbsenceInTheMonthByEmployee(Date.Today, EmployeeID, 60)
            Dim AbscenceNumber As Decimal = 0.0
            For Each AbscenceRecord As DataRow In AbsenceRecords.Rows
                AbscenceNumber = CDec(AbscenceRecord(0))
            Next
            If AbscenceNumber > 0 Then
                DGV_CompleteWeekInfo.Item("Faltas en el Mes", CounterLine).Value = AbscenceNumber
            End If

            ' Alerta: 4 o más faltas injustificadas ESTA semana
            If CounterF >= 4 Then
                DGV_CompleteWeekInfo.Item("Nombre Completo", CounterLine).ToolTipText = "⚠️ " & CounterF & " faltas injustificadas esta semana. Se recomienda hablar con el empleado."
                EmpleadosAlerta.Add("ID " & EmployeeID & " - " & DGV_CompleteWeekInfo.Item("Nombre Completo", CounterLine).Value.ToString() & " (" & CounterF & " faltas)")
            End If

            DGV_CompleteWeekInfo.Item("S. Diario", CounterLine).Value = DailySalary.ToString("C2")
            ExtraS = DailySalary / 48

            Dim MontoPorAsistencias As Decimal = DailySalary * CounterA
            DGV_CompleteWeekInfo.Item("Monto por Asistencias", CounterLine).Value = MontoPorAsistencias.ToString("C2")

            DGV_CompleteWeekInfo.Item("Ext. S", CounterLine).Value = ExtraS.ToString("C2")
            ExtraD = ExtraS * 2

            DGV_CompleteWeekInfo.Item("Ext. D", CounterLine).Value = ExtraD.ToString("C2")
            Extrat = ExtraS * 3

            DGV_CompleteWeekInfo.Item("Ext. T", CounterLine).Value = Extrat.ToString("C2")

            'Get lunch hours by employee
            Dim RecordsbyEmployee = New CL_RecordsByEmployee
            Dim LunchRecords As DataTable = RecordsbyEmployee.Get_LuchHoursByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 250)
            Dim LunchHours As Decimal = 0.0
            For Each LunchRecord As DataRow In LunchRecords.Rows
                LunchHours = CDec(LunchRecord(7))
            Next

            '' Amonestaciones
            'Dim BannsRecords As DataTable = RecordsbyEmployee.Get_BannQuantityByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 600)
            'Dim BannsQuantity As Decimal = 0.0
            'For Each BannRecord As DataRow In BannsRecords.Rows
            '    BannsQuantity = CDec(BannRecord(7))
            '    DGV_CompleteWeekInfo.Item("Amonest..", CounterLine).Value = BannsQuantity
            'Next

            'Hice cambio
            ' Amonestaciones - Saldo total
            Dim banniClass As New CL_EmployeeBanns()
            Dim totalAmonestacionesPendientes As Decimal = banniClass.GetEmployeeBannsBalance(EmployeeID)

            If totalAmonestacionesPendientes > 0 Then
                DGV_CompleteWeekInfo.Item("Amonest..", CounterLine).Value = totalAmonestacionesPendientes
            Else
                DGV_CompleteWeekInfo.Item("Amonest..", CounterLine).Value = 0
            End If

            ' muestra cuántos días de amonestación se generarán por las faltas de esta semana
            If CounterF > 0 Then
                DGV_CompleteWeekInfo.Item("Amonest. por Falta", CounterLine).Value = CounterF & " día(s)"
            Else
                DGV_CompleteWeekInfo.Item("Amonest. por Falta", CounterLine).Value = "0"
            End If

            'Transport Days by employee
            Dim TDaysRecords As DataTable = RecordsbyEmployee.Get_TDaysQuantityByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 285)
            Dim TDaysQuantity As Decimal = 0.0
            For Each TDaysRecord As DataRow In TDaysRecords.Rows
                TDaysQuantity = CDec(TDaysRecord(7))
            Next

            ''Extra time quantity
            'Dim ExtraTimeRecords As DataTable = RecordsbyEmployee.Get_ExtraTimeByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 850)
            'Dim ExtraTimeQuantity As Decimal = 0.0
            'For Each ExtraTimeRecord As DataRow In ExtraTimeRecords.Rows
            '    ExtraTimeQuantity = CDec(ExtraTimeRecord(7))
            '    DGV_CompleteWeekInfo.Item("No. H. Extra", CounterLine).Value = ExtraTimeQuantity.ToString()
            'Next

            ''Hice cambio
            'Extra time quantity
            Dim ExtraTimeRecords As DataTable = RecordsbyEmployee.Get_ExtraTimeByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 850)
            Dim HorasDobles As Decimal = 0.0
            Dim HorasTriples As Decimal = 0.0

            For Each ExtraTimeRecord As DataRow In ExtraTimeRecords.Rows
                If Not IsDBNull(ExtraTimeRecord("OVERT_TYPE")) Then
                    Dim tipo As String = ExtraTimeRecord("OVERT_TYPE").ToString().Trim()
                    Dim horas As Decimal = CDec(ExtraTimeRecord(7))

                    If tipo = "Doble" Then
                        HorasDobles += horas
                    ElseIf tipo = "Triple" Then
                        HorasTriples += horas
                    End If
                End If
            Next

            'If HorasDobles > 0 Then
            '    DGV_CompleteWeekInfo.Item("No. H. D", CounterLine).Value = HorasDobles
            '    DGV_CompleteWeekInfo.Item("Tipo. P. D", CounterLine).Value = "Doble"
            '    DGV_CompleteWeekInfo.Item("Monto H. D", CounterLine).Value = (HorasDobles * ExtraD).ToString("C2")
            'End If

            'If HorasTriples > 0 Then
            '    DGV_CompleteWeekInfo.Item("No. H. T", CounterLine).Value = HorasTriples
            '    DGV_CompleteWeekInfo.Item("Tipo. P. T", CounterLine).Value = "Triple"
            '    DGV_CompleteWeekInfo.Item("Monto H. T", CounterLine).Value = (HorasTriples * Extrat).ToString("C2")
            'End If

            Dim MontoExtraDoble As Decimal = 0.0
            Dim MontoExtraTriple As Decimal = 0.0

            If HorasDobles > 0 Then
                MontoExtraDoble = HorasDobles * ExtraD
                DGV_CompleteWeekInfo.Item("No. H. D", CounterLine).Value = HorasDobles
                DGV_CompleteWeekInfo.Item("Tipo. P. D", CounterLine).Value = "Doble"
                DGV_CompleteWeekInfo.Item("Monto H. D", CounterLine).Value = MontoExtraDoble.ToString("C2")
            End If

            If HorasTriples > 0 Then
                MontoExtraTriple = HorasTriples * Extrat
                DGV_CompleteWeekInfo.Item("No. H. T", CounterLine).Value = HorasTriples
                DGV_CompleteWeekInfo.Item("Tipo. P. T", CounterLine).Value = "Triple"
                DGV_CompleteWeekInfo.Item("Monto H. T", CounterLine).Value = MontoExtraTriple.ToString("C2")
            End If

            ' Transporte entre empleados
            Dim TEmployees As DataTable = RecordsbyEmployee.Get_TransportBetweenEmployeesAmount(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 280)
            Dim TEmployeesAmount As Decimal = 0.0
            For Each Item As DataRow In TEmployees.Rows
                TEmployeesAmount = CDec(Item(7))
            Next

            ' Bonus Botonero
            Dim BotoneroRecords As DataTable = RecordsbyEmployee.Get_BotoneroDetailsByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 900)
            Dim BotoneroAmount As Decimal = 0.0
            For Each BotoneroRecord As DataRow In BotoneroRecords.Rows
                'BotoneroAmount = CDec(BotoneroRecord(7))
                'DGV_CompleteWeekInfo.Item("Monto B. Botonero", CounterLine).Value = BotoneroAmount.ToString()
                DGV_CompleteWeekInfo.Item("Fecha inicio", CounterLine).Value = BotoneroRecord(7)
                DGV_CompleteWeekInfo.Item("Fecha fin", CounterLine).Value = BotoneroRecord(8)
            Next

            ' Monto a transferir
            Dim AmountToTransfer As DataTable = RecordsbyEmployee.Get_AmmountToTransfer(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 700)
            Dim AmountToTransferValue As Decimal = 0.0
            For Each Item As DataRow In AmountToTransfer.Rows
                AmountToTransferValue = CDec(Item(7))
                ' 35 - "Monto a transferir"
                'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(35).Value = AmountToTransferValue.ToString("C2")
                DGV_CompleteWeekInfo.Item("Monto a transferir", CounterLine).Value = AmountToTransferValue.ToString("C2")
            Next

            ' Monto infonavit
            Dim infonavitAmount As DataTable = RecordsbyEmployee.Get_infonavitAmmount(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 750)
            Dim infonavitAmountValue As Decimal = 0.0
            If infonavit = True And infonavitAmount.Rows.Count = 0 Then
                MessageBox.Show("El empleado " & EmployeeID & ": " & DGV_CompleteWeekInfo.Item("Nombre Completo", CounterLine).Value & " no tiene un monto de infonavit cargado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'DGV_CompleteWeekInfo.Item("Monto infonavit", CounterLine).Style.ForeColor = System.Drawing.Color.Yellow

                ' Deactivation of posibility to release the payment
                ReleasePayment = False
            Else
                For Each Item As DataRow In infonavitAmount.Rows
                    infonavitAmountValue = CDec(Item(7))
                    DGV_CompleteWeekInfo.Item("Monto infonavit", CounterLine).Value = infonavitAmountValue.ToString("C2")
                Next
            End If

            ' Adeudos
            Dim OwedAmount As DataTable = RecordsbyEmployee.Get_AmountOwedByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 800)
            Dim OwedAmountValue As Decimal = 0.0
            For Each Item As DataRow In OwedAmount.Rows
                OwedAmountValue = CDec(Item(7))
                DGV_CompleteWeekInfo.Item("Monto adeudo", CounterLine).Value = OwedAmountValue.ToString("C2")
                DGV_CompleteWeekInfo.Item("Monto adeudo", CounterLine).ToolTipText = Item(8).ToString
            Next

            ' Adeudos - Descuento
            Dim DiscountAmount As DataTable = RecordsbyEmployee.Get_DiscountOwedByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 800)
            Dim DiscountAmountValue As Decimal = 0.0
            Dim BalanceAmountValue As Decimal = 0.0
            For Each Item As DataRow In DiscountAmount.Rows
                DiscountAmountValue = CDec(Item(7))
                BalanceAmountValue = CDec(Item(9))
                DGV_CompleteWeekInfo.Item("Desc. por adeudo", CounterLine).Value = DiscountAmountValue.ToString("C2")
                DGV_CompleteWeekInfo.Item("Saldo adeudo", CounterLine).Value = BalanceAmountValue.ToString("C2")
            Next

            'If EmployeeID = 520 Then
            '    MsgBox(EmployeeID)
            'End If

            Dim Benefits As New CL_Benefits
            Dim ListOfBenefits As DataTable = Benefits.Get_AllActiveManualAutomaticBenefits

            'Let's scroll through the list of benefits
            For Each Benefit As DataRow In ListOfBenefits.Rows
                Dim Comment As String = ""
                Dim BenefitID As Integer = CInt(Benefit(0))
                Dim BenefitAmmount As Decimal = CDec(Benefit(4).ToString.Replace("%", ""))
                Dim DailyBenefit As Decimal = BenefitAmmount / 7

                Select Case BenefitID
                    'Hice cambio
                    'Case 10, 50 ' Bono de productividad

                    '    'Lets verify if employee has the benefitID
                    '    Dim BenefDetail As New CL_Benefits
                    '    BenefDetail.BENEF_ID = BenefitID
                    '    BenefDetail.EMPL_ID = EmployeeID
                    '    Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                    '    'Bono Productividad
                    '    If TBenefitDetails.Rows.Count > 0 Then
                    '        ' 22 - "Bono Prod."
                    '        'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(22).Value = BenefitAmmount.ToString("C2")
                    '        DGV_CompleteWeekInfo.Item("Bono Prod.", CounterLine).Value = BenefitAmmount.ToString("C2")
                    '        ProductivityAmmount = BenefitAmmount
                    '    Else
                    '        BenefitAmmount = 0.0
                    '        ' 22 - "Bono Prod."
                    '        'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(22).Value = BenefitAmmount.ToString("C2")
                    '        DGV_CompleteWeekInfo.Item("Bono Prod.", CounterLine).Value = BenefitAmmount.ToString("C2")
                    '    End If


                    Case 10, 50 'Bono de productividad
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then
                            ProductivityAmmount = BenefitAmmount
                            DGV_CompleteWeekInfo.Item("Bono Prod.", CounterLine).Value = BenefitAmmount.ToString("C2")
                        Else
                            DGV_CompleteWeekInfo.Item("Bono Prod.", CounterLine).Value = (0).ToString("C2")
                        End If

                    Case 40 ' Bono de comida

                        ' Let's show for all employes even some of them don't have the benefit but hours loaded
                        LunchHourAmmount = BenefitAmmount

                        ' 20 - "H. Comida"
                        'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(20).Value = LunchHours
                        DGV_CompleteWeekInfo.Item("H. Comida", CounterLine).Value = LunchHours

                        ' 21 - "B. Comida"
                        'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(21).Value = LunchHourAmmount.ToString("C2")
                        DGV_CompleteWeekInfo.Item("B. Comida", CounterLine).Value = LunchHourAmmount.ToString("C2")

                        DGV_CompleteWeekInfo.Item("Monto Total Comida", CounterLine).Value = (LunchHours * LunchHourAmmount).ToString("C2")

                    Case 60 ' Bono de transporte autobus empresarial

                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then

                            'Bono de productividad de planta
                            ' 27 - "D. Transporte"
                            'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(27).Value = TDaysQuantity
                            DGV_CompleteWeekInfo.Item("D. Transporte", CounterLine).Value = TDaysQuantity

                            ' 28 - "Transporte"
                            'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(28).Value = BenefitAmmount.ToString("C2")
                            DGV_CompleteWeekInfo.Item("Transporte", CounterLine).Value = BenefitAmmount.ToString("C2")
                            'Seguarda el monto en la variable TransportAmmount
                            TransportAmmount = BenefitAmmount
                        End If

                    Case 70 ' Bono de transporte entre empleados

                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then
                            ' 29 - "Transporte entre Empleados"
                            'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(29).Value = TEmployeesAmount
                            DGV_CompleteWeekInfo.Item("Transporte entre Empleados", CounterLine).Value = TEmployeesAmount
                        End If

                    Case 90, 100, 110, 120, 130, 140, 150, 160, 170 ' Bono de buenas practicas o actitud

                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then

                            'Bono Buenas Prácticas
                            ' 23 - "Bono BP"
                            'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(23).Value = BenefitAmmount.ToString("C2")
                            DGV_CompleteWeekInfo.Item("Bono BP", CounterLine).Value = BenefitAmmount.ToString("C2")
                            AttitudeGoodPract = BenefitAmmount
                        End If

                    Case 180, 190 ' Cantidad fija de ahorro
                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then
                            'Ahorro fijo
                            ' 25 - "Ahorro"
                            'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(25).Value = BenefitAmmount.ToString("C2")
                            DGV_CompleteWeekInfo.Item("Ahorro", CounterLine).Value = BenefitAmmount.ToString("C2")
                            SavingAmmount = BenefitAmmount
                        End If

                    Case 200 'Bono de productividad de planta 80%
                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then
                            PropPlantAmmount_1 = BenefitAmmount
                            ProdPlantTotalAmmount = (BaseSalary * 0.2 / 6) * CounterA
                            'ProdPlantTotalAmmount = BaseSalary * 0.2
                        End If

                    Case 210 'Bono de productividad de planta 90%
                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then
                            PropPlantAmmount_2 = BenefitAmmount
                            ProdPlantTotalAmmount = (BaseSalary * 0.3 / 6) * CounterA
                            'ProdPlantTotalAmmount = BaseSalary * 0.3
                        End If

                    'Case 220 'Bono de Botonero temporal
                    '    Dim BenefDetail As New CL_Benefits
                    '    BenefDetail.BENEF_ID = BenefitID
                    '    BenefDetail.EMPL_ID = EmployeeID
                    '    Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                    '    If TBenefitDetails.Rows.Count > 0 Then
                    '        BotoneroAmmount = BenefitAmmount
                    '        DGV_CompleteWeekInfo.Item("Monto B. botonero Temp", CounterLine).Value = BotoneroAmmount
                    '        MessageBox.Show("El empleado " & EmployeeID & ": " & DGV_CompleteWeekInfo.Item("Nombre Completo", CounterLine).Value & vbCrLf _
                    '            & "Tiene el bono de botonero, favor de verificar su periodo de validez. (" & DGV_CompleteWeekInfo.Item("Fecha inicio", CounterLine).Value & " - " _
                    '            & DGV_CompleteWeekInfo.Item("Fecha fin", CounterLine).Value & ")", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    End If

                    Case 220 'Bono de Botonero temporal
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()
                        If TBenefitDetails.Rows.Count > 0 Then
                            BotoneroAmmount = BenefitAmmount
                            DGV_CompleteWeekInfo.Item("Monto B. Botonero Temp", CounterLine).Value = BotoneroAmmount

                            ' Verificara que las fechas no sean nulas antes de convertir
                            Dim fechaInicioVal As Object = DGV_CompleteWeekInfo.Item("Fecha inicio", CounterLine).Value
                            Dim fechaFinVal As Object = DGV_CompleteWeekInfo.Item("Fecha fin", CounterLine).Value

                            If fechaInicioVal Is Nothing OrElse IsDBNull(fechaInicioVal) OrElse
                                 fechaFinVal Is Nothing OrElse IsDBNull(fechaFinVal) Then
                                ' No hay fechas registradas — avisar siempre
                                MessageBox.Show("El empleado " & EmployeeID & ": " & DGV_CompleteWeekInfo.Item("Nombre Completo", CounterLine).Value & vbCrLf _
                                                        & "Tiene el bono de botonero pero NO tiene fechas de vigencia registradas. Favor de verificar.",
                                                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                Dim fechaInicioBotonero As Date = Convert.ToDateTime(fechaInicioVal)
                                Dim fechaFinBotonero As Date = Convert.ToDateTime(fechaFinVal)

                                Dim semanaEnRango As Boolean = (DTP_StartDate.Value.Date <= fechaFinBotonero) AndAlso (DTP_EndDate.Value.Date >= fechaInicioBotonero)

                                If Not semanaEnRango Then
                                    MessageBox.Show("El empleado " & EmployeeID & ": " & DGV_CompleteWeekInfo.Item("Nombre Completo", CounterLine).Value & vbCrLf _
                                                        & "Tiene el bono de botonero, favor de verificar su periodo de validez. (" & fechaInicioBotonero.ToString("dd/MM/yyyy") & " - " _
                                                        & fechaFinBotonero.ToString("dd/MM/yyyy") & ")", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If

                    Case 230 'Bono de Botonero definitivo
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then
                            BotoneroAmmount = BenefitAmmount
                            DGV_CompleteWeekInfo.Item("Monto B. botonero Fijo", CounterLine).Value = BotoneroAmmount
                        End If
                    Case Else
                        'let's check if employee has loans - prestamos
                        Dim LoansDetail As New CL_EmployeeLoans
                        LoansDetail.EMPL_ID = EmployeeID
                        Dim TLoandsDetails As DataTable = LoansDetail.Get_AmmountOfLoandByEmployee

                        If TLoandsDetails.Rows.Count > 0 Then
                            For Each Line As DataRow In TLoandsDetails.Rows
                                'Let's validate that the ammount of discount is less or equal than the balance, else put only the balance
                                ' 30 - "Prestado" 
                                'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(30).Value = Line(1).ToString()
                                DGV_CompleteWeekInfo.Item("Prestado", CounterLine).Value = Line(1).ToString()

                                ' 31 - "Pagado" 
                                'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(31).Value = Line(2).ToString()
                                DGV_CompleteWeekInfo.Item("Pagado", CounterLine).Value = Line(2).ToString()

                                ' 32 - "Saldo a pagar" 
                                'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(32).Value = Line(3).ToString()
                                DGV_CompleteWeekInfo.Item("Saldo a pagar", CounterLine).Value = Line(3).ToString()

                                ' 33 - "Desc. Prest."
                                'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(33).Value = Line(4).ToString()
                                DGV_CompleteWeekInfo.Item("Desc. Prest.", CounterLine).Value = Line(4).ToString()
                                PaymentAmmount = CDec(Line(4).ToString.Replace("$", ""))
                            Next
                        End If

                        ' 23 - "Bono BP"
                        'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(23).Value = BenefitAmmount.ToString("C2")
                        DGV_CompleteWeekInfo.Item("Bono BP", CounterLine).Value = BenefitAmmount.ToString("C2")

                End Select

                'Reset the benefit ammount
                BenefitAmmount = 0.0
            Next

            If TB_ProdPlant.Text = "80" And (PropPlantAmmount_1 <> 0 Or PropPlantAmmount_2 <> 0) Then
                ' 26 - "Bono P. P." 
                'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(26).Value = PropPlantAmmount_1.ToString() & "%"
                DGV_CompleteWeekInfo.Item("Bono P. P.", CounterLine).Value = PropPlantAmmount_1.ToString() & "%"
                DGV_CompleteWeekInfo.Item("Monto Bono P. P.", CounterLine).Value = ProdPlantTotalAmmount.ToString("C2")

            ElseIf TB_ProdPlant.Text = "90" Then
                ' 26 - "Bono P. P." 
                'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(26).Value = PropPlantAmmount_2.ToString() & "%"
                DGV_CompleteWeekInfo.Item("Bono P. P.", CounterLine).Value = PropPlantAmmount_2.ToString() & "%"
                DGV_CompleteWeekInfo.Item("Monto Bono P. P.", CounterLine).Value = ProdPlantTotalAmmount.ToString("C2")
            End If

            'Hice cambio
            'AMONESTACIONES
            'Descuento de amonestaciones, Se descuenta del Bono de Productividad
            Dim BannDiscount As Decimal = 0.0D
            Dim DiasADescontar As Decimal = 0.0D

            If ProductivityAmmount > 0 Then
                Dim CLBanns As New CL_EmployeeBanns
                Dim PendingBanns As DataTable = CLBanns.GetPendingBannsDetails(EmployeeID)

                Dim DiasPendientes As Decimal = 0.0D
                For Each bannRow As DataRow In PendingBanns.Rows
                    DiasPendientes += CDec(bannRow("DREMPL_BALANCE"))
                Next

                DiasADescontar = Math.Min(DiasPendientes, 6)

                'If DiasADescontar > 0 Then
                '    BannDiscount = (ProductivityAmmount / 7) * DiasADescontar
                '    'DGV_CompleteWeekInfo.Item("Amonest..", CounterLine).Value = DiasADescontar
                'End If



                'Cálculo ya se muestra lo que se quedará
                If DiasADescontar > 0 Then
                    BannDiscount = (ProductivityAmmount / 7) * DiasADescontar

                    BonoProdNeto = ProductivityAmmount - BannDiscount
                    If BonoProdNeto < 0 Then BonoProdNeto = 0
                    DGV_CompleteWeekInfo.Item("Bono Prod. Neto", CounterLine).Value = BonoProdNeto.ToString("C2")
                Else
                    'If DiasADescontar = 0 Then
                    '    BonoProdNeto = 0
                    'End If
                    ' Si no hay amonestaciones, el neto es igual al original
                    'DGV_CompleteWeekInfo.Item("Bono Prod. Neto", CounterLine).Value = ProductivityAmmount.ToString("C2")
                    'DGV_CompleteWeekInfo.Item("Bono Prod. Neto", CounterLine).Value = 0
                    'BonoProdNeto = 0

                    DGV_CompleteWeekInfo.Item("Bono Prod. Neto", CounterLine).Value = ProductivityAmmount.ToString("C2")
                    BonoProdNeto = ProductivityAmmount    'sin amonestaciones, se paga completo

                End If
            End If

            ' monto final del bono de productividad, ya con faltas + amonestaciones descontadas
            Dim DiasTotalesADescontar As Decimal = CounterF + DiasADescontar
            Dim BonoProdFinal As Decimal = ProductivityAmmount - ((ProductivityAmmount / 7) * DiasTotalesADescontar)
            If BonoProdFinal < 0 Then BonoProdFinal = 0
            DGV_CompleteWeekInfo.Item("Bono Prod. Final", CounterLine).Value = BonoProdFinal.ToString("C2")


            'Hice cambio
            'Check salary by employee
            NewSalary = MainSalaryCalculation(CounterA, CounterF, CounterFJ, CounterR, CounterPG, CounterPSG, CounterV, BaseSalary,
                                              SundaySalary, DailySalary, LunchHourAmmount, ProductivityAmmount, AttitudeGoodPract,
                                              SavingAmmount, PaymentAmmount, LunchHours, BannDiscount, BotoneroAmmount, TransportAmmount,
                                              TEmployeesAmount, BonoProdNeto, ProdPlantTotalAmmount, DiscountAmountValue,
                                              MontoExtraDoble, MontoExtraTriple, infonavitAmountValue, BaseSalaryFor6Days)

            'Calculado
            ' 34 - "Calculado"
            'DGV_CompleteWeekInfo.Rows(CounterLine).Cells(34).Value = NewSalary.ToString("C2")
            DGV_CompleteWeekInfo.Item("Calculado", CounterLine).Value = NewSalary.ToString("C2")

            'Hice cambio
            ' Monto en efectivo = Monto Calculado - Monto a transferir
            Dim MontoEfectivo As Decimal = NewSalary - AmountToTransferValue
            If MontoEfectivo < 0 Then MontoEfectivo = 0
            DGV_CompleteWeekInfo.Item("Monto en efectivo", CounterLine).Value = MontoEfectivo.ToString("C2")

            CounterLine += 1

            SEL_MainWeekReportSalaryCalculation_PG_Progress(PB_Progress, CumulativesEmployees.Rows.Count, CounterLine)
            infonavit = False
        Next

        If EmpleadosAlerta.Count > 0 Then
            Dim mensaje As String = "Los siguientes empleados tienen 4 o más faltas injustificadas esta semana:" & vbCrLf & vbCrLf
            For Each item In EmpleadosAlerta
                mensaje &= "• " & item & vbCrLf
            Next
            mensaje &= vbCrLf & "Se recomienda hablar con ellos."
            MessageBox.Show(mensaje, "Aviso de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        LB_Progress.Text = "La información de " & CounterLine & " empleados fue analizada."


    End Sub

    Private Function CountLetterByEmployee(ByVal EmployeeNo As Integer, ByVal Letter As String) As Integer
        Dim EmployeeId As Integer = 0
        Dim Counter As Integer = 0

        If DGV_CompleteWeekInfo.Rows.Count = 0 Then Exit Function

        For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows
            EmployeeId = row.Cells(3).Value
            If EmployeeId = EmployeeNo Then

                'Recorrer columnas de días
                For i = 5 To DGV_CompleteWeekInfo.Columns.Count - 1
                    Dim valor = row.Cells(i).Value
                    If valor IsNot Nothing AndAlso valor.ToString() = Letter Then
                        Counter += 1
                    End If
                Next
            End If
        Next

        Return Counter
    End Function

    'Function to get the number of letters by employee in the week
    Private Function Get_CumulativesByEmployee() As DataTable
        Dim CounterLine As Integer = 0
        Dim Comment As String = ""
        Dim CounterA As Integer = 0
        Dim CounterR As Integer = 0
        Dim CounterF As Integer = 0
        Dim CounterFJ As Integer = 0
        Dim CounterPG As Integer = 0
        Dim CounterPSG As Integer = 0
        Dim CounterV As Integer = 0

        Dim CumulatesByEmployee As New DataTable
        CumulatesByEmployee.Columns.Add("EMPL_ID", GetType(Integer))
        CumulatesByEmployee.Columns.Add("ASISTANCE", GetType(String))
        CumulatesByEmployee.Columns.Add("ASIS_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("DELAYS", GetType(String))
        CumulatesByEmployee.Columns.Add("DEL_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("ABSENCE", GetType(String))
        CumulatesByEmployee.Columns.Add("ABS_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("JUST_ABSENCE", GetType(String))
        CumulatesByEmployee.Columns.Add("JABS_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("PERMISWITH", GetType(String))
        CumulatesByEmployee.Columns.Add("PG_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("PERMISWITHOUT", GetType(String))
        CumulatesByEmployee.Columns.Add("PSG_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("VACATIONS", GetType(String))
        CumulatesByEmployee.Columns.Add("V_QUANT", GetType(Integer))


        'let's get cumulatives
        For Each EmployeeInfo As DataGridViewRow In DGV_CompleteWeekInfo.Rows
            Dim EmployeeID As Integer = EmployeeInfo.Cells(3).Value

            'Verify Asistances
            CounterA = CountLetterByEmployee(EmployeeID, "A")

            'Count delays
            CounterR = CountLetterByEmployee(EmployeeID, "R")

            'Count Absences
            CounterF = CountLetterByEmployee(EmployeeID, "F")

            'Count justified absence
            CounterFJ = CountLetterByEmployee(EmployeeID, "FJ")


            'Count Permissions with salary
            CounterPG = CountLetterByEmployee(EmployeeID, "PG")

            'Count Permissions without salary
            CounterPSG = CountLetterByEmployee(EmployeeID, "PSG")

            'Count Vacations
            CounterV = CountLetterByEmployee(EmployeeID, "V")

            'Add to the list
            CumulatesByEmployee.Rows.Add(EmployeeID, "A", CounterA, "R", CounterR, "F", CounterF, "FJ", CounterFJ, "PG", CounterPG, "PSG", CounterPSG, "V", CounterV)

            CounterLine += 1
        Next

        Return CumulatesByEmployee
    End Function

    'Hice cambio
    Private Function MainSalaryCalculation(ByVal counterA As Integer, ByVal counterF As Integer, ByVal counterFJ As Integer, ByVal counterR As Integer,
                                                ByVal counterPG As Integer, ByVal counterPSG As Integer, ByVal counterV As Integer,
                                                ByVal BaseSalary As Decimal, ByVal SundaySalary As Decimal, ByVal DailySalary As Decimal,
                                                ByVal LunchHourAmmount As Decimal, ByVal ProductivityAmmount As Decimal, ByVal AttitudeGoodPract As Decimal,
                                                ByVal SavingAmmount As Decimal, ByVal PaymentAmmount As Decimal, ByVal LunchHours As Decimal, ByVal BannDiscount As Decimal,
                                                ByVal BotoneroAmmount As Decimal, ByVal TransportAmmount As Decimal, ByVal TransportBetweenAmmount As Decimal,
                                                ByVal BonoProdNeto As Decimal, ByVal ProdPlantTotalAmmount As Decimal, ByVal DiscountAmountValue As Decimal,
                                                ByVal MontoExtraDoble As Decimal, ByVal MontoExtraTriple As Decimal, ByVal infonavitAmountValue As Decimal, ByVal BaseSalaryFor6Days As Decimal) As Decimal
        Dim NewSalary As Decimal = 0.0

        Select Case counterA ' Number of assistance
            Case 6
                '6 asistencias
                'Si tiene 6 asistencias sin retardos
                'salario base + bono de productividad + proporcional de domingo 
                NewSalary = BaseSalaryFor6Days + ProductivityAmmount + AttitudeGoodPract + SundaySalary
                'NewSalary = BaseSalary + ProductivityAmmount + AttitudeGoodPract + SundaySalary
                NewSalary = NewSalary + (LunchHourAmmount * LunchHours)
                NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
                NewSalary = NewSalary + BonoProdNeto                 ' agregamos el monto despues de amonestaciones 
                NewSalary = NewSalary + ProdPlantTotalAmmount        ' agregamos el monto por productividad de la planta
                NewSalary = NewSalary - DiscountAmountValue          ' descontamos el monto por adeudo
                NewSalary = NewSalary + BotoneroAmmount              ' agregamos el biono de botonero
                NewSalary = NewSalary + MontoExtraDoble              ' Horas extra dobñe
                NewSalary = NewSalary + MontoExtraTriple             ' Horas extra Triple 

                NewSalary = NewSalary + TransportAmmount
                NewSalary = NewSalary + TransportBetweenAmmount
                NewSalary = NewSalary - infonavitAmountValue
            Case Else

                '----------------------------------- FALTAS INJUSTIFICADAS

                'Si hay una falta injustificada
                'Si tiene 5 asistencias y 1 falta injustificada
                'salario base de 5 dias-1/7 del proporcional de domingo-1 dia bonos de comida- 1 dia de bono de productividad-se le descuenta el bono de todas la semana del bono de buens practicas  
                If counterA = 5 And counterF = 1 Then
                    NewSalary = DailySalary * 5                                        ' salario base de 5 dias
                    NewSalary = NewSalary - (SundaySalary / 7)                         ' -1/7 del proporcional de domingo
                    NewSalary = NewSalary + Math.Max(0, LunchHourAmmount * (LunchHours - 1))
                    'NewSalary = NewSalary + (LunchHourAmmount * (LunchHours - 1))      ' -1 dia bonos de comida (-50)
                    NewSalary = NewSalary - (ProductivityAmmount / 7)                  ' -1 dia de bono de productividad
                    NewSalary = NewSalary + 0                                         ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                              ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                             ' Menos el pago por créditos
                    NewSalary = NewSalary - DiscountAmountValue                        ' Descuento por adeudo
                    NewSalary = NewSalary + MontoExtraDoble                            ' Horas extra dobñe
                    NewSalary = NewSalary + MontoExtraTriple                           ' Horas extra Triple
                    NewSalary = NewSalary + BonoProdNeto                               ' agregamos el monto despues de amonestaciones 
                    NewSalary = NewSalary + ProdPlantTotalAmmount                      ' agregamos el monto por productividad de la planta
                End If

                'Si hay dos faltas injustificadas
                'Si tiene 4 asistencias y 2 faltas injustificadas	
                'Salario base de 4 dias-2/7 del proporcional del domingo- 2 dias de bono de comida y productividad- se le descuenta el bono completo de toda la semana de buenas practicas 
                If counterA = 4 And counterF = 2 Then
                    NewSalary = DailySalary * 4                                     ' salario base de 4 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 2)                ' -2/7 del proporcional de domingo
                    NewSalary = NewSalary + Math.Max(0, LunchHourAmmount * (LunchHours - 2))
                    'NewSalary = NewSalary + (LunchHourAmmount * (LunchHours - 2))   ' -2 dia bonos de comida (-50)
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 2)         ' -2 dia de bono de productividad
                    NewSalary = NewSalary + 0                                      ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                           ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                          ' Menos el pago por créditos
                    NewSalary = NewSalary - DiscountAmountValue                     ' Descuento por adeudo
                    NewSalary = NewSalary + MontoExtraDoble                         ' Horas extra dobñe
                    NewSalary = NewSalary + MontoExtraTriple                        ' Horas extra Triple
                    NewSalary = NewSalary + BonoProdNeto                            ' agregamos el monto despues de amonestaciones
                    NewSalary = NewSalary + ProdPlantTotalAmmount                   ' agregamos el monto por productividad de la planta
                End If

                'Si hay tres faltas injustificadas
                'Si tiene 3 asistencias y 3 faltas injustificadas	
                'salario base de 3 dias- 3/7 del proporcional del domingo-3 dias del bono de productividad- se le descuenta bono completo de toda la semana de buenas practicas
                If counterA = 3 And counterF = 3 Then
                    NewSalary = DailySalary * 3                                     ' salario base de 3 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 3)                ' -3/7 del proporcional de domingo
                    NewSalary = NewSalary + Math.Max(0, LunchHourAmmount * (LunchHours - 3))
                    'NewSalary = NewSalary + (LunchHourAmmount * (LunchHours - 3))   ' -3 dia bonos de comida (-50)
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 3)         ' -3 dia de bono de productividad
                    NewSalary = NewSalary + 0                                       ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                           ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                          ' Menos el pago por créditos
                    NewSalary = NewSalary - DiscountAmountValue                     ' Descuento por adeudo
                    NewSalary = NewSalary + MontoExtraDoble                         ' Horas extra dobñe
                    NewSalary = NewSalary + MontoExtraTriple                        ' Horas extra triple
                    NewSalary = NewSalary + BonoProdNeto                            ' agregamos el monto despues de amonestaciones
                    NewSalary = NewSalary + ProdPlantTotalAmmount                   ' agregamos el monto por productividad de la planta
                End If

                'Si hay cuatro faltas injustificadas
                'Si tiene 2 asistencias y 4 faltas injustificadas	
                'salario base de 2 dias- 4/7 del proporcional del domingo-4 dias del bono de productividad- se le descuenta bono completo de toda la semana de buenas practicas

                If counterA = 2 And counterF = 4 Then
                    NewSalary = DailySalary * 2                                                 ' salario base de 2 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 4)                            ' -4/7 del proporcional de domingo
                    NewSalary = NewSalary + Math.Max(0, LunchHourAmmount * (LunchHours - 4))
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 4)                     ' -4 dia de bono de productividad
                    NewSalary = NewSalary + 0                                                   ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                                       ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                                      ' Menos el pago por créditos
                    NewSalary = NewSalary - DiscountAmountValue                                 ' Descuento por adeudo
                    NewSalary = NewSalary + MontoExtraDoble                                     ' Horas extra dobñe
                    NewSalary = NewSalary + MontoExtraTriple                                    ' Horas extra Triple
                    NewSalary = NewSalary + BonoProdNeto                                        ' agregamos el monto despues de amonestaciones
                    NewSalary = NewSalary + ProdPlantTotalAmmount                               ' agregamos el monto por productividad de la planta
                End If

                'Si hay cinco faltas injustificadas
                'Si tiene 1 asistencia y 5 faltas injustificadas	
                'salario base de 1 dias- 5/7 del proporcional del domingo-5 dias del bono de productividad- se le descuenta bono completo de toda la semana de buenas practicas

                If counterA = 1 And counterF = 5 Then
                    NewSalary = DailySalary * 1                                                 ' salario base de 2 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 5)                            ' -5/7 del proporcional de domingo
                    NewSalary = NewSalary + Math.Max(0, LunchHourAmmount * (LunchHours - 5))
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 5)                     ' -5 dia de bono de productividad
                    NewSalary = NewSalary + 0                                                   ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                                       ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                                      ' Menos el pago por créditos
                    NewSalary = NewSalary - DiscountAmountValue                                 ' Descuento por adeudo
                    NewSalary = NewSalary + MontoExtraDoble                                     ' Horas extra dobñe
                    NewSalary = NewSalary + MontoExtraTriple                                    ' Horas extra triple
                    NewSalary = NewSalary + BonoProdNeto                                        ' agregamos el monto despues de amonestaciones
                    NewSalary = NewSalary + ProdPlantTotalAmmount                               ' agregamos el monto por productividad de la planta
                End If

                'Si hay seis faltas injustificadas
                'Si tuvo 6 faltas injustificadas	
                'salario base de 0 dias- 6/7 del proporcional del domingo-no se le paga ningun bono 

                'If counterA = 0 And counterF = 6 Then
                '    NewSalary = DailySalary * 0                          ' salario base de 2 dias
                '    NewSalary = ((SundaySalary / 7) * 6)                 ' -6/7 del proporcional de domingo
                '    NewSalary = NewSalary + 0                            ' no se le paga ningun bono
                '    NewSalary = NewSalary + 0                            ' no se le paga ningun bono
                '    NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                '    NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
                'End If

                If counterA = 0 And counterF = 6 Then
                    NewSalary = 0
                End If

                '----------------------------------- FALTAS JUSTIFICADAS

                'Si tiene 5 asistencias y 1 falta justificada	
                'Salario base de 5 dias- 1/7 del proporcional del domingo, se le quitan 1 dia de todos lo bonos que tenga 
                If counterA = 5 And counterFJ = 1 Then
                    NewSalary = DailySalary * 5                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 1)        ' -1/7 del proporcional de domingo
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 1) ' -1 dia de bono de productividad
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 1)   ' se le descuenta un día de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tiene 4 asistencias y 2 faltas justificadas	
                'Salario base de 4 dias- 2/7 del proporcional del domingo, se le quitan 2 dia de todos lo bonos que tenga 
                If counterA = 4 And counterFJ = 2 Then
                    NewSalary = DailySalary * 4                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 2)        ' -2/7 del proporcional de domingo
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 2) ' -2 dia de bono de productividad
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 2)   ' se le descuentan dos días de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tiene 3 asistencias y 3 faltas justificadas	
                'Salario base de 3 dias- 3/7 del proporcional del domingo, se le quitan 3 dias de todos lo bonos que tenga 
                If counterA = 3 And counterFJ = 3 Then
                    NewSalary = DailySalary * 3                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 3)        ' -3/7 del proporcional de domingo
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 3) ' -3 dia de bono de productividad
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 3)   ' se le descuentan 3 días de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tiene 2 asistencias y 4 faltas justificadas	
                'Salario base de 2 dias- 4/7 del proporcional del domingo, se le quitan 4 dias de todos lo bonos que tenga 
                If counterA = 2 And counterFJ = 4 Then
                    NewSalary = DailySalary * 2                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 4)        ' -4/7 del proporcional de domingo
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 4) ' -4 dia de bono de productividad
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 4)   ' se le descuentan 4 días de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tiene 1 asistencias y 5 faltas justificadas	
                'Salario base de 1 dias- 5/7 del proporcional del domingo, se le quitan 5 dias de todos lo bonos que tenga 
                If counterA = 1 And counterFJ = 5 Then
                    NewSalary = DailySalary * 1                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 5)        ' -5/7 del proporcional de domingo
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 5) ' -5 dia de bono de productividad
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 5)   ' se le descuentan 5 días de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tiene 6 faltas justificadas	
                'Salario base de 0 dias-6/7 del proporcional del domingo, se le quitan 6 dias de todos lo bonos que tenga 
                If counterA = 0 And counterFJ = 6 Then
                    NewSalary = DailySalary * 0                             ' salario base de 5 dias
                    NewSalary = ((SundaySalary / 7) * 6)                    ' -6/7 del proporcional de domingo
                    NewSalary = NewSalary - ((ProductivityAmmount / 7) * 6) ' -6 dia de bono de productividad
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 6)   ' se le descuentan 6 días de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                '----------------------------------- RETARDOS

                'Si tienen 6 asistencias y 2 retardo	
                'Pago de sueldo base normal, amonestaciones de 1 dia del bono de buenas practicas
                If counterA = 6 And counterR = 2 Then
                    NewSalary = DailySalary * 6                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 1)   ' se le descuenta un día de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tienen 6 asistencias y 3 retardo	
                'Pago de sueldo base normal, amonestaciones de 1 semana del bono de buenas practicas
                If counterA = 3 And counterR = 3 Then
                    NewSalary = DailySalary * 6                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 7)   ' se le descuenta una semana de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tienen 6 asistencias y 4 retardo	
                'Pago de sueldo base normal, amonestaciones de 1 semana del bono de buenas practicas
                If counterA = 2 And counterR = 4 Then
                    NewSalary = DailySalary * 6                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 7)   ' se le descuenta una semana de buenas practicas
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tienen 6 asistencias y 5 retardo	
                'Pago de sueldo base normal, amonestaciones de 1 semana del bono de buenas practicas
                If counterA = 1 And counterR = 5 Then
                    NewSalary = DailySalary * 6                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 7)   ' se le descuenta una semana de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If

                'Si tienen 6 asistencias y 6 retardo	
                'Pago de sueldo base normal, amonestaciones de 1 semana del bono de buenas practicas
                If counterR = 6 Then
                    NewSalary = DailySalary * 6                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 7)   ' se le descuenta una semana de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If


                '------------- Escenarios con retardos
                'Si tienen 3 asistencias con retardo y 3 faltas	
                '????
                If counterA = 0 And counterR = 3 And counterF = 3 Then
                    NewSalary = DailySalary * 6                             ' salario base de 5 dias
                    NewSalary = NewSalary - ((AttitudeGoodPract / 7) * 7)   ' se le descuenta una semana de buenas practicas 
                    NewSalary = NewSalary - SavingAmmount                   ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount                  ' Menos el pago por créditos
                End If


                ' Bonos adicionales
                NewSalary = NewSalary + BotoneroAmmount
                NewSalary = NewSalary + TransportAmmount
                NewSalary = NewSalary + TransportBetweenAmmount
                NewSalary = NewSalary - infonavitAmountValue
        End Select

        Return NewSalary
    End Function

    Private Sub DGV_CompleteWeekInfo_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_CompleteWeekInfo.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_CompleteWeekInfo.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_CompleteWeekInfo.Rows(hit.RowIndex)

            Dim Employee_Id As Integer = CInt(row.Cells(3).Value)

            Dim EmployeeRecords As New CL_RecordsByEmployee
            Dim EmployeeInfo = EmployeeRecords.Get_WeekRecordsDetailsBYEmployee(DTP_StartDate.Value, DTP_EndDate.Value, Employee_Id)

            DGV_BenefitsDetailsByEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_BenefitsDetailsByEmployee.AutoResizeColumns()
            DGV_BenefitsDetailsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DGV_BenefitsDetailsByEmployee.DataSource = EmployeeInfo
        End If

    End Sub

    Private Sub CB_Confirmation_MouseClick(sender As Object, e As MouseEventArgs) Handles CB_Confirmation.MouseClick
        If DGV_CompleteWeekInfo.Rows.Count > 0 Then
            If CB_Confirmation.Checked = True Then
                If MessageBox.Show("¿Confirma la liberación de nómina para esta semana?", "Aviso de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BT_FinalConfirmation.Enabled = True
                Else
                    CB_Confirmation.Checked = False
                    BT_FinalConfirmation.Enabled = False
                End If
            Else
                BT_FinalConfirmation.Enabled = False
            End If
        End If

    End Sub

    Private Sub BT_FinalConfirmation_Click(sender As Object, e As EventArgs) Handles BT_FinalConfirmation.Click
        'For Each Item As DataGridViewRow In DGV_CompleteWeekInfo.Rows

        '    'verify If there Is saving
        '    If Item.Cells(23).Value IsNot Nothing AndAlso
        '    Not IsDBNull(Item.Cells(23).Value) AndAlso
        '    IsNumeric(Item.Cells(23).Value) AndAlso
        '    CDec(Item.Cells(23).Value) > 0 Then

        '        'Register automatic saving
        '        Dim EmployeeSaving As New CL_RecordsByEmployeeMoneySaved
        '        EmployeeSaving.EMPL_ID = CInt(Item.Cells(1).Value)
        '        EmployeeSaving.DREMPL_AMM = CDec(Item.Cells(21).Value)
        '        EmployeeSaving.DREMPL_TYPE = 2
        '        EmployeeSaving.REMPL_RDATE = Today
        '        EmployeeSaving.REMPL_CREBY = AppUser
        '        EmployeeSaving.InsertAutomaticSaving()
        '    End If

        '    'verify if there is discounts for paymets
        '    If Item.Cells(30).Value IsNot Nothing AndAlso
        '       Not IsDBNull(Item.Cells(30).Value) AndAlso
        '       IsNumeric(Item.Cells(30).Value) AndAlso
        '       CDec(Item.Cells(30).Value) > 0 Then

        '        'Register automatic saving
        '        Dim EmployeeLoans As New CL_EmployeeLoans
        '        EmployeeLoans.EMPL_ID = CInt(Item.Cells(1).Value)

        '        Dim LoansDetailsByEmployee As DataTable = EmployeeLoans.Get_LoandsByEmployeeDetails()

        '        If LoansDetailsByEmployee.Rows.Count > 0 Then
        '            For Each Line As DataRow In LoansDetailsByEmployee.Rows
        '                EmployeeLoans.LOAN_ID = Line(0)
        '                EmployeeLoans.LOAN_PAYM = Line(5)
        '                EmployeeLoans.LOAN_PTYPE = 2
        '                EmployeeLoans.InsertPayment()
        '            Next
        '        End If
        '    End If

        'Next

        If DGV_CompleteWeekInfo.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para procesar en la tabla actual.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea guardar la nómina de la semana actual?",
        "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmacion = DialogResult.No Then Return

        Dim objP As New CL_Payroll()

        If objP.ValidatePayrollWeek(DTP_StartDate.Value.Date,
                            DTP_EndDate.Value.Date) Then

            MessageBox.Show("Esta nómina ya fue confirmada anteriormente.",
                    "Nómina duplicada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            Exit Sub
        End If

        Dim savedCount As Integer = 0

        Try

            Dim ToDec = Function(valor As Object) As Decimal
                            If valor Is Nothing OrElse IsDBNull(valor) OrElse valor.ToString.Trim = "" Then Return 0
                            Dim s As String = valor.ToString.Replace("$", "").Trim
                            Dim d As Decimal = 0
                            Decimal.TryParse(s, d)
                            Return d
                        End Function

            For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows

                If row.Cells("No.").Value Is Nothing OrElse row.IsNewRow Then Continue For

                objP.EmployeeID = row.Cells("No.").Value
                objP.FullName = row.Cells("Nombre Completo").Value.ToString()
                objP.Company = row.Cells("Empresa").Value.ToString()
                objP.Position = row.Cells("Posición").Value.ToString()

                objP.StartDate = DTP_StartDate.Value
                objP.EndDate = DTP_EndDate.Value

                objP.BaseSalary = ToDec(row.Cells("S. Base").Value)
                objP.DailySalary = ToDec(row.Cells("S. Diario").Value)
                objP.AbsencesMonth = CInt(ToDec(row.Cells("Faltas en el Mes").Value))

                objP.ExtraS = ToDec(row.Cells("Ext. S").Value)
                objP.ExtraD = ToDec(row.Cells("Ext. D").Value)
                objP.ExtraT = ToDec(row.Cells("Ext. T").Value)
                objP.LunchHours = ToDec(row.Cells("H. Comida").Value)
                objP.LunchBonus = ToDec(row.Cells("B. Comida").Value)
                objP.ProductivityBonus = ToDec(row.Cells("Bono Prod.").Value)
                objP.AttitudeBonus = ToDec(row.Cells("Bono BP").Value)
                objP.Savings = ToDec(row.Cells("Ahorro").Value)
                objP.TransportDays = ToDec(row.Cells("D. Transporte").Value)
                objP.TransportBonus = ToDec(row.Cells("Transporte").Value)
                objP.LoanDiscount = ToDec(row.Cells("Desc. Prest.").Value)

                objP.TotalNeto = ToDec(row.Cells("Calculado").Value)
                objP.CreatedBy = AppUser

                Dim currentID = objP.InsertPayrollWeek()

                If currentID IsNot Nothing AndAlso IsNumeric(currentID) Then

                    objP.PayrollID = currentID

                    For i As Integer = 0 To 6
                        Dim fechaColumna As String = DTP_StartDate.Value.AddDays(i).ToString("dd/MM/yyyy")

                        objP.WorkDate = DTP_StartDate.Value.AddDays(i)
                        objP.Status = row.Cells(fechaColumna).Value.ToString()

                        objP.InsertPayrollAttendance()
                    Next

                    'Hice cambio
                    'Se hce el calculo de descuento por amonestaciones
                    Dim amonestCellVal As Object = row.Cells("Amonest..").Value
                    Dim diasDescontados As Decimal = 0.0D
                    If amonestCellVal IsNot Nothing AndAlso Not IsDBNull(amonestCellVal) Then
                        Decimal.TryParse(amonestCellVal.ToString(), diasDescontados)
                    End If

                    If diasDescontados > 0 Then
                        diasDescontados = Math.Min(diasDescontados, 6)
                        Dim empleadoID As Integer = CInt(row.Cells("No.").Value)
                        Dim CLBanns As New CL_EmployeeBanns
                        Dim PendingBanns As DataTable = CLBanns.GetPendingBannsDetails(empleadoID)

                        Dim DiasRestantesADescontar As Decimal = diasDescontados
                        For Each bannRow As DataRow In PendingBanns.Rows
                            If DiasRestantesADescontar <= 0 Then Exit For

                            Dim recordId As Integer = CInt(bannRow("DREMPL_ID"))
                            Dim saldoRegistro As Decimal = CDec(bannRow("DREMPL_BALANCE"))

                            Dim diasParaEsteRegistro As Decimal = Math.Min(saldoRegistro, DiasRestantesADescontar)
                            Dim comentario As String = $"Descuento aplicado en nómina semana {DTP_StartDate.Value:dd/MM/yyyy} - {DTP_EndDate.Value:dd/MM/yyyy}: -{diasParaEsteRegistro} día(s)."


                            CLBanns.ApplyBannDiscount(recordId, diasParaEsteRegistro, comentario)
                            DiasRestantesADescontar -= diasParaEsteRegistro
                        Next
                    End If

                    ' Generar amonestación automática por cada falta injustificada de la semana
                    Dim CounterFaltas As Integer = CountLetterByEmployee(CInt(row.Cells("No.").Value), "F")
                    If CounterFaltas > 0 Then
                        Dim CLBannInsert As New CL_EmployeeBanns
                        CLBannInsert.REMPL_ID = CInt(row.Cells("No.").Value)
                        CLBannInsert.DREMPL_DATE = DTP_StartDate.Value.Date
                        CLBannInsert.DREMPL_DQUANTITY = CounterFaltas
                        CLBannInsert.DREMPL_BNAME = "Falta injustificada"
                        CLBannInsert.DREMPL_DESCR = $"Amonestación automática por {CounterFaltas} falta(s) injustificada(s) en la semana {DTP_StartDate.Value:dd/MM/yyyy} - {DTP_EndDate.Value:dd/MM/yyyy}."
                        CLBannInsert.DREMPL_CREBY = AppUser
                        CLBannInsert.DREMPL_STATUS = True

                        CLBannInsert.InsertEmployeeBann()
                    End If

                    savedCount += 1
                End If
            Next

            MessageBox.Show("Se han guardado " & savedCount & " registros exitosamente.",
                        "Sistema de Nómina", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error crítico al procesar la información: " & ex.Message,
                        "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SEL_MainWeekReportSalaryCalculation_PG_Progress(progress As System.Windows.Forms.ProgressBar, totalItems As Integer, currentItem As Integer)

        If totalItems <= 0 Then Exit Sub

        Dim percentage As Integer = CInt((currentItem / totalItems) * 100)

        If percentage > 100 Then percentage = 100
        If percentage < 0 Then percentage = 0

        progress.Value = percentage

    End Sub

    Private Sub DGV_CompleteWeekInfo_Sorted(sender As Object, e As EventArgs) Handles DGV_CompleteWeekInfo.Sorted
        PaintCells_Sorted()
    End Sub

    Private Sub TB_ProdPlant_Leave(sender As Object, e As EventArgs) Handles TB_ProdPlant.Leave
        If Not ValidarProdPlant() Then
            Exit Sub
        Else
            DTP_WeekSelector.Enabled = True
        End If
    End Sub

    Private Sub BT_ExportExcel_Click(sender As Object, e As EventArgs) Handles BT_ExportExcel.Click
        Try
            Using workbook As New XLWorkbook()
                Dim wsResumen = workbook.Worksheets.Add("Resumen Nómina")

                For col As Integer = 0 To DGV_CompleteWeekInfo.Columns.Count - 1
                    Dim cell = wsResumen.Cell(1, col + 1)
                    cell.Value = DGV_CompleteWeekInfo.Columns(col).HeaderText
                    cell.Style.Font.Bold = True
                    cell.Style.Fill.BackgroundColor = XLColor.AirForceBlue
                    cell.Style.Font.FontColor = XLColor.White
                Next

                For row As Integer = 0 To DGV_CompleteWeekInfo.Rows.Count - 1
                    If Not DGV_CompleteWeekInfo.Rows(row).IsNewRow Then
                        For col As Integer = 0 To DGV_CompleteWeekInfo.Columns.Count - 1
                            wsResumen.Cell(row + 2, col + 1).Value = DGV_CompleteWeekInfo.Rows(row).Cells(col).Value?.ToString()
                        Next
                    End If
                Next
                wsResumen.Columns().AdjustToContents()

                Dim wsDetalle = workbook.Worksheets.Add("Detalle de Asistencia")

                Dim CL As New CL_Payroll
                Dim dtDetalle As DataTable

                Dim fechaIni As String = DTP_StartDate.Value.ToString("yyyy-MM-dd")
                Dim fechaFin As String = DTP_EndDate.Value.ToString("yyyy-MM-dd")

                dtDetalle = CL.GetWeeklyAttendance(Convert.ToDateTime(fechaIni), Convert.ToDateTime(fechaFin))



                If dtDetalle.Rows.Count > 0 Then

                    For col As Integer = 0 To dtDetalle.Columns.Count - 1

                        Dim cell = wsDetalle.Cell(1, col + 1)

                        cell.Value = dtDetalle.Columns(col).ColumnName
                        cell.Style.Font.Bold = True
                        cell.Style.Fill.BackgroundColor = XLColor.AirForceBlue
                        cell.Style.Font.FontColor = XLColor.White

                    Next

                    For row As Integer = 0 To dtDetalle.Rows.Count - 1

                        For col As Integer = 0 To dtDetalle.Columns.Count - 1

                            wsDetalle.Cell(row + 2, col + 1).Value =
                dtDetalle.Rows(row)(col).ToString()

                        Next

                    Next

                    wsDetalle.Columns().AdjustToContents()

                Else

                    wsDetalle.Cell(1, 1).Value = "No hay datos en el detalle."

                End If

                Dim sfd As New SaveFileDialog()
                sfd.Filter = "Excel Files|*.xlsx"
                sfd.FileName = "Nomina_Semana_" & DateTime.Now.ToString("ddMMyyyy")

                If sfd.ShowDialog() = DialogResult.OK Then
                    workbook.SaveAs(sfd.FileName)
                    MessageBox.Show("Archivo Excel generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al generar Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
