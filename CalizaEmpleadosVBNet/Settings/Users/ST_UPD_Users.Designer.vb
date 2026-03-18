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
        CB_Users = New ComboBox()
        TB_Password = New TextBox()
        LB_Password = New Label()
        LB_LastName = New Label()
        TB_LastName = New TextBox()
        TB_UserName = New TextBox()
        LB_User = New Label()
        BT_UpdateUser = New Button()
        LB_Email = New Label()
        TB_FirstName = New TextBox()
        LB_FirstName = New Label()
        TB_Email = New TextBox()
        DGV_UsersList = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_UsersList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Users)
        GroupBox1.Controls.Add(TB_Password)
        GroupBox1.Controls.Add(LB_Password)
        GroupBox1.Controls.Add(LB_LastName)
        GroupBox1.Controls.Add(TB_LastName)
        GroupBox1.Controls.Add(TB_UserName)
        GroupBox1.Controls.Add(LB_User)
        GroupBox1.Controls.Add(BT_UpdateUser)
        GroupBox1.Controls.Add(LB_Email)
        GroupBox1.Controls.Add(TB_FirstName)
        GroupBox1.Controls.Add(LB_FirstName)
        GroupBox1.Controls.Add(TB_Email)
        GroupBox1.Location = New Point(17, 77)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1070, 358)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de usuario"
        ' 
        ' CB_Users
        ' 
        CB_Users.FormattingEnabled = True
        CB_Users.Location = New Point(21, 53)
        CB_Users.Margin = New Padding(4, 5, 4, 5)
        CB_Users.Name = "CB_Users"
        CB_Users.Size = New Size(315, 33)
        CB_Users.TabIndex = 14
        ' 
        ' TB_Password
        ' 
        TB_Password.Location = New Point(223, 303)
        TB_Password.Margin = New Padding(4, 5, 4, 5)
        TB_Password.Name = "TB_Password"
        TB_Password.PasswordChar = "*"c
        TB_Password.Size = New Size(170, 31)
        TB_Password.TabIndex = 10
        ' 
        ' LB_Password
        ' 
        LB_Password.AutoSize = True
        LB_Password.Location = New Point(223, 273)
        LB_Password.Margin = New Padding(4, 0, 4, 0)
        LB_Password.Name = "LB_Password"
        LB_Password.Size = New Size(101, 25)
        LB_Password.TabIndex = 9
        LB_Password.Text = "Contraseña"
        ' 
        ' LB_LastName
        ' 
        LB_LastName.AutoSize = True
        LB_LastName.Location = New Point(347, 123)
        LB_LastName.Margin = New Padding(4, 0, 4, 0)
        LB_LastName.Name = "LB_LastName"
        LB_LastName.Size = New Size(86, 25)
        LB_LastName.TabIndex = 3
        LB_LastName.Text = "Apellidos"
        ' 
        ' TB_LastName
        ' 
        TB_LastName.Location = New Point(347, 153)
        TB_LastName.Margin = New Padding(4, 5, 4, 5)
        TB_LastName.Name = "TB_LastName"
        TB_LastName.Size = New Size(364, 31)
        TB_LastName.TabIndex = 4
        ' 
        ' TB_UserName
        ' 
        TB_UserName.Location = New Point(21, 303)
        TB_UserName.Margin = New Padding(4, 5, 4, 5)
        TB_UserName.Name = "TB_UserName"
        TB_UserName.Size = New Size(180, 31)
        TB_UserName.TabIndex = 8
        ' 
        ' LB_User
        ' 
        LB_User.AutoSize = True
        LB_User.Location = New Point(21, 273)
        LB_User.Margin = New Padding(4, 0, 4, 0)
        LB_User.Name = "LB_User"
        LB_User.Size = New Size(162, 25)
        LB_User.TabIndex = 7
        LB_User.Text = "Usuario de sistema"
        ' 
        ' BT_UpdateUser
        ' 
        BT_UpdateUser.Location = New Point(940, 302)
        BT_UpdateUser.Margin = New Padding(4, 5, 4, 5)
        BT_UpdateUser.Name = "BT_UpdateUser"
        BT_UpdateUser.Size = New Size(107, 38)
        BT_UpdateUser.TabIndex = 11
        BT_UpdateUser.Text = "Actualizar"
        BT_UpdateUser.UseVisualStyleBackColor = True
        ' 
        ' LB_Email
        ' 
        LB_Email.AutoSize = True
        LB_Email.Location = New Point(21, 200)
        LB_Email.Margin = New Padding(4, 0, 4, 0)
        LB_Email.Name = "LB_Email"
        LB_Email.Size = New Size(54, 25)
        LB_Email.TabIndex = 5
        LB_Email.Text = "Email"
        ' 
        ' TB_FirstName
        ' 
        TB_FirstName.Location = New Point(21, 153)
        TB_FirstName.Margin = New Padding(4, 5, 4, 5)
        TB_FirstName.Name = "TB_FirstName"
        TB_FirstName.Size = New Size(315, 31)
        TB_FirstName.TabIndex = 2
        ' 
        ' LB_FirstName
        ' 
        LB_FirstName.AutoSize = True
        LB_FirstName.Location = New Point(21, 125)
        LB_FirstName.Margin = New Padding(4, 0, 4, 0)
        LB_FirstName.Name = "LB_FirstName"
        LB_FirstName.Size = New Size(96, 25)
        LB_FirstName.TabIndex = 1
        LB_FirstName.Text = "Nombre(s)"
        ' 
        ' TB_Email
        ' 
        TB_Email.Location = New Point(21, 230)
        TB_Email.Margin = New Padding(4, 5, 4, 5)
        TB_Email.Name = "TB_Email"
        TB_Email.Size = New Size(371, 31)
        TB_Email.TabIndex = 6
        ' 
        ' DGV_UsersList
        ' 
        DGV_UsersList.AllowUserToAddRows = False
        DGV_UsersList.AllowUserToDeleteRows = False
        DGV_UsersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_UsersList.Location = New Point(17, 445)
        DGV_UsersList.Margin = New Padding(4, 5, 4, 5)
        DGV_UsersList.Name = "DGV_UsersList"
        DGV_UsersList.ReadOnly = True
        DGV_UsersList.RowHeadersWidth = 62
        DGV_UsersList.Size = New Size(1275, 373)
        DGV_UsersList.TabIndex = 14
        ' 
        ' ST_UPD_Users
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1143, 750)
        Controls.Add(DGV_UsersList)
        Controls.Add(GroupBox1)
        Margin = New Padding(4, 5, 4, 5)
        Name = "ST_UPD_Users"
        Text = "Actualizar datos de usuario"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_UsersList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_Password As TextBox
    Friend WithEvents LB_Password As Label
    Friend WithEvents LB_LastName As Label
    Friend WithEvents TB_LastName As TextBox
    Friend WithEvents TB_UserName As TextBox
    Friend WithEvents LB_User As Label
    Friend WithEvents BT_UpdateUser As Button
    Friend WithEvents LB_Email As Label
    Friend WithEvents TB_FirstName As TextBox
    Friend WithEvents LB_FirstName As Label
    Friend WithEvents TB_Email As TextBox
    Friend WithEvents CB_Users As ComboBox
    Friend WithEvents DGV_UsersList As DataGridView
End Class
