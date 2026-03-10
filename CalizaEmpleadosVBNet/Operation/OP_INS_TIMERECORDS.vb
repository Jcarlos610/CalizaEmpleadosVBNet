Imports System.IO
Imports System.Windows.Forms.VisualStyles
Imports Microsoft.Data.SqlClient

Public Class OP_INS_TIMERECORDS
    Dim FileName As String
    Dim FileTye As Integer

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
        ElseIf OptionOfLoad_Number = 30 Then
            OpenFileDialog.Title = "Seleccione el archivo de salidas"
            OpenFileDialog.InitialDirectory = My.Settings.WorkTimeFilesExit
        End If

        FileTye = OptionOfLoad_Number
        OpenFileDialog.Filter = "Archivos de texto|*.csv"

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            TB_SourcePath.Text = OpenFileDialog.FileName
        End If

        Dim path As String = TB_SourcePath.Text

        If Not File.Exists(path) Then
            Exit Sub
        End If

        FileName = System.IO.Path.GetFileName(OpenFileDialog.FileName)
        Dim fileDate As Date = GetDateFromFileName(path)

        LoadCSVToDGV(path, fileDate)

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

    Private Sub LoadCSVToDGV(path As String, fileDate As Date)
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

        DGV_FileContent.Rows.Clear()

        Dim lines() As String = File.ReadAllLines(path, System.Text.Encoding.GetEncoding(1252))
        Dim LineIndex As Integer = 0

        For Each line As String In lines
            If LineIndex = 0 Then
                LineIndex += 1
                Continue For
            End If

            If String.IsNullOrWhiteSpace(line) Then Continue For

            Dim values() As String = line.Replace("'", "").Split(",")

            Dim RecordID As Integer = Convert.ToInt32(values(0).Trim())
            Dim empInfo() As String = values(1).Trim().Split("-")
            Dim EmplID As Integer = CInt(empInfo(0))
            Dim empName As String = empInfo(1).ToString
            Dim hourText As String = values(2).Trim()
            Dim timeValue As DateTime = ParseSpanishTime(hourText)
            Dim fullDateTime As DateTime = fileDate.Date.Add(timeValue.TimeOfDay)
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
                fileDate.ToString("dd/MM/yyyy"),
                timeValue.ToString("HH:mm:ss"),
                fullDateTime,
                Comment
            )

            If Comment = "Tolerancia" Then
                DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            ElseIf Comment = "Retardo" Then
                DGV_FileContent.Rows(rowIndex).DefaultCellStyle.BackColor = Color.MistyRose
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

        timeText = timeText.Replace("a. m.", "AM")
        timeText = timeText.Replace("p. m.", "PM")
        timeText = timeText.Replace("a.m.", "AM")
        timeText = timeText.Replace("p.m.", "PM")

        Return DateTime.Parse(timeText)

    End Function

    Private Sub CB_Options_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Options.SelectedIndexChanged
        BT_LoadFile.Enabled = True
    End Sub

    Private Sub BT_RegisterInformation_Click(sender As Object, e As EventArgs) Handles BT_RegisterInformation.Click

        If DGV_FileContent.Rows.Count = 0 Then Exit Sub

        Dim conn As New SqlConnection(My.Settings.ConnectionString)
        conn.Open()

        Try

            Dim FileComment As String = TB_Comment.Text
            Dim NumberOfRecords As Integer = DGV_FileContent.Rows.Count

            Dim AssistanceFileHeader As New CL_AsistanceFiles(FileTye, FileName, NumberOfRecords, FileComment, AppUser, Date.Now)

            'VALIDAR SI EL ARCHIVO YA EXISTE
            If AssistanceFileHeader.FileAlreadyExists(conn) Then

                MessageBox.Show("El archivo: " & FileName & vbCrLf &
                                "ya fue registrado anteriormente.",
                                "Archivo duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                InitializationOfFields()
                CB_Options.Enabled = True

                conn.Close()
                Exit Sub

            End If

            'INICIAR TRANSACCIÓN SOLO SI NO EXISTE
            Dim trans As SqlTransaction = conn.BeginTransaction()

            Dim L_HFILE_ID As Integer = AssistanceFileHeader.InsertAsistanceFileHeader(conn, trans)

            For Each Line As DataGridViewRow In DGV_FileContent.Rows

                Dim Item As New CL_AsistanceFiles

                Item.HFILE_ID = L_HFILE_ID
                Item.EMPL_ID = Line.Cells("EmpID").Value

                If Line.Cells("Comment").Value = "Puntual" Then
                    Item.ENTTYPE_ID = 10
                ElseIf Line.Cells("Comment").Value = "Tolerancia" Then
                    Item.ENTTYPE_ID = 20
                ElseIf Line.Cells("Comment").Value = "Retardo" Then
                    Item.ENTTYPE_ID = 30
                End If

                Item.IFILE_DATE = Line.Cells("DATE").Value
                Item.IFILE_TIME = Line.Cells("TIME").Value
                Item.IFILE_DATI = Line.Cells("FullDateTime").Value

                Item.InsertAsistanceFileItem(conn, trans)

            Next

            trans.Commit()

            MessageBox.Show("Archivo: " & FileName & vbCrLf &
                            "se registró correctamente.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            InitializationOfFields()
            CB_Options.Enabled = True

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Finally

            conn.Close()

        End Try

    End Sub
End Class