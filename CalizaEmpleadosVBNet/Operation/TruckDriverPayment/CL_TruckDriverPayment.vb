Imports Microsoft.Data.SqlClient

Public Class CL_TruckDriverPayment
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _RECID As Object
    Private _EMPL_ID As Object
    Private _SALEID As Object
    Private _QUANTITY As Object
    Private _CUSCODE As Object
    Private _SHIPCODE As Object
    Private _DOCREF As Object
    Private _PAYAMOUNT As Object
    Private _SALEDATE As Object
    Private _SALESTATUS As Object
    Private _PAYROLL_ID As Object

    Public Property RECID As Object
        Get
            Return _RECID
        End Get
        Set(value As Object)
            _RECID = value
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

    Public Property SALEID As Object
        Get
            Return _SALEID
        End Get
        Set(value As Object)
            _SALEID = value
        End Set
    End Property

    Public Property QUANTITY As Object
        Get
            Return _QUANTITY
        End Get
        Set(value As Object)
            _QUANTITY = value
        End Set
    End Property

    Public Property CUSCODE As Object
        Get
            Return _CUSCODE
        End Get
        Set(value As Object)
            _CUSCODE = value
        End Set
    End Property

    Public Property SHIPCODE As Object
        Get
            Return _SHIPCODE
        End Get
        Set(value As Object)
            _SHIPCODE = value
        End Set
    End Property

    Public Property DOCREF As Object
        Get
            Return _DOCREF
        End Get
        Set(value As Object)
            _DOCREF = value
        End Set
    End Property

    Public Property PAYAMOUNT As Object
        Get
            Return _PAYAMOUNT
        End Get
        Set(value As Object)
            _PAYAMOUNT = value
        End Set
    End Property

    Public Property SALEDATE As Object
        Get
            Return _SALEDATE
        End Get
        Set(value As Object)
            _SALEDATE = value
        End Set
    End Property

    Public Property SALESTATUS As Object
        Get
            Return _SALESTATUS
        End Get
        Set(value As Object)
            _SALESTATUS = value
        End Set
    End Property

    Public Property PAYROLL_ID As Object
        Get
            Return _PAYROLL_ID
        End Get
        Set(value As Object)
            _PAYROLL_ID = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(RECID, EMPL_ID, SALEID, QUANTITY, CUSCODE, SHIPCODE, DOCREF, PAYAMOUNT, SALEDATE, SALESTATUS, PAYROLL_ID)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _RECID = RECID
        _EMPL_ID = EMPL_ID
        _SALEID = SALEID
        _QUANTITY = QUANTITY
        _CUSCODE = CUSCODE
        _SHIPCODE = SHIPCODE
        _DOCREF = DOCREF
        _PAYAMOUNT = PAYAMOUNT
        _SALEDATE = SALEDATE
        _SALESTATUS = SALESTATUS
        _PAYROLL_ID = PAYROLL_ID
    End Sub

    Sub New(EMPL_ID, SALEID, QUANTITY, CUSCODE, SHIPCODE, DOCREF, PAYAMOUNT, SALEDATE, SALESTATUS, PAYROLL_ID)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_ID = EMPL_ID
        _SALEID = SALEID
        _QUANTITY = QUANTITY
        _CUSCODE = CUSCODE
        _SHIPCODE = SHIPCODE
        _DOCREF = DOCREF
        _PAYAMOUNT = PAYAMOUNT
        _SALEDATE = SALEDATE
        _SALESTATUS = SALESTATUS
        _PAYROLL_ID = PAYROLL_ID
    End Sub


    Public Function InsertPayment() As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_TruckDriverPayment",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("@SALEID", _SALEID)
            DB_Command.Parameters.AddWithValue("@QUANTITY", _QUANTITY)
            DB_Command.Parameters.AddWithValue("@CUSCODE", _CUSCODE)
            DB_Command.Parameters.AddWithValue("@SHIPCODE", _SHIPCODE)
            DB_Command.Parameters.AddWithValue("@DOCREF", If(_DOCREF Is Nothing, DBNull.Value, _DOCREF))
            DB_Command.Parameters.AddWithValue("@PAYAMOUNT", _PAYAMOUNT)
            DB_Command.Parameters.AddWithValue("@SALEDATE", _SALEDATE)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error en CL_TruckDriverPayment.InsertPayment(): " & ex.Message)
            Return False
        End Try
    End Function

    Public Function ReadOnlyCustomers() As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_LM_ONLYCUSTOMERS", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@CUSTYPE", 10)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar clientes de La Mina: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function ReadOnlyLocationsForCustomer(ByVal cusCode As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_LM_ONLYLOCATIONSFORCUSTOMER", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@CUSCODE", cusCode)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar sucursales: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetSaleByID(ByVal saleId As Integer) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_LM_SALEBYID", DB_Connection) With {
                .CommandType = CommandType.StoredProcedure,
                .CommandTimeout = 60
            }
            DB_Command.Parameters.AddWithValue("@SALEID", saleId)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al buscar la venta: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetSalesByCustomerAndLocation(ByVal cusCode As String, ByVal shipId As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_LM_SALESBYCUSTOMERANDLOCATION", DB_Connection) With {
            .CommandType = CommandType.StoredProcedure,
            .CommandTimeout = 60
        }
            DB_Command.Parameters.AddWithValue("@CUSCODE", cusCode)
            DB_Command.Parameters.AddWithValue("@SHIPID", shipId)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar ventas del cliente: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetPendingPaymentsByEmployeeAndWeek(employeeID As Integer, startDate As Date, endDate As Date) As DataTable
        Dim dt As New DataTable()
        Try
            DB_Command = New SqlCommand("SEL_TruckDriverPaymentsByEmployeeWeek", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@EMPL_ID", employeeID)
            DB_Command.Parameters.AddWithValue("@STARTDATE", startDate)
            DB_Command.Parameters.AddWithValue("@ENDDATE", endDate)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al consultar pagos de viajes: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function MarkPaymentsAsPaid(employeeID As Integer, startDate As Date, endDate As Date, payrollID As Integer) As Boolean
        Try
            DB_Command = New SqlCommand("UPD_TruckDriverPaymentsMarkPaid", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@EMPL_ID", employeeID)
            DB_Command.Parameters.AddWithValue("@STARTDATE", startDate)
            DB_Command.Parameters.AddWithValue("@ENDDATE", endDate)
            DB_Command.Parameters.AddWithValue("@PAYROLL_ID", payrollID)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al marcar pagos de viajes: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function RevertPaymentsByBatch(batchID As String) As Boolean
        Try
            DB_Command = New SqlCommand("UPD_TruckDriverPaymentsRevertByBatch", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@BATCHID", batchID)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al revertir pagos de viajes: " & ex.Message)
            Return False
        End Try
    End Function
End Class
