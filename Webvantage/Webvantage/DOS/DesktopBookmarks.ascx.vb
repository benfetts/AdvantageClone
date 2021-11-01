Imports Telerik.Web.UI

Public Class DesktopBookmarks
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Page Event Handlers "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        If Not Session("DesktopBookmarksGroup") Is Nothing Then

            Me.CheckBoxGroup.Checked = CType(Session("DesktopBookmarksGroup"), Boolean)

        End If

        If Not Session("DesktopBookmarksEdit") Is Nothing Then

            Me.CheckBoxShowEdit.Checked = CType(Session("DesktopBookmarksEdit"), Boolean)

        End If

    End Sub
    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.SetTreeview(True)

        Else

            Select Case Me.EventTarget
                Case "ReloadPage", "UpdatePanelRadDock"

                    Me.SetTreeview(True)

            End Select

        End If

    End Sub

#End Region

#Region " Controls "

#Region " Page "

    Private Sub CheckBoxShowEdit_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxShowEdit.CheckedChanged

        Session("DesktopBookmarksEdit") = Me.CheckBoxShowEdit.Checked

        Me.RadGridBookmarks.Rebind()

    End Sub

    Private Sub ImageButtonRefresh_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonRefresh.Click

        If Me.RadioButtonShowAsGrid.Checked = True Then

            Me.RadGridBookmarks.Rebind()

        End If
        If Me.RadioButtonShowAsTree.Checked = True Then

            Me.LoadRadTreeViewBookmarks()

        End If

    End Sub

    Private Sub CheckBoxGroup_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroup.CheckedChanged

        Session("DesktopBookmarksGroup") = Me.CheckBoxGroup.Checked

        Me.RadGridBookmarks.Rebind()

    End Sub

#End Region

#Region " Radgrid "

    Private Sub RadGridBookmarks_DeleteCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBookmarks.DeleteCommand
        Dim item As GridEditableItem = TryCast(e.Item, GridEditableItem)
        Dim BookmarkId As Integer = CType(item.GetDataKeyValue("Id"), Integer)

        If BookmarkId > 0 Then

            Dim bm As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim s As String = ""

            If bm.DeleteBookmark(BookmarkId, s) = True Then

                Me.RadGridBookmarks.Rebind()

            Else

                Me.ShowMessage(s)

            End If

        End If

    End Sub
    Private Sub RadGridBookmarks_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridBookmarks.ItemDataBound

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            Dim bm As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim CurrentGridrow As Telerik.Web.UI.GridDataItem = e.Item
            Dim BookmarkHyperLink As System.Web.UI.WebControls.HyperLink

            BookmarkHyperLink = CType(CurrentGridrow.FindControl("HyperLinkBookmarkName"), HyperLink)
            bm = CType(CurrentGridrow.DataItem, AdvantageFramework.Web.Presentation.Bookmarks.Bookmark)

            If Not BookmarkHyperLink Is Nothing AndAlso Not bm Is Nothing AndAlso bm.PageURL <> "" Then

                With BookmarkHyperLink.Attributes
                    .Remove("onclick")
                    .Add("onclick", Me.HookUpOpenWindow("", bm.PageURL))
                End With

            End If

        End If

    End Sub
    Private Sub RadGridBookmarks_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBookmarks.NeedDataSource

        If Me.RadioButtonShowAsGrid.Checked = True Then

            Dim bm As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            With RadGridBookmarks

                .DataSource = bm.GetBookmarks(Session("UserCode"))

                .MasterTableView.Columns.FindByUniqueName("EditCommandColumn").Visible = Me.CheckBoxShowEdit.Checked
                .MasterTableView.Columns.FindByUniqueName("DeleteColumn").Visible = Me.CheckBoxShowEdit.Checked

                .MasterTableView.GroupByExpressions.Clear()

                If Me.CheckBoxGroup.Checked Then

                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("GroupingText Category Group By GroupingText")
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True

                End If

            End With

        End If

    End Sub
    Private Sub RadGridBookmarks_UpdateCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBookmarks.UpdateCommand

        Dim item As GridEditableItem = TryCast(e.Item, GridEditableItem)
        Dim BookmarkId As Integer = CType(item.GetDataKeyValue("Id"), Integer)

        If BookmarkId > 0 Then

            Dim bm As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim s As String = ""

            If bm.UpdateBookmarkNameAndDescription(BookmarkId, _
                                                   CType(item.FindControl("TextBoxBookmarkName"), TextBox).Text.Trim(), _
                                                   CType(item.FindControl("TextBoxDescription"), TextBox).Text.Trim(), s) = True Then

                Me.RadGridBookmarks.Rebind()

            Else

                Me.ShowMessage(s)

            End If

        End If

    End Sub

#End Region

