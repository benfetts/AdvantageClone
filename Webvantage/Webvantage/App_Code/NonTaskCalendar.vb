Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Specialized



Public Class ClientNonTaskCalendar
    Inherits _WV_NONTASK_CALENDAR

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

    Public Function GetNonTaskCalendar(ByVal Month As Integer, _
                                       ByVal Year As Integer, _
                                       ByVal UserID As String, _
                                       ByVal ROLES As String, _
                                       Optional ByVal EmpCode As String = "", _
                                       Optional ByVal showTasks As Boolean = False, _
                                       Optional ByVal showHolidays As Boolean = False, _
                                       Optional ByVal showAppointments As Boolean = False, _
                                       Optional ByVal DEPTS As String = "")


        Dim Parms As ListDictionary = New ListDictionary
        Dim StartDateString As String = Month.ToString() & "/1/" & Year.ToString
        Dim DaysInMonth As Integer = Date.DaysInMonth(Year, Month)
        Dim startDate As Date = New Date(Year, Month, 1)

        Parms.Add("@StartDate", StartDateString)
        Parms.Add("@EndDate", CStr(Month) & "/" & DaysInMonth.ToString() & "/" & Year.ToString())
        Parms.Add("@EmpCode", EmpCode)
        If showHolidays = True And showAppointments = True Then
            Parms.Add("@Type", "")
        ElseIf showHolidays = True And showAppointments = False Then
            Parms.Add("@Type", "H")
        ElseIf showHolidays = False And showAppointments = True Then
            Parms.Add("@Type", "A")
        Else
            Parms.Add("@Type", "N")
        End If
        Parms.Add("@UserID", UserID)
        Try
            Dim sr As String = ""
            If ROLES.Trim() <> "" Then
                sr = ROLES.Trim.Replace("'", "")
                If sr.IndexOf(",") > -1 Then
                    ROLES = ""
                    Dim ar() As String
                    ar = sr.Split(",")
                    For x As Integer = 0 To sr.Length - 1
                        ROLES &= ROLES & "'" & ar(x) & "',"
                    Next
                    ROLES = MiscFN.RemoveTrailingDelimiter(ROLES, ",")
                Else
                    ROLES = "'" & sr & "'"
                End If
            End If
        Catch ex As Exception
            ROLES = ""
        End Try
        Parms.Add("@ROLES", ROLES)

        Try
            Dim sd As String = ""
            If DEPTS.Trim() <> "" Then
                sd = DEPTS.Trim.Replace("'", "")
                If sd.IndexOf(",") > -1 Then
                    DEPTS = ""
                    Dim ar() As String
                    ar = sd.Split(",")
                    For x As Integer = 0 To sd.Length - 1
                        DEPTS &= DEPTS & "'" & ar(x) & "',"
                    Next
                    DEPTS = MiscFN.RemoveTrailingDelimiter(DEPTS, ",")
                Else
                    DEPTS = "'" & sd & "'"
                End If
            End If
        Catch ex As Exception
            DEPTS = ""
        End Try
        Parms.Add("@DEPTS", DEPTS)

        Me.LoadFromSql("[usp_wv_nontask_GetTasks]", Parms, CommandType.StoredProcedure)

    End Function
    Public Sub GetMediaCalendarByDateRange(ByVal StartDate As Date, ByVal EndDate As Date, _
                                            ByVal Client As String, _
                                            Optional ByVal Magazine As Boolean = True, _
                                            Optional ByVal NewsPaper As Boolean = True, _
                                            Optional ByVal Internet As Boolean = True, _
                                            Optional ByVal OutOfHome As Boolean = True, _
                                            Optional ByVal Television As Boolean = True, _
                                            Optional ByVal Radio As Boolean = True, _
                                            Optional ByVal Division As String = "", _
                                            Optional ByVal Product As String = "", _
                                            Optional ByVal MediaType As String = "", _
                                            Optional ByVal Campaign As String = "", _
                                            Optional ByVal ClientPO As String = "", _
                                            Optional ByVal Vendor As String = "", _
                                            Optional ByVal Buyer As String = "", _
                                            Optional ByVal AcceptedOrdersOnly As Boolean = True, _
                                            Optional ByVal CancelledOrders As Boolean = False, _
                                            Optional ByVal CloseDate As Boolean = False, _
                                            Optional ByVal MatDueDate As Boolean = False, _
                                            Optional ByVal ExtMatDueDate As Boolean = False, _
                                            Optional ByVal ExtCloseDate As Boolean = False, _
                                            Optional ByVal RunInsertionDate As Boolean = True)


        Dim Parms As ListDictionary = New ListDictionary


        Parms.Add("@MagazineInc", BoolToYN(Magazine))
        Parms.Add("@NewspaperInc", BoolToYN(NewsPaper))
        Parms.Add("@InternetInc", BoolToYN(Internet))
        Parms.Add("@OutOfHomeInc", BoolToYN(OutOfHome))
        Parms.Add("@TelevisionInc", BoolToYN(Television))
        Parms.Add("@RadioInc", BoolToYN(Radio))
        Parms.Add("@AcceptedOrdersOnly", BoolToYN(AcceptedOrdersOnly))
        Parms.Add("@ClientCode", Client)
        Parms.Add("@DivCode", Division)
        Parms.Add("@ProdCode", Product)
        Parms.Add("@MediaType", MediaType)
        Parms.Add("@Campaign", Campaign)
        Parms.Add("@ClientPO", ClientPO)
        Parms.Add("@VendorID", Vendor)
        Parms.Add("@BuyerID", Buyer)
        Parms.Add("@StartDate", Format(StartDate, "MM/dd/yyyy"))
        Parms.Add("@EndDate", Format(EndDate, "MM/dd/yyyy"))
        Parms.Add("@MatDueDate", BoolToYN(MatDueDate))
        Parms.Add("@ExtMatDueDate", BoolToYN(ExtMatDueDate))
        Parms.Add("@CloseDate", BoolToYN(CloseDate))
        Parms.Add("@ExtCloseDate", BoolToYN(ExtCloseDate))
        Parms.Add("@RunInsertionDate", BoolToYN(RunInsertionDate))
        Parms.Add("@MediaMonth", Format(StartDate, "MMM").ToUpper)
        Parms.Add("@MediaYear", StartDate.Year)
        Parms.Add("@LineCancelled", BoolToYN(CancelledOrders))
        Parms.Add("@debug", 0)

        Me.LoadFromSql("[usp_wv_calendar_GetMediaData]", Parms, CommandType.StoredProcedure)

    End Sub
    Public Sub GetMediaCalendarByDate(ByVal CalendarDate As Date, _
                                        ByVal Client As String, _
                                        Optional ByVal Magazine As Boolean = True, _
                                        Optional ByVal NewsPaper As Boolean = True, _
                                        Optional ByVal Internet As Boolean = True, _
                                        Optional ByVal OutOfHome As Boolean = True, _
                                        Optional ByVal Television As Boolean = True, _
                                        Optional ByVal Radio As Boolean = True, _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal MediaType As String = "", _
                                        Optional ByVal Campaign As String = "", _
                                        Optional ByVal ClientPO As String = "", _
                                        Optional ByVal Vendor As String = "", _
                                        Optional ByVal Buyer As String = "", _
                                        Optional ByVal AcceptedOrdersOnly As Boolean = True, _
                                        Optional ByVal CancelledOrders As Boolean = False, _
                                        Optional ByVal CloseDate As Boolean = False, _
                                        Optional ByVal MatDueDate As Boolean = False, _
                                        Optional ByVal ExtMatDueDate As Boolean = False, _
                                        Optional ByVal ExtCloseDate As Boolean = False, _
                                        Optional ByVal RunInsertionDate As Boolean = True)


        Dim Parms As ListDictionary = New ListDictionary


        Parms.Add("@MagazineInc", BoolToYN(Magazine))
        Parms.Add("@NewspaperInc", BoolToYN(NewsPaper))
        Parms.Add("@InternetInc", BoolToYN(Internet))
        Parms.Add("@OutOfHomeInc", BoolToYN(OutOfHome))
        Parms.Add("@TelevisionInc", BoolToYN(Television))
        Parms.Add("@RadioInc", BoolToYN(Radio))
        Parms.Add("@AcceptedOrdersOnly", BoolToYN(AcceptedOrdersOnly))
        Parms.Add("@ClientCode", Client)
        Parms.Add("@DivCode", Division)
        Parms.Add("@ProdCode", Product)
        Parms.Add("@MediaType", MediaType)
        Parms.Add("@Campaign", Campaign)
        Parms.Add("@ClientPO", ClientPO)
        Parms.Add("@VendorID", Vendor)
        Parms.Add("@BuyerID", Buyer)
        Parms.Add("@StartDate", Format(CalendarDate, "MM/dd/yyyy"))
        Parms.Add("@EndDate", Format(CalendarDate, "MM/dd/yyyy"))
        Parms.Add("@MatDueDate", BoolToYN(MatDueDate))
        Parms.Add("@ExtMatDueDate", BoolToYN(ExtMatDueDate))
        Parms.Add("@CloseDate", BoolToYN(CloseDate))
        Parms.Add("@ExtCloseDate", BoolToYN(ExtCloseDate))
        Parms.Add("@RunInsertionDate", BoolToYN(RunInsertionDate))
        Parms.Add("@MediaMonth", Format(CalendarDate, "MMM").ToUpper)
        Parms.Add("@MediaYear", CalendarDate.Year)
        Parms.Add("@LineCancelled", BoolToYN(CancelledOrders))
        Parms.Add("@debug", 0)

        Me.LoadFromSql("[usp_wv_calendar_GetMediaData]", Parms, CommandType.StoredProcedure)

    End Sub
    Private Function BoolToYN(ByVal input As Boolean) As String
        If input = True Then
            Return "Y"
        Else
            Return "N"

        End If
    End Function
End Class
