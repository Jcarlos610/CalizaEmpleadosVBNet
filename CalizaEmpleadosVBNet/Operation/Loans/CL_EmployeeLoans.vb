Imports Microsoft.Data.SqlClient

Public Class CL_EmployeeLoans
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _EMPL_ID As Object
    Private _LOAN_ID As Object
    Private _REMPL_ID As Object
    Private _DREMPL_LAMM As Object
    Private _DREMPL_LTYPE As Object
    Private _DREMPL_LSTAT As Object
    Private _LOAN_PAYM As Object
    Private _LOAN_PTYPE As Object
    Private _REMPL_CREBY As Object
    Private _REMPL_RDATE As Object
    Private _DREMPL_DESCR As Object
    Private _DREMPL_AUTH As Object
    Private _DISC_ID As Object

    Public Property EMPL_ID As Object
        Get
            Return _EMPL_ID
        End Get
        Set(value As Object)
            _EMPL_ID = value
        End Set
    End Property

    Public Property LOAN_ID As Object
        Get
            Return _LOAN_ID
        End Get
        Set(value As Object)
            _LOAN_ID = value
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

    Public Property DREMPL_LAMM As Object
        Get
            Return _DREMPL_LAMM
        End Get
        Set(value As Object)
            _DREMPL_LAMM = value
        End Set
    End Property

    Public Property DREMPL_LTYPE As Object
        Get
            Return _DREMPL_LTYPE
        End Get
        Set(value As Object)
            _DREMPL_LTYPE = value
        End Set
    End Property

    Public Property DREMPL_LSTAT As Object
        Get
            Return _DREMPL_LSTAT
        End Get
        Set(value As Object)
            _DREMPL_LSTAT = value
        End Set
    End Property

    Public Property LOAN_PAYM As Object
        Get
            Return _LOAN_PAYM
        End Get
        Set(value As Object)
            _LOAN_PAYM = value
        End Set
    End Property

    Public Property LOAN_PTYPE As Object
        Get
            Return _LOAN_PTYPE
        End Get
        Set(value As Object)
            _LOAN_PTYPE = value
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

    Public Property DREMPL_DESCR As Object
        Get
            Return _DREMPL_DESCR
        End Get
        Set(value As Object)
            _DREMPL_DESCR = value
        End Set
    End Property

    Public Property DREMPL_AUTH As Object
        Get
            Return _DREMPL_AUTH
        End Get
        Set(value As Object)
            _DREMPL_AUTH = value
        End Set
    End Property

    Public Property DISC_ID As Object
        Get
            Return _DISC_ID
        End Get
        Set(value As Object)
            _DISC_ID = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Public Sub InsertLoan()
        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("INS_LOAN", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("@LOAN_AMOUNT", _DREMPL_LAMM)
            DB_Command.Parameters.AddWithValue("@LOAN_TYPE", _DREMPL_LTYPE)
            DB_Command.Parameters.AddWithValue("@REMPL_CREBY", _REMPL_CREBY)
            DB_Command.Parameters.AddWithValue("@REMPL_RDATE", _REMPL_RDATE)
            DB_Command.Parameters.AddWithValue("@DESCR", _DREMPL_DESCR)
            DB_Command.Parameters.AddWithValue("@AUTH", _DREMPL_AUTH)
            DB_Command.Parameters.AddWithValue("@DISC_ID", _DISC_ID)

            DB_Command.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al registrar crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try
    End Sub


    Public Sub UpdateLoan()

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("UPD_LOAN", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Command.Parameters.AddWithValue("@LOAN_ID", _LOAN_ID)
            DB_Command.Parameters.AddWithValue("@LOAN_AMOUNT", _DREMPL_LAMM)
            DB_Command.Parameters.AddWithValue("@LOAN_TYPE", _DREMPL_LTYPE)
            DB_Command.Parameters.AddWithValue("@DESCR", _DREMPL_DESCR)
            DB_Command.Parameters.AddWithValue("@AUTH", _DREMPL_AUTH)
            DB_Command.Parameters.AddWithValue("@DISC_ID", _DISC_ID)

            DB_Command.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            DB_Connection.Close()
        End Try

    End Sub

    Public Sub InsertPayment()
        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("INS_LOAN_PAYMENT", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Command.Parameters.AddWithValue("@LOAN_ID", _LOAN_ID)
            DB_Command.Parameters.AddWithValue("@AMOUNT", _LOAN_PAYM)
            DB_Command.Parameters.AddWithValue("@TYPE", _LOAN_PTYPE)

            DB_Command.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al registrar pago", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try
    End Sub

    Public Function GetEmployeesWithLoans() As DataTable
        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETEMPLOYEESWITHLOANS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al obtener empleados con préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try

        Return dt
    End Function

    Public Function GetLoansByEmployee() As DataTable
        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETLOANSBYEMPLOYEE", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()
            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al obtener préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try

        Return dt
    End Function

    Public Function GetLoanDetail() As DataTable
        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETLOANDETAIL", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()
            DB_Command.Parameters.AddWithValue("@LOAN_ID", _LOAN_ID)

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al obtener detalle", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try

        Return dt
    End Function

    Public Function GetDiscounts() As DataTable
        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_RE_GETALLDISCOUNTS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al obtener descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try

        Return dt
    End Function

    Public Function GetAllEmployeesInfo() As DataTable
        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETEMPLOYEESINFO", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.Clear()

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al obtener empleados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB_Connection.Close()
        End Try

        Return dt
    End Function

    Public Function GetAllLoans() As DataTable

        Dim dt As New DataTable

        Try
            DB_Connection.Open()

            DB_Command = New SqlCommand("SEL_GETALLLOANS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Reader = DB_Command.ExecuteReader()
            dt.Load(DB_Reader)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            DB_Connection.Close()
        End Try

        Return dt

    End Function

End Class