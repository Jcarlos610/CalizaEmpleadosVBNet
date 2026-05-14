Public Class OP_INS_TEMPORALLUNCH

    Dim SelectedEmplID As Integer = 0
    Private Sub OP_INS_TEMPORALLUNCH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBX_Suggesting.Visible = False
        Historial(0)
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim.Length > 1 Then
            Dim CL As New CL_TemporalLunchTime

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
            TB_EmployeeName.Text = values(1).Trim()

            LBX_Suggesting.Visible = False

            Historial(CInt(LBX_Suggesting.SelectedValue))
            TB_Lunch.Focus()
        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
            MsgBox("Debe seleccionar un empleado de la lista.", MsgBoxStyle.Exclamation, "Atención")
            Return
        End If

        Dim horas As Decimal
        If Not Decimal.TryParse(TB_Lunch.Text, horas) OrElse horas < 0 OrElse horas > 5 Then
            MsgBox("Las horas permitidas son de 0 a 5.", MsgBoxStyle.Critical, "Rango no válido")
            TB_Lunch.Focus()
            Return
        End If

        Dim CL As New CL_TemporalLunchTime
        CL.EMPL_ID = CInt(TB_EmployeeId.Text)
        CL.LUNCH_DATE = DTP_Valid.Value
        CL.LUNCH_HOURS = horas
        CL.LUNCH_CREBY = AppUser
        CL.LUNCH_DATEC = Now
        CL.LUNCH_STAT = True

        If CL.InsertTemporalLunch() Then
            MsgBox("El registro se guardó correctamente.", MsgBoxStyle.Information, "Éxito")
            Historial(0)
            ResetFormFields()
        End If
    End Sub

    Private Sub Historial(ByVal idEmp As Integer)
        Dim CL As New CL_TemporalLunchTime
        DGV_Lunch.DataSource = CL.GetTemporalLunchHistory(AppUser)

        If DGV_Lunch.Columns.Count > 0 Then

            DGV_Lunch.Columns("ID").Visible = False

            DGV_Lunch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGV_Lunch.ReadOnly = True
            DGV_Lunch.RowHeadersVisible = False

        End If
    End Sub

    Private Sub ResetFormFields()
        TB_Employee.Clear()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_Lunch.Clear()
        SelectedEmplID = 0
        TB_Employee.Focus()
    End Sub

End Class