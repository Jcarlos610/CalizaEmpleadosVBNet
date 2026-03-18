Imports ClosedXML.Excel

Public Class MD_RPT_Employees
    Private Sub MD_RPT_Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim emp As New CL_Employee
        CB_Company.DataSource = emp.Get_AllCompanies()
        CB_Company.DisplayMember = "COMP_ONAME"
        CB_Company.ValueMember = "COMP_ID"
    End Sub

    Private Sub CB_Company_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Company.SelectedIndexChanged
        If CB_Company.SelectedValue Is Nothing Then Exit Sub
        If Not IsNumeric(CB_Company.SelectedValue) Then Exit Sub

        Dim emp As New CL_Employee

        'Cargar empleados en el ComboBox
        CB_EmployeeName.DataSource = emp.GetEmployeesByCompany(CInt(CB_Company.SelectedValue))
        CB_EmployeeName.DisplayMember = "Nombre"
        CB_EmployeeName.ValueMember = "EMPL_ID"

        'Mostrar todos los empleados de la empresa en el DataGridView
        Dim table As DataTable = emp.Get_AllEmployees()
        Dim view As New DataView(table)

        view.RowFilter = "[Empresa a la que pertenece] = '" & CB_Company.Text & "'"

        DGV_AllEmployees.DataSource = view

    End Sub

    Private Sub CB_EmployeeName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_EmployeeName.SelectedIndexChanged
        If CB_EmployeeName.SelectedValue Is Nothing Then Exit Sub
        If Not IsNumeric(CB_EmployeeName.SelectedValue) Then Exit Sub

        Dim emp As New CL_Employee

        Dim table As DataTable = emp.Get_AllEmployees()

        Dim view As New DataView(table)

        view.RowFilter = "[No. Empleado] = " & CB_EmployeeName.SelectedValue

        DGV_AllEmployees.DataSource = view
    End Sub

    Private Sub BT_EmployeeExport_Click(sender As Object, e As EventArgs) Handles BT_EmployeeExport.Click

        Using Exp_File As SaveFileDialog = New SaveFileDialog() With {.Filter = "Excel Workbook|*.xlsx"}

            If Exp_File.ShowDialog() = DialogResult.OK Then

                Try

                    Using workbook As New XLWorkbook()

                        Dim ws = workbook.Worksheets.Add("Reporte")

                        Dim dv As DataView = CType(DGV_AllEmployees.DataSource, DataView)
                        Dim dt As DataTable = dv.ToTable()

                        'Título del reporte
                        ws.Cell(1, 1).Value = "REPORTE DE EMPLEADOS"
                        ws.Cell(1, 1).Style.Font.Bold = True
                        ws.Cell(1, 1).Style.Font.FontSize = 16

                        'Empresa
                        ws.Cell(3, 1).Value = "Empresa:"
                        ws.Cell(3, 2).Value = CB_Company.Text

                        'Fecha
                        ws.Cell(4, 1).Value = "Fecha:"
                        ws.Cell(4, 2).Value = DateTime.Now.ToShortDateString()

                        'Total de empleados
                        ws.Cell(5, 1).Value = "Total de empleados:"
                        ws.Cell(5, 2).Value = dt.Rows.Count

                        'Insertar tabla desde fila 7
                        ws.Cell(7, 1).InsertTable(dt)

                        'Ajustar columnas automáticamente
                        ws.Columns().AdjustToContents()

                        workbook.SaveAs(Exp_File.FileName)

                    End Using

                    MessageBox.Show("Reporte exportado correctamente")

                Catch ex As Exception

                    MessageBox.Show(ex.Message)

                End Try

            End If

        End Using

    End Sub

End Class


