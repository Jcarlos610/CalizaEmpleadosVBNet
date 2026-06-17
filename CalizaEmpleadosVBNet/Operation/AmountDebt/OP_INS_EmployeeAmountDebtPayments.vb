Imports Microsoft.Data.SqlClient

Public Class OP_INS_EmployeeAmountDebtPayments

    Private SelectedEmployeeID As Integer = 0
    Private SelectedDebtID As Integer = 0
    Private SelectedDebtBalance As Decimal = 0
    Private CurrentUser As String = "GlobalSession"

    Private Sub OP_INS_EmployeeAmountDebtPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGlobalDebtsGrid()
    End Sub

    Private Sub LoadGlobalDebtsGrid()
        Try
            Dim debtObj As New CL_EmployeeAmountDebt()
            Dim dt As DataTable = debtObj.GetEmployeesWithDebts()
            DGV_GlobalDebts.DataSource = dt

            DGV_GlobalDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            If DGV_GlobalDebts.Columns.Contains("EMPL_ID") Then
                DGV_GlobalDebts.Columns("EMPL_ID").HeaderText = "ID"
                DGV_GlobalDebts.Columns("EMPL_ID").Width = 50
            End If

            If DGV_GlobalDebts.Columns.Contains("FullName") Then
                DGV_GlobalDebts.Columns("FullName").HeaderText = "Nombre Completo"
            End If

            If DGV_GlobalDebts.Columns.Contains("Estatus") Then
                DGV_GlobalDebts.Columns("Estatus").HeaderText = "Estatus"
                DGV_GlobalDebts.Columns("Estatus").Width = 90
            End If

            If DGV_GlobalDebts.Columns.Contains("SaldoTotal") Then
                DGV_GlobalDebts.Columns("SaldoTotal").Visible = False
            End If

            DGV_GlobalDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            MsgBox("Error al inicializar lista global: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Private Sub DGV_GlobalDebts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_GlobalDebts.CellClick
    '    If e.RowIndex >= 0 Then
    '        Try
    '            Dim row As DataGridViewRow = DGV_GlobalDebts.Rows(e.RowIndex)

    '            If DGV_GlobalDebts.Columns.Contains("ID") Then
    '                SelectedEmployeeID = Convert.ToInt32(row.Cells("ID").Value)
    '            ElseIf DGV_GlobalDebts.Columns.Contains("EMPL_ID") Then
    '                SelectedEmployeeID = Convert.ToInt32(row.Cells("EMPL_ID").Value)
    '            Else
    '                MsgBox("Error de configuración: No se encontró la columna de ID del empleado en la tabla principal.", MsgBoxStyle.Critical, "Error")
    '                Return
    '            End If

    '            SelectedDebtID = 0
    '            SelectedDebtBalance = 0
    '            DGV_EmployeeDebts.DataSource = Nothing
    '            DGV_DetailPayments.DataSource = Nothing
    '            LB_Accumulated.Text = "Acumulado por abonos: $0.00"
    '            LB_Balnce.Text = "Saldo: $0.00"

    '            Dim debtObj As New CL_EmployeeAmountDebt()
    '            Dim dtDebts As DataTable = debtObj.GetDebtsHistory(SelectedEmployeeID)

    '            If dtDebts Is Nothing OrElse dtDebts.Rows.Count = 0 Then
    '                MsgBox("El empleado seleccionado no cuenta con adeudos activos o su cuenta está desactivada.", MsgBoxStyle.Information, "Aviso del Sistema")
    '                Return
    '            End If

    '            DGV_EmployeeDebts.DataSource = dtDebts

    '            If DGV_EmployeeDebts.Columns.Contains("ID") Then
    '                DGV_EmployeeDebts.Columns("ID").Visible = False
    '            End If

    '            DGV_EmployeeDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

    '        Catch ex As Exception
    '            MsgBox("Error al seleccionar empleado: " & ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '    End If
    'End Sub

    Private Sub DGV_GlobalDebts_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_GlobalDebts.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_GlobalDebts.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_GlobalDebts.Rows(hit.RowIndex)

                If DGV_GlobalDebts.Columns.Contains("ID") Then
                    SelectedEmployeeID = Convert.ToInt32(row.Cells("ID").Value)
                ElseIf DGV_GlobalDebts.Columns.Contains("EMPL_ID") Then
                    SelectedEmployeeID = Convert.ToInt32(row.Cells("EMPL_ID").Value)
                Else
                    MsgBox("Error de configuración: No se encontró la columna de ID del empleado en la tabla principal.", MsgBoxStyle.Critical, "Error")
                    Return
                End If

                SelectedDebtID = 0
                SelectedDebtBalance = 0
                DGV_EmployeeDebts.DataSource = Nothing
                DGV_DetailPayments.DataSource = Nothing
                LB_Accumulated.Text = "Acumulado por abonos: $0.00"
                LB_Balnce.Text = "Saldo: $0.00"

                Dim debtObj As New CL_EmployeeAmountDebt()
                Dim dtDebts As DataTable = debtObj.GetDebtsHistory(SelectedEmployeeID)

                If dtDebts Is Nothing OrElse dtDebts.Rows.Count = 0 Then
                    MsgBox("El empleado seleccionado no cuenta con adeudos activos o su cuenta está desactivada.", MsgBoxStyle.Information, "Aviso del Sistema")
                    Return
                End If

                DGV_EmployeeDebts.DataSource = dtDebts

                If DGV_EmployeeDebts.Columns.Contains("ID") Then
                    DGV_EmployeeDebts.Columns("ID").Visible = False
                End If

                DGV_EmployeeDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Catch ex As Exception
                MsgBox("Error al seleccionar empleado: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    'Private Sub DGV_EmployeeDebts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_EmployeeDebts.CellClick
    '    If e.RowIndex >= 0 Then
    '        Try
    '            Dim row As DataGridViewRow = DGV_EmployeeDebts.Rows(e.RowIndex)
    '            If row.Cells("ID").Value Is DBNull.Value Then Return
    '            If DGV_EmployeeDebts.Columns.Contains("Estado") AndAlso row.Cells("Estado").Value.ToString() <> "Activo" Then
    '                MsgBox("Este adeudo no se encuentra Activo (Estatus: " & row.Cells("Estado").Value.ToString() & "). No se pueden registrar abonos.", MsgBoxStyle.Exclamation, "Adeudo Inactivo")
    '            End If

    '            SelectedDebtID = Convert.ToInt32(row.Cells("ID").Value)
    '            SelectedDebtBalance = Convert.ToDecimal(row.Cells("Saldo Pendiente").Value)
    '            Dim totalAmount As Decimal = Convert.ToDecimal(row.Cells("Monto Total").Value)

    '            LB_Accumulated.Text = "Acumulado por abonos: " & FormatCurrency(totalAmount - SelectedDebtBalance)
    '            LB_Balnce.Text = "Saldo: " & FormatCurrency(SelectedDebtBalance)

    '            LoadPaymentItemsGrid(SelectedDebtID)

    '        Catch ex As Exception
    '            MsgBox("Error al seleccionar el adeudo: " & ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '    End If
    'End Sub

    Private Sub DGV_EmployeeDebts_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_EmployeeDebts.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_EmployeeDebts.HitTest(e.X, e.Y)


        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_EmployeeDebts.Rows(hit.RowIndex)

                If row.Cells("ID").Value Is DBNull.Value Then Return


                If DGV_EmployeeDebts.Columns.Contains("Estado") AndAlso row.Cells("Estado").Value.ToString() <> "Activo" Then
                    MsgBox("Este adeudo no se encuentra Activo (Estatus: " & row.Cells("Estado").Value.ToString() & "). No se pueden registrar abonos.", MsgBoxStyle.Exclamation, "Adeudo Inactivo")
                End If

                SelectedDebtID = Convert.ToInt32(row.Cells("ID").Value)
                SelectedDebtBalance = Convert.ToDecimal(row.Cells("Saldo Pendiente").Value)
                Dim totalAmount As Decimal = Convert.ToDecimal(row.Cells("Monto Total").Value)

                LB_Accumulated.Text = "Acumulado por abonos: " & FormatCurrency(totalAmount - SelectedDebtBalance)
                LB_Balnce.Text = "Saldo: " & FormatCurrency(SelectedDebtBalance)

                LoadPaymentItemsGrid(SelectedDebtID)

            Catch ex As Exception
                MsgBox("Error al seleccionar el adeudo: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub LoadPaymentItemsGrid(ByVal debtId As Integer)
        Dim debtObj As New CL_EmployeeAmountDebt()
        DGV_DetailPayments.DataSource = debtObj.GetDebtPaymentItemsHistory(debtId)

        If DGV_DetailPayments.Columns.Contains("ID Item") Then
            DGV_DetailPayments.Columns("ID Item").Visible = False
        End If

        DGV_DetailPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        DGV_DetailPayments.AllowUserToResizeColumns = True
    End Sub

    Private Sub BT_RegisterPayment_Click(sender As Object, e As EventArgs) Handles BT_RegisterPayment.Click
        Try
            If SelectedDebtID = 0 Then
                MsgBox("Por favor, seleccione primero un adeudo específico de la lista.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If SelectedDebtBalance <= 0 Then
                MsgBox("El adeudo seleccionado ya se encuentra liquidado ($0.00).", MsgBoxStyle.Exclamation, "Operación Inválida")
                Return
            End If

            Dim amountToPay As Decimal = 0
            If Not Decimal.TryParse(TB_PaymentAmount.Text, amountToPay) OrElse amountToPay <= 0 Then
                MsgBox("Por favor, ingrese un monto válido mayor a $0.00.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If amountToPay > SelectedDebtBalance Then
                MsgBox($"El monto ingresado ({amountToPay:C2}) supera el saldo pendiente de la deuda ({SelectedDebtBalance:C2}).", MsgBoxStyle.Critical, "Error de Monto")
                Return
            End If

            Dim CL As New CL_EmployeeAmountDebt
            CL.DAMT_ID = SelectedDebtID
            CL.DAMI_AMOUNT = amountToPay
            CL.DAMI_CREBY = GlobalSession.GlobalUserName
            CL.DAMI_TYPE = 1

            If CL.InsertDebtPaymentItem() Then

                ' LOG 
                Try
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"MOV_825 - ABONO MANUAL: Se registró un abono de {amountToPay:C2} al adeudo DAMT_ID {SelectedDebtID} para el empleado EMPL_ID {SelectedEmployeeID}."
                        InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_AbonosAdeudosEmpresa", "INSERT_SUCCESS", descLog, SelectedEmployeeID, "INFO")
                    End Using
                Catch logEx As Exception
                    Console.WriteLine("No se pudo escribir en la bitácora de éxito: " & logEx.Message)
                End Try

                MsgBox("¡El abono al adeudo ha sido registrado exitosamente!", MsgBoxStyle.Information, "Registro Completo")
                TB_PaymentAmount.Clear()

                DGV_EmployeeDebts.DataSource = CL.GetDebtsHistory(SelectedEmployeeID)
                LoadPaymentItemsGrid(SelectedDebtID)

                If DGV_EmployeeDebts.Columns.Contains("ID") Then
                    DGV_EmployeeDebts.Columns("ID").Visible = False
                End If

                For Each row As DataGridViewRow In DGV_EmployeeDebts.Rows
                    If row.Cells("ID").Value IsNot DBNull.Value AndAlso Convert.ToInt32(row.Cells("ID").Value) = SelectedDebtID Then
                        SelectedDebtBalance = Convert.ToDecimal(row.Cells("Saldo Pendiente").Value)
                        Dim totalAmount As Decimal = Convert.ToDecimal(row.Cells("Monto Total").Value)

                        LB_Accumulated.Text = "Acumulado por abono: " & FormatCurrency(totalAmount - SelectedDebtBalance)
                        LB_Balnce.Text = "Saldo: " & FormatCurrency(SelectedDebtBalance)
                        Exit For
                    End If
                Next

                LoadGlobalDebtsGrid()
            End If

        Catch ex As Exception
            ' LOG DE ERROR
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR MOV_825: {ex.Message}. Adeudo ID: {SelectedDebtID}, Empleado ID: {SelectedEmployeeID}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_AbonosAdeudosEmpresa", "INSERT_EXCEPTION", descError, SelectedEmployeeID, "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("No se pudo escribir en la bitácora de errores: " & logEx.Message)
            End Try

            MsgBox("Error crítico al intentar procesar el abono en la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
    End Sub

    Private Sub DGV_GlobalDebts_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_GlobalDebts.CellFormatting
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = DGV_GlobalDebts.Rows(e.RowIndex)

                If DGV_GlobalDebts.Columns.Contains("SaldoTotal") Then
                    Dim saldoValue As Object = row.Cells("SaldoTotal").Value

                    If saldoValue IsNot DBNull.Value AndAlso Convert.ToDecimal(saldoValue) <= 0 Then
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230)
                        row.DefaultCellStyle.ForeColor = Color.DarkGray
                        Return
                    End If
                End If

                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Black

            Catch ex As Exception
            End Try
        End If
    End Sub


End Class