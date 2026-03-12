'Imports Microsoft.Data.SqlClient

'Public Class CL_Employee
'    Public DB_Connection As SqlConnection
'    Public DB_Command As SqlCommand
'    Public DB_Reader As SqlDataReader

'    Private _EMPL_ID As Object
'    Private _EMPL_NAME As Object
'    Private _EMPL_LNAM1 As Object
'    Private _EMPL_LNAM2 As Object
'    Private _EMPL_BDATE As Object
'    Private _EMPL_BCITY As Object
'    Private _EMPL_PADDR As Object
'    Private _EMPL_PHONE As Object
'    Private _EMPL_EMAIL As Object
'    Private _EMPL_CSTAT As Object
'    Private _EMPL_CURP As Object
'    Private _EMPL_NSS As Object
'    Private _EMPL_RFC As Object
'    Private _EMPL_FADD As Object
'    Private _EMPL_NBANK As Object
'    Private _EMPL_BACCO As Object
'    Private _COMP_ID As Object
'    Private _EMPL_ETYPE As Object
'    Private _EMPL_EDATE As Object
'    Private _EMPL_RDATE As Object
'    Private _POSIT_ID As Object
'    Private _EMPL_SUPER As Object
'    Private _EMPL_DVAC As Object
'    Private _EMPL_SALAR As Object
'    Private _EMPL_ECONT As Object
'    Private _EMPL_EPARE As Object
'    Private _EMPL_ETELE As Object
'    Private _EMPL_EBENE As Object
'    Private _EMPL_CREBY As Object
'    Private _EMPL_PHOTO As Object
'    Private _EMPL_STAT As Object

'    Public Property EMPL_ID As Object
'        Get
'            Return _EMPL_ID
'        End Get
'        Set(value As Object)
'            _EMPL_ID = value
'        End Set
'    End Property

'    Public Property EMPL_NAME As Object
'        Get
'            Return _EMPL_NAME
'        End Get
'        Set(value As Object)
'            _EMPL_NAME = value
'        End Set
'    End Property

'    Public Property EMPL_LNAM1 As Object
'        Get
'            Return _EMPL_LNAM1
'        End Get
'        Set(value As Object)
'            _EMPL_LNAM1 = value
'        End Set
'    End Property

'    Public Property EMPL_LNAM2 As Object
'        Get
'            Return _EMPL_LNAM2
'        End Get
'        Set(value As Object)
'            _EMPL_LNAM2 = value
'        End Set
'    End Property

'    Public Property EMPL_BDATE As Object
'        Get
'            Return _EMPL_BDATE
'        End Get
'        Set(value As Object)
'            _EMPL_BDATE = value
'        End Set
'    End Property

'    Public Property EMPL_BCITY As Object
'        Get
'            Return _EMPL_BCITY
'        End Get
'        Set(value As Object)
'            _EMPL_BCITY = value
'        End Set
'    End Property

'    Public Property EMPL_PADDR As Object
'        Get
'            Return _EMPL_PADDR
'        End Get
'        Set(value As Object)
'            _EMPL_PADDR = value
'        End Set
'    End Property

'    Public Property EMPL_PHONE As Object
'        Get
'            Return _EMPL_PHONE
'        End Get
'        Set(value As Object)
'            _EMPL_PHONE = value
'        End Set
'    End Property

'    Public Property EMPL_EMAIL As Object
'        Get
'            Return _EMPL_EMAIL
'        End Get
'        Set(value As Object)
'            _EMPL_EMAIL = value
'        End Set
'    End Property

'    Public Property EMPL_CSTAT As Object
'        Get
'            Return _EMPL_CSTAT
'        End Get
'        Set(value As Object)
'            _EMPL_CSTAT = value
'        End Set
'    End Property

'    Public Property EMPL_CURP As Object
'        Get
'            Return _EMPL_CURP
'        End Get
'        Set(value As Object)
'            _EMPL_CURP = value
'        End Set
'    End Property

'    Public Property EMPL_NSS As Object
'        Get
'            Return _EMPL_NSS
'        End Get
'        Set(value As Object)
'            _EMPL_NSS = value
'        End Set
'    End Property

'    Public Property EMPL_RFC As Object
'        Get
'            Return _EMPL_RFC
'        End Get
'        Set(value As Object)
'            _EMPL_RFC = value
'        End Set
'    End Property

'    Public Property EMPL_FADD As Object
'        Get
'            Return _EMPL_FADD
'        End Get
'        Set(value As Object)
'            _EMPL_FADD = value
'        End Set
'    End Property

'    Public Property EMPL_NBANK As Object
'        Get
'            Return _EMPL_NBANK
'        End Get
'        Set(value As Object)
'            _EMPL_NBANK = value
'        End Set
'    End Property

'    Public Property EMPL_BACCO As Object
'        Get
'            Return _EMPL_BACCO
'        End Get
'        Set(value As Object)
'            _EMPL_BACCO = value
'        End Set
'    End Property

'    Public Property COMP_ID As Object
'        Get
'            Return _COMP_ID
'        End Get
'        Set(value As Object)
'            _COMP_ID = value
'        End Set
'    End Property

