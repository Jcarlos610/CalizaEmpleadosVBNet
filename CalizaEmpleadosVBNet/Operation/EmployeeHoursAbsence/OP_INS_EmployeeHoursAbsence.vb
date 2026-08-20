Imports Microsoft.Data.SqlClient

Public Class OP_INS_EmployeeHoursAbsence

    Dim SelectedEmplID As Integer = 0

    Private Sub OP_INS_EmployeeHoursAbsence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBX_Suggesting.Visible = False

        CB_HoursAbsenceType.Items.Clear()
        CB_HoursAbsenceType.Items.Add("Seleccione una opción...")
        CB_HoursAbsenceType.Items.Add("Comida")
        CB_HoursAbsenceType.Items.Add("Tiempo Extra")
        CB_HoursAbsenceType.Items.Add("Nomina")

        CB_HoursAbsenceType.SelectedIndex = 0
        CargarGridGeneral()
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim.Length > 1 Then
            Dim CL As New CL_RecordByEmployeeHoursAbsence
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
                MsgBox("Debe ingresar quién autoriza el permiso de horas.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If String.IsNullOrWhiteSpace(TB_Cause.Text) Then
                MsgBox("Debe capturar el motivo o causa del permiso de horas.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If CB_HoursAbsenceType.SelectedIndex <= 0 Then
                MsgBox("Debe seleccionar cómo se compensarán las horas: Comida, Tiempo Extra o Nómina.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim absHours As Decimal = 0
            If Not Decimal.TryParse(TB_HoursAbsence.Text, absHours) OrElse absHours <= 0 Then
                MsgBox("Ingrese una cantidad de horas válida y mayor a 0.00.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim CL As New CL_RecordByEmployeeHoursAbsence
            CL.REMPL_ID = CInt(TB_EmployeeId.Text)
            CL.HABS_DATE = DTP_Valid.Value.Date
            CL.HABS_HOURS = absHours
            CL.HABS_CAUSE = TB_Cause.Text.Trim()
            CL.HABS_DESCR = TB_Description.Text.Trim()
            CL.HABS_AUTH = TB_AuthorizeBy.Text.Trim()
            CL.HABS_CREBY = GlobalSession.GlobalUserName
            CL.HABS_STATUS = True
            CL.HABS_TYPE = CB_HoursAbsenceType.SelectedItem.ToString()

            If CL.InsertHoursAbsenceRecord() Then
                ' LOG 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"NUEVO PERMISO DE HORAS ({CL.HABS_TYPE}): Se cargaron {absHours} hrs. al empleado ID {TB_EmployeeId.Text}. Tipo: {CL.HABS_TYPE} | Motivo: {CL.HABS_CAUSE} | Autorizó: {CL.HABS_AUTH}."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_PermisoDeHoras", "INSERT_SUCCESS", descLog, CInt(TB_EmployeeId.Text), "INFO")
                End Using

                MsgBox($"¡El permiso de horas ({CL.HABS_TYPE}) ha sido registrado exitosamente!", MsgBoxStyle.Information, "Registro Completo")

                CargarGridGeneral()
                ResetFormFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR 
            Try
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL INSERTAR PERMISO DE HORAS: {ex.Message}. Empleado ID intentado: {TB_EmployeeId.Text}"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_PermisoDeHoras", "INSERT_EXCEPTION", descError, CInt(If(String.IsNullOrEmpty(TB_EmployeeId.Text), 0, TB_EmployeeId.Text)), "ERROR")
                End Using
            Catch logEx As Exception
                Console.WriteLine("No se pudo escribir en la bitácora de errores: " & logEx.Message)
            End Try

            If ex.Message.Contains("permiso de horas registrado") Then
                MsgBox("El empleado ya cuenta con un permiso de horas registrado en la fecha seleccionada." & vbCrLf & vbCrLf &
                       "Por favor, use el módulo de edición si requiere modificarlo.",
                       MsgBoxStyle.Exclamation, "Aviso del Sistema")
            Else
                MsgBox("Ocurrió un inconveniente técnico al intentar guardar en la base de datos: " & ex.Message,
                       MsgBoxStyle.Critical, "Error de Comunicación")
            End If
        End Try
    End Sub

    Private Sub CargarGridGeneral()
        Dim CL As New CL_RecordByEmployeeHoursAbsence
        DGV_HoursAbsence.DataSource = CL.Get_AllHoursAbsenceRecords(0)

        If DGV_HoursAbsence.Columns.Count > 0 Then
            If DGV_HoursAbsence.Columns.Contains("ID") Then DGV_HoursAbsence.Columns("ID").Visible = False

            DGV_HoursAbsence.ReadOnly = True
            DGV_HoursAbsence.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DGV_HoursAbsence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            If DGV_HoursAbsence.Columns.Contains("Horas") Then
                DGV_HoursAbsence.Columns("Horas").DefaultCellStyle.Format = "N2"
            End If
        End If
    End Sub

    Private Sub ResetFormFields()
        TB_Employee.Clear()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_Cause.Clear()
        TB_Description.Clear()
        TB_HoursAbsence.Clear()
        TB_AuthorizeBy.Clear()
        DTP_Valid.Value = DateTime.Now
        CB_HoursAbsenceType.SelectedIndex = 0
        CargarGridGeneral()
        TB_Employee.Focus()
    End Sub
End Class