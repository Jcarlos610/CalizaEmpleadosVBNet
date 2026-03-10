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
                    End If
                End If
            End If
        End If
    End Sub
End Class