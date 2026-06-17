'Public Class MD_UPD_Departments
'    Private Sub MD_UPD_Departments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        InitializationOfFields()
'    End Sub

'    Private Sub InitializationOfFields()

'        TB_DepartmentName.Text = ""
'        TB_Description.Text = ""
'        TB_AuthorizeBy.Text = ""

'        Display_Record()

'    End Sub

'    Private Sub Display_Record()

'        Dim report As New CL_Departments()

'        DGV_DepartmentsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
'        DGV_DepartmentsList.AutoResizeColumns()
'        DGV_DepartmentsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

'        DGV_DepartmentsList.DataSource = report.Get_AllDepartments()

'    End Sub

'    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
'        If TB_DepartmentName.Text = "" Then
'            MessageBox.Show("Favor de ingresar el nombre del departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

'        ElseIf TB_Description.Text = "" Then
'            MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

'        Else

'            Dim Department = New CL_Departments(
'            TB_DepartmentName.Text,
'            TB_Description.Text,
'            TB_AuthorizeBy.Text,
'            Date.Now,
'            AppUser,
'            1
'        )

'            Department.DEPT_STAT = CB_Status.Checked

'            If AppUser IsNot Nothing Then

'                If Department.UpdateDepartment() Then
'                    MessageBox.Show("El departamento " + TB_DepartmentName.Text + " fue actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    InitializationOfFields()
'                End If

'            Else
'                MessageBox.Show("No se actualizó el departamento porque no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            End If

'        End If
'    End Sub

'    Private Sub CB_AllDepartments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllDepartments.SelectedIndexChanged
'        If CB_AllDepartments.SelectedValue Is Nothing Then Exit Sub
'        If TypeOf CB_AllDepartments.SelectedValue IsNot Integer Then Exit Sub

'        Dim idDepartment As Integer = CInt(CB_AllDepartments.SelectedValue)

'        Dim Department As New CL_Departments
'        Dim SelectedDepartment As DataTable = Department.Get_OneDepartment(idDepartment)

'        If SelectedDepartment.Rows.Count = 0 Then Exit Sub

'        Dim Item As DataRow = SelectedDepartment.Rows(0)

'        TB_DepartmentName.Text = Item(1).ToString()
'        TB_Description.Text = Item(2).ToString()
'        CB_Status.Checked = Item(5)
'    End Sub
'End Class

Imports Microsoft.Data.SqlClient

Public Class MD_UPD_Departments

    Private Sub MD_UPD_Departments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()

        Dim report As New CL_Departments()

        CB_AllDepartments.DataSource = report.Get_ListOfDepartments()
        CB_AllDepartments.DisplayMember = "Nombre"
        CB_AllDepartments.ValueMember = "ID"
        CB_AllDepartments.SelectedIndex = 0

        TB_DepartmentName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        CB_Status.Checked = False

        Display_Record()

    End Sub

    Private Sub Display_Record()

        Dim report As New CL_Departments()

        DGV_DepartmentsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DepartmentsList.AutoResizeColumns()
        DGV_DepartmentsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_DepartmentsList.DataSource = report.Get_AllDepartments()


    End Sub

    'Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

    '    If TB_DepartmentName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar el nombre del departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza el departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    Else

    '        Dim Department = New CL_Departments(
    '        CInt(CB_AllDepartments.SelectedValue),
    '        TB_DepartmentName.Text,
    '        TB_Description.Text,
    '        TB_AuthorizeBy.Text,
    '        Date.Now,
    '        AppUser,
    '        CB_Status.Checked
    '    )

    '        Department.DEPT_STAT = CB_Status.Checked

    '        If AppUser IsNot Nothing Then

    '            If Department.UpdateDepartment() Then
    '                MessageBox.Show("El departamento " + TB_DepartmentName.Text + " fue actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                InitializationOfFields()
    '            End If

    '        Else
    '            MessageBox.Show("No se actualizó el departamento porque no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If

    '    End If

    'End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
        Try
            Stop
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

            If CB_AllDepartments.SelectedValue Is Nothing OrElse CInt(CB_AllDepartments.SelectedValue) = 0 Then
                MessageBox.Show("Favor de seleccionar un departamento válido para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim targetDeptID As Integer = CInt(CB_AllDepartments.SelectedValue)

            Dim Department = New CL_Departments(
            targetDeptID,
            TB_DepartmentName.Text.Trim,
            TB_Description.Text.Trim,
            TB_AuthorizeBy.Text.Trim,
            Date.Now,
            GlobalSession.GlobalUserName,
            CB_Status.Checked
        )

            Department.DEPT_STAT = CB_Status.Checked
            Dim textoEstado As String = If(CB_Status.Checked, "ACTIVO / OPERATIVO", "INACTIVO / EN REESTRUCTURACIÓN")

            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)

            If Department.UpdateDepartment() Then
                'LOG 
                Dim descUpdate As String = $"MODIFICACIÓN DE DEPARTAMENTO: Se actualizaron los datos del DEPT_ID: {targetDeptID} ('{TB_DepartmentName.Text.Trim}'). Estado actual: [{textoEstado}]. Cambios autorizados por: {TB_AuthorizeBy.Text.Trim}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Departments", "UPDATE_DEPARTMENT_SUCCESS", descUpdate, targetDeptID, "INFO")

                MessageBox.Show("El departamento " + TB_DepartmentName.Text.Trim + " fue actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
            Else
                'LOG DE ADVERTENCIA
                Dim descWarn As String = $"RECHAZO EN BD: El procedimiento no guardó cambios para el DEPT_ID: {targetDeptID}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Departments", "UPDATE_DEPARTMENT_FAILED", descWarn, targetDeptID, "WARNING")
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim currentID As Integer = If(CB_AllDepartments.SelectedValue IsNot Nothing, CInt(CB_AllDepartments.SelectedValue), 0)
            Dim descError As String = $"ERROR CRÍTICO: Falló la modificación del departamento ID: {currentID}. Motivo: {ex.Message}"

            InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Departments", "ERROR_UPDATE_DEPARTMENT", descError, currentID, "ERROR", ex.StackTrace)

            MessageBox.Show("Ocurrió un error inesperado al actualizar el departamento: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CB_AllDepartments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllDepartments.SelectedIndexChanged

        If CB_AllDepartments.SelectedValue Is Nothing Then Exit Sub

        If TypeOf CB_AllDepartments.SelectedValue IsNot Integer Then Exit Sub

        Dim idDepartment As Integer = CInt(CB_AllDepartments.SelectedValue)

        Dim Department As New CL_Departments
        Dim SelectedDepartment As DataTable = Department.Get_OneDepartment(idDepartment)

        If SelectedDepartment.Rows.Count = 0 Then Exit Sub

        Dim Item As DataRow = SelectedDepartment.Rows(0)

        TB_DepartmentName.Text = Item(1).ToString()
        TB_Description.Text = Item(2).ToString()
        TB_AuthorizeBy.Text = Item(3).ToString()

        CB_Status.Checked = Item(6)

    End Sub

End Class