Public Class OP_PayrollApproval
    Private Sub OP_PayrollApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_Approvals.AutoGenerateColumns = False
        DGV_Approvals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_PayrollDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        CargarPendientes()
    End Sub

    Private Sub CargarPendientes()
        Dim CL As New CL_Payroll
        Dim dt As DataTable = CL.GetPendingApprovals()

        DGV_Approvals.Rows.Clear()
        DGV_PayrollDetail.DataSource = Nothing

        For Each row As DataRow In dt.Rows
            DGV_Approvals.Rows.Add(
                row("ApprovalID"),
                row("BatchID").ToString(),
                CDate(row("StartDate")).ToString("dd/MM/yyyy"),
                CDate(row("EndDate")).ToString("dd/MM/yyyy"),
                CDec(row("Amount")).ToString("C2"),
                row("RequestedBy").ToString()
            )
        Next

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No hay nóminas pendientes de aprobación.", "Sin pendientes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DGV_Approvals_SelectionChanged(sender As Object, e As EventArgs) Handles DGV_Approvals.SelectionChanged
        If DGV_Approvals.CurrentRow Is Nothing Then Exit Sub

        Dim batchID As String = DGV_Approvals.CurrentRow.Cells("ColBatchID").Value.ToString()
        Dim CL As New CL_Payroll
        DGV_PayrollDetail.DataSource = CL.GetPayrollWeekByBatch(batchID)

        AplicarEncabezadosAmigables()
    End Sub

    Private Sub AplicarEncabezadosAmigables()
        Dim nombres As New Dictionary(Of String, String) From {
        {"EmployeeID", "No. Emp."},
        {"StartDate", "Fecha Inicio"},
        {"EndDate", "Fecha Fin"},
        {"Company", "Empresa"},
        {"FullName", "Nombre Completo"},
        {"Position", "Puesto"},
        {"BaseSalary", "Salario Base"},
        {"DailySalary", "Salario Diario"},
        {"AbsencesMonth", "Faltas Mes"},
        {"ExtraS", "Ext. S"},
        {"ExtraD", "Monto H. D"},
        {"ExtraT", "Monto H. T"},
        {"LunchHours", "Hrs. Comida"},
        {"LunchBonus", "Bono Comida"},
        {"ProductivityBonus", "Bono Prod."},
        {"AttitudeBonus", "Bono BP"},
        {"Savings", "Ahorro"},
        {"TransportDays", "Días Transporte"},
        {"TransportBonus", "Bono Transporte"},
        {"LoanDiscount", "Desc. Préstamo"},
        {"TotalNeto", "Calculado"},
        {"AttitudeBonusFinal", "Bono BP Final"},
        {"ProductivityBonusFinal", "Bono Prod. Final"},
        {"PlantBonusAmount", "Monto Bono P.P."},
        {"TransportBetweenEmployeesBonus", "Transp. Entre Emp."},
        {"BotoneroTempFinal", "Botonero Temp Final"},
        {"BotoneroFijoFinal", "Botonero Fijo Final"},
        {"LoanAmount", "Prestado"},
        {"LoanPaid", "Pagado"},
        {"LoanBalance", "Saldo Préstamo"},
        {"HasInfonavit", "Infonavit"},
        {"InfonavitAmount", "Monto Infonavit"},
        {"AbsenceHours", "No. Horas A."},
        {"AbsenceHoursDiscount", "Desc. Horas A."},
        {"DebtAmount", "Monto Adeudo"},
        {"DebtDiscount", "Desc. Adeudo"},
        {"DebtBalance", "Saldo Adeudo"},
        {"TransferAmount", "Monto Transferencia"},
        {"CashAmount", "Monto Efectivo"}
    }

        Dim ocultas As String() = {"CreatedBy", "BatchID", "PayrollID", "CreatedAt"}

        For Each col As DataGridViewColumn In DGV_PayrollDetail.Columns
            If ocultas.Contains(col.Name) Then
                col.Visible = False
            ElseIf nombres.ContainsKey(col.Name) Then
                col.HeaderText = nombres(col.Name)
            End If
        Next
    End Sub

    Private Sub DGV_Approvals_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Approvals.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim approvalID As Integer = CInt(DGV_Approvals.Rows(e.RowIndex).Cells("ColApprovalID").Value)
        Dim batchID As String = DGV_Approvals.Rows(e.RowIndex).Cells("ColBatchID").Value.ToString()
        Dim columnaClic As String = DGV_Approvals.Columns(e.ColumnIndex).Name

        If columnaClic = "ColApprove" Then

            Dim confirmacion = MessageBox.Show($"¿Confirma que aprueba la nómina {batchID}?",
                                                "Confirmar aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmacion = DialogResult.No Then Exit Sub

            Dim CL As New CL_Payroll
            If CL.UpdatePayrollApprovalStatus(approvalID, "Aprobado", AppUser) Then
                MessageBox.Show($"Nómina {batchID} aprobada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarPendientes()
            End If

        ElseIf columnaClic = "ColReject" Then

            Dim motivo As String = InputBox($"¿Por qué se rechaza la nómina {batchID}?" & vbCrLf &
                                             "(este motivo se le va a mostrar a quien la corrija)",
                                             "Motivo de rechazo")

            If String.IsNullOrWhiteSpace(motivo) Then
                MessageBox.Show("Debe escribir un motivo para poder rechazar.", "Motivo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim CL As New CL_Payroll
            If CL.UpdatePayrollApprovalStatus(approvalID, "Rechazado", AppUser, motivo) Then
                MessageBox.Show($"Nómina {batchID} rechazada." & vbCrLf &
                                 "Ve al módulo de cálculo de nómina, corrige lo necesario, y vuelve a liberar la nómina de esa misma semana " &
                                 "para que se genere automáticamente la versión corregida.",
                                 "Nómina rechazada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CargarPendientes()
            End If

        End If
    End Sub
End Class