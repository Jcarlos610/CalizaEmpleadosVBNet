Imports System.Data.Common
Imports Microsoft.Data.SqlClient

Public Class OP_INS_InfonavitAmountManually

    Dim ObjInfonavit As New CL_InfonavitAmount

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

    Private Sub OP_INS_InfonavitAmountManually_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarSemanasExistentes()

        If CB_AllDates.Items.Count > 0 Then
            CB_AllDates.SelectedIndex = 0
        End If

        DGV_Infonavit.DataSource = Nothing
    End Sub

    Private Sub CargarSemanasExistentes()
        CB_AllDates.Items.Clear()

        CB_AllDates.Items.Add(New SemanaPeriodo("Seleccione una fecha."))

        Dim DtSemanas As DataTable = ObjInfonavit.GetExistingWeeks()

        If DtSemanas IsNot Nothing AndAlso DtSemanas.Rows.Count > 0 Then

            Dim CulturaEspañol As New System.Globalization.CultureInfo("es-MX")

            For Each Row As DataRow In DtSemanas.Rows
                Dim FechaInicio As Date = Convert.ToDateTime(Row("INFONAVIT_DATE"))
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
            DGV_Infonavit.DataSource = Nothing
            CalcularTotalesFormulario(Nothing)
            Exit Sub
        End If

        Dim PeriodoSeleccionado As SemanaPeriodo = CType(CB_AllDates.SelectedItem, SemanaPeriodo)

        If PeriodoSeleccionado.EsComodin Then
            DGV_Infonavit.DataSource = Nothing
            CalcularTotalesFormulario(Nothing)
            Exit Sub
        End If

        Try
            Dim ObjInfonavitBusqueda As New CL_InfonavitAmount()
            Dim Dt As DataTable = ObjInfonavitBusqueda.GetInfonavitAmountByWeek(PeriodoSeleccionado.FechaInicio, PeriodoSeleccionado.FechaFin)

            DGV_Infonavit.DataSource = Dt
            DGV_Infonavit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            CalcularTotalesFormulario(Dt)

            If DGV_Infonavit.Columns.Contains("INFONAVIT_ID") Then
                DGV_Infonavit.Columns("INFONAVIT_ID").Visible = False
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
                If Not IsDBNull(Row("Monto Infonavit")) Then
                    SumaMontos += Convert.ToDecimal(Row("Monto Infonavit"))
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

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If CB_AllDates.SelectedItem Is Nothing Then
            MsgBox("Por favor, seleccione un periodo semanal.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        Dim PeriodoSeleccionado As SemanaPeriodo = CType(CB_AllDates.SelectedItem, SemanaPeriodo)

        If PeriodoSeleccionado.EsComodin Then
            MsgBox("Por favor, seleccione un periodo semanal válido de la lista.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TB_EmployeeId.Text) Then
            MsgBox("Debe ingresar un número de empleado.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TB_Amount.Text) OrElse Not IsNumeric(TB_Amount.Text) Then
            MsgBox("Debe ingresar un monto válido.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        Try
            ObjInfonavit.INFONAVIT_DATE = PeriodoSeleccionado.FechaInicio
            ObjInfonavit.INFONAVIT_AMOUN = Convert.ToDecimal(TB_Amount.Text)
            ObjInfonavit.INFONAVIT_CREBY = GlobalSession.GlobalUserName

            Dim ResultadoAsignacion As Object = ObjInfonavit.InsertAmountInfonavitManually(Convert.ToInt32(TB_EmployeeId.Text))

            If ResultadoAsignacion IsNot Nothing AndAlso Equals(ResultadoAsignacion, True) Then
                MsgBox("El registro manual de Infonavit se guardó correctamente.", MsgBoxStyle.Information, "Éxito")

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