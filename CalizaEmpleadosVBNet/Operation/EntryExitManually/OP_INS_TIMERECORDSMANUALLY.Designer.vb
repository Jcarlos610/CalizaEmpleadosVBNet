<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_TIMERECORDSMANUALLY
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
        TB_Asistance = New TabControl()
        ManualAsistance = New TabPage()
        LB_AbsenceReason = New Label()
        TB_AbsenceReason = New TextBox()
        BT_AsistanceRegister = New Button()
        DTP_ManualAsistance = New DateTimePicker()
        LB_SetDateTime = New Label()
        ManualDelay = New TabPage()
        LB_DelayReason = New Label()
        TB_DelayComment = New TextBox()
        BT_UpdateDateTime = New Button()
        DTP_ManualDelay = New DateTimePicker()
        LB_DateTime = New Label()
        DGV_AllEmployees = New DataGridView()
        GB_EmployeeInfo = New GroupBox()
        LB_SelectEmployee = New Label()
        DGV_DisplayInformation = New DataGridView()
        TB_Asistance.SuspendLayout()
        ManualAsistance.SuspendLayout()
        ManualDelay.SuspendLayout()
        CType(DGV_AllEmployees, ComponentModel.ISupportInitialize).BeginInit()
        GB_EmployeeInfo.SuspendLayout()
        CType(DGV_DisplayInformation, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TB_Asistance
        ' 
        TB_Asistance.Controls.Add(ManualAsistance)
        TB_Asistance.Controls.Add(ManualDelay)
        TB_Asistance.Location = New Point(12, 282)
        TB_Asistance.Name = "TB_Asistance"
        TB_Asistance.SelectedIndex = 0
        TB_Asistance.Size = New Size(1247, 153)
        TB_Asistance.TabIndex = 2
        ' 
        ' ManualAsistance
        ' 
        ManualAsistance.BackColor = Color.White
        ManualAsistance.Controls.Add(LB_AbsenceReason)
        ManualAsistance.Controls.Add(TB_AbsenceReason)
        ManualAsistance.Controls.Add(BT_AsistanceRegister)
        ManualAsistance.Controls.Add(DTP_ManualAsistance)
        ManualAsistance.Controls.Add(LB_SetDateTime)
        ManualAsistance.ForeColor = SystemColors.ControlLightLight
        ManualAsistance.Location = New Point(4, 24)
        ManualAsistance.Name = "ManualAsistance"
        ManualAsistance.Padding = New Padding(3)
        ManualAsistance.Size = New Size(1239, 125)
        ManualAsistance.TabIndex = 0
        ManualAsistance.Text = "Registrar Asistencia"
        ' 
        ' LB_AbsenceReason
        ' 
        LB_AbsenceReason.AutoSize = True
        LB_AbsenceReason.ForeColor = SystemColors.ActiveCaptionText
        LB_AbsenceReason.Location = New Point(264, 11)
        LB_AbsenceReason.Name = "LB_AbsenceReason"
        LB_AbsenceReason.Size = New Size(145, 15)
        LB_AbsenceReason.TabIndex = 7
        LB_AbsenceReason.Text = "Indiqué la razón de la falta"
        ' 
        ' TB_AbsenceReason
        ' 
        TB_AbsenceReason.Location = New Point(264, 33)
        TB_AbsenceReason.Name = "TB_AbsenceReason"
        TB_AbsenceReason.Size = New Size(485, 23)
        TB_AbsenceReason.TabIndex = 5
        ' 
        ' BT_AsistanceRegister
        ' 
        BT_AsistanceRegister.ForeColor = SystemColors.ActiveCaptionText
        BT_AsistanceRegister.Location = New Point(768, 32)
        BT_AsistanceRegister.Name = "BT_AsistanceRegister"
        BT_AsistanceRegister.Size = New Size(128, 23)
        BT_AsistanceRegister.TabIndex = 6
        BT_AsistanceRegister.Text = "Registrar Asistencia"
        BT_AsistanceRegister.UseVisualStyleBackColor = True
        ' 
        ' DTP_ManualAsistance
        ' 
        DTP_ManualAsistance.Location = New Point(15, 33)
        DTP_ManualAsistance.Name = "DTP_ManualAsistance"
        DTP_ManualAsistance.Size = New Size(232, 23)
        DTP_ManualAsistance.TabIndex = 4
        ' 
        ' LB_SetDateTime
        ' 
        LB_SetDateTime.AutoSize = True
        LB_SetDateTime.ForeColor = SystemColors.ActiveCaptionText
        LB_SetDateTime.Location = New Point(15, 11)
        LB_SetDateTime.Name = "LB_SetDateTime"
        LB_SetDateTime.Size = New Size(115, 15)
        LB_SetDateTime.TabIndex = 3
        LB_SetDateTime.Text = "Indique fecha y hora"
        ' 
        ' ManualDelay
        ' 
        ManualDelay.BackColor = Color.White
        ManualDelay.Controls.Add(LB_DelayReason)
        ManualDelay.Controls.Add(TB_DelayComment)
        ManualDelay.Controls.Add(BT_UpdateDateTime)
        ManualDelay.Controls.Add(DTP_ManualDelay)
        ManualDelay.Controls.Add(LB_DateTime)
        ManualDelay.ForeColor = Color.White
        ManualDelay.Location = New Point(4, 24)
        ManualDelay.Name = "ManualDelay"
        ManualDelay.Padding = New Padding(3)
        ManualDelay.Size = New Size(1239, 125)
        ManualDelay.TabIndex = 1
        ManualDelay.Text = "Justificar Retardo"
        ' 
        ' LB_DelayReason
        ' 
        LB_DelayReason.AutoSize = True
        LB_DelayReason.ForeColor = Color.Black
        LB_DelayReason.Location = New Point(315, 11)
        LB_DelayReason.Name = "LB_DelayReason"
        LB_DelayReason.Size = New Size(151, 15)
        LB_DelayReason.TabIndex = 4
        LB_DelayReason.Text = "Indique la razón del retardo"
        ' 
        ' TB_DelayComment
        ' 
        TB_DelayComment.Location = New Point(315, 33)
        TB_DelayComment.Name = "TB_DelayComment"
        TB_DelayComment.Size = New Size(438, 23)
        TB_DelayComment.TabIndex = 2
        ' 
        ' BT_UpdateDateTime
        ' 
        BT_UpdateDateTime.ForeColor = Color.Black
        BT_UpdateDateTime.Location = New Point(768, 32)
        BT_UpdateDateTime.Name = "BT_UpdateDateTime"
        BT_UpdateDateTime.Size = New Size(138, 23)
        BT_UpdateDateTime.TabIndex = 3
        BT_UpdateDateTime.Text = "Justificar Retardo"
        BT_UpdateDateTime.UseVisualStyleBackColor = True
        ' 
        ' DTP_ManualDelay
        ' 
        DTP_ManualDelay.Location = New Point(15, 33)
        DTP_ManualDelay.Name = "DTP_ManualDelay"
        DTP_ManualDelay.Size = New Size(278, 23)
        DTP_ManualDelay.TabIndex = 1
        ' 
        ' LB_DateTime
        ' 
        LB_DateTime.AutoSize = True
        LB_DateTime.ForeColor = Color.Black
        LB_DateTime.Location = New Point(15, 11)
        LB_DateTime.Name = "LB_DateTime"
        LB_DateTime.Size = New Size(145, 15)
        LB_DateTime.TabIndex = 0
        LB_DateTime.Text = "Indique la hora de entrada"
        ' 
        ' DGV_AllEmployees
        ' 
        DGV_AllEmployees.AllowUserToAddRows = False
        DGV_AllEmployees.AllowUserToDeleteRows = False
        DGV_AllEmployees.AllowUserToOrderColumns = True
        DGV_AllEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_AllEmployees.Location = New Point(15, 50)
        DGV_AllEmployees.Name = "DGV_AllEmployees"
        DGV_AllEmployees.ReadOnly = True
        DGV_AllEmployees.RowHeadersWidth = 62
        DGV_AllEmployees.Size = New Size(1208, 163)
        DGV_AllEmployees.TabIndex = 1
        ' 
        ' GB_EmployeeInfo
        ' 
        GB_EmployeeInfo.Controls.Add(LB_SelectEmployee)
        GB_EmployeeInfo.Controls.Add(DGV_AllEmployees)
        GB_EmployeeInfo.Location = New Point(12, 46)
        GB_EmployeeInfo.Name = "GB_EmployeeInfo"
        GB_EmployeeInfo.Size = New Size(1247, 230)
        GB_EmployeeInfo.TabIndex = 1
        GB_EmployeeInfo.TabStop = False
        GB_EmployeeInfo.Text = "Información del empleado"
        ' 
        ' LB_SelectEmployee
        ' 
        LB_SelectEmployee.AutoSize = True
        LB_SelectEmployee.ForeColor = SystemColors.ActiveCaptionText
        LB_SelectEmployee.Location = New Point(15, 32)
        LB_SelectEmployee.Name = "LB_SelectEmployee"
        LB_SelectEmployee.Size = New Size(136, 15)
        LB_SelectEmployee.TabIndex = 2
        LB_SelectEmployee.Text = "Seleccione un empleado"
        ' 
        ' DGV_DisplayInformation
        ' 
        DGV_DisplayInformation.AllowUserToAddRows = False
        DGV_DisplayInformation.AllowUserToDeleteRows = False
        DGV_DisplayInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DisplayInformation.Location = New Point(12, 452)
        DGV_DisplayInformation.Name = "DGV_DisplayInformation"
        DGV_DisplayInformation.ReadOnly = True
        DGV_DisplayInformation.Size = New Size(1247, 150)
        DGV_DisplayInformation.TabIndex = 3
        ' 
        ' OP_INS_TIMERECORDSMANUALLY
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1408, 694)
        Controls.Add(DGV_DisplayInformation)
        Controls.Add(GB_EmployeeInfo)
        Controls.Add(TB_Asistance)
        ForeColor = SystemColors.ControlText
        Name = "OP_INS_TIMERECORDSMANUALLY"
        Text = "Registrar manualmente entradas"
        WindowState = FormWindowState.Maximized
        TB_Asistance.ResumeLayout(False)
        ManualAsistance.ResumeLayout(False)
        ManualAsistance.PerformLayout()
        ManualDelay.ResumeLayout(False)
        ManualDelay.PerformLayout()
        CType(DGV_AllEmployees, ComponentModel.ISupportInitialize).EndInit()
        GB_EmployeeInfo.ResumeLayout(False)
        GB_EmployeeInfo.PerformLayout()
        CType(DGV_DisplayInformation, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents TB_Asistance As TabControl
    Friend WithEvents ManualAsistance As TabPage
    Friend WithEvents ManualDelay As TabPage
    Friend WithEvents LB_SetDateTime As Label
    Friend WithEvents DGV_AllEmployees As DataGridView
    Friend WithEvents DTP_ManualAsistance As DateTimePicker
    Friend WithEvents BT_AsistanceRegister As Button
    Friend WithEvents GB_EmployeeInfo As GroupBox
    Friend WithEvents LB_SelectEmployee As Label
    Friend WithEvents DGV_DisplayInformation As DataGridView
    Friend WithEvents BT_UpdateDateTime As Button
    Friend WithEvents DTP_ManualDelay As DateTimePicker
    Friend WithEvents LB_DateTime As Label
    Friend WithEvents LB_DelayReason As Label
    Friend WithEvents TB_DelayComment As TextBox
    Friend WithEvents LB_AbsenceReason As Label
    Friend WithEvents TB_AbsenceReason As TextBox
End Class
