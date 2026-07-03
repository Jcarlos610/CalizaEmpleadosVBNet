Imports DocumentFormat.OpenXml.Bibliography
Imports Microsoft.Data.SqlClient

Public Class OP_ADMNISTRATIONOFINCIDENTS

    Private SelectedEmployeeID As Integer = 0

    Private Sub OP_ADMNISTRATIONOFINCIDENTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializationOfFields()
        LoadIncidents()
    End Sub

    Private Sub InitializationOfFields()

        TB_Days.Text = ""
        TB_InDays.Text = ""
        TB_VacDays.Text = ""
        TB_EmployeeId.Text = ""
        TB_Comment.Text = ""
        TB_InComment.Text = ""
        TB_VacComment.Text = ""

        TB_AuthorizeBy.Text = ""
        TB_InAuthorizeBy.Text = ""
        TB_VacAuthorizeBy.Text = ""

        DTP_DateFrom.Value = Date.Today
        DTP_DateTo.Value = Date.Today

        DTP_InDateFrom.Value = Date.Today
        DTP_InDateTo.Value = Date.Today

        DTP_VacDateFrom.Value = Date.Today
        DTP_VacDateTo.Value = Date.Today

        TB_Days.ReadOnly = True
        TB_InDays.ReadOnly = True
        TB_VacDays.ReadOnly = True

        TB_EmployeeName.ReadOnly = True
        TB_TotalPermissions.ReadOnly = True
        TB_TotalVacations.ReadOnly = True

        LoadEmployees()

    End Sub

    Private Sub LoadEmployees()
        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Employees.AutoResizeColumns()
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Dim obj As New CL_Incidents
        DGV_Employees.DataSource = obj.GetAllEmployeesInfo()
    End Sub

    'REGISTRAR CON GOCE
    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If SelectedEmployeeID = 0 Then
            MessageBox.Show("Debes seleccionar un empleado de la lista antes de continuar.", "Aviso de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Por favor, ingrese el nombre de la persona que autoriza este permiso.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim Result As Boolean = InsertIncident(
            SelectedEmployeeID,
            500,
            DTP_DateFrom.Value,
            DTP_DateTo.Value,
            TB_Comment.Text,
            TB_AuthorizeBy.Text
        )

            If Result Then

                'Log
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim desc As String = $"REGISTRO INCIDENCIA EXITOSO: Se asignó un Permiso CON GOCE DE SUELDO (Código: 500) al Empleado ID: {SelectedEmployeeID}. Período: del {DTP_DateFrom.Value.ToShortDateString()} al {DTP_DateTo.Value.ToShortDateString()}. Autorizado por: '{TB_AuthorizeBy.Text.Trim()}'. Comentarios: '{TB_Comment.Text.Trim()}'."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Incidencias", "INSERT_INCIDENT_WITH_PAY_SUCCESS", desc, SelectedEmployeeID, "INFO")
                End Using

                MessageBox.Show("Permiso con goce registrado para el empleado: " & TB_EmployeeName.Text,
                "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadIncidents()
                InitializationOfFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la inserción de Permiso Con Goce (Código: 500) para el Empleado ID: {SelectedEmployeeID}. Motivo del sistema: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Incidencias", "ERROR_INSERT_INCIDENT_WITH_PAY", descError, SelectedEmployeeID, "ERROR", ex.StackTrace)
            End Using
            MessageBox.Show("Ocurrió un error inesperado al intentar registrar el permiso con goce en el servidor: " & ex.Message, "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'REGISTRAR SIN GOCE
    Private Sub BT_InRegister_Click(sender As Object, e As EventArgs) Handles BT_InRegister.Click
        If SelectedEmployeeID = 0 Then
            MessageBox.Show("Debes seleccionar un empleado de la lista antes de continuar.", "Aviso de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TB_InAuthorizeBy.Text = "" Then
            MessageBox.Show("Por favor, ingrese el nombre de la persona que autoriza este permiso sin goce.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim Result As Boolean = InsertIncident(
            SelectedEmployeeID,
            510,
            DTP_InDateFrom.Value,
            DTP_InDateTo.Value,
            TB_InComment.Text,
            TB_InAuthorizeBy.Text
            )

            If Result Then
                'LOG
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim desc As String = $"REGISTRO INCIDENCIA EXITOSO: Se asignó un Permiso SIN GOCE DE SUELDO (Código: 510) al Empleado ID: {SelectedEmployeeID}. Período: del {DTP_InDateFrom.Value.ToShortDateString()} al {DTP_InDateTo.Value.ToShortDateString()}. Autorizado por: '{TB_InAuthorizeBy.Text.Trim()}'. Comentarios: '{TB_InComment.Text.Trim()}'."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Incidencias", "INSERT_INCIDENT_WITHOUT_PAY_SUCCESS", desc, SelectedEmployeeID, "INFO")
                End Using

                MessageBox.Show("Permiso sin goce registrado para el empleado: " & TB_EmployeeName.Text,
                    "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadIncidents()
                InitializationOfFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la inserción de Permiso Sin Goce (Código: 510) para el Empleado ID: {SelectedEmployeeID}. Motivo del sistema: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Incidencias", "ERROR_INSERT_INCIDENT_WITHOUT_PAY", descError, SelectedEmployeeID, "ERROR", ex.StackTrace)
            End Using
            MessageBox.Show("Ocurrió un error inesperado al intentar registrar el permiso sin goce en el servidor: " & ex.Message, "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'REGISTRAR VACACIONES
    Private Sub BT_VacRegister_Click(sender As Object, e As EventArgs) Handles BT_VacRegister.Click
        If SelectedEmployeeID = 0 Then
            MessageBox.Show("Debes seleccionar un empleado de la lista antes de continuar.", "Aviso de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TB_VacAuthorizeBy.Text = "" Then
            MessageBox.Show("Por favor, ingrese el nombre de la persona que autoriza el período vacacional.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Try
            Dim Result As Boolean = InsertIncident(
            SelectedEmployeeID,
            520,
            DTP_VacDateFrom.Value,
            DTP_VacDateTo.Value,
            TB_VacComment.Text,
            TB_VacAuthorizeBy.Text
        )

            If Result Then
                'LOG
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim desc As String = $"REGISTRO INCIDENCIA EXITOSO: Se asignaron VACACIONES (Código: 520) al Empleado ID: {SelectedEmployeeID}. Período: del {DTP_VacDateFrom.Value.ToShortDateString()} al {DTP_VacDateTo.Value.ToShortDateString()}. Autorizado por: '{TB_VacAuthorizeBy.Text.Trim()}'. Comentarios: '{TB_VacComment.Text.Trim()}'."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Incidencias", "INSERT_INCIDENT_VACATION_SUCCESS", desc, SelectedEmployeeID, "INFO")
                End Using

                MessageBox.Show("Vacaciones registradas para el empleado: " & TB_EmployeeName.Text,
                    "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadIncidents()
                InitializationOfFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la inserción de Vacaciones (Código: 520) para el Empleado ID: {SelectedEmployeeID}. Motivo del sistema: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Incidencias", "ERROR_INSERT_INCIDENT_VACATION", descError, SelectedEmployeeID, "ERROR", ex.StackTrace)
            End Using
            MessageBox.Show("Ocurrió un error inesperado al intentar guardar el período vacacional en el servidor: " & ex.Message, "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function InsertIncident(
    EMPL_ID As Integer,
    MOVE_ID As Integer,
    FechaInicio As Date,
    FechaFin As Date,
    Comentario As String,
    Autorizado As String
) As Boolean

        Dim Result As Boolean = False

        Dim dias As Decimal = 0

        Select Case MOVE_ID
            Case 500 'Con goce
                dias = Convert.ToDecimal(TB_Days.Text)
            Case 510 'Sin goce
                dias = Convert.ToDecimal(TB_InDays.Text)
            Case 520 'Vacaciones
                dias = Convert.ToDecimal(TB_VacDays.Text)
        End Select

        'VALIDAR PERMISOS DUPLICADOS
        If MOVE_ID = 500 Or MOVE_ID = 510 Or MOVE_ID = 520 Then

            Dim valida As New CL_Incidents

            If valida.ExistePermisoMismoDia(EMPL_ID, FechaInicio, FechaFin) Then
                MessageBox.Show("Ya existe un permiso en ese rango de fechas para este empleado",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

        End If

        Dim obj As New CL_Incidents

        obj.EMPL_ID = EMPL_ID
        obj.MOVE_ID = MOVE_ID
        obj.REMPL_CREBY = AppUser
        obj.REMPL_RDATE = Date.Now

        obj.INC_DATEFR = FechaInicio
        obj.INC_DATETO = FechaFin
        obj.INC_DAYS = dias
        obj.INC_DESCR = Comentario
        obj.INC_AUTH = Autorizado
        obj.INC_STAT = 1

        Result = obj.InsertIncident()

        Return Result

    End Function


    'Function CalcularDiasSinFines(ByVal fechaInicio As Date, ByVal fechaFin As Date) As Integer

    '    Dim dias As Integer = 0
    '    Dim fecha As Date = fechaInicio

    '    While fecha <= fechaFin


    '        If fecha.DayOfWeek <> DayOfWeek.Saturday AndAlso fecha.DayOfWeek <> DayOfWeek.Sunday Then
    '            dias += 1
    '        End If

    '        fecha = fecha.AddDays(1)
    '    End While

    '    Return dias

    'End Function

    Function CalcularDiasSinFines(ByVal fechaInicio As Date, ByVal fechaFin As Date) As Integer
        Dim dias As Integer = 0
        Dim fecha As Date = fechaInicio

        While fecha <= fechaFin

            If fecha.DayOfWeek <> DayOfWeek.Sunday Then
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


    Sub LoadIncidents()

        If SelectedEmployeeID = 0 Then
            DGV_Incidents.DataSource = Nothing
            Exit Sub
        End If

        Dim obj As New CL_Incidents


        DGV_Incidents.DataSource = Nothing
        DGV_Incidents.Columns.Clear()


        If CHK_LastOnly.Checked Then
            DGV_Incidents.DataSource = obj.GetLastIncidentByEmployee(SelectedEmployeeID)
        Else
            DGV_Incidents.DataSource = obj.GetIncidentsByEmployee(SelectedEmployeeID)
        End If


        DGV_Incidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Incidents.AutoResizeColumns()
        DGV_Incidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing


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

        If DGV_Incidents.Columns.Contains("Estado") Then
            DGV_Incidents.Columns("Estado").HeaderText = "Estado"
        End If


        If DGV_Incidents.Columns.Contains("REMPL_ID") Then
            DGV_Incidents.Columns("REMPL_ID").Visible = False
        End If

        If DGV_Incidents.Columns.Contains("DREMPL_ID") Then
            DGV_Incidents.Columns("DREMPL_ID").Visible = False
        End If

        If DGV_Incidents.Columns.Contains("MOVE_ID") Then
            DGV_Incidents.Columns("MOVE_ID").Visible = False
        End If

        If Not DGV_Incidents.Columns.Contains("Cancelar") Then
            Dim btn As New DataGridViewButtonColumn()
            btn.Name = "Cancelar"
            btn.HeaderText = "Acción"
            btn.Text = "Cancelar"
            btn.UseColumnTextForButtonValue = True

            DGV_Incidents.Columns.Add(btn)
        End If

    End Sub

    Private Sub BT_Search_Click(sender As Object, e As EventArgs) Handles BT_Search.Click
        Dim report As New CL_Employee()
        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Employees.AutoResizeColumns()
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Employees.DataSource = report.Get_EmployeesInfoByID(TB_EmployeeId.Text)
    End Sub

    Private Sub BT_Refresh_Click(sender As Object, e As EventArgs) Handles BT_Refresh.Click
        Dim report As New CL_Employee()

        DGV_Employees.DataSource = report.Get_AllEmployeesAllDepartments()
    End Sub

    'Private Sub DGV_Employees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Employees.CellClick
    '    If e.RowIndex < 0 Then Exit Sub

    '    Dim row = DGV_Employees.Rows(e.RowIndex)

    '    SelectedEmployeeID = CInt(row.Cells(0).Value)


    '    TB_EmployeeId.Text = SelectedEmployeeID.ToString()

    '    TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()

    '    LoadIncidents()
    '    LoadEmployeeSummary()
    'End Sub

    Private Sub DGV_Employees_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Employees.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_Employees.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Employees.Rows(hit.RowIndex)

                SelectedEmployeeID = CInt(row.Cells(0).Value)
                TB_EmployeeId.Text = SelectedEmployeeID.ToString()
                TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()

                LoadIncidents()
                LoadEmployeeSummary()

            Catch ex As Exception
                MsgBox("Error al seleccionar el empleado: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Sub LoadEmployeeSummary()

        Dim obj As New CL_Incidents
        Dim dt As DataTable = obj.GetEmployeeSummary(SelectedEmployeeID)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            Dim vac As Integer = If(IsDBNull(dt.Rows(0)("TotalVacaciones")), 0, dt.Rows(0)("TotalVacaciones"))
            Dim per As Integer = If(IsDBNull(dt.Rows(0)("TotalPermisos")), 0, dt.Rows(0)("TotalPermisos"))

            TB_TotalVacations.Text = "Vacaciones: " & vac & " días"
            TB_TotalPermissions.Text = "Permisos: " & per & " días"

        Else
            TB_TotalVacations.Text = "0"
            TB_TotalPermissions.Text = "0"
        End If

    End Sub

    'Private Sub DGV_Incidents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Incidents.CellClick

    '    If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub

    '    If DGV_Incidents.Columns(e.ColumnIndex).Name = "Cancelar" Then

    '        Dim estado As String = DGV_Incidents.Rows(e.RowIndex).Cells("Estado").Value.ToString()

    '        If estado = "Cancelado" Then
    '            MessageBox.Show("Este registro ya está cancelado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If

    '        Dim id As Integer = CInt(DGV_Incidents.Rows(e.RowIndex).Cells("REMPL_ID").Value)

    '        Dim confirm = MessageBox.Show("¿Deseas cancelar este registro?", "Confirmar",
    '                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '        If confirm = DialogResult.Yes Then

    '            Dim obj As New CL_Incidents

    '            If obj.CancelIncident(id) Then
    '                MessageBox.Show("Registro cancelado correctamente")
    '                LoadIncidents()
    '            End If

    '        End If

    '    End If

    'End Sub

    Private Sub DGV_Incidents_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Incidents.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_Incidents.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.Cell Then
            Try
                If DGV_Incidents.Columns(hit.ColumnIndex).Name = "Cancelar" Then
                    Dim row As DataGridViewRow = DGV_Incidents.Rows(hit.RowIndex)
                    Dim estado As String = row.Cells("Estado").Value.ToString()

                    If estado = "Cancelado" Then
                        MessageBox.Show("Este registro ya está cancelado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    Dim id As Integer = CInt(row.Cells("REMPL_ID").Value)

                    Dim confirm = MessageBox.Show("¿Deseas cancelar este registro?", "Confirmar",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If confirm = DialogResult.Yes Then
                        Dim obj As New CL_Incidents

                        If obj.CancelIncident(id) Then
                            MessageBox.Show("Registro cancelado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadIncidents()
                        End If
                    End If
                End If

            Catch ex As Exception
                MsgBox("Error al procesar la acción: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub CHK_LastOnly_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_LastOnly.CheckedChanged
        LoadIncidents()
    End Sub
End Class