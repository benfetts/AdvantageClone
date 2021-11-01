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
    public class DocumentInfoController : ControllerBase
    {
        // GET: api/<DocumentInfoController>
        [HttpGet]
        public Document Get(string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            Document doc = AdvantageFramework.Core.BLogic.Proofing.Methods.getDocumentInfo(qs);

            return doc;
        }

        // GET api/<DocumentInfoController>/5
        [HttpGet("{id}")]
        public Document Get(int id, [FromQuery] string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            Document doc = AdvantageFramework.Core.BLogic.Proofing.Methods.getDocumentInfo(qs,id);

            return doc;
        }

        // POST api/<DocumentInfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DocumentInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
