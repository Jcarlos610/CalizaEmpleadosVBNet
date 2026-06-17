Imports Microsoft.Data.SqlClient

Public Class OP_INS_EmployeeOvertime

    Dim SelectedEmplID As Integer = 0

    Private Sub OP_INS_EmployeeOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBX_Suggesting.Visible = False

        CB_OvertimeType.Items.Clear()
        CB_OvertimeType.Items.Add("Seleccione una opción...")
        CB_OvertimeType.Items.Add("Doble")
        CB_OvertimeType.Items.Add("Triple")

        CB_OvertimeType.SelectedIndex = 0
        CargarGridGeneral()
    End Sub

    Private Sub DTP_Valid_ValueChanged(sender As Object, e As EventArgs) Handles DTP_Valid.ValueChanged
        If DTP_Valid.Value.DayOfWeek = DayOfWeek.Sunday Then
            CB_OvertimeType.SelectedItem = "Triple"
        Else
            CB_OvertimeType.SelectedItem = "Doble"
        End If
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim.Length > 1 Then
            Dim CL As New CL_EmployeeOvertime
            Dim dt = CL.GetEmployeeSuggestions(AppUser, TB_Employee.Text.Trim)

            If dt.Rows.Count > 0 Then
                LBX_Suggesting.DataSource = dt
                LBX_Suggesting.DisplayMember = "FullName"
                LBX_Suggesting.ValueMember = "EMPL_ID"
                LBX_Suggesting.Visible = True
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
                    TB_EmployeeName.Text = values(1).Trim()
                Else
                    TB_EmployeeName.Text = selectedText.Trim()
                End If

                LBX_Suggesting.Visible = False

                TB_AuthorizeBy.Focus()

            Catch ex As Exception
                Console.WriteLine("Error temporal de casteo: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
            If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
                MsgBox("Por favor, seleccione un empleado válido usando el buscador.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_AuthorizeBy.Text) Then
                MsgBox("Debe ingresar quién autoriza las horas extras.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_OvertimeCause.Text) Then
                MsgBox("Debe capturar el motivo o causa de las horas extras.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If CB_OvertimeType.SelectedIndex <= 0 Then
                MsgBox("Debe seleccionar si las horas extras son Dobles o Triples.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim overtHours As Decimal = 0
            If Not Decimal.TryParse(TB_OvertimeHours.Text, overtHours) OrElse overtHours <= 0 Then
                MsgBox("Ingrese una cantidad de horas válida y mayor a 0.00.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim CL As New CL_EmployeeOvertime
            CL.REMPL_ID = CInt(TB_EmployeeId.Text)
            CL.OVERT_DATE = DTP_Valid.Value.Date
            CL.OVERT_HOURS = overtHours
            CL.OVERT_CAUSE = TB_OvertimeCause.Text.Trim()
            CL.OVERT_DESCR = TB_Description.Text.Trim()
            CL.OVERT_AUTH = TB_AuthorizeBy.Text.Trim()
            CL.OVERT_CREBY = GlobalSession.GlobalUserName
            CL.OVERT_STATUS = True
            CL.OVERT_TYPE = CB_OvertimeType.SelectedItem.ToString()

            If CL.InsertEmployeeOvertime() Then
                ' LOG 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"NUEVAS HORAS EXTRAS ({CL.OVERT_TYPE}): Se cargaron {overtHours} hrs. al empleado ID {TB_EmployeeId.Text}. Tipo: {CL.OVERT_TYPE} | Motivo: {CL.OVERT_CAUSE} | Autorizó: {CL.OVERT_AUTH}."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_HorasExtras", "INSERT_SUCCESS", descLog, CInt(TB_EmployeeId.Text), "INFO")
                End Using

                MsgBox($"¡Las horas extras ({CL.OVERT_TYPE}) han sido registradas exitosamente!", MsgBoxStyle.Information, "Registro Completo")

                CargarGridGeneral()
                ResetFormFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR 
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL INSERTAR HORAS EXTRAS: {ex.Message}. Empleado ID intentado: {TB_EmployeeId.Text}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_HorasExtras", "INSERT_EXCEPTION", descError, CInt(If(String.IsNullOrEmpty(TB_EmployeeId.Text), 0, TB_EmployeeId.Text)), "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("No se pudo escribir en la bitácora de errores: " & logEx.Message)
            End Try

            If ex.Message.Contains("horas extras registradas") Then
                MsgBox("El empleado ya cuenta con horas extras registradas en la fecha seleccionada." & vbCrLf & vbCrLf &
                       "Por favor, use el módulo de edición si requiere modificar la cantidad de horas.",
                       MsgBoxStyle.Exclamation, "Aviso del Sistema")
            Else
                MsgBox("Ocurrió un inconveniente técnico al intentar guardar en la base de datos: " & ex.Message,
                       MsgBoxStyle.Critical, "Error de Comunicación")
            End If
        End Try
    End Sub

    Private Sub CargarGridGeneral()
        Dim CL As New CL_EmployeeOvertime
        DGV_OverTime.DataSource = CL.GetOvertimeHistory(0)

        If DGV_OverTime.Columns.Count > 0 Then
            If DGV_OverTime.Columns.Contains("ID") Then DGV_OverTime.Columns("ID").Visible = False

            DGV_OverTime.ReadOnly = True
            DGV_OverTime.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DGV_OverTime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            If DGV_OverTime.Columns.Contains("Horas Extras") Then
                DGV_OverTime.Columns("Horas Extras").DefaultCellStyle.Format = "N2"
            End If
        End If
    End Sub

    Private Sub ResetFormFields()
        TB_Employee.Clear()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_OvertimeCause.Clear()
        TB_Description.Clear()
        TB_OvertimeHours.Clear()
        TB_AuthorizeBy.Clear()
        DTP_Valid.Value = DateTime.Now
        CB_OvertimeType.SelectedIndex = 0
        CargarGridGeneral()
        TB_Employee.Focus()
    End Sub

End Class