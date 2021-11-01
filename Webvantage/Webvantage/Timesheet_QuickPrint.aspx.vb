Imports Webvantage.wvTimeSheet

Public Class Timesheet_QuickPrint
    Inherits Webvantage.BaseChildPage

    Public MonTotal As String
    Public TueTotal As String
    Public WedTotal As String
    Public ThuTotal As String
    Public FriTotal As String
    Public SatTotal As String
    Public SunTotal As String
    Public TotalHours As String
    Public EmpName As String
    Private _StartDate As Date
    Private _EndDate As Date
    Private _HasProductCategory As Boolean

    Private ReadOnly Property StartWeekOn As DayOfWeek
        Get

            If ViewState("StartWeekOn") Is Nothing OrElse String.IsNullOrWhiteSpace(ViewState("StartWeekOn")) = True Then

                Try

                    Dim _MvcController As AdvantageFramework.Controller.Employee.TimesheetMvcController = Nothing
                    _MvcController = New AdvantageFramework.Controller.Employee.TimesheetMvcController(Me.SecuritySession)
                    Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        UserSettings = _MvcController.GetUserSettings(DbContext)

                    End Using

                    ViewState("StartWeekOn") = UserSettings.StartTimesheetOnDayOfWeek

                Catch ex As Exception
                    ViewState("StartWeekOn") = DayOfWeek.Sunday
                End Try

            End If

            Return CType(ViewState("StartWeekOn"), DayOfWeek)

        End Get

    End Property
    Private ReadOnly Property DaysToShow As Integer
        Get

            If ViewState("DaysToDisplay") Is Nothing OrElse String.IsNullOrWhiteSpace(ViewState("DaysToDisplay")) = True Then

                Try

                    Dim _MvcController As AdvantageFramework.Controller.Employee.TimesheetMvcController = Nothing
                    _MvcController = New AdvantageFramework.Controller.Employee.TimesheetMvcController(Me.SecuritySession)
                    Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        UserSettings = _MvcController.GetUserSettings(DbContext)

                    End Using

                    ViewState("DaysToDisplay") = UserSettings.DaysToDisplay

                Catch ex As Exception
                    ViewState("DaysToDisplay") = 7
                End Try

            End If

            Return CType(ViewState("DaysToDisplay"), Integer)

        End Get

    End Property

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet)

        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        If oSec.CheckEmployees(Session("UserCode"), Request.QueryString("empcode")) = False Then
            Server.Transfer("NoAccess.aspx")
        End If

        Dim ots As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        If ots.UserLimited(Session("UserCode")) = True And (Request.QueryString("empcode").ToString() <> Session("EmpCode").ToString()) Then
            Server.Transfer("NoAccess.aspx")
        End If

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadTimeSheet()
                End If
            End If

            If Request.QueryString("ExcludeEmployeeSignature") IsNot Nothing AndAlso Request.QueryString("ExcludeEmployeeSignature") = "0" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session("EmpCode"))

                    If Employee IsNot Nothing AndAlso Employee.SignatureImage IsNot Nothing Then

                        RadBinaryImageEmployeeSignature.DataValue = Employee.SignatureImage.ToArray
                        RadBinaryImageEmployeeSignature.Visible = True
                        LabelDate.Text = Now.ToShortDateString
                        LabelDate.Visible = True

                    Else

                        RadBinaryImageEmployeeSignature.DataValue = Nothing
                        RadBinaryImageEmployeeSignature.Visible = False
                        LabelDate.Text = ""
                        LabelDate.Visible = False

                    End If

                End Using

            Else

                RadBinaryImageEmployeeSignature.DataValue = Nothing
                RadBinaryImageEmployeeSignature.Visible = False
                LabelDate.Text = ""
                LabelDate.Visible = False

            End If

        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub
    Private Function ShowHours(ByRef ThisDay As AdvantageFramework.Timesheet.TimesheetEntry) As String
        If Not ThisDay Is Nothing Then
            Return FormatNumber(ThisDay.Hours, 2)
        Else
            Return "0.00"
        End If
    End Function
    Private Sub LoadTimeSheet()

        Dim oEmp As cEmployee = New cEmployee(CStr(Session("ConnString")))
        Dim ts As New cTimeSheet(_Session.ConnectionString)
        Dim ThisTimeSheet As AdvantageFramework.Timesheet.TimeSheet
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

        Me._HasProductCategory = ovisible.ProductCategoryVisible()

        EmpName = oEmp.GetName(Request.QueryString("empcode"))
        'ts.GetDateRange(CDate(Request.QueryString("tsdate")), _StartDate, _EndDate)
        If Not Request.QueryString("tsdate") Is Nothing Then

            _StartDate = CType(Request.QueryString("tsdate"), Date)

        Else

            _StartDate = Date.Today

        End If

        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            UserSettings = AdvantageFramework.EmployeeTimesheet.GetUserSettings(DbContext)

        End Using
        If UserSettings IsNot Nothing Then

            _StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(_StartDate, UserSettings, UserSettings.DaysToDisplay)

        End If
        If Me.DaysToShow = 5 Then

            If Me.StartWeekOn = DayOfWeek.Sunday Then

                _StartDate = DateAdd(DateInterval.Day, -1, _StartDate)

            ElseIf Me.StartWeekOn = DayOfWeek.Saturday Then

                _StartDate = DateAdd(DateInterval.Day, -2, _StartDate)

            End If

        End If

        _EndDate = DateAdd(DateInterval.Day, 6, _StartDate)

        ThisTimeSheet = AdvantageFramework.Timesheet.GetTimeSheet(Session("ConnString"), Session("UserCode"),
                                                                  Request.QueryString("empcode"), _StartDate,
                                                                  _EndDate, Request.QueryString("sortkey"))

        Select Case Me.StartWeekOn
            Case DayOfWeek.Saturday

                SunTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Saturday), 2)
                MonTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Sunday), 2)
                TueTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Monday), 2)
                WedTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Tuesday), 2)
                ThuTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Wednesday), 2)
                FriTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Thursday), 2)
                SatTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Friday), 2)

            Case DayOfWeek.Sunday

                SunTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Sunday), 2)
                MonTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Monday), 2)
                TueTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Tuesday), 2)
                WedTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Wednesday), 2)
                ThuTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Thursday), 2)
                FriTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Friday), 2)
                SatTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Saturday), 2)

            Case DayOfWeek.Monday

                SunTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Monday), 2)
                MonTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Tuesday), 2)
                TueTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Wednesday), 2)
                WedTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Thursday), 2)
                ThuTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Friday), 2)
                FriTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Saturday), 2)
                SatTotal = FormatNumber(ThisTimeSheet.GetTotalHoursByDay(DayOfWeek.Sunday), 2)

        End Select

        TotalHours = FormatNumber(ThisTimeSheet.GetTotalHours, 2)

        Me.repTimeSheet.DataSource = ThisTimeSheet
        Me.repTimeSheet.DataBind()

    End Sub

    Private Function CheckProductCategory() As Boolean

        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Return ovisible.ProductCategoryVisible()

    End Function

    Private Sub repTimeSheet_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repTimeSheet.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Header

                Dim SettingsMethods As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))
                Dim Settings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                Dim s As String = ""

                Settings = SettingsMethods.GetSettings(Session("UserCode"), s)

                If Settings Is Nothing Then

                    Me.ShowMessage(s)

                Else

                    CType(e.Item.FindControl("LabelDivision"), Label).Text = Settings.Labels.Division
                    CType(e.Item.FindControl("LabelProduct"), Label).Text = Settings.Labels.Product
                    CType(e.Item.FindControl("LabelJob"), Label).Text = Settings.Labels.Job
                    CType(e.Item.FindControl("LabelJobComponent"), Label).Text = Settings.Labels.JobComponent
                    CType(e.Item.FindControl("LabelFuncCat"), Label).Text = Settings.Labels.FuncCat

                    Try

                        CType(e.Item.FindControl("LabelSunHeader"), Label).Text = Me._StartDate.DayOfWeek.ToString().Substring(0, 3)
                        CType(e.Item.FindControl("LabelMonHeader"), Label).Text = Me._StartDate.AddDays(1).DayOfWeek.ToString().Substring(0, 3)
                        CType(e.Item.FindControl("LabelTueHeader"), Label).Text = Me._StartDate.AddDays(2).DayOfWeek.ToString().Substring(0, 3)
                        CType(e.Item.FindControl("LabelWedHeader"), Label).Text = Me._StartDate.AddDays(3).DayOfWeek.ToString().Substring(0, 3)
                        CType(e.Item.FindControl("LabelThuHeader"), Label).Text = Me._StartDate.AddDays(4).DayOfWeek.ToString().Substring(0, 3)
                        CType(e.Item.FindControl("LabelFriHeader"), Label).Text = Me._StartDate.AddDays(5).DayOfWeek.ToString().Substring(0, 3)
                        CType(e.Item.FindControl("LabelSatHeader"), Label).Text = Me._StartDate.AddDays(6).DayOfWeek.ToString().Substring(0, 3)

                    Catch ex As Exception

                    End Try

                End If

                Dim HeaderLiteral As Literal = e.Item.FindControl("LiteralHeader")
                HeaderLiteral.Text = String.Format("Timesheet for {0} ({1} - {2})", Me.EmpName, Me._StartDate.ToShortDateString, Me._EndDate.ToShortDateString)

                If Me._HasProductCategory = False Then

                    Dim ProductCategoryTd As HtmlControls.HtmlTableCell = e.Item.FindControl("TdProdCatHeader")
                    ProductCategoryTd.Visible = False

                End If

            Case ListItemType.Item, ListItemType.AlternatingItem

                Dim TimesheetRow As AdvantageFramework.Timesheet.TimesheetLine
                Dim SundayLiteral As Literal = e.Item.FindControl("LiteralSunday")
                Dim MondayLiteral As Literal = e.Item.FindControl("LiteralMonday")
                Dim TuesdayLiteral As Literal = e.Item.FindControl("LiteralTuesday")
                Dim WednesdayLiteral As Literal = e.Item.FindControl("LiteralWednesday")
                Dim ThursdayLiteral As Literal = e.Item.FindControl("LiteralThursday")
                Dim FridayLiteral As Literal = e.Item.FindControl("LiteralFriday")
                Dim SaturdayLiteral As Literal = e.Item.FindControl("LiteralSaturday")

                TimesheetRow = e.Item.DataItem

                Select Case Me.StartWeekOn
                    Case DayOfWeek.Saturday

                        SundayLiteral.Text = ShowHours(TimesheetRow.Saturday)
                        MondayLiteral.Text = ShowHours(TimesheetRow.Sunday)
                        TuesdayLiteral.Text = ShowHours(TimesheetRow.Monday)
                        WednesdayLiteral.Text = ShowHours(TimesheetRow.Tuesday)
                        ThursdayLiteral.Text = ShowHours(TimesheetRow.Wednesday)
                        FridayLiteral.Text = ShowHours(TimesheetRow.Thursday)
                        SaturdayLiteral.Text = ShowHours(TimesheetRow.Friday)

                    Case DayOfWeek.Sunday

                        SundayLiteral.Text = ShowHours(TimesheetRow.Sunday)
                        MondayLiteral.Text = ShowHours(TimesheetRow.Monday)
                        TuesdayLiteral.Text = ShowHours(TimesheetRow.Tuesday)
                        WednesdayLiteral.Text = ShowHours(TimesheetRow.Wednesday)
                        ThursdayLiteral.Text = ShowHours(TimesheetRow.Thursday)
                        FridayLiteral.Text = ShowHours(TimesheetRow.Friday)
                        SaturdayLiteral.Text = ShowHours(TimesheetRow.Saturday)

                    Case DayOfWeek.Monday

                        SundayLiteral.Text = ShowHours(TimesheetRow.Monday)
                        MondayLiteral.Text = ShowHours(TimesheetRow.Tuesday)
                        TuesdayLiteral.Text = ShowHours(TimesheetRow.Wednesday)
                        WednesdayLiteral.Text = ShowHours(TimesheetRow.Thursday)
                        ThursdayLiteral.Text = ShowHours(TimesheetRow.Friday)
                        FridayLiteral.Text = ShowHours(TimesheetRow.Saturday)
                        SaturdayLiteral.Text = ShowHours(TimesheetRow.Sunday)

                End Select

                If Me._HasProductCategory = False Then

                    Dim ProductCategoryTd As HtmlControls.HtmlTableCell = e.Item.FindControl("TdProdCat")
                    ProductCategoryTd.Visible = False

                End If

            Case ListItemType.Footer

                Dim TotalsTd As HtmlControls.HtmlTableCell = e.Item.FindControl("TdTotals")
                TotalsTd.Attributes.Remove("colspan")

                If Me._HasProductCategory = False Then

                    TotalsTd.Attributes.Add("colspan", "7")

                Else

                    TotalsTd.Attributes.Add("colspan", "8")

                End If

        End Select

    End Sub

End Class
