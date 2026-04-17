Imports Microsoft.Data.SqlClient

Public Class CL_RecordsByEmployee
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _REMPL_ID As Object
    Private _EMPL_ID As Object
    Private _MOVE_ID As Object
    Private _REMPL_CREBY As Object
    Private _REMPL_RDATE As Object
    Private _DREMPL_DATE As Object
    Private _DREMPL_ENDATI As Object
    Private _DREMPL_EXDATI As Object
    Private _DREMPL_COME As Object
    Private _DREMPL_LHOUR As Object
    Private _DREMPL_BQUANT As Object

    Public Property EMPL_ID As Object
        Get
            Return _EMPL_ID
        End Get
        Set(value As Object)
            _EMPL_ID = value
        End Set
    End Property

    Public Property MOVE_ID As Object
        Get
            Return _MOVE_ID
        End Get
        Set(value As Object)
            _MOVE_ID = value
        End Set
    End Property

    Public Property REMPL_CREBY As Object
        Get
            Return _REMPL_CREBY
        End Get
        Set(value As Object)
            _REMPL_CREBY = value
        End Set
    End Property

    Public Property REMPL_RDATE As Object
        Get
            Return _REMPL_RDATE
        End Get
        Set(value As Object)
            _REMPL_RDATE = value
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

    Public Property DREMPL_ENDATI As Object
        Get
            Return _DREMPL_ENDATI
        End Get
        Set(value As Object)
            _DREMPL_ENDATI = value
        End Set
    End Property

    Public Property DREMPL_EXDATI As Object
        Get
            Return _DREMPL_EXDATI
        End Get
        Set(value As Object)
            _DREMPL_EXDATI = value
        End Set
    End Property

    Public Property DREMPL_COME As Object
        Get
            Return _DREMPL_COME
        End Get
        Set(value As Object)
            _DREMPL_COME = value
        End Set
    End Property

    Public Property DREMPL_LHOUR As Object
        Get
            Return _DREMPL_LHOUR
        End Get
        Set(value As Object)
            _DREMPL_LHOUR = value
        End Set
    End Property

    Public Property DREMPL_BQUANT As Object
        Get
            Return _DREMPL_BQUANT
        End Get
        Set(value As Object)
            _DREMPL_BQUANT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(EMPL_ID, MOVE_ID, REMPL_CREBY, REMPL_RDATE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_ID = EMPL_ID
        _MOVE_ID = MOVE_ID
        _REMPL_CREBY = REMPL_CREBY
        _REMPL_RDATE = REMPL_RDATE

    End Sub

    Sub New(EMPL_ID, MOVE_ID, REMPL_CREBY, REMPL_RDATE, DREMPL_DATE, DREMPL_ENDATI, DREMPL_EXDATI)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_ID = EMPL_ID
        _MOVE_ID = MOVE_ID
        _REMPL_CREBY = REMPL_CREBY
        _REMPL_RDATE = REMPL_RDATE
        _DREMPL_DATE = DREMPL_DATE
        _DREMPL_ENDATI = DREMPL_ENDATI
        _DREMPL_EXDATI = DREMPL_EXDATI

    End Sub

    Sub New(REMPL_ID, EMPL_ID, MOVE_ID, REMPL_CREBY, REMPL_RDATE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _EMPL_ID = EMPL_ID
        _MOVE_ID = MOVE_ID
        _REMPL_CREBY = REMPL_CREBY
        _REMPL_RDATE = REMPL_RDATE

    End Sub

    Public Function InsertEntryRecordByEmployee()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_ENTRYRECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_ENDATI", _DREMPL_ENDATI)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.InsertRecordByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function InsertExitRecordByEmployee() As Boolean

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_EXITRECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_EXDATI", _DREMPL_EXDATI)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.InsertRecordByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function IdealFullTimeRecordByEmployee() As Boolean

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_IDEALFULLTIMERECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_ENDATI", _DREMPL_ENDATI)
            DB_Command.Parameters.AddWithValue("DREMPL_EXDATI", _DREMPL_EXDATI)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.IdealFullTimeRecordByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function AbsenceRecordByEmployee() As Boolean

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_ABSENCERECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.AbsenceRecordByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function ImcompletelFullTimeRecordByEmployee() As Boolean

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_IMCOMPLETEFULLTIMERECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_ENDATI", _DREMPL_ENDATI)
            DB_Command.Parameters.AddWithValue("DREMPL_EXDATI", _DREMPL_EXDATI)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.ImcompletelFullTimeRecordByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllRecordsByEntryFile(ByVal REMPL_RDATE As Date) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_ENTRYRECORDSBYENTRYFLE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", REMPL_RDATE)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_AllRecordsByEntryFile()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllRecordsByExitFile(ByVal REMPL_RDATE As Date) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_EXITRECORDSBYEXITFLE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", REMPL_RDATE)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_AllRecordsByExitFile()")

            Return Nothing
        End Try
    End Function

    Public Function Get_ManualAsistanceRecord(ByVal EMPL_ID As Integer, ByVal REMPL_RDATE As Date, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_MANUALASISTANCERECORD",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", REMPL_RDATE)
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_ManualAsistanceRecord()")

            Return Nothing
        End Try
    End Function

    Public Function Get_ManualDelayRecord(ByVal EMPL_ID As Integer, ByVal REMPL_RDATE As Date, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_RE_MANUALASISTANCERECORD",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", REMPL_RDATE)
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_ManualAsistanceRecord()")

            Return Nothing
        End Try
    End Function

    Public Function ManualAsistanceRecordByEmployee() As Boolean

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_MANUALASISTANCERECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_ENDATI", _DREMPL_ENDATI)
            DB_Command.Parameters.AddWithValue("DREMPL_EXDATI", _DREMPL_EXDATI)
            DB_Command.Parameters.AddWithValue("DREMPL_COME", _DREMPL_COME)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.ManualAsistanceRecordByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function InsertDelayRecordByEmployee()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_DELAYRECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_ENDATI", _DREMPL_ENDATI)
            DB_Command.Parameters.AddWithValue("DREMPL_COME", _DREMPL_COME)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.InsertDelayRecordByEmployee()")

            Return Nothing
        End Try
    End Function


    Public Function InsertLunchHoursRecordByEmployee()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_LUNCHHOURSRECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_LHOUR", _DREMPL_LHOUR)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.InsertLunchHoursRecordByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function InsertBannsQuantityRecordByEmployee()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_BANNSQUANTITYRECORDBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("MOVE_ID", _MOVE_ID)
            DB_Command.Parameters.AddWithValue("REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("DREMPL_BQUANT", DREMPL_BQUANT)
            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordByEmployee.InsertBannsQuantityRecordByEmployee()")

            Return Nothing
        End Try
    End Function


    Public Function Get_WeekRecords(ByVal startDate As Date, ByVal endDate As Date) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_WEEKRECORDS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("startDate", startDate)
            DB_Command.Parameters.AddWithValue("endDate", endDate)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_WeekRecords()")

            Return Nothing
        End Try
    End Function

    Public Function Get_CheckDelayJustified(ByVal EMPL_ID As Integer, ByVal DREMPL_DATE As Date, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_CHECKDELAYJUSTIFIED",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", DREMPL_DATE)
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_CheckDelayJustified()")

            Return Nothing
        End Try
    End Function

    Public Function Get_CheckAbsenceJustified(ByVal EMPL_ID As Integer, ByVal DREMPL_DATE As Date, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_CHECKABSENCEJUSTIFIED",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", DREMPL_DATE)
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_CheckDelayJustified()")

            Return Nothing
        End Try
    End Function

    Public Function Get_WeekRecordsDetailsBYEmployee(ByVal startDate As Date, ByVal endDate As Date, ByVal EMPL_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_WEEKRECORDSDETBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("startDate", startDate)
            DB_Command.Parameters.AddWithValue("endDate", endDate)
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_WeekRecordsDetailsBYEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function Get_DayRecordsByEmployee(ByVal startDate As Date, ByVal endDate As Date, ByVal EMPL_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_DAYRECORDSBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("startDate", startDate)
            DB_Command.Parameters.AddWithValue("endDate", endDate)
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_DayRecordsByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function Get_DayRecordsByEmployeeAndType(ByVal startDate As Date, ByVal endDate As Date, ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_DAYRECORDSBYEMPLOYEEANDTYPE",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_DayRecordsByEmployeeAndType()")

            Return Nothing
        End Try
    End Function

    Public Function Get_LuchHoursByEmployee(ByVal startDate As Date, ByVal endDate As Date, ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_LUNCHHOURSBYEMPLOYEE",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_LuchHoursByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function Get_BannQuantityByEmployee(ByVal startDate As Date, ByVal endDate As Date, ByVal EMPL_ID As Integer, ByVal MOVE_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_BANNSQUANTITYBYEMPLOYEE",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_BannQuantityByEmployee()")

            Return Nothing
        End Try
    End Function
    Public Function Get_ExistHoursBannsRecords(ByVal startDate As Date, ByVal endDate As Date) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_EXISTLUNCHANDBANNSRECORDS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("startDate", startDate)
            DB_Command.Parameters.AddWithValue("endDate", endDate)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_RecordsByEmployee.Get_ExistHoursBannsRecords()")

            Return Nothing
        End Try
    End Function

    Public Function GetLunchDates() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_LUNCHDATES_WITH_RECORDS",
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function GetLunchByDate(fecha As Date) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_LUNCHBYDATE",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@DATE", fecha)

            DB_Reader = DB_Command.ExecuteReader()

            Dim dt As New DataTable
            dt.Load(DB_Reader)

            DB_Reader.Close()
            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function UpdateLunchHours(id As Integer, hours As Decimal) As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_LUNCHHOURS",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@DREMPL_ID", id)
            DB_Command.Parameters.AddWithValue("@DREMPL_LHOUR", hours)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function UpdateBann(ByVal DREMPL_ID As Integer, ByVal Banns As Decimal) As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_RECORDSBYEMPLOYEEBANNS",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@DREMPL_ID", DREMPL_ID)
            DB_Command.Parameters.AddWithValue("@DREMPL_BQUANT", Banns)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()

            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_RecordsByEmployee.UpdateEmployeeBannQuantity()")
            Return False
        End Try
    End Function

End Class
