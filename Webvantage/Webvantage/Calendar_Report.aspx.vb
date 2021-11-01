Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports Webvantage.cGlobals.Globals

Partial Public Class Calendar_Report
    Inherits Webvantage.BaseChildPage
    Public dtThisDate As Date

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim c As New cDayPilot()
        'c.LoadTabs(Me.RadTabStripTaskCalendar, Request.QueryString("FromApp"), Request.QueryString("JobNum"), Request.QueryString("JobCompNum"))

        If Page.IsPostBack = True Then
            dtThisDate = CDate(ViewState("ThisDate"))
        Else
            If IsDate(Request.QueryString("Date")) = True Then
                dtThisDate = CDate(Request.QueryString("Date"))
            Else
                dtThisDate = Today.Date
            End If
            rbplacement.SelectedValue = "center"

            LoadDropDown(dtThisDate)
            LoadLookup()

            Dim AppVars As Webvantage.cAppVars = Nothing

            AppVars = LoadAppVars()

            If AppVars.getAppVar("rpt_location_id") <> "" Then

                ddLocation.SelectedValue = AppVars.getAppVar("rpt_location_id")

            End If

            If AppVars.getAppVar("rpt_title_placement") <> "" Then

                rbplacement.SelectedIndex = AppVars.getAppVar("rpt_title_placement")

            End If

            If AppVars.getAppVar("rpt_title") <> "" Then

                TBTitle.Text = AppVars.getAppVar("rpt_title")

            End If

            If AppVars.getAppVar("rpt_group_by") <> "" Then

                RBGroup.SelectedIndex = AppVars.getAppVar("rpt_group_by")

            End If

            If AppVars.getAppVar("rpt_include_schedule_comment") <> "" Then

                chkSchClient.Checked = CBool(AppVars.getAppVar("rpt_include_schedule_comment", "Boolean", "False"))

            End If

            If AppVars.getAppVar("rpt_include_status") <> "" Then

                chkStatus.Checked = CBool(AppVars.getAppVar("rpt_include_status", "Boolean", "False"))

            End If

            If AppVars.getAppVar("rpt_include_tasks") <> "" Then

                chkTasks.Checked = CBool(AppVars.getAppVar("rpt_include_tasks", "Boolean", "False"))

            End If

            If AppVars.getAppVar("rpt_include_assignments") <> "" Then

                chkAssignments.Checked = CBool(AppVars.getAppVar("rpt_include_assignments", "Boolean", "False"))

            End If

            If AppVars.getAppVar("rpt_include_holidays") <> "" Then

                chkHolidays.Checked = CBool(AppVars.getAppVar("rpt_include_holidays", "Boolean", "False"))

            End If

            If AppVars.getAppVar("rpt_include_appointments") <> "" Then

                chkAppts.Checked = CBool(AppVars.getAppVar("rpt_include_appointments", "Boolean", "False"))

            End If

            If AppVars.getAppVar("rpt_include_events") <> "" Then

                chkEvents.Checked = CBool(AppVars.getAppVar("rpt_include_events", "Boolean", "False"))

            End If

            If AppVars.getAppVar("rpt_include_event_tasks") <> "" Then

                chkEventTasks.Checked = CBool(AppVars.getAppVar("rpt_include_event_tasks", "Boolean", "False"))

            End If


            If Not Session("Calresponse") Is Nothing Then
                If Session("Calresponse") = True Then
                    Dim msg As String
                    msg = Session("Calresponse_string")
                    Me.ShowMessage(msg)
                    Session("Calresponse") = False
                End If
            End If

            Me.FieldsetGroupBy.Visible = True

            If Me.IsClientPortal = True Then
                Me.chkAppts.Checked = False
                Me.chkAppts.Visible = False
                Me.chkHolidays.Checked = False
                Me.chkHolidays.Visible = False
                Me.chkEvents.Checked = False
                Me.chkEvents.Visible = False
                Me.chkEventTasks.Checked = False
                Me.chkEventTasks.Visible = False
            End If
        End If

    End Sub
    Private Sub Calendar_Report_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        If Request.QueryString("mode") = "print" Then

            PrintReport()
            Me.CloseThisWindow()

        End If

    End Sub

    Private Function LoadAppVars() As Webvantage.cAppVars

        'objects
        Dim AppVars As cAppVars = Nothing

        If Session("CalendaReportPrintApp") = "PS" Then

            AppVars = New cAppVars(cAppVars.Application.PMD_CALENDAR)

        Else

            AppVars = New cAppVars(cAppVars.Application.CALENDAR)

        End If

        AppVars.getAllAppVars()

        Return AppVars

    End Function

    Private Sub LoadLookup()
        Try
            Dim oReports As cReports = New cReports(CStr(Session("ConnString")))

            Me.ddLocation.DataSource = oReports.GetLocationPO
            Me.ddLocation.DataTextField = "ID"
            Me.ddLocation.DataValueField = "LOGO_PATH"
            Me.ddLocation.DataBind()
            Me.ddLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "None"))
        Catch ex As Exception
            Me.ShowMessage("Error ddlocation!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub LoadDropDown(ByVal ThisDate As Date)
        With Me.ddStartMonth
            .Items.Clear()
            .DataSource = LoGlo.LoadMonths()
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
        End With
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("January"), CStr("1")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("February"), CStr("2")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("March"), CStr("3")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("April"), CStr("4")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("May"), CStr("5")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("June"), CStr("6")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("July"), CStr("7")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("August"), CStr("8")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("September"), CStr("9")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("October"), CStr("10")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("November"), CStr("11")))
        'Me.ddStartMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("December"), CStr("12")))
        Me.ddStartMonth.SelectedValue = ThisDate.Month.ToString
        Me.ddStartYear.Items.Clear()
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-5).Year.ToString(), Now.AddYears(-5).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-4).Year.ToString(), Now.AddYears(-4).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-3).Year.ToString(), Now.AddYears(-3).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-2).Year.ToString(), Now.AddYears(-2).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-1).Year.ToString(), Now.AddYears(-1).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.Year.ToString(), Now.Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(1).Year.ToString(), Now.AddYears(1).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(2).Year.ToString(), Now.AddYears(2).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(3).Year.ToString(), Now.AddYears(3).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(4).Year.ToString(), Now.AddYears(4).Year.ToString()))
        Me.ddStartYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(5).Year.ToString(), Now.AddYears(5).Year.ToString()))
        Me.ddStartYear.SelectedValue = ThisDate.Year.ToString

        With Me.ddEndMonth
            .Items.Clear()
            .DataSource = LoGlo.LoadMonths()
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
        End With
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("January"), CStr("1")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("February"), CStr("2")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("March"), CStr("3")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("April"), CStr("4")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("May"), CStr("5")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("June"), CStr("6")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("July"), CStr("7")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("August"), CStr("8")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("September"), CStr("9")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("October"), CStr("10")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("November"), CStr("11")))
        'Me.ddEndMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("December"), CStr("12")))
        Me.ddEndMonth.SelectedValue = ThisDate.Month.ToString
        Me.ddEndYear.Items.Clear()
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-5).Year.ToString(), Now.AddYears(-5).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-4).Year.ToString(), Now.AddYears(-4).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-3).Year.ToString(), Now.AddYears(-3).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-2).Year.ToString(), Now.AddYears(-2).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-1).Year.ToString(), Now.AddYears(-1).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.Year.ToString(), Now.Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(1).Year.ToString(), Now.AddYears(1).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(2).Year.ToString(), Now.AddYears(2).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(3).Year.ToString(), Now.AddYears(3).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(4).Year.ToString(), Now.AddYears(4).Year.ToString()))
        Me.ddEndYear.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(5).Year.ToString(), Now.AddYears(5).Year.ToString()))
        Me.ddEndYear.SelectedValue = ThisDate.Year.ToString
    End Sub

    Private Function validateDates(ByRef m As String) As Boolean
        Dim startMonth, endMonth, startYear, endYear As Integer
        Dim startDate, endDate As String
        Dim intDaysInMonth As Integer
        Dim dateTemp, dateTempEnd As Date

        startMonth = CInt(Me.ddStartMonth.SelectedValue)
        endMonth = CInt(Me.ddEndMonth.SelectedValue)
        startYear = CInt(Me.ddStartYear.SelectedValue)
        endYear = CInt(Me.ddEndYear.SelectedValue)

        'Only allow up to one year report
        startDate = LoGlo.FirstOfMonth(Me.ddStartYear.SelectedValue, Me.ddStartMonth.SelectedValue)

        dateTemp = CDate(CStr(Me.ddEndMonth.SelectedValue) & "/1/" & CStr(Me.ddEndYear.SelectedValue))
        intDaysInMonth = dateTemp.DaysInMonth(dateTemp.Year, dateTemp.Month)
        endDate = LoGlo.LastOfMonth(LoGlo.FormatDate(Me.ddEndMonth.SelectedValue & "/13/" & Me.ddEndYear.SelectedValue))

        If wvIsDate(startDate) = False Then
            Me.ddStartYear.Focus()
            m = "Please enter a valid date for Start Date."
            Return False
        End If
        If wvIsDate(endDate) = False Then
            Me.ddEndMonth.Focus()
            m = "Please enter a valid date for End Date"
            Return False
        End If

        If wvCDate(startDate) > wvCDate(endDate) Then
            Me.ddEndMonth.Focus()
            m = "End Date must be greater than Start Date"
            Return False
        End If

        If wvCDate(endDate).Subtract(wvCDate(startDate)).Days > 365 Then
            Me.ddEndMonth.Focus()
            m = "Date range must be less than year."
            Return False
        End If

        Return True

    End Function

    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        SaveReportAppVars()
        PrintReport()

    End Sub
    Private Sub PrintReport()

        'objects
        Dim CalendarReport As AdvantageFramework.Reporting.Classes.CalendarReport = Nothing
        Dim Message As String = ""
        Dim StartDate As String = ""
        Dim EndDate As String = ""
        Dim GroupLevel As String = ""
        Dim IncludeScheduleComment As String = ""
        Dim IncludeStatus As String = ""
        Dim IncludeTasks As String = ""
        Dim IncludeAssignments As String = ""
        Dim IncludeHolidays As String = ""
        Dim IncludeAppointments As String = ""
        Dim IncludeEvents As String = ""
        Dim IncludeEventTasks As String = ""
        Dim SelectedLocation As String() = Nothing
        Dim oAppVars As cAppVars = Nothing
        Dim IsDueDateView As Boolean = False

        If chkTasks.Checked = False And chkHolidays.Checked = False And chkAppts.Checked = False And chkEvents.Checked = False And chkEventTasks.Checked = False And chkAssignments.Checked = False Then

            Me.ShowMessage("Please select to include at least one display item: tasks/holidays/appts/Events/EventTasks.")
            Exit Sub

        End If

        oAppVars = LoadAppVars()

        If Request.QueryString("mode") = "print" Then

            IsDueDateView = Not CBool(oAppVars.getAppVar("tcal_duration", "Boolean"))

            IncludeScheduleComment = "0"
            IncludeStatus = "0"
            IncludeTasks = If(oAppVars.getAppVar("tcal_showtasks", "Boolean"), "1", "0")
            IncludeAssignments = If(CBool(oAppVars.getAppVar("rpt_include_assignments", "Boolean")), "1", "0")
            IncludeHolidays = If(oAppVars.getAppVar("tcal_showholidays", "Boolean"), "1", "0")
            IncludeAppointments = If(oAppVars.getAppVar("tcal_showappointments", "Boolean"), "1", "0")
            IncludeEvents = If(oAppVars.getAppVar("tcal_showevent", "Boolean"), "1", "0")
            IncludeEventTasks = If(oAppVars.getAppVar("tcal_showeventtasks", "Boolean"), "1", "0")

            With CDate(Request.QueryString("Date"))

                StartDate = LoGlo.FirstOfMonth(.Year, .Month)
                EndDate = LoGlo.LastOfMonth(.Date)

            End With

        Else

            IncludeScheduleComment = If(CBool(oAppVars.getAppVar("rpt_include_schedule_comment", "Boolean")), "1", "0")
            IncludeStatus = If(CBool(oAppVars.getAppVar("rpt_include_status", "Boolean")), "1", "0")
            IncludeTasks = If(CBool(oAppVars.getAppVar("rpt_include_tasks", "Boolean")), "1", "0")
            IncludeAssignments = If(CBool(oAppVars.getAppVar("rpt_include_assignments", "Boolean")), "1", "0")
            IncludeHolidays = If(CBool(oAppVars.getAppVar("rpt_include_holidays", "Boolean")), "1", "0")
            IncludeAppointments = If(CBool(oAppVars.getAppVar("rpt_include_appointments", "Boolean")), "1", "0")
            IncludeEvents = If(CBool(oAppVars.getAppVar("rpt_include_events", "Boolean")), "1", "0")
            IncludeEventTasks = If(CBool(oAppVars.getAppVar("rpt_include_event_tasks", "Boolean")), "1", "0")

            If validateDates(Message) = True Then

                StartDate = LoGlo.FirstOfMonth(Me.ddStartYear.SelectedValue, Me.ddStartMonth.SelectedValue)
                EndDate = LoGlo.LastOfMonth(LoGlo.FormatDate(Me.ddEndMonth.Text & "/13/" & Me.ddEndYear.Text))

            End If

        End If

        If Not String.IsNullOrWhiteSpace(Message) Then

            Me.ShowMessage(Message)
            Exit Sub

        End If

        SelectedLocation = ddLocation.SelectedItem.Value.ToString.Split("|")

        If SelectedLocation.Length > 1 Then

            Session("LogoPath") = SelectedLocation(1)

        Else

            Session("LogoPath") = ""

        End If

        GroupLevel = CStr(oAppVars.getAppVar("rpt_group_by", "Number", "0"))

        If Session("CalendaReportPrintApp") = "" Then

            CalendarReport = getTaskReport(IncludeTasks, IncludeAssignments, IncludeHolidays, IncludeAppointments, IncludeEvents, IncludeEventTasks, "", 0, 0, StartDate, EndDate, GroupLevel)

        ElseIf Session("CalendaReportPrintApp") = "PSMV" Then

            CalendarReport = getTaskReport(IncludeTasks, IncludeAssignments, IncludeHolidays, IncludeAppointments, IncludeEvents, IncludeEventTasks, Session("CalendaReportPrintApp"), 0, 0, StartDate, EndDate, GroupLevel)

        Else

            CalendarReport = getTaskReport(IncludeTasks, IncludeAssignments, IncludeHolidays, IncludeAppointments, IncludeEvents, IncludeEventTasks, Session("CalendaReportPrintApp"), Session("CalendaReportPrintJob"), Session("CalendaReportPrintComp"), StartDate, EndDate, GroupLevel)

        End If

        If CalendarReport.Worksheets.Count = 0 OrElse CalendarReport.Worksheets.Any(Function(ws) ws.CalendarItems.Count > 0) = False Then

            Me.ShowMessage("No Data for Selected Inputs.")
            Exit Sub

        End If

        Try

            CalendarReport.ReportTitle = oAppVars.getAppVar("rpt_title") ' TBTitle.Text
            CalendarReport.TitleAlignment = CShort(oAppVars.getAppVar("rpt_title_placement", "Number"))

            'AppVars.setAppVar("rpt_location_id", ddLocation.SelectedValue)

            PrintCalendarReport(CalendarReport, StartDate, EndDate, IsDueDateView)

        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try

    End Sub

    Private Sub PrintCalendarReport(ByVal CalendarReport As AdvantageFramework.Reporting.Classes.CalendarReport, ByVal StartDate As Date, ByVal EndDate As Date, ByVal IsDueDateView As Boolean)

        'objects
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim Worksheet As Aspose.Cells.Worksheet = Nothing
        Dim License As Aspose.Cells.License = Nothing
        Dim XlsSaveOptions As Aspose.Cells.XlsSaveOptions = Nothing
        Dim CurrentMonth As Short = 0
        Dim CurrentRow As Integer = 0
        Dim RowsNeeded As Short = Nothing
        Dim CurrentDate As Date = Nothing
        Dim CalendarEndDate As Date = Nothing
        Dim CalendarItems As Generic.List(Of AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem) = Nothing
        Dim FirstDayOfWeek As Date = Nothing
        Dim LastDayOfWeek As Date = Nothing
        Dim BlankCalendarDay As Date = Nothing
        Dim AccentIndex As Integer = Nothing
        Dim BuiltInStyleTypeName As String = Nothing
        Dim Counter As Short = 0
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim Picture As Aspose.Cells.Drawing.Picture = Nothing
        Dim HorizontalAlignment As Aspose.Cells.TextAlignmentType = Nothing

        License = New Aspose.Cells.License
        License.SetLicense("Aspose.Total.lic")

        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)

        If CalendarReport.Worksheets.Count > 0 Then

            For Each CalendarWorksheet In CalendarReport.Worksheets

                Counter = 0
                CurrentMonth = 0
                CurrentRow = 0

                If Workbook.Worksheets.Count < (CalendarReport.Worksheets.IndexOf(CalendarWorksheet) + 1) Then

                    Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

                End If

                Worksheet = Workbook.Worksheets(CalendarReport.Worksheets.IndexOf(CalendarWorksheet))

                Worksheet.Name = CalendarWorksheet.Name

                If Not String.IsNullOrWhiteSpace(Session("LogoPath")) Then

                    Try

                        Picture = Worksheet.Pictures(Worksheet.Pictures.Add(0, 0, Session("LogoPath")))

                        Worksheet.Cells.Merge(0, 0, 1, 7)
                        Worksheet.Cells.Rows(0).Height = Picture.HeightPt
                        CurrentRow += 1

                    Catch ex As Exception

                    End Try

                End If

                If CalendarWorksheet.CalendarItems.Count > 0 Then

                    For Each JobComp In (From Item In CalendarWorksheet.CalendarItems
                                         Order By Item.StartDate
                                         Select Item.JobNumber, Item.JobComponentNumber).Distinct.ToList

                        AccentIndex = CInt(Math.Truncate((Counter Mod 24) / 6))

                        BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.Accent1.ToString.Replace("1", (Counter Mod 6) + 1)

                        If AccentIndex = 1 Then

                            BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.SixtyPercentAccent1.ToString.Replace("Accent1", BuiltInStyleTypeName)

                        ElseIf AccentIndex = 2 Then

                            BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.FortyPercentAccent1.ToString.Replace("Accent1", BuiltInStyleTypeName)

                        ElseIf AccentIndex = 3 Then

                            BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.TwentyPercentAccent1.ToString.Replace("Accent1", BuiltInStyleTypeName)

                        End If

                        For Each CalendarItem In CalendarWorksheet.CalendarItems.Where(Function(c) c.JobNumber = JobComp.JobNumber AndAlso c.JobComponentNumber = JobComp.JobComponentNumber).ToList

                            CalendarItem.Background = BuiltInStyleTypeName

                        Next

                        Counter += 1

                    Next

                    CurrentRow = 1

                    CurrentDate = StartDate
                    CalendarEndDate = EndDate

                    While CurrentDate <= CalendarEndDate

                        If CurrentDate = StartDate Then

                            If Not String.IsNullOrWhiteSpace(CalendarReport.ReportTitle) Then

                                Select Case CalendarReport.TitleAlignment
                                    Case 0
                                        HorizontalAlignment = Aspose.Cells.TextAlignmentType.Left
                                    Case 1
                                        HorizontalAlignment = Aspose.Cells.TextAlignmentType.Right
                                    Case 2
                                        HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
                                    Case Else
                                        HorizontalAlignment = Aspose.Cells.TextAlignmentType.Left
                                End Select

                                AddReportHeaderToWorksheet(Worksheet, CurrentRow, CalendarReport.ReportTitle, HorizontalAlignment)
                                CurrentRow += 1

                            End If

                            If CalendarWorksheet.Subtitle IsNot Nothing Then

                                If TypeOf CalendarWorksheet.Subtitle Is AdvantageFramework.Database.Entities.Client Then

                                    With DirectCast(CalendarWorksheet.Subtitle, AdvantageFramework.Database.Entities.Client)

                                        AddKeyValueToWorksheet(Worksheet, CurrentRow, 0, "Client", .Name)

                                    End With

                                    CurrentRow += 1

                                ElseIf TypeOf CalendarWorksheet.Subtitle Is AdvantageFramework.Database.Views.DivisionView Then

                                    With DirectCast(CalendarWorksheet.Subtitle, AdvantageFramework.Database.Views.DivisionView)

                                        AddKeyValueToWorksheet(Worksheet, CurrentRow, 0, "Client", .ClientName)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 1, 0, "Division", .DivisionName)

                                    End With

                                    CurrentRow += 2

                                ElseIf TypeOf CalendarWorksheet.Subtitle Is AdvantageFramework.Database.Views.ProductView Then

                                    With DirectCast(CalendarWorksheet.Subtitle, AdvantageFramework.Database.Views.ProductView)

                                        AddKeyValueToWorksheet(Worksheet, CurrentRow, 0, "Client", .ClientName)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 1, 0, "Division", .DivisionName)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 2, 0, "Product", .ProductDescription)

                                    End With

                                    CurrentRow += 3

                                ElseIf TypeOf CalendarWorksheet.Subtitle Is AdvantageFramework.Database.Views.JobView Then

                                    With DirectCast(CalendarWorksheet.Subtitle, AdvantageFramework.Database.Views.JobView)

                                        AddKeyValueToWorksheet(Worksheet, CurrentRow, 0, "Client", .ClientName)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 1, 0, "Division", .DivisionName)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 2, 0, "Product", .ProductDescription)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow, 3, "Job", .JobNumber.ToString & " - " & .JobDescription)

                                    End With

                                    CurrentRow += 3

                                ElseIf TypeOf CalendarWorksheet.Subtitle Is AdvantageFramework.Database.Views.JobComponentView Then

                                    With DirectCast(CalendarWorksheet.Subtitle, AdvantageFramework.Database.Views.JobComponentView)

                                        AddKeyValueToWorksheet(Worksheet, CurrentRow, 0, "Client", .ClientName)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 1, 0, "Division", .DivisionName)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 2, 0, "Product", .ProductDescription)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow, 3, "Job", .JobNumber.ToString & " - " & .JobDescription)
                                        AddKeyValueToWorksheet(Worksheet, CurrentRow + 1, 3, "Component", .JobComponentNumber.ToString & " - " & .JobComponentDescription)

                                    End With

                                    CurrentRow += 3

                                ElseIf TypeOf CalendarWorksheet.Subtitle Is System.String Then



                                End If

                            End If

                        End If

                        If CurrentDate.Month <> CurrentMonth Then

                            If CurrentMonth > 0 Then 'no trailers for first month

                                If CurrentDate.DayOfWeek <> DayOfWeek.Sunday Then

                                    BlankCalendarDay = CurrentDate

                                    While BlankCalendarDay.DayOfWeek <> DayOfWeek.Sunday

                                        BuildDayCell(Worksheet, Nothing, Nothing, BlankCalendarDay, CurrentRow, RowsNeeded, IsDueDateView)

                                        BlankCalendarDay = BlankCalendarDay.AddDays(1)

                                    End While

                                End If

                                CurrentRow += RowsNeeded + 2

                            End If

                            AddCalendarHeaderToWorksheet(Worksheet, CurrentRow, CurrentDate)

                            CurrentRow += 2

                            RowsNeeded = CalendarWorksheet.GetNumberOfRowsNeeded(CurrentDate, IsDueDateView)

                            If CurrentDate.DayOfWeek <> DayOfWeek.Sunday Then

                                BlankCalendarDay = CurrentDate.AddDays(-CInt(CurrentDate.DayOfWeek))

                                While BlankCalendarDay < CurrentDate

                                    BuildDayCell(Worksheet, Nothing, Nothing, BlankCalendarDay, CurrentRow, RowsNeeded, IsDueDateView)

                                    BlankCalendarDay = BlankCalendarDay.AddDays(1)

                                End While

                            End If

                            CurrentMonth = CurrentDate.Month

                        ElseIf CurrentDate.DayOfWeek = DayOfWeek.Sunday Then

                            CurrentRow += RowsNeeded
                            RowsNeeded = CalendarWorksheet.GetNumberOfRowsNeeded(CurrentDate, IsDueDateView)

                        End If

                        BuildDayCell(Worksheet, CalendarReport, CalendarWorksheet, CurrentDate, CurrentRow, RowsNeeded, IsDueDateView)

                        CurrentDate = CurrentDate.AddDays(1)

                    End While

                    If CurrentDate.DayOfWeek <> DayOfWeek.Sunday Then

                        While CurrentDate.DayOfWeek <> DayOfWeek.Sunday

                            BuildDayCell(Worksheet, Nothing, Nothing, CurrentDate, CurrentRow, RowsNeeded, IsDueDateView)
                            CurrentDate = CurrentDate.AddDays(1)

                        End While

                    End If

                End If

                'Worksheet.AutoFitColumns()

                For I = 0 To 6

                    If I = 0 OrElse I = 6 Then

                        Worksheet.Cells.SetColumnWidth(I, 16)

                    Else

                        Worksheet.Cells.SetColumnWidth(I, 32)

                    End If

                Next

            Next

        End If

        If StartDate.Month = EndDate.Month AndAlso StartDate.Year = EndDate.Year Then

            Workbook.FileName = String.Format("CALENDAR_REPORT_{0:MMMyyyy}", StartDate).ToUpper & ".xls"

        Else

            Workbook.FileName = String.Format("CALENDAR_REPORT_{0:MMMyyyy}-{1:MMMyyyy}", StartDate, EndDate).ToUpper & ".xls"

        End If

        Try

            Using MemoryStream = New System.IO.MemoryStream

                XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)

                Workbook.Save(MemoryStream, XlsSaveOptions)

                With HttpContext.Current.Response

                    .Clear()
                    .Buffer = True
                    .ContentType = "application/vnd.ms-excel"
                    .AppendHeader("Content-Disposition", "attachment; filename=" & Workbook.FileName)
                    .Charset = ""
                    .BinaryWrite(MemoryStream.ToArray())

                End With

                HttpContext.Current.ApplicationInstance.CompleteRequest()

                Try

                    HttpContext.Current.Response.End()

                Catch ex As Exception

                End Try

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Function FindNextEmptyCell(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer, ByVal CellNumber As Integer) As Aspose.Cells.Cell

        'objects
        Dim IsEmptyCell As Boolean = False
        Dim Cell As Aspose.Cells.Cell = Nothing

        While IsEmptyCell = False

            Cell = Worksheet.Cells(RowNumber, CellNumber)

            If String.IsNullOrWhiteSpace(Cell.StringValue) Then

                If Not Cell.IsMerged Then

                    IsEmptyCell = True

                End If

            End If

            If IsEmptyCell = False Then

                RowNumber += 1

            End If

        End While

        Return Cell

    End Function
    Private Sub AddReportHeaderToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer, ByVal ReportHeader As String, ByVal HorizontalAlignment As Aspose.Cells.TextAlignmentType)

        'objects
        Dim Cell As Aspose.Cells.Cell = Nothing
        Dim Style As Aspose.Cells.Style = Nothing

        If Worksheet IsNot Nothing Then

            Cell = Worksheet.Cells(RowNumber, 0)

            Cell.Value = ReportHeader
            Worksheet.Cells.Merge(RowNumber, 0, 1, 7)

            Style = Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header1)
            Style.HorizontalAlignment = HorizontalAlignment
            Cell.GetMergedRange().SetStyle(Style)
            Cell.SetStyle(Style)

        End If

    End Sub
    Private Sub AddReportSubtitleToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer, ByVal Subtitle As String)

        'objects
        Dim Cell As Aspose.Cells.Cell = Nothing
        Dim Style As Aspose.Cells.Style = Nothing

        If Worksheet IsNot Nothing Then

            Cell = Worksheet.Cells(RowNumber, 0)

            Cell.Value = Subtitle
            Worksheet.Cells.Merge(RowNumber, 0, 1, 7)

            Style = Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header4)
            Cell.GetMergedRange().SetStyle(Style)

            Cell.SetStyle(Style)

        End If

    End Sub
    Private Sub AddCalendarHeaderToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer, ByVal CalendarDate As Date)

        'objects
        Dim CultureInfo As Globalization.CultureInfo = LoGlo.GetCultureInfo

        If Worksheet IsNot Nothing Then

            Worksheet.Cells(RowNumber, 0).Value = String.Format(CultureInfo, "{0:MMMM yyyy}", CalendarDate)
            Worksheet.Cells.Merge(RowNumber, 0, 1, 7)

            With CultureInfo.DateTimeFormat

                Worksheet.Cells(RowNumber + 1, 0).Value = .DayNames(0)
                Worksheet.Cells(RowNumber + 1, 1).Value = .DayNames(1)
                Worksheet.Cells(RowNumber + 1, 2).Value = .DayNames(2)
                Worksheet.Cells(RowNumber + 1, 3).Value = .DayNames(3)
                Worksheet.Cells(RowNumber + 1, 4).Value = .DayNames(4)
                Worksheet.Cells(RowNumber + 1, 5).Value = .DayNames(5)
                Worksheet.Cells(RowNumber + 1, 6).Value = .DayNames(6)

            End With

            FormatCalendarHeader(Worksheet, RowNumber)

        End If

    End Sub
    Private Sub FormatCalendarHeader(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer)

        'objects
        Dim Style As Aspose.Cells.Style = Nothing
        Dim Cell As Aspose.Cells.Cell = Nothing

        Cell = Worksheet.Cells(RowNumber, 0)

        Style = Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header3)

        With Style

            .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            .VerticalAlignment = Aspose.Cells.TextAlignmentType.Bottom

        End With

        Cell.GetMergedRange().SetStyle(Style)
        Cell.SetStyle(Style)

        For I = 0 To 6

            Cell = Worksheet.Cells(RowNumber + 1, I)

            Style = Cell.GetStyle

            With Style

                .Font.Size = 8
                .Font.IsBold = True
                .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
                .VerticalAlignment = Aspose.Cells.TextAlignmentType.Bottom
                .Pattern = Aspose.Cells.BackgroundType.Solid
                .ForegroundThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Background2, 0)

                .SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Medium, System.Drawing.Color.Black)

                If I <> 6 Then

                    .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, System.Drawing.Color.Black)

                End If

            End With

            Cell.SetStyle(Style)

        Next

    End Sub
    Private Sub BuildDayCell(ByVal Worksheet As Aspose.Cells.Worksheet,
                             ByVal CalendarReport As AdvantageFramework.Reporting.Classes.CalendarReport,
                             ByVal CalendarWorksheet As AdvantageFramework.Reporting.Classes.CalendarReport.Worksheet,
                             ByVal CurrentDate As Date, ByVal RowNumber As Integer, ByVal MaxNumberOfTasks As Integer, ByVal IsDueDateView As Boolean)

        'objects
        Dim Cell As Aspose.Cells.Cell = Nothing
        Dim Style As Aspose.Cells.Style = Nothing
        Dim CalendarItems As Generic.List(Of AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem) = Nothing
        Dim CellsToMerge As Short = Nothing
        Dim RowEndDate As Date = Nothing
        Dim BuiltinStyleType As Aspose.Cells.BuiltinStyleType = Nothing
        Dim CurrentRowNumber As Short = Nothing
        Dim RowsToMerge As Short = Nothing
        Dim CurrentCell As Aspose.Cells.Cell = Nothing

        Cell = Worksheet.Cells(RowNumber, CInt(CurrentDate.DayOfWeek))

        Style = Cell.GetStyle

        Style.Font.Size = 8
        Style.Pattern = Aspose.Cells.BackgroundType.Solid

        Cell.SetStyle(Style)

        If CalendarWorksheet IsNot Nothing Then

            If IsDueDateView Then

                CalendarItems = CalendarWorksheet.CalendarItems.Where(Function(ci) New Date(ci.EndDate.Year, ci.EndDate.Month, ci.EndDate.Day) = CurrentDate).ToList

            Else

                CalendarItems = CalendarWorksheet.CalendarItems.Where(Function(ci) ci.StartDate = CurrentDate).ToList

                If CurrentDate.DayOfWeek = DayOfWeek.Sunday OrElse CurrentDate.Day = 1 Then

                    CalendarItems.AddRange((From Item In CalendarWorksheet.CalendarItems
                                            Let StartDateNoTime = New Date(Item.StartDate.Year, Item.StartDate.Month, Item.StartDate.Day),
                                                EndDateNoTime = New Date(Item.EndDate.Year, Item.EndDate.Month, Item.EndDate.Day)
                                            Where StartDateNoTime < CurrentDate AndAlso
                                                  EndDateNoTime >= CurrentDate AndAlso
                                                  StartDateNoTime <> CurrentDate
                                            Select Item).ToList)

                End If

            End If

            Cell.Value = CurrentDate.Day

            For Each CalendarItem In CalendarItems.OrderByDescending(Function(ci) ci.JobNumber).ThenBy(Function(ci) ci.JobComponentNumber).ThenBy(Function(ci) ci.StartDate)

                Cell = FindNextEmptyCell(Worksheet, RowNumber, CInt(CurrentDate.DayOfWeek))

                RowEndDate = CalendarReport.GetLastDayOfWeekInSameMonth(CurrentDate)

                If RowEndDate > CalendarItem.EndDate Then

                    RowEndDate = CalendarItem.EndDate

                End If

                CellsToMerge = DateDiff(DateInterval.Day, CurrentDate, RowEndDate) + 1

                If CellsToMerge > 1 Then

                    Worksheet.Cells.Merge(Cell.Row, Cell.Column, 1, CellsToMerge)

                End If

                Worksheet.Cells.SetRowHeight(Cell.Row, 14.25)
                Cell.Value = CalendarItem.Description

                Try

                    BuiltinStyleType = [Enum].Parse(GetType(Aspose.Cells.BuiltinStyleType), CalendarItem.Background)

                Catch ex As Exception

                End Try

                If BuiltinStyleType = Aspose.Cells.BuiltinStyleType.TwentyPercentAccent3 Then

                    Style = Cell.GetStyle

                    With Style

                        Style.Font.ThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Text1, 0)
                        Style.ForegroundThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Accent3, 0.8)

                    End With

                Else

                    Style = Worksheet.Workbook.Styles.CreateBuiltinStyle(BuiltinStyleType)

                End If

                Style.Font.Size = 8
                Style.Pattern = Aspose.Cells.BackgroundType.Solid

                Cell.SetStyle(Style)

            Next

        End If

        For Idx = 0 To MaxNumberOfTasks - 1

            CurrentRowNumber = Idx + RowNumber

            CurrentCell = Worksheet.Cells(CurrentRowNumber, CInt(CurrentDate.DayOfWeek))

            Cell = CurrentCell

            While Cell.IsMerged = False AndAlso (String.IsNullOrEmpty(Cell.StringValue) OrElse Cell.Row = RowNumber) AndAlso Cell.Row < (RowNumber + MaxNumberOfTasks)

                Cell = Worksheet.Cells(Cell.Row + 1, Cell.Column)

            End While

            RowsToMerge = (Cell.Row - CurrentRowNumber)

            If RowsToMerge > 1 Then

                Style = CurrentCell.GetStyle

                Style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Right
                Style.VerticalAlignment = Aspose.Cells.TextAlignmentType.Top

                CurrentCell.SetStyle(Style)

                Worksheet.Cells.Merge(Idx + RowNumber, CurrentCell.Column, RowsToMerge, 1)

            End If

            Style = CurrentCell.GetStyle

            Style.SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            Style.SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            Style.SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            Style.SetBorder(Aspose.Cells.BorderType.LeftBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            CurrentCell.SetStyle(Style)

        Next

    End Sub
    Private Sub AddKeyValueToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal Row As Integer, ByVal Column As Integer, ByVal Key As String, ByVal Value As String)

        'objects
        Dim Style As Aspose.Cells.Style = Nothing

        Worksheet.Cells(Row, Column).Value = Key
        Worksheet.Cells(Row, Column + 1).Value = Value

        Style = Worksheet.Cells(Row, Column).GetStyle

        Style.Font.IsBold = True
        Style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Right

        Worksheet.Cells(Row, Column).SetStyle(Style)

    End Sub

    Private Sub RBGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBGroup.SelectedIndexChanged

        Select Case RBGroup.SelectedIndex
            Case 0  'none
                Me.chkSchClient.Enabled = False
                Me.chkStatus.Enabled = False
            Case 1  'cl
                Me.chkSchClient.Enabled = False
                Me.chkStatus.Enabled = False
            Case 2  'cl/div
                Me.chkSchClient.Enabled = False
                Me.chkStatus.Enabled = False
            Case 3  'cl/div/prd
                Me.chkSchClient.Enabled = False
                Me.chkStatus.Enabled = False
            Case 4  'cl/div/prd/job
                Me.chkSchClient.Enabled = False
                Me.chkStatus.Enabled = False
            Case 5  'cl/div/prd/job/comp
                Me.chkSchClient.Enabled = True
                Me.chkStatus.Enabled = True

        End Select

    End Sub
    Private Sub LoadCalendar(ByVal StartDate As Date)

        'objects
        Dim intDaysInMonth As Integer
        Dim strEmpCode As String = ""
        Dim oAppVars As Webvantage.cAppVars = Nothing
        oAppVars.getAllAppVars()
        Dim Dt As New DataTable
        Dim c As New cDayPilot()
        Dim d As String = ""

        Try

            DayPilotMonthReport.StartDate = StartDate

            oAppVars = LoadAppVars()

            Dt = c.GetCalendarData(StartDate.Month,
                                         StartDate.Year,
                                         CStr(Session("UserCode")),
                                         CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                         "0",
                                         oAppVars.getAppVar("tcal_emp"),
                                         oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"),
                                         oAppVars.getAppVar("tcal_div"),
                                         oAppVars.getAppVar("tcal_prod"),
                                         oAppVars.getAppVar("tcal_jobno"),
                                         oAppVars.getAppVar("tcal_jobcomp"),
                                         oAppVars.getAppVar("tcal_roles"),
                                         CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                         oAppVars.getAppVar("tcal_taskstatus"),
                                         CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("rpt_include_tasks", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("rpt_include_assignments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("rpt_include_holidays", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("rpt_include_apppointments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_manager"), Nothing, Nothing,
                                         CType(oAppVars.getAppVar("rpt_include_events", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("rpt_include_event_tasks", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_departs"),
                                         oAppVars.getAppVar("tcal_trafficstatuscode"), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"))


            Session("MonthView") = Dt
            DayPilotMonthReport.DataSource = Dt
            DayPilotMonthReport.DataBind()

            If CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean) = True Then

                Me.DayPilotMonthReport.EventResizeHandling = DayPilot.Web.Ui.Enums.UserActionHandling.PostBack
                Me.DayPilotMonthReport.EventMoveHandling = DayPilot.Web.Ui.Enums.UserActionHandling.PostBack

            Else

                Me.DayPilotMonthReport.EventResizeHandling = DayPilot.Web.Ui.Enums.UserActionHandling.Disabled
                Me.DayPilotMonthReport.EventMoveHandling = DayPilot.Web.Ui.Enums.UserActionHandling.Disabled

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Protected Sub DayPilotMonthReport_TimeRangeSelected(ByVal sender As Object, ByVal e As DayPilot.Web.Ui.Events.TimeRangeSelectedEventArgs)

        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)

        Session("TaskCalendarSelectedDate") = e.Start

        DayPilotMonthReport.DataSource = Session("MonthView")
        DayPilotMonthReport.DataBind()
        DayPilotMonthReport.Update()

    End Sub
    Protected Sub DayPilotMonthReport_BeforeEventRender(ByVal sender As Object, ByVal e As DayPilot.Web.Ui.Events.Month.BeforeEventRenderEventArgs)

        'objects
        Dim EventTextPlain As String = ""
        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
        Dim TextArray() As String = Nothing
        Dim IsNonTask As Integer = 0
        Dim NonTaskType As String = ""
        Dim IsAllDay As Integer = 0
        Dim TaskStatus As String = ""
        Dim dt As DataTable = Nothing
        Dim dt1 As DataTable = Nothing
        Dim HTMLText As String = ""
        Dim dv As DataView = Nothing
        Dim dp As cDayPilot = Nothing

        Try

            TextArray = e.Value.Split("|")

            IsNonTask = CType(TextArray(1), Integer)
            IsAllDay = CType(TextArray(3), Integer)
            TaskStatus = TextArray(4).ToString().Trim()

            NonTaskType = TextArray(2).ToString().Trim()

            If Not Session("MonthView") Is Nothing Then

                dt = CType(Session("MonthView"), DataTable)

            End If

            If Not dt Is Nothing Then

                If dt.Rows.Count > 0 Then

                    dv = New DataView(dt)

                    dv.RowFilter = "DATA_KEY = '" & e.Value & "'"

                    dt1 = dv.ToTable()

                    If Not dt1 Is Nothing Then

                        If dt1.Rows.Count > 0 Then

                            dp = New cDayPilot

                            HTMLText = dp.RenderEvents(dt1, IsNonTask, IsAllDay, False)

                        End If

                    End If

                End If

            End If

            e.InnerHTML = HTMLText
            EventTextPlain = HTMLText.Replace("<strong>", "").Replace("</strong>", "")

            If IsNonTask = 1 Then

                NonTaskType = TextArray(2).ToString().Trim()

                Select Case NonTaskType

                    Case "H"

                        If Me.HfHolidayBackColor.Value <> "" Then

                            e.BackgroundColor = Me.HfHolidayBackColor.Value

                        End If


                        e.InnerHTML = EventTextPlain

                    Case "A"

                        IsAllDay = CType(TextArray(3), Integer)

                        If IsAllDay = 1 Then

                            If Me.HfAppointmentAllDayBackColor.Value <> "" Then

                                e.BackgroundColor = Me.HfAppointmentAllDayBackColor.Value

                            End If

                        Else

                            If Me.HfAppointmentBackColor.Value <> "" Then

                                e.BackgroundColor = Me.HfAppointmentBackColor.Value

                            End If

                        End If

                        e.InnerHTML = EventTextPlain

                    Case Else

                        e.InnerHTML = EventTextPlain

                End Select

            ElseIf IsNonTask = 0 Then

                If Me.HfTaskBackColor.Value <> "" Then

                    e.BackgroundColor = Me.HfTaskBackColor.Value

                End If


                e.InnerHTML = EventTextPlain

            ElseIf IsNonTask = 2 Then

                If IsDBNull(dt1.Rows(0)("AD_NBR_COLOR")) = False Then

                    If dt1.Rows(0)("AD_NBR_COLOR").ToString().Length = 7 Then

                        e.BackgroundColor = dt1.Rows(0)("AD_NBR_COLOR")

                    End If

                Else

                    If Me.HfDefaultEventColor.Value <> "" Then

                        e.BackgroundColor = Me.HfDefaultEventColor.Value

                    End If

                End If

                e.InnerHTML = EventTextPlain

            ElseIf IsNonTask = 3 Then

                If Me.HfDefaultEventTaskColor.Value <> "" Then

                    e.BackgroundColor = Me.HfDefaultEventTaskColor.Value

                End If

                e.InnerHTML = EventTextPlain

            End If

            dt1 = Nothing
            dt = Nothing

        Catch ex As Exception
            e.InnerHTML = ex.Message.ToString()
        End Try

    End Sub
    Private Sub DropDownListReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReportType.SelectedIndexChanged

        If DropDownListReportType.SelectedValue = "1" Then

            Me.FieldsetGroupBy.Visible = False

        Else

            Me.FieldsetGroupBy.Visible = True

        End If

    End Sub
    Private Function getTaskReport(ByVal showtasks As Boolean, ByVal showassignments As Boolean, ByVal showholidays As Boolean, ByVal showappts As Boolean, ByVal showEvents As Boolean, ByVal showEventTasks As Boolean,
                                   Optional ByVal fromapp As String = "", Optional ByVal job As Integer = 0, Optional ByVal comp As Integer = 0,
                                   Optional ByVal sdate As String = "", Optional ByVal edate As String = "", Optional ByVal grouplevel As String = "", Optional ByVal cpid As Integer = 0) As AdvantageFramework.Reporting.Classes.CalendarReport

        Dim startDate, endDate As DateTime
        Dim oAppVars As cAppVars = Nothing

        oAppVars = LoadAppVars()

        startDate = cGlobals.wvCDate(sdate)
        endDate = cGlobals.wvCDate(edate)

        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
        SetSessionDefaults()

        Dim CalendarReport As AdvantageFramework.Reporting.Classes.CalendarReport = Nothing

        If fromapp = "PS" Then
            If grouplevel = 0 Or showtasks = False And (showholidays = True Or showappts = True) Then
                CalendarReport = oCalendar.GetNewTaskCalendarReport(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 grouplevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                             oAppVars.getAppVar("tcal_client"),
                                             oAppVars.getAppVar("tcal_div"),
                                             oAppVars.getAppVar("tcal_prod"),
                                             job,
                                             comp,
                                             oAppVars.getAppVar("tcal_roles"),
                                             CInt(oAppVars.getAppVar("tcal_len", "Number", "50")),
                                             oAppVars.getAppVar("tcal_taskstatus"),
                                             CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                            showtasks,
                                            showassignments,
                                            showholidays,
                                            showappts,
                                            CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                            oAppVars.getAppVar("tcal_manager"), showEvents, showEventTasks, oAppVars.getAppVar("tcal_departs"), Session("CalendaReportPrintApp"), "", CType(oAppVars.getAppVar("tcal_thoursallowed", "Boolean"), Boolean))

            Else
                CalendarReport = oCalendar.GetNewTaskCalendarReportCDPJCGroup3(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 grouplevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                                oAppVars.getAppVar("tcal_client"),
                                                 oAppVars.getAppVar("tcal_div"),
                                                 oAppVars.getAppVar("tcal_prod"),
                                                 job,
                                                 comp,
                                                 oAppVars.getAppVar("tcal_roles"),
                                                 CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                                 oAppVars.getAppVar("tcal_taskstatus"),
                                                 CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                                    showtasks,
                                                    showassignments,
                                                    showholidays,
                                                    showappts,
                                                 CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                                 oAppVars.getAppVar("tcal_manager"), showEvents, showEventTasks, oAppVars.getAppVar("tcal_departs"), Session("CalendaReportPrintApp"), CType(oAppVars.getAppVar("tcal_thoursallowed", "Boolean"), Boolean))
            End If
        Else
            If grouplevel = 0 Or showtasks = False And (showholidays = True Or showappts = True) Then
                CalendarReport = oCalendar.GetNewTaskCalendarReport(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 grouplevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                             oAppVars.getAppVar("tcal_client"),
                                             oAppVars.getAppVar("tcal_div"),
                                             oAppVars.getAppVar("tcal_prod"),
                                             oAppVars.getAppVar("tcal_jobno"),
                                             oAppVars.getAppVar("tcal_jobcomp"),
                                             oAppVars.getAppVar("tcal_roles"),
                                             CInt(oAppVars.getAppVar("tcal_len", "Number", "50")),
                                             oAppVars.getAppVar("tcal_taskstatus"),
                                             CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                            showtasks,
                                            showassignments,
                                            showholidays,
                                            showappts,
                                            CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                            oAppVars.getAppVar("tcal_manager"), showEvents,
                                            showEventTasks, oAppVars.getAppVar("tcal_departs"),
                                            Request.QueryString("FromApp"), Session("TrafficScheduleMVJobs"),
                                            CType(oAppVars.getAppVar("tcal_thoursallowed", "Boolean"), Boolean), CType(oAppVars.getAppVar("tcal_includeunassigned"), Boolean), Session("UserID"), Me.IsClientPortal)

            Else
                CalendarReport = oCalendar.GetNewTaskCalendarReportCDPJCGroup3(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 grouplevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                                oAppVars.getAppVar("tcal_client"),
                                                 oAppVars.getAppVar("tcal_div"),
                                                 oAppVars.getAppVar("tcal_prod"),
                                                 oAppVars.getAppVar("tcal_jobno"),
                                                 oAppVars.getAppVar("tcal_jobcomp"),
                                                 oAppVars.getAppVar("tcal_roles"),
                                                 CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                                 oAppVars.getAppVar("tcal_taskstatus"),
                                                 CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                                    showtasks,
                                                    showassignments,
                                                    showholidays,
                                                    showappts,
                                                 CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                                 oAppVars.getAppVar("tcal_manager"), showEvents, showEventTasks, oAppVars.getAppVar("tcal_departs"), Request.QueryString("FromApp"),
                                                 CType(oAppVars.getAppVar("tcal_thoursallowed", "Boolean"), Boolean), Session("TrafficScheduleMVJobs"), Session("UserID"), Me.IsClientPortal)
            End If
        End If

        Return CalendarReport

    End Function

    Private Sub SetSessionDefaults()
        Dim oAppVars As Webvantage.cAppVars = Nothing

        oAppVars = LoadAppVars()

        'If Session("tcal_len") Is Nothing Then
        '    Session("tcal_len") = "50"
        'End If
        If oAppVars.HasAppVar("tcal_len") = False Then
            oAppVars.setAppVar("tcal_len", "50", "Number")
        End If

        'If Session("tcal_tclientcode") Is Nothing Then
        '    Session("tcal_tclientcode") = True
        'End If
        If oAppVars.HasAppVar("tcal_tclientcode") = False Then
            oAppVars.setAppVar("tcal_tclientcode", "True", "Boolean")
        End If
        'If Session("tcal_tclientdesc") Is Nothing Then
        '    Session("tcal_tclientdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tclientdesc") = False Then
            oAppVars.setAppVar("tcal_tclientdesc", "False", "Boolean")
        End If
        'If Session("tcal_tdivcode") Is Nothing Then
        '    Session("tcal_tdivcode") = True
        'End If
        If oAppVars.HasAppVar("tcal_tdivcode") = False Then
            oAppVars.setAppVar("tcal_tdivcode", "True", "Boolean")
        End If
        'If Session("tcal_tdivdesc") Is Nothing Then
        '    Session("tcal_tdivdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tdivdesc") = False Then
            oAppVars.setAppVar("tcal_tdivdesc", "False", "Boolean")
        End If
        'If Session("tcal_tprodcode") Is Nothing Then
        '    Session("tcal_tprodcode") = True
        'End If
        If oAppVars.HasAppVar("tcal_tprodcode") = False Then
            oAppVars.setAppVar("tcal_tprodcode", "True", "Boolean")
        End If
        'If Session("tcal_tproddesc") Is Nothing Then
        '    Session("tcal_tproddesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tproddesc") = False Then
            oAppVars.setAppVar("tcal_tproddesc", "False", "Boolean")
        End If

        'If Session("tcal_tjobnum") Is Nothing Then
        '    Session("tcal_tjobnum") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobnum") = False Then
            oAppVars.setAppVar("tcal_tjobnum", "False", "Boolean")
        End If
        'If Session("tcal_tjobdesc") Is Nothing Then
        '    Session("tcal_tjobdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobdesc") = False Then
            oAppVars.setAppVar("tcal_tjobdesc", "False", "Boolean")
        End If
        'If Session("tcal_tjobcompnum") Is Nothing Then
        '    Session("tcal_tjobcompnum") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobcompnum") = False Then
            oAppVars.setAppVar("tcal_tjobcompnum", "False", "Boolean")
        End If
        'If Session("tcal_tjobcompdesc") Is Nothing Then
        '    Session("tcal_tjobcompdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobcompdesc") = False Then
            oAppVars.setAppVar("tcal_tjobcompdesc", "False", "Boolean")
        End If
        'If Session("tcal_ttaskcode") Is Nothing Then
        '    Session("tcal_ttaskcode") = False
        'End If
        If oAppVars.HasAppVar("tcal_ttaskcode") = False Then
            oAppVars.setAppVar("tcal_ttaskcode", "False", "Boolean")
        End If
        'If Session("tcal_ttaskdesc") Is Nothing Then
        '    Session("tcal_ttaskdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_ttaskdesc") = False Then
            oAppVars.setAppVar("tcal_ttaskdesc", "False", "Boolean")
        End If
        'If Session("tcal_haemployeecode") Is Nothing Then
        '    Session("tcal_haemployeecode") = False
        'End If
        If oAppVars.HasAppVar("tcal_haemployeecode") = False Then
            oAppVars.setAppVar("tcal_haemployeecode", "False", "Boolean")
        End If
        'If Session("tcal_haemployeedesc") Is Nothing Then
        '    Session("tcal_haemployeedesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_haemployeedesc") = False Then
            oAppVars.setAppVar("tcal_haemployeedesc", "False", "Boolean")
        End If
        'If Session("tcal_hasubject") Is Nothing Then
        '    Session("tcal_hasubject") = False
        'End If
        If oAppVars.HasAppVar("tcal_hasubject") = False Then
            oAppVars.setAppVar("tcal_hasubject", "False", "Boolean")
        End If
        'If Session("tcal_hatimes") Is Nothing Then
        '    Session("tcal_hatimes") = False
        'End If
        If oAppVars.HasAppVar("tcal_hatimes") = False Then
            oAppVars.setAppVar("tcal_hatimes", "False", "Boolean")
        End If
        'If Session("tcal_hahours") Is Nothing Then
        '    Session("tcal_hahours") = False
        'End If
        If oAppVars.HasAppVar("tcal_hahours") = False Then
            oAppVars.setAppVar("tcal_hahours", "False", "Boolean")
        End If
        'If Session("tcal_hatimecat") Is Nothing Then
        '    Session("tcal_hatimecat") = False
        'End If
        If oAppVars.HasAppVar("tcal_hatimecat") = False Then
            oAppVars.setAppVar("tcal_hatimecat", "False", "Boolean")
        End If
        'If Session("tcal_milestone") Is Nothing Then
        '    Session("tcal_milestone") = False
        'End If
        If oAppVars.HasAppVar("tcal_milestone") = False Then
            oAppVars.setAppVar("tcal_milestone", "False", "Boolean")
        End If
        'If Session("tcal_empcodedispl") Is Nothing Then
        '    Session("tcal_empcodedispl") = False
        'End If
        If oAppVars.HasAppVar("tcal_empcodedispl") = False Then
            oAppVars.setAppVar("tcal_empcodedispl", "False", "Boolean")
        End If
        'If Session("tcal_empdescdispl") Is Nothing Then
        '    Session("tcal_empdescdispl") = False
        'End If
        If oAppVars.HasAppVar("tcal_empdescdispl") = False Then
            oAppVars.setAppVar("tcal_empdescdispl", "False", "Boolean")
        End If
        'If Session("show_client") Is Nothing Then
        '    Session("show_client") = True
        'End If
        If oAppVars.HasAppVar("show_client") = False Then
            oAppVars.setAppVar("show_client", "True", "Boolean")
        End If


        'If Session("tcal_office") Is Nothing Then
        '    Session("tcal_office") = ""
        'End If
        If oAppVars.HasAppVar("tcal_office") = False Then
            oAppVars.setAppVar("tcal_office", "")
        End If

        'If Session("tcal_client") Is Nothing Then
        '    Session("tcal_client") = ""
        'End If
        If oAppVars.HasAppVar("tcal_client") = False Then
            oAppVars.setAppVar("tcal_client", "")
        End If

        'If Session("tcal_div") Is Nothing Then
        '    Session("tcal_div") = ""
        'End If
        If oAppVars.HasAppVar("tcal_div") = False Then
            oAppVars.setAppVar("tcal_div", "")
        End If

        'If Session("tcal_prod") Is Nothing Then
        '    Session("tcal_prod") = ""
        'End If
        If oAppVars.HasAppVar("tcal_prod") = False Then
            oAppVars.setAppVar("tcal_prod", "")
        End If

        'If Session("tcal_jobno") Is Nothing Then
        '    Session("tcal_jobno") = ""
        'End If
        If oAppVars.HasAppVar("tcal_jobno") = False Then
            oAppVars.setAppVar("tcal_jobno", "")
        End If

        'If Session("tcal_jobcomp") Is Nothing Then
        '    Session("tcal_jobcomp") = ""
        'End If
        If oAppVars.HasAppVar("tcal_jobcomp") = False Then
            oAppVars.setAppVar("tcal_jobcomp", "")
        End If

        'If Session("tcal_role") Is Nothing Then
        '    Session("tcal_role") = ""
        'End If
        If oAppVars.HasAppVar("tcal_roles") = False Then
            oAppVars.setAppVar("tcal_roles", "")
        End If

        'If Session("tcal_taskstatus") Is Nothing Then
        '    Session("tcal_taskstatus") = ""
        'End If
        If oAppVars.HasAppVar("tcal_taskstatus") = False Then
            oAppVars.setAppVar("tcal_taskstatus", "")
        End If

        If oAppVars.HasAppVar("tcal_manager") = False Then
            oAppVars.setAppVar("tcal_manager", "")
        End If

        If oAppVars.HasAppVar("tcal_excludetempcomplete") = False Then
            oAppVars.setAppVar("tcal_excludetempcomplete", "False", "Boolean")
        End If

        If oAppVars.HasAppVar("tcal_duration") = False Then
            oAppVars.setAppVar("tcal_duration", "False", "Boolean")
        End If

        oAppVars.SaveAllAppVars()


    End Sub
    Private Sub SaveReportAppVars()

        Dim AppVars As Webvantage.cAppVars = Nothing

        AppVars = LoadAppVars()

        AppVars.setAppVar("rpt_location_id", ddLocation.SelectedValue)
        AppVars.setAppVar("rpt_title", TBTitle.Text)
        AppVars.setAppVar("rpt_title_placement", rbplacement.SelectedIndex)
        AppVars.setAppVar("rpt_group_by", RBGroup.SelectedIndex)
        AppVars.setAppVar("rpt_include_schedule_comment", chkSchClient.Checked)
        AppVars.setAppVar("rpt_include_status", chkStatus.Checked)
        AppVars.setAppVar("rpt_include_tasks", chkTasks.Checked)
        AppVars.setAppVar("rpt_include_assignments", chkAssignments.Checked)
        AppVars.setAppVar("rpt_include_holidays", chkHolidays.Checked)
        AppVars.setAppVar("rpt_include_appointments", chkAppts.Checked)
        AppVars.setAppVar("rpt_include_events", chkEvents.Checked)
        AppVars.setAppVar("rpt_include_event_tasks", chkEventTasks.Checked)

        AppVars.SaveAllAppVars()

    End Sub

End Class
