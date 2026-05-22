Imports Microsoft.Data.SqlClient

Public Class MD_INS_Departments
    Private Sub MD_INS_Departments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()

        TB_DepartmentName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""

        Display_Record()

    End Sub

    Private Sub Display_Record()

        Dim report As New CL_Departments()

        DGV_DepartmentsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DepartmentsList.AutoResizeColumns()
        DGV_DepartmentsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_DepartmentsList.DataSource = report.Get_AllDepartments()

    End Sub

    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
    '    If TB_DepartmentName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar el nombre del departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza el departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    Else

    '        Dim Department = New CL_Departments(
    '        TB_DepartmentName.Text,
    '        TB_Description.Text,
    '        TB_AuthorizeBy.Text,
    '        Date.Now,
    '        AppUser,
    '        1
    '    )

    '        If Department.InsertDepartment() Then

    '            MessageBox.Show("El departamento " + TB_DepartmentName.Text + " fue ingresado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            InitializationOfFields()

    '        End If

    '    End If

    'End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
            If TB_DepartmentName.Text.Trim = "" Then
                MessageBox.Show("Favor de ingresar el nombre del departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If TB_Description.Text.Trim = "" Then
                MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If TB_AuthorizeBy.Text.Trim = "" Then
                MessageBox.Show("Favor de indicar quién autoriza el departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim Department = New CL_Departments(
                TB_DepartmentName.Text.Trim,
                TB_Description.Text.Trim,
                TB_AuthorizeBy.Text.Trim,
                Date.Now,
                GlobalSession.GlobalUserName,
                1
            )

            If Department.InsertDepartment() Then
                Dim connTmp As New SqlConnection(My.Settings.ConnectionString)

                'LOG DE ÉXITO
                Dim descExito As String = $"CREACIÓN DE DEPARTAMENTO: Se registró la nueva área '{TB_DepartmentName.Text.Trim}'. Autorizado por: {TB_AuthorizeBy.Text.Trim}. Descripción operativa: [{TB_Description.Text.Trim}]."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Departments", "INSERT_DEPARTMENT_SUCCESS", descExito, 0, "INFO")

                MessageBox.Show("El departamento " + TB_DepartmentName.Text.Trim + " fue ingresado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim descError As String = $"ERROR CRÍTICO: Falló la creación del departamento '{TB_DepartmentName.Text.Trim}'. Motivo: {ex.Message}"

            InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Departments", "ERROR_INSERT_DEPARTMENT", descError, 0, "ERROR", ex.StackTrace)

            MessageBox.Show("Ocurrió un error inesperado al registrar el departamento: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class