
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("PRODUCT")]
    public partial class Product
    {
        public Product()
        {
            JobLogs = new HashSet<Job>();
            ProductDocuments = new HashSet<ProductDocument>();
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
        [Key]
        [Column("DIV_CODE")]
        [StringLength(6)]
        public string DivCode { get; set; }
        [Key]
        [Column("PRD_CODE")]
        [StringLength(6)]
        public string PrdCode { get; set; }
        [Column("PRD_DESCRIPTION")]
        [StringLength(40)]
        public string PrdDescription { get; set; }
        [Column("PRD_ATTENTION")]
        [StringLength(40)]
        public string PrdAttention { get; set; }
        [Column("PRD_BILL_ADDRESS1")]
        [StringLength(40)]
        public string PrdBillAddress1 { get; set; }
        [Column("PRD_BILL_ADDRESS2")]
        [StringLength(40)]
        public string PrdBillAddress2 { get; set; }
        [Column("PRD_BILL_CITY")]
        [StringLength(30)]
        public string PrdBillCity { get; set; }
        [Column("PRD_BILL_COUNTY")]
        [StringLength(20)]
        public string PrdBillCounty { get; set; }
        [Column("PRD_BILL_STATE")]
        [StringLength(10)]
        public string PrdBillState { get; set; }
        [Column("PRD_BILL_COUNTRY")]
        [StringLength(20)]
        public string PrdBillCountry { get; set; }
        [Column("PRD_BILL_ZIP")]
        [StringLength(10)]
        public string PrdBillZip { get; set; }
        [Column("PRD_BILL_TELEPHONE")]
        [StringLength(13)]
        public string PrdBillTelephone { get; set; }
        [Column("PRD_BILL_EXTENTION")]
        [StringLength(4)]
        public string PrdBillExtention { get; set; }
        [Column("PRD_BILL_FAX")]
        [StringLength(13)]
        public string PrdBillFax { get; set; }
        [Column("PRD_BILL_FAX_EXT")]
        [StringLength(4)]
        public string PrdBillFaxExt { get; set; }
        [Column("PRD_STATE_ADDR1")]
        [StringLength(40)]
        public string PrdStateAddr1 { get; set; }
        [Column("PRD_STATE_ADDR2")]
        [StringLength(40)]
        public string PrdStateAddr2 { get; set; }
        [Column("PRD_STATE_CITY")]
        [StringLength(30)]
        public string PrdStateCity { get; set; }
        [Column("PRD_STATE_COUNTY")]
        [StringLength(20)]
        public string PrdStateCounty { get; set; }
        [Column("PRD_STATE_STATE")]
        [StringLength(10)]
        public string PrdStateState { get; set; }
        [Column("PRD_STATE_COUNTRY")]
        [StringLength(20)]
        public string PrdStateCountry { get; set; }
        [Column("PRD_STATE_ZIP")]
        [StringLength(10)]
        public string PrdStateZip { get; set; }
        [Column("PRD_STATE_TELEPHON")]
        [StringLength(13)]
        public string PrdStateTelephon { get; set; }
        [Column("PRD_STATE_EXT")]
        [StringLength(4)]
        public string PrdStateExt { get; set; }
        [Column("PRD_STATE_FAX")]
        [StringLength(13)]
        public string PrdStateFax { get; set; }
        [Column("PRD_STATE_FAX_EXT")]
        [StringLength(4)]
        public string PrdStateFaxExt { get; set; }
        [Column("PRD_ALPHA_SORT")]
        [StringLength(20)]
        public string PrdAlphaSort { get; set; }
        [Required]
        [Column("OFFICE_CODE")]
        [StringLength(4)]
        public string OfficeCode { get; set; }
        [Column("PRD_CONSOL_FUNC")]
        public short? PrdConsolFunc { get; set; }
        [Column("PRD_CONT_PCT", TypeName = "decimal(7, 3)")]
        public decimal? PrdContPct { get; set; }
        [Column("PRD_PROD_MARKUP", TypeName = "decimal(7, 3)")]
        public decimal? PrdProdMarkup { get; set; }
        [Column("PRD_PROD_BCYCLE")]
        [StringLength(6)]
        public string PrdProdBcycle { get; set; }
        [Column("PRD_PROD_BILL_NET")]
        public short? PrdProdBillNet { get; set; }
        [Column("PRD_PROD_VEN_DISC")]
        public short? PrdProdVenDisc { get; set; }
        [Column("PRD_PROD_ESTIMATE")]
        public short? PrdProdEstimate { get; set; }
        [Column("PRD_PROD_TAX_CODE")]
        [StringLength(4)]
        public string PrdProdTaxCode { get; set; }
        [Column("PRD_PROD_COMMENTS", TypeName = "text")]
        public string PrdProdComments { get; set; }
        [Column("PRD_MEDIA_BCYCLE")]
        [StringLength(6)]
        public string PrdMediaBcycle { get; set; }
        [Column("PRD_RADIO_REBATE", TypeName = "decimal(7, 3)")]
        public decimal? PrdRadioRebate { get; set; }
        [Column("PRD_RADIO_BILL_NET")]
        public short? PrdRadioBillNet { get; set; }
        [Column("PRD_RADIO_VEN_DISC")]
        public short? PrdRadioVenDisc { get; set; }
        [Column("PRD_RADIO_COM_ONLY")]
        public short? PrdRadioComOnly { get; set; }
        [Column("PRD_RADIO_TAX_CODE")]
        [StringLength(4)]
        public string PrdRadioTaxCode { get; set; }
        [Column("PRD_RADIO_DAYS")]
        public short? PrdRadioDays { get; set; }
        [Column("PRD_RADIO_PRE_POST")]
        public short? PrdRadioPrePost { get; set; }
        [Column("PRD_RADIO_BF_AF")]
        public short? PrdRadioBfAf { get; set; }
        [Column("PRD_TV_REBATE", TypeName = "decimal(7, 3)")]
        public decimal? PrdTvRebate { get; set; }
        [Column("PRD_TV_BILL_NET")]
        public short? PrdTvBillNet { get; set; }
        [Column("PRD_TV_VEN_DISC")]
        public short? PrdTvVenDisc { get; set; }
        [Column("PRD_TV_COM_ONLY")]
        public short? PrdTvComOnly { get; set; }
        [Column("PRD_TV_TAX_CODE")]
        [StringLength(4)]
        public string PrdTvTaxCode { get; set; }
        [Column("PRD_TV_DAYS")]
        public short? PrdTvDays { get; set; }
        [Column("PRD_TV_PRE_POST")]
        public short? PrdTvPrePost { get; set; }
        [Column("PRD_TV_BF_AF")]
        public short? PrdTvBfAf { get; set; }
        [Column("PRD_MAG_REBATE", TypeName = "decimal(7, 3)")]
        public decimal? PrdMagRebate { get; set; }
        [Column("PRD_MAG_BILL_NET")]
        public short? PrdMagBillNet { get; set; }
        [Column("PRD_MAG_VEN_DISC")]
        public short? PrdMagVenDisc { get; set; }
        [Column("PRD_MAG_COM_ONLY")]
        public short? PrdMagComOnly { get; set; }
        [Column("PRD_MAG_TAX_CODE")]
        [StringLength(4)]
        public string PrdMagTaxCode { get; set; }
        [Column("PRD_MAG_DAYS")]
        public short? PrdMagDays { get; set; }
        [Column("PRD_MAG_PRE_POST")]
        public short? PrdMagPrePost { get; set; }
        [Column("PRD_MAG_BF_AF")]
        public short? PrdMagBfAf { get; set; }
        [Column("PRD_NEWS_COMM", TypeName = "decimal(7, 3)")]
        public decimal? PrdNewsComm { get; set; }
        [Column("PRD_NEWS_BILL_NET")]
        public short? PrdNewsBillNet { get; set; }
        [Column("PRD_NEWS_VEN_DISC")]
        public short? PrdNewsVenDisc { get; set; }
        [Column("PRD_NEWS_COM_ONLY")]
        public short? PrdNewsComOnly { get; set; }
        [Column("PRD_NEWS_TAX_CODE")]
        [StringLength(4)]
        public string PrdNewsTaxCode { get; set; }
        [Column("PRD_NEWS_DAYS")]
        public short? PrdNewsDays { get; set; }
        [Column("PRD_NEWS_PRE_POST")]
        public short? PrdNewsPrePost { get; set; }
        [Column("PRD_NEWS_BF_AF")]
        public short? PrdNewsBfAf { get; set; }
        [Column("PRD_RADIO_COMMENT", TypeName = "text")]
        public string PrdRadioComment { get; set; }
        [Column("PRD_SF_BEGIN_DATE", TypeName = "smalldatetime")]
        public DateTime? PrdSfBeginDate { get; set; }
        [Column("PRD_SF_NBR_OF_MTHS")]
        public short? PrdSfNbrOfMths { get; set; }
        [Column("PRD_SF_PER_GUARAN", TypeName = "decimal(15, 2)")]
        public decimal? PrdSfPerGuaran { get; set; }
        [Column("PRD_SF_RECON_CODE")]
        [StringLength(1)]
        public string PrdSfReconCode { get; set; }
        [Column("PRD_SF_BCYCLE")]
        [StringLength(6)]
        public string PrdSfBcycle { get; set; }
        [Column("PRD_SF_TAX_TIME")]
        public short? PrdSfTaxTime { get; set; }
        [Column("PRD_SF_EMP_TIME")]
        public short? PrdSfEmpTime { get; set; }
        [Column("PRD_SF_MEDIA_COMM")]
        public short? PrdSfMediaComm { get; set; }
        [Column("PRD_SF_PROD_COMM")]
        public short? PrdSfProdComm { get; set; }
        [Column("PRD_SF_AMT", TypeName = "decimal(15, 2)")]
        public decimal? PrdSfAmt { get; set; }
        [Column("PRD_TV_COMMENT", TypeName = "text")]
        public string PrdTvComment { get; set; }
        [Column("PRD_MAG_COMMENT", TypeName = "text")]
        public string PrdMagComment { get; set; }
        [Column("PRD_NEWS_COMMENT", TypeName = "text")]
        public string PrdNewsComment { get; set; }
        [Column("PRD_OTDR_COMMENT", TypeName = "text")]
        public string PrdOtdrComment { get; set; }
        [Column("PRD_MISC_COMMENT", TypeName = "text")]
        public string PrdMiscComment { get; set; }
        [Column("PRD_NEWS_REBATE", TypeName = "decimal(7, 3)")]
        public decimal? PrdNewsRebate { get; set; }
        [Column("PRD_OTDR_REBATE", TypeName = "decimal(7, 3)")]
        public decimal? PrdOtdrRebate { get; set; }
        [Column("PRD_MISC_REBATE", TypeName = "decimal(7, 3)")]
        public decimal? PrdMiscRebate { get; set; }
        [Column("PRD_RADIO_COMM", TypeName = "decimal(7, 3)")]
        public decimal? PrdRadioComm { get; set; }
        [Column("PRD_TV_COMM", TypeName = "decimal(7, 3)")]
        public decimal? PrdTvComm { get; set; }
        [Column("PRD_MAG_COMM", TypeName = "decimal(7, 3)")]
        public decimal? PrdMagComm { get; set; }
        [Column("PRD_OTDR_COMM", TypeName = "decimal(7, 3)")]
        public decimal? PrdOtdrComm { get; set; }
        [Column("PRD_MISC_COMM", TypeName = "decimal(7, 3)")]
        public decimal? PrdMiscComm { get; set; }
        [Column("PRD_OTDR_BF_AF")]
        public short? PrdOtdrBfAf { get; set; }
        [Column("PRD_OTDR_BILL_NET")]
        public short? PrdOtdrBillNet { get; set; }
        [Column("PRD_OTDR_COM_ONLY")]
        public short? PrdOtdrComOnly { get; set; }
        [Column("PRD_OTDR_DAYS")]
        public short? PrdOtdrDays { get; set; }
        [Column("PRD_OTDR_PRE_POST")]
        public short? PrdOtdrPrePost { get; set; }
        [Column("PRD_OTDR_TAX_CODE")]
        [StringLength(4)]
        public string PrdOtdrTaxCode { get; set; }
        [Column("PRD_OTDR_VEN_DISC")]
        public short? PrdOtdrVenDisc { get; set; }
        [Column("PRD_MISC_BF_AF")]
        public short? PrdMiscBfAf { get; set; }
        [Column("PRD_MISC_BILL_NET")]
        public short? PrdMiscBillNet { get; set; }
        [Column("PRD_MISC_COM_ONLY")]
        public short? PrdMiscComOnly { get; set; }
        [Column("PRD_MISC_DAYS")]
        public short? PrdMiscDays { get; set; }
        [Column("PRD_MISC_PRE_POST")]
        public short? PrdMiscPrePost { get; set; }
        [Column("PRD_MISC_TAX_CODE")]
        [StringLength(4)]
        public string PrdMiscTaxCode { get; set; }
        [Column("PRD_MISC_VEN_DISC")]
        public short? PrdMiscVenDisc { get; set; }
        [Column("EMAIL_GR_CODE")]
        [StringLength(50)]
        public string EmailGrCode { get; set; }
        [Column("TECHNOLOGY_FEE", TypeName = "decimal(7, 3)")]
        public decimal? TechnologyFee { get; set; }
        [Column("INACTIVE")]
        public short? Inactive { get; set; }
        [Column("ACTIVE_FLAG")]
        public short? ActiveFlag { get; set; }
        [Column("USER_DEFINED1")]
        [StringLength(50)]
        public string UserDefined1 { get; set; }
        [Column("USER_DEFINED2")]
        [StringLength(50)]
        public string UserDefined2 { get; set; }
        [Column("USER_DEFINED3")]
        [StringLength(50)]
        public string UserDefined3 { get; set; }
        [Column("USER_DEFINED4")]
        [StringLength(50)]
        public string UserDefined4 { get; set; }
        [Column("BILLED_TIME")]
        public short? BilledTime { get; set; }
        [Column("BILLED_MARKUP")]
        public short? BilledMarkup { get; set; }
        [Column("BILLED_COMM")]
        public short? BilledComm { get; set; }
        [Column("NEWSPAPER")]
        public short? Newspaper { get; set; }
        [Column("MAGAZINE")]
        public short? Magazine { get; set; }
        [Column("RADIO")]
        public short? Radio { get; set; }
        [Column("TELEVISION")]
        public short? Television { get; set; }
        [Column("OUTDOOR")]
        public short? Outdoor { get; set; }
        [Column("INTERNET")]
        public short? Internet { get; set; }
        [Column("USE_TAX_FLAGS_R")]
        public short? UseTaxFlagsR { get; set; }
        [Column("TAXAPPLYLN_R")]
        public short? TaxapplylnR { get; set; }
        [Column("TAXAPPLYND_R")]
        public short? TaxapplyndR { get; set; }
        [Column("TAXAPPLYNC_R")]
        public short? TaxapplyncR { get; set; }
        [Column("TAXAPPLYAI_R")]
        public short? TaxapplyaiR { get; set; }
        [Column("TAXAPPLYC_R")]
        public short? TaxapplycR { get; set; }
        [Column("TAXAPPLYR_R")]
        public short? TaxapplyrR { get; set; }
        [Column("USE_TAX_FLAGS_T")]
        public short? UseTaxFlagsT { get; set; }
        [Column("TAXAPPLYLN_T")]
        public short? TaxapplylnT { get; set; }
        [Column("TAXAPPLYND_T")]
        public short? TaxapplyndT { get; set; }
        [Column("TAXAPPLYNC_T")]
        public short? TaxapplyncT { get; set; }
        [Column("TAXAPPLYAI_T")]
        public short? TaxapplyaiT { get; set; }
        [Column("TAXAPPLYC_T")]
        public short? TaxapplycT { get; set; }
        [Column("TAXAPPLYR_T")]
        public short? TaxapplyrT { get; set; }
        [Column("USE_TAX_FLAGS_M")]
        public short? UseTaxFlagsM { get; set; }
        [Column("TAXAPPLYLN_M")]
        public short? TaxapplylnM { get; set; }
        [Column("TAXAPPLYND_M")]
        public short? TaxapplyndM { get; set; }
        [Column("TAXAPPLYNC_M")]
        public short? TaxapplyncM { get; set; }
        [Column("TAXAPPLYAI_M")]
        public short? TaxapplyaiM { get; set; }
        [Column("TAXAPPLYC_M")]
        public short? TaxapplycM { get; set; }
        [Column("TAXAPPLYR_M")]
        public short? TaxapplyrM { get; set; }
        [Column("USE_TAX_FLAGS_N")]
        public short? UseTaxFlagsN { get; set; }
        [Column("TAXAPPLYLN_N")]
        public short? TaxapplylnN { get; set; }
        [Column("TAXAPPLYND_N")]
        public short? TaxapplyndN { get; set; }
        [Column("TAXAPPLYNC_N")]
        public short? TaxapplyncN { get; set; }
        [Column("TAXAPPLYAI_N")]
        public short? TaxapplyaiN { get; set; }
        [Column("TAXAPPLYC_N")]
        public short? TaxapplycN { get; set; }
        [Column("TAXAPPLYR_N")]
        public short? TaxapplyrN { get; set; }
        [Column("USE_TAX_FLAGS_O")]
        public short? UseTaxFlagsO { get; set; }
        [Column("TAXAPPLYLN_O")]
        public short? TaxapplylnO { get; set; }
        [Column("TAXAPPLYND_O")]
        public short? TaxapplyndO { get; set; }
        [Column("TAXAPPLYNC_O")]
        public short? TaxapplyncO { get; set; }
        [Column("TAXAPPLYAI_O")]
        public short? TaxapplyaiO { get; set; }
        [Column("TAXAPPLYC_O")]
        public short? TaxapplycO { get; set; }
        [Column("TAXAPPLYR_O")]
        public short? TaxapplyrO { get; set; }
        [Column("USE_TAX_FLAGS_I")]
        public short? UseTaxFlagsI { get; set; }
        [Column("TAXAPPLYLN_I")]
        public short? TaxapplylnI { get; set; }
        [Column("TAXAPPLYND_I")]
        public short? TaxapplyndI { get; set; }
        [Column("TAXAPPLYNC_I")]
        public short? TaxapplyncI { get; set; }
        [Column("TAXAPPLYAI_I")]
        public short? TaxapplyaiI { get; set; }
        [Column("TAXAPPLYC_I")]
        public short? TaxapplycI { get; set; }
        [Column("TAXAPPLYR_I")]
        public short? TaxapplyrI { get; set; }
        [Column("PRD_BILL_RATE", TypeName = "decimal(9, 3)")]
        public decimal? PrdBillRate { get; set; }
        [Column("PRD_BILL_EMP_TIME")]
        public short? PrdBillEmpTime { get; set; }
        [Column("PROD_SETUP_COMPLETE")]
        public short? ProdSetupComplete { get; set; }
        [Column("RADIO_SETUP_COMPLETE")]
        public short? RadioSetupComplete { get; set; }
        [Column("TV_SETUP_COMPLETE")]
        public short? TvSetupComplete { get; set; }
        [Column("MAG_SETUP_COMPLETE")]
        public short? MagSetupComplete { get; set; }
        [Column("NEWS_SETUP_COMPLETE")]
        public short? NewsSetupComplete { get; set; }
        [Column("OOH_SETUP_COMPLETE")]
        public short? OohSetupComplete { get; set; }
        [Column("INET_SETUP_COMPLETE")]
        public short? InetSetupComplete { get; set; }
        [Column("USE_EST_BILL_RATE")]
        public short? UseEstBillRate { get; set; }
        [Column("CURRENCY_CODE")]
        [StringLength(5)]
        public string CurrencyCode { get; set; }
        [Column("BATCH_NAME")]
        [StringLength(50)]
        public string BatchName { get; set; }
        [Column("AVALARA_TAX_EXEMPT_OVERRIDE")]
        public bool AvalaraTaxExemptOverride { get; set; }
        [Column("PRD_PROD_PAYDAYS")]
        public short PrdProdPaydays { get; set; }
        [Column("CALC_LATE_FEE")]
        public bool CalcLateFee { get; set; }
        [Column("LATE_FEE_PERCENT", TypeName = "decimal(5, 2)")]
        public decimal? LateFeePercent { get; set; }

        [ForeignKey("ClCode,DivCode")]
        [InverseProperty("Products")]
        public virtual Division Division { get; set; }
        [ForeignKey(nameof(OfficeCode))]
        [InverseProperty(nameof(Office.Products))]
        public virtual Office OfficeCodeNavigation { get; set; }
        [InverseProperty(nameof(Job.Product))]
        public virtual ICollection<Job> JobLogs { get; set; }
        [InverseProperty(nameof(ProductDocument.Product))]
        public virtual ICollection<ProductDocument> ProductDocuments { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}