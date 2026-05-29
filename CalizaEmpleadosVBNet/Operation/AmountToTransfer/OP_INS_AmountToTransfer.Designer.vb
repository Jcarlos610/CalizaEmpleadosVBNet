<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_INS_AmountToTransfer
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
        TB_Amount = New TextBox()
        LB_Amount = New Label()
        BT_SearchExcel = New Button()
        BT_Register = New Button()
        DTP_Valid = New DateTimePicker()
        Label1 = New Label()
        TB_EmployeeName = New TextBox()
        LB_EmployeeName = New Label()
        TB_EmployeeId = New TextBox()
        LB_EmplyeeId = New Label()
        DGV_Amtrans = New DataGridView()
        OFD_Amtrans = New OpenFileDialog()
        PB_Progress = New ProgressBar()
        LB_TotalEmployees = New Label()
        LB_TotalAmount = New Label()
        GroupBox1.SuspendLayout()
        CType(DGV_Amtrans, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TB_Amount)
        GroupBox1.Controls.Add(LB_Amount)
        GroupBox1.Controls.Add(BT_SearchExcel)
        GroupBox1.Controls.Add(BT_Register)
        GroupBox1.Controls.Add(DTP_Valid)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TB_EmployeeName)
        GroupBox1.Controls.Add(LB_EmployeeName)
        GroupBox1.Controls.Add(TB_EmployeeId)
        GroupBox1.Controls.Add(LB_EmplyeeId)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 203)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información sobre monto"
        ' 
        ' TB_Amount
        ' 
        TB_Amount.BackColor = SystemColors.Info
        TB_Amount.Location = New Point(472, 152)
        TB_Amount.Name = "TB_Amount"
        TB_Amount.ReadOnly = True
        TB_Amount.Size = New Size(79, 23)
        TB_Amount.TabIndex = 15
        ' 
        ' LB_Amount
        ' 
        LB_Amount.AutoSize = True
        LB_Amount.Location = New Point(420, 155)
        LB_Amount.Name = "LB_Amount"
        LB_Amount.Size = New Size(46, 15)
        LB_Amount.TabIndex = 14
        LB_Amount.Text = "Monto:"
        ' 
        ' BT_SearchExcel
        ' 
        BT_SearchExcel.Location = New Point(15, 49)
        BT_SearchExcel.Name = "BT_SearchExcel"
        BT_SearchExcel.Size = New Size(102, 23)
        BT_SearchExcel.TabIndex = 13
        BT_SearchExcel.Text = "Buscar Excel"
        BT_SearchExcel.UseVisualStyleBackColor = True
        ' 
        ' BT_Register
        ' 
        BT_Register.Location = New Point(1120, 151)
        BT_Register.Name = "BT_Register"
        BT_Register.Size = New Size(75, 23)
        BT_Register.TabIndex = 10
        BT_Register.Text = "Registrar"
        BT_Register.UseVisualStyleBackColor = True
        ' 
        ' DTP_Valid
        ' 
        DTP_Valid.Location = New Point(147, 47)
        DTP_Valid.Name = "DTP_Valid"
        DTP_Valid.Size = New Size(232, 23)
        DTP_Valid.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(147, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 6
        Label1.Text = "Fecha de aplicación:"
        ' 
        ' TB_EmployeeName
        ' 
        TB_EmployeeName.Location = New Point(147, 147)
        TB_EmployeeName.Name = "TB_EmployeeName"
        TB_EmployeeName.ReadOnly = True
        TB_EmployeeName.Size = New Size(253, 23)
        TB_EmployeeName.TabIndex = 5
        ' 
        ' LB_EmployeeName
        ' 
        LB_EmployeeName.AutoSize = True
        LB_EmployeeName.Location = New Point(15, 155)
        LB_EmployeeName.Name = "LB_EmployeeName"
        LB_EmployeeName.Size = New Size(123, 15)
        LB_EmployeeName.TabIndex = 4
        LB_EmployeeName.Text = "Nombre de empleado"
        ' 
        ' TB_EmployeeId
        ' 
        TB_EmployeeId.Location = New Point(147, 110)
        TB_EmployeeId.Name = "TB_EmployeeId"
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeId.Size = New Size(61, 23)
        TB_EmployeeId.TabIndex = 3
        ' 
        ' LB_EmplyeeId
        ' 
        LB_EmplyeeId.AutoSize = True
        LB_EmplyeeId.Location = New Point(15, 118)
        LB_EmplyeeId.Name = "LB_EmplyeeId"
        LB_EmplyeeId.Size = New Size(129, 15)
        LB_EmplyeeId.TabIndex = 2
        LB_EmplyeeId.Text = "Número de empleado: "
        ' 
        ' DGV_Amtrans
        ' 
        DGV_Amtrans.AllowUserToAddRows = False
        DGV_Amtrans.AllowUserToDeleteRows = False
        DGV_Amtrans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Amtrans.Location = New Point(12, 267)
        DGV_Amtrans.Name = "DGV_Amtrans"
        DGV_Amtrans.ReadOnly = True
        DGV_Amtrans.Size = New Size(1218, 380)
        DGV_Amtrans.TabIndex = 3
        ' 
        ' OFD_Amtrans
        ' 
        OFD_Amtrans.FileName = "OpenFileDialog1"
        ' 
        ' PB_Progress
        ' 
        PB_Progress.Location = New Point(15, 654)
        PB_Progress.Name = "PB_Progress"
        PB_Progress.Size = New Size(1215, 10)
        PB_Progress.TabIndex = 4
        ' 
        ' LB_TotalEmployees
        ' 
        LB_TotalEmployees.AutoSize = True
        LB_TotalEmployees.Location = New Point(12, 691)
        LB_TotalEmployees.Name = "LB_TotalEmployees"
        LB_TotalEmployees.Size = New Size(106, 15)
        LB_TotalEmployees.TabIndex = 5
        LB_TotalEmployees.Text = "Total Empleados: 0"
        ' 
        ' LB_TotalAmount
        ' 
        LB_TotalAmount.AutoSize = True
        LB_TotalAmount.Location = New Point(159, 691)
        LB_TotalAmount.Name = "LB_TotalAmount"
        LB_TotalAmount.Size = New Size(105, 15)
        LB_TotalAmount.TabIndex = 6
        LB_TotalAmount.Text = "Monto Total: $0.00"
        ' 
        ' OP_INS_AmountToTransfer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 750)
        Controls.Add(LB_TotalAmount)
        Controls.Add(LB_TotalEmployees)
        Controls.Add(PB_Progress)
        Controls.Add(DGV_Amtrans)
        Controls.Add(GroupBox1)
        Name = "OP_INS_AmountToTransfer"
        Text = "Monto a transferir"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGV_Amtrans, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BT_Register As Button
    Friend WithEvents DTP_Valid As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_EmployeeName As TextBox
    Friend WithEvents LB_EmployeeName As Label
    Friend WithEvents TB_EmployeeId As TextBox
    Friend WithEvents LB_EmplyeeId As Label
    Friend WithEvents BT_SearchExcel As Button
    Friend WithEvents DGV_Amtrans As DataGridView
    Friend WithEvents OFD_Amtrans As OpenFileDialog
    Friend WithEvents TB_Amount As TextBox
    Friend WithEvents LB_Amount As Label
    Friend WithEvents PB_Progress As ProgressBar
    Friend WithEvents LB_TotalEmployees As Label
    Friend WithEvents LB_TotalAmount As Label
End Class
