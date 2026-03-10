Imports System.Collections.Immutable
Imports System.Data.Common
Imports System.Runtime.InteropServices.JavaScript
Imports Microsoft.Data.SqlClient

Public Class CL_Companies
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _COMP_ID As Object
    Private _COMP_NAME As Object
    Private _COMP_ONAME As Object
    Private _COMP_TCODE As Object

    Public Property COMP_ID As Object
        Get
            Return _COMP_ID
        End Get
        Set(value As Object)
            _COMP_ID = value
        End Set
    End Property

    Public Property COMP_NAME As Object
        Get
            Return _COMP_NAME
        End Get
        Set(value As Object)
            _COMP_NAME = value
        End Set
    End Property

    Public Property COMP_ONAME As Object
        Get
            Return _COMP_ONAME
        End Get
        Set(value As Object)
            _COMP_ONAME = value
        End Set
    End Property

    Public Property COMP_TCODE As Object
        Get
            Return _COMP_TCODE
        End Get
        Set(value As Object)
            _COMP_TCODE = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(COMP_NAME, COMP_ONAME, COMP_TCODE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
        _COMP_NAME = COMP_NAME
        _COMP_ONAME = COMP_ONAME
        _COMP_TCODE = COMP_TCODE
    End Sub
    Sub New(COMP_ID, COMP_NAME, COMP_ONAME, COMP_TCODE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
        _COMP_ID = COMP_ID
        _COMP_NAME = COMP_NAME
        _COMP_ONAME = COMP_ONAME
        _COMP_TCODE = COMP_TCODE
    End Sub

    Public Function InsertCompany()
        Dim F_Resutl = False
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_COMPANY",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("COMP_NAME", _COMP_NAME)
            DB_Command.Parameters.AddWithValue("COMP_ONAME", _COMP_ONAME)
            DB_Command.Parameters.AddWithValue("COMP_TCODE", _COMP_TCODE)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Companies.InsertCompany()")

            Return Nothing
        End Try
    End Function

    Public Function GetCompanies()

        Dim dt As New DataTable()
        dt.Columns.Add("COMP_ID", GetType(Integer))
        dt.Columns.Add("COMP_NAME", GetType(String))
        dt.Columns.Add("COMP_ONAME", GetType(String))
        dt.Columns.Add("COMP_TCODE", GetType(String))

        dt.Rows.Add(0, "Seleccione una")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_COMPANIES",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Companies.GetCompany()")

            Return Nothing
        End Try
    End Function

    Public Function GetCompanyData()

        Dim dt As New DataTable()
        dt.Columns.Add("COMP_ID", GetType(Integer))
        dt.Columns.Add("COMP_NAME", GetType(String))
        dt.Columns.Add("COMP_ONAME", GetType(String))
        dt.Columns.Add("COMP_TCODE", GetType(String))

        dt.Rows.Add(0, "Seleccione una")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_COMPANYDATA",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("COMP_ID", _COMP_ID)
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Companies.GetCompanyData()")

            Return Nothing
        End Try
    End Function

    Public Function UpdateCompany()
        Dim F_Resutl = False
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_COMPANY",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("COMP_ID", _COMP_ID)
            DB_Command.Parameters.AddWithValue("COMP_NAME", _COMP_NAME)
            DB_Command.Parameters.AddWithValue("COMP_ONAME", _COMP_ONAME)
            DB_Command.Parameters.AddWithValue("COMP_TCODE", _COMP_TCODE)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Companies.UpdateCompany()")

            Return Nothing
        End Try
    End Function

    Public Function GetListOfCompanies()

        Dim dt As New DataTable()
        dt.Columns.Add("COMP_ID", GetType(Integer))
        dt.Columns.Add("COMP_ONAME", GetType(String))

        dt.Rows.Add(0, "Seleccione una")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_LISTOFCOMPANIES",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Companies.GetListOfCompany()")

            Return Nothing
        End Try
    End Function

End Class
