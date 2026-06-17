Imports Microsoft.Data.SqlClient

Public Class OP_RecordsByEmployeeMoneySaved

    Private Sub OP_RecordByEmployeeMoneySaved_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadEmployeeInfo()

    End Sub

    Sub LoadEmployeeInfo()

        Dim obj As New CL_RecordsByEmployeeMoneySaved

        DGV_EmployeeInfo.DataSource = obj.GetEmployeeRecords()

        DGV_EmployeeInfo.Columns("EMPL_ID").HeaderText = "ID Empleado"
        DGV_EmployeeInfo.Columns("NombreEmpleado").HeaderText = "Nombre de empleado "
        DGV_EmployeeInfo.Columns("TotalAhorro").HeaderText = "Total Ahorro"


        DGV_EmployeeInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_EmployeeInfo.AutoResizeColumns()
        DGV_EmployeeInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_EmployeeInfo.Columns("TotalAhorro").DefaultCellStyle.Format = "C2"

    End Sub



    Sub LoadSavings()

        Dim obj As New CL_RecordsByEmployeeMoneySaved
        obj.EMPL_ID = Get_EMPL_ID()

        DGV_DetailSaving.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DetailSaving.AutoResizeColumns()
        DGV_DetailSaving.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_DetailSaving.DataSource = obj.GetSavings()

    End Sub

    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

    '    If TB_ManualSaving.Text = "" Then
    '        MessageBox.Show("Ingresa un monto", "Aviso",
    '                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    If Not IsNumeric(TB_ManualSaving.Text) Then
    '        MessageBox.Show("Solo números", "Aviso",
    '                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    Dim obj As New CL_RecordsByEmployeeMoneySaved

    '    obj.EMPL_ID = Get_EMPL_ID()
    '    obj.DREMPL_AMM = Convert.ToDecimal(TB_ManualSaving.Text)
    '    obj.DREMPL_TYPE = 1
    '    obj.REMPL_CREBY = AppUser
    '    obj.REMPL_RDATE = Date.Today

    '    obj.InsertSaving()

    '    MessageBox.Show("Ahorro registrado", "Confirmación",
    '                            MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    TB_ManualSaving.Text = ""

    '    LoadSavings()
    '    LoadEmployeeInfo()

    'End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        If TB_ManualSaving.Text = "" Then
            MessageBox.Show("Por favor, ingrese el monto que el empleado desea ahorrar.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(TB_ManualSaving.Text) Then
            MessageBox.Show("El monto de ahorro debe contener únicamente caracteres numéricos.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim empId As Integer = Get_EMPL_ID()
        Dim montoAhorro As Decimal = Convert.ToDecimal(TB_ManualSaving.Text)

        Try
            Dim obj As New CL_RecordsByEmployeeMoneySaved
            obj.EMPL_ID = Get_EMPL_ID()
            obj.DREMPL_AMM = Convert.ToDecimal(TB_ManualSaving.Text)
            obj.DREMPL_TYPE = 1
            obj.REMPL_CREBY = GlobalSession.GlobalUserName
            obj.REMPL_RDATE = Date.Today

            obj.InsertSaving()
            'LOG
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim desc As String = $"DEPÓSITO DE AHORRO: Registro exitoso de aportación para el Empleado ID: {empId}. Cantidad Ingresada: ${montoAhorro}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Ahorros", "INSERT_SAVING_SUCCESS", desc, empId, "INFO")
            End Using

            MessageBox.Show($"¡Ahorro de ${montoAhorro} registrado de manera correcta!", "Confirmación de Depósito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            TB_ManualSaving.Text = ""

            LoadSavings()
            LoadEmployeeInfo()

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la inserción de depósito de ahorro para el Empleado ID: {empId}. Motivo: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Ahorros", "ERROR_INSERT_SAVING", descError, empId, "ERROR", ex.StackTrace)
            End Using
            MessageBox.Show("Ocurrió un error inesperado al depositar en la cuenta de ahorros: " & ex.Message, "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub TB_ManualSaving_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_ManualSaving.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And e.KeyChar <> "." Then
            e.Handled = True
        End If

    End Sub

    Function Get_EMPL_ID() As Integer

        If DGV_EmployeeInfo.CurrentRow Is Nothing Then
            Return 0
        End If

        Return Convert.ToInt32(DGV_EmployeeInfo.CurrentRow.Cells("EMPL_ID").Value)

    End Function

    'Private Sub DGV_EmployeeInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_EmployeeInfo.CellClick

    '    LoadSavings()
    '    LoadWithdrawals()
    '    CalcularTotales()
    'End Sub

    Private Sub DGV_EmployeeInfo_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_EmployeeInfo.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_EmployeeInfo.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                LoadSavings()
                LoadWithdrawals()
                CalcularTotales()

            Catch ex As Exception
                MsgBox("Error al cargar la información financiera del empleado: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Sub LoadWithdrawals()

        Dim obj As New CL_RecordsByEmployeeMoneySaved
        obj.EMPL_ID = Get_EMPL_ID()

        DGV_Withdrawals.DataSource = obj.GetWithdrawals()

        DGV_Withdrawals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Withdrawals.AutoResizeColumns()

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


        Dim totalAhorro As Decimal = SumarColumna(DGV_DetailSaving, "Monto")


        Dim totalRetiro As Decimal = SumarColumna(DGV_Withdrawals, "Monto")


        Dim disponible As Decimal = totalAhorro - totalRetiro


        TB_TotalSaved.Text = totalAhorro.ToString("C2")
        TB_TotalWithdrawn.Text = totalRetiro.ToString("C2")
        TB_TotalAvailable.Text = disponible.ToString("C2")

    End Sub

    'Private Sub BT_Withdraw_Click(sender As Object, e As EventArgs) Handles BT_Withdraw.Click
    '    If TB_Withdrawal.Text = "" Then
    '        MessageBox.Show("Ingresa un monto", "Aviso",
    '                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    If Not IsNumeric(TB_Withdrawal.Text) Then
    '        MessageBox.Show("Solo números", "Aviso",
    '                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    Dim total As Decimal = Convert.ToDecimal(DGV_EmployeeInfo.CurrentRow.Cells("TotalAhorro").Value)

    '    If Convert.ToDecimal(TB_Withdrawal.Text) > total Then
    '        MessageBox.Show("No puedes retirar más de lo disponible", "Error",
    '                MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End If

    '    Dim obj As New CL_RecordsByEmployeeMoneySaved

    '    obj.EMPL_ID = Get_EMPL_ID()
    '    obj.DREMPL_AMM = Convert.ToDecimal(TB_Withdrawal.Text)
    '    obj.REMPL_CREBY = AppUser
    '    obj.REMPL_RDATE = Date.Today

    '    obj.InsertWithdrawal()

    '    MessageBox.Show("Retiro registrado", "Confirmación",
    '                    MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    TB_Withdrawal.Text = ""

    '    LoadSavings()
    '    LoadEmployeeInfo()
    'End Sub

    Private Sub BT_Withdraw_Click(sender As Object, e As EventArgs) Handles BT_Withdraw.Click
        If TB_Withdrawal.Text = "" Then
            MessageBox.Show("Por favor, introduzca el monto que desea retirar de la cuenta.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(TB_Withdrawal.Text) Then
            MessageBox.Show("El valor del retiro debe ser un número válido.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If DGV_EmployeeInfo.CurrentRow Is Nothing Then
            MessageBox.Show("No hay un empleado seleccionado válidamente para verificar el fondo disponible.", "Error de Contexto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim total As Decimal = Convert.ToDecimal(DGV_EmployeeInfo.CurrentRow.Cells("TotalAhorro").Value)
        Dim montoRetiro As Decimal = Convert.ToDecimal(TB_Withdrawal.Text)
        Dim empId As Integer = Get_EMPL_ID()

        If Convert.ToDecimal(TB_Withdrawal.Text) > total Then
            MessageBox.Show($"Operación denegada: El monto a retirar (${montoRetiro}) supera los fondos totales disponibles en la cuenta (${total}).", "Fondos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim obj As New CL_RecordsByEmployeeMoneySaved
            obj.EMPL_ID = Get_EMPL_ID()
            obj.DREMPL_AMM = Convert.ToDecimal(TB_Withdrawal.Text)
            obj.REMPL_CREBY = GlobalSession.GlobalUserName
            obj.REMPL_RDATE = Date.Today

            obj.InsertWithdrawal()
            'LOG
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim desc As String = $"RETIRO DE AHORRO: Extracción de fondos exitosa para el Empleado ID: {empId}. Cantidad Retirada: ${montoRetiro} | Fondos Restantes: ${total - montoRetiro}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Ahorros", "WITHDRAWAL_SAVING_SUCCESS", desc, empId, "INFO")
            End Using

            MessageBox.Show($"¡Retiro por ${montoRetiro} procesado y entregado con éxito!", "Confirmación de Retiro", MessageBoxButtons.OK, MessageBoxIcon.Information)

            TB_Withdrawal.Text = ""

            LoadSavings()
            LoadEmployeeInfo()

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la operación de retiro de ahorros para el Empleado ID: {empId} por la suma de ${montoRetiro}. Motivo: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Ahorros", "ERROR_WITHDRAWAL_SAVING", descError, empId, "ERROR", ex.StackTrace)
            End Using
            MessageBox.Show("Ocurrió un error inesperado al efectuar el retiro en el servidor: " & ex.Message, "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class