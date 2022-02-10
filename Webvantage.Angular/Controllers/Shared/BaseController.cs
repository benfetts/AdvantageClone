using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Webvantage.Angular.Controllers.Shared
{
    [Serializable]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {

        #region Constants



        #endregion

        #region Enum



        #endregion

        #region Variables

        private AdvantageFramework.Core.Web.QueryString _CurrentQueryString;

        #endregion

        #region Properties
        protected AdvantageFramework.Core.BLogic.Controllers.AlertSystem.AlertController _controller = new AdvantageFramework.Core.BLogic.Controllers.AlertSystem.AlertController();
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        public AdvantageFramework.Core.Web.QueryString CurrentQueryString
        {
            get
            {
                if(_CurrentQueryString is null)
                {
                    string s = Request.GetDisplayUrl();
                    string t = Request.GetEncodedUrl();
                    AdvantageFramework.Core.Web.QueryString QueryString = new AdvantageFramework.Core.Web.QueryString();
                    QueryString.FromString(s);
                    _CurrentQueryString = QueryString;
                }
                return _CurrentQueryString;
            }
        }

        #endregion

        #region Methods


        protected bool NotifyAlertRecipients(AdvantageFramework.Core.Web.QueryString queryString, 
            AdvantageFramework.Core.Database.DbContext DbContext, 
            AdvantageFramework.Core.Database.Entities.Alert Alert, 
            bool IncludeOriginator, 
            bool IsNew, 
            int DocumentID,
            bool SendEmail,
            bool IsMarkupComment,
            bool OnlyAtMentions,
            string[] MentionEmployeeCodes,
            string ProofingMarkupCommenterEmployeeCode
            )
        {
            // objects
            List<string> EmployeeCodes = null;
            List<AdvantageFramework.Core.Database.Classes.AlertRecipient> AlertRecipients = null;
            AppCode.EmailSessionObject EmailSessionObject = default;
            AdvantageFramework.Core.Database.Entities.Agency agency = null;
            string Subject = null;
            string WebvantageURL = null;
            string ClientPortalURL = null;
            string ProofingURL = null;
            string err = "";
            bool HasAtMentions = false;
            var SubjectList = new List<string>();
            bool ResetAssignedToEmployeeCodeReadFlag = true;
            bool Notified = true;
            try
            {
                agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                if (agency != null)
                {
                    WebvantageURL = agency.WebvantageUrl;
                    ClientPortalURL = agency.ClientportalUrl;
                    ProofingURL = agency.ProofingURL;
                }
                if (string.IsNullOrWhiteSpace(ProofingURL) == false && DocumentID > 0)
                {
                    ProofingURL = ProofingURL + AdvantageFramework.Core.BLogic.Proofing.Methods.GetProofingURL(queryString, Alert.AlertId, DocumentID, ref err);
                } else
                {
                    ProofingURL = "";
                }

                EmployeeCodes = new List<string>();

                if (IsMarkupComment == true && HasAtMentions == true)
                {
                    SendEmail = true;

                }
                AlertRecipients = (from Entity in _controller.LoadAlertRecipients(queryString, Alert.AlertId)
                                   where Entity.IsCurrentRecipient != false
                                   select Entity).ToList();
                if (AlertRecipients is object && AlertRecipients.Count > 0)
                {
                    EmployeeCodes.AddRange(AlertRecipients.Select(r => r.EmployeeCode).ToList());
                }

                ResetAssignedToEmployeeCodeReadFlag = true;

                if (MentionEmployeeCodes != null && MentionEmployeeCodes.Length > 0)
                {
                    HasAtMentions = true;
                    //always send when there is an at mention? if yes, need to clean up OR in the below if statement
                    ////SendEmail = true; 
                }

                if (SendEmail == true || (IsMarkupComment == true && HasAtMentions == true))
                {
                    EmailSessionObject = new AppCode.EmailSessionObject(queryString, null, WebvantageURL, ClientPortalURL, ProofingURL);
                    if (IsNew)
                    {
                        SubjectList.Add("New");
                    }
                    if (Alert.IsWorkItem.GetValueOrDefault(false) == true)
                    {
                        SubjectList.Add("Assignment");
                    }
                    else
                    {
                        SubjectList.Add("Alert");
                    }
                    if (!IsNew)
                    {
                        SubjectList.Add("Updated");
                    }
                    Subject = "[" + string.Join(" ", SubjectList) + "]";
                    if (EmployeeCodes is null)
                        EmployeeCodes = new List<string>();

                    if (HasAtMentions == true)
                    {
                        for (int i = 0; i < MentionEmployeeCodes.Length; i++)
                        {
                            EmployeeCodes.Add(MentionEmployeeCodes[i]);
                        }
                    }

                    EmailSessionObject.AlertId = Alert.AlertId;
                    EmailSessionObject.Subject = Subject;
                    EmailSessionObject.EmployeeCodesToSendEmailTo = string.Join(", ", EmployeeCodes);
                    EmailSessionObject.ClientPortalEmailAddressessToSendTo = "";
                    EmailSessionObject.IsClientPortal = false;
                    EmailSessionObject.IncludeOriginator = true;
                    EmailSessionObject.IsProofingMarkupComment = IsMarkupComment;
                    EmailSessionObject.OnlyAtMentions = OnlyAtMentions;
                    EmailSessionObject.DocumentID = DocumentID;

                    if (IsMarkupComment == true)
                    {
                        EmailSessionObject.ProofingMarkupCommenterEmployeeCode = ProofingMarkupCommenterEmployeeCode;
                    }
                    //EmailSessionObject.SessionID = HttpContext.Session.SessionID.ToString();
                    //EmailSessionObject.PhysicalApplicationPath = HttpContext.Request.PhysicalApplicationPath;
                    EmailSessionObject.ResetAssignedToEmployeeCodeReadFlag = ResetAssignedToEmployeeCodeReadFlag;
                    EmailSessionObject.Send();
                }
            }
            // End If
            catch (Exception ex)
            {
                Notified = false;
            }
            if (Notified == true)
            {
                RefreshWebvantage(queryString,WebvantageURL, Alert.AlertId);
            }
            return Notified;
        }

        protected bool NotifyAlertRecipients(AdvantageFramework.Core.Web.QueryString queryString, 
            int AlertID, 
            bool Notify, 
            bool IncludeOriginator, 
            bool IsNew, 
            bool UpdateSprint, 
            int? SprintID, 
            bool OnlyCommentAdded, 
            int DocumentID,
            bool SendEmail,
            bool IsMarkupComment,
            bool OnlyAtMentions,
            string[] Mentions,
            string ProofingMarkupCommenterEmployeeCode)
        {
            bool NotifyAlertRecipientsRet = default;

            // objects
            AdvantageFramework.Core.Database.Entities.Alert Alert = default;
            bool Sent = false;
            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(queryString.ConnectionString, queryString.UserCode))
            {
                Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
                if (Alert is object)
                {
                    if (Notify == true)
                    {
                        Sent = NotifyAlertRecipients(queryString, DbContext, Alert, IncludeOriginator, 
                            IsNew, DocumentID, SendEmail, IsMarkupComment, OnlyAtMentions, Mentions, ProofingMarkupCommenterEmployeeCode);
                    }
                    if (OnlyCommentAdded == false)
                    {
                        if (SprintID is null)
                        {
                            SprintID = 0;
                        }
                    }
                    if (UpdateSprint == true)
                    {
                        PushSprintRefreshAndNotifyByAlertID(DbContext, AlertID, SprintID);
                    }
                }
            }
            NotifyAlertRecipientsRet = Sent;
            return NotifyAlertRecipientsRet;
        }

        private async void  RefreshWebvantage(AdvantageFramework.Core.Web.QueryString queryString, 
            string WebvantageURL, int AlertID)
        {

            var values = new Dictionary<string, string>
                        {
                            { "AlertID", AlertID.ToString() }
                        };

            var content = new System.Net.Http.FormUrlEncodedContent(values);
           
            AdvantageFramework.Core.Web.QueryString qs = new AdvantageFramework.Core.Web.QueryString(queryString.ConnectionString, queryString.UserCode, "");

            if(WebvantageURL[WebvantageURL.Length - 1] != '/' && WebvantageURL[WebvantageURL.Length - 1] != '\\')
            {
                WebvantageURL += '/';
            }

            qs.Page = WebvantageURL + "Desktop/Alert/RefreshProofingAssignment";
            qs.Add("AlertID", AlertID.ToString());
            qs.AlertID = AlertID;
            qs.UserCode = queryString.UserCode;

            var response = await client.PostAsync(qs.ToString(), content);

            var responseString = await response.Content.ReadAsStringAsync();

        }


        private void PushSprintRefreshAndNotifyByAlertID(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int? SprintID)
        {
            try
            {
                try
                {
                    if (SprintID is null || SprintID == 0)
                    {
                        SprintID = DbContext.SqlQueryInt(string.Format("SELECT TOP 1 SD.SPRINT_HDR_ID FROM SPRINT_DTL SD WITH(NOLOCK) INNER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID  WHERE SD.ALERT_ID = {0} AND SH.IS_ACTIVE = 1;", AlertID));
                    }
                }
                catch (Exception)
                {
                    SprintID = 0;
                }
            }

            catch (Exception)
            {
            }
        }

        #endregion

    }


}
