<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ST_UPD_Users
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
        DGV_RolesSelection = New DataGridView()
        TB_Password = New TextBox()
        LB_Password = New Label()
        TB_UserName = New TextBox()
        LB_User = New Label()
        BT_UpdateUser = New Button()
        DGV_Roles = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_RolesSelection, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_Roles, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_RolesSelection)
        GroupBox1.Controls.Add(TB_Password)
        GroupBox1.Controls.Add(LB_Password)
        GroupBox1.Controls.Add(TB_UserName)
        GroupBox1.Controls.Add(LB_User)
        GroupBox1.Controls.Add(BT_UpdateUser)
        GroupBox1.Location = New Point(12, 206)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(747, 272)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de usuario"
        ' 
        ' DGV_RolesSelection
        ' 
        DGV_RolesSelection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_RolesSelection.Location = New Point(15, 79)
        DGV_RolesSelection.Margin = New Padding(2, 2, 2, 2)
        DGV_RolesSelection.Name = "DGV_RolesSelection"
        DGV_RolesSelection.RowHeadersWidth = 62
        DGV_RolesSelection.Size = New Size(635, 180)
        DGV_RolesSelection.TabIndex = 14
        ' 
        ' TB_Password
        ' 
        TB_Password.Location = New Point(156, 49)
        TB_Password.Name = "TB_Password"
        TB_Password.PasswordChar = "*"c
        TB_Password.Size = New Size(120, 23)
        TB_Password.TabIndex = 10
        ' 
        ' LB_Password
        ' 
        LB_Password.AutoSize = True
        LB_Password.Location = New Point(156, 28)
        LB_Password.Name = "LB_Password"
        LB_Password.Size = New Size(67, 15)
        LB_Password.TabIndex = 9
        LB_Password.Text = "Contraseña"
        ' 
        ' TB_UserName
        ' 
        TB_UserName.Location = New Point(15, 49)
        TB_UserName.Name = "TB_UserName"
        TB_UserName.Size = New Size(127, 23)
        TB_UserName.TabIndex = 8
        ' 
        ' LB_User
        ' 
        LB_User.AutoSize = True
        LB_User.Location = New Point(15, 28)
        LB_User.Name = "LB_User"
        LB_User.Size = New Size(106, 15)
        LB_User.TabIndex = 7
        LB_User.Text = "Usuario de sistema"
        ' 
        ' BT_UpdateUser
        ' 
        BT_UpdateUser.Location = New Point(666, 236)
        BT_UpdateUser.Name = "BT_UpdateUser"
        BT_UpdateUser.Size = New Size(75, 23)
        BT_UpdateUser.TabIndex = 11
        BT_UpdateUser.Text = "Actualizar"
        BT_UpdateUser.UseVisualStyleBackColor = True
        ' 
        ' DGV_Roles
        ' 
        DGV_Roles.AllowUserToAddRows = False
        DGV_Roles.AllowUserToDeleteRows = False
        DGV_Roles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Roles.Location = New Point(12, 46)
        DGV_Roles.Name = "DGV_Roles"
        DGV_Roles.ReadOnly = True
        DGV_Roles.RowHeadersWidth = 62
        DGV_Roles.Size = New Size(747, 136)
        DGV_Roles.TabIndex = 14
        ' 
        ' ST_UPD_Users
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(DGV_Roles)
        Controls.Add(GroupBox1)
        Name = "ST_UPD_Users"
        Text = "Actualizar datos de usuario"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_RolesSelection, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Roles, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_Password As TextBox
    Friend WithEvents LB_Password As Label
    Friend WithEvents TB_UserName As TextBox
    Friend WithEvents LB_User As Label
    Friend WithEvents BT_UpdateUser As Button
    Friend WithEvents DGV_Roles As DataGridView
    Friend WithEvents DGV_RolesSelection As DataGridView
End Class
