using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdvantageFramework.Core.Database.Entities
{
    public partial class Comment
    {
        public int AlertID { get; set; }
        public int RowID { get; set; }
        public int? CommentID { get; set; }
        public DateTime? GeneratedDate { get; set; }
        [Column("Comment")]
        public string LongComment { get; set; }
        public string ShortComment { get; set; }
        public int? IsTruncated { get; set; }
        public bool? IsClientPortalComment { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string EmployeeCode { get; set; }
        public string AssignedEmployeeCode { get; set; }
        public int? AlertTemplateID { get; set; }
        public string AlertTemplateName { get; set; }
        public int? AlertStateID { get; set; }
        public string AlertStateName { get; set; }
        public bool? AssignmentChanged { get; set; }
        public bool? IsUnassigned { get; set; }
        public string DocumentList { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeNickname { get; set; }
        public string AssignedFullName { get; set; }
        public string AssignedEmployeeNickname { get; set; }
        public DateTime? CustodyStartDate { get; set; }
        public DateTime? CustodyEndDate { get; set; }
        public int? ReplyLevel { get; set; }
        public int ParentID { get; set; }
        public int? MarkupID { get; set; }
        public string MarkupXML { get; set; }
        public string Markup { get; set; }
        public int? MarkupDocumentID { get; set; }
        public DateTime? MarkupGeneratedDate { get; set; }
        public int? MarkupTypeID { get; set; }

        [Column("PROOFING_X_REVIEWER_ID")]
        public int? ProofingXReviwerId { get; set; }
    }
}
