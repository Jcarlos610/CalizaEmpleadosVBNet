Imports Microsoft.Data.SqlClient

Public Class CL_EmployeeOvertime
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _OVERT_ID As Object
    Private _REMPL_ID As Object
    Private _OVERT_DATE As Object
    Private _OVERT_HOURS As Object
    Private _OVERT_CAUSE As Object
    Private _OVERT_DESCR As Object
    Private _OVERT_AUTH As Object
    Private _OVERT_CREBY As Object
    Private _OVERT_CREDATE As Object
    Private _OVERT_STATUS As Object
    Private _OVERT_TYPE As Object

    Public Property OVERT_ID As Object
        Get
            Return _OVERT_ID
        End Get
        Set(value As Object)
            _OVERT_ID = value
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

    Public Property OVERT_DATE As Object
        Get
            Return _OVERT_DATE
        End Get
        Set(value As Object)
            _OVERT_DATE = value
        End Set
    End Property

    Public Property OVERT_HOURS As Object
        Get
            Return _OVERT_HOURS
        End Get
        Set(value As Object)
            _OVERT_HOURS = value
        End Set
    End Property

    Public Property OVERT_CAUSE As Object
        Get
            Return _OVERT_CAUSE
        End Get
        Set(value As Object)
            _OVERT_CAUSE = value
        End Set
    End Property

    Public Property OVERT_DESCR As Object
        Get
            Return _OVERT_DESCR
        End Get
        Set(value As Object)
            _OVERT_DESCR = value
        End Set
    End Property

    Public Property OVERT_AUTH As Object
        Get
            Return _OVERT_AUTH
        End Get
        Set(value As Object)
            _OVERT_AUTH = value
        End Set
    End Property

    Public Property OVERT_CREBY As Object
        Get
            Return _OVERT_CREBY
        End Get
        Set(value As Object)
            _OVERT_CREBY = value
        End Set
    End Property

    Public Property OVERT_CREDATE As Object
        Get
            Return _OVERT_CREDATE
        End Get
        Set(value As Object)
            _OVERT_CREDATE = value
        End Set
    End Property

    Public Property OVERT_STATUS As Object
        Get
            Return _OVERT_STATUS
        End Get
        Set(value As Object)
            _OVERT_STATUS = value
        End Set
    End Property

    Public Property OVERT_TYPE As Object
        Get
            Return _OVERT_TYPE
        End Get
        Set(value As Object)
            _OVERT_TYPE = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(OVERT_ID, REMPL_ID, OVERT_DATE, OVERT_HOURS, OVERT_CAUSE, OVERT_DESCR, OVERT_AUTH, OVERT_CREBY, OVERT_CREDATE, OVERT_STATUS, OVERT_TYPE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _OVERT_ID = OVERT_ID
        _REMPL_ID = REMPL_ID
        _OVERT_DATE = OVERT_DATE
        _OVERT_HOURS = OVERT_HOURS
        _OVERT_CAUSE = OVERT_CAUSE
        _OVERT_DESCR = OVERT_DESCR
        _OVERT_AUTH = OVERT_AUTH
        _OVERT_CREBY = OVERT_CREBY
        _OVERT_CREDATE = OVERT_CREDATE
        _OVERT_STATUS = OVERT_STATUS
        _OVERT_TYPE = OVERT_TYPE
    End Sub

    Sub New(REMPL_ID, OVERT_DATE, OVERT_HOURS, OVERT_CAUSE, OVERT_DESCR, OVERT_AUTH, OVERT_CREBY, OVERT_CREDATE, OVERT_STATUS, OVERT_TYPE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _OVERT_DATE = OVERT_DATE
        _OVERT_HOURS = OVERT_HOURS
        _OVERT_CAUSE = OVERT_CAUSE
        _OVERT_DESCR = OVERT_DESCR
        _OVERT_AUTH = OVERT_AUTH
        _OVERT_CREBY = OVERT_CREBY
        _OVERT_CREDATE = OVERT_CREDATE
        _OVERT_STATUS = OVERT_STATUS
        _OVERT_TYPE = OVERT_TYPE
    End Sub

    Public Function InsertEmployeeOvertime() As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_EMPLOYEE_OVERTIME",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@EMPL_ID", REMPL_ID)
            DB_Command.Parameters.AddWithValue("@OVERT_DATE", OVERT_DATE)
            DB_Command.Parameters.AddWithValue("@OVERT_HOURS", OVERT_HOURS)
            DB_Command.Parameters.AddWithValue("@OVERT_CAUSE", OVERT_CAUSE)
            DB_Command.Parameters.AddWithValue("@OVERT_DESCR", If(OVERT_DESCR IsNot Nothing, OVERT_DESCR, DBNull.Value))
            DB_Command.Parameters.AddWithValue("@OVERT_AUTH", OVERT_AUTH)
            DB_Command.Parameters.AddWithValue("@OVERT_CREBY", OVERT_CREBY)
            DB_Command.Parameters.AddWithValue("@OVERT_STATUS", OVERT_STATUS)
            DB_Command.Parameters.AddWithValue("@OVERT_TYPE", OVERT_TYPE)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True

        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then
                DB_Connection.Close()
            End If

            Throw ex
            Return False
        End Try
    End Function

    Public Function GetEmployeeSuggestions(ByVal appUser As String, ByVal searchText As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_EMPLOYEESEARCHBYAREA", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.AddWithValue("@AppUser", appUser)
            DB_Command.Parameters.AddWithValue("@SearchText", searchText)
            DB_Command.Parameters.AddWithValue("@IgnoreDept", True)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()

        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error en búsqueda de empleados: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetOvertimeHistory(ByVal employeeID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_EMPLOYEEOVERTIME", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure
            DB_Command.Parameters.AddWithValue("@EMPL_ID", employeeID)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar historial de horas extras: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetAllOvertimeHistory() As DataTable

        Return GetOvertimeHistory(0)
    End Function

    Public Function UpdateEmployeeOvertime(ByVal overtID As Integer) As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_EMPLOYEE_OVERTIME",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@OVERT_ID", overtID)
            DB_Command.Parameters.AddWithValue("@OVERT_DATE", OVERT_DATE)
            DB_Command.Parameters.AddWithValue("@OVERT_HOURS", OVERT_HOURS)
            DB_Command.Parameters.AddWithValue("@OVERT_CAUSE", OVERT_CAUSE)
            DB_Command.Parameters.AddWithValue("@OVERT_DESCR", If(OVERT_DESCR IsNot Nothing, OVERT_DESCR, DBNull.Value))
            DB_Command.Parameters.AddWithValue("@OVERT_AUTH", OVERT_AUTH)
            DB_Command.Parameters.AddWithValue("@OVERT_STATUS", OVERT_STATUS)
            DB_Command.Parameters.AddWithValue("@OVERT_CREBY", OVERT_CREBY)
            DB_Command.Parameters.AddWithValue("@OVERT_TYPE", OVERT_TYPE)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            Throw ex
            Return False
        End Try
    End Function

End Class
