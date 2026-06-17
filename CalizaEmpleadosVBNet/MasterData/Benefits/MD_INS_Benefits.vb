Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Data.SqlClient

Public Class MD_INS_Benefits

    Private Sub MD_INS_Benefits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializationOfFields()

    End Sub



    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
    '    Try

    '        If TB_BenefitName.Text.Trim() = "" Then
    '            MsgBox("Por favor, ingrese el nombre del beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
    '            TB_BenefitName.Focus()
    '            Exit Sub

    '        ElseIf TB_Description.Text.Trim() = "" Then
    '            MsgBox("Por favor, ingrese una descripción para el beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
    '            TB_Description.Focus()
    '            Exit Sub

    '        ElseIf CB_Type.SelectedItem Is Nothing Then
    '            MsgBox("Por favor, seleccione el tipo de beneficio de la lista.", MsgBoxStyle.Exclamation, "Falta Información")
    '            CB_Type.Focus()
    '            Exit Sub

    '        ElseIf TB_AuthorizeBy.Text.Trim() = "" Then
    '            MsgBox("Por favor, indique quién autoriza este beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
    '            TB_AuthorizeBy.Focus()
    '            Exit Sub

    '        ElseIf TB_Ammount.Text.Trim() <> "" AndAlso TB_Percent.Text.Trim() <> "" Then
    '            MsgBox("Operación inválida: Solo puede ingresar un Monto fijo o un Porcentaje, no ambos.", MsgBoxStyle.Critical, "Error de Configuración")
    '            Return

    '        ElseIf TB_Ammount.Text.Trim() = "" AndAlso TB_Percent.Text.Trim() = "" Then
    '            MsgBox("Por favor, debe ingresar un Monto monetario o un Porcentaje de beneficio.", MsgBoxStyle.Exclamation, "Falta Información")
    '            Return

    '        ElseIf DT_ValidTo.Value.Date < DT_ValidFrom.Value.Date Then
    '            MsgBox("La fecha de término del beneficio no puede ser menor a la fecha de inicio.", MsgBoxStyle.Exclamation, "Fechas Inválidas")
    '            Return
    '        End If



    '        Dim Type As ComboItem = CType(CB_Type.SelectedItem, ComboItem)
    '        Dim Id_Type As Integer = Type.Id

    '        Dim Benefit = New CL_Benefits(
    '            TB_BenefitName.Text,
    '            TB_Description.Text,
    '            Id_Type,
    '            Date.Now,
    '            AppUser,
    '            TB_AuthorizeBy.Text,
    '            TB_Ammount.Text,
    '            1,
    '            DT_ValidFrom.Value,
    '            DT_ValidTo.Value,
    '            TB_Percent.Text
    '        )

    '        If Benefit.InsertBenefit() Then
    '            MsgBox("¡El beneficio '" & TB_BenefitName.Text.Trim() & "' ha sido registrado exitosamente en el sistema!", MsgBoxStyle.Information, "Registro Completo")

    '            InitializationOfFields()
    '        Else
    '            MsgBox("El beneficio no pudo ser guardado. Verifique las conexiones o las reglas de la base de datos.", MsgBoxStyle.Critical, "Error al Guardar")
    '        End If

    '    Catch ex As Exception

    '        MsgBox("Ocurrió un error crítico inesperado al registrar el beneficio: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
    '    End Try

    'End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        Try
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
            Dim valorDetalle As String = If(TB_Ammount.Text.Trim() <> "", $"Monto: {TB_Ammount.Text.Trim()}", $"Porcentaje: {TB_Percent.Text.Trim()}%")

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
                'LOG 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descLog As String = $"REGISTRO BENEFICIO EXITOSO: El usuario '{GlobalSession.GlobalUserName}' creó el beneficio: '{TB_BenefitName.Text.Trim()}' (Tipo ID: {Id_Type}) | " &
                                        $"{valorDetalle} | Autorizado Por: '{TB_AuthorizeBy.Text.Trim()}' | " &
                                        $"Vigencia: {DT_ValidFrom.Value:dd/MM/yyyy} al {DT_ValidTo.Value:dd/MM/yyyy} | " &
                                        $"Descripción: '{TB_Description.Text.Trim()}'."

                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Benefits", "INSERT_BENEFIT_SUCCESS", descLog, 0, "INFO")
                End Using

                MsgBox("¡El beneficio '" & TB_BenefitName.Text.Trim() & "' ha sido registrado exitosamente en el sistema!", MsgBoxStyle.Information, "Registro Completo")
                InitializationOfFields()
            Else
                'LOG DE RECHAZO
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descFallo As String = $"REGISTRO BENEFICIO RECHAZADO: Base de datos denegó la inserción de '{TB_BenefitName.Text.Trim()}'. Revisar constraints."
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Benefits", "INSERT_BENEFIT_REJECTED", descFallo, 0, "WARNING")
                End Using

                MsgBox("El beneficio no pudo ser guardado. Verifique las conexiones o las reglas de la base de datos.", MsgBoxStyle.Critical, "Error al Guardar")
            End If

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR AL INSERTAR BENEFICIO: Falló el registro de '{TB_BenefitName.Text.Trim()}'. Motivo: {ex.Message} en Form_Benefits.BT_Register_Click()"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Benefits", "INSERT_BENEFIT_ERROR", descError, 0, "ERROR", ex.StackTrace)
            End Using

            MsgBox("Ocurrió un error crítico inesperado al registrar el beneficio: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
        End Try
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