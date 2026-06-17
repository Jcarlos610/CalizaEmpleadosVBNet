<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_InfonavitAmountManually
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
        LB_Title = New Label()
        GroupBox1 = New GroupBox()
        CB_AllDates = New ComboBox()
        TB_Amount = New TextBox()
        LB_Amount = New Label()
        BT_Register = New Button()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        DGV_Infonavit = New DataGridView()
        LB_TotalAmount = New Label()
        LB_TotalEmployees = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_Infonavit, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(257, 30)
        LB_Title.TabIndex = 108
        LB_Title.Text = "Infonavit: Registro Manual"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_AllDates)
        GroupBox1.Controls.Add(TB_Amount)
        GroupBox1.Controls.Add(LB_Amount)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 185)
        GroupBox1.TabIndex = 109
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre monto de infonavit"
        ' 
        ' CB_AllDates
        ' 
        CB_AllDates.DropDownStyle = ComboBoxStyle.DropDownList
        CB_AllDates.FormattingEnabled = True
        CB_AllDates.Location = New Point(15, 52)
        CB_AllDates.Name = "CB_AllDates"
        CB_AllDates.Size = New Size(251, 23)
        CB_AllDates.TabIndex = 16
        ' 
        ' TB_Amount
        ' 
        TB_Amount.BackColor = SystemColors.Info
        TB_Amount.Location = New Point(472, 132)
        TB_Amount.Name = "TB_Amount"
        TB_Amount.Size = New Size(79, 23)
        TB_Amount.TabIndex = 15
        ' 
        ' LB_Amount
        ' 
        LB_Amount.AutoSize = True
        LB_Amount.Location = New Point(420, 135)
        LB_Amount.Name = "LB_Amount"
        LB_Amount.Size = New Size(46, 15)
        LB_Amount.TabIndex = 14
        LB_Amount.Text = "Monto:"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(1122, 135)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 10
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(124, 15)
        Label1.TabIndex = 6
        Label1.Text = "Seleccione una fecha: "
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 127)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 135)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 90)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 98)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' DGV_Infonavit
        ' 
        DGV_Infonavit.AllowUserToAddRows = False
        DGV_Infonavit.AllowUserToDeleteRows = False
        DGV_Infonavit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Infonavit.Location = New Point(12, 249)
        DGV_Infonavit.Name = "DGV_Infonavit"
        DGV_Infonavit.ReadOnly = True
        DGV_Infonavit.Size = New Size(1218, 414)
        DGV_Infonavit.TabIndex = 110
        ' 
        ' LB_TotalAmount
        ' 
        LB_TotalAmount.AutoSize = True
        LB_TotalAmount.Location = New Point(159, 681)
        LB_TotalAmount.Name = "LB_TotalAmount"
        LB_TotalAmount.Size = New Size(105, 15)
        LB_TotalAmount.TabIndex = 112
        LB_TotalAmount.Text = "Monto Total: $0.00"
        ' 
        ' LB_TotalEmployees
        ' 
        LB_TotalEmployees.AutoSize = True
        LB_TotalEmployees.Location = New Point(12, 681)
        LB_TotalEmployees.Name = "LB_TotalEmployees"
        LB_TotalEmployees.Size = New Size(106, 15)
        LB_TotalEmployees.TabIndex = 111
        LB_TotalEmployees.Text = "Total Empleados: 0"
        ' 
        ' OP_INS_InfonavitAmountManually
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 750)
        Controls.Add(LB_TotalAmount)
        Controls.Add(LB_TotalEmployees)
        Controls.Add(DGV_Infonavit)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Name = "OP_INS_InfonavitAmountManually"
        Text = "Registro manual de montos de Infonavit"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Infonavit, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_Amount As TextBox
    Friend WithEvents LB_Amount As Label
    Friend WithEvents BT_Register As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents CB_AllDates As ComboBox
    Friend WithEvents DGV_Infonavit As DataGridView
    Friend WithEvents LB_TotalAmount As Label
    Friend WithEvents LB_TotalEmployees As Label
End Class
