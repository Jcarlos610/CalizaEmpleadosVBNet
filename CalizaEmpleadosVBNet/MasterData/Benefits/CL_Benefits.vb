Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.Data.SqlClient

Public Class CL_Benefits
    'Public DB_Connection As SqlConnection
    'Public DB_Command As SqlCommand
    'Public DB_Reader As SqlDataReader

    'Private _BENEF_ID As Object
    'Private _BENEF_NAME As Object
    'Private _BENEF_DESCR As Object
    'Private _BENEF_DATEC As Object
    'Private _BENEF_CREBY As Object
    'Private _BENEF_AUTH As Object
    'Private _BENEF_SCHE As Object
    'Private _BENEF_DAY As Object
    'Private _BENEF_STAT As Object
    'Private _BENEF_VALFR As Object
    'Private _BENEF_VALTO As Object
    'Private _BENEF_AMMOU As Object

    'Public Property BENEF_ID As Object
    '    Get
    '        Return _BENEF_ID
    '    End Get
    '    Set(value As Object)
    '        _BENEF_ID = value
    '    End Set
    'End Property

    'Public Property BENEF_NAME As Object
    '    Get
    '        Return _BENEF_NAME
    '    End Get
    '    Set(value As Object)
    '        _BENEF_NAME = value
    '    End Set
    'End Property

    'Public Property BENEF_DESCR As Object
    '    Get
    '        Return _BENEF_DESCR
    '    End Get
    '    Set(value As Object)
    '        _BENEF_DESCR = value
    '    End Set
    'End Property

    'Public Property BENEF_DATEC As Object
    '    Get
    '        Return _BENEF_DATEC
    '    End Get
    '    Set(value As Object)
    '        _BENEF_DATEC = value
    '    End Set
    'End Property

    'Public Property BENEF_CREBY As Object
    '    Get
    '        Return _BENEF_CREBY
    '    End Get
    '    Set(value As Object)
    '        _BENEF_CREBY = value
    '    End Set
    'End Property

    'Public Property BENEF_AUTH As Object
    '    Get
    '        Return _BENEF_AUTH
    '    End Get
    '    Set(value As Object)
    '        _BENEF_AUTH = value
    '    End Set
    'End Property

    'Public Property BENEF_SCHE As Object
    '    Get
    '        Return _BENEF_SCHE
    '    End Get
    '    Set(value As Object)
    '        _BENEF_SCHE = value
    '    End Set
    'End Property

    'Public Property BENEF_DAY As Object
    '    Get
    '        Return _BENEF_DAY
    '    End Get
    '    Set(value As Object)
    '        _BENEF_DAY = value
    '    End Set
    'End Property

    'Public Property BENEF_STAT As Object
    '    Get
    '        Return _BENEF_STAT
    '    End Get
    '    Set(value As Object)
    '        _BENEF_STAT = value
    '    End Set
    'End Property

    'Public Property BENEF_VALFR As Object
    '    Get
    '        Return _BENEF_VALFR
    '    End Get
    '    Set(value As Object)
    '        _BENEF_VALFR = value
    '    End Set
    'End Property

    'Public Property BENEF_VALTO As Object
    '    Get
    '        Return _BENEF_VALTO
    '    End Get
    '    Set(value As Object)
    '        _BENEF_VALTO = value
    '    End Set
    'End Property

    'Public Property BENEF_AMMOU As Object
    '    Get
    '        Return _BENEF_AMMOU
    '    End Get
    '    Set(value As Object)
    '        _BENEF_AMMOU = value
    '    End Set
    'End Property

    'Sub New()
    '    DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    'End Sub

    'Sub New(BENEF_NAME, BENEF_DESCR, BENEF_DATEC, BENEF_CREBY, BENEF_AUTH, BENEF_SCHE, BENEF_DAY, BENEF_AMMOU, BENEF_STAT, BENEF_VALFR, BENEF_VALTO)
    '    DB_Connection = New SqlConnection(My.Settings.ConnectionString)

    '    _BENEF_NAME = BENEF_NAME
    '    _BENEF_DESCR = BENEF_DESCR
    '    _BENEF_DATEC = BENEF_DATEC
    '    _BENEF_CREBY = BENEF_CREBY
    '    _BENEF_AUTH = BENEF_AUTH
    '    _BENEF_SCHE = BENEF_SCHE
    '    _BENEF_DAY = BENEF_DAY
    '    _BENEF_STAT = BENEF_STAT
    '    _BENEF_VALFR = BENEF_VALFR
    '    _BENEF_VALTO = BENEF_VALTO
    '    _BENEF_AMMOU = BENEF_AMMOU
    'End Sub

    'Sub New(BENEF_ID, BENEF_NAME, BENEF_DESCR, BENEF_DATEC, BENEF_CREBY, BENEF_AUTH, BENEF_SCHE, BENEF_DAY, BENEF_AMMOU, BENEF_STAT, BENEF_VALFR, BENEF_VALTO)
    '    DB_Connection = New SqlConnection(My.Settings.ConnectionString)

    '    _BENEF_ID = BENEF_ID
    '    _BENEF_NAME = BENEF_NAME
    '    _BENEF_DESCR = BENEF_DESCR
    '    _BENEF_DATEC = BENEF_DATEC
    '    _BENEF_CREBY = BENEF_CREBY
    '    _BENEF_AUTH = BENEF_AUTH
    '    _BENEF_SCHE = BENEF_SCHE
    '    _BENEF_DAY = BENEF_DAY
    '    _BENEF_STAT = BENEF_STAT
    '    _BENEF_VALFR = BENEF_VALFR
    '    _BENEF_VALTO = BENEF_VALTO
    '    _BENEF_AMMOU = BENEF_AMMOU
    'End Sub

    'Public Function InsertBenefit()

    '    Try
    '        DB_Command = New SqlCommand With {
    '            .CommandText = "INS_BENEFIT",
    '            .CommandType = CommandType.StoredProcedure
    '        }
    '        DB_Connection.Open()
    '        DB_Command.Connection = DB_Connection
    '        DB_Command.Parameters.AddWithValue("BENEF_NAME", _BENEF_NAME)
    '        DB_Command.Parameters.AddWithValue("BENEF_DESCR", _BENEF_DESCR)
    '        DB_Command.Parameters.AddWithValue("BENEF_DATEC", Date.Today)
    '        DB_Command.Parameters.AddWithValue("BENEF_CREBY", AppUser)
    '        DB_Command.Parameters.AddWithValue("BENEF_AUTH", _BENEF_AUTH)
    '        DB_Command.Parameters.AddWithValue("BENEF_SCHE", _BENEF_SCHE)
    '        DB_Command.Parameters.AddWithValue("BENEF_DAY", _BENEF_DAY)
    '        DB_Command.Parameters.AddWithValue("BENEF_STAT", 1)
    '        DB_Command.Parameters.AddWithValue("BENEF_VALFR", _BENEF_VALFR)
    '        DB_Command.Parameters.AddWithValue("BENEF_VALTO", _BENEF_VALTO)
    '        DB_Command.Parameters.AddWithValue("BENEF_AMMOU", BENEF_AMMOU)

    '        DB_Command.ExecuteNonQuery()

    '        DB_Connection.Close()
    '        Return True
    '    Catch ex As Exception
    '        DB_Connection.Close()
    '        MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefit.InsertBenefit()")

    '        Return Nothing
    '    End Try
    'End Function


    'Public Function UpdateBenefit()

    '    Try
    '        DB_Command = New SqlCommand With {
    '            .CommandText = "UPD_BENEFIT",
    '            .CommandType = CommandType.StoredProcedure
    '        }
    '        DB_Connection.Open()
    '        DB_Command.Connection = DB_Connection
    '        DB_Command.Parameters.AddWithValue("BENEF_ID", _BENEF_ID)
    '        DB_Command.Parameters.AddWithValue("BENEF_NAME", _BENEF_NAME)
    '        DB_Command.Parameters.AddWithValue("BENEF_DESCR", _BENEF_DESCR)
    '        'DB_Command.Parameters.AddWithValue("BENEF_DATEC", Date.Today)
    '        'DB_Command.Parameters.AddWithValue("BENEF_CREBY", AppUser)
    '        DB_Command.Parameters.AddWithValue("BENEF_AUTH", _BENEF_AUTH)
    '        DB_Command.Parameters.AddWithValue("BENEF_SCHE", _BENEF_SCHE)
    '        DB_Command.Parameters.AddWithValue("BENEF_DAY", _BENEF_DAY)
    '        DB_Command.Parameters.AddWithValue("BENEF_STAT", _BENEF_STAT)
    '        DB_Command.Parameters.AddWithValue("BENEF_VALFR", _BENEF_VALFR)
    '        DB_Command.Parameters.AddWithValue("BENEF_VALTO", _BENEF_VALTO)
    '        DB_Command.Parameters.AddWithValue("BENEF_AMMOU", BENEF_AMMOU)

    '        DB_Command.ExecuteNonQuery()

    '        DB_Connection.Close()
    '        Return True
    '    Catch ex As Exception
    '        DB_Connection.Close()
    '        MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefit.InsertBenefit()")

    '        Return Nothing
    '    End Try
    'End Function

    'Public Function Get_AllBenefits() As DataTable
    '    Try
    '        DB_Command = New SqlCommand With {
    '            .CommandText = "SEL_RE_GETALLBENEFITS",
    '            .CommandType = CommandType.StoredProcedure
    '        }
    '        DB_Connection.Open()
    '        DB_Command.Connection = DB_Connection
    '        DB_Reader = DB_Command.ExecuteReader()
    '        DB_Command.Connection = DB_Connection
    '        Dim LocalTable As New DataTable

    '        LocalTable.Load(DB_Reader)
    '        DB_Reader.Close()
    '        DB_Connection.Close()
    '        Return LocalTable
    '    Catch ex As Exception
    '        DB_Connection.Close()
    '        MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_AllBenefits()")

    '        Return Nothing
    '    End Try
    'End Function

    'Public Function Get_ListOfBenefits() As DataTable

    '    Dim dt As New DataTable()
    '    dt.Columns.Add("ID", GetType(Integer))
    '    dt.Columns.Add("Nombre", GetType(String))

    '    dt.Rows.Add(0, "Seleccione un beneficio")

    '    Try
    '        DB_Command = New SqlCommand With {
    '            .CommandText = "SEL_GETLISTOFBENEFITS",
    '            .CommandType = CommandType.StoredProcedure
    '        }
    '        DB_Connection.Open()
    '        DB_Command.Connection = DB_Connection
    '        dt.Load(DB_Command.ExecuteReader())

    '        DB_Connection.Close()
    '        Return dt

    '    Catch ex As Exception
    '        DB_Connection.Close()
    '        MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_ListOfBenefits()")

    '        Return Nothing
    '    End Try
    'End Function

    'Public Function Get_OneBenefit(BENEF_ID) As DataTable
    '    Try
    '        DB_Command = New SqlCommand With {
    '            .CommandText = "SEL_GETONEBENEFIT",
    '            .CommandType = CommandType.StoredProcedure
    '        }
    '        DB_Connection.Open()
    '        DB_Command.Connection = DB_Connection
    '        DB_Command.Parameters.AddWithValue("BENEF_ID", BENEF_ID)
    '        DB_Reader = DB_Command.ExecuteReader()
    '        DB_Command.Connection = DB_Connection
    '        Dim LocalTable As New DataTable

    '        LocalTable.Load(DB_Reader)
    '        DB_Reader.Close()
    '        DB_Connection.Close()
    '        Return LocalTable
    '    Catch ex As Exception
    '        DB_Connection.Close()
    '        MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_OneBenefit()")

    '        Return Nothing
    '    End Try
    'End Function

    'Public Function Get_AllActiveBenefits() As DataTable
    '    Try
    '        DB_Command = New SqlCommand With {
    '            .CommandText = "SEL_GETALLACTIVEBENEFITS",
    '            .CommandType = CommandType.StoredProcedure
    '        }
    '        DB_Connection.Open()
    '        DB_Command.Connection = DB_Connection
    '        DB_Reader = DB_Command.ExecuteReader()
    '        DB_Command.Connection = DB_Connection
    '        Dim LocalTable As New DataTable

    '        LocalTable.Load(DB_Reader)
    '        DB_Reader.Close()
    '        DB_Connection.Close()
    '        Return LocalTable
    '    Catch ex As Exception
    '        DB_Connection.Close()
    '        MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_AllActiveBenefits()")

    '        Return Nothing
    '    End Try
    'End Function

    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _BENEF_ID As Object
    Private _BENEF_NAME As Object
    Private _BENEF_DESCR As Object
    Private _BENEF_TYPE As Object
    Private _BENEF_DATEC As Object
    Private _BENEF_CREBY As Object
    Private _BENEF_AUTH As Object
    Private _BENEF_SCHE As Object
    Private _BENEF_DAY As Object
    Private _BENEF_STAT As Object
    Private _BENEF_VALFR As Object
    Private _BENEF_VALTO As Object
    Private _BENEF_AMMOU As Object

    Public Property BENEF_ID As Object
        Get
            Return _BENEF_ID
        End Get
        Set(value As Object)
            _BENEF_ID = value
        End Set
    End Property

    Public Property BENEF_NAME As Object
        Get
            Return _BENEF_NAME
        End Get
        Set(value As Object)
            _BENEF_NAME = value
        End Set
    End Property

    Public Property BENEF_DESCR As Object
        Get
            Return _BENEF_DESCR
        End Get
        Set(value As Object)
            _BENEF_DESCR = value
        End Set
    End Property

    Public Property BENEF_TYPE As Object
        Get
            Return _BENEF_TYPE
        End Get
        Set(value As Object)
            _BENEF_TYPE = value
        End Set
    End Property

    Public Property BENEF_DATEC As Object
        Get
            Return _BENEF_DATEC
        End Get
        Set(value As Object)
            _BENEF_DATEC = value
        End Set
    End Property

    Public Property BENEF_CREBY As Object
        Get
            Return _BENEF_CREBY
        End Get
        Set(value As Object)
            _BENEF_CREBY = value
        End Set
    End Property

    Public Property BENEF_AUTH As Object
        Get
            Return _BENEF_AUTH
        End Get
        Set(value As Object)
            _BENEF_AUTH = value
        End Set
    End Property

    Public Property BENEF_SCHE As Object
        Get
            Return _BENEF_SCHE
        End Get
        Set(value As Object)
            _BENEF_SCHE = value
        End Set
    End Property

    Public Property BENEF_DAY As Object
        Get
            Return _BENEF_DAY
        End Get
        Set(value As Object)
            _BENEF_DAY = value
        End Set
    End Property

    Public Property BENEF_STAT As Object
        Get
            Return _BENEF_STAT
        End Get
        Set(value As Object)
            _BENEF_STAT = value
        End Set
    End Property

    Public Property BENEF_VALFR As Object
        Get
            Return _BENEF_VALFR
        End Get
        Set(value As Object)
            _BENEF_VALFR = value
        End Set
    End Property

    Public Property BENEF_VALTO As Object
        Get
            Return _BENEF_VALTO
        End Get
        Set(value As Object)
            _BENEF_VALTO = value
        End Set
    End Property

    Public Property BENEF_AMMOU As Object
        Get
            Return _BENEF_AMMOU
        End Get
        Set(value As Object)
            _BENEF_AMMOU = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(BENEF_NAME, BENEF_DESCR, BENEF_TYPE, BENEF_DATEC, BENEF_CREBY, BENEF_AUTH, BENEF_SCHE, BENEF_DAY, BENEF_AMMOU, BENEF_STAT, BENEF_VALFR, BENEF_VALTO)

        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _BENEF_NAME = BENEF_NAME
        _BENEF_DESCR = BENEF_DESCR
        _BENEF_TYPE = BENEF_TYPE
        _BENEF_DATEC = BENEF_DATEC
        _BENEF_CREBY = BENEF_CREBY
        _BENEF_AUTH = BENEF_AUTH
        _BENEF_SCHE = BENEF_SCHE
        _BENEF_DAY = BENEF_DAY
        _BENEF_STAT = BENEF_STAT
        _BENEF_VALFR = BENEF_VALFR
        _BENEF_VALTO = BENEF_VALTO
        _BENEF_AMMOU = BENEF_AMMOU
    End Sub


    Sub New(BENEF_ID, BENEF_NAME, BENEF_DESCR, BENEF_TYPE, BENEF_DATEC, BENEF_CREBY, BENEF_AUTH, BENEF_SCHE, BENEF_DAY, BENEF_AMMOU, BENEF_STAT, BENEF_VALFR, BENEF_VALTO)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _BENEF_ID = BENEF_ID
        _BENEF_NAME = BENEF_NAME
        _BENEF_DESCR = BENEF_DESCR
        _BENEF_TYPE = BENEF_TYPE
        _BENEF_DATEC = BENEF_DATEC
        _BENEF_CREBY = BENEF_CREBY
        _BENEF_AUTH = BENEF_AUTH
        _BENEF_SCHE = BENEF_SCHE
        _BENEF_DAY = BENEF_DAY
        _BENEF_STAT = BENEF_STAT
        _BENEF_VALFR = BENEF_VALFR
        _BENEF_VALTO = BENEF_VALTO
        _BENEF_AMMOU = BENEF_AMMOU
    End Sub

    Public Function InsertBenefit()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_BENEFIT",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("BENEF_NAME", _BENEF_NAME)
            DB_Command.Parameters.AddWithValue("BENEF_DESCR", _BENEF_DESCR)
            DB_Command.Parameters.AddWithValue("BENEF_TYPE", _BENEF_TYPE)
            DB_Command.Parameters.AddWithValue("BENEF_DATEC", Date.Today)
            DB_Command.Parameters.AddWithValue("BENEF_CREBY", AppUser)
            DB_Command.Parameters.AddWithValue("BENEF_AUTH", _BENEF_AUTH)
            DB_Command.Parameters.AddWithValue("BENEF_SCHE", _BENEF_SCHE)
            DB_Command.Parameters.AddWithValue("BENEF_DAY", _BENEF_DAY)
            DB_Command.Parameters.AddWithValue("BENEF_STAT", 1)
            DB_Command.Parameters.AddWithValue("BENEF_VALFR", _BENEF_VALFR)
            DB_Command.Parameters.AddWithValue("BENEF_VALTO", _BENEF_VALTO)
            DB_Command.Parameters.AddWithValue("BENEF_AMMOU", BENEF_AMMOU)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefit.InsertBenefit()")

            Return Nothing
        End Try
    End Function


    Public Function UpdateBenefit()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_BENEFIT",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("BENEF_ID", _BENEF_ID)
            DB_Command.Parameters.AddWithValue("BENEF_NAME", _BENEF_NAME)
            DB_Command.Parameters.AddWithValue("BENEF_DESCR", _BENEF_DESCR)
            DB_Command.Parameters.AddWithValue("BENEF_TYPE", _BENEF_TYPE)
            'DB_Command.Parameters.AddWithValue("BENEF_DATEC", Date.Today)
            'DB_Command.Parameters.AddWithValue("BENEF_CREBY", AppUser)
            DB_Command.Parameters.AddWithValue("BENEF_AUTH", _BENEF_AUTH)
            DB_Command.Parameters.AddWithValue("BENEF_SCHE", _BENEF_SCHE)
            DB_Command.Parameters.AddWithValue("BENEF_DAY", _BENEF_DAY)
            DB_Command.Parameters.AddWithValue("BENEF_STAT", _BENEF_STAT)
            DB_Command.Parameters.AddWithValue("BENEF_VALFR", _BENEF_VALFR)
            DB_Command.Parameters.AddWithValue("BENEF_VALTO", _BENEF_VALTO)
            DB_Command.Parameters.AddWithValue("BENEF_AMMOU", BENEF_AMMOU)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefit.InsertBenefit()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllBenefits() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_GETALLBENEFITS",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_AllBenefits()")

            Return Nothing
        End Try
    End Function

    Public Function Get_ListOfBenefits() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione un beneficio")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETLISTOFBENEFITS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_ListOfBenefits()")

            Return Nothing
        End Try
    End Function

    Public Function Get_OneBenefit(BENEF_ID) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETONEBENEFIT",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("BENEF_ID", BENEF_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_OneBenefit()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllActiveBenefits() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETALLACTIVEBENEFITS",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_AllActiveBenefits()")

            Return Nothing
        End Try
    End Function

End Class

