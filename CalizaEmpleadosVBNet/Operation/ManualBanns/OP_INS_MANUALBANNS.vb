Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class OP_INS_MANUALBANNS
    Dim SelectedEmplID As Integer = 0

    Private Sub OP_INS_MANUALBANNS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBX_Suggesting.Visible = False
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim.Length > 1 Then
            Dim CL As New CL_EmployeeBanns
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

    Private Sub LBX_Suggesting_Click(sender As Object, e As EventArgs) Handles LBX_Suggesting.Click
        If LBX_Suggesting.SelectedValue IsNot Nothing Then
            SelectedEmplID = Convert.ToInt32(LBX_Suggesting.SelectedValue)
            TB_EmployeeId.Text = SelectedEmplID.ToString()

            Dim values As String() = LBX_Suggesting.Text.Split("-")
            TB_EmployeeName.Text = values(1).Trim()

            LBX_Suggesting.Visible = False

            Historial(SelectedEmplID)

            Dim CL As New CL_EmployeeBanns
            Dim saldoActual As Decimal = CL.GetEmployeeBannsBalance(SelectedEmplID)
            LB_BannsBalance.Text = $"Saldo de amonestaciones por descontar: {saldoActual.ToString("N2")} días"
        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
            If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
                MsgBox("Por favor, seleccione un empleado primero.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_BannName.Text) Then
                MsgBox("Por favor, ingrese el concepto o título de la amonestación.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim dias As Decimal = 0
            If Not Decimal.TryParse(TB_BannDays.Text, dias) OrElse dias <= 0 Then
                MsgBox("Por favor, introduzca una cantidad de días válida mayor a cero.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim targetEmpID As Integer = CInt(TB_EmployeeId.Text)
            Dim concepto As String = TB_BannName.Text.Trim()

            Dim CL As New CL_EmployeeBanns
            CL.REMPL_ID = targetEmpID
            CL.REMPL_ID = CInt(TB_EmployeeId.Text)
            CL.DREMPL_DATE = DTP_Valid.Value.Date
            CL.DREMPL_DQUANTITY = dias
            CL.DREMPL_BNAME = TB_BannName.Text.Trim()
            CL.DREMPL_DESCR = TB_Description.Text.Trim()
            CL.DREMPL_CREBY = GlobalSession.GlobalUserName
            CL.DREMPL_STATUS = True

            If CL.InsertEmployeeBann() Then
                'LOG
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"NUEVA AMONESTACIÓN: Se registró sanción de {dias} días al EMPL_ID: {targetEmpID}. Concepto: '{concepto}'."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Amonestaciones", "INSERT_BANN_SUCCESS", descLog, targetEmpID, "INFO")
                End Using

                MsgBox("¡Amonestación registrada con éxito con un saldo de " & dias & " días!", MsgBoxStyle.Information, "Éxito")
                Historial(CInt(TB_EmployeeId.Text))
                ResetFormFields()
            End If
        Catch ex As Exception
            'LOG DE ERROR 
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló el registro de amonestación para EMPL_ID: {TB_EmployeeId.Text}. Motivo: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Amonestaciones", "ERROR_INSERT_BANN", descError, 0, "ERROR", ex.StackTrace)
            End Using
            MsgBox("Ocurrió un error inesperado al registrar la amonestación: " & ex.Message, MsgBoxStyle.Critical, "Error Crítico")
        End Try
    End Sub

    Private Sub Historial(ByVal idEmp As Integer)
        Dim CL As New CL_EmployeeBanns
        DGV_Banns.DataSource = CL.GetBannsHistory(idEmp)

        If DGV_Banns.Columns.Count > 0 Then
            DGV_Banns.Columns("ID").Visible = False

            DGV_Banns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_Banns.ReadOnly = True
            DGV_Banns.RowHeadersVisible = False

            DGV_Banns.Columns("Empleado").FillWeight = 130
            DGV_Banns.Columns("Departamento").FillWeight = 100
            DGV_Banns.Columns("Amonestación").FillWeight = 110
        End If
    End Sub

    Private Sub ResetFormFields()
        TB_Employee.Clear()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_BannName.Clear()
        TB_Description.Clear()
        TB_BannDays.Clear()
        LB_BannsBalance.Text = "Saldo de amonestaciones por descontar: 0.00 días"
        SelectedEmplID = 0
        TB_Employee.Focus()
    End Sub
End Class