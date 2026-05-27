Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Public Class OP_UPD_TEMPORALLUNCH

    Dim SelectedRecordID As Integer = 0
    Private Original_LunchHours As Decimal = 0D

    Private Sub OP_UPD_TEMPORALLUNCH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Historial()
    End Sub

    Private Sub Historial()
        Dim CL As New CL_TemporalLunchTime
        DGV_Lunch.DataSource = CL.GetTemporalLunchHistory(GlobalSession.GlobalUserName)

        If DGV_Lunch.Columns.Count > 0 Then
            DGV_Lunch.Columns("ID").Visible = False
            DGV_Lunch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
    End Sub

    Private Sub DGV_Lunch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Lunch.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_Lunch.Rows(e.RowIndex)

            SelectedRecordID = CInt(row.Cells("ID").Value)
            TB_EmployeeId.Text = row.Cells("ID Empleado").Value.ToString()
            TB_EmployeeName.Text = row.Cells("Empleado").Value.ToString()
            TB_Lunch.Text = row.Cells("Horas").Value.ToString()

            Decimal.TryParse(TB_Lunch.Text, Original_LunchHours)

            DTP_Valid.Value = CDate(row.Cells("Fecha Registro").Value)

            TB_EmployeeId.ReadOnly = True
            TB_EmployeeName.ReadOnly = True


            DTP_Valid.Value = CDate(row.Cells("Fecha Registro").Value)
            DTP_Valid.Enabled = False
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        Try
            If SelectedRecordID = 0 Then
                MsgBox("Por favor, seleccione un registro de la tabla para editar.", MsgBoxStyle.Exclamation)
                Return
            End If

            Dim horas As Decimal
            If Not Decimal.TryParse(TB_Lunch.Text, horas) OrElse horas < 0 OrElse horas > 5 Then
                MsgBox("Las horas de comida deben ser entre 0 y 5.", MsgBoxStyle.Critical)
                Return
            End If

            Dim stringCambio As String = ""
            If Original_LunchHours <> horas Then
                stringCambio = $"Modificación de Horas: de {Original_LunchHours} hrs a {horas} hrs."
            Else
                stringCambio = "Actualización general sin cambios en el cómputo de horas."
            End If

            Dim CL As New CL_TemporalLunchTime
            CL.LUNCH_HOURS = horas
            CL.LUNCH_DATE = DTP_Valid.Value
            CL.LUNCH_CREBY = GlobalSession.GlobalUserName

            If CL.UpdateTemporalLunch(SelectedRecordID) Then
                'LOG DE EXITO 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"MODIFICACIÓN DE INCIDENCIA DE COMIDA: Se editó el registro LUNCH_ID: {SelectedRecordID}. Detalle -> {stringCambio} Fecha asignada: [{DTP_Valid.Value:dd/MM/yyyy}]."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Comidas", "UPDATE_LUNCH_SUCCESS", descLog, SelectedRecordID, "INFO")
                End Using


                MsgBox("El registro se actualizó correctamente.", MsgBoxStyle.Information, "Éxito")

                ResetFormFields()
                Historial()
            End If

        Catch ex As Exception
            'LOG DE ERROR 
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la actualización del registro LUNCH_ID: {SelectedRecordID}. Motivo: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Comidas", "ERROR_UPDATE_LUNCH", descError, SelectedRecordID, "ERROR", ex.StackTrace)
            End Using
            MsgBox("Ocurrió un error inesperado al actualizar el registro: " & ex.Message, MsgBoxStyle.Critical, "Error Crítico")
        End Try
    End Sub

    Private Sub ResetFormFields()
        SelectedRecordID = 0
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_Lunch.Clear()
        DTP_Valid.Value = Now
    End Sub

End Class