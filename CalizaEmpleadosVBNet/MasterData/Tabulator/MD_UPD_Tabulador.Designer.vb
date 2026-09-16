<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MD_UPD_Tabulador
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
        LB_Title = New Label()
        DGV_Tabulator = New DataGridView()
        GroupBox1 = New GroupBox()
        TB_PriceIncrease = New TextBox()
        LB_PriceIncreaseTitle = New Label()
        TB_Price = New TextBox()
        LB_Price = New Label()
        BT_Upd = New Button()
        CB_LocationList = New ComboBox()
        LB_Locations1 = New Label()
        CB_CustomerList = New ComboBox()
        LB_Customers1 = New Label()
        CType(DGV_Tabulator, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(290, 30)
        LB_Title.TabIndex = 116
        LB_Title.Text = "Edición de tabulador de viajes"
        ' 
        ' DGV_Tabulator
        ' 
        DGV_Tabulator.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Tabulator.Location = New Point(12, 46)
        DGV_Tabulator.Name = "DGV_Tabulator"
        DGV_Tabulator.Size = New Size(1070, 322)
        DGV_Tabulator.TabIndex = 117
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_PriceIncrease)
        GroupBox1.Controls.Add(LB_PriceIncreaseTitle)
        GroupBox1.Controls.Add(TB_Price)
        GroupBox1.Controls.Add(LB_Price)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(CB_LocationList)
        GroupBox1.Controls.Add(LB_Locations1)
        GroupBox1.Controls.Add(CB_CustomerList)
        GroupBox1.Controls.Add(LB_Customers1)
        GroupBox1.Location = New Point(12, 379)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(840, 113)
        GroupBox1.TabIndex = 118
        GroupBox1.TabStop = False
        ' 
        ' TB_PriceIncrease
        ' 
        TB_PriceIncrease.Location = New Point(117, 84)
        TB_PriceIncrease.Name = "TB_PriceIncrease"
        TB_PriceIncrease.ReadOnly = True
        TB_PriceIncrease.Size = New Size(100, 23)
        TB_PriceIncrease.TabIndex = 24
        ' 
        ' LB_PriceIncreaseTitle
        ' 
        LB_PriceIncreaseTitle.AutoSize = True
        LB_PriceIncreaseTitle.Location = New Point(117, 66)
        LB_PriceIncreaseTitle.Name = "LB_PriceIncreaseTitle"
        LB_PriceIncreaseTitle.Size = New Size(87, 15)
        LB_PriceIncreaseTitle.TabIndex = 23
        LB_PriceIncreaseTitle.Text = "Incremento 3%"
        ' 
        ' TB_Price
        ' 
        TB_Price.BackColor = SystemColors.Info
        TB_Price.Location = New Point(6, 83)
        TB_Price.Name = "TB_Price"
        TB_Price.Size = New Size(100, 23)
        TB_Price.TabIndex = 22
        ' 
        ' LB_Price
        ' 
        LB_Price.AutoSize = True
        LB_Price.Location = New Point(6, 66)
        LB_Price.Name = "LB_Price"
        LB_Price.Size = New Size(43, 15)
        LB_Price.TabIndex = 21
        LB_Price.Text = "Precio:"
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(750, 82)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 13
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' CB_LocationList
        ' 
        CB_LocationList.DropDownStyle = ComboBoxStyle.DropDownList
        CB_LocationList.FormattingEnabled = True
        CB_LocationList.Location = New Point(279, 36)
        CB_LocationList.Margin = New Padding(3, 2, 3, 2)
        CB_LocationList.Name = "CB_LocationList"
        CB_LocationList.Size = New Size(546, 23)
        CB_LocationList.TabIndex = 12
        ' 
        ' LB_Locations1
        ' 
        LB_Locations1.AutoSize = True
        LB_Locations1.Location = New Point(279, 16)
        LB_Locations1.Name = "LB_Locations1"
        LB_Locations1.Size = New Size(133, 15)
        LB_Locations1.TabIndex = 11
        LB_Locations1.Text = "Seleccione una Sucursal"
        ' 
        ' CB_CustomerList
        ' 
        CB_CustomerList.DropDownStyle = ComboBoxStyle.DropDownList
        CB_CustomerList.FormattingEnabled = True
        CB_CustomerList.Location = New Point(6, 36)
        CB_CustomerList.Margin = New Padding(3, 2, 3, 2)
        CB_CustomerList.Name = "CB_CustomerList"
        CB_CustomerList.Size = New Size(269, 23)
        CB_CustomerList.TabIndex = 10
        ' 
        ' LB_Customers1
        ' 
        LB_Customers1.AutoSize = True
        LB_Customers1.Location = New Point(6, 19)
        LB_Customers1.Name = "LB_Customers1"
        LB_Customers1.Size = New Size(120, 15)
        LB_Customers1.TabIndex = 9
        LB_Customers1.Text = "Seleccione un Cliente"
        ' 
        ' MD_UPD_Tabulador
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 831)
        Controls.Add(GroupBox1)
        Controls.Add(DGV_Tabulator)
        Controls.Add(LB_Title)
        Name = "MD_UPD_Tabulador"
        Text = "Edición de tabulador de viajes"
        WindowState = FormWindowState.Maximized
        CType(DGV_Tabulator, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents DGV_Tabulator As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_PriceIncrease As TextBox
    Friend WithEvents LB_PriceIncreaseTitle As Label
    Friend WithEvents TB_Price As TextBox
    Friend WithEvents LB_Price As Label
    Friend WithEvents BT_Upd As Button
    Friend WithEvents CB_LocationList As ComboBox
    Friend WithEvents LB_Locations1 As Label
    Friend WithEvents CB_CustomerList As ComboBox
    Friend WithEvents LB_Customers1 As Label
End Class
