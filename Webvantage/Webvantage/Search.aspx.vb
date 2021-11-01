Imports System.Data.SqlClient

Public Class Search
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Private Const TruncateLength As Integer = 10

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _SearchText As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Search_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.LoadCheckBoxLists()
            Me.LoadSavedSearchSettings()

            Me.RadToolbarSearch.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

            Try
                If Not Request.QueryString("bm") Is Nothing Then

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs = qs.FromCurrent()

                    Me.CheckBoxExact.Checked = qs.Get("ex") = "True"
                    Me.TextBoxSearch.Text = qs.Get("val")

                    Me.Search()

                End If

            Catch ex As Exception
            End Try

            If Me.IsClientPortal = True Then
                For Each item As ListItem In Me.CheckBoxListEstimates.Items
                    item.Selected = False
                Next
                For Each item As ListItem In Me.CheckBoxListPurchaseOrders.Items
                    item.Selected = False
                Next
                Me.CheckBoxListEstimates.Visible = False
                Me.CheckBoxListPurchaseOrders.Visible = False
                Me.PanelEstimate.Visible = False
                Me.CheckboxJobRequests.Checked = False
                'Me.CheckboxJobRequests.Visible = False
            End If

        End If

        Me.TextBoxSearch.Focus()

    End Sub

#End Region

