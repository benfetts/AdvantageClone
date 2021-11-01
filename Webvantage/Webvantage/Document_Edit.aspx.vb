Imports Telerik.Web.UI

Public Class Document_Edit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DocumentID As Integer = 0
    Private _Document As AdvantageFramework.Database.Entities.Document
    Private _DocumentLabels As Generic.List(Of AdvantageFramework.Database.Entities.LabelDocument)

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadToolbarDocumentInfo_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarDocumentInfo.ButtonClick

        Select Case e.Item.Value
            Case "Save"
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me._Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, Me._DocumentID)

                    If Me._Document IsNot Nothing Then

                        Me._Document.Description = Me.TextBoxDescription.Text
                        Me._Document.Keywords = Me.TextBoxKeywords.Text
                        Me._Document.DocumentTypeID = Me.RadComboBoxDocumentType.SelectedItem.Value

                        If AdvantageFramework.Database.Procedures.Document.Update(DbContext, Me._Document) = True Then

                            Me.CloseThisWindow()

                        End If

                        'Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        '    Me._DocumentLabels = AdvantageFramework.Database.Procedures.LabelDocument.LoadByDocumentID(dc, Me._DocumentID)

                        'End Using

                    End If

                End Using

            Case "Download"

                Me.DeliverFile(Me._DocumentID)

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                b.Name = "Document: " & Me.LabelFilename.Text

                With qs

                    .Add("bm", "1")
                    .DocumentID = Me._DocumentID

                End With

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.DocumentEdit
                    .UserCode = Session("UserCode")
                    .PageURL = "Document_Edit.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

            Case "Cancel"

                Me.CloseThisWindow()

        End Select

    End Sub

#End Region
#Region " Page "

    Private Sub Document_Edit_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Me.CurrentQuerystring.DocumentID > 0 Then Me._DocumentID = Me.CurrentQuerystring.DocumentID

    End Sub
    Private Sub Document_Edit_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.RadToolbarDocumentInfo.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks
            AdvantageFramework.Web.Presentation.Controls.RadComboBoxLoadDocumentTypeList(Me._Session, Me.RadComboBoxDocumentType)

            Me.ImageButtonEditLabels.Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_Documents, False) = 1

            If Me._DocumentID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me._Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, Me._DocumentID)

                    If Me._Document IsNot Nothing Then

                        If Me._Document.FileName IsNot Nothing Then Me.LabelFilename.Text = Me._Document.FileName
                        If Me._Document.Description IsNot Nothing Then Me.TextBoxDescription.Text = Me._Document.Description
                        If Me._Document.Keywords IsNot Nothing Then Me.TextBoxKeywords.Text = Me._Document.Keywords
                        If Me._Document.DocumentTypeID IsNot Nothing Then MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDocumentType, Me._Document.DocumentTypeID, False, True)

                    End If

                End Using

                Me.UserControlDocumentLabelTree.DocumentID = Me._DocumentID
                Me.UserControlDocumentLabelTree.LoadLabels()
                Me.UserControlDocumentLabelTree.LoadExistingLabelsForDocument()

            End If

        End If

    End Sub

#End Region

#End Region

End Class
