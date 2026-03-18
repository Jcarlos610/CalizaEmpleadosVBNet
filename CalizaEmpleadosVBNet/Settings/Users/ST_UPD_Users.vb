Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.Mail
Imports Microsoft.VisualBasic.ApplicationServices

Public Class ST_UPD_Users

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

    Private Sub ST_UPD_Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users = New CL_Users

        'Load companies information
        CB_Users.DataSource = users.GetUsers()
        CB_Users.DisplayMember = "COMPLETE_NAME"
        CB_Users.ValueMember = "USER_ID"
        CB_Users.SelectedIndex = 0

        'Disable fields
        TB_FirstName.Enabled = False
        TB_LastName.Enabled = False
        TB_Email.Enabled = False
        TB_UserName.Enabled = False
        TB_Password.Enabled = False

        InitializationOfFields()

    End Sub

    Private Sub BT_UpdateUser_Click(sender As Object, e As EventArgs) Handles BT_UpdateUser.Click

        If TB_FirstName.Text = "" Then
            MessageBox.Show("Favor de ingresar el nombre completo del usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_LastName.Text = "" Then
            MessageBox.Show("Favor de ingresar el/los apellido(s).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Email.Text = "" Then
            MessageBox.Show("Favor de ingresar un email.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_UserName.Text = "" Then
            MessageBox.Show("Favor de ingresar el nombre de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Password.Text = "" Then
            MessageBox.Show("Favor de ingresar un password.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'All fields were completed
            If Not IsValidEmail(TB_Email.Text) Then
                MessageBox.Show("Ingrese una dirección de correo válida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TB_Email.Focus()
            Else
                Dim User = New CL_Users(CB_Users.SelectedValue, TB_FirstName.Text, TB_LastName.Text, TB_Email.Text, TB_UserName.Text, HashPassword(TB_Password.Text))

                If User.UpdateUser() Then
                    MessageBox.Show("El usuario: " & TB_UserName.Text & " se actualizó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    InitializationOfFields()

                    'Load companies information into de combobox
                    CB_Users.DataSource = User.GetUsers()
                    CB_Users.DisplayMember = "COMPLETE_NAME"
                    CB_Users.ValueMember = "USER_ID"
                    CB_Users.SelectedIndex = 0

                    'Disable fields
                    TB_FirstName.Enabled = False
                    TB_LastName.Enabled = False
                    TB_Email.Enabled = False
                    TB_UserName.Enabled = False
                    TB_Password.Enabled = False

                    'Disable fields
                    TB_FirstName.Text = ""
                    TB_LastName.Text = ""
                    TB_Email.Text = ""
                    TB_UserName.Text = ""
                    TB_Password.Text = ""

                End If
            End If
        End If
    End Sub

    Private Sub CB_Users_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Users.SelectedIndexChanged
        Dim Users = New CL_Users()

        If CB_Users.SelectedIndex <> 0 Then
            TB_FirstName.Enabled = True
            TB_LastName.Enabled = True
            TB_Email.Enabled = True
            TB_UserName.Enabled = True
            TB_Password.Enabled = True
            Users.USER_ID = CB_Users.SelectedValue
            Dim LT_Users As DataTable = Users.GetUserData()

            For Each item As DataRow In LT_Users.Rows
                TB_FirstName.Text = item("USER_FNAME").ToString
                TB_LastName.Text = item("USER_LNAME").ToString
                TB_Email.Text = item("USER_EMAIL").ToString
                TB_UserName.Text = item("USER_NAME").ToString
            Next

        End If
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

    Private Sub InitializationOfFields()

        Dim users As New CL_Users

        'Cargar usuarios en ComboBox
        CB_Users.DataSource = users.GetUsers()
        CB_Users.DisplayMember = "COMPLETE_NAME"
        CB_Users.ValueMember = "USER_ID"
        CB_Users.SelectedIndex = 0

        'Limpiar campos
        TB_FirstName.Text = ""
        TB_LastName.Text = ""
        TB_Email.Text = ""
        TB_UserName.Text = ""
        TB_Password.Text = ""

        'Deshabilitar campos
        TB_FirstName.Enabled = False
        TB_LastName.Enabled = False
        TB_Email.Enabled = False
        TB_UserName.Enabled = False
        TB_Password.Enabled = False

        Display_Record()

    End Sub



End Class