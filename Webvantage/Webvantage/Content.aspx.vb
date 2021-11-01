Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class ContentPage
    Inherits Webvantage.BaseChildPage

    ''Store viewstate in session instead of on the page...
    ''This doesn't work on the base page
    'Dim _pers As PageStatePersister
    'Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
    '    Get
    '        If _pers Is Nothing Then
    '            _pers = New SessionPageStatePersister(Me)
    '        End If
    '        Return _pers
    '    End Get
    'End Property

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private _UserCode As String = ""
    Private _ContentType As AdvantageFramework.Database.Classes.Content.ContentType = AdvantageFramework.Database.Classes.Content.ContentType.ProjectManagement
    Private _ContentControlProjectSchedule_Gantt As Webvantage.ProjectSchedule_Gantt
    Private _ContentPageData As New AdvantageFramework.Web.Classes.ContentPageData()

#End Region

#Region " Properties "

    Private Property ClientCode As String
        Get
            If Session("ContentPage_ClientCode") IsNot Nothing Then
                Return Session("ContentPage_ClientCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Session("ContentPage_ClientCode") = value
        End Set
    End Property
    Private Property DivisionCode As String
        Get
            If Session("ContentPage_DivisionCode") IsNot Nothing Then
                Return Session("ContentPage_DivisionCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Session("ContentPage_DivisionCode") = value
        End Set
    End Property
    Private Property ProductCode As String
        Get
            If Session("ContentPage_ProductCode") IsNot Nothing Then
                Return Session("ContentPage_ProductCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Session("ContentPage_ProductCode") = value
        End Set
    End Property
    Public Property JobNumber As Integer
        Get
            If ViewState("ContentPage_JobNumber") Is Nothing Then
                ViewState("ContentPage_JobNumber") = 0
            End If
            Return CType(ViewState("ContentPage_JobNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("ContentPage_JobNumber") = value
        End Set
    End Property
    Public Property JobComponentNumber As Short
        Get
            If ViewState("ContentPage_JobComponentNumber") Is Nothing Then
                ViewState("ContentPage_JobComponentNumber") = 0
            End If
            Return CType(ViewState("ContentPage_JobComponentNumber"), Short)
        End Get
        Set(value As Short)
            ViewState("ContentPage_JobComponentNumber") = value
        End Set
    End Property
    Public Property IsBookmark As Short
        Get
            If ViewState("ContentPage_IsBookmark") Is Nothing Then
                ViewState("ContentPage_IsBookmark") = 0
            End If
            Return CType(ViewState("ContentPage_IsBookmark"), Short)
        End Get
        Set(value As Short)
            ViewState("ContentPage_IsBookmark") = value
        End Set
    End Property
    Public Property AAMShowAssignmentType As String
        Get
            If ViewState("ContentPage_AAMShowAssignmentType") Is Nothing Then
                ViewState("ContentPage_AAMShowAssignmentType") = ""
            End If
            Return CType(ViewState("ContentPage_AAMShowAssignmentType"), String)
        End Get
        Set(value As String)
            ViewState("ContentPage_AAMShowAssignmentType") = value
        End Set
    End Property
    Private Property _ControlName As String
        Get
            If Session("ControlName") IsNot Nothing Then
                Return Session("ControlName")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Session("ControlName") = value
        End Set
    End Property
    Private Property _PageTitle As String
        Get
            If ViewState("PageTitle") IsNot Nothing Then
                Return ViewState("PageTitle")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            ViewState("PageTitle") = value
        End Set
    End Property
    Private Property _ContentSaveButtonVisible As Boolean
        Get
            If ViewState("ContentSaveButtonVisible") IsNot Nothing Then
                Return ViewState("ContentSaveButtonVisible")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("ContentSaveButtonVisible") = value
        End Set
    End Property
    Private Property HideClientPortalDeepLink As Boolean
        Get
            If ViewState("HideClientPortalDeepLink") IsNot Nothing Then
                Return ViewState("HideClientPortalDeepLink")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("HideClientPortalDeepLink") = value
        End Set
    End Property
    Public Property CurrentContentArea As AdvantageFramework.Web.QueryString.ContentAreaName
        Get
            If ViewState("CurrentContentArea") Is Nothing Then
                ViewState("CurrentContentArea") = CType(AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate, Integer)
            End If
            Return CType(ViewState("CurrentContentArea"), AdvantageFramework.Web.QueryString.ContentAreaName)
        End Get
        Set(value As AdvantageFramework.Web.QueryString.ContentAreaName)
            ViewState("CurrentContentArea") = CType(value, Integer)
        End Set
    End Property
    Private Property _ShowFullMenu As Boolean
        Get
            If Session("ContentShowFullMenu") IsNot Nothing Then
                Return Session("ContentShowFullMenu")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            Session("ContentShowFullMenu") = value
        End Set
    End Property
    Private Property _MenuList As Generic.List(Of AdvantageFramework.Database.Classes.Content)
    '    Get

    '        Dim list As Generic.List(Of AdvantageFramework.Database.Classes.Content)

    '        If Session("ContentMenuList") Is Nothing Then

    '            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                list = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.Content)(String.Format("EXEC advsp_get_content_for_user '{0}', {1}, '{2}', {3}, {4};", _Session.UserCode,
    '                                                                                                          CType(Me._ContentType, Integer), Session("EmpCode"), Me._JobNumber, Me._JobComponentNumber)).ToList()

    '                Session("ContentMenuList") = list

    '            End Using

    '        Else

    '            list = DirectCast(Session("ContentMenuList"), Generic.List(Of AdvantageFramework.Database.Classes.Content))

    '        End If

    '        Return list

    '    End Get
    'End Property

    Private ReadOnly Property IsProofingActive As Boolean
        Get
            Dim IsActive As Boolean = False

            'Check code set by DashboardController.vb
            If HttpContext.Current.Session("gN$uYrs&5X6$a") IsNot Nothing Then

                IsActive = CType(HttpContext.Current.Session("gN$uYrs&5X6$a"), Boolean)

            Else

                IsActive = cApplication.IsProofingToolActive(SecuritySession)
                HttpContext.Current.Session("gN$uYrs&5X6$a") = IsActive

            End If

            Return IsActive

        End Get
    End Property
    Private ReadOnly Property IsConceptShareActive As Boolean
        Get
            Dim IsActive As Boolean = False

            'Check code set by DashboardController.vb
            If HttpContext.Current.Session("bLnaNBeJk4y$f") IsNot Nothing Then

                IsActive = CType(HttpContext.Current.Session("bLnaNBeJk4y$f"), Boolean)

            Else

                IsActive = cApplication.IsConceptShareActive(SecuritySession)
                HttpContext.Current.Session("bLnaNBeJk4y$f") = IsActive

            End If

            Return IsActive

        End Get
    End Property

#End Region

#Region " Methods "

#Region " Page "

    Private Sub ContentPage_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket)

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.AamShowAssignmentType.Length > 0 Then Me.AAMShowAssignmentType = Me.CurrentQuerystring.AamShowAssignmentType
        If Me.CurrentQuerystring.IsBookmark Then Me.IsBookmark = Me.CurrentQuerystring.IsBookmark

        'Just in case old query string vars passed in:
        If Me.JobNumber = 0 Then

            Try

                If Request.QueryString("JobNum") IsNot Nothing AndAlso IsNumeric(Request.QueryString("JobNum")) Then Me.JobNumber = CType(Request.QueryString("JobNum"), Integer)

            Catch ex As Exception

                Me.JobNumber = 0

            End Try

        End If
        If Me.JobNumber = 0 Then

            Try

                If Request.QueryString("Job") IsNot Nothing AndAlso IsNumeric(Request.QueryString("Job")) Then Me.JobNumber = CType(Request.QueryString("Job"), Integer)

            Catch ex As Exception

                Me.JobNumber = 0

            End Try

        End If
        If Me.JobNumber = 0 Then

            Me.ShowMessage("Cannot get job number!")
            Me.CloseThisWindow()

        End If
        If Me.JobComponentNumber = 0 Then

            Try

                If Request.QueryString("JobComp") IsNot Nothing AndAlso IsNumeric(Request.QueryString("JobComp")) Then Me.JobComponentNumber = CType(Request.QueryString("JobComp"), Integer)

            Catch ex As Exception

                Me.JobComponentNumber = 0

            End Try

        End If
        If Me.JobComponentNumber = 0 Then

            Try

                If Request.QueryString("JobCompNum") IsNot Nothing AndAlso IsNumeric(Request.QueryString("JobCompNum")) Then Me.JobComponentNumber = CType(Request.QueryString("JobCompNum"), Integer)

            Catch ex As Exception

                Me.JobComponentNumber = 0

            End Try

        End If
        If Me.JobComponentNumber = 0 Then

            Try

                If Request.QueryString("Comp") IsNot Nothing AndAlso IsNumeric(Request.QueryString("Comp")) Then Me.JobComponentNumber = CType(Request.QueryString("Comp"), Integer)

            Catch ex As Exception

                Me.JobComponentNumber = 0

            End Try

        End If
        If Me.JobComponentNumber = 0 Then

            Me.ShowMessage("Cannot get job component number!")
            Me.CloseThisWindow()

        End If

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If Me.JobNumber > 0 AndAlso Me.JobComponentNumber > 0 Then

                Dim v As New cValidations(Session("ConnString"))
                If v.ValidateJobCompIsViewable(Session("UserCode"), JobNumber, JobComponentNumber) = False Then

                    'Server.Transfer("NoAccess.aspx")
                    Me.ShowMessage("Access to this job/comp is denied")
                    Me.CloseThisWindow()
                    Exit Sub

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)

                    If Job IsNot Nothing Then

                        Me.ClientCode = Job.ClientCode
                        Me.DivisionCode = Job.DivisionCode
                        Me.ProductCode = Job.ProductCode

                    End If

                End Using

            End If

        End If

    End Sub
    Private Sub ContentPage_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If Me.CurrentQuerystring.ContentArea <> AdvantageFramework.Web.QueryString.ContentAreaName.None Then Me.CurrentContentArea = Me.CurrentQuerystring.ContentArea

            Me._ContentPageData.Clear()
            Me._ContentPageData.JobNumber = Me.JobNumber
            Me._ContentPageData.JobComponentNumber = Me.JobComponentNumber

            If Me.CurrentContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates Then

                Me._ContentPageData.EstimateNumber = Me.CurrentQuerystring.EstimateNumber
                Me._ContentPageData.EstimateComponentNumber = Me.CurrentQuerystring.EstimateComponentNumber

            End If

            Me._ContentPageData.Save()

        End If

    End Sub
    Private Sub ContentPage_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.PlaceHolderContent.Controls.Clear()
            Me.IFrameContent.Attributes.Remove("onload")
            Me.IFrameContent.Attributes.Add("onload", "hideLoading();")

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            '    Dim ClientName As String = ""

            '    ClientName = (From Job In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Job).Include("Client")
            '                  Where Job.Number = Me.JobNumber
            '                  Select Job.Client.Name).FirstOrDefault

            '    Dim jc As New AdvantageFramework.Database.Entities.JobComponent
            '    jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

            '    If jc IsNot Nothing Then

            '        Me._PageTitle = Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNumber.ToString().PadLeft(3, "0") & " - " & jc.Description & " | " & ClientName

            '    End If

            '    Me.PageTitle = Me._PageTitle

            'End Using

            Dim ContentPageSettings As New cAppVars(cAppVars.Application.CONTENT_PAGE)
            ContentPageSettings.getAllAppVars()

            If Me.IsClientPortal = True Then

                Me._ShowFullMenu = True

            Else

                Me._ShowFullMenu = (ContentPageSettings.getAppVar("ShowFullMenu", "Boolean", "True") = "True")

            End If

            If Me.CurrentContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.None Then Me.CurrentContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate

            Me.LoadMenu()

            Dim CurrentNode As RadTreeNode = Me.RadTreeViewContent.Nodes.FindNodeByValue(Me.CurrentContentArea.ToString())

            If CurrentNode Is Nothing OrElse CurrentNode.Visible = False Then

                'get first node that is visible
                For Each node As RadTreeNode In Me.RadTreeViewContent.Nodes

                    If node.Visible = True Then

                        Me.CurrentContentArea = DirectCast(System.[Enum].Parse(GetType(AdvantageFramework.Web.QueryString.ContentAreaName), node.Value), AdvantageFramework.Web.QueryString.ContentAreaName)
                        Exit For

                    End If

                Next

            End If

            Me._ControlName = Me.CurrentContentArea.ToString()

            If Me._ShowFullMenu = True Then

                Me.SetTreeViewSelectedNode()

            Else

                Me.SetShortMenuRepeaterSelectedLinkButton()

            End If

            Me.SetMenuVisibilityAndStyle(Me._ShowFullMenu)

            Me.LoadContentDetail()

        Else

            Select Case Me.EventTarget
                Case "Refresh"

                    Me.LoadContentDetail()

                Case "RefreshFromAAM"

                    If Me.CurrentContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Alerts OrElse
                        Me.CurrentContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate Then

                        Me.LoadContentDetail()

                    End If

                Case "ImageButtonShowFullMenu"

                    If Me.EventArgument = "click" Then

                        Me._ShowFullMenu = True

                        Dim ContentPageSettings As New cAppVars(cAppVars.Application.CONTENT_PAGE)

                        ContentPageSettings.getAllAppVars()
                        ContentPageSettings.setAppVar("ShowFullMenu", Me._ShowFullMenu.ToString(), "Boolean")
                        ContentPageSettings.SaveAllAppVars()

                        Me.LoadMenu()
                        Me.SetMenuVisibilityAndStyle(Me._ShowFullMenu)

                    End If

                Case "ContextMenuFloatie"

                    Select Case Me.EventArgument
                        Case "NewProof"

                            ActionButtonAction(BasePrintSendPage.PageMode.NewProof)

                        Case "NewAlert"

                            ActionButtonAction(BasePrintSendPage.PageMode.NewAlert)

                        Case "NewAssignment"

                            ActionButtonAction(BasePrintSendPage.PageMode.NewAssignment)

                        Case "SendAlert"

                            ActionButtonAction(BasePrintSendPage.PageMode.SendAlert)

                        Case "SendAssignment"

                            ActionButtonAction(BasePrintSendPage.PageMode.SendAssignment)

                        Case "NewEmail"

                            ActionButtonAction(BasePrintSendPage.PageMode.SendEmail)

                        Case "Print"

                            ActionButtonAction(BasePrintSendPage.PageMode.Print)

                        Case "PrintSettings"

                            ActionButtonAction(BasePrintSendPage.PageMode.Options)

                        Case "Bookmark"

                            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                            Dim QueryStringForBookmark As New AdvantageFramework.Web.QueryString()
                            Dim s As String = ""

                            With b

                                .Name = Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNumber.ToString().PadLeft(2, "0")

                                If Me._ShowFullMenu = True Then

                                    Select Case Me.RadTreeViewContent.SelectedNode.Text
                                        Case "Job Jacket"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobJacket
                                        Case "Assignments & Alerts"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_AlertInbox
                                        Case "Team"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Team
                                        Case "Documents"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Documents
                                        Case "Creative Brief"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_CreativeBrief
                                        Case "Specifications"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Specifications
                                        Case "Forms"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Forms
                                        Case "Purchase Orders"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
                                        Case "Schedule"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                                        Case "Estimate"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Estimating
                                        Case "Gantt"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Gantt
                                        Case "Risk Analysis"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_RiskAnalysis
                                        Case "Calendar"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Calendar
                                        Case "Workload"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Workload
                                        Case "Financial Status"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_FinancialStatus
                                        Case "Job Status"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobStatus
                                        Case "Media"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Media
                                        Case "Job Forecasts"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_JobForecast
                                        Case "Boards"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Agile_Board
                                        Case "Reviews", "Proof", "Proofs"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ConceptShare_Review
                                        Case "Account Setup"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_AccountSetup
                                        Case Else
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content
                                    End Select

                                    If Me.RadTreeViewContent.SelectedNode IsNot Nothing Then

                                        .Name &= " - " & Me.RadTreeViewContent.SelectedNode.Text
                                        .Description = Me.RadTreeViewContent.SelectedNode.Text & " for " & Me._PageTitle

                                    Else

                                        .Name &= " - " & "Job Status"
                                        .Description = "Job Status for " & Me._PageTitle

                                    End If

                                Else

                                    Select Case Me.HiddenFieldSelectedShortMenuName.Value
                                        Case "Job Jacket"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobJacket
                                        Case "Alerts"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_AlertInbox
                                        Case "Team"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Team
                                        Case "Documents"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Documents
                                        Case "Creative Brief"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_CreativeBrief
                                        Case "Specifications"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Specifications
                                        Case "Forms"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Forms
                                        Case "Purchase Orders"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
                                        Case "Schedule"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                                        Case "Estimate"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Estimating
                                        Case "Gantt"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Gantt
                                        Case "Risk Analysis"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_RiskAnalysis
                                        Case "Calendar"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Calendar
                                        Case "Workload"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Workload
                                        Case "Financial Status"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_FinancialStatus
                                        Case "Job Status"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobStatus
                                        Case "Media"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_Media
                                        Case "Job Forecasts"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_JobForecast
                                        Case "Boards"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Agile_Board
                                        Case "Reviews", "Proof", "Proofs"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ConceptShare_Review
                                        Case "Account Setup"
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content_AccountSetup
                                        Case Else
                                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content
                                    End Select

                                    If Me.HiddenFieldSelectedShortMenuName.Value IsNot Nothing Then

                                        .Name &= " - " & Me.HiddenFieldSelectedShortMenuName.Value
                                        .Description = Me.HiddenFieldSelectedShortMenuName.Value & " for " & Me._PageTitle

                                    Else

                                        .Name &= " - " & "Job Status"
                                        .Description = "Job Status for " & Me._PageTitle

                                    End If

                                End If

                                .UserCode = Session("UserCode")

                                QueryStringForBookmark = Me.SetupCurrentContentQueryString

                                .PageURL = QueryStringForBookmark.ToString(True)

                            End With

                            If BmMethods.SaveBookmark(b, s) = False Then

                                Me.ShowMessage(s)

                            Else

                                Me.RefreshBookmarksDesktopObject()

                            End If

                        Case "EditMenu"

                            If Me._ShowFullMenu = False Then

                                Me.SetMenuVisibilityAndStyle(True)

                            End If

                            Me.RadTreeViewContent.CheckBoxes = True
                            Me.RadTreeViewContent.EnableDragAndDrop = True
                            Me.RadTreeViewContent.EnableDragAndDropBetweenNodes = True
                            Me.LoadContentTree(True)
                            Me.ImageButtonSaveRadTreeViewContent.Visible = True

                    End Select

            End Select

        End If

        If cApplication.IsProofingToolActive(Me.SecuritySession) = False OrElse
            MiscFN.IsClientPortal = True Then

            Try

                Me.ContextMenuFloatie.FindItemByValue("SeparatorEmailProof").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("NewProof").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("SeparatorProofPrint").Visible = False

            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub ContentPage_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        If JobNumber > 0 And JobComponentNumber > 0 Then


        Else

            Me.CloseThisWindow()

        End If

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If Me.IsClientPortal = False Then

                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False) = False OrElse
                      Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Desktop_Alerts) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("NewAlert").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("NewAssignment").Visible = False

                End If

                Me.ContextMenuFloatie.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

                Dim QueryStringPermalink As New AdvantageFramework.Web.QueryString
                QueryStringPermalink = Me.SetupCurrentContentQueryString
                Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
                Deep.BuildJavascriptFromQueryString(QueryStringPermalink, WebvantageLink, ClientPortalLink)

                If Me.HideClientPortalDeepLink = True Then

                    Me.ContextMenuFloatie.FindItemByValue("ClientPortalLink").Visible = False

                Else

                    Me.ContextMenuFloatie.FindItemByValue("ClientPortalLink").Visible = Deep.ClientPortalVisible

                End If

            Else

                ''Me.ContextMenuFloatie.FindItemByValue("Bookmark").Visible = False
                '''Me.ContextMenuFloatie.FindItemByValue("NewAlert").Visible = False
                ''Me.ContextMenuFloatie.FindItemByValue("NewAssignment").Visible = False
                '''Me.ContextMenuFloatie.FindItemByValue("NewEmail").Visible = False
                ''Me.ContextMenuFloatie.FindItemByValue("SeparatorAlerts").Visible = False
                ''Me.ContextMenuFloatie.FindItemByValue("EditMenu").Visible = False
                ''Me.ContextMenuFloatie.FindItemByValue("WebvantageLink").Visible = False
                ''Me.ContextMenuFloatie.FindItemByValue("ClientPortalLink").Visible = False
                Me.DivShowShortMenu.Visible = False
                Me.DivShowFullMenu.Visible = False

                For Each Item As RadMenuItem In ContextMenuFloatie.Items

                    Select Case Item.Value
                        Case "NewAlert", "NewEmail", "SeparatorAlerts", "Print"

                            Item.Visible = True

                        Case "PrintSettings"

                            Item.Visible = True
                            Item.Text = "Print Settings"

                        Case Else

                            Item.Visible = False

                    End Select

                Next


            End If

        End If

        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim ClientName As String = String.Empty
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Description As String = String.Empty
            Dim ControlAbbreviation As String = String.Empty
            Dim ModuleName As String = String.Empty

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

            If JobComponent IsNot Nothing Then

                Job = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Job).Include("Client").Include("Division").Include("Product")
                       Where Entity.Number = Me.JobNumber
                       Select Entity).FirstOrDefault

                ClientName = Job.Client.Name

                If Job.Description.Trim = JobComponent.Description.Trim Then

                    Description = Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & JobComponent.Description

                Else

                    Description = Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & Job.Description & " - " & JobComponent.Description

                End If

                Select Case Me._ControlName
                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Alerts.ToString()

                        Me._PageTitle = "A "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Alerts.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Documents.ToString()

                        Me._PageTitle = "D "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Documents.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.MediaOrderList.ToString()

                        Me._PageTitle = "M "
                        ModuleName = "Media Order List"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief.ToString()

                        Me._PageTitle = "CB "
                        ModuleName = "Creative Briefs"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.JobSpecifications.ToString()

                        Me._PageTitle = "S "
                        ModuleName = "Specifications"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion.ToString()

                        Me._PageTitle = "V "
                        Try

                            Dim SQL As String = "SELECT COALESCE(NULLIF(CAST(AGY_SETTINGS_VALUE AS VARCHAR), ''), CAST(AGY_SETTINGS_DEF AS VARCHAR), 'Versions') FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'JOB_VERSION_DESC';"
                            ModuleName = DbContext.Database.SqlQuery(Of String)(SQL).SingleOrDefault

                        Catch ex As Exception
                            ModuleName = "Versions"
                        End Try

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Estimates.ToString()

                        Me._PageTitle = "E "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Schedule.ToString()

                        Me._PageTitle = "PS "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.PurchaseOrder.ToString()

                        Me._PageTitle = "PO "
                        ModuleName = "Purchase Orders"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.JobStatus_Team.ToString()

                        Me._PageTitle = "T "
                        ModuleName = "Team"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate.ToString()

                        Me._PageTitle = "JJ "
                        ModuleName = "Job Jacket"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.JobStatus.ToString()

                        Me._PageTitle = "JS "
                        ModuleName = "Status"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Events.ToString()

                        Me._PageTitle = "E "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Events.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Gantt.ToString()

                        Me._PageTitle = "G "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Gantt.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Risk.ToString()

                        Me._PageTitle = "RA "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Risk.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Calendar.ToString()

                        Me._PageTitle = "C "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Calendar.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.Workload.ToString()

                        Me._PageTitle = "W "
                        ModuleName = AdvantageFramework.Web.QueryString.ContentAreaName.Workload.ToString()

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.FinancialStatus.ToString()

                        Me._PageTitle = "FS "
                        ModuleName = "Financial Status"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.JobForecasts.ToString()

                        Me._PageTitle = "JF "
                        ModuleName = "Job Forecasts"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.AccountSetupForm.ToString()

                        Me._PageTitle = "AS "
                        ModuleName = "Account Setup"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.ProjectBoard.ToString()

                        Me._PageTitle = "B "
                        ModuleName = "Boards"

                    Case AdvantageFramework.Web.QueryString.ContentAreaName.DigitalAssetReviews.ToString(),
                         AdvantageFramework.Web.QueryString.ContentAreaName.Proofs.ToString()

                        Me._PageTitle = "P "
                        ModuleName = "Proofs"

                    Case Else

                        Me._PageTitle = Me._ControlName

                End Select

                Me._PageTitle &= Description

                Webvantage.Recents.AddToRecentJobs(DbContext, Me.JobNumber, Me.JobComponentNumber, JobComponent.Description)

            Else

                Webvantage.Recents.AddToRecentJobs(DbContext, Me.JobNumber, Me.JobComponentNumber, "")

            End If

            Me._PageTitle &= " | " & ClientName

            If Me.CurrentQuerystring.IsBookmark = False Then

                Me.PageTitle = Me._PageTitle

            End If



        End Using

    End Sub

