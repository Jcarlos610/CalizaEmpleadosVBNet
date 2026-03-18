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

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If TB_DepartmentName.Text = "" Then
            MessageBox.Show("Favor de ingresar el nombre del departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Favor de indicar quién autoriza el departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Dim Department = New CL_Departments(
            TB_DepartmentName.Text,
            TB_Description.Text,
            TB_AuthorizeBy.Text,
            Date.Now,
            AppUser,
            1
        )

            If Department.InsertDepartment() Then

                MessageBox.Show("El departamento " + TB_DepartmentName.Text + " fue ingresado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                InitializationOfFields()

            End If

        End If



    End Sub
End Class