#Region " Controls Events "

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click

        Me.SaveAllSearchSettings()

    End Sub
    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click

        If Me.TextBoxSearch.Text.Trim() = "" Then

            Me.ShowMessage("Please enter a search term")

        Else

            Me.Search()

        End If

    End Sub

    Private Sub RadGridSearch_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSearch.ItemDataBound

        Try

            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing
                CurrentGridRow = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                If Not CurrentGridRow Is Nothing Then

                    Dim HyperLinkResult As System.Web.UI.WebControls.HyperLink = Nothing
                    Dim CurrentResult As AdvantageFramework.Database.Classes.Search = Nothing

                    HyperLinkResult = DirectCast(CurrentGridRow("GridHyperLinkColumnLink").Controls(0), HyperLink)
                    CurrentResult = e.Item.DataItem

                    If Not HyperLinkResult Is Nothing AndAlso Not CurrentResult Is Nothing Then

                        With HyperLinkResult

                            Dim Text As String = ""

                            If Not CurrentResult.MatchingText Is Nothing Then

                                Text = CurrentResult.MatchingText.ToString()
                                Text = AdvantageFramework.StringUtilities.RemoveAllHtmlTags(Text)

                                Dim MatchingTextLength As Integer = Text.Length

                                Try

                                    If MatchingTextLength > 100 Then

                                        Dim StartSubString As Integer = 0
                                        Dim SubStringLength As Integer = 100

                                        Text = Text.Substring(StartSubString, SubStringLength) & "..."

                                    End If

                                Catch ex As Exception

                                    Text = CurrentResult.MatchingText.ToString()

                                End Try

                                Text = Microsoft.VisualBasic.Strings.Replace(Text, Me._SearchText, "<strong>" & Me._SearchText & "</strong>", 1, -1, CompareMethod.Text)

                                .Text = Text
                                .NavigateUrl = ""
                                .Attributes.Add("style", "text-decoration:underline !important;")

                                If Not CurrentResult.Link = Nothing Then

                                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        If CurrentResult.Link.Contains("TrafficSchedule_TaskDetail") Then

                                            Dim task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
                                            task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, CurrentResult.ID1, CurrentResult.ID2, CurrentResult.ID3)

                                            If task IsNot Nothing Then
                                                .Attributes.Add("onclick", Me.HookUpOpenWindow(task.Description.Replace("'", "\'"), CurrentResult.Link))
                                            Else
                                                .Attributes.Add("onclick", Me.HookUpOpenWindow("", CurrentResult.Link))
                                            End If

                                        ElseIf CurrentResult.Link.Contains("Alert_View") = True Then

                                            Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                                            alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, CurrentResult.ID1)

                                            If alert IsNot Nothing Then
                                                .Attributes.Add("onclick", Me.HookUpOpenWindow(alert.Subject.Replace("'", "\'"), CurrentResult.Link))
                                            Else
                                                .Attributes.Add("onclick", Me.HookUpOpenWindow("", CurrentResult.Link))
                                            End If

                                        Else

                                            .Attributes.Add("onclick", Me.HookUpOpenWindow("", CurrentResult.Link))

                                        End If

                                    End Using

                                End If
                            End If
                        End With

                    End If

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridSearch_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSearch.NeedDataSource

        If Me._SearchText <> "" Then

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadGridSearch.DataSource = AdvantageFramework.Database.Procedures.SearchComplexType.Load(DbContext, Session("EmpCode"), Session("UserCode"),
                                                           Me._SearchText, Me.CheckBoxExact.Checked,
                                                           Me.CheckBoxListJobJackets.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.JobsOpen.ToString()).Selected,
                                                           Me.CheckBoxListJobJackets.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.JobsClosed.ToString()).Selected,
                                                           Me.CheckBoxListJobJackets.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.JobsDescription.ToString()).Selected,
                                                           Me.CheckBoxListJobJackets.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.JobsComments.ToString()).Selected,
                                                           Me.CheckBoxListAlerts.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsStandard.ToString()).Selected,
                                                           Me.CheckBoxListAlerts.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsAssignments.ToString()).Selected,
                                                           Me.CheckBoxListAlerts.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsSubject.ToString()).Selected,
                                                           Me.CheckBoxListAlerts.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsDescription.ToString()).Selected,
                                                           Me.CheckBoxListAlerts.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsOpen.ToString()).Selected,
                                                           Me.CheckBoxListAlerts.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsDismissedCompleted.ToString()).Selected,
                                                           Me.CheckBoxListSchedules.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleComments.ToString()).Selected,
                                                           Me.CheckBoxListSchedules.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleIncludeClosed.ToString()).Selected,
                                                           Me.CheckBoxListSchedules.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskDescription.ToString()).Selected,
                                                           Me.CheckBoxListSchedules.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskFunctionComments.ToString()).Selected,
                                                           Me.CheckBoxListSchedules.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskDueDateComments.ToString()).Selected,
                                                           Me.CheckBoxListSchedules.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskRevisionDateComments.ToString()).Selected,
                                                           Me.CheckBoxListSchedules.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskIncludeClosed.ToString()).Selected,
                                                           Me.CheckBoxListEstimates.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateDescription.ToString()).Selected,
                                                           Me.CheckBoxListEstimates.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComments.ToString()).Selected,
                                                           Me.CheckBoxListEstimates.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComponentDescription.ToString()).Selected,
                                                           Me.CheckBoxListEstimates.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComponentComments.ToString()).Selected,
                                                           Me.CheckBoxListEstimates.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateFooterComments.ToString()).Selected,
                                                           Me.CheckBoxListEstimates.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateQuoteDetailComments.ToString()).Selected,
                                                           Me.CheckBoxListEstimates.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateQuoteDetailDescription.ToString()).Selected,
                                                           Me.CheckBoxListCampaigns.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.CampaignComments.ToString()).Selected,
                                                           Me.CheckBoxListPurchaseOrders.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDescription.ToString()).Selected,
                                                           Me.CheckBoxListPurchaseOrders.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderMainInstruction.ToString()).Selected,
                                                           Me.CheckBoxListPurchaseOrders.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDeliveryInstruction.ToString()).Selected,
                                                           Me.CheckBoxListPurchaseOrders.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailDescription.ToString()).Selected,
                                                           Me.CheckBoxListPurchaseOrders.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailLineDescription.ToString()).Selected,
                                                           Me.CheckBoxListPurchaseOrders.Items.FindByValue(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailInstruction.ToString()).Selected,
                                                           Me.IsClientPortal, Session("UserID"), Me.CheckboxJobRequests.Checked).ToList()

            End Using


            Me.RadGridSearch.MasterTableView.GroupByExpressions.Clear()
            Me.RadGridSearch.MasterTableView.GroupByExpressions.Add("Group [Found in] Group By GroupCount desc, Group desc")

            Me.RadGridSearch.MasterTableView.HierarchyDefaultExpanded = False

        End If

    End Sub

    Private Sub RadToolbarSearch_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSearch.ButtonClick

        Select Case e.Item.Value

            Case "Search"

                If Me.TextBoxSearch.Text.Trim() = "" Then

                    Me.ShowMessage("Please enter a search term")

                Else

                    Me.Search()

                End If

            Case "Clear"

                Me.TextBoxSearch.Text = ""

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                With qs

                    .Add("ex", Me.CheckBoxExact.Checked.ToString())
                    .Add("val", Me.TextBoxSearch.Text)

                    .Build()

                End With

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Custom_Search
                    .UserCode = Session("UserCode")
                    .Name = "Search for: &quot;" & Me.TextBoxSearch.Text & "&quot;"
                    .PageURL = "Search.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If


        End Select


    End Sub

