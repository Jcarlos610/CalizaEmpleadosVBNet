Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module GL_Logger

    ''' <summary>
    ''' Guarda una bitácora o error directamente en la tabla APP_LOGS en SQL Server usando una conexión independiente.
    ''' </summary>
    Public Sub InsertLog(conn As SqlConnection,
                         appUser As String,
                         moduleName As String,
                         actionName As String,
                         description As String,
                         Optional recordId As Integer = 0,
                         Optional logLevel As String = "INFO",
                         Optional stackTrace As String = "")
        Try

            If conn Is Nothing Then Exit Sub

            Using logConn As New SqlConnection(conn.ConnectionString)

                Using cmd As New SqlCommand("INS_APP_LOG", logConn)
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.AddWithValue("@APP_USER", appUser)
                    cmd.Parameters.AddWithValue("@MODULE_NAME", moduleName)
                    cmd.Parameters.AddWithValue("@ACTION_NAME", actionName)
                    cmd.Parameters.AddWithValue("@DESCRIPTION", description)
                    cmd.Parameters.AddWithValue("@RECORD_ID", recordId)
                    cmd.Parameters.AddWithValue("@LOG_LEVEL", logLevel)

                    If String.IsNullOrEmpty(stackTrace) Then
                        cmd.Parameters.AddWithValue("@STACK_TRACE", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@STACK_TRACE", stackTrace)
                    End If

                    logConn.Open()

                    cmd.ExecuteNonQuery()

                End Using

                logConn.Close()

            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error crítico en bitácora de sistema: " & ex.Message)
        End Try
    End Sub

End Module