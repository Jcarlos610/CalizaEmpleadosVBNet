Imports System.Diagnostics.Metrics
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports DocumentFormat.OpenXml.Bibliography
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Math
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Microsoft.Identity.Client
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles

Public Class OP_SEL_MainWeekReportSalaryCalculation
    Dim SelectedEmployeeID As Integer = 0

    Private Sub OP_SEL_MainWeekReportSalaryCalculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_WeekSelector.Value = Today
        LB_StartDate.Visible = False
        DTP_StartDate.Visible = False
        LB_EndDate.Visible = False
        DTP_EndDate.Visible = False
        BT_FinalConfirmation.Enabled = False
        CB_Confirmation.Enabled = False

    End Sub

    Private Function GetWeekRange(selectedDate As Date) As Tuple(Of Date, Date)

        Dim startDate As Date = selectedDate

        While startDate.DayOfWeek <> DayOfWeek.Thursday
            startDate = startDate.AddDays(-1)
        End While

        Dim endDate As Date = startDate.AddDays(6)

        Return Tuple.Create(startDate, endDate)

    End Function

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

        Dim EmployeesInfo As New DataTable

        'Columnas fijas
        EmployeesInfo.Columns.Add("Empresa")
        EmployeesInfo.Columns.Add("No.")
        EmployeesInfo.Columns.Add("Nombre Completo")
        EmployeesInfo.Columns.Add("Posición")
        EmployeesInfo.Columns.Add("Tipo")
        EmployeesInfo.Columns.Add("S. Base")

        'Columnas de la semana
        For i = 0 To 6
            'dt.Columns.Add(startDate.AddDays(i).ToString("ddd dd"))
            EmployeesInfo.Columns.Add(startDate.AddDays(i).ToString("dd/MM/yyyy"))
        Next

        'Lista de empleados únicos
        Dim employees = sourceTable.DefaultView.ToTable(True, "Empresa", "ID Empleado", "Nombre Completo", "Posición", "Tipo de empleado", "Salario Base")

        For Each emp As DataRow In employees.Rows

            Dim newRow = EmployeesInfo.NewRow()

            newRow("Empresa") = emp("Empresa")
            newRow("No.") = emp("ID Empleado")
            newRow("Nombre Completo") = emp("Nombre Completo")
            newRow("Posición") = emp("Posición")
            newRow("Tipo") = emp("Tipo de empleado")
            newRow("S. Base") = emp("Salario Base")

            For i = 0 To 6 ' Week Days

                Dim currentDate = startDate.AddDays(i)

                Dim found = sourceTable.Select("[ID Empleado]=" & emp("ID Empleado") & " AND DREMPL_DATE = #" & currentDate.ToString("yyyy-MM-dd") & "#")

                'If there are records then check for delay justification
                If found.Length > 0 Then
                    Dim moveID As Integer = CInt(found(0)("MOVE_ID"))

                    If moveID = 100 Or moveID = 110 Then ' tuvo Asistencia
                        Dim EmployeeRecord As New CL_RecordsByEmployee
                        EmployeeRecord.EMPL_ID = CInt(emp("ID Empleado"))
                        EmployeeRecord.DREMPL_DATE = currentDate.ToString("yyyy-MM-dd")
                        Dim DelayJustified As Integer = 140 ' Retardo Justificado - Registro Manual

                        Dim EmployeeRecords140 As DataTable = EmployeeRecord.Get_CheckDelayJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        If EmployeeRecords140.Rows.Count > 0 Then
                            newRow(i + 6) = 140 ' Retardo Justificado
                        Else
                            newRow(i + 6) = found(0)("MOVE_ID")
                        End If
                    ElseIf moveID = 60 Then ' Tuvo falta
                        'If there are records then check for absence justification
                        Dim EmployeeRecord As New CL_RecordsByEmployee
                        EmployeeRecord.EMPL_ID = CInt(emp("ID Empleado"))
                        EmployeeRecord.DREMPL_DATE = currentDate.ToString("yyyy-MM-dd")
                        Dim DelayJustified As Integer = 130 ' Retardo Justificado - Registro Manual

                        Dim EmployeeRecords130 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        If EmployeeRecords130.Rows.Count > 0 Then
                            newRow(i + 6) = 130 ' Jornada Completa - Falta Justificada
                        Else
                            Dim AbsenceWithSalary As Integer = 500 ' Permiso con goce - Registro Manual

                            'Let's see if there is a permission or vacations
                            Dim EmployeeRecords500 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), AbsenceWithSalary)
                            If EmployeeRecords500.Rows.Count > 0 Then
                                newRow(i + 6) = 500 ' Permiso con goce
                            Else
                                Dim AbsenceWithoutSalary As Integer = 510 ' Permiso sin goce - Registro Manual

                                'Let's see if there is a permission or vacations
                                Dim EmployeeRecords510 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), AbsenceWithoutSalary)
                                If EmployeeRecords510.Rows.Count > 0 Then
                                    newRow(i + 6) = 510 ' Permiso con goce
                                Else
                                    Dim AbsenceForVacation As Integer = 520 ' Falta por vacaciones - Registro Manual

                                    'Let's see if there is a permission or vacations
                                    Dim EmployeeRecords520 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), AbsenceForVacation)
                                    If EmployeeRecords520.Rows.Count > 0 Then
                                        newRow(i + 6) = 520 ' Permiso con goce
                                    Else
                                        newRow(i + 6) = found(0)("MOVE_ID")
                                    End If
                                End If
                            End If
                        End If

                        'Dim EmployeeRecords130 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        'If EmployeeRecords130.Rows.Count > 0 Then
                        '    newRow(i + 6) = 130 ' Jornada Completa - Falta Justificada
                        'Else
                        '    newRow(i + 6) = found(0)("MOVE_ID")
                        'End If
                    Else
                        newRow(i + 6) = found(0)("MOVE_ID")
                    End If
                End If


            Next

            EmployeesInfo.Rows.Add(newRow)

        Next
        '----- 1.- Add Column to DGV
        EmployeesInfo.Columns.Add("S. Diario", GetType(String))
        EmployeesInfo.Columns.Add("Ext. S", GetType(String))
        EmployeesInfo.Columns.Add("Ext. D", GetType(String))
        EmployeesInfo.Columns.Add("Ext. T", GetType(String))
        EmployeesInfo.Columns.Add("H. Comida", GetType(Decimal))    ' 17
        EmployeesInfo.Columns.Add("Bono Prod.", GetType(String))    ' 18
        EmployeesInfo.Columns.Add("Bono BP", GetType(String))       ' 19
        EmployeesInfo.Columns.Add("Amonest..", GetType(Decimal))    ' 20
        EmployeesInfo.Columns.Add("Ahorro", GetType(String))        ' 21
        EmployeesInfo.Columns.Add("Bono P. P.", GetType(String))    ' 22
        EmployeesInfo.Columns.Add("Transporte", GetType(String))    ' 23
        EmployeesInfo.Columns.Add("Prestado", GetType(String))      ' 23-24
        EmployeesInfo.Columns.Add("Pagado", GetType(String))        ' 24-25
        EmployeesInfo.Columns.Add("Saldo a pagar", GetType(String)) ' 25-26
        EmployeesInfo.Columns.Add("Desc. Prest.", GetType(String))  ' 26-27
        EmployeesInfo.Columns.Add("Calculado", GetType(String))     ' 27-28

        'DGV_CompleteWeekInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        'DGV_CompleteWeekInfo.AutoResizeColumns()
        DGV_CompleteWeekInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_CompleteWeekInfo.DataSource = EmployeesInfo
        DGV_CompleteWeekInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DGV_CompleteWeekInfo.Columns("Empresa").Width = 220
        DGV_CompleteWeekInfo.Columns("No.").Width = 40
        DGV_CompleteWeekInfo.Columns("Nombre Completo").Width = 180
        DGV_CompleteWeekInfo.Columns("Posición").Width = 150
        DGV_CompleteWeekInfo.Columns("Tipo").Width = 60
        DGV_CompleteWeekInfo.Columns("S. Base").Width = 65
        DGV_CompleteWeekInfo.Columns("S. Base").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'Centra las columnas de los días
        For i = 6 To 12
            DGV_CompleteWeekInfo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGV_CompleteWeekInfo.Columns(i).Width = 70
        Next

        '----- 2.- Adit Width 
        DGV_CompleteWeekInfo.Columns("S. Diario").Width = 65
        DGV_CompleteWeekInfo.Columns("S. Diario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Ext. S").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Ext. S").Width = 50
        DGV_CompleteWeekInfo.Columns("Ext. D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Ext. D").Width = 50
        DGV_CompleteWeekInfo.Columns("Ext. T").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Ext. T").Width = 50
        '17
        DGV_CompleteWeekInfo.Columns("H. Comida").Width = 70
        DGV_CompleteWeekInfo.Columns("H. Comida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("H. Comida").ToolTipText = "Horas de comida"
        '18
        DGV_CompleteWeekInfo.Columns("Bono Prod.").Width = 80
        DGV_CompleteWeekInfo.Columns("Bono Prod.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Bono Prod.").ToolTipText = "Bono de Productividad"
        '19
        DGV_CompleteWeekInfo.Columns("Bono BP").Width = 70
        DGV_CompleteWeekInfo.Columns("Bono BP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Bono BP").ToolTipText = "Bono de actitud y buenas practicas"
        '20
        DGV_CompleteWeekInfo.Columns("Amonest..").Width = 70
        DGV_CompleteWeekInfo.Columns("Amonest..").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Amonest..").ToolTipText = "Número de amonestaciones"
        '21
        DGV_CompleteWeekInfo.Columns("Ahorro").Width = 50
        DGV_CompleteWeekInfo.Columns("Ahorro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Ahorro").ToolTipText = "Cantidad a Ahorrar"
        '22
        DGV_CompleteWeekInfo.Columns("Bono P. P.").Width = 70
        DGV_CompleteWeekInfo.Columns("Bono P. P.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Bono P. P.").ToolTipText = "Bono de productividad de planta"
        '23
        DGV_CompleteWeekInfo.Columns("Transporte").Width = 70
        DGV_CompleteWeekInfo.Columns("Transporte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Transporte").ToolTipText = "Bono de transporte"
        '24
        DGV_CompleteWeekInfo.Columns("Prestado").Width = 70
        DGV_CompleteWeekInfo.Columns("Prestado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Prestado").ToolTipText = "Monto Prestado"
        '25
        DGV_CompleteWeekInfo.Columns("Pagado").Width = 70
        DGV_CompleteWeekInfo.Columns("Pagado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Pagado").ToolTipText = "Monto Pagado"
        '26
        DGV_CompleteWeekInfo.Columns("Saldo a pagar").Width = 90
        DGV_CompleteWeekInfo.Columns("Saldo a pagar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Saldo a pagar").ToolTipText = "Saldo a pagar"
        '27
        DGV_CompleteWeekInfo.Columns("Desc. Prest.").Width = 80
        DGV_CompleteWeekInfo.Columns("Desc. Prest.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Desc. Prest.").ToolTipText = "Monto a descontar"
        '28
        DGV_CompleteWeekInfo.Columns("Calculado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Calculado").Width = 65

        PaintCells()
        GetAdditionalValues()

        If DGV_CompleteWeekInfo.Rows.Count > 0 Then
            CB_Confirmation.Enabled = True
        End If

    End Sub

    Private Sub PaintCells()

        For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows

            For i = 6 To DGV_CompleteWeekInfo.Columns.Count - 1

                Dim value = row.Cells(i).Value

                If value Is Nothing OrElse value Is DBNull.Value Then Continue For

                Dim moveID As Integer = Convert.ToInt32(value)

                Select Case moveID
                    Case 60
                        row.Cells(i).Value = "F" ' FI -Falta Injustificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(128), CByte(0))
                        row.Cells(i).ToolTipText = "Falta"
                    Case 70
                        row.Cells(i).Value = "A" ' JC- Jornada Completa
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 80
                        row.Cells(i).Value = "A" ' JC-T Jornada completa con tolerancia
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 85
                        row.Cells(i).Value = "A" 'JC-TA Jornada Completa con Tiempo Adicional
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 90
                        row.Cells(i).Value = "A" 'JI-EP-SA Jornada Incompleta - Entrada Puntual y Salida Anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 100
                        row.Cells(i).Value = "R" 'JI-ER-SA Jornada Incompleta - Entrada con retardo salida anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case 110
                        row.Cells(i).Value = "R" 'JI-ER-SP Jornada Incompleta - Entrada con retardo salida puntual
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case 120
                        row.Cells(i).Value = "A" 'JI-ET-SA Jornada Incompleta - Entrada con tolerancia salida anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case 130
                        row.Cells(i).Value = "FJ" 'JC-FJ Jornada Completa - Falta Justificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(128), CByte(128))
                        row.Cells(i).ToolTipText = "Falta Justificada"
                    Case 140
                        row.Cells(i).Value = "R" ' RJ Retardo Justificado
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case 500
                        row.Cells(i).Value = "PG" ' PG Permiso con goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Permiso con goce"
                    Case 510
                        row.Cells(i).Value = "PSG" ' Permiso sin goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(127), CByte(255), CByte(212))
                        row.Cells(i).ToolTipText = "Permiso sin goce"
                    Case 520
                        row.Cells(i).Value = "V" ' V Vacaciones
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(224), CByte(192))
                        row.Cells(i).ToolTipText = "Vacaciones"
                End Select

            Next

        Next

    End Sub

    Private Sub PaintCells_Sorted()

        For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows

            For i = 6 To DGV_CompleteWeekInfo.Columns.Count - 1

                Dim value = row.Cells(i).Value

                If value Is Nothing OrElse value Is DBNull.Value Then Continue For

                Dim moveID As String = value

                Select Case moveID
                    Case "F"
                        row.Cells(i).Value = "F" ' FI -Falta Injustificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(128), CByte(0))
                        row.Cells(i).ToolTipText = "Falta"
                    Case "A"
                        row.Cells(i).Value = "A" ' JC- Jornada Completa
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Asistencia"
                    Case "R"
                        row.Cells(i).Value = "R" 'JI-ER-SA Jornada Incompleta - Entrada con retardo salida anticipada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(255))
                        row.Cells(i).ToolTipText = "Retardo"
                    Case "FJ"
                        row.Cells(i).Value = "FJ" 'JC-FJ Jornada Completa - Falta Justificada
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(128), CByte(128))
                        row.Cells(i).ToolTipText = "Falta Justificada"
                    Case "PG"
                        row.Cells(i).Value = "PG" ' PG Permiso con goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(255), CByte(192))
                        row.Cells(i).ToolTipText = "Permiso con goce"
                    Case "PSG"
                        row.Cells(i).Value = "PSG" ' Permiso sin goce
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(127), CByte(255), CByte(212))
                        row.Cells(i).ToolTipText = "Permiso sin goce"
                    Case "V"
                        row.Cells(i).Value = "V" ' V Vacaciones
                        row.Cells(i).Style.BackColor = System.Drawing.Color.FromArgb(CByte(255), CByte(224), CByte(192))
                        row.Cells(i).ToolTipText = "Vacaciones"
                End Select

            Next

        Next

    End Sub

    Private Sub DTP_WeekSelector_MouseLeave(sender As Object, e As EventArgs)
        DTP_StartDate.Visible = True
        LB_StartDate.Visible = True
        DTP_EndDate.Visible = True
        LB_EndDate.Visible = True
    End Sub

    Private Sub DTP_WeekSelector_ValueChanged_1(sender As Object, e As EventArgs) Handles DTP_WeekSelector.ValueChanged
        LoadWeek()
        DTP_StartDate.Visible = True
        DTP_EndDate.Visible = True
        LB_StartDate.Visible = True
        LB_EndDate.Visible = True

    End Sub

    Private Sub GetAdditionalValues()
        Dim CumulativesEmployees As DataTable = Get_CumulativesByEmployee()
        Dim CounterLine As Integer = 0

        'Scroll trough the list of employees into the DGV
        For Each EmployeeCum As DataRow In CumulativesEmployees.Rows
            Dim LunchHourAmmount As Decimal = 0.0
            Dim ProductGoodPract As Decimal = 0.0
            Dim GoodPractice As Decimal = 0.0
            Dim AttitudeGoodPract As Decimal = 0.0
            Dim SavingAmmount As Decimal = 0.0
            Dim PaymentAmmount As Decimal = 0.0

            Dim CounterOfDays As Integer = 0
            Dim EmployeeID As Integer = CInt(EmployeeCum(0))
            Dim CounterA As Integer = CInt(EmployeeCum(2))
            Dim CounterR As Integer = CInt(EmployeeCum(4))
            Dim CounterF As Integer = CInt(EmployeeCum(6))
            Dim CounterFJ As Integer = CInt(EmployeeCum(8))
            Dim CounterPG As Integer = CInt(EmployeeCum(10))
            Dim CounterPSG As Integer = CInt(EmployeeCum(12))
            Dim CounterV As Integer = CInt(EmployeeCum(14))

            If CounterA = 6 Then
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(9).Value = "A"
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(9).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
            Else
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(9).Value = "A"
                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(9).Style.BackColor = System.Drawing.Color.FromArgb(CByte(230), CByte(230), CByte(250))
            End If

            'Get employee information
            Dim Employees = New CL_Employee
            Dim EmployeesCompleteInformation As DataTable = Employees.Get_EmployeesInfoByID(EmployeeID)

            Dim NewSalary As Decimal = 0.0
            Dim DailySalary As Decimal = 0.0
            Dim BaseSalary As Decimal = 0.0
            Dim SundaySalary As Decimal = 0.0
            Dim ExtraS As Decimal = 0.0
            Dim ExtraD As Decimal = 0.0
            Dim Extrat As Decimal = 0.0

            'Get employee's base salary 
            For Each EmployeeCompleteInformation As DataRow In EmployeesCompleteInformation.Rows
                BaseSalary = EmployeeCompleteInformation(9)
            Next

            'Obtain sunday salary
            SundaySalary = (BaseSalary / 7)
            DailySalary = (BaseSalary / 7)

            '----- 3.- asign value 

            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(13).Value = DailySalary.ToString("C2")
            ExtraS = DailySalary / 48
            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(14).Value = ExtraS.ToString("C2")
            ExtraD = ExtraS * 2
            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(15).Value = ExtraD.ToString("C2")
            Extrat = ExtraS * 3
            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(16).Value = Extrat.ToString("C2")

            'Get lunch hours by employee
            Dim RecordsbyEmployee = New CL_RecordsByEmployee
            Dim LunchRecords As DataTable = RecordsbyEmployee.Get_LuchHoursByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 250)
            Dim LunchHours As Decimal = 0.0
            For Each LunchRecord As DataRow In LunchRecords.Rows
                LunchHours = CDec(LunchRecord(7))
            Next

            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(17).Value = LunchHours

            'Get lunch hours by employee
            Dim BannsRecords As DataTable = RecordsbyEmployee.Get_BannQuantityByEmployee(DTP_StartDate.Value, DTP_EndDate.Value, EmployeeID, 270)
            Dim BannsQuantity As Decimal = 0
            For Each BannRecord As DataRow In BannsRecords.Rows
                BannsQuantity = CDec(BannRecord(7))
            Next

            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(20).Value = BannsQuantity

            Dim Benefits As New CL_Benefits
            Dim ListOfBenefits As DataTable = Benefits.Get_AllActiveManualAutomaticBenefits

            'Let's scroll through the list of benefits
            For Each Benefit As DataRow In ListOfBenefits.Rows
                Dim Comment As String = ""
                Dim BenefitID As Integer = CInt(Benefit(0))
                Dim BenefitAmmount As Decimal = CDec(Benefit(4).ToString.Replace("%", ""))
                Dim DailyBenefit As Decimal = BenefitAmmount / 7

                Select Case BenefitID
                    Case 10 ' Bono de productividad

                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        'Bono Productividad
                        If TBenefitDetails.Rows.Count > 0 Then
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(18).Value = BenefitAmmount.ToString("C2")
                            GoodPractice = BenefitAmmount
                        Else
                            BenefitAmmount = 0.0
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(18).Value = BenefitAmmount.ToString("C2")
                        End If
                    Case 40
                        LunchHourAmmount = BenefitAmmount

                    Case 90, 100, 110, 120, 130, 140, 150, 160, 170 ' Bono de buenas practicas o actitud

                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then

                            'Bono Buenas Prácticas
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(19).Value = BenefitAmmount.ToString("C2")
                            AttitudeGoodPract = BenefitAmmount
                        End If

                    Case 180, 190 ' Cantidad fija de ahorro
                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then
                            'Ahorro fijo
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(21).Value = BenefitAmmount.ToString("C2")
                            SavingAmmount = BenefitAmmount
                        End If
                    Case 200, 210 ' Bono de productividad de planta 20%, 80%

                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then

                            'Bono de productividad de planta
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(22).Value = BenefitAmmount.ToString() & "%"
                        End If
                    Case 70 ' Bono de transporte

                        'Lets verify if employee has the benefitID
                        Dim BenefDetail As New CL_Benefits
                        BenefDetail.BENEF_ID = BenefitID
                        BenefDetail.EMPL_ID = EmployeeID
                        Dim TBenefitDetails As DataTable = BenefDetail.Get_BenefitIDDetailsByEmployee()

                        If TBenefitDetails.Rows.Count > 0 Then

                            'Bono de productividad de planta
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(23).Value = BenefitAmmount.ToString("C2")
                        End If
                    Case Else
                        'let's check if employee has loans
                        Dim LoansDetail As New CL_EmployeeLoans
                        LoansDetail.EMPL_ID = EmployeeID
                        Dim TLoandsDetails As DataTable = LoansDetail.Get_AmmountOfLoandByEmployee

                        If TLoandsDetails.Rows.Count > 0 Then
                            For Each Line As DataRow In TLoandsDetails.Rows
                                'Let's validate that the ammount of discount is less or equal than the balance, else put only the balance
                                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(24).Value = Line(1).ToString()
                                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(25).Value = Line(2).ToString()
                                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(26).Value = Line(3).ToString()
                                DGV_CompleteWeekInfo.Rows(CounterLine).Cells(27).Value = Line(4).ToString()
                                PaymentAmmount = CDec(Line(4).ToString.Replace("$", ""))
                            Next
                        End If

                        DGV_CompleteWeekInfo.Rows(CounterLine).Cells(19).Value = BenefitAmmount.ToString("C2")
                        DGV_CompleteWeekInfo.Rows(CounterLine).Cells(28).Value = BenefitAmmount.ToString("C2")
                End Select
                BenefitAmmount = 0.0
            Next

            'Check salary by employee
            NewSalary = MainSalaryCalculation(CounterA, CounterF, CounterFJ, CounterR, CounterPG, CounterPSG, CounterV, BaseSalary, SundaySalary, DailySalary, LunchHourAmmount, GoodPractice, AttitudeGoodPract, SavingAmmount, PaymentAmmount, LunchHours)

            'Calculado
            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(28).Value = NewSalary.ToString("C2")

            CounterLine += 1

            SEL_MainWeekReportSalaryCalculation_PG_Progress(PB_Progress, CumulativesEmployees.Rows.Count, CounterLine)
        Next

    End Sub

    Private Function CountLetterByEmployee(ByVal EmployeeNo As Integer, ByVal Letter As String) As Integer
        Dim EmployeeId As Integer = 0
        Dim Counter As Integer = 0

        If DGV_CompleteWeekInfo.Rows.Count = 0 Then Exit Function

        For Each row As DataGridViewRow In DGV_CompleteWeekInfo.Rows
            EmployeeId = row.Cells(1).Value
            If EmployeeId = EmployeeNo Then

                'Recorrer columnas de días
                For i = 5 To DGV_CompleteWeekInfo.Columns.Count - 1
                    Dim valor = row.Cells(i).Value
                    If valor IsNot Nothing AndAlso valor.ToString() = Letter Then
                        Counter += 1
                    End If
                Next
            End If
        Next

        Return Counter
    End Function

    'Function to get the number of letters by employee in the week
    Private Function Get_CumulativesByEmployee() As DataTable
        Dim CounterLine As Integer = 0
        Dim Comment As String = ""
        Dim CounterA As Integer = 0
        Dim CounterR As Integer = 0
        Dim CounterF As Integer = 0
        Dim CounterFJ As Integer = 0
        Dim CounterPG As Integer = 0
        Dim CounterPSG As Integer = 0
        Dim CounterV As Integer = 0

        Dim CumulatesByEmployee As New DataTable
        CumulatesByEmployee.Columns.Add("EMPL_ID", GetType(Integer))
        CumulatesByEmployee.Columns.Add("ASISTANCE", GetType(String))
        CumulatesByEmployee.Columns.Add("ASIS_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("DELAYS", GetType(String))
        CumulatesByEmployee.Columns.Add("DEL_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("ABSENCE", GetType(String))
        CumulatesByEmployee.Columns.Add("ABS_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("JUST_ABSENCE", GetType(String))
        CumulatesByEmployee.Columns.Add("JABS_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("PERMISWITH", GetType(String))
        CumulatesByEmployee.Columns.Add("PG_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("PERMISWITHOUT", GetType(String))
        CumulatesByEmployee.Columns.Add("PSG_QUANT", GetType(Integer))
        CumulatesByEmployee.Columns.Add("VACATIONS", GetType(String))
        CumulatesByEmployee.Columns.Add("V_QUANT", GetType(Integer))


        'let's get cumulatives
        For Each EmployeeInfo As DataGridViewRow In DGV_CompleteWeekInfo.Rows
            Dim EmployeeID As Integer = EmployeeInfo.Cells(1).Value

            'Verify Asistances
            CounterA = CountLetterByEmployee(EmployeeID, "A")

            'Count delays
            CounterR = CountLetterByEmployee(EmployeeID, "R")

            'Count Absences
            CounterF = CountLetterByEmployee(EmployeeID, "F")

            'Count justified absence
            CounterFJ = CountLetterByEmployee(EmployeeID, "FJ")


            'Count Permissions with salary
            CounterPG = CountLetterByEmployee(EmployeeID, "PG")

            'Count Permissions without salary
            CounterPSG = CountLetterByEmployee(EmployeeID, "PSG")

            'Count Vacations
            CounterV = CountLetterByEmployee(EmployeeID, "V")

            'Add to the list
            CumulatesByEmployee.Rows.Add(EmployeeID, "A", CounterA, "R", CounterR, "F", CounterF, "FJ", CounterFJ, "PG", CounterPG, "PSG", CounterPSG, "V", CounterV)

            CounterLine += 1
        Next

        Return CumulatesByEmployee
    End Function

    Private Function MainSalaryCalculation(ByVal counterA As Integer, ByVal counterF As Integer, ByVal counterFJ As Integer, ByVal counterR As Integer,
                                                ByVal counterPG As Integer, ByVal counterPSG As Integer, ByVal counterV As Integer,
                                                ByVal BaseSalary As Decimal, ByVal SundaySalary As Decimal, ByVal DailySalary As Decimal,
                                                ByVal LunchHourAmmount As Decimal, ByVal GoodPractice As Decimal, ByVal AttitudeGoodPract As Decimal,
                                                ByVal SavingAmmount As Decimal, ByVal PaymentAmmount As Decimal, ByVal LunchHours As Decimal) As Decimal
        Dim NewSalary As Decimal = 0.0

        Select Case counterA ' Number of assistance
            Case 6
                '6 asistencias
                'Si tiene 6 asistencias sin retardos
                'salario base + bono de productividad + proporcional de domingo 
                NewSalary = BaseSalary + GoodPractice + AttitudeGoodPract + SundaySalary
                NewSalary = NewSalary + (LunchHourAmmount * LunchHours)
                NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
            Case Else
                'Si hay una falta injustificada
                'Si tiene 5 asistencias y 1 falta injustificada
                'salario base de 5 dias-1/7 del proporcional de domingo-1 dia bonos de comida- 1 dia de bono de productividad-se le descuenta el bono de todas la semana del bono de buens practicas  
                If counterA = 5 And counterF = 1 Then
                    NewSalary = DailySalary * 5                          ' salario base de 5 dias
                    NewSalary = NewSalary - (SundaySalary / 7)           ' -1/7 del proporcional de domingo
                    NewSalary = NewSalary - (LunchHourAmmount * (LunchHours - 1))           ' -1 dia bonos de comida (-50)
                    NewSalary = NewSalary - (GoodPractice / 7)           ' -1 dia de bono de productividad
                    NewSalary = NewSalary + 0                            ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
                End If

                'Si hay dos faltas injustificadas
                'Si tiene 4 asistencias y 2 faltas injustificadas	
                'Salario base de 4 dias-2/7 del proporcional del domingo- 2 dias de bono de comida y productividad- se le descuenta el bono completo de toda la semana de buenas practicas 
                If counterA = 4 And counterF = 2 Then
                    NewSalary = DailySalary * 4                          ' salario base de 4 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 2)     ' -2/7 del proporcional de domingo
                    NewSalary = NewSalary - (LunchHourAmmount * (LunchHours - 2))       ' -2 dia bonos de comida (-50)
                    NewSalary = NewSalary - ((GoodPractice / 7) * 2)     ' -2 dia de bono de productividad
                    NewSalary = NewSalary + 0                            ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
                End If

                'Si hay tres faltas injustificadas
                'Si tiene 3 asistencias y 3 faltas injustificadas	
                'salario base de 3 dias- 3/7 del proporcional del domingo-3 dias del bono de productividad- se le descuenta bono completo de toda la semana de buenas practicas
                If counterA = 3 And counterF = 3 Then
                    NewSalary = DailySalary * 3                          ' salario base de 3 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 3)     ' -3/7 del proporcional de domingo
                    'NewSalary = NewSalary - (LunchHourAmmount * 3)      ' -3 dia bonos de comida (-50)
                    NewSalary = NewSalary - ((GoodPractice / 7) * 3)     ' -3 dia de bono de productividad
                    NewSalary = NewSalary + 0                            ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos                    
                End If

                'Si hay cuatro faltas injustificadas
                'Si tiene 2 asistencias y 4 faltas injustificadas	
                'salario base de 2 dias- 4/7 del proporcional del domingo-4 dias del bono de productividad- se le descuenta bono completo de toda la semana de buenas practicas

                If counterA = 2 And counterF = 4 Then
                    NewSalary = DailySalary * 3                          ' salario base de 2 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 4)     ' -4/7 del proporcional de domingo
                    NewSalary = NewSalary - ((GoodPractice / 7) * 4)     ' -4 dia de bono de productividad
                    NewSalary = NewSalary + 0                            ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
                End If

                'Si hay cinco faltas injustificadas
                'Si tiene 1 asistencia y 5 faltas injustificadas	
                'salario base de 1 dias- 5/7 del proporcional del domingo-5 dias del bono de productividad- se le descuenta bono completo de toda la semana de buenas practicas

                If counterA = 1 And counterF = 5 Then
                    NewSalary = DailySalary * 1                          ' salario base de 2 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 5)     ' -5/7 del proporcional de domingo
                    NewSalary = NewSalary - ((GoodPractice / 7) * 5)     ' -5 dia de bono de productividad
                    NewSalary = NewSalary + 0                            ' se le descuenta el bono de todas la semana del bono de buens practicas (+ 0)
                    NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
                End If

                'Si hay seis faltas injustificadas
                'Si tuvo 6 faltas injustificadas	
                'salario base de 0 dias- 6/7 del proporcional del domingo-no se le paga ningun bono 

                If counterA = 0 And counterF = 6 Then
                    NewSalary = DailySalary * 0                          ' salario base de 2 dias
                    NewSalary = NewSalary - ((SundaySalary / 7) * 6)     ' -6/7 del proporcional de domingo
                    NewSalary = NewSalary + 0                            ' no se le paga ningun bono
                    NewSalary = NewSalary + 0                            ' no se le paga ningun bono
                    NewSalary = NewSalary - SavingAmmount                ' Menos la cantidad a ahorrar
                    NewSalary = NewSalary - PaymentAmmount               ' Menos el pago por créditos
                End If
                '-----------------------------------

                ''Si hay una falta justificada,
                'If counterA = 5 And counterFJ = 1 Then 'se le paga exclusivamente el sueldo del día sin ningún otro bono
                '    NewSalary = ((BaseSalary / 7) * 5) + ((BenefitAmmount / 7) * 5) 'se le paga 5 días completos + proporcional al bono de actitud
                '    NewSalary = NewSalary + ((BaseSalary / 7) * 1)                  ' + un día completo pero sin el proporcionale al bono de actitud de día
                '    NewSalary = NewSalary + ((SundaySalary / 7) * 6)                ' + Proporcional a 6/7 del domingo
                'End If

                ''Si tuvo 5 asistencias y 1 retardo 
                'If counterA = 5 And counterR = 1 Then
                '    'NewSalary = BaseSalary - ((BenefitAmmount / 7) * 1) ' Se les descuentan $58.33 que es la parte proporcional al bono semanal de $350 por productividad.
                '    'NewSalary = NewSalary + SundaySalary
                'End If

                ''Si tuvo 4 asistencias y 2 retardo 
                'If counterA = 4 And counterR = 2 Then
                '    NewSalary = BaseSalary + ((BenefitAmmount / 7) * 6) ' se descuenta 1 día del de actitud.
                '    NewSalary = NewSalary + SundaySalary
                'End If

                ''Si tuvo 3 asistencias y 3 retardo 
                'If counterA = 3 And counterR = 3 Then
                '    NewSalary = BaseSalary + 0 ' regresan al empleado, pierde el bono de actitud de la semana.
                '    NewSalary = NewSalary + SundaySalary
                'End If

                ''Si tuvo 2 asistencias y 4 retardo 
                'If counterA = 2 And counterR = 4 Then 'Si justificó, solo pierde el.bono de los dias que falto, si no justificó si pierde el.bono de toda la.sema a
                '    'NewSalary = BaseSalary + 0 ' regresan al empleado, pierde el bono de actitud de la semana.
                '    'NewSalary = NewSalary + SundaySalary
                'End If
        End Select

        Return NewSalary
    End Function

    Private Sub DGV_CompleteWeekInfo_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_CompleteWeekInfo.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_CompleteWeekInfo.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_CompleteWeekInfo.Rows(hit.RowIndex)

            Dim Employee_Id As Integer = CInt(row.Cells(1).Value)

            Dim EmployeeRecords As New CL_RecordsByEmployee
            Dim EmployeeInfo = EmployeeRecords.Get_WeekRecordsDetailsBYEmployee(DTP_StartDate.Value, DTP_EndDate.Value, Employee_Id)

            DGV_BenefitsDetailsByEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_BenefitsDetailsByEmployee.AutoResizeColumns()
            DGV_BenefitsDetailsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DGV_BenefitsDetailsByEmployee.DataSource = EmployeeInfo
        End If

    End Sub

    Private Sub CB_Confirmation_MouseClick(sender As Object, e As MouseEventArgs) Handles CB_Confirmation.MouseClick
        If DGV_CompleteWeekInfo.Rows.Count > 0 Then
            If CB_Confirmation.Checked = True Then
                If MessageBox.Show("¿Confirma la liberación de nómina para esta semana?", "Aviso de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BT_FinalConfirmation.Enabled = True
                Else
                    CB_Confirmation.Checked = False
                    BT_FinalConfirmation.Enabled = False
                End If
            Else
                BT_FinalConfirmation.Enabled = False
            End If
        End If

    End Sub

    Private Sub BT_FinalConfirmation_Click(sender As Object, e As EventArgs) Handles BT_FinalConfirmation.Click
        For Each Item As DataGridViewRow In DGV_CompleteWeekInfo.Rows
            If Item.Cells(21).Value > 0 Then

                'Register automatic saving
                Dim EmployeeSaving As New CL_RecordsByEmployeeMoneySaved
                EmployeeSaving.EMPL_ID = CInt(Item.Cells(1).Value)
                EmployeeSaving.DREMPL_AMM = CDec(Item.Cells(21).Value)
                EmployeeSaving.DREMPL_TYPE = 2
                EmployeeSaving.REMPL_RDATE = Today
                EmployeeSaving.REMPL_CREBY = AppUser
                EmployeeSaving.InsertAutomaticSaving()
            End If
        Next
    End Sub

    Public Sub SEL_MainWeekReportSalaryCalculation_PG_Progress(progress As System.Windows.Forms.ProgressBar, totalItems As Integer, currentItem As Integer)

        If totalItems <= 0 Then Exit Sub

        Dim percentage As Integer = CInt((currentItem / totalItems) * 100)

        If percentage > 100 Then percentage = 100
        If percentage < 0 Then percentage = 0

        progress.Value = percentage

    End Sub

    Private Sub DGV_CompleteWeekInfo_Sorted(sender As Object, e As EventArgs) Handles DGV_CompleteWeekInfo.Sorted
        PaintCells_Sorted()
    End Sub
End Class
