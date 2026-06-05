<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_EmployeeOvertime
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
        TB_OvertimeHours = New TextBox()
        LB_OvertimeHours = New Label()
        CB_Stat = New CheckBox()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        LB_Description = New Label()
        TB_Description = New TextBox()
        TB_OvertimeCause = New TextBox()
        BT_Upd = New Button()
        LB_OvertimeCause = New Label()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        DGV_Overtime = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_Overtime, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(218, 30)
        LB_Title.TabIndex = 109
        LB_Title.Text = "Edición de horas extra"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_OvertimeHours)
        GroupBox1.Controls.Add(LB_OvertimeHours)
        GroupBox1.Controls.Add(CB_Stat)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_OvertimeCause)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(LB_OvertimeCause)
        GroupBox1.Controls.Add(DTP_Valid)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 467)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 289)
        GroupBox1.TabIndex = 108
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre horas extra"
        ' 
        ' TB_OvertimeHours
        ' 
        TB_OvertimeHours.BackColor = SystemColors.Menu
        TB_OvertimeHours.Location = New Point(446, 248)
        TB_OvertimeHours.Name = "TB_OvertimeHours"
        TB_OvertimeHours.Size = New Size(120, 23)
        TB_OvertimeHours.TabIndex = 26
        ' 
        ' LB_OvertimeHours
        ' 
        LB_OvertimeHours.AutoSize = True
        LB_OvertimeHours.Location = New Point(446, 225)
        LB_OvertimeHours.Name = "LB_OvertimeHours"
        LB_OvertimeHours.Size = New Size(69, 15)
        LB_OvertimeHours.TabIndex = 25
        LB_OvertimeHours.Text = "Horas extra:"
        ' 
        ' CB_Stat
        ' 
        CB_Stat.AutoSize = True
        CB_Stat.Location = New Point(1140, 30)
        CB_Stat.Name = "CB_Stat"
        CB_Stat.Size = New Size(58, 19)
        CB_Stat.TabIndex = 24
        CB_Stat.Text = "Status"
        CB_Stat.UseVisualStyleBackColor = True
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(15, 109)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 21
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(110, 101)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 20
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(15, 180)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(72, 15)
        LB_Description.TabIndex = 14
        LB_Description.Text = "Descripción:"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(15, 198)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 13
        ' 
        ' TB_OvertimeCause
        ' 
        TB_OvertimeCause.Location = New Point(69, 139)
        TB_OvertimeCause.Name = "TB_OvertimeCause"
        TB_OvertimeCause.Size = New Size(263, 23)
        TB_OvertimeCause.TabIndex = 12
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(1123, 247)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 10
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' LB_OvertimeCause
        ' 
        LB_OvertimeCause.AutoSize = True
        LB_OvertimeCause.Location = New Point(15, 147)
        LB_OvertimeCause.Name = "LB_OvertimeCause"
        LB_OvertimeCause.Size = New Size(48, 15)
        LB_OvertimeCause.TabIndex = 9
        LB_OvertimeCause.Text = "Motivo:"
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(587, 245)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(587, 225)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 6
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 66)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 74)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 30)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 38)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' DGV_Overtime
        ' 
        DGV_Overtime.AllowUserToAddRows = False
        DGV_Overtime.AllowUserToDeleteRows = False
        DGV_Overtime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Overtime.Location = New Point(12, 46)
        DGV_Overtime.Name = "DGV_Overtime"
        DGV_Overtime.ReadOnly = True
        DGV_Overtime.Size = New Size(1218, 400)
        DGV_Overtime.TabIndex = 107
        ' 
        ' OP_UPD_EmployeeOvertime
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 787)
        Controls.Add(LB_Title)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_Overtime)
        Name = "OP_UPD_EmployeeOvertime"
        Text = "Actualización de horas extra"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Overtime, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CB_Stat As CheckBox
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_OvertimeCause As TextBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents LB_OvertimeCause As Label
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents DGV_Overtime As DataGridView
    Friend WithEvents TB_OvertimeHours As TextBox
    Friend WithEvents LB_OvertimeHours As Label
End Class
