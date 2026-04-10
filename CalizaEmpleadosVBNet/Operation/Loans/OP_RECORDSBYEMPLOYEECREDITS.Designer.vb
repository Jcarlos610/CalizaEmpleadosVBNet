<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_RECORDSBYEMPLOYEECREDITS
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
        TB_Ammount = New TextBox()
        LB_Ammount = New Label()
        CB_Discounts = New ComboBox()
        LB_Discount = New Label()
        TB_AuthorizeBy = New TextBox()
        LB_AuthorizeBy = New Label()
        TB_Comment = New TextBox()
        LB_Comment = New Label()
        CB_Credits = New ComboBox()
        LB_Type = New Label()
        DGV_EmployeeInfo = New DataGridView()
        DGV_Loans = New DataGridView()
        LB_EmployeesWithCredit = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_Loans, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(TB_Ammount)
        GroupBox1.Controls.Add(LB_Ammount)
        GroupBox1.Controls.Add(CB_Discounts)
        GroupBox1.Controls.Add(LB_Discount)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_Comment)
        GroupBox1.Controls.Add(LB_Comment)
        GroupBox1.Controls.Add(CB_Credits)
        GroupBox1.Controls.Add(LB_Type)
        GroupBox1.Controls.Add(DGV_EmployeeInfo)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Margin = New Padding(2)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(2)
        GroupBox1.Size = New Size(1485, 432)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Créditos"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(618, 389)
        BT_Register.Margin = New Padding(2)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(74, 23)
        BT_Register.TabIndex = 25
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' TB_Ammount
        ' 
        TB_Ammount.BackColor = SystemColors.Info
        TB_Ammount.Location = New Point(280, 389)
        TB_Ammount.Name = "TB_Ammount"
        TB_Ammount.Size = New Size(120, 23)
        TB_Ammount.TabIndex = 24
        ' 
        ' LB_Ammount
        ' 
        LB_Ammount.AutoSize = True
        LB_Ammount.ForeColor = SystemColors.ActiveCaptionText
        LB_Ammount.Location = New Point(281, 370)
        LB_Ammount.Name = "LB_Ammount"
        LB_Ammount.Size = New Size(102, 15)
        LB_Ammount.TabIndex = 23
        LB_Ammount.Text = "Monto de crédito:"
        ' 
        ' CB_Discounts
        ' 
        CB_Discounts.FormattingEnabled = True
        CB_Discounts.Location = New Point(20, 388)
        CB_Discounts.Name = "CB_Discounts"
        CB_Discounts.Size = New Size(222, 23)
        CB_Discounts.TabIndex = 22
        ' 
        ' LB_Discount
        ' 
        LB_Discount.AutoSize = True
        LB_Discount.ForeColor = SystemColors.ActiveCaptionText
        LB_Discount.Location = New Point(20, 370)
        LB_Discount.Name = "LB_Discount"
        LB_Discount.Size = New Size(107, 15)
        LB_Discount.TabIndex = 21
        LB_Discount.Text = "Descuento fijo por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(20, 336)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 20
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(20, 318)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 19
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_Comment
        ' 
        TB_Comment.Location = New Point(279, 293)
        TB_Comment.Multiline = True
        TB_Comment.Name = "TB_Comment"
        TB_Comment.Size = New Size(404, 70)
        TB_Comment.TabIndex = 18
        ' 
        ' LB_Comment
        ' 
        LB_Comment.AutoSize = True
        LB_Comment.ForeColor = SystemColors.ActiveCaptionText
        LB_Comment.Location = New Point(279, 269)
        LB_Comment.Name = "LB_Comment"
        LB_Comment.Size = New Size(73, 15)
        LB_Comment.TabIndex = 17
        LB_Comment.Text = "Comentario:"
        ' 
        ' CB_Credits
        ' 
        CB_Credits.FormattingEnabled = True
        CB_Credits.Location = New Point(20, 287)
        CB_Credits.Name = "CB_Credits"
        CB_Credits.Size = New Size(222, 23)
        CB_Credits.TabIndex = 16
        ' 
        ' LB_Type
        ' 
        LB_Type.AutoSize = True
        LB_Type.ForeColor = SystemColors.ActiveCaptionText
        LB_Type.Location = New Point(20, 269)
        LB_Type.Name = "LB_Type"
        LB_Type.Size = New Size(90, 15)
        LB_Type.TabIndex = 15
        LB_Type.Text = "Tipo de crédito:"
        ' 
        ' DGV_EmployeeInfo
        ' 
        DGV_EmployeeInfo.AllowUserToAddRows = False
        DGV_EmployeeInfo.AllowUserToDeleteRows = False
        DGV_EmployeeInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_EmployeeInfo.Location = New Point(18, 24)
        DGV_EmployeeInfo.Margin = New Padding(2)
        DGV_EmployeeInfo.Name = "DGV_EmployeeInfo"
        DGV_EmployeeInfo.ReadOnly = True
        DGV_EmployeeInfo.RowHeadersWidth = 62
        DGV_EmployeeInfo.Size = New Size(1441, 233)
        DGV_EmployeeInfo.TabIndex = 1
        ' 
        ' DGV_Loans
        ' 
        DGV_Loans.AllowUserToAddRows = False
        DGV_Loans.AllowUserToDeleteRows = False
        DGV_Loans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_Loans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Loans.Location = New Point(12, 510)
        DGV_Loans.Margin = New Padding(2)
        DGV_Loans.Name = "DGV_Loans"
        DGV_Loans.ReadOnly = True
        DGV_Loans.RowHeadersWidth = 62
        DGV_Loans.Size = New Size(1267, 160)
        DGV_Loans.TabIndex = 9
        ' 
        ' LB_EmployeesWithCredit
        ' 
        LB_EmployeesWithCredit.AutoSize = True
        LB_EmployeesWithCredit.Location = New Point(12, 493)
        LB_EmployeesWithCredit.Name = "LB_EmployeesWithCredit"
        LB_EmployeesWithCredit.Size = New Size(179, 15)
        LB_EmployeesWithCredit.TabIndex = 10
        LB_EmployeesWithCredit.Text = "Empleados con crédito asignado"
        ' 
        ' OP_RECORDSBYEMPLOYEECREDITS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1536, 681)
        Controls.Add(LB_EmployeesWithCredit)
        Controls.Add(DGV_Loans)
        Controls.Add(GroupBox1)
        Margin = New Padding(2)
        Name = "OP_RECORDSBYEMPLOYEECREDITS"
        Tag = ""
        Text = "Registro de nuevos créditos"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Loans, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGV_EmployeeInfo As DataGridView
    Friend WithEvents LB_Type As Label
    Friend WithEvents CB_Credits As ComboBox
    Friend WithEvents LB_Comment As Label
    Friend WithEvents TB_Comment As TextBox
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents LB_Ammount As Label
    Friend WithEvents CB_Discounts As ComboBox
    Friend WithEvents LB_Discount As Label
    Friend WithEvents TB_Ammount As TextBox
    Friend WithEvents DGV_Loans As DataGridView
    Friend WithEvents BT_Register As Button
    Friend WithEvents LB_EmployeesWithCredit As Label
End Class
