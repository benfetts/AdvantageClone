using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AdvantageFramework.Core.Utilities;
using Microsoft.AspNetCore.Http;

namespace AdvantageFramework.Core.Email.Classes
{
    [Serializable()]
    public partial class EmailSessionObject
    {
        public enum EmailType
        {
            SendEmail,
            SendAlertEmail
        }

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

        // Private _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
        // Private _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
        private object _CurrentIdentity = null;

        //public string ToSession()
        //{
        //    _Guid = "EML" + MiscFN.GUID_Date(true, true, true, true);
        //    HttpContext.Current.Session(_Guid) = this;
        //    return _Guid;
        //}

        //public static EmailSessionObject FromSession(string Guid)
        //{
        //    if (HttpContext.Current.Session(Guid) is object)
        //    {
        //        EmailSessionObject eso = null;
        //        eso = HttpContext.Current.Session(Guid);
        //        return eso;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public bool Send()
        //{
        //    return SendEmailOnSeparateThread();
        //    // Me.SendEmail()

        //}

        //public bool SendEmailOnSeparateThread()
        //{
        //    try
        //    {
        //        if (AlertId > 0)
        //        {

        //            // 'Webvantage.SignalR.Classes.NotificationHub.NotifyRecipients(AlertId, Me._ConnectionString, Me._UserCode)

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    var EmailThreadStart = new ThreadStart(SendEmail);
        //    var EmailThread = new Thread(EmailThreadStart);
        //    try
        //    {
        //        EmailThread.CurrentCulture = LoGlo.GetCultureInfo;
        //        EmailThread.CurrentUICulture = LoGlo.GetCultureInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    EmailThread.Start();
        //    return true;
        //}

        //private bool SendEmail()
        //{
        //    bool Sent = false;
        //    try
        //    {
        //        EmployeeCodesToSendEmailTo = MiscFN.CleanStringForSplit(EmployeeCodesToSendEmailTo, ",");
        //        ClientPortalEmailAddressessToSendTo = MiscFN.CleanStringForSplit(ClientPortalEmailAddressessToSendTo, ",");
        //        if (MiscFN.IsNTAuth == true)
        //        {
        //            Global.System.Security.Principal.WindowsImpersonationContext _ImpersonationContext;
        //            System.Security.Principal.WindowsIdentity _CurrentWindowsIdentity;
        //            _CurrentWindowsIdentity = (System.Security.Principal.WindowsIdentity)_CurrentIdentity; // System.Security.Principal.WindowsIdentity.GetCurrent()
        //            _ImpersonationContext = _CurrentWindowsIdentity.Impersonate;
        //            using (_ImpersonationContext)
        //            using (var DbContext = new AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode))
        //            {
        //                var alrt = new AdvantageFramework.Database.Entities.Alert();
        //                alrt = default;
        //                alrt = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertId);
        //                if (alrt is object)
        //                {
        //                    Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(_ConnectionString, _UserCode, alrt, Subject, EmployeeCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo, AppName, SupervisorApprovalComment, ExcludeAttachments, InsertEmailBodyAsAlertDescription, IsClientPortal, IncludeOriginator, _WebvantageURL, _ClientPortalURL, ErrorMessage, ResetAssignedToEmployeeCodeReadFlag);
        //                }
        //            }

        //            _ImpersonationContext.Undo();
        //        }
        //        else
        //        {
        //            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(_ConnectionString, _UserCode))
        //            {
        //                AdvantageFramework.Core.Security.Database.Entities.User user = default;
        //                using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(_ConnectionString, _UserCode))
        //                {
        //                    user = AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _UserCode);
        //                }

        //                var alrt = new AdvantageFramework.Core.Database.Entities.Alert();
        //                alrt = default;
        //                alrt = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertId);
        //                if (alrt is object)
        //                {
        //                    if (MiscFN.IsClientPortal & user is null)
        //                    {
        //                        Sent = AdvantageFramework.Core.AlertSystem.Methods.BuildAndSendAlertEmail(_ConnectionString, _UserCode, alrt, Subject, EmployeeCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo, AppName, SupervisorApprovalComment, ExcludeAttachments, InsertEmailBodyAsAlertDescription, IsClientPortal, IncludeOriginator, _WebvantageURL, _ClientPortalURL, ErrorMessage, ResetAssignedToEmployeeCodeReadFlag, true, "");
        //                    }
        //                    else
        //                    {
        //                        Sent = AdvantageFramework.Core.AlertSystem.Methods.BuildAndSendAlertEmail(_ConnectionString, _UserCode, alrt, Subject, EmployeeCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo, AppName, SupervisorApprovalComment, ExcludeAttachments, InsertEmailBodyAsAlertDescription, IsClientPortal, IncludeOriginator, _WebvantageURL, _ClientPortalURL, ErrorMessage, ResetAssignedToEmployeeCodeReadFlag, true, user.EmployeeCode);
        //                    }
        //                }
        //            }
        //        }

        //        if (Sent == false)
        //        {
        //            ErrorMessage = ErrorMessage;
        //        }
        //        else if (ErrorMessage.ToString().Contains("Message exceeds maximum email size"))
        //        {
        //            Sent = false;
        //        }
        //    }
        //    catch (ThreadAbortException ThreadAbortEx)
        //    {
        //        Sent = false;
        //        ErrorMessage = ThreadAbortEx.Message.ToString() + Environment.NewLine + ThreadAbortEx.InnerException.Message.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        Sent = false;
        //        ErrorMessage = ex.Message.ToString() + Environment.NewLine + ex.InnerException.Message.ToString();
        //    }
        //    finally
        //    {
        //        if (Sent == true)
        //        {
        //            ErrorMessage = "";
        //        }
        //        else
        //        {
        //            ErrorMessage = "Error sending email:  " + ErrorMessage;
        //            AdvantageFramework.Core.Security.AddWebvantageEventLog(ErrorMessage, System.Diagnostics.EventLogEntryType.Error);

        //            // Dim AsyncError As New AsyncErrorMessage()
        //            // AsyncError.SessionID = Me._UserCode
        //            // AsyncError.PhysicalApplicationPath = Me.PhysicalApplicationPath

        //            // AsyncError.Create(Me.ErrorMessage)

        //            Webvantage.SignalR.Classes.NotificationHub.MessageUser(_UserCode, ErrorMessage);
        //        }
        //    }

        //    return Sent;
        //}

        //private void Discard()
        //{
        //    if (HttpContext.Current.Session(_Guid) is object)
        //    {
        //        HttpContext.Current.Session(_Guid) = null;
        //    }
        //}

        // Sub New()
        // End Sub

        //public EmailSessionObject(string ConnectionString, string UserCode, AdvantageFramework.Core.Security.Session SecuritySession, string WebvantageURL, string ClientPortalURL)
        //{
        //    _ConnectionString = ConnectionString;
        //    _UserCode = UserCode;
        //    // Me._SecuritySession = SecuritySession
        //    _WebvantageURL = WebvantageURL;
        //    _ClientPortalURL = ClientPortalURL;
        //    ResetAssignedToEmployeeCodeReadFlag = true;

        //    // Me._CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
        //    _CurrentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
        //}
    }
}
