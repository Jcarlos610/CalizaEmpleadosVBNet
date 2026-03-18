Public Class ST_INS_Companies
    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Dim Company = New CL_Companies(TB_CompanyName.Text, TB_OfficialName.Text, TB_TaxCode.Text)

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
                    If Company.InsertCompany() Then
                        MessageBox.Show("la empresa: " & TB_CompanyName.Text & " se creó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        InitializationOfFields()

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Display_Record()

        Dim company As New CL_Companies()

        DGV_CompaniesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_CompaniesList.AutoResizeColumns()
        DGV_CompaniesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_CompaniesList.DataSource = company.GetCompaniesList()

        'Cambiar nombres de columnas
        DGV_CompaniesList.Columns("COMP_ID").HeaderText = "ID"
        DGV_CompaniesList.Columns("COMP_NAME").HeaderText = "Empresa"
        DGV_CompaniesList.Columns("COMP_ONAME").HeaderText = "Razón Social"
        DGV_CompaniesList.Columns("COMP_TCODE").HeaderText = "RFC"

    End Sub

    Private Sub InitializationOfFields()

        TB_CompanyName.Text = ""
        TB_OfficialName.Text = ""
        TB_TaxCode.Text = ""

        Display_Record()

    End Sub

    Private Sub ST_INS_Companies_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializationOfFields()

    End Sub
End Class