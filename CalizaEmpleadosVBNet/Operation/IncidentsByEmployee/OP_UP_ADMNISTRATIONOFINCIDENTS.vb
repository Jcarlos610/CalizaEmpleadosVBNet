Public Class OP_UP_ADMNISTRATIONOFINCIDENTS

    Private SelectedDREMPL_ID As Integer = 0
    Private SelectedEmployeeID As Integer = 0
    Private SelectedTipo As String = ""

    Private Sub OP_UP_ADMNISTRATIONOFINCIDENTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TB_Days.ReadOnly = True
        TB_InDays.ReadOnly = True
        TB_VacDays.ReadOnly = True

        LoadEmployees()
    End Sub

    Sub LoadEmployees()

        Dim obj As New CL_Incidents
        DGV_Employees.DataSource = obj.GetEmployeesWithIncidents()

        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        If DGV_Employees.Columns.Contains("INC_STAT") Then
            DGV_Employees.Columns("INC_STAT").Visible = False
        End If

    End Sub

    Private Sub DGV_Employees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Employees.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim row = DGV_Employees.Rows(e.RowIndex)

        SelectedEmployeeID = CInt(row.Cells("No. Empleado").Value)
        TB_EmployeeName.Text = row.Cells("Empleado").Value.ToString()

        LoadIncidentsByEmployee(SelectedEmployeeID)
        LoadEmployeeSummary()

    End Sub


    Sub LoadIncidentsByEmployee(ByVal EMPL_ID As Integer)

        Dim obj As New CL_Incidents
        Dim dt As DataTable = obj.GetIncidentsByEmployee(EMPL_ID)


        Dim dv As New DataView(dt)
        dv.RowFilter = "Estado = 'Generado'"

        DGV_Incidents.DataSource = dv

        If DGV_Incidents.Rows.Count > 0 Then
            DGV_Incidents.Rows(0).Selected = True
            LlenarFormulario(DGV_Incidents.Rows(0))
        End If

        FormatGridIncidents()

    End Sub

    Sub FormatGridIncidents()

        If DGV_Incidents.Columns.Count = 0 Then Exit Sub

        DGV_Incidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        If DGV_Incidents.Columns.Contains("EMPL_ID") Then
            DGV_Incidents.Columns("EMPL_ID").HeaderText = "No. Empleado"
        End If

        If DGV_Incidents.Columns.Contains("Empleado") Then
            DGV_Incidents.Columns("Empleado").HeaderText = "Empleado"
        End If

        If DGV_Incidents.Columns.Contains("FechaInicio") Then
            DGV_Incidents.Columns("FechaInicio").HeaderText = "Fecha Inicio"
        End If

        If DGV_Incidents.Columns.Contains("FechaFin") Then
            DGV_Incidents.Columns("FechaFin").HeaderText = "Fecha Fin"
        End If

        If DGV_Incidents.Columns.Contains("Dias") Then
            DGV_Incidents.Columns("Dias").HeaderText = "Días"
        End If

        If DGV_Incidents.Columns.Contains("Comentario") Then
            DGV_Incidents.Columns("Comentario").HeaderText = "Comentario"
        End If

        If DGV_Incidents.Columns.Contains("AutorizadoPor") Then
            DGV_Incidents.Columns("AutorizadoPor").HeaderText = "Autorizado por"
        End If

        If DGV_Incidents.Columns.Contains("Tipo") Then
            DGV_Incidents.Columns("Tipo").HeaderText = "Tipo"
        End If

        If DGV_Incidents.Columns.Contains("Estado") Then
            DGV_Incidents.Columns("Estado").HeaderText = "Estado"
        End If

        If DGV_Incidents.Columns.Contains("DREMPL_ID") Then
            DGV_Incidents.Columns("DREMPL_ID").Visible = False
        End If

        If DGV_Incidents.Columns.Contains("REMPL_ID") Then
            DGV_Incidents.Columns("REMPL_ID").Visible = False
        End If

        If DGV_Incidents.Columns.Contains("MOVE_ID") Then
            DGV_Incidents.Columns("MOVE_ID").Visible = False
        End If

    End Sub

    Private Sub DGV_Incidents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Incidents.CellClick

        If e.RowIndex < 0 Then Exit Sub

        LlenarFormulario(DGV_Incidents.Rows(e.RowIndex))

    End Sub

    Sub LlenarFormulario(ByVal row As DataGridViewRow)

        LimpiarTabs()
        Dim tipotab As String = row.Cells("Tipo").Value.ToString()
        SelectedTipo = tipotab

        If row.Cells("Tipo").Value Is Nothing Then Exit Sub

        Dim tipo As String = row.Cells("Tipo").Value.ToString()

        SelectedDREMPL_ID = CInt(row.Cells("DREMPL_ID").Value)

        Dim fechaInicio As Date = row.Cells("FechaInicio").Value
        Dim fechaFin As Date = row.Cells("FechaFin").Value
        Dim dias As Decimal = row.Cells("Dias").Value
        Dim comentario As String = row.Cells("Comentario").Value.ToString()
        Dim auth As String = row.Cells("AutorizadoPor").Value.ToString()

        TB_Incidents.SelectedIndex = 0

        Select Case tipo

            Case "Permiso con goce"
                TB_Incidents.SelectedTab = TabPaidLeave
                DTP_DateFrom.Value = fechaInicio
                DTP_DateTo.Value = fechaFin
                TB_Days.Text = dias
                TB_Comment.Text = comentario
                TB_AuthorizeBy.Text = auth

            Case "Permiso sin goce"
                TB_Incidents.SelectedTab = TabUnpaidLeave
                DTP_InDateFrom.Value = fechaInicio
                DTP_InDateTo.Value = fechaFin
                TB_InDays.Text = dias
                TB_InComment.Text = comentario
                TB_InAuthorizeBy.Text = auth

            Case "Vacaciones"
                TB_Incidents.SelectedTab = TabVacations
                DTP_VacDateFrom.Value = fechaInicio
                DTP_VacDateTo.Value = fechaFin
                TB_VacDays.Text = dias
                TB_VacComment.Text = comentario
                TB_VacAuthorizeBy.Text = auth

        End Select

    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        If SelectedDREMPL_ID = 0 Then
            MessageBox.Show("Selecciona un registro")
            Exit Sub
        End If

        Dim obj As New CL_Incidents

        obj.DREMPL_ID = SelectedDREMPL_ID

        obj.INC_DATEFR = DTP_DateFrom.Value
        obj.INC_DATETO = DTP_DateTo.Value
        obj.INC_DAYS = TB_Days.Text
        obj.INC_DESCR = TB_Comment.Text
        obj.INC_AUTH = TB_AuthorizeBy.Text

        If obj.UpdateIncident() Then
            MessageBox.Show("Registro actualizado")
            LoadIncidentsByEmployee(SelectedEmployeeID)
            LoadEmployeeSummary()
            LimpiarFormulario()
        End If
    End Sub

    Private Sub BT_InUpd_Click(sender As Object, e As EventArgs) Handles BT_InUpd.Click
        If SelectedDREMPL_ID = 0 Then
            MessageBox.Show("Selecciona un registro")
            Exit Sub
        End If

        Dim obj As New CL_Incidents

        obj.DREMPL_ID = SelectedDREMPL_ID

        obj.INC_DATEFR = DTP_InDateFrom.Value
        obj.INC_DATETO = DTP_InDateTo.Value
        obj.INC_DAYS = TB_InDays.Text
        obj.INC_DESCR = TB_InComment.Text
        obj.INC_AUTH = TB_InAuthorizeBy.Text

        If obj.UpdateIncident() Then
            MessageBox.Show("Registro actualizado")
            LoadIncidentsByEmployee(SelectedEmployeeID)
            LoadEmployeeSummary()
            LimpiarFormulario()
        End If
    End Sub

    Private Sub BT_VacUpd_Click(sender As Object, e As EventArgs) Handles BT_VacUpd.Click

        If SelectedDREMPL_ID = 0 Then
            MessageBox.Show("Selecciona un registro")
            Exit Sub
        End If

        Dim obj As New CL_Incidents

        obj.DREMPL_ID = SelectedDREMPL_ID
        obj.INC_DATEFR = DTP_VacDateFrom.Value
        obj.INC_DATETO = DTP_VacDateTo.Value
        obj.INC_DAYS = TB_VacDays.Text
        obj.INC_DESCR = TB_VacComment.Text
        obj.INC_AUTH = TB_VacAuthorizeBy.Text

        If obj.UpdateIncident() Then
            MessageBox.Show("Registro actualizado")
            LoadIncidentsByEmployee(SelectedEmployeeID)
            LoadEmployeeSummary()
            LimpiarFormulario()
        End If

    End Sub

    Sub UpdateData(f1 As Date, f2 As Date, dias As String, com As String, auth As String)

        If SelectedDREMPL_ID = 0 Then
            MessageBox.Show("Selecciona un registro")
            Exit Sub
        End If

        Dim obj As New CL_Incidents

        obj.DREMPL_ID = SelectedDREMPL_ID
        obj.INC_DATEFR = f1
        obj.INC_DATETO = f2
        obj.INC_DAYS = dias
        obj.INC_DESCR = com
        obj.INC_AUTH = auth

        If obj.UpdateIncident() Then
            MessageBox.Show("Registro actualizado")

            LoadIncidentsByEmployee(SelectedEmployeeID)
            LoadEmployeeSummary()
            LimpiarFormulario()
        End If

    End Sub

    Sub LimpiarFormulario()
        SelectedDREMPL_ID = 0
        LimpiarTabs()
    End Sub

    Sub LimpiarTabs()

        TB_Days.Text = ""
        TB_InDays.Text = ""
        TB_VacDays.Text = ""

        TB_Comment.Text = ""
        TB_InComment.Text = ""
        TB_VacComment.Text = ""

        TB_AuthorizeBy.Text = ""
        TB_InAuthorizeBy.Text = ""
        TB_VacAuthorizeBy.Text = ""

    End Sub

    Sub LoadEmployeeSummary()

        If SelectedEmployeeID = 0 Then Exit Sub

        Dim obj As New CL_Incidents
        Dim dt As DataTable = obj.GetEmployeeSummary(SelectedEmployeeID)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            Dim vac As Integer = If(IsDBNull(dt.Rows(0)("TotalVacaciones")), 0, dt.Rows(0)("TotalVacaciones"))
            Dim per As Integer = If(IsDBNull(dt.Rows(0)("TotalPermisos")), 0, dt.Rows(0)("TotalPermisos"))

            TB_TotalVacations.Text = "Vacaciones: " & vac & " días"
            TB_TotalPermissions.Text = "Permisos: " & per & " días"

        Else
            TB_TotalVacations.Text = "Vacaciones: 0 días"
            TB_TotalPermissions.Text = "Permisos: 0 días"
        End If

    End Sub

    Private Sub TB_Incidents_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TB_Incidents.Selecting

        If SelectedDREMPL_ID = 0 Then Exit Sub

        Dim tabName As String = e.TabPage.Text

        If tabName <> SelectedTipo Then

            MessageBox.Show("Este registro es de tipo: " & SelectedTipo, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            e.Cancel = True

        End If
    End Sub

    Function CalcularDiasSinFines(ByVal fechaInicio As Date, ByVal fechaFin As Date) As Integer

        Dim dias As Integer = 0
        Dim fecha As Date = fechaInicio

        While fecha <= fechaFin


            If fecha.DayOfWeek <> DayOfWeek.Saturday AndAlso fecha.DayOfWeek <> DayOfWeek.Sunday Then
                dias += 1
            End If

            fecha = fecha.AddDays(1)
        End While

        Return dias

    End Function

    Sub CalcularDias(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal txt As TextBox)

        If fechaFin < fechaInicio Then
            txt.Text = "0"
            Exit Sub
        End If

        Dim dias As Integer = CalcularDiasSinFines(fechaInicio, fechaFin)

        txt.Text = dias.ToString()

    End Sub


    'PERMISO CON GOCE
    Private Sub DTP_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DTP_DateFrom.ValueChanged
        CalcularDias(DTP_DateFrom.Value, DTP_DateTo.Value, TB_Days)
    End Sub

    Private Sub DTP_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DTP_DateTo.ValueChanged
        CalcularDias(DTP_DateFrom.Value, DTP_DateTo.Value, TB_Days)
    End Sub

    'PERMISO SIN GOCE
    Private Sub DTP_InDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DTP_InDateFrom.ValueChanged
        CalcularDias(DTP_InDateFrom.Value, DTP_InDateTo.Value, TB_InDays)
    End Sub

    Private Sub DTP_InDateTo_ValueChanged(sender As Object, e As EventArgs) Handles DTP_InDateTo.ValueChanged
        CalcularDias(DTP_InDateFrom.Value, DTP_InDateTo.Value, TB_InDays)
    End Sub

    'VACACIONES
    Private Sub DTP_VacDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DTP_VacDateFrom.ValueChanged
        CalcularDias(DTP_VacDateFrom.Value, DTP_VacDateTo.Value, TB_VacDays)
    End Sub

    Private Sub DTP_VacDateTo_ValueChanged(sender As Object, e As EventArgs) Handles DTP_VacDateTo.ValueChanged
        CalcularDias(DTP_VacDateFrom.Value, DTP_VacDateTo.Value, TB_VacDays)
    End Sub


End Class