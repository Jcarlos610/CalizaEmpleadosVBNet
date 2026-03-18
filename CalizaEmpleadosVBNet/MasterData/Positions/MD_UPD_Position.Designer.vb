<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MD_UPD_Position
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        GB_PositionData = New GroupBox()
        CB_Status = New CheckBox()
        CB_AllPositions = New ComboBox()
        LB_AuthorizeBy = New Label()
        TB_AuthorizeBy = New TextBox()
        TB_Update = New Button()
        TB_Salary = New TextBox()
        LB_Salaray = New Label()
        LB_Description = New Label()
        TB_Description = New TextBox()
        TB_PositionName = New TextBox()
        LB_PositionName = New Label()
        DGV_PositionsList = New DataGridView()
        GB_PositionData.SuspendLayout()
        CType(DGV_PositionsList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_PositionData
        ' 
        GB_PositionData.Controls.Add(CB_Status)
        GB_PositionData.Controls.Add(CB_AllPositions)
        GB_PositionData.Controls.Add(LB_AuthorizeBy)
        GB_PositionData.Controls.Add(TB_AuthorizeBy)
        GB_PositionData.Controls.Add(TB_Update)
        GB_PositionData.Controls.Add(TB_Salary)
        GB_PositionData.Controls.Add(LB_Salaray)
        GB_PositionData.Controls.Add(LB_Description)
        GB_PositionData.Controls.Add(TB_Description)
        GB_PositionData.Controls.Add(TB_PositionName)
        GB_PositionData.Controls.Add(LB_PositionName)
        GB_PositionData.Location = New Point(17, 77)
        GB_PositionData.Margin = New Padding(4, 5, 4, 5)
        GB_PositionData.Name = "GB_PositionData"
        GB_PositionData.Padding = New Padding(4, 5, 4, 5)
        GB_PositionData.Size = New Size(1111, 327)
        GB_PositionData.TabIndex = 1
        GB_PositionData.TabStop = False
        GB_PositionData.Text = "Datos de la posición"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(946, 43)
        CB_Status.Margin = New Padding(4, 5, 4, 5)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(86, 29)
        CB_Status.TabIndex = 15
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' CB_AllPositions
        ' 
        CB_AllPositions.FormattingEnabled = True
        CB_AllPositions.Location = New Point(23, 37)
        CB_AllPositions.Margin = New Padding(4, 5, 4, 5)
        CB_AllPositions.Name = "CB_AllPositions"
        CB_AllPositions.Size = New Size(315, 33)
        CB_AllPositions.TabIndex = 14
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(23, 177)
        LB_AuthorizeBy.Margin = New Padding(4, 0, 4, 0)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(137, 25)
        LB_AuthorizeBy.TabIndex = 13
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(23, 208)
        TB_AuthorizeBy.Margin = New Padding(4, 5, 4, 5)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(315, 31)
        TB_AuthorizeBy.TabIndex = 12
        ' 
        ' TB_Update
        ' 
        TB_Update.Location = New Point(946, 277)
        TB_Update.Margin = New Padding(4, 5, 4, 5)
        TB_Update.Name = "TB_Update"
        TB_Update.Size = New Size(107, 38)
        TB_Update.TabIndex = 11
        TB_Update.Text = "Actualizar"
        TB_Update.UseVisualStyleBackColor = True
        ' 
        ' TB_Salary
        ' 
        TB_Salary.BackColor = SystemColors.Info
        TB_Salary.Location = New Point(23, 280)
        TB_Salary.Margin = New Padding(4, 5, 4, 5)
        TB_Salary.Name = "TB_Salary"
        TB_Salary.Size = New Size(190, 31)
        TB_Salary.TabIndex = 10
        ' 
        ' LB_Salaray
        ' 
        LB_Salaray.AutoSize = True
        LB_Salaray.Location = New Point(23, 250)
        LB_Salaray.Margin = New Padding(4, 0, 4, 0)
        LB_Salaray.Name = "LB_Salaray"
        LB_Salaray.Size = New Size(141, 25)
        LB_Salaray.TabIndex = 9
        LB_Salaray.Text = "Salario tabulado"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(359, 107)
        LB_Description.Margin = New Padding(4, 0, 4, 0)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(104, 25)
        LB_Description.TabIndex = 8
        LB_Description.Text = "Descripción"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(359, 137)
        TB_Description.Margin = New Padding(4, 5, 4, 5)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(575, 114)
        TB_Description.TabIndex = 7
        ' 
        ' TB_PositionName
        ' 
        TB_PositionName.Location = New Point(23, 137)
        TB_PositionName.Margin = New Padding(4, 5, 4, 5)
        TB_PositionName.Name = "TB_PositionName"
        TB_PositionName.Size = New Size(315, 31)
        TB_PositionName.TabIndex = 1
        ' 
        ' LB_PositionName
        ' 
        LB_PositionName.AutoSize = True
        LB_PositionName.Location = New Point(23, 107)
        LB_PositionName.Margin = New Padding(4, 0, 4, 0)
        LB_PositionName.Name = "LB_PositionName"
        LB_PositionName.Size = New Size(163, 25)
        LB_PositionName.TabIndex = 0
        LB_PositionName.Text = "Nombre de puesto"
        ' 
        ' DGV_PositionsList
        ' 
        DGV_PositionsList.AllowUserToAddRows = False
        DGV_PositionsList.AllowUserToDeleteRows = False
        DGV_PositionsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_PositionsList.Location = New Point(17, 423)
        DGV_PositionsList.Margin = New Padding(4, 5, 4, 5)
        DGV_PositionsList.Name = "DGV_PositionsList"
        DGV_PositionsList.ReadOnly = True
        DGV_PositionsList.RowHeadersWidth = 62
        DGV_PositionsList.Size = New Size(1740, 409)
        DGV_PositionsList.TabIndex = 12
        ' 
        ' MD_UPD_Position
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1774, 1050)
        Controls.Add(DGV_PositionsList)
        Controls.Add(GB_PositionData)
        Name = "MD_UPD_Position"
        Text = "Actualizar Posiciones"
        WindowState = FormWindowState.Maximized
        GB_PositionData.ResumeLayout(False)
        GB_PositionData.PerformLayout()
        CType(DGV_PositionsList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GB_PositionData As GroupBox
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents TB_Update As Button
    Friend WithEvents TB_Salary As TextBox
    Friend WithEvents LB_Salaray As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_PositionName As TextBox
    Friend WithEvents LB_PositionName As Label
    Friend WithEvents DGV_PositionsList As DataGridView
    Friend WithEvents CB_AllPositions As ComboBox
    Friend WithEvents CB_Status As CheckBox
End Class