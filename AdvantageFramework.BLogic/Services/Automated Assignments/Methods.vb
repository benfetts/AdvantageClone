Namespace Services.AutomatedAssignments

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "

        Private Const _AutomatedAssignmentMessageTemplate As String = "{0} From {1} {2} | {3}"

#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Automated Assignments\", "RunAtEvery", "1")>
            RunAtEvery
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Automated Assignments\", "LastRanAt", "01/01/2001 01:00 AM")>
            LastRanAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Automated Assignments\", "MessageIDs", "")>
            MessageIDs
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

        Private Sub _EventLog_EntryWritten(sender As Object, e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Public Sub ProcessDatabase(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim POP3Listener As MailBee.Pop3Mail.Pop3 = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim MessageIDs As String()
            Dim Message As MailBee.Mime.MailMessage = Nothing
            Dim POP3AutomatedAssignmentAccounts As Generic.List(Of AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount) = Nothing
            Dim RunAtEvery As Integer = 0
            Dim SavedMessageIDs As Generic.List(Of String) = Nothing
            Dim AlertSubjectMaxLength As Long = 0
            Dim ErrorMessage As String = String.Empty
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertTypes = Database.Entities.Methods.AlertTypes.Alert
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategories = Database.Entities.Methods.AlertCategories.AlertAction
            Dim EmailSent As Boolean = False
            Dim AlertCreated As Boolean = False
            Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim ClientJobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
            Dim AutomatedAssignmentMessage As String = String.Empty
            Dim AlertID As Integer = 0
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim ExtraMessageToSendWithReplyBackEmail As String = String.Empty

            If DatabaseProfile IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Session = New AdvantageFramework.Security.Session(Security.Methods.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If Agency IsNot Nothing Then

                                LoadSettings(DataContext, RunAtEvery)

                                Try

                                    AlertSubjectMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Alert.Properties.Subject))

                                Catch ex As Exception
                                    AlertSubjectMaxLength = 0
                                End Try

                                If AlertSubjectMaxLength = 0 Then

                                    AlertSubjectMaxLength = 250

                                End If

                                WriteToEventLog("Connecting to email server --> " & DatabaseProfile.DatabaseName & " - " & Agency.POP3Server)

                                POP3AutomatedAssignmentAccounts = AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Load(DbContext).ToList

                                SavedMessageIDs = LoadSavedMessageIDs(DataContext)

                                For Each POP3AutomatedAssignmentAccount In POP3AutomatedAssignmentAccounts

                                    POP3Listener = Nothing
                                    WriteToEventLog("Processing """ & POP3AutomatedAssignmentAccount.Description & """ Automated Assignment Account")

                                    POP3Listener = AdvantageFramework.Email.CreateMailBeePOP3(Agency, POP3AutomatedAssignmentAccount)
                                    JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, POP3AutomatedAssignmentAccount.JobNumber.GetValueOrDefault(0), POP3AutomatedAssignmentAccount.JobComponentNumber.GetValueOrDefault(0))

                                    If POP3Listener IsNot Nothing Then

                                        WriteToEventLog("Connected to email server --> " & Agency.POP3Server)

                                        MessageIDs = POP3Listener.GetMessageUids

                                        MessageIDs = (From MessageID In MessageIDs
                                                      Select POP3AutomatedAssignmentAccount.ID & "_" & MessageID).ToArray

                                        WriteToEventLog("Checking for new message(s) --> " & POP3AutomatedAssignmentAccount.UserName)

                                        For MesseageIndex As Integer = 0 To POP3Listener.InboxMessageCount - 1

                                            ClientJobComponentView = Nothing

                                            If Not HasMessageBeenChecked(SavedMessageIDs, MessageIDs(MesseageIndex)) Then

                                                'mailbee index starts at one, every other index starts at zero
                                                Message = POP3Listener.DownloadEntireMessage(MesseageIndex + 1)

                                                Message.Parser.WorkingFolder = Agency.ImportPath

                                                EmailSent = False
                                                AlertCreated = False
                                                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
                                                AlertID = 0

                                                If Message IsNot Nothing Then

                                                    WriteToEventLog("New Message --> From: " & Message.From.Email & "   Subject: " & Message.Subject)
                                                    '=============
                                                    'Process Message
                                                    '=============

                                                    If POP3AutomatedAssignmentAccount.IncludeEmployeeContacts Then

                                                        Try

                                                            Employee = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).Include("Office")
                                                                        Where Entity.Email.ToUpper = Message.From.Email.ToUpper
                                                                        Select Entity).FirstOrDefault

                                                        Catch ex As Exception
                                                            Employee = Nothing
                                                        End Try

                                                    End If

                                                    If POP3AutomatedAssignmentAccount.IncludeClientContacts AndAlso Employee Is Nothing Then

                                                        Try

                                                            ClientContact = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientContact).Include("Client")
                                                                             Where Entity.EmailAddress.ToUpper = Message.From.Email.ToUpper
                                                                             Select Entity).FirstOrDefault

                                                        Catch ex As Exception
                                                            ClientContact = Nothing
                                                        End Try

                                                    End If

                                                    If Employee IsNot Nothing Then

                                                        WriteToEventLog("creating alert --> Message ID: " & MessageIDs(MesseageIndex) & " Employee: " & Employee.ToString)

                                                        AutomatedAssignmentMessage = String.Format(_AutomatedAssignmentMessageTemplate, POP3AutomatedAssignmentAccount.Description, Employee.ToString, Employee.Email, If(Employee.Office IsNot Nothing, Employee.Office.Name, String.Empty))

                                                        If JobComponentView IsNot Nothing Then

                                                            AlertCreated = CreateAndSendAlertAssignment(Session, Message, Agency, AlertType, AlertCategory, "JC", POP3AutomatedAssignmentAccount.AlertTemplateID.GetValueOrDefault(0),
                                                                                                        POP3AutomatedAssignmentAccount.AlertStateID.GetValueOrDefault(0), AlertSystem.PriorityLevels.Normal, Message.Subject,
                                                                                                        AutomatedAssignmentMessage & System.Environment.NewLine & Message.BodyPlainText,
                                                                                                        AutomatedAssignmentMessage & "<br />" & Message.GetHtmlAndSaveRelatedFiles(Agency.ImportPath, MailBee.Mime.VirtualMappingType.Base64, MailBee.Mime.MessageFolderBehavior.CreateAndDelete), Employee.Code, Session.UserCode,
                                                                                                        POP3AutomatedAssignmentAccount.EmployeeCode, False, ErrorMessage, EmailSent, AlertID,
                                                                                                        OfficeCode:=Employee.OfficeCode, ClientCode:=JobComponentView.ClientCode, DivisionCode:=JobComponentView.DivisionCode,
                                                                                                        ProductCode:=JobComponentView.ProductCode, JobNumber:=JobComponentView.JobNumber, JobComponentNumber:=JobComponentView.JobComponentNumber)

                                                        Else

                                                            If String.IsNullOrWhiteSpace(Employee.OfficeCode) = False Then

                                                                AlertCreated = CreateAndSendAlertAssignment(Session, Message, Agency, AlertType, AlertCategory, "OF", POP3AutomatedAssignmentAccount.AlertTemplateID.GetValueOrDefault(0),
                                                                                                            POP3AutomatedAssignmentAccount.AlertStateID.GetValueOrDefault(0), AlertSystem.PriorityLevels.Normal, Message.Subject,
                                                                                                            AutomatedAssignmentMessage & System.Environment.NewLine & Message.BodyPlainText,
                                                                                                            AutomatedAssignmentMessage & "<br />" & Message.GetHtmlAndSaveRelatedFiles(Agency.ImportPath, MailBee.Mime.VirtualMappingType.Base64, MailBee.Mime.MessageFolderBehavior.CreateAndDelete), Session.User.EmployeeCode, Session.UserCode,
                                                                                                            POP3AutomatedAssignmentAccount.EmployeeCode, False, ErrorMessage, EmailSent, AlertID,
                                                                                                            OfficeCode:=Employee.OfficeCode)

                                                            Else

                                                                If String.IsNullOrWhiteSpace(POP3AutomatedAssignmentAccount.FailureMessage) Then

                                                                    AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "No Account Found",
                                                                                                  "Your Email account was not found in our system.  Please call us to receive assistance.",
                                                                                                  3, Nothing, SendingEmailStatus, "", "", "")

                                                                Else

                                                                    AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "No Account Found",
                                                                                                  POP3AutomatedAssignmentAccount.FailureMessage,
                                                                                                  3, Nothing, SendingEmailStatus, "", "", "")

                                                                End If

                                                            End If

                                                        End If

                                                    ElseIf ClientContact IsNot Nothing Then

                                                        WriteToEventLog("creating alert --> Message ID: " & MessageIDs(MesseageIndex) & " ClientContact: " & ClientContact.ToString)

                                                        If ClientContact.Client IsNot Nothing AndAlso ClientContact.Client.AutomatedAssignmentJobNumber.GetValueOrDefault(0) > 0 AndAlso ClientContact.Client.AutomatedAssignmentJobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                            ClientJobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, ClientContact.Client.AutomatedAssignmentJobNumber.GetValueOrDefault(0), ClientContact.Client.AutomatedAssignmentJobComponentNumber.GetValueOrDefault(0))

                                                        End If

                                                        AutomatedAssignmentMessage = String.Format(_AutomatedAssignmentMessageTemplate, POP3AutomatedAssignmentAccount.Description, ClientContact.ToString, ClientContact.EmailAddress, If(ClientContact.Client IsNot Nothing, ClientContact.Client.Name, String.Empty))

                                                        If ClientJobComponentView IsNot Nothing Then

                                                            AlertCreated = CreateAndSendAlertAssignment(Session, Message, Agency, AlertType, AlertCategory, "JC", POP3AutomatedAssignmentAccount.AlertTemplateID.GetValueOrDefault(0),
                                                                                                        POP3AutomatedAssignmentAccount.AlertStateID.GetValueOrDefault(0), AlertSystem.PriorityLevels.Normal, Message.Subject,
                                                                                                        AutomatedAssignmentMessage & System.Environment.NewLine & Message.BodyPlainText,
                                                                                                        AutomatedAssignmentMessage & "<br />" & Message.GetHtmlAndSaveRelatedFiles(Agency.ImportPath, MailBee.Mime.VirtualMappingType.Base64, MailBee.Mime.MessageFolderBehavior.CreateAndDelete), Session.User.EmployeeCode, Session.UserCode,
                                                                                                        POP3AutomatedAssignmentAccount.EmployeeCode, False, ErrorMessage, EmailSent, AlertID,
                                                                                                        OfficeCode:=ClientJobComponentView.OfficeCode, ClientCode:=ClientJobComponentView.ClientCode, DivisionCode:=ClientJobComponentView.DivisionCode,
                                                                                                        ProductCode:=ClientJobComponentView.ProductCode, JobNumber:=ClientJobComponentView.JobNumber, JobComponentNumber:=ClientJobComponentView.JobComponentNumber,
                                                                                                        ClientContactID:=ClientContact.ContactID, IsCPAlert:=True)

                                                        ElseIf JobComponentView IsNot Nothing Then

                                                            AlertCreated = CreateAndSendAlertAssignment(Session, Message, Agency, AlertType, AlertCategory, "JC", POP3AutomatedAssignmentAccount.AlertTemplateID.GetValueOrDefault(0),
                                                                                                        POP3AutomatedAssignmentAccount.AlertStateID.GetValueOrDefault(0), AlertSystem.PriorityLevels.Normal, Message.Subject,
                                                                                                        AutomatedAssignmentMessage & System.Environment.NewLine & Message.BodyPlainText,
                                                                                                        AutomatedAssignmentMessage & "<br />" & Message.GetHtmlAndSaveRelatedFiles(Agency.ImportPath, MailBee.Mime.VirtualMappingType.Base64, MailBee.Mime.MessageFolderBehavior.CreateAndDelete), Session.User.EmployeeCode, Session.UserCode,
                                                                                                        POP3AutomatedAssignmentAccount.EmployeeCode, False, ErrorMessage, EmailSent, AlertID,
                                                                                                        OfficeCode:=JobComponentView.OfficeCode, ClientCode:=JobComponentView.ClientCode, DivisionCode:=JobComponentView.DivisionCode,
                                                                                                        ProductCode:=JobComponentView.ProductCode, JobNumber:=JobComponentView.JobNumber, JobComponentNumber:=JobComponentView.JobComponentNumber,
                                                                                                        ClientContactID:=ClientContact.ContactID, IsCPAlert:=True)


                                                        Else

                                                            AlertCreated = CreateAndSendAlertAssignment(Session, Message, Agency, AlertType, AlertCategory, "CL", POP3AutomatedAssignmentAccount.AlertTemplateID.GetValueOrDefault(0),
                                                                                                        POP3AutomatedAssignmentAccount.AlertStateID.GetValueOrDefault(0), AlertSystem.PriorityLevels.Normal, Message.Subject,
                                                                                                        AutomatedAssignmentMessage & System.Environment.NewLine & Message.BodyPlainText,
                                                                                                        AutomatedAssignmentMessage & "<br />" & Message.GetHtmlAndSaveRelatedFiles(Agency.ImportPath, MailBee.Mime.VirtualMappingType.Base64, MailBee.Mime.MessageFolderBehavior.CreateAndDelete), Session.User.EmployeeCode, Session.UserCode,
                                                                                                        POP3AutomatedAssignmentAccount.EmployeeCode, False, ErrorMessage, EmailSent, AlertID,
                                                                                                        ClientContactID:=ClientContact.ContactID, ClientCode:=ClientContact.ClientCode, IsCPAlert:=True)

                                                        End If

                                                    Else

                                                        If String.IsNullOrWhiteSpace(POP3AutomatedAssignmentAccount.FailureMessage) Then

                                                            AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "No Account Found",
                                                                                          "Your Email account was not found in our system.  Please call us to receive assistance.",
                                                                                          3, Nothing, SendingEmailStatus, "", "", "")

                                                        Else

                                                            AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "No Account Found",
                                                                                          POP3AutomatedAssignmentAccount.FailureMessage,
                                                                                          3, Nothing, SendingEmailStatus, "", "", "")

                                                        End If

                                                    End If

                                                    If AlertCreated AndAlso EmailSent Then

                                                        ExtraMessageToSendWithReplyBackEmail = String.Empty

                                                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                                                        If Alert IsNot Nothing AndAlso Alert.JobNumber.GetValueOrDefault(0) > 0 AndAlso Alert.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                            ExtraMessageToSendWithReplyBackEmail = String.Format("ID # {0}-{1}-{2} has been assigned to this request.", Alert.JobNumber.Value, Alert.JobComponentNumber.Value, Alert.AlertSequenceNumber.Value)

                                                        ElseIf Alert IsNot Nothing Then

                                                            ExtraMessageToSendWithReplyBackEmail = String.Format("ID # {0} has been assigned to this request.", Alert.ID)

                                                        End If

                                                        If String.IsNullOrWhiteSpace(POP3AutomatedAssignmentAccount.SuccessMessage) Then

                                                            If String.IsNullOrWhiteSpace(ExtraMessageToSendWithReplyBackEmail) Then

                                                                AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "Your Message has been Received",
                                                                                              "Thank you for contacting us, your message has been received.",
                                                                                              3, Nothing, SendingEmailStatus, "", "", "")

                                                            Else

                                                                AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "Your Message has been Received",
                                                                                              "Thank you for contacting us, your message has been received." & "<br />" & ExtraMessageToSendWithReplyBackEmail,
                                                                                              3, Nothing, SendingEmailStatus, "", "", "")

                                                            End If

                                                        Else

                                                            If String.IsNullOrWhiteSpace(ExtraMessageToSendWithReplyBackEmail) Then

                                                                AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "Your Message has been Received",
                                                                                              POP3AutomatedAssignmentAccount.SuccessMessage,
                                                                                              3, Nothing, SendingEmailStatus, "", "", "")

                                                            Else

                                                                AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Message.From.Email, "Your Message has been Received",
                                                                                              POP3AutomatedAssignmentAccount.SuccessMessage & "<br />" & ExtraMessageToSendWithReplyBackEmail,
                                                                                              3, Nothing, SendingEmailStatus, "", "", "")

                                                            End If

                                                        End If

                                                    End If

                                                    If SaveMessageID(DataContext, SavedMessageIDs, MessageIDs(MesseageIndex)) Then

                                                        WriteToEventLog("Saved message --> Message ID: " & MessageIDs(MesseageIndex) & " Message Index: " & MesseageIndex)

                                                    Else

                                                        WriteToEventLog("Failed to save message --> Message ID: " & MessageIDs(MesseageIndex) & " Message Index: " & MesseageIndex)

                                                    End If

                                                    If POP3AutomatedAssignmentAccount.DeleteProcessed = True Then

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
        Public Function CreateAndSendAlertAssignment(Session As AdvantageFramework.Security.Session, Message As MailBee.Mime.MailMessage,
                                                     Agency As AdvantageFramework.Database.Entities.Agency,
                                                     AlertTypeID As Integer, AlertCategoryID As Integer,
                                                     AlertLevel As String, AlertAssignmentTemplateID As Integer, AlertStateID As Integer, PriorityLevel As AdvantageFramework.AlertSystem.PriorityLevels,
                                                     Subject As String, Body As String, EmailBody As String, EmployeeCode As String,
                                                     UserCode As String, AssignedToEmployeeCode As String, ExcludeAttachments As Boolean,
                                                     ByRef ErrorMessage As String, ByRef EmailSent As Boolean, ByRef AlertID As Integer,
                                                     Optional DueDate As Nullable(Of Date) = Nothing, Optional TimeDue As String = Nothing, Optional OfficeCode As String = Nothing,
                                                     Optional ClientCode As String = Nothing, Optional DivisionCode As String = Nothing, Optional ProductCode As String = Nothing,
                                                     Optional CampaignCode As String = Nothing, Optional JobNumber As Integer = Nothing, Optional JobComponentNumber As Short = Nothing,
                                                     Optional EstimateNumber As Integer = Nothing, Optional EstimateComponentNumber As Short = Nothing, Optional EstimateQuoteNumber As Short = Nothing,
                                                     Optional EstimateRevisionNumber As Short = Nothing, Optional VendorCode As String = Nothing, Optional PONumber As Integer = Nothing,
                                                     Optional PORevisionNumber As Short = Nothing, Optional AccountPayableID As Integer = Nothing, Optional AccountPayableSequenceNumber As Short = Nothing,
                                                     Optional CampaignID As Integer = Nothing, Optional ClientContactID As Integer = Nothing, Optional IsCPAlert As Boolean = False) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim IsUnassigned As Boolean = False
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim AlertAttachmentAdded As Boolean = False
            Dim FileSystemFile As String = ""
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Alert = New AdvantageFramework.Database.Entities.Alert

                    Alert.DbContext = DbContext

                    Alert.AlertTypeID = AlertTypeID
                    Alert.AlertCategoryID = AlertCategoryID
                    Alert.AlertLevel = AlertLevel

                    If AlertAssignmentTemplateID = 0 Then

                        Alert.AlertAssignmentTemplateID = Nothing

                    Else

                        Alert.AlertAssignmentTemplateID = AlertAssignmentTemplateID

                    End If

                    If AlertStateID = 0 Then

                        Alert.AlertStateID = Nothing

                    Else

                        Alert.AlertStateID = AlertStateID

                    End If
                    
                    Alert.PriorityLevel = PriorityLevel
                    Alert.DueDate = DueDate
                    Alert.TimeDue = TimeDue
                    Alert.Subject = Subject
                    Alert.Body = Body
                    Alert.EmailBody = EmailBody
                    Alert.GeneratedDate = System.DateTime.Now
                    Alert.IsWorkItem = True

                    If IsCPAlert Then

                        Alert.EmployeeCode = ""
                        Alert.UserCode = ClientContactID
                        Alert.IsCPAlert = 1
                        Alert.ClientContactID = ClientContactID

                    Else

                        Alert.EmployeeCode = EmployeeCode
                        Alert.UserCode = UserCode
                        Alert.IsCPAlert = Nothing
                        Alert.ClientContactID = Nothing

                    End If

                    Alert.OfficeCode = OfficeCode
                    Alert.ClientCode = ClientCode
                    Alert.DivisionCode = DivisionCode
                    Alert.ProductCode = ProductCode
                    Alert.CampaignCode = CampaignCode
                    Alert.JobNumber = JobNumber
                    Alert.JobComponentNumber = JobComponentNumber
                    Alert.EstimateNumber = EstimateNumber
                    Alert.EstimateComponentNumber = EstimateComponentNumber
                    Alert.EstimateQuoteNumber = EstimateQuoteNumber
                    Alert.EstimateRevisionNumber = EstimateRevisionNumber
                    Alert.VendorCode = VendorCode
                    Alert.PONumber = PONumber
                    Alert.PORevisionNumber = PORevisionNumber
                    Alert.AccountPayableID = AccountPayableID
                    Alert.AccountPayableSequenceNumber = AccountPayableSequenceNumber
                    Alert.CampaignID = CampaignID

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                        Try

                            If String.IsNullOrWhiteSpace(AssignedToEmployeeCode) OrElse (AssignedToEmployeeCode.Trim().ToLower().IndexOf("unassigned") > -1 OrElse AssignedToEmployeeCode.Trim().ToLower().IndexOf("un-assigned") > -1) Then

                                IsUnassigned = True

                            End If

                        Catch ex As Exception
                            IsUnassigned = False
                        End Try

                        Try

                            AlertCreated = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[usp_wv_ALERT_NOTIFY_SAVE] '{0}', {1}, '{2}', {3}, {4}, {5}, '{6}', {7}, {8}, {9}", If(IsCPAlert, ClientContactID, UserCode), Alert.ID, AssignedToEmployeeCode, 0,
                                                                                                                                                                                                 If(AlertStateID = 0, "NULL", AlertStateID),
                                                                                                                                                                                                 If(AlertAssignmentTemplateID = 0, "NULL", AlertAssignmentTemplateID),
                                                                                                                                                                                                 "", If(IsUnassigned, 1, 0), 1, 1)).FirstOrDefault()

                        Catch ex As Exception
                            AlertCreated = False
                        End Try

                        If AlertCreated Then

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
                                                Document.UserCode = UserCode

                                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                    AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                                                    AlertAttachment.DbContext = DbContext
                                                    AlertAttachment.DocumentID = Document.ID
                                                    AlertAttachment.AlertID = Alert.ID
                                                    AlertAttachment.GeneratedDate = Now
                                                    AlertAttachment.UserCode = UserCode
                                                    AlertAttachment.HasEmailBeenSent = False

                                                    AlertAttachmentAdded = AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

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

                        End If

                    End If

                End Using

                If AlertCreated Then

                    AlertID = Alert.ID

                    EmailSent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert]", Nothing, Nothing, Nothing, Nothing, ExcludeAttachments, False, IsCPAlert, True, "", "", ErrorMessage)

                End If

            Catch ex As Exception
                AlertCreated = False
            Finally
                CreateAndSendAlertAssignment = AlertCreated
            End Try

        End Function
        Private Function LoadSavedMessageIDs(DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of String)

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
        Private Function SaveMessageID(DataContext As AdvantageFramework.Database.DataContext, ByRef SavedMessageIDs As Generic.List(Of String), MessageID As String) As Boolean

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
        Private Function HasMessageBeenChecked(SavedMessageIDs As Generic.List(Of String), MessageID As String) As Boolean

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
        Public Function IsServiceReadyToRun(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

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

                                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.AutomatedAssignments.RegistrySetting.RunAtEvery), RunAtEvery)
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.AutomatedAssignments.RegistrySetting.LastRanAt), LastRanAt)

                                LastRanAt = LastRanAt.AddMinutes(RunAtEvery)

                                If DateDiff(DateInterval.Minute, LastRanAt, Now) >= 0 Then

                                    LastRanAt = Now

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.AutomatedAssignments.RegistrySetting.LastRanAt, LastRanAt)

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
        Public Sub Run(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

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
        Public Function LoadLog(LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

            'objects
            Dim Log As String = ""
            Dim Entry As System.Diagnostics.EventLogEntry = Nothing

            If System.Diagnostics.EventLog.SourceExists("Adv Automated Assignments Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Adv Automated Assignments Source", "Adv Automated Assignments Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Adv Automated Assignments Log", My.Computer.Name, "Adv Automated Assignments Source")

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
        Public Function LoadAdvantageService(DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageAutomatedAssignmentsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(DataContext As AdvantageFramework.Database.DataContext, AdvantageServiceID As Integer, RegistrySetting As AdvantageFramework.Services.AutomatedAssignments.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(DataContext As AdvantageFramework.Database.DataContext, AdvantageServiceID As Integer, RegistrySetting As AdvantageFramework.Services.AutomatedAssignments.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(DataContext As AdvantageFramework.Database.DataContext, AdvantageServiceID As Integer, RegistrySetting As AdvantageFramework.Services.AutomatedAssignments.RegistrySetting, SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(DataContext As AdvantageFramework.Database.DataContext, ByRef RunAtEvery As Integer, Optional ByRef LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.AutomatedAssignments.RegistrySetting.RunAtEvery), RunAtEvery)

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.AutomatedAssignments.RegistrySetting.LastRanAt), LastRanAt)

            End If

        End Sub
        Public Sub SaveSettings(DataContext As AdvantageFramework.Database.DataContext, RunAtEvery As Integer)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.AutomatedAssignments.RegistrySetting.RunAtEvery, RunAtEvery)

            End If

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

