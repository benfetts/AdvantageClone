using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvantageFramework.Core.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestVersionController : ControllerBase
    {
        // GET: api/<LatestVersionController>
        [HttpGet]
        public int Get(string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            if(qs.ProofingStatusExternalReviewerID > 0) { 
                return AdvantageFramework.Core.AlertSystem.Methods.GetLatestDocumentID(qs.ConnectionString, qs.AlertID);
            }

            return  qs.DocumentID;
        }

        // GET api/<LatestVersionController>/5
        [HttpGet("{id}")]
        public Document Get(int id, [FromQuery] string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            return AdvantageFramework.Core.BLogic.Proofing.Methods.GetCurrentVersion(qs, qs.AlertID, id);
        }
    }
}
