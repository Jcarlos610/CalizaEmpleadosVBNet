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
        LB_User = New Label()
        BT_RegisterUser = New Button()
        DGV_RolesSelection = New DataGridView()
        DGV_Roles = New DataGridView()
        DGV_Employees = New DataGridView()
        DGV_Permissions = New DataGridView()
        GroupBox2 = New GroupBox()
        BT_SaveRoles = New Button()
        GroupBox1.SuspendLayout()
        CType(DGV_RolesSelection, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_Roles, ComponentModel.ISupportInitialize).BeginInit()
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
        GroupBox1.Controls.Add(LB_User)
        GroupBox1.Controls.Add(BT_RegisterUser)
        GroupBox1.Location = New Point(17, 344)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(620, 174)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de usuario"
        ' 
        ' TB_Password
        ' 
        TB_Password.Location = New Point(223, 83)
        TB_Password.Margin = New Padding(4, 5, 4, 5)
        TB_Password.Name = "TB_Password"
        TB_Password.PasswordChar = "*"c
        TB_Password.Size = New Size(170, 31)
        TB_Password.TabIndex = 10
        ' 
        ' LB_Password
        ' 
        LB_Password.AutoSize = True
        LB_Password.Location = New Point(223, 53)
        LB_Password.Margin = New Padding(4, 0, 4, 0)
        LB_Password.Name = "LB_Password"
        LB_Password.Size = New Size(87, 25)
        LB_Password.TabIndex = 9
        LB_Password.Text = "Password"
        ' 
        ' TB_UserName
        ' 
        TB_UserName.Location = New Point(21, 82)
        TB_UserName.Margin = New Padding(4, 5, 4, 5)
        TB_UserName.Name = "TB_UserName"
        TB_UserName.Size = New Size(180, 31)
        TB_UserName.TabIndex = 8
        ' 
        ' LB_User
        ' 
        LB_User.AutoSize = True
        LB_User.Location = New Point(21, 53)
        LB_User.Margin = New Padding(4, 0, 4, 0)
        LB_User.Name = "LB_User"
        LB_User.Size = New Size(162, 25)
        LB_User.TabIndex = 7
        LB_User.Text = "Usuario de sistema"
        ' 
        ' BT_RegisterUser
        ' 
        BT_RegisterUser.Location = New Point(502, 121)
        BT_RegisterUser.Margin = New Padding(4, 5, 4, 5)
        BT_RegisterUser.Name = "BT_RegisterUser"
        BT_RegisterUser.Size = New Size(107, 38)
        BT_RegisterUser.TabIndex = 11
        BT_RegisterUser.Text = "Registrar"
        BT_RegisterUser.UseVisualStyleBackColor = True
        ' 
        ' DGV_RolesSelection
        ' 
        DGV_RolesSelection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_RolesSelection.Location = New Point(21, 48)
        DGV_RolesSelection.Name = "DGV_RolesSelection"
        DGV_RolesSelection.RowHeadersWidth = 62
        DGV_RolesSelection.Size = New Size(372, 226)
        DGV_RolesSelection.TabIndex = 14
        ' 
        ' DGV_Roles
        ' 
        DGV_Roles.AllowUserToAddRows = False
        DGV_Roles.AllowUserToDeleteRows = False
        DGV_Roles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Roles.Location = New Point(668, 335)
        DGV_Roles.Margin = New Padding(4, 5, 4, 5)
        DGV_Roles.Name = "DGV_Roles"
        DGV_Roles.ReadOnly = True
        DGV_Roles.RowHeadersWidth = 62
        DGV_Roles.Size = New Size(785, 183)
        DGV_Roles.TabIndex = 13
        ' 
        ' DGV_Employees
        ' 
        DGV_Employees.AllowUserToAddRows = False
        DGV_Employees.AllowUserToDeleteRows = False
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Employees.Location = New Point(17, 77)
        DGV_Employees.Margin = New Padding(4, 5, 4, 5)
        DGV_Employees.Name = "DGV_Employees"
        DGV_Employees.ReadOnly = True
        DGV_Employees.RowHeadersWidth = 62
        DGV_Employees.Size = New Size(1436, 226)
        DGV_Employees.TabIndex = 14
        ' 
        ' DGV_Permissions
        ' 
        DGV_Permissions.AllowUserToAddRows = False
        DGV_Permissions.AllowUserToDeleteRows = False
        DGV_Permissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Permissions.Location = New Point(668, 549)
        DGV_Permissions.Margin = New Padding(4, 5, 4, 5)
        DGV_Permissions.Name = "DGV_Permissions"
        DGV_Permissions.ReadOnly = True
        DGV_Permissions.RowHeadersWidth = 62
        DGV_Permissions.Size = New Size(785, 262)
        DGV_Permissions.TabIndex = 15
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(DGV_RolesSelection)
        GroupBox2.Controls.Add(BT_SaveRoles)
        GroupBox2.Location = New Point(17, 537)
        GroupBox2.Margin = New Padding(4, 5, 4, 5)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4, 5, 4, 5)
        GroupBox2.Size = New Size(620, 293)
        GroupBox2.TabIndex = 16
        GroupBox2.TabStop = False
        GroupBox2.Text = "Asignar rol"
        ' 
        ' BT_SaveRoles
        ' 
        BT_SaveRoles.Location = New Point(493, 236)
        BT_SaveRoles.Margin = New Padding(4, 5, 4, 5)
        BT_SaveRoles.Name = "BT_SaveRoles"
        BT_SaveRoles.Size = New Size(107, 38)
        BT_SaveRoles.TabIndex = 11
        BT_SaveRoles.Text = "Registrar"
        BT_SaveRoles.UseVisualStyleBackColor = True
        ' 
        ' ST_INS_Users
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1774, 1050)
        Controls.Add(GroupBox2)
        Controls.Add(DGV_Permissions)
        Controls.Add(DGV_Employees)
        Controls.Add(DGV_Roles)
        Controls.Add(GroupBox1)
        Margin = New Padding(4, 5, 4, 5)
        Name = "ST_INS_Users"
        Text = "Crear usuario de sistema"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_RolesSelection, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Roles, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Permissions, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        ResumeLayout(False)
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
End Class
