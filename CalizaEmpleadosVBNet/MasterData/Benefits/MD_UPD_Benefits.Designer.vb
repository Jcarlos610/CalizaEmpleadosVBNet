<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_UPD_Benefits
    Inherits System.Windows.Forms.Form

    ''Form reemplaza a Dispose para limpiar la lista de componentes.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    ''Requerido por el Diseñador de Windows Forms
    'Private components As System.ComponentModel.IContainer

    ''NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    ''Se puede modificar usando el Diseñador de Windows Forms.  
    ''No lo modifique con el editor de código.
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    DGV_BenefitsList = New DataGridView()
    '    GroupBox1 = New GroupBox()
    '    TB_Ammount = New TextBox()
    '    LB_Ammount = New Label()
    '    CB_Status = New CheckBox()
    '    CB_AllBenefits = New ComboBox()
    '    DT_ValidTo = New DateTimePicker()
    '    LB_ValidTo = New Label()
    '    DT_ValidFrom = New DateTimePicker()
    '    LB_ValidFrom = New Label()
    '    CB_NumberOfDays = New ComboBox()
    '    LB_AplicationDay = New Label()
    '    CB_Period = New ComboBox()
    '    LB_Period = New Label()
    '    BT_Update = New Button()
    '    LB_AuthorizeBy = New Label()
    '    LB_Description = New Label()
    '    TB_BenefitName = New TextBox()
    '    LB_BenefitName = New Label()
    '    TB_Description = New TextBox()
    '    TB_AuthorizeBy = New TextBox()
    '    CType(DGV_BenefitsList, ComponentModel.ISupportInitialize).BeginInit()
    '    GroupBox1.SuspendLayout()
    '    SuspendLayout()
    '    ' 
    '    ' DGV_BenefitsList
    '    ' 
    '    DGV_BenefitsList.AllowUserToAddRows = False
    '    DGV_BenefitsList.AllowUserToDeleteRows = False
    '    DGV_BenefitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    '    DGV_BenefitsList.Location = New Point(17, 537)
    '    DGV_BenefitsList.Margin = New Padding(4, 5, 4, 5)
    '    DGV_BenefitsList.Name = "DGV_BenefitsList"
    '    DGV_BenefitsList.ReadOnly = True
    '    DGV_BenefitsList.RowHeadersWidth = 62
    '    DGV_BenefitsList.Size = New Size(1740, 597)
    '    DGV_BenefitsList.TabIndex = 12
    '    ' 
    '    ' GroupBox1
    '    ' 
    '    GroupBox1.Controls.Add(TB_Ammount)
    '    GroupBox1.Controls.Add(LB_Ammount)
    '    GroupBox1.Controls.Add(CB_Status)
    '    GroupBox1.Controls.Add(CB_AllBenefits)
    '    GroupBox1.Controls.Add(DT_ValidTo)
    '    GroupBox1.Controls.Add(LB_ValidTo)
    '    GroupBox1.Controls.Add(DT_ValidFrom)
    '    GroupBox1.Controls.Add(LB_ValidFrom)
    '    GroupBox1.Controls.Add(CB_NumberOfDays)
    '    GroupBox1.Controls.Add(LB_AplicationDay)
    '    GroupBox1.Controls.Add(CB_Period)
    '    GroupBox1.Controls.Add(LB_Period)
    '    GroupBox1.Controls.Add(BT_Update)
    '    GroupBox1.Controls.Add(LB_AuthorizeBy)
    '    GroupBox1.Controls.Add(LB_Description)
    '    GroupBox1.Controls.Add(TB_BenefitName)
    '    GroupBox1.Controls.Add(LB_BenefitName)
    '    GroupBox1.Controls.Add(TB_Description)
    '    GroupBox1.Controls.Add(TB_AuthorizeBy)
    '    GroupBox1.Location = New Point(17, 73)
    '    GroupBox1.Margin = New Padding(4, 5, 4, 5)
    '    GroupBox1.Name = "GroupBox1"
    '    GroupBox1.Padding = New Padding(4, 5, 4, 5)
    '    GroupBox1.Size = New Size(1280, 435)
    '    GroupBox1.TabIndex = 11
    '    GroupBox1.TabStop = False
    '    GroupBox1.Text = "Información sobre beneficios"
    '    ' 
    '    ' TB_Ammount
    '    ' 
    '    TB_Ammount.BackColor = SystemColors.Info
    '    TB_Ammount.Location = New Point(26, 372)
    '    TB_Ammount.Margin = New Padding(4, 5, 4, 5)
    '    TB_Ammount.Name = "TB_Ammount"
    '    TB_Ammount.Size = New Size(170, 31)
    '    TB_Ammount.TabIndex = 19
    '    ' 
    '    ' LB_Ammount
    '    ' 
    '    LB_Ammount.AutoSize = True
    '    LB_Ammount.Location = New Point(26, 342)
    '    LB_Ammount.Margin = New Padding(4, 0, 4, 0)
    '    LB_Ammount.Name = "LB_Ammount"
    '    LB_Ammount.Size = New Size(137, 25)
    '    LB_Ammount.TabIndex = 18
    '    LB_Ammount.Text = "Monto definido"
    '    ' 
    '    ' CB_Status
    '    ' 
    '    CB_Status.AutoSize = True
    '    CB_Status.Location = New Point(1170, 37)
    '    CB_Status.Margin = New Padding(4, 5, 4, 5)
    '    CB_Status.Name = "CB_Status"
    '    CB_Status.Size = New Size(86, 29)
    '    CB_Status.TabIndex = 17
    '    CB_Status.Text = "Status"
    '    CB_Status.UseVisualStyleBackColor = True
    '    ' 
    '    ' CB_AllBenefits
    '    ' 
    '    CB_AllBenefits.FormattingEnabled = True
    '    CB_AllBenefits.Location = New Point(23, 37)
    '    CB_AllBenefits.Margin = New Padding(4, 5, 4, 5)
    '    CB_AllBenefits.Name = "CB_AllBenefits"
    '    CB_AllBenefits.Size = New Size(315, 33)
    '    CB_AllBenefits.TabIndex = 0
    '    ' 
    '    ' DT_ValidTo
    '    ' 
    '    DT_ValidTo.Location = New Point(811, 293)
    '    DT_ValidTo.Margin = New Padding(4, 5, 4, 5)
    '    DT_ValidTo.Name = "DT_ValidTo"
    '    DT_ValidTo.Size = New Size(324, 31)
    '    DT_ValidTo.TabIndex = 7
    '    ' 
    '    ' LB_ValidTo
    '    ' 
    '    LB_ValidTo.AutoSize = True
    '    LB_ValidTo.Location = New Point(811, 263)
    '    LB_ValidTo.Margin = New Padding(4, 0, 4, 0)
    '    LB_ValidTo.Name = "LB_ValidTo"
    '    LB_ValidTo.Size = New Size(108, 25)
    '    LB_ValidTo.TabIndex = 15
    '    LB_ValidTo.Text = "Valido hasta"
    '    ' 
    '    ' DT_ValidFrom
    '    ' 
    '    DT_ValidFrom.Location = New Point(456, 293)
    '    DT_ValidFrom.Margin = New Padding(4, 5, 4, 5)
    '    DT_ValidFrom.Name = "DT_ValidFrom"
    '    DT_ValidFrom.Size = New Size(330, 31)
    '    DT_ValidFrom.TabIndex = 6
    '    ' 
    '    ' LB_ValidFrom
    '    ' 
    '    LB_ValidFrom.AutoSize = True
    '    LB_ValidFrom.Location = New Point(456, 263)
    '    LB_ValidFrom.Margin = New Padding(4, 0, 4, 0)
    '    LB_ValidFrom.Name = "LB_ValidFrom"
    '    LB_ValidFrom.Size = New Size(114, 25)
    '    LB_ValidFrom.TabIndex = 13
    '    LB_ValidFrom.Text = "Valido desde"
    '    ' 
    '    ' CB_NumberOfDays
    '    ' 
    '    CB_NumberOfDays.FormattingEnabled = True
    '    CB_NumberOfDays.Location = New Point(227, 293)
    '    CB_NumberOfDays.Margin = New Padding(4, 5, 4, 5)
    '    CB_NumberOfDays.Name = "CB_NumberOfDays"
    '    CB_NumberOfDays.Size = New Size(184, 33)
    '    CB_NumberOfDays.TabIndex = 5
    '    ' 
    '    ' LB_AplicationDay
    '    ' 
    '    LB_AplicationDay.AutoSize = True
    '    LB_AplicationDay.Location = New Point(227, 263)
    '    LB_AplicationDay.Margin = New Padding(4, 0, 4, 0)
    '    LB_AplicationDay.Name = "LB_AplicationDay"
    '    LB_AplicationDay.Size = New Size(146, 25)
    '    LB_AplicationDay.TabIndex = 11
    '    LB_AplicationDay.Text = "Día de aplicación"
    '    ' 
    '    ' CB_Period
    '    ' 
    '    CB_Period.FormattingEnabled = True
    '    CB_Period.Location = New Point(24, 293)
    '    CB_Period.Margin = New Padding(4, 5, 4, 5)
    '    CB_Period.Name = "CB_Period"
    '    CB_Period.Size = New Size(171, 33)
    '    CB_Period.TabIndex = 4
    '    ' 
    '    ' LB_Period
    '    ' 
    '    LB_Period.AutoSize = True
    '    LB_Period.Location = New Point(23, 263)
    '    LB_Period.Margin = New Padding(4, 0, 4, 0)
    '    LB_Period.Name = "LB_Period"
    '    LB_Period.Size = New Size(181, 25)
    '    LB_Period.TabIndex = 9
    '    LB_Period.Text = "Periodo de aplicación"
    '    ' 
    '    ' BT_Update
    '    ' 
    '    BT_Update.Location = New Point(1146, 372)
    '    BT_Update.Margin = New Padding(4, 5, 4, 5)
    '    BT_Update.Name = "BT_Update"
    '    BT_Update.Size = New Size(107, 38)
    '    BT_Update.TabIndex = 8
    '    BT_Update.Text = "Actualizar"
    '    BT_Update.UseVisualStyleBackColor = True
    '    ' 
    '    ' LB_AuthorizeBy
    '    ' 
    '    LB_AuthorizeBy.AutoSize = True
    '    LB_AuthorizeBy.Location = New Point(23, 188)
    '    LB_AuthorizeBy.Margin = New Padding(4, 0, 4, 0)
    '    LB_AuthorizeBy.Name = "LB_AuthorizeBy"
    '    LB_AuthorizeBy.Size = New Size(137, 25)
    '    LB_AuthorizeBy.TabIndex = 7
    '    LB_AuthorizeBy.Text = "Autorizado por:"
    '    ' 
    '    ' LB_Description
    '    ' 
    '    LB_Description.AutoSize = True
    '    LB_Description.Location = New Point(363, 105)
    '    LB_Description.Margin = New Padding(4, 0, 4, 0)
    '    LB_Description.Name = "LB_Description"
    '    LB_Description.Size = New Size(104, 25)
    '    LB_Description.TabIndex = 6
    '    LB_Description.Text = "Descripción"
    '    ' 
    '    ' TB_BenefitName
    '    ' 
    '    TB_BenefitName.Location = New Point(23, 135)
    '    TB_BenefitName.Margin = New Padding(4, 5, 4, 5)
    '    TB_BenefitName.Name = "TB_BenefitName"
    '    TB_BenefitName.Size = New Size(315, 31)
    '    TB_BenefitName.TabIndex = 1
    '    ' 
    '    ' LB_BenefitName
    '    ' 
    '    LB_BenefitName.AutoSize = True
    '    LB_BenefitName.Location = New Point(23, 107)
    '    LB_BenefitName.Margin = New Padding(4, 0, 4, 0)
    '    LB_BenefitName.Name = "LB_BenefitName"
    '    LB_BenefitName.Size = New Size(184, 25)
    '    LB_BenefitName.TabIndex = 5
    '    LB_BenefitName.Text = "Nombre del beneficio"
    '    ' 
    '    ' TB_Description
    '    ' 
    '    TB_Description.Location = New Point(363, 135)
    '    TB_Description.Margin = New Padding(4, 5, 4, 5)
    '    TB_Description.Multiline = True
    '    TB_Description.Name = "TB_Description"
    '    TB_Description.Size = New Size(575, 114)
    '    TB_Description.TabIndex = 2
    '    ' 
    '    ' TB_AuthorizeBy
    '    ' 
    '    TB_AuthorizeBy.Location = New Point(23, 213)
    '    TB_AuthorizeBy.Margin = New Padding(4, 5, 4, 5)
    '    TB_AuthorizeBy.Name = "TB_AuthorizeBy"
    '    TB_AuthorizeBy.Size = New Size(315, 31)
    '    TB_AuthorizeBy.TabIndex = 3
    '    ' 
    '    ' MD_UPD_Benefits
    '    ' 
    '    AutoScaleDimensions = New SizeF(10F, 25F)
    '    AutoScaleMode = AutoScaleMode.Font
    '    BackColor = SystemColors.ButtonHighlight
    '    ClientSize = New Size(1774, 1050)
    '    Controls.Add(DGV_BenefitsList)
    '    Controls.Add(GroupBox1)
    '    Margin = New Padding(4, 5, 4, 5)
    '    Name = "MD_UPD_Benefits"
    '    Text = "Actualizar Beneficio"
    '    WindowState = FormWindowState.Maximized
    '    CType(DGV_BenefitsList, ComponentModel.ISupportInitialize).EndInit()
    '    GroupBox1.ResumeLayout(False)
    '    GroupBox1.PerformLayout()
    '    ResumeLayout(False)
    'End Sub

    'Friend WithEvents DGV_BenefitsList As DataGridView
    'Friend WithEvents GroupBox1 As GroupBox
    'Friend WithEvents DT_ValidTo As DateTimePicker
    'Friend WithEvents LB_ValidTo As Label
    'Friend WithEvents DT_ValidFrom As DateTimePicker
    'Friend WithEvents LB_ValidFrom As Label
    'Friend WithEvents CB_NumberOfDays As ComboBox
    'Friend WithEvents LB_AplicationDay As Label
    'Friend WithEvents CB_Period As ComboBox
    'Friend WithEvents LB_Period As Label
    'Friend WithEvents BT_Update As Button
    'Friend WithEvents LB_AuthorizeBy As Label
    'Friend WithEvents LB_Description As Label
    'Friend WithEvents TB_BenefitName As TextBox
    'Friend WithEvents LB_BenefitName As Label
    'Friend WithEvents TB_Description As TextBox
    'Friend WithEvents TB_AuthorizeBy As TextBox
    'Friend WithEvents CB_AllBenefits As ComboBox
    'Friend WithEvents CB_Status As CheckBox
    'Friend WithEvents TB_Ammount As TextBox
    'Friend WithEvents LB_Ammount As Label

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
        DGV_BenefitsList = New DataGridView()
        GroupBox1 = New GroupBox()
        TB_Percent = New TextBox()
        LB_Percent = New Label()
        CB_Type = New ComboBox()
        LB_Type = New Label()
        TB_Ammount = New TextBox()
        LB_Ammount = New Label()
        CB_Status = New CheckBox()
        CB_AllBenefits = New ComboBox()
        DT_ValidTo = New DateTimePicker()
        LB_ValidTo = New Label()
        DT_ValidFrom = New DateTimePicker()
        LB_ValidFrom = New Label()
        BT_Update = New Button()
        LB_AuthorizeBy = New Label()
        LB_Description = New Label()
        TB_BenefitName = New TextBox()
        LB_BenefitName = New Label()
        TB_Description = New TextBox()
        TB_AuthorizeBy = New TextBox()
        CType(DGV_BenefitsList, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DGV_BenefitsList
        ' 
        DGV_BenefitsList.AllowUserToAddRows = False
        DGV_BenefitsList.AllowUserToDeleteRows = False
        DGV_BenefitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_BenefitsList.Location = New Point(17, 537)
        DGV_BenefitsList.Margin = New Padding(4, 5, 4, 5)
        DGV_BenefitsList.Name = "DGV_BenefitsList"
        DGV_BenefitsList.ReadOnly = True
        DGV_BenefitsList.RowHeadersWidth = 62
        DGV_BenefitsList.Size = New Size(1740, 597)
        DGV_BenefitsList.TabIndex = 12
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_Percent)
        GroupBox1.Controls.Add(LB_Percent)
        GroupBox1.Controls.Add(CB_Type)
        GroupBox1.Controls.Add(LB_Type)
        GroupBox1.Controls.Add(TB_Ammount)
        GroupBox1.Controls.Add(LB_Ammount)
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Controls.Add(CB_AllBenefits)
        GroupBox1.Controls.Add(DT_ValidTo)
        GroupBox1.Controls.Add(LB_ValidTo)
        GroupBox1.Controls.Add(DT_ValidFrom)
        GroupBox1.Controls.Add(LB_ValidFrom)
        GroupBox1.Controls.Add(BT_Update)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_BenefitName)
        GroupBox1.Controls.Add(LB_BenefitName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Location = New Point(17, 73)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1280, 435)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre beneficios"
        ' 
        ' TB_Percent
        ' 
        TB_Percent.BackColor = SystemColors.Info
        TB_Percent.Location = New Point(214, 372)
        TB_Percent.Margin = New Padding(4, 5, 4, 5)
        TB_Percent.Name = "TB_Percent"
        TB_Percent.Size = New Size(170, 31)
        TB_Percent.TabIndex = 23
        ' 
        ' LB_Percent
        ' 
        LB_Percent.AutoSize = True
        LB_Percent.Location = New Point(214, 342)
        LB_Percent.Margin = New Padding(4, 0, 4, 0)
        LB_Percent.Name = "LB_Percent"
        LB_Percent.Size = New Size(164, 25)
        LB_Percent.TabIndex = 22
        LB_Percent.Text = "Porcentaje definido"
        ' 
        ' CB_Type
        ' 
        CB_Type.FormattingEnabled = True
        CB_Type.Location = New Point(981, 133)
        CB_Type.Margin = New Padding(4, 5, 4, 5)
        CB_Type.Name = "CB_Type"
        CB_Type.Size = New Size(171, 33)
        CB_Type.TabIndex = 21
        ' 
        ' LB_Type
        ' 
        LB_Type.AutoSize = True
        LB_Type.Location = New Point(981, 105)
        LB_Type.Margin = New Padding(4, 0, 4, 0)
        LB_Type.Name = "LB_Type"
        LB_Type.Size = New Size(149, 25)
        LB_Type.TabIndex = 20
        LB_Type.Text = "Tipo de beneficio"
        ' 
        ' TB_Ammount
        ' 
        TB_Ammount.BackColor = SystemColors.Info
        TB_Ammount.Location = New Point(26, 372)
        TB_Ammount.Margin = New Padding(4, 5, 4, 5)
        TB_Ammount.Name = "TB_Ammount"
        TB_Ammount.Size = New Size(170, 31)
        TB_Ammount.TabIndex = 19
        ' 
        ' LB_Ammount
        ' 
        LB_Ammount.AutoSize = True
        LB_Ammount.Location = New Point(26, 342)
        LB_Ammount.Margin = New Padding(4, 0, 4, 0)
        LB_Ammount.Name = "LB_Ammount"
        LB_Ammount.Size = New Size(137, 25)
        LB_Ammount.TabIndex = 18
        LB_Ammount.Text = "Monto definido"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(1170, 37)
        CB_Status.Margin = New Padding(4, 5, 4, 5)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(86, 29)
        CB_Status.TabIndex = 17
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' CB_AllBenefits
        ' 
        CB_AllBenefits.FormattingEnabled = True
        CB_AllBenefits.Location = New Point(23, 37)
        CB_AllBenefits.Margin = New Padding(4, 5, 4, 5)
        CB_AllBenefits.Name = "CB_AllBenefits"
        CB_AllBenefits.Size = New Size(444, 33)
        CB_AllBenefits.TabIndex = 0
        ' 
        ' DT_ValidTo
        ' 
        DT_ValidTo.Location = New Point(401, 293)
        DT_ValidTo.Margin = New Padding(4, 5, 4, 5)
        DT_ValidTo.Name = "DT_ValidTo"
        DT_ValidTo.Size = New Size(324, 31)
        DT_ValidTo.TabIndex = 7
        ' 
        ' LB_ValidTo
        ' 
        LB_ValidTo.AutoSize = True
        LB_ValidTo.Location = New Point(401, 263)
        LB_ValidTo.Margin = New Padding(4, 0, 4, 0)
        LB_ValidTo.Name = "LB_ValidTo"
        LB_ValidTo.Size = New Size(108, 25)
        LB_ValidTo.TabIndex = 15
        LB_ValidTo.Text = "Valido hasta"
        ' 
        ' DT_ValidFrom
        ' 
        DT_ValidFrom.Location = New Point(23, 293)
        DT_ValidFrom.Margin = New Padding(4, 5, 4, 5)
        DT_ValidFrom.Name = "DT_ValidFrom"
        DT_ValidFrom.Size = New Size(330, 31)
        DT_ValidFrom.TabIndex = 6
        ' 
        ' LB_ValidFrom
        ' 
        LB_ValidFrom.AutoSize = True
        LB_ValidFrom.Location = New Point(23, 263)
        LB_ValidFrom.Margin = New Padding(4, 0, 4, 0)
        LB_ValidFrom.Name = "LB_ValidFrom"
        LB_ValidFrom.Size = New Size(114, 25)
        LB_ValidFrom.TabIndex = 13
        LB_ValidFrom.Text = "Valido desde"
        ' 
        ' BT_Update
        ' 
        BT_Update.Location = New Point(1146, 372)
        BT_Update.Margin = New Padding(4, 5, 4, 5)
        BT_Update.Name = "BT_Update"
        BT_Update.Size = New Size(107, 38)
        BT_Update.TabIndex = 8
        BT_Update.Text = "Actualizar"
        BT_Update.UseVisualStyleBackColor = True
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(23, 188)
        LB_AuthorizeBy.Margin = New Padding(4, 0, 4, 0)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(137, 25)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(363, 105)
        LB_Description.Margin = New Padding(4, 0, 4, 0)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(104, 25)
        LB_Description.TabIndex = 6
        LB_Description.Text = "Descripción"
        ' 
        ' TB_BenefitName
        ' 
        TB_BenefitName.Location = New Point(23, 135)
        TB_BenefitName.Margin = New Padding(4, 5, 4, 5)
        TB_BenefitName.Name = "TB_BenefitName"
        TB_BenefitName.Size = New Size(315, 31)
        TB_BenefitName.TabIndex = 1
        ' 
        ' LB_BenefitName
        ' 
        LB_BenefitName.AutoSize = True
        LB_BenefitName.Location = New Point(23, 107)
        LB_BenefitName.Margin = New Padding(4, 0, 4, 0)
        LB_BenefitName.Name = "LB_BenefitName"
        LB_BenefitName.Size = New Size(184, 25)
        LB_BenefitName.TabIndex = 5
        LB_BenefitName.Text = "Nombre del beneficio"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(363, 135)
        TB_Description.Margin = New Padding(4, 5, 4, 5)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(575, 114)
        TB_Description.TabIndex = 2
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(23, 213)
        TB_AuthorizeBy.Margin = New Padding(4, 5, 4, 5)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(315, 31)
        TB_AuthorizeBy.TabIndex = 3
        ' 
        ' MD_UPD_Benefits
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1774, 1050)
        Controls.Add(DGV_BenefitsList)
        Controls.Add(GroupBox1)
        Margin = New Padding(4, 5, 4, 5)
        Name = "MD_UPD_Benefits"
        Text = "Actualizar Beneficio"
        WindowState = FormWindowState.Maximized
        CType(DGV_BenefitsList, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DGV_BenefitsList As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DT_ValidTo As DateTimePicker
    Friend WithEvents LB_ValidTo As Label
    Friend WithEvents DT_ValidFrom As DateTimePicker
    Friend WithEvents LB_ValidFrom As Label
    Friend WithEvents BT_Update As Button
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_BenefitName As TextBox
    Friend WithEvents LB_BenefitName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents CB_AllBenefits As ComboBox
    Friend WithEvents CB_Status As CheckBox
    Friend WithEvents TB_Ammount As TextBox
    Friend WithEvents LB_Ammount As Label
    Friend WithEvents LB_Type As Label
    Friend WithEvents CB_Type As ComboBox
    Friend WithEvents LB_Percent As Label
    Friend WithEvents TB_Percent As TextBox
End Class
