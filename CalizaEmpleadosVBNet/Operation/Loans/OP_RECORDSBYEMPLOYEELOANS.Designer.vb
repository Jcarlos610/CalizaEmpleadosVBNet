<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_RECORDSBYEMPLOYEELOANS
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
        LB_ManualInstalment = New Label()
        TB_ManualInstalment = New TextBox()
        DGV_DetailInstalment = New DataGridView()
        BT_Register = New Button()
        DGV_EmployeeInfo = New DataGridView()
        DGV_Loans = New DataGridView()
        TB_TotalLoans = New TextBox()
        TB_balance = New TextBox()
        LB_TotalLoans = New Label()
        LB_balance = New Label()
        GB_SavingInformation = New GroupBox()
        Label2 = New Label()
        Label1 = New Label()
        LB_SelectEmployee = New Label()
        CType(DGV_DetailInstalment, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_Loans, ComponentModel.ISupportInitialize).BeginInit()
        GB_SavingInformation.SuspendLayout()
        SuspendLayout()
        ' 
        ' LB_ManualInstalment
        ' 
        LB_ManualInstalment.AutoSize = True
        LB_ManualInstalment.Location = New Point(24, 633)
        LB_ManualInstalment.Name = "LB_ManualInstalment"
        LB_ManualInstalment.Size = New Size(134, 25)
        LB_ManualInstalment.TabIndex = 2
        LB_ManualInstalment.Text = "Abono manual:"
        ' 
        ' TB_ManualInstalment
        ' 
        TB_ManualInstalment.BackColor = SystemColors.Info
        TB_ManualInstalment.Location = New Point(165, 627)
        TB_ManualInstalment.Margin = New Padding(4, 5, 4, 5)
        TB_ManualInstalment.Name = "TB_ManualInstalment"
        TB_ManualInstalment.Size = New Size(141, 31)
        TB_ManualInstalment.TabIndex = 3
        ' 
        ' DGV_DetailInstalment
        ' 
        DGV_DetailInstalment.AllowUserToAddRows = False
        DGV_DetailInstalment.AllowUserToDeleteRows = False
        DGV_DetailInstalment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_DetailInstalment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DetailInstalment.Location = New Point(25, 730)
        DGV_DetailInstalment.Name = "DGV_DetailInstalment"
        DGV_DetailInstalment.ReadOnly = True
        DGV_DetailInstalment.RowHeadersWidth = 62
        DGV_DetailInstalment.Size = New Size(826, 200)
        DGV_DetailInstalment.TabIndex = 1
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(332, 623)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(159, 38)
        BT_Register.TabIndex = 4
        BT_Register.Text = "Registrar Monto"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' DGV_EmployeeInfo
        ' 
        DGV_EmployeeInfo.AllowUserToAddRows = False
        DGV_EmployeeInfo.AllowUserToDeleteRows = False
        DGV_EmployeeInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_EmployeeInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_EmployeeInfo.Location = New Point(25, 91)
        DGV_EmployeeInfo.Name = "DGV_EmployeeInfo"
        DGV_EmployeeInfo.ReadOnly = True
        DGV_EmployeeInfo.RowHeadersWidth = 62
        DGV_EmployeeInfo.Size = New Size(826, 251)
        DGV_EmployeeInfo.TabIndex = 0
        ' 
        ' DGV_Loans
        ' 
        DGV_Loans.AllowUserToAddRows = False
        DGV_Loans.AllowUserToDeleteRows = False
        DGV_Loans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Loans.Location = New Point(25, 406)
        DGV_Loans.Name = "DGV_Loans"
        DGV_Loans.ReadOnly = True
        DGV_Loans.RowHeadersWidth = 62
        DGV_Loans.Size = New Size(826, 200)
        DGV_Loans.TabIndex = 8
        ' 
        ' TB_TotalLoans
        ' 
        TB_TotalLoans.BackColor = SystemColors.Window
        TB_TotalLoans.Location = New Point(194, 938)
        TB_TotalLoans.Margin = New Padding(4, 5, 4, 5)
        TB_TotalLoans.Name = "TB_TotalLoans"
        TB_TotalLoans.Size = New Size(141, 31)
        TB_TotalLoans.TabIndex = 9
        ' 
        ' TB_balance
        ' 
        TB_balance.BackColor = SystemColors.Window
        TB_balance.Location = New Point(447, 941)
        TB_balance.Margin = New Padding(4, 5, 4, 5)
        TB_balance.Name = "TB_balance"
        TB_balance.Size = New Size(141, 31)
        TB_balance.TabIndex = 10
        ' 
        ' LB_TotalLoans
        ' 
        LB_TotalLoans.AutoSize = True
        LB_TotalLoans.Location = New Point(24, 944)
        LB_TotalLoans.Name = "LB_TotalLoans"
        LB_TotalLoans.Size = New Size(163, 25)
        LB_TotalLoans.TabIndex = 12
        LB_TotalLoans.Text = "Monto acumulado:"
        ' 
        ' LB_balance
        ' 
        LB_balance.AutoSize = True
        LB_balance.Location = New Point(379, 944)
        LB_balance.Name = "LB_balance"
        LB_balance.Size = New Size(61, 25)
        LB_balance.TabIndex = 13
        LB_balance.Text = "Saldo:"
        ' 
        ' GB_SavingInformation
        ' 
        GB_SavingInformation.Controls.Add(Label2)
        GB_SavingInformation.Controls.Add(Label1)
        GB_SavingInformation.Controls.Add(LB_SelectEmployee)
        GB_SavingInformation.Controls.Add(LB_balance)
        GB_SavingInformation.Controls.Add(LB_TotalLoans)
        GB_SavingInformation.Controls.Add(TB_balance)
        GB_SavingInformation.Controls.Add(TB_TotalLoans)
        GB_SavingInformation.Controls.Add(DGV_Loans)
        GB_SavingInformation.Controls.Add(DGV_EmployeeInfo)
        GB_SavingInformation.Controls.Add(BT_Register)
        GB_SavingInformation.Controls.Add(DGV_DetailInstalment)
        GB_SavingInformation.Controls.Add(TB_ManualInstalment)
        GB_SavingInformation.Controls.Add(LB_ManualInstalment)
        GB_SavingInformation.Location = New Point(17, 77)
        GB_SavingInformation.Margin = New Padding(4, 5, 4, 5)
        GB_SavingInformation.Name = "GB_SavingInformation"
        GB_SavingInformation.Padding = New Padding(4, 5, 4, 5)
        GB_SavingInformation.Size = New Size(1580, 974)
        GB_SavingInformation.TabIndex = 6
        GB_SavingInformation.TabStop = False
        GB_SavingInformation.Text = "Información sobre créditos"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(25, 685)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(281, 25)
        Label2.TabIndex = 16
        Label2.Text = "Detalle de pagos por cada crédito"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(25, 364)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(425, 25)
        Label1.TabIndex = 15
        Label1.Text = "Detalle de créditos por empleado (Activos/Pagados)"
        ' 
        ' LB_SelectEmployee
        ' 
        LB_SelectEmployee.AutoSize = True
        LB_SelectEmployee.ForeColor = SystemColors.ActiveCaptionText
        LB_SelectEmployee.Location = New Point(25, 51)
        LB_SelectEmployee.Margin = New Padding(4, 0, 4, 0)
        LB_SelectEmployee.Name = "LB_SelectEmployee"
        LB_SelectEmployee.Size = New Size(275, 25)
        LB_SelectEmployee.TabIndex = 14
        LB_SelectEmployee.Text = "Saldos pendientes por empleado"
        ' 
        ' OP_RECORDSBYEMPLOYEELOANS
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1924, 1050)
        Controls.Add(GB_SavingInformation)
        Name = "OP_RECORDSBYEMPLOYEELOANS"
        Text = "Registro de abonos a créditos"
        WindowState = FormWindowState.Maximized
        CType(DGV_DetailInstalment, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Loans, ComponentModel.ISupportInitialize).EndInit()
        GB_SavingInformation.ResumeLayout(False)
        GB_SavingInformation.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LB_ManualInstalment As Label
    Friend WithEvents TB_ManualInstalment As TextBox
    Friend WithEvents DGV_DetailInstalment As DataGridView
    Friend WithEvents BT_Register As Button
    Friend WithEvents DGV_EmployeeInfo As DataGridView
    Friend WithEvents DGV_Loans As DataGridView
    Friend WithEvents TB_TotalLoans As TextBox
    Friend WithEvents TB_balance As TextBox
    Friend WithEvents LB_TotalLoans As Label
    Friend WithEvents LB_balance As Label
    Friend WithEvents GB_SavingInformation As GroupBox
    Friend WithEvents LB_SelectEmployee As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
