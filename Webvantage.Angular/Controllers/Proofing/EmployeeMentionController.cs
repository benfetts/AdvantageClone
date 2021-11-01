using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdvantageFramework.Core.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMentionController : ControllerBase
    {
        // GET: api/<EmployeeMentionController>
        [HttpGet]
        public IEnumerable<AdvantageFramework.Core.Database.Classes.EmployeeMention> Get([FromQuery] string dl)
        {
            try
            {
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                List<AdvantageFramework.Core.Database.Classes.EmployeeMention> employeeMentions = AdvantageFramework.Core.BLogic.EmployeeMention.Methods.GetEmployeesForMention(qs);

                return employeeMentions;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }

        }

        //// POST api/<EmployeeMentionController/5>
        //[HttpPost("{alertId}")]
        //public ActionResult<AdvantageFramework.Core.Database.Entities.AlertComment> Post([FromQuery] string dl, [FromBody] AdvantageFramework.Core.Database.Classes.AlertComment value)
        //{
        //    AdvantageFramework.Core.Database.Entities.AlertComment newComment;
        //    try
        //    {
        //        AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

        //        newComment = AdvantageFramework.Core.BLogic.Proofing.Methods.CreateComment(qs, new AdvantageFramework.Core.Database.Entities.AlertComment()
        //        {
        //            AlertId = qs.AlertID,
        //            DocumentId = qs.DocumentID,
        //            UserCode = qs.UserCode,
        //            GeneratedDate = DateTime.Now,
        //            Comment = value.Comment,
        //            ParentId = value.ParentId,
        //            //MarkupTypeId = value.MarkupTypeId,
        //            //MarkupXml = value.MarkupXml,
        //            //Thumbnail = value.Thumbnail
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.Write(ex);

        //        return BadRequest();
        //    }

        //    return newComment;
        //}        

        //// DELETE api/<EmployeeMentionController>/5/0?1
        //[HttpDelete("{alertId, descMention}")]
        //public void Delete(int id)
        //{
        //}
    }
}
