<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_INS_HolidayScheme
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
        LB_Title = New Label()
        GroupBox1 = New GroupBox()
        BT_Register = New Button()
        LB_Description = New Label()
        TB_SchemeName = New TextBox()
        LB_SchemeName = New Label()
        TB_Description = New TextBox()
        DGV_HolidaySchema = New DataGridView()
        CB_PaysBonos = New CheckBox()
        GroupBox1.SuspendLayout()
        CType(DGV_HolidaySchema, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(254, 30)
        LB_Title.TabIndex = 106
        LB_Title.Text = "Esquemas de días festivos"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_PaysBonos)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_SchemeName)
        GroupBox1.Controls.Add(LB_SchemeName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(781, 197)
        GroupBox1.TabIndex = 107
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre esquemas"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(700, 168)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 8
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(16, 77)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 6
        LB_Description.Text = "Descripción"
        ' 
        ' TB_SchemeName
        ' 
        TB_SchemeName.Location = New Point(16, 46)
        TB_SchemeName.Name = "TB_SchemeName"
        TB_SchemeName.Size = New Size(222, 23)
        TB_SchemeName.TabIndex = 1
        ' 
        ' LB_SchemeName
        ' 
        LB_SchemeName.AutoSize = True
        LB_SchemeName.Location = New Point(16, 29)
        LB_SchemeName.Name = "LB_SchemeName"
        LB_SchemeName.Size = New Size(121, 15)
        LB_SchemeName.TabIndex = 5
        LB_SchemeName.Text = "Nombre del esquema"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(16, 95)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 2
        ' 
        ' DGV_HolidaySchema
        ' 
        DGV_HolidaySchema.AllowUserToAddRows = False
        DGV_HolidaySchema.AllowUserToDeleteRows = False
        DGV_HolidaySchema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_HolidaySchema.Location = New Point(12, 250)
        DGV_HolidaySchema.Name = "DGV_HolidaySchema"
        DGV_HolidaySchema.ReadOnly = True
        DGV_HolidaySchema.RowHeadersWidth = 62
        DGV_HolidaySchema.Size = New Size(1195, 237)
        DGV_HolidaySchema.TabIndex = 109
        ' 
        ' CB_PaysBonos
        ' 
        CB_PaysBonos.AutoSize = True
        CB_PaysBonos.Location = New Point(428, 97)
        CB_PaysBonos.Name = "CB_PaysBonos"
        CB_PaysBonos.Size = New Size(209, 19)
        CB_PaysBonos.TabIndex = 9
        CB_PaysBonos.Text = "¿Paga bonos (BP y Productividad)?"
        CB_PaysBonos.UseVisualStyleBackColor = True
        ' 
        ' MD_INS_HolidayScheme
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(DGV_HolidaySchema)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Name = "MD_INS_HolidayScheme"
        Text = "Esquemas de días festivos"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_HolidaySchema, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_SchemeName As TextBox
    Friend WithEvents LB_SchemeName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents DGV_HolidaySchema As DataGridView
    Friend WithEvents CB_PaysBonos As CheckBox
End Class
