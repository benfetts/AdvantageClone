Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports Webvantage.cGlobals.Globals
Imports System.Globalization
Imports System.Configuration
Imports System.Web.Configuration
Imports Webvantage.wvTimeSheet

Public Class DefaultParent
    Inherits Webvantage.BasePageShared
    Implements IRadWindowFunctions

#Region " Constants "



#End Region

#Region " Enums "

    Public Enum DefaultMainContent

        MyTasks = 0
        MyAlerts = 1
        MyAssignments = 2
        MyReviews = 3

    End Enum

#End Region

#Region " Variables "

    Private _TimeOutPeriod As Integer = 0
    Private _CurrentUI As String = "win"
    Private _ThisPage As String = "Default.aspx"
    Private _PageStatePersister As PageStatePersister = Nothing
    Private _MenuOffset As Integer = 0
    Private _CurrentDockStates As Generic.List(Of Telerik.Web.UI.DockState) = Nothing
    Private _IsClientPortal As Boolean = Me.IsClientPortal()

    Private _HasFavoriteObjects As Boolean = False
    Private _HasFavoriteApps As Boolean = False

    Private _HasUserAddedBookmarkDO As Boolean = False

    Private _ShowNewMenu As Boolean = True
    Private _ShowAppMenu As Boolean = True

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0

    Private _ScheduleUserControl As Webvantage.DesktopCardsMySummary
    Private _CalendarUserControl As Webvantage.DesktopCardsMyCalendar
    Private _AssignmentsUserControl As Webvantage.DesktopCardsMyAssignments
    Private _AlertsUserControl As Webvantage.DesktopCardsMyAssignments
    Private _ReviewsUserControl As Webvantage.DesktopCardsMyAssignments
    Private _BookmarksUserControl As Webvantage.DesktopCardsMyBookmarks
    Private _TasksUserControl As Webvantage.DesktopCardsMyTasks

    Private _LoadPageName As String = ""
    Private _AutoOpenArrayCount As Integer = 0
    Private _SbWindowArray As New System.Text.StringBuilder

    Public JavascriptWindowsArrays As String = ""
    Public JavascriptWorkspaceId As Integer = 0
    Public JavascriptAlertTimer As String = ""

    Public JavascriptAssignmentUpdatePanelName As String = ""
    Public JavascriptAlertUpdatePanelName As String = ""
    Public JavascriptTaskUpdatePanelName As String = ""
    Public JavascriptHoursUpdatePanelName As String = ""
    Public JavascriptCalendarUpdatePanelName As String = ""
    Public JavascriptMainLeftContentUpdatePanelName As String = ""

    Public FilesizeLimit As String = ""
    Public PanelScript As String = ""

    Public SideBarBackgroundColor As String = "#00BCD4"
    Public BackgroundColor As String = "#0097A7"
    Public DarkHighlightColor As String = "#00838F"

    Public TimeoutMilliseconds As Double = 1200000

    Public Shared Property ChatEnabled As Boolean
        Get
            If HttpContext.Current.Session("CheckModuleAccessDesktop_Chat") IsNot Nothing Then
                Return CType(HttpContext.Current.Session("CheckModuleAccessDesktop_Chat"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            HttpContext.Current.Session("CheckModuleAccessDesktop_Chat") = value
        End Set
    End Property

#End Region

#Region " Properties "

    Public Property _CurrentDefaultContent As DefaultMainContent
        Get
            Dim CurrentMainContent As DefaultMainContent = DefaultMainContent.MyTasks
            Dim AppVars As New cAppVars(cAppVars.Application.DFLT_WRKSPCE)
            Try

                AppVars.getAllAppVars()

                If IsNumeric(AppVars.getAppVar("MainContentLoaded", "integer", "0")) = True Then

                    CurrentMainContent = CType(CType(AppVars.getAppVar("MainContentLoaded", "integer", "0"), Integer), DefaultMainContent)

                End If

            Catch ex As Exception

                CurrentMainContent = DefaultMainContent.MyTasks

            End Try
            Return CurrentMainContent
        End Get
        Set(value As DefaultMainContent)

            Dim AppVars As New cAppVars(cAppVars.Application.DFLT_WRKSPCE)

            AppVars.getAllAppVars()
            AppVars.setAppVar("MainContentLoaded", CType(value, Integer), "integer")
            AppVars.SaveAllAppVars()

            Dim qs As New AdvantageFramework.Web.QueryString
            qs = qs.FromCurrent

            qs.Go(False, True)

        End Set
    End Property
    Public Property _IsDefaultWorkspace As Boolean
        Get
            If Session("_IsDefaultWorkspace") Is Nothing Then
                Session("_IsDefaultWorkspace") = False
            End If
            Return Session("_IsDefaultWorkspace")
        End Get
        Set(value As Boolean)
            Session("_IsDefaultWorkspace") = value
        End Set
    End Property
    Public Property _IsFloatingObjects As Boolean
        Get
            If Session("_IsFloatingObjects") Is Nothing Then
                Session("_IsFloatingObjects") = False
            End If
            Return Session("_IsFloatingObjects")
        End Get
        Set(value As Boolean)
            Session("_IsFloatingObjects") = value
        End Set
    End Property
    Public Property CurrentWorkspaceId() As Integer
        Get

            If Session("CurrentWorkspaceId") Is Nothing OrElse IsNumeric(Session("CurrentWorkspaceId")) = False Then

                Session("CurrentWorkspaceId") = 0

            End If

            Return CType(Session("CurrentWorkspaceId"), Integer)

        End Get
        Set(ByVal value As Integer)

            Session("CurrentWorkspaceId") = value

        End Set
    End Property
    Private Property _DefaultWorkspaceDate() As Date
        Get

            If Session("_DefaultWorkspaceDate") Is Nothing OrElse IsDate(Session("_DefaultWorkspaceDate")) = False Then

                Session("_DefaultWorkspaceDate") = cEmployee.TimeZoneToday

            End If

            Return CDate(Session("_DefaultWorkspaceDate"))

        End Get
        Set(ByVal value As Date)

            Session("_DefaultWorkspaceDate") = value

        End Set
    End Property

    Private ReadOnly Property _IsUsingAssignments() As Boolean
        Get
            Try

                Dim a As New cAgency(_Session.ConnectionString)
                Return a.IsUsingAssignments

            Catch ex As Exception
                Return True
            End Try
        End Get
    End Property
    Public Property PersistenceManager() As Telerik.Web.UI.RadPersistenceManager
        Get
            Return Me.RadPersistenceManagerParent
        End Get
        Set(value As Telerik.Web.UI.RadPersistenceManager)
            Me.RadPersistenceManagerParent = value
        End Set
    End Property
    'Public Property RadToolTipManager As Telerik.Web.UI.RadToolTipManager
    '    Get
    '        Return Me.RadToolTipManagerParent
    '    End Get
    '    Set(value As Telerik.Web.UI.RadToolTipManager)
    '        Me.RadToolTipManagerParent = value
    '    End Set
    'End Property
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _PageStatePersister Is Nothing Then
                _PageStatePersister = New SessionPageStatePersister(Me)
            End If
            PageStatePersister = _PageStatePersister
        End Get
    End Property

    Public Shared AppPath As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")

#End Region

#Region " Methods "

#Region " Page "

    Private Sub DefaultParent_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Dim URL = "NewApp"

        If Request.QueryString IsNot Nothing Then

            URL = URL & "?" & Request.QueryString.ToString

        End If

        Response.Redirect(URL, True)

    End Sub

    Private Sub Page_Error1(sender As Object, e As EventArgs) Handles Me.Error
        Try
            If _Session Is Nothing OrElse Session("ConnString") Is Nothing OrElse Session("ConnString") = "" Then

                MiscFN.ResponseRedirect("SignIn.aspx?m=" & CType(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString, Integer))
                Exit Sub

            Else

                Server.Transfer("Error.aspx")

            End If
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
    End Sub
    'Private Sub DefaultParent_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub

    '    Dim BrowserName As String = String.Empty

    '    BrowserName = Request.Browser.Browser.ToLower

    '    If String.IsNullOrWhiteSpace(BrowserName) = False Then

    '        If BrowserName.Contains("chrome") Then

    '            Me.maincontent.Attributes.Remove("class")
    '            Me.maincontent.Attributes.Add("class", "main-content-chr")

    '        ElseIf BrowserName.Contains("fox") Then

    '            Me.maincontent.Attributes.Remove("class")
    '            Me.maincontent.Attributes.Add("class", "main-content-ffx")

    '        ElseIf BrowserName.Contains("safari") Then

    '            Me.maincontent.Attributes.Remove("class")
    '            Me.maincontent.Attributes.Add("class", "main-content-saf")

    '        ElseIf BrowserName.Contains("explorer") Then

    '            Me.maincontent.Attributes.Remove("class")
    '            Me.maincontent.Attributes.Add("class", "main-content-dflt")

    '        Else

    '            Me.maincontent.Attributes.Remove("class")
    '            Me.maincontent.Attributes.Add("class", "main-content-dflt")

    '        End If

    '    End If

    '    Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
    '    t.Reload()

    '    Me._IsFloatingObjects = t.Settings.FloatDesktopObjects.ToString().ToLower()

    '    Try

    '        If Not Request.QueryString("link") Is Nothing Then

    '            _LoadPageName = Request.QueryString.ToString.Replace("link=", "")
    '            _LoadPageName = Server.UrlDecode(_LoadPageName)
    '            _LoadPageName = _LoadPageName.Replace("$", "?").Replace("alert=", "AlertID=")
    '            _LoadPageName = _LoadPageName & "&openasassign=False&SprintID=0"

    '        End If

    '    Catch ex As Exception
    '        _LoadPageName = ""
    '    End Try
    '    If String.IsNullOrWhiteSpace(_LoadPageName) = True Then
    '        Try

    '            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.DeepLink) = False Then

    '                Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
    '                _LoadPageName = Deep.Decrypt(Me.CurrentQuerystring.DeepLink)

    '            End If

    '        Catch ex As Exception
    '            _LoadPageName = ""
    '        End Try
    '    End If

    '    Dim UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission) = Nothing

    '    'Me._AssignmentsUserControl.LoadAlertType = DesktopCardsMyAssignments.LoadType.Assignments
    '    'Me._AlertsUserControl.LoadAlertType = DesktopCardsMyAssignments.LoadType.Alerts



    '    If Me.Page.IsPostBack = False AndAlso Me.Page.IsCallback = False AndAlso _Session IsNot Nothing Then

    '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '            If _Session.Application <> AdvantageFramework.Security.Application.Client_Portal Then

    '                UserPermissionList = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndUser(SecurityDbContext, _Session.Application, _Session.User.ID).ToList

    '            End If

    '            If UserPermissionList IsNot Nothing Then

    '                For Each UserPermission In UserPermissionList

    '                    Me.CheckAndSaveAllSecurityForModule(UserPermission)

    '                Next

    '            End If

    '        End Using

    '        If String.IsNullOrWhiteSpace(Me._LoadPageName) = True Then

    '            Dim qs As New AdvantageFramework.Web.QueryString()
    '            qs = qs.FromCurrent()

    '            Try

    '                Dim oAppVars As New cAppVars(cAppVars.Application.MY_SETTINGS)
    '                oAppVars.getAllAppVars()

    '                Try

    '                    If qs.GetValue("click") = "1" Then

    '                        oAppVars.setAppVar("CURRENT_WORKSPACE", qs.WorkspaceId, "Integer")
    '                        oAppVars.SaveAllAppVars()

    '                    End If

    '                Catch ex As Exception

    '                End Try

    '                Me.CurrentWorkspaceId = qs.WorkspaceId

    '                'If Me.CurrentWorkspaceId = 0 Then

    '                If IsNumeric(oAppVars.getAppVar("CURRENT_WORKSPACE")) = True Then

    '                    Me.CurrentWorkspaceId = CType(oAppVars.getAppVar("CURRENT_WORKSPACE"), Integer)

    '                End If

    '                'Else

    '                '    oAppVars.setAppVar("CURRENT_WORKSPACE", Me.CurrentWorkspaceId, "Integer")
    '                '    oAppVars.SaveAllAppVars()

    '                'End If

    '            Catch ex As Exception

    '                Me.CurrentWorkspaceId = 0

    '            End Try

    '        Else

    '            Me.CurrentWorkspaceId = -1

    '        End If

    '        Me.HiddenFieldChatEnabled.Value = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Chat, False) = 1

    '    End If

    '    Me._IsDefaultWorkspace = Me.CurrentWorkspaceId = 0
    '    JavascriptWorkspaceId = Me.CurrentWorkspaceId

    '    Me.SetTheme()

    '    If Me._IsDefaultWorkspace = True Then

    '        Me.LoadDefaultWorkspaceMainContent()

    '    End If

    '    Me.LoadDefaultWorkspace()

    '    If HttpContext.Current.Session("FileSizeLimit" & DocumentRepository.ByteDisplay.Megabytes.ToString()) Is Nothing Then

    '        Dim d As New DocumentRepository()
    '        Me.FilesizeLimit = d.GetFileSizeLimit(DocumentRepository.ByteDisplay.Megabytes).ToString()

    '    Else

    '        Me.FilesizeLimit = HttpContext.Current.Session("FileSizeLimit" & DocumentRepository.ByteDisplay.Megabytes.ToString())

    '    End If

    'End Sub
    'Private Sub DefaultParent_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub

    '    Try

    '        If Session("ConnString") Is Nothing Then 'natural timeout most likely occurred.

    '            AdvantageFramework.Security.AddWebvantageEventLog("Default page: connection string is nothing (most likely session timeout occurred ")
    '            Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.TimeOut)
    '            Exit Sub

    '        End If
    '        If String.IsNullOrWhiteSpace(Session("ConnString").ToString()) = True Then

    '            AdvantageFramework.Security.AddWebvantageEventLog("Default page: connection string is blank ")
    '            Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString)
    '            Exit Sub

    '        End If

    '    Catch ex As Exception
    '        Response.Redirect("SignIn.aspx", True)
    '        Exit Sub
    '    End Try

    '    Dim BodyTagOnLoad As String = ""
    '    If _LoadPageName <> "" Then BodyTagOnLoad &= Me.HookUpOpenWindow("", _LoadPageName)
    '    Me.BodyTagParent.Attributes.Add("onload", BodyTagOnLoad)

    '    Dim sss As SessionStateSection = WebConfigurationManager.GetSection("system.web/sessionState")

    '    If sss IsNot Nothing Then

    '        TimeoutMilliseconds = sss.Timeout.TotalMilliseconds

    '    End If

    '    If Me.Page.IsPostBack Then 'Or Me.Page.IsCallback Then

    '        Select Case Me.EventTarget
    '            Case "UpdateWorkspaceAlerts"

    '                Me.UpdatePanelUserSummary.Update()

    '                If _IsFloatingObjects = False Then

    '                    Me.UpdatePanelRadDock.Update()

    '                End If

    '            Case "UpdateDashboardAlerts"

    '                Dim s As String = Me.iFrameDefaultWorkspaceLeftMiddle.Attributes("src")
    '                Me.iFrameDefaultWorkspaceLeftMiddle.Attributes.Remove("src")
    '                Me.iFrameDefaultWorkspaceLeftMiddle.Attributes.Add("src", s)

    '                Me.UpdatePanelUserSummary.Update()

    '            Case "UpdatePanelDefaultWorkspaceLeftMiddle"

    '                Dim s As String = Me.iFrameDefaultWorkspaceLeftMiddle.Attributes("src")
    '                Me.iFrameDefaultWorkspaceLeftMiddle.Attributes.Remove("src")
    '                Me.iFrameDefaultWorkspaceLeftMiddle.Attributes.Add("src", s)

    '                If Me.EventArgument = "UpdatePanelUserSummary" Then

    '                    Me.UpdatePanelUserSummary.Update()

    '                End If

    '            Case "UpdatePanelRight"

    '                Me.UpdatePanelRight.Update()

    '            Case "UpdatePanelUserSummary"

    '                Me.UpdatePanelUserSummary.Update()

    '            Case "UpdatePanelUserSchedule"

    '                Me.UpdatePanelUserSchedule.Update()

    '            Case "UpdatePanelRadDock"

    '                Me.UpdatePanelRadDock.Update()

    '            Case "LoadWorkspace", "DefaultWorkspace"

    '                If IsNumeric(Me.EventArgument) = True Then

    '                    Dim oAppVars As New cAppVars(cAppVars.Application.MY_SETTINGS)
    '                    With oAppVars

    '                        .getAllAppVars()
    '                        .setAppVar("CURRENT_WORKSPACE", Me.EventArgument, "Integer")
    '                        .SaveAllAppVars()

    '                    End With

    '                    Dim q As New AdvantageFramework.Web.QueryString()
    '                    With q

    '                        .Page = Me._ThisPage
    '                        .WorkspaceId = CType(Me.EventArgument, Integer)
    '                        .Go()

    '                    End With

    '                    Exit Sub

    '                End If

    '            Case "NextWorkspace"

    '                Me.NextWorkspace()
    '                Exit Sub

    '            Case "PreviousWorkspace"

    '                Me.PreviousWorkspace()
    '                Exit Sub

    '            Case "SignOut"

    '                Dim Success As Boolean = False
    '                Dim ErrorMessage As String = String.Empty

    '                Success = MiscFN.SignOutOfWebvantage(SecuritySession, ErrorMessage)

    '                'If Success = True Then

    '                MiscFN.ResponseRedirect("SignIn.aspx")
    '                Exit Sub

    '                'Else

    '                '    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

    '                '        Me.ShowMessage(ErrorMessage)

    '                '    End If

    '                'End If

    '            Case "ShowColumn"

    '                Dim ar() As String
    '                ar = EventArgument.Split("|")
    '                Me.ColumnChanged(ar(1), ar(2), ar(3))
    '                Exit Sub

    '            Case "Notification"

    '                RadNotificationParent.ContentIcon = ""
    '                RadNotificationParent.TitleIcon = ""
    '                RadNotificationParent.VisibleOnPageLoad = True
    '                Exit Sub

    '        End Select

    '    End If



    'End Sub
    'Private Sub DefaultParent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub

    '    Try

    '        Try

    '            Me.Page.Header.DataBind()

    '        Catch ex As Exception
    '        End Try

    '        If Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites") IsNot Nothing Then

    '            Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites").Nodes.Clear()

    '        End If

    '        If Not Me.IsPostBack And Not Me.IsCallback Then

    '            Me.LoadApplicationMenu()
    '            Me.SetupQuickLaunchItems()

    '        End If

    '        Me.JavascriptWindowsArrays = ""

    '        If Me.HiddenFieldFloatDesktopObjects.Value = "False" Or Me.HiddenFieldFloatDesktopObjects.Value = "" Then

    '            ''use RadDock
    '            Me.LoadCurrentWorkspaceObjects(Me.CurrentWorkspaceId)

    '        Else

    '            ''use RadWindow
    '            If Not Me.IsPostBack = True Then Me.CreateJavascriptWindowArray()

    '        End If

    '        Me.SetBookmarkMenuIcon()

    '        If Not Me.IsPostBack And Not Me.IsCallback Then

    '            Try

    '                If Me._HasFavoriteApps = False And Me._HasFavoriteObjects = False Then

    '                    Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites").Visible = False

    '                Else

    '                    Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites").Visible = True

    '                End If

    '            Catch ex As Exception
    '            End Try

    '            Dim FindRadTreeNode As RadTreeNode = Me.RadTreeViewMainMenu.FindNodeByValue("RadPanelItemFind")

    '            If _Session IsNot Nothing Then

    '                If _Session.Application = AdvantageFramework.Security.Application.Client_Portal Then

    '                    LoadNewMenuItemsClientPortal()

    '                    'Me.RadTreeViewMainMenu.FindNodeByValue("APP|0|MySettings.aspx|0|0").Visible = False
    '                    Me.RadTreeViewMainMenu.FindNodeByText("Help").Value = "HELPCP|"
    '                    Me.RadTreeViewMainMenu.FindNodeByValue("APP|0|About.aspx|0|0").Visible = False

    '                    If FindRadTreeNode IsNot Nothing Then

    '                        FindRadTreeNode.Nodes.FindNodeByText("Authorization to Buy").Visible = False
    '                        FindRadTreeNode.Nodes.FindNodeByText("Campaign").Visible = False
    '                        FindRadTreeNode.Nodes.FindNodeByText("Document").Visible = False
    '                        FindRadTreeNode.Nodes.FindNodeByText("Estimate").Visible = False
    '                        FindRadTreeNode.Nodes.FindNodeByText("Job Jacket").Visible = False
    '                        FindRadTreeNode.Nodes.FindNodeByText("Project Schedule").Visible = False
    '                        FindRadTreeNode.Nodes.FindNodeByText("Purchase Order").Visible = False
    '                        FindRadTreeNode.Nodes.FindNodeByText("Time").Visible = False

    '                    End If

    '                    Me.GetSpaces()

    '                    Me.DivChatButton.Visible = False

    '                ElseIf _Session.Application = AdvantageFramework.Security.Application.Webvantage Then

    '                    RadNotificationLicenseKey.VisibleOnPageLoad = AdvantageFramework.Security.LicenseKey.CheckToNotifyUserOfLicenseKey(_Session, LabelNotificationMessage.Text)
    '                    RadNotificationLicenseKey.Visible = RadNotificationLicenseKey.VisibleOnPageLoad

    '                    Me.LoadNewMenuItems()
    '                    Me.GetSpaces()
    '                    Me.SetAppNotification()

    '                    If FindRadTreeNode IsNot Nothing Then

    '                        FindRadTreeNode.Nodes.FindNodeByText("Authorization to Buy").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy, False) = 1
    '                        FindRadTreeNode.Nodes.FindNodeByText("Campaign").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Campaigns, False) = 1
    '                        FindRadTreeNode.Nodes.FindNodeByText("Document").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, False) = 1
    '                        FindRadTreeNode.Nodes.FindNodeByText("Estimate").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating, False) = 1
    '                        FindRadTreeNode.Nodes.FindNodeByText("Job Jacket").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, False) = 1
    '                        'FindRadTreeNode.Nodes.FindNodeByText("Job Request").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules., False) = 1
    '                        FindRadTreeNode.Nodes.FindNodeByText("Project Schedule").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, False) = 1
    '                        FindRadTreeNode.Nodes.FindNodeByText("Purchase Order").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders, False) = 1
    '                        FindRadTreeNode.Nodes.FindNodeByText("Time").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet, False) = 1

    '                    End If

    '                End If

    '            End If

    '            Me.ImageButtonBoards.Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Boards, False) = 1

    '        End If


    '        If Not Me.IsPostBack And Not Me.IsCallback Then

    '            Me.LoadEmployee()

    '            If _Session.Application = AdvantageFramework.Security.Application.Client_Portal Then

    '                RadTreeViewMainMenu.Nodes.FindNodeByValue("RadPanelItemOther").Nodes.FindNodeByValue("APP|0|AgencySettings.aspx|0|0").Visible = False

    '            ElseIf _Session.Application = AdvantageFramework.Security.Application.Webvantage Then

    '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                    'RadTreeViewMainMenu.Nodes.FindNodeByValue("RadPanelItemOther").Nodes.FindNodeByValue("APP|0|AgencySettings.aspx|0|0").Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_AgencySettings, False) = 1

    '                End Using

    '            End If

    '            Me.LiteralDayOfMonth.Text = cEmployee.TimeZoneToday.Day.ToString()
    '            Me.LiteralMonth.Text = MonthName(cEmployee.TimeZoneToday.Month)

    '            If AdvantageFramework.Timesheet.HasStopWatch(Session("ConnString"), Session("UserCode"), Session("EmpCode")) = True Then

    '                Me.OpenTimesheetStopwatchNotificationWindow()

    '            End If

    '            Try

    '                Dim i As Integer = 0
    '                Dim Messages As New AdvantageFramework.Web.CookieMessages.Methods(_Session.ConnectionString, _Session.UserCode)

    '                If Me.IsClientPortal = False Then
    '                    Messages.Load()

    '                    If _AutoOpenArrayCount > 0 Then

    '                        i = _AutoOpenArrayCount

    '                    End If
    '                    For Each msg In Messages.MessagesToShow

    '                        JavascriptWindowsArrays += AddToAutoOpenArray(i, msg.URL)
    '                        i += 1

    '                    Next
    '                End If


    '            Catch ex As Exception
    '            End Try

    '            'Me.ImageButtonEmployeeBoard.OnClientClick = String.Format("OpenRadWindow('', 'ProjectManagement/Agile/EmployeeBoard/{0}'); return false;", HttpContext.Current.Session("EmpCode"))

    '        Else

    '            Select Case Me.EventTarget

    '            End Select

    '        End If

    '    Catch ex As Exception
    '    End Try

    'End Sub
    'Private Sub DefaultParent_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub

    'End Sub

