Imports Microsoft.Data.SqlClient

Public Class CL_Incidents
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _DREMPL_ID As Object
    Private _REMPL_ID As Object
    Private _INC_DATEFR As Object
    Private _INC_DATETO As Object
    Private _INC_DAYS As Object
    Private _INC_DESCR As Object
    Private _INC_AUTH As Object
    Private _INC_STAT As Object

    Private _EMPL_ID As Object
    Private _MOVE_ID As Object
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

    Public Property INC_DATEFR As Object
        Get
            Return _INC_DATEFR
        End Get
        Set(value As Object)
            _INC_DATEFR = value
        End Set
    End Property

    Public Property INC_DATETO As Object
        Get
            Return _INC_DATETO
        End Get
        Set(value As Object)
            _INC_DATETO = value
        End Set
    End Property

    Public Property INC_DAYS As Object
        Get
            Return _INC_DAYS
        End Get
        Set(value As Object)
            _INC_DAYS = value
        End Set
    End Property

    Public Property INC_DESCR As Object
        Get
            Return _INC_DESCR
        End Get
        Set(value As Object)
            _INC_DESCR = value
        End Set
    End Property

    Public Property INC_AUTH As Object
        Get
            Return _INC_AUTH
        End Get
        Set(value As Object)
            _INC_AUTH = value
        End Set
    End Property

    Public Property INC_STAT As Object
        Get
            Return _INC_STAT
        End Get
        Set(value As Object)
            _INC_STAT = value
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

    Public Property MOVE_ID As Object
        Get
            Return _MOVE_ID
        End Get
        Set(value As Object)
            _MOVE_ID = value
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


    Sub New(DREMPL_ID, REMPL_ID, INC_DATEFR, INC_DATETO, INC_DAYS, INC_DESCR, INC_AUTH, INC_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DREMPL_ID = DREMPL_ID
        _REMPL_ID = REMPL_ID
        _INC_DATEFR = INC_DATEFR
        _INC_DATETO = INC_DATETO
        _INC_DAYS = INC_DAYS
        _INC_DESCR = INC_DESCR
        _INC_AUTH = INC_AUTH
        _INC_STAT = INC_STAT

    End Sub

    Sub New(REMPL_ID, INC_DATEFR, INC_DATETO, INC_DAYS, INC_DESCR, INC_AUTH, INC_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _INC_DATEFR = INC_DATEFR
        _INC_DATETO = INC_DATETO
        _INC_DAYS = INC_DAYS
        _INC_DESCR = INC_DESCR
        _INC_AUTH = INC_AUTH
        _INC_STAT = INC_STAT

    End Sub



    Public Function InsertIncident() As Boolean

        Dim Result As Boolean = False

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("INS_EMPLOYEEBYINCIDENT", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("@MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("@REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("@REMPL_RDATE", _REMPL_RDATE)

            DB_Command.Parameters.AddWithValue("@DATE_FROM", _INC_DATEFR)
            DB_Command.Parameters.AddWithValue("@DATE_TO", _INC_DATETO)
            DB_Command.Parameters.AddWithValue("@DAYS", _INC_DAYS)
            DB_Command.Parameters.AddWithValue("@DESCR", _INC_DESCR)
            DB_Command.Parameters.AddWithValue("@AUTH", _INC_AUTH)
            DB_Command.Parameters.AddWithValue("@STAT", _INC_STAT)

            DB_Command.ExecuteNonQuery()

            Result = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Result = False
        Finally
            DB_Connection.Close()
        End Try

        Return Result

    End Function
    Public Function GetAllEmployeesInfo() As DataTable
        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETEMPLOYEESINFO", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al obtener empleados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try

        Return dt
    End Function

    Public Function GetIncidents() As DataTable
        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETINCIDENTS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            DB_Connection.Close()
        End Try

        Return dt
    End Function

End Class
