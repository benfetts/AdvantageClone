Public Class Alert_AddAttachments
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _AddAttachmentComment As Boolean = False
    Private _DocumentList As New Generic.List(Of Webvantage.CommentDocument)
    Private _IsProofHQEnabled As Boolean = False
    Private _LegacyAlertObject As Alert
    Private _ClientPortalID As Integer = 0
    Private _NoRefreshCaller As Boolean = False

#End Region

#Region " Properties "

    Private ReadOnly Property AlertID
        Get
            Return Me.CurrentQuerystring.AlertID
        End Get
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Protected Sub ButtonUploadAttachments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUploadAttachments.Click

        Me._AddAttachmentComment = Me.TextBoxAttachmentComment.Text.Trim() <> ""
        Me._DocumentList.Clear()

        Dim DocumentsLinked As Boolean = Me.LinkDocuments()
        Dim FilesAttached As Boolean = Me.UploadAttachments()

        If DocumentsLinked = True OrElse FilesAttached = True Then

            'new comment stuff
            '======================================================================================================================
            If Me._AddAttachmentComment = True Then

                Dim StrComment As String = "DOCUMENT ADDED|" & Session("EmployeeName") & "|" & HttpUtility.HtmlEncode(Me.TextBoxAttachmentComment.Text.Trim()) '& Me.AppendDocumentAddedComment(dict)
                Dim alertComment As New AlertComment(_Session.ConnectionString)
                Dim DocListString As String = ""

                If Not Me._DocumentList Is Nothing AndAlso Me._DocumentList.Count > 0 Then

                    Dim m As New CommentDocument()

                    DocListString = m.ObjectToString(Me._DocumentList)

                End If

                If Me.IsClientPortal = True Then

                    alertComment.AddNewComment(Me.AlertID, "", StrComment, Me._ClientPortalID, DocListString)

                Else

                    alertComment.AddNewComment(Me.AlertID, Me._Session.UserCode, StrComment, 0, DocListString)

                End If

                If Me.AlertRecipients(False) = False Then

                    'Exit Sub

                End If

            End If

            If _NoRefreshCaller = False Then

                'Me.CloseThisWindowAndRefreshCaller("Alert_View.aspx")
                Me.CloseThisWindowAndRefreshCaller(String.Format("Alert_View.aspx?AlertID={0}&openasassign=false&a={0}", Me.AlertID), False, True)

            Else

                Me.CloseThisWindow()

            End If

        Else

            Me.ShowMessage("Nothing attached/linked")

        End If

    End Sub
    Private Sub ChkUploadToRepository_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUploadToRepository.CheckedChanged

        If CheckBoxUploadToProofHQ.Visible Then

            CheckBoxUploadToProofHQ.Enabled = ChkUploadToRepository.Checked

            If CheckBoxUploadToProofHQ.Enabled = False Then

                CheckBoxUploadToProofHQ.Checked = False

            End If

        End If

    End Sub

#End Region
#Region " Page "

    Private Sub Alert_AddAttachments_Init(sender As Object, e As EventArgs) Handles Me.Init

        If HttpContext.Current.Session("UserID") IsNot Nothing AndAlso IsNumeric(HttpContext.Current.Session("UserID")) Then

            Me._ClientPortalID = HttpContext.Current.Session("UserID")

        End If

        Try

            If Request.QueryString("NoRefreshCaller") IsNot Nothing Then

                _NoRefreshCaller = CBool(Request.QueryString("NoRefreshCaller"))

            End If

        Catch ex As Exception
            _NoRefreshCaller = False
        End Try

    End Sub
    Private Sub Alert_AddAttachments_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me._LegacyAlertObject = New Alert()
            Me.ShowLinkExistingFile()

            If Me._LegacyAlertObject.LoadByPrimaryKey(Me.AlertID) = True Then

                Dim m As New DocumentRepository("", True)

                If m.SetRadAsyncUpload(Me.RadUploadAlertDocuments, True, Me.LabelFileSizeLimitMessage.Text) = False Then

                    Me.LabelFileSizeLimitMessage.CssClass = "warning"

                End If

                Using DataContext = New AdvantageFramework.Database.DataContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    _IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

                    If _IsProofHQEnabled AndAlso Me.IsClientPortal = False Then

                        CheckBoxUploadToProofHQ.Visible = True

                    End If

                End Using

                'Select Case Me._LegacyAlertObject.s_ALERT_LEVEL
                '    Case "JO", "JC", "JJ", "PS", "PST"

                Me.ChkUploadToRepository.Visible = True
                Me.CheckBoxUploadToProofHQ.Visible = (_IsProofHQEnabled AndAlso Me.IsClientPortal = False)

                '    Case Else

                '        Me.ChkUploadToRepository.Visible = False
                '        Me.CheckBoxUploadToProofHQ.Visible = False

                'End Select

                Me.ChkUploadToRepository.AutoPostBack = Me.CheckBoxUploadToProofHQ.Visible

                If Me.IsClientPortal = True Then

                    Me.DivLinkDocuments.Visible = False

                Else

                    Me.LoadLinkableDocuments()

                End If

            Else

                Me.CloseThisWindow()

            End If

        End If

    End Sub

