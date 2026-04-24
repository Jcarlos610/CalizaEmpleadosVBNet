<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UP_ADMNISTRATIONOFINCIDENTS
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
        TB_TotalPermissions = New TextBox()
        TB_TotalVacations = New TextBox()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        DGV_Employees = New DataGridView()
        GroupBox1 = New GroupBox()
        DGV_Incidents = New DataGridView()
        TB_Incidents = New TabControl()
        TabPaidLeave = New TabPage()
        LB_PermissionWithSalary = New Label()
        TB_Days = New TextBox()
        LB_Days = New Label()
        TB_Comment = New TextBox()
        LB_Comment = New Label()
        DTP_DateTo = New DateTimePicker()
        LB_DateTo = New Label()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        BT_Upd = New Button()
        DTP_DateFrom = New DateTimePicker()
        LB_DateFrom = New Label()
        TabUnpaidLeave = New TabPage()
        LB_PermissionWithoutSalary = New Label()
        TB_InDays = New TextBox()
        LB_InDays = New Label()
        TB_InComment = New TextBox()
        LB_InComment = New Label()
        DTP_InDateTo = New DateTimePicker()
        LB_InDateTo = New Label()
        LB_InAuthorizeBy = New Label()
        TB_InAuthorizeBy = New TextBox()
        BT_InUpd = New Button()
        DTP_InDateFrom = New DateTimePicker()
        LB_InDateFrom = New Label()
        TabVacations = New TabPage()
        LB_VacationsRequest = New Label()
        TB_VacDays = New TextBox()
        LB_VacDays = New Label()
        TB_VacComment = New TextBox()
        LB_VacComment = New Label()
        DTP_VacDateTo = New DateTimePicker()
        LB_VacDateTo = New Label()
        LB_VacAuthorizeBy = New Label()
        TB_VacAuthorizeBy = New TextBox()
        BT_VacUpd = New Button()
        DTP_VacDateFrom = New DateTimePicker()
        LB_VacDateFrom = New Label()
        GB_EmployeeInfo.SuspendLayout()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(DGV_Incidents, ComponentModel.ISupportInitialize).BeginInit()
        TB_Incidents.SuspendLayout()
        TabPaidLeave.SuspendLayout()
        TabUnpaidLeave.SuspendLayout()
        TabVacations.SuspendLayout()
        SuspendLayout()
        ' 
        ' GB_EmployeeInfo
        ' 
        GB_EmployeeInfo.Controls.Add(TB_TotalPermissions)
        GB_EmployeeInfo.Controls.Add(TB_TotalVacations)
        GB_EmployeeInfo.Controls.Add(TB_EmployeeName)
        GB_EmployeeInfo.Controls.Add(LB_EmployeeName)
        GB_EmployeeInfo.Controls.Add(DGV_Employees)
        GB_EmployeeInfo.Location = New Point(17, 77)
        GB_EmployeeInfo.Margin = New Padding(4, 5, 4, 5)
        GB_EmployeeInfo.Name = "GB_EmployeeInfo"
        GB_EmployeeInfo.Padding = New Padding(4, 5, 4, 5)
        GB_EmployeeInfo.Size = New Size(1944, 401)
        GB_EmployeeInfo.TabIndex = 6
        GB_EmployeeInfo.TabStop = False
        GB_EmployeeInfo.Text = "Información de empleado"
        ' 
        ' TB_TotalPermissions
        ' 
        TB_TotalPermissions.Location = New Point(17, 353)
        TB_TotalPermissions.Name = "TB_TotalPermissions"
        TB_TotalPermissions.Size = New Size(201, 31)
        TB_TotalPermissions.TabIndex = 10
        ' 
        ' TB_TotalVacations
        ' 
        TB_TotalVacations.Location = New Point(17, 312)
        TB_TotalVacations.Name = "TB_TotalVacations"
        TB_TotalVacations.Size = New Size(201, 31)
        TB_TotalVacations.TabIndex = 8
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(119, 265)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.Size = New Size(333, 31)
        TB_EmployeeName.TabIndex = 6
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(17, 265)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(96, 25)
        LB_EmployeeName.TabIndex = 5
        LB_EmployeeName.Text = "Empleado:"
        ' 
        ' DGV_Employees
        ' 
        DGV_Employees.AllowUserToAddRows = False
        DGV_Employees.AllowUserToDeleteRows = False
        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Employees.Location = New Point(17, 34)
        DGV_Employees.Margin = New Padding(4, 5, 4, 5)
        DGV_Employees.Name = "DGV_Employees"
        DGV_Employees.ReadOnly = True
        DGV_Employees.RowHeadersWidth = 62
        DGV_Employees.Size = New Size(1899, 213)
        DGV_Employees.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_Incidents)
        GroupBox1.Controls.Add(TB_Incidents)
        GroupBox1.Location = New Point(17, 486)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1903, 528)
        GroupBox1.TabIndex = 7
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información de permisos"
        ' 
        ' DGV_Incidents
        ' 
        DGV_Incidents.AllowUserToAddRows = False
        DGV_Incidents.AllowUserToDeleteRows = False
        DGV_Incidents.AllowUserToOrderColumns = True
        DGV_Incidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_Incidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Incidents.Location = New Point(21, 293)
        DGV_Incidents.Margin = New Padding(4, 5, 4, 5)
        DGV_Incidents.Name = "DGV_Incidents"
        DGV_Incidents.ReadOnly = True
        DGV_Incidents.RowHeadersWidth = 62
        DGV_Incidents.Size = New Size(1899, 213)
        DGV_Incidents.TabIndex = 5
        ' 
        ' TB_Incidents
        ' 
        TB_Incidents.Controls.Add(TabPaidLeave)
        TB_Incidents.Controls.Add(TabUnpaidLeave)
        TB_Incidents.Controls.Add(TabVacations)
        TB_Incidents.Location = New Point(17, 32)
        TB_Incidents.Margin = New Padding(4, 5, 4, 5)
        TB_Incidents.Name = "TB_Incidents"
        TB_Incidents.SelectedIndex = 0
        TB_Incidents.Size = New Size(1781, 255)
        TB_Incidents.TabIndex = 3
        ' 
        ' TabPaidLeave
        ' 
        TabPaidLeave.BackColor = Color.White
        TabPaidLeave.Controls.Add(LB_PermissionWithSalary)
        TabPaidLeave.Controls.Add(TB_Days)
        TabPaidLeave.Controls.Add(LB_Days)
        TabPaidLeave.Controls.Add(TB_Comment)
        TabPaidLeave.Controls.Add(LB_Comment)
        TabPaidLeave.Controls.Add(DTP_DateTo)
        TabPaidLeave.Controls.Add(LB_DateTo)
        TabPaidLeave.Controls.Add(LB_AuthorizeBy)
        TabPaidLeave.Controls.Add(TB_AuthorizeBy)
        TabPaidLeave.Controls.Add(BT_Upd)
        TabPaidLeave.Controls.Add(DTP_DateFrom)
        TabPaidLeave.Controls.Add(LB_DateFrom)
        TabPaidLeave.ForeColor = SystemColors.ControlLightLight
        TabPaidLeave.Location = New Point(4, 34)
        TabPaidLeave.Margin = New Padding(4, 5, 4, 5)
        TabPaidLeave.Name = "TabPaidLeave"
        TabPaidLeave.Padding = New Padding(4, 5, 4, 5)
        TabPaidLeave.Size = New Size(1773, 217)
        TabPaidLeave.TabIndex = 0
        TabPaidLeave.Text = "Permiso con goce"
        ' 
        ' LB_PermissionWithSalary
        ' 
        LB_PermissionWithSalary.AutoSize = True
        LB_PermissionWithSalary.BackColor = Color.Transparent
        LB_PermissionWithSalary.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        LB_PermissionWithSalary.ForeColor = SystemColors.ActiveCaptionText
        LB_PermissionWithSalary.Location = New Point(1480, 10)
        LB_PermissionWithSalary.Margin = New Padding(4, 0, 4, 0)
        LB_PermissionWithSalary.Name = "LB_PermissionWithSalary"
        LB_PermissionWithSalary.Size = New Size(301, 30)
        LB_PermissionWithSalary.TabIndex = 34
        LB_PermissionWithSalary.Text = "Permiso con goce de sueldo"
        ' 
        ' TB_Days
        ' 
        TB_Days.Location = New Point(766, 45)
        TB_Days.Margin = New Padding(4, 5, 4, 5)
        TB_Days.Name = "TB_Days"
        TB_Days.Size = New Size(108, 31)
        TB_Days.TabIndex = 33
        ' 
        ' LB_Days
        ' 
        LB_Days.AutoSize = True
        LB_Days.ForeColor = SystemColors.ActiveCaptionText
        LB_Days.Location = New Point(770, 20)
        LB_Days.Margin = New Padding(4, 0, 4, 0)
        LB_Days.Name = "LB_Days"
        LB_Days.Size = New Size(46, 25)
        LB_Days.TabIndex = 32
        LB_Days.Text = "Días"
        ' 
        ' TB_Comment
        ' 
        TB_Comment.Location = New Point(159, 142)
        TB_Comment.Margin = New Padding(4, 5, 4, 5)
        TB_Comment.Multiline = True
        TB_Comment.Name = "TB_Comment"
        TB_Comment.Size = New Size(504, 57)
        TB_Comment.TabIndex = 11
        ' 
        ' LB_Comment
        ' 
        LB_Comment.AutoSize = True
        LB_Comment.ForeColor = SystemColors.ActiveCaptionText
        LB_Comment.Location = New Point(18, 163)
        LB_Comment.Margin = New Padding(4, 0, 4, 0)
        LB_Comment.Name = "LB_Comment"
        LB_Comment.Size = New Size(114, 25)
        LB_Comment.TabIndex = 10
        LB_Comment.Text = "Comentario: "
        ' 
        ' DTP_DateTo
        ' 
        DTP_DateTo.Location = New Point(394, 47)
        DTP_DateTo.Margin = New Padding(4, 5, 4, 5)
        DTP_DateTo.Name = "DTP_DateTo"
        DTP_DateTo.Size = New Size(335, 31)
        DTP_DateTo.TabIndex = 9
        ' 
        ' LB_DateTo
        ' 
        LB_DateTo.AutoSize = True
        LB_DateTo.ForeColor = SystemColors.ActiveCaptionText
        LB_DateTo.Location = New Point(398, 20)
        LB_DateTo.Margin = New Padding(4, 0, 4, 0)
        LB_DateTo.Name = "LB_DateTo"
        LB_DateTo.Size = New Size(113, 25)
        LB_DateTo.TabIndex = 8
        LB_DateTo.Text = "Fecha hasta: "
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.ForeColor = SystemColors.ActiveCaptionText
        LB_AuthorizeBy.Location = New Point(18, 100)
        LB_AuthorizeBy.Margin = New Padding(4, 0, 4, 0)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(137, 25)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(159, 95)
        TB_AuthorizeBy.Margin = New Padding(4, 5, 4, 5)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(353, 31)
        TB_AuthorizeBy.TabIndex = 5
        ' 
        ' BT_Upd
        ' 
        BT_Upd.ForeColor = SystemColors.ActiveCaptionText
        BT_Upd.Location = New Point(1579, 160)
        BT_Upd.Margin = New Padding(4, 5, 4, 5)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(183, 38)
        BT_Upd.TabIndex = 6
        BT_Upd.Text = "Actualizar permiso"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' DTP_DateFrom
        ' 
        DTP_DateFrom.Location = New Point(14, 47)
        DTP_DateFrom.Margin = New Padding(4, 5, 4, 5)
        DTP_DateFrom.Name = "DTP_DateFrom"
        DTP_DateFrom.Size = New Size(335, 31)
        DTP_DateFrom.TabIndex = 4
        ' 
        ' LB_DateFrom
        ' 
        LB_DateFrom.AutoSize = True
        LB_DateFrom.ForeColor = SystemColors.ActiveCaptionText
        LB_DateFrom.Location = New Point(18, 20)
        LB_DateFrom.Margin = New Padding(4, 0, 4, 0)
        LB_DateFrom.Name = "LB_DateFrom"
        LB_DateFrom.Size = New Size(119, 25)
        LB_DateFrom.TabIndex = 3
        LB_DateFrom.Text = "Fecha desde: "
        ' 
        ' TabUnpaidLeave
        ' 
        TabUnpaidLeave.BackColor = Color.White
        TabUnpaidLeave.Controls.Add(LB_PermissionWithoutSalary)
        TabUnpaidLeave.Controls.Add(TB_InDays)
        TabUnpaidLeave.Controls.Add(LB_InDays)
        TabUnpaidLeave.Controls.Add(TB_InComment)
        TabUnpaidLeave.Controls.Add(LB_InComment)
        TabUnpaidLeave.Controls.Add(DTP_InDateTo)
        TabUnpaidLeave.Controls.Add(LB_InDateTo)
        TabUnpaidLeave.Controls.Add(LB_InAuthorizeBy)
        TabUnpaidLeave.Controls.Add(TB_InAuthorizeBy)
        TabUnpaidLeave.Controls.Add(BT_InUpd)
        TabUnpaidLeave.Controls.Add(DTP_InDateFrom)
        TabUnpaidLeave.Controls.Add(LB_InDateFrom)
        TabUnpaidLeave.ForeColor = Color.White
        TabUnpaidLeave.Location = New Point(4, 34)
        TabUnpaidLeave.Margin = New Padding(4, 5, 4, 5)
        TabUnpaidLeave.Name = "TabUnpaidLeave"
        TabUnpaidLeave.Padding = New Padding(4, 5, 4, 5)
        TabUnpaidLeave.Size = New Size(1773, 217)
        TabUnpaidLeave.TabIndex = 1
        TabUnpaidLeave.Text = "Permiso sin goce"
        ' 
        ' LB_PermissionWithoutSalary
        ' 
        LB_PermissionWithoutSalary.AutoSize = True
        LB_PermissionWithoutSalary.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        LB_PermissionWithoutSalary.ForeColor = Color.Black
        LB_PermissionWithoutSalary.Location = New Point(1487, 10)
        LB_PermissionWithoutSalary.Margin = New Padding(4, 0, 4, 0)
        LB_PermissionWithoutSalary.Name = "LB_PermissionWithoutSalary"
        LB_PermissionWithoutSalary.Size = New Size(293, 30)
        LB_PermissionWithoutSalary.TabIndex = 34
        LB_PermissionWithoutSalary.Text = "Permiso sin goce de sueldo"
        ' 
        ' TB_InDays
        ' 
        TB_InDays.Location = New Point(751, 43)
        TB_InDays.Margin = New Padding(4, 5, 4, 5)
        TB_InDays.Name = "TB_InDays"
        TB_InDays.Size = New Size(108, 31)
        TB_InDays.TabIndex = 33
        ' 
        ' LB_InDays
        ' 
        LB_InDays.AutoSize = True
        LB_InDays.ForeColor = SystemColors.ActiveCaptionText
        LB_InDays.Location = New Point(755, 18)
        LB_InDays.Margin = New Padding(4, 0, 4, 0)
        LB_InDays.Name = "LB_InDays"
        LB_InDays.Size = New Size(46, 25)
        LB_InDays.TabIndex = 32
        LB_InDays.Text = "Días"
        ' 
        ' TB_InComment
        ' 
        TB_InComment.Location = New Point(159, 140)
        TB_InComment.Margin = New Padding(4, 5, 4, 5)
        TB_InComment.Multiline = True
        TB_InComment.Name = "TB_InComment"
        TB_InComment.Size = New Size(504, 57)
        TB_InComment.TabIndex = 20
        ' 
        ' LB_InComment
        ' 
        LB_InComment.AutoSize = True
        LB_InComment.ForeColor = SystemColors.ActiveCaptionText
        LB_InComment.Location = New Point(18, 163)
        LB_InComment.Margin = New Padding(4, 0, 4, 0)
        LB_InComment.Name = "LB_InComment"
        LB_InComment.Size = New Size(114, 25)
        LB_InComment.TabIndex = 19
        LB_InComment.Text = "Comentario: "
        ' 
        ' DTP_InDateTo
        ' 
        DTP_InDateTo.Location = New Point(394, 47)
        DTP_InDateTo.Margin = New Padding(4, 5, 4, 5)
        DTP_InDateTo.Name = "DTP_InDateTo"
        DTP_InDateTo.Size = New Size(335, 31)
        DTP_InDateTo.TabIndex = 18
        ' 
        ' LB_InDateTo
        ' 
        LB_InDateTo.AutoSize = True
        LB_InDateTo.ForeColor = SystemColors.ActiveCaptionText
        LB_InDateTo.Location = New Point(398, 18)
        LB_InDateTo.Margin = New Padding(4, 0, 4, 0)
        LB_InDateTo.Name = "LB_InDateTo"
        LB_InDateTo.Size = New Size(113, 25)
        LB_InDateTo.TabIndex = 17
        LB_InDateTo.Text = "Fecha hasta: "
        ' 
        ' LB_InAuthorizeBy
        ' 
        LB_InAuthorizeBy.AutoSize = True
        LB_InAuthorizeBy.ForeColor = SystemColors.ActiveCaptionText
        LB_InAuthorizeBy.Location = New Point(18, 98)
        LB_InAuthorizeBy.Margin = New Padding(4, 0, 4, 0)
        LB_InAuthorizeBy.Name = "LB_InAuthorizeBy"
        LB_InAuthorizeBy.Size = New Size(137, 25)
        LB_InAuthorizeBy.TabIndex = 16
        LB_InAuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_InAuthorizeBy
        ' 
        TB_InAuthorizeBy.Location = New Point(159, 93)
        TB_InAuthorizeBy.Margin = New Padding(4, 5, 4, 5)
        TB_InAuthorizeBy.Name = "TB_InAuthorizeBy"
        TB_InAuthorizeBy.Size = New Size(353, 31)
        TB_InAuthorizeBy.TabIndex = 14
        ' 
        ' BT_InUpd
        ' 
        BT_InUpd.ForeColor = SystemColors.ActiveCaptionText
        BT_InUpd.Location = New Point(1579, 160)
        BT_InUpd.Margin = New Padding(4, 5, 4, 5)
        BT_InUpd.Name = "BT_InUpd"
        BT_InUpd.Size = New Size(183, 38)
        BT_InUpd.TabIndex = 15
        BT_InUpd.Text = "Actualizar permiso"
        BT_InUpd.UseVisualStyleBackColor = True
        ' 
        ' DTP_InDateFrom
        ' 
        DTP_InDateFrom.Location = New Point(14, 47)
        DTP_InDateFrom.Margin = New Padding(4, 5, 4, 5)
        DTP_InDateFrom.Name = "DTP_InDateFrom"
        DTP_InDateFrom.Size = New Size(335, 31)
        DTP_InDateFrom.TabIndex = 13
        ' 
        ' LB_InDateFrom
        ' 
        LB_InDateFrom.AutoSize = True
        LB_InDateFrom.ForeColor = SystemColors.ActiveCaptionText
        LB_InDateFrom.Location = New Point(18, 18)
        LB_InDateFrom.Margin = New Padding(4, 0, 4, 0)
        LB_InDateFrom.Name = "LB_InDateFrom"
        LB_InDateFrom.Size = New Size(119, 25)
        LB_InDateFrom.TabIndex = 12
        LB_InDateFrom.Text = "Fecha desde: "
        ' 
        ' TabVacations
        ' 
        TabVacations.BackColor = Color.White
        TabVacations.Controls.Add(LB_VacationsRequest)
        TabVacations.Controls.Add(TB_VacDays)
        TabVacations.Controls.Add(LB_VacDays)
        TabVacations.Controls.Add(TB_VacComment)
        TabVacations.Controls.Add(LB_VacComment)
        TabVacations.Controls.Add(DTP_VacDateTo)
        TabVacations.Controls.Add(LB_VacDateTo)
        TabVacations.Controls.Add(LB_VacAuthorizeBy)
        TabVacations.Controls.Add(TB_VacAuthorizeBy)
        TabVacations.Controls.Add(BT_VacUpd)
        TabVacations.Controls.Add(DTP_VacDateFrom)
        TabVacations.Controls.Add(LB_VacDateFrom)
        TabVacations.Location = New Point(4, 34)
        TabVacations.Name = "TabVacations"
        TabVacations.Padding = New Padding(3)
        TabVacations.Size = New Size(1773, 217)
        TabVacations.TabIndex = 2
        TabVacations.Text = "Vacaciones"
        ' 
        ' LB_VacationsRequest
        ' 
        LB_VacationsRequest.AutoSize = True
        LB_VacationsRequest.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        LB_VacationsRequest.Location = New Point(1527, 8)
        LB_VacationsRequest.Margin = New Padding(4, 0, 4, 0)
        LB_VacationsRequest.Name = "LB_VacationsRequest"
        LB_VacationsRequest.Size = New Size(253, 30)
        LB_VacationsRequest.TabIndex = 32
        LB_VacationsRequest.Text = "Solicitud de vacaciones"
        ' 
        ' TB_VacDays
        ' 
        TB_VacDays.Location = New Point(759, 43)
        TB_VacDays.Margin = New Padding(4, 5, 4, 5)
        TB_VacDays.Name = "TB_VacDays"
        TB_VacDays.Size = New Size(108, 31)
        TB_VacDays.TabIndex = 31
        ' 
        ' LB_VacDays
        ' 
        LB_VacDays.AutoSize = True
        LB_VacDays.ForeColor = SystemColors.ActiveCaptionText
        LB_VacDays.Location = New Point(762, 16)
        LB_VacDays.Margin = New Padding(4, 0, 4, 0)
        LB_VacDays.Name = "LB_VacDays"
        LB_VacDays.Size = New Size(46, 25)
        LB_VacDays.TabIndex = 30
        LB_VacDays.Text = "Días"
        ' 
        ' TB_VacComment
        ' 
        TB_VacComment.Location = New Point(159, 140)
        TB_VacComment.Margin = New Padding(4, 5, 4, 5)
        TB_VacComment.Multiline = True
        TB_VacComment.Name = "TB_VacComment"
        TB_VacComment.Size = New Size(504, 57)
        TB_VacComment.TabIndex = 29
        ' 
        ' LB_VacComment
        ' 
        LB_VacComment.AutoSize = True
        LB_VacComment.ForeColor = SystemColors.ActiveCaptionText
        LB_VacComment.Location = New Point(17, 161)
        LB_VacComment.Margin = New Padding(4, 0, 4, 0)
        LB_VacComment.Name = "LB_VacComment"
        LB_VacComment.Size = New Size(114, 25)
        LB_VacComment.TabIndex = 28
        LB_VacComment.Text = "Comentario: "
        ' 
        ' DTP_VacDateTo
        ' 
        DTP_VacDateTo.Location = New Point(394, 47)
        DTP_VacDateTo.Margin = New Padding(4, 5, 4, 5)
        DTP_VacDateTo.Name = "DTP_VacDateTo"
        DTP_VacDateTo.Size = New Size(335, 31)
        DTP_VacDateTo.TabIndex = 27
        ' 
        ' LB_VacDateTo
        ' 
        LB_VacDateTo.AutoSize = True
        LB_VacDateTo.ForeColor = SystemColors.ActiveCaptionText
        LB_VacDateTo.Location = New Point(397, 16)
        LB_VacDateTo.Margin = New Padding(4, 0, 4, 0)
        LB_VacDateTo.Name = "LB_VacDateTo"
        LB_VacDateTo.Size = New Size(113, 25)
        LB_VacDateTo.TabIndex = 26
        LB_VacDateTo.Text = "Fecha hasta: "
        ' 
        ' LB_VacAuthorizeBy
        ' 
        LB_VacAuthorizeBy.AutoSize = True
        LB_VacAuthorizeBy.ForeColor = SystemColors.ActiveCaptionText
        LB_VacAuthorizeBy.Location = New Point(17, 96)
        LB_VacAuthorizeBy.Margin = New Padding(4, 0, 4, 0)
        LB_VacAuthorizeBy.Name = "LB_VacAuthorizeBy"
        LB_VacAuthorizeBy.Size = New Size(137, 25)
        LB_VacAuthorizeBy.TabIndex = 25
        LB_VacAuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_VacAuthorizeBy
        ' 
        TB_VacAuthorizeBy.Location = New Point(159, 93)
        TB_VacAuthorizeBy.Margin = New Padding(4, 5, 4, 5)
        TB_VacAuthorizeBy.Name = "TB_VacAuthorizeBy"
        TB_VacAuthorizeBy.Size = New Size(353, 31)
        TB_VacAuthorizeBy.TabIndex = 23
        ' 
        ' BT_VacUpd
        ' 
        BT_VacUpd.ForeColor = SystemColors.ActiveCaptionText
        BT_VacUpd.Location = New Point(1579, 160)
        BT_VacUpd.Margin = New Padding(4, 5, 4, 5)
        BT_VacUpd.Name = "BT_VacUpd"
        BT_VacUpd.Size = New Size(183, 38)
        BT_VacUpd.TabIndex = 24
        BT_VacUpd.Text = "Actualizar permiso"
        BT_VacUpd.UseVisualStyleBackColor = True
        ' 
        ' DTP_VacDateFrom
        ' 
        DTP_VacDateFrom.Location = New Point(14, 47)
        DTP_VacDateFrom.Margin = New Padding(4, 5, 4, 5)
        DTP_VacDateFrom.Name = "DTP_VacDateFrom"
        DTP_VacDateFrom.Size = New Size(335, 31)
        DTP_VacDateFrom.TabIndex = 22
        ' 
        ' LB_VacDateFrom
        ' 
        LB_VacDateFrom.AutoSize = True
        LB_VacDateFrom.ForeColor = SystemColors.ActiveCaptionText
        LB_VacDateFrom.Location = New Point(17, 16)
        LB_VacDateFrom.Margin = New Padding(4, 0, 4, 0)
        LB_VacDateFrom.Name = "LB_VacDateFrom"
        LB_VacDateFrom.Size = New Size(119, 25)
        LB_VacDateFrom.TabIndex = 21
        LB_VacDateFrom.Text = "Fecha desde: "
        ' 
        ' OP_UP_ADMNISTRATIONOFINCIDENTS
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1924, 1050)
        Controls.Add(GroupBox1)
        Controls.Add(GB_EmployeeInfo)
        Name = "OP_UP_ADMNISTRATIONOFINCIDENTS"
        Text = "Edición de permisos"
        WindowState = FormWindowState.Maximized
        GB_EmployeeInfo.ResumeLayout(False)
        GB_EmployeeInfo.PerformLayout()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        CType(DGV_Incidents, ComponentModel.ISupportInitialize).EndInit()
        TB_Incidents.ResumeLayout(False)
        TabPaidLeave.ResumeLayout(False)
        TabPaidLeave.PerformLayout()
        TabUnpaidLeave.ResumeLayout(False)
        TabUnpaidLeave.PerformLayout()
        TabVacations.ResumeLayout(False)
        TabVacations.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GB_EmployeeInfo As GroupBox
    Friend WithEvents TB_TotalPermissions As TextBox
    Friend WithEvents TB_TotalVacations As TextBox
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGV_Employees As DataGridView
    Friend WithEvents TB_Incidents As TabControl
    Friend WithEvents TabPaidLeave As TabPage
    Friend WithEvents LB_PermissionWithSalary As Label
    Friend WithEvents TB_Days As TextBox
    Friend WithEvents LB_Days As Label
    Friend WithEvents TB_Comment As TextBox
    Friend WithEvents LB_Comment As Label
    Friend WithEvents DTP_DateTo As DateTimePicker
    Friend WithEvents LB_DateTo As Label
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents DTP_DateFrom As DateTimePicker
    Friend WithEvents LB_DateFrom As Label
    Friend WithEvents TabUnpaidLeave As TabPage
    Friend WithEvents LB_PermissionWithoutSalary As Label
    Friend WithEvents TB_InDays As TextBox
    Friend WithEvents LB_InDays As Label
    Friend WithEvents TB_InComment As TextBox
    Friend WithEvents LB_InComment As Label
    Friend WithEvents DTP_InDateTo As DateTimePicker
    Friend WithEvents LB_InDateTo As Label
    Friend WithEvents LB_InAuthorizeBy As Label
    Friend WithEvents TB_InAuthorizeBy As TextBox
    Friend WithEvents BT_InUpd As Button
    Friend WithEvents DTP_InDateFrom As DateTimePicker
    Friend WithEvents LB_InDateFrom As Label
    Friend WithEvents TabVacations As TabPage
    Friend WithEvents LB_VacationsRequest As Label
    Friend WithEvents TB_VacDays As TextBox
    Friend WithEvents LB_VacDays As Label
    Friend WithEvents TB_VacComment As TextBox
    Friend WithEvents LB_VacComment As Label
    Friend WithEvents DTP_VacDateTo As DateTimePicker
    Friend WithEvents LB_VacDateTo As Label
    Friend WithEvents LB_VacAuthorizeBy As Label
    Friend WithEvents TB_VacAuthorizeBy As TextBox
    Friend WithEvents BT_VacUpd As Button
    Friend WithEvents DTP_VacDateFrom As DateTimePicker
    Friend WithEvents LB_VacDateFrom As Label
    Friend WithEvents DGV_Incidents As DataGridView
End Class
