using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Webvantage.Angular.Models;

namespace Webvantage.Angular.Controllers.Proofing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProofingRefreshController : ControllerBase
    {
        //private readonly IHubContext<ProofingRefreshHub> _hubContext;

        //public ProofingRefreshController(IHubContext<ProofingRefreshHub> hubContext)
        //{
        //    _hubContext = hubContext;
        //}

        [HttpGet]
        public string Get(string dl)
        {
            //AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            //AdvantageFramework.Core.Web.QueryString qsEncrypted = new AdvantageFramework.Core.Web.QueryString(qs.ConnectionString, qs.UserCode, "");

            //string WebvantageURL = AdvantageFramework.Core.Agency.Methods.GetWebvantageURL(qs.ConnectionString);

            //if (WebvantageURL[WebvantageURL.Length - 1] != '/' && WebvantageURL[WebvantageURL.Length - 1] != '\\')
            //{
            //    WebvantageURL += '/';
            //}

            //qsEncrypted.Page = WebvantageURL + "Desktop/Alert/RefreshProofingAssignment";
            //qsEncrypted.Add("AlertID", qs.AlertID.ToString());
            //qsEncrypted.AlertID = qs.AlertID;
            //qsEncrypted.UserCode = qs.UserCode;

            //return qsEncrypted.ToString();
            return "";
        }

        public class stupid
        {
            public string dl { get; set; }
        }

        [HttpPost]
        public void Post([FromBody] stupid really)
        {
            //AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(really.dl);
            //AdvantageFramework.Core.Web.QueryString qsEncrypted = new AdvantageFramework.Core.Web.QueryString(qs.ConnectionString, qs.UserCode, "");

            //string WebvantageURL = AdvantageFramework.Core.Agency.Methods.GetWebvantageURL(qs.ConnectionString);

            //if (WebvantageURL[WebvantageURL.Length - 1] != '/' && WebvantageURL[WebvantageURL.Length - 1] != '\\')
            //{
            //    WebvantageURL += '/';
            //}

            //qsEncrypted.Page = WebvantageURL + "Desktop/Alert/RefreshProofingAssignment";
            //qsEncrypted.Add("AlertID", qs.AlertID.ToString());
            //qsEncrypted.AlertID = qs.AlertID;
            //qsEncrypted.UserCode = qs.UserCode;

            //using var client = new HttpClient();

            //var result = client.GetAsync(qsEncrypted.ToString()).Result;

            //using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            //{
            //    Console.WriteLine(sr.ReadToEnd());
            //}

            //from here we need to update 
            //_hubContext.Clients.All.SendAsync(alertID.ToString());
        }
    }
}
