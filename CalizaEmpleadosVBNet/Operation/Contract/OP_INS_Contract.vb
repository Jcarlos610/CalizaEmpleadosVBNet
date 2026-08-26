Imports System.IO

Public Class OP_INS_Contract

    Dim SelectedEmplID As Integer = 0

    Private Sub OP_INS_Contract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBX_Suggesting.Visible = False
        CargarTiposDeDocumento()
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
                If values.Length > 1 Then
                    TB_EmployeeName.Text = values(1).Trim()
                Else
                    TB_EmployeeName.Text = selectedText.Trim()
                End If

                LBX_Suggesting.Visible = False

            Catch ex As Exception
                Console.WriteLine("Error temporal de casteo: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub CargarTiposDeDocumento()
        Dim carpetaPlantillas As String = My.Settings.ContractTemplatesFolder

        If Not Directory.Exists(carpetaPlantillas) Then
            MsgBox("No se encontró la carpeta de plantillas: " & carpetaPlantillas & vbCrLf &
               "Revisa la configuración del sistema.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        CB_TypeDoc.Items.Clear()
        CB_TypeDoc.Items.Add("Seleccione un tipo de documento")

        For Each archivo As String In Directory.GetFiles(carpetaPlantillas, "*.docx")
            CB_TypeDoc.Items.Add(Path.GetFileNameWithoutExtension(archivo))
        Next

        CB_TypeDoc.SelectedIndex = 0
    End Sub

    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
    '    If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
    '        MsgBox("Selecciona un empleado usando el buscador.", MsgBoxStyle.Exclamation, "Aviso")
    '        Exit Sub
    '    End If

    '    If CB_TypeDoc.SelectedIndex <= 0 Then
    '        MsgBox("Selecciona un tipo de documento.", MsgBoxStyle.Exclamation, "Aviso")
    '        Exit Sub
    '    End If

    '    Try
    '        Dim CLEmployee As New CL_Employee()
    '        Dim dtEmployee As DataTable = CLEmployee.Get_EmployeeFullInfoForContract(SelectedEmplID)

    '        If dtEmployee Is Nothing OrElse dtEmployee.Rows.Count = 0 Then
    '            MsgBox("No se encontró información de ese empleado.", MsgBoxStyle.Critical, "Error")
    '            Exit Sub
    '        End If

    '        Dim fila As DataRow = dtEmployee.Rows(0)

    '        CLEmployee.EMPL_ID = fila("EMPL_ID")
    '        CLEmployee.EMPL_NAME = fila("EMPL_NAME")
    '        CLEmployee.EMPL_LNAM1 = fila("EMPL_LNAM1")
    '        CLEmployee.EMPL_LNAM2 = fila("EMPL_LNAM2")
    '        CLEmployee.EMPL_RFC = fila("EMPL_RFC")
    '        CLEmployee.EMPL_CURP = fila("EMPL_CURP")
    '        CLEmployee.EMPL_NSS = fila("EMPL_NSS")
    '        CLEmployee.EMPL_PADDR = fila("EMPL_PADDR")
    '        CLEmployee.EMPL_PHONE = fila("EMPL_PHONE")
    '        CLEmployee.EMPL_EMAIL = fila("EMPL_EMAIL")
    '        CLEmployee.EMPL_CSTAT = fila("EMPL_CSTAT")
    '        CLEmployee.EMPL_BDATE = fila("EMPL_BDATE")
    '        CLEmployee.EMPL_SALAR = fila("EMPL_SALAR")
    '        CLEmployee.EMPL_RDATE = fila("EMPL_RDATE")
    '        CLEmployee.EMPL_EDATE = fila("EMPL_EDATE")
    '        CLEmployee.POSIT_ID = fila("POSIT_ID")
    '        CLEmployee.COMP_ID = fila("COMP_ID")

    '        Dim CLContract As New CL_Contract(CLEmployee)

    '        Dim carpetaPlantillas As String = My.Settings.ContractTemplatesFolder
    '        Dim carpetaSalida As String = My.Settings.ContractsOutputFolder
    '        Dim nombrePlantilla As String = CB_TypeDoc.SelectedItem.ToString() & ".docx"
    '        Dim rutaPlantilla As String = Path.Combine(carpetaPlantillas, nombrePlantilla)

    '        Dim reemplazos = CLContract.BuildReplacementDictionary()
    '        CLContract.GenerateSingleDocumentPublic(rutaPlantilla, carpetaSalida, reemplazos)

    '        MsgBox("Documento generado correctamente.", MsgBoxStyle.Information, "Éxito")
    '        Process.Start("explorer.exe", carpetaSalida)

    '    Catch ex As Exception
    '        MsgBox("Error al generar documento: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try

    'End Sub

    Private Async Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If String.IsNullOrEmpty(TB_EmployeeId.Text) Then
            MsgBox("Selecciona un empleado usando el buscador.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        If CB_TypeDoc.SelectedIndex <= 0 Then
            MsgBox("Selecciona un tipo de documento.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        BT_Register.Enabled = False
        PB_Progress.Visible = True
        LB_Estado.Visible = True
        PB_Progress.Value = 0
        LB_Estado.Text = "Buscando información del empleado..."

        Try
            Dim CLEmployee As New CL_Employee()
            Dim dtEmployee As DataTable = CLEmployee.Get_EmployeeFullInfoForContract(SelectedEmplID)

            If dtEmployee Is Nothing OrElse dtEmployee.Rows.Count = 0 Then
                MsgBox("No se encontró información de ese empleado.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            Dim fila As DataRow = dtEmployee.Rows(0)

            CLEmployee.EMPL_ID = fila("EMPL_ID")
            CLEmployee.EMPL_NAME = fila("EMPL_NAME")
            CLEmployee.EMPL_LNAM1 = fila("EMPL_LNAM1")
            CLEmployee.EMPL_LNAM2 = fila("EMPL_LNAM2")
            CLEmployee.EMPL_RFC = fila("EMPL_RFC")
            CLEmployee.EMPL_CURP = fila("EMPL_CURP")
            CLEmployee.EMPL_NSS = fila("EMPL_NSS")
            CLEmployee.EMPL_PADDR = fila("EMPL_PADDR")
            CLEmployee.EMPL_PHONE = fila("EMPL_PHONE")
            CLEmployee.EMPL_EMAIL = fila("EMPL_EMAIL")
            CLEmployee.EMPL_CSTAT = fila("EMPL_CSTAT")
            CLEmployee.EMPL_BDATE = fila("EMPL_BDATE")
            CLEmployee.EMPL_SALAR = fila("EMPL_SALAR")
            CLEmployee.EMPL_RDATE = fila("EMPL_RDATE")
            CLEmployee.EMPL_EDATE = fila("EMPL_EDATE")
            CLEmployee.POSIT_ID = fila("POSIT_ID")
            CLEmployee.COMP_ID = fila("COMP_ID")
            CLEmployee.EMPL_GENDER = fila("EMPL_GENDER")

            Dim CLContract As New CL_Contract(CLEmployee)

            Dim carpetaPlantillas As String = My.Settings.ContractTemplatesFolder
            Dim carpetaSalida As String = My.Settings.ContractsOutputFolder
            Dim nombrePlantilla As String = CB_TypeDoc.SelectedItem.ToString() & ".docx"
            Dim rutaPlantilla As String = Path.Combine(carpetaPlantillas, nombrePlantilla)

            Dim reemplazos = CLContract.BuildReplacementDictionary()

            Dim progreso As New Progress(Of Integer)(Sub(valor)
                                                         PB_Progress.Value = valor
                                                         Select Case valor
                                                             Case 20
                                                                 LB_Estado.Text = "Abriendo plantilla..."
                                                             Case 50
                                                                 LB_Estado.Text = "Rellenando datos..."
                                                             Case 70
                                                                 LB_Estado.Text = "Convirtiendo a PDF..."
                                                             Case 100
                                                                 LB_Estado.Text = "¡Listo!"
                                                         End Select
                                                     End Sub)

            Await Task.Run(Sub() CLContract.GenerateSingleDocumentPublic(rutaPlantilla, carpetaSalida, reemplazos, progreso))

            MsgBox("Documento generado correctamente.", MsgBoxStyle.Information, "Éxito")
            Process.Start("explorer.exe", carpetaSalida)

        Catch ex As Exception
            MsgBox("Error al generar documento: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            BT_Register.Enabled = True
            PB_Progress.Visible = False
            LB_Estado.Visible = False
        End Try

    End Sub
End Class