Public Module AccessEmail

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function Main(args() As String) As Integer

        Dim ErrorCode As Integer = 0
        Dim AccessEmailIDs As Generic.List(Of Integer) = Nothing
        Dim EmailSuccessful As Boolean = False
        Dim DNSName As String = String.Empty
        Dim UserCode As String = String.Empty
        Dim Password As String = String.Empty
        Dim ODBCs As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
        Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim AccessEmail As AdvantageFramework.Database.Entities.AccessEmail = Nothing
        Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
        Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToSend
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim UserName As String = String.Empty
        Dim [From] As String = String.Empty
        Dim ReplyTo As String = String.Empty
        Dim MaxEmailSize As Long = Nothing
        Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing
        Dim SMTP As MailBee.SmtpMail.Smtp = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim DebugLines As String = String.Empty

        Try

            DNSName = args(0)
            UserCode = args(1)
            AccessEmailIDs = args(2).Split(",").Select(Function(AccessEmailID) CInt(AccessEmailID)).ToList

        Catch ex As Exception
            AccessEmailIDs = New Generic.List(Of Integer)
        End Try

        If String.IsNullOrWhiteSpace(DNSName) = False AndAlso
                String.IsNullOrWhiteSpace(UserCode) = False AndAlso
                AccessEmailIDs.Count > 0 Then

            Try

                DebugLines = NewDebugLine(DebugLines, "DNSName = " & DNSName)
                DebugLines = NewDebugLine(DebugLines, "UserCode = " & UserCode)
                DebugLines = NewDebugLine(DebugLines, "AccessEmailIDs = " & args(2))

                Try

                    ODBCs = AdvantageFramework.Database.LoadODBCs()

                    If ODBCs IsNot Nothing AndAlso ODBCs.Count > 0 Then

                        ODBC = ODBCs.SingleOrDefault(Function(Entity) Entity.DNSName = DNSName)

                    End If

                Catch ex As Exception
                    ODBC = Nothing
                End Try

                If ODBC IsNot Nothing Then

                    DebugLines = NewDebugLine(DebugLines, "Found ODBC " & DNSName)

                    Try

                        ConnectionDatabaseProfiles = LoadConnectionDatabaseProfileForAdvantage(DebugLines, True)

                        Try

                            ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName.ToUpper = ODBC.ServerName.ToUpper AndAlso Entity.DatabaseName.ToUpper = ODBC.DatabaseName.ToUpper)

                        Catch ex As Exception
                            ConnectionDatabaseProfile = Nothing
                        End Try

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            DebugLines = NewDebugLine(DebugLines, "Found ConnectionDatabaseProfile " & ConnectionDatabaseProfile.ToString)

                            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                                    DbContext.Database.Connection.Open()

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                    SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                                    If AdvantageFramework.Email.LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                                        MaxEmailSize = AdvantageFramework.Email.LoadMaxEmailSize(DbContext)

                                        SMTP = CreateSMTP(DbContext, SecurityDbContext, Agency, SMTPSettings, UserName, Password, [From], ReplyTo)

                                        For Each AccessEmailID In AccessEmailIDs

                                            ErrorMessage = String.Empty
                                            AccessEmail = Nothing

                                            Try

                                                AccessEmail = DbContext.AccessEmails.Find(AccessEmailID)

                                            Catch ex As Exception
                                                AccessEmail = Nothing
                                            End Try

                                            If AccessEmail IsNot Nothing Then

                                                If String.IsNullOrWhiteSpace(AccessEmail.AttachmentPath) = False Then

                                                    DebugLines = NewDebugLine(DebugLines, "Adding attachment ")

                                                    Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AccessEmail.AttachmentPath))

                                                ElseIf AccessEmail.Attachment IsNot Nothing Then

                                                    DebugLines = NewDebugLine(DebugLines, "Adding attachment ")

                                                    Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AccessEmail.AttachmentName, AccessEmail.Attachment))

                                                End If

                                                EmailSuccessful = SendEmail(SMTP, AccessEmail.TO, AccessEmail.CC, AccessEmail.Subject, AccessEmail.IsBodyHTML, AccessEmail.Body,
                                                                            CInt(AdvantageFramework.AlertSystem.PriorityLevels.Normal),
                                                                            Attachments, SendingEmailStatus, Agency, String.Empty, From, ReplyTo, MaxEmailSize)

                                                DebugLines = NewDebugLine(DebugLines, "Email status " & SendingEmailStatus.ToString)

                                                If EmailSuccessful = False Then

                                                    If String.IsNullOrWhiteSpace(ErrorMessage) AndAlso
                                                            (SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSent AndAlso
                                                             SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSentWithoutAttachment) Then

                                                        ErrorMessage = AdvantageFramework.StringUtilities.GetNameAsWords(SendingEmailStatus.ToString)

                                                    End If

                                                End If

                                                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                                    ErrorMessage = ""

                                                End If

                                                AccessEmail.ErrorMessage = ErrorMessage
                                                AccessEmail.Processed = True

                                            Else

                                                DebugLines = NewDebugLine(DebugLines, "DID NOT Find AccessEmailID " & AccessEmailID)

                                            End If

                                        Next

                                        DbContext.SaveChanges()

                                    Else

                                        SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                                    End If

                                End Using

                            End Using

                        Else

                            DebugLines = NewDebugLine(DebugLines, "DID NOT Find ConnectionDatabaseProfile " & ODBC.DatabaseName)

                        End If

                    Catch ex As Exception

                        DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.Message)

                        If ex.InnerException IsNot Nothing Then

                            DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.Message)

                            If ex.InnerException.InnerException IsNot Nothing Then

                                DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.InnerException.Message)

                            End If

                        End If

                    End Try

                Else

                    DebugLines = NewDebugLine(DebugLines, "DID NOT Find ODBC " & DNSName)

                End If

            Catch ex As Exception
                EmailSuccessful = False
            End Try

        Else

            If String.IsNullOrWhiteSpace(DNSName) Then

                DebugLines = NewDebugLine(DebugLines, "DNSName is blank ")

            End If

            If String.IsNullOrWhiteSpace(UserCode) Then

                DebugLines = NewDebugLine(DebugLines, "UserCode is blank ")

            End If

            If AccessEmailIDs Is Nothing OrElse AccessEmailIDs.Count = 0 Then

                DebugLines = NewDebugLine(DebugLines, "AccessEmailID is blank ")

            End If

        End If

        'Try

        '    My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "AccessEmailDebug.txt", DebugLines, False)

        'Catch ex As Exception

        'End Try

        If EmailSuccessful Then

            ErrorCode = 0

        Else

            ErrorCode = 1

        End If

        Return ErrorCode

    End Function
    Private Function NewDebugLine(DebugLines As String, Message As String) As String

        Dim DebugLine As String = String.Empty

        If String.IsNullOrWhiteSpace(DebugLines) Then

            DebugLine = Now.ToShortDateString & " " & Now.ToLongTimeString & " --- " & Message

        Else

            DebugLine = Now.ToShortDateString & " " & Now.ToLongTimeString & " --- " & Message & System.Environment.NewLine & DebugLines

        End If

        NewDebugLine = DebugLine

    End Function
    Private Function LoadConnectionDatabaseProfileForAdvantage(ByRef DebugLines As String, Optional DecryptPassword As Boolean = False) As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

        'objects
        Dim XmlTextReader As System.Xml.XmlTextReader = Nothing
        Dim XMLFile As String = String.Empty
        Dim XML As String = String.Empty
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

        Try

            XMLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & AdvantageFramework.Security.AdvantageConnectionConfigurationFileName

            DebugLines = NewDebugLine(DebugLines, "XML FILE --> " & XMLFile)

            ConnectionDatabaseProfileList = New Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

            If My.Computer.FileSystem.FileExists(XMLFile) Then

                Try

                    XmlTextReader = New System.Xml.XmlTextReader(XMLFile)

                    Do Until XmlTextReader.Read() = False

                        If XmlTextReader.Name = "ConnectionDatabaseProfile" Then

                            XML = XmlTextReader.ReadOuterXml

                            ConnectionDatabaseProfile = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.Database.ConnectionDatabaseProfile))

                            If ConnectionDatabaseProfile IsNot Nothing Then

                                If DecryptPassword Then

                                    ConnectionDatabaseProfile.Password = AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)

                                End If

                                ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

                            End If

                        End If

                    Loop

                Catch ex As Exception
                    XML = ""

                    DebugLines = NewDebugLine(DebugLines, "FAILED READING XML FILE --> " & XMLFile)

                Finally

                    If XmlTextReader IsNot Nothing Then

                        XmlTextReader.Close()

                    End If

                    XmlTextReader = Nothing

                End Try

            Else

                DebugLines = NewDebugLine(DebugLines, "NOT FOUND XML FILE --> " & XMLFile)

            End If

        Catch ex As Exception

        End Try

        LoadConnectionDatabaseProfileForAdvantage = ConnectionDatabaseProfileList

    End Function
    Public Function Login(DNSName As String, UserCode As String, Password As String) As Boolean

        Dim SuccessfulLogin As Boolean = False
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ODBCs As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
        Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
        Dim UserID As Integer = 0
        Dim EncryptedPassword As String = String.Empty
        Dim DebugLines As String = String.Empty

        DebugLines = NewDebugLine(DebugLines, "DNSName = " & DNSName)
        DebugLines = NewDebugLine(DebugLines, "UserCode = " & UserCode)
        DebugLines = NewDebugLine(DebugLines, "Password = " & Password)

        Try

            ODBCs = AdvantageFramework.Database.LoadODBCs()

            If ODBCs IsNot Nothing AndAlso ODBCs.Count > 0 Then

                ODBC = ODBCs.SingleOrDefault(Function(Entity) Entity.DNSName = DNSName)

            End If

        Catch ex As Exception
            ODBC = Nothing
        End Try

        If ODBC IsNot Nothing Then

            DebugLines = NewDebugLine(DebugLines, "Found ODBC " & DNSName)

            Try

                ConnectionDatabaseProfiles = LoadConnectionDatabaseProfileForAdvantage(DebugLines, True)

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName.ToUpper = ODBC.ServerName.ToUpper AndAlso Entity.DatabaseName.ToUpper = ODBC.DatabaseName.ToUpper)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    DebugLines = NewDebugLine(DebugLines, "Found ConnectionDatabaseProfile " & ConnectionDatabaseProfile.ToString)

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                        DbContext.Database.Connection.Open()

                        Try

                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

                        Catch ex As Exception
                            UserID = 0
                        End Try

                        If UserID > 0 Then

                            DebugLines = NewDebugLine(DebugLines, "Found User ID " & UserID)

                            Try

                                EncryptedPassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT dbo.advfn_SEC_USER_AUTH({0})", UserID)).FirstOrDefault

                            Catch ex As Exception
                                EncryptedPassword = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(EncryptedPassword) = False Then

                                DebugLines = NewDebugLine(DebugLines, "Found EncryptedPassword - User ID " & UserID)

                                If EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password) Then

                                    DebugLines = NewDebugLine(DebugLines, "Valid Password " & Password)

                                    SuccessfulLogin = True

                                Else

                                    DebugLines = NewDebugLine(DebugLines, "Invalid Password " & Password)

                                End If

                            Else

                                DebugLines = NewDebugLine(DebugLines, "DID NOT Find EncryptedPassword - User ID " & UserID)

                            End If

                        Else

                            DebugLines = NewDebugLine(DebugLines, "DID NOT Find User ID " & UserID)

                        End If

                    End Using

                Else

                    DebugLines = NewDebugLine(DebugLines, "DID NOT Find ConnectionDatabaseProfile " & ODBC.DatabaseName)

                End If

            Catch ex As Exception

                DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.Message)

                If ex.InnerException IsNot Nothing Then

                    DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.Message)

                    If ex.InnerException.InnerException IsNot Nothing Then

                        DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.InnerException.Message)

                    End If

                End If

            End Try

        Else

            DebugLines = NewDebugLine(DebugLines, "DID NOT Find ODBC " & DNSName)

        End If

        My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "AdassistDebug.txt", DebugLines, False)

        Login = SuccessfulLogin

    End Function
    Private Function CreateSMTP(DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                Agency As AdvantageFramework.Database.Entities.Agency,
                                SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings,
                                UserName As String, Password As String, [From] As String, ReplyTo As String) As MailBee.SmtpMail.Smtp

        'objects
        Dim SMTP As MailBee.SmtpMail.Smtp = Nothing

        Try

            SMTP = AdvantageFramework.Email.CreateMailBeeSMTP(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                              SMTPSettings.SMTPPortNumber, UserName, Password, SMTPSettings.SMTPSecureType)

            If SMTP.Connect = False Then

                SMTP = Nothing

            End If

        Catch ex As Exception
            SMTP = Nothing
        Finally
            CreateSMTP = SMTP
        End Try

    End Function
    Private Function SendEmail(SMTP As MailBee.SmtpMail.Smtp, [To] As String, [CC] As String, Subject As String, IsHTML As Boolean, Body As String, Priority As Integer,
                               Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment), ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                               Agency As AdvantageFramework.Database.Entities.Agency, SenderName As String, [From] As String, ByRef ReplyTo As String, MaxEmailSize As Long) As Boolean

        'objects
        Dim EmailSent As Boolean = False
        Dim AttachmentsAdded As Boolean = True
        Dim HasAttachment As Boolean = False
        Dim Impersonating As Boolean = False
        Dim DecrpytedPassword As String = String.Empty

        Try

            SMTP.ResetMessage()

            SMTP.Message.From.AsString = From

            If String.IsNullOrWhiteSpace(SenderName) = False Then

                SMTP.Message.From.DisplayName = SenderName

            End If

            SMTP.Message.ReplyTo.AsString = ReplyTo

            SMTP.Message.To.AsString = [To]

            If String.IsNullOrWhiteSpace([CC]) = False AndAlso [CC].Length > 0 Then

                SMTP.Message.Cc.AsString = [CC]

            End If

            SMTP.Message.Subject = Subject

            If IsHTML Then

                SMTP.Message.BodyHtmlText = Body

            Else

                SMTP.Message.BodyPlainText = Body

            End If

            AdvantageFramework.Email.SetPriority(SMTP, Priority)

            If Attachments IsNot Nothing AndAlso Attachments.Any Then

                HasAttachment = True

                DecrpytedPassword = AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword)

                If Agency.FileSystemUserName <> "" AndAlso Agency.FileSystemDomain <> "" AndAlso DecrpytedPassword <> "" Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, DecrpytedPassword)
                    Impersonating = True

                End If

                For Each Attachment In Attachments

                    If String.IsNullOrEmpty(Attachment.File) = False Then

                        Try

                            If String.IsNullOrWhiteSpace(Attachment.AttachmentName) = False Then

                                If SMTP.Message.Attachments.Add(Attachment.File, Attachment.AttachmentName, Nothing) = False Then

                                    AttachmentsAdded = False

                                End If

                            Else

                                If SMTP.AddAttachment(Attachment.File) = False Then

                                    AttachmentsAdded = False

                                End If

                            End If

                        Catch ex As Exception
                            AttachmentsAdded = False
                        End Try

                    ElseIf Attachment.FileBytes IsNot Nothing Then

                        Try

                            SMTP.Message.Attachments.Add(Attachment.FileBytes,
                                                         Attachment.AttachmentName,
                                                         Nothing, Nothing, Nothing, MailBee.Mime.NewAttachmentOptions.ReplaceIfExists, MailBee.Mime.MailTransferEncoding.Base64)

                        Catch ex As Exception
                            AttachmentsAdded = False
                        End Try

                    Else

                        AttachmentsAdded = False

                    End If

                Next

                AdvantageFramework.Email.CheckEmailSize(SMTP, MaxEmailSize, AttachmentsAdded)

                If Impersonating = True Then

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Else

                AttachmentsAdded = False

            End If

            If SMTP.Send() Then

                If HasAttachment Then

                    If AttachmentsAdded Then

                        SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent

                    Else

                        SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSentWithoutAttachment

                    End If

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent

                End If

                EmailSent = True

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToSend

            End If

        Catch ex As Exception
            EmailSent = False
        End Try

        SendEmail = EmailSent

    End Function

#End Region

End Module
