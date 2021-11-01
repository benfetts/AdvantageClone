Namespace Email

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const MailBeeDotNetKey As String = "MN120-4D857ACC84818593857E6A7C9EEB-F72F" ' "MN700-CF0778C1075F07C1078BF870175F-B389"
        Public Const Font As String = "Verdana, Arial, Helvetica, sans-serif"
        Public Const BodyBackgroundColor As String = "#FFFFFF"
        Public Const HeaderShowBottomBorder As Boolean = False
        Public Const HeaderBackgroundColor As String = "#FFFFFF"
        Public Const HeaderFontSize As Integer = 3
        Public Const HeaderFontColor As String = "#333333"
        Public Const HeaderBold As Boolean = True
        Public Const RowBackgroundColor As String = "#FFFFFF"
        Public Const RowFontSize As Integer = 2
        Public Const RowFontSizeSmall As Integer = 1
        Public Const RowFontColor As String = "#333333"
        Public Const RowBoldLabel As Boolean = False
        Public Const HorizontalLineColor As String = "#333333"
        Public Const LineBreak As String = "<br />"
        Public Const NonBreakingSpace As String = "&nbsp;"

        ' IF THESE ARE CHANGED, UPDATE THEM IN GOOGLE SERVICES PROJECT!!!
        Public Const GoogleClientID As String = "641931340891-99hr8ijdob0b40mkk5ar2s2nn0nnss12.apps.googleusercontent.com"
        Public Const GoogleClientSecret As String = "iEnotTrS7pjQ94gDoKm2eS7G"


#End Region