#End Region
#Region " Controls "

    'Private Sub DefaultWorkspaceLinkUserAlertsPanel_ServerClick(sender As Object, e As EventArgs) Handles DefaultWorkspaceLinkUserAlertsPanel.ServerClick

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Me._CurrentDefaultContent = DefaultMainContent.MyAlerts
    '    'Me.LoadDefaultWorkspaceMainContent()

    'End Sub
    'Private Sub DefaultWorkspaceLinkUserAssignmentsPanel_ServerClick(sender As Object, e As EventArgs) Handles DefaultWorkspaceLinkUserAssignmentsPanel.ServerClick

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Me._CurrentDefaultContent = DefaultMainContent.MyAssignments
    '    'Me.LoadDefaultWorkspaceMainContent()

    'End Sub
    'Private Sub DefaultWorkspaceLinkUserReviewsPanel_ServerClick(sender As Object, e As EventArgs) Handles DefaultWorkspaceLinkUserReviewsPanel.ServerClick

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Me._CurrentDefaultContent = DefaultMainContent.MyReviews
    '    'Me.LoadDefaultWorkspaceMainContent()

    'End Sub
    'Private Sub DefaultWorkspaceLinkUserTasksPanel_ServerClick(sender As Object, e As EventArgs) Handles DefaultWorkspaceLinkUserTasksPanel.ServerClick

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Me._CurrentDefaultContent = DefaultMainContent.MyTasks
    '    'Me.LoadDefaultWorkspaceMainContent()

    'End Sub
    'Private Sub RadButtonDontRemindMeAgain_Click(sender As Object, e As System.EventArgs) Handles RadButtonDontRemindMeAgain.Click

    '    'objects
    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

    '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        Try

    '            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString)

    '        Catch ex As Exception
    '            UserSetting = Nothing
    '        End Try

    '        If UserSetting IsNot Nothing Then

    '            UserSetting.StringValue = "N"
    '            UserSetting.DateValue = Nothing

    '            AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

    '        Else

    '            AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString, "N", Nothing, Nothing, UserSetting)

    '        End If

    '    End Using

    '    RadNotificationLicenseKey.VisibleOnPageLoad = False
    '    RadNotificationLicenseKey.Visible = False

    'End Sub
    'Private Sub RadButtonRemindMeAgainTomorrow_Click(sender As Object, e As System.EventArgs) Handles RadButtonRemindMeAgainTomorrow.Click

    '    'objects
    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

    '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        Try

    '            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString)

    '        Catch ex As Exception
    '            UserSetting = Nothing
    '        End Try

    '        If UserSetting IsNot Nothing Then

    '            UserSetting.StringValue = "Y"
    '            UserSetting.DateValue = Now.AddDays(1)

    '            AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

    '        Else

    '            AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString, "Y", Nothing, Now.AddDays(1), UserSetting)

    '        End If

    '    End Using

    '    RadNotificationLicenseKey.VisibleOnPageLoad = False
    '    RadNotificationLicenseKey.Visible = False


    'End Sub
    'Private Sub RadDockLayoutParent_SaveDockLayout(sender As Object, e As DockLayoutEventArgs) Handles RadDockLayoutParent.SaveDockLayout

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    If Me._IsFloatingObjects = True Then Exit Sub
    '    _CurrentDockStates = RadDockLayoutParent.GetRegisteredDocksState()

    'End Sub
    ''Protected Sub RadNotificationParent_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)

    ''    Select Case e.Item.Value

    ''        Case "Read"

    ''            AdvantageFramework.Security.ClearNewAdvantageApplicationsAlertSetting(_Session)

    ''            Me.ImageButtonNewApplications.Visible = False

    ''            RadNotificationParent.ContentIcon = ""
    ''            RadNotificationParent.TitleIcon = ""
    ''            RadNotificationParent.VisibleOnPageLoad = False

    ''        Case "Hide"

    ''            Me.ImageButtonNewApplications.Visible = True

    ''            RadNotificationParent.ContentIcon = ""
    ''            RadNotificationParent.TitleIcon = ""
    ''            RadNotificationParent.VisibleOnPageLoad = False

    ''    End Select

    ''End Sub

    ''Private Sub UpdatePanelUserAlerts_Load(sender As Object, e As EventArgs) Handles UpdatePanelUserAlerts.Load
    ''    Me.UserAlerts.LoadAlertType = DesktopCardsMyAssignments.LoadType.Alerts
    ''    'Me.UserAlerts.LoadData()
    ''    Me.UpdatePanelUserAlerts.Update()
    ''End Sub
    ''Private Sub UpdatePanelUserAssignments_Load(sender As Object, e As EventArgs) Handles UpdatePanelUserAssignments.Load
    ''    Me.UserAssignments.LoadAlertType = DesktopCardsMyAssignments.LoadType.Assignments
    ''    'Me.UserAlerts.LoadData()
    ''    Me.UpdatePanelUserAssignments.Update()
    ''End Sub
    ''Private Sub UpdatePanelUserBookmarks_Load(sender As Object, e As EventArgs) Handles UpdatePanelUserBookmarks.Load
    ''    Me.UserBookmarks.LoadData()
    ''    Me.UpdatePanelUserBookmarks.Update()
    ''End Sub
    ''Private Sub UpdatePanelUserSchedule_Load(sender As Object, e As EventArgs) Handles UpdatePanelUserSchedule.Load
    ''    Me.UserSchedule.LoadData()
    ''    Me.UpdatePanelUserSchedule.Update()
    ''End Sub
    ''Private Sub UpdatePanelUserTasks_Load(sender As Object, e As EventArgs) Handles UpdatePanelUserTasks.Load
    ''    Me.UserTasks.LoadData()
    ''    Me.UpdatePanelUserTasks.Update()
    ''End Sub
    ''Private Sub UpdatePanelUserSummary_Load(sender As Object, e As EventArgs) Handles UpdatePanelUserSummary.Load
    ''    Me.UserSummary.LoadData()
    ''    Me.UpdatePanelUserSummary.Update()
    ''End Sub

#End Region

