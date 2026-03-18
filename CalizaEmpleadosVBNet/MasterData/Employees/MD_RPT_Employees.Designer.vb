<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_RPT_Employees
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
        GB_EmployeeInformation = New GroupBox()
        CB_EmployeeName = New ComboBox()
        LB_Employee = New Label()
        LB_Company = New Label()
        CB_Company = New ComboBox()
        GroupBox1 = New GroupBox()
        DGV_AllEmployees = New DataGridView()
        BT_EmployeeExport = New Button()
        GB_EmployeeInformation.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(DGV_AllEmployees, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(17, 18)
        LB_Title.Margin = New Padding(4, 0, 4, 0)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(343, 45)
        LB_Title.TabIndex = 104
        LB_Title.Text = "Reporte de empleados"
        ' 
        ' GB_EmployeeInformation
        ' 
        GB_EmployeeInformation.Controls.Add(CB_EmployeeName)
        GB_EmployeeInformation.Controls.Add(LB_Employee)
        GB_EmployeeInformation.Controls.Add(LB_Company)
        GB_EmployeeInformation.Controls.Add(CB_Company)
        GB_EmployeeInformation.Location = New Point(17, 65)
        GB_EmployeeInformation.Margin = New Padding(4, 5, 4, 5)
        GB_EmployeeInformation.Name = "GB_EmployeeInformation"
        GB_EmployeeInformation.Padding = New Padding(4, 5, 4, 5)
        GB_EmployeeInformation.Size = New Size(794, 117)
        GB_EmployeeInformation.TabIndex = 301
        GB_EmployeeInformation.TabStop = False
        GB_EmployeeInformation.Text = "Información"
        ' 
        ' CB_EmployeeName
        ' 
        CB_EmployeeName.FormattingEnabled = True
        CB_EmployeeName.Location = New Point(533, 63)
        CB_EmployeeName.Margin = New Padding(4, 5, 4, 5)
        CB_EmployeeName.Name = "CB_EmployeeName"
        CB_EmployeeName.Size = New Size(228, 33)
        CB_EmployeeName.TabIndex = 304
        ' 
        ' LB_Employee
        ' 
        LB_Employee.AutoSize = True
        LB_Employee.Location = New Point(535, 37)
        LB_Employee.Margin = New Padding(4, 0, 4, 0)
        LB_Employee.Name = "LB_Employee"
        LB_Employee.Size = New Size(92, 25)
        LB_Employee.TabIndex = 303
        LB_Employee.Text = "Empleado"
        ' 
        ' LB_Company
        ' 
        LB_Company.AutoSize = True
        LB_Company.Location = New Point(35, 37)
        LB_Company.Margin = New Padding(4, 0, 4, 0)
        LB_Company.Name = "LB_Company"
        LB_Company.Size = New Size(80, 25)
        LB_Company.TabIndex = 301
        LB_Company.Text = "Empresa"
        ' 
        ' CB_Company
        ' 
        CB_Company.FormattingEnabled = True
        CB_Company.Location = New Point(33, 63)
        CB_Company.Margin = New Padding(4, 5, 4, 5)
        CB_Company.Name = "CB_Company"
        CB_Company.Size = New Size(475, 33)
        CB_Company.TabIndex = 302
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_AllEmployees)
        GroupBox1.Location = New Point(17, 199)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1783, 739)
        GroupBox1.TabIndex = 302
        GroupBox1.TabStop = False
        GroupBox1.Text = "Empleados registrados"
        ' 
        ' DGV_AllEmployees
        ' 
        DGV_AllEmployees.AllowUserToAddRows = False
        DGV_AllEmployees.AllowUserToDeleteRows = False
        DGV_AllEmployees.AllowUserToOrderColumns = True
        DGV_AllEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_AllEmployees.Location = New Point(33, 37)
        DGV_AllEmployees.Margin = New Padding(4, 5, 4, 5)
        DGV_AllEmployees.Name = "DGV_AllEmployees"
        DGV_AllEmployees.ReadOnly = True
        DGV_AllEmployees.RowHeadersWidth = 62
        DGV_AllEmployees.Size = New Size(1726, 672)
        DGV_AllEmployees.TabIndex = 0
        ' 
        ' BT_EmployeeExport
        ' 
        BT_EmployeeExport.Location = New Point(1698, 976)
        BT_EmployeeExport.Margin = New Padding(4, 5, 4, 5)
        BT_EmployeeExport.Name = "BT_EmployeeExport"
        BT_EmployeeExport.Size = New Size(102, 42)
        BT_EmployeeExport.TabIndex = 408
        BT_EmployeeExport.Text = "Exportar"
        BT_EmployeeExport.UseVisualStyleBackColor = True
        ' 
        ' MD_RPT_Employees
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1830, 1050)
        Controls.Add(BT_EmployeeExport)
        Controls.Add(GroupBox1)
        Controls.Add(GB_EmployeeInformation)
        Controls.Add(LB_Title)
        Location = New Point(17, 77)
        Name = "MD_RPT_Employees"
        Text = "Reportes"
        WindowState = FormWindowState.Maximized
        GB_EmployeeInformation.ResumeLayout(False)
        GB_EmployeeInformation.PerformLayout()
        GroupBox1.ResumeLayout(False)
        CType(DGV_AllEmployees, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GB_EmployeeInformation As GroupBox
    Friend WithEvents CB_EmployeeName As ComboBox
    Friend WithEvents LB_Employee As Label
    Friend WithEvents LB_Company As Label
    Friend WithEvents CB_Company As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGV_AllEmployees As DataGridView
    Friend WithEvents BT_EmployeeExport As Button
End Class
