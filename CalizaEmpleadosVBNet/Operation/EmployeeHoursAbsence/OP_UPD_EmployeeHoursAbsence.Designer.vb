<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_EmployeeHoursAbsence
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
        DGV_HoursAbsence = New DataGridView()
        GroupBox1 = New GroupBox()
        CB_Stat = New CheckBox()
        Label2 = New Label()
        CB_HoursAbsenceType = New ComboBox()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        TB_HoursAbsence = New TextBox()
        LB_HoursAbsence = New Label()
        LB_Description = New Label()
        TB_Description = New TextBox()
        TB_Cause = New TextBox()
        BT_Upd = New Button()
        LB_Cause = New Label()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        CType(DGV_HoursAbsence, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(275, 30)
        LB_Title.TabIndex = 110
        LB_Title.Text = "Edición de permiso de horas"
        ' 
        ' DGV_HoursAbsence
        ' 
        DGV_HoursAbsence.AllowUserToAddRows = False
        DGV_HoursAbsence.AllowUserToDeleteRows = False
        DGV_HoursAbsence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_HoursAbsence.Location = New Point(12, 46)
        DGV_HoursAbsence.Name = "DGV_HoursAbsence"
        DGV_HoursAbsence.ReadOnly = True
        DGV_HoursAbsence.Size = New Size(1218, 400)
        DGV_HoursAbsence.TabIndex = 111
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Stat)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(CB_HoursAbsenceType)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_HoursAbsence)
        GroupBox1.Controls.Add(LB_HoursAbsence)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_Cause)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(LB_Cause)
        GroupBox1.Controls.Add(DTP_Valid)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 467)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 289)
        GroupBox1.TabIndex = 112
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre permiso de horas"
        ' 
        ' CB_Stat
        ' 
        CB_Stat.AutoSize = True
        CB_Stat.Location = New Point(1140, 30)
        CB_Stat.Name = "CB_Stat"
        CB_Stat.Size = New Size(58, 19)
        CB_Stat.TabIndex = 26
        CB_Stat.Text = "Status"
        CB_Stat.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(808, 220)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 15)
        Label2.TabIndex = 25
        Label2.Text = "Tipo de pago:"
        ' 
        ' CB_HoursAbsenceType
        ' 
        CB_HoursAbsenceType.DropDownStyle = ComboBoxStyle.DropDownList
        CB_HoursAbsenceType.FormattingEnabled = True
        CB_HoursAbsenceType.Location = New Point(808, 242)
        CB_HoursAbsenceType.Name = "CB_HoursAbsenceType"
        CB_HoursAbsenceType.Size = New Size(127, 23)
        CB_HoursAbsenceType.TabIndex = 24
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(15, 107)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 23
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(110, 99)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 22
        ' 
        ' TB_HoursAbsence
        ' 
        TB_HoursAbsence.BackColor = SystemColors.Menu
        TB_HoursAbsence.Location = New Point(676, 243)
        TB_HoursAbsence.Name = "TB_HoursAbsence"
        TB_HoursAbsence.Size = New Size(120, 23)
        TB_HoursAbsence.TabIndex = 19
        ' 
        ' LB_HoursAbsence
        ' 
        LB_HoursAbsence.AutoSize = True
        LB_HoursAbsence.Location = New Point(676, 220)
        LB_HoursAbsence.Name = "LB_HoursAbsence"
        LB_HoursAbsence.Size = New Size(41, 15)
        LB_HoursAbsence.TabIndex = 18
        LB_HoursAbsence.Text = "Horas:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(15, 177)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(72, 15)
        LB_Description.TabIndex = 14
        LB_Description.Text = "Descripción:"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(15, 195)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 13
        ' 
        ' TB_Cause
        ' 
        TB_Cause.Location = New Point(69, 135)
        TB_Cause.Name = "TB_Cause"
        TB_Cause.Size = New Size(222, 23)
        TB_Cause.TabIndex = 12
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(1125, 257)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 10
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' LB_Cause
        ' 
        LB_Cause.AutoSize = True
        LB_Cause.Location = New Point(15, 143)
        LB_Cause.Name = "LB_Cause"
        LB_Cause.Size = New Size(48, 15)
        LB_Cause.TabIndex = 9
        LB_Cause.Text = "Motivo:"
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(432, 243)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(432, 220)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 6
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 67)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 75)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 29)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 37)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' OP_UPD_EmployeeHoursAbsence
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 787)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_HoursAbsence)
        Controls.Add(LB_Title)
        Name = "OP_UPD_EmployeeHoursAbsence"
        Text = "Edición de permiso de horas"
        WindowState = FormWindowState.Maximized
        CType(DGV_HoursAbsence, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents DGV_HoursAbsence As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_HoursAbsenceType As ComboBox
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents TB_HoursAbsence As TextBox
    Friend WithEvents LB_HoursAbsence As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_Cause As TextBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents LB_Cause As Label
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents CB_Stat As CheckBox
End Class
