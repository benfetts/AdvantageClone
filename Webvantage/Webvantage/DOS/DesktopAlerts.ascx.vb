Imports EeekSoft
Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Drawing
Imports AdvantageFramework.AlertSystem
Imports AdvantageFramework.Web.Presentation.Controls
Imports System.Collections.Generic
Imports System.Linq

Partial Public Class DesktopAlerts
    Inherits Webvantage.BaseDesktopObject

#Region " Variables "

    Public li_status As Int16
    Public is_comment As String
    Public alertid As Integer

    Private FilterCategory As Integer = 0
    Private FilterType As Integer = 0
    Private FilterSearch As String = ""
    Private FilterGrouping As String = ""
    Private FilterShowAssignmentType As String = ""
    Private _LoadingDatasource As Boolean = False

    Public Property CollapsedHeaders() As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
        Get
            If IsNothing(Session.Item("AIDO")) Then
                Session.Item("AIDO") = New AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
            End If
            Return Session.Item("AIDO")
        End Get
        Set(ByVal value As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection)
            Session.Item("AIDO") = value
        End Set
    End Property

#End Region

#Region " Page "

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        ''Dim ps As New PersistenceSetting
        ''ps.ControlID = Me.RadGridMyAlerts.ID
        ''Me.PersistenceManager.PersistenceSettings.Add(ps)
        ''Me.PersistenceManager.StorageProvider = New AdvantageFramework.Web.Presentation.Controls.TelerikPersistenceStorageProvider(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), "DesktopAlerts")
        ''Me.PersistenceManager.LoadState()

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridMyAlerts)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridMyAlerts)
        Me.DivUserControlInOutBoard.Visible = False

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.LoadDropdowns()

            If Me.IsClientPortal = True Then

                'Me.RadComboBoxSortOptions.Items(1).Visible = False
                'Me.RadComboBoxSortOptions.Items(2).Visible = False
                'Me.RadComboBoxSortOptions.Items(3).Visible = False
                'Me.RadComboBoxSortOptions.Items(6).Visible = False
                'Me.RadComboBoxSortOptions.Items(7).Visible = False
                'Me.RadComboBoxSortOptions.Items(8).Visible = False
                'Me.RadComboBoxSortOptions.Items(11).Visible = False
                'Me.RadComboBoxSortOptions.Items(12).Visible = False
                'Me.RadComboBoxSortOptions.Items(13).Visible = False
                'Me.RadComboBoxSortOptions.Items(14).Visible = False

                Me.DropDownListShowAssignmentType.Visible = False

                Me.pnlShow.Visible = False

                Me.ImageButtonBookmark.Visible = False
            End If

        Else

            Select Case Me.EventTarget
                Case "RebindGrid", "UpdatePanelRadDock"

                    Me.RadGridMyAlerts.Rebind()

            End Select

        End If

    End Sub

#End Region

