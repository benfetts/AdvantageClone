Imports Telerik.Web.UI

Public Class JobForecast_Main
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get
            If _DbContext Is Nothing Then
                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DbContext
        End Get
    End Property
    Private ReadOnly Property CanUserAdd As Boolean
        Get
            If ViewState("JF_CanUserAdd") Is Nothing Then
                ViewState("JF_CanUserAdd") = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserAdd")
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub SaveCookieInformation()

        Response.Cookies("JFMainPageSettings")("MonthYear") = RadMonthYearPicker.DbSelectedDate
        Response.Cookies("JFMainPageSettings")("EmployeeCode") = RadComboBoxEmployee.SelectedValue
        Response.Cookies("JFMainPageSettings").Expires = Now.AddMonths(1)

    End Sub
    Private Sub CheckUserRights()

        If Not Me.CanUserAdd Then

            DisableMenuItem(RadToolBarButtonNew)

        End If

    End Sub
    Private Sub DisableMenuItem(ByVal RadToolBarItem As Telerik.Web.UI.RadToolBarItem)

        With RadToolBarItem

            .Enabled = False

            If TypeOf RadToolBarItem Is Telerik.Web.UI.RadToolBarButton Then

                With DirectCast(RadToolBarItem, Telerik.Web.UI.RadToolBarButton)

                    .Value = Nothing
                    .CommandName = Nothing

                End With

            End If

        End With

    End Sub

#Region "  Form Event Handlers "

    Private Sub JobForecast_Main_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        With QueryString

            _JobNumber = .JobNumber
            _JobComponentNumber = .JobComponentNumber

        End With

    End Sub
    Private Sub JobForecast_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)

                If _JobNumber <= 0 AndAlso _JobComponentNumber <= 0 Then

                    RadComboBoxEmployee.DataSource = (From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(Me.DbContext, SecurityDbContext, _Session.User.UserCode, _Session.User.EmployeeCode).ToList
                                                      Join ForecastEmp In AdvantageFramework.Database.Procedures.JobForecast.Load(Me.DbContext).Select(Function(jf) jf.AssignedToEmployeeCode).Distinct.ToList On Item.Code Equals ForecastEmp
                                                      Select New With {.Code = Item.Code,
                                                                      .Name = Item.ToString}).ToList
                    RadComboBoxEmployee.DataBind()
                    RadComboBoxEmployee.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    If Request.Cookies("JFMainPageSettings") Is Nothing Then

                        RadMonthYearPicker.SelectedDate = cEmployee.TimeZoneToday

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, Session("empcode").ToString())

                        If Employee IsNot Nothing Then

                            RadComboBoxEmployee.SelectedValue = Employee.Code

                        End If

                        SaveCookieInformation()

                    Else

                        RadMonthYearPicker.DbSelectedDate = Request.Cookies("JFMainPageSettings")("MonthYear")
                        RadComboBoxEmployee.SelectedValue = Request.Cookies("JFMainPageSettings")("EmployeeCode")

                    End If

                Else

                    SearchDiv.Visible = False
                    RadMonthYearPicker.Visible = False
                    RadComboBoxEmployee.Visible = False

                End If

            End Using

            RadGridJobForecasts.PageSize = MiscFN.LoadPageSize(RadGridJobForecasts.ID)

            RadGridJobForecasts.Rebind()

        End If

        CheckUserRights()

    End Sub
    Private Sub JobForecast_Main_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()

                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()

                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadMonthYearPicker_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadMonthYearPicker.SelectedDateChanged

        SaveCookieInformation()

        RadGridJobForecasts.Rebind()

    End Sub
    Private Sub RadComboBoxEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBoxEmployee.SelectedIndexChanged

        SaveCookieInformation()

        RadGridJobForecasts.Rebind()

    End Sub
    Private Sub RadToolBarJobForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobForecast.ButtonClick

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        QueryString = QueryString.FromCurrent()

        Select Case e.Item.Value

            Case "New"

                QueryString.Page = "JobForecast_New.aspx"

                Me.OpenWindow(QueryString, "Job Forecast Details", 600, 950, False, False)

            Case "Settings"

                Me.OpenWindow("Job Forecast Settings", "JobForecast_Settings.aspx", 500, 625, False, True)

            Case "Refresh"

                Me.Response.Redirect("JobForecast_Main.aspx")

            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                qs.Page = "JobForecast_Main.aspx"
                qs.Add("bm", "1")

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_JobForecast
                    .UserCode = Session("UserCode")
                    .Name = "Job Forecast"
                    .Description = "Job Forecast"
                    .PageURL = qs.ToString(True)

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    ' Me.RefreshBookmarksDesktopObject()

                End If

        End Select

    End Sub
    Private Sub RadGridJobForecasts_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobForecasts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim JobForecastRevisionID As Integer = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridJobForecasts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "View"

                If CurrentGridDataItem IsNot Nothing Then

                    JobForecastRevisionID = CInt(CurrentGridDataItem.GetDataKeyValue("JobForecastRevisionID"))

                    Me.OpenWindow("Job Forecast Details", [String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", JobForecastRevisionID))

                End If

        End Select

    End Sub
    Private Sub RadGridJobForecasts_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobForecasts.NeedDataSource

        Try

            RadGridJobForecasts.DataSource = AdvantageFramework.JobForecast.LoadCurrentJobForecasts(Me.DbContext, RadComboBoxEmployee.SelectedValue, _JobNumber, _JobComponentNumber, RadMonthYearPicker.SelectedDate, _Session.UserCode).OrderBy(Function(item) item.PostPeriodStartDate).ThenByDescending(Function(item) item.CreatedDate).ToList

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridJobForecasts_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridJobForecasts.PageSizeChanged

        MiscFN.SavePageSize(RadGridJobForecasts.ID, e.NewPageSize)

    End Sub

#End Region

#End Region

End Class
