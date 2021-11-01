using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetInfoController : ControllerBase
    {
        // GET: api/<AssetInfoController>
        [HttpGet]
        public AdvantageFramework.Core.Database.Classes.AssetInfo Get(string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            return AdvantageFramework.Core.BLogic.Proofing.Methods.GetAssetInfo(qs);

        }

        // GET api/<AssetInfoController>/5
        [HttpGet("{id}")]
        public AdvantageFramework.Core.Database.Classes.AssetInfo Get(int id, [FromQuery] string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            return AdvantageFramework.Core.BLogic.Proofing.Methods.GetAssetInfo(qs, id);
        }

        // POST api/<AssetInfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AssetInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssetInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
