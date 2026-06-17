Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class ST_UPD_Users

    Private SelectedUserID As Integer = 0

    Private Sub ST_UPD_Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        LoadRolesGrid()
    End Sub


    Private Sub LoadUsers()

        Dim user As New CL_Users()
        DGV_Roles.DataSource = user.GetUsersDetailed()

        With DGV_Roles
            If .Columns.Contains("USER_ID") Then .Columns("USER_ID").Visible = False
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
            .AllowUserToAddRows = False

            .Columns("Seleccionado").DisplayIndex = 0
            .Columns("Seleccionado").HeaderText = "Asignar"

            .Columns("ROLE_ID").Visible = False
            .Columns("ROLE_NAME").HeaderText = "Rol"

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

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

    Private Sub BT_UpdateUser_Click(sender As Object, e As EventArgs) Handles BT_UpdateUser.Click
        Try
            If SelectedUserID = 0 Then
                MessageBox.Show("Por favor, selecciona un usuario de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If TB_UserName.Text.Trim = "" Then
                MessageBox.Show("El nombre de usuario no puede quedar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim user As New CL_Users()
            Dim password As String = TB_Password.Text.Trim
            Dim tieneNuevaClave As String = ""

            If password = "" Then
                password = Nothing
                tieneNuevaClave = "NO SE MODIFICÓ LA CONTRASEÑA"
            Else
                password = user.HashPassword(password)
                tieneNuevaClave = "SE ACTUALIZÓ LA CONTRASEÑA CON UN NUEVO HASH"
            End If

            Dim updUser As New CL_Users(
                    SelectedUserID,
                    DBNull.Value,
                    TB_UserName.Text.Trim,
                    If(password Is Nothing, DBNull.Value, password)
                )

            If updUser.UpdateUser() Then

                ' LOG DE ACTUALIZACIÓN 
                Dim descUpdate As String = $"MODIFICACIÓN DE DATOS: Se guardaron cambios en la cuenta '{TB_UserName.Text.Trim}' (USER_ID: {SelectedUserID}). Estado de seguridad: [{tieneNuevaClave}]."
                InsertLog(user.DB_Connection, GlobalSession.GlobalUserName, "Settings_Users", "UPDATE_USER_BASE", descUpdate, SelectedUserID, "INFO")

                user.DeleteUserRoles(SelectedUserID)

                For Each row As DataGridViewRow In DGV_RolesSelection.Rows

                    If Not IsDBNull(row.Cells("Seleccionado").Value) AndAlso CBool(row.Cells("Seleccionado").Value) = True Then

                        Dim ROLE_ID As Integer = CInt(row.Cells("ROLE_ID").Value)
                        user.AssignRoleToUser(SelectedUserID, ROLE_ID)

                    End If

                Next

                MessageBox.Show("Usuario actualizado correctamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadUsers()

            End If

        Catch ex As Exception
            ' LOG DE ERROR 
            Dim connectionFallBack As New CL_Users()
            Dim descError As String = $"ERROR CRÍTICO: Falló la actualización del usuario ID: {SelectedUserID}. Motivo: {ex.Message}"

            InsertLog(connectionFallBack.DB_Connection, GlobalSession.GlobalUserName, "Settings_Users", "ERROR_UPDATE_USER", descError, SelectedUserID, "ERROR", ex.StackTrace)

            MessageBox.Show("Ocurrió un error al actualizar los datos: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub DGV_Roles_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Roles.CellContentClick
    '    If e.RowIndex < 0 Then Exit Sub

    '    SelectedUserID = CInt(DGV_Roles.Rows(e.RowIndex).Cells("USER_ID").Value)

    '    Dim user As New CL_Users()
    '    user.USER_ID = SelectedUserID

    '    Dim dt = user.GetUserData()

    '    If dt.Rows.Count > 0 Then
    '        TB_UserName.Text = dt.Rows(0)("USER_NAME").ToString()

    '    End If

    '    LoadUserRoles(SelectedUserID)
    'End Sub

    Private Sub DGV_Roles_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Roles.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_Roles.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Roles.Rows(hit.RowIndex)

                SelectedUserID = CInt(row.Cells("USER_ID").Value)

                Dim user As New CL_Users()
                user.USER_ID = SelectedUserID

                Dim dt As DataTable = user.GetUserData()

                If dt.Rows.Count > 0 Then
                    TB_UserName.Text = dt.Rows(0)("USER_NAME").ToString()
                End If

                LoadUserRoles(SelectedUserID)

            Catch ex As Exception
                MsgBox("Error al cargar la información del usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub
End Class