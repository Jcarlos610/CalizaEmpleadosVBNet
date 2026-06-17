Imports Microsoft.Data.SqlClient

Public Class MD_INS_Discounts
    Private Sub MD_INS_Discounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()
        Dim report As New CL_Banns()

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

        DT_ValidFrom.Value = Date.Today
        DT_ValidTo.Value = Date.Today.AddYears(1)

        Display_Record()
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Discounts()
        DGV_DiscountsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_DiscountsList.AutoResizeColumns()
        DGV_DiscountsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_DiscountsList.DataSource = report.Get_AllDiscounts
    End Sub

    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
    '    If TB_DiscountName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar un nombre del descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    ElseIf CType(CB_Type.SelectedItem, ComboItem).Id = 10 Then
    '        MessageBox.Show("Debes seleccionar un tipo de descuento válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza el descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Ammount.Text = "" Then
    '        MessageBox.Show("Favor de indicar el monto asignado para este descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else

    '        Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
    '        Dim Id_Type As Integer = Type.Id

    '        Dim Discount As New CL_Discounts(
    '            TB_DiscountName.Text,
    '            TB_Description.Text,
    '            Id_Type,
    '            Date.Now,
    '            TB_Ammount.Text,
    '            AppUser,
    '            TB_AuthorizeBy.Text,
    '            DT_ValidFrom.Value,
    '            DT_ValidTo.Value,
    '            1
    '        )

    '        If Discount.InsertDiscount() Then
    '            MessageBox.Show("El descuento " + TB_DiscountName.Text + " fue ingresado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            InitializationOfFields()
    '        End If


    '    End If
    'End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
            If TB_DiscountName.Text.Trim() = "" Then
                MessageBox.Show("Favor de ingresar un nombre del descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf TB_Description.Text.Trim() = "" Then
                MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf CB_Type.SelectedItem Is Nothing Then
                MessageBox.Show("Debes seleccionar un tipo de descuento de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf CType(CB_Type.SelectedItem, ComboItem).Id = 10 Then
                MessageBox.Show("Debes seleccionar un tipo de descuento válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf TB_AuthorizeBy.Text.Trim() = "" Then
                MessageBox.Show("Favor de indicar quién autoriza el descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf TB_Ammount.Text.Trim() = "" Then
                MessageBox.Show("Favor de indicar el monto asignado para este descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
                Dim Id_Type As Integer = Type.Id

                Dim Discount As New CL_Discounts(
                TB_DiscountName.Text,
                TB_Description.Text,
                Id_Type,
                Date.Now,
                TB_Ammount.Text,
                AppUser,
                TB_AuthorizeBy.Text,
                DT_ValidFrom.Value,
                DT_ValidTo.Value,
                1
            )

                If Discount.InsertDiscount() Then
                    'LOG 
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"REGISTRO DESCUENTO EXITOSO: El usuario '{GlobalSession.GlobalUserName}' creó el descuento: '{TB_DiscountName.Text.Trim()}' (Tipo ID: {Id_Type}) | " &
                                            $"Monto: {TB_Ammount.Text.Trim()} | Autorizado Por: '{TB_AuthorizeBy.Text.Trim()}' | " &
                                            $"Vigencia: {DT_ValidFrom.Value:dd/MM/yyyy} al {DT_ValidTo.Value:dd/MM/yyyy} | " &
                                            $"Descripción: '{TB_Description.Text.Trim()}'."

                        InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Discounts", "INSERT_DISCOUNT_SUCCESS", descLog, 0, "INFO")
                    End Using

                    MessageBox.Show("El descuento " + TB_DiscountName.Text + " fue ingresado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO AL INSERTAR DESCUENTO: Falló la operación de registro para '{TB_DiscountName.Text.Trim()}'. Motivo: {ex.Message} en Form_Discounts.BT_Register_Click()"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Discounts", "INSERT_DISCOUNT_ERROR", descError, 0, "ERROR", ex.StackTrace)
            End Using

            MessageBox.Show("Ocurrió un error inesperado al intentar registrar el descuento. El detalle ha sido guardado en la bitácora.", "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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