#Region " Theme and Wallpaper "

    'Private Sub SetTheme()

    '    Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
    '    t.Load()

    '    Me._ShowNewMenu = t.Settings.SimpleLayoutShowNewMenu
    '    Me._ShowAppMenu = t.Settings.SimpleLayoutShowAppMenu

    '    Me.UseSolidColorBackground(t.Settings.SimpleLayoutBackgroundColor)

    '    Me.RadSkinManagerParent.Skin = t.Settings.TelerikTheme
    '    Me.RadFormDecoratorParent.Skin = t.Settings.TelerikTheme
    '    Me.RadWindowManagerParent.Skin = t.Settings.TelerikTheme

    '    Me.HiddenFieldFloatDesktopObjects.Value = t.Settings.FloatDesktopObjects.ToString()

    '    Me.Page.Theme = t.Settings.AppTheme

    '    If t.Settings.EnableWeather = True Then

    '        Dim ei As New AdvantageFramework.Web.Presentation.Controls.WeatherInformationTemplateMenu()
    '        ei.InstantiateIn(Me.DivWeather)

    '    Else

    '        Me.DivWeather.Visible = False

    '    End If

    '    Select Case t.Settings.SimpleLayoutIconStyle

    '        Case UserThemeSettings.IconStyle.DarkGrey

    '            Me.ParentPageHead.Controls.Add(New LiteralControl("<link href=""CSS/UI_Simple.Grey.min.css"" rel=""stylesheet"" type=""text/css"" />"))

    '            Me.ImageAdvantage.ImageUrl = "~/Images/Icons/Grey/256/Advantage.png" ' Me.ImageWebvantage.ImageUrl.Replace("Icons/Color", "Icons/Grey")
    '            Me.ImageApps.ImageUrl = "~/Images/Icons/Grey/256/app_drawer.png" 'Me.ImageApps.ImageUrl.Replace("Icons/Color", "Icons/Grey")

    '            Me.ImageButtonNextWorkspace.ImageUrl = Me.ImageButtonNextWorkspace.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonPreviousWorkspace.ImageUrl = Me.ImageButtonPreviousWorkspace.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonBookmarks.ImageUrl = Me.ImageButtonBookmarks.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonSignOut.ImageUrl = Me.ImageButtonSignOut.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonSetColors.ImageUrl = Me.ImageButtonSetColors.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonNewApplications.ImageUrl = Me.ImageButtonNewApplications.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonDashboard.ImageUrl = Me.ImageButtonDashboard.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ASPxBinaryImageEmp.EmptyImage.Url = Me.ASPxBinaryImageEmp.EmptyImage.Url.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonChat.ImageUrl = Me.ImageButtonChat.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            'Me.ImageButtonEmployeeBoard.ImageUrl = Me.ImageButtonEmployeeBoard.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonTheme.ImageUrl = Me.ImageButtonTheme.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")
    '            Me.ImageButtonBoards.ImageUrl = Me.ImageButtonBoards.ImageUrl.Replace("Icons/Color", "Icons/Grey").Replace("Icons/White", "Icons/Grey")

    '        Case Else 'Default to White

    '            Me.ParentPageHead.Controls.Add(New LiteralControl("<link href=""CSS/UI_Simple.White.min.css"" rel=""stylesheet"" type=""text/css"" />"))

    '            Me.ImageAdvantage.ImageUrl = "~/Images/Icons/White/256/Advantage.png" 'Me.ImageWebvantage.ImageUrl.Replace("Icons/Color", "Icons/White")
    '            Me.ImageApps.ImageUrl = "~/Images/Icons/White/256/app_drawer.png" 'Me.ImageApps.ImageUrl.Replace("Icons/Color", "Icons/White")

    '            Me.ImageButtonNextWorkspace.ImageUrl = Me.ImageButtonNextWorkspace.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonPreviousWorkspace.ImageUrl = Me.ImageButtonPreviousWorkspace.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonBookmarks.ImageUrl = Me.ImageButtonBookmarks.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonSignOut.ImageUrl = Me.ImageButtonSignOut.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonSetColors.ImageUrl = Me.ImageButtonSetColors.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonNewApplications.ImageUrl = Me.ImageButtonNewApplications.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonDashboard.ImageUrl = Me.ImageButtonDashboard.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ASPxBinaryImageEmp.EmptyImage.Url = Me.ASPxBinaryImageEmp.EmptyImage.Url.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonChat.ImageUrl = Me.ImageButtonChat.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            'Me.ImageButtonEmployeeBoard.ImageUrl = Me.ImageButtonEmployeeBoard.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonTheme.ImageUrl = Me.ImageButtonTheme.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")
    '            Me.ImageButtonBoards.ImageUrl = Me.ImageButtonBoards.ImageUrl.Replace("Icons/Color", "Icons/White").Replace("Icons/Grey", "Icons/White")

    '    End Select

    '    'Me.ImageButtonEmployeeBoard.Visible = MiscFN.EnableKanBan
    '    If t.Settings.Agency_UseAgencyBranding = True Then
    '        SideBarBackgroundColor = t.Settings.Agency_SimpleLayoutSideBarColor
    '        BackgroundColor = t.Settings.Agency_SimpleLayoutBackgroundColor
    '    Else
    '        SideBarBackgroundColor = t.Settings.SimpleLayoutSideBarColor
    '        BackgroundColor = t.Settings.SimpleLayoutBackgroundColor
    '    End If

    '    DarkHighlightColor = t.Settings.SimpleLayoutDarkHighlightColor

    '    Me.DivNewPanel.Visible = Me._ShowNewMenu
    '    Me.DivAppPanel.Visible = Me._ShowAppMenu

    '    Me.MaterialCSSLink.Attributes.Remove("href")
    '    Me.MaterialCSSLink.Attributes.Add("href", "CSS/Material/" & t.Settings.CssFile)

    '    If Me._ShowNewMenu = False AndAlso Me._ShowAppMenu = False Then

    '        Me.ParentPageHead.Controls.Add(New LiteralControl("<link href=""CSS/UI_Simple.NoLeftSideBar.min.css"" rel=""stylesheet"" type=""text/css"" />"))
    '        Me.framecontentLeft.Visible = False

    '    End If

    '    If Me._IsDefaultWorkspace = False AndAlso t.Settings.FloatDesktopObjects = True AndAlso
    '        t.Settings.Agency_UseAgencyBranding = True AndAlso t.Settings.Agency_ShowLogoOnWorkspace = True AndAlso
    '        t.Settings.Agency_Logo IsNot Nothing AndAlso t.Settings.Agency_Logo <> "" AndAlso t.Settings.FullPathToLogo <> "" Then

    '        Me.ImageLogo.ImageUrl = t.Settings.FullPathToLogo
    '        Me.ImageLogo.Attributes.Add("lpos", t.Settings.Agency_WorkspaceLogoPosition.ToString())
    '        Me.ImageLogo.CssClass = "workspace-logo"

    '        If t.Settings.Agency_SimpleLayoutBackgroundColor <> "" Then
    '            BackgroundColor = t.Settings.Agency_SimpleLayoutBackgroundColor
    '        End If

    '    Else

    '        Me.ImageLogo.Visible = False

    '    End If

    '    Me._IsFloatingObjects = t.Settings.FloatDesktopObjects.ToString().ToLower()

    '    If t.Settings.TelerikTheme = "Metro" Then

    '        Me.ImageButtonTheme.ToolTip = "Switch to large theme"

    '    Else

    '        Me.ImageButtonTheme.ToolTip = "Switch to small theme"

    '    End If

    'End Sub
    'Private Function UseSolidColorBackground(ByVal HtmlColor As String) As Boolean
    '    Try
    '        Dim sb As New System.Text.StringBuilder
    '        With sb
    '            .Append("background-color: " & HtmlColor & " !important;")
    '        End With
    '        Me.maincontent.Attributes.Add("style", sb.ToString())
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

#End Region
#Region " Menu "

    'Private Sub LoadApplicationMenu()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Try

    '        Try

    '            If HttpContext.Current Is Nothing Then Exit Sub
    '            If HttpContext.Current.Session Is Nothing Then Exit Sub
    '            If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub
    '            If HttpContext.Current.Session("UserCode") Is Nothing Then Exit Sub

    '        Catch ex As Exception
    '        End Try

    '        Try

    '            If Me._ShowAppMenu = False Then Exit Sub

    '        Catch ex As Exception
    '        End Try

    '        'objects
    '        Dim ModuleView As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
    '        'Dim RadPanelItem As Telerik.Web.UI.RadPanelItem = Nothing
    '        Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing
    '        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing
    '        Dim UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission) = Nothing


    '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '            If _Session.Application <> AdvantageFramework.Security.Application.Client_Portal Then

    '                UserPermissionList = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndUser(SecurityDbContext, _Session.Application, _Session.User.ID).ToList

    '            End If

    '            ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.Load(SecurityDbContext).ToList

    '            If ModulesList IsNot Nothing AndAlso ModulesList.Count > 0 Then

    '                For Each ModuleView In ModulesList.Where(Function(ModView) ModView.ApplicationID = _Session.Application AndAlso ModView.ParentModuleID Is Nothing AndAlso
    '                                                                   ModView.IsInactive = False AndAlso ModView.IsMenuItem = True).OrderBy(Function(ModView) ModView.SortOrder)

    '                    RadTreeNode = New Telerik.Web.UI.RadTreeNode
    '                    RadTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide
    '                    RadTreeNode.Text = ModuleView.ModuleDescription

    '                    Try

    '                        Me.RadTreeViewApps.Nodes.Add(RadTreeNode)

    '                    Catch ex As Exception
    '                    End Try

    '                    Try

    '                        If _Session.Application = AdvantageFramework.Security.Application.Client_Portal Then

    '                            LoadApplicationSubMenu(_Session.Application, _Session.ClientPortalUser, ModuleView, RadTreeNode, ModulesList)

    '                        Else

    '                            LoadApplicationSubMenu(SecurityDbContext, _Session.Application, ModuleView, RadTreeNode, ModulesList, UserPermissionList)

    '                        End If

    '                    Catch ex As Exception
    '                    End Try

    '                    Try

    '                        If RadTreeNode.Nodes.Count = 0 Then

    '                            RadTreeViewApps.Nodes.Remove(RadTreeNode)

    '                        End If

    '                    Catch ex As Exception
    '                    End Try

    '                Next

    '            End If

    '        End Using

    '    Catch ex As Exception
    '    End Try

    'End Sub
    'Private Sub LoadApplicationSubMenu(ByVal ApplicationID As Integer, ByVal ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser,
    '                                   ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentRadTreeNode As Telerik.Web.UI.RadTreeNode, ByRef ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView))

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    'objects
    '    Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing
    '    Dim SubModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
    '    Dim HasURL As Boolean = False

    '    Try

    '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '            For Each SubModule In ModulesList.Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = ModuleView.ModuleID AndAlso
    '                                                                      ModView.IsInactive = False AndAlso ModView.IsMenuItem = True AndAlso ModView.IsDesktopObject = False).OrderBy(Function(ModView) ModView.SortOrder)

    '                If SubModule.IsCategory Then

    '                    If ModulesList.Any(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = SubModule.ModuleID AndAlso
    '                                                         ModView.IsMenuItem AndAlso ModView.IsDesktopObject = False AndAlso ModView.IsInactive = False) Then

    '                        RadTreeNode = New Telerik.Web.UI.RadTreeNode
    '                        RadTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide
    '                        RadTreeNode.Text = SubModule.ModuleDescription

    '                        ParentRadTreeNode.Nodes.Add(RadTreeNode)

    '                        LoadApplicationSubMenu(ApplicationID, ClientPortalUser, SubModule, RadTreeNode, ModulesList)

    '                        If RadTreeNode.Nodes.Count = 0 Then

    '                            ParentRadTreeNode.Nodes.Remove(RadTreeNode)

    '                        End If

    '                    End If

    '                Else

    '                    If Me.CheckModuleAccess(ClientPortalUser, SubModule.ModuleCode, True) = 1 Or Me.CheckModuleAccess(ClientPortalUser, SubModule.ModuleCode, True) = -1 Then

    '                        RadTreeNode = New Telerik.Web.UI.RadTreeNode
    '                        RadTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide
    '                        RadTreeNode.Text = SubModule.ModuleDescription

    '                        If SubModule.IsApplication Then

    '                            If SubModule.ModuleCode = AdvantageFramework.Security.Modules.HelpCustomerService_Help.ToString Then

    '                                RadTreeNode.Value = "HELPCP|"

    '                            Else

    '                                RadTreeNode.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"

    '                            End If

    '                            If SubModule.WebvantageURL <> "" Then

    '                                HasURL = True

    '                            End If

    '                        ElseIf SubModule.IsReport Then

    '                            RadTreeNode.Value = "RPT|" & SubModule.ModuleID & "|" & SubModule.ReportURL & "|0|0"

    '                            If SubModule.ReportURL <> "" Then

    '                                HasURL = True

    '                            End If

    '                        Else

    '                            RadTreeNode.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"

    '                            If SubModule.WebvantageURL <> "" Then

    '                                HasURL = True

    '                            End If

    '                        End If

    '                        If HasURL = True Then

    '                            If Me.IsClientPortal = True And SubModule.ModuleDescription = "Project Schedule" Then

    '                            Else

    '                                ParentRadTreeNode.Nodes.Add(RadTreeNode)

    '                            End If

    '                        End If

    '                    End If

    '                End If

    '            Next

    '        End Using

    '    Catch ex As Exception
    '        RadTreeNode = Nothing
    '    End Try

    'End Sub
    'Private Sub LoadApplicationSubMenu(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer,
    '                                   ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentRadTreeNode As Telerik.Web.UI.RadTreeNode,
    '                                   ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
    '                                   ByVal UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission))

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    'objects
    '    Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing
    '    Dim SubModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
    '    Dim HasURL As Boolean = False
    '    Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

    '    Try

    '        For Each SubModule In ModulesList.Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = ModuleView.ModuleID AndAlso
    '                                                                  ModView.IsInactive = False AndAlso ModView.IsMenuItem = True AndAlso ModView.IsDesktopObject = False).OrderBy(Function(ModView) ModView.SortOrder)

    '            If SubModule.IsCategory Then

    '                If ModulesList.Any(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = SubModule.ModuleID AndAlso ModView.IsMenuItem AndAlso ModView.IsDesktopObject = False) Then

    '                    RadTreeNode = New Telerik.Web.UI.RadTreeNode
    '                    RadTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide
    '                    RadTreeNode.Text = SubModule.ModuleDescription

    '                    ParentRadTreeNode.Nodes.Add(RadTreeNode)

    '                    LoadApplicationSubMenu(SecurityDbContext, _Session.Application, SubModule, RadTreeNode, ModulesList, UserPermissionList)

    '                    If RadTreeNode.Nodes.Count = 0 Then

    '                        ParentRadTreeNode.Nodes.Remove(RadTreeNode)

    '                    Else

    '                        'RadTreeNode.Expanded = True
    '                        'ParentRadTreeNode.Expanded = True

    '                    End If

    '                End If

    '            Else

    '                Try

    '                    UserPermission = (From Entity In UserPermissionList
    '                                      Where Entity.ApplicationID = ApplicationID AndAlso
    '                                            Entity.ModuleID = SubModule.ModuleID AndAlso
    '                                            Entity.UserID = _Session.User.ID
    '                                      Select Entity).SingleOrDefault

    '                Catch ex As Exception
    '                    UserPermission = Nothing
    '                End Try

    '                If Me.CheckModuleAccess(UserPermission, True) = 1 Then

    '                    RadTreeNode = New Telerik.Web.UI.RadTreeNode
    '                    RadTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide
    '                    'RadPanelItem.CssClass = "icon1"
    '                    If SubModule.ModuleDescription = "Job Version" Then
    '                        Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
    '                        Dim JobVersionDescription As String = MyJV.GetAgencyDesc()
    '                        If JobVersionDescription = "" Then
    '                            RadTreeNode.Text = SubModule.ModuleDescription
    '                        Else
    '                            RadTreeNode.Text = JobVersionDescription
    '                        End If
    '                    Else
    '                        RadTreeNode.Text = SubModule.ModuleDescription
    '                    End If
    '                    'RadPanelItem.ImageUrl = "Images/" & AdvantageFramework.Security.LoadImageNameForModule(SubModule, True)

    '                    If SubModule.IsApplication Then

    '                        If String.IsNullOrWhiteSpace(SubModule.WebvantageURL) = False Then

    '                            HasURL = True

    '                            If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

    '                                SubModule.WebvantageURL = String.Format("{0}/{1}", Request.ApplicationPath, SubModule.WebvantageURL)

    '                            End If

    '                        End If
    '                        If SubModule.ModuleCode = AdvantageFramework.Security.Modules.HelpCustomerService_Help.ToString Then

    '                            RadTreeNode.Value = "HELP|"

    '                        Else

    '                            RadTreeNode.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"

    '                            If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

    '                                SubModule.WebvantageURL = String.Format("{0}/{1}", "", SubModule.WebvantageURL)

    '                            End If

    '                        End If

    '                        If SubModule.WebvantageURL <> "" Then


    '                        End If

    '                    ElseIf SubModule.IsReport Then

    '                        If String.IsNullOrWhiteSpace(SubModule.ReportURL) = False Then

    '                            HasURL = True

    '                            If SubModule.ReportURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

    '                                SubModule.ReportURL = String.Format("{0}/{1}", "", SubModule.ReportURL)

    '                            End If

    '                        End If

    '                        RadTreeNode.Value = "RPT|" & SubModule.ModuleID & "|" & SubModule.ReportURL & "|0|0"

    '                    Else

    '                        If String.IsNullOrWhiteSpace(SubModule.WebvantageURL) = False Then

    '                            HasURL = True

    '                            If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

    '                                SubModule.WebvantageURL = String.Format("{0}/{1}", "", SubModule.WebvantageURL)

    '                            End If

    '                        End If

    '                        RadTreeNode.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"

    '                    End If

    '                    'hide items if ASP
    '                    If SubModule.ModuleCode = AdvantageFramework.Security.Modules.Security_Setup_ClientPortalUser.ToString OrElse
    '                            SubModule.ModuleCode = AdvantageFramework.Security.Modules.Security_RepositorySettings.ToString Then

    '                        If HttpContext.Current.Session("ASP_ACTIVE") Is Nothing Then

    '                            If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.AGENCY WHERE ASP_ACTIVE = 1").First >= 1 Then

    '                                HasURL = False
    '                                HttpContext.Current.Session("ASP_ACTIVE") = HasURL

    '                            End If

    '                        Else

    '                            HasURL = HttpContext.Current.Session("ASP_ACTIVE")

    '                        End If

    '                    End If

    '                    If HasURL = True Then

    '                        If Me.IsClientPortal = True And SubModule.ModuleDescription = "Project Schedule" Then

    '                        Else

    '                            ParentRadTreeNode.Nodes.Add(RadTreeNode)
    '                            'ParentRadTreeNode.Expanded = True
    '                            'RadTreeNode.Expanded = True

    '                        End If

    '                    End If

    '                End If

    '            End If

    '        Next

    '    Catch ex As Exception
    '        RadTreeNode = Nothing
    '    End Try

    'End Sub

    'Private Sub LoadNewMenuItems()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    If Me._ShowNewMenu = False Then Exit Sub

    '    Dim HasNewItems As Boolean = False
    '    'Dim NewRadPanelItem As RadPanelItem = Me.RadPanelBarMainMenu.Items.FindItemByValue("RadPanelItemNew")
    '    Dim NewRadTreeViewNode As RadTreeNode = Me.RadTreeViewMainMenu.Nodes.FindNodeByValue("RadPanelItemNew")

    '    If NewRadTreeViewNode IsNot Nothing Then

    '        NewRadTreeViewNode.Nodes.Clear()

    '        'New alert
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Desktop_Alerts) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Alert"
    '                    .Value = "APP|0|" & "Alert_New.aspx?f=" & CType(MiscFN.Source_App.Alert, Integer).ToString() & "|600|860"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New assignment
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Desktop_Alerts) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Assignment"
    '                    .Value = "APP|0|" & "Alert_New.aspx?ps=0&assn=1&f=" & CType(MiscFN.Source_App.JobJacketAlerts, Integer).ToString() & "|600|860"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New calendar item
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Desktop_Calendar) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Calendar Activity"
    '                    .Value = "APP|0|" & "Calendar_NewActivity.aspx?f=" & CType(MiscFN.Source_App.Alert, Integer).ToString() & "|600|860"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Expense Report
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Employee_ExpenseReports) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Expense Report"
    '                    .Value = "APP|0|" & "Expense_Edit.aspx?invoice=new&empcode=" & Session("EmpCode") & "|650|1040"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Time Entry
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Employee_Timesheet) = True Then
    '                Dim q As New AdvantageFramework.Web.QueryString()
    '                Dim ts As New wvTimeSheet.cTimeSheet(_Session.ConnectionString)
    '                With q
    '                    .Page = "Timesheet_CommentsView.aspx"
    '                    .EmpCode = Session("EmpCode")
    '                    .StartDate = ts.FirstDayOfWeek(Now.Date).ToShortDateString()
    '                    .Add("Display", "0")
    '                    .Add("Type", "New")
    '                    .Add("caller", "MainMenu")
    '                    .Add("single", "1")
    '                    .Build()
    '                End With
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Timesheet Entry"
    '                    .Value = "APP|0|" & q.ToString(True) & "|650|1040"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Campaign
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_Campaigns) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Campaign"
    '                    .Value = "APP|0|" & "Campaign_New.aspx?FromWindow=campaignSearch" & "|280|700"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Estimate
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_Estimating) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Estimate"
    '                    .Value = "APP|0|" & "Estimating_AddNew.aspx" & "|580|660"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Job
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Job Jacket"
    '                    .Value = "APP|0|" & "JobTemplate_New.aspx" & "|720|600"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Schedule
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Project Schedule"
    '                    '.Value = "APP|0|" & "TrafficSchedule_AddNew.aspx?c=&d=&p=&j=&jc=" & "|270|690"
    '                    .Value = "APP|0|" & Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create?ClientCode=&DivisionCode=&ProductCode=" & "|270|690"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Purchase Order
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Purchase Order"
    '                    .Value = "APP|0|" & "purchaseorder.aspx?pagemode=new" & "|690|1030"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Billing Approval Batch
    '        Try
    '            If Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Billing_BillingApprovalBatch) = True Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Billing Approval Batch"
    '                    .Value = "APP|0|" & "BillingApproval_Batch.aspx" & "|690|950"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Authorization To Buy
    '        Try
    '            If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy, False) = 1 Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Authorization to Buy"
    '                    .Value = "APP|0|" & "Media_ATB_Add.aspx" & "|350|700"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'New Job Request
    '        Try
    '            If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, False) = 1 Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Job Request"
    '                    .Value = "APP|0|" & "jobVerNew.aspx?mode=request" & "|690|950"
    '                End With
    '                NewRadTreeViewNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try

    '        NewRadTreeViewNode.Visible = HasNewItems

    '    End If

    'End Sub
    'Private Sub LoadNewMenuItemsClientPortal()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Dim HasNewItems As Boolean = False
    '    Dim NewRadTreeNode As RadTreeNode = Me.RadTreeViewMainMenu.Nodes.FindNodeByValue("RadPanelItemNew")

    '    If NewRadTreeNode IsNot Nothing Then

    '        NewRadTreeNode.Nodes.Clear()

    '        'New Job Request
    '        Try
    '            If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, False) = 1 Then
    '                Dim SubItem As New Telerik.Web.UI.RadTreeNode
    '                With SubItem
    '                    .Text = "Job Request"
    '                    .Value = "APP|0|" & "jobVerNew.aspx?mode=request" & "|690|950"
    '                End With
    '                NewRadTreeNode.Nodes.Add(SubItem)
    '                HasNewItems = True
    '            End If
    '        Catch ex As Exception
    '        End Try

    '        NewRadTreeNode.Visible = HasNewItems

    '    End If

    'End Sub

    'Private Sub SetupQuickLaunchItems()

    '    Try

    '        If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '        If _Session IsNot Nothing Then

    '            'objects
    '            Dim ModuleView As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
    '            Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing

    '            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                If SecurityDbContext IsNot Nothing Then

    '                    If IsClientPortal = True Then

    '                        For Each CPUserFavoriteModule In AdvantageFramework.Security.Database.Procedures.CPUserFavoriteModule.LoadByIDAndWorkspaceID(SecurityDbContext, Session("UserID"), Me.CurrentWorkspaceId)

    '                            ModuleView = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadByModuleID(SecurityDbContext, CPUserFavoriteModule.ModuleID)

    '                            If ModuleView IsNot Nothing Then

    '                                If Me.CheckModuleAccess(ModuleView.ModuleCode, False) = 1 Then

    '                                    RadTreeNode = New Telerik.Web.UI.RadTreeNode
    '                                    RadTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide
    '                                    RadTreeNode.Text = ModuleView.ModuleDescription

    '                                    If ModuleView.IsApplication Then

    '                                        RadTreeNode.Value = "APP|" & ModuleView.ModuleID & "|" & ModuleView.WebvantageURL & "|0|0"

    '                                    ElseIf ModuleView.IsReport Then

    '                                        RadTreeNode.Value = "RPT|" & ModuleView.ModuleID & "|" & ModuleView.ReportURL & "|0|0"

    '                                    Else

    '                                        RadTreeNode.Value = "APP|" & ModuleView.ModuleID & "|" & ModuleView.WebvantageURL & "|0|0"

    '                                    End If

    '                                    Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites").Nodes.Add(RadTreeNode)
    '                                    Me._HasFavoriteApps = True

    '                                End If

    '                            End If

    '                        Next

    '                    Else

    '                        For Each UserFavoriteModule In AdvantageFramework.Security.Database.Procedures.UserFavoriteModule.LoadByUserCodeAndWorkspaceID(SecurityDbContext, _Session.UserCode, Me.CurrentWorkspaceId)

    '                            Try

    '                                ModuleView = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadByModuleID(SecurityDbContext, UserFavoriteModule.ModuleID)

    '                                If ModuleView IsNot Nothing Then

    '                                    If Me.CheckModuleAccess(ModuleView.ModuleCode, False) = 1 Then

    '                                        RadTreeNode = Nothing
    '                                        RadTreeNode = New Telerik.Web.UI.RadTreeNode

    '                                        RadTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide
    '                                        RadTreeNode.Text = ModuleView.ModuleDescription

    '                                        If RadTreeNode IsNot Nothing Then

    '                                            If ModuleView.ModuleID > 0 Then

    '                                                If ModuleView.IsApplication Then

    '                                                    If String.IsNullOrWhiteSpace(ModuleView.WebvantageURL) = False Then

    '                                                        RadTreeNode.Value = "APP|" & ModuleView.ModuleID & "|" & ModuleView.WebvantageURL & "|0|0"

    '                                                    End If

    '                                                ElseIf ModuleView.IsReport Then

    '                                                    If String.IsNullOrWhiteSpace(ModuleView.ReportURL) = False Then

    '                                                        RadTreeNode.Value = "RPT|" & ModuleView.ModuleID & "|" & ModuleView.ReportURL & "|0|0"

    '                                                    End If

    '                                                Else

    '                                                    If String.IsNullOrWhiteSpace(ModuleView.WebvantageURL) = False Then

    '                                                        RadTreeNode.Value = "APP|" & ModuleView.ModuleID & "|" & ModuleView.WebvantageURL & "|0|0"

    '                                                    End If

    '                                                End If

    '                                            End If

    '                                            Try

    '                                                If Me.RadTreeViewUser IsNot Nothing AndAlso RadTreeNode IsNot Nothing Then

    '                                                    If Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites") IsNot Nothing Then

    '                                                        Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites").Nodes.Add(RadTreeNode)
    '                                                        Me._HasFavoriteApps = True

    '                                                    End If

    '                                                End If

    '                                            Catch ex As Exception
    '                                            End Try

    '                                        End If

    '                                    End If

    '                                End If

    '                            Catch ex As Exception
    '                            End Try

    '                        Next

    '                    End If

    '                End If

    '            End Using

    '        End If

    '    Catch ex As Exception
    '    End Try

    'End Sub

