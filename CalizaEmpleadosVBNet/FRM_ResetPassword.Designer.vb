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
        GroupBox1 = New GroupBox()
        BT_Save = New Button()
        LB_NewPassword = New Label()
        TB_UserName = New TextBox()
        LB_UserName = New Label()
        TB_NewPassword = New TextBox()
        LB_ConfirmPassword = New Label()
        TB_ConfirmPassword = New TextBox()
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
        GroupBox1.Location = New Point(17, 77)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(661, 307)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        GroupBox1.Text = "Actualizar contraseña"
        ' 
        ' BT_Save
        ' 
        BT_Save.Location = New Point(530, 247)
        BT_Save.Margin = New Padding(4, 5, 4, 5)
        BT_Save.Name = "BT_Save"
        BT_Save.Size = New Size(107, 38)
        BT_Save.TabIndex = 8
        BT_Save.Text = "Actualizar"
        BT_Save.UseVisualStyleBackColor = True
        ' 
        ' LB_NewPassword
        ' 
        LB_NewPassword.AutoSize = True
        LB_NewPassword.Location = New Point(24, 132)
        LB_NewPassword.Margin = New Padding(4, 0, 4, 0)
        LB_NewPassword.Name = "LB_NewPassword"
        LB_NewPassword.Size = New Size(157, 25)
        LB_NewPassword.TabIndex = 7
        LB_NewPassword.Text = "Nueva contraseña:"
        ' 
        ' TB_UserName
        ' 
        TB_UserName.Location = New Point(23, 77)
        TB_UserName.Margin = New Padding(4, 5, 4, 5)
        TB_UserName.Name = "TB_UserName"
        TB_UserName.Size = New Size(315, 31)
        TB_UserName.TabIndex = 1
        ' 
        ' LB_UserName
        ' 
        LB_UserName.AutoSize = True
        LB_UserName.Location = New Point(24, 50)
        LB_UserName.Margin = New Padding(4, 0, 4, 0)
        LB_UserName.Name = "LB_UserName"
        LB_UserName.Size = New Size(76, 25)
        LB_UserName.TabIndex = 5
        LB_UserName.Text = "Usuario:"
        ' 
        ' TB_NewPassword
        ' 
        TB_NewPassword.Location = New Point(23, 155)
        TB_NewPassword.Margin = New Padding(4, 5, 4, 5)
        TB_NewPassword.Name = "TB_NewPassword"
        TB_NewPassword.Size = New Size(315, 31)
        TB_NewPassword.TabIndex = 3
        ' 
        ' LB_ConfirmPassword
        ' 
        LB_ConfirmPassword.AutoSize = True
        LB_ConfirmPassword.Location = New Point(23, 201)
        LB_ConfirmPassword.Margin = New Padding(4, 0, 4, 0)
        LB_ConfirmPassword.Name = "LB_ConfirmPassword"
        LB_ConfirmPassword.Size = New Size(186, 25)
        LB_ConfirmPassword.TabIndex = 9
        LB_ConfirmPassword.Text = "Confirmar contraseña:"
        ' 
        ' TB_ConfirmPassword
        ' 
        TB_ConfirmPassword.Location = New Point(24, 235)
        TB_ConfirmPassword.Margin = New Padding(4, 5, 4, 5)
        TB_ConfirmPassword.Name = "TB_ConfirmPassword"
        TB_ConfirmPassword.Size = New Size(315, 31)
        TB_ConfirmPassword.TabIndex = 10
        ' 
        ' FRM_ResetPassword
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1774, 1050)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FRM_ResetPassword"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Actualizar contraseña"
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
