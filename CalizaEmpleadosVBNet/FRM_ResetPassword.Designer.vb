<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_ResetPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_ResetPassword))
        GroupBox1 = New GroupBox()
        TB_ConfirmPassword = New TextBox()
        LB_ConfirmPassword = New Label()
        BT_Save = New Button()
        LB_NewPassword = New Label()
        TB_UserName = New TextBox()
        LB_UserName = New Label()
        TB_NewPassword = New TextBox()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_ConfirmPassword)
        GroupBox1.Controls.Add(LB_ConfirmPassword)
        GroupBox1.Controls.Add(BT_Save)
        GroupBox1.Controls.Add(LB_NewPassword)
        GroupBox1.Controls.Add(TB_UserName)
        GroupBox1.Controls.Add(LB_UserName)
        GroupBox1.Controls.Add(TB_NewPassword)
        resources.ApplyResources(GroupBox1, "GroupBox1")
        GroupBox1.Name = "GroupBox1"
        GroupBox1.TabStop = False
        ' 
        ' TB_ConfirmPassword
        ' 
        resources.ApplyResources(TB_ConfirmPassword, "TB_ConfirmPassword")
        TB_ConfirmPassword.Name = "TB_ConfirmPassword"
        ' 
        ' LB_ConfirmPassword
        ' 
        resources.ApplyResources(LB_ConfirmPassword, "LB_ConfirmPassword")
        LB_ConfirmPassword.Name = "LB_ConfirmPassword"
        ' 
        ' BT_Save
        ' 
        resources.ApplyResources(BT_Save, "BT_Save")
        BT_Save.Name = "BT_Save"
        BT_Save.UseVisualStyleBackColor = True
        ' 
        ' LB_NewPassword
        ' 
        resources.ApplyResources(LB_NewPassword, "LB_NewPassword")
        LB_NewPassword.Name = "LB_NewPassword"
        ' 
        ' TB_UserName
        ' 
        resources.ApplyResources(TB_UserName, "TB_UserName")
        TB_UserName.Name = "TB_UserName"
        ' 
        ' LB_UserName
        ' 
        resources.ApplyResources(LB_UserName, "LB_UserName")
        LB_UserName.Name = "LB_UserName"
        ' 
        ' TB_NewPassword
        ' 
        resources.ApplyResources(TB_NewPassword, "TB_NewPassword")
        TB_NewPassword.Name = "TB_NewPassword"
        ' 
        ' FRM_ResetPassword
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FRM_ResetPassword"
        Opacity = 0.9R
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Save As Button
    Friend WithEvents LB_NewPassword As Label
    Friend WithEvents TB_UserName As TextBox
    Friend WithEvents LB_UserName As Label
    Friend WithEvents TB_NewPassword As TextBox
    Friend WithEvents TB_ConfirmPassword As TextBox
    Friend WithEvents LB_ConfirmPassword As Label
End Class
