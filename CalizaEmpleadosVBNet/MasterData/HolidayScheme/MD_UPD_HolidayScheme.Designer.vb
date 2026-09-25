<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_UPD_HolidayScheme
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
        DGV_HolidaySchema = New DataGridView()
        GroupBox1 = New GroupBox()
        CB_PaysBonos = New CheckBox()
        BT_Upd = New Button()
        LB_Description = New Label()
        TB_SchemeName = New TextBox()
        LB_SchemeName = New Label()
        TB_Description = New TextBox()
        CType(DGV_HolidaySchema, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(356, 30)
        LB_Title.TabIndex = 107
        LB_Title.Text = "Edición de esquemas de días festivos"
        ' 
        ' DGV_HolidaySchema
        ' 
        DGV_HolidaySchema.AllowUserToAddRows = False
        DGV_HolidaySchema.AllowUserToDeleteRows = False
        DGV_HolidaySchema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_HolidaySchema.Location = New Point(12, 46)
        DGV_HolidaySchema.Name = "DGV_HolidaySchema"
        DGV_HolidaySchema.ReadOnly = True
        DGV_HolidaySchema.RowHeadersWidth = 62
        DGV_HolidaySchema.Size = New Size(1167, 237)
        DGV_HolidaySchema.TabIndex = 108
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_PaysBonos)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_SchemeName)
        GroupBox1.Controls.Add(LB_SchemeName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Location = New Point(12, 294)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(781, 197)
        GroupBox1.TabIndex = 109
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre esquemas"
        ' 
        ' CB_PaysBonos
        ' 
        CB_PaysBonos.AutoSize = True
        CB_PaysBonos.Location = New Point(428, 95)
        CB_PaysBonos.Name = "CB_PaysBonos"
        CB_PaysBonos.Size = New Size(209, 19)
        CB_PaysBonos.TabIndex = 10
        CB_PaysBonos.Text = "¿Paga bonos (BP y Productividad)?"
        CB_PaysBonos.UseVisualStyleBackColor = True
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(700, 168)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 8
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
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
        ' MD_UPD_HolidayScheme
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_HolidaySchema)
        Controls.Add(LB_Title)
        Name = "MD_UPD_HolidayScheme"
        Text = "Edición de esquemas de días festivos"
        WindowState = FormWindowState.Maximized
        CType(DGV_HolidaySchema, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents DGV_HolidaySchema As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_SchemeName As TextBox
    Friend WithEvents LB_SchemeName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents CB_PaysBonos As CheckBox
End Class
