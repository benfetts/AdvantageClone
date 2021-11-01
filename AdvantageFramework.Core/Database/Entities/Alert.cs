
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT")]
    public partial class Alert
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

        public Alert()
        {
            AlertAttachments = new HashSet<AlertAttachment>();
            AlertComments = new HashSet<AlertComment>();
            AlertEmpHours = new HashSet<AlertEmployeeHour>();
            AlertRcptDismisseds = new HashSet<AlertRecipientDismissed>();
            AlertRcptExts = new HashSet<AlertRecipientExternal>();
            AlertRcpts = new HashSet<AlertRecipient>();
        }

        [Key]
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Column("ALERT_TYPE_ID")]
        public int AlertTypeId { get; set; }
        [Column("ALERT_CAT_ID")]
        public int AlertCatId { get; set; }
        [Column("SUBJECT")]
        [StringLength(254)]
        public string Subject { get; set; }
        [Column("BODY", TypeName = "text")]
        public string Body { get; set; }
        [Column("GENERATED", TypeName = "smalldatetime")]
        public DateTime? Generated { get; set; }
        [Column("PRIORITY")]
        public short? Priority { get; set; }
        [Column("CL_CODE")]
        [StringLength(6)]
        public string ClCode { get; set; }
        [Column("DIV_CODE")]
        [StringLength(6)]
        public string DivCode { get; set; }
        [Column("PRD_CODE")]
        [StringLength(6)]
        public string PrdCode { get; set; }
        [Column("CMP_CODE")]
        [StringLength(6)]
        public string CmpCode { get; set; }
        [Column("JOB_NUMBER")]
        public int? JobNumber { get; set; }
        [Column("JOB_COMPONENT_NBR")]
        public short? JobComponentNbr { get; set; }
        [Column("ESTIMATE_NUMBER")]
        public int? EstimateNumber { get; set; }
        [Column("EST_COMPONENT_NBR")]
        public short? EstComponentNbr { get; set; }
        [Column("EST_QUOTE_NBR")]
        public short? EstQuoteNbr { get; set; }
        [Column("ESTIMATE_REV_NBR")]
        public short? EstimateRevNbr { get; set; }
        [Column("VN_CODE")]
        [StringLength(6)]
        public string VnCode { get; set; }
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("PO_NUMBER")]
        public int? PoNumber { get; set; }
        [Column("PO_REVISION")]
        public short? PoRevision { get; set; }
        [Column("ORDER_NBR")]
        public int? OrderNbr { get; set; }
        [Column("REV_NBR")]
        public short? RevNbr { get; set; }
        [Column("ALERT_USER")]
        [StringLength(100)]
        public string AlertUser { get; set; }
        [Column("TEMP_PDF_PATH")]
        [StringLength(254)]
        public string TempPdfPath { get; set; }
        [Column("ALERT_LEVEL")]
        [StringLength(50)]
        public string AlertLevel { get; set; }
        [Column("CMP_IDENTIFIER")]
        public int? CmpIdentifier { get; set; }
        [Column("OFFICE_CODE")]
        [StringLength(4)]
        public string OfficeCode { get; set; }
        [Column("BODY_HTML", TypeName = "text")]
        public string BodyHtml { get; set; }
        [Column("CP_ALERT")]
        public short? CpAlert { get; set; }
        [Column("BA_BATCH_ID")]
        public int? BaBatchId { get; set; }
        [Column("TASK_SEQ_NBR")]
        public short? TaskSeqNbr { get; set; }
        [Column("DUE_DATE", TypeName = "smalldatetime")]
        public DateTime? DueDate { get; set; }
        [Column("ALERT_STATE_ID")]
        public int? AlertStateId { get; set; }
        [Column("ALRT_NOTIFY_HDR_ID")]
        public int? AlrtNotifyHdrId { get; set; }
        [Column("TIME_DUE")]
        [StringLength(10)]
        public string TimeDue { get; set; }
        [Column("VER")]
        [StringLength(10)]
        public string Ver { get; set; }
        [Column("BUILD")]
        [StringLength(10)]
        public string Build { get; set; }
        [Column("ALERT_SEQ_NBR")]
        public short? AlertSeqNbr { get; set; }
        [Column("SENT", TypeName = "smalldatetime")]
        public DateTime? Sent { get; set; }
        [Column("LAST_UPDATED", TypeName = "smalldatetime")]
        public DateTime? LastUpdated { get; set; }
        [Column("VER2")]
        [StringLength(10)]
        public string Ver2 { get; set; }
        [Column("BUILD2")]
        [StringLength(10)]
        public string Build2 { get; set; }
        [Column("ALERT_USER_CP")]
        public int? AlertUserCp { get; set; }
        [Column("NON_TASK_ID")]
        public int? NonTaskId { get; set; }
        [Column("AP_ID")]
        public int? ApId { get; set; }
        [Column("AP_SEQ")]
        public short? ApSeq { get; set; }
        [Column("ATB_REV_ID")]
        public int? AtbRevId { get; set; }
        [Column("IS_DRAFT")]
        public bool? IsDraft { get; set; }
        [Column("ATTACHMENT_COUNT")]
        public int? AttachmentCount { get; set; }
        [Column("LAST_UPDATED_USER_CODE")]
        [StringLength(100)]
        public string LastUpdatedUserCode { get; set; }
        [Column("LAST_UPDATED_FML")]
        [StringLength(80)]
        public string LastUpdatedFml { get; set; }
        [Column("ASSIGNED_EMP_CODE")]
        [StringLength(6)]
        public string AssignedEmpCode { get; set; }
        [Column("ASSIGNED_EMP_FML")]
        [StringLength(80)]
        public string AssignedEmpFml { get; set; }
        [Column("ASSIGN_COMPLETED")]
        public bool? AssignCompleted { get; set; }
        [Column("LAST_ASSIGNED_EMP_CODE")]
        [StringLength(6)]
        public string LastAssignedEmpCode { get; set; }
        [Column("JOB_VER_HDR_ID")]
        public int? JobVerHdrId { get; set; }
        [Column("IS_CS_REVIEW")]
        public bool? IsCsReview { get; set; }
        [Column("CS_AUTO_APPR_METHOD")]
        public int? CsAutoApprMethod { get; set; }
        [Column("CS_REVIEW_TYPE")]
        public int? CsReviewType { get; set; }
        [Column("CS_REVIEW_STATUS")]
        public int? CsReviewStatus { get; set; }
        [Column("CS_PROJECT_ID")]
        public int? CsProjectId { get; set; }
        [Column("CS_REVIEW_ID")]
        public int? CsReviewId { get; set; }
        [Column("CS_NUM_REVIEWER")]
        public int? CsNumReviewer { get; set; }
        [Column("CS_NUM_CMPLT")]
        public int? CsNumCmplt { get; set; }
        [Column("CS_ASSET_IMG", TypeName = "image")]
        public byte[] CsAssetImg { get; set; }
        [Column("CS_NUM_REJECT")]
        public int? CsNumReject { get; set; }
        [Column("CS_NUM_DEFER")]
        public int? CsNumDefer { get; set; }
        [Column("CS_NUM_APPR")]
        public int? CsNumAppr { get; set; }
        [Column("IS_WORK_ITEM")]
        public bool? IsWorkItem { get; set; }
        [Column("BOARD_STATE_ID")]
        public int? BoardStateId { get; set; }
        [Column("EPIC_ID")]
        public int? EpicId { get; set; }
        [Column("HRS_ALLOWED", TypeName = "decimal(7, 2)")]
        public decimal? HrsAllowed { get; set; }
        [Column("BACKLOG_SEQ_NBR")]
        public int? BacklogSeqNbr { get; set; }
        [Column("START_DATE", TypeName = "smalldatetime")]
        public DateTime? StartDate { get; set; }

        [ForeignKey(nameof(AlertCatId))]
        [InverseProperty(nameof(AlertCategory.Alerts))]
        public virtual AlertCategory AlertCat { get; set; }
        [ForeignKey(nameof(AlertStateId))]
        [InverseProperty("Alerts")]
        public virtual AlertState AlertState { get; set; }
        [ForeignKey(nameof(AlertTypeId))]
        [InverseProperty("Alerts")]
        public virtual AlertType AlertType { get; set; }
        [InverseProperty(nameof(AlertAttachment.Alert))]
        public virtual ICollection<AlertAttachment> AlertAttachments { get; set; }
        [InverseProperty(nameof(AlertComment.Alert))]
        public virtual ICollection<AlertComment> AlertComments { get; set; }
        [InverseProperty(nameof(AlertEmployeeHour.Alert))]
        public virtual ICollection<AlertEmployeeHour> AlertEmpHours { get; set; }
        [InverseProperty(nameof(AlertRecipientDismissed.Alert))]
        public virtual ICollection<AlertRecipientDismissed> AlertRcptDismisseds { get; set; }
        [InverseProperty(nameof(AlertRecipientExternal.Alert))]
        public virtual ICollection<AlertRecipientExternal> AlertRcptExts { get; set; }
        [InverseProperty(nameof(AlertRecipient.Alert))]
        public virtual ICollection<AlertRecipient> AlertRcpts { get; set; }
        [InverseProperty(nameof(ClientPortalAlertRecipient.Alert))]
        public virtual ICollection<ClientPortalAlertRecipient> ClientPortalAlertRecipients { get; set; }
        [InverseProperty(nameof(MediaRFPHeader.Alert))]
        public virtual ICollection<MediaRFPHeader> MediaRfpHeaders { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
