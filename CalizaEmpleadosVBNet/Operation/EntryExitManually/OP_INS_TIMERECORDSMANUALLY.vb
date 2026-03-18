Imports System.IO

Public Class OP_INS_TIMERECORDSMANUALLY
    Private SelectedEmployeeID As Integer = 0

    Private Sub OP_INS_TIMERECORDSMANUALLY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()
        BT_AsistanceRegister.Enabled = False
        BT_UpdateDateTime.Enabled = False

        DTP_ManualDelay.Format = DateTimePickerFormat.Custom
        DTP_ManualDelay.CustomFormat = "dddd , dd 'de' MMMM 'de' yyyy  HH:mm"

        TB_AbsenceReason.Text = ""
        TB_DelayComment.Text = ""

        DTP_ManualAsistance.Value = Date.Today
        DTP_ManualDelay.Value = Date.Now

        Display_Record()

    End Sub

    Private Sub Display_Record()

        Dim report As New CL_Employee()
        Dim table As DataTable = report.Get_AllEmployees()

        If table IsNot Nothing Then
            DGV_AllEmployees.DataSource = table
        End If

        DGV_AllEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_AllEmployees.AutoResizeColumns()

    End Sub

    Private Sub DGV_AllEmployees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_AllEmployees.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DGV_AllEmployees.Rows(e.RowIndex)

        SelectedEmployeeID = CInt(row.Cells(0).Value)

    End Sub

    Private Sub BT_AsistanceRegister_Click(sender As Object, e As EventArgs) Handles BT_AsistanceRegister.Click
        Dim Result As Boolean = False
        Dim MovementID As Integer = 130 ' Jornada Completa - Manual
        Dim EntryDateTime As DateTime = DTP_ManualAsistance.Value.Date.AddHours(7)
        Dim ExitDateTime As DateTime = DTP_ManualAsistance.Value.Date.AddHours(17.5)
        Dim SaturdayExitDateTime As DateTime = DTP_ManualAsistance.Value.Date.AddHours(13.5)
        Dim SundayExitDateTime As DateTime = DTP_ManualAsistance.Value.Date.AddHours(13.5)
        Dim Comment As String = TB_AbsenceReason.Text

        If TB_AbsenceReason.Text = "" Then
            MessageBox.Show("Es necesario que indiqué la razón de la falta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Select Case DTP_ManualAsistance.Value.DayOfWeek
                Case 6
                    Result = InserManualAsistanceRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualAsistance.Value, EntryDateTime, SaturdayExitDateTime, Comment)
                Case 7
                    Result = InserManualAsistanceRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualAsistance.Value, EntryDateTime, SundayExitDateTime, Comment)
                Case Else
                    Result = InserManualAsistanceRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualAsistance.Value, EntryDateTime, ExitDateTime, Comment)
            End Select

            If Result Then
                Display_ManualAsistanceRecord()
                InitializationOfFields()
            End If
        End If

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
        DGV_DisplayInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DisplayInformation.AutoResizeColumns()
        DGV_DisplayInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_DisplayInformation.DataSource = RecordsByEmployees.Get_ManualAsistanceRecord(SelectedEmployeeID, DTP_ManualAsistance.Value, 130)
    End Sub

    Private Sub Display_ManualDelayRecord()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()
        DGV_DisplayInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DisplayInformation.AutoResizeColumns()
        DGV_DisplayInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_DisplayInformation.DataSource = RecordsByEmployees.Get_ManualDelayRecord(SelectedEmployeeID, DTP_ManualDelay.Value, 140)
    End Sub

    Private Sub TB_Asistance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TB_Asistance.SelectedIndexChanged
        DGV_DisplayInformation.Columns.Clear()
    End Sub

    Private Sub BT_UpdateDateTime_Click(sender As Object, e As EventArgs) Handles BT_UpdateDateTime.Click
        Dim Result As Boolean = False
        Dim MovementID As Integer = 140 ' Justificar Retardo - Registro Manual
        Dim EntryDateTime As DateTime = DTP_ManualDelay.Value
        Dim Comment As String = TB_DelayComment.Text

        If TB_DelayComment.Text = "" Then
            MessageBox.Show("Es necesario que indiqué la razón del retardo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Result = InserManualDelayRecord(SelectedEmployeeID, MovementID, AppUser, Date.Now, DTP_ManualDelay.Value, EntryDateTime, Comment)

            If Result Then
                Display_ManualDelayRecord()
                InitializationOfFields()
            End If
        End If

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
End Class