#Region " Load Data "

    Private Sub LoadDropdowns()
        'Alert Types
        Dim a As New cAlerts()
        Try

            Me.DropType.Items.Clear()
            Me.DropType.Items.Add(New Telerik.Web.UI.RadComboBoxItem("[All]", ""))

            Dim AlertTypes As New AlertType(Session("ConnString"))

            AlertTypes = a.LoadAlertTypes()

            If AlertTypes.Query.Load() Then

                Do Until AlertTypes.EOF

                    Me.DropType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AlertTypes.ALERT_TYPE_DESC, AlertTypes.ALERT_TYPE_ID))
                    AlertTypes.MoveNext()

                Loop

            End If


        Catch ex As Exception
        End Try

        'Sort options
        Me.RadComboBoxSortOptions.Items.Clear()
        a.LoadAlertGroupingOptions(Me.RadComboBoxSortOptions, cAlerts.AlertGroupingModule.AlertsDO)

        'Alert Categories:
        Try
            Me.DropCategory.Items.Clear()
            Me.DropCategory.Items.Add(New Telerik.Web.UI.RadComboBoxItem("[All]", ""))

            Dim AlertCategories As New AlertCategory(Session("ConnString"))

            AlertCategories = a.LoadAlertCategories()

            If AlertCategories IsNot Nothing Then

                Do Until AlertCategories.EOF

                    Me.DropCategory.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AlertCategories.ALERT_DESC, AlertCategories.ALERT_CAT_ID))
                    AlertCategories.MoveNext()

                Loop

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Filter "

    Private Sub SetSavedSettings()
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_ALERT_DTO)
        oAppVars.getAllAppVars()

        Dim VAL As String = ""
        Try
            VAL = oAppVars.getAppVar("ALERT_CATEGORY")
            If VAL <> "" Then
                MiscFN.RadComboBoxSetIndex(Me.DropCategory, VAL, False)
            End If
            VAL = ""
        Catch ex As Exception
            VAL = ""
        End Try
        Try
            VAL = oAppVars.getAppVar("ALERT_TYPE")
            If VAL <> "" Then
                MiscFN.RadComboBoxSetIndex(Me.DropType, VAL, False)
            End If
            VAL = ""
        Catch ex As Exception
            VAL = ""
        End Try
        Try
            VAL = oAppVars.getAppVar("GROUPING")
            If VAL <> "" Then
                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxSortOptions, VAL, False)
            End If
            VAL = ""
        Catch ex As Exception
            VAL = ""
        End Try
        Try
            VAL = oAppVars.getAppVar("SHOW_ASSIGNMENT_TYPE")
            If VAL <> "" Then
                MiscFN.RadComboBoxSetIndex(Me.DropDownListShowAssignmentType, VAL, False)
            End If
            VAL = ""
        Catch ex As Exception
            VAL = ""
        End Try
    End Sub
    Private Sub SaveAllSettings()

        Dim a As New cAppVars(cAppVars.Application.MY_ALERT_DTO)
        a.getAllAppVars()

        If Me.DropType.SelectedIndex > 0 Then

            a.setAppVar("ALERT_TYPE", Me.DropType.SelectedValue)
            Me.FilterType = Me.DropType.SelectedValue

        Else

            a.setAppVar("ALERT_TYPE", 0)
            Me.FilterType = 0

        End If

        If Me.RadComboBoxSortOptions.SelectedIndex > 0 Then

            a.setAppVar("GROUPING", Me.RadComboBoxSortOptions.SelectedValue)
            Me.FilterGrouping = Me.RadComboBoxSortOptions.SelectedValue

        Else

            a.setAppVar("GROUPING", "")
            Me.FilterGrouping = ""

        End If

        a.setAppVar("SHOW_ASSIGNMENT_TYPE", DropDownListShowAssignmentType.SelectedValue.ToString())

        If Me.DropCategory.SelectedIndex > 0 Then

            a.setAppVar("ALERT_CATEGORY", Me.DropCategory.SelectedValue)
            Me.FilterCategory = Me.DropCategory.SelectedValue

        Else

            a.setAppVar("ALERT_CATEGORY", "")
            Me.FilterCategory = 0

        End If

        a.SaveAllAppVars()

    End Sub
    Private Sub DropCategory_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles DropCategory.SelectedIndexChanged
        Me.SaveAllSettings()
        Me.RadGridMyAlerts.Rebind()
    End Sub
    Private Sub DropType_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles DropType.SelectedIndexChanged
        Me.SaveAllSettings()
        Me.RadGridMyAlerts.Rebind()
    End Sub
    Private Sub DropDownListShowAssignmentType_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles DropDownListShowAssignmentType.SelectedIndexChanged
        Me.SaveAllSettings()
        Me.RadGridMyAlerts.Rebind()
    End Sub
    Private Sub RadComboBoxSortOptions_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSortOptions.SelectedIndexChanged
        Me.SaveAllSettings()
        ''Me.PersistenceManager.SaveState()
        Me.RadGridMyAlerts.Rebind()

        If RadComboBoxSortOptions.Text <> Me.CollapsedHeaders.GroupName Then

            Me.CollapsedHeaders.GroupName = RadComboBoxSortOptions.Text
            Me.CollapsedHeaders.GroupCaptions.Clear()

        End If

    End Sub
    Private Sub imgbtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnSearch.Click
        Me.SaveAllSettings()
        Me.RadGridMyAlerts.Rebind()
    End Sub

