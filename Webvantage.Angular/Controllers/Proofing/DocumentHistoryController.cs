using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdvantageFramework.Core.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentHistoryController : ControllerBase
    {
        // GET: api/<DocumentHistoryController>
        [HttpGet]
        public IEnumerable<Document> Get(string dl)
        {
            try{
                AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

                IEnumerable<Document> docs = AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocumentHistory(qs);

                return docs;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);

                return null;
            }
        }

        // GET api/<DocumentHistoryController>/5
        [HttpGet("{id}")]
        public IEnumerable<Document> Get(int id, [FromQuery] string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            IEnumerable<Document> docs = AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocumentHistory(qs, id);

            return docs;
        }

        // POST api/<DocumentHistoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DocumentHistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentHistoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
