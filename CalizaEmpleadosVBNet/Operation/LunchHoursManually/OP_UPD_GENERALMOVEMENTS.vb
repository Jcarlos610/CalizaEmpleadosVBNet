'Imports System.Data.Common
'Imports Microsoft.Data.SqlClient

'Public Class OP_UPD_GENERALMOVEMENTS

'    Dim obj As New CL_RecordsByEmployee
'    Private loading As Boolean = False
'    Private AppUser As String = ""

'    Dim obj1 As New CL_TemporalLunchTime
'    Dim obj2 As New CL_EmployeeBanns
'    Private Sub FRM_GeneralMovements_Load(sender As Object, e As EventArgs) Handles MyBase.Load

'        AppUser = GlobalValues.AppUser
'        DTP_StartDate.Value = DateTime.Now
'    End Sub

'    Private Sub DTP_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DTP_StartDate.ValueChanged
'        RemoveHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged

'        Dim fechaSeleccionada As Date = DTP_StartDate.Value
'        Dim diasARestar As Integer = (CInt(fechaSeleccionada.DayOfWeek) - CInt(DayOfWeek.Thursday) + 7) Mod 7

'        DTP_StartDate.Value = fechaSeleccionada.AddDays(-diasARestar).Date
'        DTP_EndDate.Value = DTP_StartDate.Value.AddDays(6).Date

'        AddHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged

'        RefreshGridData()
'    End Sub

'    Private Sub SetWeekRange(selectedDate As Date)
'        Dim daysToSubtract As Integer = (CInt(selectedDate.DayOfWeek) - CInt(DayOfWeek.Thursday) + 7) Mod 7
'        Dim startThursday As Date = selectedDate.AddDays(-daysToSubtract).Date

'        DTP_StartDate.Value = startThursday
'        DTP_EndDate.Value = startThursday.AddDays(6).Date
'        RefreshGridData()
'    End Sub

'    Private Sub RefreshGridData()
'        If loading Then Exit Sub

'        Dim dt As DataTable = obj.GetGeneralMovementsByRange(DTP_StartDate.Value, DTP_EndDate.Value)

'        If dt IsNot Nothing Then
'            dt.Columns("DREMPL_LHOUR").ReadOnly = False
'            dt.Columns("DREMPL_BQUANT").ReadOnly = False
'            dt.Columns("DREMPL_TDAYS").ReadOnly = False
'            dt.Columns("OBSERVACIONES").ReadOnly = False
'            FormatGrid(dt)
'        End If
'    End Sub

'    Private Sub FormatGrid(dt As DataTable)
'        DGV_ActiveEmployeesInfo.DataSource = dt

'        With DGV_ActiveEmployeesInfo
'            .AllowUserToAddRows = False
'            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

'            For Each col As DataGridViewColumn In .Columns
'                col.ReadOnly = True
'            Next

'            If .Columns.Contains("DREMPL_LHOUR") Then .Columns("DREMPL_LHOUR").ReadOnly = False : .Columns("DREMPL_LHOUR").HeaderText = "Horas Comida" : .Columns("DREMPL_LHOUR").DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
'            If .Columns.Contains("DREMPL_BQUANT") Then .Columns("DREMPL_BQUANT").ReadOnly = False : .Columns("DREMPL_BQUANT").HeaderText = "Amonestaciones" : .Columns("DREMPL_BQUANT").DefaultCellStyle.BackColor = Color.LightCyan
'            If .Columns.Contains("DREMPL_TDAYS") Then .Columns("DREMPL_TDAYS").ReadOnly = False : .Columns("DREMPL_TDAYS").HeaderText = "Días Transporte" : .Columns("DREMPL_TDAYS").DefaultCellStyle.BackColor = Color.Honeydew
'            If .Columns.Contains("OBSERVACIONES") Then .Columns("OBSERVACIONES").ReadOnly = False : .Columns("OBSERVACIONES").HeaderText = "Observaciones" : .Columns("OBSERVACIONES").DefaultCellStyle.BackColor = Color.WhiteSmoke

'            Dim hiddenCols As String() = {"TEMP_LUNCH_ID", "BANN_ID", "TDAYS_ID", "COMM_ID", "ID Empresa"}
'            For Each h In hiddenCols
'                If .Columns.Contains(h) Then .Columns(h).Visible = False
'            Next
'        End With
'    End Sub



'    Private Function GetSafeInt(row As DataGridViewRow, col As String) As Integer
'        If Not row.DataGridView.Columns.Contains(col) Then Return 0
'        Dim val = row.Cells(col).Value
'        Return If(val Is Nothing OrElse IsDBNull(val), 0, Convert.ToInt32(val))
'    End Function

