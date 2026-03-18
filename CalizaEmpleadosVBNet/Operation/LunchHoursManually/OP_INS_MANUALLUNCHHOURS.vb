Imports System.Data

Public Class OP_INS_MANUALLUNCHHOURS

    Private MOVE_ID As Integer = 250

    Private Sub OP_INS_MANUALLUNCHHOURS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadActiveEmployees()

        DTP_DateLunchHours.Value = DateTime.Now
        BT_LuchHoursRegister.Enabled = False

    End Sub

    'Cargar empleados activos
    Private Sub LoadActiveEmployees()
        Try
            Dim Employees As New CL_Employee
            Dim dt As DataTable = Employees.Get_AllActiveEmployeesListForLunchHours()
            DGV_ActiveEmployeesInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_ActiveEmployeesInfo.AutoResizeColumns()
            DGV_ActiveEmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DGV_ActiveEmployeesInfo.DataSource = dt

            'Agregar columna editable de horas
            Dim colHoras As New DataGridViewTextBoxColumn

            colHoras.Name = "DREMPL_LHOUR"
            colHoras.HeaderText = "Cantidad de horas"
            colHoras.ValueType = GetType(Decimal)

            DGV_ActiveEmployeesInfo.Columns.Add(colHoras)

            'Configuración visual
            DGV_ActiveEmployeesInfo.Columns(0).ReadOnly = True
            DGV_ActiveEmployeesInfo.Columns(1).ReadOnly = True
            DGV_ActiveEmployeesInfo.Columns(2).ReadOnly = True
            DGV_ActiveEmployeesInfo.Columns(3).ReadOnly = True
            DGV_ActiveEmployeesInfo.Columns(4).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Validar que solo se capturen números
    Private Sub DGV_ActiveEmployeesInfo_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGV_ActiveEmployeesInfo.EditingControlShowing

        If DGV_ActiveEmployeesInfo.CurrentCell.ColumnIndex = 4 Then

            Dim txt As TextBox = CType(e.Control, TextBox)

            RemoveHandler txt.KeyPress, AddressOf OnlyDecimalNumbers
            AddHandler txt.KeyPress, AddressOf OnlyDecimalNumbers

        End If

    End Sub


    Private Sub OnlyDecimalNumbers(sender As Object, e As KeyPressEventArgs)

        If Not Char.IsDigit(e.KeyChar) AndAlso
           Not e.KeyChar = "." AndAlso
           Not e.KeyChar = Chr(8) Then

            e.Handled = True

        End If

    End Sub


    'Registrar horas
    Private Sub BT_LuchHoursRegister_Click(sender As Object, e As EventArgs) Handles BT_LuchHoursRegister.Click

        Try

            For Each row As DataGridViewRow In DGV_ActiveEmployeesInfo.Rows
                If row.IsNewRow Then Continue For
                If row.Cells("DREMPL_LHOUR").Value Is Nothing Then Continue For
                Dim hoursValue As Decimal

                If Decimal.TryParse(row.Cells("DREMPL_LHOUR").Value.ToString(), hoursValue) Then
                    If hoursValue <= 0 Then Continue For
                    Dim EMPL_ID As Integer = Convert.ToInt32(row.Cells(3).Value)
                    Dim NewRecordByEmployee As New CL_RecordsByEmployee()

                    NewRecordByEmployee.EMPL_ID = EMPL_ID
                    NewRecordByEmployee.MOVE_ID = MOVE_ID
                    NewRecordByEmployee.REMPL_CREBY = AppUser
                    NewRecordByEmployee.REMPL_RDATE = DateTime.Now
                    NewRecordByEmployee.DREMPL_DATE = DTP_DateLunchHours.Value.Date
                    NewRecordByEmployee.DREMPL_LHOUR = hoursValue
                    NewRecordByEmployee.InsertLunchHoursRecordByEmployee()
                End If
            Next

            MessageBox.Show("Horas registradas correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub DTP_DateLunchHours_Leave(sender As Object, e As EventArgs) Handles DTP_DateLunchHours.Leave
        BT_LuchHoursRegister.Enabled = True
    End Sub
End Class
