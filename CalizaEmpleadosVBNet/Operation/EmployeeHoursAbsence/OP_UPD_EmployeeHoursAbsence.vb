Imports Microsoft.Data.SqlClient

Public Class OP_UPD_EmployeeHoursAbsence

    Dim SelectedHabsID As Integer = 0

    Private Sub OP_UPD_EmployeeHoursAbsence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CB_HoursAbsenceType.Items.Clear()
        CB_HoursAbsenceType.Items.Add("Seleccione una opción...")
        CB_HoursAbsenceType.Items.Add("Comida")
        CB_HoursAbsenceType.Items.Add("Tiempo Extra")
        CB_HoursAbsenceType.Items.Add("Nomina")

        CB_HoursAbsenceType.SelectedIndex = 0
        CargarGridGeneral()
    End Sub

    Private Sub CargarGridGeneral()
        Try
            Dim CL As New CL_RecordByEmployeeHoursAbsence
            DGV_HoursAbsence.DataSource = CL.Get_AllHoursAbsenceRecords(0)

            If DGV_HoursAbsence.Columns.Count > 0 Then
                If DGV_HoursAbsence.Columns.Contains("ID") Then DGV_HoursAbsence.Columns("ID").Visible = False

                DGV_HoursAbsence.ReadOnly = True
                DGV_HoursAbsence.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                DGV_HoursAbsence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                If DGV_HoursAbsence.Columns.Contains("Horas") Then
                    DGV_HoursAbsence.Columns("Horas").DefaultCellStyle.Format = "N2"
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al cargar el listado de permisos de horas: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DGV_HoursAbsence_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_HoursAbsence.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_HoursAbsence.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_HoursAbsence.Rows(hit.RowIndex)

                SelectedHabsID = Convert.ToInt32(row.Cells("ID").Value)
                TB_EmployeeId.Text = row.Cells("Núm. Empleado").Value.ToString()
                TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()
                TB_Cause.Text = row.Cells("Motivo").Value.ToString()
                TB_Description.Text = row.Cells("Descripción").Value.ToString()
                TB_HoursAbsence.Text = row.Cells("Horas").Value.ToString()
                TB_AuthorizeBy.Text = row.Cells("Autorizado Por").Value.ToString()

                If DGV_HoursAbsence.Columns.Contains("Tipo") AndAlso row.Cells("Tipo").Value IsNot Nothing Then
                    CB_HoursAbsenceType.SelectedItem = row.Cells("Tipo").Value.ToString()
                End If

                If IsDate(row.Cells("Fecha Aplicación").Value) Then
                    DTP_Valid.Value = Convert.ToDateTime(row.Cells("Fecha Aplicación").Value)
                End If

                Dim estadoStr As String = row.Cells("Estado").Value.ToString()
                CB_Stat.Checked = (estadoStr <> "Inactivo")

                Dim yaPagada As Boolean = Convert.ToBoolean(row.Cells("Pagada").Value)

                TB_Cause.Enabled = Not yaPagada
                TB_Description.Enabled = Not yaPagada
                TB_HoursAbsence.Enabled = Not yaPagada
                TB_AuthorizeBy.Enabled = Not yaPagada
                DTP_Valid.Enabled = Not yaPagada
                CB_HoursAbsenceType.Enabled = Not yaPagada
                CB_Stat.Enabled = Not yaPagada
                BT_Upd.Enabled = Not yaPagada

                If yaPagada Then
                    MsgBox("Este permiso de horas ya fue cobrado en nómina y no se puede modificar.", MsgBoxStyle.Information, "Registro Pagado")
                End If

            Catch ex As Exception
                MsgBox("Error al seleccionar el registro del Grid: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
            End Try
        End If
    End Sub

    Private Sub DGV_HoursAbsence_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_HoursAbsence.CellFormatting
        If DGV_HoursAbsence.Columns.Contains("Estado") Then
            Dim estadoValue As Object = DGV_HoursAbsence.Rows(e.RowIndex).Cells("Estado").Value

            If estadoValue IsNot Nothing Then
                Select Case estadoValue.ToString()
                    Case "Inactivo"
                        e.CellStyle.ForeColor = Color.DarkGray
                    Case "Pagada"
                        e.CellStyle.ForeColor = Color.SeaGreen
                        e.CellStyle.Font = New Font(DGV_HoursAbsence.Font, FontStyle.Bold)
                End Select
            End If
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        Try
            If SelectedHabsID = 0 Then
                MsgBox("Por favor, seleccione primero un registro del listado superior para editar.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If
            If String.IsNullOrWhiteSpace(TB_Cause.Text) OrElse String.IsNullOrWhiteSpace(TB_AuthorizeBy.Text) Then
                MsgBox("El motivo del permiso de horas y la persona que autoriza son campos obligatorios.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If CB_HoursAbsenceType.SelectedIndex <= 0 Then
                MsgBox("Debe seleccionar cómo se compensarán las horas: Comida, Tiempo Extra o Nómina.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim absHours As Decimal = 0
            If Not Decimal.TryParse(TB_HoursAbsence.Text, absHours) OrElse absHours <= 0 Then
                MsgBox("Ingrese una cantidad de horas válida y mayor a 0.00.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim CL As New CL_RecordByEmployeeHoursAbsence
            CL.HABS_DATE = DTP_Valid.Value.Date
            CL.HABS_CAUSE = TB_Cause.Text.Trim()
            CL.HABS_DESCR = TB_Description.Text.Trim()
            CL.HABS_HOURS = absHours
            CL.HABS_AUTH = TB_AuthorizeBy.Text.Trim()
            CL.HABS_STATUS = CB_Stat.Checked
            CL.HABS_CREBY = GlobalSession.GlobalUserName
            CL.HABS_TYPE = CB_HoursAbsenceType.SelectedItem.ToString()

            If CL.UpdateHoursAbsenceRecord(SelectedHabsID) Then
                ' LOG
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"MODIFICACIÓN PERMISO DE HORAS ({CL.HABS_TYPE}): Se actualizó el registro ID {SelectedHabsID} ({TB_EmployeeName.Text}). Nuevas Horas: {absHours} Tipo: {CL.HABS_TYPE}. Estatus: {If(CB_Stat.Checked, "Activo", "Inactivo")}"

                    Dim empId As Integer = 0
                    Integer.TryParse(TB_EmployeeId.Text, empId)
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_PermisoDeHoras", "UPDATE_SUCCESS", descLog, empId, "INFO")
                End Using

                MsgBox("¡El registro del permiso de horas ha sido modificado con éxito!", MsgBoxStyle.Information, "Actualización Completa")

                CargarGridGeneral()
                ResetFormFields()
            End If

        Catch ex As Exception
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL ACTUALIZAR PERMISO DE HORAS: {ex.Message} en Registro ID {SelectedHabsID}"

                    Dim empId As Integer = 0
                    Integer.TryParse(TB_EmployeeId.Text, empId)
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_PermisoDeHoras", "UPDATE_EXCEPTION", descError, empId, "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("Error al escribir log de actualización: " & logEx.Message)
            End Try

            MsgBox("Ocurrió un inconveniente técnico al intentar modificar el registro: " & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
    End Sub

    Private Sub ResetFormFields()
        SelectedHabsID = 0
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_Cause.Clear()
        TB_Description.Clear()
        TB_HoursAbsence.Clear()
        TB_AuthorizeBy.Clear()
        DTP_Valid.Value = DateTime.Now
        CB_HoursAbsenceType.SelectedIndex = 0
        CB_Stat.Checked = True
    End Sub
End Class