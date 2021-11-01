Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class UnityUC
    Inherits Webvantage.BaseChildPageUserControl

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum UnityType

        ChildPage
        DesktopObject

    End Enum
    Public Enum UnityItem

        JobJacket
        Alerts
        Documents
        CreativeBrief
        Specifications
        Versions
        Estimates
        Schedule
        QvA
        Snapshot
        AddTime
        Stopwatch
        PurchaseOrders
        Events
        NewAlert
        NewAssignment
        Print
        SendAlert
        SendEmail
        PrintSendOptions
        SendAssignment
        NewJob
        Review
        ProjectBoard
        NewProof

        DeepLinkInternal
        DeepLinkExternal
        DeepLinkExternalClientPortalUser
        AlertAssignmentView
        TaskDetail
        TimeSheet
        EstimateQuote
        BillingApproval
        BillingApprovalBatch
        BillingApprovalJobComponent

    End Enum

#End Region

#Region " Variables "

    Private _UnityBase As Object = Nothing
    'Private _RadgridName As String = ""
    Private _IsBoundToListControl As Boolean = False
    Private _ListControlName As String = ""

    Private _IsBoundToGrid As Boolean = False
    Private _IsBoundToCardRepeater As Boolean = False
    Private _IsBoundToRadListView As Boolean = False

#End Region