#End Region
#Region " Workspaces "

    'Private Sub GetSpaces()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Try

    '        Dim SQL As New System.Text.StringBuilder

    '        If Me.IsClientPortal = True Then

    '            With SQL

    '                .Append("SELECT WORKSPACE_ID, [NAME] FROM CP_USER_WORKSPACE WITH(NOLOCK) WHERE CDP_CONTACT_ID = ")
    '                .Append(Session("UserID"))
    '                .Append(" ORDER BY SORT_ORDER;")

    '            End With

    '        Else

    '            With SQL

    '                .Append("SELECT WORKSPACE_ID, [NAME] FROM WV_USER_WORKSPACE WITH(NOLOCK) WHERE USER_CODE = '")
    '                .Append(Session("UserCode"))
    '                .Append("' AND (CP = 0 OR CP IS NULL)")
    '                .Append(" ORDER BY SORT_ORDER;")

    '            End With

    '        End If

    '        Me.ImageButtonNextWorkspace.Visible = False
    '        Me.ImageButtonPreviousWorkspace.Visible = False

    '        Me.RadContextMenuWorkspaces.FindItemByValue("PreviousWorkspace").Visible = False
    '        Me.RadContextMenuWorkspaces.FindItemByValue("NextWorkspace").Visible = False
    '        Me.RadContextMenuWorkspaces.FindItemByValue("PreviousWorkspaceSeparator").Visible = False
    '        Me.RadContextMenuWorkspaces.FindItemByValue("NextWorkspaceSeparator").Visible = False

    '        Dim dt As New DataTable

    '        dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, SQL.ToString(), "DtWorkspaces")

    '        If Not dt Is Nothing Then

    '            If dt.Rows.Count > 0 Then

    '                For i As Integer = 0 To dt.Rows.Count - 1

    '                    Dim w As New Telerik.Web.UI.RadTreeNode
    '                    w.ExpandMode = TreeNodeExpandMode.ClientSide

    '                    With w

    '                        .Text = dt.Rows(i)("NAME").ToString()
    '                        .Value = "WORKSPACE|" & dt.Rows(i)("WORKSPACE_ID").ToString()

    '                    End With

    '                    Try

    '                        If Me.CurrentWorkspaceId = CType(dt.Rows(i)("WORKSPACE_ID"), Integer) Then

    '                            w.Selected = True

    '                        End If

    '                    Catch ex As Exception

    '                    End Try

    '                    Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserWorkspaces").Nodes.Add(w)

    '                Next

    '            End If

    '            If dt.Rows.Count > 1 OrElse Me._IsDefaultWorkspace = True Then

    '                Me.ImageButtonNextWorkspace.Visible = True
    '                Me.ImageButtonPreviousWorkspace.Visible = True

    '                Me.RadContextMenuWorkspaces.FindItemByValue("PreviousWorkspace").Visible = True
    '                Me.RadContextMenuWorkspaces.FindItemByValue("NextWorkspace").Visible = True
    '                Me.RadContextMenuWorkspaces.FindItemByValue("PreviousWorkspaceSeparator").Visible = True
    '                Me.RadContextMenuWorkspaces.FindItemByValue("NextWorkspaceSeparator").Visible = True

    '            End If

    '            If dt.Rows.Count = 0 Then 'Only dashboard is available and you are on it

    '                Me.ImageButtonNextWorkspace.Visible = False
    '                Me.ImageButtonPreviousWorkspace.Visible = False

    '                Me.RadContextMenuWorkspaces.FindItemByValue("PreviousWorkspace").Visible = False
    '                Me.RadContextMenuWorkspaces.FindItemByValue("NextWorkspace").Visible = False
    '                Me.RadContextMenuWorkspaces.FindItemByValue("PreviousWorkspaceSeparator").Visible = False
    '                Me.RadContextMenuWorkspaces.FindItemByValue("NextWorkspaceSeparator").Visible = False

    '                Me.ImageButtonDashboard.Visible = False

    '            End If

    '        End If

    '        Dim ManageSpace As New Telerik.Web.UI.RadTreeNode
    '        With ManageSpace

    '            .Text = "Manage Workspaces"
    '            .Value = ""
    '            .ExpandMode = TreeNodeExpandMode.ClientSide
    '            .Attributes.Add("onclick", "OpenWorkspaceManager();return false;")

    '        End With
    '        Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserWorkspaces").Nodes.Add(ManageSpace)

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub LoadDefaultWorkspace()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Me.DefaultWorkspaceLinkUserReviewsPanel.Visible = False

    '    Me.DivDefaultWorkspace.Visible = Me._IsDefaultWorkspace = True

    '    Me.LinkUserSchedulePanel.Visible = Not Me._IsDefaultWorkspace = True
    '    Me.HrCountSeparator.Visible = Not Me._IsDefaultWorkspace = True
    '    Me.LinkUserAssignmentsPanel.Visible = Not Me._IsDefaultWorkspace = True
    '    Me.LinkUserAlertsPanel.Visible = Not Me._IsDefaultWorkspace = True
    '    Me.LinkUserReviewsPanel.Visible = Not Me._IsDefaultWorkspace = True
    '    Me.LinkUserTasksPanel.Visible = Not Me._IsDefaultWorkspace = True

    '    If Me._IsDefaultWorkspace = True Then

    '        AdvantageFramework.Web.Presentation.Controls.DivHide(Me.DivUserPanelTimeCount)

    '        Me.RadDockLayoutParent.Visible = False
    '        Me.LoadDefaultWorkspaceFavorites()

    '        If cApplication.IsProofingToolActive(Me.SecuritySession) = True Then

    '            Me.DefaultWorkspaceLinkUserReviewsPanel.Visible = True

    '        Else

    '            Me.DefaultWorkspaceLinkUserReviewsPanel.Visible = False

    '        End If

    '        If IsClientPortal = True Then

    '            Me.PlaceHolderDefaultWorkspaceRight.Visible = False
    '            Me.RadRadialGaugeHoursToday.Visible = False
    '            Me.RadRadialGaugeHoursThisWeek.Visible = False
    '            Me.DefaultWorkspaceLinkUserAssignmentsPanel.Visible = False

    '        End If

    '    Else

    '        Me.LinkUserSchedulePanel.HRef = "#DivUserSchedule"
    '        Me.PanelScript &= "$('#LinkUserSchedulePanel').panelslider({ side: 'right', clickClose: false, duration: 500 });"

    '        Me._CalendarUserControl = CType(LoadControl("DOS\DesktopCardsMyCalendar.ascx"), Webvantage.DesktopCardsMyCalendar)
    '        Me.PlaceHolderUserSchedule.Controls.Add(Me._CalendarUserControl)

    '        Me._TasksUserControl = CType(LoadControl("DOS\DesktopCardsMyTasks.ascx"), Webvantage.DesktopCardsMyTasks)

    '        Me.LinkUserAssignmentsPanel.HRef = "#DivUserAssignments"
    '        Me.LinkUserAlertsPanel.HRef = "#DivUserAlerts"
    '        Me.LinkUserTasksPanel.HRef = "#DivUserTasks"

    '        If cApplication.IsProofingToolActive(Me.SecuritySession) = True Then

    '            'Me.LinkUserReviewsPanel.HRef = "#DivUserReviews"
    '            'Me.PanelScript &= "$('#LinkUserReviewsPanel').panelslider({ side: 'right', clickClose: false, duration: 500 });"

    '        Else

    '            Me.LinkUserReviewsPanel.Visible = False

    '        End If

    '        JavascriptCalendarUpdatePanelName = Me.SetUpdatePanelJavascriptAction("UpdatePanelUserSchedule")
    '        JavascriptMainLeftContentUpdatePanelName = Me.SetUpdatePanelJavascriptAction("")

    '        If IsClientPortal = True Then

    '            Me.DivUserPanelAssignmentCount.Visible = False
    '            Me.DivUserPanelTimeCount.Visible = False

    '        End If

    '    End If

    '    If IsClientPortal = True Then

    '        Me.LinkUserBookmarksPanel.Visible = False
    '        Me.ImageButtonSetColors.Visible = False
    '        Me.ImageButtonTheme.Visible = False
    '    Else

    '        'Me.PanelScript &= "$('#LinkUserBookmarksPanel').panelslider({ side: 'right', clickClose: true, duration: 500 });"
    '        'Me.LinkUserBookmarksPanel.HRef = "#DivUserBookmarks"
    '        'Me._BookmarksUserControl = CType(LoadControl("DOS\DesktopCardsMyBookmarks.ascx"), Webvantage.DesktopCardsMyBookmarks)

    '    End If

    'End Sub
    'Private Sub LoadDefaultWorkspaceMainContent()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    If Me._CurrentDefaultContent = DefaultMainContent.MyReviews AndAlso cApplication.IsProofingToolActive(_Session) = False Then

    '        Me._CurrentDefaultContent = DefaultMainContent.MyAlerts

    '    End If

    '    Dim DesktopObjectName As String = String.Empty

    '    Select Case Me._CurrentDefaultContent
    '        Case DefaultMainContent.MyTasks

    '            ''''Me._TasksUserControl = CType(LoadControl("DOS\DesktopCardsMyTasks.ascx"), Webvantage.DesktopCardsMyTasks)
    '            ''''Me._TasksUserControl.PageSize = 35
    '            ''''Me._TasksUserControl.MoreButtonVisible = False
    '            '''''Me._TasksUserControl.LoadData(False)
    '            ''''Me._TasksUserControl.ShowTitle = True

    '            ''''Me.PlaceHolderDefaultWorkspaceLeftMiddle.Controls.Add(Me._TasksUserControl)
    '            DesktopObjectName = "DesktopCardsMyTasks.ascx"

    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Add("class", "dfltws-badge badge-outline-color")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Add("class", "dfltws-badge")

    '        Case DefaultMainContent.MyAlerts

    '            ''''Me._AlertsUserControl = CType(LoadControl("DOS\DesktopCardsMyAssignments.ascx"), Webvantage.DesktopCardsMyAssignments)
    '            ''''Me._AlertsUserControl.LoadAlertType = DesktopCardsMyAssignments.LoadType.Alerts
    '            ''''Me._AlertsUserControl.ShowMoreButton = True
    '            ''''Me._AlertsUserControl.ShowTitle = True
    '            ''''Me._AlertsUserControl.IsDashboard = True

    '            ''''Me.PlaceHolderDefaultWorkspaceLeftMiddle.Controls.Add(Me._AlertsUserControl)
    '            DesktopObjectName = "DesktopCardsMyAssignments.ascx&card_type=1"

    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Add("class", "dfltws-badge badge-outline-color")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Add("class", "dfltws-badge")

    '        Case DefaultMainContent.MyAssignments

    '            ''''Me._AssignmentsUserControl = CType(LoadControl("DOS\DesktopCardsMyAssignments.ascx"), Webvantage.DesktopCardsMyAssignments)
    '            ''''Me._AssignmentsUserControl.LoadAlertType = DesktopCardsMyAssignments.LoadType.Assignments
    '            ''''Me._AssignmentsUserControl.ShowMoreButton = True
    '            ''''Me._AssignmentsUserControl.ShowTitle = True
    '            ''''Me._AssignmentsUserControl.IsDashboard = True

    '            ''''Me.PlaceHolderDefaultWorkspaceLeftMiddle.Controls.Add(Me._AssignmentsUserControl)
    '            DesktopObjectName = "DesktopCardsMyAssignments.ascx&card_type=2"

    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Add("class", "dfltws-badge badge-outline-color")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Add("class", "dfltws-badge")

    '        Case DefaultMainContent.MyReviews

    '            ''''Me._ReviewsUserControl = CType(LoadControl("DOS\DesktopCardsMyAssignments.ascx"), Webvantage.DesktopCardsMyAssignments)
    '            ''''Me._ReviewsUserControl.LoadAlertType = DesktopCardsMyAssignments.LoadType.Reviews
    '            ''''Me._ReviewsUserControl.ShowMoreButton = True
    '            ''''Me._ReviewsUserControl.ShowTitle = True
    '            ''''Me._ReviewsUserControl.IsDashboard = True

    '            ''''Me.PlaceHolderDefaultWorkspaceLeftMiddle.Controls.Add(Me._ReviewsUserControl)
    '            DesktopObjectName = "DesktopCardsMyAssignments.ascx&card_type=3"

    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceTasksBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAlertsBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceAssignmentsBadge.Attributes.Add("class", "dfltws-badge")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Remove("class")
    '            Me.DivDefaultWorkspaceReviewsBadge.Attributes.Add("class", "dfltws-badge badge-outline-color")

    '    End Select

    '    Me.iFrameDefaultWorkspaceLeftMiddle.Attributes.Remove("src")
    '    Me.iFrameDefaultWorkspaceLeftMiddle.Attributes.Add("src", String.Format("DesktopObjectWindow.aspx?dtoname={0}", DesktopObjectName))

    '    Me._CalendarUserControl = CType(LoadControl("DOS\DesktopCardsMyCalendar.ascx"), Webvantage.DesktopCardsMyCalendar)
    '    Me._CalendarUserControl.ShowTasks = Not Me._CurrentDefaultContent = DefaultMainContent.MyTasks
    '    Me.PlaceHolderDefaultWorkspaceRight.Controls.Add(Me._CalendarUserControl)

    'End Sub
    'Private Sub LoadDefaultWorkspaceFavorites()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Dim Favorites As Generic.List(Of AdvantageFramework.Web.DefaultWorkspaceFavorite) = Nothing
    '    Dim ShowFavorites As Boolean = False

    '    Try

    '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)


    '            Favorites = DbContext.Database.SqlQuery(Of AdvantageFramework.Web.DefaultWorkspaceFavorite)(String.Format("SELECT DISTINCT CASE WHEN RTRIM(LTRIM(SEC_MODULE_INFO.WV_URL)) = '' OR SEC_MODULE_INFO.WV_URL IS NULL THEN WV_RPT_URL ELSE SEC_MODULE_INFO.WV_URL END AS WebvantageUrl, SEC_MODULE.DESCRIPTION AS Description, SEC_MODULE.SEC_MODULE_CODE AS ModuleCode " &
    '                                                                                                                      " FROM WV_USER_QUICK_LAUNCH_APPS WITH (NOLOCK) INNER JOIN " &
    '                                                                                                                      " SEC_MODULE WITH (NOLOCK) ON WV_USER_QUICK_LAUNCH_APPS.APPID = SEC_MODULE.SEC_MODULE_ID INNER JOIN " &
    '                                                                                                                      " SEC_MODULE_INFO WITH (NOLOCK) ON SEC_MODULE.SEC_MODULE_INFO_ID = SEC_MODULE_INFO.SEC_MODULE_INFO_ID INNER JOIN " &
    '                                                                                                                      " WV_USER_WORKSPACE ON WV_USER_QUICK_LAUNCH_APPS.TABNO = WV_USER_WORKSPACE.WORKSPACE_ID AND " &
    '                                                                                                                      " WV_USER_QUICK_LAUNCH_APPS.USERID = WV_USER_WORKSPACE.USER_CODE " &
    '                                                                                                                      " WHERE (WV_USER_QUICK_LAUNCH_APPS.USERID = '{0}') " &
    '                                                                                                                      " ORDER BY SEC_MODULE.[DESCRIPTION];", _Session.UserCode)).ToList()
    '            If Favorites IsNot Nothing AndAlso Favorites.Count > 0 Then

    '                Me.RepeaterDefaultWorkspaceFavorites.DataSource = Favorites
    '                Me.RepeaterDefaultWorkspaceFavorites.DataBind()
    '                ShowFavorites = True

    '            End If

    '        End Using

    '    Catch ex As Exception

    '        ShowFavorites = False

    '    End Try

    '    Me.DivDefaultWorkspaceLeftMiddle.Attributes.Remove("class")
    '    Me.DivDefaultWorkspaceLeftBottom.Attributes.Remove("class")

    '    If ShowFavorites = True Then

    '        Me.DivDefaultWorkspaceLeftMiddle.Attributes.Add("class", "dfltws-left-middle")
    '        Me.DivDefaultWorkspaceLeftBottom.Attributes.Add("class", "dfltws-left-bottom")

    '    Else

    '        Me.DivDefaultWorkspaceLeftMiddle.Attributes.Add("class", "dfltws-left-middle-no-favorites")
    '        Me.DivDefaultWorkspaceLeftBottom.Attributes.Add("class", "dfltws-left-bottom-no-favorites")

    '    End If

    'End Sub
    'Private Function SetUpdatePanelJavascriptAction(ByVal PanelName As String) As String

    '    If Me.CheckUserNotTimedOut() = True Then Exit Function
    '    PanelName = PanelName.Trim()

    '    If PanelName = "" Then

    '        Return "return false;"

    '    Else

    '        Return String.Format("__doPostBack(""{0}"","""");", PanelName)

    '    End If

    'End Function

    'Private Sub RepeaterDefaultWorkspaceFavorites_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RepeaterDefaultWorkspaceFavorites.ItemDataBound

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Select Case e.Item.ItemType
    '        Case ListItemType.Item, ListItemType.AlternatingItem

    '            Dim Favorite As New AdvantageFramework.Web.DefaultWorkspaceFavorite
    '            Dim FavoriteDiv As HtmlControls.HtmlControl

    '            Favorite = e.Item.DataItem
    '            FavoriteDiv = e.Item.FindControl("DivFavorite")

    '            If Favorite IsNot Nothing AndAlso FavoriteDiv IsNot Nothing Then

    '                FavoriteDiv.Attributes.Add("onclick", "OpenRadWindow('','" & Favorite.WebvantageUrl & "');return false;")

    '                'If Favorite.ModuleCode.Contains("Desktop") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-desktop")

    '                'ElseIf Favorite.ModuleCode.Contains("Employee") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-employee")

    '                'ElseIf Favorite.ModuleCode.Contains("ProjectManagement") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-project-management")

    '                'ElseIf Favorite.ModuleCode.Contains("Media") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-media")

    '                'ElseIf Favorite.ModuleCode.Contains("Billing") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-billing")

    '                'ElseIf Favorite.ModuleCode.Contains("FinanceAccounting") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-finance-and-accounting")

    '                'ElseIf Favorite.ModuleCode.Contains("Maintenance") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-maintenance")

    '                'ElseIf Favorite.ModuleCode.Contains("Security") Then

    '                '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FavoriteDiv, "application-type-security")

    '                'End If

    '            End If

    '    End Select

    'End Sub

    'Private Sub NextWorkspace()

    '    Me.GoToWorkspace("+")

    'End Sub
    'Private Sub PreviousWorkspace()
    '    Me.GoToWorkspace("-")
    'End Sub
    'Private Sub GoToWorkspace(ByVal MoveDirection As String)

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Dim arP(4) As System.Data.SqlClient.SqlParameter
    '    Dim GoToWorkspaceId As Integer

    '    Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
    '    pUserCode.Value = Session("UserCode")
    '    arP(0) = pUserCode

    '    Dim pMoveDirection As New System.Data.SqlClient.SqlParameter("@MOVE_DIRECTION", SqlDbType.VarChar, 1)
    '    pMoveDirection.Value = MoveDirection
    '    arP(1) = pMoveDirection

    '    Dim pIsDashboard As New System.Data.SqlClient.SqlParameter("@IS_DASHBOARD", SqlDbType.Bit)
    '    pIsDashboard.Value = Me._IsDefaultWorkspace
    '    arP(2) = pIsDashboard

    '    If IsClientPortal = True Then

    '        Dim pCPID As New System.Data.SqlClient.SqlParameter("@CPID", SqlDbType.Int)
    '        pCPID.Value = Session("UserID")
    '        arP(3) = pCPID

    '        GoToWorkspaceId = SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.StoredProcedure, "usp_cp_WORKSPACE_NAVIGATE", arP)

    '    Else

    '        GoToWorkspaceId = SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_WORKSPACE_NAVIGATE", arP)

    '    End If

    '    'Dim oAppVars As New cAppVars(cAppVars.Application.MY_SETTINGS)
    '    'oAppVars.Clear()

    '    Dim q As New AdvantageFramework.Web.QueryString()
    '    With q

    '        .Page = "Default.aspx"
    '        .WorkspaceId = CType(GoToWorkspaceId, Integer)
    '        .Add("click", "1")
    '        .Go(False, True)

    '    End With

    'End Sub

