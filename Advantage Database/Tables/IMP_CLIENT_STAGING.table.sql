CREATE TABLE [dbo].[IMP_CLIENT_STAGING](
	[IMPORT_ID] [int] IDENTITY(1,1) NOT NULL,
	[BATCH_NAME] [varchar](50) NULL,
	[IS_NEW] [bit] NOT NULL,
	[CL_CODE] [varchar](6) NOT NULL,
	[CL_NAME] [varchar](40) NULL,
	[CL_ADDRESS1] [varchar](40) NULL,
	[CL_ADDRESS2] [varchar](40) NULL,
	[CL_CITY] [varchar](30) NULL,
	[CL_COUNTY] [varchar](20) NULL,
	[CL_STATE] [varchar](10) NULL,
	[CL_COUNTRY] [varchar](20) NULL,
	[CL_ZIP] [varchar](10) NULL,
	[CL_ATTENTION] [varchar](40) NULL,
	[CL_BADDRESS1] [varchar](40) NULL,
	[CL_BADDRESS2] [varchar](40) NULL,
	[CL_BCITY] [varchar](30) NULL,
	[CL_BCOUNTY] [varchar](20) NULL,
	[CL_BSTATE] [varchar](10) NULL,
	[CL_BCOUNTRY] [varchar](20) NULL,
	[CL_BZIP] [varchar](10) NULL,
	[CL_SADDRESS1] [varchar](40) NULL,
	[CL_SADDRESS2] [varchar](40) NULL,
	[CL_SCITY] [varchar](30) NULL,
	[CL_SCOUNTY] [varchar](20) NULL,
	[CL_SSTATE] [varchar](10) NULL,
	[CL_SCOUNTRY] [varchar](20) NULL,
	[CL_SZIP] [varchar](10) NULL,
	[CL_FOOTER] [varchar](60) NULL,
	[CL_ALPHA_SORT] [varchar](20) NULL,
	[CL_FISCAL_START] [smallint] NULL,
	[CL_CREDIT_LIMIT] [decimal](15, 2) NULL,
	[CL_INV_BY] [smallint] NULL,
	[CL_MATTENTION] [varchar](40) NULL,
	[CL_MINV_BY] [smallint] NULL,
	[CL_MFOOTER] [varchar](60) NULL,
	[ACTIVE_FLAG] [smallint] NULL,
	[NEW_BUSINESS] [smallint] NULL,
	[CMP_CODE_R] [smallint] NULL,
	[ACCT_NBR_R] [smallint] NULL,
	[JT_CODE_R] [smallint] NULL,
	[PROMO_CODE_R] [smallint] NULL,
	[REQ_FLDS] [smallint] NULL,
	[JOB_FIRST_USE_DT_R] [smallint] NULL,
	[COMPLEX_CODE_R] [smallint] NULL,
	[FORMAT_SC_CODE_R] [smallint] NULL,
	[DP_TM_CODE_R] [smallint] NULL,
	[MARKET_CODE_R] [smallint] NULL,
	[EMAIL_GR_CODE_R] [smallint] NULL,
	[BILL_COOP_CODE_R] [smallint] NULL,
	[AD_NBR_R] [smallint] NULL,
	[JOB_CLI_REF_R] [smallint] NULL,
	[JOB_DATE_OPENED_R] [smallint] NULL,
	[JOB_AD_SIZE_R] [smallint] NULL,
	[PROD_CONT_CODE_R] [smallint] NULL,
	[JOB_COMP_BUDGET_R] [smallint] NULL,
	[JOB_LOG_UDV1_R] [smallint] NULL,
	[JOB_LOG_UDV2_R] [smallint] NULL,
	[JOB_LOG_UDV3_R] [smallint] NULL,
	[JOB_LOG_UDV4_R] [smallint] NULL,
	[JOB_LOG_UDV5_R] [smallint] NULL,
	[JOB_CMP_UDV1_R] [smallint] NULL,
	[JOB_CMP_UDV2_R] [smallint] NULL,
	[JOB_CMP_UDV3_R] [smallint] NULL,
	[JOB_CMP_UDV4_R] [smallint] NULL,
	[JOB_CMP_UDV5_R] [smallint] NULL,
	[CL_AR_COMMENT] [text] NULL,
	[REQ_PROD_CAT] [smallint] NULL,
	[TAX_FLAG_R] [smallint] NULL,
	[FISCAL_PD_R] [smallint] NULL,
	[BLACKPLATE_VER_R] [smallint] NULL,
	[BLACKPLATE_VER2_R] [smallint] NULL,
	[CL_P_PAYDAYS] [smallint] NULL,
	[CL_M_PAYDAYS] [smallint] NULL,
	[SERVICE_FEE_TYPE_R] [smallint] NULL,
	[REQ_TIME_COMMENT] [bit] NOT NULL,
	[ON_HOLD] [bit] NOT NULL,
CONSTRAINT [PK_IMP_CLIENT_STAGING] PRIMARY KEY CLUSTERED 
(
	[IMPORT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

