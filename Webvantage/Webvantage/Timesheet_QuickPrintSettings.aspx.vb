Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI

Public Class Timesheet_QuickPrintSettings
    Inherits Webvantage.BaseChildPage

    Private VendorCode As String = ""
    Private VendorName As String = ""
    Private MediaType As String = ""
    Private StartDate As Date = Nothing
    Private EndDate As Date = Nothing

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet)

        'printSetup()
        If Not Me.IsPostBack Then


            Me.SetRadDatePicker(Me.RadDatePickerStartDate)
            Me.SetRadDatePicker(Me.RadDatePickerEndDate)
            Me.pnlDates.Visible = False

            Me.SetStartAndEndDates()

            Me.RadDatePickerStartDate.SelectedDate = StartDate
            Me.RadDatePickerEndDate.SelectedDate = EndDate

            Me.LoadSort()

        End If

    End Sub
    Private Sub SetStartAndEndDates()

        Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

        If Not Request.QueryString("tsdate") Is Nothing Then

            StartDate = CType(Request.QueryString("tsdate"), Date)

        Else

            StartDate = Date.Today

        End If
        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            UserSettings = AdvantageFramework.EmployeeTimesheet.GetUserSettings(DbContext)

        End Using
        If UserSettings IsNot Nothing Then

            StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, UserSettings.DaysToDisplay)

        End If

        EndDate = DateAdd(DateInterval.Day, UserSettings.DaysToDisplay - 1, StartDate)

    End Sub

    Private Sub butPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butPrint.Click
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        If oSec.CheckEmployees(Session("UserCode"), Request.QueryString("empcode")) = False Then
            Me.ShowMessage("Access to this employee (" & Request.QueryString("empcode") & ") is not allowed")
            Exit Sub
        End If
        Dim ots As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        If ots.UserLimited(Session("UserCode")) = True And (Request.QueryString("empcode").ToString() <> Session("EmpCode").ToString()) Then
            Me.ShowMessage("Access to this employee (" & Request.QueryString("empcode") & ") is not allowed")
            Exit Sub
        End If

        'objects
        Dim lExcludeEmployeeSignature As Long = 0

        Try
            If Me.rbSummary.Checked = True Then

                Me.SetStartAndEndDates()

            End If
            If Me.rbDetail.Checked = True Then

                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then

                    Me.ShowMessage("Invalid Start date")
                    Exit Sub

                Else

                    Me.StartDate = Me.RadDatePickerStartDate.SelectedDate

                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then

                    Me.ShowMessage("Invalid End date")
                    Exit Sub

                Else

                    Me.EndDate = Me.RadDatePickerEndDate.SelectedDate

                End If
            End If

            MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate, True)

            Dim strURL As String

            If CheckBoxExcludeEmployeeSignature.Checked Then

                lExcludeEmployeeSignature = 1

            Else

                lExcludeEmployeeSignature = 0

            End If

            If Me.rbDetail.Checked = True Then

                strURL = "popReportViewer.aspx?empcode=" & Request.QueryString("empcode") & "&startdate=" & Me.StartDate.ToShortDateString() & "&enddate=" &
                        Me.EndDate.ToShortDateString() & "&sortkey=" & Me.RadComboBoxSort.SelectedValue & "&Type=1&Report=timesheetprint" &
                        "&ExcludeEmployeeSignature=" & lExcludeEmployeeSignature & "&UserCode=" & Session("EmpCode")

                Response.Redirect(strURL)

            ElseIf Me.rbSummary.Checked = True Then

                strURL = "Timesheet_QuickPrint.aspx?empcode=" & Request.QueryString("empcode") & "&tsdate=" & Me.StartDate.ToShortDateString() &
                        "&sortkey=" & Me.RadComboBoxSort.SelectedValue & "&ExcludeEmployeeSignature=" & lExcludeEmployeeSignature

                Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

                strBuilder.Append("<script language='javascript'>")
                strBuilder.Append("window.open('" & strURL & "', 'timesheetQuickPrint', 'menubar=no,scrollbars=yes,resizable=yes,maximazable=yes')")
                strBuilder.Append("</")
                strBuilder.Append("script>")

                Page.RegisterStartupScript("newpage2", strBuilder.ToString())

            End If

        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try

    End Sub

    Private Sub rbDetail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDetail.CheckedChanged
        If Me.rbDetail.Checked Then
            Me.pnlDates.Visible = True
        End If
    End Sub

    Private Sub rbSummary_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSummary.CheckedChanged
        If Me.rbSummary.Checked = True Then
            Me.pnlDates.Visible = False
        End If
    End Sub

    Private Sub LoadSort()

        Dim DaysToShow As Integer = 0
        Dim StartWeekOn As String = ""
        Dim ShowCommentUsing As String = ""
        Dim DivisionLabel As String = ""
        Dim ProductLabel As String = ""
        Dim ProductCategoryLabel As String = ""
        Dim JobLabel As String = ""
        Dim JobComponentLabel As String = ""
        Dim FunctionCategoryLabel As String = ""

        Dim c As New cTimeSheet(Session("ConnString"))
        Dim s As String = ""
        Me.RadComboBoxSort.Items.Clear()
        Me.RadComboBoxSort.Items.Add(New RadComboBoxItem("[None]", AdvantageFramework.Timesheet.TimesheetSort.NewestFirst))
        Me.RadComboBoxSort.Items.Add(New RadComboBoxItem("Client", AdvantageFramework.Timesheet.TimesheetSort.Client))
        If c.GetTimesheetSettings(Session("UserCode"), DaysToShow, StartWeekOn, ShowCommentUsing,
                        DivisionLabel, ProductLabel, ProductCategoryLabel, JobLabel, JobComponentLabel, FunctionCategoryLabel, s) = True Then
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem(DivisionLabel, AdvantageFramework.Timesheet.TimesheetSort.Division))
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem(ProductLabel, AdvantageFramework.Timesheet.TimesheetSort.Product))
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem(JobLabel & "/" & JobComponentLabel, AdvantageFramework.Timesheet.TimesheetSort.JobComponent))
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem(FunctionCategoryLabel, AdvantageFramework.Timesheet.TimesheetSort.FunctionCategory))
        Else
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem("Division", AdvantageFramework.Timesheet.TimesheetSort.Division))
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem("Product", AdvantageFramework.Timesheet.TimesheetSort.Product))
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem("Job/Job Comp", AdvantageFramework.Timesheet.TimesheetSort.JobComponent))
            Me.RadComboBoxSort.Items.Add(New RadComboBoxItem("Function/Category", AdvantageFramework.Timesheet.TimesheetSort.FunctionCategory))
        End If

        Me.RadComboBoxSort.Items.Add(New RadComboBoxItem("Department", AdvantageFramework.Timesheet.TimesheetSort.DepartmentTeam))

    End Sub



End Class
