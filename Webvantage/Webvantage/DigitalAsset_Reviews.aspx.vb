Imports Telerik.Web.UI

Public Class DigitalAsset_Reviews
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Public Const WasCsActiveKey As String = "#89w3Jyp*zp5Sj@*^3fZs"

#End Region

#Region " Enum "



#End Region

#Region " Variables "


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

    Private ReadOnly Property WasConceptShareActive As Boolean
        Get
            If Session(WasCsActiveKey) Is Nothing Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Dim WasActive As Boolean = False
                    Dim URL As String = String.Empty
                    Try

                        URL = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(AGY_SETTINGS_VALUE, '') FROM AGY_SETTINGS A WITH(NOLOCK) WHERE A.AGY_SETTINGS_CODE = 'CS_URL';").SingleOrDefault()

                    Catch ex As Exception
                        URL = String.Empty
                    End Try
                    If String.IsNullOrWhiteSpace(URL) = False AndAlso
                        URL.Contains("gotoadvantage.conceptshare.com") = True Then
                        WasActive = True
                    End If
                    Session(WasCsActiveKey) = WasActive
                    Return WasActive
                End Using
            Else
                Return CType(Session(WasCsActiveKey), Boolean)
            End If
        End Get
    End Property

    Private Property ClientCode As String
        Get
            If ViewState("ContentPage_ClientCode") IsNot Nothing Then
                Return ViewState("ContentPage_ClientCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            ViewState("ContentPage_ClientCode") = value
        End Set
    End Property
    Private Property DivisionCode As String
        Get
            If ViewState("ContentPage_DivisionCode") IsNot Nothing Then
                Return ViewState("ContentPage_DivisionCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            ViewState("ContentPage_DivisionCode") = value
        End Set
    End Property
    Private Property ProductCode As String
        Get
            If ViewState("ContentPage_ProductCode") IsNot Nothing Then
                Return ViewState("ContentPage_ProductCode")
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            ViewState("ContentPage_ProductCode") = value
        End Set
    End Property
    Private ReadOnly Property JobNumber As Integer
        Get
            Return Me.CurrentQuerystring.JobNumber
        End Get
    End Property
    Private ReadOnly Property JobComponentNumber As Integer
        Get
            Return Me.CurrentQuerystring.JobComponentNumber
        End Get
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadToolbarDigitalAssetReviews_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarDigitalAssetReviews.ButtonClick

        Select Case e.Item.Value
            Case "ConceptShareMaintenance"

                Dim q As New AdvantageFramework.Web.QueryString

                q.Page = "ProjectManagement/Proofing/FeedbackSummary"

                Me.OpenWindow(q, "ConceptShare Maintenance")

            Case "GetAssetsAndThumbnails"



            Case "Add"

                If String.IsNullOrWhiteSpace(Me.ClientCode) = True OrElse
                    String.IsNullOrWhiteSpace(Me.DivisionCode) = True OrElse
                    String.IsNullOrWhiteSpace(Me.ProductCode) = True Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)

                        If Job IsNot Nothing Then

                            Me.ClientCode = Job.ClientCode
                            Me.DivisionCode = Job.DivisionCode
                            Me.ProductCode = Job.ProductCode

                        End If

                    End Using

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "Desktop_NewAssignment"
                qs.Add("caller", "review")
                qs.Add("f", "1")
                qs.Add("jt", "1")
                qs.Add("assn", "1")

                qs.ClientCode = Me.ClientCode
                qs.DivisionCode = Me.DivisionCode
                qs.ProductCode = Me.ProductCode
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNumber

                Me.OpenWindow(qs, Title)

            Case "Refresh"

                Me.RadGridProofs.Rebind()

        End Select
    End Sub

#Region " ****************************** PROOFS ****************************** "
    Private Sub RadGridProofs_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridProofs.ItemCommand
        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
        Dim qs As New AdvantageFramework.Web.QueryString
        Dim AlertID As Integer = 0
        Dim LatestDocumentID As Integer = 0
        Dim ErrorMessage As String = String.Empty
        Dim Subject As String = String.Empty

        If index > -1 Then CurrentGridRow = DirectCast(RadGridProofs.Items(index), Telerik.Web.UI.GridDataItem)

        If CurrentGridRow IsNot Nothing Then

            Try
                AlertID = CType(CurrentGridRow.GetDataKeyValue("AlertID"), Integer)
            Catch ex As Exception
                AlertID = 0
            End Try
            Try
                LatestDocumentID = CType(CurrentGridRow.GetDataKeyValue("LatestDocumentID"), Integer)
            Catch ex As Exception
                LatestDocumentID = 0
            End Try
            Try

                Subject = CurrentGridRow("GridBoundColumnTitle").Text

            Catch ex As Exception
                Subject = "Proofing"
            End Try
            If AlertID > 0 Then

                Select Case e.CommandName
                    Case "ViewDetails"

                        qs.Page = "Desktop_AlertView"
                        qs.AlertID = AlertID
                        qs.SprintHeaderID = 0
                        qs.Add("AlertID", AlertID)
                        qs.Add("SprintID", 0)

                        Me.OpenWindow(qs, Subject)

                    Case "ProofingTool"

                        'If LatestDocumentID > 0 Then

                        If LatestDocumentID = 0 Then

                            Try

                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                                    LatestDocumentID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(MAX(DOCUMENT_ID), 0) FROM ALERT_ATTACHMENT AA WITH(NOLOCK) WHERE AA.ALERT_ID = {0};",
                                                                                               AlertID)).SingleOrDefault()

                                End Using

                            Catch ex As Exception
                            End Try

                        End If

                        qs.Page = AdvantageFramework.Web.GetProofingURL(Me.SecuritySession, AlertID, LatestDocumentID, 0, ErrorMessage)

                        Me.OpenWindow(qs, Subject)

                        'Else

                        '    ErrorMessage = "Invalid document ID."

                        'End If

                    Case "Delete"


                    Case "FeedbackSummary"


                End Select

            Else

                ErrorMessage = "Cannot get AlertID."

            End If

        Else

            'ErrorMessage = "Cannot get row."

        End If

        'If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

        '    Me.ShowMessage(ErrorMessage)

        'End If

    End Sub
    Private Sub RadGridProofs_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridProofs.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem OrElse
            e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item

            If CurrentGridRow IsNot Nothing Then

                Dim ProofingSummary As AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingSummary = Nothing

                Try

                    ProofingSummary = CType(CurrentGridRow.DataItem, AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingSummary)

                Catch ex As Exception
                    ProofingSummary = Nothing
                End Try

                If ProofingSummary IsNot Nothing Then

                    Dim DivIcon As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivIcon")
                    Dim DivThumbnail As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivThumbnail")
                    Dim RadBinaryImageThumbnail As Telerik.Web.UI.RadBinaryImage = CurrentGridRow.FindControl("RadBinaryImageThumbnail")

                    If DivIcon IsNot Nothing AndAlso RadBinaryImageThumbnail IsNot Nothing Then

                        Dim qs As New AdvantageFramework.Web.QueryString
                        Dim ClickCommand As String = String.Empty
                        qs.Page = "Desktop_AlertView"
                        qs.AlertID = ProofingSummary.AlertID

                        ClickCommand = "OpenRadWindow('','" & qs.ToString(True) & "',,);return false;"

                        If ProofingSummary.LatestThumbnail IsNot Nothing AndAlso ProofingSummary.LatestThumbnail.Length > 0 Then

                            DivIcon.Visible = False
                            DivThumbnail.Visible = True

                            RadBinaryImageThumbnail.DataValue = ProofingSummary.LatestThumbnail
                            RadBinaryImageThumbnail.DataBind()
                            RadBinaryImageThumbnail.Visible = True

                            'Click action
                            DivThumbnail.Attributes.Add("onclick", ClickCommand)

                        Else

                            DivIcon.Visible = True
                            DivThumbnail.Visible = False
                            RadBinaryImageThumbnail.Visible = False

                            'Click action
                            DivIcon.Attributes.Add("onclick", ClickCommand)

                        End If

                    End If

                End If

            End If

        End If
    End Sub
    Private Sub RadGridProofs_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridProofs.NeedDataSource

        If cApplication.IsProofingToolActive(Me.SecuritySession) = True Then

            Dim ProofingSummaries As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingSummary) = Nothing
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                ProofingSummaries = AdvantageFramework.Proofing.LoadProofingListByJob(DbContext, JobNumber, JobComponentNumber,
                                                                                      Me.CheckBoxProofingShowCompleted.Checked, ErrorMessage)

            End Using

            Me.RadGridProofs.DataSource = ProofingSummaries

        Else

            Me.RadGridProofs.Visible = False

        End If

    End Sub
    'Private _Controller As AdvantageFramework.Controller.Dashboard.DashboardController = Nothing
    'Public Function GetCards(ByVal GroupBy As String, ByVal Search As String,
    '                         ByVal PageSize As Integer, ByVal PageNumber As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup)

    '    If _Controller Is Nothing Then

    '        _Controller = New AdvantageFramework.Controller.Dashboard.DashboardController(Me.SecuritySession)

    '    End If

    '    Dim CardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
    '    Dim Cards As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.Card) = Nothing
    '    Dim ReturnCardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
    '    Dim ReturnCardGroup As AdvantageFramework.DTO.Desktop.Dashboard.CardGroup = Nothing
    '    Dim ReturnObject As Object = Nothing
    '    Dim AlertCount As Integer = 0
    '    Dim AssignmentCount As Integer = 0
    '    Dim ReviewCount As Integer = 0

    '    CardGroups = _Controller.GetDashboardCardGroups(3,
    '                                                    GroupBy,
    '                                                    Search,
    '                                                    MiscFN.IsClientPortal,
    '                                                    PageSize,
    '                                                    PageNumber,
    '                                                    AssignmentCount,
    '                                                    AlertCount,
    '                                                    ReviewCount)

    '    Cards = New Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.Card)

    '    ReturnCardGroups = New Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup)

    '    For Each CardGroup In CardGroups

    '        If CardGroup.Cards IsNot Nothing AndAlso CardGroup.Cards.Count > 0 Then

    '            Cards.AddRange(CardGroup.Cards.ToList)

    '            ReturnCardGroup = New AdvantageFramework.DTO.Desktop.Dashboard.CardGroup
    '            ReturnCardGroup.Key = CardGroup.Key

    '            ReturnCardGroup.Cards = CardGroup.Cards

    '            ReturnCardGroups.Add(ReturnCardGroup)

    '        End If

    '    Next

    '    Return ReturnCardGroups

    'End Function

