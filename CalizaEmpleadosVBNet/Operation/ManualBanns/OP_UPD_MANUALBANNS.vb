Public Class OP_UPD_MANUALBANNS
    Dim SelectedEBannID As Integer = 0
    Private Sub OP_UPD_MANUALBANNS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CL As New CL_EmployeeBanns
        Dim dtBanns As DataTable = CL.GetBannTypes()

        If dtBanns.Rows.Count > 0 Then
            CB_Banns.DataSource = dtBanns
            CB_Banns.DisplayMember = "BANN_NAME"
            CB_Banns.ValueMember = "BANN_ID"
        End If
        Historial()
    End Sub

    Private Sub DGV_Banns_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Banns.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_Banns.Rows(e.RowIndex)

            SelectedEBannID = CInt(row.Cells("ID").Value)

            TB_EmployeeId.Text = row.Cells("ID Empleado").Value.ToString()
            TB_EmployeeName.Text = row.Cells("Empleado").Value.ToString()
            CB_Banns.Text = row.Cells("Amonestación").Value.ToString()
            DTP_Valid.Value = CDate(row.Cells("Fecha").Value)

            TB_EmployeeId.ReadOnly = True
            TB_EmployeeName.ReadOnly = True
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        If SelectedEBannID = 0 Then
            MsgBox("Por favor, seleccione una amonestación de la tabla.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        Dim CL As New CL_EmployeeBanns
        CL.BANN_ID = CB_Banns.SelectedValue
        CL.EBANN_DATE = DTP_Valid.Value
        CL.EBANN_CREBY = AppUser
        CL.EBANN_DATEC = Now

        If CL.UpdateEmployeeBanns(SelectedEBannID) Then
            MsgBox("¡Amonestación actualizada con éxito!", MsgBoxStyle.Information, "Éxito")

            Historial()
            ResetFormFields()
        End If
    End Sub

    Private Sub Historial()
        Dim CL As New CL_EmployeeBanns
        DGV_Banns.DataSource = CL.GetAllBannsHistory(AppUser)

        If DGV_Banns.Columns.Count > 0 Then
            DGV_Banns.Columns("ID").Visible = False
            DGV_Banns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGV_Banns.ReadOnly = True
            DGV_Banns.RowHeadersVisible = False

            DGV_Banns.Columns("Empleado").FillWeight = 130
            DGV_Banns.Columns("Amonestación").FillWeight = 110
        End If
    End Sub

    Private Sub ResetFormFields()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        SelectedEBannID = 0
        CB_Banns.SelectedIndex = 0
        DTP_Valid.Value = Now
    End Sub

End Class