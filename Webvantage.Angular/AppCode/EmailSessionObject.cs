using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdvantageFramework.Core.Utilities;
using AdvantageFramework.Core.Web;

namespace Webvantage.Angular.AppCode
{
    [Serializable()]
    public partial class EmailSessionObject
    {
        public enum EmailType
        {
            SendEmail,
            SendAlertEmail
        }

        private QueryString queryString = null;

        public int AlertId { get; set; } = 0;
        public string Subject { get; set; } = "";
        public string EmployeeCodesToSendEmailTo { get; set; } = "";
        public string ClientPortalEmailAddressessToSendTo { get; set; } = "";
        public string AppName { get; set; } = "";
        public string SupervisorApprovalComment { get; set; } = "";
        public bool ExcludeAttachments { get; set; } = false;
        public bool InsertEmailBodyAsAlertDescription { get; set; } = false;
        public bool IsClientPortal { get; set; } = false;
        public bool IncludeOriginator { get; set; } = false;
        public string ErrorMessage { get; set; } = "";
        public bool MessageExceedsMaximumEmailSize { get; set; } = false;
        public string SessionID { get; set; } = "";
        public string PhysicalApplicationPath { get; set; } = "";
        public bool ResetAssignedToEmployeeCodeReadFlag { get; set; }
        private string _Guid { get; set; } = "";
        private string _ConnectionString { get; set; } = "";
        private string _UserCode { get; set; } = "";
        private string _WebvantageURL { get; set; } = "";
        private string _ClientPortalURL { get; set; } = "";
        private string _ProofingURL { get; set; } = "";

        // Private _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
        // Private _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
        private object _CurrentIdentity = null;

        public bool Send()
        {
            return SendEmailOnSeparateThread();
            //SendEmail(); return true;

        }

        public bool SendEmailOnSeparateThread()
        {
            try
            {
                if (AlertId > 0)
                {

                    // 'Webvantage.SignalR.Classes.NotificationHub.NotifyRecipients(AlertId, Me._ConnectionString, Me._UserCode)

                }
            }
            catch (Exception ex)
            {
            }

            var EmailThreadStart = new ThreadStart(SendEmail);
            var EmailThread = new Thread(EmailThreadStart);
            try
            {
                //EmailThread.CurrentCulture = LoGlo.GetCultureInfo;
                //EmailThread.CurrentUICulture = LoGlo.GetCultureInfo;
            }
            catch (Exception ex)
            {
            }

            EmailThread.Start();
            return true;
        }

        private void SendEmail()
        {
            bool Sent = false;
            try
            {
                EmployeeCodesToSendEmailTo = MiscFN.CleanStringForSplit(EmployeeCodesToSendEmailTo, ",");
                ClientPortalEmailAddressessToSendTo = MiscFN.CleanStringForSplit(ClientPortalEmailAddressessToSendTo, ",");
                if (MiscFN.IsNTAuth() == true)
                {

                    //TODO: Fix impersination
                    //Global.System.Security.Principal.WindowsImpersonationContext _ImpersonationContext;
                    //System.Security.Principal.WindowsIdentity _CurrentWindowsIdentity;
                    //_CurrentWindowsIdentity = (System.Security.Principal.WindowsIdentity)_CurrentIdentity; // System.Security.Principal.WindowsIdentity.GetCurrent()
                    //_ImpersonationContext = _CurrentWindowsIdentity.Impersonate;
                    //using (_ImpersonationContext)
                    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(_ConnectionString, _UserCode))
                    {
                        var alrt = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertId);
                        if (alrt is object)
                        {
                            Sent = AdvantageFramework.Core.AlertSystem.Methods.BuildAndSendAlertEmail(queryString,
                                alrt, Subject, EmployeeCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo, AppName,
                                SupervisorApprovalComment, ExcludeAttachments, InsertEmailBodyAsAlertDescription,
                                IsClientPortal, IncludeOriginator, ErrorMessage,
                                ResetAssignedToEmployeeCodeReadFlag,true,"", _ProofingURL);
                        }
                    }

                    //_ImpersonationContext.Undo();
                }
                else
                {
                    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(_ConnectionString, _UserCode))
                    {
                        AdvantageFramework.Core.Security.Database.Entities.User user = default;
                        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(_ConnectionString, _UserCode))
                        {
                            user = AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _UserCode);
                        }

                        var alrt = new AdvantageFramework.Core.Database.Entities.Alert();
                        alrt = default;
                        alrt = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertId);
                        if (alrt is object)
                        {
                            if (MiscFN.IsClientPortal() & user is null)
                            {
                                Sent = AdvantageFramework.Core.AlertSystem.Methods.BuildAndSendAlertEmail(queryString,
                                    alrt, Subject, EmployeeCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo, AppName,
                                    SupervisorApprovalComment, ExcludeAttachments, InsertEmailBodyAsAlertDescription, IsClientPortal,
                                    IncludeOriginator, ErrorMessage, ResetAssignedToEmployeeCodeReadFlag, true, "", _ProofingURL);
                            }
                            else
                            {
                                Sent = AdvantageFramework.Core.AlertSystem.Methods.BuildAndSendAlertEmail(queryString,
                                    alrt, Subject, EmployeeCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo,
                                    AppName, SupervisorApprovalComment, ExcludeAttachments, InsertEmailBodyAsAlertDescription,
                                    IsClientPortal, IncludeOriginator, ErrorMessage, ResetAssignedToEmployeeCodeReadFlag, true, user.EmpCode, _ProofingURL);
                            }
                        }
                    }
                }

                if (Sent == false)
                {
                    ErrorMessage = ErrorMessage;
                }
                else if (ErrorMessage.ToString().Contains("Message exceeds maximum email size"))
                {
                    Sent = false;
                }
            }
            catch (ThreadAbortException ThreadAbortEx)
            {
                Sent = false;
                ErrorMessage = ThreadAbortEx.Message.ToString() + Environment.NewLine + ThreadAbortEx.InnerException.Message.ToString();
            }
            catch (Exception ex)
            {
                Sent = false;
                ErrorMessage = ex.Message.ToString() + Environment.NewLine + ex.InnerException.Message.ToString();
            }
            finally
            {
                if (Sent == true)
                {
                    ErrorMessage = "";
                }
                else
                {
                    ErrorMessage = "Error sending email:  " + ErrorMessage;
                    //AdvantageFramework.Core.Security.AddWebvantageEventLog(ErrorMessage, System.Diagnostics.EventLogEntryType.Error);

                    // Dim AsyncError As New AsyncErrorMessage()
                    // AsyncError.SessionID = Me._UserCode
                    // AsyncError.PhysicalApplicationPath = Me.PhysicalApplicationPath

                    // AsyncError.Create(Me.ErrorMessage)

                    //Webvantage.SignalR.Classes.NotificationHub.MessageUser(_UserCode, ErrorMessage);
                }
            }

            //return Sent;
        }

        public EmailSessionObject(QueryString queryString, AdvantageFramework.Core.Security.Session SecuritySession, string WebvantageURL, string ClientPortalURL, string ProofingURL)
        {
            _ConnectionString = queryString.ConnectionString;
            _UserCode = queryString.UserCode;

            this.queryString = queryString;

            // Me._SecuritySession = SecuritySession
            _WebvantageURL = WebvantageURL;
            _ClientPortalURL = ClientPortalURL;
            _ProofingURL = ProofingURL;
            ResetAssignedToEmployeeCodeReadFlag = true;

            // Me._CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
            _CurrentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
        }
    }
}
