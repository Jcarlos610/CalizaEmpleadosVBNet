Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports Microsoft.Data.SqlClient

Public Class CL_EntryExitFile
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _HFILE_ID As Object
    Private _HFILE_TYPE As Object
    Private _HFILE_NAME As Object
    Private _HFILE_RECOR As Object
    Private _HFILE_COME As Object
    Private _HFILE_CREBY As Object
    Private _HFILE_RDATE As Object

    Private _IFILE_ID As Object
    Private _EMPL_ID As Object
    Private _ENTTYPE_ID As Object
    Private _IFILE_DATE As Object
    Private _IFILE_TIME As Object
    Private _IFILE_DATI As Object

    Private _EXTTYPE_ID As Object

    Public Property HFILE_ID As Object
        Get
            Return _HFILE_ID
        End Get
        Set(value As Object)
            _HFILE_ID = value
        End Set
    End Property

    Public Property HFILE_NAME As Object
        Get
            Return _HFILE_NAME
        End Get
        Set(value As Object)
            _HFILE_NAME = value
        End Set
    End Property

    Public Property HFILE_RECOR As Object
        Get
            Return _HFILE_RECOR
        End Get
        Set(value As Object)
            _HFILE_RECOR = value
        End Set
    End Property

    Public Property HFILE_COME As Object
        Get
            Return _HFILE_COME
        End Get
        Set(value As Object)
            _HFILE_COME = value
        End Set
    End Property

    Public Property HFILE_CREBY As Object
        Get
            Return _HFILE_CREBY
        End Get
        Set(value As Object)
            _HFILE_CREBY = value
        End Set
    End Property

    Public Property HFILE_RDATE As Object
        Get
            Return _HFILE_RDATE
        End Get
        Set(value As Object)
            _HFILE_RDATE = value
        End Set
    End Property

    Public Property IFILE_ID As Object
        Get
            Return _IFILE_ID
        End Get
        Set(value As Object)
            _IFILE_ID = value
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

    Public Property ENTTYPE_ID As Object
        Get
            Return _ENTTYPE_ID
        End Get
        Set(value As Object)
            _ENTTYPE_ID = value
        End Set
    End Property

    Public Property IFILE_DATE As Object
        Get
            Return _IFILE_DATE
        End Get
        Set(value As Object)
            _IFILE_DATE = value
        End Set
    End Property

    Public Property IFILE_TIME As Object
        Get
            Return _IFILE_TIME
        End Get
        Set(value As Object)
            _IFILE_TIME = value
        End Set
    End Property

    Public Property HFILE_TYPE As Object
        Get
            Return _HFILE_TYPE
        End Get
        Set(value As Object)
            _HFILE_TYPE = value
        End Set
    End Property

    Public Property IFILE_DATI As Object
        Get
            Return _IFILE_DATI
        End Get
        Set(value As Object)
            _IFILE_DATI = value
        End Set
    End Property

    Public Property EXTTYPE_ID As Object
        Get
            Return _EXTTYPE_ID
        End Get
        Set(value As Object)
            _EXTTYPE_ID = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    'Header Constructor
    Sub New(HFILE_TYPE, HFILE_NAME, HFILE_RECOR, HFILE_COME, HFILE_CREBY, HFILE_RDATE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _HFILE_TYPE = HFILE_TYPE
        _HFILE_NAME = HFILE_NAME
        _HFILE_RECOR = HFILE_RECOR
        _HFILE_COME = HFILE_COME
        _HFILE_CREBY = HFILE_CREBY
        _HFILE_RDATE = HFILE_RDATE
    End Sub

    'Item Constructor
    Sub New(HFILE_ID, HFILE_TYPE, EMPL_ID, ENTTYPE_ID, IFILE_DATE, IFILE_TIME, IFILE_DATI)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _HFILE_ID = HFILE_ID
        _HFILE_TYPE = HFILE_TYPE
        _EMPL_ID = EMPL_ID
        _ENTTYPE_ID = ENTTYPE_ID
        _IFILE_DATE = IFILE_DATE
    End Sub

    Public Function InsertAsistanceFileHeader(conn As SqlConnection, trans As SqlTransaction) As Integer

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_ENTRYEXITFILEHEADER",
                .CommandType = CommandType.StoredProcedure,
                .Connection = conn,
                .Transaction = trans
            }

            DB_Command.Parameters.AddWithValue("HFILE_TYPE", _HFILE_TYPE)
            DB_Command.Parameters.AddWithValue("HFILE_NAME", _HFILE_NAME)
            DB_Command.Parameters.AddWithValue("HFILE_RECOR", _HFILE_RECOR)
            DB_Command.Parameters.AddWithValue("HFILE_COME", _HFILE_COME)
            DB_Command.Parameters.AddWithValue("HFILE_CREBY", _HFILE_CREBY)
            DB_Command.Parameters.AddWithValue("HFILE_RDATE", _HFILE_RDATE)

            Dim HeaderId As Integer = Convert.ToInt32(DB_Command.ExecuteScalar())

            Return HeaderId
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AsistanceFilesHeader.InsertAsistanceFile()")

            Return Nothing
        End Try
    End Function

    Public Sub InsertAsistanceFileItem(conn As SqlConnection, trans As SqlTransaction)

        DB_Command = New SqlCommand With {
            .CommandText = "INS_ENTRYEXITFILEITEM",
            .CommandType = CommandType.StoredProcedure,
            .Connection = conn,
            .Transaction = trans
        }

        DB_Command.Parameters.AddWithValue("@HFILE_ID", _HFILE_ID)
        DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
        DB_Command.Parameters.AddWithValue("@ENTTYPE_ID", _ENTTYPE_ID)
        DB_Command.Parameters.AddWithValue("@IFILE_DATE", _IFILE_DATE)
        DB_Command.Parameters.AddWithValue("@IFILE_TIME", _IFILE_TIME)
        DB_Command.Parameters.AddWithValue("@IFILE_DATI", _IFILE_DATI)

        DB_Command.ExecuteNonQuery()

    End Sub

    Public Function FileAlreadyExists(conn As SqlConnection) As Boolean

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_ASISTANCEFILEEXIST",
                .CommandType = CommandType.StoredProcedure,
                .Connection = conn
            }
            DB_Command.Parameters.AddWithValue("@HFILE_TYPE", _HFILE_TYPE)
            DB_Command.Parameters.AddWithValue("@HFILE_NAME", _HFILE_NAME)

            Dim Result As Integer = Convert.ToInt32(DB_Command.ExecuteScalar())

            If Result > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            MsgBox("Ocurrió el siguiente error: " & ex.Message & " CL_AsistanceFiles.FileAlreadyExists()")
            Return False

        End Try

    End Function

    Public Function Get_EntryExitRecordByEmployeeID() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETENTRYEXITRECORDSBYEMPLOYEEINFO",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@HFILE_TYPE", _HFILE_TYPE)
            DB_Command.Parameters.AddWithValue("@HFILE_NAME", _HFILE_NAME)
            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AsistanceFiles.Get_EntryExitRecordByEmployeeID()")

            Return Nothing
        End Try
    End Function

    Public Function Get_EntryExitRecordByEmployeeIDEnTypeInFIle() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RECORDSBYEMPLOYEEINFILEENTYPE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@HFILE_TYPE", _HFILE_TYPE)
            DB_Command.Parameters.AddWithValue("@HFILE_NAME", _HFILE_NAME)
            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("@ENTTYPE_ID", _ENTTYPE_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AsistanceFiles.Get_EntryExitRecordByEmployeeIDEnType()")

            Return Nothing
        End Try
    End Function

    Public Function Get_EntryExitRecordsByEmployeeIDEnTypes() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_ENTRYEXITRECORDSINFILEBYENTYPES",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@HFILE_NAME", _HFILE_NAME)
            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("@ENTTYPE_ID", _ENTTYPE_ID)
            DB_Command.Parameters.AddWithValue("@EXTTYPE_ID", _EXTTYPE_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AsistanceFiles.Get_EntryExitRecordByEmployeeIDEnType()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AsistanceCheck() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_CHECKASISTANCERECORDSBYEMPLOYEEINFILE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@HFILE_TYPE", _HFILE_TYPE)
            DB_Command.Parameters.AddWithValue("@HFILE_NAME", _HFILE_NAME)
            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AsistanceFiles.Get_AsistanceCheck()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllAssistanceTypes() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_ALLASISTANCETYPES",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AsistanceFiles.Get_AllAssistanceTypes()")

            Return Nothing
        End Try
    End Function

    'Public Function Get_IncompleteRecordsByEmployee() As DataTable
    '    Try
    '        DB_Command = New SqlCommand With {
    '            .CommandText = "SEL_INCOMPLETERECORDSINFILE",
    '            .CommandType = CommandType.StoredProcedure
    '        }
    '        DB_Connection.Open()
    '        DB_Command.Connection = DB_Connection
    '        DB_Command.Parameters.AddWithValue("@HFILE_NAME", _HFILE_NAME)
    '        DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
    '        DB_Reader = DB_Command.ExecuteReader()
    '        DB_Command.Connection = DB_Connection
    '        Dim LocalTable As New DataTable

    '        LocalTable.Load(DB_Reader)
    '        DB_Reader.Close()
    '        DB_Connection.Close()
    '        Return LocalTable
    '    Catch ex As Exception
    '        DB_Connection.Close()
    '        MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AsistanceFiles.Get_IncompleteRecordsByEmployee()")

    '        Return Nothing
    '    End Try
    'End Function
End Class
