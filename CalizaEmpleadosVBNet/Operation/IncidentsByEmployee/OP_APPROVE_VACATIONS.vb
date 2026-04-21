Public Class OP_APPROVE_VACATIONS
    Private Sub OP_APPROVE_VACATIONS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVacations()
    End Sub

    Sub LoadVacations()

        Dim obj As New CL_Incidents
        DGV_Vacations.DataSource = obj.GetPendingVacations()
        DGV_Vacations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Vacations.AutoResizeColumns()
        DGV_Vacations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        If DGV_Vacations.Columns.Contains("EMPL_ID") Then
            DGV_Vacations.Columns("EMPL_ID").HeaderText = "No. Empleado"
        End If

        If DGV_Vacations.Columns.Contains("Empleado") Then
            DGV_Vacations.Columns("Empleado").HeaderText = "Nombre completo"
        End If

        If DGV_Vacations.Columns.Contains("FechaInicio") Then
            DGV_Vacations.Columns("FechaInicio").HeaderText = "Fecha inicio"
        End If

        If DGV_Vacations.Columns.Contains("FechaFin") Then
            DGV_Vacations.Columns("FechaFin").HeaderText = "Fecha fin"
        End If

        If DGV_Vacations.Columns.Contains("Dias") Then
            DGV_Vacations.Columns("Dias").HeaderText = "Días solicitados"
        End If

        If DGV_Vacations.Columns.Contains("Comentario") Then
            DGV_Vacations.Columns("Comentario").HeaderText = "Comentarios"
        End If

        If DGV_Vacations.Columns.Contains("AutorizadoPor") Then
            DGV_Vacations.Columns("AutorizadoPor").HeaderText = "Autorizado por"
        End If

        If DGV_Vacations.Columns.Contains("Estado") Then
            DGV_Vacations.Columns("Estado").HeaderText = "Estado"
        End If

        If DGV_Vacations.Columns.Contains("DREMPL_ID") Then
            DGV_Vacations.Columns("DREMPL_ID").Visible = False
        End If

        If DGV_Vacations.Columns.Contains("FechaInicio") Then
            DGV_Vacations.Columns("FechaInicio").DefaultCellStyle.Format = "dd/MM/yyyy"
        End If

        If DGV_Vacations.Columns.Contains("FechaFin") Then
            DGV_Vacations.Columns("FechaFin").DefaultCellStyle.Format = "dd/MM/yyyy"
        End If

        DGV_Vacations.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_Vacations.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If Not DGV_Vacations.Columns.Contains("Aprobar") Then
            Dim btn As New DataGridViewButtonColumn()
            btn.Name = "Aprobar"
            btn.HeaderText = "Acción"
            btn.Text = "Aprobar"
            btn.UseColumnTextForButtonValue = True

            DGV_Vacations.Columns.Add(btn)
        End If

    End Sub

    Private Sub DGV_Vacations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Vacations.CellClick

        If e.RowIndex < 0 Then Exit Sub

        If DGV_Vacations.Columns(e.ColumnIndex).Name = "Aprobar" Then

            Dim id As Integer = CInt(DGV_Vacations.Rows(e.RowIndex).Cells("DREMPL_ID").Value)

            Dim confirm = MessageBox.Show("¿Aprobar vacaciones?", "Confirmar",
                                         MessageBoxButtons.YesNo)

            If confirm = DialogResult.Yes Then

                Dim obj As New CL_Incidents

                If obj.ApproveVacation(id) Then
                    MessageBox.Show("Vacaciones aprobadas")
                    LoadVacations()
                End If

            End If

        End If

    End Sub


End Class