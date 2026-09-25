<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_UPD_Holiday
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
        DGV_Holiday = New DataGridView()
        GroupBox1 = New GroupBox()
        CB_Status = New CheckBox()
        CB_Scheme = New ComboBox()
        LB_Scheme = New Label()
        DTP_Date = New DateTimePicker()
        LB_Date = New Label()
        BT_Upd = New Button()
        CType(DGV_Holiday, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(228, 30)
        LB_Title.TabIndex = 109
        LB_Title.Text = "Edición de días festivos"
        ' 
        ' DGV_Holiday
        ' 
        DGV_Holiday.AllowUserToAddRows = False
        DGV_Holiday.AllowUserToDeleteRows = False
        DGV_Holiday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Holiday.Location = New Point(12, 46)
        DGV_Holiday.Name = "DGV_Holiday"
        DGV_Holiday.ReadOnly = True
        DGV_Holiday.RowHeadersWidth = 62
        DGV_Holiday.Size = New Size(766, 237)
        DGV_Holiday.TabIndex = 111
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Controls.Add(CB_Scheme)
        GroupBox1.Controls.Add(LB_Scheme)
        GroupBox1.Controls.Add(DTP_Date)
        GroupBox1.Controls.Add(LB_Date)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Location = New Point(12, 291)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(761, 139)
        GroupBox1.TabIndex = 112
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre el festivo"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(697, 27)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(58, 19)
        CB_Status.TabIndex = 13
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
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
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(680, 103)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 8
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' MD_UPD_Holiday
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_Holiday)
        Controls.Add(LB_Title)
        Name = "MD_UPD_Holiday"
        Text = "Edición de días festivos"
        WindowState = FormWindowState.Maximized
        CType(DGV_Holiday, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents DGV_Holiday As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CB_Status As CheckBox
    Friend WithEvents CB_Scheme As ComboBox
    Friend WithEvents LB_Scheme As Label
    Friend WithEvents DTP_Date As DateTimePicker
    Friend WithEvents LB_Date As Label
    Friend WithEvents BT_Upd As Button
End Class
