<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ST_UPD_Roles
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
        CB_Status = New CheckBox()
        CB_AllRoles = New ComboBox()
        BT_Update = New Button()
        LB_AuthorizeBy = New Label()
        LB_Description = New Label()
        TB_RoleName = New TextBox()
        LB_RoleName = New Label()
        TB_Description = New TextBox()
        TB_AuthorizeBy = New TextBox()
        GroupBox2 = New GroupBox()
        CB_Forms = New ComboBox()
        BT_AddPermission = New Button()
        Label2 = New Label()
        TB_FormDescription = New TextBox()
        DGV_Permissions = New DataGridView()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(DGV_Permissions, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Controls.Add(CB_AllRoles)
        GroupBox1.Controls.Add(BT_Update)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_RoleName)
        GroupBox1.Controls.Add(LB_RoleName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1354, 182)
        GroupBox1.TabIndex = 13
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre rol"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(1279, 22)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(58, 19)
        CB_Status.TabIndex = 17
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' CB_AllRoles
        ' 
        CB_AllRoles.FormattingEnabled = True
        CB_AllRoles.Location = New Point(16, 22)
        CB_AllRoles.Name = "CB_AllRoles"
        CB_AllRoles.Size = New Size(222, 23)
        CB_AllRoles.TabIndex = 0
        ' 
        ' BT_Update
        ' 
        BT_Update.Location = New Point(1262, 153)
        BT_Update.Name = "BT_Update"
        BT_Update.Size = New Size(75, 23)
        BT_Update.TabIndex = 8
        BT_Update.Text = "Actualizar"
        BT_Update.UseVisualStyleBackColor = True
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(18, 115)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(256, 65)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 6
        LB_Description.Text = "Descripción"
        ' 
        ' TB_RoleName
        ' 
        TB_RoleName.Location = New Point(16, 81)
        TB_RoleName.Name = "TB_RoleName"
        TB_RoleName.Size = New Size(222, 23)
        TB_RoleName.TabIndex = 1
        ' 
        ' LB_RoleName
        ' 
        LB_RoleName.AutoSize = True
        LB_RoleName.Location = New Point(18, 67)
        LB_RoleName.Name = "LB_RoleName"
        LB_RoleName.Size = New Size(87, 15)
        LB_RoleName.TabIndex = 5
        LB_RoleName.Text = "Nombre del rol"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(254, 81)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 2
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(16, 128)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 3
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(CB_Forms)
        GroupBox2.Controls.Add(BT_AddPermission)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(TB_FormDescription)
        GroupBox2.Location = New Point(12, 238)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(526, 191)
        GroupBox2.TabIndex = 15
        GroupBox2.TabStop = False
        GroupBox2.Text = "Asignar permisos"
        ' 
        ' CB_Forms
        ' 
        CB_Forms.FormattingEnabled = True
        CB_Forms.Location = New Point(16, 22)
        CB_Forms.Name = "CB_Forms"
        CB_Forms.Size = New Size(405, 23)
        CB_Forms.TabIndex = 0
        ' 
        ' BT_AddPermission
        ' 
        BT_AddPermission.Location = New Point(446, 161)
        BT_AddPermission.Name = "BT_AddPermission"
        BT_AddPermission.Size = New Size(75, 23)
        BT_AddPermission.TabIndex = 8
        BT_AddPermission.Text = "Asignar"
        BT_AddPermission.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(18, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 15)
        Label2.TabIndex = 6
        Label2.Text = "Descripción"
        ' 
        ' TB_FormDescription
        ' 
        TB_FormDescription.Location = New Point(18, 70)
        TB_FormDescription.Multiline = True
        TB_FormDescription.Name = "TB_FormDescription"
        TB_FormDescription.Size = New Size(404, 70)
        TB_FormDescription.TabIndex = 2
        ' 
        ' DGV_Permissions
        ' 
        DGV_Permissions.AllowUserToAddRows = False
        DGV_Permissions.AllowUserToDeleteRows = False
        DGV_Permissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Permissions.Location = New Point(559, 238)
        DGV_Permissions.Name = "DGV_Permissions"
        DGV_Permissions.ReadOnly = True
        DGV_Permissions.RowHeadersWidth = 62
        DGV_Permissions.Size = New Size(807, 191)
        DGV_Permissions.TabIndex = 16
        ' 
        ' ST_UPD_Roles
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1454, 630)
        Controls.Add(DGV_Permissions)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Margin = New Padding(2, 2, 2, 2)
        Name = "ST_UPD_Roles"
        Text = "Actualizar Rol"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(DGV_Permissions, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CB_Status As CheckBox
    Friend WithEvents CB_AllRoles As ComboBox
    Friend WithEvents BT_Update As Button
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_RoleName As TextBox
    Friend WithEvents LB_RoleName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CB_Forms As ComboBox
    Friend WithEvents BT_AddPermission As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_FormDescription As TextBox
    Friend WithEvents DGV_Permissions As DataGridView
End Class
