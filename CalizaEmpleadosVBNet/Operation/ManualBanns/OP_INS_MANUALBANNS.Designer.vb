<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_MANUALBANNS
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
        LBX_Suggesting = New ListBox()
        BT_Register = New Button()
        LB_Banns = New Label()
        CB_Banns = New ComboBox()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        TB_Employee = New TextBox()
        LB_Employee = New Label()
        SqlCommand1 = New Microsoft.Data.SqlClient.SqlCommand()
        DGV_Banns = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_Banns, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(LBX_Suggesting)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(LB_Banns)
        GroupBox1.Controls.Add(CB_Banns)
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
        GroupBox1.Size = New Size(1218, 239)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre amonestaciones"
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
        BT_Register.Location = New Point(1124, 186)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 10
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' LB_Banns
        ' 
        LB_Banns.AutoSize = True
        LB_Banns.Location = New Point(15, 159)
        LB_Banns.Name = "LB_Banns"
        LB_Banns.Size = New Size(98, 15)
        LB_Banns.TabIndex = 9
        LB_Banns.Text = "Amonestaciones:"
        ' 
        ' CB_Banns
        ' 
        CB_Banns.FormattingEnabled = True
        CB_Banns.Location = New Point(15, 186)
        CB_Banns.Name = "CB_Banns"
        CB_Banns.Size = New Size(385, 23)
        CB_Banns.TabIndex = 8
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(441, 118)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(441, 86)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 6
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 116)
        TB_EmployeeName.Name = "TB_EmployeeName"
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
        ' SqlCommand1
        ' 
        SqlCommand1.CommandTimeout = 30
        SqlCommand1.EnableOptimizedParameterBinding = False
        ' 
        ' DGV_Banns
        ' 
        DGV_Banns.AllowUserToAddRows = False
        DGV_Banns.AllowUserToDeleteRows = False
        DGV_Banns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Banns.Location = New Point(12, 302)
        DGV_Banns.Name = "DGV_Banns"
        DGV_Banns.ReadOnly = True
        DGV_Banns.Size = New Size(1218, 380)
        DGV_Banns.TabIndex = 1
        ' 
        ' OP_INS_MANUALBANNS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(DGV_Banns)
        Controls.Add(GroupBox1)
        Name = "OP_INS_MANUALBANNS"
        Text = "Registro manual de amonestaciones"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Banns, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LB_Employee As Label
    Friend WithEvents TB_Employee As TextBox
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents SqlCommand1 As Microsoft.Data.SqlClient.SqlCommand
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents LB_Banns As Label
    Friend WithEvents CB_Banns As ComboBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents DGV_Banns As DataGridView
    Friend WithEvents LBX_Suggesting As ListBox
End Class
