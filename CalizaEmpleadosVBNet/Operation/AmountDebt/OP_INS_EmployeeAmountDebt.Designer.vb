<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_EmployeeAmountDebt
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
        DGV_Debt = New DataGridView()
        GroupBox1 = New GroupBox()
        TB_PeriodicDiscount = New TextBox()
        LB_PeriodicDiscount = New Label()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        TB_TotalAmount = New TextBox()
        LB_TotalAmount = New Label()
        LB_Comment = New Label()
        TB_Comment = New TextBox()
        TB_DebtCause = New TextBox()
        LBX_Suggesting = New ListBox()
        BT_Register = New Button()
        LB_DebtCause = New Label()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        TB_Employee = New TextBox()
        LB_Employee = New Label()
        LB_Title = New Label()
        CType(DGV_Debt, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DGV_Debt
        ' 
        DGV_Debt.AllowUserToAddRows = False
        DGV_Debt.AllowUserToDeleteRows = False
        DGV_Debt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Debt.Location = New Point(12, 411)
        DGV_Debt.Name = "DGV_Debt"
        DGV_Debt.ReadOnly = True
        DGV_Debt.Size = New Size(1218, 271)
        DGV_Debt.TabIndex = 5
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_PeriodicDiscount)
        GroupBox1.Controls.Add(LB_PeriodicDiscount)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_TotalAmount)
        GroupBox1.Controls.Add(LB_TotalAmount)
        GroupBox1.Controls.Add(LB_Comment)
        GroupBox1.Controls.Add(TB_Comment)
        GroupBox1.Controls.Add(TB_DebtCause)
        GroupBox1.Controls.Add(LBX_Suggesting)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(LB_DebtCause)
        GroupBox1.Controls.Add(DTP_Valid)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Controls.Add(TB_Employee)
        GroupBox1.Controls.Add(LB_Employee)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 345)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre adeudo"
        ' 
        ' TB_PeriodicDiscount
        ' 
        TB_PeriodicDiscount.BackColor = SystemColors.MenuBar
        TB_PeriodicDiscount.Location = New Point(582, 290)
        TB_PeriodicDiscount.Name = "TB_PeriodicDiscount"
        TB_PeriodicDiscount.Size = New Size(131, 23)
        TB_PeriodicDiscount.TabIndex = 23
        ' 
        ' LB_PeriodicDiscount
        ' 
        LB_PeriodicDiscount.AutoSize = True
        LB_PeriodicDiscount.Location = New Point(582, 267)
        LB_PeriodicDiscount.Name = "LB_PeriodicDiscount"
        LB_PeriodicDiscount.Size = New Size(131, 15)
        LB_PeriodicDiscount.TabIndex = 22
        LB_PeriodicDiscount.Text = "Descuento por nómina:"
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(15, 156)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 21
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(110, 148)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 20
        ' 
        ' TB_TotalAmount
        ' 
        TB_TotalAmount.BackColor = SystemColors.Info
        TB_TotalAmount.Location = New Point(441, 290)
        TB_TotalAmount.Name = "TB_TotalAmount"
        TB_TotalAmount.Size = New Size(120, 23)
        TB_TotalAmount.TabIndex = 19
        ' 
        ' LB_TotalAmount
        ' 
        LB_TotalAmount.AutoSize = True
        LB_TotalAmount.Location = New Point(441, 267)
        LB_TotalAmount.Name = "LB_TotalAmount"
        LB_TotalAmount.Size = New Size(100, 15)
        LB_TotalAmount.TabIndex = 18
        LB_TotalAmount.Text = "Cantidad a pagar:"
        ' 
        ' LB_Comment
        ' 
        LB_Comment.AutoSize = True
        LB_Comment.Location = New Point(15, 226)
        LB_Comment.Name = "LB_Comment"
        LB_Comment.Size = New Size(73, 15)
        LB_Comment.TabIndex = 14
        LB_Comment.Text = "Comentario:"
        ' 
        ' TB_Comment
        ' 
        TB_Comment.Location = New Point(15, 244)
        TB_Comment.Multiline = True
        TB_Comment.Name = "TB_Comment"
        TB_Comment.Size = New Size(404, 70)
        TB_Comment.TabIndex = 13
        ' 
        ' TB_DebtCause
        ' 
        TB_DebtCause.Location = New Point(69, 184)
        TB_DebtCause.Name = "TB_DebtCause"
        TB_DebtCause.Size = New Size(263, 23)
        TB_DebtCause.TabIndex = 12
        ' 
        ' LBX_Suggesting
        ' 
        LBX_Suggesting.FormattingEnabled = True
        LBX_Suggesting.IntegralHeight = False
        LBX_Suggesting.ItemHeight = 15
        LBX_Suggesting.Location = New Point(582, 17)
        LBX_Suggesting.Name = "LBX_Suggesting"
        LBX_Suggesting.Size = New Size(420, 34)
        LBX_Suggesting.TabIndex = 11
        LBX_Suggesting.Visible = False
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(1125, 306)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 10
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' LB_DebtCause
        ' 
        LB_DebtCause.AutoSize = True
        LB_DebtCause.Location = New Point(15, 192)
        LB_DebtCause.Name = "LB_DebtCause"
        LB_DebtCause.Size = New Size(48, 15)
        LB_DebtCause.TabIndex = 9
        LB_DebtCause.Text = "Motivo:"
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(732, 290)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(732, 267)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 6
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 116)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 124)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 78)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 86)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' TB_Employee
        ' 
        TB_Employee.Location = New Point(120, 28)
        TB_Employee.Name = "TB_Employee"
        TB_Employee.Size = New Size(435, 23)
        TB_Employee.TabIndex = 1
        ' 
        ' LB_Employee
        ' 
        LB_Employee.AutoSize = True
        LB_Employee.Location = New Point(15, 36)
        LB_Employee.Name = "LB_Employee"
        LB_Employee.Size = New Size(104, 15)
        LB_Employee.TabIndex = 0
        LB_Employee.Text = "Buscar empleado: "
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(193, 30)
        LB_Title.TabIndex = 105
        LB_Title.Text = "Registro de adeudo"
        ' 
        ' OP_INS_EmployeeAmountDebt
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 717)
        Controls.Add(LB_Title)
        Controls.Add(DGV_Debt)
        Controls.Add(GroupBox1)
        Name = "OP_INS_EmployeeAmountDebt"
        Text = "Adeudo a empresa"
        WindowState = FormWindowState.Maximized
        CType(DGV_Debt, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DGV_Debt As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_PeriodicDiscount As TextBox
    Friend WithEvents LB_PeriodicDiscount As Label
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents TB_TotalAmount As TextBox
    Friend WithEvents LB_TotalAmount As Label
    Friend WithEvents LB_Comment As Label
    Friend WithEvents TB_Comment As TextBox
    Friend WithEvents TB_DebtCause As TextBox
    Friend WithEvents LBX_Suggesting As ListBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents LB_DebtCause As Label
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents TB_Employee As TextBox
    Friend WithEvents LB_Employee As Label
    Friend WithEvents LB_Title As Label
End Class
