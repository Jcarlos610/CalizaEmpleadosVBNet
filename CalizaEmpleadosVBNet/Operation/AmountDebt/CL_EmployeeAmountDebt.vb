Imports Microsoft.Data.SqlClient

Public Class CL_EmployeeAmountDebt
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _DAMT_ID As Object
    Private _REMPL_ID As Object
    Private _DAMT_DATE As Object
    Private _DAMT_CAUSE As Object
    Private _DAMT_DESCR As Object
    Private _DAMT_TOTAL_AMOUNT As Object
    Private _DAMT_PERIODIC_DISCOUNT As Object
    Private _DAMT_AUTH As Object
    Private _DAMT_STATUS As Object
    Private _DAMT_CREBY As Object
    Private _DAMT_RDATE As Object
    Private _DAMT_CURRENT_BALANCE As Object
    Private _DAMT_PAYMENT_STATUS As Object


    Public Property DAMT_ID As Object
        Get
            Return _DAMT_ID
        End Get
        Set(value As Object)
            _DAMT_ID = value
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

    Public Property DAMT_DATE As Object
        Get
            Return _DAMT_DATE
        End Get
        Set(value As Object)
            _DAMT_DATE = value
        End Set
    End Property

    Public Property DAMT_CAUSE As Object
        Get
            Return _DAMT_CAUSE
        End Get
        Set(value As Object)
            _DAMT_CAUSE = value
        End Set
    End Property

    Public Property DAMT_DESCR As Object
        Get
            Return _DAMT_DESCR
        End Get
        Set(value As Object)
            _DAMT_DESCR = value
        End Set
    End Property

    Public Property DAMT_TOTAL_AMOUNT As Object
        Get
            Return _DAMT_TOTAL_AMOUNT
        End Get
        Set(value As Object)
            _DAMT_TOTAL_AMOUNT = value
        End Set
    End Property

    Public Property DAMT_PERIODIC_DISCOUNT As Object
        Get
            Return _DAMT_PERIODIC_DISCOUNT
        End Get
        Set(value As Object)
            _DAMT_PERIODIC_DISCOUNT = value
        End Set
    End Property

    Public Property DAMT_AUTH As Object
        Get
            Return _DAMT_AUTH
        End Get
        Set(value As Object)
            _DAMT_AUTH = value
        End Set
    End Property

    Public Property DAMT_STATUS As Object
        Get
            Return _DAMT_STATUS
        End Get
        Set(value As Object)
            _DAMT_STATUS = value
        End Set
    End Property

    Public Property DAMT_CREBY As Object
        Get
            Return _DAMT_CREBY
        End Get
        Set(value As Object)
            _DAMT_CREBY = value
        End Set
    End Property

    Public Property DAMT_RDATE As Object
        Get
            Return _DAMT_RDATE
        End Get
        Set(value As Object)
            _DAMT_RDATE = value
        End Set
    End Property

    Public Property DAMT_CURRENT_BALANCE As Object
        Get
            Return _DAMT_CURRENT_BALANCE
        End Get
        Set(value As Object)
            _DAMT_CURRENT_BALANCE = value
        End Set
    End Property

    Public Property DAMT_PAYMENT_STATUS As Object
        Get
            Return _DAMT_PAYMENT_STATUS
        End Get
        Set(value As Object)
            _DAMT_PAYMENT_STATUS = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(DAMT_ID, REMPL_ID, DAMT_DATE, DAMT_CAUSE, DAMT_DESCR, DAMT_TOTAL_AMOUNT, DAMT_PERIODIC_DISCOUNT, DAMT_AUTH, DAMT_STATUS, DAMT_CREBY, DAMT_RDATE, DAMT_CURRENT_BALANCE, DAMT_PAYMENT_STATUS)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DAMT_ID = DAMT_ID
        _REMPL_ID = REMPL_ID
        _DAMT_DATE = DAMT_DATE
        _DAMT_CAUSE = DAMT_CAUSE
        _DAMT_DESCR = DAMT_DESCR
        _DAMT_TOTAL_AMOUNT = DAMT_TOTAL_AMOUNT
        _DAMT_PERIODIC_DISCOUNT = DAMT_PERIODIC_DISCOUNT
        _DAMT_AUTH = DAMT_AUTH
        _DAMT_STATUS = DAMT_STATUS
        _DAMT_CREBY = DAMT_CREBY
        _DAMT_RDATE = DAMT_RDATE
        _DAMT_CURRENT_BALANCE = DAMT_CURRENT_BALANCE
        _DAMT_PAYMENT_STATUS = DAMT_PAYMENT_STATUS
    End Sub

    Sub New(REMPL_ID, DAMT_DATE, DAMT_CAUSE, DAMT_DESCR, DAMT_TOTAL_AMOUNT, DAMT_PERIODIC_DISCOUNT, DAMT_AUTH, DAMT_STATUS, DAMT_CREBY, DAMT_RDATE, DAMT_CURRENT_BALANCE, DAMT_PAYMENT_STATUS)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _DAMT_DATE = DAMT_DATE
        _DAMT_CAUSE = DAMT_CAUSE
        _DAMT_DESCR = DAMT_DESCR
        _DAMT_TOTAL_AMOUNT = DAMT_TOTAL_AMOUNT
        _DAMT_PERIODIC_DISCOUNT = DAMT_PERIODIC_DISCOUNT
        _DAMT_AUTH = DAMT_AUTH
        _DAMT_STATUS = DAMT_STATUS
        _DAMT_CREBY = DAMT_CREBY
        _DAMT_RDATE = DAMT_RDATE
        _DAMT_CURRENT_BALANCE = DAMT_CURRENT_BALANCE
        _DAMT_PAYMENT_STATUS = DAMT_PAYMENT_STATUS
    End Sub


    Public Function InsertEmployeeDebt() As Boolean
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_EMPLOYEE_AMOUNTDEBT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@EMPL_ID", REMPL_ID)
            DB_Command.Parameters.AddWithValue("@DAMT_DATE", _DAMT_DATE)
            DB_Command.Parameters.AddWithValue("@DAMT_CAUSE", DAMT_CAUSE)
            DB_Command.Parameters.AddWithValue("@DAMT_DESCR", DAMT_DESCR)
            DB_Command.Parameters.AddWithValue("@DAMT_TOTAL_AMOUNT", DAMT_TOTAL_AMOUNT)
            DB_Command.Parameters.AddWithValue("@DAMT_PERIODIC_DISCOUNT", DAMT_PERIODIC_DISCOUNT)
            DB_Command.Parameters.AddWithValue("@DAMT_AUTH", DAMT_AUTH)
            DB_Command.Parameters.AddWithValue("@DAMT_CREBY", _DAMT_CREBY)
            DB_Command.Parameters.AddWithValue("@DAMT_STATUS", _DAMT_STATUS)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error en CL_EmployeeAmountDebt.InsertEmployeeDebt(): " & ex.Message)
            Return False
        End Try
    End Function

    Public Function GetEmployeeSuggestions(ByVal appUser As String, ByVal searchText As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_EMPLOYEESEARCHBYAREA", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
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

    Public Function GetDebtsHistory(ByVal employeeID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_EMPLOYEEAMOUNTDEBTS", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@EMPL_ID", employeeID)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar historial de adeudos: " & ex.Message)
        End Try
        Return dt
    End Function


    Public Function UpdateEmployeeDebt(ByVal recordId As Integer) As Boolean
        Try
            DB_Command = New SqlCommand("UPD_EMPLOYEE_AMOUNTDEBT", DB_Connection) With {.CommandType = CommandType.StoredProcedure}

            DB_Command.Parameters.AddWithValue("@DAMT_ID", recordId)
            DB_Command.Parameters.AddWithValue("@DAMT_DATE", _DAMT_DATE)
            DB_Command.Parameters.AddWithValue("@DAMT_CAUSE", DAMT_CAUSE)
            DB_Command.Parameters.AddWithValue("@DAMT_DESCR", DAMT_DESCR)
            DB_Command.Parameters.AddWithValue("@DAMT_TOTAL_AMOUNT", DAMT_TOTAL_AMOUNT)
            DB_Command.Parameters.AddWithValue("@DAMT_CURRENT_BALANCE", DAMT_CURRENT_BALANCE)
            DB_Command.Parameters.AddWithValue("@DAMT_PERIODIC_DISCOUNT", DAMT_PERIODIC_DISCOUNT)
            DB_Command.Parameters.AddWithValue("@DAMT_PAYMENT_STATUS", DAMT_PAYMENT_STATUS)
            DB_Command.Parameters.AddWithValue("@DAMT_AUTH", DAMT_AUTH)
            DB_Command.Parameters.AddWithValue("@DAMT_CREBY", _DAMT_CREBY)
            DB_Command.Parameters.AddWithValue("@DAMT_STATUS", _DAMT_STATUS)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al actualizar el adeudo en BD (UpdateEmployeeDebt): " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

End Class
