Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class ST_INS_Users




    Private FormLoaded As Boolean = False
    Private SelectedUserID As Integer = 0

    Private Sub ST_INS_Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()

        TB_UserName.Text = ""
        TB_Password.Text = ""

        SelectedUserID = 0

        FormLoaded = False

        LoadEmployees()
        LoadRolesGrid()
        LoadUsers()

        FormLoaded = True

    End Sub


    Private Sub LoadEmployees()

        Dim emp As New CL_Employee()
        DGV_Employees.DataSource = emp.Get_AllEmployees()

        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub


    Private Sub LoadUsers()

        Dim user As New CL_Users()
        DGV_Roles.DataSource = user.GetUsersDetailed()

        With DGV_Roles

            If .Columns.Contains("USER_ID") Then .Columns("USER_ID").Visible = False

            If .Columns.Contains("Usuario") Then .Columns("Usuario").HeaderText = "Usuario"
            If .Columns.Contains("Empleado") Then .Columns("Empleado").HeaderText = "Empleado"
            If .Columns.Contains("FechaRegistro") Then .Columns("FechaRegistro").HeaderText = "Fecha de registro"
            If .Columns.Contains("Rol") Then .Columns("Rol").HeaderText = "Rol asignado"

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        End With

    End Sub

    Private Sub LoadRolesGrid()

        Dim cn As New SqlConnection(My.Settings.ConnectionString)
        Dim cmd As New SqlCommand("SELECT ROLE_ID, ROLE_NAME FROM ST_Roles", cn)
        Dim dt As New DataTable()

        cn.Open()
        dt.Load(cmd.ExecuteReader())
        cn.Close()

        dt.Columns.Add("Seleccionado", GetType(Boolean))

        DGV_RolesSelection.DataSource = dt

        With DGV_RolesSelection

            .Columns("Seleccionado").DisplayIndex = 0
            .Columns("Seleccionado").HeaderText = "Asignar"

            .Columns("ROLE_ID").Visible = False
            .Columns("ROLE_NAME").HeaderText = "Rol disponible"

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            .AllowUserToAddRows = False

        End With

    End Sub


    Private Sub DGV_Roles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Roles.CellClick

        If e.RowIndex < 0 Then Exit Sub

        SelectedUserID = CInt(DGV_Roles.Rows(e.RowIndex).Cells("USER_ID").Value)

        LoadUserRoles(SelectedUserID)

    End Sub


    Private Sub LoadUserRoles(USER_ID As Integer)

        For Each row As DataGridViewRow In DGV_RolesSelection.Rows
            row.Cells("Seleccionado").Value = False
        Next

        Dim user As New CL_Users()
        Dim dt As DataTable = user.GetUserRoles(USER_ID)

        For Each dbRow As DataRow In dt.Rows
            For Each gridRow As DataGridViewRow In DGV_RolesSelection.Rows

                If CInt(gridRow.Cells("ROLE_ID").Value) = CInt(dbRow("ROLE_ID")) Then
                    gridRow.Cells("Seleccionado").Value = True
                End If

            Next
        Next

    End Sub


    Private Sub DGV_RolesSelection_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_RolesSelection.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim ROLE_ID As Integer = CInt(DGV_RolesSelection.Rows(e.RowIndex).Cells("ROLE_ID").Value)

        Dim cn As New SqlConnection(My.Settings.ConnectionString)
        Dim cmd As New SqlCommand("SEL_ROLEDETAILS", cn)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ROLE_ID", ROLE_ID)

        Dim dt As New DataTable()

        cn.Open()
        dt.Load(cmd.ExecuteReader())
        cn.Close()

        DGV_Permissions.DataSource = dt

        With DGV_Permissions

            If .Columns.Contains("FORM_ID") Then .Columns("FORM_ID").Visible = False
            If .Columns.Contains("ROLE_ID") Then .Columns("ROLE_ID").Visible = False

            If .Columns.Contains("Formulario") Then .Columns("Formulario").HeaderText = "Formulario"
            If .Columns.Contains("Descripción") Then .Columns("Descripción").HeaderText = "Descripción"

            If .Columns.Contains("CAN_INS") Then .Columns("Insertar").HeaderText = "Puede agregar"
            If .Columns.Contains("CAN_UPD") Then .Columns("Actualizar").HeaderText = "Puede modificar"

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        End With

    End Sub


    Private Sub BT_RegisterUser_Click(sender As Object, e As EventArgs) Handles BT_RegisterUser.Click

        If TB_UserName.Text.Trim = "" Or TB_Password.Text.Trim = "" Then
            MessageBox.Show("Completa los datos")
            Exit Sub
        End If

        If DGV_Employees.CurrentRow Is Nothing Then
            MessageBox.Show("Selecciona empleado")
            Exit Sub
        End If

        Dim userCheck As New CL_Users()
        Dim dtUser = userCheck.GetUserDataByUsername(TB_UserName.Text.Trim)

        If dtUser IsNot Nothing AndAlso dtUser.Rows.Count > 0 Then
            MessageBox.Show("El usuario ya existe")
            Exit Sub
        End If

        Dim u As New CL_Users()
        MessageBox.Show(u.HashPassword("12345"))

        Dim EMPL_ID As Integer = CInt(DGV_Employees.CurrentRow.Cells(0).Value)

        Dim userCL As New CL_Users()

        Dim hashedPassword As String = userCL.HashPassword(TB_Password.Text.Trim)

        Dim user As New CL_Users(
            EMPL_ID,
            TB_UserName.Text.Trim,
            hashedPassword
            )

        Dim USER_ID As Integer = user.InsertSystemUser()

        If USER_ID > 0 Then
            MessageBox.Show("Usuario creado. Ahora selecciona y asigna roles.")
            LoadUsers()
        Else
            MessageBox.Show("Error al crear usuario")
        End If

    End Sub


    Private Sub BT_SaveRoles_Click(sender As Object, e As EventArgs) Handles BT_SaveRoles.Click

        If SelectedUserID = 0 Then
            MessageBox.Show("Selecciona un usuario")
            Exit Sub
        End If

        Dim user As New CL_Users()

        user.DeleteUserRoles(SelectedUserID)

        For Each row As DataGridViewRow In DGV_RolesSelection.Rows

            If Not IsDBNull(row.Cells("Seleccionado").Value) AndAlso CBool(row.Cells("Seleccionado").Value) = True Then

                Dim ROLE_ID As Integer = CInt(row.Cells("ROLE_ID").Value)

                user.AssignRoleToUser(SelectedUserID, ROLE_ID)

            End If

        Next

        MessageBox.Show("Roles actualizados correctamente")

        LoadUsers()

    End Sub


End Class
