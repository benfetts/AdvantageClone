Imports Telerik.Web.UI
Imports Webvantage.cGlobals
Public Class LookUp_EmailRecipients
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _FromNewAlertPage As Boolean = False
    Private _FromReview As Boolean = False
    Private _PurchaseOrderReferenceID As Integer = 0

    Private _LabelFullName As System.Web.UI.WebControls.Label
    Private _LabelEmailAddress As System.Web.UI.WebControls.Label
    Private _LabelCode As System.Web.UI.WebControls.Label
    Private _RadListBoxItem As Telerik.Web.UI.RadListBoxItem

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
    Private Property _JobNumber As Integer
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
    Private Property _JobComponentNumber As Short
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

    Public Property ClientCode As String
        Get
            If ViewState("ClientCode") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ClientCode")
            End If
        End Get
        Set(value As String)
            ViewState("ClientCode") = value
        End Set
    End Property
    Public Property DivisionCode As String
        Get
            If ViewState("DivisionCode") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("DivisionCode")
            End If
        End Get
        Set(value As String)
            ViewState("DivisionCode") = value
        End Set
    End Property
    Public Property ProductCode As String
        Get
            If ViewState("ProductCode") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ProductCode")
            End If
        End Get
        Set(value As String)
            ViewState("ProductCode") = value
        End Set
    End Property

    Private Property JobInformation As AdvantageFramework.ConceptShare.Classes.JobInfo
        Get
            If ViewState("JobInformation") Is Nothing Then
                Return Nothing
            Else
                Return CType(ViewState("JobInformation"), AdvantageFramework.ConceptShare.Classes.JobInfo)
            End If
        End Get
        Set(value As AdvantageFramework.ConceptShare.Classes.JobInfo)
            ViewState("JobInformation") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Function CopySelectionsFromGridToListBox(ByRef RadGrid As Telerik.Web.UI.RadGrid, ByRef RadListBox As Telerik.Web.UI.RadListBox, ByVal LookForCode As Boolean) As Boolean

        Dim ItemAdded As Boolean = False

        If RadGrid.Visible = True Then

            Dim i As Integer = 0
            Dim Text As String = String.Empty
            Dim Value As String = String.Empty

            For i = 0 To RadGrid.Items.Count - 1

                Text = String.Empty
                Value = String.Empty
                _RadListBoxItem = Nothing
                _LabelFullName = Nothing
                _LabelEmailAddress = Nothing
                _LabelCode = Nothing

                If RadGrid.Items(i).Selected = True Then

                    _LabelFullName = RadGrid.Items(i).FindControl("lblName")
                    _LabelEmailAddress = RadGrid.Items(i).FindControl("lblAddress")
                    _LabelCode = RadGrid.Items(i).FindControl("lblCode")

                    If _LabelEmailAddress IsNot Nothing Then

                        Text = _LabelEmailAddress.Text

                        If _FromReview = False Then

                            If LookForCode = True AndAlso _LabelCode IsNot Nothing Then

                                Value = _LabelCode.Text

                            Else

                                If _LabelFullName IsNot Nothing Then

                                    Value = _LabelFullName.Text

                                End If

                            End If

                        Else

                            Value = String.Format("{0}|{1}", _LabelFullName.Text, _LabelEmailAddress.Text)

                        End If

                        _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(Text, Value)

                        If _RadListBoxItem IsNot Nothing Then

                            RadListBox.Items.Add(_RadListBoxItem)
                            ItemAdded = True

                        End If

                    End If

                End If

            Next

        End If

        Return ItemAdded

    End Function

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Me.radGridEmpRecipients.Visible = True Then
            Me.radGridEmpRecipients.Rebind()
        End If
        If Me.radGridClientRecipients.Visible = True Then
            Me.radGridClientRecipients.Rebind()
        End If
        If Me.radGridProductRecipients.Visible = True Then
            Me.radGridProductRecipients.Rebind()
        End If
        If Me.radGridVendorContacts.Visible = True Then
            Me.radGridVendorContacts.Rebind()
        End If
        If Me.radGridVendorReps.Visible = True Then
            Me.radGridVendorReps.Rebind()
        End If
    End Sub
    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click

        Me.ddFilter.SelectedValue = 0

        Me.radGridEmpRecipients.Visible = True
        Me.radGridClientRecipients.Visible = False
        Me.radGridProductRecipients.Visible = False
        Me.radGridVendorContacts.Visible = False
        Me.radGridVendorReps.Visible = False

        Me.hlLookup.Text = "Employee:"
        Me.hlLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.txtCode.ClientID.ToString() & "&control2=" & txtName.ClientID.ToString & "');return false;")

        Me.secondLevelLookup.Visible = False
        Me.thirdLevelLookup.Visible = False

        Me.RadListBoxTo.Items.Clear()

        Me.lbBcc.Items.Clear()
        Me.lbCc.Items.Clear()
        Me.txtName.Text = ""
        Me.txtCode.Text = ""
        Me.txtNameDiv.Text = ""
        Me.txtNamePrd.Text = ""
        Me.txtCodeDiv.Text = ""
        Me.txtCodePrd.Text = ""

        Me.radGridEmpRecipients.Rebind()

    End Sub
    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim toContacts As String = String.Empty
        Dim ccContacts As String = String.Empty
        Dim bccContacts As String = String.Empty
        Dim i As Integer = 0

        Dim HasTo As Boolean = False
        Dim HasCC As Boolean = False
        Dim HasBCC As Boolean = False
        Dim strScript As String = String.Empty

        If Me._FromReview = True Then

            Dim ItemAdded As Boolean = False
            Dim HasExternalUser As Boolean = False
            Dim NewExternalUserAdded As Boolean = False

            Dim ExternalReviewers = New Generic.List(Of AdvantageFramework.ConceptShareAPI.ExternalReviewer)
            Dim NewlyAddedExternalReviewers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

            If Me.RadListBoxTo.Items IsNot Nothing AndAlso Me.RadListBoxTo.Items.Count > 0 Then

                Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                Dim ReviewerAdded As Boolean = False
                Dim CurrentAlert As New Alert
                Dim CurrentAlertLoaded As Boolean = False
                Dim Reviewer As AdvantageFramework.ConceptShareAPI.ReviewMember

                ConceptShareConnection = Nothing
                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection
                Reviewer = Nothing

                CurrentAlertLoaded = CurrentAlert.LoadByPrimaryKey(Me.AlertID)

                If ConceptShareConnection IsNot Nothing Then

                    Dim EmailAddress As String = String.Empty
                    Dim FirstName As String = String.Empty
                    Dim LastName As String = String.Empty
                    Dim ExternalReviewer As AdvantageFramework.ConceptShareAPI.ExternalReviewer
                    Dim NewExternalReviewer As AdvantageFramework.ConceptShareAPI.ReviewMember
                    Dim URL As String = String.Empty
                    Dim Employee As AdvantageFramework.Database.Views.Employee
                    Dim InternalEmployeeCodesAdded As New Generic.List(Of String)
                    Dim InternalClientContactIdsAdded As New Generic.List(Of Integer)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim LegacyAlert As New Alert
                        Dim LegacyAlertLoaded As Boolean = False

                        LegacyAlertLoaded = LegacyAlert.LoadByPrimaryKey(Me.AlertID)

                        Try

                            For Each Item As RadListBoxItem In RadListBoxTo.Items

                                If Item.Value.Contains("|") OrElse Item.Value.Contains("@") Then

                                    Dim ar As String()

                                    ar = Item.Value.Split("|")

                                    If ar IsNot Nothing AndAlso ar.Length = 2 Then

                                        Dim Name As Generic.List(Of String)
                                        i = 0

                                        Name = Nothing

                                        Try

                                            Name = ar(0).Split(" ").ToList

                                        Catch ex As Exception
                                            ar = Nothing
                                        End Try
                                        Try

                                            If Name IsNot Nothing AndAlso Name.Count > 0 Then

                                                For Each NamePiece As String In Name

                                                    If i = 0 Then

                                                        FirstName = NamePiece

                                                    ElseIf i = 1 Then

                                                        LastName = NamePiece

                                                    ElseIf i > 1 Then

                                                        LastName &= " " & NamePiece

                                                    End If

                                                    i += 1

                                                Next
                                            End If

                                        Catch ex As Exception
                                            FirstName = "External Reviewer"
                                            LastName = ar(0)
                                        End Try

                                        EmailAddress = ar(1)

                                    End If

                                End If

                                EmailAddress = EmailAddress.Trim
                                FirstName = FirstName.Trim
                                LastName = LastName.Trim

                                If AdvantageFramework.StringUtilities.IsValidEmailAddress(EmailAddress) = True Then

                                    Dim ErrorMessage As String = String.Empty

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByConceptShareEmployeeEmail(DbContext, EmailAddress)

                                    If Employee Is Nothing Then

                                        Dim AddedClientPortalCSUser As Boolean = False
                                        Try

                                            Using SecurityContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                                Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

                                                ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadConceptShareUserByEmailAddress(SecurityContext, EmailAddress)

                                                If ClientPortalUser IsNot Nothing Then

                                                    If AdvantageFramework.ConceptShare.AddUpdateReviewMember(ConceptShareConnection,
                                                                                                      Me.ConceptShareReviewID, ClientPortalUser.ConceptShareUserID) IsNot Nothing Then

                                                        AddedClientPortalCSUser = True

                                                        If LegacyAlert.LoadByPrimaryKey(Me.AlertID) = True Then

                                                            LegacyAlert.AddAlertRecipientCC(ClientPortalUser.ClientContactID)
                                                            ItemAdded = True

                                                        End If

                                                    End If

                                                End If

                                            End Using

                                        Catch ex As Exception
                                            AddedClientPortalCSUser = False
                                        End Try

                                        If AddedClientPortalCSUser = False Then

                                            If ExternalReviewers Is Nothing Then ExternalReviewers = New Generic.List(Of AdvantageFramework.ConceptShareAPI.ExternalReviewer)

                                            ExternalReviewer = New AdvantageFramework.ConceptShareAPI.ExternalReviewer

                                            ExternalReviewer.txtEmail = EmailAddress
                                            ExternalReviewer.txtFirstName = FirstName
                                            ExternalReviewer.txtEmail = EmailAddress

                                            ExternalReviewers.Add(ExternalReviewer)

                                            NewExternalReviewer = AdvantageFramework.ConceptShare.AddUpdateExternalReviewer(ConceptShareConnection, Me.ConceptShareReviewID,
                                                                                                                            EmailAddress, FirstName, LastName, ErrorMessage)

                                            If NewExternalReviewer IsNot Nothing Then

                                                HasExternalUser = True
                                                NewExternalUserAdded = True
                                                ItemAdded = True


                                                Dim Options As New AdvantageFramework.ConceptShareAPI.ResourceUrlOptions

                                                Options.PreAuthenticateUser = True
                                                Options.ProjectId = Me.ConceptShareProjectID
                                                Options.ReferenceType = AdvantageFramework.ConceptShareAPI.ReferenceType.Review
                                                Options.ReferenceId = Me.ConceptShareReviewID
                                                Options.UrlType = AdvantageFramework.ConceptShareAPI.ResourceUrlType.Reference
                                                Options.SecureUrl = True

                                                URL = ConceptShareConnection.APIServiceClient.GetResourceUrlForUser(ConceptShareConnection.APIContext, NewExternalReviewer.ReferenceId, Options)

                                                NewlyAddedExternalReviewers.Add(NewExternalReviewer)

                                                AdvantageFramework.ConceptShare.AddUpdateEmailExternalReviewer(DbContext, Me.ConceptShareReviewID, Me.AlertID, NewExternalReviewer, False)

                                            Else

                                                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                    Me.ShowMessage(ErrorMessage)

                                                End If

                                            End If

                                        End If

                                    Else

                                        If LegacyAlert.LoadByPrimaryKey(Me.AlertID) = True Then

                                            LegacyAlert.AddAlertRecipient(Employee.Code, True)

                                        End If

                                        AdvantageFramework.ConceptShare.AddUpdateReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, Employee.ConceptShareUserID)
                                        InternalEmployeeCodesAdded.Add(Employee.Code)
                                        ItemAdded = True

                                    End If

                                    EmailAddress = String.Empty
                                    FirstName = String.Empty
                                    LastName = String.Empty
                                    URL = String.Empty
                                    ExternalReviewer = Nothing
                                    NewExternalReviewer = Nothing
                                    Employee = Nothing

                                End If

                            Next

                        Catch ex As Exception
                        End Try

                    End Using

                End If

            End If

            If ItemAdded = True Then

                Me.CloseThisWindowAndRefreshCaller("Alert_DigitalAssetReview.aspx")

            End If

        Else

            If Me.RadListBoxTo.Items.Count > 0 Then
                For i = 0 To Me.RadListBoxTo.Items.Count - 1
                    toContacts = toContacts & Me.RadListBoxTo.Items(i).Text & ","
                    HasTo = True
                Next
            End If
            If Me.lbCc.Items.Count > 0 Then
                For i = 0 To Me.lbCc.Items.Count - 1
                    ccContacts = ccContacts & Me.lbCc.Items(i).Text & ","
                    HasCC = True
                Next
            End If
            If Me.lbBcc.Items.Count > 0 Then
                For i = 0 To Me.lbBcc.Items.Count - 1
                    bccContacts = bccContacts & Me.lbBcc.Items(i).Text & ","
                    HasBCC = True
                Next
            End If

            toContacts = MiscFN.CleanStringForSplit(toContacts, ",", Me._FromReview = False)
            ccContacts = MiscFN.CleanStringForSplit(ccContacts, ",", Me._FromReview = False)
            bccContacts = MiscFN.CleanStringForSplit(bccContacts, ",", Me._FromReview = False)

            If Me._FromNewAlertPage = True Then

                If HasTo = True Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEmailTo').value = '" & toContacts & "';"

                End If
                If HasCC = True Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEmailCC').value = '" & ccContacts & "';"

                End If
                If HasBCC = True Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEmailBCC').value = '" & bccContacts & "';"

                End If

            Else

                If HasTo = True Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtToContacts').value = '" & toContacts & "';"

                End If
                If HasCC = True Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCcContacts').value = '" & ccContacts & "';"

                End If
                If HasBCC = True Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtBccContacts').value = '" & bccContacts & "';"

                End If

            End If

            Me.ControlsToSet = strScript
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")

        End If

    End Sub

    Private Sub radGridEmpRecipients_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridEmpRecipients.NeedDataSource
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dr As SqlClient.SqlDataReader

        dr = oEmp.GetEmailRecipientsInternal(Me.cbInclude.Checked, Me.txtCode.Text, Me.txtName.Text, Me.IsClientPortal, Session("UserID"), Me._JobNumber, Me._JobComponentNumber)
        Me.radGridEmpRecipients.DataSource = dr
    End Sub
    Private Sub radGridClientRecipients_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridClientRecipients.NeedDataSource
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dr As SqlClient.SqlDataReader

        dr = oEmp.GetEmailRecipientsClient(Me.cbInclude.Checked, Me.txtCode.Text, Me.txtName.Text, Me.IsClientPortal, Session("UserID"))
        Me.radGridClientRecipients.DataSource = dr
    End Sub
    Private Sub radGridProductRecipients_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridProductRecipients.NeedDataSource
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dr As SqlClient.SqlDataReader

        dr = oEmp.GetEmailRecipientsProduct(Me.cbInclude.Checked, Me.txtCode.Text, Me.txtCodeDiv.Text, Me.txtCodePrd.Text, Me.txtName.Text, Me.txtNameDiv.Text, Me.txtNamePrd.Text, Me.IsClientPortal, Session("UserID"))
        Me.radGridProductRecipients.DataSource = dr
    End Sub
    Private Sub radGridVendorContacts_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridVendorContacts.NeedDataSource
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dr As SqlClient.SqlDataReader

        dr = oEmp.GetEmailVendorContacts(Me.cbInclude.Checked, Me.txtCode.Text, Me.txtName.Text)
        Me.radGridVendorContacts.DataSource = dr
    End Sub
    Private Sub radGridVendorReps_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridVendorReps.NeedDataSource
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dr As SqlClient.SqlDataReader

        dr = oEmp.GetEmailVendorReps(Me.cbInclude.Checked, Me.txtCode.Text, Me.txtName.Text)
        Me.radGridVendorReps.DataSource = dr
    End Sub

    Private Sub cbInclude_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbInclude.CheckedChanged
        If Me.radGridEmpRecipients.Visible = True Then
            Me.radGridEmpRecipients.Rebind()
        End If
        If Me.radGridClientRecipients.Visible = True Then
            Me.radGridClientRecipients.Rebind()
        End If
        If Me.radGridProductRecipients.Visible = True Then
            Me.radGridProductRecipients.Rebind()
        End If
        If Me.radGridVendorContacts.Visible = True Then
            Me.radGridVendorContacts.Rebind()
        End If
        If Me.radGridVendorReps.Visible = True Then
            Me.radGridVendorReps.Rebind()
        End If
    End Sub
    Private Sub cbSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSelectAll.CheckedChanged
        Dim i As Integer
        If Me.radGridEmpRecipients.Visible = True Then
            If Me.cbSelectAll.Checked = True Then
                For i = 0 To Me.radGridEmpRecipients.Items.Count - 1
                    Me.radGridEmpRecipients.Items(i).Selected = True
                Next
            Else
                For i = 0 To Me.radGridEmpRecipients.Items.Count - 1
                    Me.radGridEmpRecipients.Items(i).Selected = False
                Next
            End If
        End If
        If Me.radGridClientRecipients.Visible = True Then
            If Me.cbSelectAll.Checked = True Then
                For i = 0 To Me.radGridClientRecipients.Items.Count - 1
                    Me.radGridClientRecipients.Items(i).Selected = True
                Next
            Else
                For i = 0 To Me.radGridClientRecipients.Items.Count - 1
                    Me.radGridClientRecipients.Items(i).Selected = False
                Next
            End If
        End If
        If Me.radGridProductRecipients.Visible = True Then
            If Me.cbSelectAll.Checked = True Then
                For i = 0 To Me.radGridProductRecipients.Items.Count - 1
                    Me.radGridProductRecipients.Items(i).Selected = True
                Next
            Else
                For i = 0 To Me.radGridProductRecipients.Items.Count - 1
                    Me.radGridProductRecipients.Items(i).Selected = False
                Next
            End If
        End If
        If Me.radGridVendorContacts.Visible = True Then
            If Me.cbSelectAll.Checked = True Then
                For i = 0 To Me.radGridVendorContacts.Items.Count - 1
                    Me.radGridVendorContacts.Items(i).Selected = True
                Next
            Else
                For i = 0 To Me.radGridVendorContacts.Items.Count - 1
                    Me.radGridVendorContacts.Items(i).Selected = False
                Next
            End If
        End If
        If Me.radGridVendorReps.Visible = True Then
            If Me.cbSelectAll.Checked = True Then
                For i = 0 To Me.radGridVendorReps.Items.Count - 1
                    Me.radGridVendorReps.Items(i).Selected = True
                Next
            Else
                For i = 0 To Me.radGridVendorReps.Items.Count - 1
                    Me.radGridVendorReps.Items(i).Selected = False
                Next
            End If
        End If

    End Sub

    Private Sub btnRemoveTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveTo.Click
        Dim i As Integer
        For i = 0 To Me.RadListBoxTo.Items.Count - 1
            If Me.RadListBoxTo.Items.Count > 0 And i <= (Me.RadListBoxTo.Items.Count - 1) Then
                If Me.RadListBoxTo.Items(i).Selected = True Then
                    Me.RadListBoxTo.Items.Remove(Me.RadListBoxTo.Items(i))
                    i = i - 1
                End If
            Else
                Exit For
            End If
        Next
    End Sub
    Private Sub btnRemoveCc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveCc.Click
        Dim i As Integer
        For i = 0 To Me.lbCc.Items.Count - 1
            If Me.lbCc.Items.Count > 0 And i <= (Me.lbCc.Items.Count - 1) Then
                If Me.lbCc.Items(i).Selected = True Then
                    Me.lbCc.Items.Remove(Me.lbCc.Items(i))
                    i = i - 1
                End If
            Else
                Exit For
            End If
        Next
    End Sub
    Private Sub btnRemoveBcc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveBcc.Click
        Dim i As Integer
        For i = 0 To Me.lbBcc.Items.Count - 1
            If Me.lbBcc.Items.Count > 0 And i <= (Me.lbBcc.Items.Count - 1) Then
                If Me.lbBcc.Items(i).Selected = True Then
                    Me.lbBcc.Items.Remove(Me.lbBcc.Items(i))
                    i = i - 1
                End If
            Else
                Exit For
            End If
        Next
    End Sub
    Private Sub btnTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTo.Click

        CopySelectionsFromGridToListBox(radGridEmpRecipients, RadListBoxTo, True)
        CopySelectionsFromGridToListBox(radGridClientRecipients, RadListBoxTo, False)
        CopySelectionsFromGridToListBox(radGridProductRecipients, RadListBoxTo, False)
        CopySelectionsFromGridToListBox(radGridVendorContacts, RadListBoxTo, False)
        CopySelectionsFromGridToListBox(radGridVendorReps, RadListBoxTo, False)

    End Sub
    Private Sub btnCc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCc.Click

        CopySelectionsFromGridToListBox(radGridEmpRecipients, lbCc, True)
        CopySelectionsFromGridToListBox(radGridClientRecipients, lbCc, False)
        CopySelectionsFromGridToListBox(radGridProductRecipients, lbCc, False)
        CopySelectionsFromGridToListBox(radGridVendorContacts, lbCc, False)
        CopySelectionsFromGridToListBox(radGridVendorReps, lbCc, False)

    End Sub
    Private Sub btnBcc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBcc.Click

        CopySelectionsFromGridToListBox(radGridEmpRecipients, lbBcc, True)
        CopySelectionsFromGridToListBox(radGridClientRecipients, lbBcc, False)
        CopySelectionsFromGridToListBox(radGridProductRecipients, lbBcc, False)
        CopySelectionsFromGridToListBox(radGridVendorContacts, lbBcc, False)
        CopySelectionsFromGridToListBox(radGridVendorReps, lbBcc, False)

    End Sub

    'Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    '    Me.CloseThisWindow()

    'End Sub

    Private Sub ddFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFilter.SelectedIndexChanged

        Me.SetData()

    End Sub

    Protected Sub txtCode_TextChanged(sender As Object, e As EventArgs)

        'objects
        Dim Code As String = Nothing
        Dim Name As String = Nothing
        Dim TextBoxToFocus As System.Web.UI.WebControls.TextBox = Nothing

        Code = DirectCast(sender, System.Web.UI.WebControls.TextBox).Text

        If Not String.IsNullOrWhiteSpace(Code) Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case ddFilter.SelectedValue

                        Case "0" 'internal

                            With AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Code)

                                Name = .ToString

                            End With

                        Case "1", "2" 'client contacts, product contacts

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                With (From Item In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                      Where Item.IsActive = 1 AndAlso
                                            Item.Code = Code
                                      Select Item).SingleOrDefault

                                    Name = .Name

                                End With

                            End Using

                            If ddFilter.SelectedValue = "2" Then

                                TextBoxToFocus = txtCodeDiv

                            End If

                        Case "3", "4" 'vendor contacts, vendor rep

                            With AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Code)

                                Name = .Name

                            End With

                    End Select

                End Using

            Catch ex As Exception

            End Try

        End If

        If TextBoxToFocus IsNot Nothing Then

            TextBoxToFocus.Focus()

        End If

        txtName.Text = Name
        txtCodeDiv.Text = ""
        txtNameDiv.Text = ""
        txtCodePrd.Text = ""
        txtNamePrd.Text = ""

    End Sub
    Protected Sub txtCodeDiv_TextChanged(sender As Object, e As EventArgs)

        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing
        Dim DivisionName As String = Nothing

        ClientCode = txtCode.Text
        DivisionCode = DirectCast(sender, System.Web.UI.WebControls.TextBox).Text

        If Not [String].IsNullOrWhiteSpace(ClientCode) AndAlso Not [String].IsNullOrWhiteSpace(DivisionCode) Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        With (From Item In AdvantageFramework.Database.Procedures.DivisionView.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                              Where Item.ClientCode = ClientCode AndAlso
                                    Item.DivisionCode = DivisionCode AndAlso
                                    Item.IsActive = 1
                              Select Item).SingleOrDefault

                            DivisionName = .DivisionName
                            txtCodePrd.Focus()

                        End With

                    End Using

                End Using

            Catch ex As Exception

            End Try

        End If

        txtNameDiv.Text = DivisionName
        txtCodePrd.Text = ""
        txtNamePrd.Text = ""

    End Sub
    Protected Sub txtCodePrd_TextChanged(sender As Object, e As EventArgs)

        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing
        Dim ProductCode As String = Nothing
        Dim ProductName As String = Nothing

        ClientCode = txtCode.Text
        DivisionCode = txtCodeDiv.Text
        ProductCode = DirectCast(sender, System.Web.UI.WebControls.TextBox).Text

        If Not [String].IsNullOrWhiteSpace(ClientCode) AndAlso Not [String].IsNullOrWhiteSpace(DivisionCode) AndAlso Not [String].IsNullOrWhiteSpace(ProductCode) Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        With (From Item In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, True)
                              Where Item.ClientCode = ClientCode AndAlso
                                    Item.DivisionCode = DivisionCode
                              Select Item).SingleOrDefault

                            ProductName = .ProductDescription

                        End With

                    End Using

                End Using

            Catch ex As Exception

            End Try

        End If

        txtNamePrd.Text = ProductName

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            Me.OpenerRadWindowName = Request.QueryString("opener")
        Catch ex As Exception
            Me.OpenerRadWindowName = ""
        End Try
        Me._FromReview = Me.OpenerRadWindowName.StartsWith("review")
        Try
            If Not Request.QueryString("fna") Is Nothing Then
                If IsNumeric(Request.QueryString("fna")) = True Then
                    If CType(Request.QueryString("fna"), Integer) = 1 Then
                        Me._FromNewAlertPage = True
                    End If
                End If
            End If
        Catch ex As Exception
            Me._FromNewAlertPage = False
        End Try
        Try
            If Not Request.QueryString("ref_id") Is Nothing Then
                Dim i As Integer = CType(Request.QueryString("ref_id"), Integer)
                If i > 0 Then
                    Me._PurchaseOrderReferenceID = i
                End If
            End If
        Catch ex As Exception
            Me._PurchaseOrderReferenceID = 0
        End Try
        Try

            If Me.CurrentQuerystring.JobNumber > 0 Then _JobNumber = Me.CurrentQuerystring.JobNumber
            If Me.CurrentQuerystring.JobComponentNumber > 0 Then _JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

        Catch ex As Exception
        End Try
        Try

            If Me.CurrentQuerystring.ConceptShareProjectID > 0 Then ConceptShareProjectID = Me.CurrentQuerystring.ConceptShareProjectID
            If Me.CurrentQuerystring.ConceptShareReviewID > 0 Then ConceptShareReviewID = Me.CurrentQuerystring.ConceptShareReviewID
            If Me.CurrentQuerystring.AlertID > 0 Then AlertID = Me.CurrentQuerystring.AlertID

        Catch ex As Exception
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack And Not Me.IsCallback Then

            LoadFilter()

            'Me.radGridClientRecipients.Visible = False
            'Me.radGridProductRecipients.Visible = False
            'Me.radGridVendorContacts.Visible = False
            'Me.radGridVendorReps.Visible = False
            'Me.secondLevelLookup.Visible = False
            'Me.thirdLevelLookup.Visible = False

            'Me.hlLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.txtCode.ClientID.ToString() & "&control2=" & txtName.ClientID.ToString & "');return false;")

            If Me._FromReview = True Then

                Me.DivCC.Visible = False
                Me.DivBCC.Visible = False

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    If Me._JobNumber > 0 AndAlso Me._JobComponentNumber > 0 Then

                        If Me.JobInformation Is Nothing Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                Me.JobInformation = AdvantageFramework.ConceptShare.LoadJobInfoByByConceptShareReviewID(DataContext, Me.ConceptShareReviewID)

                                If Me.JobInformation IsNot Nothing Then

                                    Me.txtCode.Text = JobInformation.ClientCode
                                    Me.txtName.Text = JobInformation.ClientName
                                    Me.txtCodeDiv.Text = JobInformation.DivisionCode
                                    Me.txtNameDiv.Text = JobInformation.DivisionName
                                    Me.txtCodePrd.Text = JobInformation.ProductCode
                                    Me.txtNamePrd.Text = JobInformation.ProductName

                                End If

                            End Using

                        End If

                    End If

                End If


            End If

            Me.SetData()

            Try

                If Me._PurchaseOrderReferenceID > 0 Then

                    Dim p As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

                    With p

                        .Select_POHeader(Me._PurchaseOrderReferenceID, "")

                        If p.Vendor_Contact_Email <> "" Then

                            _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(p.Vendor_Contact_Email, p.Vendor_Contact_Name)
                            Me.RadListBoxTo.Items.Add(_RadListBoxItem)

                        End If

                    End With

                End If
            Catch ex As Exception
            End Try

            If Not Request.QueryString("to") Is Nothing Then

                Dim Existing As String = Request.QueryString("to").ToString()

                If Existing <> "" Then

                    If Existing.Contains(",") = True Then

                        Dim str() As String
                        str = Existing.Split(",")

                        If str.Length > 0 Then

                            For i As Integer = 0 To str.Length - 1

                                If RadListBoxTo.FindItemByText(str(i)) Is Nothing Then

                                    _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(str(i), "")
                                    Me.RadListBoxTo.Items.Add(_RadListBoxItem)

                                End If

                            Next

                        End If

                    Else

                        If RadListBoxTo.FindItemByText(Existing) Is Nothing Then

                            _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(Existing, "")
                            Me.RadListBoxTo.Items.Add(_RadListBoxItem)

                        End If

                    End If

                End If

            End If
            If Not Request.QueryString("cc") Is Nothing Then

                Dim Existing As String = Request.QueryString("cc").ToString()

                If Existing <> "" Then

                    If Existing.Contains(",") = True Then

                        Dim str() As String
                        str = Existing.Split(",")

                        If str.Length > 0 Then

                            For i As Integer = 0 To str.Length - 1

                                If lbCc.FindItemByText(str(i)) Is Nothing Then

                                    _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(str(i), "")
                                    Me.lbCc.Items.Add(_RadListBoxItem)

                                End If

                            Next

                        End If

                    Else

                        If lbCc.FindItemByText(Existing) Is Nothing Then

                            _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(Existing, "")
                            Me.lbCc.Items.Add(_RadListBoxItem)

                        End If

                    End If

                End If

            End If
            If Not Request.QueryString("bcc") Is Nothing Then

                Dim Existing As String = Request.QueryString("bcc").ToString()

                If Existing <> "" Then

                    If Existing.Contains(",") = True Then

                        Dim str() As String
                        str = Existing.Split(",")

                        If str.Length > 0 Then

                            For i As Integer = 0 To str.Length - 1

                                If lbBcc.FindItemByText(str(i)) Is Nothing Then

                                    _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(str(i), "")
                                    Me.lbBcc.Items.Add(_RadListBoxItem)

                                End If

                            Next

                        End If

                    Else

                        If lbBcc.FindItemByText(Existing) Is Nothing Then

                            _RadListBoxItem = New Telerik.Web.UI.RadListBoxItem(Existing, "")
                            Me.lbBcc.Items.Add(_RadListBoxItem)

                        End If

                    End If

                End If

            End If

        End If

    End Sub

