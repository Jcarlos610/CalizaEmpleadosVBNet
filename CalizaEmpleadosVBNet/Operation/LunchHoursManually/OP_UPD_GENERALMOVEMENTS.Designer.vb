<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_GENERALMOVEMENTS
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
        GB_EmployeesList = New GroupBox()
        DTP_EndDate = New DateTimePicker()
        LB_EndDate = New Label()
        DTP_StartDate = New DateTimePicker()
        LB_StartDate = New Label()
        BT_Update = New Button()
        DGV_ActiveEmployeesInfo = New DataGridView()
        LB_Title = New Label()
        GB_EmployeesList.SuspendLayout()
        CType(DGV_ActiveEmployeesInfo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_EmployeesList
        ' 
        GB_EmployeesList.Controls.Add(DTP_EndDate)
        GB_EmployeesList.Controls.Add(LB_EndDate)
        GB_EmployeesList.Controls.Add(DTP_StartDate)
        GB_EmployeesList.Controls.Add(LB_StartDate)
        GB_EmployeesList.Controls.Add(BT_Update)
        GB_EmployeesList.Controls.Add(DGV_ActiveEmployeesInfo)
        GB_EmployeesList.Location = New Point(12, 46)
        GB_EmployeesList.Name = "GB_EmployeesList"
        GB_EmployeesList.Padding = New Padding(4, 5, 4, 5)
        GB_EmployeesList.Size = New Size(1851, 953)
        GB_EmployeesList.TabIndex = 2
        GB_EmployeesList.TabStop = False
        GB_EmployeesList.Text = "Lista de empleados activos"
        ' 
        ' DTP_EndDate
        ' 
        DTP_EndDate.Location = New Point(411, 44)
        DTP_EndDate.Name = "DTP_EndDate"
        DTP_EndDate.Size = New Size(213, 23)
        DTP_EndDate.TabIndex = 11
        ' 
        ' LB_EndDate
        ' 
        LB_EndDate.AutoSize = True
        LB_EndDate.Location = New Point(335, 48)
        LB_EndDate.Name = "LB_EndDate"
        LB_EndDate.Size = New Size(74, 15)
        LB_EndDate.TabIndex = 10
        LB_EndDate.Text = "Fecha de fin:"
        ' 
        ' DTP_StartDate
        ' 
        DTP_StartDate.Location = New Point(114, 44)
        DTP_StartDate.Name = "DTP_StartDate"
        DTP_StartDate.Size = New Size(215, 23)
        DTP_StartDate.TabIndex = 9
        ' 
        ' LB_StartDate
        ' 
        LB_StartDate.AutoSize = True
        LB_StartDate.Location = New Point(23, 48)
        LB_StartDate.Name = "LB_StartDate"
        LB_StartDate.Size = New Size(89, 15)
        LB_StartDate.TabIndex = 8
        LB_StartDate.Text = "Fecha de inicio:"
        ' 
        ' BT_Update
        ' 
        BT_Update.Location = New Point(1729, 35)
        BT_Update.Margin = New Padding(4, 5, 4, 5)
        BT_Update.Name = "BT_Update"
        BT_Update.Size = New Size(85, 32)
        BT_Update.TabIndex = 6
        BT_Update.Text = "Validar"
        BT_Update.UseVisualStyleBackColor = True
        ' 
        ' DGV_ActiveEmployeesInfo
        ' 
        DGV_ActiveEmployeesInfo.AllowUserToAddRows = False
        DGV_ActiveEmployeesInfo.AllowUserToDeleteRows = False
        DGV_ActiveEmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_ActiveEmployeesInfo.Location = New Point(21, 85)
        DGV_ActiveEmployeesInfo.Name = "DGV_ActiveEmployeesInfo"
        DGV_ActiveEmployeesInfo.RowHeadersWidth = 62
        DGV_ActiveEmployeesInfo.Size = New Size(1793, 785)
        DGV_ActiveEmployeesInfo.TabIndex = 2
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(155, 30)
        LB_Title.TabIndex = 114
        LB_Title.Text = "Edición general"
        ' 
        ' OP_UPD_GENERALMOVEMENTS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1361, 630)
        Controls.Add(LB_Title)
        Controls.Add(GB_EmployeesList)
        Name = "OP_UPD_GENERALMOVEMENTS"
        Text = "Edición general"
        WindowState = FormWindowState.Maximized
        GB_EmployeesList.ResumeLayout(False)
        GB_EmployeesList.PerformLayout()
        CType(DGV_ActiveEmployeesInfo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GB_EmployeesList As GroupBox
    Friend WithEvents BT_Update As Button
    Friend WithEvents DGV_ActiveEmployeesInfo As DataGridView
    Friend WithEvents DTP_EndDate As DateTimePicker
    Friend WithEvents LB_EndDate As Label
    Friend WithEvents DTP_StartDate As DateTimePicker
    Friend WithEvents LB_StartDate As Label
    Friend WithEvents LB_Title As Label
End Class
