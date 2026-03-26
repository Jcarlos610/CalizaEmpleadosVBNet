Imports Microsoft.Data.SqlClient

Public Class CL_Roles
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _ROLE_ID As Object
    Private _ROLE_NAME As Object
    Private _ROLE_DESCR As Object
    Private _ROLE_DATEC As Object
    Private _ROLE_CREBY As Object
    Private _ROLE_AUTH As Object
    Private _ROLE_STAT As Object

    Public Property ROLE_ID As Object
        Get
            Return _ROLE_ID
        End Get
        Set(value As Object)
            _ROLE_ID = value
        End Set
    End Property

    Public Property ROLE_NAME As Object
        Get
            Return _ROLE_NAME
        End Get
        Set(value As Object)
            _ROLE_NAME = value
        End Set
    End Property

    Public Property ROLE_DESCR As Object
        Get
            Return _ROLE_DESCR
        End Get
        Set(value As Object)
            _ROLE_DESCR = value
        End Set
    End Property

    Public Property ROLE_DATEC As Object
        Get
            Return _ROLE_DATEC
        End Get
        Set(value As Object)
            _ROLE_DATEC = value
        End Set
    End Property

    Public Property ROLE_CREBY As Object
        Get
            Return _ROLE_CREBY
        End Get
        Set(value As Object)
            _ROLE_CREBY = value
        End Set
    End Property

    Public Property ROLE_AUTH As Object
        Get
            Return _ROLE_AUTH
        End Get
        Set(value As Object)
            _ROLE_AUTH = value
        End Set
    End Property

    Public Property ROLE_STAT As Object
        Get
            Return _ROLE_STAT
        End Get
        Set(value As Object)
            _ROLE_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(ROLE_NAME, ROLE_DESCR, ROLE_DATEC, ROLE_CREBY, ROLE_AUTH, ROLE_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _ROLE_NAME = ROLE_NAME
        _ROLE_DESCR = ROLE_DESCR
        _ROLE_DATEC = ROLE_DATEC
        _ROLE_CREBY = ROLE_CREBY
        _ROLE_AUTH = ROLE_AUTH
        _ROLE_STAT = ROLE_STAT
    End Sub

    Sub New(ROLE_ID, ROLE_NAME, ROLE_DESCR, ROLE_DATEC, ROLE_CREBY, ROLE_AUTH, ROLE_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _ROLE_ID = ROLE_ID
        _ROLE_NAME = ROLE_NAME
        _ROLE_DESCR = ROLE_DESCR
        _ROLE_DATEC = ROLE_DATEC
        _ROLE_CREBY = ROLE_CREBY
        _ROLE_AUTH = ROLE_AUTH
        _ROLE_STAT = ROLE_STAT
    End Sub

    Public Function InsertRole()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_ROLE",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@ROLE_NAME", _ROLE_NAME)
            DB_Command.Parameters.AddWithValue("@ROLE_DESCR", _ROLE_DESCR)
            DB_Command.Parameters.AddWithValue("@ROLE_DATEC", _ROLE_DATEC)
            DB_Command.Parameters.AddWithValue("@ROLE_CREBY", _ROLE_CREBY)
            DB_Command.Parameters.AddWithValue("@ROLE_AUTH", _ROLE_AUTH)
            DB_Command.Parameters.AddWithValue("@ROLE_STAT", _ROLE_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Roles.InsertRole()")
            Return Nothing
        End Try

    End Function

    Public Function UpdateRole()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_ROLE",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@ROLE_ID", _ROLE_ID)
            DB_Command.Parameters.AddWithValue("@ROLE_NAME", _ROLE_NAME)
            DB_Command.Parameters.AddWithValue("@ROLE_DESCR", _ROLE_DESCR)
            DB_Command.Parameters.AddWithValue("@ROLE_AUTH", _ROLE_AUTH)
            DB_Command.Parameters.AddWithValue("@ROLE_STAT", _ROLE_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Roles.UpdateRole()")
            Return Nothing
        End Try

    End Function

    Public Function Get_AllRoles() As DataTable

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETALLROLES",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()

            Dim dt As New DataTable
            dt.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Roles.Get_AllRoles()")
            Return Nothing
        End Try

    End Function

    Public Function Get_ListOfRoles() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione un rol")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETLISTOFROLES",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Roles.Get_ListOfRoles()")
            Return Nothing
        End Try

    End Function

    Public Function Get_OneRole(ROLE_ID) As DataTable

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETONEROLE",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@ROLE_ID", ROLE_ID)

            DB_Reader = DB_Command.ExecuteReader()

            Dim dt As New DataTable
            dt.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Roles.Get_OneRole()")
            Return Nothing
        End Try

    End Function


End Class
