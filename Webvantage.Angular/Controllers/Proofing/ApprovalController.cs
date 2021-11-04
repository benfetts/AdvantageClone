using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webvantage.Angular.Controllers.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webvantage.Angular.Controllers.Proofing
{
    //temp stub class
    public class Aprroval
    {
        public int ApprovalStatus { get; set; }
        //public DateTime DateApproved { get; set; }
        public string UserCode { get; set; }
        public string EmpCode { get; set; }
        public string EmpFullName { get; set; }
        public int? DocumentId { get; set; }
        public DateTime? DateApproved { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : BaseController
    {
        // GET: api/<ApprovalController>
        [HttpGet]
        public object Get(string dl)
        {
            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);
            List<AdvantageFramework.Core.Database.Entities.Approval> approvals = AdvantageFramework.Core.BLogic.Proofing.Methods.GetApprovalsList(qs.ConnectionString, qs.AlertID,qs.DocumentID);

            foreach (AdvantageFramework.Core.Database.Entities.Approval approval in approvals)
            {
                if(approval.EmployeeCode == null)
                {
                    approval.IsCurrentState = false;
                    approval.AlertStateId = 999;
                    approval.AlertStateName = "External Approver";
                }
            }

            approvals.ForEach(a => { if (a.AlertStateId == null) a.AlertStateId = 0; });

            //because square sucks .Where(a => a.DocumentID == qs.DocumentID || a.DocumentID == null)
            var approves = approvals.GroupBy(a => a.AlertStateId,
                              a => a,
                              (key, g) => new
                              {
                                  Group = new { AlertStateId = key, AlertStateName = g.ToArray()[0].AlertStateName, IsCurrentState = g.ToArray()[0].IsCurrentState },
                                  Reviewers = Array.ConvertAll(g.OrderBy(rev => rev.Name).ToArray(), (x) =>
                                  {
                                      return new
                                      {
                                          EmployeeName = x.Name,
                                          ProofingStatus = x.ProofingStatus,
                                          ProofingStatusID = x.ProofingStatusID,
                                          ApproveDate = x.ApproveDate,
                                          ProofingStatusExternalReviewerID = x.ProofingStatusExternalReviewerID,
                                          EmployeeCode = x.EmployeeCode
                                      };
                                  })
                              }).OrderBy(a => a.Group.AlertStateId);

            return approves;
        }

        // GET api/<ApprovalController>/5
        [HttpGet("{id}")]
        public object Get(int id, [FromQuery] string dl)
        {
            List<Aprroval> rv = new List<Aprroval>();

            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);
            List<AdvantageFramework.Core.Database.Entities.Approval> approvals = AdvantageFramework.Core.BLogic.Proofing.Methods.GetApprovalsList(qs.ConnectionString, qs.AlertID, id);

            foreach (AdvantageFramework.Core.Database.Entities.Approval approval in approvals)
            {
                if (approval.EmployeeCode == null)
                {
                    approval.IsCurrentState = false;
                    approval.AlertStateId = 999;
                    approval.AlertStateName = "External Reviewers";
                }
            }

            approvals.ForEach(a => { if (a.AlertStateId == null) a.AlertStateId = 0; });

            //because square sucks .Where(a => a.DocumentID == id || (id == qs.DocumentID && a.DocumentID == null))
            var approves = approvals.GroupBy(a => a.AlertStateId,
                              a => a,
                              (key, g) => new
                              {
                                  Group = new { AlertStateId = key, AlertStateName = g.ToArray()[0].AlertStateName, IsCurrentState = g.ToArray()[0].IsCurrentState },
                                  Reviewers = Array.ConvertAll(g.OrderBy(rev => rev.Name).ToArray(), (x) =>
                                  {
                                      return new
                                      {
                                          EmployeeName = x.Name,
                                          ProofingStatus = x.ProofingStatus,
                                          ProofingStatusID = x.ProofingStatusID,
                                          ApproveDate = x.ApproveDate,
                                          ProofingStatusExternalReviewerID = x.ProofingStatusExternalReviewerID,
                                          EmployeeCode = x.EmployeeCode
                                      };
                                  })
                              }).OrderBy(a => a.Group.AlertStateId);

            return approves;
        }

        // POST api/<ApprovalController>
        [HttpPost]
        public async Task<ActionResult<Aprroval>> PostAsync([FromQuery] string dl, [FromBody] Aprroval value)
        {
            Aprroval rv = new Aprroval();

            AdvantageFramework.Core.Web.QueryString qs = AdvantageFramework.Core.Web.QueryString.FromEncrypted(dl);

            rv.UserCode = qs.UserCode;

            if (qs.ProofingStatusExternalReviewerID <= 0) {

                AdvantageFramework.Core.BLogic.Proofing.ProofingStatusID _value = (AdvantageFramework.Core.BLogic.Proofing.ProofingStatusID)value.ApprovalStatus;

                AdvantageFramework.Core.Database.Entities.CompleteAssignmentResult _rv = await AdvantageFramework.Core.BLogic.Proofing.Methods.CompleteAssignment(
                    qs.ConnectionString, qs.AlertID, qs.EmployeeCode, qs.UserCode, value.DocumentId == null ? qs.DocumentID : (int)value.DocumentId, _value);
            }
            else
            {
                AdvantageFramework.Core.BLogic.Proofing.ProofingStatusID _value = (AdvantageFramework.Core.BLogic.Proofing.ProofingStatusID)value.ApprovalStatus;
                AdvantageFramework.Core.BLogic.Proofing.Methods.ExternalUserCompleteAssignment(qs.ConnectionString, qs.AlertID,
                    qs.ProofingStatusExternalReviewerID, value.DocumentId == null ? qs.DocumentID : (int)value.DocumentId, _value);
            }

            NotifyAlertRecipients(qs, qs.AlertID, true, true, false, false, null, false, qs.DocumentID, true);

            return rv;
        }

        // PUT api/<ApprovalController>/5
        [HttpPut("{id}")]
        public Aprroval Put(int id, [FromBody] Aprroval value)
        {
            Aprroval rv = new Aprroval();

            return rv;
        }

        // DELETE api/<ApprovalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromQuery] string dl)
        {
        }
    }
}
