Public Class OP_RecordsByEmployeeMoneySaved

    Private Sub OP_RecordByEmployeeMoneySaved_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadEmployeeInfo()
        LoadSavings()

    End Sub

    Sub LoadEmployeeInfo()

        Dim obj As New CL_RecordsByEmployeeMoneySaved

        DGV_EmployeeInfo.DataSource = obj.GetEmployeeRecords()

        DGV_EmployeeInfo.Columns("ID").HeaderText = "ID Registro"
        DGV_EmployeeInfo.Columns("EMPL_ID").HeaderText = "ID Empleado"
        DGV_EmployeeInfo.Columns("NombreEmpleado").HeaderText = "Nombre de empleado "
        DGV_EmployeeInfo.Columns("TotalAhorro").HeaderText = "Total Ahorro"

        DGV_EmployeeInfo.Columns("TotalAhorro").DefaultCellStyle.Format = "C2"

        DGV_EmployeeInfo.Columns("ID").Visible = False

    End Sub



    Sub LoadSavings()

        Dim obj As New CL_RecordsByEmployeeMoneySaved
        obj.REMPL_ID = GetREMPL_ID()

        DGV_DetailSaving.DataSource = obj.GetSavings()


        DGV_DetailSaving.Columns("DREMPL_DATE").HeaderText = "Fecha"
        DGV_DetailSaving.Columns("DREMPL_AMM").HeaderText = "Monto"


        DGV_DetailSaving.Columns("DREMPL_AMM").DefaultCellStyle.Format = "C2"


        DGV_DetailSaving.Columns("DREMPL_ID").Visible = False
        DGV_DetailSaving.Columns("REMPL_ID").Visible = False
        DGV_DetailSaving.Columns("DREMPL_TYPE").Visible = False
        DGV_DetailSaving.Columns("DREMPL_STAT").Visible = False

    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        If TB_ManualSaving.Text = "" Then
            MsgBox("Ingresa un monto")
            Exit Sub
        End If

        If Not IsNumeric(TB_ManualSaving.Text) Then
            MsgBox("Solo números")
            Exit Sub
        End If

        Dim obj As New CL_RecordsByEmployeeMoneySaved

        obj.REMPL_ID = GetREMPL_ID()
        obj.DREMPL_AMM = Convert.ToDecimal(TB_ManualSaving.Text)
        obj.DREMPL_TYPE = 1

        obj.InsertSaving()

        MsgBox("Ahorro registrado")

        TB_ManualSaving.Text = ""

        LoadSavings()
        LoadEmployeeInfo()

    End Sub

    Private Sub TB_ManualSaving_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_ManualSaving.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And e.KeyChar <> "." Then
            e.Handled = True
        End If

    End Sub

    Function GetREMPL_ID() As Integer

        If DGV_EmployeeInfo.CurrentRow Is Nothing Then
            Return 0
        End If

        Return Convert.ToInt32(DGV_EmployeeInfo.CurrentRow.Cells("ID").Value)

    End Function

    Private Sub DGV_EmployeeInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_EmployeeInfo.CellClick

        LoadSavings()

    End Sub

End Class