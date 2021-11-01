using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("AGY_POP3_AUTOMATED_ASSIGNMENT_ACCOUNT")]
    public partial class POP3AutomatedAssignmentAccount
    {
        [Key]
        [Column("AGY_POP3_AUTOMATED_ASSIGNMENT_ACCOUNT_ID")]
        public int AgyPop3AutomatedAssignmentAccountId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(30)]
        public string Description { get; set; }
        [Required]
        [Column("USERNAME")]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("DELETE_PROCESSED")]
        public bool DeleteProcessed { get; set; }
        [Column("JOB_NUMBER")]
        public int? JobNumber { get; set; }
        [Column("JOB_COMPONENT_NBR")]
        public short? JobComponentNbr { get; set; }
        [Column("ALRT_NOTIFY_HDR_ID")]
        public int? AlrtNotifyHdrId { get; set; }
        [Column("ALERT_STATE_ID")]
        public int? AlertStateId { get; set; }
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("INCLUDE_EMPLOYEE_CONTACTS")]
        public bool IncludeEmployeeContacts { get; set; }
        [Column("INCLUDE_CLIENT_CONTACTS")]
        public bool IncludeClientContacts { get; set; }
        [Column("FAILURE_MESSAGE")]
        public string FailureMessage { get; set; }
        [Column("SUCCESS_MESSAGE")]
        public string SuccessMessage { get; set; }
    }
}
