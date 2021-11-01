Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class DesktopInOutBoard
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property CurrentGridPageIndex As Integer = 0

#End Region

#Region " Methods "

#Region " Controls "

    Protected Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click

        Me.InOutRadGrid.Rebind()

    End Sub

    Private Sub ddGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGroupBy.SelectedIndexChanged

        Response.Cookies("InOutBoardSort").Expires = Now.AddYears(1)
        Response.Cookies("InOutBoardSort")("Grouping") = Me.ddGroupBy.SelectedValue

        Me.InOutRadGrid.Rebind()

    End Sub

    Private Sub InOutRadGrid_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles InOutRadGrid.ItemCommand
        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim AlertGroupCode As String = ""
        Dim cdo As New cDesktopObjects(_Session.ConnectionString)

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = InOutRadGrid.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In InOutRadGrid.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    Dim tb As TextBox = CType(GridDataItem.FindControl("TextBoxComment"), TextBox)

                    cdo.tInOutBoardSaveComment(GridDataItem.GetDataKeyValue("EMP_CODE"), tb.Text, GridDataItem.GetDataKeyValue("INOUT_REF"))

                Next

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Dim tb As TextBox = CType(CurrentGridDataItem.FindControl("TextBoxComment"), TextBox)

                    cdo.tInOutBoardSaveComment(CurrentGridDataItem.GetDataKeyValue("EMP_CODE"), tb.Text, CurrentGridDataItem.GetDataKeyValue("INOUT_REF"))

                End If

        End Select
    End Sub

    Private Sub InOutRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles InOutRadGrid.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Header


            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)
                Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim Label As System.Web.UI.WebControls.Label = Nothing

                If CurrentGridRow IsNot Nothing Then

                    CurrentGridRow("GridBoundColumnInOutTime").Text = Webvantage.InOutBoard.DisplayInOutTime(CurrentGridRow("GridBoundColumnInOutTime").Text)

                    If e.Item.DataItem("INOUT_STAT").ToString() = "1" Then 'out

                        CurrentGridRow("GridBoundColumnExpectedReturn").Text = Webvantage.InOutBoard.DisplayReturnTime(CurrentGridRow("GridBoundColumnInOutTime").Text, CurrentGridRow("GridBoundColumnExpectedReturn").Text)

                    Else 'in

                        'CurrentGridRow("GridBoundColumnReason").Text = ""
                        CurrentGridRow("GridBoundColumnExpectedReturn").Text = ""

                    End If

                    Dim FlagColorDiv As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivFlagColor")
                    AdvantageFramework.Web.Presentation.Controls.SetInOutBoardColor(FlagColorDiv, e.Item.DataItem("INOUT_STAT"))

                    If CurrentGridRow.GetDataKeyValue("INOUT_REF") = -1 Or e.Item.DataItem("INOUT_STAT").ToString() = "1" Then

                        TextBox = CurrentGridRow.FindControl("TextBoxComment")
                        Label = CurrentGridRow.FindControl("LabelComment")

                        TextBox.Visible = False
                        Label.Visible = True

                    Else

                        Label = CurrentGridRow.FindControl("LabelComment")
                        Label.Visible = False

                    End If

                End If

        End Select
    End Sub
    Private Sub InOutRadGrid_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles InOutRadGrid.NeedDataSource

        Me.UserControlInOutBoard.LoadCurrentStatus()

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        If Me.ddGroupBy.SelectedValue = "Dept" Then

            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Clear()
            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Add("DEPT Department Group By DEPT")
            Me.InOutRadGrid.GroupingEnabled = True
            Me.InOutRadGrid.ShowGroupPanel = False
            Me.InOutRadGrid.MasterTableView.GroupsDefaultExpanded = False

        ElseIf Me.ddGroupBy.SelectedValue = "Office" Then

            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Clear()
            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Add("OFFICE Office Group By OFFICE")
            Me.InOutRadGrid.GroupingEnabled = True
            Me.InOutRadGrid.ShowGroupPanel = False
            Me.InOutRadGrid.MasterTableView.GroupsDefaultExpanded = False

        ElseIf Me.ddGroupBy.SelectedValue = "OD" Then

            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Clear()
            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Add("OFFICE Office Group By OFFICE")
            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Add("DEPT Department Group By DEPT")
            Me.InOutRadGrid.GroupingEnabled = True
            Me.InOutRadGrid.ShowGroupPanel = False
            Me.InOutRadGrid.MasterTableView.GroupsDefaultExpanded = False

        Else

            Me.InOutRadGrid.MasterTableView.GroupByExpressions.Clear()
            Me.InOutRadGrid.GroupingEnabled = False

        End If

        Me.InOutRadGrid.DataSource = oDO.GetInOutBoard()

        Me.InOutRadGrid.CurrentPageIndex = Me.CurrentGridPageIndex
        Me.InOutRadGrid.PageSize = MiscFN.LoadPageSize(Me.InOutRadGrid.ID)

    End Sub
    Private Sub InOutRadGrid_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles InOutRadGrid.PageIndexChanged

        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.InOutRadGrid.Rebind()

    End Sub
    Private Sub InOutRadGrid_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles InOutRadGrid.PageSizeChanged
        MiscFN.SavePageSize(Me.InOutRadGrid.ID, e.NewPageSize)
    End Sub
    Private Sub InOutRadGrid_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles InOutRadGrid.SortCommand
        Me.InOutRadGrid.Rebind()
    End Sub
    Private Sub UserControlInOutBoard_InsertStatusComplete() Handles UserControlInOutBoard.InsertStatusComplete
        Me.InOutRadGrid.Rebind()
        Me.RefreshInOutBoardObjects("DesktopInOutBoard")
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_MyInOutBoard
                .UserCode = Session("UserCode")
                .Name = "In/Out Board (My)"
                .Description = "In/Out Board (My)"
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

#End Region
#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Not Request.Cookies("InOutBoardSort") Is Nothing Then

                If Request.Cookies("InOutBoardSort")("Grouping") <> "" Then

                    Me.ddGroupBy.SelectedValue = Request.Cookies("InOutBoardSort")("Grouping")

                End If

            End If

        Else

            Select Case Me.EventTarget
                Case "RebindGrid", "UpdatePanelRadDock"

                    Me.InOutRadGrid.Rebind()

            End Select

        End If

    End Sub

#End Region

#End Region

End Class