#End Region

#End Region
#Region " Page "

    Private Sub DigitalAsset_Reviews_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

        Try

            Me.InitConceptShare()

            Try

                Me.RadToolbarDigitalAssetReviews.FindItemByValue("RadToolBarSeparatorGetAssetsAndThumbnails").Visible = False
                Me.RadToolbarDigitalAssetReviews.FindItemByValue("ConceptShareMaintenance").Visible = False
                'Me.RadToolbarDigitalAssetReviews.FindItemByValue("GetAssetsAndThumbnails").Visible = False
                'Me.RadToolbarDigitalAssetReviews.FindItemByValue("RefreshGetAssetsAndThumbnails").Visible = False

            Catch ex As Exception
            End Try

        Catch ex As Exception
            Me.DivConceptShare.Visible = False
        End Try
        Try

            If cApplication.IsProofingToolActive(Me._Session) = False OrElse MiscFN.IsClientPortal = True Then

                Me.RadToolbarDigitalAssetReviews.FindItemByValue("Add").Visible = False

            Else

                Me.RadToolbarDigitalAssetReviews.FindItemByValue("Add").Visible = True

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub DigitalAsset_Reviews_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub
    Private Sub DigitalAsset_Reviews_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        ''Deep link removed
        'Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
        'Deep.BuildJavascriptFromQueryString(Me.CurrentQuerystring, WebvantageLink, ClientPortalLink)
        'Me.RadToolbarDigitalAssetReviews.Visible = Deep.ClientPortalVisible
        'If Me.IsClientPortal = True Then

        '    Me.RadToolbarDigitalAssetReviews.FindItemByValue("WvPermaLink").Visible = False
        '    Me.RadToolbarDigitalAssetReviews.FindItemByValue("CpPermaLink").Visible = False

        'End If

    End Sub

