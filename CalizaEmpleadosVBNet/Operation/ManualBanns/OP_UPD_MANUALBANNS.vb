
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

Public Class OP_UPD_MANUALBANNS

    Dim SelectedEBannID As Integer = 0
    Dim JustificacionDesactivar As String = ""

    Private Sub OP_UPD_MANUALBANNS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_Valid.Enabled = False
        Historial()
    End Sub

    Private Sub DGV_Banns_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Banns.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_Banns.Rows(e.RowIndex)

            SelectedEBannID = CInt(row.Cells("ID").Value)

            TB_EmployeeId.Text = row.Cells("ID Empleado").Value.ToString()
            TB_EmployeeName.Text = row.Cells("Empleado").Value.ToString()
            TB_BannName.Text = row.Cells("Amonestación").Value.ToString()
            TB_Description.Text = row.Cells("Descripción").Value.ToString()
            TB_BannDays.Text = row.Cells("Días").Value.ToString()
            DTP_Valid.Value = CDate(row.Cells("Fecha").Value)

            TB_EmployeeId.ReadOnly = True
            TB_EmployeeName.ReadOnly = True

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
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
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

        Dim CL As New CL_EmployeeBanns
        CL.DREMPL_DATE = DTP_Valid.Value.Date
        CL.DREMPL_DQUANTITY = dias
        CL.DREMPL_BNAME = TB_BannName.Text.Trim()
        CL.DREMPL_DESCR = TB_Description.Text.Trim()
        CL.DREMPL_STATUS = CB_Status.Checked
        CL.DREMPL_CREBY = AppUser

        Dim justiFinal As String = JustificacionDesactivar
        If String.IsNullOrWhiteSpace(justiFinal) AndAlso CB_Status.Checked = False Then
            justiFinal = "Modificación de días / campos sin alterar estado activo."
        End If

        If CL.UpdateEmployeeBanns(SelectedEBannID, justiFinal) Then
            MsgBox("¡Amonestación actualizada con éxito!", MsgBoxStyle.Information, "Éxito")

            Historial()
            ResetFormFields()
        End If
    End Sub

    Private Sub Historial()
        Dim CL As New CL_EmployeeBanns
        DGV_Banns.DataSource = CL.GetAllBannsHistory(AppUser)

        If DGV_Banns.Columns.Count > 0 Then
            DGV_Banns.Columns("ID").Visible = False
            DGV_Banns.Columns("ID Empleado").Visible = True

            DGV_Banns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGV_Banns.ReadOnly = True
            DGV_Banns.RowHeadersVisible = False

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