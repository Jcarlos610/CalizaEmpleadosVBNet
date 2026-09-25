Public Class MD_INS_Holiday
    Private Sub MD_INS_Holiday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub ConfigurarGrid()
        DGV_Holiday.AutoGenerateColumns = False
        DGV_Holiday.Columns.Clear()

        DGV_Holiday.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "HOL_DATE", .DataPropertyName = "HOL_DATE", .HeaderText = "Fecha"})
        DGV_Holiday.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "SCHM_NAME", .DataPropertyName = "SCHM_NAME", .HeaderText = "Esquema"})


        DGV_Holiday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub CargarHolidays()
        Dim holiday As New CL_Holiday()
        DGV_Holiday.DataSource = holiday.Get_AllHolidays()
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
            If CB_Scheme.SelectedValue Is Nothing OrElse Convert.ToInt32(CB_Scheme.SelectedValue) = 0 Then
                MessageBox.Show("Selecciona un esquema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim holiday As New CL_Holiday(DTP_Date.Value.Date, CB_Scheme.SelectedValue, Nothing, GlobalSession.GlobalUserName, True)
            Dim resultado = holiday.InsertHoliday()

            If resultado Then
                MessageBox.Show("Día festivo registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DTP_Date.Value = Date.Today
                CargarEsquemas()
                CargarHolidays()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error en BT_Register_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class