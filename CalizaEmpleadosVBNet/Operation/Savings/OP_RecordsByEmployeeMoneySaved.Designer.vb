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
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_DetailSaving, ComponentModel.ISupportInitialize).BeginInit()
        GB_SavingInformation.SuspendLayout()
        SuspendLayout()
        ' 
        ' DGV_EmployeeInfo
        ' 
        DGV_EmployeeInfo.AllowUserToAddRows = False
        DGV_EmployeeInfo.AllowUserToDeleteRows = False
        DGV_EmployeeInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_EmployeeInfo.Location = New Point(17, 28)
        DGV_EmployeeInfo.Margin = New Padding(2)
        DGV_EmployeeInfo.Name = "DGV_EmployeeInfo"
        DGV_EmployeeInfo.ReadOnly = True
        DGV_EmployeeInfo.RowHeadersWidth = 62
        DGV_EmployeeInfo.Size = New Size(1071, 243)
        DGV_EmployeeInfo.TabIndex = 0
        ' 
        ' DGV_DetailSaving
        ' 
        DGV_DetailSaving.AllowUserToAddRows = False
        DGV_DetailSaving.AllowUserToDeleteRows = False
        DGV_DetailSaving.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DetailSaving.Location = New Point(17, 315)
        DGV_DetailSaving.Margin = New Padding(2)
        DGV_DetailSaving.Name = "DGV_DetailSaving"
        DGV_DetailSaving.ReadOnly = True
        DGV_DetailSaving.RowHeadersWidth = 62
        DGV_DetailSaving.Size = New Size(578, 144)
        DGV_DetailSaving.TabIndex = 1
        ' 
        ' LB_ManualSaving
        ' 
        LB_ManualSaving.AutoSize = True
        LB_ManualSaving.Location = New Point(17, 286)
        LB_ManualSaving.Margin = New Padding(2, 0, 2, 0)
        LB_ManualSaving.Name = "LB_ManualSaving"
        LB_ManualSaving.Size = New Size(90, 15)
        LB_ManualSaving.TabIndex = 2
        LB_ManualSaving.Text = "Ahorro manual:"
        ' 
        ' TB_ManualSaving
        ' 
        TB_ManualSaving.BackColor = SystemColors.Info
        TB_ManualSaving.Location = New Point(112, 282)
        TB_ManualSaving.Name = "TB_ManualSaving"
        TB_ManualSaving.Size = New Size(100, 23)
        TB_ManualSaving.TabIndex = 3
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(217, 282)
        BT_Register.Margin = New Padding(2)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(111, 23)
        BT_Register.TabIndex = 4
        BT_Register.Text = "Registrar Monto"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' GB_SavingInformation
        ' 
        GB_SavingInformation.Controls.Add(DGV_EmployeeInfo)
        GB_SavingInformation.Controls.Add(BT_Register)
        GB_SavingInformation.Controls.Add(DGV_DetailSaving)
        GB_SavingInformation.Controls.Add(TB_ManualSaving)
        GB_SavingInformation.Controls.Add(LB_ManualSaving)
        GB_SavingInformation.Location = New Point(12, 46)
        GB_SavingInformation.Name = "GB_SavingInformation"
        GB_SavingInformation.Size = New Size(1106, 491)
        GB_SavingInformation.TabIndex = 5
        GB_SavingInformation.TabStop = False
        GB_SavingInformation.Text = "Información sobre ahorros"
        ' 
        ' OP_RecordsByEmployeeMoneySaved
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1465, 637)
        Controls.Add(GB_SavingInformation)
        Margin = New Padding(2)
        Name = "OP_RecordsByEmployeeMoneySaved"
        Tag = "OP_RecordsByEmployeeMoneySaved"
        Text = "Información sobre Ahorros"
        WindowState = FormWindowState.Maximized
        CType(DGV_EmployeeInfo, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_DetailSaving, ComponentModel.ISupportInitialize).EndInit()
        GB_SavingInformation.ResumeLayout(False)
        GB_SavingInformation.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DGV_EmployeeInfo As DataGridView
    Friend WithEvents DGV_DetailSaving As DataGridView
    Friend WithEvents LB_ManualSaving As Label
    Friend WithEvents TB_ManualSaving As TextBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents GB_SavingInformation As GroupBox
End Class
