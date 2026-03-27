Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class CL_Users
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _USER_ID As Object
    Private _EMPL_ID As Object
    Private _USER_NAME As Object
    Private _USER_PASSW As Object
    Private _USER_LACCESS As Object
    Private _USER_DATREG As Object

    Public Property USER_ID As Object
        Get
            Return _USER_ID
        End Get
        Set(value As Object)
            _USER_ID = value
        End Set
    End Property



    Public Property USER_NAME As Object
        Get
            Return _USER_NAME
        End Get
        Set(value As Object)
            _USER_NAME = value
        End Set
    End Property

    Public Property USER_PASSW As Object
        Get
            Return _USER_PASSW
        End Get
        Set(value As Object)
            _USER_PASSW = value
        End Set
    End Property

    Public Property USER_LACCESS As Object
        Get
            Return _USER_LACCESS
        End Get
        Set(value As Object)
            _USER_LACCESS = value
        End Set
    End Property

    Public Property USER_DATREG As Object
        Get
            Return _USER_DATREG
        End Get
        Set(value As Object)
            _USER_DATREG = value
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


    ' Constructor vacío
    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    ' INSERT
    Sub New(EMPL_ID, USER_NAME, USER_PASSW)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
        Me.EMPL_ID = EMPL_ID
        _USER_NAME = USER_NAME
        _USER_PASSW = USER_PASSW
    End Sub

    ' UPDATE
    Sub New(USER_ID, EMPL_ID, USER_NAME, USER_PASSW)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
        _USER_ID = USER_ID
        Me.EMPL_ID = EMPL_ID
        _USER_NAME = USER_NAME
        _USER_PASSW = USER_PASSW
    End Sub

    Public Function EncryptText(plainText As String, secretKey As String) As String
        Dim keyBytes As Byte() = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(secretKey))
        Dim ivBytes As Byte() = New Byte(15) {} ' 16 bytes en cero

        Using aes As Aes = Aes.Create()
            aes.Key = keyBytes
            aes.IV = ivBytes

            Using encryptor = aes.CreateEncryptor()
                Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
                Dim cipherBytes As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)
                Return Convert.ToBase64String(cipherBytes)
            End Using
        End Using
    End Function

    Public Function DecryptText(cipherText As String, secretKey As String) As String
        Dim keyBytes As Byte() = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(secretKey))
        Dim ivBytes As Byte() = New Byte(15) {}

        Using aes As Aes = Aes.Create()
            aes.Key = keyBytes
            aes.IV = ivBytes

            Using decryptor = aes.CreateDecryptor()
                Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
                Dim plainBytes As Byte() = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length)
                Return Encoding.UTF8.GetString(plainBytes)
            End Using
        End Using
    End Function

    Public Function InsertSystemUser() As Integer

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_SYSTEMUSER",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("@USER_NAME", _USER_NAME)
            DB_Command.Parameters.AddWithValue("@USER_PASSW", _USER_PASSW)

            '🔥 AQUÍ RECIBES EL ID REAL
            Dim newID As Integer = CInt(DB_Command.ExecuteScalar())

            DB_Connection.Close()

            Return newID

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message)
            Return 0
        End Try

    End Function

    Public Function GetUsers()

        Dim dt As New DataTable()
        dt.Columns.Add("USER_ID", GetType(Integer))
        dt.Columns.Add("EMPL_ID", GetType(Integer))
        dt.Columns.Add("COMPLETE_NAME", GetType(String))
        dt.Columns.Add("USER_NAME", GetType(String))
        dt.Columns.Add("USER_PASSW", GetType(String))
        dt.Columns.Add("USER_LACCESS", GetType(DateTime))
        dt.Columns.Add("USER_DATREG", GetType(DateTime))

        'dt.Rows.Add(0, "Seleccione un usuario")
        dt.Rows.Add(0, 0, "Seleccione un usuario", "", "", Nothing, Nothing)


        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_SYSTEMUSERS",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Users.GetUsers()")

            Return Nothing
        End Try
    End Function

    Public Function GetUserData()

        Dim dt As New DataTable()
        dt.Columns.Add("USER_ID", GetType(Integer))
        dt.Columns.Add("EMPL_ID", GetType(Integer))
        dt.Columns.Add("COMPLETE_NAME", GetType(String))
        dt.Columns.Add("USER_NAME", GetType(String))
        dt.Columns.Add("USER_PASSW", GetType(String))
        dt.Columns.Add("USER_LACCESS", GetType(DateTime))
        dt.Columns.Add("USER_DATREG", GetType(DateTime))



        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_USERDATA",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("USER_ID", _USER_ID)
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Users.GetUserData()")

            Return Nothing
        End Try
    End Function

    Public Function UpdateUser()
        Dim F_Resutl = False
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "UPD_SYSTEMUSER",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("USER_ID", _USER_ID)
            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
            DB_Command.Parameters.AddWithValue("USER_NAME", _USER_NAME)
            DB_Command.Parameters.AddWithValue("USER_PASSW", _USER_PASSW)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Users.UpdateUser()")

            Return Nothing
        End Try
    End Function

    Public Function ValidationUser(ByVal L_USERNM As String, l_PASSWRD As String) As Boolean

        Dim ValidUser As Boolean = False

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_VALIDATIONUSER",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("USER_NAME", L_USERNM.Trim())
            DB_Command.Parameters.AddWithValue("USER_PASSW", HashPassword(l_PASSWRD.Trim())) '🔥 HASH

            DB_Reader = DB_Command.ExecuteReader()

            If DB_Reader.HasRows Then
                DB_Reader.Read() '🔥 LEER FILA

                Me.USER_ID = CInt(DB_Reader("USER_ID")) '🔥 GUARDAR ID GLOBAL

                ValidUser = True
            End If

            DB_Connection.Close()

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox(ex.Message)
        End Try

        Return ValidUser



    End Function



    Public Function GetUsersList()

        Dim dt As New DataTable()

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_SYSTEMUSERS",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Users.GetUsersList()")
            Return Nothing
        End Try

    End Function

    Public Function HashPassword(password As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(password)
            Dim hash = sha.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Public Function GetUserPermissions(USER_ID As Integer) As DataTable

        Dim dt As New DataTable()

        Try
            DB_Command = New SqlCommand("SEL_USER_PERMISSIONS", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure
            DB_Command.Parameters.AddWithValue("@USER_ID", USER_ID)

            DB_Connection.Open()
            dt.Load(DB_Command.ExecuteReader())
            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error permisos: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function TienePermiso(USER_ID As Integer, FORM_NAME As String) As Boolean

        If EsAdmin() Then
            Return True
        End If

        Dim dt As DataTable = GetUserPermissions(USER_ID)


        If dt Is Nothing Then Return False


        For Each row As DataRow In dt.Rows



            If row("FORM_NAME").ToString().Trim().ToUpper() =
               FORM_NAME.Trim().ToUpper() Then
                Return True
            End If

        Next

        Return False

    End Function

    Public Function GetLastUserID() As Integer

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_LASTUSERID",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            Dim result = DB_Command.ExecuteScalar()

            DB_Connection.Close()

            Return CInt(result)

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message)
            Return 0
        End Try

    End Function

    Public Function GetUsersWithRoles() As DataTable

        Dim dt As New DataTable()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_USER_ROLES",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function GetUserRoles(USER_ID As Integer) As DataTable

        Dim dt As New DataTable()

        Try
            DB_Command = New SqlCommand("SEL_USER_ROLES_BY_USER", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.AddWithValue("@USER_ID", USER_ID)

            DB_Connection.Open()
            dt.Load(DB_Command.ExecuteReader())
            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Sub AssignRoleToUser(USER_ID As Integer, ROLE_ID As Integer)

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_USERROLE",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@USER_ID", USER_ID)
            DB_Command.Parameters.AddWithValue("@ROLE_ID", ROLE_ID)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error AssignRoleToUser: " & ex.Message)
        End Try

    End Sub

    Public Sub DeleteUserRoles(USER_ID As Integer)

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "DEL_USERROLES",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@USER_ID", USER_ID)

            DB_Connection.Open()
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Error: " & ex.Message)
        End Try

    End Sub

    Public Function GetUserDataByUsername(username As String) As DataTable

        Dim dt As New DataTable()

        Try
            DB_Command = New SqlCommand("
            SELECT USER_ID, USER_NAME
            FROM System_Users 
            WHERE USER_NAME = @USER_NAME", DB_Connection)

            DB_Command.Parameters.AddWithValue("@USER_NAME", username)

            DB_Connection.Open()
            dt.Load(DB_Command.ExecuteReader())
            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function GetUsersDetailed() As DataTable

        Dim dt As New DataTable()

        Try
            DB_Command = New SqlCommand("SEL_USER_ROLES", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Connection.Open()
            dt.Load(DB_Command.ExecuteReader())
            DB_Connection.Close()

            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function EsAdmin() As Boolean

        If String.IsNullOrEmpty(GlobalUserName) Then
            Return False
        End If

        If GlobalUserName.ToUpper() = "ADMINCALIZA" Then
            Return True
        End If

        Return False

    End Function

End Class
