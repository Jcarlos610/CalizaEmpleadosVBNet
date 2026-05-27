Imports Microsoft.Data.SqlClient

Public Class MD_UPD_Plants
    Private Sub MD_UPD_Plants_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()
        Dim report As New CL_Plants()

        CB_Plants.DataSource = report.Get_ListOfPlants()
        CB_Plants.DisplayMember = "Nombre"
        CB_Plants.ValueMember = "ID"
        CB_Plants.SelectedIndex = 0

        TB_PlantName.Text = ""
        TB_Description.Text = ""
        CB_Status.Checked = False

        Display_Record()
    End Sub

    Private Sub Display_Record()
        Dim Plant As New CL_Plants()

        DGV_PlantsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_PlantsList.AutoResizeColumns()
        DGV_PlantsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_PlantsList.DataSource = Plant.Get_AllPlants()

        If DGV_PlantsList.Columns.Contains("PLANT_ID") Then DGV_PlantsList.Columns("PLANT_ID").HeaderText = "ID Planta"
        If DGV_PlantsList.Columns.Contains("PLANT_NAME") Then DGV_PlantsList.Columns("PLANT_NAME").HeaderText = "Nombre de Planta"
        If DGV_PlantsList.Columns.Contains("PLANT_DESCR") Then DGV_PlantsList.Columns("PLANT_DESCR").HeaderText = "Descripción"

        If DGV_PlantsList.Columns.Contains("PLANT_DATEC") Then
            DGV_PlantsList.Columns("PLANT_DATEC").HeaderText = "Fecha de Creación"
            DGV_PlantsList.Columns("PLANT_DATEC").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt"
        End If

        If DGV_PlantsList.Columns.Contains("PLANT_CREBY") Then DGV_PlantsList.Columns("PLANT_CREBY").HeaderText = "Creado Por"
        If DGV_PlantsList.Columns.Contains("PLANT_STATUS_TXT") Then DGV_PlantsList.Columns("PLANT_STATUS_TXT").HeaderText = "Estatus"

        If DGV_PlantsList.Columns.Contains("PLANT_STAT") Then DGV_PlantsList.Columns("PLANT_STAT").Visible = False
    End Sub

    Private Sub CB_Plants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Plants.SelectedIndexChanged

        If CB_Plants.SelectedValue Is Nothing Then Exit Sub
        If TypeOf CB_Plants.SelectedValue IsNot Integer Then Exit Sub

        Dim idPlant As Integer = CInt(CB_Plants.SelectedValue)

        If idPlant = 0 Then
            TB_PlantName.Text = ""
            TB_Description.Text = ""
            Exit Sub
        End If

        Dim Plant As New CL_Plants()
        Dim SelectedPlant As DataTable = Plant.Get_OnePlant(idPlant)

        If SelectedPlant.Rows.Count = 0 Then Exit Sub

        Dim Item As DataRow = SelectedPlant.Rows(0)
        TB_PlantName.Text = Item("PLANT_NAME").ToString()
        TB_Description.Text = Item("PLANT_DESCR").ToString()
        CB_Status.Checked = CBool(Item("PLANT_STAT"))
    End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        If CB_Plants.SelectedIndex = 0 Then
            MessageBox.Show("Favor de seleccionar una planta válida para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_PlantName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de planta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción para la planta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Try
                Dim Plant As New CL_Plants With {
                    .PLANT_ID = CInt(CB_Plants.SelectedValue),
                    .PLANT_NAME = TB_PlantName.Text.Trim(),
                    .PLANT_DESCR = TB_Description.Text.Trim(),
                    .PLANT_STAT = CB_Status.Checked
                }

                If Plant.UpdatePlant() Then

                    'LOG 
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"ACTUALIZACIÓN PLANTA EXITOSA: ID: {Plant.PLANT_ID} | Nombre: '{TB_PlantName.Text.Trim()}' | Estado: {If(CB_Status.Checked, "Activo", "Inactivo")}."
                        InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Plants", "UPDATE_PLANT_SUCCESS", descLog, Plant.PLANT_ID, "INFO")
                    End Using

                    MessageBox.Show("La planta " + TB_PlantName.Text + " fue actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If

            Catch ex As Exception
                'LOG DE ERROR 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL ACTUALIZAR PLANTA ID {CB_Plants.SelectedValue}: {ex.Message} en MD_UPD_Plants.BT_Update_Click()"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Plants", "UPDATE_PLANT_ERROR", descError, CInt(CB_Plants.SelectedValue), "ERROR")
                End Using

                MessageBox.Show("Ocurrió un error al intentar actualizar la planta. El detalle fue guardado en la bitácora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
End Class