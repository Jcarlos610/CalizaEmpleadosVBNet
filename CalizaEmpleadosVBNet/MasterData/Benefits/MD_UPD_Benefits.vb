Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MD_UPD_Benefits

    Private Sub MD_UPD_Benefits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub




    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click
        Try
            If AppUser Is Nothing OrElse AppUser.Trim() = "" Then
                MsgBox("No se puede actualizar el beneficio debido a que no hay un usuario con sesión activa.", MsgBoxStyle.Critical, "Acceso Denegado")
                Exit Sub
            End If

            If TB_BenefitName.Text.Trim() = "" Then
                MsgBox("Por favor, ingrese el nombre del beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
                TB_BenefitName.Focus()
                Exit Sub
            ElseIf TB_Description.Text.Trim() = "" Then
                MsgBox("Por favor, ingrese una descripción para el beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
                TB_Description.Focus()
                Exit Sub
            ElseIf CB_Type.SelectedItem Is Nothing Then
                MsgBox("Por favor, seleccione el tipo de beneficio de la lista.", MsgBoxStyle.Exclamation, "Falta Información")
                CB_Type.Focus()
                Exit Sub
            ElseIf TB_AuthorizeBy.Text.Trim() = "" Then
                MsgBox("Por favor, indique quién autoriza este beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
                TB_AuthorizeBy.Focus()
                Exit Sub
            ElseIf TB_Ammount.Text.Trim() <> "" AndAlso TB_Percent.Text.Trim() <> "" Then
                MsgBox("Operación inválida: Solo puede ingresar un Monto fijo o un Porcentaje, no ambos.", MsgBoxStyle.Critical, "Error de Configuración")
                Return
            ElseIf TB_Ammount.Text.Trim() = "" AndAlso TB_Percent.Text.Trim() = "" Then
                MsgBox("Por favor, debe ingresar un Monto monetario o un Porcentaje de beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
                Return
            ElseIf DT_ValidTo.Value.Date < DT_ValidFrom.Value.Date Then
                MsgBox("La fecha de término del beneficio no puede ser menor a la fecha de inicio.", MsgBoxStyle.Exclamation, "Fechas Inválidas")
                Return
            End If

            Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
            Dim Id_Type As Integer = Type.Id

            Dim Benefit = New CL_Benefits(CInt(CB_AllBenefits.SelectedValue),
                                          TB_BenefitName.Text,
                                          TB_Description.Text,
                                          Id_Type,
                                          Date.Now,
                                          AppUser,
                                          TB_AuthorizeBy.Text,
                                          TB_Ammount.Text,
                                          1,
                                          DT_ValidFrom.Value,
                                          DT_ValidTo.Value,
                                          TB_Percent.Text)

            Benefit.BENEF_STAT = CB_Status.Checked

            If Benefit.UpdateBenefit() Then
                MsgBox("¡El beneficio '" & TB_BenefitName.Text.Trim() & "' ha sido actualizado correctamente!", MsgBoxStyle.Information, "Actualización Exitosa")
                InitializationOfFields()
            Else
                MsgBox("El beneficio no pudo ser actualizado. Verifique las reglas o restricciones de la base de datos.", MsgBoxStyle.Critical, "Error al Actualizar")
            End If

        Catch ex As Exception
            MsgBox("Ocurrió un error crítico inesperado al intentar actualizar el beneficio: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Benefits()
        DGV_BenefitsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_BenefitsList.AutoResizeColumns()
        DGV_BenefitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_BenefitsList.DataSource = report.Get_AllBenefits
    End Sub


    Private Sub CB_AllBenefits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllBenefits.SelectedIndexChanged

        If CB_AllBenefits.SelectedValue Is Nothing Then Exit Sub

        If TypeOf CB_AllBenefits.SelectedValue IsNot Integer Then Exit Sub

        Dim idBenefit As Integer = CInt(CB_AllBenefits.SelectedValue)

        Dim Benefit As New CL_Benefits
        Dim SelectedBenefit As DataTable = Benefit.Get_OneBenefit(idBenefit)

        If SelectedBenefit.Rows.Count = 0 Then Exit Sub

        Dim Item As DataRow = SelectedBenefit.Rows(0)

        TB_BenefitName.Text = Item(1).ToString()
        TB_Description.Text = Item(2).ToString()

        Dim type As Integer = CInt(Item(3))
        If type = 20 Then
            CB_Type.SelectedIndex = 1
        ElseIf type = 30 Then
            CB_Type.SelectedIndex = 2
        End If

        TB_AuthorizeBy.Text = Item(6).ToString()

        If IsDBNull(Item(8)) Then
            CB_Status.Checked = False
        Else
            CB_Status.Checked = Convert.ToBoolean(Item(8))
        End If

        If IsDBNull(Item(9)) Then
            DT_ValidFrom.Value = Date.Today
        Else
            DT_ValidFrom.Value = CDate(Item(9))
        End If

        If IsDBNull(Item(10)) Then
            DT_ValidTo.Value = Date.Today.AddYears(10)
        Else
            DT_ValidTo.Value = CDate(Item(10))
        End If

        TB_Ammount.Text = If(IsDBNull(Item("BENEF_AMMOU")), "", Item("BENEF_AMMOU").ToString())
        TB_Percent.Text = If(IsDBNull(Item("BENEF_PERCENT")), "", Item("BENEF_PERCENT").ToString())

    End Sub


    Private Sub InitializationOfFields()
        Dim report As New CL_Benefits()
        CB_AllBenefits.DataSource = report.Get_ListOfBenefits

        CB_AllBenefits.DisplayMember = "Nombre"
        CB_AllBenefits.ValueMember = "Id"
        CB_AllBenefits.SelectedIndex = 0


        CB_Type.Items.Clear()
        CB_Type.Items.Add(New ComboItem With {.Id = 10, .Descripcion = "Seleccione uno"})
        CB_Type.Items.Add(New ComboItem With {.Id = 20, .Descripcion = "Manual"})
        CB_Type.Items.Add(New ComboItem With {.Id = 30, .Descripcion = "Automático"})
        CB_Type.DisplayMember = "Descripcion"
        CB_Type.ValueMember = "Id"
        CB_Type.SelectedIndex = 0


        TB_BenefitName.Text = ""
        TB_Description.Text = ""
        TB_AuthorizeBy.Text = ""
        CB_Status.Checked = False
        TB_Ammount.Text = ""
        TB_Percent.Text = ""


        DT_ValidFrom.Value = Date.Today
        DT_ValidTo.Value = Date.Today.AddYears(10)

        Display_Record()
    End Sub


    Private Sub CB_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Type.SelectedIndexChanged
        If Not CB_Type.Focused Then Return

        If CB_Type.SelectedItem IsNot Nothing Then
            Dim item As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
            Dim id As Integer = item.Id

            If id = 30 Then
                System.Windows.Forms.MessageBox.Show("Este beneficio se asignará automáticamente.",
                                                    "Información del Sistema",
                                                    System.Windows.Forms.MessageBoxButtons.OK,
                                                    System.Windows.Forms.MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
