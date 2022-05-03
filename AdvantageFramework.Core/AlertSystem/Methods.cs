using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using AdvantageFramework.Core.Web;
using System.Diagnostics;

namespace AdvantageFramework.Core.AlertSystem
{
    public enum PriorityLevels : short
    {
        Highest = 1,
        High = 2,
        Normal = 3,
        Low = 4,
        Lowest = 5
    }
    public static class Methods
    {
        #region "Constants"
        private const string AssignmentLink = "{0} here to view this assignment.";
        private const string AlertLink = "{0} here to view this alert.";
        private const string ReviewLink = "{0} here to view this review.";
        private const string AppVarApplication = "CSHARE";
        #endregion

        #region Properties
        static public string WebvantageWithClientPortalAssignmentLinkVerbiage
        {
            get
            {
                return string.Format(AssignmentLink, "Webvantage users click");
            }
        }

        static public string WebvantageAssignmentLinkVerbiage
        {
            get
            {
                return string.Format(AssignmentLink, "Click");
            }
        }

        static public string ClientPortalAssignmentLinkVerbiage
        {
            get
            {
                return string.Format(AssignmentLink, "Client Portal users click");
            }
        }

        static public string WebvantageWithClientPortalAlertLinkVerbiage
        {
            get
            {
                return string.Format(AlertLink, "Webvantage users click");
            }
        }

        static public string WebvantageAlertLinkVerbiage
        {
            get
            {
                return string.Format(AlertLink, "Click");
            }
        }

        static public string ClientPortalAlertLinkVerbiage
        {
            get
            {
                return string.Format(AlertLink, "Client Portal users click");
            }
        }

        static public string WebvantageWithClientPortalReviewLinkVerbiage
        {
            get
            {
                return string.Format(ReviewLink, "Webvantage users click");
            }
        }

        static public string WebvantageReviewLinkVerbiage
        {
            get
            {
                return string.Format(ReviewLink, "Click");
            }
        }

        static public string ClientPortalReviewLinkVerbiage
        {
            get
            {
                return string.Format(ReviewLink, "Client Portal users click");
            }
        }

        #endregion

