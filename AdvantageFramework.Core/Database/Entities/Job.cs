
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_LOG")]
    public partial class Job
    {
        public Job()
        {
            JobComponents = new HashSet<JobComponent>();
            JobDocuments = new HashSet<JobDocument>();
        }

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
        [Column("JOB_NUMBER")]
        public int JobNumber { get; set; }
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
        [Column("CMP_CODE")]
        [StringLength(6)]
        public string CmpCode { get; set; }
        [Column("SC_CODE")]
        [StringLength(6)]
        public string ScCode { get; set; }
        [Column("USER_ID")]
        [StringLength(100)]
        public string UserId { get; set; }
        [Column("CREATE_DATE", TypeName = "smalldatetime")]
        public DateTime? CreateDate { get; set; }
        [Column("JOB_DESC")]
        [StringLength(60)]
        public string JobDesc { get; set; }
        [Column("JOB_DATE_OPENED", TypeName = "smalldatetime")]
        public DateTime? JobDateOpened { get; set; }
        [Column("JOB_RUSH_CHARGES")]
        public short? JobRushCharges { get; set; }
        [Column("JOB_ESTIMATE_REQ")]
        public short? JobEstimateReq { get; set; }
        [Column("JOB_COMMENTS", TypeName = "text")]
        public string JobComments { get; set; }
        [Column("JOB_CLI_REF")]
        [StringLength(30)]
        public string JobCliRef { get; set; }
        [Column("BILL_COOP_CODE")]
        [StringLength(6)]
        public string BillCoopCode { get; set; }
        [Column("FORMAT_SC_CODE")]
        [StringLength(6)]
        public string FormatScCode { get; set; }
        [Column("FORMAT_CODE")]
        [StringLength(8)]
        public string FormatCode { get; set; }
        [Column("COMPLEX_CODE")]
        [StringLength(8)]
        public string ComplexCode { get; set; }
        [Column("PROMO_CODE")]
        [StringLength(8)]
        public string PromoCode { get; set; }
        [Column("CMP_IDENTIFIER")]
        public int? CmpIdentifier { get; set; }
        [Column("CMP_LINE_NBR")]
        public short? CmpLineNbr { get; set; }
        [Column("ROWID")]
        public int Rowid { get; set; }
        [Column("JOB_BILL_COMMENT")]
        [StringLength(254)]
        public string JobBillComment { get; set; }
        [Column("FEE_JOB")]
        public short? FeeJob { get; set; }
        [Column("UDV1_CODE")]
        [StringLength(10)]
        public string Udv1Code { get; set; }
        [Column("UDV2_CODE")]
        [StringLength(10)]
        public string Udv2Code { get; set; }
        [Column("UDV3_CODE")]
        [StringLength(10)]
        public string Udv3Code { get; set; }
        [Column("UDV4_CODE")]
        [StringLength(10)]
        public string Udv4Code { get; set; }
        [Column("UDV5_CODE")]
        [StringLength(10)]
        public string Udv5Code { get; set; }
        [Column("COMP_OPEN")]
        public int? CompOpen { get; set; }
        [Column("LOCKED_USER")]
        [StringLength(100)]
        public string LockedUser { get; set; }
        [Column("NP_COOP_SPLIT")]
        public short? NpCoopSplit { get; set; }
        [Column("JOB_COMMENTS_HTML", TypeName = "text")]
        public string JobCommentsHtml { get; set; }
        [Column("MODIFY_DATE", TypeName = "smalldatetime")]
        public DateTime? ModifyDate { get; set; }
        [Column("MODIFIED_BY")]
        [StringLength(100)]
        public string ModifiedBy { get; set; }

        [ForeignKey(nameof(OfficeCode))]
        [InverseProperty(nameof(Office.JobLogs))]
        public virtual Office OfficeCodeNavigation { get; set; }
        [ForeignKey("ClCode,DivCode,PrdCode")]
        [InverseProperty("JobLogs")]
        public virtual Product Product { get; set; }
        [InverseProperty(nameof(JobComponent.JobNumberNavigation))]
        public virtual ICollection<JobComponent> JobComponents { get; set; }
        [InverseProperty(nameof(JobDocument.JobNumberNavigation))]
        public virtual ICollection<JobDocument> JobDocuments { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}