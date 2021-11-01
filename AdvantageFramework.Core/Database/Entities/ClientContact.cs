﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("CDP_CONTACT_HDR")]
    public partial class ClientContact
    {
        [Key]
        [Column("CDP_CONTACT_ID")]
        public int CdpContactId { get; set; }
        [Required]
        [Column("CONT_CODE")]
        [StringLength(6)]
        public string ContCode { get; set; }
        [Required]
        [Column("CL_CODE")]
        [StringLength(6)]
        public string ClCode { get; set; }
        [Column("EMAIL_ADDRESS")]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("CONT_FNAME")]
        [StringLength(30)]
        public string ContFname { get; set; }
        [Column("CONT_LNAME")]
        [StringLength(30)]
        public string ContLname { get; set; }
        [Column("CONT_MI")]
        [StringLength(1)]
        public string ContMi { get; set; }
        [Column("CONT_TITLE")]
        [StringLength(40)]
        public string ContTitle { get; set; }
        [Column("CONT_ADDRESS1")]
        [StringLength(40)]
        public string ContAddress1 { get; set; }
        [Column("CONT_ADDRESS2")]
        [StringLength(40)]
        public string ContAddress2 { get; set; }
        [Column("CONT_CITY")]
        [StringLength(30)]
        public string ContCity { get; set; }
        [Column("CONT_COUNTY")]
        [StringLength(20)]
        public string ContCounty { get; set; }
        [Column("CONT_STATE")]
        [StringLength(10)]
        public string ContState { get; set; }
        [Column("CONT_COUNTRY")]
        [StringLength(20)]
        public string ContCountry { get; set; }
        [Column("CONT_ZIP")]
        [StringLength(10)]
        public string ContZip { get; set; }
        [Column("CONT_TELEPHONE")]
        [StringLength(13)]
        public string ContTelephone { get; set; }
        [Column("CONT_EXTENTION")]
        [StringLength(5)]
        public string ContExtention { get; set; }
        [Column("CONT_FAX")]
        [StringLength(13)]
        public string ContFax { get; set; }
        [Column("CONT_FAX_EXTENTION")]
        [StringLength(5)]
        public string ContFaxExtention { get; set; }
        [Column("SCHEDULE_USER")]
        public short? ScheduleUser { get; set; }
        [Column("DEFAULT_TASK")]
        [StringLength(10)]
        public string DefaultTask { get; set; }
        [Column("CP_USER")]
        public short? CpUser { get; set; }
        [Column("CP_ALERTS")]
        public short? CpAlerts { get; set; }
        [Column("EMAIL_RCPT")]
        public short? EmailRcpt { get; set; }
        [Column("TASK_PRIMARY")]
        public short? TaskPrimary { get; set; }
        [Column("INACTIVE_FLAG")]
        public short? InactiveFlag { get; set; }
        [Column("CONT_LF")]
        [StringLength(62)]
        public string ContLf { get; set; }
        [Column("CONT_FML")]
        [StringLength(64)]
        public string ContFml { get; set; }
        [Column("CELL_PHONE")]
        [StringLength(13)]
        public string CellPhone { get; set; }
        [Column("CONT_COMMENT", TypeName = "text")]
        public string ContComment { get; set; }
        [Column("CONTACT_TYPE_ID")]
        public int? ContactTypeId { get; set; }
    }
}
