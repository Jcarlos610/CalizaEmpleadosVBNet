Imports System.IO
Imports System.Text
Imports System.Diagnostics

Public Class OP_PayrollDispersion
    Private Sub OP_PayrollDispersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CL As New CL_Payroll
        Dim dt As DataTable = CL.GetApprovedWeeks()

        Dim filaVacia As DataRow = dt.NewRow()
        filaVacia("StartDate") = DBNull.Value
        filaVacia("EndDate") = DBNull.Value
        filaVacia("Semana") = "Seleccione la fecha de nómina"
        dt.Rows.InsertAt(filaVacia, 0)

        If dt.Rows.Count = 1 Then
            MessageBox.Show("No hay semanas de nómina aprobadas disponibles para dispersión.", "Sin semanas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        CB_BatchID.DisplayMember = "Semana"
        CB_BatchID.ValueMember = "StartDate"
        LB_TotalRegistros.Text = "Total de registros: 0"
        LB_Amount.Text = "Monto a transferir: $0.00"
        CB_BatchID.DataSource = dt
        CB_BatchID.SelectedIndex = 0
    End Sub

    Private Sub CB_BatchID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_BatchID.SelectedIndexChanged
        If CB_BatchID.SelectedItem Is Nothing Then Exit Sub

        Dim rowView As DataRowView = DirectCast(CB_BatchID.SelectedItem, DataRowView)

        If IsDBNull(rowView("StartDate")) Then
            DGV_Dispersion.DataSource = Nothing
            LB_TotalRegistros.Text = "Total de registros: 0"
            LB_Amount.Text = "Monto a transferir: $0.00"
            Exit Sub
        End If

        Dim startDate As Date = CDate(rowView("StartDate"))
        Dim endDate As Date = CDate(rowView("EndDate"))

        Dim CL As New CL_Payroll
        Dim dt As DataTable = CL.GetDispersionByWeek(startDate, endDate)

        DGV_Dispersion.AutoGenerateColumns = True
        DGV_Dispersion.DataSource = dt

        AplicarEncabezadosDispersion()

        LB_TotalRegistros.Text = "Total de registros: " & dt.Rows.Count.ToString()

        If dt.Rows.Count = 0 Then
            LB_Amount.Text = "Monto a transferir: $0.00"
        Else
            Dim totalTransferir As Decimal = Convert.ToDecimal(dt.Compute("SUM(TransferAmount)", String.Empty))
            LB_Amount.Text = "Monto a transferir: " & totalTransferir.ToString("C2")
        End If
    End Sub

    Private Sub AplicarEncabezadosDispersion()
        Dim nombres As New Dictionary(Of String, String) From {
            {"BankAccount", "Cuenta"},
            {"FullName", "Nombre"},
            {"TransferAmount", "Monto a Transferir"}
        }

        For Each col As DataGridViewColumn In DGV_Dispersion.Columns
            If col.Name = "EmployeeID" Then
                col.Visible = False
            ElseIf nombres.ContainsKey(col.Name) Then
                col.HeaderText = nombres(col.Name)
            End If
        Next
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If CB_BatchID.SelectedItem Is Nothing Then
            MessageBox.Show("Selecciona una semana antes de generar el archivo.", "Falta semana", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim rowView As DataRowView = DirectCast(CB_BatchID.SelectedItem, DataRowView)
        Dim startDate As Date = CDate(rowView("StartDate"))
        Dim endDate As Date = CDate(rowView("EndDate"))

        Dim CL As New CL_Payroll
        Dim dt As DataTable = CL.GetDispersionByWeek(startDate, endDate)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No hay registros para esta semana.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        PB_Progress.Minimum = 0
        PB_Progress.Maximum = dt.Rows.Count
        PB_Progress.Value = 0
        LB_Estado.Text = "Generando archivo..."

        Dim sb As New StringBuilder()
        Dim consecutivo As Integer = 1

        For Each row As DataRow In dt.Rows
            Dim secuencia As String = consecutivo.ToString().PadLeft(9, "0"c)
            Dim relleno1 As String = New String(" "c, 16)
            Dim cuenta As String = "99" & row("BankAccount").ToString().Trim().PadLeft(10, "0"c)
            Dim relleno2 As String = New String(" "c, 10)
            Dim centavos As Long = CLng(Math.Round(CDec(row("TransferAmount")) * 100))
            Dim importe As String = centavos.ToString().PadLeft(15, "0"c)
            Dim nombre As String = CL_Payroll.LimpiarTexto(row("FullName").ToString()).PadRight(40).Substring(0, 40)
            Dim constante As String = "001001"

            sb.Append(secuencia & relleno1 & cuenta & relleno2 & importe & nombre & constante)
            sb.AppendLine()

            consecutivo += 1

            PB_Progress.Value = consecutivo - 1
            LB_Estado.Text = $"Procesando {consecutivo - 1} de {dt.Rows.Count}..."
            Application.DoEvents()
        Next

        Dim nombreArchivo As String = $"Dispersion_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.txt"
        Dim rutaCompleta As String = Path.Combine(My.Settings.DispersionOutputPath, nombreArchivo)

        If File.Exists(rutaCompleta) Then
            Dim confirmacion = MessageBox.Show(
        $"Ya existe un archivo de dispersión para esta semana:{vbCrLf}{rutaCompleta}{vbCrLf}{vbCrLf}¿Quieres sobrescribirlo?",
        "Archivo existente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.No Then
                LB_Estado.Text = "Generación cancelada."
                Exit Sub
            End If
        End If

        File.WriteAllText(rutaCompleta, sb.ToString(), Encoding.ASCII)

        LB_Estado.Text = "Archivo generado correctamente."
        PB_Progress.Value = PB_Progress.Maximum

        MessageBox.Show($"Archivo generado correctamente:{vbCrLf}{rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Process.Start("explorer.exe", $"/select,""{rutaCompleta}""")
    End Sub
End Class