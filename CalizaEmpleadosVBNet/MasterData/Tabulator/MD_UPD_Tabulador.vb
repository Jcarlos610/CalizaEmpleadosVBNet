Public Class MD_UPD_Tabulador

    Private currentTabId As Integer = 0

    Private Sub MD_UPD_Tabulador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            DGV_Tabulator.Columns("PRICEINCREASE").HeaderText = "Incremento 3%"

            DGV_Tabulator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
    End Sub

    Private Sub DGV_Tabulator_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Tabulator.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_Tabulator.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Tabulator.Rows(hit.RowIndex)

                currentTabId = Convert.ToInt32(row.Cells("TABID").Value)

                Dim cusCode As String = row.Cells("CUSCODE").Value.ToString().Trim()
                Dim shipId As String = ""
                If Not IsDBNull(row.Cells("SHIPID").Value) Then
                    shipId = row.Cells("SHIPID").Value.ToString().Trim()
                End If
                Dim price As Decimal = CDec(row.Cells("PRICE").Value)

                F_SelectComboItem(CB_CustomerList, cusCode)

                If shipId <> "" Then
                    F_SelectComboItem(CB_LocationList, shipId)
                Else
                    CB_LocationList.SelectedIndex = -1
                End If

                TB_Price.Text = price.ToString("0.00")

            Catch ex As Exception
                MsgBox("Error al seleccionar el registro del tabulador: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
            End Try
        End If
    End Sub

    Private Sub F_SelectComboItem(combo As ComboBox, code As String)
        For i As Integer = 0 To combo.Items.Count - 1
            If combo.Items(i).ToString().StartsWith(code) Then
                combo.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub CB_CustomerList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerList.SelectedIndexChanged
        If CB_CustomerList.SelectedIndex = -1 Then Exit Sub

        Dim payment As New CL_TruckDriverPayment()
        Dim cusCode As String = CB_CustomerList.Text.Substring(0, 10)
        Dim location_table As DataTable = payment.ReadOnlyLocationsForCustomer(cusCode)

        CB_LocationList.Items.Clear()
        CB_LocationList.Text = ""
        For Each locRow As DataRow In location_table.Rows
            CB_LocationList.Items.Add(locRow(2).ToString & " - " & locRow(3).ToString & " - " & locRow(4).ToString)
        Next
        CB_LocationList.Enabled = True
    End Sub

    Private Sub TB_Price_TextChanged(sender As Object, e As EventArgs) Handles TB_Price.TextChanged
        Dim price As Decimal
        If Decimal.TryParse(TB_Price.Text, price) Then
            Dim increase As Decimal = Math.Round(price * 1.03D, 0)
            TB_PriceIncrease.Text = increase.ToString("C0")
        Else
            TB_PriceIncrease.Text = ""
        End If
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        If currentTabId = 0 Then
            MessageBox.Show("Selecciona un registro de la tabla para editar.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If CB_CustomerList.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un cliente.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(TB_Price.Text, price) Then
            MessageBox.Show("Verifica el precio.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim priceIncrease As Decimal = Math.Round(price * 1.03D, 0)

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
            If tab.UpdateTabulator(currentTabId, cusCode, cusName, shipId, shipName, price, priceIncrease) Then
                MessageBox.Show("Tabulador actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                F_Load_Tabulator()
                F_ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub F_ClearForm()
        currentTabId = 0
        CB_CustomerList.SelectedIndex = -1
        CB_LocationList.Items.Clear()
        CB_LocationList.Enabled = False
        TB_Price.Text = ""
        TB_PriceIncrease.Text = ""
    End Sub

End Class