Imports Microsoft.Data.SqlClient

Public Class CL_HolidayScheme
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _SCHM_ID As Object
    Private _SCHM_NAME As Object
    Private _SCHM_DESCR As Object
    Private _SCHM_DATEC As Object
    Private _SCHM_CREBY As Object
    Private _SCHM_PAYSBONOS As Object

    Public Property SCHM_ID As Object
        Get
            Return _SCHM_ID
        End Get
        Set(value As Object)
            _SCHM_ID = value
        End Set
    End Property

    Public Property SCHM_NAME As Object
        Get
            Return _SCHM_NAME
        End Get
        Set(value As Object)
            _SCHM_NAME = value
        End Set
    End Property

    Public Property SCHM_DESCR As Object
        Get
            Return _SCHM_DESCR
        End Get
        Set(value As Object)
            _SCHM_DESCR = value
        End Set
    End Property

    Public Property SCHM_DATEC As Object
        Get
            Return _SCHM_DATEC
        End Get
        Set(value As Object)
            _SCHM_DATEC = value
        End Set
    End Property

    Public Property SCHM_CREBY As Object
        Get
            Return _SCHM_CREBY
        End Get
        Set(value As Object)
            _SCHM_CREBY = value
        End Set
    End Property

    Public Property SCHM_PAYSBONOS As Object
        Get
            Return _SCHM_PAYSBONOS
        End Get
        Set(value As Object)
            _SCHM_PAYSBONOS = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(SCHM_ID, SCHM_NAME, SCHM_DESCR, SCHM_DATEC, SCHM_CREBY, SCHM_PAYSBONOS)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _SCHM_ID = SCHM_ID
        _SCHM_NAME = SCHM_NAME
        _SCHM_DESCR = SCHM_DESCR
        _SCHM_DATEC = SCHM_DATEC
        _SCHM_CREBY = SCHM_CREBY
        _SCHM_PAYSBONOS = SCHM_PAYSBONOS
    End Sub

    Sub New(SCHM_NAME, SCHM_DESCR, SCHM_DATEC, SCHM_CREBY, SCHM_PAYSBONOS)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _SCHM_NAME = SCHM_NAME
        _SCHM_DESCR = SCHM_DESCR
        _SCHM_DATEC = SCHM_DATEC
        _SCHM_CREBY = SCHM_CREBY
        _SCHM_PAYSBONOS = SCHM_PAYSBONOS
    End Sub

    Public Function InsertScheme()
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_HOLIDAYSCHEME",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("SCHM_NAME", _SCHM_NAME)
            DB_Command.Parameters.AddWithValue("SCHM_DESCR", _SCHM_DESCR)
            DB_Command.Parameters.AddWithValue("SCHM_CREBY", _SCHM_CREBY)
            DB_Command.Parameters.AddWithValue("SCHM_PAYSBONOS", If(_SCHM_PAYSBONOS Is Nothing, True, _SCHM_PAYSBONOS))

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MessageBox.Show("Ocurrio el siguiente error: " & ex.Message & " CL_HolidayScheme.InsertScheme()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing
        End Try
    End Function

    Public Function UpdateScheme()
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_HOLIDAYSCHEME",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("SCHM_ID", _SCHM_ID)
            DB_Command.Parameters.AddWithValue("SCHM_NAME", _SCHM_NAME)
            DB_Command.Parameters.AddWithValue("SCHM_DESCR", _SCHM_DESCR)
            DB_Command.Parameters.AddWithValue("SCHM_PAYSBONOS", If(_SCHM_PAYSBONOS Is Nothing, True, _SCHM_PAYSBONOS))

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_HolidayScheme.UpdateScheme()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllSchemes() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_HOLIDAYSCHEMES",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_HolidayScheme.Get_AllSchemes()")

            Return Nothing
        End Try
    End Function

End Class
