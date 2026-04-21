<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_APPROVE_VACATIONS
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
        GB_EmployeeVacations = New GroupBox()
        DGV_Vacations = New DataGridView()
        GB_EmployeeVacations.SuspendLayout()
        CType(DGV_Vacations, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GB_EmployeeVacations
        ' 
        GB_EmployeeVacations.Controls.Add(DGV_Vacations)
        GB_EmployeeVacations.Location = New Point(17, 77)
        GB_EmployeeVacations.Margin = New Padding(4, 5, 4, 5)
        GB_EmployeeVacations.Name = "GB_EmployeeVacations"
        GB_EmployeeVacations.Padding = New Padding(4, 5, 4, 5)
        GB_EmployeeVacations.Size = New Size(1944, 943)
        GB_EmployeeVacations.TabIndex = 2
        GB_EmployeeVacations.TabStop = False
        GB_EmployeeVacations.Text = "Aprobación de vacaciones"
        ' 
        ' DGV_Vacations
        ' 
        DGV_Vacations.AllowUserToAddRows = False
        DGV_Vacations.AllowUserToDeleteRows = False
        DGV_Vacations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV_Vacations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Vacations.Location = New Point(17, 87)
        DGV_Vacations.Margin = New Padding(4, 5, 4, 5)
        DGV_Vacations.Name = "DGV_Vacations"
        DGV_Vacations.ReadOnly = True
        DGV_Vacations.RowHeadersWidth = 62
        DGV_Vacations.Size = New Size(1899, 796)
        DGV_Vacations.TabIndex = 1
        ' 
        ' OP_APPROVE_VACATIONS
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1924, 1050)
        Controls.Add(GB_EmployeeVacations)
        Name = "OP_APPROVE_VACATIONS"
        Text = "Aprobar vacaciones"
        WindowState = FormWindowState.Maximized
        GB_EmployeeVacations.ResumeLayout(False)
        CType(DGV_Vacations, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GB_EmployeeVacations As GroupBox
    Friend WithEvents DGV_Vacations As DataGridView
End Class
