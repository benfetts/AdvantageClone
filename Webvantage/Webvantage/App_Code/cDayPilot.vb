Imports DayPilot.Web.Ui.Events
Imports DayPilot.Web.Ui.Events.Bubble
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Web

Imports Webvantage.cGlobals
Imports Webvantage.MiscFN

<Serializable()> Public Class cDayPilot
    Private mConnString As String
    Private mUserID As String
    Private mEmpCode As String
    Private oSQL As SqlHelper

#Region " Main Calendar (aka Task Calendar) "

    Public Function GetCalendarData(ByVal Month As Integer,
                                    ByVal Year As Integer,
                                    ByVal UserID As String,
                                    ByVal ShowClient As Boolean,
                                    ByVal GrpLevel As String,
                                    Optional ByVal EmpCode As String = "",
                                    Optional ByVal OfficeCode As String = "",
                                    Optional ByVal Client As String = "",
                                    Optional ByVal Division As String = "",
                                    Optional ByVal Product As String = "",
                                    Optional ByVal Job As String = "",
                                    Optional ByVal JobComp As String = "",
                                    Optional ByVal Roles As String = "",
                                    Optional ByVal CellLength As Integer = 50,
                                    Optional ByVal TaskStatus As String = "",
                                    Optional ByVal ExcludeTempComplete As Boolean = False,
                                    Optional ByVal TaskDuration As Boolean = False,
                                    Optional ByVal tClientCode As Boolean = False,
                                    Optional ByVal tClientDesc As Boolean = False,
                                    Optional ByVal tDivisionCode As Boolean = False,
                                    Optional ByVal tDivisionDesc As Boolean = False,
                                    Optional ByVal tProductCode As Boolean = False,
                                    Optional ByVal tProductDesc As Boolean = False,
                                    Optional ByVal tJobNumber As Boolean = False,
                                    Optional ByVal tJobDesc As Boolean = False,
                                    Optional ByVal tCompNumber As Boolean = False,
                                    Optional ByVal tCompDesc As Boolean = False,
                                    Optional ByVal tTaskCode As Boolean = False,
                                    Optional ByVal tTaskDesc As Boolean = False,
                                    Optional ByVal haEmployeeCode As Boolean = False,
                                    Optional ByVal haEmployeeName As Boolean = False,
                                    Optional ByVal haType As Boolean = False,
                                    Optional ByVal haSubject As Boolean = False,
                                    Optional ByVal haTimes As Boolean = False,
                                    Optional ByVal haHours As Boolean = False,
                                    Optional ByVal haTimeCat As Boolean = False,
                                    Optional ByVal showTasks As Boolean = False,
                                    Optional ByVal showAssignments As Boolean = False,
                                    Optional ByVal showHolidays As Boolean = False,
                                    Optional ByVal showAppointments As Boolean = False,
                                    Optional ByVal milestonesOnly As Boolean = False,
                                    Optional ByVal EmpCodeDispl As Boolean = False,
                                    Optional ByVal EmpDescDispl As Boolean = False,
                                    Optional ByVal Manager As String = "",
                                    Optional ByVal ForceStartDate As Date = Nothing,
                                    Optional ByVal ForceEndDate As Date = Nothing,
                                    Optional ByVal ShowEvents As Boolean = False,
                                    Optional ByVal ShowEventTasks As Boolean = False,
                                    Optional ByVal Depts As String = "",
                                    Optional ByVal TrafficStatus As String = "",
                                    Optional ByVal CP As Boolean = False,
                                    Optional ByVal CPID As Integer = 0,
                                    Optional ByVal FuncRoles As String = "",
                                    Optional ByVal IncludeUnassigned As Boolean = False) As DataTable

        If Month < 0 Or Month > 12 Then
            Month = 1
        End If
        If Year < 1950 Then
            Year = Now.Year
        End If

        Dim StartOfSelectedMonth As New DateTime(Year, Month, 1)
        Dim EndOfSelectedMonth As New DateTime(Year, Month, Date.DaysInMonth(Year, Month))

        Dim arP(28) As SqlParameter

        Dim p0 As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        p0.Value = UserID
        arP(0) = p0

        Dim p1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        p1.Value = EmpCode
        arP(1) = p1

        Dim p2 As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        p2.Value = OfficeCode
        arP(2) = p2

        Dim p3 As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        p3.Value = Client
        arP(3) = p3

        Dim p4 As New SqlParameter("@DivCode", SqlDbType.VarChar, 6)
        p4.Value = Division
        arP(4) = p4

        Dim p5 As New SqlParameter("@ProdCode", SqlDbType.VarChar, 6)
        p5.Value = Product
        arP(5) = p5

        Dim p6 As New SqlParameter("@JobNumber", SqlDbType.VarChar, 6)
        p6.Value = Job
        arP(6) = p6

        Dim p7 As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        p7.Value = JobComp
        arP(7) = p7

        Dim p8 As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
        p8.Value = Roles
        arP(8) = p8

        Dim p9 As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        If ForceStartDate = Nothing Then
            p9.Value = StartOfSelectedMonth
        Else
            p9.Value = CDate(ForceStartDate)
        End If
        arP(9) = p9

        Dim p10 As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If ForceEndDate = Nothing Then
            p10.Value = EndOfSelectedMonth
        Else
            p10.Value = CDate(ForceEndDate)
        End If
        arP(10) = p10

        Dim p11 As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
        p11.Value = TaskStatus
        arP(11) = p11

        Dim p12 As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
        p12.Value = BoolToYN(ExcludeTempComplete)
        arP(12) = p12

        Dim p13 As New SqlParameter("@MilestonesOnly", SqlDbType.Char, 1)
        p13.Value = BoolToYN(milestonesOnly)
        arP(13) = p13

        Dim p14 As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        p14.Value = Manager
        arP(14) = p14

        Dim p15 As New SqlParameter("@GrpLevel", SqlDbType.VarChar, 1)
        p15.Value = GrpLevel
        arP(15) = p15

        Dim NonTaskType As String = ""
        If showHolidays = True And showAppointments = True Then
            NonTaskType = ""
        ElseIf showHolidays = True And showAppointments = False Then
            NonTaskType = "H"
        ElseIf showHolidays = False And showAppointments = True Then
            NonTaskType = "A"
        Else
            NonTaskType = "N"
        End If

        Dim p16 As New SqlParameter("@Type", SqlDbType.VarChar, 2)
        p16.Value = NonTaskType
        arP(16) = p16

        Dim p17 As New SqlParameter("@ShowTasks", SqlDbType.SmallInt)
        If showTasks = True Then
            p17.Value = 1
        Else
            p17.Value = 0
        End If
        arP(17) = p17

        Dim p18 As New SqlParameter("@ShowDuration", SqlDbType.SmallInt)
        If TaskDuration = True Then
            p18.Value = 1
        Else
            p18.Value = 0
        End If
        arP(18) = p18

        Dim p19 As New SqlParameter("@Show_Events", SqlDbType.SmallInt)
        If ShowEvents = True Then
            p19.Value = 1
        Else
            p19.Value = 0
        End If
        arP(19) = p19

        Dim p20 As New SqlParameter("@Show_Event_Tasks", SqlDbType.SmallInt)
        If ShowEventTasks = True Then
            p20.Value = 1
        Else
            p20.Value = 0
        End If
        arP(20) = p20

        Dim p21 As New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
        p21.Value = Depts
        arP(21) = p21

        Dim p22 As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
        p22.Value = TrafficStatus
        arP(22) = p22

        Dim p23 As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            p23.Value = 1
        Else
            p23.Value = 0
        End If
        arP(23) = p23

        Dim p24 As New SqlParameter("@CPID", SqlDbType.Int)
        p24.Value = CPID
        arP(24) = p24

        Dim p25 As New SqlParameter("@FuncRoles", SqlDbType.VarChar)
        p25.Value = FuncRoles
        arP(25) = p25

        Dim p26 As New SqlParameter("@ShowAssignments", SqlDbType.SmallInt)
        If showTasks = True Then
            p26.Value = 1
        Else
            p26.Value = 0
        End If
        arP(26) = p26

        Dim p27 As New SqlParameter("@IncludeUnassigned", SqlDbType.Bit)
        If IncludeUnassigned = True Then
            p27.Value = 1
        Else
            p27.Value = 0
        End If
        arP(27) = p27


        'quick fix for bug when appt and holidays are both unchecked...
        If showHolidays = False And showAppointments = False Then
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_DayPilot_GetMonth", "dtData", arP)
            'If dt.Rows.Count > 0 Then
            Dim dv As DataView = dt.DefaultView
            dv.RowFilter = "IS_NON_TASK <> 1"
            Return dv.ToTable()
            'End If
        Else
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_DayPilot_GetMonth", "dtData", arP)
        End If

    End Function

    Public Function GetWeek(ByVal DtMonth As DataTable, ByVal StartDate As Date) As DataTable
        Dim dStartOfWeek As Date = DayPilot.Utils.Week.FirstDayOfWeek(StartDate)
        Dim dEndOfWeek As Date = dStartOfWeek.AddDays(6)

        Dim sStartOfWeek As String = dStartOfWeek.ToShortDateString()
        Dim sEndOfWeek As String = dEndOfWeek.ToShortDateString()

        Dim dt As New DataTable

        If Not DtMonth Is Nothing Then
            If DtMonth.Rows.Count > 0 Then
                Dim dv As DataView = New DataView(DtMonth)
                dv.RowFilter = "START_DATE >= '" & sStartOfWeek & "' AND END_DATE <= '" & sEndOfWeek & "'"
                dt = dv.ToTable()
            End If
        End If
        Return dt
    End Function

    Public Sub LoadTabs(ByRef CalTabStrip As Telerik.Web.UI.RadTabStrip, Optional ByVal FromApp As String = "", Optional ByVal job As Integer = 0, Optional ByVal comp As Integer = 0)
        Dim CalTabIndex As Integer = 0
        Try
            CalTabIndex = CType(HttpContext.Current.Request.QueryString("Tab"), Integer)
        Catch ex As Exception
            CalTabIndex = 0
        End Try
        With CalTabStrip
            .Tabs.Clear()
            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Calendar"
            newTab.Value = 0
            newTab.NavigateUrl = "Calendar_MonthView.aspx?tab=0&FromApp=" & FromApp & "&JobNum=" & job & "&JobCompNum=" & comp
            .Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Week View"
            'newTab.Value = 1
            'newTab.NavigateUrl = "Calendar_WeekView.aspx?tab=1"
            '.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Day View"
            'newTab.Value = 2
            'newTab.NavigateUrl = "Calendar_DayView.aspx?tab=2"
            '.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "List View"
            newTab.Value = 3
            newTab.NavigateUrl = "Calendar_ListView.aspx?tab=3&FromApp=" & FromApp & "&JobNum=" & job & "&JobCompNum=" & comp
            .Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Workload"
            newTab.Value = 4
            newTab.NavigateUrl = "Calendar_Workload.aspx?tab=4&FromApp=" & FromApp & "&JobNum=" & job & "&JobCompNum=" & comp
            .Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Availability"
            newTab.Value = 5
            newTab.NavigateUrl = "Calendar_AssignmentsAvailability.aspx?tab=5&FromApp=" & FromApp & "&JobNum=" & job & "&JobCompNum=" & comp
            .Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Filter"
            newTab.Value = 6
            newTab.NavigateUrl = "Calendar_Filter.aspx?tab=6&FromApp=" & FromApp & "&JobNum=" & job & "&JobCompNum=" & comp
            .Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Report"
            newTab.Value = 7
            newTab.NavigateUrl = "Calendar_Report.aspx?tab=7&FromApp=" & FromApp & "&JobNum=" & job & "&JobCompNum=" & comp
            .Tabs.Add(newTab)
        End With
        Dim selectTab As Telerik.Web.UI.RadTab = CalTabStrip.FindTabByValue(CalTabIndex)
        selectTab.Selected = True
    End Sub