#End Region

#Region " RadGridMyAlerts "

    Private Sub RadGridMyAlerts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridMyAlerts.ItemCommand
        Dim index As Integer = 0

        If Not e.Item Is Nothing Then

            index = e.Item.ItemIndex

        Else

            Exit Sub

        End If
        If index = -1 Then 'command item

            Select Case e.CommandName
                Case "ExpandCollapse"

                    If (Me.RadComboBoxSortOptions.SelectedIndex <> -1) Then

                        Dim groupHeaders As List(Of GridItem) = Me.RadGridMyAlerts.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

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

                        Me.CollapsedHeaders.GroupName = RadComboBoxSortOptions.SelectedItem.Text
                        Me.CollapsedHeaders.GroupCaptions = captions

                    End If

            End Select

            Exit Sub

        End If

        Dim AlertID As Integer = 0
        Dim SprintID As Integer = 0
        Dim IsTask As Boolean = False
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridMyAlerts.Items(index), Telerik.Web.UI.GridDataItem)

        If CurrentGridRow IsNot Nothing Then

            Try

                AlertID = CType(CurrentGridRow.GetDataKeyValue("ALERT_ID"), Integer)

            Catch ex As Exception
                AlertID = 0
            End Try
            Try

                SprintID = CType(CurrentGridRow.GetDataKeyValue("SPRINT_ID"), Integer)

            Catch ex As Exception
                SprintID = 0
            End Try

            Try

                If CurrentGridRow.GetDataKeyValue("CATEGORY") = "Task" Then

                    IsTask = True

                End If

            Catch ex As Exception

            End Try

        End If

        If CurrentGridRow IsNot Nothing AndAlso AlertID > 0 Then

            Select Case e.CommandName
                Case ActionIconState.Dismiss.ToString()

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim PromptForFullCompleteTask As Boolean = False
                        Dim PromptForTempCompleteTask As Boolean = False
                        Dim s As String = String.Empty

                        If AdvantageFramework.AlertSystem.DismissAlert(DbContext, AlertID, Session("EmpCode"), Session("UserCode"), Session("UserID"), False,
                                                                           PromptForFullCompleteTask, PromptForTempCompleteTask, s) = True Then

                            If PromptForFullCompleteTask = True Then

                                Dim QueryString As New AdvantageFramework.Web.QueryString
                                With QueryString

                                    .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                    .AlertID = AlertID
                                    .Add("complete", 0)
                                    .Add("IsTempComplete", 0)

                                End With

                                Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                            ElseIf PromptForTempCompleteTask = True Then

                                Dim QueryString As New AdvantageFramework.Web.QueryString
                                With QueryString

                                    .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                    .AlertID = AlertID
                                    .Add("complete", 0)
                                    .Add("IsTempComplete", 1)

                                End With

                                Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                            Else

                                Me.RadGridMyAlerts.Rebind()
                                Me.RefreshAlertWindows(False, False, False)

                            End If

                            'Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me._Session.UserCode)

                        Else

                            If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                        End If

                    End Using

                Case ActionIconState.Undismiss.ToString()

                    Dim a As New cAlerts()

                    a.UnDismissAlert(AlertID, Me.IsClientPortal, Session("UserID"))

                    'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    '    ''Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me._Session.UserCode)

                    'End Using

                    Me.RadGridMyAlerts.Rebind()
                    Me.RefreshAlertWindows(False, False, False)

                Case ActionIconState.Complete.ToString()

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)


                        Dim PromptForFullCompleteTask As Boolean = False
                        Dim PromptForTempCompleteTask As Boolean = False
                        Dim s As String = String.Empty

                        If IsTask = False Then

                            If AdvantageFramework.AlertSystem.DismissAlert(DbContext, AlertID, Session("EmpCode"), Session("UserCode"), Session("UserID"), True,
                                                                               PromptForFullCompleteTask, PromptForTempCompleteTask, s) = True Then

                                If PromptForFullCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = AlertID
                                        .Add("complete", 1)
                                        .Add("IsTempComplete", 0)

                                    End With

                                    Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                                ElseIf PromptForTempCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = AlertID
                                        .Add("complete", 1)
                                        .Add("IsTempComplete", 1)

                                    End With

                                    Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                                Else

                                    Me.RadGridMyAlerts.Rebind()
                                    Me.RefreshAlertWindows(False, False, False)

                                End If

                                ''Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me._Session.UserCode, "", True)

                            Else

                                If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                            End If

                        Else

                            Dim TempCompleted As Boolean = False
                            Dim ShowFullyCompletePrompt As Boolean = False
                            Dim _Controller As AdvantageFramework.Controller.Desktop.AlertController = Nothing
                            Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing

                            _Controller = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)

                            Alert = _Controller.LoadAlert(AlertID, 0, 0, SprintID)

                            TempCompleted = _Controller.TempComplete(Alert, ShowFullyCompletePrompt)

                            If TempCompleted = True Then

                                ''Webvantage.SignalR.Classes.NotificationHub.RefreshTaskAssignment(DbContext, AlertID, SprintID, Me.SecuritySession.UserCode)

                            End If

                            Me.RadGridMyAlerts.Rebind()

                        End If

                    End Using

                Case ActionIconState.ReOpen.ToString()

                    Dim a As New cAlerts()

                    If IsTask = False Then

                        a.UnDismissAlert(AlertID, Me.IsClientPortal, Session("UserID"), True)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ''Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me._Session.UserCode, "", True)

                        End Using

                    Else

                        Dim TempCompleted As Boolean = False
                        Dim ShowFullyCompletePrompt As Boolean = False
                        Dim _Controller As AdvantageFramework.Controller.Desktop.AlertController = Nothing
                        Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing

                        _Controller = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)

                        Alert = _Controller.LoadAlert(AlertID, 0, 0, SprintID)

                        TempCompleted = _Controller.UnTempComplete(Alert)

                    End If

                    Me.RadGridMyAlerts.Rebind()
                    Me.RefreshAlertWindows(False, False, False)

            End Select

        End If

    End Sub
    Private Sub RadGridMyAlerts_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridMyAlerts.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                Dim CurrentGridRow As GridDataItem = e.Item

                Try

                    If IsDBNull(e.Item.DataItem("TIME_DUE")) = False Then

                        CurrentGridRow("GridBoundColumnTimeDue").Text = AdvantageFramework.AlertSystem.MilitaryTimeStringToStandardTimeString(e.Item.DataItem("TIME_DUE"))

                    End If

                Catch ex As Exception
                End Try

                Dim ImageButtonViewAlert As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonViewAlert"), ImageButton)
                Dim LBtnViewAlert As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LBtnViewAlert"), LinkButton)
                Dim IsCSReview As Boolean = False

                Try
                    IsCSReview = e.Item.DataItem("IS_CS_REVIEW")
                Catch ex As Exception
                    IsCSReview = False
                End Try

                If IsCSReview = False Then

                    If e.Item.DataItem("IS_WORK_ITEM") = True Then

                        If Me.FilterShowAssignmentType = "myalerts" OrElse (IsDBNull(e.Item.DataItem("CURRENT_NOTIFY")) = False AndAlso e.Item.DataItem("CURRENT_NOTIFY").ToString = "0") Then

                            ImageButtonViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), "Desktop_AlertView?SprintID=0&AlertID=" & e.Item.DataItem("ALERT_ID")))
                            LBtnViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), "Desktop_AlertView?SprintID=0&AlertID=" & e.Item.DataItem("ALERT_ID")))

                        Else

                            Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                            QsViewDetails.Page = "Desktop_AlertView"
                            QsViewDetails.Add("AlertID", e.Item.DataItem("ALERT_ID").ToString)
                            QsViewDetails.Add("SprintID", e.Item.DataItem("SPRINT_ID").ToString)

                            ImageButtonViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), QsViewDetails.ToString(True)))
                            LBtnViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), QsViewDetails.ToString(True)))

                        End If

                    Else

                        If e.Item.DataItem("CATEGORY") = "PO Approval Request" Then

                            ImageButtonViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), "Alert_View.aspx?AlertID=" & e.Item.DataItem("ALERT_ID") & "&openasassign=false"))
                            LBtnViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), "Alert_View.aspx?AlertID=" & e.Item.DataItem("ALERT_ID") & "&openasassign=false"))

                        Else

                            ImageButtonViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), "Desktop_AlertView?SprintID=0&AlertID=" & e.Item.DataItem("ALERT_ID")))
                            LBtnViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), "Desktop_AlertView?SprintID=0&AlertID=" & e.Item.DataItem("ALERT_ID")))

                        End If

                    End If

                Else

                    Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                    QsViewDetails.Page = "Alert_DigitalAssetReview.aspx"
                    QsViewDetails.AlertID = e.Item.DataItem("ALERT_ID")
                    QsViewDetails.JobNumber = e.Item.DataItem("JOB_NUMBER")
                    QsViewDetails.JobComponentNumber = e.Item.DataItem("JOB_COMPONENT_NBR")
                    QsViewDetails.ConceptShareProjectID = e.Item.DataItem("CS_PROJECT_ID")
                    QsViewDetails.ConceptShareReviewID = e.Item.DataItem("CS_REVIEW_ID")

                    ImageButtonViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), QsViewDetails.ToString(True)))
                    LBtnViewAlert.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Subject").ToString.Replace("'", "\'"), QsViewDetails.ToString(True)))

                End If

                Try
                    Dim ra As String = e.Item.DataItem("READ_ALERT").ToString().Trim()
                    If ra = "&nbsp;" Or ra = "" Then
                        e.Item.Font.Bold = True
                        ImageButtonViewAlert.ImageUrl = "~/Images/Icons/White/256/mail.png"
                    Else
                        e.Item.Font.Bold = False
                        ImageButtonViewAlert.ImageUrl = "~/Images/Icons/White/256/mail_open.png"
                    End If
                Catch ex As Exception
                    e.Item.Font.Bold = False
                    ImageButtonViewAlert.ImageUrl = "~/Images/Icons/White/256/mail_open.png"
                End Try


                Dim PriorityDiv As HtmlControls.HtmlControl = CType(e.Item.FindControl("DivPriority"), HtmlControls.HtmlControl)
                Dim PriorityLabel As Label = CType(e.Item.FindControl("LabelPriority"), Label)

                AdvantageFramework.Web.Presentation.Controls.SetIconLabelPriority(PriorityDiv, PriorityLabel, e.Item.DataItem("PRIORITY"))

                Try
                    If Not IsDBNull(e.Item.DataItem("Subject")) Then
                        LBtnViewAlert.Text = e.Item.DataItem("Subject")
                    Else
                        LBtnViewAlert.Text = "NO SUBJECT"
                    End If
                Catch ex As Exception
                    LBtnViewAlert.Text = "NO SUBJECT"
                End Try

                LBtnViewAlert.CommandArgument = e.Item.DataItem("ALERT_ID")
                LBtnViewAlert.CommandName = "View"

                ''Try
                ''    Dim UpdatedColumnIndex As Integer = 10
                ''    If Me.RadComboBoxSortOptions.SelectedIndex > 0 Then
                ''        UpdatedColumnIndex += 1
                ''    End If
                ''    e.Item.Cells(UpdatedColumnIndex).Text = LoGlo.FormatDateTime(e.Item.Cells(UpdatedColumnIndex).Text)



                ''Catch ex As Exception
                ''End Try

                Dim DismissImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonDismiss"), ImageButton)
                Dim DismissDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDismissComplete")
                Dim IsAssignmentHiddenField As HiddenField = e.Item.FindControl("HiddenFieldIsAssignment")
                Dim IsTaskHiddenField As HiddenField = e.Item.FindControl("HiddenFieldIsTask")

                SetIconState(DismissImageButton, ActionIconState.Dismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, False)

                Try

                    Dim n As Integer = 0
                    Try
                        If Not IsDBNull(e.Item.DataItem("CURRENT_NOTIFY")) = True Then
                            n = CType(e.Item.DataItem("CURRENT_NOTIFY"), Integer)
                        End If
                    Catch ex As Exception
                        n = 0
                    End Try
                    Dim s As String = ""
                    Try
                        If Not IsDBNull(e.Item.DataItem("CURRENT_NOTIFY_EMP_FML")) = True Then
                            s = e.Item.DataItem("CURRENT_NOTIFY_EMP_FML").ToString()
                        End If
                    Catch ex As Exception
                        s = ""
                    End Try

                    Dim g As String = ""
                    Try
                        If Not IsDBNull(e.Item.DataItem("CURRENT_NOTIFY_EMP_CODE")) = True Then
                            g = e.Item.DataItem("CURRENT_NOTIFY_EMP_CODE").ToString()
                        End If
                    Catch ex As Exception
                        g = ""
                    End Try

                    Dim isTask As Boolean = False
                    Dim IsTaskTempComplete As Boolean = False
                    Try

                        If IsDBNull(e.Item.DataItem("CATEGORY")) = False Then

                            If e.Item.DataItem("CATEGORY") = "Task" Then

                                isTask = True

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                    Try

                        If isTask = True AndAlso IsDBNull(e.Item.DataItem("TEMP_COMP_DATE")) = False Then

                            IsTaskTempComplete = True

                        End If

                    Catch ex As Exception

                    End Try

                    Dim isWorkItem As Boolean = False
                    Try

                        If IsDBNull(e.Item.DataItem("IS_WORK_ITEM")) = False Then

                            isWorkItem = e.Item.DataItem("IS_WORK_ITEM")

                        End If

                    Catch ex As Exception

                    End Try

                    If n = 1 Then
                        If s <> "" Then
                            If s.Trim().ToLower = "completed" Then

                                If e.Item.DataItem("IS_CC") = 1 Then

                                    SetIconState(DismissImageButton, ActionIconState.Undismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                                Else

                                    SetIconState(DismissImageButton, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                                End If


                            Else
                                If e.Item.DataItem("IS_CC") = 1 Then

                                    SetIconState(DismissImageButton, ActionIconState.Dismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                                Else

                                    SetIconState(DismissImageButton, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                                End If

                            End If
                        Else
                            If isTask = True Then

                                If IsTaskTempComplete = True Then

                                    SetIconState(DismissImageButton, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                                Else

                                    SetIconState(DismissImageButton, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                                End If

                            Else


                            End If
                        End If
                    ElseIf isTask = True Or isWorkItem = True Then

                        If s.Trim().ToLower = "completed" Then

                            If e.Item.DataItem("IS_CC") = 1 Then

                                SetIconState(DismissImageButton, ActionIconState.Undismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                            Else

                                SetIconState(DismissImageButton, ActionIconState.ReOpen, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                            End If

                        Else

                            If e.Item.DataItem("IS_CC") = 1 Then

                                SetIconState(DismissImageButton, ActionIconState.Dismiss, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                            Else

                                SetIconState(DismissImageButton, ActionIconState.Complete, DismissDiv, IsAssignmentHiddenField, IsTaskHiddenField, isTask)

                            End If

                        End If

                    End If

                Catch ex As Exception

                End Try


            Case Telerik.Web.UI.GridItemType.GroupHeader

        End Select
    End Sub
    Private Sub RadGridMyAlerts_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMyAlerts.NeedDataSource

        Dim a As New cAlerts()
        Dim dv As New DataView

        _LoadingDatasource = True

        Me.FilterSearch = Me.TxtSearch.Text.Trim()

        'If Not Me.IsPostBack AndAlso Not Me.Page.IsCallback Then

        Me.SetSavedSettings()

        'End If

        Try
            If Me.DropType.SelectedIndex > 0 Then
                Me.FilterType = Me.DropType.SelectedValue
            Else
                Me.FilterType = 0
            End If
        Catch ex As Exception
            Me.FilterType = 0
        End Try
        Try
            If Me.RadComboBoxSortOptions.SelectedIndex > 0 Then
                Me.FilterGrouping = Me.RadComboBoxSortOptions.SelectedValue
            Else
                Me.FilterGrouping = ""
            End If
        Catch ex As Exception
            Me.FilterGrouping = ""
        End Try
        Try
            If Me.DropDownListShowAssignmentType.SelectedIndex > 0 Then
                Me.FilterShowAssignmentType = Me.DropDownListShowAssignmentType.SelectedValue
            Else
                Me.FilterShowAssignmentType = "myalertsandassignments"
            End If
        Catch ex As Exception
            Me.FilterShowAssignmentType = "myalertsandassignments"
        End Try
        Try
            If Me.DropCategory.SelectedIndex > 0 Then
                Me.FilterCategory = Me.DropCategory.SelectedValue
            Else
                Me.FilterCategory = 0
            End If
        Catch ex As Exception
            Me.FilterCategory = 0
        End Try

        Dim s As String = ""
        If Me.IsClientPortal = True Then
            dv = a.LoadAlertsCP(Session("UserID"), "inbox", "", "", "", "", "", "", "", 0, 0, Me.FilterType, Me.FilterCategory, "", "", "", "", 0, 0, "", "", "myalertsandassignments",
                          0, "", False, False, 0, Me.FilterGrouping, Me.FilterSearch, 0, False, Nothing, True, s).DefaultView
        Else
            'dv = a.LoadAlerts(Session("EmpCode"), "inbox", "", "", "", "", "", "", "", 0, 0, Me.FilterType, Me.FilterCategory, "", "", "", "", 0, 0, "", "", 0, Me.FilterShowAssignmentType,
            '              0, "", False, False, 0, Me.FilterGrouping, Me.FilterSearch, "", "", 0, 0, False, Nothing, True, False, s).DefaultView
        End If


        Me.RadGridMyAlerts.DataSource = dv

        Me.ApplyGrouping(Me.FilterGrouping)
        Me.RadGridMyAlerts.PageSize = MiscFN.LoadPageSize(Me.RadGridMyAlerts.ID)

        Dim ShowReOrderColumn As Boolean = False

        If Me.IsClientPortal = False AndAlso (Me.RadComboBoxSortOptions.SelectedIndex = Nothing OrElse Me.RadComboBoxSortOptions.SelectedIndex = 0) AndAlso Me.DropDownListShowAssignmentType.SelectedIndex > 0 Then

            ShowReOrderColumn = True

        End If

        RadGridMyAlerts.MasterTableView.GetColumn("DragDropColumn").Visible = ShowReOrderColumn
        RadGridMyAlerts.ClientSettings.AllowRowsDragDrop = ShowReOrderColumn
        RadGridMyAlerts.ClientSettings.Selecting.AllowRowSelect = ShowReOrderColumn

        _LoadingDatasource = False

    End Sub
    Private Sub RadGridMyAlerts_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridMyAlerts.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridMyAlerts.ID, e.NewPageSize)

        End If

    End Sub

    Private Sub ApplyGrouping(ByVal GroupLevel As String)

        Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Clear()

        Select Case GroupLevel
            Case "C"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_CLIENT Client Group By GRP_CLIENT")

            Case "CD"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_DIVISION Division Group By GRP_DIVISION")

            Case "CDP"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_PRODUCT Product Group By GRP_PRODUCT")

            Case "CDPJ"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_JOB Job Group By GRP_JOB")

            Case "CDPJC"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_COMPONENT Component Group By GRP_COMPONENT")

            Case "CM" 'ok

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_CAMPAIGN Campaign Group By GRP_CAMPAIGN")

            Case "CAT" 'ok

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("CATEGORY Category Group By CATEGORY")

            Case "O" 'ok

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_OFFICE Office Group By GRP_OFFICE")

            Case "STATE" 'ok

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("ALERT_STATE_NAME State Group By ALERT_STATE_NAME")

            Case "ES"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_ESTIMATE Estimate Group By GRP_ESTIMATE")

            Case "EST"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_ESTIMATE_COMPONENT Est.Component Group By GRP_ESTIMATE_COMPONENT")

            Case "PST"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_TASK Task Group By GRP_TASK")

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

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add(GroupByExpression)

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

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add(GroupByExpression)

            Case "PRIORITY"

                Me.RadGridMyAlerts.MasterTableView.GroupByExpressions.Add("GRP_PRIORITY Task Group By PRIORITY")

        End Select

        If GroupLevel <> "" Then

            Me.RadGridMyAlerts.GroupingEnabled = True
            Me.RadGridMyAlerts.ShowGroupPanel = False
            Me.RadGridMyAlerts.MasterTableView.GroupsDefaultExpanded = True

        Else

            Me.RadGridMyAlerts.GroupingEnabled = False
            Me.RadGridMyAlerts.ShowGroupPanel = False

        End If

    End Sub

#End Region

#Region " Controls "

    Private Sub butrefreshAlerts_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefreshAlerts.Click

        Me.SaveAllSettings()
        'Me.LoadDropdowns()
        Me.RadGridMyAlerts.Rebind()
        Me.UserControlInOutBoard.LoadCurrentStatus()


    End Sub
    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = Me.RadGridMyAlerts.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = Me.RadGridMyAlerts.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")
        Me.MyUnityContextMenu.AlertID = Me.RadGridMyAlerts.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("ALERT_ID")

    End Sub
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

#End Region

    Private Function CheckCompleteProjectScheduleAlert(ByVal AlertID As Integer, ByVal Complete As Boolean) As Boolean

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Return AdvantageFramework.ProjectSchedule.MarkTaskCompleteOnAlertDismissed(DbContext, Session("UserCode"), Session("EmpCode"), AlertID, Complete)

            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If IsNothing(Session.Item("AIDO")) = False Then
            Dim groupHeaders As List(Of GridItem) = Me.RadGridMyAlerts.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

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

    Private Sub RadGridMyAlerts_RowDrop(sender As Object, e As GridDragDropEventArgs) Handles RadGridMyAlerts.RowDrop

        Dim s As String = ""
        Dim _Controller As AdvantageFramework.Controller.Dashboard.DashboardController = Nothing

        _Controller = New AdvantageFramework.Controller.Dashboard.DashboardController(Me.SecuritySession)

        If e.DraggedItems(0).OwnerGridID = RadGridMyAlerts.ClientID Then

            If e.DestDataItem IsNot Nothing Then

                Dim NewIndex As Integer = e.DestDataItem.ItemIndex '- 1
                Dim CurrentGridRow As GridDataItem = e.DraggedItems(0)
                Dim LastIndex As Integer = CurrentGridRow.ItemIndex

                If NewIndex <> LastIndex Then

                    If Me.DropDownListShowAssignmentType.SelectedValue = "myalertassignments" Then

                        If CurrentGridRow.GetDataKeyValue("CATEGORY").ToString = "Task" Then

                            s = _Controller.SortAssignmentTaskCards(CurrentGridRow.GetDataKeyValue("ALERT_ID"), NewIndex, CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), CurrentGridRow.GetDataKeyValue("TASK_SEQ_NBR"))

                        Else

                            s = _Controller.SortAssignmentTaskCards(CurrentGridRow.GetDataKeyValue("ALERT_ID"), NewIndex, 0, 0, 0)

                        End If

                    Else

                        s = DesktopCardsMyAssignments.SortAlertAssignmentCard(CurrentGridRow.GetDataKeyValue("ALERT_ID"), NewIndex)

                    End If

                    If s.Trim() = "" Then

                        RadGridMyAlerts.Rebind()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            End If

        End If

    End Sub
    Public Shared Function SortAlertAssignmentList(ByVal AlertId As Integer, ByVal NewPosition As Integer, ByVal EmployeeCode As String) As String

        Dim UserCode As String = HttpContext.Current.Session("UserCode")
        Dim ConnectionString As String = HttpContext.Current.Session("ConnString")

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_alerts] '{0}', {1}, {2};",
                                                     EmployeeCode, AlertId, NewPosition))

            End Using

            Return ""

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try

    End Function

    Private Sub UserControlInOutBoard_InsertStatusComplete() Handles UserControlInOutBoard.InsertStatusComplete

        Me.RefreshInOutBoardObjects("DesktopAlerts")

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_AssignmentsAlerts
                .UserCode = Session("UserCode")
                .Name = "Assignments and Alerts"
                .Description = "Assignments and Alerts"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                'Me.RefreshBookmarksDesktopObject()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
