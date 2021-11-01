using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace AdvantageFramework.Core.Email
{
    public static partial class Methods
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public const string MailBeeDotNetKey = "MN120-4D857ACC84818593857E6A7C9EEB-F72F"; // "MN700-CF0778C1075F07C1078BF870175F-B389"
        public const string Font = "Verdana, Arial, Helvetica, sans-serif";
        public const string BodyBackgroundColor = "#FFFFFF";
        public const bool HeaderShowBottomBorder = false;
        public const string HeaderBackgroundColor = "#FFFFFF";
        public const int HeaderFontSize = 3;
        public const string HeaderFontColor = "#333333";
        public const bool HeaderBold = true;
        public const string RowBackgroundColor = "#FFFFFF";
        public const int RowFontSize = 2;
        public const int RowFontSizeSmall = 1;
        public const string RowFontColor = "#333333";
        public const bool RowBoldLabel = false;
        public const string HorizontalLineColor = "#333333";
        public const string LineBreak = "<br />";
        public const string NonBreakingSpace = "&nbsp;";

        // IF THESE ARE CHANGED, UPDATE THEM IN GOOGLE SERVICES PROJECT!!!
        public const string GoogleClientID = "641931340891-99hr8ijdob0b40mkk5ar2s2nn0nnss12.apps.googleusercontent.com";
        public const string GoogleClientSecret = "iEnotTrS7pjQ94gDoKm2eS7G";


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum SendingEmailStatus
        {
            EmailSent,
            EmailSentWithoutAttachment,
            FailedToConnect,
            FailedToSend,
            FailedToLoadSettings
        }

        public enum POP3SecureTypes
        {
            UseSSL = 1,
            UseTLS = 2,
            NoSecureProtocol = 0
        }

        public enum POP3AuthenticationMethods
        {
            NoAuthentication = 0,
            Plain = 1,
            Login = 2,
            CRAMLD5 = 3,
            NTLM = 4,
            MSN = 5
        }

        public enum SmtpAuthenticationMethods
        {
            NoAuthentication = 0,
            Plain = 1,
            Login = 2,
            CRAMLD5 = 3,
            NTLM = 4,
            MSN = 5,
            OAuth2 = 6
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static MailBee.SmtpMail.Smtp CreateMailBeeSMTP(string MbKey, int SmtpAuthMethod, string SmtpServer, int SmtpPortNumber, string UserName, string Password, int SMTPSecureType)
        {
            MailBee.SmtpMail.Smtp CreateMailBeeSMTPRet = default;

            // objects
            MailBee.SmtpMail.Smtp MailBeeSmtp = default;
            MailBee.SmtpMail.SmtpServer MailBeeServerInfo = default;
            try
            {
                MailBee.Global.LicenseKey = MbKey;
                MailBeeSmtp = new MailBee.SmtpMail.Smtp();

                // If SmtpAuthMethod = SmtpAuthenticationMethods.OAuth2 Then

                // 'With New MailBee.OAuth2(GoogleClientID, GoogleClientSecret)

                // '    Password = .GetXOAuthKey(UserName, Password)

                // 'End With

                // 'MailBeeSmtp.SmtpServers.Add(SmtpServer, UserName, Password, MailBee.AuthenticationMethods.SaslOAuth2)

                // Else


                MailBeeServerInfo = new MailBee.SmtpMail.SmtpServer();
                switch (SmtpAuthMethod)
                {
                    case 0:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.None;
                            break;
                        }

                    case 1:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslPlain;
                            break;
                        }

                    case 2:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslLogin;
                            break;
                        }

                    case 3:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslCramMD5;
                            break;
                        }

                    case 4:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslNtlm;
                            break;
                        }

                    case 5:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslMsn;
                            break;
                        }

                    case 6:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.SaslOAuth2;
                            break;
                        }

                    default:
                        {
                            MailBeeServerInfo.AuthMethods = MailBee.AuthenticationMethods.Auto;
                            break;
                        }
                }

                MailBeeServerInfo.Name = SmtpServer;
                MailBeeServerInfo.AccountName = UserName;
                if (MailBeeServerInfo.AuthMethods == MailBee.AuthenticationMethods.SaslOAuth2)
                {
                    {
                        var withBlock = new MailBee.OAuth2(GoogleClientID, GoogleClientSecret);
                        MailBeeServerInfo.Password = withBlock.GetXOAuthKey(UserName, Password);
                    }
                }
                else
                {
                    MailBeeServerInfo.Password = Password;
                }

                if (SmtpPortNumber != 0)
                {
                    MailBeeServerInfo.Port = SmtpPortNumber;
                }

                if (SMTPSecureType != (int)POP3SecureTypes.NoSecureProtocol)
                {
                    if (SMTPSecureType == (int)AdvantageFramework.Core.Email.Methods.POP3SecureTypes.UseTLS)
                    {
                        MailBeeServerInfo.SslMode = MailBee.Security.SslStartupMode.UseStartTls;
                    }
                }

                MailBeeServerInfo.Timeout = 60000;
                MailBeeServerInfo.HelloDomain = MailBeeServerInfo.Name;
                MailBeeSmtp.DirectSendDefaults.HelloDomain = MailBeeServerInfo.Name;
                MailBeeSmtp.SmtpServers.Add(MailBeeServerInfo);
            }

            // End If

            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                MailBeeSmtp = default;
            }
            finally
            {
                CreateMailBeeSMTPRet = MailBeeSmtp;
            }

            return CreateMailBeeSMTPRet;
        }

        private static MailBee.Pop3Mail.Pop3 InitMailBeePop3(AdvantageFramework.Core.Database.Entities.Agency Agency, ref MailBee.AuthenticationMethods AuthenticationMethod)
        {
            MailBee.Pop3Mail.Pop3 InitMailBeePop3Ret = default;

            // objects
            MailBee.Pop3Mail.Pop3 POP3 = default;
            bool Connected = false;
            try
            {
                MailBee.Global.LicenseKey = MailBeeDotNetKey;
                POP3 = new MailBee.Pop3Mail.Pop3();
                POP3.RaiseEvents = true;
                if (Agency.Pop3SecureType.GetValueOrDefault(0) != (int)AdvantageFramework.Core.Email.Methods.POP3SecureTypes.NoSecureProtocol)
                {
                    if (Agency.Pop3SecureType.GetValueOrDefault(0) == (int)AdvantageFramework.Core.Email.Methods.POP3SecureTypes.UseTLS)
                    {
                        POP3.SslMode = MailBee.Security.SslStartupMode.UseStartTls;
                    }
                }

                if (Agency.Pop3PortNumber is object)
                {
                    Connected = POP3.Connect(Agency.Pop3Server, (int)Agency.Pop3PortNumber);
                }
                else
                {
                    Connected = POP3.Connect(Agency.Pop3Server);
                }

                if (Connected == true)
                {
                    if (Agency.Pop3AuthMethod is object)
                    {
                        switch (Agency.Pop3AuthMethod)
                        {
                            case 0:
                                {
                                    AuthenticationMethod = MailBee.AuthenticationMethods.None;
                                    break;
                                }

                            case 1:
                                {
                                    AuthenticationMethod = MailBee.AuthenticationMethods.Regular;
                                    break;
                                }

                            case 3:
                                {
                                    AuthenticationMethod = MailBee.AuthenticationMethods.SaslCramMD5;
                                    break;
                                }

                            case 4:
                                {
                                    AuthenticationMethod = MailBee.AuthenticationMethods.SaslNtlm;
                                    break;
                                }

                            case 5:
                                {
                                    AuthenticationMethod = MailBee.AuthenticationMethods.SaslMsn;
                                    break;
                                }

                            default:
                                {
                                    AuthenticationMethod = MailBee.AuthenticationMethods.Auto;
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    POP3 = default;
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                POP3 = default;
            }
            finally
            {
                InitMailBeePop3Ret = POP3;
            }

            return InitMailBeePop3Ret;
        }

        public static MailBee.Pop3Mail.Pop3 CreateMailBeePOP3(AdvantageFramework.Core.Database.Entities.Agency Agency)
        {
            MailBee.Pop3Mail.Pop3 CreateMailBeePOP3Ret = default;
            CreateMailBeePOP3Ret = CreateMailBeePOP3(Agency, Agency.Pop3Username, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.Pop3Pwd));
            return CreateMailBeePOP3Ret;
        }

        /* TODO ERROR: */
        public static MailBee.Pop3Mail.Pop3 CreateMailBeePOP3(AdvantageFramework.Core.Database.Entities.Agency Agency, AdvantageFramework.Core.Database.Entities.POP3EmailListenerAccount POP3EmailListenerAccount)
        {
            MailBee.Pop3Mail.Pop3 CreateMailBeePOP3Ret = default;
            CreateMailBeePOP3Ret = CreateMailBeePOP3(Agency, POP3EmailListenerAccount.Username, AdvantageFramework.Core.Security.Encryption.Decrypt(POP3EmailListenerAccount.Password));
            return CreateMailBeePOP3Ret;
        }

        /* TODO ERROR: */
        public static MailBee.Pop3Mail.Pop3 CreateMailBeePOP3(AdvantageFramework.Core.Database.Entities.Agency Agency, AdvantageFramework.Core.Database.Entities.POP3AutomatedAssignmentAccount POP3AutomatedAssignmentAccount)
        {
            MailBee.Pop3Mail.Pop3 CreateMailBeePOP3Ret = default;
            CreateMailBeePOP3Ret = CreateMailBeePOP3(Agency, POP3AutomatedAssignmentAccount.Username, AdvantageFramework.Core.Security.Encryption.Decrypt(POP3AutomatedAssignmentAccount.Password));
            return CreateMailBeePOP3Ret;
        }

        public static MailBee.Pop3Mail.Pop3 CreateMailBeePOP3(AdvantageFramework.Core.Database.Entities.Agency Agency, string UserName, string Password)
        {
            MailBee.Pop3Mail.Pop3 CreateMailBeePOP3Ret = default;
            MailBee.Pop3Mail.Pop3 POP3 = default;
            bool LoggedIn = false;
            MailBee.AuthenticationMethods AuthenticationMethod = MailBee.AuthenticationMethods.None;
            try
            {
                POP3 = InitMailBeePop3(Agency, ref AuthenticationMethod);
                if (POP3 is object)
                {
                    LoggedIn = POP3.Login(UserName, Password, AuthenticationMethod);
                }

                if (!LoggedIn)
                {
                    POP3 = default;
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                POP3 = default;
            }
            finally
            {
                CreateMailBeePOP3Ret = POP3;
            }

            return CreateMailBeePOP3Ret;
        }

        public static bool IsValidEmailAddress(ref string EmailAddress)
        {
            bool IsValidEmailAddressRet = default;
            IsValidEmailAddressRet = AdvantageFramework.Core.StringUtilities.Methods.IsValidEmailAddress(EmailAddress);
            return IsValidEmailAddressRet;
        }
        /// <summary>
        /// Generic Email Send
        /// </summary>
        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext,
            string To, string Cc, string Bcc, string Subject, string Body, int Priority,
            List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments,
            ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus,
            ref string ErrorMessage, bool IsHTML = true)
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            if (DbContext is object)
            {
                /* TODO ERROR: */
                using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode))
                {
                    Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                    var argSecurityDbContext = SecurityDbContext;
                    if (LoadSMTPSettings(ref DbContext, ref argSecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
                    {
                        MaxEmailSize = LoadMaxEmailSize(DbContext);
                        EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, To, Cc, Bcc, Subject, IsHTML, Body, Priority, Attachments, MaxEmailSize, ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword), ref ErrorMessage);
                    }
                    else
                    {
                        SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
                    }
                }
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext,
            string To, string Cc, string Bcc, string Subject, string Body, int Priority,
            string[] AttachmentFiles, ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus,
            [Optional, DefaultParameterValue("")] ref string ErrorMessage, bool IsHTML = true)
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments = null;
            if (DbContext is object)
            {
                /* TODO ERROR: */
                using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode))
                {
                    Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                    var argSecurityDbContext = SecurityDbContext;
                    if (LoadSMTPSettings(ref DbContext, ref argSecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
                    {
                        MaxEmailSize = LoadMaxEmailSize(DbContext);
                        Attachments = new List<AdvantageFramework.Core.Email.Classes.Attachment>();
                        if (AttachmentFiles is object && AttachmentFiles.Any())
                        {
                            foreach (var AttachmentFile in AttachmentFiles)
                                Attachments.Add(new AdvantageFramework.Core.Email.Classes.Attachment(AttachmentFile));
                        }

                        EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey,
                            (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0),
                            UserName, Password, From, ReplyTo, To, Cc, Bcc, Subject, IsHTML, Body, Priority, Attachments, MaxEmailSize, ref SendingEmailStatus,
                            (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, 
                            AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword),ref ErrorMessage);
                    }
                    else
                    {
                        SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
                    }
                }
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext,
            AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext,
            AdvantageFramework.Core.Database.Entities.Agency Agency,
            AdvantageFramework.Core.Database.Views.Employee Employee,
            List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments,
            string Subject, string Body, int Priority,
            ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus,
            [Optional, DefaultParameterValue("")] ref string ErrorMessage)
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            if (DbContext is object)
            {
                if (LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
                {
                    MaxEmailSize = LoadMaxEmailSize(DbContext);
                    EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, AdvantageFramework.Core.EmployeeUtilities.Methods.LoadEmailWithEmployeeName(Employee), default, default, Subject, true, Body, Priority, Attachments, MaxEmailSize, ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword),ref ErrorMessage);
                }
                else
                {
                    SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
                }
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext,
            AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext,
            ref AdvantageFramework.Core.Database.Views.Employee Employee,
            string Subject, string Body, int Priority,
            ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus,
            [Optional, DefaultParameterValue("")] ref string ErrorMessage, string Cc = "", string Bcc = "")
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            if (DbContext is object)
            {
                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                if (LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
                {
                    MaxEmailSize = LoadMaxEmailSize(DbContext);
                    EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, AdvantageFramework.Core.EmployeeUtilities.Methods.LoadEmailWithEmployeeName(Employee), Cc, Bcc, Subject, true, Body, Priority, default, MaxEmailSize, ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword),ref ErrorMessage);
                }
                else
                {
                    SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
                }
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext,
            AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext,
            string To, string Subject, string Body, int Priority,
            string[] AttachmentFiles, ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus,
            [Optional, DefaultParameterValue("")] ref string ErrorMessage, string Cc = "", string Bcc = "")
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments = null;
            if (DbContext is object)
            {
                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                if (LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
                {
                    MaxEmailSize = LoadMaxEmailSize(DbContext);
                    Attachments = new List<AdvantageFramework.Core.Email.Classes.Attachment>();
                    if (AttachmentFiles is object && AttachmentFiles.Any())
                    {
                        foreach (var AttachmentFile in AttachmentFiles)
                            Attachments.Add(new AdvantageFramework.Core.Email.Classes.Attachment(AttachmentFile));
                    }

                    EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, To, Cc, Bcc, Subject, true, Body, Priority, Attachments, MaxEmailSize, ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword), ref ErrorMessage);
                }
                else
                {
                    SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
                }
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, string To, string Subject, string Body, int Priority, string[] AttachmentFiles, ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus, ref string ErrorMessage, string Cc, string Bcc, string FromEmployeeCode)
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments = null;
            if (DbContext is object)
            {
                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                if (LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo, FromEmployeeCode))
                {
                    MaxEmailSize = LoadMaxEmailSize(DbContext);
                    Attachments = new List<AdvantageFramework.Core.Email.Classes.Attachment>();
                    if (AttachmentFiles is object && AttachmentFiles.Any())
                    {
                        foreach (var AttachmentFile in AttachmentFiles)
                            Attachments.Add(new AdvantageFramework.Core.Email.Classes.Attachment(AttachmentFile));
                    }

                    EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, To, Cc, Bcc, Subject, true, Body, Priority, Attachments, MaxEmailSize, ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword),ref ErrorMessage);
                }
                else
                {
                    SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
                }
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, string To, string Subject, string Body, int Priority, List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments, ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus, [Optional, DefaultParameterValue("")] ref string ErrorMessage)
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            if (DbContext is object)
            {
                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                if (LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
                {
                    MaxEmailSize = LoadMaxEmailSize(DbContext);
                    EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, To, default, default, Subject, true, Body, Priority, Attachments, MaxEmailSize,ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword),ref ErrorMessage);
                }
                else
                {
                    SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
                }
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        /// <summary>
        /// Generic Email Send
        /// </summary>
        public static bool Send(string MbKey, int SmtpAuthMethod, string SmtpServer, int SmtpPortNumber, string UserName, string Password, string From, string ReplyTo, string To, string Cc, string Bcc, string Subject, bool IsHTML, string Body, int Priority, List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments, long MaxEmailSize, ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus, int SMTPSecureType, string DocRepositoryUserName, string DocRepositoryUserDomain, string DocRepositoryUserPassword, [Optional, DefaultParameterValue("")] ref string ErrorMsg)
        {
            bool SendRet = default;
            if (string.IsNullOrWhiteSpace(To) == true & string.IsNullOrWhiteSpace(Cc) == true & string.IsNullOrWhiteSpace(Bcc) == true)
                return true;

            // objects
            bool EmailSent = false;
            MailBee.SmtpMail.Smtp SMTP = default;
            bool AttachmentsAdded = true;
            bool HasAttachment = false;
            bool Impersonating = false;
            try
            {
                SMTP = CreateMailBeeSMTP(MbKey, SmtpAuthMethod, SmtpServer, SmtpPortNumber, UserName, Password, SMTPSecureType);
                if (SMTP.Connect())
                {
                    SMTP.Message.From.AsString = From;
                    SMTP.Message.ReplyTo.AsString = ReplyTo;
                    SMTP.Message.To.AsString = To;
                    if (string.IsNullOrWhiteSpace(Cc) == false && Cc.Length > 0)
                    {
                        SMTP.Message.Cc.AsString = Cc;
                    }

                    if (string.IsNullOrWhiteSpace(Bcc) == false && Bcc.Length > 0)
                    {
                        SMTP.Message.Bcc.AsString = Bcc;
                    }

                    SMTP.Message.Subject = Subject;
                    if (IsHTML)
                    {
                        SMTP.Message.BodyHtmlText = Body;
                    }
                    else
                    {
                        SMTP.Message.BodyPlainText = Body;
                    }

                    SetPriority(ref SMTP, (MailBee.Mime.MailPriority)Priority);
                    if (Attachments is object && Attachments.Any())
                    {
                        HasAttachment = true;
                        if (!string.IsNullOrEmpty(DocRepositoryUserName) && !string.IsNullOrEmpty(DocRepositoryUserDomain) && !string.IsNullOrEmpty(DocRepositoryUserPassword))
                        {
                            AdvantageFramework.Core.Security.Impersonate.BeginImpersonation(DocRepositoryUserName, DocRepositoryUserDomain, DocRepositoryUserPassword);
                            Impersonating = true;
                        }

                        foreach (var Attachment in Attachments)
                        {
                            if (string.IsNullOrEmpty(Attachment.File) == false)
                            {
                                try
                                {
                                    if (string.IsNullOrWhiteSpace(Attachment.AttachmentName) == false)
                                    {
                                        if (SMTP.Message.Attachments.Add(Attachment.File, Attachment.AttachmentName, default) == false)
                                        {
                                            AttachmentsAdded = false;
                                        }
                                    }
                                    else if (SMTP.AddAttachment(Attachment.File) == false)
                                    {
                                        AttachmentsAdded = false;
                                    }
                                }
                                catch (Exception)
                                {
                                    AttachmentsAdded = false;
                                }
                            }
                            else if (Attachment.FileBytes is object)
                            {
                                try
                                {
                                    SMTP.Message.Attachments.Add(Attachment.FileBytes, Attachment.AttachmentName, default, default, default, MailBee.Mime.NewAttachmentOptions.ReplaceIfExists, MailBee.Mime.MailTransferEncoding.Base64);
                                }
                                catch (Exception)
                                {
                                    AttachmentsAdded = false;
                                }
                            }
                            else
                            {
                                AttachmentsAdded = false;
                            }
                        }

                        CheckEmailSize(ref SMTP, MaxEmailSize, ref AttachmentsAdded);
                        if (Impersonating == true)
                        {
                            AdvantageFramework.Core.Security.Impersonate.EndImpersonation();
                        }
                    }
                    else
                    {
                        AttachmentsAdded = false;
                    }

                    if (SMTP.Send())
                    {
                        if (HasAttachment)
                        {
                            if (AttachmentsAdded)
                            {
                                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.EmailSent;
                            }
                            else
                            {
                                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.EmailSentWithoutAttachment;
                            }
                        }
                        else
                        {
                            SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.EmailSent;
                        }

                        EmailSent = true;
                    }
                    else
                    {
                        SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToSend;
                    }
                }
                else
                {
                    SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToConnect;
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message.ToString();
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ErrorMsg, System.Diagnostics.EventLogEntryType.Error);
                SendingEmailStatus = Methods.SendingEmailStatus.FailedToSend;
                EmailSent = false;
            }

            try
            {
                if (SMTP is object)
                {
                    try
                    {
                        SMTP.Disconnect();
                    }
                    catch (Exception)
                    {
                    }

                    SMTP.Dispose();
                    SMTP = default;
                }
            }
            catch (Exception)
            {
            }

            SendRet = EmailSent;
            return SendRet;
        }
        /// <summary>
        /// Missing Time Email Send (Employee\Supervisor)
        /// </summary>
        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref AdvantageFramework.Core.Database.Entities.Agency Agency, ref AdvantageFramework.Core.Database.Views.Employee Employee, ref string AttachmentFile, string Subject, string Body, int Priority, ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus, [Optional, DefaultParameterValue("")] ref string ErrorMessage)
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments = null;
            if (LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
            {
                MaxEmailSize = LoadMaxEmailSize(DbContext);
                Attachments = new List<AdvantageFramework.Core.Email.Classes.Attachment>();
                if (string.IsNullOrEmpty(AttachmentFile) == false)
                {
                    Attachments.Add(new AdvantageFramework.Core.Email.Classes.Attachment(AttachmentFile));
                }

                EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, Employee.EmpEmail, default, default, Subject, true, Body, Priority, Attachments, MaxEmailSize, ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword), ref ErrorMessage);
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }
        /// <summary>
        /// Missing Time Email Send (IT Contact)
        /// </summary>
        public static bool Send(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref AdvantageFramework.Core.Database.Entities.Agency Agency, ref string AttachmentFile, string Subject, string Body, int Priority, ref AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus, [Optional, DefaultParameterValue("")] ref string ErrorMessage)
        {
            bool SendRet = default;

            // objects
            bool EmailSent = false;
            string UserName = "";
            string Password = "";
            string From = "";
            string ReplyTo = "";
            long MaxEmailSize = default;
            List<AdvantageFramework.Core.Email.Classes.Attachment> Attachments = null;
            if (LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo))
            {
                MaxEmailSize = LoadMaxEmailSize(DbContext);
                Attachments = new List<AdvantageFramework.Core.Email.Classes.Attachment>();
                if (string.IsNullOrEmpty(AttachmentFile) == false)
                {
                    Attachments.Add(new AdvantageFramework.Core.Email.Classes.Attachment(AttachmentFile));
                }

                EmailSent = AdvantageFramework.Core.Email.Methods.Send(Agency.MbKey, (int)Agency.SmtpAuthMethod, Agency.SmtpServer, Agency.SmtpPortNumber.GetValueOrDefault(0), UserName, Password, From, ReplyTo, Agency.ItContactEmail, default, default, Subject, true, Body, Priority, Attachments, MaxEmailSize, ref SendingEmailStatus, (int)Agency.SmtpSecureType, Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword), ref ErrorMessage);
            }
            else
            {
                SendingEmailStatus = AdvantageFramework.Core.Email.Methods.SendingEmailStatus.FailedToLoadSettings;
            }

            SendRet = EmailSent;
            return SendRet;
        }

        public static bool LoadSMTPSettings(ref AdvantageFramework.Core.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref AdvantageFramework.Core.Database.Entities.Agency Agency, ref string UserName, ref string Password, ref string From, ref string ReplyTo, string FromEmployeeCode)
        {
            bool LoadSMTPSettingsRet = default;

            // objects
            bool SMTPSettingsLoaded = false;
            AdvantageFramework.Core.Database.Views.Employee FromEmployee = default;
            AdvantageFramework.Core.Security.Database.Entities.User User = default;
            bool UsingFromEmployeeEmail = false;
            bool UsingOAuth2 = false;
            object Token = null;
            try
            {
                if (Agency is object && DbContext is object)
                {
                    if (Agency.SmtpAuthMethod.GetValueOrDefault(0) == (int)SmtpAuthenticationMethods.OAuth2)
                    {
                        UsingOAuth2 = true;
                    }

                    User = AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode);

                    if (Agency.SmtpUseEmpLogin.GetValueOrDefault(0) == 1)
                    {
                        if (User is object)
                        {
                            FromEmployee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmpCode);
                            if (FromEmployee is object)
                            {
                                if (FromEmployee.EmpEmail != "")
                                {
                                    UsingFromEmployeeEmail = true;
                                    From = FromEmployee.EmpEmail;
                                }
                                else
                                {
                                    From = Agency.SmtpSender;
                                }

                                if (UsingOAuth2)
                                {
                                    UserName = FromEmployee.EmpEmail;
                                    Password = FromEmployee.GoogleToken;
                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(FromEmployee.EmailUsername))
                                    {
                                        UserName = FromEmployee.EmailUsername;
                                    }
                                    else
                                    {
                                        UserName = Agency.EmailUsername;
                                    }

                                    if (!string.IsNullOrWhiteSpace(FromEmployee.EmailPwd))
                                    {
                                        Password = AdvantageFramework.Core.Security.Encryption.Decrypt(FromEmployee.EmailPwd);
                                    }
                                    else
                                    {
                                        Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                                    }
                                }

                                if (!string.IsNullOrWhiteSpace(FromEmployee.EmailReplyTo))
                                {
                                    ReplyTo = FromEmployee.EmailReplyTo;
                                }
                                else
                                {
                                    ReplyTo = Agency.EmailReplyTo;
                                }
                            }
                            else
                            {
                                if (!UsingOAuth2)
                                {
                                    UserName = Agency.EmailUsername;
                                    Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                                }

                                From = Agency.SmtpSender;
                                ReplyTo = Agency.EmailReplyTo;
                            }
                        }
                        else
                        {
                            if (!UsingOAuth2)
                            {
                                UserName = Agency.EmailUsername;
                                Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                            }

                            From = Agency.SmtpSender;
                            ReplyTo = Agency.EmailReplyTo;
                        }
                    }
                    else
                    {
                        if (!UsingOAuth2)
                        {
                            UserName = Agency.EmailUsername;
                            Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                        }

                        From = Agency.SmtpSender;
                        ReplyTo = Agency.EmailReplyTo;
                    }

                    if (UsingOAuth2)
                    {
                        if (string.IsNullOrWhiteSpace(UserName))
                        {
                            UserName = Agency.SmtpSender;
                        }

                        if (string.IsNullOrWhiteSpace(Password))
                        {
                            using (var DataContext = new AdvantageFramework.Core.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode))
                            {
                                Password = (string)Database.Procedures.Settings.LoadBySettingCode(DataContext, AdvantageFramework.Core.Agency.Methods.Settings.SMTP_OAUTH2_TOKEN.ToString()).Value;
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(Password))
                        {
                            Token = JsonSerializer.Deserialize<object>(Password);
                        }
                    }

                    if (AdvantageFramework.Core.Email.Methods.IsValidEmailAddress(ref From) == false)
                    {
                        From = UserName + "@" + Agency.SmtpServer;
                    }

                    if (AdvantageFramework.Core.Email.Methods.IsValidEmailAddress(ref From) == false)
                    {
                        From = From + ".com";
                    }

                    if (AdvantageFramework.Core.Email.Methods.IsValidEmailAddress(ref From) == false)
                    {
                        From = "webvantage@gotoadvantage.com";
                    }

                    if (string.IsNullOrWhiteSpace(FromEmployeeCode) == false && FromEmployee is null)
                    {
                        FromEmployee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, FromEmployeeCode);
                        UsingFromEmployeeEmail = FromEmployee is object;
                    }
                    else if (string.IsNullOrWhiteSpace(FromEmployeeCode) == false && FromEmployee is object)
                    {
                        UsingFromEmployeeEmail = true;
                    }

                    if (UsingFromEmployeeEmail)
                    {
                        From = AdvantageFramework.Core.EmployeeUtilities.Methods.LoadEmailWithEmployeeName(FromEmployee, From);
                    }

                    if (Agency.Pop3Server is object && Agency.Pop3Server != "" && Agency.Pop3Username is object && Agency.Pop3Username != "" && Agency.Pop3Pwd is object && Agency.Pop3Pwd != "" && Agency.Pop3ReplyTo is object && Agency.Pop3ReplyTo != "")
                    {
                        ReplyTo = Agency.Pop3ReplyTo;
                    }

                    SMTPSettingsLoaded = true;
                }
            }
            catch (Exception)
            {
                SMTPSettingsLoaded = false;
            }
            finally
            {
                LoadSMTPSettingsRet = SMTPSettingsLoaded;
            }

            return LoadSMTPSettingsRet;
        }

        public static bool LoadSMTPSettings(ref AdvantageFramework.Core.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref AdvantageFramework.Core.Database.Entities.Agency Agency, ref string UserName, ref string Password, ref string From, ref string ReplyTo)
        {
            bool LoadSMTPSettingsRet = default;

            // objects
            bool SMTPSettingsLoaded = false;
            AdvantageFramework.Core.Database.Views.Employee FromEmployee = default;
            AdvantageFramework.Core.Security.Database.Entities.User User = default;
            bool UsingFromEmployeeEmail = false;
            bool UsingOAuth2 = false;
            //Global.System.Web.Script.Serialization.JavaScriptSerializer JavaScriptSerializer = default;
            object Token = null;
            try
            {
                if (Agency is object && DbContext is object)
                {
                    if (Agency.SmtpAuthMethod.GetValueOrDefault(0) == (int)SmtpAuthenticationMethods.OAuth2)
                    {
                        UsingOAuth2 = true;
                    }

                    User = AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode);
                    if (Agency.SmtpUseEmpLogin.GetValueOrDefault(0) == 1)
                    {
                        if (User is object)
                        {
                            FromEmployee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmpCode);
                            if (FromEmployee is object)
                            {
                                if (FromEmployee.EmpEmail != "")
                                {
                                    UsingFromEmployeeEmail = true;
                                    From = FromEmployee.EmpEmail;
                                }
                                else
                                {
                                    From = Agency.SmtpSender;
                                }

                                if (UsingOAuth2)
                                {
                                    UserName = FromEmployee.EmpEmail;
                                    Password = FromEmployee.GoogleToken;
                                }
                                else
                                {
                                    if (FromEmployee.EmailUsername != "")
                                    {
                                        UserName = FromEmployee.EmailUsername;
                                    }
                                    else
                                    {
                                        UserName = Agency.EmailUsername;
                                    }

                                    if (FromEmployee.EmailPwd != "")
                                    {
                                        Password = AdvantageFramework.Core.Security.Encryption.Decrypt(FromEmployee.EmailPwd);
                                    }
                                    else
                                    {
                                        Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                                    }
                                }

                                if (FromEmployee.EmailReplyTo != "")
                                {
                                    ReplyTo = FromEmployee.EmailReplyTo;
                                }
                                else
                                {
                                    ReplyTo = Agency.EmailReplyTo;
                                }
                            }
                            else
                            {
                                if (!UsingOAuth2)
                                {
                                    UserName = Agency.EmailUsername;
                                    Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                                }

                                From = Agency.SmtpSender;
                                ReplyTo = Agency.EmailReplyTo;
                            }
                        }
                        else
                        {
                            if (!UsingOAuth2)
                            {
                                UserName = Agency.EmailUsername;
                                Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                            }

                            From = Agency.SmtpSender;
                            ReplyTo = Agency.EmailReplyTo;
                        }
                    }
                    else
                    {
                        if (!UsingOAuth2)
                        {
                            UserName = Agency.EmailUsername;
                            Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                        }

                        From = Agency.SmtpSender;
                        ReplyTo = Agency.EmailReplyTo;
                    }

                    if (UsingOAuth2)
                    {
                        if (string.IsNullOrWhiteSpace(UserName))
                        {
                            UserName = Agency.SmtpSender;
                        }

                        if (string.IsNullOrWhiteSpace(Password))
                        {
                            using (var DataContext = new AdvantageFramework.Core.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode))
                            {
                                Password = (string)AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, AdvantageFramework.Core.Agency.Methods.Settings.SMTP_OAUTH2_TOKEN.ToString()).Value;
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(Password))
                        {
                            Token = JsonSerializer.Deserialize<object>(Password);
                        }
                    }

                    if (AdvantageFramework.Core.Email.Methods.IsValidEmailAddress(ref From) == false)
                    {
                        From = UserName + "@" + Agency.SmtpServer;
                    }

                    if (AdvantageFramework.Core.Email.Methods.IsValidEmailAddress(ref From) == false)
                    {
                        From += ".com";
                    }

                    if (AdvantageFramework.Core.Email.Methods.IsValidEmailAddress(ref From) == false)
                    {
                        From = "webvantage@gotoadvantage.com";
                    }

                    if (UsingFromEmployeeEmail)
                    {
                        From = AdvantageFramework.Core.EmployeeUtilities.Methods.LoadEmailWithEmployeeName(FromEmployee, From);
                    }

                    if (Agency.Pop3Server is object && Agency.Pop3Server != "" && Agency.Pop3Username is object && Agency.Pop3Username != "" && Agency.Pop3Pwd is object && Agency.Pop3Pwd != "" && Agency.Pop3ReplyTo is object && Agency.Pop3ReplyTo != "")
                    {
                        ReplyTo = Agency.Pop3ReplyTo;
                    }

                    SMTPSettingsLoaded = true;
                }
            }
            catch (Exception)
            {
                SMTPSettingsLoaded = false;
            }
            finally
            {
                LoadSMTPSettingsRet = SMTPSettingsLoaded;
            }

            return LoadSMTPSettingsRet;
        }

        public static bool LoadSMTPSettings(ref AdvantageFramework.Core.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref AdvantageFramework.Core.Database.Entities.Agency Agency, ref string UserName, ref string Password, ref string From, ref string ReplyTo, bool IsClientPortal, int CPID)
        {
            bool LoadSMTPSettingsRet = default;

            // objects
            bool SMTPSettingsLoaded = false;
            AdvantageFramework.Core.Security.Database.Entities.ClientContact ClientContact = default;
            try
            {
                if (Agency is object && DbContext is object)
                {
                    if (IsClientPortal == true)
                    {
                        From = Agency.SmtpSender;
                        UserName = Agency.EmailUsername;
                        Password = AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.EmailPwd);
                        ReplyTo = Agency.EmailReplyTo;
                        if (Agency.SmtpUseEmpLogin.GetValueOrDefault(0) == 1)
                        {

                            // ClientPortalUser = AdvantageFramework.Core.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, CPID)

                            ClientContact = AdvantageFramework.Core.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, CPID);
                            if (string.IsNullOrEmpty(ClientContact.EmailAddress) == false)
                            {

                                // [From] = ClientContact.EmailAddress
                                ReplyTo = ClientContact.EmailAddress;
                            }
                        }

                        SMTPSettingsLoaded = true;
                    }
                    else
                    {
                        SMTPSettingsLoaded = LoadSMTPSettings(ref DbContext, ref SecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo);
                    }
                }
            }
            catch (Exception)
            {
                SMTPSettingsLoaded = false;
            }
            finally
            {
                LoadSMTPSettingsRet = SMTPSettingsLoaded;
            }

            return LoadSMTPSettingsRet;
        }

        public static bool LoadSMTPSettings(string ConnectionString, string UserCode, ref string UserName, ref string Password, ref string From, ref string ReplyTo)
        {
            bool LoadSMTPSettingsRet = default;

            // objects
            bool SMTPSettingsLoaded = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            try
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString, UserCode))
                {
                    using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(ConnectionString, UserCode))
                    {
                        Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                        var argDbContext = DbContext;
                        var argSecurityDbContext = SecurityDbContext;
                        SMTPSettingsLoaded = LoadSMTPSettings(ref argDbContext, ref argSecurityDbContext, ref Agency, ref UserName, ref Password, ref From, ref ReplyTo);
                    }
                }
            }
            catch (Exception)
            {
                SMTPSettingsLoaded = false;
            }
            finally
            {
                LoadSMTPSettingsRet = SMTPSettingsLoaded;
            }

            return LoadSMTPSettingsRet;
        }

        public static bool TestPOP3Settings(bool ShowMessage, string MbKey, string Server, string UserName, string Password)
        {
            bool TestPOP3SettingsRet = default;


            // objects
            MailBee.Pop3Mail.Pop3 POP3Listener = default;
            bool IsValid = false;
            POP3Listener = new MailBee.Pop3Mail.Pop3();
            MailBee.Global.LicenseKey = MailBeeDotNetKey;
            if (POP3Listener.Connect(Server))
            {
                if (ShowMessage)
                {
                    //AdvantageFramework.Navigation.ShowMessageBox("Test Successful!");
                }

                IsValid = true;
            }
            else
            {
                if (ShowMessage)
                {
                    //AdvantageFramework.Navigation.ShowMessageBox("Test Failed.");
                }

                IsValid = false;
            }

            TestPOP3SettingsRet = IsValid;
            return TestPOP3SettingsRet;
        }

        public static string LoadEmployeeEmail(AdvantageFramework.Core.Database.Views.Employee Employee, bool CheckEmailFlag = false, bool GetMailBeeFormatted = false)
        {
            string LoadEmployeeEmailRet = default;

            // objects
            string EmailAddress = "";
            bool EmployeeGetsEmail = true;
            try
            {
                if (CheckEmailFlag)
                {
//                    EmployeeGetsEmail = AdvantageFramework.Core.AlertSystem.Methods.CheckEmployeeAlertNotificationForEmail(ref Employee);
                }

                if (EmployeeGetsEmail)
                {
                    if (GetMailBeeFormatted)
                    {
                        EmailAddress = Employee.ToString() + " <" + Employee.EmpEmail + ">";
                    }
                    else
                    {
                        EmailAddress = Employee.EmpEmail;
                    }
                }
            }
            catch (Exception)
            {
                EmailAddress = "";
            }
            finally
            {
                LoadEmployeeEmailRet = EmailAddress;
            }

            return LoadEmployeeEmailRet;
        }

        public static object LoadEmployeeEmail(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode, bool CheckEmailFlag = false, bool GetMailBeeFormatted = false)
        {
            object LoadEmployeeEmailRet = default;

            // objects
            AdvantageFramework.Core.Database.Views.Employee Employee = default;
            Employee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode);
            LoadEmployeeEmailRet = LoadEmployeeEmail(Employee, CheckEmailFlag, GetMailBeeFormatted);
            return LoadEmployeeEmailRet;
        }

        public static long LoadMaxEmailSize(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            long LoadMaxEmailSizeRet = default;

            // objects
            long MaxEmailSize = 0L;
            try
            {
                //MaxEmailSize = DbContext.Database.SqlQuery<long>("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, ISNULL(AGY_SETTINGS_DEF, 0)) AS bigint) FROM dbo.AGY_SETTINGS WHERE [AGY_SETTINGS_CODE] = 'MAX_EMAIL_SIZE'").Single;
                MaxEmailSize = MaxEmailSize * AdvantageFramework.Core.FileSystem.Methods.MBInBytes;
            }
            catch (Exception )
            {
                MaxEmailSize = 0L;
            }

            LoadMaxEmailSizeRet = MaxEmailSize;
            return LoadMaxEmailSizeRet;
        }

        public static void CheckEmailSize(ref MailBee.SmtpMail.Smtp SMTP, long MaxEmailSize, ref bool AttachmentAdded)
        {
            try
            {
                if (MaxEmailSize > 0L && SMTP.Message.Size > MaxEmailSize)
                {
                    SMTP.Message.Attachments.Clear();
                    AttachmentAdded = false;
                }
            }
            catch (Exception)
            {
            }
        }

        public static string LoadEmailWithName(string Name, string Email)
        {
            string LoadEmailWithNameRet = default;

            // objects
            string EmailWithName = "";
            try
            {
                EmailWithName = Name + " <" + Email + ">";
            }
            catch (Exception)
            {
                EmailWithName = "";
            }
            finally
            {
                LoadEmailWithNameRet = EmailWithName;
            }

            return LoadEmailWithNameRet;
        }

        public static void SetPriority(ref MailBee.SmtpMail.Smtp EmailMessage, MailBee.Mime.MailPriority PriorityLevel)
        {
            try
            {
                switch (PriorityLevel)
                {
                    case var @case when @case == MailBee.Mime.MailPriority.Highest:
                        {
                            EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Highest;
                            EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Highest;
                            break;
                        }

                    case var case1 when case1 == MailBee.Mime.MailPriority.High:
                        {
                            EmailMessage.Message.Priority = MailBee.Mime.MailPriority.High;
                            EmailMessage.Message.Importance = MailBee.Mime.MailPriority.High;
                            break;
                        }

                    case var case2 when case2 == MailBee.Mime.MailPriority.Normal:
                        {
                            EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Normal;
                            EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Normal;
                            break;
                        }

                    case var case3 when case3 == MailBee.Mime.MailPriority.Low:
                        {
                            EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Low;
                            EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Low;
                            break;
                        }

                    case var case4 when case4 == MailBee.Mime.MailPriority.Lowest:
                        {
                            EmailMessage.Message.Priority = MailBee.Mime.MailPriority.Lowest;
                            EmailMessage.Message.Importance = MailBee.Mime.MailPriority.Lowest;
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }

            try
            {
                EmailMessage.Message.Headers.Add("X-MSMail-Priority", EmailMessage.Message.Priority.ToString(), true);
                EmailMessage.Message.Headers.Add("Importance", EmailMessage.Message.Priority.ToString(), true);
            }
            catch (Exception)
            {
            }
        }

        public static string LoadEmailErrorMessage(AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus)
        {
            string LoadEmailErrorMessageRet = default;

            // objects
            string ErrorMessage = "";
            switch (SendingEmailStatus)
            {
                case var @case when @case == Email.Methods.SendingEmailStatus.EmailSentWithoutAttachment:
                    {
                        ErrorMessage = "Message exceeds maximum email size. Attachments were excluded but the email was still sent.";
                        break;
                    }

                case var case1 when case1 == Email.Methods.SendingEmailStatus.FailedToConnect:
                    {
                        ErrorMessage = "There was a problem connecting to the email server. Message was not sent.";
                        break;
                    }

                case var case2 when case2 == Email.Methods.SendingEmailStatus.FailedToLoadSettings:
                    {
                        ErrorMessage = "There was a problem loading email settings. Message was not sent.";
                        break;
                    }

                case var case3 when case3 == Email.Methods.SendingEmailStatus.FailedToSend:
                    {
                        ErrorMessage = "Message failed to send.";
                        break;
                    }

                case var case4 when case4 == Email.Methods.SendingEmailStatus.EmailSent:
                    {
                        ErrorMessage = "";
                        break;
                    }

                default:
                    {
                        ErrorMessage = AdvantageFramework.Core.StringUtilities.Methods.GetNameAsWords(SendingEmailStatus.ToString());
                        break;
                    }
            }

            LoadEmailErrorMessageRet = ErrorMessage;
            return LoadEmailErrorMessageRet;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
