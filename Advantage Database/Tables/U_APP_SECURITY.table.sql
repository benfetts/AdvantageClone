﻿CREATE TABLE [dbo].[U_APP_SECURITY] (
    [USER_CODE]            VARCHAR (100) NOT NULL,
    [EMP_CODE]             VARCHAR (6)   NULL,
    [USER_NAME]            VARCHAR (30)  NULL,
    [MENU_MAINT]           VARCHAR (1)   NULL,
    [MENU_PROD]            VARCHAR (1)   NULL,
    [MENU_MEDIA]           VARCHAR (1)   NULL,
    [MENU_ACCT]            VARCHAR (1)   NULL,
    [MENU_BILL]            VARCHAR (1)   NULL,
    [MENU_GL]              VARCHAR (1)   NULL,
    [MENU_MNGREP]          VARCHAR (1)   NULL,
    [MENU_HK]              VARCHAR (1)   NULL,
    [AC_ACCT_PAYABLE]      VARCHAR (1)   NULL,
    [AC_MAN_CHECK]         VARCHAR (1)   NULL,
    [AC_BANK_REC]          VARCHAR (1)   NULL,
    [AC_BILL_DATES]        VARCHAR (1)   NULL,
    [AC_COMP_CHECK]        VARCHAR (1)   NULL,
    [AC_CLI_OOP]           VARCHAR (1)   NULL,
    [AC_REC_PAYMENT]       VARCHAR (1)   NULL,
    [AC_INCOME_ONLY]       VARCHAR (1)   NULL,
    [AC_TIME_ENTRY]        VARCHAR (1)   NULL,
    [AC_MAN_INVOICE]       VARCHAR (1)   NULL,
    [AC_CLI_RECEIPTS]      VARCHAR (1)   NULL,
    [AC_OTH_RECEIPTS]      VARCHAR (1)   NULL,
    [AC_REPORT]            VARCHAR (1)   NULL,
    [AC_JOB_CONTROL]       VARCHAR (1)   NULL,
    [AC_PO]                VARCHAR (1)   NULL,
    [AC_QUERY]             VARCHAR (1)   NULL,
    [AC_VOID_CHECK]        VARCHAR (1)   NULL,
    [AC_VOID_INVOICE]      VARCHAR (1)   NULL,
    [AC_CREDIT_MEMO]       VARCHAR (1)   NULL,
    [AC_VENDOR]            VARCHAR (1)   NULL,
    [AC_VEN_CONTACT]       VARCHAR (1)   NULL,
    [AC_VEN_TERMS]         VARCHAR (1)   NULL,
    [BL_REPORT]            VARCHAR (1)   NULL,
    [BL_RELEASE_BH]        VARCHAR (1)   NULL,
    [BL_ADVANCE]           VARCHAR (1)   NULL,
    [BL_APPROVAL]          VARCHAR (1)   NULL,
    [BL_SELECTION]         VARCHAR (1)   NULL,
    [BL_REPRINT]           VARCHAR (1)   NULL,
    [BL_QUOTE_APPR]        VARCHAR (1)   NULL,
    [BL_INV_TEMPLATE]      VARCHAR (1)   NULL,
    [MD_CAMPAIGN]          VARCHAR (1)   NULL,
    [MD_JOB]               VARCHAR (1)   NULL,
    [MD_MAG_ORDER]         VARCHAR (1)   NULL,
    [MD_MARKET]            VARCHAR (1)   NULL,
    [MD_MISC_ORDER]        VARCHAR (1)   NULL,
    [MD_NEWS_ORDER]        VARCHAR (1)   NULL,
    [MD_OUTDOOR_ORDER]     VARCHAR (1)   NULL,
    [MD_QUERY]             VARCHAR (1)   NULL,
    [MD_REPORT]            VARCHAR (1)   NULL,
    [MD_TIME_ENTRY]        VARCHAR (1)   NULL,
    [MD_VENDOR]            VARCHAR (1)   NULL,
    [MD_VEN_CONTACT]       VARCHAR (1)   NULL,
    [MD_VEN_REP]           VARCHAR (1)   NULL,
    [MD_VEN_TERMS]         VARCHAR (1)   NULL,
    [MD_BRDCAST_ORDER]     SMALLINT      NULL,
    [MD_INTERFACE]         SMALLINT      NULL,
    [MD_ORD_CONTROL]       SMALLINT      NULL,
    [MN_ADMIN]             VARCHAR (1)   NULL,
    [MN_AGENCY]            VARCHAR (1)   NULL,
    [MN_BANK]              VARCHAR (1)   NULL,
    [MN_DEPARTMENT]        VARCHAR (1)   NULL,
    [MN_CATEGORY]          VARCHAR (1)   NULL,
    [MN_COMPLEXITY]        VARCHAR (1)   NULL,
    [MN_EMP_TS]            VARCHAR (1)   NULL,
    [MN_FUNCTION]          VARCHAR (1)   NULL,
    [MN_PRD_RATES]         VARCHAR (1)   NULL,
    [MN_PROMOTION]         VARCHAR (1)   NULL,
    [MN_SALES_TAX]         VARCHAR (1)   NULL,
    [MN_SALES_CLASS]       VARCHAR (1)   NULL,
    [MN_SCFORMAT]          VARCHAR (1)   NULL,
    [MN_TRAF_FUNCTION]     VARCHAR (1)   NULL,
    [MN_TRAF_STATUS]       VARCHAR (1)   NULL,
    [MN_VEN_TERMS]         VARCHAR (1)   NULL,
    [MN_OFFICE]            VARCHAR (1)   NULL,
    [MN_REPORT]            VARCHAR (1)   NULL,
    [MN_CLIENT]            VARCHAR (1)   NULL,
    [MN_DIVISION]          VARCHAR (1)   NULL,
    [MN_PRODUCT]           VARCHAR (1)   NULL,
    [MN_EMPLOYEE]          VARCHAR (1)   NULL,
    [MN_FREELANCE]         VARCHAR (1)   NULL,
    [MN_VENDOR]            VARCHAR (1)   NULL,
    [MN_PRD_AE]            VARCHAR (1)   NULL,
    [MN_APPR_PASSWORD]     VARCHAR (1)   NULL,
    [MN_ADJ_PASSWORD]      VARCHAR (1)   NULL,
    [MN_EST_PF]            VARCHAR (1)   NULL,
    [MN_TRAF_PF]           VARCHAR (1)   NULL,
    [MN_CLI_CONTACT]       VARCHAR (1)   NULL,
    [MN_DIV_CONTACT]       VARCHAR (1)   NULL,
    [MN_MAC_INTFC]         VARCHAR (1)   NULL,
    [MN_PRD_CONTACT]       VARCHAR (1)   NULL,
    [MN_PRD_SLS_TEAM]      VARCHAR (1)   NULL,
    [MN_PRD_FUNCTION]      VARCHAR (1)   NULL,
    [MN_EMP_FUNCTION]      VARCHAR (1)   NULL,
    [MN_VEN_CONTACT]       VARCHAR (1)   NULL,
    [MN_VEN_REP]           VARCHAR (1)   NULL,
    [MN_QUERY]             VARCHAR (1)   NULL,
    [MN_MARKET]            VARCHAR (1)   NULL,
    [MN_INV_SEL]           VARCHAR (1)   NULL,
    [MN_RPT_SEL]           VARCHAR (1)   NULL,
    [PR_CAMPAIGN]          VARCHAR (1)   NULL,
    [PR_JOB]               VARCHAR (1)   NULL,
    [PR_JOB_SLS_TEAM]      VARCHAR (1)   NULL,
    [PR_TRAFFIC]           VARCHAR (1)   NULL,
    [PR_ESTIMATE]          VARCHAR (1)   NULL,
    [PR_QUOTE_APPR]        VARCHAR (1)   NULL,
    [PR_PO]                VARCHAR (1)   NULL,
    [PR_TIME_ENTRY]        VARCHAR (1)   NULL,
    [PR_REPORT]            VARCHAR (1)   NULL,
    [PR_QUERY]             VARCHAR (1)   NULL,
    [PR_EMP_FUNCTION]      VARCHAR (1)   NULL,
    [PR_EST_PF]            VARCHAR (1)   NULL,
    [PR_FUNCTION]          VARCHAR (1)   NULL,
    [PR_PRD_AE]            VARCHAR (1)   NULL,
    [PR_PRD_FUNCTION]      VARCHAR (1)   NULL,
    [PR_TRAF_FUNCTION]     VARCHAR (1)   NULL,
    [PR_TRAF_PF]           VARCHAR (1)   NULL,
    [PR_TRAF_STATUS]       VARCHAR (1)   NULL,
    [PR_VENDOR]            VARCHAR (1)   NULL,
    [PR_VEN_CONTACT]       VARCHAR (1)   NULL,
    [PR_VEN_TERMS]         VARCHAR (1)   NULL,
    [HK_REORG]             VARCHAR (1)   NULL,
    [HK_STATS]             VARCHAR (1)   NULL,
    [MR_OHSETUP]           VARCHAR (1)   NULL,
    [MR_AGYCLI]            VARCHAR (1)   NULL,
    [MR_RPTS]              VARCHAR (1)   NULL,
    [MR_TEMPLATE]          VARCHAR (1)   NULL,
    [MR_INFO]              VARCHAR (1)   NULL,
    [MN_BILL_COOP]         VARCHAR (1)   NULL,
    [BL_BILL_COOP]         VARCHAR (1)   NULL,
    [MN_JOB_TYPE]          VARCHAR (1)   NULL,
    [HK_ARCHIVE]           VARCHAR (1)   NULL,
    [HK_CHECKDB]           VARCHAR (1)   NULL,
    [HK_ARCHIVE_DB]        VARCHAR (1)   NULL,
    [SI_MARKUP_TAX]        VARCHAR (1)   NULL,
    [SI_DO_OWN_TS]         VARCHAR (1)   NULL,
    [MN_PRD_EMP_FNC]       VARCHAR (1)   NULL,
    [MN_PRD_EMP_RATE]      VARCHAR (1)   NULL,
    [MN_EMAIL_GROUP]       VARCHAR (1)   NULL,
    [EMP_TS_FNC]           VARCHAR (1)   NULL,
    [ADASSIST_PASSWORD]    VARCHAR (10)  NULL,
    [BL_CHANGE_ET]         VARCHAR (1)   NULL,
    [MN_DBA]               VARCHAR (1)   NULL,
    [MN_AD_NBR]            VARCHAR (1)   NULL,
    [MN_ACCT_NBR]          VARCHAR (1)   NULL,
    [MN_QTE_APP_PWD]       VARCHAR (1)   NULL,
    [AC_POST_ET]           VARCHAR (1)   NULL,
    [MN_BUDGET_CAT]        VARCHAR (1)   NULL,
    [MN_STATUS]            VARCHAR (1)   NULL,
    [MN_REGION]            VARCHAR (1)   NULL,
    [MD_PRINT_IMPORT]      VARCHAR (1)   NULL,
    [MD_LOADATA]           VARCHAR (1)   NULL,
    [MD_ADTIMES]           VARCHAR (1)   NULL,
    [AC_APIMPORT]          VARCHAR (1)   NULL,
    [MN_EMAIL_SETUP]       VARCHAR (1)   NULL,
    [MD_CUSTTECH]          VARCHAR (1)   NULL,
    [PR_CUSTTECH]          VARCHAR (1)   NULL,
    [AC_CUSTTECH]          VARCHAR (1)   NULL,
    [BL_CUSTTECH]          VARCHAR (1)   NULL,
    [GROUP_CODE]           VARCHAR (100) NULL,
    [GROUP_IND]            SMALLINT      NULL,
    [TS_ADMIN_LVL]         SMALLINT      NULL,
    [AC_CHKIMPORT]         VARCHAR (1)   NULL,
    [MN_SC_FNC]            VARCHAR (1)   NULL,
    [MD_NFUSION]           VARCHAR (1)   NULL,
    [AC_TIMEPORT]          VARCHAR (1)   NULL,
    [AC_IO_IMPORT]         VARCHAR (1)   NULL,
    [MD_DEL_NOBILL]        VARCHAR (1)   NULL,
    [HK_VN_MERGE]          VARCHAR (1)   NULL,
    [HK_BILL_MAINT]        VARCHAR (1)   NULL,
    [HK_PO_MAINT]          VARCHAR (1)   NULL,
    [HK_BRD_AUTO_CL]       VARCHAR (1)   NULL,
    [PR_VAC_SIC_QRY]       VARCHAR (1)   NULL,
    [PR_OPEN_JOB_QRY]      VARCHAR (1)   NULL,
    [AC_VAC_SIC_QRY]       VARCHAR (1)   NULL,
    [TIME_ENTRY_ONLY]      SMALLINT      NULL,
    [BL_ADJUST]            VARCHAR (1)   NULL,
    [AC_ARIMPORT]          VARCHAR (1)   NULL,
    [AC_SERVICE_FEE]       VARCHAR (1)   NULL,
    [PR_EMP_CAL]           VARCHAR (1)   NULL,
    [AC_RECUR_AP]          VARCHAR (1)   NULL,
    [AC_RECUR_AP_POST]     VARCHAR (1)   NULL,
    [MD_INET_ORDER]        VARCHAR (1)   NULL,
    [PR_CRTV_BRF]          VARCHAR (1)   NULL,
    [PR_JOB_SPECS]         VARCHAR (1)   NULL,
    [MN_TRF_ROLE]          VARCHAR (1)   NULL,
    [MN_TRF_PHASE]         VARCHAR (1)   NULL,
    [PR_TRF_EDIT]          VARCHAR (1)   NULL,
    [AC_CHK_EXPORT]        VARCHAR (1)   NULL,
    [MN_SPECS]             VARCHAR (1)   NULL,
    [MN_CRTV_BRF]          VARCHAR (1)   NULL,
    [PR_TIME_APPR]         VARCHAR (1)   NULL,
    [MENU_HWND]            INT           NULL,
    [PR_QVA_QUERY]         VARCHAR (1)   NULL,
    [MN_FNC_HEADING]       VARCHAR (1)   NULL,
    [WEB_ID]               VARCHAR (255) NULL,
    [MN_VN_PRICE]          VARCHAR (1)   NULL,
    [MN_LOCATION]          VARCHAR (1)   NULL,
    [MN_OOH_TYPE]          VARCHAR (1)   NULL,
    [MN_OOH_SIZE]          VARCHAR (1)   NULL,
    [MN_INT_TYPE]          VARCHAR (1)   NULL,
    [PR_EST_IMPORT]        VARCHAR (1)   NULL,
    [MN_JL_UDV1]           VARCHAR (1)   NULL,
    [MN_JL_UDV2]           VARCHAR (1)   NULL,
    [MN_JL_UDV3]           VARCHAR (1)   NULL,
    [MN_JL_UDV4]           VARCHAR (1)   NULL,
    [MN_JL_UDV5]           VARCHAR (1)   NULL,
    [MN_JC_UDV1]           VARCHAR (1)   NULL,
    [MN_JC_UDV2]           VARCHAR (1)   NULL,
    [MN_JC_UDV3]           VARCHAR (1)   NULL,
    [MN_JC_UDV4]           VARCHAR (1)   NULL,
    [MN_JC_UDV5]           VARCHAR (1)   NULL,
    [MN_RATE_CARD]         VARCHAR (1)   NULL,
    [MN_AUTO_AR_STMT]      VARCHAR (1)   NULL,
    [MN_JOB_TABS]          VARCHAR (1)   NULL,
    [MN_MAR_CB_SETUP]      VARCHAR (1)   NULL,
    [PR_MAR_CB]            VARCHAR (1)   NULL,
    [PR_TMG_MF_EXP]        VARCHAR (1)   NULL,
    [PR_EMP_TIME_RPT]      VARCHAR (1)   NULL,
    [PR_PO_FORM]           VARCHAR (1)   NULL,
    [PR_EST_FORM]          VARCHAR (1)   NULL,
    [PR_JDA]               VARCHAR (1)   NULL,
    [MN_PRTNR]             VARCHAR (1)   NULL,
    [MD_PRTNR_ALLOC]       VARCHAR (1)   NULL,
    [MN_ASSOC]             VARCHAR (1)   NULL,
    [MN_RATE_WIZ]          VARCHAR (1)   NULL,
    [MN_PROD_CAT]          VARCHAR (1)   NULL,
    [UTILITY_REL]          VARCHAR (1)   NULL,
    [MD_STRATA_CONNECT]    VARCHAR (1)   NULL,
    [MD_ESTIMATING]        VARCHAR (1)   NULL,
    [AC_CLI_BUDGET]        VARCHAR (1)   NULL,
    [MD_GLOBAL_EDIT]       VARCHAR (1)   NULL,
    [MN_JOB_TMPLT]         VARCHAR (1)   NULL,
    [MN_RATE_TIERS]        VARCHAR (1)   NULL,
    [MN_BILL_RATE]         VARCHAR (1)   NULL,
    [AC_FEE_REC]           VARCHAR (1)   NULL,
    [MN_FISCAL_PERIOD]     VARCHAR (1)   NULL,
    [MN_DESTINATION]       VARCHAR (1)   NULL,
    [MN_DEST_CONTACT]      VARCHAR (1)   NULL,
    [MN_BLACKPLATE_VER]    VARCHAR (1)   NULL,
    [PR_JOB_DESTINATION]   VARCHAR (1)   NULL,
    [MN_MED_SPECS]         VARCHAR (1)   NULL,
    [GL_JE_BGT]            VARCHAR (1)   NULL,
    [GL_PROCESS]           VARCHAR (1)   NULL,
    [GL_MAINT]             VARCHAR (1)   NULL,
    [GL_QRY_RPT]           VARCHAR (1)   NULL,
    [GL_RPT_WRITER]        VARCHAR (1)   NULL,
    [MD_AP_APPROVAL]       VARCHAR (1)   NULL,
    [MD_AP_APPROVE]        VARCHAR (1)   NULL,
    [MD_AP_RECONCILE]      VARCHAR (1)   NULL,
    [MN_AGY_BUILDER]       VARCHAR (1)   NULL,
    [MN_PRODUCTION]        VARCHAR (1)   NULL,
    [MN_SCHEDULE_SETTINGS] VARCHAR (1)   NULL,
    [MN_EMPLOYEE_CATEGORY] VARCHAR (1)   NULL,
    [MN_EMPLOYEE_TITLE]    VARCHAR (1)   NULL,
    [MN_JOB_VER_TMPLT]     VARCHAR (1)   NULL,
    [MN_PO_APPROVAL]       VARCHAR (1)   NULL,
    [PR_PO_DO_OWN]         VARCHAR (1)   NULL,
    [AC_EMP_TIME_EXPORT]   VARCHAR (1)   NULL,
    [MR_EMP_TIME]          VARCHAR (1)   NULL,
    [MN_BILLING]           VARCHAR (1)   NULL,
    [MN_RESOURCE]          VARCHAR (1)   NULL,
    [MN_RESOURCE_TYPE]     VARCHAR (1)   NULL,
    [MN_EMP_OFFICE]        VARCHAR (1)   NULL,
    [MN_WS_COMP]           VARCHAR (1)   NULL,
    [BL_BCC]               VARCHAR (1)   NULL,
    [MN_GEN_DESC]          VARCHAR (1)   NULL,
    [MN_CRNCY_CODE]        VARCHAR (1)   NULL,
    [MN_INV_CAT]           VARCHAR (1)   NULL,
    [ADASSIST_OPT]         SMALLINT      NULL,
    [MN_STD_COMMENTS]      VARCHAR (1)   NULL,
    [MN_EMP_IMPORT]        VARCHAR (1)   NULL,
    [MN_PTO_TYPE]          VARCHAR (1)   NULL
);

