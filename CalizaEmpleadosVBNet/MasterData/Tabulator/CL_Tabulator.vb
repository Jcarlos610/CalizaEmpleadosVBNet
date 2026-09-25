Imports Microsoft.Data.SqlClient

Public Class CL_Tabulator
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _TABID As Object
    Private _CUSCODE As Object
    Private _CUSNAME As Object
    Private _PRICE As Object
    Private _PRICEINCREASE As Object
    Private _DATECREATED As Object
    Private _PERCENTAGE As Object


    Public Property TABID As Object
        Get
            Return _TABID
        End Get
        Set(value As Object)
            _TABID = value
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

    Public Property CUSNAME As Object
        Get
            Return _CUSNAME
        End Get
        Set(value As Object)
            _CUSNAME = value
        End Set
    End Property

    Public Property PRICE As Object
        Get
            Return _PRICE
        End Get
        Set(value As Object)
            _PRICE = value
        End Set
    End Property

    Public Property PRICEINCREASE As Object
        Get
            Return _PRICEINCREASE
        End Get
        Set(value As Object)
            _PRICEINCREASE = value
        End Set
    End Property

    Public Property DATECREATED As Object
        Get
            Return _DATECREATED
        End Get
        Set(value As Object)
            _DATECREATED = value
        End Set
    End Property

    Public Property PERCENTAGE As Object
        Get
            Return _PERCENTAGE
        End Get
        Set(value As Object)
            _PERCENTAGE = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(TABID, CUSCODE, CUSNAME, PRICE, PRICEINCREASE, DATECREATED, PERCENTAGE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _TABID = TABID
        _CUSCODE = CUSCODE
        _CUSNAME = CUSNAME
        _PRICE = PRICE
        _PRICEINCREASE = PRICEINCREASE
        _DATECREATED = DATECREATED
        _PERCENTAGE = PERCENTAGE

    End Sub

    Sub New(CUSCODE, CUSNAME, PRICE, PRICEINCREASE, DATECREATED, PERCENTAGE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _CUSCODE = CUSCODE
        _CUSNAME = CUSNAME
        _PRICE = PRICE
        _PRICEINCREASE = PRICEINCREASE
        _DATECREATED = DATECREATED
        _PERCENTAGE = PERCENTAGE
    End Sub

    Public Function InsertTabulator(cusCode As String, cusName As String, shipId As Object, shipName As Object, price As Decimal, percentage As Object, priceIncrease As Decimal) As Boolean
        Try
            DB_Command = New SqlCommand("INS_MD_TABULATOR", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@CUSCODE", cusCode)
            DB_Command.Parameters.AddWithValue("@CUSNAME", cusName)
            DB_Command.Parameters.AddWithValue("@SHIPID", If(shipId Is Nothing, DBNull.Value, shipId))
            DB_Command.Parameters.AddWithValue("@SHIPNAME", If(shipName Is Nothing, DBNull.Value, shipName))
            DB_Command.Parameters.AddWithValue("@PRICE", price)
            DB_Command.Parameters.AddWithValue("@PERCENTAGE", If(percentage Is Nothing, DBNull.Value, percentage))
            DB_Command.Parameters.AddWithValue("@PRICEINCREASE", priceIncrease)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al guardar el tabulador: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function GetTabulator() As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_MD_TABULATOR", DB_Connection) With {.CommandType = CommandType.StoredProcedure}

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al cargar tabulador: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetPriceByCustomer(ByVal cusCode As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_TABULATORPRICEBYCUSTOMER", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@CUSCODE", cusCode)

            DB_Connection.Open()
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al obtener precio del cliente: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function UpdateTabulator(tabId As Integer, cusCode As String, cusName As String, shipId As Object, shipName As Object, price As Decimal, percentage As Object, priceIncrease As Decimal) As Boolean
        Try
            DB_Command = New SqlCommand("UPD_MD_TABULATOR", DB_Connection) With {.CommandType = CommandType.StoredProcedure}
            DB_Command.Parameters.AddWithValue("@TABID", tabId)
            DB_Command.Parameters.AddWithValue("@CUSCODE", cusCode)
            DB_Command.Parameters.AddWithValue("@CUSNAME", cusName)
            DB_Command.Parameters.AddWithValue("@SHIPID", If(shipId Is Nothing, DBNull.Value, shipId))
            DB_Command.Parameters.AddWithValue("@SHIPNAME", If(shipName Is Nothing, DBNull.Value, shipName))
            DB_Command.Parameters.AddWithValue("@PRICE", price)
            DB_Command.Parameters.AddWithValue("@PERCENTAGE", If(percentage Is Nothing, DBNull.Value, percentage))
            DB_Command.Parameters.AddWithValue("@PRICEINCREASE", priceIncrease)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error al actualizar el tabulador: " & ex.Message)
            Return False
        End Try
    End Function

End Class
