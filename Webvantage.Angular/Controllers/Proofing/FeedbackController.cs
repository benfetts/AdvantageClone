using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdvantageFramework.Core.Database.Entities;
using AdvantageFramework.Core.Web;
using Microsoft.AspNetCore.Mvc;
using Webvantage.Angular.Controllers.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseController
    {

        // GET: api/<FeedbackController>
        [HttpGet]
        public IEnumerable<AdvantageFramework.Core.Database.Classes.AlertComment> Get([FromQuery] string dl)
        {
            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                AdvantageFramework.Core.Database.Classes.AlertComment[] alertComments = AdvantageFramework.Core.BLogic.Proofing.Methods.GetAlertComents(qs);

                return alertComments;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }

        }

        // GET api/<FeedbackController>/5
        [HttpGet("{id}")]
        public IEnumerable<AdvantageFramework.Core.Database.Classes.AlertComment> Get(int id, [FromQuery] string dl)
        {
            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                IEnumerable<AdvantageFramework.Core.Database.Classes.AlertComment> alertComments = AdvantageFramework.Core.BLogic.Proofing.Methods.GetAlertComents(qs, id);

                return alertComments;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST api/<FeedbackController>
        [HttpPost]
        public ActionResult<AdvantageFramework.Core.Database.Entities.AlertComment> Post([FromQuery] string dl, [FromBody] AdvantageFramework.Core.Database.Classes.AlertComment value)
        {
            AdvantageFramework.Core.Database.Entities.AlertComment newComment = null;
            try
            {
                bool sendEmail = false;
                bool isProofingMarkupComment = false;
                bool hasAtMentions = false;
                bool onlyAtMentions = false;
                int documentID = 0;

                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                documentID = value.DocumentId == null ? qs.DocumentID : (int)value.DocumentId;

                AdvantageFramework.Core.Database.Entities.AlertComment comment = AdvantageFramework.Core.BLogic.Proofing.Methods.CreateComment(qs, new AdvantageFramework.Core.Database.Entities.AlertComment()
                {
                    AlertId = qs.AlertID,
                    DocumentId = documentID,
                    UserCode = qs.ProofingStatusExternalReviewerID <= 0 ? qs.UserCode : null,
                    GeneratedDate = DateTime.Now,
                    Comment = value.Comment,
                    ParentId = value.ParentId,
                    ProofingXReviwerId = qs.ProofingStatusExternalReviewerID <= 0 ? (int?)null : qs.ProofingStatusExternalReviewerID
                });

                if (value.Mentions != null && value.Mentions.Length > 0)
                {
                    _controller.AddAlertMentions(qs, qs.AlertID, value.Mentions, comment.CommentId);
                    sendEmail = true;
                    onlyAtMentions = true;
                }

                NotifyAlertRecipients(qs, qs.AlertID, true, true, false, false, null, true, documentID,
                    sendEmail, isProofingMarkupComment, onlyAtMentions, value.Mentions, qs.EmployeeCode);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);

                return BadRequest();
            }

            return newComment;
        }

        // PUT api/<FeedbackController>/5
        [HttpPut("{id}")]
        public ActionResult<AdvantageFramework.Core.Database.Entities.AlertComment> Put(int id, [FromQuery] string dl, [FromBody] AdvantageFramework.Core.Database.Classes.AlertComment value)
        {
            AdvantageFramework.Core.Database.Entities.AlertComment newComment;
            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                newComment = AdvantageFramework.Core.BLogic.Proofing.Methods.UpdateComment(qs, new AdvantageFramework.Core.Database.Entities.AlertComment()
                {
                    AlertId = qs.AlertID,
                    DocumentId = value.DocumentId == null ? qs.DocumentID : (int)value.DocumentId,
                    UserCode = value.UserCode,
                    GeneratedDate = DateTime.Now,
                    Comment = value.Comment,
                    ParentId = value.ParentId,
                    CommentId = value.CommentId,
                    ProofingXReviwerId = qs.ProofingStatusExternalReviewerID <= 0 ? (int?)null : qs.ProofingStatusExternalReviewerID
                });

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);

                return BadRequest();
            }

            return newComment;
        }

        // DELETE api/<FeedbackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
