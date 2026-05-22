Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class ST_UPD_Roles

    Private FormLoaded As Boolean = False

    Private Sub ST_UPD_Roles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()

        FormLoaded = False

        Dim report As New CL_Roles()

        CB_AllRoles.DataSource = report.Get_ListOfRoles()
        CB_AllRoles.DisplayMember = "Nombre"
        CB_AllRoles.ValueMember = "ID"

        TB_RoleName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        CB_Status.Checked = False

        LoadForms()
        Display_Record()

        FormLoaded = True

    End Sub

    Private Sub LoadForms()

        Dim cn As New SqlConnection(My.Settings.ConnectionString)
        Dim cmd As New SqlCommand("SELECT FORM_ID, FORM_DESCRIPTION FROM ST_Forms", cn)
        Dim dt As New DataTable()

        cn.Open()
        dt.Load(cmd.ExecuteReader())
        cn.Close()

        Dim row As DataRow = dt.NewRow()
        row("FORM_ID") = 0
        row("FORM_DESCRIPTION") = "Seleccione un formulario"
        dt.Rows.InsertAt(row, 0)

        CB_Forms.DataSource = dt
        CB_Forms.DisplayMember = "FORM_DESCRIPTION"
        CB_Forms.ValueMember = "FORM_ID"

    End Sub


    Private Sub Display_Record()

    End Sub


    Private Sub CB_AllRoles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllRoles.SelectedIndexChanged

        If Not FormLoaded Then Exit Sub
        If CB_AllRoles.SelectedValue Is Nothing Then Exit Sub
        If Not IsNumeric(CB_AllRoles.SelectedValue) Then Exit Sub

        Dim idRole As Integer = CInt(CB_AllRoles.SelectedValue)

        Dim Role As New CL_Roles
        Dim dt As DataTable = Role.Get_OneRole(idRole)

        If dt.Rows.Count = 0 Then Exit Sub

        Dim row As DataRow = dt.Rows(0)

        TB_RoleName.Text = row("ROLE_NAME").ToString()
        TB_Description.Text = row("ROLE_DESCR").ToString()
        TB_AuthorizeBy.Text = row("ROLE_AUTH").ToString()
        CB_Status.Checked = row("ROLE_STAT")

        LoadPermissions(idRole)

    End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

        If TB_RoleName.Text = "" Then
            MessageBox.Show("Ingresa nombre del rol")
            Exit Sub
        End If

        If TB_Description.Text = "" Then
            MessageBox.Show("Ingresa descripción")
            Exit Sub
        End If

        If TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Ingresa autorizado por")
            Exit Sub
        End If

        Dim Role = New CL_Roles(
            CInt(CB_AllRoles.SelectedValue),
            TB_RoleName.Text,
            TB_Description.Text,
            Date.Now,
            AppUser,
            TB_AuthorizeBy.Text,
            CB_Status.Checked
        )

        If Role.UpdateRole() Then
            MessageBox.Show("Rol actualizado correctamente")
            Display_Record()
        End If

    End Sub

    Private Sub LoadPermissions(ROLE_ID As Integer)

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

            .Columns("ROLE_ID").Visible = False
            .Columns("FORM_ID").Visible = False

            .Columns("Rol").HeaderText = "Rol"
            .Columns("Formulario").HeaderText = "Formulario"
            .Columns("Descripción").HeaderText = "Descripción"

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        End With

    End Sub


    Private Sub CB_Forms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Forms.SelectedIndexChanged

        If CB_Forms.SelectedItem Is Nothing Then Exit Sub

        Dim row As DataRowView = CType(CB_Forms.SelectedItem, DataRowView)
        TB_FormDescription.Text = row("FORM_DESCRIPTION").ToString()

    End Sub



    'Private Sub BT_AddPermission_Click(sender As Object, e As EventArgs) Handles BT_AddPermission.Click

    '    If CB_AllRoles.SelectedValue Is Nothing Then Exit Sub

    '    If CInt(CB_Forms.SelectedValue) = 0 Then
    '        MessageBox.Show("Selecciona un formulario válido")
    '        Exit Sub
    '    End If

    '    Dim ROLE_ID As Integer = CInt(CB_AllRoles.SelectedValue)
    '    Dim FORM_ID As Integer = CInt(CB_Forms.SelectedValue)

    '    For Each row As DataGridViewRow In DGV_Permissions.Rows

    '        If CInt(row.Cells("FORM_ID").Value) = FORM_ID Then
    '            MessageBox.Show("Este formulario ya está asignado a este rol")
    '            Exit Sub
    '        End If

    '    Next

    '    Dim cn As New SqlConnection(My.Settings.ConnectionString)
    '    Dim cmd As New SqlCommand("INS_ROLEDETAIL", cn)

    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@ROLE_ID", ROLE_ID)
    '    cmd.Parameters.AddWithValue("@FORM_ID", FORM_ID)
    '    cmd.Parameters.AddWithValue("@DESCR", TB_FormDescription.Text)

    '    Try
    '        cn.Open()
    '        cmd.ExecuteNonQuery()
    '        cn.Close()

    '        MessageBox.Show("Permiso agregado")

    '        LoadPermissions(ROLE_ID)

    '        CB_Forms.SelectedIndex = 0
    '        TB_FormDescription.Text = ""

    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message)
    '    End Try

    'End Sub


    Private Sub BT_AddPermission_Click(sender As Object, e As EventArgs) Handles BT_AddPermission.Click
        Try
            If CB_AllRoles.SelectedValue Is Nothing Then Exit Sub

            Dim formIdSeleccionado As Integer = CInt(CB_Forms.SelectedValue)
            If formIdSeleccionado = 0 Then
                MessageBox.Show("Selecciona un formulario válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim ROLE_ID As Integer = CInt(CB_AllRoles.SelectedValue)

            For Each row As DataGridViewRow In DGV_Permissions.Rows
                If CInt(row.Cells("FORM_ID").Value) = formIdSeleccionado Then
                    MessageBox.Show("Este formulario ya se encuentra asignado a este rol.", "Permiso Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Next

            Dim cn As New SqlConnection(My.Settings.ConnectionString)
            Dim cmd As New SqlCommand("INS_ROLEDETAIL", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ROLE_ID", ROLE_ID)
            cmd.Parameters.AddWithValue("@FORM_ID", formIdSeleccionado)
            cmd.Parameters.AddWithValue("@DESCR", TB_FormDescription.Text.Trim)

            Try
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                'LOG DE MODIFICACIÓN 
                Dim nombreRol As String = CB_AllRoles.Text
                Dim nombreFormulario As String = CB_Forms.Text
                Dim descModif As String = $"PERMISO AGREGADO DESDE EDICIÓN: Se vinculó la pantalla '{nombreFormulario}' (FORM_ID: {formIdSeleccionado}) al rol '{nombreRol}' (ROLE_ID: {ROLE_ID}). Detalle operativo: [{TB_FormDescription.Text.Trim}]."
                InsertLog(cn, GlobalSession.GlobalUserName, "Settings_Roles", "UPDATE_ADD_PERMISSION", descModif, ROLE_ID, "INFO")

                MessageBox.Show("Permiso agregado correctamente al rol.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadPermissions(ROLE_ID)

                CB_Forms.SelectedIndex = 0
                TB_FormDescription.Text = ""

            Catch ex As Exception
                'LOG DE ERROR 
                Dim descError As String = $"ERROR CRÍTICO: Falló la inserción del permiso en edición para el ROLE_ID: {ROLE_ID}. Motivo: {ex.Message}"
                InsertLog(cn, GlobalSession.GlobalUserName, "Settings_Roles", "ERROR_ADD_PERMISSION_UPD", descError, ROLE_ID, "ERROR", ex.StackTrace)

                MessageBox.Show("Error al agregar permiso: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Catch ex As Exception
            Dim cnFallback As New SqlConnection(My.Settings.ConnectionString)
            InsertLog(cnFallback, GlobalSession.GlobalUserName, "Settings_Roles", "ERROR_GENERAL_UPD_ROLES", "Falla general en el flujo del botón: " & ex.Message, 0, "ERROR", ex.StackTrace)
            MessageBox.Show("Ocurrió un error inesperado: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub DGV_Permissions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Permissions.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim result = MessageBox.Show("¿Eliminar permiso?", "Confirmar", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then Exit Sub

        Try
            Dim ROLE_ID As Integer = CInt(CB_AllRoles.SelectedValue)
            Dim FORM_ID As Integer = CInt(DGV_Permissions.Rows(e.RowIndex).Cells("FORM_ID").Value)

            Dim cn As New SqlConnection(My.Settings.ConnectionString)
            Dim cmd As New SqlCommand("DEL_ROLEDETAIL", cn)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ROLE_ID", ROLE_ID)
            cmd.Parameters.AddWithValue("@FORM_ID", FORM_ID)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            MessageBox.Show("Permiso eliminado")

            LoadPermissions(ROLE_ID)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

End Class