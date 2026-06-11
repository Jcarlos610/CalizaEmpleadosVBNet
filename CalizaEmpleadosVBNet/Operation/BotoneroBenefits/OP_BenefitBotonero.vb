Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class OP_BenefitBotonero

    Dim BotoneroObj As New CL_EmployeesBenefitsBotonero

    Private Sub OP_BenefitBotonero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarControlesIniciales()
        LlenarGridPendientes()
    End Sub

    Private Sub ConfigurarControlesIniciales()
        DTP_StartDate.Value = Date.Today
        DTP_EndDate.Value = DTP_StartDate.Value.AddMonths(3)
        DTP_EndDate.Enabled = False

        TB_EmployeeId.Text = ""
        TB_EmployeeName.Text = ""
        TB_Comment.Text = ""
        TB_AuthorizeBy.Text = ""
    End Sub

    Private Sub LlenarGridPendientes()
        Try
            Dim dt As DataTable = BotoneroObj.Get_PendingBotoneros()

            If dt IsNot Nothing Then
                DGV_PendingBotoneros.DataSource = dt

                If DGV_PendingBotoneros.Columns.Contains("BEEMP_ID") Then DGV_PendingBotoneros.Columns("BEEMP_ID").Visible = False
                If DGV_PendingBotoneros.Columns.Contains("BENEF_ID") Then DGV_PendingBotoneros.Columns("BENEF_ID").Visible = False

                If DGV_PendingBotoneros.Columns.Contains("EMPL_ID") Then
                    DGV_PendingBotoneros.Columns("EMPL_ID").HeaderText = "ID Empleado"
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al cargar la lista de pendientes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DTP_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DTP_StartDate.ValueChanged
        DTP_EndDate.Value = DTP_StartDate.Value.AddMonths(3)
    End Sub
    Private Sub DGV_PendingBotoneros_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_PendingBotoneros.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DGV_PendingBotoneros.Rows(e.RowIndex)

                TB_EmployeeId.Text = row.Cells("EMPL_ID").Value.ToString()
                TB_EmployeeName.Text = row.Cells("Nombre Completo").Value.ToString()

                BotoneroObj.REMPL_ID = Convert.ToInt32(row.Cells("EMPL_ID").Value)
                BotoneroObj.BENEF_ID = Convert.ToInt32(row.Cells("BENEF_ID").Value)


            End If
        Catch ex As Exception
            MsgBox("Error al seleccionar el empleado: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BT_Save_Click(sender As Object, e As EventArgs) Handles BT_Save.Click
        Try
            If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
                MsgBox("Por favor, seleccione un empleado de la lista de pendientes.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_AuthorizeBy.Text) Then
                MsgBox("Debe ingresar quién autoriza la validación del bono.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_Comment.Text) Then
                MsgBox("Debe ingresar un comentario.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim MsgTexto As String = $"¿Está seguro que desea activar el Bono de Botonero por 3 meses para el empleado {TB_EmployeeName.Text}?"

            If MsgBox(MsgTexto, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar Registro") = MsgBoxResult.Yes Then

                BotoneroObj.BOTON_VALFR = DTP_StartDate.Value.ToString("yyyy-MM-dd")
                BotoneroObj.BOTON_VALTO = DTP_EndDate.Value.ToString("yyyy-MM-dd")
                BotoneroObj.BOTON_DESCR = TB_Comment.Text.Trim()
                BotoneroObj.BOTON_CREBY = TB_AuthorizeBy.Text.Trim()

                If BotoneroObj.InsertBotoneroValidez() Then

                    ' LOG 
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"VALIDACIÓN BONO BOTONERO: Se activó la vigencia de 3 meses ({BotoneroObj.BOTON_VALFR} al {BotoneroObj.BOTON_VALTO}) al empleado ID {TB_EmployeeId.Text}."
                        InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_EmployeesBenefitsBotonero", "INSERT_SUCCESS", descLog, CInt(TB_EmployeeId.Text), "INFO")
                    End Using

                    MsgBox("¡El periodo de validez del Bono de Botonero ha sido registrado exitosamente!", MsgBoxStyle.Information, "Registro Completo")

                    ConfigurarControlesIniciales()
                    LlenarGridPendientes()
                Else
                    MsgBox("No se pudo registrar la activación en la base de datos.", MsgBoxStyle.Critical, "Error")
                End If
            End If

        Catch ex As Exception

            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL INSERTAR VALIDACIÓN BONO BOTONERO: {ex.Message}. Empleado ID intentado: {TB_EmployeeId.Text}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_EmployeesBenefitsBotonero", "INSERT_EXCEPTION", descError, CInt(If(String.IsNullOrEmpty(TB_EmployeeId.Text), 0, TB_EmployeeId.Text)), "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("No se pudo escribir en la bitácora central: " & logEx.Message)
            End Try

            MsgBox("Error crítico al intentar procesar el registro en la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
    End Sub

End Class