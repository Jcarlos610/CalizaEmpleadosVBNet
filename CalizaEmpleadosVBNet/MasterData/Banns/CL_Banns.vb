Imports Microsoft.Data.SqlClient

Public Class CL_Banns
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _BANN_ID As Object
    Private _BANN_NAME As Object
    Private _BANN_DESCR As Object
    Private _BANN_DATEC As Object
    Private _BANN_AMMOU As Object
    Private _BANN_CREBY As Object
    Private _BANN_AUTH As Object
    Private _BANN_VALFR As Object
    Private _BANN_VALTO As Object
    Private _BANN_STAT As Object

    Public Property BANN_ID As Object
        Get
            Return _BANN_ID
        End Get
        Set(value As Object)
            _BANN_ID = value
        End Set
    End Property

    Public Property BANN_NAME As Object
        Get
            Return _BANN_NAME
        End Get
        Set(value As Object)
            _BANN_NAME = value
        End Set
    End Property

    Public Property BANN_DESCR As Object
        Get
            Return _BANN_DESCR
        End Get
        Set(value As Object)
            _BANN_DESCR = value
        End Set
    End Property

    Public Property BANN_DATEC As Object
        Get
            Return _BANN_DATEC
        End Get
        Set(value As Object)
            _BANN_DATEC = value
        End Set
    End Property

    Public Property BANN_AMMOU As Object
        Get
            Return _BANN_AMMOU
        End Get
        Set(value As Object)
            _BANN_AMMOU = value
        End Set
    End Property

    Public Property BANN_CREBY As Object
        Get
            Return _BANN_CREBY
        End Get
        Set(value As Object)
            _BANN_CREBY = value
        End Set
    End Property

    Public Property BANN_AUTH As Object
        Get
            Return _BANN_AUTH
        End Get
        Set(value As Object)
            _BANN_AUTH = value
        End Set
    End Property

    Public Property BANN_VALFR As Object
        Get
            Return _BANN_VALFR
        End Get
        Set(value As Object)
            _BANN_VALFR = value
        End Set
    End Property

    Public Property BANN_VALTO As Object
        Get
            Return _BANN_VALTO
        End Get
        Set(value As Object)
            _BANN_VALTO = value
        End Set
    End Property

    Public Property BANN_STAT As Object
        Get
            Return _BANN_STAT
        End Get
        Set(value As Object)
            _BANN_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(BANN_NAME, BANN_DESCR, BANN_DATEC, BANN_AMMOU, BANN_CREBY, BANN_AUTH, BANN_VALFR, BANN_VALTO, BANN_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _BANN_NAME = BANN_NAME
        _BANN_DESCR = BANN_DESCR
        _BANN_DATEC = BANN_DATEC
        _BANN_AMMOU = BANN_AMMOU
        _BANN_CREBY = BANN_CREBY
        _BANN_AUTH = BANN_AUTH
        _BANN_VALFR = BANN_VALFR
        _BANN_VALTO = BANN_VALTO
        _BANN_STAT = BANN_STAT
    End Sub

    Sub New(BANN_ID, BANN_NAME, BANN_DESCR, BANN_AMMOU, BANN_AUTH, BANN_VALFR, BANN_VALTO, BANN_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _BANN_ID = BANN_ID
        _BANN_NAME = BANN_NAME
        _BANN_DESCR = BANN_DESCR
        _BANN_AMMOU = BANN_AMMOU
        _BANN_AUTH = BANN_AUTH
        _BANN_VALFR = BANN_VALFR
        _BANN_VALTO = BANN_VALTO
        _BANN_STAT = BANN_STAT
    End Sub

    Public Function InsertBann()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_BANN",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("BANN_NAME", _BANN_NAME)
            DB_Command.Parameters.AddWithValue("BANN_DESCR", _BANN_DESCR)
            DB_Command.Parameters.AddWithValue("BANN_DATEC", _BANN_DATEC)
            DB_Command.Parameters.AddWithValue("BANN_CREBY", _BANN_CREBY)
            DB_Command.Parameters.AddWithValue("BANN_AUTH", _BANN_AUTH)
            DB_Command.Parameters.AddWithValue("BANN_STAT", _BANN_STAT)
            DB_Command.Parameters.AddWithValue("BANN_VALFR", _BANN_VALFR)
            DB_Command.Parameters.AddWithValue("BANN_VALTO", _BANN_VALTO)
            DB_Command.Parameters.AddWithValue("BANN_AMMOU", BANN_AMMOU)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Bann.InsertBann()")

            Return Nothing
        End Try
    End Function

    Public Function UpdateBann()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_BANN",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("BANN_ID", _BANN_ID)
            DB_Command.Parameters.AddWithValue("BANN_NAME", _BANN_NAME)
            DB_Command.Parameters.AddWithValue("BANN_DESCR", _BANN_DESCR)
            DB_Command.Parameters.AddWithValue("BANN_AUTH", _BANN_AUTH)
            DB_Command.Parameters.AddWithValue("BANN_STAT", _BANN_STAT)
            DB_Command.Parameters.AddWithValue("BANN_VALFR", _BANN_VALFR)
            DB_Command.Parameters.AddWithValue("BANN_VALTO", _BANN_VALTO)
            DB_Command.Parameters.AddWithValue("BANN_AMMOU", BANN_AMMOU)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Bann.UpdateBann()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllBanns() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_GETALLBANNS",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Banns.Get_AllBanns()")

            Return Nothing
        End Try
    End Function

    Public Function Get_ListOfBanns() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione una amonestación")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETLISTOFBANNS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Banns.Get_ListOfBanns()")

            Return Nothing
        End Try
    End Function

    Public Function Get_OneBann(BANN_ID) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETONEBANN",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("BANN_ID", BANN_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Bann.Get_OneBann()")

            Return Nothing
        End Try
    End Function

End Class
