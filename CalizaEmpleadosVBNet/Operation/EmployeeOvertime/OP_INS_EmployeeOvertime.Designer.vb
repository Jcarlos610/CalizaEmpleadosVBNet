<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_EmployeeOvertime
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
        Label2 = New Label()
        CB_OvertimeType = New ComboBox()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        TB_OvertimeHours = New TextBox()
        LB_OvertimeHours = New Label()
        LB_Description = New Label()
        TB_Description = New TextBox()
        TB_OvertimeCause = New TextBox()
        LBX_Suggesting = New ListBox()
        BT_Register = New Button()
        LB_OvertimeCause = New Label()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        TB_Employee = New TextBox()
        LB_Employee = New Label()
        DGV_OverTime = New DataGridView()
        LB_Title = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_OverTime, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(CB_OvertimeType)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_OvertimeHours)
        GroupBox1.Controls.Add(LB_OvertimeHours)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_OvertimeCause)
        GroupBox1.Controls.Add(LBX_Suggesting)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(LB_OvertimeCause)
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
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre horas extra"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(808, 269)
        Label2.Name = "Label2"
        Label2.Size = New Size(34, 15)
        Label2.TabIndex = 25
        Label2.Text = "Tipo:"
        ' 
        ' CB_OvertimeType
        ' 
        CB_OvertimeType.DropDownStyle = ComboBoxStyle.DropDownList
        CB_OvertimeType.FormattingEnabled = True
        CB_OvertimeType.Location = New Point(808, 291)
        CB_OvertimeType.Name = "CB_OvertimeType"
        CB_OvertimeType.Size = New Size(127, 23)
        CB_OvertimeType.TabIndex = 24
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(15, 156)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 23
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(110, 148)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 22
        ' 
        ' TB_OvertimeHours
        ' 
        TB_OvertimeHours.BackColor = SystemColors.Menu
        TB_OvertimeHours.Location = New Point(676, 292)
        TB_OvertimeHours.Name = "TB_OvertimeHours"
        TB_OvertimeHours.Size = New Size(120, 23)
        TB_OvertimeHours.TabIndex = 19
        ' 
        ' LB_OvertimeHours
        ' 
        LB_OvertimeHours.AutoSize = True
        LB_OvertimeHours.Location = New Point(676, 269)
        LB_OvertimeHours.Name = "LB_OvertimeHours"
        LB_OvertimeHours.Size = New Size(69, 15)
        LB_OvertimeHours.TabIndex = 18
        LB_OvertimeHours.Text = "Horas extra:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(15, 226)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(72, 15)
        LB_Description.TabIndex = 14
        LB_Description.Text = "Descripción:"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(15, 244)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 13
        ' 
        ' TB_OvertimeCause
        ' 
        TB_OvertimeCause.Location = New Point(69, 184)
        TB_OvertimeCause.Name = "TB_OvertimeCause"
        TB_OvertimeCause.Size = New Size(222, 23)
        TB_OvertimeCause.TabIndex = 12
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
        ' LB_OvertimeCause
        ' 
        LB_OvertimeCause.AutoSize = True
        LB_OvertimeCause.Location = New Point(15, 192)
        LB_OvertimeCause.Name = "LB_OvertimeCause"
        LB_OvertimeCause.Size = New Size(48, 15)
        LB_OvertimeCause.TabIndex = 9
        LB_OvertimeCause.Text = "Motivo:"
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(432, 292)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(432, 269)
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
        ' DGV_OverTime
        ' 
        DGV_OverTime.AllowUserToAddRows = False
        DGV_OverTime.AllowUserToDeleteRows = False
        DGV_OverTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_OverTime.Location = New Point(12, 411)
        DGV_OverTime.Name = "DGV_OverTime"
        DGV_OverTime.ReadOnly = True
        DGV_OverTime.Size = New Size(1218, 271)
        DGV_OverTime.TabIndex = 6
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(226, 30)
        LB_Title.TabIndex = 106
        LB_Title.Text = "Registro de horas extra"
        ' 
        ' OP_INS_EmployeeOvertime
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(LB_Title)
        Controls.Add(DGV_OverTime)
        Controls.Add(GroupBox1)
        Name = "OP_INS_EmployeeOvertime"
        Text = "Registro de horas extra"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_OverTime, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_OvertimeHours As TextBox
    Friend WithEvents LB_OvertimeHours As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_OvertimeCause As TextBox
    Friend WithEvents LBX_Suggesting As ListBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents LB_OvertimeCause As Label
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents TB_Employee As TextBox
    Friend WithEvents LB_Employee As Label
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents DGV_OverTime As DataGridView
    Friend WithEvents LB_Title As Label
    Friend WithEvents CB_OvertimeType As ComboBox
    Friend WithEvents Label2 As Label
End Class
