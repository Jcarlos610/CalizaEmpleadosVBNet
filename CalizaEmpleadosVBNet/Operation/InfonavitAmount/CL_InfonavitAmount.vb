Imports Microsoft.Data.SqlClient
Public Class CL_InfonavitAmount
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _INFONAVIT_ID As Object
    Private _REMPL_ID As Object
    Private _INFONAVIT_DATE As Object
    Private _INFONAVIT_AMOUN As Object
    Private _INFONAVIT_CREBY As Object
    Private _INFONAVIT_RDATE As Object
    Private _INFONAVIT_TYPE As Object

    Public Property INFONAVIT_ID As Object
        Get
            Return _INFONAVIT_ID
        End Get
        Set(value As Object)
            _INFONAVIT_ID = value
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

    Public Property INFONAVIT_DATE As Object
        Get
            Return _INFONAVIT_DATE
        End Get
        Set(value As Object)
            _INFONAVIT_DATE = value
        End Set
    End Property

    Public Property INFONAVIT_AMOUN As Object
        Get
            Return _INFONAVIT_AMOUN
        End Get
        Set(value As Object)
            _INFONAVIT_AMOUN = value
        End Set
    End Property

    Public Property INFONAVIT_CREBY As Object
        Get
            Return _INFONAVIT_CREBY
        End Get
        Set(value As Object)
            _INFONAVIT_CREBY = value
        End Set
    End Property

    Public Property INFONAVIT_RDATE As Object
        Get
            Return _INFONAVIT_RDATE
        End Get
        Set(value As Object)
            _INFONAVIT_RDATE = value
        End Set
    End Property

    Public Property INFONAVIT_TYPE As Object
        Get
            Return _INFONAVIT_TYPE
        End Get
        Set(value As Object)
            _INFONAVIT_TYPE = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(INFONAVIT_ID, REMPL_ID, INFONAVIT_DATE, INFONAVIT_AMOUN, INFONAVIT_CREBY, INFONAVIT_RDATE, INFONAVIT_TYPE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _INFONAVIT_ID = INFONAVIT_ID
        _REMPL_ID = REMPL_ID
        _INFONAVIT_DATE = INFONAVIT_DATE
        _INFONAVIT_AMOUN = INFONAVIT_AMOUN
        _INFONAVIT_CREBY = INFONAVIT_CREBY
        _INFONAVIT_RDATE = INFONAVIT_RDATE
        _INFONAVIT_TYPE = INFONAVIT_TYPE
    End Sub

    Sub New(REMPL_ID, INFONAVIT_DATE, INFONAVIT_AMOUN, INFONAVIT_CREBY, INFONAVIT_RDATE, INFONAVIT_TYPE)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _REMPL_ID = REMPL_ID
        _INFONAVIT_DATE = INFONAVIT_DATE
        _INFONAVIT_AMOUN = INFONAVIT_AMOUN
        _INFONAVIT_CREBY = INFONAVIT_CREBY
        _INFONAVIT_RDATE = INFONAVIT_RDATE
        _INFONAVIT_TYPE = INFONAVIT_TYPE
    End Sub

    Public Function InsertAmountInfonavit(ByVal EMPL_ID As Object) As Object
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_AMOUNT_INFONAVIT",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("INFONAVIT_DATE", _INFONAVIT_DATE)
            DB_Command.Parameters.AddWithValue("INFONAVIT_AMOUN", _INFONAVIT_AMOUN)
            DB_Command.Parameters.AddWithValue("INFONAVIT_CREBY", _INFONAVIT_CREBY)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_InfonavitAmount.InsertAmountInfonavit()")
            Return Nothing
        End Try
    End Function

    Public Function InsertAmountInfonavitManually(ByVal EMPL_ID As Object) As Object
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_AMOUNT_INFONAVIT_MANUALLY",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("INFONAVIT_DATE", _INFONAVIT_DATE)
            DB_Command.Parameters.AddWithValue("INFONAVIT_AMOUN", _INFONAVIT_AMOUN)
            DB_Command.Parameters.AddWithValue("INFONAVIT_CREBY", _INFONAVIT_CREBY)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_InfonavitAmount.InsertAmountInfonavitManually()")
            Return Nothing
        End Try
    End Function

    Public Function ValidarRegistroSemanalInfonavit(ByVal fechaSeleccionada As Date) As Boolean
        Dim yaExiste As Boolean = False

        Dim diasDesdeJueves As Integer = CInt(fechaSeleccionada.DayOfWeek) - DayOfWeek.Thursday
        If diasDesdeJueves < 0 Then diasDesdeJueves += 7

        Dim fechaJueves As Date = fechaSeleccionada.AddDays(-diasDesdeJueves).Date
        Dim fechaMiercoles As Date = fechaJueves.AddDays(6).Date

        Dim Query As String = "SELECT COUNT(*) FROM dbo.OP_RecordsByEmployeeAmountInfonavit " &
                      "WHERE INFONAVIT_DATE >= @FechaInicio AND INFONAVIT_DATE <= @FechaFin"

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

    Public Function UpdateInfonavitAmount(ByVal INFONAVIT_ID As Integer, ByVal NuevoMonto As Decimal, ByVal UsuarioModifica As String) As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_AMOUNT_INFONAVIT",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("InfonavitId", INFONAVIT_ID)
            DB_Command.Parameters.AddWithValue("NuevoMonto", NuevoMonto)
            DB_Command.Parameters.AddWithValue("UsuarioModifica", UsuarioModifica)

            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

            Return True

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_InfonavitAmount.UpdateInfonavitAmount()")
            Return False
        End Try
    End Function

    Public Function GetInfonavitAmountByWeek(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim Dt As New DataTable()
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_AMOUNTINFONAVIT_BYWEEK",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("FechaInicio", FechaInicio)
            DB_Command.Parameters.AddWithValue("FechaFin", FechaFin)

            Dim Da As New SqlDataAdapter(DB_Command)
            Da.Fill(Dt)

            DB_Connection.Close()

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_InfonavitAmount.GetInfonavitAmountByWeek()")
        End Try

        Return Dt
    End Function

    Public Function GetExistingWeeks() As DataTable
        Dim Dt As New DataTable()
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_INFONAVIT_EXISTING_WEEKS",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            Dim Da As New SqlDataAdapter(DB_Command)
            Da.Fill(Dt)

            DB_Connection.Close()
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error al obtener semanas: " & ex.Message & " CL_InfonavitAmount.GetExistingWeeks()")
        End Try
        Return Dt
    End Function

    Public Function SearchEmployeesByArea(ByVal SearchText As String, Optional ByVal IgnoreDept As Boolean = False, Optional ByVal OnlyInfonavit As Boolean = False) As DataTable
        Dim Dt As New DataTable()
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_EMPLOYEESEARCHBYAREA",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("AppUser", GlobalSession.GlobalUserName)
            DB_Command.Parameters.AddWithValue("SearchText", SearchText)
            DB_Command.Parameters.AddWithValue("IgnoreDept", If(IgnoreDept, 1, 0))
            DB_Command.Parameters.AddWithValue("OnlyInfonavit", If(OnlyInfonavit, 1, 0))

            Dim Da As New SqlDataAdapter(DB_Command)
            Da.Fill(Dt)
            DB_Connection.Close()

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error al buscar empleados en Infonavit: " & ex.Message)
        End Try
        Return Dt
    End Function

End Class
