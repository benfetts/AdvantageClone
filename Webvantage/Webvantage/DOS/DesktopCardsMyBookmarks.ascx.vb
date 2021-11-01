Public Class DesktopCardsMyBookmarks
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Bookmark As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub DesktopCardsMyBookmarks_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Me.EventTarget = "SignOut" OrElse Me.EventTarget = "UpdatePanelAlertsAndAssignments" Then Exit Sub

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.LoadData()

        Else

            Select Case Me.EventTarget
                Case "UpdatePanelUserBookmarks"
                    Me.LoadData()
            End Select

        End If

    End Sub

#Region " Listview "

    Public Sub LoadData()

        Dim bm As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

        Me.DataListBookmarks.DataSource = bm.GetBookmarks(HttpContext.Current.Session("UserCode"))
        Me.DataListBookmarks.DataBind()

    End Sub
    Private Sub DataListBookmarks_CancelCommand(source As Object, e As DataListCommandEventArgs) Handles DataListBookmarks.CancelCommand

        Me.DataListBookmarks.EditItemIndex = -1
        Me.LoadData()

    End Sub

    Private Sub DataListBookmarks_DeleteCommand(source As Object, e As DataListCommandEventArgs) Handles DataListBookmarks.DeleteCommand

        Dim s As String = ""
        Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

        If BmMethods.DeleteBookmark(Me.DataListBookmarks.DataKeys(e.Item.ItemIndex), s) = False Then

            Me.ShowMessage(s)

        Else

            Me.DataListBookmarks.EditItemIndex = -1
            Me.LoadData()

        End If

    End Sub

    Private Sub DataListBookmarks_EditCommand(source As Object, e As DataListCommandEventArgs) Handles DataListBookmarks.EditCommand

        Me.DataListBookmarks.EditItemIndex = e.Item.ItemIndex
        Me.LoadData()

    End Sub
    Private _LastFolder As String = String.Empty

    Private Sub DataListBookmarks_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles DataListBookmarks.ItemDataBound

        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem

                Me._Bookmark = e.Item.DataItem

                If Me._Bookmark IsNot Nothing Then

                    Dim IndicatorDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivActionBar")
                    'IndicatorDiv.Attributes.Add("class", "card-bottom-header " & Me._Bookmark.ColorIndicatorCSSClass)

                    Dim FolderNameHeader As HtmlControls.HtmlGenericControl = e.Item.FindControl("HeaderFolderName")

                    If String.IsNullOrWhiteSpace(Me._Bookmark.FolderName) = True Then

                        FolderNameHeader.Visible = False

                    Else

                        If Me._Bookmark.FolderName <> Me._LastFolder Then

                            FolderNameHeader.Visible = True
                            Me._LastFolder = Me._Bookmark.FolderName

                        Else

                            FolderNameHeader.Visible = False

                        End If

                    End If

                    If e.Item.ItemType <> ListItemType.EditItem Then

                        Dim BookmarkNameHeader As HtmlControls.HtmlGenericControl = e.Item.FindControl("HeaderBookmarkName")
                        Dim js As String = String.Empty
                        If Me._Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_AlertInbox Then

                            js = Me.HookUpCallUiAction(UI_Action.ActionType.OpenAlertInboxAsBookmark, "&url=" &
                                                                         Me.Sanitize(AdvantageFramework.Security.Encryption.ASCIIEncoding(Me._Bookmark.PageURL)))

                        Else

                            js = Me.HookUpOpenWindow("", Me._Bookmark.PageURL)

                        End If

                        js = js.Replace("return false;", "closePanel(); return false;")

                        BookmarkNameHeader.Attributes.Add("onclick", js)

                        If Me._Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.DocumentEdit Then

                            If Me._Bookmark.PageURL.Contains("doc=") = True Then

                                Dim DocumentID As String = ""
                                DocumentID = _Bookmark.PageURL.Substring(_Bookmark.PageURL.IndexOf("doc=") + 4)

                                If DocumentID <> Nothing AndAlso DocumentID <> String.Empty AndAlso IsNumeric(DocumentID) Then

                                    Dim ImageButtonDownload As ImageButton = e.Item.FindControl("ImageButtonDownload")

                                    If ImageButtonDownload IsNot Nothing Then

                                        ImageButtonDownload.Visible = True
                                        ImageButtonDownload.Attributes.Add("onclick", Me.HookUpCallUiAction(UI_Action.ActionType.GetDocumentRepositoryDocument, DocumentID))

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

        End Select
    End Sub
    Private Sub DataListBookmarks_UpdateCommand(source As Object, e As DataListCommandEventArgs) Handles DataListBookmarks.UpdateCommand

        Dim s As String = ""
        Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

        If BmMethods.UpdateBookmarkNameAndDescription(Me.DataListBookmarks.DataKeys(e.Item.ItemIndex), _
                                                      CType(e.Item.FindControl("TextBoxName"), TextBox).Text, _
                                                      CType(e.Item.FindControl("TextBoxDescription"), TextBox).Text, s) = False Then

        Else

            Me.DataListBookmarks.EditItemIndex = -1
            Me.LoadData()

        End If

    End Sub
    Private Sub ImageButtonRefreshDesktopCardsMyBookmarks_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefreshDesktopCardsMyBookmarks.Click
        Me.LoadData()
    End Sub

    Private Sub DataListBookmarks_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataListBookmarks.ItemCommand

    End Sub

#End Region

#End Region

End Class