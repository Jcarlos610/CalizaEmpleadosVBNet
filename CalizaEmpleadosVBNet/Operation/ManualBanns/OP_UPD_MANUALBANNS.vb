
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement

'Public Class OP_UPD_MANUALBANNS

'    Dim SelectedEBannID As Integer = 0
'    Dim JustificacionDesactivar As String = ""

'    Private Sub OP_UPD_MANUALBANNS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ' Cargamos el historial general al abrir la pantalla
'        Historial()
'    End Sub

'    Private Sub DGV_Banns_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Banns.CellContentClick
'        If e.RowIndex >= 0 Then
'            Dim row As DataGridViewRow = DGV_Banns.Rows(e.RowIndex)

'            SelectedEBannID = CInt(row.Cells("ID").Value)

'            TB_EmployeeId.Text = row.Cells("ID").Value.ToString()
'            TB_EmployeeName.Text = row.Cells("Empleado").Value.ToString()
'            TB_BannName.Text = row.Cells("Amonestación").Value.ToString()
'            TB_Description.Text = row.Cells("Descripción").Value.ToString()
'            TB_BannDays.Text = row.Cells("Días").Value.ToString()
'            DTP_Valid.Value = CDate(row.Cells("Fecha").Value)

'            TB_EmployeeId.ReadOnly = True
'            TB_EmployeeName.ReadOnly = True

'            RemoveHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

'            If row.Cells("Estado").Value IsNot Nothing Then
'                CB_Status.Checked = CBool(row.Cells("Status").Value)
'            Else
'                CB_Status.Checked = True
'            End If

'            AddHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

'            JustificacionDesactivar = ""
'        End If
'    End Sub


'    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
'        If SelectedEBannID = 0 Then
'            MsgBox("Por favor, seleccione una amonestación de la tabla.", MsgBoxStyle.Exclamation, "Aviso")
'            Return
'        End If

'        If CB_Status.Checked = False AndAlso String.IsNullOrWhiteSpace(JustificacionDesactivar) Then
'            MsgBox("No se puede actualizar el registro sin una justificación de la desactivación.", MsgBoxStyle.Critical, "Error de Validación")
'            Return
'        End If

'        Dim dias As Decimal = 0
'        If Not Decimal.TryParse(TB_BannDays.Text, dias) OrElse dias <= 0 Then
'            MsgBox("Por favor, introduzca una cantidad de días válida mayor a cero.", MsgBoxStyle.Exclamation, "Aviso")
'            Return
'        End If

'        Dim CL As New CL_EmployeeBanns
'        CL.DREMPL_DATE = DTP_Valid.Value.Date
'        CL.DREMPL_DQUANTITY = dias
'        CL.DREMPL_BNAME = TB_BannName.Text.Trim()
'        CL.DREMPL_DESCR = TB_Description.Text.Trim()
'        CL.DREMPL_STATUS = CB_Status.Checked
'        CL.DREMPL_CREBY = AppUser

'        If CL.UpdateEmployeeBanns(SelectedEBannID, JustificacionDesactivar) Then
'            MsgBox("¡Amonestación actualizada con éxito!", MsgBoxStyle.Information, "Éxito")

'            Historial()
'            ResetFormFields()
'        End If
'    End Sub

'    Private Sub Historial()
'        Dim CL As New CL_EmployeeBanns
'        DGV_Banns.DataSource = CL.GetAllBannsHistory(AppUser)

'        If DGV_Banns.Columns.Count > 0 Then
'            DGV_Banns.Columns("ID").Visible = False
'            DGV_Banns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
'            DGV_Banns.ReadOnly = True
'            DGV_Banns.RowHeadersVisible = False

'            DGV_Banns.Columns("Empleado").FillWeight = 130
'            DGV_Banns.Columns("Amonestación").FillWeight = 110
'        End If
'    End Sub

'    Private Sub ResetFormFields()
'        TB_EmployeeId.Clear()
'        TB_EmployeeName.Clear()
'        TB_BannName.Clear()
'        TB_Description.Clear()
'        TB_BannDays.Clear()
'        DTP_Valid.Value = Now
'        SelectedEBannID = 0

