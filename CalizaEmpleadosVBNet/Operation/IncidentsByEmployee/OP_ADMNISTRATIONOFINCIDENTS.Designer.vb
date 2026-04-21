<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_ADMNISTRATIONOFINCIDENTS
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
        GB_EmployeeInfo = New GroupBox()
        CHK_LastOnly = New CheckBox()
        TB_TotalPermissions = New TextBox()
        BT_Refresh = New Button()
        TB_TotalVacations = New TextBox()
        BT_Search = New Button()
        TB_EmployeeName = New TextBox()
        TB_EmployeeId = New TextBox()
        LB_EmployeeName = New Label()
        LB_EmployeeId = New Label()
        DGV_Employees = New DataGridView()
        TB_Incidents = New TabControl()
        PaidLeave = New TabPage()
        LB_PermissionWithSalary = New Label()
        TB_Days = New TextBox()
        LB_Days = New Label()
        TB_Comment = New TextBox()
        LB_Comment = New Label()
        DTP_DateTo = New DateTimePicker()
        LB_DateTo = New Label()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        BT_Register = New Button()
        DTP_DateFrom = New DateTimePicker()
        LB_DateFrom = New Label()
        UnpaidLeave = New TabPage()
        LB_PermissionWithoutSalary = New Label()
        TB_InDays = New TextBox()
        LB_InDays = New Label()
        TB_InComment = New TextBox()
        LB_InComment = New Label()
        DTP_InDateTo = New DateTimePicker()
        LB_InDateTo = New Label()
        LB_InAuthorizeBy = New Label()
        TB_InAuthorizeBy = New TextBox()
        BT_InRegister = New Button()
        DTP_InDateFrom = New DateTimePicker()
        LB_InDateFrom = New Label()
        Vacations = New TabPage()
        LB_VacationsRequest = New Label()
        TB_VacDays = New TextBox()
        LB_VacDays = New Label()
        TB_VacComment = New TextBox()
        LB_VacComment = New Label()
        DTP_VacDateTo = New DateTimePicker()
        LB_VacDateTo = New Label()
        LB_VacAuthorizeBy = New Label()
        TB_VacAuthorizeBy = New TextBox()
        BT_VacRegister = New Button()
        DTP_VacDateFrom = New DateTimePicker()
        LB_VacDateFrom = New Label()
        DGV_Incidents = New DataGridView()
        GroupBox1 = New GroupBox()
        GB_EmployeeInfo.SuspendLayout()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).BeginInit()
        TB_Incidents.SuspendLayout()
        PaidLeave.SuspendLayout()
        UnpaidLeave.SuspendLayout()
        Vacations.SuspendLayout()
        CType(DGV_Incidents, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GB_EmployeeInfo
        ' 
        GB_EmployeeInfo.Controls.Add(CHK_LastOnly)
        GB_EmployeeInfo.Controls.Add(TB_TotalPermissions)
        GB_EmployeeInfo.Controls.Add(BT_Refresh)
        GB_EmployeeInfo.Controls.Add(TB_TotalVacations)
        GB_EmployeeInfo.Controls.Add(BT_Search)
        GB_EmployeeInfo.Controls.Add(TB_EmployeeName)
        GB_EmployeeInfo.Controls.Add(TB_EmployeeId)
        GB_EmployeeInfo.Controls.Add(LB_EmployeeName)
        GB_EmployeeInfo.Controls.Add(LB_EmployeeId)
        GB_EmployeeInfo.Controls.Add(DGV_Employees)
        GB_EmployeeInfo.Location = New Point(12, 46)
        GB_EmployeeInfo.Name = "GB_EmployeeInfo"
        GB_EmployeeInfo.Size = New Size(1361, 264)
        GB_EmployeeInfo.TabIndex = 1
        GB_EmployeeInfo.TabStop = False
        GB_EmployeeInfo.Text = "Información de empleado"
        ' 
        ' CHK_LastOnly
        ' 
        CHK_LastOnly.AutoSize = True
        CHK_LastOnly.Location = New Point(335, 188)
        CHK_LastOnly.Margin = New Padding(2)
        CHK_LastOnly.Name = "CHK_LastOnly"
        CHK_LastOnly.Size = New Size(173, 19)
        CHK_LastOnly.TabIndex = 11
        CHK_LastOnly.Text = "Mostrar solo último registro"
        CHK_LastOnly.UseVisualStyleBackColor = True
        ' 
        ' TB_TotalPermissions
        ' 
        TB_TotalPermissions.Location = New Point(15, 237)
        TB_TotalPermissions.Margin = New Padding(2)
        TB_TotalPermissions.Name = "TB_TotalPermissions"
        TB_TotalPermissions.Size = New Size(142, 23)
        TB_TotalPermissions.TabIndex = 10
        ' 
        ' BT_Refresh
        ' 
        BT_Refresh.Location = New Point(1265, 24)
        BT_Refresh.Name = "BT_Refresh"
        BT_Refresh.Size = New Size(75, 23)
        BT_Refresh.TabIndex = 8
        BT_Refresh.Text = "Actualizar"
        BT_Refresh.UseVisualStyleBackColor = True
        ' 
        ' TB_TotalVacations
        ' 
        TB_TotalVacations.Location = New Point(15, 212)
        TB_TotalVacations.Margin = New Padding(2)
        TB_TotalVacations.Name = "TB_TotalVacations"
        TB_TotalVacations.Size = New Size(142, 23)
        TB_TotalVacations.TabIndex = 8
        ' 
        ' BT_Search
        ' 
        BT_Search.Location = New Point(257, 21)
        BT_Search.Name = "BT_Search"
        BT_Search.Size = New Size(75, 23)
        BT_Search.TabIndex = 3
        BT_Search.Text = "Buscar"
        BT_Search.UseVisualStyleBackColor = True
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(78, 187)
        TB_EmployeeName.Margin = New Padding(2)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.Size = New Size(234, 23)
        TB_EmployeeName.TabIndex = 6
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(141, 21)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.Size = New Size(100, 23)
        TB_EmployeeId.TabIndex = 2
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(12, 191)
        LB_EmployeeName.Margin = New Padding(2, 0, 2, 0)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(63, 15)
        LB_EmployeeName.TabIndex = 5
        LB_EmployeeName.Text = "Empleado:"
        ' 
        ' LB_EmployeeId
        ' 
        LB_EmployeeId.AutoSize = True
        LB_EmployeeId.Location = New Point(13, 25)
        LB_EmployeeId.Name = "LB_EmployeeId"
        LB_EmployeeId.Size = New Size(123, 15)
        LB_EmployeeId.TabIndex = 1
        LB_EmployeeId.Text = "Número de empleado"
        ' 
        ' DGV_Employees
        ' 
        DGV_Employees.AllowUserToAddRows = False
        DGV_Employees.AllowUserToDeleteRows = False
        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Employees.Location = New Point(12, 52)
        DGV_Employees.Name = "DGV_Employees"
        DGV_Employees.ReadOnly = True
        DGV_Employees.RowHeadersWidth = 62
        DGV_Employees.Size = New Size(1329, 128)
        DGV_Employees.TabIndex = 1
        ' 
        ' TB_Incidents
        ' 
        TB_Incidents.Controls.Add(PaidLeave)
        TB_Incidents.Controls.Add(UnpaidLeave)
        TB_Incidents.Controls.Add(Vacations)
        TB_Incidents.Location = New Point(12, 19)
        TB_Incidents.Name = "TB_Incidents"
        TB_Incidents.SelectedIndex = 0
        TB_Incidents.Size = New Size(1247, 153)
        TB_Incidents.TabIndex = 3
        ' 
        ' PaidLeave
        ' 
        PaidLeave.BackColor = Color.White
        PaidLeave.Controls.Add(LB_PermissionWithSalary)
        PaidLeave.Controls.Add(TB_Days)
        PaidLeave.Controls.Add(LB_Days)
        PaidLeave.Controls.Add(TB_Comment)
        PaidLeave.Controls.Add(LB_Comment)
        PaidLeave.Controls.Add(DTP_DateTo)
        PaidLeave.Controls.Add(LB_DateTo)
        PaidLeave.Controls.Add(LB_AuthorizeBy)
        PaidLeave.Controls.Add(TB_AuthorizeBy)
        PaidLeave.Controls.Add(BT_Register)
        PaidLeave.Controls.Add(DTP_DateFrom)
        PaidLeave.Controls.Add(LB_DateFrom)
        PaidLeave.ForeColor = SystemColors.ControlLightLight
        PaidLeave.Location = New Point(4, 24)
        PaidLeave.Name = "PaidLeave"
        PaidLeave.Padding = New Padding(3)
        PaidLeave.Size = New Size(1239, 125)
        PaidLeave.TabIndex = 0
        PaidLeave.Text = "Permiso con goce"
        ' 
        ' LB_PermissionWithSalary
        ' 
        LB_PermissionWithSalary.AutoSize = True
        LB_PermissionWithSalary.BackColor = Color.Transparent
        LB_PermissionWithSalary.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        LB_PermissionWithSalary.ForeColor = SystemColors.ActiveCaptionText
        LB_PermissionWithSalary.Location = New Point(1033, 3)
        LB_PermissionWithSalary.Name = "LB_PermissionWithSalary"
        LB_PermissionWithSalary.Size = New Size(203, 20)
        LB_PermissionWithSalary.TabIndex = 34
        LB_PermissionWithSalary.Text = "Permiso con goce de sueldo"
        ' 
        ' TB_Days
        ' 
        TB_Days.Location = New Point(536, 27)
        TB_Days.Name = "TB_Days"
        TB_Days.Size = New Size(77, 23)
        TB_Days.TabIndex = 33
        ' 
        ' LB_Days
        ' 
        LB_Days.AutoSize = True
        LB_Days.ForeColor = SystemColors.ActiveCaptionText
        LB_Days.Location = New Point(536, 9)
        LB_Days.Name = "LB_Days"
        LB_Days.Size = New Size(29, 15)
        LB_Days.TabIndex = 32
        LB_Days.Text = "Días"
        ' 
        ' TB_Comment
        ' 
        TB_Comment.Location = New Point(111, 85)
        TB_Comment.Multiline = True
        TB_Comment.Name = "TB_Comment"
        TB_Comment.Size = New Size(354, 36)
        TB_Comment.TabIndex = 11
        ' 
        ' LB_Comment
        ' 
        LB_Comment.AutoSize = True
        LB_Comment.ForeColor = SystemColors.ActiveCaptionText
        LB_Comment.Location = New Point(10, 95)
        LB_Comment.Name = "LB_Comment"
        LB_Comment.Size = New Size(76, 15)
        LB_Comment.TabIndex = 10
        LB_Comment.Text = "Comentario: "
        ' 
        ' DTP_DateTo
        ' 
        DTP_DateTo.Location = New Point(276, 28)
        DTP_DateTo.Name = "DTP_DateTo"
        DTP_DateTo.Size = New Size(236, 23)
        DTP_DateTo.TabIndex = 9
        ' 
        ' LB_DateTo
        ' 
        LB_DateTo.AutoSize = True
        LB_DateTo.ForeColor = SystemColors.ActiveCaptionText
        LB_DateTo.Location = New Point(276, 9)
        LB_DateTo.Name = "LB_DateTo"
        LB_DateTo.Size = New Size(75, 15)
        LB_DateTo.TabIndex = 8
        LB_DateTo.Text = "Fecha hasta: "
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.ForeColor = SystemColors.ActiveCaptionText
        LB_AuthorizeBy.Location = New Point(10, 57)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(111, 57)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(248, 23)
        TB_AuthorizeBy.TabIndex = 5
        ' 
        ' BT_Register
        ' 
        BT_Register.ForeColor = SystemColors.ActiveCaptionText
        BT_Register.Location = New Point(1105, 96)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(128, 23)
        BT_Register.TabIndex = 6
        BT_Register.Text = "Registrar permiso"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' DTP_DateFrom
        ' 
        DTP_DateFrom.Location = New Point(10, 28)
        DTP_DateFrom.Name = "DTP_DateFrom"
        DTP_DateFrom.Size = New Size(236, 23)
        DTP_DateFrom.TabIndex = 4
        ' 
        ' LB_DateFrom
        ' 
        LB_DateFrom.AutoSize = True
        LB_DateFrom.ForeColor = SystemColors.ActiveCaptionText
        LB_DateFrom.Location = New Point(10, 9)
        LB_DateFrom.Name = "LB_DateFrom"
        LB_DateFrom.Size = New Size(78, 15)
        LB_DateFrom.TabIndex = 3
        LB_DateFrom.Text = "Fecha desde: "
        ' 
        ' UnpaidLeave
        ' 
        UnpaidLeave.BackColor = Color.White
        UnpaidLeave.Controls.Add(LB_PermissionWithoutSalary)
        UnpaidLeave.Controls.Add(TB_InDays)
        UnpaidLeave.Controls.Add(LB_InDays)
        UnpaidLeave.Controls.Add(TB_InComment)
        UnpaidLeave.Controls.Add(LB_InComment)
        UnpaidLeave.Controls.Add(DTP_InDateTo)
        UnpaidLeave.Controls.Add(LB_InDateTo)
        UnpaidLeave.Controls.Add(LB_InAuthorizeBy)
        UnpaidLeave.Controls.Add(TB_InAuthorizeBy)
        UnpaidLeave.Controls.Add(BT_InRegister)
        UnpaidLeave.Controls.Add(DTP_InDateFrom)
        UnpaidLeave.Controls.Add(LB_InDateFrom)
        UnpaidLeave.ForeColor = Color.White
        UnpaidLeave.Location = New Point(4, 24)
        UnpaidLeave.Name = "UnpaidLeave"
        UnpaidLeave.Padding = New Padding(3)
        UnpaidLeave.Size = New Size(1239, 125)
        UnpaidLeave.TabIndex = 1
        UnpaidLeave.Text = "Permiso sin goce"
        ' 
        ' LB_PermissionWithoutSalary
        ' 
        LB_PermissionWithoutSalary.AutoSize = True
        LB_PermissionWithoutSalary.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        LB_PermissionWithoutSalary.ForeColor = Color.Black
        LB_PermissionWithoutSalary.Location = New Point(1038, 3)
        LB_PermissionWithoutSalary.Name = "LB_PermissionWithoutSalary"
        LB_PermissionWithoutSalary.Size = New Size(198, 20)
        LB_PermissionWithoutSalary.TabIndex = 34
        LB_PermissionWithoutSalary.Text = "Permiso sin goce de sueldo"
        ' 
        ' TB_InDays
        ' 
        TB_InDays.Location = New Point(526, 26)
        TB_InDays.Name = "TB_InDays"
        TB_InDays.Size = New Size(77, 23)
        TB_InDays.TabIndex = 33
        ' 
        ' LB_InDays
        ' 
        LB_InDays.AutoSize = True
        LB_InDays.ForeColor = SystemColors.ActiveCaptionText
        LB_InDays.Location = New Point(526, 8)
        LB_InDays.Name = "LB_InDays"
        LB_InDays.Size = New Size(29, 15)
        LB_InDays.TabIndex = 32
        LB_InDays.Text = "Días"
        ' 
        ' TB_InComment
        ' 
        TB_InComment.Location = New Point(111, 84)
        TB_InComment.Multiline = True
        TB_InComment.Name = "TB_InComment"
        TB_InComment.Size = New Size(354, 36)
        TB_InComment.TabIndex = 20
        ' 
        ' LB_InComment
        ' 
        LB_InComment.AutoSize = True
        LB_InComment.ForeColor = SystemColors.ActiveCaptionText
        LB_InComment.Location = New Point(10, 95)
        LB_InComment.Name = "LB_InComment"
        LB_InComment.Size = New Size(76, 15)
        LB_InComment.TabIndex = 19
        LB_InComment.Text = "Comentario: "
        ' 
        ' DTP_InDateTo
        ' 
        DTP_InDateTo.Location = New Point(276, 28)
        DTP_InDateTo.Name = "DTP_InDateTo"
        DTP_InDateTo.Size = New Size(236, 23)
        DTP_InDateTo.TabIndex = 18
        ' 
        ' LB_InDateTo
        ' 
        LB_InDateTo.AutoSize = True
        LB_InDateTo.ForeColor = SystemColors.ActiveCaptionText
        LB_InDateTo.Location = New Point(276, 8)
        LB_InDateTo.Name = "LB_InDateTo"
        LB_InDateTo.Size = New Size(75, 15)
        LB_InDateTo.TabIndex = 17
        LB_InDateTo.Text = "Fecha hasta: "
        ' 
        ' LB_InAuthorizeBy
        ' 
        LB_InAuthorizeBy.AutoSize = True
        LB_InAuthorizeBy.ForeColor = SystemColors.ActiveCaptionText
        LB_InAuthorizeBy.Location = New Point(10, 56)
        LB_InAuthorizeBy.Name = "LB_InAuthorizeBy"
        LB_InAuthorizeBy.Size = New Size(89, 15)
        LB_InAuthorizeBy.TabIndex = 16
        LB_InAuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_InAuthorizeBy
        ' 
        TB_InAuthorizeBy.Location = New Point(111, 56)
        TB_InAuthorizeBy.Name = "TB_InAuthorizeBy"
        TB_InAuthorizeBy.Size = New Size(248, 23)
        TB_InAuthorizeBy.TabIndex = 14
        ' 
        ' BT_InRegister
        ' 
        BT_InRegister.ForeColor = SystemColors.ActiveCaptionText
        BT_InRegister.Location = New Point(1105, 96)
        BT_InRegister.Name = "BT_InRegister"
        BT_InRegister.Size = New Size(128, 23)
        BT_InRegister.TabIndex = 15
        BT_InRegister.Text = "Registrar permiso"
        BT_InRegister.UseVisualStyleBackColor = True
        ' 
        ' DTP_InDateFrom
        ' 
        DTP_InDateFrom.Location = New Point(10, 28)
        DTP_InDateFrom.Name = "DTP_InDateFrom"
        DTP_InDateFrom.Size = New Size(236, 23)
        DTP_InDateFrom.TabIndex = 13
        ' 
        ' LB_InDateFrom
        ' 
        LB_InDateFrom.AutoSize = True
        LB_InDateFrom.ForeColor = SystemColors.ActiveCaptionText
        LB_InDateFrom.Location = New Point(10, 8)
        LB_InDateFrom.Name = "LB_InDateFrom"
        LB_InDateFrom.Size = New Size(78, 15)
        LB_InDateFrom.TabIndex = 12
        LB_InDateFrom.Text = "Fecha desde: "
        ' 
        ' Vacations
        ' 
        Vacations.BackColor = Color.White
        Vacations.Controls.Add(LB_VacationsRequest)
        Vacations.Controls.Add(TB_VacDays)
        Vacations.Controls.Add(LB_VacDays)
        Vacations.Controls.Add(TB_VacComment)
        Vacations.Controls.Add(LB_VacComment)
        Vacations.Controls.Add(DTP_VacDateTo)
        Vacations.Controls.Add(LB_VacDateTo)
        Vacations.Controls.Add(LB_VacAuthorizeBy)
        Vacations.Controls.Add(TB_VacAuthorizeBy)
        Vacations.Controls.Add(BT_VacRegister)
        Vacations.Controls.Add(DTP_VacDateFrom)
        Vacations.Controls.Add(LB_VacDateFrom)
        Vacations.Location = New Point(4, 24)
        Vacations.Margin = New Padding(2)
        Vacations.Name = "Vacations"
        Vacations.Padding = New Padding(2)
        Vacations.Size = New Size(1239, 125)
        Vacations.TabIndex = 2
        Vacations.Text = "Registro de vacaciones"
        ' 
        ' LB_VacationsRequest
        ' 
        LB_VacationsRequest.AutoSize = True
        LB_VacationsRequest.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        LB_VacationsRequest.Location = New Point(1067, 3)
        LB_VacationsRequest.Name = "LB_VacationsRequest"
        LB_VacationsRequest.Size = New Size(169, 20)
        LB_VacationsRequest.TabIndex = 32
        LB_VacationsRequest.Text = "Solicitud de vacaciones"
        ' 
        ' TB_VacDays
        ' 
        TB_VacDays.Location = New Point(531, 26)
        TB_VacDays.Name = "TB_VacDays"
        TB_VacDays.Size = New Size(77, 23)
        TB_VacDays.TabIndex = 31
        ' 
        ' LB_VacDays
        ' 
        LB_VacDays.AutoSize = True
        LB_VacDays.ForeColor = SystemColors.ActiveCaptionText
        LB_VacDays.Location = New Point(531, 8)
        LB_VacDays.Name = "LB_VacDays"
        LB_VacDays.Size = New Size(29, 15)
        LB_VacDays.TabIndex = 30
        LB_VacDays.Text = "Días"
        ' 
        ' TB_VacComment
        ' 
        TB_VacComment.Location = New Point(111, 84)
        TB_VacComment.Multiline = True
        TB_VacComment.Name = "TB_VacComment"
        TB_VacComment.Size = New Size(354, 36)
        TB_VacComment.TabIndex = 29
        ' 
        ' LB_VacComment
        ' 
        LB_VacComment.AutoSize = True
        LB_VacComment.ForeColor = SystemColors.ActiveCaptionText
        LB_VacComment.Location = New Point(10, 95)
        LB_VacComment.Name = "LB_VacComment"
        LB_VacComment.Size = New Size(76, 15)
        LB_VacComment.TabIndex = 28
        LB_VacComment.Text = "Comentario: "
        ' 
        ' DTP_VacDateTo
        ' 
        DTP_VacDateTo.Location = New Point(276, 28)
        DTP_VacDateTo.Name = "DTP_VacDateTo"
        DTP_VacDateTo.Size = New Size(236, 23)
        DTP_VacDateTo.TabIndex = 27
        ' 
        ' LB_VacDateTo
        ' 
        LB_VacDateTo.AutoSize = True
        LB_VacDateTo.ForeColor = SystemColors.ActiveCaptionText
        LB_VacDateTo.Location = New Point(276, 8)
        LB_VacDateTo.Name = "LB_VacDateTo"
        LB_VacDateTo.Size = New Size(75, 15)
        LB_VacDateTo.TabIndex = 26
        LB_VacDateTo.Text = "Fecha hasta: "
        ' 
        ' LB_VacAuthorizeBy
        ' 
        LB_VacAuthorizeBy.AutoSize = True
        LB_VacAuthorizeBy.ForeColor = SystemColors.ActiveCaptionText
        LB_VacAuthorizeBy.Location = New Point(10, 56)
        LB_VacAuthorizeBy.Name = "LB_VacAuthorizeBy"
        LB_VacAuthorizeBy.Size = New Size(89, 15)
        LB_VacAuthorizeBy.TabIndex = 25
        LB_VacAuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_VacAuthorizeBy
        ' 
        TB_VacAuthorizeBy.Location = New Point(111, 56)
        TB_VacAuthorizeBy.Name = "TB_VacAuthorizeBy"
        TB_VacAuthorizeBy.Size = New Size(248, 23)
        TB_VacAuthorizeBy.TabIndex = 23
        ' 
        ' BT_VacRegister
        ' 
        BT_VacRegister.ForeColor = SystemColors.ActiveCaptionText
        BT_VacRegister.Location = New Point(1105, 96)
        BT_VacRegister.Name = "BT_VacRegister"
        BT_VacRegister.Size = New Size(128, 23)
        BT_VacRegister.TabIndex = 24
        BT_VacRegister.Text = "Registrar solicitud"
        BT_VacRegister.UseVisualStyleBackColor = True
        ' 
        ' DTP_VacDateFrom
        ' 
        DTP_VacDateFrom.Location = New Point(10, 28)
        DTP_VacDateFrom.Name = "DTP_VacDateFrom"
        DTP_VacDateFrom.Size = New Size(236, 23)
        DTP_VacDateFrom.TabIndex = 22
        ' 
        ' LB_VacDateFrom
        ' 
        LB_VacDateFrom.AutoSize = True
        LB_VacDateFrom.ForeColor = SystemColors.ActiveCaptionText
        LB_VacDateFrom.Location = New Point(10, 8)
        LB_VacDateFrom.Name = "LB_VacDateFrom"
        LB_VacDateFrom.Size = New Size(78, 15)
        LB_VacDateFrom.TabIndex = 21
        LB_VacDateFrom.Text = "Fecha desde: "
        ' 
        ' DGV_Incidents
        ' 
        DGV_Incidents.AllowUserToAddRows = False
        DGV_Incidents.AllowUserToDeleteRows = False
        DGV_Incidents.AllowUserToOrderColumns = True
        DGV_Incidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_Incidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Incidents.Location = New Point(15, 176)
        DGV_Incidents.Name = "DGV_Incidents"
        DGV_Incidents.ReadOnly = True
        DGV_Incidents.RowHeadersWidth = 62
        DGV_Incidents.Size = New Size(1329, 128)
        DGV_Incidents.TabIndex = 4
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_Incidents)
        GroupBox1.Controls.Add(TB_Incidents)
        GroupBox1.Location = New Point(12, 315)
        GroupBox1.Margin = New Padding(2)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(2)
        GroupBox1.Size = New Size(1332, 317)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información de permisos"
        ' 
        ' OP_ADMNISTRATIONOFINCIDENTS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1347, 630)
        Controls.Add(GB_EmployeeInfo)
        Controls.Add(GroupBox1)
        Margin = New Padding(2)
        Name = "OP_ADMNISTRATIONOFINCIDENTS"
        Text = "Registro de permisos"
        WindowState = FormWindowState.Maximized
        GB_EmployeeInfo.ResumeLayout(False)
        GB_EmployeeInfo.PerformLayout()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).EndInit()
        TB_Incidents.ResumeLayout(False)
        PaidLeave.ResumeLayout(False)
        PaidLeave.PerformLayout()
        UnpaidLeave.ResumeLayout(False)
        UnpaidLeave.PerformLayout()
        Vacations.ResumeLayout(False)
        Vacations.PerformLayout()
        CType(DGV_Incidents, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents GB_EmployeeInfo As GroupBox
    Friend WithEvents BT_Refresh As Button
    Friend WithEvents BT_Search As Button
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmployeeId As Label
    Friend WithEvents DGV_Employees As DataGridView
    Friend WithEvents TB_Incidents As TabControl
    Friend WithEvents PaidLeave As TabPage
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents DTP_DateFrom As DateTimePicker
    Friend WithEvents LB_DateFrom As Label
    Friend WithEvents UnpaidLeave As TabPage
    Friend WithEvents Vacations As TabPage
    Friend WithEvents LB_DateTo As Label
    Friend WithEvents DTP_DateTo As DateTimePicker
    Friend WithEvents LB_Comment As Label
    Friend WithEvents TB_Comment As TextBox
    Friend WithEvents TB_InComment As TextBox
    Friend WithEvents LB_InComment As Label
    Friend WithEvents DTP_InDateTo As DateTimePicker
    Friend WithEvents LB_InDateTo As Label
    Friend WithEvents LB_InAuthorizeBy As Label
    Friend WithEvents TB_InAuthorizeBy As TextBox
    Friend WithEvents BT_InRegister As Button
    Friend WithEvents DTP_InDateFrom As DateTimePicker
    Friend WithEvents LB_InDateFrom As Label
    Friend WithEvents TB_VacComment As TextBox
    Friend WithEvents LB_VacComment As Label
    Friend WithEvents DTP_VacDateTo As DateTimePicker
    Friend WithEvents LB_VacDateTo As Label
    Friend WithEvents LB_VacAuthorizeBy As Label
    Friend WithEvents TB_VacAuthorizeBy As TextBox
    Friend WithEvents BT_VacRegister As Button
    Friend WithEvents DTP_VacDateFrom As DateTimePicker
    Friend WithEvents LB_VacDateFrom As Label
    Friend WithEvents TB_VacDays As TextBox
    Friend WithEvents LB_VacDays As Label
    Friend WithEvents TB_Days As TextBox
    Friend WithEvents LB_Days As Label
    Friend WithEvents TB_InDays As TextBox
    Friend WithEvents LB_InDays As Label
    Friend WithEvents DGV_Incidents As DataGridView
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents TB_TotalVacations As TextBox
    Friend WithEvents TB_TotalPermissions As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CHK_LastOnly As CheckBox
    Friend WithEvents LB_PermissionWithSalary As Label
    Friend WithEvents LB_PermissionWithoutSalary As Label
    Friend WithEvents LB_VacationsRequest As Label
End Class
