Imports Microsoft.Data.SqlClient
Public Class CL_Departments

    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _DEPT_ID As Object
    Private _DEPT_NAME As Object
    Private _DEPT_DESCR As Object
    Private _DEPT_AUTH As Object
    Private _DEPT_CREBY As Object
    Private _DEPT_DATEC As Object
    Private _DEPT_STAT As Object

    Public Property DEPT_ID As Object
        Get
            Return _DEPT_ID
        End Get
        Set(value As Object)
            _DEPT_ID = value
        End Set
    End Property

    Public Property DEPT_NAME As Object
        Get
            Return _DEPT_NAME
        End Get
        Set(value As Object)
            _DEPT_NAME = value
        End Set
    End Property

    Public Property DEPT_DESCR As Object
        Get
            Return _DEPT_DESCR
        End Get
        Set(value As Object)
            _DEPT_DESCR = value
        End Set
    End Property

    Public Property DEPT_AUTH As Object
        Get
            Return _DEPT_AUTH
        End Get
        Set(value As Object)
            _DEPT_AUTH = value
        End Set
    End Property

    Public Property DEPT_CREBY As Object
        Get
            Return _DEPT_CREBY
        End Get
        Set(value As Object)
            _DEPT_CREBY = value
        End Set
    End Property

    Public Property DEPT_DATEC As Object
        Get
            Return _DEPT_DATEC
        End Get
        Set(value As Object)
            _DEPT_DATEC = value
        End Set
    End Property

    Public Property DEPT_STAT As Object
        Get
            Return _DEPT_STAT
        End Get
        Set(value As Object)
            _DEPT_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(DEPT_NAME, DEPT_DESCR, DEPT_AUTH, DEPT_CREBY, DEPT_DATEC, DEPT_STAT)

        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DEPT_NAME = DEPT_NAME
        _DEPT_DESCR = DEPT_DESCR
        _DEPT_AUTH = DEPT_AUTH
        _DEPT_CREBY = DEPT_CREBY
        _DEPT_DATEC = DEPT_DATEC
        _DEPT_STAT = DEPT_STAT

    End Sub

    Sub New(DEPT_ID, DEPT_NAME, DEPT_DESCR, DEPT_AUTH, DEPT_CREBY, DEPT_DATEC, DEPT_STAT)

        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _DEPT_ID = DEPT_ID
        _DEPT_NAME = DEPT_NAME
        _DEPT_DESCR = DEPT_DESCR
        _DEPT_AUTH = DEPT_AUTH
        _DEPT_CREBY = DEPT_CREBY
        _DEPT_DATEC = DEPT_DATEC
        _DEPT_STAT = DEPT_STAT

    End Sub

    Public Function InsertDepartment()

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_DEPARTMENT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@DEPT_NAME", _DEPT_NAME)
            DB_Command.Parameters.AddWithValue("@DEPT_DESCR", _DEPT_DESCR)
            DB_Command.Parameters.AddWithValue("@DEPT_AUTH", _DEPT_AUTH)
            DB_Command.Parameters.AddWithValue("@DEPT_CREBY", AppUser)
            DB_Command.Parameters.AddWithValue("@DEPT_DATEC", Date.Today)
            DB_Command.Parameters.AddWithValue("@DEPT_STAT", _DEPT_STAT)


            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Departments.InsertDiscount()")

            Return Nothing
        End Try

    End Function

    Public Function UpdateDepartment()

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "UPD_DEPARTMENT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("DEPT_ID", _DEPT_ID)
            DB_Command.Parameters.AddWithValue("@DEPT_NAME", _DEPT_NAME)
            DB_Command.Parameters.AddWithValue("@DEPT_DESCR", _DEPT_DESCR)
            DB_Command.Parameters.AddWithValue("@DEPT_AUTH", _DEPT_AUTH)
            'DB_Command.Parameters.AddWithValue("@DEPT_CREBY", _DEPT_CREBY)
            'DB_Command.Parameters.AddWithValue("@DEPT_DATEC", _DEPT_DATEC)
            DB_Command.Parameters.AddWithValue("@DEPT_STAT", _DEPT_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Departments.UpdateDiscount()")

            Return Nothing
        End Try

    End Function

    Public Function Get_AllDepartments() As DataTable

        Try

            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_GETALLDEPARTMENTS",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()

            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()

            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()

            Return LocalTable

        Catch ex As Exception

            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Departments.Get_AllDepartments()")

            Return Nothing

        End Try

    End Function

    Public Function Get_ListOfDepartments() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione un departamento")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETLISTOFDEPARTMENTS",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Departments.Get_ListOfDepartments()")

            Return Nothing
        End Try

    End Function

    Public Function Get_OneDepartment(DEPT_ID) As DataTable

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_GETONEDEPARTMENT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("DEPT_ID", DEPT_ID)

            DB_Reader = DB_Command.ExecuteReader()

            Dim LocalTable As New DataTable
            LocalTable.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()

            Return LocalTable

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Departments.Get_OneDepartment()")

            Return Nothing
        End Try

    End Function


End Class
