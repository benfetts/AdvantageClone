Namespace Services.EmailListener

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Email Listener\", "RunAtEvery", "1")>
            RunAtEvery
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Email Listener\", "StartofSignatureCode", "")>
            StartofSignatureCode
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Email Listener\", "LastRanAt", "01/01/2001 01:00 AM")>
            LastRanAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Email Listener\", "MessageIDs", "")>
            MessageIDs
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Email Listener\", "SendEmailToAlertRecipients", "TRUE")>
            SendEmailToAlertRecipients
        End Enum

        Public Enum CustomCommand As Integer
            LoadSettings = 128
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Private Function ParseAlertID(ByRef BodyText As String) As Long

            'objects
            Dim Index As Integer = -1
            Dim RestOfBody As String = ""
            Dim AlertIDString As String = ""
            Dim AlertID As Long = 0

            Try

                If BodyText.Contains("##LISTENER_ALERT_ID:") Then

                    Index = BodyText.IndexOf("##LISTENER_ALERT_ID:")

                    If Index > 0 Then

                        RestOfBody = BodyText.Substring(Index, BodyText.Length - Index)

                        RestOfBody = RestOfBody.Replace("##LISTENER_ALERT_ID:", "")

                        Index = 0

                        AlertIDString &= RestOfBody.Substring(Index, 1)
                        Index += 1

                        Do Until IsNumeric(AlertIDString) = False

                            AlertIDString &= RestOfBody.Substring(Index, 1)
                            Index += 1

                        Loop

                        AlertID = Long.Parse(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(AlertIDString))

                    End If

                End If

            Catch ex As Exception
                AlertID = 0
            Finally
                ParseAlertID = AlertID
            End Try

        End Function
        Private Function ParseAlertID(ByRef Message As MailBee.Mime.MailMessage) As Long

            'objects
            Dim AlertID As Long = 0

            Try

                If String.IsNullOrWhiteSpace(Message.BodyPlainText) = False Then

                    AlertID = ParseAlertID(Message.BodyPlainText)

                Else

                    AlertID = ParseAlertID(Message.BodyHtmlText)

                End If

            Catch ex As Exception
                AlertID = 0
            Finally
                ParseAlertID = AlertID
            End Try

        End Function
        Private Function ParseUserCode(ByRef DbContext As AdvantageFramework.Security.Database.DbContext, ByRef Employee As AdvantageFramework.Database.Views.Employee, ByRef UserCode As String) As Boolean

            'objects
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim FoundUserCode As Boolean = False

            If Employee IsNot Nothing Then

                User = AdvantageFramework.Security.Database.Procedures.User.LoadFirstUserByEmployeeCode(DbContext, Employee.Code)

                If User IsNot Nothing Then

                    UserCode = User.UserCode
                    FoundUserCode = True

                End If

            End If

            ParseUserCode = FoundUserCode

        End Function
        Private Function ParseComment(ByRef BodyText As String, ByVal StartofSignatureCode As String) As String

            'objects
            Dim Comment As String = ""
            Dim Index As Integer = -1

            If StartofSignatureCode <> "" AndAlso BodyText.Contains(StartofSignatureCode) Then

                Comment = BodyText.Substring(0, BodyText.IndexOf(StartofSignatureCode))

            End If

            If Comment = "" Then

                If BodyText.ToUpper.Contains("FROM:") Then

                    Comment = BodyText.Substring(0, BodyText.ToUpper.IndexOf("FROM:"))

                Else

                    Index = 0

                    For Each Line In Split(BodyText, vbCrLf)

                        If Index > 2 Then

                            Exit For

                        End If

                        Comment &= vbCrLf & Line
                        Index += 1

                    Next

                End If

            End If

            ParseComment = Comment.Trim

        End Function
        Private Function ParseComment(ByRef Message As MailBee.Mime.MailMessage, ByVal StartofSignatureCode As String) As String

            'objects
            Dim Comment As String = ""
            Dim BodyText As String = ""

            Try

                If String.IsNullOrWhiteSpace(Message.BodyPlainText) Then

                    Message.MakePlainBodyFromHtmlBody()

                End If

                If String.IsNullOrWhiteSpace(Message.BodyPlainText) = False Then

                    BodyText = Message.BodyPlainText

                Else

                    BodyText = TryToGetPlainTextFromMessageBodyParts(Message)

                End If

                Comment = ParseComment(BodyText, StartofSignatureCode)

            Catch ex As Exception
                Comment = ""
            Finally
                ParseComment = Comment
            End Try

        End Function
        Private Function TryToGetPlainTextFromMessageBodyParts(ByRef Message As MailBee.Mime.MailMessage) As String

            'objects
            Dim BodyText As String = ""

            Try

                If Message.BodyParts IsNot Nothing AndAlso Message.BodyParts.Count > 0 Then

                    For Each BodyPart In Message.BodyParts.OfType(Of MailBee.Mime.TextBodyPart)().ToList

                        If BodyPart.TransferEncoding = MailBee.Mime.MailTransferEncoding.QuotedPrintable Then

                            BodyText = BodyPart.Text
                            Exit For

                        End If

                    Next

                End If

            Catch ex As Exception
                BodyText = ""
            End Try

            If String.IsNullOrWhiteSpace(BodyText) Then

                BodyText = Message.BodyHtmlText

            End If

            TryToGetPlainTextFromMessageBodyParts = BodyText

        End Function
        Private Function SaveMessageID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef SavedMessageIDs As Generic.List(Of String), ByVal MessageID As String) As Boolean

            'objects
            Dim MessageIDSaved As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing
            Dim AdvantageServiceSettingList As AdvantageFramework.Database.Entities.AdvantageServiceSettingList = Nothing

            Try

                If SavedMessageIDs.Contains(MessageID) = False Then

                    If DataContext IsNot Nothing Then

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.MessageIDs)

                            If AdvantageServiceSetting IsNot Nothing Then

                                AdvantageServiceSettingList = New AdvantageFramework.Database.Entities.AdvantageServiceSettingList

                                AdvantageServiceSettingList.AdvantageServiceSettingID = AdvantageServiceSetting.ID
                                AdvantageServiceSettingList.Value = MessageID

                                If AdvantageFramework.Database.Procedures.AdvantageServiceSettingList.Insert(DataContext, AdvantageServiceSettingList) Then

                                    SavedMessageIDs.Add(MessageID)
                                    MessageIDSaved = True

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                MessageIDSaved = False
            Finally
                SaveMessageID = MessageIDSaved
            End Try

        End Function
        Private Function HasMessageBeenChecked(ByVal SavedMessageIDs As Generic.List(Of String), ByVal MessageID As String) As Boolean

            'objects
            Dim MessageHasBeenChecked As Boolean = False

            Try

                MessageHasBeenChecked = SavedMessageIDs.Contains(MessageID)

            Catch ex As Exception
                MessageHasBeenChecked = False
            Finally
                HasMessageBeenChecked = MessageHasBeenChecked
            End Try

        End Function
        Private Sub ProcessDefaultMailboxMessage(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                 ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                                 ByVal AskBlueProcessor As AdvantageFramework.Services.EmailListener.AskBlue.Processor,
                                                 ByVal Message As MailBee.Mime.MailMessage,
                                                 ByVal StartofSignatureCode As String,
                                                 ByVal SendEmailToAlertRecipients As Boolean)

            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient = Nothing
            Dim AskBlueCommandProcessed As Boolean = False
            Dim AlertID As Long = 0
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim UserCode As String = ""
            Dim AlertAttachmentAdded As Boolean = False
            Dim FileSystemFile As String = ""
            Dim ErrorMessage As String = ""
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim FilePath As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim MediaRFPHeaderStatus As AdvantageFramework.Database.Entities.MediaRFPHeaderStatus = Nothing
            Dim ResponseBy As String = Nothing
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim MediaTrafficVendorStatus As AdvantageFramework.Database.Entities.MediaTrafficVendorStatus = Nothing
            Dim EmailErrorMessage As String = ""
            Dim CommentDocument As AdvantageFramework.AlertSystem.Classes.CommentDocument = Nothing
            Dim CommentDocumentList As List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument) = Nothing
            Dim CommentDocumentListString As String = String.Empty

            AskBlueCommandProcessed = AskBlueProcessor.ProcessEmailForCommand(Message)

            If AskBlueCommandProcessed = True Then

                WriteToEventLog("AskBlue command processed")

            End If

            If AskBlueCommandProcessed = False Then

                AlertID = ParseAlertID(Message)

                If AlertID > 0 Then

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        If Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.Load(DbContext)
                                              Where Entity.AlertID = Alert.ID
                                              Select Entity).SingleOrDefault

                            If MediaRFPHeader IsNot Nothing Then

                                VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaRFPHeader.VendorCode)
                                                        Where Entity.EmailAddress.ToUpper = Message.From.Email.ToUpper
                                                        Select Entity).FirstOrDefault

                                If VendorRepresentative Is Nothing Then

                                    VendorContact = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, MediaRFPHeader.VendorCode)
                                                     Where Entity.Email.ToUpper = Message.From.Email.ToUpper AndAlso
                                                           (Entity.IsInactive Is Nothing OrElse
                                                            Entity.IsInactive = 0)
                                                     Select Entity).FirstOrDefault

                                End If

                                If VendorContact IsNot Nothing Then

                                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                                    AlertComment.DbContext = DbContext
                                    AlertComment.AlertID = Alert.ID
                                    AlertComment.VendorContactCode = VendorContact.Code
                                    AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    AlertComment.Comment = ParseComment(Message, StartofSignatureCode)

                                    ResponseBy = VendorContact.ToString

                                ElseIf VendorRepresentative IsNot Nothing Then

                                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                                    AlertComment.DbContext = DbContext
                                    AlertComment.AlertID = Alert.ID
                                    AlertComment.VendorRepresentativeCode = VendorRepresentative.Code
                                    AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    AlertComment.Comment = ParseComment(Message, StartofSignatureCode)

                                    ResponseBy = VendorRepresentative.ToString

                                End If

                                If Not String.IsNullOrWhiteSpace(ResponseBy) Then

                                    MediaRFPHeaderStatus = New AdvantageFramework.Database.Entities.MediaRFPHeaderStatus
                                    MediaRFPHeaderStatus.CreatedDate = Now
                                    MediaRFPHeaderStatus.CreatedByUserCode = ResponseBy
                                    MediaRFPHeaderStatus.MediaRFPHeaderID = MediaRFPHeader.ID
                                    MediaRFPHeaderStatus.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Response

                                    DbContext.MediaRFPHeaderStatuses.Add(MediaRFPHeaderStatus)
                                    DbContext.SaveChanges()

                                End If

                            Else

                                WriteToEventLog("Cannot find Media RFP Header")

                            End If

                        End If

                        If Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.MediaTrafficGenerated Then

                            MediaTrafficVendor = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendor.Load(DbContext)
                                                  Where Entity.AlertID = Alert.ID
                                                  Select Entity).SingleOrDefault

                            If MediaTrafficVendor IsNot Nothing Then

                                VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaTrafficVendor.VendorCode)
                                                        Where Entity.EmailAddress.ToUpper = Message.From.Email.ToUpper
                                                        Select Entity).FirstOrDefault

                                If VendorRepresentative Is Nothing Then

                                    VendorContact = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, MediaTrafficVendor.VendorCode)
                                                     Where Entity.Email.ToUpper = Message.From.Email.ToUpper AndAlso
                                                           (Entity.IsInactive Is Nothing OrElse
                                                            Entity.IsInactive = 0)
                                                     Select Entity).FirstOrDefault

                                End If

                                If VendorContact IsNot Nothing Then

                                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                                    AlertComment.DbContext = DbContext
                                    AlertComment.AlertID = Alert.ID
                                    AlertComment.VendorContactCode = VendorContact.Code
                                    AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    AlertComment.Comment = ParseComment(Message, StartofSignatureCode)

                                    ResponseBy = VendorContact.ToString

                                ElseIf VendorRepresentative IsNot Nothing Then

                                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                                    AlertComment.DbContext = DbContext
                                    AlertComment.AlertID = Alert.ID
                                    AlertComment.VendorRepresentativeCode = VendorRepresentative.Code
                                    AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    AlertComment.Comment = ParseComment(Message, StartofSignatureCode)

                                    ResponseBy = VendorRepresentative.ToString

                                End If

                                If Not String.IsNullOrWhiteSpace(ResponseBy) Then

                                    MediaTrafficVendorStatus = New AdvantageFramework.Database.Entities.MediaTrafficVendorStatus
                                    MediaTrafficVendorStatus.CreatedDate = Now
                                    MediaTrafficVendorStatus.UserCreated = ResponseBy
                                    MediaTrafficVendorStatus.MediaTrafficVendorID = MediaTrafficVendor.ID
                                    MediaTrafficVendorStatus.MediaTrafficStatusID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Response

                                    DbContext.MediaTrafficVendorStatuses.Add(MediaTrafficVendorStatus)
                                    DbContext.SaveChanges()

                                End If

                            Else

                                WriteToEventLog("Cannot find Media Traffic Vendor")

                            End If

                        End If

                        Employee = (From Entity In DbContext.Employees
                                    Where Entity.Email.ToUpper = Message.From.Email.ToUpper
                                    Select Entity).FirstOrDefault

                        If Employee Is Nothing Then

                            ClientContact = (From Entity In DbContext.ClientContact
                                             Where Entity.EmailAddress.ToUpper = Message.From.Email.ToUpper
                                             Select Entity).FirstOrDefault

                        End If

                        If ClientContact IsNot Nothing AndAlso AlertComment Is Nothing Then

                            AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                            AlertComment.DbContext = DbContext
                            AlertComment.AlertID = Alert.ID
                            AlertComment.ClientContactID = ClientContact.ContactID
                            AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            AlertComment.Comment = ParseComment(Message, StartofSignatureCode)

                        ElseIf Employee IsNot Nothing AndAlso AlertComment Is Nothing Then

                            If ParseUserCode(SecurityDbContext, Employee, UserCode) Then

                                AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                                AlertComment.DbContext = DbContext
                                AlertComment.AlertID = Alert.ID
                                AlertComment.UserCode = UserCode
                                AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                AlertComment.Comment = ParseComment(Message, StartofSignatureCode)

                            Else

                                WriteToEventLog("Failed to load valid user code for employee: " & Employee.ToString & " for email: " & Message.From.Email)

                            End If

                        End If

                        If AlertComment Is Nothing Then

                            If Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated Then

                                WriteToEventLog("Cannot find vendor rep or employee for Media RFP alert with email: " & Message.From.Email)

                            ElseIf Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.MediaTrafficGenerated Then

                                WriteToEventLog("Cannot find vendor rep or employee for Media Traffic alert with email: " & Message.From.Email)

                            Else

                                WriteToEventLog("Failed to find email address in system for email: " & Message.From.Email)

                            End If

                        End If

                        If AlertComment IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                                For Each ClientPortalAlertRecipient In AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertID(DbContext, Alert.ID).ToList

                                    ClientPortalAlertRecipient.HasBeenRead = Nothing
                                    ClientPortalAlertRecipient.ProcessedDate = Nothing

                                    AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Update(DbContext, ClientPortalAlertRecipient)

                                Next

                                For Each ClientPortalAlertRecipientDismissed In AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID).ToList

                                    ClientPortalAlertRecipient = New AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                                    ClientPortalAlertRecipient.DbContext = DbContext

                                    ClientPortalAlertRecipient.AlertID = ClientPortalAlertRecipientDismissed.AlertID
                                    ClientPortalAlertRecipient.AlertRecipientID = ClientPortalAlertRecipientDismissed.AlertRecipientID
                                    ClientPortalAlertRecipient.ClientContactID = ClientPortalAlertRecipientDismissed.ClientContactID
                                    ClientPortalAlertRecipient.EmailAddress = ClientPortalAlertRecipientDismissed.EmailAddress
                                    ClientPortalAlertRecipient.ProcessedDate = Nothing
                                    ClientPortalAlertRecipient.IsNewAlert = ClientPortalAlertRecipientDismissed.IsNewAlert
                                    ClientPortalAlertRecipient.HasBeenRead = Nothing

                                    If AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.Delete(DbContext, ClientPortalAlertRecipientDismissed) Then

                                        AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Insert(DbContext, ClientPortalAlertRecipient)

                                    End If

                                Next

                                For Each AlertRecipient In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alert.ID).ToList

                                    AlertRecipient.HasBeenRead = Nothing
                                    AlertRecipient.ProcessedDate = Nothing

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient)

                                Next

                                For Each AlertRecipientDismissed In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID).ToList

                                    AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                    AlertRecipient.DbContext = DbContext

                                    AlertRecipient.AlertID = AlertRecipientDismissed.AlertID
                                    AlertRecipient.ID = AlertRecipientDismissed.ID
                                    AlertRecipient.EmployeeCode = AlertRecipientDismissed.EmployeeCode
                                    AlertRecipient.EmployeeEmail = AlertRecipientDismissed.EmployeeEmail
                                    AlertRecipient.ProcessedDate = Nothing
                                    AlertRecipient.IsNewAlert = AlertRecipientDismissed.IsNewAlert
                                    AlertRecipient.HasBeenRead = Nothing

                                    If AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Delete(DbContext, AlertRecipientDismissed) Then

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                                    End If

                                Next

                                WriteToEventLog("Alert comment added for alert id: " & Alert.ID)

                            Else

                                WriteToEventLog("Failed to insert alert comment")

                            End If

                            For Each Attachment As MailBee.Mime.Attachment In Message.Attachments.OfType(Of MailBee.Mime.Attachment)()

                                If Attachment.IsInline = False Then

                                    AlertAttachmentAdded = False
                                    FileSystemFile = ""
                                    ErrorMessage = ""

                                    If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                                        If Attachment.SaveToFolder(My.Application.Info.DirectoryPath, True) Then

                                            If AdvantageFramework.FileSystem.Add(Agency, AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & Attachment.Filename, "", "", UserCode, "Alert View", "Attached Doc", FileSystem.DocumentSource.Alert, FileSystemFile) Then

                                                Document = New AdvantageFramework.Database.Entities.Document

                                                Document.DbContext = DbContext
                                                Document.FileName = Attachment.Filename
                                                Document.MIMEType = Attachment.ContentType
                                                Document.FileSystemFileName = AdvantageFramework.FileSystem.GetFileName(FileSystemFile)
                                                Document.FileSize = Attachment.Size
                                                Document.DocumentTypeID = 2
                                                Document.IsPrivate = 0
                                                Document.UploadedDate = Now

                                                If ClientContact IsNot Nothing Then

                                                    Document.UserCode = ClientContact.ContactID

                                                ElseIf Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated Then

                                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Alert.VendorCode)

                                                    If Vendor IsNot Nothing Then

                                                        Document.Description = Vendor.Name

                                                    End If

                                                    Document.UserCode = UserCode

                                                Else

                                                    Document.UserCode = UserCode

                                                End If

                                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                    AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                                                    AlertAttachment.DbContext = DbContext
                                                    AlertAttachment.DocumentID = Document.ID
                                                    AlertAttachment.AlertID = Alert.ID
                                                    AlertAttachment.GeneratedDate = Now

                                                    If ClientContact IsNot Nothing Then

                                                        AlertAttachment.ClientContactID = ClientContact.ContactID

                                                    ElseIf Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated Then

                                                        AlertAttachment.UserCode = Alert.UserCode

                                                    Else

                                                        AlertAttachment.UserCode = UserCode

                                                    End If

                                                    AlertAttachment.HasEmailBeenSent = 0

                                                    AlertAttachmentAdded = AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                                                    Try

                                                        CommentDocument = Nothing
                                                        CommentDocument = New AlertSystem.Classes.CommentDocument

                                                        CommentDocument.Filename = Document.FileName
                                                        CommentDocument.DocumentId = Document.ID
                                                        CommentDocument.MimeType = Document.MIMEType

                                                        If CommentDocumentList Is Nothing Then CommentDocumentList = New List(Of AlertSystem.Classes.CommentDocument)

                                                        CommentDocumentList.Add(CommentDocument)

                                                    Catch ex As Exception
                                                        WriteToEventLog("Failed to add document link to comment.  Reason:  " &
                                                                        Environment.NewLine &
                                                                        AdvantageFramework.StringUtilities.FullErrorToString(ex))

                                                    End Try

                                                End If

                                            End If

                                            Try

                                                My.Computer.FileSystem.DeleteFile(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & Attachment.Filename)

                                            Catch ex As Exception

                                            End Try

                                        End If

                                    End If

                                    If AlertAttachmentAdded Then

                                        WriteToEventLog("Alert attachment added for alert id: " & Alert.ID)

                                    Else

                                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                            WriteToEventLog("Failed to add alert attachment in system. Reason: " & ErrorMessage)

                                        Else

                                            WriteToEventLog("Failed to add alert attachment in system")

                                        End If

                                    End If

                                End If

                            Next

                            Try

                                If CommentDocumentList IsNot Nothing AndAlso CommentDocumentList.Count > 0 Then

                                    CommentDocument = New AdvantageFramework.AlertSystem.Classes.CommentDocument

                                    CommentDocumentListString = CommentDocument.ObjectToString(CommentDocumentList)

                                    If Not String.IsNullOrWhiteSpace(CommentDocumentListString) Then

                                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ALERT_COMMENT] SET DOCUMENT_LIST = '{0}' WHERE COMMENT_ID = {1} AND ALERT_ID = {2}",
                                                                                       CommentDocumentListString,
                                                                                       AlertComment.ID,
                                                                                       AlertComment.AlertID))

                                    End If

                                End If

                            Catch ex As Exception
                                WriteToEventLog("Failed to add document links to comment. Reason:" &
                                                Environment.NewLine &
                                                AdvantageFramework.StringUtilities.FullErrorToString(ex))
                            End Try

                            If SendEmailToAlertRecipients Then

                                If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) Then

                                    If AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, "[Alert Updated]",
                                                                                             IncludeOriginator:=True, FromEmployeeCode:=If(Employee IsNot Nothing, Employee.Code, String.Empty), ErrorMessage:=EmailErrorMessage) Then

                                        WriteToEventLog("Alert email sent for alert id: " & Alert.ID & " - " & EmailErrorMessage)

                                    Else

                                        WriteToEventLog("Failed to send alert email for alert id: " & Alert.ID)

                                    End If

                                Else

                                    If AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, "[Alert Updated]",
                                                                                             IncludeOriginator:=False, FromEmployeeCode:=If(Employee IsNot Nothing, Employee.Code, String.Empty), ErrorMessage:=EmailErrorMessage) Then

                                        WriteToEventLog("Alert email sent for alert id: " & Alert.ID & " - " & EmailErrorMessage)

                                    Else

                                        WriteToEventLog("Failed to send alert email for alert id: " & Alert.ID)

                                    End If

                                End If

                            End If

                        End If

                    Else

                        WriteToEventLog("Failed to find alert in system.")

                    End If

                Else

                    WriteToEventLog("Failed to parse alert id from email message.")

                End If

            End If

        End Sub
        Private Sub ProcessAccountsPayableInvoicesMessage(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                                          ByVal Message As MailBee.Mime.MailMessage)

            'objects
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim Attachments As Generic.List(Of MailBee.Mime.Attachment) = Nothing
            Dim PDFAttachments As Generic.List(Of MailBee.Mime.Attachment) = Nothing
            Dim InvoiceSaved As Boolean = False
            Dim ImportDirectory As String = Nothing

            If Message IsNot Nothing AndAlso Message.HasAttachments Then

                Attachments = Message.Attachments.OfType(Of MailBee.Mime.Attachment).Where(Function(mailAttachment) mailAttachment.Filename.ToUpper.EndsWith(".DAT") OrElse mailAttachment.Filename.ToUpper.EndsWith(".BUY") OrElse mailAttachment.Filename.ToUpper.EndsWith(".TXT")).ToList
                PDFAttachments = Message.Attachments.OfType(Of MailBee.Mime.Attachment).Where(Function(mailAttachment) mailAttachment.Filename.ToUpper.EndsWith(".PDF")).ToList

                If Attachments IsNot Nothing AndAlso Attachments.Count > 0 Then

                    WriteToEventLog("Processing Email Attachments...")

                    ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast).FirstOrDefault

                    If Agency.IsASP.GetValueOrDefault(0) Then

                        ImportDirectory = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath, "\")

                        ImportDirectory = AdvantageFramework.Importing.GetHostedDirectory(ImportTemplate.Type, ImportDirectory)

                    Else

                        ImportDirectory = ImportTemplate.DefaultDirectory

                    End If

                    If Not String.IsNullOrWhiteSpace(ImportDirectory) Then

                        For Each Attachment In Attachments

                            WriteToEventLog("Processing Attachment --> " & Attachment.Filename)
                            WriteToEventLog("Saving file to default directory --> " & ImportDirectory)

                            Try

                                If Attachment.SaveToFolder(ImportDirectory, True) Then

                                    WriteToEventLog("File saved to directory --> " & ImportDirectory)

                                    For Each PDFAttachment In PDFAttachments

                                        PDFAttachment.Save(ImportDirectory & If(ImportDirectory.EndsWith("\"), "", "\") & Attachment.Name & ".pdf", True)

                                    Next

                                Else

                                    WriteToEventLog("Unable to save file directory --> " & ImportDirectory)

                                End If

                            Catch ex As Exception
                                WriteToEventLog("Error saving file to directory --> " & ImportDirectory)
                            End Try

                        Next

                    Else

                        WriteToEventLog("Import Template does not have a default directory --> " & ImportTemplate.Name)

                    End If

                Else

                    WriteToEventLog("Message does not have any .DAT or .BUY attachments.")

                End If

            Else

                WriteToEventLog("Message does not have any .DAT or .BUY attachments.")

            End If

        End Sub
        Private Sub ProcessExpenseReportReceiptsMessage(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                                 ByVal Message As MailBee.Mime.MailMessage)


            Dim AskBlueCommandProcessed As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeAddlEmails As AdvantageFramework.Database.Entities.EmployeeAdditionalEmail = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim UserCode As String = ""
            Dim AlertAttachmentAdded As Boolean = False
            Dim FileSystemFile As String = ""
            Dim ErrorMessage As String = ""
            Dim FilePath As String = Nothing
            Dim ResponseBy As String = Nothing

            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim ExpenseReportDocumentUnassigned As AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned = Nothing
            Dim ExpenseDate As Date = Nothing
            Dim FilenameToSave As String = ""
            Dim ProcessedExpenseAction As Boolean = False

            If Message IsNot Nothing AndAlso Message.HasAttachments Then

                ExpenseDate = IIf(IsDate(Message.Date), CType(CType(Message.Date, Date).ToShortDateString(), Date), CType(Now.Date.ToShortDateString(), Date))
                Document = New AdvantageFramework.Database.Entities.Document

                Services.EmailListener.WriteToEventLog("Expense Command found")

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency Is Nothing Then

                    Services.EmailListener.WriteToEventLog("Cannot load Agency")
                    Exit Sub

                End If

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, Message.From.Email)

                If Employee Is Nothing Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, Message.From.Email.ToLower)

                    If Employee Is Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, Message.From.Email.ToUpper)

                        If Employee Is Nothing Then

                            Try

                                Employee = (From Entity In DbContext.Employees
                                            Where Entity.Email.ToUpper = Message.From.Email.ToUpper
                                            Select Entity).FirstOrDefault

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                        End If

                    End If

                End If

                If Employee Is Nothing Then

                    EmployeeAddlEmails = AdvantageFramework.Database.Procedures.EmployeeAdditionalEmail.LoadByEmployeeEmail(DbContext, Message.From.Email)

                    If EmployeeAddlEmails Is Nothing Then

                        EmployeeAddlEmails = AdvantageFramework.Database.Procedures.EmployeeAdditionalEmail.LoadByEmployeeEmail(DbContext, Message.From.Email.ToLower)

                        If EmployeeAddlEmails Is Nothing Then

                            EmployeeAddlEmails = AdvantageFramework.Database.Procedures.EmployeeAdditionalEmail.LoadByEmployeeEmail(DbContext, Message.From.Email.ToUpper)

                            If EmployeeAddlEmails Is Nothing Then

                                Try

                                    EmployeeAddlEmails = (From Entity In DbContext.EmployeeAdditionalEmails
                                                          Where Entity.Email.ToUpper = Message.From.Email.ToUpper
                                                          Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    Employee = Nothing
                                End Try

                            End If

                        End If

                    End If

                End If

                If EmployeeAddlEmails IsNot Nothing Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeAddlEmails.EmployeeCode)

                End If

                If Employee Is Nothing Then

                    Services.EmailListener.WriteToEventLog("Cannot load Employee")
                    Exit Sub

                End If

                For Each Attachment As MailBee.Mime.Attachment In Message.Attachments.OfType(Of MailBee.Mime.Attachment)()

                    If Attachment.IsInline = False Then

                        FileSystemFile = ""
                        ErrorMessage = ""

                        If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                            FilenameToSave = AdvantageFramework.FileSystem.AddDateGUID(Attachment.Filename)

                            If Attachment.SaveToFolder(My.Application.Info.DirectoryPath, True) Then

                                If AdvantageFramework.FileSystem.Add(Agency, AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") &
                                                                                     FilenameToSave, "", "", Employee.Code, "Expense",
                                                                                     "Attached Doc", FileSystem.DocumentSource.DocumentUpload, FileSystemFile, Attachment.GetData()) Then

                                    Document = New AdvantageFramework.Database.Entities.Document

                                    With Document

                                        .DbContext = DbContext
                                        .FileName = FilenameToSave
                                        .MIMEType = Attachment.ContentType
                                        .FileSystemFileName = AdvantageFramework.FileSystem.GetFileName(FileSystemFile)
                                        .FileSize = Attachment.Size
                                        .DocumentTypeID = 3
                                        .IsPrivate = 0
                                        .UploadedDate = Now
                                        .UserCode = DbContext.UserCode
                                        .Description = "Expense Receipt for " & Employee.Code

                                    End With

                                    If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                        ExpenseReportDocumentUnassigned = New AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned

                                        With ExpenseReportDocumentUnassigned

                                            .DbContext = DbContext
                                            .DocumentID = Document.ID
                                            .EmployeeCode = Employee.Code

                                        End With

                                        If AdvantageFramework.Database.Procedures.ExpenseReportDocumentUnassigned.Insert(DbContext, ExpenseReportDocumentUnassigned) = True Then

                                            Services.EmailListener.WriteToEventLog("Document added for unassigned")

                                        End If

                                    End If

                                End If

                                Try

                                    My.Computer.FileSystem.DeleteFile(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & FilenameToSave)

                                Catch ex As Exception

                                End Try

                            End If

                        Else

                            Services.EmailListener.WriteToEventLog("Document failed to add for unassigned:  Reason: " & ErrorMessage)

                        End If

                    End If

                Next

                If ExpenseReport IsNot Nothing AndAlso Employee IsNot Nothing AndAlso Message IsNot Nothing Then

                    For Each Attachment As MailBee.Mime.Attachment In Message.Attachments.OfType(Of MailBee.Mime.Attachment)()

                        If Attachment.IsInline = False Then

                            FileSystemFile = ""
                            ErrorMessage = ""

                            If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                                FilenameToSave = AdvantageFramework.FileSystem.AddDateGUID(Attachment.Filename)

                                If Attachment.SaveToFolder(My.Application.Info.DirectoryPath, True) Then

                                    If AdvantageFramework.FileSystem.Add(Agency, AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") &
                                                                                 FilenameToSave, "", "", ExpenseReport.EmployeeCode, "Expense",
                                                                                 "Attached Doc", FileSystem.DocumentSource.DocumentUpload, FileSystemFile, Attachment.GetData()) Then

                                        Document = New AdvantageFramework.Database.Entities.Document

                                        With Document

                                            .DbContext = DbContext
                                            .FileName = FilenameToSave
                                            .MIMEType = Attachment.ContentType
                                            .FileSystemFileName = AdvantageFramework.FileSystem.GetFileName(FileSystemFile)
                                            .FileSize = Attachment.Size
                                            .DocumentTypeID = 3
                                            .IsPrivate = 0
                                            .UploadedDate = Now
                                            .UserCode = DbContext.UserCode
                                            .Description = "Invoice Number: " & ExpenseReport.InvoiceNumber

                                        End With

                                        If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                            ExpenseReportDocument = New AdvantageFramework.Database.Entities.ExpenseReportDocument

                                            With ExpenseReportDocument

                                                .DbContext = DbContext
                                                .DocumentID = Document.ID
                                                .InvoiceNumber = ExpenseReport.InvoiceNumber

                                            End With

                                            If AdvantageFramework.Database.Procedures.ExpenseReportDocument.Insert(DbContext, ExpenseReportDocument) = True Then

                                                Services.EmailListener.WriteToEventLog("Document added for expense report: " & ExpenseReport.InvoiceNumber)

                                            End If

                                        End If

                                    End If

                                    Try

                                        My.Computer.FileSystem.DeleteFile(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & FilenameToSave)

                                    Catch ex As Exception

                                    End Try

                                End If

                            Else

                                Services.EmailListener.WriteToEventLog("Document failed to add for expense report: " & ExpenseReport.InvoiceNumber & "Reason: " & ErrorMessage)

                            End If

                        End If

                    Next

                End If

                WriteToEventLog("Expense command processed")

            Else

                WriteToEventLog("Message does not have any receipt attachments.")

            End If




            'AskBlueCommandProcessed = AskBlueProcessor.ProcessEmailForCommand(Message)

            'If AskBlueCommandProcessed = True Then

            '    WriteToEventLog("AskBlue command processed")

            'End If



        End Sub
        Private Function InitMailBeePop3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByRef AuthenticationMethod As MailBee.AuthenticationMethods) As MailBee.Pop3Mail.Pop3

            'objects
            Dim POP3 As MailBee.Pop3Mail.Pop3 = Nothing
            Dim Connected As Boolean = False
            Dim LoggedIn As Boolean = False

            Try

                MailBee.Global.LicenseKey = AdvantageFramework.Email.MailBeeDotNetKey

                POP3 = New MailBee.Pop3Mail.Pop3

                POP3.RaiseEvents = True

                If Agency.POP3SecureType.GetValueOrDefault(0) <> AdvantageFramework.Email.POP3SecureTypes.NoSecureProtocol Then

                    If Agency.POP3SecureType.GetValueOrDefault(0) = AdvantageFramework.Email.POP3SecureTypes.UseTLS Then

                        POP3.SslMode = MailBee.Security.SslStartupMode.UseStartTls

                    End If

                End If

                If Agency.POP3PortNumber IsNot Nothing Then

                    Connected = POP3.Connect(Agency.POP3Server, Agency.POP3PortNumber)

                Else

                    Connected = POP3.Connect(Agency.POP3Server)

                End If

                If Connected = True Then

                    If Agency.POP3AuthenticationMethod IsNot Nothing Then

                        Select Case Agency.POP3AuthenticationMethod

                            Case 0

                                AuthenticationMethod = MailBee.AuthenticationMethods.None

                            Case 1

                                AuthenticationMethod = MailBee.AuthenticationMethods.Regular

                            Case 3

                                AuthenticationMethod = MailBee.AuthenticationMethods.SaslCramMD5

                            Case 4

                                AuthenticationMethod = MailBee.AuthenticationMethods.SaslNtlm

                            Case 5

                                AuthenticationMethod = MailBee.AuthenticationMethods.SaslMsn

                            Case Else

                                AuthenticationMethod = MailBee.AuthenticationMethods.Auto

                        End Select

                    End If

                Else

                    POP3 = Nothing

                End If

            Catch ex As Exception

                WriteToEventLog(ex.Message)
                POP3 = Nothing

            Finally

                InitMailBeePop3 = POP3

            End Try

        End Function
        Private Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency) As MailBee.Pop3Mail.Pop3

            CreateMailBeePOP3 = CreateMailBeePOP3(Agency, Agency.POP3UserName, AdvantageFramework.Security.Encryption.Decrypt(Agency.POP3Password))

        End Function
        Private Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal POP3EmailListenerAccount As AdvantageFramework.Database.Entities.POP3EmailListenerAccount) As MailBee.Pop3Mail.Pop3

            CreateMailBeePOP3 = CreateMailBeePOP3(Agency, POP3EmailListenerAccount.UserName, AdvantageFramework.Security.Encryption.Decrypt(POP3EmailListenerAccount.Password))

        End Function
        Private Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount) As MailBee.Pop3Mail.Pop3

            CreateMailBeePOP3 = CreateMailBeePOP3(Agency, POP3AutomatedAssignmentAccount.UserName, AdvantageFramework.Security.Encryption.Decrypt(POP3AutomatedAssignmentAccount.Password))

        End Function
        Private Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal UserName As String, ByVal Password As String) As MailBee.Pop3Mail.Pop3

            Dim POP3 As MailBee.Pop3Mail.Pop3 = Nothing
            Dim LoggedIn As Boolean = False
            Dim AuthenticationMethod As MailBee.AuthenticationMethods = MailBee.AuthenticationMethods.None

            Try

                POP3 = InitMailBeePop3(Agency, AuthenticationMethod)

                If POP3 IsNot Nothing Then

                    LoggedIn = POP3.Login(UserName, Password, AuthenticationMethod)

                End If

                If Not LoggedIn Then

                    POP3 = Nothing

                End If

            Catch ex As Exception

                WriteToEventLog(ex.Message)
                POP3 = Nothing

            Finally

                CreateMailBeePOP3 = POP3

            End Try

        End Function
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim POP3Listener As MailBee.Pop3Mail.Pop3 = Nothing
            Dim AlertID As Long = 0
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim MessageIDs As String()
            Dim Message As MailBee.Mime.MailMessage = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertAttachmentAdded As Boolean = False
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim AskBlueProcessor As AdvantageFramework.Services.EmailListener.AskBlue.Processor = Nothing
            Dim POP3EmailListenerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.POP3EmailListenerAccount) = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim FileSystemFile As String = ""
            Dim UserCode As String = ""
            Dim AskBlueCommandProcessed As Boolean = False
            Dim RunAtEvery As Integer = 0
            Dim StartofSignatureCode As String = ""
            Dim SendEmailToAlertRecipients As Boolean = True
            Dim SavedMessageIDs As Generic.List(Of String) = Nothing
            Dim AlertSubjectMaxLength As Long = 0
            Dim ErrorMessage As String = ""
            Dim MessageIDPrefix As String = ""
            Dim POP3EmailListenerAccountType As AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes = Database.Entities.Methods.POP3EmailListenerAccountTypes.Default

            If DatabaseProfile IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If Agency IsNot Nothing Then

                                LoadSettings(DataContext, RunAtEvery, StartofSignatureCode, SendEmailToAlertRecipients)

                                Try

                                    AlertSubjectMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Alert.Properties.Subject))

                                Catch ex As Exception
                                    AlertSubjectMaxLength = 0
                                End Try

                                If AlertSubjectMaxLength = 0 Then

                                    AlertSubjectMaxLength = 250

                                End If

                                WriteToEventLog("Connecting to email server --> " & DatabaseProfile.DatabaseName & " - " & Agency.POP3Server)

                                POP3EmailListenerAccounts = AdvantageFramework.Database.Procedures.POP3EmailListenerAccount.LoadAndIncludeAgencyDefault(DbContext, Agency)

                                SavedMessageIDs = LoadSavedMessageIDs(DataContext)

                                For Each POP3EmailListenerAccount In POP3EmailListenerAccounts

                                    AskBlueProcessor = Nothing
                                    POP3Listener = Nothing
                                    MessageIDPrefix = Nothing

                                    POP3EmailListenerAccountType = CType(POP3EmailListenerAccount.AccountType, AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes)

                                    WriteToEventLog("Processing """ & AdvantageFramework.StringUtilities.GetNameAsWords(POP3EmailListenerAccountType.ToString) & """ E-Mail Listener Account")

                                    Select Case POP3EmailListenerAccountType

                                        Case AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.Default

                                            AskBlueProcessor = New AdvantageFramework.Services.EmailListener.AskBlue.Processor(DatabaseProfile)
                                            POP3Listener = CreateMailBeePOP3(Agency)

                                        Case AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.AccountsPayableInvoices

                                            POP3Listener = CreateMailBeePOP3(Agency, POP3EmailListenerAccount)
                                            MessageIDPrefix = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.AccountsPayableInvoices).Code & "_"

                                        Case AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.ExpenseReportReceipts

                                            POP3Listener = CreateMailBeePOP3(Agency, POP3EmailListenerAccount)
                                            MessageIDPrefix = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.ExpenseReportReceipts).Code & "_"

                                    End Select

                                    If POP3Listener IsNot Nothing Then

                                        WriteToEventLog("Connected to email server --> " & Agency.POP3Server)

                                        MessageIDs = POP3Listener.GetMessageUids

                                        If Not String.IsNullOrWhiteSpace(MessageIDPrefix) Then

                                            MessageIDs = (From MessageID In MessageIDs
                                                          Select MessageIDPrefix & MessageID).ToArray

                                        End If

                                        WriteToEventLog("Checking for new message(s) --> " & POP3EmailListenerAccount.UserName)

                                        For MesseageIndex As Integer = 0 To POP3Listener.InboxMessageCount - 1

                                            If Not HasMessageBeenChecked(SavedMessageIDs, MessageIDs(MesseageIndex)) Then

                                                'mailbee index starts at one, every other index starts at zero
                                                Message = POP3Listener.DownloadEntireMessage(MesseageIndex + 1)

                                                If Message IsNot Nothing Then

                                                    WriteToEventLog("New Message --> From: " & Message.From.Email & "   Subject: " & Message.Subject)

                                                    Try

                                                        Select Case POP3EmailListenerAccountType

                                                            Case AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.Default

                                                                ProcessDefaultMailboxMessage(DataContext, DbContext, SecurityDbContext, Agency, AskBlueProcessor, Message, StartofSignatureCode, SendEmailToAlertRecipients)

                                                            Case AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.AccountsPayableInvoices

                                                                ProcessAccountsPayableInvoicesMessage(DbContext, Agency, Message)

                                                            Case AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.ExpenseReportReceipts

                                                                ProcessExpenseReportReceiptsMessage(DbContext, Agency, Message)

                                                        End Select

                                                    Catch ex As Exception

                                                    End Try

                                                    If SaveMessageID(DataContext, SavedMessageIDs, MessageIDs(MesseageIndex)) Then

                                                        WriteToEventLog("Saved message --> Message ID: " & MessageIDs(MesseageIndex) & " Message Index: " & MesseageIndex)

                                                    Else

                                                        WriteToEventLog("Failed to save message --> Message ID: " & MessageIDs(MesseageIndex) & " Message Index: " & MesseageIndex)

                                                    End If

                                                    If POP3EmailListenerAccount.DeleteProcessed.GetValueOrDefault(0) = 1 Then

                                                        If POP3Listener.DeleteMessage(MesseageIndex + 1) Then

                                                            WriteToEventLog("Deleted message --> Message ID: " & MessageIDs(MesseageIndex) & " Message Index: " & MesseageIndex)

                                                        Else

                                                            WriteToEventLog("Failed to delete message --> Message ID: " & MessageIDs(MesseageIndex) & " Message Index: " & MesseageIndex)

                                                        End If

                                                    End If

                                                Else

                                                    WriteToEventLog("Failed to download message --> Message ID: " & MessageIDs(MesseageIndex) & " Message Index: " & MesseageIndex)

                                                End If

                                            End If

                                        Next

                                        POP3Listener.Disconnect()

                                    Else

                                        WriteToEventLog("Failed to connect email server --> " & Agency.POP3Server)

                                    End If

                                Next

                            Else

                                WriteToEventLog("Failed to load agency from database --> " & DatabaseProfile.DatabaseName)

                            End If

                        End Using

                    End Using

                End Using

            End If

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim RunAtEvery As Integer = 0
            Dim LastRanAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.RunAtEvery), RunAtEvery)
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.LastRanAt), LastRanAt)

                                LastRanAt = LastRanAt.AddMinutes(RunAtEvery)

                                If DateDiff(DateInterval.Minute, LastRanAt, Now) >= 0 Then

                                    LastRanAt = Now

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.LastRanAt, LastRanAt)

                                    ServiceIsReadyToRun = True

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                End Try

            End If

            IsServiceReadyToRun = ServiceIsReadyToRun

        End Function
        Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            If DatabaseProfile IsNot Nothing Then

                Try

                    If IsServiceReadyToRun(DatabaseProfile) Then

                        ProcessDatabase(DatabaseProfile)

                    End If

                Catch ex As Exception
                    WriteToEventLog("Error -->" & ex.Message)
                End Try

                WriteToEventLog("Running")

            End If

        End Sub
        Public Function LoadLogEntries() As String

            'objects
            Dim Log As String = ""

            Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

            LoadLogEntries = Log

        End Function
        Public Function LoadLog(ByVal LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

            'objects
            Dim Log As String = ""
            Dim Entry As System.Diagnostics.EventLogEntry = Nothing

            If System.Diagnostics.EventLog.SourceExists("Adv Email Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Adv Email Source", "Adv Email Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Adv Email Log", My.Computer.Name, "Adv Email Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

            If LoadEntries Then

                Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

                Try

                    Entry = _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated).FirstOrDefault

                Catch ex As Exception
                    Entry = Nothing
                End Try

                If Entry IsNot Nothing Then

                    LastEntryMessage = Entry.Message & "...."

                End If

            End If

            LoadLog = Log

        End Function
        Private Function LoadSavedMessageIDs(ByVal DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of String)

            'objects
            Dim SavedMessageIDs As Generic.List(Of String) = Nothing
            Dim MessageID As String = ""
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.MessageIDs)

                If AdvantageServiceSetting IsNot Nothing Then

                    SavedMessageIDs = New Generic.List(Of String)

                    For Each AdvantageServiceSettingList In LoadAdvantageServiceSettingList(DataContext, AdvantageServiceSetting.ID)

                        If IsNothing(AdvantageServiceSettingList.Value) = False Then

                            Try

                                MessageID = AdvantageServiceSettingList.Value.ToString

                            Catch ex As Exception
                                MessageID = ""
                            End Try

                            If String.IsNullOrEmpty(MessageID) = False Then

                                SavedMessageIDs.Add(MessageID)

                            End If

                        End If

                    Next

                End If

            End If

            LoadSavedMessageIDs = SavedMessageIDs

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.EmailListener.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.EmailListener.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.EmailListener.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAtEvery As Integer, ByRef StartofSignatureCode As String, ByRef SendEmailToAlertRecipients As Boolean, Optional ByRef LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.RunAtEvery), RunAtEvery)

                StartofSignatureCode = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.StartofSignatureCode)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.SendEmailToAlertRecipients), SendEmailToAlertRecipients)

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.LastRanAt), LastRanAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAtEvery As Integer, ByVal StartofSignatureCode As String, ByVal SendEmailToAlertRecipients As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousRunAtEvery As Integer = 0
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.RunAtEvery, RunAtEvery)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.StartofSignatureCode, StartofSignatureCode)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.EmailListener.RegistrySetting.SendEmailToAlertRecipients, SendEmailToAlertRecipients)

            End If

            'Integer.TryParse(AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadEmailListenerRegistryKey, AdvantageFramework.Services.EmailListener.RegistrySetting.RunAtEvery), PreviousRunAtEvery)

            'If PreviousRunAtEvery <> RunAtEvery Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.EmailListener.CustomCommand.LoadSettings)

            '    End If

            'End If

        End Sub
        Public Sub WriteToEventLog(Message As String)

            Try

                SyncLock _EventLog

                    _EventLog.WriteEntry(Message)

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearLog()

            Try

                SyncLock _EventLog

                    _EventLog.Clear()

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Module

End Namespace

