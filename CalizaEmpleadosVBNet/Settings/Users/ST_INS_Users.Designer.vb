<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ST_INS_Users
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
        GroupBox1 = New GroupBox()
        TB_Password = New TextBox()
        LB_Password = New Label()
        TB_UserName = New TextBox()
        DGV_Roles = New DataGridView()
        LB_User = New Label()
        BT_RegisterUser = New Button()
        DGV_RolesSelection = New DataGridView()
        DGV_Employees = New DataGridView()
        DGV_Permissions = New DataGridView()
        GroupBox2 = New GroupBox()
        LB_OptionsByRole = New Label()
        LB_AvailableRoles = New Label()
        BT_SaveRoles = New Button()
        LB_Title = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_Roles, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_RolesSelection, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_Permissions, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_Password)
        GroupBox1.Controls.Add(LB_Password)
        GroupBox1.Controls.Add(TB_UserName)
        GroupBox1.Controls.Add(DGV_Roles)
        GroupBox1.Controls.Add(LB_User)
        GroupBox1.Controls.Add(BT_RegisterUser)
        GroupBox1.Location = New Point(12, 197)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1005, 207)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del nuevo usuario"
        ' 
        ' TB_Password
        ' 
        TB_Password.Location = New Point(149, 41)
        TB_Password.Name = "TB_Password"
        TB_Password.PasswordChar = "*"c
        TB_Password.Size = New Size(120, 23)
        TB_Password.TabIndex = 10
        ' 
        ' LB_Password
        ' 
        LB_Password.AutoSize = True
        LB_Password.Location = New Point(149, 23)
        LB_Password.Name = "LB_Password"
        LB_Password.Size = New Size(57, 15)
        LB_Password.TabIndex = 9
        LB_Password.Text = "Password"
        ' 
        ' TB_UserName
        ' 
        TB_UserName.Location = New Point(8, 40)
        TB_UserName.Name = "TB_UserName"
        TB_UserName.Size = New Size(127, 23)
        TB_UserName.TabIndex = 8
        ' 
        ' DGV_Roles
        ' 
        DGV_Roles.AllowUserToAddRows = False
        DGV_Roles.AllowUserToDeleteRows = False
        DGV_Roles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Roles.Location = New Point(8, 69)
        DGV_Roles.Name = "DGV_Roles"
        DGV_Roles.ReadOnly = True
        DGV_Roles.RowHeadersWidth = 62
        DGV_Roles.Size = New Size(982, 132)
        DGV_Roles.TabIndex = 13
        ' 
        ' LB_User
        ' 
        LB_User.AutoSize = True
        LB_User.Location = New Point(8, 23)
        LB_User.Name = "LB_User"
        LB_User.Size = New Size(106, 15)
        LB_User.TabIndex = 7
        LB_User.Text = "Usuario de sistema"
        ' 
        ' BT_RegisterUser
        ' 
        BT_RegisterUser.Location = New Point(838, 39)
        BT_RegisterUser.Name = "BT_RegisterUser"
        BT_RegisterUser.Size = New Size(152, 23)
        BT_RegisterUser.TabIndex = 11
        BT_RegisterUser.Text = "Registrar nuevo usuario"
        BT_RegisterUser.UseVisualStyleBackColor = True
        ' 
        ' DGV_RolesSelection
        ' 
        DGV_RolesSelection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_RolesSelection.Location = New Point(8, 39)
        DGV_RolesSelection.Margin = New Padding(2)
        DGV_RolesSelection.Name = "DGV_RolesSelection"
        DGV_RolesSelection.RowHeadersWidth = 62
        DGV_RolesSelection.Size = New Size(634, 155)
        DGV_RolesSelection.TabIndex = 14
        ' 
        ' DGV_Employees
        ' 
        DGV_Employees.AllowUserToAddRows = False
        DGV_Employees.AllowUserToDeleteRows = False
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Employees.Location = New Point(12, 46)
        DGV_Employees.Name = "DGV_Employees"
        DGV_Employees.ReadOnly = True
        DGV_Employees.RowHeadersWidth = 62
        DGV_Employees.Size = New Size(1005, 136)
        DGV_Employees.TabIndex = 14
        ' 
        ' DGV_Permissions
        ' 
        DGV_Permissions.AllowUserToAddRows = False
        DGV_Permissions.AllowUserToDeleteRows = False
        DGV_Permissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Permissions.Location = New Point(668, 37)
        DGV_Permissions.Name = "DGV_Permissions"
        DGV_Permissions.ReadOnly = True
        DGV_Permissions.RowHeadersWidth = 62
        DGV_Permissions.Size = New Size(718, 157)
        DGV_Permissions.TabIndex = 15
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(LB_OptionsByRole)
        GroupBox2.Controls.Add(LB_AvailableRoles)
        GroupBox2.Controls.Add(DGV_RolesSelection)
        GroupBox2.Controls.Add(DGV_Permissions)
        GroupBox2.Controls.Add(BT_SaveRoles)
        GroupBox2.Location = New Point(12, 410)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(1487, 208)
        GroupBox2.TabIndex = 16
        GroupBox2.TabStop = False
        GroupBox2.Text = "Asignación de roles"
        ' 
        ' LB_OptionsByRole
        ' 
        LB_OptionsByRole.AutoSize = True
        LB_OptionsByRole.Location = New Point(668, 22)
        LB_OptionsByRole.Name = "LB_OptionsByRole"
        LB_OptionsByRole.Size = New Size(124, 15)
        LB_OptionsByRole.TabIndex = 17
        LB_OptionsByRole.Text = "Permisos por cada rol:"
        ' 
        ' LB_AvailableRoles
        ' 
        LB_AvailableRoles.AutoSize = True
        LB_AvailableRoles.Location = New Point(8, 22)
        LB_AvailableRoles.Name = "LB_AvailableRoles"
        LB_AvailableRoles.Size = New Size(138, 15)
        LB_AvailableRoles.TabIndex = 16
        LB_AvailableRoles.Text = "Lista de roles disponibles"
        ' 
        ' BT_SaveRoles
        ' 
        BT_SaveRoles.Location = New Point(1390, 171)
        BT_SaveRoles.Name = "BT_SaveRoles"
        BT_SaveRoles.Size = New Size(87, 23)
        BT_SaveRoles.TabIndex = 11
        BT_SaveRoles.Text = "Registrar"
        BT_SaveRoles.UseVisualStyleBackColor = True
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(241, 30)
        LB_Title.TabIndex = 114
        LB_Title.Text = "Crear usuario de sistema"
        ' 
        ' ST_INS_Users
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1501, 667)
        Controls.Add(LB_Title)
        Controls.Add(GroupBox2)
        Controls.Add(DGV_Employees)
        Controls.Add(GroupBox1)
        Name = "ST_INS_Users"
        Text = "Crear usuario de sistema"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Roles, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_RolesSelection, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Permissions, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_UserName As TextBox
    Friend WithEvents LB_User As Label
    Friend WithEvents BT_RegisterUser As Button
    Friend WithEvents TB_Password As TextBox
    Friend WithEvents LB_Password As Label
    Friend WithEvents DGV_Roles As DataGridView
    Friend WithEvents DGV_Employees As DataGridView
    Friend WithEvents DGV_Permissions As DataGridView
    Friend WithEvents DGV_RolesSelection As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BT_SaveRoles As Button
    Friend WithEvents LB_OptionsByRole As Label
    Friend WithEvents LB_AvailableRoles As Label
    Friend WithEvents LB_Title As Label
End Class
