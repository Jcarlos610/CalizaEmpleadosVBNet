<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_MANUALLUNCHHOURS
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
        GB_EmployeesList = New GroupBox()
        CB_Dates = New ComboBox()
        BT_Update = New Button()
        LB_SetDate = New Label()
        DGV_ActiveEmployeesInfo = New DataGridView()
        GB_EmployeesList.SuspendLayout()
        CType(DGV_ActiveEmployeesInfo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_EmployeesList
        ' 
        GB_EmployeesList.Controls.Add(CB_Dates)
        GB_EmployeesList.Controls.Add(BT_Update)
        GB_EmployeesList.Controls.Add(LB_SetDate)
        GB_EmployeesList.Controls.Add(DGV_ActiveEmployeesInfo)
        GB_EmployeesList.Location = New Point(17, 77)
        GB_EmployeesList.Margin = New Padding(4, 5, 4, 5)
        GB_EmployeesList.Name = "GB_EmployeesList"
        GB_EmployeesList.Padding = New Padding(4, 5, 4, 5)
        GB_EmployeesList.Size = New Size(1606, 953)
        GB_EmployeesList.TabIndex = 1
        GB_EmployeesList.TabStop = False
        GB_EmployeesList.Text = "Lista de empleados activos"
        ' 
        ' CB_Dates
        ' 
        CB_Dates.FormattingEnabled = True
        CB_Dates.Location = New Point(30, 78)
        CB_Dates.Name = "CB_Dates"
        CB_Dates.Size = New Size(276, 33)
        CB_Dates.TabIndex = 7
        ' 
        ' BT_Update
        ' 
        BT_Update.Location = New Point(1374, 78)
        BT_Update.Margin = New Padding(4, 5, 4, 5)
        BT_Update.Name = "BT_Update"
        BT_Update.Size = New Size(183, 53)
        BT_Update.TabIndex = 6
        BT_Update.Text = "Actualizar"
        BT_Update.UseVisualStyleBackColor = True
        ' 
        ' LB_SetDate
        ' 
        LB_SetDate.AutoSize = True
        LB_SetDate.Location = New Point(31, 50)
        LB_SetDate.Margin = New Padding(4, 0, 4, 0)
        LB_SetDate.Name = "LB_SetDate"
        LB_SetDate.Size = New Size(246, 25)
        LB_SetDate.TabIndex = 3
        LB_SetDate.Text = "Seleccione la fecha de edición"
        ' 
        ' DGV_ActiveEmployeesInfo
        ' 
        DGV_ActiveEmployeesInfo.AllowUserToAddRows = False
        DGV_ActiveEmployeesInfo.AllowUserToDeleteRows = False
        DGV_ActiveEmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_ActiveEmployeesInfo.Location = New Point(30, 142)
        DGV_ActiveEmployeesInfo.Margin = New Padding(4, 5, 4, 5)
        DGV_ActiveEmployeesInfo.Name = "DGV_ActiveEmployeesInfo"
        DGV_ActiveEmployeesInfo.RowHeadersWidth = 62
        DGV_ActiveEmployeesInfo.Size = New Size(1527, 785)
        DGV_ActiveEmployeesInfo.TabIndex = 2
        ' 
        ' OP_UPD_MANUALLUNCHHOURS
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1774, 1050)
        Controls.Add(GB_EmployeesList)
        Name = "OP_UPD_MANUALLUNCHHOURS"
        Text = "Edición de horas de comida"
        WindowState = FormWindowState.Maximized
        GB_EmployeesList.ResumeLayout(False)
        GB_EmployeesList.PerformLayout()
        CType(DGV_ActiveEmployeesInfo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GB_EmployeesList As GroupBox
    Friend WithEvents BT_Update As Button
    Friend WithEvents LB_SetDate As Label
    Friend WithEvents DGV_ActiveEmployeesInfo As DataGridView
    Friend WithEvents CB_Dates As ComboBox
End Class
