<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_Contract
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
        CB_TypeDoc = New ComboBox()
        LB_TypeDoc = New Label()
        LBX_Suggesting = New ListBox()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        TB_Employee = New TextBox()
        LB_Employee = New Label()
        LB_Title = New Label()
        PB_Progress = New ProgressBar()
        LB_Estado = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(CB_TypeDoc)
        GroupBox1.Controls.Add(LB_TypeDoc)
        GroupBox1.Controls.Add(LBX_Suggesting)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Controls.Add(TB_Employee)
        GroupBox1.Controls.Add(LB_Employee)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 238)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(1075, 194)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(125, 28)
        BT_Register.TabIndex = 26
        BT_Register.Text = "Generar documento"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' CB_TypeDoc
        ' 
        CB_TypeDoc.FormattingEnabled = True
        CB_TypeDoc.Location = New Point(148, 158)
        CB_TypeDoc.Name = "CB_TypeDoc"
        CB_TypeDoc.Size = New Size(253, 23)
        CB_TypeDoc.TabIndex = 25
        ' 
        ' LB_TypeDoc
        ' 
        LB_TypeDoc.AutoSize = True
        LB_TypeDoc.Location = New Point(16, 166)
        LB_TypeDoc.Name = "LB_TypeDoc"
        LB_TypeDoc.Size = New Size(115, 15)
        LB_TypeDoc.TabIndex = 24
        LB_TypeDoc.Text = "Tipo de documento:"
        ' 
        ' LBX_Suggesting
        ' 
        LBX_Suggesting.FormattingEnabled = True
        LBX_Suggesting.IntegralHeight = False
        LBX_Suggesting.ItemHeight = 15
        LBX_Suggesting.Location = New Point(583, 16)
        LBX_Suggesting.Name = "LBX_Suggesting"
        LBX_Suggesting.Size = New Size(420, 34)
        LBX_Suggesting.TabIndex = 18
        LBX_Suggesting.Visible = False
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(148, 115)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 17
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(16, 123)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 16
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(148, 77)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 15
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(16, 85)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 14
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' TB_Employee
        ' 
        TB_Employee.Location = New Point(121, 27)
        TB_Employee.Name = "TB_Employee"
        TB_Employee.Size = New Size(435, 23)
        TB_Employee.TabIndex = 13
        ' 
        ' LB_Employee
        ' 
        LB_Employee.AutoSize = True
        LB_Employee.Location = New Point(16, 35)
        LB_Employee.Name = "LB_Employee"
        LB_Employee.Size = New Size(104, 15)
        LB_Employee.TabIndex = 12
        LB_Employee.Text = "Buscar empleado: "
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(234, 30)
        LB_Title.TabIndex = 110
        LB_Title.Text = "Elaboración de contrato"
        ' 
        ' PB_Progress
        ' 
        PB_Progress.Location = New Point(160, 290)
        PB_Progress.Name = "PB_Progress"
        PB_Progress.Size = New Size(1070, 10)
        PB_Progress.TabIndex = 111
        PB_Progress.Visible = False
        ' 
        ' LB_Estado
        ' 
        LB_Estado.AutoSize = True
        LB_Estado.ForeColor = SystemColors.Desktop
        LB_Estado.Location = New Point(12, 290)
        LB_Estado.Name = "LB_Estado"
        LB_Estado.Size = New Size(41, 15)
        LB_Estado.TabIndex = 112
        LB_Estado.Text = "Label1"
        LB_Estado.Visible = False
        ' 
        ' OP_INS_Contract
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(LB_Estado)
        Controls.Add(PB_Progress)
        Controls.Add(LB_Title)
        Controls.Add(GroupBox1)
        Name = "OP_INS_Contract"
        Text = "Elaboración de contrato"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LB_Title As Label
    Friend WithEvents LBX_Suggesting As ListBox
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents TB_Employee As TextBox
    Friend WithEvents LB_Employee As Label
    Friend WithEvents CB_TypeDoc As ComboBox
    Friend WithEvents LB_TypeDoc As Label
    Friend WithEvents BT_Register As Button
    Friend WithEvents PB_Progress As ProgressBar
    Friend WithEvents LB_Estado As Label
End Class
