Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MD_UPD_Benefits
    'Private Sub MD_UPD_Benefits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    InitializationOfFields()
    'End Sub

    'Private Sub CB_Period_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Period.SelectedIndexChanged

    '    If CB_Period.SelectedItem IsNot Nothing Then

    '        CB_NumberOfDays.Enabled = True
    '        CB_NumberOfDays.Items.Clear()

    '        Dim item As ComboItem = CType(CB_Period.SelectedItem, ComboItem)

    '        Dim id As Integer = item.Id
    '        Dim descripcion As String = item.Descripcion

    '        If id > 0 Then
    '            CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 1, .Descripcion = "Lunes"})
    '            CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 2, .Descripcion = "Martes"})
    '            CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 3, .Descripcion = "Miercoles"})
    '            CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 4, .Descripcion = "Jueves"})
    '            CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 5, .Descripcion = "Viernes"})
    '            CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 6, .Descripcion = "Sabado"})
    '            CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 7, .Descripcion = "Domingo"})

    '            CB_NumberOfDays.DisplayMember = "Descripcion"
    '            CB_NumberOfDays.ValueMember = "Id"
    '        End If
    '    End If
    'End Sub

    'Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

    '    If TB_BenefitName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar un nombre de beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Description.Text = "" Then
    '        MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_AuthorizeBy.Text = "" Then
    '        MessageBox.Show("Favor de indicar quién autoriza el beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf CB_Period.SelectedItem Is Nothing Then
    '        MessageBox.Show("Favor de indicar la perioricidad.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf CB_NumberOfDays.SelectedItem Is Nothing Then
    '        MessageBox.Show("Favor de indicar el día de aplicación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ElseIf TB_Ammount.Text = "" Then
    '        MessageBox.Show("Favor de indicar el monto asignado para este beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else
    '        'select the schedule
    '        Dim Schedule As ComboItem = CType(CB_Period.SelectedItem, ComboItem)
    '        Dim Id_Schedule As Integer = Schedule.Id
    '        Dim DescriptionSchedule As String = Schedule.Descripcion

    '        'Select the number od day
    '        Dim NumberOfDay As ComboItem = CType(CB_NumberOfDays.SelectedItem, ComboItem)

    '        Dim Id_NumberOfDay As Integer = NumberOfDay.Id
    '        Dim NameOfDay As String = NumberOfDay.Descripcion

    '        Dim Benefit = New CL_Benefits(CInt(CB_AllBenefits.SelectedValue), TB_BenefitName.Text, TB_Description.Text, Date.Now, AppUser, TB_AuthorizeBy.Text, DescriptionSchedule, Id_NumberOfDay, TB_Ammount.Text, 1, DT_ValidFrom.Value, DT_ValidTo.Value)

    '        Benefit.BENEF_STAT = CB_Status.Checked

    '        If AppUser IsNot Nothing Then
    '            If Benefit.UpdateBenefit() Then
    '                MessageBox.Show("El beneficio " + TB_BenefitName.Text + " fue actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                InitializationOfFields()
    '            End If
    '        Else
    '            MessageBox.Show("No se actualizó el beneficio debido a que no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If

    '    End If
    'End Sub

    'Private Sub Display_Record()
    '    Dim report As New CL_Benefits()
    '    DGV_BenefitsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '    DGV_BenefitsList.AutoResizeColumns()
    '    DGV_BenefitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '    DGV_BenefitsList.DataSource = report.Get_AllBenefits
    'End Sub

    'Private Sub CB_AllBenefits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllBenefits.SelectedIndexChanged

    '    ' Evita ejecución durante la carga del DataSource
    '    If CB_AllBenefits.SelectedValue Is Nothing Then Exit Sub

    '    ' Evita DataRowView
    '    If TypeOf CB_AllBenefits.SelectedValue IsNot Integer Then Exit Sub

    '    Dim idBenefit As Integer = CInt(CB_AllBenefits.SelectedValue)

    '    Dim Benefit As New CL_Benefits
    '    Dim SelectedBenefit As DataTable = Benefit.Get_OneBenefit(idBenefit)

    '    If SelectedBenefit.Rows.Count = 0 Then Exit Sub

    '    Dim Item As DataRow = SelectedBenefit.Rows(0)

    '    TB_BenefitName.Text = Item(1).ToString()
    '    TB_Description.Text = Item(2).ToString()
    '    TB_AuthorizeBy.Text = Item(5).ToString()
    '    DT_ValidFrom.Value = CDate(Item(10))
    '    DT_ValidTo.Value = CDate(Item(11))
    '    CB_Status.Checked = Item(9)

    'End Sub

    'Private Sub InitializationOfFields()
    '    Dim report As New CL_Benefits()
    '    CB_AllBenefits.DataSource = report.Get_ListOfBenefits

    '    CB_AllBenefits.DisplayMember = "Nombre"
    '    CB_AllBenefits.ValueMember = "Id"
    '    CB_AllBenefits.SelectedIndex = 0

    '    CB_Period.Items.Clear()
    '    CB_Period.Items.Add(New ComboItem With {.Id = 0, .Descripcion = "Seleccione uno"})
    '    CB_Period.Items.Add(New ComboItem With {.Id = 1, .Descripcion = "Cada semana"})
    '    CB_Period.Items.Add(New ComboItem With {.Id = 2, .Descripcion = "Cada dos semanas"})
    '    CB_Period.DisplayMember = "Descripcion"
    '    CB_Period.ValueMember = "Id"
    '    CB_Period.SelectedIndex = 0

    '    TB_BenefitName.Text = ""
    '    TB_Description.Text = ""
    '    TB_AuthorizeBy.Text = ""
    '    CB_Status.Checked = False
    '    TB_Ammount.Text = ""

    '    CB_NumberOfDays.Enabled = False

    '    DT_ValidFrom.Value = Date.Today
    '    DT_ValidTo.Value = Date.Today.AddYears(1)

    '    Display_Record()
    'End Sub

    Private Sub MD_UPD_Benefits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub CB_Period_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Period.SelectedIndexChanged

        If CB_Period.SelectedItem IsNot Nothing Then

            CB_NumberOfDays.Enabled = True
            CB_NumberOfDays.Items.Clear()

            Dim item = CType(CB_Period.SelectedItem, ComboItem)

            Dim id = item.Id
            Dim descripcion = item.Descripcion

            If id > 0 Then
                CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 1, .Descripcion = "Lunes"})
                CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 2, .Descripcion = "Martes"})
                CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 3, .Descripcion = "Miercoles"})
                CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 4, .Descripcion = "Jueves"})
                CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 5, .Descripcion = "Viernes"})
                CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 6, .Descripcion = "Sabado"})
                CB_NumberOfDays.Items.Add(New ComboItem With {.Id = 7, .Descripcion = "Domingo"})

                CB_NumberOfDays.DisplayMember = "Descripcion"
                CB_NumberOfDays.ValueMember = "Id"
            End If
        End If
    End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

        If TB_BenefitName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf CB_Type.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de indicar el tipo de beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Favor de indicar quién autoriza el beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf CB_Period.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de indicar la perioricidad.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf CB_NumberOfDays.SelectedItem Is Nothing Then
            MessageBox.Show("Favor de indicar el día de aplicación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Ammount.Text = "" Then
            MessageBox.Show("Favor de indicar el monto asignado para este beneficio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'select the schedule
            Dim Schedule As ComboItem = CType(CB_Period.SelectedItem, ComboItem)
            Dim Id_Schedule As Integer = Schedule.Id
            Dim DescriptionSchedule As String = Schedule.Descripcion

            'Select the number od day
            Dim NumberOfDay As ComboItem = CType(CB_NumberOfDays.SelectedItem, ComboItem)

            Dim Id_NumberOfDay As Integer = NumberOfDay.Id
            Dim NameOfDay As String = NumberOfDay.Descripcion

            Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
            Dim Id_Type As Integer = Type.Id


            Dim Benefit = New CL_Benefits(CInt(CB_AllBenefits.SelectedValue), TB_BenefitName.Text, TB_Description.Text, Id_Type, Date.Now, AppUser, TB_AuthorizeBy.Text, DescriptionSchedule, Id_NumberOfDay, TB_Ammount.Text, 1, DT_ValidFrom.Value, DT_ValidTo.Value)

            Benefit.BENEF_STAT = CB_Status.Checked

            If AppUser IsNot Nothing Then
                If Benefit.UpdateBenefit() Then
                    MessageBox.Show("El beneficio " + TB_BenefitName.Text + " fue actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If
            Else
                MessageBox.Show("No se actualizó el beneficio debido a que no hay usuario logeado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    Private Sub Display_Record()
        Dim report As New CL_Benefits()
        DGV_BenefitsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_BenefitsList.AutoResizeColumns()
        DGV_BenefitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_BenefitsList.DataSource = report.Get_AllBenefits
    End Sub

    Private Sub CB_AllBenefits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AllBenefits.SelectedIndexChanged

        ' Evita ejecución durante la carga del DataSource
        If CB_AllBenefits.SelectedValue Is Nothing Then Exit Sub

        ' Evita DataRowView
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
        DT_ValidFrom.Value = CDate(Item(11))
        DT_ValidTo.Value = CDate(Item(12))
        CB_Status.Checked = Item(10)

    End Sub

    Private Sub InitializationOfFields()
        Dim report As New CL_Benefits()
        CB_AllBenefits.DataSource = report.Get_ListOfBenefits

        CB_AllBenefits.DisplayMember = "Nombre"
        CB_AllBenefits.ValueMember = "Id"
        CB_AllBenefits.SelectedIndex = 0

        CB_Period.Items.Clear()
        CB_Period.Items.Add(New ComboItem With {.Id = 0, .Descripcion = "Seleccione uno"})
        CB_Period.Items.Add(New ComboItem With {.Id = 1, .Descripcion = "Cada semana"})
        CB_Period.Items.Add(New ComboItem With {.Id = 2, .Descripcion = "Cada dos semanas"})
        CB_Period.DisplayMember = "Descripcion"
        CB_Period.ValueMember = "Id"
        CB_Period.SelectedIndex = 0

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

        CB_NumberOfDays.Enabled = False

        DT_ValidFrom.Value = Date.Today
        DT_ValidTo.Value = Date.Today.AddYears(1)

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
