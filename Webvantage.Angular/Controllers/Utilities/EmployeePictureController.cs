using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Utilities
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePictureController : ControllerBase
    {
        // GET: api/<EmployeePictureController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeePictureController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id, [FromQuery] string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            AdvantageFramework.Core.Database.Entities.EmployeePicture EmployeePic = AdvantageFramework.Core.BLogic.EmployeePicture.Methods.LoadByEmployeeCode(qs, id.ToLower());

            if (EmployeePic != null)
            {
                return File(EmployeePic.EmpImage, "image/png");
            }

            return NotFound();
        }

        // POST api/<EmployeePictureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeePictureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeePictureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
