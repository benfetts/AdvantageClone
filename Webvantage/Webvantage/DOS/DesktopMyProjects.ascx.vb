Partial Public Class DesktopMyProjects
    Inherits Webvantage.BaseDesktopObject

    Public strSort

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Me.butPrint.Attributes.Add("onclick", "window.open('dtp_myprojects.aspx?type=my&sort=" & Me.DropSort.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1000,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            Me.butExport.Attributes.Add("onclick", "window.open('dtp_myprojects.aspx?export=1&type=my&sort=" & Me.DropSort.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=50,height=50,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")

            'LoadGrid("duedate")
        End If

        Me.MyUnityContextMenu.SetRadGrid(Me.ProjectRadGrid)

        If DropSort.SelectedIndex = 0 Then
            strSort = "duedate"
        Else
            strSort = DropSort.SelectedValue
        End If

        If Me.IsClientPortal = True Then
            Me.ImageButtonBookmark.Visible = False
        End If

    End Sub

    Private Sub LoadGrid(ByVal SortBy As String)

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        Me.ProjectRadGrid.DataSource = oDO.DesktopObject_GetMyProjectsSort(CStr(Session("EmpCode")), SortBy, Me.txtSearch.Text, Me.IsClientPortal, Session("UserID"))
        Me.ProjectRadGrid.DataBind()
        Me.ProjectRadGrid.PageSize = MiscFN.LoadPageSize(Me.ProjectRadGrid.ID)

    End Sub

    Private Sub DropSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropSort.SelectedIndexChanged
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Me.ProjectRadGrid.DataSource = oDO.DesktopObject_GetMyProjectsSort(CStr(Session("EmpCode")), DropSort.SelectedValue, Me.txtSearch.Text)
        Me.ProjectRadGrid.Rebind()
    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyProjects", "ProjectMySearch", "", Me.txtSearch.Text)
        Me.ProjectRadGrid.Rebind()
        'LoadGrid(DropSort.SelectedValue)
    End Sub

    Private Sub imgbtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSearch.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyProjects", "ProjectMySearch", "", Me.txtSearch.Text)
        Me.ProjectRadGrid.MasterTableView.CurrentPageIndex = 0
        Me.ProjectRadGrid.Rebind()
        'LoadGrid(DropSort.SelectedValue)
    End Sub

    Private Sub ProjectRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles ProjectRadGrid.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                Dim ViewDetailsImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonViewDetails")
                ViewDetailsImageButton.Attributes.Add("onclick", "OpenRadWindow('','TrafficSchedule_ViewTasks.aspx?JobNo=" & e.Item.DataItem("JobNo") & "&JobComp=" & e.Item.DataItem("JobCompNo") & "'); return false;")

                Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.Cells(3).FindControl("ViewLinkButton")
                ViewLinkButton.Text = e.Item.DataItem("JobAndComp")
                ViewLinkButton.Attributes.Add("onclick", "OpenRadWindow('','Content.aspx?PageMode=Edit&JobNum=" & e.Item.DataItem("JobNo") & "&JobCompNum=" & e.Item.DataItem("JobCompNo") & "&NewComp=0'); return false;")

                If e.Item.Cells(5).Text <> "" And e.Item.Cells(5).Text <> "&nbsp;" Then
                    e.Item.Cells(5).Text = LoGlo.FormatDate(e.Item.Cells(5).Text) ' CDate(e.Item.Cells(11).Text).ToShortDateString
                End If
                If e.Item.Cells(6).Text <> "" And e.Item.Cells(6).Text <> "&nbsp;" Then
                    e.Item.Cells(6).Text = LoGlo.FormatDate(e.Item.Cells(6).Text) 'CDate(e.Item.Cells(12).Text).ToShortDateString
                End If

        End Select
    End Sub

    Private Sub ProjectRadGrid_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles ProjectRadGrid.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim otask As cTasks = New cTasks(Session("ConnString"))

            Me.ProjectRadGrid.DataSource = oDO.DesktopObject_GetMyProjectsSort(CStr(Session("EmpCode")), DropSort.SelectedValue, Me.txtSearch.Text, Me.IsClientPortal, Session("UserID"))
            Me.ProjectRadGrid.PageSize = MiscFN.LoadPageSize(Me.ProjectRadGrid.ID)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProjectRadGrid_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles ProjectRadGrid.PageIndexChanged
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Me.ProjectRadGrid.DataSource = oDO.DesktopObject_GetMyProjectsSort(CStr(Session("EmpCode")), DropSort.SelectedValue, Me.txtSearch.Text)
        Me.ProjectRadGrid.Rebind()
    End Sub

    Private Sub ProjectRadGrid_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles ProjectRadGrid.PageSizeChanged
        MiscFN.SavePageSize(Me.ProjectRadGrid.ID, e.NewPageSize)
    End Sub

    Private Sub ProjectRadGrid_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProjectRadGrid.PreRender
        Session("MyProjectsDOSortExp") = Me.ProjectRadGrid.MasterTableView.SortExpressions.GetSortString
    End Sub

    Private Sub ProjectRadGrid_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles ProjectRadGrid.SortCommand
        Me.LoadGrid(Me.DropSort.SelectedValue)
    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = ProjectRadGrid.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNo")
        Me.MyUnityContextMenu.JobComponentNumber = ProjectRadGrid.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobCompNo")

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_MyProjects
                .UserCode = Session("UserCode")
                .Name = "Projects (My)"
                .Description = "Projects (My)"
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
