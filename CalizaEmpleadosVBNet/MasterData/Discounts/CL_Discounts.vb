Imports Microsoft.Data.SqlClient

Public Class CL_Discounts
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _DISC_ID As Object
    Private _DISC_NAME As Object
    Private _DISC_DESCR As Object
    Private _DISC_TYPE As Object
    Private _DISC_DATEC As Object
    Private _DISC_AMMOU As Object
    Private _DISC_CREBY As Object
    Private _DISC_AUTH As Object
    Private _DISC_VALFR As Object
    Private _DISC_VALTO As Object
    Private _DISC_STAT As Object

    Public Property DISC_ID As Object
        Get
            Return _DISC_ID
        End Get
        Set(value As Object)
            _DISC_ID = value
        End Set
    End Property

    Public Property DISC_NAME As Object
        Get
            Return _DISC_NAME
        End Get
        Set(value As Object)
            _DISC_NAME = value
        End Set
    End Property

    Public Property DISC_DESCR As Object
        Get
            Return _DISC_DESCR
        End Get
        Set(value As Object)
            _DISC_DESCR = value
        End Set
    End Property

    Public Property DISC_TYPE As Object
        Get
            Return _DISC_TYPE
        End Get
        Set(value As Object)
            _DISC_TYPE = value
        End Set
    End Property

    Public Property DISC_DATEC As Object
        Get
            Return _DISC_DATEC
        End Get
        Set(value As Object)
            _DISC_DATEC = value
        End Set
    End Property

    Public Property DISC_AMMOU As Object
        Get
            Return _DISC_AMMOU
        End Get
        Set(value As Object)
            _DISC_AMMOU = value
        End Set
    End Property

    Public Property DISC_CREBY As Object
        Get
            Return _DISC_CREBY
        End Get
        Set(value As Object)
            _DISC_CREBY = value
        End Set
    End Property

    Public Property DISC_AUTH As Object
        Get
            Return _DISC_AUTH
        End Get
        Set(value As Object)
            _DISC_AUTH = value
        End Set
    End Property

    Public Property DISC_VALFR As Object
        Get
            Return _DISC_VALFR
        End Get
        Set(value As Object)
            _DISC_VALFR = value
        End Set
    End Property

    Public Property DISC_VALTO As Object
        Get
            Return _DISC_VALTO
        End Get
        Set(value As Object)
            _DISC_VALTO = value
        End Set
    End Property

    Public Property DISC_STAT As Object
        Get
            Return _DISC_STAT
        End Get
        Set(value As Object)
            _DISC_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(DISC_NAME, DISC_DESCR, DISC_TYPE, DISC_DATEC, DISC_AMMOU, DISC_CREBY, DISC_AUTH, DISC_VALFR, DISC_VALTO, DISC_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DISC_NAME = DISC_NAME
        _DISC_DESCR = DISC_DESCR
        _DISC_TYPE = DISC_TYPE
        _DISC_DATEC = DISC_DATEC
        _DISC_AMMOU = DISC_AMMOU
        _DISC_CREBY = DISC_CREBY
        _DISC_AUTH = DISC_AUTH
        _DISC_VALFR = DISC_VALFR
        _DISC_VALTO = DISC_VALTO
        _DISC_STAT = DISC_STAT

    End Sub

    Sub New(DISC_ID, DISC_NAME, DISC_DESCR, DISC_TYPE, DISC_DATEC, DISC_AMMOU, DISC_CREBY, DISC_AUTH, DISC_VALFR, DISC_VALTO, DISC_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DISC_ID = DISC_ID
        _DISC_NAME = DISC_NAME
        _DISC_DESCR = DISC_DESCR
        _DISC_TYPE = DISC_TYPE
        _DISC_DATEC = DISC_DATEC
        _DISC_AMMOU = DISC_AMMOU
        _DISC_CREBY = DISC_CREBY
        _DISC_AUTH = DISC_AUTH
        _DISC_VALFR = DISC_VALFR
        _DISC_VALTO = DISC_VALTO
        _DISC_STAT = DISC_STAT

    End Sub

    Public Function InsertDiscount()

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_DISCOUNT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@DISC_NAME", _DISC_NAME)
            DB_Command.Parameters.AddWithValue("@DISC_DESCR", _DISC_DESCR)
            DB_Command.Parameters.AddWithValue("@DISC_TYPE", _DISC_TYPE)
            DB_Command.Parameters.AddWithValue("@DISC_DATEC", _DISC_DATEC)
            DB_Command.Parameters.AddWithValue("@DISC_AMMOU", _DISC_AMMOU)
            DB_Command.Parameters.AddWithValue("@DISC_CREBY", _DISC_CREBY)
            DB_Command.Parameters.AddWithValue("@DISC_AUTH", _DISC_AUTH)
            DB_Command.Parameters.AddWithValue("@DISC_VALFR", _DISC_VALFR)
            DB_Command.Parameters.AddWithValue("@DISC_VALTO", _DISC_VALTO)
            DB_Command.Parameters.AddWithValue("@DISC_STAT", _DISC_STAT)


            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Discounts.InsertDiscount()")

            Return Nothing
        End Try

    End Function

    Public Function UpdateDiscount()

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "UPD_DISCOUNT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("DISC_ID", _DISC_ID)
            DB_Command.Parameters.AddWithValue("DISC_NAME", _DISC_NAME)
            DB_Command.Parameters.AddWithValue("DISC_DESCR", _DISC_DESCR)
            DB_Command.Parameters.AddWithValue("DISC_TYPE", _DISC_TYPE)
            DB_Command.Parameters.AddWithValue("DISC_AUTH", _DISC_AUTH)
            DB_Command.Parameters.AddWithValue("DISC_STAT", _DISC_STAT)
            DB_Command.Parameters.AddWithValue("DISC_VALFR", _DISC_VALFR)
            DB_Command.Parameters.AddWithValue("DISC_VALTO", _DISC_VALTO)
            DB_Command.Parameters.AddWithValue("DISC_AMMOU", _DISC_AMMOU)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Discounts.UpdateDiscount()")

            Return Nothing
        End Try

    End Function

    Public Function Get_AllDiscounts() As DataTable
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_RE_GETALLDISCOUNTS",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()

            Dim LocalTable As New DataTable
            LocalTable.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()

            Return LocalTable

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Discounts.Get_AllDiscounts()")
            Return Nothing
        End Try
    End Function

    Public Function Get_ListOfDiscounts() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione un descuento")

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_GETLISTOFDISCOUNTS",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Discounts.Get_ListOfDiscounts()")
            Return Nothing
        End Try

    End Function

    Public Function Get_OneDiscount(DISC_ID) As DataTable

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_GETONEDISCOUNT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("DISC_ID", DISC_ID)

            DB_Reader = DB_Command.ExecuteReader()

            Dim LocalTable As New DataTable
            LocalTable.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()

            Return LocalTable

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Discounts.Get_OneDiscount()")
            Return Nothing
        End Try

    End Function

End Class