'    Public Property EMPL_ETYPE As Object
'        Get
'            Return _EMPL_ETYPE
'        End Get
'        Set(value As Object)
'            _EMPL_ETYPE = value
'        End Set
'    End Property

'    Public Property EMPL_EDATE As Object
'        Get
'            Return _EMPL_EDATE
'        End Get
'        Set(value As Object)
'            _EMPL_EDATE = value
'        End Set
'    End Property

'    Public Property EMPL_RDATE As Object
'        Get
'            Return _EMPL_RDATE
'        End Get
'        Set(value As Object)
'            _EMPL_RDATE = value
'        End Set
'    End Property

'    Public Property POSIT_ID As Object
'        Get
'            Return _POSIT_ID
'        End Get
'        Set(value As Object)
'            _POSIT_ID = value
'        End Set
'    End Property

'    Public Property EMPL_SUPER As Object
'        Get
'            Return _EMPL_SUPER
'        End Get
'        Set(value As Object)
'            _EMPL_SUPER = value
'        End Set
'    End Property

'    Public Property EMPL_DVAC As Object
'        Get
'            Return _EMPL_DVAC
'        End Get
'        Set(value As Object)
'            _EMPL_DVAC = value
'        End Set
'    End Property

'    Public Property EMPL_SALAR As Object
'        Get
'            Return _EMPL_SALAR
'        End Get
'        Set(value As Object)
'            _EMPL_SALAR = value
'        End Set
'    End Property

'    Public Property EMPL_ECONT As Object
'        Get
'            Return _EMPL_ECONT
'        End Get
'        Set(value As Object)
'            _EMPL_ECONT = value
'        End Set
'    End Property

'    Public Property EMPL_EPARE As Object
'        Get
'            Return _EMPL_EPARE
'        End Get
'        Set(value As Object)
'            _EMPL_EPARE = value
'        End Set
'    End Property

'    Public Property EMPL_ETELE As Object
'        Get
'            Return _EMPL_ETELE
'        End Get
'        Set(value As Object)
'            _EMPL_ETELE = value
'        End Set
'    End Property

'    Public Property EMPL_EBENE As Object
'        Get
'            Return _EMPL_EBENE
'        End Get
'        Set(value As Object)
'            _EMPL_EBENE = value
'        End Set
'    End Property

'    Public Property EMPL_STAT As Object
'        Get
'            Return _EMPL_STAT
'        End Get
'        Set(value As Object)
'            _EMPL_STAT = value
'        End Set
'    End Property

'    Public Property EMPL_CREBY As Object
'        Get
'            Return _EMPL_CREBY
'        End Get
'        Set(value As Object)
'            _EMPL_CREBY = value
'        End Set
'    End Property

'    Public Property EMPL_PHOTO As Object
'        Get
'            Return _EMPL_PHOTO
'        End Get
'        Set(value As Object)
'            _EMPL_PHOTO = value
'        End Set
'    End Property

'    Sub New()
'        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
'    End Sub

'    Sub New(EMPL_ID, EMPL_NAME, EMPL_LNAM1, EMPL_LNAM2, EMPL_BDATE, EMPL_BCITY, EMPL_PADDR, EMPL_PHONE, EMPL_EMAIL, EMPL_CSTAT, EMPL_CURP, EMPL_NSS, EMPL_RFC, EMPL_FADD, EMPL_NBANK, EMPL_BACCO, COMP_ID, EMPL_ETYPE, EMPL_EDATE, EMPL_RDATE, POSIT_ID, EMPL_SUPER, EMPL_DVAC, EMPL_SALAR, EMPL_ECONT, EMPL_EPARE, EMPL_ETELE, EMPL_EBENE, EMPL_CREBY, EMPL_PHOTO, EMPL_STAT)
'        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

'        _EMPL_ID = EMPL_ID
'        _EMPL_NAME = EMPL_NAME
'        _EMPL_LNAM1 = EMPL_LNAM1
'        _EMPL_LNAM2 = EMPL_LNAM2
'        _EMPL_BDATE = EMPL_BDATE
'        _EMPL_BCITY = EMPL_BCITY
'        _EMPL_PADDR = EMPL_PADDR
'        _EMPL_PHONE = EMPL_PHONE
'        _EMPL_EMAIL = EMPL_EMAIL
'        _EMPL_CSTAT = EMPL_CSTAT
'        _EMPL_CURP = EMPL_CURP
'        _EMPL_NSS = EMPL_NSS
'        _EMPL_RFC = EMPL_RFC
'        _EMPL_FADD = EMPL_FADD
'        _EMPL_NBANK = EMPL_NBANK
'        _EMPL_BACCO = EMPL_BACCO
'        _COMP_ID = COMP_ID
'        _EMPL_ETYPE = EMPL_ETYPE
'        _EMPL_EDATE = EMPL_EDATE
'        _EMPL_RDATE = EMPL_RDATE
'        _POSIT_ID = POSIT_ID
'        _EMPL_SUPER = EMPL_SUPER
'        _EMPL_DVAC = EMPL_DVAC
'        _EMPL_SALAR = EMPL_SALAR
'        _EMPL_ECONT = EMPL_ECONT
'        _EMPL_EPARE = EMPL_EPARE
'        _EMPL_ETELE = EMPL_ETELE
'        _EMPL_EBENE = EMPL_EBENE
'        _EMPL_CREBY = EMPL_CREBY
'        _EMPL_PHOTO = EMPL_PHOTO
'        _EMPL_STAT = EMPL_STAT


