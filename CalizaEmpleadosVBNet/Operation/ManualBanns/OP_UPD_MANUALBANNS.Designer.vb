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
        TB_BannDays = New TextBox()
        LB_BannDays = New Label()
        LB_Description = New Label()
        TB_Description = New TextBox()
        TB_BannName = New TextBox()
        BT_Upd = New Button()
        LB_BannNmae = New Label()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        CB_Status = New CheckBox()
        LB_Title = New Label()
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
        GroupBox1.Controls.Add(TB_BannDays)
        GroupBox1.Controls.Add(LB_BannDays)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_BannName)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(LB_BannNmae)
        GroupBox1.Controls.Add(DTP_Valid)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Location = New Point(12, 462)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 278)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre amonestaciones"
        ' 
        ' TB_BannDays
        ' 
        TB_BannDays.BackColor = SystemColors.Info
        TB_BannDays.Location = New Point(441, 223)
        TB_BannDays.Name = "TB_BannDays"
        TB_BannDays.Size = New Size(120, 23)
        TB_BannDays.TabIndex = 33
        ' 
        ' LB_BannDays
        ' 
        LB_BannDays.AutoSize = True
        LB_BannDays.Location = New Point(441, 200)
        LB_BannDays.Name = "LB_BannDays"
        LB_BannDays.Size = New Size(29, 15)
        LB_BannDays.TabIndex = 32
        LB_BannDays.Text = "Días"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(15, 158)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 31
        LB_Description.Text = "Descripción"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(15, 176)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 30
        ' 
        ' TB_BannName
        ' 
        TB_BannName.Location = New Point(15, 123)
        TB_BannName.Name = "TB_BannName"
        TB_BannName.Size = New Size(222, 23)
        TB_BannName.TabIndex = 29
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(1118, 225)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 28
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' LB_BannNmae
        ' 
        LB_BannNmae.AutoSize = True
        LB_BannNmae.Location = New Point(15, 105)
        LB_BannNmae.Name = "LB_BannNmae"
        LB_BannNmae.Size = New Size(83, 15)
        LB_BannNmae.TabIndex = 27
        LB_BannNmae.Text = "Amonestació: "
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(582, 223)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 26
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(582, 200)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 25
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 62)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 24
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 70)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 23
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 24)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 22
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 32)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 21
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(1135, 28)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(58, 19)
        CB_Status.TabIndex = 20
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(265, 30)
        LB_Title.TabIndex = 114
        LB_Title.Text = "Edición de amonestaciones"
        ' 
        ' OP_UPD_MANUALBANNS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 824)
        Controls.Add(LB_Title)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_Banns)
        Name = "OP_UPD_MANUALBANNS"
        Text = "Edición de amonestaciones"
        WindowState = FormWindowState.Maximized
        CType(DGV_Banns, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DGV_Banns As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CB_Status As CheckBox
    Friend WithEvents TB_BannDays As TextBox
    Friend WithEvents LB_BannDays As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_BannName As TextBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents LB_BannNmae As Label
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents LB_Title As Label
End Class