#End Region

    Private Function AlertRecipients(ByVal IncludeOriginator As Boolean) As Boolean
        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Alert As AdvantageFramework.Database.Entities.Alert

                Alert = Nothing

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertID)

                If Alert IsNot Nothing Then

                    Dim AlertRecipientsList As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient)
                    Dim AlertClientPortalRecipientsList As Generic.List(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipient)

                    Dim EmployeeCodesForEmail As String = String.Empty
                    Dim EmployeeCodeOfAlertAssignment As String = String.Empty
                    Dim ClientPortalRecipientsForEmail As String = String.Empty

                    AlertRecipientsList = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Me.AlertID).ToList

                    If AlertRecipientsList IsNot Nothing AndAlso AlertRecipientsList.Count > 0 Then

                        For Each Recipient As AdvantageFramework.Database.Entities.AlertRecipient In AlertRecipientsList

                            If Recipient.IsCurrentRecipient Is Nothing OrElse Recipient.IsCurrentRecipient = 0 Then

                                Recipient.HasBeenRead = Nothing
                                AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Recipient)

                                EmployeeCodesForEmail &= Recipient.EmployeeCode & ","

                            End If

                        Next

                    End If

                    AlertClientPortalRecipientsList = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertID(DbContext, Me.AlertID).ToList

                    If AlertClientPortalRecipientsList IsNot Nothing AndAlso AlertClientPortalRecipientsList.Count > 0 Then

                        For Each ClientPortalRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient In AlertClientPortalRecipientsList

                            If ClientPortalRecipient.IsCurrentRecipient Is Nothing OrElse ClientPortalRecipient.IsCurrentRecipient = 0 Then

                                ClientPortalRecipient.HasBeenRead = Nothing
                                AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Update(DbContext, ClientPortalRecipient)

                                ClientPortalRecipientsForEmail &= ClientPortalRecipient.ClientContactID.ToString & ","

                            End If

                        Next

                    End If
                    If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = True Then

                        EmployeeCodeOfAlertAssignment = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(ALERT.ASSIGNED_EMP_CODE, '') FROM ALERT WITH(NOLOCK) WHERE ALERT_ID = {0};", Me.AlertID)).FirstOrDefault

                    End If
                    If String.IsNullOrWhiteSpace(EmployeeCodeOfAlertAssignment) = False Then

                        If String.IsNullOrWhiteSpace(EmployeeCodesForEmail) = True Then

                            EmployeeCodesForEmail = EmployeeCodesForEmail & "," & EmployeeCodeOfAlertAssignment

                        Else

                            EmployeeCodesForEmail = EmployeeCodeOfAlertAssignment

                        End If

                    End If
                    If String.IsNullOrWhiteSpace(EmployeeCodesForEmail) = False OrElse String.IsNullOrWhiteSpace(ClientPortalRecipientsForEmail) = False Then

                        EmployeeCodesForEmail = MiscFN.CleanStringForSplit(EmployeeCodesForEmail, ",")
                        ClientPortalRecipientsForEmail = MiscFN.CleanStringForSplit(ClientPortalRecipientsForEmail, ",")

                        Dim eso As New EmailSessionObject(Me._Session.ConnectionString,
                                                      Me._Session.UserCode,
                                                      Me._Session,
                                                      HttpContext.Current.Session("WebvantageURL"),
                                                      HttpContext.Current.Session("ClientPortalURL"))

                        With eso

                            .AlertId = Me.AlertID
                            .Subject = "[Alert Updated]"
                            .EmployeeCodesToSendEmailTo = EmployeeCodesForEmail
                            .ClientPortalEmailAddressessToSendTo = ClientPortalRecipientsForEmail
                            .IsClientPortal = Me.IsClientPortal
                            .IncludeOriginator = IncludeOriginator
                            .SessionID = HttpContext.Current.Session.SessionID.ToString()
                            .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                            .Send()

                        End With

                        Me.CheckForAsyncMessage()

                    End If

                End If

            End Using

            Return True

        Catch ex As Exception
            Me.ShowMessage("Error occurred sending mail.  " & ex.Message)
            Return False
        End Try

    End Function
    Private Function AppendDocumentAddedComment(ByVal FileAndIdDictionary As System.Collections.Generic.Dictionary(Of Integer, String)) As String

        Dim sb As New System.Text.StringBuilder
        sb.Append("<br /><br />")
        For Each item As System.Collections.Generic.KeyValuePair(Of Integer, String) In FileAndIdDictionary

            'sb.Append(item.Key.ToString())
            With sb

                .Append("<a href=""#"" onclick=""GetDocumentRepositoryDocument('")
                .Append(item.Key.ToString())
                .Append("');return false;"">")
                .Append(item.Value.ToString())
                .Append("</a>")

            End With
            sb.Append(Environment.NewLine)

        Next

        'Return MiscFN.CleanStringForSplit(sb.ToString(), ";", False, True, True, True, False)

    End Function
    Private Function LinkDocuments() As Boolean

        Dim SomethingAdded As Boolean = False
        Dim TryingToLinkADocumentThatIsAlreadyLinked As Boolean = False
        Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
        Me._LegacyAlertObject = New Alert()

        If Me._LegacyAlertObject.LoadByPrimaryKey(Me.AlertID) = True Then

            Try

                For Each item As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxLinkableDocuments.Items

                    If item.Selected = True Then

                        Dim DocumentID As Integer = item.Value
                        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString.ToString(), Me._Session.UserCode.ToString())

                            AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertIDAndDocumentID(DbContext, Me.AlertID, DocumentID)

                            If AlertAttachment IsNot Nothing Then

                                _LegacyAlertObject.AddAttachment(DocumentID, Me._Session.UserCode, 0)

                                If Me._AddAttachmentComment = True Then

                                    Dim doc As New AdvantageFramework.Database.Entities.Document

                                    doc = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)
                                    If Not doc Is Nothing Then

                                        Dim d As New Webvantage.CommentDocument()
                                        With d

                                            .Filename = doc.FileName
                                            '.FileExtension = 
                                            .DocumentId = DocumentID
                                            .MimeType = doc.MIMEType

                                        End With

                                        Me._DocumentList.Add(d)

                                    End If

                                End If

                                SomethingAdded = True

                            Else

                                TryingToLinkADocumentThatIsAlreadyLinked = True

                            End If

                        End Using

                    End If

                Next
                If SomethingAdded = True Then

                    Dim AlertRecipient As New AlertRecipient(Me._Session.ConnectionString)
                    AlertRecipient.Where.ALERT_ID.Value = Me.AlertID
                    AlertRecipient.Query.Load()

                    Do Until AlertRecipient.EOF

                        'Set the PROCESSED date to NULL
                        AlertRecipient.SetColumnNull(AlertRecipient.ColumnNames.PROCESSED)
                        AlertRecipient.MoveNext()

                    Loop

                    AlertRecipient.Save()

                End If

            Catch ex As Exception

            End Try

        End If

        Return SomethingAdded

    End Function
    Private Sub LoadLinkableDocuments()

        Me.RadListBoxLinkableDocuments.Items.Clear()
        Me._LegacyAlertObject = New Alert()

        If Me._LegacyAlertObject.LoadByPrimaryKey(Me.AlertID) = True Then
            Try
                Select Case Me._LegacyAlertObject.ALERT_LEVEL

                    Case "CL"
                        Dim ClientDocs As New vCurrentClientDocuments(Me._Session.ConnectionString)
                        ClientDocs.Where.CL_CODE.Value = Me._LegacyAlertObject.CL_CODE
                        ClientDocs.Query.Load()

                        Do Until ClientDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(ClientDocs.FILENAME & " " & ClientDocs.USER_NAME & " " & ClientDocs.UPLOADED_DATE, ClientDocs.DOCUMENT_ID))
                            ClientDocs.MoveNext()
                        Loop


                    Case "OF"
                        Dim OfficeDocs As New vCurrentOfficeDocuments(Me._Session.ConnectionString)

                        OfficeDocs.Where.OFFICE_CODE.Value = Me._LegacyAlertObject.OFFICE_CODE
                        OfficeDocs.Query.Load()
                        Do Until OfficeDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(OfficeDocs.FILENAME & " " & OfficeDocs.USER_NAME & " " & OfficeDocs.UPLOADED_DATE, OfficeDocs.DOCUMENT_ID))

                            OfficeDocs.MoveNext()
                        Loop
                    Case "DI"

                        Dim DivisionDocs As New vCurrentDivisionDocuments(Me._Session.ConnectionString)
                        'DivisionDocs.Where.CL_CODE.Value = Me.CurrentAlert.CL_CODE
                        DivisionDocs.Where.DIV_CODE.Value = Me._LegacyAlertObject.DIV_CODE
                        DivisionDocs.Query.Load()
                        Do Until DivisionDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(DivisionDocs.FILENAME & " " & DivisionDocs.USER_NAME & " " & DivisionDocs.UPLOADED_DATE, DivisionDocs.DOCUMENT_ID))
                            DivisionDocs.MoveNext()
                        Loop

                    Case "PR"
                        Dim ProductDocs As New vCurrentProductDocuments(Me._Session.ConnectionString)
                        ProductDocs.Where.PRD_CODE.Value = Me._LegacyAlertObject.PRD_CODE
                        ProductDocs.Query.Load()
                        Do Until ProductDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(ProductDocs.FILENAME & " " & ProductDocs.USER_NAME & " " & ProductDocs.UPLOADED_DATE, ProductDocs.DOCUMENT_ID))
                            ProductDocs.MoveNext()
                        Loop
                    Case "CM"
                        Dim CampaignDocs As New vCurrentCampaignDocuments(Me._Session.ConnectionString)
                        CampaignDocs.Where.CMP_IDENTIFIER.Value = Me._LegacyAlertObject.CMP_IDENTIFIER
                        CampaignDocs.Query.Load()
                        Do Until CampaignDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(CampaignDocs.FILENAME & " " & CampaignDocs.USER_NAME & " " & CampaignDocs.UPLOADED_DATE, CampaignDocs.DOCUMENT_ID))
                            CampaignDocs.MoveNext()
                        Loop
                    Case "JC"
                        Dim JobComponentDocs As New vCurrentJobComponentDocuments(Me._Session.ConnectionString)
                        JobComponentDocs.Where.JOB_NUMBER.Value = Me._LegacyAlertObject.JOB_NUMBER
                        JobComponentDocs.Where.JOB_COMPONENT_NUMBER.Value = Me._LegacyAlertObject.JOB_COMPONENT_NBR
                        JobComponentDocs.Query.Load()
                        Do Until JobComponentDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobComponentDocs.FILENAME & ", added by " & JobComponentDocs.USER_NAME & " @ " & JobComponentDocs.UPLOADED_DATE, JobComponentDocs.DOCUMENT_ID))
                            JobComponentDocs.MoveNext()
                        Loop
                    Case "JO"
                        Dim JobDocs As New vCurrentJobDocuments(Me._Session.ConnectionString)
                        JobDocs.Where.JOB_NUMBER.Value = Me._LegacyAlertObject.JOB_NUMBER
                        JobDocs.Query.Load()
                        Do Until JobDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobDocs.FILENAME & ", added by " & JobDocs.USER_NAME & " @ " & JobDocs.UPLOADED_DATE, JobDocs.DOCUMENT_ID))
                            JobDocs.MoveNext()
                        Loop
                    Case "PS", "PST"
                        Dim JobDocs As New vCurrentJobDocuments(Me._Session.ConnectionString)
                        With JobDocs.Where
                            .JOB_NUMBER.Value = Me._LegacyAlertObject.JOB_NUMBER

                        End With
                        JobDocs.Query.Load()
                        Do Until JobDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobDocs.FILENAME & ", added by " & JobDocs.USER_NAME & " @ " & JobDocs.UPLOADED_DATE, JobDocs.DOCUMENT_ID))
                            JobDocs.MoveNext()
                        Loop
                        Dim JobComponentDocs As New vCurrentJobComponentDocuments(Me._Session.ConnectionString)
                        JobComponentDocs.Where.JOB_NUMBER.Value = Me._LegacyAlertObject.JOB_NUMBER
                        JobComponentDocs.Where.JOB_COMPONENT_NUMBER.Value = Me._LegacyAlertObject.JOB_COMPONENT_NBR
                        JobComponentDocs.Query.Load()
                        Do Until JobComponentDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobComponentDocs.FILENAME & ", added by " & JobComponentDocs.USER_NAME & " @ " & JobComponentDocs.UPLOADED_DATE, JobComponentDocs.DOCUMENT_ID))
                            JobComponentDocs.MoveNext()
                        Loop

                    Case "VN"
                        Dim APDocuments As New vCurrentAPDocuments(Me._Session.ConnectionString)
                    Case "AD"

                    Case "ED"

                End Select

            Catch ex As Exception
            End Try

        End If

        Me.DivLinkDocuments.Visible = Me.RadListBoxLinkableDocuments.Items.Count > 0

    End Sub
    Private Function UploadAttachments() As Boolean

        Dim i As Integer = 0
        Dim OneThingAdded As Boolean = False
        Dim HasOverSizedFile As Boolean = False
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        Try

            If Me.RadUploadAlertDocuments.UploadedFiles.Count > 0 Then

                Me._LegacyAlertObject = New Alert()
                If Me._LegacyAlertObject.LoadByPrimaryKey(Me.AlertID) = True Then

                    'Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                    'Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
                    'If IsNTAUTH = True Then
                    '    currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                    '    impersonationContext = currentWindowsIdentity.Impersonate()
                    'End If

                    ''''Dim dict As New System.Collections.Generic.Dictionary(Of Integer, String)

                    Dim SomethingAdded As Boolean = False
                    Dim a As New cAlerts()

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me._Session.ConnectionString, Me._Session.UserCode)

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            For i = 0 To Me.RadUploadAlertDocuments.UploadedFiles.Count - 1

                                If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadAlertDocuments.UploadedFiles(i)) = False Then

                                    Me.ShowMessage("Invalid file type.")
                                    Return False

                                End If

                                Dim DocId As Integer = 0
                                DocId = a.UploadAlertDocument(Me.RadUploadAlertDocuments.UploadedFiles(i), Me._LegacyAlertObject, SomethingAdded, HasOverSizedFile, Me.ChkUploadToRepository.Checked)

                                If SomethingAdded = True Then

                                    OneThingAdded = True
                                    ''''dict.Add(DocId, Me.RadUploadAlertDocuments.UploadedFiles(i).FileName)

                                    If Me._AddAttachmentComment = True Then

                                        Dim d As New Webvantage.CommentDocument()
                                        With d

                                            .Filename = Me.RadUploadAlertDocuments.UploadedFiles(i).FileName
                                            .FileExtension = Me.RadUploadAlertDocuments.UploadedFiles(i).GetExtension
                                            .DocumentId = DocId

                                            If Not Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType Is Nothing Then

                                                .MimeType = Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType

                                            End If

                                        End With

                                        Me._DocumentList.Add(d)

                                    End If

                                End If

                                If DocId > 0 AndAlso CheckBoxUploadToProofHQ.Checked Then

                                    If Agency IsNot Nothing Then

                                        AdvantageFramework.AlertSystem.UploadAttachmentToProofHQ(DbContext, DataContext, HttpContext.Current.Session("EmpCode"), DocId, Me._LegacyAlertObject.ALERT_ID)

                                    End If

                                End If

                            Next

                        End Using

                    End Using

                    If HasOverSizedFile = True Then

                        Me.ShowMessage("Files that exceeded the file size limit were excluded")

                    End If

                    If OneThingAdded = True Then

                        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity

                        If IsNTAuth = True Then

                            currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                            impersonationContext = currentWindowsIdentity.Impersonate()

                        End If

                        If IsNTAuth = True Then

                            impersonationContext.Undo()
                            impersonationContext.Dispose()
                            currentWindowsIdentity.Dispose()

                        End If

                    End If

                End If

            End If

        Catch ex As Exception

            Me.ShowMessage("Error adding attachment")

        End Try

        Return OneThingAdded

    End Function

    Private Sub CheckBoxLinkExistingFile_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLinkExistingFile.CheckedChanged

        Me.ShowLinkExistingFile()

    End Sub

    Private Sub ShowLinkExistingFile()

        Me.DivUploadAttachments.Visible = Not Me.CheckBoxLinkExistingFile.Checked
        Me.DivLinkDocumentsRadListBox.Visible = Me.CheckBoxLinkExistingFile.Checked

    End Sub

#End Region

End Class
