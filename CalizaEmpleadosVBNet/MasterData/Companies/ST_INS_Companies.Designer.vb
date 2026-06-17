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
        LB_Title = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_CompaniesList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TB_CompanyName
        ' 
        TB_CompanyName.Location = New Point(16, 46)
        TB_CompanyName.Name = "TB_CompanyName"
        TB_CompanyName.Size = New Size(445, 23)
        TB_CompanyName.TabIndex = 1
        ' 
        ' TB_OfficialName
        ' 
        TB_OfficialName.Location = New Point(16, 92)
        TB_OfficialName.Name = "TB_OfficialName"
        TB_OfficialName.Size = New Size(445, 23)
        TB_OfficialName.TabIndex = 2
        ' 
        ' TB_TaxCode
        ' 
        TB_TaxCode.Location = New Point(504, 92)
        TB_TaxCode.Name = "TB_TaxCode"
        TB_TaxCode.Size = New Size(100, 23)
        TB_TaxCode.TabIndex = 3
        ' 
        ' LB_ConpanyName
        ' 
        LB_ConpanyName.AutoSize = True
        LB_ConpanyName.Location = New Point(16, 29)
        LB_ConpanyName.Name = "LB_ConpanyName"
        LB_ConpanyName.Size = New Size(115, 15)
        LB_ConpanyName.TabIndex = 5
        LB_ConpanyName.Text = "Nombre de empresa"
        ' 
        ' LB_OfficialName
        ' 
        LB_OfficialName.AutoSize = True
        LB_OfficialName.Location = New Point(16, 74)
        LB_OfficialName.Name = "LB_OfficialName"
        LB_OfficialName.Size = New Size(73, 15)
        LB_OfficialName.TabIndex = 6
        LB_OfficialName.Text = "Razón Social"
        ' 
        ' LB_TaxCode
        ' 
        LB_TaxCode.AutoSize = True
        LB_TaxCode.Location = New Point(504, 77)
        LB_TaxCode.Name = "LB_TaxCode"
        LB_TaxCode.Size = New Size(28, 15)
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
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(749, 135)
        GroupBox1.TabIndex = 8
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de empresa"
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(654, 92)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 8
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' DGV_CompaniesList
        ' 
        DGV_CompaniesList.AllowUserToAddRows = False
        DGV_CompaniesList.AllowUserToDeleteRows = False
        DGV_CompaniesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_CompaniesList.Location = New Point(12, 190)
        DGV_CompaniesList.Name = "DGV_CompaniesList"
        DGV_CompaniesList.ReadOnly = True
        DGV_CompaniesList.RowHeadersWidth = 62
        DGV_CompaniesList.Size = New Size(892, 228)
        DGV_CompaniesList.TabIndex = 14
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(211, 30)
        LB_Title.TabIndex = 105
        LB_Title.Text = "Registro de empresas"
        ' 
        ' ST_INS_Companies
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(800, 450)
        Controls.Add(LB_Title)
        Controls.Add(DGV_CompaniesList)
        Controls.Add(GroupBox1)
        ForeColor = SystemColors.ControlText
        Name = "ST_INS_Companies"
        Text = "Registro de empresas"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_CompaniesList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
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
    Friend WithEvents LB_Title As Label
End Class
