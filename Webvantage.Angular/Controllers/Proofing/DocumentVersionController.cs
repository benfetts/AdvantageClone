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
    public class DocumentVersionController : ControllerBase
    {
        // GET: api/<DocumentVersionController>
        [HttpGet]
        public int Get(string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            return AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocumentVersion(qs, qs.DocumentID);
        }

        // GET api/<DocumentVersionController>/5
        [HttpGet("{id}")]
        public int Get(int id, [FromQuery] string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            return AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocumentVersion(qs, id);
        }

        // POST api/<DocumentVersionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DocumentVersionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentVersionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
