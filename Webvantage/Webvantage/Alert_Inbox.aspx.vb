Imports Webvantage.cGlobals
Imports Webvantage.SqlHelperdataItem
Imports System.Drawing
Imports Telerik.Web.UI
Imports System.IO
Imports AdvantageFramework.AlertSystem
Imports AdvantageFramework.Web.Presentation.Controls
Imports System.Collections.Generic
Imports System.Linq

Partial Public Class Alert_Inbox
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enums "

    'Public Enum AlertInbox_ShowFilter

    '    MyAlertsAndAssignments
    '    MyAlerts
    '    MyAssignments
    '    AllAssignments
    '    Unassigned

    'End Enum
    'Public Enum AlertInbox_FolderFilter

    '    Inbox
    '    Sent
    '    Dismissed
    '    AllReceived

    'End Enum
    'Public Enum ActionIconState

    '    Dismiss
    '    Undismiss
    '    Complete
    '    Uncomplete
    '    Hide

    'End Enum

#End Region

#Region " Properties "

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
    Private Property AlertInboxCurrentFilter() As Collection
        Get
            Return Session("CurrentAlertFilter")
        End Get
        Set(ByVal value As Collection)
            Session("CurrentAlertFilter") = value
        End Set
    End Property
    Private Property AlertsView() As String
        Get
            If Session("AlertsView") = "" Or Session("AlertsView") Is Nothing Then
                Session("AlertsView") = "Inbox"
                Return Session("AlertsView")
            Else
                Return Session("AlertsView")
            End If
        End Get
        Set(ByVal value As String)
            Session("AlertsView") = value
        End Set
    End Property
    Private Property CurrentPageNumber() As Integer
        Get

            Try

                Return CInt(Session("AlertsCurrentPageNumber"))

            Catch ex As Exception

                Session("AlertsCurrentPageNumber") = 0
                Return CInt(Session("AlertsCurrentPageNumber"))

            End Try

        End Get
        Set(ByVal value As Integer)
            Session("AlertsCurrentPageNumber") = value
        End Set
    End Property

    Private Property _CurrentFolder As AlertInbox_FolderFilter
    Private Property _CurrentShowFilter As AlertInbox_ShowFilter

    Private Property CurrentNumberOfPages As Integer = 0

    Private Property AppVarApplication As cAppVars.Application
        Get
            If ViewState("AppVarApplication") Is Nothing Then
                ViewState("AppVarApplication") = CType(cAppVars.Application.ALERT_INBOX, Integer).ToString()
            End If
            Return CType(CType(ViewState("AppVarApplication"), Integer), cAppVars.Application)
        End Get
        Set(value As cAppVars.Application)
            ViewState("AppVarApplication") = CType(value, Integer)
        End Set
    End Property

    Public Property CollapsedHeaders() As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
        Get
            If IsNothing(Session.Item("AlertInboxCollapsedGroupHeaders")) Then
                Session.Item("AlertInboxCollapsedGroupHeaders") = New AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
            End If
            Return Session.Item("AlertInboxCollapsedGroupHeaders")
        End Get
        Set(ByVal value As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection)
            Session.Item("AlertInboxCollapsedGroupHeaders") = value
        End Set
    End Property

#End Region

#Region " Variables "

    Private ConnectionString As String

#Region " Controls "

    Protected WithEvents RadComboBoxGroupBy As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadComboBoxAssignments As Telerik.Web.UI.RadComboBox
    Protected WithEvents TxtSearchCriteria As System.Web.UI.WebControls.TextBox
    Protected WithEvents ChkIncludeCompletedAssignments As System.Web.UI.WebControls.CheckBox

#End Region

    Private FromApp As MiscFN.Source_App

    Private FromJobNumber As Integer = 0
    Private FromJobComponentNbr As Integer = 0
    Private FromJobJacket As Boolean = False

    Private FromJobJacketDirect As Boolean = False
    Private FromProjectSchedule As Boolean = False

    Private DfltPageSize As Integer = 25

    Private EmpCodeFromFilter As String = ""

    Private LoadingFromBookmark As Boolean = False
    Private SearchText As String = ""
    Private IsBookmark As Boolean = False
    Private _LoadingDatasource As Boolean = False

#End Region

#Region " Page "

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts)

        Me.ConnectionString = Session("ConnString")

        Me.RadComboBoxGroupBy = Me.RadToolbarAlertInbox.FindItemByValue("RadToolBarButtonGroupFilter").FindControl("RadComboBoxGroupBy")
        Me.RadComboBoxAssignments = Me.RadToolbarAlertInbox.FindItemByValue("RadToolBarButtonAssignmentType").FindControl("RadComboBoxAssignments")
        Me.ChkIncludeCompletedAssignments = Me.RadToolbarAlertInbox.FindItemByValue("RadToolBarButtonCompletedAssignments").FindControl("ChkIncludeCompletedAssignments")
        Me.TxtSearchCriteria = CType(Me.RadToolbarAlertInbox.FindItemByValue("RadToolBarButtonSearchCriteria").FindControl("TxtSearchCriteria"), TextBox)

        ''This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(Me.RadGridAlertInbox)

        Try

            If Request.Cookies("RadGridAlertInboxSettings") IsNot Nothing AndAlso Request.Cookies("RadGridAlertInboxSettings").Value IsNot Nothing Then

                Dim GridSettings As New AdvantageFramework.Web.Presentation.Controls.GridSettingsPersister(Me.RadGridAlertInbox)

                GridSettings.LoadSettings(Request.Cookies("RadGridAlertInboxSettings").Value.ToString())

            End If

        Catch ex As Exception
        End Try

        If Me.IsPostBack Then
            Select Case Me.EventTarget
                Case "Refresh"
                    Me.RadGridAlertInbox.Rebind()
                    Me.RefreshAlertWindows(False, True, False, False)
            End Select
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not Request.QueryString("f") Is Nothing Then
                Me.FromApp = MiscFN.SourceApp_FromInt(Request.QueryString("f"))
            End If
        Catch ex As Exception
            Me.FromApp = MiscFN.Source_App.Alert
        End Try

        'see if coming from job jacket
        Try
            If Not Request.QueryString("j") Is Nothing Then

                Me.FromJobNumber = CType(Request.QueryString("j"), Integer)

            End If
        Catch ex As Exception
            Me.FromJobNumber = 0
        End Try
        Try
            If Not Request.QueryString("jc") Is Nothing Then

                Me.FromJobComponentNbr = CType(Request.QueryString("jc"), Integer)

            End If
        Catch ex As Exception
            Me.FromJobComponentNbr = 0
        End Try
        Try
            If Not Request.QueryString("bm") Is Nothing Then

                If Request.QueryString("bm") = "1" Then

                    IsBookmark = True

                End If

            End If
        Catch ex As Exception

        End Try

        'Clean up old querystring names by letting clean qs class override

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.FromJobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.FromJobComponentNbr = Me.CurrentQuerystring.JobComponentNumber

        'Me.RadToolbarAlertInbox.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        If (Me.FromJobNumber > 0 And Me.FromJobComponentNbr > 0) OrElse Me.FromApp = MiscFN.Source_App.JobJacket OrElse Me.CurrentQuerystring.IsJobDashboard Then

            Me.FromApp = MiscFN.Source_App.JobJacket
            Me.FromJobJacket = True
            AppVarApplication = cAppVars.Application.JOB_INBOX

        Else

            Me.FromJobJacket = False

        End If

        Me.PanelFolderAndFilter.Visible = Not Me.FromJobJacket

        If Me.CurrentQuerystring.IsJobDashboard = True Then

            Me.PanelFolderAndFilter.Visible = False

            Me.DivFilter.Visible = False
            Me.DivGrid.Attributes.Remove("class")
            Me.RadToolbarAlertInbox.FindItemByValue("ShowHideFilter").Visible = False

            Me.RadToolbarAlertInbox.FindItemByValue("NewAlert").Visible = False
            Me.RadToolbarAlertInbox.FindItemByValue("NewAlertAssignment").Visible = False
            Me.RadToolbarAlertInbox.FindItemByValue("RadToolBarButtonSeparatorNew").Visible = False
            Me.RadToolbarAlertInbox.FindItemByValue("Bookmark").Visible = False

        End If

        Try
            If Not Request.QueryString("dtlemp") Is Nothing Then
                Me.EmpCodeFromFilter = Request.QueryString("dtlemp").ToString()
            End If
        Catch ex As Exception
            Me.EmpCodeFromFilter = ""
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.SetRadDatePicker(Me.RadDatePickerStartDate)
            Me.SetRadDatePicker(Me.RadDatePickerEndDate)

            Dim a As New cAlerts()
            a.LoadAlertGroupingOptions(Me.RadComboBoxGroupBy, cAlerts.AlertGroupingModule.AlertInbox)

            Me.ClearFilter(False, False)

            Try

                Me.RadGridAlertInbox.CurrentPageIndex = Me.CurrentPageNumber

            Catch ex As Exception

                Me.RadGridAlertInbox.CurrentPageIndex = 0

            End Try

            RadTreeViewFolders.SingleExpandPath = False


            If Me.IsClientPortal = True Then

                Me.TxtEmployee.Text = ""
                Me.RadComboBoxGroupBy.Items.Clear()
                Me.RadComboBoxGroupBy.Items.Add(New RadComboBoxItem("None", ""))
                Me.RadComboBoxGroupBy.Items.Add(New RadComboBoxItem("Category", "CAT"))
                Me.RadComboBoxGroupBy.Items.Add(New RadComboBoxItem("Client", "C"))
                Me.RadComboBoxGroupBy.Items.Add(New RadComboBoxItem("Division", "CD"))
                Me.RadComboBoxGroupBy.Items.Add(New RadComboBoxItem("Product", "CDP"))
                Me.RadComboBoxGroupBy.Items.Add(New RadComboBoxItem("Job", "CDPJ"))
                Me.RadComboBoxGroupBy.Items.Add(New RadComboBoxItem("Job/Component", "CDPJC"))
                Me.RadComboBoxAssignments.Items.Clear()
                Me.RadComboBoxAssignments.Items.Add(New RadComboBoxItem("Alerts", "myalerts"))

                Me.RadToolbarAlertInbox.FindItemByValue("RadToolBarButtonAssignmentType").Visible = False
                Me.RadToolbarAlertInbox.FindItemByValue("RadToolBarButtonCompletedAssignments").Visible = False
                Me.RadToolbarAlertInbox.FindItemByValue("NewAlertAssignment").Visible = False
                Me.RadToolbarAlertInbox.FindItemByValue("Bookmark").Visible = False

            End If
            If Me.FromApp = MiscFN.Source_App.JobJacket Then

                Me.ChkIncludeCompletedAssignments.Checked = True

            Else

                Me.ChkIncludeCompletedAssignments.Checked = False
                Me.ChkIncludeCompletedAssignments.Visible = False

            End If

            Me.LoadLookups()

            'Me.BindRadComboBoxAlertNotifyHdrId()

        Else 'it's a postback

            Select Case Me.EventTarget
                Case "SavePaneState"
                    If Me.EventArgument = "Collapsed" Then
                        Session("AlertInboxPanelIsCollapsed") = True
                    Else
                        Session("AlertInboxPanelIsCollapsed") = False
                    End If
                Case "RebindGrid"

                    Me.RadGridAlertInbox.Rebind()

            End Select

        End If

        If Me.FromJobJacket = False Then

            Me.MyUnityContextMenu.SetRadGrid(Me.RadGridAlertInbox)

        End If

        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Alerts}

        If Me.FromJobJacket = True AndAlso Me.FromJobNumber > 0 AndAlso Me.FromJobComponentNbr > 0 Then

            If IsBookmark = False Then

                Me.PageTitle = "Alerts for Job:  " & Me.FromJobNumber.ToString().PadLeft(6, "0") & " - " &
                        Me.FromJobComponentNbr.ToString().PadLeft(2, "0") & " " & Me.GetJobComponentDescription()

            End If

            AppVarApplication = cAppVars.Application.JOB_INBOX

        Else

            If IsBookmark = False Then

                Me.PageTitle = "Assignments & Alerts Manager"

            End If

            Dim oAppVars As New cAppVars(AppVarApplication)
            oAppVars.getAllAppVars()
            Me.ShowFilter(oAppVars.getAppVar("DivFilterVisible", "boolean", "True") = "True")


        End If

        If Me.IsClientPortal = True Then

            If Session("DivFilterVisible_" & AppVarApplication.ToString()) IsNot Nothing Then

                Me.ShowFilter(Session("DivFilterVisible_" & AppVarApplication.ToString()) = "True")

            End If

        End If

    End Sub
    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If (RadDatePickerStartDate.SelectedDate.HasValue AndAlso CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString().IndexOf("1950") > -1) OrElse
                    Me.RadDatePickerStartDate.DateInput.Text.IndexOf("1950") > -1 Then
                Me.RadDatePickerStartDate.SelectedDate = Nothing
            End If
        Catch ex As Exception
        End Try
        'Try
        '    If CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString().IndexOf("1950") > -1 OrElse Me.RadDatePickerStartDate.DateInput.Text.IndexOf("1950") > -1 Then
        '        Me.RadDatePickerStartDate.DateInput.Text = ""
        '    End If
        'Catch ex As Exception
        'End Try

        Try
            Me.RadComboBoxAssignments.Items.FindItemByValue("allalertassignments").Visible = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments) 'AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments).Any(Function(SettingValue) SettingValue = True)
        Catch ex As Exception
        End Try

        Try
            Me.RadComboBoxAssignments.Items.FindItemByValue("unassigned").Visible = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments) 'AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments).Any(Function(SettingValue) SettingValue = True)
        Catch ex As Exception
        End Try

        Try
            If Me.FromJobJacket = True Or Me.FromProjectSchedule = True Then

                If Me.RadComboBoxAssignments.SelectedValue.ToString().ToLower().IndexOf("unassigned") > -1 Then
                    Me.ChkIncludeCompletedAssignments.Checked = False
                    Me.ChkIncludeCompletedAssignments.Enabled = False
                End If
            End If
        Catch ex As Exception
        End Try

        Try

            Me.DivDismissAll.Visible = Me.RadComboBoxAssignments.SelectedValue.ToString().Trim().ToLower() <> "allalertassignments"

        Catch ex As Exception
        End Try
        Try

            If Me.RadTreeViewFolders.SelectedValue IsNot Nothing AndAlso Me.RadTreeViewFolders.SelectedValue = "Drafts" Then

                Me.DivDismissAll.Visible = False

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If IsNothing(Session.Item("AlertInboxCollapsedGroupHeaders")) = False Then
            Dim groupHeaders As List(Of GridItem) = Me.RadGridAlertInbox.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

            Dim expanded As List(Of GridItem) = (From g In groupHeaders
                                                 Where g.Expanded
                                                 Select g).ToList()


            For Each expandedItem As GridItem In expanded
                If Me.CollapsedHeaders.GroupCaptions.Contains(expandedItem.Cells(1).Text) Then
                    expandedItem.Expanded = False
                End If
            Next

        End If

    End Sub

