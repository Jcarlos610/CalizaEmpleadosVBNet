<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_INS_Holiday
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
        CB_Scheme = New ComboBox()
        LB_Scheme = New Label()
        DTP_Date = New DateTimePicker()
        LB_Date = New Label()
        BT_Register = New Button()
        DGV_Holiday = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_Holiday, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(129, 30)
        LB_Title.TabIndex = 108
        LB_Title.Text = "Días festivos"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Scheme)
        GroupBox1.Controls.Add(LB_Scheme)
        GroupBox1.Controls.Add(DTP_Date)
        GroupBox1.Controls.Add(LB_Date)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(761, 139)
        GroupBox1.TabIndex = 109
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre el festivo"
        ' 
        ' CB_Scheme
        ' 
        CB_Scheme.DropDownStyle = ComboBoxStyle.DropDownList
        CB_Scheme.FormattingEnabled = True
        CB_Scheme.Location = New Point(15, 103)
        CB_Scheme.Name = "CB_Scheme"
        CB_Scheme.Size = New Size(324, 23)
        CB_Scheme.TabIndex = 12
        ' 
        ' LB_Scheme
        ' 
        LB_Scheme.AutoSize = True
        LB_Scheme.Location = New Point(15, 81)
        LB_Scheme.Name = "LB_Scheme"
        LB_Scheme.Size = New Size(58, 15)
        LB_Scheme.TabIndex = 11
        LB_Scheme.Text = "Esquema:"
        ' 
        ' DTP_Date
        ' 
        DTP_Date.Location = New Point(15, 49)
        DTP_Date.Name = "DTP_Date"
        DTP_Date.Size = New Size(222, 23)
        DTP_Date.TabIndex = 10
        ' 
        ' LB_Date
        ' 
        LB_Date.AutoSize = True
        LB_Date.Location = New Point(15, 31)
        LB_Date.Name = "LB_Date"
        LB_Date.Size = New Size(41, 15)
        LB_Date.TabIndex = 9
        LB_Date.Text = "Fecha:"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(680, 103)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 8
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' DGV_Holiday
        ' 
        DGV_Holiday.AllowUserToAddRows = False
        DGV_Holiday.AllowUserToDeleteRows = False
        DGV_Holiday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Holiday.Location = New Point(12, 193)
        DGV_Holiday.Name = "DGV_Holiday"
        DGV_Holiday.ReadOnly = True
        DGV_Holiday.RowHeadersWidth = 62
        DGV_Holiday.Size = New Size(766, 237)
        DGV_Holiday.TabIndex = 110
        ' 
        ' MD_INS_Holiday
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(DGV_Holiday)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Name = "MD_INS_Holiday"
        Text = "Días festivos"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Holiday, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CB_Scheme As ComboBox
    Friend WithEvents LB_Scheme As Label
    Friend WithEvents DTP_Date As DateTimePicker
    Friend WithEvents LB_Date As Label
    Friend WithEvents BT_Register As Button
    Friend WithEvents DGV_Holiday As DataGridView
End Class
