Public Class FRM_ResetPassword
    Private Sub BT_Save_Click(sender As Object, e As EventArgs) Handles BT_Save.Click
        If TB_UserName.Text = "" Then
            MessageBox.Show("Ingresa usuario", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TB_NewPassword.Text = "" Then
            MessageBox.Show("Ingresa nueva contraseña", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TB_NewPassword.Text <> TB_ConfirmPassword.Text Then
            MessageBox.Show("Las contraseñas no coinciden", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim user As New CL_Users()

        If user.ResetPassword(TB_UserName.Text, TB_NewPassword.Text) Then
            MessageBox.Show("Contraseña actualizada correctamente", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Error al actualizar contraseña", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class