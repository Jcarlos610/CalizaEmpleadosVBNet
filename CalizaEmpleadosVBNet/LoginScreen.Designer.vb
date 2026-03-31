<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginScreen))
        LB_User = New Label()
        TB_UserName = New TextBox()
        LB_Password = New Label()
        TB_Password = New TextBox()
        BT_Access = New Button()
        PictureBox1 = New PictureBox()
        LB_Title = New Label()
        LBL_ResetPassword = New LinkLabel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_User
        ' 
        resources.ApplyResources(LB_User, "LB_User")
        LB_User.BackColor = SystemColors.ButtonHighlight
        LB_User.Name = "LB_User"
        ' 
        ' TB_UserName
        ' 
        resources.ApplyResources(TB_UserName, "TB_UserName")
        TB_UserName.Name = "TB_UserName"
        ' 
        ' LB_Password
        ' 
        resources.ApplyResources(LB_Password, "LB_Password")
        LB_Password.BackColor = SystemColors.ButtonHighlight
        LB_Password.Name = "LB_Password"
        ' 
        ' TB_Password
        ' 
        resources.ApplyResources(TB_Password, "TB_Password")
        TB_Password.Name = "TB_Password"
        ' 
        ' BT_Access
        ' 
        resources.ApplyResources(BT_Access, "BT_Access")
        BT_Access.Name = "BT_Access"
        BT_Access.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        resources.ApplyResources(PictureBox1, "PictureBox1")
        PictureBox1.Name = "PictureBox1"
        PictureBox1.TabStop = False
        ' 
        ' LB_Title
        ' 
        resources.ApplyResources(LB_Title, "LB_Title")
        LB_Title.Name = "LB_Title"
        ' 
        ' LBL_ResetPassword
        ' 
        resources.ApplyResources(LBL_ResetPassword, "LBL_ResetPassword")
        LBL_ResetPassword.LinkColor = Color.MediumBlue
        LBL_ResetPassword.Name = "LBL_ResetPassword"
        LBL_ResetPassword.TabStop = True
        LBL_ResetPassword.VisitedLinkColor = SystemColors.ControlDarkDark
        ' 
        ' LoginScreen
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ControlBox = False
        Controls.Add(LBL_ResetPassword)
        Controls.Add(LB_Title)
        Controls.Add(BT_Access)
        Controls.Add(LB_User)
        Controls.Add(TB_Password)
        Controls.Add(TB_UserName)
        Controls.Add(LB_Password)
        Controls.Add(PictureBox1)
        Name = "LoginScreen"
        ShowInTaskbar = False
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_User As Label
    Friend WithEvents TB_UserName As TextBox
    Friend WithEvents LB_Password As Label
    Friend WithEvents TB_Password As TextBox
    Friend WithEvents BT_Access As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LB_Title As Label
    Friend WithEvents LBL_ResetPassword As LinkLabel
End Class
