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

        InitializationOfFields()

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
                    InitializationOfFields()
                End If
            End If
        End If



    End Sub

    Private Sub InitializationOfFields()

        TB_FirstName.Text = ""
        TB_LastName.Text = ""
        TB_Email.Text = ""
        tb_UserName.Text = ""
        TB_Password.Text = ""

        Display_Record()

    End Sub

    Private Sub Display_Record()

        Dim user As New CL_Users()

        DGV_UsersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_UsersList.AutoResizeColumns()
        DGV_UsersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_UsersList.DataSource = user.GetUsersList()

        'Cambiar nombres de columnas
        DGV_UsersList.Columns("USER_ID").HeaderText = "ID"
        DGV_UsersList.Columns("COMPLETE_NAME").HeaderText = "Nombre Completo"
        DGV_UsersList.Columns("USER_FNAME").HeaderText = "Nombre"
        DGV_UsersList.Columns("USER_LNAME").HeaderText = "Apellido"
        DGV_UsersList.Columns("USER_EMAIL").HeaderText = "Correo"
        DGV_UsersList.Columns("USER_NAME").HeaderText = "Usuario"
        DGV_UsersList.Columns("USER_PASSW").HeaderText = "Contraseña"
        DGV_UsersList.Columns("USER_LACCESS").HeaderText = "Último acceso"
        DGV_UsersList.Columns("USER_DATREG").HeaderText = "Fecha de registro"

        'Ocultar contraseña
        'DGV_UsersList.Columns("USER_PASSW").Visible = False

    End Sub



End Class