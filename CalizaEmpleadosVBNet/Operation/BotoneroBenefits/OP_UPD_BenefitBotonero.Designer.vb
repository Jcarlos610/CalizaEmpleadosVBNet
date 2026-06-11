<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_BenefitBotonero
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
        CB_Status = New CheckBox()
        DTP_EndDate = New DateTimePicker()
        LB_EndDate = New Label()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        LB_Comment = New Label()
        TB_Comment = New TextBox()
        BT_UPD = New Button()
        DTP_StartDate = New DateTimePicker()
        LB_StartDate = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        GB_DebtInformation = New GroupBox()
        LB_SelectEmployee = New Label()
        DGV_PendingBotoneros = New DataGridView()
        LB_Title = New Label()
        GroupBox1.SuspendLayout()
        GB_DebtInformation.SuspendLayout()
        CType(DGV_PendingBotoneros, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Controls.Add(DTP_EndDate)
        GroupBox1.Controls.Add(LB_EndDate)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Comment)
        GroupBox1.Controls.Add(TB_Comment)
        GroupBox1.Controls.Add(BT_UPD)
        GroupBox1.Controls.Add(DTP_StartDate)
        GroupBox1.Controls.Add(LB_StartDate)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 417)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 269)
        GroupBox1.TabIndex = 117
        GroupBox1.TabStop = False
        GroupBox1.Text = "Detalles de Validación (Vigencia de 3 meses)"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(1124, 31)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(58, 19)
        CB_Status.TabIndex = 26
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' DTP_EndDate
        ' 
        DTP_EndDate.Location = New Point(707, 210)
        DTP_EndDate.Name = "DTP_EndDate"
        DTP_EndDate.Size = New Size(232, 23)
        DTP_EndDate.TabIndex = 25
        ' 
        ' LB_EndDate
        ' 
        LB_EndDate.AutoSize = True
        LB_EndDate.Location = New Point(707, 187)
        LB_EndDate.Name = "LB_EndDate"
        LB_EndDate.Size = New Size(74, 15)
        LB_EndDate.TabIndex = 24
        LB_EndDate.Text = "Fecha de fin:"
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(18, 109)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 23
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(113, 101)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 22
        ' 
        ' LB_Comment
        ' 
        LB_Comment.AutoSize = True
        LB_Comment.Location = New Point(18, 146)
        LB_Comment.Name = "LB_Comment"
        LB_Comment.Size = New Size(73, 15)
        LB_Comment.TabIndex = 14
        LB_Comment.Text = "Comentario:"
        ' 
        ' TB_Comment
        ' 
        TB_Comment.Location = New Point(18, 164)
        TB_Comment.Multiline = True
        TB_Comment.Name = "TB_Comment"
        TB_Comment.Size = New Size(404, 70)
        TB_Comment.TabIndex = 13
        ' 
        ' BT_UPD
        ' 
        BT_UPD.Location = New Point(1124, 212)
        BT_UPD.Name = "BT_UPD"
        BT_UPD.Size = New Size(75, 23)
        BT_UPD.TabIndex = 10
        BT_UPD.Text = "Actualizar"
        BT_UPD.UseVisualStyleBackColor = True
        ' 
        ' DTP_StartDate
        ' 
        DTP_StartDate.Location = New Point(443, 210)
        DTP_StartDate.Name = "DTP_StartDate"
        DTP_StartDate.Size = New Size(232, 23)
        DTP_StartDate.TabIndex = 7
        ' 
        ' LB_StartDate
        ' 
        LB_StartDate.AutoSize = True
        LB_StartDate.Location = New Point(443, 187)
        LB_StartDate.Name = "LB_StartDate"
        LB_StartDate.Size = New Size(89, 15)
        LB_StartDate.TabIndex = 6
        LB_StartDate.Text = "Fecha de inicio:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(150, 69)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(18, 77)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(150, 31)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(18, 39)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' GB_DebtInformation
        ' 
        GB_DebtInformation.Controls.Add(LB_SelectEmployee)
        GB_DebtInformation.Controls.Add(DGV_PendingBotoneros)
        GB_DebtInformation.Location = New Point(12, 46)
        GB_DebtInformation.Name = "GB_DebtInformation"
        GB_DebtInformation.Size = New Size(1218, 353)
        GB_DebtInformation.TabIndex = 116
        GB_DebtInformation.TabStop = False
        GB_DebtInformation.Text = "Empleados con Bono de Botonero"
        ' 
        ' LB_SelectEmployee
        ' 
        LB_SelectEmployee.AutoSize = True
        LB_SelectEmployee.ForeColor = SystemColors.ActiveCaptionText
        LB_SelectEmployee.Location = New Point(18, 31)
        LB_SelectEmployee.Name = "LB_SelectEmployee"
        LB_SelectEmployee.Size = New Size(0, 15)
        LB_SelectEmployee.TabIndex = 14
        ' 
        ' DGV_PendingBotoneros
        ' 
        DGV_PendingBotoneros.AllowUserToAddRows = False
        DGV_PendingBotoneros.AllowUserToDeleteRows = False
        DGV_PendingBotoneros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_PendingBotoneros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_PendingBotoneros.Location = New Point(18, 31)
        DGV_PendingBotoneros.Margin = New Padding(2)
        DGV_PendingBotoneros.Name = "DGV_PendingBotoneros"
        DGV_PendingBotoneros.ReadOnly = True
        DGV_PendingBotoneros.RowHeadersWidth = 62
        DGV_PendingBotoneros.Size = New Size(1181, 306)
        DGV_PendingBotoneros.TabIndex = 0
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(177, 30)
        LB_Title.TabIndex = 115
        LB_Title.Text = "Editar asignación "
        ' 
        ' OP_UPD_BenefitBotonero
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 717)
        Controls.Add(GroupBox1)
        Controls.Add(GB_DebtInformation)
        Controls.Add(LB_Title)
        Name = "OP_UPD_BenefitBotonero"
        Text = "Editar asignación"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GB_DebtInformation.ResumeLayout(False)
        GB_DebtInformation.PerformLayout()
        CType(DGV_PendingBotoneros, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DTP_EndDate As DateTimePicker
    Friend WithEvents LB_EndDate As Label
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents LB_Comment As Label
    Friend WithEvents TB_Comment As TextBox
    Friend WithEvents BT_UPD As Button
    Friend WithEvents DTP_StartDate As DateTimePicker
    Friend WithEvents LB_StartDate As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents GB_DebtInformation As GroupBox
    Friend WithEvents LB_SelectEmployee As Label
    Friend WithEvents DGV_PendingBotoneros As DataGridView
    Friend WithEvents LB_Title As Label
    Friend WithEvents CB_Status As CheckBox
End Class
