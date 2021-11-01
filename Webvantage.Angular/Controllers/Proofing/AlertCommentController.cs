using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webvantage.Angular.Controllers.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    public class AlertComment
    {
        public string Comment { get; set; }
        public string[] Mentions { get; set; }
        public int DocumentId { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AlertCommentController : BaseController
    {
        // GET: api/<AlertCommentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlertCommentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlertCommentController>
        [HttpPost]
        public void Post([FromQuery] string dl, [FromBody] AlertComment comment)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            AdvantageFramework.Core.Database.Entities.AlertComment _comment = AdvantageFramework.Core.BLogic.Proofing.Methods.CreateAlertComment(
                qs, comment.Comment, comment.DocumentId > 0 ? comment.DocumentId: qs.DocumentID);

            if (comment.Mentions != null && comment.Mentions.Length > 0)
            {
                _controller.AddAlertMentions(qs, qs.AlertID, comment.Mentions, _comment.CommentId);
            }

            NotifyAlertRecipients(qs, qs.AlertID, true, true, false, false, null, true, qs.DocumentID);
        }

        // PUT api/<AlertCommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlertCommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
