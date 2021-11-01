using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentVersionController : ControllerBase
    {
        // GET: api/<CurentVersionController>
        [HttpGet]
        public bool Get(string dl)
        {
            // we can get here if someone is sent a link and then the version is updated
            //this would take us to an older version of the file
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            return AdvantageFramework.Core.BLogic.Proofing.Methods.IsCurrentVersion(qs, qs.DocumentID);
        }

        // GET api/<CurentVersionController>/5
        [HttpGet("{id}")]
        public bool Get(int id, [FromQuery] string dl)
        {
            //in this case the document has been selected at some point and it could be a version of
            //the file we started with but we don't know for sure.
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            return AdvantageFramework.Core.BLogic.Proofing.Methods.IsCurrentVersion(qs, id);
        }

        // POST api/<CurentVersionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CurentVersionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CurentVersionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
