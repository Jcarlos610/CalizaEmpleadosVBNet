Imports Microsoft.Data.SqlClient

Public Class CL_EmployeesBenefitsBotonero
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader


    Private _BOTON_ID As Object
    Private _REMPL_ID As Object
    Private _BENEF_ID As Object
    Private _BOTON_VALFR As Object
    Private _BOTON_VALTO As Object
    Private _BOTON_DESCR As Object
    Private _BOTON_CREBY As Object
    Private _BOTON_DATEC As Object
    Private _BOTON_STAT As Integer

    Public Property BOTON_ID As Object
        Get
            Return _BOTON_ID
        End Get
        Set(value As Object)
            _BOTON_ID = value
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

    Public Property BENEF_ID As Object
        Get
            Return _BENEF_ID
        End Get
        Set(value As Object)
            _BENEF_ID = value
        End Set
    End Property

    Public Property BOTON_VALFR As Object
        Get
            Return _BOTON_VALFR
        End Get
        Set(value As Object)
            _BOTON_VALFR = value
        End Set
    End Property

    Public Property BOTON_VALTO As Object
        Get
            Return _BOTON_VALTO
        End Get
        Set(value As Object)
            _BOTON_VALTO = value
        End Set
    End Property

    Public Property BOTON_DESCR As Object
        Get
            Return _BOTON_DESCR
        End Get
        Set(value As Object)
            _BOTON_DESCR = value
        End Set
    End Property

    Public Property BOTON_CREBY As Object
        Get
            Return _BOTON_CREBY
        End Get
        Set(value As Object)
            _BOTON_CREBY = value
        End Set
    End Property

    Public Property BOTON_DATEC As Object
        Get
            Return _BOTON_DATEC
        End Get
        Set(value As Object)
            _BOTON_DATEC = value
        End Set
    End Property

    Public Property BOTON_STAT As Integer
        Get
            Return _BOTON_STAT
        End Get
        Set(value As Integer)
            _BOTON_STAT = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(BOTON_ID, REMPL_ID, BENEF_ID, BOTON_VALFR, BOTON_VALTO, BOTON_DESCR, BOTON_CREBY, BOTON_DATEC, BOTON_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _BOTON_ID = BOTON_ID
        _REMPL_ID = REMPL_ID
        _BENEF_ID = BENEF_ID
        _BOTON_VALFR = BOTON_VALFR
        _BOTON_VALTO = BOTON_VALTO
        _BOTON_DESCR = BOTON_DESCR
        _BOTON_CREBY = BOTON_CREBY
        _BOTON_DATEC = BOTON_DATEC
        Me.BOTON_STAT = BOTON_STAT
    End Sub


    Sub New(REMPL_ID, BENEF_ID, BOTON_VALFR, BOTON_VALTO, BOTON_DESCR, BOTON_CREBY, BOTON_DATEC, BOTON_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _BENEF_ID = BENEF_ID
        _BOTON_VALFR = BOTON_VALFR
        _BOTON_VALTO = BOTON_VALTO
        _BOTON_DESCR = BOTON_DESCR
        _BOTON_CREBY = BOTON_CREBY
        _BOTON_DATEC = BOTON_DATEC
        Me.BOTON_STAT = BOTON_STAT
    End Sub

    Public Function Get_PendingBotoneros() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETPENDINGBOTONEROS",
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
            MsgBox("Ocurrió el siguiente error: " & ex.Message & " CL_EmployeesBenefitsBotonero.Get_PendingBotoneros()")
            Return Nothing
        End Try
    End Function

    Public Function InsertBotoneroValidez() As Boolean
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_EMPLOYEEBENEFITBOTONERO",
            .CommandType = CommandType.StoredProcedure
        }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("EMPL_ID", _REMPL_ID)
            DB_Command.Parameters.AddWithValue("BENEF_ID", _BENEF_ID)
            DB_Command.Parameters.AddWithValue("BOTON_VALFR", _BOTON_VALFR)
            DB_Command.Parameters.AddWithValue("BOTON_VALTO", _BOTON_VALTO)
            DB_Command.Parameters.AddWithValue("BOTON_DESCR", If(_BOTON_DESCR = "", DBNull.Value, _BOTON_DESCR))
            DB_Command.Parameters.AddWithValue("BOTON_CREBY", _BOTON_CREBY)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrió el siguiente error: " & ex.Message & " CL_EmployeesBenefitsBotonero.InsertBotoneroValidez()")
            Return False
        End Try
    End Function

    Public Function Get_AllValidatedBotoneros() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETALLVALIDATEDBOTONEROS",
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
            MsgBox("Ocurrió el siguiente error: " & ex.Message & " CL_EmployeesBenefitsBotonero.Get_AllValidatedBotoneros()")
            Return Nothing
        End Try
    End Function

    Public Function UpdateBotoneroValidez() As Boolean
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "UPD_EMPLOYEEBENEFITBOTONERO",
            .CommandType = CommandType.StoredProcedure
        }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("BOTON_ID", _BOTON_ID)
            DB_Command.Parameters.AddWithValue("BOTON_VALFR", _BOTON_VALFR)
            DB_Command.Parameters.AddWithValue("BOTON_VALTO", _BOTON_VALTO)
            DB_Command.Parameters.AddWithValue("BOTON_DESCR", _BOTON_DESCR)
            DB_Command.Parameters.AddWithValue("BOTON_CREBY", _BOTON_CREBY)
            DB_Command.Parameters.AddWithValue("BOTON_STAT", _BOTON_STAT)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrió el siguiente error: " & ex.Message & " CL_EmployeesBenefitsBotonero.UpdateBotoneroValidez()")
            Return False
        End Try
    End Function

End Class
