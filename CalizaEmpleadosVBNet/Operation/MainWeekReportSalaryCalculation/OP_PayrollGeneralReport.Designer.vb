<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_PayrollGeneralReport
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
        CB_Week = New ComboBox()
        GroupBox1 = New GroupBox()
        BT_ExportExcel = New Button()
        DGV_ReportGeneral = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_ReportGeneral, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(282, 30)
        LB_Title.TabIndex = 111
        LB_Title.Text = "Reporte de nomina genearal "
        ' 
        ' CB_Week
        ' 
        CB_Week.DropDownStyle = ComboBoxStyle.DropDownList
        CB_Week.FormattingEnabled = True
        CB_Week.Location = New Point(15, 39)
        CB_Week.Name = "CB_Week"
        CB_Week.Size = New Size(304, 23)
        CB_Week.TabIndex = 112
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BT_ExportExcel)
        GroupBox1.Controls.Add(CB_Week)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(444, 126)
        GroupBox1.TabIndex = 113
        GroupBox1.TabStop = False
        GroupBox1.Text = "Semanas"
        ' 
        ' BT_ExportExcel
        ' 
        BT_ExportExcel.Location = New Point(359, 93)
        BT_ExportExcel.Name = "BT_ExportExcel"
        BT_ExportExcel.Size = New Size(75, 23)
        BT_ExportExcel.TabIndex = 113
        BT_ExportExcel.Text = "Exportar"
        BT_ExportExcel.UseVisualStyleBackColor = True
        ' 
        ' DGV_ReportGeneral
        ' 
        DGV_ReportGeneral.AllowUserToAddRows = False
        DGV_ReportGeneral.AllowUserToDeleteRows = False
        DGV_ReportGeneral.AllowUserToOrderColumns = True
        DGV_ReportGeneral.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_ReportGeneral.Location = New Point(12, 179)
        DGV_ReportGeneral.Name = "DGV_ReportGeneral"
        DGV_ReportGeneral.ReadOnly = True
        DGV_ReportGeneral.RowHeadersWidth = 62
        DGV_ReportGeneral.Size = New Size(1218, 482)
        DGV_ReportGeneral.TabIndex = 114
        ' 
        ' OP_PayrollGeneralReport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(DGV_ReportGeneral)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Name = "OP_PayrollGeneralReport"
        Text = "Reporte de nomina general "
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        CType(DGV_ReportGeneral, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents CB_Week As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_ExportExcel As Button
    Friend WithEvents DGV_ReportGeneral As DataGridView
End Class
