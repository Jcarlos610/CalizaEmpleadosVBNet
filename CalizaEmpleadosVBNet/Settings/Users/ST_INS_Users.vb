Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.Mail

Public Class ST_INS_Users

    Public Function HashPassword(password As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(password)
            Dim hash = sha.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Public Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False

        Try
            Dim addr As New MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    Private Sub ST_Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub BT_RegisterUser_Click(sender As Object, e As EventArgs) Handles BT_RegisterUser.Click

        If TB_FirstName.Text = "" Then
            MessageBox.Show("Favor de ingresar el nombre completo del usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_LastName.Text = "" Then
            MessageBox.Show("Favor de ingresar el/los apellido(s).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Email.Text = "" Then
            MessageBox.Show("Favor de ingresar un email.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf tb_UserName.Text = "" Then
            MessageBox.Show("Favor de ingresar el nombre de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Password.Text = "" Then
            MessageBox.Show("Favor de ingresar un password.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'All fields were completed
            If Not IsValidEmail(TB_Email.Text) Then
                MessageBox.Show("Ingrese una dirección de correo válida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TB_Email.Focus()
            Else
                Dim User = New CL_Users(TB_FirstName.Text, TB_LastName.Text, TB_Email.Text, tb_UserName.Text, HashPassword(TB_Password.Text))

                If User.InsertSystemUser() Then
                    MessageBox.Show("El usuario " & tb_UserName.Text & "se creo correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If



    End Sub

End Class