#End Region

    Private Sub LoadFilter()

        If Me._FromReview = False Then

            Me.ddFilter.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Internal"), CStr("0")))

        End If

        Me.ddFilter.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Client Contacts"), CStr("1")))
        Me.ddFilter.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Product Contacts"), CStr("2")))

        If Me.IsClientPortal = False Then

            Me.ddFilter.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Vendor Contacts"), CStr("3")))
            Me.ddFilter.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Vendor Representatives"), CStr("4")))

        End If

        Me.ddFilter.SelectedIndex = 0

    End Sub
    Private Sub SetData()

        'If Me._FromReview = False Then


        'End If

        txtCode.Text = ""
        txtName.Text = ""
        txtCodeDiv.Text = ""
        txtNameDiv.Text = ""
        txtCodePrd.Text = ""
        txtNamePrd.Text = ""

        If Me.ddFilter.SelectedValue = "0" Then 'Internal

            Me.radGridEmpRecipients.Visible = True
            Me.radGridClientRecipients.Visible = False
            Me.radGridProductRecipients.Visible = False
            Me.radGridVendorContacts.Visible = False
            Me.radGridVendorReps.Visible = False
            Me.hlLookup.Text = "Employee:"
            Me.hlLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.txtCode.ClientID.ToString() & "&control2=" & txtName.ClientID.ToString & "');return false;")
            Me.secondLevelLookup.Visible = False
            Me.thirdLevelLookup.Visible = False

            Me.radGridEmpRecipients.Rebind()

        End If

        If Me.ddFilter.SelectedValue = "1" Then 'Client Contacts

            Me.radGridEmpRecipients.Visible = False
            Me.radGridClientRecipients.Visible = True
            Me.radGridProductRecipients.Visible = False
            Me.radGridVendorContacts.Visible = False
            Me.radGridVendorReps.Visible = False

            Me.hlLookup.Text = "Client:"

            If IsClientPortal = True Then

                Me.hlLookup.Attributes.Add("onclick", "")
                Me.txtCode.Text = Session("CL_CODE")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me.txtName.Text = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Session("CL_CODE")).Name

                End Using

            Else

                Me.hlLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=client&control=" & Me.txtCode.ClientID & "&client=' + document.forms[0]." & Me.txtCode.ClientID & ".value);return false;")

            End If

            Me.secondLevelLookup.Visible = False
            Me.thirdLevelLookup.Visible = False

            If IsClientPortal = True Then

                Me.txtCode.Text = Session("CL_CODE")
                Me.txtCode.ReadOnly = True
                Me.hlLookup.Attributes.Remove("onClick")
                Me.hlLookup.Attributes.Remove("href")

            ElseIf Me._FromReview = True Then


                Me.txtCode.Text = Me.JobInformation.ClientCode
                Me.txtName.Text = Me.JobInformation.ClientName
                Me.txtCode.ReadOnly = True
                Me.hlLookup.Attributes.Remove("onClick")
                Me.hlLookup.Attributes.Remove("href")

            End If

            Me.radGridClientRecipients.Rebind()

        End If
        If Me.ddFilter.SelectedValue = "2" Then 'Product Contacts

            Me.radGridEmpRecipients.Visible = False
            Me.radGridClientRecipients.Visible = False
            Me.radGridProductRecipients.Visible = True
            Me.radGridVendorContacts.Visible = False
            Me.radGridVendorReps.Visible = False
            Me.hlLookup.Text = "Client:"

            If IsClientPortal = True Then

                Me.hlLookup.Attributes.Add("onclick", "")
                Me.txtCode.Text = Session("CL_CODE")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me.txtName.Text = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Session("CL_CODE")).Name

                End Using
                Me.txtCode.Text = Session("CL_CODE")
                Me.txtCode.ReadOnly = True
                Me.hlLookup.Attributes.Remove("onClick")
                Me.hlLookup.Attributes.Remove("href")

            ElseIf Me._FromReview = True Then


                Me.txtCode.Text = Me.JobInformation.ClientCode
                Me.txtName.Text = Me.JobInformation.ClientName
                Me.txtCode.ReadOnly = True
                Me.hlLookup.Attributes.Remove("onClick")
                Me.hlLookup.Attributes.Remove("href")

            Else

                Me.hlLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacket&control=" & Me.txtCode.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtCodeDiv.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtCodePrd.ClientID & ".value + '&job=&jobcomp=');return false;")

            End If

            Me.secondLevelLookup.Visible = True
            Me.thirdLevelLookup.Visible = True
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtCodeDiv.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtCodeDiv.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtCodePrd.ClientID & ".value + '&job=&jobcomp=');return false;")
            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacket&control=" & Me.txtCodePrd.ClientID & "&type=product&client=' + document.forms[0]." & Me.txtCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtCodeDiv.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtCodePrd.ClientID & ".value + '&job=&jobcomp=');return false;")

            Me.radGridProductRecipients.Rebind()

        End If
        If Me.ddFilter.SelectedValue = "3" Then 'Vendor Contacts

            Me.radGridEmpRecipients.Visible = False
            Me.radGridClientRecipients.Visible = False
            Me.radGridProductRecipients.Visible = False
            Me.radGridVendorContacts.Visible = True
            Me.radGridVendorReps.Visible = False
            Me.hlLookup.Text = "Vendor:"
            Me.hlLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=email_search&type=vendor_and_contact&control=" & Me.txtCode.ClientID & "&control2=" & txtName.ClientID & "');return false;")
            Me.secondLevelLookup.Visible = False
            Me.thirdLevelLookup.Visible = False
            Me.radGridVendorContacts.Rebind()

        End If
        If Me.ddFilter.SelectedValue = "4" Then 'Vendor Representatives

            Me.radGridEmpRecipients.Visible = False
            Me.radGridClientRecipients.Visible = False
            Me.radGridProductRecipients.Visible = False
            Me.radGridVendorContacts.Visible = False
            Me.radGridVendorReps.Visible = True
            Me.hlLookup.Text = "Vendor:"
            Me.hlLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=email_search&type=vendor_and_contact&control=" & Me.txtCode.ClientID & "&control2=" & txtName.ClientID & "');return false;")
            Me.secondLevelLookup.Visible = False
            Me.thirdLevelLookup.Visible = False
            Me.radGridVendorReps.Rebind()

        End If

    End Sub

#End Region


End Class
