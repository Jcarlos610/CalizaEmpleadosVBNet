Imports System.Security.Cryptography
Imports System.Text

Public Class LoginScreen

    Public Function HashPassword(password As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(password)
            Dim hash = sha.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Private Sub BT_Access_Click(sender As Object, e As EventArgs) Handles BT_Access.Click

        Dim User As New CL_Users()

        If User.ValidationUser(TB_UserName.Text, TB_Password.Text) Then


            Dim dt As DataTable = User.GetUserDataByUsername(TB_UserName.Text)



            If dt.Rows.Count > 0 Then
                GlobalUserID = CInt(dt.Rows(0)("USER_ID"))

                GlobalUserName = dt.Rows(0)("USER_NAME").ToString()

            End If

            DeterminarEntorno()
            AppUser = TB_UserName.Text

            Dim main As MainScreen = CType(Me.MdiParent, MainScreen)
            Dim Obj_UserData As New CL_Users

            Obj_UserData.USER_ID = GlobalUserID
            Dim UserData As DataTable = Obj_UserData.GetUserData()

            For Each Obj_Line As DataRow In UserData.Rows
                FirstName = Obj_Line(2)
            Next

            main.aplicarpermisos()

            main.Text = main.Text & " - " & FirstName & " - [" & Envirotment & "]"

            Me.Close()

        Else



            MessageBox.Show("Usuario o contraseña incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub



    Private Sub DeterminarEntorno()
        Dim cadenaConexion As String = My.Settings.ConnectionString

        If cadenaConexion.Contains(".net") Then
            Envirotment = "PRODUCCIÓN"
        ElseIf cadenaConexion.Contains("SQLEXPRESS") Then
            Envirotment = "DESARROLLO"
        Else
            Envirotment = "DESCONOCIDO"
        End If
    End Sub

    Private Sub TB_Password_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Password.KeyDown
        If e.KeyCode = Keys.Enter Then
            BT_Access.PerformClick()
        End If
    End Sub

    Private Sub LBL_ResetPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LBL_ResetPassword.LinkClicked
        Dim frm As New FRM_ResetPassword()
        frm.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class