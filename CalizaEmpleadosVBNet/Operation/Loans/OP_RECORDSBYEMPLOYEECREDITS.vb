Public Class OP_RECORDSBYEMPLOYEECREDITS
    Private Sub OP_RECORDSBYEMPLOYEECREDITS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCreditTypes()
        LoadDiscounts()
        LoadLoans()
        LoadEmployees()
        InitializationOfFields()
    End Sub

    Sub LoadEmployees()
        Dim obj As New CL_EmployeeLoans
        DGV_EmployeeInfo.DataSource = obj.GetAllEmployeesInfo()

        DGV_EmployeeInfo.Columns("No. Empleado").HeaderText = "No. Empleado"
        DGV_EmployeeInfo.Columns("Nombre Completo").HeaderText = "Empleado"
    End Sub



    Sub LoadLoans()
        Dim obj As New CL_EmployeeLoans
        DGV_Loans.DataSource = obj.GetAllLoans()

        DGV_Loans.Columns("EMPL_ID").HeaderText = "ID"
        DGV_Loans.Columns("Empleado").HeaderText = "Empleado"
        DGV_Loans.Columns("Monto").DefaultCellStyle.Format = "C2"
        DGV_Loans.Columns("Saldo").Visible = False
        DGV_Loans.Columns("LOAN_ID").Visible = False
        DGV_Loans.Columns("Pagado").Visible = False
    End Sub


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

    Function Get_EMPL_ID() As Integer
        If DGV_EmployeeInfo.CurrentRow Is Nothing Then Return 0
        Return Convert.ToInt32(DGV_EmployeeInfo.CurrentRow.Cells("No. Empleado").Value)
    End Function

    Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click
        If Get_EMPL_ID() = 0 Then
            MessageBox.Show("Selecciona un empleado")
            Exit Sub
        End If

        If TB_Ammount.Text = "" OrElse Not IsNumeric(TB_Ammount.Text) Then
            MessageBox.Show("Monto inválido")
            Exit Sub
        End If

        If CB_Credits.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona tipo de crédito")
            Exit Sub
        End If

        Dim tipoCredito As Integer

        If CB_Credits.SelectedIndex = 0 Then
            tipoCredito = 1
        Else
            tipoCredito = 2
        End If

        If TB_AuthorizeBy.Text = "" Then
            MessageBox.Show("Ingresa quién autoriza")
            Exit Sub
        End If

        Dim obj As New CL_EmployeeLoans

        obj.EMPL_ID = Get_EMPL_ID()
        obj.DREMPL_LAMM = Convert.ToDecimal(TB_Ammount.Text)
        obj.DREMPL_LTYPE = tipoCredito
        obj.REMPL_CREBY = AppUser
        obj.REMPL_RDATE = Date.Today
        obj.DREMPL_DESCR = TB_Comment.Text
        obj.DREMPL_AUTH = TB_AuthorizeBy.Text


        If CB_Discounts.SelectedValue IsNot Nothing Then
            obj.DISC_ID = CB_Discounts.SelectedValue
        Else
            obj.DISC_ID = DBNull.Value
        End If


        obj.InsertLoan()

        MessageBox.Show("Crédito registrado correctamente")

        LoadLoans()

        InitializationOfFields()

    End Sub

    Sub InitializationOfFields()

        TB_Ammount.Text = ""
        TB_Comment.Text = ""
        TB_AuthorizeBy.Text = ""

        CB_Credits.SelectedIndex = -1
        CB_Discounts.SelectedIndex = -1
        CB_Discounts.Text = ""



        DGV_EmployeeInfo.ClearSelection()

    End Sub


End Class