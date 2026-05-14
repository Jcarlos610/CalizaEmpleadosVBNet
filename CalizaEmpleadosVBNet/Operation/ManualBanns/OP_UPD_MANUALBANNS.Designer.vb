<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_MANUALBANNS
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
        DGV_Banns = New DataGridView()
        GroupBox1 = New GroupBox()
        BT_Upd = New Button()
        LB_Banns = New Label()
        CB_Banns = New ComboBox()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        CType(DGV_Banns, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DGV_Banns
        ' 
        DGV_Banns.AllowUserToAddRows = False
        DGV_Banns.AllowUserToDeleteRows = False
        DGV_Banns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Banns.Location = New Point(12, 46)
        DGV_Banns.Name = "DGV_Banns"
        DGV_Banns.ReadOnly = True
        DGV_Banns.Size = New Size(1218, 400)
        DGV_Banns.TabIndex = 2
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(LB_Banns)
        GroupBox1.Controls.Add(CB_Banns)
        GroupBox1.Controls.Add(DTP_Valid)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 474)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 175)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre amonestaciones"
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(1115, 132)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 10
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' LB_Banns
        ' 
        LB_Banns.AutoSize = True
        LB_Banns.Location = New Point(15, 102)
        LB_Banns.Name = "LB_Banns"
        LB_Banns.Size = New Size(98, 15)
        LB_Banns.TabIndex = 9
        LB_Banns.Text = "Amonestaciones:"
        ' 
        ' CB_Banns
        ' 
        CB_Banns.FormattingEnabled = True
        CB_Banns.Location = New Point(15, 130)
        CB_Banns.Name = "CB_Banns"
        CB_Banns.Size = New Size(385, 23)
        CB_Banns.TabIndex = 8
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(441, 130)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(441, 102)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 6
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(144, 60)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 68)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 27)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 35)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' OP_UPD_MANUALBANNS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_Banns)
        Name = "OP_UPD_MANUALBANNS"
        Text = "Edición de amonestaciones"
        WindowState = FormWindowState.Maximized
        CType(DGV_Banns, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DGV_Banns As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents LB_Banns As Label
    Friend WithEvents CB_Banns As ComboBox
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
End Class
