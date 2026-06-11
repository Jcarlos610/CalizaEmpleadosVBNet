Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

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

        CB_InfonavitCredit.Checked = False

        CB_Plant.Items.Clear()
        Dim PlantClass As New CL_Plants()
        Dim ListOfPlants As DataTable = PlantClass.Get_ListOfPlants()

        For Each Item As DataRow In ListOfPlants.Rows
            CB_Plant.Items.Add(New ComboItem With {
                .Id = CInt(Item(0)),
                .Descripcion = Item(1).ToString()
            })
        Next
        CB_Plant.DisplayMember = "Descripcion"
        CB_Plant.ValueMember = "Id"
        CB_Plant.SelectedIndex = 0

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
        Try
            If TB_EmployeeName.Text.Trim = "" Then
                MessageBox.Show("Favor de ingresar nombre(s) del empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If TB_LastName1.Text.Trim = "" Then
                MessageBox.Show("Favor de ingresar apellido paterno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If TB_LastName2.Text.Trim = "" Then
                MessageBox.Show("Favor de indicar apellido materno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DT_BornDate.Value = Date.Today Then
                MessageBox.Show("Favor de ingresar una fecha de nacimiento válida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not IsValidEmail(TB_EmailAddress.Text.Trim) Then
                MessageBox.Show("Ingrese una dirección de correo válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TB_EmailAddress.Focus()
                Exit Sub
            End If
            If CB_Company.SelectedItem Is Nothing Then
                MessageBox.Show("Favor de indicar a qué empresa será asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CB_EmployeeType.SelectedItem Is Nothing Then
                MessageBox.Show("Favor de indicar tipo de empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CB_Position.SelectedItem Is Nothing Then
                MessageBox.Show("Favor de seleccionar la posición a ocupar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CB_Department.SelectedItem Is Nothing Then
                MessageBox.Show("Favor de seleccionar un departamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim plantIdSelected As Integer = 0
            Dim plantDescription As String = "Sin Planta"

            If CB_Plant.SelectedItem IsNot Nothing Then
                If TypeOf CB_Plant.SelectedItem Is ComboItem Then
                    Dim itemPlanta As ComboItem = CType(CB_Plant.SelectedItem, ComboItem)
                    plantIdSelected = itemPlanta.Id
                    plantDescription = itemPlanta.Descripcion
                ElseIf TypeOf CB_Plant.SelectedItem Is DataRowView Then
                    plantIdSelected = CInt(CType(CB_Plant.SelectedItem, DataRowView)("PLANT_ID"))
                    plantDescription = CType(CB_Plant.SelectedItem, DataRowView)("PLANT_NAME").ToString()
                End If
            End If

            ' Validar cupo MÁXIMO únicamente si seleccionó una planta real (Mayor a 0)
            Dim empValidar As New CL_Employee()
            If plantIdSelected > 0 AndAlso Not empValidar.PlantaTieneCupo(plantIdSelected, 0) Then
                MessageBox.Show("No se puede asignar el empleado a esta planta. La planta seleccionada ya cuenta con el límite máximo de 2 empleados activos.",
                        "Límite de Planta Alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim Company As ComboItem = CType(CB_Company.SelectedItem, ComboItem)
            Dim TypeOfEmployee As ComboItem = CType(CB_EmployeeType.SelectedItem, ComboItem)
            Dim Positions As ComboItem = CType(CB_Position.SelectedItem, ComboItem)
            Dim Department As ComboItem = CType(CB_Department.SelectedItem, ComboItem)

            Dim Id_Supervisor As Integer = 0
            Dim Desc_Supervisor As String = "NINGUNO"
            If CB_Supervisor.SelectedItem IsNot Nothing Then
                Dim Supervisor As ComboItem = CType(CB_Supervisor.SelectedItem, ComboItem)
                Id_Supervisor = Supervisor.Id
                Desc_Supervisor = Supervisor.Descripcion
            End If

            Dim PhotoPath As String = Nothing
            If PB_Picture.Tag IsNot Nothing Then
                PhotoPath = PB_Picture.Tag.ToString()
            End If

            Dim nombreCompleto As String = $"{TB_EmployeeName.Text.Trim} {TB_LastName1.Text.Trim} {TB_LastName2.Text.Trim}"

            Dim Employee = New CL_Employee(
            TB_EmployeeName.Text.Trim,
            TB_LastName1.Text.Trim,
            TB_LastName2.Text.Trim,
            DT_BornDate.Value,
            TB_BornCity.Text.Trim,
            TB_PersonalAddress.Text.Trim,
            TB_PhoneNumber.Text.Trim,
            TB_EmailAddress.Text.Trim,
            TB_CivilStatus.Text.Trim,
            TB_Curp.Text.Trim,
            TB_SocialNumber.Text.Trim,
            TB_RFC.Text.Trim,
            TB_FiscalAddress.Text.Trim,
            TB_BankName.Text.Trim,
            TB_BankAccount.Text.Trim,
            Company.Id,
            TypeOfEmployee.Id,
            DT_EntryDate.Value,
            DT_RegistrationDate.Value,
            Positions.Id,
            Id_Supervisor,
            TB_VacationsDays.Text.Trim,
            TB_BaseSalary.Text.Trim,
            Department.Id,
            TB_EmergencyContact.Text.Trim,
            TB_Relationship.Text.Trim,
            TB_EmergencyPhone.Text.Trim,
            TB_Baneficiary.Text.Trim,
            TB_Costc.Text.Trim,
            GlobalSession.GlobalUserName,
            PhotoPath,
            1,
            CB_Confidential.Checked,
            plantIdSelected,
            CB_InfonavitCredit.Checked
        )


            If Employee.InsertEmployee() Then

                'LOG 
                Try
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim salarioLog As String = If(CB_Confidential.Checked, "[PROTEGIDO/CONFIDENCIAL]", $"${TB_BaseSalary.Text.Trim}")
                        Dim confidencialTxt As String = If(CB_Confidential.Checked, "SÍ", "NO")
                        Dim infonavitTxt As String = If(CB_InfonavitCredit.Checked, "SÍ TIENE CRÉDITO", "NO TIENE CRÉDITO")
                        Dim descExito As String = $"ALTA DE EMPLEADO: Se registró a '{nombreCompleto}' en la empresa '{Company.Descripcion}'. Planta Asignada: '{plantDescription}', Depto: {Department.Descripcion}, Puesto: {Positions.Descripcion}, Salario Base: {salarioLog}, Confidencial: [{confidencialTxt}], INFONAVIT: [{infonavitTxt}]."

                        InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Employees", "INSERT_EMPLOYEE_SUCCESS", descExito, 0, "INFO")
                    End Using
                Catch logEx As Exception
                    Console.WriteLine("No se pudo escribir el log de éxito: " & logEx.Message)
                End Try

                MessageBox.Show("El empleado " + TB_EmployeeName.Text.Trim + " fue creado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR 
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim nombreFalla As String = $"{TB_EmployeeName.Text.Trim} {TB_LastName1.Text.Trim}"
                    Dim descError As String = $"ERROR CRÍTICO: Falló la inserción del empleado '{nombreFalla}'. Motivo: {ex.Message}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Employees", "ERROR_INSERT_EMPLOYEE", descError, 0, "ERROR", ex.StackTrace)
                End Using
            Catch logEx As Exception
                Console.WriteLine("Error al intentar escribir log de excepción: " & logEx.Message)
            End Try

            MessageBox.Show("Ocurrió un error inesperado al registrar el empleado: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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


        Dim Employeeinfo As DataTable = report.Get_EmployeeInfoByUserName(AppUser)
        Dim ID_Depto As Integer
        For Each Line As DataRow In Employeeinfo.Rows
            ID_Depto = CInt(Line(27))
        Next

        If ID_Depto = 30 Or ID_Depto = 0 Then
            DGV_AllEmployees.DataSource = report.Get_AllEmployeesAllDepartments
        Else
            DGV_AllEmployees.DataSource = report.Get_AllEmployeesOnlyFewDepartments
        End If

        DGV_AllEmployees.Columns("Salario Inicial").Visible = False

        If DGV_AllEmployees.Columns.Contains("Planta") Then
            DGV_AllEmployees.Columns("Planta").HeaderText = "Planta Asignada"
        End If

    End Sub

End Class