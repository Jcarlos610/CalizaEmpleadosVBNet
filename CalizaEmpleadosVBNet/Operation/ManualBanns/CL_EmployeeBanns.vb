Imports Microsoft.Data.SqlClient

Public Class CL_EmployeeBanns

    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _EBANN_ID As Object
    Private _EMPL_ID As Object
    Private _BANN_ID As Object
    Private _EBANN_DATE As Object
    Private _EBANN_CREBY As Object
    Private _EBANN_DATEC As Object
    Private _EBANN_STAT As Object

    Public Property EBANN_ID As Object
        Get
            Return _EBANN_ID
        End Get
        Set(value As Object)
            _EBANN_ID = value
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

    Public Property BANN_ID As Object
        Get
            Return _BANN_ID
        End Get
        Set(value As Object)
            _BANN_ID = value
        End Set
    End Property

    Public Property EBANN_DATE As Object
        Get
            Return _EBANN_DATE
        End Get
        Set(value As Object)
            _EBANN_DATE = value
        End Set
    End Property

    Public Property EBANN_CREBY As Object
        Get
            Return _EBANN_CREBY
        End Get
        Set(value As Object)
            _EBANN_CREBY = value
        End Set
    End Property

    Public Property EBANN_DATEC As Object
        Get
            Return _EBANN_DATEC
        End Get
        Set(value As Object)
            _EBANN_DATEC = value
        End Set
    End Property

    Public Property EBANN_STAT As Object
        Get
            Return _EBANN_STAT
        End Get
        Set(value As Object)
            _EBANN_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(EBANN_ID, EMPL_ID, BANN_ID, EBANN_DATE, EBANN_CREBY, EBANN_DATEC, EBANN_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EBANN_ID = EBANN_ID
        _EMPL_ID = EMPL_ID
        _BANN_ID = BANN_ID
        _EBANN_DATE = EBANN_DATE
        _EBANN_CREBY = EBANN_CREBY
        _EBANN_DATEC = EBANN_DATEC
        _EBANN_STAT = EBANN_STAT

    End Sub

    Sub New(EMPL_ID, BANN_ID, EBANN_DATE, EBANN_CREBY, EBANN_DATEC, EBANN_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_ID = EMPL_ID
        _BANN_ID = BANN_ID
        _EBANN_DATE = EBANN_DATE
        _EBANN_CREBY = EBANN_CREBY
        _EBANN_DATEC = EBANN_DATEC
        _EBANN_STAT = EBANN_STAT

    End Sub

    Public Function InsertEmployeeBann() As Boolean

        Try

            DB_Command = New SqlCommand With {
                .CommandText = "INS_EMPLOYEE_BANN",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()

            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("@BANN_ID", BANN_ID)
            DB_Command.Parameters.AddWithValue("@EBANN_DATE", EBANN_DATE)
            DB_Command.Parameters.AddWithValue("@EBANN_CREBY", EBANN_CREBY)
            DB_Command.Parameters.AddWithValue("@EBANN_DATEC", EBANN_DATEC)
            DB_Command.Parameters.AddWithValue("@EBANN_STAT", EBANN_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()

            Return True

        Catch ex As Exception

            If DB_Connection.State = ConnectionState.Open Then
                DB_Connection.Close()
            End If

            MsgBox("Error: " & ex.Message &
                   " CL_EmployeeBanns.InsertEmployeeBann()")

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

    Public Function GetBannTypes() As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_BANNTYPES", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()

        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar catálogo: " & ex.Message)
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

    Public Function UpdateEmployeeBanns(ByVal recordId As Integer) As Boolean
        Try
            DB_Command = New SqlCommand("UPD_EMPLOYEEBANNS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.AddWithValue("@EBANN_ID", recordId)
            DB_Command.Parameters.AddWithValue("@BANN_ID", BANN_ID)
            DB_Command.Parameters.AddWithValue("@EBANN_DATE", EBANN_DATE)
            DB_Command.Parameters.AddWithValue("@EBANN_CREBY", EBANN_CREBY)
            DB_Command.Parameters.AddWithValue("@EBANN_DATEC", Now)

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

End Class