        static public System.Text.RegularExpressions.MatchCollection GetUrlMatchCollection(ref string TextString, string WebvantageURL, string ClientPortalURL)
        {
            System.Text.RegularExpressions.MatchCollection Matches = null;
            if (TextHasInternalLinks(TextString, WebvantageURL, ClientPortalURL) == true)
            {
                string Pattern = @"\b([\d\w\.\/\+\-\?\:]*)((ht|f)tp(s|)\:\/\/|[\d\d\d|\d\d]\.[\d\d\d|\d\d]\.|www\.|\.tv|\.ac|\.com|\.edu|\.gov|\.int|\.mil|\.net|\.org|\.biz|\.info|\.name|\.pro|\.museum|\.co|\.ca)([\d\w\.\/\%\+\-\=\&amp;\?\:\\\&quot;\'\,\|\~\;]*)\b([=,@,+,!,%,&,*,-])*";
                try
                {
                    Matches = System.Text.RegularExpressions.Regex.Matches(TextString, Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }
                catch (Exception)
                {
                    Matches = null;
                }
            }

            return Matches;
        }

        static public bool TextHasInternalLinks(string TextString, string WebvantageURL, string ClientPortalURL)
        {
            if (TextString.Contains(WebvantageURL) || TextString.Contains(ClientPortalURL) || TextString.ToLower().Contains("newapp?dl="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static public bool CheckEmployeeAlertNotificationForEmail(ref AdvantageFramework.Core.Database.Views.Employee Employee)
        {
            bool CheckEmployeeAlertNotificationForEmailRet = default;

            // objects
            bool SendEmployeeEmail = false;
            if (Employee is object)
            {
                if (Employee.AlertEmail.GetValueOrDefault(0) == 1 || Employee.AlertEmail.GetValueOrDefault(0) == 3)
                {
                    SendEmployeeEmail = true;
                }
            }

            CheckEmployeeAlertNotificationForEmailRet = SendEmployeeEmail;
            return CheckEmployeeAlertNotificationForEmailRet;
        }
        static public bool isLatestDocument(string ConnectionString, int AlertID, int DocumentID)
        {
            if (DocumentID == GetLatestDocumentID(ConnectionString, AlertID))
            {
                return true;
            } else
            {
                return false;
            }
        }
        static public int GetLatestDocumentID(string ConnectionString, int AlertID)
        {
            using (AdvantageFramework.Core.Database.DbContext DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                return GetLatestDocumentID(DbContext, AlertID);
            }
        }
        static public int GetLatestDocumentID(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        {
            int latestDocumentID = 0;
            try
            {

                latestDocumentID = DbContext.SqlQueryInt(String.Format("EXEC [dbo].[advsp_proofing_get_latest_document_id] {0};", AlertID));

            } catch(Exception ex)
            {
                latestDocumentID = -1;
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return latestDocumentID;
        }
        static public bool CanUpdateProofingStatus(string ConnectionString, int AlertID, string EmpCode, int DocumentID)
        {
            using (AdvantageFramework.Core.Database.DbContext DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                return CanUpdateProofingStatus(DbContext, AlertID, EmpCode, DocumentID);
            }

        }
        static public bool CanUpdateProofingStatus(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmpCode, int DocumentID)
        {
            bool canUpdateProofingStatus = false;
            try
            {

                canUpdateProofingStatus = DbContext.SqlQueryBool(String.Format("EXEC [advsp_proofing_can_set_status] {0}, '{1}', {2};", AlertID, EmpCode, DocumentID));
            
            }
            catch (Exception ex)
            {
                canUpdateProofingStatus = false;
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return canUpdateProofingStatus;
        }

        static public bool CanMarkup(string ConnectionString, int AlertID, string EmpCode, int DocumentID)
        {
            using (AdvantageFramework.Core.Database.DbContext DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                return CanMarkup(DbContext, AlertID, EmpCode, DocumentID);
            }

        }
        static public bool CanMarkup(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmpCode, int DocumentID)
        {
            bool canMarkup = true;
            try
            {

                canMarkup = DbContext.SqlQueryBool(String.Format("EXEC [advsp_proofing_can_markup] {0}, '{1}', {2};", AlertID, EmpCode, DocumentID));

            }
            catch (Exception ex)
            {
                canMarkup = false;
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return canMarkup;
        }

        static public bool CanExternalReviewerUpdateProofingStatus(string ConnectionString, int AlertID, int ProofingExternalReviewerID, int DocumentID)
        {
            using (AdvantageFramework.Core.Database.DbContext DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                return CanExternalReviewerUpdateProofingStatus(DbContext, AlertID, ProofingExternalReviewerID, DocumentID);
            }
        }
        static public bool CanExternalReviewerUpdateProofingStatus(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int ProofingExternalReviewerID, int DocumentID)
        {
            bool canExternalReviewerUpdateProofingStatus = false;
            try
            {

                canExternalReviewerUpdateProofingStatus = DbContext.SqlQueryBool(String.Format("EXEC [advsp_proofing_external_reviewer_can_set_status] {0}, {1}, {2};", AlertID, ProofingExternalReviewerID, DocumentID));

            }
            catch (Exception ex)
            {
                canExternalReviewerUpdateProofingStatus = false;
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return canExternalReviewerUpdateProofingStatus;
        }

        static public bool CanMarkup(string ConnectionString, int AlertID, string EmpCode)
        {
            using (AdvantageFramework.Core.Database.DbContext DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                return CanMarkup(DbContext, AlertID, EmpCode);
            }

        }
        static public bool CanMarkup(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmpCode)
        {
            return DbContext.SqlQueryBool("EXEC [advsp_proofing_can_markup] " + AlertID + ", '" + EmpCode + "';");
        }

        static public bool CanExternalReviewerMarkup(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int ProofingExternalReviewerID, int DocumentID)
        {
            bool canExternalReviewerMarkup = false;
            try
            {

                canExternalReviewerMarkup = DbContext.SqlQueryBool(String.Format("EXEC [advsp_proofing_external_reviewer_can_markup] {0}, {1}, {2};", AlertID, ProofingExternalReviewerID, DocumentID));

            }
            catch (Exception ex)
            {
                canExternalReviewerMarkup = true;
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return canExternalReviewerMarkup;
        }

        static public bool CanExternalReviewerMarkup(string ConnectionString, int AlertID, int ProofingExternalReviewerID, int DocumentID)
        {
            using (AdvantageFramework.Core.Database.DbContext DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                return CanExternalReviewerMarkup(DbContext, AlertID, ProofingExternalReviewerID, DocumentID);
            }

        }

        //TODO: Fix ref and default value issue on ErrorMessage
        static public bool BuildAndSendAlertEmail(QueryString qs,
            AdvantageFramework.Core.Database.Entities.Alert Alert, int DocumentID, string Subject,
            string EmpCodesToSendEmailTo = "", string ClientPortalEmailAddressessToSendTo = "",
            string AppName = "", string SupervisorApprovalComment = "", bool ExcludeAttachments = false,
            bool InsertEmailBodyAsAlertDescription = false, bool IsClientPortal = false, bool IncludeOriginator = false,
            string ErrorMessage = "", bool ResetAssignedToEmpCodeReadFlag = true,
            bool IncludeAlertVendorReps = true, string EmployeeSession = "",string ProofingURL = "", 
            bool isProofingMarkupComment = false,
            bool onlyAtMentions = false)
        {
            bool Completed = false;

            try
            {
                using (AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(qs.ConnectionString, qs.UserCode))
                {
                    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString, qs.UserCode))
                    {
                        //TODO: Fix ref and default value issue on ErrorMessage
                        //TODO: Change session to query string

                        Completed = BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, Subject,
                            EmpCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo, AppName, SupervisorApprovalComment,
                            ExcludeAttachments, InsertEmailBodyAsAlertDescription, IsClientPortal, IncludeOriginator, 
                            ErrorMessage, ResetAssignedToEmpCodeReadFlag, IncludeAlertVendorReps,"", 
                            qs.EmployeeCode, qs.UserCode, DocumentID > 0 ? DocumentID : qs.DocumentID, ProofingURL, isProofingMarkupComment, onlyAtMentions);

                        //Completed = BuildAndSendAlertEmail(SecurityDbContext,
                        //    DbContext, Alert, Subject, EmpCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo,
                        //    AppName, SupervisorApprovalComment, ExcludeAttachments, InsertEmailBodyAsAlertDescription,
                        //    IsClientPortal, IncludeOriginator, WebvantageURL, ClientPortalURL, ref ErrorMessage, ResetAssignedToEmpCodeReadFlag,
                        //    IncludeAlertVendorReps, EmployeeSession);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                Completed = false;
            }

            return Completed;
        }
        //TODO: Fix ref and default value issue on ErrorMessage

        //TODO: Change session to query string
        //static public bool BuildAndSendAlertEmail(QueryString queryString,
        //    AdvantageFramework.Core.Database.Entities.Alert Alert, string Subject, string EmpCodesToSendEmailTo = "",
        //    string ClientPortalEmailAddressessToSendTo = "", string AppName = "", string SupervisorApprovalComment = "",
        //    bool ExcludeAttachments = false, bool InsertEmailBodyAsAlertDescription = false, bool IsClientPortal = false,
        //    bool IncludeOriginator = false, 
        //    string ErrorMessage = "", bool ResetAssignedToEmpCodeReadFlag = true, bool IncludeAlertVendorReps = true,string UserCode = "")
        //{
        //    bool Completed = false;

        //    try
        //    {
        //        using (AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(queryString.ConnectionString, queryString.UserCode))
        //        {
        //            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(queryString.ConnectionString, queryString.UserCode))
        //            {
        //                /*
        //                 * */
        //                //TODO: Fix This
        //                Completed = BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, Subject,
        //                    EmpCodesToSendEmailTo, ClientPortalEmailAddressessToSendTo, AppName, SupervisorApprovalComment,
        //                    ExcludeAttachments, InsertEmailBodyAsAlertDescription, IsClientPortal, IncludeOriginator, 
        //                    ErrorMessage, ResetAssignedToEmpCodeReadFlag, IncludeAlertVendorReps, queryString.EmployeeCode, queryString.EmployeeCode, UserCode);
        //            }
        //        }
        //    }
        //    catch (Exception )
        //    {
        //        Completed = false;
        //    }

        //    return Completed;
        //}
        //TODO: Fix ref and default value issue on ErrorMessage
        static public bool BuildAndSendAlertEmail(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext,
            AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert,
            string Subject, string EmpCodesToSendEmailTo, string ClientPortalEmailAddressessToSendTo, string AppName,
            string SupervisorApprovalComment, bool ExcludeAttachments, bool InsertEmailBodyAsAlertDescription,
            bool IsClientPortal, bool IncludeOriginator,
            string ErrorMessage, bool ResetAssignedToEmpCodeReadFlag, bool IncludeAlertVendorReps, string EmployeeSession,
            string FromEmpCode, string UserCode, int DocumentID = 0, string ProofingURL = "", 
            bool isProofingMarkupComment = false,
            bool onlyAtMentions = false)
        {
            bool Completed = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = null/* TODO Change to default(_) if this is not a reference type */;
            AdvantageFramework.Core.Email.Classes.HtmlEmail HTMLEmail = null/* TODO Change to default(_) if this is not a reference type */;
            // Dim AlertEmailRecipients As Generic.List(Of AdvantageFramework.Core.Database.Classes.AlertEmailRecipient) = Nothing
            bool IsAlertAssignment = false;
            bool IsWorkItem = false;
            List<AdvantageFramework.Core.Database.Views.AlertAttachmentView> AlertAttachmentViews = null/* TODO Change to default(_) if this is not a reference type */;
            List<Database.Views.AlertView> AlertDetails = null/* TODO Change to default(_) if this is not a reference type */;
            AdvantageFramework.Core.Email.Methods.SendingEmailStatus SendingEmailStatus = default /* TODO Change to default(_) if this is not a reference type */;
            bool HasLinksHeader = false;
            List<string> AttachmentFiles = null/* TODO Change to default(_) if this is not a reference type */;
            string SaveToLocation = "";
            string FileName = "";
            string FinalEmailBody = "";
            string ThumbnailFilename = "";

            string EmailToString = "";
            string EmailCcString = "";

            List<string> empsTo = new List<string>();
            List<string> empsCC = new List<string>();

            string ExceptionMessage = "";
            string ClickLinkText = "";
            bool IsSingleReviewEmailToClientPortalUser = false;
            bool IsSingleReviewEmailToInternalReviewer = false;

            //TODO: Impersonate
            //System.Security.Principal.WindowsIdentity CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //System.Security.Principal.WindowsImpersonationContext ImpersonationContext = null;
            IEnumerable<string> VendorRepCodes = null;

            string EmployeeViewLink = string.Empty;
            string ContactViewLink = string.Empty;
            AdvantageFramework.Core.Database.Entities.MediaRFPHeader MediaRFPHeader = null/* TODO Change to default(_) if this is not a reference type */;
            string VendorRepEmailBody = null;
            string NewLink = null;
            string VendorRepEmailToString = null;

            List<AdvantageFramework.Core.Database.Classes.AlertEmailRecipient> BaseAlertRecipients = null/* TODO Change to default(_) if this is not a reference type */;
            List<AdvantageFramework.Core.Database.Classes.AlertEmailRecipient> ClientPortalAlertEmailRecipients = null/* TODO Change to default(_) if this is not a reference type */;
            AdvantageFramework.Core.Database.Entities.MediaTrafficVendor MediaTrafficVendor = null/* TODO Change to default(_) if this is not a reference type */;

            bool IsProof = false;

            try
            {
                //TODO: Impersonate
                //if (AdvantageFramework.Core.Security.Impersonate.CheckNTAuthentication == true)
                //{
                //    try
                //    {
                //        CurrentWindowsIdentity = (System.Security.Principal.WindowsIdentity)System.Web.HttpContext.Current.User.Identity;
                //    }
                //    catch (Exception ex)
                //    {
                //        CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
                //    }

                //    ImpersonationContext = CurrentWindowsIdentity.Impersonate();
                //}

                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                IsAlertAssignment = IsAlertAnAlertAssignment(Alert);
                IsWorkItem = Alert.IsWorkItem.GetValueOrDefault(false);

                if (IsWorkItem == true || IsAlertAssignment == true)
                    IncludeOriginator = true;
                if (Alert.AlertLevel == "BRD" || Alert.AlertCatId == 71)
                    IncludeOriginator = false;
                if (Alert.AlertCatId == 79 || Alert.AlertTypeId == 15 || (Alert.IsCsReview is object && Alert.IsCsReview == true))
                {
                    IsProof = true;
                }

                BaseAlertRecipients = DbContext.AlertEmailRecipient.FromSqlRaw(string.Format("EXEC [dbo].[usp_Get_Alert_EmailRecipients] {0};", Alert.AlertId)).ToList();

                if (BaseAlertRecipients != null)
                {
                    if (IsWorkItem == true)
                    {
                        empsTo = (from Entity in BaseAlertRecipients
                                  where Entity.IsAssignee == true & Entity.SendEmail == true & Entity.IsClientPortal == false
                                  select Entity.EmployeeCode).ToList();

                        foreach (var emp in empsTo)
                        {
                            if (emp.Count() > 0)
                                MarkAssigneeUnread(DbContext, Alert, emp);
                        }

                        empsCC = (from Entity in BaseAlertRecipients
                                  where Entity.IsCC == true & Entity.IsClientPortal == false
                                  select Entity.EmployeeCode).ToList();

                        string[] mentions = GetAlertMentions(DbContext, Alert.AlertId, UserCode);
                        RemoveAlertMentions(DbContext, Alert.AlertId, UserCode);
                        if(isProofingMarkupComment == true || onlyAtMentions == true)
                        {
                            // Send only to self and at mentions.
                            empsTo.Clear();
                            empsCC.Clear();
                            empsTo.Add(FromEmpCode);
                            IncludeOriginator = false;
                        }
                        if (mentions != null && mentions.Length > 0)
                        {
                            foreach (string item in mentions)
                            {
                                if (empsCC.Contains(item) == false)
                                {
                                    empsCC.Add(item);
                                }
                            }
                        }

                        foreach (var emp in empsCC)
                        {
                            if (emp.Count() > 0)
                                MarkCCsUnread(DbContext, Alert.AlertId, emp);
                        }
                    }
                    else
                    {
                        UpdateAlertRecipients(DbContext, Alert.AlertId, BaseAlertRecipients, ref ErrorMessage, EmployeeSession);

                        empsTo = (from Entity in BaseAlertRecipients
                                  where Entity.SendEmail == true & Entity.IsClientPortal == false
                                  select Entity.EmployeeCode).ToList();
                    }
                }

                ClientPortalAlertEmailRecipients = (from Entity in BaseAlertRecipients
                                                    where Entity.IsClientPortal
                                                    select Entity).ToList();

                if (IsAlertAssignment || IsWorkItem)
                {
                    if (IncludeOriginator == true && empsCC.Contains(Alert.EmpCode) == false && 
                        empsTo.Contains(Alert.EmpCode) == false && 
                        isProofingMarkupComment == false)
                    {
                        empsCC.Add(Alert.EmpCode);
                    }

                    ClientPortalEmailAddressessToSendTo = "";

                    Subject = Subject.Replace("[Alert", "[Assignment");
                    Subject = Subject.Replace("Alert]", "Assignment]");

                }

                if (onlyAtMentions == true)
                {
                    EmpCodesToSendEmailTo = string.Join(",", empsCC.ToArray());
                }

                if ((empsTo == null || empsTo.Count == 0) && (empsCC == null || empsCC.Count == 0) && string.IsNullOrWhiteSpace(EmpCodesToSendEmailTo) == true && string.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) == true &&
                    !(Alert.AlertCatId == (int)AdvantageFramework.Core.Database.Entities.AlertCategories.OrderGenerated && IncludeAlertVendorReps) &&
                    !(Alert.AlertCatId == (int)AdvantageFramework.Core.Database.Entities.AlertCategories.RFPGenerated && IncludeAlertVendorReps) &&
                    !(Alert.AlertCatId == (int)AdvantageFramework.Core.Database.Entities.AlertCategories.MediaTrafficGenerated && IncludeAlertVendorReps))
                {
                    ErrorMessage = "";
                    Completed = true;
                }
                else
                {
                    HTMLEmail = new AdvantageFramework.Core.Email.Classes.HtmlEmail(false);

                    // Build email body
                    try
                    {

                        // Set link back into WV in email
                        bool HyperLinkRowSet = false;
                        bool IncludeContactLink = false;
                        try
                        {
                            if (ClientPortalAlertEmailRecipients != null && ClientPortalAlertEmailRecipients.Count > 0)
                            {
                                if (Agency.ClientportalUrl != null && string.IsNullOrWhiteSpace(Agency.ClientportalUrl) == false && IsSingleReviewEmailToInternalReviewer == false)
                                    IncludeContactLink = true;
                                if (IsSingleReviewEmailToClientPortalUser == false && ((empsTo != null && empsTo.Count > 0) || string.IsNullOrWhiteSpace(EmpCodesToSendEmailTo) == false))
                                {
                                    if (IsAlertAssignment == true || IsWorkItem == true)
                                    {
                                        ClickLinkText = WebvantageWithClientPortalAssignmentLinkVerbiage;
                                        EmployeeViewLink = HTMLEmail.AssignmentLink(Agency, Alert.AlertId, 0, ClickLinkText, Web.Methods.DeepLinkType.External);
                                        if (IncludeContactLink == true)
                                            ContactViewLink = HTMLEmail.AssignmentLink(Agency, Alert.AlertId, 0, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal);
                                    }
                                    else
                                    {
                                        ClickLinkText = WebvantageWithClientPortalAlertLinkVerbiage;
                                        EmployeeViewLink = HTMLEmail.AlertLink(Agency, Alert.AlertId, ClickLinkText, Web.Methods.DeepLinkType.External);
                                        if (IncludeContactLink == true)
                                            ContactViewLink = HTMLEmail.AlertLink(Agency, Alert.AlertId, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal);
                                    }

                                    HTMLEmail.AddCustomRow(EmployeeViewLink);
                                }
                                if (IsAlertAssignment == true || IsWorkItem == true)
                                {
                                    ClickLinkText = ClientPortalAssignmentLinkVerbiage;
                                    EmployeeViewLink = HTMLEmail.AssignmentLink(Agency, Alert.AlertId, 0, ClickLinkText, Web.Methods.DeepLinkType.External);
                                    if (IncludeContactLink == true)
                                        ContactViewLink = HTMLEmail.AssignmentLink(Agency, Alert.AlertId, 0, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal);
                                }
                                else
                                {
                                    ClickLinkText = ClientPortalAlertLinkVerbiage;
                                    if (IncludeContactLink == true)
                                        ContactViewLink = HTMLEmail.AlertLink(Agency, Alert.AlertId, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal);
                                }
                                if (IncludeContactLink == true && string.IsNullOrWhiteSpace(ContactViewLink) == false)
                                    HTMLEmail.AddCustomRow(ContactViewLink);
                            }
                            else
                            {
                                if ((empsTo == null || empsTo.Count == 0) && string.IsNullOrWhiteSpace(EmpCodesToSendEmailTo) == true)
                                {
                                    if (ClientPortalAlertEmailRecipients == null && string.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) == false)
                                    {
                                        if (Agency.ClientportalUrl != null && string.IsNullOrWhiteSpace(Agency.ClientportalUrl) == false && IsSingleReviewEmailToInternalReviewer == false)
                                            IncludeContactLink = true;
                                    }
                                }
                                if (IsAlertAssignment == true || IsWorkItem == true)
                                {
                                    ClickLinkText = WebvantageAssignmentLinkVerbiage;
                                    EmployeeViewLink = HTMLEmail.AssignmentLink(Agency, Alert.AlertId, 0, ClickLinkText, Web.Methods.DeepLinkType.External);
                                    if (IncludeContactLink == true)
                                        ContactViewLink = HTMLEmail.AssignmentLink(Agency, Alert.AlertId, 0, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal);
                                }
                                else
                                {
                                    ClickLinkText = WebvantageAlertLinkVerbiage;
                                    EmployeeViewLink = HTMLEmail.AlertLink(Agency, Alert.AlertId, ClickLinkText, Web.Methods.DeepLinkType.External, Alert.AlertCatId);
                                    if (IncludeContactLink == true)
                                        ContactViewLink = HTMLEmail.AlertLink(Agency, Alert.AlertId, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal);
                                }
                                if (IncludeContactLink == true && string.IsNullOrWhiteSpace(ContactViewLink) == false)
                                    HTMLEmail.AddCustomRow(ContactViewLink);
                                if (HyperLinkRowSet == false)
                                    HTMLEmail.AddCustomRow(EmployeeViewLink);

                            }
                        }
                        catch (Exception)
                        {
                        }

                        // Subject and description
                        try
                        {
                            HTMLEmail.AddHeaderRow(Subject);
                            HTMLEmail.AddKeyValueRow("Subject", string.IsNullOrEmpty(Alert.Subject) ? "" : Alert.Subject);

                            string EmailBody = Alert.BodyHtml;

                            UrlToHtmlLink(ref EmailBody, Agency.WebvantageUrl, Agency.ClientportalUrl);

                            if (string.IsNullOrWhiteSpace(EmailBody) == false)
                            {
                                HTMLEmail.AddKeyValueRow("Description", EmailBody);
                            }

                            HTMLEmail.AddBlankRow();
                        }
                        catch (Exception)
                        {
                        }

                        // Thumbnail?
                        try
                        {
                            if (IsProof == true)
                            {
                                if (DocumentID > 0)
                                {
                                    HTMLEmail.AddDocumentThumbnailRow(DbContext, DocumentID, ref ThumbnailFilename);
                                }
                                else
                                {
                                    HTMLEmail.AddLatestVersionsThumbnails(DbContext, Alert.AlertId);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }

                        // Comments
                        try
                        {
                            if (IsProof == true && DocumentID > 0)
                            {
                                CommentsHistory(DbContext, false, Alert.AlertId, DocumentID, ThumbnailFilename, Agency, ref HTMLEmail);
                            }
                            else
                            {
                                CommentsHistory(DbContext, false, Alert.AlertId, Agency, ref HTMLEmail);
                            }
                            HTMLEmail.AddBlankRow();
                        }
                        catch (Exception)
                        {
                        }

                        // Details
                        try
                        {

                            if (AppName == "SupervisorApproval" && string.IsNullOrWhiteSpace(SupervisorApprovalComment) == false)
                            {
                                HTMLEmail.AddKeyValueRow("Comments", SupervisorApprovalComment);
                                HTMLEmail.AddBlankRow();
                            }
                        }

                        catch (Exception)
                        {
                        }
                        // General Info
                        try
                        {
                            HTMLEmail.AddCustomRow(GeneralInformation(DbContext, Alert));
                            HTMLEmail.AddBlankRow();
                        }
                        catch (Exception)
                        {
                        }
                        // Details Section
                        try
                        {
                            if (IsClientPortal)
                            {
                                //TODO: Need to fix the type issue we have here
                                //AlertDetails = (from Entity in AdvantageFramework.Core.Database.Procedures.ClientPortalAlertView.Load(DbContext)
                                //                where Entity.AlertId == Alert.AlertId
                                //                select Entity).ToList();
                            }
                            else
                                AlertDetails = (from Entity in AdvantageFramework.Core.Database.Procedures.AlertView.Load(DbContext)
                                                where Entity.AlertId == Alert.AlertId
                                                select Entity).ToList();

                            if (AppName != "SupervisorApproval" && AppName != "Timesheet" && AppName != "Expense" && AppName != "APVendorMediaInvoiceApproval")
                                LoadAlertDetailsInTable(DbContext, AlertDetails, HTMLEmail);

                            AttachmentFiles = new List<string>();

                            if (Convert.ToBoolean(Agency.PdfAlertOnly.GetValueOrDefault(0)) == false && ExcludeAttachments == false)
                            {
                                AlertAttachmentViews = (from Entity in AdvantageFramework.Core.Database.Procedures.AlertAttachmentView.LoadByAlertID(DbContext, Alert.AlertId)
                                                        where Entity.Emailsent == false
                                                        select Entity).ToList();

                                //TODO: Impersonate
                                //if (AdvantageFramework.Core.Security.Impersonate.CheckNTAuthentication == true)
                                //    ImpersonationContext.Undo();

                                HTMLEmail.AddKeyValueRowNoCell("Attachments", AlertAttachmentViews.Count.ToString());

                                foreach (var AlertAttachmentView in AlertAttachmentViews)
                                {
                                    if (AlertAttachmentView.MimeType == "URL")
                                    {
                                        if (HasLinksHeader == false)
                                        {
                                            HTMLEmail.AddHeaderRow("Attached Links");
                                            HasLinksHeader = true;
                                        }

                                        HTMLEmail.AddHyperlinkRow(AlertAttachmentView.RepositoryFilename, AlertAttachmentView.RealFileName);
                                    }
                                    else
                                    {
                                        bool Downloaded = false;
                                        bool foo = false;
                                        if (Agency.AspActive.GetValueOrDefault(0) == 1)
                                        {
                                            SaveToLocation = AdvantageFramework.Core.FileSystem.Methods.LoadHostedClientDownloadLocation(Agency);
                                            Downloaded = AdvantageFramework.Core.FileSystem.Methods.Download(Agency, AlertAttachmentView, SaveToLocation, ref FileName, ref foo);

                                            if (Downloaded == false)
                                            {
                                                SaveToLocation = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\");
                                                Downloaded = AdvantageFramework.Core.FileSystem.Methods.Download(Agency, AlertAttachmentView, SaveToLocation, ref FileName, ref foo);
                                            }
                                        }
                                        else if (Agency.DocRepositoryPath == "")
                                        {
                                            SaveToLocation = "";//My.Application.Info.DirectoryPath + @"\";
                                            Downloaded = AdvantageFramework.Core.FileSystem.Methods.Download(Agency, AlertAttachmentView, SaveToLocation, ref FileName, ref foo);
                                        }
                                        else
                                        {
                                            SaveToLocation = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\");
                                            Downloaded = AdvantageFramework.Core.FileSystem.Methods.Download(Agency, AlertAttachmentView, SaveToLocation, ref FileName, ref foo);
                                        }

                                        if (Downloaded)
                                        {
                                            AttachmentFiles.Add(FileName);

                                            //TODO: Impersonate
                                            //if (AdvantageFramework.Core.Security.Impersonate.CheckNTAuthentication == true)
                                            //    ImpersonationContext = CurrentWindowsIdentity.Impersonate();

                                            UpdateAlertAttachment(DbContext, AlertAttachmentView.AlertId, AlertAttachmentView.AttachmentId);

                                            //TODO: Impersonate
                                            //if (AdvantageFramework.Core.Security.Impersonate.CheckNTAuthentication == true)
                                            //    ImpersonationContext.Undo();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.Write(ex);
                        }
                        // Finalize the body
                        // Don't modify body after this!!
                        try
                        {
                            if (string.IsNullOrWhiteSpace(EmployeeViewLink) == false)
                                HTMLEmail.AddCustomRow(EmployeeViewLink);
                            if (IncludeContactLink == true && string.IsNullOrWhiteSpace(ContactViewLink) == false)
                                HTMLEmail.AddCustomRow(ContactViewLink);

                            HTMLEmail.Finish();
                            FinalEmailBody = HTMLEmail.ToString(Alert.AlertId);

                            if (InsertEmailBodyAsAlertDescription == true && IsAlertAssignment == false)
                                AdvantageFramework.Core.Database.Procedures.Alert.Update(DbContext, Alert);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    catch (Exception)
                    {
                    }

                    // Subject
                    bool JobAdded = false;
                    try
                    {
                        if (string.IsNullOrWhiteSpace(Subject) == true)
                        {
                            if (string.IsNullOrEmpty(Alert.Subject) == false)
                                Subject = Alert.Subject;
                        }
                        else
                        {
                            if (Alert.JobNumber != null)
                            {
                                if (Alert.JobNumber != null)
                                {
                                    if (Alert.Subject.Contains(Alert.JobNumber.ToString().PadLeft(6, '0')) == false)
                                    {
                                        AdvantageFramework.Core.Database.Entities.Job j = null/* TODO Change to default(_) if this is not a reference type */;
                                        j = AdvantageFramework.Core.Database.Procedures.Job.LoadByJobNumber(DbContext, (int)Alert.JobNumber);

                                        if (j != null)
                                        {
                                            Subject = Subject + " " + Alert.JobNumber.ToString().PadLeft(6, '0') + " - " + Alert.JobComponentNbr.ToString().PadLeft(3, '0') + " " + j.JobComments;
                                            JobAdded = true;
                                        }
                                    }
                                }
                            }
                            if (string.IsNullOrEmpty(Alert.Subject) == false && Subject.Contains(Alert.Subject) == false)
                            {
                                if (JobAdded == true)
                                    Subject = Subject + " | " + Alert.Subject;
                                else
                                    Subject = Subject + " " + Alert.Subject;
                            }
                        }


                        if (AppName == "SupervisorApproval" || AppName == "Expense")
                        {
                            if (Subject.StartsWith("[New Alert]") == false || Subject.StartsWith("[New Assignment]") == false)
                                Subject = "[New Alert] " + Subject;
                        }
                    }
                    catch (Exception)
                    {
                    }

                    // Set To and CC and Send email
                    try
                    {
                        if (IsAlertAssignment == false)
                        {
                            if (string.IsNullOrWhiteSpace(EmpCodesToSendEmailTo) == false)
                            {
                                try
                                {
                                    foreach (var EmpCode in EmpCodesToSendEmailTo.Split(","))
                                    {
                                        if (empsTo.Contains(EmpCode) == false && empsCC.Contains(EmpCode) == false)
                                            empsTo.Add(EmpCode);
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }

                        string EmpEmailString = "";
                        AdvantageFramework.Core.Database.Views.Employee CurrentEmployee;

                        //TODO: Impersonate
                        //if (AdvantageFramework.Core.Security.Impersonate.CheckNTAuthentication == true)
                        //    ImpersonationContext = CurrentWindowsIdentity.Impersonate();

                        foreach (var EmpCode in empsTo.Distinct())
                        {
                            CurrentEmployee = null/* TODO Change to default(_) if this is not a reference type */;
                            EmpEmailString = string.Empty;

                            CurrentEmployee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmpCode);

                            if (CurrentEmployee != null)
                            {
                                if ((CurrentEmployee.AlertEmail != null && CurrentEmployee.AlertEmail == 3) && (CurrentEmployee.EmpEmail != null && string.IsNullOrEmpty(CurrentEmployee.EmpEmail) == false) && AdvantageFramework.Core.StringUtilities.Methods.IsValidEmailAddress(CurrentEmployee.EmpEmail) == true)
                                    EmpEmailString = AdvantageFramework.Core.EmployeeUtilities.Methods.LoadEmailWithEmployeeName(CurrentEmployee);

                                if (string.IsNullOrWhiteSpace(EmpEmailString) == false)
                                {
                                    try
                                    {
                                        EmailToString += EmpEmailString + ";";
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }
                        foreach (var EmpCode in empsCC.Distinct())
                        {
                            CurrentEmployee = null/* TODO Change to default(_) if this is not a reference type */;
                            EmpEmailString = string.Empty;

                            CurrentEmployee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmpCode);

                            if (CurrentEmployee != null)
                            {
                                //if ((CurrentEmployee.AlertEmail != null && CurrentEmployee.AlertEmail == 3) && (CurrentEmployee.EmpEmail != null && string.IsNullOrEmpty(CurrentEmployee.EmpEmail) == false) && AdvantageFramework.Core.StringUtilities.Methods.IsValidEmailAddress(CurrentEmployee.EmpEmail) == true)
                                EmpEmailString = AdvantageFramework.Core.EmployeeUtilities.Methods.LoadEmailWithEmployeeName(CurrentEmployee);

                                if (string.IsNullOrWhiteSpace(EmpEmailString) == false)
                                {
                                    try
                                    {
                                        EmailCcString += EmpEmailString + ";";
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }
                        if (ClientPortalAlertEmailRecipients != null)
                        {
                            foreach (var ClientPortalAlertEmailRecipient in ClientPortalAlertEmailRecipients)
                            {
                                try
                                {
                                    if (IsAlertAssignment == false)
                                        EmailToString += ClientPortalAlertEmailRecipient.MailBeeTitle + ";";
                                    else
                                        EmailCcString += ClientPortalAlertEmailRecipient.MailBeeTitle + ";";
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }

                        if (Alert.AlertCatId == (int)AdvantageFramework.Core.Database.Entities.AlertCategories.RFPGenerated && IncludeAlertVendorReps)
                        {
                            VendorRepCodes = (from Entity in AdvantageFramework.Core.Database.Procedures.AlertComments.LoadByAlertID(DbContext, Alert.AlertId)
                                              where Entity.VrCode != null && Entity.VrCode != ""
                                              select Entity.VrCode).Distinct().ToArray();

                            if (VendorRepCodes != null && VendorRepCodes.Count() > 0)
                            {
                                MediaRFPHeader = (from Entity in AdvantageFramework.Core.Database.Procedures.MediaRFPHeader.Load(DbContext)
                                                  where Entity.AlertId == Alert.AlertId
                                                  select Entity).FirstOrDefault();

                                if (MediaRFPHeader != null)
                                {
                                    using (AdvantageFramework.Core.Database.DataContext DataContext = new AdvantageFramework.Core.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode))
                                    {
                                        foreach (var VendorRep in (from Entity in AdvantageFramework.Core.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Alert.VnCode)
                                                                   where VendorRepCodes.Contains(Entity.VrCode) && Entity.EmailAddress != null && Entity.EmailAddress != ""
                                                                   select Entity).ToList())
                                        {
                                            //TODO: Fix this crap
                                            //NewLink = "<a href=\"" + AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.WebvantageUrl, "/") + "MediaManager/RequestForProposalForm?%7C" + 
                                            //    AdvantageFramework.Core.Security.Encryption.Encrypt("Database=" + DbContext.Database.Connection.Database + "&MediaRFPHeaderID=" +
                                            //    MediaRFPHeader.ID + "&Email=" + VendorRep.EmailAddress) + "%7C\" > Click Here</a> to View the RFP";

                                            VendorRepEmailBody = ReplaceLinks(FinalEmailBody, NewLink);

                                            VendorRepEmailToString = VendorRep.ToString() + " <" + VendorRep.EmailAddress + ">" + ";";

                                            AdvantageFramework.Core.Email.Methods.Send(DbContext, SecurityDbContext, VendorRepEmailToString, Subject, VendorRepEmailBody,
                                                (int)Alert.Priority, AttachmentFiles.ToArray(), ref SendingEmailStatus, ref ExceptionMessage);
                                        }
                                    }
                                }
                            }
                        }
                        else if (Alert.AlertCatId == (int)AdvantageFramework.Core.Database.Entities.AlertCategories.OrderGenerated && IncludeAlertVendorReps)
                        {
                            VendorRepCodes = (from Entity in AdvantageFramework.Core.Database.Procedures.AlertComments.LoadByAlertID(DbContext, Alert.AlertId)
                                              where Entity.VrCode != null && Entity.VrCode != ""
                                              select Entity.VrCode).Distinct().ToArray();

                            if (VendorRepCodes != null && VendorRepCodes.Count() > 0)
                            {
                                using (AdvantageFramework.Core.Database.DataContext DataContext = new AdvantageFramework.Core.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode))
                                {
                                    foreach (var VendorRep in (from Entity in AdvantageFramework.Core.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Alert.VnCode)
                                                               where VendorRepCodes.Contains(Entity.VrCode) && Entity.EmailAddress != null && Entity.EmailAddress != ""
                                                               select Entity).ToList())
                                    {
                                        //TODO: And here
                                        //NewLink = "<a href=\"" + AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.WebvantageUrl, "/") +
                                        //    "Media/MakegoodDelivery/MakegoodOutstandingForm?%7C" + AdvantageFramework.Core.Security.Encryption.Encrypt("Database=" + 
                                        //    DbContext.Database.Connection.Database + "&VendorCode=" + Alert.VnCode + "&VendorRepCode=" + VendorRep.VrCode) +
                                        //    "%7C\" > Click Here</a> to review open orders and take various actions.";

                                        VendorRepEmailBody = ReplaceLinks(FinalEmailBody, NewLink);

                                        VendorRepEmailToString = VendorRep.ToString() + " <" + VendorRep.EmailAddress + ">" + ";";

                                        AdvantageFramework.Core.Email.Methods.Send(DbContext, SecurityDbContext, VendorRepEmailToString, Subject, VendorRepEmailBody,
                                            (int)Alert.Priority, AttachmentFiles.ToArray(), ref SendingEmailStatus, ref ExceptionMessage);
                                    }
                                }
                            }
                        }
                        else if (Alert.AlertCatId == (int)AdvantageFramework.Core.Database.Entities.AlertCategories.MediaTrafficGenerated && IncludeAlertVendorReps)
                        {
                            MediaTrafficVendor = (from Entity in AdvantageFramework.Core.Database.Procedures.MediaTrafficVendor.Load(DbContext)
                                                  where Entity.AlertId == Alert.AlertId
                                                  select Entity).FirstOrDefault();

                            if (MediaTrafficVendor != null)
                            {
                                VendorRepCodes = (from Entity in AdvantageFramework.Core.Database.Procedures.AlertComments.LoadByAlertID(DbContext, Alert.AlertId)
                                                  where Entity.VrCode != null && Entity.VrCode != ""
                                                  select Entity.VrCode).Distinct().ToArray();

                                if (VendorRepCodes != null && VendorRepCodes.Count() > 0)
                                {
                                    using (AdvantageFramework.Core.Database.DataContext DataContext = new AdvantageFramework.Core.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode))
                                    {
                                        foreach (var VendorRep in (from Entity in AdvantageFramework.Core.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Alert.VnCode)
                                                                   where VendorRepCodes.Contains(Entity.VrCode) && Entity.EmailAddress != null && Entity.EmailAddress != ""
                                                                   select Entity).ToList())
                                        {
                                            //TODO: And here
                                            //NewLink = "<a href=\"" + AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.WebvantageUrl, "/") +
                                            //    "Media/MediaTraffic/TrafficInstructionForm?%7C" + AdvantageFramework.Core.Security.Encryption.Encrypt("Database=" +
                                            //    DbContext.Database.Connection.Database + "&MediaTrafficID=" + MediaTrafficVendor.MediaTrafficRevision.MediaTrafficID +
                                            //    "&VendorCode=" + MediaTrafficVendor.VendorCode + "&RevisionNumber=" + MediaTrafficVendor.MediaTrafficRevision.RevisionNumber +
                                            //    "&Email=" + VendorRep.EmailAddress) + "%7C\" > Click Here</a> to View the Traffic Instruction";

                                            VendorRepEmailBody = ReplaceLinks(FinalEmailBody, NewLink);

                                            VendorRepEmailToString = VendorRep.ToString() + " <" + VendorRep.EmailAddress + ">" + ";";

                                            AdvantageFramework.Core.Email.Methods.Send(DbContext, SecurityDbContext, VendorRepEmailToString, Subject, VendorRepEmailBody,
                                                (int)Alert.Priority, AttachmentFiles.ToArray(), ref SendingEmailStatus, ref ExceptionMessage);
                                        }
                                    }
                                }
                            }
                        }

                        EmailToString = StringUtilities.Methods.CleanStringForSplit(ref EmailToString, ";", false);
                        EmailCcString = AdvantageFramework.Core.StringUtilities.Methods.CleanStringForSplit(ref EmailCcString, ";", false);
                        EmailToString = AdvantageFramework.Core.StringUtilities.Methods.CleanStringForSplit(ref EmailToString, ",", false);
                        EmailCcString = AdvantageFramework.Core.StringUtilities.Methods.CleanStringForSplit(ref EmailCcString, ",", false);

                        if (string.IsNullOrWhiteSpace(EmailToString) == true && string.IsNullOrWhiteSpace(EmailCcString) == true)
                            Completed = true;
                        else
                        {

                            // Just in case
                            Subject = Subject.Replace("[New Alert] [New Alert]", "[New Alert]");
                            Subject = Subject.Replace("[New Assignment] [New Assignment]", "[New Alert]");

                            Completed = AdvantageFramework.Core.Email.Methods.Send(DbContext, SecurityDbContext, EmailToString, Subject, FinalEmailBody,
                                (int)Alert.Priority, AttachmentFiles.ToArray(), ref SendingEmailStatus, ref ExceptionMessage, EmailCcString, string.Empty, FromEmpCode);
                        }

                        //TODO: Impersonate
                        //if (AdvantageFramework.Core.Security.Impersonate.CheckNTAuthentication == true)
                        //    ImpersonationContext.Undo();

                        ErrorMessage = AdvantageFramework.Core.Email.Methods.LoadEmailErrorMessage(SendingEmailStatus);

                        if (SendingEmailStatus != Email.Methods.SendingEmailStatus.EmailSent && ExceptionMessage != "")
                            ErrorMessage += Environment.NewLine + ExceptionMessage;
                    }
                    catch (Exception)
                    {
                    }

                    // Clean up attachments
                    try
                    {
                        if (AttachmentFiles != null)
                        {
                            foreach (var AttachmentFile in AttachmentFiles)
                            {
                                if (AdvantageFramework.Core.FileSystem.Methods.Delete(Agency, AttachmentFile) == false)
                                {
                                    if (System.IO.File.Exists(AttachmentFile))
                                        System.IO.File.Delete(AttachmentFile);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                Completed = false;
            }

            return Completed;
        }

        static private string ReplaceLinks(string HTMLEmail, string ReplacementLink)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLEmail, "<a href=\"(.*?)\".*?>(.*?)</a>", ReplacementLink);
        }

        static public bool IsAlertAnAlertAssignment(AdvantageFramework.Core.Database.Entities.Alert Alert)
        {
            // objects
            bool IsAnAlertAssignment = false;
            if (Alert is object)
            {
                if (Alert.AlertStateId is object && Alert.AlrtNotifyHdrId is object && Alert.AlertStateId > 0 && Alert.AlrtNotifyHdrId > 0)
                {
                    IsAnAlertAssignment = true;
                }
            }

            return IsAnAlertAssignment;
        }

        static public bool MarkAssigneeUnread(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert, string AssignedEmployeeCode)
        {
            bool Updated = true;
            try
            {
                DbContext.Database.ExecuteSqlRaw(string.Format("UPDATE [dbo].[ALERT_RCPT] WITH(ROWLOCK) SET READ_ALERT = NULL WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND CURRENT_NOTIFY = 1;", Alert.AlertId, AssignedEmployeeCode));
                if (Alert.AlertCatId == 71 || Alert.AlertLevel == "BRD" || Alert.AlertLevel == "PST")
                {
                    DbContext.Database.ExecuteSqlRaw(string.Format("UPDATE [dbo].[JOB_TRAFFIC_DET_EMPS] WITH(ROWLOCK) SET READ_ALERT = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND EMP_CODE = '{3}';", Alert.JobNumber, Alert.JobComponentNbr, Alert.TaskSeqNbr, AssignedEmployeeCode));
                }
            }
            catch (Exception)
            {
                Updated = false;
            }
            finally
            {
            }

            return Updated;
        }

        static public bool MarkCCsUnread(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string AssignedEmployeeCode)
        {

            // objects
            bool Updated = true;
            try
            {
                DbContext.Database.ExecuteSqlRaw(string.Format("UPDATE [dbo].[ALERT_RCPT] WITH(ROWLOCK) SET READ_ALERT = NULL WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND (CURRENT_RCPT = 0 OR CURRENT_RCPT IS NULL)", AlertID, AssignedEmployeeCode));
            }
            catch (Exception)
            {
                Updated = false;
            }

            return Updated;
        }

        static public bool UpdateAlertRecipients(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, List<AdvantageFramework.Core.Database.Classes.AlertEmailRecipient> AlertRecipients, ref string ErrorMessage, string EmployeeSession = "")
        {
            bool Success = true;
            string EmployeeCodes = string.Empty;
            if (AlertRecipients is object)
            {
                EmployeeCodes = string.Join(",", (from Entity in AlertRecipients
                                                  select "'" + Entity.EmployeeCode + "'"));
                Success = UpdateAlertRecipients(DbContext, AlertID, EmployeeCodes, "", true, EmployeeSession, ref ErrorMessage);
            }

            return Success;
        }

        static public bool UpdateAlertRecipients(AdvantageFramework.Core.Database.DbContext DbContext, int AlertId, string EmpCodeListChecked, string EmpCodeListUnChecked, bool MarkAsNew, string LeaveEmployeeCodeReadFlag, ref string ErrorMessage)
        {
            bool Success = true;
            try
            {
                var arP = new SqlParameter[6];
                var pAlertId = new SqlParameter("@ALERT_ID", SqlDbType.Int);
                pAlertId.Value = AlertId;
                arP[0] = pAlertId;
                var pEmpCodeListChecked = new SqlParameter("@EMP_LIST_CHECKED", SqlDbType.VarChar);
                pEmpCodeListChecked.Value = EmpCodeListChecked;
                arP[1] = pEmpCodeListChecked;
                var pEmpCodeListUnChecked = new SqlParameter("@EMP_LIST_UNCHECKED", SqlDbType.VarChar);
                pEmpCodeListUnChecked.Value = EmpCodeListUnChecked;
                arP[2] = pEmpCodeListUnChecked;
                var pMarkAsNew = new SqlParameter("@SET_AS_NEW", SqlDbType.Bit);
                pMarkAsNew.Value = MarkAsNew;
                arP[3] = pMarkAsNew;
                var pLeaveEmployeeCode = new SqlParameter("@LEAVE_READ_EMP_CODE", SqlDbType.VarChar);
                pLeaveEmployeeCode.Value = LeaveEmployeeCodeReadFlag;
                arP[4] = pLeaveEmployeeCode;
                DbContext.Database.ExecuteSqlRaw(string.Format("[dbo].[usp_wv_ALERT_UPDATE_RECIPIENTS] @ALERT_ID, @EMP_LIST_CHECKED, @EMP_LIST_UNCHECKED, @SET_AS_NEW, @LEAVE_READ_EMP_CODE"), pAlertId, pEmpCodeListChecked, pEmpCodeListUnChecked, pMarkAsNew, pLeaveEmployeeCode);
            }
            catch (Exception ex)
            {
                ErrorMessage = AdvantageFramework.Core.StringUtilities.Methods.FullErrorToString(ex);
            }

            return Success;
        }

        static public void CommentsHistory(AdvantageFramework.Core.Database.DbContext DbContext, bool IsProof, int AlertID, int DocumentID, string DocumentFilename, AdvantageFramework.Core.Database.Entities.Agency Agency, ref AdvantageFramework.Core.Email.Classes.HtmlEmail HTMLEmail)
        {
            _CommentsHistory(DbContext, IsProof, AlertID, DocumentID, DocumentFilename, Agency,ref HTMLEmail);
        }

        static public void CommentsHistory(AdvantageFramework.Core.Database.DbContext DbContext, bool IsProof, int AlertID, AdvantageFramework.Core.Database.Entities.Agency Agency, ref AdvantageFramework.Core.Email.Classes.HtmlEmail HTMLEmail)
        {
            _CommentsHistory(DbContext, IsProof, AlertID, default, "", Agency,ref HTMLEmail);
        }

        static public void _CommentsHistory(AdvantageFramework.Core.Database.DbContext DbContext,
            bool IsConceptShareReview,
            int AlertID,
            int DocumentID,
            string DocumentFilename,
            AdvantageFramework.Core.Database.Entities.Agency Agency,
            ref AdvantageFramework.Core.Email.Classes.HtmlEmail HTMLEmail)
        {

            // objects
            List<AdvantageFramework.Core.Email.Classes.AlertComment> AllComments = null;
            List<AdvantageFramework.Core.Email.Classes.AlertComment> AlertComments = null;
            // '''Dim Comment As String = Nothing

            try
            {
                decimal Offset = 0.0m;
                if (IsConceptShareReview == false)
                {
                    //TODO: Fix Time zone issue
                    //Offset = AdvantageFramework.Core.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, string.Empty);
                }
                else
                {
                    //TODO: Fix Time zone issue
                    //Offset = AdvantageFramework.Core.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployeeForceUtcZero(DbContext, string.Empty);
                }

                AllComments = (from comment in DbContext.Comments.FromSqlRaw(string.Format("EXEC [dbo].[advsp_alert_load_comments] {0}, {1}, '{2}', 0, 1;", AlertID, DocumentID, "")).AsEnumerable()
                      //where comment.ParentID == 0
                      select new AdvantageFramework.Core.Email.Classes.AlertComment()
                      {
                          AlertID = comment.AlertID,
                          CommentID = comment.CommentID ?? 0,
                          AlertStateID = comment.AlertStateID,
                          Comment = comment.LongComment,
                          //MarkupId = comment.MarkupID,
                          EmployeeFullName = comment.EmployeeFullName,
                          CustodyEndDate = comment.CustodyEndDate,
                          CustodyStartDate = comment.CustodyStartDate,
                          GeneratedDate = comment.GeneratedDate,
                          ParentID = comment.ParentID,
                          UserCode = comment.UserCode,
                          RowID = comment.RowID,
                          UserName = comment.UserName,
                          EmployeeCode = comment.EmployeeCode,
                          EmployeeNickname = comment.EmployeeNickname,
                          AssignedEmployeeCode = comment.AssignedEmployeeCode,
                          AssignedEmployeeFullName = comment.AssignedFullName,
                          AlertTemplateID = comment.AlertTemplateID,
                          AlertTemplateName = comment.AlertTemplateName,
                          AlertStateName = comment.AlertStateName,
                          AssignmentChanged = (bool)comment.AssignmentChanged,
                          IsUnassigned = (bool)comment.IsUnassigned,
                          ReplyLevel = (int)comment.ReplyLevel,
                          IsMyComment = comment.IsMyComment
                      }).ToList();


                if (AllComments is object && AllComments.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(DocumentFilename))
                    {
                        HTMLEmail.AddHeaderRow("Comments");
                    }
                    else
                    {
                        HTMLEmail.AddHeaderRow("Comments for:  " +DocumentFilename);
                    }


                    AlertComments = (from Entity in AllComments
                                     where Entity.ParentID == 0
                                     select Entity).OrderByDescending(x => x.GeneratedDate).OrderByDescending(x => x.CommentID).ToList();
                    if (AlertComments is object)
                    {
                        foreach (AdvantageFramework.Core.Email.Classes.AlertComment Comment in AlertComments)
                        {
                            GetReplies(Comment, AllComments, ref HTMLEmail, Agency);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }

        static private List<AdvantageFramework.Core.Email.Classes.AlertComment> GetReplies(AdvantageFramework.Core.Email.Classes.AlertComment Parent, List<AdvantageFramework.Core.Email.Classes.AlertComment> AllComments, ref AdvantageFramework.Core.Email.Classes.HtmlEmail HTMLEmail, AdvantageFramework.Core.Database.Entities.Agency Agency)
        {
            int CommentID = Parent.CommentID;
            List<AdvantageFramework.Core.Email.Classes.AlertComment> Children = null;
            string CommentString = string.Empty;

            // CommentString &= "<br />"

            UrlToHtmlLink(ref CommentString, Agency.WebvantageUrl, Agency.ClientportalUrl);
            CommentString += HTMLEmail.AddComment(Agency.WebvantageUrl, Agency.ClientportalUrl, Parent.EmployeeFullName, Parent.UserCode, Parent.GeneratedDate, Parent.CustodyEndDate, Parent.Comment);
            HTMLEmail.AddCustomRowLeftPad(CommentString, Parent.ReplyLevel);

            Children = (from Entity in AllComments
                        where Entity.ParentID == CommentID
                        select Entity).OrderBy(x => x.GeneratedDate).ThenBy(x => x.CommentID).ToList();

            if (Children is object && Children.Count > 0)
            {
                foreach (AdvantageFramework.Core.Email.Classes.AlertComment Child in Children)
                {
                    Child.Replies = GetReplies(Child, AllComments, ref HTMLEmail, Agency);
                }
            }

            return Children;
        }


        static public bool UrlToHtmlLink(ref string TextString, string WebvantageURL, string ClientPortalURL)
        {
            if (string.IsNullOrWhiteSpace(TextString) == true || TextString.Contains("<img") == true || TextString.Contains("data:image") == true || TextString.Contains("Click here to navigate") == true)
            {
                return false;
            }
            else
            {
                bool HasWebvantageLink = false;
                string FixedBodyText = string.Empty;
                string URL = string.Empty;
                System.Text.RegularExpressions.MatchCollection MatchCollection = null;
                string HrefLink = string.Empty;
                try
                {
                    FixedBodyText = TextString;
                    MatchCollection = GetUrlMatchCollection(ref FixedBodyText, WebvantageURL, ClientPortalURL);
                    if (MatchCollection is object)
                    {
                        var ProcessedURLs = new List<string>();
                        foreach (var Match in MatchCollection.OfType<System.Text.RegularExpressions.Match>().Where(m => m.Success == true))
                        {
                            HrefLink = string.Empty;
                            try
                            {
                                URL = Match.Value;
                            }
                            catch (Exception )
                            {
                                URL = string.Empty;
                            }

                            if (string.IsNullOrWhiteSpace(URL) == false && ProcessedURLs.Contains(URL) == false)
                            {
                                HrefLink = string.Format("<a style=\"overflow-wrap: break-word;word-break:break-all;-ms-word-break: break-all;word-wrap: break-word;\" href=\"{0}\">{0}</a>", URL);
                                ProcessedURLs.Add(URL);
                                HasWebvantageLink = true;
                                FixedBodyText = FixedBodyText.Replace(URL, HrefLink);
                            }
                        }

                        TextString = FixedBodyText;
                    }
                }
                catch (Exception )
                {
                }

                return HasWebvantageLink;
            }
        }
        static public string GeneralInformation(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert)
        {
            string GeneralInformationRet = default;

            // objects
            string GeneralInfo = "";
            List<AdvantageFramework.Core.Database.Views.AlertView> AlertViews = null;
            AdvantageFramework.Core.Database.Views.AlertView AlertView = default;
            int AlternateAlertID = default;
            AdvantageFramework.Core.Email.Classes.HtmlEmail HtmlEmail = default;
            try
            {
                AlertViews = (from Entity in AdvantageFramework.Core.Database.Procedures.AlertView.Load(DbContext)
                              where Entity.AlertId == Alert.AlertId
                              select Entity).ToList();
                AlertView = AlertViews.FirstOrDefault();
                try
                {
                    AlternateAlertID = (int)(from Entity in AlertViews where Entity.AlertSeqNbr != null select Entity.AlertSeqNbr).FirstOrDefault();
                }
                catch (Exception )
                {
                    AlternateAlertID = 0;
                }

                if (AlternateAlertID == 0)
                {
                    AlternateAlertID = Alert.AlertId;
                }

                HtmlEmail = new AdvantageFramework.Core.Email.Classes.HtmlEmail(false);
                HtmlEmail.AddHeaderRow("General Information");
                HtmlEmail.AddKeyValueRow("ID", AlternateAlertID.ToString());
                if (Convert.ToBoolean(AlertView.CpAlert.GetValueOrDefault(0)) == true)
                {
                    HtmlEmail.AddKeyValueRow("", "Client Portal Alert");

                    // Else

                    // HtmlEmail.AddKeyValueRow("", "Webvantage Alert")

                }

                HtmlEmail.AddKeyValueRow("Generated", string.Format("{0:G}", LocalDate(DbContext, (DateTime)Alert.Generated)));
                if (Convert.ToBoolean(AlertView.CpAlert.GetValueOrDefault(0)) == true)
                {
                    //TODO: That is not the contact ID, I have no idea how or if this worked in VB
                    //HtmlEmail.AddKeyValueRow("By", AdvantageFramework.Core.Database.Procedures.ClientContact.LoadByContactID(DbContext, Alert.AlertUser).ToString);
                }
                else
                {
                    //try
                    //{
                    //    //TODO:This is also really odd
                    //    //DbContext.Database.SqlQuery<string>(string.Format("SELECT TOP 1 ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ','') + ISNULL(E.EMP_LNAME,'') FROM SEC_USER SU INNER JOIN EMPLOYEE E ON SU.EMP_CODE = E.EMP_CODE WHERE USER_CODE = '{0}';", Alert.AlertUser)).SingleOrDefault();
                    //}
                    //catch (Exception)
                    //{
                    //    HtmlEmail.AddKeyValueRow("By", Alert.AlertUser);
                    //}

                    HtmlEmail.AddKeyValueRow("By", Alert.AlertUser);
                }

                try
                {
                    if (Alert.AlertCatId != (default))
                    {
                        HtmlEmail.AddKeyValueRow("Type", AdvantageFramework.Core.Database.Procedures.AlertCategory.LoadByID(DbContext, Alert.AlertCatId).AlertDesc);
                    }
                }
                catch (Exception )
                {
                }

                try
                {
                    if (Alert.Priority is object)
                    {
                        HtmlEmail.AddKeyValueRow("Priority", Enum.GetName(typeof(AdvantageFramework.Core.AlertSystem.PriorityLevels), Alert.Priority));
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    //TODO: Right now I'm just removing boards. I don't think we need it right now.
                    //BoardInfo BoardNameBoardStatename = default;
                    //string SQL = string.Format("SELECT TOP 1 B.[NAME] AS BoardName, ALS.ALERT_STATE_NAME AS BoardStateName " + "FROM  SPRINT_DTL SD INNER JOIN SPRINT_HDR SH ON SD.SPRINT_HDR_ID = SH.ID INNER JOIN ALERT A ON SD.ALERT_ID = A.ALERT_ID INNER JOIN BOARD B ON B.ID = SH.BOARD_ID INNER JOIN ALERT_STATES ALS ON ALS.ALERT_STATE_ID = A.BOARD_STATE_ID " + "WHERE SD.ALERT_ID = {0} ORDER BY SH.IS_ACTIVE DESC, SH.IS_COMPLETE ASC;", Alert.ID);
                    //BoardNameBoardStatename = DbContext.Database.SqlQuery<BoardInfo>(SQL).SingleOrDefault;
                    //if (BoardNameBoardStatename is object)
                    //{
                    //    if (string.IsNullOrWhiteSpace(BoardNameBoardStatename.BoardName) == false)
                    //    {
                    //        HtmlEmail.AddKeyValueRow("Board", BoardNameBoardStatename.BoardName);
                    //    }

                    //    if (string.IsNullOrWhiteSpace(BoardNameBoardStatename.BoardStateName) == false)
                    //    {
                    //        HtmlEmail.AddKeyValueRow("Board State", BoardNameBoardStatename.BoardStateName);
                    //    }
                    //}
                }
                catch (Exception)
                {
                }

                try
                {
                    if (Alert.StartDate.HasValue)
                    {
                        HtmlEmail.AddKeyValueRow("Start Date", string.Format("{0:d}", Alert.StartDate));
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    if (Alert.DueDate.HasValue)
                    {
                        HtmlEmail.AddKeyValueRow("Due Date", string.Format("{0:d}", Alert.DueDate));
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    if (string.IsNullOrEmpty(Alert.TimeDue) == false)
                    {
                        HtmlEmail.AddKeyValueRow("Time Due", Alert.TimeDue);
                    }
                }
                catch (Exception )
                {
                }

                try
                {
                    if (string.IsNullOrEmpty(AlertView.Ver) == false)
                    {
                        HtmlEmail.AddKeyValueRow("Version", AlertView.Ver);
                    }
                }
                catch (Exception )
                {
                }

                try
                {
                    if (string.IsNullOrEmpty(AlertView.Build) == false)
                    {
                        HtmlEmail.AddKeyValueRow("Build", AlertView.Build);
                    }
                }
                catch (Exception )
                {
                }

                HtmlEmail.Finish();
                GeneralInfo = HtmlEmail.ToString();
            }
            catch (Exception )
            {
                GeneralInfo = "";
            }
            finally
            {
                GeneralInformationRet = GeneralInfo;
            }

            return GeneralInformationRet;
        }

        static public DateTime LocalDate(AdvantageFramework.Core.Database.DbContext DbContext, DateTime Date)
        {
            DateTime LocalDateRet = default;
            var NewDate = Date;
            try
            {
                decimal DatabaseGMT = 0.0m;
                decimal AgencyGMT = 0.0m;
                LoadGMT(DbContext, ref AgencyGMT, ref DatabaseGMT);
                if (DatabaseGMT != AgencyGMT)
                {
                    NewDate = LocalDate(DatabaseGMT, AgencyGMT, Date);
                }
            }
            catch (Exception )
            {
                NewDate = Date;
            }
            finally
            {
                LocalDateRet = NewDate;
            }

            return LocalDateRet;
        }

        static public DateTime LocalDate(decimal DatabaseGMTHours,decimal AgencyGMTHours, DateTime Date)
        {
            DateTime LocalDateRet = default;
            var NewDate = Date;
            try
            {
                if (DatabaseGMTHours != AgencyGMTHours)
                {
                    NewDate = GetOffsetDateTime(AgencyGMTHours - DatabaseGMTHours, Date);
                }
            }
            catch (Exception )
            {
                NewDate = Date;
            }
            finally
            {
                LocalDateRet = NewDate;
            }

            return LocalDateRet;
        }

        static public DateTime GetOffsetDateTime(decimal OffSet, DateTime Date)
        {
            return Date.AddMinutes(Convert.ToInt32(OffSet) * 60 + (int)(OffSet - Convert.ToInt32(OffSet)) );
            //return DateTime.DateAdd(DateInterval.Minute, (double)(Conversions.ToInteger(OffSet) * 60 + (OffSet - Conversions.ToInteger(OffSet))), Date);
        }

        static public void LoadGMT(AdvantageFramework.Core.Database.DbContext DbContext, ref decimal AgencyGMT, ref decimal DatabaseGMT)
        {
            AgencyGMT = 0.0M;
            DatabaseGMT = 0.0M;
            using (var DataContext = new AdvantageFramework.Core.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode))
            {
                //DatabaseGMT = AdvantageFramework.Core.Database.Procedures.Generic.LoadSQLHoursOffset(DataContext);
                //AgencyGMT = AdvantageFramework.Core.Database.Procedures.Generic.LoadAgencyHoursOffset(DataContext);
            }
        }

        static private void UpdateAlertAttachment(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int AlertAttachmentID)
        {
            try
            {
                DbContext.Database.ExecuteSqlRaw(string.Format("UPDATE dbo.ALERT_ATTACHMENT WITH(ROWLOCK) SET EMAILSENT = 1 WHERE ATTACHMENT_ID = {0} AND ALERT_ID = {1}", AlertAttachmentID, AlertID));
            }
            catch (Exception )
            {
            }
        }
        static private void LoadAlertDetailsInTable(AdvantageFramework.Core.Database.DbContext DbContext, IEnumerable<AdvantageFramework.Core.Database.Views.AlertView> AlertDetails, ref AdvantageFramework.Core.Email.Classes.HtmlEmail HTMLEmail)
        {
            if (HTMLEmail is object && AlertDetails is object)
            {
                if (AlertDetails is IEnumerable<AdvantageFramework.Core.Database.Views.AlertView>)
                {
                    LoadAlertDetailsInTable(DbContext, (IEnumerable<AdvantageFramework.Core.Database.Views.AlertView>)AlertDetails, HTMLEmail);
                }
                else if (AlertDetails is IEnumerable<AdvantageFramework.Core.Database.Views.ClientPortalAlertView>)
                {
                    LoadAlertDetailsInTable((IEnumerable<AdvantageFramework.Core.Database.Views.ClientPortalAlertView>)AlertDetails, HTMLEmail);
                }
            }
        }

        static private void LoadAlertDetailsInTable(IEnumerable<AdvantageFramework.Core.Database.Views.ClientPortalAlertView> ClientPortalAlertViews, AdvantageFramework.Core.Email.Classes.HtmlEmail HtmlEmail)
        {

            // objects
            AdvantageFramework.Core.Database.Views.ClientPortalAlertView ClientPortalAlertView = default;
            ClientPortalAlertView = ClientPortalAlertViews.FirstOrDefault();
            HtmlEmail.AddHeaderRow("Alert Details");
            try
            {
                if (string.IsNullOrEmpty(ClientPortalAlertView.OfficeName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Office", ClientPortalAlertView.OfficeName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(ClientPortalAlertView.ClName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Client", ClientPortalAlertView.ClName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(ClientPortalAlertView.DivName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Division", ClientPortalAlertView.DivName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(ClientPortalAlertView.PrdDescription) == false)
                {
                    HtmlEmail.AddKeyValueRow("Product", ClientPortalAlertView.PrdDescription);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(ClientPortalAlertView.CmpName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Campaign", ClientPortalAlertView.CmpName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(ClientPortalAlertView.JobDesc) == false)
                {
                    HtmlEmail.AddKeyValueRow("Job", ClientPortalAlertView.JobNumber.ToString().PadLeft(6, '0') + " - " + ClientPortalAlertView.JobDesc);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(ClientPortalAlertView.JobCompDesc) == false)
                {
                    HtmlEmail.AddKeyValueRow("Component", ClientPortalAlertView.JobComponentNbr.ToString().PadLeft(2, '0') + " - " + ClientPortalAlertView.JobCompDesc);
                }
            }
            catch (Exception )
            {
            }

            HtmlEmail.AddBlankRow();
        }

        static private void LoadAlertDetailsInTable(AdvantageFramework.Core.Database.DbContext DbContext, IEnumerable<AdvantageFramework.Core.Database.Views.AlertView> AlertViews, AdvantageFramework.Core.Email.Classes.HtmlEmail HtmlEmail)
        {

            // objects
            AdvantageFramework.Core.Database.Views.AlertView AlertView = default;
            AdvantageFramework.Core.Database.Entities.JobTrafficDet JobTrafficDet = default;
            string TaskDescription = "";
            AlertView = AlertViews.FirstOrDefault();
            HtmlEmail.AddHeaderRow("Alert Details");
            try
            {
                if (string.IsNullOrEmpty(AlertView.OfficeName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Office", AlertView.OfficeName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(AlertView.ClName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Client", AlertView.ClName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(AlertView.DivName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Division", AlertView.DivName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(AlertView.PrdDescription) == false)
                {
                    HtmlEmail.AddKeyValueRow("Product", AlertView.PrdDescription);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(AlertView.CmpName) == false)
                {
                    HtmlEmail.AddKeyValueRow("Campaign", AlertView.CmpName);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(AlertView.JobDesc) == false)
                {
                    HtmlEmail.AddKeyValueRow("Job", AlertView.JobNumber.ToString().PadLeft(6, '0') + " - " + AlertView.JobDesc);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(AlertView.JobCompDesc) == false)
                {
                    HtmlEmail.AddKeyValueRow("Component", AlertView.JobComponentNbr.ToString().PadLeft(2, '0') + " - " + AlertView.JobCompDesc);
                }
            }
            catch (Exception )
            {
            }

            try
            {
                if (string.IsNullOrEmpty(AlertView.TaskFncCode) && string.IsNullOrEmpty(AlertView.TaskFncDesc) == false)
                {
                    TaskDescription = AlertView.TaskFncDesc;
                }
                else if (string.IsNullOrEmpty(AlertView.TaskFncCode) == false && string.IsNullOrEmpty(AlertView.TaskFncDesc))
                {
                    TaskDescription = AlertView.TaskFncCode;
                }
                else if (string.IsNullOrEmpty(AlertView.TaskFncCode) == false && string.IsNullOrEmpty(AlertView.TaskFncDesc) == false)
                {
                    TaskDescription = AlertView.TaskFncCode + " - " + AlertView.TaskFncDesc;
                }
                else
                {
                    TaskDescription = "";
                }

                if (string.IsNullOrEmpty(TaskDescription) == false)
                {
                    HtmlEmail.AddKeyValueRow("Task", TaskDescription);
                }
            }
            catch (Exception )
            {
            }

            if (AlertView.AlertLevel == "PST")
            {
                try
                {
                    JobTrafficDet = AdvantageFramework.Core.Database.Procedures.JobTrafficDet.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, (int)AlertView.JobNumber, (short)AlertView.JobComponentNbr, (short)AlertView.TaskSeqNbr);
                }
                catch (Exception )
                {
                }

                if (JobTrafficDet is object)
                {
                    if (JobTrafficDet.TaskStartDate.HasValue)
                    {
                        HtmlEmail.AddKeyValueRow("Start Date", JobTrafficDet.TaskStartDate.Value.ToShortDateString());
                    }

                    if (JobTrafficDet.JobRevisedDate.HasValue)
                    {
                        HtmlEmail.AddKeyValueRow("Due Date", JobTrafficDet.JobRevisedDate.Value.ToShortDateString());
                    }
                }
            }

            HtmlEmail.AddBlankRow();
        }

        static public bool AddAlertRecipients(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCodesAndContactCodes)
        {
            bool Completed = false;
            string[] Codes;
            Codes = AdvantageFramework.Core.StringUtilities.Methods.CleanStringForSplit(ref EmployeeCodesAndContactCodes, ",").Split(",");
            if (Codes.Length > 0)
            {
                foreach (string Code in Codes)
                {
                    if (Code.Contains("(CC)") == false)
                    {
                        AddAlertRecipient(DbContext, AlertID, Code);
                    }
                    else if (int.TryParse(Code, out _) == true)
                        AddAlertClientContactRecipient(DbContext, AlertID, int.Parse(Code));
                }

                Completed = true;
            }
            else
            {
                Completed = true;
            }

            return Completed;
        }

        static public bool AddAlertRecipient(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode)
        {
            bool AddAlertRecipientRet = default;

            // objects
            bool Added = false;
            AdvantageFramework.Core.Database.Views.Employee Employee = default;
            try
            {
                Employee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode);
                if (Employee is object)
                {
                    Added = AddAlertRecipient(DbContext, AlertID, Employee);
                }
            }
            catch (Exception )
            {
                Added = false;
            }
            finally
            {
                AddAlertRecipientRet = Added;
            }

            return AddAlertRecipientRet;
        }

        static public bool AddAlertRecipient(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, AdvantageFramework.Core.Database.Views.Employee Employee)
        {
            bool AddAlertRecipientRet = default;

            // objects
            bool Added = false;
            AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient = default;
            string EmailAddress = "";
            bool AddRecipient = true;
            try
            {
                if (CheckEmployeeAlertNotificationForEmail(ref Employee))
                {
                    EmailAddress = LoadEmployeeEmailAddress(Employee);
                }
                else if (CheckEmployeeAlertNotificationForAlert(ref Employee))
                {
                    EmailAddress = "";
                }
                else
                {
                    AddRecipient = false;
                }

                if (AddRecipient)
                {
                    AlertRecipient = new AdvantageFramework.Core.Database.Entities.AlertRecipient();
                    AlertRecipient.AlertId = AlertID;
                    AlertRecipient.EmpCode = Employee.EmpCode;
                    AlertRecipient.EmailAddress = EmailAddress;
                    //AlertRecipient.DbContext = DbContext;
                    if (AdvantageFramework.Core.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient))
                    {
                        Added = true;
                    }
                }
            }
            catch (Exception )
            {
                Added = false;
            }
            finally
            {
                AddAlertRecipientRet = Added;
            }

            return AddAlertRecipientRet;
        }

        static public string LoadEmployeeEmailAddress(AdvantageFramework.Core.Database.Views.Employee Employee, bool CheckEmailFlag = false, bool GetMailBeeFormatted = false)
        {
            string LoadEmployeeEmailAddressRet = default;

            // objects
            string EmailAddress = "";
            bool LoadEmail = true;
            try
            {
                if (CheckEmailFlag)
                {
                    LoadEmail = CheckEmployeeAlertNotificationForEmail(ref Employee);
                }

                if (LoadEmail)
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
            catch (Exception )
            {
                EmailAddress = "";
            }
            finally
            {
                LoadEmployeeEmailAddressRet = EmailAddress;
            }

            return LoadEmployeeEmailAddressRet;
        }

        static public bool CheckEmployeeAlertNotificationForAlert(ref AdvantageFramework.Core.Database.Views.Employee Employee)
        {
            bool CheckEmployeeAlertNotificationForAlertRet = default;

            // objects
            bool SendEmployeeAlert = false;
            if (Employee is object)
            {
                if (Employee.AlertEmail.GetValueOrDefault(0) == 2 || Employee.AlertEmail.GetValueOrDefault(0) == 3)
                {
                    SendEmployeeAlert = true;
                }
            }

            CheckEmployeeAlertNotificationForAlertRet = SendEmployeeAlert;
            return CheckEmployeeAlertNotificationForAlertRet;
        }

        static public bool AddAlertClientContactRecipient(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int ContactID)
        {
            bool AddAlertClientContactRecipientRet = default;

            // objects
            bool Added = false;
            AdvantageFramework.Core.Database.Entities.ClientContact ClientContact = default;
            AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient = default;
            string EmailAddress = "";
            bool AddRecipient = true;
            try
            {
                ClientContact = AdvantageFramework.Core.Database.Procedures.ClientContact.LoadByContactID(DbContext, ContactID);
                if (ClientContact is object)
                {
                    if (CheckClientContactAlertNotificationForEmail(ref ClientContact))
                    {
                        EmailAddress = LoadClientContactEmailAddress(ClientContact);
                    }
                    else if (CheckClientContactAlertNotificationForAlert(ref ClientContact))
                    {
                        EmailAddress = "";
                    }
                    else
                    {
                        AddRecipient = false;
                    }

                    if (AddRecipient)
                    {
                        AlertRecipient = new AdvantageFramework.Core.Database.Entities.AlertRecipient();
                        AlertRecipient.AlertId = AlertID;
                        // AlertRecipient.cl = EmployeeCode
                        AlertRecipient.EmailAddress = EmailAddress;
                        //AlertRecipient.DbContext = DbContext;
                        if (AdvantageFramework.Core.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient))
                        {
                            Added = true;
                        }
                    }
                }
            }
            catch (Exception )
            {
                Added = false;
            }
            finally
            {
                AddAlertClientContactRecipientRet = Added;
            }

            return AddAlertClientContactRecipientRet;
        }

        static public bool CheckClientContactAlertNotificationForEmail(ref AdvantageFramework.Core.Database.Entities.ClientContact ClientContact)
        {
            bool CheckClientContactAlertNotificationForEmailRet = default;

            // objects
            bool SendClientContactEmail = false;
            if (ClientContact is object)
            {
                if ((ClientContact.InactiveFlag is null || ClientContact.InactiveFlag == 0) && ClientContact.EmailRcpt is object && ClientContact.EmailRcpt == 1)
                {
                    SendClientContactEmail = true;
                }
            }

            CheckClientContactAlertNotificationForEmailRet = SendClientContactEmail;
            return CheckClientContactAlertNotificationForEmailRet;
        }

        static private string LoadClientContactEmailAddress(AdvantageFramework.Core.Database.Entities.ClientContact ClientContact, bool CheckEmailFlag = false, bool GetMailBeeFormatted = false)
        {
            string LoadClientContactEmailAddressRet = default;

            // objects
            string EmailAddress = "";
            bool LoadEmail = true;
            try
            {
                if (CheckEmailFlag)
                {
                    LoadEmail = CheckClientContactAlertNotificationForEmail(ref ClientContact);
                }

                if (LoadEmail)
                {
                    if (GetMailBeeFormatted)
                    {
                        EmailAddress = ClientContact.ToString() + " <" + ClientContact.EmailAddress + ">";
                    }
                    else
                    {
                        EmailAddress = ClientContact.EmailAddress;
                    }
                }
            }
            catch (Exception )
            {
                EmailAddress = "";
            }
            finally
            {
                LoadClientContactEmailAddressRet = EmailAddress;
            }

            return LoadClientContactEmailAddressRet;
        }

        static public bool CheckClientContactAlertNotificationForAlert(ref AdvantageFramework.Core.Database.Entities.ClientContact ClientContact)
        {
            // objects
            bool SendClientContactAlert = false;
            if (ClientContact is object)
            {
                if ((ClientContact.InactiveFlag is null || ClientContact.InactiveFlag == 0) && ClientContact.EmailRcpt is object && ClientContact.EmailRcpt == 1)
                {
                    SendClientContactAlert = true;
                }
            }

            return SendClientContactAlert;
        }

        static public Database.Entities.AlertComment AddAlertComment(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int? CommentID, string Comment, int? ClientContactID, string DocumentList,string UserCode, int? DocumentId, int ?ProofingXReviwerId = null)
        {

            // objects
            Database.Entities.AlertComment AlertComment = new Database.Entities.AlertComment();
            AlertComment.AlertId = AlertID;
            AlertComment.Comment = Comment;
            AlertComment.UserCode = UserCode;
            AlertComment.GeneratedDate = DateTime.Now;
            AlertComment.Emailsent = false;
            AlertComment.UserCodeCp = ClientContactID;
            AlertComment.ParentId = CommentID;
            AlertComment.DocumentId = DocumentId;
            AlertComment.ProofingXReviwerId = ProofingXReviwerId;
            if (Database.Procedures.AlertComments.Insert(DbContext, AlertComment))
            {
                UndismissCCsByAlertID(DbContext, AlertID);
                if (!string.IsNullOrWhiteSpace(DocumentList))
                {
                    DbContext.Database.ExecuteSqlRaw(string.Format("UPDATE [dbo].[ALERT_COMMENT] SET DOCUMENT_LIST = '{0}' WHERE COMMENT_ID = {1} AND ALERT_ID = {2}", DocumentList, AlertComment.CommentId, AlertComment.AlertId));
                }
            }

            return AlertComment;
        }

        static public bool UndismissCCsByAlertID(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        {
            bool Undismissed = true;
            try
            {
                List<string> DismissedCCEmpCodes = DbContext.SqlQueryString(string.Format("SELECT DISTINCT ARD.EMP_CODE FROM ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) WHERE (ARD.CURRENT_NOTIFY IS NULL OR ARD.CURRENT_NOTIFY = 0) AND ARD.ALERT_ID = {0};", AlertID)).ToList();
                if (DismissedCCEmpCodes is object)
                {
                    foreach (string EmployeeCode in DismissedCCEmpCodes)
                        UnDismissAlertByAlertIDAndEmployeeCode(DbContext, ref AlertID, EmployeeCode, DbContext.UserCode);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debugger.Break();
                Undismissed = false;
            }

            return Undismissed;
        }

        static public bool UnDismissAlertByAlertIDAndEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext, ref int AlertID, string EmployeeCode, string UserCode)
        {
            bool Success = true;
            try
            {
                DbContext.Database.ExecuteSqlRaw(string.Format("EXEC [dbo].[usp_wv_ALERT_UNDISMISS] {0}, '{1}', '{2}', 0, 0, 0;", AlertID, UserCode, EmployeeCode));
            }
            catch (Exception)
            {
                Success = false;
            }

            return Success;
        }

        static public string[] GetAlertMentions(AdvantageFramework.Core.Database.DbContext DbContext, int AlertId, string UserCode)
        {
            string[] Mentions = null;
            //System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
            //System.Data.SqlClient.SqlParameter EmpCodeSqlParameter = null;
            //AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int);
            //EmpCodeSqlParameter = new System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6);
            //AlertIDSqlParameter.Value = AlertId;
            //EmpCodeSqlParameter.Value = UserCode;
            try
            {
                Mentions = DbContext.SqlQueryString("EXEC [dbo].[usp_wv_ALERT_GET_MENTIONS]" + AlertId + ", " + UserCode + ";");
            }
            catch (Exception ex)
            {
            }

            return Mentions;
        }

        static public void RemoveAlertMentions(AdvantageFramework.Core.Database.DbContext DbContext, int AlertId, string UserCode)
        {
            //System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
            //System.Data.SqlClient.SqlParameter DescriptionMentionSqlParameter = null;
            //System.Data.SqlClient.SqlParameter UserCodeSqlParameter = null;
            //AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int);
            //DescriptionMentionSqlParameter = new System.Data.SqlClient.SqlParameter("@DESCRIPTION_MENTION", SqlDbType.Int);
            //UserCodeSqlParameter = new System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6);
            //AlertIDSqlParameter.Value = AlertId;
            //DescriptionMentionSqlParameter.Value = 0;
            //UserCodeSqlParameter.Value = UserCode;
            try
            {
                DbContext.ExecuteNonQuery("EXEC [dbo].[usp_wv_ALERT_REMOVE_MENTION] " + AlertId + ", " + 0 + ", '" + UserCode + "'; ");
            }
            catch (Exception ex)
            {
            }

        }

    }
}