#End Region
#Region " Dock and Objects "

    'Private Sub LoadCurrentWorkspaceObjects(ByVal WorkSpaceId As Integer)

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    'objects
    '    Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
    '    Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
    '    Dim UserWorkspaceCP As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
    '    Dim RadDock As Telerik.Web.UI.RadDock = Nothing
    '    Dim WorkspaceHasObjects As Boolean = False
    '    Dim DesktopObjectTitle As String = ""
    '    Dim DesktopObjectName As String = ""
    '    Dim WorkspaceHasProjectViewpointObject As Boolean = False
    '    Dim AddObject As Boolean = True
    '    Dim ProjectViewpointAccess As New ArrayList()
    '    Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing
    '    Dim IsUsingLeftDock As Boolean = False

    '    Try

    '        If Me.CurrentWorkspaceId > 0 Then

    '            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                _CurrentDockStates = New Generic.List(Of Telerik.Web.UI.DockState)
    '                ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadActiveModulesByApplicationID(SecurityDbContext,
    '                                                                                                                          CType(AdvantageFramework.Security.Application.Webvantage, Integer)).ToList()

    '                If Me.IsClientPortal = True Then

    '                    Try

    '                        UserWorkspaceCP = (From UsrWrkSpace In AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Load(SecurityDbContext).Include("ClientPortalWorkspaceObjects")
    '                                           Where UsrWrkSpace.ID = Me.CurrentWorkspaceId
    '                                           Select UsrWrkSpace).Single

    '                    Catch ex As Exception
    '                        UserWorkspaceCP = Nothing
    '                    End Try

    '                    If UserWorkspaceCP IsNot Nothing Then

    '                        ''Me.CurrentWorkspaceName = UserWorkspaceCP.Name
    '                        Me.Page.Title = UserWorkspaceCP.Name

    '                        For Each ClientPortalWorkspaceObject In UserWorkspaceCP.ClientPortalWorkspaceObjects.OrderBy(Function(WorkObject) WorkObject.SortOrder)

    '                            Try

    '                                [Module] = ModulesList.First(Function(ModView) ModView.ModuleID = ClientPortalWorkspaceObject.DesktopObjectID)

    '                            Catch ex As Exception
    '                                [Module] = Nothing
    '                            End Try

    '                            If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

    '                                If [Module].DesktopObjectName.Contains("DesktopCards") Then

    '                                    AddObject = False

    '                                Else

    '                                    AddObject = True

    '                                End If

    '                                If AddObject = True Then

    '                                    If [Module].DesktopObjectName.Contains("DesktopProjectViewpoint.ascx") Then

    '                                        DesktopObjectTitle = "Project Viewpoint"
    '                                        DesktopObjectName = "DesktopProjectViewpoint.ascx"

    '                                        If [Module].DesktopObjectName.Contains("?View=0") Then
    '                                            ProjectViewpointAccess.Add(0)
    '                                        ElseIf [Module].DesktopObjectName.Contains("?View=2") Then
    '                                            ProjectViewpointAccess.Add(1)
    '                                        ElseIf [Module].DesktopObjectName.Contains("?View=3") Then
    '                                            ProjectViewpointAccess.Add(2)
    '                                        End If

    '                                        If WorkspaceHasProjectViewpointObject = False Then
    '                                            WorkspaceHasProjectViewpointObject = True
    '                                            AddObject = True
    '                                        Else
    '                                            AddObject = False
    '                                        End If

    '                                    Else

    '                                        DesktopObjectTitle = [Module].ModuleDescription.Replace("(Cards)", "")
    '                                        DesktopObjectName = [Module].DesktopObjectName.Replace("dos\", "")
    '                                        AddObject = True

    '                                    End If

    '                                End If

    '                                If AddObject = True Then

    '                                    If Me._HasUserAddedBookmarkDO = False Then

    '                                        Me._HasUserAddedBookmarkDO = [Module].DesktopObjectName.Contains("DesktopBookmarks.ascx")

    '                                    End If
    '                                    '' ''If Me._HasScheduleCard = False Then

    '                                    '' ''    Me._HasScheduleCard = [Module].DesktopObjectName.Contains("DesktopBookmarks.ascx")

    '                                    '' ''End If
    '                                    '' ''If Me._HasBookmarkCard = False Then

    '                                    '' ''    Me._HasBookmarkCard = [Module].DesktopObjectName.Contains("DesktopCardsMyBookmarks.ascx")

    '                                    '' ''End If
    '                                    '' ''If Me._HasAlertsAndAssignmentsCard = False Then

    '                                    '' ''    Me._HasAlertsAndAssignmentsCard = [Module].DesktopObjectName.Contains("DesktopCardsMyAssignments.ascx")

    '                                    '' ''End If
    '                                    '' ''If Me._HasTasksCard = False Then

    '                                    '' ''    Me._HasTasksCard = [Module].DesktopObjectName.Contains("DesktopCardsMyTasks.ascx")

    '                                    '' ''End If

    '                                    RadDock = CreateRadDock(DesktopObjectTitle, DesktopObjectName, ClientPortalWorkspaceObject.ID,
    '                                                               ClientPortalWorkspaceObject.Height.GetValueOrDefault(0), ClientPortalWorkspaceObject.Width.GetValueOrDefault(0),
    '                                                               ClientPortalWorkspaceObject.TopCoordinate.GetValueOrDefault(0), ClientPortalWorkspaceObject.LeftCoordinate.GetValueOrDefault(0))

    '                                    LoadWorkspaceObject(RadDock)

    '                                    Try
    '                                        Select Case ClientPortalWorkspaceObject.ZoneID
    '                                            Case "RadDockZoneLeft"
    '                                                'RadDock.Width = New Unit(400, UnitType.Pixel)
    '                                                RadDockZoneLeft.Controls.Add(RadDock)
    '                                                WorkspaceHasObjects = True
    '                                                IsUsingLeftDock = True
    '                                            Case Else
    '                                                'RadDock.Width = New Unit(800, UnitType.Pixel)
    '                                                RadDockZoneCenter.Controls.Add(RadDock)
    '                                                WorkspaceHasObjects = True
    '                                        End Select
    '                                    Catch ex As Exception
    '                                    End Try

    '                                End If

    '                            End If

    '                        Next
    '                        If Session("currentPVView") Is Nothing Then
    '                            Session("currentPVView") = 0 'init anyway?
    '                            Try
    '                                If ProjectViewpointAccess.Count > 0 Then
    '                                    ProjectViewpointAccess.Sort()
    '                                    If IsNumeric(ProjectViewpointAccess(0)) = True Then
    '                                        Session("currentPVView") = ProjectViewpointAccess(0)
    '                                    End If
    '                                End If
    '                            Catch ex As Exception
    '                            End Try
    '                        End If

    '                    End If

    '                Else 'Webvantage

    '                    Try

    '                        UserWorkspace = (From UsrWrkSpace In AdvantageFramework.Security.Database.Procedures.UserWorkspace.Load(SecurityDbContext).Include("WorkspaceObjects")
    '                                         Where UsrWrkSpace.ID = Me.CurrentWorkspaceId
    '                                         Select UsrWrkSpace).Single

    '                    Catch ex As Exception
    '                        UserWorkspace = Nothing
    '                    End Try

    '                    If UserWorkspace IsNot Nothing Then

    '                        '''Me.CurrentWorkspaceName = UserWorkspace.Name
    '                        Me.Page.Title = UserWorkspace.Name

    '                        For Each WorkspaceObject In UserWorkspace.WorkspaceObjects.OrderBy(Function(WorkObject) WorkObject.SortOrder)

    '                            Try
    '                                [Module] = ModulesList.First(Function(ModView) ModView.ModuleID = WorkspaceObject.DesktopObjectID)

    '                            Catch ex As Exception
    '                                [Module] = Nothing
    '                            End Try

    '                            If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

    '                                If [Module].DesktopObjectName.Contains("DesktopCards") Then

    '                                    AddObject = False

    '                                End If

    '                                If AddObject = True Then

    '                                    If [Module].DesktopObjectName.Contains("DesktopProjectViewpoint.ascx") Then

    '                                        DesktopObjectTitle = "Project Viewpoint"
    '                                        DesktopObjectName = "DesktopProjectViewpoint.ascx"

    '                                        If [Module].DesktopObjectName.Contains("?View=0") Then
    '                                            ProjectViewpointAccess.Add(0)
    '                                        ElseIf [Module].DesktopObjectName.Contains("?View=2") Then
    '                                            ProjectViewpointAccess.Add(1)
    '                                        ElseIf [Module].DesktopObjectName.Contains("?View=3") Then
    '                                            ProjectViewpointAccess.Add(2)
    '                                        End If

    '                                        If WorkspaceHasProjectViewpointObject = False Then

    '                                            WorkspaceHasProjectViewpointObject = True
    '                                            AddObject = True

    '                                        Else

    '                                            AddObject = False

    '                                        End If

    '                                    Else

    '                                        DesktopObjectTitle = [Module].ModuleDescription.Replace("(Cards)", "")
    '                                        DesktopObjectName = [Module].DesktopObjectName.Replace("dos\", "")
    '                                        AddObject = True

    '                                    End If

    '                                End If

    '                                If AddObject = True Then

    '                                    If Me._HasUserAddedBookmarkDO = False Then

    '                                        Me._HasUserAddedBookmarkDO = [Module].DesktopObjectName.Contains("DesktopBookmarks.ascx")

    '                                    End If
    '                                    '' ''If Me._HasScheduleCard = False Then

    '                                    '' ''    Me._HasScheduleCard = [Module].DesktopObjectName.Contains("DesktopBookmarks.ascx")

    '                                    '' ''End If
    '                                    '' ''If Me._HasBookmarkCard = False Then

    '                                    '' ''    Me._HasBookmarkCard = [Module].DesktopObjectName.Contains("DesktopCardsMyBookmarks.ascx")

    '                                    '' ''End If
    '                                    '' ''If Me._HasAlertsAndAssignmentsCard = False Then

    '                                    '' ''    Me._HasAlertsAndAssignmentsCard = [Module].DesktopObjectName.Contains("DesktopCardsMyAssignments.ascx")

    '                                    '' ''End If
    '                                    '' ''If Me._HasTasksCard = False Then

    '                                    '' ''    Me._HasTasksCard = [Module].DesktopObjectName.Contains("DesktopCardsMyTasks.ascx")

    '                                    '' ''End If

    '                                    RadDock = CreateRadDock(DesktopObjectTitle, DesktopObjectName, WorkspaceObject.ID,
    '                                                                             WorkspaceObject.Height.GetValueOrDefault(0), WorkspaceObject.Width.GetValueOrDefault(0),
    '                                                                             WorkspaceObject.TopCoordinate.GetValueOrDefault(0), WorkspaceObject.LeftCoordinate.GetValueOrDefault(0))

    '                                    LoadWorkspaceObject(RadDock)

    '                                    Try
    '                                        Select Case WorkspaceObject.ZoneID
    '                                            Case "RadDockZoneLeft"
    '                                                'RadDock.Width = New Unit(400, UnitType.Pixel)
    '                                                RadDockZoneLeft.Controls.Add(RadDock)
    '                                                WorkspaceHasObjects = True
    '                                                IsUsingLeftDock = True
    '                                            Case Else
    '                                                'RadDock.Width = New Unit(800, UnitType.Pixel)
    '                                                RadDockZoneCenter.Controls.Add(RadDock)
    '                                                WorkspaceHasObjects = True
    '                                        End Select
    '                                    Catch ex As Exception
    '                                    End Try

    '                                End If


    '                            End If

    '                        Next
    '                        If Session("currentPVView") Is Nothing Then
    '                            Session("currentPVView") = 0 'init anyway?
    '                            Try
    '                                If ProjectViewpointAccess.Count > 0 Then
    '                                    ProjectViewpointAccess.Sort()
    '                                    If IsNumeric(ProjectViewpointAccess(0)) = True Then
    '                                        Session("currentPVView") = ProjectViewpointAccess(0)
    '                                    End If
    '                                End If
    '                            Catch ex As Exception
    '                            End Try
    '                        End If

    '                    End If
    '                End If

    '            End Using

    '            'Me.DivLeftDock = Me.RadDockLayoutParent.FindControl("DivLeftDock")
    '            'Me.DivRightDock = Me.RadDockLayoutParent.FindControl("DivRightDock")

    '            Me.DivLeftDock.Attributes.Clear()
    '            Me.DivRightDock.Attributes.Clear()
    '            Me.DivLeftDock.Visible = True
    '            Me.DivRightDock.Visible = True

    '            If IsUsingLeftDock = False Then

    '                Me.DivLeftDock.Attributes.Add("class", "no-left-dock")
    '                Me.DivRightDock.Attributes.Add("class", "full-right-dock")
    '                Me.RadDockZoneLeft.Visible = False
    '            Else

    '                Me.DivLeftDock.Attributes.Add("class", "left-dock")
    '                Me.DivRightDock.Attributes.Add("class", "right-dock")

    '            End If

    '        End If

    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Private Function CreateRadDock(ByVal UserControlTitle As String, ByVal UserControlPage As String, ByVal RecordId As Integer, Optional ByVal Height As Integer = 0,
    '                               Optional ByVal Width As Integer = 0, Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) As Telerik.Web.UI.RadDock

    '    If Me.CheckUserNotTimedOut() = True Then Exit Function
    '    If Me._IsFloatingObjects = True Then Exit Function

    '    Dim docksCount As Integer = 0 ' _CurrentDockStates.Count
    '    Dim dock As New Telerik.Web.UI.RadDock()

    '    With dock

    '        .Tag = "DOS\" & UserControlPage

    '        .ID = String.Format("RadDock_{0}_{1}|{2}", docksCount, UserControlPage.Replace(".", "_"), RecordId)
    '        .Title = String.Format(UserControlTitle)
    '        .UniqueName = Guid.NewGuid().ToString()

    '        .DockMode = Telerik.Web.UI.DockMode.Docked

    '        .EnableDrag = False
    '        .Resizable = False

    '        .EnableAnimation = False

    '        Dim ExpandCollapseCommand As New Telerik.Web.UI.DockExpandCollapseCommand
    '        .Commands.Add(ExpandCollapseCommand)

    '    End With

    '    Return dock

    'End Function
    'Private Sub LoadWorkspaceObject(ByVal dock As Telerik.Web.UI.RadDock)

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    If Not String.IsNullOrEmpty(dock.Tag) Then

    '        Try

    '            Select Case dock.Tag

    '                Case "DOS\DesktopMyQvA.ascx", "DOS\DesktopQvA.ascx?m=2"

    '                    Dim ctrl As Webvantage.DesktopQvA
    '                    ctrl = CType(LoadControl("~\DOS\DesktopQvA.ascx"), Webvantage.DesktopQvA)
    '                    ctrl.CurrentPageMode = DesktopQvA.PageMode.MyQvA

    '                    dock.ContentContainer.Controls.Add(ctrl)

    '                Case Else

    '                    Dim DesktopObject As System.Web.UI.Control

    '                    DesktopObject = LoadControl(dock.Tag)

    '                    If Not DesktopObject Is Nothing Then

    '                        dock.ContentContainer.Controls.Add(DesktopObject)

    '                    End If

    '            End Select


    '        Catch ex As Exception

    '            'Dim lit As Literal
    '            'lit.Text = ex.Message.ToString()
    '            'dock.ContentContainer.Controls.Add(lit)

    '        End Try

    '    End If

    'End Sub

#End Region
#Region " Windows"

    Public Sub ShowMessage(ByVal [ErrorMessage] As String) Implements IRadWindowFunctions.ShowMessage
        'ErrorMessage = HttpUtility.JavaScriptStringEncode(ErrorMessage)
        Me.RadAjaxManagerParent.ResponseScripts.Add("ShowMessage('" & ErrorMessage & "');")
    End Sub
    Public Sub ShowMessageBox(ByVal [ErrorMessage] As String, Optional ByVal [Title] As String = "") Implements IRadWindowFunctions.ShowMessageBox
        'ErrorMessage = HttpUtility.JavaScriptStringEncode(ErrorMessage)
        Me.RadAjaxManagerParent.ResponseScripts.Add("ShowMessage('" & ErrorMessage & "','" & Title & "');")
    End Sub
    Public Sub BackToSignInPage(Optional ByVal Message As AdvantageFramework.Security.ErrorMessages.SystemMessageType = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage,
                                Optional ByRef DBSessionId As String = "", Optional ByRef CurrSessionId As String = "") Implements IRadWindowFunctions.BackToSignInPage
        Dim s As String = ""
        If Message <> AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage Then
            s = "?m=" & CType(Message, Integer).ToString()
            If Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.SessionIdMismatch Then
                s &= "&d="
                s &= DBSessionId
                s &= "&c="
                s &= CurrSessionId
            End If
        End If
        Me.RadAjaxManagerParent.ResponseScripts.Add("BrowserWindow.location.href = 'SignIn.aspx" & s & "';")
    End Sub
    Public Sub OpenTimesheetStopwatchNotificationWindow()
        Me.RadAjaxManagerParent.ResponseScripts.Add("OpenStopwatchNotify();")
    End Sub
    Public Sub OpenPrintSendSilently(ByVal QS As AdvantageFramework.Web.QueryString)
        Me.RadAjaxManagerParent.ResponseScripts.Add("CallPrintSendPageSilently('" & QS.ToString(True) & "');")
    End Sub
    Public Overloads Sub OpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                          Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False, Optional Callback As String = Nothing) Implements IRadWindowFunctions.OpenWindow
        Dim s As String = ""
        If CloseCurrentWindowAfterOpen = True Then
            s = "CloseThisWindow();"
        End If
        Me.RadAjaxManagerParent.ResponseScripts.Add("OpenRadWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & "," & IsModal.ToString().ToLower() & ");" & s)
    End Sub
    Public Overloads Sub OpenWindow(ByVal [URL])
        [URL] = MiscFN.JavascriptSafe([URL])
        Me.RadAjaxManagerParent.ResponseScripts.Add("RefreshWindow('" & [URL] & "',true);")
    End Sub
    Public Sub OpenLookUp(ByVal [URL] As String) Implements IRadWindowFunctions.OpenLookUp
        [URL] = MiscFN.JavascriptSafe([URL])
        Me.RadAjaxManagerParent.ResponseScripts.Add("OpenRadWindowLookup('" & [URL] & "');")
    End Sub
    Public Sub RefreshBookmarksDesktopObject()
        Me.RadAjaxManagerParent.ResponseScripts.Add("RefreshBookmarksDTO();")
    End Sub
    Public Sub OpenLookUpRecipients(ByVal [URL] As String)
        [URL] = MiscFN.JavascriptSafe([URL])
        Me.RadAjaxManagerParent.ResponseScripts.Add("OpenRadWindowLookup('" & [URL] & "');")
    End Sub
    Public Overloads Sub HookUpLookUp(ByRef LookUpHyperLink As System.Web.UI.WebControls.HyperLink, ByVal [URL] As String) Implements IRadWindowFunctions.HookUpLookUp
        [URL] = MiscFN.JavascriptSafe([URL])
        With LookUpHyperLink.Attributes
            .Remove("onclick")
            .Add("onclick", "OpenRadWindowLookup('" & [URL] & "');")
        End With
    End Sub
    Public Overloads Function HookUpLookUp(ByVal LookUpType As String, ByVal [URL] As String, Optional ByVal JavascriptToExecuteBefore As String = "",
                                           Optional ByVal JavascriptToExecuteAfter As String = "") As String Implements IRadWindowFunctions.HookUpLookUp

        Dim StringBuilderJavascript As New System.Text.StringBuilder
        With StringBuilderJavascript
            '    'If JavascriptToExecuteBefore.Trim() <> "" Then
            '    '    .Append(JavascriptToExecuteBefore.Trim())
            '    'End If
            .Append("OpenRadWindowLookup(" & [URL] & ");")
            '    'If JavascriptToExecuteAfter.Trim() <> "" Then
            '    '    .Append(JavascriptToExecuteAfter.Trim())
            '    'End If
        End With
        ''Return HttpUtility.JavaScriptStringEncode(StringBuilderJavascript.ToString())
        Return StringBuilderJavascript.ToString()
        'Return ""



        'Dim FunctionName As String = "LookUp_" & LookUpType
        'Dim StringBuilderJavascript As New System.Text.StringBuilder
        'With StringBuilderJavascript

        'End With

    End Function
    Public Function HookUpOpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal CallBack As String = Nothing, Optional ByVal Param As String = Nothing) As String Implements IRadWindowFunctions.HookUpOpenWindow
        Dim s As String = ""
        If CloseCurrentWindowAfterOpen = True Then
            s = "CloseThisWindow();"
        End If
        Return "OpenRadWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & ");" & s & "return false;"
    End Function
    Public Sub CallUiAction(ByVal Action As UI_Action.ActionType, ByVal ExtraQuerystringParameters As String)
        Me.RadAjaxManagerParent.ResponseScripts.Add("CallUiAction(" & CType(Action, Integer) & ",'" & ExtraQuerystringParameters & "');")
    End Sub
    Public Function HookUpCallUiAction(ByVal Action As UI_Action.ActionType, ByVal ExtraQuerystringParameters As String) As String
        Return "CallUiAction(" & CType(Action, Integer) & ",'" & ExtraQuerystringParameters & "');" & "return false;"
    End Function
    '    //Open task edit window:
    '    /*
    '    --Array positions for key:
    '    -- 0 = Internal row id
    '    ***Going to re-use position zero as a "from page" variable...
    '    -- 1 = Is non task
    '    -- 2 = non task type
    '    -- 3 = is all day
    '    -- 4 = task status, N = normal status
    '    -- 5 = job number
    '    -- 6 = job component number
    '    -- 7 = sequence number
    '    -- 8 = non-task id (this is also Event ID and the Event Task ID)
    '    -- 9 = emp code
    '    -- 10 = client code
    '    -- 11 = division code
    '    -- 12 = product code
    '    */
    Public Function HookUpOpenDetailWindow(ByVal DataKey As String) As String
        Try
            Dim ar() As String
            Dim URL As String = ""

            Dim FromForm As String = ""
            Dim IsNonTask As Integer = 0
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = 0
            Dim NonId As String = ""
            Dim EmpCode As String = ""
            Dim ClCode As String = ""
            Dim DivCode As String = ""
            Dim PrdCode As String = ""

            ar = DataKey.Split("|")

            FromForm = ar(0)
            IsNonTask = CType(ar(1), Integer)
            JobNumber = CType(ar(5), Integer)
            JobComponentNbr = CType(ar(6), Integer)
            SeqNbr = CType(ar(7), Integer)
            NonId = ar(8)
            EmpCode = ar(9)
            ClCode = ar(10)
            DivCode = ar(11)
            PrdCode = ar(12)

            Select Case IsNonTask
                Case 0
                    URL = "TrafficSchedule_TaskDetail.aspx?pop=1&form=" & FromForm & "&JobNum=" & JobNumber.ToString() & "&JobComp=" & JobComponentNbr.ToString() & "&SeqNum=" & SeqNbr.ToString() &
                        "&EmpCode=" & EmpCode & "&Client=" & ClCode & "&Division=" & DivCode & "&Product=" & PrdCode
                Case 1
                    URL = "Calendar_NewActivity.aspx?TaskNo=" & NonId.ToString()
                Case 2
                    URL = "Event_Detail.aspx?et=0&j=" & JobNumber.ToString() & "&jc=" & JobComponentNbr.ToString() & "&evt=" & NonId & "&cli=" & ClCode & "&from=1"
                Case 3
                    URL = "Event_Task_Detail.aspx?etid=" & NonId & "&f=c"
            End Select
            Return "OpenRadWindow('','" & URL & "',0,0);return false;"
        Catch ex As Exception
            Return "alert('Error in javascript function:  HookUpOpenDetailWindow');"
        End Try
    End Function
    Public Sub OpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                          Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) Implements IRadWindowFunctions.OpenFloatingWindow
        Me.RadAjaxManagerParent.ResponseScripts.Add("OpenFloatingWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & "," & Top & "," & Left & ");")
    End Sub
    Function HookUpOpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                                  Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) As String Implements IRadWindowFunctions.HookUpOpenFloatingWindow

        Title = AdvantageFramework.StringUtilities.JavascriptSafe(Title)
        [URL] = AdvantageFramework.StringUtilities.JavascriptSafe([URL])

        Return "OpenFloatingWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & "," & Top & "," & Left & ");return false;"

    End Function
    Public Sub RefreshTasks()
        Me.RadAjaxManagerParent.ResponseScripts.Add("RefreshTasks();")
    End Sub
    Public Sub CopyToClipboard(ByVal Text As String)
        Me.RadAjaxManagerParent.ResponseScripts.Add(String.Format("copyToClipboard('{0}');", Text))
    End Sub
    Public Sub RefreshAlertWindows(Optional ByVal CloseThisWindow As Boolean = True,
                                   Optional ByVal IncludeAlertDesktopObject As Boolean = True,
                                   Optional ByVal IncludeProjectSchedulePage As Boolean = False,
                                   Optional ByVal IncludeAlertInbox As Boolean = True,
                                   Optional ByVal IncludeDashboard As Boolean = True)

        Dim CloseString As String = ""
        Dim ProjectScheduleString As String = ""

        If CloseThisWindow = True Then

            CloseString = "CloseThisWindow();"

        End If
        If IncludeProjectSchedulePage = True Then

            ProjectScheduleString = "RefreshProjectScheduleGrid();"

        End If
        Me.RadAjaxManagerParent.ResponseScripts.Add(String.Format("RefreshAlertWindows({0}, {1}, {4});{2}{3}",
                                                                  IncludeAlertDesktopObject.ToString.ToLower,
                                                                  IncludeAlertInbox.ToString.ToLower,
                                                                  ProjectScheduleString,
                                                                  CloseString,
                                                                  IncludeDashboard.ToString.ToLower))
    End Sub
    Public Sub RefreshInOutBoardObjects(ByVal CurrentObjectName As String)
        Me.RadAjaxManagerParent.ResponseScripts.Add("RefreshInOutBoardObjects('" & CurrentObjectName & "');")
    End Sub
    Public Sub RefreshJobRequestObjects(ByVal CurrentObjectName As String)
        Me.RadAjaxManagerParent.ResponseScripts.Add("RefreshJobRequestObjects('" & CurrentObjectName & "');")
    End Sub
    Public Sub RefreshTimesheetDesktopObject(Optional ByVal CloseThisWindow As Boolean = True)
        Dim CloseString As String = ""
        If CloseThisWindow = True Then
            CloseString = "CloseThisWindow();"
        End If
        Me.RadAjaxManagerParent.ResponseScripts.Add("RefreshTimesheetDTO();" & CloseString)
    End Sub
    Public Sub RefreshTimesheetWindows(Optional ByVal CloseThisWindow As Boolean = True)
        Dim CloseString As String = ""
        If CloseThisWindow = True Then
            CloseString = "CloseThisWindow();"
        End If
        Me.RadAjaxManagerParent.ResponseScripts.Add("RefreshTimesheetWindows();" & CloseString)
    End Sub
    Public Sub CalendarSync(ByVal EmployeeNonTaskID As Integer, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean)
        Me.RadAjaxManagerParent.ResponseScripts.Add("CalendarSync(" & EmployeeNonTaskID.ToString() & ", " & IsHoliday.ToString().ToLower() & "," & IsDeleting.ToString().ToLower() & ");")
    End Sub
    Public Function SendEmail(ByVal Guid As String) As Boolean
        Me.RadAjaxManagerParent.ResponseScripts.Add("SendEmail('" & Guid & "');")
    End Function
    Public Sub ReviewGenerateFeedbackSummary(ByVal ConceptShareProjectID As Integer, ByVal ConceptShareReviewID As Integer)
        Me.RadAjaxManagerParent.ResponseScripts.Add(String.Format("ReviewGenerateFeedbackSummary({0}, {1});", ConceptShareProjectID, ConceptShareReviewID))
    End Sub

