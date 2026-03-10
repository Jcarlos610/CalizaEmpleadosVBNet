<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_UPD_Banns
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
        GroupBox1 = New GroupBox()
        TB_Ammount = New TextBox()
        LB_Ammount = New Label()
        CB_Status = New CheckBox()
        CB_AllBanns = New ComboBox()
        DT_ValidTo = New DateTimePicker()
        LB_ValidTo = New Label()
        DT_ValidFrom = New DateTimePicker()
        LB_ValidFrom = New Label()
        BT_Update = New Button()
        LB_AuthorizeBy = New Label()
        LB_Description = New Label()
        TB_BannName = New TextBox()
        LB_BannName = New Label()
        TB_Description = New TextBox()
        TB_AuthorizeBy = New TextBox()
        DGV_BannsList = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_BannsList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_Ammount)
        GroupBox1.Controls.Add(LB_Ammount)
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Controls.Add(CB_AllBanns)
        GroupBox1.Controls.Add(DT_ValidTo)
        GroupBox1.Controls.Add(LB_ValidTo)
        GroupBox1.Controls.Add(DT_ValidFrom)
        GroupBox1.Controls.Add(LB_ValidFrom)
        GroupBox1.Controls.Add(BT_Update)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_BannName)
        GroupBox1.Controls.Add(LB_BannName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Location = New Point(12, 44)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(896, 216)
        GroupBox1.TabIndex = 12
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información de amonestaciones"
        ' 
        ' TB_Ammount
        ' 
        TB_Ammount.BackColor = SystemColors.Info
        TB_Ammount.Location = New Point(16, 176)
        TB_Ammount.Name = "TB_Ammount"
        TB_Ammount.Size = New Size(120, 23)
        TB_Ammount.TabIndex = 19
        ' 
        ' LB_Ammount
        ' 
        LB_Ammount.AutoSize = True
        LB_Ammount.Location = New Point(16, 161)
        LB_Ammount.Name = "LB_Ammount"
        LB_Ammount.Size = New Size(90, 15)
        LB_Ammount.TabIndex = 18
        LB_Ammount.Text = "Monto definido"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(819, 22)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(58, 19)
        CB_Status.TabIndex = 17
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' CB_AllBanns
        ' 
        CB_AllBanns.FormattingEnabled = True
        CB_AllBanns.Location = New Point(16, 22)
        CB_AllBanns.Name = "CB_AllBanns"
        CB_AllBanns.Size = New Size(222, 23)
        CB_AllBanns.TabIndex = 0
        ' 
        ' DT_ValidTo
        ' 
        DT_ValidTo.Location = New Point(403, 176)
        DT_ValidTo.Name = "DT_ValidTo"
        DT_ValidTo.Size = New Size(228, 23)
        DT_ValidTo.TabIndex = 7
        ' 
        ' LB_ValidTo
        ' 
        LB_ValidTo.AutoSize = True
        LB_ValidTo.Location = New Point(403, 158)
        LB_ValidTo.Name = "LB_ValidTo"
        LB_ValidTo.Size = New Size(70, 15)
        LB_ValidTo.TabIndex = 15
        LB_ValidTo.Text = "Valido hasta"
        ' 
        ' DT_ValidFrom
        ' 
        DT_ValidFrom.Location = New Point(154, 176)
        DT_ValidFrom.Name = "DT_ValidFrom"
        DT_ValidFrom.Size = New Size(232, 23)
        DT_ValidFrom.TabIndex = 6
        ' 
        ' LB_ValidFrom
        ' 
        LB_ValidFrom.AutoSize = True
        LB_ValidFrom.Location = New Point(154, 158)
        LB_ValidFrom.Name = "LB_ValidFrom"
        LB_ValidFrom.Size = New Size(73, 15)
        LB_ValidFrom.TabIndex = 13
        LB_ValidFrom.Text = "Valido desde"
        ' 
        ' BT_Update
        ' 
        BT_Update.Location = New Point(802, 176)
        BT_Update.Name = "BT_Update"
        BT_Update.Size = New Size(75, 23)
        BT_Update.TabIndex = 8
        BT_Update.Text = "Actualizar"
        BT_Update.UseVisualStyleBackColor = True
        ' 
        ' LB_AuthorizeBy
        ' 
        LB_AuthorizeBy.AutoSize = True
        LB_AuthorizeBy.Location = New Point(16, 113)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(254, 63)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 6
        LB_Description.Text = "Descripción"
        ' 
        ' TB_BannName
        ' 
        TB_BannName.Location = New Point(16, 81)
        TB_BannName.Name = "TB_BannName"
        TB_BannName.Size = New Size(222, 23)
        TB_BannName.TabIndex = 1
        ' 
        ' LB_BannName
        ' 
        LB_BannName.AutoSize = True
        LB_BannName.Location = New Point(16, 64)
        LB_BannName.Name = "LB_BannName"
        LB_BannName.Size = New Size(148, 15)
        LB_BannName.TabIndex = 5
        LB_BannName.Text = "Nombre del amonestación"
        ' 
        ' TB_Description
        ' 
        TB_Description.Location = New Point(254, 81)
        TB_Description.Multiline = True
        TB_Description.Name = "TB_Description"
        TB_Description.Size = New Size(404, 70)
        TB_Description.TabIndex = 2
        ' 
        ' TB_AuthorizeBy
        ' 
        TB_AuthorizeBy.Location = New Point(16, 128)
        TB_AuthorizeBy.Name = "TB_AuthorizeBy"
        TB_AuthorizeBy.Size = New Size(222, 23)
        TB_AuthorizeBy.TabIndex = 3
        ' 
        ' DGV_BannsList
        ' 
        DGV_BannsList.AllowUserToAddRows = False
        DGV_BannsList.AllowUserToDeleteRows = False
        DGV_BannsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_BannsList.Location = New Point(12, 274)
        DGV_BannsList.Name = "DGV_BannsList"
        DGV_BannsList.ReadOnly = True
        DGV_BannsList.Size = New Size(1218, 406)
        DGV_BannsList.TabIndex = 13
        ' 
        ' MD_UPD_Banns
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 694)
        Controls.Add(DGV_BannsList)
        Controls.Add(GroupBox1)
        Name = "MD_UPD_Banns"
        Text = "Modificación de amonestaciones"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_BannsList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_Ammount As TextBox
    Friend WithEvents LB_Ammount As Label
    Friend WithEvents CB_Status As CheckBox
    Friend WithEvents CB_AllBanns As ComboBox
    Friend WithEvents DT_ValidTo As DateTimePicker
    Friend WithEvents LB_ValidTo As Label
    Friend WithEvents DT_ValidFrom As DateTimePicker
    Friend WithEvents LB_ValidFrom As Label
    Friend WithEvents BT_Update As Button
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_BannName As TextBox
    Friend WithEvents LB_BannName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents DGV_BannsList As DataGridView
End Class