#End Region

#Region " Controls "

#Region " Radgrid Inbox "

    Private Sub RadGridAlertInbox_PreRender(sender As Object, e As System.EventArgs) Handles RadGridAlertInbox.PreRender

        Try

            Dim GridSettings As New AdvantageFramework.Web.Presentation.Controls.GridSettingsPersister(Me.RadGridAlertInbox)
            Response.Cookies("RadGridAlertInboxSettings").Value = GridSettings.SaveSettings()
            Response.Cookies("RadGridAlertInboxSettings").Expires = DateTime.Now.AddDays(30)

        Catch ex As Exception

        End Try
        Try

            Me.CurrentNumberOfPages = Me.RadGridAlertInbox.PageCount
            If Me.CurrentPageNumber <= Me.CurrentNumberOfPages Then

                Me.RadGridAlertInbox.CurrentPageIndex = Me.CurrentPageNumber

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridAlertInbox_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridAlertInbox.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridAlertInbox.ID, e.NewPageSize)

        End If

    End Sub
    Private Sub RadGridAlertInbox_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridAlertInbox.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridAlertInbox.Rebind()

    End Sub
    Private Sub RadGridAlertInbox_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAlertInbox.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.Header

                Me.SetCurrentFolderAndShowFilter()

            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                Dim CurrentRow As GridDataItem = CType(e.Item, GridDataItem)

                Dim ra As String = ""
                Try
                    If Me.FromJobJacket = False And Me.RadTreeViewFolders.SelectedValue.ToString() <> "Sent" Then

                        If Not IsDBNull(e.Item.DataItem("READ_ALERT")) = True Then

                            ra = e.Item.DataItem("READ_ALERT")

                        Else

                            ra = ""

                        End If

                    End If
                Catch ex As Exception
                End Try

                If Me.RadTreeViewFolders.SelectedValue.ToString().ToLower() = "sent" OrElse
                    Me.RadComboBoxAssignments.SelectedValue.ToString().ToLower() = "unassigned" Then

                    ra = "1"

                End If

                Try

                    If IsDBNull(e.Item.DataItem("TIME_DUE")) = False Then

                        CurrentRow("GridBoundColumnTimeDue").Text = AdvantageFramework.AlertSystem.MilitaryTimeStringToStandardTimeString(e.Item.DataItem("TIME_DUE"))

                    End If

                Catch ex As Exception
                End Try

                Dim IsAssignment As Boolean = e.Item.DataItem("IS_ASSIGNMENT")
                Dim IsWorkItem As Boolean = e.Item.DataItem("IS_WORK_ITEM")
                Dim IsTask As Boolean = False
                Dim IsTaskTempComplete As Boolean = False
                Dim IsMyAssignment As Boolean = False
                Dim IsCurrentNotify As Boolean = False
                Dim AssignedEmpCode As String = ""
                Dim AssignedEmpFML As String = ""
                Dim RowIsUnassigned As Boolean = AssignedEmpFML.ToLower().IndexOf("unassigned") > -1
                Dim IsCC As Boolean = CType(e.Item.DataItem("IS_CC"), Short) = 1
                Dim OpenLinkAsAssignment As Boolean = False

                If IsDBNull(e.Item.DataItem("CURRENT_NOTIFY")) = False Then

                    IsCurrentNotify = e.Item.DataItem("CURRENT_NOTIFY") = 1

                End If

                Try

                    If Not IsDBNull(e.Item.DataItem("CURRENT_NOTIFY_EMP_CODE")) = True Then

                        AssignedEmpCode = e.Item.DataItem("CURRENT_NOTIFY_EMP_CODE").ToString()

                    End If

                Catch ex As Exception

                    AssignedEmpCode = ""

                End Try

                Try
                    If IsAssignment = True AndAlso AssignedEmpCode = Session("EmpCode") Then

                        IsMyAssignment = True

                    End If
                Catch ex As Exception

                    IsMyAssignment = False

                End Try

                Try

                    If IsDBNull(e.Item.DataItem("CURRENT_NOTIFY_EMP_FML")) = False Then

                        AssignedEmpFML = e.Item.DataItem("CURRENT_NOTIFY_EMP_FML").ToString()

                    End If

                Catch ex As Exception

                    AssignedEmpFML = ""

                End Try

                Try

                    If IsDBNull(e.Item.DataItem("CATEGORY")) = False Then

                        If e.Item.DataItem("CATEGORY") = "Task" Then

                            IsTask = True

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If IsTask = True AndAlso IsDBNull(e.Item.DataItem("TEMP_COMP_DATE")) = False Then

                        IsTaskTempComplete = True

                    End If

                Catch ex As Exception

                End Try

                Dim ImgBtnDismiss As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("DismissImageButton")
                Dim DismissDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDismissComplete")
                Dim IsAssignmentHiddenField As HiddenField = e.Item.FindControl("HiddenFieldIsAssignment")
                Dim IsTaskHiddenField As HiddenField = e.Item.FindControl("HiddenFieldIsTask")

                Try

                    With ImgBtnDismiss

                        If Me.FromJobJacket Or Me.FromJobJacketDirect = True Then

                            If IsAssignment = True Then

                                If IsMyAssignment = True Then

                                    If AssignedEmpFML.Trim().ToLower = "completed" Then

                                        SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                    Else

                                        SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                    End If

                                    OpenLinkAsAssignment = True

                                Else

                                    SetIconState(ImgBtnDismiss, ActionIconState.Hide, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                End If

                            Else

                                SetIconState(ImgBtnDismiss, ActionIconState.Hide, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                            End If

                        Else 'Normal Alert Inbox

                            If Me._CurrentShowFilter = AlertInbox_ShowFilter.Unassigned Then

                                SetIconState(ImgBtnDismiss, ActionIconState.Hide, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                            Else

                                Select Case Me._CurrentFolder

                                    Case AlertInbox_FolderFilter.Inbox

                                        Select Case Me._CurrentShowFilter

                                            Case AlertInbox_ShowFilter.MyAlerts

                                                SetIconState(ImgBtnDismiss, ActionIconState.Dismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                            Case AlertInbox_ShowFilter.MyAssignments

                                                If IsTask = True Then

                                                    If IsTaskTempComplete = True Then

                                                        SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                        OpenLinkAsAssignment = True

                                                    Else

                                                        SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                        OpenLinkAsAssignment = True

                                                    End If

                                                Else

                                                    SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                    OpenLinkAsAssignment = True

                                                End If

                                            Case AlertInbox_ShowFilter.MyAlertsAndAssignments

                                                If (IsAssignment = False And IsTask = False And IsWorkItem = False) OrElse (IsCC = True) Then

                                                    SetIconState(ImgBtnDismiss, ActionIconState.Dismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                                Else

                                                    If IsTask = True Then

                                                        If IsTaskTempComplete = True Then

                                                            SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                            OpenLinkAsAssignment = True

                                                        Else

                                                            SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                            OpenLinkAsAssignment = True

                                                        End If

                                                    Else

                                                        If AssignedEmpCode = Session("EmpCode") And (IsCurrentNotify = True) Then

                                                            SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                            OpenLinkAsAssignment = True

                                                        ElseIf IsWorkItem = True Then

                                                            SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                            OpenLinkAsAssignment = True

                                                        Else

                                                            SetIconState(ImgBtnDismiss, ActionIconState.Dismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask) 'my CC

                                                        End If

                                                    End If


                                                End If

                                            Case AlertInbox_ShowFilter.AllAssignments

                                                If AssignedEmpCode = Session("EmpCode") Then 'And IsCurrentNotify = True Then

                                                    SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                    OpenLinkAsAssignment = True

                                                Else

                                                    SetIconState(ImgBtnDismiss, ActionIconState.Hide, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                                End If

                                        End Select

                                    Case AlertInbox_FolderFilter.Dismissed

                                        Select Case Me._CurrentShowFilter

                                            Case AlertInbox_ShowFilter.MyAlerts

                                                SetIconState(ImgBtnDismiss, ActionIconState.Undismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                            Case AlertInbox_ShowFilter.MyAssignments

                                                SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                OpenLinkAsAssignment = True

                                            Case AlertInbox_ShowFilter.MyAlertsAndAssignments

                                                If IsAssignment = False Then

                                                    SetIconState(ImgBtnDismiss, ActionIconState.Undismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                                Else

                                                    If AssignedEmpCode = Session("EmpCode") And IsCurrentNotify = True Then

                                                        If IsCC = False Then

                                                            SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                            OpenLinkAsAssignment = True

                                                        Else

                                                            SetIconState(ImgBtnDismiss, ActionIconState.Undismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                                        End If

                                                    ElseIf IsWorkItem = True Then

                                                        SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                        OpenLinkAsAssignment = True

                                                    Else

                                                        SetIconState(ImgBtnDismiss, ActionIconState.Undismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                                    End If

                                                End If

                                            Case AlertInbox_ShowFilter.AllAssignments

                                                If AssignedEmpCode = Session("EmpCode") And (IsCurrentNotify = True Or AssignedEmpFML.ToLower() = "completed") Then

                                                    SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                    OpenLinkAsAssignment = True

                                                Else

                                                    SetIconState(ImgBtnDismiss, ActionIconState.Hide, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                                End If

                                        End Select

                                    Case AlertInbox_FolderFilter.AllReceived ',AlertInbox_FolderFilter.Sent

                                        If IsAssignment = True Then

                                            If AssignedEmpCode = Session("EmpCode") And AssignedEmpFML.ToLower() = "completed" Then

                                                SetIconState(ImgBtnDismiss, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                OpenLinkAsAssignment = True

                                            ElseIf AssignedEmpCode = Session("EmpCode") And AssignedEmpFML.ToLower() <> "completed" Then

                                                SetIconState(ImgBtnDismiss, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)
                                                OpenLinkAsAssignment = True

                                            Else

                                                SetIconState(ImgBtnDismiss, ActionIconState.Hide, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                            End If

                                        Else

                                            If IsDBNull(e.Item.DataItem("IS_DISMISSED")) = False AndAlso CType(e.Item.DataItem("IS_DISMISSED"), Integer) = 1 Then

                                                SetIconState(ImgBtnDismiss, ActionIconState.Undismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                            Else

                                                SetIconState(ImgBtnDismiss, ActionIconState.Dismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                            End If

                                        End If

                                    Case AlertInbox_FolderFilter.Drafts

                                        SetIconState(ImgBtnDismiss, ActionIconState.DeleteDraft, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, IsTask)

                                End Select

                            End If

                        End If

                    End With

                Catch ex As Exception

                End Try

                Dim IsDraft As Boolean = False
                If Me.RadTreeViewFolders.SelectedValue IsNot Nothing AndAlso Me.RadTreeViewFolders.SelectedValue.ToLower() = "drafts" Then

                    IsDraft = True

                End If

                Dim QsViewDetails As New AdvantageFramework.Web.QueryString
                Dim IsCSReview As Boolean = False

                QsViewDetails.AlertID = CType(e.Item.DataItem("ALERT_ID"), Integer)
                QsViewDetails.Add("openasassign", OpenLinkAsAssignment.ToString())

                Try
                    IsCSReview = e.Item.DataItem("IS_CS_REVIEW")
                Catch ex As Exception
                    IsCSReview = False
                End Try

                If IsCSReview = False Then

                    If IsDraft Then

                        If (IsDBNull(e.Item.DataItem("JOB_NUMBER")) = False AndAlso e.Item.DataItem("JOB_NUMBER") > 0) AndAlso
                            (IsDBNull(e.Item.DataItem("JOB_COMPONENT_NBR")) = False AndAlso e.Item.DataItem("JOB_COMPONENT_NBR") > 0) Then

                            QsViewDetails.Page = "Desktop_AlertView"
                            QsViewDetails.Add("AlertID", e.Item.DataItem("ALERT_ID").ToString)
                            If IsDBNull(e.Item.DataItem("SPRINT_ID")) = False Then QsViewDetails.Add("SprintID", e.Item.DataItem("SPRINT_ID").ToString)
                            If Me.FromJobJacket = True Then QsViewDetails.Add("OpenedFrom", "1")

                        Else

                            QsViewDetails.Page = "Alert_New.aspx"
                            QsViewDetails.Add("draft_id", e.Item.DataItem("ALERT_ID"))

                        End If

                    Else

                        If e.Item.DataItem("CATEGORY") = "PO Approval Request" Then

                            QsViewDetails.Page = "Alert_View.aspx"
                            QsViewDetails.Add("AlertID", e.Item.DataItem("ALERT_ID").ToString)
                            QsViewDetails.Add("openasassign", "false")

                        Else

                            QsViewDetails.Page = "Desktop_AlertView"
                            QsViewDetails.Add("AlertID", e.Item.DataItem("ALERT_ID").ToString)
                            If IsDBNull(e.Item.DataItem("SPRINT_ID")) = False Then QsViewDetails.Add("SprintID", e.Item.DataItem("SPRINT_ID").ToString)
                            If Me.FromJobJacket = True Then QsViewDetails.Add("OpenedFrom", "1")

                        End If


                        'If Me._CurrentShowFilter = AlertInbox_ShowFilter.MyAlerts OrElse ImgBtnDismiss.ImageUrl.Contains("garbage") = True Then

                        '    QsViewDetails.Page = "Alert_View.aspx"
                        '    QsViewDetails.Add("Alert", e.Item.DataItem("ALERT_ID"))

                        'Else

                        '    If (Me.FromJobJacket Or Me.FromJobJacketDirect = True) And IsAssignment = False Then
                        '        QsViewDetails.Page = "Alert_View.aspx"
                        '        QsViewDetails.Add("Alert", e.Item.DataItem("ALERT_ID"))
                        '    Else

                        '    End If

                        'End If

                    End If

                Else

                    QsViewDetails.Page = "Alert_DigitalAssetReview.aspx"
                    QsViewDetails.AlertID = e.Item.DataItem("ALERT_ID")
                    QsViewDetails.JobNumber = e.Item.DataItem("JOB_NUMBER")
                    QsViewDetails.JobComponentNumber = e.Item.DataItem("JOB_COMPONENT_NBR")
                    QsViewDetails.ConceptShareProjectID = e.Item.DataItem("CS_PROJECT_ID")
                    QsViewDetails.ConceptShareReviewID = e.Item.DataItem("CS_REVIEW_ID")

                End If

                Dim ImgBtnViewAlert As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ViewImageButton")
                Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.FindControl("ViewLinkButton")

                ImgBtnViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString().Trim().Replace("'", "\'"), QsViewDetails.ToString(True)))

                If Me.FromJobJacket = False Then

                    If ra = "&nbsp;" Or ra = "" Or ra = "0" Then

                        ImgBtnViewAlert.ImageUrl = "Images/Icons/White/256/mail.png"
                        e.Item.Font.Bold = True

                    Else

                        ImgBtnViewAlert.ImageUrl = "Images/Icons/White/256/mail_open.png"

                    End If

                Else

                    ImgBtnViewAlert.ImageUrl = "Images/Icons/White/256/mail.png"

                End If

                ViewLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString().Trim().Replace("'", "\'"), QsViewDetails.ToString(True)))
                Try

                    If IsDBNull(e.Item.DataItem("Subject")) = False OrElse e.Item.DataItem("Subject").ToString().Trim().Length = 0 Then

                        ViewLinkButton.Text = Me.Sanitize(e.Item.DataItem("Subject"))

                    Else

                        ViewLinkButton.Text = "[No subject]"

                    End If

                Catch ex As Exception
                    ViewLinkButton.Text = "[No subject]"
                End Try

                Dim tt As String = ""

                If IsDraft = True Then

                    tt = "Edit Draft"
                    ImgBtnViewAlert.ImageUrl = "Images/Icons/White/256/edit.png"

                Else

                    tt = ViewLinkButton.Text

                End If

                ImgBtnViewAlert.ToolTip = tt
                ViewLinkButton.ToolTip = tt

                QsViewDetails = Nothing

                Dim rcbp As Telerik.Web.UI.RadComboBox = e.Item.FindControl("RadComboBoxPriority")
                Dim a As New cAlerts()
                a.LoadPrioritiesComboBox(rcbp, True, True, True)
                MiscFN.RadComboBoxSetIndex(rcbp, e.Item.DataItem("PRIORITY"), False)
                Dim PriorityText As String = ""

                Dim ViewDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivView")
                Select Case CType(e.Item.DataItem("PRIORITY"), Integer)
                    Case 1
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ViewDiv, "alert-priority-highest")
                        PriorityText = "Highest Priority"
                    Case 2
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ViewDiv, "alert-priority-high")
                        PriorityText = "High Priority"
                    Case 4
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ViewDiv, "alert-priority-low")
                        PriorityText = "Low Priority"
                    Case 5
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ViewDiv, "alert-priority-lowest")
                        PriorityText = "Lowest Priority"
                    Case Else
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ViewDiv, "alert-priority-normal")
                        PriorityText = "Normal Priority"
                End Select

                PriorityText &= "/Click to view details"

                ViewDiv.Attributes.Add("title", PriorityText)
                ImgBtnViewAlert.ToolTip = PriorityText

                Dim AttachmentImage As System.Web.UI.WebControls.Image = e.Item.FindControl("AttachmentsImage")
                Dim DivAttachments As HtmlControls.HtmlControl = e.Item.FindControl("DivAttachments")

                Select Case e.Item.DataItem("ATTACHMENTCOUNT")
                    Case Is > 0

                        Dim StrSuffix As String = ""

                        If e.Item.DataItem("ATTACHMENTCOUNT") = 1 Then

                            StrSuffix = "attachment"

                        ElseIf e.Item.DataItem("ATTACHMENTCOUNT") > 1 Then

                            StrSuffix = "attachments"

                        End If

                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivAttachments, "standard-green")
                        AttachmentImage.ToolTip = e.Item.DataItem("ATTACHMENTCOUNT").ToString() & " " & StrSuffix
                        AttachmentImage.AlternateText = e.Item.DataItem("ATTACHMENTCOUNT").ToString() & " " & StrSuffix

                    Case Else

                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivAttachments, "standard-red")
                        AttachmentImage.ToolTip = "No attachments"
                        AttachmentImage.AlternateText = "No attachments"

                End Select

                Dim LblSubjectText As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LblSubject"), Label)
                LblSubjectText.Visible = False

                Try
                    If Me.FromJobJacket = True And Me.RadComboBoxAssignments.SelectedValue = "myalerts" And Me.IsClientPortal = False Then
                        If Not IsDBNull(e.Item.DataItem("CURRENT_NOTIFY_EMP_CODE")) Then
                            If e.Item.DataItem("CURRENT_NOTIFY_EMP_CODE").ToString().Trim() <> Session("EmpCode") Then
                                With ImgBtnViewAlert
                                    .ImageUrl = "images/spacer.gif"
                                    .Enabled = False
                                    .ToolTip = ""
                                    .AlternateText = ""
                                End With
                                With ImgBtnDismiss
                                    .ImageUrl = "images/spacer.gif"
                                    .ToolTip = ""
                                    .AlternateText = ""
                                    .Enabled = False
                                End With
                                With AttachmentImage
                                    .ImageUrl = "images/spacer.gif"
                                    .Enabled = False
                                    .ToolTip = ""
                                    .AlternateText = ""
                                End With
                                With ViewLinkButton
                                    .Visible = False
                                    .ToolTip = ""
                                End With
                                LblSubjectText.Visible = True
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDate(e.Item.DataItem("GENERATED")) = True Then

                        CType(e.Item.FindControl("LabelGenerated"), Label).Text = LoGlo.FormatDateTime(e.Item.DataItem("GENERATED"))

                    End If
                Catch ex As Exception
                End Try

                Try
                    Dim rdpsd As RadDatePicker = CType(e.Item.FindControl("RadDatePickerStartDate"), RadDatePicker)

                    If rdpsd IsNot Nothing Then

                        Me.SetRadDatePicker(rdpsd)

                        If IsDBNull(e.Item.DataItem("START_DATE")) = False And IsDate(e.Item.DataItem("START_DATE")) = True Then

                            rdpsd.SelectedDate = CDate(e.Item.DataItem("START_DATE"))

                        End If

                    End If
                Catch ex As Exception
                End Try
                Try
                    Dim rdpdd As RadDatePicker = CType(e.Item.FindControl("RadDatePickerDueDate"), RadDatePicker)

                    If rdpdd IsNot Nothing Then

                        Me.SetRadDatePicker(rdpdd)

                        If IsDBNull(e.Item.DataItem("DUE_DATE")) = False And IsDate(e.Item.DataItem("DUE_DATE")) = True Then

                            rdpdd.SelectedDate = CDate(e.Item.DataItem("DUE_DATE"))

                        End If

                    End If
                Catch ex As Exception
                End Try

                Try

                    Dim AssignedToLinkButton As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LinkButtonAssignedTo"), LinkButton)

                    If AssignedToLinkButton IsNot Nothing Then

                        If IsDBNull(e.Item.DataItem("CURRENT_NOTIFY_EMP_FML")) = False Then

                            Dim AssignedToEmpName As String = ""

                            Try

                                AssignedToEmpName = e.Item.DataItem("CURRENT_NOTIFY_EMP_FML").ToString()

                            Catch ex As Exception
                                AssignedToEmpName = ""
                            End Try

                            If AssignedToEmpName.Trim() <> "" Then

                                Select Case AssignedToEmpName.Trim().ToLower()
                                    Case "unassigned"

                                        AssignedToLinkButton.ToolTip = "Assignment is unassigned."

                                    Case "completed"

                                        AssignedToLinkButton.ToolTip = "Assignment is completed."

                                    Case Else

                                        AssignedToLinkButton.ToolTip = "Currently assigned to:  " & AssignedToEmpName & "."

                                End Select

                                If IsClientPortal = False Then

                                    AssignedToLinkButton.ToolTip &= "  Click to change."

                                    Try

                                        'If AssignedToEmpName.Contains(" ") = True Then

                                        '    Dim ar() As String
                                        '    ar = AssignedToEmpName.Split(" ")

                                        '    AssignedToLinkButton.Text = ar(0)

                                        'Else

                                        AssignedToLinkButton.Text = AssignedToEmpName

                                        'End If

                                    Catch ex As Exception

                                        AssignedToLinkButton.Text = AssignedToEmpName

                                    End Try

                                    Dim qs As New AdvantageFramework.Web.QueryString()

                                    Dim AlertStateName As String = ""
                                    If IsDBNull(e.Item.DataItem("ALERT_STATE_NAME")) = False Then
                                        AlertStateName = e.Item.DataItem("ALERT_STATE_NAME")
                                    End If

                                    If (AssignedToEmpName = "Unassigned" Or AssignedToEmpName = "Completed") And AlertStateName = "" Then
                                        With qs

                                            .Page = "Desktop_AlertView"
                                            .Add("AlertID", e.Item.DataItem("ALERT_ID").ToString)
                                            If IsDBNull(e.Item.DataItem("SPRINT_ID")) = False Then .Add("SprintID", e.Item.DataItem("SPRINT_ID").ToString)
                                            If Me.FromJobJacket = True Then .Add("OpenedFrom", "1")

                                        End With
                                        AssignedToLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString().Trim(), qs.ToString(True)))
                                    Else
                                        If IsTask = True Then
                                            With qs

                                                .Page = "TrafficSchedule_TaskEmployees.aspx"
                                                .AlertID = e.Item.DataItem("ALERT_ID")
                                                .JobNumber = e.Item.DataItem("JOB_NUMBER")
                                                .JobComponentNumber = e.Item.DataItem("JOB_COMPONENT_NBR")
                                                .TaskSequenceNumber = e.Item.DataItem("TASK_SEQ_NBR")
                                                .Add("From", "pb")
                                                .Add("AlertID", e.Item.DataItem("ALERT_ID").ToString)

                                            End With
                                            AssignedToLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("Employees", qs.ToString(True), 500, 500, False, "refreshGrid"))
                                        Else
                                            With qs

                                                .Page = "Desktop_Reassign"
                                                .AlertID = e.Item.DataItem("ALERT_ID")
                                                .Add("AlertID", e.Item.DataItem("ALERT_ID").ToString)

                                            End With
                                            AssignedToLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("Assignment", qs.ToString(True), 500, 500, False, "refreshGrid"))
                                        End If
                                        'AssignedToLinkButton.Enabled = False
                                    End If

                                    qs = Nothing

                                Else

                                    AssignedToLinkButton.Text = AssignedToEmpName
                                    AssignedToLinkButton.Enabled = False

                                End If

                            Else

                                AssignedToLinkButton.Visible = False

                            End If

                        Else

                            AssignedToLinkButton.Visible = False

                        End If

                        Try

                            If e.Item.DataItem("IS_WORK_ITEM") = True AndAlso e.Item.DataItem("IS_ASSIGNMENT") = False Then

                                AssignedToLinkButton.Enabled = False

                            End If

                        Catch ex As Exception
                        End Try



                        If AssignedToLinkButton.Enabled = False Then

                            AssignedToLinkButton.Attributes.Remove("onclick")
                            AssignedToLinkButton.ToolTip = AssignedToLinkButton.ToolTip.Replace("Click to change.", "")

                        End If

                    End If

                Catch ex As Exception
                End Try

                Try

                    Dim UserNameLabel As Label = e.Item.FindControl("LabelUserName")

                    If UserNameLabel IsNot Nothing Then

                        If IsDBNull(e.Item.DataItem("USER_NAME")) = False Then

                            Dim UserName As String = e.Item.DataItem("USER_NAME").ToString()

                            UserNameLabel.ToolTip = "Last modified by:  " & UserName

                            Try

                                'If UserName.Contains(" ") = True Then

                                '    Dim arUserName As String()
                                '    arUserName = UserName.Split(" ")

                                '    UserNameLabel.Text = arUserName(0)

                                'Else

                                UserNameLabel.Text = UserName

                                'End If

                            Catch ex As Exception

                                UserNameLabel.Text = UserName

                            End Try

                        End If

                    End If

                Catch ex As Exception

                End Try

            Case Telerik.Web.UI.GridItemType.GroupHeader

        End Select
    End Sub
    Private Sub RadGridAlertInbox_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAlertInbox.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If
        If index = -1 Then 'command item

            Select Case e.CommandName
                Case "ExpandCollapse"

                    If (Me.RadComboBoxGroupBy.SelectedIndex <> -1) Then

                        Dim groupHeaders As List(Of GridItem) = Me.RadGridAlertInbox.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

                        Dim captions As List(Of String) = (From g In groupHeaders
                                                           Where g.Expanded = False
                                                           Select g.Cells(1).Text).ToList()

                        If (e.Item.Expanded) Then

                            captions.Add(e.Item.Cells(1).Text)

                        Else
                            If (captions.Contains(e.Item.Cells(1).Text)) Then

                                captions.Remove(e.Item.Cells(1).Text)

                            End If
                        End If

                        Me.CollapsedHeaders.GroupName = RadComboBoxGroupBy.SelectedItem.Text
                        Me.CollapsedHeaders.GroupCaptions = captions

                    End If

                Case Else

                    MiscFN.SavePageSize(Me.RadGridAlertInbox.ID, Me.RadGridAlertInbox.PageSize)

            End Select

            Exit Sub

        End If

        Dim ThisAlertId As Integer = 0
        Dim ThisSprintId As Integer = 0
        Dim IsTask As Boolean = False

        Select Case e.CommandName
            Case "Filter"

                For Each column As GridColumn In e.Item.OwnerTableView.Columns

                    column.CurrentFilterValue = String.Empty
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter

                Next

            Case ActionIconState.Dismiss.ToString()

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAlertInbox.Items(index), Telerik.Web.UI.GridDataItem)
                If CurrentGridRow IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ThisAlertId = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)

                        If ThisAlertId > 0 Then

                            Dim PromptForFullCompleteTask As Boolean = False
                            Dim PromptForTempCompleteTask As Boolean = False
                            Dim s As String = String.Empty

                            If AdvantageFramework.AlertSystem.DismissAlert(DbContext, ThisAlertId, Session("EmpCode"), Session("UserCode"), Session("UserID"), False,
                                                                           PromptForFullCompleteTask, PromptForTempCompleteTask, s) = True Then

                                If PromptForFullCompleteTask = True Then

                                    Me.ShowMessage("Task will be completed if you were the last employee to temp complete")
                                    'Dim QueryString As New AdvantageFramework.Web.QueryString
                                    'With QueryString

                                    '    .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                    '    .AlertId = ThisAlertId
                                    '    .Add("complete", 0)
                                    '    .Add("IsTempComplete", 0)

                                    'End With

                                    'Me.OpenWindow(QS:=QueryString, Height:=250, Width:=500, IsModal:=True)

                                ElseIf PromptForTempCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = ThisAlertId
                                        .Add("complete", 0)
                                        .Add("IsTempComplete", 1)

                                    End With

                                    Me.OpenWindow(QS:=QueryString, Height:=250, Width:=500, IsModal:=True)

                                Else

                                    Me.RadGridAlertInbox.Rebind()
                                    Me.RefreshAlertWindows(False, True, False, False)

                                End If

                            Else

                                If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                            End If

                        End If

                    End Using

                End If

            Case ActionIconState.Undismiss.ToString()

                Dim a As New cAlerts()
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAlertInbox.Items(index), Telerik.Web.UI.GridDataItem)

                ThisAlertId = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)
                a.UnDismissAlert(ThisAlertId, Me.IsClientPortal, Session("UserID"))

                Me.RadGridAlertInbox.Rebind()
                Me.RefreshAlertWindows(False, True, False, False)

            Case ActionIconState.Complete.ToString()

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAlertInbox.Items(index), Telerik.Web.UI.GridDataItem)
                Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
                Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

                If CurrentGridRow IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ThisAlertId = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)
                        AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, ThisAlertId)


                        If ThisAlertId > 0 Then

                            Dim PromptForFullCompleteTask As Boolean = False
                            Dim PromptForTempCompleteTask As Boolean = False
                            Dim s As String = String.Empty

                            Try

                                ThisSprintId = CType(CurrentGridRow.GetDataKeyValue("SPRINT_ID"), Integer)

                            Catch ex As Exception
                                ThisSprintId = 0
                            End Try
                            Try

                                If CurrentGridRow.GetDataKeyValue("CATEGORY") = "Task" Then

                                    IsTask = True

                                End If
                            Catch ex As Exception
                            End Try
                            If IsTask = False Then

                                CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, _Session.User.EmployeeCode, _Session.UserCode, Nothing, Nothing)

                                If CompleteResult.Success = True Then

                                    AdvantageFramework.AlertSystem.CheckForTaskPrompts(DbContext, _Session, AlertEntity, PromptForFullCompleteTask, PromptForTempCompleteTask, s)

                                    If PromptForFullCompleteTask = True Then

                                        'Dim QueryString As New AdvantageFramework.Web.QueryString
                                        'With QueryString

                                        '    .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        '    .AlertId = ThisAlertId
                                        '    .Add("complete", 1)
                                        '    .Add("IsTempComplete", 0)

                                        'End With

                                        'Me.OpenWindow(QS:=QueryString, Height:=250, Width:=500, IsModal:=True)
                                        Me.ShowMessage("Task will be completed if you were the last employee to temp complete")

                                    ElseIf PromptForTempCompleteTask = True Then

                                        Dim QueryString As New AdvantageFramework.Web.QueryString
                                        With QueryString

                                            .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                            .AlertID = ThisAlertId
                                            .Add("complete", 1)
                                            .Add("IsTempComplete", 1)

                                        End With

                                        Me.OpenWindow(QS:=QueryString, Height:=250, Width:=500, IsModal:=True)

                                    Else

                                        Me.RadGridAlertInbox.Rebind()
                                        Me.RefreshAlertWindows(False, True, False, False)

                                    End If

                                End If

                            Else

                                Dim TempCompleted As Boolean = False
                                Dim ShowFullyCompletePrompt As Boolean = False
                                Dim _Controller As AdvantageFramework.Controller.Desktop.AlertController = Nothing
                                Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing

                                _Controller = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)

                                Alert = _Controller.LoadAlert(ThisAlertId, 0, 0, ThisSprintId)

                                TempCompleted = _Controller.TempComplete(Alert, ShowFullyCompletePrompt)

                                If TempCompleted = True Then

                                    If ShowFullyCompletePrompt = True Then

                                        Me.ShowMessage("Task will be completed if you were the last employee to temp complete")
                                        'Dim QueryString As New AdvantageFramework.Web.QueryString
                                        'With QueryString

                                        '    .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        '    .AlertId = ThisAlertId
                                        '    .Add("complete", 1)
                                        '    .Add("IsTempComplete", 0)

                                        'End With

                                        'Me.OpenWindow(QS:=QueryString, Height:=250, Width:=500, IsModal:=True)

                                    End If
                                    ''Webvantage.SignalR.Classes.NotificationHub.RefreshTaskAssignment(DbContext, ThisAlertId, ThisSprintId, Me.SecuritySession.UserCode)

                                End If

                                Me.RadGridAlertInbox.Rebind()

                            End If

                        End If

                    End Using

                End If

            Case ActionIconState.ReOpen.ToString()

                Dim a As New cAlerts()
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAlertInbox.Items(index), Telerik.Web.UI.GridDataItem)
                Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
                Dim s As String = String.Empty
                Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

                Try

                    If CurrentGridRow.GetDataKeyValue("CATEGORY") = "Task" Then

                        IsTask = True

                    End If

                Catch ex As Exception
                End Try

                ThisAlertId = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)

                Try

                    ThisSprintId = CType(CurrentGridRow.GetDataKeyValue("SPRINT_ID"), Integer)

                Catch ex As Exception
                    ThisSprintId = 0
                End Try

                If IsTask = False Then

                    '''''a.UnDismissAlert(ThisAlertId, Me.IsClientPortal, Session("UserID"), True)
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ThisAlertId = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)
                        AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, ThisAlertId)

                        CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, _Session.User.EmployeeCode, _Session.UserCode, Nothing, Nothing)

                    End Using

                Else

                    Dim TempCompleted As Boolean = False
                    Dim ShowFullyCompletePrompt As Boolean = False
                    Dim _Controller As AdvantageFramework.Controller.Desktop.AlertController = Nothing
                    Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing

                    _Controller = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)

                    Alert = _Controller.LoadAlert(ThisAlertId, 0, 0, ThisSprintId)

                    TempCompleted = _Controller.UnTempComplete(Alert)

                End If

                Me.RadGridAlertInbox.Rebind()
                Me.RefreshAlertWindows(False, True, False, False)

            Case ActionIconState.DeleteDraft.ToString()

                Dim a As New cAlerts()
                Dim s As String = ""
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAlertInbox.Items(index), Telerik.Web.UI.GridDataItem)

                ThisAlertId = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)

                If a.DeleteAlert(ThisAlertId, s) = True Then

                    Me.RadGridAlertInbox.Rebind()

                Else

                    If s <> "" Then Me.ShowMessage(s)

                End If

        End Select
    End Sub
    Private Sub RadGridAlertInbox_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAlertInbox.NeedDataSource

        _LoadingDatasource = True

        Try

            Me.RadToolbarAlertInbox.FindItemByValue("ViewComments").Visible = Me.FromJobJacket
            Me.RadGridAlertInbox.PageSize = MiscFN.LoadPageSize(Me.RadGridAlertInbox.ID)
            Me.RadGridAlertInbox.AllowCustomPaging = Not ShouldApplySortFilterOrGroup()

            If Not Me.IsPostBack And Not Me.IsCallback Then

                Me.SavedSettingLoad()
                Session("AlertInboxIsBookmark") = Nothing

            End If

            Dim s As String = String.Empty
            Dim AlertInboxDataTable As New DataTable

            AlertInboxDataTable = Me.GetAlertInboxData(s)

            If String.IsNullOrWhiteSpace(s) = False Then

                Me.ShowMessage(s)
                Exit Sub

            End If

            Dim RecCount As Integer = 5000
            Try

                If AlertInboxDataTable IsNot Nothing AndAlso AlertInboxDataTable.Rows.Count > 0 Then

                    RecCount = AlertInboxDataTable.Rows.Count

                End If

            Catch ex As Exception
                RecCount = 5000
            End Try

            Me.RadGridAlertInbox.VirtualItemCount = RecCount

            Dim Skip As Integer = If((ShouldApplySortFilterOrGroup()), 0, Me.RadGridAlertInbox.CurrentPageIndex * Me.RadGridAlertInbox.PageSize)
            Dim Take As Integer = RecCount

            If Me.RadGridAlertInbox.AllowPaging = True Then

                Take = If((ShouldApplySortFilterOrGroup()), RecCount, Me.RadGridAlertInbox.PageSize)

            End If

            Try

                If AlertInboxDataTable IsNot Nothing Then

                    If AlertInboxDataTable.Rows.Count > 0 Then

                        Me.RadGridAlertInbox.DataSource = AlertInboxDataTable.AsEnumerable().Skip(Skip).Take(Take).CopyToDataTable.DefaultView

                    Else

                        Me.RadGridAlertInbox.DataSource = AlertInboxDataTable

                    End If

                End If
            Catch ex As Exception
            End Try

            Dim ShowReOrderColumn As Boolean = False

            If Me.RadTreeViewFolders.SelectedNode IsNot Nothing AndAlso Me.RadTreeViewFolders.SelectedNode.Value = "Inbox" AndAlso
                (Me.RadComboBoxGroupBy.SelectedItem IsNot Nothing AndAlso Me.RadComboBoxGroupBy.SelectedIndex = 0) Then

                If Me.TxtEmployee.Text.Trim() = Session("EmpCode") AndAlso (Me.RadComboBoxAssignments.SelectedItem.Value = "myalerts" OrElse
                    Me.RadComboBoxAssignments.SelectedItem.Value = "myalertassignments") Then

                    ShowReOrderColumn = True

                End If
                If ShowReOrderColumn = False AndAlso Me.TxtEmployee.Text.Trim() <> "" AndAlso
                    Me.RadComboBoxAssignments.SelectedItem IsNot Nothing AndAlso Me.RadComboBoxAssignments.SelectedItem.Value = "allalertassignments" Then

                    If AdvantageFramework.Security.UserHasAccessToEmployee(_Session, _Session.UserCode, Me.TxtEmployee.Text.Trim()) = True Then

                        ShowReOrderColumn = True

                    End If

                End If

            End If

            RadGridAlertInbox.MasterTableView.GetColumn("DragDropColumn").Visible = ShowReOrderColumn
            RadGridAlertInbox.ClientSettings.AllowRowsDragDrop = ShowReOrderColumn
            RadGridAlertInbox.ClientSettings.Selecting.AllowRowSelect = ShowReOrderColumn

            Me.ApplyGrouping(Me.RadComboBoxGroupBy.SelectedValue, s)
            If String.IsNullOrWhiteSpace(s) = False Then

                Me.ShowMessage(s)
                Exit Sub

            End If

        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
        End Try

        _LoadingDatasource = False

    End Sub
    Private Function ShouldApplySortFilterOrGroup() As Boolean
        Return String.IsNullOrWhiteSpace(RadGridAlertInbox.MasterTableView.FilterExpression) = False OrElse
            (RadGridAlertInbox.MasterTableView.GroupByExpressions.Count > 0) OrElse
            RadGridAlertInbox.MasterTableView.SortExpressions.Count > 0
    End Function

    Private Sub RadGridAlertInbox_RowDrop(sender As Object, e As GridDragDropEventArgs) Handles RadGridAlertInbox.RowDrop
        Dim s As String = ""
        Dim _Controller As AdvantageFramework.Controller.Dashboard.DashboardController = Nothing

        _Controller = New AdvantageFramework.Controller.Dashboard.DashboardController(Me.SecuritySession)

        If Me.TxtEmployee.Text.Trim() <> "" AndAlso e.DraggedItems(0).OwnerGridID = RadGridAlertInbox.ClientID Then

            If e.DestDataItem IsNot Nothing Then

                Dim NewIndex As Integer = e.DestDataItem.ItemIndex
                Dim CurrentGridRow As GridDataItem = e.DraggedItems(0)
                Dim LastIndex As Integer = CurrentGridRow.ItemIndex

                If NewIndex <> LastIndex Then

                    If Me.RadComboBoxAssignments.SelectedValue = "myalertassignments" Then

                        If CurrentGridRow.GetDataKeyValue("CATEGORY").ToString = "Task" Then

                            s = _Controller.SortAssignmentTaskCards(CurrentGridRow.GetDataKeyValue("ALERT_ID"), NewIndex, CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), CurrentGridRow.GetDataKeyValue("TASK_SEQ_NBR"))

                        Else

                            s = _Controller.SortAssignmentTaskCards(CurrentGridRow.GetDataKeyValue("ALERT_ID"), NewIndex, 0, 0, 0)

                        End If

                    Else

                        s = DesktopAlerts.SortAlertAssignmentList(CurrentGridRow.GetDataKeyValue("ALERT_ID"), NewIndex, Me.TxtEmployee.Text.Trim())

                    End If

                    If s.Trim() = "" Or s.Trim() = "True" Then

                        RadGridAlertInbox.Rebind()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub RadGridAlertInbox_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGridAlertInbox.SortCommand
        Me.RadGridAlertInbox.Rebind()
    End Sub

#End Region

    Public Sub RadComboBoxPriority_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)
        Try
            Dim rcb As RadComboBox = CType(sender, Telerik.Web.UI.RadComboBox)
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(rcb.Parent.Parent, Telerik.Web.UI.GridDataItem)
            Dim PriorityHiddenField As HiddenField = CType(CurrentGridRow.FindControl("HiddenFieldPriority"), HiddenField)
            Dim AlertId As Integer = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)

            Dim OldValue As String = PriorityHiddenField.Value

            If CType(OldValue, Integer) <> CType(rcb.SelectedValue, Integer) Then
                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("UPDATE ALERT WITH(ROWLOCK) SET [PRIORITY] = ")
                    .Append(CType(rcb.SelectedValue, Integer).ToString())
                    .Append(" WHERE ALERT_ID = ")
                    .Append(AlertId.ToString())
                    .Append(";")
                End With
                Dim UpdateMessage As New System.Text.StringBuilder
                Dim a As New cAlerts()
                If a.TrackChanges() = True Then
                    With UpdateMessage
                        .Append("Priority changed from:  ")
                        .Append(a.GetPriorityText(OldValue))
                        .Append(Environment.NewLine())
                    End With
                    With SQL
                        .Append("INSERT INTO ALERT_COMMENT WITH(ROWLOCK) (ALERT_ID, USER_CODE, GENERATED_DATE, COMMENT, EMAILSENT) VALUES (")
                        .Append(AlertId.ToString())
                        .Append(", ")
                        .Append("'" & Session("UserCode") & "'")
                        .Append(", ")
                        .Append("GETDATE()")
                        .Append(", ")
                        .Append("'" & UpdateMessage.ToString() & "'")
                        .Append(",0);")
                    End With
                End If
                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session("ConnString"), CommandType.Text, SQL.ToString())
            End If
            Me.RadGridAlertInbox.Rebind()
            Me.FocusControl(rcb)
        Catch ex As Exception
            Me.ShowMessage("Error setting Priority")
        End Try
    End Sub
    Public Sub RadDatePickerStartDate_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs)
        Try
            Dim rdp As RadDatePicker = CType(sender, Telerik.Web.UI.RadDatePicker)
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(rdp.Parent.Parent, Telerik.Web.UI.GridDataItem)

            Dim AlertId As Integer = CurrentGridRow.GetDataKeyValue("ALERT_ID")
            Dim NewValue As String = ""
            Dim OldValue As String = CType(CurrentGridRow.FindControl("HiddenFieldStartDate"), HiddenField).Value

            Try
                NewValue = CType(rdp.SelectedDate, Date).ToShortDateString()
            Catch ex As Exception
                NewValue = ""
            End Try

            Try
                If OldValue.Trim() <> "" Then
                    If IsDate(OldValue) = True Then
                        OldValue = CType(OldValue, Date).ToShortDateString()
                    End If
                End If
            Catch ex As Exception
                OldValue = ""
            End Try

            If OldValue <> NewValue Then
                Dim pSTART_DATE As New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                If cGlobals.wvIsDate(NewValue) = True Then
                    pSTART_DATE.Value = Convert.ToDateTime(NewValue)
                Else
                    pSTART_DATE.Value = System.DBNull.Value
                End If

                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("UPDATE ALERT WITH(ROWLOCK) SET [START_DATE] = @START_DATE WHERE ALERT_ID = ")
                    .Append(AlertId.ToString())
                    .Append(";")
                End With

                Dim UpdateMessage As New System.Text.StringBuilder
                Dim a As New cAlerts()

                If a.TrackChanges() = True Then
                    With UpdateMessage
                        .Append("Start Date changed from:  ")
                        If OldValue.Trim() = "" Then
                            .Append("[No prior entry]")
                        ElseIf cGlobals.wvIsDate(OldValue) = True Then
                            .Append(CType(OldValue, DateTime).ToShortDateString())
                        End If
                        .Append(Environment.NewLine())
                    End With
                    With SQL
                        .Append("INSERT INTO ALERT_COMMENT WITH(ROWLOCK) (ALERT_ID, USER_CODE, GENERATED_DATE, COMMENT, EMAILSENT) VALUES (")
                        .Append(AlertId.ToString())
                        .Append(", ")
                        .Append("'" & Session("UserCode") & "'")
                        .Append(", ")
                        .Append("GETDATE()")
                        .Append(", ")
                        .Append("'" & UpdateMessage.ToString() & "'")
                        .Append(",0);")
                    End With
                End If

                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session("ConnString"), CommandType.Text, SQL.ToString(), pSTART_DATE)

            End If
        Catch ex As Exception
            Me.ShowMessage("Error setting Due Date")
        End Try
    End Sub
    Public Sub RadDatePickerDueDate_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs)
        Try
            Dim rdp As RadDatePicker = CType(sender, Telerik.Web.UI.RadDatePicker)
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(rdp.Parent.Parent, Telerik.Web.UI.GridDataItem)

            Dim AlertId As Integer = CurrentGridRow.GetDataKeyValue("ALERT_ID")
            Dim NewValue As String = ""
            Dim OldValue As String = CType(CurrentGridRow.FindControl("HiddenFieldDueDate"), HiddenField).Value

            Try
                NewValue = CType(rdp.SelectedDate, Date).ToShortDateString()
            Catch ex As Exception
                NewValue = ""
            End Try

            Try
                If OldValue.Trim() <> "" Then
                    If IsDate(OldValue) = True Then
                        OldValue = CType(OldValue, Date).ToShortDateString()
                    End If
                End If
            Catch ex As Exception
                OldValue = ""
            End Try

            If OldValue <> NewValue Then
                Dim pDUE_DATE As New System.Data.SqlClient.SqlParameter("@DUE_DATE", SqlDbType.SmallDateTime)
                If cGlobals.wvIsDate(NewValue) = True Then
                    pDUE_DATE.Value = Convert.ToDateTime(NewValue)
                Else
                    pDUE_DATE.Value = System.DBNull.Value
                End If

                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("UPDATE ALERT WITH(ROWLOCK) SET [DUE_DATE] = @DUE_DATE WHERE ALERT_ID = ")
                    .Append(AlertId.ToString())
                    .Append(";")
                End With

                Dim UpdateMessage As New System.Text.StringBuilder
                Dim a As New cAlerts()

                If a.TrackChanges() = True Then
                    With UpdateMessage
                        .Append("Due Date changed from:  ")
                        If OldValue.Trim() = "" Then
                            .Append("[No prior entry]")
                        ElseIf cGlobals.wvIsDate(OldValue) = True Then
                            .Append(CType(OldValue, DateTime).ToShortDateString())
                        End If
                        .Append(Environment.NewLine())
                    End With
                    With SQL
                        .Append("INSERT INTO ALERT_COMMENT WITH(ROWLOCK) (ALERT_ID, USER_CODE, GENERATED_DATE, COMMENT, EMAILSENT) VALUES (")
                        .Append(AlertId.ToString())
                        .Append(", ")
                        .Append("'" & Session("UserCode") & "'")
                        .Append(", ")
                        .Append("GETDATE()")
                        .Append(", ")
                        .Append("'" & UpdateMessage.ToString() & "'")
                        .Append(",0);")
                    End With
                End If

                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session("ConnString"), CommandType.Text, SQL.ToString(), pDUE_DATE)

            End If
        Catch ex As Exception
            Me.ShowMessage("Error setting Due Date")
        End Try
    End Sub

    Protected Sub RadTreeViewFolders_NodeClick(ByVal o As System.Object, ByVal e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles RadTreeViewFolders.NodeClick

        Dim node As Telerik.Web.UI.RadTreeNode = e.Node

        If Me.AlertsView.ToLower() <> "inbox" And node.Value.ToLower() = "inbox" Then

            Session("AlertInboxStartDate") = Nothing
            Me.RadDatePickerStartDate.SelectedDate = Nothing
            Me.RadDatePickerStartDate.DateInput.Text = ""

        End If

        Me.AlertsView = node.Value

        Me.SetIncludeCompletedCheckbox()

        Select Case node.Value.ToLower()
            Case "sent", "dismissed", "received"

                Me.btnDismissAll.Enabled = False
                Session("AlertInboxUserAppliedFilter") = Nothing

                'If node.Value.ToLower() = "received" Then

                '    Me.RadDatePickerEndDate.SelectedDate = Now.ToShortDateString
                '    Me.RadDatePickerStartDate.SelectedDate = DateAdd(DateInterval.Day, -60, Me.RadDatePickerEndDate.SelectedDate.Value)

                'End If

            Case Else

                Me.btnDismissAll.Enabled = True

        End Select

        Dim oAppVars As New cAppVars(AppVarApplication)
        oAppVars.setAppVarDB("RadTreeViewFolders", Me.AlertsView)

        If Me.RadComboBoxAssignments.SelectedValue.ToString().Trim().ToLower() = "allalertassignments" Then
            Me.TxtEmployee.Text = ""
        End If

        Me.ResetPageIndex()
        Me.RadGridAlertInbox.Rebind()

    End Sub

    Private Sub btnDismissAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDismissAll.Click
        Try

            Dim dt As New DataTable
            Dim PromptForFullCompleteTask As Boolean = False
            Dim PromptForTempCompleteTask As Boolean = False
            Dim s As String = String.Empty
            Dim i As Integer
            Dim a As New cAlerts()

            If Me.RadComboBoxAssignments.SelectedValue = "allalertassignments" Then

                Me.ShowMessage("Cannot Dismiss All on All Assignments")
                Exit Sub

            End If

            dt = Me.GetAlertInboxData(s)

            If s <> "" Then

                Me.ShowMessage(s)
                Exit Sub

            End If
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim CompleteAssignment As Boolean = True

                    If Me.RadComboBoxAssignments.SelectedItem IsNot Nothing Then

                        Select Case Me.RadComboBoxAssignments.SelectedItem.Value.ToString().Trim().ToLower()
                            Case "myalertsandassignments", "myalerts"

                                CompleteAssignment = False

                        End Select

                    End If

                    For i = 0 To dt.Rows.Count - 1

                        Try 'to allow dismiss all on unassigned

                            If CompleteAssignment = True Then

                                CompleteAssignment = dt.Rows(0)("IS_ASSIGNMENT").ToString() = "1"

                            End If

                        Catch ex As Exception
                            CompleteAssignment = False
                        End Try

                        AdvantageFramework.AlertSystem.DismissAlert(DbContext, CInt(dt.Rows(i).Item(0)),
                                                                    HttpContext.Current.Session("EmpCode"), _Session.UserCode, HttpContext.Current.Session("UserID"),
                                                                    CompleteAssignment,
                                                                    PromptForFullCompleteTask, PromptForTempCompleteTask, s)
                    Next

                End Using

            End If
            If Not dt Is Nothing Then

                dt.Dispose()
                dt = Nothing

            End If

            Me.ResetPageIndex()
            Me.RadGridAlertInbox.Rebind()
            Me.RefreshAlertWindows(False, True, False)

        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadToolbarAlertInbox_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarAlertInbox.ButtonClick
        Select Case e.Item.Value
            Case "ShowHideFilter"

                Me.ShowFilter(Not Me.DivFilter.Visible)

                If Me.IsClientPortal = False Then

                    Dim oAppVars As New cAppVars(AppVarApplication)
                    oAppVars.getAllAppVars()
                    oAppVars.setAppVar("DivFilterVisible", Me.DivFilter.Visible.ToString(), "boolean")
                    oAppVars.SaveAllAppVars()

                Else

                    Session("DivFilterVisible_" & AppVarApplication.ToString()) = Me.DivFilter.Visible.ToString()

                End If

            Case "NewAlert"
                Dim URL As String = ""
                If Me.FromJobJacket = False Then
                    URL = "Alert_New.aspx?caller=alertinbox&ps=0&f=" & CType(MiscFN.Source_App.Alert, Integer).ToString()
                ElseIf Me.FromProjectSchedule = True Then
                    URL = "Alert_New.aspx?caller=alertinbox&ps=1&f=" & CType(MiscFN.Source_App.ProjectSchedule_Alerts, Integer).ToString() & "&j=" & Me.FromJobNumber.ToString() & "&jc=" & Me.FromJobComponentNbr.ToString()
                Else
                    URL = "Alert_New.aspx?caller=alertinbox&ps=0&f=" & CType(MiscFN.Source_App.JobJacketAlerts, Integer).ToString() & "&j=" & Me.FromJobNumber.ToString() & "&jc=" & Me.FromJobComponentNbr.ToString()
                End If
                Me.OpenWindow("New Alert", URL)
            Case "NewAlertAssignment"
                Dim URL As String = ""
                'If Me.FromJobJacket = False Then
                '    URL = "Alert_New.aspx?caller=alertinbox&ps=0&assn=1&f=" & CType(MiscFN.Source_App.AlertInbox, Integer).ToString()
                'Else
                If Me.FromProjectSchedule = True Then
                    URL = "Alert_New.aspx?caller=alertinbox&ps=1&assn=1&f=" & CType(MiscFN.Source_App.ProjectSchedule_Alerts, Integer).ToString() & "&j=" & Me.FromJobNumber.ToString() & "&jc=" & Me.FromJobComponentNbr.ToString()
                Else
                    URL = "Alert_New.aspx?caller=alertinbox&ps=0&assn=1&f=" & CType(MiscFN.Source_App.JobJacketAlerts, Integer).ToString() & "&j=" & Me.FromJobNumber.ToString() & "&jc=" & Me.FromJobComponentNbr.ToString()
                End If
                Me.OpenWindow("New Alert", URL, 0, 0, False, False, "RefreshPage")
            Case "Refresh"
                Me.RadGridAlertInbox.Rebind()
                Me.RefreshAlertWindows(False, True, False, False)
            Case "Filter"
                Me.RadGridAlertInbox.AllowFilteringByColumn = Not Me.RadGridAlertInbox.AllowFilteringByColumn
                If Me.RadGridAlertInbox.AllowFilteringByColumn Then
                Else
                    For Each column As GridColumn In Me.RadGridAlertInbox.MasterTableView.Columns
                        column.FilterListOptions = GridFilterListOptions.VaryByDataTypeAllowCustom
                        column.CurrentFilterFunction = GridKnownFunction.NoFilter
                        column.CurrentFilterValue = String.Empty
                    Next
                    RadGridAlertInbox.MasterTableView.FilterExpression = String.Empty
                    RadGridAlertInbox.MasterTableView.Rebind()

                End If
                Session("AlertInboxFilterEmployee") = Me.TxtEmployee.Text
                Me.ResetPageIndex()
                Me.RadGridAlertInbox.Rebind()
            Case "Group"
                Me.RadGridAlertInbox.ShowGroupPanel = Not Me.RadGridAlertInbox.ShowGroupPanel
                Me.RadGridAlertInbox.GroupingEnabled = Me.RadGridAlertInbox.ShowGroupPanel
                If Me.RadGridAlertInbox.ShowGroupPanel = False Then

                    Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Clear()
                    Dim i As Integer
                    For i = 0 To Me.RadGridAlertInbox.Columns.Count - 1
                        Me.RadGridAlertInbox.Columns(i).Visible = True
                    Next
                Else

                End If
                Me.RadGridAlertInbox.Rebind()
            Case "Search"
                Dim Criteria As String = TxtSearchCriteria.Text.Trim()
                Dim oAppVars As New cAppVars(AppVarApplication)
                oAppVars.setAppVarDB("TxtSearchCriteria", Criteria)
                Me.ResetPageIndex()
                Me.RadGridAlertInbox.Rebind()
            Case "ClearSearch"
                Dim oAppVars As New cAppVars(AppVarApplication)
                oAppVars.setAppVarDB("TxtSearchCriteria", "")
                TxtSearchCriteria.Text = ""
                Me.FocusControl(TxtSearchCriteria)
                Me.ResetPageIndex()
                Me.RadGridAlertInbox.Rebind()
            Case "ViewComments"
                If Me.FromJobNumber > 0 And Me.FromJobComponentNbr > 0 Then
                    Me.OpenWindow("Comments for Job:  " & Me.FromJobNumber.ToString().PadLeft(6, "0") & " - " & Me.FromJobComponentNbr.ToString().PadLeft(2, "0"), "JobComponent_Comments.aspx?a=0&j=" & Me.FromJobNumber.ToString() & "&jc=" & Me.FromJobComponentNbr.ToString(), 450, 710, False, True)
                End If
            Case "ExportToExcel"
                Try
                    Dim str As String = ""
                    str = "Alert_Inbox" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)

                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridAlertInbox, str)

                    RadGridAlertInbox.MasterTableView.GetColumn("TemplateColumn1").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("TemplateColumn2").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("AttachmentColumn").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("Priority").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("SubjectColumn").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("SUBJECT").Visible = True
                    RadGridAlertInbox.MasterTableView.GetColumn("CurrentNotifyEmpFMLColumn").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("CURRENT_NOTIFY_EMP_FML_TEXT").Visible = True
                    RadGridAlertInbox.MasterTableView.GetColumn("DUE_DATE").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("DUE_DATE_EXPORT").Visible = True
                    RadGridAlertInbox.MasterTableView.GetColumn("START_DATE").Visible = False
                    RadGridAlertInbox.MasterTableView.GetColumn("START_DATE_EXPORT").Visible = True
                    RadGridAlertInbox.MasterTableView.ExportToExcel()
                Catch ex As Exception
                End Try

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                If Me.FromJobJacket = True Then

                    qs = qs.FromCurrent()

                    b.Name = "Assignments and Alerts for Job: " & Me.FromJobNumber.ToString() & "/" & Me.FromJobComponentNbr.ToString()

                Else

                    With qs

                        .StartDate = Me.RadDatePickerStartDate.SelectedDate.ToString()
                        .EmployeeCode = Me.TxtEmployee.Text.Trim()

                        If Me.RadDatePickerStartDate.SelectedDate <> Now.Date Then

                            .EndDate = Me.RadDatePickerEndDate.SelectedDate.ToString()

                        End If

                    End With

                    b.Name = "Assignments and Alerts Manager"

                End If

                With qs

                    .Add("bm", "1")

                    .Add("ai_folder", Me.RadTreeViewFolders.SelectedValue.ToString())
                    .Add("ai_show", Me.RadComboBoxAssignments.SelectedValue.ToString())
                    .Add("ai_gf", Me.RadComboBoxGroupBy.SelectedValue.ToString())
                    .Add("ai_search", Me.Sanitize(Me.TxtSearchCriteria.Text))

                End With

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_AlertInbox
                    .UserCode = Session("UserCode")
                    .PageURL = "Alert_Inbox.aspx" & qs.ToString()

                End With


                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

        End Select

    End Sub
    Private Sub ChkIncludeCompletedAssignments_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkIncludeCompletedAssignments.CheckedChanged
        Dim oAppVars As New cAppVars(AppVarApplication)
        oAppVars.setAppVarDB("ChkIncludeCompletedAssignments", MiscFN.BoolToInt(Me.ChkIncludeCompletedAssignments.Checked).ToString())
        Me.RadGridAlertInbox.Rebind()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            Me.RadGridAlertInbox.MasterTableView.ExportToPdf()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadComboBoxGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxGroupBy.SelectedIndexChanged

        Dim oAppVars As New cAppVars(AppVarApplication)
        oAppVars.setAppVarDB("RadComboBoxGroupBy", Me.RadComboBoxGroupBy.SelectedValue)

        Me.ResetPageIndex()
        Me.RadGridAlertInbox.Rebind()

        If RadComboBoxGroupBy.Text <> Me.CollapsedHeaders.GroupName Then

            Me.CollapsedHeaders.GroupName = RadComboBoxGroupBy.Text
            Me.CollapsedHeaders.GroupCaptions.Clear()

        End If

    End Sub
    Private Sub RadComboBoxAssignments_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAssignments.SelectedIndexChanged

        Dim oAppVars As New cAppVars(AppVarApplication)
        oAppVars.setAppVarDB("RadComboBoxAssignments", Me.RadComboBoxAssignments.SelectedValue)

        Me.RadTreeViewFolders.FindNodeByValue("Inbox").Visible = True ' "Current"
        Me.RadTreeViewFolders.FindNodeByValue("Dismissed").Visible = True
        Me.RadTreeViewFolders.FindNodeByValue("Received").Visible = True ' "All"
        Me.RadTreeViewFolders.FindNodeByValue("Drafts").Visible = True

        Select Case Me.RadComboBoxAssignments.SelectedValue.ToString().Trim().ToLower()
            Case "myalerts"

                Me.TxtEmployee.Text = Session("EmpCode")
                Me.btnDismissAll.Visible = True

            Case "myalertassignments"

                Me.TxtEmployee.Text = Session("EmpCode")
                Me.btnDismissAll.Visible = True

            Case "myalertsandassignments"

                Me.TxtEmployee.Text = Session("EmpCode")
                Me.btnDismissAll.Visible = True

            Case "allalertassignments"

                Me.TxtEmployee.Text = ""
                Me.btnDismissAll.Visible = False

        End Select

        Me.SetIncludeCompletedCheckbox()
        Me.ResetPageIndex()
        Me.RadGridAlertInbox.Rebind()

    End Sub
    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        If Me.FromJobJacket = False Then

            If IsNumeric(RadGridAlertInbox.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")) = True AndAlso
               IsNumeric(RadGridAlertInbox.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")) = True Then

                Me.MyUnityContextMenu.JobNumber = RadGridAlertInbox.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
                Me.MyUnityContextMenu.JobComponentNumber = RadGridAlertInbox.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")
                Me.MyUnityContextMenu.AlertID = RadGridAlertInbox.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("ALERT_ID")

            End If

        Else

            Me.MyUnityContextMenu.JobNumber = Me.FromJobNumber
            Me.MyUnityContextMenu.JobComponentNumber = Me.FromJobComponentNbr

        End If

    End Sub

#End Region

#Region " Methods "

    Private Sub ShowFilter(ByVal ShowFilter As Boolean)

        Dim RadToolBarButtonShowHideFilter As RadToolBarButton = Me.RadToolbarAlertInbox.FindItemByValue("ShowHideFilter")
        Me.DivGrid.Attributes.Remove("class")

        If ShowFilter = True Then

            Me.DivFilter.Visible = True
            Me.DivGrid.Attributes.Add("class", "two-col-rightcolumn")

            RadToolBarButtonShowHideFilter.ImageUrl = "~/Images/Icons/Grey/256/navigate_left.png"
            RadToolBarButtonShowHideFilter.ToolTip = "Hide filter"

        Else

            Me.DivFilter.Visible = False

            RadToolBarButtonShowHideFilter.ImageUrl = "~/Images/Icons/Grey/256/navigate_right.png"
            RadToolBarButtonShowHideFilter.ToolTip = "Show filter"

        End If

    End Sub
    Private Sub SetCurrentFolderAndShowFilter()

        Select Case Me.RadComboBoxAssignments.SelectedValue.ToString().ToLower()
            Case "myalertsandassignments"

                Me._CurrentShowFilter = AlertInbox_ShowFilter.MyAlertsAndAssignments

            Case "myalerts"

                Me._CurrentShowFilter = AlertInbox_ShowFilter.MyAlerts

            Case "myalertassignments"

                Me._CurrentShowFilter = AlertInbox_ShowFilter.MyAssignments

            Case "allalertassignments"

                Me._CurrentShowFilter = AlertInbox_ShowFilter.AllAssignments

            Case "unassigned"

                Me._CurrentShowFilter = AlertInbox_ShowFilter.Unassigned

        End Select

        Select Case Me.RadTreeViewFolders.SelectedValue.ToString().ToLower()
            Case "inbox"

                Me._CurrentFolder = AlertInbox_FolderFilter.Inbox

            'Case "sent"

            '    Me._CurrentFolder = AlertInbox_FolderFilter.Sent

            Case "dismissed"

                Me._CurrentFolder = AlertInbox_FolderFilter.Dismissed

            Case "received"

                Me._CurrentFolder = AlertInbox_FolderFilter.AllReceived

            Case "drafts"

                Me._CurrentFolder = AlertInbox_FolderFilter.Drafts

        End Select


    End Sub

    Private Function ValidateSearch()

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim myReq As cRequired = New cRequired(Session("ConnString"))
        Dim strCaption As String = String.Empty

        Me.TxtEmployee.Text = Me.TxtEmployee.Text.Trim()

        Session("AlertInboxFilterEmployee") = Me.TxtEmployee.Text

        If Me.TxtEmployee.Text <> "" Then

            If myVal.ValidateEmpCode(Me.TxtEmployee.Text) = False Then

                Me.ShowMessage("This is not a valid Employee Code")
                Return False

            End If

        End If

        Me.SavedSettingsSet()
        Return True

    End Function
    Private Function GetAlertInboxData(ByRef ErrorMessage As String) As DataTable

        Dim LoadSessionDates As Boolean = False

        Try
            If Not Me.IsPostBack And Not Me.IsCallback Then

                If Not Request.QueryString("bm") Is Nothing And Session("AlertInboxIsBookmark") Is Nothing Then

                    Me.LoadingFromBookmark = True
                    Session("AlertInboxIsBookmark") = 1

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs = qs.FromCurrent()

                    If IsDate(qs.StartDate) = True Then

                        Me.RadDatePickerStartDate.SelectedDate = CType(qs.StartDate, Date)

                    End If

                    If IsDate(qs.EndDate) = True Then

                        Me.RadDatePickerEndDate.SelectedDate = CType(qs.EndDate, Date)

                    Else

                        Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday.Date

                    End If

                    Me.TxtEmployee.Text = qs.EmployeeCode

                    Try
                        If qs.Get("ai_folder") <> "" Then
                            RadTreeViewFolders.FindNodeByValue(qs.Get("ai_folder")).Selected = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If qs.Get("ai_show") <> "" Then
                            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAssignments, qs.Get("ai_show"), False)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Me.RadComboBoxGroupBy.SelectedIndex = 0
                        If qs.Get("ai_gf") <> "" Then
                            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxGroupBy, qs.Get("ai_gf"), False)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If qs.Get("ai_search") <> "" Then
                            Me.TxtSearchCriteria.Text = Server.HtmlDecode(qs.Get("ai_search"))
                        End If
                    Catch ex As Exception
                    End Try

                Else 'not postback not bookmark (trying to handle the refresh when closing an alert you are viewing

                    If Me.FromJobJacket = False Then

                        If IsDate(Session("AlertInboxStartDate")) = True Then

                            Me.RadDatePickerStartDate.SelectedDate = CType(Session("AlertInboxStartDate"), Date)

                        End If

                        If IsDate(Session("AlertInboxEndDate")) = True Then

                            Me.RadDatePickerEndDate.SelectedDate = CType(Session("AlertInboxEndDate"), Date)

                        Else

                            Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday.Date

                        End If

                        LoadSessionDates = True

                    End If

                End If

            End If

        Catch ex As Exception
        End Try

        Dim strStartDate As String = ""
        Dim strEndDate As String = ""

        If MiscFN.ValidDate(Me.RadDatePickerStartDate, False) = True Then

            strStartDate = wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToString()

        Else

            strStartDate = "1/1/1950"

        End If

        If MiscFN.ValidDate(Me.RadDatePickerEndDate, False) = True Then

            strEndDate = wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToString()

        Else

            strEndDate = Now.Month.ToString() & "/" & Now.Day.ToString() & "/" & Now.Year.ToString

        End If

        Dim tmpAV As String = Me.AlertsView
        Try
            If Me.RadTreeViewFolders.Nodes.Count > 0 Then
                Me.AlertsView = Me.RadTreeViewFolders.SelectedNode.Value
            End If
        Catch ex As Exception
            Me.AlertsView = tmpAV
        End Try

        Dim AlertDataView As DataView
        Dim a As New cAlerts()

        If InStr(CType(strStartDate, Date).ToShortDateString, "1950") > 0 Then

            Me.RadDatePickerStartDate.DateInput.Text = ""

        Else

            Me.RadDatePickerStartDate.SelectedDate = CType(strStartDate, Date)

        End If

        Me.RadDatePickerEndDate.SelectedDate = CType(strEndDate, Date)

        Me.SetEmployeeTextbox()

        Try
            If Me.RadComboBoxAssignments.SelectedValue = "allalertassignments" And Session("AlertInboxFilterEmployee") IsNot Nothing Then

                If Me.LoadingFromBookmark = False Then

                    Me.TxtEmployee.Text = Session("AlertInboxFilterEmployee")

                Else

                    Session("AlertInboxFilterEmployee") = Me.TxtEmployee.Text

                End If
            End If
        Catch ex As Exception
        End Try



        Dim dt As New DataTable

        If FromJobJacket = False And Me.LoadingFromBookmark = False Then

            If Not Session("AlertInboxUserAppliedFilter") Is Nothing Then

                If Session("AlertInboxUserAppliedFilter") = True Then

                    If Not Session("AlertInboxStartDate") Is Nothing Then

                        If IsDate(Session("AlertInboxStartDate")) = True Then

                            Me.RadDatePickerStartDate.SelectedDate = CType(Session("AlertInboxStartDate"), Date)
                            strStartDate = Me.RadDatePickerStartDate.SelectedDate

                        End If

                    End If
                    If Not Session("AlertInboxEndDate") Is Nothing Then

                        If IsDate(Session("AlertInboxEndDate")) = True Then

                            Me.RadDatePickerEndDate.SelectedDate = CType(Session("AlertInboxEndDate"), Date)
                            strEndDate = Me.RadDatePickerEndDate.SelectedDate

                        End If

                    End If

                End If

            Else

                Try
                    If Me.AlertsView <> "Inbox" And (strStartDate = "" Or strStartDate = "1/1/1950") Then

                        strStartDate = DayPilot.Utils.Week.FirstDayOfWeek.ToShortDateString()
                        Me.RadDatePickerStartDate.SelectedDate = CType(strStartDate, Date)

                    End If
                Catch ex As Exception
                End Try

            End If

        End If
        If Me.IsClientPortal = True Then

            dt = a.LoadAlertsCP(Session("UserID"), Me.AlertsView, "", "",
                                "", "",
                                "", 0, "",
                                Me.CurrentQuerystring.JobNumber,
                                Me.CurrentQuerystring.JobComponentNumber,
                                0, 0,
                                CType(strStartDate, Date).ToShortDateString(),
                                CType(strEndDate, Date).ToShortDateString(),
                                "", "", 0, 0,
                                "", "",
                                "myalertsandassignments", 0, 0,
                                Me.ChkIncludeCompletedAssignments.Checked, Me.FromJobJacket,
                                0, Me.RadComboBoxGroupBy.SelectedValue,
                                TxtSearchCriteria.Text.Trim(), 0, False, Nothing, True, ErrorMessage)

        Else

            Dim RecordCount As Integer = 0

            If Me.checkBoxNewQuery.Checked = True Then

                ''   Mike version
                'dt = a.LoadAlertsNew(Me.TxtEmployee.Text, Me.AlertsView, FilterLevel, Me.txtOffice.Text.Trim(), Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(),
                '                     Me.txtProduct.Text.Trim(), 0, Me.txtCampaign.Text.Trim(), ThisJobNumber, ThisJobComponentNbr,
                '                     ThisAlertTypeId, ThisAlertCategoryId,
                '                     CType(strStartDate, Date).ToShortDateString(), CType(strEndDate, Date).ToShortDateString(),
                '                     FilterLevel, Me.txtVendor.Text.Trim(), ThisEstimateNumber, ThisEstComponentNbr, Me.TxtTaskCode.Text.Trim(), Me.TxtTaskDescription.Text.Trim(), ThisATBNumber,
                '                     Me.RadComboBoxAssignments.SelectedValue, ThisAlertNotifyHdrId, ThisAlertNotifyHeaderName, Me.ChkIncludeCompletedAssignments.Checked, Me.FromJobJacket,
                '                     ThisAlertAssignmentSeqNbr, Me.RadComboBoxGroupBy.SelectedValue, TxtSearchCriteria.Text.Trim(), "", "", ThisStateId, 0, False, Nothing, True, False, ErrorMessage)
                '   Sam version
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim Filter As New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter

                    Filter.UserCode = _Session.UserCode
                    Filter.SearchCriteria = TxtSearchCriteria.Text.Trim()
                    Filter.InboxType = Me.AlertsView
                    Filter.ShowAssignmentType = Me.RadComboBoxAssignments.SelectedValue
                    Filter.IsJobAlertsPage = Me.FromJobJacket
                    Filter.JobNumber = Me.CurrentQuerystring.JobNumber
                    Filter.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
                    Filter.StartDate = Me.RadDatePickerStartDate.SelectedDate
                    Filter.EndDate = Me.RadDatePickerEndDate.SelectedDate
                    Filter.IncludeCompletedAssignments = Me.ChkIncludeCompletedAssignments.Checked
                    Filter.GroupBy = Me.RadComboBoxGroupBy.SelectedValue
                    Filter.IsCount = False
                    Filter.IncludeReviews = False
                    Filter.IncludeBoardLevel = True
                    Filter.IncludeBacklog = False
                    Filter.RecordCount = RecordCount
                    If Filter.ShowAssignmentType.Contains("my") = True Then

                        Filter.EmployeeCode = Me._Session.User.EmployeeCode

                    Else

                        Filter.EmployeeCode = Me.TxtEmployee.Text.Trim()

                    End If

                    dt = AdvantageFramework.AlertSystem.LoadAlertsAndAssignmentsManagerAsDataTable(DbContext:=DbContext,
                                                                                                   Filter:=Filter,
                                                                                                   ErrorMessage:=ErrorMessage)

                End Using

            Else

                '   Old shitty version
                'dt = a.LoadAlerts(Me.TxtEmployee.Text,
                '                  Me.AlertsView,
                '                  "",
                '                  "",
                '                  "",
                '                  "",
                '                  "",
                '                  0,
                '                  "",
                '                  Me.CurrentQuerystring.JobNumber,
                '                  Me.CurrentQuerystring.JobComponentNumber,
                '                  0,
                '                  0,
                '                  CType(strStartDate, Date).ToShortDateString(),
                '                  CType(strEndDate, Date).ToShortDateString(),
                '                  "",
                '                  "",
                '                  0,
                '                  0,
                '                  "",
                '                  "",
                '                  0,
                '                  Me.RadComboBoxAssignments.SelectedValue,
                '                  0,
                '                  "",
                '                  Me.ChkIncludeCompletedAssignments.Checked,
                '                  Me.FromJobJacket,
                '                  0,
                '                  Me.RadComboBoxGroupBy.SelectedValue,
                '                  TxtSearchCriteria.Text.Trim(),
                '                  "",
                '                  "",
                '                  0,
                '                  0,
                '                  False,
                '                  Nothing,
                '                  True,
                '                  False,
                '                  ErrorMessage)

            End If

        End If

        Return dt

    End Function
    Private Function ApplyGrouping(ByVal GroupLevel As String, ByRef ErrorMessage As String) As Boolean
        Dim GroupingFailed As Boolean = False
        Try
            Dim oAppVars As New cAppVars(AppVarApplication)
            oAppVars.setAppVarDB("RadComboBoxGroupBy", GroupLevel)

            Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Clear()

            If GroupLevel <> "" Then
                Select Case GroupLevel
                    Case "CAT" 'ok

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("CATEGORY Category Group By CATEGORY")

                    Case "STATE" 'ok

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("ALERT_STATE_NAME State Group By ALERT_STATE_NAME")

                    Case "ALERT_NOTIFY_NAME"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("ALERT_NOTIFY_NAME Template Group By ALERT_NOTIFY_NAME")

                    Case "LEVEL"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("ALERT_LEVEL_TEXT Level Group By ALERT_LEVEL_TEXT")

                    Case "PRIORITY"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_PRIORITY Task Group By PRIORITY")

                    Case "C"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_CLIENT Client Group By GRP_CLIENT")

                    Case "CD"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_DIVISION Division Group By GRP_DIVISION")

                    Case "CDP"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_PRODUCT Product Group By GRP_PRODUCT")

                    Case "CDPJ"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_JOB Job Group By GRP_JOB")

                    Case "CDPJC"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_COMPONENT Component Group By GRP_COMPONENT")

                    Case "CM" 'ok

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_CAMPAIGN Campaign Group By GRP_CAMPAIGN")

                    Case "O" 'ok

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_OFFICE Office Group By GRP_OFFICE")

                    Case "ES"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_ESTIMATE Estimate Group By GRP_ESTIMATE")

                    Case "EST"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_ESTIMATE_COMPONENT Est.Component Group By GRP_ESTIMATE_COMPONENT")

                    Case "PST"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_TASK Task Group By GRP_TASK")

                    Case "DUE_DATE"

                        Dim GroupByExpression As New GridGroupByExpression

                        Dim GroupByFieldSelect As New GridGroupByField
                        GroupByFieldSelect.FieldName = "GRP_DUE_DATE_DISPLAY"
                        GroupByFieldSelect.FieldAlias = "Due"

                        Dim GroupByField As New GridGroupByField
                        GroupByField.FieldName = "GRP_DUE_DATE"
                        GroupByField.SortOrder = GridSortOrder.Descending

                        GroupByExpression.SelectFields.Add(GroupByFieldSelect)
                        GroupByExpression.GroupByFields.Add(GroupByField)

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add(GroupByExpression)

                    Case "DUE_DATE_ASC"

                        Dim GroupByExpression As New GridGroupByExpression

                        Dim GroupByFieldSelect As New GridGroupByField
                        GroupByFieldSelect.FieldName = "GRP_DUE_DATE_DISPLAY"
                        GroupByFieldSelect.FieldAlias = "Due"

                        Dim GroupByField As New GridGroupByField
                        GroupByField.FieldName = "GRP_DUE_DATE"
                        GroupByField.SortOrder = GridSortOrder.Ascending

                        GroupByExpression.SelectFields.Add(GroupByFieldSelect)
                        GroupByExpression.GroupByFields.Add(GroupByField)

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add(GroupByExpression)

                    Case "AB"

                        Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Add("GRP_ATB ATB Group By GRP_ATB")

                End Select

                Me.RadGridAlertInbox.GroupingEnabled = True
                Me.RadGridAlertInbox.MasterTableView.GroupsDefaultExpanded = True

            Else

                Me.RadGridAlertInbox.GroupingEnabled = False

            End If

            Me.RadGridAlertInbox.ShowGroupPanel = False

        Catch ex As Exception

            GroupingFailed = True
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())

        End Try
        Try

            If GroupingFailed = True Then

                Dim oAppVars As New cAppVars(AppVarApplication)
                oAppVars.setAppVarDB("RadComboBoxGroupBy", "")
                Me.RadGridAlertInbox.GroupingEnabled = False
                Me.RadGridAlertInbox.MasterTableView.GroupByExpressions.Clear()

            End If
        Catch ex As Exception

            GroupingFailed = True
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())

        End Try

        Return Not GroupingFailed

    End Function
    Private Function GetJobComponentDescription() As String
        Dim SessionKey As String = "GetJobComponentDescription" & Me.FromJobNumber.ToString().PadLeft(6, "0") & Me.FromJobComponentNbr.ToString().PadLeft(2, "0")
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim ThisJobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    ThisJobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.FromJobNumber, Me.FromJobComponentNbr)
                End Using
                ReturnString = ThisJobComponent.Description
            Catch ex As Exception
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function
    Private Sub HideExpandColumnRecursive(ByVal tableView As Telerik.Web.UI.GridTableView)
        Dim nestedViewItems As Telerik.Web.UI.GridItem() = tableView.GetItems(Telerik.Web.UI.GridItemType.NestedView)
        For Each nestedViewItem As Telerik.Web.UI.GridNestedViewItem In nestedViewItems
            For Each nestedView As Telerik.Web.UI.GridTableView In nestedViewItem.NestedTableViews
                Dim cell As TableCell = nestedView.ParentItem("ExpandColumn")
                cell.Controls(0).Visible = False
                nestedViewItem.Visible = False
                If nestedView.HasDetailTables Then
                    HideExpandColumnRecursive(nestedView)
                End If
            Next
        Next
    End Sub
    Private Sub SetEmployeeTextbox()
        If Me.FromJobJacket = True Or Me.IsClientPortal = True Then
            Me.TxtEmployee.Text = ""
            Me.TxtEmployee.Enabled = False
            Exit Sub
        Else
            Try
                If Me.IsPostBack Or Me.IsCallback Then
                    Dim AssignmentFilter As String = Me.RadComboBoxAssignments.SelectedValue.ToString().ToLower()
                    Dim FolderFilter As String = Me.RadTreeViewFolders.SelectedNode.Value.ToString().ToLower()

                    Select Case AssignmentFilter
                        Case "myalerts" 'Only alerts
                        Case "myalertassignments" 'Only MY Assignments
                            With Me.TxtEmployee
                                .Text = Session("EmpCode")
                            End With
                        Case "allalertassignments" 'ALL assignments
                            With Me.TxtEmployee
                                '.Text = ""
                            End With
                        Case "unassigned" 'all unassigned
                            With Me.TxtEmployee
                                .Text = ""
                            End With
                    End Select

                    If FolderFilter = "sent" Then 'And AssignmentFilter = "allalertassignments" Then
                        Me.TxtEmployee.Text = Session("EmpCode")
                    End If

                Else 'not a postback, first load
                    If Me.LoadingFromBookmark = False Then
                        With Me.TxtEmployee
                            If Me.RadComboBoxAssignments.SelectedValue = "allalertassignments" Or Me.RadComboBoxAssignments.SelectedValue = "unassigned" Then
                                .Text = ""
                            Else
                                .Text = Session("EmpCode")
                            End If
                        End With
                    End If
                End If

                If Me.RadComboBoxAssignments.SelectedValue = "allalertassignments" Then
                    Me.TxtEmployee.Enabled = True
                Else
                    Me.TxtEmployee.Enabled = False
                End If

                With Me.HlEmployee
                    .Attributes.Remove("onclick")
                    If Me.TxtEmployee.Enabled = True Then
                        .Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtEmployee.ClientID & "&type=empcode');return false;")
                    End If
                End With

            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub UnDismissAlert(ByVal CurrentAlertID As Integer)
        Dim AlertRecipient As New AlertRecipient(CStr(Session("ConnString")))
        ' Load the row from ALERT_RCPT
        AlertRecipient.Where.ALERT_ID.Value = CurrentAlertID
        AlertRecipient.Where.EMP_CODE.Value = Session("EmpCode")
        AlertRecipient.Query.Load()

        If AlertRecipient.RowCount > 0 Then
            'Set the PROCESSED date to now
            AlertRecipient.s_PROCESSED = ""
            AlertRecipient.Save()
        Else
            ' This seems to happen when a user created an alert (Diary) with no recipients.
            AlertRecipient.AddNew()
            ' AlertRecipient.PROCESSED = Date.Now
            AlertRecipient.EMP_CODE = Session("EmpCode")
            AlertRecipient.ALERT_RCPT_ID = 1
            AlertRecipient.ALERT_ID = CurrentAlertID
            AlertRecipient.Save()
        End If
    End Sub
    Private Sub SetIncludeCompletedCheckbox()
        If Me.FromJobJacket = False Then
            With Me.ChkIncludeCompletedAssignments
                Select Case Me.RadTreeViewFolders.SelectedValue.ToLower()
                    Case "inbox"
                        .Checked = False
                        .Enabled = False
                    Case Else
                        .Checked = True
                        .Enabled = False
                End Select
            End With
        Else
            With Me.ChkIncludeCompletedAssignments
                If Me.RadComboBoxAssignments.SelectedValue.ToString().ToLower() <> "unassigned" Then
                    .Checked = True
                    .Enabled = True
                Else
                    .Checked = False
                    .Enabled = False
                End If
            End With
        End If
    End Sub
    Private Sub ClearFilter(ByVal ClearSavedSettings As Boolean, ByVal ClearEmployeeCode As Boolean)

        Me.RadDatePickerStartDate.DateInput.Text = ""
        Me.RadDatePickerStartDate.SelectedDate = Nothing
        Session("AlertInboxStartDate") = Nothing

        Me.RadDatePickerEndDate.SelectedDate = Today.Date
        Session("AlertInboxEndDate") = Today.Date

        If ClearSavedSettings = True Then

            Me.SavedSettingsSet()

        End If

        If Me.TxtEmployee.Enabled = True And ClearEmployeeCode = True Then
            Me.TxtEmployee.Text = ""
            Session("AlertInboxFilterEmployee") = ""
        End If

    End Sub
    Private Sub SavedSettingLoad()
        Try
            If Me.RadTreeViewFolders.Nodes.Count > 0 Then
                Me.RadTreeViewFolders.Nodes.FindNodeByValue("Inbox").Selected = True
            End If
        Catch ex As Exception
        End Try

        Dim IsCustomized As Boolean = False

        Dim LoadAllSettings As Boolean = True

        If Me.FromJobJacket = True Or Me.FromJobJacketDirect = True Then
            LoadAllSettings = False
        End If

        Dim oAppVars As New cAppVars(AppVarApplication)
        oAppVars.getAllAppVars()
        Dim s As String = ""

        If LoadAllSettings = True Then


            'FOLDERS SECTION
            '=================================================================================
            Try
                Me.AlertsView = "Inbox"
                s = oAppVars.getAppVar("RadTreeViewFolders")
                If s <> "" Then
                    Me.AlertsView = s
                End If
            Catch ex As Exception
                Me.AlertsView = "Inbox"
            End Try

            If Me.AlertsView.Trim() = "" Then Me.AlertsView = "Inbox"
            Me.RadTreeViewFolders.Nodes.FindNodeByValue(Me.AlertsView).Selected = True
            '=================================================================================
            If Me.AlertsView.Trim() <> "Inbox" Then IsCustomized = True

            'FILTER ITEMS
            '=================================================================================

        End If

        'HEADER TOOLBAR
        '=================================================================================
        Try
            s = ""
            s = oAppVars.getAppVar("TxtSearchCriteria")
            If s <> "" Then
                Me.TxtSearchCriteria.Text = s.ToString()
            End If
        Catch ex As Exception
        End Try
        Try
            s = ""
            s = oAppVars.getAppVar("RadComboBoxGroupBy")
            If s <> "" And Me.RadComboBoxGroupBy.Items.Count > 0 Then
                Me.RadComboBoxGroupBy.Items.FindItemByValue(s).Selected = True
            End If
        Catch ex As Exception
        End Try
        Try
            s = ""
            s = oAppVars.getAppVar("RadComboBoxAssignments")
            If s <> "" Then
                Me.RadComboBoxAssignments.Items.FindItemByValue(s).Selected = True
            End If
        Catch ex As Exception
        End Try

        Try
            s = ""
            s = oAppVars.getAppVar("ChkIncludeCompletedAssignments")
            If s <> "" Then
                If IsNumeric(s) = True Then
                    Me.ChkIncludeCompletedAssignments.Checked = MiscFN.IntToBool(CType(s, Integer))
                End If
            End If
        Catch ex As Exception
        End Try
        If Me.FromJobJacket = False Then
            Me.ChkIncludeCompletedAssignments.Checked = False
        End If

    End Sub
    Private Sub SavedSettingsSet(Optional ByVal SaveFolders As Boolean = True, Optional ByVal SaveFilter As Boolean = True,
                                 Optional ByVal SaveTypes As Boolean = True, Optional ByVal SaveCategories As Boolean = True,
                                 Optional ByVal SaveHeaderToolbar As Boolean = True)

        If Me.FromJobJacket = True Or Me.FromJobJacketDirect = True Then
            Exit Sub
        End If

        Dim oAppVars As New cAppVars(AppVarApplication)
        oAppVars.getAllAppVars()
        With oAppVars
            If SaveFolders = True Then

                .setAppVar("RadTreeViewFolders", Me.RadTreeViewFolders.SelectedValue)

            End If
            If SaveHeaderToolbar = True Then

                .setAppVar("TxtSearchCriteria", Me.TxtSearchCriteria.Text)
                .setAppVar("RadComboBoxGroupBy", Me.RadComboBoxGroupBy.SelectedValue)
                .setAppVar("RadComboBoxAssignments", Me.RadComboBoxAssignments.SelectedValue)
                .setAppVar("ChkIncludeCompletedAssignments", MiscFN.BoolToInt(Me.ChkIncludeCompletedAssignments.Checked).ToString())

            End If

            .SaveAllAppVars()

        End With

    End Sub
    Private Sub LoadLookups()

        Me.btnDismissAll.Attributes.Add("onclick", "if(confirm('Are you sure you want to dismiss all alerts in the filtered inbox?')==false) return false;")

        If Me.FromJobJacket = False Then

            With Me.RadComboBoxAssignments

                If Me.IsClientPortal = False Then
                    .FindItemByValue("myalertsandassignments").Text = "My Assignments & Alerts"
                End If
                .FindItemByValue("myalerts").Text = "My Alerts"

            End With

        Else

            With Me.RadComboBoxAssignments

                If Me.IsClientPortal = False Then
                    .FindItemByValue("myalertsandassignments").Text = "All Assignments & Alerts"
                End If
                .FindItemByValue("myalerts").Text = "All Alerts"

            End With

        End If


    End Sub
    Private Sub ResetPageIndex()

        Me.CurrentPageNumber = 0
        Me.RadGridAlertInbox.CurrentPageIndex = 0

    End Sub

    Private Sub checkBoxNewQuery_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxNewQuery.CheckedChanged

        Me.RadGridAlertInbox.Rebind()

    End Sub

#End Region

End Class