'    End Sub
'    Sub New(EMPL_NAME, EMPL_LNAM1, EMPL_LNAM2, EMPL_BDATE, EMPL_BCITY, EMPL_PADDR, EMPL_PHONE, EMPL_EMAIL, EMPL_CSTAT, EMPL_CURP, EMPL_NSS, EMPL_RFC, EMPL_FADD, EMPL_NBANK, EMPL_BACCO, COMP_ID, EMPL_ETYPE, EMPL_EDATE, EMPL_RDATE, POSIT_ID, EMPL_SUPER, EMPL_DVAC, EMPL_SALAR, EMPL_ECONT, EMPL_EPARE, EMPL_ETELE, EMPL_EBENE, EMPL_CREBY, EMPL_PHOTO, EMPL_STAT)
'        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

'        _EMPL_NAME = EMPL_NAME
'        _EMPL_LNAM1 = EMPL_LNAM1
'        _EMPL_LNAM2 = EMPL_LNAM2
'        _EMPL_BDATE = EMPL_BDATE
'        _EMPL_BCITY = EMPL_BCITY
'        _EMPL_PADDR = EMPL_PADDR
'        _EMPL_PHONE = EMPL_PHONE
'        _EMPL_EMAIL = EMPL_EMAIL
'        _EMPL_CSTAT = EMPL_CSTAT
'        _EMPL_CURP = EMPL_CURP
'        _EMPL_NSS = EMPL_NSS
'        _EMPL_RFC = EMPL_RFC
'        _EMPL_FADD = EMPL_FADD
'        _EMPL_NBANK = EMPL_NBANK
'        _EMPL_BACCO = EMPL_BACCO
'        _COMP_ID = COMP_ID
'        _EMPL_ETYPE = EMPL_ETYPE
'        _EMPL_EDATE = EMPL_EDATE
'        _EMPL_RDATE = EMPL_RDATE
'        _POSIT_ID = POSIT_ID
'        _EMPL_SUPER = EMPL_SUPER
'        _EMPL_DVAC = EMPL_DVAC
'        _EMPL_SALAR = EMPL_SALAR
'        _EMPL_ECONT = EMPL_ECONT
'        _EMPL_EPARE = EMPL_EPARE
'        _EMPL_ETELE = EMPL_ETELE
'        _EMPL_EBENE = EMPL_EBENE
'        _EMPL_CREBY = EMPL_CREBY
'        _EMPL_PHOTO = EMPL_PHOTO
'        _EMPL_STAT = EMPL_STAT

'    End Sub

'    Public Function InsertEmployee()

'        Try
'            DB_Command = New SqlCommand With {
'                .CommandText = "INS_EMPLOYEE",
'                .CommandType = CommandType.StoredProcedure
'            }
'            DB_Connection.Open()
'            DB_Command.Connection = DB_Connection
'            DB_Command.Parameters.AddWithValue("EMPL_NAME", _EMPL_NAME)
'            DB_Command.Parameters.AddWithValue("EMPL_LNAM1", _EMPL_LNAM1)
'            DB_Command.Parameters.AddWithValue("EMPL_LNAM2", _EMPL_LNAM2)
'            DB_Command.Parameters.AddWithValue("EMPL_BDATE", _EMPL_BDATE)
'            DB_Command.Parameters.AddWithValue("EMPL_BCITY", _EMPL_BCITY)
'            DB_Command.Parameters.AddWithValue("EMPL_PADDR", _EMPL_PADDR)
'            DB_Command.Parameters.AddWithValue("EMPL_PHONE", _EMPL_PHONE)
'            DB_Command.Parameters.AddWithValue("EMPL_EMAIL", _EMPL_EMAIL)
'            DB_Command.Parameters.AddWithValue("EMPL_CSTAT", _EMPL_CSTAT)
'            DB_Command.Parameters.AddWithValue("EMPL_CURP", _EMPL_CURP)
'            DB_Command.Parameters.AddWithValue("EMPL_NSS", _EMPL_NSS)
'            DB_Command.Parameters.AddWithValue("EMPL_RFC", _EMPL_RFC)
'            DB_Command.Parameters.AddWithValue("EMPL_FADD", _EMPL_FADD)
'            DB_Command.Parameters.AddWithValue("EMPL_NBANK", _EMPL_NBANK)
'            DB_Command.Parameters.AddWithValue("EMPL_BACCO", _EMPL_BACCO)
'            DB_Command.Parameters.AddWithValue("COMP_ID", _COMP_ID)
'            DB_Command.Parameters.AddWithValue("EMPL_ETYPE", _EMPL_ETYPE)
'            DB_Command.Parameters.AddWithValue("EMPL_EDATE", _EMPL_EDATE)
'            DB_Command.Parameters.AddWithValue("EMPL_RDATE", _EMPL_RDATE)
'            DB_Command.Parameters.AddWithValue("POSIT_ID", _POSIT_ID)
'            DB_Command.Parameters.AddWithValue("EMPL_SUPER", _EMPL_SUPER)
'            DB_Command.Parameters.AddWithValue("EMPL_DVAC", _EMPL_DVAC)
'            DB_Command.Parameters.AddWithValue("EMPL_SALAR", _EMPL_SALAR)
'            DB_Command.Parameters.AddWithValue("EMPL_ECONT", _EMPL_ECONT)
'            DB_Command.Parameters.AddWithValue("EMPL_EPARE", _EMPL_EPARE)
'            DB_Command.Parameters.AddWithValue("EMPL_ETELE", _EMPL_ETELE)
'            DB_Command.Parameters.AddWithValue("EMPL_EBENE", _EMPL_EBENE)
'            DB_Command.Parameters.AddWithValue("EMPL_CREBY", _EMPL_CREBY)
'            DB_Command.Parameters.AddWithValue("EMPL_PHOTO", _EMPL_PHOTO)
'            DB_Command.Parameters.AddWithValue("EMPL_STAT", _EMPL_STAT)

