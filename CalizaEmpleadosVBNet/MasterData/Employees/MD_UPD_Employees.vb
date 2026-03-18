Imports System.IO
Imports System.Net.Mail

Public Class MD_UPD_Employees

    Private SelectedEmployeeID As Integer = 0

    Private Sub MD_UPD_Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

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
        CB_Status.Checked = False

        CB_Company.DataSource = Nothing
        CB_EmployeeType.Items.Clear()
        CB_Position.Items.Clear()
        CB_Supervisor.Items.Clear()

        DT_EntryDate.Value = Date.Today()
        DT_RegistrationDate.Value = Date.Today()

        TB_VacationsDays.Text = ""
        TB_BaseSalary.Text = ""

        TB_EmergencyContact.Text = ""
        TB_Relationship.Text = ""
        TB_EmergencyPhone.Text = ""
        TB_Baneficiary.Text = ""

        Dim imagePath As String = Path.Combine(Application.StartupPath, "System_Images", "default_user.png")

        If File.Exists(imagePath) Then
            PB_Picture.Image = Image.FromFile(imagePath)
            PB_Picture.Tag = imagePath
        End If

        'TYPE EMPLOYEE
        CB_EmployeeType.Items.Add(New ComboItem With {.Id = 10, .Descripcion = "Seleccione uno"})
        CB_EmployeeType.Items.Add(New ComboItem With {.Id = 20, .Descripcion = "Directo"})
        CB_EmployeeType.Items.Add(New ComboItem With {.Id = 30, .Descripcion = "Indirecto"})
        CB_EmployeeType.DisplayMember = "Descripcion"
        CB_EmployeeType.ValueMember = "Id"
        CB_EmployeeType.SelectedIndex = 0

        'COMPANY
        Dim Companies = New CL_Companies
        Dim ListOfCompanies As DataTable = Companies.GetListOfCompanies()

        CB_Company.DataSource = ListOfCompanies
        CB_Company.DisplayMember = "COMP_ONAME"
        CB_Company.ValueMember = "COMP_ID"

        If CB_Company.Items.Count > 0 Then
            CB_Company.SelectedIndex = 0
        End If

        'Department
        CB_Department.Items.Clear()

        Dim Departments = New CL_Departments
        Dim ListOfDepartments As DataTable = Departments.Get_ListOfDepartments()

        For Each Item As DataRow In ListOfDepartments.Rows
            CB_Department.Items.Add(New ComboItem With {
        .Id = CInt(Item(0)),
        .Descripcion = Item(1).ToString
    })
        Next

        CB_Department.DisplayMember = "Descripcion"
        CB_Department.ValueMember = "Id"

        If CB_Department.Items.Count > 0 Then
            CB_Department.SelectedIndex = 0
        End If

        'POSITION
        Dim Positions = New CL_Positions
        Dim ListOfPositions As DataTable = Positions.Get_ListOfPositions()

        For Each Item As DataRow In ListOfPositions.Rows
            CB_Position.Items.Add(New ComboItem With {.Id = CInt(Item(0)), .Descripcion = Item(1).ToString})
        Next

        CB_Position.DisplayMember = "Descripcion"
        CB_Position.ValueMember = "Id"

        If CB_Position.Items.Count > 0 Then
            CB_Position.SelectedIndex = 0
        End If


        Dim Employees = New CL_Employee
        Dim ListOfEmployees As DataTable = Employees.Get_ListOfEmployees()

        For Each Item As DataRow In ListOfEmployees.Rows
            CB_Supervisor.Items.Add(New ComboItem With {.Id = CInt(Item(0)), .Descripcion = Item(1).ToString})
        Next

        CB_Supervisor.DisplayMember = "Descripcion"
        CB_Supervisor.ValueMember = "Id"

        If CB_Supervisor.Items.Count > 0 Then
            CB_Supervisor.SelectedIndex = 0
        End If

        Display_Record()

    End Sub

    Private Sub Display_Record()

        Dim report As New CL_Employee()
        Dim table As DataTable = report.Get_AllEmployees()

        If table IsNot Nothing Then
            DGV_AllEmployees.DataSource = table
        End If

        DGV_AllEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_AllEmployees.AutoResizeColumns()

    End Sub

    Private Sub MD_UPD_Employees_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ActiveControl = TB_EmployeeName
    End Sub

    Private Sub BT_EmployeeUpdate_Click(sender As Object, e As EventArgs) Handles BT_EmployeeUpdate.Click

        If SelectedEmployeeID = 0 Then
            MessageBox.Show("Seleccione un empleado para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TB_EmployeeName.Text = "" Then
            MessageBox.Show("Favor de ingresar nombre(s) del empleado.")
            Exit Sub
        End If

        If TB_LastName1.Text = "" Then
            MessageBox.Show("Favor de ingresar apellido paterno.")
            Exit Sub
        End If

        If TB_LastName2.Text = "" Then
            MessageBox.Show("Favor de indicar apellido materno.")
            Exit Sub
        End If

        If Not IsValidEmail(TB_EmailAddress.Text) Then
            MessageBox.Show("Ingrese un correo válido")
            Exit Sub
        End If

        Dim company As Integer = CInt(CB_Company.SelectedValue)

        Dim typeEmployee As ComboItem = CType(CB_EmployeeType.SelectedItem, ComboItem)
        Dim Id_TypeOfEmployee As Integer = typeEmployee.Id

        Dim position As ComboItem = CType(CB_Position.SelectedItem, ComboItem)
        Dim Id_Position As Integer = position.Id

        Dim supervisor As ComboItem = CType(CB_Supervisor.SelectedItem, ComboItem)
        Dim Id_Supervisor As Integer = supervisor.Id

        Dim PhotoPath As String = ""

        If PB_Picture.Tag IsNot Nothing Then
            PhotoPath = PB_Picture.Tag.ToString()
        End If

        Dim Department As ComboItem = CType(CB_Department.SelectedItem, ComboItem)
        Dim Id_Department As Integer = Department.Id

        Dim Employee As New CL_Employee(
            SelectedEmployeeID,
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
            company,
            Id_TypeOfEmployee,
            DT_EntryDate.Value,
            DT_RegistrationDate.Value,
            Id_Position,
            Id_Supervisor,
            TB_VacationsDays.Text,
            TB_BaseSalary.Text,
            Id_Department,
            TB_EmergencyContact.Text,
            TB_Relationship.Text,
            TB_EmergencyPhone.Text,
            TB_Baneficiary.Text,
            TB_Costc.Text,
            AppUser,
            PhotoPath,
            CB_Status.Checked
        )

        Employee.EMPL_STAT = CB_Status.Checked

        If Employee.UpdateEmployee() Then

            MessageBox.Show("Empleado actualizado correctamente")

            InitializationOfFields()
            Display_Record()

        End If

    End Sub

    Private Sub DGV_AllEmployees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_AllEmployees.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DGV_AllEmployees.Rows(e.RowIndex)

        SelectedEmployeeID = CInt(row.Cells(0).Value)

        Dim Employee As New CL_Employee
        Dim EmployeeInfo As DataTable = Employee.Get_SelectedEmployeesIDInfo(SelectedEmployeeID)

        For Each Item As DataRow In EmployeeInfo.Rows

            TB_EmployeeName.Text = Item(1).ToString
            TB_LastName1.Text = Item(2).ToString
            TB_LastName2.Text = Item(3).ToString

            DT_BornDate.Value = CDate(Item(4))
            TB_BornCity.Text = Item(5).ToString
            TB_PersonalAddress.Text = Item(6).ToString
            TB_PhoneNumber.Text = Item(7).ToString
            TB_EmailAddress.Text = Item(8).ToString

            TB_CivilStatus.Text = Item(9).ToString
            TB_Curp.Text = Item(10).ToString
            TB_SocialNumber.Text = Item(11).ToString

            TB_RFC.Text = Item(12).ToString
            TB_FiscalAddress.Text = Item(13).ToString
            TB_BankName.Text = Item(14).ToString
            TB_BankAccount.Text = Item(15).ToString

            CB_Company.SelectedValue = Item(16)

            'TIPY EMPLOYEE
            Dim typeEmployee As Integer = CInt(Item(18))
            SelectComboById(CB_EmployeeType, typeEmployee)

            DT_EntryDate.Value = CDate(Item(19))
            DT_RegistrationDate.Value = CDate(Item(20))

            SelectComboById(CB_Position, CInt(Item(21)))
            SelectComboById(CB_Supervisor, CInt(Item(23)))

            TB_VacationsDays.Text = Item(25).ToString
            TB_BaseSalary.Text = Item(26).ToString
            SelectComboById(CB_Department, CInt(Item(27)))
            TB_EmergencyContact.Text = Item(28).ToString
            TB_Relationship.Text = Item(29).ToString
            TB_EmergencyPhone.Text = Item(30).ToString
            TB_Baneficiary.Text = Item(31).ToString
            TB_Costc.Text = Item(32).ToString

            If Not IsDBNull(Item(34)) Then

                Dim PhotoPath As String = Item(34).ToString

                If File.Exists(PhotoPath) Then
                    Using imgTemp As Image = Image.FromFile(PhotoPath)
                        PB_Picture.Image = New Bitmap(imgTemp)
                    End Using
                    PB_Picture.Tag = PhotoPath
                End If

            End If

            CB_Status.Checked = Item(35)

        Next

    End Sub

    Private Sub SelectComboById(combo As ComboBox, id As Integer)

        For Each item As ComboItem In combo.Items
            If item.Id = id Then
                combo.SelectedItem = item
                Exit For
            End If
        Next

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
End Class
