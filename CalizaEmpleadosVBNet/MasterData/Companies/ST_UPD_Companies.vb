Public Class ST_UPD_Companies
    Private Sub ST_UPD_Companies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Company = New CL_Companies()

        'Load companies information
        CB_Companies.DataSource = Company.GetCompanies()
        CB_Companies.DisplayMember = "COMP_NAME"
        CB_Companies.ValueMember = "COMP_ID"
        CB_Companies.SelectedIndex = 0

        'Disable fields
        TB_CompanyName.Enabled = False
        TB_OfficialName.Enabled = False
        TB_TaxCode.Enabled = False
    End Sub

    Private Sub CB_Companies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Companies.SelectedIndexChanged
        Dim Company = New CL_Companies()

        If CB_Companies.SelectedIndex <> 0 Then
            TB_CompanyName.Enabled = True
            TB_OfficialName.Enabled = True
            TB_TaxCode.Enabled = True
            Company.COMP_ID = CB_Companies.SelectedValue
            Dim LT_Companies As DataTable = Company.GetCompanyData()

            For Each item As DataRow In LT_Companies.Rows
                TB_CompanyName.Text = item("COMP_NAME").ToString
                TB_OfficialName.Text = item("COMP_ONAME").ToString
                TB_TaxCode.Text = item("COMP_TCODE").ToString
            Next

        End If
    End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

        'Validation of fields
        If TB_CompanyName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If TB_OfficialName.Text = "" Then
                MessageBox.Show("Favor de ingresar un nombre oficial de la empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If TB_TaxCode.Text = "" Then
                    MessageBox.Show("Favor de ingresar un número de RFC", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim Company = New CL_Companies(CB_Companies.SelectedValue, TB_CompanyName.Text, TB_OfficialName.Text, TB_TaxCode.Text)

                    If Company.UpdateCompany() Then
                        MessageBox.Show("la empresa: " & TB_CompanyName.Text & " se actualizó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'Reload Data
                        CB_Companies.DataSource = Company.GetCompanies()
                        CB_Companies.DisplayMember = "COMP_NAME"
                        CB_Companies.ValueMember = "COMP_ID"
                        CB_Companies.SelectedIndex = 0

                        'Clean Textbox
                        TB_CompanyName.Text = ""
                        TB_OfficialName.Text = ""
                        TB_TaxCode.Text = ""

                        'Enable fields
                        TB_CompanyName.Enabled = False
                        TB_OfficialName.Enabled = False
                        TB_TaxCode.Enabled = False
                    End If
                End If
            End If
        End If
    End Sub
End Class