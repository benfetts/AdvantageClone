using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using AdvantageFramework.Core.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Linq;
using Webvantage.Angular.Controllers.Shared;
using Webvantage.Angular.Models;
using AdvantageFramework.Core.Database.Classes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{


    public class AddMissingContentType : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Request.Headers["Content-Type"] = "application/json";
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AnnotationsController : BaseController
    {

        // GET: api/<MarkupController>
        [HttpGet]
        public ProofingMarkupDto[] Get(string dl)
        {
            if (string.IsNullOrEmpty(dl))
            {
                Debug.WriteLine("dl is null or empty");
                return null;
            }

            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                ProofingMarkupDto[] Annotations = AdvantageFramework.Core.BLogic.Proofing.Methods.GetAnnotations(qs);

                return Annotations;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        // GET api/<MarkupController>/5
        [HttpGet("{id}")]
        public ProofingMarkupDto[] Get(int id, [FromQuery] string dl)
        {
            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                ProofingMarkupDto[] Annotations = AdvantageFramework.Core.BLogic.Proofing.Methods.GetAnnotations(qs, id);

                return Annotations;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        // POST api/<MarkupController>
        [HttpPost]
        public ActionResult<AdvantageFramework.Core.Database.Entities.ProofingMarkup[]> Post([FromQuery] string dl, [FromBody] ProofingMarkupDto[] Annotations)
        {
            AdvantageFramework.Core.Database.Entities.ProofingMarkup[] newMarkups;
            try
            {
                bool sendEmail = false;
                bool isProofingMarkupComment = true;
                bool onlyAtMentions = false;
                bool hasAtMentions = false;
                int documentID = 0;

                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);
                List<AdvantageFramework.Core.Database.Entities.ProofingMarkup> entities = new List<AdvantageFramework.Core.Database.Entities.ProofingMarkup>();

                foreach (ProofingMarkupDto Annot in Annotations)
                {
                    //this is where the document id is set, so that it is either the one that is passed or the one from the qs
                    documentID = Annot.DocumentId != null ? (int)Annot.DocumentId : qs.DocumentID;
                    entities.Add(new AdvantageFramework.Core.Database.Entities.ProofingMarkup()
                    {
                        //AlertId = qs.AlertID,
                        DocumentId = documentID,
                        EmpCode = string.IsNullOrWhiteSpace(qs.EmployeeCode) ? null : qs.EmployeeCode,
                        Generated = DateTime.Now,
                        Markup = Annot.Markup,
                        MarkupTypeId = Annot.MarkupTypeId,
                        MarkupXml = Annot.MarkupXml,
                        Thumbnail = Annot.Thumbnail,
                        ProofingXReviwerId = qs.ProofingStatusExternalReviewerID <= 0 ? (int?)null : qs.ProofingStatusExternalReviewerID
                    });
                }

                newMarkups = AdvantageFramework.Core.BLogic.Proofing.Methods.CreateAnnotations(qs, entities.ToArray());

                if (Annotations[0].Mentions != null && Annotations[0].Mentions.Length > 0)
                {
                    hasAtMentions = true;
                    _controller.AddAlertMentions(qs, qs.AlertID, Annotations[0].Mentions, newMarkups[0].CommentId != null ? (int)newMarkups[0].CommentId : 0);
                    sendEmail = true;
                    onlyAtMentions = true;
                }

                NotifyAlertRecipients(qs, qs.AlertID, true, true, false, false, null, true, documentID,
                    sendEmail, isProofingMarkupComment, onlyAtMentions, Annotations[0].Mentions, qs.EmployeeCode);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);

                return BadRequest();
            }

            return newMarkups;
        }

        // PUT api/<MarkupController>/5
        [HttpPut("{id}")]
        public ActionResult<AdvantageFramework.Core.Database.Entities.ProofingMarkup> Put(int id, [FromQuery] string dl, [FromBody] ProofingMarkupDto value)
        {
            AdvantageFramework.Core.Database.Entities.ProofingMarkup newMarkup;

            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                newMarkup = AdvantageFramework.Core.BLogic.Proofing.Methods.UpdateAnnotation(qs, id, new AdvantageFramework.Core.Database.Entities.ProofingMarkup()
                {
                    CommentId = value.CommentId,
                    DocumentId = value.DocumentId != null ? (int)value.DocumentId : qs.DocumentID,
                    EmpCode = qs.EmployeeCode,
                    Generated = value.Generated,
                    Id = value.Id,
                    Markup = value.Markup,
                    MarkupTypeId = value.MarkupTypeId,
                    MarkupXml = value.MarkupXml,
                    Thumbnail = value.Thumbnail
                });

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);

                return BadRequest();
            }

            return newMarkup;
        }

        // DELETE api/<MarkupController>/5
        [AddMissingContentType]
        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            string dl = "";
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                var bodyContent = await reader.ReadToEndAsync();
                JObject details = JObject.Parse(bodyContent.ToString());
                dl = (string)details["dl"];
            }

            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                AdvantageFramework.Core.BLogic.Proofing.Methods.DeleteAnnotation(qs, id);
            }
            catch (Exception)
            {

            }

            Debug.Write("delete\n");
        }

    }
}
