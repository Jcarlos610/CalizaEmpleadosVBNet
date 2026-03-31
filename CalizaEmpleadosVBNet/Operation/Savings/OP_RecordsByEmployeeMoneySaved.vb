Public Class OP_RecordsByEmployeeMoneySaved

    Private Sub OP_RecordByEmployeeMoneySaved_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadEmployeeInfo()

    End Sub

    Sub LoadEmployeeInfo()

        Dim obj As New CL_RecordsByEmployeeMoneySaved

        DGV_EmployeeInfo.DataSource = obj.GetEmployeeRecords()

        DGV_EmployeeInfo.Columns("EMPL_ID").HeaderText = "ID Empleado"
        DGV_EmployeeInfo.Columns("NombreEmpleado").HeaderText = "Nombre de empleado "
        DGV_EmployeeInfo.Columns("TotalAhorro").HeaderText = "Total Ahorro"


        DGV_EmployeeInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_EmployeeInfo.AutoResizeColumns()
        DGV_EmployeeInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_EmployeeInfo.Columns("TotalAhorro").DefaultCellStyle.Format = "C2"

    End Sub



    Sub LoadSavings()

        Dim obj As New CL_RecordsByEmployeeMoneySaved
        obj.EMPL_ID = Get_EMPL_ID()

        DGV_DetailSaving.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DetailSaving.AutoResizeColumns()
        DGV_DetailSaving.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_DetailSaving.DataSource = obj.GetSavings()

    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        If TB_ManualSaving.Text = "" Then
            MessageBox.Show("Ingresa un monto", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(TB_ManualSaving.Text) Then
            MessageBox.Show("Solo números", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim obj As New CL_RecordsByEmployeeMoneySaved

        obj.EMPL_ID = Get_EMPL_ID()
        obj.DREMPL_AMM = Convert.ToDecimal(TB_ManualSaving.Text)
        obj.DREMPL_TYPE = 1
        obj.REMPL_CREBY = AppUser
        obj.REMPL_RDATE = Date.Today

        obj.InsertSaving()

        MessageBox.Show("Ahorro registrado", "Confirmación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

        TB_ManualSaving.Text = ""

        LoadSavings()
        LoadEmployeeInfo()

    End Sub

    Private Sub TB_ManualSaving_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_ManualSaving.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And e.KeyChar <> "." Then
            e.Handled = True
        End If

    End Sub

    Function Get_EMPL_ID() As Integer

        If DGV_EmployeeInfo.CurrentRow Is Nothing Then
            Return 0
        End If

        Return Convert.ToInt32(DGV_EmployeeInfo.CurrentRow.Cells("EMPL_ID").Value)

    End Function

    Private Sub DGV_EmployeeInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_EmployeeInfo.CellClick

        LoadSavings()

    End Sub

End Class