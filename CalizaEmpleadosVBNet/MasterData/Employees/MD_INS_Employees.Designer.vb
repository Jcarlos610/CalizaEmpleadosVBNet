<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_INS_Employees
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MD_INS_Employees))
        GB_PersonalInformation = New GroupBox()
        BT_EmployeeRegister = New Button()
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
        GB_PersonalInformation.Controls.Add(BT_EmployeeRegister)
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
        GB_PersonalInformation.Location = New Point(12, 46)
        GB_PersonalInformation.Name = "GB_PersonalInformation"
        GB_PersonalInformation.Size = New Size(1248, 518)
        GB_PersonalInformation.TabIndex = 100
        GB_PersonalInformation.TabStop = False
        GB_PersonalInformation.Text = "Información personal"
        ' 
        ' BT_EmployeeRegister
        ' 
        BT_EmployeeRegister.Location = New Point(1101, 471)
        BT_EmployeeRegister.Name = "BT_EmployeeRegister"
        BT_EmployeeRegister.Size = New Size(130, 25)
        BT_EmployeeRegister.TabIndex = 407
        BT_EmployeeRegister.Text = "Registrar Empleado"
        BT_EmployeeRegister.UseVisualStyleBackColor = True
        ' 
        ' TB_SocialNumber
        ' 
        TB_SocialNumber.Location = New Point(612, 148)
        TB_SocialNumber.Name = "TB_SocialNumber"
        TB_SocialNumber.Size = New Size(219, 23)
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
        GB_EmergencyInfo.Location = New Point(23, 416)
        GB_EmergencyInfo.Name = "GB_EmergencyInfo"
        GB_EmergencyInfo.Size = New Size(1044, 80)
        GB_EmergencyInfo.TabIndex = 400
        GB_EmergencyInfo.TabStop = False
        GB_EmergencyInfo.Text = "Contacto de emergencia"
        ' 
        ' TB_Baneficiary
        ' 
        TB_Baneficiary.Location = New Point(678, 41)
        TB_Baneficiary.Name = "TB_Baneficiary"
        TB_Baneficiary.Size = New Size(342, 23)
        TB_Baneficiary.TabIndex = 408
        ' 
        ' LB_Beneficiary
        ' 
        LB_Beneficiary.AutoSize = True
        LB_Beneficiary.Location = New Point(677, 23)
        LB_Beneficiary.Name = "LB_Beneficiary"
        LB_Beneficiary.Size = New Size(132, 15)
        LB_Beneficiary.TabIndex = 407
        LB_Beneficiary.Text = "Nombre de beneficiario"
        ' 
        ' LB_EmergencyContact
        ' 
        LB_EmergencyContact.AutoSize = True
        LB_EmergencyContact.Location = New Point(23, 23)
        LB_EmergencyContact.Name = "LB_EmergencyContact"
        LB_EmergencyContact.Size = New Size(137, 15)
        LB_EmergencyContact.TabIndex = 401
        LB_EmergencyContact.Text = "Contacto de emergencia"
        ' 
        ' LB_RelationShip
        ' 
        LB_RelationShip.AutoSize = True
        LB_RelationShip.Location = New Point(348, 23)
        LB_RelationShip.Name = "LB_RelationShip"
        LB_RelationShip.Size = New Size(65, 15)
        LB_RelationShip.TabIndex = 403
        LB_RelationShip.Text = "Parentesco"
        ' 
        ' TB_EmergencyPhone
        ' 
        TB_EmergencyPhone.Location = New Point(496, 41)
        TB_EmergencyPhone.Name = "TB_EmergencyPhone"
        TB_EmergencyPhone.Size = New Size(169, 23)
        TB_EmergencyPhone.TabIndex = 406
        ' 
        ' LB_PhoneNumber2
        ' 
        LB_PhoneNumber2.AutoSize = True
        LB_PhoneNumber2.Location = New Point(496, 23)
        LB_PhoneNumber2.Name = "LB_PhoneNumber2"
        LB_PhoneNumber2.Size = New Size(119, 15)
        LB_PhoneNumber2.TabIndex = 405
        LB_PhoneNumber2.Text = "Teléfono de contacto"
        ' 
        ' TB_Relationship
        ' 
        TB_Relationship.Location = New Point(348, 41)
        TB_Relationship.Name = "TB_Relationship"
        TB_Relationship.Size = New Size(130, 23)
        TB_Relationship.TabIndex = 404
        ' 
        ' TB_EmergencyContact
        ' 
        TB_EmergencyContact.Location = New Point(23, 41)
        TB_EmergencyContact.Name = "TB_EmergencyContact"
        TB_EmergencyContact.Size = New Size(308, 23)
        TB_EmergencyContact.TabIndex = 402
        ' 
        ' LB_SocialSecurityNumber
        ' 
        LB_SocialSecurityNumber.AutoSize = True
        LB_SocialSecurityNumber.Location = New Point(612, 130)
        LB_SocialSecurityNumber.Name = "LB_SocialSecurityNumber"
        LB_SocialSecurityNumber.Size = New Size(189, 15)
        LB_SocialSecurityNumber.TabIndex = 124
        LB_SocialSecurityNumber.Text = "Numero de Seguridad Social (NSS)"
        ' 
        ' GB_EmployeeInformation
        ' 
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
        GB_EmployeeInformation.Location = New Point(23, 286)
        GB_EmployeeInformation.Name = "GB_EmployeeInformation"
        GB_EmployeeInformation.Size = New Size(1208, 125)
        GB_EmployeeInformation.TabIndex = 300
        GB_EmployeeInformation.TabStop = False
        GB_EmployeeInformation.Text = "Información de empleado"
        ' 
        ' CB_Position
        ' 
        CB_Position.FormattingEnabled = True
        CB_Position.Location = New Point(23, 86)
        CB_Position.Name = "CB_Position"
        CB_Position.Size = New Size(334, 23)
        CB_Position.TabIndex = 310
        ' 
        ' LB_Position
        ' 
        LB_Position.AutoSize = True
        LB_Position.Location = New Point(23, 68)
        LB_Position.Name = "LB_Position"
        LB_Position.Size = New Size(120, 15)
        LB_Position.TabIndex = 309
        LB_Position.Text = "Puesto a desempeñar"
        ' 
        ' CB_Supervisor
        ' 
        CB_Supervisor.FormattingEnabled = True
        CB_Supervisor.Location = New Point(373, 86)
        CB_Supervisor.Name = "CB_Supervisor"
        CB_Supervisor.Size = New Size(334, 23)
        CB_Supervisor.TabIndex = 312
        ' 
        ' LB_Supervisor
        ' 
        LB_Supervisor.AutoSize = True
        LB_Supervisor.Location = New Point(373, 68)
        LB_Supervisor.Name = "LB_Supervisor"
        LB_Supervisor.Size = New Size(51, 15)
        LB_Supervisor.TabIndex = 311
        LB_Supervisor.Text = "Superior"
        ' 
        ' TB_BaseSalary
        ' 
        TB_BaseSalary.BackColor = SystemColors.Info
        TB_BaseSalary.Location = New Point(854, 86)
        TB_BaseSalary.Name = "TB_BaseSalary"
        TB_BaseSalary.Size = New Size(100, 23)
        TB_BaseSalary.TabIndex = 316
        ' 
        ' TB_VacationsDays
        ' 
        TB_VacationsDays.Location = New Point(723, 86)
        TB_VacationsDays.Name = "TB_VacationsDays"
        TB_VacationsDays.Size = New Size(108, 23)
        TB_VacationsDays.TabIndex = 314
        ' 
        ' DT_RegistrationDate
        ' 
        DT_RegistrationDate.Location = New Point(801, 38)
        DT_RegistrationDate.Name = "DT_RegistrationDate"
        DT_RegistrationDate.Size = New Size(230, 23)
        DT_RegistrationDate.TabIndex = 308
        ' 
        ' DT_EntryDate
        ' 
        DT_EntryDate.Location = New Point(551, 38)
        DT_EntryDate.Name = "DT_EntryDate"
        DT_EntryDate.Size = New Size(229, 23)
        DT_EntryDate.TabIndex = 306
        ' 
        ' LB_Salary
        ' 
        LB_Salary.AutoSize = True
        LB_Salary.Location = New Point(854, 68)
        LB_Salary.Name = "LB_Salary"
        LB_Salary.Size = New Size(69, 15)
        LB_Salary.TabIndex = 315
        LB_Salary.Text = "Salario base"
        ' 
        ' LB_VacationDays
        ' 
        LB_VacationDays.AutoSize = True
        LB_VacationDays.Location = New Point(725, 68)
        LB_VacationDays.Name = "LB_VacationDays"
        LB_VacationDays.Size = New Size(106, 15)
        LB_VacationDays.TabIndex = 313
        LB_VacationDays.Text = "Días de vacaciones"
        ' 
        ' CB_EmployeeType
        ' 
        CB_EmployeeType.FormattingEnabled = True
        CB_EmployeeType.Location = New Point(373, 38)
        CB_EmployeeType.Name = "CB_EmployeeType"
        CB_EmployeeType.Size = New Size(161, 23)
        CB_EmployeeType.TabIndex = 304
        ' 
        ' LB_EmployeeType
        ' 
        LB_EmployeeType.AutoSize = True
        LB_EmployeeType.Location = New Point(373, 20)
        LB_EmployeeType.Name = "LB_EmployeeType"
        LB_EmployeeType.Size = New Size(103, 15)
        LB_EmployeeType.TabIndex = 303
        LB_EmployeeType.Text = "Tipo de empleado"
        ' 
        ' LB_RegisterDate
        ' 
        LB_RegisterDate.AutoSize = True
        LB_RegisterDate.Location = New Point(801, 20)
        LB_RegisterDate.Name = "LB_RegisterDate"
        LB_RegisterDate.Size = New Size(164, 15)
        LB_RegisterDate.TabIndex = 307
        LB_RegisterDate.Text = "Fecha de registro ante el IMSS"
        ' 
        ' LB_EntryDate
        ' 
        LB_EntryDate.AutoSize = True
        LB_EntryDate.Location = New Point(551, 20)
        LB_EntryDate.Name = "LB_EntryDate"
        LB_EntryDate.Size = New Size(96, 15)
        LB_EntryDate.TabIndex = 305
        LB_EntryDate.Text = "Fecha de Ingreso"
        ' 
        ' LB_Company
        ' 
        LB_Company.AutoSize = True
        LB_Company.Location = New Point(23, 20)
        LB_Company.Name = "LB_Company"
        LB_Company.Size = New Size(52, 15)
        LB_Company.TabIndex = 301
        LB_Company.Text = "Empresa"
        ' 
        ' CB_Company
        ' 
        CB_Company.FormattingEnabled = True
        CB_Company.Location = New Point(23, 38)
        CB_Company.Name = "CB_Company"
        CB_Company.Size = New Size(334, 23)
        CB_Company.TabIndex = 302
        ' 
        ' TB_Curp
        ' 
        TB_Curp.Location = New Point(421, 148)
        TB_Curp.Name = "TB_Curp"
        TB_Curp.Size = New Size(174, 23)
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
        GB_FiscalInformation.Location = New Point(23, 202)
        GB_FiscalInformation.Name = "GB_FiscalInformation"
        GB_FiscalInformation.Size = New Size(1208, 79)
        GB_FiscalInformation.TabIndex = 200
        GB_FiscalInformation.TabStop = False
        GB_FiscalInformation.Text = "Información Fiscal"
        ' 
        ' TB_BankAccount
        ' 
        TB_BankAccount.Location = New Point(870, 41)
        TB_BankAccount.Name = "TB_BankAccount"
        TB_BankAccount.Size = New Size(284, 23)
        TB_BankAccount.TabIndex = 208
        ' 
        ' TB_BankName
        ' 
        TB_BankName.Location = New Point(566, 41)
        TB_BankName.Name = "TB_BankName"
        TB_BankName.Size = New Size(289, 23)
        TB_BankName.TabIndex = 206
        ' 
        ' LB_BankAccount
        ' 
        LB_BankAccount.AutoSize = True
        LB_BankAccount.Location = New Point(870, 23)
        LB_BankAccount.Name = "LB_BankAccount"
        LB_BankAccount.Size = New Size(106, 15)
        LB_BankAccount.TabIndex = 207
        LB_BankAccount.Text = "Número de cuenta"
        ' 
        ' LB_BankName
        ' 
        LB_BankName.AutoSize = True
        LB_BankName.Location = New Point(566, 23)
        LB_BankName.Name = "LB_BankName"
        LB_BankName.Size = New Size(103, 15)
        LB_BankName.TabIndex = 205
        LB_BankName.Text = "Nombre de banco"
        ' 
        ' TB_FiscalAddress
        ' 
        TB_FiscalAddress.Location = New Point(207, 41)
        TB_FiscalAddress.Name = "TB_FiscalAddress"
        TB_FiscalAddress.Size = New Size(339, 23)
        TB_FiscalAddress.TabIndex = 204
        ' 
        ' TB_RFC
        ' 
        TB_RFC.Location = New Point(23, 41)
        TB_RFC.Name = "TB_RFC"
        TB_RFC.Size = New Size(170, 23)
        TB_RFC.TabIndex = 202
        ' 
        ' LB_FiscalAddress
        ' 
        LB_FiscalAddress.AutoSize = True
        LB_FiscalAddress.Location = New Point(207, 23)
        LB_FiscalAddress.Name = "LB_FiscalAddress"
        LB_FiscalAddress.Size = New Size(89, 15)
        LB_FiscalAddress.TabIndex = 203
        LB_FiscalAddress.Text = "Dirección Fiscal"
        ' 
        ' LB_RFC
        ' 
        LB_RFC.AutoSize = True
        LB_RFC.Location = New Point(23, 23)
        LB_RFC.Name = "LB_RFC"
        LB_RFC.Size = New Size(28, 15)
        LB_RFC.TabIndex = 201
        LB_RFC.Text = "RFC"
        ' 
        ' TB_CivilStatus
        ' 
        TB_CivilStatus.Location = New Point(260, 148)
        TB_CivilStatus.Name = "TB_CivilStatus"
        TB_CivilStatus.Size = New Size(141, 23)
        TB_CivilStatus.TabIndex = 121
        ' 
        ' TB_EmailAddress
        ' 
        TB_EmailAddress.Location = New Point(991, 100)
        TB_EmailAddress.Name = "TB_EmailAddress"
        TB_EmailAddress.Size = New Size(240, 23)
        TB_EmailAddress.TabIndex = 119
        ' 
        ' TB_PhoneNumber
        ' 
        TB_PhoneNumber.Location = New Point(824, 100)
        TB_PhoneNumber.Name = "TB_PhoneNumber"
        TB_PhoneNumber.Size = New Size(161, 23)
        TB_PhoneNumber.TabIndex = 117
        ' 
        ' TB_PersonalAddress
        ' 
        TB_PersonalAddress.Location = New Point(477, 100)
        TB_PersonalAddress.Name = "TB_PersonalAddress"
        TB_PersonalAddress.Size = New Size(338, 23)
        TB_PersonalAddress.TabIndex = 115
        ' 
        ' TB_BornCity
        ' 
        TB_BornCity.Location = New Point(257, 100)
        TB_BornCity.Name = "TB_BornCity"
        TB_BornCity.Size = New Size(203, 23)
        TB_BornCity.TabIndex = 113
        ' 
        ' DT_BornDate
        ' 
        DT_BornDate.Location = New Point(940, 52)
        DT_BornDate.Name = "DT_BornDate"
        DT_BornDate.Size = New Size(233, 23)
        DT_BornDate.TabIndex = 111
        ' 
        ' TB_LastName2
        ' 
        TB_LastName2.Location = New Point(711, 52)
        TB_LastName2.Name = "TB_LastName2"
        TB_LastName2.Size = New Size(214, 23)
        TB_LastName2.TabIndex = 109
        ' 
        ' TB_LastName1
        ' 
        TB_LastName1.Location = New Point(496, 52)
        TB_LastName1.Name = "TB_LastName1"
        TB_LastName1.Size = New Size(200, 23)
        TB_LastName1.TabIndex = 107
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(257, 52)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.Size = New Size(219, 23)
        TB_EmployeeName.TabIndex = 105
        ' 
        ' LB_Curp
        ' 
        LB_Curp.AutoSize = True
        LB_Curp.Location = New Point(421, 130)
        LB_Curp.Name = "LB_Curp"
        LB_Curp.Size = New Size(37, 15)
        LB_Curp.TabIndex = 122
        LB_Curp.Text = "CURP"
        ' 
        ' LB_CivilStatus
        ' 
        LB_CivilStatus.AutoSize = True
        LB_CivilStatus.Location = New Point(260, 130)
        LB_CivilStatus.Name = "LB_CivilStatus"
        LB_CivilStatus.Size = New Size(68, 15)
        LB_CivilStatus.TabIndex = 120
        LB_CivilStatus.Text = "Estado Civil"
        ' 
        ' LB_Email
        ' 
        LB_Email.AutoSize = True
        LB_Email.Location = New Point(986, 82)
        LB_Email.Name = "LB_Email"
        LB_Email.Size = New Size(105, 15)
        LB_Email.TabIndex = 118
        LB_Email.Text = "Correo Electrónico"
        ' 
        ' LB_PhoneNumber
        ' 
        LB_PhoneNumber.AutoSize = True
        LB_PhoneNumber.Location = New Point(824, 82)
        LB_PhoneNumber.Name = "LB_PhoneNumber"
        LB_PhoneNumber.Size = New Size(53, 15)
        LB_PhoneNumber.TabIndex = 116
        LB_PhoneNumber.Text = "Teléfono"
        ' 
        ' LB_Adress
        ' 
        LB_Adress.AutoSize = True
        LB_Adress.Location = New Point(477, 82)
        LB_Adress.Name = "LB_Adress"
        LB_Adress.Size = New Size(110, 15)
        LB_Adress.TabIndex = 114
        LB_Adress.Text = "Dirección particular"
        ' 
        ' LB_Picture
        ' 
        LB_Picture.AutoSize = True
        LB_Picture.Location = New Point(23, 34)
        LB_Picture.Name = "LB_Picture"
        LB_Picture.Size = New Size(103, 15)
        LB_Picture.TabIndex = 101
        LB_Picture.Text = "Foto de empleado"
        ' 
        ' LB_BornCity
        ' 
        LB_BornCity.AutoSize = True
        LB_BornCity.Location = New Point(257, 82)
        LB_BornCity.Name = "LB_BornCity"
        LB_BornCity.Size = New Size(116, 15)
        LB_BornCity.TabIndex = 112
        LB_BornCity.Text = "Lugar de nacimiento"
        ' 
        ' LB_BirthDate
        ' 
        LB_BirthDate.AutoSize = True
        LB_BirthDate.Location = New Point(940, 34)
        LB_BirthDate.Name = "LB_BirthDate"
        LB_BirthDate.Size = New Size(119, 15)
        LB_BirthDate.TabIndex = 110
        LB_BirthDate.Text = "Fecha de Nacimiento"
        ' 
        ' LB_LastName2
        ' 
        LB_LastName2.AutoSize = True
        LB_LastName2.Location = New Point(711, 34)
        LB_LastName2.Name = "LB_LastName2"
        LB_LastName2.Size = New Size(95, 15)
        LB_LastName2.TabIndex = 108
        LB_LastName2.Text = "Apellido Paterno"
        ' 
        ' LB_LastName
        ' 
        LB_LastName.AutoSize = True
        LB_LastName.Location = New Point(496, 34)
        LB_LastName.Name = "LB_LastName"
        LB_LastName.Size = New Size(99, 15)
        LB_LastName.TabIndex = 106
        LB_LastName.Text = "Apellido Materno"
        ' 
        ' BT_Picture
        ' 
        BT_Picture.Location = New Point(154, 162)
        BT_Picture.Name = "BT_Picture"
        BT_Picture.Size = New Size(88, 23)
        BT_Picture.TabIndex = 103
        BT_Picture.Text = "Importar..."
        BT_Picture.UseVisualStyleBackColor = True
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(257, 34)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(64, 15)
        LB_EmployeeName.TabIndex = 104
        LB_EmployeeName.Text = "Nombre(s)"
        ' 
        ' PB_Picture
        ' 
        PB_Picture.BackgroundImageLayout = ImageLayout.None
        PB_Picture.BorderStyle = BorderStyle.Fixed3D
        PB_Picture.Image = CType(resources.GetObject("PB_Picture.Image"), Image)
        PB_Picture.Location = New Point(23, 52)
        PB_Picture.Name = "PB_Picture"
        PB_Picture.Size = New Size(125, 133)
        PB_Picture.SizeMode = PictureBoxSizeMode.StretchImage
        PB_Picture.TabIndex = 102
        PB_Picture.TabStop = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_AllEmployees)
        GroupBox1.Location = New Point(12, 569)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1248, 196)
        GroupBox1.TabIndex = 101
        GroupBox1.TabStop = False
        GroupBox1.Text = "Empleados registrados"
        ' 
        ' DGV_AllEmployees
        ' 
        DGV_AllEmployees.AllowUserToAddRows = False
        DGV_AllEmployees.AllowUserToDeleteRows = False
        DGV_AllEmployees.AllowUserToOrderColumns = True
        DGV_AllEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_AllEmployees.Location = New Point(23, 22)
        DGV_AllEmployees.Name = "DGV_AllEmployees"
        DGV_AllEmployees.ReadOnly = True
        DGV_AllEmployees.Size = New Size(1208, 150)
        DGV_AllEmployees.TabIndex = 0
        ' 
        ' MD_INS_Employees
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1281, 783)
        Controls.Add(GroupBox1)
        Controls.Add(GB_PersonalInformation)
        Name = "MD_INS_Employees"
        Text = "Registro de empleados"
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
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GB_PersonalInformation As GroupBox
    Protected Friend WithEvents PB_Picture As PictureBox
    Friend WithEvents LB_Company As Label
    Friend WithEvents BT_Picture As Button
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents LB_Adress As Label
    Friend WithEvents LB_Picture As Label
    Friend WithEvents LB_BornCity As Label
    Friend WithEvents LB_BirthDate As Label
    Friend WithEvents LB_LastName2 As Label
    Friend WithEvents LB_LastName As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents CB_Company As ComboBox
    Friend WithEvents LB_Curp As Label
    Friend WithEvents LB_CivilStatus As Label
    Friend WithEvents LB_Email As Label
    Friend WithEvents LB_PhoneNumber As Label
    Friend WithEvents TB_Curp As TextBox
    Friend WithEvents TB_CivilStatus As TextBox
    Friend WithEvents TB_EmailAddress As TextBox
    Friend WithEvents TB_PhoneNumber As TextBox
    Friend WithEvents TB_PersonalAddress As TextBox
    Friend WithEvents TB_BornCity As TextBox
    Friend WithEvents DT_BornDate As DateTimePicker
    Friend WithEvents TB_LastName2 As TextBox
    Friend WithEvents TB_LastName1 As TextBox
    Friend WithEvents GB_FiscalInformation As GroupBox
    Friend WithEvents TB_SocialNumber As TextBox
    Friend WithEvents LB_SocialSecurityNumber As Label
    Friend WithEvents TB_FiscalAddress As TextBox
    Friend WithEvents TB_RFC As TextBox
    Friend WithEvents LB_FiscalAddress As Label
    Friend WithEvents LB_RFC As Label
    Friend WithEvents GB_EmployeeInformation As GroupBox
    Friend WithEvents LB_RegisterDate As Label
    Friend WithEvents LB_EntryDate As Label
    Friend WithEvents LB_BankName As Label
    Friend WithEvents LB_Salary As Label
    Friend WithEvents LB_VacationDays As Label
    Friend WithEvents CB_EmployeeType As ComboBox
    Friend WithEvents LB_EmployeeType As Label
    Friend WithEvents LB_PhoneNumber2 As Label
    Friend WithEvents LB_RelationShip As Label
    Friend WithEvents LB_EmergencyContact As Label
    Friend WithEvents TB_BankAccount As TextBox
    Friend WithEvents TB_BankName As TextBox
    Friend WithEvents LB_BankAccount As Label
    Friend WithEvents TB_EmergencyContact As TextBox
    Friend WithEvents DT_RegistrationDate As DateTimePicker
    Friend WithEvents DT_EntryDate As DateTimePicker
    Friend WithEvents TB_BaseSalary As TextBox
    Friend WithEvents TB_VacationsDays As TextBox
    Friend WithEvents TB_EmergencyPhone As TextBox
    Friend WithEvents TB_Relationship As TextBox
    Friend WithEvents CB_Position As ComboBox
    Friend WithEvents LB_Position As Label
    Friend WithEvents CB_Supervisor As ComboBox
    Friend WithEvents LB_Supervisor As Label
    Friend WithEvents GB_EmergencyInfo As GroupBox
    Friend WithEvents BT_EmployeeRegister As Button
    Friend WithEvents TB_Baneficiary As TextBox
    Friend WithEvents LB_Beneficiary As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGV_AllEmployees As DataGridView
End Class
