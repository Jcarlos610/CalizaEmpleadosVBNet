Public Class OP_UPD_MANUALLUNCHHOURS

    Private loading As Boolean = False

    Private Sub OP_UPD_MANUALLUNCHHOURS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDates()
    End Sub

    Private Sub LoadDates()

        loading = True

        Dim obj As New CL_RecordsByEmployee
        Dim dt As DataTable = obj.GetLunchDates()

        dt.Columns.Add("DisplayDate", GetType(String))

        For Each row As DataRow In dt.Rows
            row("DisplayDate") = Convert.ToDateTime(row("DREMPL_DATE")).ToString("dd/MM/yyyy")
        Next

        CB_Dates.DataSource = dt
        CB_Dates.DisplayMember = "DisplayDate"
        CB_Dates.ValueMember = "DREMPL_DATE"


        CB_Dates.SelectedIndex = -1
        CB_Dates.Text = "Seleccione una fecha"

        loading = False

    End Sub

    Private Sub CB_Dates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Dates.SelectedIndexChanged
        If loading Then Exit Sub
        If CB_Dates.SelectedValue Is Nothing Then Exit Sub
        If TypeOf CB_Dates.SelectedValue Is DataRowView Then Exit Sub

        Dim fecha As Date = Convert.ToDateTime(CB_Dates.SelectedValue)

        Dim obj As New CL_RecordsByEmployee
        DGV_ActiveEmployeesInfo.DataSource = obj.GetLunchByDate(fecha)

        If DGV_ActiveEmployeesInfo.Columns.Contains("EMPL_ID") Then
            DGV_ActiveEmployeesInfo.Columns("EMPL_ID").HeaderText = "ID"
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("NombreEmpleado") Then
            DGV_ActiveEmployeesInfo.Columns("NombreEmpleado").HeaderText = "Empleado"
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("DREMPL_LHOUR") Then
            DGV_ActiveEmployeesInfo.Columns("DREMPL_LHOUR").HeaderText = "Horas de comida"
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("DREMPL_BQUANT") Then
            DGV_ActiveEmployeesInfo.Columns("DREMPL_BQUANT").HeaderText = "Amonestaciones"
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("DREMPL_ID") Then
            DGV_ActiveEmployeesInfo.Columns("DREMPL_ID").Visible = False
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("LUNCH_ID") Then
            DGV_ActiveEmployeesInfo.Columns("LUNCH_ID").Visible = False
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("BANN_ID") Then
            DGV_ActiveEmployeesInfo.Columns("BANN_ID").Visible = False
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("DREMPL_TDAYS") Then
            DGV_ActiveEmployeesInfo.Columns("DREMPL_TDAYS").HeaderText = "Días de transporte"
        End If

        If DGV_ActiveEmployeesInfo.Columns.Contains("TDAYS_ID") Then
            DGV_ActiveEmployeesInfo.Columns("TDAYS_ID").Visible = False
        End If



        FormatGrid()
    End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
        Dim obj As New CL_RecordsByEmployee

        For Each row As DataGridViewRow In DGV_ActiveEmployeesInfo.Rows

            If row.IsNewRow Then Continue For

            'Dim emplId As Integer = Convert.ToInt32(row.Cells("EMPL_ID").Value)
            Dim emplId As Integer = Convert.ToInt32(row.Cells("No.").Value)

            If row.Cells("DREMPL_LHOUR").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DREMPL_LHOUR").Value) Then

                Dim hours As Decimal

                If Decimal.TryParse(row.Cells("DREMPL_LHOUR").Value.ToString(), hours) Then
                    If hours > 0 AndAlso hours <= 5 Then

                        If Not IsDBNull(row.Cells("LUNCH_ID").Value) Then
                            Dim id As Integer = Convert.ToInt32(row.Cells("LUNCH_ID").Value)
                            obj.UpdateLunchHours(id, hours)

                        Else
                            obj.EMPL_ID = emplId
                            obj.MOVE_ID = 250
                            obj.REMPL_CREBY = AppUser
                            obj.REMPL_RDATE = DateTime.Now
                            obj.DREMPL_DATE = Convert.ToDateTime(CB_Dates.SelectedValue)
                            obj.DREMPL_LHOUR = hours

                            obj.InsertLunchHoursRecordByEmployee()
                        End If

                    End If
                End If
            End If

            If row.Cells("DREMPL_BQUANT").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DREMPL_BQUANT").Value) Then

                Dim bann As Decimal

                If Decimal.TryParse(row.Cells("DREMPL_BQUANT").Value.ToString(), bann) Then
                    If bann > 0 AndAlso bann <= 6 Then

                        If Not IsDBNull(row.Cells("BANN_ID").Value) Then
                            Dim id As Integer = Convert.ToInt32(row.Cells("BANN_ID").Value)
                            obj.UpdateBann(id, bann)

                        Else
                            obj.EMPL_ID = emplId
                            obj.MOVE_ID = 270
                            obj.REMPL_CREBY = AppUser
                            obj.REMPL_RDATE = DateTime.Now
                            obj.DREMPL_DATE = Convert.ToDateTime(CB_Dates.SelectedValue)
                            obj.DREMPL_BQUANT = bann

                            obj.InsertBannsQuantityRecordByEmployee()
                        End If

                    End If
                End If
            End If

            If row.Cells("DREMPL_TDAYS").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DREMPL_TDAYS").Value) Then

                Dim tdays As Decimal

                If Decimal.TryParse(row.Cells("DREMPL_TDAYS").Value.ToString(), tdays) Then
                    If tdays > 0 AndAlso tdays <= 31 Then

                        If Not IsDBNull(row.Cells("TDAYS_ID").Value) Then
                            Dim id As Integer = Convert.ToInt32(row.Cells("TDAYS_ID").Value)
                            obj.UpdateTransportDays(id, tdays)

                        Else
                            obj.EMPL_ID = emplId
                            obj.MOVE_ID = 280
                            obj.REMPL_CREBY = AppUser
                            obj.REMPL_RDATE = DateTime.Now
                            obj.DREMPL_DATE = Convert.ToDateTime(CB_Dates.SelectedValue)
                            obj.DREMPL_TDAYS = tdays

                            obj.InsertTransportDaysRecordByEmployee()
                        End If

                    End If
                End If
            End If

        Next

        MessageBox.Show("Datos actualizados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub FormatGrid()
        DGV_ActiveEmployeesInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_ActiveEmployeesInfo.AutoResizeColumns()
        DGV_ActiveEmployeesInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'DGV_ActiveEmployeesInfo.Columns("EMPL_ID").ReadOnly = True
       
        DGV_ActiveEmployeesInfo.Columns("No.").ReadOnly = True
        DGV_ActiveEmployeesInfo.Columns("Nombre Completo").ReadOnly = True
        DGV_ActiveEmployeesInfo.Columns("Nombre de empresa").ReadOnly = True
        DGV_ActiveEmployeesInfo.Columns("Beneficio de comida").ReadOnly = True
        DGV_ActiveEmployeesInfo.Columns("Beneficio de transporte").ReadOnly = True
        DGV_ActiveEmployeesInfo.Columns("Nombre Completo").ReadOnly = True

        DGV_ActiveEmployeesInfo.Columns("DREMPL_LHOUR").DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
        DGV_ActiveEmployeesInfo.Columns("DREMPL_BQUANT").DefaultCellStyle.BackColor = Color.LightCyan
        DGV_ActiveEmployeesInfo.Columns("DREMPL_TDAYS").DefaultCellStyle.BackColor = Color.Honeydew

    End Sub

    Private Sub DGV_ActiveEmployeesInfo_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGV_ActiveEmployeesInfo.EditingControlShowing

        Dim colName = DGV_ActiveEmployeesInfo.CurrentCell.OwningColumn.Name

        If colName = "DREMPL_LHOUR" OrElse colName = "DREMPL_BQUANT" OrElse colName = "DREMPL_TDAYS" Then

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


End Class