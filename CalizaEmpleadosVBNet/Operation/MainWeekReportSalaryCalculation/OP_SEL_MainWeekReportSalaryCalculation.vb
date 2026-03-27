Imports System.Diagnostics.Metrics
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports DocumentFormat.OpenXml.Bibliography
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Math
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Microsoft.Identity.Client
Imports System.Drawing

Public Class OP_SEL_MainWeekReportSalaryCalculation
    Dim SelectedEmployeeID As Integer = 0

    Private Sub OP_SEL_MainWeekReportSalaryCalculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_WeekSelector.Value = Today
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
                        'If there are records then check for abssence justification
                        Dim EmployeeRecord As New CL_RecordsByEmployee
                        EmployeeRecord.EMPL_ID = CInt(emp("ID Empleado"))
                        EmployeeRecord.DREMPL_DATE = currentDate.ToString("yyyy-MM-dd")
                        Dim DelayJustified As Integer = 130 ' Retardo Justificado - Registro Manual

                        Dim EmployeeRecords140 As DataTable = EmployeeRecord.Get_CheckAbsenceJustified(CInt(emp("ID Empleado")), currentDate.ToString("yyyy-MM-dd"), DelayJustified)
                        If EmployeeRecords140.Rows.Count > 0 Then
                            newRow(i + 6) = 130 ' Jornada Completa - Falta Justificada
                        Else
                            newRow(i + 6) = found(0)("MOVE_ID")
                        End If
                    Else
                        newRow(i + 6) = found(0)("MOVE_ID")
                    End If
                End If


            Next

            EmployeesInfo.Rows.Add(newRow)

        Next

        EmployeesInfo.Columns.Add("S. Diario", GetType(String))
        EmployeesInfo.Columns.Add("Ext. S", GetType(String))
        EmployeesInfo.Columns.Add("Ext. D", GetType(String))
        EmployeesInfo.Columns.Add("Ext. T", GetType(String))
        EmployeesInfo.Columns.Add("H. Comida", GetType(Decimal))
        EmployeesInfo.Columns.Add("Calculado", GetType(String))

        'DGV_CompleteWeekInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        'DGV_CompleteWeekInfo.AutoResizeColumns()
        DGV_CompleteWeekInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_CompleteWeekInfo.DataSource = EmployeesInfo
        DGV_CompleteWeekInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        'DGV_CompleteWeekInfo.Columns("Empresa").Width = 80
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

        DGV_CompleteWeekInfo.Columns("S. Diario").Width = 65
        DGV_CompleteWeekInfo.Columns("S. Diario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("H. Comida").Width = 70
        DGV_CompleteWeekInfo.Columns("H. Comida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_CompleteWeekInfo.Columns("Ext. S").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Ext. S").Width = 50
        DGV_CompleteWeekInfo.Columns("Ext. D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Ext. D").Width = 50
        DGV_CompleteWeekInfo.Columns("Ext. T").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Ext. T").Width = 50
        DGV_CompleteWeekInfo.Columns("Calculado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV_CompleteWeekInfo.Columns("Calculado").Width = 65

        PaintCells()
        MainSalaryCalculation()

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
                End Select

            Next

        Next

    End Sub

    Private Sub DTP_WeekSelector_MouseLeave(sender As Object, e As EventArgs)
        DTP_StartDate.Visible = True

        DTP_EndDate.Visible = True
    End Sub

    'Private Sub DGV_CompleteWeekInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs)

    '    If e.RowIndex < 0 Then Exit Sub

    '    Dim row As DataGridViewRow = DGV_CompleteWeekInfo.Rows(e.RowIndex)

    '    SelectedEmployeeID = CInt(row.Cells(1).Value)

    '    Dim EmployeeRecords As New CL_RecordsByEmployee
    '    Dim EmployeeInfo = EmployeeRecords.Get_WeekRecordsDetailsBYEmployee(DTP_StartDate.Value, DTP_EndDate.Value, SelectedEmployeeID)

    '    DGV_BenefitsDetailsByEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '    DGV_BenefitsDetailsByEmployee.AutoResizeColumns()
    '    DGV_BenefitsDetailsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '    DGV_BenefitsDetailsByEmployee.DataSource = EmployeeInfo

    'End Sub

    Private Sub DTP_WeekSelector_ValueChanged_1(sender As Object, e As EventArgs) Handles DTP_WeekSelector.ValueChanged
        LoadWeek()
        DTP_StartDate.Visible = True
        DTP_EndDate.Visible = True

    End Sub

    Private Sub MainSalaryCalculation()
        Dim CumulativesEmployees As DataTable = Get_CumulativesByEmployee()
        Dim CounterLine As Integer = 0

        For Each EmployeeCum As DataRow In CumulativesEmployees.Rows
            Dim CounterOfDays As Integer = 0
            Dim EmployeeID As Integer = CInt(EmployeeCum(0))
            Dim CounterA As Integer = CInt(EmployeeCum(2))
            Dim CounterR As Integer = CInt(EmployeeCum(4))
            Dim CounterF As Integer = CInt(EmployeeCum(6))
            Dim CounterFJ As Integer = CInt(EmployeeCum(8))

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
            Dim LunchHours As Decimal = 0
            For Each LunchRecord As DataRow In LunchRecords.Rows
                LunchHours = CDec(LunchRecord(7))
            Next

            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(17).Value = LunchHours


            Dim Benefits As New CL_Benefits
            Dim ListOfBenefits As DataTable = Benefits.Get_AllActiveManualAutomaticBenefits

            'Let's scroll through the list of benefits
            For Each Benefit As DataRow In ListOfBenefits.Rows
                Dim Comment As String = ""
                Dim BenefitID As Integer = CInt(Benefit(0))
                Dim BenefitAmmount As Decimal = CInt(Benefit(4))
                Dim DailyBenefit As Decimal = BenefitAmmount / 7

                Select Case BenefitID
                    Case 10 ' Bono de buenas practicas o actitud
                        NewSalary = CalculationAttitudeBenefit(CounterA, CounterF, CounterFJ, CounterR, BaseSalary, BenefitAmmount, SundaySalary, DailySalary)
                        If CounterA = 6 Then
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(9).Value = "A"
                            DGV_CompleteWeekInfo.Rows(CounterLine).Cells(9).Style.BackColor = System.Drawing.Color.FromArgb(CByte(192), CByte(255), CByte(192))
                            Comment = "Empleado tuvo asistencia completa, se le otorga bono de actitud y buenas prácticas + día domingo completo."
                        End If
                        DGV_CompleteWeekInfo.Rows(CounterLine).Cells(18).Value = NewSalary.ToString("C2")
                End Select
            Next
            CounterLine += 1
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

    Private Function Get_CumulativesByEmployee() As DataTable
        Dim CounterLine As Integer = 0
        Dim Comment As String = ""
        Dim CounterA As Integer = 0
        Dim CounterR As Integer = 0
        Dim CounterF As Integer = 0
        Dim CounterFJ As Integer = 0

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

            'Add to the list
            CumulatesByEmployee.Rows.Add(EmployeeID, "A", CounterA, "R", CounterR, "F", CounterF, "FJ", CounterFJ)

            CounterLine += 1
        Next

        Return CumulatesByEmployee
    End Function

    Private Function CalculationAttitudeBenefit(ByVal counterA As Integer, ByVal counterF As Integer, ByVal counterFJ As Integer, ByVal counterR As Integer,
                                                ByVal BaseSalary As Decimal, ByVal BenefitAmmount As Decimal, ByVal SundaySalary As Decimal, ByVal DailySalary As Decimal) As Decimal
        Dim NewSalary As Decimal = 0.0

        Select Case counterA
            Case 6
                NewSalary = BaseSalary + BenefitAmmount + SundaySalary
            Case Else
                'Si hay una falta injustificada
                If counterA = 5 And counterF = 1 Then
                    NewSalary = (BaseSalary + 0)                        ' no se otorga el bono de actitud de toda la semana,
                    NewSalary = NewSalary - DailySalary                 ' se descuenta el sueldo del día,
                    NewSalary = NewSalary + ((SundaySalary / 7) * 6)    ' no se otorga el proporcional al domingo, solo se dan 6/7 del domingo
                    '************y el descuento de 1 día por cada bono que tenga el empleado**************
                End If

                'Si hay dos faltas injustificadas
                If counterA = 4 And counterF = 2 Then
                    NewSalary = (BaseSalary + 0)                        'no se otorga el bono de actitud de toda la semana,
                    NewSalary = NewSalary - (DailySalary * 2)           ' se le descuentan dos  días de sueldo,
                    NewSalary = NewSalary + ((SundaySalary / 7) * 5)    'no se otorga el proporcional al domingo, solo se dan 5/7 del domingo
                    '************y el descuento de 1 día por cada bono que tenga el empleado**************
                End If

                'Si hay una falta justificada,
                If counterA = 5 And counterFJ = 1 Then 'se le paga exclusivamente el sueldo del día sin ningún otro bono
                    NewSalary = ((BaseSalary / 7) * 5) + ((BenefitAmmount / 7) * 5) 'se le paga 5 días completos + proporcional al bono de actitud
                    NewSalary = NewSalary + ((BaseSalary / 7) * 1)                  ' + un día completo pero sin el proporcionale al bono de actitud de día
                    NewSalary = NewSalary + ((SundaySalary / 7) * 6)                ' + Proporcional a 6/7 del domingo
                End If

                'Si tuvo 5 asistencias y 1 retardo 
                If counterA = 5 And counterR = 1 Then
                    'NewSalary = BaseSalary - ((BenefitAmmount / 7) * 1) ' Se les descuentan $58.33 que es la parte proporcional al bono semanal de $350 por productividad.
                    'NewSalary = NewSalary + SundaySalary
                End If

                'Si tuvo 4 asistencias y 2 retardo 
                If counterA = 4 And counterR = 2 Then
                    NewSalary = BaseSalary + ((BenefitAmmount / 7) * 6) ' se descuenta 1 día del de actitud.
                    NewSalary = NewSalary + SundaySalary
                End If

                'Si tuvo 3 asistencias y 3 retardo 
                If counterA = 3 And counterR = 3 Then
                    NewSalary = BaseSalary + 0 ' regresan al empleado, pierde el bono de actitud de la semana.
                    NewSalary = NewSalary + SundaySalary
                End If

                'Si tuvo 2 asistencias y 4 retardo 
                If counterA = 2 And counterR = 4 Then 'Si justificó, solo pierde el.bono de los dias que falto, si no justificó si pierde el.bono de toda la.sema a
                    'NewSalary = BaseSalary + 0 ' regresan al empleado, pierde el bono de actitud de la semana.
                    'NewSalary = NewSalary + SundaySalary
                End If
        End Select

        Return NewSalary
    End Function

End Class
