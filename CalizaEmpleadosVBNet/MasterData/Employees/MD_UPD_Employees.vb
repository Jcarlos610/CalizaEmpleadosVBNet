Imports System.IO
Imports System.Net.Mail
Imports Microsoft.Data.SqlClient

Public Class MD_UPD_Employees

    Private SelectedEmployeeID As Integer = 0

    Private Original_Dept As String = ""
    Private Original_Pos As String = ""
    Private Original_Salary As String = ""
    Private Original_Status As Boolean = True
    Private Original_Plant As String = ""
    Private Original_Infonavit As Boolean = False

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

        CB_InfonavitCredit.Checked = False

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

        CB_Plant.Items.Clear()

        Dim Plants = New CL_Plants()
        Dim ListOfPlants As DataTable = Plants.Get_ListOfPlants()

        For Each Item As DataRow In ListOfPlants.Rows
            CB_Plant.Items.Add(New ComboItem With {
                .Id = CInt(Item(0)),
                .Descripcion = Item(1).ToString()
            })
        Next

        CB_Plant.DisplayMember = "Descripcion"
        CB_Plant.ValueMember = "Id"

        If CB_Plant.Items.Count > 0 Then
            CB_Plant.SelectedIndex = 0
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
        'Dim table As DataTable = report.Get_AllEmployees()

        'If table IsNot Nothing Then
        '    DGV_AllEmployees.DataSource = table
        'End If

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

        DGV_AllEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_AllEmployees.AutoResizeColumns()

    End Sub

    Private Sub MD_UPD_Employees_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ActiveControl = TB_EmployeeName
    End Sub


    Private Sub BT_EmployeeUpdate_Click(sender As Object, e As EventArgs) Handles BT_EmployeeUpdate.Click
        Try
            If SelectedEmployeeID = 0 Then
                MessageBox.Show("Seleccione un empleado para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If TB_EmployeeName.Text.Trim = "" OrElse TB_LastName1.Text.Trim = "" OrElse TB_LastName2.Text.Trim = "" Then
                MessageBox.Show("Favor de ingresar el nombre completo del empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not IsValidEmail(TB_EmailAddress.Text.Trim) Then
                MessageBox.Show("Ingrese un correo válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim companyID As Integer = CInt(CB_Company.SelectedValue)
            Dim typeEmployee As ComboItem = CType(CB_EmployeeType.SelectedItem, ComboItem)
            Dim position As ComboItem = CType(CB_Position.SelectedItem, ComboItem)
            Dim department As ComboItem = CType(CB_Department.SelectedItem, ComboItem)

            Dim plantIdSelected As Integer = 0
            If CB_Plant.SelectedItem IsNot Nothing Then
                If TypeOf CB_Plant.SelectedItem Is ComboItem Then
                    plantIdSelected = CType(CB_Plant.SelectedItem, ComboItem).Id
                End If
            End If


            If CB_Status.Checked AndAlso plantIdSelected > 0 Then
                Dim empValidar As New CL_Employee()
                If Not empValidar.PlantaTieneCupo(plantIdSelected, SelectedEmployeeID) Then
                    MessageBox.Show("No se pueden guardar los cambios. La planta seleccionada ya tiene asignados 2 empleados activos.",
                        "Límite de Planta Alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If


            Dim Id_Supervisor As Integer = 0
            If CB_Supervisor.SelectedItem IsNot Nothing Then
                Dim supervisor As ComboItem = CType(CB_Supervisor.SelectedItem, ComboItem)
                Id_Supervisor = supervisor.Id
            End If

            Dim PhotoPath As String = ""
            If PB_Picture.Tag IsNot Nothing Then
                PhotoPath = PB_Picture.Tag.ToString()
            End If

            Dim listaCambios As New List(Of String)()

            If Original_Dept <> CB_Department.Text Then
                listaCambios.Add($"Depto: de '{Original_Dept}' a '{CB_Department.Text}'")
            End If

            If Original_Pos <> CB_Position.Text Then
                listaCambios.Add($"Puesto: de '{Original_Pos}' a '{CB_Position.Text}'")
            End If

            If Original_Salary <> TB_BaseSalary.Text.Trim Then
                If CB_Confidential.Checked Then
                    listaCambios.Add("Salario: Modificado [VALOR PROTEGIDO POR CONFIDENCIALIDAD]")
                Else
                    listaCambios.Add($"Salario: de ${Original_Salary} a ${TB_BaseSalary.Text.Trim}")
                End If
            End If

            If Original_Plant <> CB_Plant.Text Then
                listaCambios.Add($"Planta: de '{Original_Plant}' a '{CB_Plant.Text}'")
            End If

            If Original_Status <> CB_Status.Checked Then
                Dim estAnt As String = If(Original_Status, "ACTIVO", "INACTIVO")
                Dim estNue As String = If(CB_Status.Checked, "ACTIVO", "INACTIVO")
                listaCambios.Add($"Estatus: de '{estAnt}' a '{estNue}'")
            End If

            If Original_Infonavit <> CB_InfonavitCredit.Checked Then
                Dim infAnt As String = If(Original_Infonavit, "SÍ TIENE CRÉDITO", "NO TIENE CRÉDITO")
                Dim infNue As String = If(CB_InfonavitCredit.Checked, "SÍ TIENE CRÉDITO", "NO TIENE CRÉDITO")
                listaCambios.Add($"INFONAVIT: de '{infAnt}' a '{infNue}'")
            End If

            Dim stringDetalleCambios As String = ""
            If listaCambios.Count > 0 Then
                stringDetalleCambios = "Cambios detectados -> " & String.Join(" | ", listaCambios) & "."
            Else
                stringDetalleCambios = "Actualización general sin cambios en campos estructurales."
            End If

            Dim Employee As New CL_Employee(
                SelectedEmployeeID,
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
                companyID,
                typeEmployee.Id,
                DT_EntryDate.Value,
                DT_RegistrationDate.Value,
                position.Id,
                Id_Supervisor,
                CDec(TB_VacationsDays.Text.Trim),
                TB_BaseSalary.Text.Trim,
                department.Id,
                TB_EmergencyContact.Text.Trim,
                TB_Relationship.Text.Trim,
                TB_EmergencyPhone.Text.Trim,
                TB_Baneficiary.Text.Trim,
                TB_Costc.Text.Trim,
                GlobalSession.GlobalUserName,
                PhotoPath,
                CB_Confidential.Checked,
                CB_Status.Checked,
                plantIdSelected,
                CB_InfonavitCredit.Checked
            )



            Employee.EMPL_STAT = CB_Status.Checked

            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim nombreCompleto As String = $"{TB_EmployeeName.Text.Trim} {TB_LastName1.Text.Trim} {TB_LastName2.Text.Trim}"
            Dim exitoActualizacion As Boolean = False
            Dim accionLog As String = ""

            If CB_Confidential.Checked Then
                If Employee.UpdateEmployeeWithoutSalary() Then
                    exitoActualizacion = True
                    accionLog = "UPDATE_EMPLOYEE_CONFIDENTIAL"
                End If
            Else
                If Employee.UpdateEmployee() Then
                    exitoActualizacion = True
                    accionLog = "UPDATE_EMPLOYEE_STANDARD"
                End If
            End If

            If exitoActualizacion Then
                Dim descFinalLog As String = $"MODIFICACIÓN EXPEDIENTE: El usuario editó al EMPL_ID: {SelectedEmployeeID} ('{nombreCompleto}'). {stringDetalleCambios}"

                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Employees", accionLog, descFinalLog, SelectedEmployeeID, "INFO")

                MessageBox.Show("Empleado actualizado correctamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
                Display_Record()
            Else
                Dim descWarn As String = $"RECHAZO EN BD: El procedimiento no aplicó cambios para el EMPL_ID: {SelectedEmployeeID}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Employees", "UPDATE_EMPLOYEE_FAILED", descWarn, SelectedEmployeeID, "WARNING")
            End If

        Catch ex As Exception
            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim descError As String = $"ERROR CRÍTICO: Falló el guardado del formulario de edición del EMPL_ID: {SelectedEmployeeID}. Motivo: {ex.Message}"

            InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Employees", "ERROR_UPDATE_EMPLOYEE", descError, SelectedEmployeeID, "ERROR", ex.StackTrace)

            MessageBox.Show("Ocurrió un error inesperado al actualizar el expediente: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DGV_AllEmployees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_AllEmployees.CellClick


        TB_BaseSalary.Text = ""

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
            If IsDBNull(Item(36)) Then
                TB_BaseSalary.Text = Item(26).ToString
                CB_Confidential.Checked = False
            Else
                TB_BaseSalary.Text = "******"
                CB_Confidential.Checked = True
            End If

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


            If Not IsDBNull(Item(37)) Then
                SelectComboById(CB_Plant, CInt(Item(37)))
            Else
                CB_Plant.SelectedIndex = 0
            End If

            If Not IsDBNull(Item(38)) Then
                CB_InfonavitCredit.Checked = CBool(Item(38))
            Else
                CB_InfonavitCredit.Checked = False
            End If

            Original_Dept = CB_Department.Text
            Original_Pos = CB_Position.Text
            Original_Salary = TB_BaseSalary.Text.Trim
            Original_Status = CB_Status.Checked
            Original_Plant = CB_Plant.Text
            Original_Infonavit = CB_InfonavitCredit.Checked

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
