
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_COMPONENT")]
    public partial class JobComponent
    {
        public JobComponent()
        {
            Clients = new HashSet<Client>();
            JobComponentDocuments = new HashSet<JobComponentDocument>();
            JobTrafficDets = new HashSet<JobTrafficDet>();
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
        [Key]
        [Column("JOB_COMPONENT_NBR")]
        public short JobComponentNbr { get; set; }
        [Column("JOB_BILL_HOLD")]
        public short? JobBillHold { get; set; }
        [Required]
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("JOB_COMP_DATE", TypeName = "smalldatetime")]
        public DateTime? JobCompDate { get; set; }
        [Column("JOB_FIRST_USE_DATE", TypeName = "smalldatetime")]
        public DateTime? JobFirstUseDate { get; set; }
        [Column("START_DATE", TypeName = "smalldatetime")]
        public DateTime? StartDate { get; set; }
        [Column("JOB_AD_SIZE")]
        [StringLength(60)]
        public string JobAdSize { get; set; }
        [Required]
        [Column("JOB_SPEC_TYPE")]
        [StringLength(1)]
        public string JobSpecType { get; set; }
        [Column("DP_TM_CODE")]
        [StringLength(4)]
        public string DpTmCode { get; set; }
        [Column("JOB_MARKUP_PCT", TypeName = "decimal(7, 3)")]
        public decimal? JobMarkupPct { get; set; }
        [Column("CREATIVE_INSTR", TypeName = "text")]
        public string CreativeInstr { get; set; }
        [Column("JOB_LAYOUT_THUMB")]
        public short? JobLayoutThumb { get; set; }
        [Column("JOB_LAYOUT_ROUGH")]
        public short? JobLayoutRough { get; set; }
        [Column("JOB_LAYOUT_COMP")]
        public short? JobLayoutComp { get; set; }
        [Column("JOB_LAYOUT_NONE")]
        public short? JobLayoutNone { get; set; }
        [Column("JOB_LAYOUT_SPECIAL")]
        public short? JobLayoutSpecial { get; set; }
        [Column("JOB_LAYOUT_SPC_EXP")]
        [StringLength(60)]
        public string JobLayoutSpcExp { get; set; }
        [Column("JOB_PROCESS_CONTRL")]
        public short? JobProcessContrl { get; set; }
        [Required]
        [Column("JOB_COMP_DESC")]
        [StringLength(60)]
        public string JobCompDesc { get; set; }
        [Column("JOB_COMP_COMMENTS", TypeName = "text")]
        public string JobCompComments { get; set; }
        [Column("JOB_COMP_BUDGET_AM", TypeName = "decimal(11, 2)")]
        public decimal? JobCompBudgetAm { get; set; }
        [Column("ESTIMATE_NUMBER")]
        public int? EstimateNumber { get; set; }
        [Column("EST_COMPONENT_NBR")]
        public short? EstComponentNbr { get; set; }
        [Column("BILLING_USER")]
        [StringLength(100)]
        public string BillingUser { get; set; }
        [Column("AB_FLAG")]
        public short? AbFlag { get; set; }
        [Column("JOB_DEL_INSTRUCT", TypeName = "text")]
        public string JobDelInstruct { get; set; }
        [Column("JT_CODE")]
        [StringLength(10)]
        public string JtCode { get; set; }
        [Column("TAX_FLAG")]
        public short? TaxFlag { get; set; }
        [Column("TAX_CODE")]
        [StringLength(4)]
        public string TaxCode { get; set; }
        [Column("NOBILL_FLAG")]
        public short? NobillFlag { get; set; }
        [Column("EMAIL_GR_CODE")]
        [StringLength(50)]
        public string EmailGrCode { get; set; }
        [Column("AD_NBR")]
        [StringLength(30)]
        public string AdNbr { get; set; }
        [Column("ACCT_NBR")]
        [StringLength(30)]
        public string AcctNbr { get; set; }
        [Column("PRD_AB_INCOME")]
        public short? PrdAbIncome { get; set; }
        [Column("MARKET_CODE")]
        [StringLength(10)]
        public string MarketCode { get; set; }
        [Column("SERVICE_FEE_FLAG")]
        public short? ServiceFeeFlag { get; set; }
        [Column("ARCHIVE_FLAG")]
        public short? ArchiveFlag { get; set; }
        [Column("ROWID")]
        public int Rowid { get; set; }
        [Column("ADJUST_USER")]
        [StringLength(100)]
        public string AdjustUser { get; set; }
        [Column("TRF_SCHEDULE_BY")]
        public short? TrfScheduleBy { get; set; }
        [Column("TRF_SCHEDULE_REQ")]
        public short? TrfScheduleReq { get; set; }
        [Column("JOB_CL_PO_NBR")]
        [StringLength(40)]
        public string JobClPoNbr { get; set; }
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
        [Column("JOB_TMPLT_CODE")]
        [StringLength(6)]
        public string JobTmpltCode { get; set; }
        [Column("FEE_TIME")]
        public short? FeeTime { get; set; }
        [Column("FISCAL_PERIOD_CODE")]
        [StringLength(6)]
        public string FiscalPeriodCode { get; set; }
        [Column("JOB_QTY")]
        public int? JobQty { get; set; }
        [Column("BLACKPLT_VER_CODE")]
        [StringLength(6)]
        public string BlackpltVerCode { get; set; }
        [Column("BLACKPLT_VER_DESC")]
        [StringLength(60)]
        public string BlackpltVerDesc { get; set; }
        [Column("BLACKPLT_VER2_CODE")]
        [StringLength(6)]
        public string BlackpltVer2Code { get; set; }
        [Column("BLACKPLT_VER2_DESC")]
        [StringLength(60)]
        public string BlackpltVer2Desc { get; set; }
        [Column("CDP_CONTACT_ID")]
        public int? CdpContactId { get; set; }
        [Column("PRD_CONT_CODE")]
        [StringLength(6)]
        public string PrdContCode { get; set; }
        [Column("BA_BATCH_ID")]
        public int? BaBatchId { get; set; }
        [Column("SELECTED_BA_ID")]
        public int? SelectedBaId { get; set; }
        [Column("BCC_ID")]
        public int? BccId { get; set; }
        [Column("ALRT_NOTIFY_HDR_ID")]
        public int? AlrtNotifyHdrId { get; set; }
        [Column("SERVICE_FEE_TYPE_ID")]
        public int? ServiceFeeTypeId { get; set; }
        [Column("MEDIA_BILL_DATE", TypeName = "smalldatetime")]
        public DateTime? MediaBillDate { get; set; }
        [Column("CS_PROJECT_ID")]
        public int? CsProjectId { get; set; }
        [Column("JC_COMMENTS_HTML", TypeName = "text")]
        public string JcCommentsHtml { get; set; }
        [Column("CREATIVE_INSTR_HTML", TypeName = "text")]
        public string CreativeInstrHtml { get; set; }
        [Column("JOB_DEL_INSTR_HTML", TypeName = "text")]
        public string JobDelInstrHtml { get; set; }
        [Column("TRF_JOB_NUMBER")]
        public int? TrfJobNumber { get; set; }
        [Column("TRF_JOB_COMPONENT_NBR")]
        public short? TrfJobComponentNbr { get; set; }
        [Column("CLIENT_DISCOUNT_CODE")]
        [StringLength(6)]
        public string ClientDiscountCode { get; set; }
        [Column("MODIFY_DATE", TypeName = "smalldatetime")]
        public DateTime? ModifyDate { get; set; }
        [Column("MODIFIED_BY")]
        [StringLength(100)]
        public string ModifiedBy { get; set; }

        [ForeignKey(nameof(JobNumber))]
        [InverseProperty(nameof(Job.JobComponents))]
        public virtual Job JobNumberNavigation { get; set; }
        [InverseProperty("Job")]
        public virtual ProjectSchedule JobTraffic { get; set; }
        [InverseProperty(nameof(Client.AutomatedAssignmentJob))]
        public virtual ICollection<Client> Clients { get; set; }
        [InverseProperty(nameof(JobComponentDocument.Job))]
        public virtual ICollection<JobComponentDocument> JobComponentDocuments { get; set; }
        [InverseProperty(nameof(JobTrafficDet.Job))]
        public virtual ICollection<JobTrafficDet> JobTrafficDets { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}