#End Region

#Region " Media Calendar "

    Public Sub LoadMediaTabs(ByRef CalTabStrip As Telerik.Web.UI.RadTabStrip)
        Try

            Dim tab As Integer = 0

            Try
                If IsNumeric(HttpContext.Current.Request.QueryString("Tab")) = True Then
                    tab = CInt(HttpContext.Current.Request.QueryString("Tab"))
                Else
                    tab = 0
                End If
            Catch ex As Exception
            End Try

            CalTabStrip.Tabs.Clear()
            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Calendar"
            newTab.Value = 0
            newTab.NavigateUrl = "MediaCalendar.aspx?tab=0"
            CalTabStrip.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Week View"
            'newTab.Value = 1
            'newTab.NavigateUrl = "MediaCalendar_Week.aspx?tab=1"
            'CalTabStrip.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Day View"
            'newTab.Value = 2
            'newTab.NavigateUrl = "MediaCalendar_Day.aspx?tab=2"
            'CalTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Filter"
            newTab.Value = 3
            newTab.NavigateUrl = "MediaCalendar_Filter.aspx?tab=3"
            CalTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab

            Dim selectTab As Telerik.Web.UI.RadTab = CalTabStrip.FindTabByValue(tab)
            selectTab.Selected = True

        Catch ex As Exception
        End Try
    End Sub

    'DATA_KEY POSITIONS:
    '===================
    '   ID
    '   ORDER_NBR
    '   LINE_NBR
    '   TYPE
    '   REV_NBR
    '   MEDIA_YEAR
    Public Function GetMediaCalendarDisplay(ByVal MediaCalType As String,
                                        ByVal Month As Integer,
                                        ByVal Year As Integer,
                                        ByVal UserID As String,
                                        ByVal Client As String,
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal MediaType As String = "",
                                        Optional ByVal Campaign As String = "",
                                        Optional ByVal ClientPO As String = "",
                                        Optional ByVal Vendor As String = "",
                                        Optional ByVal Buyer As String = "",
                                        Optional ByVal Magazine As Boolean = True,
                                        Optional ByVal NewsPaper As Boolean = True,
                                        Optional ByVal Internet As Boolean = True,
                                        Optional ByVal OutOfHome As Boolean = True,
                                        Optional ByVal Television As Boolean = True,
                                        Optional ByVal Radio As Boolean = True,
                                        Optional ByVal AcceptedOrdersOnly As Boolean = True,
                                        Optional ByVal CancelledOrders As Boolean = False,
                                        Optional ByVal ClientCode As Boolean = True,
                                        Optional ByVal DivisionCode As Boolean = True,
                                        Optional ByVal ProductCode As Boolean = True,
                                        Optional ByVal Type As Boolean = True,
                                        Optional ByVal MType As Boolean = True,
                                        Optional ByVal InsertionLine As Boolean = False,
                                        Optional ByVal VendorCode As Boolean = False,
                                        Optional ByVal VendorName As Boolean = False,
                                        Optional ByVal JobComp As Boolean = False,
                                        Optional ByVal CampaignCode As Boolean = False,
                                        Optional ByVal CampaignName As Boolean = False,
                                        Optional ByVal MarketCode As Boolean = False,
                                        Optional ByVal MarketName As Boolean = False,
                                        Optional ByVal AdSizeLength As Boolean = False,
                                        Optional ByVal HeadlineProg As Boolean = False,
                                        Optional ByVal ExtMatDate As Boolean = False,
                                        Optional ByVal CloseDate As Boolean = False,
                                        Optional ByVal ExtCloseDate As Boolean = False,
                                        Optional ByVal RunDate As Boolean = False,
                                        Optional ByVal BillingAmount As Boolean = False,
                                        Optional ByVal Spots As Boolean = False,
                                        Optional ByVal MatDueDate As Boolean = False,
                                        Optional ByVal ExtMatDueDate As Boolean = False,
                                        Optional ByVal CloseDate2 As Boolean = False,
                                        Optional ByVal ExtCloseDate2 As Boolean = False,
                                        Optional ByVal RunInsertionDate As Boolean = False,
                                        Optional ByVal DisplayFlight As Boolean = False,
                                        Optional ByVal Print As Boolean = False,
                                        Optional ByVal Office As String = "",
                                        Optional ByVal ForceStartDate As DateTime = Nothing,
                                        Optional ByVal ForceEndDate As DateTime = Nothing,
                                        Optional ByVal CP As Integer = 0,
                                        Optional ByVal CPID As Integer = 0) As DataTable

        Dim MainDT As New DataTable
        'get base data
        MainDT = Me.GetMediaCalendarData(Month, Year, UserID, Client, Division, Product, MediaType, Campaign, ClientPO, Vendor,
                                            Buyer, Magazine, NewsPaper, Internet, OutOfHome, Television, Radio, AcceptedOrdersOnly, CancelledOrders, ClientCode, DivisionCode, ProductCode, Type, MType, InsertionLine,
                                            VendorCode, VendorName, JobComp, CampaignCode, CampaignName, MarketCode, MarketName, AdSizeLength, HeadlineProg, ExtMatDate,
                                            CloseDate, ExtCloseDate, RunDate, BillingAmount, Spots, MatDueDate, ExtMatDueDate, CloseDate2, ExtCloseDate2, RunInsertionDate, DisplayFlight, Print, Office, ForceStartDate, ForceEndDate, CP, CPID)
        'modify to work with the daypilot control
        If MainDT.Rows.Count > 0 Then
            'Create custom columns
            Dim COL_ID As DataColumn = New DataColumn("ID")
            COL_ID.DataType = GetType(Int32)

            Dim COL_DISPLAY_START_DATE As DataColumn = New DataColumn("DISPLAY_START_DATE")
            COL_DISPLAY_START_DATE.DataType = GetType(DateTime)

            Dim COL_DISPLAY_END_DATE As DataColumn = New DataColumn("DISPLAY_END_DATE")
            COL_DISPLAY_END_DATE.DataType = GetType(DateTime)

            Dim COL_DATA_KEY As DataColumn = New DataColumn("DATA_KEY")
            COL_DATA_KEY.DataType = GetType(String)


            'Add custom columns
            With MainDT.Columns
                .Add(COL_ID)
                .Add(COL_DISPLAY_START_DATE)
                .Add(COL_DISPLAY_END_DATE)
                .Add(COL_DATA_KEY)
            End With

            Dim r As DataRow
            For i As Integer = 0 To MainDT.Rows.Count - 1
                r = MainDT.Rows(i)
                'set id column
                r("ID") = i + 1

                'set datakey:
                Dim SbKey As New System.Text.StringBuilder
                With SbKey
                    If IsDBNull(r("TYPE")) = False Then
                        .Append(r("TYPE"))
                    End If
                    .Append("|")
                    If IsDBNull(r("ORDER_NBR")) = False Then
                        .Append(r("ORDER_NBR"))
                    End If
                    .Append("|")
                    If IsDBNull(r("LINE_NBR")) = False Then
                        .Append(r("LINE_NBR"))
                    End If
                    .Append("|")
                    If IsDBNull(r("REV_NBR")) = False Then
                        .Append(r("REV_NBR"))
                    End If
                    .Append("|")
                    If IsDBNull(r("MEDIA_YEAR")) = False Then
                        .Append(r("MEDIA_YEAR"))
                    End If
                    .Append("|")
                    If IsDBNull(r("DOCUMENT_COUNT")) = False Then
                        .Append(r("DOCUMENT_COUNT"))
                    End If
                End With
                r("DATA_KEY") = CType(i + 1, String) & "|" & SbKey.ToString()

                'scrub existing data
                Dim UseDateField As String = ""

                Select Case MediaCalType
                    Case "Traffic"
                        If MatDueDate = True Then
                            UseDateField = "MATL_CLOSE_DATE"
                        End If
                        If ExtMatDueDate = True Then
                            UseDateField = "EXT_MATL_DATE"
                        End If
                        If CloseDate2 = True Then
                            UseDateField = "CLOSE_DATE"
                        End If
                        If ExtCloseDate2 = True Then
                            UseDateField = "EXT_CLOSE_DATE"
                        End If
                        If RunInsertionDate = True Then
                            UseDateField = "START_DATE"
                        End If


                    Case "Schedule"
                        If MatDueDate = True Then
                            UseDateField = "MATL_CLOSE_DATE"
                        End If
                        If ExtMatDueDate = True Then
                            UseDateField = "EXT_MATL_DATE"
                        End If
                        If CloseDate2 = True Then
                            UseDateField = "CLOSE_DATE"
                        End If
                        If ExtCloseDate2 = True Then
                            UseDateField = "EXT_CLOSE_DATE"
                        End If
                        If RunInsertionDate = True Then
                            UseDateField = "START_DATE"
                        End If

                    Case Else
                        UseDateField = "MATL_CLOSE_DATE"
                End Select

                If UseDateField = "" Then
                    UseDateField = "MATL_CLOSE_DATE"
                End If

                Try
                    If RunInsertionDate = False Then

                        If cGlobals.wvIsDate(r(UseDateField)) = True Then
                            r("DISPLAY_START_DATE") = CType(r(UseDateField), DateTime)
                        End If

                        If cGlobals.wvIsDate(r(UseDateField)) = True Then
                            r("DISPLAY_END_DATE") = CType(r(UseDateField), DateTime).AddHours(24)
                        End If


                    Else
                        If DisplayFlight = True Then
                            If cGlobals.wvIsDate(r("START_DATE")) = True Then
                                r("DISPLAY_START_DATE") = CType(r("START_DATE"), DateTime)
                            End If
                            If cGlobals.wvIsDate(r("START_DATE")) = True Then
                                r("DISPLAY_END_DATE") = CType(r("START_DATE"), DateTime).AddHours(24)
                            End If

                        Else 'span
                            If cGlobals.wvIsDate(r("START_DATE")) = True Then
                                If CDate(r("START_DATE")) <= CDate(r("END_DATE")) Then
                                    r("DISPLAY_START_DATE") = CType(r("START_DATE"), DateTime)
                                End If
                            End If

                            If cGlobals.wvIsDate(r("END_DATE")) = True And cGlobals.wvIsDate(r("END_DATE")) >= cGlobals.wvIsDate(r("START_DATE")) Then
                                If CDate(r("END_DATE")) >= CDate(r("START_DATE")) Then
                                    r("DISPLAY_END_DATE") = CType(r("END_DATE"), DateTime).AddHours(24)
                                End If
                                'r("DISPLAY_END_DATE") = CType(r("END_DATE"), DateTime).AddDays(1)
                                'r("DISPLAY_END_DATE") = CType(r("END_DATE"), DateTime).AddHours(5)
                            End If

                        End If


                    End If

                Catch ex As Exception
                End Try
            Next
        End If

        'return
        Return MainDT

    End Function

    Private Function GetMediaCalendarData(ByVal _Month As Integer,
                                        ByVal _Year As Integer,
                                        ByVal _UserID As String,
                                        ByVal _Client As String,
                                        Optional ByVal _Division As String = "",
                                        Optional ByVal _Product As String = "",
                                        Optional ByVal _MediaType As String = "",
                                        Optional ByVal _Campaign As String = "",
                                        Optional ByVal _ClientPO As String = "",
                                        Optional ByVal _Vendor As String = "",
                                        Optional ByVal _Buyer As String = "",
                                        Optional ByVal _Magazine As Boolean = True,
                                        Optional ByVal _NewsPaper As Boolean = True,
                                        Optional ByVal _Internet As Boolean = True,
                                        Optional ByVal _OutOfHome As Boolean = True,
                                        Optional ByVal _Television As Boolean = True,
                                        Optional ByVal _Radio As Boolean = True,
                                        Optional ByVal _AcceptedOrdersOnly As Boolean = True,
                                        Optional ByVal _CancelledOrders As Boolean = False,
                                        Optional ByVal _ClientCode As Boolean = True,
                                        Optional ByVal _DivisionCode As Boolean = True,
                                        Optional ByVal _ProductCode As Boolean = True,
                                        Optional ByVal _Type As Boolean = True,
                                        Optional ByVal _MType As Boolean = True,
                                        Optional ByVal _InsertionLine As Boolean = False,
                                        Optional ByVal _VendorCode As Boolean = False,
                                        Optional ByVal _VendorName As Boolean = False,
                                        Optional ByVal _JobComp As Boolean = False,
                                        Optional ByVal _CampaignCode As Boolean = False,
                                        Optional ByVal _CampaignName As Boolean = False,
                                        Optional ByVal _MarketCode As Boolean = False,
                                        Optional ByVal _MarketName As Boolean = False,
                                        Optional ByVal _AdSizeLength As Boolean = False,
                                        Optional ByVal _HeadlineProg As Boolean = False,
                                        Optional ByVal _ExtMatDate As Boolean = False,
                                        Optional ByVal _CloseDate As Boolean = False,
                                        Optional ByVal _ExtCloseDate As Boolean = False,
                                        Optional ByVal _RunDate As Boolean = False,
                                        Optional ByVal _BillingAmount As Boolean = False,
                                        Optional ByVal _Spots As Boolean = False,
                                        Optional ByVal _MatDueDate As Boolean = False,
                                        Optional ByVal _ExtMatDueDate As Boolean = False,
                                        Optional ByVal _CloseDate2 As Boolean = False,
                                        Optional ByVal _ExtCloseDate2 As Boolean = False,
                                        Optional ByVal _RunInsertionDate As Boolean = False,
                                        Optional ByVal _DisplayFlight As Boolean = False,
                                        Optional ByVal _Print As Boolean = False,
                                        Optional ByVal _Office As String = "",
                                        Optional ByVal _ForceStartDate As DateTime = Nothing,
                                        Optional ByVal _ForceEndDate As DateTime = Nothing,
                                        Optional ByVal _CP As Integer = 0,
                                        Optional ByVal _CPID As Integer = 0) As DataTable

        Dim _StartDateString As String = _Month.ToString() & "/1/" & _Year.ToString
        Dim _DaysInMonth As Integer = Date.DaysInMonth(_Year, _Month)
        Dim _startDate As Date = New Date(_Year, _Month, 1)

        Dim arP(28) As SqlParameter

        Dim p0 As New SqlParameter("@MagazineInc", SqlDbType.Char, 1)
        p0.Value = BoolToYN(_Magazine)
        arP(0) = p0

        Dim p1 As New SqlParameter("@NewspaperInc", SqlDbType.Char, 1)
        p1.Value = BoolToYN(_NewsPaper)
        arP(1) = p1

        Dim p2 As New SqlParameter("@InternetInc", SqlDbType.Char, 1)
        p2.Value = BoolToYN(_Internet)
        arP(2) = p2

        Dim p3 As New SqlParameter("@OutOfHomeInc", SqlDbType.Char, 1)
        p3.Value = BoolToYN(_OutOfHome)
        arP(3) = p3

        Dim p4 As New SqlParameter("@TelevisionInc", SqlDbType.Char, 1)
        p4.Value = BoolToYN(_Television)
        arP(4) = p4

        Dim p5 As New SqlParameter("@RadioInc", SqlDbType.Char, 1)
        p5.Value = BoolToYN(_Radio)
        arP(5) = p5

        Dim p6 As New SqlParameter("@AcceptedOrdersOnly", SqlDbType.Char, 1)
        p6.Value = BoolToYN(_AcceptedOrdersOnly)
        arP(6) = p6

        Dim p7 As New SqlParameter("@ClientCode", SqlDbType.VarChar, 10)
        p7.Value = _Client
        arP(7) = p7

        Dim p8 As New SqlParameter("@DivCode", SqlDbType.VarChar, 10)
        p8.Value = _Division
        arP(8) = p8

        Dim p9 As New SqlParameter("@ProdCode", SqlDbType.VarChar, 10)
        p9.Value = _Product
        arP(9) = p9

        Dim p10 As New SqlParameter("@MediaType", SqlDbType.VarChar, 10)
        p10.Value = _MediaType
        arP(10) = p10

        Dim p11 As New SqlParameter("@Campaign", SqlDbType.VarChar, 100)
        p11.Value = _Campaign
        arP(11) = p11

        Dim p12 As New SqlParameter("@ClientPO", SqlDbType.VarChar, 100)
        p12.Value = _ClientPO
        arP(12) = p12

        Dim p13 As New SqlParameter("@VendorID", SqlDbType.VarChar, 100)
        p13.Value = _Vendor
        arP(13) = p13

        Dim p14 As New SqlParameter("@BuyerID", SqlDbType.VarChar, 100)
        p14.Value = _Buyer
        arP(14) = p14

        Dim p15 As New SqlParameter("@StartDate", SqlDbType.DateTime)
        If _ForceStartDate = Nothing Then
            p15.Value = CDate(_StartDateString).Date
        Else
            p15.Value = CDate(_ForceStartDate).Date
        End If
        arP(15) = p15

        Dim p16 As New SqlParameter("@EndDate", SqlDbType.DateTime)
        If _ForceEndDate = Nothing Then
            p16.Value = CDate(CStr(_Month) & "/" & _DaysInMonth.ToString() & "/" & _Year.ToString)
        Else
            p16.Value = CDate(_ForceEndDate)
        End If
        arP(16) = p16

        Dim p17 As New SqlParameter("@MatDueDate", SqlDbType.Char, 1)
        p17.Value = BoolToYN(_MatDueDate)
        arP(17) = p17

        Dim p18 As New SqlParameter("@ExtMatDueDate", SqlDbType.Char, 1)
        p18.Value = BoolToYN(_ExtMatDueDate)
        arP(18) = p18

        Dim p19 As New SqlParameter("@CloseDate", SqlDbType.Char, 1)
        p19.Value = BoolToYN(_CloseDate2)
        arP(19) = p19

        Dim p20 As New SqlParameter("@ExtCloseDate", SqlDbType.Char, 1)
        p20.Value = BoolToYN(_ExtCloseDate2)
        arP(20) = p20

        Dim p21 As New SqlParameter("@RunInsertionDate", SqlDbType.Char, 1)
        p21.Value = BoolToYN(_RunInsertionDate)
        arP(21) = p21

        Dim p22 As New SqlParameter("@MediaMonth", SqlDbType.VarChar, 6)
        p22.Value = Format(_startDate, "MMM").ToUpper
        arP(22) = p22

        Dim p23 As New SqlParameter("@MediaYear", SqlDbType.Int)
        p23.Value = _Year
        arP(23) = p23

        Dim p24 As New SqlParameter("@LineCancelled", SqlDbType.Char, 1)
        p24.Value = BoolToYN(_CancelledOrders)
        arP(24) = p24

        Dim p25 As New SqlParameter("@debug", SqlDbType.Bit)
        p25.Value = 0
        arP(25) = p25

        If _CP = 0 Then
            Dim p26 As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            p26.Value = _UserID
            arP(26) = p26

            Dim p27 As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 10)
            p27.Value = _Office
            arP(27) = p27
        Else
            Dim p26 As New SqlParameter("@CDPID", SqlDbType.Int)
            p26.Value = _CPID
            arP(26) = p26
        End If


        Try
            If _CP = 1 Then
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_cp_calendar_GetMediaData", "DtMediaCalendar", arP)
            Else
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_GetMediaData", "DtMediaCalendar", arP)
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

