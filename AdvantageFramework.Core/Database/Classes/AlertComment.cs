using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Classes
{
    public class AlertComment
    {
        public int CommentId { get; set; }
        public int AlertId { get; set; }
        public string UserCode { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public string Comment { get; set; }
        public bool? Emailsent { get; set; }
        public int? UserCodeCp { get; set; }
        public string DocumentList { get; set; }
        public string AssignedEmpCode { get; set; }
        public int? AlrtNotifyHdrId { get; set; }
        public int? AlertStateId { get; set; }
        public int? CsProjectId { get; set; }
        public int? CsReviewId { get; set; }
        public int? CsCommentId { get; set; }
        public int? CsReplyId { get; set; }
        public int? ParentId { get; set; }
        public byte[] CsMarkupImage { get; set; }
        public bool? IsDraft { get; set; }
        public DateTime? CustodyStart { get; set; }
        public DateTime? CustodyEnd { get; set; }
        public int? BoardId { get; set; }
        public int? BoardHdrId { get; set; }
        public int? BoardColId { get; set; }
        public int? BoardDtlId { get; set; }
        public bool? IsSystem { get; set; }
        public string VrCode { get; set; }
        public string VcCode { get; set; }
        public int? DocumentId { get; set; }
        public int? ProofingXReviwerId { get; set; }
        public virtual Entities.Alert Alert { get; set; }
        public virtual ICollection<AlertComment> Replies { get; set; }
        public string EmployeeFullName { get; set; }
        public int? MarkupId { get; set; }
        public short? MarkupSeqNumber { get; set; }

        public string[] Mentions { get; set; }
        public bool IsMyComment { get; internal set; }
    }
}
