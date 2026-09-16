Public Class OP_INS_TruckDriverSale

    Dim SelectedEmplID As Integer
    Dim SelectedSaleID As Integer
    Dim SelectedShipCode As String
    Dim SelectedPrice As Decimal
    Dim SelectedQuantity As Decimal

    Private Sub OP_INS_TruckDriverSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub CB_CustomerList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerList.SelectedIndexChanged
        If CB_CustomerList.SelectedIndex = -1 Then Exit Sub

        Dim payment As New CL_TruckDriverPayment()
        Dim cusCode As String = CB_CustomerList.Text.Substring(0, 10)
        Dim location_table As DataTable = payment.ReadOnlyLocationsForCustomer(cusCode)

        CB_LocationList.Items.Clear()
        For Each row As DataRow In location_table.Rows
            CB_LocationList.Items.Add(row(2).ToString & " - " & row(3).ToString & " - " & row(4).ToString)
        Next
        CB_LocationList.Enabled = True
    End Sub

    Private Sub F_Load_Tabulator()
        Dim tab As New CL_Tabulator()
        DGV_Tabulator.DataSource = tab.GetTabulator()

        DGV_Tabulator.Columns("TABID").Visible = False
        DGV_Tabulator.Columns("CUSCODE").Visible = False
        DGV_Tabulator.Columns("CUSNAME").HeaderText = "Cliente"
        DGV_Tabulator.Columns("PRICE").HeaderText = "Precio"
        DGV_Tabulator.Columns("PRICEINCREASE").HeaderText = "Incremento 3%"

        DGV_Tabulator.Columns("PRICE").DefaultCellStyle.Format = "C2"
        DGV_Tabulator.Columns("PRICEINCREASE").DefaultCellStyle.Format = "C2"

        DGV_Tabulator.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub



    Private Sub CB_LocationList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_LocationList.SelectedIndexChanged
        If CB_LocationList.SelectedIndex = -1 Then Exit Sub

        Dim payment As New CL_TruckDriverPayment()
        Dim cusCode As String = CB_CustomerList.Text.Substring(0, 10)
        Dim shipId As String = CB_LocationList.Text.Substring(0, 10)

        Dim sales_table As DataTable = payment.GetSalesByCustomerAndLocation(cusCode, shipId)
        DGV_Sales.DataSource = sales_table

        If sales_table.Rows.Count > 0 Then
            DGV_Sales.Columns("SALEID").HeaderText = "Folio"
            DGV_Sales.Columns("DOCID").HeaderText = "Documento"
            DGV_Sales.Columns("DNAME").HeaderText = "Chofer"
            DGV_Sales.Columns("TRUCKN").HeaderText = "Camión"
            DGV_Sales.Columns("TOTALAM").HeaderText = "Monto"
            DGV_Sales.Columns("POSDATE").HeaderText = "Fecha"

            DGV_Sales.Columns("TOTALAM").DefaultCellStyle.Format = "C2"

            DGV_Sales.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End If
    End Sub

    Private Sub DGV_Tabulator_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Tabulator.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_Tabulator.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Tabulator.Rows(hit.RowIndex)
                SelectedPrice = Convert.ToDecimal(row.Cells("PRICE").Value)
                CalcularMonto()
            Catch ex As Exception
                MsgBox("Error al seleccionar el precio: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub DGV_Sales_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Sales.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_Sales.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Sales.Rows(hit.RowIndex)

                SelectedSaleID = Convert.ToInt32(row.Cells("SALEID").Value)
                SelectedShipCode = CB_LocationList.Text.Substring(0, 10)
                SelectedQuantity = Convert.ToDecimal(row.Cells("Cantidad").Value)

                CalcularMonto()
            Catch ex As Exception
                MsgBox("Error al seleccionar el viaje: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub CalcularMonto()
        If SelectedPrice > 0 AndAlso SelectedQuantity > 0 Then
            LB_Amount.Text = "Monto a pagar: " & (SelectedQuantity * SelectedPrice).ToString("C2")
        Else
            LB_Amount.Text = "Monto a pagar: $0.00"
        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If SelectedEmplID = 0 Then
            MessageBox.Show("Selecciona un empleado.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If SelectedSaleID = 0 OrElse SelectedPrice = 0 Then
            MessageBox.Show("Selecciona un viaje y un precio del tabulador.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim payment As New CL_TruckDriverPayment(
            SelectedEmplID, SelectedSaleID, SelectedQuantity,
            CB_CustomerList.Text.Substring(0, 10), SelectedShipCode,
            DGV_Sales.CurrentRow.Cells("DOCID").Value.ToString(),
            SelectedQuantity * SelectedPrice, Convert.ToDateTime(DGV_Sales.CurrentRow.Cells("POSDATE").Value),
            0, DBNull.Value)

            If payment.InsertPayment() Then
                MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se pudo registrar el pago. Revisa los datos e intenta de nuevo.", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al registrar el pago: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TB_Employee_TextChanged(sender As Object, e As EventArgs) Handles TB_Employee.TextChanged
        If TB_Employee.Text.Trim.Length > 1 Then
            Dim CL As New CL_RecordByEmployeeHoursAbsence
            Dim dt = CL.GetEmployeeSuggestions(AppUser, TB_Employee.Text.Trim)

            If dt.Rows.Count > 0 Then
                LBX_Suggesting.DataSource = dt
                LBX_Suggesting.DisplayMember = "FullName"
                LBX_Suggesting.ValueMember = "EMPL_ID"
                LBX_Suggesting.Visible = True
            Else
                LBX_Suggesting.Visible = False
            End If
        Else
            LBX_Suggesting.Visible = False
        End If
    End Sub

    Private Sub LBX_Suggesting_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBX_Suggesting.SelectedIndexChanged
        If LBX_Suggesting.SelectedValue IsNot Nothing AndAlso Not TypeOf LBX_Suggesting.SelectedValue Is DataRowView Then
            Try
                SelectedEmplID = Convert.ToInt32(LBX_Suggesting.SelectedValue)
                TB_EmployeeId.Text = SelectedEmplID.ToString()

                Dim selectedText As String = ""
                If TypeOf LBX_Suggesting.SelectedItem Is DataRowView Then
                    Dim row As DataRowView = CType(LBX_Suggesting.SelectedItem, DataRowView)
                    selectedText = row("FullName").ToString()
                Else
                    selectedText = LBX_Suggesting.Text
                End If

                Dim values As String() = selectedText.Split("-")
                TB_EmployeeName.Text = If(values.Length > 1, values(1).Trim(), selectedText.Trim())

                LBX_Suggesting.Visible = False
            Catch ex As Exception
                Console.WriteLine("Error temporal de casteo: " & ex.Message)
            End Try
        End If
    End Sub
End Class