#End Region

#Region " Updating from the Calendar "

    Public Function Task_UpdateDates(ByVal Job_Number As Integer, ByVal Job_Component_Nbr As Integer, ByVal Seq_Nbr As Integer, ByVal New_Start As Date, ByVal New_End As Date, ByVal User_Code As String, ByVal jobdays As Integer) As String
        Try
            Dim arParams(8) As SqlParameter

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = Job_Number
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = Job_Component_Nbr
            arParams(1) = pJOB_COMPONENT_NBR

            Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            pSEQ_NBR.Value = Seq_Nbr
            arParams(2) = pSEQ_NBR

            Dim pNEW_START As New SqlParameter("@NEW_START", SqlDbType.SmallDateTime, 26)
            pNEW_START.Value = Convert.ToDateTime(New_Start)
            arParams(4) = pNEW_START

            Dim pNEW_END As New SqlParameter("@NEW_END", SqlDbType.SmallDateTime, 26)
            pNEW_END.Value = Convert.ToDateTime(New_End)
            arParams(5) = pNEW_END

            Dim pUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUSER_CODE.Value = User_Code
            arParams(6) = pUSER_CODE

            Dim pJOB_DAYS As New SqlParameter("@JOB_DAYS", SqlDbType.SmallInt)
            pJOB_DAYS.Value = jobdays
            arParams(7) = pJOB_DAYS

            Dim i As Integer = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_DayPilot_Task_UpdateDates", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function NonTask_UpdateDates(ByVal Non_Task_Id As Integer, ByVal New_Start As DateTime, ByVal New_End As DateTime, ByVal Update_Time As Boolean) As String

        Try
            Dim StrMSG As String = ""
            Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing
            Dim CanEditHoliday As Boolean = False

            Try
                Dim SecuritySession As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")), HttpContext.Current.Session("ConnString"))
                UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(SecuritySession, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays)

                For Each UserGroupSettingValue In UserGroupSettingValues

                    Try

                        If UserGroupSettingValue = True Then

                            CanEditHoliday = True
                            Exit For

                        End If

                    Catch ex As Exception

                    End Try

                Next

            Catch ex As Exception
                CanEditHoliday = False
            End Try

            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(mConnString)
            'Don't want to mess with existing function...will re-use function....
            'Re-get data to pass to fn

            Dim IsHoliday As Boolean
            Dim IsAppointment As Boolean
            Dim Subject As String
            Dim IsAllDay As Boolean
            'use new start
            'use new end
            'reset the date on these two dependent on the new start/end
            Dim StartTime As DateTime
            Dim EndTime As DateTime
            Dim FixedStartTime As DateTime
            Dim FixedEndTime As DateTime
            Dim EmpCode As String
            Dim Category As String
            Dim Indicator As String = ""
            Dim TaskId As Integer '?
            Dim StandardHours As Decimal
            Dim client As String = ""
            Dim division As String = ""
            Dim product As String = ""
            Dim job As Integer = 0
            Dim comp As Integer = 0
            Dim priority As Integer = 2
            Dim func As String = ""
            Dim remind As String = ""
            Dim desc As String = ""
            Dim cdpid As Integer = 0
            Dim deschtml As String = ""

            'Get the existing data (copied from Calendar_NewItem.aspx.vb sub "LoadTask()" line:174)
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetNonTaskData(Non_Task_Id, HttpContext.Current.Session("UserCode"))
            Dim type As String
            While dr.Read
                type = dr.GetString(1)
                If dr.GetString(1) = "H" Then
                    IsHoliday = True
                    IsAppointment = False
                    EmpCode = Nothing
                Else
                    IsAppointment = True
                    IsHoliday = False
                    EmpCode = dr.GetString(3)
                    client = dr.GetString(13)
                    division = dr.GetString(14)
                    product = dr.GetString(15)
                    If IsDBNull(dr("JOB_NUMBER")) = False Then
                        job = dr("JOB_NUMBER")
                    End If
                    If IsDBNull(dr("JOB_COMPONENT_NBR")) = False Then
                        comp = dr("JOB_COMPONENT_NBR")
                    End If
                    If IsDBNull(dr("PRIORITY")) = False Then
                        priority = dr("PRIORITY")
                    End If
                    If IsDBNull(dr("FNC_CODE")) = False Then
                        func = dr("FNC_CODE")
                    End If
                    If IsDBNull(dr("REMINDER")) = False Then
                        remind = dr("REMINDER")
                    End If
                    If IsDBNull(dr("NON_EMP_TASK_DESC")) = False Then
                        desc = dr("NON_EMP_TASK_DESC")
                    End If
                    If IsDBNull(dr("CDP_CONTACT_ID")) = False Then
                        cdpid = dr("CDP_CONTACT_ID")
                    End If
                    If IsDBNull(dr("NON_EMP_TASK_HTML")) = False Then
                        deschtml = dr("NON_EMP_TASK_HTML")
                    End If
                End If
                Subject = dr.GetString(2)
                If dr.GetInt32(4) = 1 Then
                    IsAllDay = True
                Else
                    IsAllDay = False
                    StartTime = dr.GetDateTime(7)
                    EndTime = dr.GetDateTime(8)
                End If
                Category = dr.GetString(9).Trim()
            End While
            Dim dr2 As SqlClient.SqlDataReader
            dr2 = oCalendar.GetStandardHours()
            Do While dr2.Read
                StandardHours = dr2.GetDecimal(0)
            Loop


            'exit if can't edit holiday:
            If CanEditHoliday = False And IsHoliday = True Then
                Return "You do not have permission to edit holidays."
                Exit Function
            End If

            '''exit if trying to mod someone else's appt
            ''If IsAppointment = True And EmpCode <> mEmpCode Then
            ''    Return "You cannot modify someone else\'s appointment."
            ''    Exit Function
            ''End If

            'This point, I guess all is ok:
            'Fix the date value of the time fields ?
            If Update_Time = True Then
                FixedStartTime = New_Start
                FixedEndTime = New_End
            Else 'retain the start and end of the original
                FixedStartTime = Convert.ToDateTime(New_Start.ToShortDateString() & " " & StartTime.ToShortTimeString())
                FixedEndTime = Convert.ToDateTime(New_End.ToShortDateString() & " " & EndTime.ToShortTimeString())
            End If

            If IsAllDay = False Then
                Dim TheHours As Decimal = CType(0.0, Decimal)
                Try
                    Dim ts As TimeSpan
                    ts = FixedEndTime.Subtract(FixedStartTime)
                    TheHours = CType(ts.TotalHours, Decimal)
                Catch ex As Exception
                    TheHours = CType(0.0, Decimal)
                End Try
                If TheHours <= 0 Then 'end time needs to go to next day:
                    TheHours = TheHours + 24
                    FixedEndTime = DateAdd(DateInterval.Day, 1, FixedEndTime)
                End If
            End If

            Dim save As Boolean
            Dim task As AdvantageFramework.Database.Entities.EmployeeNonTask
            Dim tasklist As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeNonTask) = Nothing
            Dim days As Integer
            Dim duration As Integer = 0
            Dim time As Decimal = 0
            Dim rsr As Telerik.Web.UI.RadSchedulerRecurrenceEditor
            Dim key As Integer
            Dim oCount As Integer = 0
            Dim ds As DataSet

            If IsHoliday = True Then
                save = oCalendar.UpdateActivity(type, Subject, IsAllDay, Convert.ToDateTime(wvCDate(New_Start)), Convert.ToDateTime(wvCDate(New_End)), FixedStartTime, FixedEndTime, EmpCode, Category, "", Non_Task_Id, StandardHours, "", "", "", 0, 0, 2, 0, "", "", "", "", 0, 0, "")
            Else
                Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))
                    task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, Non_Task_Id)
                    ds = oCalendar.GetNonTaskDataDS(Non_Task_Id, HttpContext.Current.Session("UserCode"))
                    If task.Recurrence <> "" Then
                        save = oCalendar.UpdateActivity(type, Subject, IsAllDay, Convert.ToDateTime(wvCDate(New_Start)), Convert.ToDateTime(wvCDate(New_End)), FixedStartTime, FixedEndTime, EmpCode, Category, "", Non_Task_Id, StandardHours, client, division, product, job, comp, priority, remind, task.Recurrence, "", desc, func, 0, cdpid, deschtml)
                        tasklist = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByRecurrenceParentID(DbContext, task.ID).ToList
                        For Each task In tasklist
                            AdvantageFramework.Database.Procedures.EmployeeNonTask.DeleteByNonTaskId(DbContext, task.ID)
                        Next
                        rsr.RecurrenceRuleText = task.Recurrence
                        rsr.StartDate = New_Start
                        rsr.EndDate = New_End
                        For Each occurence As DateTime In rsr.RecurrenceRule.Occurrences
                            If oCount >= 1 Then
                                If IsAllDay = True Then
                                    key = oCalendar.AddNewActivity(type, Subject, IsAllDay, occurence.Date, occurence.AddDays(duration).Date, FixedStartTime, FixedEndTime, EmpCode, Category, "", StandardHours, client, division, product, job, comp, priority, remind, "", "", desc, func, Non_Task_Id, cdpid, deschtml)
                                    If key <> -1 Then
                                        For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                            Dim emp() As String = ds.Tables(1).Rows(i)("EMP_EMAIL").Split("|")
                                            oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                                        Next
                                    End If
                                Else
                                    key = oCalendar.AddNewActivity(type, Subject, IsAllDay, occurence.Date, occurence.AddDays(duration).Date, occurence, occurence.AddMinutes(time), EmpCode, Category, "", StandardHours, client, division, product, job, comp, priority, remind, "", "", desc, func, Non_Task_Id, cdpid, deschtml)
                                    If key <> -1 Then
                                        For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                            Dim emp() As String = ds.Tables(1).Rows(i)("EMP_EMAIL").Split("|")
                                            oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                                        Next
                                    End If
                                End If
                            Else
                                oCount += 1
                            End If
                        Next
                    ElseIf task.RecurrenceParent > 0 Then
                        save = oCalendar.UpdateActivity(type, Subject, IsAllDay, Convert.ToDateTime(wvCDate(New_Start)), Convert.ToDateTime(wvCDate(New_End)), FixedStartTime, FixedEndTime, EmpCode, Category, "", Non_Task_Id, StandardHours, client, division, product, job, comp, priority, remind, "", "", desc, func, 0, cdpid, deschtml)
                    Else
                        save = oCalendar.UpdateActivity(type, Subject, IsAllDay, Convert.ToDateTime(wvCDate(New_Start)), Convert.ToDateTime(wvCDate(New_End)), FixedStartTime, FixedEndTime, EmpCode, Category, "", Non_Task_Id, StandardHours, client, division, product, job, comp, priority, remind, "", "", desc, func, 0, cdpid, deschtml)
                    End If
                End Using
            End If

            'save = oCalendar.UpdateTask(IsHoliday, IsAppointment, Subject, IsAllDay, Convert.ToDateTime(wvCDate(New_Start)), _
            '                Convert.ToDateTime(wvCDate(New_End)), FixedStartTime, FixedEndTime, EmpCode, Category, _
            '                 Indicator, Non_Task_Id, StandardHours)
            If save = True Then

                'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), Non_Task_Id, IsHoliday, False)

                Return ""
            Else
                Return "Error saving holiday/appointment."
            End If


        Catch ex As Exception
            Return "Error saving holiday/appointment.\r" & ex.Message.ToString()
        End Try
    End Function

    Public Function Event_UpdateDates(ByVal Event_Id As Integer, ByVal New_Start As DateTime, ByVal New_End As DateTime, ByVal IncludeTime As Boolean, ByVal User_Code As String) As String
        'set include time to true if we decide to allow drag/drop on day/week view
        Try
            Dim arParams(5) As SqlParameter

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            pEVENT_ID.Value = Event_Id
            arParams(0) = pEVENT_ID

            Dim pNEW_START As New SqlParameter("@NEW_START", SqlDbType.SmallDateTime, 26)
            pNEW_START.Value = Convert.ToDateTime(New_Start)
            arParams(1) = pNEW_START

            Dim pNEW_END As New SqlParameter("@NEW_END", SqlDbType.SmallDateTime, 26)
            pNEW_END.Value = Convert.ToDateTime(New_End)
            arParams(2) = pNEW_END

            Dim pINCLUDE_TIME As New SqlParameter("@INCLUDE_TIME", SqlDbType.SmallInt)
            If IncludeTime = True Then
                pINCLUDE_TIME.Value = 1
            Else
                pINCLUDE_TIME.Value = 0
            End If
            arParams(3) = pINCLUDE_TIME

            Dim pUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUSER_CODE.Value = User_Code
            arParams(4) = pUSER_CODE



            Dim i As Integer = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_DayPilot_Event_UpdateDates", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function EventTask_UpdateDates(ByVal Event_Task_Id As Integer, ByVal New_Start As DateTime, ByVal New_End As DateTime, ByVal IncludeTime As Boolean, Optional ByVal User_Code As String = "") As String
        'set include time to true if we decide to allow drag/drop on day/week view
        Try
            Dim arParams(5) As SqlParameter

            Dim pEVENT_TASK_ID As New SqlParameter("@EVENT_TASK_ID", SqlDbType.Int)
            pEVENT_TASK_ID.Value = Event_Task_Id
            arParams(0) = pEVENT_TASK_ID

            Dim pNEW_START As New SqlParameter("@NEW_START", SqlDbType.SmallDateTime, 26)
            pNEW_START.Value = Convert.ToDateTime(New_Start)
            arParams(1) = pNEW_START

            Dim pNEW_END As New SqlParameter("@NEW_END", SqlDbType.SmallDateTime, 26)
            pNEW_END.Value = Convert.ToDateTime(New_End)
            arParams(2) = pNEW_END

            Dim pINCLUDE_TIME As New SqlParameter("@INCLUDE_TIME", SqlDbType.SmallInt)
            If IncludeTime = True Then
                pINCLUDE_TIME.Value = 1
            Else
                pINCLUDE_TIME.Value = 0
            End If
            arParams(3) = pINCLUDE_TIME

            Dim pUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            If User_Code.Trim() = "" Then
                User_Code = mUserID
            End If
            pUSER_CODE.Value = User_Code
            arParams(4) = pUSER_CODE

            Dim i As Integer = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_DayPilot_EventTask_UpdateDates", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

#End Region

#Region " Daypilot rendering "

    Public Function RenderEvents(ByVal Dt1 As DataTable, ByVal isNonTask As Integer, ByVal isAllDay As Integer, ByVal IsTaskDayPage As Boolean) As String
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
            oAppVars.getAllAppVars()
            Dim SbDetails As New System.Text.StringBuilder
            With SbDetails
                If isNonTask = 1 Then 'Appointment or holiday
                    Dim NonTaskType As String = ""
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("NON_TASK_TYPE")) = False Then
                                NonTaskType = Dt1.Rows(0)("NON_TASK_TYPE").ToString().Trim()
                                If NonTaskType = "H" Then
                                    .Append("H")
                                ElseIf NonTaskType = "A" Then
                                    .Append("A")
                                End If
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        'If Session("tcal_hasubject") = True Then
                        If CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean) = True Then
                            If IsDBNull(Dt1.Rows(0)("TASK_NON_TASK_DISPLAY")) = False Then
                                .Append(Dt1.Rows(0)("TASK_NON_TASK_DISPLAY").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        'If Session("tcal_hatimes") = True And IsAllDay = 0 Then
                        If (CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean) = True Or IsTaskDayPage = True) And isAllDay = 0 Then
                            If IsDBNull(Dt1.Rows(0)("START_TIME")) = False And IsDBNull(Dt1.Rows(0)("END_TIME")) = False Then
                                If IsDBNull(Dt1.Rows(0)("NUM_DAYS")) = False Then
                                    Dim DayCount As Integer = CType(Dt1.Rows(0)("NUM_DAYS"), Integer)
                                    If DayCount > 1 Then
                                        .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
                                        .Append(" ")
                                        .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortTimeString())
                                        .Append(" - ")
                                        .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
                                        .Append(" ")
                                        .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortTimeString())
                                        .Append("|")
                                    Else 'one day event:
                                        If CType(Dt1.Rows(0)("START_TIME"), Date).ToShortTimeString() <> CType(Dt1.Rows(0)("END_TIME"), Date).ToShortTimeString() Then
                                            .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortTimeString())
                                            .Append(" - ")
                                            .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortTimeString())
                                            .Append("|")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("NON_TASK_CATEGORY")) = False Then
                                .Append(Dt1.Rows(0)("NON_TASK_CATEGORY").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.Rows(0)("NON_TASK_TYPE")) = False Then
                            If IsTaskDayPage = True And Dt1.Rows(0)("NON_TASK_TYPE").ToString().Trim() = "A" Then
                                If IsDBNull(Dt1.Rows(0)("EMP_CODE")) = False Then
                                    .Append(Dt1.Rows(0)("EMP_CODE").ToString())
                                    .Append("|")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    ''Try
                    ''    If Session("tcal_haemployeedesc") = True And NonTaskType = "A" Then
                    ''        .Append(dt1.Rows(0)("EMP_FML_NAME").ToString())
                    ''    End If
                    ''Catch ex As Exception
                    ''End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("NON_TASK_HOURS")) = False Then
                                If NonTaskType = "H" Then
                                    If CType(Dt1.Rows(0)("NON_TASK_HOURS"), Decimal) > 0 Then
                                        .Append(FormatNumber(Dt1.Rows(0)("NON_TASK_HOURS"), 2, True, False, True))
                                        .Append("|")
                                    End If
                                Else
                                    .Append(FormatNumber(Dt1.Rows(0)("NON_TASK_HOURS"), 2, True, False, True))
                                    .Append("|")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try


                ElseIf isNonTask = 0 Then 'real task

                    Try
                        'If Session("tcal_tclientcode") = True Then
                        If CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("CL_CODE")) = False Then
                                .Append(Dt1.Rows(0)("CL_CODE").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    ''Try
                    ''    If Session("tcal_tclientdesc") = True Then
                    ''        If IsDBNull(dt1.Rows(0)("CL_NAME")) = False Then
                    ''            .Append(dt1.Rows(0)("CL_NAME").ToString())
                    ''            .Append("|")
                    ''        End If
                    ''    End If
                    ''Catch ex As Exception
                    ''End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("DIV_CODE")) = False Then
                                .Append(Dt1.Rows(0)("DIV_CODE").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    ''Try
                    ''    If Session("tcal_tdivdesc") = True Then
                    ''        If IsDBNull(dt1.Rows(0)("DIV_NAME")) = False Then
                    ''            .Append(dt1.Rows(0)("DIV_NAME").ToString())
                    ''            .Append("|")
                    ''        End If
                    ''    End If
                    ''Catch ex As Exception
                    ''End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("PRD_CODE")) = False Then
                                .Append(Dt1.Rows(0)("PRD_CODE").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    ''Try
                    ''    If Session("tcal_tproddesc") = True Then
                    ''        If IsDBNull(dt1.Rows(0)("PRD_DESCRIPTION")) = False Then
                    ''            .Append(dt1.Rows(0)("PRD_DESCRIPTION").ToString())
                    ''            .Append("|")
                    ''        End If
                    ''    End If
                    ''Catch ex As Exception
                    ''End Try
                    Try
                        'If Session("tcal_tjobnum") = True Then
                        If CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("JOB_NUMBER")) = False Then
                                .Append(Dt1.Rows(0)("JOB_NUMBER").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("JOB_DESC")) = False Then
                                .Append(Dt1.Rows(0)("JOB_DESC").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                .Append(Dt1.Rows(0)("JOB_COMPONENT_NBR").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("JOB_COMP_DESC")) = False Then
                                .Append(Dt1.Rows(0)("JOB_COMP_DESC").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("TRF_CODE")) = False Then
                                .Append(Dt1.Rows(0)("TRF_CODE").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        'If Session("tcal_ttaskdesc") = True Then
                        If CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("TASK_DESCRIPTION")) = False Then
                                .Append(Dt1.Rows(0)("TASK_DESCRIPTION").ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        'If Session("tcal_empcodedispl") = True Then
                        If CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(Dt1.Rows(0)("EMP_CODE")) = False Then
                                If Dt1.Rows(0)("EMP_CODE").ToString.Trim() <> "" Then
                                    .Append(Dt1.Rows(0)("EMP_CODE").ToString())
                                    .Append("|")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    ''Try
                    ''    If Session("tcal_empdescdispl") = True Then
                    ''        If IsDBNull(dt1.Rows(0)("EMP_FML_NAME")) = False Then
                    ''            .Append(dt1.Rows(0)("EMP_FML_NAME").ToString())
                    ''            .Append("|")
                    ''        End If
                    ''    End If
                    ''Catch ex As Exception
                    ''End Try

                ElseIf isNonTask = 2 Then 'it is an event
                    Try
                        'If Session("tcal_tclientcode") = True Then
                        If IsDBNull(Dt1.Rows(0)("CL_CODE")) = False Then
                            .Append(Dt1.Rows(0)("CL_CODE").ToString())
                            .Append("|")
                        End If
                        'End If
                    Catch ex As Exception
                    End Try
                    Try
                        'If Session("tcal_tjobnum") = True Then
                        If IsDBNull(Dt1.Rows(0)("RESOURCE_CODE")) = False Then
                            .Append(Dt1.Rows(0)("RESOURCE_CODE").ToString())
                            .Append("|")
                        End If
                        'End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.Rows(0)("START_TIME")) = False And IsDBNull(Dt1.Rows(0)("END_TIME")) = False Then
                            '.Append("<strong>Dates: </strong> ")
                            '.Append(CType(dt1.Rows(0)("START_TIME"), Date))
                            '.Append(" - ")
                            '.Append(CType(dt1.Rows(0)("END_TIME"), Date))
                            '.Append("<br />")

                            '.Append("<strong>Start: </strong> ")
                            .Append(CType(Dt1.Rows(0)("START_TIME"), DateTime).ToShortTimeString())
                            ' .Append("<br />")
                            ' .Append("<strong>End: </strong> ")
                            .Append("-")
                            .Append(CType(Dt1.Rows(0)("END_TIME"), DateTime).ToShortTimeString())
                            '.Append("<br />")

                        End If
                    Catch ex As Exception
                    End Try

                    'Try
                    '    'If Session("tcal_tjobcompnum") = True Then
                    '    If IsDBNull(dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                    '        .Append(dt1.Rows(0)("JOB_COMPONENT_NBR").ToString())
                    '        .Append("|")
                    '    End If
                    '    'End If
                    'Catch ex As Exception
                    'End Try
                    'Try
                    '    'If Session("tcal_hasubject") = True Then
                    '    If IsDBNull(dt1.Rows(0)("TASK_NON_TASK_DISPLAY")) = False Then
                    '        .Append(dt1.Rows(0)("TASK_NON_TASK_DISPLAY").ToString())
                    '        .Append("|")
                    '    End If
                    '    'End If
                    'Catch ex As Exception
                    'End Try

                ElseIf isNonTask = 3 Then 'an event task
                    'Try
                    '    'If Session("tcal_tclientcode") = True Then
                    '    If IsDBNull(dt1.Rows(0)("TASK_SEQ_NBR")) = False Then 'this is the event id for the event task!
                    '        .Append(dt1.Rows(0)("TASK_SEQ_NBR").ToString())
                    '        .Append("|")
                    '    End If
                    '    'End If
                    'Catch ex As Exception
                    'End Try
                    'Try
                    '    'If Session("tcal_tclientcode") = True Then
                    '    If IsDBNull(dt1.Rows(0)("NON_TASK_ID")) = False Then 'this is the  event task id!
                    '        .Append(dt1.Rows(0)("NON_TASK_ID").ToString())
                    '        .Append("|")
                    '    End If
                    '    'End If
                    'Catch ex As Exception
                    'End Try

                    'Try
                    '    'If Session("tcal_tclientcode") = True Then
                    '    If IsDBNull(dt1.Rows(0)("NON_TASK_ID")) = False Then 'this is the  event task id!
                    '        .Append(dt1.Rows(0)("NON_TASK_ID").ToString())
                    '        .Append("|")
                    '    End If
                    '    'End If
                    'Catch ex As Exception
                    'End Try
                    Try
                        'If Session("tcal_tjobnum") = True Then
                        If IsDBNull(Dt1.Rows(0)("RESOURCE_CODE")) = False Then
                            .Append(Dt1.Rows(0)("RESOURCE_CODE").ToString())
                            .Append("|")
                        End If
                        'End If
                    Catch ex As Exception
                    End Try
                    Try
                        'If Session("tcal_tjobnum") = True Then
                        If IsDBNull(Dt1.Rows(0)("TRF_CODE")) = False Then
                            .Append(Dt1.Rows(0)("TRF_CODE").ToString())
                            .Append("|")
                        End If
                        'End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.Rows(0)("START_TIME")) = False And IsDBNull(Dt1.Rows(0)("END_TIME")) = False Then
                            '.Append("<strong>Dates: </strong> ")
                            '.Append(CType(dt1.Rows(0)("START_TIME"), Date))
                            '.Append(" - ")
                            '.Append(CType(dt1.Rows(0)("END_TIME"), Date))
                            '.Append("<br />")

                            '.Append("<strong>Start: </strong> ")
                            .Append(CType(Dt1.Rows(0)("START_TIME"), DateTime).ToShortTimeString())
                            ' .Append("<br />")
                            ' .Append("<strong>End: </strong> ")
                            .Append("-")
                            .Append(CType(Dt1.Rows(0)("END_TIME"), DateTime).ToShortTimeString())
                            '.Append("<br />")

                        End If
                    Catch ex As Exception
                    End Try




                End If
            End With
            Dim s As String = MiscFN.RemoveTrailingDelimiter(SbDetails.ToString().Trim(), "|")
            s = MiscFN.RemoveTrailingDelimiter(s, "|")
            s = s.Replace("|", "<strong>|</strong>")
            SbDetails = Nothing
            Return s

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'Public Function RenderBubbles(ByVal Dt1 As DataTable, ByVal isNonTask As Integer, ByVal isAllDay As Integer) As String
    '    Try
    '        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
    '        oAppVars.getAllAppVars()
    '        Dim SbDetails As New System.Text.StringBuilder
    '        With SbDetails
    '            '.Append("<strong>Details</strong><br />")
    '            If Not dt Is Nothing Then
    '                If dt.Rows.Count > 0 Then
    '                    'filter:
    '                    Dim dv As DataView = New DataView(dt)
    '                    dv.RowFilter = "DATA_KEY = '" & re.Value & "'"
    '                    Dt1 = dv.ToTable()
    '                    If Not Dt1 Is Nothing Then
    '                        If Dt1.Rows.Count > 0 Then
    '                            'Get data and build:
    '                            If isNonTask = 1 Then
    '                                Dim ShowEmpCode As Boolean = False
    '                                Dim ShowEmpDescript As Boolean = False
    '                                'If Session("tcal_haemployeecode") = True And NonTaskType = "A" Then
    '                                If CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean) = True And NonTaskType = "A" Then
    '                                    If IsDBNull(Dt1.Rows(0)("EMP_CODE")) = False Then
    '                                        .Append("<strong>Employee: </strong> ")
    '                                        .Append(Dt1.Rows(0)("EMP_CODE").ToString())
    '                                        ShowEmpCode = True
    '                                    End If
    '                                End If
    '                                'If Session("tcal_haemployeedesc") = True And NonTaskType = "A" Then
    '                                If CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean) = True And NonTaskType = "A" Then
    '                                    If ShowEmpCode = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("EMP_FML_NAME")) = False Then
    '                                            .Append(" - ")
    '                                            .Append(Dt1.Rows(0)("EMP_FML_NAME").ToString())
    '                                        End If
    '                                        ShowEmpDescript = True
    '                                    Else
    '                                        .Append("<strong>Employee: </strong> ")
    '                                        .Append(Dt1.Rows(0)("EMP_FML_NAME").ToString())
    '                                    End If
    '                                End If
    '                                If ShowEmpCode = True Or ShowEmpDescript = True Then
    '                                    .Append("<br />")
    '                                End If
    '                                'If Session("tcal_hatype") = True Then
    '                                If CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean) = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("NON_TASK_TYPE")) = False Then
    '                                        .Append("<strong>Type:</strong> ")
    '                                        If Dt1.Rows(0)("NON_TASK_TYPE").ToString().Trim() = "H" Then
    '                                            .Append("Holiday (H)")
    '                                        ElseIf Dt1.Rows(0)("NON_TASK_TYPE").ToString().Trim() = "A" Then
    '                                            .Append("Appointment (A)")
    '                                        End If
    '                                        .Append("<br />")
    '                                    End If
    '                                End If
    '                                'If Session("tcal_hasubject") = True Then
    '                                If CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean) = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("TASK_NON_TASK_DISPLAY")) = False Then
    '                                        .Append("<strong>Subject: </strong> ")
    '                                        .Append(Dt1.Rows(0)("TASK_NON_TASK_DISPLAY").ToString())
    '                                        .Append("<br />")
    '                                    End If
    '                                End If
    '                                'If Session("tcal_hatimes") = True And IsAllDay = 0 Then
    '                                If CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean) = True And isAllDay = 0 Then
    '                                    If IsDBNull(Dt1.Rows(0)("START_TIME")) = False And IsDBNull(Dt1.Rows(0)("END_TIME")) = False Then
    '                                        .Append("<strong>Time: </strong> ")
    '                                        If IsDBNull(Dt1.Rows(0)("NUM_DAYS")) = False Then
    '                                            Dim DayCount As Integer = CType(Dt1.Rows(0)("NUM_DAYS"), Integer)
    '                                            Dim HasTime As Boolean = False
    '                                            If IsDBNull(Dt1.Rows(0)("HAS_TIME")) = False Then
    '                                                If CType(Dt1.Rows(0)("HAS_TIME"), Integer) = 1 Then
    '                                                    HasTime = True
    '                                                End If
    '                                            End If
    '                                            If HasTime = True Then
    '                                                If DayCount > 1 Then
    '                                                    .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
    '                                                    .Append(" ")
    '                                                    .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortTimeString())
    '                                                    .Append(" - ")
    '                                                    .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
    '                                                    .Append(" ")
    '                                                    .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortTimeString())
    '                                                Else 'one day event:
    '                                                    .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
    '                                                    .Append(" ")
    '                                                    .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortTimeString())
    '                                                    .Append(" - ")
    '                                                    .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortTimeString())
    '                                                End If
    '                                            Else
    '                                                If DayCount > 1 Then
    '                                                    .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
    '                                                    .Append(" - ")
    '                                                    .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
    '                                                Else 'one day event:
    '                                                    .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
    '                                                End If
    '                                            End If
    '                                        End If
    '                                        .Append("<br />")
    '                                    End If
    '                                End If
    '                                'If Session("tcal_hahours") = True Then
    '                                If CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean) = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("NON_TASK_HOURS")) = False Then
    '                                        .Append("<strong>Hours: </strong> ")
    '                                        .Append(FormatNumber(Dt1.Rows(0)("NON_TASK_HOURS"), 2, True, False, True))
    '                                        .Append("<br />")
    '                                    End If
    '                                End If
    '                                'If Session("tcal_hatimecat") = True Then
    '                                If CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean) = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("NON_TASK_CATEGORY")) = False Then
    '                                        .Append("<strong>Category: </strong> ")
    '                                        .Append(Dt1.Rows(0)("NON_TASK_CATEGORY").ToString())
    '                                        .Append("<br />")
    '                                    End If
    '                                End If
    '                            ElseIf isNonTask = 0 Then 'Real task!
    '                                Dim ShowCliCode As Boolean = False
    '                                Dim ShowDivCode As Boolean = False
    '                                Dim ShowPrdCode As Boolean = False
    '                                Dim ShowJobNum As Boolean = False
    '                                Dim ShowJobCompNum As Boolean = False
    '                                Dim ShowTaskCode As Boolean = False
    '                                Dim ShowEmpCode As Boolean = False
    '                                Dim ShowCliDesc As Boolean = False
    '                                Dim ShowDivDesc As Boolean = False
    '                                Dim ShowPrdDesc As Boolean = False
    '                                Dim ShowJobDesc As Boolean = False
    '                                Dim ShowJobCompDesc As Boolean = False
    '                                Dim ShowTaskDesc As Boolean = False
    '                                Dim ShowEmpDesc As Boolean = False

    '                                Try
    '                                    'If Session("tcal_tclientcode") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean) = True = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("CL_CODE")) = False Then
    '                                            .Append("<strong>Client: </strong> ")
    '                                            .Append(Dt1.Rows(0)("CL_CODE").ToString())
    '                                            ShowCliCode = True
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tclientdesc") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean) = True Then
    '                                        If ShowCliCode = True Then
    '                                            .Append(" - ")
    '                                            .Append(Dt1.Rows(0)("CL_NAME").ToString())
    '                                        Else
    '                                            If IsDBNull(Dt1.Rows(0)("CL_NAME")) = False Then
    '                                                .Append("Client: ")
    '                                                .Append(Dt1.Rows(0)("CL_NAME").ToString())
    '                                                ShowCliDesc = True
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                If ShowCliCode = True Or ShowCliDesc = True Then
    '                                    .Append("<br />")
    '                                End If


    '                                Try
    '                                    'If Session("tcal_tdivcode") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean) = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("DIV_CODE")) = False Then
    '                                            .Append("<strong>Division: </strong> ")
    '                                            .Append(Dt1.Rows(0)("DIV_CODE").ToString())
    '                                            ShowDivCode = True
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tdivdesc") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean) = True Then
    '                                        If ShowDivCode = True Then
    '                                            .Append(" - ")
    '                                            .Append(Dt1.Rows(0)("DIV_NAME").ToString())
    '                                        Else
    '                                            If IsDBNull(Dt1.Rows(0)("DIV_NAME")) = False Then
    '                                                .Append("<strong>Division: </strong> ")
    '                                                .Append(Dt1.Rows(0)("DIV_NAME").ToString())
    '                                                ShowDivDesc = True
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                If ShowDivCode = True Or ShowDivDesc = True Then
    '                                    .Append("<br />")
    '                                End If


    '                                Try
    '                                    'If Session("tcal_tprodcode") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean) = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("PRD_CODE")) = False Then
    '                                            .Append("<strong>Product: </strong> ")
    '                                            .Append(Dt1.Rows(0)("PRD_CODE").ToString())
    '                                            ShowPrdCode = True
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tproddesc") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean) = True Then
    '                                        If ShowPrdCode = True Then
    '                                            .Append(" - ")
    '                                            .Append(Dt1.Rows(0)("PRD_DESCRIPTION").ToString())
    '                                        Else
    '                                            If IsDBNull(Dt1.Rows(0)("PRD_DESCRIPTION")) = False Then
    '                                                .Append("<strong>Product: </strong> ")
    '                                                .Append(Dt1.Rows(0)("PRD_DESCRIPTION").ToString())
    '                                                ShowPrdDesc = True
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                If ShowPrdCode = True Or ShowPrdDesc = True Then
    '                                    .Append("<br />")
    '                                End If


    '                                Try
    '                                    'If Session("tcal_tjobnum") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean) = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("JOB_NUMBER")) = False Then
    '                                            .Append("<strong>Job: </strong> ")
    '                                            .Append(Dt1.Rows(0)("JOB_NUMBER").ToString().PadLeft(6, "0"))
    '                                            ShowJobNum = True
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobdesc") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean) = True Then
    '                                        If ShowJobNum = True Then
    '                                            .Append(" - ")
    '                                            .Append(Dt1.Rows(0)("JOB_DESC").ToString())
    '                                        Else
    '                                            If IsDBNull(Dt1.Rows(0)("JOB_DESC")) = False Then
    '                                                .Append("<strong>Job: </strong> ")
    '                                                .Append(Dt1.Rows(0)("JOB_DESC").ToString())
    '                                                ShowJobDesc = True
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                If ShowJobNum = True Or ShowJobDesc = True Then
    '                                    .Append("<br />")
    '                                End If


    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean) = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
    '                                            .Append("<strong>Component: </strong> ")
    '                                            .Append(Dt1.Rows(0)("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
    '                                            ShowJobCompNum = True
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompdesc") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean) = True Then
    '                                        If ShowJobCompNum = True Then
    '                                            .Append(" - ")
    '                                            .Append(Dt1.Rows(0)("JOB_COMP_DESC").ToString())
    '                                        Else
    '                                            If IsDBNull(Dt1.Rows(0)("JOB_COMP_DESC")) = False Then
    '                                                .Append("<strong>Component: </strong> ")
    '                                                .Append(Dt1.Rows(0)("JOB_COMP_DESC").ToString())
    '                                                ShowJobCompDesc = True
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                If ShowJobCompNum = True Or ShowJobCompDesc = True Then
    '                                    .Append("<br />")
    '                                End If


    '                                Try
    '                                    'If Session("tcal_ttaskcode") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean) = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("FNC_CODE")) = False Then
    '                                            .Append("<strong>Task: </strong> ")
    '                                            .Append(Dt1.Rows(0)("FNC_CODE").ToString())
    '                                            ShowTaskCode = True
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_ttaskdesc") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean) = True Then
    '                                        If ShowTaskCode = True Then
    '                                            .Append(" - ")
    '                                            .Append(Dt1.Rows(0)("TASK_DESCRIPTION").ToString())
    '                                        Else
    '                                            If IsDBNull(Dt1.Rows(0)("TASK_DESCRIPTION")) = False Then
    '                                                .Append("<strong>Task: </strong> ")
    '                                                .Append(Dt1.Rows(0)("TASK_DESCRIPTION").ToString())
    '                                                ShowTaskDesc = True
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                If ShowTaskCode = True Or ShowTaskDesc = True Then
    '                                    .Append("<br />")
    '                                End If

    '                                Try
    '                                    If IsDBNull(Dt1.Rows(0)("START_TIME")) = False And IsDBNull(Dt1.Rows(0)("END_TIME")) = False Then
    '                                        If IsDBNull(Dt1.Rows(0)("NUM_DAYS")) = False Then
    '                                            Dim DayCount As Integer = CType(Dt1.Rows(0)("NUM_DAYS"), Integer)
    '                                            If DayCount > 1 Then
    '                                                .Append("<strong>Dates: </strong> ")
    '                                                .Append(CType(Dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
    '                                                .Append(" - ")
    '                                                .Append(CType(Dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
    '                                                'Else 'one day event:
    '                                                '    .Append(CType(dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
    '                                                .Append("<br />")
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try


    '                                Try
    '                                    'If Session("tcal_empcodedispl") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean) = True Then
    '                                        If IsDBNull(Dt1.Rows(0)("EMP_CODE")) = False Then
    '                                            .Append("<strong>Employee: </strong> ")
    '                                            .Append(Dt1.Rows(0)("EMP_CODE").ToString())
    '                                            ShowEmpCode = True
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_empdescdispl") = True Then
    '                                    If CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean) = True Then
    '                                        If ShowEmpCode = True Then
    '                                            If IsDBNull(Dt1.Rows(0)("EMP_FML_NAME")) = False Then
    '                                                .Append(" - ")
    '                                                .Append(Dt1.Rows(0)("EMP_FML_NAME").ToString())
    '                                            End If
    '                                            ShowEmpDesc = True
    '                                        Else
    '                                            .Append("<strong>Employee: </strong> ")
    '                                            .Append(Dt1.Rows(0)("EMP_FML_NAME").ToString())
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                                If ShowEmpCode = True Or ShowEmpDesc = True Then
    '                                    .Append("<br />")
    '                                End If
    '                            ElseIf isNonTask = 2 Then 'event
    '                                Try
    '                                    'If Session("tcal_tjobnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("JOB_NUMBER")) = False Then
    '                                        .Append("<strong>Job Number: </strong> ")
    '                                        .Append(Dt1.Rows(0)("JOB_NUMBER").ToString().PadLeft(6, "0"))
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
    '                                        .Append("<strong>Component Number: </strong> ")
    '                                        .Append(Dt1.Rows(0)("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("NON_TASK_ID")) = False Then
    '                                        .Append("<strong>Event ID: </strong> ")
    '                                        .Append(Dt1.Rows(0)("NON_TASK_ID").ToString().PadLeft(6, "0"))
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("TASK_NON_TASK_DISPLAY")) = False Then
    '                                        .Append("<strong>Event Description: </strong> ")
    '                                        .Append(Dt1.Rows(0)("TASK_NON_TASK_DISPLAY").ToString())
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                'Try
    '                                '    If IsDBNull(dt1.Rows(0)("START_TIME")) = False And IsDBNull(dt1.Rows(0)("END_TIME")) = False Then
    '                                '        '.Append("<strong>Dates: </strong> ")
    '                                '        '.Append(CType(dt1.Rows(0)("START_TIME"), Date))
    '                                '        '.Append(" - ")
    '                                '        '.Append(CType(dt1.Rows(0)("END_TIME"), Date))
    '                                '        '.Append("<br />")
    '                                '        .Append("<strong>Start: </strong> ")
    '                                '        .Append(CType(dt1.Rows(0)("START_TIME"), Date))
    '                                '        .Append("<br />")
    '                                '        .Append("<strong>End: </strong> ")
    '                                '        .Append(CType(dt1.Rows(0)("END_TIME"), Date))
    '                                '        .Append("<br />")
    '                                '    End If
    '                                'Catch ex As Exception
    '                                'End Try

    '                            ElseIf isNonTask = 3 Then 'an event task
    '                                Try
    '                                    'If Session("tcal_tjobnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("JOB_NUMBER")) = False Then
    '                                        .Append("<strong>Job Number: </strong> ")
    '                                        .Append(Dt1.Rows(0)("JOB_NUMBER").ToString().PadLeft(6, "0"))
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
    '                                        .Append("<strong>Component Number: </strong> ")
    '                                        .Append(Dt1.Rows(0)("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("TASK_SEQ_NBR")) = False Then
    '                                        .Append("<strong>Event ID: </strong> ")
    '                                        .Append(Dt1.Rows(0)("TASK_SEQ_NBR").ToString().PadLeft(6, "0"))
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("EVENT_AND_DESCRIPT")) = False Then
    '                                        .Append("<strong>Event Description: </strong> ")
    '                                        .Append(Dt1.Rows(0)("EVENT_AND_DESCRIPT").ToString())
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("NON_TASK_ID")) = False Then
    '                                        .Append("<strong>Event Task ID: </strong> ")
    '                                        .Append(Dt1.Rows(0)("NON_TASK_ID").ToString().PadLeft(6, "0"))
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                Try
    '                                    'If Session("tcal_tjobcompnum") = True Then
    '                                    If IsDBNull(Dt1.Rows(0)("TRF_AND_DESCRIPT")) = False Then
    '                                        .Append("<strong>Task Description: </strong> ")
    '                                        .Append(Dt1.Rows(0)("TRF_AND_DESCRIPT").ToString())
    '                                        .Append("<br />")
    '                                    End If
    '                                    'End If
    '                                Catch ex As Exception
    '                                End Try
    '                                '
    '                            End If
    '                        End If
    '                    End If
    '                Else
    '                    .Append("[None]")
    '                End If
    '            End If
    '        End With
    '    Catch ex As Exception
    '        Return ex.Message.ToString()
    '    End Try
    'End Function



#End Region

#Region " Misc "

    Private Function BoolToYN(ByVal input As Boolean) As String
        Try
            If input = True Then
                Return "Y"
            Else
                Return "N"
            End If
        Catch ex As Exception
            Return "N"
        End Try
    End Function

#End Region

    Public Sub New(Optional ByVal UserID As String = "", Optional ByVal EmpCode As String = "")
        mConnString = HttpContext.Current.Session("ConnString")
        Try
            If UserID <> "" Then
                mUserID = UserID
            Else
                mUserID = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserID = ""
        End Try
        Try
            If EmpCode <> "" Then
                mEmpCode = EmpCode
            Else
                mEmpCode = HttpContext.Current.Session("EmpCode")
            End If
        Catch ex As Exception
            mEmpCode = ""
        End Try
    End Sub

End Class
