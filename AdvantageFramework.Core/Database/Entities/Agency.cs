using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("AGENCY")]
    public partial class Agency
    {

        #region Constants



        #endregion

        #region Enum
        public enum Properties
        {
            Name,
            Address1,
            Address2,
            City,
            State,
            Zip,
            Country,
            Phone,
            AutoEstRev,
            WipEmpCost,
            WipEmpNbcost,
            MagComment,
            NewsComment,
            OtdrComment,
            RadioComment,
            TvComment,
            MdInterface,
            MacExport,
            MdRename,
            AutoEmail,
            DeleteInvoice,
            WhVendor,
            ApVolumeDisc,
            Logo,
            BaseAmt,
            IndPct,
            IndWaiverPct,
            NonIPct,
            NonIWaiverPct,
            IncBillRate,
            FlagTaxJobs,
            ClientRef,
            CmpBudgetCode,
            QaPwdReq,
            EtBatch,
            CopyTs,
            ImportPath,
            CheckFormat,
            AspActive,
            DefEmailGroup,
            ValidateJobClose,
            TsDaysPerWk,
            TsAdminApprove,
            TsPperiodChk,
            EnableAttachments,
            CmpCodeR,
            AcctNbrR,
            JtCodeR,
            PromoCodeR,
            EditOffice,
            EmpNotes,
            LicenseKey,
            ApImportType,
            IoImportType,
            MrpDsn,
            PdfGenerator,
            JobFirstUseDtR,
            ComplexCodeR,
            FormatScCodeR,
            DpTmCodeR,
            MarketCodeR,
            EmailGrCodeR,
            BillCoopCodeR,
            AdNbrR,
            NobillFlagH,
            SpellLicKey,
            SmtpServer,
            SmtpSender,
            SmtpSenderPwd,
            CrArDesc,
            DefEstRpt,
            DefEstDtEnter,
            DefEstDtPrint,
            DefEstSuppress,
            DefEstIncCont,
            DefPoRpt,
            DefPoDtEnter,
            DefPoDtPrint,
            McUrl,
            McAcctId,
            ApOffice,
            InterCompany,
            Flag1099,
            ApPoMessage,
            ApPoReject,
            ApCalcPo,
            ApPoMessageText,
            ApPoRejectText,
            ApLockGlcode,
            VnAcctNbr,
            VnPayToInfo,
            GlFilter,
            JobCliRefR,
            JobDateOpenedR,
            JobAdSizeR,
            ProdContCodeR,
            JobCompBudgetR,
            AllowVnEmail,
            AllowClEmail,
            EmpOnAlertList,
            EmailUsername,
            EmailPwd,
            QvaQuery,
            BillSelectAlert,
            McActive,
            PendingTimeOff,
            StartEndTime,
            TimeApprActive,
            ApprEstReq,
            EditJobReqEst,
            InetComment,
            NonClientGlDet,
            StartDateR,
            EstComment,
            McAcctPwd,
            JobLogUdv1R,
            JobLogUdv2R,
            JobLogUdv3R,
            JobLogUdv4R,
            JobLogUdv5R,
            JobCmpUdv1R,
            JobCmpUdv2R,
            JobCmpUdv3R,
            JobCmpUdv4R,
            JobCmpUdv5R,
            MarCbActive,
            PoAmtReq,
            EditOtherTime,
            CurrencySymbol,
            CurrencyText,
            CoinText,
            TimeCommentsReq,
            UseSmtpForPdf,
            UseProdCat,
            PoFooter,
            StrataPath,
            TaxFlagR,
            ItContactEmail,
            EmailItContact,
            EmailSupervisor,
            WeeklyTime,
            DocRepositoryPath,
            DocRepositoryUserDomain,
            DocRepositoryUserName,
            DocRepositoryUserPassword,
            WordCheckAmt,
            BillMediaType,
            ChkStubLinesUp,
            ChkBodyLinesDn,
            ApAcctOffImp,
            FiscalPdR,
            BlackplateVerR,
            BlackplateVer2R,
            AccessRptPath,
            ContactOpt,
            ApApproval,
            ApAppPrintPct,
            ApAppInetPct,
            ApAppOohPct,
            PdfAlertOnly,
            AlertNotify,
            WebvantageUrl,
            TrTitle1,
            TrTitle2,
            TrTitle3,
            TrTitle4,
            TrTitle5,
            TrfHrs,
            TrfScheduleBy,
            TrfLockDate,
            TrfCalcByCmp,
            AutoAlertSuper,
            SmtpAuthMethod,
            SmtpPortNumber,
            EmailReplyTo,
            SmtpSecureType,
            MbKey,
            SmtpUseEmpLogin,
            SmtpUseEmpFrom,
            CrncyImportType,
            MultiCrncy,
            HomeCrncy,
            AccessTmpPath,
            EmailAttachDef,
            Pop3Server,
            Pop3PortNumber,
            Pop3Username,
            Pop3Pwd,
            Pop3DelProcessed,
            Pop3ReplyTo,
            Pop3AuthMethod,
            Pop3SecureType,
            ApAppTvPct,
            ApAppRadioPct,
            ServiceFeeTypeR,
            County,
            CosEntryFlag,
            InvTaxFlag,
            DbTimezoneId,
            TimezoneId,
            EditCdp,
            TsCopyHrs,
            ClientportalUrl,
            DbCultureCode,
            CultureCode,
            TimeReqAssn,
            TimeUniqueRow,
            AllowProofhq,
            ProofingURL
        }

        #endregion

        #region Variables



        #endregion

        #region Properties

        [Column("NAME")]
        [StringLength(40)]
        public string Name { get; set; }
        [Column("ADDRESS1")]
        [StringLength(40)]
        public string Address1 { get; set; }
        [Column("ADDRESS2")]
        [StringLength(40)]
        public string Address2 { get; set; }
        [Column("CITY")]
        [StringLength(20)]
        public string City { get; set; }
        [Column("STATE")]
        [StringLength(10)]
        public string State { get; set; }
        [Column("ZIP")]
        [StringLength(10)]
        public string Zip { get; set; }
        [Column("COUNTRY")]
        [StringLength(10)]
        public string Country { get; set; }
        [Column("PHONE")]
        [StringLength(13)]
        public string Phone { get; set; }
        [Column("AUTO_EST_REV")]
        public short? AutoEstRev { get; set; }
        [Column("WIP_EMP_COST")]
        public short? WipEmpCost { get; set; }
        [Column("WIP_EMP_NBCOST")]
        public short? WipEmpNbcost { get; set; }
        [Column("MAG_COMMENT", TypeName = "text")]
        public string MagComment { get; set; }
        [Column("NEWS_COMMENT", TypeName = "text")]
        public string NewsComment { get; set; }
        [Column("OTDR_COMMENT", TypeName = "text")]
        public string OtdrComment { get; set; }
        [Column("RADIO_COMMENT", TypeName = "text")]
        public string RadioComment { get; set; }
        [Column("TV_COMMENT", TypeName = "text")]
        public string TvComment { get; set; }
        [Column("MD_INTERFACE")]
        [StringLength(2)]
        public string MdInterface { get; set; }
        [Column("MAC_EXPORT")]
        [StringLength(2)]
        public string MacExport { get; set; }
        [Column("MD_RENAME")]
        public short? MdRename { get; set; }
        [Column("AUTO_EMAIL")]
        public short? AutoEmail { get; set; }
        [Column("DELETE_INVOICE")]
        public short? DeleteInvoice { get; set; }
        [Column("WH_VENDOR")]
        public short? WhVendor { get; set; }
        [Column("AP_VOLUME_DISC")]
        public short? ApVolumeDisc { get; set; }
        [Column("LOGO")]
        [StringLength(254)]
        public string Logo { get; set; }
        [Column("BASE_AMT", TypeName = "decimal(14, 2)")]
        public decimal? BaseAmt { get; set; }
        [Column("IND_PCT", TypeName = "decimal(6, 3)")]
        public decimal? IndPct { get; set; }
        [Column("IND_WAIVER_PCT", TypeName = "decimal(6, 3)")]
        public decimal? IndWaiverPct { get; set; }
        [Column("NON_I_PCT", TypeName = "decimal(6, 3)")]
        public decimal? NonIPct { get; set; }
        [Column("NON_I_WAIVER_PCT", TypeName = "decimal(6, 3)")]
        public decimal? NonIWaiverPct { get; set; }
        [Column("INC_BILL_RATE")]
        public short? IncBillRate { get; set; }
        [Column("FLAG_TAX_JOBS")]
        public short? FlagTaxJobs { get; set; }
        [Column("CLIENT_REF")]
        public short? ClientRef { get; set; }
        [Column("CMP_BUDGET_CODE")]
        public short? CmpBudgetCode { get; set; }
        [Column("QA_PWD_REQ")]
        public short? QaPwdReq { get; set; }
        [Column("ET_BATCH")]
        public short? EtBatch { get; set; }
        [Column("COPY_TS")]
        public short? CopyTs { get; set; }
        [Column("IMPORT_PATH")]
        [StringLength(254)]
        public string ImportPath { get; set; }
        [Column("CHECK_FORMAT")]
        public short? CheckFormat { get; set; }
        [Column("ASP_ACTIVE")]
        public short? AspActive { get; set; }
        [Column("DEF_EMAIL_GROUP")]
        [StringLength(50)]
        public string DefEmailGroup { get; set; }
        [Column("VALIDATE_JOB_CLOSE")]
        public short? ValidateJobClose { get; set; }
        [Column("TS_DAYS_PER_WK")]
        public short? TsDaysPerWk { get; set; }
        [Column("TS_ADMIN_APPROVE")]
        public short? TsAdminApprove { get; set; }
        [Column("TS_PPERIOD_CHK")]
        public short? TsPperiodChk { get; set; }
        [Column("ENABLE_ATTACHMENTS")]
        public short? EnableAttachments { get; set; }
        [Column("CMP_CODE_R")]
        public short? CmpCodeR { get; set; }
        [Column("ACCT_NBR_R")]
        public short? AcctNbrR { get; set; }
        [Column("JT_CODE_R")]
        public short? JtCodeR { get; set; }
        [Column("PROMO_CODE_R")]
        public short? PromoCodeR { get; set; }
        [Column("EDIT_OFFICE")]
        public short? EditOffice { get; set; }
        [Column("EMP_NOTES")]
        public short EmpNotes { get; set; }
        [Column("LICENSE_KEY")]
        [StringLength(8000)]
        public string LicenseKey { get; set; }
        [Column("AP_IMPORT_TYPE")]
        [StringLength(15)]
        public string ApImportType { get; set; }
        [Column("IO_IMPORT_TYPE")]
        [StringLength(15)]
        public string IoImportType { get; set; }
        [Column("MRP_DSN")]
        [StringLength(32)]
        public string MrpDsn { get; set; }
        [Column("PDF_GENERATOR")]
        [StringLength(20)]
        public string PdfGenerator { get; set; }
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
        [Column("NOBILL_FLAG_H")]
        public short? NobillFlagH { get; set; }
        [Column("SPELL_LIC_KEY")]
        public double? SpellLicKey { get; set; }
        [Column("SMTP_SERVER")]
        [StringLength(50)]
        public string SmtpServer { get; set; }
        [Column("SMTP_SENDER")]
        [StringLength(100)]
        public string SmtpSender { get; set; }
        [Column("SMTP_SENDER_PWD")]
        [StringLength(100)]
        public string SmtpSenderPwd { get; set; }
        [Column("CR_AR_DESC")]
        public short? CrArDesc { get; set; }
        [Column("DEF_EST_RPT")]
        [StringLength(40)]
        public string DefEstRpt { get; set; }
        [Column("DEF_EST_DT_ENTER")]
        public short? DefEstDtEnter { get; set; }
        [Column("DEF_EST_DT_PRINT")]
        public short? DefEstDtPrint { get; set; }
        [Column("DEF_EST_SUPPRESS")]
        public short? DefEstSuppress { get; set; }
        [Column("DEF_EST_INC_CONT")]
        public short? DefEstIncCont { get; set; }
        [Column("DEF_PO_RPT")]
        [StringLength(40)]
        public string DefPoRpt { get; set; }
        [Column("DEF_PO_DT_ENTER")]
        public short? DefPoDtEnter { get; set; }
        [Column("DEF_PO_DT_PRINT")]
        public short? DefPoDtPrint { get; set; }
        [Column("MC_URL")]
        [StringLength(254)]
        public string McUrl { get; set; }
        [Column("MC_ACCT_ID")]
        public int? McAcctId { get; set; }
        [Column("AP_OFFICE")]
        public short? ApOffice { get; set; }
        [Column("INTER_COMPANY")]
        public short? InterCompany { get; set; }
        [Column("FLAG_1099")]
        public short? Flag1099 { get; set; }
        [Column("AP_PO_MESSAGE")]
        public short? ApPoMessage { get; set; }
        [Column("AP_PO_REJECT")]
        public short? ApPoReject { get; set; }
        [Column("AP_CALC_PO")]
        public short? ApCalcPo { get; set; }
        [Column("AP_PO_MESSAGE_TEXT")]
        [StringLength(150)]
        public string ApPoMessageText { get; set; }
        [Column("AP_PO_REJECT_TEXT")]
        [StringLength(150)]
        public string ApPoRejectText { get; set; }
        [Column("AP_LOCK_GLCODE")]
        public short? ApLockGlcode { get; set; }
        [Column("VN_ACCT_NBR")]
        public short? VnAcctNbr { get; set; }
        [Column("VN_PAY_TO_INFO")]
        public short? VnPayToInfo { get; set; }
        [Column("GL_FILTER")]
        public short? GlFilter { get; set; }
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
        [Column("ALLOW_VN_EMAIL")]
        public short? AllowVnEmail { get; set; }
        [Column("ALLOW_CL_EMAIL")]
        public short? AllowClEmail { get; set; }
        [Column("EMP_ON_ALERT_LIST")]
        public short? EmpOnAlertList { get; set; }
        [Column("EMAIL_USERNAME")]
        [StringLength(100)]
        public string EmailUsername { get; set; }
        [Column("EMAIL_PWD")]
        public string EmailPwd { get; set; }
        [Column("QVA_QUERY")]
        public short? QvaQuery { get; set; }
        [Column("BILL_SELECT_ALERT")]
        public short? BillSelectAlert { get; set; }
        [Column("MC_ACTIVE")]
        public short? McActive { get; set; }
        [Column("PENDING_TIME_OFF")]
        public short? PendingTimeOff { get; set; }
        [Column("START_END_TIME")]
        public short? StartEndTime { get; set; }
        [Column("TIME_APPR_ACTIVE")]
        public short? TimeApprActive { get; set; }
        [Column("APPR_EST_REQ")]
        public short? ApprEstReq { get; set; }
        [Column("EDIT_JOB_REQ_EST")]
        public short? EditJobReqEst { get; set; }
        [Column("INET_COMMENT", TypeName = "text")]
        public string InetComment { get; set; }
        [Column("NON_CLIENT_GL_DET")]
        public short? NonClientGlDet { get; set; }
        [Column("START_DATE_R")]
        public short? StartDateR { get; set; }
        [Column("EST_COMMENT", TypeName = "text")]
        public string EstComment { get; set; }
        [Column("MC_ACCT_PWD")]
        [StringLength(50)]
        public string McAcctPwd { get; set; }
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
        [Column("MAR_CB_ACTIVE")]
        public short? MarCbActive { get; set; }
        [Column("PO_AMT_REQ")]
        public short? PoAmtReq { get; set; }
        [Column("EDIT_OTHER_TIME")]
        public short? EditOtherTime { get; set; }
        [Column("CURRENCY_SYMBOL")]
        [StringLength(3)]
        public string CurrencySymbol { get; set; }
        [Column("CURRENCY_TEXT")]
        [StringLength(20)]
        public string CurrencyText { get; set; }
        [Column("COIN_TEXT")]
        [StringLength(20)]
        public string CoinText { get; set; }
        [Column("TIME_COMMENTS_REQ")]
        public short? TimeCommentsReq { get; set; }
        [Column("USE_SMTP_FOR_PDF")]
        public short? UseSmtpForPdf { get; set; }
        [Column("USE_PROD_CAT")]
        public short? UseProdCat { get; set; }
        [Column("PO_FOOTER", TypeName = "text")]
        public string PoFooter { get; set; }
        [Column("STRATA_PATH")]
        [StringLength(254)]
        public string StrataPath { get; set; }
        [Column("TAX_FLAG_R")]
        public short? TaxFlagR { get; set; }
        [Column("IT_CONTACT_EMAIL")]
        [StringLength(50)]
        public string ItContactEmail { get; set; }
        [Column("EMAIL_IT_CONTACT")]
        public short? EmailItContact { get; set; }
        [Column("EMAIL_SUPERVISOR")]
        public short? EmailSupervisor { get; set; }
        [Column("WEEKLY_TIME")]
        public short? WeeklyTime { get; set; }
        [Column("DOC_REPOSITORY_PATH")]
        [StringLength(100)]
        public string DocRepositoryPath { get; set; }
        [Column("DOC_REPOSITORY_USER_DOMAIN")]
        [StringLength(30)]
        public string DocRepositoryUserDomain { get; set; }
        [Column("DOC_REPOSITORY_USER_NAME")]
        [StringLength(50)]
        public string DocRepositoryUserName { get; set; }
        [Column("DOC_REPOSITORY_USER_PASSWORD")]
        [StringLength(50)]
        public string DocRepositoryUserPassword { get; set; }
        [Column("WORD_CHECK_AMT")]
        public short? WordCheckAmt { get; set; }
        [Column("BILL_MEDIA_TYPE")]
        public short? BillMediaType { get; set; }
        [Column("CHK_STUB_LINES_UP")]
        public short? ChkStubLinesUp { get; set; }
        [Column("CHK_BODY_LINES_DN")]
        public short? ChkBodyLinesDn { get; set; }
        [Column("AP_ACCT_OFF_IMP")]
        public short? ApAcctOffImp { get; set; }
        [Column("FISCAL_PD_R")]
        public short? FiscalPdR { get; set; }
        [Column("BLACKPLATE_VER_R")]
        public short? BlackplateVerR { get; set; }
        [Column("BLACKPLATE_VER2_R")]
        public short? BlackplateVer2R { get; set; }
        [Column("ACCESS_RPT_PATH")]
        [StringLength(254)]
        public string AccessRptPath { get; set; }
        [Column("CONTACT_OPT")]
        public short? ContactOpt { get; set; }
        [Column("AP_APPROVAL")]
        public short? ApApproval { get; set; }
        [Column("AP_APP_PRINT_PCT", TypeName = "decimal(6, 3)")]
        public decimal? ApAppPrintPct { get; set; }
        [Column("AP_APP_INET_PCT", TypeName = "decimal(6, 3)")]
        public decimal? ApAppInetPct { get; set; }
        [Column("AP_APP_OOH_PCT", TypeName = "decimal(6, 3)")]
        public decimal? ApAppOohPct { get; set; }
        [Column("PDF_ALERT_ONLY")]
        public short? PdfAlertOnly { get; set; }
        [Column("ALERT_NOTIFY")]
        public short? AlertNotify { get; set; }
        [Column("WEBVANTAGE_URL")]
        [StringLength(254)]
        public string WebvantageUrl { get; set; }
        [Column("TR_TITLE1")]
        [StringLength(20)]
        public string TrTitle1 { get; set; }
        [Column("TR_TITLE2")]
        [StringLength(20)]
        public string TrTitle2 { get; set; }
        [Column("TR_TITLE3")]
        [StringLength(20)]
        public string TrTitle3 { get; set; }
        [Column("TR_TITLE4")]
        [StringLength(20)]
        public string TrTitle4 { get; set; }
        [Column("TR_TITLE5")]
        [StringLength(20)]
        public string TrTitle5 { get; set; }
        [Column("TRF_HRS", TypeName = "decimal(9, 3)")]
        public decimal? TrfHrs { get; set; }
        [Column("TRF_SCHEDULE_BY")]
        public short? TrfScheduleBy { get; set; }
        [Column("TRF_LOCK_DATE")]
        public short? TrfLockDate { get; set; }
        [Column("TRF_CALC_BY_CMP")]
        public short? TrfCalcByCmp { get; set; }
        [Column("AUTO_ALERT_SUPER")]
        public short? AutoAlertSuper { get; set; }
        [Column("SMTP_AUTH_METHOD")]
        public short? SmtpAuthMethod { get; set; }
        [Column("SMTP_PORT_NUMBER")]
        public short? SmtpPortNumber { get; set; }
        [Column("EMAIL_REPLY_TO")]
        [StringLength(50)]
        public string EmailReplyTo { get; set; }
        [Column("SMTP_SECURE_TYPE")]
        public short? SmtpSecureType { get; set; }
        [Column("MB_KEY")]
        [StringLength(100)]
        public string MbKey { get; set; }
        [Column("SMTP_USE_EMP_LOGIN")]
        public short? SmtpUseEmpLogin { get; set; }
        [Column("SMTP_USE_EMP_FROM")]
        public short? SmtpUseEmpFrom { get; set; }
        [Column("CRNCY_IMPORT_TYPE")]
        [StringLength(15)]
        public string CrncyImportType { get; set; }
        [Column("MULTI_CRNCY")]
        public short? MultiCrncy { get; set; }
        [Column("HOME_CRNCY")]
        [StringLength(5)]
        public string HomeCrncy { get; set; }
        [Column("ACCESS_TMP_PATH")]
        [StringLength(254)]
        public string AccessTmpPath { get; set; }
        [Column("EMAIL_ATTACH_DEF")]
        public short? EmailAttachDef { get; set; }
        [Column("POP3_SERVER")]
        [StringLength(40)]
        public string Pop3Server { get; set; }
        [Column("POP3_PORT_NUMBER")]
        public short? Pop3PortNumber { get; set; }
        [Column("POP3_USERNAME")]
        [StringLength(100)]
        public string Pop3Username { get; set; }
        [Column("POP3_PWD")]
        public string Pop3Pwd { get; set; }
        [Column("POP3_DEL_PROCESSED")]
        public short? Pop3DelProcessed { get; set; }
        [Column("POP3_REPLY_TO")]
        [StringLength(50)]
        public string Pop3ReplyTo { get; set; }
        [Column("POP3_AUTH_METHOD")]
        public short? Pop3AuthMethod { get; set; }
        [Column("POP3_SECURE_TYPE")]
        public short? Pop3SecureType { get; set; }
        [Column("AP_APP_TV_PCT", TypeName = "decimal(6, 3)")]
        public decimal? ApAppTvPct { get; set; }
        [Column("AP_APP_RADIO_PCT", TypeName = "decimal(6, 3)")]
        public decimal? ApAppRadioPct { get; set; }
        [Column("SERVICE_FEE_TYPE_R")]
        public short? ServiceFeeTypeR { get; set; }
        [Column("COUNTY")]
        [StringLength(20)]
        public string County { get; set; }
        [Column("COS_ENTRY_FLAG")]
        public short CosEntryFlag { get; set; }
        [Column("INV_TAX_FLAG")]
        public bool InvTaxFlag { get; set; }
        [Column("DB_TIMEZONE_ID")]
        [StringLength(256)]
        public string DbTimezoneId { get; set; }
        [Column("TIMEZONE_ID")]
        [StringLength(256)]
        public string TimezoneId { get; set; }
        [Column("EDIT_CDP")]
        public short? EditCdp { get; set; }
        [Column("TS_COPY_HRS")]
        public bool? TsCopyHrs { get; set; }
        [Column("CLIENTPORTAL_URL")]
        [StringLength(254)]
        public string ClientportalUrl { get; set; }
        [Column("DB_CULTURE_CODE")]
        [StringLength(10)]
        public string DbCultureCode { get; set; }
        [Column("CULTURE_CODE")]
        [StringLength(10)]
        public string CultureCode { get; set; }
        [Column("TIME_REQ_ASSN")]
        public bool? TimeReqAssn { get; set; }
        [Column("TIME_UNIQUE_ROW")]
        public bool? TimeUniqueRow { get; set; }
        [Column("ALLOW_PROOFHQ")]
        public bool? AllowProofhq { get; set; }
        [Column("PROOFING_URL")]
        [StringLength(254)]
        public string ProofingURL { get; set; }

        #endregion

        #region Methods



        #endregion

    }
}
