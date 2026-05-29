Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Data.SqlClient

Public Class OP_INS_AmountToTransfer

    Private RutaArchivoExcel As String = ""

    Private Sub OP_INS_AmountToTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BT_Register.Enabled = False
        DTP_Valid.Value = DateTime.Now

        PB_Progress.Value = 0
    End Sub

    Private Sub BT_SearchExcel_Click(sender As Object, e As EventArgs) Handles BT_SearchExcel.Click
        OFD_Amtrans.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Archivos de Excel Antiguos (*.xls)|*.xls"
        OFD_Amtrans.Title = "Seleccionar archivo de montos a depositar"

        If OFD_Amtrans.ShowDialog() = DialogResult.OK Then
            RutaArchivoExcel = OFD_Amtrans.FileName

            Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & RutaArchivoExcel & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"

            Try
                Using ConnExcel As New OleDbConnection(ConnString)
                    ConnExcel.Open()

                    Dim Query As String = "SELECT * FROM [Hoja1$]"

                    Using CmdExcel As New OleDbCommand(Query, ConnExcel)
                        Dim Da As New OleDbDataAdapter(CmdExcel)
                        Dim Dt As New DataTable()
                        Da.Fill(Dt)

                        DGV_Amtrans.DataSource = Dt

                        If DGV_Amtrans.Rows.Count > 0 Then
                            BT_Register.Enabled = True

                            Dim ConteoFilas As Integer = 0
                            Dim SumaMontos As Decimal = 0

                            For Each Row As DataRow In Dt.Rows
                                If Row(0) IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(Row(0).ToString()) Then
                                    ConteoFilas += 1

                                    If Row(2) IsNot DBNull.Value AndAlso IsNumeric(Row(2)) Then
                                        SumaMontos += Convert.ToDecimal(Row(2))
                                    End If
                                End If
                            Next

                            LB_TotalEmployees.Text = "Total Empleados: " & ConteoFilas
                            LB_TotalAmount.Text = "Monto Total: " & String.Format("{0:C2}", SumaMontos)


                            MessageBox.Show("Vista previa cargada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            BT_Register.Enabled = False
                            MessageBox.Show("El archivo de Excel no contiene registros.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al leer el Excel: " & ex.Message & vbCrLf & "Revisa que la hoja se llame 'Hoja1' y que el archivo esté cerrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If DGV_Amtrans.Rows.Count = 0 Then
            MessageBox.Show("No hay datos en la tabla para procesar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show("¿Deseas guardar de forma masiva los montos de este Excel?", "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim ObjValidar As New CL_AmountToTransfer()
        If ObjValidar.ValidarRegistroSemanal(DTP_Valid.Value) Then
            Dim diasDesdeJueves As Integer = CInt(DTP_Valid.Value.DayOfWeek) - DayOfWeek.Thursday
            If diasDesdeJueves < 0 Then diasDesdeJueves += 7
            Dim jueves As Date = DTP_Valid.Value.AddDays(-diasDesdeJueves)
            Dim miercoles As Date = jueves.AddDays(6)

            MessageBox.Show($"¡Atención! Ya se realizó una importación de montos para el periodo semanal del " &
                            $"{jueves:dd/MM/yyyy} al {miercoles:dd/MM/yyyy}." & vbCrLf & vbCrLf &
                            "No se permiten registros duplicados en la misma semana.",
                            "Bloqueo de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim Guardados As Integer = 0
        Dim Errores As Integer = 0

        PB_Progress.Minimum = 0
        PB_Progress.Maximum = DGV_Amtrans.Rows.Count
        PB_Progress.Value = 0

        For Each Row As DataGridViewRow In DGV_Amtrans.Rows
            PB_Progress.Value += 1

            If Row.IsNewRow Then Continue For

            Try
                Dim IdEmpleado As Object = Row.Cells(0).Value
                Dim NombreEmpleado As Object = Row.Cells(1).Value
                Dim MontoDinero As Object = Row.Cells(2).Value

                If IdEmpleado IsNot Nothing AndAlso MontoDinero IsNot Nothing Then

                    TB_EmployeeId.Text = IdEmpleado.ToString()
                    TB_EmployeeName.Text = If(NombreEmpleado IsNot Nothing, NombreEmpleado.ToString(), "")
                    TB_Amount.Text = String.Format("{0:C2}", Convert.ToDecimal(MontoDinero))

                    Application.DoEvents()

                    Dim ObjAmount As New CL_AmountToTransfer()
                    ObjAmount.DREMPL_DATE = DTP_Valid.Value.Date
                    ObjAmount.AMTRANS_AMOUN = Convert.ToDecimal(MontoDinero)
                    ObjAmount.AMTRANS_CREBY = GlobalSession.GlobalUserName

                    Dim Resultado As Object = ObjAmount.InsertAmountToTransfer(Convert.ToInt32(IdEmpleado))

                    If Resultado IsNot Nothing AndAlso CType(Resultado, Boolean) = True Then
                        Guardados += 1
                    Else
                        Errores += 1
                    End If
                End If

            Catch ex As Exception
                Errores += 1
            End Try
        Next

        PB_Progress.Value = PB_Progress.Maximum

        Dim Mensaje As String = "Proceso de importación finalizado." & vbCrLf & "Registros guardados: " & Guardados

        If Errores > 0 Then
            Mensaje &= vbCrLf & "Registros omitidos con error: " & Errores
            MessageBox.Show(Mensaje, "Completado con Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ' LOG de advertencia
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"IMPORTACIÓN MASIVA CON OBSERVACIONES: Se cargó un Excel para la fecha de aplicación [{DTP_Valid.Value:dd/MM/yyyy}]. Éxitos: {Guardados}, Errores/Omitidos: {Errores}."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_MontosTransferir", "IMPORT_AMOUNT_WARN", descLog, 0, "WARN")
                End Using
            Catch ex As Exception
            End Try
        Else
            MessageBox.Show(Mensaje, "¡Guardado Masivo Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' LOG de éxito
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"IMPORTACIÓN MASIVA EXITOSA: Se registraron correctamente {Guardados} montos de empleados para la fecha de aplicación [{DTP_Valid.Value:dd/MM/yyyy}]."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_MontosTransferir", "IMPORT_AMOUNT_SUCCESS", descLog, 0, "INFO")
                End Using
            Catch ex As Exception
            End Try
        End If

        DGV_Amtrans.DataSource = Nothing
        TB_EmployeeId.Text = ""
        TB_EmployeeName.Text = ""
        TB_Amount.Text = ""
        LB_TotalEmployees.Text = "Total Empleados: 0"
        LB_TotalAmount.Text = "Monto Total: $0.00"
        PB_Progress.Value = 0
        BT_Register.Enabled = False
    End Sub

    Private Sub DGV_Amtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Amtrans.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim FilaSeleccionada As DataGridViewRow = DGV_Amtrans.Rows(e.RowIndex)

                Dim IdEmp As Object = FilaSeleccionada.Cells(0).Value
                Dim NombreEmp As Object = FilaSeleccionada.Cells(1).Value
                Dim MontoEmp As Object = FilaSeleccionada.Cells(2).Value

                TB_EmployeeId.Text = If(IdEmp IsNot Nothing, IdEmp.ToString(), "")
                TB_EmployeeName.Text = If(NombreEmp IsNot Nothing, NombreEmp.ToString(), "")
                TB_Amount.Text = If(MontoEmp IsNot Nothing, String.Format("{0:C2}", Convert.ToDecimal(MontoEmp)), "")

            Catch ex As Exception
                TB_EmployeeId.Text = ""
                TB_EmployeeName.Text = ""
                TB_Amount.Text = ""
            End Try
        End If
    End Sub
End Class