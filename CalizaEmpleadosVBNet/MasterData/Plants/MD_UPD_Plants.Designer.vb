<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_UPD_Plants
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
        DGV_PlantsList = New DataGridView()
        GroupBox1 = New GroupBox()
        CB_Status = New CheckBox()
        CB_Plants = New ComboBox()
        LB_Description = New Label()
        TB_Description = New TextBox()
        BT_Upd = New Button()
        TB_PlantName = New TextBox()
        LB_PlantName = New Label()
        LB_Title = New Label()
        CType(DGV_PlantsList, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DGV_PlantsList
        ' 
        DGV_PlantsList.AllowUserToAddRows = False
        DGV_PlantsList.AllowUserToDeleteRows = False
        DGV_PlantsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_PlantsList.Location = New Point(12, 273)
        DGV_PlantsList.Name = "DGV_PlantsList"
        DGV_PlantsList.ReadOnly = True
        DGV_PlantsList.RowHeadersWidth = 62
        DGV_PlantsList.Size = New Size(892, 201)
        DGV_PlantsList.TabIndex = 18
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Controls.Add(CB_Plants)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(TB_PlantName)
        GroupBox1.Controls.Add(LB_PlantName)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(749, 221)
        GroupBox1.TabIndex = 17
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de planta"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(650, 31)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(58, 19)
        CB_Status.TabIndex = 18
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' CB_Plants
        ' 
        CB_Plants.FormattingEnabled = True
        CB_Plants.Location = New Point(6, 31)
        CB_Plants.Name = "CB_Plants"
        CB_Plants.Size = New Size(149, 23)
        CB_Plants.TabIndex = 11
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(6, 117)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 10
        LB_Description.Text = "Descripción"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(6, 135)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 9
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(650, 182)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 8
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' TB_PlantName
        ' 
        TB_PlantName.Location = New Point(6, 82)
        TB_PlantName.Name = "TB_PlantName"
        TB_PlantName.Size = New Size(445, 23)
        TB_PlantName.TabIndex = 1
        ' 
        ' LB_PlantName
        ' 
        LB_PlantName.AutoSize = True
        LB_PlantName.Location = New Point(6, 65)
        LB_PlantName.Name = "LB_PlantName"
        LB_PlantName.Size = New Size(103, 15)
        LB_PlantName.TabIndex = 5
        LB_PlantName.Text = "Nombre de planta"
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(182, 30)
        LB_Title.TabIndex = 111
        LB_Title.Text = "Edición de plantas"
        ' 
        ' MD_UPD_Plants
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(858, 486)
        Controls.Add(LB_Title)
        Controls.Add(DGV_PlantsList)
        Controls.Add(GroupBox1)
        Name = "MD_UPD_Plants"
        Text = "Edición de plantas"
        WindowState = FormWindowState.Maximized
        CType(DGV_PlantsList, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DGV_PlantsList As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents BT_Upd As Button
    Friend WithEvents TB_PlantName As TextBox
    Friend WithEvents LB_PlantName As Label
    Friend WithEvents CB_Plants As ComboBox
    Friend WithEvents CB_Status As CheckBox
    Friend WithEvents LB_Title As Label
End Class
