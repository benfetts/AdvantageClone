IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[AR_SUMMARY]') AND OBJECTPROPERTY( id, N'IsUserTable' ) = 1 )
	DROP TABLE [dbo].[AR_SUMMARY]
GO	

IF NOT EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[AR_SUMMARY]') AND OBJECTPROPERTY( id, N'IsUserTable' ) = 1 )
	CREATE TABLE dbo.AR_SUMMARY (
		AR_SUMMARY_ID				integer identity(1,1) NOT NULL, 
		AR_INV_NBR					integer NULL,
		AR_INV_SEQ					smallint NULL,							
		AR_TYPE						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		COOP_PCT					decimal(10,4) NULL,
		MANUAL_FLAG					bit NULL,
		ORDER_NBR					integer NULL,
		ORDER_LINE_NBR				smallint NULL,
		MEDIA_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,			-- M, N, R, T, I, O
		JOB_NUMBER					integer NULL,
		JOB_COMPONENT_NBR			smallint NULL,
		JOB_AB_FLAG					smallint NULL,											
		AR_DESCRIPTION				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		OFFICE_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		SC_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_IDENTIFIER				integer NULL,												-- BJL 03/01/2013
		CLIENT_PO					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- BJL 03/01/2013
		FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		FNC_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
-- ****************************************************************************************************************************************************************************************************************				
		SALE_POST_PERIOD			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Use for media and production, but media is the main reason to add this
		TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		INV_TAX_FLAG				bit NULL,
		INV_BY						smallint NULL,	
		BILL_COMM_NET				smallint NULL,
		AB_REC_FLAG					smallint NULL,												-- DEBUG BJL added																	
		MED_REC_FLAG				smallint NULL,
		HRS_QTY						decimal(18,2) NULL,
-- ****************************************************************************************************************************************************************************************************************		
		GL_ACCT_AR					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		GL_ACCT_SALE				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		GL_ACCT_DEF_SALE			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the sale amount or its own column
		GL_ACCT_COS					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
		GL_ACCT_DEF_COS				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the cost of sales amount or its own column
		GL_ACCT_ACC_AP				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the WIP amount or its own column			
		GL_ACCT_ACC_COS				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- NEW 																					-- NEW - Amount goes into the WIP amount or its own column
		GL_ACCT_WIP					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
		GL_ACCT_STATE				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
		GL_ACCT_COUNTY				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
		GL_ACCT_CITY				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
-- ****************************************************************************************************************************************************************************************************************		
		MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MEDIA_MONTH					tinyint NULL,
		MEDIA_YEAR					smallint NULL,
		[START_DATE]				smalldatetime NULL,
		[END_DATE]					smalldatetime NULL,
-- ****************************************************************************************************************************************************************************************************************		
		EMP_TIME_AMT				decimal(18,2) NULL,
		INC_ONLY_AMT				decimal(18,2) NULL,
		COMMISSION_AMT				decimal(18,2) NULL,			-- MS
		REBATE_AMT					decimal(18,2) NULL,
		COST_AMT					decimal(18,2) NULL,
		NET_CHARGE_AMT				decimal(18,2) NULL,
		NON_RESALE_AMT				decimal(18,2) NULL,			-- MC							
		DISCOUNT_AMT				decimal(18,2) NULL,			-- MC							
		ADDITIONAL_AMT				decimal(18,2) NULL,			-- MS						
		AB_COST_AMT					decimal(18,2) NULL,
		AB_INC_AMT					decimal(18,2) NULL,		
		AB_COMMISSION_AMT			decimal(18,2) NULL,											-- AB Prod Commission (for Vendor Functions)
		AB_SALE_AMT					decimal(18,2) NULL,											-- For AB Flag of 5 entries only; it will use the normal sales account
		CITY_TAX_AMT				decimal(18,2) NULL,			-- MS
		CNTY_TAX_AMT				decimal(18,2) NULL,			-- MS
		STATE_TAX_AMT				decimal(18,2) NULL,			-- MS
		TOTAL_BILL					decimal(18,2) NULL,			-- MR (?)
-- ****************************************************************************************************************************************************************************************************************
		GL_XACT						integer NULL,
		GL_XACT_DEF					integer NULL,												-- Media Only - Separate GL Xact for Deferred Sale		
-- ****************************************************************************************************************************************************************************************************************
		MODIFIED_FLAG				bit NULL,
		DIFF_APPLIED				bit NULL,
		CONVERTED					bit NULL DEFAULT 0,
	  CONSTRAINT PK_AR_SUMMARY PRIMARY KEY ( AR_SUMMARY_ID ))
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON AR_SUMMARY TO PUBLIC AS dbo
GO
