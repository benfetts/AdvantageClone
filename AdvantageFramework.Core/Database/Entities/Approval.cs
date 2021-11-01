using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Entities
{
    public class Approval
    {
        #region Enum
        public enum Properties
        {
            ID,
            Name,
            ProofingStatusID,
            ProofingStatus,
            ApproveDate
        }

        #endregion

        #region Variables



        #endregion

        #region Properties

        public int? AlertStateId { get; set; }
        public string AlertStateName { get; set; }
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public int? ProofingStatusID { get; set; }
        public string ProofingStatus { get; set; }
        public DateTime? ApproveDate { get; set; }
        public bool? IsCurrentState { get; set; }
        public int? DocumentID { get; set; }
        public int? ProofingStatusExternalReviewerID { get; set; }

        #endregion
    }
}
