Public Class MD_UPD_Holiday

    Private HOL_ID As Integer

    Private Sub MD_UPD_Holiday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEsquemas()
        ConfigurarGrid()
        CargarHolidays()
    End Sub

    Private Sub CargarEsquemas()
        Dim scheme As New CL_HolidayScheme()
        Dim dt As DataTable = scheme.Get_AllSchemes()

        Dim filaVacia As DataRow = dt.NewRow()
        filaVacia("SCHM_ID") = 0
        filaVacia("SCHM_NAME") = "Elija un esquema"
        filaVacia("SCHM_DESCR") = ""
        filaVacia("SCHM_DATEC") = DateTime.Now
        filaVacia("SCHM_CREBY") = ""
        filaVacia("SCHM_PAYSBONOS") = True
        dt.Rows.InsertAt(filaVacia, 0)

        CB_Scheme.DataSource = dt
        CB_Scheme.DisplayMember = "SCHM_NAME"
        CB_Scheme.ValueMember = "SCHM_ID"
        CB_Scheme.SelectedIndex = 0

        HOL_ID = 0
        DTP_Date.Value = Date.Today
        CB_Status.Checked = False
    End Sub

    Private Sub ConfigurarGrid()
        DGV_Holiday.AutoGenerateColumns = False
        DGV_Holiday.Columns.Clear()

        DGV_Holiday.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "HOL_ID", .DataPropertyName = "HOL_ID", .Visible = False})
        DGV_Holiday.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "HOL_DATE", .DataPropertyName = "HOL_DATE", .HeaderText = "Fecha"})
        DGV_Holiday.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "HOL_SCHMID", .DataPropertyName = "HOL_SCHMID", .Visible = False})
        DGV_Holiday.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "SCHM_NAME", .DataPropertyName = "SCHM_NAME", .HeaderText = "Esquema"})
        DGV_Holiday.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "HOL_STAT", .DataPropertyName = "HOL_STAT", .HeaderText = "Activo"})

        DGV_Holiday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub CargarHolidays()
        Dim holiday As New CL_Holiday()
        DGV_Holiday.DataSource = holiday.Get_AllHolidays()
    End Sub

    Private Sub DGV_Holiday_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Holiday.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_Holiday.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim fila As DataGridViewRow = DGV_Holiday.Rows(hit.RowIndex)

                HOL_ID = Convert.ToInt32(fila.Cells("HOL_ID").Value)
                DTP_Date.Value = Convert.ToDateTime(fila.Cells("HOL_DATE").Value)
                CB_Scheme.SelectedValue = Convert.ToInt32(fila.Cells("HOL_SCHMID").Value)
                CB_Status.Checked = Convert.ToBoolean(fila.Cells("HOL_STAT").Value)
            Catch ex As Exception
                MsgBox("Error al seleccionar el registro del festivo: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
            End Try
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        Try
            If HOL_ID = 0 Then
                MessageBox.Show("Selecciona un festivo del listado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim holiday As New CL_Holiday()
            Dim resultado = holiday.UpdateHoliday(HOL_ID, DTP_Date.Value.Date, CB_Scheme.SelectedValue, CB_Status.Checked)

            If resultado Then
                MessageBox.Show("Día festivo actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                HOL_ID = 0
                DTP_Date.Value = Date.Today
                CB_Scheme.SelectedIndex = -1
                CB_Status.Checked = False
                CargarHolidays()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error en BT_Update_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DGV_Holiday_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Holiday.CellFormatting
        If DGV_Holiday.Columns(e.ColumnIndex).Name = "HOL_STAT" AndAlso e.Value IsNot Nothing Then
            e.Value = If(Convert.ToBoolean(e.Value), "Activo", "Inactivo")
            e.FormattingApplied = True
        End If
    End Sub
End Class