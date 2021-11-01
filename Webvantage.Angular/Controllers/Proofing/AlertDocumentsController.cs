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
    public class AlertDocumentsController : ControllerBase
    {
        // GET: api/<AlertDocumentsController>
        [HttpGet]
        public IEnumerable<Document> Get(string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            IEnumerable<Document> docs = AdvantageFramework.Core.BLogic.Proofing.Methods.GetAlertDocuments(qs);

            return docs;
        }

        // GET api/<AlertDocumentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlertDocumentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlertDocumentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlertDocumentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
