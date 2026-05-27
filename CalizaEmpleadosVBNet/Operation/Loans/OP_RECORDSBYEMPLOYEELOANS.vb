Imports Microsoft.Data.SqlClient

Public Class OP_RECORDSBYEMPLOYEELOANS
    Public GV_Balance As Decimal = 0.0

    Private Sub OP_RECORDSBYEMPLOYEELOANS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeInfo()
        BT_Register.Enabled = True
    End Sub


    Sub LoadEmployeeInfo()

        Dim obj As New CL_EmployeeLoans

        DGV_EmployeeInfo.DataSource = obj.GetEmployeesWithLoans()
        DGV_EmployeeInfo.Refresh()

        DGV_EmployeeInfo.Columns("EMPL_ID").HeaderText = "ID Empleado"
        DGV_EmployeeInfo.Columns("NombreEmpleado").HeaderText = "Nombre"

        DGV_EmployeeInfo.Columns("TotalSaldo").HeaderText = "Saldo a pagar"
        DGV_EmployeeInfo.Columns("TotalSaldo").DefaultCellStyle.Format = "C2"

        DGV_EmployeeInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub


    Sub LoadLoans()

        Dim obj As New CL_EmployeeLoans
        obj.EMPL_ID = Get_EMPL_ID()

        DGV_Loans.DataSource = obj.GetLoansByEmployee()
        DGV_Loans.Refresh()

        If DGV_Loans.Columns.Contains("LOAN_ID") Then
            DGV_Loans.Columns(0).HeaderText = "ID Préstamo"
        End If

        If DGV_Loans.Columns.Contains("Monto") Then
            DGV_Loans.Columns("Monto").HeaderText = "Monto"
            DGV_Loans.Columns("Monto").DefaultCellStyle.Format = "C2"
        End If

        If DGV_Loans.Columns.Contains("Pagado") Then
            DGV_Loans.Columns("Pagado").HeaderText = "Pagado"
            DGV_Loans.Columns("Pagado").DefaultCellStyle.Format = "C2"
        End If

        If DGV_Loans.Columns.Contains("Saldo") Then
            DGV_Loans.Columns("Saldo").HeaderText = "Saldo"
            DGV_Loans.Columns("Saldo").DefaultCellStyle.Format = "C2"
        End If

        If DGV_Loans.Columns.Contains("DREMPL_LDATE") Then
            DGV_Loans.Columns("DREMPL_LDATE").HeaderText = "Fecha"
        End If

        If DGV_Loans.Columns.Contains("DREMPL_LTYPE") Then
            DGV_Loans.Columns("DREMPL_LTYPE").HeaderText = "Tipo"
        End If

        If DGV_Loans.Columns.Contains("DREMPL_LSTAT") Then
            DGV_Loans.Columns("DREMPL_LSTAT").HeaderText = "Estado"
        End If

        If DGV_Loans.Columns.Contains("TipoCredito") Then
            DGV_Loans.Columns("TipoCredito").HeaderText = "Tipo de crédito"
        End If

        If DGV_Loans.Columns.Contains("Estado") Then
            DGV_Loans.Columns("Estado").HeaderText = "Estado"
        End If

        If DGV_Loans.Columns.Contains("RegistradoPor") Then
            DGV_Loans.Columns("RegistradoPor").HeaderText = "Registrado por"
        End If

        DGV_Loans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Sub LoadDetail()

        Dim obj As New CL_EmployeeLoans
        obj.LOAN_ID = Get_LOAN_ID()

        DGV_DetailInstalment.DataSource = obj.GetLoanDetail()
        DGV_DetailInstalment.Refresh()


        If DGV_DetailInstalment.Columns.Contains("DLREC_ID") Then
            DGV_DetailInstalment.Columns("DLREC_ID").HeaderText = "ID"
        End If

        If DGV_DetailInstalment.Columns.Contains("LOAN_ID") Then
            DGV_DetailInstalment.Columns("LOAN_ID").HeaderText = "ID Préstamo"
        End If

        If DGV_DetailInstalment.Columns.Contains("Monto") Then
            DGV_DetailInstalment.Columns("Monto").HeaderText = "Monto"
            DGV_DetailInstalment.Columns("Monto").DefaultCellStyle.Format = "C2"
        End If
        If DGV_DetailInstalment.Columns.Contains("TipoPago") Then
            DGV_DetailInstalment.Columns("TipoPago").HeaderText = "Tipo Pago"
        End If

        If DGV_DetailInstalment.Columns.Contains("RegistradoPor") Then
            DGV_DetailInstalment.Columns("RegistradoPor").HeaderText = "Registrado por"
        End If

        If DGV_DetailInstalment.Columns.Contains("Fecha") Then
            DGV_DetailInstalment.Columns("Fecha").HeaderText = "Fecha"
        End If

        DGV_DetailInstalment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Function Get_EMPL_ID() As Integer
        If DGV_EmployeeInfo.CurrentRow Is Nothing Then Return 0
        Return Convert.ToInt32(DGV_EmployeeInfo.CurrentRow.Cells("EMPL_ID").Value)
    End Function

    Function Get_LOAN_ID() As Integer
        If DGV_Loans.CurrentRow Is Nothing Then Return 0

        Return Convert.ToInt32(DGV_Loans.CurrentRow.Cells("LOAN_ID").Value)
    End Function


    Private Sub DGV_EmployeeInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_EmployeeInfo.CellClick
        LoadLoans()
        LimpiarDetalle()
    End Sub

    Private Sub DGV_Loans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Loans.CellClick
        LoadDetail()
        CalcularTotales()
    End Sub

    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click


    '    If Get_LOAN_ID() = 0 Then
    '        MessageBox.Show("Selecciona un préstamo primero")
    '        Exit Sub
    '    End If

    '    If TB_ManualInstalment.Text = "" Then
    '        MessageBox.Show("Ingresa un monto")
    '        Exit Sub
    '    End If

    '    If Not IsNumeric(TB_ManualInstalment.Text) Then
    '        MessageBox.Show("Solo números")
    '        Exit Sub
    '    End If


    '    If TB_balance.Text = "$0.00" Then
    '        MessageBox.Show("El préstamo ya está liquidado")
    '        Exit Sub
    '    End If

    '    Dim obj As New CL_EmployeeLoans

    '    obj.LOAN_ID = Get_LOAN_ID()
    '    obj.LOAN_PAYM = Convert.ToDecimal(TB_ManualInstalment.Text)
    '    obj.LOAN_PTYPE = 1
    '    obj.REMPL_CREBY = AppUser
    '    obj.REMPL_RDATE = Date.Today

    '    If CDec(TB_ManualInstalment.Text) > GV_Balance Then
    '        MessageBox.Show("El monto ingresado es mayor al saldo a pagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        TB_ManualInstalment.SelectAll()
    '        TB_ManualInstalment.Focus()
    '    Else
    '        obj.InsertPayment()
    '        MessageBox.Show("Pago registrado", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        TB_ManualInstalment.Text = ""

    '        LoadEmployeeInfo()
    '        LoadLoans()
    '        LoadDetail()
    '        CalcularTotales()
    '    End If

    'End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If Get_LOAN_ID() = 0 Then
            MessageBox.Show("Por favor, seleccione el préstamo al cual desea aplicar el abono.", "Aviso de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TB_ManualInstalment.Text) Then
            MessageBox.Show("Debe ingresar un monto para realizar el abono.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(TB_ManualInstalment.Text) Then
            MessageBox.Show("El abono debe ser exclusivamente un valor numérico.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TB_balance.Text = "$0.00" Then
            MessageBox.Show("Este préstamo ya se encuentra completamente liquidado.", "Cuenta Saldada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim loanId As Integer = Get_LOAN_ID()
        Dim montoAbono As Decimal = Convert.ToDecimal(TB_ManualInstalment.Text)

        If montoAbono > GV_Balance Then
            MessageBox.Show($"El monto ingresado (${montoAbono}) supera el saldo pendiente de la deuda (${GV_Balance}).", "Error de Monto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TB_ManualInstalment.SelectAll()
            TB_ManualInstalment.Focus()
            Exit Sub
        End If

        Try
            Dim obj As New CL_EmployeeLoans
            obj.LOAN_ID = loanId
            obj.LOAN_PAYM = montoAbono
            obj.LOAN_PTYPE = 1
            obj.REMPL_CREBY = GlobalSession.GlobalUserName
            obj.REMPL_RDATE = Date.Today

            obj.InsertPayment()

            'LOG
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim desc As String = $"ABONO A CRÉDITO: Se registró un pago exitoso al Préstamo ID: {loanId}. Importe Abonado: ${montoAbono} | Saldo Anterior: ${GV_Balance} | Nuevo Saldo Estimado: ${GV_Balance - montoAbono}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Abonos", "INSERT_PAYMENT_SUCCESS", desc, 0, "INFO")
            End Using

            MessageBox.Show($"¡El pago por ${montoAbono} ha sido aplicado correctamente al préstamo!", "Confirmación de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TB_ManualInstalment.Text = ""

            LoadEmployeeInfo()
            LoadLoans()
            LoadDetail()
            CalcularTotales()

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló el registro del abono para el Préstamo ID: {loanId} por cantidad de ${montoAbono}. Motivo: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Abonos", "ERROR_INSERT_PAYMENT", descError, 0, "ERROR", ex.StackTrace)
            End Using
            MessageBox.Show("Ocurrió un error inesperado al intentar aplicar el pago en el servidor: " & ex.Message, "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SumarColumna(dgv As DataGridView, nombreColumna As String) As Decimal

        Dim total As Decimal = 0



        For Each row As DataGridViewRow In dgv.Rows

            If Not row.IsNewRow Then

                Dim valor = row.Cells(nombreColumna).Value

                If valor IsNot Nothing AndAlso Not IsDBNull(valor) Then

                    Dim numero As Decimal

                    If Decimal.TryParse(valor.ToString().Replace("$", "").Replace(",", ""), numero) Then
                        total += numero
                    End If

                End If

            End If

        Next

        Return total

    End Function

    Sub CalcularTotales()

        Dim totalPagado As Decimal = SumarColumna(DGV_DetailInstalment, "Monto")

        Dim totalLoan As Decimal = 0


        If DGV_Loans.CurrentRow IsNot Nothing AndAlso
       DGV_Loans.Columns.Contains("Monto") AndAlso
       DGV_Loans.CurrentRow.Cells("Monto").Value IsNot DBNull.Value Then

            totalLoan = Convert.ToDecimal(DGV_Loans.CurrentRow.Cells("Monto").Value)

        End If

        Dim saldo As Decimal = totalLoan - totalPagado

        TB_TotalLoans.Text = totalLoan.ToString("C2")
        TB_balance.Text = saldo.ToString("C2")

        If saldo = 0 Then
            BT_Register.Enabled = False
        Else
            BT_Register.Enabled = True
        End If


    End Sub

    Sub LimpiarDetalle()

        DGV_DetailInstalment.DataSource = Nothing
        TB_TotalLoans.Text = ""
        TB_balance.Text = ""
        BT_Register.Enabled = False

    End Sub

    Private Sub DGV_EmployeeInfo_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_EmployeeInfo.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_EmployeeInfo.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_EmployeeInfo.Rows(hit.RowIndex)

            GV_Balance = CInt(row.Cells(3).Value) ' Balance
        End If
    End Sub
End Class