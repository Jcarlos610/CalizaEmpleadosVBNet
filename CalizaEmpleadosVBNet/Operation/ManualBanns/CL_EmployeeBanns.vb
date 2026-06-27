Imports Microsoft.Data.SqlClient

Public Class CL_EmployeeBanns

    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _DREMPL_ID As Object
    Private _REMPL_ID As Object
    Private _DREMPL_DATE As Object
    Private _DREMPL_DQUANTITY As Object
    Private _DREMPL_BALANCE As Object
    Private _DREMPL_BNAME As Object
    Private _DREMPL_DESCR As Object
    Private _DREMPL_STATUS As Object
    Private _DREMPL_JUSTI As Object
    Private _DREMPL_CREBY As Object
    Private _DREMPL_DISCOUNTED As Object
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

    Public Property DREMPL_DQUANTITY As Object
        Get
            Return _DREMPL_DQUANTITY
        End Get
        Set(value As Object)
            _DREMPL_DQUANTITY = value
        End Set
    End Property

    Public Property DREMPL_BALANCE As Object
        Get
            Return _DREMPL_BALANCE
        End Get
        Set(value As Object)
            _DREMPL_BALANCE = value
        End Set
    End Property

    Public Property DREMPL_BNAME As Object
        Get
            Return _DREMPL_BNAME
        End Get
        Set(value As Object)
            _DREMPL_BNAME = value
        End Set
    End Property

    Public Property DREMPL_DESCR As Object
        Get
            Return _DREMPL_DESCR
        End Get
        Set(value As Object)
            _DREMPL_DESCR = value
        End Set
    End Property

    Public Property DREMPL_STATUS As Object
        Get
            Return _DREMPL_STATUS
        End Get
        Set(value As Object)
            _DREMPL_STATUS = value
        End Set
    End Property

    Public Property DREMPL_JUSTI As Object
        Get
            Return _DREMPL_JUSTI
        End Get
        Set(value As Object)
            _DREMPL_JUSTI = value
        End Set
    End Property

    Public Property DREMPL_CREBY As Object
        Get
            Return _DREMPL_CREBY
        End Get
        Set(value As Object)
            _DREMPL_CREBY = value
        End Set
    End Property

    Public Property DREMPL_DISCOUNTED As Object
        Get
            Return _DREMPL_DISCOUNTED
        End Get
        Set(value As Object)
            _DREMPL_DISCOUNTED = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(DREMPL_ID, REMPL_ID, DREMPL_DATE, DREMPL_DQUANTITY, DREMPL_BALANCE, DREMPL_BNAME, DREMPL_DESCR, DREMPL_STATUS, DREMPL_JUSTI, DREMPL_CREBY, DREMPL_DISCOUNTED)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DREMPL_ID = DREMPL_ID
        _REMPL_ID = REMPL_ID
        _DREMPL_DATE = DREMPL_DATE
        _DREMPL_DQUANTITY = DREMPL_DQUANTITY
        _DREMPL_BALANCE = DREMPL_BALANCE
        _DREMPL_BNAME = DREMPL_BNAME
        _DREMPL_DESCR = DREMPL_DESCR
        _DREMPL_STATUS = DREMPL_STATUS
        _DREMPL_JUSTI = DREMPL_JUSTI
        _DREMPL_CREBY = DREMPL_CREBY
        _DREMPL_DISCOUNTED = DREMPL_DISCOUNTED
    End Sub

    Sub New(REMPL_ID, DREMPL_DATE, DREMPL_DQUANTITY, DREMPL_BALANCE, DREMPL_BNAME, DREMPL_DESCR, DREMPL_STATUS, DREMPL_JUSTI, DREMPL_CREBY, DREMPL_DISCOUNTED)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _DREMPL_DATE = DREMPL_DATE
        _DREMPL_DQUANTITY = DREMPL_DQUANTITY
        _DREMPL_BALANCE = DREMPL_BALANCE
        _DREMPL_BNAME = DREMPL_BNAME
        _DREMPL_DESCR = DREMPL_DESCR
        _DREMPL_STATUS = DREMPL_STATUS
        _DREMPL_JUSTI = DREMPL_JUSTI
        _DREMPL_CREBY = DREMPL_CREBY
        _DREMPL_DISCOUNTED = DREMPL_DISCOUNTED
    End Sub

    Public Function InsertEmployeeBann() As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_EMPLOYEE_BANN",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@EMPL_ID", REMPL_ID)
            DB_Command.Parameters.AddWithValue("@DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("@DREMPL_DQUANTITY", DREMPL_DQUANTITY)
            DB_Command.Parameters.AddWithValue("@DREMPL_BNAME", DREMPL_BNAME)
            DB_Command.Parameters.AddWithValue("@DREMPL_DESCR", DREMPL_DESCR)
            DB_Command.Parameters.AddWithValue("@DREMPL_CREBY", _DREMPL_CREBY)
            DB_Command.Parameters.AddWithValue("@DREMPL_STATUS", _DREMPL_STATUS)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True

        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then
                DB_Connection.Close()
            End If

            MsgBox("Error: " & ex.Message & " CL_EmployeeBanns.InsertEmployeeBann()")
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
            MsgBox("Error en búsqueda: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetBannsHistory(ByVal employeeID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_EMPLOYEEBANNS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure
            DB_Command.Parameters.AddWithValue("@EMPL_ID", employeeID)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar historial: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function UpdateEmployeeBanns(ByVal recordId As Integer, ByVal justificacion As String, ByVal diasAsignados As Decimal) As Boolean
        Try
            DB_Command = New SqlCommand("UPD_EMPLOYEEBANNS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.AddWithValue("@DREMPL_ID", recordId)
            DB_Command.Parameters.AddWithValue("@DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("@DREMPL_DQUANTITY", diasAsignados)
            DB_Command.Parameters.AddWithValue("@DREMPL_BNAME", _DREMPL_BNAME)
            DB_Command.Parameters.AddWithValue("@DREMPL_DESCR", _DREMPL_DESCR)
            DB_Command.Parameters.AddWithValue("@DREMPL_STATUS", _DREMPL_STATUS)
            DB_Command.Parameters.AddWithValue("@DREMPL_JUSTI", justificacion)
            DB_Command.Parameters.AddWithValue("@DREMPL_CREBY", _DREMPL_CREBY)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al actualizar la amonestación: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Public Function GetAllBannsHistory(ByVal appUser As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_ALLBANNSHISTORY", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure
            DB_Command.Parameters.AddWithValue("@AppUser", appUser)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar historial general: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function ApplyBannDiscount(ByVal recordId As Integer, ByVal daysToDiscount As Decimal, ByVal commentAppend As String) As Boolean
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "UPD_APPLYBANN_DISCOUNT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Command.Parameters.AddWithValue("@DREMPL_ID", recordId)
            DB_Command.Parameters.AddWithValue("@DAYS_TO_DISCOUNT", daysToDiscount)
            DB_Command.Parameters.AddWithValue("@COMMENT", commentAppend)

            If DB_Connection.State = ConnectionState.Closed Then DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error en CL_EmployeeBanns.ApplyBannDiscount: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Public Function GetPendingBannsDetails(ByVal internalEmpID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Dim query As String = "SELECT D.DREMPL_ID, D.DREMPL_BALANCE, D.DREMPL_BNAME " &
                              "FROM OP_RecordsByEmployeeBannsDetails D " &
                              "INNER JOIN OP_RecordsByEmployee E ON D.REMPL_ID = E.REMPL_ID " &
                              "WHERE E.EMPL_ID = @EMPL_ID AND D.DREMPL_STATUS IN (1, 5) " &
                              "ORDER BY D.DREMPL_DATE ASC"

            Using cmd As New SqlCommand(query, DB_Connection)
                cmd.Parameters.AddWithValue("@EMPL_ID", internalEmpID)

                If DB_Connection.State = ConnectionState.Closed Then DB_Connection.Open()
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
                DB_Connection.Close()
            End Using
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al obtener amonestaciones pendientes: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetEmployeeBannsBalance(ByVal employeeID As Integer) As Decimal
        Dim totalBalance As Decimal = 0D
        Try
            Dim query As String = "SELECT ISNULL(SUM(D.DREMPL_BALANCE), 0) " &
                              "FROM OP_RecordsByEmployeeBannsDetails D " &
                              "INNER JOIN OP_RecordsByEmployee E ON D.REMPL_ID = E.REMPL_ID " &
                              "WHERE E.EMPL_ID = @EMPL_ID AND D.DREMPL_STATUS IN (1, 5)"

            Using cmd As New SqlCommand(query, DB_Connection)
                cmd.Parameters.AddWithValue("@EMPL_ID", employeeID)

                If DB_Connection.State = ConnectionState.Closed Then DB_Connection.Open()
                totalBalance = Convert.ToDecimal(cmd.ExecuteScalar())
                DB_Connection.Close()
            End Using
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al obtener saldo de amonestaciones: " & ex.Message)
        End Try
        Return totalBalance
    End Function
End Class