#End Region
#Region " Auto open windows "

    'Private Overloads Sub AddToAutoOpenArray(ByVal IsDesktopObject As Boolean, ByVal ArrayPosition As Integer, ByVal DtoOrPageName As String, Optional ByVal WindowTitle As String = "",
    '                                Optional ByVal ObjectId As Integer = 0,
    '                                Optional ByVal Left As Integer = Nothing, Optional ByVal Top As Integer = Nothing,
    '                                Optional ByVal Height As Integer = Nothing, Optional ByVal Width As Integer = Nothing)

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    'WindowTitle = MiscFN.JavascriptSafe(WindowTitle)
    '    If Left = Nothing Then Left = -1
    '    If Top = Nothing Then Top = -1
    '    If Height = Nothing Then Height = 0
    '    If Width = Nothing Then Width = 0

    '    With _SbWindowArray
    '        'Main array for urls
    '        .Append("WindowsToOpen[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")

    '        Dim SbURL As New System.Text.StringBuilder

    '        If DtoOrPageName.StartsWith("/") = False Then

    '            If IsDesktopObject = True Then
    '                SbURL.Append("DesktopObjectWindow.aspx?dtoname=")
    '                SbURL.Append(DtoOrPageName)
    '                SbURL.Append("&")
    '            Else
    '                If DtoOrPageName.IndexOf(".aspx?") = -1 Then
    '                    DtoOrPageName = DtoOrPageName.Replace(".aspx", ".aspx?")
    '                    SbURL.Append(DtoOrPageName)
    '                Else
    '                    SbURL.Append(DtoOrPageName)
    '                    SbURL.Append("&")
    '                End If
    '            End If

    '            SbURL.Append("title=")
    '            SbURL.Append(WindowTitle)
    '            SbURL.Append("&id=")
    '            SbURL.Append(ObjectId.ToString())
    '            SbURL.Append("&workspace=")
    '            SbURL.Append(Me.CurrentWorkspaceId.ToString())
    '            SbURL.Append("&auto=1")

    '        Else

    '            SbURL.Append(DtoOrPageName)

    '        End If

    '        .Append(MiscFN.JavascriptSafe(SbURL.ToString()))

    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for left
    '        .Append("WindowsLeft[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append(Left.ToString())
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for top
    '        .Append("WindowsTop[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append(Top.ToString())
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for height
    '        .Append("WindowsHeight[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append(Height.ToString())
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for width
    '        .Append("WindowsWidth[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append(Width.ToString())
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for width
    '        .Append("WindowsTitle[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append(WindowTitle)
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '    End With
    'End Sub
    'Private Overloads Function AddToAutoOpenArray(ByVal ArrayPosition As Integer, ByVal URL As String, Optional ByVal WindowTitle As String = "") As String

    '    If Me.CheckUserNotTimedOut() = True Then Exit Function
    '    Dim SbWindowArray As New System.Text.StringBuilder
    '    With SbWindowArray
    '        'Main array for urls
    '        .Append("WindowsToOpen[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")

    '        Dim SbURL As New System.Text.StringBuilder
    '        SbURL.Append(URL)
    '        SbURL.Append("&")
    '        SbURL.Append("title=")
    '        SbURL.Append("&id=0")
    '        SbURL.Append("&workspace=")
    '        SbURL.Append(Me.CurrentWorkspaceId.ToString())
    '        SbURL.Append("&auto=1")

    '        .Append(MiscFN.JavascriptSafe(SbURL.ToString()))

    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for left
    '        .Append("WindowsLeft[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append("0")
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for top
    '        .Append("WindowsTop[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append("0")
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for height
    '        .Append("WindowsHeight[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append("0")
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for width
    '        .Append("WindowsWidth[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append("0")
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '        'array for width
    '        .Append("WindowsTitle[")
    '        .Append(ArrayPosition.ToString())
    '        .Append("] = '")
    '        .Append(WindowTitle)
    '        .Append("';")
    '        .Append(Environment.NewLine)

    '    End With

    '    Return SbWindowArray.ToString()

    'End Function
    'Private Sub CreateJavascriptWindowArray()

    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    Try

    '        If Me._IsDefaultWorkspace = True OrElse
    '       Me.HiddenFieldFloatDesktopObjects.Value = "False" OrElse
    '       Me.HiddenFieldFloatDesktopObjects.Value = "" OrElse
    '       Me.HiddenFieldAutoOpenWindowsLoaded.Value = "true" Then Exit Sub

    '        Dim ItemCount As Integer = 0

    '        'From dto's
    '        Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
    '        Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
    '        Dim UserWorkspaceCP As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
    '        Dim RadDock As Telerik.Web.UI.RadDock = Nothing
    '        Dim WorkspaceHasObjects As Boolean = False
    '        Dim DesktopObjectTitle As String = ""
    '        Dim DesktopObjectName As String = ""
    '        Dim WorkspaceHasProjectViewpointObject As Boolean = False
    '        Dim AddObject As Boolean = True
    '        Dim ProjectViewpointAccess As New ArrayList()
    '        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing


    '        Try

    '            If Me.CurrentWorkspaceId > 0 Then

    '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                    '_CurrentDockStates = New Generic.List(Of Telerik.Web.UI.DockState)
    '                    ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadActiveModulesByApplicationID(SecurityDbContext,
    '                                                                                                                          CType(AdvantageFramework.Security.Application.Webvantage, Integer)).ToList()

    '                    If Me.IsClientPortal = True Then

    '                        Try

    '                            UserWorkspaceCP = (From UsrWrkSpace In AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Load(SecurityDbContext).Include("ClientPortalWorkspaceObjects")
    '                                               Where UsrWrkSpace.ID = Me.CurrentWorkspaceId
    '                                               Select UsrWrkSpace).Single

    '                        Catch ex As Exception
    '                            UserWorkspaceCP = Nothing
    '                        End Try

    '                        If UserWorkspaceCP IsNot Nothing Then

    '                            '''Me.CurrentWorkspaceName = UserWorkspaceCP.Name
    '                            Me.Page.Title = UserWorkspaceCP.Name

    '                            For Each ClientPortalWorkspaceObject In UserWorkspaceCP.ClientPortalWorkspaceObjects.OrderBy(Function(WorkObject) WorkObject.SortOrder)

    '                                Try
    '                                    [Module] = ModulesList.First(Function(ModView) ModView.ModuleID = ClientPortalWorkspaceObject.DesktopObjectID)

    '                                Catch ex As Exception

    '                                    [Module] = Nothing

    '                                End Try

    '                                If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

    '                                    If [Module].DesktopObjectName.Contains("DesktopCards") Then

    '                                        AddObject = False

    '                                    End If

    '                                    If AddObject = True Then

    '                                        If [Module].DesktopObjectName.Contains("DesktopProjectViewpoint.ascx") Then

    '                                            DesktopObjectTitle = "Project Viewpoint"
    '                                            DesktopObjectName = "DesktopProjectViewpoint.ascx"

    '                                            If [Module].DesktopObjectName.Contains("?View=0") Then

    '                                                ProjectViewpointAccess.Add(0)

    '                                            ElseIf [Module].DesktopObjectName.Contains("?View=2") Then

    '                                                ProjectViewpointAccess.Add(1)

    '                                            ElseIf [Module].DesktopObjectName.Contains("?View=3") Then

    '                                                ProjectViewpointAccess.Add(2)

    '                                            End If

    '                                            If WorkspaceHasProjectViewpointObject = False Then

    '                                                WorkspaceHasProjectViewpointObject = True
    '                                                AddObject = True

    '                                            Else

    '                                                AddObject = False

    '                                            End If

    '                                        Else

    '                                            DesktopObjectTitle = [Module].ModuleDescription
    '                                            DesktopObjectName = [Module].DesktopObjectName.Replace("dos\", "")
    '                                            AddObject = True

    '                                        End If

    '                                    End If

    '                                    If AddObject = True Then

    '                                        '''Add to js array to auto open
    '                                        Dim DesktopObjectLeft As Integer = -1
    '                                        Dim DesktopObjectTop As Integer = -1
    '                                        Dim DesktopObjectHeight As Integer = 0
    '                                        Dim DesktopObjectWidth As Integer = 0

    '                                        Try
    '                                            If Not ClientPortalWorkspaceObject.LeftCoordinate Is Nothing Then
    '                                                DesktopObjectLeft = ClientPortalWorkspaceObject.LeftCoordinate
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectLeft = -1
    '                                        End Try
    '                                        Try
    '                                            If Not ClientPortalWorkspaceObject.TopCoordinate Is Nothing Then
    '                                                DesktopObjectTop = ClientPortalWorkspaceObject.TopCoordinate
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectTop = -1
    '                                        End Try
    '                                        Try
    '                                            If Not ClientPortalWorkspaceObject.Height Is Nothing Then
    '                                                DesktopObjectHeight = ClientPortalWorkspaceObject.Height
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectHeight = 0
    '                                        End Try
    '                                        Try
    '                                            If Not ClientPortalWorkspaceObject.Width Is Nothing Then
    '                                                DesktopObjectWidth = ClientPortalWorkspaceObject.Width
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectWidth = 0
    '                                        End Try

    '                                        If DesktopObjectLeft = 0 Then DesktopObjectLeft = 1
    '                                        If DesktopObjectTop = 0 Then DesktopObjectTop = 1

    '                                        DesktopObjectTitle = DesktopObjectTitle.Replace("(Cards)", "")

    '                                        Me.AddToAutoOpenArray(True, ItemCount, DesktopObjectName, DesktopObjectTitle, ClientPortalWorkspaceObject.ID,
    '                                                           DesktopObjectLeft, DesktopObjectTop,
    '                                                           DesktopObjectHeight, DesktopObjectWidth)

    '                                        'add to Favorites Menu
    '                                        Dim NewMenuItem As New RadTreeNode
    '                                        With NewMenuItem
    '                                            .Text = DesktopObjectTitle
    '                                            .Value = "APP|" & [Module].ID & "|" & "DesktopObjectWindow.aspx?dtoname=" &
    '                                                 DesktopObjectName & "&title=" & DesktopObjectTitle
    '                                        End With

    '                                        Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites").Nodes.Add(NewMenuItem)

    '                                        If DesktopObjectName.Contains("DesktopBookmarks.ascx") = True Then

    '                                            Me._HasUserAddedBookmarkDO = True

    '                                        End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyCalendar.ascx") = True Then

    '                                        '' ''    Me._HasScheduleCard = True

    '                                        '' ''End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyBookmarks.ascx") = True Then

    '                                        '' ''    Me._HasBookmarkCard = True

    '                                        '' ''End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyAssignments.ascx") = True Then

    '                                        '' ''    Me._HasAlertsAndAssignmentsCard = True

    '                                        '' ''End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyTasks.ascx") = True Then

    '                                        '' ''    Me._HasTasksCard = True

    '                                        '' ''End If

    '                                        Me._HasFavoriteObjects = True
    '                                        ItemCount += 1

    '                                    End If

    '                                End If

    '                            Next

    '                            If Session("currentPVView") Is Nothing Then
    '                                Session("currentPVView") = 0 'init anyway?
    '                                Try
    '                                    If ProjectViewpointAccess.Count > 0 Then
    '                                        ProjectViewpointAccess.Sort()
    '                                        If IsNumeric(ProjectViewpointAccess(0)) = True Then
    '                                            Session("currentPVView") = ProjectViewpointAccess(0)
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                End Try
    '                            End If

    '                        End If

    '                    Else

    '                        Try

    '                            UserWorkspace = (From UsrWrkSpace In AdvantageFramework.Security.Database.Procedures.UserWorkspace.Load(SecurityDbContext).Include("WorkspaceObjects")
    '                                             Where UsrWrkSpace.ID = Me.CurrentWorkspaceId
    '                                             Select UsrWrkSpace).Single

    '                        Catch ex As Exception
    '                            UserWorkspace = Nothing
    '                        End Try

    '                        If UserWorkspace IsNot Nothing Then

    '                            '''Me.CurrentWorkspaceName = UserWorkspace.Name
    '                            Me.Page.Title = UserWorkspace.Name


    '                            For Each WorkspaceObject In UserWorkspace.WorkspaceObjects.OrderBy(Function(WorkObject) WorkObject.SortOrder)

    '                                Try

    '                                    [Module] = ModulesList.First(Function(ModView) ModView.ModuleID = WorkspaceObject.DesktopObjectID)

    '                                Catch ex As Exception

    '                                    [Module] = Nothing

    '                                End Try

    '                                If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

    '                                    If [Module].DesktopObjectName.Contains("DesktopCards") Then

    '                                        AddObject = False

    '                                    End If

    '                                    If AddObject = True Then

    '                                        If [Module].DesktopObjectName.Contains("DesktopProjectViewpoint.ascx") Then

    '                                            DesktopObjectTitle = "Project Viewpoint"
    '                                            DesktopObjectName = "DesktopProjectViewpoint.ascx"

    '                                            If [Module].DesktopObjectName.Contains("?View=0") Then

    '                                                ProjectViewpointAccess.Add(0)

    '                                            ElseIf [Module].DesktopObjectName.Contains("?View=2") Then

    '                                                ProjectViewpointAccess.Add(1)

    '                                            ElseIf [Module].DesktopObjectName.Contains("?View=3") Then

    '                                                ProjectViewpointAccess.Add(2)

    '                                            End If

    '                                            If WorkspaceHasProjectViewpointObject = False Then

    '                                                WorkspaceHasProjectViewpointObject = True
    '                                                AddObject = True

    '                                            Else

    '                                                AddObject = False

    '                                            End If
    '                                        Else

    '                                            DesktopObjectTitle = [Module].ModuleDescription
    '                                            DesktopObjectName = [Module].DesktopObjectName.Replace("dos\", "")
    '                                            AddObject = True

    '                                        End If

    '                                    End If

    '                                    If AddObject = True Then

    '                                        'Add to js array to auto open
    '                                        Dim DesktopObjectLeft As Integer = -1
    '                                        Dim DesktopObjectTop As Integer = -1
    '                                        Dim DesktopObjectHeight As Integer = 0
    '                                        Dim DesktopObjectWidth As Integer = 0
    '                                        Try
    '                                            If Not WorkspaceObject.LeftCoordinate Is Nothing Then
    '                                                DesktopObjectLeft = WorkspaceObject.LeftCoordinate
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectLeft = -1
    '                                        End Try
    '                                        Try
    '                                            If Not WorkspaceObject.TopCoordinate Is Nothing Then
    '                                                DesktopObjectTop = WorkspaceObject.TopCoordinate
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectTop = -1
    '                                        End Try
    '                                        Try
    '                                            If Not WorkspaceObject.Height Is Nothing Then
    '                                                DesktopObjectHeight = WorkspaceObject.Height
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectHeight = 0
    '                                        End Try
    '                                        Try
    '                                            If Not WorkspaceObject.Width Is Nothing Then
    '                                                DesktopObjectWidth = WorkspaceObject.Width
    '                                            End If
    '                                        Catch ex As Exception
    '                                            DesktopObjectWidth = 0
    '                                        End Try

    '                                        If DesktopObjectLeft = 0 Then DesktopObjectLeft = 1
    '                                        If DesktopObjectTop = 0 Then DesktopObjectTop = 1

    '                                        DesktopObjectTitle = DesktopObjectTitle.Replace("(Cards)", "")

    '                                        Me.AddToAutoOpenArray(True, ItemCount, DesktopObjectName, DesktopObjectTitle, WorkspaceObject.ID, DesktopObjectLeft, DesktopObjectTop,
    '                                                                                         DesktopObjectHeight, DesktopObjectWidth)

    '                                        'add to Favorites Menu
    '                                        Dim NewMenuItem As New RadTreeNode
    '                                        With NewMenuItem

    '                                            .Text = DesktopObjectTitle
    '                                            .Value = "APP|" & [Module].ID & "|" & "DesktopObjectWindow.aspx?dtoname=" &
    '                                                 DesktopObjectName & "&title=" & DesktopObjectTitle

    '                                        End With
    '                                        Me.RadTreeViewUser.FindNodeByValue("RadPanelBarUserFavorites").Nodes.Add(NewMenuItem)

    '                                        If DesktopObjectName.Contains("DesktopBookmarks.ascx") = True Then

    '                                            Me._HasUserAddedBookmarkDO = True

    '                                        End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyCalendar.ascx") = True Then

    '                                        '' ''    Me._HasScheduleCard = True

    '                                        '' ''End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyBookmarks.ascx") = True Then

    '                                        '' ''    Me._HasBookmarkCard = True

    '                                        '' ''End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyAssignments.ascx") = True Then

    '                                        '' ''    Me._HasAlertsAndAssignmentsCard = True

    '                                        '' ''End If
    '                                        '' ''If DesktopObjectName.Contains("DesktopCardsMyTasks.ascx") = True Then

    '                                        '' ''    Me._HasTasksCard = True

    '                                        '' ''End If

    '                                        Me._HasFavoriteObjects = True
    '                                        ItemCount += 1

    '                                    End If

    '                                End If

    '                            Next

    '                            If Session("currentPVView") Is Nothing Then
    '                                Session("currentPVView") = 0 'init anyway?
    '                                Try
    '                                    If ProjectViewpointAccess.Count > 0 Then

    '                                        ProjectViewpointAccess.Sort()

    '                                        If IsNumeric(ProjectViewpointAccess(0)) = True Then

    '                                            Session("currentPVView") = ProjectViewpointAccess(0)

    '                                        End If

    '                                    End If
    '                                Catch ex As Exception
    '                                End Try

    '                            End If

    '                        End If

    '                    End If

    '                End Using

    '            End If

    '        Catch ex As Exception
    '        End Try

    '        'From favorites
    '        Try
    '            Dim arP(2) As SqlParameter
    '            Dim DtFavorites As New DataTable
    '            If IsClientPortal = True Then
    '                Dim pCPID As New SqlParameter("@CPID", SqlDbType.Int)
    '                pCPID.Value = Session("UserID").ToString()
    '                arP(0) = pCPID

    '                Dim pCurrentWorkspaceId As New SqlParameter("@WORKSPACE_ID", SqlDbType.Int)
    '                pCurrentWorkspaceId.Value = Me.CurrentWorkspaceId
    '                arP(1) = pCurrentWorkspaceId

    '                DtFavorites = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_cp_UseFavoritesGet", "DtData", arP)
    '            Else
    '                Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
    '                pUserCode.Value = Session("UserCode").ToString()
    '                arP(0) = pUserCode

    '                Dim pCurrentWorkspaceId As New SqlParameter("@WORKSPACE_ID", SqlDbType.Int)
    '                pCurrentWorkspaceId.Value = Me.CurrentWorkspaceId
    '                arP(1) = pCurrentWorkspaceId

    '                DtFavorites = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_UseFavoritesGet", "DtData", arP)
    '            End If

    '            If Not DtFavorites Is Nothing Then
    '                For i As Integer = 0 To DtFavorites.Rows.Count - 1
    '                    Dim URL As String = ""
    '                    Dim ModuleId As Integer = 0
    '                    Dim ModuleCode As String = ""
    '                    Dim Title As String = ""
    '                    Dim WindowHeight As Integer = 0
    '                    Dim WindowWidth As Integer = 0
    '                    Dim WindowTop As Integer = 0
    '                    Dim WindowLeft As Integer = 0
    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("URL")) = True Then
    '                            URL = DtFavorites.Rows(i)("URL").ToString()
    '                        End If
    '                    Catch ex As Exception
    '                        URL = ""
    '                    End Try
    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("DESCRIPTION")) = True Then
    '                            Title = DtFavorites.Rows(i)("DESCRIPTION").ToString()
    '                        End If
    '                    Catch ex As Exception
    '                        Title = ""
    '                    End Try
    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("USER_FAVORITE_MODUE_ID")) = True Then
    '                            ModuleId = CType(DtFavorites.Rows(i)("USER_FAVORITE_MODUE_ID"), Integer)
    '                        End If
    '                    Catch ex As Exception
    '                        ModuleId = 0
    '                    End Try
    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("SEC_MODULE_CODE")) = True Then
    '                            ModuleCode = DtFavorites.Rows(i)("SEC_MODULE_CODE").ToString()
    '                        End If
    '                    Catch ex As Exception
    '                        ModuleCode = ""
    '                    End Try


    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("HEIGHT")) = True Then
    '                            WindowHeight = CType(DtFavorites.Rows(i)("HEIGHT"), Integer)
    '                        End If
    '                    Catch ex As Exception
    '                        WindowHeight = 0
    '                    End Try
    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("WIDTH")) = True Then
    '                            WindowWidth = CType(DtFavorites.Rows(i)("WIDTH"), Integer)
    '                        End If
    '                    Catch ex As Exception
    '                        WindowWidth = 0
    '                    End Try
    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("TOP_COORD")) = True Then
    '                            WindowTop = CType(DtFavorites.Rows(i)("TOP_COORD"), Integer)
    '                        End If
    '                    Catch ex As Exception
    '                        WindowTop = 0
    '                    End Try
    '                    Try
    '                        If Not IsDBNull(DtFavorites.Rows(i)("LEFT_COORD")) = True Then
    '                            WindowLeft = CType(DtFavorites.Rows(i)("LEFT_COORD"), Integer)
    '                        End If
    '                    Catch ex As Exception
    '                        WindowLeft = 0
    '                    End Try

    '                    Title = Title.Replace("(Cards)", "")

    '                    If URL <> "" And ModuleCode <> "" Then
    '                        If Me.CheckModuleAccess(ModuleCode, False) = 1 Then
    '                            Me.AddToAutoOpenArray(False, ItemCount, URL, Title, ModuleId, WindowLeft, WindowTop, WindowHeight, WindowWidth)
    '                            Me._HasFavoriteApps = True
    '                            ItemCount += 1
    '                        End If
    '                    End If

    '                Next
    '            End If

    '        Catch ex As Exception
    '        End Try

    '        'output to js array
    '        If ItemCount > 0 Then 'Or HasBookMark = True Then

    '            Me.JavascriptWindowsArrays &= Me._SbWindowArray.ToString()
    '            Me._AutoOpenArrayCount = ItemCount

    '        Else

    '            Me.JavascriptWindowsArrays = ""

    '        End If

    '        Me.RadDockLayoutParent.Visible = False
    '        Me.RadDockZoneCenter.Visible = False
    '        Me.RadDockZoneLeft.Visible = False

    '    Catch ex As Exception
    '    End Try

    'End Sub

