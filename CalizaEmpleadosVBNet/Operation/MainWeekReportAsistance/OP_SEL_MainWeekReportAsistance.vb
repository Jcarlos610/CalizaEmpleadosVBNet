Imports Microsoft.Identity.Client

Public Class OP_SEL_MainWeekReportAsistance
    Dim SelectedEmployeeID As Integer = 0

    Private Sub OP_SEL_MainWeekReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DTP_WeekSelector.Value = Today
        'LoadWeek()
        DTP_StartDate.Visible = False
        DTP_EndDate.Visible = False
    End Sub

    Private Function GetWeekRange(selectedDate As Date) As Tuple(Of Date, Date)

        Dim startDate As Date = selectedDate

        While startDate.DayOfWeek <> DayOfWeek.Thursday
            startDate = startDate.AddDays(-1)
        End While

        Dim endDate As Date = startDate.AddDays(6)

        Return Tuple.Create(startDate, endDate)

    End Function

    'Private Sub DTP_WeekSelector_ValueChanged(sender As Object, e As EventArgs)
    '    LoadWeek()
    'End Sub

    Private Sub LoadWeek()

        Dim weekRange = GetWeekRange(DTP_WeekSelector.Value)

        Dim startDate As Date = weekRange.Item1
        Dim endDate As Date = weekRange.Item2

        Dim RecordsByEmployee As New CL_RecordsByEmployee

        Dim dt As DataTable = RecordsByEmployee.Get_WeekRecords(startDate, endDate)

        DTP_StartDate.Value = startDate
        DTP_StartDate.Enabled = False
        DTP_EndDate.Value = endDate
        DTP_EndDate.Enabled = False

        BuildWeeklyGrid(dt, startDate)

    End Sub

    Private Sub BuildWeeklyGrid(sourceTable As DataTable, startDate As Date)

        Dim dt As New DataTable

        'Columnas fijas
        dt.Columns.Add("Empresa")
        dt.Columns.Add("ID Empleado")
        dt.Columns.Add("Nombre Completo")
        dt.Columns.Add("Posición")
        dt.Columns.Add("Tipo")

        'Columnas de la semana
        For i = 0 To 6
            'dt.Columns.Add(startDate.AddDays(i).ToString("ddd dd"))
            dt.Columns.Add(startDate.AddDays(i).ToString("dd/MM/yyyy"))
        Next

        'Lista de empleados únicos
        Dim employees = sourceTable.DefaultView.ToTable(True,
                                                        "Empresa",
                                                        "ID Empleado",
                                                        "Nombre Completo",
                                                        "Posición",
                                                        "Tipo de empleado")

        For Each emp As DataRow In employees.Rows

            Dim newRow = dt.NewRow()

            newRow("Empresa") = emp("Empresa")
            newRow("ID Empleado") = emp("ID Empleado")
            newRow("Nombre Completo") = emp("Nombre Completo")
            newRow("Posición") = emp("Posición")
            newRow("Tipo") = emp("Tipo de empleado")

            For i = 0 To 6

                Dim currentDate = startDate.AddDays(i)

                Dim found = sourceTable.Select(
                    "[ID Empleado]=" & emp("ID Empleado") &
                    " AND DREMPL_DATE = #" & currentDate.ToString("yyyy-MM-dd") & "#"
                )

                'If there are records then check for delay justification
                If found.Length > 0 Then
                    Dim moveID As Integer = CInt(found(0)("MOVE_ID"))

                    If moveID = 100 Or moveID = 110 Then
                        Dim EmployeeRecord As New CL_RecordsByEmployee
                        EmployeeRecord.EMPL_ID = CInt(emp("ID Empleado"))
                        EmployeeRecord.DREMPL_DATE = currentDate.ToString("yyyy-MM-dd")
                        Dim DelayJustified As Integer = 140 ' Retardo Justificado - Registro Manual

                        Dim EmployeeRecords140 As DataTable = EmployeeRecord.Get_CheckDelayJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        If EmployeeRecords140.Rows.Count > 0 Then
                            newRow(i + 5) = 140
                        Else
                            newRow(i + 5) = found(0)("MOVE_ID")
                        End If
                    ElseIf moveID = 60 Then
                        'If there are records then check for abssence justification
                        Dim EmployeeRecord As New CL_RecordsByEmployee
                        EmployeeRecord.EMPL_ID = CInt(emp("ID Empleado"))
                        EmployeeRecord.DREMPL_DATE = currentDate.ToString("yyyy-MM-dd")
                        Dim DelayJustified As Integer = 130 ' Retardo Justificado - Registro Manual

                        Dim EmployeeRecords140 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        If EmployeeRecords140.Rows.Count > 0 Then
                            newRow(i + 5) = 130
                        Else
                            newRow(i + 5) = found(0)("MOVE_ID")
                        End If
                    Else
                        newRow(i + 5) = found(0)("MOVE_ID")
                    End If
                End If


            Next

            dt.Rows.Add(newRow)

        Next

        DGV_CompleteWeekInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_CompleteWeekInfo.AutoResizeColumns()
        DGV_CompleteWeekInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_CompleteWeekInfo.DataSource = dt

        'Centra las columnas de los días
        For i = 5 To DGV_CompleteWeekInfo.Columns.Count - 1
            DGV_CompleteWeekInfo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        PaintCells()

    End Sub

    Private Sub PaintCells()

        For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows

            For i = 5 To DGV_CompleteWeekInfo.Columns.Count - 1

                Dim value = row.Cells(i).Value

                If value Is Nothing OrElse value Is DBNull.Value Then Continue For

                Dim moveID As Integer = Convert.ToInt32(value)

                Select Case moveID
                    Case 60
                        row.Cells(i).Value = "FI"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
                        row.Cells(i).ToolTipText = "Falta Injustificada"
                    Case 70
                        row.Cells(i).Value = "JC"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Jornada Completa"
                    Case 80
                        row.Cells(i).Value = "JC-T"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Jornada Completa con Tolerancia"
                    Case 85
                        row.Cells(i).Value = "JC-TA"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Jornada Completa con Tiempo Adicional"
                    Case 90
                        row.Cells(i).Value = "JI-EP-SA"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
                        row.Cells(i).ToolTipText = "Jornada Incompleta - Entrada Puntual y Salida Anticipada"
                    Case 100
                        row.Cells(i).Value = "JI-ER-SA"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
                        row.Cells(i).ToolTipText = "Jornada Incompleta - Entrada con retardo salida anticipada"
                    Case 110
                        row.Cells(i).Value = "JI-ER-SP"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
                        row.Cells(i).ToolTipText = "Jornada Incompleta - Entrada con retardo salida puntual"
                    Case 120
                        row.Cells(i).Value = "JI-ET-SA"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
                        row.Cells(i).ToolTipText = "Jornada Incompleta - Entrada con tolerancia salida anticipada"
                    Case 130
                        row.Cells(i).Value = "JC-FJ"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Jornada Completa - Falta Justificada"
                    Case 140
                        row.Cells(i).Value = "RJ"
                        row.Cells(i).Style.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Retardo Justificado"

                End Select

            Next

        Next

    End Sub

    Private Sub DTP_WeekSelector_MouseLeave(sender As Object, e As EventArgs)
        DTP_StartDate.Visible = True

        DTP_EndDate.Visible = True
    End Sub

    Private Sub DTP_WeekSelector_ValueChanged_1(sender As Object, e As EventArgs) Handles DTP_WeekSelector.ValueChanged
        LoadWeek()
    End Sub

    Private Sub DGV_CompleteWeekInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_CompleteWeekInfo.CellClick

    End Sub

    Private Sub DGV_CompleteWeekInfo_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_CompleteWeekInfo.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_CompleteWeekInfo.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_CompleteWeekInfo.Rows(hit.RowIndex)

            Dim Employee_Id As Integer = CInt(row.Cells(1).Value)

            Dim EmployeeRecords As New CL_RecordsByEmployee
            Dim EmployeeInfo = EmployeeRecords.Get_WeekRecordsDetailsBYEmployee(DTP_StartDate.Value, DTP_EndDate.Value, Employee_Id)

            DGV_DetailsByEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_DetailsByEmployee.AutoResizeColumns()
            DGV_DetailsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DGV_DetailsByEmployee.DataSource = EmployeeInfo
        End If

    End Sub
End Class
