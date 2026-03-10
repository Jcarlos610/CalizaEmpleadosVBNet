<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_TIMERECORDS
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
        GB_WorkTme = New GroupBox()
        BT_LoadFile = New Button()
        TB_SourcePath = New TextBox()
        CB_Options = New ComboBox()
        DGV_FileContent = New DataGridView()
        BT_RegisterInformation = New Button()
        GB_FileContent = New GroupBox()
        TB_Comment = New TextBox()
        LB_Comment = New Label()
        Label1 = New Label()
        GB_WorkTme.SuspendLayout()
        CType(DGV_FileContent, ComponentModel.ISupportInitialize).BeginInit()
        GB_FileContent.SuspendLayout()
        SuspendLayout()
        ' 
        ' GB_WorkTme
        ' 
        GB_WorkTme.Controls.Add(BT_LoadFile)
        GB_WorkTme.Controls.Add(TB_SourcePath)
        GB_WorkTme.Controls.Add(CB_Options)
        GB_WorkTme.Location = New Point(12, 46)
        GB_WorkTme.Name = "GB_WorkTme"
        GB_WorkTme.Size = New Size(646, 107)
        GB_WorkTme.TabIndex = 0
        GB_WorkTme.TabStop = False
        GB_WorkTme.Text = "Datos de reloj checador"
        ' 
        ' BT_LoadFile
        ' 
        BT_LoadFile.Location = New Point(553, 62)
        BT_LoadFile.Name = "BT_LoadFile"
        BT_LoadFile.Size = New Size(75, 23)
        BT_LoadFile.TabIndex = 2
        BT_LoadFile.Text = "Examinar"
        BT_LoadFile.UseVisualStyleBackColor = True
        ' 
        ' TB_SourcePath
        ' 
        TB_SourcePath.Location = New Point(17, 63)
        TB_SourcePath.Name = "TB_SourcePath"
        TB_SourcePath.Size = New Size(530, 23)
        TB_SourcePath.TabIndex = 1
        ' 
        ' CB_Options
        ' 
        CB_Options.FormattingEnabled = True
        CB_Options.Location = New Point(16, 29)
        CB_Options.Name = "CB_Options"
        CB_Options.Size = New Size(198, 23)
        CB_Options.TabIndex = 0
        ' 
        ' DGV_FileContent
        ' 
        DGV_FileContent.AllowUserToAddRows = False
        DGV_FileContent.AllowUserToDeleteRows = False
        DGV_FileContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_FileContent.Location = New Point(16, 27)
        DGV_FileContent.Name = "DGV_FileContent"
        DGV_FileContent.ReadOnly = True
        DGV_FileContent.Size = New Size(998, 439)
        DGV_FileContent.TabIndex = 1
        ' 
        ' BT_RegisterInformation
        ' 
        BT_RegisterInformation.Location = New Point(878, 476)
        BT_RegisterInformation.Name = "BT_RegisterInformation"
        BT_RegisterInformation.Size = New Size(136, 23)
        BT_RegisterInformation.TabIndex = 2
        BT_RegisterInformation.Text = "Registrar información"
        BT_RegisterInformation.UseVisualStyleBackColor = True
        ' 
        ' GB_FileContent
        ' 
        GB_FileContent.Controls.Add(TB_Comment)
        GB_FileContent.Controls.Add(LB_Comment)
        GB_FileContent.Controls.Add(DGV_FileContent)
        GB_FileContent.Controls.Add(BT_RegisterInformation)
        GB_FileContent.Location = New Point(12, 159)
        GB_FileContent.Name = "GB_FileContent"
        GB_FileContent.Size = New Size(1035, 513)
        GB_FileContent.TabIndex = 3
        GB_FileContent.TabStop = False
        GB_FileContent.Text = "Información del archivo"
        ' 
        ' TB_Comment
        ' 
        TB_Comment.BackColor = SystemColors.ButtonHighlight
        TB_Comment.Location = New Point(95, 477)
        TB_Comment.Name = "TB_Comment"
        TB_Comment.Size = New Size(452, 23)
        TB_Comment.TabIndex = 4
        ' 
        ' LB_Comment
        ' 
        LB_Comment.AutoSize = True
        LB_Comment.Location = New Point(16, 480)
        LB_Comment.Name = "LB_Comment"
        LB_Comment.Size = New Size(73, 15)
        LB_Comment.TabIndex = 3
        LB_Comment.Text = "Comentario:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(841, 94)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 4
        Label1.Text = "Label1"
        ' 
        ' OP_INS_TIMERECORDS
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(Label1)
        Controls.Add(GB_FileContent)
        Controls.Add(GB_WorkTme)
        Name = "OP_INS_TIMERECORDS"
        Text = "Registrar horas de entrada y salida"
        WindowState = FormWindowState.Maximized
        GB_WorkTme.ResumeLayout(False)
        GB_WorkTme.PerformLayout()
        CType(DGV_FileContent, ComponentModel.ISupportInitialize).EndInit()
        GB_FileContent.ResumeLayout(False)
        GB_FileContent.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GB_WorkTme As GroupBox
    Friend WithEvents BT_LoadFile As Button
    Friend WithEvents TB_SourcePath As TextBox
    Friend WithEvents CB_Options As ComboBox
    Friend WithEvents DGV_FileContent As DataGridView
    Friend WithEvents BT_RegisterInformation As Button
    Friend WithEvents GB_FileContent As GroupBox
    Friend WithEvents TB_Comment As TextBox
    Friend WithEvents LB_Comment As Label
    Friend WithEvents Label1 As Label
End Class
