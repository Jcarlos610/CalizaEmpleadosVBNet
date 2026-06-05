Imports Microsoft.Data.SqlClient

Public Class OP_INS_EmployeeAmountDebt

    Dim SelectedEmplID As Integer = 0

    Private Sub OP_INS_EmployeeAmountDebt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBX_Suggesting.Visible = False
        CargarGridGeneral()
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim.Length > 1 Then
            Dim CL As New CL_EmployeeAmountDebt
            Dim dt = CL.GetEmployeeSuggestions(AppUser, TB_Employee.Text.Trim)

            If dt.Rows.Count > 0 Then
                LBX_Suggesting.DataSource = dt
                LBX_Suggesting.DisplayMember = "FullName"
                LBX_Suggesting.ValueMember = "EMPL_ID"
                LBX_Suggesting.Visible = True
            Else
                LBX_Suggesting.Visible = False
            End If
        Else
            LBX_Suggesting.Visible = False
        End If
    End Sub

    Private Sub LBX_Suggesting_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBX_Suggesting.SelectedIndexChanged
        If LBX_Suggesting.SelectedValue IsNot Nothing AndAlso Not TypeOf LBX_Suggesting.SelectedValue Is DataRowView Then
            Try
                SelectedEmplID = Convert.ToInt32(LBX_Suggesting.SelectedValue)
                TB_EmployeeId.Text = SelectedEmplID.ToString()

                Dim selectedText As String = ""
                If TypeOf LBX_Suggesting.SelectedItem Is DataRowView Then
                    Dim row As DataRowView = CType(LBX_Suggesting.SelectedItem, DataRowView)
                    selectedText = row("FullName").ToString()
                Else
                    selectedText = LBX_Suggesting.Text
                End If

                Dim values As String() = selectedText.Split("-")
                If values.Length > 1 Then
                    TB_EmployeeName.Text = values(1).Trim()
                Else
                    TB_EmployeeName.Text = selectedText.Trim()
                End If

                LBX_Suggesting.Visible = False

                TB_AuthorizeBy.Focus()

            Catch ex As Exception
                Console.WriteLine("Error temporal de casteo: " & ex.Message)
            End Try
        End If
    End Sub


    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
            If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
                MsgBox("Por favor, seleccione un empleado válido usando el buscador.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_AuthorizeBy.Text) Then
                MsgBox("Debe ingresar quién autoriza el adeudo.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_DebtCause.Text) Then
                MsgBox("Debe capturar el motivo o causa del adeudo.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim totalAmt As Decimal = 0
            If Not Decimal.TryParse(TB_TotalAmount.Text, totalAmt) OrElse totalAmt <= 0 Then
                MsgBox("Ingrese un monto total válido mayor a $0.00.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim periodicDiscount As Decimal = 0
            If Not Decimal.TryParse(TB_PeriodicDiscount.Text, periodicDiscount) OrElse periodicDiscount <= 0 Then
                MsgBox("Ingrese un cobro periódico por nómina válido mayor a $0.00.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim CL As New CL_EmployeeAmountDebt
            CL.REMPL_ID = CInt(TB_EmployeeId.Text)
            CL.DAMT_DATE = DTP_Valid.Value.Date
            CL.DAMT_CAUSE = TB_DebtCause.Text.Trim()
            CL.DAMT_DESCR = TB_Comment.Text.Trim()
            CL.DAMT_TOTAL_AMOUNT = totalAmt
            CL.DAMT_PERIODIC_DISCOUNT = periodicDiscount
            CL.DAMT_AUTH = TB_AuthorizeBy.Text.Trim()
            CL.DAMT_CREBY = GlobalSession.GlobalUserName
            CL.DAMT_STATUS = True

            If CL.InsertEmployeeDebt() Then
                ' LOG 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"NUEVO ADEUDO: Se cargó un total de {totalAmt:C2} al empleado ID {TB_EmployeeId.Text} por motivo: {CL.DAMT_CAUSE}."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_AdeudosEmpresa", "INSERT_SUCCESS", descLog, CInt(TB_EmployeeId.Text), "INFO")
                End Using

                MsgBox("¡El adeudo a empresa ha sido registrado exitosamente!", MsgBoxStyle.Information, "Registro Completo")

                CargarGridGeneral()
                ResetFormFields()
            End If

        Catch ex As Exception
            'LOG de error
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL INSERTAR ADEUDO: {ex.Message}. Empleado ID intentado: {TB_EmployeeId.Text}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_AdeudosEmpresa", "INSERT_EXCEPTION", descError, CInt(If(String.IsNullOrEmpty(TB_EmployeeId.Text), 0, TB_EmployeeId.Text)), "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("No se pudo escribir en la bitácora de errores: " & logEx.Message)
            End Try

            MsgBox("Error crítico al intentar procesar el registro en la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
    End Sub

    Private Sub CargarGridGeneral()
        Dim CL As New CL_EmployeeAmountDebt
        DGV_Debt.DataSource = CL.GetDebtsHistory(0)

        If DGV_Debt.Columns.Count > 0 Then
            If DGV_Debt.Columns.Contains("ID") Then DGV_Debt.Columns("ID").Visible = False


            DGV_Debt.ReadOnly = True
            DGV_Debt.RowHeadersVisible = False
            DGV_Debt.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            DGV_Debt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            If DGV_Debt.Columns.Contains("Monto Total") Then DGV_Debt.Columns("Monto Total").DefaultCellStyle.Format = "C2"
            If DGV_Debt.Columns.Contains("Saldo Pendiente") Then DGV_Debt.Columns("Saldo Pendiente").DefaultCellStyle.Format = "C2"
            If DGV_Debt.Columns.Contains("Descuento Periódico") Then DGV_Debt.Columns("Descuento Periódico").DefaultCellStyle.Format = "C2"
        End If
    End Sub



    Private Sub ResetFormFields()
        TB_Employee.Clear()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_DebtCause.Clear()
        TB_Comment.Clear()
        TB_TotalAmount.Clear()
        TB_PeriodicDiscount.Clear()
        TB_AuthorizeBy.Clear()
        DTP_Valid.Value = DateTime.Now
        CargarGridGeneral()
        TB_Employee.Focus()
    End Sub

End Class