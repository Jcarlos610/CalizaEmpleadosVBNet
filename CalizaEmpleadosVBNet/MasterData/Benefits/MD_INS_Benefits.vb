Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MD_INS_Benefits

    Private Sub MD_INS_Benefits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializationOfFields()

    End Sub



    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

        'If TB_BenefitName.Text = "" Then
        '    MessageBox.Show("Favor de ingresar un nombre de beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'ElseIf TB_Description.Text = "" Then
        '    MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'ElseIf CB_Type.SelectedItem Is Nothing Then
        '    MessageBox.Show("Favor de indicar el tipo de beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'ElseIf TB_AuthorizeBy.Text = "" Then
        '    MessageBox.Show("Favor de indicar quién autoriza el beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    'ElseIf TB_Ammount.Text = "" Then
        '    '    MessageBox.Show("Favor de indicar el monto asignado para este beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    'Else
        'ElseIf TB_Ammount.Text <> "" And TB_Percent.Text <> "" Then
        '    MessageBox.Show("Solo puedes ingresar monto o porcentaje, no ambos.")

        'ElseIf TB_Ammount.Text = "" And TB_Percent.Text = "" Then
        '    MessageBox.Show("Debes ingresar un monto o un porcentaje.")



        '    Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
        '    Dim Id_Type As Integer = Type.Id




        '    Dim Benefit = New CL_Benefits(TB_BenefitName.Text, TB_Description.Text, Id_Type, Date.Now, AppUser, TB_AuthorizeBy.Text, TB_Ammount.Text, 1, DT_ValidFrom.Value, DT_ValidTo.Value, TB_Percent.Text)

        '    If Benefit.InsertBenefit() Then
        '        MessageBox.Show("El beneficio " + TB_BenefitName.Text + " fue ingresado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        InitializationOfFields()
        '    End If

        'End If

        If TB_BenefitName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de beneficio.")

        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción.")

        ElseIf CB_Type.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de indicar el tipo de beneficio.")

        ElseIf TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Favor de indicar quién autoriza el beneficio.")

        ElseIf TB_Ammount.Text <> "" And TB_Percent.Text <> "" Then
            MessageBox.Show("Solo puedes ingresar monto o porcentaje, no ambos.")
            Exit Sub

        ElseIf TB_Ammount.Text = "" And TB_Percent.Text = "" Then
            MessageBox.Show("Debes ingresar un monto o un porcentaje.")
            Exit Sub
        End If



        Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
        Dim Id_Type As Integer = Type.Id

        Dim Benefit = New CL_Benefits(
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
            TB_Percent.Text
        )

        If Benefit.InsertBenefit() Then
            MessageBox.Show("El beneficio " + TB_BenefitName.Text + " fue ingresado correctamente.")
            InitializationOfFields()
        End If

    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Benefits()
        DGV_BenefitsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_BenefitsList.AutoResizeColumns()
        DGV_BenefitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_BenefitsList.DataSource = report.Get_AllBenefits
    End Sub

    Private Sub InitializationOfFields()
        Dim report As New CL_Benefits()


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
        TB_Ammount.Text = ""
        TB_Percent.Text = ""


        DT_ValidFrom.Value = Date.Today
        DT_ValidTo.Value = Date.Today.AddYears(10)

        Display_Record()
    End Sub

    Private Sub CB_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Type.SelectedIndexChanged
        If CB_Type.SelectedItem IsNot Nothing Then

            Dim item As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
            Dim id As Integer = item.Id

            If id = 30 Then
                MessageBox.Show("Este beneficio se asignará automáticamente.")
            End If

        End If

    End Sub
End Class