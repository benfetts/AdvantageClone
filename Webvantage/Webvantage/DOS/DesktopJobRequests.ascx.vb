Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Public Class DesktopJobRequests
    Inherits Webvantage.BaseDesktopObject

    Public strTaskStatus As String
    Public strShow As String = ""
    Public dDateStart As Date
    Public dDateEnd As Date

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.butPrint.Attributes.Add("onclick", "window.open('dtp_jobrequests.aspx?DesktopObject=All', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1100,height=800,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            Me.butExport.Attributes.Add("onclick", "window.open('dtp_jobrequests.aspx?export=1&DesktopObject=All', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            If Not Page.IsPostBack Then
                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim taskVar As String

                dDateStart = Date.Today
                RadDatePickerStart.SelectedDate = dDateStart
                RadDatePickerDue.SelectedDate = dDateStart.AddMonths(1)


                If otask.getAppVars(Session("UserCode"), "JobRequests", "dDateStart") <> "" Then
                    Me.RadDatePickerStart.SelectedDate = otask.getAppVars(Session("UserCode"), "JobRequests", "dDateStart")
                Else
                    otask.setAppVars(Session("UserCode"), "JobRequests", "dDateStart", "", CStr(RadDatePickerStart.SelectedDate))
                End If
                If otask.getAppVars(Session("UserCode"), "JobRequests", "dDateDue") <> "" Then
                    Me.RadDatePickerDue.SelectedDate = otask.getAppVars(Session("UserCode"), "JobRequests", "dDateDue")
                Else
                    otask.setAppVars(Session("UserCode"), "JobRequests", "dDateDue", "", CStr(RadDatePickerDue.SelectedDate))
                End If

                taskVar = otask.getAppVars(Session("UserCode"), "JobRequests", "sSearch")
                If taskVar <> "" Then
                    Me.txtSearch.Text = taskVar
                    Me.TextBoxSearchHeader.Text = taskVar
                Else
                    Me.txtSearch.Text = ""
                    Me.TextBoxSearchHeader.Text = ""
                End If

                If otask.getAppVars(Session("UserCode"), "JobRequests", "CheckboxExclude") <> "" Then
                    Me.CheckboxExclude.Checked = CType(otask.getAppVars(Session("UserCode"), "JobRequests", "CheckboxExclude"), Boolean)
                End If

                LoadRequests()
                Session("TasksDOSortOrder") = ""
                Session("TasksDOSortExp") = ""
            Else

                Select Case Me.EventTarget
                    Case "RebindGrid", "UpdatePanelRadDock"
                        Me.RadGridAllJobRequestsDO.Rebind()

                End Select

            End If

        Catch ex As Exception

        End Try

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridAllJobRequestsDO)

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridAllJobRequestsDO)
        If Me.IsClientPortal = True Then
            AddHandler RadGridAllJobRequestsDO.HeaderContextMenu.ItemCreated, AddressOf HeaderContextMenuItemCreated
        End If

        Try
            Dim head As GridHeaderItem
            Try
                If Not Me.RadGridAllJobRequestsDO.MasterTableView.GetItems(GridItemType.Header) Is Nothing Then
                    head = TryCast(Me.RadGridAllJobRequestsDO.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
                End If
            Catch ex As Exception
                head = Nothing
            End Try
            'Me.HideIconHeaderLabels(head)
        Catch ex As Exception
        End Try

        If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, False) = 0 Then
            Me.ImageButtonAdd.Visible = False
        End If

    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        'otask.setAppVars(Session("UserCode"), "MyTasks", "ddType", "", Me.ddType.SelectedValue) 'status
        'otask.setAppVars(Session("UserCode"), "MyTasks", "ddTaskShow", "", Me.ddTaskShow.SelectedValue)
        otask.setAppVars(Session("UserCode"), "JobRequests", "sSearch", "", Me.txtSearch.Text)
        LoadRequests()
    End Sub
    Private Sub imgbtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSearch.Click
        Me.Search(Me.txtSearch.Text)
    End Sub
    Private Sub Search(ByVal Search As String)

        Search = Search.Trim()

        Me.TextBoxSearchHeader.Text = Search
        Me.txtSearch.Text = Search
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "JobRequests", "sSearch", "", Search)
        Me.RadGridAllJobRequestsDO.MasterTableView.CurrentPageIndex = 0

        LoadRequests()

    End Sub

    Private Sub TaskRadGrid_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAllJobRequestsDO.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub
            Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim ar() As String
            Dim commandParm As String
            Dim jv As New JobVersion(Session("ConnString"))
            Dim dr As SqlDataReader

            Select Case e.CommandName
                Case "Detail"
                    If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                        CurrentGridDataItem = RadGridAllJobRequestsDO.Items(e.Item.ItemIndex)

                    End If

                    If CurrentGridDataItem.GetDataKeyValue("JOB_NUMBER") > 0 Then
                        Dim qs As New AdvantageFramework.Web.QueryString
                        qs.Page = "Content.aspx"
                        qs.JobNumber = CurrentGridDataItem.GetDataKeyValue("JOB_NUMBER")
                        qs.JobComponentNumber = CurrentGridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                        Me.OpenWindow("", qs.ToString(True))
                    Else
                        dr = jv.GetJVRequestDescriptions(CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"))
                        If dr.HasRows Then
                            dr.Read()
                            If IsDBNull(dr("CL_CODE")) = True Then
                                Me.OpenWindow("Job Request", "jobVerTmplt.aspx?mode=request&JobVerHdrID=" & CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"), 600, 1100)
                            Else
                                Me.OpenWindow("Job Request", "jobVerTmplt.aspx?mode=requesttoform&JobVerHdrID=" & CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"), 600, 1100)
                            End If
                            dr.Close()
                        End If
                    End If

            End Select
        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Sub
    Private Sub TaskRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAllJobRequestsDO.ItemDataBound
        'If e.Item.ItemType = GridItemType.Header Then
        '    Dim Header As GridHeaderItem = TryCast(e.Item, GridHeaderItem)
        '    Me.HideIconHeaderLabels(Header)
        'End If
        Try

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)

                'Dim ViewImage As WebControls.ImageButton = e.Item.FindControl("ImageButtonViewDetails")

                'Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.FindControl("ViewLinkButton")
                'ViewLinkButton.Text = e.Item.DataItem("JobData")
                'ViewLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Content.aspx?From=DO&PageMode=Edit&JobNum=" & e.Item.DataItem("JOB_NUMBER") & "&JobCompNum=" & e.Item.DataItem("JOB_COMPONENT_NBR") & "&NewComp=0"))

                Dim job As Integer = e.Item.DataItem("JOB_NUMBER")
                Dim comp As Integer = e.Item.DataItem("JOB_COMPONENT_NBR")

                If job = 0 Then
                    GridRow("JobNumber").Text = ""
                Else
                    GridRow("JobNumber").Text = job.ToString().PadLeft(6, "0")
                End If

                If comp = 0 Then
                    GridRow("ComponentNumber").Text = ""
                Else
                    GridRow("ComponentNumber").Text = comp.ToString().PadLeft(2, "0")
                End If

                Try
                    If IsDate(e.Item.DataItem("CREATE_DATE")) = True Then
                        GridRow("RequestDate").Text = LoGlo.FormatDate(CType(e.Item.DataItem("CREATE_DATE"), Date))
                    End If
                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub TaskRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAllJobRequestsDO.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim jv As New JobVersion(Session("ConnString"))

            If IsClientPortal = True Then
                RadGridAllJobRequestsDO.DataSource = jv.GetJobRequestsDO(Session("CL_CODE"), "", "", Me.RadDatePickerStart.SelectedDate, Me.RadDatePickerDue.SelectedDate, Me.txtSearch.Text, Me.CheckboxExclude.Checked, "All", True, Session("UserID"))
            Else
                RadGridAllJobRequestsDO.DataSource = jv.GetJobRequestsDO("", "", "", Me.RadDatePickerStart.SelectedDate, Me.RadDatePickerDue.SelectedDate, Me.txtSearch.Text, Me.CheckboxExclude.Checked, "All", False)
            End If
            ' Me.RadGridJobRequestsDO.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridAllJobRequestsDO.PageSize = MiscFN.LoadPageSize(Me.RadGridAllJobRequestsDO.ID)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadGridJobRequestsDO_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridAllJobRequestsDO.PageIndexChanged
        LoadRequests()
    End Sub
    Private Sub RadGridJobRequestsDO_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridAllJobRequestsDO.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridAllJobRequestsDO.ID, e.NewPageSize)
    End Sub
    Private Sub RadGridJobRequestsDO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAllJobRequestsDO.PreRender

    End Sub
    Private Sub RadGridJobRequestsDO_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGridAllJobRequestsDO.SortCommand

        LoadRequests()

    End Sub

    Private Sub HeaderContextMenuItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
        Try
            If e.Item.Controls.Count > 0 Then
                If e.Item.Text = "Add Time" Then
                    e.Item.Visible = False
                End If
                If e.Item.Text = "Mark Complete" Then
                    e.Item.Visible = False
                End If
                If e.Item.Text = "Start Stopwatch" Then
                    e.Item.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Private Sub HideIconHeaderLabels(ByRef header As GridHeaderItem)

    '    If Not header Is Nothing Then

    '        Try
    '            header("TemplateColumn2").Text = "&nbsp;"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            header("TemplateColumn3").Text = "&nbsp;"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            header("GridTemplateColumnStopwatch").Text = "&nbsp;"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            header("TemplateColumn1").Text = "&nbsp;"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            header("TemplateColumn4").Text = "&nbsp;"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            header("TemplateColumnDocuments").Text = "&nbsp;"
    '        Catch ex As Exception
    '        End Try

    '    End If

    'End Sub
    Private Sub LoadRequests()

        Me.RadGridAllJobRequestsDO.Rebind()

    End Sub
    Public Function SetStyle(ByVal PValue As String) As String
        If PValue = "" Then
            Return "calendarNormal"
        Else
            Return "calendarPending"
        End If
    End Function

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = RadGridAllJobRequestsDO.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = RadGridAllJobRequestsDO.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

    End Sub
    Private Sub ImageButtonSearchHeader_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonSearchHeader.Click
        Me.Search(Me.TextBoxSearchHeader.Text)
    End Sub

    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub RadDatePickerDue_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerDue.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        dDateEnd = Me.RadDatePickerDue.SelectedDate
        If dDateEnd = "#12:00:00 AM#" Then
            dDateEnd = Today()
        End If

        otask.setAppVars(Session("UserCode"), "JobRequests", "dDateDue", "", CStr(dDateEnd))

        LoadRequests()
    End Sub

    Private Sub RadDatePickerStart_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStart.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        dDateStart = Me.RadDatePickerStart.SelectedDate
        If dDateStart = "#12:00:00 AM#" Then
            dDateStart = Today()
        End If

        otask.setAppVars(Session("UserCode"), "JobRequests", "dDateStart", "", CStr(dDateStart))

        LoadRequests()
    End Sub

    Private Sub butExport_Click(sender As Object, e As ImageClickEventArgs) Handles butExport.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageButtonAdd_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAdd.Click
        Me.OpenWindow("Add Job Request", "jobVerNew.aspx?mode=request", 690, 950)
    End Sub

    Private Sub CheckboxExclude_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxExclude.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "JobRequests", "CheckboxExclude", "Boolean", Me.CheckboxExclude.Checked)

        LoadRequests()
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobRequests
                .UserCode = Session("UserCode")
                .Name = "Job Requests (All)"
                .Description = "Job Requests (All)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