'        RemoveHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged
'        CB_Status.Checked = True
'        AddHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

'        JustificacionDesactivar = ""
'    End Sub

'    Private Sub CB_Status_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Status.CheckedChanged
'        If CB_Status.Checked = False Then

'            Dim motivo As String = InputBox("Por favor, ingrese la justificación o el motivo por el cual va a desactivar esta amonestación:", "Justificación Obligatoria")

'            If String.IsNullOrWhiteSpace(motivo) Then
'                MsgBox("Para poder desactivar la amonestación es obligatorio ingresar una justificación.", MsgBoxStyle.Critical, "Aviso")

'                RemoveHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged
'                CB_Status.Checked = True
'                AddHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

'                JustificacionDesactivar = ""
'            Else
'                JustificacionDesactivar = motivo
'            End If
'        Else
'            JustificacionDesactivar = ""
'        End If
'    End Sub
'End Class

Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Data.SqlClient

Public Class OP_UPD_MANUALBANNS

    Dim SelectedEBannID As Integer = 0
    Dim JustificacionDesactivar As String = ""
    Private Original_BannDays As Decimal = 0D

    Private Sub OP_UPD_MANUALBANNS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_Valid.Enabled = False
        Historial()
    End Sub


    Private Sub DGV_Banns_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Banns.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_Banns.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Banns.Rows(hit.RowIndex)

                SelectedEBannID = CInt(row.Cells("ID").Value)
                TB_EmployeeId.Text = row.Cells("ID Empleado").Value.ToString()
                TB_EmployeeName.Text = row.Cells("Empleado").Value.ToString()
                TB_BannName.Text = row.Cells("Amonestación").Value.ToString()
                TB_Description.Text = row.Cells("Descripción").Value.ToString()
                TB_BannDays.Text = row.Cells("Días").Value.ToString()
                DTP_Valid.Value = CDate(row.Cells("Fecha").Value)

                Decimal.TryParse(TB_BannDays.Text, Original_BannDays)

                TB_EmployeeId.ReadOnly = True
                TB_EmployeeName.ReadOnly = True

                Dim empID As Integer = 0
                If Integer.TryParse(TB_EmployeeId.Text, empID) Then
                    Dim CL_Banns As New CL_EmployeeBanns
                    Dim saldo As Decimal = CL_Banns.GetEmployeeBannsBalance(empID)
                    LB_BannsBalance.Text = "Días acumulados: " & saldo.ToString("N2")
                Else
                    LB_BannsBalance.Text = "Días acumulados: 0.00"
                End If

                RemoveHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

                If row.Cells("Estado").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Estado").Value) Then
                    Dim estadoTexto As String = row.Cells("Estado").Value.ToString()
                    If estadoTexto = "Activa" Then
                        CB_Status.Checked = True
                    Else
                        CB_Status.Checked = False
                    End If
                Else
                    CB_Status.Checked = True
                End If

                AddHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

                JustificacionDesactivar = ""

            Catch ex As Exception
                MsgBox("Error al seleccionar la amonestación: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub


    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        Try
            If SelectedEBannID = 0 Then
                MsgBox("Por favor, seleccione una amonestación de la tabla.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim dias As Decimal = 0
            If Not Decimal.TryParse(TB_BannDays.Text, dias) OrElse dias <= 0 Then
                MsgBox("Por favor, introduzca una cantidad de días válida mayor a cero.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If CB_Status.Checked = False AndAlso String.IsNullOrWhiteSpace(JustificacionDesactivar) Then
                Dim row As DataGridViewRow = DGV_Banns.CurrentRow
                If row IsNot Nothing AndAlso row.Cells("Estado").Value.ToString() = "Activa" Then
                    MsgBox("No se puede desactivar una amonestación activa sin una justificación.", MsgBoxStyle.Critical, "Error de Validación")
                    Return
                End If
            End If


            Dim detalleCambios As String = ""
            If Original_BannDays <> dias Then
                detalleCambios &= $"Modificación de días (Antes: {Original_BannDays} -> Ahora: {dias}). "
            End If
            If CB_Status.Checked = False Then
                detalleCambios &= "Estado cambiado a INACTIVA. "
            End If
            If detalleCambios = "" Then
                detalleCambios = "Actualización de campos descriptivos o fechas."
            End If

            Dim CL As New CL_EmployeeBanns
            CL.DREMPL_DATE = DTP_Valid.Value.Date
            CL.DREMPL_BNAME = TB_BannName.Text.Trim()
            CL.DREMPL_DESCR = TB_Description.Text.Trim()
            CL.DREMPL_STATUS = CB_Status.Checked
            CL.DREMPL_CREBY = GlobalSession.GlobalUserName

            Dim justiFinal As String = JustificacionDesactivar
            If String.IsNullOrWhiteSpace(justiFinal) AndAlso CB_Status.Checked = False Then
                justiFinal = "Modificación de días / campos sin alterar estado activo."
            End If

            If CL.UpdateEmployeeBanns(SelectedEBannID, justiFinal, dias) Then

                'LOG 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"MODIFICACIÓN DE AMONESTACIÓN: Se editó el registro BANN_ID: {SelectedEBannID}. Cambios: {detalleCambios} Justificación: '{justiFinal}'."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Amonestaciones", "UPDATE_BANN_SUCCESS", descLog, SelectedEBannID, "INFO")
                End Using

                MsgBox("¡Amonestación actualizada con éxito!", MsgBoxStyle.Information, "Éxito")

                Historial()
                ResetFormFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR 
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la modificación del registro BANN_ID: {SelectedEBannID}. Motivo: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Amonestaciones", "ERROR_UPDATE_BANN", descError, SelectedEBannID, "ERROR", ex.StackTrace)
            End Using
            MsgBox("Ocurrió un error inesperado al actualizar la amonestación: " & ex.Message, MsgBoxStyle.Critical, "Error Crítico")
        End Try
    End Sub

    Private Sub Historial()
        Dim CL As New CL_EmployeeBanns
        DGV_Banns.DataSource = CL.GetAllBannsHistory(GlobalSession.GlobalUserName)

        If DGV_Banns.Columns.Count > 0 Then
            DGV_Banns.Columns("ID").Visible = False
            DGV_Banns.Columns("ID Empleado").Visible = True

            DGV_Banns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGV_Banns.ReadOnly = True

            DGV_Banns.Columns("Empleado").FillWeight = 130
            DGV_Banns.Columns("Amonestación").FillWeight = 110
        End If
    End Sub

    Private Sub ResetFormFields()
        TB_EmployeeId.Clear()
        TB_EmployeeName.Clear()
        TB_BannName.Clear()
        TB_Description.Clear()
        TB_BannDays.Clear()
        DTP_Valid.Value = Now
        SelectedEBannID = 0
        LB_BannsBalance.Text = "Días acumulados: 0.00"
        RemoveHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged
        CB_Status.Checked = True
        AddHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

        JustificacionDesactivar = ""
    End Sub

    Private Sub CB_Status_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Status.CheckedChanged
        If CB_Status.Checked = False Then

            Dim motivo As String = InputBox("Por favor, ingrese la justificación o el motivo por el cual va a desactivar esta amonestación:", "Justificación Obligatoria")

            If String.IsNullOrWhiteSpace(motivo) Then
                MsgBox("Para poder desactivar la amonestación es obligatorio ingresar una justificación.", MsgBoxStyle.Critical, "Aviso")

                RemoveHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged
                CB_Status.Checked = True
                AddHandler CB_Status.CheckedChanged, AddressOf CB_Status_CheckedChanged

                JustificacionDesactivar = ""
            Else
                JustificacionDesactivar = motivo
            End If
        Else
            JustificacionDesactivar = ""
        End If
    End Sub
End Class