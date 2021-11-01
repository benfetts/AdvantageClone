using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanMarkupController : ControllerBase
    {
        // GET: api/<CanMarkupController>
        [HttpGet]
        public bool Get(string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            //we need to also make sure that we have the current version selected, we can't get here from webvantage,
            //but we could by fallowing an old link

            if (qs.ProofingStatusExternalReviewerID <= 0)
            {
                if (AdvantageFramework.Core.AlertSystem.Methods.CanMarkup(qs.ConnectionString, qs.AlertID, qs.EmployeeCode, qs.DocumentID) &&
                    AdvantageFramework.Core.BLogic.Proofing.Methods.IsCurrentVersion(qs, qs.DocumentID))
                {
                    return true;
                }
            }
            else
            {
                if (AdvantageFramework.Core.AlertSystem.Methods.CanExternalReviewerMarkup(qs.ConnectionString, qs.AlertID, qs.ProofingStatusExternalReviewerID, qs.DocumentID) &&
                    AdvantageFramework.Core.BLogic.Proofing.Methods.IsCurrentVersion(qs, qs.DocumentID))
                {
                    return true;
                }
            }

            return false;
        }

        // GET api/<CanMarkupController>/5
        [HttpGet("{id}")]
        public bool Get(int id, [FromQuery] string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            //we need to also make sure that we have the current version selected
            if (qs.ProofingStatusExternalReviewerID <= 0)
            {
                if (AdvantageFramework.Core.AlertSystem.Methods.CanMarkup(qs.ConnectionString, qs.AlertID, qs.EmployeeCode, id) &&
                AdvantageFramework.Core.BLogic.Proofing.Methods.IsCurrentVersion(qs, id))
                {
                    return true;
                }
            }
            else
            {
                if (AdvantageFramework.Core.AlertSystem.Methods.CanExternalReviewerMarkup(qs.ConnectionString, qs.AlertID, qs.ProofingStatusExternalReviewerID, id) &&
                    AdvantageFramework.Core.BLogic.Proofing.Methods.IsCurrentVersion(qs, id))
                {
                    return true;
                }
            }

            return false;
        }

        // POST api/<CanMarkupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CanMarkupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CanMarkupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
