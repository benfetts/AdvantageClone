Imports Telerik.Web.UI

Public Class Alert_DigitalAssetReview_Comment
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ConceptShareComment As AdvantageFramework.ConceptShareAPI.Comment
    Private _ConceptShareCommentReplies As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread)
    Private _ConceptShareCommentMarkupImage As Byte()

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
    Private ReadOnly Property EmployeeTimezoneOffset As Decimal
        Get
            Return cEmployee.GetTimeZoneOffset(True)
        End Get
    End Property
    'Private Property ProjectID As Integer
    '    Get
    '        If ViewState("ProjectID") Is Nothing Then ViewState("ProjectID") = 0
    '        Return CType(ViewState("ProjectID"), Integer)
    '    End Get
    '    Set(value As Integer)
    '        ViewState("ProjectID") = value
    '    End Set
    'End Property
    'Private Property ReviewID As Integer
    '    Get
    '        If ViewState("ReviewID") Is Nothing Then ViewState("ReviewID") = 0
    '        Return CType(ViewState("ReviewID"), Integer)
    '    End Get
    '    Set(value As Integer)
    '        ViewState("ReviewID") = value
    '    End Set
    'End Property
    'Private Property CommentID As Integer
    '    Get
    '        If ViewState("CommentID") Is Nothing Then ViewState("CommentID") = 0
    '        Return CType(ViewState("CommentID"), Integer)
    '    End Get
    '    Set(value As Integer)
    '        ViewState("CommentID") = value
    '    End Set
    'End Property
    Private ReadOnly Property ProjectID As Integer
        Get
            Return Me.CurrentQuerystring.ConceptShareProjectID
        End Get
    End Property
    Private ReadOnly Property ReviewID As Integer
        Get
            Return Me.CurrentQuerystring.ConceptShareReviewID
        End Get
    End Property
    Private ReadOnly Property AssetID As Integer
        Get
            Return Me.CurrentQuerystring.ConceptShareAssetID
        End Get
    End Property
    Private ReadOnly Property CommentID As Integer
        Get
            Return Me.CurrentQuerystring.ConceptShareCommentID
        End Get
    End Property


#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ButtonAddReply_Click(sender As Object, e As EventArgs) Handles ButtonAddReply.Click

        If String.IsNullOrWhiteSpace(Me.TextBoxAddReply.Text) = False Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            'If Me.IsClientPortal = False Then

            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            'Else

            '    ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            'End If

            If ConceptShareConnection IsNot Nothing Then

                If AdvantageFramework.ConceptShare.AddCommentReply(ConceptShareConnection, Me.CommentID, False, Me.TextBoxAddReply.Text) IsNot Nothing Then

                    Me.TextBoxAddReply.Text = ""
                    Me.LoadComment()

                End If

            End If

        Else

            Me.ShowMessage("Please enter reply text")

        End If

    End Sub

#End Region
#Region " Page "

    Private Sub Alert_DigitalAssetReview_Comment_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub
    Private Sub Alert_DigitalAssetReview_Comment_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.LoadComment()

        End If

    End Sub
    Private Sub Alert_DigitalAssetReview_Comment_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub

#End Region

    Private Sub LoadComment()

        Me._ConceptShareComment = Nothing
        Me._ConceptShareCommentReplies = Nothing
        Me._ConceptShareCommentMarkupImage = Nothing

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing
        If Me.IsClientPortal = False Then

            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        Else

            ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

        End If

        If ConceptShareConnection IsNot Nothing Then

            If AdvantageFramework.ConceptShare.LoadFullComment(ConceptShareConnection, Me.ProjectID, Me.ReviewID, Me.AssetID, Me.CommentID,
                                                                       Me._ConceptShareComment, Me._ConceptShareCommentReplies, Me._ConceptShareCommentMarkupImage) = True Then

                Me.ImageMarkup.ImageUrl = AdvantageFramework.ConceptShare.ByteArrayImageToImageURL(Me._ConceptShareCommentMarkupImage)

                Me.LabelComment.Text = Me._ConceptShareComment.CommentData
                Me.LabelCommentBy.Text = Me._ConceptShareComment.CreatedByName & " @ " & DateAdd(DateInterval.Hour, Me.EmployeeTimezoneOffset, CType(Me._ConceptShareComment.DateCreated, DateTime))
                Me.RadGridReplies.DataSource = Me._ConceptShareCommentReplies
                Me.RadGridReplies.DataBind()

            End If

        End If


    End Sub

    Private Sub RadGridReplies_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridReplies.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.Header
            Case GridItemType.Item, GridItemType.AlternatingItem

                Dim CurrentRow As GridDataItem = CType(e.Item, GridDataItem)

                If CurrentRow IsNot Nothing Then

                    Dim CommentThread As AdvantageFramework.ConceptShareAPI.CommentThread = Nothing
                    Try

                        CommentThread = e.Item.DataItem

                    Catch ex As Exception
                        CommentThread = Nothing
                    End Try

                    If CommentThread IsNot Nothing Then

                        Dim CreatedDateLabel As Label = CurrentRow.FindControl("LabelCreatedDate")
                        Try

                            If CreatedDateLabel IsNot Nothing AndAlso IsDate(CommentThread.CreatedDate) = True Then

                                CreatedDateLabel.Text = DateAdd(DateInterval.Hour, Me.EmployeeTimezoneOffset, CType(CommentThread.CreatedDate, DateTime))

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                End If
        End Select

    End Sub

#End Region

End Class