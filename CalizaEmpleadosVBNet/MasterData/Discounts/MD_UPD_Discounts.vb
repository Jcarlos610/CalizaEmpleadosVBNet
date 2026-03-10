Public Class MD_UPD_Discounts
    Private Sub MD_UPD_Discounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()

        Dim report As New CL_Discounts()

        CB_AllDiscounts.DataSource = report.Get_ListOfDiscounts
        CB_AllDiscounts.DisplayMember = "Nombre"
        CB_AllDiscounts.ValueMember = "Id"
        CB_AllDiscounts.SelectedIndex = 0

        CB_Type.Items.Clear()
        CB_Type.Items.Add(New ComboItem With {.Id = 10, .Descripcion = "Seleccione uno"})
        CB_Type.Items.Add(New ComboItem With {.Id = 20, .Descripcion = "Manual"})
        CB_Type.Items.Add(New ComboItem With {.Id = 30, .Descripcion = "Automático"})

        CB_Type.DisplayMember = "Descripcion"
        CB_Type.ValueMember = "Id"
        CB_Type.SelectedIndex = 0

        TB_DiscountName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        TB_Ammount.Text = ""

        CB_Status.Checked = False

        DT_ValidFrom.Value = Date.Today
        DT_ValidTo.Value = Date.Today.AddYears(1)

        Display_Record()

    End Sub

    Private Sub Display_Record()

        Dim report As New CL_Discounts()

        DGV_DiscountsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DiscountsList.AutoResizeColumns()
        DGV_DiscountsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_DiscountsList.DataSource = report.Get_AllDiscounts()

    End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
        If TB_DiscountName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf CB_Type.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de indicar el tipo de descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Favor de indicar quién autoriza el descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf TB_Ammount.Text = "" Then
            MessageBox.Show("Favor de indicar el monto del descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
            Dim Id_Type As Integer = Type.Id


            Dim Discount As New CL_Discounts(CInt(CB_AllDiscounts.SelectedValue), TB_DiscountName.Text, TB_Description.Text, Id_Type, Date.Now, TB_Ammount.Text, AppUser, TB_AuthorizeBy.Text, DT_ValidFrom.Value, DT_ValidTo.Value, CB_Status.Checked)


            Discount.DISC_STAT = CB_Status.Checked

            If AppUser IsNot Nothing Then
                If Discount.UpdateDiscount() Then
                    MessageBox.Show("El descuento " + TB_DiscountName.Text + " fue actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If
            Else
                MessageBox.Show("No se actualizó el descuento debido a que no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    Private Sub CB_AllDiscounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllDiscounts.SelectedIndexChanged
        ' Evita ejecución durante la carga del DataSource
        If CB_AllDiscounts.SelectedValue Is Nothing Then Exit Sub

        ' Evita DataRowView
        If TypeOf CB_AllDiscounts.SelectedValue IsNot Integer Then Exit Sub

        Dim idDiscount As Integer = CInt(CB_AllDiscounts.SelectedValue)

        Dim Discount As New CL_Discounts
        Dim SelectedDiscount As DataTable = Discount.Get_OneDiscount(idDiscount)

        If SelectedDiscount.Rows.Count = 0 Then Exit Sub

        Dim Item As DataRow = SelectedDiscount.Rows(0)

        TB_DiscountName.Text = Item(1).ToString()
        TB_Description.Text = Item(2).ToString()
        TB_AuthorizeBy.Text = Item(7).ToString()
        TB_Ammount.Text = Item(5).ToString()

        DT_ValidFrom.Value = CDate(Item(8))
        DT_ValidTo.Value = CDate(Item(9))

        CB_Status.Checked = Item(10)


    End Sub

    Private Sub CB_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Type.SelectedIndexChanged
        If CB_Type.SelectedItem IsNot Nothing Then

            Dim item As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
            Dim id As Integer = item.Id

            If id = 30 Then
                MessageBox.Show("Este descuento se asignará automáticamente.")
            End If

        End If
    End Sub
End Class