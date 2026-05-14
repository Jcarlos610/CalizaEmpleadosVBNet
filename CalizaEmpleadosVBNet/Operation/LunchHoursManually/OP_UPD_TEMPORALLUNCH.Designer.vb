<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_TEMPORALLUNCH
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
        DGV_Lunch = New DataGridView()
        GroupBox1 = New GroupBox()
        TB_Lunch = New TextBox()
        BT_Upd = New Button()
        LB_Lunch = New Label()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        CType(DGV_Lunch, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DGV_Lunch
        ' 
        DGV_Lunch.AllowUserToAddRows = False
        DGV_Lunch.AllowUserToDeleteRows = False
        DGV_Lunch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Lunch.Location = New Point(12, 46)
        DGV_Lunch.MultiSelect = False
        DGV_Lunch.Name = "DGV_Lunch"
        DGV_Lunch.ReadOnly = True
        DGV_Lunch.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGV_Lunch.Size = New Size(1218, 419)
        DGV_Lunch.TabIndex = 3
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_Lunch)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(LB_Lunch)
        GroupBox1.Controls.Add(DTP_Valid)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 500)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 150)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre amonestaciones"
        ' 
        ' TB_Lunch
        ' 
        TB_Lunch.Location = New Point(150, 88)
        TB_Lunch.Name = "TB_Lunch"
        TB_Lunch.Size = New Size(253, 23)
        TB_Lunch.TabIndex = 12
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(1117, 87)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 10
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' LB_Lunch
        ' 
        LB_Lunch.AutoSize = True
        LB_Lunch.Location = New Point(15, 96)
        LB_Lunch.Name = "LB_Lunch"
        LB_Lunch.Size = New Size(100, 15)
        LB_Lunch.TabIndex = 9
        LB_Lunch.Text = "Horas de comida:"
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(441, 90)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(441, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 6
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(150, 56)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 64)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(150, 25)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 33)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' OP_UPD_TEMPORALLUNCH
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_Lunch)
        Name = "OP_UPD_TEMPORALLUNCH"
        Text = "Edición de horas de comida"
        WindowState = FormWindowState.Maximized
        CType(DGV_Lunch, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DGV_Lunch As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_Lunch As TextBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents LB_Lunch As Label
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
End Class
