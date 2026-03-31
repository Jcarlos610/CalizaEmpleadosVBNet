Imports Microsoft.Data.SqlClient

Public Class CL_RecordsByEmployeeMoneySaved

    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _EMPL_ID As Object
    Private _DREMPL_ID As Object
    Private _REMPL_ID As Object
    Private _DREMPL_DATE As Object
    Private _DREMPL_AMM As Object
    Private _DREMPL_TYPE As Object
    Private _DREMPL_STAT As Object
    Private _REMPL_CREBY As Object
    Private _REMPL_RDATE As Object

    Public Property DREMPL_ID As Object
        Get
            Return _DREMPL_ID
        End Get
        Set(value As Object)
            _DREMPL_ID = value
        End Set
    End Property

    Public Property REMPL_ID As Object
        Get
            Return _REMPL_ID
        End Get
        Set(value As Object)
            _REMPL_ID = value
        End Set
    End Property

    Public Property DREMPL_DATE As Object
        Get
            Return _DREMPL_DATE
        End Get
        Set(value As Object)
            _DREMPL_DATE = value
        End Set
    End Property

    Public Property DREMPL_AMM As Object
        Get
            Return _DREMPL_AMM
        End Get
        Set(value As Object)
            _DREMPL_AMM = value
        End Set
    End Property

    Public Property DREMPL_TYPE As Object
        Get
            Return _DREMPL_TYPE
        End Get
        Set(value As Object)
            _DREMPL_TYPE = value
        End Set
    End Property

    Public Property DREMPL_STAT As Object
        Get
            Return _DREMPL_STAT
        End Get
        Set(value As Object)
            _DREMPL_STAT = value
        End Set
    End Property

    Public Property EMPL_ID As Object
        Get
            Return _EMPL_ID
        End Get
        Set(value As Object)
            _EMPL_ID = value
        End Set
    End Property

    Public Property REMPL_CREBY As Object
        Get
            Return _REMPL_CREBY
        End Get
        Set(value As Object)
            _REMPL_CREBY = value
        End Set
    End Property

    Public Property REMPL_RDATE As Object
        Get
            Return _REMPL_RDATE
        End Get
        Set(value As Object)
            _REMPL_RDATE = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(DREMPL_ID, REMPL_ID, DREMPL_AMM, DREMPL_TYPE, DREMPL_DATE, DREMPL_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DREMPL_ID = _DREMPL_ID
        _REMPL_ID = REMPL_ID
        _DREMPL_AMM = DREMPL_AMM
        _DREMPL_TYPE = DREMPL_TYPE
        _DREMPL_DATE = DREMPL_DATE
        _DREMPL_STAT = DREMPL_STAT
    End Sub

    Sub New(REMPL_ID, DREMPL_AMM, DREMPL_TYPE, DREMPL_DATE, DREMPL_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _DREMPL_AMM = DREMPL_AMM
        _DREMPL_TYPE = DREMPL_TYPE
        _DREMPL_DATE = DREMPL_DATE
        _DREMPL_STAT = DREMPL_STAT
    End Sub

    Public Sub InsertSaving()

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("INS_SAVINGDETAIL", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            ' LIMPIAR PARAMETROS 🔥
            DB_Command.Parameters.Clear()

            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("DREMPL_AMM", _DREMPL_AMM)
            DB_Command.Parameters.AddWithValue("DREMPL_TYPE", _DREMPL_TYPE)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)

            DB_Command.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DB_Connection.Close()
        End Try

    End Sub

    Public Function GetSavings() As DataTable

        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETSAVINGSBYRECORD", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            ' LIMPIAR PARAMETROS (CLAVE 🔥)
            DB_Command.Parameters.Clear()

            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DB_Connection.Close()
        End Try

        Return dt

    End Function

    Public Function GetEmployeeRecords() As DataTable

        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETEMPLOYEERECORDS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DB_Connection.Close()
        End Try

        Return dt

    End Function


End Class
