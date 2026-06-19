Imports System.IO
Imports Microsoft.Data.SqlClient

Public Class OP_INS_TIMERECORDSMANUALLY
    Private SelectedEmployeeID As Integer = 0

    Private Sub OP_INS_TIMERECORDSMANUALLY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()
        BT_AsistanceRegister.Enabled = False
        BT_UpdateDateTime.Enabled = False
        BT_EarlyExitRegister.Enabled = False

        DTP_ManualDelay.Format = DateTimePickerFormat.Custom
        DTP_ManualDelay.CustomFormat = "dddd , dd 'de' MMMM 'de' yyyy  HH:mm"

        DTP_EarlyExit.Format = DateTimePickerFormat.Custom
        DTP_EarlyExit.CustomFormat = "dddd , dd 'de' MMMM 'de' yyyy  HH:mm"

        TB_AbsenceReason.Text = ""
        TB_DelayComment.Text = ""
        TB_EarlyExitComment.Text = ""

        DTP_ManualAsistance.Value = Date.Today
        DTP_ManualDelay.Value = Date.Now
        DTP_EarlyExit.Value = Date.Now

        Display_Record()

    End Sub

    Private Sub Display_Record()

        Dim report As New CL_Employee()
        Dim table As DataTable = report.Get_AllEmployeesAllDepartments()

        If table IsNot Nothing Then
            DGV_AllEmployees.DataSource = table
        End If


        DGV_AllEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_AllEmployees.AutoResizeColumns()

    End Sub

    Private Sub DGV_AllEmployees_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_AllEmployees.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_AllEmployees.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_AllEmployees.Rows(hit.RowIndex)

                If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value IsNot System.DBNull.Value Then
                    SelectedEmployeeID = Convert.ToInt32(row.Cells(0).Value)
                    TB_EmployeeId.Text = SelectedEmployeeID.ToString()
                Else
                    SelectedEmployeeID = 0
                    TB_EmployeeId.Text = ""
                End If

                If row.Cells.Count > 1 AndAlso row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value IsNot System.DBNull.Value Then
                    TB_EmployeeName.Text = row.Cells(1).Value.ToString()
                Else
                    TB_EmployeeName.Text = "SIN NOMBRE"
                End If

            Catch ex As Exception
                MsgBox("Error al seleccionar el registro del Grid: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
            End Try
        End If
    End Sub

    Private Sub BT_EarlyExitRegister_Click(sender As Object, e As EventArgs) Handles BT_EarlyExitRegister.Click
        Try
            Dim Result As Boolean = False
            Dim MovementID As Integer = 515 ' Permiso salida anticipada
            Dim ExitDateTime As DateTime = DTP_EarlyExit.Value
            Dim Comment As String = TB_EarlyExitComment.Text.Trim()

            If SelectedEmployeeID = 0 Then
                MessageBox.Show("Por favor, seleccione un empleado de la tabla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(Comment) Then
                MessageBox.Show("Es necesario que indique la razón o motivo de la salida anticipada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Result = InsertManualEarlyExitRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_EarlyExit.Value.Date, ExitDateTime, Comment)

            If Result Then
                'LOG
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"REGISTRO MANUAL - SALIDA ANTICIPADA (MOV_515): Empleado ID: {SelectedEmployeeID} ({TB_EmployeeName.Text}). Fecha/Hora Salida: {ExitDateTime}. Motivo: '{Comment}'."
                    InsertLog(connTmp, AppUser, "OP_AsistenciasManuales", "INSERT_EARLY_EXIT_SUCCESS", descLog, SelectedEmployeeID, "INFO")
                End Using

                MessageBox.Show("Permiso de salida anticipada registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Display_ManualEarlyExitRecord()
                InitializationOfFields()
            End If

        Catch ex As Exception
            'Log de rror
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló el registro manual de salida anticipada para Empleado ID: {SelectedEmployeeID}. Motivo: {ex.Message}"
                InsertLog(connTmp, AppUser, "OP_AsistenciasManuales", "ERROR_INSERT_EARLY_EXIT", descError, SelectedEmployeeID, "ERROR", ex.StackTrace)
            End Using

            MsgBox("Ocurrió un error inesperado al registrar la salida anticipada: " & ex.Message, MsgBoxStyle.Critical, "Error Crítico")
        End Try
    End Sub

    Private Function InsertManualEarlyExitRecord(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_EXDATI As DateTime, ByVal DREMPL_COME As String) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        NewRecordByEmployee.DREMPL_COME = DREMPL_COME

        Result = NewRecordByEmployee.InsertEarlyExitRecordByEmployee()

        Return Result
    End Function

    Private Sub Display_ManualEarlyExitRecord()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()

        DGV_DisplayInformation.DataSource = RecordsByEmployees.Get_ManualAsistanceRecord(SelectedEmployeeID, DTP_EarlyExit.Value, 515)

        If DGV_DisplayInformation.Columns.Contains("Movimiento") Then
            DGV_DisplayInformation.Columns("Movimiento").Visible = False
        End If

        DGV_DisplayInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DisplayInformation.AutoResizeColumns()
        DGV_DisplayInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    End Sub


    Private Sub BT_AsistanceRegister_Click(sender As Object, e As EventArgs) Handles BT_AsistanceRegister.Click
        Try

            Dim Result = False
            Dim MovementID = 130 ' Jornada Completa - Manual
            Dim EntryDateTime = DTP_ManualAsistance.Value.Date.AddHours(7)
            Dim ExitDateTime = DTP_ManualAsistance.Value.Date.AddHours(17.5)
            Dim SaturdayExitDateTime = DTP_ManualAsistance.Value.Date.AddHours(13.5)
            Dim SundayExitDateTime = DTP_ManualAsistance.Value.Date.AddHours(13.5)
            Dim Comment = TB_AbsenceReason.Text

            If SelectedEmployeeID = 0 Then
                MessageBox.Show("Por favor, seleccione un empleado de la tabla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If TB_AbsenceReason.Text = "" Then
                MessageBox.Show("Es necesario que indiqué la razón de la falta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim horaSalidaFinal As DateTime = ExitDateTime
                Select Case DTP_ManualAsistance.Value.DayOfWeek
                    Case 6
                        Result = InserManualAsistanceRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualAsistance.Value, EntryDateTime, SaturdayExitDateTime, Comment)
                    Case 7
                        Result = InserManualAsistanceRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualAsistance.Value, EntryDateTime, SundayExitDateTime, Comment)
                    Case Else
                        Result = InserManualAsistanceRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualAsistance.Value, EntryDateTime, ExitDateTime, Comment)
                End Select

                If Result Then
                    'LOG
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"REGISTRO MANUAL - JORNADA COMPLETA (MOV_130): Empleado ID: {SelectedEmployeeID} ({TB_EmployeeName.Text}). Fecha Laborada: {DTP_ManualAsistance.Value.ToShortDateString()}. Horario asignado: {EntryDateTime.ToShortTimeString()} a {horaSalidaFinal.ToShortTimeString()}. Razón: '{Comment}'."
                        InsertLog(connTmp, AppUser, "OP_AsistenciasManuales", "INSERT_ASISTANCE_SUCCESS", descLog, SelectedEmployeeID, "INFO")
                    End Using

                    MessageBox.Show("Registro de asistencia guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Display_ManualAsistanceRecord()
                    InitializationOfFields()
                End If
            End If

        Catch ex As Exception
            'LOG de error
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló el registro manual de asistencia para Empleado ID: {SelectedEmployeeID}. Motivo: {ex.Message}"
                InsertLog(connTmp, AppUser, "OP_AsistenciasManuales", "ERROR_INSERT_ASISTANCE", descError, SelectedEmployeeID, "ERROR", ex.StackTrace)
            End Using

            MsgBox("Ocurrió un error inesperado al registrar la asistencia: " & ex.Message, MsgBoxStyle.Critical, "Error Crítico")
        End Try
    End Sub

    Private Function InserManualAsistanceRecord(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime, ByVal DREMPL_COME As String) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        NewRecordByEmployee.DREMPL_COME = DREMPL_COME
        Result = NewRecordByEmployee.ManualAsistanceRecordByEmployee

        Return Result
    End Function

    Private Sub Display_ManualAsistanceRecord()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()

        DGV_DisplayInformation.DataSource = RecordsByEmployees.Get_ManualAsistanceRecord(SelectedEmployeeID, DTP_ManualAsistance.Value, 130)

        If DGV_DisplayInformation.Columns.Contains("Movimiento") Then
            DGV_DisplayInformation.Columns("Movimiento").Visible = False
        End If

        DGV_DisplayInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DisplayInformation.AutoResizeColumns()
        DGV_DisplayInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

    End Sub

    Private Sub Display_ManualDelayRecord()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()
        DGV_DisplayInformation.DataSource = RecordsByEmployees.Get_ManualDelayRecord(SelectedEmployeeID, DTP_ManualDelay.Value, 140)

        If DGV_DisplayInformation.Columns.Contains("Movimiento") Then
            DGV_DisplayInformation.Columns("Movimiento").Visible = False
        End If
        DGV_DisplayInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DisplayInformation.AutoResizeColumns()
        DGV_DisplayInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    End Sub

    Private Sub TB_Asistance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TB_Asistance.SelectedIndexChanged
        DGV_DisplayInformation.Columns.Clear()
    End Sub

    Private Sub BT_UpdateDateTime_Click(sender As Object, e As EventArgs) Handles BT_UpdateDateTime.Click
        Try
            Dim Result As Boolean = False
            Dim MovementID As Integer = 140 ' Justificar Retardo - Registro Manual
            Dim EntryDateTime As DateTime = DTP_ManualDelay.Value
            Dim Comment As String = TB_DelayComment.Text

            If SelectedEmployeeID = 0 Then
                MessageBox.Show("Por favor, seleccione un empleado de la tabla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If TB_DelayComment.Text = "" Then
                MessageBox.Show("Es necesario que indiqué la razón del retardo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Result = InserManualDelayRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualDelay.Value, EntryDateTime, Comment)

                If Result Then
                    'LOG
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"REGISTRO MANUAL - RETARDO JUSTIFICADO (MOV_140): Empleado ID: {SelectedEmployeeID} ({TB_EmployeeName.Text}). Fecha/Hora Checada: {EntryDateTime}. Comentario: '{Comment}'."
                        InsertLog(connTmp, AppUser, "OP_AsistenciasManuales", "INSERT_DELAY_SUCCESS", descLog, SelectedEmployeeID, "INFO")
                    End Using

                    MessageBox.Show("Retardo justificado guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Display_ManualDelayRecord()
                    InitializationOfFields()
                End If
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la justificación manual del retardo para Empleado ID: {SelectedEmployeeID}. Motivo: {ex.Message}"
                InsertLog(connTmp, AppUser, "OP_AsistenciasManuales", "ERROR_INSERT_DELAY", descError, SelectedEmployeeID, "ERROR", ex.StackTrace)
            End Using

            MsgBox("Ocurrió un error inesperado al justificar el retardo: " & ex.Message, MsgBoxStyle.Critical, "Error Crítico")
        End Try

    End Sub

    Private Function InserManualDelayRecord(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_COME As String) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_COME = DREMPL_COME

        Result = NewRecordByEmployee.InsertDelayRecordByEmployee()

        Return Result
    End Function

    Private Sub DTP_ManualAsistance_Leave(sender As Object, e As EventArgs) Handles DTP_ManualAsistance.Leave
        BT_AsistanceRegister.Enabled = True
    End Sub

    Private Sub DTP_ManualDelay_Leave(sender As Object, e As EventArgs) Handles DTP_ManualDelay.Leave
        BT_UpdateDateTime.Enabled = True
    End Sub

    Private Sub DTP_EarlyExit_ValueChanged(sender As Object, e As EventArgs) Handles DTP_EarlyExit.ValueChanged
        BT_EarlyExitRegister.Enabled = True
    End Sub
End Class