#Region " Properties "

    Public Property ContextMenu As RadContextMenu = RadContextMenuUnity
    Public Property HideItems As UnityItem()
    Public Property JobNumber As Integer
        Get
            If ViewState("UC_JobNumber") Is Nothing Then ViewState("UC_JobNumber") = 0
            Return CType(ViewState("UC_JobNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("UC_JobNumber") = value
        End Set
    End Property
    Public Property JobComponentNumber As Integer
        Get
            If ViewState("UC_JobComponentNumber") Is Nothing Then ViewState("UC_JobComponentNumber") = 0
            Return CType(ViewState("UC_JobComponentNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("UC_JobComponentNumber") = value
        End Set
    End Property
    Private Property ClientCode As String
        Get
            If Session("UC_ClientCode") IsNot Nothing Then
                Return Session("UC_ClientCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Session("UC_ClientCode") = value
        End Set
    End Property
    Private Property DivisionCode As String
        Get
            If Session("UC_DivisionCode") IsNot Nothing Then
                Return Session("UC_DivisionCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Session("UC_DivisionCode") = value
        End Set
    End Property
    Private Property ProductCode As String
        Get
            If Session("UC_ProductCode") IsNot Nothing Then
                Return Session("UC_ProductCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Session("UC_ProductCode") = value
        End Set
    End Property


    Public Property DeepLinkType As UnityItem
        Get
            If ViewState("UC_DeepLinkType") Is Nothing Then ViewState("UC_DeepLinkType") = CType(UnityItem.JobJacket, Integer)
            Return CType(CType(ViewState("UC_DeepLinkType"), Integer), UnityItem)
        End Get
        Set(value As UnityItem)
            ViewState("UC_DeepLinkType") = CType(value, Integer)
        End Set
    End Property
    'Public Property ClientCode As String = ""
    'Public Property DivisionCode As String = ""
    'Public Property ProductCode As String = ""

    Public ReadOnly Property GridIndex As Integer
        Get
            If IsNumeric(Me.HiddenFieldGridClickedRowIndex.Value) = True Then
                Return CType(Me.HiddenFieldGridClickedRowIndex.Value, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public Property EstimateNumber As Integer = 0
    Public Property EstimateComponentNbr As Integer = 0
    Public Property EstimatingQuoteDelimitedString As String = ""
    Public Property AlertID As Integer = 0
    Public Property TaskSequenceNumber As Integer = -1
    Public Property BillingApprovalBatchID As Integer = 0
    Public Property BillingApprovalID As Integer = 0
    Public Property ConceptShareReviewID As Integer = 0

    Public WriteOnly Property Hide As Boolean
        Set(value As Boolean)
            If value = True Then
                Me.RadContextMenuUnity.Enabled = False
                Me.RadContextMenuUnity.Visible = False
            End If
        End Set
    End Property


#End Region

#Region " Page "

    Private Sub UnityUC_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            'If Me.HasJobAndComponent() = False Then Exit Sub
            Me.CheckSecurity()

        Catch ex As Exception
        End Try

    End Sub
    Private Sub UnityUC_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            'If Me.HasJobAndComponent() = False Then Exit Sub
            If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

                Me.LoadData()

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Controls "

    Public Event RadContextMenuUnityItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs)
    Private Sub RadContextMenuUnity_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles RadContextMenuUnity.ItemClick

        Try

            If sender Is Nothing OrElse e Is Nothing Then Exit Sub

            RaiseEvent RadContextMenuUnityItemClick(sender, e)

            Dim IsSilentPrintSendPage As Boolean = False
            Dim CurrentPrintPage As String = Me.GetPrintPage()

            If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then

                Dim OkayToOpen As Boolean = True
                Dim qs As New AdvantageFramework.Web.QueryString()
                Dim OpenNewTimeEntryWindow As Boolean = False

                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNumber

                Select Case e.Item.Value

                    Case "NewProof"

                        qs.Page = "Desktop_NewAssignment"
                        qs.Add("caller", "review")
                        qs.Add("f", "1")
                        qs.Add("jt", "1")
                        qs.Add("assn", "1")

                    Case UnityItem.JobJacket.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                        qs.Add("PageMode", "Edit")
                        qs.Add("NewComp", "0")

                    Case UnityItem.Alerts.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Alerts

                    Case UnityItem.Documents.ToString()

                        Session("FromWindow") = "ProjectView"
                        Session("DocFilterLevel") = "JC"
                        Session("DocFilterValue") = Me.JobNumber.ToString() & "," & Me.JobComponentNumber.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Documents

                        qs.Add("m", "D")

                    Case UnityItem.CreativeBrief.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief

                    Case UnityItem.Specifications.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobSpecifications

                    Case UnityItem.Versions.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                    Case UnityItem.Estimates.ToString()

                        Dim dr As SqlDataReader
                        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                        dr = oEstimating.GetEstJob(Me.JobNumber, Me.JobComponentNumber)
                        If dr.HasRows = True Then

                            dr.Read()

                            If dr("ESTIMATE_NUMBER") <> 0 Then

                                qs.Add("JT", "0")
                                qs.Add("newEst", "edit")
                                qs.EstimateNumber = dr("ESTIMATE_NUMBER")
                                qs.EstimateComponentNumber = dr("EST_COMPONENT_NBR")

                            Else

                                qs.Add("JT", "0")
                                qs.Add("newEst", "job")

                            End If

                        Else

                            qs.Add("JT", "0")
                            qs.Add("newEst", "job")

                        End If

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                    Case UnityItem.Schedule.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                    Case UnityItem.ProjectBoard.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.ProjectBoard

                    Case UnityItem.QvA.ToString()

                        'qs.Page = "QuoteVsActualSummaryPopup.aspx"
                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.FinancialStatus

                    Case UnityItem.Snapshot.ToString()

                        qs.Page = "TrafficSchedule_ProjectSummary.aspx"

                    Case UnityItem.AddTime.ToString()

                        Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                        Dim empnontask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
                        Dim di As GridDataItem = e.Item.DataItem

                        qs.Page = "Employee/Timesheet/Entry"
                        qs.EmployeeCode = Session("EmpCode")
                        qs.StartDate = Today.Date.ToShortDateString
                        qs.JobNumber = Me.JobNumber
                        qs.JobComponentNumber = Me.JobComponentNumber
                        qs.AlertID = Me.AlertID
                        qs.Add("new", "0")
                        qs.Add("Type", "New")

                        'qs.Page = "Timesheet_CommentsView.aspx"
                        'qs.Add("Type", "New")
                        'qs.Add("single", "1")

                        If Me.AlertID > 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertID)

                                If alert IsNot Nothing AndAlso alert.NonTaskID IsNot Nothing Then

                                    empnontask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, alert.NonTaskID)

                                End If
                                If empnontask IsNot Nothing Then

                                    'qs.Add("caller", "Calendar_NewActivity")
                                    qs.FunctionCode = empnontask.FunctionCode

                                    'Else

                                    '    qs.Add("caller", "AlertView")
                                    '    OpenNewTimeEntryWindow = True

                                End If

                            End Using

                            'Else

                            '    qs.Add("caller", "AlertView")

                        End If

                        OpenNewTimeEntryWindow = True

                    Case UnityItem.Stopwatch.ToString()

                        OkayToOpen = False

                        Dim s As String = ""

                        If AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), Me.JobNumber, Me.JobComponentNumber, -1, AlertID, s) = True Then

                            Me.OpenTimesheetStopwatchNotificationWindow()

                        Else

                            Me.ShowMessage(s)

                        End If

                    Case UnityItem.PurchaseOrders.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.PurchaseOrder

                    Case UnityItem.Events.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Events

                    Case UnityItem.NewAlert.ToString()

                        qs.Page = "Alert_New.aspx"
                        qs.Add("caller", "jobtemplate")
                        qs.Add("f", "1")
                        qs.Add("jt", "1")

                    Case UnityItem.NewAssignment.ToString()

                        qs.Page = "Alert_New.aspx"
                        qs.Add("caller", "jobtemplate")
                        qs.Add("f", "1")
                        qs.Add("jt", "1")
                        qs.Add("assn", "1")

                    Case UnityItem.NewJob.ToString()

                        qs.Page = "JobTemplate_New.aspx"
                        qs.JobNumber = Me.JobNumber

                    Case UnityItem.Print.ToString()

                        qs.Page = CurrentPrintPage '"JobTemplate_Print.aspx"
                        qs.Add("fromapp", "jobtemplate")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)
                        qs.Add("content", "1")

                        If Me.JobNumber > 0 Then qs.JobNumber = Me.JobNumber
                        If Me.JobComponentNumber > 0 Then qs.JobComponentNumber = Me.JobComponentNumber
                        If Me.EstimateNumber > 0 Then qs.EstimateNumber = Me.EstimateNumber
                        If Me.EstimateComponentNbr > 0 Then qs.EstimateComponentNumber = Me.EstimateComponentNbr
                        If Me.EstimatingQuoteDelimitedString <> "" Then qs.Add("sel_quotes", Me.EstimatingQuoteDelimitedString)

                        IsSilentPrintSendPage = True

                    Case UnityItem.SendAlert.ToString()

                        qs.Page = CurrentPrintPage '"JobTemplate_Print.aspx"
                        qs.Add("fromapp", "jobtemplate")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)
                        qs.Add("content", "1")

                        If Me.JobNumber > 0 Then qs.JobNumber = Me.JobNumber
                        If Me.JobComponentNumber > 0 Then qs.JobComponentNumber = Me.JobComponentNumber
                        If Me.EstimateNumber > 0 Then qs.EstimateNumber = Me.EstimateNumber
                        If Me.EstimateComponentNbr > 0 Then qs.EstimateComponentNumber = Me.EstimateComponentNbr
                        If Me.EstimatingQuoteDelimitedString <> "" Then qs.Add("sel_quotes", Me.EstimatingQuoteDelimitedString)

                        IsSilentPrintSendPage = True

                    Case UnityItem.SendAssignment.ToString()

                        qs.Page = CurrentPrintPage '"JobTemplate_Print.aspx"
                        qs.Add("fromapp", "jobtemplate")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)
                        qs.Add("content", "1")

                        If Me.JobNumber > 0 Then qs.JobNumber = Me.JobNumber
                        If Me.JobComponentNumber > 0 Then qs.JobComponentNumber = Me.JobComponentNumber
                        If Me.EstimateNumber > 0 Then qs.EstimateNumber = Me.EstimateNumber
                        If Me.EstimateComponentNbr > 0 Then qs.EstimateComponentNumber = Me.EstimateComponentNbr
                        If Me.EstimatingQuoteDelimitedString <> "" Then qs.Add("sel_quotes", Me.EstimatingQuoteDelimitedString)

                        IsSilentPrintSendPage = True

                    Case UnityItem.SendEmail.ToString()

                        qs.Page = CurrentPrintPage '"JobTemplate_Print.aspx"
                        qs.Add("fromapp", "jobtemplate")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)
                        qs.Add("content", "1")

                        If Me.JobNumber > 0 Then qs.JobNumber = Me.JobNumber
                        If Me.JobComponentNumber > 0 Then qs.JobComponentNumber = Me.JobComponentNumber
                        If Me.EstimateNumber > 0 Then qs.EstimateNumber = Me.EstimateNumber
                        If Me.EstimateComponentNbr > 0 Then qs.EstimateComponentNumber = Me.EstimateComponentNbr
                        If Me.EstimatingQuoteDelimitedString <> "" Then qs.Add("sel_quotes", Me.EstimatingQuoteDelimitedString)

                        IsSilentPrintSendPage = True

                    Case UnityItem.PrintSendOptions.ToString()

                        qs.Page = CurrentPrintPage '"JobTemplate_Print.aspx"
                        qs.Add("fromapp", "jobtemplate")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                        If Me.JobNumber > 0 Then qs.JobNumber = Me.JobNumber
                        If Me.JobComponentNumber > 0 Then qs.JobComponentNumber = Me.JobComponentNumber
                        If Me.EstimateNumber > 0 Then qs.EstimateNumber = Me.EstimateNumber
                        If Me.EstimateComponentNbr > 0 Then qs.EstimateComponentNumber = Me.EstimateComponentNbr
                        If Me.EstimatingQuoteDelimitedString <> "" Then qs.Add("sel_quotes", Me.EstimatingQuoteDelimitedString)

                    Case UnityItem.Review.ToString()

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.DigitalAssetReviews

                    Case UnityItem.DeepLinkExternal.ToString

                        OkayToOpen = False

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                        qs.Add("PageMode", "Edit")
                        qs.Add("NewComp", "0")

                        'Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
                        'Dim s As String = Deep.Build(AdvantageFramework.Web.DeepLink.LinkType.External, qs)

                        'If s IsNot Nothing Then

                        '    Me.CopyToClipboard(s)

                        'End If

                        Exit Sub

                    Case Else

                        OkayToOpen = False

                End Select

                Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
                Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))
                If _Session.HasLimitedOfficeCodes AndAlso Me.JobNumber > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, Me.JobNumber) = False Then
                            OkayToOpen = False
                        End If
                        If oValidation.ValidateJobCompIsViewable(Session("UserCode"), Me.JobNumber, Me.JobComponentNumber, "ts") = False Then
                            OkayToOpen = False
                        End If
                    End Using

                    If OkayToOpen = False Then

                        Me.ShowMessage("Access to this job/comp is denied")

                    End If

                End If

                If OkayToOpen = True Then

                    If IsSilentPrintSendPage = False Then

                        If TypeOf Me.Page Is Webvantage.DefaultParent Then

                            Dim ThisPage As Webvantage.DefaultParent = CType(Me.Page, Webvantage.DefaultParent)

                            If OpenNewTimeEntryWindow = False Then

                                ThisPage.OpenWindow(qs.ToString(True))

                            Else

                                Me.OpenWindow("Add Time", qs.ToString(True), 600, 800, False)
                                'ThisPage.OpenWindow("Add Time", String.Format("ProjectManagement_Agile_NewWorkItemTimeDialogFromOld?AlertID={0}", AlertID))

                            End If

                        Else


                            If OpenNewTimeEntryWindow = False Then

                                Me.OpenWindow(qs.ToString(True))

                            Else

                                Me.OpenWindow("Add Time", qs.ToString(True), 580, 680, False)
                                'Me.OpenWindow("Add Time", String.Format("ProjectManagement_Agile_NewWorkItemTimeDialogFromOld?AlertID={0}", AlertID),,,, False)

                            End If

                        End If

                    Else

                        If TypeOf Me.Page Is Webvantage.DefaultParent Then

                            Dim ThisPage As Webvantage.DefaultParent = CType(Me.Page, Webvantage.DefaultParent)
                            ThisPage.OpenPrintSendSilently(qs)

                        Else

                            Me.OpenPrintSendSilently(qs)

                        End If

                    End If

                End If

            Else

                Me.ShowMessage("Sorry, no associated Job Component")

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Methods "

    Private Function HasJobAndComponent() As Boolean

        Try

            If Me.JobNumber = 0 AndAlso Me.JobComponentNumber = 0 Then

                Me.RadContextMenuUnity.Enabled = False
                Me.RadContextMenuUnity.Visible = False
                Return False

            Else

                Me.RadContextMenuUnity.Enabled = True
                Me.RadContextMenuUnity.Visible = True
                Return True

            End If

        Catch ex As Exception
        End Try

    End Function
    Private Sub CheckSecurity()

        Try

            If Not Me.Page.IsPostBack AndAlso Not Me.Page.IsCallback Then

                Dim bp As New Webvantage.BasePageShared

                If bp._Session Is Nothing Then

                    If HttpContext.Current.Session("Security_Session") Is Nothing Then

                        If HttpContext.Current.Session("UserGUID") IsNot Nothing Then

                            bp._Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal,
                                                                              HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"),
                                                                              CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")),
                                                                              HttpContext.Current.Session("ConnString"))

                        Else

                            bp._Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage,
                                                                              HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"),
                                                                              CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")),
                                                                              HttpContext.Current.Session("ConnString"))

                        End If

                        HttpContext.Current.Session("Security_Session") = bp._Session

                    Else

                        bp._Session = HttpContext.Current.Session("Security_Session")

                    End If

                End If

                If bp.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket) = False OrElse
                bp.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket) = False Then

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.NewJob.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorNewJob").Visible = False

                End If
                If bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, False) = False Then

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Visible = False

                End If
                If bp.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False) = False Then

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Alerts.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.NewAlert.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.NewAssignment.ToString()).Visible = False

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.SendAlert.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.SendAssignment.ToString()).Visible = False

                End If
                If bp.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False) = False AndAlso
                     bp.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Chat, False) = False Then

                    Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorAlertActions").Visible = False

                End If

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Documents.ToString()).Visible =
                bp.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_JobComponent, False) = 1

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.CreativeBrief.ToString()).Visible =
                bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_CreativeBrief, False) = 1

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Specifications.ToString()).Visible =
                bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Specifications, False) = 1

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Versions.ToString()).Visible =
                bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, False) = 1

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Schedule.ToString()).Visible =
                bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, False) = 1

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.ProjectBoard.ToString()).Visible =
                bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, False) = 1

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Snapshot.ToString()).Visible =
                bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DesktopObjects_ProjectViewpointSnapshot, False) = 1

                If bp.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet, False) = False Or MiscFN.IsClientPortal = True Then

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.AddTime.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.Stopwatch.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorTimesheetActions").Visible = False

                End If

                Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Review.ToString()).Visible = cApplication.IsProofingToolActive(bp._Session)

                If MiscFN.IsClientPortal = True Then

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Documents.ToString()).Visible = bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Documents, False) = 1
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Estimates.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.QvA.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.PurchaseOrders.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Events.ToString()).Visible = False

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.NewAssignment.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.SendAssignment.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.NewProof.ToString()).Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorNewJob").Visible = False
                    Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorTimesheetActions").Visible = False

                Else

                    'Don't know where this is set in ADV for CP users?? 
                    If bp.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Desktop_Alerts) = False Then

                        Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.NewAlert.ToString()).Visible = False
                        Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.NewAssignment.ToString()).Visible = False
                        Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorAlertActions").Visible = False

                        Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.SendAlert.ToString()).Visible = False
                        Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.SendAssignment.ToString()).Visible = False

                    End If

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Documents.ToString()).Visible =
                    bp.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, False) = 1

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Estimates.ToString()).Visible =
                    bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating, False) = 1

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.QvA.ToString()).Visible =
                    bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_QuotevsActualsDQ, False) = 1

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.PurchaseOrders.ToString()).Visible =
                    bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders, False) = 1

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Events.ToString()).Visible =
                    bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectEvents, False) = 1

                    Try
                        If bp.UserCanPrintInModule(AdvantageFramework.Security.Methods.Modules.ProjectManagement_JobJacket) = False Then

                            Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.Print.ToString).Visible = False
                            Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.PrintSendOptions.ToString).Visible = False

                        End If

                    Catch ex As Exception
                    End Try

                    Try

                        If cApplication.IsProofingToolActive(bp.SecuritySession) = False OrElse MiscFN.IsClientPortal = True Then

                            Me.RadContextMenuUnity.Items.FindItemByValue("NewProof").Visible = False

                        Else

                            If String.IsNullOrWhiteSpace(Me.ClientCode) = True OrElse
                                String.IsNullOrWhiteSpace(Me.DivisionCode) = True OrElse
                                String.IsNullOrWhiteSpace(Me.ProductCode) = True Then

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

                    Catch ex As Exception
                    End Try

                End If

                Try

                    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.ProjectBoard.ToString()).Visible =
                    bp.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Boards, False) = 1

                    'If cApplication.EnableKanBan(bp._Session) = False Then

                    '    Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.ProjectBoard.ToString()).Visible = False

                    'End If

                Catch ex As Exception
                End Try

            End If

        Catch ex As Exception
        End Try


    End Sub
    Private Sub WriteScriptForListControlContextMenu()

        Try

            If Me._IsBoundToListControl = True Then

                Dim sb As New System.Text.StringBuilder

                sb.Append("<script type=""text/javascript"">")

                sb.Append("function UnityRowContextMenu" & _ListControlName & "(sender, eventArgs) {")

                'sb.Append("alert(sender);")
                'sb.Append("alert('3');")
                'sb.Append("alert('4');")
                'sb.Append("alert(index);")
                'sb.Append("alert(index);")
                'sb.Append("alert(sender);")

                sb.Append("     var index = 0;")

                sb.Append("     var menu = $find(""" & Me.RadContextMenuUnity.ClientID & """);")

                If Me._IsBoundToGrid = True Then

                    sb.Append("     var evt = eventArgs.get_domEvent();")
                    sb.Append("     if (evt.target.tagName == ""INPUT"" || evt.target.tagName == ""A"" || evt.target.tagName == ""BUTTON"") {")
                    sb.Append("          return;")
                    sb.Append("     };")

                    sb.Append("     index = eventArgs.get_itemIndexHierarchical();")

                    sb.Append("     document.getElementById(""" & HiddenFieldGridClickedRowIndex.ClientID & """).value = index;")

                    sb.Append("     menu.show(evt);")

                    sb.Append("     evt.cancelBubble = true;")
                    sb.Append("     evt.returnValue = false;")

                    sb.Append("     if (evt.stopPropagation) {")
                    sb.Append("          evt.stopPropagation();")
                    sb.Append("          evt.preventDefault();")
                    sb.Append("     };")


                End If
                If Me._IsBoundToCardRepeater = True OrElse Me._IsBoundToRadListView Then

                    sb.Append("     var targetElement  = eventArgs.srcElement || eventArgs.target;")
                    sb.Append("     if (targetElement.tagName == ""INPUT"" || targetElement.tagName == ""A"" || targetElement.tagName == ""BUTTON"") {")
                    sb.Append("          return;")
                    sb.Append("     };")

                    sb.Append("     index = sender;")

                    sb.Append("     document.getElementById(""" & HiddenFieldGridClickedRowIndex.ClientID & """).value = index;")

                    sb.Append("     menu.show(eventArgs);")

                    sb.Append("     eventArgs.cancelBubble = true;")
                    sb.Append("     eventArgs.returnValue = false;")

                    sb.Append("     if (eventArgs.stopPropagation) {")
                    sb.Append("          eventArgs.stopPropagation();")
                    sb.Append("          eventArgs.preventDefault();")
                    sb.Append("     };")

                End If

                sb.Append("};")

                sb.Append("</script>")

                Me.LiteralRadgridScript.Text = sb.ToString()

            End If

        Catch ex As Exception
        End Try

    End Sub
    Public Sub SetRadGrid(ByRef Grid As RadGrid)

        Try

            If Not Grid Is Nothing Then

                Me._IsBoundToListControl = True
                Me._IsBoundToGrid = True
                Me._ListControlName = Grid.ID
                Grid.ClientSettings.ClientEvents.OnRowContextMenu = "UnityRowContextMenu" & Me._ListControlName

            End If

        Catch ex As Exception
        End Try

    End Sub
    Public Sub SetRadListView(ByRef ListView As RadListView)

        Try

            If Not ListView Is Nothing Then

                Me._IsBoundToListControl = True
                Me._IsBoundToRadListView = True
                Me._ListControlName = ListView.ID

            End If

        Catch ex As Exception
        End Try

    End Sub
    Public Sub SetCardRepeater(ByRef Repeater As Repeater)

        Try

            If Not Repeater Is Nothing Then

                Me._IsBoundToListControl = True
                Me._IsBoundToCardRepeater = True
                Me._ListControlName = Repeater.ID

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Function GetPrintPage() As String

        Try
            Dim CurrentPage As String = HttpContext.Current.Request.Url.AbsoluteUri.ToString()

            If CurrentPage.ToLower().Contains("trafficschedule") Then

                Return "TrafficSchedule_Print.aspx"

            ElseIf CurrentPage.ToLower().Contains("gantt") Then

                Return "TrafficSchedule_Print.aspx"

            ElseIf CurrentPage.ToLower().Contains("jobtemplate") Then

                Return "JobTemplate_Print.aspx"

                'ElseIf CurrentPage.Contains("jobspecs") Then

                '    Return "JobSpecs_Print.aspx"

                'ElseIf CurrentPage.ToLower().Contains("jobver") Then

                '    Return "JobVersion_Print.aspx"

                'ElseIf CurrentPage.ToLower().Contains("campaign") Then

                '    Return "Campaign_Print.aspx"

                'ElseIf CurrentPage.ToLower().Contains("creativebrief") Then

                '    Return "CreativeBrief_Print.aspx"

                'ElseIf CurrentPage.ToLower().Contains("estimating") Then

                '    Return "Estimating_Print.aspx"

                'ElseIf CurrentPage.ToLower().Contains("purchaseorder") Then

                '    Return "PurchaseOrder_Print.aspx"

            Else

                Return "JobTemplate_Print.aspx"

            End If

        Catch ex As Exception
            Return "JobTemplate_Print.aspx"
        End Try

    End Function
    Public Sub LoadData()

        Try

            Dim MyJV As JobVersion = New JobVersion(HttpContext.Current.Session("ConnString"))
            Dim NewAlertHidden = False
            Dim NewAssignmentHidden = False
            Dim AddTimeHidden = False
            Dim StopwatchHidden = False

            Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(UnityItem.Versions.ToString()).Text = MyJV.GetAgencyDesc()

            If Not Me.HideItems Is Nothing AndAlso Me.HideItems.Count > 0 Then

                For Each item As UnityItem In Me.HideItems

                    Select Case item
                        Case UnityItem.Alerts,
                             UnityItem.Documents,
                             UnityItem.CreativeBrief,
                             UnityItem.Specifications,
                             UnityItem.Versions,
                             UnityItem.Estimates,
                             UnityItem.Schedule,
                             UnityItem.QvA,
                             UnityItem.PurchaseOrders,
                             UnityItem.Events,
                             UnityItem.Snapshot

                            Me.RadContextMenuUnity.Items.FindItemByValue(UnityItem.JobJacket.ToString()).Items.FindItemByValue(item.ToString()).Visible = False

                        Case UnityItem.JobJacket

                            'can't hide this one since "child" apps are now under it
                            Me.RadContextMenuUnity.Items.FindItemByValue(item.ToString()).Visible = False

                            If MiscFN.IsClientPortal = True Then

                                Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorPrint").Visible = False

                            End If

                        Case Else

                            Me.RadContextMenuUnity.Items.FindItemByValue(item.ToString()).Visible = False

                    End Select

                    Select Case item.ToString()

                        Case UnityItem.NewAlert.ToString()

                            NewAlertHidden = True

                        Case UnityItem.NewAssignment.ToString()

                            NewAssignmentHidden = True

                        Case UnityItem.AddTime.ToString()

                            AddTimeHidden = True

                        Case UnityItem.Stopwatch.ToString()

                            StopwatchHidden = True

                    End Select

                Next

                If NewAlertHidden = True And NewAssignmentHidden = True Then

                    Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorAlertActions").Visible = False

                End If
                If AddTimeHidden = True And StopwatchHidden = True Then

                    Me.RadContextMenuUnity.Items.FindItemByValue("RadMenuItemSeparatorTimesheetActions").Visible = False

                End If

            End If

            Me.WriteScriptForListControlContextMenu()

            If Me._ListControlName = "" Then

                Me.RadContextMenuUnity.Targets.Add(New Telerik.Web.UI.ContextMenuDocumentTarget())

            Else

                Me.RadContextMenuUnity.Targets.Clear()

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

End Class
