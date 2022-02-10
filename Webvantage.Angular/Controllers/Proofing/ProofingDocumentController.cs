using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvantageFramework.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProofingDocumentController : Shared.BaseController
    {
        // GET: api/<PoofingDocumentController>
        [HttpGet]
        public IActionResult Get([FromQuery] string dl)
        {
            byte[] file = null;
            string errorMessage = "";
            string FileName = "";
            string contentType;

            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocument(qs, ref file, ref FileName, ref errorMessage);

            if(errorMessage != "")
            {
                throw new InvalidOperationException(errorMessage);
            }

            new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider().TryGetContentType(FileName, out contentType);

            if (file != null)
            {
                System.IO.Stream stream = new System.IO.MemoryStream(file);
                return File(stream, contentType, FileName);
            }

            return NotFound();
        }

        // GET api/<PoofingDocumentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromQuery] string dl)
        {
            byte[] file = null;
            string errorMessage = "";
            string FileName = "";
            string contentType;

            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            AdvantageFramework.Core.BLogic.Proofing.Methods.GetDocument(qs, id ,ref file, ref FileName, ref errorMessage);

            new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider().TryGetContentType(FileName, out contentType);

            if (file != null)
            {
                System.IO.Stream stream = new System.IO.MemoryStream(file);
                return File(stream, contentType, FileName);
            }

            return NotFound();
        }

        // POST api/<PoofingDocumentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PoofingDocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PoofingDocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

#region private

#endregion

    }
}