#End Region

#End Region

#Region " ConceptShare "

    Private Sub InitConceptShare()

        DivConceptShare.Visible = Me.WasConceptShareActive

    End Sub
    Private Sub RadGridDigitalAssetReviews_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridDigitalAssetReviews.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
        Dim qs As New AdvantageFramework.Web.QueryString
        Dim AlertID As Integer = 0
        Dim LatestDocumentID As Integer = 0
        Dim ErrorMessage As String = String.Empty
        Dim Subject As String = String.Empty

        If index > -1 Then CurrentGridRow = DirectCast(RadGridDigitalAssetReviews.Items(index), Telerik.Web.UI.GridDataItem)

        If CurrentGridRow IsNot Nothing Then

            Try

                AlertID = CType(CurrentGridRow.GetDataKeyValue("ID"), Integer)

            Catch ex As Exception
                AlertID = 0
            End Try

            If AlertID > 0 Then

                Select Case e.CommandName
                    Case "ViewDetails"

                        qs.Page = "Desktop_AlertView"
                        qs.AlertID = AlertID
                        qs.SprintHeaderID = 0
                        qs.Add("AlertID", AlertID)
                        qs.Add("SprintID", 0)

                        Me.OpenWindow(qs, Subject)
                End Select

            End If

        End If

    End Sub
    Private Sub RadGridDigitalAssetReviews_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridDigitalAssetReviews.ItemDataBound
        Try

            Select Case e.Item.ItemType
                Case GridItemType.Header

                Case GridItemType.Item, GridItemType.AlternatingItem

                    Dim CurrentRow As GridDataItem = CType(e.Item, GridDataItem)
                    Dim AlertRecord As AdvantageFramework.Database.Entities.Alert = Nothing

                    If CurrentRow IsNot Nothing Then

                        AlertRecord = e.Item.DataItem

                        If AlertRecord IsNot Nothing Then

                            Dim ViewDetailsDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivViewDetails")
                            Dim DeleteDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivDeleteReview")

                            ViewDetailsDiv.Visible = True

                            Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton
                            DeleteImageButton = CType(e.Item.FindControl("ImageButtonDelete"), ImageButton)

                            If Not DeleteImageButton Is Nothing Then

                                If Me.IsClientPortal = True Then
                                    DeleteDiv.Visible = False
                                End If

                                DeleteImageButton.Attributes("onclick") = "return confirm('Are you sure you want to delete this Version?')"

                            End If

                            Dim CompletedLabel As Label
                            CompletedLabel = CType(e.Item.FindControl("LabelCompleted"), Label)

                            If CompletedLabel IsNot Nothing Then

                                Dim ConceptShareNumberOfApprovedReviewers As Integer = 0
                                Dim ConceptShareNumberOfRejectedReviewers As Integer = 0
                                Dim ConceptShareNumberOfDeferredReviewers As Integer = 0
                                Dim CompletedText As String = String.Empty

                                If AlertRecord.AssignmentCompleted IsNot Nothing AndAlso AlertRecord.AssignmentCompleted = True Then

                                    CompletedLabel.Text = "Completed"

                                Else

                                    CompletedLabel.Text = "Not Completed"
                                End If

                                If AlertRecord.ConceptShareNumberOfApprovedReviewers IsNot Nothing Then ConceptShareNumberOfApprovedReviewers = AlertRecord.ConceptShareNumberOfApprovedReviewers
                                If AlertRecord.ConceptShareNumberOfRejectedReviewers IsNot Nothing Then ConceptShareNumberOfRejectedReviewers = AlertRecord.ConceptShareNumberOfRejectedReviewers
                                If AlertRecord.ConceptShareNumberOfDeferredReviewers IsNot Nothing Then ConceptShareNumberOfDeferredReviewers = AlertRecord.ConceptShareNumberOfDeferredReviewers

                                CompletedLabel.ToolTip = String.Format("{0} Approved, {1} Rejected, {2} Deferred",
                                                                        ConceptShareNumberOfApprovedReviewers,
                                                                        ConceptShareNumberOfRejectedReviewers,
                                                                        ConceptShareNumberOfDeferredReviewers)

                            End If

                        End If

                    End If

                Case GridItemType.Footer

            End Select

        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadGridDigitalAssetReviews_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridDigitalAssetReviews.NeedDataSource

        If Me.WasConceptShareActive = True Then

            Dim Alerts As Generic.List(Of AdvantageFramework.Database.Entities.Alert) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Alerts = AdvantageFramework.Database.Procedures.Alert.LoadConceptShareAlertsForJob(DbContext,
                                                                                                   Me.JobNumber,
                                                                                                   Me.JobComponentNumber).ToList()

                End Using

            Catch ex As Exception
                Alerts = Nothing
            End Try

            If Alerts IsNot Nothing AndAlso Alerts.Count > 0 Then

                Me.DivConceptShare.Visible = True
                Me.RadGridDigitalAssetReviews.DataSource = Alerts

            Else

                Me.DivConceptShare.Visible = False

            End If

        End If

    End Sub
    Private Sub CheckBoxProofingShowCompleted_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProofingShowCompleted.CheckedChanged

        Me.RadGridProofs.Rebind()

    End Sub

#End Region
End Class
