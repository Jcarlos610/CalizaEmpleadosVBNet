<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ST_UPD_Companies
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
        CB_Companies = New ComboBox()
        BT_Update = New Button()
        LB_TaxCode = New Label()
        LB_OfficialName = New Label()
        TB_CompanyName = New TextBox()
        LB_ConpanyName = New Label()
        TB_OfficialName = New TextBox()
        TB_TaxCode = New TextBox()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Companies)
        GroupBox1.Controls.Add(BT_Update)
        GroupBox1.Controls.Add(LB_TaxCode)
        GroupBox1.Controls.Add(LB_OfficialName)
        GroupBox1.Controls.Add(TB_CompanyName)
        GroupBox1.Controls.Add(LB_ConpanyName)
        GroupBox1.Controls.Add(TB_OfficialName)
        GroupBox1.Controls.Add(TB_TaxCode)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(749, 168)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de empresa"
        ' 
        ' CB_Companies
        ' 
        CB_Companies.FormattingEnabled = True
        CB_Companies.Location = New Point(16, 22)
        CB_Companies.Name = "CB_Companies"
        CB_Companies.Size = New Size(149, 23)
        CB_Companies.TabIndex = 9
        ' 
        ' BT_Update
        ' 
        BT_Update.Location = New Point(649, 127)
        BT_Update.Name = "BT_Update"
        BT_Update.Size = New Size(75, 23)
        BT_Update.TabIndex = 8
        BT_Update.Text = "Actualizar"
        BT_Update.UseVisualStyleBackColor = True
        ' 
        ' LB_TaxCode
        ' 
        LB_TaxCode.AutoSize = True
        LB_TaxCode.Location = New Point(504, 112)
        LB_TaxCode.Name = "LB_TaxCode"
        LB_TaxCode.Size = New Size(28, 15)
        LB_TaxCode.TabIndex = 7
        LB_TaxCode.Text = "RFC"
        ' 
        ' LB_OfficialName
        ' 
        LB_OfficialName.AutoSize = True
        LB_OfficialName.Location = New Point(16, 109)
        LB_OfficialName.Name = "LB_OfficialName"
        LB_OfficialName.Size = New Size(73, 15)
        LB_OfficialName.TabIndex = 6
        LB_OfficialName.Text = "Razón Social"
        ' 
        ' TB_CompanyName
        ' 
        TB_CompanyName.Location = New Point(16, 81)
        TB_CompanyName.Name = "TB_CompanyName"
        TB_CompanyName.Size = New Size(445, 23)
        TB_CompanyName.TabIndex = 1
        ' 
        ' LB_ConpanyName
        ' 
        LB_ConpanyName.AutoSize = True
        LB_ConpanyName.Location = New Point(16, 64)
        LB_ConpanyName.Name = "LB_ConpanyName"
        LB_ConpanyName.Size = New Size(115, 15)
        LB_ConpanyName.TabIndex = 5
        LB_ConpanyName.Text = "Nombre de empresa"
        ' 
        ' TB_OfficialName
        ' 
        TB_OfficialName.Location = New Point(16, 127)
        TB_OfficialName.Name = "TB_OfficialName"
        TB_OfficialName.Size = New Size(445, 23)
        TB_OfficialName.TabIndex = 2
        ' 
        ' TB_TaxCode
        ' 
        TB_TaxCode.Location = New Point(504, 127)
        TB_TaxCode.Name = "TB_TaxCode"
        TB_TaxCode.Size = New Size(100, 23)
        TB_TaxCode.TabIndex = 3
        ' 
        ' ST_UPD_Companies
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(800, 450)
        Controls.Add(GroupBox1)
        Name = "ST_UPD_Companies"
        Text = "Actualizar Empresa"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Update As Button
    Friend WithEvents LB_TaxCode As Label
    Friend WithEvents LB_OfficialName As Label
    Friend WithEvents TB_CompanyName As TextBox
    Friend WithEvents LB_ConpanyName As Label
    Friend WithEvents TB_OfficialName As TextBox
    Friend WithEvents TB_TaxCode As TextBox
    Friend WithEvents CB_Companies As ComboBox
End Class
