<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ST_INS_Roles
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
        BT_Register = New Button()
        LB_AuthorizeBy = New Label()
        LB_Description = New Label()
        TB_RoleName = New TextBox()
        LB_RoleName = New Label()
        TB_Description = New TextBox()
        TB_AuthorizeBy = New TextBox()
        DGV_RoleList = New DataGridView()
        GroupBox2 = New GroupBox()
        CB_Forms = New ComboBox()
        BT_Assing = New Button()
        Label2 = New Label()
        TB_FormDescription = New TextBox()
        DGV_Permissions = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_RoleList, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        CType(DGV_Permissions, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_RoleName)
        GroupBox1.Controls.Add(LB_RoleName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Location = New Point(17, 77)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1216, 222)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre rol"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(1094, 171)
        BT_Register.Margin = New Padding(4, 5, 4, 5)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(107, 38)
        BT_Register.TabIndex = 8
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(25, 134)
        LB_AuthorizeBy.Margin = New Padding(4, 0, 4, 0)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(137, 25)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(365, 51)
        LB_Description.Margin = New Padding(4, 0, 4, 0)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(104, 25)
        LB_Description.TabIndex = 6
        LB_Description.Text = "Descripción"
        ' 
        ' TB_RoleName
        ' 
        TB_RoleName.Location = New Point(23, 77)
        TB_RoleName.Margin = New Padding(4, 5, 4, 5)
        TB_RoleName.Name = "TB_RoleName"
        TB_RoleName.Size = New Size(315, 31)
        TB_RoleName.TabIndex = 1
        ' 
        ' LB_RoleName
        ' 
        LB_RoleName.AutoSize = True
        LB_RoleName.Location = New Point(25, 52)
        LB_RoleName.Margin = New Padding(4, 0, 4, 0)
        LB_RoleName.Name = "LB_RoleName"
        LB_RoleName.Size = New Size(133, 25)
        LB_RoleName.TabIndex = 5
        LB_RoleName.Text = "Nombre del rol"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(363, 77)
        TB_Description.Margin = New Padding(4, 5, 4, 5)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(575, 114)
        TB_Description.TabIndex = 2
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(23, 155)
        TB_AuthorizeBy.Margin = New Padding(4, 5, 4, 5)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(315, 31)
        TB_AuthorizeBy.TabIndex = 3
        ' 
        ' DGV_RoleList
        ' 
        DGV_RoleList.AllowUserToAddRows = False
        DGV_RoleList.AllowUserToDeleteRows = False
        DGV_RoleList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_RoleList.Location = New Point(17, 313)
        DGV_RoleList.Margin = New Padding(4, 5, 4, 5)
        DGV_RoleList.Name = "DGV_RoleList"
        DGV_RoleList.ReadOnly = True
        DGV_RoleList.RowHeadersWidth = 62
        DGV_RoleList.Size = New Size(1226, 260)
        DGV_RoleList.TabIndex = 12
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(CB_Forms)
        GroupBox2.Controls.Add(BT_Assing)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(TB_FormDescription)
        GroupBox2.Location = New Point(17, 606)
        GroupBox2.Margin = New Padding(4, 5, 4, 5)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4, 5, 4, 5)
        GroupBox2.Size = New Size(748, 335)
        GroupBox2.TabIndex = 14
        GroupBox2.TabStop = False
        GroupBox2.Text = "Asignar permisos"
        ' 
        ' CB_Forms
        ' 
        CB_Forms.FormattingEnabled = True
        CB_Forms.Location = New Point(23, 48)
        CB_Forms.Name = "CB_Forms"
        CB_Forms.Size = New Size(410, 33)
        CB_Forms.TabIndex = 18
        ' 
        ' BT_Assing
        ' 
        BT_Assing.Location = New Point(621, 270)
        BT_Assing.Margin = New Padding(4, 5, 4, 5)
        BT_Assing.Name = "BT_Assing"
        BT_Assing.Size = New Size(107, 38)
        BT_Assing.TabIndex = 17
        BT_Assing.Text = "Asignar"
        BT_Assing.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(23, 99)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 25)
        Label2.TabIndex = 6
        Label2.Text = "Descripción"
        ' 
        ' TB_FormDescription
        ' 
        TB_FormDescription.Location = New Point(23, 135)
        TB_FormDescription.Margin = New Padding(4, 5, 4, 5)
        TB_FormDescription.Multiline = True
        TB_FormDescription.Name = "TB_FormDescription"
        TB_FormDescription.Size = New Size(575, 114)
        TB_FormDescription.TabIndex = 2
        ' 
        ' DGV_Permissions
        ' 
        DGV_Permissions.AllowUserToAddRows = False
        DGV_Permissions.AllowUserToDeleteRows = False
        DGV_Permissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Permissions.Location = New Point(793, 606)
        DGV_Permissions.Margin = New Padding(4, 5, 4, 5)
        DGV_Permissions.Name = "DGV_Permissions"
        DGV_Permissions.ReadOnly = True
        DGV_Permissions.RowHeadersWidth = 62
        DGV_Permissions.Size = New Size(450, 335)
        DGV_Permissions.TabIndex = 15
        ' 
        ' ST_INS_Roles
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1774, 1050)
        Controls.Add(DGV_Permissions)
        Controls.Add(GroupBox2)
        Controls.Add(DGV_RoleList)
        Controls.Add(GroupBox1)
        Name = "ST_INS_Roles"
        Text = "Creación de roles"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_RoleList, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(DGV_Permissions, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_RoleName As TextBox
    Friend WithEvents LB_RoleName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents DGV_RoleList As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_FormDescription As TextBox
    Friend WithEvents DGV_Permissions As DataGridView
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents BT_Assing As Button
    Friend WithEvents CB_Forms As ComboBox
End Class
