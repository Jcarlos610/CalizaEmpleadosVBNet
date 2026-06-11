<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_EmployeeAmountDebtPayments
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
        GroupBox3 = New GroupBox()
        BT_RegisterPayment = New Button()
        TB_PaymentAmount = New TextBox()
        LB_ManualInstalment = New Label()
        GroupBox2 = New GroupBox()
        DGV_DetailPayments = New DataGridView()
        GroupBox1 = New GroupBox()
        DGV_EmployeeDebts = New DataGridView()
        LB_Title = New Label()
        GB_DebtInformation = New GroupBox()
        LB_SelectEmployee = New Label()
        DGV_GlobalDebts = New DataGridView()
        LB_Accumulated = New Label()
        LB_Balnce = New Label()
        GroupBox3.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(DGV_DetailPayments, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(DGV_EmployeeDebts, ComponentModel.ISupportInitialize).BeginInit()
        GB_DebtInformation.SuspendLayout()
        CType(DGV_GlobalDebts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(BT_RegisterPayment)
        GroupBox3.Controls.Add(TB_PaymentAmount)
        GroupBox3.Controls.Add(LB_ManualInstalment)
        GroupBox3.Location = New Point(12, 728)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(392, 71)
        GroupBox3.TabIndex = 116
        GroupBox3.TabStop = False
        GroupBox3.Text = "Registrar Nuevo Abono"
        ' 
        ' BT_RegisterPayment
        ' 
        BT_RegisterPayment.Location = New Point(248, 28)
        BT_RegisterPayment.Margin = New Padding(2)
        BT_RegisterPayment.Name = "BT_RegisterPayment"
        BT_RegisterPayment.Size = New Size(111, 23)
        BT_RegisterPayment.TabIndex = 7
        BT_RegisterPayment.Text = "Registrar Monto"
        BT_RegisterPayment.UseVisualStyleBackColor = True
        ' 
        ' TB_PaymentAmount
        ' 
        TB_PaymentAmount.BackColor = SystemColors.Info
        TB_PaymentAmount.Location = New Point(104, 28)
        TB_PaymentAmount.Name = "TB_PaymentAmount"
        TB_PaymentAmount.Size = New Size(115, 23)
        TB_PaymentAmount.TabIndex = 6
        ' 
        ' LB_ManualInstalment
        ' 
        LB_ManualInstalment.AutoSize = True
        LB_ManualInstalment.Location = New Point(5, 32)
        LB_ManualInstalment.Margin = New Padding(2, 0, 2, 0)
        LB_ManualInstalment.Name = "LB_ManualInstalment"
        LB_ManualInstalment.Size = New Size(89, 15)
        LB_ManualInstalment.TabIndex = 5
        LB_ManualInstalment.Text = "Abono manual:"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(DGV_DetailPayments)
        GroupBox2.Location = New Point(429, 728)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(894, 302)
        GroupBox2.TabIndex = 115
        GroupBox2.TabStop = False
        GroupBox2.Text = "Historial de abonos por empleado"
        ' 
        ' DGV_DetailPayments
        ' 
        DGV_DetailPayments.AllowUserToAddRows = False
        DGV_DetailPayments.AllowUserToDeleteRows = False
        DGV_DetailPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_DetailPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DetailPayments.Location = New Point(18, 32)
        DGV_DetailPayments.Margin = New Padding(2)
        DGV_DetailPayments.Name = "DGV_DetailPayments"
        DGV_DetailPayments.ReadOnly = True
        DGV_DetailPayments.RowHeadersWidth = 62
        DGV_DetailPayments.Size = New Size(846, 245)
        DGV_DetailPayments.TabIndex = 0
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_EmployeeDebts)
        GroupBox1.Location = New Point(12, 409)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1311, 302)
        GroupBox1.TabIndex = 114
        GroupBox1.TabStop = False
        GroupBox1.Text = "Adeudos específicos del empleado seleccionado"
        ' 
        ' DGV_EmployeeDebts
        ' 
        DGV_EmployeeDebts.AllowUserToAddRows = False
        DGV_EmployeeDebts.AllowUserToDeleteRows = False
        DGV_EmployeeDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_EmployeeDebts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_EmployeeDebts.Location = New Point(18, 32)
        DGV_EmployeeDebts.Margin = New Padding(2)
        DGV_EmployeeDebts.Name = "DGV_EmployeeDebts"
        DGV_EmployeeDebts.ReadOnly = True
        DGV_EmployeeDebts.RowHeadersWidth = 62
        DGV_EmployeeDebts.Size = New Size(1263, 245)
        DGV_EmployeeDebts.TabIndex = 0
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(407, 30)
        LB_Title.TabIndex = 113
        LB_Title.Text = "Registro de abonos a adeudos de empresa"
        ' 
        ' GB_DebtInformation
        ' 
        GB_DebtInformation.Controls.Add(LB_SelectEmployee)
        GB_DebtInformation.Controls.Add(DGV_GlobalDebts)
        GB_DebtInformation.Location = New Point(12, 46)
        GB_DebtInformation.Name = "GB_DebtInformation"
        GB_DebtInformation.Size = New Size(1311, 346)
        GB_DebtInformation.TabIndex = 112
        GB_DebtInformation.TabStop = False
        GB_DebtInformation.Text = "Información sobre adeudo a empresa"
        ' 
        ' LB_SelectEmployee
        ' 
        LB_SelectEmployee.AutoSize = True
        LB_SelectEmployee.ForeColor = SystemColors.ActiveCaptionText
        LB_SelectEmployee.Location = New Point(18, 31)
        LB_SelectEmployee.Name = "LB_SelectEmployee"
        LB_SelectEmployee.Size = New Size(179, 15)
        LB_SelectEmployee.TabIndex = 14
        LB_SelectEmployee.Text = "Saldos pendientes por empleado"
        ' 
        ' DGV_GlobalDebts
        ' 
        DGV_GlobalDebts.AllowUserToAddRows = False
        DGV_GlobalDebts.AllowUserToDeleteRows = False
        DGV_GlobalDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_GlobalDebts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_GlobalDebts.Location = New Point(18, 49)
        DGV_GlobalDebts.Margin = New Padding(2)
        DGV_GlobalDebts.Name = "DGV_GlobalDebts"
        DGV_GlobalDebts.ReadOnly = True
        DGV_GlobalDebts.RowHeadersWidth = 62
        DGV_GlobalDebts.Size = New Size(1263, 278)
        DGV_GlobalDebts.TabIndex = 0
        ' 
        ' LB_Accumulated
        ' 
        LB_Accumulated.AutoSize = True
        LB_Accumulated.Location = New Point(12, 817)
        LB_Accumulated.Name = "LB_Accumulated"
        LB_Accumulated.Size = New Size(165, 15)
        LB_Accumulated.TabIndex = 117
        LB_Accumulated.Text = "Acumulado por abonos: $0.00"
        ' 
        ' LB_Balnce
        ' 
        LB_Balnce.AutoSize = True
        LB_Balnce.Location = New Point(260, 817)
        LB_Balnce.Name = "LB_Balnce"
        LB_Balnce.Size = New Size(69, 15)
        LB_Balnce.TabIndex = 118
        LB_Balnce.Text = "Saldo: $0.00"
        ' 
        ' OP_INS_EmployeeAmountDebtPayments
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1374, 1051)
        Controls.Add(LB_Balnce)
        Controls.Add(LB_Accumulated)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Controls.Add(GB_DebtInformation)
        Name = "OP_INS_EmployeeAmountDebtPayments"
        Text = "Registro de abonos"
        WindowState = FormWindowState.Maximized
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox2.ResumeLayout(False)
        CType(DGV_DetailPayments, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        CType(DGV_EmployeeDebts, ComponentModel.ISupportInitialize).EndInit()
        GB_DebtInformation.ResumeLayout(False)
        GB_DebtInformation.PerformLayout()
        CType(DGV_GlobalDebts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BT_RegisterPayment As Button
    Friend WithEvents TB_PaymentAmount As TextBox
    Friend WithEvents LB_ManualInstalment As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DGV_DetailPayments As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGV_EmployeeDebts As DataGridView
    Friend WithEvents LB_Title As Label
    Friend WithEvents GB_DebtInformation As GroupBox
    Friend WithEvents LB_SelectEmployee As Label
    Friend WithEvents DGV_GlobalDebts As DataGridView
    Friend WithEvents LB_Accumulated As Label
    Friend WithEvents LB_Balnce As Label
End Class
