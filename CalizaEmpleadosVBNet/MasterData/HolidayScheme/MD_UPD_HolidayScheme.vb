Public Class MD_UPD_HolidayScheme

    Private SCHM_ID As Integer

    Private Sub MD_UPD_HolidayScheme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarGrid()
        CargarSchemes()
    End Sub

    Private Sub ConfigurarGrid()
        DGV_HolidaySchema.AutoGenerateColumns = False
        DGV_HolidaySchema.Columns.Clear()

        DGV_HolidaySchema.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "SCHM_ID", .DataPropertyName = "SCHM_ID", .Visible = False})
        DGV_HolidaySchema.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "SCHM_NAME", .DataPropertyName = "SCHM_NAME", .HeaderText = "Nombre"})
        DGV_HolidaySchema.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "SCHM_DESCR", .DataPropertyName = "SCHM_DESCR", .HeaderText = "Descripción"})
        DGV_HolidaySchema.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "SCHM_PAYSBONOS", .DataPropertyName = "SCHM_PAYSBONOS", .Visible = False})

        DGV_HolidaySchema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub CargarSchemes()
        Dim scheme As New CL_HolidayScheme()
        DGV_HolidaySchema.DataSource = scheme.Get_AllSchemes()
    End Sub

    Private Sub DGV_HolidaySchema_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_HolidaySchema.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_HolidaySchema.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim fila As DataGridViewRow = DGV_HolidaySchema.Rows(hit.RowIndex)

                SCHM_ID = Convert.ToInt32(fila.Cells("SCHM_ID").Value)
                TB_SchemeName.Text = fila.Cells("SCHM_NAME").Value.ToString()
                TB_Description.Text = If(fila.Cells("SCHM_DESCR").Value Is DBNull.Value, "", fila.Cells("SCHM_DESCR").Value.ToString())
                CB_PaysBonos.Checked = Convert.ToBoolean(fila.Cells("SCHM_PAYSBONOS").Value)
            Catch ex As Exception
                MsgBox("Error al seleccionar el registro del esquema: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
            End Try
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        Try
            If SCHM_ID = 0 Then
                MessageBox.Show("Selecciona un esquema del listado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim scheme As New CL_HolidayScheme()
            scheme.SCHM_ID = SCHM_ID
            scheme.SCHM_NAME = TB_SchemeName.Text.Trim
            scheme.SCHM_DESCR = TB_Description.Text.Trim
            scheme.SCHM_PAYSBONOS = CB_PaysBonos.Checked
            Dim resultado = scheme.UpdateScheme()

            If resultado Then
                MessageBox.Show("Esquema actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TB_SchemeName.Clear()
                TB_Description.Clear()
                SCHM_ID = 0
                CargarSchemes()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error en BT_Update_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class