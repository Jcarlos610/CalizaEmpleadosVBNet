Imports Microsoft.Data.SqlClient

Public Class OP_UPD_RECORDSBYEMPLOYEECREDITS
    'Private Sub DGV_Loans_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Loans.CellContentClick
    '    If DGV_Loans.CurrentRow Is Nothing Then Exit Sub


    '    TB_Ammount.Text = DGV_Loans.CurrentRow.Cells("Monto").Value.ToString()

    '    TB_Comment.Text = DGV_Loans.CurrentRow.Cells("Comentario").Value.ToString()

    '    Dim tipo As String = DGV_Loans.CurrentRow.Cells("TipoCredito").Value.ToString()

    '    If tipo = "Crédito Manual" Then
    '        CB_Credits.SelectedItem = "Crédito Manual"
    '    ElseIf tipo = "Adelanto de sueldo" Then
    '        CB_Credits.SelectedItem = "Adelanto de sueldo"
    '    End If


    '    If DGV_Loans.Columns.Contains("AutorizadoPor") AndAlso
    '         Not IsDBNull(DGV_Loans.CurrentRow.Cells("AutorizadoPor").Value) Then

    '        TB_AuthorizeBy.Text = DGV_Loans.CurrentRow.Cells("AutorizadoPor").Value.ToString()
    '    End If

    '    If DGV_Loans.Columns.Contains("DISC_ID") Then

    '        Dim valor = DGV_Loans.CurrentRow.Cells("DISC_ID").Value

    '        If valor IsNot Nothing AndAlso Not IsDBNull(valor) Then
    '            Try
    '                CB_Discounts.SelectedValue = Convert.ToInt32(valor)
    '            Catch
    '                CB_Discounts.SelectedIndex = -1
    '            End Try
    '        Else
    '            CB_Discounts.SelectedIndex = -1
    '        End If

    '    End If

    'End Sub

    Private Sub DGV_Loans_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Loans.MouseClick

        Dim hit As DataGridView.HitTestInfo = DGV_Loans.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 AndAlso hit.Type = DataGridViewHitTestType.RowHeader Then
            Try
                Dim row As DataGridViewRow = DGV_Loans.Rows(hit.RowIndex)

                TB_Ammount.Text = row.Cells("Monto").Value.ToString()
                TB_Comment.Text = row.Cells("Comentario").Value.ToString()
                Dim tipo As String = row.Cells("TipoCredito").Value.ToString()
                If tipo = "Crédito Manual" Then
                    CB_Credits.SelectedItem = "Crédito Manual"
                ElseIf tipo = "Adelanto de sueldo" Then
                    CB_Credits.SelectedItem = "Adelanto de sueldo"
                End If

                If DGV_Loans.Columns.Contains("AutorizadoPor") AndAlso Not IsDBNull(row.Cells("AutorizadoPor").Value) Then
                    TB_AuthorizeBy.Text = row.Cells("AutorizadoPor").Value.ToString()
                End If

                If DGV_Loans.Columns.Contains("DISC_ID") Then
                    Dim valor = row.Cells("DISC_ID").Value

                    If valor IsNot Nothing AndAlso Not IsDBNull(valor) Then
                        Try
                            CB_Discounts.SelectedValue = Convert.ToInt32(valor)
                        Catch
                            CB_Discounts.SelectedIndex = -1
                        End Try
                    Else
                        CB_Discounts.SelectedIndex = -1
                    End If
                End If

            Catch ex As Exception
                MsgBox("Error al seleccionar el préstamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub


    Sub LoadLoans()
        Dim obj As New CL_EmployeeLoans

        DGV_Loans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Loans.AutoResizeColumns()
        DGV_Loans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Loans.DataSource = obj.GetAllLoans()

        DGV_Loans.Columns("EMPL_ID").HeaderText = "ID"
        DGV_Loans.Columns("Empleado").HeaderText = "Empleado"
        DGV_Loans.Columns("Monto").DefaultCellStyle.Format = "C2"
        DGV_Loans.Columns("Saldo").Visible = False
        DGV_Loans.Columns("LOAN_ID").Visible = False
        DGV_Loans.Columns("Pagado").Visible = False
    End Sub


    Sub InitializationOfFields()

        TB_Ammount.Text = ""
        TB_Comment.Text = ""
        TB_AuthorizeBy.Text = ""

        CB_Credits.SelectedIndex = -1
        CB_Discounts.SelectedIndex = -1
        CB_Discounts.Text = ""


    End Sub

    'Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
    '    If Get_LOAN_ID() = 0 Then
    '        MessageBox.Show("Selecciona un crédito")
    '        Exit Sub
    '    End If

    '    Dim tipoCredito As Integer

    '    If CB_Credits.SelectedIndex = 0 Then
    '        tipoCredito = 1
    '    Else
    '        tipoCredito = 2
    '    End If

    '    Dim obj As New CL_EmployeeLoans

    '    obj.LOAN_ID = Get_LOAN_ID()
    '    obj.DREMPL_LAMM = Convert.ToDecimal(TB_Ammount.Text)
    '    obj.DREMPL_LTYPE = tipoCredito
    '    obj.DREMPL_DESCR = TB_Comment.Text
    '    obj.DREMPL_AUTH = TB_AuthorizeBy.Text

    '    If CB_Discounts.SelectedValue IsNot Nothing Then
    '        obj.DISC_ID = CB_Discounts.SelectedValue
    '    Else
    '        obj.DISC_ID = DBNull.Value
    '    End If



    '    obj.UpdateLoan()

    '    MessageBox.Show("Crédito actualizado")

    '    LoadLoans()
    '    InitializationOfFields()
    'End Sub

    Private Sub BT_Upd_Click(sender As Object, e As EventArgs) Handles BT_Upd.Click
        If Get_LOAN_ID() = 0 Then
            MessageBox.Show("Por favor, seleccione un crédito de la lista para proceder con la actualización.", "Aviso de Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim loanId As Integer = Get_LOAN_ID()
        Dim tipoCredito As Integer = If(CB_Credits.SelectedIndex = 0, 1, 2)

        Try
            Dim obj As New CL_EmployeeLoans
            obj.LOAN_ID = loanId
            obj.DREMPL_LAMM = Convert.ToDecimal(TB_Ammount.Text)
            obj.DREMPL_LTYPE = tipoCredito
            obj.DREMPL_DESCR = TB_Comment.Text
            obj.DREMPL_AUTH = TB_AuthorizeBy.Text

            If CB_Discounts.SelectedValue IsNot Nothing Then
                obj.DISC_ID = CB_Discounts.SelectedValue
            Else
                obj.DISC_ID = DBNull.Value
            End If

            obj.UpdateLoan()

            'LOG 
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim desc As String = $"MODIFICACIÓN CRÉDITO: Se actualizaron los datos del Préstamo ID: {loanId}. Nuevos valores -> Monto: ${obj.DREMPL_LAMM} | Tipo: {tipoCredito} | Autorizado por: '{obj.DREMPL_AUTH.Trim()}' | Comentario: '{obj.DREMPL_DESCR.Trim()}'."
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Prestamos", "UPDATE_LOAN_SUCCESS", desc, 0, "INFO")
            End Using

            MessageBox.Show("¡Los datos del crédito han sido modificados con éxito!", "Confirmación de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadLoans()
            InitializationOfFields()

        Catch ex As Exception
            'LOG DE ERROR
            Using connTmp As New SqlConnection(My.Settings.ConnectionString)
                Dim descError As String = $"ERROR CRÍTICO: Falló la modificación del Préstamo ID: {loanId}. Motivo: {ex.Message}"
                InsertLog(connTmp, GlobalSession.GlobalUserName, "OP_Prestamos", "ERROR_UPDATE_LOAN", descError, 0, "ERROR", ex.StackTrace)
            End Using
            MessageBox.Show("Ocurrió un error inesperado al intentar actualizar el crédito en el servidor: " & ex.Message, "Error Crítico del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OP_UPD_RECORDSBYEMPLOYEECREDITS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCreditTypes()
        LoadDiscounts()
        LoadLoans()
        InitializationOfFields()
    End Sub

    Function Get_LOAN_ID() As Integer
        Try
            If DGV_Loans.CurrentRow Is Nothing Then Return 0

            Dim valor = DGV_Loans.CurrentRow.Cells("LOAN_ID").Value

            If valor Is Nothing OrElse IsDBNull(valor) Then Return 0

            Return Convert.ToInt32(valor)

        Catch ex As Exception
            MessageBox.Show("Error al obtener LOAN_ID: " & ex.Message)
            Return 0
        End Try
    End Function

    Sub LoadCreditTypes()
        CB_Credits.Items.Clear()
        CB_Credits.Items.Add("Crédito Manual")
        CB_Credits.Items.Add("Adelanto de sueldo")
    End Sub

    Sub LoadDiscounts()
        Dim obj As New CL_EmployeeLoans
        CB_Discounts.DataSource = obj.GetDiscounts()
        CB_Discounts.DisplayMember = "Nombre de descuento"
        CB_Discounts.ValueMember = "ID"


    End Sub

End Class