#Region " Treeview "

    Private Sub RadTreeViewBookmarks_ContextMenuItemClick(sender As Object, e As Telerik.Web.UI.RadTreeViewContextMenuEventArgs) Handles RadTreeViewBookmarks.ContextMenuItemClick
        Dim clickedNode As RadTreeNode = e.Node

        Select Case e.MenuItem.Value
            Case "NewFolder"

                Dim newFolder As New RadTreeNode(String.Format("New Folder {0}", clickedNode.Nodes.Count + 1))
                newFolder.Selected = True
                newFolder.ImageUrl = clickedNode.ImageUrl

                Me.RadTreeViewBookmarks.Nodes.Add(newFolder)
                newFolder.Value = newFolder.GetFullPath("/")
                startNodeInEditMode(newFolder.Value)

            Case "Delete"

                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim s As String = ""
                Dim NodeDeleted As Boolean = False

                If clickedNode.Category = "Folder" Then

                    If BmMethods.DeleteFolder(CType(clickedNode.Value, Integer), s) = True Then

                        NodeDeleted = True

                    End If

                ElseIf clickedNode.Category = "Bookmark" Then

                    If clickedNode.ParentNode.Value = "-1" Then
                        'bookmark is in Uncategorized; delete
                        If BmMethods.DeleteBookmark(CType(clickedNode.Value, Integer), s) = True Then

                            NodeDeleted = True

                        End If

                    Else 'remove from folder

                        If BmMethods.RemoveBookmarkFromFolder(CType(clickedNode.Value, Integer), CType(clickedNode.ParentNode.Value, Integer), s) = True Then

                            NodeDeleted = True

                        End If

                    End If

                End If

                If NodeDeleted = True Then

                    'clickedNode.Remove()
                    Me.LoadRadTreeViewBookmarks()

                End If

        End Select

    End Sub

    Private Sub RadTreeViewBookmarks_NodeDrop(sender As Object, e As Telerik.Web.UI.RadTreeNodeDragDropEventArgs) Handles RadTreeViewBookmarks.NodeDrop

        Dim SourceNode As RadTreeNode = e.SourceDragNode
        Dim TargetNode As RadTreeNode = e.DestDragNode

        Dim s As String = ""
        Dim BookmarkMoved As Boolean = False

        If SourceNode.Category = "Folder" Then

            Me.ShowMessage("Folders cannot be moved")
            Exit Sub

        ElseIf SourceNode.Category = "Bookmark" Then

            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim SourceParentNode As RadTreeNode = SourceNode.ParentNode
            Dim TargetParentNode As RadTreeNode = TargetNode.ParentNode

            If TargetNode.Category = "Folder" And TargetNode.Value <> SourceParentNode.Value Then

                If TargetNode.Value = "-1" Then

                    If BmMethods.RemoveBookmarkFromFolder(SourceNode.Value, SourceNode.ParentNode.Value, s) = True Then

                        BookmarkMoved = True
                        SourceNode.Owner.Nodes.Remove(SourceNode)
                        TargetNode.Nodes.Add(SourceNode)

                    Else

                        Me.ShowMessage(s)
                        Exit Sub

                    End If

                Else

                    If BmMethods.MoveBookmarkToFolder(SourceNode.Value, TargetNode.Value, s) = True Then

                        BookmarkMoved = True
                        SourceNode.Owner.Nodes.Remove(SourceNode)
                        TargetNode.Nodes.Add(SourceNode)

                    Else

                        Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))
                        Exit Sub

                    End If

                End If


            ElseIf TargetNode.Category = "Bookmark" Then

                If SourceParentNode.Value = TargetParentNode.Value Then 'user dragged bookmark onto another bookmark in same folder

                    Exit Sub

                Else

                    If TargetParentNode.Category = "Folder" Then 'will need a recurse fn here if we allow nesting folders...?

                        If TargetParentNode.Value = "-1" Then

                            If BmMethods.RemoveBookmarkFromFolder(SourceNode.Value, SourceNode.ParentNode.Value, s) = True Then

                                BookmarkMoved = True
                                SourceNode.Owner.Nodes.Remove(SourceNode)
                                TargetParentNode.Nodes.Add(SourceNode)

                            Else

                                Me.ShowMessage(s)
                                Exit Sub

                            End If

                        Else

                            If BmMethods.MoveBookmarkToFolder(SourceNode.Value, TargetParentNode.Value, s) = True Then

                                SourceNode.Owner.Nodes.Remove(SourceNode)
                                TargetNode.Nodes.Add(SourceNode)
                                BookmarkMoved = True

                            Else

                                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))
                                Exit Sub

                            End If

                        End If

                    End If

                End If

            End If

        End If

        If BookmarkMoved = True Then

            'Me.LoadRadTreeViewBookmarks()

        End If

    End Sub
    Private Sub RadTreeViewBookmarks_NodeEdit(sender As Object, e As Telerik.Web.UI.RadTreeNodeEditEventArgs) Handles RadTreeViewBookmarks.NodeEdit

        Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

        'Update text
        If e.Node.Text <> e.Text Then

            Dim s As String = ""
            Dim NodeUpdated As Boolean = False

            If e.Node.Category = "Folder" Then

                If BmMethods.UpdateFolderNameAndDescription(e.Node.Value, e.Text, e.Node.ToolTip, s) = True Then

                    NodeUpdated = True

                End If

            ElseIf e.Node.Category = "Bookmark" Then

                If BmMethods.UpdateBookmarkNameAndDescription(e.Node.Value, e.Text, e.Node.ToolTip, s) = True Then

                    NodeUpdated = True

                End If

            End If

            If NodeUpdated = True Then

                e.Node.Text = e.Text

            End If

        End If

        'save new folder
        If e.Node.Value.ToString().IndexOf("New Folder") > -1 Then

            Dim f As New AdvantageFramework.Web.Presentation.Bookmarks.BookmarkFolder

            If e.Text.Trim() = "" Then e.Text = e.Node.Text

            With f
                .UserCode = Session("UserCode")
                .Name = e.Text.Trim()
            End With

            BmMethods.CreateFolder(f)

            If f.Id = -1 Then

                Me.ShowMessage(f.ErrorMessage)

            Else

                'e.Node.Value = f.Id
                'e.Node.Text = e.Text
                'e.Node.ToolTip = e.Text
                Me.LoadRadTreeViewBookmarks()

            End If


        End If

    End Sub

