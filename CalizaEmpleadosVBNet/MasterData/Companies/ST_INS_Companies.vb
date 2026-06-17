Imports Microsoft.Data.SqlClient

Public Class ST_INS_Companies
    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
    '    Dim Company = New CL_Companies(TB_CompanyName.Text, TB_OfficialName.Text, TB_TaxCode.Text)

    '    'Validation of fields
    '    If TB_CompanyName.Text = "" Then
    '        MessageBox.Show("Favor de ingresar un nombre de empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else
    '        If TB_OfficialName.Text = "" Then
    '            MessageBox.Show("Favor de ingresar un nombre oficial de la empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Else
    '            If TB_TaxCode.Text = "" Then
    '                MessageBox.Show("Favor de ingresar un número de RFC", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Else
    '                If Company.InsertCompany() Then
    '                    MessageBox.Show("la empresa: " & TB_CompanyName.Text & " se creó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                    InitializationOfFields()

    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If TB_CompanyName.Text.Trim() = "" Then
            MessageBox.Show("Favor de ingresar un nombre de empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_OfficialName.Text.Trim() = "" Then
            MessageBox.Show("Favor de ingresar un nombre oficial de la empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_TaxCode.Text.Trim() = "" Then
            MessageBox.Show("Favor de ingresar un número de RFC", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                Dim Company = New CL_Companies(TB_CompanyName.Text.Trim(), TB_OfficialName.Text.Trim(), TB_TaxCode.Text.Trim())

                If Company.InsertCompany() Then
                    ' LOG 
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"REGISTRO EMPRESA EXITOSO: El usuario '{GlobalSession.GlobalUserName}' creó la empresa comercial: '{TB_CompanyName.Text.Trim()}' | " &
                                            $"Razón Social: '{TB_OfficialName.Text.Trim()}' | RFC: '{TB_TaxCode.Text.Trim()}'."

                        InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Companies", "INSERT_COMPANY_SUCCESS", descLog, 0, "INFO")
                    End Using

                    MessageBox.Show("La empresa: " & TB_CompanyName.Text & " se creó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If

            Catch ex As Exception
                'LOG DE ERROR 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL INSERTAR EMPRESA: Falló el registro de '{TB_CompanyName.Text.Trim()}'. Motivo: {ex.Message} en Form_Companies.BT_Register_Click()"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Companies", "INSERT_COMPANY_ERROR", descError, 0, "ERROR", ex.StackTrace)
                End Using

                MessageBox.Show("Ocurrió un error inesperado al intentar registrar la empresa. El detalle ha sido guardado en la bitácora.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Display_Record()

        Dim company As New CL_Companies()

        DGV_CompaniesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_CompaniesList.AutoResizeColumns()
        DGV_CompaniesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_CompaniesList.DataSource = company.GetCompaniesList()

        'Cambiar nombres de columnas
        DGV_CompaniesList.Columns("COMP_ID").HeaderText = "ID"
        DGV_CompaniesList.Columns("COMP_NAME").HeaderText = "Empresa"
        DGV_CompaniesList.Columns("COMP_ONAME").HeaderText = "Razón Social"
        DGV_CompaniesList.Columns("COMP_TCODE").HeaderText = "RFC"

    End Sub

    Private Sub InitializationOfFields()

        TB_CompanyName.Text = ""
        TB_OfficialName.Text = ""
        TB_TaxCode.Text = ""

        Display_Record()

    End Sub

    Private Sub ST_INS_Companies_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializationOfFields()

    End Sub
End Class