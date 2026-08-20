<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OP_PayrollApproval
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
        GroupBox1 = New GroupBox()
        DGV_Approvals = New DataGridView()
        DGV_PayrollDetail = New DataGridView()
        ColApprovalID = New DataGridViewTextBoxColumn()
        ColBatchID = New DataGridViewTextBoxColumn()
        ColStartDate = New DataGridViewTextBoxColumn()
        ColEndDate = New DataGridViewTextBoxColumn()
        ColAmount = New DataGridViewTextBoxColumn()
        ColRequestedBy = New DataGridViewTextBoxColumn()
        ColReject = New DataGridViewButtonColumn()
        ColApprove = New DataGridViewButtonColumn()
        GroupBox1.SuspendLayout()
        CType(DGV_Approvals, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGV_PayrollDetail, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LB_Title
        ' 
        LB_Title.AutoSize = True
        LB_Title.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LB_Title.Location = New Point(12, 11)
        LB_Title.Name = "LB_Title"
        LB_Title.Size = New Size(229, 30)
        LB_Title.TabIndex = 105
        LB_Title.Text = "Aprobación de Nómina"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DGV_Approvals)
        GroupBox1.Location = New Point(12, 46)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1218, 306)
        GroupBox1.TabIndex = 106
        GroupBox1.TabStop = False
        GroupBox1.Text = "Información "
        ' 
        ' DGV_Approvals
        ' 
        DGV_Approvals.AllowUserToAddRows = False
        DGV_Approvals.AllowUserToDeleteRows = False
        DGV_Approvals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_Approvals.Columns.AddRange(New DataGridViewColumn() {ColApprovalID, ColBatchID, ColStartDate, ColEndDate, ColAmount, ColRequestedBy, ColReject, ColApprove})
        DGV_Approvals.Location = New Point(21, 32)
        DGV_Approvals.Name = "DGV_Approvals"
        DGV_Approvals.ReadOnly = True
        DGV_Approvals.Size = New Size(1088, 251)
        DGV_Approvals.TabIndex = 4
        ' 
        ' DGV_PayrollDetail
        ' 
        DGV_PayrollDetail.AllowUserToAddRows = False
        DGV_PayrollDetail.AllowUserToDeleteRows = False
        DGV_PayrollDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGV_PayrollDetail.Location = New Point(12, 368)
        DGV_PayrollDetail.Name = "DGV_PayrollDetail"
        DGV_PayrollDetail.ReadOnly = True
        DGV_PayrollDetail.Size = New Size(1212, 306)
        DGV_PayrollDetail.TabIndex = 107
        ' 
        ' ColApprovalID
        ' 
        ColApprovalID.HeaderText = "ID Interno"
        ColApprovalID.Name = "ColApprovalID"
        ColApprovalID.ReadOnly = True
        ColApprovalID.Visible = False
        ' 
        ' ColBatchID
        ' 
        ColBatchID.HeaderText = "ID"
        ColBatchID.Name = "ColBatchID"
        ColBatchID.ReadOnly = True
        ' 
        ' ColStartDate
        ' 
        ColStartDate.HeaderText = "Fecha Inicio"
        ColStartDate.Name = "ColStartDate"
        ColStartDate.ReadOnly = True
        ' 
        ' ColEndDate
        ' 
        ColEndDate.HeaderText = "Fecha Fin"
        ColEndDate.Name = "ColEndDate"
        ColEndDate.ReadOnly = True
        ' 
        ' ColAmount
        ' 
        ColAmount.HeaderText = "Monto Calculado"
        ColAmount.Name = "ColAmount"
        ColAmount.ReadOnly = True
        ' 
        ' ColRequestedBy
        ' 
        ColRequestedBy.HeaderText = "Solicitó"
        ColRequestedBy.Name = "ColRequestedBy"
        ColRequestedBy.ReadOnly = True
        ' 
        ' ColReject
        ' 
        ColReject.HeaderText = ""
        ColReject.Name = "ColReject"
        ColReject.ReadOnly = True
        ColReject.Resizable = DataGridViewTriState.True
        ColReject.SortMode = DataGridViewColumnSortMode.Automatic
        ColReject.Text = "Rechazar"
        ColReject.UseColumnTextForButtonValue = True
        ' 
        ' ColApprove
        ' 
        ColApprove.HeaderText = ""
        ColApprove.Name = "ColApprove"
        ColApprove.ReadOnly = True
        ColApprove.Resizable = DataGridViewTriState.True
        ColApprove.SortMode = DataGridViewColumnSortMode.Automatic
        ColApprove.Text = "Aprobar"
        ColApprove.UseColumnTextForButtonValue = True
        ' 
        ' OP_PayrollApproval
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1242, 750)
        Controls.Add(DGV_PayrollDetail)
        Controls.Add(GroupBox1)
        Controls.Add(LB_Title)
        Name = "OP_PayrollApproval"
        Text = "Aprobación de Nómina"
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        CType(DGV_Approvals, ComponentModel.ISupportInitialize).EndInit()
        CType(DGV_PayrollDetail, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LB_Title As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGV_Approvals As DataGridView
    Friend WithEvents DGV_PayrollDetail As DataGridView
    Friend WithEvents ColApprovalID As DataGridViewTextBoxColumn
    Friend WithEvents ColBatchID As DataGridViewTextBoxColumn
    Friend WithEvents ColStartDate As DataGridViewTextBoxColumn
    Friend WithEvents ColEndDate As DataGridViewTextBoxColumn
    Friend WithEvents ColAmount As DataGridViewTextBoxColumn
    Friend WithEvents ColRequestedBy As DataGridViewTextBoxColumn
    Friend WithEvents ColReject As DataGridViewButtonColumn
    Friend WithEvents ColApprove As DataGridViewButtonColumn
End Class
