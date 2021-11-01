using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Views
{
    public partial class AlertView
    {
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Column("SUBJECT")]
        [StringLength(254)]
        public string Subject { get; set; }
        [Column("GENERATED", TypeName = "smalldatetime")]
        public DateTime? Generated { get; set; }
        [Column("PROCESSED", TypeName = "smalldatetime")]
        public DateTime? Processed { get; set; }
        [Column("USER_NAME")]
        [StringLength(64)]
        public string UserName { get; set; }
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("PRIORITY")]
        public int Priority { get; set; }
        [Required]
        [Column("TYPE")]
        [StringLength(40)]
        public string Type { get; set; }
        [Required]
        [Column("CATEGORY")]
        [StringLength(40)]
        public string Category { get; set; }
        [Column("ALERT_TYPE_ID")]
        public int AlertTypeId { get; set; }
        [Column("ALERT_CAT_ID")]
        public int AlertCatId { get; set; }
        [Column("ATTACHMENTCOUNT")]
        public int? Attachmentcount { get; set; }
        [Column("ALERT_LEVEL")]
        [StringLength(50)]
        public string AlertLevel { get; set; }
        [Column("OFFICE_CODE")]
        [StringLength(4)]
        public string OfficeCode { get; set; }
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
        [Column("SENDER_EMP_CODE")]
        [StringLength(6)]
        public string SenderEmpCode { get; set; }
        [Column("DISMISSED_DATE")]
        [StringLength(10)]
        public string DismissedDate { get; set; }
        [Column("CL_NAME")]
        [StringLength(40)]
        public string ClName { get; set; }
        [Column("DIV_NAME")]
        [StringLength(40)]
        public string DivName { get; set; }
        [Column("PRD_DESCRIPTION")]
        [StringLength(40)]
        public string PrdDescription { get; set; }
        [Column("CMP_NAME")]
        [StringLength(60)]
        public string CmpName { get; set; }
        [Column("BODY", TypeName = "text")]
        public string Body { get; set; }
        [Column("LOWER_SUBJECT")]
        [StringLength(254)]
        public string LowerSubject { get; set; }
        [Column("LOWER_BODY")]
        [StringLength(30)]
        public string LowerBody { get; set; }
        [Column("OFFICE_NAME")]
        [StringLength(30)]
        public string OfficeName { get; set; }
        [Column("JOB_DESC")]
        [StringLength(60)]
        public string JobDesc { get; set; }
        [Column("JOB_COMP_DESC")]
        [StringLength(60)]
        public string JobCompDesc { get; set; }
        [Column("ALERT_USER")]
        [StringLength(100)]
        public string AlertUser { get; set; }
        [Column("CP_ALERT")]
        public short? CpAlert { get; set; }
        [Column("NEW_ALERT")]
        public short? NewAlert { get; set; }
        [Column("READ_ALERT")]
        public short? ReadAlert { get; set; }
        [Column("VN_CODE")]
        [StringLength(6)]
        public string VnCode { get; set; }
        [Column("DUE_DATE", TypeName = "smalldatetime")]
        public DateTime? DueDate { get; set; }
        [Column("TIME_DUE")]
        [StringLength(10)]
        public string TimeDue { get; set; }
        [Column("ALERT_STATE_ID")]
        public int? AlertStateId { get; set; }
        [Column("ALERT_STATE_NAME")]
        [StringLength(100)]
        public string AlertStateName { get; set; }
        [Column("CURRENT_NOTIFY")]
        public int? CurrentNotify { get; set; }
        [Column("CURRENT_NOTIFY_EMP_CODE")]
        [StringLength(6)]
        public string CurrentNotifyEmpCode { get; set; }
        [Column("CURRENT_NOTIFY_EMP_FML")]
        [StringLength(64)]
        public string CurrentNotifyEmpFml { get; set; }
        [Column("GRP_OFFICE")]
        [StringLength(37)]
        public string GrpOffice { get; set; }
        [Column("GRP_CLIENT")]
        [StringLength(49)]
        public string GrpClient { get; set; }
        [Column("GRP_DIVISION")]
        [StringLength(57)]
        public string GrpDivision { get; set; }
        [Column("GRP_PRODUCT")]
        [StringLength(65)]
        public string GrpProduct { get; set; }
        [Column("GRP_JOB")]
        [StringLength(69)]
        public string GrpJob { get; set; }
        [Column("GRP_COMPONENT")]
        [StringLength(136)]
        public string GrpComponent { get; set; }
        [Column("TASK_SEQ_NBR")]
        public short? TaskSeqNbr { get; set; }
        [Column("TASK_FNC_CODE")]
        [StringLength(10)]
        public string TaskFncCode { get; set; }
        [Column("TASK_FNC_DESC")]
        [StringLength(40)]
        public string TaskFncDesc { get; set; }
        [Column("ESTIMATE_NUMBER")]
        public int? EstimateNumber { get; set; }
        [Column("EST_COMPONENT_NBR")]
        public short? EstComponentNbr { get; set; }
        [Column("GRP_ESTIMATE")]
        [StringLength(67)]
        public string GrpEstimate { get; set; }
        [Column("GRP_ESTIMATE_COMPONENT")]
        [StringLength(134)]
        public string GrpEstimateComponent { get; set; }
        [Column("GRP_TASK")]
        [StringLength(51)]
        public string GrpTask { get; set; }
        [Required]
        [Column("GRP_CAMPAIGN")]
        [StringLength(69)]
        public string GrpCampaign { get; set; }
        [Column("CMP_IDENTIFIER")]
        public int? CmpIdentifier { get; set; }
        [Column("VERSION_ID")]
        [StringLength(10)]
        public string VersionId { get; set; }
        [Column("BUILD_ID")]
        [StringLength(10)]
        public string BuildId { get; set; }
        [Column("VER")]
        [StringLength(10)]
        public string Ver { get; set; }
        [Column("BUILD")]
        [StringLength(10)]
        public string Build { get; set; }
        [Column("ALERT_SEQ_NBR")]
        public short? AlertSeqNbr { get; set; }
        [Required]
        [Column("GRP_PRIORITY")]
        [StringLength(6)]
        public string GrpPriority { get; set; }
        [Column("GRP_DUE_DATE")]
        [StringLength(64)]
        public string GrpDueDate { get; set; }
        [Column("GRP_DUE_DATE_DISPLAY")]
        [StringLength(64)]
        public string GrpDueDateDisplay { get; set; }
        [Column("ID")]
        public int? Id { get; set; }
        [Column("SENT", TypeName = "smalldatetime")]
        public DateTime? Sent { get; set; }
        [Column("ALRT_NOTIFY_HDR_ID")]
        public int? AlrtNotifyHdrId { get; set; }
        [Column("ALERT_NOTIFY_NAME")]
        [StringLength(100)]
        public string AlertNotifyName { get; set; }
        [Required]
        [Column("VN_NAME")]
        [StringLength(1)]
        public string VnName { get; set; }
    }
}