'    Private Function GetSafeDecimal(row As DataGridViewRow, col As String) As Decimal
'        If Not row.DataGridView.Columns.Contains(col) Then Return 0
'        Dim val = row.Cells(col).Value
'        Return If(val Is Nothing OrElse IsDBNull(val), 0D, Convert.ToDecimal(val))
'    End Function


'    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

'        Try

'            DGV_ActiveEmployeesInfo.EndEdit()

'            For Each row As DataGridViewRow In DGV_ActiveEmployeesInfo.Rows

'                If row.IsNewRow Then Continue For

'                Dim emplId As Integer = Convert.ToInt32(row.Cells("No.").Value)

'                Dim lunchId As Integer = GetSafeInt(row, "TEMP_LUNCH_ID")
'                Dim lunchHours As Decimal = GetSafeDecimal(row, "DREMPL_LHOUR")

'                If lunchHours > 5 Then
'                    MessageBox.Show("Las horas comida no pueden ser mayores a 5.")
'                    Continue For
'                End If

'                If lunchId > 0 Then

'                    obj1.LUNCH_HOURS = lunchHours
'                    obj1.LUNCH_DATE = DTP_StartDate.Value
'                    obj1.LUNCH_CREBY = AppUser

'                    obj1.UpdateTemporalLunch(lunchId)

'                End If

'                Dim cantidadNueva As Integer = GetSafeInt(row, "DREMPL_BQUANT")

'                Dim cantidadActual As Integer =
'                obj.GetBannsCountByEmployee(emplId, DTP_StartDate.Value, DTP_EndDate.Value)
'                If cantidadNueva > cantidadActual Then

'                    Dim diferencia As Integer =
'                    cantidadNueva - cantidadActual

'                    For i As Integer = 1 To diferencia

'                        obj2.EMPL_ID = emplId
'                        obj2.BANN_ID = 1

'                        obj2.EBANN_DATE = DTP_StartDate.Value
'                        obj2.EBANN_CREBY = AppUser
'                        obj2.EBANN_DATEC = Now
'                        obj2.EBANN_STAT = 1

'                        obj2.InsertEmployeeBann()

'                    Next

'                End If
'                If cantidadNueva < cantidadActual Then

'                    Dim diferencia As Integer =
'                    cantidadActual - cantidadNueva

'                    obj.DisableLastBanns(
'                    emplId,
'                    diferencia,
'                    DTP_StartDate.Value,
'                    DTP_EndDate.Value
'                )

'                End If

'                Dim transId As Integer = GetSafeInt(row, "TDAYS_ID")
'                Dim transportDays As Decimal = GetSafeDecimal(row, "DREMPL_TDAYS")

'                If transportDays > 5 Then
'                    MessageBox.Show("Los días transporte no pueden ser mayores a 5.")
'                    Continue For
'                End If

'                If transId > 0 Then

'                    obj.UpdateTransportDays(transId, transportDays)

'                ElseIf transportDays > 0 Then

'                    obj.InsertTransportDirect(emplId, 280, AppUser, DTP_StartDate.Value, transportDays)

'                End If

'                Dim comentario As String =
'                row.Cells("OBSERVACIONES").Value.ToString().Trim()

'                If comentario <> "" Then

'                    obj.InsertGeneralComment(emplId, comentario, AppUser, DTP_StartDate.Value)

'                End If

'            Next

'            MessageBox.Show("Actualización realizada correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

'            RefreshGridData()

'        Catch ex As Exception

'            MessageBox.Show(
'            ex.Message,
'            "Error",
'            MessageBoxButtons.OK,
'            MessageBoxIcon.Error
'        )

'        End Try

'    End Sub


'    'Private Sub BT_ValidateFinal_Click(sender As Object, e As EventArgs) Handles BT_ValidateFinal.Click

'    '    Dim respuesta As MsgBoxResult

'    '    respuesta = MsgBox("¿Desea validar la semana seleccionada?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar")

'    '    If respuesta = MsgBoxResult.Yes Then

'    '        obj.ValidateLunchTemporal(
'    '            DTP_StartDate.Value,
'    '            DTP_EndDate.Value,
'    '            AppUser
'    '        )

'    '        MsgBox(
'    '            "Semana validada correctamente.",
'    '            MsgBoxStyle.Information
'    '        )

'    '        RefreshGridData()

'    '    End If

'    'End Sub

'End Class