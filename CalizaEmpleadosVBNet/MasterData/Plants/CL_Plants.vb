Imports Microsoft.Data.SqlClient

Public Class CL_Plants
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _PLANT_ID As Object
    Private _PLANT_NAME As Object
    Private _PLANT_DESCR As Object
    Private _PLANT_DATEC As Object
    Private _PLANT_CREBY As Object
    Private _PLANT_STAT As Object

    Public Property PLANT_ID As Object
        Get
            Return _PLANT_ID
        End Get
        Set(value As Object)
            _PLANT_ID = value
        End Set
    End Property

    Public Property PLANT_NAME As Object
        Get
            Return _PLANT_NAME
        End Get
        Set(value As Object)
            _PLANT_NAME = value
        End Set
    End Property

    Public Property PLANT_DESCR As Object
        Get
            Return _PLANT_DESCR
        End Get
        Set(value As Object)
            _PLANT_DESCR = value
        End Set
    End Property

    Public Property PLANT_DATEC As Object
        Get
            Return _PLANT_DATEC
        End Get
        Set(value As Object)
            _PLANT_DATEC = value
        End Set
    End Property

    Public Property PLANT_CREBY As Object
        Get
            Return _PLANT_CREBY
        End Get
        Set(value As Object)
            _PLANT_CREBY = value
        End Set
    End Property

    Public Property PLANT_STAT As Object
        Get
            Return _PLANT_STAT
        End Get
        Set(value As Object)
            _PLANT_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub


    Sub New(PLANT_ID, PLANT_NAME, PLANT_DESCR, PLANT_DATEC, PLANT_CREBY, PLANT_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _PLANT_ID = PLANT_ID
        _PLANT_NAME = PLANT_NAME
        _PLANT_DESCR = PLANT_DESCR
        _PLANT_DATEC = PLANT_DATEC
        _PLANT_CREBY = PLANT_CREBY
        _PLANT_STAT = PLANT_STAT

    End Sub

    Sub New(PLANT_NAME, PLANT_DESCR, PLANT_DATEC, PLANT_CREBY, PLANT_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _PLANT_NAME = PLANT_NAME
        _PLANT_DESCR = PLANT_DESCR
        _PLANT_DATEC = PLANT_DATEC
        _PLANT_CREBY = PLANT_CREBY
        _PLANT_STAT = PLANT_STAT

    End Sub

    Public Function InsertPlant() As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_PLANT",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("PLANT_NAME", _PLANT_NAME)
            DB_Command.Parameters.AddWithValue("PLANT_DESCR", _PLANT_DESCR)
            DB_Command.Parameters.AddWithValue("PLANT_DATEC", DateTime.Now)
            DB_Command.Parameters.AddWithValue("PLANT_CREBY", GlobalSession.GlobalUserName)
            DB_Command.Parameters.AddWithValue("PLANT_STAT", True)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Plants.InsertPlant()")
            Return Nothing
        End Try
    End Function

    Public Function UpdatePlant() As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_PLANT",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("PLANT_ID", _PLANT_ID)
            DB_Command.Parameters.AddWithValue("PLANT_NAME", _PLANT_NAME)
            DB_Command.Parameters.AddWithValue("PLANT_DESCR", _PLANT_DESCR)
            DB_Command.Parameters.AddWithValue("PLANT_STAT", _PLANT_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Plants.UpdatePlant()")
            Return Nothing
        End Try
    End Function

    Public Function Get_AllPlants() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_GETALLPLANTS",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Plants.Get_AllPlants()")
            Return Nothing
        End Try
    End Function

    Public Function Get_ListOfPlants() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione una planta")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETLISTOFPLANTS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Plants.Get_ListOfPlants()")
            Return Nothing
        End Try
    End Function

    Public Function Get_OnePlant(PLANT_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETONEPLANT",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("PLANT_ID", PLANT_ID)
            DB_Reader = DB_Command.ExecuteReader()

            Dim LocalTable As New DataTable
            LocalTable.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Plants.Get_OnePlant()")
            Return Nothing
        End Try
    End Function

End Class
