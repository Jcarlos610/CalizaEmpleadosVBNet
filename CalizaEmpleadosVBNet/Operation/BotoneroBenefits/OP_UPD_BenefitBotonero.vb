Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class OP_UPD_BenefitBotonero

    Dim BotoneroObj As New CL_EmployeesBenefitsBotonero

    Private Sub OP_UPD_BenefitBotonero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarControles()
        LlenarGridValidados()
    End Sub

    Private Sub ConfigurarControles()
        DTP_StartDate.Value = Date.Today
        DTP_EndDate.Value = DTP_StartDate.Value.AddMonths(3)
        DTP_EndDate.Enabled = False

        TB_EmployeeId.Text = ""
        TB_EmployeeName.Text = ""
        TB_Comment.Text = ""
        TB_AuthorizeBy.Text = ""
        CB_Status.Checked = True
    End Sub

    Private Sub LlenarGridValidados()
        Try

            Dim dt As DataTable = BotoneroObj.Get_AllValidatedBotoneros()

            If dt IsNot Nothing Then
                DGV_PendingBotoneros.DataSource = dt

                If DGV_PendingBotoneros.Columns.Contains("BOTON_ID") Then DGV_PendingBotoneros.Columns("BOTON_ID").Visible = False

                If DGV_PendingBotoneros.Columns.Contains("EMPL_ID") Then
                    DGV_PendingBotoneros.Columns("EMPL_ID").HeaderText = "ID Empleado"
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al cargar el historial de validaciones: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DTP_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DTP_StartDate.ValueChanged
        DTP_EndDate.Value = DTP_StartDate.Value.AddMonths(3)
    End Sub

    'Private Sub DGV_PendingBotoneros_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_PendingBotoneros.CellClick
    '    Try
    '        If e.RowIndex >= 0 Then
    '            Dim row As DataGridViewRow = DGV_PendingBotoneros.Rows(e.RowIndex)
    '            If row.Cells("Estatus").Value IsNot Nothing Then
    '                Dim estatusTexto As String = row.Cells("Estatus").Value.ToString()
    '                CB_Status.Checked = (estatusTexto = "Activo")
    '            End If

    '            TB_EmployeeId.Text = row.Cells("EMPL_ID").Value.ToString()
    '            TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()
    '            DTP_StartDate.Value = Convert.ToDateTime(row.Cells("Fecha Inicio").Value)
    '            DTP_EndDate.Value = Convert.ToDateTime(row.Cells("Fecha Fin").Value)
    '            TB_Comment.Text = row.Cells("Comentario").Value.ToString()
    '            TB_AuthorizeBy.Text = row.Cells("Autorizado Por").Value.ToString()

    '            BotoneroObj.BOTON_ID = Convert.ToInt32(row.Cells("BOTON_ID").Value)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al seleccionar la validación: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    Private Sub DGV_PendingBotoneros_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_PendingBotoneros.MouseClick
        Try
            Dim hit As DataGridView.HitTestInfo = DGV_PendingBotoneros.HitTest(e.X, e.Y)

            If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
                Dim row As DataGridViewRow = DGV_PendingBotoneros.Rows(hit.RowIndex)

                If row.Cells("Estatus").Value IsNot Nothing Then
                    Dim estatusTexto As String = row.Cells("Estatus").Value.ToString()
                    CB_Status.Checked = (estatusTexto = "Activo")
                End If

                TB_EmployeeId.Text = row.Cells("EMPL_ID").Value.ToString()
                TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()
                DTP_StartDate.Value = Convert.ToDateTime(row.Cells("Fecha Inicio").Value)
                DTP_EndDate.Value = Convert.ToDateTime(row.Cells("Fecha Fin").Value)
                TB_Comment.Text = row.Cells("Comentario").Value.ToString()
                TB_AuthorizeBy.Text = row.Cells("Autorizado Por").Value.ToString()
                BotoneroObj.BOTON_ID = Convert.ToInt32(row.Cells("BOTON_ID").Value)
            End If

        Catch ex As Exception
            MsgBox("Error al seleccionar la validación: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BT_UPD_Click(sender As Object, e As EventArgs) Handles BT_UPD.Click
        Try
            If String.IsNullOrEmpty(TB_EmployeeId.Text) OrElse BotoneroObj.BOTON_ID Is Nothing Then
                MsgBox("Por favor, seleccione un registro de la lista antes de actualizar.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_AuthorizeBy.Text) Then
                MsgBox("Debe ingresar quién autoriza esta modificación.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_Comment.Text) Then
                MsgBox("Debe ingresar un comentario antes de actualizar.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If MsgBox($"¿Está seguro que desea guardar las modificaciones para el bono de {TB_EmployeeName.Text}?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar Cambios") = MsgBoxResult.Yes Then


                BotoneroObj.BOTON_VALFR = DTP_StartDate.Value.ToString("yyyy-MM-dd")
                BotoneroObj.BOTON_VALTO = DTP_EndDate.Value.ToString("yyyy-MM-dd")
                BotoneroObj.BOTON_DESCR = TB_Comment.Text.Trim()
                BotoneroObj.BOTON_CREBY = TB_AuthorizeBy.Text.Trim()
                BotoneroObj.BOTON_STAT = If(CB_Status.Checked, 1, 2)

                If BotoneroObj.UpdateBotoneroValidez() Then

                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim statusTexto As String = If(CB_Status.Checked, "ACTIVO", "INACTIVO")
                        Dim descLog As String = $"MODIFICACIÓN BONO BOTONERO: Registro ID {BotoneroObj.BOTON_ID} del empleado ID {TB_EmployeeId.Text} fue modificado. Nuevo Estatus: {statusTexto}."
                        InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_EmployeesBenefitsBotonero", "UPDATE_SUCCESS", descLog, CInt(TB_EmployeeId.Text), "INFO")
                    End Using

                    MsgBox("¡El registro de validación ha sido actualizado correctamente!", MsgBoxStyle.Information, "Éxito")

                    ConfigurarControles()
                    LlenarGridValidados()
                Else
                    MsgBox("No se pudieron guardar los cambios en la base de datos.", MsgBoxStyle.Critical, "Error")
                End If
            End If

        Catch ex As Exception
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL ACTUALIZAR BONO BOTONERO ID {BotoneroObj.BOTON_ID}: {ex.Message}."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_EmployeesBenefitsBotonero", "UPDATE_EXCEPTION", descError, CInt(If(String.IsNullOrEmpty(TB_EmployeeId.Text), 0, TB_EmployeeId.Text)), "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("Fallo crítico al reportar a la bitácora: " & logEx.Message)
            End Try

            MsgBox("Error al intentar procesar la actualización: " & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
    End Sub

End Class