'            DB_Command.ExecuteNonQuery()

'            DB_Connection.Close()
'            Return True
'        Catch ex As Exception
'            DB_Connection.Close()
'            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employee.InsertEmployee()")

'            Return Nothing
'        End Try
'    End Function

'    Public Function Get_ListOfEmployees() As DataTable

'        Dim dt As New DataTable()
'        dt.Columns.Add("ID", GetType(Integer))
'        dt.Columns.Add("Nombre", GetType(String))

'        dt.Rows.Add(0, "Seleccione un empleado")

'        Try
'            DB_Command = New SqlCommand With {
'                .CommandText = "SEL_GETLISTOFEMPLOYEES",
'                .CommandType = CommandType.StoredProcedure
'            }
'            DB_Connection.Open()
'            DB_Command.Connection = DB_Connection
'            dt.Load(DB_Command.ExecuteReader())

'            DB_Connection.Close()
'            Return dt

'        Catch ex As Exception
'            DB_Connection.Close()
'            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_ListOfEmployees()")

'            Return Nothing
'        End Try
'    End Function

'    Public Function Get_AllEmployees() As DataTable
'        Try
'            DB_Command = New SqlCommand With {
'                .CommandText = "SEL_GETALLEMPLOYEES",
'                .CommandType = CommandType.StoredProcedure
'            }
'            DB_Connection.Open()
'            DB_Command.Connection = DB_Connection
'            DB_Reader = DB_Command.ExecuteReader()
'            DB_Command.Connection = DB_Connection
'            Dim LocalTable As New DataTable

'            LocalTable.Load(DB_Reader)
'            DB_Reader.Close()
'            DB_Connection.Close()
'            Return LocalTable
'        Catch ex As Exception
'            DB_Connection.Close()
'            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_AllEmployees()")

'            Return Nothing
'        End Try
'    End Function

'    Public Function Get_EmployeesInfo() As DataTable
'        Try
'            DB_Command = New SqlCommand With {
'                .CommandText = "SEL_GETEMPLOYEESINFO",
'                .CommandType = CommandType.StoredProcedure
'            }
'            DB_Connection.Open()
'            DB_Command.Connection = DB_Connection
'            DB_Reader = DB_Command.ExecuteReader()
'            DB_Command.Connection = DB_Connection
'            Dim LocalTable As New DataTable

'            LocalTable.Load(DB_Reader)
'            DB_Reader.Close()
'            DB_Connection.Close()
'            Return LocalTable
'        Catch ex As Exception
'            DB_Connection.Close()
'            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_EmployeesInfo()")

'            Return Nothing
'        End Try
'    End Function

'    Public Function Get_EmployeesInfoByID(ByVal EMPL_ID As Integer) As DataTable
'        Try
'            DB_Command = New SqlCommand With {
'                .CommandText = "SEL_GETEMPLOYEESINFOBYID",
'                .CommandType = CommandType.StoredProcedure
'            }
'            DB_Connection.Open()
'            DB_Command.Connection = DB_Connection
'            DB_Command.Parameters.AddWithValue("EMPL_ID", EMPL_ID)
'            DB_Reader = DB_Command.ExecuteReader()
'            DB_Command.Connection = DB_Connection
'            Dim LocalTable As New DataTable

'            LocalTable.Load(DB_Reader)
'            DB_Reader.Close()
'            DB_Connection.Close()
'            Return LocalTable
'        Catch ex As Exception
'            DB_Connection.Close()
'            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_EmployeesInfo()")

'            Return Nothing
'        End Try
'    End Function


'End Class

Imports Microsoft.Data.SqlClient

