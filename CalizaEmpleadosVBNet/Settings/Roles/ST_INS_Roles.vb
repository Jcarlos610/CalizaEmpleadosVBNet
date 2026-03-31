Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class ST_INS_Roles

    Dim CurrentRoleID As Integer = 0

    Private Sub ST_INS_Roles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()

        TB_RoleName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""

        CurrentRoleID = 0

        LoadForms()
        Display_Record()

        DGV_Permissions.DataSource = Nothing

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

        Dim report As New CL_Roles()

        DGV_RoleList.DataSource = report.Get_AllRoles()

        With DGV_RoleList

            .Columns("ROLE_ID").HeaderText = "ID"
            .Columns("ROLE_NAME").HeaderText = "Nombre del rol"
            .Columns("ROLE_DESCR").HeaderText = "Descripción"
            .Columns("ROLE_DATEC").HeaderText = "Fecha creación"
            .Columns("ROLE_CREBY").HeaderText = "Creado por"
            .Columns("ROLE_AUTH").HeaderText = "Autorizado por"
            .Columns("ROLE_STAT").HeaderText = "Activo"

            .Columns("ROLE_DATEC").DefaultCellStyle.Format = "dd/MM/yyyy"

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        End With

    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        If TB_RoleName.Text = "" Then
            MessageBox.Show("Ingrese nombre del rol")
            Exit Sub
        End If

        If TB_Description.Text = "" Then
            MessageBox.Show("Ingrese descripción")
            Exit Sub
        End If

        If TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Ingrese autorizado por")
            Exit Sub
        End If

        Dim Role = New CL_Roles(
            TB_RoleName.Text,
            TB_Description.Text,
            Date.Now,
            AppUser,
            TB_AuthorizeBy.Text,
            1)



        If Role.InsertRole() Then
            MessageBox.Show("Rol creado correctamente")
            Display_Record()
        End If

    End Sub


    Private Sub DGV_RoleList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_RoleList.CellClick

        If e.RowIndex < 0 Then Exit Sub

        CurrentRoleID = CInt(DGV_RoleList.Rows(e.RowIndex).Cells("ROLE_ID").Value)

        LoadPermissions(CurrentRoleID)

    End Sub



    Private Sub LoadPermissions(roleID As Integer)

        Dim cn As New SqlConnection(My.Settings.ConnectionString)
        Dim cmd As New SqlCommand("SEL_ROLEDETAILS", cn)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ROLE_ID", roleID)

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




    Private Sub BT_Assing_Click(sender As Object, e As EventArgs) Handles BT_Assing.Click

        If CurrentRoleID = 0 Then
            MessageBox.Show("Selecciona un rol")
            Exit Sub
        End If

        If CInt(CB_Forms.SelectedValue) = 0 Then
            MessageBox.Show("Selecciona un formulario válido")
            Exit Sub
        End If


        For Each row As DataGridViewRow In DGV_Permissions.Rows

            If CInt(row.Cells("FORM_ID").Value) = CInt(CB_Forms.SelectedValue) Then
                MessageBox.Show("Este formulario ya está asignado a este rol")
                Exit Sub
            End If

        Next


        Dim cn As New SqlConnection(My.Settings.ConnectionString)
        Dim cmd As New SqlCommand("INS_ROLEDETAIL", cn)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ROLE_ID", CurrentRoleID)
        cmd.Parameters.AddWithValue("@FORM_ID", CInt(CB_Forms.SelectedValue))
        cmd.Parameters.AddWithValue("@DESCR", TB_FormDescription.Text)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            MessageBox.Show("Permiso asignado")

            LoadPermissions(CurrentRoleID)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub


    Private Sub CB_Forms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Forms.SelectedIndexChanged

        If CB_Forms.SelectedItem Is Nothing Then Exit Sub

        Dim row As DataRowView = CType(CB_Forms.SelectedItem, DataRowView)
        TB_FormDescription.Text = row("FORM_DESCRIPTION").ToString()

    End Sub


End Class