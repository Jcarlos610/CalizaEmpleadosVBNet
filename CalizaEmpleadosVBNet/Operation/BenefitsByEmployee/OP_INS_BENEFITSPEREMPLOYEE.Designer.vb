<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_BENEFITSPEREMPLOYEE
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
        GB_DocumentHeader = New GroupBox()
        BT_Cancel = New Button()
        BT_Search = New Button()
        TB_EmployeeId = New TextBox()
        LB_EmployeeId = New Label()
        DGV_Employees = New DataGridView()
        GB_BenefitsInfo = New GroupBox()
        DGV_Benefits = New DataGridView()
        GB_BenefitPerEmployee = New GroupBox()
        DGV_UpdateSalary = New DataGridView()
        DGV_BenefitsByEmployee = New DataGridView()
        GB_DocumentHeader.SuspendLayout()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).BeginInit()
        GB_BenefitsInfo.SuspendLayout()
        CType(DGV_Benefits, ComponentModel.ISupportInitialize).BeginInit()
        GB_BenefitPerEmployee.SuspendLayout()
        CType(DGV_UpdateSalary, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_BenefitsByEmployee, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_DocumentHeader
        ' 
        GB_DocumentHeader.Controls.Add(BT_Cancel)
        GB_DocumentHeader.Controls.Add(BT_Search)
        GB_DocumentHeader.Controls.Add(TB_EmployeeId)
        GB_DocumentHeader.Controls.Add(LB_EmployeeId)
        GB_DocumentHeader.Controls.Add(DGV_Employees)
        GB_DocumentHeader.Location = New Point(12, 46)
        GB_DocumentHeader.Name = "GB_DocumentHeader"
        GB_DocumentHeader.Size = New Size(1361, 195)
        GB_DocumentHeader.TabIndex = 0
        GB_DocumentHeader.TabStop = False
        GB_DocumentHeader.Text = "Información de empleado"
        ' 
        ' BT_Cancel
        ' 
        BT_Cancel.Location = New Point(1265, 24)
        BT_Cancel.Name = "BT_Cancel"
        BT_Cancel.Size = New Size(75, 23)
        BT_Cancel.TabIndex = 8
        BT_Cancel.Text = "Actualizar"
        BT_Cancel.UseVisualStyleBackColor = True
        ' 
        ' BT_Search
        ' 
        BT_Search.Location = New Point(257, 21)
        BT_Search.Name = "BT_Search"
        BT_Search.Size = New Size(75, 23)
        BT_Search.TabIndex = 3
        BT_Search.Text = "Buscar"
        BT_Search.UseVisualStyleBackColor = True
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(141, 21)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.Size = New Size(100, 23)
        TB_EmployeeId.TabIndex = 2
        ' 
        ' LB_EmployeeId
        ' 
        LB_EmployeeId.AutoSize = True
        LB_EmployeeId.Location = New Point(12, 24)
        LB_EmployeeId.Name = "LB_EmployeeId"
        LB_EmployeeId.Size = New Size(123, 15)
        LB_EmployeeId.TabIndex = 1
        LB_EmployeeId.Text = "Número de empleado"
        ' 
        ' DGV_Employees
        ' 
        DGV_Employees.AllowUserToAddRows = False
        DGV_Employees.AllowUserToDeleteRows = False
        DGV_Employees.AllowUserToOrderColumns = True
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Employees.Location = New Point(12, 52)
        DGV_Employees.Name = "DGV_Employees"
        DGV_Employees.ReadOnly = True
        DGV_Employees.Size = New Size(1329, 128)
        DGV_Employees.TabIndex = 0
        ' 
        ' GB_BenefitsInfo
        ' 
        GB_BenefitsInfo.Controls.Add(DGV_Benefits)
        GB_BenefitsInfo.Location = New Point(12, 246)
        GB_BenefitsInfo.Name = "GB_BenefitsInfo"
        GB_BenefitsInfo.Size = New Size(1361, 198)
        GB_BenefitsInfo.TabIndex = 1
        GB_BenefitsInfo.TabStop = False
        GB_BenefitsInfo.Text = "Beneficios disponibles"
        ' 
        ' DGV_Benefits
        ' 
        DGV_Benefits.AllowUserToAddRows = False
        DGV_Benefits.AllowUserToDeleteRows = False
        DGV_Benefits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Benefits.Location = New Point(12, 22)
        DGV_Benefits.Name = "DGV_Benefits"
        DGV_Benefits.ReadOnly = True
        DGV_Benefits.Size = New Size(1329, 157)
        DGV_Benefits.TabIndex = 0
        ' 
        ' GB_BenefitPerEmployee
        ' 
        GB_BenefitPerEmployee.Controls.Add(DGV_UpdateSalary)
        GB_BenefitPerEmployee.Controls.Add(DGV_BenefitsByEmployee)
        GB_BenefitPerEmployee.Location = New Point(12, 449)
        GB_BenefitPerEmployee.Name = "GB_BenefitPerEmployee"
        GB_BenefitPerEmployee.Size = New Size(1361, 187)
        GB_BenefitPerEmployee.TabIndex = 2
        GB_BenefitPerEmployee.TabStop = False
        GB_BenefitPerEmployee.Text = "Beneficios por empleado"
        ' 
        ' DGV_UpdateSalary
        ' 
        DGV_UpdateSalary.AllowUserToAddRows = False
        DGV_UpdateSalary.AllowUserToDeleteRows = False
        DGV_UpdateSalary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_UpdateSalary.Location = New Point(872, 22)
        DGV_UpdateSalary.Name = "DGV_UpdateSalary"
        DGV_UpdateSalary.ReadOnly = True
        DGV_UpdateSalary.Size = New Size(469, 150)
        DGV_UpdateSalary.TabIndex = 1
        ' 
        ' DGV_BenefitsByEmployee
        ' 
        DGV_BenefitsByEmployee.AllowUserToAddRows = False
        DGV_BenefitsByEmployee.AllowUserToDeleteRows = False
        DGV_BenefitsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_BenefitsByEmployee.Location = New Point(12, 22)
        DGV_BenefitsByEmployee.Name = "DGV_BenefitsByEmployee"
        DGV_BenefitsByEmployee.ReadOnly = True
        DGV_BenefitsByEmployee.Size = New Size(841, 150)
        DGV_BenefitsByEmployee.TabIndex = 0
        ' 
        ' OP_INS_BENEFITSPEREMPLOYEE
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1465, 783)
        Controls.Add(GB_BenefitPerEmployee)
        Controls.Add(GB_BenefitsInfo)
        Controls.Add(GB_DocumentHeader)
        Name = "OP_INS_BENEFITSPEREMPLOYEE"
        Text = "Asignación de beneficios por empleado"
        WindowState = FormWindowState.Maximized
        GB_DocumentHeader.ResumeLayout(False)
        GB_DocumentHeader.PerformLayout()
        CType(DGV_Employees, ComponentModel.ISupportInitialize).EndInit()
        GB_BenefitsInfo.ResumeLayout(False)
        CType(DGV_Benefits, ComponentModel.ISupportInitialize).EndInit()
        GB_BenefitPerEmployee.ResumeLayout(False)
        CType(DGV_UpdateSalary, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_BenefitsByEmployee, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GB_DocumentHeader As GroupBox
    Friend WithEvents DGV_Employees As DataGridView
    Friend WithEvents BT_Search As Button
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmployeeId As Label
    Friend WithEvents GB_BenefitsInfo As GroupBox
    Friend WithEvents DGV_Benefits As DataGridView
    Friend WithEvents GB_BenefitPerEmployee As GroupBox
    Friend WithEvents DGV_BenefitsByEmployee As DataGridView
    Friend WithEvents BT_Cancel As Button
    Friend WithEvents DGV_UpdateSalary As DataGridView
End Class
