Imports System.Data
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Diagnostics.Metrics
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports DocumentFormat.OpenXml.Bibliography
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Math
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Microsoft.Identity.Client
Imports System.Drawing
Imports System

Public Class OP_INS_MANUALLUNCHHOURS

    Private LUNCH_MOVE As Integer = 250 ' Lunch Hours
    Private BANN_MOVE As Integer = 270 ' Lunch Hours
    Private TRANSPORT_MOVE As Integer = 280
    Private Sub OP_INS_MANUALLUNCHHOURS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadActiveEmployees()

        DTP_DateLunchHours.Value = DateTime.Now
        BT_RegisterInfo.Enabled = False

    End Sub

    'Cargar empleados activos
    'Private Sub LoadActiveEmployees()
    '    Try
    '        Dim Employees As New CL_Employee
    '        Dim dt As DataTable = Employees.Get_AllActiveEmployeesListForLunchHoursAndBanns()
    '        DGV_ActiveEmployeesInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '        DGV_ActiveEmployeesInfo.AutoResizeColumns()
    '        DGV_ActiveEmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '        DGV_ActiveEmployeesInfo.DataSource = dt

    '        'Agregar columna editable de horas
    '        Dim ColLunchHours As New DataGridViewTextBoxColumn

    '        ColLunchHours.Name = "DREMPL_LHOUR"
    '        ColLunchHours.HeaderText = "Horas de Comida"
    '        ColLunchHours.ValueType = GetType(Decimal)

    '        DGV_ActiveEmployeesInfo.Columns.Add(ColLunchHours)

    '        'Agregar columna editable de horas
    '        Dim ColBannQuant As New DataGridViewTextBoxColumn

    '        ColBannQuant.Name = "DREMPL_BQUANT"
    '        ColBannQuant.HeaderText = "No. de Amonestaciones"
    '        ColBannQuant.ValueType = GetType(Decimal)

    '        DGV_ActiveEmployeesInfo.Columns.Add(ColBannQuant)

    '        'Configuración visual
    '        DGV_ActiveEmployeesInfo.Columns(0).ReadOnly = True
    '        DGV_ActiveEmployeesInfo.Columns(1).ReadOnly = True
    '        DGV_ActiveEmployeesInfo.Columns(2).ReadOnly = True
    '        DGV_ActiveEmployeesInfo.Columns(3).ReadOnly = True
    '        DGV_ActiveEmployeesInfo.Columns(4).ReadOnly = True
    '        DGV_ActiveEmployeesInfo.Columns(5).DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow
    '        DGV_ActiveEmployeesInfo.Columns(6).DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan

    '        DGV_ActiveEmployeesInfo.Columns(0).Width = 40
    '        DGV_ActiveEmployeesInfo.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGV_ActiveEmployeesInfo.Columns(1).Width = 220
    '        DGV_ActiveEmployeesInfo.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        DGV_ActiveEmployeesInfo.Columns(2).Width = 40
    '        DGV_ActiveEmployeesInfo.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGV_ActiveEmployeesInfo.Columns(3).Width = 280
    '        DGV_ActiveEmployeesInfo.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        DGV_ActiveEmployeesInfo.Columns(4).Width = 100
    '        DGV_ActiveEmployeesInfo.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        DGV_ActiveEmployeesInfo.Columns(5).Width = 150
    '        DGV_ActiveEmployeesInfo.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        DGV_ActiveEmployeesInfo.Columns(6).Width = 150
    '        DGV_ActiveEmployeesInfo.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Private Sub LoadActiveEmployees()
        Try
            Dim Employees As New CL_Employee
            Dim dt As DataTable = Employees.Get_AllActiveEmployeesListForLunchHoursAndBanns()
            DGV_ActiveEmployeesInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_ActiveEmployeesInfo.AutoResizeColumns()
            DGV_ActiveEmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DGV_ActiveEmployeesInfo.Columns.Clear()
            DGV_ActiveEmployeesInfo.DataSource = dt



            'Horas de comida
            Dim ColLunchHours As New DataGridViewTextBoxColumn
            ColLunchHours.Name = "DREMPL_LHOUR"
            ColLunchHours.HeaderText = "Horas de Comida"
            ColLunchHours.ValueType = GetType(Decimal)
            DGV_ActiveEmployeesInfo.Columns.Add(ColLunchHours)

            'Amonestaciones
            Dim ColBannQuant As New DataGridViewTextBoxColumn
            ColBannQuant.Name = "DREMPL_BQUANT"
            ColBannQuant.HeaderText = "No. de Amonestaciones"
            ColBannQuant.ValueType = GetType(Decimal)
            DGV_ActiveEmployeesInfo.Columns.Add(ColBannQuant)

            'Dias de transporte
            Dim ColTransportDays As New DataGridViewTextBoxColumn
            ColTransportDays.Name = "DREMPL_TDAYS"
            ColTransportDays.HeaderText = "Días Transporte"
            ColTransportDays.ValueType = GetType(Decimal)
            DGV_ActiveEmployeesInfo.Columns.Add(ColTransportDays)

            DGV_ActiveEmployeesInfo.Columns("Beneficio transporte").ReadOnly = True


            For i As Integer = 0 To 4
                DGV_ActiveEmployeesInfo.Columns(i).ReadOnly = True
            Next


            DGV_ActiveEmployeesInfo.Columns("DREMPL_LHOUR").DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow
            DGV_ActiveEmployeesInfo.Columns("DREMPL_BQUANT").DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
            DGV_ActiveEmployeesInfo.Columns("DREMPL_TDAYS").DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew

            DGV_ActiveEmployeesInfo.Columns("Beneficio transporte").DisplayIndex = 7
            DGV_ActiveEmployeesInfo.Columns("DREMPL_TDAYS").DisplayIndex = 8

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'solo numeros
    Private Sub DGV_ActiveEmployeesInfo_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGV_ActiveEmployeesInfo.EditingControlShowing

        Dim colName = DGV_ActiveEmployeesInfo.CurrentCell.OwningColumn.Name

        If colName = "DREMPL_LHOUR" Or colName = "DREMPL_BQUANT" Or colName = "DREMPL_TDAYS" Then

            Dim txt As TextBox = CType(e.Control, TextBox)

            RemoveHandler txt.KeyPress, AddressOf OnlyDecimalNumbers
            AddHandler txt.KeyPress, AddressOf OnlyDecimalNumbers

        End If

    End Sub


    Private Sub OnlyDecimalNumbers(sender As Object, e As KeyPressEventArgs)

        If Not Char.IsDigit(e.KeyChar) AndAlso
           Not e.KeyChar = "." AndAlso
           Not e.KeyChar = Chr(8) Then

            e.Handled = True

        End If

    End Sub

    Private Function GetWeekRange(selectedDate As Date) As Tuple(Of Date, Date)

        Dim startDate As Date = selectedDate

        While startDate.DayOfWeek <> DayOfWeek.Thursday
            startDate = startDate.AddDays(-1)
        End While

        Dim endDate As Date = startDate.AddDays(6)

        Return System.Tuple.Create(startDate, endDate)

    End Function


    'Registrar valores
    Private Sub BT_RegisterInfo_Click(sender As Object, e As EventArgs) Handles BT_RegisterInfo.Click
        Dim weekRange = GetWeekRange(DTP_DateLunchHours.Value)

        Dim startDate As Date = weekRange.Item1
        Dim endDate As Date = weekRange.Item2

        Dim ExistRecords = New CL_RecordsByEmployee
        Dim Records As DataTable = ExistRecords.Get_ExistHoursBannsRecords(startDate, endDate)

        If Records.Rows.Count > 0 Then
            MessageBox.Show("Ya fueron ingresados los registros de la semana seleccionada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try

                For Each row As DataGridViewRow In DGV_ActiveEmployeesInfo.Rows
                    If row.IsNewRow Then Continue For

                    'Both are nothing
                    'If row.Cells("DREMPL_LHOUR").Value Is Nothing And row.Cells("DREMPL_BQUANT").Value Is Nothing Then Continue For
                    If row.Cells("DREMPL_LHOUR").Value Is Nothing And row.Cells("DREMPL_BQUANT").Value Is Nothing And
                                 (row.Cells("DREMPL_TDAYS").Value Is Nothing OrElse
                                  String.IsNullOrWhiteSpace(row.Cells("DREMPL_TDAYS").Value?.ToString())) Then

                        Continue For
                    End If

                    'We have only Lunch Hours
                    If row.Cells("DREMPL_LHOUR").Value IsNot Nothing And row.Cells("DREMPL_BQUANT").Value Is Nothing Then
                        Dim hoursValue As Decimal

                        If Not Decimal.TryParse(row.Cells("DREMPL_LHOUR").Value.ToString(), hoursValue) Then
                            MessageBox.Show("Favor de verificar los valores ingresados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            If hoursValue <= 0 Then
                                MessageBox.Show("Favor de verificar que solo haya números validos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf (hoursValue > 0 And hoursValue <= 5) Then

                                Dim EMPL_ID As Integer = Convert.ToInt32(row.Cells("No.").Value)
                                Dim NewRecordByEmployee As New CL_RecordsByEmployee()

                                NewRecordByEmployee.EMPL_ID = EMPL_ID
                                NewRecordByEmployee.MOVE_ID = LUNCH_MOVE
                                NewRecordByEmployee.REMPL_CREBY = AppUser
                                NewRecordByEmployee.REMPL_RDATE = DateTime.Now
                                NewRecordByEmployee.DREMPL_DATE = DTP_DateLunchHours.Value.Date
                                NewRecordByEmployee.DREMPL_LHOUR = hoursValue
                                NewRecordByEmployee.InsertLunchHoursRecordByEmployee()
                            End If
                        End If
                    End If

                    'We have only Banns Number
                    If row.Cells("DREMPL_LHOUR").Value Is Nothing And row.Cells("DREMPL_BQUANT").Value IsNot Nothing Then
                        Dim BannsValue As Decimal

                        If Not Decimal.TryParse(row.Cells("DREMPL_BQUANT").Value.ToString(), BannsValue) Then
                            MessageBox.Show("Favor de verificar los valores ingresados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            If BannsValue <= 0 Then
                                MessageBox.Show("Favor de verificar que solo haya números validos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf (BannsValue > 0 And BannsValue <= 6) Then

                                Dim EMPL_ID As Integer = Convert.ToInt32(row.Cells("No.").Value)
                                Dim NewRecordByEmployee As New CL_RecordsByEmployee()

                                NewRecordByEmployee.EMPL_ID = EMPL_ID
                                NewRecordByEmployee.MOVE_ID = BANN_MOVE
                                NewRecordByEmployee.REMPL_CREBY = AppUser
                                NewRecordByEmployee.REMPL_RDATE = DateTime.Now
                                NewRecordByEmployee.DREMPL_DATE = DTP_DateLunchHours.Value.Date
                                NewRecordByEmployee.DREMPL_BQUANT = BannsValue
                                NewRecordByEmployee.InsertBannsQuantityRecordByEmployee()

                            End If
                        End If
                    End If

                    'Both are nothing
                    If row.Cells("DREMPL_LHOUR").Value IsNot Nothing And row.Cells("DREMPL_BQUANT").Value IsNot Nothing Then
                        Dim hoursValue As Decimal
                        Dim BannsValue As Decimal

                        If Not Decimal.TryParse(row.Cells("DREMPL_LHOUR").Value.ToString(), hoursValue) Or
                                        Not Decimal.TryParse(row.Cells("DREMPL_BQUANT").Value.ToString(), BannsValue) Then
                            MessageBox.Show("Favor de verificar los valores ingresados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            If hoursValue <= 0 Or BannsValue <= 0 Then
                                MessageBox.Show("Favor de verificar que solo haya números validos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf ((hoursValue > 0 And hoursValue <= 5) And (BannsValue > 0 And BannsValue <= 6)) Then 'Both have value

                                Dim EMPL_ID As Integer = Convert.ToInt32(row.Cells("No.").Value)
                                Dim NewRecordByEmployee As New CL_RecordsByEmployee()

                                NewRecordByEmployee.EMPL_ID = EMPL_ID
                                NewRecordByEmployee.REMPL_CREBY = AppUser
                                NewRecordByEmployee.MOVE_ID = BANN_MOVE
                                NewRecordByEmployee.REMPL_RDATE = DateTime.Now
                                NewRecordByEmployee.DREMPL_DATE = DTP_DateLunchHours.Value.Date
                                NewRecordByEmployee.DREMPL_LHOUR = hoursValue
                                NewRecordByEmployee.DREMPL_BQUANT = BannsValue
                                NewRecordByEmployee.InsertBannsQuantityRecordByEmployee()
                                NewRecordByEmployee.MOVE_ID = LUNCH_MOVE
                                NewRecordByEmployee.InsertLunchHoursRecordByEmployee()

                            End If
                        End If
                    End If

                    If row.Cells("DREMPL_TDAYS").Value IsNot Nothing AndAlso
                            Not String.IsNullOrWhiteSpace(row.Cells("DREMPL_TDAYS").Value.ToString()) Then

                        Dim tdays As Decimal

                        If Decimal.TryParse(row.Cells("DREMPL_TDAYS").Value.ToString(), tdays) Then

                            If tdays > 0 AndAlso tdays <= 7 Then

                                Dim EMPL_ID As Integer = Convert.ToInt32(row.Cells("No.").Value)

                                Dim NewRecordByEmployee As New CL_RecordsByEmployee()

                                NewRecordByEmployee.EMPL_ID = EMPL_ID
                                NewRecordByEmployee.MOVE_ID = 280
                                NewRecordByEmployee.REMPL_CREBY = AppUser
                                NewRecordByEmployee.REMPL_RDATE = DateTime.Now
                                NewRecordByEmployee.DREMPL_DATE = DTP_DateLunchHours.Value.Date
                                NewRecordByEmployee.DREMPL_TDAYS = tdays

                                NewRecordByEmployee.InsertTransportDaysRecordByEmployee()

                            End If

                        End If

                    End If

                Next

                MessageBox.Show("Se regitró la información correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BT_RegisterInfo.Enabled = False
                DGV_ActiveEmployeesInfo.Columns.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        End If


    End Sub


    Private Sub DGV_ActiveEmployeesInfo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ActiveEmployeesInfo.CellEndEdit

        Dim cell = DGV_ActiveEmployeesInfo.Rows(e.RowIndex).Cells(e.ColumnIndex)

        If cell.Value Is Nothing Then Exit Sub

        Dim number As Decimal

        If Not Decimal.TryParse(cell.Value.ToString(), number) Then
            MessageBox.Show("Solo se permiten números.")
            cell.Value = ""
            Exit Sub
        End If

        If number > 5 Then
            MessageBox.Show("Solo se permiten valores del 0 al 5.")
            cell.Value = ""
        End If

    End Sub

    Private Sub DTP_DateLunchHours_MouseCaptureChanged(sender As Object, e As EventArgs) Handles DTP_DateLunchHours.MouseCaptureChanged
        BT_RegisterInfo.Enabled = True
    End Sub
End Class


