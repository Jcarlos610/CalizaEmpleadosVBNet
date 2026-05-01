Imports Microsoft.Data.SqlClient

Public Class CL_Payroll
    Public DB_Connection As SqlConnection
    Public DB_Command As SqlCommand
    Public DB_Reader As SqlDataReader

    Private _PayrollID As Object
    Private _EmployeeID As Object
    Private _StartDate As Object
    Private _EndDate As Object
    Private _Company As Object
    Private _FullName As Object
    Private _Position As Object
    Private _BaseSalary As Object
    Private _DailySalary As Object
    Private _AbsencesMonth As Object
    Private _ExtraS As Object
    Private _ExtraD As Object
    Private _ExtraT As Object
    Private _LunchHours As Object
    Private _LunchBonus As Object
    Private _ProductivityBonus As Object
    Private _AttitudeBonus As Object
    Private _Savings As Object
    Private _TransportDays As Object
    Private _TransportBonus As Object
    Private _LoanDiscount As Object
    Private _TotalNeto As Object
    Private _CreatedBy As Object
    Private _WorkDate As Object
    Private _Status As Object

    Public Property PayrollID As Object
        Get
            Return _PayrollID
        End Get
        Set(value As Object)
            _PayrollID = value
        End Set
    End Property

    Public Property EmployeeID As Object
        Get
            Return _EmployeeID
        End Get
        Set(value As Object)
            _EmployeeID = value
        End Set
    End Property

    Public Property StartDate As Object
        Get
            Return _StartDate
        End Get
        Set(value As Object)
            _StartDate = value
        End Set
    End Property

    Public Property EndDate As Object
        Get
            Return _EndDate
        End Get
        Set(value As Object)
            _EndDate = value
        End Set
    End Property

    Public Property Company As Object
        Get
            Return _Company
        End Get
        Set(value As Object)
            _Company = value
        End Set
    End Property

    Public Property FullName As Object
        Get
            Return _FullName
        End Get
        Set(value As Object)
            _FullName = value
        End Set
    End Property

    Public Property Position As Object
        Get
            Return _Position
        End Get
        Set(value As Object)
            _Position = value
        End Set
    End Property

    Public Property BaseSalary As Object
        Get
            Return _BaseSalary
        End Get
        Set(value As Object)
            _BaseSalary = value
        End Set
    End Property

    Public Property DailySalary As Object
        Get
            Return _DailySalary
        End Get
        Set(value As Object)
            _DailySalary = value
        End Set
    End Property

    Public Property AbsencesMonth As Object
        Get
            Return _AbsencesMonth
        End Get
        Set(value As Object)
            _AbsencesMonth = value
        End Set
    End Property

    Public Property ExtraS As Object
        Get
            Return _ExtraS
        End Get
        Set(value As Object)
            _ExtraS = value
        End Set
    End Property

    Public Property ExtraD As Object
        Get
            Return _ExtraD
        End Get
        Set(value As Object)
            _ExtraD = value
        End Set
    End Property

    Public Property ExtraT As Object
        Get
            Return _ExtraT
        End Get
        Set(value As Object)
            _ExtraT = value
        End Set
    End Property

    Public Property LunchHours As Object
        Get
            Return _LunchHours
        End Get
        Set(value As Object)
            _LunchHours = value
        End Set
    End Property

    Public Property LunchBonus As Object
        Get
            Return _LunchBonus
        End Get
        Set(value As Object)
            _LunchBonus = value
        End Set
    End Property

    Public Property ProductivityBonus As Object
        Get
            Return _ProductivityBonus
        End Get
        Set(value As Object)
            _ProductivityBonus = value
        End Set
    End Property

    Public Property AttitudeBonus As Object
        Get
            Return _AttitudeBonus
        End Get
        Set(value As Object)
            _AttitudeBonus = value
        End Set
    End Property

    Public Property Savings As Object
        Get
            Return _Savings
        End Get
        Set(value As Object)
            _Savings = value
        End Set
    End Property

    Public Property TransportDays As Object
        Get
            Return _TransportDays
        End Get
        Set(value As Object)
            _TransportDays = value
        End Set
    End Property

    Public Property TransportBonus As Object
        Get
            Return _TransportBonus
        End Get
        Set(value As Object)
            _TransportBonus = value
        End Set
    End Property

    Public Property LoanDiscount As Object
        Get
            Return _LoanDiscount
        End Get
        Set(value As Object)
            _LoanDiscount = value
        End Set
    End Property

    Public Property TotalNeto As Object
        Get
            Return _TotalNeto
        End Get
        Set(value As Object)
            _TotalNeto = value
        End Set
    End Property

    Public Property CreatedBy As Object
        Get
            Return _CreatedBy
        End Get
        Set(value As Object)
            _CreatedBy = value
        End Set
    End Property

    Public Property WorkDate As Object
        Get
            Return _WorkDate
        End Get
        Set(value As Object)
            _WorkDate = value
        End Set
    End Property

    Public Property Status As Object
        Get
            Return _Status
        End Get
        Set(value As Object)
            _Status = value
        End Set
    End Property

    Sub New()
        DB_Connection = New SqlConnection(My.Settings.ConnectionString)
    End Sub

    Public Function InsertPayrollWeek() As Object
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_PAYROLL_WEEK",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("EmployeeID", EmployeeID)
            DB_Command.Parameters.AddWithValue("StartDate", StartDate)
            DB_Command.Parameters.AddWithValue("EndDate", EndDate)
            DB_Command.Parameters.AddWithValue("Company", Company)
            DB_Command.Parameters.AddWithValue("FullName", FullName)
            DB_Command.Parameters.AddWithValue("Position", Position)
            DB_Command.Parameters.AddWithValue("BaseSalary", BaseSalary)
            DB_Command.Parameters.AddWithValue("DailySalary", DailySalary)
            DB_Command.Parameters.AddWithValue("AbsencesMonth", AbsencesMonth)
            DB_Command.Parameters.AddWithValue("ExtraS", ExtraS)
            DB_Command.Parameters.AddWithValue("ExtraD", ExtraD)
            DB_Command.Parameters.AddWithValue("ExtraT", ExtraT)
            DB_Command.Parameters.AddWithValue("LunchHours", LunchHours)
            DB_Command.Parameters.AddWithValue("LunchBonus", LunchBonus)
            DB_Command.Parameters.AddWithValue("ProductivityBonus", ProductivityBonus)
            DB_Command.Parameters.AddWithValue("AttitudeBonus", AttitudeBonus)
            DB_Command.Parameters.AddWithValue("Savings", Savings)
            DB_Command.Parameters.AddWithValue("TransportDays", TransportDays)
            DB_Command.Parameters.AddWithValue("TransportBonus", TransportBonus)
            DB_Command.Parameters.AddWithValue("LoanDiscount", LoanDiscount)
            DB_Command.Parameters.AddWithValue("TotalNeto", TotalNeto)
            DB_Command.Parameters.AddWithValue("CreatedBy", CreatedBy)

            Dim result = DB_Command.ExecuteScalar()

            DB_Connection.Close()
            Return result
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.InsertPayrollWeek()")
            Return Nothing
        End Try
    End Function

    Public Function InsertPayrollAttendance() As Boolean
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "INS_PAYROLL_ATTENDANCE",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("PayrollID", PayrollID)
            DB_Command.Parameters.AddWithValue("EmployeeID", EmployeeID)
            DB_Command.Parameters.AddWithValue("WorkDate", WorkDate)
            DB_Command.Parameters.AddWithValue("Status", Status)

            DB_Command.ExecuteNonQuery()

            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.InsertPayrollAttendance()")
            Return False
        End Try
    End Function

    Public Function GetWeeklyAttendance(startDate As Date, endDate As Date) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand("SEL_GETWEEKATTENDANCE", DB_Connection)
            DB_Command.CommandType = CommandType.StoredProcedure

            DB_Command.Parameters.AddWithValue("@StartDate", startDate)
            DB_Command.Parameters.AddWithValue("@EndDate", endDate)

            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error en CL_Payroll.GetWeeklyAttendance: " & ex.Message)
        End Try
        Return dt
    End Function

End Class
