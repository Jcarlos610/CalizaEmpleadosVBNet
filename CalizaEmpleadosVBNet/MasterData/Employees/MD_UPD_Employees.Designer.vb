<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MD_UPD_Employees
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        GB_PersonalInformation = New GroupBox()
        CB_Status = New CheckBox()
        BT_EmployeeUpdate = New Button()
        TB_SocialNumber = New TextBox()
        GB_EmergencyInfo = New GroupBox()
        TB_Baneficiary = New TextBox()
        LB_Beneficiary = New Label()
        LB_EmergencyContact = New Label()
        LB_RelationShip = New Label()
        TB_EmergencyPhone = New TextBox()
        LB_PhoneNumber2 = New Label()
        TB_Relationship = New TextBox()
        TB_EmergencyContact = New TextBox()
        LB_SocialSecurityNumber = New Label()
        GB_EmployeeInformation = New GroupBox()
        TB_Costc = New TextBox()
        Label2 = New Label()
        CB_Department = New ComboBox()
        Label1 = New Label()
        CB_Position = New ComboBox()
        LB_Position = New Label()
        CB_Supervisor = New ComboBox()
        LB_Supervisor = New Label()
        TB_BaseSalary = New TextBox()
        TB_VacationsDays = New TextBox()
        DT_RegistrationDate = New DateTimePicker()
        DT_EntryDate = New DateTimePicker()
        LB_Salary = New Label()
        LB_VacationDays = New Label()
        CB_EmployeeType = New ComboBox()
        LB_EmployeeType = New Label()
        LB_RegisterDate = New Label()
        LB_EntryDate = New Label()
        LB_Company = New Label()
        CB_Company = New ComboBox()
        TB_Curp = New TextBox()
        GB_FiscalInformation = New GroupBox()
        TB_BankAccount = New TextBox()
        TB_BankName = New TextBox()
        LB_BankAccount = New Label()
        LB_BankName = New Label()
        TB_FiscalAddress = New TextBox()
        TB_RFC = New TextBox()
        LB_FiscalAddress = New Label()
        LB_RFC = New Label()
        TB_CivilStatus = New TextBox()
        TB_EmailAddress = New TextBox()
        TB_PhoneNumber = New TextBox()
        TB_PersonalAddress = New TextBox()
        TB_BornCity = New TextBox()
        DT_BornDate = New DateTimePicker()
        TB_LastName2 = New TextBox()
        TB_LastName1 = New TextBox()
        TB_EmployeeName = New TextBox()
        LB_Curp = New Label()
        LB_CivilStatus = New Label()
        LB_Email = New Label()
        LB_PhoneNumber = New Label()
        LB_Adress = New Label()
        LB_Picture = New Label()
        LB_BornCity = New Label()
        LB_BirthDate = New Label()
        LB_LastName2 = New Label()
        LB_LastName = New Label()
        BT_Picture = New Button()
        LB_EmployeeName = New Label()
        PB_Picture = New PictureBox()
        GroupBox1 = New GroupBox()
        DGV_AllEmployees = New DataGridView()
        LB_Title = New Label()
        GB_PersonalInformation.SuspendLayout()
        GB_EmergencyInfo.SuspendLayout()
        GB_EmployeeInformation.SuspendLayout()
        GB_FiscalInformation.SuspendLayout()
        CType(PB_Picture, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(DGV_AllEmployees, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_PersonalInformation
        ' 
        GB_PersonalInformation.Controls.Add(CB_Status)
        GB_PersonalInformation.Controls.Add(BT_EmployeeUpdate)
        GB_PersonalInformation.Controls.Add(TB_SocialNumber)
        GB_PersonalInformation.Controls.Add(GB_EmergencyInfo)
        GB_PersonalInformation.Controls.Add(LB_SocialSecurityNumber)
        GB_PersonalInformation.Controls.Add(GB_EmployeeInformation)
        GB_PersonalInformation.Controls.Add(TB_Curp)
        GB_PersonalInformation.Controls.Add(GB_FiscalInformation)
        GB_PersonalInformation.Controls.Add(TB_CivilStatus)
        GB_PersonalInformation.Controls.Add(TB_EmailAddress)
        GB_PersonalInformation.Controls.Add(TB_PhoneNumber)
        GB_PersonalInformation.Controls.Add(TB_PersonalAddress)
        GB_PersonalInformation.Controls.Add(TB_BornCity)
        GB_PersonalInformation.Controls.Add(DT_BornDate)
        GB_PersonalInformation.Controls.Add(TB_LastName2)
        GB_PersonalInformation.Controls.Add(TB_LastName1)
        GB_PersonalInformation.Controls.Add(TB_EmployeeName)
        GB_PersonalInformation.Controls.Add(LB_Curp)
        GB_PersonalInformation.Controls.Add(LB_CivilStatus)
        GB_PersonalInformation.Controls.Add(LB_Email)
        GB_PersonalInformation.Controls.Add(LB_PhoneNumber)
        GB_PersonalInformation.Controls.Add(LB_Adress)
        GB_PersonalInformation.Controls.Add(LB_Picture)
        GB_PersonalInformation.Controls.Add(LB_BornCity)
        GB_PersonalInformation.Controls.Add(LB_BirthDate)
        GB_PersonalInformation.Controls.Add(LB_LastName2)
        GB_PersonalInformation.Controls.Add(LB_LastName)
        GB_PersonalInformation.Controls.Add(BT_Picture)
        GB_PersonalInformation.Controls.Add(LB_EmployeeName)
        GB_PersonalInformation.Controls.Add(PB_Picture)
        GB_PersonalInformation.Location = New Point(17, 413)
        GB_PersonalInformation.Margin = New Padding(4, 5, 4, 5)
        GB_PersonalInformation.Name = "GB_PersonalInformation"
        GB_PersonalInformation.Padding = New Padding(4, 5, 4, 5)
        GB_PersonalInformation.Size = New Size(1783, 863)
        GB_PersonalInformation.TabIndex = 101
        GB_PersonalInformation.TabStop = False
        GB_PersonalInformation.Text = "Información personal"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(1673, 24)
        CB_Status.Margin = New Padding(4, 5, 4, 5)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(86, 29)
        CB_Status.TabIndex = 408
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' BT_EmployeeUpdate
        ' 
        BT_EmployeeUpdate.Location = New Point(1573, 785)
        BT_EmployeeUpdate.Margin = New Padding(4, 5, 4, 5)
        BT_EmployeeUpdate.Name = "BT_EmployeeUpdate"
        BT_EmployeeUpdate.Size = New Size(186, 42)
        BT_EmployeeUpdate.TabIndex = 407
        BT_EmployeeUpdate.Text = "Actualizar Empleado"
        BT_EmployeeUpdate.UseVisualStyleBackColor = True
        ' 
        ' TB_SocialNumber
        ' 
        TB_SocialNumber.Location = New Point(874, 247)
        TB_SocialNumber.Margin = New Padding(4, 5, 4, 5)
        TB_SocialNumber.Name = "TB_SocialNumber"
        TB_SocialNumber.Size = New Size(311, 31)
        TB_SocialNumber.TabIndex = 125
        ' 
        ' GB_EmergencyInfo
        ' 
        GB_EmergencyInfo.Controls.Add(TB_Baneficiary)
        GB_EmergencyInfo.Controls.Add(LB_Beneficiary)
        GB_EmergencyInfo.Controls.Add(LB_EmergencyContact)
        GB_EmergencyInfo.Controls.Add(LB_RelationShip)
        GB_EmergencyInfo.Controls.Add(TB_EmergencyPhone)
        GB_EmergencyInfo.Controls.Add(LB_PhoneNumber2)
        GB_EmergencyInfo.Controls.Add(TB_Relationship)
        GB_EmergencyInfo.Controls.Add(TB_EmergencyContact)
        GB_EmergencyInfo.Location = New Point(33, 693)
        GB_EmergencyInfo.Margin = New Padding(4, 5, 4, 5)
        GB_EmergencyInfo.Name = "GB_EmergencyInfo"
        GB_EmergencyInfo.Padding = New Padding(4, 5, 4, 5)
        GB_EmergencyInfo.Size = New Size(1491, 133)
        GB_EmergencyInfo.TabIndex = 400
        GB_EmergencyInfo.TabStop = False
        GB_EmergencyInfo.Text = "Contacto de emergencia"
        ' 
        ' TB_Baneficiary
        ' 
        TB_Baneficiary.Location = New Point(969, 68)
        TB_Baneficiary.Margin = New Padding(4, 5, 4, 5)
        TB_Baneficiary.Name = "TB_Baneficiary"
        TB_Baneficiary.Size = New Size(487, 31)
        TB_Baneficiary.TabIndex = 408
        ' 
        ' LB_Beneficiary
        ' 
        LB_Beneficiary.AutoSize = True
        LB_Beneficiary.Location = New Point(969, 40)
        LB_Beneficiary.Margin = New Padding(4, 0, 4, 0)
        LB_Beneficiary.Name = "LB_Beneficiary"
        LB_Beneficiary.Size = New Size(199, 25)
        LB_Beneficiary.TabIndex = 407
        LB_Beneficiary.Text = "Nombre de beneficiario"
        ' 
        ' LB_EmergencyContact
        ' 
        LB_EmergencyContact.AutoSize = True
        LB_EmergencyContact.Location = New Point(34, 40)
        LB_EmergencyContact.Margin = New Padding(4, 0, 4, 0)
        LB_EmergencyContact.Name = "LB_EmergencyContact"
        LB_EmergencyContact.Size = New Size(205, 25)
        LB_EmergencyContact.TabIndex = 401
        LB_EmergencyContact.Text = "Contacto de emergencia"
        ' 
        ' LB_RelationShip
        ' 
        LB_RelationShip.AutoSize = True
        LB_RelationShip.Location = New Point(499, 40)
        LB_RelationShip.Margin = New Padding(4, 0, 4, 0)
        LB_RelationShip.Name = "LB_RelationShip"
        LB_RelationShip.Size = New Size(97, 25)
        LB_RelationShip.TabIndex = 403
        LB_RelationShip.Text = "Parentesco"
        ' 
        ' TB_EmergencyPhone
        ' 
        TB_EmergencyPhone.Location = New Point(709, 68)
        TB_EmergencyPhone.Margin = New Padding(4, 5, 4, 5)
        TB_EmergencyPhone.Name = "TB_EmergencyPhone"
        TB_EmergencyPhone.Size = New Size(240, 31)
        TB_EmergencyPhone.TabIndex = 406
        ' 
        ' LB_PhoneNumber2
        ' 
        LB_PhoneNumber2.AutoSize = True
        LB_PhoneNumber2.Location = New Point(710, 40)
        LB_PhoneNumber2.Margin = New Padding(4, 0, 4, 0)
        LB_PhoneNumber2.Name = "LB_PhoneNumber2"
        LB_PhoneNumber2.Size = New Size(178, 25)
        LB_PhoneNumber2.TabIndex = 405
        LB_PhoneNumber2.Text = "Teléfono de contacto"
        ' 
        ' TB_Relationship
        ' 
        TB_Relationship.Location = New Point(497, 68)
        TB_Relationship.Margin = New Padding(4, 5, 4, 5)
        TB_Relationship.Name = "TB_Relationship"
        TB_Relationship.Size = New Size(184, 31)
        TB_Relationship.TabIndex = 404
        ' 
        ' TB_EmergencyContact
        ' 
        TB_EmergencyContact.Location = New Point(33, 68)
        TB_EmergencyContact.Margin = New Padding(4, 5, 4, 5)
        TB_EmergencyContact.Name = "TB_EmergencyContact"
        TB_EmergencyContact.Size = New Size(438, 31)
        TB_EmergencyContact.TabIndex = 402
        ' 
        ' LB_SocialSecurityNumber
        ' 
        LB_SocialSecurityNumber.AutoSize = True
        LB_SocialSecurityNumber.Location = New Point(874, 218)
        LB_SocialSecurityNumber.Margin = New Padding(4, 0, 4, 0)
        LB_SocialSecurityNumber.Name = "LB_SocialSecurityNumber"
        LB_SocialSecurityNumber.Size = New Size(287, 25)
        LB_SocialSecurityNumber.TabIndex = 124
        LB_SocialSecurityNumber.Text = "Numero de Seguridad Social (NSS)"
        ' 
        ' GB_EmployeeInformation
        ' 
        GB_EmployeeInformation.Controls.Add(TB_Costc)
        GB_EmployeeInformation.Controls.Add(Label2)
        GB_EmployeeInformation.Controls.Add(CB_Department)
        GB_EmployeeInformation.Controls.Add(Label1)
        GB_EmployeeInformation.Controls.Add(CB_Position)
        GB_EmployeeInformation.Controls.Add(LB_Position)
        GB_EmployeeInformation.Controls.Add(CB_Supervisor)
        GB_EmployeeInformation.Controls.Add(LB_Supervisor)
        GB_EmployeeInformation.Controls.Add(TB_BaseSalary)
        GB_EmployeeInformation.Controls.Add(TB_VacationsDays)
        GB_EmployeeInformation.Controls.Add(DT_RegistrationDate)
        GB_EmployeeInformation.Controls.Add(DT_EntryDate)
        GB_EmployeeInformation.Controls.Add(LB_Salary)
        GB_EmployeeInformation.Controls.Add(LB_VacationDays)
        GB_EmployeeInformation.Controls.Add(CB_EmployeeType)
        GB_EmployeeInformation.Controls.Add(LB_EmployeeType)
        GB_EmployeeInformation.Controls.Add(LB_RegisterDate)
        GB_EmployeeInformation.Controls.Add(LB_EntryDate)
        GB_EmployeeInformation.Controls.Add(LB_Company)
        GB_EmployeeInformation.Controls.Add(CB_Company)
        GB_EmployeeInformation.Location = New Point(33, 477)
        GB_EmployeeInformation.Margin = New Padding(4, 5, 4, 5)
        GB_EmployeeInformation.Name = "GB_EmployeeInformation"
        GB_EmployeeInformation.Padding = New Padding(4, 5, 4, 5)
        GB_EmployeeInformation.Size = New Size(1726, 208)
        GB_EmployeeInformation.TabIndex = 300
        GB_EmployeeInformation.TabStop = False
        GB_EmployeeInformation.Text = "Información de empleado"
        ' 
        ' TB_Costc
        ' 
        TB_Costc.Location = New Point(1383, 143)
        TB_Costc.Margin = New Padding(4, 5, 4, 5)
        TB_Costc.Name = "TB_Costc"
        TB_Costc.Size = New Size(153, 31)
        TB_Costc.TabIndex = 412
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(1377, 115)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(147, 25)
        Label2.TabIndex = 411
        Label2.Text = "Centro de costos"
        ' 
        ' CB_Department
        ' 
        CB_Department.FormattingEnabled = True
        CB_Department.Location = New Point(1502, 63)
        CB_Department.Margin = New Padding(4, 5, 4, 5)
        CB_Department.Name = "CB_Department"
        CB_Department.Size = New Size(201, 33)
        CB_Department.TabIndex = 410
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(1502, 35)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(127, 25)
        Label1.TabIndex = 409
        Label1.Text = "Departamento"
        ' 
        ' CB_Position
        ' 
        CB_Position.FormattingEnabled = True
        CB_Position.Location = New Point(33, 143)
        CB_Position.Margin = New Padding(4, 5, 4, 5)
        CB_Position.Name = "CB_Position"
        CB_Position.Size = New Size(475, 33)
        CB_Position.TabIndex = 310
        ' 
        ' LB_Position
        ' 
        LB_Position.AutoSize = True
        LB_Position.Location = New Point(34, 115)
        LB_Position.Margin = New Padding(4, 0, 4, 0)
        LB_Position.Name = "LB_Position"
        LB_Position.Size = New Size(183, 25)
        LB_Position.TabIndex = 309
        LB_Position.Text = "Puesto a desempeñar"
        ' 
        ' CB_Supervisor
        ' 
        CB_Supervisor.FormattingEnabled = True
        CB_Supervisor.Location = New Point(533, 143)
        CB_Supervisor.Margin = New Padding(4, 5, 4, 5)
        CB_Supervisor.Name = "CB_Supervisor"
        CB_Supervisor.Size = New Size(475, 33)
        CB_Supervisor.TabIndex = 312
        ' 
        ' LB_Supervisor
        ' 
        LB_Supervisor.AutoSize = True
        LB_Supervisor.Location = New Point(534, 115)
        LB_Supervisor.Margin = New Padding(4, 0, 4, 0)
        LB_Supervisor.Name = "LB_Supervisor"
        LB_Supervisor.Size = New Size(79, 25)
        LB_Supervisor.TabIndex = 311
        LB_Supervisor.Text = "Superior"
        ' 
        ' TB_BaseSalary
        ' 
        TB_BaseSalary.BackColor = SystemColors.Info
        TB_BaseSalary.Location = New Point(1220, 143)
        TB_BaseSalary.Margin = New Padding(4, 5, 4, 5)
        TB_BaseSalary.Name = "TB_BaseSalary"
        TB_BaseSalary.Size = New Size(141, 31)
        TB_BaseSalary.TabIndex = 316
        ' 
        ' TB_VacationsDays
        ' 
        TB_VacationsDays.Location = New Point(1033, 143)
        TB_VacationsDays.Margin = New Padding(4, 5, 4, 5)
        TB_VacationsDays.Name = "TB_VacationsDays"
        TB_VacationsDays.Size = New Size(153, 31)
        TB_VacationsDays.TabIndex = 314
        ' 
        ' DT_RegistrationDate
        ' 
        DT_RegistrationDate.Location = New Point(1144, 63)
        DT_RegistrationDate.Margin = New Padding(4, 5, 4, 5)
        DT_RegistrationDate.Name = "DT_RegistrationDate"
        DT_RegistrationDate.Size = New Size(327, 31)
        DT_RegistrationDate.TabIndex = 308
        ' 
        ' DT_EntryDate
        ' 
        DT_EntryDate.Location = New Point(787, 63)
        DT_EntryDate.Margin = New Padding(4, 5, 4, 5)
        DT_EntryDate.Name = "DT_EntryDate"
        DT_EntryDate.Size = New Size(325, 31)
        DT_EntryDate.TabIndex = 306
        ' 
        ' LB_Salary
        ' 
        LB_Salary.AutoSize = True
        LB_Salary.Location = New Point(1221, 115)
        LB_Salary.Margin = New Padding(4, 0, 4, 0)
        LB_Salary.Name = "LB_Salary"
        LB_Salary.Size = New Size(107, 25)
        LB_Salary.TabIndex = 315
        LB_Salary.Text = "Salario base"
        ' 
        ' LB_VacationDays
        ' 
        LB_VacationDays.AutoSize = True
        LB_VacationDays.Location = New Point(1037, 115)
        LB_VacationDays.Margin = New Padding(4, 0, 4, 0)
        LB_VacationDays.Name = "LB_VacationDays"
        LB_VacationDays.Size = New Size(161, 25)
        LB_VacationDays.TabIndex = 313
        LB_VacationDays.Text = "Días de vacaciones"
        ' 
        ' CB_EmployeeType
        ' 
        CB_EmployeeType.FormattingEnabled = True
        CB_EmployeeType.Location = New Point(533, 63)
        CB_EmployeeType.Margin = New Padding(4, 5, 4, 5)
        CB_EmployeeType.Name = "CB_EmployeeType"
        CB_EmployeeType.Size = New Size(228, 33)
        CB_EmployeeType.TabIndex = 304
        ' 
        ' LB_EmployeeType
        ' 
        LB_EmployeeType.AutoSize = True
        LB_EmployeeType.Location = New Point(534, 35)
        LB_EmployeeType.Margin = New Padding(4, 0, 4, 0)
        LB_EmployeeType.Name = "LB_EmployeeType"
        LB_EmployeeType.Size = New Size(157, 25)
        LB_EmployeeType.TabIndex = 303
        LB_EmployeeType.Text = "Tipo de empleado"
        ' 
        ' LB_RegisterDate
        ' 
        LB_RegisterDate.AutoSize = True
        LB_RegisterDate.Location = New Point(1146, 35)
        LB_RegisterDate.Margin = New Padding(4, 0, 4, 0)
        LB_RegisterDate.Name = "LB_RegisterDate"
        LB_RegisterDate.Size = New Size(251, 25)
        LB_RegisterDate.TabIndex = 307
        LB_RegisterDate.Text = "Fecha de registro ante el IMSS"
        ' 
        ' LB_EntryDate
        ' 
        LB_EntryDate.AutoSize = True
        LB_EntryDate.Location = New Point(789, 35)
        LB_EntryDate.Margin = New Padding(4, 0, 4, 0)
        LB_EntryDate.Name = "LB_EntryDate"
        LB_EntryDate.Size = New Size(147, 25)
        LB_EntryDate.TabIndex = 305
        LB_EntryDate.Text = "Fecha de Ingreso"
        ' 
        ' LB_Company
        ' 
        LB_Company.AutoSize = True
        LB_Company.Location = New Point(34, 35)
        LB_Company.Margin = New Padding(4, 0, 4, 0)
        LB_Company.Name = "LB_Company"
        LB_Company.Size = New Size(80, 25)
        LB_Company.TabIndex = 301
        LB_Company.Text = "Empresa"
        ' 
        ' CB_Company
        ' 
        CB_Company.FormattingEnabled = True
        CB_Company.Location = New Point(33, 63)
        CB_Company.Margin = New Padding(4, 5, 4, 5)
        CB_Company.Name = "CB_Company"
        CB_Company.Size = New Size(475, 33)
        CB_Company.TabIndex = 302
        ' 
        ' TB_Curp
        ' 
        TB_Curp.Location = New Point(601, 247)
        TB_Curp.Margin = New Padding(4, 5, 4, 5)
        TB_Curp.Name = "TB_Curp"
        TB_Curp.Size = New Size(247, 31)
        TB_Curp.TabIndex = 123
        ' 
        ' GB_FiscalInformation
        ' 
        GB_FiscalInformation.Controls.Add(TB_BankAccount)
        GB_FiscalInformation.Controls.Add(TB_BankName)
        GB_FiscalInformation.Controls.Add(LB_BankAccount)
        GB_FiscalInformation.Controls.Add(LB_BankName)
        GB_FiscalInformation.Controls.Add(TB_FiscalAddress)
        GB_FiscalInformation.Controls.Add(TB_RFC)
        GB_FiscalInformation.Controls.Add(LB_FiscalAddress)
        GB_FiscalInformation.Controls.Add(LB_RFC)
        GB_FiscalInformation.Location = New Point(33, 337)
        GB_FiscalInformation.Margin = New Padding(4, 5, 4, 5)
        GB_FiscalInformation.Name = "GB_FiscalInformation"
        GB_FiscalInformation.Padding = New Padding(4, 5, 4, 5)
        GB_FiscalInformation.Size = New Size(1726, 132)
        GB_FiscalInformation.TabIndex = 200
        GB_FiscalInformation.TabStop = False
        GB_FiscalInformation.Text = "Información Fiscal"
        ' 
        ' TB_BankAccount
        ' 
        TB_BankAccount.Location = New Point(1243, 68)
        TB_BankAccount.Margin = New Padding(4, 5, 4, 5)
        TB_BankAccount.Name = "TB_BankAccount"
        TB_BankAccount.Size = New Size(404, 31)
        TB_BankAccount.TabIndex = 208
        ' 
        ' TB_BankName
        ' 
        TB_BankName.Location = New Point(809, 68)
        TB_BankName.Margin = New Padding(4, 5, 4, 5)
        TB_BankName.Name = "TB_BankName"
        TB_BankName.Size = New Size(411, 31)
        TB_BankName.TabIndex = 206
        ' 
        ' LB_BankAccount
        ' 
        LB_BankAccount.AutoSize = True
        LB_BankAccount.Location = New Point(1244, 40)
        LB_BankAccount.Margin = New Padding(4, 0, 4, 0)
        LB_BankAccount.Name = "LB_BankAccount"
        LB_BankAccount.Size = New Size(159, 25)
        LB_BankAccount.TabIndex = 207
        LB_BankAccount.Text = "Número de cuenta"
        ' 
        ' LB_BankName
        ' 
        LB_BankName.AutoSize = True
        LB_BankName.Location = New Point(810, 40)
        LB_BankName.Margin = New Padding(4, 0, 4, 0)
        LB_BankName.Name = "LB_BankName"
        LB_BankName.Size = New Size(157, 25)
        LB_BankName.TabIndex = 205
        LB_BankName.Text = "Nombre de banco"
        ' 
        ' TB_FiscalAddress
        ' 
        TB_FiscalAddress.Location = New Point(296, 68)
        TB_FiscalAddress.Margin = New Padding(4, 5, 4, 5)
        TB_FiscalAddress.Name = "TB_FiscalAddress"
        TB_FiscalAddress.Size = New Size(483, 31)
        TB_FiscalAddress.TabIndex = 204
        ' 
        ' TB_RFC
        ' 
        TB_RFC.Location = New Point(33, 68)
        TB_RFC.Margin = New Padding(4, 5, 4, 5)
        TB_RFC.Name = "TB_RFC"
        TB_RFC.Size = New Size(241, 31)
        TB_RFC.TabIndex = 202
        ' 
        ' LB_FiscalAddress
        ' 
        LB_FiscalAddress.AutoSize = True
        LB_FiscalAddress.Location = New Point(297, 40)
        LB_FiscalAddress.Margin = New Padding(4, 0, 4, 0)
        LB_FiscalAddress.Name = "LB_FiscalAddress"
        LB_FiscalAddress.Size = New Size(132, 25)
        LB_FiscalAddress.TabIndex = 203
        LB_FiscalAddress.Text = "Dirección Fiscal"
        ' 
        ' LB_RFC
        ' 
        LB_RFC.AutoSize = True
        LB_RFC.Location = New Point(34, 40)
        LB_RFC.Margin = New Padding(4, 0, 4, 0)
        LB_RFC.Name = "LB_RFC"
        LB_RFC.Size = New Size(43, 25)
        LB_RFC.TabIndex = 201
        LB_RFC.Text = "RFC"
        ' 
        ' TB_CivilStatus
        ' 
        TB_CivilStatus.Location = New Point(371, 247)
        TB_CivilStatus.Margin = New Padding(4, 5, 4, 5)
        TB_CivilStatus.Name = "TB_CivilStatus"
        TB_CivilStatus.Size = New Size(200, 31)
        TB_CivilStatus.TabIndex = 121
        ' 
        ' TB_EmailAddress
        ' 
        TB_EmailAddress.Location = New Point(1416, 167)
        TB_EmailAddress.Margin = New Padding(4, 5, 4, 5)
        TB_EmailAddress.Name = "TB_EmailAddress"
        TB_EmailAddress.Size = New Size(341, 31)
        TB_EmailAddress.TabIndex = 119
        ' 
        ' TB_PhoneNumber
        ' 
        TB_PhoneNumber.Location = New Point(1177, 167)
        TB_PhoneNumber.Margin = New Padding(4, 5, 4, 5)
        TB_PhoneNumber.Name = "TB_PhoneNumber"
        TB_PhoneNumber.Size = New Size(228, 31)
        TB_PhoneNumber.TabIndex = 117
        ' 
        ' TB_PersonalAddress
        ' 
        TB_PersonalAddress.Location = New Point(681, 167)
        TB_PersonalAddress.Margin = New Padding(4, 5, 4, 5)
        TB_PersonalAddress.Name = "TB_PersonalAddress"
        TB_PersonalAddress.Size = New Size(481, 31)
        TB_PersonalAddress.TabIndex = 115
        ' 
        ' TB_BornCity
        ' 
        TB_BornCity.Location = New Point(367, 167)
        TB_BornCity.Margin = New Padding(4, 5, 4, 5)
        TB_BornCity.Name = "TB_BornCity"
        TB_BornCity.Size = New Size(288, 31)
        TB_BornCity.TabIndex = 113
        ' 
        ' DT_BornDate
        ' 
        DT_BornDate.Location = New Point(1343, 87)
        DT_BornDate.Margin = New Padding(4, 5, 4, 5)
        DT_BornDate.Name = "DT_BornDate"
        DT_BornDate.Size = New Size(331, 31)
        DT_BornDate.TabIndex = 111
        ' 
        ' TB_LastName2
        ' 
        TB_LastName2.Location = New Point(1016, 87)
        TB_LastName2.Margin = New Padding(4, 5, 4, 5)
        TB_LastName2.Name = "TB_LastName2"
        TB_LastName2.Size = New Size(304, 31)
        TB_LastName2.TabIndex = 109
        ' 
        ' TB_LastName1
        ' 
        TB_LastName1.Location = New Point(709, 87)
        TB_LastName1.Margin = New Padding(4, 5, 4, 5)
        TB_LastName1.Name = "TB_LastName1"
        TB_LastName1.Size = New Size(284, 31)
        TB_LastName1.TabIndex = 107
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(367, 87)
        TB_EmployeeName.Margin = New Padding(4, 5, 4, 5)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.Size = New Size(311, 31)
        TB_EmployeeName.TabIndex = 105
        ' 
        ' LB_Curp
        ' 
        LB_Curp.AutoSize = True
        LB_Curp.Location = New Point(601, 218)
        LB_Curp.Margin = New Padding(4, 0, 4, 0)
        LB_Curp.Name = "LB_Curp"
        LB_Curp.Size = New Size(56, 25)
        LB_Curp.TabIndex = 122
        LB_Curp.Text = "CURP"
        ' 
        ' LB_CivilStatus
        ' 
        LB_CivilStatus.AutoSize = True
        LB_CivilStatus.Location = New Point(371, 218)
        LB_CivilStatus.Margin = New Padding(4, 0, 4, 0)
        LB_CivilStatus.Name = "LB_CivilStatus"
        LB_CivilStatus.Size = New Size(103, 25)
        LB_CivilStatus.TabIndex = 120
        LB_CivilStatus.Text = "Estado Civil"
        ' 
        ' LB_Email
        ' 
        LB_Email.AutoSize = True
        LB_Email.Location = New Point(1410, 138)
        LB_Email.Margin = New Padding(4, 0, 4, 0)
        LB_Email.Name = "LB_Email"
        LB_Email.Size = New Size(157, 25)
        LB_Email.TabIndex = 118
        LB_Email.Text = "Correo Electrónico"
        ' 
        ' LB_PhoneNumber
        ' 
        LB_PhoneNumber.AutoSize = True
        LB_PhoneNumber.Location = New Point(1179, 138)
        LB_PhoneNumber.Margin = New Padding(4, 0, 4, 0)
        LB_PhoneNumber.Name = "LB_PhoneNumber"
        LB_PhoneNumber.Size = New Size(79, 25)
        LB_PhoneNumber.TabIndex = 116
        LB_PhoneNumber.Text = "Teléfono"
        ' 
        ' LB_Adress
        ' 
        LB_Adress.AutoSize = True
        LB_Adress.Location = New Point(681, 138)
        LB_Adress.Margin = New Padding(4, 0, 4, 0)
        LB_Adress.Name = "LB_Adress"
        LB_Adress.Size = New Size(163, 25)
        LB_Adress.TabIndex = 114
        LB_Adress.Text = "Dirección particular"
        ' 
        ' LB_Picture
        ' 
        LB_Picture.AutoSize = True
        LB_Picture.Location = New Point(34, 58)
        LB_Picture.Margin = New Padding(4, 0, 4, 0)
        LB_Picture.Name = "LB_Picture"
        LB_Picture.Size = New Size(159, 25)
        LB_Picture.TabIndex = 101
        LB_Picture.Text = "Foto de empleado"
        ' 
        ' LB_BornCity
        ' 
        LB_BornCity.AutoSize = True
        LB_BornCity.Location = New Point(369, 138)
        LB_BornCity.Margin = New Padding(4, 0, 4, 0)
        LB_BornCity.Name = "LB_BornCity"
        LB_BornCity.Size = New Size(173, 25)
        LB_BornCity.TabIndex = 112
        LB_BornCity.Text = "Lugar de nacimiento"
        ' 
        ' LB_BirthDate
        ' 
        LB_BirthDate.AutoSize = True
        LB_BirthDate.Location = New Point(1344, 58)
        LB_BirthDate.Margin = New Padding(4, 0, 4, 0)
        LB_BirthDate.Name = "LB_BirthDate"
        LB_BirthDate.Size = New Size(177, 25)
        LB_BirthDate.TabIndex = 110
        LB_BirthDate.Text = "Fecha de Nacimiento"
        ' 
        ' LB_LastName2
        ' 
        LB_LastName2.AutoSize = True
        LB_LastName2.Location = New Point(1017, 58)
        LB_LastName2.Margin = New Padding(4, 0, 4, 0)
        LB_LastName2.Name = "LB_LastName2"
        LB_LastName2.Size = New Size(143, 25)
        LB_LastName2.TabIndex = 108
        LB_LastName2.Text = "Apellido Paterno"
        ' 
        ' LB_LastName
        ' 
        LB_LastName.AutoSize = True
        LB_LastName.Location = New Point(710, 58)
        LB_LastName.Margin = New Padding(4, 0, 4, 0)
        LB_LastName.Name = "LB_LastName"
        LB_LastName.Size = New Size(150, 25)
        LB_LastName.TabIndex = 106
        LB_LastName.Text = "Apellido Materno"
        ' 
        ' BT_Picture
        ' 
        BT_Picture.Location = New Point(220, 270)
        BT_Picture.Margin = New Padding(4, 5, 4, 5)
        BT_Picture.Name = "BT_Picture"
        BT_Picture.Size = New Size(126, 38)
        BT_Picture.TabIndex = 103
        BT_Picture.Text = "Importar..."
        BT_Picture.UseVisualStyleBackColor = True
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(369, 58)
        LB_EmployeeName.Margin = New Padding(4, 0, 4, 0)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(96, 25)
        LB_EmployeeName.TabIndex = 104
        LB_EmployeeName.Text = "Nombre(s)"
        ' 
        ' PB_Picture
        ' 
        PB_Picture.BackgroundImageLayout = ImageLayout.None
        PB_Picture.BorderStyle = BorderStyle.Fixed3D
        PB_Picture.Location = New Point(33, 87)
        PB_Picture.Margin = New Padding(4, 5, 4, 5)
        PB_Picture.Name = "PB_Picture"
        PB_Picture.Size = New Size(177, 219)
        PB_Picture.SizeMode = PictureBoxSizeMode.StretchImage
        PB_Picture.TabIndex = 102
        PB_Picture.TabStop = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_AllEmployees)
        GroupBox1.Location = New Point(17, 77)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1783, 327)
        GroupBox1.TabIndex = 102
        GroupBox1.TabStop = False
        GroupBox1.Text = "Empleados registrados"
        ' 
        ' DGV_AllEmployees
        ' 
        DGV_AllEmployees.AllowUserToAddRows = False
        DGV_AllEmployees.AllowUserToDeleteRows = False
        DGV_AllEmployees.AllowUserToOrderColumns = True
        DGV_AllEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_AllEmployees.Location = New Point(33, 37)
        DGV_AllEmployees.Margin = New Padding(4, 5, 4, 5)
        DGV_AllEmployees.Name = "DGV_AllEmployees"
        DGV_AllEmployees.ReadOnly = True
        DGV_AllEmployees.RowHeadersWidth = 62
        DGV_AllEmployees.Size = New Size(1726, 250)
        DGV_AllEmployees.TabIndex = 0
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(17, 18)
        LB_Title.Margin = New Padding(4, 0, 4, 0)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(334, 45)
        LB_Title.TabIndex = 103
        LB_Title.Text = "Edición de empleados"
        ' 
        ' MD_UPD_Employees
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1830, 1050)
        Controls.Add(LB_Title)
        Controls.Add(GroupBox1)
        Controls.Add(GB_PersonalInformation)
        Location = New Point(17, 77)
        Name = "MD_UPD_Employees"
        Text = "Edición de empleados"
        WindowState = FormWindowState.Maximized
        GB_PersonalInformation.ResumeLayout(False)
        GB_PersonalInformation.PerformLayout()
        GB_EmergencyInfo.ResumeLayout(False)
        GB_EmergencyInfo.PerformLayout()
        GB_EmployeeInformation.ResumeLayout(False)
        GB_EmployeeInformation.PerformLayout()
        GB_FiscalInformation.ResumeLayout(False)
        GB_FiscalInformation.PerformLayout()
        CType(PB_Picture, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        CType(DGV_AllEmployees, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GB_PersonalInformation As GroupBox
    Friend WithEvents BT_EmployeeUpdate As Button
    Friend WithEvents TB_SocialNumber As TextBox
    Friend WithEvents GB_EmergencyInfo As GroupBox
    Friend WithEvents TB_Baneficiary As TextBox
    Friend WithEvents LB_Beneficiary As Label
    Friend WithEvents LB_EmergencyContact As Label
    Friend WithEvents LB_RelationShip As Label
    Friend WithEvents TB_EmergencyPhone As TextBox
    Friend WithEvents LB_PhoneNumber2 As Label
    Friend WithEvents TB_Relationship As TextBox
    Friend WithEvents TB_EmergencyContact As TextBox
    Friend WithEvents LB_SocialSecurityNumber As Label
    Friend WithEvents GB_EmployeeInformation As GroupBox
    Friend WithEvents CB_Position As ComboBox
    Friend WithEvents LB_Position As Label
    Friend WithEvents CB_Supervisor As ComboBox
    Friend WithEvents LB_Supervisor As Label
    Friend WithEvents TB_BaseSalary As TextBox
    Friend WithEvents TB_VacationsDays As TextBox
    Friend WithEvents DT_RegistrationDate As DateTimePicker
    Friend WithEvents DT_EntryDate As DateTimePicker
    Friend WithEvents LB_Salary As Label
    Friend WithEvents LB_VacationDays As Label
    Friend WithEvents CB_EmployeeType As ComboBox
    Friend WithEvents LB_EmployeeType As Label
    Friend WithEvents LB_RegisterDate As Label
    Friend WithEvents LB_EntryDate As Label
    Friend WithEvents LB_Company As Label
    Friend WithEvents CB_Company As ComboBox
    Friend WithEvents TB_Curp As TextBox
    Friend WithEvents GB_FiscalInformation As GroupBox
    Friend WithEvents TB_BankAccount As TextBox
    Friend WithEvents TB_BankName As TextBox
    Friend WithEvents LB_BankAccount As Label
    Friend WithEvents LB_BankName As Label
    Friend WithEvents TB_FiscalAddress As TextBox
    Friend WithEvents TB_RFC As TextBox
    Friend WithEvents LB_FiscalAddress As Label
    Friend WithEvents LB_RFC As Label
    Friend WithEvents TB_CivilStatus As TextBox
    Friend WithEvents TB_EmailAddress As TextBox
    Friend WithEvents TB_PhoneNumber As TextBox
    Friend WithEvents TB_PersonalAddress As TextBox
    Friend WithEvents TB_BornCity As TextBox
    Friend WithEvents DT_BornDate As DateTimePicker
    Friend WithEvents TB_LastName2 As TextBox
    Friend WithEvents TB_LastName1 As TextBox
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_Curp As Label
    Friend WithEvents LB_CivilStatus As Label
    Friend WithEvents LB_Email As Label
    Friend WithEvents LB_PhoneNumber As Label
    Friend WithEvents LB_Adress As Label
    Friend WithEvents LB_Picture As Label
    Friend WithEvents LB_BornCity As Label
    Friend WithEvents LB_BirthDate As Label
    Friend WithEvents LB_LastName2 As Label
    Friend WithEvents LB_LastName As Label
    Friend WithEvents BT_Picture As Button
    Friend WithEvents LB_EmployeeName As Label
    Protected Friend WithEvents PB_Picture As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGV_AllEmployees As DataGridView
    Friend WithEvents LB_Title As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CB_Department As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_Costc As TextBox
    Friend WithEvents CB_Status As CheckBox
End Class