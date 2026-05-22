Imports System.Data.Common
Imports Microsoft.Data.SqlClient

Public Class OP_UPD_GENERALMOVEMENTS

    Dim obj As New CL_RecordsByEmployee
    Private loading As Boolean = False
    Private AppUser As String = ""

    Dim obj1 As New CL_TemporalLunchTime
    Dim obj2 As New CL_EmployeeBanns

    Private Sub FRM_GeneralMovements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppUser = GlobalValues.AppUser
        DTP_StartDate.Value = DateTime.Now
        DTP_EndDate.Enabled = False
        DGV_ActiveEmployeesInfo.DataSource = Nothing
    End Sub

    Private Sub DTP_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DTP_StartDate.ValueChanged
        If loading Then Exit Sub

        RemoveHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged

        Dim fechaSeleccionada As Date = DTP_StartDate.Value
        Dim diasARestar As Integer = (CInt(fechaSeleccionada.DayOfWeek) - CInt(DayOfWeek.Thursday) + 7) Mod 7

        DTP_StartDate.Value = fechaSeleccionada.AddDays(-diasARestar).Date

        DTP_EndDate.Value = DTP_StartDate.Value.AddDays(6).Date.AddHours(23).AddMinutes(59).AddSeconds(59)

        AddHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged

        RefreshGridData()
    End Sub

    Private Sub SetWeekRange(selectedDate As Date)
        Dim daysToSubtract As Integer = (CInt(selectedDate.DayOfWeek) - CInt(DayOfWeek.Thursday) + 7) Mod 7
        Dim startThursday As Date = selectedDate.AddDays(-daysToSubtract).Date

        DTP_StartDate.Value = startThursday
        DTP_EndDate.Value = startThursday.AddDays(6).Date
        RefreshGridData()
    End Sub

    Private Sub RefreshGridData()
        Try
            Dim dt As DataTable = obj.GetGeneralMovementsByRange(DTP_StartDate.Value, DTP_EndDate.Value)

            If dt IsNot Nothing Then
                If dt.Columns.Contains("DREMPL_LHOUR") Then dt.Columns("DREMPL_LHOUR").ReadOnly = False
                If dt.Columns.Contains("DREMPL_TDAYS") Then dt.Columns("DREMPL_TDAYS").ReadOnly = False
                If dt.Columns.Contains("DREMPL_AMOUNT") Then dt.Columns("DREMPL_AMOUNT").ReadOnly = False
                If dt.Columns.Contains("OBSERVACIONES") Then dt.Columns("OBSERVACIONES").ReadOnly = False

                FormatGrid(dt)
            Else
                MessageBox.Show("La consulta no devolvió ninguna estructura de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar la información: " & ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid(dt As DataTable)
        DGV_ActiveEmployeesInfo.DataSource = dt

        With DGV_ActiveEmployeesInfo
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            .EnableHeadersVisualStyles = True
            .RowHeadersVisible = True

            For Each col As DataGridViewColumn In .Columns
                col.ReadOnly = True
            Next


            If .Columns.Contains("ID Empresa") Then .Columns("ID Empresa").Visible = True
            If .Columns.Contains("Empresa") Then .Columns("Empresa").HeaderText = "Empresa"
            If .Columns.Contains("No.") Then .Columns("No.").HeaderText = "No. Emp"
            If .Columns.Contains("Empleado") Then .Columns("Empleado").HeaderText = "Nombre Completo"
            If .Columns.Contains("Departamento") Then .Columns("Departamento").HeaderText = "Departamento"
            If .Columns.Contains("Beneficio Comida") Then .Columns("Beneficio Comida").HeaderText = "Beneficio Comida"
            If .Columns.Contains("DREMPL_LHOUR") Then
                .Columns("DREMPL_LHOUR").ReadOnly = False
                .Columns("DREMPL_LHOUR").HeaderText = "Horas Comida"
                .Columns("DREMPL_LHOUR").DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow
            End If

            If .Columns.Contains("DREMPL_BQUANT") Then
                .Columns("DREMPL_BQUANT").ReadOnly = True
                .Columns("DREMPL_BQUANT").HeaderText = "Días de Amonestaciones"
                .Columns("DREMPL_BQUANT").DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
            End If

            If .Columns.Contains("Beneficio Transporte") Then .Columns("Beneficio Transporte").HeaderText = "Beneficio Transporte"

            If .Columns.Contains("DREMPL_TDAYS") Then
                .Columns("DREMPL_TDAYS").ReadOnly = False
                .Columns("DREMPL_TDAYS").HeaderText = "Días Transporte"
                .Columns("DREMPL_TDAYS").DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew
            End If

            If .Columns.Contains("DREMPL_AMOUNT") Then
                .Columns("DREMPL_AMOUNT").ReadOnly = False
                .Columns("DREMPL_AMOUNT").HeaderText = "Transporte entre Empleados"
                .Columns("DREMPL_AMOUNT").DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew
                .Columns("DREMPL_AMOUNT").DefaultCellStyle.Format = "C2"
            End If

            If .Columns.Contains("OBSERVACIONES") Then
                .Columns("OBSERVACIONES").ReadOnly = False
                .Columns("OBSERVACIONES").HeaderText = "Observaciones"
            End If

            Dim hiddenCols As String() = {"TEMP_LUNCH_ID", "COMM_ID", "REMPL_ID_COMM"}
            For Each h In hiddenCols
                If .Columns.Contains(h) Then .Columns(h).Visible = False
            Next
        End With
    End Sub

    Private Function GetSafeInt(row As DataGridViewRow, col As String) As Integer
        If Not row.DataGridView.Columns.Contains(col) Then Return 0
        Dim val = row.Cells(col).Value
        Return If(val Is Nothing OrElse IsDBNull(val), 0, Convert.ToInt32(val))
    End Function

    Private Function GetSafeDecimal(row As DataGridViewRow, col As String) As Decimal
        If Not row.DataGridView.Columns.Contains(col) Then Return 0
        Dim val = row.Cells(col).Value
        Return If(val Is Nothing OrElse IsDBNull(val), 0D, Convert.ToDecimal(val))
    End Function


    'Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
    '    Try
    '        DGV_ActiveEmployeesInfo.EndEdit()

    '        Dim startDate As Date = DTP_StartDate.Value.Date
    '        Dim endDate As Date = DTP_EndDate.Value.Date

    '        For Each row As DataGridViewRow In DGV_ActiveEmployeesInfo.Rows
    '            If row.IsNewRow Then Continue For

    '            Dim emplId As Integer = Convert.ToInt32(row.Cells("No.").Value)

    '            Dim lunchId As Integer = GetSafeInt(row, "TEMP_LUNCH_ID")
    '            Dim lunchHours As Decimal = GetSafeDecimal(row, "DREMPL_LHOUR")

    '            If lunchHours > 5 Then
    '                MessageBox.Show("Las horas comida no pueden ser mayores a 5 en el empleado No. " & emplId.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Continue For
    '            End If

    '            If lunchHours > 0 Then
    '                If lunchId > 0 Then
    '                    obj1.LUNCH_HOURS = lunchHours
    '                    obj1.LUNCH_DATE = startDate
    '                    obj1.LUNCH_CREBY = AppUser
    '                    obj1.UpdateTemporalLunch(lunchId)
    '                Else
    '                    obj1.EMPL_ID = emplId
    '                    obj1.LUNCH_DATE = startDate
    '                    obj1.LUNCH_HOURS = lunchHours
    '                    obj1.LUNCH_CREBY = AppUser
    '                    obj1.InsertTemporalLunch()
    '                End If

    '                obj.InsertLunchHoursRecordByEmployeeDirect(emplId, startDate, startDate, lunchHours, AppUser)
    '            End If

    '            Dim diasTransporte As Decimal = 0D
    '            Dim montoTransporte As Decimal = 0D

    '            If row.Cells("DREMPL_TDAYS").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DREMPL_TDAYS").Value) Then
    '                Decimal.TryParse(row.Cells("DREMPL_TDAYS").Value.ToString(), diasTransporte)
    '            End If

    '            If row.Cells("DREMPL_AMOUNT").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DREMPL_AMOUNT").Value) Then
    '                Dim txtMonto As String = row.Cells("DREMPL_AMOUNT").Value.ToString().Replace("$", "").Trim()
    '                Decimal.TryParse(txtMonto, montoTransporte)
    '            End If

    '            If diasTransporte > 0 Then
    '                obj.ProcessTransportMovement(emplId, 285, startDate, diasTransporte, 0D, AppUser)
    '            End If

    '            If montoTransporte > 0 Then
    '                obj.ProcessTransportMovement(emplId, 280, startDate, 0D, montoTransporte, AppUser)
    '            End If


    '            If row.Cells("OBSERVACIONES").Value IsNot Nothing Then
    '                Dim comentario As String = row.Cells("OBSERVACIONES").Value.ToString().Trim()
    '                Dim commId As Integer = GetSafeInt(row, "COMM_ID")
    '                Dim remplIdComm As Integer = GetSafeInt(row, "REMPL_ID_COMM")

    '                If comentario <> "" Then
    '                    If commId > 0 Then
    '                        obj.UpdateGeneralComment(commId, comentario)
    '                    Else
    '                        If remplIdComm > 0 Then
    '                            obj.InsertGeneralComment(remplIdComm, comentario, AppUser, startDate)
    '                        Else
    '                            If lunchHours > 0 Then
    '                                obj.InsertLunchHoursRecordByEmployeeDirect(emplId, startDate, startDate, lunchHours, AppUser)
    '                            Else
    '                                obj.ProcessTransportMovement(emplId, 285, startDate, diasTransporte, montoTransporte, AppUser)
    '                            End If

    '                            Dim dtAux As DataTable = obj.GetGeneralMovementsByRange(startDate, endDate)
    '                            Dim filaFiltro = dtAux.Select("[No.] = " & emplId)
    '                            If filaFiltro.Length > 0 Then
    '                                Dim nuevoRemplId As Integer = Convert.ToInt32(filaFiltro(0)("REMPL_ID_COMM"))
    '                                obj.InsertGeneralComment(nuevoRemplId, comentario, AppUser, startDate)
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        Next

    '        ProcesarHorasOficiales()

    '        MessageBox.Show("¡Registros validados y actualizados correctamente en el sistema!", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        RefreshGridData()

    '    Catch ex As Exception
    '        MessageBox.Show("Error durante la actualización: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
        Try
            DGV_ActiveEmployeesInfo.EndEdit()

            Dim startDate As Date = DTP_StartDate.Value.Date
            Dim endDate As Date = DTP_EndDate.Value.Date

            Dim empleadosProcesados As Integer = 0
            Dim totalComidas As Integer = 0
            Dim totalTransportes As Integer = 0
            Dim totalComentarios As Integer = 0

            For Each row As DataGridViewRow In DGV_ActiveEmployeesInfo.Rows
                If row.IsNewRow Then Continue For

                Dim emplId As Integer = Convert.ToInt32(row.Cells("No.").Value)
                Dim huboMovimientoEmpleado As Boolean = False

                Dim lunchId As Integer = GetSafeInt(row, "TEMP_LUNCH_ID")
                Dim lunchHours As Decimal = GetSafeDecimal(row, "DREMPL_LHOUR")

                If lunchHours > 5 Then
                    MessageBox.Show($"Las horas comida no pueden ser mayores a 5 en el empleado No. {emplId}.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Continue For
                End If

                If lunchHours > 0 Then
                    huboMovimientoEmpleado = True
                    totalComidas += 1

                    If lunchId > 0 Then
                        obj1.LUNCH_HOURS = lunchHours
                        obj1.LUNCH_DATE = startDate
                        obj1.LUNCH_CREBY = GlobalSession.GlobalUserName
                        obj1.UpdateTemporalLunch(lunchId)
                    Else
                        obj1.EMPL_ID = emplId
                        obj1.LUNCH_DATE = startDate
                        obj1.LUNCH_HOURS = lunchHours
                        obj1.LUNCH_CREBY = GlobalSession.GlobalUserName
                        obj1.InsertTemporalLunch()
                    End If

                    obj.InsertLunchHoursRecordByEmployeeDirect(emplId, startDate, startDate, lunchHours, GlobalSession.GlobalUserName) ' 🌟 Actualizado
                End If

                Dim diasTransporte As Decimal = 0D
                Dim montoTransporte As Decimal = 0D

                If row.Cells("DREMPL_TDAYS").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DREMPL_TDAYS").Value) Then
                    Decimal.TryParse(row.Cells("DREMPL_TDAYS").Value.ToString(), diasTransporte)
                End If

                If row.Cells("DREMPL_AMOUNT").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DREMPL_AMOUNT").Value) Then
                    Dim txtMonto As String = row.Cells("DREMPL_AMOUNT").Value.ToString().Replace("$", "").Trim()
                    Decimal.TryParse(txtMonto, montoTransporte)
                End If

                If diasTransporte > 0 Then
                    huboMovimientoEmpleado = True
                    totalTransportes += 1
                    obj.ProcessTransportMovement(emplId, 285, startDate, diasTransporte, 0D, GlobalSession.GlobalUserName)
                End If

                If montoTransporte > 0 Then
                    huboMovimientoEmpleado = True
                    If diasTransporte = 0 Then totalTransportes += 1
                    obj.ProcessTransportMovement(emplId, 280, startDate, 0D, montoTransporte, GlobalSession.GlobalUserName)
                End If

                If row.Cells("OBSERVACIONES").Value IsNot Nothing Then
                    Dim comentario As String = row.Cells("OBSERVACIONES").Value.ToString().Trim()
                    Dim commId As Integer = GetSafeInt(row, "COMM_ID")
                    Dim remplIdComm As Integer = GetSafeInt(row, "REMPL_ID_COMM")

                    If comentario <> "" Then
                        huboMovimientoEmpleado = True
                        totalComentarios += 1

                        If commId > 0 Then
                            obj.UpdateGeneralComment(commId, comentario)
                        Else
                            If remplIdComm > 0 Then
                                obj.InsertGeneralComment(remplIdComm, comentario, GlobalSession.GlobalUserName, startDate)
                            Else
                                If lunchHours > 0 Then
                                    obj.InsertLunchHoursRecordByEmployeeDirect(emplId, startDate, startDate, lunchHours, GlobalSession.GlobalUserName)
                                Else
                                    obj.ProcessTransportMovement(emplId, 285, startDate, diasTransporte, montoTransporte, GlobalSession.GlobalUserName)
                                End If

                                Dim dtAux As DataTable = obj.GetGeneralMovementsByRange(startDate, endDate)
                                Dim filaFiltro = dtAux.Select("[No.] = " & emplId)
                                If filaFiltro.Length > 0 Then
                                    Dim nuevoRemplId As Integer = Convert.ToInt32(filaFiltro(0)("REMPL_ID_COMM"))
                                    obj.InsertGeneralComment(nuevoRemplId, comentario, GlobalSession.GlobalUserName, startDate)
                                End If
                            End If
                        End If
                    End If
                End If

                If huboMovimientoEmpleado Then
                    empleadosProcesados += 1
                End If
            Next

            ProcesarHorasOficiales()

            'LOG DE ÉXITO 
            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim descLog As String = $"PROCESAMIENTO DIARIO DE PRENOMINA: Se validaron y actualizaron movimientos para el rango [{startDate:dd/MM/yyyy} - {endDate:dd/MM/yyyy}]. " &
                               $"Resumen de afectaciones -> Empleados con cambios: {empleadosProcesados} | Registros de Comida: {totalComidas} | Movimientos de Transporte: {totalTransportes} | Comentarios Guardados: {totalComentarios}."

            InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Prenomina", "PROCESS_DAILY_MOVEMENTS_SUCCESS", descLog, 0, "INFO")

            MessageBox.Show("¡Registros validados y actualizados correctamente en el sistema!", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

            RefreshGridData()

        Catch ex As Exception
            'LOG DE ERROR 
            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim descError As String = $"ERROR CRÍTICO: Falló la ejecución masiva de preclaudicación/actualización de incidencias diarias. Motivo: {ex.Message}"

            InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Prenomina", "ERROR_DAILY_MOVEMENTS", descError, 0, "ERROR", ex.StackTrace)

            MessageBox.Show("Error inesperado durante la actualización masiva: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub ProcesarHorasOficiales()
        Try
            Dim migrationSuccess As Boolean = obj.MigrateTemporalLunchToOfficial(DTP_StartDate.Value.Date, DTP_EndDate.Value.Date, AppUser)

            'If migrationSuccess Then
            '    MessageBox.Show("¡Las horas de comida se transfirieron a la tabla oficial exitosamente!", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Se guardaron los datos en pantalla, pero hubo un detalle al sincronizar las horas oficiales.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
        Catch ex As Exception
            MessageBox.Show("Error al migrar datos a través del objeto de negocio: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
