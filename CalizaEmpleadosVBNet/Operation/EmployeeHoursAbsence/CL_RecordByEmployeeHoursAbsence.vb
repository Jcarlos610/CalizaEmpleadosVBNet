Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.Data.SqlClient

Public Class CL_RecordByEmployeeHoursAbsence
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _HABS_ID As Object
    Private _REMPL_ID As Object
    Private _HABS_DATE As Object
    Private _HABS_HOURS As Object
    Private _HABS_CAUSE As Object
    Private _HABS_DESCR As Object
    Private _HABS_AUTH As Object
    Private _HABS_TYPE As Object
    Private _HABS_CREBY As Object
    Private _HABS_CREDATE As Object
    Private _HABS_STATUS As Object
    Private _HABS_PAID As Object
    Private _HABS_PAIDDATE As Object

    Public Property HABS_ID As Object
        Get
            Return _HABS_ID
        End Get
        Set(value As Object)
            _HABS_ID = value
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

    Public Property HABS_DATE As Object
        Get
            Return _HABS_DATE
        End Get
        Set(value As Object)
            _HABS_DATE = value
        End Set
    End Property

    Public Property HABS_HOURS As Object
        Get
            Return _HABS_HOURS
        End Get
        Set(value As Object)
            _HABS_HOURS = value
        End Set
    End Property

    Public Property HABS_CAUSE As Object
        Get
            Return _HABS_CAUSE
        End Get
        Set(value As Object)
            _HABS_CAUSE = value
        End Set
    End Property

    Public Property HABS_DESCR As Object
        Get
            Return _HABS_DESCR
        End Get
        Set(value As Object)
            _HABS_DESCR = value
        End Set
    End Property

    Public Property HABS_AUTH As Object
        Get
            Return _HABS_AUTH
        End Get
        Set(value As Object)
            _HABS_AUTH = value
        End Set
    End Property

    Public Property HABS_TYPE As Object
        Get
            Return _HABS_TYPE
        End Get
        Set(value As Object)
            _HABS_TYPE = value
        End Set
    End Property

    Public Property HABS_CREBY As Object
        Get
            Return _HABS_CREBY
        End Get
        Set(value As Object)
            _HABS_CREBY = value
        End Set
    End Property

    Public Property HABS_CREDATE As Object
        Get
            Return _HABS_CREDATE
        End Get
        Set(value As Object)
            _HABS_CREDATE = value
        End Set
    End Property

    Public Property HABS_STATUS As Object
        Get
            Return _HABS_STATUS
        End Get
        Set(value As Object)
            _HABS_STATUS = value
        End Set
    End Property

    Public Property HABS_PAID As Object
        Get
            Return _HABS_PAID
        End Get
        Set(value As Object)
            _HABS_PAID = value
        End Set
    End Property

    Public Property HABS_PAIDDATE As Object
        Get
            Return _HABS_PAIDDATE
        End Get
        Set(value As Object)
            _HABS_PAIDDATE = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(HABS_ID, REMPL_ID, HABS_DATE, HABS_HOURS, HABS_CAUSE, HABS_DESCR, HABS_AUTH, HABS_TYPE, HABS_CREBY, HABS_CREDATE, HABS_STATUS, HABS_PAID, HABS_PAIDDATE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _HABS_ID = HABS_ID
        _REMPL_ID = REMPL_ID
        _HABS_DATE = HABS_DATE
        _HABS_HOURS = HABS_HOURS
        _HABS_CAUSE = HABS_CAUSE
        _HABS_DESCR = HABS_DESCR
        _HABS_AUTH = HABS_AUTH
        _HABS_TYPE = HABS_TYPE
        _HABS_CREBY = HABS_CREBY
        _HABS_CREDATE = HABS_CREDATE
        _HABS_STATUS = HABS_STATUS
        _HABS_PAID = HABS_PAID
        _HABS_PAIDDATE = HABS_PAIDDATE
    End Sub

    Sub New(REMPL_ID, HABS_DATE, HABS_HOURS, HABS_CAUSE, HABS_DESCR, HABS_AUTH, HABS_TYPE, HABS_CREBY, HABS_CREDATE, HABS_STATUS, HABS_PAID, HABS_PAIDDATE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _HABS_DATE = HABS_DATE
        _HABS_HOURS = HABS_HOURS
        _HABS_CAUSE = HABS_CAUSE
        _HABS_DESCR = HABS_DESCR
        _HABS_AUTH = HABS_AUTH
        _HABS_TYPE = HABS_TYPE
        _HABS_CREBY = HABS_CREBY
        _HABS_CREDATE = HABS_CREDATE
        _HABS_STATUS = HABS_STATUS
        _HABS_PAID = HABS_PAID
        _HABS_PAIDDATE = HABS_PAIDDATE
    End Sub

    Public Function InsertHoursAbsenceRecord() As Boolean
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_RECORDBYEMPLOYEEHOURSABSENCE",
            .CommandType = CommandType.StoredProcedure
        }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@EMPL_ID", REMPL_ID)
            DB_Command.Parameters.AddWithValue("@HABS_DATE", HABS_DATE)
            DB_Command.Parameters.AddWithValue("@HABS_HOURS", HABS_HOURS)
            DB_Command.Parameters.AddWithValue("@HABS_CAUSE", If(HABS_CAUSE IsNot Nothing, HABS_CAUSE, DBNull.Value))
            DB_Command.Parameters.AddWithValue("@HABS_DESCR", If(HABS_DESCR IsNot Nothing, HABS_DESCR, DBNull.Value))
            DB_Command.Parameters.AddWithValue("@HABS_AUTH", If(HABS_AUTH IsNot Nothing, HABS_AUTH, DBNull.Value))
            DB_Command.Parameters.AddWithValue("@HABS_CREBY", HABS_CREBY)
            DB_Command.Parameters.AddWithValue("@HABS_STATUS", HABS_STATUS)
            DB_Command.Parameters.AddWithValue("@HABS_TYPE", HABS_TYPE)

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

    Public Function Get_AllHoursAbsenceRecords(Optional ByVal EMPL_ID As Integer = 0) As DataTable
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_RECORDBYEMPLOYEEHOURSABSENCE",
            .CommandType = CommandType.StoredProcedure
        }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable
            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployeeHoursAbsence.Get_AllHoursAbsenceRecords()")
            Return Nothing
        End Try
    End Function

    Public Function Get_HoursAbsenceByEmployee(ByVal startDate As Date, ByVal endDate As Date, ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_HOURSABSENCEBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("startDate", startDate)
            DB_Command.Parameters.AddWithValue("endDate", endDate)
            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", MOVE_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable
            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployeeHoursAbsence.Get_HoursAbsenceByEmployee()")
            Return Nothing
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

    Public Function UpdateHoursAbsenceRecord(ByVal habsID As Integer) As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_RECORDBYEMPLOYEEHOURSABSENCE",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@HABS_ID", habsID)
            DB_Command.Parameters.AddWithValue("@HABS_DATE", HABS_DATE)
            DB_Command.Parameters.AddWithValue("@HABS_HOURS", HABS_HOURS)
            DB_Command.Parameters.AddWithValue("@HABS_CAUSE", HABS_CAUSE)
            DB_Command.Parameters.AddWithValue("@HABS_DESCR", If(HABS_DESCR IsNot Nothing, HABS_DESCR, DBNull.Value))
            DB_Command.Parameters.AddWithValue("@HABS_AUTH", HABS_AUTH)
            DB_Command.Parameters.AddWithValue("@HABS_STATUS", HABS_STATUS)
            DB_Command.Parameters.AddWithValue("@HABS_CREBY", HABS_CREBY)
            DB_Command.Parameters.AddWithValue("@HABS_TYPE", HABS_TYPE)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            Throw ex
            Return False
        End Try
    End Function


    Public Function MarkHoursAbsenceAsPaid(ByVal EMPL_ID As Integer, ByVal startDate As Date, ByVal endDate As Date) As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_MARKHOURSABSENCEASPAID",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("@startDate", startDate)
            DB_Command.Parameters.AddWithValue("@endDate", endDate)
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployeeHoursAbsence.MarkHoursAbsenceAsPaid()")
            Return False
        End Try
    End Function

End Class
