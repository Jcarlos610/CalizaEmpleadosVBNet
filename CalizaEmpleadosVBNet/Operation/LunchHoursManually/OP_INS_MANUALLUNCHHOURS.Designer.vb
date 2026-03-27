<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_MANUALLUNCHHOURS
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
        BT_LuchHoursRegister = New Button()
        DTP_DateLunchHours = New DateTimePicker()
        LB_SetDate = New Label()
        DGV_ActiveEmployeesInfo = New DataGridView()
        GB_EmployeesList.SuspendLayout()
        CType(DGV_ActiveEmployeesInfo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_EmployeesList
        ' 
        GB_EmployeesList.Controls.Add(BT_LuchHoursRegister)
        GB_EmployeesList.Controls.Add(DTP_DateLunchHours)
        GB_EmployeesList.Controls.Add(LB_SetDate)
        GB_EmployeesList.Controls.Add(DGV_ActiveEmployeesInfo)
        GB_EmployeesList.Location = New Point(12, 46)
        GB_EmployeesList.Name = "GB_EmployeesList"
        GB_EmployeesList.Size = New Size(1124, 572)
        GB_EmployeesList.TabIndex = 0
        GB_EmployeesList.TabStop = False
        GB_EmployeesList.Text = "Lista de empleados activos"
        ' 
        ' BT_LuchHoursRegister
        ' 
        BT_LuchHoursRegister.Location = New Point(984, 56)
        BT_LuchHoursRegister.Name = "BT_LuchHoursRegister"
        BT_LuchHoursRegister.Size = New Size(106, 23)
        BT_LuchHoursRegister.TabIndex = 6
        BT_LuchHoursRegister.Text = "Registrar horas"
        BT_LuchHoursRegister.UseVisualStyleBackColor = True
        ' 
        ' DTP_DateLunchHours
        ' 
        DTP_DateLunchHours.Location = New Point(21, 47)
        DTP_DateLunchHours.Name = "DTP_DateLunchHours"
        DTP_DateLunchHours.Size = New Size(234, 23)
        DTP_DateLunchHours.TabIndex = 4
        ' 
        ' LB_SetDate
        ' 
        LB_SetDate.AutoSize = True
        LB_SetDate.Location = New Point(21, 29)
        LB_SetDate.Name = "LB_SetDate"
        LB_SetDate.Size = New Size(166, 15)
        LB_SetDate.TabIndex = 3
        LB_SetDate.Text = "Seleccione la fecha de registro"
        ' 
        ' DGV_ActiveEmployeesInfo
        ' 
        DGV_ActiveEmployeesInfo.AllowUserToAddRows = False
        DGV_ActiveEmployeesInfo.AllowUserToDeleteRows = False
        DGV_ActiveEmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_ActiveEmployeesInfo.Location = New Point(21, 85)
        DGV_ActiveEmployeesInfo.Name = "DGV_ActiveEmployeesInfo"
        DGV_ActiveEmployeesInfo.Size = New Size(1069, 471)
        DGV_ActiveEmployeesInfo.TabIndex = 2
        ' 
        ' OP_INS_MANUALLUNCHHOURS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(GB_EmployeesList)
        Name = "OP_INS_MANUALLUNCHHOURS"
        Text = "Registro de horas de comida"
        WindowState = FormWindowState.Maximized
        GB_EmployeesList.ResumeLayout(False)
        GB_EmployeesList.PerformLayout()
        CType(DGV_ActiveEmployeesInfo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GB_EmployeesList As GroupBox
    Friend WithEvents DGV_ActiveEmployeesInfo As DataGridView
    Friend WithEvents DTP_DateLunchHours As DateTimePicker
    Friend WithEvents LB_SetDate As Label
    Friend WithEvents BT_LuchHoursRegister As Button
End Class
