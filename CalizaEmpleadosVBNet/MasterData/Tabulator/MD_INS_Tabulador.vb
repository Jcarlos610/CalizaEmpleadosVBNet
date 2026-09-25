Public Class MD_INS_Tabulador
    Private Sub MD_INS_Tabulador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        F_Get_Customers()
        F_Load_Tabulator()
    End Sub

    Private Sub F_Get_Customers()
        Dim payment As New CL_TruckDriverPayment()
        Dim customer_table As DataTable = payment.ReadOnlyCustomers()

        CB_CustomerList.Items.Clear()
        CB_CustomerList.Text = ""
        CB_LocationList.Items.Clear()
        CB_LocationList.Text = ""
        CB_LocationList.Enabled = False

        For Each row As DataRow In customer_table.Rows
            CB_CustomerList.Items.Add(row(3).ToString & " - " & row(4).ToString)
        Next
    End Sub

    Private Sub F_Load_Tabulator()
        Dim tab As New CL_Tabulator()
        Dim tabulator_table As DataTable = tab.GetTabulator()
        DGV_Tabulator.DataSource = tabulator_table

        If tabulator_table.Rows.Count > 0 Then
            DGV_Tabulator.Columns("TABID").Visible = False
            DGV_Tabulator.Columns("CUSCODE").HeaderText = "Código"
            DGV_Tabulator.Columns("CUSNAME").HeaderText = "Cliente"
            DGV_Tabulator.Columns("SHIPID").HeaderText = "Cód. Sucursal"
            DGV_Tabulator.Columns("SHIPNAME").HeaderText = "Sucursal"
            DGV_Tabulator.Columns("PRICE").HeaderText = "Precio"
            DGV_Tabulator.Columns("PERCENTAGE").HeaderText = "% Incremento"
            DGV_Tabulator.Columns("PRICEINCREASE").HeaderText = "Monto a Pagar"

            DGV_Tabulator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
    End Sub

    Private Sub CB_CustomerList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerList.SelectedIndexChanged
        If CB_CustomerList.SelectedIndex = -1 Then Exit Sub

        Dim payment As New CL_TruckDriverPayment()
        Dim cusCode As String = CB_CustomerList.Text.Substring(0, 10)
        Dim location_table As DataTable = payment.ReadOnlyLocationsForCustomer(cusCode)

        CB_LocationList.Items.Clear()
        CB_LocationList.Text = ""
        For Each row As DataRow In location_table.Rows
            CB_LocationList.Items.Add(row(2).ToString & " - " & row(3).ToString & " - " & row(4).ToString)
        Next
        CB_LocationList.Enabled = True
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If CB_CustomerList.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un cliente.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(TB_Price.Text, price) Then
            MessageBox.Show("Verifica el precio.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim percentage As Object = Nothing
        Dim percentValue As Decimal
        If TB_Percentage.Text.Trim() <> "" AndAlso Decimal.TryParse(TB_Percentage.Text, percentValue) Then
            percentage = percentValue
        End If

        Dim priceIncrease As Decimal
        If percentage Is Nothing Then
            priceIncrease = price
        Else
            priceIncrease = Math.Round(price * (1 + percentValue / 100D), 0)
        End If

        Dim cusCode As String = CB_CustomerList.Text.Substring(0, 10)
        Dim cusName As String = CB_CustomerList.Text.Substring(13)

        Dim shipId As Object = Nothing
        Dim shipName As Object = Nothing
        If CB_LocationList.SelectedIndex <> -1 Then
            shipId = CB_LocationList.Text.Substring(0, 10)
            shipName = CB_LocationList.Text.Substring(13)
        End If

        Try
            Dim tab As New CL_Tabulator()
            If tab.InsertTabulator(cusCode, cusName, shipId, shipName, price, percentage, priceIncrease) Then
                MessageBox.Show("Tabulador guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                F_Load_Tabulator()
                TB_Price.Text = ""
                TB_Percentage.Text = ""
                TB_PriceIncrease.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TB_Price_TextChanged(sender As Object, e As EventArgs) Handles TB_Price.TextChanged
        'Dim price As Decimal
        'If Decimal.TryParse(TB_Price.Text, price) Then
        '    Dim increase As Decimal = Math.Round(price * 1.03D, 0)
        '    TB_PriceIncrease.Text = increase.ToString("C0")
        'Else
        '    TB_PriceIncrease.Text = ""
        'End If
        RecalculatePriceIncrease()
    End Sub

    Private Sub RecalculatePriceIncrease()
        Dim price As Decimal
        If Not Decimal.TryParse(TB_Price.Text, price) Then
            TB_PriceIncrease.Text = ""
            Return
        End If

        Dim percentText As String = TB_Percentage.Text.Trim()

        If percentText = "" Then
            ' Sin porcentaje: se queda el precio normal
            TB_PriceIncrease.Text = price.ToString("C0")
        Else
            Dim percent As Decimal
            If Decimal.TryParse(percentText, percent) Then
                Dim finalAmount As Decimal = Math.Round(price * (1 + percent / 100D), 0)
                TB_PriceIncrease.Text = finalAmount.ToString("C0")
            Else
                TB_PriceIncrease.Text = ""
            End If
        End If
    End Sub

    Private Sub TB_Percentage_TextChanged(sender As Object, e As EventArgs) Handles TB_Percentage.TextChanged
        RecalculatePriceIncrease()
    End Sub
End Class