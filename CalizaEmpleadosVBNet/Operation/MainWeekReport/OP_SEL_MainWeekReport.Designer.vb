<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_SEL_MainWeekReport
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
        GB_NumberOfWeek = New GroupBox()
        DTP_EndDate = New DateTimePicker()
        LB_EndDate = New Label()
        DTP_StartDate = New DateTimePicker()
        LB_StartDate = New Label()
        Label1 = New Label()
        DTP_WeekSelector = New DateTimePicker()
        DGV_CompleteWeekInfo = New DataGridView()
        PN_1 = New Panel()
        LB_1 = New Label()
        Label2 = New Label()
        PN_3 = New Panel()
        LB_2 = New Label()
        LB_Incomplete = New Label()
        PN_4 = New Panel()
        LB_3 = New Label()
        LB_Absence = New Label()
        Label3 = New Label()
        PN_2 = New Panel()
        Label4 = New Label()
        LB_6 = New Label()
        PN_6 = New Panel()
        Label6 = New Label()
        LB_5 = New Label()
        PN_5 = New Panel()
        Label8 = New Label()
        Label5 = New Label()
        PN_8 = New Panel()
        Label7 = New Label()
        Label9 = New Label()
        PN_7 = New Panel()
        Label10 = New Label()
        Label11 = New Label()
        Panel1 = New Panel()
        Label12 = New Label()
        Label13 = New Label()
        Panel2 = New Panel()
        Label14 = New Label()
        DGV_DetailsByEmployee = New DataGridView()
        GB_NumberOfWeek.SuspendLayout()
        CType(DGV_CompleteWeekInfo, ComponentModel.ISupportInitialize).BeginInit()
        PN_1.SuspendLayout()
        PN_3.SuspendLayout()
        PN_4.SuspendLayout()
        PN_2.SuspendLayout()
        PN_6.SuspendLayout()
        PN_5.SuspendLayout()
        PN_8.SuspendLayout()
        PN_7.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DGV_DetailsByEmployee, ComponentModel.ISupportInitialize).BeginInit()
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
        GB_NumberOfWeek.Size = New Size(374, 135)
        GB_NumberOfWeek.TabIndex = 0
        GB_NumberOfWeek.TabStop = False
        GB_NumberOfWeek.Text = "Información de la semana"
        ' 
        ' DTP_EndDate
        ' 
        DTP_EndDate.Location = New Point(113, 87)
        DTP_EndDate.Name = "DTP_EndDate"
        DTP_EndDate.Size = New Size(235, 23)
        DTP_EndDate.TabIndex = 5
        ' 
        ' LB_EndDate
        ' 
        LB_EndDate.AutoSize = True
        LB_EndDate.Location = New Point(21, 93)
        LB_EndDate.Name = "LB_EndDate"
        LB_EndDate.Size = New Size(74, 15)
        LB_EndDate.TabIndex = 4
        LB_EndDate.Text = "Fecha de fin:"
        ' 
        ' DTP_StartDate
        ' 
        DTP_StartDate.Location = New Point(113, 58)
        DTP_StartDate.Name = "DTP_StartDate"
        DTP_StartDate.Size = New Size(232, 23)
        DTP_StartDate.TabIndex = 3
        ' 
        ' LB_StartDate
        ' 
        LB_StartDate.AutoSize = True
        LB_StartDate.Location = New Point(17, 63)
        LB_StartDate.Name = "LB_StartDate"
        LB_StartDate.Size = New Size(86, 15)
        LB_StartDate.TabIndex = 2
        LB_StartDate.Text = "Fecha de inicio"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(17, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(171, 15)
        Label1.TabIndex = 1
        Label1.Text = "Selecciona un día de la semana"
        ' 
        ' DTP_WeekSelector
        ' 
        DTP_WeekSelector.Format = DateTimePickerFormat.Short
        DTP_WeekSelector.Location = New Point(194, 29)
        DTP_WeekSelector.Name = "DTP_WeekSelector"
        DTP_WeekSelector.Size = New Size(112, 23)
        DTP_WeekSelector.TabIndex = 0
        ' 
        ' DGV_CompleteWeekInfo
        ' 
        DGV_CompleteWeekInfo.AllowUserToAddRows = False
        DGV_CompleteWeekInfo.AllowUserToDeleteRows = False
        DGV_CompleteWeekInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_CompleteWeekInfo.Location = New Point(12, 199)
        DGV_CompleteWeekInfo.Name = "DGV_CompleteWeekInfo"
        DGV_CompleteWeekInfo.ReadOnly = True
        DGV_CompleteWeekInfo.Size = New Size(1232, 244)
        DGV_CompleteWeekInfo.TabIndex = 1
        ' 
        ' PN_1
        ' 
        PN_1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        PN_1.BorderStyle = BorderStyle.Fixed3D
        PN_1.Controls.Add(LB_1)
        PN_1.Location = New Point(400, 54)
        PN_1.Name = "PN_1"
        PN_1.Size = New Size(65, 22)
        PN_1.TabIndex = 2
        ' 
        ' LB_1
        ' 
        LB_1.AutoSize = True
        LB_1.Location = New Point(23, 3)
        LB_1.Name = "LB_1"
        LB_1.Size = New Size(19, 15)
        LB_1.TabIndex = 6
        LB_1.Text = "JC"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(471, 58)
        Label2.Name = "Label2"
        Label2.Size = New Size(103, 15)
        Label2.TabIndex = 3
        Label2.Text = "Jornada Completa"
        ' 
        ' PN_3
        ' 
        PN_3.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        PN_3.BorderStyle = BorderStyle.Fixed3D
        PN_3.Controls.Add(LB_2)
        PN_3.Location = New Point(400, 105)
        PN_3.Name = "PN_3"
        PN_3.Size = New Size(65, 22)
        PN_3.TabIndex = 4
        ' 
        ' LB_2
        ' 
        LB_2.AutoSize = True
        LB_2.Location = New Point(5, 3)
        LB_2.Name = "LB_2"
        LB_2.Size = New Size(51, 15)
        LB_2.TabIndex = 6
        LB_2.Text = "JI-EP-SA"
        ' 
        ' LB_Incomplete
        ' 
        LB_Incomplete.AutoSize = True
        LB_Incomplete.Location = New Point(471, 109)
        LB_Incomplete.Name = "LB_Incomplete"
        LB_Incomplete.Size = New Size(309, 15)
        LB_Incomplete.TabIndex = 5
        LB_Incomplete.Text = "Jornada Incompleta - Entrada Puntual y Salida Anticipada"
        ' 
        ' PN_4
        ' 
        PN_4.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        PN_4.BorderStyle = BorderStyle.Fixed3D
        PN_4.Controls.Add(LB_3)
        PN_4.Location = New Point(400, 131)
        PN_4.Name = "PN_4"
        PN_4.Size = New Size(65, 22)
        PN_4.TabIndex = 6
        ' 
        ' LB_3
        ' 
        LB_3.AutoSize = True
        LB_3.Location = New Point(5, 3)
        LB_3.Name = "LB_3"
        LB_3.Size = New Size(51, 15)
        LB_3.TabIndex = 8
        LB_3.Text = "JI-ER-SA"
        ' 
        ' LB_Absence
        ' 
        LB_Absence.AutoSize = True
        LB_Absence.Location = New Point(471, 135)
        LB_Absence.Name = "LB_Absence"
        LB_Absence.Size = New Size(323, 15)
        LB_Absence.TabIndex = 7
        LB_Absence.Text = "Jornada Incompleta - Entrada con Retardo Salida Anticipada"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(471, 84)
        Label3.Name = "Label3"
        Label3.Size = New Size(183, 15)
        Label3.TabIndex = 9
        Label3.Text = "Jornada Completa con Tolerancia"
        ' 
        ' PN_2
        ' 
        PN_2.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        PN_2.BorderStyle = BorderStyle.Fixed3D
        PN_2.Controls.Add(Label4)
        PN_2.Location = New Point(400, 80)
        PN_2.Name = "PN_2"
        PN_2.Size = New Size(65, 22)
        PN_2.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(17, 2)
        Label4.Name = "Label4"
        Label4.Size = New Size(31, 15)
        Label4.TabIndex = 6
        Label4.Text = "JC-T"
        ' 
        ' LB_6
        ' 
        LB_6.AutoSize = True
        LB_6.Location = New Point(873, 61)
        LB_6.Name = "LB_6"
        LB_6.Size = New Size(336, 15)
        LB_6.TabIndex = 13
        LB_6.Text = "Jornada Incompleta - Entrada con Tolerancia Salida Anticipada"
        ' 
        ' PN_6
        ' 
        PN_6.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        PN_6.BorderStyle = BorderStyle.Fixed3D
        PN_6.Controls.Add(Label6)
        PN_6.Location = New Point(802, 57)
        PN_6.Name = "PN_6"
        PN_6.Size = New Size(65, 22)
        PN_6.TabIndex = 12
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(5, 2)
        Label6.Name = "Label6"
        Label6.Size = New Size(51, 15)
        Label6.TabIndex = 8
        Label6.Text = "JI-ET-SA"
        ' 
        ' LB_5
        ' 
        LB_5.AutoSize = True
        LB_5.Location = New Point(471, 160)
        LB_5.Name = "LB_5"
        LB_5.Size = New Size(307, 15)
        LB_5.TabIndex = 11
        LB_5.Text = "Jornada Incompleta - Entrada con Retardo Salida Puntual"
        ' 
        ' PN_5
        ' 
        PN_5.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        PN_5.BorderStyle = BorderStyle.Fixed3D
        PN_5.Controls.Add(Label8)
        PN_5.Location = New Point(400, 156)
        PN_5.Name = "PN_5"
        PN_5.Size = New Size(65, 22)
        PN_5.TabIndex = 10
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(5, 3)
        Label8.Name = "Label8"
        Label8.Size = New Size(50, 15)
        Label8.TabIndex = 6
        Label8.Text = "JI-ER-SP"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(873, 112)
        Label5.Name = "Label5"
        Label5.Size = New Size(107, 15)
        Label5.TabIndex = 17
        Label5.Text = "Retardo Justificado"
        ' 
        ' PN_8
        ' 
        PN_8.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        PN_8.BorderStyle = BorderStyle.Fixed3D
        PN_8.Controls.Add(Label7)
        PN_8.Location = New Point(802, 108)
        PN_8.Name = "PN_8"
        PN_8.Size = New Size(65, 22)
        PN_8.TabIndex = 16
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(23, 2)
        Label7.Name = "Label7"
        Label7.Size = New Size(18, 15)
        Label7.TabIndex = 8
        Label7.Text = "RJ"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(873, 86)
        Label9.Name = "Label9"
        Label9.Size = New Size(197, 15)
        Label9.TabIndex = 15
        Label9.Text = "Jornada Completa - Falta Justificada"
        ' 
        ' PN_7
        ' 
        PN_7.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        PN_7.BorderStyle = BorderStyle.Fixed3D
        PN_7.Controls.Add(Label10)
        PN_7.Location = New Point(802, 82)
        PN_7.Name = "PN_7"
        PN_7.Size = New Size(65, 22)
        PN_7.TabIndex = 14
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(11, 3)
        Label10.Name = "Label10"
        Label10.Size = New Size(34, 15)
        Label10.TabIndex = 6
        Label10.Text = "JC-FJ"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(873, 138)
        Label11.Name = "Label11"
        Label11.Size = New Size(223, 15)
        Label11.TabIndex = 19
        Label11.Text = "Jornada Completa con Tiempo Adicional"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Label12)
        Panel1.Location = New Point(802, 134)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(65, 22)
        Panel1.TabIndex = 18
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(13, 2)
        Label12.Name = "Label12"
        Label12.Size = New Size(38, 15)
        Label12.TabIndex = 8
        Label12.Text = "JC-TA"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(873, 163)
        Label13.Name = "Label13"
        Label13.Size = New Size(99, 15)
        Label13.TabIndex = 21
        Label13.Text = "Falta Injustificada"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(Label14)
        Panel2.Location = New Point(802, 159)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(65, 22)
        Panel2.TabIndex = 20
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(24, 2)
        Label14.Name = "Label14"
        Label14.Size = New Size(16, 15)
        Label14.TabIndex = 8
        Label14.Text = "FI"
        ' 
        ' DGV_DetailsByEmployee
        ' 
        DGV_DetailsByEmployee.AllowUserToAddRows = False
        DGV_DetailsByEmployee.AllowUserToDeleteRows = False
        DGV_DetailsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DetailsByEmployee.Location = New Point(12, 459)
        DGV_DetailsByEmployee.Name = "DGV_DetailsByEmployee"
        DGV_DetailsByEmployee.ReadOnly = True
        DGV_DetailsByEmployee.Size = New Size(1232, 237)
        DGV_DetailsByEmployee.TabIndex = 22
        ' 
        ' OP_SEL_MainWeekReport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1262, 708)
        Controls.Add(DGV_DetailsByEmployee)
        Controls.Add(Label13)
        Controls.Add(Panel2)
        Controls.Add(Label11)
        Controls.Add(Panel1)
        Controls.Add(Label5)
        Controls.Add(PN_8)
        Controls.Add(Label9)
        Controls.Add(PN_7)
        Controls.Add(LB_6)
        Controls.Add(PN_6)
        Controls.Add(LB_5)
        Controls.Add(PN_5)
        Controls.Add(Label3)
        Controls.Add(PN_2)
        Controls.Add(LB_Absence)
        Controls.Add(PN_4)
        Controls.Add(LB_Incomplete)
        Controls.Add(PN_3)
        Controls.Add(Label2)
        Controls.Add(PN_1)
        Controls.Add(DGV_CompleteWeekInfo)
        Controls.Add(GB_NumberOfWeek)
        Name = "OP_SEL_MainWeekReport"
        Text = "Reporte semanal"
        WindowState = FormWindowState.Maximized
        GB_NumberOfWeek.ResumeLayout(False)
        GB_NumberOfWeek.PerformLayout()
        CType(DGV_CompleteWeekInfo, ComponentModel.ISupportInitialize).EndInit()
        PN_1.ResumeLayout(False)
        PN_1.PerformLayout()
        PN_3.ResumeLayout(False)
        PN_3.PerformLayout()
        PN_4.ResumeLayout(False)
        PN_4.PerformLayout()
        PN_2.ResumeLayout(False)
        PN_2.PerformLayout()
        PN_6.ResumeLayout(False)
        PN_6.PerformLayout()
        PN_5.ResumeLayout(False)
        PN_5.PerformLayout()
        PN_8.ResumeLayout(False)
        PN_8.PerformLayout()
        PN_7.ResumeLayout(False)
        PN_7.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DGV_DetailsByEmployee, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LB_6 As Label
    Friend WithEvents PN_6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents LB_5 As Label
    Friend WithEvents PN_5 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PN_8 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PN_7 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents DGV_DetailsByEmployee As DataGridView
End Class
