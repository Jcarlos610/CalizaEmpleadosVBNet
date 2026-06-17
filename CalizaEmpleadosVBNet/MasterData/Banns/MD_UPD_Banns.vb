Imports Microsoft.Data.SqlClient

Public Class MD_UPD_Banns
    Private Sub MD_UPD_Banns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()
        Dim report As New CL_Banns()
        CB_AllBanns.DataSource = report.Get_ListOfBanns

        CB_AllBanns.DisplayMember = "Nombre"
        CB_AllBanns.ValueMember = "Id"
        CB_AllBanns.SelectedIndex = 0

        TB_BannName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        CB_Status.Checked = False
        TB_Ammount.Text = ""

        DT_ValidFrom.Value = Date.Today
        DT_ValidTo.Value = Date.Today.AddYears(1)

        Display_Record()
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Banns()
        DGV_BannsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_BannsList.AutoResizeColumns()
        DGV_BannsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_BannsList.DataSource = report.Get_AllBanns
    End Sub

    'Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
    '    If TB_BannName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar un nombre de la amonestación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza la amonestación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Ammount.Text = "" Then
    '        MessageBox.Show("Favor de indicar el monto asignado para este beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else
    '        Dim Bann = New CL_Banns(CInt(CB_AllBanns.SelectedValue), TB_BannName.Text, TB_Description.Text, TB_Ammount.Text, TB_AuthorizeBy.Text, DT_ValidFrom.Value, DT_ValidTo.Value, CB_Status.Checked)

    '        If Bann.UpdateBann() Then
    '            MessageBox.Show("La amonestación " + TB_BannName.Text + " fue actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            InitializationOfFields()
    '        End If

    '    End If
    'End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
        If TB_BannName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de la amonestación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Favor de indicar quién autoriza la amonestación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Ammount.Text = "" Then
            MessageBox.Show("Favor de indicar el monto asignado para este beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                Dim BannID As Integer = CInt(CB_AllBanns.SelectedValue)
                Dim statusStr As String = If(CB_Status.Checked, "Activa", "Inactiva")

                Dim Bann = New CL_Banns(BannID, TB_BannName.Text, TB_Description.Text, TB_Ammount.Text, TB_AuthorizeBy.Text, DT_ValidFrom.Value, DT_ValidTo.Value, CB_Status.Checked)

                If Bann.UpdateBann() Then
                    ' LOG 
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"ACTUALIZACIÓN AMONESTACIÓN EXITOSA: El usuario '{GlobalSession.GlobalUserName}' modificó el ID: {BannID} ({TB_BannName.Text.Trim()}) | " &
                                            $"Nuevo Monto: {TB_Ammount.Text} | Autorizado Por: '{TB_AuthorizeBy.Text.Trim()}' | " &
                                            $"Estatus: {statusStr} | Vigencia: {DT_ValidFrom.Value:dd/MM/yyyy} al {DT_ValidTo.Value:dd/MM/yyyy} | " &
                                            $"Nueva Descripción: '{TB_Description.Text.Trim()}'."

                        InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Banns", "UPDATE_BANN_SUCCESS", descLog, BannID, "INFO")
                    End Using

                    MessageBox.Show("La amonestación " + TB_BannName.Text + " fue actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If

            Catch ex As Exception
                ' LOG DE ERROR 
                Dim fallbackID As Integer = 0
                Try : fallbackID = CInt(CB_AllBanns.SelectedValue) : Catch : End Try

                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL ACTUALIZAR AMONESTACIÓN: Falló la modificación del ID: {fallbackID}. Motivo: {ex.Message} en Form_Banns.BT_Update_Click()"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Banns", "UPDATE_BANN_ERROR", descError, fallbackID, "ERROR", ex.StackTrace)
                End Using

                MessageBox.Show("Ocurrió un error inesperado al intentar actualizar la amonestación. El detalle del error se ha registrado en la bitácora.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub CB_AllBanns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllBanns.SelectedIndexChanged

        If CB_AllBanns.SelectedValue Is Nothing Then Exit Sub

        If TypeOf CB_AllBanns.SelectedValue IsNot Integer Then Exit Sub

        Dim idBann As Integer = CInt(CB_AllBanns.SelectedValue)

        Dim Benefit As New CL_Banns
        Dim SelectedBenefit As DataTable = Benefit.Get_OneBann(idBann)

        If SelectedBenefit.Rows.Count = 0 Then Exit Sub

        Dim Item As DataRow = SelectedBenefit.Rows(0)

        TB_BannName.Text = Item(1).ToString()
        TB_Description.Text = Item(2).ToString()
        TB_AuthorizeBy.Text = Item(6).ToString()
        TB_Ammount.Text = Item(4).ToString
        DT_ValidFrom.Value = CDate(Item(7))
        DT_ValidTo.Value = CDate(Item(8))
        CB_Status.Checked = Item(9)
    End Sub
End Class