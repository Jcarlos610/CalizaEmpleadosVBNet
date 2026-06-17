Imports Microsoft.Data.SqlClient

Public Class MD_INS_Position

    Private Sub MD_INS_Positions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializationOfFields()

    End Sub

    Private Sub InitializationOfFields()

        TB_PositionName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        TB_Salary.Text = ""

        Display_Record()
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Positions()
        DGV_PositionsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_PositionsList.AutoResizeColumns()
        DGV_PositionsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_PositionsList.DataSource = report.Get_AllPositions
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If TB_PositionName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar un nombre de posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza la posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Salary.Text = "" Then
    '        MessageBox.Show("Favor de indicar el salario asignado para esta posición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else
    '        Dim Position = New CL_Positions(TB_PositionName.Text, TB_Description.Text, Date.Now, TB_Salary.Text, AppUser, TB_AuthorizeBy.Text, 1)

    '        If Position.InsertPosition() Then
    '            MessageBox.Show("La posición " + TB_PositionName.Text + " fue creada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            InitializationOfFields()
    '        End If

    '    End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

            Dim Position = New CL_Positions(
                TB_PositionName.Text.Trim,
                TB_Description.Text.Trim,
                Date.Now,
                TB_Salary.Text.Trim,
                GlobalSession.GlobalUserName,
                TB_AuthorizeBy.Text.Trim,
                1
            )


            If Position.InsertPosition() Then
                Dim connTmp As New SqlConnection(My.Settings.ConnectionString)

                'LOG DE ÉXITO
                Dim descExito As String = $"CREACIÓN DE PUESTO: Se registró el puesto '{TB_PositionName.Text.Trim}' con un salario base de ${TB_Salary.Text.Trim}. Autorizado originalmente por: {TB_AuthorizeBy.Text.Trim}. Descripción: [{TB_Description.Text.Trim}]."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Positions", "INSERT_POSITION_SUCCESS", descExito, 0, "INFO")

                MessageBox.Show("La posición " + TB_PositionName.Text.Trim + " fue creada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializationOfFields()
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Dim connTmp As New SqlConnection(My.Settings.ConnectionString)
            Dim descError As String = $"ERROR CRÍTICO: Falló la creación del puesto '{TB_PositionName.Text.Trim}'. Motivo: {ex.Message}"

            InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Positions", "ERROR_INSERT_POSITION", descError, 0, "ERROR", ex.StackTrace)

            MessageBox.Show("Ocurrió un error inesperado al registrar la posición: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class