Namespace Email

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const MailBeeDotNetKey As String = "MN120-4D857ACC84818593857E6A7C9EEB-F72F" ' "MN700-CF0778C1075F07C1078BF870175F-B389"
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
        Public Enum SmtpAuthenticationMethods
            NoAuthentication = 0
            Plain = 1
            Login = 2
            CRAMLD5 = 3
            NTLM = 4
            MSN = 5
            OAuth2 = 6
        End Enum
        Public Enum SecureTypes
            UseSSL = 1
            UseTLS = 2
            NoSecureProtocol = 0
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CreateMailBeeSMTP(MailBeeLicenseKey As String, SMTPAuthenticationMethodType As Integer, SMTPServer As String,
                                          SMTPPortNumber As Integer, UserName As String, Password As String,
                                          SMTPSecureType As Integer) As MailBee.SmtpMail.Smtp

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

                If SMTPSecureType <> Email.SecureTypes.NoSecureProtocol Then

                    If SMTPSecureType = Email.SecureTypes.UseTLS Then

                        MailBeeServerInfo.SslMode = MailBee.Security.SslStartupMode.UseStartTls

                    End If

                End If

                MailBeeServerInfo.Timeout = 60000

                MailBeeServerInfo.HelloDomain = MailBeeServerInfo.Name
                MailBeeSmtp.DirectSendDefaults.HelloDomain = MailBeeServerInfo.Name

                MailBeeSmtp.SmtpServers.Add(MailBeeServerInfo)

                'End If

            Catch ex As Exception
                MailBeeSmtp = Nothing
            Finally
                CreateMailBeeSMTP = MailBeeSmtp
            End Try

        End Function
        Public Function IsValidEmailAddress(EmailAddress As String) As Boolean

            If String.IsNullOrWhiteSpace(EmailAddress) = False Then

                IsValidEmailAddress = EmailAddress.IsValidEmailAddress

            Else

                IsValidEmailAddress = False

            End If

        End Function
        Public Function HasValidSMTPSettings() As Boolean

            'objects
            Dim SMTPSettingsValid As Boolean = False
            Dim SMTPServer As String = String.Empty
            Dim UserName As String = String.Empty
            Dim Password As String = String.Empty
            Dim [From] As String = String.Empty
            Dim ReplyTo As String = String.Empty
            Dim MaxEmailSize As Long = Nothing

            Try

                'If DbContext IsNot Nothing AndAlso SecurityDbContext IsNot Nothing Then

                'If LoadSMTPSettings(DbContext, SecurityDbContext, Agency, UserName, Password, [From], ReplyTo, FromEmployeeCode) Then

                SMTPSettingsValid = If(String.IsNullOrWhiteSpace(SMTPServer) = False AndAlso String.IsNullOrWhiteSpace(UserName) = False AndAlso String.IsNullOrWhiteSpace(Password) = False AndAlso String.IsNullOrWhiteSpace([From]) = False, True, False)

                'End If

                'End If

            Catch ex As Exception
                SMTPSettingsValid = False
            End Try

            HasValidSMTPSettings = SMTPSettingsValid

        End Function
        Public Function LoadEmailWithName(Name As String, Email As String) As String

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
        Public Sub SetPriority(ByRef EmailMessage As MailBee.SmtpMail.Smtp, PriorityLevel As MailBee.Mime.MailPriority)

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
        Public Function LoadEmailErrorMessage(SendingEmailStatus As Email.SendingEmailStatus) As String

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

                    ErrorMessage = SendingEmailStatus.ToString.GetNameAsWords

            End Select

            LoadEmailErrorMessage = ErrorMessage

        End Function

#End Region

    End Module

End Namespace


