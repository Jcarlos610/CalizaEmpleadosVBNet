<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_ADMINTIMERECORDS
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
        GB_RegisterData = New GroupBox()
        LB_Validation = New Label()
        DGV_DataValidation = New DataGridView()
        BT_Check = New Button()
        Label1 = New Label()
        CB_Options = New ComboBox()
        DGV_EmployeesInfo = New DataGridView()
        DTP_RegisterDate = New DateTimePicker()
        LB_RegisterDate = New Label()
        BT_Register = New Button()
        GB_LoadedInformation = New GroupBox()
        DGV_Registerinformation = New DataGridView()
        LB_Title = New Label()
        GB_RegisterData.SuspendLayout()
        CType(DGV_DataValidation, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_EmployeesInfo, ComponentModel.ISupportInitialize).BeginInit()
        GB_LoadedInformation.SuspendLayout()
        CType(DGV_Registerinformation, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_RegisterData
        ' 
        GB_RegisterData.Controls.Add(LB_Validation)
        GB_RegisterData.Controls.Add(DGV_DataValidation)
        GB_RegisterData.Controls.Add(BT_Check)
        GB_RegisterData.Controls.Add(Label1)
        GB_RegisterData.Controls.Add(CB_Options)
        GB_RegisterData.Controls.Add(DGV_EmployeesInfo)
        GB_RegisterData.Controls.Add(DTP_RegisterDate)
        GB_RegisterData.Controls.Add(LB_RegisterDate)
        GB_RegisterData.Location = New Point(12, 46)
        GB_RegisterData.Name = "GB_RegisterData"
        GB_RegisterData.Size = New Size(1053, 541)
        GB_RegisterData.TabIndex = 0
        GB_RegisterData.TabStop = False
        GB_RegisterData.Text = "Datos de registro"
        ' 
        ' LB_Validation
        ' 
        LB_Validation.AutoSize = True
        LB_Validation.Location = New Point(19, 345)
        LB_Validation.Name = "LB_Validation"
        LB_Validation.Size = New Size(169, 15)
        LB_Validation.TabIndex = 7
        LB_Validation.Text = "Validación de datos ingresados"
        ' 
        ' DGV_DataValidation
        ' 
        DGV_DataValidation.AllowUserToAddRows = False
        DGV_DataValidation.AllowUserToDeleteRows = False
        DGV_DataValidation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DataValidation.Location = New Point(15, 363)
        DGV_DataValidation.Name = "DGV_DataValidation"
        DGV_DataValidation.ReadOnly = True
        DGV_DataValidation.Size = New Size(1022, 167)
        DGV_DataValidation.TabIndex = 1
        ' 
        ' BT_Check
        ' 
        BT_Check.Location = New Point(962, 22)
        BT_Check.Name = "BT_Check"
        BT_Check.Size = New Size(75, 23)
        BT_Check.TabIndex = 6
        BT_Check.Text = "Validar"
        BT_Check.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 15)
        Label1.TabIndex = 2
        Label1.Text = "Tipo de registro"
        ' 
        ' CB_Options
        ' 
        CB_Options.FormattingEnabled = True
        CB_Options.Location = New Point(111, 20)
        CB_Options.Name = "CB_Options"
        CB_Options.Size = New Size(170, 23)
        CB_Options.TabIndex = 3
        ' 
        ' DGV_EmployeesInfo
        ' 
        DGV_EmployeesInfo.AllowUserToAddRows = False
        DGV_EmployeesInfo.AllowUserToDeleteRows = False
        DGV_EmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_EmployeesInfo.Location = New Point(15, 57)
        DGV_EmployeesInfo.Name = "DGV_EmployeesInfo"
        DGV_EmployeesInfo.Size = New Size(1022, 280)
        DGV_EmployeesInfo.TabIndex = 5
        ' 
        ' DTP_RegisterDate
        ' 
        DTP_RegisterDate.Location = New Point(472, 22)
        DTP_RegisterDate.Name = "DTP_RegisterDate"
        DTP_RegisterDate.Size = New Size(219, 23)
        DTP_RegisterDate.TabIndex = 1
        ' 
        ' LB_RegisterDate
        ' 
        LB_RegisterDate.AutoSize = True
        LB_RegisterDate.Location = New Point(302, 26)
        LB_RegisterDate.Name = "LB_RegisterDate"
        LB_RegisterDate.Size = New Size(164, 15)
        LB_RegisterDate.TabIndex = 0
        LB_RegisterDate.Text = "Seleccione fecha para registro"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(1214, 564)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 4
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' GB_LoadedInformation
        ' 
        GB_LoadedInformation.Controls.Add(DGV_Registerinformation)
        GB_LoadedInformation.Location = New Point(12, 593)
        GB_LoadedInformation.Name = "GB_LoadedInformation"
        GB_LoadedInformation.Size = New Size(1277, 240)
        GB_LoadedInformation.TabIndex = 7
        GB_LoadedInformation.TabStop = False
        GB_LoadedInformation.Text = "Información registrada"
        ' 
        ' DGV_Registerinformation
        ' 
        DGV_Registerinformation.AllowUserToAddRows = False
        DGV_Registerinformation.AllowUserToDeleteRows = False
        DGV_Registerinformation.AllowUserToOrderColumns = True
        DGV_Registerinformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Registerinformation.Location = New Point(17, 22)
        DGV_Registerinformation.Name = "DGV_Registerinformation"
        DGV_Registerinformation.ReadOnly = True
        DGV_Registerinformation.Size = New Size(1244, 204)
        DGV_Registerinformation.TabIndex = 0
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(287, 30)
        LB_Title.TabIndex = 107
        LB_Title.Text = "Registro de entradas y salidas"
        ' 
        ' OP_INS_ADMINTIMERECORDS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1408, 844)
        Controls.Add(LB_Title)
        Controls.Add(GB_LoadedInformation)
        Controls.Add(GB_RegisterData)
        Controls.Add(BT_Register)
        Name = "OP_INS_ADMINTIMERECORDS"
        Tag = "OP_INS_ADMINTIMERECORDS"
        Text = "Registro de entradas y salidas para administrativos"
        WindowState = FormWindowState.Maximized
        GB_RegisterData.ResumeLayout(False)
        GB_RegisterData.PerformLayout()
        CType(DGV_DataValidation, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_EmployeesInfo, ComponentModel.ISupportInitialize).EndInit()
        GB_LoadedInformation.ResumeLayout(False)
        CType(DGV_Registerinformation, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GB_RegisterData As GroupBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents DTP_RegisterDate As DateTimePicker
    Friend WithEvents LB_RegisterDate As Label
    Friend WithEvents DGV_EmployeesInfo As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents CB_Options As ComboBox
    Friend WithEvents DGV_DataValidation As DataGridView
    Friend WithEvents GB_LoadedInformation As GroupBox
    Friend WithEvents DGV_Registerinformation As DataGridView
    Friend WithEvents BT_Check As Button
    Friend WithEvents LB_Validation As Label
    Friend WithEvents LB_Title As Label
End Class