#End Region

#Region " Methods "

    Private Sub LoadCheckBoxLists()

        With Me.CheckBoxListAlerts.Items

            .Clear()

            .Add(New ListItem("Standard Alerts", AdvantageFramework.Database.Entities.SearchAllParameters.AlertsStandard.ToString()))
            .Add(New ListItem("Assignments", AdvantageFramework.Database.Entities.SearchAllParameters.AlertsAssignments.ToString()))
            .Add(New ListItem("Subject", AdvantageFramework.Database.Entities.SearchAllParameters.AlertsSubject.ToString()))
            .Add(New ListItem("Description", AdvantageFramework.Database.Entities.SearchAllParameters.AlertsDescription.ToString()))
            .Add(New ListItem("Open", AdvantageFramework.Database.Entities.SearchAllParameters.AlertsOpen.ToString()))
            .Add(New ListItem("Dismissed/Completed", AdvantageFramework.Database.Entities.SearchAllParameters.AlertsDismissedCompleted.ToString()))

        End With
        For Each item As ListItem In Me.CheckBoxListAlerts.Items

            item.Selected = item.Value <> AdvantageFramework.Database.Entities.SearchAllParameters.AlertsDismissedCompleted.ToString()

        Next

        With Me.CheckBoxListCampaigns.Items

            .Clear()

            .Add(New ListItem("Comments", AdvantageFramework.Database.Entities.SearchAllParameters.CampaignComments.ToString()))

        End With
        With Me.CheckBoxListEstimates.Items

            .Clear()

            .Add(New ListItem("Description", AdvantageFramework.Database.Entities.SearchAllParameters.EstimateDescription.ToString()))
            .Add(New ListItem("Comments", AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComments.ToString()))
            .Add(New ListItem("Footer Comments", AdvantageFramework.Database.Entities.SearchAllParameters.EstimateFooterComments.ToString()))
            .Add(New ListItem("Component Description", AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComponentDescription.ToString()))
            .Add(New ListItem("Component Comments", AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComponentComments.ToString()))
            .Add(New ListItem("Quote Detail Comments", AdvantageFramework.Database.Entities.SearchAllParameters.EstimateQuoteDetailComments.ToString()))
            .Add(New ListItem("Quote Detail Description", AdvantageFramework.Database.Entities.SearchAllParameters.EstimateQuoteDetailDescription.ToString()))

        End With
        For Each item As ListItem In Me.CheckBoxListEstimates.Items

            item.Selected = True

        Next
        With Me.CheckBoxListJobJackets.Items

            .Clear()

            .Add(New ListItem("Description", AdvantageFramework.Database.Entities.SearchAllParameters.JobsDescription.ToString()))
            .Add(New ListItem("Comments", AdvantageFramework.Database.Entities.SearchAllParameters.JobsComments.ToString()))
            .Add(New ListItem("Open", AdvantageFramework.Database.Entities.SearchAllParameters.JobsOpen.ToString()))
            .Add(New ListItem("Closed", AdvantageFramework.Database.Entities.SearchAllParameters.JobsClosed.ToString()))

        End With
        For Each item As ListItem In Me.CheckBoxListJobJackets.Items

            item.Selected = item.Value <> AdvantageFramework.Database.Entities.SearchAllParameters.JobsClosed.ToString()

        Next
        With Me.CheckBoxListPurchaseOrders.Items

            .Clear()

            .Add(New ListItem("Description", AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDescription.ToString()))
            .Add(New ListItem("Main Instructions", AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderMainInstruction.ToString()))
            .Add(New ListItem("Delivery Instructions", AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDeliveryInstruction.ToString()))
            .Add(New ListItem("Detail Description", AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailDescription.ToString()))
            .Add(New ListItem("Detail Line Description", AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailLineDescription.ToString()))
            .Add(New ListItem("Detail Instructions", AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailInstruction.ToString()))

        End With
        For Each item As ListItem In Me.CheckBoxListPurchaseOrders.Items

            item.Selected = True

        Next
        With Me.CheckBoxListSchedules.Items

            .Clear()

            .Add(New ListItem("Comments", AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleComments.ToString()))
            .Add(New ListItem("Task Description", AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskDescription.ToString()))
            .Add(New ListItem("Task Function Comments", AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskFunctionComments.ToString()))
            .Add(New ListItem("Task Due Date Comments", AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskDueDateComments.ToString()))
            .Add(New ListItem("Task Revision Date Comments", AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskRevisionDateComments.ToString()))
            .Add(New ListItem("Include Closed Schedules", AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleIncludeClosed.ToString()))
            .Add(New ListItem("Include Completed Tasks", AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskIncludeClosed.ToString()))

        End With
        For Each item As ListItem In Me.CheckBoxListSchedules.Items

            If item.Value <> AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleIncludeClosed.ToString() Or
                item.Value <> AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskIncludeClosed.ToString() Then

                item.Selected = True

            End If

        Next

    End Sub
    Private Sub LoadSavedSearchSettings()

        Dim Settings As New AdvantageFramework.Web.UserSettings.Settings(New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode),
                                                                         AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll, HttpContext.Current)

        Settings.Load()

        Dim Item As New ListItem

        Item = Nothing

        For Each Setting In Settings.List

            Select Case Setting.Group

                Case Me.CheckBoxListAlerts.ID

                    Item = Me.CheckBoxListAlerts.Items.FindByValue(Setting.Name)

                    If Not Item Is Nothing Then

                        Item.Selected = Setting.Value = "True"

                    End If

                    Item = Nothing

                Case Me.CheckBoxListCampaigns.ID

                    Item = Me.CheckBoxListCampaigns.Items.FindByValue(Setting.Name)

                    If Not Item Is Nothing Then

                        Item.Selected = Setting.Value = "True"

                    End If

                    Item = Nothing

                Case Me.CheckBoxListEstimates.ID

                    Item = Me.CheckBoxListEstimates.Items.FindByValue(Setting.Name)

                    If Not Item Is Nothing Then

                        Item.Selected = Setting.Value = "True"

                    End If

                    Item = Nothing

                Case Me.CheckBoxListJobJackets.ID

                    Item = Me.CheckBoxListJobJackets.Items.FindByValue(Setting.Name)

                    If Not Item Is Nothing Then

                        Item.Selected = Setting.Value = "True"

                    End If

                    Item = Nothing

                Case Me.CheckBoxListPurchaseOrders.ID

                    Item = Me.CheckBoxListPurchaseOrders.Items.FindByValue(Setting.Name)

                    If Not Item Is Nothing Then

                        Item.Selected = Setting.Value = "True"

                    End If

                    Item = Nothing

                Case Me.CheckBoxListSchedules.ID

                    Item = Me.CheckBoxListSchedules.Items.FindByValue(Setting.Name)

                    If Not Item Is Nothing Then

                        Item.Selected = Setting.Value = "True"

                    End If

                    Item = Nothing

                Case Me.CheckboxJobRequests.ID

                    If Setting.Value = "True" Then
                        Me.CheckboxJobRequests.Checked = True
                    End If

            End Select

        Next

    End Sub
    Private Sub SaveAllSearchSettings()

        Dim Settings As New AdvantageFramework.Web.UserSettings.Settings(New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode),
                                                                         AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll, HttpContext.Current)

        Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing

        For Each item As ListItem In Me.CheckBoxListJobJackets.Items

            Setting = New AdvantageFramework.Database.Entities.AppVars()

            With Setting

                .UserCode = _Session.UserCode
                .Application = AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll.ToString()
                .Group = Me.CheckBoxListJobJackets.ID.ToString()
                .Type = "Boolean"
                .Name = item.Value
                .Value = item.Selected.ToString()

            End With

            Settings.List.Add(Setting)
            Setting = Nothing

        Next
        For Each item As ListItem In Me.CheckBoxListAlerts.Items

            Setting = New AdvantageFramework.Database.Entities.AppVars()

            With Setting

                .UserCode = _Session.UserCode
                .Application = AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll.ToString()
                .Group = Me.CheckBoxListAlerts.ID.ToString()
                .Type = "Boolean"
                .Name = item.Value
                .Value = item.Selected.ToString()

            End With

            Settings.List.Add(Setting)
            Setting = Nothing

        Next
        For Each item As ListItem In Me.CheckBoxListSchedules.Items

            Setting = New AdvantageFramework.Database.Entities.AppVars()

            With Setting

                .UserCode = _Session.UserCode
                .Application = AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll.ToString()
                .Group = Me.CheckBoxListSchedules.ID.ToString()
                .Type = "Boolean"
                .Name = item.Value
                .Value = item.Selected.ToString()

            End With

            Settings.List.Add(Setting)
            Setting = Nothing

        Next
        For Each item As ListItem In Me.CheckBoxListEstimates.Items

            Setting = New AdvantageFramework.Database.Entities.AppVars()

            With Setting

                .UserCode = _Session.UserCode
                .Application = AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll.ToString()
                .Group = Me.CheckBoxListEstimates.ID.ToString()
                .Type = "Boolean"
                .Name = item.Value
                .Value = item.Selected.ToString()

            End With

            Settings.List.Add(Setting)
            Setting = Nothing

        Next
        For Each item As ListItem In Me.CheckBoxListPurchaseOrders.Items

            Setting = New AdvantageFramework.Database.Entities.AppVars()

            With Setting

                .UserCode = _Session.UserCode
                .Application = AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll.ToString()
                .Group = Me.CheckBoxListPurchaseOrders.ID.ToString()
                .Type = "Boolean"
                .Name = item.Value
                .Value = item.Selected.ToString()

            End With

            Settings.List.Add(Setting)
            Setting = Nothing

        Next

        Setting = New AdvantageFramework.Database.Entities.AppVars()

        With Setting

            .UserCode = _Session.UserCode
            .Application = AdvantageFramework.Web.UserSettings.ApplicationPage.SearchAll.ToString()
            .Group = Me.CheckboxJobRequests.ID.ToString
            .Type = "Boolean"
            .Name = Me.CheckboxJobRequests.Text
            .Value = Me.CheckboxJobRequests.Checked.ToString()

        End With

        Settings.List.Add(Setting)
        Setting = Nothing

        Settings.Update()

        If Me.TextBoxSearch.Text.Trim() <> "" Then

            Me.Search()

        End If

    End Sub
    Private Sub Search()

        Dim SearchJobJacket As Boolean = Me.CheckBoxListJobJackets.SelectedIndex > -1
        Dim SearchAlerts As Boolean = Me.CheckBoxListAlerts.SelectedIndex > -1
        Dim SearchSchedules As Boolean = Me.CheckBoxListSchedules.SelectedIndex > -1
        Dim SearchEstimates As Boolean = Me.CheckBoxListEstimates.SelectedIndex > -1
        Dim SearchCampaigns As Boolean = Me.CheckBoxListCampaigns.SelectedIndex > -1
        Dim SearchPurchaseOrders As Boolean = Me.CheckBoxListPurchaseOrders.SelectedIndex > -1
        Dim SearchJobRequests As Boolean = Me.CheckboxJobRequests.Checked

        If SearchJobJacket = False And SearchAlerts = False And SearchSchedules = False And _
            SearchEstimates = False And SearchCampaigns = False And SearchPurchaseOrders = False And SearchJobRequests = False Then

            Me.ShowMessage("Please select at least one search area")
            Exit Sub

        End If

        Me._SearchText = Me.TextBoxSearch.Text.Trim()

        Me.RadGridSearch.Rebind()

    End Sub

#End Region

End Class
