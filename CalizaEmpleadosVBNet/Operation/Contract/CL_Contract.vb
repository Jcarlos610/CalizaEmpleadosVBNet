Imports System.IO
Imports System.Diagnostics
Imports Xceed.Words.NET
Public Class CL_Contract
    Public Property Employee As CL_Employee
    Public Property Position As CL_Positions
    Public Property Company As CL_Companies

    Public Sub New(employee As CL_Employee)
        Me.Employee = employee

        Me.Position = New CL_Positions()
        Dim dtPosition As DataTable = Me.Position.Get_OnePosition(employee.POSIT_ID)
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 Then
            Me.Position.POSIT_NAME = dtPosition.Rows(0)("POSIT_NAME")
        End If

        Me.Company = New CL_Companies()
        Me.Company.COMP_ID = employee.COMP_ID
        Dim dtCompany As DataTable = Me.Company.GetCompanyData()
        If dtCompany IsNot Nothing AndAlso dtCompany.Rows.Count > 0 Then
            Me.Company.COMP_NAME = dtCompany.Rows(0)("COMP_NAME")
            Me.Company.COMP_ONAME = dtCompany.Rows(0)("COMP_ONAME")
        End If
    End Sub

    Public Function BuildReplacementDictionary() As Dictionary(Of String, String)
        Return New Dictionary(Of String, String) From {
            {"<NOMBRE>", $"{Employee.EMPL_NAME} {Employee.EMPL_LNAM1} {Employee.EMPL_LNAM2}"},
            {"<RFC>", Employee.EMPL_RFC.ToString()},
            {"<CURP>", Employee.EMPL_CURP.ToString()},
            {"<NSS>", Employee.EMPL_NSS.ToString()},
            {"<DIRECCION>", Employee.EMPL_PADDR.ToString()},
            {"<TELEFONO>", Employee.EMPL_PHONE.ToString()},
            {"<CORREO>", Employee.EMPL_EMAIL.ToString()},
            {"<SALARIO>", CDec(Employee.EMPL_SALAR).ToString("C2")},
            {"<FECHA_INGRESO>", CDate(Employee.EMPL_RDATE).ToString("dd/MM/yyyy")},
            {"<PUESTO>", If(Position.POSIT_NAME?.ToString(), "")},
            {"<EMPRESA>", If(Company.COMP_ONAME?.ToString(), "")}
        }
    End Function

    Public Sub GenerateDocumentsForEmployee(templatesFolder As String, outputBaseFolder As String)
        Dim reemplazos = BuildReplacementDictionary()
        Dim nombreCompleto As String = $"{Employee.EMPL_NAME} {Employee.EMPL_LNAM1} {Employee.EMPL_LNAM2}"
        Dim outputFolder As String = Path.Combine(outputBaseFolder, nombreCompleto)
        If Not Directory.Exists(outputFolder) Then Directory.CreateDirectory(outputFolder)

        For Each templatePath As String In Directory.GetFiles(templatesFolder, "*.docx")
            GenerateSingleDocument(templatePath, outputFolder, reemplazos)
        Next
    End Sub

    Private Sub GenerateSingleDocument(templatePath As String, outputFolder As String,
                                        reemplazos As Dictionary(Of String, String))
        Dim nombreArchivo As String = Path.GetFileNameWithoutExtension(templatePath)
        Dim docxRellenoPath As String = Path.Combine(outputFolder, nombreArchivo & ".docx")

        Using doc = DocX.Load(templatePath)
            For Each par In reemplazos
                doc.ReplaceText(par.Key, par.Value)
            Next
            doc.SaveAs(docxRellenoPath)
        End Using

        ConvertToPdf(docxRellenoPath, outputFolder)
    End Sub

    Private Sub ConvertToPdf(docxPath As String, outputFolder As String)
        Dim rutaLibreOffice As String = "C:\Program Files\LibreOffice\program\soffice.exe"
        Dim psi As New ProcessStartInfo With {
            .FileName = rutaLibreOffice,
            .Arguments = $"--headless --convert-to pdf --outdir ""{outputFolder}"" ""{docxPath}""",
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        Using proceso = Process.Start(psi)
            proceso.WaitForExit(60000)
        End Using
    End Sub
End Class