#End Region
#Region " Panels "

    'Private Sub LoadEmployee()

    '    Try

    '        If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '        If _Session IsNot Nothing AndAlso HttpContext.Current.Session("EmpCode") IsNot Nothing Then

    '            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                Dim ep As AdvantageFramework.Database.Entities.EmployeePicture
    '                ep = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode"))

    '                If ep IsNot Nothing AndAlso ep.Image IsNot Nothing Then

    '                    Me.ASPxBinaryImageEmp.Value = ep.Image

    '                End If

    '            End Using

    '        End If

    '        If HttpContext.Current.Session("Admin") IsNot Nothing AndAlso HttpContext.Current.Session("Admin") = True Then

    '            If HttpContext.Current.Session("DBServerName") IsNot Nothing Then Me.LiteralServer.Text = "Server:&nbsp;" & HttpContext.Current.Session("DBServerName").ToString()

    '        Else

    '            DivServerName.Visible = False

    '        End If

    '        If HttpContext.Current.Session("DBName") IsNot Nothing Then LiteralDatabase.Text = "Database:&nbsp;" & HttpContext.Current.Session("DBName").ToString()

    '    Catch ex As Exception
    '    End Try

    'End Sub
    'Private Sub SetAppNotification()
    '    If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '    If Session("AppNotificationShown") Is Nothing Then
    '        Dim AlertMessage As String = ""
    '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
    '            Me.ImageButtonNewApplications.Visible = AdvantageFramework.Security.LoadNewAdvantageApplicationsAlertSetting(_Session, AlertMessage)
    '            If Me.ImageButtonNewApplications.Visible Then
    '                RadNotificationParent.Text = AlertMessage.Replace("<br></br>", "<br/>")
    '                Session("AppNotificationShown") = True
    '            Else
    '                Session("AppNotificationShown") = False
    '            End If
    '        End Using
    '    End If
    'End Sub
    'Private Sub SetBookmarkMenuIcon()

    '    If Not Me.Page.IsPostBack AndAlso Not Me.Page.IsCallback Then

    '        If Me.CheckUserNotTimedOut() = True Then Exit Sub
    '        Try

    '            If EnableBookmarks() = True Then

    '                Me.ImageButtonBookmarks.Visible = Not Me._HasUserAddedBookmarkDO

    '                If Me._HasUserAddedBookmarkDO = False Then

    '                    Try

    '                        Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
    '                        Dim UserBookmarks As Generic.List(Of AdvantageFramework.Web.Presentation.Bookmarks.Bookmark)

    '                        UserBookmarks = BmMethods.GetBookmarks(Session("UserCode"))

    '                        If Not UserBookmarks Is Nothing Then

    '                            If UserBookmarks.Count = 0 Then

    '                                Me.ImageButtonBookmarks.Style.Add("display", "none")

    '                            End If

    '                        End If

    '                    Catch ex As Exception
    '                    End Try

    '                End If

    '            End If

    '        Catch ex As Exception
    '        End Try

    '    End If

    'End Sub

    'Private Sub ImageButtonTheme_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonTheme.Click

    '    Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
    '    t.Load()

    '    If t.Settings.TelerikTheme = "Metro" Then

    '        t.Settings.TelerikTheme = "Bootstrap"

    '    Else

    '        t.Settings.TelerikTheme = "Metro"

    '    End If

    '    t.Save()
    '    t.Reload()

    '    Dim Qs As New AdvantageFramework.Web.QueryString
    '    Qs = Qs.FromCurrent
    '    Qs.Go()

    'End Sub

