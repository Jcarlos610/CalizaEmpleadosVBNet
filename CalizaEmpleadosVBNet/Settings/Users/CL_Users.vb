Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class CL_Users
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _USER_ID As Object
    Private _USER_FNAME As Object
    Private _USER_LNAME As Object
    Private _USER_EMAIL As Object
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

    Public Property USER_FNAME As Object
        Get
            Return _USER_FNAME
        End Get
        Set(value As Object)
            _USER_FNAME = value
        End Set
    End Property

    Public Property USER_LNAME As Object
        Get
            Return _USER_LNAME
        End Get
        Set(value As Object)
            _USER_LNAME = value
        End Set
    End Property

    Public Property USER_EMAIL As Object
        Get
            Return _USER_EMAIL
        End Get
        Set(value As Object)
            _USER_EMAIL = value
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

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(USER_ID, USER_FNAME, USER_LNAME, USER_EMAIL, USER_NAME, USER_PASSW)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
        _USER_ID = USER_ID
        _USER_FNAME = USER_FNAME
        _USER_LNAME = USER_LNAME
        _USER_EMAIL = USER_EMAIL
        _USER_NAME = USER_NAME
        _USER_PASSW = USER_PASSW

    End Sub

    Sub New(USER_FNAME, USER_LNAME, USER_EMAIL, USER_NAME, USER_PASSW)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _USER_FNAME = USER_FNAME
        _USER_LNAME = USER_LNAME
        _USER_EMAIL = USER_EMAIL
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

    Public Function InsertSystemUser()
        Dim F_Resutl = False
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_SYSTEMUSER",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("USER_FNAME", _USER_FNAME)
            DB_Command.Parameters.AddWithValue("USER_LNAME", _USER_LNAME)
            DB_Command.Parameters.AddWithValue("USER_EMAIL", _USER_EMAIL)
            DB_Command.Parameters.AddWithValue("USER_NAME", _USER_NAME)
            DB_Command.Parameters.AddWithValue("USER_PASSW", _USER_PASSW)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_User.InsertSystemUser()")

            Return Nothing
        End Try
    End Function

    Public Function GetUsers()

        Dim dt As New DataTable()
        dt.Columns.Add("USER_ID", GetType(Integer))
        dt.Columns.Add("COMPLETE_NAME", GetType(String))
        dt.Columns.Add("USER_FNAME", GetType(String))
        dt.Columns.Add("USER_LNAME", GetType(String))
        dt.Columns.Add("USER_EMAIL", GetType(String))
        dt.Columns.Add("USER_NAME", GetType(String))
        dt.Columns.Add("USER_PASSW", GetType(String))
        dt.Columns.Add("USER_LACCESS", GetType(DateTime))
        dt.Columns.Add("USER_DATREG", GetType(DateTime))

        dt.Rows.Add(0, "Seleccione un usuario")

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
        dt.Columns.Add("COMPLETE_NAME", GetType(String))
        dt.Columns.Add("USER_FNAME", GetType(String))
        dt.Columns.Add("USER_LNAME", GetType(String))
        dt.Columns.Add("USER_EMAIL", GetType(String))
        dt.Columns.Add("USER_NAME", GetType(String))
        dt.Columns.Add("USER_PASSW", GetType(String))
        dt.Columns.Add("USER_LACCESS", GetType(DateTime))
        dt.Columns.Add("USER_DATREG", GetType(DateTime))

        dt.Rows.Add(0, "Seleccione un usuario")

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
            DB_Command.Parameters.AddWithValue("USER_FNAME", _USER_FNAME)
            DB_Command.Parameters.AddWithValue("USER_LNAME", _USER_LNAME)
            DB_Command.Parameters.AddWithValue("USER_EMAIL", _USER_EMAIL)
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
            DB_Command.Parameters.AddWithValue("USER_NAME", L_USERNM)
            DB_Command.Parameters.AddWithValue("USER_PASSW", l_PASSWRD)
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()

            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            For Each row As DataRow In LocalTable.Rows
                FirstName = row(1)
                LastName = row(2)
                ValidUser = True
            Next

            DB_Connection.Close()
            Return ValidUser

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Users.ValidationUser()")
            Return ValidUser
        End Try
    End Function
End Class
