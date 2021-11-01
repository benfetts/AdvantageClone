Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class Alert_DigitalAssetReview_AddReviewer
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum PageTypes

        Add = 0
        ReOrder = 1

    End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property JobNumber As Integer
        Get
            If ViewState("JobNumber") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("JobNumber"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("JobNumber") = value
        End Set
    End Property
    Private Property JobComponentNumber As Short
        Get
            If ViewState("JobComponentNumber") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("JobComponentNumber"), Short)
            End If
        End Get
        Set(value As Short)
            ViewState("JobComponentNumber") = value
        End Set
    End Property
    Private Property ConceptShareProjectID As Integer
        Get
            If ViewState("ConceptShareProjectID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("ConceptShareProjectID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("ConceptShareProjectID") = value
        End Set
    End Property
    Private Property ConceptShareReviewID As Integer
        Get
            If ViewState("ConceptShareReviewID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("ConceptShareReviewID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("ConceptShareReviewID") = value
        End Set
    End Property
    Private Property AlertID As Integer
        Get
            If ViewState("AlertID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("AlertID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("AlertID") = value
        End Set
    End Property
    Private Property PageType As PageTypes
        Get
            If ViewState("PageType") Is Nothing Then
                Return PageTypes.Add
            Else
                Return CType(CType(ViewState("PageType"), Integer), PageTypes)
            End If
        End Get
        Set(value As PageTypes)
            ViewState("PageType") = CType(value, Integer).ToString
        End Set
    End Property
    Private Property SelectedAlertGroup As String
        Get
            If ViewState("SelectedAlertGroup") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("SelectedAlertGroup")
            End If
        End Get
        Set(value As String)
            ViewState("SelectedAlertGroup") = value
        End Set
    End Property
    Private Property DefaultAlertGroup As String
        Get
            If ViewState("DefaultAlertGroup") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("DefaultAlertGroup")
            End If
        End Get
        Set(value As String)
            ViewState("DefaultAlertGroup") = value
        End Set
    End Property
    Private Property IncludeAlertGroupsInPromptWindow As Boolean
        Get
            If ViewState("IncludeAlertGroupsInPromptWindow") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("IncludeAlertGroupsInPromptWindow"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("IncludeAlertGroupsInPromptWindow") = value
        End Set
    End Property
#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadToolbarAddReviewer_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarAddReviewer.ButtonClick

        Dim ErrorMessage As String = String.Empty

        Select Case e.Item.Value
            Case "SelectAll"

                For Each item As RadListBoxItem In Me.RadListBoxReviewers.Items

                    If item.Enabled = True Then

                        item.Selected = True

                    End If

                Next

            Case "Save"

                Select Case Me.PageType
                    Case PageTypes.Add

                        Me.Save(ErrorMessage)

                    Case PageTypes.ReOrder

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Dim SQL As String = String.Empty
                            Dim i As Integer = 0
                            Dim EmployeeCode As String = String.Empty

                            For Each Item As RadListBoxItem In Me.RadListBoxReviewers.Items

                                i += 1
                                SQL = String.Empty
                                EmployeeCode = String.Empty

                                Try

                                    EmployeeCode = Item.Value

                                Catch ex As Exception
                                    EmployeeCode = String.Empty
                                End Try

                                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                                    SQL = String.Format("UPDATE ALERT_RCPT SET ALERT_RCPT_ID = 0321 WHERE ALERT_ID = {0} AND ALERT_RCPT_ID ={1};", Me.AlertID, i)
                                    SQL &= String.Format("UPDATE ALERT_RCPT SET ALERT_RCPT_ID = {0} WHERE ALERT_ID = {1} AND EMP_CODE = '{2}';", i, Me.AlertID, EmployeeCode)

                                    Try

                                        DbContext.Database.ExecuteSqlCommand(SQL)

                                    Catch ex As Exception
                                    End Try

                                End If

                            Next

                        End Using

                        ReloadReviewPage()

                End Select

            Case "Cancel"

                Me.CloseThisWindow()

        End Select

    End Sub

    Private Sub RadComboBoxAlertGroups_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAlertGroups.SelectedIndexChanged

        Try

            Me.SelectedAlertGroup = Me.RadComboBoxAlertGroups.SelectedValue

        Catch ex As Exception
            Me.SelectedAlertGroup = String.Empty
        End Try

        Me.LoadReviewersForAdd()

    End Sub

#End Region
#Region " Page "

    Private Sub Alert_DigitalAssetReview_AddReviewer_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

        If cApplication.IsProofingToolActive(Me.SecuritySession) = False Then

            Me.ShowMessage("Advantage Proofing not enabled")
            Me.CloseThisWindow()

        End If

        If Me.CurrentQuerystring.AlertID > 0 Then Me.AlertID = Me.CurrentQuerystring.AlertID
        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.ConceptShareProjectID > 0 Then Me.ConceptShareProjectID = Me.CurrentQuerystring.ConceptShareProjectID
        If Me.CurrentQuerystring.ConceptShareReviewID > 0 Then Me.ConceptShareReviewID = Me.CurrentQuerystring.ConceptShareReviewID

        Try

            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.GetValue("loie")) = False AndAlso
                IsNumeric(Me.CurrentQuerystring.GetValue("loie")) Then

                Me.PageType = CType(CType(Me.CurrentQuerystring.GetValue("loie"), Integer), PageTypes)

            End If

        Catch ex As Exception
            Me.PageType = PageTypes.Add
        End Try

    End Sub
    Private Sub Alert_DigitalAssetReview_AddReviewer_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Select Case Me.PageType
                Case PageTypes.Add

                    Me.LoadAlertGroups()
                    Me.LoadReviewersForAdd()
                    Me.DivAlertGroups.Visible = True

                Case PageTypes.ReOrder

                    Me.LoadReviewersForReOrder()
                    Me.DivAlertGroups.Visible = False
                    Me.Page.Title = "Reorder"

            End Select

        End If

    End Sub
    Private Sub Alert_DigitalAssetReview_AddReviewer_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub

#End Region

    Private Sub LoadReviewersForReOrder()

        Me.RadToolbarAddReviewer.FindItemByValue("SelectAll").Visible = False

        Me.RadListBoxReviewers.Items.Clear()
        Me.RadListBoxReviewers.AllowReorder = True
        Me.RadListBoxReviewers.SelectionMode = ListBoxSelectionMode.Multiple
        Me.RadListBoxReviewers.EnableDragAndDrop = True

        If Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing

            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)


                    Dim ReviewMembers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

                    ReviewMembers = Nothing

                    Try

                        ReviewMembers = ConceptShareConnection.APIServiceClient.GetReviewMemberList(ConceptShareConnection.APIContext, Me.ConceptShareReviewID).ToList

                    Catch ex As Exception
                        ReviewMembers = Nothing
                    End Try

                    If ReviewMembers IsNot Nothing Then

                        Dim ConceptShareReviewers As Generic.List(Of AdvantageFramework.ConceptShare.Classes.Reviewer)
                        Dim ConceptShareEmployees As Generic.List(Of ConceptShareSession.ConceptShareEmployee)

                        Dim WebCS As New ConceptShareSession(_Session)

                        WebCS.LoadConceptShareReviewers()
                        WebCS.LoadConceptShareEmployees()

                        ConceptShareReviewers = Nothing
                        ConceptShareEmployees = Nothing

                        ConceptShareReviewers = WebCS.Reviewers
                        ConceptShareEmployees = WebCS.Employees

                        Me.RadListBoxReviewers.DataSource = (From Entity In ReviewMembers
                                                             Join Reviewer In ConceptShareReviewers On Entity.ReferenceId Equals Reviewer.ConceptShareUserID
                                                             Join Employee In ConceptShareEmployees On Entity.ReferenceId Equals Employee.ConceptShareUserID
                                                             Join AlertRecipient In DbContext.AlertRecipients On Employee.EmployeeCode Equals AlertRecipient.EmployeeCode
                                                             Where Entity.ExternalReviewer = False And
                                                                   AlertRecipient.AlertID = Me.AlertID
                                                             Select New With {.Id = Entity.Id,
                                                                              .ConceptShareUserID = Entity.ReferenceId,
                                                                              .FullName = Reviewer.FullName,
                                                                              .Picture = Reviewer.Picture,
                                                                              .Status = Entity.StatusName,
                                                                              .StatusID = Entity.StatusId,
                                                                              .EmployeeCode = Reviewer.EmployeeCode,
                                                                              .IsEmployee = Reviewer.IsEmployee,
                                                                              .SortOrder = AlertRecipient.ID,
                                                                              .IsCurrentReviewer = IIf(AlertRecipient.IsCurrentNotify IsNot Nothing AndAlso AlertRecipient.IsCurrentNotify = 1, True, False)}).ToList.OrderBy(Function(MyData) MyData.SortOrder)


                        Me.RadListBoxReviewers.DataValueField = "EmployeeCode"
                        Me.RadListBoxReviewers.DataTextField = "FullName"
                        Me.RadListBoxReviewers.DataBind()

                    End If

                End Using

            End If

        End If

    End Sub
    Private Sub LoadReviewersForAdd()

        Me.RadToolbarAddReviewer.FindItemByValue("SelectAll").Visible = True

        Me.RadListBoxReviewers.Items.Clear()

        Me.RadListBoxReviewers.AllowReorder = False
        Me.RadListBoxReviewers.SelectionMode = ListBoxSelectionMode.Multiple
        Me.RadListBoxReviewers.EnableDragAndDrop = False

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me.RadListBoxReviewers.DataSource = SqlHelper.ExecuteDataTable(HttpContext.Current.Session("ConnString"),
                                                                               CommandType.StoredProcedure,
                                                                               "usp_wv_AutoCompleteRecipientsLoad",
                                                                               "DtData",
                                                                               New SqlParameter("@CL_CODE", ""),
                                                                               New SqlParameter("@DIV_CODE", ""),
                                                                               New SqlParameter("@PRD_CODE", ""),
                                                                               New SqlParameter("@JOB_NUMBER", 0),
                                                                               New SqlParameter("@JOB_COMPONENT_NBR", 0),
                                                                               New SqlParameter("@CMP_IDENTIFIER", 0),
                                                                               New SqlParameter("@CLIENT_PORTAL_USER_ID", 0),
                                                                               New SqlParameter("@ALERT_ID", Me.AlertID),
                                                                               New SqlParameter("@USER_CODE", HttpContext.Current.Session("UserCode")),
                                                                               New SqlParameter("@IS_REVIEWERS", True),
                                                                               New SqlParameter("@EMAIL_GR_CODE", Me.SelectedAlertGroup)
                                                                               )

            Me.RadListBoxReviewers.DataValueField = "ConceptShareUserID"
            Me.RadListBoxReviewers.DataTextField = "FullName"
            Me.RadListBoxReviewers.DataBind()

        End Using

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing
        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        If ConceptShareConnection IsNot Nothing Then

            Dim ReviewMembers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
            Dim Reviewers As Generic.List(Of AdvantageFramework.ConceptShare.Classes.Reviewer)

            ReviewMembers = Nothing
            Reviewers = Nothing

            ReviewMembers = AdvantageFramework.ConceptShare.LoadReviewMembersByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

            If ReviewMembers IsNot Nothing Then

                Dim ListItem As RadListBoxItem

                For Each ReviewMember As AdvantageFramework.ConceptShareAPI.ReviewMember In ReviewMembers

                    ListItem = Nothing
                    ListItem = Me.RadListBoxReviewers.FindItemByValue(ReviewMember.ReferenceId)

                    If ListItem IsNot Nothing Then

                        Me.RadListBoxReviewers.Items.Remove(ListItem)

                    Else

                        'If ReviewMember.ExternalReviewer = False Then

                        '    ListItem = New RadListBoxItem

                        '    ListItem.Text = ReviewMember.Name
                        '    ListItem.Value = ReviewMember.ReferenceId

                        '    ListItem.Enabled = False

                        '    Me.RadListBoxReviewers.Items.Add(ListItem)

                        'End If

                    End If

                Next

            End If

        End If

        If Me.DefaultAlertGroup = Me.SelectedAlertGroup Then

            For Each Item As RadListBoxItem In Me.RadListBoxReviewers.Items

                If Item.Text.Contains("CC") = False Then

                    Item.Selected = True

                End If

            Next

        End If

    End Sub
    Private Sub ReloadReviewPage()

        Dim qs As New AdvantageFramework.Web.QueryString

        qs.Page = "Alert_DigitalAssetReview.aspx"
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNumber
        qs.ConceptShareProjectID = Me.ConceptShareProjectID
        qs.ConceptShareReviewID = Me.ConceptShareReviewID

        'Me.RefreshCaller(qs.ToString(True), True, True, False)

        Me.CloseThisWindowAndRefreshCaller(qs.ToString(True), True, True)

    End Sub
    Private Sub LoadAlertGroups()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me.RadComboBoxAlertGroups.Items.Clear()
            Me.RadComboBoxAlertGroups.Items.Add(New RadComboBoxItem("[Please select]", ""))

            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If JobComponent IsNot Nothing AndAlso String.IsNullOrEmpty(JobComponent.AlertGroupCode) = False Then

                Me.SelectedAlertGroup = JobComponent.AlertGroupCode
                Me.DefaultAlertGroup = JobComponent.AlertGroupCode

            End If
            If Agency IsNot Nothing AndAlso Agency.IncludeAlertGroups IsNot Nothing AndAlso Agency.IncludeAlertGroups = 1 Then

                Me.IncludeAlertGroupsInPromptWindow = True

            End If

            If Me.IncludeAlertGroupsInPromptWindow = True Then

                Dim AlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup)

                AlertGroups = Nothing
                AlertGroups = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActiveDistinctAlertGroups(DbContext).ToList

                If AlertGroups IsNot Nothing AndAlso AlertGroups.Count > 0 Then

                    For Each AlertGroup As AdvantageFramework.Database.Entities.AlertGroup In AlertGroups

                        Me.RadComboBoxAlertGroups.Items.Add(New RadComboBoxItem(AlertGroup.Code, AlertGroup.Code))

                    Next
                    If String.IsNullOrWhiteSpace(Me.SelectedAlertGroup) = False Then

                        Try

                            Dim DefaultGroup As RadComboBoxItem = Me.RadComboBoxAlertGroups.FindItemByValue(Me.SelectedAlertGroup)

                            If DefaultGroup IsNot Nothing Then

                                DefaultGroup.Text = DefaultGroup.Text & "*"
                                DefaultGroup.Selected = True

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                    Me.RadComboBoxAlertGroups.Enabled = True

                Else

                    Me.RadComboBoxAlertGroups.Enabled = False

                End If

            Else

                Me.RadComboBoxAlertGroups.Visible = False

            End If

        End Using

    End Sub
    Private Sub Save(ByRef ErrorMessage)

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
        Dim ReviewerAdded As Boolean = False

        ConceptShareConnection = Nothing
        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        If ConceptShareConnection IsNot Nothing Then

            Dim Review As AdvantageFramework.ConceptShareAPI.Review
            Dim ReviewMembers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
            Dim ReviewMember As AdvantageFramework.ConceptShareAPI.ReviewMember
            Dim NewReviewerIDs As New Generic.List(Of Integer)

            Review = Nothing
            Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, ErrorMessage)

            If Review IsNot Nothing Then

                Dim a As New cAlerts()
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim EmployeeCodesAdded As New Generic.List(Of String)
                    Dim ClientContactIdsAdded As New Generic.List(Of Integer)
                    Dim CurrentAlert As New Alert
                    Dim CurrentAlertLoaded As Boolean = False
                    Dim EmployeeCode As String = String.Empty
                    Dim ClientContactID As Integer = 0

                    CurrentAlertLoaded = CurrentAlert.LoadByPrimaryKey(Me.AlertID)

                    For Each Item As RadListBoxItem In Me.RadListBoxReviewers.Items

                        If Item.Enabled = True AndAlso (Item.Selected = True OrElse Item.Checked = True) Then

                            EmployeeCode = String.Empty
                            ClientContactID = 0

                            If Item.Text.Contains("CC") = True AndAlso IsNumeric(Item.Value) Then

                                Try

                                    ClientContactID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 ISNULL(CDP_CONTACT_ID, 0) FROM CP_USER WITH(NOLOCK) WHERE CS_USERID = {0}", Item.Value)).SingleOrDefault

                                Catch ex As Exception
                                    ClientContactID = 0
                                End Try

                                If ClientContactID > 0 Then

                                    If CurrentAlert.AlertCPCheckForDuplicates(Me.AlertID, ClientContactID) = False Then

                                        ClientContactIdsAdded.Add(ClientContactID)
                                        CurrentAlert.AddAlertRecipientCC(ClientContactID, True)
                                        AdvantageFramework.ConceptShare.AddUpdateReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, Item.Value)
                                        ReviewerAdded = True

                                    End If

                                End If

                            Else

                                Try

                                    EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 ISNULL(EMP_CODE, '') FROM EMPLOYEE WHERE CS_USERID = {0}", Item.Value)).SingleOrDefault

                                Catch ex As Exception
                                    EmployeeCode = String.Empty
                                End Try

                                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                                    If CurrentAlert.AlertCheckForDuplicates(Me.AlertID, EmployeeCode) = False Then

                                        EmployeeCodesAdded.Add(EmployeeCode)
                                        If CurrentAlert.AddAlertRecipient(EmployeeCode, True) = True Then

                                            AdvantageFramework.ConceptShare.AddUpdateReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, Item.Value)
                                            ReviewerAdded = True

                                            Dim ThisRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                                            ThisRecipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, Me.AlertID, EmployeeCode)

                                            If ThisRecipient IsNot Nothing Then

                                                ThisRecipient.IsConceptShareReviewer = 1
                                                ThisRecipient.IsCurrentNotify = 1

                                                AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, ThisRecipient)

                                            End If
                                            If EmployeeCode = HttpContext.Current.Session("EmpCode") Then

                                                Me.RefreshAlertWindows(False)

                                            Else

                                                ''Webvantage.SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(EmployeeCode, _Session.ConnectionString, _Session.UserCode)

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    Next

                End Using

            End If

        End If

        If ReviewerAdded = True Then

            'LoadReviewersForAdd()
            ReloadReviewPage()
            'Me.CloseThisWindowAndRefreshCaller("Alert_DigitalAssetReview.aspx")

        Else

            Me.CloseThisWindow()

        End If

    End Sub

#End Region

End Class
