Imports System.IO
Imports System.Diagnostics
Imports Xceed.Words.NET
Imports Xceed.Document.NET
Imports System.Globalization
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
        {"<DOMICILIO>", Employee.EMPL_PADDR.ToString()},
        {"<TELEFONO>", Employee.EMPL_PHONE.ToString()},
        {"<CORREO>", Employee.EMPL_EMAIL.ToString()},
        {"<ESTADO_CIVIL>", Employee.EMPL_CSTAT.ToString()},
        {"<SALARIO>", CDec(Employee.EMPL_SALAR).ToString("C2")},
        {"<SALARIO_LETRA>", NumeroALetras(CDec(Employee.EMPL_SALAR))},
        {"<FECHA_INGRESO>", CDate(Employee.EMPL_EDATE).ToString("dd/MM/yyyy")},
        {"<FECHA_INICIO_PRUEBA>", CDate(Employee.EMPL_EDATE).ToString("dd/MM/yyyy")},
        {"<FECHA_FIN_PRUEBA>", CDate(Employee.EMPL_EDATE).AddDays(30).ToString("dd/MM/yyyy")},
        {"<EDAD>", (Date.Today.Year - CDate(Employee.EMPL_BDATE).Year -
                    If(Date.Today < CDate(Employee.EMPL_BDATE).AddYears(Date.Today.Year - CDate(Employee.EMPL_BDATE).Year), 1, 0)).ToString()},
        {"<SEXO>", If(Employee.EMPL_GENDER?.ToString().ToUpper() = "FEMENINO", "FEMENINO", "MASCULINO")},
        {"<PUESTO>", If(Position.POSIT_NAME?.ToString(), "")},
        {"<EMPRESA>", If(Company.COMP_ONAME?.ToString(), "")},
        {"<NACIONALIDAD>", If(Employee.EMPL_NATIONALITY?.ToString(), "")},
        {"<NO DE INE>", If(Employee.EMPL_INE?.ToString(), "")},
        {"<DIRECCION>", If(Employee.EMPL_PADDR?.ToString(), "")},
        {"<CELULAR>", If(Employee.EMPL_PHONE?.ToString(), "")},
        {"<REGISTRO AL IMSS>", If(Employee.EMPL_RDATE Is Nothing, "", CDate(Employee.EMPL_RDATE).ToString("dd/MM/yyyy"))},
        {"<BENEFICIARIO>", If(Employee.EMPL_EBENE?.ToString(), "")},
        {"<PARENTESCO>", If(Employee.EMPL_EPARE?.ToString(), "")},
        {"<FECHA>", FechaEnLetras(Date.Today)}
    }
    End Function

    Public Sub GenerateDocumentsForEmployee(templatesFolder As String, outputBaseFolder As String)
        Dim reemplazos = BuildReplacementDictionary()
        Dim nombreCompleto As String = $"{Employee.EMPL_NAME} {Employee.EMPL_LNAM1} {Employee.EMPL_LNAM2}"
        Dim outputFolder As String = Path.Combine(outputBaseFolder, nombreCompleto)
        If Not Directory.Exists(outputFolder) Then Directory.CreateDirectory(outputFolder)

        For Each templatePath As String In Directory.GetFiles(templatesFolder, "*.docx")
            GenerateSingleDocumentPublic(templatePath, outputFolder, reemplazos)
        Next
    End Sub

    'Public Sub GenerateSingleDocumentPublic(templatePath As String, outputFolder As String,
    '                                    reemplazos As Dictionary(Of String, String))
    '    Dim nombreArchivo As String = Path.GetFileNameWithoutExtension(templatePath)
    '    Dim docxRellenoPath As String = Path.Combine(outputFolder, nombreArchivo & ".docx")

    '    Using doc = DocX.Load(templatePath)
    '        For Each par In reemplazos
    '            doc.ReplaceText(par.Key, par.Value)
    '        Next
    '        doc.SaveAs(docxRellenoPath)
    '    End Using

    '    ConvertToPdf(docxRellenoPath, outputFolder)
    'End Sub

    'Public Sub GenerateSingleDocumentPublic(templatePath As String, outputFolder As String,
    '                                reemplazos As Dictionary(Of String, String),
    '                                Optional progress As IProgress(Of Integer) = Nothing)
    '    Dim nombreArchivo As String = Path.GetFileNameWithoutExtension(templatePath)
    '    Dim docxRellenoPath As String = Path.Combine(outputFolder, nombreArchivo & ".docx")

    '    progress?.Report(20)

    '    'Using doc = DocX.Load(templatePath)
    '    '    For Each par In reemplazos
    '    '        doc.ReplaceText(par.Key, par.Value)
    '    '    Next
    '    '    progress?.Report(50)
    '    '    doc.SaveAs(docxRellenoPath)
    '    'End Using

    '    Using doc = DocX.Load(templatePath)
    '        For Each par In reemplazos
    '            Dim opciones As New Xceed.Document.NET.StringReplaceTextOptions With {
    '        .SearchValue = par.Key,
    '        .NewValue = par.Value,
    '        .TrackChanges = False,
    '        .RegExOptions = Text.RegularExpressions.RegexOptions.None
    '    }
    '            doc.ReplaceText(opciones)
    '        Next
    '        doc.SaveAs(docxRellenoPath)
    '    End Using

    '    progress?.Report(70)
    '    ConvertToPdf(docxRellenoPath, outputFolder)
    '    progress?.Report(100)
    'End Sub

    Public Sub GenerateSingleDocumentPublic(templatePath As String, outputFolder As String,
                                reemplazos As Dictionary(Of String, String),
                                Optional progress As IProgress(Of Integer) = Nothing)
        Dim nombreArchivo As String = Path.GetFileNameWithoutExtension(templatePath)
        Dim nombreEmpleado As String = $"{Employee.EMPL_NAME} {Employee.EMPL_LNAM1} {Employee.EMPL_LNAM2}"
        Dim docxRellenoPath As String = Path.Combine(outputFolder, $"{nombreArchivo} - {nombreEmpleado}.docx")

        progress?.Report(20)

        Using doc = DocX.Load(templatePath)
            For Each par In reemplazos
                Dim opciones As New Xceed.Document.NET.StringReplaceTextOptions With {
        .SearchValue = par.Key,
        .NewValue = par.Value,
        .TrackChanges = False,
        .RegExOptions = Text.RegularExpressions.RegexOptions.None
    }
                doc.ReplaceText(opciones)
            Next
            doc.SaveAs(docxRellenoPath)
        End Using

        progress?.Report(70)
        ConvertToPdf(docxRellenoPath, outputFolder)
        progress?.Report(100)
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

    Public Function NumeroALetras(monto As Decimal) As String
        Dim parteEntera As Long = Math.Floor(monto)
        Dim centavos As Integer = CInt(Math.Round((monto - parteEntera) * 100))

        Dim texto As String = ConvertirEntero(parteEntera).Trim().ToUpper()
        Return $"{texto} PESOS {centavos:00}/100 M.N."
    End Function

    Private Function ConvertirEntero(numero As Long) As String
        If numero = 0 Then Return "cero"
        If numero < 0 Then Return "menos " & ConvertirEntero(-numero)

        Dim unidades() As String = {"", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve"}
        Dim especiales() As String = {"diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve"}
        Dim decenas() As String = {"", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa"}
        Dim centenas() As String = {"", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos"}

        If numero >= 1000000 Then
            Dim millones As Long = numero \ 1000000
            Dim resto As Long = numero Mod 1000000
            Dim textoMillones As String = If(millones = 1, "un millón", ConvertirEntero(millones) & " millones")
            Return (textoMillones & If(resto > 0, " " & ConvertirEntero(resto), "")).Trim()
        End If

        If numero >= 1000 Then
            Dim miles As Long = numero \ 1000
            Dim resto As Long = numero Mod 1000
            Dim textoMiles As String = If(miles = 1, "mil", ConvertirEntero(miles) & " mil")
            Return (textoMiles & If(resto > 0, " " & ConvertirEntero(resto), "")).Trim()
        End If

        If numero >= 100 Then
            Dim c As Integer = CInt(numero \ 100)
            Dim resto As Integer = CInt(numero Mod 100)
            If numero = 100 Then Return "cien"
            Return (centenas(c) & If(resto > 0, " " & ConvertirEntero(resto), "")).Trim()
        End If

        If numero >= 30 Then
            Dim d As Integer = CInt(numero \ 10)
            Dim u As Integer = CInt(numero Mod 10)
            Return (decenas(d) & If(u > 0, " y " & unidades(u), "")).Trim()
        End If

        If numero >= 20 Then
            Dim u As Integer = CInt(numero Mod 10)
            If u = 0 Then Return "veinte"
            Return "veinti" & unidades(u)
        End If

        If numero >= 10 Then
            Return especiales(CInt(numero - 10))
        End If

        Return unidades(CInt(numero))
    End Function

    Private Function FechaEnLetras(fecha As Date) As String
        Dim cultura As New CultureInfo("es-MX")
        Return fecha.ToString("d 'de' MMMM 'de' yyyy", cultura)
    End Function

End Class
