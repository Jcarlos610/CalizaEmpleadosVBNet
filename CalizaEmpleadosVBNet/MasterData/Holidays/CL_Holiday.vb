Imports Microsoft.Data.SqlClient

Public Class CL_Holiday

    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader


    Private _HOL_ID As Object
    Private _HOL_DATE As Object
    Private _HOL_SCHMID As Object
    Private _HOL_DATEC As Object
    Private _HOL_CREBY As Object
    Private _HOL_STAT As Object

    Public Property HOL_ID As Object
        Get
            Return _HOL_ID
        End Get
        Set(value As Object)
            _HOL_ID = value
        End Set
    End Property

    Public Property HOL_DATE As Object
        Get
            Return _HOL_DATE
        End Get
        Set(value As Object)
            _HOL_DATE = value
        End Set
    End Property

    Public Property HOL_SCHMID As Object
        Get
            Return _HOL_SCHMID
        End Get
        Set(value As Object)
            _HOL_SCHMID = value
        End Set
    End Property

    Public Property HOL_DATEC As Object
        Get
            Return _HOL_DATEC
        End Get
        Set(value As Object)
            _HOL_DATEC = value
        End Set
    End Property

    Public Property HOL_CREBY As Object
        Get
            Return _HOL_CREBY
        End Get
        Set(value As Object)
            _HOL_CREBY = value
        End Set
    End Property

    Public Property HOL_STAT As Object
        Get
            Return _HOL_STAT
        End Get
        Set(value As Object)
            _HOL_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(HOL_ID, HOL_DATE, HOL_SCHMID, HOL_DATEC, HOL_CREBY, HOL_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _HOL_ID = HOL_ID
        _HOL_DATE = HOL_DATE
        _HOL_SCHMID = HOL_SCHMID
        _HOL_DATEC = HOL_DATEC
        _HOL_CREBY = HOL_CREBY
        _HOL_STAT = HOL_STAT
    End Sub

    Sub New(HOL_DATE, HOL_SCHMID, HOL_DATEC, HOL_CREBY, HOL_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _HOL_DATE = HOL_DATE
        _HOL_SCHMID = HOL_SCHMID
        _HOL_DATEC = HOL_DATEC
        _HOL_CREBY = HOL_CREBY
        _HOL_STAT = HOL_STAT
    End Sub

    Public Function InsertHoliday()
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_HOLIDAY",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("HOL_DATE", _HOL_DATE)
            DB_Command.Parameters.AddWithValue("HOL_SCHMID", _HOL_SCHMID)
            DB_Command.Parameters.AddWithValue("HOL_CREBY", _HOL_CREBY)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Holiday.InsertHoliday()")

            Return Nothing
        End Try
    End Function


    Public Function Get_AllHolidays() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_HOLIDAYS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Holiday.Get_AllHolidays()")

            Return Nothing
        End Try
    End Function

    Public Function UpdateHoliday(ByVal HOL_ID As Integer, ByVal HOL_DATE As Date, ByVal HOL_SCHMID As Integer, ByVal HOL_STAT As Boolean)
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_HOLIDAY",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("HOL_ID", HOL_ID)
            DB_Command.Parameters.AddWithValue("HOL_DATE", HOL_DATE)
            DB_Command.Parameters.AddWithValue("HOL_SCHMID", HOL_SCHMID)
            DB_Command.Parameters.AddWithValue("HOL_STAT", HOL_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Holiday.UpdateHoliday()")

            Return Nothing
        End Try
    End Function
End Class
