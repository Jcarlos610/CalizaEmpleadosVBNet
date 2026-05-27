Imports Microsoft.Data.SqlClient
Public Class MD_INS_Plants
    Private Sub MD_INS_Plants_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializationOfFields()
    End Sub

    Private Sub InitializationOfFields()
        TB_PlantName.Text = ""
        TB_Description.Text = ""

        Display_Record()
    End Sub

    Private Sub Display_Record()
        Dim Plant As New CL_Plants()

        DGV_PlantsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_PlantsList.AutoResizeColumns()
        DGV_PlantsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DGV_PlantsList.DataSource = Plant.Get_AllPlants()

        If DGV_PlantsList.Columns.Contains("PLANT_ID") Then
            DGV_PlantsList.Columns("PLANT_ID").HeaderText = "ID Planta"
        End If

        If DGV_PlantsList.Columns.Contains("PLANT_NAME") Then
            DGV_PlantsList.Columns("PLANT_NAME").HeaderText = "Nombre de Planta"
        End If

        If DGV_PlantsList.Columns.Contains("PLANT_DESCR") Then
            DGV_PlantsList.Columns("PLANT_DESCR").HeaderText = "Descripción"
        End If

        If DGV_PlantsList.Columns.Contains("PLANT_DATEC") Then
            DGV_PlantsList.Columns("PLANT_DATEC").HeaderText = "Fecha de Creación"
            DGV_PlantsList.Columns("PLANT_DATEC").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt"
        End If

        If DGV_PlantsList.Columns.Contains("PLANT_CREBY") Then
            DGV_PlantsList.Columns("PLANT_CREBY").HeaderText = "Creado Por"
        End If

        If DGV_PlantsList.Columns.Contains("PLANT_STATUS_TXT") Then
            DGV_PlantsList.Columns("PLANT_STATUS_TXT").HeaderText = "Estatus"
        End If

        If DGV_PlantsList.Columns.Contains("PLANT_STAT") Then
            DGV_PlantsList.Columns("PLANT_STAT").Visible = False
        End If
    End Sub

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If TB_PlantName.Text = "" Then
            MessageBox.Show("Favor de ingresar un nombre de planta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TB_Description.Text = "" Then
            MessageBox.Show("Favor de ingresar una descripción para la planta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Try
                Dim Plant As New CL_Plants With {
                    .PLANT_NAME = TB_PlantName.Text.Trim(),
                    .PLANT_DESCR = TB_Description.Text.Trim()
                }

                If Plant.InsertPlant() Then

                    'LOG
                    Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                        Dim descLog As String = $"REGISTRO PLANTA EXITOSO: Se creó la Planta: '{TB_PlantName.Text.Trim()}' | Descripción: '{TB_Description.Text.Trim()}'."
                        InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Plants", "INSERT_PLANT_SUCCESS", descLog, 0, "INFO")
                    End Using

                    MessageBox.Show("La planta " + TB_PlantName.Text + " fue ingresada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitializationOfFields()
                End If

            Catch ex As Exception
                'LOG DE ERROR 
                Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                    Dim descError As String = $"ERROR AL INSERTAR PLANTA: {ex.Message} en MD_INS_Plants.BT_Register_Click()"
                    InsertLog(connTmp, GlobalSession.GlobalUserName, "MD_Plants", "INSERT_PLANT_ERROR", descError, 0, "ERROR")
                End Using

                MessageBox.Show("Ocurrió un error al intentar registrar la planta. El detalle ha sido guardado en la bitácora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
End Class