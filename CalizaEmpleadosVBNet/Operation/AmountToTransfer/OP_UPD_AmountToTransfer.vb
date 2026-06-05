Imports Microsoft.Data.SqlClient

Public Class OP_UPD_AmountToTransfer

    Private AmtransIdSeleccionado As Integer = 0

    Private Sub OP_UPD_AmountToTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BT_Upd.Enabled = False
        TB_EmployeeId.ReadOnly = True
        TB_EmployeeName.ReadOnly = True
        TB_Amount.ReadOnly = False

        Dim fechaHoy As Date = DateTime.Now.Date
        Dim diasDesdeJueves As Integer = CInt(fechaHoy.DayOfWeek) - DayOfWeek.Thursday


        If diasDesdeJueves < 0 Then diasDesdeJueves += 7

        Dim fechaJueves As Date = fechaHoy.AddDays(-diasDesdeJueves)
        Dim fechaMiercoles As Date = fechaJueves.AddDays(6)


        RemoveHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged

        DTP_StartDate.Value = fechaJueves
        DTP_EndDate.Value = fechaMiercoles

        AddHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged
    End Sub

    Private Sub BT_Consult_Click(sender As Object, e As EventArgs) Handles BT_Consult.Click

        Dim fechaIniciada As Date = DTP_StartDate.Value.Date
        Dim fechaFinalizada As Date = DTP_EndDate.Value.Date

        If fechaIniciada > fechaFinalizada Then
            MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Fechas Inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim ObjAmount As New CL_AmountToTransfer()
            Dim Dt As DataTable = ObjAmount.GetAmountToTransferByWeek(fechaIniciada, fechaFinalizada)

            DGV_Amtrans.DataSource = Dt


            DGV_Amtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_Amtrans.AutoResizeColumns()

            If DGV_Amtrans.Columns.Contains("AMTRANS_ID") Then
                DGV_Amtrans.Columns("AMTRANS_ID").Visible = False
            End If

            Dim Conteo As Integer = Dt.Rows.Count
            Dim Total As Decimal = 0

            For Each r As DataRow In Dt.Rows
                If r("Monto a Depositar") IsNot DBNull.Value Then
                    Total += Convert.ToDecimal(r("Monto a Depositar"))
                End If
            Next

            LB_TotalEmployees.Text = "Total Empleados: " & Conteo
            LB_TotalAmount.Text = "Monto Total: " & String.Format("{0:C2}", Total)

            If Conteo = 0 Then
                MessageBox.Show("No se encontraron registros cargados en el rango seleccionado.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BT_Upd.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error al consultar el periodo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DGV_Amtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Amtrans.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim Fila As DataGridViewRow = DGV_Amtrans.Rows(e.RowIndex)

                TB_EmployeeId.Text = Fila.Cells("No. Emp").Value.ToString()
                TB_EmployeeName.Text = Fila.Cells("Nombre Completo").Value.ToString()
                TB_Amount.Text = Convert.ToDecimal(Fila.Cells("Monto a Depositar").Value).ToString("0.00")

                AmtransIdSeleccionado = Convert.ToInt32(Fila.Cells("AMTRANS_ID").Value)

                BT_Upd.Enabled = True

            Catch ex As Exception
                BT_Upd.Enabled = False
            End Try
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click

        If String.IsNullOrEmpty(TB_Amount.Text) OrElse Not IsNumeric(TB_Amount.Text) Then
            MessageBox.Show("Por favor ingresa un monto numérico válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Deseas actualizar el monto para este empleado?", "Confirmar Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Dim ObjAmount As New CL_AmountToTransfer()

            Dim filaSeleccionada As DataGridViewRow = DGV_Amtrans.CurrentRow
            Dim montoAnterior As String = Convert.ToDecimal(filaSeleccionada.Cells("Monto a Depositar").Value).ToString("C2")
            Dim montoNuevo As String = Convert.ToDecimal(TB_Amount.Text).ToString("C2")

            Dim Resultado As Boolean = ObjAmount.UpdateAmountToTransfer(AmtransIdSeleccionado, Convert.ToDecimal(TB_Amount.Text), GlobalSession.GlobalUserName)

            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)

            If Resultado Then
                MessageBox.Show("Monto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' LOG 
                Try
                    Dim descLog As String = $"MODIFICACIÓN DE MONTO INDIVIDUAL: El usuario [{GlobalSession.GlobalUserName}] modificó el monto del empleado ID [{TB_EmployeeId.Text}] - {TB_EmployeeName.Text}. Monto anterior: {montoAnterior} -> Monto nuevo: {montoNuevo}."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_MontosTransferir", "UPDATE_AMOUNT_SUCCESS", descLog, AmtransIdSeleccionado, "INFO")
                Catch logEx As Exception
                End Try

                TB_EmployeeId.Text = ""
                TB_EmployeeName.Text = ""
                TB_Amount.Text = ""
                BT_Upd.Enabled = False
                AmtransIdSeleccionado = 0

                BT_Consult_Click(Nothing, Nothing)
            Else
                Dim descWarn As String = $"RECHAZO EN BD: El procedimiento no aplicó la actualización para el AMTRANS_ID: {AmtransIdSeleccionado} (Empleado ID: {TB_EmployeeId.Text})."
                Try
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_MontosTransferir", "UPDATE_AMOUNT_FAILED", descWarn, AmtransIdSeleccionado, "WARNING")
                Catch logEx As Exception
                End Try

                MessageBox.Show("No se pudo realizar la actualización en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ' LOG de error
            Try
                Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la actualización individual del AMTRANS_ID: {AmtransIdSeleccionado} (Empleado ID: {TB_EmployeeId.Text}). Motivo: {ex.Message}"

                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_MontosTransferir", "ERROR_UPDATE_AMOUNT", descError, AmtransIdSeleccionado, "ERROR", ex.StackTrace)
            Catch logEx As Exception
            End Try

            MessageBox.Show("Ocurrió un error inesperado al actualizar el monto: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DTP_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DTP_StartDate.ValueChanged
        RemoveHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged

        Dim fechaSeleccionada As Date = DTP_StartDate.Value.Date
        Dim diasDesdeJueves As Integer = CInt(fechaSeleccionada.DayOfWeek) - DayOfWeek.Thursday

        If diasDesdeJueves < 0 Then diasDesdeJueves += 7

        Dim fechaJueves As Date = fechaSeleccionada.AddDays(-diasDesdeJueves)
        Dim fechaMiercoles As Date = fechaJueves.AddDays(6)

        DTP_StartDate.Value = fechaJueves
        DTP_EndDate.Value = fechaMiercoles

        AddHandler DTP_StartDate.ValueChanged, AddressOf DTP_StartDate_ValueChanged
    End Sub
End Class