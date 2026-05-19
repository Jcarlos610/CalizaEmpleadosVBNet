Imports Microsoft.Data.SqlClient

Public Class CL_TemporalLunchTime
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _TEMP_LUNCH_ID As Object
    Private _EMPL_ID As Object
    Private _LUNCH_DATE As Object
    Private _LUNCH_HOURS As Object
    Private _LUNCH_CREBY As Object
    Private _LUNCH_DATEC As Object
    Private _LUNCH_STAT As Object

    Public Property TEMP_LUNCH_ID As Object
        Get
            Return _TEMP_LUNCH_ID
        End Get
        Set(value As Object)
            _TEMP_LUNCH_ID = value
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

    Public Property LUNCH_DATE As Object
        Get
            Return _LUNCH_DATE
        End Get
        Set(value As Object)
            _LUNCH_DATE = value
        End Set
    End Property

    Public Property LUNCH_HOURS As Object
        Get
            Return _LUNCH_HOURS
        End Get
        Set(value As Object)
            _LUNCH_HOURS = value
        End Set
    End Property

    Public Property LUNCH_CREBY As Object
        Get
            Return _LUNCH_CREBY
        End Get
        Set(value As Object)
            _LUNCH_CREBY = value
        End Set
    End Property

    Public Property LUNCH_DATEC As Object
        Get
            Return _LUNCH_DATEC
        End Get
        Set(value As Object)
            _LUNCH_DATEC = value
        End Set
    End Property

    Public Property LUNCH_STAT As Object
        Get
            Return _LUNCH_STAT
        End Get
        Set(value As Object)
            _LUNCH_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(TEMP_LUNCH_ID, EMPL_ID, LUNCH_DATE, LUNCH_HOURS, LUNCH_CREBY, LUNCH_DATEC, LUNCH_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _TEMP_LUNCH_ID = TEMP_LUNCH_ID
        _EMPL_ID = EMPL_ID
        _LUNCH_DATE = LUNCH_DATE
        _LUNCH_HOURS = LUNCH_HOURS
        _LUNCH_CREBY = LUNCH_CREBY
        _LUNCH_DATEC = LUNCH_DATEC
        _LUNCH_STAT = LUNCH_STAT
    End Sub

    Sub New(EMPL_ID, LUNCH_DATE, LUNCH_HOURS, LUNCH_CREBY, LUNCH_DATEC, LUNCH_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_ID = EMPL_ID
        _LUNCH_DATE = LUNCH_DATE
        _LUNCH_HOURS = LUNCH_HOURS
        _LUNCH_CREBY = LUNCH_CREBY
        _LUNCH_DATEC = LUNCH_DATEC
        _LUNCH_STAT = LUNCH_STAT
    End Sub

    Public Function InsertTemporalLunch() As Boolean
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_TEMPORAL_LUNCH",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("@LDATE", LUNCH_DATE)
            DB_Command.Parameters.AddWithValue("@LHOURS", LUNCH_HOURS)
            DB_Command.Parameters.AddWithValue("@LUSER", LUNCH_CREBY)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()

            Dim msg As String = ex.Message
            If msg.Contains("Procedure or function") Or msg.Contains("CL_") Then
                msg = "No se pudo realizar el registro. Verifique que el empleado no tenga ya un registro en este ciclo (Jueves-Miércoles)."
            End If

            MsgBox(msg, MsgBoxStyle.Exclamation, "Aviso de Validación")
            Return False
        End Try
    End Function

    Public Function GetTemporalLunchHistory(ByVal appUser As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_TEMPLUNCHDEPT", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure
            DB_Command.Parameters.AddWithValue("@AppUser", appUser)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar historial temporal: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetEmployeeSuggestions(ByVal appUser As String, ByVal searchText As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_EMPLOYEESEARCHBYAREA", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.AddWithValue("@AppUser", appUser)
            DB_Command.Parameters.AddWithValue("@SearchText", searchText)
            DB_Command.Parameters.AddWithValue("@IgnoreDept", False)

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

    Public Function UpdateTemporalLunch(ByVal id As Integer) As Boolean
        Try
            DB_Command = New SqlCommand("UPD_TEMPORALLUNCH", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.AddWithValue("@ID", id)
            DB_Command.Parameters.AddWithValue("@LHOURS", LUNCH_HOURS)
            DB_Command.Parameters.AddWithValue("@LDATE", LUNCH_DATE)
            DB_Command.Parameters.AddWithValue("@LUSER", LUNCH_CREBY)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()

            MsgBox("Error al actualizar el registro: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

End Class
