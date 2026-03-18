Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.Mail

Public Class MD_INS_Employees
    Private Sub MD_INS_Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializationOfFields()

    End Sub

    Public Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False

        Try
            Dim addr As New MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    Private Sub InitializationOfFields()

        TB_EmployeeName.Text = ""
        TB_LastName1.Text = ""
        TB_LastName2.Text = ""
        DT_BornDate.Value = Date.Today()
        TB_BornCity.Text = ""
        TB_PersonalAddress.Text = ""
        TB_PhoneNumber.Text = ""
        TB_EmailAddress.Text = ""
        TB_CivilStatus.Text = ""
        TB_Curp.Text = ""
        TB_SocialNumber.Text = ""

        TB_RFC.Text = ""
        TB_FiscalAddress.Text = ""
        TB_BankName.Text = ""
        TB_BankAccount.Text = ""

        CB_Company.Items.Clear()
        CB_EmployeeType.Items.Clear()
        DT_EntryDate.Value = Date.Today()
        DT_RegistrationDate.Value = Date.Today()
        CB_Position.Items.Clear()
        CB_Supervisor.Items.Clear()
        TB_VacationsDays.Text = ""
        TB_BaseSalary.Text = ""

        TB_EmergencyContact.Text = ""
        TB_Relationship.Text = ""
        TB_EmergencyPhone.Text = ""
        TB_Baneficiary.Text = ""

        Dim Departments = New CL_Departments
        Dim ListOfDepartments As DataTable = Departments.Get_ListOfDepartments()

        CB_Department.Items.Clear()

        For Each Item As DataRow In ListOfDepartments.Rows
            CB_Department.Items.Add(New ComboItem With {
        .Id = CInt(Item(0)),
        .Descripcion = Item(1).ToString
    })
        Next

        CB_Department.DisplayMember = "Descripcion"
        CB_Department.ValueMember = "Id"
        CB_Department.SelectedIndex = 0

        Dim imagePath As String = Path.Combine(
            Application.StartupPath,
            "System_Images",
            "default_user.png"
        )

        If File.Exists(imagePath) Then
            PB_Picture.Image = Image.FromFile(imagePath)
        End If

        'Fill Manually Type of Employee
        CB_EmployeeType.Items.Add(New ComboItem With {.Id = 10, .Descripcion = "Seleccione uno"})
        CB_EmployeeType.Items.Add(New ComboItem With {.Id = 20, .Descripcion = "Directo"})
        CB_EmployeeType.Items.Add(New ComboItem With {.Id = 30, .Descripcion = "Indirecto"})
        CB_EmployeeType.DisplayMember = "Descripcion"
        CB_EmployeeType.ValueMember = "Id"
        CB_EmployeeType.SelectedIndex = 0

        'Fill companies list
        Dim Companies = New CL_Companies
        Dim ListOfCompanies As DataTable = Companies.GetListOfCompanies()

        For Each Item As DataRow In ListOfCompanies.Rows
            CB_Company.Items.Add(New ComboItem With {.Id = CInt(Item(0)), .Descripcion = Item(1).ToString})
        Next
        CB_Company.DisplayMember = "Descripcion"
        CB_Company.ValueMember = "Id"
        CB_Company.SelectedIndex = 0

        'Fill available positions
        Dim Positions = New CL_Positions
        Dim ListOfPositions As DataTable = Positions.Get_ListOfPositions()

        For Each Item As DataRow In ListOfPositions.Rows
            CB_Position.Items.Add(New ComboItem With {.Id = CInt(Item(0)), .Descripcion = Item(1).ToString})
        Next
        CB_Position.DisplayMember = "Descripcion"
        CB_Position.ValueMember = "Id"
        CB_Position.SelectedIndex = 0

        'Fill available employees
        Dim Employees = New CL_Employee
        Dim ListOfEmployees As DataTable = Employees.Get_ListOfEmployees()

        For Each Item As DataRow In ListOfEmployees.Rows
            CB_Supervisor.Items.Add(New ComboItem With {.Id = CInt(Item(0)), .Descripcion = Item(1).ToString})
        Next
        CB_Supervisor.DisplayMember = "Descripcion"
        CB_Supervisor.ValueMember = "Id"
        CB_Supervisor.SelectedIndex = 0

        Display_Record()

    End Sub

    Private Sub MD_INS_Employees_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ActiveControl = TB_EmployeeName
    End Sub

    Private Sub BT_EmployeeRegister_Click(sender As Object, e As EventArgs) Handles BT_EmployeeRegister.Click
        If TB_EmployeeName.Text = "" Then
            MessageBox.Show("Favor de ingresar nombre(s) del empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_LastName1.Text = "" Then
            MessageBox.Show("Favor de ingresar apellido paterno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_LastName2.Text = "" Then
            MessageBox.Show("Favor de indicar apellido materno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf DT_BornDate.Value = Date.Today Then
            MessageBox.Show("Favor de ingresar una fecha de nacimiento valida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Not IsValidEmail(TB_EmailAddress.Text) Then
            MessageBox.Show("Ingrese una dirección de correo válida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TB_EmailAddress.Focus()
        ElseIf CB_Company.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de indicar a qué empresa será asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf CB_EmployeeType.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de indicar tipo de empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf CB_Position.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de seleccionar la posición a ocupar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf CB_Department.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de seleccionar un departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            'select the company
            Dim Company As ComboItem = CType(CB_Company.SelectedItem, ComboItem)
            Dim Id_Company As Integer = Company.Id
            Dim Description_Company As String = Company.Descripcion

            'Select the Type of Employee
            Dim TypeOfEmployee As ComboItem = CType(CB_EmployeeType.SelectedItem, ComboItem)
            Dim Id_TypeOfEmployee As Integer = TypeOfEmployee.Id
            Dim Description_TypeOfEmployee As String = TypeOfEmployee.Descripcion

            'Select the Positions
            Dim Positions As ComboItem = CType(CB_Position.SelectedItem, ComboItem)
            Dim Id_Position As Integer = Positions.Id
            Dim Description_Position As String = Positions.Descripcion

            'Select the Supervisor
            Dim Supervisor As ComboItem = CType(CB_Supervisor.SelectedItem, ComboItem)
            Dim Id_Supervisor As Integer = Supervisor.Id
            Dim Description_Supervisor As String = Supervisor.Descripcion

            'Select the Supervisor
            Dim Employees As ComboItem = CType(CB_Supervisor.SelectedItem, ComboItem)
            Dim Id_Employee As Integer = Employees.Id
            Dim Description_Employee As String = Employees.Descripcion

            Dim PhotoPath As String = Nothing

            If PB_Picture.Tag IsNot Nothing Then
                PhotoPath = PB_Picture.Tag.ToString()
            End If

            Dim Department As ComboItem = CType(CB_Department.SelectedItem, ComboItem)
            Dim Id_Department As Integer = Department.Id

            Dim Employee = New CL_Employee(
            TB_EmployeeName.Text,
            TB_LastName1.Text,
            TB_LastName2.Text,
            DT_BornDate.Value,
            TB_BornCity.Text,
            TB_PersonalAddress.Text,
            TB_PhoneNumber.Text,
            TB_EmailAddress.Text,
            TB_CivilStatus.Text,
            TB_Curp.Text,
            TB_SocialNumber.Text,
            TB_RFC.Text,
            TB_FiscalAddress.Text,
            TB_BankName.Text,
            TB_BankAccount.Text,
            Id_Company,
            Id_TypeOfEmployee,
            DT_EntryDate.Value,
            DT_RegistrationDate.Value,
            Id_Position,
            Id_Supervisor,
            TB_VacationsDays.Text,
            TB_BaseSalary.Text,
            Id_Department,              'NUEVO
            TB_EmergencyContact.Text,
            TB_Relationship.Text,
            TB_EmergencyPhone.Text,
            TB_Baneficiary.Text,
            TB_Costc.Text,         'NUEVO
            AppUser,
            PhotoPath,
            1)
            If Employee.InsertEmployee() Then
                MessageBox.Show("El empleado " + TB_EmployeeName.Text + " fue creado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
            End If

        End If
    End Sub

    Private Sub BT_Picture_Click(sender As Object, e As EventArgs) Handles BT_Picture.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar foto del empleado"
            ofd.Filter = "Imágenes (*.jpg;*.png)|*.jpg;*.png"

            If ofd.ShowDialog() = DialogResult.OK Then

                Dim SourcePath As String = ofd.FileName
                'Dim DestinationPath As String = My.Settings.PicturesOfEmployees
                Dim DestinationPath As String =
                Path.Combine(Application.StartupPath, "Images", "Employees")



                ' Ensure that the path exist
                If Not Directory.Exists(DestinationPath) Then
                    Directory.CreateDirectory(DestinationPath)
                End If

                'Assign file name
                Dim FileName As String = "EMP_" & DateTime.Now.Ticks & Path.GetExtension(SourcePath)
                Dim FinalFileName As String = Path.Combine(DestinationPath, FileName)

                'Copy file
                File.Copy(SourcePath, FinalFileName, True)

                'load file wihtout any blocking
                Using imgTemp As Image = Image.FromFile(FinalFileName)
                    PB_Picture.Image = New Bitmap(imgTemp)
                End Using

                'assign file name
                PB_Picture.Tag = FinalFileName
            End If
        End Using
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Employee()
        DGV_AllEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_AllEmployees.AutoResizeColumns()
        DGV_AllEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_AllEmployees.DataSource = report.Get_AllEmployees
    End Sub
End Class