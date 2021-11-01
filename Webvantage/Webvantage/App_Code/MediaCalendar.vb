Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Specialized



Public Class ClientMediaCalendar
    Inherits _WV_MEDIA_CALENDAR

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

    Public Sub GetMediaCalendarMyMonth(ByVal Month As Integer, _
                                        ByVal Year As Integer, _
                                        ByVal UserID As String, _
                                        ByVal Client As String, _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal MediaType As String = "", _
                                        Optional ByVal Campaign As String = "", _
                                        Optional ByVal ClientPO As String = "", _
                                        Optional ByVal Vendor As String = "", _
                                        Optional ByVal Buyer As String = "", _
                                        Optional ByVal Magazine As Boolean = True, _
                                        Optional ByVal NewsPaper As Boolean = True, _
                                        Optional ByVal Internet As Boolean = True, _
                                        Optional ByVal OutOfHome As Boolean = True, _
                                        Optional ByVal Television As Boolean = True, _
                                        Optional ByVal Radio As Boolean = True, _
                                        Optional ByVal AcceptedOrdersOnly As Boolean = True, _
                                        Optional ByVal CancelledOrders As Boolean = False, _
                                        Optional ByVal ClientCode As Boolean = True, _
                                        Optional ByVal DivisionCode As Boolean = True, _
                                        Optional ByVal ProductCode As Boolean = True, _
                                        Optional ByVal Type As Boolean = True, _
                                        Optional ByVal MType As Boolean = True, _
                                        Optional ByVal InsertionLine As Boolean = False, _
                                        Optional ByVal VendorCode As Boolean = False, _
                                        Optional ByVal VendorName As Boolean = False, _
                                        Optional ByVal JobComp As Boolean = False, _
                                        Optional ByVal CampaignCode As Boolean = False, _
                                        Optional ByVal CampaignName As Boolean = False, _
                                        Optional ByVal MarketCode As Boolean = False, _
                                        Optional ByVal MarketName As Boolean = False, _
                                        Optional ByVal AdSizeLength As Boolean = False, _
                                        Optional ByVal HeadlineProg As Boolean = False, _
                                        Optional ByVal ExtMatDate As Boolean = False, _
                                        Optional ByVal CloseDate As Boolean = False, _
                                        Optional ByVal ExtCloseDate As Boolean = False, _
                                        Optional ByVal RunDate As Boolean = False, _
                                        Optional ByVal BillingAmount As Boolean = False, _
                                        Optional ByVal Spots As Boolean = False, _
                                        Optional ByVal MatDueDate As Boolean = False, _
                                        Optional ByVal ExtMatDueDate As Boolean = False, _
                                        Optional ByVal CloseDate2 As Boolean = False, _
                                        Optional ByVal ExtCloseDate2 As Boolean = False, _
                                        Optional ByVal RunInsertionDate As Boolean = False, _
                                        Optional ByVal DisplayFlight As Boolean = False, _
                                        Optional ByVal Print As Boolean = False, _
                                        Optional ByVal Office As String = "")


        Dim Parms As ListDictionary = New ListDictionary
        Dim StartDateString As String = Month.ToString() & "/1/" & Year.ToString
        Dim DaysInMonth As Integer = Date.DaysInMonth(Year, Month)
        Dim startDate As Date = New Date(Year, Month, 1)

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
        Parms.Add("@StartDate", StartDateString)
        Parms.Add("@EndDate", CStr(Month) & "/" & DaysInMonth.ToString() & "/" & Year.ToString())
        Parms.Add("@MatDueDate", BoolToYN(MatDueDate))
        Parms.Add("@ExtMatDueDate", BoolToYN(ExtMatDueDate))
        Parms.Add("@CloseDate", BoolToYN(CloseDate2))
        Parms.Add("@ExtCloseDate", BoolToYN(ExtCloseDate2))
        Parms.Add("@RunInsertionDate", BoolToYN(RunInsertionDate))
        Parms.Add("@MediaMonth", Format(startDate, "MMM").ToUpper)
        Parms.Add("@MediaYear", Year)
        Parms.Add("@LineCancelled", BoolToYN(CancelledOrders))
        Parms.Add("@debug", 0)
        Parms.Add("@UserID", UserID)
        Parms.Add("@OfficeCode", Office)

        Me.LoadFromSql("[usp_wv_calendar_GetMediaData]", Parms, CommandType.StoredProcedure)

    End Sub
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
