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
    public class ProofingDocumentNameController : ControllerBase
    {
        // GET: api/<ProofingDocumentName>
        [HttpGet]
        public string Get(string dl)
        {
            string FileName = "";
            string ErrorMessage = "";

            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocumentName(qs,ref FileName, ref ErrorMessage);

            return FileName;
        }

        // GET api/<ProofingDocumentName>/5
        [HttpGet("{id}")]
        public string Get(int id, [FromQuery] string dl)
        {
            string FileName = "";
            string ErrorMessage = "";

            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocumentName(qs, id, ref FileName, ref ErrorMessage);

            return FileName;
        }

        // POST api/<ProofingDocumentName>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProofingDocumentName>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProofingDocumentName>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
