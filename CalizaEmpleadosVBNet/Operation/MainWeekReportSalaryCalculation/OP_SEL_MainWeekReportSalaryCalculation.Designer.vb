<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OP_SEL_MainWeekReportSalaryCalculation
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        GB_NumberOfWeek = New GroupBox()
        DTP_EndDate = New DateTimePicker()
        LB_EndDate = New Label()
        DTP_StartDate = New DateTimePicker()
        LB_StartDate = New Label()
        Label1 = New Label()
        DTP_WeekSelector = New DateTimePicker()
        Label5 = New Label()
        Panel1 = New Panel()
        Label6 = New Label()
        Label3 = New Label()
        PN_2 = New Panel()
        Label4 = New Label()
        LB_Absence = New Label()
        PN_4 = New Panel()
        LB_3 = New Label()
        LB_Incomplete = New Label()
        PN_1 = New Panel()
        LB_1 = New Label()
        PN_3 = New Panel()
        LB_2 = New Label()
        Label2 = New Label()
        DGV_CompleteWeekInfo = New DataGridView()
        DGV_BenefitsDetailsByEmployee = New DataGridView()
        LB_EmployeeDetailInfo = New Label()
        Label7 = New Label()
        Panel2 = New Panel()
        Label8 = New Label()
        CB_Confirmation = New CheckBox()
        BT_FinalConfirmation = New Button()
        GB_NumberOfWeek.SuspendLayout()
        Panel1.SuspendLayout()
        PN_2.SuspendLayout()
        PN_4.SuspendLayout()
        PN_1.SuspendLayout()
        PN_3.SuspendLayout()
        CType(DGV_CompleteWeekInfo, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_BenefitsDetailsByEmployee, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' GB_NumberOfWeek
        ' 
        GB_NumberOfWeek.Controls.Add(DTP_EndDate)
        GB_NumberOfWeek.Controls.Add(LB_EndDate)
        GB_NumberOfWeek.Controls.Add(DTP_StartDate)
        GB_NumberOfWeek.Controls.Add(LB_StartDate)
        GB_NumberOfWeek.Controls.Add(Label1)
        GB_NumberOfWeek.Controls.Add(DTP_WeekSelector)
        GB_NumberOfWeek.Location = New Point(12, 46)
        GB_NumberOfWeek.Name = "GB_NumberOfWeek"
        GB_NumberOfWeek.Size = New Size(616, 90)
        GB_NumberOfWeek.TabIndex = 0
        GB_NumberOfWeek.TabStop = False
        GB_NumberOfWeek.Text = "Información de la semana"
        ' 
        ' DTP_EndDate
        ' 
        DTP_EndDate.Location = New Point(396, 54)
        DTP_EndDate.Name = "DTP_EndDate"
        DTP_EndDate.Size = New Size(213, 23)
        DTP_EndDate.TabIndex = 5
        ' 
        ' LB_EndDate
        ' 
        LB_EndDate.AutoSize = True
        LB_EndDate.Location = New Point(320, 58)
        LB_EndDate.Name = "LB_EndDate"
        LB_EndDate.Size = New Size(74, 15)
        LB_EndDate.TabIndex = 4
        LB_EndDate.Text = "Fecha de fin:"
        ' 
        ' DTP_StartDate
        ' 
        DTP_StartDate.Location = New Point(99, 54)
        DTP_StartDate.Name = "DTP_StartDate"
        DTP_StartDate.Size = New Size(215, 23)
        DTP_StartDate.TabIndex = 3
        ' 
        ' LB_StartDate
        ' 
        LB_StartDate.AutoSize = True
        LB_StartDate.Location = New Point(8, 58)
        LB_StartDate.Name = "LB_StartDate"
        LB_StartDate.Size = New Size(89, 15)
        LB_StartDate.TabIndex = 2
        LB_StartDate.Text = "Fecha de inicio:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(171, 15)
        Label1.TabIndex = 1
        Label1.Text = "Selecciona un día de la semana"
        ' 
        ' DTP_WeekSelector
        ' 
        DTP_WeekSelector.Format = DateTimePickerFormat.Short
        DTP_WeekSelector.Location = New Point(189, 25)
        DTP_WeekSelector.Name = "DTP_WeekSelector"
        DTP_WeekSelector.Size = New Size(112, 23)
        DTP_WeekSelector.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(695, 117)
        Label5.Name = "Label5"
        Label5.Size = New Size(90, 15)
        Label5.TabIndex = 24
        Label5.Text = "Falta Justificada"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Label6)
        Panel1.Location = New Point(655, 114)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(40, 22)
        Panel1.TabIndex = 23
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(10, 2)
        Label6.Name = "Label6"
        Label6.Size = New Size(17, 15)
        Label6.TabIndex = 6
        Label6.Text = "FJ"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(695, 89)
        Label3.Name = "Label3"
        Label3.Size = New Size(32, 15)
        Label3.TabIndex = 9
        Label3.Text = "Falta"
        ' 
        ' PN_2
        ' 
        PN_2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        PN_2.BorderStyle = BorderStyle.Fixed3D
        PN_2.Controls.Add(Label4)
        PN_2.Location = New Point(655, 85)
        PN_2.Name = "PN_2"
        PN_2.Size = New Size(40, 22)
        PN_2.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 1)
        Label4.Name = "Label4"
        Label4.Size = New Size(13, 15)
        Label4.TabIndex = 6
        Label4.Text = "F"
        ' 
        ' LB_Absence
        ' 
        LB_Absence.AutoSize = True
        LB_Absence.Location = New Point(852, 118)
        LB_Absence.Name = "LB_Absence"
        LB_Absence.Size = New Size(50, 15)
        LB_Absence.TabIndex = 7
        LB_Absence.Text = "Permiso"
        ' 
        ' PN_4
        ' 
        PN_4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        PN_4.BorderStyle = BorderStyle.Fixed3D
        PN_4.Controls.Add(LB_3)
        PN_4.Location = New Point(811, 114)
        PN_4.Name = "PN_4"
        PN_4.Size = New Size(40, 22)
        PN_4.TabIndex = 6
        ' 
        ' LB_3
        ' 
        LB_3.AutoSize = True
        LB_3.Location = New Point(13, 2)
        LB_3.Name = "LB_3"
        LB_3.Size = New Size(14, 15)
        LB_3.TabIndex = 8
        LB_3.Text = "P"
        ' 
        ' LB_Incomplete
        ' 
        LB_Incomplete.AutoSize = True
        LB_Incomplete.Location = New Point(852, 88)
        LB_Incomplete.Name = "LB_Incomplete"
        LB_Incomplete.Size = New Size(65, 15)
        LB_Incomplete.TabIndex = 5
        LB_Incomplete.Text = "Vacaciones"
        ' 
        ' PN_1
        ' 
        PN_1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        PN_1.BorderStyle = BorderStyle.Fixed3D
        PN_1.Controls.Add(LB_1)
        PN_1.Location = New Point(655, 55)
        PN_1.Name = "PN_1"
        PN_1.Size = New Size(39, 22)
        PN_1.TabIndex = 2
        ' 
        ' LB_1
        ' 
        LB_1.AutoSize = True
        LB_1.Location = New Point(10, 2)
        LB_1.Name = "LB_1"
        LB_1.Size = New Size(15, 15)
        LB_1.TabIndex = 6
        LB_1.Text = "A"
        ' 
        ' PN_3
        ' 
        PN_3.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        PN_3.BorderStyle = BorderStyle.Fixed3D
        PN_3.Controls.Add(LB_2)
        PN_3.Location = New Point(811, 85)
        PN_3.Name = "PN_3"
        PN_3.Size = New Size(40, 22)
        PN_3.TabIndex = 4
        ' 
        ' LB_2
        ' 
        LB_2.AutoSize = True
        LB_2.Location = New Point(12, 2)
        LB_2.Name = "LB_2"
        LB_2.Size = New Size(14, 15)
        LB_2.TabIndex = 6
        LB_2.Text = "V"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(695, 59)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 15)
        Label2.TabIndex = 3
        Label2.Text = "Asistencia"
        ' 
        ' DGV_CompleteWeekInfo
        ' 
        DGV_CompleteWeekInfo.AllowUserToAddRows = False
        DGV_CompleteWeekInfo.AllowUserToDeleteRows = False
        DGV_CompleteWeekInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_CompleteWeekInfo.Location = New Point(12, 149)
        DGV_CompleteWeekInfo.Name = "DGV_CompleteWeekInfo"
        DGV_CompleteWeekInfo.ReadOnly = True
        DGV_CompleteWeekInfo.Size = New Size(1890, 294)
        DGV_CompleteWeekInfo.TabIndex = 1
        ' 
        ' DGV_BenefitsDetailsByEmployee
        ' 
        DGV_BenefitsDetailsByEmployee.AllowUserToAddRows = False
        DGV_BenefitsDetailsByEmployee.AllowUserToDeleteRows = False
        DGV_BenefitsDetailsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_BenefitsDetailsByEmployee.Location = New Point(12, 476)
        DGV_BenefitsDetailsByEmployee.Name = "DGV_BenefitsDetailsByEmployee"
        DGV_BenefitsDetailsByEmployee.ReadOnly = True
        DGV_BenefitsDetailsByEmployee.Size = New Size(1890, 220)
        DGV_BenefitsDetailsByEmployee.TabIndex = 22
        ' 
        ' LB_EmployeeDetailInfo
        ' 
        LB_EmployeeDetailInfo.AutoSize = True
        LB_EmployeeDetailInfo.Location = New Point(12, 458)
        LB_EmployeeDetailInfo.Name = "LB_EmployeeDetailInfo"
        LB_EmployeeDetailInfo.Size = New Size(120, 15)
        LB_EmployeeDetailInfo.TabIndex = 25
        LB_EmployeeDetailInfo.Text = "Detalle por empleado"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(852, 59)
        Label7.Name = "Label7"
        Label7.Size = New Size(48, 15)
        Label7.TabIndex = 27
        Label7.Text = "Retardo"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(Label8)
        Panel2.Location = New Point(811, 55)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(40, 22)
        Panel2.TabIndex = 26
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(13, 2)
        Label8.Name = "Label8"
        Label8.Size = New Size(14, 15)
        Label8.TabIndex = 8
        Label8.Text = "R"
        ' 
        ' CB_Confirmation
        ' 
        CB_Confirmation.AutoSize = True
        CB_Confirmation.Location = New Point(1776, 117)
        CB_Confirmation.Name = "CB_Confirmation"
        CB_Confirmation.Size = New Size(126, 19)
        CB_Confirmation.TabIndex = 28
        CB_Confirmation.Text = "Confirmar Nómina"
        CB_Confirmation.UseVisualStyleBackColor = True
        ' 
        ' BT_FinalConfirmation
        ' 
        BT_FinalConfirmation.BackColor = SystemColors.Info
        BT_FinalConfirmation.Location = New Point(1803, 449)
        BT_FinalConfirmation.Name = "BT_FinalConfirmation"
        BT_FinalConfirmation.Size = New Size(99, 23)
        BT_FinalConfirmation.TabIndex = 29
        BT_FinalConfirmation.Text = "Liberar Nómina"
        BT_FinalConfirmation.UseVisualStyleBackColor = False
        ' 
        ' OP_SEL_MainWeekReportSalaryCalculation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1930, 708)
        Controls.Add(BT_FinalConfirmation)
        Controls.Add(CB_Confirmation)
        Controls.Add(Label7)
        Controls.Add(Panel2)
        Controls.Add(LB_EmployeeDetailInfo)
        Controls.Add(Label5)
        Controls.Add(DGV_BenefitsDetailsByEmployee)
        Controls.Add(DGV_CompleteWeekInfo)
        Controls.Add(Panel1)
        Controls.Add(GB_NumberOfWeek)
        Controls.Add(LB_Absence)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(PN_3)
        Controls.Add(PN_1)
        Controls.Add(PN_2)
        Controls.Add(LB_Incomplete)
        Controls.Add(PN_4)
        Name = "OP_SEL_MainWeekReportSalaryCalculation"
        Text = "Reporte semanal"
        WindowState = FormWindowState.Maximized
        GB_NumberOfWeek.ResumeLayout(False)
        GB_NumberOfWeek.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        PN_2.ResumeLayout(False)
        PN_2.PerformLayout()
        PN_4.ResumeLayout(False)
        PN_4.PerformLayout()
        PN_1.ResumeLayout(False)
        PN_1.PerformLayout()
        PN_3.ResumeLayout(False)
        PN_3.PerformLayout()
        CType(DGV_CompleteWeekInfo, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_BenefitsDetailsByEmployee, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GB_NumberOfWeek As GroupBox
    Friend WithEvents DGV_CompleteWeekInfo As DataGridView
    Friend WithEvents DTP_WeekSelector As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DTP_EndDate As DateTimePicker
    Friend WithEvents LB_EndDate As Label
    Friend WithEvents DTP_StartDate As DateTimePicker
    Friend WithEvents LB_StartDate As Label
    Friend WithEvents PN_1 As Panel
    Friend WithEvents LB_1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PN_3 As Panel
    Friend WithEvents LB_2 As Label
    Friend WithEvents LB_Incomplete As Label
    Friend WithEvents PN_4 As Panel
    Friend WithEvents LB_3 As Label
    Friend WithEvents LB_Absence As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PN_2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents DGV_BenefitsDetailsByEmployee As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents LB_EmployeeDetailInfo As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents CB_Confirmation As CheckBox
    Friend WithEvents BT_FinalConfirmation As Button
End Class
