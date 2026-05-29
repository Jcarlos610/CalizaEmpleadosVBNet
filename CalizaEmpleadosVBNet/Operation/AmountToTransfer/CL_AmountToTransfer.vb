Imports Microsoft.Data.SqlClient
Public Class CL_AmountToTransfer
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _AMTRANS_ID As Object
    Private _REMPL_ID As Object
    Private _DREMPL_DATE As Object
    Private _AMTRANS_AMOUN As Object
    Private _AMTRANS_CREBY As Object
    Private _AMTRANS_RDATE As Object

    Public Property AMTRANS_ID As Object
        Get
            Return _AMTRANS_ID
        End Get
        Set(value As Object)
            _AMTRANS_ID = value
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

    Public Property AMTRANS_AMOUN As Object
        Get
            Return _AMTRANS_AMOUN
        End Get
        Set(value As Object)
            _AMTRANS_AMOUN = value
        End Set
    End Property

    Public Property AMTRANS_CREBY As Object
        Get
            Return _AMTRANS_CREBY
        End Get
        Set(value As Object)
            _AMTRANS_CREBY = value
        End Set
    End Property

    Public Property AMTRANS_RDATE As Object
        Get
            Return _AMTRANS_RDATE
        End Get
        Set(value As Object)
            _AMTRANS_RDATE = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub


    Sub New(AMTRANS_ID, REMPL_ID, DREMPL_DATE, AMTRANS_AMOUN, AMTRANS_CREBY, AMTRANS_RDATE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        Me.AMTRANS_ID = AMTRANS_ID
        Me.REMPL_ID = REMPL_ID
        Me.DREMPL_DATE = DREMPL_DATE
        Me.AMTRANS_AMOUN = AMTRANS_AMOUN
        Me.AMTRANS_CREBY = AMTRANS_CREBY
        Me.AMTRANS_RDATE = AMTRANS_RDATE

    End Sub

    Sub New(REMPL_ID, DREMPL_DATE, AMTRANS_AMOUN, AMTRANS_CREBY, AMTRANS_RDATE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        Me.REMPL_ID = REMPL_ID
        Me.DREMPL_DATE = DREMPL_DATE
        Me.AMTRANS_AMOUN = AMTRANS_AMOUN
        Me.AMTRANS_CREBY = AMTRANS_CREBY
        Me.AMTRANS_RDATE = AMTRANS_RDATE

    End Sub

    Public Function InsertAmountToTransfer(ByVal EMPL_ID As Object) As Object
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_AMOUNT_TO_TRANSFER",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("DREMPL_DATE", _DREMPL_DATE)
            DB_Command.Parameters.AddWithValue("AMTRANS_AMOUN", _AMTRANS_AMOUN)
            DB_Command.Parameters.AddWithValue("AMTRANS_CREBY", _AMTRANS_CREBY)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_AmountToTransfer.InsertAmountToTransfer()")
            Return Nothing
        End Try
    End Function

    Public Function ValidarRegistroSemanal(ByVal fechaSeleccionada As Date) As Boolean
        Dim yaExiste As Boolean = False

        Dim diasDesdeJueves As Integer = CInt(fechaSeleccionada.DayOfWeek) - DayOfWeek.Thursday
        If diasDesdeJueves < 0 Then diasDesdeJueves += 7

        Dim fechaJueves As Date = fechaSeleccionada.AddDays(-diasDesdeJueves).Date
        Dim fechaMiercoles As Date = fechaJueves.AddDays(6).Date

        Dim Query As String = "SELECT COUNT(*) FROM dbo.OP_RecordsByEmployeeAmountToTransfer " &
                              "WHERE AMTRANS_RDATE >= @FechaInicio AND AMTRANS_RDATE <= @FechaFin"

        Try
            Using Conn As New SqlConnection(My.Settings.ConnectionString)
                Using Cmd As New SqlCommand(Query, Conn)
                    Cmd.Parameters.AddWithValue("@FechaInicio", fechaJueves)
                    Cmd.Parameters.AddWithValue("@FechaFin", fechaMiercoles)

                    Conn.Open()
                    Dim Conteo As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If Conteo > 0 Then
                        yaExiste = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            yaExiste = False
        End Try

        Return yaExiste
    End Function

End Class
