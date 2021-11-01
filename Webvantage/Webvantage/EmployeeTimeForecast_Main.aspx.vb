Public Class EmployeeTimeForecast_Main
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub SaveCookieInformation()

        Response.Cookies("ETFMainPageSettings")("PostPeriod") = DropDownListPostPeriod.SelectedValue
        Response.Cookies("ETFMainPageSettings")("OfficeCode") = DropDownListOffice.SelectedValue
        Response.Cookies("ETFMainPageSettings")("EmployeeCode") = DropDownListEmployee.SelectedValue
        Response.Cookies("ETFMainPageSettings").Expires = Now.AddMonths(1)

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing


        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecast)

                RadToolBarButtonSettings.Enabled = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastSettings, False) = 1

                RadToolBarButtonComparisonDashboard.Enabled = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastComparisonDashboard, False) = 1

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                DropDownListPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                                                                                                                                             .Description = Entity.Code & " - " & Entity.Description}).ToList
                DropDownListPostPeriod.DataBind()
                DropDownListPostPeriod.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

                If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                    DropDownListOffice.DataSource = From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                                    Where UserEmployeeOfficeList.Any(Function(UsrOfficeAccess) UsrOfficeAccess.OfficeCode = Entity.Code) = True
                                                    Select [Code] = Entity.Code,
                                                      [Name] = Entity.ToString()

                Else

                    DropDownListOffice.DataSource = From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                                    Select [Code] = Entity.Code,
                                                      [Name] = Entity.ToString()

                End If
                'DropDownListOffice.DataSource = AdvantageFramework.Database.Procedures.Office.Load(DbContext).OrderBy(Function(Office) Office.Name)
                DropDownListOffice.DataBind()
                DropDownListOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then

                    DropDownListEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(DbContext, _Session.User.EmployeeCode).ToList.
                                                            Select(Function(ActiveEmployee) New With {.Code = ActiveEmployee.Code,
                                                                                                      .Name = ActiveEmployee.ToString})

                Else

                    DropDownListEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList.
                                                            Select(Function(ActiveEmployee) New With {.Code = ActiveEmployee.Code,
                                                                                                      .Name = ActiveEmployee.ToString})

                End If


                DropDownListEmployee.DataBind()
                DropDownListEmployee.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                If Request.Cookies("ETFMainPageSettings") Is Nothing Then

                    If PostPeriod IsNot Nothing Then

                        DropDownListPostPeriod.SelectedValue = PostPeriod.Code

                    Else

                        DropDownListPostPeriod.SelectedValue = String.Empty

                    End If

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session("empcode").ToString())

                    If Employee IsNot Nothing Then

                        DropDownListOffice.SelectedValue = Employee.OfficeCode
                        DropDownListEmployee.SelectedValue = Employee.Code

                    End If

                    SaveCookieInformation()

                Else

                    DropDownListPostPeriod.SelectedValue = Request.Cookies("ETFMainPageSettings")("PostPeriod")
                    DropDownListOffice.SelectedValue = Request.Cookies("ETFMainPageSettings")("OfficeCode")
                    DropDownListEmployee.SelectedValue = Request.Cookies("ETFMainPageSettings")("EmployeeCode")

                End If

                RadGridEmployeeTimeForecastOfficeDetails.Rebind()

            End Using
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    RadGridEmployeeTimeForecastOfficeDetails.Rebind()
            End Select
        End If

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ShowInactive As Integer = 0

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridEmployeeTimeForecastOfficeDetails AndAlso (eventArgument.IndexOf("EmployeeTimeForecastOfficeDetailID") <> -1) Then

            'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", Integer.Parse(eventArgument.Split(":"c)(1))))
            Me.OpenWindow("Employee Time Forecast Details", [String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", Integer.Parse(eventArgument.Split(":"c)(1))))
        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub DropDownListPostPeriod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPostPeriod.SelectedIndexChanged

        SaveCookieInformation()

        RadGridEmployeeTimeForecastOfficeDetails.Rebind()

    End Sub
    Private Sub DropDownListOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListOffice.SelectedIndexChanged

        SaveCookieInformation()

        RadGridEmployeeTimeForecastOfficeDetails.Rebind()

    End Sub
    Private Sub DropDownListEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListEmployee.SelectedIndexChanged

        SaveCookieInformation()

        RadGridEmployeeTimeForecastOfficeDetails.Rebind()

    End Sub
    Private Sub RadToolBarEmployeeTimeForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecast.ButtonClick

        Select Case e.Item.Value

            Case "New"

                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "EmployeeTimeForecast_New", "", "EmployeeTimeForecast_New.aspx", 350, 650, True)
                Me.OpenWindow("Employee Time Forecast", "EmployeeTimeForecast_New.aspx", 350, 750, False, False, "RefreshPage")

            Case "ComparisonDashboard"

                Me.OpenWindow("Comparison Dashboard", "EmployeeTimeForecast_ComparisonDashboard.aspx")

            Case "EmployeeTimeAnalysis"

                Me.OpenWindow("Employee Time Analysis", "EmployeeTimeForecast_EmployeeTimeAnalysis.aspx")

            Case "Settings"

                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "EmployeeTimeForecast_Settings", "", "EmployeeTimeForecast_Settings.aspx", 500, 625, True)
                Me.OpenWindow("Employee Time Forecast Settings", "EmployeeTimeForecast_Settings.aspx", 500, 625, False, True)

            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                qs.Page = "EmployeeTimeForecast_Main.aspx"
                qs.Add("bm", "1")

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_EmployeeTimeForecast
                    .UserCode = Session("UserCode")
                    .Name = "Employee Time Forecast"
                    .Description = "Employee Time Forecast"
                    .PageURL = qs.ToString(True)
                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                End If


        End Select

    End Sub
    Private Sub RadGridEmployeeTimeForecastOfficeDetails_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetails.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Reload As Boolean = True
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0
        Dim EmployeeTimeForecastID As Integer = 0
        Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing
        Dim EmployeeTimeForecastOfficeDetailOfficeCode As String = ""
        Dim EmployeeTimeForecastOfficeDetailRevisionNumber As Integer = 0
        Dim AssignedToEmployeeCode As String = ""

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridEmployeeTimeForecastOfficeDetails.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "View"

                Reload = False

                If CurrentGridDataItem IsNot Nothing Then

                    Try

                        EmployeeTimeForecastID = CurrentGridDataItem.GetDataKeyValue("EmployeeTimeForecastID")

                    Catch ex As Exception
                        EmployeeTimeForecastID = 0
                    End Try

                    Try

                        EmployeeTimeForecastOfficeDetailOfficeCode = CurrentGridDataItem.GetDataKeyValue("OfficeCode")

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetailOfficeCode = ""
                    End Try

                    Try

                        EmployeeTimeForecastOfficeDetailRevisionNumber = CurrentGridDataItem.GetDataKeyValue("RevisionNumber")

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetailRevisionNumber = 0
                    End Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Try

                                AssignedToEmployeeCode = CurrentGridDataItem.GetDataKeyValue("AssignedToEmployeeCode")

                            Catch ex As Exception
                                AssignedToEmployeeCode = ""
                            End Try

                            Try

                                EmployeeTimeForecast = AdvantageFramework.Database.Procedures.EmployeeTimeForecast.LoadByEmployeeTimeForecastID(DbContext, EmployeeTimeForecastID)

                                If EmployeeTimeForecast IsNot Nothing Then

                                    EmployeeTimeForecastOfficeDetailID = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetails(DbContext, EmployeeTimeForecast.PostPeriodCode,
                                                                                                                                                       EmployeeTimeForecastOfficeDetailOfficeCode, AssignedToEmployeeCode, SecurityDbContext, _Session).
                                                                                                                     Where(Function(OfficeDetail) OfficeDetail.RevisionNumber = EmployeeTimeForecastOfficeDetailRevisionNumber).Single.ID

                                End If

                            Catch ex As Exception
                                EmployeeTimeForecastOfficeDetailID = 0
                            Finally

                                If EmployeeTimeForecastOfficeDetailID <> 0 Then

                                    Session("ETF_ExpandedIndexes") = Nothing

                                    'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", EmployeeTimeForecastOfficeDetailID))
                                    Me.OpenWindow("Employee Time Forecast Details", [String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", EmployeeTimeForecastOfficeDetailID))

                                End If

                            End Try

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            RadGridEmployeeTimeForecastOfficeDetails.Rebind()

        End If

    End Sub
    Private Sub RadGridEmployeeTimeForecastOfficeDetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetails.ItemDataBound

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
        Dim EmployeeTimeForecastID As Integer = 0
        Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing
        Dim EmployeeTimeForecastOfficeDetailOfficeCode As String = ""
        Dim EmployeeTimeForecastOfficeDetailRevisionNumber As Integer = 0
        Dim AssignedToEmployeeCode As String = ""
        Dim ImageIsApproved As Image = Nothing
        Dim IsApprovedDiv As HtmlControls.HtmlControl = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

                CurrentGridDataItem = e.Item

            End If

        End If

        If CurrentGridDataItem IsNot Nothing Then

            Try

                EmployeeTimeForecastID = CurrentGridDataItem.GetDataKeyValue("EmployeeTimeForecastID")

            Catch ex As Exception
                EmployeeTimeForecastID = 0
            End Try

            Try

                EmployeeTimeForecastOfficeDetailOfficeCode = CurrentGridDataItem.GetDataKeyValue("OfficeCode")

            Catch ex As Exception
                EmployeeTimeForecastOfficeDetailOfficeCode = ""
            End Try

            Try

                EmployeeTimeForecastOfficeDetailRevisionNumber = CurrentGridDataItem.GetDataKeyValue("RevisionNumber")

            Catch ex As Exception
                EmployeeTimeForecastOfficeDetailRevisionNumber = 0
            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        AssignedToEmployeeCode = CurrentGridDataItem.GetDataKeyValue("AssignedToEmployeeCode")

                    Catch ex As Exception
                        AssignedToEmployeeCode = ""
                    End Try

                    Try

                        EmployeeTimeForecast = AdvantageFramework.Database.Procedures.EmployeeTimeForecast.LoadByEmployeeTimeForecastID(DbContext, EmployeeTimeForecastID)

                        If EmployeeTimeForecast IsNot Nothing Then

                            EmployeeTimeForecastOfficeDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetails(DbContext, EmployeeTimeForecast.PostPeriodCode,
                                                                                                                                               EmployeeTimeForecastOfficeDetailOfficeCode, AssignedToEmployeeCode, SecurityDbContext, _Session).
                                                                                                           Where(Function(OfficeDetail) OfficeDetail.RevisionNumber = EmployeeTimeForecastOfficeDetailRevisionNumber).Single

                        End If

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetail = Nothing
                    Finally

                        If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                            Try

                                IsApprovedDiv = DirectCast(e.Item.FindControl("DivIsApproved"), HtmlControls.HtmlControl)

                            Catch ex As Exception
                                IsApprovedDiv = Nothing
                            Finally

                                If IsApprovedDiv IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail.IsApproved = False Then

                                    AdvantageFramework.Web.Presentation.Controls.DivHide(IsApprovedDiv)

                                End If

                            End Try

                        End If

                    End Try

                End Using

            End Using

        End If

    End Sub
    Private Sub RadGridEmployeeTimeForecastOfficeDetails_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetails.NeedDataSource

        'objects
        Dim Month As Short = 0
        Dim Year As String = ""
        Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DbContext.Database.Connection.Open()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If String.IsNullOrWhiteSpace(DropDownListPostPeriod.SelectedValue) = False Then

                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, DropDownListPostPeriod.SelectedValue)

                End If

                If PostPeriod IsNot Nothing Then

                    Year = PostPeriod.Year

                    Try

                        Month = PostPeriod.Month

                    Catch ex As Exception
                        Month = 0
                    End Try

                Else

                    Year = ""
                    Month = 0

                End If

                RadGridEmployeeTimeForecastOfficeDetails.DataSource = (From EmployeeTimeForecastOfficeDetail In AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetails(DbContext, Month, Year, DropDownListOffice.SelectedValue, DropDownListEmployee.SelectedValue, SecurityDbContext, _Session)
                                                                       Group By Key = New With {EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast, EmployeeTimeForecastOfficeDetail.Office, EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode} Into Group).ToList.Select(Function(GroupEntity) _
                                                                       New With {.[EmployeeTimeForecastID] = GroupEntity.Key.EmployeeTimeForecast.ID,
                                                                                 .[Description] = GroupEntity.Key.EmployeeTimeForecast.Description,
                                                                                 .[OfficeCode] = GroupEntity.Key.Office.Code,
                                                                                 .[OfficeName] = GroupEntity.Key.Office.Name,
                                                                                 .[RevisionNumber] = GroupEntity.Group.Max(Function(OfficeDetail) OfficeDetail.RevisionNumber),
                                                                                 .[AssignedToEmployeeCode] = GroupEntity.Key.AssignedToEmployeeCode,
                                                                                 .[AssignedToEmployeeName] = GroupEntity.Group.Max(Function(OfficeDetail) OfficeDetail.AssignedToEmployee.ToString())}).ToList

            End Using

        End Using

    End Sub

#End Region

#End Region

End Class
