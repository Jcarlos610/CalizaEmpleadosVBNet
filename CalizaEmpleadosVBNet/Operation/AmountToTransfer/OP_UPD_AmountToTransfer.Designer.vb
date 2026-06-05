<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_UPD_AmountToTransfer
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
        LB_TotalAmount = New Label()
        LB_TotalEmployees = New Label()
        DGV_Amtrans = New DataGridView()
        GroupBox1 = New GroupBox()
        DTP_EndDate = New DateTimePicker()
        LB_EndDate = New Label()
        DTP_StartDate = New DateTimePicker()
        LB_StartDate = New Label()
        TB_Amount = New TextBox()
        LB_Amount = New Label()
        BT_Consult = New Button()
        BT_Upd = New Button()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        LB_Title = New Label()
        CType(DGV_Amtrans, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LB_TotalAmount
        ' 
        LB_TotalAmount.AutoSize = True
        LB_TotalAmount.Location = New Point(159, 666)
        LB_TotalAmount.Name = "LB_TotalAmount"
        LB_TotalAmount.Size = New Size(105, 15)
        LB_TotalAmount.TabIndex = 11
        LB_TotalAmount.Text = "Monto Total: $0.00"
        ' 
        ' LB_TotalEmployees
        ' 
        LB_TotalEmployees.AutoSize = True
        LB_TotalEmployees.Location = New Point(12, 666)
        LB_TotalEmployees.Name = "LB_TotalEmployees"
        LB_TotalEmployees.Size = New Size(106, 15)
        LB_TotalEmployees.TabIndex = 10
        LB_TotalEmployees.Text = "Total Empleados: 0"
        ' 
        ' DGV_Amtrans
        ' 
        DGV_Amtrans.AllowUserToAddRows = False
        DGV_Amtrans.AllowUserToDeleteRows = False
        DGV_Amtrans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Amtrans.Location = New Point(12, 227)
        DGV_Amtrans.Name = "DGV_Amtrans"
        DGV_Amtrans.ReadOnly = True
        DGV_Amtrans.Size = New Size(1218, 420)
        DGV_Amtrans.TabIndex = 8
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DTP_EndDate)
        GroupBox1.Controls.Add(LB_EndDate)
        GroupBox1.Controls.Add(DTP_StartDate)
        GroupBox1.Controls.Add(LB_StartDate)
        GroupBox1.Controls.Add(TB_Amount)
        GroupBox1.Controls.Add(LB_Amount)
        GroupBox1.Controls.Add(BT_Consult)
        GroupBox1.Controls.Add(BT_Upd)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 166)
        GroupBox1.TabIndex = 7
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre monto"
        ' 
        ' DTP_EndDate
        ' 
        DTP_EndDate.Enabled = False
        DTP_EndDate.Location = New Point(403, 32)
        DTP_EndDate.Name = "DTP_EndDate"
        DTP_EndDate.Size = New Size(213, 23)
        DTP_EndDate.TabIndex = 19
        ' 
        ' LB_EndDate
        ' 
        LB_EndDate.AutoSize = True
        LB_EndDate.Location = New Point(327, 36)
        LB_EndDate.Name = "LB_EndDate"
        LB_EndDate.Size = New Size(74, 15)
        LB_EndDate.TabIndex = 18
        LB_EndDate.Text = "Fecha de fin:"
        ' 
        ' DTP_StartDate
        ' 
        DTP_StartDate.Location = New Point(106, 32)
        DTP_StartDate.Name = "DTP_StartDate"
        DTP_StartDate.Size = New Size(215, 23)
        DTP_StartDate.TabIndex = 17
        ' 
        ' LB_StartDate
        ' 
        LB_StartDate.AutoSize = True
        LB_StartDate.Location = New Point(15, 36)
        LB_StartDate.Name = "LB_StartDate"
        LB_StartDate.Size = New Size(89, 15)
        LB_StartDate.TabIndex = 16
        LB_StartDate.Text = "Fecha de inicio:"
        ' 
        ' TB_Amount
        ' 
        TB_Amount.BackColor = SystemColors.Info
        TB_Amount.Location = New Point(472, 121)
        TB_Amount.Name = "TB_Amount"
        TB_Amount.Size = New Size(79, 23)
        TB_Amount.TabIndex = 15
        ' 
        ' LB_Amount
        ' 
        LB_Amount.AutoSize = True
        LB_Amount.Location = New Point(420, 124)
        LB_Amount.Name = "LB_Amount"
        LB_Amount.Size = New Size(46, 15)
        LB_Amount.TabIndex = 14
        LB_Amount.Text = "Monto:"
        ' 
        ' BT_Consult
        ' 
        BT_Consult.Location = New Point(633, 32)
        BT_Consult.Name = "BT_Consult"
        BT_Consult.Size = New Size(123, 23)
        BT_Consult.TabIndex = 13
        BT_Consult.Text = "Consultar Semana"
        BT_Consult.UseVisualStyleBackColor = True
        ' 
        ' BT_Upd
        ' 
        BT_Upd.Location = New Point(1120, 124)
        BT_Upd.Name = "BT_Upd"
        BT_Upd.Size = New Size(75, 23)
        BT_Upd.TabIndex = 10
        BT_Upd.Text = "Actualizar"
        BT_Upd.UseVisualStyleBackColor = True
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 116)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 124)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 79)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 87)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(185, 30)
        LB_Title.TabIndex = 105
        LB_Title.Text = "Edición de montos"
        ' 
        ' OP_UPD_AmountToTransfer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 750)
        Controls.Add(LB_Title)
        Controls.Add(LB_TotalAmount)
        Controls.Add(LB_TotalEmployees)
        Controls.Add(DGV_Amtrans)
        Controls.Add(GroupBox1)
        Name = "OP_UPD_AmountToTransfer"
        Text = "Actualización de monto a tranferir"
        WindowState = FormWindowState.Maximized
        CType(DGV_Amtrans, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_TotalAmount As Label
    Friend WithEvents LB_TotalEmployees As Label
    Friend WithEvents DGV_Amtrans As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_Amount As TextBox
    Friend WithEvents LB_Amount As Label
    Friend WithEvents BT_Consult As Button
    Friend WithEvents BT_Upd As Button
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents DTP_EndDate As DateTimePicker
    Friend WithEvents LB_EndDate As Label
    Friend WithEvents DTP_StartDate As DateTimePicker
    Friend WithEvents LB_StartDate As Label
    Friend WithEvents LB_Title As Label
End Class
