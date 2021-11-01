IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[W_AR_FUNCTION]') AND OBJECTPROPERTY( id, N'IsUserTable' ) = 1 )
	DROP TABLE dbo.W_AR_FUNCTION
GO

IF NOT EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[W_AR_FUNCTION]') AND OBJECTPROPERTY( id, N'IsUserTable' ) = 1 )
	CREATE TABLE dbo.W_AR_FUNCTION (
		AR_FUNCTION_ID				integer identity(1,1) NOT NULL,															-- Just serves as PK to simplify updating
		BILLING_USER				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,			
		AR_INV_NBR					integer NULL,																			-- This will start with 1 for each BILLING_USER		
		DRAFT_INV_NBR				AS ( 'D-' + BILLING_USER + UPPER( LTRIM( RTRIM( CAST( AR_INV_NBR AS varchar(8)))))),		
		-- DRAFT_INV_NBR returns an identifier to use on the draft invoice, 
		-- ex. 'D-BENL1' which is 'D' as a prefix, a dash, the billing user, and the padded temporary invoice number	
		AR_INV_SEQ					smallint NULL,	
		COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
		COOP_PCT					decimal(9,4) NULL,	
		MANUAL_FLAG					bit NOT NULL,
		ORDER_NBR					integer NULL,
		ORDER_LINE_NBR				smallint NULL,
		MEDIA_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,									-- M, N, R, T, I, O
		JOB_NUMBER					integer NULL,
		JOB_COMPONENT_NBR			smallint NULL,
		JOB_AB_FLAG					smallint NULL,																			-- This would tell us what the job's ab flag was at the time of billing.  Certain ones would not allow for coop split edit.  Only 2 would allow.
		AR_DESCRIPTION				varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		OFFICE_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,	
		SC_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,			
		CMP_IDENTIFIER				integer NULL,	
		CLIENT_PO					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,									-- BJL 02/12/2013 - Changed to allow NULLs for income recognition
		FNC_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS  NULL,									-- BJL 02/12/2013 - Changed to allow for income recognition FNC_TYPE ("R")
-- ****************************************************************************************************************************************************************************************************************
		SALE_POST_PERIOD			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,									-- Use for media and production, but media is the main reason to add this.
		TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		INV_TAX_FLAG				bit NULL,																				-- Set if tax is applied at the time of billing?
		INV_BY						smallint NULL,																				
		BILL_COMM_NET				smallint NULL,																		-- DEBUG BJL added	
		AB_REC_FLAG					smallint NULL,																		-- 
		MED_REC_FLAG				smallint NULL,																		-- DEBUG BJL added	
		HRS_QTY						decimal(18,2) NULL,																		-- Don't split for coop
-- ****************************************************************************************************************************************************************************************************************
		MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MEDIA_MONTH					tinyint NULL,
		MEDIA_YEAR					smallint NULL,
		[START_DATE]				smalldatetime NULL,
		[END_DATE]					smalldatetime NULL,
-- ****************************************************************************************************************************************************************************************************************
		EMP_TIME_AMT				decimal(18,2) NULL,																		-- Employee Time plus its markup
		INC_ONLY_AMT				decimal(18,2) NULL,																		-- Income Only plus its markup
		COMMISSION_AMT				decimal(18,2) NULL,																		-- Commission for the vendor amount
		REBATE_AMT					decimal(18,2) NULL,																		-- Media Rebate
		COST_AMT					decimal(18,2) NULL,																	-- DEBUG Cost Amount for Media (Production okay)
		NET_CHARGE_AMT				decimal(18,2) NULL,																		-- Media Net Charge
		NON_RESALE_AMT				decimal(18,2) NULL,			-- MC														-- NEW - 
		DISCOUNT_AMT				decimal(18,2) NULL,			-- MC														-- NEW - 
		ADDITIONAL_AMT				decimal(18,2) NULL,			-- MS														-- NEW - 
		AB_COST_AMT					decimal(18,2) NULL,																		-- AB Prod Cost Amount
		AB_INC_AMT					decimal(18,2) NULL,																		-- AB Prod Income Amount (Time or Income Only plus their markup)
		AB_COMMISSION_AMT			decimal(18,2) NULL,																		-- AB Prod Commission (for Vendor Functions)
		AB_SALE_AMT					decimal(18,2) NULL,																		-- This will be for AB Flag of 5 entries only.  It will use the normal Sales Account.
		CITY_TAX_AMT				decimal(18,2) NULL,			-- MS														-- Resale City
		CNTY_TAX_AMT				decimal(18,2) NULL,			-- MS														-- Resale County 
		STATE_TAX_AMT				decimal(18,2) NULL,			-- MS														-- Resale State
		TOTAL_BILL					decimal(18,2) NULL,			-- MR 														-- Total Billing Amount, should be all amounts totaled.
-- ****************************************************************************************************************************************************************************************************************
		TAX_STATE_PCT				decimal(8,4),																			-- BJL 04/25/2013
		TAX_COUNTY_PCT				decimal(8,4),																			-- BJL 04/25/2013
		TAX_CITY_PCT				decimal(8,4),																			-- BJL 04/25/2013
		TAX_COMM					bit NULL,																				-- BJL 04/25/2013
		TAX_COMM_ONLY				bit NULL,																				-- BJL 04/25/2013
		RECONCILE_ROW				bit NULL,																				-- BJL 04/01/2013
		SUMMARY_FLAG				bit NOT NULL DEFAULT 0,																	-- Used for simplified co-op rounding - ignore rows with SUMMARY_FLAG = 1
		MODIFIED_FLAG				bit NULL,																				-- RESERVED FOR FUTURE FUNCTIONALITY
		REJECTED_BY_OFFICE			bit NULL,																				-- Used to ID co-ops with multiple offices
	  CONSTRAINT PK_W_AR_FUNCTION PRIMARY KEY ( AR_FUNCTION_ID )	
	)		
GO
