Public Class OP_INS_AmountToTransferManually

    Dim ObjAmount As New CL_AmountToTransfer
    Dim SelectedEmplID As Integer = 0

    Private Structure SemanaPeriodo
        Dim FechaInicio As Date
        Dim FechaFin As Date
        Dim Descripcion As String
        Dim EsComodin As Boolean

        Sub New(textoComodin As String)
            Descripcion = textoComodin
            EsComodin = True
        End Sub

        Sub New(inicio As Date, fin As Date)
            FechaInicio = inicio
            FechaFin = fin
            Dim strInicio As String = inicio.ToString("dd-MMM-yyyy")
            Dim strFin As String = fin.ToString("dd-MMM-yyyy")
            Descripcion = "Semana del " & strInicio & " al " & strFin
            EsComodin = False
        End Sub

        Overrides Function ToString() As String
            Return Descripcion
        End Function
    End Structure

    Private Sub OP_INS_AmountToTransferManually_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarSemanasExistentes()
        If CB_AllDates.Items.Count > 0 Then CB_AllDates.SelectedIndex = 0
        DGV_Amtrans.DataSource = Nothing
        LBX_Suggesting.Visible = False

    End Sub

    Private Sub CargarSemanasExistentes()
        CB_AllDates.Items.Clear()
        CB_AllDates.Items.Add(New SemanaPeriodo("Seleccione una fecha."))

        Dim DtSemanas As DataTable = ObjAmount.GetExistingWeeks()

        If DtSemanas IsNot Nothing AndAlso DtSemanas.Rows.Count > 0 Then
            Dim CulturaEspañol As New System.Globalization.CultureInfo("es-MX")

            For Each Row As DataRow In DtSemanas.Rows
                Dim FechaInicio As Date = Convert.ToDateTime(Row(0))
                Dim FechaFin As Date = FechaInicio.AddDays(6)

                Dim Periodo As New SemanaPeriodo(FechaInicio, FechaFin)
                Periodo.Descripcion = "Semana del " & FechaInicio.ToString("dd-MMM-yyyy", CulturaEspañol) &
                                  " al " & FechaFin.ToString("dd-MMM-yyyy", CulturaEspañol)
                CB_AllDates.Items.Add(Periodo)
            Next
        End If
    End Sub

    Private Sub ConsultarRegistrosSemanales()
        If CB_AllDates.SelectedItem Is Nothing Then
            DGV_Amtrans.DataSource = Nothing
            CalcularTotalesFormulario(Nothing)
            Exit Sub
        End If

        Dim PeriodoSeleccionado As SemanaPeriodo = CType(CB_AllDates.SelectedItem, SemanaPeriodo)
        If PeriodoSeleccionado.EsComodin Then
            DGV_Amtrans.DataSource = Nothing
            CalcularTotalesFormulario(Nothing)
            Exit Sub
        End If

        Try
            Dim ObjBusqueda As New CL_AmountToTransfer()
            Dim Dt As DataTable = ObjBusqueda.GetAmountToTransferByWeek(PeriodoSeleccionado.FechaInicio, PeriodoSeleccionado.FechaFin)

            DGV_Amtrans.DataSource = Dt
            DGV_Amtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            CalcularTotalesFormulario(Dt)

            If DGV_Amtrans.Columns.Contains("AMTRANS_ID") Then
                DGV_Amtrans.Columns("AMTRANS_ID").Visible = False
            End If
        Catch ex As Exception
            MsgBox("Error al cargar la tabla y calcular totales: " & ex.Message, MsgBoxStyle.Critical, "Error de Datos")
        End Try
    End Sub

    Private Sub CalcularTotalesFormulario(ByVal Dt As DataTable)
        If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
            LB_TotalEmployees.Text = "Total Empleados: 0"
            LB_TotalAmount.Text = "Monto Total: $0.00"
            Exit Sub
        End If

        Try
            Dim TotalEmpleados As Integer = Dt.Rows.Count
            Dim SumaMontos As Decimal = 0

            For Each Row As DataRow In Dt.Rows
                If Not IsDBNull(Row("Monto a Depositar")) Then
                    SumaMontos += Convert.ToDecimal(Row("Monto a Depositar"))
                End If
            Next

            LB_TotalEmployees.Text = "Total Empleados: " & TotalEmpleados.ToString()
            LB_TotalAmount.Text = "Monto Total: " & SumaMontos.ToString("$#,##0.00")
        Catch ex As Exception
            LB_TotalEmployees.Text = "Total Empleados: --"
            LB_TotalAmount.Text = "Monto Total: --"
        End Try
    End Sub

    Private Sub CB_AllDates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllDates.SelectedIndexChanged
        ConsultarRegistrosSemanales()
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim().Length >= 2 Then
            Dim Dt As DataTable = ObjAmount.SearchEmployeesByArea(TB_Employee.Text.Trim(), True, False)

            If Dt IsNot Nothing AndAlso Dt.Rows.Count > 0 Then
                LBX_Suggesting.DataSource = Dt
                LBX_Suggesting.DisplayMember = "FullName"
                LBX_Suggesting.ValueMember = "EMPL_ID"
                LBX_Suggesting.Visible = True
                LBX_Suggesting.BringToFront()
            Else
                LBX_Suggesting.Visible = False
            End If
        Else
            LBX_Suggesting.Visible = False
        End If
    End Sub

    Private Sub LBX_Suggesting_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBX_Suggesting.SelectedIndexChanged
        If LBX_Suggesting.SelectedValue IsNot Nothing AndAlso Not TypeOf LBX_Suggesting.SelectedValue Is DataRowView Then
            Try
                SelectedEmplID = Convert.ToInt32(LBX_Suggesting.SelectedValue)
                TB_EmployeeId.Text = SelectedEmplID.ToString()

                Dim selectedText As String = ""
                If TypeOf LBX_Suggesting.SelectedItem Is DataRowView Then
                    Dim row As DataRowView = CType(LBX_Suggesting.SelectedItem, DataRowView)
                    selectedText = row("FullName").ToString()
                Else
                    selectedText = LBX_Suggesting.Text
                End If

                Dim values As String() = selectedText.Split("-")
                If values.Length > 1 Then
                    TB_EmployeeName.Text = values(1).Replace("[CON BONO]", "").Trim()
                Else
                    TB_EmployeeName.Text = selectedText.Trim()
                End If

                LBX_Suggesting.Visible = False
                TB_Employee.Clear()
                TB_Amount.Focus()
            Catch ex As Exception
                Console.WriteLine("Error temporal de casteo en sugerencias: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If CB_AllDates.SelectedItem Is Nothing Then
            MsgBox("Por favor, seleccione un periodo semanal.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        Dim PeriodoSeleccionado As SemanaPeriodo = CType(CB_AllDates.SelectedItem, SemanaPeriodo)

        If String.IsNullOrWhiteSpace(TB_Amount.Text) OrElse Not IsNumeric(TB_Amount.Text) Then
            MsgBox("Debe ingresar un monto válido.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        Dim IdAInsertar As String = TB_EmployeeId.Text.Trim()

        For Each row As DataGridViewRow In DGV_Amtrans.Rows
            If row.Cells("No. Emp") IsNot Nothing AndAlso row.Cells("No. Emp").Value IsNot Nothing Then
                If row.Cells("No. Emp").Value.ToString().Trim() = IdAInsertar Then
                    MsgBox("El empleado ya cuenta con un monto a transferir registrado para esta semana." & vbCrLf & vbCrLf &
                           "Por favor, use el módulo de edición si requiere modificar la cantidad actual.",
                           MsgBoxStyle.Exclamation, "Registro Duplicado")
                    Exit Sub
                End If
            End If
        Next

        Try
            ObjAmount.DREMPL_DATE = PeriodoSeleccionado.FechaInicio
            ObjAmount.AMTRANS_AMOUN = Convert.ToDecimal(TB_Amount.Text)
            ObjAmount.AMTRANS_CREBY = GlobalSession.GlobalUserName

            Dim ResultadoAsignacion As Object = ObjAmount.InsertAmountToTransfer(Convert.ToInt32(TB_EmployeeId.Text))

            If ResultadoAsignacion IsNot Nothing AndAlso Equals(ResultadoAsignacion, True) Then
                MsgBox("El registro manual de monto a transferir se guardó correctamente.", MsgBoxStyle.Information, "Éxito")

                TB_EmployeeId.Clear()
                TB_EmployeeName.Clear()
                TB_Amount.Clear()

                ConsultarRegistrosSemanales()
            Else
                MsgBox("La base de datos rechazó el registro. Verifique que el ID de empleado exista.", MsgBoxStyle.Critical, "Error de Inserción")
            End If

        Catch ex As Exception
            MsgBox("Ocurrió un error inesperado al procesar el registro: " & ex.Message, MsgBoxStyle.Critical, "Error Fatal en Interfaz")
        End Try
    End Sub
End Class