#End Region

    Private Sub RadioButtonShowAsGrid_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonShowAsGrid.CheckedChanged

        Me.SetTreeview(Not Me.RadioButtonShowAsGrid.Checked)

    End Sub
    Private Sub RadioButtonShowAsTree_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonShowAsTree.CheckedChanged

        Me.SetTreeview(Me.RadioButtonShowAsTree.Checked)

    End Sub

#End Region

    Private Sub LoadRadTreeViewBookmarks()

        If Me.RadioButtonShowAsTree.Checked = True Then

            Dim IsMetro As Boolean



            Me.RadTreeViewBookmarks.Nodes.Clear()

            Dim CurrentBookmarks As New AdvantageFramework.Web.Presentation.Bookmarks.UserBookmarks(Session("ConnString"), Session("UserCode"))

            CurrentBookmarks.GetAll()

            For Each folder As AdvantageFramework.Web.Presentation.Bookmarks.BookmarkFolder In CurrentBookmarks.BookmarkFolders

                Dim FolderNode As New RadTreeNode

                With FolderNode

                    .Text = folder.Name
                    .ToolTip = folder.Name 'folder.Description
                    .Value = folder.Id
                    .Category = "Folder"
                    .CssClass = "treeview-folder"
                    .ContentCssClass = "treeview-folder-content"
                    If folder.Id = -1 Then

                        .Expanded = True

                    End If

                End With

                For Each bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark In folder.Bookmarks

                    Dim BookmarkNode As New RadTreeNode

                    With BookmarkNode

                        .Text = bookmark.Name
                        .Value = bookmark.Id
                        .ToolTip = bookmark.Name 'bookmark.Description
                        .Category = "Bookmark"
                        .CssClass = "treeview-bookmark" '& bookmark.ColorIndicatorCSSClass
                        .ContentCssClass = "treeview-bookmark-content"

                        .Attributes.Remove("onclick")

                        'If bookmark.PageURL.Contains("bm=1") = False Then

                        '    bookmark.PageURL = bookmark.PageURL & "&bm=1"

                        'End If

                        If bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_AlertInbox Then
                            .Attributes.Add("onclick", Me.HookUpCallUiAction(UI_Action.ActionType.OpenAlertInboxAsBookmark, "&url=" & _
                                                                             Me.Sanitize(AdvantageFramework.Security.Encryption.ASCIIEncoding(bookmark.PageURL))))
                        Else
                            .Attributes.Add("onclick", Me.HookUpOpenWindow("", bookmark.PageURL))
                        End If

                    End With

                    FolderNode.Nodes.Add(BookmarkNode)

                Next

                Me.RadTreeViewBookmarks.Nodes.Add(FolderNode)

            Next

        End If

    End Sub
    Private Sub startNodeInEditMode(ByVal nodeValue As String)

        'find the node by its Value and edit it when page loads
        Dim js As String = "Sys.Application.add_load(editNode); function editNode(){ "
        js += "var tree = $find(""" + Me.RadTreeViewBookmarks.ClientID + """);"
        js += "var node = tree.findNodeByValue('" + nodeValue + "');"
        js += "if (node) node.startEdit();"
        js += "Sys.Application.remove_load(editNode);};"
        RadScriptManager.RegisterStartupScript(Page, Page.[GetType](), "nodeEdit", js, True)

    End Sub
    Private Sub SetTreeview(ByVal IsTreeView As Boolean)

        If IsTreeView = True Then

            Me.LoadRadTreeViewBookmarks()

        Else

            Me.RadGridBookmarks.Rebind()

        End If

        Me.TrShowAsGrid.Visible = Not IsTreeView
        Me.CheckBoxGroup.Visible = Not IsTreeView
        Me.CheckBoxShowEdit.Visible = Not IsTreeView

        Me.TrShowAsTree.Visible = IsTreeView

        Me.RadioButtonShowAsTree.Checked = IsTreeView
        Me.RadioButtonShowAsGrid.Checked = Not IsTreeView

    End Sub

#End Region

End Class
