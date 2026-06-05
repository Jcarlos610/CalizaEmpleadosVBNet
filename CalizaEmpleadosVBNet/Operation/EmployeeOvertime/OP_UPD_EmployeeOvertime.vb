Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Data.SqlClient

Public Class OP_UPD_EmployeeOvertime

    Dim SelectedOvertID As Integer = 0

    Private Sub OP_UPD_EmployeeOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGridGeneral()
    End Sub

    Private Sub CargarGridGeneral()
        Try
            Dim CL As New CL_EmployeeOvertime
            DGV_Overtime.DataSource = CL.GetOvertimeHistory(0)

            If DGV_Overtime.Columns.Count > 0 Then
                If DGV_Overtime.Columns.Contains("ID") Then DGV_Overtime.Columns("ID").Visible = False

                DGV_Overtime.ReadOnly = True
                DGV_Overtime.RowHeadersVisible = False
                DGV_Overtime.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                DGV_Overtime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                If DGV_Overtime.Columns.Contains("Horas Extras") Then
                    DGV_Overtime.Columns("Horas Extras").DefaultCellStyle.Format = "N2"
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al cargar el listado de horas extras: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DGV_Overtime_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Overtime.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = DGV_Overtime.Rows(e.RowIndex)

                SelectedOvertID = Convert.ToInt32(row.Cells("ID").Value)

                TB_EmployeeId.Text = row.Cells("Núm. Empleado").Value.ToString()
                TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()
                TB_OvertimeCause.Text = row.Cells("Motivo").Value.ToString()
                TB_Description.Text = row.Cells("Descripción").Value.ToString()
                TB_OvertimeHours.Text = row.Cells("Horas Extras").Value.ToString()
                TB_AuthorizeBy.Text = row.Cells("Autorizado Por").Value.ToString()

                If IsDate(row.Cells("Fecha Aplicación").Value) Then
                    DTP_Valid.Value = Convert.ToDateTime(row.Cells("Fecha Aplicación").Value)
                End If

                Dim estadoStr As String = row.Cells("Estado").Value.ToString()
                CB_Stat.Checked = (estadoStr = "Activo")

            Catch ex As Exception
                MsgBox("Error al seleccionar el registro del Grid: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
            End Try
        End If
    End Sub

    Private Sub DGV_Overtime_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Overtime.CellFormatting
        If DGV_Overtime.Columns.Contains("Estado") Then
            Dim estadoValue As Object = DGV_Overtime.Rows(e.RowIndex).Cells("Estado").Value

            If estadoValue IsNot Nothing AndAlso (estadoValue.ToString() = "Inactivo" OrElse estadoValue.ToString() = "Modificado/Inactivo") Then
                e.CellStyle.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        If SelectedOvertID = 0 Then
            MsgBox("Por favor, seleccione primero un registro del listado superior para editar.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        ' Validaciones básicas de campos vacíos
        If String.IsNullOrWhiteSpace(TB_OvertimeCause.Text) OrElse String.IsNullOrWhiteSpace(TB_AuthorizeBy.Text) Then
            MsgBox("El motivo de las horas extras y la persona que autoriza son campos obligatorios.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        Dim overtHours As Decimal = 0
        If Not Decimal.TryParse(TB_OvertimeHours.Text, overtHours) OrElse overtHours <= 0 Then
            MsgBox("Ingrese una cantidad de horas válida y mayor a 0.00.", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        Try
            Dim CL As New CL_EmployeeOvertime
            CL.OVERT_DATE = DTP_Valid.Value.Date
            CL.OVERT_CAUSE = TB_OvertimeCause.Text.Trim()
            CL.OVERT_DESCR = TB_Description.Text.Trim()
            CL.OVERT_HOURS = overtHours
            CL.OVERT_AUTH = TB_AuthorizeBy.Text.Trim()
            CL.OVERT_STATUS = CB_Stat.Checked
            CL.OVERT_CREBY = GlobalSession.GlobalUserName

            If CL.UpdateEmployeeOvertime(SelectedOvertID) Then
                'LOG
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"MODIFICACIÓN HORAS EXTRAS: Se actualizó el registro ID {SelectedOvertID} del empleado {TB_EmployeeName.Text}. Nuevas Horas: {overtHours}. Estatus: {If(CB_Stat.Checked, "Activo", "Inactivo")}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_HorasExtras", "UPDATE_SUCCESS", descLog, CInt(TB_EmployeeId.Text), "INFO")
                End Using

                MsgBox("¡El registro de horas extras ha sido modificado con éxito!", MsgBoxStyle.Information, "Actualización Completa")

                CargarGridGeneral()
                ResetFormFields()
            End If

        Catch ex As Exception
            'LOG
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL ACTUALIZAR HORAS EXTRAS: {ex.Message} en ID {SelectedOvertID}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_HorasExtras", "UPDATE_EXCEPTION", descError, CInt(If(String.IsNullOrEmpty(TB_EmployeeId.Text), 0, TB_EmployeeId.Text)), "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("Error al escribir log de actualización: " & logEx.Message)
            End Try

            MsgBox("Ocurrió un inconveniente técnico al intentar modificar el registro: " & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
    End Sub

    Private Sub ResetFormFields()
        SelectedOvertID = 0
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_OvertimeCause.Clear()
        TB_Description.Clear()
        TB_OvertimeHours.Clear()
        TB_AuthorizeBy.Clear()
        DTP_Valid.Value = DateTime.Now
        CB_Stat.Checked = True
    End Sub

End Class