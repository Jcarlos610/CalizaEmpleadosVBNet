<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MD_UPD_Discounts
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
        GroupBox1 = New GroupBox()
        CB_Type = New ComboBox()
        LB_Type = New Label()
        TB_Ammount = New TextBox()
        LB_Ammount = New Label()
        CB_Status = New CheckBox()
        CB_AllDiscounts = New ComboBox()
        DT_ValidTo = New DateTimePicker()
        LB_ValidTo = New Label()
        DT_ValidFrom = New DateTimePicker()
        LB_ValidFrom = New Label()
        BT_Update = New Button()
        LB_AuthorizeBy = New Label()
        LB_Description = New Label()
        TB_DiscountName = New TextBox()
        LB_DiscountName = New Label()
        TB_Description = New TextBox()
        TB_AuthorizeBy = New TextBox()
        DGV_DiscountsList = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(DGV_DiscountsList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CB_Type)
        GroupBox1.Controls.Add(LB_Type)
        GroupBox1.Controls.Add(TB_Ammount)
        GroupBox1.Controls.Add(LB_Ammount)
        GroupBox1.Controls.Add(CB_Status)
        GroupBox1.Controls.Add(CB_AllDiscounts)
        GroupBox1.Controls.Add(DT_ValidTo)
        GroupBox1.Controls.Add(LB_ValidTo)
        GroupBox1.Controls.Add(DT_ValidFrom)
        GroupBox1.Controls.Add(LB_ValidFrom)
        GroupBox1.Controls.Add(BT_Update)
        GroupBox1.Controls.Add(LB_AuthorizeBy)
        GroupBox1.Controls.Add(LB_Description)
        GroupBox1.Controls.Add(TB_DiscountName)
        GroupBox1.Controls.Add(LB_DiscountName)
        GroupBox1.Controls.Add(TB_Description)
        GroupBox1.Controls.Add(TB_AuthorizeBy)
        GroupBox1.Location = New Point(12, 44)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(896, 216)
        GroupBox1.TabIndex = 13
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información de descuentos"
        ' 
        ' CB_Type
        ' 
        CB_Type.FormattingEnabled = True
        CB_Type.Location = New Point(687, 80)
        CB_Type.Name = "CB_Type"
        CB_Type.Size = New Size(121, 23)
        CB_Type.TabIndex = 22
        ' 
        ' LB_Type
        ' 
        LB_Type.AutoSize = True
        LB_Type.Location = New Point(687, 63)
        LB_Type.Name = "LB_Type"
        LB_Type.Size = New Size(105, 15)
        LB_Type.TabIndex = 21
        LB_Type.Text = "Tipo de descuento"
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
        LB_Ammount.Location = New Point(17, 162)
        LB_Ammount.Name = "LB_Ammount"
        LB_Ammount.Size = New Size(90, 15)
        LB_Ammount.TabIndex = 18
        LB_Ammount.Text = "Monto definido"
        ' 
        ' CB_Status
        ' 
        CB_Status.AutoSize = True
        CB_Status.Location = New Point(820, 23)
        CB_Status.Name = "CB_Status"
        CB_Status.Size = New Size(58, 19)
        CB_Status.TabIndex = 17
        CB_Status.Text = "Status"
        CB_Status.UseVisualStyleBackColor = True
        ' 
        ' CB_AllDiscounts
        ' 
        CB_AllDiscounts.FormattingEnabled = True
        CB_AllDiscounts.Location = New Point(16, 22)
        CB_AllDiscounts.Name = "CB_AllDiscounts"
        CB_AllDiscounts.Size = New Size(222, 23)
        CB_AllDiscounts.TabIndex = 0
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
        LB_ValidTo.Location = New Point(404, 159)
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
        LB_ValidFrom.Location = New Point(155, 159)
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
        LB_AuthorizeBy.Location = New Point(17, 114)
        LB_AuthorizeBy.Name = "LB_AuthorizeBy"
        LB_AuthorizeBy.Size = New Size(89, 15)
        LB_AuthorizeBy.TabIndex = 7
        LB_AuthorizeBy.Text = "Autorizado por:"
        ' 
        ' LB_Description
        ' 
        LB_Description.AutoSize = True
        LB_Description.Location = New Point(255, 64)
        LB_Description.Name = "LB_Description"
        LB_Description.Size = New Size(69, 15)
        LB_Description.TabIndex = 6
        LB_Description.Text = "Descripción"
        ' 
        ' TB_DiscountName
        ' 
        TB_DiscountName.Location = New Point(16, 81)
        TB_DiscountName.Name = "TB_DiscountName"
        TB_DiscountName.Size = New Size(222, 23)
        TB_DiscountName.TabIndex = 1
        ' 
        ' LB_DiscountName
        ' 
        LB_DiscountName.AutoSize = True
        LB_DiscountName.Location = New Point(17, 65)
        LB_DiscountName.Name = "LB_DiscountName"
        LB_DiscountName.Size = New Size(128, 15)
        LB_DiscountName.TabIndex = 5
        LB_DiscountName.Text = "Nombre del descuento"
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
        ' DGV_DiscountsList
        ' 
        DGV_DiscountsList.AllowUserToAddRows = False
        DGV_DiscountsList.AllowUserToDeleteRows = False
        DGV_DiscountsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_DiscountsList.Location = New Point(12, 274)
        DGV_DiscountsList.Name = "DGV_DiscountsList"
        DGV_DiscountsList.ReadOnly = True
        DGV_DiscountsList.RowHeadersWidth = 62
        DGV_DiscountsList.Size = New Size(1218, 406)
        DGV_DiscountsList.TabIndex = 14
        ' 
        ' MD_UPD_Discounts
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 630)
        Controls.Add(DGV_DiscountsList)
        Controls.Add(GroupBox1)
        Margin = New Padding(2)
        Name = "MD_UPD_Discounts"
        Text = "Modificación de opciones de descuentos"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_DiscountsList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_Ammount As TextBox
    Friend WithEvents LB_Ammount As Label
    Friend WithEvents CB_Status As CheckBox
    Friend WithEvents CB_AllDiscounts As ComboBox
    Friend WithEvents DT_ValidTo As DateTimePicker
    Friend WithEvents LB_ValidTo As Label
    Friend WithEvents DT_ValidFrom As DateTimePicker
    Friend WithEvents LB_ValidFrom As Label
    Friend WithEvents BT_Update As Button
    Friend WithEvents LB_AuthorizeBy As Label
    Friend WithEvents LB_Description As Label
    Friend WithEvents TB_DiscountName As TextBox
    Friend WithEvents LB_DiscountName As Label
    Friend WithEvents TB_Description As TextBox
    Friend WithEvents TB_AuthorizeBy As TextBox
    Friend WithEvents DGV_DiscountsList As DataGridView
    Friend WithEvents LB_Type As Label
    Friend WithEvents CB_Type As ComboBox
End Class
