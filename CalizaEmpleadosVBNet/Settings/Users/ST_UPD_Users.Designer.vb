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
        GroupBox1.SuspendLayout()
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
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(749, 238)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de usuario"
        ' 
        ' CB_Users
        ' 
        CB_Users.FormattingEnabled = True
        CB_Users.Location = New Point(15, 32)
        CB_Users.Name = "CB_Users"
        CB_Users.Size = New Size(222, 23)
        CB_Users.TabIndex = 14
        ' 
        ' TB_Password
        ' 
        TB_Password.Location = New Point(156, 182)
        TB_Password.Name = "TB_Password"
        TB_Password.PasswordChar = "*"c
        TB_Password.Size = New Size(120, 23)
        TB_Password.TabIndex = 10
        ' 
        ' LB_Password
        ' 
        LB_Password.AutoSize = True
        LB_Password.Location = New Point(156, 164)
        LB_Password.Name = "LB_Password"
        LB_Password.Size = New Size(67, 15)
        LB_Password.TabIndex = 9
        LB_Password.Text = "Contraseña"
        ' 
        ' LB_LastName
        ' 
        LB_LastName.AutoSize = True
        LB_LastName.Location = New Point(243, 74)
        LB_LastName.Name = "LB_LastName"
        LB_LastName.Size = New Size(56, 15)
        LB_LastName.TabIndex = 3
        LB_LastName.Text = "Apellidos"
        ' 
        ' TB_LastName
        ' 
        TB_LastName.Location = New Point(243, 92)
        TB_LastName.Name = "TB_LastName"
        TB_LastName.Size = New Size(256, 23)
        TB_LastName.TabIndex = 4
        ' 
        ' TB_UserName
        ' 
        TB_UserName.Location = New Point(15, 182)
        TB_UserName.Name = "TB_UserName"
        TB_UserName.Size = New Size(127, 23)
        TB_UserName.TabIndex = 8
        ' 
        ' LB_User
        ' 
        LB_User.AutoSize = True
        LB_User.Location = New Point(15, 164)
        LB_User.Name = "LB_User"
        LB_User.Size = New Size(106, 15)
        LB_User.TabIndex = 7
        LB_User.Text = "Usuario de sistema"
        ' 
        ' BT_UpdateUser
        ' 
        BT_UpdateUser.Location = New Point(658, 181)
        BT_UpdateUser.Name = "BT_UpdateUser"
        BT_UpdateUser.Size = New Size(75, 23)
        BT_UpdateUser.TabIndex = 11
        BT_UpdateUser.Text = "Actualizar"
        BT_UpdateUser.UseVisualStyleBackColor = True
        ' 
        ' LB_Email
        ' 
        LB_Email.AutoSize = True
        LB_Email.Location = New Point(15, 120)
        LB_Email.Name = "LB_Email"
        LB_Email.Size = New Size(36, 15)
        LB_Email.TabIndex = 5
        LB_Email.Text = "Email"
        ' 
        ' TB_FirstName
        ' 
        TB_FirstName.Location = New Point(15, 92)
        TB_FirstName.Name = "TB_FirstName"
        TB_FirstName.Size = New Size(222, 23)
        TB_FirstName.TabIndex = 2
        ' 
        ' LB_FirstName
        ' 
        LB_FirstName.AutoSize = True
        LB_FirstName.Location = New Point(15, 75)
        LB_FirstName.Name = "LB_FirstName"
        LB_FirstName.Size = New Size(64, 15)
        LB_FirstName.TabIndex = 1
        LB_FirstName.Text = "Nombre(s)"
        ' 
        ' TB_Email
        ' 
        TB_Email.Location = New Point(15, 138)
        TB_Email.Name = "TB_Email"
        TB_Email.Size = New Size(261, 23)
        TB_Email.TabIndex = 6
        ' 
        ' ST_UPD_Users
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(800, 450)
        Controls.Add(GroupBox1)
        Name = "ST_UPD_Users"
        Text = "Actualizar datos de usuario"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
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
End Class
