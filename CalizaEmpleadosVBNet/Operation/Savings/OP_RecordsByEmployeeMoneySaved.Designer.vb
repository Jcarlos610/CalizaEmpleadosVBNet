<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_RecordsByEmployeeMoneySaved
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
        DGV_EmployeeInfo = New DataGridView()
        DGV_DetailSaving = New DataGridView()
        LB_ManualSaving = New Label()
        TB_ManualSaving = New TextBox()
        BT_Register = New Button()
        GB_SavingInformation = New GroupBox()
        LB_TotalAvailable = New Label()
        LB_TotalWithdrawn = New Label()
        LB_TotalSaved = New Label()
        TB_TotalAvailable = New TextBox()
        TB_TotalWithdrawn = New TextBox()
        TB_TotalSaved = New TextBox()
        DGV_Withdrawals = New DataGridView()
        BT_Withdraw = New Button()
        TB_Withdrawal = New TextBox()
        LB_Withdrawals = New Label()
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_DetailSaving, ComponentModel.ISupportInitialize).BeginInit()
        GB_SavingInformation.SuspendLayout()
        CType(DGV_Withdrawals, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DGV_EmployeeInfo
        ' 
        DGV_EmployeeInfo.AllowUserToAddRows = False
        DGV_EmployeeInfo.AllowUserToDeleteRows = False
        DGV_EmployeeInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_EmployeeInfo.Location = New Point(24, 47)
        DGV_EmployeeInfo.Name = "DGV_EmployeeInfo"
        DGV_EmployeeInfo.ReadOnly = True
        DGV_EmployeeInfo.RowHeadersWidth = 62
        DGV_EmployeeInfo.Size = New Size(1530, 405)
        DGV_EmployeeInfo.TabIndex = 0
        ' 
        ' DGV_DetailSaving
        ' 
        DGV_DetailSaving.AllowUserToAddRows = False
        DGV_DetailSaving.AllowUserToDeleteRows = False
        DGV_DetailSaving.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DetailSaving.Location = New Point(24, 525)
        DGV_DetailSaving.Name = "DGV_DetailSaving"
        DGV_DetailSaving.ReadOnly = True
        DGV_DetailSaving.RowHeadersWidth = 62
        DGV_DetailSaving.Size = New Size(826, 240)
        DGV_DetailSaving.TabIndex = 1
        ' 
        ' LB_ManualSaving
        ' 
        LB_ManualSaving.AutoSize = True
        LB_ManualSaving.Location = New Point(24, 477)
        LB_ManualSaving.Name = "LB_ManualSaving"
        LB_ManualSaving.Size = New Size(135, 25)
        LB_ManualSaving.TabIndex = 2
        LB_ManualSaving.Text = "Ahorro manual:"
        ' 
        ' TB_ManualSaving
        ' 
        TB_ManualSaving.BackColor = SystemColors.Info
        TB_ManualSaving.Location = New Point(160, 470)
        TB_ManualSaving.Margin = New Padding(4, 5, 4, 5)
        TB_ManualSaving.Name = "TB_ManualSaving"
        TB_ManualSaving.Size = New Size(141, 31)
        TB_ManualSaving.TabIndex = 3
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(310, 470)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(159, 38)
        BT_Register.TabIndex = 4
        BT_Register.Text = "Registrar Monto"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' GB_SavingInformation
        ' 
        GB_SavingInformation.Controls.Add(LB_TotalAvailable)
        GB_SavingInformation.Controls.Add(LB_TotalWithdrawn)
        GB_SavingInformation.Controls.Add(LB_TotalSaved)
        GB_SavingInformation.Controls.Add(TB_TotalAvailable)
        GB_SavingInformation.Controls.Add(TB_TotalWithdrawn)
        GB_SavingInformation.Controls.Add(TB_TotalSaved)
        GB_SavingInformation.Controls.Add(DGV_Withdrawals)
        GB_SavingInformation.Controls.Add(BT_Withdraw)
        GB_SavingInformation.Controls.Add(TB_Withdrawal)
        GB_SavingInformation.Controls.Add(LB_Withdrawals)
        GB_SavingInformation.Controls.Add(DGV_EmployeeInfo)
        GB_SavingInformation.Controls.Add(BT_Register)
        GB_SavingInformation.Controls.Add(DGV_DetailSaving)
        GB_SavingInformation.Controls.Add(TB_ManualSaving)
        GB_SavingInformation.Controls.Add(LB_ManualSaving)
        GB_SavingInformation.Location = New Point(17, 77)
        GB_SavingInformation.Margin = New Padding(4, 5, 4, 5)
        GB_SavingInformation.Name = "GB_SavingInformation"
        GB_SavingInformation.Padding = New Padding(4, 5, 4, 5)
        GB_SavingInformation.Size = New Size(1580, 889)
        GB_SavingInformation.TabIndex = 5
        GB_SavingInformation.TabStop = False
        GB_SavingInformation.Text = "Información sobre ahorros"
        ' 
        ' LB_TotalAvailable
        ' 
        LB_TotalAvailable.AutoSize = True
        LB_TotalAvailable.Location = New Point(1265, 793)
        LB_TotalAvailable.Name = "LB_TotalAvailable"
        LB_TotalAvailable.Size = New Size(141, 25)
        LB_TotalAvailable.TabIndex = 14
        LB_TotalAvailable.Text = "Total disponible:"
        ' 
        ' LB_TotalWithdrawn
        ' 
        LB_TotalWithdrawn.AutoSize = True
        LB_TotalWithdrawn.Location = New Point(889, 793)
        LB_TotalWithdrawn.Name = "LB_TotalWithdrawn"
        LB_TotalWithdrawn.Size = New Size(137, 25)
        LB_TotalWithdrawn.TabIndex = 13
        LB_TotalWithdrawn.Text = "Monto retirado:"
        ' 
        ' LB_TotalSaved
        ' 
        LB_TotalSaved.AutoSize = True
        LB_TotalSaved.Location = New Point(24, 793)
        LB_TotalSaved.Name = "LB_TotalSaved"
        LB_TotalSaved.Size = New Size(163, 25)
        LB_TotalSaved.TabIndex = 12
        LB_TotalSaved.Text = "Monto acumulado:"
        ' 
        ' TB_TotalAvailable
        ' 
        TB_TotalAvailable.BackColor = SystemColors.Window
        TB_TotalAvailable.Location = New Point(1413, 787)
        TB_TotalAvailable.Margin = New Padding(4, 5, 4, 5)
        TB_TotalAvailable.Name = "TB_TotalAvailable"
        TB_TotalAvailable.Size = New Size(141, 31)
        TB_TotalAvailable.TabIndex = 11
        ' 
        ' TB_TotalWithdrawn
        ' 
        TB_TotalWithdrawn.BackColor = SystemColors.Window
        TB_TotalWithdrawn.Location = New Point(1027, 787)
        TB_TotalWithdrawn.Margin = New Padding(4, 5, 4, 5)
        TB_TotalWithdrawn.Name = "TB_TotalWithdrawn"
        TB_TotalWithdrawn.Size = New Size(141, 31)
        TB_TotalWithdrawn.TabIndex = 10
        ' 
        ' TB_TotalSaved
        ' 
        TB_TotalSaved.BackColor = SystemColors.Window
        TB_TotalSaved.Location = New Point(183, 790)
        TB_TotalSaved.Margin = New Padding(4, 5, 4, 5)
        TB_TotalSaved.Name = "TB_TotalSaved"
        TB_TotalSaved.Size = New Size(141, 31)
        TB_TotalSaved.TabIndex = 9
        ' 
        ' DGV_Withdrawals
        ' 
        DGV_Withdrawals.AllowUserToAddRows = False
        DGV_Withdrawals.AllowUserToDeleteRows = False
        DGV_Withdrawals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_Withdrawals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Withdrawals.Location = New Point(889, 525)
        DGV_Withdrawals.Name = "DGV_Withdrawals"
        DGV_Withdrawals.ReadOnly = True
        DGV_Withdrawals.RowHeadersWidth = 62
        DGV_Withdrawals.Size = New Size(665, 240)
        DGV_Withdrawals.TabIndex = 8
        ' 
        ' BT_Withdraw
        ' 
        BT_Withdraw.Location = New Point(1180, 470)
        BT_Withdraw.Name = "BT_Withdraw"
        BT_Withdraw.Size = New Size(159, 38)
        BT_Withdraw.TabIndex = 7
        BT_Withdraw.Text = "Registrar Retiro"
        BT_Withdraw.UseVisualStyleBackColor = True
        ' 
        ' TB_Withdrawal
        ' 
        TB_Withdrawal.BackColor = SystemColors.Info
        TB_Withdrawal.Location = New Point(1027, 474)
        TB_Withdrawal.Margin = New Padding(4, 5, 4, 5)
        TB_Withdrawal.Name = "TB_Withdrawal"
        TB_Withdrawal.Size = New Size(141, 31)
        TB_Withdrawal.TabIndex = 6
        ' 
        ' LB_Withdrawals
        ' 
        LB_Withdrawals.AutoSize = True
        LB_Withdrawals.Location = New Point(889, 477)
        LB_Withdrawals.Name = "LB_Withdrawals"
        LB_Withdrawals.Size = New Size(125, 25)
        LB_Withdrawals.TabIndex = 5
        LB_Withdrawals.Text = "Retiro manual:"
        ' 
        ' OP_RecordsByEmployeeMoneySaved
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1924, 1050)
        Controls.Add(GB_SavingInformation)
        Name = "OP_RecordsByEmployeeMoneySaved"
        Tag = "OP_RecordsByEmployeeMoneySaved"
        Text = "Información sobre Ahorros"
        WindowState = FormWindowState.Maximized
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_DetailSaving, ComponentModel.ISupportInitialize).EndInit()
        GB_SavingInformation.ResumeLayout(False)
        GB_SavingInformation.PerformLayout()
        CType(DGV_Withdrawals, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DGV_EmployeeInfo As DataGridView
    Friend WithEvents DGV_DetailSaving As DataGridView
    Friend WithEvents LB_ManualSaving As Label
    Friend WithEvents TB_ManualSaving As TextBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents GB_SavingInformation As GroupBox
    Friend WithEvents DGV_Withdrawals As DataGridView
    Friend WithEvents BT_Withdraw As Button
    Friend WithEvents TB_Withdrawal As TextBox
    Friend WithEvents LB_Withdrawals As Label
    Friend WithEvents LB_TotalAvailable As Label
    Friend WithEvents LB_TotalWithdrawn As Label
    Friend WithEvents LB_TotalSaved As Label
    Friend WithEvents TB_TotalAvailable As TextBox
    Friend WithEvents TB_TotalWithdrawn As TextBox
    Friend WithEvents TB_TotalSaved As TextBox
End Class
