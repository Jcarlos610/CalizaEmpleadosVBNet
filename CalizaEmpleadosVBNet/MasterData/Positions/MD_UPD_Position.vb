Imports Microsoft.Data.SqlClient

Public Class MD_UPD_Position
    'Private Sub MD_UPD_Position_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    InitializationOfFields()
    'End Sub

    'Private Sub TB_Update_Click(sender As Object, e As EventArgs) Handles TB_Update.Click
    '    If TB_PositionName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar un nombre de posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza la posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Salary.Text = "" Then
    '        MessageBox.Show("Favor de indicar el salario asignado para esta posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else


    '        Dim Position = New CL_Positions(CInt(CB_AllPositions.SelectedValue), TB_PositionName.Text, TB_Description.Text, Date.Now, TB_Salary.Text, AppUser, TB_AuthorizeBy.Text, 1)


    '        If AppUser IsNot Nothing Then
    '            If Position.UpdatePosition() Then
    '                MessageBox.Show("La Posición " + TB_PositionName.Text + " fue actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                InitializationOfFields()
    '            End If
    '        Else
    '            MessageBox.Show("No se actualizó la posición debido a que no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If

    '    End If
    'End Sub

    'Private Sub Display_Record()
    '    Dim report As New CL_Positions()
    '    DGV_PositionsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '    DGV_PositionsList.AutoResizeColumns()
    '    DGV_PositionsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '    DGV_PositionsList.DataSource = report.Get_AllPositions
    'End Sub

    'Private Sub CB_AllPositions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllPositions.SelectedIndexChanged
    '    ' Evita ejecución durante la carga del DataSource
    '    If CB_AllPositions.SelectedValue Is Nothing Then Exit Sub

    '    ' Evita DataRowView
    '    If TypeOf CB_AllPositions.SelectedValue IsNot Integer Then Exit Sub

    '    Dim idPosition As Integer = CInt(CB_AllPositions.SelectedValue)

    '    Dim Position As New CL_Positions
    '    Dim SelectedPosition As DataTable = Position.Get_OnePosition(idPosition)

    '    If SelectedPosition.Rows.Count = 0 Then Exit Sub

    '    Dim Item As DataRow = SelectedPosition.Rows(0)

    '    TB_PositionName.Text = Item(1).ToString()
    '    TB_Description.Text = Item(2).ToString()
    '    TB_AuthorizeBy.Text = Item(6).ToString()
    '    TB_Salary.Text = Item(4).ToString
    'End Sub

    'Private Sub InitializationOfFields()
    '    Dim report As New CL_Positions()
    '    CB_AllPositions.DataSource = report.Get_ListOfPositions

    '    CB_AllPositions.DisplayMember = "Nombre"
    '    CB_AllPositions.ValueMember = "Id"
    '    CB_AllPositions.SelectedIndex = 0

    '    TB_PositionName.Text = ""
    '    TB_Description.Text = ""
    '    TB_AuthorizeBy.Text = ""
    '    TB_Salary.Text = ""

    '    Display_Record()
    'End Sub

    Private Sub MD_UPD_Position_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    'Private Sub TB_Update_Click(sender As Object, e As EventArgs) Handles TB_Update.Click
    '    If TB_PositionName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar un nombre de posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza la posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Salary.Text = "" Then
    '        MessageBox.Show("Favor de indicar el salario asignado para esta posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else


    '        Dim Position = New CL_Positions(CInt(CB_AllPositions.SelectedValue), TB_PositionName.Text, TB_Description.Text, Date.Now, TB_Salary.Text, AppUser, TB_AuthorizeBy.Text, 1)

    '        Position.POSIT_STAT = CB_Status.Checked


    '        If AppUser IsNot Nothing Then
    '            If Position.UpdatePosition() Then
    '                MessageBox.Show("La Posición " + TB_PositionName.Text + " fue actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                InitializationOfFields()
    '            End If
    '        Else
    '            MessageBox.Show("No se actualizó la posición debido a que no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If

    '    End If
    'End Sub

    Private Sub TB_Update_Click(sender As Object, e As EventArgs) Handles TB_Update.Click
        Try
            If TB_PositionName.Text.Trim = "" Then
                MessageBox.Show("Favor de ingresar un nombre de posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If TB_Description.Text.Trim = "" Then
                MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If TB_AuthorizeBy.Text.Trim = "" Then
                MessageBox.Show("Favor de indicar quién autoriza la posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If TB_Salary.Text.Trim = "" Then
                MessageBox.Show("Favor de indicar el salario asignado para esta posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If CB_AllPositions.SelectedValue Is Nothing OrElse CInt(CB_AllPositions.SelectedValue) = 0 Then
                MessageBox.Show("Favor de seleccionar una posición válida a actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim targetPositionID As Integer = CInt(CB_AllPositions.SelectedValue)

            Dim Position = New CL_Positions(
            targetPositionID,
            TB_PositionName.Text.Trim,
            TB_Description.Text.Trim,
            Date.Now,
            TB_Salary.Text.Trim,
            GlobalSession.GlobalUserName,
            TB_AuthorizeBy.Text.Trim,
            1
        )

            Position.POSIT_STAT = CB_Status.Checked
            Dim textoEstado As String = If(CB_Status.Checked, "ACTIVO / VIGENTE", "INACTIVO / DE BAJA")

            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)

            If Position.UpdatePosition() Then
                'LOG DE ACTUALIZACIÓN
                Dim descUpdate As String = $"MODIFICACIÓN DE PUESTO: Se actualizaron los parámetros del POSITION_ID: {targetPositionID} ('{TB_PositionName.Text.Trim}'). Salario registrado: ${TB_Salary.Text.Trim}. Estado del puesto: [{textoEstado}]. Cambios autorizados por: {TB_AuthorizeBy.Text.Trim}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Positions", "UPDATE_POSITION_SUCCESS", descUpdate, targetPositionID, "INFO")

                MessageBox.Show("La Posición " + TB_PositionName.Text.Trim + " fue actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
            Else
                'LOG DE ADVERTENCIA 
                Dim descWarn As String = $"RECHAZO EN BD: No se pudieron guardar los cambios en el POSITION_ID: {targetPositionID}."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Positions", "UPDATE_POSITION_FAILED", descWarn, targetPositionID, "WARNING")
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim currentID As Integer = If(CB_AllPositions.SelectedValue IsNot Nothing, CInt(CB_AllPositions.SelectedValue), 0)
            Dim descError As String = $"ERROR CRÍTICO: Falló la modificación de la posición ID: {currentID}. Motivo: {ex.Message}"

            InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Positions", "ERROR_UPDATE_POSITION", descError, currentID, "ERROR", ex.StackTrace)

            MessageBox.Show("Ocurrió un error inesperado al actualizar la posición: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Positions()
        DGV_PositionsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_PositionsList.AutoResizeColumns()
        DGV_PositionsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_PositionsList.DataSource = report.Get_AllPositions
    End Sub

    Private Sub CB_AllPositions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllPositions.SelectedIndexChanged

        If CB_AllPositions.SelectedValue Is Nothing Then Exit Sub

        If TypeOf CB_AllPositions.SelectedValue IsNot Integer Then Exit Sub

        Dim idPosition As Integer = CInt(CB_AllPositions.SelectedValue)

        Dim Position As New CL_Positions
        Dim SelectedPosition As DataTable = Position.Get_OnePosition(idPosition)

        If SelectedPosition.Rows.Count = 0 Then Exit Sub

        Dim Item As DataRow = SelectedPosition.Rows(0)

        TB_PositionName.Text = Item(1).ToString()
        TB_Description.Text = Item(2).ToString()
        TB_AuthorizeBy.Text = Item(6).ToString()
        TB_Salary.Text = Item(4).ToString
        CB_Status.Checked = Item(7)
    End Sub

    Private Sub InitializationOfFields()
        Dim report As New CL_Positions()
        CB_AllPositions.DataSource = report.Get_ListOfPositions

        CB_AllPositions.DisplayMember = "Nombre"
        CB_AllPositions.ValueMember = "Id"
        CB_AllPositions.SelectedIndex = 0

        TB_PositionName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        TB_Salary.Text = ""
        CB_Status.Checked = False

        Display_Record()
    End Sub

End Class