
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_COMMENT")]
    public partial class AlertComment
    {
        #region Constants



        #endregion

        #region Enum

        public enum Properties
        {
            TBD
        }


        #endregion

        #region Variables



        #endregion

        #region Properties

        [Key]
        [Column("COMMENT_ID")]
        public int CommentId { get; set; }
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Column("USER_CODE")]
        [StringLength(100)]
        public string UserCode { get; set; }
        [Column("GENERATED_DATE", TypeName = "smalldatetime")]
        public DateTime? GeneratedDate { get; set; }
        [Column("COMMENT", TypeName = "text")]
        public string Comment { get; set; }
        [Required]
        [Column("EMAILSENT")]
        public bool? Emailsent { get; set; }
        [Column("USER_CODE_CP")]
        public int? UserCodeCp { get; set; }
        [Column("DOCUMENT_LIST", TypeName = "varchar(max)")]
        public string DocumentList { get; set; }
        [Column("ASSIGNED_EMP_CODE")]
        [StringLength(6)]
        public string AssignedEmpCode { get; set; }
        [Column("ALRT_NOTIFY_HDR_ID")]
        public int? AlrtNotifyHdrId { get; set; }
        [Column("ALERT_STATE_ID")]
        public int? AlertStateId { get; set; }
        [Column("CS_PROJECT_ID")]
        public int? CsProjectId { get; set; }
        [Column("CS_REVIEW_ID")]
        public int? CsReviewId { get; set; }
        [Column("CS_COMMENT_ID")]
        public int? CsCommentId { get; set; }
        [Column("CS_REPLY_ID")]
        public int? CsReplyId { get; set; }
        [Column("PARENT_ID")]
        //[ForeignKey("ParentAlertComment")]
        public int? ParentId { get; set; }
        [Column("CS_MARKUP_IMAGE", TypeName = "image")]
        public byte[] CsMarkupImage { get; set; }
        [Column("IS_DRAFT")]
        public bool? IsDraft { get; set; }
        [Column("CUSTODY_START", TypeName = "smalldatetime")]
        public DateTime? CustodyStart { get; set; }
        [Column("CUSTODY_END", TypeName = "smalldatetime")]
        public DateTime? CustodyEnd { get; set; }
        [Column("BOARD_ID")]
        public int? BoardId { get; set; }
        [Column("BOARD_HDR_ID")]
        public int? BoardHdrId { get; set; }
        [Column("BOARD_COL_ID")]
        public int? BoardColId { get; set; }
        [Column("BOARD_DTL_ID")]
        public int? BoardDtlId { get; set; }
        [Column("IS_SYSTEM")]
        public bool? IsSystem { get; set; }
        [Column("VR_CODE")]
        [StringLength(4)]
        public string VrCode { get; set; }
        [Column("VC_CODE")]
        [StringLength(4)]
        public string VcCode { get; set; }
        [Column("DOCUMENT_ID")]
        public int? DocumentId { get; set; }
        [Column("PROOFING_X_REVIEWER_ID")]
        public int? ProofingXReviwerId { get; set; }

        [ForeignKey(nameof(AlertId))]
        [InverseProperty("AlertComments")]
        public virtual Alert Alert { get; set; }

        //public virtual AlertComment ParentAlertComment { get; set; }

        //public virtual ICollection<AlertComment> Replies { get; set; }
        #endregion

        #region Methods



        #endregion
    }
}
