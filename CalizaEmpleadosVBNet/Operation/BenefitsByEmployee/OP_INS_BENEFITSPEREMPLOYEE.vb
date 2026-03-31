Imports System.DirectoryServices.ActiveDirectory
Imports System.Runtime.InteropServices.JavaScript.JSType

Public Class OP_INS_BENEFITSPEREMPLOYEE
    Private Sub OP_INS_BENEFITSPEREMPLOYEE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display_EmployeesRecords()
        Display_BenefitsRecords()
        AddAssignmentButton()
        Definition_DGV_BenefitsByEmployee()
    End Sub

    Private Sub Display_EmployeesRecords()
        Dim report As New CL_Employee()
        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Employees.AutoResizeColumns()
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Employees.DataSource = report.Get_EmployeesInfo
    End Sub

    Private Sub Display_BenefitsRecords()
        Dim report As New CL_Benefits()
        'DGV_Benefits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        'DGV_Benefits.AutoResizeColumns()
        DGV_Benefits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Benefits.DataSource = report.Get_AllActiveBenefits()

        DGV_Benefits.Columns("No. Beneficio").Width = 50
        DGV_Benefits.Columns("No. Beneficio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV_Benefits.Columns("No. Beneficio").ToolTipText = "Número de beneficio"
        DGV_Benefits.Columns("Nombre de beneficio").Width = 250
        DGV_Benefits.Columns("Nombre de beneficio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGV_Benefits.Columns("Nombre de beneficio").ToolTipText = "Nombre de beneficio"
        DGV_Benefits.Columns("Descripción").Width = 450
        DGV_Benefits.Columns("Descripción").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGV_Benefits.Columns("Descripción").ToolTipText = "Descripción"

    End Sub

    Private Function GetSelectedEmployee() As Integer?
        If DGV_Employees.SelectedRows.Count = 0 Then
            Return Nothing
        End If

        Return Convert.ToInt32(DGV_Employees.SelectedRows(0).Cells(0).Value)
    End Function

    Private Sub Definition_DGV_BenefitsByEmployee()

        With DGV_BenefitsByEmployee
            .Columns.Clear()
            .AutoGenerateColumns = False
            .Columns.Add("NoEmpleado", "No. Empleado")
            .Columns.Add("IdBeneficio", "ID Beneficio")
            .Columns.Add("NombreBeneficio", "Beneficio")
            .Columns.Add("Monto", "Monto")
            .Columns.Add("ValidoDesde", "Válido desde")
            .Columns.Add("ValidoHasta", "Válido hasta")
            .Columns("Monto").DefaultCellStyle.Format = "C2"

            Dim colCheck As New DataGridViewCheckBoxColumn()
            colCheck.Name = "Status"
            colCheck.HeaderText = "Status"
            colCheck.Width = 60
            .Columns.Add(colCheck)
        End With
        AddActivateButton()
        AddDeactivateButton()

        DGV_BenefitsByEmployee.Columns("NoEmpleado").Visible = False
        DGV_BenefitsByEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_BenefitsByEmployee.AutoResizeColumns()
        DGV_BenefitsByEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

    End Sub

    'Add button asignar
    Private Sub AddAssignmentButton()
        Dim btn As New DataGridViewButtonColumn()
        btn.Name = "BT_Assign"
        btn.HeaderText = "Acción"
        btn.Text = "Asignar"
        btn.UseColumnTextForButtonValue = True

        DGV_Benefits.Columns.Add(btn)
    End Sub

    'Add button activate
    Private Sub AddActivateButton()
        Dim btn As New DataGridViewButtonColumn()
        btn.Name = "BT_Activate"
        btn.HeaderText = "Activar"
        btn.Text = "Activar"
        btn.UseColumnTextForButtonValue = True

        DGV_BenefitsByEmployee.Columns.Add(btn)
    End Sub

    'Add button deactivate
    Private Sub AddDeactivateButton()
        Dim btn As New DataGridViewButtonColumn()
        btn.Name = "BT_Deactivate"
        btn.HeaderText = "Desactivar"
        btn.Text = "Desactivar"
        btn.UseColumnTextForButtonValue = True

        DGV_BenefitsByEmployee.Columns.Add(btn)
    End Sub



    'Add color to button
    Private Sub DGV_Benefits_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
    Handles DGV_Benefits.CellFormatting

        If DGV_Benefits.Columns(e.ColumnIndex).Name = "BT_Assign" AndAlso e.RowIndex >= 0 Then

            Dim cell As DataGridViewButtonCell =
            CType(DGV_Benefits.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewButtonCell)

            'cell.Style.BackColor = Color.GreenYellow
            'cell.Style.ForeColor = Color.Black
            cell.Style.BackColor = Color.FromArgb(0, 120, 215) ' Azul estilo Windows
            cell.Style.ForeColor = Color.White

        End If
    End Sub

    'Add color to button
    Private Sub DGV_BenefitsByEmployee_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
    Handles DGV_BenefitsByEmployee.CellFormatting

        If DGV_BenefitsByEmployee.Columns(e.ColumnIndex).Name = "BT_Deactivate" Or DGV_BenefitsByEmployee.Columns(e.ColumnIndex).Name = "BT_Activate" AndAlso e.RowIndex >= 0 Then

            Dim cell As DataGridViewButtonCell =
            CType(DGV_BenefitsByEmployee.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewButtonCell)

            'cell.Style.BackColor = Color.IndianRed
            'cell.Style.ForeColor = Color.Black
            cell.Style.BackColor = Color.FromArgb(0, 120, 215) ' Azul estilo Windows
            cell.Style.ForeColor = Color.White

        End If
    End Sub

    'Assign benefits to Employee
    Private Sub DGV_Benefits_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DGV_Benefits.CellContentClick

        If e.RowIndex < 0 Then Exit Sub

        If DGV_Benefits.Columns(e.ColumnIndex).Name = "BT_Assign" Then

            Dim EmployeeId = GetSelectedEmployee()

            If EmployeeId Is Nothing Then
                MessageBox.Show("Selecciona primero un empleado.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            BenefitAssignment(EmployeeId.Value, e.RowIndex)


        End If
    End Sub

    'Deactivate benefits to Employee
    Private Sub DGV_BenefitsByEmployee_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DGV_BenefitsByEmployee.CellContentClick

        If e.RowIndex < 0 Then Exit Sub

        If DGV_BenefitsByEmployee.Columns(e.ColumnIndex).Name = "BT_Deactivate" Or DGV_BenefitsByEmployee.Columns(e.ColumnIndex).Name = "BT_Activate" Then

            Dim EmployeeId = DGV_BenefitsByEmployee.Rows(e.RowIndex).Cells(0).Value
            Dim BenefitId = DGV_BenefitsByEmployee.Rows(e.RowIndex).Cells(1).Value

            Dim BenefitByEmployee = New CL_BenefitsEmployee
            If DGV_BenefitsByEmployee.Columns(e.ColumnIndex).Name = "BT_Activate" Then
                BenefitByEmployee.Upd_BenefitsByEmployeeID(EmployeeId, BenefitId, True)
            ElseIf DGV_BenefitsByEmployee.Columns(e.ColumnIndex).Name = "BT_Deactivate" Then
                BenefitByEmployee.Upd_BenefitsByEmployeeID(EmployeeId, BenefitId, False)
            End If

            Get_AvailableBenefitByEmployee(EmployeeId)
            Get_UpdatedSalaryByEmployee(EmployeeId)

        End If
    End Sub

    'Total Ammount calculation
    Private Function AmountOfBenefits() As Decimal

        Dim TotalAmmount As Decimal = 0D

        For Each r As DataGridViewRow In DGV_BenefitsByEmployee.Rows

            Dim monto As Decimal = 0D

            Decimal.TryParse(
                r.Cells("Monto").Value.ToString(),
                Globalization.NumberStyles.Currency,
                Globalization.CultureInfo.CurrentCulture,
                monto)

            TotalAmmount += monto
        Next

        Return TotalAmmount

    End Function

    'Adding benefit to employee and calculate new salary
    Private Sub BenefitAssignment(noEmpleado As Integer, rowIndex As Integer)

        DGV_Employees.Enabled = False

        Dim row As DataGridViewRow = DGV_Benefits.Rows(rowIndex)

        Dim Benefit_Id As Integer = Convert.ToInt32(row.Cells(1).Value)

        'Validate to avoid duplicate assignment
        If BenefitAlreadyAssigned(noEmpleado, Benefit_Id) Then
            MessageBox.Show(
            "Este beneficio ya fue asignado a este empleado.",
            "Beneficio duplicado",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
            Exit Sub
        End If

        'Add Benefit to DGV
        Dim Benefit_Name = row.Cells("Nombre de beneficio").Value
        Dim Ammount = row.Cells("Monto").Value
        Dim ValidFrom = row.Cells("Válido desde").Value
        Dim ValidTO = row.Cells("Válido hasta").Value

        DGV_BenefitsByEmployee.Rows.Add(noEmpleado, Benefit_Id, Benefit_Name, Ammount, ValidFrom, ValidTO)

        'Register benefit to emplyee in DB
        Dim Employee_Id As Integer = GetSelectedEmployee()


        Dim BenefitByEmployee = New CL_BenefitsEmployee(Employee_Id, Benefit_Id, Ammount, Date.Today, AppUser, 1)
        If BenefitByEmployee.InsertBenefitsByEmployee() Then
            Get_AvailableBenefitByEmployee(Employee_Id)
            Get_UpdatedSalaryByEmployee(Employee_Id)
        End If

    End Sub


    Private Function BenefitAlreadyAssigned(noEmpleado As Integer, idBeneficio As Integer) As Boolean

        For Each r As DataGridViewRow In DGV_BenefitsByEmployee.Rows

            If r.IsNewRow Then Continue For

            If Convert.ToInt32(r.Cells("NoEmpleado").Value) = noEmpleado AndAlso
               Convert.ToInt32(r.Cells("IdBeneficio").Value) = idBeneficio Then
                Return True
            End If

        Next

        Return False
    End Function

    Private Sub BT_Search_Click(sender As Object, e As EventArgs) Handles BT_Search.Click
        Dim report As New CL_Employee()
        DGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Employees.AutoResizeColumns()
        DGV_Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_Employees.DataSource = report.Get_EmployeesInfoByID(TB_EmployeeId.Text)
    End Sub

    Private Sub BT_Cancel_Click(sender As Object, e As EventArgs) Handles BT_Cancel.Click
        DGV_Employees.Enabled = True
        DGV_BenefitsByEmployee.Rows.Clear()
    End Sub

    'Private Sub BT_Register_Click(sender As Object, e As EventArgs) Handles BT_Register.Click

    '    Dim flag As Boolean = False
    '    For Each Line As DataGridViewRow In DGV_BenefitsByEmployee.Rows
    '        Dim Employee_Id As Integer = Line.Cells("NoEmpleado").Value
    '        Dim Benefit_Id As Integer = Line.Cells("IdBeneficio").Value
    '        Dim Ammount As Decimal = Line.Cells("Monto").Value

    '        Dim BenefitByEmployee = New CL_BenfitsEmployee(Employee_Id, Benefit_Id, Ammount, Date.Today, AppUser, 1)
    '        flag = BenefitByEmployee.InsertBenefitsByEmployee()
    '    Next

    '    If flag Then
    '        MessageBox.Show("Los beneficios fueron asignados corretamente al empleado " & DGV_Employees.SelectedRows(0).Cells(1).Value, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        DGV_Employees.Enabled = True
    '        DGV_BenefitsByEmployee.Rows.Clear()
    '        TB_BaseSalary.Text = ""
    '        TB_CalculatedSalary.Text = ""
    '    End If
    'End Sub

    Private Sub DGV_Employees_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_Employees.MouseClick
        Dim hit As DataGridView.HitTestInfo = DGV_Employees.HitTest(e.X, e.Y)

        If hit.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGV_Employees.Rows(hit.RowIndex)
            Dim Employee_Id As Integer = CInt(row.Cells(0).Value)

            Get_AvailableBenefitByEmployee(Employee_Id)
            Get_UpdatedSalaryByEmployee(Employee_Id)
        End If
    End Sub

    Private Sub Get_AvailableBenefitByEmployee(ByVal Employee_Id As Integer)
        DGV_BenefitsByEmployee.Rows.Clear()

        Dim BenefitsByEmployee = New CL_BenefitsEmployee
            Dim Result As DataTable = BenefitsByEmployee.Get_BenefitsByEmployeeID(Employee_Id)

            For Each Item As DataRow In Result.Rows
                If Item(6) Then
                    DGV_BenefitsByEmployee.Rows.Add(
                    Item(0),
                    Item(1),
                    Item(2),
                    Item(3),
                    Item(4),
                    Item(5),
                    True
                    )
                Else
                    DGV_BenefitsByEmployee.Rows.Add(
                    Item(0),
                    Item(1),
                    Item(2),
                    Item(3),
                    Item(4),
                    Item(5),
                    False
                    )
                End If

            Next

    End Sub

    Private Sub Get_UpdatedSalaryByEmployee(ByVal Employee_Id As Integer)
        Dim report As New CL_BenefitsEmployee()
        DGV_UpdateSalary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_UpdateSalary.AutoResizeColumns()
        DGV_UpdateSalary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGV_UpdateSalary.DataSource = report.Get_UpdateSalaryByEmployeeID(Employee_Id)
    End Sub




End Class