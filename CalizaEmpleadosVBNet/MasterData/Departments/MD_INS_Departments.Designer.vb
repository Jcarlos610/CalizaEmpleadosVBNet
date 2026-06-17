<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_INS_Departments
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
        BT_Register = New Button()
        LB_AuthorizeBy = New Label()
        LB_Description = New Label()
        TB_DepartmentName = New TextBox()
        LB_DepartmentName = New Label()
        TB_Description = New TextBox()
        TB_AuthorizeBy = New TextBox()
        DGV_DepartmentsList = New DataGridView()
        LB_Title = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_DepartmentsList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_DepartmentName)
        GroupBox1.Controls.Add(LB_DepartmentName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(846, 156)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre departamentos"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(760, 118)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 8
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(17, 79)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(255, 29)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 6
        LB_Description.Text = "Descripción"
        ' 
        ' TB_DepartmentName
        ' 
        TB_DepartmentName.Location = New Point(16, 46)
        TB_DepartmentName.Name = "TB_DepartmentName"
        TB_DepartmentName.Size = New Size(222, 23)
        TB_DepartmentName.TabIndex = 1
        ' 
        ' LB_DepartmentName
        ' 
        LB_DepartmentName.AutoSize = True
        LB_DepartmentName.Location = New Point(17, 30)
        LB_DepartmentName.Name = "LB_DepartmentName"
        LB_DepartmentName.Size = New Size(148, 15)
        LB_DepartmentName.TabIndex = 5
        LB_DepartmentName.Text = "Nombre del departamento"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(254, 46)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 2
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(16, 93)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 3
        ' 
        ' DGV_DepartmentsList
        ' 
        DGV_DepartmentsList.AllowUserToAddRows = False
        DGV_DepartmentsList.AllowUserToDeleteRows = False
        DGV_DepartmentsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DepartmentsList.Location = New Point(12, 208)
        DGV_DepartmentsList.Name = "DGV_DepartmentsList"
        DGV_DepartmentsList.ReadOnly = True
        DGV_DepartmentsList.RowHeadersWidth = 62
        DGV_DepartmentsList.Size = New Size(1218, 214)
        DGV_DepartmentsList.TabIndex = 11
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(263, 30)
        LB_Title.TabIndex = 106
        LB_Title.Text = "Registro de departamentos"
        ' 
        ' MD_INS_Departments
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(LB_Title)
        Controls.Add(DGV_DepartmentsList)
        Controls.Add(GroupBox1)
        Margin = New Padding(2, 2, 2, 2)
        Name = "MD_INS_Departments"
        Text = "Registro de departamentos"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_DepartmentsList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CB_Type As ComboBox
    Friend WithEvents LB_Type As Label
    Friend WithEvents TB_Ammount As TextBox
    Friend WithEvents LB_Ammount As Label
    Friend WithEvents DT_ValidTo As DateTimePicker
    Friend WithEvents LB_ValidTo As Label
    Friend WithEvents DT_ValidFrom As DateTimePicker
    Friend WithEvents LB_ValidFrom As Label
    Friend WithEvents CB_NumberOfDays As ComboBox
    Friend WithEvents LB_AplicationDay As Label
    Friend WithEvents CB_Period As ComboBox
    Friend WithEvents LB_Period As Label
    Friend WithEvents BT_Register As Button
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_DepartmentName As TextBox
    Friend WithEvents LB_DepartmentName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents DGV_DepartmentsList As DataGridView
    Friend WithEvents LB_Title As Label
End Class
