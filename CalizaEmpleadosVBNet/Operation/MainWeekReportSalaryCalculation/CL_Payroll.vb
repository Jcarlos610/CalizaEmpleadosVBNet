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
    Private _Amonest As Object
    Private _TotalNeto As Object
    Private _CreatedBy As Object
    Private _WorkDate As Object
    Private _Status As Object
    Private _AttitudeBonusFinal As Object
    Private _ProductivityBonusFinal As Object
    Private _PlantBonusAmount As Object
    Private _TransportBetweenEmployeesBonus As Object
    Private _BotoneroTempFinal As Object
    Private _BotoneroFijoFinal As Object
    Private _LoanAmount As Object
    Private _LoanPaid As Object
    Private _LoanBalance As Object
    Private _HasInfonavit As Object
    Private _InfonavitAmount As Object
    Private _AbsenceHours As Object
    Private _AbsenceHoursDiscount As Object
    Private _DebtAmount As Object
    Private _DebtDiscount As Object
    Private _DebtBalance As Object
    Private _TransferAmount As Object
    Private _CashAmount As Object
    Private _BatchID As Object

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

    Public Property Amonest As Object
        Get
            Return _Amonest
        End Get
        Set(value As Object)
            _Amonest = value
        End Set
    End Property

    Public Property AttitudeBonusFinal As Object
        Get
            Return _AttitudeBonusFinal
        End Get
        Set(value As Object)
            _AttitudeBonusFinal = value
        End Set
    End Property

    Public Property ProductivityBonusFinal As Object
        Get
            Return _ProductivityBonusFinal
        End Get
        Set(value As Object)
            _ProductivityBonusFinal = value
        End Set
    End Property

    Public Property PlantBonusAmount As Object
        Get
            Return _PlantBonusAmount
        End Get
        Set(value As Object)
            _PlantBonusAmount = value
        End Set
    End Property

    Public Property TransportBetweenEmployeesBonus As Object
        Get
            Return _TransportBetweenEmployeesBonus
        End Get
        Set(value As Object)
            _TransportBetweenEmployeesBonus = value
        End Set
    End Property

    Public Property BotoneroTempFinal As Object
        Get
            Return _BotoneroTempFinal
        End Get
        Set(value As Object)
            _BotoneroTempFinal = value
        End Set
    End Property

    Public Property BotoneroFijoFinal As Object
        Get
            Return _BotoneroFijoFinal
        End Get
        Set(value As Object)
            _BotoneroFijoFinal = value
        End Set
    End Property

    Public Property LoanAmount As Object
        Get
            Return _LoanAmount
        End Get
        Set(value As Object)
            _LoanAmount = value
        End Set
    End Property

    Public Property LoanPaid As Object
        Get
            Return _LoanPaid
        End Get
        Set(value As Object)
            _LoanPaid = value
        End Set
    End Property

    Public Property LoanBalance As Object
        Get
            Return _LoanBalance
        End Get
        Set(value As Object)
            _LoanBalance = value
        End Set
    End Property

    Public Property HasInfonavit As Object
        Get
            Return _HasInfonavit
        End Get
        Set(value As Object)
            _HasInfonavit = value
        End Set
    End Property

    Public Property InfonavitAmount As Object
        Get
            Return _InfonavitAmount
        End Get
        Set(value As Object)
            _InfonavitAmount = value
        End Set
    End Property

    Public Property AbsenceHours As Object
        Get
            Return _AbsenceHours
        End Get
        Set(value As Object)
            _AbsenceHours = value
        End Set
    End Property

    Public Property AbsenceHoursDiscount As Object
        Get
            Return _AbsenceHoursDiscount
        End Get
        Set(value As Object)
            _AbsenceHoursDiscount = value
        End Set
    End Property

    Public Property DebtAmount As Object
        Get
            Return _DebtAmount
        End Get
        Set(value As Object)
            _DebtAmount = value
        End Set
    End Property

    Public Property DebtDiscount As Object
        Get
            Return _DebtDiscount
        End Get
        Set(value As Object)
            _DebtDiscount = value
        End Set
    End Property

    Public Property DebtBalance As Object
        Get
            Return _DebtBalance
        End Get
        Set(value As Object)
            _DebtBalance = value
        End Set
    End Property

    Public Property TransferAmount As Object
        Get
            Return _TransferAmount
        End Get
        Set(value As Object)
            _TransferAmount = value
        End Set
    End Property

    Public Property CashAmount As Object
        Get
            Return _CashAmount
        End Get
        Set(value As Object)
            _CashAmount = value
        End Set
    End Property

    Public Property BatchID As Object
        Get
            Return _BatchID
        End Get
        Set(value As Object)
            _BatchID = value
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
            DB_Command.Parameters.AddWithValue("BatchID", If(BatchID Is Nothing, DBNull.Value, BatchID))
            DB_Command.Parameters.AddWithValue("AttitudeBonusFinal", If(AttitudeBonusFinal Is Nothing, DBNull.Value, AttitudeBonusFinal))
            DB_Command.Parameters.AddWithValue("ProductivityBonusFinal", If(ProductivityBonusFinal Is Nothing, DBNull.Value, ProductivityBonusFinal))
            DB_Command.Parameters.AddWithValue("PlantBonusAmount", If(PlantBonusAmount Is Nothing, DBNull.Value, PlantBonusAmount))
            DB_Command.Parameters.AddWithValue("TransportBetweenEmployeesBonus", If(TransportBetweenEmployeesBonus Is Nothing, DBNull.Value, TransportBetweenEmployeesBonus))
            DB_Command.Parameters.AddWithValue("BotoneroTempFinal", If(BotoneroTempFinal Is Nothing, DBNull.Value, BotoneroTempFinal))
            DB_Command.Parameters.AddWithValue("BotoneroFijoFinal", If(BotoneroFijoFinal Is Nothing, DBNull.Value, BotoneroFijoFinal))
            DB_Command.Parameters.AddWithValue("LoanAmount", If(LoanAmount Is Nothing, DBNull.Value, LoanAmount))
            DB_Command.Parameters.AddWithValue("LoanPaid", If(LoanPaid Is Nothing, DBNull.Value, LoanPaid))
            DB_Command.Parameters.AddWithValue("LoanBalance", If(LoanBalance Is Nothing, DBNull.Value, LoanBalance))
            DB_Command.Parameters.AddWithValue("HasInfonavit", If(HasInfonavit Is Nothing, DBNull.Value, HasInfonavit))
            DB_Command.Parameters.AddWithValue("InfonavitAmount", If(InfonavitAmount Is Nothing, DBNull.Value, InfonavitAmount))
            DB_Command.Parameters.AddWithValue("AbsenceHours", If(AbsenceHours Is Nothing, DBNull.Value, AbsenceHours))
            DB_Command.Parameters.AddWithValue("AbsenceHoursDiscount", If(AbsenceHoursDiscount Is Nothing, DBNull.Value, AbsenceHoursDiscount))
            DB_Command.Parameters.AddWithValue("DebtAmount", If(DebtAmount Is Nothing, DBNull.Value, DebtAmount))
            DB_Command.Parameters.AddWithValue("DebtDiscount", If(DebtDiscount Is Nothing, DBNull.Value, DebtDiscount))
            DB_Command.Parameters.AddWithValue("DebtBalance", If(DebtBalance Is Nothing, DBNull.Value, DebtBalance))
            DB_Command.Parameters.AddWithValue("TransferAmount", If(TransferAmount Is Nothing, DBNull.Value, TransferAmount))
            DB_Command.Parameters.AddWithValue("CashAmount", If(CashAmount Is Nothing, DBNull.Value, CashAmount))

            Dim result = DB_Command.ExecuteScalar()

            DB_Connection.Close()
            Return result
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.InsertPayrollWeek()")
            Return Nothing
        End Try
    End Function

    Public Function InsertPayrollApproval(batchID As String, startDate As Date, endDate As Date,
                                       amount As Decimal, requestedBy As String) As Object
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "INS_PAYROLL_APPROVAL",
            .CommandType = CommandType.StoredProcedure
        }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("BatchID", batchID)
            DB_Command.Parameters.AddWithValue("StartDate", startDate)
            DB_Command.Parameters.AddWithValue("EndDate", endDate)
            DB_Command.Parameters.AddWithValue("Amount", amount)
            DB_Command.Parameters.AddWithValue("RequestedBy", requestedBy)
            Dim result = DB_Command.ExecuteScalar()
            DB_Connection.Close()
            Return result
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.InsertPayrollApproval()")
            Return Nothing
        End Try
    End Function

    Public Function UpdatePayrollApprovalStatus(approvalID As Integer, newStatus As String,
                                             reviewedBy As String, Optional rejectionReason As String = Nothing) As Boolean
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "UPD_PAYROLL_APPROVAL_STATUS",
            .CommandType = CommandType.StoredProcedure
        }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("ApprovalID", approvalID)
            DB_Command.Parameters.AddWithValue("NewStatus", newStatus)
            DB_Command.Parameters.AddWithValue("ReviewedBy", reviewedBy)
            DB_Command.Parameters.AddWithValue("RejectionReason", If(rejectionReason Is Nothing, DBNull.Value, rejectionReason))
            DB_Command.ExecuteNonQuery()
            DB_Connection.Close()
            Return True
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.UpdatePayrollApprovalStatus()")
            Return False
        End Try
    End Function

    Public Function GetPendingApprovals() As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand With {
            .CommandText = "SEL_PENDING_PAYROLL_APPROVALS",
            .CommandType = CommandType.StoredProcedure
        }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.GetPendingApprovals()")
            Return dt
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

            DB_Connection.Open()

            Dim adapter As New SqlDataAdapter(DB_Command)

            adapter.Fill(dt)

            DB_Connection.Close()

        Catch ex As Exception

            DB_Connection.Close()

            Throw New Exception("Error en CL_Payroll.GetWeeklyAttendance: " & ex.Message)

        End Try

        Return dt

    End Function

    Public Function ValidatePayrollWeek(startDate As Date,
                                    endDate As Date) As Boolean

        Dim dt As New DataTable

        Try

            DB_Command = New SqlCommand With {
                .CommandText = "SEL_VALIDATE_PAYROLL_WEEK",
                .CommandType = CommandType.StoredProcedure
            }

            DB_Connection.Open()

            DB_Command.Connection = DB_Connection

            DB_Command.Parameters.AddWithValue("@StartDate", startDate)
            DB_Command.Parameters.AddWithValue("@EndDate", endDate)

            Dim adapter As New SqlDataAdapter(DB_Command)

            adapter.Fill(dt)

            DB_Connection.Close()

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            DB_Connection.Close()

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    Public Function GetLatestBatchID(startDate As Date, endDate As Date) As String
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_LATEST_PAYROLL_BATCH",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@StartDate", startDate)
            DB_Command.Parameters.AddWithValue("@EndDate", endDate)
            Dim result = DB_Command.ExecuteScalar()
            DB_Connection.Close()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return result.ToString()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.GetLatestBatchID()")
            Return Nothing
        End Try
    End Function

    Public Function GetPayrollWeekNumber(startDate As Date) As Integer
        Dim jan1 As Date = New Date(startDate.Year, 1, 1)
        Dim offsetJan1 As Integer = (CInt(jan1.DayOfWeek) - 4 + 7) Mod 7   ' Jueves = 4
        Dim week1Start As Date = jan1.AddDays(-offsetJan1)
        Dim diasTranscurridos As Integer = (startDate - week1Start).Days
        Return (diasTranscurridos \ 7) + 1
    End Function

    Public Function GetBatchID(startDate As Date) As String
        Dim anio2Digitos As String = (startDate.Year Mod 100).ToString("00")
        Dim semana As String = GetPayrollWeekNumber(startDate).ToString("00")
        Return anio2Digitos & semana
    End Function

    Public Function GetPayrollWeekByBatch(batchID As String) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_PAYROLL_WEEK_BY_BATCH",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@BatchID", batchID)
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.GetPayrollWeekByBatch()")
            Return dt
        End Try
    End Function

    Public Function GetLatestApprovalByWeek(startDate As Date, endDate As Date) As DataTable
        Dim dt As New DataTable
        Try
            DB_Command = New SqlCommand With {
                .CommandText = "SEL_LATEST_PAYROLL_APPROVAL_BY_WEEK",
                .CommandType = CommandType.StoredProcedure
            }
            DB_Connection.Open()
            DB_Command.Connection = DB_Connection
            DB_Command.Parameters.AddWithValue("@StartDate", startDate)
            DB_Command.Parameters.AddWithValue("@EndDate", endDate)
            Dim adapter As New SqlDataAdapter(DB_Command)
            adapter.Fill(dt)
            DB_Connection.Close()
            Return dt
        Catch ex As Exception
            If DB_Connection.State = ConnectionState.Open Then DB_Connection.Close()
            MsgBox("Error: " & ex.Message & " CL_Payroll.GetLatestApprovalByWeek()")
            Return dt
        End Try
    End Function

End Class
