<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ST_INS_Companies
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
        TB_CompanyName = New TextBox()
        TB_OfficialName = New TextBox()
        TB_TaxCode = New TextBox()
        LB_ConpanyName = New Label()
        LB_OfficialName = New Label()
        LB_TaxCode = New Label()
        GroupBox1 = New GroupBox()
        BT_Register = New Button()
        DGV_CompaniesList = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_CompaniesList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TB_CompanyName
        ' 
        TB_CompanyName.Location = New Point(23, 77)
        TB_CompanyName.Margin = New Padding(4, 5, 4, 5)
        TB_CompanyName.Name = "TB_CompanyName"
        TB_CompanyName.Size = New Size(634, 31)
        TB_CompanyName.TabIndex = 1
        ' 
        ' TB_OfficialName
        ' 
        TB_OfficialName.Location = New Point(23, 153)
        TB_OfficialName.Margin = New Padding(4, 5, 4, 5)
        TB_OfficialName.Name = "TB_OfficialName"
        TB_OfficialName.Size = New Size(634, 31)
        TB_OfficialName.TabIndex = 2
        ' 
        ' TB_TaxCode
        ' 
        TB_TaxCode.Location = New Point(720, 153)
        TB_TaxCode.Margin = New Padding(4, 5, 4, 5)
        TB_TaxCode.Name = "TB_TaxCode"
        TB_TaxCode.Size = New Size(141, 31)
        TB_TaxCode.TabIndex = 3
        ' 
        ' LB_ConpanyName
        ' 
        LB_ConpanyName.AutoSize = True
        LB_ConpanyName.Location = New Point(23, 48)
        LB_ConpanyName.Margin = New Padding(4, 0, 4, 0)
        LB_ConpanyName.Name = "LB_ConpanyName"
        LB_ConpanyName.Size = New Size(176, 25)
        LB_ConpanyName.TabIndex = 5
        LB_ConpanyName.Text = "Nombre de empresa"
        ' 
        ' LB_OfficialName
        ' 
        LB_OfficialName.AutoSize = True
        LB_OfficialName.Location = New Point(23, 123)
        LB_OfficialName.Margin = New Padding(4, 0, 4, 0)
        LB_OfficialName.Name = "LB_OfficialName"
        LB_OfficialName.Size = New Size(112, 25)
        LB_OfficialName.TabIndex = 6
        LB_OfficialName.Text = "Razón Social"
        ' 
        ' LB_TaxCode
        ' 
        LB_TaxCode.AutoSize = True
        LB_TaxCode.Location = New Point(720, 128)
        LB_TaxCode.Margin = New Padding(4, 0, 4, 0)
        LB_TaxCode.Name = "LB_TaxCode"
        LB_TaxCode.Size = New Size(43, 25)
        LB_TaxCode.TabIndex = 7
        LB_TaxCode.Text = "RFC"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(LB_TaxCode)
        GroupBox1.Controls.Add(LB_OfficialName)
        GroupBox1.Controls.Add(TB_CompanyName)
        GroupBox1.Controls.Add(LB_ConpanyName)
        GroupBox1.Controls.Add(TB_OfficialName)
        GroupBox1.Controls.Add(TB_TaxCode)
        GroupBox1.Location = New Point(17, 77)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1070, 225)
        GroupBox1.TabIndex = 8
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de empresa"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(934, 153)
        BT_Register.Margin = New Padding(4, 5, 4, 5)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(107, 38)
        BT_Register.TabIndex = 8
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' DGV_CompaniesList
        ' 
        DGV_CompaniesList.AllowUserToAddRows = False
        DGV_CompaniesList.AllowUserToDeleteRows = False
        DGV_CompaniesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_CompaniesList.Location = New Point(17, 317)
        DGV_CompaniesList.Margin = New Padding(4, 5, 4, 5)
        DGV_CompaniesList.Name = "DGV_CompaniesList"
        DGV_CompaniesList.ReadOnly = True
        DGV_CompaniesList.RowHeadersWidth = 62
        DGV_CompaniesList.Size = New Size(1275, 380)
        DGV_CompaniesList.TabIndex = 14
        ' 
        ' ST_INS_Companies
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1143, 750)
        Controls.Add(DGV_CompaniesList)
        Controls.Add(GroupBox1)
        ForeColor = SystemColors.ControlText
        Margin = New Padding(4, 5, 4, 5)
        Name = "ST_INS_Companies"
        Text = "Crear Empresa"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_CompaniesList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents TB_CompanyName As TextBox
    Friend WithEvents TB_OfficialName As TextBox
    Friend WithEvents TB_TaxCode As TextBox
    Friend WithEvents LB_ConpanyName As Label
    Friend WithEvents LB_OfficialName As Label
    Friend WithEvents LB_TaxCode As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents DGV_CompaniesList As DataGridView
End Class
