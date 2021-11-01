using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Views
{
    public partial class ClientPortalAlertView
    {
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Column("SUBJECT")]
        [StringLength(254)]
        public string Subject { get; set; }
        [Column("GENERATED", TypeName = "smalldatetime")]
        public DateTime? Generated { get; set; }
        [Column("USER_NAME")]
        [StringLength(61)]
        public string UserName { get; set; }
        [Column("PRIORITY")]
        public short? Priority { get; set; }
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
        [Required]
        [Column("OFFICE_CODE")]
        [StringLength(4)]
        public string OfficeCode { get; set; }
        [Required]
        [Column("CL_CODE")]
        [StringLength(6)]
        public string ClCode { get; set; }
        [Required]
        [Column("DIV_CODE")]
        [StringLength(6)]
        public string DivCode { get; set; }
        [Required]
        [Column("PRD_CODE")]
        [StringLength(6)]
        public string PrdCode { get; set; }
        [Required]
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
        [Required]
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
        [Required]
        [Column("OFFICE_NAME")]
        [StringLength(30)]
        public string OfficeName { get; set; }
        [Column("JOB_DESC")]
        [StringLength(60)]
        public string JobDesc { get; set; }
        [Column("JOB_COMP_DESC")]
        [StringLength(60)]
        public string JobCompDesc { get; set; }
        [Column("PROCESSED", TypeName = "smalldatetime")]
        public DateTime? Processed { get; set; }
        [Column("CDP_CONTACT_ID")]
        public int? CdpContactId { get; set; }
        [Column("ALERT_USER")]
        [StringLength(100)]
        public string AlertUser { get; set; }
        [Column("CP_ALERT")]
        public short? CpAlert { get; set; }
        [Column("NEW_ALERT")]
        public short? NewAlert { get; set; }
        [Column("READ_ALERT")]
        public short? ReadAlert { get; set; }
    }
}
