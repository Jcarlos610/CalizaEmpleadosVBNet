Imports Microsoft.Data.SqlClient

Public Class CL_BenefitsEmployee
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _BEEMP_ID As Object
    Private _EMPL_ID As Object
    Private _BENEF_ID As Object
    Private _BEEMP_RDATE As Object
    Private _BEEMP_CREBY As Object
    Private _BEEMP_STAT As Object
    Private _BEEMP_AMOUN As Object

    Public Property BEEMP_ID As Object
        Get
            Return _BEEMP_ID
        End Get
        Set(value As Object)
            _BEEMP_ID = value
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

    Public Property BENEF_ID As Object
        Get
            Return _BENEF_ID
        End Get
        Set(value As Object)
            _BENEF_ID = value
        End Set
    End Property

    Public Property BEEMP_RDATE As Object
        Get
            Return _BEEMP_RDATE
        End Get
        Set(value As Object)
            _BEEMP_RDATE = value
        End Set
    End Property

    Public Property BEEMP_CREBY As Object
        Get
            Return _BEEMP_CREBY
        End Get
        Set(value As Object)
            _BEEMP_CREBY = value
        End Set
    End Property

    Public Property BEEMP_STAT As Object
        Get
            Return _BEEMP_STAT
        End Get
        Set(value As Object)
            _BEEMP_STAT = value
        End Set
    End Property

    Public Property BEEMP_AMOUN As Object
        Get
            Return _BEEMP_AMOUN
        End Get
        Set(value As Object)
            _BEEMP_AMOUN = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(BEEMP_ID, EMPL_ID, BENEF_ID, BEEMP_AMOUN, BEEMP_RDATE, BEEMP_CREBY, BEEMP_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _BEEMP_ID = BEEMP_ID
        _EMPL_ID = EMPL_ID
        _BENEF_ID = BENEF_ID
        _BEEMP_AMOUN = BEEMP_AMOUN
        _BEEMP_RDATE = BEEMP_RDATE
        _BEEMP_CREBY = BEEMP_CREBY
        _BEEMP_STAT = BEEMP_STAT
    End Sub

    Sub New(EMPL_ID, BENEF_ID, BEEMP_AMOUN, BEEMP_RDATE, BEEMP_CREBY, BEEMP_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_ID = EMPL_ID
        _BENEF_ID = BENEF_ID
        _BEEMP_AMOUN = BEEMP_AMOUN
        _BEEMP_RDATE = BEEMP_RDATE
        _BEEMP_CREBY = BEEMP_CREBY
        _BEEMP_STAT = BEEMP_STAT
    End Sub

    Public Function InsertBenefitsByEmployee()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_BENEFITSBYEMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("BENEF_ID", _BENEF_ID)
            DB_Command.Parameters.AddWithValue("BEEMP_AMOUN", BEEMP_AMOUN)
            DB_Command.Parameters.AddWithValue("BEEMP_RDATE", _BEEMP_RDATE)
            DB_Command.Parameters.AddWithValue("BEEMP_CREBY", _BEEMP_CREBY)
            DB_Command.Parameters.AddWithValue("BEEMP_STAT", _BEEMP_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_BenefitEmployees.InsertBenefitsByEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function Get_BenefitsByEmployeeID(ByVal EMPL_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_BENEFITSAASIGNEDTEMPLOYEE ",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_BenefitEmployees.Get_BenefitsByEmployeeID()")

            Return Nothing
        End Try
    End Function

    Public Function Upd_BenefitsByEmployeeID(ByVal EMPL_ID As Integer, ByVal BENEF_ID As Integer, ByVal BEEMP_STAT As Boolean) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_DEACTIVATEBENEFITTOEMPLOYEE ",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("BENEF_ID", BENEF_ID)
            DB_Command.Parameters.AddWithValue("BEEMP_STAT", BEEMP_STAT)
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_BenefitEmployees.Upd_BenefitsByEmployeeID()")

            Return Nothing
        End Try
    End Function

    Public Function Get_UpdateSalaryByEmployeeID(ByVal EMPL_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_UPDATEDSALARY ",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_BenefitEmployees.Get_UpdateSalaryByEmployeeID()")

            Return Nothing
        End Try
    End Function

End Class
