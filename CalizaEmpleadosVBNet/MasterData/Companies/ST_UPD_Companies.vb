Imports Microsoft.Data.SqlClient

Public Class ST_UPD_Companies
    Private Sub ST_UPD_Companies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Company = New CL_Companies()

        'Load companies information
        CB_Companies.DataSource = Company.GetCompanies()
        CB_Companies.DisplayMember = "COMP_NAME"
        CB_Companies.ValueMember = "COMP_ID"
        CB_Companies.SelectedIndex = 0

        'Disable fields
        TB_CompanyName.Enabled = False
        TB_OfficialName.Enabled = False
        TB_TaxCode.Enabled = False

        InitializationOfFields()

    End Sub

    Private Sub CB_Companies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Companies.SelectedIndexChanged
        Dim Company = New CL_Companies()

        If CB_Companies.SelectedIndex <> 0 Then
            TB_CompanyName.Enabled = True
            TB_OfficialName.Enabled = True
            TB_TaxCode.Enabled = True
            Company.COMP_ID = CB_Companies.SelectedValue
            Dim LT_Companies As DataTable = Company.GetCompanyData()

            For Each item As DataRow In LT_Companies.Rows
                TB_CompanyName.Text = item("COMP_NAME").ToString
                TB_OfficialName.Text = item("COMP_ONAME").ToString
                TB_TaxCode.Text = item("COMP_TCODE").ToString
            Next

        End If
    End Sub

    'Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

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
    '                Dim Company = New CL_Companies(CB_Companies.SelectedValue, TB_CompanyName.Text, TB_OfficialName.Text, TB_TaxCode.Text)

    '                If Company.UpdateCompany() Then
    '                    MessageBox.Show("la empresa: " & TB_CompanyName.Text & " se actualizó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                    InitializationOfFields()

    '                    'Reload Data
    '                    CB_Companies.DataSource = Company.GetCompanies()
    '                    CB_Companies.DisplayMember = "COMP_NAME"
    '                    CB_Companies.ValueMember = "COMP_ID"
    '                    CB_Companies.SelectedIndex = 0

    '                    'Clean Textbox
    '                    TB_CompanyName.Text = ""
    '                    TB_OfficialName.Text = ""
    '                    TB_TaxCode.Text = ""

    '                    'Enable fields
    '                    TB_CompanyName.Enabled = False
    '                    TB_OfficialName.Enabled = False
    '                    TB_TaxCode.Enabled = False
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub BT_Update_Click(sender As Object, e As EventArgs) Handles BT_Update.Click

        If TB_CompanyName.Text.Trim() = "" Then
            MessageBox.Show("Favor de ingresar un nombre de empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_OfficialName.Text.Trim() = "" Then
            MessageBox.Show("Favor de ingresar un nombre oficial de la empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_TaxCode.Text.Trim() = "" Then
            MessageBox.Show("Favor de ingresar un número de RFC", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                Dim CompanyID As Integer = CInt(CB_Companies.SelectedValue)
                Dim Company = New CL_Companies(CompanyID, TB_CompanyName.Text.Trim(), TB_OfficialName.Text.Trim(), TB_TaxCode.Text.Trim())

                If Company.UpdateCompany() Then
                    'LOG
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"ACTUALIZACIÓN EMPRESA EXITOSA: El usuario '{GlobalSession.GlobalUserName}' modificó la Empresa ID: {CompanyID} | " &
                                            $"Nuevo Nombre: '{TB_CompanyName.Text.Trim()}' | Nueva Razón Social: '{TB_OfficialName.Text.Trim()}' | Nuevo RFC: '{TB_TaxCode.Text.Trim()}'."

                        InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Companies", "UPDATE_COMPANY_SUCCESS", descLog, CompanyID, "INFO")
                    End Using

                    MessageBox.Show("la empresa: " & TB_CompanyName.Text & " se actualizó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    InitializationOfFields()

                    CB_Companies.DataSource = Company.GetCompanies()
                    CB_Companies.DisplayMember = "COMP_NAME"
                    CB_Companies.ValueMember = "COMP_ID"
                    CB_Companies.SelectedIndex = 0

                    TB_CompanyName.Text = ""
                    TB_OfficialName.Text = ""
                    TB_TaxCode.Text = ""

                    TB_CompanyName.Enabled = False
                    TB_OfficialName.Enabled = False
                    TB_TaxCode.Enabled = False
                End If

            Catch ex As Exception
                'LOG DE ERROR 
                Dim fallbackID As Integer = 0
                Try : fallbackID = CInt(CB_Companies.SelectedValue) : Catch : End Try

                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL ACTUALIZAR EMPRESA: Falló la modificación de la Empresa ID: {fallbackID}. Motivo: {ex.Message} en Form_Companies.BT_Update_Click()"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Companies", "UPDATE_COMPANY_ERROR", descError, fallbackID, "ERROR", ex.StackTrace)
                End Using

                MessageBox.Show("Ocurrió un error inesperado al intentar actualizar la empresa. El reporte ha sido enviado a la bitácora.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

End Class