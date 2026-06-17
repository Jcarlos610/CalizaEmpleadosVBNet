<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_INS_Plants
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
        LB_Description = New Label()
        TB_Description = New TextBox()
        BT_Register = New Button()
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
        DGV_PlantsList.Location = New Point(12, 229)
        DGV_PlantsList.Name = "DGV_PlantsList"
        DGV_PlantsList.ReadOnly = True
        DGV_PlantsList.RowHeadersWidth = 62
        DGV_PlantsList.Size = New Size(892, 189)
        DGV_PlantsList.TabIndex = 16
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(TB_PlantName)
        GroupBox1.Controls.Add(LB_PlantName)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(749, 177)
        GroupBox1.TabIndex = 15
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de planta"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(16, 81)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 10
        LB_Description.Text = "Descripción"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(16, 99)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 9
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(668, 146)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 8
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' TB_PlantName
        ' 
        TB_PlantName.Location = New Point(16, 46)
        TB_PlantName.Name = "TB_PlantName"
        TB_PlantName.Size = New Size(445, 23)
        TB_PlantName.TabIndex = 1
        ' 
        ' LB_PlantName
        ' 
        LB_PlantName.AutoSize = True
        LB_PlantName.Location = New Point(16, 29)
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
        LB_Title.Size = New Size(190, 30)
        LB_Title.TabIndex = 110
        LB_Title.Text = "Registro de plantas"
        ' 
        ' MD_INS_Plants
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(800, 450)
        Controls.Add(LB_Title)
        Controls.Add(DGV_PlantsList)
        Controls.Add(GroupBox1)
        Name = "MD_INS_Plants"
        Text = "Registro de plantas"
        WindowState = FormWindowState.Maximized
        CType(DGV_PlantsList, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DGV_PlantsList As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents TB_PlantName As TextBox
    Friend WithEvents LB_PlantName As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents LB_Title As Label
End Class
