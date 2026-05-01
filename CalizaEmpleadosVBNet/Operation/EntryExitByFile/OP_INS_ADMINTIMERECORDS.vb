Imports DocumentFormat.OpenXml.Office2016.Excel
Imports DocumentFormat.OpenXml.Spreadsheet
Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar

Public Class OP_INS_ADMINTIMERECORDS
    Private dtpHora As New DateTimePicker()

    Private Sub OP_INS_ADMINTIMERECORDS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DTP_RegisterDate.Enabled = False
        BT_Register.Enabled = False

        CB_Options.Items.Add(New ComboItem With {.Id = 10, .Descripcion = "Seleccione una opción"})
        CB_Options.Items.Add(New ComboItem With {.Id = 20, .Descripcion = "Registro de entrada"})
        CB_Options.Items.Add(New ComboItem With {.Id = 30, .Descripcion = "Registro de salida"})
        CB_Options.DisplayMember = "Descripcion"
        CB_Options.ValueMember = "Id"
        CB_Options.SelectedIndex = 0


        Dim obj As New CL_Employee
        Dim Employees As DataTable = obj.Get_AllAdministrativeEmployees
        DGV_EmployeesInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_EmployeesInfo.AutoResizeColumns()
        DGV_EmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_EmployeesInfo.DataSource = Employees

        'DGV_EmployeesInfo.Columns.Add("Hora HH:MM", "Hora HH:MM")
        Dim col As New DataGridViewTextBoxColumn()
        col.Name = "Hora"
        col.HeaderText = "Hora HH:MM"
        col.DefaultCellStyle.NullValue = ""
        DGV_EmployeesInfo.Columns.Add(col)

    End Sub


    Private Sub CB_Options_Leave(sender As Object, e As EventArgs) Handles CB_Options.Leave

        DTP_RegisterDate.Enabled = True

    End Sub

    Private Sub DGV_EmployeesInfo_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DGV_EmployeesInfo.CellValidating

        If DGV_EmployeesInfo.Columns(e.ColumnIndex).Name = "Hora" Then

            Dim input As String = e.FormattedValue.ToString().Trim()

            ' Permitir vacío si quieres manejarlo después
            If input = "" Then Exit Sub

            Dim parsedTime As DateTime

            If Not DateTime.TryParseExact(input,
                                      "hh:mm tt",
                                      Globalization.CultureInfo.InvariantCulture,
                                      Globalization.DateTimeStyles.None,
                                      parsedTime) Then

                MessageBox.Show("Formato inválido. Usa HH:mm AM/PM (ej: 07:30 AM)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                e.Cancel = True ' 🔴 evita salir de la celda
            Else
                ' Opcional: normaliza el formato
                DGV_EmployeesInfo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = parsedTime.ToString("hh:mm tt", Globalization.CultureInfo.InvariantCulture)
            End If

        End If

    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        If DGV_DataValidation.Rows.Count = 0 Then Exit Sub
        RegisterDGVContent()


        'Dim Asistance_Type As Integer = 0

        'For Each row As DataGridViewRow In DGV_EmployeesInfo.Rows
        '    Dim cellValue = row.Cells("Hora").Value

        '    If cellValue Is Nothing OrElse IsDBNull(cellValue) OrElse String.IsNullOrWhiteSpace(cellValue.ToString()) Then
        '        ' Saltar esta fila
        '        Continue For
        '    End If

        '    Dim EmployeeID As Integer = CInt(row.Cells(3).Value)
        '    Dim timeText As String = row.Cells("Hora HH:MM").Value.ToString()

        '    Dim selectedDate As Date = DTP_RegisterDate.Value.Date
        '    Dim parsedTime As DateTime

        '    If Not DateTime.TryParseExact(timeText,
        '                      "hh:mm tt",
        '                      Globalization.CultureInfo.InvariantCulture,
        '                      Globalization.DateTimeStyles.None,
        '                      parsedTime) Then

        '        MessageBox.Show("Formato de hora inválido para el empleado: " & EmployeeID)
        '        Continue For
        '    End If

        '    Dim fullDateTime As DateTime = selectedDate.Date.Add(parsedTime.TimeOfDay)
        '    Dim fileDate As Date = fullDateTime.Date
        '    Dim timeValue As DateTime = fullDateTime

        '    Dim Type As ComboItem = CType(CB_Options.SelectedItem, ComboItem)
        '    Dim FileTye As Integer = Type.Id

        '    If FileTye = 30 AndAlso timeValue.Hour < 12 Then
        '        timeValue = timeValue.AddHours(12)
        '        fullDateTime = fullDateTime.AddHours(12)
        '    End If

        '    Dim Comment As String = ""

        '    If FileTye = 20 Then
        '        ' ENTRADA
        '        Dim toleranceTime As DateTime = DateTime.Parse("07:10:00")
        '        Dim limitTime As DateTime = DateTime.Parse("07:00:00")

        '        Comment = "Puntual"
        '        Asistance_Type = 10

        '        If timeValue.TimeOfDay > limitTime.TimeOfDay AndAlso timeValue.TimeOfDay <= toleranceTime.TimeOfDay Then
        '            Comment = "Tolerancia"
        '            Asistance_Type = 20
        '        ElseIf timeValue.TimeOfDay > toleranceTime.TimeOfDay Then
        '            Comment = "Retardo"
        '            Asistance_Type = 30
        '        End If

        '    Else
        '        ' SALIDA
        '        Dim ToleranceEnd As DateTime = DateTime.Parse("18:00:00")
        '        Dim EndTime As DateTime = DateTime.Parse("17:30:00")
        '        Dim EndSaturdayTime As DateTime = DateTime.Parse("13:30:00")
        '        Dim ToleranceSaturdayEnd As DateTime = DateTime.Parse("14:00:00")

        '        Comment = "Salida Puntual"
        '        Asistance_Type = 40

        '        If (fileDate.DayOfWeek >= DayOfWeek.Monday And fileDate.DayOfWeek <= DayOfWeek.Friday) AndAlso
        '           timeValue.TimeOfDay < EndTime.TimeOfDay Then
        '            Comment = "Salida anticipada"
        '            Asistance_Type = 50

        '        ElseIf timeValue.TimeOfDay > ToleranceEnd.TimeOfDay Then
        '            Comment = "Salida con tiempo adicional"
        '            Asistance_Type = 55
        '        End If
        '    End If

        '    Select Case Asistance_Type
        '        Case 10 ' Entrada puntual
        '            InserEntryRecordByEmployee(EmployeeID, Asistance_Type, AppUser, Date.Now, fullDateTime.Date, fullDateTime)
        '        Case 20 ' Entrada con Tolerancia
        '            InserEntryRecordByEmployee(EmployeeID, Asistance_Type, AppUser, Date.Now, fullDateTime.Date, fullDateTime)
        '        Case 30 ' Retardo
        '            InserEntryRecordByEmployee(EmployeeID, Asistance_Type, AppUser, Date.Now, fullDateTime.Date, fullDateTime)
        '        Case 40 ' Salida Puntual
        '            InserExitRecordByEmployee(EmployeeID, Asistance_Type, AppUser, Date.Now, fullDateTime.Date, fullDateTime)
        '        Case 50 ' Salida Anticipada
        '            InserExitRecordByEmployee(EmployeeID, Asistance_Type, AppUser, Date.Now, fullDateTime.Date, fullDateTime)
        '        Case 55 ' Salida con Tiempo Adicional
        '            InserExitRecordByEmployee(EmployeeID, Asistance_Type, AppUser, Date.Now, fullDateTime.Date, fullDateTime)
        '    End Select

        '    'Make Full Time Calculation
        '    'LoadRecordByEmployee(FileTye, "Admin_" + Date.Today.ToString("ddmmaaaa"))

        '    If FileTye = 20 Then
        '        Display_EntryRecords()
        '    Else
        '        Display_ExitRecords()
        '    End If
        'Next
    End Sub

    Private Sub RegisterDGVContent()
        Dim FileName As String = "Admin_" & DTP_RegisterDate.Value.ToString("yyyyMMdd")
        Dim conn As New SqlConnection(My.Settings.ConnectionString)
        Dim trans As SqlTransaction = Nothing

        Dim Type As ComboItem = CType(CB_Options.SelectedItem, ComboItem)
        Dim FileTye As Integer = Type.Id

        conn.Open()
        Try
            Dim NumberOfRecords As Integer = DGV_DataValidation.Rows.Count
            Dim AssistanceFileHeader As New CL_EntryExitFile(FileTye, FileName, NumberOfRecords, "Manual", AppUser, Date.Now)

            'VALIDAR SI EL ARCHIVO YA EXISTE
            If AssistanceFileHeader.FileAlreadyExists(conn) Then
                MessageBox.Show("El archivo: " & FileName & vbCrLf & "ya fue registrado anteriormente.", "Archivo duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DGV_DataValidation.Columns.Clear()
                conn.Close()
                Exit Sub
            End If

            'INICIAR TRANSACCIÓN SOLO SI NO EXISTE
            trans = conn.BeginTransaction()
            Dim L_HFILE_ID As Integer = AssistanceFileHeader.InsertAsistanceFileHeader(conn, trans)

            If L_HFILE_ID <> 0 Then
                For Each Line As DataGridViewRow In DGV_DataValidation.Rows
                    Dim Item As New CL_EntryExitFile
                    Item.HFILE_ID = L_HFILE_ID
                    Item.EMPL_ID = Line.Cells("EmpID").Value
                    If Line.Cells("Comment").Value = "Puntual" Then
                        Item.ENTTYPE_ID = 10
                    ElseIf Line.Cells("Comment").Value = "Tolerancia" Then
                        Item.ENTTYPE_ID = 20
                    ElseIf Line.Cells("Comment").Value = "Retardo" Then
                        Item.ENTTYPE_ID = 30
                    ElseIf Line.Cells("Comment").Value = "Salida Puntual" Then
                        Item.ENTTYPE_ID = 40
                    ElseIf Line.Cells("Comment").Value = "Salida anticipada" Then
                        Item.ENTTYPE_ID = 50
                    ElseIf Line.Cells("Comment").Value = "Salida con tiempo adicional" Then
                        Item.ENTTYPE_ID = 55
                    End If


                    Item.IFILE_DATE = DTP_RegisterDate.Value.Date
                    Item.IFILE_TIME = Line.Cells("TIME").Value
                    Item.IFILE_DATI = Line.Cells("FullDateTime").Value
                    Item.InsertAsistanceFileItem(conn, trans)
                Next
                trans.Commit()

                'Make Full Time Calculation
                LoadRecordByEmployee(FileTye, FileName)

                If FileTye = 20 Then
                    Display_EntryRecords()
                Else
                    Display_ExitRecords()
                End If

                'InitializationOfFields()
                CB_Options.Enabled = True
            End If
        Catch ex As Exception
            If trans IsNot Nothing Then
                trans.Rollback()
            End If
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Display_EntryRecords()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()
        DGV_Registerinformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Registerinformation.AutoResizeColumns()
        DGV_Registerinformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Registerinformation.DataSource = RecordsByEmployees.Get_AllRecordsByEntryFile(DTP_RegisterDate.Value)
    End Sub

    Private Sub Display_ExitRecords()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()
        DGV_Registerinformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Registerinformation.AutoResizeColumns()
        DGV_Registerinformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Registerinformation.DataSource = RecordsByEmployees.Get_AllRecordsByExitFile(DTP_RegisterDate.Value)
    End Sub

    Private Function LoadRecordByEmployee(ByVal HFILE_TYPE As Integer, ByVal HFILE_NAME As String) As Boolean
        Dim Result As Boolean = False
        Dim Employee = New CL_Employee()
        Dim ActiveEmployees As DataTable = Employee.Get_AllAdministrativeEmployees
        Dim AsistanceTypes As DataTable

        Dim Type As ComboItem = CType(CB_Options.SelectedItem, ComboItem)
        Dim FileTye As Integer = Type.Id

        'Check all active employees
        For Each EmployeeRow As DataRow In ActiveEmployees.Rows
            Dim RecordByEmployee As New CL_EntryExitFile
            RecordByEmployee.EMPL_ID = CInt(EmployeeRow(2))
            RecordByEmployee.HFILE_TYPE = FileTye
            RecordByEmployee.HFILE_NAME = HFILE_NAME
            AsistanceTypes = RecordByEmployee.Get_AllAssistanceTypes()

            'Check all asistance types by employee
            For Each Asistance As DataRow In AsistanceTypes.Rows
                '8 - Empl_ID
                '9 - Entry Type
                '10 - date
                '11 - time
                '12 - datetime
                Dim RecordByEmployeeType As New CL_EntryExitFile
                Dim EntryExitFileRecords As DataTable
                RecordByEmployeeType.EMPL_ID = CInt(EmployeeRow(2))
                RecordByEmployeeType.HFILE_TYPE = FileTye
                RecordByEmployeeType.HFILE_NAME = HFILE_NAME
                RecordByEmployeeType.ENTTYPE_ID = CInt(Asistance(0))
                EntryExitFileRecords = RecordByEmployeeType.Get_EntryExitRecordByEmployeeIDEnTypeInFIle()

                Select Case Asistance(0)
                    Case 10 ' Entrada puntual
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserEntryRecordByEmployee(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 20 ' Entrada con Tolerancia
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserEntryRecordByEmployee(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 30 ' Retardo
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserEntryRecordByEmployee(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 40 ' Salida Puntual
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserExitRecordByEmployee(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 50 ' Salida Anticipada
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserExitRecordByEmployee(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 55 ' Salida con Tiempo Adicional
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserExitRecordByEmployee(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 60 ' Falta
                        If FileTye = 20 Then
                            Dim AsistanceCheck As New CL_EntryExitFile
                            Dim AbsenceRecors As DataTable
                            AsistanceCheck.EMPL_ID = CInt(EmployeeRow(2))
                            AsistanceCheck.HFILE_NAME = HFILE_NAME
                            AsistanceCheck.HFILE_TYPE = FileTye
                            AbsenceRecors = AsistanceCheck.Get_AsistanceCheck()

                            If AbsenceRecors.Rows.Count = 0 Then
                                AbsenceRecordByEmployee(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DTP_RegisterDate.Value.Date)
                            End If
                        End If
                    Case 70 ' Jornada Completa 10/40
                        Dim RecordsByEmployeeType1040 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        RecordsByEmployeeType1040.EMPL_ID = CInt(EmployeeRow(2))
                        RecordsByEmployeeType1040.HFILE_NAME = HFILE_NAME
                        RecordsByEmployeeType1040.ENTTYPE_ID = 10  ' Entrada puntual 
                        RecordsByEmployeeType1040.EXTTYPE_ID = 40  ' Salida puntual 
                        IdealEntryRecords = RecordsByEmployeeType1040.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 10 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 40 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            IdealFullTimeRecordByEmployee1040(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 80 'Jornada Completa - Entrada con tolerancia salida puntual 20/40
                        Dim RecordsByEmployeeType2040 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        RecordsByEmployeeType2040.EMPL_ID = CInt(EmployeeRow(2))
                        RecordsByEmployeeType2040.HFILE_NAME = HFILE_NAME
                        RecordsByEmployeeType2040.ENTTYPE_ID = 20  ' Entrada con Tolerancia
                        RecordsByEmployeeType2040.EXTTYPE_ID = 40  ' Salida puntual 
                        IdealEntryRecords = RecordsByEmployeeType2040.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 20 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 40 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            CompleteTimeRecordByEmployee2040(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 85 'Jornada Completa con Tiempo Adicional 20/55
                        Dim IncompleteRecordByEmployee2055 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee2055.EMPL_ID = CInt(EmployeeRow(2))
                        IncompleteRecordByEmployee2055.HFILE_NAME = HFILE_NAME
                        IncompleteRecordByEmployee2055.ENTTYPE_ID = 20  ' Entrada con Tolerancia
                        IncompleteRecordByEmployee2055.EXTTYPE_ID = 55  ' Salida Anticipada
                        IdealEntryRecords = IncompleteRecordByEmployee2055.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim Count As Integer = 0
                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 20 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 55 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            IncompleteTimeRecordByEmployee2055(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 90 'Jornada Incompleta - Entrada puntual salida anticipada 10/50
                        Dim IncompleteRecordByEmployee1050 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee1050.EMPL_ID = CInt(EmployeeRow(2))
                        IncompleteRecordByEmployee1050.HFILE_NAME = HFILE_NAME
                        IncompleteRecordByEmployee1050.ENTTYPE_ID = 10  ' Entrada Puntual
                        IncompleteRecordByEmployee1050.EXTTYPE_ID = 50  ' Salida Anticipada
                        IdealEntryRecords = IncompleteRecordByEmployee1050.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim Count As Integer = 0
                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 10 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 50 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            IncompleteTimeRecordByEmployee1050(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 100 'Jornada Incompleta - Entrada con retardo salida anticipada 30/50
                        Dim IncompleteRecordByEmployee3050 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee3050.EMPL_ID = CInt(EmployeeRow(2))
                        IncompleteRecordByEmployee3050.HFILE_NAME = HFILE_NAME
                        IncompleteRecordByEmployee3050.ENTTYPE_ID = 30  ' Retardo
                        IncompleteRecordByEmployee3050.EXTTYPE_ID = 50  ' Salida Anticipada
                        IdealEntryRecords = IncompleteRecordByEmployee3050.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim Count As Integer = 0
                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 30 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 50 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            IncompleteTimeRecordByEmployee3050(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 110 'Jornada Incompleta - Entrada con retardo salida puntual       30/40
                        Dim IncompleteRecordByEmployee3040 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee3040.EMPL_ID = CInt(EmployeeRow(2))
                        IncompleteRecordByEmployee3040.HFILE_NAME = HFILE_NAME
                        IncompleteRecordByEmployee3040.ENTTYPE_ID = 30  ' Retardo
                        IncompleteRecordByEmployee3040.EXTTYPE_ID = 40  ' Salida Puntual
                        IdealEntryRecords = IncompleteRecordByEmployee3040.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim Count As Integer = 0
                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 30 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 40 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            IncompleteTimeRecordByEmployee3040(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 120 'Jornada Incompleta - Entrada con tolerancia salida anticipada 20/50
                        Dim IncompleteRecordByEmployee2050 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee2050.EMPL_ID = CInt(EmployeeRow(2))
                        IncompleteRecordByEmployee2050.HFILE_NAME = HFILE_NAME
                        IncompleteRecordByEmployee2050.ENTTYPE_ID = 20  ' Entrada con Tolerancia
                        IncompleteRecordByEmployee2050.EXTTYPE_ID = 50  ' Salida Anticipada
                        IdealEntryRecords = IncompleteRecordByEmployee2050.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim Count As Integer = 0
                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 20 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 50 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            IncompleteTimeRecordByEmployee2050(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 122 'Jornada Desfasada - Entrada con Retardo y Salida con tiempo adicional 30/55
                        Dim IncompleteRecordByEmployee3055 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee3055.EMPL_ID = CInt(EmployeeRow(2))
                        IncompleteRecordByEmployee3055.HFILE_NAME = HFILE_NAME
                        IncompleteRecordByEmployee3055.ENTTYPE_ID = 30  ' Entrada con Retardo 
                        IncompleteRecordByEmployee3055.EXTTYPE_ID = 55  ' Salida con tiempo adicional
                        IdealEntryRecords = IncompleteRecordByEmployee3055.Get_EntryExitRecordsByEmployeeIDEnTypes()

                        Dim Count As Integer = 0
                        Dim DateRecord As Date
                        Dim EntryRecord As DateTime
                        Dim ExitRecord As DateTime
                        If IdealEntryRecords.Rows.Count = 2 Then
                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
                                If IdealRow(9) = 30 Then
                                    DateRecord = IdealRow(10)
                                    EntryRecord = IdealRow(12)
                                ElseIf IdealRow(9) = 55 Then
                                    ExitRecord = IdealRow(12)
                                End If
                            Next

                            IncompleteTimeRecordByEmployee3055(CInt(EmployeeRow(2)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                End Select
            Next
        Next

        Return Result
    End Function

    Private Function AbsenceRecordByEmployee(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        Result = NewRecordByEmployee.AbsenceRecordByEmployee()

        Return Result
    End Function

    Private Function InserEntryRecordByEmployee(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        Result = NewRecordByEmployee.InsertEntryRecordByEmployee()

        Return Result
    End Function

    Private Function InserExitRecordByEmployee(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.InsertExitRecordByEmployee()

        Return Result
    End Function

    Private Sub DTP_RegisterDate_Leave(sender As Object, e As EventArgs) Handles DTP_RegisterDate.Leave
        Dim Type = CType(CB_Options.SelectedItem, ComboItem)
        Dim Id_Type = Type.Id

        If Id_Type <> 10 Then
            BT_Register.Enabled = True
        End If
    End Sub

    Private Sub LoadDataToDGV()
        DGV_DataValidation.Columns.Clear()

        DGV_DataValidation.Columns.Add("EmpID", "No.")
        DGV_DataValidation.Columns.Add("EmpName", "ID de empleado - Nombre completo")
        DGV_DataValidation.Columns.Add("Date", "Fecha")
        DGV_DataValidation.Columns.Add("Time", "Hora")
        DGV_DataValidation.Columns.Add("FullDateTime", "FechaHora")
        DGV_DataValidation.Columns.Add("Comment", "Comentario")
        DGV_DataValidation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DataValidation.AutoResizeColumns()
        DGV_DataValidation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        If DGV_DataValidation.Rows.Count > 0 Then
            DGV_DataValidation.Rows.Clear()
        End If

        For Each line As DataGridViewRow In DGV_EmployeesInfo.Rows

            Dim colName = DGV_EmployeesInfo.Columns("Hora").Name
            Dim value = line.Cells("Hora").Value

            Dim EmplID As Integer = CInt(line.Cells(3).Value)
            Dim empName As String = line.Cells(4).Value

            Dim timeText As String = ""

            If line.Cells("Hora").Value IsNot Nothing Then
                timeText = line.Cells("Hora").Value.ToString().Trim()
            End If

            If String.IsNullOrEmpty(timeText) Then
                Continue For
            End If

            Dim selectedDate As Date = DTP_RegisterDate.Value.Date
            Dim parsedTime As DateTime

            DateTime.TryParseExact(timeText,
                              "hh:mm tt",
                              Globalization.CultureInfo.InvariantCulture,
                              Globalization.DateTimeStyles.None,
                              parsedTime)


            Dim fullDateTime As DateTime = selectedDate.Date.Add(parsedTime.TimeOfDay)
            'Dim fileDate As Date = fullDateTime.Date
            Dim timeValue As DateTime = fullDateTime


            ' Nuevo: fecha y hora vienen juntas
            Dim dateTimeText As String = fullDateTime.ToString
            ' Dim fullDateTime As DateTime = DateTime.Parse(dateTimeText)

            'Dim fileDate As Date = fullDateTime.Date
            'Dim timeValue As DateTime = fullDateTime.ToString

            Dim Type As ComboItem = CType(CB_Options.SelectedItem, ComboItem)
            Dim FileTye As Integer = Type.Id

            ' Ajuste para salidas (igual que antes)
            If FileTye = 30 AndAlso timeValue.Hour < 12 Then
                timeValue = timeValue.AddHours(12)
                fullDateTime = fullDateTime.AddHours(12)
            End If

            If FileTye = 20 Then
                'Logic for Entry File
                Dim toleranceTime As DateTime = DateTime.Parse("08:10:00")
                Dim limitTime As DateTime = DateTime.Parse("08:00:00")

                Dim Comment As String = "Puntual"

                If timeValue.TimeOfDay > limitTime.TimeOfDay AndAlso timeValue.TimeOfDay <= toleranceTime.TimeOfDay Then
                    Comment = "Tolerancia"
                ElseIf timeValue.TimeOfDay > toleranceTime.TimeOfDay Then
                    Comment = "Retardo"
                End If

                Dim rowIndex As Integer = DGV_DataValidation.Rows.Add(
                    EmplID,
                    empName,
                    selectedDate.Date.ToString("dd/MM/yyyy"),
                    timeValue.ToString("HH:mm:ss"),
                    fullDateTime,
                    Comment
                )

                If Comment = "Tolerancia" Then
                    DGV_DataValidation.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow
                ElseIf Comment = "Retardo" Then
                    DGV_DataValidation.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                End If
            Else
                'Logic for Exit file
                Dim ToleranceEnd As DateTime = DateTime.Parse("18:00:00")
                Dim EndTime As DateTime = DateTime.Parse("17:30:00")
                Dim EndSaturdayTime As DateTime = DateTime.Parse("13:30:00")
                Dim ToleranceSaturdayEnd As DateTime = DateTime.Parse("14:00:00")

                Dim Comment As String = "Salida Puntual"

                'Moday to Friday
                If (selectedDate.Date.DayOfWeek >= 1 And selectedDate.Date.DayOfWeek <= 5) And
                    timeValue.TimeOfDay > EndTime.TimeOfDay AndAlso timeValue.TimeOfDay <= ToleranceEnd.TimeOfDay Then
                    Comment = "Salida Puntual"
                    'Saturday or Sunday
                ElseIf (selectedDate.Date.DayOfWeek = DayOfWeek.Saturday Or selectedDate.Date.DayOfWeek = DayOfWeek.Sunday) _
                    And timeValue.TimeOfDay > EndSaturdayTime.TimeOfDay AndAlso timeValue.TimeOfDay <= ToleranceSaturdayEnd.TimeOfDay Then
                    Comment = "Salida Puntual"
                    'Monday to Friday
                ElseIf (selectedDate.Date.DayOfWeek >= 1 And selectedDate.Date.DayOfWeek <= 5) And
                    timeValue.TimeOfDay < EndTime.TimeOfDay Then
                    Comment = "Salida anticipada"
                    'Saturday or Sunday
                ElseIf (selectedDate.Date.DayOfWeek = DayOfWeek.Saturday Or selectedDate.Date.DayOfWeek = DayOfWeek.Sunday) And
                    timeValue.TimeOfDay < EndSaturdayTime.TimeOfDay Then
                    Comment = "Salida anticipada"
                ElseIf (selectedDate.Date.DayOfWeek >= 1 And selectedDate.Date.DayOfWeek <= 5) And
                    timeValue.TimeOfDay > ToleranceEnd.TimeOfDay Then
                    Comment = "Salida con tiempo adicional"
                ElseIf (selectedDate.Date.DayOfWeek = DayOfWeek.Saturday Or selectedDate.Date.DayOfWeek = DayOfWeek.Sunday) And
                    timeValue.TimeOfDay > ToleranceSaturdayEnd.TimeOfDay Then
                    Comment = "Salida con tiempo adicional"
                End If

                Dim rowIndex As Integer = DGV_DataValidation.Rows.Add(
                    EmplID,
                    empName,
                    selectedDate.Date.ToString("dd/MM/yyyy"),
                    timeValue.ToString("HH:mm:ss"),
                    fullDateTime,
                    Comment
                )

                If Comment = "Salida anticipada" Then
                    DGV_DataValidation.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                ElseIf Comment = "Salida con tiempo adicional" Then
                    DGV_DataValidation.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow
                End If
            End If
        Next

    End Sub

    Private Sub BT_Check_Click(sender As Object, e As EventArgs) Handles BT_Check.Click
        LoadDataToDGV()
    End Sub

    Private Function IdealFullTimeRecordByEmployee1040(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.IdealFullTimeRecordByEmployee()

        Return Result
    End Function

    Private Function CompleteTimeRecordByEmployee2040(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

        Return Result
    End Function

    Private Function IncompleteTimeRecordByEmployee1050(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

        Return Result
    End Function

    Private Function IncompleteTimeRecordByEmployee3050(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

        Return Result
    End Function

    Private Function IncompleteTimeRecordByEmployee3040(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

        Return Result
    End Function

    Private Function IncompleteTimeRecordByEmployee2050(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

        Return Result
    End Function

    Private Function IncompleteTimeRecordByEmployee3055(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

        Return Result
    End Function

    Private Function IncompleteTimeRecordByEmployee2055(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
        Dim Result As Boolean = False

        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
        NewRecordByEmployee.EMPL_ID = EMPL_ID
        NewRecordByEmployee.MOVE_ID = MOVE_ID
        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

        Return Result
    End Function
End Class