<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_PayrollDispersion
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
        LB_Amount = New Label()
        LB_TotalRegistros = New Label()
        BT_Register = New Button()
        CB_BatchID = New ComboBox()
        DGV_Dispersion = New DataGridView()
        LB_Estado = New Label()
        PB_Progress = New ProgressBar()
        GroupBox1.SuspendLayout()
        CType(DGV_Dispersion, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(215, 30)
        LB_Title.TabIndex = 111
        LB_Title.Text = "Dispersión de nomina"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(LB_Amount)
        GroupBox1.Controls.Add(LB_TotalRegistros)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(CB_BatchID)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 159)
        GroupBox1.TabIndex = 112
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información"
        ' 
        ' LB_Amount
        ' 
        LB_Amount.AutoSize = True
        LB_Amount.Location = New Point(205, 70)
        LB_Amount.Name = "LB_Amount"
        LB_Amount.Size = New Size(105, 15)
        LB_Amount.TabIndex = 28
        LB_Amount.Text = "Monto a transferir:"
        ' 
        ' LB_TotalRegistros
        ' 
        LB_TotalRegistros.AutoSize = True
        LB_TotalRegistros.Location = New Point(16, 70)
        LB_TotalRegistros.Name = "LB_TotalRegistros"
        LB_TotalRegistros.Size = New Size(100, 15)
        LB_TotalRegistros.TabIndex = 27
        LB_TotalRegistros.Text = "Total de registros:"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(1087, 116)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(125, 28)
        BT_Register.TabIndex = 26
        BT_Register.Text = "Generar archivo"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' CB_BatchID
        ' 
        CB_BatchID.DropDownStyle = ComboBoxStyle.DropDownList
        CB_BatchID.FormattingEnabled = True
        CB_BatchID.Location = New Point(16, 22)
        CB_BatchID.Name = "CB_BatchID"
        CB_BatchID.Size = New Size(408, 23)
        CB_BatchID.TabIndex = 25
        ' 
        ' DGV_Dispersion
        ' 
        DGV_Dispersion.AllowUserToAddRows = False
        DGV_Dispersion.AllowUserToDeleteRows = False
        DGV_Dispersion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Dispersion.Location = New Point(12, 245)
        DGV_Dispersion.MultiSelect = False
        DGV_Dispersion.Name = "DGV_Dispersion"
        DGV_Dispersion.ReadOnly = True
        DGV_Dispersion.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGV_Dispersion.Size = New Size(1218, 403)
        DGV_Dispersion.TabIndex = 113
        ' 
        ' LB_Estado
        ' 
        LB_Estado.AutoSize = True
        LB_Estado.ForeColor = SystemColors.Desktop
        LB_Estado.Location = New Point(12, 211)
        LB_Estado.Name = "LB_Estado"
        LB_Estado.Size = New Size(41, 15)
        LB_Estado.TabIndex = 115
        LB_Estado.Text = "Label1"
        LB_Estado.Visible = False
        ' 
        ' PB_Progress
        ' 
        PB_Progress.Location = New Point(160, 211)
        PB_Progress.Name = "PB_Progress"
        PB_Progress.Size = New Size(1070, 10)
        PB_Progress.TabIndex = 114
        PB_Progress.Visible = False
        ' 
        ' OP_PayrollDispersion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(LB_Estado)
        Controls.Add(PB_Progress)
        Controls.Add(DGV_Dispersion)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Name = "OP_PayrollDispersion"
        Text = "Dispersión de nomina"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Dispersion, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents CB_BatchID As ComboBox
    Friend WithEvents LB_Amount As Label
    Friend WithEvents LB_TotalRegistros As Label
    Friend WithEvents DGV_Dispersion As DataGridView
    Friend WithEvents LB_Estado As Label
    Friend WithEvents PB_Progress As ProgressBar
End Class
