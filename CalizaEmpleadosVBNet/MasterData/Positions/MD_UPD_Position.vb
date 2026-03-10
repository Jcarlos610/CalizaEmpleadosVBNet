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

    Private Sub TB_Update_Click(sender As Object, e As EventArgs) Handles TB_Update.Click
        If TB_PositionName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Favor de indicar quién autoriza la posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Salary.Text = "" Then
            MessageBox.Show("Favor de indicar el salario asignado para esta posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else


            Dim Position = New CL_Positions(CInt(CB_AllPositions.SelectedValue), TB_PositionName.Text, TB_Description.Text, Date.Now, TB_Salary.Text, AppUser, TB_AuthorizeBy.Text, 1)

            Position.POSIT_STAT = CB_Status.Checked


            If AppUser IsNot Nothing Then
                If Position.UpdatePosition() Then
                    MessageBox.Show("La Posición " + TB_PositionName.Text + " fue actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If
            Else
                MessageBox.Show("No se actualizó la posición debido a que no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Positions()
        DGV_PositionsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_PositionsList.AutoResizeColumns()
        DGV_PositionsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_PositionsList.DataSource = report.Get_AllPositions
    End Sub

    Private Sub CB_AllPositions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllPositions.SelectedIndexChanged
        ' Evita ejecución durante la carga del DataSource
        If CB_AllPositions.SelectedValue Is Nothing Then Exit Sub

        ' Evita DataRowView
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