#Region " Enum "

        Public Enum SendingEmailStatus
            EmailSent
            EmailSentWithoutAttachment
            FailedToConnect
            FailedToSend
            FailedToLoadSettings
        End Enum
        Public Enum POP3SecureTypes
            UseSSL = 1
            UseTLS = 2
            NoSecureProtocol = 0
        End Enum
        Public Enum POP3AuthenticationMethods
            NoAuthentication = 0
            Plain = 1
            Login = 2
            CRAMLD5 = 3
            NTLM = 4
            MSN = 5
        End Enum
        Public Enum SmtpAuthenticationMethods
            NoAuthentication = 0
            Plain = 1
            Login = 2
            CRAMLD5 = 3
            NTLM = 4
            MSN = 5
            OAuth2 = 6
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CreateMailBeeSMTP(ByVal MailBeeLicenseKey As String, ByVal SMTPAuthenticationMethodType As Integer, ByVal SMTPServer As String,
                                          ByVal SMTPPortNumber As Integer, ByVal UserName As String, ByVal Password As String,
                                          ByVal SMTPSecureType As Integer) As MailBee.SmtpMail.Smtp

            'objects
            Dim MailBeeSmtp As MailBee.SmtpMail.Smtp = Nothing
            Dim MailBeeServerInfo As MailBee.SmtpMail.SmtpServer = Nothing

            Try

                MailBee.Global.LicenseKey = MailBeeLicenseKey

                MailBeeSmtp = New MailBee.SmtpMail.Smtp

                'If SMTPAuthenticationMethodType = SmtpAuthenticationMethods.OAuth2 Then

                '    'With New MailBee.OAuth2(GoogleClientID, GoogleClientSecret)

                '    '    Password = .GetXOAuthKey(UserName, Password)

                '    'End With

                '    'MailBeeSmtp.SmtpServers.Add(SMTPServer, UserName, Password, MailBee.AuthenticationMethods.SaslOAuth2)

                'Else


                MailBeeServerInfo = New MailBee.SmtpMail.SmtpServer

                Select Case SMTPAuthenticationMethodType

                    Case 0

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.None

                    Case 1

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslPlain

                    Case 2

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslLogin

                    Case 3

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslCramMD5

                    Case 4

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslNtlm

                    Case 5

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslMsn

                    Case 6

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslOAuth2

                    Case Else

                        MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.Auto

                End Select

                MailBeeServerInfo.Name = SMTPServer
                MailBeeServerInfo.AccountName = UserName

                If MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslOAuth2 Then

                    With New MailBee.OAuth2(GoogleClientID, GoogleClientSecret)

                        MailBeeServerInfo.Password = .GetXOAuthKey(UserName, Password)

                    End With

                Else

                    MailBeeServerInfo.Password = Password

                End If

                If SMTPPortNumber <> 0 Then

                    MailBeeServerInfo.Port = SMTPPortNumber

                End If

                If SMTPSecureType <> AdvantageFramework.Email.POP3SecureTypes.NoSecureProtocol Then

                    If SMTPSecureType = AdvantageFramework.Email.POP3SecureTypes.UseTLS Then

                        MailBeeServerInfo.SslMode = MailBee.Security.SslStartupMode.UseStartTls

                    End If

                End If

                MailBeeServerInfo.Timeout = 60000

                MailBeeServerInfo.HelloDomain = MailBeeServerInfo.Name
                MailBeeSmtp.DirectSendDefaults.HelloDomain = MailBeeServerInfo.Name

                MailBeeSmtp.SmtpServers.Add(MailBeeServerInfo)

                'End If

            Catch ex As Exception

                AdvantageFramework.Security.AddWebvantageEventLog(ex.Message.ToString(), EventLogEntryType.Error)
                MailBeeSmtp = Nothing

            Finally

                CreateMailBeeSMTP = MailBeeSmtp

            End Try

        End Function
        Private Function InitMailBeePop3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByRef AuthenticationMethod As MailBee.AuthenticationMethods) As MailBee.Pop3Mail.Pop3

            'objects
            Dim POP3 As MailBee.Pop3Mail.Pop3 = Nothing
            Dim Connected As Boolean = False
            Dim LoggedIn As Boolean = False

            Try

                MailBee.Global.LicenseKey = MailBeeDotNetKey

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

                AdvantageFramework.Security.AddWebvantageEventLog(ex.Message.ToString(), EventLogEntryType.Error)
                POP3 = Nothing

            Finally

                InitMailBeePop3 = POP3

            End Try

        End Function
        Public Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency) As MailBee.Pop3Mail.Pop3

            CreateMailBeePOP3 = CreateMailBeePOP3(Agency, Agency.POP3UserName, AdvantageFramework.Security.Encryption.Decrypt(Agency.POP3Password))

        End Function
        Public Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal POP3EmailListenerAccount As AdvantageFramework.Database.Entities.POP3EmailListenerAccount) As MailBee.Pop3Mail.Pop3

            CreateMailBeePOP3 = CreateMailBeePOP3(Agency, POP3EmailListenerAccount.UserName, AdvantageFramework.Security.Encryption.Decrypt(POP3EmailListenerAccount.Password))

        End Function
        Public Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount) As MailBee.Pop3Mail.Pop3

            CreateMailBeePOP3 = CreateMailBeePOP3(Agency, POP3AutomatedAssignmentAccount.UserName, AdvantageFramework.Security.Encryption.Decrypt(POP3AutomatedAssignmentAccount.Password))

        End Function
        Public Function CreateMailBeePOP3(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal UserName As String, ByVal Password As String) As MailBee.Pop3Mail.Pop3

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

                AdvantageFramework.Security.AddWebvantageEventLog(ex.Message.ToString(), EventLogEntryType.Error)
                POP3 = Nothing

            Finally

                CreateMailBeePOP3 = POP3

            End Try

        End Function
        Public Function IsValidEmailAddress(ByRef EmailAddress As String) As Boolean

            IsValidEmailAddress = AdvantageFramework.StringUtilities.IsValidEmailAddress(EmailAddress)

        End Function
        ''' <summary>
        ''' Generic Email Send
        ''' </summary>
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal [To] As String, ByVal [Cc] As String, ByVal [Bcc] As String,
                             ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByVal Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment),
                             ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "",
                             Optional ByVal IsHTML As Boolean = True) As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            If DbContext IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                    If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                        MaxEmailSize = LoadMaxEmailSize(DbContext)

                        EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                                  SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo,
                                                                  [To], Cc, Bcc, Subject, IsHTML, Body, Priority, Attachments,
                                                                  MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                                  Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                                  ErrorMessage)

                    Else

                        SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                    End If

                End Using

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal [To] As String, ByVal [Cc] As String, ByVal [Bcc] As String,
                             ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByVal AttachmentFiles() As String, ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "",
                             Optional ByVal IsHTML As Boolean = True) As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            If DbContext IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                    If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                        MaxEmailSize = LoadMaxEmailSize(DbContext)

                        Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                        If AttachmentFiles IsNot Nothing AndAlso AttachmentFiles.Any Then

                            For Each AttachmentFile In AttachmentFiles

                                Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AttachmentFile))

                            Next

                        End If

                        EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                                  SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo,
                                                                  [To], Cc, Bcc, Subject, IsHTML, Body, Priority, Attachments,
                                                                  MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                                  Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                                  ErrorMessage)

                    Else

                        SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                    End If

                End Using

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                             ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                             ByVal Employee As AdvantageFramework.Database.Views.Employee,
                             ByVal Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment),
                             ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "") As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            If DbContext IsNot Nothing Then

                SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                    MaxEmailSize = LoadMaxEmailSize(DbContext)

                    EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                              SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo,
                                                              AdvantageFramework.EmployeeUtilities.LoadEmailWithEmployeeName(Employee), Nothing, Nothing,
                                                              Subject, True, Body, Priority, Attachments, MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                              Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                              ErrorMessage)

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                End If

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                             ByRef Employee As AdvantageFramework.Database.Views.Employee,
                             ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "",
                             Optional ByVal Cc As String = "",
                             Optional ByVal Bcc As String = "") As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            If DbContext IsNot Nothing Then

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                    MaxEmailSize = LoadMaxEmailSize(DbContext)

                    EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                              SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo,
                                                              AdvantageFramework.EmployeeUtilities.LoadEmailWithEmployeeName(Employee), Cc, Bcc,
                                                              Subject, True, Body, Priority, Nothing, MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                              Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                              ErrorMessage)

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                End If

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                             ByVal [To] As String, ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByVal AttachmentFiles() As String, ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "", Optional ByVal Cc As String = "", Optional ByVal Bcc As String = "") As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            If DbContext IsNot Nothing Then

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                    MaxEmailSize = LoadMaxEmailSize(DbContext)

                    Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                    If AttachmentFiles IsNot Nothing AndAlso AttachmentFiles.Any Then

                        For Each AttachmentFile In AttachmentFiles

                            Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AttachmentFile))

                        Next

                    End If

                    EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                              SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo,
                                                              [To], Cc, Bcc, Subject, True, Body, Priority, Attachments, MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                              Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                              ErrorMessage)

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                End If

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                             ByVal [To] As String, ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByVal AttachmentFiles() As String, ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             ByRef ErrorMessage As String, ByVal Cc As String, ByVal Bcc As String,
                             ByVal FromEmployeeCode As String) As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            If DbContext IsNot Nothing Then

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo, FromEmployeeCode) Then

                    MaxEmailSize = LoadMaxEmailSize(DbContext)

                    Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                    If AttachmentFiles IsNot Nothing AndAlso AttachmentFiles.Any Then

                        For Each AttachmentFile In AttachmentFiles

                            Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AttachmentFile))

                        Next

                    End If

                    EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                              SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo,
                                                              [To], Cc, Bcc, Subject, True, Body, Priority, Attachments, MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                              Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                              ErrorMessage)

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                End If

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                             ByVal [To] As String, ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByVal Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment),
                             UseAdvantageSESIfHosted As Boolean,
                             ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "") As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            If DbContext IsNot Nothing Then

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, UseAdvantageSESIfHosted)

                If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                    MaxEmailSize = LoadMaxEmailSize(DbContext)

                    EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                              SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo,
                                                              [To], Nothing, Nothing, Subject, True, Body, Priority, Attachments, MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                              Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                              ErrorMessage)

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

                End If

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function TestMailBee() As Boolean

            'objects
            Dim IsMailBeeAvailable As Boolean = False
            Dim SMTP As MailBee.SmtpMail.Smtp = Nothing
            MailBee.Global.LicenseKey = MailBeeDotNetKey

            Try

                SMTP = New MailBee.SmtpMail.Smtp

                IsMailBeeAvailable = True

            Catch ex As Exception
                IsMailBeeAvailable = False
            Finally

                If SMTP IsNot Nothing Then

                    SMTP = Nothing

                End If

            End Try

            TestMailBee = IsMailBeeAvailable

        End Function
        ''' <summary>
        ''' Generic Email Send
        ''' </summary>
        Public Function Send(ByVal MailBeeLicenseKey As String, ByVal SMTPAuthenticationMethodType As Integer, ByVal SMTPServer As String,
                             ByVal SMTPPortNumber As Integer,
                             ByVal UserName As String, ByVal Password As String, ByVal From As String,
                             ByVal ReplyTo As String, ByVal [To] As String, ByVal [Cc] As String, ByVal [Bcc] As String, ByVal Subject As String,
                             ByVal IsHTML As Boolean, ByVal Body As String, ByVal Priority As Integer,
                             ByVal Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment), ByVal MaxEmailSize As Long,
                             ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             ByVal SMTPSecureType As Integer,
                             ByVal FileSystemUserName As String, ByVal FileSystemDomain As String, ByVal FileSystemPassword As String,
                             Optional ByRef ErrorMsg As String = ""
                             ) As Boolean

            If String.IsNullOrWhiteSpace([To]) = True And String.IsNullOrWhiteSpace([Cc]) = True And String.IsNullOrWhiteSpace([Bcc]) = True Then Return True

            'objects
            Dim EmailSent As Boolean = False
            Dim SMTP As MailBee.SmtpMail.Smtp = Nothing
            Dim AttachmentsAdded As Boolean = True
            Dim HasAttachment As Boolean = False
            Dim Impersonating As Boolean = False

            Try

                SMTP = CreateMailBeeSMTP(MailBeeLicenseKey, SMTPAuthenticationMethodType, SMTPServer, SMTPPortNumber, UserName, Password, SMTPSecureType)

                If SMTP.Connect Then

                    SMTP.Message.From.AsString = From
                    SMTP.Message.ReplyTo.AsString = ReplyTo

                    SMTP.Message.To.AsString = [To]

                    If String.IsNullOrWhiteSpace([Cc]) = False AndAlso [Cc].Length > 0 Then

                        SMTP.Message.Cc.AsString = [Cc]

                    End If

                    If String.IsNullOrWhiteSpace([Bcc]) = False AndAlso [Bcc].Length > 0 Then

                        SMTP.Message.Bcc.AsString = [Bcc]

                    End If

                    SMTP.Message.Subject = Subject

                    If IsHTML Then

                        SMTP.Message.BodyHtmlText = Body

                    Else

                        SMTP.Message.BodyPlainText = Body

                    End If

                    SetPriority(SMTP, Priority)

                    If Attachments IsNot Nothing AndAlso Attachments.Any Then

                        HasAttachment = True

                        If FileSystemUserName <> "" AndAlso FileSystemDomain <> "" AndAlso FileSystemPassword <> "" Then

                            AdvantageFramework.Security.Impersonate.BeginImpersonation(FileSystemUserName, FileSystemDomain, FileSystemPassword)
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

                        CheckEmailSize(SMTP, MaxEmailSize, AttachmentsAdded)

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

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToConnect

                End If

            Catch ex As Exception

                ErrorMsg = ex.Message.ToString()
                AdvantageFramework.Security.AddWebvantageEventLog(ErrorMsg, EventLogEntryType.Error)
                SendingEmailStatus = Methods.SendingEmailStatus.FailedToSend
                EmailSent = False

            End Try

            Try

                If SMTP IsNot Nothing Then

                    Try

                        SMTP.Disconnect()

                    Catch ex As Exception

                    End Try

                    SMTP.Dispose()
                    SMTP = Nothing

                End If

            Catch ex As Exception

            End Try

            Send = EmailSent

        End Function
        ''' <summary>
        ''' Missing Time Email Send (Employee\Supervisor)
        ''' </summary>
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                             ByRef Agency As AdvantageFramework.Database.Entities.Agency, ByRef Employee As AdvantageFramework.Database.Views.Employee, ByRef AttachmentFile As String,
                             ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "") As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

            If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                MaxEmailSize = LoadMaxEmailSize(DbContext)

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                If String.IsNullOrEmpty(AttachmentFile) = False Then

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AttachmentFile))

                End If

                EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                          SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo, Employee.Email, Nothing, Nothing,
                                                          Subject, True, Body, Priority, Attachments, MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                          Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                          ErrorMessage)

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        ''' <summary>
        ''' Missing Time Email Send (IT Contact)
        ''' </summary>
        Public Function Send(ByVal DbContext As AdvantageFramework.Database.DbContext,
                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                             ByRef Agency As AdvantageFramework.Database.Entities.Agency, ByRef AttachmentFile As String,
                             ByVal Subject As String, ByVal Body As String, ByVal Priority As Integer,
                             ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                             Optional ByRef ErrorMessage As String = "") As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim From As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

            If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                MaxEmailSize = LoadMaxEmailSize(DbContext)

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                If String.IsNullOrEmpty(AttachmentFile) = False Then

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AttachmentFile))

                End If

                EmailSent = AdvantageFramework.Email.Send(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                          SMTPSettings.SMTPPortNumber, UserName, Password, [From], ReplyTo, Agency.ITContactEmail, Nothing, Nothing, Subject,
                                                          True, Body, Priority, Attachments, MaxEmailSize, SendingEmailStatus, SMTPSettings.SMTPSecureType,
                                                          Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword),
                                                          ErrorMessage)

            Else

                SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            End If

            Send = EmailSent

        End Function
        Public Function LoadSMTPSettings(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                         ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                         ByRef SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings,
                                         ByRef UserName As String, ByRef Password As String, ByRef [From] As String,
                                         ByRef ReplyTo As String, FromEmployeeCode As String) As Boolean

            'objects
            Dim SMTPSettingsLoaded As Boolean = False
            Dim FromEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UsingFromEmployeeEmail As Boolean = False
            Dim UsingOAuth2 As Boolean = False
            Dim JavaScriptSerializer As System.Web.Script.Serialization.JavaScriptSerializer = Nothing
            Dim Token As Object = Nothing

            Try

                If SMTPSettings IsNot Nothing AndAlso DbContext IsNot Nothing Then

                    If SMTPSettings.SMTPAuthMethod = SmtpAuthenticationMethods.OAuth2 Then

                        UsingOAuth2 = True

                    End If

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode)

                    'If String.IsNullOrWhiteSpace(FromEmployeeCode) = False Then

                    '    User = AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, FromEmployeeCode).FirstOrDefault

                    'Else

                    '    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode)

                    'End If

                    If SMTPSettings.UseEmployeeLogin Then

                        If User IsNot Nothing Then

                            FromEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                            If FromEmployee IsNot Nothing Then

                                If FromEmployee.Email <> "" Then

                                    UsingFromEmployeeEmail = True

                                    [From] = FromEmployee.Email

                                Else

                                    [From] = SMTPSettings.SMTPSender

                                End If

                                If UsingOAuth2 Then

                                    UserName = FromEmployee.Email
                                    Password = FromEmployee.GoogleToken

                                Else

                                    If FromEmployee.EmailUserName <> "" Then

                                        UserName = FromEmployee.EmailUserName

                                    Else

                                        UserName = SMTPSettings.EmailUsername

                                    End If

                                    If FromEmployee.EmailPassword <> "" Then

                                        Password = AdvantageFramework.Security.Encryption.Decrypt(FromEmployee.EmailPassword)

                                    Else

                                        Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                                    End If

                                End If

                                If FromEmployee.ReplyToEmail <> "" Then

                                    ReplyTo = FromEmployee.ReplyToEmail

                                Else

                                    ReplyTo = SMTPSettings.EmailReplyTo

                                End If

                            Else

                                If Not UsingOAuth2 Then

                                    UserName = SMTPSettings.EmailUsername
                                    Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                                End If

                                [From] = SMTPSettings.SMTPSender
                                ReplyTo = SMTPSettings.EmailReplyTo

                            End If

                        Else

                            If Not UsingOAuth2 Then

                                UserName = SMTPSettings.EmailUsername
                                Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                            End If

                            [From] = SMTPSettings.SMTPSender
                            ReplyTo = SMTPSettings.EmailReplyTo

                        End If

                    Else

                        If Not UsingOAuth2 Then

                            UserName = SMTPSettings.EmailUsername
                            Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                        End If

                        [From] = SMTPSettings.SMTPSender
                        ReplyTo = SMTPSettings.EmailReplyTo

                    End If

                    If UsingOAuth2 Then

                        If String.IsNullOrWhiteSpace(UserName) Then

                            UserName = SMTPSettings.SMTPSender

                        End If

                        If String.IsNullOrWhiteSpace(Password) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                                Password = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SMTP_OAUTH2_TOKEN.ToString).Value

                            End Using

                        End If

                        If Not String.IsNullOrWhiteSpace(Password) Then

                            JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer

                            Token = JavaScriptSerializer.Deserialize(Of Object)(Password)

                            'Password = Token("access_token")

                            Password = AdvantageFramework.GoogleServices.TokenService.GetOrRefreshToken(DbContext.ConnectionString,
                                                                                                        DbContext.ConnectionString.Contains("Integrated Security=SSPI"),
                                                                                                        If(FromEmployee IsNot Nothing, FromEmployee.Code, String.Empty),
                                                                                                        Token("scope").ToString.Split(" "),
                                                                                                        "")

                        End If

                    End If

                    If AdvantageFramework.Email.IsValidEmailAddress([From]) = False Then

                        [From] = UserName & "@" & SMTPSettings.SMTPServer

                    End If

                    If AdvantageFramework.Email.IsValidEmailAddress([From]) = False Then

                        [From] = [From] & ".com"

                    End If

                    If AdvantageFramework.Email.IsValidEmailAddress([From]) = False Then

                        [From] = "webvantage@gotoadvantage.com"

                    End If

                    If String.IsNullOrWhiteSpace(FromEmployeeCode) = False AndAlso FromEmployee Is Nothing Then

                        FromEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, FromEmployeeCode)

                        UsingFromEmployeeEmail = (FromEmployee IsNot Nothing)

                    ElseIf String.IsNullOrWhiteSpace(FromEmployeeCode) = False AndAlso FromEmployee IsNot Nothing Then

                        UsingFromEmployeeEmail = True

                    End If

                    If UsingFromEmployeeEmail Then

                        [From] = AdvantageFramework.EmployeeUtilities.LoadEmailWithEmployeeName(FromEmployee, [From])

                    End If

                    If (Not SMTPSettings.POP3DefaultReplyToEmail Is Nothing AndAlso SMTPSettings.POP3DefaultReplyToEmail <> "") Then

                        ReplyTo = SMTPSettings.POP3DefaultReplyToEmail

                    End If

                    SMTPSettingsLoaded = True

                End If

            Catch ex As Exception
                SMTPSettingsLoaded = False
            Finally
                LoadSMTPSettings = SMTPSettingsLoaded
            End Try

        End Function
        Public Function LoadSMTPSettings(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                         ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                         ByRef SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings,
                                         ByRef UserName As String, ByRef Password As String, ByRef [From] As String,
                                         ByRef ReplyTo As String) As Boolean

            'objects
            Dim SMTPSettingsLoaded As Boolean = False
            Dim FromEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UsingFromEmployeeEmail As Boolean = False
            Dim UsingOAuth2 As Boolean = False
            Dim JavaScriptSerializer As System.Web.Script.Serialization.JavaScriptSerializer = Nothing
            Dim Token As Object = Nothing

            Try

                If SMTPSettings IsNot Nothing AndAlso DbContext IsNot Nothing Then

                    If SMTPSettings.SMTPAuthMethod = SmtpAuthenticationMethods.OAuth2 Then

                        UsingOAuth2 = True

                    End If

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode)

                    If SMTPSettings.UseEmployeeLogin Then

                        If User IsNot Nothing Then

                            FromEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                            If FromEmployee IsNot Nothing Then

                                If FromEmployee.Email <> "" Then

                                    UsingFromEmployeeEmail = True

                                    [From] = FromEmployee.Email

                                Else

                                    [From] = SMTPSettings.SMTPSender

                                End If

                                If UsingOAuth2 Then

                                    UserName = FromEmployee.Email
                                    Password = FromEmployee.GoogleToken

                                Else

                                    If FromEmployee.EmailUserName <> "" Then

                                        UserName = FromEmployee.EmailUserName

                                    Else

                                        UserName = SMTPSettings.EmailUsername

                                    End If

                                    If FromEmployee.EmailPassword <> "" Then

                                        Password = AdvantageFramework.Security.Encryption.Decrypt(FromEmployee.EmailPassword)

                                    Else

                                        Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                                    End If

                                End If

                                If FromEmployee.ReplyToEmail <> "" Then

                                    ReplyTo = FromEmployee.ReplyToEmail

                                Else

                                    ReplyTo = SMTPSettings.EmailReplyTo

                                End If

                            Else

                                If Not UsingOAuth2 Then

                                    UserName = SMTPSettings.EmailUsername
                                    Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                                End If

                                [From] = SMTPSettings.SMTPSender
                                ReplyTo = SMTPSettings.EmailReplyTo

                            End If

                        Else

                            If Not UsingOAuth2 Then

                                UserName = SMTPSettings.EmailUsername
                                Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                            End If

                            [From] = SMTPSettings.SMTPSender
                            ReplyTo = SMTPSettings.EmailReplyTo

                        End If

                    Else

                        If Not UsingOAuth2 Then

                            UserName = SMTPSettings.EmailUsername
                            Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)

                        End If

                        [From] = SMTPSettings.SMTPSender
                        ReplyTo = SMTPSettings.EmailReplyTo

                    End If

                    If UsingOAuth2 Then

                        If String.IsNullOrWhiteSpace(UserName) Then

                            UserName = SMTPSettings.SMTPSender

                        End If

                        If String.IsNullOrWhiteSpace(Password) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                                Password = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SMTP_OAUTH2_TOKEN.ToString).Value

                            End Using

                        End If

                        If Not String.IsNullOrWhiteSpace(Password) Then

                            JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer

                            Token = JavaScriptSerializer.Deserialize(Of Object)(Password)

                            'Password = Token("access_token")

                            Password = AdvantageFramework.GoogleServices.TokenService.GetOrRefreshToken(DbContext.ConnectionString,
                                                                                                        DbContext.ConnectionString.Contains("Integrated Security=SSPI"),
                                                                                                        If(FromEmployee IsNot Nothing, FromEmployee.Code, String.Empty),
                                                                                                        Token("scope").ToString.Split(" "),
                                                                                                        "")

                        End If

                    End If

                    If AdvantageFramework.Email.IsValidEmailAddress([From]) = False Then

                        [From] = UserName & "@" & SMTPSettings.SMTPServer

                    End If

                    If AdvantageFramework.Email.IsValidEmailAddress([From]) = False Then

                        [From] = [From] & ".com"

                    End If

                    If AdvantageFramework.Email.IsValidEmailAddress([From]) = False Then

                        [From] = "webvantage@gotoadvantage.com"

                    End If

                    If UsingFromEmployeeEmail Then

                        [From] = AdvantageFramework.EmployeeUtilities.LoadEmailWithEmployeeName(FromEmployee, [From])

                    End If

                    If (Not SMTPSettings.POP3DefaultReplyToEmail Is Nothing AndAlso SMTPSettings.POP3DefaultReplyToEmail <> "") Then

                        ReplyTo = SMTPSettings.POP3DefaultReplyToEmail

                    End If

                    SMTPSettingsLoaded = True

                End If

            Catch ex As Exception
                SMTPSettingsLoaded = False
            Finally
                LoadSMTPSettings = SMTPSettingsLoaded
            End Try

        End Function
        Public Function LoadSMTPSettings(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                         ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                         ByRef Agency As AdvantageFramework.Database.Entities.Agency,
                                         ByRef UserName As String, ByRef Password As String, ByRef [From] As String,
                                         ByRef ReplyTo As String, ByVal IsClientPortal As Boolean, CPID As Integer) As Boolean

            'objects
            Dim SMTPSettingsLoaded As Boolean = False
            Dim FromEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UsingFromEmployeeEmail As Boolean = False
            Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact = Nothing
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            Try

                If Agency IsNot Nothing AndAlso DbContext IsNot Nothing Then

                    SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                    If IsClientPortal = True Then

                        [From] = SMTPSettings.SMTPSender
                        UserName = SMTPSettings.EmailUsername
                        Password = AdvantageFramework.Security.Encryption.Decrypt(SMTPSettings.EmailPassword)
                        ReplyTo = SMTPSettings.EmailReplyTo

                        If SMTPSettings.UseEmployeeLogin Then

                            'ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, CPID)

                            ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, CPID)

                            If String.IsNullOrEmpty(ClientContact.EmailAddress) = False Then

                                '[From] = ClientContact.EmailAddress
                                ReplyTo = ClientContact.EmailAddress

                            End If

                        End If

                        SMTPSettingsLoaded = True

                    Else

                        SMTPSettingsLoaded = LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo)

                    End If

                End If

            Catch ex As Exception
                SMTPSettingsLoaded = False
            Finally
                LoadSMTPSettings = SMTPSettingsLoaded
            End Try

        End Function
        Public Function LoadSMTPSettings(ByVal ConnectionString As String, ByVal UserCode As String,
                                          ByRef UserName As String, ByRef Password As String, ByRef [From] As String,
                                          ByRef ReplyTo As String) As Boolean

            'objects
            Dim SMTPSettingsLoaded As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        SMTPSettingsLoaded = LoadSMTPSettings(DbContext, SecurityDbContext, New Classes.SMTPSettings(DbContext, Agency, False), UserName, Password, [From], ReplyTo)

                    End Using

                End Using

            Catch ex As Exception
                SMTPSettingsLoaded = False
            Finally
                LoadSMTPSettings = SMTPSettingsLoaded
            End Try

        End Function
        Public Function HasValidSMTPSettings(DbContext As AdvantageFramework.Database.DbContext,
                                             SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             FromEmployeeCode As String, UseAdvantageSESIfHosted As Boolean) As Boolean

            'objects
            Dim SMTPSettingsValid As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim UserName As String = String.Empty
            Dim Password As String = String.Empty
            Dim [From] As String = String.Empty
            Dim ReplyTo As String = String.Empty
            Dim MaxEmailSize As Long = Nothing
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            Try

                If DbContext IsNot Nothing AndAlso SecurityDbContext IsNot Nothing Then

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, UseAdvantageSESIfHosted)

                    If LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo, FromEmployeeCode) Then

                        SMTPSettingsValid = If(String.IsNullOrWhiteSpace(SMTPSettings.SMTPServer) = False AndAlso String.IsNullOrWhiteSpace(UserName) = False AndAlso String.IsNullOrWhiteSpace(Password) = False AndAlso String.IsNullOrWhiteSpace([From]) = False, True, False)

                    End If

                End If

            Catch ex As Exception
                SMTPSettingsValid = False
            End Try

            HasValidSMTPSettings = SMTPSettingsValid

        End Function
        Public Function TestPOP3Settings(ByVal ShowMessage As Boolean, ByVal MailBeeLicenseKey As String, ByVal Server As String, ByVal UserName As String, ByVal Password As String) As Boolean


            'objects
            Dim POP3Listener As MailBee.Pop3Mail.Pop3 = Nothing
            Dim IsValid As Boolean = False

            POP3Listener = New MailBee.Pop3Mail.Pop3

            MailBee.Global.LicenseKey = MailBeeDotNetKey

            If POP3Listener.Connect(Server) Then

                If ShowMessage Then

                    AdvantageFramework.Navigation.ShowMessageBox("Test Successful!")

                End If

                IsValid = True

            Else

                If ShowMessage Then

                    AdvantageFramework.Navigation.ShowMessageBox("Test Failed.")

                End If

                IsValid = False

            End If

            TestPOP3Settings = IsValid

        End Function
        Public Function LoadEmployeeEmail(ByVal Employee As AdvantageFramework.Database.Views.Employee, Optional ByVal CheckEmailFlag As Boolean = False, Optional ByVal GetMailBeeFormatted As Boolean = False) As String

            'objects
            Dim EmailAddress As String = ""
            Dim EmployeeGetsEmail As Boolean = True

            Try

                If CheckEmailFlag Then

                    EmployeeGetsEmail = AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForEmail(Employee)

                End If

                If EmployeeGetsEmail Then

                    If GetMailBeeFormatted Then

                        EmailAddress = Employee.ToString & " <" & Employee.Email & ">"

                    Else

                        EmailAddress = Employee.Email

                    End If

                End If

            Catch ex As Exception
                EmailAddress = ""
            Finally
                LoadEmployeeEmail = EmailAddress
            End Try

        End Function
        Public Function LoadEmployeeEmail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, Optional ByVal CheckEmailFlag As Boolean = False, Optional ByVal GetMailBeeFormatted As Boolean = False)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            LoadEmployeeEmail = LoadEmployeeEmail(Employee, CheckEmailFlag, GetMailBeeFormatted)

        End Function
        Public Function LoadMaxEmailSize(ByVal DbContext As AdvantageFramework.Database.DbContext) As Long

            'objects
            Dim MaxEmailSize As Long = 0

            Try

                MaxEmailSize = DbContext.Database.SqlQuery(Of Long)("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, ISNULL(AGY_SETTINGS_DEF, 0)) AS bigint) FROM dbo.AGY_SETTINGS WHERE [AGY_SETTINGS_CODE] = 'MAX_EMAIL_SIZE'").Single

                MaxEmailSize = MaxEmailSize * AdvantageFramework.FileSystem.MBInBytes

            Catch ex As Exception
                MaxEmailSize = 0
            End Try

            LoadMaxEmailSize = MaxEmailSize

        End Function
        Public Sub CheckEmailSize(ByRef SMTP As MailBee.SmtpMail.Smtp, ByVal MaxEmailSize As Long, ByRef AttachmentAdded As Boolean)


            Try

                If MaxEmailSize > 0 AndAlso SMTP.Message.Size > MaxEmailSize Then

                    SMTP.Message.Attachments.Clear()
                    AttachmentAdded = False

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Function LoadEmailWithName(ByVal Name As String, ByVal Email As String) As String

            'objects
            Dim EmailWithName As String = ""

            Try

                EmailWithName = Name & " <" & Email & ">"

            Catch ex As Exception
                EmailWithName = ""
            Finally
                LoadEmailWithName = EmailWithName
            End Try

        End Function
        Public Sub SetPriority(ByRef EmailMessage As MailBee.SmtpMail.Smtp, ByVal PriorityLevel As MailBee.Mime.MailPriority)

            Try

                Select Case PriorityLevel
                    Case MailBee.Mime.MailPriority.Highest
                        EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Highest
                        EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Highest

                    Case MailBee.Mime.MailPriority.High
                        EmailMessage.Message.Priority = MailBee.Mime.MailPriority.High
                        EmailMessage.Message.Importance = MailBee.Mime.MailPriority.High

                    Case MailBee.Mime.MailPriority.Normal

                        EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Normal
                        EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Normal

                    Case MailBee.Mime.MailPriority.Low

                        EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Low
                        EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Low

                    Case MailBee.Mime.MailPriority.Lowest

                        EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Lowest
                        EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Lowest

                End Select

            Catch ex As Exception

            End Try

            Try

                EmailMessage.Message.Headers.Add("X-MSMail-Priority", EmailMessage.Message.Priority.ToString(), True)
                EmailMessage.Message.Headers.Add("Importance", EmailMessage.Message.Priority.ToString(), True)

            Catch ex As Exception

            End Try

        End Sub
        Public Function LoadEmailErrorMessage(ByVal SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus) As String

            'objects
            Dim ErrorMessage As String = ""

            Select Case SendingEmailStatus

                Case Email.SendingEmailStatus.EmailSentWithoutAttachment

                    ErrorMessage = "Message exceeds maximum email size. Attachments were excluded but the email was still sent."

                Case Email.SendingEmailStatus.FailedToConnect

                    ErrorMessage = "There was a problem connecting to the email server. Message was not sent."

                Case Email.SendingEmailStatus.FailedToLoadSettings

                    ErrorMessage = "There was a problem loading email settings. Message was not sent."

                Case Email.SendingEmailStatus.FailedToSend

                    ErrorMessage = "Message failed to send."

                Case Email.SendingEmailStatus.EmailSent

                    ErrorMessage = ""

                Case Else

                    ErrorMessage = AdvantageFramework.StringUtilities.GetNameAsWords(SendingEmailStatus)

            End Select

            LoadEmailErrorMessage = ErrorMessage

        End Function

#End Region

    End Module

End Namespace