#End Region

    'Private Function CheckUserNotTimedOut() As Boolean

    '    Dim UserIsSignedOut As Boolean = False

    '    Try
    '        If _Session Is Nothing Then

    '            MiscFN.ResponseRedirect("SignIn.aspx?m=" & CType(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString, Integer))
    '            UserIsSignedOut = True

    '        End If
    '    Catch ex As Exception
    '        UserIsSignedOut = True
    '    End Try
    '    If UserIsSignedOut = False Then
    '        Try
    '            If Session("ConnString") Is Nothing OrElse Session("ConnString") = "" Then

    '                MiscFN.ResponseRedirect("SignIn.aspx?m=" & CType(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString, Integer))
    '                UserIsSignedOut = True

    '            End If
    '        Catch ex As Exception
    '            UserIsSignedOut = True
    '        End Try
    '    End If
    '    If UserIsSignedOut = False Then
    '        Try
    '            If Session("UserCode") Is Nothing OrElse Session("UserCode") = "" Then

    '                MiscFN.ResponseRedirect("SignIn.aspx?m=" & CType(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoUserCode, Integer))
    '                UserIsSignedOut = True

    '            End If
    '        Catch ex As Exception
    '            UserIsSignedOut = True
    '        End Try
    '    End If
    '    If UserIsSignedOut = False Then
    '        Try
    '            If (Session("EmpCode") Is Nothing OrElse Session("EmpCode") = "") And Me.IsClientPortal = False Then

    '                MiscFN.ResponseRedirect("SignIn.aspx?m=" & CType(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoUserCode, Integer))
    '                UserIsSignedOut = True

    '            End If
    '        Catch ex As Exception
    '            UserIsSignedOut = True
    '        End Try
    '    End If

    '    Return UserIsSignedOut

    'End Function

#End Region

End Class
