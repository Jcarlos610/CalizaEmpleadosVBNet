Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports Microsoft.Data.SqlClient

Public Class OP_INS_TIMERECORDS
    Dim FileName As String
    Dim FileTye As Integer
    Dim FileDate As Date
    Dim SourcePath As String = ""
    Dim baseFolder As String = ""


    Private Sub OP_INS_TIMERECORDS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()

        CB_Options.Items.Clear()
        CB_Options.Items.Add(New ComboItem With {.Id = 10, .Descripcion = "Seleccione una opción"})
        CB_Options.Items.Add(New ComboItem With {.Id = 20, .Descripcion = "Registro de entradas"})
        CB_Options.Items.Add(New ComboItem With {.Id = 30, .Descripcion = "Registro de salidas"})
        CB_Options.DisplayMember = "Descripcion"
        CB_Options.ValueMember = "Id"
        CB_Options.SelectedIndex = 0

        TB_SourcePath.Enabled = False
        TB_SourcePath.Text = ""
        BT_LoadFile.Enabled = False
        BT_RegisterInformation.Enabled = False

        TB_Comment.Text = ""
        TB_Comment.Enabled = False

        DGV_FileContent.Columns.Clear()
        DGV_Registerinformation.Columns.Clear()

    End Sub

    Private Sub BT_LoadFile_Click(sender As Object, e As EventArgs) Handles BT_LoadFile.Click

        Dim OpenFileDialog As New OpenFileDialog()

        'Select the ID to load info
        Dim OptionOfLoad As ComboItem = CType(CB_Options.SelectedItem, ComboItem)

        Dim OptionOfLoad_Number As Integer = OptionOfLoad.Id
        Dim OptionOfLoad_Text As String = OptionOfLoad.Descripcion

        If OptionOfLoad_Number = 10 Then
            MessageBox.Show("Favor de seleccionar una de las opciones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf OptionOfLoad_Number = 20 Then
            OpenFileDialog.Title = "Seleccione el archivo de entradas"
            OpenFileDialog.InitialDirectory = My.Settings.WorkTimeFilesEntry
            baseFolder = My.Settings.WorkTimeFilesEntry
        ElseIf OptionOfLoad_Number = 30 Then
            OpenFileDialog.Title = "Seleccione el archivo de salidas"
            OpenFileDialog.InitialDirectory = My.Settings.WorkTimeFilesExit
            baseFolder = My.Settings.WorkTimeFilesExit
        End If

        FileTye = OptionOfLoad_Number
        OpenFileDialog.Filter = "Archivos de texto|*.csv"

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            'If Not ValidarNombreArchivo(OpenFileDialog.FileName) Then
            '    MessageBox.Show("El archivo debe tener formato ddmmaaaa.csv (ejemplo: 11032026.csv)", "Formato incorrecto")
            '    Exit Sub
            'End If

            'Si pasa la validación
            TB_SourcePath.Text = OpenFileDialog.FileName
        End If

        SourcePath = TB_SourcePath.Text

        If Not File.Exists(SourcePath) Then
            Exit Sub
        End If

        FileName = System.IO.Path.GetFileName(OpenFileDialog.FileName)
        'Dim fileDate As Date = GetDateFromFileName(SourcePath)

        LoadCSVToDGV(SourcePath)

        BT_RegisterInformation.Enabled = True
        CB_Options.Enabled = False

    End Sub

    Private Function GetDateFromFileName(path As String) As Date

        Dim fileName As String = System.IO.Path.GetFileNameWithoutExtension(path)

        Dim day As Integer = Integer.Parse(fileName.Substring(0, 2))
        Dim month As Integer = Integer.Parse(fileName.Substring(2, 2))
        Dim year As Integer = Integer.Parse(fileName.Substring(4, 4))

        Return New Date(year, month, day)

    End Function

    Private Sub LoadCSVToDGV(path As String)
        DGV_FileContent.Columns.Clear()

        DGV_FileContent.Columns.Add("EmpID", "No.")
        DGV_FileContent.Columns.Add("EmpName", "ID de empleado - Nombre completo")
        DGV_FileContent.Columns.Add("Date", "Fecha")
        DGV_FileContent.Columns.Add("Time", "Hora")
        DGV_FileContent.Columns.Add("FullDateTime", "FechaHora")
        DGV_FileContent.Columns.Add("Comment", "Comentario")
        DGV_FileContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_FileContent.AutoResizeColumns()
        DGV_FileContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        If DGV_FileContent.Rows.Count > 0 Then
            DGV_FileContent.Rows.Clear()
        End If

        'Dim lines() As String = File.ReadAllLines(path, System.Text.Encoding.GetEncoding(1252))
        Dim lines() As String = File.ReadAllLines(path, System.Text.Encoding.UTF8)
        Dim LineIndex As Integer = 0

        For Each line As String In lines
            If LineIndex = 0 Then
                LineIndex += 1
                Continue For
            End If

            If String.IsNullOrWhiteSpace(line) Then Continue For

            'Dim values() As String = line.Replace("'", "").Split(",")

            'Dim RecordID As Integer = Convert.ToInt32(values(0).Trim())
            'Dim empInfo() As String = values(1).Trim().Split("-")
            'Dim EmplID As Integer = CInt(empInfo(0))
            'Dim empName As String = empInfo(1).ToString
            'Dim hourText As String = values(2).Trim()
            'Dim timeValue As DateTime = ParseSpanishTime(hourText)

            'If FileTye = 30 AndAlso timeValue.Hour < 12 Then
            '    timeValue = timeValue.AddHours(12)
            'End If

            'Dim fullDateTime As DateTime = fileDate.Date.Add(timeValue.TimeOfDay)

            'Dim values() As String = line.Replace("'", "").Split(",")
            'Dim EmplID As Integer = Convert.ToInt32(values(0).Trim())
            'Dim empName As String = values(1).Trim()

            Dim values() As String = line.Replace("'", "").Split(",")
            Dim empInfo() As String = values(1).Trim().Split("-")
            Dim EmplID As Integer = CInt(empInfo(0))
            Dim empName As String = empInfo(1).ToString

            ' Nuevo: fecha y hora vienen juntas
            Dim dateTimeText As String = values(3).Trim()
            Dim fullDateTime As DateTime = DateTime.Parse(dateTimeText)

            Dim fileDate As Date = fullDateTime.Date
            Dim timeValue As DateTime = fullDateTime

            ' Ajuste para salidas (igual que antes)
            If FileTye = 30 AndAlso timeValue.Hour < 12 Then
                timeValue = timeValue.AddHours(12)
                fullDateTime = fullDateTime.AddHours(12)
            End If

            If FileTye = 20 Then
                'Logic for Entry File
                Dim toleranceTime As DateTime = DateTime.Parse("07:10:00")
                Dim limitTime As DateTime = DateTime.Parse("07:00:00")

                Dim Comment As String = "Puntual"

                If timeValue.TimeOfDay > limitTime.TimeOfDay AndAlso timeValue.TimeOfDay <= toleranceTime.TimeOfDay Then
                    Comment = "Tolerancia"
                ElseIf timeValue.TimeOfDay > toleranceTime.TimeOfDay Then
                    Comment = "Retardo"
                End If

                Dim rowIndex As Integer = DGV_FileContent.Rows.Add(
                    EmplID,
                    empName,
                    FileDate.ToString("dd/MM/yyyy"),
                    timeValue.ToString("HH:mm:ss"),
                    fullDateTime,
                    Comment
                )

                If Comment = "Tolerancia" Then
                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                ElseIf Comment = "Retardo" Then
                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                End If
            Else
                'Logic for Exit file
                Dim ToleranceEnd As DateTime = DateTime.Parse("18:00:00")
                Dim EndTime As DateTime = DateTime.Parse("17:30:00")
                Dim EndSaturdayTime As DateTime = DateTime.Parse("13:30:00")
                Dim ToleranceSaturdayEnd As DateTime = DateTime.Parse("14:00:00")

                Dim Comment As String = "Salida Puntual"

                'Moday to Friday
                If (FileDate.DayOfWeek >= 1 And FileDate.DayOfWeek <= 5) And
                    timeValue.TimeOfDay > EndTime.TimeOfDay AndAlso timeValue.TimeOfDay <= ToleranceEnd.TimeOfDay Then
                    Comment = "Salida Puntual"
                    'Saturday or Sunday
                ElseIf (FileDate.DayOfWeek = DayOfWeek.Saturday Or FileDate.DayOfWeek = DayOfWeek.Sunday) _
                    And timeValue.TimeOfDay > EndSaturdayTime.TimeOfDay AndAlso timeValue.TimeOfDay <= ToleranceSaturdayEnd.TimeOfDay Then
                    Comment = "Salida Puntual"
                    'Monday to Friday
                ElseIf (FileDate.DayOfWeek >= 1 And FileDate.DayOfWeek <= 5) And
                    timeValue.TimeOfDay < EndTime.TimeOfDay Then
                    Comment = "Salida anticipada"
                    'Saturday or Sunday
                ElseIf (FileDate.DayOfWeek = DayOfWeek.Saturday Or FileDate.DayOfWeek = DayOfWeek.Sunday) And
                    timeValue.TimeOfDay < EndSaturdayTime.TimeOfDay Then
                    Comment = "Salida anticipada"
                ElseIf (FileDate.DayOfWeek >= 1 And FileDate.DayOfWeek <= 5) And
                    timeValue.TimeOfDay > ToleranceEnd.TimeOfDay Then
                    Comment = "Salida con tiempo adicional"
                ElseIf (FileDate.DayOfWeek = DayOfWeek.Saturday Or FileDate.DayOfWeek = DayOfWeek.Sunday) And
                    timeValue.TimeOfDay > ToleranceSaturdayEnd.TimeOfDay Then
                    Comment = "Salida con tiempo adicional"
                End If

                Dim rowIndex As Integer = DGV_FileContent.Rows.Add(
                    EmplID,
                    empName,
                    FileDate.ToString("dd/MM/yyyy"),
                    timeValue.ToString("HH:mm:ss"),
                    fullDateTime,
                    Comment
                )

                If Comment = "Salida anticipada" Then
                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                ElseIf Comment = "Salida con tiempo adicional" Then
                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                End If
            End If
        Next

        If MessageBox.Show("¿Desea agregar algún comentario?.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
            TB_Comment.BackColor = SystemColors.Info
            TB_Comment.Enabled = True
            TB_Comment.Focus()
        Else
            TB_Comment.Enabled = False
            BT_RegisterInformation.Focus()
        End If



    End Sub

    Private Function ParseSpanishTime(timeText As String) As DateTime

        timeText = timeText.ToLower()

        timeText = timeText.Replace("a. m.", "AM")
        timeText = timeText.Replace("p. m.", "PM")
        timeText = timeText.Replace("a.m.", "AM")
        timeText = timeText.Replace("p.m.", "PM")
        timeText = timeText.Replace("am", "AM")
        timeText = timeText.Replace("pm", "PM")

        Dim parsedTime As DateTime

        If DateTime.TryParse(timeText, parsedTime) Then
            Return parsedTime
        Else
            Throw New Exception("Formato de hora inválido: " & timeText)
        End If

    End Function

    Private Sub CB_Options_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Options.SelectedIndexChanged
        BT_LoadFile.Enabled = True
    End Sub

    Private Sub BT_RegisterInformation_Click(sender As Object, e As EventArgs) Handles BT_RegisterInformation.Click

        If DGV_FileContent.Rows.Count = 0 Then Exit Sub

        RegisterFileContent()

    End Sub

    Private Sub RegisterFileContent()
        Dim conn As New SqlConnection(My.Settings.ConnectionString)
        Dim trans As SqlTransaction = Nothing

        conn.Open()
        Try
            Dim FileComment As String = TB_Comment.Text
            Dim NumberOfRecords As Integer = DGV_FileContent.Rows.Count
            Dim AssistanceFileHeader As New CL_EntryExitFile(FileTye, FileName, NumberOfRecords, FileComment, AppUser, Date.Now)

            'VALIDAR SI EL ARCHIVO YA EXISTE
            If AssistanceFileHeader.FileAlreadyExists(conn) Then
                MessageBox.Show("El archivo: " & FileName & vbCrLf & "ya fue registrado anteriormente.", "Archivo duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                InitializationOfFields()
                CB_Options.Enabled = True
                conn.Close()
                Exit Sub
            End If

            'INICIAR TRANSACCIÓN SOLO SI NO EXISTE
            trans = conn.BeginTransaction()
            Dim L_HFILE_ID As Integer = AssistanceFileHeader.InsertAsistanceFileHeader(conn, trans)

            If L_HFILE_ID <> 0 Then
                For Each Line As DataGridViewRow In DGV_FileContent.Rows
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
                    FileDate = DateTime.ParseExact(
                        Line.Cells("DATE").Value.ToString(),
                        "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture
                    )

                    Item.IFILE_DATE = FileDate
                    Item.IFILE_TIME = Line.Cells("TIME").Value
                    Item.IFILE_DATI = Line.Cells("FullDateTime").Value
                    Item.InsertAsistanceFileItem(conn, trans)
                Next

                trans.Commit()

                'Make Full Time Calculation
                LoadRecordByEmployee(FileTye, FileName)

                MoveFileToBackup(SourcePath, FileDate, baseFolder)
                MessageBox.Show("Archivo: " & FileName & vbCrLf & "se registró correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


                If FileTye = 20 Then
                    Display_EntryRecords()
                Else
                    Display_ExitRecords()
                End If

                'InitializationOfFields()
                CB_Options.Enabled = True
            Else
                MessageBox.Show("Ocurrió un error con el ID del archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                InitializationOfFields()
                CB_Options.Enabled = True
                conn.Close()
                Exit Sub
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

    Function ValidarNombreArchivo(rutaArchivo As String) As Boolean

        Dim nombreArchivo As String = Path.GetFileName(rutaArchivo)

        'Patrón: ddmmaaaa.csv
        Dim patron As String = "^\d{8}\.csv$"

        If Not Regex.IsMatch(nombreArchivo, patron) Then
            Return False
        End If

        'Extraer la fecha
        Dim fechaTexto As String = nombreArchivo.Substring(0, 8)

        Dim fecha As DateTime
        If DateTime.TryParseExact(fechaTexto, "ddMMyyyy",
                                  Globalization.CultureInfo.InvariantCulture,
                                  Globalization.DateTimeStyles.None,
                                  fecha) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function LoadRecordByEmployee(ByVal HFILE_TYPE As Integer, ByVal HFILE_NAME As String) As Boolean
        Dim Result As Boolean = False
        Dim Employee = New CL_Employee()
        Dim ActiveEmployees As DataTable = Employee.Get_AllActiveEmployeesID()
        Dim AsistanceTypes As DataTable

        'Check all active employees
        For Each EmployeeRow As DataRow In ActiveEmployees.Rows
            Dim RecordByEmployee As New CL_EntryExitFile
            RecordByEmployee.EMPL_ID = CInt(EmployeeRow(0))
            RecordByEmployee.HFILE_TYPE = FileTye
            RecordByEmployee.HFILE_NAME = FileName
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
                RecordByEmployeeType.EMPL_ID = CInt(EmployeeRow(0))
                RecordByEmployeeType.HFILE_TYPE = FileTye
                RecordByEmployeeType.HFILE_NAME = FileName
                RecordByEmployeeType.ENTTYPE_ID = CInt(Asistance(0))
                EntryExitFileRecords = RecordByEmployeeType.Get_EntryExitRecordByEmployeeIDEnTypeInFIle()

                Select Case Asistance(0)
                    Case 10 ' Entrada puntual
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserEntryRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 20 ' Entrada con Tolerancia
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserEntryRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 30 ' Retardo
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserEntryRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 40 ' Salida Puntual
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserExitRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 50 ' Salida Anticipada
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserExitRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 55 ' Salida con Tiempo Adicional
                        For Each Record As DataRow In EntryExitFileRecords.Rows
                            InserExitRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
                        Next
                    Case 60 ' Falta
                        If FileTye = 20 Then
                            Dim AsistanceCheck As New CL_EntryExitFile
                            Dim AbsenceRecors As DataTable
                            AsistanceCheck.EMPL_ID = CInt(EmployeeRow(0))
                            AsistanceCheck.HFILE_NAME = FileName
                            AsistanceCheck.HFILE_TYPE = FileTye
                            AbsenceRecors = AsistanceCheck.Get_AsistanceCheck()

                            If AbsenceRecors.Rows.Count = 0 Then
                                AbsenceRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, FileDate)
                            End If
                        End If
                    Case 70 ' Jornada Completa 10/40
                        Dim RecordsByEmployeeType1040 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        RecordsByEmployeeType1040.EMPL_ID = CInt(EmployeeRow(0))
                        RecordsByEmployeeType1040.HFILE_NAME = FileName
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

                            IdealFullTimeRecordByEmployee1040(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 80 'Jornada Completa - Entrada con tolerancia salida puntual 20/40
                        Dim RecordsByEmployeeType2040 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        RecordsByEmployeeType2040.EMPL_ID = CInt(EmployeeRow(0))
                        RecordsByEmployeeType2040.HFILE_NAME = FileName
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

                            CompleteTimeRecordByEmployee2040(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 85 'Jornada Completa con Tiempo Adicional 20/55
                        Dim IncompleteRecordByEmployee2055 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee2055.EMPL_ID = CInt(EmployeeRow(0))
                        IncompleteRecordByEmployee2055.HFILE_NAME = FileName
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

                            IncompleteTimeRecordByEmployee2055(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 90 'Jornada Incompleta - Entrada puntual salida anticipada 10/50
                        Dim IncompleteRecordByEmployee1050 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee1050.EMPL_ID = CInt(EmployeeRow(0))
                        IncompleteRecordByEmployee1050.HFILE_NAME = FileName
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

                            IncompleteTimeRecordByEmployee1050(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 100 'Jornada Incompleta - Entrada con retardo salida anticipada 30/50
                        Dim IncompleteRecordByEmployee3050 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee3050.EMPL_ID = CInt(EmployeeRow(0))
                        IncompleteRecordByEmployee3050.HFILE_NAME = FileName
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

                            IncompleteTimeRecordByEmployee3050(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 110 'Jornada Incompleta - Entrada con retardo salida puntual       30/40
                        Dim IncompleteRecordByEmployee3040 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee3040.EMPL_ID = CInt(EmployeeRow(0))
                        IncompleteRecordByEmployee3040.HFILE_NAME = FileName
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

                            IncompleteTimeRecordByEmployee3040(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                    Case 120 'Jornada Incompleta - Entrada con tolerancia salida anticipada 20/50
                        Dim IncompleteRecordByEmployee2050 As New CL_EntryExitFile
                        Dim IdealEntryRecords As DataTable
                        IncompleteRecordByEmployee2050.EMPL_ID = CInt(EmployeeRow(0))
                        IncompleteRecordByEmployee2050.HFILE_NAME = FileName
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

                            IncompleteTimeRecordByEmployee2050(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
                        End If
                End Select
            Next
        Next

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

    Private Sub Display_EntryRecords()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()
        DGV_Registerinformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Registerinformation.AutoResizeColumns()
        DGV_Registerinformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Registerinformation.DataSource = RecordsByEmployees.Get_AllRecordsByEntryFile(FileDate)
    End Sub

    Private Sub Display_ExitRecords()
        Dim RecordsByEmployees As New CL_RecordsByEmployee()
        DGV_Registerinformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Registerinformation.AutoResizeColumns()
        DGV_Registerinformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Registerinformation.DataSource = RecordsByEmployees.Get_AllRecordsByExitFile(FileDate)
    End Sub

    Private Sub MoveFileToBackup(originalPath As String, fileDate As Date, baseFolder As String)

        Try
            'Obtener año y mes
            Dim yearFolder As String = fileDate.Year.ToString()
            Dim monthFolder As String = fileDate.Month.ToString("00")

            'Ruta final dentro de Entradas o Salidas
            Dim finalPath As String = Path.Combine(baseFolder, yearFolder, monthFolder)

            'Crear carpeta si no existe
            If Not Directory.Exists(finalPath) Then
                Directory.CreateDirectory(finalPath)
            End If

            'Nombre del archivo
            Dim fileName As String = Path.GetFileName(originalPath)

            'Ruta destino
            Dim destinationFile As String = Path.Combine(finalPath, fileName)

            'Si ya existe lo reemplaza
            If File.Exists(destinationFile) Then
                File.Delete(destinationFile)
            End If

            'Mover archivo
            File.Move(originalPath, destinationFile)

        Catch ex As Exception
            MessageBox.Show("Error al mover archivo a backup: " & ex.Message)
        End Try

    End Sub

    Private Sub BT_CleanFields_Click(sender As Object, e As EventArgs) Handles BT_CleanFields.Click
        InitializationOfFields()
        BT_LoadFile.Enabled = True
    End Sub
End Class


'Imports System.IO
'Imports System.Text.RegularExpressions
'Imports System.Windows.Forms.VisualStyles
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
'Imports Microsoft.Data.SqlClient

'Public Class OP_INS_TIMERECORDS
'    Dim FileName As String
'    Dim FileTye As Integer
'    Dim FileDate As Date
'    Dim SourcePath As String = ""
'    Dim baseFolder As String = ""


'    Private Sub OP_INS_TIMERECORDS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        InitializationOfFields()
'    End Sub

'    Private Sub InitializationOfFields()

'        CB_Options.Items.Clear()
'        CB_Options.Items.Add(New ComboItem With {.Id = 10, .Descripcion = "Seleccione una opción"})
'        CB_Options.Items.Add(New ComboItem With {.Id = 20, .Descripcion = "Registro de entradas"})
'        CB_Options.Items.Add(New ComboItem With {.Id = 30, .Descripcion = "Registro de salidas"})
'        CB_Options.DisplayMember = "Descripcion"
'        CB_Options.ValueMember = "Id"
'        CB_Options.SelectedIndex = 0

'        TB_SourcePath.Enabled = False
'        TB_SourcePath.Text = ""
'        BT_LoadFile.Enabled = False
'        BT_RegisterInformation.Enabled = False

'        TB_Comment.Text = ""
'        TB_Comment.Enabled = False

'        DGV_FileContent.Columns.Clear()
'        DGV_Registerinformation.Columns.Clear()

'    End Sub

'    Private Sub BT_LoadFile_Click(sender As Object, e As EventArgs) Handles BT_LoadFile.Click

'        Dim OpenFileDialog As New OpenFileDialog()

'        'Select the ID to load info
'        Dim OptionOfLoad As ComboItem = CType(CB_Options.SelectedItem, ComboItem)

'        Dim OptionOfLoad_Number As Integer = OptionOfLoad.Id
'        Dim OptionOfLoad_Text As String = OptionOfLoad.Descripcion

'        If OptionOfLoad_Number = 10 Then
'            MessageBox.Show("Favor de seleccionar una de las opciones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'        ElseIf OptionOfLoad_Number = 20 Then
'            OpenFileDialog.Title = "Seleccione el archivo de entradas"
'            OpenFileDialog.InitialDirectory = My.Settings.WorkTimeFilesEntry
'            baseFolder = My.Settings.WorkTimeFilesEntry
'        ElseIf OptionOfLoad_Number = 30 Then
'            OpenFileDialog.Title = "Seleccione el archivo de salidas"
'            OpenFileDialog.InitialDirectory = My.Settings.WorkTimeFilesExit
'            baseFolder = My.Settings.WorkTimeFilesExit
'        End If

'        FileTye = OptionOfLoad_Number
'        OpenFileDialog.Filter = "Archivos de texto|*.csv"

'        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
'            If Not ValidarNombreArchivo(OpenFileDialog.FileName) Then
'                MessageBox.Show("El archivo debe tener formato ddmmaaaa.csv (ejemplo: 11032026.csv)", "Formato incorrecto")
'                Exit Sub
'            End If

'            'Si pasa la validación
'            TB_SourcePath.Text = OpenFileDialog.FileName
'        End If

'        SourcePath = TB_SourcePath.Text

'        If Not File.Exists(SourcePath) Then
'            Exit Sub
'        End If

'        FileName = System.IO.Path.GetFileName(OpenFileDialog.FileName)
'        Dim fileDate As Date = GetDateFromFileName(SourcePath)

'        LoadCSVToDGV(SourcePath, fileDate)

'        BT_RegisterInformation.Enabled = True
'        CB_Options.Enabled = False

'    End Sub

'    Private Function GetDateFromFileName(path As String) As Date

'        Dim fileName As String = System.IO.Path.GetFileNameWithoutExtension(path)

'        Dim day As Integer = Integer.Parse(fileName.Substring(0, 2))
'        Dim month As Integer = Integer.Parse(fileName.Substring(2, 2))
'        Dim year As Integer = Integer.Parse(fileName.Substring(4, 4))

'        Return New Date(year, month, day)

'    End Function

'    Private Sub LoadCSVToDGV(path As String, fileDate As Date)
'        DGV_FileContent.Columns.Clear()

'        DGV_FileContent.Columns.Add("EmpID", "No.")
'        DGV_FileContent.Columns.Add("EmpName", "ID de empleado - Nombre completo")
'        DGV_FileContent.Columns.Add("Date", "Fecha")
'        DGV_FileContent.Columns.Add("Time", "Hora")
'        DGV_FileContent.Columns.Add("FullDateTime", "FechaHora")
'        DGV_FileContent.Columns.Add("Comment", "Comentario")
'        DGV_FileContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
'        DGV_FileContent.AutoResizeColumns()
'        DGV_FileContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

'        If DGV_FileContent.Rows.Count > 0 Then
'            DGV_FileContent.Rows.Clear()
'        End If

'        Dim lines() As String = File.ReadAllLines(path, System.Text.Encoding.GetEncoding(1252))
'        Dim LineIndex As Integer = 0

'        For Each line As String In lines
'            If LineIndex = 0 Then
'                LineIndex += 1
'                Continue For
'            End If

'            If String.IsNullOrWhiteSpace(line) Then Continue For

'            Dim values() As String = line.Replace("'", "").Split(",")

'            Dim RecordID As Integer = Convert.ToInt32(values(0).Trim())
'            Dim empInfo() As String = values(1).Trim().Split("-")
'            Dim EmplID As Integer = CInt(empInfo(0))
'            Dim empName As String = empInfo(1).ToString
'            Dim hourText As String = values(2).Trim()
'            Dim timeValue As DateTime = ParseSpanishTime(hourText)

'            If FileTye = 30 AndAlso timeValue.Hour < 12 Then
'                timeValue = timeValue.AddHours(12)
'            End If

'            Dim fullDateTime As DateTime = fileDate.Date.Add(timeValue.TimeOfDay)

'            If FileTye = 20 Then
'                'Logic for Entry File
'                Dim toleranceTime As DateTime = DateTime.Parse("07:10:00")
'                Dim limitTime As DateTime = DateTime.Parse("07:00:00")

'                Dim Comment As String = "Puntual"

'                If timeValue.TimeOfDay > limitTime.TimeOfDay AndAlso timeValue.TimeOfDay <= toleranceTime.TimeOfDay Then
'                    Comment = "Tolerancia"
'                ElseIf timeValue.TimeOfDay > toleranceTime.TimeOfDay Then
'                    Comment = "Retardo"
'                End If

'                Dim rowIndex As Integer = DGV_FileContent.Rows.Add(
'                    EmplID,
'                    empName,
'                    fileDate.ToString("dd/MM/yyyy"),
'                    timeValue.ToString("HH:mm:ss"),
'                    fullDateTime,
'                    Comment
'                )

'                If Comment = "Tolerancia" Then
'                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
'                ElseIf Comment = "Retardo" Then
'                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.MistyRose
'                End If
'            Else
'                'Logic for Exit file
'                Dim ToleranceEnd As DateTime = DateTime.Parse("18:00:00")
'                Dim EndTime As DateTime = DateTime.Parse("17:30:00")
'                Dim EndSaturdayTime As DateTime = DateTime.Parse("13:30:00")
'                Dim ToleranceSaturdayEnd As DateTime = DateTime.Parse("14:00:00")

'                Dim Comment As String = "Salida Puntual"

'                'Moday to Friday
'                If (fileDate.DayOfWeek >= 1 And fileDate.DayOfWeek <= 5) And
'                    timeValue.TimeOfDay > EndTime.TimeOfDay AndAlso timeValue.TimeOfDay <= ToleranceEnd.TimeOfDay Then
'                    Comment = "Salida Puntual"
'                    'Saturday or Sunday
'                ElseIf (fileDate.DayOfWeek = DayOfWeek.Saturday Or fileDate.DayOfWeek = DayOfWeek.Sunday) _
'                    And timeValue.TimeOfDay > EndSaturdayTime.TimeOfDay AndAlso timeValue.TimeOfDay <= ToleranceSaturdayEnd.TimeOfDay Then
'                    Comment = "Salida Puntual"
'                    'Monday to Friday
'                ElseIf (fileDate.DayOfWeek >= 1 And fileDate.DayOfWeek <= 5) And
'                    timeValue.TimeOfDay < EndTime.TimeOfDay Then
'                    Comment = "Salida anticipada"
'                    'Saturday or Sunday
'                ElseIf (fileDate.DayOfWeek = DayOfWeek.Saturday Or fileDate.DayOfWeek = DayOfWeek.Sunday) And
'                    timeValue.TimeOfDay < EndSaturdayTime.TimeOfDay Then
'                    Comment = "Salida anticipada"
'                ElseIf (fileDate.DayOfWeek >= 1 And fileDate.DayOfWeek <= 5) And
'                    timeValue.TimeOfDay > ToleranceEnd.TimeOfDay Then
'                    Comment = "Salida con tiempo adicional"
'                ElseIf (fileDate.DayOfWeek = DayOfWeek.Saturday Or fileDate.DayOfWeek = DayOfWeek.Sunday) And
'                    timeValue.TimeOfDay > ToleranceSaturdayEnd.TimeOfDay Then
'                    Comment = "Salida con tiempo adicional"
'                End If

'                Dim rowIndex As Integer = DGV_FileContent.Rows.Add(
'                    EmplID,
'                    empName,
'                    fileDate.ToString("dd/MM/yyyy"),
'                    timeValue.ToString("HH:mm:ss"),
'                    fullDateTime,
'                    Comment
'                )

'                If Comment = "Salida anticipada" Then
'                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.MistyRose
'                ElseIf Comment = "Salida con tiempo adicional" Then
'                    DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
'                End If
'            End If
'        Next

'        If MessageBox.Show("¿Desea agregar algún comentario?.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
'            TB_Comment.BackColor = SystemColors.Info
'            TB_Comment.Enabled = True
'            TB_Comment.Focus()
'        Else
'            TB_Comment.Enabled = False
'            BT_RegisterInformation.Focus()
'        End If



'    End Sub

'    Private Function ParseSpanishTime(timeText As String) As DateTime

'        timeText = timeText.ToLower()

'        timeText = timeText.Replace("a. m.", "AM")
'        timeText = timeText.Replace("p. m.", "PM")
'        timeText = timeText.Replace("a.m.", "AM")
'        timeText = timeText.Replace("p.m.", "PM")
'        timeText = timeText.Replace("am", "AM")
'        timeText = timeText.Replace("pm", "PM")

'        Dim parsedTime As DateTime

'        If DateTime.TryParse(timeText, parsedTime) Then
'            Return parsedTime
'        Else
'            Throw New Exception("Formato de hora inválido: " & timeText)
'        End If

'    End Function

'    Private Sub CB_Options_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Options.SelectedIndexChanged
'        BT_LoadFile.Enabled = True
'    End Sub

'    Private Sub BT_RegisterInformation_Click(sender As Object, e As EventArgs) Handles BT_RegisterInformation.Click

'        If DGV_FileContent.Rows.Count = 0 Then Exit Sub

'        RegisterFileContent()

'    End Sub

'    Private Sub RegisterFileContent()
'        Dim conn As New SqlConnection(My.Settings.ConnectionString)
'        Dim trans As SqlTransaction = Nothing

'        conn.Open()
'        Try
'            Dim FileComment As String = TB_Comment.Text
'            Dim NumberOfRecords As Integer = DGV_FileContent.Rows.Count
'            Dim AssistanceFileHeader As New CL_EntryExitFile(FileTye, FileName, NumberOfRecords, FileComment, AppUser, Date.Now)

'            'VALIDAR SI EL ARCHIVO YA EXISTE
'            If AssistanceFileHeader.FileAlreadyExists(conn) Then
'                MessageBox.Show("El archivo: " & FileName & vbCrLf & "ya fue registrado anteriormente.", "Archivo duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                InitializationOfFields()
'                CB_Options.Enabled = True
'                conn.Close()
'                Exit Sub
'            End If

'            'INICIAR TRANSACCIÓN SOLO SI NO EXISTE
'            trans = conn.BeginTransaction()
'            Dim L_HFILE_ID As Integer = AssistanceFileHeader.InsertAsistanceFileHeader(conn, trans)

'            If L_HFILE_ID <> 0 Then
'                For Each Line As DataGridViewRow In DGV_FileContent.Rows
'                    Dim Item As New CL_EntryExitFile
'                    Item.HFILE_ID = L_HFILE_ID
'                    Item.EMPL_ID = Line.Cells("EmpID").Value
'                    If Line.Cells("Comment").Value = "Puntual" Then
'                        Item.ENTTYPE_ID = 10
'                    ElseIf Line.Cells("Comment").Value = "Tolerancia" Then
'                        Item.ENTTYPE_ID = 20
'                    ElseIf Line.Cells("Comment").Value = "Retardo" Then
'                        Item.ENTTYPE_ID = 30
'                    ElseIf Line.Cells("Comment").Value = "Salida Puntual" Then
'                        Item.ENTTYPE_ID = 40
'                    ElseIf Line.Cells("Comment").Value = "Salida anticipada" Then
'                        Item.ENTTYPE_ID = 50
'                    ElseIf Line.Cells("Comment").Value = "Salida con tiempo adicional" Then
'                        Item.ENTTYPE_ID = 55
'                    End If
'                    FileDate = DateTime.ParseExact(
'                        Line.Cells("DATE").Value.ToString(),
'                        "dd/MM/yyyy",
'                        System.Globalization.CultureInfo.InvariantCulture
'                    )

'                    Item.IFILE_DATE = FileDate
'                    Item.IFILE_TIME = Line.Cells("TIME").Value
'                    Item.IFILE_DATI = Line.Cells("FullDateTime").Value
'                    Item.InsertAsistanceFileItem(conn, trans)
'                Next

'                trans.Commit()

'                'Make Full Time Calculation
'                LoadRecordByEmployee(FileTye, FileName)

'                MoveFileToBackup(SourcePath, FileDate, baseFolder)
'                MessageBox.Show("Archivo: " & FileName & vbCrLf & "se registró correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


'                If FileTye = 20 Then
'                    Display_EntryRecords()
'                Else
'                    Display_ExitRecords()
'                End If

'                'InitializationOfFields()
'                CB_Options.Enabled = True
'            Else
'                MessageBox.Show("Ocurrió un error con el ID del archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                InitializationOfFields()
'                CB_Options.Enabled = True
'                conn.Close()
'                Exit Sub
'            End If
'        Catch ex As Exception
'            If trans IsNot Nothing Then
'                trans.Rollback()
'            End If
'            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            conn.Close()
'        End Try
'    End Sub

'    Function ValidarNombreArchivo(rutaArchivo As String) As Boolean

'        Dim nombreArchivo As String = Path.GetFileName(rutaArchivo)

'        'Patrón: ddmmaaaa.csv
'        Dim patron As String = "^\d{8}\.csv$"

'        If Not Regex.IsMatch(nombreArchivo, patron) Then
'            Return False
'        End If

'        'Extraer la fecha
'        Dim fechaTexto As String = nombreArchivo.Substring(0, 8)

'        Dim fecha As DateTime
'        If DateTime.TryParseExact(fechaTexto, "ddMMyyyy",
'                                  Globalization.CultureInfo.InvariantCulture,
'                                  Globalization.DateTimeStyles.None,
'                                  fecha) Then
'            Return True
'        Else
'            Return False
'        End If

'    End Function

'    Private Function LoadRecordByEmployee(ByVal HFILE_TYPE As Integer, ByVal HFILE_NAME As String) As Boolean
'        Dim Result As Boolean = False
'        Dim Employee = New CL_Employee()
'        Dim ActiveEmployees As DataTable = Employee.Get_AllActiveEmployeesID()
'        Dim AsistanceTypes As DataTable

'        'Check all active employees
'        For Each EmployeeRow As DataRow In ActiveEmployees.Rows
'            Dim RecordByEmployee As New CL_EntryExitFile
'            RecordByEmployee.EMPL_ID = CInt(EmployeeRow(0))
'            RecordByEmployee.HFILE_TYPE = FileTye
'            RecordByEmployee.HFILE_NAME = FileName
'            AsistanceTypes = RecordByEmployee.Get_AllAssistanceTypes()

'            'Check all asistance types by employee
'            For Each Asistance As DataRow In AsistanceTypes.Rows
'                '8 - Empl_ID
'                '9 - Entry Type
'                '10 - date
'                '11 - time
'                '12 - datetime
'                Dim RecordByEmployeeType As New CL_EntryExitFile
'                Dim EntryExitFileRecords As DataTable
'                RecordByEmployeeType.EMPL_ID = CInt(EmployeeRow(0))
'                RecordByEmployeeType.HFILE_TYPE = FileTye
'                RecordByEmployeeType.HFILE_NAME = FileName
'                RecordByEmployeeType.ENTTYPE_ID = CInt(Asistance(0))
'                EntryExitFileRecords = RecordByEmployeeType.Get_EntryExitRecordByEmployeeIDEnTypeInFIle()

'                Select Case Asistance(0)
'                    Case 10 ' Entrada puntual
'                        For Each Record As DataRow In EntryExitFileRecords.Rows
'                            InserEntryRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
'                        Next
'                    Case 20 ' Entrada con Tolerancia
'                        For Each Record As DataRow In EntryExitFileRecords.Rows
'                            InserEntryRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
'                        Next
'                    Case 30 ' Retardo
'                        For Each Record As DataRow In EntryExitFileRecords.Rows
'                            InserEntryRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
'                        Next
'                    Case 40 ' Salida Puntual
'                        For Each Record As DataRow In EntryExitFileRecords.Rows
'                            InserExitRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
'                        Next
'                    Case 50 ' Salida Anticipada
'                        For Each Record As DataRow In EntryExitFileRecords.Rows
'                            InserExitRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
'                        Next
'                    Case 55 ' Salida con Tiempo Adicional
'                        For Each Record As DataRow In EntryExitFileRecords.Rows
'                            InserExitRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, Record(10), Record(12))
'                        Next
'                    Case 60 ' Falta
'                        If FileTye = 20 Then
'                            Dim AsistanceCheck As New CL_EntryExitFile
'                            Dim AbsenceRecors As DataTable
'                            AsistanceCheck.EMPL_ID = CInt(EmployeeRow(0))
'                            AsistanceCheck.HFILE_NAME = FileName
'                            AsistanceCheck.HFILE_TYPE = FileTye
'                            AbsenceRecors = AsistanceCheck.Get_AsistanceCheck()

'                            If AbsenceRecors.Rows.Count = 0 Then
'                                AbsenceRecordByEmployee(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, FileDate)
'                            End If
'                        End If
'                    Case 70 ' Jornada Completa 10/40
'                        Dim RecordsByEmployeeType1040 As New CL_EntryExitFile
'                        Dim IdealEntryRecords As DataTable
'                        RecordsByEmployeeType1040.EMPL_ID = CInt(EmployeeRow(0))
'                        RecordsByEmployeeType1040.HFILE_NAME = FileName
'                        RecordsByEmployeeType1040.ENTTYPE_ID = 10  ' Entrada puntual 
'                        RecordsByEmployeeType1040.EXTTYPE_ID = 40  ' Salida puntual 
'                        IdealEntryRecords = RecordsByEmployeeType1040.Get_EntryExitRecordsByEmployeeIDEnTypes()

'                        Dim DateRecord As Date
'                        Dim EntryRecord As DateTime
'                        Dim ExitRecord As DateTime
'                        If IdealEntryRecords.Rows.Count = 2 Then
'                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
'                                If IdealRow(9) = 10 Then
'                                    DateRecord = IdealRow(10)
'                                    EntryRecord = IdealRow(12)
'                                ElseIf IdealRow(9) = 40 Then
'                                    ExitRecord = IdealRow(12)
'                                End If
'                            Next

'                            IdealFullTimeRecordByEmployee1040(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
'                        End If
'                    Case 80 'Jornada Completa - Entrada con tolerancia salida puntual 20/40
'                        Dim RecordsByEmployeeType2040 As New CL_EntryExitFile
'                        Dim IdealEntryRecords As DataTable
'                        RecordsByEmployeeType2040.EMPL_ID = CInt(EmployeeRow(0))
'                        RecordsByEmployeeType2040.HFILE_NAME = FileName
'                        RecordsByEmployeeType2040.ENTTYPE_ID = 20  ' Entrada con Tolerancia
'                        RecordsByEmployeeType2040.EXTTYPE_ID = 40  ' Salida puntual 
'                        IdealEntryRecords = RecordsByEmployeeType2040.Get_EntryExitRecordsByEmployeeIDEnTypes()

'                        Dim DateRecord As Date
'                        Dim EntryRecord As DateTime
'                        Dim ExitRecord As DateTime
'                        If IdealEntryRecords.Rows.Count = 2 Then
'                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
'                                If IdealRow(9) = 20 Then
'                                    DateRecord = IdealRow(10)
'                                    EntryRecord = IdealRow(12)
'                                ElseIf IdealRow(9) = 40 Then
'                                    ExitRecord = IdealRow(12)
'                                End If
'                            Next

'                            CompleteTimeRecordByEmployee2040(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
'                        End If
'                    Case 85 'Jornada Completa con Tiempo Adicional 20/55
'                        Dim IncompleteRecordByEmployee2055 As New CL_EntryExitFile
'                        Dim IdealEntryRecords As DataTable
'                        IncompleteRecordByEmployee2055.EMPL_ID = CInt(EmployeeRow(0))
'                        IncompleteRecordByEmployee2055.HFILE_NAME = FileName
'                        IncompleteRecordByEmployee2055.ENTTYPE_ID = 20  ' Entrada con Tolerancia
'                        IncompleteRecordByEmployee2055.EXTTYPE_ID = 55  ' Salida Anticipada
'                        IdealEntryRecords = IncompleteRecordByEmployee2055.Get_EntryExitRecordsByEmployeeIDEnTypes()

'                        Dim Count As Integer = 0
'                        Dim DateRecord As Date
'                        Dim EntryRecord As DateTime
'                        Dim ExitRecord As DateTime
'                        If IdealEntryRecords.Rows.Count = 2 Then
'                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
'                                If IdealRow(9) = 20 Then
'                                    DateRecord = IdealRow(10)
'                                    EntryRecord = IdealRow(12)
'                                ElseIf IdealRow(9) = 55 Then
'                                    ExitRecord = IdealRow(12)
'                                End If
'                            Next

'                            IncompleteTimeRecordByEmployee2055(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
'                        End If
'                    Case 90 'Jornada Incompleta - Entrada puntual salida anticipada 10/50
'                        Dim IncompleteRecordByEmployee1050 As New CL_EntryExitFile
'                        Dim IdealEntryRecords As DataTable
'                        IncompleteRecordByEmployee1050.EMPL_ID = CInt(EmployeeRow(0))
'                        IncompleteRecordByEmployee1050.HFILE_NAME = FileName
'                        IncompleteRecordByEmployee1050.ENTTYPE_ID = 10  ' Entrada Puntual
'                        IncompleteRecordByEmployee1050.EXTTYPE_ID = 50  ' Salida Anticipada
'                        IdealEntryRecords = IncompleteRecordByEmployee1050.Get_EntryExitRecordsByEmployeeIDEnTypes()

'                        Dim Count As Integer = 0
'                        Dim DateRecord As Date
'                        Dim EntryRecord As DateTime
'                        Dim ExitRecord As DateTime
'                        If IdealEntryRecords.Rows.Count = 2 Then
'                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
'                                If IdealRow(9) = 10 Then
'                                    DateRecord = IdealRow(10)
'                                    EntryRecord = IdealRow(12)
'                                ElseIf IdealRow(9) = 50 Then
'                                    ExitRecord = IdealRow(12)
'                                End If
'                            Next

'                            IncompleteTimeRecordByEmployee1050(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
'                        End If
'                    Case 100 'Jornada Incompleta - Entrada con retardo salida anticipada 30/50
'                        Dim IncompleteRecordByEmployee3050 As New CL_EntryExitFile
'                        Dim IdealEntryRecords As DataTable
'                        IncompleteRecordByEmployee3050.EMPL_ID = CInt(EmployeeRow(0))
'                        IncompleteRecordByEmployee3050.HFILE_NAME = FileName
'                        IncompleteRecordByEmployee3050.ENTTYPE_ID = 30  ' Retardo
'                        IncompleteRecordByEmployee3050.EXTTYPE_ID = 50  ' Salida Anticipada
'                        IdealEntryRecords = IncompleteRecordByEmployee3050.Get_EntryExitRecordsByEmployeeIDEnTypes()

'                        Dim Count As Integer = 0
'                        Dim DateRecord As Date
'                        Dim EntryRecord As DateTime
'                        Dim ExitRecord As DateTime
'                        If IdealEntryRecords.Rows.Count = 2 Then
'                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
'                                If IdealRow(9) = 30 Then
'                                    DateRecord = IdealRow(10)
'                                    EntryRecord = IdealRow(12)
'                                ElseIf IdealRow(9) = 50 Then
'                                    ExitRecord = IdealRow(12)
'                                End If
'                            Next

'                            IncompleteTimeRecordByEmployee3050(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
'                        End If
'                    Case 110 'Jornada Incompleta - Entrada con retardo salida puntual       30/40
'                        Dim IncompleteRecordByEmployee3040 As New CL_EntryExitFile
'                        Dim IdealEntryRecords As DataTable
'                        IncompleteRecordByEmployee3040.EMPL_ID = CInt(EmployeeRow(0))
'                        IncompleteRecordByEmployee3040.HFILE_NAME = FileName
'                        IncompleteRecordByEmployee3040.ENTTYPE_ID = 30  ' Retardo
'                        IncompleteRecordByEmployee3040.EXTTYPE_ID = 40  ' Salida Puntual
'                        IdealEntryRecords = IncompleteRecordByEmployee3040.Get_EntryExitRecordsByEmployeeIDEnTypes()

'                        Dim Count As Integer = 0
'                        Dim DateRecord As Date
'                        Dim EntryRecord As DateTime
'                        Dim ExitRecord As DateTime
'                        If IdealEntryRecords.Rows.Count = 2 Then
'                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
'                                If IdealRow(9) = 30 Then
'                                    DateRecord = IdealRow(10)
'                                    EntryRecord = IdealRow(12)
'                                ElseIf IdealRow(9) = 40 Then
'                                    ExitRecord = IdealRow(12)
'                                End If
'                            Next

'                            IncompleteTimeRecordByEmployee3040(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
'                        End If
'                    Case 120 'Jornada Incompleta - Entrada con tolerancia salida anticipada 20/50
'                        Dim IncompleteRecordByEmployee2050 As New CL_EntryExitFile
'                        Dim IdealEntryRecords As DataTable
'                        IncompleteRecordByEmployee2050.EMPL_ID = CInt(EmployeeRow(0))
'                        IncompleteRecordByEmployee2050.HFILE_NAME = FileName
'                        IncompleteRecordByEmployee2050.ENTTYPE_ID = 20  ' Entrada con Tolerancia
'                        IncompleteRecordByEmployee2050.EXTTYPE_ID = 50  ' Salida Anticipada
'                        IdealEntryRecords = IncompleteRecordByEmployee2050.Get_EntryExitRecordsByEmployeeIDEnTypes()

'                        Dim Count As Integer = 0
'                        Dim DateRecord As Date
'                        Dim EntryRecord As DateTime
'                        Dim ExitRecord As DateTime
'                        If IdealEntryRecords.Rows.Count = 2 Then
'                            For Each IdealRow As DataRow In IdealEntryRecords.Rows
'                                If IdealRow(9) = 20 Then
'                                    DateRecord = IdealRow(10)
'                                    EntryRecord = IdealRow(12)
'                                ElseIf IdealRow(9) = 50 Then
'                                    ExitRecord = IdealRow(12)
'                                End If
'                            Next

'                            IncompleteTimeRecordByEmployee2050(CInt(EmployeeRow(0)), CInt(Asistance(0)), AppUser, Date.Now, DateRecord, EntryRecord, ExitRecord)
'                        End If
'                End Select
'            Next
'        Next

'        Return Result
'    End Function

'    Private Function InserEntryRecordByEmployee(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        Result = NewRecordByEmployee.InsertEntryRecordByEmployee()

'        Return Result
'    End Function

'    Private Function InserExitRecordByEmployee(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.InsertExitRecordByEmployee()

'        Return Result
'    End Function

'    Private Function IdealFullTimeRecordByEmployee1040(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.IdealFullTimeRecordByEmployee()

'        Return Result
'    End Function

'    Private Function CompleteTimeRecordByEmployee2040(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

'        Return Result
'    End Function

'    Private Function IncompleteTimeRecordByEmployee1050(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

'        Return Result
'    End Function

'    Private Function IncompleteTimeRecordByEmployee3050(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

'        Return Result
'    End Function

'    Private Function IncompleteTimeRecordByEmployee3040(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

'        Return Result
'    End Function

'    Private Function IncompleteTimeRecordByEmployee2050(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

'        Return Result
'    End Function

'    Private Function IncompleteTimeRecordByEmployee2055(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date, ByVal DREMPL_ENDATI As DateTime, ByVal DREMPL_EXDATI As DateTime) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        NewRecordByEmployee.DREMPL_ENDATI = DREMPL_ENDATI
'        NewRecordByEmployee.DREMPL_EXDATI = DREMPL_EXDATI
'        Result = NewRecordByEmployee.ImcompletelFullTimeRecordByEmployee()

'        Return Result
'    End Function

'    Private Function AbsenceRecordByEmployee(ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer, ByVal REMPL_CREBY As String, ByVal REMPL_RDATE As DateTime, ByVal DREMPL_DATE As Date) As Boolean
'        Dim Result As Boolean = False

'        Dim NewRecordByEmployee = New CL_RecordsByEmployee()
'        NewRecordByEmployee.EMPL_ID = EMPL_ID
'        NewRecordByEmployee.MOVE_ID = MOVE_ID
'        NewRecordByEmployee.REMPL_CREBY = REMPL_CREBY
'        NewRecordByEmployee.REMPL_RDATE = REMPL_RDATE
'        NewRecordByEmployee.DREMPL_DATE = DREMPL_DATE
'        Result = NewRecordByEmployee.AbsenceRecordByEmployee()

'        Return Result
'    End Function

'    Private Sub Display_EntryRecords()
'        Dim RecordsByEmployees As New CL_RecordsByEmployee()
'        DGV_Registerinformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
'        DGV_Registerinformation.AutoResizeColumns()
'        DGV_Registerinformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
'        DGV_Registerinformation.DataSource = RecordsByEmployees.Get_AllRecordsByEntryFile(FileDate)
'    End Sub

'    Private Sub Display_ExitRecords()
'        Dim RecordsByEmployees As New CL_RecordsByEmployee()
'        DGV_Registerinformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
'        DGV_Registerinformation.AutoResizeColumns()
'        DGV_Registerinformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
'        DGV_Registerinformation.DataSource = RecordsByEmployees.Get_AllRecordsByExitFile(FileDate)
'    End Sub

'    Private Sub MoveFileToBackup(originalPath As String, fileDate As Date, baseFolder As String)

'        Try
'            'Obtener año y mes
'            Dim yearFolder As String = fileDate.Year.ToString()
'            Dim monthFolder As String = fileDate.Month.ToString("00")

'            'Ruta final dentro de Entradas o Salidas
'            Dim finalPath As String = Path.Combine(baseFolder, yearFolder, monthFolder)

'            'Crear carpeta si no existe
'            If Not Directory.Exists(finalPath) Then
'                Directory.CreateDirectory(finalPath)
'            End If

'            'Nombre del archivo
'            Dim fileName As String = Path.GetFileName(originalPath)

'            'Ruta destino
'            Dim destinationFile As String = Path.Combine(finalPath, fileName)

'            'Si ya existe lo reemplaza
'            If File.Exists(destinationFile) Then
'                File.Delete(destinationFile)
'            End If

'            'Mover archivo
'            File.Move(originalPath, destinationFile)

'        Catch ex As Exception
'            MessageBox.Show("Error al mover archivo a backup: " & ex.Message)
'        End Try

'    End Sub

'    Private Sub BT_CleanFields_Click(sender As Object, e As EventArgs) Handles BT_CleanFields.Click
'        InitializationOfFields()
'        BT_LoadFile.Enabled = True
'    End Sub
'End Class