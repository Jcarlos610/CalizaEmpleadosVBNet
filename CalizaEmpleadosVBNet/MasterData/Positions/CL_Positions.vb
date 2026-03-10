Imports Microsoft.Data.SqlClient

Public Class CL_Positions
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _POSIT_ID As Object
    Private _POSIT_NAME As Object
    Private _POSIT_DESCR As Object
    Private _POSIT_DATEC As Object
    Private _POSIT_SALAR As Object
    Private _POSIT_CREBY As Object
    Private _POSIT_AUTH As Object
    Private _POSIT_STAT As Object

    Public Property POSIT_ID As Object
        Get
            Return _POSIT_ID
        End Get
        Set(value As Object)
            _POSIT_ID = value
        End Set
    End Property

    Public Property POSIT_NAME As Object
        Get
            Return _POSIT_NAME
        End Get
        Set(value As Object)
            _POSIT_NAME = value
        End Set
    End Property

    Public Property POSIT_DESCR As Object
        Get
            Return _POSIT_DESCR
        End Get
        Set(value As Object)
            _POSIT_DESCR = value
        End Set
    End Property

    Public Property POSIT_DATEC As Object
        Get
            Return _POSIT_DATEC
        End Get
        Set(value As Object)
            _POSIT_DATEC = value
        End Set
    End Property

    Public Property POSIT_SALAR As Object
        Get
            Return _POSIT_SALAR
        End Get
        Set(value As Object)
            _POSIT_SALAR = value
        End Set
    End Property

    Public Property POSIT_CREBY As Object
        Get
            Return _POSIT_CREBY
        End Get
        Set(value As Object)
            _POSIT_CREBY = value
        End Set
    End Property

    Public Property POSIT_AUTH As Object
        Get
            Return _POSIT_AUTH
        End Get
        Set(value As Object)
            _POSIT_AUTH = value
        End Set
    End Property

    Public Property POSIT_STAT As Object
        Get
            Return _POSIT_STAT
        End Get
        Set(value As Object)
            _POSIT_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(POSIT_NAME, POSIT_DESCR, POSIT_DATEC, POSIT_SALAR, POSIT_CREBY, POSIT_AUTH, POSIT_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _POSIT_NAME = POSIT_NAME
        _POSIT_DESCR = POSIT_DESCR
        _POSIT_DATEC = POSIT_DATEC
        _POSIT_SALAR = POSIT_SALAR
        _POSIT_CREBY = POSIT_CREBY
        _POSIT_AUTH = POSIT_AUTH
        _POSIT_STAT = POSIT_STAT

    End Sub
    Sub New(POSIT_ID, POSIT_NAME, POSIT_DESCR, POSIT_DATEC, POSIT_SALAR, POSIT_CREBY, POSIT_AUTH, POSIT_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _POSIT_ID = POSIT_ID
        _POSIT_NAME = POSIT_NAME
        _POSIT_DESCR = POSIT_DESCR
        _POSIT_DATEC = POSIT_DATEC
        _POSIT_SALAR = POSIT_SALAR
        _POSIT_CREBY = POSIT_CREBY
        _POSIT_AUTH = POSIT_AUTH
        _POSIT_STAT = POSIT_STAT
    End Sub

    Public Function InsertPosition()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_POSITION",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("POSIT_NAME", _POSIT_NAME)
            DB_Command.Parameters.AddWithValue("POSIT_DESCR", _POSIT_DESCR)
            DB_Command.Parameters.AddWithValue("POSIT_DATEC", _POSIT_DATEC)
            DB_Command.Parameters.AddWithValue("POSIT_SALAR", _POSIT_SALAR)
            DB_Command.Parameters.AddWithValue("POSIT_CREBY", _POSIT_CREBY)
            DB_Command.Parameters.AddWithValue("POSIT_AUTH", _POSIT_AUTH)
            DB_Command.Parameters.AddWithValue("POSIT_STAT", _POSIT_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Positions.InsertPosition()")

            Return Nothing
        End Try
    End Function


    Public Function UpdatePosition()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_Position",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("POSIT_ID", _POSIT_ID)
            DB_Command.Parameters.AddWithValue("POSIT_NAME", _POSIT_NAME)
            DB_Command.Parameters.AddWithValue("POSIT_DESCR", _POSIT_DESCR)
            DB_Command.Parameters.AddWithValue("POSIT_DATEC", _POSIT_DATEC)
            DB_Command.Parameters.AddWithValue("POSIT_SALAR", _POSIT_SALAR)
            DB_Command.Parameters.AddWithValue("POSIT_AUTH", _POSIT_AUTH)
            DB_Command.Parameters.AddWithValue("POSIT_STAT", _POSIT_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Position.InsertPosition()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllPositions() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_GETALLPOSITIONS",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Position.Get_AllPositions()")

            Return Nothing
        End Try
    End Function

    Public Function Get_ListOfPositions() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione una posición")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETLISTOFPOSITIONS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Positions.Get_ListOfPositions()")

            Return Nothing
        End Try
    End Function

    Public Function Get_OnePosition(POSIT_ID) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETONEPOSITION",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("POSIT_ID", POSIT_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Positions.Get_OnePosition()")

            Return Nothing
        End Try
    End Function

End Class