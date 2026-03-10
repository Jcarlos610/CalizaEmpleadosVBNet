Public Class MD_INS_Banns
    Private Sub MD_INS_Banns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()
        Dim report As New CL_Banns()

        TB_BannName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        TB_Ammount.Text = ""

        DT_ValidFrom.Value = Date.Today
        DT_ValidTo.Value = Date.Today.AddYears(1)

        Display_Record()
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Banns()
        DGV_BannsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_BannsList.AutoResizeColumns()
        DGV_BannsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_BannsList.DataSource = report.Get_AllBanns
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If TB_BannName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de la amonestación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Favor de indicar quién autoriza la amonestación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Ammount.Text = "" Then
            MessageBox.Show("Favor de indicar el monto asignado para este beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim Bann = New CL_Banns(TB_BannName.Text, TB_Description.Text, Date.Now, TB_Ammount.Text, AppUser, TB_AuthorizeBy.Text, DT_ValidFrom.Value, DT_ValidTo.Value, 1)

            If Bann.InsertBann() Then
                MessageBox.Show("La amonestación " + TB_BannName.Text + " fue ingresada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
            End If

        End If
    End Sub
End Class