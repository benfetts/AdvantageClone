
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("CLIENT")]
    public partial class Client
    {
        public Client()
        {
            Divisions = new HashSet<Division>();
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
        [Column("CL_CODE")]
        [StringLength(6)]
        public string ClCode { get; set; }
        [Column("CL_NAME")]
        [StringLength(40)]
        public string ClName { get; set; }
        [Column("CL_ADDRESS1")]
        [StringLength(40)]
        public string ClAddress1 { get; set; }
        [Column("CL_ADDRESS2")]
        [StringLength(40)]
        public string ClAddress2 { get; set; }
        [Column("CL_CITY")]
        [StringLength(30)]
        public string ClCity { get; set; }
        [Column("CL_COUNTY")]
        [StringLength(20)]
        public string ClCounty { get; set; }
        [Column("CL_STATE")]
        [StringLength(10)]
        public string ClState { get; set; }
        [Column("CL_COUNTRY")]
        [StringLength(20)]
        public string ClCountry { get; set; }
        [Column("CL_ZIP")]
        [StringLength(10)]
        public string ClZip { get; set; }
        [Column("CL_ATTENTION")]
        [StringLength(40)]
        public string ClAttention { get; set; }
        [Column("CL_BADDRESS1")]
        [StringLength(40)]
        public string ClBaddress1 { get; set; }
        [Column("CL_BADDRESS2")]
        [StringLength(40)]
        public string ClBaddress2 { get; set; }
        [Column("CL_BCITY")]
        [StringLength(30)]
        public string ClBcity { get; set; }
        [Column("CL_BCOUNTY")]
        [StringLength(20)]
        public string ClBcounty { get; set; }
        [Column("CL_BSTATE")]
        [StringLength(10)]
        public string ClBstate { get; set; }
        [Column("CL_BCOUNTRY")]
        [StringLength(20)]
        public string ClBcountry { get; set; }
        [Column("CL_BZIP")]
        [StringLength(10)]
        public string ClBzip { get; set; }
        [Column("CL_SADDRESS1")]
        [StringLength(40)]
        public string ClSaddress1 { get; set; }
        [Column("CL_SADDRESS2")]
        [StringLength(40)]
        public string ClSaddress2 { get; set; }
        [Column("CL_SCITY")]
        [StringLength(30)]
        public string ClScity { get; set; }
        [Column("CL_SCOUNTY")]
        [StringLength(20)]
        public string ClScounty { get; set; }
        [Column("CL_SSTATE")]
        [StringLength(10)]
        public string ClSstate { get; set; }
        [Column("CL_SCOUNTRY")]
        [StringLength(20)]
        public string ClScountry { get; set; }
        [Column("CL_SZIP")]
        [StringLength(10)]
        public string ClSzip { get; set; }
        [Column("CL_FOOTER")]
        [StringLength(60)]
        public string ClFooter { get; set; }
        [Column("CL_ALPHA_SORT")]
        [StringLength(20)]
        public string ClAlphaSort { get; set; }
        [Column("CL_FISCAL_START")]
        public short? ClFiscalStart { get; set; }
        [Column("CL_CREDIT_LIMIT", TypeName = "decimal(15, 2)")]
        public decimal? ClCreditLimit { get; set; }
        [Column("CL_HIGH_BALANCE", TypeName = "decimal(15, 2)")]
        public decimal? ClHighBalance { get; set; }
        [Column("CL_INV_BY")]
        public short? ClInvBy { get; set; }
        [Column("INV_FORMAT")]
        [StringLength(12)]
        public string InvFormat { get; set; }
        [Column("CL_MATTENTION")]
        [StringLength(40)]
        public string ClMattention { get; set; }
        [Column("PINV_FORMAT")]
        [StringLength(12)]
        public string PinvFormat { get; set; }
        [Column("BINV_FORMAT")]
        [StringLength(12)]
        public string BinvFormat { get; set; }
        [Column("CL_MINV_BY")]
        public short? ClMinvBy { get; set; }
        [Column("CL_MFOOTER")]
        [StringLength(60)]
        public string ClMfooter { get; set; }
        [Column("ACTIVE_FLAG")]
        public short? ActiveFlag { get; set; }
        [Column("NEW_BUSINESS")]
        public short? NewBusiness { get; set; }
        [Column("CMP_CODE_R")]
        public short? CmpCodeR { get; set; }
        [Column("ACCT_NBR_R")]
        public short? AcctNbrR { get; set; }
        [Column("JT_CODE_R")]
        public short? JtCodeR { get; set; }
        [Column("PROMO_CODE_R")]
        public short? PromoCodeR { get; set; }
        [Column("REQ_FLDS")]
        public short? ReqFlds { get; set; }
        [Column("JOB_FIRST_USE_DT_R")]
        public short? JobFirstUseDtR { get; set; }
        [Column("COMPLEX_CODE_R")]
        public short? ComplexCodeR { get; set; }
        [Column("FORMAT_SC_CODE_R")]
        public short? FormatScCodeR { get; set; }
        [Column("DP_TM_CODE_R")]
        public short? DpTmCodeR { get; set; }
        [Column("MARKET_CODE_R")]
        public short? MarketCodeR { get; set; }
        [Column("EMAIL_GR_CODE_R")]
        public short? EmailGrCodeR { get; set; }
        [Column("BILL_COOP_CODE_R")]
        public short? BillCoopCodeR { get; set; }
        [Column("AD_NBR_R")]
        public short? AdNbrR { get; set; }
        [Column("JOB_CLI_REF_R")]
        public short? JobCliRefR { get; set; }
        [Column("JOB_DATE_OPENED_R")]
        public short? JobDateOpenedR { get; set; }
        [Column("JOB_AD_SIZE_R")]
        public short? JobAdSizeR { get; set; }
        [Column("PROD_CONT_CODE_R")]
        public short? ProdContCodeR { get; set; }
        [Column("JOB_COMP_BUDGET_R")]
        public short? JobCompBudgetR { get; set; }
        [Column("OINV_FORMAT")]
        [StringLength(12)]
        public string OinvFormat { get; set; }
        [Column("IINV_FORMAT")]
        [StringLength(12)]
        public string IinvFormat { get; set; }
        [Column("START_DATE_R")]
        public short? StartDateR { get; set; }
        [Column("JOB_LOG_UDV1_R")]
        public short? JobLogUdv1R { get; set; }
        [Column("JOB_LOG_UDV2_R")]
        public short? JobLogUdv2R { get; set; }
        [Column("JOB_LOG_UDV3_R")]
        public short? JobLogUdv3R { get; set; }
        [Column("JOB_LOG_UDV4_R")]
        public short? JobLogUdv4R { get; set; }
        [Column("JOB_LOG_UDV5_R")]
        public short? JobLogUdv5R { get; set; }
        [Column("JOB_CMP_UDV1_R")]
        public short? JobCmpUdv1R { get; set; }
        [Column("JOB_CMP_UDV2_R")]
        public short? JobCmpUdv2R { get; set; }
        [Column("JOB_CMP_UDV3_R")]
        public short? JobCmpUdv3R { get; set; }
        [Column("JOB_CMP_UDV4_R")]
        public short? JobCmpUdv4R { get; set; }
        [Column("JOB_CMP_UDV5_R")]
        public short? JobCmpUdv5R { get; set; }
        [Column("PINV_FORMAT2")]
        [StringLength(12)]
        public string PinvFormat2 { get; set; }
        [Column("CL_AR_COMMENT", TypeName = "text")]
        public string ClArComment { get; set; }
        [Column("REQ_PROD_CAT")]
        public short? ReqProdCat { get; set; }
        [Column("TAX_FLAG_R")]
        public short? TaxFlagR { get; set; }
        [Column("FISCAL_PD_R")]
        public short? FiscalPdR { get; set; }
        [Column("BLACKPLATE_VER_R")]
        public short? BlackplateVerR { get; set; }
        [Column("BLACKPLATE_VER2_R")]
        public short? BlackplateVer2R { get; set; }
        [Column("CL_P_PAYDAYS")]
        public short? ClPPaydays { get; set; }
        [Column("CL_M_PAYDAYS")]
        public short? ClMPaydays { get; set; }
        [Column("SERVICE_FEE_TYPE_R")]
        public short? ServiceFeeTypeR { get; set; }
        [Column("CONTRACT_EXP_DT", TypeName = "smalldatetime")]
        public DateTime? ContractExpDt { get; set; }
        [Column("REQ_TIME_COMMENT")]
        public bool ReqTimeComment { get; set; }
        [Column("BATCH_NAME")]
        [StringLength(50)]
        public string BatchName { get; set; }
        [Column("INV_BY_JOB_ON_NULL")]
        public bool? InvByJobOnNull { get; set; }
        [Column("INVOICE_LOCATION_ID")]
        [StringLength(6)]
        public string InvoiceLocationId { get; set; }
        [Column("AVALARA_SC_CODE")]
        [StringLength(6)]
        public string AvalaraScCode { get; set; }
        [Column("AVALARA_TAX_EXEMPT")]
        public bool? AvalaraTaxExempt { get; set; }
        [Column("COMBO_INV_BY")]
        public short? ComboInvBy { get; set; }
        [Column("COMBO_MEDIA_ONLY")]
        public bool ComboMediaOnly { get; set; }
        [Column("CURRENCY_CODE")]
        [StringLength(5)]
        public string CurrencyCode { get; set; }
        [Column("BILLER_EMP_CODE")]
        [StringLength(6)]
        public string BillerEmpCode { get; set; }
        [Column("CLIENT_DISCOUNT_CODE")]
        [StringLength(6)]
        public string ClientDiscountCode { get; set; }
        [Column("LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY")]
        public bool LimitTimeFunctionsToBillingHierarchy { get; set; }
        [Column("TV_UNIT_PRODUCT_SPLIT")]
        public bool TvUnitProductSplit { get; set; }
        [Column("CALC_LATE_FEE")]
        public bool CalcLateFee { get; set; }
        [Column("LATE_FEE_PERCENT", TypeName = "decimal(5, 2)")]
        public decimal? LateFeePercent { get; set; }
        [Column("AUTOMATED_ASSIGNMENT_JOB_NUMBER")]
        public int? AutomatedAssignmentJobNumber { get; set; }
        [Column("AUTOMATED_ASSIGNMENT_JOB_COMPONENT_NBR")]
        public short? AutomatedAssignmentJobComponentNbr { get; set; }
        [Column("VAT_NUMBER")]
        [StringLength(50)]
        public string VatNumber { get; set; }
        [Column("RESP_FOR_MEDIA_TRAFFIC_INSTRUCTION")]
        public bool RespForMediaTrafficInstruction { get; set; }

        [ForeignKey("AutomatedAssignmentJobNumber,AutomatedAssignmentJobComponentNbr")]
        [InverseProperty(nameof(JobComponent.Clients))]
        public virtual JobComponent AutomatedAssignmentJob { get; set; }
        [InverseProperty(nameof(Division.ClCodeNavigation))]
        public virtual ICollection<Division> Divisions { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}