#End Region
#Region " Controls "

    'Private Sub ActionButtonContentSave_ServerClick(sender As Object, e As EventArgs) Handles ActionButtonContentSave.ServerClick
    '    Select Case Me._ControlName
    '        Case "JobTemplate"
    '            'Me._ContentControlJobJacket_JobTemplate.Save()

    '    End Select
    'End Sub
    'Private Sub ActionButtonBookmark_ServerClick(sender As Object, e As EventArgs) Handles ActionButtonBookmark.ServerClick

    '    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
    '    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
    '    Dim QueryStringForBookmark As New AdvantageFramework.Web.QueryString()
    '    Dim s As String = ""

    '    With b

    '        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Content
    '        .UserCode = Session("UserCode")

    '        .Name = Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNumber.ToString().PadLeft(2, "0")

    '        If Me._ShowFullMenu = True Then

    '            If Me.RadTreeViewContent.SelectedNode IsNot Nothing Then

    '                .Name &= " - " & Me.RadTreeViewContent.SelectedNode.Text
    '                .Description = Me.RadTreeViewContent.SelectedNode.Text & " for " & Me._PageTitle

    '            Else

    '                .Name &= " - " & "Job Status"
    '                .Description = "Job Status for " & Me._PageTitle

    '            End If

    '        Else

    '            If Me.HiddenFieldSelectedShortMenuName.Value IsNot Nothing Then

    '                .Name &= " - " & Me.HiddenFieldSelectedShortMenuName.Value
    '                .Description = Me.HiddenFieldSelectedShortMenuName.Value & " for " & Me._PageTitle

    '            Else

    '                .Name &= " - " & "Job Status"
    '                .Description = "Job Status for " & Me._PageTitle

    '            End If

    '        End If

    '        QueryStringForBookmark = Me.SetupCurrentContentQueryString

    '        .PageURL = QueryStringForBookmark.ToString(True)

    '    End With

    '    If BmMethods.SaveBookmark(b, s) = False Then

    '        Me.ShowMessage(s)

    '    Else

    '        Me.RefreshBookmarksDesktopObject()

    '    End If

    'End Sub
    Private Function SetupCurrentContentQueryString() As AdvantageFramework.Web.QueryString

        Dim qs As New AdvantageFramework.Web.QueryString()

        'qs = qs.FromCurrent()

        qs.Page = "Content.aspx"
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNumber
        qs.ContentArea = Me.CurrentContentArea
        qs.IsBookmark = True

        If Me._ShowFullMenu = True Then

            If Me.RadTreeViewContent.SelectedNode IsNot Nothing Then

                qs.ContentArea = Me.CurrentContentArea

            Else

                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobStatus

            End If

        Else

            If Me.HiddenFieldSelectedShortMenuName.Value IsNot Nothing Then

                qs.ContentArea = Me.CurrentContentArea

            Else

                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobStatus

            End If

        End If

        Return qs

    End Function

    Private Sub ImageButtonSaveRadTreeViewContent_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonSaveRadTreeViewContent.Click

        If Me.IsClientPortal = False Then

            Dim NewSequenceNumber As Integer = 0
            For Each node As Telerik.Web.UI.RadTreeNode In Me.RadTreeViewContent.Nodes

                If node.LongDesc IsNot Nothing AndAlso node.LongDesc.Length > 0 Then

                    NewSequenceNumber += 1

                    Dim ContentItem As New AdvantageFramework.Database.Classes.Content
                    ContentItem.FromString(node.LongDesc)

                    If ContentItem IsNot Nothing Then

                        Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Dim ContentUserItem As AdvantageFramework.Database.Entities.ContentUser = Nothing
                            ContentUserItem = AdvantageFramework.Database.Procedures.ContentUser.LoadByID(dc, ContentItem.ContentUserID)

                            If ContentUserItem IsNot Nothing Then

                                ContentUserItem.SequenceNumber = NewSequenceNumber
                                ContentUserItem.IsVisible = node.Checked
                                AdvantageFramework.Database.Procedures.ContentUser.Update(dc, ContentUserItem)

                            Else

                                ContentUserItem = New AdvantageFramework.Database.Entities.ContentUser

                                ContentUserItem.UserCode = _Session.UserCode
                                ContentUserItem.ContentID = CType(Me._ContentType, Integer)
                                ContentUserItem.ContentItemID = ContentItem.ContentItemID
                                ContentUserItem.SequenceNumber = NewSequenceNumber
                                ContentUserItem.IsVisible = node.Checked

                                AdvantageFramework.Database.Procedures.ContentUser.Insert(dc, ContentUserItem)

                            End If

                        End Using

                    End If

                End If

            Next

            Me.RadTreeViewContent.CheckBoxes = False
            Me.RadTreeViewContent.EnableDragAndDrop = False
            Me.RadTreeViewContent.EnableDragAndDropBetweenNodes = False
            Me.LoadContentTree(False)
            Me.ImageButtonSaveRadTreeViewContent.Visible = False

            If Me._ShowFullMenu = False Then

                Me.LoadShortMenu()

            End If

            Me.SetMenuVisibilityAndStyle(Me._ShowFullMenu)

        End If

    End Sub
    Private Sub ImageButtonShowFullMenu_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonShowFullMenu.Click

        Me._ShowFullMenu = True

        Dim ContentPageSettings As New cAppVars(cAppVars.Application.CONTENT_PAGE)

        ContentPageSettings.getAllAppVars()
        ContentPageSettings.setAppVar("ShowFullMenu", Me._ShowFullMenu.ToString(), "Boolean")
        ContentPageSettings.SaveAllAppVars()

        Me.LoadMenu()
        Me.SetMenuVisibilityAndStyle(Me._ShowFullMenu)

    End Sub
    Private Sub ImageButtonShowShortMenu_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonShowShortMenu.Click

        Me._ShowFullMenu = False

        Dim ContentPageSettings As New cAppVars(cAppVars.Application.CONTENT_PAGE)

        ContentPageSettings.getAllAppVars()
        ContentPageSettings.setAppVar("ShowFullMenu", Me._ShowFullMenu.ToString(), "Boolean")
        ContentPageSettings.SaveAllAppVars()

        Me.LoadShortMenu()
        Me.LoadMenu()
        Me.SetMenuVisibilityAndStyle(Me._ShowFullMenu)

    End Sub

    Private Sub LinkButtonShortMenuItem_Click(sender As Object, e As EventArgs)

        Dim ar As String()
        ar = CType(sender, LinkButton).CommandArgument.ToString().Split("|")
        Me.HiddenFieldSelectedShortMenuName.Value = ar(1)
        Me.LoadContent(ar(0))
        Me.LoadShortMenu()

    End Sub

    Private Sub RadTreeViewContent_NodeClick(sender As Object, e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles RadTreeViewContent.NodeClick

        Me.LoadContent(e.Node.Value)
        Me.LoadContentTree(False)

    End Sub
    Private Sub RadTreeViewContent_NodeDrop(sender As Object, e As Telerik.Web.UI.RadTreeNodeDragDropEventArgs) Handles RadTreeViewContent.NodeDrop

        Dim sourceNode As RadTreeNode = e.SourceDragNode
        Dim destNode As RadTreeNode = e.DestDragNode
        Dim dropPosition As RadTreeViewDropPosition = e.DropPosition

        If destNode IsNot Nothing Then

            If sourceNode.TreeView.SelectedNodes.Count <= 1 Then

                AdvantageFramework.Web.Presentation.Controls.PerformRadTreeViewDragAndDrop(dropPosition, sourceNode, destNode, False)

            ElseIf sourceNode.TreeView.SelectedNodes.Count > 1 Then

                For Each node As RadTreeNode In sourceNode.TreeView.SelectedNodes

                    AdvantageFramework.Web.Presentation.Controls.PerformRadTreeViewDragAndDrop(dropPosition, node, destNode, False)

                Next

            End If

            destNode.Expanded = True
            sourceNode.TreeView.ClearSelectedNodes()

        End If
    End Sub

    Private Sub RepeaterShortMenu_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RepeaterShortMenu.ItemCommand
        Select Case e.CommandName
            Case "LoadContent"

                Dim ar As String()
                ar = e.CommandArgument.ToString.Split("|")
                Me.HiddenFieldSelectedShortMenuName.Value = ar(1)
                Me.LoadContent(ar(0))
                Me.LoadShortMenu()

        End Select
    End Sub
    Private Sub RepeaterShortMenu_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RepeaterShortMenu.ItemDataBound

        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem

                Dim ShortMenuItemDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivShortMenuItem")
                Dim ShortMenuItemLinkButton As LinkButton = e.Item.FindControl("LinkButtonShortMenuItem")

                If ShortMenuItemDiv IsNot Nothing AndAlso ShortMenuItemLinkButton IsNot Nothing Then

                    Dim ContentItem As AdvantageFramework.Database.Classes.Content = CType(e.Item.DataItem, AdvantageFramework.Database.Classes.Content)

                    If ContentItem IsNot Nothing Then

                        Dim ToolTip As String = String.Empty
                        Dim Skip As Boolean = False

                        ''If (ContentItem.ContentCode = "DigitalAssetReviews" OrElse ContentItem.Name = "Reviews" OrElse ContentItem.Name.Contains("Proof")) AndAlso
                        ''    cApplication.IsProofingToolActive(Me.SecuritySession) = False Then

                        ''    Skip = True
                        ''    ContentItem.IsVisible = False

                        ''End If
                        If ContentItem.ContentCode = "DigitalAssetReviews" Then

                            If Me.IsProofingActive = False AndAlso Me.IsConceptShareActive = False Then

                                Skip = True
                                ContentItem.IsVisible = False

                            ElseIf Me.IsProofingActive = True AndAlso Me.IsConceptShareActive = False Then

                                ContentItem.Name = "Proofs"

                            ElseIf Me.IsProofingActive = False AndAlso Me.IsConceptShareActive = True Then

                                ContentItem.Name = "Reviews"

                            ElseIf Me.IsProofingActive = True AndAlso Me.IsConceptShareActive = True Then

                                ContentItem.Name = "Proofs"

                            End If

                        End If


                        'If ContentItem.Name = "ProjectBoard" AndAlso cApplication.EnableKanBan(Me.SecuritySession) = False Then

                        '    Skip = True
                        '    ContentItem.IsVisible = False

                        'End If
                        If ContentItem.IsVisible = False Then

                            Skip = True

                        End If
                        If Skip = True Then

                            AdvantageFramework.Web.Presentation.Controls.DivHide(ShortMenuItemDiv)

                        Else

                            If (ContentItem.ModuleCode Is Nothing) OrElse (ContentItem.ModuleCode IsNot Nothing AndAlso Me.CheckModuleAccess(_Session.User, ContentItem.ModuleCode, True) = 1) Then

                                If (ContentItem.Name = "Alerts") Then

                                    ShortMenuItemDiv.Attributes.Add("title", "Click to see Assignments & Alerts")

                                Else

                                    If ContentItem.ContentCode = "DigitalAssetReviews" Then

                                        If Me.IsConceptShareActive = True AndAlso Me.IsProofingActive = False Then

                                            ShortMenuItemDiv.Attributes.Add("title", "Click to see Reviews")

                                        Else

                                            ShortMenuItemDiv.Attributes.Add("title", "Click to see Proofs")

                                        End If

                                    Else

                                        ShortMenuItemDiv.Attributes.Add("title", "Click to see " & ContentItem.Name)

                                    End If

                                End If

                                If ContentItem.Name.Contains(" ") Then

                                    Dim ar() As String
                                    ar = ContentItem.Name.Split(" ")

                                    If ar.Length > 1 Then

                                        ShortMenuItemLinkButton.Text = ar(0).Substring(0, 1) & ar(1).Substring(0, 1)

                                    Else

                                        ShortMenuItemLinkButton.Text = ContentItem.Name.Substring(0, 1)

                                    End If

                                Else

                                    ShortMenuItemLinkButton.Text = ContentItem.Name.Substring(0, 1)

                                End If

                                If (ContentItem.Name = "Alerts") Then

                                    ToolTip = "Assignments & Alerts"

                                Else

                                    ToolTip = ContentItem.Name

                                End If

                                Select Case ContentItem.Name
                                    Case "Schedule"

                                        ShortMenuItemLinkButton.Text = "PS"

                                    Case "Events"

                                        ShortMenuItemLinkButton.Text = "EV"

                                    Case "ProjectBoard"

                                        ShortMenuItemLinkButton.Text = "PB"

                                    Case "Sprints"

                                        ShortMenuItemLinkButton.Text = "SP"

                                End Select

                                If ContentItem.ContentCode = "DigitalAssetReviews" Then

                                    If Me.IsConceptShareActive = True AndAlso Me.IsProofingActive = False Then

                                        ToolTip = "Reviews"
                                        ShortMenuItemLinkButton.Text = "R"

                                    Else

                                        ToolTip = "Proofs"
                                        ShortMenuItemLinkButton.Text = "Pr"

                                    End If

                                End If

                                ToolTip = "Click to see " & ToolTip

                                ShortMenuItemLinkButton.TabIndex = -1
                                ShortMenuItemLinkButton.ToolTip = ToolTip
                                ShortMenuItemLinkButton.CommandName = "LoadContent"
                                ShortMenuItemLinkButton.CommandArgument = ContentItem.ContentCode.ToString() & "|" & ContentItem.Name

                                If ContentItem.HasContent = False Then

                                    ShortMenuItemLinkButton.CssClass = "no-item "

                                Else

                                    ShortMenuItemLinkButton.CssClass = "dark-highlight-color "

                                End If

                                If CurrentContentArea.ToString = ContentItem.ContentCode Then

                                    ShortMenuItemLinkButton.CssClass &= "content-page-short-menu-text-selected"
                                    Me.HiddenFieldSelectedShortMenuName.Value = ContentItem.Name

                                Else

                                    ShortMenuItemLinkButton.CssClass &= "content-page-short-menu-text"

                                End If

                            Else

                                AdvantageFramework.Web.Presentation.Controls.DivHide(ShortMenuItemDiv)

                            End If

                        End If

                    End If

                End If

        End Select

    End Sub

#End Region

#Region " Load "

    Private Sub LoadContent(ByVal ContentCode As String)

        ''If ContentCode <> "JobTemplate" Then

        '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '        If AdvantageFramework.ProjectManagement.JobComponentIsMissingRequiredField(DbContext, Me._JobNumber, Me._JobComponentNumber) = True Then

        ''            ContentCode = "JobTemplate"
        ''            Me.ShowMessage("Job missing required information")

        ''        End If

        ''    End Using

        ''End If

        Me._ContentSaveButtonVisible = False
        Me._ControlName = ContentCode
        Me.CurrentContentArea = DirectCast([Enum].Parse(GetType(AdvantageFramework.Web.QueryString.ContentAreaName), Me._ControlName), AdvantageFramework.Web.QueryString.ContentAreaName)
        Me.LoadContentDetail()

    End Sub
    'Session variables in the below sub are legacy.  Do not add session variables when querystring class is usable!
    Private Sub LoadContentDetail()

        If Me.JobNumber = 0 OrElse Me.JobComponentNumber = 0 Then

            Exit Sub

        End If

        Me.PlaceHolderContent.Controls.Clear()

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs.IsJobDashboard = True
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNumber
        qs.AamShowAssignmentType = Me.AAMShowAssignmentType
        qs.IsBookmark = Me.IsBookmark

        Select Case Me._ControlName

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Alerts.ToString()

                'If IsClientPortal = True Then
                '    qs.Page = "Alert_Inbox.aspx"
                'Else
                qs.Page = "~/Desktop/Inbox"
                'qs.Page = "Alert_Inbox.aspx"
                'End If

                Me.UseIFrame(qs)

                If Me.IsClientPortal = False AndAlso Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.Desktop_Alerts) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Calendar.ToString()

                qs.Page = "Calendar_MonthView.aspx"
                qs.Add("FromApp", "PS")
                If Session("PMD_Calendar_View") IsNot Nothing Then
                    qs.Add("calView", Session("PMD_Calendar_View"))
                End If

                Me.UseIFrame(qs)

                If Me.IsClientPortal = False AndAlso Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.Desktop_Calendar) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief.ToString()

                Try

                    Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
                    Dim existingtemps As Boolean

                    Session("FromWindow") = "ProjectView"
                    Session("CBDeleted") = 0
                    Session("CBNewSaved") = 1

                    existingtemps = cb.ExistingTemplates(Me.JobNumber, Me.JobComponentNumber)

                    If existingtemps = False Then

                        If MiscFN.IsClientPortal = True Then

                            Me.ShowMessage("No Creative Brief exist for this job.")
                            Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate.ToString()
                            qs.Page = "JobTemplate.aspx"
                            qs.Add("PageMode", "Edit")

                        Else

                            Session("CBNewSaved") = 0
                            Session("CBNewCanceled") = 0

                            qs.Page = "CreativeBrief_New.aspx"
                            qs.Add("fw", "ProjectView")
                            Me.UseIFrame(qs)

                        End If

                    Else

                        qs.Page = "CreativeBrief.aspx"
                        qs.Add("fw", "")
                        Me.UseIFrame(qs)

                    End If

                Catch ex As Exception

                    qs.Page = "CreativeBrief.aspx"
                    qs.Add("fw", "")
                    Me.UseIFrame(qs)

                End Try

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_CreativeBrief) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Documents.ToString()

                Session("FromWindow") = "ProjectView"
                Session("DocFilterLevel") = "JC"
                Session("DocFilterValue") = Me.JobNumber.ToString() & "," & Me.JobComponentNumber.ToString()

                qs.Page = "Documents_JobComponent.aspx"
                qs.Add("m", "D")
                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.Desktop_DocumentManager) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Estimates.ToString()

                Dim dr As SqlDataReader
                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                dr = oEstimating.GetEstJob(Me.JobNumber, Me.JobComponentNumber)
                If dr.HasRows = True Then

                    dr.Read()

                    If dr("ESTIMATE_NUMBER") <> 0 Then

                        qs.Page = "Estimating.aspx"
                        qs.Add("JT", "0")
                        qs.Add("newEst", "edit")
                        qs.EstimateNumber = dr("ESTIMATE_NUMBER")
                        qs.EstimateComponentNumber = dr("EST_COMPONENT_NBR")

                    Else

                        qs.Page = "Estimating_AddNew.aspx"
                        qs.Add("JT", "0")
                        qs.Add("newEst", "job")

                    End If

                Else

                    qs.Page = "Estimating_AddNew.aspx"
                    qs.Add("JT", "0")
                    qs.Add("newEst", "job")

                End If

                Me.HideClientPortalDeepLink = True
                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_Estimating) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Events.ToString()

                qs.Page = "Event_View.aspx"
                Me.HideClientPortalDeepLink = True
                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_Events) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Gantt.ToString()

                qs.Page = "angulargantt.aspx"
                qs.JobComponentNumber = Me.JobComponentNumber
                qs.JobNumber = Me.JobNumber
                qs.Add("from", "ps")

                'qs.Page = String.Format("{0}{1}/{2}/{3}", Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute,
                '                                                         "ProjectScheduleGantt", qs.JobNumber, qs.JobComponentNbr)


                Me.UseIFrame(qs)

            Case AdvantageFramework.Web.QueryString.ContentAreaName.JobForecasts.ToString()

                qs.Page = "JobForecast_Job.aspx"

                Me.HideClientPortalDeepLink = True
                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.JobSpecifications.ToString()

                Dim js As New Job_Specs(Session("ConnString"))
                Dim dr As SqlDataReader

                dr = js.GetJobSpecData(Me.JobNumber, Me.JobComponentNumber, -1, -1)
                If dr.HasRows = False Then
                    If MiscFN.IsClientPortal = True Then

                        Me.ShowMessage("No Specifications exist for this job.")
                        Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate.ToString()
                        qs.Page = "JobTemplate.aspx"
                        qs.Add("PageMode", "Edit")

                    Else

                        qs.Add("AddType", "4")
                        qs.Page = "jobspecs_AddNew.aspx"

                    End If
                Else

                    qs.Page = "jobspecs.aspx"

                End If

                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_Specifications) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.JobStatus.ToString()

                qs.Page = "JobStatus.aspx"

                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_JobJacket) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.JobStatus_Team.ToString()

                qs.Page = "JobStatus_Team.aspx"

                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_ProjectSchedule) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate.ToString()

                Me.PlaceHolderContent.Visible = False

                qs.Page = "JobTemplate.aspx"
                qs.Add("PageMode", "Edit")

                If Me.CurrentQuerystring("NewJob") = "1" Then
                    qs.Add("NewJob", "1")
                End If

                If Me.CurrentQuerystring("NewComp") = "new" Then
                    qs.Add("NewComp", "new")
                End If

                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_JobJacket) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion.ToString()

                Try

                    Dim jv As New JobVersion(HttpContext.Current.Session("ConnString"))
                    If jv.ExistingTemplates(Me.JobNumber, Me.JobComponentNumber) = True Then

                        qs.Page = "jobVersions.aspx"

                    Else

                        qs.Page = "jobVerNew.aspx"

                    End If


                Catch ex As Exception

                    qs.Page = "jobVerNew.aspx"

                End Try

                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_JobVersions) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.MediaOrderList.ToString()

                qs.Page = "MediaOrder_List.aspx"

                Me.HideClientPortalDeepLink = True
                Me.UseIFrame(qs)

            Case AdvantageFramework.Web.QueryString.ContentAreaName.PurchaseOrder.ToString()

                qs.Page = "purchaseOrderbyJobCompPopup.aspx"

                Me.HideClientPortalDeepLink = True
                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_PurchaseOrders) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.FinancialStatus.ToString()

                qs.Page = "QuoteVsActualSummaryPopup.aspx"

                Me.HideClientPortalDeepLink = True
                Me.UseIFrame(qs)

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Risk.ToString()

                qs.Page = "TrafficSchedule_Status_Graph.aspx"

                Me.UseIFrame(qs)

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Schedule.ToString()

                Dim Schedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim x As Integer = Schedule.CheckExistsClosed(Me.JobNumber, Me.JobComponentNumber)

                Select Case x
                    Case 0, -2

                        qs.Add("JT", "2")

                        Select Case Me._ControlName
                            Case AdvantageFramework.Web.QueryString.ContentAreaName.Schedule.ToString()

                                'If IsClientPortal = True Then

                                '    qs.Page = String.Format("{0}{1}/{2}/{3}", Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute,
                                '                                         "Index", qs.JobNumber, qs.JobComponentNumber)

                                'Else

                                qs.Page = String.Format("{0}{1}/{2}/{3}", Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute,
                                                                             "ProjectScheduleDetail", qs.JobNumber, qs.JobComponentNumber)

                                'End If


                            Case AdvantageFramework.Web.QueryString.ContentAreaName.ProjectBoard.ToString()

                        End Select

                    Case -1

                        If MiscFN.IsClientPortal = True Then

                            Me.ShowMessage("No Project Schedule exists for this Job")
                            Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate.ToString()
                            qs.Page = "JobTemplate.aspx"
                            qs.Add("PageMode", "Edit")

                        Else

                            qs.Add("JT", "2")

                            qs.Add("JobNumber", qs.JobNumber)
                            qs.Add("JobComponentNumber", qs.JobComponentNumber)

                            Select Case Me._ControlName
                                Case AdvantageFramework.Web.QueryString.ContentAreaName.Schedule.ToString()

                                    qs.Add("isPB", "0")

                                Case AdvantageFramework.Web.QueryString.ContentAreaName.ProjectBoard.ToString()

                                    qs.Add("isPB", "1")

                            End Select

                            qs.Page = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create"

                        End If

                End Select

                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_ProjectSchedule) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.ProjectBoard.ToString()

                qs.Page = String.Format("{0}{1}",
                                        Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute,
                                        "AgileBoards")

                Me.UseIFrame(qs)

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Workload.ToString()

                Me.HideClientPortalDeepLink = True
                Dim Schedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim DataTable As System.Data.DataTable = Nothing

                DataTable = Schedule.GetScheduleHeader(Me.JobNumber, Me.JobComponentNumber, _Session.UserCode, False).Tables(0)

                If DataTable.Rows.Count > 0 Then

                    Dim StartDate As String = ""
                    Dim DueDate As String = ""
                    If IsDBNull(DataTable.Rows(0)("START_DATE")) = False AndAlso cGlobals.wvIsDate(DataTable.Rows(0)("START_DATE")) = True Then

                        StartDate = CType(DataTable.Rows(0)("START_DATE"), Date).ToShortDateString()
                        If StartDate = "1/1/1900" Then StartDate = ""

                    End If
                    If IsDBNull(DataTable.Rows(0)("JOB_FIRST_USE_DATE")) = False AndAlso cGlobals.wvIsDate(DataTable.Rows(0)("JOB_FIRST_USE_DATE")) = True Then

                        DueDate = CType(DataTable.Rows(0)("JOB_FIRST_USE_DATE"), Date).ToShortDateString()
                        If DueDate = "1/1/1900" Then DueDate = ""

                    End If

                    If StartDate = "" OrElse DueDate = "" Then

                        Me.ShowMessage("Workload analysis requires a schedule with valid start and due dates.")
                        Exit Sub

                    Else

                        Session("WorkloadStart") = StartDate
                        Session("WorkloadEnd") = DueDate
                        Session("WorkloadIsMulti") = "False"
                        Session("WorkloadJobCompList") = Me.JobNumber.ToString() & "," & Me.JobComponentNumber.ToString() & "|"

                        qs.Page = "TrafficSchedule_Workload2.aspx"

                        Me.UseIFrame(qs)

                    End If

                Else

                    Me.ShowMessage("Workload analysis requires a schedule with valid start and due dates.")
                    Exit Sub

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.AccountSetupForm.ToString()

                qs.Page = "AccountSetupForm.aspx"
                Me.HideClientPortalDeepLink = True
                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_AccountSetupForm) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

            Case AdvantageFramework.Web.QueryString.ContentAreaName.DigitalAssetReviews.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.Proofs.ToString(), "Proof", "Reviews"

                If Me.IsProofingActive = True OrElse Me.IsConceptShareActive = True Then

                    qs.Page = "DigitalAsset_Reviews.aspx"

                Else

                    qs.Page = "JobStatus.aspx"

                End If

                Me.UseIFrame(qs)

            Case Else

                qs.Page = "JobStatus.aspx"
                Me.UseIFrame(qs)

                If Me.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_JobJacket) = False Then

                    Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                    Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False

                End If

        End Select

        Select Case Me._ControlName
            Case AdvantageFramework.Web.QueryString.ContentAreaName.MediaOrderList.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.JobForecasts.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.FinancialStatus.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.PurchaseOrder.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.Calendar.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.DigitalAssetReviews.ToString(),
                 AdvantageFramework.Web.QueryString.ContentAreaName.Proofs.ToString()

                Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("NewEmail").Visible = False

            Case AdvantageFramework.Web.QueryString.ContentAreaName.Events.ToString()

                Me.ContextMenuFloatie.FindItemByValue("Print").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = False
                Me.ContextMenuFloatie.FindItemByValue("NewEmail").Visible = True

            Case Else

                Me.ContextMenuFloatie.FindItemByValue("Print").Visible = True
                Me.ContextMenuFloatie.FindItemByValue("PrintSettings").Visible = True
                Me.ContextMenuFloatie.FindItemByValue("SeparatorPrint").Visible = True
                Me.ContextMenuFloatie.FindItemByValue("NewEmail").Visible = True

        End Select

        Dim ClientPortalLink As RadMenuItem = ContextMenuFloatie.Items.FindItemByValue("ClientPortalLink")

        If ClientPortalLink IsNot Nothing Then

            If Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.JobStatus.ToString() OrElse
                Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate.ToString() OrElse
                Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.Alerts.ToString() OrElse
                Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief.ToString() OrElse
                Me._ControlName = AdvantageFramework.Web.QueryString.ContentAreaName.Calendar.ToString() Then

                ClientPortalLink.Visible = True

            Else

                ClientPortalLink.Visible = False

            End If

        End If

    End Sub
    Private Sub UsePlaceholder()

        Me.PlaceHolderContent.Visible = True

        Me.IFrameContent.Attributes.Remove("src")
        Me.IFrameContent.Visible = False

    End Sub
    Private Sub UseIFrame(ByRef QueryString As AdvantageFramework.Web.QueryString)

        Me.PlaceHolderContent.Visible = False

        Me.IFrameContent.Visible = True
        Me.IFrameContent.Attributes.Remove("src")
        Me.IFrameContent.Attributes.Add("src", QueryString.ToString(True))

    End Sub
    Private Sub LoadContentTree(ByVal LoadForEdit As Boolean)

        Me.RadTreeViewContent.Nodes.Clear()
        Me._MenuList = Nothing
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me._MenuList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.Content)(String.Format("EXEC advsp_get_content_for_user '{0}', {1}, '{2}', {3}, {4};", _Session.UserCode,
                                                                                                      CType(Me._ContentType, Integer), Session("EmpCode"), Me.JobNumber, Me.JobComponentNumber)).ToList()

        End Using

        If _MenuList IsNot Nothing AndAlso _MenuList.Count > 0 Then

            Dim node As Telerik.Web.UI.RadTreeNode
            Dim Skip As Boolean = False

            For Each ContentItem As AdvantageFramework.Database.Classes.Content In _MenuList

                Skip = False

                ''If (ContentItem.ContentCode = "DigitalAssetReviews" OrElse ContentItem.ContentCode.Contains("Proof")) AndAlso
                ''    cApplication.IsProofingToolActive(Me.SecuritySession) = False Then

                ''    Skip = True

                ''End If
                If ContentItem.ContentCode = "DigitalAssetReviews" Then

                    If Me.IsProofingActive = False AndAlso Me.IsConceptShareActive = False Then

                        Skip = True
                        ContentItem.IsVisible = False

                    ElseIf Me.IsProofingActive = True AndAlso Me.IsConceptShareActive = False Then

                        ContentItem.Name = "Proofs"

                    ElseIf Me.IsProofingActive = False AndAlso Me.IsConceptShareActive = True Then

                        ContentItem.Name = "Reviews"

                    ElseIf Me.IsProofingActive = True AndAlso Me.IsConceptShareActive = True Then

                        ContentItem.Name = "Proofs"

                    End If

                End If

                'If ContentItem.Name = "Gantt" Then

                '    Skip = True

                'End If
                If ContentItem.ContentCode = "Alerts" Then
                    ContentItem.Name = "Assignments & Alerts"
                End If
                If Skip = False Then

                    If Me.IsClientPortal = True Then

                        If ContentItem.ModuleCode = "Desktop_DocumentManager" Then ContentItem.ModuleCode = "ProjectManagement_Documents"

                        If ContentItem.ModuleCode Is Nothing OrElse (ContentItem.ModuleCode IsNot Nothing AndAlso Me.CheckModuleAccess(_Session.ClientPortalUser, ContentItem.ModuleCode, True) = -1) OrElse
                        (ContentItem.ModuleCode IsNot Nothing AndAlso Me.CheckModuleAccess(_Session.ClientPortalUser, ContentItem.ModuleCode, True) = 1) Then

                            If ContentItem.Name <> "Team" AndAlso ContentItem.Name <> "Gantt" AndAlso ContentItem.Name <> "Risk Analysis" AndAlso ContentItem.Name <> "Workload" AndAlso
                           ContentItem.Name <> "Media" AndAlso ContentItem.Name <> "Reports" AndAlso ContentItem.Name <> "Account Setup" Then

                                AddNodeToContentTree(ContentItem, LoadForEdit)

                            End If

                        End If

                    Else

                        If ContentItem.ModuleCode Is Nothing OrElse (ContentItem.ModuleCode IsNot Nothing AndAlso Me.CheckModuleAccess(_Session.User, ContentItem.ModuleCode, True) = 1) Then

                            AddNodeToContentTree(ContentItem, LoadForEdit)

                        End If

                    End If

                End If
            Next

        End If

        Dim CurrentNode As RadTreeNode = Me.RadTreeViewContent.Nodes.FindNodeByValue(Me.CurrentContentArea.ToString())
        If CurrentNode IsNot Nothing AndAlso CurrentNode.Visible = True Then CurrentNode.Selected = True

    End Sub
    Private Sub AddNodeToContentTree(ByVal ContentItem As AdvantageFramework.Database.Classes.Content, ByVal LoadForEdit As Boolean)

        Dim node As New Telerik.Web.UI.RadTreeNode
        Dim ToolTip As String = String.Empty

        If LoadForEdit = False Then node.Visible = ContentItem.IsVisible

        ToolTip = ContentItem.Name

        Select Case ContentItem.Name

            Case "Reviews", "Proof", "Proofs"

                ToolTip = "Proofs"

        End Select

        ToolTip = "Click to see " & ToolTip

        node.TabIndex = -1
        node.Text = ContentItem.Name
        node.LongDesc = ContentItem.ToString()
        node.Checked = ContentItem.IsVisible
        node.Value = ContentItem.ContentCode.ToString()
        node.ToolTip = ToolTip

        If ContentItem.HasContent = False AndAlso LoadForEdit = False Then node.CssClass = "no-item"

        node.Checkable = LoadForEdit

        Me.RadTreeViewContent.Nodes.Add(node)

        node = Nothing

    End Sub
    Private Sub LoadShortMenu()

        Me._MenuList = Nothing
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me._MenuList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.Content)(String.Format("EXEC advsp_get_content_for_user '{0}', {1}, '{2}', {3}, {4};", _Session.UserCode,
                                                                                                      CType(Me._ContentType, Integer), Session("EmpCode"), Me.JobNumber, Me.JobComponentNumber)).ToList()

        End Using
        If _MenuList IsNot Nothing AndAlso _MenuList.Count > 0 Then

            Me.RepeaterShortMenu.DataSource = _MenuList
            Me.RepeaterShortMenu.DataBind()

        End If

    End Sub
    Private Sub LoadMenu()

        If Me._ShowFullMenu = True Then

            Me.LoadContentTree(False)
            Me.SetTreeViewSelectedNode()

        Else

            Me.LoadShortMenu()
            Me.SetShortMenuRepeaterSelectedLinkButton()

        End If

        Me.SetMenuVisibilityAndStyle(Me._ShowFullMenu)

    End Sub

