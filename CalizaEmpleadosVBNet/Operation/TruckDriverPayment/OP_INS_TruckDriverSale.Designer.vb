<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_TruckDriverSale
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
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        LBX_Suggesting = New ListBox()
        TB_Employee = New TextBox()
        LB_Employee = New Label()
        BT_Register = New Button()
        CB_LocationList = New ComboBox()
        LB_Locations1 = New Label()
        CB_CustomerList = New ComboBox()
        LB_Customers1 = New Label()
        DGV_Sales = New DataGridView()
        DGV_Tabulator = New DataGridView()
        LB_Amount = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_Sales, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_Tabulator, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(190, 30)
        LB_Title.TabIndex = 112
        LB_Title.Text = "Tabulador de viajes"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Controls.Add(LBX_Suggesting)
        GroupBox1.Controls.Add(TB_Employee)
        GroupBox1.Controls.Add(LB_Employee)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(CB_LocationList)
        GroupBox1.Controls.Add(LB_Locations1)
        GroupBox1.Controls.Add(CB_CustomerList)
        GroupBox1.Controls.Add(LB_Customers1)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1070, 131)
        GroupBox1.TabIndex = 113
        GroupBox1.TabStop = False
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(351, 93)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 20
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(219, 101)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 19
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(138, 93)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 18
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(6, 101)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 17
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' LBX_Suggesting
        ' 
        LBX_Suggesting.FormattingEnabled = True
        LBX_Suggesting.IntegralHeight = False
        LBX_Suggesting.ItemHeight = 15
        LBX_Suggesting.Location = New Point(552, 63)
        LBX_Suggesting.Name = "LBX_Suggesting"
        LBX_Suggesting.Size = New Size(420, 23)
        LBX_Suggesting.TabIndex = 16
        LBX_Suggesting.Visible = False
        ' 
        ' TB_Employee
        ' 
        TB_Employee.Location = New Point(111, 63)
        TB_Employee.Name = "TB_Employee"
        TB_Employee.Size = New Size(435, 23)
        TB_Employee.TabIndex = 15
        ' 
        ' LB_Employee
        ' 
        LB_Employee.AutoSize = True
        LB_Employee.Location = New Point(6, 71)
        LB_Employee.Name = "LB_Employee"
        LB_Employee.Size = New Size(104, 15)
        LB_Employee.TabIndex = 14
        LB_Employee.Text = "Buscar empleado: "
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(989, 102)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 13
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' CB_LocationList
        ' 
        CB_LocationList.DropDownStyle = ComboBoxStyle.DropDownList
        CB_LocationList.FormattingEnabled = True
        CB_LocationList.Location = New Point(279, 36)
        CB_LocationList.Margin = New Padding(3, 2, 3, 2)
        CB_LocationList.Name = "CB_LocationList"
        CB_LocationList.Size = New Size(546, 23)
        CB_LocationList.TabIndex = 12
        ' 
        ' LB_Locations1
        ' 
        LB_Locations1.AutoSize = True
        LB_Locations1.Location = New Point(279, 16)
        LB_Locations1.Name = "LB_Locations1"
        LB_Locations1.Size = New Size(133, 15)
        LB_Locations1.TabIndex = 11
        LB_Locations1.Text = "Seleccione una Sucursal"
        ' 
        ' CB_CustomerList
        ' 
        CB_CustomerList.DropDownStyle = ComboBoxStyle.DropDownList
        CB_CustomerList.FormattingEnabled = True
        CB_CustomerList.Location = New Point(6, 36)
        CB_CustomerList.Margin = New Padding(3, 2, 3, 2)
        CB_CustomerList.Name = "CB_CustomerList"
        CB_CustomerList.Size = New Size(269, 23)
        CB_CustomerList.TabIndex = 10
        ' 
        ' LB_Customers1
        ' 
        LB_Customers1.AutoSize = True
        LB_Customers1.Location = New Point(6, 19)
        LB_Customers1.Name = "LB_Customers1"
        LB_Customers1.Size = New Size(120, 15)
        LB_Customers1.TabIndex = 9
        LB_Customers1.Text = "Seleccione un Cliente"
        ' 
        ' DGV_Sales
        ' 
        DGV_Sales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Sales.Location = New Point(12, 484)
        DGV_Sales.Name = "DGV_Sales"
        DGV_Sales.Size = New Size(1150, 335)
        DGV_Sales.TabIndex = 114
        ' 
        ' DGV_Tabulator
        ' 
        DGV_Tabulator.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Tabulator.Location = New Point(12, 183)
        DGV_Tabulator.Name = "DGV_Tabulator"
        DGV_Tabulator.Size = New Size(557, 293)
        DGV_Tabulator.TabIndex = 115
        ' 
        ' LB_Amount
        ' 
        LB_Amount.AutoSize = True
        LB_Amount.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LB_Amount.ForeColor = SystemColors.ControlText
        LB_Amount.Location = New Point(588, 452)
        LB_Amount.Name = "LB_Amount"
        LB_Amount.Size = New Size(130, 20)
        LB_Amount.TabIndex = 116
        LB_Amount.Text = "Monto a pagar: $"
        ' 
        ' OP_INS_TruckDriverSale
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 831)
        Controls.Add(LB_Amount)
        Controls.Add(DGV_Tabulator)
        Controls.Add(DGV_Sales)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Name = "OP_INS_TruckDriverSale"
        Text = "Tabulador de viajes"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Sales, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_Tabulator, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CB_LocationList As ComboBox
    Friend WithEvents LB_Locations1 As Label
    Friend WithEvents CB_CustomerList As ComboBox
    Friend WithEvents LB_Customers1 As Label
    Friend WithEvents DGV_Sales As DataGridView
    Friend WithEvents BT_Register As Button
    Friend WithEvents DGV_Tabulator As DataGridView
    Friend WithEvents LBX_Suggesting As ListBox
    Friend WithEvents TB_Employee As TextBox
    Friend WithEvents LB_Employee As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents LB_Amount As Label
End Class