Public Class CL_Employee
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _EMPL_ID As Object
    Private _EMPL_NAME As Object
    Private _EMPL_LNAM1 As Object
    Private _EMPL_LNAM2 As Object
    Private _EMPL_BDATE As Object
    Private _EMPL_BCITY As Object
    Private _EMPL_PADDR As Object
    Private _EMPL_PHONE As Object
    Private _EMPL_EMAIL As Object
    Private _EMPL_CSTAT As Object
    Private _EMPL_CURP As Object
    Private _EMPL_NSS As Object
    Private _EMPL_RFC As Object
    Private _EMPL_FADD As Object
    Private _EMPL_NBANK As Object
    Private _EMPL_BACCO As Object
    Private _COMP_ID As Object
    Private _EMPL_ETYPE As Object
    Private _EMPL_EDATE As Object
    Private _EMPL_RDATE As Object
    Private _POSIT_ID As Object
    Private _EMPL_SUPER As Object
    Private _EMPL_DVAC As Object
    Private _EMPL_SALAR As Object
    Private _EMPL_ECONT As Object
    Private _EMPL_EPARE As Object
    Private _EMPL_ETELE As Object
    Private _EMPL_EBENE As Object
    Private _EMPL_CREBY As Object
    Private _EMPL_PHOTO As Object
    Private _EMPL_STAT As Object

    Public Property EMPL_ID As Object
        Get
            Return _EMPL_ID
        End Get
        Set(value As Object)
            _EMPL_ID = value
        End Set
    End Property

    Public Property EMPL_NAME As Object
        Get
            Return _EMPL_NAME
        End Get
        Set(value As Object)
            _EMPL_NAME = value
        End Set
    End Property

    Public Property EMPL_LNAM1 As Object
        Get
            Return _EMPL_LNAM1
        End Get
        Set(value As Object)
            _EMPL_LNAM1 = value
        End Set
    End Property

    Public Property EMPL_LNAM2 As Object
        Get
            Return _EMPL_LNAM2
        End Get
        Set(value As Object)
            _EMPL_LNAM2 = value
        End Set
    End Property

    Public Property EMPL_BDATE As Object
        Get
            Return _EMPL_BDATE
        End Get
        Set(value As Object)
            _EMPL_BDATE = value
        End Set
    End Property

    Public Property EMPL_BCITY As Object
        Get
            Return _EMPL_BCITY
        End Get
        Set(value As Object)
            _EMPL_BCITY = value
        End Set
    End Property

    Public Property EMPL_PADDR As Object
        Get
            Return _EMPL_PADDR
        End Get
        Set(value As Object)
            _EMPL_PADDR = value
        End Set
    End Property

    Public Property EMPL_PHONE As Object
        Get
            Return _EMPL_PHONE
        End Get
        Set(value As Object)
            _EMPL_PHONE = value
        End Set
    End Property

    Public Property EMPL_EMAIL As Object
        Get
            Return _EMPL_EMAIL
        End Get
        Set(value As Object)
            _EMPL_EMAIL = value
        End Set
    End Property

    Public Property EMPL_CSTAT As Object
        Get
            Return _EMPL_CSTAT
        End Get
        Set(value As Object)
            _EMPL_CSTAT = value
        End Set
    End Property

    Public Property EMPL_CURP As Object
        Get
            Return _EMPL_CURP
        End Get
        Set(value As Object)
            _EMPL_CURP = value
        End Set
    End Property

    Public Property EMPL_NSS As Object
        Get
            Return _EMPL_NSS
        End Get
        Set(value As Object)
            _EMPL_NSS = value
        End Set
    End Property

    Public Property EMPL_RFC As Object
        Get
            Return _EMPL_RFC
        End Get
        Set(value As Object)
            _EMPL_RFC = value
        End Set
    End Property

    Public Property EMPL_FADD As Object
        Get
            Return _EMPL_FADD
        End Get
        Set(value As Object)
            _EMPL_FADD = value
        End Set
    End Property

    Public Property EMPL_NBANK As Object
        Get
            Return _EMPL_NBANK
        End Get
        Set(value As Object)
            _EMPL_NBANK = value
        End Set
    End Property

    Public Property EMPL_BACCO As Object
        Get
            Return _EMPL_BACCO
        End Get
        Set(value As Object)
            _EMPL_BACCO = value
        End Set
    End Property

    Public Property COMP_ID As Object
        Get
            Return _COMP_ID
        End Get
        Set(value As Object)
            _COMP_ID = value
        End Set
    End Property

    Public Property EMPL_ETYPE As Object
        Get
            Return _EMPL_ETYPE
        End Get
        Set(value As Object)
            _EMPL_ETYPE = value
        End Set
    End Property

    Public Property EMPL_EDATE As Object
        Get
            Return _EMPL_EDATE
        End Get
        Set(value As Object)
            _EMPL_EDATE = value
        End Set
    End Property

    Public Property EMPL_RDATE As Object
        Get
            Return _EMPL_RDATE
        End Get
        Set(value As Object)
            _EMPL_RDATE = value
        End Set
    End Property

    Public Property POSIT_ID As Object
        Get
            Return _POSIT_ID
        End Get
        Set(value As Object)
            _POSIT_ID = value
        End Set
    End Property

    Public Property EMPL_SUPER As Object
        Get
            Return _EMPL_SUPER
        End Get
        Set(value As Object)
            _EMPL_SUPER = value
        End Set
    End Property

    Public Property EMPL_DVAC As Object
        Get
            Return _EMPL_DVAC
        End Get
        Set(value As Object)
            _EMPL_DVAC = value
        End Set
    End Property

    Public Property EMPL_SALAR As Object
        Get
            Return _EMPL_SALAR
        End Get
        Set(value As Object)
            _EMPL_SALAR = value
        End Set
    End Property

    Public Property EMPL_ECONT As Object
        Get
            Return _EMPL_ECONT
        End Get
        Set(value As Object)
            _EMPL_ECONT = value
        End Set
    End Property

    Public Property EMPL_EPARE As Object
        Get
            Return _EMPL_EPARE
        End Get
        Set(value As Object)
            _EMPL_EPARE = value
        End Set
    End Property

    Public Property EMPL_ETELE As Object
        Get
            Return _EMPL_ETELE
        End Get
        Set(value As Object)
            _EMPL_ETELE = value
        End Set
    End Property

    Public Property EMPL_EBENE As Object
        Get
            Return _EMPL_EBENE
        End Get
        Set(value As Object)
            _EMPL_EBENE = value
        End Set
    End Property

    Public Property EMPL_STAT As Object
        Get
            Return _EMPL_STAT
        End Get
        Set(value As Object)
            _EMPL_STAT = value
        End Set
    End Property

    Public Property EMPL_CREBY As Object
        Get
            Return _EMPL_CREBY
        End Get
        Set(value As Object)
            _EMPL_CREBY = value
        End Set
    End Property

    Public Property EMPL_PHOTO As Object
        Get
            Return _EMPL_PHOTO
        End Get
        Set(value As Object)
            _EMPL_PHOTO = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Sub New(EMPL_ID, EMPL_NAME, EMPL_LNAM1, EMPL_LNAM2, EMPL_BDATE, EMPL_BCITY, EMPL_PADDR, EMPL_PHONE, EMPL_EMAIL, EMPL_CSTAT, EMPL_CURP, EMPL_NSS, EMPL_RFC, EMPL_FADD, EMPL_NBANK, EMPL_BACCO, COMP_ID, EMPL_ETYPE, EMPL_EDATE, EMPL_RDATE, POSIT_ID, EMPL_SUPER, EMPL_DVAC, EMPL_SALAR, EMPL_ECONT, EMPL_EPARE, EMPL_ETELE, EMPL_EBENE, EMPL_CREBY, EMPL_PHOTO, EMPL_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_ID = EMPL_ID
        _EMPL_NAME = EMPL_NAME
        _EMPL_LNAM1 = EMPL_LNAM1
        _EMPL_LNAM2 = EMPL_LNAM2
        _EMPL_BDATE = EMPL_BDATE
        _EMPL_BCITY = EMPL_BCITY
        _EMPL_PADDR = EMPL_PADDR
        _EMPL_PHONE = EMPL_PHONE
        _EMPL_EMAIL = EMPL_EMAIL
        _EMPL_CSTAT = EMPL_CSTAT
        _EMPL_CURP = EMPL_CURP
        _EMPL_NSS = EMPL_NSS
        _EMPL_RFC = EMPL_RFC
        _EMPL_FADD = EMPL_FADD
        _EMPL_NBANK = EMPL_NBANK
        _EMPL_BACCO = EMPL_BACCO
        _COMP_ID = COMP_ID
        _EMPL_ETYPE = EMPL_ETYPE
        _EMPL_EDATE = EMPL_EDATE
        _EMPL_RDATE = EMPL_RDATE
        _POSIT_ID = POSIT_ID
        _EMPL_SUPER = EMPL_SUPER
        _EMPL_DVAC = EMPL_DVAC
        _EMPL_SALAR = EMPL_SALAR
        _EMPL_ECONT = EMPL_ECONT
        _EMPL_EPARE = EMPL_EPARE
        _EMPL_ETELE = EMPL_ETELE
        _EMPL_EBENE = EMPL_EBENE
        _EMPL_CREBY = EMPL_CREBY
        _EMPL_PHOTO = EMPL_PHOTO
        _EMPL_STAT = EMPL_STAT


    End Sub
    Sub New(EMPL_NAME, EMPL_LNAM1, EMPL_LNAM2, EMPL_BDATE, EMPL_BCITY, EMPL_PADDR, EMPL_PHONE, EMPL_EMAIL, EMPL_CSTAT, EMPL_CURP, EMPL_NSS, EMPL_RFC, EMPL_FADD, EMPL_NBANK, EMPL_BACCO, COMP_ID, EMPL_ETYPE, EMPL_EDATE, EMPL_RDATE, POSIT_ID, EMPL_SUPER, EMPL_DVAC, EMPL_SALAR, EMPL_ECONT, EMPL_EPARE, EMPL_ETELE, EMPL_EBENE, EMPL_CREBY, EMPL_PHOTO, EMPL_STAT)
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)

        _EMPL_NAME = EMPL_NAME
        _EMPL_LNAM1 = EMPL_LNAM1
        _EMPL_LNAM2 = EMPL_LNAM2
        _EMPL_BDATE = EMPL_BDATE
        _EMPL_BCITY = EMPL_BCITY
        _EMPL_PADDR = EMPL_PADDR
        _EMPL_PHONE = EMPL_PHONE
        _EMPL_EMAIL = EMPL_EMAIL
        _EMPL_CSTAT = EMPL_CSTAT
        _EMPL_CURP = EMPL_CURP
        _EMPL_NSS = EMPL_NSS
        _EMPL_RFC = EMPL_RFC
        _EMPL_FADD = EMPL_FADD
        _EMPL_NBANK = EMPL_NBANK
        _EMPL_BACCO = EMPL_BACCO
        _COMP_ID = COMP_ID
        _EMPL_ETYPE = EMPL_ETYPE
        _EMPL_EDATE = EMPL_EDATE
        _EMPL_RDATE = EMPL_RDATE
        _POSIT_ID = POSIT_ID
        _EMPL_SUPER = EMPL_SUPER
        _EMPL_DVAC = EMPL_DVAC
        _EMPL_SALAR = EMPL_SALAR
        _EMPL_ECONT = EMPL_ECONT
        _EMPL_EPARE = EMPL_EPARE
        _EMPL_ETELE = EMPL_ETELE
        _EMPL_EBENE = EMPL_EBENE
        _EMPL_CREBY = EMPL_CREBY
        _EMPL_PHOTO = EMPL_PHOTO
        _EMPL_STAT = EMPL_STAT

    End Sub

    Public Function InsertEmployee()

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_EMPLOYEE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("EMPL_NAME", _EMPL_NAME)
            DB_Command.Parameters.AddWithValue("EMPL_LNAM1", _EMPL_LNAM1)
            DB_Command.Parameters.AddWithValue("EMPL_LNAM2", _EMPL_LNAM2)
            DB_Command.Parameters.AddWithValue("EMPL_BDATE", _EMPL_BDATE)
            DB_Command.Parameters.AddWithValue("EMPL_BCITY", _EMPL_BCITY)
            DB_Command.Parameters.AddWithValue("EMPL_PADDR", _EMPL_PADDR)
            DB_Command.Parameters.AddWithValue("EMPL_PHONE", _EMPL_PHONE)
            DB_Command.Parameters.AddWithValue("EMPL_EMAIL", _EMPL_EMAIL)
            DB_Command.Parameters.AddWithValue("EMPL_CSTAT", _EMPL_CSTAT)
            DB_Command.Parameters.AddWithValue("EMPL_CURP", _EMPL_CURP)
            DB_Command.Parameters.AddWithValue("EMPL_NSS", _EMPL_NSS)
            DB_Command.Parameters.AddWithValue("EMPL_RFC", _EMPL_RFC)
            DB_Command.Parameters.AddWithValue("EMPL_FADD", _EMPL_FADD)
            DB_Command.Parameters.AddWithValue("EMPL_NBANK", _EMPL_NBANK)
            DB_Command.Parameters.AddWithValue("EMPL_BACCO", _EMPL_BACCO)
            DB_Command.Parameters.AddWithValue("COMP_ID", _COMP_ID)
            DB_Command.Parameters.AddWithValue("EMPL_ETYPE", _EMPL_ETYPE)
            DB_Command.Parameters.AddWithValue("EMPL_EDATE", _EMPL_EDATE)
            DB_Command.Parameters.AddWithValue("EMPL_RDATE", _EMPL_RDATE)
            DB_Command.Parameters.AddWithValue("POSIT_ID", _POSIT_ID)
            DB_Command.Parameters.AddWithValue("EMPL_SUPER", _EMPL_SUPER)
            DB_Command.Parameters.AddWithValue("EMPL_DVAC", _EMPL_DVAC)
            DB_Command.Parameters.AddWithValue("EMPL_SALAR", _EMPL_SALAR)
            DB_Command.Parameters.AddWithValue("EMPL_ECONT", _EMPL_ECONT)
            DB_Command.Parameters.AddWithValue("EMPL_EPARE", _EMPL_EPARE)
            DB_Command.Parameters.AddWithValue("EMPL_ETELE", _EMPL_ETELE)
            DB_Command.Parameters.AddWithValue("EMPL_EBENE", _EMPL_EBENE)
            DB_Command.Parameters.AddWithValue("EMPL_CREBY", _EMPL_CREBY)
            If _EMPL_PHOTO Is Nothing Then
                DB_Command.Parameters.AddWithValue("EMPL_PHOTO", DBNull.Value)
            Else
                DB_Command.Parameters.AddWithValue("EMPL_PHOTO", _EMPL_PHOTO)
            End If
            DB_Command.Parameters.AddWithValue("EMPL_STAT", _EMPL_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employee.InsertEmployee()")

            Return Nothing
        End Try
    End Function

    Public Function Get_ListOfEmployees() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Seleccione un empleado")

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETLISTOFEMPLOYEES",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            dt.Load(DB_Command.ExecuteReader())

            DB_Connection.Close()
            Return dt

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Benefits.Get_ListOfEmployees()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllEmployees() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETALLEMPLOYEES",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_AllEmployees()")

            Return Nothing
        End Try
    End Function

    Public Function Get_EmployeesInfo() As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETEMPLOYEESINFO",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable
        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_EmployeesInfo()")

            Return Nothing
        End Try
    End Function

    Public Function Get_EmployeesInfoByID(ByVal EMPL_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETEMPLOYEESINFOBYID",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_EmployeesInfo()")

            Return Nothing
        End Try
    End Function

    Public Function UpdateEmployee()

        Try
            DB_Command = New SqlCommand With {
            .CommandText = "UPD_EMPLOYEE",
            .CommandType = CommandType.StoredProcedure
        }

            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("EMPL_ID", _EMPL_ID)
            DB_Command.Parameters.AddWithValue("EMPL_NAME", _EMPL_NAME)
            DB_Command.Parameters.AddWithValue("EMPL_LNAM1", _EMPL_LNAM1)
            DB_Command.Parameters.AddWithValue("EMPL_LNAM2", _EMPL_LNAM2)
            DB_Command.Parameters.AddWithValue("EMPL_BDATE", _EMPL_BDATE)
            DB_Command.Parameters.AddWithValue("EMPL_BCITY", _EMPL_BCITY)
            DB_Command.Parameters.AddWithValue("EMPL_PADDR", _EMPL_PADDR)
            DB_Command.Parameters.AddWithValue("EMPL_PHONE", _EMPL_PHONE)
            DB_Command.Parameters.AddWithValue("EMPL_EMAIL", _EMPL_EMAIL)
            DB_Command.Parameters.AddWithValue("EMPL_CSTAT", _EMPL_CSTAT)
            DB_Command.Parameters.AddWithValue("EMPL_CURP", _EMPL_CURP)
            DB_Command.Parameters.AddWithValue("EMPL_NSS", _EMPL_NSS)
            DB_Command.Parameters.AddWithValue("EMPL_RFC", _EMPL_RFC)
            DB_Command.Parameters.AddWithValue("EMPL_FADD", _EMPL_FADD)
            DB_Command.Parameters.AddWithValue("EMPL_NBANK", _EMPL_NBANK)
            DB_Command.Parameters.AddWithValue("EMPL_BACCO", _EMPL_BACCO)
            DB_Command.Parameters.AddWithValue("COMP_ID", _COMP_ID)
            DB_Command.Parameters.AddWithValue("EMPL_ETYPE", _EMPL_ETYPE)
            DB_Command.Parameters.AddWithValue("EMPL_EDATE", _EMPL_EDATE)
            DB_Command.Parameters.AddWithValue("EMPL_RDATE", _EMPL_RDATE)
            DB_Command.Parameters.AddWithValue("POSIT_ID", _POSIT_ID)
            DB_Command.Parameters.AddWithValue("EMPL_SUPER", _EMPL_SUPER)
            DB_Command.Parameters.AddWithValue("EMPL_DVAC", _EMPL_DVAC)
            DB_Command.Parameters.AddWithValue("EMPL_SALAR", _EMPL_SALAR)
            DB_Command.Parameters.AddWithValue("EMPL_ECONT", _EMPL_ECONT)
            DB_Command.Parameters.AddWithValue("EMPL_EPARE", _EMPL_EPARE)
            DB_Command.Parameters.AddWithValue("EMPL_ETELE", _EMPL_ETELE)
            DB_Command.Parameters.AddWithValue("EMPL_EBENE", _EMPL_EBENE)
            DB_Command.Parameters.AddWithValue("EMPL_PHOTO", _EMPL_PHOTO)
            DB_Command.Parameters.AddWithValue("EMPL_STAT", _EMPL_STAT)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()

            Return True

        Catch ex As Exception

            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employee.UpdateEmployee()")

            Return Nothing

        End Try

    End Function

    Public Function Get_SelectedEmployeesIDInfo(ByVal EMPL_ID As Integer) As DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_GETSELECTEDEMPLOYEEIDINFO",
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
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_SelectedEmployeesIDInfo()")

            Return Nothing
        End Try
    End Function

    Public Function Get_AllActiveEmployeesID() As DataTable

        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_ALLACTIVEEMPLOYEESID",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Reader = DB_Command.ExecuteReader()
            DB_Command.Connection = DB_Connection
            Dim LocalTable As New DataTable

            LocalTable.Load(DB_Reader)
            DB_Reader.Close()
            DB_Connection.Close()
            Return LocalTable

        Catch ex As Exception
            DB_Connection.Close()
            MsgBox("Ocurrio el siguiente error: " & ex.Message & " CL_Employees.Get_AllActiveEmployeesID()")

            Return Nothing
        End Try
    End Function

End Class
