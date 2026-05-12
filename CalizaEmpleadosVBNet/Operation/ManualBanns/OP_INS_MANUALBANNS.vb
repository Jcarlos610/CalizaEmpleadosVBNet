Imports System.Linq.Expressions

Public Class OP_INS_MANUALBANNS
    Dim SelectedEmplID As Integer = 0

    'Private Sub OP_INS_MANUALBANNS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    '    Dim CL As New CL_EmployeeBanns
    '    Dim dtBanns As DataTable = CL.GetBannTypes()

    '    If dtBanns.Rows.Count > 0 Then
    '        CB_Banns.DataSource = dtBanns
    '        CB_Banns.DisplayMember = "BANN_NAME"
    '        CB_Banns.ValueMember = "BANN_ID"
    '    End If
    'End Sub

    Private Sub OP_INS_MANUALBANNS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBX_Suggesting.Visible = False

        Dim CL As New CL_EmployeeBanns
        Dim dtBanns As DataTable = CL.GetBannTypes()
        Dim dr As DataRow = dtBanns.NewRow()
        dr("BANN_ID") = 0
        dr("BANN_NAME") = "-- Selecciona una amonestación --"
        dtBanns.Rows.InsertAt(dr, 0)

        If dtBanns.Rows.Count > 0 Then
            CB_Banns.DataSource = dtBanns
            CB_Banns.DisplayMember = "BANN_NAME"
            CB_Banns.ValueMember = "BANN_ID"


            CB_Banns.SelectedIndex = 0
        End If
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim.Length > 1 Then
            Dim CL As New CL_EmployeeBanns
            Dim dt As DataTable = CL.GetEmployeeSuggestions(AppUser, TB_Employee.Text.Trim())

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

            SelectedEmplID = LBX_Suggesting.SelectedValue
            TB_EmployeeId.Text = SelectedEmplID.ToString()
            Dim values As String() = LBX_Suggesting.Text.Split("-")
            TB_EmployeeName.Text = values(1)

            LBX_Suggesting.Visible = False

            Historial(CInt(LBX_Suggesting.SelectedValue))

        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
            MsgBox("Por favor, seleccione un empleado primero.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        If CB_Banns.SelectedValue = 0 Then
            MsgBox("Por favor, seleccione el tipo de amonestación.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        Dim CL As New CL_EmployeeBanns
        CL.EMPL_ID = CInt(TB_EmployeeId.Text)
        CL.BANN_ID = CB_Banns.SelectedValue
        CL.EBANN_DATE = DTP_Valid.Value
        CL.EBANN_CREBY = AppUser
        CL.EBANN_DATEC = Now
        CL.EBANN_STAT = True

        If CL.InsertEmployeeBann() Then
            MsgBox("¡Amonestación registrada con éxito!", MsgBoxStyle.Information, "Éxito")

            Historial(CInt(TB_EmployeeId.Text))
            ResetFormFields()
        End If
    End Sub

    Private Sub Historial(ByVal idEmp As Integer)
        Dim CL As New CL_EmployeeBanns
        DGV_Banns.DataSource = CL.GetBannsHistory(idEmp)

        If DGV_Banns.Columns.Count > 0 Then

            DGV_Banns.Columns("ID").Visible = False

            DGV_Banns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGV_Banns.ReadOnly = True
            DGV_Banns.RowHeadersVisible = False

            DGV_Banns.Columns("Empleado").FillWeight = 150
            DGV_Banns.Columns("Amonestación").FillWeight = 120
        End If
    End Sub

    Private Sub ResetFormFields()
        TB_Employee.Clear()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()

        SelectedEmplID = 0

        If CB_Banns.Items.Count > 0 Then
            CB_Banns.SelectedIndex = 0
        End If

        TB_Employee.Focus()
    End Sub

    Private Sub TB_EmployeeName_TextChanged(sender As Object, e As EventArgs) Handles TB_EmployeeName.TextChanged

    End Sub
End Class