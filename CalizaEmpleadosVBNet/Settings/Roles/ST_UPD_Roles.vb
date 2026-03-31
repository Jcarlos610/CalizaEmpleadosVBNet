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

        ' Combo Roles
        CB_AllRoles.DataSource = report.Get_ListOfRoles()
        CB_AllRoles.DisplayMember = "Nombre"
        CB_AllRoles.ValueMember = "ID"

        ' Limpiar campos
        TB_RoleName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        CB_Status.Checked = False

        LoadForms()
        Display_Record()

        FormLoaded = True

    End Sub

    '========================
    ' FORMULARIOS (UX)
    '========================
    Private Sub LoadForms()

        Dim cn As New SqlConnection(My.Settings.ConnectionString)
        Dim cmd As New SqlCommand("SELECT FORM_ID, FORM_DESCRIPTION FROM ST_Forms", cn)
        Dim dt As New DataTable()

        cn.Open()
        dt.Load(cmd.ExecuteReader())
        cn.Close()

        ' 🔥 OPCIÓN UX
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

    '========================
    ' ACTUALIZAR ROL
    '========================
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

    '========================
    ' CARGAR PERMISOS
    '========================
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

    '========================
    ' MOSTRAR DESCRIPCIÓN FORM
    '========================
    Private Sub CB_Forms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Forms.SelectedIndexChanged

        If CB_Forms.SelectedItem Is Nothing Then Exit Sub

        Dim row As DataRowView = CType(CB_Forms.SelectedItem, DataRowView)
        TB_FormDescription.Text = row("FORM_DESCRIPTION").ToString()

    End Sub

    '========================
    ' AGREGAR PERMISO
    '========================
    'Private Sub BT_AddPermission_Click(sender As Object, e As EventArgs) Handles BT_AddPermission.Click

    '    If CB_AllRoles.SelectedValue Is Nothing Then Exit Sub

    '    If CInt(CB_Forms.SelectedValue) = 0 Then
    '        MessageBox.Show("Selecciona un formulario válido")
    '        Exit Sub
    '    End If

    '    Dim ROLE_ID As Integer = CInt(CB_AllRoles.SelectedValue)
    '    Dim FORM_ID As Integer = CInt(CB_Forms.SelectedValue)

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

        If CB_AllRoles.SelectedValue Is Nothing Then Exit Sub

        If CInt(CB_Forms.SelectedValue) = 0 Then
            MessageBox.Show("Selecciona un formulario válido")
            Exit Sub
        End If

        Dim ROLE_ID As Integer = CInt(CB_AllRoles.SelectedValue)
        Dim FORM_ID As Integer = CInt(CB_Forms.SelectedValue)

        ' 🔥 VALIDAR DUPLICADO EN GRID
        For Each row As DataGridViewRow In DGV_Permissions.Rows

            If CInt(row.Cells("FORM_ID").Value) = FORM_ID Then
                MessageBox.Show("Este formulario ya está asignado a este rol")
                Exit Sub
            End If

        Next

        ' 🔥 INSERTAR SOLO SI NO EXISTE
        Dim cn As New SqlConnection(My.Settings.ConnectionString)
        Dim cmd As New SqlCommand("INS_ROLEDETAIL", cn)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ROLE_ID", ROLE_ID)
        cmd.Parameters.AddWithValue("@FORM_ID", FORM_ID)
        cmd.Parameters.AddWithValue("@DESCR", TB_FormDescription.Text)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            MessageBox.Show("Permiso agregado")

            LoadPermissions(ROLE_ID)

            CB_Forms.SelectedIndex = 0
            TB_FormDescription.Text = ""

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
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