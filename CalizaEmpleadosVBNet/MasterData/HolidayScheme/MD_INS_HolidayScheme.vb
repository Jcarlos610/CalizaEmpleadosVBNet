Public Class MD_INS_HolidayScheme
    Private Sub MD_INS_HolidayScheme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        DGV_HolidaySchema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub CargarSchemes()
        Dim scheme As New CL_HolidayScheme()
        DGV_HolidaySchema.DataSource = scheme.Get_AllSchemes()
    End Sub

    Private Sub BT_Registrar_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
            If TB_SchemeName.Text.Trim = "" Then
                MessageBox.Show("Ingresa el nombre del esquema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim scheme As New CL_HolidayScheme()
            scheme.SCHM_NAME = TB_SchemeName.Text.Trim
            scheme.SCHM_DESCR = TB_Description.Text.Trim
            scheme.SCHM_CREBY = GlobalSession.GlobalUserName
            scheme.SCHM_PAYSBONOS = CB_PaysBonos.Checked
            Dim resultado = scheme.InsertScheme()

            If resultado Then
                MessageBox.Show("Esquema registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TB_SchemeName.Clear()
                TB_Description.Clear()
                CargarSchemes()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error en BT_Registrar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class