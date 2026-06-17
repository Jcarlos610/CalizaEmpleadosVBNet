Imports Microsoft.Data.SqlClient

Public Class OP_UPD_EmployeeAmountDebt

    Dim SelectedDebtID As Integer = 0

    Private Sub OP_UPD_EmployeeAmountDebt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGridGeneral()
    End Sub

    Private Sub CargarGridGeneral()
        Try
            Dim CL As New CL_EmployeeAmountDebt
            DGV_Debt.DataSource = CL.GetDebtsHistory(0)

            If DGV_Debt.Columns.Count > 0 Then
                If DGV_Debt.Columns.Contains("ID") Then DGV_Debt.Columns("ID").Visible = False

                DGV_Debt.ReadOnly = True
                DGV_Debt.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                DGV_Debt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                If DGV_Debt.Columns.Contains("Monto Total") Then DGV_Debt.Columns("Monto Total").DefaultCellStyle.Format = "C2"
                If DGV_Debt.Columns.Contains("Saldo Pendiente") Then DGV_Debt.Columns("Saldo Pendiente").DefaultCellStyle.Format = "C2"
                If DGV_Debt.Columns.Contains("Descuento Periódico") Then DGV_Debt.Columns("Descuento Periódico").DefaultCellStyle.Format = "C2"
            End If
        Catch ex As Exception
            MsgBox("Error al cargar el listado de adeudos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Private Sub DGV_Debt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Debt.CellClick
    '    If e.RowIndex >= 0 Then
    '        Try
    '            Dim row As DataGridViewRow = DGV_Debt.Rows(e.RowIndex)

    '            SelectedDebtID = Convert.ToInt32(row.Cells("ID").Value)

    '            TB_EmployeeId.Text = row.Cells("Núm. Empleado").Value.ToString()
    '            TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()
    '            TB_DebtCause.Text = row.Cells("Causa Adeudo").Value.ToString()
    '            TB_Comment.Text = row.Cells("Descripción").Value.ToString()
    '            TB_TotalAmount.Text = row.Cells("Monto Total").Value.ToString()
    '            TB_PeriodicDiscount.Text = row.Cells("Descuento Periódico").Value.ToString()
    '            TB_AuthorizeBy.Text = row.Cells("Autorizado Por").Value.ToString()

    '            If IsDate(row.Cells("Fecha Aplicación").Value) Then
    '                DTP_Valid.Value = Convert.ToDateTime(row.Cells("Fecha Aplicación").Value)
    '            End If
    '            Dim estadoStr As String = row.Cells("Estado").Value.ToString()
    '            CB_Stat.Checked = (estadoStr = "Activo")

    '        Catch ex As Exception
    '            MsgBox("Error al seleccionar el registro del Grid: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
    '        End Try
    '    End If
    'End Sub

    Private Sub DGV_Debt_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Debt.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_Debt.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Debt.Rows(hit.RowIndex)

                SelectedDebtID = Convert.ToInt32(row.Cells("ID").Value)

                TB_EmployeeId.Text = row.Cells("Núm. Empleado").Value.ToString()
                TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()
                TB_DebtCause.Text = row.Cells("Causa Adeudo").Value.ToString()
                TB_Comment.Text = row.Cells("Descripción").Value.ToString()
                TB_TotalAmount.Text = row.Cells("Monto Total").Value.ToString()
                TB_PeriodicDiscount.Text = row.Cells("Descuento Periódico").Value.ToString()
                TB_AuthorizeBy.Text = row.Cells("Autorizado Por").Value.ToString()

                If IsDate(row.Cells("Fecha Aplicación").Value) Then
                    DTP_Valid.Value = Convert.ToDateTime(row.Cells("Fecha Aplicación").Value)
                End If

                Dim estadoStr As String = row.Cells("Estado").Value.ToString()
                CB_Stat.Checked = (estadoStr = "Activo")

            Catch ex As Exception
                MsgBox("Error al seleccionar el registro del Grid: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
            End Try
        End If
    End Sub

    Private Sub DGV_Debt_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Debt.CellFormatting
        If DGV_Debt.Columns.Contains("Estado") Then
            Dim estadoValue As Object = DGV_Debt.Rows(e.RowIndex).Cells("Estado").Value

            If estadoValue IsNot Nothing AndAlso estadoValue.ToString() = "Modificado/Inactivo" Then

                e.CellStyle.ForeColor = Color.DarkGray

            End If
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        If SelectedDebtID = 0 Then
            MsgBox("Por favor, seleccione primero un registro del listado superior para editar.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        If String.IsNullOrWhiteSpace(TB_DebtCause.Text) OrElse String.IsNullOrWhiteSpace(TB_AuthorizeBy.Text) Then
            MsgBox("La causa del adeudo y la persona que autoriza son campos obligatorios.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        Dim totalAmt As Decimal = 0
        Dim periodicDiscount As Decimal = 0

        If Not Decimal.TryParse(TB_TotalAmount.Text, totalAmt) OrElse totalAmt <= 0 Then
            MsgBox("Ingrese un monto total válido mayor a $0.00.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        If Not Decimal.TryParse(TB_PeriodicDiscount.Text, periodicDiscount) OrElse periodicDiscount <= 0 Then
            MsgBox("Ingrese un cobro periódico válido mayor a $0.00.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        Try
            Dim CL As New CL_EmployeeAmountDebt
            CL.DAMT_DATE = DTP_Valid.Value.Date
            CL.DAMT_CAUSE = TB_DebtCause.Text.Trim()
            CL.DAMT_DESCR = TB_Comment.Text.Trim()
            CL.DAMT_TOTAL_AMOUNT = totalAmt
            CL.DAMT_PERIODIC_DISCOUNT = periodicDiscount
            CL.DAMT_AUTH = TB_AuthorizeBy.Text.Trim()
            CL.DAMT_CREBY = GlobalSession.GlobalUserName

            CL.DAMT_STATUS = CB_Stat.Checked

            CL.DAMT_CURRENT_BALANCE = totalAmt
            CL.DAMT_PAYMENT_STATUS = "Pendiente"

            If CL.UpdateEmployeeDebt(SelectedDebtID) Then

                ' LOG
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"MODIFICACIÓN ADEUDO: Se actualizó el registro ID {SelectedDebtID} del empleado {TB_EmployeeName.Text}. Estatus Lógico: {If(CB_Stat.Checked, "Activo", "Inactivo")}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_AdeudosEmpresa", "UPDATE_SUCCESS", descLog, CInt(TB_EmployeeId.Text), "INFO")
                End Using

                MsgBox("¡El registro de adeudo ha sido modificado con éxito!", MsgBoxStyle.Information, "Actualización Completa")

                CargarGridGeneral()
                ResetFormFields()
            End If

        Catch ex As Exception
            ' LOG DE error
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL ACTUALIZAR ADEUDO: {ex.Message} en ID {SelectedDebtID}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_AdeudosEmpresa", "UPDATE_EXCEPTION", descError, CInt(If(String.IsNullOrEmpty(TB_EmployeeId.Text), 0, TB_EmployeeId.Text)), "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("Error al escribir log de actualización: " & logEx.Message)
            End Try

            MsgBox("Error crítico al intentar modificar el registro: " & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try

    End Sub

    Private Sub ResetFormFields()
        SelectedDebtID = 0
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_DebtCause.Clear()
        TB_Comment.Clear()
        TB_TotalAmount.Clear()
        TB_PeriodicDiscount.Clear()
        TB_AuthorizeBy.Clear()
        DTP_Valid.Value = DateTime.Now
        CB_Stat.Checked = True
    End Sub

End Class