#End Region

    Private Sub ActionButtonAction(ByVal Action As Webvantage.BasePrintSendPage.PageMode)

        Me._ContentPageData.Load()

        Dim qs As New AdvantageFramework.Web.QueryString()
        Dim title As String = ""

        qs.IsJobDashboard = True
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNumber
        qs.Add("mode", Action)

        Select Case Me._ControlName
            Case "CreativeBrief"

                qs.Page = "CreativeBrief_Print.aspx"

            Case "Estimates"

                qs.Page = "Estimating_PrintSettings.aspx"
                qs.Add("from", "Est")

                If Me._ContentPageData.EstimateNumber > 0 Then qs.EstimateNumber = Me._ContentPageData.EstimateNumber
                If Me._ContentPageData.EstimateComponentNumber > 0 Then qs.EstimateComponentNumber = Me._ContentPageData.EstimateComponentNumber
                qs.Add("sel_quotes", Me._ContentPageData.EstimateSelectedQuoteNumbers)
                qs.Add("sel_quotes_desc", Me._ContentPageData.EstimateSelectedQuoteDescriptions)
                qs.Add("content", 1)
                'qs.Add("print_all", Me._ContentPageData.EstimatePrintSendAll)
                title = "Print/Send Estimate"

            Case "Gantt"

                qs.Page = "TrafficSchedule_Print.aspx"
                qs.Add("pm", "0")
                title = "Print/Send Project Schedule"

            Case "JobSpecifications"

                qs.Page = "JobSpecs_Print.aspx"
                Session("JSDescription") = Me._ContentPageData.JobSpecDescription
                Session("JSReason") = Me._ContentPageData.JobSpecReason

                If Me._ContentPageData.JobSpecVersionID > 0 Then qs.VersionID = Me._ContentPageData.JobSpecVersionID
                If Me._ContentPageData.JobSpecRevisionID > 0 Then qs.RevisionID = Me._ContentPageData.JobSpecRevisionID

            Case "JobVersion"

                If Session("versionNbr") IsNot Nothing Then

                    qs.Page = "JobVersion_Print.aspx"
                    qs.Add("fromapp", "jobVerTmplt")
                    qs.Add("content", 1)

                    qs.JobVersionHeaderID = Me._ContentPageData.JobVersionHeaderID
                    qs.JobVersionSequenceNumber = Session("versionNbr")

                End If

            Case "PurchaseOrder"

                If Me._ContentPageData.PurchaseOrderNumber IsNot Nothing AndAlso IsNumeric(Me._ContentPageData.PurchaseOrderNumber) = True Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim HasDetails As Boolean = False
                        HasDetails = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, Me._ContentPageData.PurchaseOrderNumber)
                                      Select Entity).Any

                        Dim s As String = ""
                        If HasDetails = True AndAlso purchaseorder.NeedsApprovalAndApprove(Me._ContentPageData.PurchaseOrderNumber, Me._ContentPageData.PurchaseOrderPad, Me._ContentPageData.PurchaseOrderEmployeeCode, s) = False Then

                            If Me._ContentPageData.PurchaseOrderNeedsApprovalAndApprove = False Then

                                qs.Page = "PurchaseOrder_Print.aspx"
                                qs.Add("Fromjj", "jjpo")
                                qs.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(Me._ContentPageData.PurchaseOrderNumber))
                                qs.Add("callingpagemode", Me._ContentPageData.PurchaseOrderCallingPageMode)

                            End If

                        End If

                    End Using

                Else

                    Me.DefaultQuerystringAction(qs, Action)

                End If

            Case "Risk"

                qs.Page = "TrafficSchedule_Print.aspx"
                qs.Add("pm", "0")
                qs.Add("content", 1)

            Case "Schedule"

                qs.Page = "TrafficSchedule_Print.aspx"
                qs.Add("pm", "0")
                qs.Add("content", 1)
                title = "Print/Send Project Schedule"

            Case "Workload"

                qs.Page = "TrafficSchedule_Print.aspx"
                qs.Add("pm", "0")
                qs.Add("content", 1)

            Case "AccountSetupForm"

                qs.Page = "AccountSetupForm_Print.aspx"

            Case Else

                Me.DefaultQuerystringAction(qs, Action)

        End Select

        If String.IsNullOrWhiteSpace(qs.Page) = False Then

            If Action = BasePrintSendPage.PageMode.Options OrElse
               Action = BasePrintSendPage.PageMode.NewAlert OrElse
               Action = BasePrintSendPage.PageMode.NewAssignment OrElse
               Action = BasePrintSendPage.PageMode.NewProof OrElse
               qs.Page = "AccountSetupForm_Print.aspx" Then

                Me.OpenWindow(qs, title)

            Else

                Me.OpenPrintSendSilently(qs)

            End If

        End If

    End Sub
    Private Sub DefaultQuerystringAction(ByRef QS As AdvantageFramework.Web.QueryString, ByVal Action As Webvantage.BasePrintSendPage.PageMode)
        Select Case Action

            Case BasePrintSendPage.PageMode.NewProof

                QS.Page = "Desktop_NewAssignment"
                QS.Add("caller", "review")
                QS.Add("f", "1")
                QS.Add("jt", "1")
                QS.Add("assn", "1")

                QS.ClientCode = Me.ClientCode
                QS.DivisionCode = Me.DivisionCode
                QS.ProductCode = Me.ProductCode
                QS.JobNumber = Me.JobNumber
                QS.JobComponentNumber = Me.JobComponentNumber

            Case BasePrintSendPage.PageMode.NewAlert

                QS.Page = "Alert_New.aspx"
                QS.Add("caller", "jobtemplate")
                QS.Add("f", "1")
                QS.Add("jt", "1")
                QS.Add("content", "1")

                If Me._ControlName = "JobTemplate" Then QS.Add("pagetype", "jt")

            Case BasePrintSendPage.PageMode.NewAssignment

                QS.Page = "Alert_New.aspx"
                QS.Add("caller", "jobtemplate")
                QS.Add("f", "1")
                QS.Add("jt", "1")
                QS.Add("assn", "1")
                QS.Add("content", "1")

                If Me._ControlName = "JobTemplate" Then QS.Add("pagetype", "jt")

            Case BasePrintSendPage.PageMode.SendAlert

                'QS.Page = "Alert_New.aspx"
                'QS.Add("caller", "jobtemplate")
                'QS.Add("f", "1")
                'QS.Add("jt", "1")
                'QS.Add("content", "1")

                'If Me._ControlName = "JobTemplate" Then QS.Add("pagetype", "jt")
                QS.Page = "JobTemplate_Print.aspx"
                QS.Add("fromapp", "jobtemplate")
                QS.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)
                QS.Add("content", "1")

            Case BasePrintSendPage.PageMode.SendAssignment

                'QS.Page = "Alert_New.aspx"
                'QS.Add("caller", "jobtemplate")
                'QS.Add("f", "1")
                'QS.Add("jt", "1")
                'QS.Add("assn", "1")
                'QS.Add("content", "1")

                'If Me._ControlName = "JobTemplate" Then QS.Add("pagetype", "jt")

                QS.Page = "JobTemplate_Print.aspx"
                QS.Add("fromapp", "jobtemplate")
                QS.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)
                QS.Add("content", "1")

            Case BasePrintSendPage.PageMode.SendEmail

                QS.Page = "JobTemplate_Print.aspx"
                QS.Add("fromapp", "jobtemplate")
                QS.Add("content", "1")

            Case BasePrintSendPage.PageMode.Print, BasePrintSendPage.PageMode.Options

                QS.Page = "JobTemplate_Print.aspx"
                QS.Add("fromapp", "jobtemplate")
                QS.Add("content", "1")

        End Select

    End Sub
    Private Sub SetTreeViewSelectedNode()
        Dim SelectedNode As Telerik.Web.UI.RadTreeNode

        SelectedNode = Me.RadTreeViewContent.FindNodeByValue(Me._ControlName)

        If SelectedNode IsNot Nothing Then

            SelectedNode.Selected = True

        End If

    End Sub
    Private Sub SetShortMenuRepeaterSelectedLinkButton()

        Dim SelectedLinkButton As LinkButton
        Dim SelectedLinkButtonFound As Boolean = False
        Dim ContentItem As AdvantageFramework.Database.Classes.Content

        For Each RptrItm As RepeaterItem In Me.RepeaterShortMenu.Items

            Select Case RptrItm.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item

                    SelectedLinkButton = CType(RptrItm.FindControl("LinkButtonShortMenuItem"), LinkButton)
                    ContentItem = RptrItm.DataItem

                    If ContentItem IsNot Nothing AndAlso SelectedLinkButton IsNot Nothing Then

                        If ContentItem.HasContent = False Then

                            SelectedLinkButton.CssClass = "no-item "

                        Else

                            SelectedLinkButton.CssClass = "dark-highlight-color "

                        End If

                        If CurrentContentArea.ToString = ContentItem.ContentCode Then

                            SelectedLinkButton.CssClass &= "content-page-short-menu-text-selected"

                        Else

                            SelectedLinkButton.CssClass &= "content-page-short-menu-text"

                        End If

                    End If

            End Select

        Next

    End Sub
    Private Sub SetMenuVisibilityAndStyle(ByVal ShowFullMenu As Boolean)

        Me.DivLeftFullMenu.Visible = ShowFullMenu
        Me.DivLeftShortMenu.Visible = Not ShowFullMenu

        If ShowFullMenu = True Then

            AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivLeftSideNavigation, "content-left-full")
            AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivMainContent, "content-main-full")

        Else

            AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivLeftSideNavigation, "content-left-short")
            AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivMainContent, "content-main-short")

        End If

    End Sub

#End Region

End Class

'' ''Select Case Me._ControlName
'' ''    Case "Alerts"


'' ''    Case "CreativeBrief"


'' ''    Case "Documents"


'' ''    Case "Estimates"


'' ''    Case "Events"


'' ''    Case "Gantt"


'' ''    Case "JobSpecifications"


'' ''    Case "JobStatus"


'' ''    Case "JobStatus_Team"


'' ''    Case "JobTemplate"


'' ''    Case "JobVersion"


'' ''    Case "PurchaseOrder"


'' ''    Case "QvA"


'' ''    Case "Risk"


'' ''    Case "Schedule"


'' ''    Case "Workload"


'' ''End Select
