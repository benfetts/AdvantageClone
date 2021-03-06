
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_billing]' ) AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_billing]
GO

CREATE PROCEDURE [dbo].[advsp_billing] @billing_user_in varchar(100), @ret_val integer OUTPUT
AS

-- ************************************************************************************************************************
-- BJL 11/15/2012 - Now populating #PROD_DTL.EMP_TIME_MU_AMT and #PROD_DTL.INC_ONLY_MU_AMT
-- BJL 11/16/2012 - Added AR_FUNCTION.JOB_COMPONENT
-- BJL 12/20/2012 - Added invoice by job component
-- BJL 12/27/2012 - Incorrect AR GL sequence in AR_SUMMARY
-- BJL 12/27/2012 - Incorrect rounding
-- BJL 01/05/2013 - Adjustment/rounding commented out and moved to [advsp_bcc_populate_ar_function]
-- BJL 01/08/2013 - Added media
-- BJL 01/17/2013 - Added AR_FUNCTION.HRS_QTY
-- BJL 02/06/2013 - Rewrote condensed version based on new table structures and sequence of processing
-- BJL 03/01/2013 - Added CMP_IDENTIFIER and JOB_CL_PO_NBR to AR_SUMMARY
-- BJL 04/05/2013 - Moved account gathering from advsp_bcc_populate_ar_function
-- BJL 04/24/2013 - Multi-campaign to one job fix
-- BJL 06/25/2013 - Added income recognition
-- PJH 08/01/2013 - Updated Group By for ACCT_REC inserts Per EC
-- BJL 08/16/2013 - Fixed income recognition coop
-- BJL 10/24/2013 - Fixed issue with missing GL accounts from AR_SUMMARY, A/B and actuals tables
-- BJL ** NOTE ** - Consider adding flags for accounts to use and validate that used xact's and invoice numbers are actually used
-- BJL 10/25/2013 - Changed criteria so that an ACC_AP account is not retrieved for progress bill
-- BJL 10/30/2013 - Wrong media detail accounts updated when multiple tax codes on a line
-- BJL ** NOTE ** - We are favoring an approach that de-emphasizes specifying G/L accounts only when used to 
--					recording all available, whether or not entries were made
-- BJL 11/12/2013 - Use multiple rows in AR_SUMMARY when there are multiple tax codes for production
-- BJL 11/13/2013 - Break out vendor tax for production
-- BJL 11/20/2013 - Added AB_NONRESALE_AMT
-- EC 12/07/2013 - Fixed Media AR SEQ and GL Account updates to actual tables
-- EC 01/08/2014 - Fixed Update AR_INV_NBR for BILL_APPR_HDR 
-- PJH 02/19/2015 - Do not allow $0 GL Detail rows -After AR Inoice is updated to source tables - Before assigning GL seq numbers
-- MJC 02/20/2015 - Added Column AVATAX_DOC_CODE to @AR_SUMMARY and insertion into AR_SUMMARY
-- PJH 03/04/2015 - Do not clear w_ar_function here - will be cleared by PostAvaTax or in at end of Assign Invoice on PB side 
-- MJC 02/20/2015 - Removed Column AVATAX_DOC_CODE from @AR_SUMMARY and insertion into AR_SUMMARY and ADDED select @ret_val
-- PJH 04/07/2015 - Avatax columns	to @AR_SUMMARY - AVATAX_KEY = yymmddhhnnss + @billing_user_in, AVATAX_POSTED 
-- PJH 04/07/2015 - Clear Cli/Div in ACCT_REC insert if INV_BY precludes their use
-- PJH 04/07/2015 - Allow clearing w_ar_function - we are using AR_SUMMARY now for posting Avatax
-- PJH 04/21/2015 - Changed BILL_HOLD <> 1 to  BILL_HOLD = 0
-- PJH 07/20/2015 - Clear Cli/Div if INV_BY precludes their use - Only in ACCT_REC INSERT - Leave @AR_SUMMARY for later use
-- MJC 09/29/2015 - join on new FNC_CODE column in INCOME_REC
-- MJC 10/16/2015 - add calls to usp_wv_BA_BATCH_FINISH
-- MJC 10/19/2015 - clear AP, IO, ET temporary bill holds if job/comp was assigned to invoice
-- MJC 11/06/2015 - changes for Combo Invoice billing
-- MJC 01/27/2016 - added Clear Div/Prd if INV_BY precludes their use when COMBO billing
-- MJC 04/06/2016 - Only clear TEMP bill holds
-- PJH 05/25/2016 - Choose Campaign or Job Cli/Div/Prd - Production
-- PJH 05/25/2016 - Choose Campaign or Job Cli/Div/Prd - Media
-- PJH 05/25/2016 - Clear Div - Production if A.INV_BY IN (6,21)
-- PJH 05/25/2016 - Clear Div - Media if A.INV_BY IN (6,21)
-- PJH 05/25/2016 - Clear Prd - Production if A.INV_BY IN (6,7,21)
-- PJH 05/25/2016 - Clear Prd - Media if A.INV_BY IN (6,21)
-- MJC 06/01/2016 - added multi currency
-- MJC 06/15/2016 - added client/division combo billing
-- PJH 09/06/2016 - Use @AR_SUMMARY2 to update ACCT_REC
-- MJC 12/09/2016 - fixed EXCHANGE_RATE sign
-- MJC 01/09/2017 - fixed to store correct USER_ID in ACCT_REC and GLENTHDR
-- PJH 02/23/2017 - 735-1-2666 - Check Void - There is no GL transaction for voided check - Lock IDSTABLE until transaction is complete
-- PJH 04/06/2017 - Added Deferred
-- PJH 06/12/2017 - Added  AND A.AR_INV_SEQ = 0 - Don't update Coop records
-- MJC 10/16/2018 - add BILLING_ADDRESS to ACCT_REC
-- PJH 03/07/2018 - Updated for Unit Split (TV only)
-- PJH 09/18/2019 - Update AR_SUMMARY with TV_UNIT split as needed
-- PJH 03/04/2020 - Added Job and Component to grouping and join
-- ************************************************************************************************************************

SET ANSI_WARNINGS OFF
SET NOCOUNT ON

-- BJL 02/07/2013 - Temp table for retrieving rows from AR_SUMMARY for the current billing user
DECLARE @AR_SUMMARY TABLE (
	AR_SUMMARY_ID				integer identity(1,1) NOT NULL, 
	AR_FUNCTION_ID				integer NOT NULL, 
	AR_INV_NBR					integer NULL,
	AR_INV_SEQ					smallint NULL,							
	AR_TYPE						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	COOP_PCT					decimal(10,4) NULL,
	MANUAL_FLAG					bit NULL,
	ORDER_NBR					integer NULL,
	ORDER_LINE_NBR				smallint NULL,
	MEDIA_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- M, N, R, T, I, O
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
	GL_XACT						integer NULL,
	GL_SEQ_AR					smallint NULL,
	GL_SEQ_SALE					smallint NULL,
	GL_SEQ_COS					smallint NULL,
	GL_SEQ_WIP					smallint NULL,
	GL_SEQ_ACC_AP				smallint NULL,
	GL_SEQ_ACC_COS				smallint NULL,
	GL_SEQ_STATE				smallint NULL,
	GL_SEQ_COUNTY				smallint NULL,
	GL_SEQ_CITY					smallint NULL,
	GL_ACCT_AR					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GL_ACCT_SALE				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GL_ACCT_DEF_SALE			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the sale amount or its own column
	GL_ACCT_COS					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	GL_ACCT_DEF_COS				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the cost of sales amount or its own column
	GL_ACCT_ACC_AP				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the WIP amount or its own column
	GL_ACCT_ACC_COS				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the WIP amount or its own column		
	GL_ACCT_WIP					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
	GL_ACCT_STATE				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	GL_ACCT_COUNTY				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
	GL_ACCT_CITY				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	SALE_POST_PERIOD			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Use for media deferred only
	GL_XACT_DEF					integer NULL,												-- Media Only - Separate GL Xact for Deferred Sale		
	GL_SEQ_DEF_SALE				smallint NULL,
	GL_SEQ_DEF_COS				smallint NULL,
	INV_TAX_FLAG				bit NULL,														--Tax @ Invoice
	INV_BY						smallint NULL,															
	BILL_COMM_NET				smallint NULL,
	AB_REC_FLAG					smallint NULL,												-- BJL added
	MED_REC_FLAG				smallint NULL,												-- BJL added
	HRS_QTY						decimal(18,2) NULL,
-- **********************************************************************************************************************************************************************************	
	TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
-- **********************************************************************************************************************************************************************************	
	EMP_TIME_AMT				decimal(18,2) NULL,
	INC_ONLY_AMT				decimal(18,2) NULL,
	COMMISSION_AMT				decimal(18,2) NULL,			-- MS
	REBATE_AMT					decimal(18,2) NULL,			-- MS
	COST_AMT					decimal(18,2) NULL,			-- MC (total)							
	NET_CHARGE_AMT				decimal(18,2) NULL,			-- MC
	NON_RESALE_AMT				decimal(18,2) NULL,			-- MC							
	DISCOUNT_AMT				decimal(18,2) NULL,			-- MC							
	ADDITIONAL_AMT				decimal(18,2) NULL,			-- MS							
	AB_COST_AMT					decimal(18,2) NULL,
	AB_INC_AMT					decimal(18,2) NULL,		
	AB_COMMISSION_AMT			decimal(18,2) NULL,											-- AB Prod Commission (for Vendor Functions)
	AB_SALE_AMT					decimal(18,2) NULL,											-- This will be for AB Flag of 5 entries only; it will use the normal sales account
	AB_NONRESALE_AMT			decimal(18,2) NULL,											-- BJL 11/20/2013
-- **********************************************************************************************************************************************************************************		
	CITY_TAX_PCT				decimal(9,4) NULL,
	CNTY_TAX_PCT				decimal(9,4) NULL,
	STATE_TAX_PCT				decimal(9,4) NULL,
	CITY_TAX_AMT				decimal(18,2) NULL,			-- MS
	CNTY_TAX_AMT				decimal(18,2) NULL,			-- MS
	STATE_TAX_AMT				decimal(18,2) NULL,			-- MS
	TOTAL_BILL					decimal(18,2) NULL,			-- MR 
-- **********************************************************************************************************************************************************************************	
	DEFERRED_FLAG				bit NULL,
	SUMMARY_FLAG				bit NULL,	
	MODIFIED_FLAG				bit NULL,
-- ****************************************************************************************************************************************************************************************************************		
	MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_MONTH					tinyint NULL,
	MEDIA_YEAR					smallint NULL,
	[START_DATE]				smalldatetime NULL,
	[END_DATE]					smalldatetime NULL,
-- ****************************************************************************************************************************************************************************************************************		
	-- BJL 04/19/2013 - Added to properly update ACCT_REC when assigning by CL_CODE or by DIV_CODE
	AR_DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AR_PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
-- ****************************************************************************************************************************************************************************************************************	
	--PJH 04/07/2015 - Avatax columns	
	AVATAX_KEY					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AVATAX_POSTED			bit NULL,
-- ****************************************************************************************************************************************************************************************************************		
	DIFF_APPLIED				bit NULL,
	PROD_SALE_AMT				AS ( CASE AB_REC_FLAG
										WHEN 1 THEN COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) 
												  + COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 )
												  + COALESCE( AB_SALE_AMT, 0.00 ) 
												  + COALESCE( NON_RESALE_AMT, 0.00 )								-- BJL 11/15/13
										WHEN 2 THEN COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) 
												  + COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 )
												  + COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 )
												  + COALESCE( AB_COST_AMT, 0.00 ) + COALESCE( AB_SALE_AMT, 0.00 )
												  + COALESCE( NON_RESALE_AMT, 0.00 )								-- BJL 11/15/13
												  + COALESCE( AB_NONRESALE_AMT, 0.00 )								-- BJL 11/20/13
											   ELSE COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) 
												  + COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 )
												  + COALESCE( NON_RESALE_AMT, 0.00 )								-- BJL 11/15/13
									 END ),
	MEDIA_SALE_AMT				AS ( CASE BILL_COMM_NET 
										WHEN 1 THEN COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( REBATE_AMT, 0.00 )
										WHEN 2 THEN COALESCE( COST_AMT, 0.00 ) + COALESCE( NET_CHARGE_AMT, 0.00 )
												  + COALESCE( NON_RESALE_AMT, 0.00 ) + COALESCE( DISCOUNT_AMT, 0.00 )
												  + COALESCE( ADDITIONAL_AMT, 0.00 )
										WHEN 3 THEN COALESCE( COST_AMT, 0.00 ) + COALESCE( NET_CHARGE_AMT, 0.00 )
												  + COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( REBATE_AMT, 0.00 )
												  + COALESCE( NON_RESALE_AMT, 0.00 ) + COALESCE( DISCOUNT_AMT, 0.00 )
												  + COALESCE( ADDITIONAL_AMT, 0.00 )
											   ELSE 0.00
									  END ),
	MEDIA_COS_AMT				AS ( CASE BILL_COMM_NET 
										WHEN 1 THEN 0.00
										WHEN 2 THEN COALESCE( COST_AMT, 0.00 ) + COALESCE( NET_CHARGE_AMT, 0.00 )
												  + COALESCE( NON_RESALE_AMT, 0.00 ) + COALESCE( DISCOUNT_AMT, 0.00 )
										WHEN 3 THEN COALESCE( COST_AMT, 0.00 ) + COALESCE( NET_CHARGE_AMT, 0.00 )
												  + COALESCE( NON_RESALE_AMT, 0.00 ) + COALESCE( DISCOUNT_AMT, 0.00 )
											   ELSE 0.00
									  END ),
	HAS_PROD_SALE_AMT			AS ( CASE AB_REC_FLAG																-- BJL 10/24/13
										WHEN 1 THEN COALESCE( ABS( EMP_TIME_AMT ), 0.00 ) + COALESCE( ABS( INC_ONLY_AMT ), 0.00 ) 
												  + COALESCE( ABS( COMMISSION_AMT ), 0.00 ) + COALESCE( ABS( COST_AMT ), 0.00 )
												  + COALESCE( ABS( AB_SALE_AMT ), 0.00 )
												  + COALESCE( ABS( NON_RESALE_AMT ), 0.00 )							-- BJL 11/15/13
										WHEN 2 THEN COALESCE( ABS( EMP_TIME_AMT ), 0.00 ) + COALESCE( ABS( INC_ONLY_AMT ), 0.00 ) 
												  + COALESCE( ABS( COMMISSION_AMT ), 0.00 ) + COALESCE( ABS( COST_AMT ), 0.00 )
												  + COALESCE( ABS( AB_INC_AMT ), 0.00 ) + COALESCE( ABS( AB_COMMISSION_AMT ), 0.00 )
												  + COALESCE( ABS( AB_COST_AMT ), 0.00 ) + COALESCE( ABS( AB_SALE_AMT ), 0.00 )
												  + COALESCE( ABS( NON_RESALE_AMT ), 0.00 )							-- BJL 11/15/13
												  + COALESCE( ABS( AB_NONRESALE_AMT ), 0.00 )						-- BJL 11/20/13
											   ELSE COALESCE( ABS( EMP_TIME_AMT ), 0.00 ) + COALESCE( ABS( INC_ONLY_AMT ), 0.00 ) 
												  + COALESCE( ABS( COMMISSION_AMT ), 0.00 ) + COALESCE( ABS( COST_AMT ), 0.00 )
												  + COALESCE( ABS( NON_RESALE_AMT ), 0.00 )							-- BJL 11/15/13
									 END ),
	HAS_MEDIA_SALE_AMT			AS ( CASE BILL_COMM_NET																-- BJL 10/24/13 
										WHEN 1 THEN COALESCE( ABS( COMMISSION_AMT ), 0.00 ) + COALESCE( ABS( REBATE_AMT ), 0.00 )
										WHEN 2 THEN COALESCE( ABS( COST_AMT ), 0.00 ) + COALESCE( ABS( NET_CHARGE_AMT ), 0.00 )
												  + COALESCE( ABS( NON_RESALE_AMT ), 0.00 ) + COALESCE( ABS( DISCOUNT_AMT ), 0.00 )
												  + COALESCE( ABS( ADDITIONAL_AMT ), 0.00 )
										WHEN 3 THEN COALESCE( ABS( COST_AMT ), 0.00 ) + COALESCE( ABS( NET_CHARGE_AMT ), 0.00 )
												  + COALESCE( ABS( COMMISSION_AMT ), 0.00 ) + COALESCE( ABS( REBATE_AMT ), 0.00 )
												  + COALESCE( ABS( NON_RESALE_AMT ), 0.00 ) + COALESCE( ABS( DISCOUNT_AMT ), 0.00 )
												  + COALESCE( ABS( ADDITIONAL_AMT ), 0.00 )
											   ELSE 0.00
									  END ),
	HAS_MEDIA_COS_AMT			AS ( CASE BILL_COMM_NET																-- BJL 10/24/13
										WHEN 1 THEN 0.00
										WHEN 2 THEN COALESCE( ABS( COST_AMT ), 0.00 ) + COALESCE( ABS( NET_CHARGE_AMT ), 0.00 )
												  + COALESCE( ABS( NON_RESALE_AMT ), 0.00 ) + COALESCE( ABS( DISCOUNT_AMT ), 0.00 )
										WHEN 3 THEN COALESCE( ABS( COST_AMT ), 0.00 ) + COALESCE( ABS( NET_CHARGE_AMT ), 0.00 )
												  + COALESCE( ABS( NON_RESALE_AMT ), 0.00 ) + COALESCE( ABS( DISCOUNT_AMT ), 0.00 )
											   ELSE 0.00
									  END ),
	CURRENCY_CODE				varchar(5) NULL,
	CURRENCY_RATE				decimal(12,6) NULL,
	BILLING_ADDRESS				varchar(100) NULL,
	UNIQUE (JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, FNC_TYPE, SUMMARY_FLAG, AR_SUMMARY_ID),
	UNIQUE (ORDER_NBR, ORDER_LINE_NBR, TAX_CODE, MEDIA_TYPE, SUMMARY_FLAG, AR_INV_NBR, AR_SUMMARY_ID),
	UNIQUE (AR_INV_NBR, AR_INV_SEQ, CL_CODE, DIV_CODE, PRD_CODE, GL_XACT, AR_SUMMARY_ID)
)

DECLARE @AR_SUMMARY2 TABLE (
	AR_SUMMARY_ID				integer NOT NULL, 
	AR_FUNCTION_ID				integer NOT NULL, 
	AR_INV_NBR					integer NULL,
	AR_INV_SEQ					smallint NULL,							
	AR_TYPE						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	COOP_PCT					decimal(10,4) NULL,
	MANUAL_FLAG					bit NULL,
	ORDER_NBR					integer NULL,
	ORDER_LINE_NBR				smallint NULL,
	MEDIA_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- M, N, R, T, I, O
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
	GL_XACT						integer NULL,
	GL_SEQ_AR					smallint NULL,
	GL_SEQ_SALE					smallint NULL,
	GL_SEQ_COS					smallint NULL,
	GL_SEQ_WIP					smallint NULL,
	GL_SEQ_ACC_AP				smallint NULL,
	GL_SEQ_ACC_COS				smallint NULL,
	GL_SEQ_STATE				smallint NULL,
	GL_SEQ_COUNTY				smallint NULL,
	GL_SEQ_CITY					smallint NULL,
	GL_ACCT_AR					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GL_ACCT_SALE				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GL_ACCT_DEF_SALE			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the sale amount or its own column
	GL_ACCT_COS					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	GL_ACCT_DEF_COS				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the cost of sales amount or its own column
	GL_ACCT_ACC_AP				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the WIP amount or its own column
	GL_ACCT_ACC_COS				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Amount goes into the WIP amount or its own column		
	GL_ACCT_WIP					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
	GL_ACCT_STATE				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	GL_ACCT_COUNTY				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
	GL_ACCT_CITY				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	SALE_POST_PERIOD			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Use for media deferred only
	GL_XACT_DEF					integer NULL,												-- Media Only - Separate GL Xact for Deferred Sale		
	GL_SEQ_DEF_SALE				smallint NULL,
	GL_SEQ_DEF_COS				smallint NULL,
	INV_TAX_FLAG				bit NULL,														--Tax @ Invoice
	INV_BY						smallint NULL,															
	BILL_COMM_NET				smallint NULL,
	AB_REC_FLAG					smallint NULL,												-- BJL added
	MED_REC_FLAG				smallint NULL,												-- BJL added
	HRS_QTY						decimal(18,2) NULL,
-- **********************************************************************************************************************************************************************************	
	TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
-- **********************************************************************************************************************************************************************************	
	EMP_TIME_AMT				decimal(18,2) NULL,
	INC_ONLY_AMT				decimal(18,2) NULL,
	COMMISSION_AMT				decimal(18,2) NULL,			-- MS
	REBATE_AMT					decimal(18,2) NULL,			-- MS
	COST_AMT					decimal(18,2) NULL,			-- MC (total)							
	NET_CHARGE_AMT				decimal(18,2) NULL,			-- MC
	NON_RESALE_AMT				decimal(18,2) NULL,			-- MC							
	DISCOUNT_AMT				decimal(18,2) NULL,			-- MC							
	ADDITIONAL_AMT				decimal(18,2) NULL,			-- MS							
	AB_COST_AMT					decimal(18,2) NULL,
	AB_INC_AMT					decimal(18,2) NULL,		
	AB_COMMISSION_AMT			decimal(18,2) NULL,											-- AB Prod Commission (for Vendor Functions)
	AB_SALE_AMT					decimal(18,2) NULL,											-- This will be for AB Flag of 5 entries only; it will use the normal sales account
	AB_NONRESALE_AMT			decimal(18,2) NULL,											-- BJL 11/20/2013
-- **********************************************************************************************************************************************************************************		
	CITY_TAX_PCT				decimal(9,4) NULL,
	CNTY_TAX_PCT				decimal(9,4) NULL,
	STATE_TAX_PCT				decimal(9,4) NULL,
	CITY_TAX_AMT				decimal(18,2) NULL,			-- MS
	CNTY_TAX_AMT				decimal(18,2) NULL,			-- MS
	STATE_TAX_AMT				decimal(18,2) NULL,			-- MS
	TOTAL_BILL					decimal(18,2) NULL,			-- MR 
-- **********************************************************************************************************************************************************************************	
	DEFERRED_FLAG				bit NULL,
	SUMMARY_FLAG				bit NULL,	
	MODIFIED_FLAG				bit NULL,
-- ****************************************************************************************************************************************************************************************************************		
	MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_MONTH					tinyint NULL,
	MEDIA_YEAR					smallint NULL,
	[START_DATE]				smalldatetime NULL,
	[END_DATE]					smalldatetime NULL,
-- ****************************************************************************************************************************************************************************************************************		
	-- BJL 04/19/2013 - Added to properly update ACCT_REC when assigning by CL_CODE or by DIV_CODE
	AR_DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AR_PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
-- ****************************************************************************************************************************************************************************************************************	
	--PJH 04/07/2015 - Avatax columns	
	AVATAX_KEY					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AVATAX_POSTED			bit NULL,
-- ****************************************************************************************************************************************************************************************************************		
	DIFF_APPLIED				bit NULL,
	PROD_SALE_AMT			decimal(18,2) NULL,
	MEDIA_SALE_AMT			decimal(18,2) NULL,
	MEDIA_COS_AMT			decimal(18,2) NULL,
	HAS_PROD_SALE_AMT	decimal(18,2) NULL,
	HAS_MEDIA_SALE_AMT	decimal(18,2) NULL,
	HAS_MEDIA_COS_AMT	decimal(18,2) NULL,
	CURRENCY_CODE				varchar(5) NULL,
	CURRENCY_RATE				decimal(12,6) NULL,
	BILLING_ADDRESS				varchar(100) NULL,
	UNIQUE (JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, FNC_TYPE, SUMMARY_FLAG, AR_SUMMARY_ID),
	UNIQUE (ORDER_NBR, ORDER_LINE_NBR, TAX_CODE, MEDIA_TYPE, SUMMARY_FLAG, AR_INV_NBR, AR_SUMMARY_ID),
	UNIQUE (AR_INV_NBR, AR_INV_SEQ, CL_CODE, DIV_CODE, PRD_CODE, GL_XACT, AR_SUMMARY_ID)
)

-- BJL 02/07/2013 - Temp table for setting up the journal entries
DECLARE @GL_ENTRY TABLE ( 
	GL_ENTRY_ID			integer identity(1,1) NOT NULL, 
	GL_ENTRY_SUM_ID		integer NULL, 
	GLEXACT				integer NOT NULL, 
	GLETSEQ				smallint NULL,
	ACCT_TYPE			varchar(32) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLACCOUNT			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLPP				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLSOURCE			varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLREM				varchar(150) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	INV_BY				smallint NOT NULL,
	GLETAMT				decimal(18,2) NOT NULL,
	AR_INV_NBR			integer NOT NULL,
	AR_INV_SEQ			smallint NULL,														-- BJL 04/24/2013 - Multi-campaign to one job fix
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_NUMBER			integer NULL,
	ORDER_NUMBER		integer NULL,
	DEFERRED_FLAG		bit NOT NULL DEFAULT 0,
	SUMMARY_ROW			bit NOT NULL DEFAULT 0,
	UNIQUE (AR_INV_NBR, AR_INV_SEQ, ORDER_NUMBER, GLPP, DEFERRED_FLAG, GL_ENTRY_ID),
	UNIQUE (GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, AR_INV_NBR, GL_ENTRY_ID),
	UNIQUE (AR_INV_NBR, AR_INV_SEQ, CL_CODE, DIV_CODE, PRD_CODE, GLEXACT, GLACCOUNT, ACCT_TYPE, SUMMARY_ROW, GL_ENTRY_ID)
)	

-- BJL 04/09/2013 - Added to set up the deferred media journal entries
DECLARE @GL_ENTRY_DEF TABLE ( 
	GL_ENTRY_DEF_ID		integer identity(1,1) NOT NULL, 
--	GLEXACT_DEF			integer NULL, 
	GLETSEQ				smallint NULL,
	ACCT_TYPE			varchar(32) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLACCOUNT			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLPP				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLSOURCE			varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	GLREM				varchar(150) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	INV_BY				smallint NOT NULL,
	GLETAMT				decimal(18,2) NOT NULL,
	AR_INV_NBR			integer NOT NULL,
	AR_INV_SEQ			smallint NOT NULL,												-- BJL 04/24/2013 - Multi-campaign to one job fix	
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ORDER_NUMBER		integer NULL
)	

DECLARE @assign_inv smallint, @first_inv integer, @last_inv integer, @magazine bit
DECLARE @media bit, @newspaper bit, @outdoor bit, @production bit, @radio bit
DECLARE @service_fees smallint, @television bit, @adjust smallint, @internet bit
DECLARE @post_period varchar(6), @inv_date smalldatetime, @row_ct integer
DECLARE @gl_xact integer, @gl_xact_def integer, @coop_master_seq tinyint, @ar_inv_nbr integer
DECLARE @curr_assign_user varchar(100)--, @inv_tax_flag bit
DECLARE @gl_total decimal(18,2), @update_on bit
DECLARE @avatax_key_base varchar(40), @avatax_enabled integer, @user_code varchar(100)
/* PJH 02/23/2017 - added */
DECLARE @gl_xact_base integer, @gl_xact_def_base integer, @ar_inv_nbr_base integer

/* 02/23/2017 - do not need this transaction any longer */	
--BEGIN TRANSACTION populate_billing;

SET @update_on = 1
SET @ret_val = 0
SET @gl_xact = 0

SELECT @avatax_enabled = COALESCE(CAST(AGY_SETTINGS_VALUE AS INT), 0)
FROM AGY_SETTINGS 
WHERE AGY_SETTINGS_CODE = 'AVATAX_ENABLED'

IF @avatax_enabled = 1 
BEGIN
	SET @avatax_key_base = REPLACE(CONVERT(VARCHAR(10), GETDATE(), 102), '.', '') +  REPLACE(CONVERT(VARCHAR(12), GETDATE(), 108), ':','')
	SET @avatax_key_base = @avatax_key_base + '-' + LEFT(@billing_user_in, 24)
END

SELECT @user_code = LEFT(BILLING_USER,LEN(BILLING_USER)-2)
FROM dbo.BILLING_CMD_CENTER
WHERE BILLING_USER = @billing_user_in

-- BJL 02/07/2013 - @coop_master_seq holds the number used to designate an A/R "master" job co-op record
	-- @coop_master_seq was created in such a way as to simplify switching over from 99 to -1 
	-- as the co-op master at some point in the future.
SET @coop_master_seq = 99				

IF ( @ret_val = 0 )
BEGIN
	-- BJL 02/07/2013 - Retrieve the AGENCY and BILLING table values
	 SELECT @assign_inv = b.INV_ASSIGN, @first_inv = b.FIRST_INV, @last_inv = b.LAST_INV, @magazine = b.MAGAZINE, @media = b.MEDIA, 
			@newspaper = b.NEWSPAPER, @outdoor = b.OUTDOOR, @production = b.PRODUCTION, @radio = b.RADIO, @service_fees = b.SERVICE_FEES, 
			@television = b.TELEVISION, @adjust = b.ADJUSTMENTS, @internet = b.INTERNET, @post_period = b.POST_PERIOD, @inv_date = b.INV_DATE
	   FROM dbo.BILLING b
	  WHERE ( b.BILLING_USER = @billing_user_in )
	  
	SET @row_ct = @@ROWCOUNT
	SET @ret_val = @@ERROR
END

-- {4}
IF ( @ret_val = 0 )
BEGIN
	IF ( @row_ct = 1 )
	BEGIN
		IF ( @assign_inv = 1 )
			SET @ret_val = -1					-- ! Invoices have already been assigned
	END
	ELSE
		SET @ret_val = -3						-- ! No billing record exists for the current user
END

-- BJL 02/09/2013 - Check for cross offices
IF ( @ret_val = 0 )
BEGIN
	SELECT @row_ct = ( SELECT COUNT( * ) FROM dbo.W_AR_FUNCTION WHERE ( BILLING_USER = @billing_user_in ) AND ( REJECTED_BY_OFFICE = 1 ))
	SET @ret_val = @@ERROR

	IF ( @row_ct > 0 )
		SET @ret_val = -12					-- ! A job or order has multiple offices
END

-- BJL 02/11/2013 - Check for out of balance co-op job split 
IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	SELECT @row_ct = ( SELECT COUNT( * ) FROM dbo.advtf_get_billing_function_var( @billing_user_in ))
	SET @ret_val = @@ERROR

	IF ( @row_ct > 0 )
		SET @ret_val = -13					-- ! Production co-op split OOB
END

-- BJL 05/22/2013 - Add check for media out of balance co-op job split 
--IF ( @ret_val = 0 AND @media = 1 )
--BEGIN
--	SELECT @row_ct = ( SELECT COUNT( * ) FROM dbo.advtf_get_billing_order_line_var( @billing_user_in ))
--	SET @ret_val = @@ERROR

--	IF ( @row_ct > 0 )
--		SET @ret_val = -14					-- ! Media co-op split OOB
--END

--{5.2}
--IF ( @ret_val = 0 )
--BEGIN
--	-- BJL 02/06/2012 - Get the last invoice number assigned
--	SELECT @ar_inv_nbr = [LAST_NBR], @curr_assign_user = [USER_ID] FROM dbo.ASSIGN_NBR WHERE ( COLUMNNAME = 'AR_INV_NBR' )
	  
--	SET @ret_val = @@ERROR
	
--	IF ( @ret_val = 0 )
--	BEGIN
--		IF ( @curr_assign_user IS NULL ) OR ( @billing_user_in = @curr_assign_user )
--		BEGIN
--			-- BJL 02/06/2012 - Lock the record with the current user ID
--			UPDATE dbo.ASSIGN_NBR SET [USER_ID] = @billing_user_in WHERE ( COLUMNNAME = 'AR_INV_NBR' )
--			SET @ret_val = @@ERROR
--		END
--		ELSE
--		BEGIN
--			SET @ret_val = -4					-- ! Another user has the ACCT_REC table locked
--		END	
--		SET @ar_inv_nbr = COALESCE( @ar_inv_nbr, 0 ) -- + 1
--	END
--END

--IF ( @ret_val = 0 )
--BEGIN
--	-- BJL 02/06/2012 - Get the last GLEHXACT number used
--	/* PJH 02/23/2017 - 735-1-2666 - Check Void - There is no GL transaction for voided check */
--	--SELECT @gl_xact = ( COALESCE( IDSXACT, 0 )) FROM dbo.IDS WHERE ( IDSTABLE = 'GLENTHDR' )
--	--SET @ret_val = @@ERROR
--		UPDATE IDS
--		SET @gl_xact = COALESCE( IDSXACT, 0 ),
--		IDSXACT = COALESCE( IDSXACT, 0 )
--		FROM IDS WHERE IDSTABLE = 'GLENTHDR'
				
--		SET @ret_val = @@ERROR
--END

SET @gl_xact = 0 /* PJH 02/23/2017 - Start virtual xact with 0 and increment during groupin as needed */
SET @gl_xact_def = 0 /* Set further down in processing */
SET @ar_inv_nbr = 0

--	*******************************************************************************************************************************************************
--	**** PRODUCTION ***************************************************************************************************************************************
--	*******************************************************************************************************************************************************
IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	-- BJL 11/20/2013 - Added AB_NONRESALE_AMT
	-- BJL 11/13/2013 - Added NON_RESALE_AMT
	-- EC  03/31/2013 - Fixed to get GL ACCT ACC AP account from this table to fix OOB
	-- BJL 02/07/2013 - Retrieve rows from W_AR_FUNCTION for the current billing user
	--PJH 04/07/2015 - AVATAX_KEY = @avatax_key_base + @billing_user_in , AVATAX_POSTED 
	INSERT INTO @AR_SUMMARY ( 
				AR_FUNCTION_ID, AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, 
				MANUAL_FLAG, INV_BY, JOB_NUMBER, JOB_COMPONENT_NBR, JOB_AB_FLAG, 
				AR_DESCRIPTION, DEFERRED_FLAG, AB_REC_FLAG, CL_CODE, DIV_CODE, PRD_CODE, 
				AR_DIV_CODE, AR_PRD_CODE, OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, 
				FNC_CODE, FNC_TYPE, GL_XACT, SALE_POST_PERIOD, HRS_QTY, EMP_TIME_AMT, INC_ONLY_AMT, 
				COMMISSION_AMT, COST_AMT, AB_COST_AMT, AB_INC_AMT, AB_COMMISSION_AMT, AB_SALE_AMT, 
				AB_NONRESALE_AMT, NON_RESALE_AMT, TOTAL_BILL, TAX_CODE, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, 
				CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT, INV_TAX_FLAG, MODIFIED_FLAG, SUMMARY_FLAG,
				AVATAX_KEY, AVATAX_POSTED, CURRENCY_CODE, CURRENCY_RATE, BILLING_ADDRESS )
		 SELECT af.AR_FUNCTION_ID, ( af.AR_INV_NBR + @ar_inv_nbr ), af.AR_INV_SEQ, 'IN', af.COOP_CODE, af.COOP_PCT, 
				af.MANUAL_FLAG, af.INV_BY, af.JOB_NUMBER, af.JOB_COMPONENT_NBR, af.JOB_AB_FLAG, 
				LEFT((( CASE WHEN af.COOP_CODE IS NOT NULL THEN '(Coop) ' ELSE '' END ) + 'Inv by ' ) + 
					  ( CASE af.INV_BY 
							WHEN 1 THEN 'Job/Office'
							WHEN 2 THEN 'Job Component/Office'
							WHEN 3 THEN 'Product/Sales Class/Office'
							WHEN 4 THEN 'Campaign/Office'
							WHEN 5 THEN 'Product/Client PO/Office'
							WHEN 6 THEN 'Client/Office'
							WHEN 7 THEN 'Division/Office'
							WHEN 8 THEN 'Product/Office'
							WHEN 21 THEN 'Combo Client'
							WHEN 22 THEN 'Combo Client/Division/Product'
							WHEN 23 THEN 'Combo Client/Campaign'
							WHEN 24 THEN 'Combo Client/Division/Product/Campaign'
							WHEN 25 THEN 'Combo Client/Division'  -- MJC 06/15/2016 - added client/division combo billing
							ELSE 'unknown method' END ), 40 ),
				CASE WHEN ( af.AB_REC_FLAG = 1 ) THEN 1 ELSE 0 END, af.AB_REC_FLAG, 
				af.CL_CODE, af.DIV_CODE, af.PRD_CODE, af.DIV_CODE, af.PRD_CODE, 
				af.OFFICE_CODE, af.SC_CODE, af.CMP_IDENTIFIER, af.CLIENT_PO, af.FNC_CODE, af.FNC_TYPE, 
				( af.AR_INV_NBR + @gl_xact ), af.SALE_POST_PERIOD, af.HRS_QTY, af.EMP_TIME_AMT, af.INC_ONLY_AMT, 
				af.COMMISSION_AMT, af.COST_AMT, af.AB_COST_AMT, af.AB_INC_AMT, af.AB_COMMISSION_AMT, af.AB_SALE_AMT, 
				af.AB_NONRESALE_AMT, af.NON_RESALE_AMT, af.TOTAL_BILL, af.TAX_CODE, af.CITY_TAX_AMT, af.CNTY_TAX_AMT, 
				af.STATE_TAX_AMT, af.TAX_CITY_PCT, af.TAX_COUNTY_PCT, af.TAX_STATE_PCT, 
				af.INV_TAX_FLAG, af.MODIFIED_FLAG, af.SUMMARY_FLAG,
				@avatax_key_base, CASE WHEN af.AVATAX_CALCULATED = 1 THEN 0 ELSE NULL END,
				CURRENCY_CODE, CURRENCY_RATE, af.BILLING_ADDRESS
		   FROM dbo.W_AR_FUNCTION af 
		  WHERE ( af.BILLING_USER = @billing_user_in )
		    AND ( af.FNC_TYPE IS NOT NULL )		    
		    
	SET @ret_val = @@ERROR		
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 04/19/2013
		UPDATE s
		   SET AR_DIV_CODE = NULL
		  FROM @AR_SUMMARY s
		 WHERE ( s.AR_INV_SEQ IN ( 0, @coop_master_seq ))
		 --AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
		   AND ( s.FNC_TYPE IS NOT NULL )
		   AND ( s.INV_BY = 6 )
	
		SET @ret_val = @@ERROR
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 04/19/2013
		UPDATE s
		   SET AR_PRD_CODE = NULL
		  FROM @AR_SUMMARY s
		 WHERE ( s.AR_INV_SEQ IN ( 0, @coop_master_seq ))
		 --AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
		   AND ( s.FNC_TYPE IS NOT NULL )
		   AND ( s.INV_BY IN ( 6, 7 ))
	
		SET @ret_val = @@ERROR
	END
	
	-- Production account determination
	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with AR account
			UPDATE s
			   SET GL_ACCT_AR = o.GLACODE_AR
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			 --AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
			   AND ( s.FNC_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_AR IS NULL )
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 11/13/2013 - Added NON_RESALE_AMT
			-- BJL 04/05/2013 - Update with COS account
			UPDATE s
			   SET GL_ACCT_COS = COALESCE( dbo.advfn_get_gl_acct( 42, 'P', s.OFFICE_CODE, s.SC_CODE, s.FNC_CODE, NULL ), o.PGLACODE_COS ) 
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE = 'V' )
			   AND ( s.GL_ACCT_COS IS NULL )
					-- BJL 04/29/2013
			 --AND ( s.COST_AMT <> 0.00 /*OR s.AB_COST_AMT <> 0.00*/ )					
			 --AND ( s.COST_AMT <> 0.00 OR ( s.COST_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))											-- BJL 10/24/13
			   AND ( s.NON_RESALE_AMT <> 0.00 
			      OR s.COST_AMT <> 0.00 
				  OR ( s.NON_RESALE_AMT = 0.00 AND s.COST_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))				
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with Sale account
			UPDATE s
			   SET GL_ACCT_SALE = COALESCE( dbo.advfn_get_gl_acct( 40, 'P', s.OFFICE_CODE, s.SC_CODE, s.FNC_CODE, NULL ), o.PGLACODE_SALES ) 
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
			   AND ( s.GL_ACCT_SALE IS NULL )
			   AND ( s.HAS_PROD_SALE_AMT > 0.00 OR ( s.HAS_PROD_SALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))							-- BJL 10/24/13 
			   
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with Sale account for income recognition
			UPDATE s
			   SET GL_ACCT_SALE = COALESCE( dbo.advfn_get_gl_acct( 40, 'P', s.OFFICE_CODE, s.SC_CODE, s.FNC_CODE, NULL ), o.PGLACODE_SALES ) 
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE = 'R' )
			   AND ( s.GL_ACCT_SALE IS NULL )
			   AND ( s.HAS_PROD_SALE_AMT > 0.00 OR ( s.HAS_PROD_SALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))							-- BJL 10/24/13 
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with Deferred Sale account
			UPDATE s
			   SET GL_ACCT_DEF_SALE = o.PGLACODE_DEF_SALES
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
			   AND ( s.GL_ACCT_DEF_SALE IS NULL )
			   AND (
				--	( s.AB_INC_AMT <> 0.00 OR s.AB_COMMISSION_AMT <> 0.00 OR s.AB_COST_AMT <> 0.00 )	
					( s.AB_INC_AMT <> 0.00 OR s.AB_COMMISSION_AMT <> 0.00 OR s.AB_COST_AMT <> 0.00 OR s.AB_NONRESALE_AMT <> 0.00 )		-- BJL 11/20/13
				-- OR ( s.AB_INC_AMT = 0.00 AND s.AB_COMMISSION_AMT = 0.00 AND s.AB_COST_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))			-- BJL 10/24/13 
				-- BJL 11/20/13 				
				   OR ( s.AB_INC_AMT = 0.00 AND s.AB_COMMISSION_AMT = 0.00 AND s.AB_COST_AMT = 0.00 AND s.AB_NONRESALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))		
			   AND ( s.AB_REC_FLAG = 1 )
		
		SET @ret_val = @@ERROR
	END
	
	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 06/25/2013 - Update with Deferred Sale account for income recognition
			-- BJL 08/08/2013 - Changed PROD_SALE_AMT to AB_INC_AMT
			UPDATE s
			   SET GL_ACCT_DEF_SALE = o.PGLACODE_DEF_SALES
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE = 'R' )
			   AND ( s.GL_ACCT_DEF_SALE IS NULL )
			   AND ( s.AB_INC_AMT <> 0.00 OR ( s.AB_INC_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))							-- BJL 10/24/13 
			   AND ( s.AB_REC_FLAG = 1 )
		
		SET @ret_val = @@ERROR
	END	

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with WIP account
			UPDATE s
			   SET GL_ACCT_WIP = o.PGLACODE_WIP
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE = 'V' )
			   AND ( s.GL_ACCT_WIP IS NULL )
			 --AND ( s.COST_AMT <> 0.00 OR ( s.COST_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))								-- BJL 10/24/13
			   AND ( s.COST_AMT <> 0.00 
				  OR s.NON_RESALE_AMT <> 0.00 
				  OR ( s.COST_AMT = 0.00 AND s.NON_RESALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))							-- BJL 11/13/13
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with State Tax account
			UPDATE s
			   SET GL_ACCT_STATE = COALESCE( dbo.advfn_get_gl_acct( 50, 'P', s.OFFICE_CODE, NULL, NULL, s.TAX_CODE ), o.GLACODE_STATE )
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
			   AND ( s.GL_ACCT_STATE IS NULL )
			   AND ( s.STATE_TAX_AMT <> 0.00 OR ( s.STATE_TAX_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))						-- BJL 10/24/13
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with County Tax account
			UPDATE s
			   SET GL_ACCT_COUNTY = COALESCE( dbo.advfn_get_gl_acct( 51, 'P', s.OFFICE_CODE, NULL, NULL, s.TAX_CODE ), o.GLACODE_COUNTY )
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
			   AND ( s.GL_ACCT_COUNTY IS NULL )
			   AND ( s.CNTY_TAX_AMT <> 0.00 OR ( s.CNTY_TAX_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))						-- BJL 10/24/13
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with City Tax account
			UPDATE s
			   SET GL_ACCT_CITY = COALESCE( dbo.advfn_get_gl_acct( 52, 'P', s.OFFICE_CODE, NULL, NULL, s.TAX_CODE ), o.GLACODE_CITY )
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE IN ( 'E', 'I', 'V' ))
			   AND ( s.GL_ACCT_CITY IS NULL )
			   AND ( s.CITY_TAX_AMT <> 0.00 OR ( s.CITY_TAX_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))						-- BJL 10/24/13
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with Deferred COS account 
			UPDATE s
			   SET GL_ACCT_DEF_COS = o.PGLACODE_DEF_COS
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE = 'V' )
			   AND ( s.GL_ACCT_DEF_COS IS NULL )
			 --AND ( s.AB_COST_AMT <> 0.00 OR ( s.AB_COST_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))							-- BJL 10/24/13
			   AND ( s.AB_COST_AMT <> 0.00 
			      OR s.AB_NONRESALE_AMT <> 0.00
			      OR ( s.AB_COST_AMT = 0.00 AND s.AB_NONRESALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))					-- BJL 11/20/13
			   AND ( s.AB_REC_FLAG = 1 )
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with Accrued AP account 
			UPDATE s
			   SET GL_ACCT_ACC_AP = o.PGLACODE_ACC_AP
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE = 'V' )
			   AND ( s.GL_ACCT_ACC_AP IS NULL )
			 --AND ( s.AB_COST_AMT <> 0.00 OR ( s.AB_COST_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))							-- BJL 10/24/13
			   AND ( s.AB_COST_AMT <> 0.00 
			      OR s.AB_NONRESALE_AMT <> 0.00 
			      OR ( s.AB_COST_AMT = 0.00 AND s.AB_NONRESALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))					-- BJL 11/20/13
			   AND ( s.AB_REC_FLAG IN ( 1, 2 ))																			-- BJL 10/25/13
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/05/2013 - Update with Accrued COS account 
			UPDATE s
			   SET GL_ACCT_ACC_COS = o.PGLACODE_ACC_COS
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.FNC_TYPE = 'V' )
			   AND ( s.GL_ACCT_ACC_COS IS NULL )
			 --AND ( s.AB_COST_AMT <> 0.00 OR ( s.AB_COST_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))							-- BJL 10/24/13
			   AND ( s.AB_COST_AMT <> 0.00 
			      OR s.AB_NONRESALE_AMT <> 0.00 
			      OR ( s.AB_COST_AMT = 0.00 AND s.AB_NONRESALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))					-- BJL 11/20/13
			   AND ( s.AB_REC_FLAG = 2 )
		
		SET @ret_val = @@ERROR
	END

END

--	*******************************************************************************************************************************************************
--	**** MEDIA ********************************************************************************************************************************************
--	*******************************************************************************************************************************************************
IF ( @ret_val = 0 AND @media = 1 )
BEGIN

	INSERT INTO @AR_SUMMARY ( AR_FUNCTION_ID, AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, 
			MANUAL_FLAG, ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, INV_BY, AR_DESCRIPTION, AB_REC_FLAG, MED_REC_FLAG, 
			CL_CODE, DIV_CODE, PRD_CODE, AR_DIV_CODE, AR_PRD_CODE, OFFICE_CODE, SC_CODE, MARKET_CODE, 
			CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, MEDIA_MONTH, MEDIA_YEAR, [START_DATE], [END_DATE],
			GL_XACT, GL_XACT_DEF, SALE_POST_PERIOD, INV_TAX_FLAG, HRS_QTY, BILL_COMM_NET, 
			COMMISSION_AMT, REBATE_AMT, COST_AMT, NET_CHARGE_AMT, NON_RESALE_AMT, DISCOUNT_AMT, ADDITIONAL_AMT,
			TAX_CODE, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, TOTAL_BILL, CITY_TAX_PCT, CNTY_TAX_PCT,
			STATE_TAX_PCT, MODIFIED_FLAG, SUMMARY_FLAG, CURRENCY_CODE, CURRENCY_RATE, BILLING_ADDRESS )
	 SELECT AR_FUNCTION_ID, ( AR_INV_NBR + @ar_inv_nbr ), AR_INV_SEQ, 'IN', COOP_CODE, COOP_PCT, 
			MANUAL_FLAG, ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, INV_BY, 
			-- PJH 03/07/2018 - Updated for Unit Split
			LEFT((( CASE WHEN COOP_CODE = 'units!' THEN '(Unit Split) ' WHEN COOP_CODE IS NULL THEN '' ELSE '(Coop) ' END ) + 'Inv by ' ) + 
				  ( CASE INV_BY 
						WHEN 1 THEN 'Sales Class'
						WHEN 2 THEN 'Client PO'
						WHEN 3 THEN 'Market'
						WHEN 4 THEN 'Order'
						WHEN 5 THEN 'Campaign'
						WHEN 6 THEN 'Media Type'
						WHEN 21 THEN 'Combo Client'
						WHEN 22 THEN 'Combo Client/Division/Product'
						WHEN 23 THEN 'Combo Client/Campaign'
						WHEN 24 THEN 'Combo Client/Division/Product/Campaign'
						WHEN 25 THEN 'Combo Client/Division'  -- MJC 06/15/2016 - added client/division combo billing
						ELSE 'unknown method' END ), 40 ), 
			NULL, MED_REC_FLAG, CL_CODE, DIV_CODE, PRD_CODE, DIV_CODE, PRD_CODE, OFFICE_CODE, SC_CODE, MARKET_CODE, 
			CMP_IDENTIFIER, CLIENT_PO, NULL, NULL, MEDIA_MONTH, MEDIA_YEAR, [START_DATE], [END_DATE],
			( AR_INV_NBR + @gl_xact ), NULL, SALE_POST_PERIOD, INV_TAX_FLAG, HRS_QTY, BILL_COMM_NET, COMMISSION_AMT, 
			REBATE_AMT, COST_AMT, NET_CHARGE_AMT, NON_RESALE_AMT, DISCOUNT_AMT, ADDITIONAL_AMT, TAX_CODE, 
			CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, TOTAL_BILL, TAX_CITY_PCT, TAX_COUNTY_PCT, TAX_STATE_PCT, 
			MODIFIED_FLAG, SUMMARY_FLAG, CURRENCY_CODE, CURRENCY_RATE, BILLING_ADDRESS
	   FROM dbo.W_AR_FUNCTION
	  WHERE ( BILLING_USER = @billing_user_in )
	    AND ( MEDIA_TYPE IS NOT NULL )
	
	SET @ret_val = @@ERROR				
	
	-- BJL 05/22/2013 - Used for when an invoice by type is chosen that allows divisions and products to vary
	--IF ( @ret_val = 0 )
	--BEGIN
	-- BJL 05/22/2013
	--	UPDATE s
	--	   SET AR_DIV_CODE = NULL
	--	  FROM @AR_SUMMARY s
	--	 WHERE ( s.AR_INV_SEQ IN ( 0, @coop_master_seq ))
	--	   AND ( s.MEDIA_TYPE IS NOT NULL )
	--	   AND ( s.INV_BY = )
	
	--	SET @ret_val = @@ERROR
	--END
	
	--IF ( @ret_val = 0 )
	--BEGIN
	-- BJL 05/22/2013
	--	UPDATE s
	--	   SET AR_PRD_CODE = NULL
	--	  FROM @AR_SUMMARY s
	--	 WHERE ( s.AR_INV_SEQ IN ( 0, @coop_master_seq ))
	--	   AND ( s.MEDIA_TYPE IS NOT NULL )
	--	   AND ( s.INV_BY IN ( , ))
	
	--	SET @ret_val = @@ERROR
	--END

	-- Media account determination
	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Update with Sale account
			UPDATE s
			   SET GL_ACCT_SALE = CASE 
									WHEN ( s.MED_REC_FLAG IN ( 2, 3 )) THEN o.MGLACODE_DEF_SALES
									ELSE COALESCE( dbo.advfn_get_gl_acct( 40, 'M', s.OFFICE_CODE, s.SC_CODE, NULL, NULL ), o.MGLACODE_SALES ) 
								  END	
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_SALE IS NULL )
			   AND ( s.HAS_MEDIA_SALE_AMT > 0.00 OR ( s.HAS_MEDIA_SALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))				-- BJL 10/24/13
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Update with COS account
			UPDATE s
			   SET GL_ACCT_COS = CASE 
								   WHEN ( s.MED_REC_FLAG IN ( 2, 3 )) THEN o.MGLACODE_DEF_COS 
								   ELSE COALESCE( dbo.advfn_get_gl_acct( 42, 'M', s.OFFICE_CODE, s.SC_CODE, NULL, NULL ), o.MGLACODE_COS )
								 END
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_COS IS NULL )
			   AND ( s.HAS_MEDIA_COS_AMT > 0.00 OR ( s.HAS_MEDIA_COS_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Update with WIP account
			UPDATE s
			   SET GL_ACCT_WIP = CASE
								   WHEN ( s.MED_REC_FLAG IN ( 2, 3 )) THEN o.MGLACODE_ACC_AP
								   ELSE o.MGLACODE_WIP 
								 END
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_WIP IS NULL )
			   AND ( s.HAS_MEDIA_COS_AMT > 0.00 OR ( s.HAS_MEDIA_COS_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))
		
		SET @ret_val = @@ERROR
	END	

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Deferred entry - Sale account
			UPDATE s
			   SET GL_ACCT_DEF_SALE = COALESCE( dbo.advfn_get_gl_acct( 40, 'M', s.OFFICE_CODE, s.SC_CODE, NULL, NULL ), o.MGLACODE_SALES ) 
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_DEF_SALE IS NULL )
			   AND ( s.MED_REC_FLAG > 1 )
			   AND ( s.SALE_POST_PERIOD IS NOT NULL )
			   AND ( s.HAS_MEDIA_SALE_AMT > 0.00 OR ( s.HAS_MEDIA_SALE_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))
			   		
		SET @ret_val = @@ERROR
	END
	
	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Deferred entry - COS account
			UPDATE s
			   SET GL_ACCT_DEF_COS = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', s.OFFICE_CODE, s.SC_CODE, NULL, NULL ), o.MGLACODE_COS )
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_DEF_COS IS NULL )
			   AND ( s.MED_REC_FLAG > 1 )
			   AND ( s.SALE_POST_PERIOD IS NOT NULL )
			   AND ( s.HAS_MEDIA_COS_AMT > 0.00 OR ( s.HAS_MEDIA_COS_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))
			   		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Deferred entry - ACC_AP account
			UPDATE s
			   SET GL_ACCT_ACC_AP = o.MGLACODE_WIP 
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_ACC_AP IS NULL )
			   AND ( s.MED_REC_FLAG > 1 )
			   AND ( s.SALE_POST_PERIOD IS NOT NULL )
			   AND ( s.HAS_MEDIA_COS_AMT > 0.00 OR ( s.HAS_MEDIA_COS_AMT = 0.00 AND s.TOTAL_BILL = 0.00 ))
		
		SET @ret_val = @@ERROR
	END		
	
	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Update with State Tax account
			UPDATE s
			   SET GL_ACCT_STATE = COALESCE( dbo.advfn_get_gl_acct( 50, 'M', s.OFFICE_CODE, NULL, NULL, s.TAX_CODE ), o.GLACODE_STATE )
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_STATE IS NULL )
			   AND ( s.STATE_TAX_AMT <> 0.00 )
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Update with County Tax account
			UPDATE s
			   SET GL_ACCT_COUNTY = COALESCE( dbo.advfn_get_gl_acct( 51, 'M', s.OFFICE_CODE, NULL, NULL, s.TAX_CODE ), o.GLACODE_COUNTY )
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_COUNTY IS NULL )
			   AND ( s.CNTY_TAX_AMT <> 0.00 )
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Update with City Tax account
			UPDATE s
			   SET GL_ACCT_CITY = COALESCE( dbo.advfn_get_gl_acct( 52, 'M', s.OFFICE_CODE, NULL, NULL, s.TAX_CODE ), o.GLACODE_CITY )
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_CITY IS NULL )
			   AND ( s.CITY_TAX_AMT <> 0.00 )
		
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
			-- BJL 04/08/2013 - Update with AR account
			UPDATE s
			   SET GL_ACCT_AR = o.GLACODE_AR
			  FROM @AR_SUMMARY s
		INNER JOIN dbo.OFFICE o ON ( s.OFFICE_CODE = o.OFFICE_CODE )
			 WHERE ( s.SUMMARY_FLAG = 0 )
			   AND ( s.MEDIA_TYPE IS NOT NULL )
			   AND ( s.GL_ACCT_AR IS NULL )
			   --AND ( s.TOTAL_BILL <> 0.00 )								
		
		SET @ret_val = @@ERROR
	END	

END	

--	*******************************************************************************************************************************************************
--	**** G/L (PRODUCTION) *********************************************************************************************************************************
--	*******************************************************************************************************************************************************
IF ( @production = 1 )
BEGIN

	IF ( @ret_val = 0 )
	BEGIN
		-- A/R Entries (P1) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '07 - AR', GL_ACCT_AR, @post_period, 'BL', INV_BY, 
					-- ****************************************************************************************************************************
						COALESCE( SUM( COALESCE( TOTAL_BILL, 0.00 )), 0.00 ),
					-- ****************************************************************************************************************************
					--CASE WHEN INV_BY >= 21 THEN 'Billing - Cmb Inv ' ELSE 'Billing - Prd Inv ' END + RIGHT( '00000000' + CAST( AR_INV_NBR AS varchar(8)), 8 ) + '-' + RIGHT( '000' + CAST( AR_INV_SEQ AS varchar(3)), 3 ) +
					--	' - ' + CL_CODE + '-' + COALESCE(DIV_CODE, 'N/A') + '-' + COALESCE(PRD_CODE, 'N/A'),  --PJH 05/25/2016
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( FNC_TYPE IS NOT NULL )
				AND ( GL_ACCT_AR IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_AR, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
		   --HAVING ( COALESCE( SUM( COALESCE( TOTAL_BILL, 0.00 )), 0.00 ) <> 0.00 )									-- BJL 10/24/13
	  					
		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- COS Entries (P2) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '02 - COS', GL_ACCT_COS, @post_period, 'BL', INV_BY, 
					-- ****************************************************************************************************************************
						COALESCE( SUM( COALESCE( COST_AMT, 0.00 ) + COALESCE( NON_RESALE_AMT, 0.00 )), 0.00 ),					-- BJL 11/13/2013
						--COALESCE( SUM( COALESCE( COST_AMT, 0.00 )), 0.00 ),													-- BJL 04/19/2013
						--CASE AB_REC_FLAG WHEN 2 THEN COALESCE( SUM( COALESCE( COST_AMT, 0.00 )) + SUM( COALESCE( AB_COST_AMT, 0.00 )), 0.00 )
						--						ELSE COALESCE( SUM( COALESCE( COST_AMT, 0.00 )), 0.00 )
						--END,
					-- ****************************************************************************************************************************
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
 			  WHERE ( FNC_TYPE = 'V' )
				AND ( GL_ACCT_COS IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_COS, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ, AB_REC_FLAG
	 		 
		SET @ret_val = @@ERROR 		 
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- Sales (Actuals) Entries (P5) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '01 - SALES', GL_ACCT_SALE, @post_period, 'BL', INV_BY, 
					-- ****************************************************************************************************************************
						COALESCE( SUM( COALESCE( -PROD_SALE_AMT, 0.00 )), 0.00 ),
					-- ****************************************************************************************************************************
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
			--WHERE ( FNC_TYPE IN ( 'E', 'I', 'V' ))
			  WHERE ( FNC_TYPE IS NOT NULL )
				AND ( GL_ACCT_SALE IS NOT NULL )
				AND (( AR_INV_SEQ <> @coop_master_seq ) OR ( FNC_TYPE = 'R' ))
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_SALE, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
 				 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- Deferred Sales (Actuals) Entries (P8) [entry established] 
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '08 - DEFERRED SALES', GL_ACCT_DEF_SALE, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
					-- BJL 11/13/13
						COALESCE( SUM( COALESCE( -AB_INC_AMT, 0.00 )) + 
								  SUM( COALESCE( -AB_COMMISSION_AMT, 0.00 ))  + 
								  SUM( COALESCE( -AB_COST_AMT, 0.00 )) + 
								  SUM( COALESCE( -AB_NONRESALE_AMT, 0.00 )), 0.00 ),			-- BJL 11/20/2013
						--COALESCE( SUM( COALESCE( -AB_INC_AMT, 0.00 )) + SUM( COALESCE( -AB_COMMISSION_AMT, 0.00 ))  + SUM( COALESCE( -AB_COST_AMT, 0.00 )), 0.00 ), 
					-- *********************************************************************************************************************************************
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( FNC_TYPE IS NOT NULL )
			  --AND ( FNC_TYPE IN ( 'E', 'I', 'V' ))
				AND ( GL_ACCT_DEF_SALE IS NOT NULL )
				AND (( AR_INV_SEQ <> @coop_master_seq ) OR ( FNC_TYPE = 'R' ))
				AND ( SUMMARY_FLAG = 0 )
				AND ( AB_REC_FLAG = 1 )
		   GROUP BY GL_XACT, GL_ACCT_DEF_SALE, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ, AB_REC_FLAG
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- WIP Entries (P4) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '03 - WIP', GL_ACCT_WIP, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -COST_AMT, 0.00 ) + COALESCE( -NON_RESALE_AMT, 0.00 )), 0.00 ),					-- BJL 11/13/13
						--COALESCE( SUM( COALESCE( -COST_AMT, 0.00 )), 0.00 ), 
					-- *********************************************************************************************************************************************
 					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( FNC_TYPE = 'V' )
				AND ( GL_ACCT_WIP IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_WIP, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
 			 	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- Def COS Entries (P3) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '09 - DEFERRED COS', GL_ACCT_DEF_COS, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( AB_COST_AMT, 0.00 ) + COALESCE( AB_NONRESALE_AMT, 0.00 )), 0.00 ),					-- BJL 11/20/13
						--COALESCE( SUM( COALESCE( AB_COST_AMT, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
 			  WHERE ( FNC_TYPE = 'V' )
				AND ( GL_ACCT_DEF_COS IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
				AND ( AB_REC_FLAG = 1 )
		   GROUP BY GL_XACT, GL_ACCT_DEF_COS, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ, AB_REC_FLAG
 			 	 		 
		SET @ret_val = @@ERROR 		 
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- ACC_AP Entries (P14) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '10 - ACCRUED AP', GL_ACCT_ACC_AP, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -AB_COST_AMT, 0.00 ) + COALESCE( -AB_NONRESALE_AMT, 0.00 )), 0.00 ),					-- BJL 11/20/13
						--COALESCE( SUM( COALESCE( -AB_COST_AMT, 0.00 )), 0.00 ), 
					-- *********************************************************************************************************************************************
						'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( FNC_TYPE = 'V' )
				AND ( GL_ACCT_ACC_AP IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_ACC_AP, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
	IF ( @ret_val = 0 )
	BEGIN
		-- ACC_COS Entries (P15) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '11 - ACCRUED COS', GL_ACCT_ACC_COS, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( AB_COST_AMT, 0.00 ) + COALESCE( AB_NONRESALE_AMT, 0.00 )), 0.00 ),		-- BJL 11/20/2013
						--COALESCE( SUM( COALESCE( -AB_COST_AMT, 0.00 )), 0.00 ),										-- BJL 04/19/2013
						--COALESCE( SUM( COALESCE( AB_COST_AMT, 0.00 )), 0.00 ), 
					-- *********************************************************************************************************************************************
						'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( FNC_TYPE = 'V' )
				AND ( GL_ACCT_ACC_COS IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
				AND ( AB_REC_FLAG = 2 )
		   GROUP BY GL_XACT, GL_ACCT_ACC_COS, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- State Tax Entries (P11) [entry established] 
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '04 - STATE', GL_ACCT_STATE, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -STATE_TAX_AMT, 0.00 )), 0.00 ), 
					-- *********************************************************************************************************************************************
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY ars
			  WHERE ( FNC_TYPE IN ( 'E', 'I', 'V' ))
				AND ( GL_ACCT_STATE IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_STATE, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
HAVING ( COALESCE( SUM( COALESCE( -STATE_TAX_AMT, 0.00 )), 0.00 ) <> 0.00 ) --** PJH 02/19/2015 ************************************************--*******************************************************--*******	 				   
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- County Tax Entries (P12) [entry established] 
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '05 - COUNTY', GL_ACCT_COUNTY, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -CNTY_TAX_AMT, 0.00 )), 0.00 ), 
					-- *********************************************************************************************************************************************
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY ars
			  WHERE ( FNC_TYPE IN ( 'E', 'I', 'V' ))
				AND ( GL_ACCT_COUNTY IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_COUNTY, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
HAVING ( COALESCE( SUM( COALESCE( -CNTY_TAX_AMT, 0.00 )), 0.00 ) <> 0.00 ) --** PJH 02/19/2015 ************************************************--*******************************************************--*******	 				   
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- City Tax Entries (P13) [entry established] 
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '06 - CITY', GL_ACCT_CITY, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -CITY_TAX_AMT, 0.00 )), 0.00 ), 
					-- *********************************************************************************************************************************************
					'P',  
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( FNC_TYPE IN ( 'E', 'I', 'V' )) 
				AND ( GL_ACCT_CITY IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_CITY, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, AR_INV_SEQ
HAVING ( COALESCE( SUM( COALESCE( -CITY_TAX_AMT, 0.00 )), 0.00 ) <> 0.00 ) --** PJH 02/19/2015 ************************************************--*******************************************************--*******	 				   
	 		 
		SET @ret_val = @@ERROR 		 
	END

END

--	*******************************************************************************************************************************************************
--	**** G/L (MEDIA) **************************************************************************************************************************************
--	*******************************************************************************************************************************************************
IF ( @media = 1 )
BEGIN
	-- DEBUG There seems to be a non-billable check on each entry in SQL-W
	IF ( @ret_val = 0 )
	BEGIN
		-- Sales Entries (M1) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '01 - SALES', GL_ACCT_SALE, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -MEDIA_SALE_AMT, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					--CASE WHEN INV_BY >= 21 THEN 'Billing - Cmb Inv ' ELSE 'Billing - Med Inv ' END + RIGHT( '00000000' + CAST( AR_INV_NBR AS varchar(8)), 8 ) + '-' + RIGHT( '000' + CAST( AR_INV_SEQ AS varchar(3)), 3 ) +
					--	' - ' + CL_CODE + '-' + COALESCE(DIV_CODE, 'N/A') + '-' + COALESCE(PRD_CODE, 'N/A'),  --PJH 05/25/2016
					'M',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_SALE IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_SALE, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_SEQ, ORDER_NBR
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- COS Entries (M2) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '02 - COS', GL_ACCT_COS, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( MEDIA_COS_AMT, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					'M',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_COS IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_COS, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_SEQ, ORDER_NBR
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- WIP Entries (M3) [entry established]  
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '03 - WIP', GL_ACCT_WIP, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -MEDIA_COS_AMT, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					'M',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_WIP IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_WIP, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_SEQ, ORDER_NBR
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
	IF ( @ret_val = 0 )
	BEGIN
		-- State Tax Entries (M4) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '04 - STATE', GL_ACCT_STATE, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -STATE_TAX_AMT, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					'M',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_STATE IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_STATE, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_SEQ, ORDER_NBR
HAVING ( COALESCE( SUM( COALESCE( -STATE_TAX_AMT, 0.00 )), 0.00 ) <> 0.00 )  --** PJH 02/19/2015 ************************************************--*******************************************************--*******		   
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
	IF ( @ret_val = 0 )
	BEGIN
		-- County Tax Entries (M5) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '05 - COUNTY', GL_ACCT_COUNTY, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -CNTY_TAX_AMT, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					'M',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_COUNTY IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_COUNTY, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_SEQ, ORDER_NBR
HAVING ( COALESCE( SUM( COALESCE( -CNTY_TAX_AMT, 0.00 )), 0.00 ) <> 0.00 )  --** PJH 02/19/2015 ************************************************--*******************************************************--*******	   
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
	IF ( @ret_val = 0 )
	BEGIN
		-- City Tax Entries (M6) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '06 - CITY', GL_ACCT_CITY, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( -CITY_TAX_AMT, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					'M',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_CITY IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_CITY, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_SEQ, ORDER_NBR
HAVING ( COALESCE( SUM( COALESCE( -CITY_TAX_AMT, 0.00 )), 0.00 ) <> 0.00 ) --** PJH 02/19/2015 ************************************************--*******************************************************--*******	
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
	IF ( @ret_val = 0 )
	BEGIN
		-- A/R Entries (M7) [entry established]
		INSERT INTO @GL_ENTRY ( 
					GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT GL_XACT, '07 - AR', GL_ACCT_AR, @post_period, 'BL', INV_BY, 
					-- *********************************************************************************************************************************************
						COALESCE( SUM( COALESCE( TOTAL_BILL, 0.00 )), 0.00 ),
					-- *********************************************************************************************************************************************
					'M',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ 
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_AR IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_XACT, GL_ACCT_AR, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_SEQ, ORDER_NBR
 			-- HAVING ( COALESCE( SUM( COALESCE( TOTAL_BILL, 0.00 )), 0.00 ) <> 0.00 )
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
	/* Get ready for deferred transactions - Get the max xact already used for std transactions */
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 04/09/2013 - Get the last GLEHXACT number used - used as a starting number further down
		SET @gl_xact_def = COALESCE(( SELECT MAX( GLEXACT ) FROM @GL_ENTRY ), 0 )
		SET @ret_val = @@ERROR
	END
	
--	*******************************************************************************************************************************************************
--	**** G/L (MEDIA DEFERRED) *****************************************************************************************************************************
--	*******************************************************************************************************************************************************
	--	BJL 04/10/2013 - Added new temp table for deferred to simplify getting GL_XACT_DEF's
	IF ( @ret_val = 0 )
	BEGIN
		-- COS Entries (MD1) [entry established]
		INSERT INTO @GL_ENTRY_DEF ( 
					ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT '02 - COS', GL_ACCT_COS, SALE_POST_PERIOD, 'BL', INV_BY, 
					-- **********************************************************************************************************************************
						COALESCE( SUM( COALESCE( -MEDIA_COS_AMT, 0.00 )), 0.00 ),
					-- **********************************************************************************************************************************
					--CASE WHEN INV_BY >= 21 THEN 'Billing - Cmb Inv Def ' ELSE 'Billing - Med Inv Def ' END + RIGHT( '00000000' + CAST( AR_INV_NBR AS varchar(8)), 8 ) + '-' + RIGHT( '000' + CAST( AR_INV_SEQ AS varchar(3)), 3 ) +
					--	' - ' + CL_CODE + '-' + COALESCE(DIV_CODE, 'N/A') + '-' + COALESCE(PRD_CODE, 'N/A'),  --PJH 05/25/2016
					'MD',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_COS IS NOT NULL )
				AND ( MED_REC_FLAG > 1 )
				AND ( SALE_POST_PERIOD IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_ACCT_COS, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, SALE_POST_PERIOD, ORDER_NBR, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		-- WIP Entries (MD2) [entry established]
		INSERT INTO @GL_ENTRY_DEF ( 
					ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT '03 - WIP', GL_ACCT_WIP, SALE_POST_PERIOD, 'BL', INV_BY, 
					-- **********************************************************************************************************************************
						COALESCE( SUM( COALESCE( MEDIA_COS_AMT, 0.00 )), 0.00 ),
					-- **********************************************************************************************************************************
					'MD',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_WIP IS NOT NULL )
				AND ( MED_REC_FLAG > 1 )
				AND ( SALE_POST_PERIOD IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_ACCT_WIP, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, SALE_POST_PERIOD, ORDER_NBR, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- Sales Entries (MD3) [entry established]
		INSERT INTO @GL_ENTRY_DEF ( 
					ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT '01 - SALES', GL_ACCT_SALE, SALE_POST_PERIOD, 'BL', INV_BY, 
					-- **********************************************************************************************************************************
						COALESCE( SUM( COALESCE( MEDIA_SALE_AMT, 0.00 )), 0.00 ),
					-- **********************************************************************************************************************************
					'MD',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_SALE IS NOT NULL )
				AND ( MED_REC_FLAG > 1 )
				AND ( SALE_POST_PERIOD IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_ACCT_SALE, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, SALE_POST_PERIOD, ORDER_NBR, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
	IF ( @ret_val = 0 )
	BEGIN
		-- Deferred Sales Entries (MD4) [entry established]
		INSERT INTO @GL_ENTRY_DEF ( 
					ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT '08 - DEFERRED SALES', GL_ACCT_DEF_SALE, SALE_POST_PERIOD, 'BL', INV_BY, 
					-- **********************************************************************************************************************************
						COALESCE( SUM( COALESCE( -MEDIA_SALE_AMT, 0.00 )), 0.00 ),
					-- **********************************************************************************************************************************
					'MD',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_DEF_SALE IS NOT NULL )
				AND ( MED_REC_FLAG > 1 )
				AND ( SALE_POST_PERIOD IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_ACCT_DEF_SALE, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, SALE_POST_PERIOD, ORDER_NBR, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- Accrued Deferred AP Entries (MD5) [entry established]
		-- DEBUG - Scrutinize this entry
		INSERT INTO @GL_ENTRY_DEF ( 
					ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT '00 - DEFERRED ACCRUED AP', GL_ACCT_ACC_AP, SALE_POST_PERIOD, 'BL', INV_BY, 
					-- **********************************************************************************************************************************
						COALESCE( SUM( COALESCE( -MEDIA_COS_AMT, 0.00 )), 0.00 ),
					-- **********************************************************************************************************************************
					'MD',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_ACC_AP IS NOT NULL )
				AND ( MED_REC_FLAG > 1 )
				AND ( SALE_POST_PERIOD IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_ACCT_ACC_AP, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, SALE_POST_PERIOD, ORDER_NBR, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- Accrued Deferred COS Entries (MD6) [entry established]
		INSERT INTO @GL_ENTRY_DEF ( 
					ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, GLREM, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, AR_INV_SEQ )
			 SELECT '09 - DEFERRED COS', GL_ACCT_DEF_COS, SALE_POST_PERIOD, 'BL', INV_BY, 
					-- **********************************************************************************************************************************
						COALESCE( SUM( COALESCE( MEDIA_COS_AMT, 0.00 )), 0.00 ),
					-- **********************************************************************************************************************************
					'MD',
					AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, AR_INV_SEQ
			   FROM @AR_SUMMARY
			  WHERE ( MEDIA_TYPE IS NOT NULL )
				AND ( GL_ACCT_DEF_COS IS NOT NULL )
				AND ( MED_REC_FLAG > 1 )
				AND ( SALE_POST_PERIOD IS NOT NULL )
				AND ( AR_INV_SEQ <> @coop_master_seq )
				AND ( SUMMARY_FLAG = 0 )
		   GROUP BY GL_ACCT_DEF_COS, INV_BY, AR_INV_NBR, CL_CODE, DIV_CODE, PRD_CODE, SALE_POST_PERIOD, ORDER_NBR, AR_INV_SEQ
	 		 
		SET @ret_val = @@ERROR 		 
	END	
	
--	*******************************************************************************************************************************************************
--	**** G/L TRANSACTION NUMBER ASSIGNMENT (MEDIA DEFERRED) ***********************************************************************************************
--	*******************************************************************************************************************************************************
	IF ( @ret_val = 0 )
	BEGIN
		-- Assign GL_XACT_DEF by grouping on AR_INV_NBR, ORDER_NBR, and GLPP
		INSERT INTO @GL_ENTRY ( 
				GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, 
				GLREM, AR_INV_NBR, AR_INV_SEQ, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, DEFERRED_FLAG )
		 SELECT DENSE_RANK( ) OVER ( ORDER BY AR_INV_NBR ASC, ORDER_NUMBER ASC, GLPP ASC  ) + @gl_xact_def,
				ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, INV_BY, GLETAMT, 
				GLREM, AR_INV_NBR, AR_INV_SEQ, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NUMBER, 1
		   FROM @GL_ENTRY_DEF ged

		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- Update the GL_XACT_DEF in AR_SUMMARY
		UPDATE ARS 
		   SET GL_XACT_DEF = GL.GLEXACT
		  FROM @AR_SUMMARY ARS
    INNER JOIN @GL_ENTRY GL
			ON ( ARS.AR_INV_NBR = GL.AR_INV_NBR )
		   AND ( ARS.AR_INV_SEQ = GL.AR_INV_SEQ )
		   AND ( ARS.ORDER_NBR = GL.ORDER_NUMBER )
		   AND ( ARS.SALE_POST_PERIOD = GL.GLPP )
		 WHERE ( GL.DEFERRED_FLAG = 1 )
		 
		SET @ret_val = @@ERROR
	END

END

--	*******************************************************************************************************************************************************
--	**** G/L GROUPING, SUMMARIZATION AND GLSEQ ASSIGNMENT *************************************************************************************************
--	*******************************************************************************************************************************************************
IF ( @ret_val = 0 )
BEGIN
	
	INSERT INTO @GL_ENTRY( 
				GLEXACT, GLETSEQ, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, AR_INV_NBR, AR_INV_SEQ, GLREM, 
				INV_BY, GLETAMT, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, ORDER_NUMBER, SUMMARY_ROW )
		 SELECT GLEXACT, 
				--DENSE_RANK( ) OVER ( PARTITION BY GLEXACT ORDER BY ACCT_TYPE ASC, GLACCOUNT ASC ),
				--DENSE_RANK( ) 
				--	OVER ( PARTITION BY GLEXACT ORDER BY CL_CODE ASC, DIV_CODE ASC, PRD_CODE ASC, ACCT_TYPE ASC, GLACCOUNT ASC ),
				DENSE_RANK( ) 
					OVER ( PARTITION BY GLEXACT ORDER BY CL_CODE ASC, DIV_CODE ASC, PRD_CODE ASC, AR_INV_SEQ ASC, ACCT_TYPE ASC, GLACCOUNT ASC ),
				ACCT_TYPE, 
				GLACCOUNT, 
				GLPP, 
				GLSOURCE, 
				AR_INV_NBR, 
				AR_INV_SEQ, 
				GLREM, 
				INV_BY, 
				GLETAMT, 
				CL_CODE, 
				DIV_CODE,
				PRD_CODE, 
				JOB_NUMBER, 
				ORDER_NUMBER, 
				1 
		   FROM @GL_ENTRY 
		  WHERE ( GLETSEQ IS NULL )
			AND ( SUMMARY_ROW = 0 )

	 SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	-- BJL 04/11/2013 - Eliminates rows with no entry
	DELETE FROM @GL_ENTRY WHERE SUMMARY_ROW = 0 AND GLETSEQ IS NULL
	SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	-- BJL 04/11/2013 - Assigns GLSEQ grouped by xact & account
	UPDATE @GL_ENTRY SET SUMMARY_ROW = 0 WHERE SUMMARY_ROW = 1 
    SET @ret_val = @@ERROR
END

--( SELECT gl.GLEXACT, gl.GLACCOUNT, DENSE_RANK( ) OVER ( PARTITION BY gl.GLEXACT
--										 ORDER BY gl.ACCT_TYPE ASC, gl.GLACCOUNT ASC )
--    FROM @GL_ENTRY gl )

IF ( @ret_val = 0 )
BEGIN
	-- BJL 04/11/2013 - Creates summary rows for all entries to be used for GLENTHDR rows
	INSERT INTO @GL_ENTRY( 
				GLEXACT, 
				ACCT_TYPE, 
				GLACCOUNT, 
				GLPP, 
				GLSOURCE, 
				AR_INV_NBR,
				GLREM, 
				INV_BY, 
				GLETAMT, 
				CL_CODE, 
				DIV_CODE, 
				PRD_CODE, 
				JOB_NUMBER, 
				ORDER_NUMBER, 
				SUMMARY_ROW )
		 SELECT GLEXACT, 
				ACCT_TYPE, 
				GLACCOUNT, 
				GLPP, 
				GLSOURCE, 
				AR_INV_NBR,
				MIN( GLREM ), 
				MIN( INV_BY ), 
				COALESCE( SUM( COALESCE( GLETAMT, 0.00 )), 0.00 ), 
				MIN( CL_CODE ), 
				MIN( DIV_CODE ), 
				MIN( PRD_CODE ), 
				MIN( JOB_NUMBER ), 
				MIN( ORDER_NUMBER ), 
				1
		   FROM @GL_ENTRY
	   GROUP BY GLEXACT, ACCT_TYPE, GLACCOUNT, GLPP, GLSOURCE, AR_INV_NBR

	SET @ret_val = @@ERROR 		 
END

IF ( @ret_val = 0 )
BEGIN
	-- Update back to the non-summarized rows and establish join between detail rows and summary row
	 UPDATE gl
	    SET GLETSEQ = GL.GLETSEQ
	   FROM @GL_ENTRY gl INNER JOIN @GL_ENTRY GL
		 ON ( gl.GL_ENTRY_SUM_ID = GL.GL_ENTRY_ID ) 
	  WHERE ( gl.GLETSEQ IS NULL )
	    AND ( gl.SUMMARY_ROW = 0 )
	 
	 SET @ret_val = @@ERROR
END 

-- Update the G/L sequence data back to the detail 
IF ( @ret_val = 0 )
BEGIN
	-- (P1),(M7)
	 UPDATE ars
	    SET GL_SEQ_AR = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ )
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_AR = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '07 - AR' )
		AND ( ge.SUMMARY_ROW = 0 )
		
	SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	-- (P2),(M2)
	 UPDATE ars
	    SET GL_SEQ_COS = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ )
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_COS = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '02 - COS' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.FNC_TYPE = 'V' OR ars.MEDIA_TYPE IS NOT NULL )
	  
  	SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	-- (P3)
	 UPDATE ars
	    SET GL_SEQ_DEF_COS = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ )
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_DEF_COS = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '09 - DEFERRED COS' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.FNC_TYPE = 'V' )
	  
  	SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- (MD1)
	 UPDATE ars
	    SET GL_SEQ_COS = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT_DEF = ge.GLEXACT )
 		AND ( ars.GL_ACCT_COS = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '02 - COS' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.MEDIA_TYPE IS NOT NULL )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- (MD6)
	 UPDATE ars
	    SET GL_SEQ_DEF_COS = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT_DEF = ge.GLEXACT )
 		AND ( ars.GL_ACCT_DEF_COS = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '09 - DEFERRED COS' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.MEDIA_TYPE IS NOT NULL )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	-- (P4)
	 UPDATE ars
	    SET GL_SEQ_WIP = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
 		AND ( ars.GL_ACCT_WIP = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '03 - WIP' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.FNC_TYPE = 'V' )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	-- (P14)
	 UPDATE ars
	    SET GL_SEQ_ACC_AP = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
 		AND ( ars.GL_ACCT_ACC_AP = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '10 - ACCRUED AP' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.FNC_TYPE = 'V' )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	-- (P15)
	 UPDATE ars
	    SET GL_SEQ_ACC_COS = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
 		AND ( ars.GL_ACCT_ACC_COS = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '11 - ACCRUED COS' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.FNC_TYPE = 'V' )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- (M3)
	 UPDATE ars
	    SET GL_SEQ_WIP = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
 		AND ( ars.GL_ACCT_WIP = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '03 - WIP' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.MEDIA_TYPE IS NOT NULL )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- (MD2)
	 UPDATE ars
	    SET GL_SEQ_WIP = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT_DEF = ge.GLEXACT )
 		AND ( ars.GL_ACCT_WIP = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '03 - WIP' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.MEDIA_TYPE IS NOT NULL )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- (MD5)
	 UPDATE ars
	    SET GL_SEQ_ACC_AP = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT_DEF = ge.GLEXACT )
 		AND ( ars.GL_ACCT_ACC_AP = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '00 - DEFERRED ACCRUED AP' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.MEDIA_TYPE IS NOT NULL )
	  
  	SET @ret_val = @@ERROR	  
END

IF ( @ret_val = 0 )
BEGIN
	-- (P5),(P6),(M1)
	 UPDATE ars
	    SET GL_SEQ_SALE = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_SALE = ge.GLACCOUNT )
		AND ( ge.SUMMARY_ROW = 0 )
		AND ( ge.ACCT_TYPE = '01 - SALES' )
		
	SET @ret_val = @@ERROR
END

---- BJL 04/04/2013
--IF ( @ret_val = 0 AND @production = 1 )
--BEGIN
--	-- (P7)
--	 UPDATE ars
--	    SET GL_SEQ_SALE = ge.GLETSEQ
--	   FROM @AR_SUMMARY ars
-- INNER JOIN @GL_ENTRY ge 
--		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
--		AND ( ars.JOB_NUMBER = ge.JOB_NUMBER )
--		AND ( ars.CL_CODE = ge.CL_CODE )
--		AND ( ars.DIV_CODE = ge.DIV_CODE )
--		AND ( ars.PRD_CODE = ge.PRD_CODE )
--		AND ( ars.GL_XACT = ge.GLEXACT )
--		AND ( ars.GL_ACCT_SALE = ge.GLACCOUNT )
--		AND ( ge.ACCT_TYPE = '1 - SALES' )
--	  WHERE ( ars.FNC_TYPE = 'R' )
		
--	SET @ret_val = @@ERROR
--END

IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- (MD3)
	 UPDATE ars
	    SET GL_SEQ_SALE = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT_DEF = ge.GLEXACT )
		AND ( ars.GL_ACCT_SALE = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '01 - SALES' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.MEDIA_TYPE IS NOT NULL )
		
	SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	-- (P8),(P9)
	 UPDATE ars
	    SET GL_SEQ_DEF_SALE = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_DEF_SALE = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '08 - DEFERRED SALES' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.FNC_TYPE IS NOT NULL )
		
	SET @ret_val = @@ERROR
END

---- BJL 04/04/2013
--IF ( @ret_val = 0 AND @production = 1 )
--BEGIN
--	-- (P10)
--	 UPDATE ars
--	    SET GL_SEQ_DEF_SALE = ge.GLETSEQ
--	   FROM @AR_SUMMARY ars
-- INNER JOIN @GL_ENTRY ge 
--		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
--		AND ( ars.JOB_NUMBER = ge.JOB_NUMBER )
--		AND ( ars.CL_CODE = ge.CL_CODE )
--		AND ( ars.DIV_CODE = ge.DIV_CODE )
--		AND ( ars.PRD_CODE = ge.PRD_CODE )
--		AND ( ars.GL_XACT = ge.GLEXACT )
--		AND ( ars.GL_ACCT_DEF_SALE = ge.GLACCOUNT )
--		AND ( ge.ACCT_TYPE = '8 - DEFERRED SALES' )
--	  WHERE ( ars.FNC_TYPE = 'R' )
		
--	SET @ret_val = @@ERROR
--END

IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- (MD4)
	 UPDATE ars
	    SET GL_SEQ_DEF_SALE = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT_DEF = ge.GLEXACT )
		AND ( ars.GL_ACCT_DEF_SALE = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '08 - DEFERRED SALES' )
		AND ( ge.SUMMARY_ROW = 0 )
	  WHERE ( ars.MEDIA_TYPE IS NOT NULL )
		
	SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	-- (P11),(M4)
	 UPDATE ars
	    SET GL_SEQ_STATE = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_STATE = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '04 - STATE' )
		AND ( ge.SUMMARY_ROW = 0 )
		
  	SET @ret_val = @@ERROR		
END

IF ( @ret_val = 0 )
BEGIN
	-- (P12),(M5)
	 UPDATE ars
	    SET GL_SEQ_COUNTY = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_COUNTY = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '05 - COUNTY' )
		AND ( ge.SUMMARY_ROW = 0 )
		
  	SET @ret_val = @@ERROR		
END

IF ( @ret_val = 0 )
BEGIN
	-- (P13),(M6)
	 UPDATE ars
	    SET GL_SEQ_CITY = ge.GLETSEQ
	   FROM @AR_SUMMARY ars
 INNER JOIN @GL_ENTRY ge 
		 ON ( ars.AR_INV_NBR = ge.AR_INV_NBR )
		AND ( ars.AR_INV_SEQ = ge.AR_INV_SEQ ) 
		AND ( ars.CL_CODE = ge.CL_CODE )
		AND ( ars.DIV_CODE = ge.DIV_CODE )
		AND ( ars.PRD_CODE = ge.PRD_CODE )
		AND ( ars.GL_XACT = ge.GLEXACT )
		AND ( ars.GL_ACCT_CITY = ge.GLACCOUNT )
		AND ( ge.ACCT_TYPE = '06 - CITY' )
		AND ( ge.SUMMARY_ROW = 0 )
		
  	SET @ret_val = @@ERROR		
END

/* PJH 02/23/2017
Start transaction before we get and upsate the last numbers. 
These will remain locked until the vaues are saved to the permenent tables 
*/
BEGIN TRANSACTION update_billing;

/* PJH 02/23/2017 - 735-1-2666 - Get real XACT here and replace the virtual version */
IF ( @ret_val = 0 )
BEGIN
		UPDATE IDS
		SET @gl_xact = COALESCE( IDSXACT, 0 ),
		IDSXACT = COALESCE( IDSXACT, 0 )
		FROM IDS WHERE IDSTABLE = 'GLENTHDR'
				
		SET @ret_val = @@ERROR
END

/* PJH 02/23/2017 - Get AR_INV_NBR */
IF ( @ret_val = 0 )
BEGIN
	-- BJL 02/06/2012 - Get the last invoice number assigned
	SELECT @ar_inv_nbr = [LAST_NBR], @curr_assign_user = [USER_ID] FROM dbo.ASSIGN_NBR WHERE ( COLUMNNAME = 'AR_INV_NBR' )
	  
	SET @ret_val = @@ERROR
	
	IF ( @ret_val = 0 )
	BEGIN
		IF ( @curr_assign_user IS NULL ) OR ( @billing_user_in = @curr_assign_user )
		BEGIN
			-- BJL 02/06/2012 - Lock the record with the current user ID
			UPDATE dbo.ASSIGN_NBR SET [USER_ID] = @billing_user_in WHERE ( COLUMNNAME = 'AR_INV_NBR' )
			SET @ret_val = @@ERROR
		END
		ELSE
		BEGIN
			SET @ret_val = -4					-- ! Another user has the ACCT_REC table locked
		END	
		SET @ar_inv_nbr = COALESCE( @ar_inv_nbr, 0 ) -- + 1
	END
END

/* PJH 02/23/2017 - Update virtual transactions */
/****************** The Magic begins here *********************************************************************/
UPDATE @GL_ENTRY SET GLEXACT = @gl_xact + GLEXACT, AR_INV_NBR = @ar_inv_nbr + AR_INV_NBR
--PJH 04/06/2017 - Added Deferred
UPDATE @AR_SUMMARY SET GL_XACT = @gl_xact + GL_XACT, AR_INV_NBR = @ar_inv_nbr + AR_INV_NBR, GL_XACT_DEF = @gl_xact + GL_XACT_DEF 

UPDATE @GL_ENTRY SET GLREM = CASE WHEN INV_BY >= 21 THEN 'Billing - Cmb Inv ' ELSE 'Billing - Prd Inv ' END + RIGHT( '00000000' + CAST( AR_INV_NBR AS varchar(8)), 8 ) + '-' + RIGHT( '000' + CAST( COALESCE(AR_INV_SEQ,0) AS varchar(3)), 3 ) +
	' - ' + CL_CODE + '-' + COALESCE(DIV_CODE, 'N/A') + '-' + COALESCE(PRD_CODE, 'N/A') 
WHERE GLREM = 'P'

UPDATE @GL_ENTRY SET GLREM = CASE WHEN INV_BY >= 21 THEN 'Billing - Cmb Inv ' ELSE 'Billing - Med Inv ' END + RIGHT( '00000000' + CAST( AR_INV_NBR AS varchar(8)), 8 ) + '-' + RIGHT( '000' + CAST( COALESCE(AR_INV_SEQ,0) AS varchar(3)), 3 ) +
	' - ' + CL_CODE + '-' + COALESCE(DIV_CODE, 'N/A') + '-' + COALESCE(PRD_CODE, 'N/A')
WHERE GLREM  = 'M'

UPDATE @GL_ENTRY SET GLREM = CASE WHEN INV_BY >= 21 THEN 'Billing - Cmb Inv Def ' ELSE 'Billing - Med Inv Def ' END + RIGHT( '00000000' + CAST( AR_INV_NBR AS varchar(8)), 8 ) + '-' + RIGHT( '000' + CAST( COALESCE(AR_INV_SEQ,0) AS varchar(3)), 3 ) +
	' - ' + CL_CODE + '-' + COALESCE(DIV_CODE, 'N/A') + '-' + COALESCE(PRD_CODE, 'N/A')
WHERE GLREM  = 'MD'
/****************** The Magic ends here *********************************************************************/


-- ******************************************************************************************************************************
-- **** FOR DEBUGGING USE *******************************************************************************************************
-- ******************************************************************************************************************************
--IF ( 1 = 1 )      /******************** DEBUG -  DEBUG -  DEBUG -  DEBUG -  DEBUG -  DEBUG -  DEBUG -  DEBUG ********************/
--BEGIN
--	SELECT * FROM @AR_SUMMARY
--	SELECT * FROM @GL_ENTRY /*WHERE SUMMARY_ROW = 0*/ ORDER BY 3, 4
--	--SELECT * FROM @GL_ENTRY_DEF ORDER BY 3, 4
--	SELECT SUM( A.GLETAMT ) FROM @GL_ENTRY A WHERE SUMMARY_ROW = 0 
--	SELECT 'GL_XACT: ' + CAST( @gl_xact AS char(6)) + ' GL_XACT_DEF: ' + CAST( @gl_xact_def AS char(6))
--	SET @ret_val = -1111
--END

-- ******************************************************************************************************************************
-- **** VALIDATE DATA ***********************************************************************************************************
-- ******************************************************************************************************************************
IF ( @ret_val = 0 )
BEGIN
	SELECT @row_ct = ( SELECT COUNT(*) 
						 FROM @GL_ENTRY A
						WHERE ( A.SUMMARY_ROW = 1 )
					 GROUP BY A.GLEXACT 
					   HAVING ( SUM( A.GLETAMT ) <> 0.00 ))
					   
  	SET @ret_val = @@ERROR
 	IF ( @row_ct > 0 )
  		SET @ret_val = -6											-- ! Out of balance
END

IF ( @ret_val = 0 )
BEGIN
	IF EXISTS ( SELECT 1 FROM @GL_ENTRY A WHERE ( A.SUMMARY_ROW = 0 ) GROUP BY A.GLEXACT HAVING ( COALESCE( SUM( A.GLETAMT ), 0.00 ) <> 0.00 ))
  	SET @ret_val = @@ERROR
 	IF ( @row_ct > 0 )
  		SET @ret_val = -6											-- ! Out of balance
END

IF ( @ret_val = 0 )
BEGIN
	IF ( @ret_val = 0 ) AND EXISTS( SELECT 1 FROM @GL_ENTRY A WHERE ( A.SUMMARY_ROW = 0 AND ( A.GLEXACT = 0 OR A.GLEXACT IS NULL )))
  		SET @ret_val = -7											-- ! Invalid transaction

	IF ( @ret_val = 0 ) AND EXISTS( SELECT 1 FROM @GL_ENTRY A WHERE ( A.SUMMARY_ROW = 0 AND ( A.GLETSEQ = 0 OR A.GLETSEQ IS NULL )))
  		SET @ret_val = -8											-- ! Invalid sequence

	IF ( @ret_val = 0 ) AND EXISTS( SELECT 1 FROM @GL_ENTRY A WHERE ( A.SUMMARY_ROW = 0 AND A.GLSOURCE IS NULL ))
		SET @ret_val = -9											-- ! Invalid source

	--DEBUG missing a non billable check???
	IF ( @ret_val = 0 ) AND EXISTS( SELECT 1 FROM @GL_ENTRY A WHERE ( A.SUMMARY_ROW = 0 AND A.GLETAMT IS NULL ))
		SET @ret_val = -10											-- ! Invalid GL amount

	--DEBUG include an inactive check on this (and others)???
	IF ( @ret_val = 0 ) AND EXISTS( SELECT 1 FROM @GL_ENTRY A WHERE ( A.SUMMARY_ROW = 0 AND A.GLPP NOT IN ( SELECT PPPERIOD FROM dbo.POSTPERIOD /*WHERE ?*/ )))
		SET @ret_val = -11											-- ! Invalid posting period

END

/* 02/23/2017 - do not need this transaction any longer */
--IF ( @@TRANCOUNT > 0 )
--BEGIN
--	IF ( @ret_val = 0  )
--		COMMIT TRANSACTION populate_billing;  
--	ELSE
--		ROLLBACK TRANSACTION populate_billing;
--END		

-- ******************************************************************************************************************************
-- **** UPDATE PERMANENT TABLES *************************************************************************************************
-- ******************************************************************************************************************************
IF ( @ret_val = 0 AND @update_on = 1 )
BEGIN
	/* 02/23/2017 - this was moved to above */
	--BEGIN TRANSACTION update_billing;	

	IF ( @ret_val = 0 )
	BEGIN		
		 INSERT INTO dbo.GLENTHDR ( GLEHXACT, GLEHPP, GLEHUSER, GLEHENTDATE, GLEHMODDATE, GLEHSOURCE, GLEHDESC, CREATE_DATE )
			  SELECT GL.GLEXACT, GL.GLPP, @user_code, getdate( ), getdate( ), GL.GLSOURCE,
					 LEFT( 'Client Billing - ' + CONVERT( varchar(25), getdate( ), 100 ) + ' Client Code: ' + COALESCE( MAX( GL.CL_CODE ), '' ), 100 ), GETDATE()
			    FROM @GL_ENTRY GL
			   WHERE ( GL.SUMMARY_ROW = 1 )
			GROUP BY GL.GLEXACT, GL.GLPP, GL.GLSOURCE

		 SET @ret_val = @@ERROR
	END
--PJH DEBUG	
--SELECT GL.GLEXACT, GL.GLETSEQ, GL.GLACCOUNT, SUM( GL.GLETAMT ), SUM( GL.GLETAMT ), 
--	 GL.GLREM, GL.GLSOURCE, GL.CL_CODE, GL.DIV_CODE, GL.PRD_CODE 
--FROM @GL_ENTRY GL
--WHERE ( GL.SUMMARY_ROW = 0 )
--GROUP BY GL.GLEXACT, GL.GLETSEQ, GL.GLACCOUNT, GL.GLREM, GL.GLSOURCE, GL.CL_CODE, GL.DIV_CODE, GL.PRD_CODE 	
	
	IF ( @ret_val = 0 )
	BEGIN
		 INSERT INTO dbo.GLENTTRL ( GLETXACT, GLETSEQ, GLETCODE, GLETAMT, GLETFCAMT, GLETREM, GLETSOURCE, CL_CODE, DIV_CODE, PRD_CODE ) 
			  SELECT GL.GLEXACT, GL.GLETSEQ, GL.GLACCOUNT, SUM( GL.GLETAMT ), SUM( GL.GLETAMT ), 
					 GL.GLREM, GL.GLSOURCE, GL.CL_CODE, GL.DIV_CODE, GL.PRD_CODE 
			    FROM @GL_ENTRY GL
			   WHERE ( GL.SUMMARY_ROW = 0 )
			GROUP BY GL.GLEXACT, GL.GLETSEQ, GL.GLACCOUNT, GL.GLREM, GL.GLSOURCE, GL.CL_CODE, GL.DIV_CODE, GL.PRD_CODE 
		 
		 SET @ret_val = @@ERROR
	END	
	
	/*
	Production
	( CASE af.INV_BY 
		WHEN 1 THEN 'Job/Office'
		WHEN 2 THEN 'Job Component/Office'
		WHEN 3 THEN 'Product/Sales Class/Office'
		WHEN 4 THEN 'Campaign/Office'
		WHEN 5 THEN 'Product/Client PO/Office'
		WHEN 6 THEN 'Client/Office'
		WHEN 7 THEN 'Division/Office'
		WHEN 8 THEN 'Product/Office'
		WHEN 21 THEN 'Combo Client'
		WHEN 22 THEN 'Combo Client/Division/Product'
		WHEN 23 THEN 'Combo Client/Campaign'
		WHEN 24 THEN 'Combo Client/Division/Product/Campaign'

	Media
	( CASE INV_BY 
		WHEN 1 THEN 'Sales Class'
		WHEN 2 THEN 'Client PO'
		WHEN 3 THEN 'Market'
		WHEN 4 THEN 'Order'
		WHEN 5 THEN 'Campaign'
		WHEN 6 THEN 'Media Type'
		WHEN 21 THEN 'Combo Client'
		WHEN 22 THEN 'Combo Client/Division/Product'
		WHEN 23 THEN 'Combo Client/Campaign'
		WHEN 24 THEN 'Combo Client/Division/Product/Campaign'
	*/
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 04/17/2013 - Changed to use AR_DIV_CODE and AR_PRD_CODE
		-- BJL 04/10/2013 - This statement handles all media and all of production except the coop master record.
		-- EC  03/31/2013 - AR Cost Amount was including the AB Cost Amount causing it to be 0 in the ACCT REC Table.  Removed AB Cost Amount from Sum.
		-- EC  03/31/2013 - AR Advance Amount was not including the AB COMMISSION Amount.  Fixed to include that column.
		-- PJH 04/07/2015 - Clear Div/Prd if INV_BY precludes their use
		-- MJC 06/15/2016 - added client/division combo billing - clear PRD_CODE if INV_BY = 25
		
		--PJH 09/06/2016 - Use @AR_SUMMARY2 to update ACCT_REC
		INSERT INTO @AR_SUMMARY2
		SELECT * FROM @AR_SUMMARY		

		-- PJH 05/25/2016 - Choose Campaign or Job Cli/Div/Prd - Production
		-- PJH 06/12/2017 - Added  AND A.AR_INV_SEQ = 0 - Don't update Coop records
		IF ( @ret_val = 0 )
		BEGIN
			UPDATE A
			SET A.CL_CODE = B.CL_CODE, A.DIV_CODE = B.DIV_CODE, A.PRD_CODE = B.PRD_CODE, A.AR_DIV_CODE = B.DIV_CODE, A.AR_PRD_CODE = B.PRD_CODE
			FROM @AR_SUMMARY2 A INNER JOIN CAMPAIGN B ON A.CMP_IDENTIFIER = B.CMP_IDENTIFIER
			WHERE COALESCE(A.MEDIA_TYPE, 'P') = 'P' AND A.INV_BY IN (4,23,24) AND A.AR_INV_SEQ = 0
							
			SET @ret_val = @@ERROR
		END	

		-- PJH 05/25/2016 - Choose Campaign or Job Cli/Div/Prd - Media
		-- PJH 06/12/2017 - Added  AND A.AR_INV_SEQ = 0 - Don't update Coop records
		IF ( @ret_val = 0 )
		BEGIN
			UPDATE A
			SET A.CL_CODE = B.CL_CODE, A.DIV_CODE = B.DIV_CODE, A.PRD_CODE = B.PRD_CODE, A.AR_DIV_CODE = B.DIV_CODE, A.AR_PRD_CODE = B.PRD_CODE
			FROM @AR_SUMMARY2 A INNER JOIN CAMPAIGN B ON A.CMP_IDENTIFIER = B.CMP_IDENTIFIER
			WHERE COALESCE(A.MEDIA_TYPE, '') > '' AND A.INV_BY IN (5,23,24)  AND A.AR_INV_SEQ = 0
							
			SET @ret_val = @@ERROR
		END	

		-- PJH 07/20/2015 - Clear Div/Prd if INV_BY precludes their use - Only in ACCT_REC INSERT - Leave @AR_SUMMARY for later use
		-- MJC 01/27/2016 - added Clear Div/Prd if INV_BY precludes their use when COMBO billing [added 21,23 when checking ars.INV_BY]
		-- PJH 05/25/2016 - Changed 'P' DIV_CODE (INV_BY) from (4,6,21,23) to (6,21) - Changed 'M' (INV_BY) from (6,21,23) to (6,21) 
		-- PJH 05/25/2016 - Changed 'P' PRD_CODE (INV_BY) from (4,6,7,21,23) to (6,7,21) - Changed 'M' (INV_BY) from (6,21,23) to (6,21) 
			--OLD
				--CASE WHEN (COALESCE( ( MAX(ars.MEDIA_TYPE) ), 'P' ) = 'P' AND MAX(ars.INV_BY) IN (4,6,21,23) OR 
				--			COALESCE( ( MAX(ars.MEDIA_TYPE) ), '' ) > '' AND MAX(ars.INV_BY) IN (6,21,23)) THEN NULL ELSE MAX( ars.AR_DIV_CODE ) END AS DIV_CODE,
				--CASE WHEN (COALESCE( ( MAX(ars.MEDIA_TYPE) ), 'P' ) = 'P' AND MAX(ars.INV_BY) IN (4,6,7,21,23) OR 
				--			COALESCE( ( MAX(ars.MEDIA_TYPE) ), '' ) > '' AND MAX(ars.INV_BY) IN (6,21,23)) THEN NULL ELSE MAX( ars.AR_PRD_CODE ) END AS PRD_CODE,


		-- MJC 06/15/2016 - added client/division combo billing - clear PRD_CODE if INV_BY = 25
		
		-- PJH 05/25/2016 - Clear Div - Production
		IF ( @ret_val = 0 )
		BEGIN
			UPDATE A
			SET A.DIV_CODE = NULL, A.AR_DIV_CODE = NULL
			FROM @AR_SUMMARY2 A
			WHERE COALESCE(A.MEDIA_TYPE, 'P') = 'P' AND A.INV_BY IN (6,21)
							
			SET @ret_val = @@ERROR
		END	

		-- PJH 05/25/2016 - Clear Div - Media
		IF ( @ret_val = 0 )
		BEGIN
			UPDATE A
			SET A.DIV_CODE = NULL, A.AR_DIV_CODE = NULL
			FROM @AR_SUMMARY2 A
			WHERE COALESCE(A.MEDIA_TYPE, '') > '' AND A.INV_BY IN (6,21)
							
			SET @ret_val = @@ERROR
		END	

		-- PJH 05/25/2016 - Clear Prd - Production
		IF ( @ret_val = 0 )
		BEGIN
			UPDATE A
			SET A.PRD_CODE = NULL, A.AR_PRD_CODE = NULL
			FROM @AR_SUMMARY2 A
			WHERE COALESCE(A.MEDIA_TYPE, 'P') = 'P' AND A.INV_BY IN (6,7,21,25)
							
			SET @ret_val = @@ERROR
		END	

		-- PJH 05/25/2016 - Clear Prd - Media
		IF ( @ret_val = 0 )
		BEGIN
			UPDATE A
			SET A.PRD_CODE = NULL, A.AR_PRD_CODE = NULL
			FROM @AR_SUMMARY2 A
			WHERE COALESCE(A.MEDIA_TYPE, '') > '' AND A.INV_BY IN (6,21,25)
							
			SET @ret_val = @@ERROR
		END	
		
		-- MJC 12/20/2018 - set BILLING_ADDRESS to non-null value for matching AR_INV_NBRs
		IF ( @ret_val = 0 )
		BEGIN
			UPDATE A
			SET A.BILLING_ADDRESS = (SELECT TOP 1 BILLING_ADDRESS FROM @AR_SUMMARY2 WHERE AR_INV_NBR = A.AR_INV_NBR AND COALESCE(BILLING_ADDRESS,'') <> '')
			FROM @AR_SUMMARY2 A
			WHERE COALESCE(A.BILLING_ADDRESS, '') = ''
							
			SET @ret_val = @@ERROR
		END	

		IF ( @ret_val = 0 )
		BEGIN		
			 INSERT INTO dbo.ACCT_REC ( 
						AR_INV_NBR, AR_INV_SEQ, AR_TYPE, AR_INV_DATE, CL_CODE, DIV_CODE, PRD_CODE, 
						OFFICE_CODE, AR_DESCRIPTION, AR_POST_PERIOD, GLACODE_AR, GLEXACT, GLESEQ_AR, 
						CMP_CODE, SC_CODE, JOB_NUMBER, PRD_PO_NBR, USERID, CREATE_DATE, REC_TYPE, 
						AR_INV_AMOUNT, AR_COS_AMT, AR_STATE_AMT, AR_COUNTY_AMT, AR_CITY_AMT, 
						AR_EMP_TIME, AR_IO_AMT, AR_COMM_AMT, AR_ADVANCE_AMT, CURRENCY_CODE, CURRENCY_RATE, EXCHANGE_AMOUNT, BILLING_ADDRESS )
				 SELECT ars.AR_INV_NBR, ars.AR_INV_SEQ, 'IN', @inv_date, MAX( ars.CL_CODE ), 
						MAX( ars.AR_DIV_CODE ), MAX( ars.AR_PRD_CODE ), -- PJH 05/25/2016 - Use MAX again
						MAX( ars.OFFICE_CODE ), MAX( ars.AR_DESCRIPTION ), @post_period, MAX( ars.GL_ACCT_AR ), MAX( ars.GL_XACT ), MAX( ars.GL_SEQ_AR ), 
						CASE 
							WHEN MIN( ars.CMP_IDENTIFIER ) = MAX( ars.CMP_IDENTIFIER ) THEN 
								( SELECT DISTINCT CMP_CODE FROM dbo.CAMPAIGN WHERE CMP_IDENTIFIER = MAX( ars.CMP_IDENTIFIER ))
							ELSE NULL 
						END, 
						MAX( ars.SC_CODE ), MAX( ars.JOB_NUMBER ), NULL, @user_code, getdate( ), 
						CASE WHEN MAX( ars.INV_BY ) >= 21 THEN 'C' ELSE COALESCE( MAX( ars.MEDIA_TYPE ), 'P' ) END,
						SUM( COALESCE( ars.TOTAL_BILL, 0.00 )),
						-- BJL 11/13/13
						SUM( COALESCE(( CASE 
											WHEN ars.FNC_TYPE IS NULL THEN ars.MEDIA_COS_AMT 
																	  ELSE ( ars.COST_AMT + ars.NON_RESALE_AMT )
										END ), 0.00 )), 
						--SUM( COALESCE(( CASE WHEN ars.FNC_TYPE IS NULL THEN ars.MEDIA_COS_AMT ELSE ars.COST_AMT END ), 0.00 )), 									
						SUM( COALESCE( ars.STATE_TAX_AMT, 0.00 )), 
						SUM( COALESCE( ars.CNTY_TAX_AMT, 0.00 )), 
						SUM( COALESCE( ars.CITY_TAX_AMT, 0.00 )), 
						SUM( COALESCE( ars.EMP_TIME_AMT, 0.00 )), 
						SUM( COALESCE( ars.INC_ONLY_AMT, 0.00 )), 
						-- BJL 04/12/13 - Added rebate amount
						SUM( COALESCE( ars.COMMISSION_AMT, 0.00 ) + COALESCE( ars.REBATE_AMT, 0.00 )),
						-- BJL 11/20/13
						SUM( COALESCE( ars.AB_COST_AMT, 0.00 ) + 
							 COALESCE( ars.AB_INC_AMT, 0.00 ) + 
							 COALESCE( ars.AB_COMMISSION_AMT, 0.00 ) + 
							 COALESCE( ars.AB_NONRESALE_AMT, 0.00 )),
						--SUM( COALESCE( ars.AB_COST_AMT, 0.00 ) + COALESCE( ars.AB_INC_AMT, 0.00 ) + COALESCE( ars.AB_COMMISSION_AMT, 0.00 ))
						MAX(ars.CURRENCY_CODE),
						MAX(ars.CURRENCY_RATE),
						SUM( COALESCE( ars.TOTAL_BILL, 0.00 )) * MAX(ars.CURRENCY_RATE) - SUM( COALESCE( ars.TOTAL_BILL, 0.00 )),
						ars.BILLING_ADDRESS
				   FROM @AR_SUMMARY2 ars 
				  WHERE ( ars.AR_INV_SEQ <> @coop_master_seq )
					AND ( ars.SUMMARY_FLAG = 0 )
				-- BJL 04/10/2013 - The GL codes were removed from the master co-op record.
				  --AND ( ars.GL_ACCT_AR IS NOT NULL )
			   GROUP BY ars.AR_INV_NBR, ars.AR_INV_SEQ, BILLING_ADDRESS
						--ars.CL_CODE, ars.AR_DIV_CODE, ars.AR_PRD_CODE,					--PJH 08/01/2013 Per EC - Also added MAX( ) to Select
						--ars.OFFICE_CODE, ars.MEDIA_TYPE, ars.GL_ACCT_AR, ars.GL_XACT		--PJH 08/01/2013 Per EC - Also added MAX( ) to Select
						--ars.AR_DESCRIPTION, ars.SC_CODE									--BJL ??
						
			SET @ret_val = @@ERROR
		END 
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- EC  03/31/2013 - AR Cost Amount was including the AB Cost Amount causing it to be 0 in the ACCT REC Table.  Removed AB Cost Amount from Sum.
		-- EC  03/31/2013 - AR Advance Amount was not including the AB COMMISSION Amount.  Fixed to include that column.
		-- BJL 04/17/2013 - Did not change to use AR_DIV_CODE and AR_PRD_CODE because the production co-op master does not get an invoice assigned.
		-- EC	Q: What is the case for this vs the one above?  
		-- BJL	A: This statement handles the master co-op ACCT_REC record. 
		INSERT INTO dbo.ACCT_REC ( 
					AR_INV_NBR, AR_INV_SEQ, AR_TYPE, AR_INV_DATE, CL_CODE, DIV_CODE, PRD_CODE, 
					OFFICE_CODE, AR_DESCRIPTION, AR_POST_PERIOD, GLACODE_AR, GLEXACT, GLESEQ_AR, 
					CMP_CODE, SC_CODE, JOB_NUMBER, PRD_PO_NBR, USERID, CREATE_DATE, REC_TYPE,
					AR_INV_AMOUNT, AR_COS_AMT, AR_STATE_AMT, AR_COUNTY_AMT, AR_CITY_AMT, 
					AR_EMP_TIME, AR_IO_AMT, AR_COMM_AMT, AR_ADVANCE_AMT, CURRENCY_CODE, CURRENCY_RATE, EXCHANGE_AMOUNT, BILLING_ADDRESS )
			 SELECT arm.AR_INV_NBR, @coop_master_seq, 'IN', @inv_date, MAX( arm.CL_CODE ), MAX( arm.AR_DIV_CODE ), MAX( arm.AR_PRD_CODE ), 
					MAX( arm.OFFICE_CODE ), MAX( arm.AR_DESCRIPTION ), @post_period, MIN( arm.GL_ACCT_AR ), MAX( arm.GL_XACT ), NULL, 
					NULL, MAX( arm.SC_CODE ), MAX( arm.JOB_NUMBER ), NULL, @user_code, getdate( ), 
					CASE WHEN MAX( arm.INV_BY ) >= 21 THEN 'C' ELSE COALESCE( MAX( arm.MEDIA_TYPE ), 'P' ) END,
					SUM( COALESCE( arm.TOTAL_BILL, 0.00 )), 
					-- BJL 11/13/13
					SUM( COALESCE(( CASE 
										WHEN arm.FNC_TYPE IS NULL THEN arm.MEDIA_COS_AMT 
																  ELSE ( arm.COST_AMT + arm.NON_RESALE_AMT )
									END ), 0.00 )), 
					--SUM( COALESCE( arm.COST_AMT, 0.00 )), 
					--SUM( COALESCE(( CASE WHEN arm.FNC_TYPE IS NULL THEN arm.MEDIA_COS_AMT ELSE arm.COST_AMT END ), 0.00 )), 
					SUM( COALESCE( arm.STATE_TAX_AMT, 0.00 )), 
					SUM( COALESCE( arm.CNTY_TAX_AMT, 0.00 )), 
					SUM( COALESCE( arm.CITY_TAX_AMT, 0.00 )), 
					SUM( COALESCE( arm.EMP_TIME_AMT, 0.00 )), 
					SUM( COALESCE( arm.INC_ONLY_AMT, 0.00 )), 
					-- BJL 04/12/13 - Added rebate amount
					SUM( COALESCE( arm.COMMISSION_AMT, 0.00 ) + COALESCE( arm.REBATE_AMT, 0.00 )),
					-- BJL 11/20/13
					SUM( COALESCE( arm.AB_COST_AMT, 0.00 ) + 
						 COALESCE( arm.AB_INC_AMT, 0.00 ) + 
						 COALESCE( arm.AB_COMMISSION_AMT, 0.00 ) + 
						 COALESCE( arm.AB_NONRESALE_AMT, 0.00 )),
					--SUM( COALESCE( arm.AB_COST_AMT, 0.00 ) + COALESCE( arm.AB_INC_AMT, 0.00 ) + COALESCE( arm.AB_COMMISSION_AMT, 0.00 ))
					MAX(arm.CURRENCY_CODE),
					MAX(arm.CURRENCY_RATE),
					SUM( COALESCE( arm.TOTAL_BILL, 0.00 )) * MAX(arm.CURRENCY_RATE) - SUM( COALESCE( arm.TOTAL_BILL, 0.00 )),
					BILLING_ADDRESS
			   FROM @AR_SUMMARY2 arm
			  WHERE ( arm.AR_INV_SEQ = @coop_master_seq )
			-- BJL 04/10/2013 - The GL codes were removed from the master co-op record.
			   --AND ( arm.GL_ACCT_AR IS NOT NULL )
		   GROUP BY arm.AR_INV_NBR, BILLING_ADDRESS
					--arm.CL_CODE, arm.AR_DIV_CODE, arm.AR_PRD_CODE,		--PJH 08/01/2013 Per EC - Also added MAX( ) to Select
					--arm.OFFICE_CODE, arm.MEDIA_TYPE, arm.GL_XACT			--PJH 08/01/2013 Per EC - Also added MAX( ) to Select
					--AR_DESCRIPTION, SC_CODE								--BJL ??
		 
		 SET @ret_val = @@ERROR
		 
		IF EXISTS(SELECT 1 FROM dbo.AGENCY WHERE INV_TAX_FLAG = 1) BEGIN
			UPDATE ar SET AR_STATE_AMT = SUM_STATE, AR_COUNTY_AMT = SUM_COUNTY, AR_CITY_AMT = SUM_CITY, AR_INV_AMOUNT = SUM_TOT
			FROM dbo.ACCT_REC ar
				INNER JOIN (
							SELECT SUM_STATE = SUM(ar.AR_STATE_AMT), SUM_COUNTY = SUM(ar.AR_COUNTY_AMT), SUM_CITY = SUM(ar.AR_CITY_AMT), SUM_TOT = SUM(ar.AR_INV_AMOUNT), ar.AR_INV_NBR
							FROM dbo.ACCT_REC ar
							WHERE ar.AR_INV_NBR IN (SELECT DISTINCT AR_INV_NBR FROM @AR_SUMMARY2)
							AND ar.AR_INV_SEQ <> @coop_master_seq
							GROUP BY ar.AR_INV_NBR
							) dtl ON ar.AR_INV_NBR = dtl.AR_INV_NBR AND ar.AR_INV_SEQ = @coop_master_seq

			SET @ret_val = @@ERROR
		END

	END
	
	IF ( @production = 1 )
	BEGIN
			
		IF ( @ret_val = 0 )
		BEGIN		
			 INSERT INTO dbo.ARINV_JOB ( AR_INV_NBR, AR_INV_DATE, JOB_NUMBER, JOB_COMPONENT_NBR, AR_TYPE, AR_INV_SEQ )
				  SELECT DISTINCT AR_INV_NBR, @inv_date, JOB_NUMBER, JOB_COMPONENT_NBR, 'IN', AR_INV_SEQ
					FROM @AR_SUMMARY										
				   WHERE ( AR_INV_SEQ IN ( 0, @coop_master_seq ))
					 AND ( FNC_TYPE IS NOT NULL )
			 
			 SET @ret_val = @@ERROR
		END
		
		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013
			 UPDATE etd
				SET GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_CNTY = ars.GL_ACCT_COUNTY, 
					GLACODE_CITY = ars.GL_ACCT_CITY
			   FROM dbo.EMP_TIME_DTL etd
		 INNER JOIN	@AR_SUMMARY ars
				 ON ( etd.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( etd.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( etd.FNC_CODE = ars.FNC_CODE )	 
				AND ( etd.TAX_CODE = ars.TAX_CODE ) 
			  WHERE ( etd.BILLING_USER = @billing_user_in )
			    AND ( etd.AR_INV_NBR IS NULL )
				AND ( ars.FNC_TYPE = 'E' )	
				AND ( ars.INV_TAX_FLAG = 0 )					
				AND ( ars.SUMMARY_FLAG = 0 )			
				AND ( etd.BILL_HOLD_FLG IS NULL OR etd.BILL_HOLD_FLG = 0 )
				
			SET @ret_val = @@ERROR			
		END 			
				
		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013 - Always update the AR_INV_NBR last
			 UPDATE etd
				SET AR_INV_NBR = ars.AR_INV_NBR, 
					AR_TYPE = 'IN', 
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),
					GLEXACT_BILL = ars.GL_XACT, 
					GLACODE_SALES = ars.GL_ACCT_SALE
			   FROM dbo.EMP_TIME_DTL etd
		 INNER JOIN	@AR_SUMMARY ars
				 ON ( etd.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( etd.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( etd.FNC_CODE = ars.FNC_CODE )	 
			  WHERE ( etd.BILLING_USER = @billing_user_in )
				AND ( etd.AR_INV_NBR IS NULL )
				AND ( ars.FNC_TYPE = 'E' )						
				AND ( ars.SUMMARY_FLAG = 0 )			
				AND ( etd.BILL_HOLD_FLG IS NULL OR etd.BILL_HOLD_FLG = 0 )
				
			SET @ret_val = @@ERROR			
		END 			
		
		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013
			 UPDATE inc
				SET	GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_CNTY = ars.GL_ACCT_COUNTY, 
					GLACODE_CITY = ars.GL_ACCT_CITY
			   FROM dbo.INCOME_ONLY inc
		 INNER JOIN @AR_SUMMARY ars
				 ON ( inc.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( inc.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( inc.FNC_CODE = ars.FNC_CODE )	
				AND ( inc.TAX_CODE = ars.TAX_CODE ) 
			  WHERE ( inc.BILLING_USER = @billing_user_in )
			    AND ( inc.AR_INV_NBR IS NULL )
				AND ( ars.FNC_TYPE = 'I' )		
				AND ( ars.INV_TAX_FLAG = 0 )				
				AND ( ars.SUMMARY_FLAG = 0 )
				AND ( inc.BILL_HOLD_FLAG IS NULL OR inc.BILL_HOLD_FLAG = 0 )
		
			SET @ret_val = @@ERROR			
		END 		

		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013 - Always update the AR_INV_NBR last
			 UPDATE inc
				SET	AR_INV_NBR = ars.AR_INV_NBR, 
					AR_TYPE = 'IN', 
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ), 
					GLEXACT_BILL = ars.GL_XACT,
					GLACODE_SALES = ars.GL_ACCT_SALE
			   FROM dbo.INCOME_ONLY inc
		 INNER JOIN @AR_SUMMARY ars
				 ON ( inc.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( inc.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( inc.FNC_CODE = ars.FNC_CODE )	
			  WHERE ( inc.BILLING_USER = @billing_user_in )
				AND ( inc.AR_INV_NBR IS NULL )
				AND ( ars.FNC_TYPE = 'I' )						
				AND ( ars.SUMMARY_FLAG = 0 )
				AND ( inc.BILL_HOLD_FLAG IS NULL OR inc.BILL_HOLD_FLAG = 0 )
		
			SET @ret_val = @@ERROR			
		END 		
				
		IF ( @ret_val = 0 )
		BEGIN
			 -- BJL 11/22/2013 - Separated from below to allow updating resale tax accounts
			 UPDATE ap
				SET	GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_CNTY = ars.GL_ACCT_COUNTY,  
					GLACODE_CITY = ars.GL_ACCT_CITY
			   FROM dbo.AP_PRODUCTION ap
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ap.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ap.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ap.FNC_CODE = ars.FNC_CODE )
			    AND ( ap.TAX_CODE = ars.TAX_CODE )
			  WHERE ( ap.BILLING_USER = @billing_user_in )
			    AND ( ap.AR_INV_NBR IS NULL )
			    AND ( ars.FNC_TYPE = 'V' )
			    AND ( ars.INV_TAX_FLAG = 0 )
  				AND ( ars.SUMMARY_FLAG = 0 )
  				AND ( ap.AP_PROD_BILL_HOLD IS NULL OR ap.AP_PROD_BILL_HOLD = 0 )

			SET @ret_val = @@ERROR			
		END 		

		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013 - Always update the AR_INV_NBR last
			 UPDATE ap
				SET	AR_INV_NBR = ars.AR_INV_NBR, 
					AR_TYPE = 'IN', 
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),
					GLEXACT_BILL = ars.GL_XACT, 
					GLACODE_SALES = ars.GL_ACCT_SALE, 
					GLACODE_COS = ars.GL_ACCT_COS
			   FROM dbo.AP_PRODUCTION ap
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ap.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ap.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ap.FNC_CODE = ars.FNC_CODE )
			  WHERE ( ap.BILLING_USER = @billing_user_in )
  				AND ( ap.AR_INV_NBR IS NULL )
  				AND ( ars.FNC_TYPE = 'V' )			
  				AND ( ars.SUMMARY_FLAG = 0 )
  				AND ( ap.AP_PROD_BILL_HOLD IS NULL OR ap.AP_PROD_BILL_HOLD = 0 )

			SET @ret_val = @@ERROR			
		END 		

		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 03/13/2013 - Fixed WIP account - caused OOB when reconciling
			-- EC  03/31/2013 - Fixed so that the GL ACCT ACC AP account is used to update AB actual table
			 UPDATE ab
	 			SET	GLACODE_SALES = ( CASE ars.DEFERRED_FLAG WHEN 1 THEN ars.GL_ACCT_DEF_SALE ELSE ars.GL_ACCT_SALE END ), 
					GLACODE_COS = ( CASE ars.AB_REC_FLAG 
										WHEN 1 THEN ars.GL_ACCT_DEF_COS 
										WHEN 2 THEN ars.GL_ACCT_ACC_COS					-- BJL 10/25/13
										ELSE ars.GL_ACCT_COS END ),
					GLACODE_ACC_AP = ( CASE ars.FNC_TYPE WHEN 'V' THEN ars.GL_ACCT_ACC_AP ELSE NULL END )
			   FROM dbo.ADVANCE_BILLING ab
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ab.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ab.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ab.FNC_CODE = ars.FNC_CODE )		
				AND ( ab.FNC_TYPE = ars.FNC_TYPE )
			  WHERE ( ab.BILLING_USER = @billing_user_in )
			    AND ( ab.AR_INV_NBR IS NULL )
				AND ( ab.AB_FLAG <> 5 )
				AND ( ars.SUMMARY_FLAG = 0 )
				
			SET @ret_val = @@ERROR			
		END 
		
		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 02/23/2013 - 	
			 UPDATE ab
	 			SET	GLACODE_SALES = ars.GL_ACCT_SALE
			   FROM dbo.ADVANCE_BILLING ab
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ab.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ab.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ab.FNC_CODE = ars.FNC_CODE )		
				AND ( ab.FNC_TYPE = ars.FNC_TYPE )
			  WHERE ( ab.BILLING_USER = @billing_user_in )
			    AND ( ab.AR_INV_NBR IS NULL )
				AND ( ab.AB_FLAG = 5 )
				AND ( ars.SUMMARY_FLAG = 0 )
				AND ( ars.GL_ACCT_SALE IS NOT NULL )
				
			SET @ret_val = @@ERROR			
		END 				
		
		IF ( @ret_val = 0 )
		BEGIN
			 -- BJL 11/22/2013 - Separated from below to allow updating resale tax accounts
			 UPDATE ab
	 			SET	GLACODE_STATE = ars.GL_ACCT_STATE,
					GLACODE_CNTY = ars.GL_ACCT_COUNTY,
					GLACODE_CITY = ars.GL_ACCT_CITY
			   FROM dbo.ADVANCE_BILLING ab
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ab.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ab.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ab.FNC_CODE = ars.FNC_CODE )		
				AND ( ab.FNC_TYPE = ars.FNC_TYPE )
				AND ( ab.TAX_CODE = ars.TAX_CODE ) 
			  WHERE ( ab.BILLING_USER = @billing_user_in )
			    AND ( ab.AR_INV_NBR IS NULL )
			    AND ( ars.INV_TAX_FLAG = 0 )
				AND ( ars.SUMMARY_FLAG = 0 )
				
			SET @ret_val = @@ERROR			
		END 		

		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013 - Always update the AR_INV_NBR last
			 UPDATE ab
	 			SET	AR_INV_NBR = ars.AR_INV_NBR, 
	 				AR_TYPE = 'IN', 
	 				AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ), 
	 				GLEXACT = ars.GL_XACT
			   FROM dbo.ADVANCE_BILLING ab
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ab.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ab.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ab.FNC_CODE = ars.FNC_CODE )		
				AND ( ab.FNC_TYPE = ars.FNC_TYPE )
			  WHERE ( ab.BILLING_USER = @billing_user_in )
				AND ( ab.AR_INV_NBR IS NULL )
				AND ( ars.SUMMARY_FLAG = 0 )
				
			SET @ret_val = @@ERROR			
		END 		

		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE ir
		 	    SET	AR_INV_NBR = ars.AR_INV_NBR, 
		 			AR_TYPE = 'IN', 
		 			AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),										
		 			GLEXACT = ars.GL_XACT,
					GLACODE_SALES = ars.GL_ACCT_SALE,
					GLACODE_DEF_SALES = ars.GL_ACCT_DEF_SALE
			   FROM dbo.INCOME_REC ir
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ir.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ir.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
			    AND (( ars.FNC_CODE IS NULL ) OR ( ir.FNC_CODE = ars.FNC_CODE )) --MJC 09/29/15 join on new FNC_CODE column in INCOME_REC
			    AND ( ars.TAX_CODE IS NULL )
			  WHERE ( ir.BILLING_USER = @billing_user_in )
			    AND ( ir.AR_INV_NBR IS NULL )
			    AND ( ars.FNC_TYPE = 'R' )
			   --AND ( ars.SUMMARY_FLAG = 0 )
				
			SET @ret_val = @@ERROR			
		END 		
		
		--Clear taxes from source tables only - the taxes remain in the billing work tables
		-- BJL 11/25/2013 - Clear resale taxes when using tax @ invoice = ON, recalculate LINE_TOTAL
		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE etd
				SET TAX_CODE = NULL, 
					TAX_RESALE = 0, 
					TAX_COMM = 0, 
					TAX_COMM_ONLY = 0,
					TAX_STATE_PCT = 0.000, 
					TAX_COUNTY_PCT = 0.000, 
					TAX_CITY_PCT = 0.000,
					EXT_STATE_RESALE = 0.00, 
					EXT_COUNTY_RESALE = 0.00, 
					EXT_CITY_RESALE = 0.00,
					LINE_TOTAL = COALESCE( COALESCE( etd.TOTAL_BILL, 0.00 ) + COALESCE( etd.EXT_MARKUP_AMT, 0.00 ), 0.00 )
			   FROM dbo.EMP_TIME_DTL etd
		 INNER JOIN	@AR_SUMMARY ars
				 ON ( etd.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( etd.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( etd.FNC_CODE = ars.FNC_CODE )	 
				AND ( etd.AR_INV_NBR = ars.AR_INV_NBR )
				AND ( ars.INV_TAX_FLAG = 1 )
			  WHERE ( etd.EXT_STATE_RESALE <> 0.00 ) 
				 OR ( etd.EXT_COUNTY_RESALE <> 0.00 ) 
				 OR ( etd.EXT_CITY_RESALE <> 0.00 ) 

			SET @ret_val = @@ERROR			
		END

		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE inc
				SET TAX_CODE = NULL, 
					TAX_RESALE = 0, 
					TAX_COMM = 0, 
					TAX_COMM_ONLY = 0,
					TAX_STATE_PCT = 0.000, 
					TAX_COUNTY_PCT = 0.000, 
					TAX_CITY_PCT = 0.000,
					EXT_STATE_RESALE = 0.00, 
					EXT_COUNTY_RESALE = 0.00, 
					EXT_CITY_RESALE = 0.00,
					LINE_TOTAL = COALESCE( COALESCE( [inc].[IO_AMOUNT], 0.00 ) + COALESCE( inc.EXT_MARKUP_AMT, 0.00 ), 0.00 )
			   FROM dbo.INCOME_ONLY inc
		 INNER JOIN @AR_SUMMARY ars
				 ON ( inc.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( inc.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( inc.FNC_CODE = ars.FNC_CODE )	
				AND ( inc.AR_INV_NBR = ars.AR_INV_NBR )
				AND ( ars.INV_TAX_FLAG = 1 )
			  WHERE ( inc.EXT_STATE_RESALE <> 0.00 ) 
				 OR ( inc.EXT_COUNTY_RESALE <> 0.00 ) 
				 OR ( inc.EXT_CITY_RESALE <> 0.00 ) 
			    
			SET @ret_val = @@ERROR			
		END

		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013 - Modified to only clear certain columns when there is no vendor tax amount
			 UPDATE ap
				SET TAX_CODE = CASE WHEN ( ars.NON_RESALE_AMT <> 0.00 ) THEN ap.TAX_CODE 
									ELSE NULL 
							   END, 
					TAX_RESALE = 0, 
					TAX_COMMISSIONS = 0, 
					TAX_COMM_ONLY = 0,
					TAX_STATE_PCT = CASE WHEN ( ars.NON_RESALE_AMT <> 0.00 ) THEN ap.TAX_STATE_PCT 
										 ELSE 0.000 
									END, 
					TAX_COUNTY_PCT = CASE WHEN ( ars.NON_RESALE_AMT <> 0.00 ) THEN ap.TAX_COUNTY_PCT 
										  ELSE 0.000 
									 END, 
					TAX_CITY_PCT = CASE WHEN ( ars.NON_RESALE_AMT <> 0.00 ) THEN ap.TAX_CITY_PCT 
										ELSE 0.000 
								   END,
					EXT_STATE_RESALE = 0.00, 
					EXT_COUNTY_RESALE = 0.00, 
					EXT_CITY_RESALE = 0.00,
					LINE_TOTAL = COALESCE( COALESCE( ap.AP_PROD_EXT_AMT, 0.00 ) 
										 + COALESCE( ap.EXT_MARKUP_AMT, 0.00 )
										 + COALESCE( ap.EXT_NONRESALE_TAX, 0.00 ), 0.00 )
			   FROM dbo.AP_PRODUCTION ap
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ap.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ap.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ap.FNC_CODE = ars.FNC_CODE )	
				AND ( ap.AR_INV_NBR = ars.AR_INV_NBR )
				AND ( ars.INV_TAX_FLAG = 1 )
			  WHERE ( ap.EXT_STATE_RESALE <> 0.00 ) 
				 OR ( ap.EXT_COUNTY_RESALE <> 0.00 ) 
				 OR ( ap.EXT_CITY_RESALE <> 0.00 ) 
			    
			SET @ret_val = @@ERROR			
		END

		IF ( @ret_val = 0 )
		BEGIN
			-- BJL 11/22/2013 - Modified to only clear certain columns when there is no vendor tax amount
			 UPDATE ab
				SET TAX_CODE = CASE WHEN ( ars.AB_NONRESALE_AMT <> 0.00 ) THEN ab.TAX_CODE 
									ELSE NULL 
							   END, 
					TAX_RESALE = 0, 
					TAX_COMM = 0, 
					TAX_COMM_ONLY = 0,
					TAX_STATE_PCT = CASE WHEN ( ars.AB_NONRESALE_AMT <> 0.00 ) THEN ab.TAX_STATE_PCT 
										 ELSE 0.000 
									END, 
					TAX_COUNTY_PCT = CASE WHEN ( ars.AB_NONRESALE_AMT <> 0.00 ) THEN ab.TAX_COUNTY_PCT 
										  ELSE 0.000 
									 END, 
					TAX_CITY_PCT = CASE WHEN ( ars.AB_NONRESALE_AMT <> 0.00 ) THEN ab.TAX_CITY_PCT 
										ELSE 0.000 
								   END,
					EXT_STATE_RESALE = 0.00, 
					EXT_COUNTY_RESALE = 0.00, 
					EXT_CITY_RESALE = 0.00,
					LINE_TOTAL = COALESCE( COALESCE( ab.ADV_BILL_NET_AMT, 0.00 ) 
										 + COALESCE( ab.EXT_MARKUP_AMT, 0.00 )
										 + COALESCE( ab.EXT_NONRESALE_TAX, 0.00 ), 0.00 )
			   FROM dbo.ADVANCE_BILLING ab
		 INNER JOIN @AR_SUMMARY ars
				 ON ( ab.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( ab.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ab.FNC_CODE = ars.FNC_CODE )		
				AND ( ab.FNC_TYPE = ars.FNC_TYPE )
				AND ( ab.AR_INV_NBR = ars.AR_INV_NBR )
				AND ( ars.INV_TAX_FLAG = 1 )
			  WHERE ( ab.EXT_STATE_RESALE <> 0.00 ) 
				 OR ( ab.EXT_COUNTY_RESALE <> 0.00 ) 
				 OR ( ab.EXT_CITY_RESALE <> 0.00 ) 
			    
			SET @ret_val = @@ERROR			
		END

		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE jc
				SET JOB_PROCESS_CONTRL = ( CASE WHEN ( jpl.NEW_PROCESS_CNTRL IS NULL ) THEN 1
												WHEN ( jpl.NEW_PROCESS_CNTRL = 0 ) THEN 1
												ELSE jpl.NEW_PROCESS_CNTRL END )
			   FROM dbo.JOB_COMPONENT jc
		 INNER JOIN @AR_SUMMARY ars
				 ON ( jc.JOB_NUMBER = ars.JOB_NUMBER )
		 INNER JOIN dbo.ADVANCE_BILLING ab
				 ON ( ars.JOB_NUMBER = ab.JOB_NUMBER )
				AND ( ars.JOB_COMPONENT_NBR = ab.JOB_COMPONENT_NBR )
	LEFT OUTER JOIN dbo.JOB_PROCESS_LOG jpl
				 ON ( jc.JOB_NUMBER = jpl.JOB_NUMBER )
				AND ( jc.JOB_COMPONENT_NBR = jpl.JOB_COMPONENT_NBR )
				AND ( jpl.JOB_PROCESS_LOG_ID = ( SELECT MAX( jpl2.JOB_PROCESS_LOG_ID )
												   FROM dbo.JOB_PROCESS_LOG jpl2
												  WHERE ( jpl2.JOB_NUMBER = jpl.JOB_NUMBER )
													AND ( jpl2.JOB_COMPONENT_NBR = jpl.JOB_COMPONENT_NBR )
													AND ( jpl2.BCC_FLAG IS NULL OR jpl2.BCC_FLAG = 0 )))					 
			  WHERE ( ars.AR_INV_SEQ IN ( 0, @coop_master_seq ))
				AND ( ab.AB_FLAG IN ( 4, 5 ))
				AND ( ab.BILLING_USER = @billing_user_in )
				AND EXISTS ( SELECT *
							   FROM dbo.JOB_PROCESS_LOG jpl3
							  WHERE ( jpl3.JOB_NUMBER = jc.JOB_NUMBER )
								AND ( jpl3.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
								AND ( jpl3.BCC_FLAG = 1 ))
				
			 SET @ret_val = @@ERROR
		END

		IF ( @ret_val = 0 )
		BEGIN
			DELETE FROM dbo.JOB_PROCESS_LOG 
				  WHERE BCC_FLAG = 1 		
					AND EXISTS ( SELECT *
								   FROM @AR_SUMMARY ars
							 INNER JOIN dbo.ADVANCE_BILLING ab
									 ON ( ars.JOB_NUMBER = ab.JOB_NUMBER )
									AND ( ars.JOB_COMPONENT_NBR = ab.JOB_COMPONENT_NBR )
						 		  WHERE ( ars.JOB_NUMBER = dbo.JOB_PROCESS_LOG.JOB_NUMBER )
									AND ( ars.JOB_COMPONENT_NBR = dbo.JOB_PROCESS_LOG.JOB_COMPONENT_NBR )
									AND ( ars.AR_INV_SEQ IN ( 0, @coop_master_seq ))
									AND ( ab.AB_FLAG IN ( 4, 5 ))
									AND ( ab.BILLING_USER = @billing_user_in ))
									
			SET @ret_val = @@ERROR	
		END
													
		IF ( @ret_val = 0 )
		BEGIN
				UPDATE jc
				   SET AB_FLAG = 0 
				  FROM dbo.JOB_COMPONENT jc
			INNER JOIN @AR_SUMMARY ars
					ON ( jc.JOB_NUMBER = ars.JOB_NUMBER )
				   AND ( jc.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR ) 
				 WHERE ( ars.AR_INV_SEQ IN ( 0, @coop_master_seq ))
				   AND EXISTS (SELECT 1
							   FROM dbo.ADVANCE_BILLING ab
							   WHERE ars.JOB_NUMBER = ab.JOB_NUMBER
							   AND	ars.JOB_COMPONENT_NBR = ab.JOB_COMPONENT_NBR
							   AND	ab.FINAL_AB_ID IS NOT NULL
							   AND	ab.METHOD_DESC IS NOT NULL
							   AND	(ab.AR_INV_VOID IS NULL OR ab.AR_INV_VOID = 0)
							   )
				   --AND ( ab.AB_FLAG IN ( 4, 5 ))
				   --AND ( ab.BILLING_USER = @billing_user_in )

			 SET @ret_val = @@ERROR
		END
		
		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE bah
				SET AR_INV_NBR = ars.AR_INV_NBR,
					INVOICE_DATE = @inv_date,
					PROCESSED = 1
			   FROM dbo.BILL_APPR_HDR bah
		 INNER JOIN	dbo.JOB_COMPONENT jc
				 ON ( bah.JOB_NUMBER = jc.JOB_NUMBER )
				AND ( bah.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
				AND ( bah.BA_ID = jc.SELECTED_BA_ID )
		 INNER JOIN	@AR_SUMMARY ars
				 ON ( jc.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( jc.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ars.AR_INV_SEQ IN ( 0, @coop_master_seq ))
				--AND ( ars.JOB_AB_FLAG = 0 ) 			-- EC 01/08/2014 - Fixed Update AR_INV_NBR			
			  WHERE ( bah.AR_INV_NBR IS NULL )
				AND ( bah.INVOICE_DATE IS NULL )
		
			 SET @ret_val = @@ERROR
		END
		
		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE bah
				SET PROCESSED = 1
			   FROM dbo.BILL_APPR_HDR bah
		 INNER JOIN	dbo.JOB_COMPONENT jc
				 ON ( bah.JOB_NUMBER = jc.JOB_NUMBER )
				AND ( bah.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
				AND ( bah.BA_ID = jc.SELECTED_BA_ID )
		 INNER JOIN	@AR_SUMMARY ars
				 ON ( jc.JOB_NUMBER = ars.JOB_NUMBER )
				AND ( jc.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
				AND ( ars.AR_INV_SEQ IN ( 0, @coop_master_seq ))
			  WHERE COALESCE( jc.JOB_BILL_HOLD, 0 ) = 0
		
			 SET @ret_val = @@ERROR
		END

		-- MJC 10/16/2015 took out, we dont need to update for earlier bah.BA_ID records
		--IF ( @ret_val = 0 )
		--BEGIN
		--	 UPDATE bah
		--		SET AR_INV_NBR = ars.AR_INV_NBR,
		--			INVOICE_DATE = @inv_date
		--	   FROM dbo.BILL_APPR_HDR bah
		-- INNER JOIN	dbo.JOB_COMPONENT jc
		--		 ON ( bah.JOB_NUMBER = jc.JOB_NUMBER )
		--		AND ( bah.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
		-- INNER JOIN	@AR_SUMMARY ars
		--		 ON ( jc.JOB_NUMBER = ars.JOB_NUMBER )
		--		AND ( jc.JOB_COMPONENT_NBR = ars.JOB_COMPONENT_NBR )
		--		AND ( ars.AR_INV_SEQ IN ( 0, @coop_master_seq ))
		--		AND ( ars.JOB_AB_FLAG = 0 ) 									
		--	  WHERE ( bah.AR_INV_NBR IS NULL )
		--		AND ( bah.INVOICE_DATE IS NULL )
		--		--AND ( bah.BILL_TYPE = 1 )			-- EC 01/08/2014 - Fixed Update AR_INV_NBR
		--		AND ( bah.BA_ID < jc.SELECTED_BA_ID )
		
		--	 SET @ret_val = @@ERROR
		--END
		
		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE dbo.AP_PRODUCTION
				SET BILLING_USER = NULL,
					AP_PROD_BILL_HOLD = ( CASE AP_PROD_BILL_HOLD WHEN 1 THEN 0 ELSE AP_PROD_BILL_HOLD END )
			  WHERE ( BILLING_USER = @billing_user_in ) AND ( AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
		
			 SET @ret_val = @@ERROR
		END

		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE dbo.EMP_TIME_DTL
				SET BILLING_USER = NULL,
					BILL_HOLD_FLG = ( CASE BILL_HOLD_FLG WHEN 1 THEN 0 ELSE BILL_HOLD_FLG END )
			  WHERE	( BILLING_USER = @billing_user_in ) AND ( AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
		
			 SET @ret_val = @@ERROR
		END

		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE dbo.INCOME_ONLY
				SET BILLING_USER = NULL,
					BILL_HOLD_FLAG = ( CASE BILL_HOLD_FLAG WHEN 1 THEN 0 ELSE BILL_HOLD_FLAG END )
			  WHERE	( BILLING_USER = @billing_user_in ) AND ( AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
		
			 SET @ret_val = @@ERROR
		END

		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE dbo.ADVANCE_BILLING
				SET BILLING_USER = NULL
			  WHERE	( BILLING_USER = @billing_user_in ) AND ( AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
		
			 SET @ret_val = @@ERROR
		END

		IF ( @ret_val = 0 )
		BEGIN
			 UPDATE dbo.INCOME_REC
				SET BILLING_USER = NULL
			  WHERE	( BILLING_USER = @billing_user_in ) AND ( AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
		
			 SET @ret_val = @@ERROR
		END

		-- MJC 10/16/2015 - add calls to usp_wv_BA_BATCH_FINISH
		IF ( @ret_val = 0 )
		BEGIN
			DECLARE @ba_batch_ids TABLE (
				rowid INT IDENTITY(1,1) NOT NULL,
				BA_BATCH_ID int NOT NULL
			)

			DECLARE @row int,
					@max int,
					@ba_batch_id int

			INSERT INTO @ba_batch_ids (BA_BATCH_ID)
			SELECT BA_BATCH_ID 
			FROM dbo.BILL_APPR_BATCH 
			WHERE FINISHED = 0 
			AND PROCESSED_ALL = 1 
			AND APPROVED = 1 
			AND BA_BATCH_ID IN (SELECT ba.BA_BATCH_ID 
								FROM dbo.JOB_COMPONENT jc 
									INNER JOIN dbo.BILL_APPR ba ON jc.SELECTED_BA_ID = ba.BA_ID
								WHERE jc.BILLING_USER = @billing_user_in)

			SELECT @max = @@ROWCOUNT
			SET @row = 1

			WHILE @row <= @max
			BEGIN
				SELECT @ba_batch_id = BA_BATCH_ID FROM @ba_batch_ids WHERE rowid = @row

				EXEC dbo.usp_wv_BA_BATCH_FINISH @ba_batch_id
	
				SET @row = @row +1
			END
			
		END

		IF ( @ret_val = 0 )
		BEGIN
			-- MJC 10/19/2015 - clear AP, IO, ET temporary bill holds if job/comp was assigned to invoice
			-- MJC 04/06/2016 - Only clear TEMP bill holds (when flag = 1)
			UPDATE dtl SET AP_PROD_BILL_HOLD = CASE WHEN AP_PROD_BILL_HOLD = 1 THEN 0 ELSE AP_PROD_BILL_HOLD END
			FROM dbo.JOB_COMPONENT jc
				INNER JOIN dbo.AP_PRODUCTION dtl ON jc.JOB_NUMBER = dtl.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = dtl.JOB_COMPONENT_NBR 
			WHERE jc.BILLING_USER = @billing_user_in
			AND EXISTS (SELECT 1 FROM @AR_SUMMARY WHERE JOB_NUMBER = jc.JOB_NUMBER AND JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR) 

			UPDATE dtl SET BILL_HOLD_FLAG = CASE WHEN BILL_HOLD_FLAG = 1 THEN 0 ELSE BILL_HOLD_FLAG END
			FROM dbo.JOB_COMPONENT jc
				INNER JOIN dbo.INCOME_ONLY dtl ON jc.JOB_NUMBER = dtl.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = dtl.JOB_COMPONENT_NBR 
			WHERE jc.BILLING_USER = @billing_user_in
			AND EXISTS (SELECT 1 FROM @AR_SUMMARY WHERE JOB_NUMBER = jc.JOB_NUMBER AND JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR) 

			UPDATE dtl SET BILL_HOLD_FLG = CASE WHEN BILL_HOLD_FLG = 1 THEN 0 ELSE BILL_HOLD_FLG END
			FROM dbo.JOB_COMPONENT jc
				INNER JOIN dbo.EMP_TIME_DTL dtl ON jc.JOB_NUMBER = dtl.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = dtl.JOB_COMPONENT_NBR 
			WHERE jc.BILLING_USER = @billing_user_in
			AND EXISTS (SELECT 1 FROM @AR_SUMMARY WHERE JOB_NUMBER = jc.JOB_NUMBER AND JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR) 

			UPDATE dbo.JOB_COMPONENT
				SET BILLING_USER = NULL, ADJUST_USER = NULL, SELECTED_BA_ID = NULL,
					JOB_BILL_HOLD = ( CASE JOB_BILL_HOLD WHEN 1 THEN 0 ELSE JOB_BILL_HOLD END )
			WHERE	( BILLING_USER = @billing_user_in )
		
			SET @ret_val = @@ERROR
		END
		
	END	
	
	IF ( @media = 1 )
	BEGIN
	
		IF ( @ret_val = 0 )
		BEGIN		
			 INSERT INTO dbo.ARINV_MEDIA ( 
						 AR_INV_NBR, AR_INV_DATE, ORDER_NBR, ORDER_TYPE, AR_TYPE, AR_INV_SEQ, LINE_NBR, 
						 REV_NBR, BRDCAST_YEAR, BILL_MONTHS, BILL_COMM_NET )
				  SELECT DISTINCT ars.AR_INV_NBR, @inv_date, ars.ORDER_NBR, ars.MEDIA_TYPE, 'IN', ars.AR_INV_SEQ, 
						 ars.ORDER_LINE_NBR, 0, ars.MEDIA_YEAR, NULL, NULL
					FROM @AR_SUMMARY ars												 
				   WHERE ( ars.AR_INV_SEQ IN ( 0, @coop_master_seq ))
					 AND ( ars.MEDIA_TYPE IS NOT NULL )
			 
			 SET @ret_val = @@ERROR
		END

		IF ( @ret_val = 0 AND @magazine = 1 )
		BEGIN
			 UPDATE d
				SET	BILLING_USER = NULL, 
					AR_INV_NBR = ars.AR_INV_NBR, AR_TYPE = 'IN', 
					-- AR_INV_SEQ = ars.AR_INV_SEQ,
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),  -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
					GLEXACT = ars.GL_XACT, 
					GLACODE_SALES = ars.GL_ACCT_SALE, 
					GLACODE_COS = ars.GL_ACCT_COS, 
					GLACODE_WIP = ars.GL_ACCT_WIP,
					GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_COUNTY = ars.GL_ACCT_COUNTY, 
					GLACODE_CITY = ars.GL_ACCT_CITY,
					GLEXACT_DEF = ars.GL_XACT_DEF, 
					GLACODE_SALES_DEF = ars.GL_ACCT_DEF_SALE, 
					GLACODE_COS_DEF = ars.GL_ACCT_DEF_COS
			   FROM dbo.MAGAZINE_DETAIL d 
		 INNER JOIN @AR_SUMMARY ars
				 ON ( d.ORDER_NBR = ars.ORDER_NBR )
				AND ( d.LINE_NBR = ars.ORDER_LINE_NBR )
				AND ( COALESCE( d.TAX_CODE, '_NULL_' ) = COALESCE( ars.TAX_CODE, '_NULL_' ))		-- BJL 10/30/13
				AND ( ars.MEDIA_TYPE = 'M' )
			  WHERE ( d.BILLING_USER = @billing_user_in ) 
				AND ( ars.SUMMARY_FLAG = 0 ) -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
				AND ( ars.AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
		    
	   		SET @ret_val = @@ERROR
		END
	
		IF ( @ret_val = 0 AND @newspaper = 1 )
		BEGIN
			 UPDATE d
				SET	BILLING_USER = NULL, 
					AR_INV_NBR = ars.AR_INV_NBR, 
					AR_TYPE = 'IN', 
					-- AR_INV_SEQ = ars.AR_INV_SEQ,
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),  -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
					GLEXACT = ars.GL_XACT, 
					GLACODE_SALES = ars.GL_ACCT_SALE, 
					GLACODE_COS = ars.GL_ACCT_COS, 
					GLACODE_WIP = ars.GL_ACCT_WIP,
					GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_COUNTY = ars.GL_ACCT_COUNTY, 
					GLACODE_CITY = ars.GL_ACCT_CITY,
					GLEXACT_DEF = ars.GL_XACT_DEF, 
					GLACODE_SALES_DEF = ars.GL_ACCT_DEF_SALE, 
					GLACODE_COS_DEF = ars.GL_ACCT_DEF_COS
			   FROM dbo.NEWSPAPER_DETAIL d 
		 INNER JOIN @AR_SUMMARY ars
				 ON ( d.ORDER_NBR = ars.ORDER_NBR )
				AND ( d.LINE_NBR = ars.ORDER_LINE_NBR )
				AND ( COALESCE( d.TAX_CODE, '_NULL_' ) = COALESCE( ars.TAX_CODE, '_NULL_' ))		-- BJL 10/30/13
				AND ( ars.MEDIA_TYPE = 'N' )
			  WHERE ( d.BILLING_USER = @billing_user_in )
				AND ( ars.SUMMARY_FLAG = 0 ) -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
				AND ( ars.AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
			  	    
			SET @ret_val = @@ERROR
		END
		
		IF ( @ret_val = 0 AND @internet = 1 )
		BEGIN
			 UPDATE d
				SET	BILLING_USER = NULL, 
					AR_INV_NBR = ars.AR_INV_NBR, 
					AR_TYPE = 'IN', 
					-- AR_INV_SEQ = ars.AR_INV_SEQ,
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),  -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
					GLEXACT = ars.GL_XACT, 
					GLACODE_SALES = ars.GL_ACCT_SALE, 
					GLACODE_COS = ars.GL_ACCT_COS, 
					GLACODE_WIP = ars.GL_ACCT_WIP,
					GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_COUNTY = ars.GL_ACCT_COUNTY, 
					GLACODE_CITY = ars.GL_ACCT_CITY,
					GLEXACT_DEF = ars.GL_XACT_DEF, 
					GLACODE_SALES_DEF = ars.GL_ACCT_DEF_SALE, 
					GLACODE_COS_DEF = ars.GL_ACCT_DEF_COS
			   FROM dbo.INTERNET_DETAIL d 
		 INNER JOIN @AR_SUMMARY ars
				 ON ( d.ORDER_NBR = ars.ORDER_NBR )
				AND ( d.LINE_NBR = ars.ORDER_LINE_NBR )
				AND ( COALESCE( d.TAX_CODE, '_NULL_' ) = COALESCE( ars.TAX_CODE, '_NULL_' ))		-- BJL 10/30/13
				AND ( ars.MEDIA_TYPE = 'I' )
			  WHERE ( d.BILLING_USER = @billing_user_in )
				AND ( ars.SUMMARY_FLAG = 0 ) -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media		
				AND ( ars.AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
	    
			SET @ret_val = @@ERROR
		END
		
		IF ( @ret_val = 0 AND @outdoor = 1 )
		BEGIN
			 UPDATE d
				SET	BILLING_USER = NULL, 
					AR_INV_NBR = ars.AR_INV_NBR, 
					AR_TYPE = 'IN', 
					-- AR_INV_SEQ = ars.AR_INV_SEQ,
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),  -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
					GLEXACT = ars.GL_XACT, 
					GLACODE_SALES = ars.GL_ACCT_SALE, 
					GLACODE_COS = ars.GL_ACCT_COS, 
					GLACODE_WIP = ars.GL_ACCT_WIP,
					GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_COUNTY = ars.GL_ACCT_COUNTY, 
					GLACODE_CITY = ars.GL_ACCT_CITY,
					GLEXACT_DEF = ars.GL_XACT_DEF, 
					GLACODE_SALES_DEF = ars.GL_ACCT_DEF_SALE, 
					GLACODE_COS_DEF = ars.GL_ACCT_DEF_COS
			   FROM dbo.OUTDOOR_DETAIL d 
		 INNER JOIN @AR_SUMMARY ars
				 ON ( d.ORDER_NBR = ars.ORDER_NBR )
				AND ( d.LINE_NBR = ars.ORDER_LINE_NBR )
				AND ( COALESCE( d.TAX_CODE, '_NULL_' ) = COALESCE( ars.TAX_CODE, '_NULL_' ))		-- BJL 10/30/13
				AND ( ars.MEDIA_TYPE = 'O' )
			  WHERE ( d.BILLING_USER = @billing_user_in )
				AND ( ars.SUMMARY_FLAG = 0 ) -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
				AND ( ars.AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
	    
			SET @ret_val = @@ERROR
		END				

		IF ( @ret_val = 0 AND @television = 1 )
		BEGIN
			 UPDATE d
				SET	BILLING_USER = NULL, 
					AR_INV_NBR = ars.AR_INV_NBR, 
					AR_TYPE = 'IN', 
					-- AR_INV_SEQ = ars.AR_INV_SEQ,
					AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),  -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
					GLEXACT = ars.GL_XACT, 
					GLACODE_SALES = ars.GL_ACCT_SALE, 
					GLACODE_COS = ars.GL_ACCT_COS, 
					GLACODE_WIP = ars.GL_ACCT_WIP,
					GLACODE_STATE = ars.GL_ACCT_STATE, 
					GLACODE_COUNTY = ars.GL_ACCT_COUNTY, 
					GLACODE_CITY = ars.GL_ACCT_CITY,
					GLEXACT_DEF = ars.GL_XACT_DEF, 
					GLACODE_SALES_DEF = ars.GL_ACCT_DEF_SALE, 
					GLACODE_COS_DEF = ars.GL_ACCT_DEF_COS
			   FROM dbo.TV_DETAIL d 
		 INNER JOIN @AR_SUMMARY ars
				 ON ( d.ORDER_NBR = ars.ORDER_NBR )
				AND ( d.LINE_NBR = ars.ORDER_LINE_NBR )
				AND ( COALESCE( d.TAX_CODE, '_NULL_' ) = COALESCE( ars.TAX_CODE, '_NULL_' ))		-- BJL 10/30/13
				AND ( ars.MEDIA_TYPE = 'T' )
			  WHERE ( d.BILLING_USER = @billing_user_in )
				AND ( ars.SUMMARY_FLAG = 0 ) -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
				AND ( ars.AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
	    
			SET @ret_val = @@ERROR
		END				
		
		IF ( @ret_val = 0 AND @radio = 1 )
		BEGIN
			 UPDATE d
				SET	BILLING_USER = NULL, 
				AR_INV_NBR = ars.AR_INV_NBR, 
				AR_TYPE = 'IN', 
				-- AR_INV_SEQ = ars.AR_INV_SEQ,
				AR_INV_SEQ = ( CASE ars.AR_INV_SEQ WHEN 0 THEN 0 ELSE @coop_master_seq END ),  -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
				GLEXACT = ars.GL_XACT, 
				GLACODE_SALES = ars.GL_ACCT_SALE, 
				GLACODE_COS = ars.GL_ACCT_COS, 
				GLACODE_WIP = ars.GL_ACCT_WIP,
				GLACODE_STATE = ars.GL_ACCT_STATE, 
				GLACODE_COUNTY = ars.GL_ACCT_COUNTY, 
				GLACODE_CITY = ars.GL_ACCT_CITY,
				GLEXACT_DEF = ars.GL_XACT_DEF, 
				GLACODE_SALES_DEF = ars.GL_ACCT_DEF_SALE, 
				GLACODE_COS_DEF = ars.GL_ACCT_DEF_COS
			   FROM dbo.RADIO_DETAIL d 
		 INNER JOIN @AR_SUMMARY ars
				 ON ( d.ORDER_NBR = ars.ORDER_NBR )
				AND ( d.LINE_NBR = ars.ORDER_LINE_NBR )
				AND ( COALESCE( d.TAX_CODE, '_NULL_' ) = COALESCE( ars.TAX_CODE, '_NULL_' ))		-- BJL 10/30/13
				AND ( ars.MEDIA_TYPE = 'R' )
			  WHERE ( d.BILLING_USER = @billing_user_in )
				AND ( ars.SUMMARY_FLAG = 0 ) -- EC 12/7/13 Changed to fix bug with sequence not updating correctly for media
				AND ( ars.AR_INV_NBR IS NOT NULL ) -- PJH 03/06/2015 - Added AR_INV_NBR IS NOT NULL **********************************
	    
			SET @ret_val = @@ERROR
		END						
	END	
	
	-- PJH 03/06/2015 - Verify that BILLING_USER has been cleared *************************************************************
	-- PJH 04/21/2015 - Changed BILL_HOLD <> 1 to  BILL_HOLD = 0
	/* Skip this for now
	SELECT @ret_val = SUM(CNT) FROM (
			SELECT COUNT(BILLING_USER) 'CNT' FROM AP_PRODUCTION WHERE ( BILLING_USER = @billing_user_in ) AND COALESCE(AP_PROD_BILL_HOLD, 0)  = 0
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM EMP_TIME_DTL WHERE ( BILLING_USER = @billing_user_in ) AND COALESCE(BILL_HOLD_FLG, 0)  = 0
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM INCOME_ONLY WHERE ( BILLING_USER = @billing_user_in )  AND COALESCE(BILL_HOLD_FLAG, 0)  = 0
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM ADVANCE_BILLING WHERE ( BILLING_USER = @billing_user_in )
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM INCOME_REC WHERE ( BILLING_USER = @billing_user_in )
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM MAGAZINE_DETAIL WHERE ( BILLING_USER = @billing_user_in )
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM NEWSPAPER_DETAIL WHERE ( BILLING_USER = @billing_user_in )
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM INTERNET_DETAIL WHERE ( BILLING_USER = @billing_user_in )
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM OUTDOOR_DETAIL WHERE ( BILLING_USER = @billing_user_in )
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM TV_DETAIL WHERE ( BILLING_USER = @billing_user_in )
			UNION ALL
			SELECT COUNT(BILLING_USER) FROM RADIO_DETAIL WHERE ( BILLING_USER = @billing_user_in )
			) A
			
	IF ( @ret_val <> 0 )
	BEGIN
		SET @ret_val = -14 --Failed updating AR Invoice numbers
	END
	*/

	--PJH 03/04/2015 - Do not clear w_ar_function here - will be cleared by PostAvaTax or in at end of Assign Invoice on PB side 
	--PJH 04/07/2015 - Allow clearing w_ar_function - we are using AR_SUMMARY now for posting Avatax

	IF ( @ret_val = 0 )
	BEGIN
		DECLARE @ret_val_arg integer
		EXECUTE dbo.advsp_delete_ar_function @bill_user_in = @billing_user_in, @ret_val = @ret_val_arg OUTPUT
		SET @ret_val = @@ERROR
	END	  

	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 04/15/2013 - For deferred media, swap deferred accounts (from 809|1|75)
		-- BJL 04/17/2013 - For deferred media, swap deferred posting periods (from 809|1|75)
		UPDATE ars
		   SET GL_ACCT_ACC_AP = GL_ACCT_WIP,
			   GL_ACCT_WIP = GL_ACCT_ACC_AP,
			   GL_ACCT_DEF_SALE = GL_ACCT_SALE,
			   GL_ACCT_SALE = GL_ACCT_DEF_SALE,
			   GL_ACCT_DEF_COS = GL_ACCT_COS,
			   GL_ACCT_COS = GL_ACCT_DEF_COS,
			   GL_XACT = GL_XACT_DEF,
			   GL_XACT_DEF = GL_XACT
		  FROM @AR_SUMMARY ars
		 WHERE ( ars.MEDIA_TYPE <> 'P' )
		   AND ( ars.MED_REC_FLAG IN ( 2, 3 ))
		
		SET @ret_val = @@ERROR
	END	
	
/******************* DEBUG **********************************************************************************************************/
-- SELECT AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, MANUAL_FLAG, JOB_NUMBER, 
--		JOB_COMPONENT_NBR, JOB_AB_FLAG, AR_DESCRIPTION, ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, 
--		CL_CODE, DIV_CODE, PRD_CODE, OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, 
--		GL_ACCT_AR, GL_ACCT_SALE, GL_ACCT_DEF_SALE, GL_ACCT_COS, GL_ACCT_DEF_COS, GL_ACCT_ACC_AP, 
--		GL_ACCT_WIP, GL_ACCT_STATE, GL_ACCT_COUNTY, GL_ACCT_CITY, GL_ACCT_ACC_COS, 
--		[START_DATE], [END_DATE], MARKET_CODE, MEDIA_MONTH, MEDIA_YEAR,
--		COALESCE( SALE_POST_PERIOD, @post_period ), INV_TAX_FLAG, INV_BY, TAX_CODE, 
--		AB_REC_FLAG, MED_REC_FLAG, BILL_COMM_NET, SUM( HRS_QTY ), 
--		SUM( COALESCE( EMP_TIME_AMT, 0.00 )), SUM( COALESCE( INC_ONLY_AMT, 0.00 )), 
--		SUM( COALESCE( COMMISSION_AMT, 0.00 )), SUM( COALESCE( COST_AMT, 0.00 )), 
--		SUM( COALESCE( REBATE_AMT, 0.00 )), SUM( COALESCE( NET_CHARGE_AMT, 0.00 )), 
--		SUM( COALESCE( NON_RESALE_AMT, 0.00 )), SUM( COALESCE( DISCOUNT_AMT, 0.00 )), 
--		SUM( COALESCE( ADDITIONAL_AMT, 0.00 )), SUM( COALESCE( AB_COST_AMT, 0.00 )), 
--		SUM( COALESCE( AB_INC_AMT, 0.00 )), SUM( COALESCE( AB_COMMISSION_AMT, 0.00 )), 
--		SUM( COALESCE( AB_SALE_AMT, 0.00 )), SUM( COALESCE( AB_NONRESALE_AMT, 0.00 )), 
--		SUM( COALESCE( CITY_TAX_AMT, 0.00 )), SUM( COALESCE( CNTY_TAX_AMT, 0.00 )), 
--		SUM( COALESCE( STATE_TAX_AMT, 0.00 )), SUM( COALESCE( TOTAL_BILL, 0.00 )), 
--		GL_XACT, GL_XACT_DEF, 
--		CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT,
--		AVATAX_KEY, AVATAX_POSTED
--   FROM @AR_SUMMARY
--GROUP BY AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, 
--		MANUAL_FLAG, JOB_NUMBER, JOB_COMPONENT_NBR, JOB_AB_FLAG, AR_DESCRIPTION, 
--		ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, CL_CODE, DIV_CODE, PRD_CODE, 
--		OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, 
--		GL_ACCT_AR, GL_ACCT_SALE, GL_ACCT_DEF_SALE, GL_ACCT_COS, GL_ACCT_DEF_COS, 
--		GL_ACCT_ACC_AP, GL_ACCT_WIP, GL_ACCT_STATE, GL_ACCT_COUNTY, GL_ACCT_CITY, 
--		GL_ACCT_ACC_COS, SALE_POST_PERIOD, INV_TAX_FLAG, INV_BY, TAX_CODE, 
--		AB_REC_FLAG, MED_REC_FLAG, BILL_COMM_NET, GL_XACT, GL_XACT_DEF,
--		[START_DATE], [END_DATE], MARKET_CODE, MEDIA_MONTH, MEDIA_YEAR,
--		CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT	,
--		AVATAX_KEY, AVATAX_POSTED
		
-- SELECT AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, MANUAL_FLAG, JOB_NUMBER, 
--		JOB_COMPONENT_NBR, JOB_AB_FLAG, AR_DESCRIPTION, ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, 
--		CL_CODE, DIV_CODE, PRD_CODE, OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, 
--		GL_ACCT_AR, GL_ACCT_SALE, GL_ACCT_DEF_SALE, GL_ACCT_COS, GL_ACCT_DEF_COS, GL_ACCT_ACC_AP, 
--		GL_ACCT_WIP, GL_ACCT_STATE, GL_ACCT_COUNTY, GL_ACCT_CITY, GL_ACCT_ACC_COS, 
--		[START_DATE], [END_DATE], MARKET_CODE, MEDIA_MONTH, MEDIA_YEAR,
--		COALESCE( SALE_POST_PERIOD, @post_period ), INV_TAX_FLAG, INV_BY, TAX_CODE, 
--		AB_REC_FLAG, MED_REC_FLAG, BILL_COMM_NET, ( HRS_QTY ), 
--		( COALESCE( EMP_TIME_AMT, 0.00 )), ( COALESCE( INC_ONLY_AMT, 0.00 )), 
--		( COALESCE( COMMISSION_AMT, 0.00 )), ( COALESCE( COST_AMT, 0.00 )), 
--		( COALESCE( REBATE_AMT, 0.00 )), ( COALESCE( NET_CHARGE_AMT, 0.00 )), 
--		( COALESCE( NON_RESALE_AMT, 0.00 )), ( COALESCE( DISCOUNT_AMT, 0.00 )), 
--		( COALESCE( ADDITIONAL_AMT, 0.00 )), ( COALESCE( AB_COST_AMT, 0.00 )), 
--		( COALESCE( AB_INC_AMT, 0.00 )), ( COALESCE( AB_COMMISSION_AMT, 0.00 )), 
--		( COALESCE( AB_SALE_AMT, 0.00 )), ( COALESCE( AB_NONRESALE_AMT, 0.00 )), 
--		( COALESCE( CITY_TAX_AMT, 0.00 )), ( COALESCE( CNTY_TAX_AMT, 0.00 )), 
--		( COALESCE( STATE_TAX_AMT, 0.00 )), ( COALESCE( TOTAL_BILL, 0.00 )), 
--		GL_XACT, GL_XACT_DEF, 
--		CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT,
--		AVATAX_KEY, AVATAX_POSTED
--   FROM @AR_SUMMARY
--ORDER BY AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, 
--		MANUAL_FLAG, JOB_NUMBER, JOB_COMPONENT_NBR, JOB_AB_FLAG, AR_DESCRIPTION, 
--		ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, CL_CODE, DIV_CODE, PRD_CODE, 
--		OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, 
--		GL_ACCT_AR, GL_ACCT_SALE, GL_ACCT_DEF_SALE, GL_ACCT_COS, GL_ACCT_DEF_COS, 
--		GL_ACCT_ACC_AP, GL_ACCT_WIP, GL_ACCT_STATE, GL_ACCT_COUNTY, GL_ACCT_CITY, 
--		GL_ACCT_ACC_COS, SALE_POST_PERIOD, INV_TAX_FLAG, INV_BY, TAX_CODE, 
--		AB_REC_FLAG, MED_REC_FLAG, BILL_COMM_NET, GL_XACT, GL_XACT_DEF,
--		[START_DATE], [END_DATE], MARKET_CODE, MEDIA_MONTH, MEDIA_YEAR,
--		CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT	,
--		AVATAX_KEY, AVATAX_POSTED		
		
--SET @ret_val	= -99
/******************* DEBUG **********************************************************************************************************/

	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 11/20/2013 - Added AB_NONRESALE_AMT
		-- BJL 04/10/2013 - Changed SALE_POST_PERIOD to hold AR PP when deferred media not included
		-- PJH 04/07/2015 - Added AVATAX_KEY, AVATAX_POSTED 
		INSERT INTO dbo.AR_SUMMARY ( 
					AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, MANUAL_FLAG, JOB_NUMBER, 
					JOB_COMPONENT_NBR, JOB_AB_FLAG, AR_DESCRIPTION, ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, 
					CL_CODE, DIV_CODE, PRD_CODE, OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, 
					GL_ACCT_AR, GL_ACCT_SALE, GL_ACCT_DEF_SALE, GL_ACCT_COS, GL_ACCT_DEF_COS, GL_ACCT_ACC_AP, 
					GL_ACCT_WIP, GL_ACCT_STATE, GL_ACCT_COUNTY, GL_ACCT_CITY, GL_ACCT_ACC_COS, 
					[START_DATE], [END_DATE], MARKET_CODE, MEDIA_MONTH, MEDIA_YEAR, SALE_POST_PERIOD, 
					INV_TAX_FLAG, INV_BY, TAX_CODE, AB_REC_FLAG, MED_REC_FLAG, BILL_COMM_NET, HRS_QTY, 
					EMP_TIME_AMT, INC_ONLY_AMT, COMMISSION_AMT, COST_AMT, REBATE_AMT, NET_CHARGE_AMT, 
					NON_RESALE_AMT, DISCOUNT_AMT, ADDITIONAL_AMT, AB_COST_AMT, AB_INC_AMT, AB_COMMISSION_AMT, 
					AB_SALE_AMT, AB_NONRESALE_AMT, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, TOTAL_BILL, 
					GL_XACT, GL_XACT_DEF, CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT,
					AVATAX_KEY, AVATAX_POSTED, CURRENCY_CODE, CURRENCY_RATE )
			 SELECT AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, MANUAL_FLAG, JOB_NUMBER, 
					JOB_COMPONENT_NBR, JOB_AB_FLAG, AR_DESCRIPTION, ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, 
					CL_CODE, DIV_CODE, PRD_CODE, OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, 
					GL_ACCT_AR, GL_ACCT_SALE, GL_ACCT_DEF_SALE, GL_ACCT_COS, GL_ACCT_DEF_COS, GL_ACCT_ACC_AP, 
					GL_ACCT_WIP, GL_ACCT_STATE, GL_ACCT_COUNTY, GL_ACCT_CITY, GL_ACCT_ACC_COS, 
					[START_DATE], [END_DATE], MARKET_CODE, MEDIA_MONTH, MEDIA_YEAR,
					COALESCE( SALE_POST_PERIOD, @post_period ), INV_TAX_FLAG, INV_BY, TAX_CODE, 
					AB_REC_FLAG, MED_REC_FLAG, BILL_COMM_NET, SUM( HRS_QTY ), 
					SUM( COALESCE( EMP_TIME_AMT, 0.00 )), SUM( COALESCE( INC_ONLY_AMT, 0.00 )), 
					SUM( COALESCE( COMMISSION_AMT, 0.00 )), SUM( COALESCE( COST_AMT, 0.00 )), 
					SUM( COALESCE( REBATE_AMT, 0.00 )), SUM( COALESCE( NET_CHARGE_AMT, 0.00 )), 
					SUM( COALESCE( NON_RESALE_AMT, 0.00 )), SUM( COALESCE( DISCOUNT_AMT, 0.00 )), 
					SUM( COALESCE( ADDITIONAL_AMT, 0.00 )), SUM( COALESCE( AB_COST_AMT, 0.00 )), 
					SUM( COALESCE( AB_INC_AMT, 0.00 )), SUM( COALESCE( AB_COMMISSION_AMT, 0.00 )), 
					SUM( COALESCE( AB_SALE_AMT, 0.00 )), SUM( COALESCE( AB_NONRESALE_AMT, 0.00 )), 
					SUM( COALESCE( CITY_TAX_AMT, 0.00 )), SUM( COALESCE( CNTY_TAX_AMT, 0.00 )), 
					SUM( COALESCE( STATE_TAX_AMT, 0.00 )), SUM( COALESCE( TOTAL_BILL, 0.00 )), 
					GL_XACT, GL_XACT_DEF, 
					-- BJL 11/12/2013
					CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT,
					AVATAX_KEY, AVATAX_POSTED, CURRENCY_CODE, CURRENCY_RATE
			   FROM @AR_SUMMARY
			     -- BJL 06/25/2013 - Uncomment WHERE clause to keep income recognition out of AR_SUMMARY
			--WHERE ( FNC_TYPE IS NULL OR FNC_TYPE <> 'R' )
		   GROUP BY AR_INV_NBR, AR_INV_SEQ, AR_TYPE, COOP_CODE, COOP_PCT, 
					MANUAL_FLAG, JOB_NUMBER, JOB_COMPONENT_NBR, JOB_AB_FLAG, AR_DESCRIPTION, 
					ORDER_NBR, ORDER_LINE_NBR, MEDIA_TYPE, CL_CODE, DIV_CODE, PRD_CODE, 
					OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, CLIENT_PO, FNC_CODE, FNC_TYPE, 
					GL_ACCT_AR, GL_ACCT_SALE, GL_ACCT_DEF_SALE, GL_ACCT_COS, GL_ACCT_DEF_COS, 
					GL_ACCT_ACC_AP, GL_ACCT_WIP, GL_ACCT_STATE, GL_ACCT_COUNTY, GL_ACCT_CITY, 
					GL_ACCT_ACC_COS, SALE_POST_PERIOD, INV_TAX_FLAG, INV_BY, TAX_CODE, 
					AB_REC_FLAG, MED_REC_FLAG, BILL_COMM_NET, GL_XACT, GL_XACT_DEF,
					[START_DATE], [END_DATE], MARKET_CODE, MEDIA_MONTH, MEDIA_YEAR,
					-- BJL 11/12/2013
					CITY_TAX_PCT, CNTY_TAX_PCT, STATE_TAX_PCT	,
					AVATAX_KEY, AVATAX_POSTED, CURRENCY_CODE, CURRENCY_RATE
					
		 SET @ret_val = @@ERROR
		 
		IF EXISTS(SELECT 1 FROM dbo.AGENCY WHERE INV_TAX_FLAG = 1) BEGIN
			UPDATE ar SET STATE_TAX_AMT = SUM_STATE, CNTY_TAX_AMT = SUM_COUNTY, CITY_TAX_AMT = SUM_CITY, TOTAL_BILL = SUM_TOT
			FROM dbo.AR_SUMMARY ar
			/* PJH 03/04/2020 - Added Job and Component to grouping and join */
				INNER JOIN (
							SELECT SUM_STATE = SUM(ar.STATE_TAX_AMT), SUM_COUNTY = SUM(ar.CNTY_TAX_AMT), SUM_CITY = SUM(ar.CITY_TAX_AMT), SUM_TOT = SUM(ar.TOTAL_BILL), 
								ar.AR_INV_NBR, ar.FNC_CODE, ar.JOB_NUMBER, ar.JOB_COMPONENT_NBR
							FROM dbo.AR_SUMMARY ar
							WHERE ar.AR_INV_NBR IN (SELECT DISTINCT AR_INV_NBR FROM @AR_SUMMARY)
							AND ar.AR_INV_SEQ <> @coop_master_seq
							GROUP BY ar.AR_INV_NBR, ar.FNC_CODE, ar.JOB_NUMBER, ar.JOB_COMPONENT_NBR
							) dtl ON ar.AR_INV_NBR = dtl.AR_INV_NBR AND ar.FNC_CODE = dtl.FNC_CODE 
								AND ((dtl.JOB_NUMBER = ar.JOB_NUMBER AND dtl.JOB_COMPONENT_NBR = ar.JOB_COMPONENT_NBR) OR (dtl.JOB_NUMBER IS NULL AND ar.JOB_NUMBER IS NULL))
								AND ar.AR_INV_SEQ = @coop_master_seq

			SET @ret_val = @@ERROR
		END

	END

	/* PJH 02/23/2017 - Moved below */
	IF ( @ret_val = 0 )
	BEGIN
		 UPDATE dbo.BILLING
			SET INV_ASSIGN = 1,	FIRST_INV = ( SELECT MIN( AR_INV_NBR ) FROM @AR_SUMMARY ), LAST_INV = ( SELECT MAX( AR_INV_NBR ) FROM @AR_SUMMARY )
		  WHERE ( BILLING_USER = @billing_user_in )
	
		 SET @ret_val = @@ERROR
	END

END	


/* PJH 09/18/2019 - Update AR_SUMMARY with TV_UNIT split as needed - BEGIN */

DECLARE @assigned TABLE (
	[AR_INV_NBR] [int] NOT NULL,
	[AR_INV_SEQ] [smallint] NOT NULL,
	[AR_INV_DATE] [smalldatetime] NULL,
	[AR_INV_AMOUNT] [decimal](15, 2) NULL,
	[CURRENCY_CODE] [varchar](5) NULL,
	[CURRENCY_RATE] [decimal](12, 6) NULL,
	[EXCHANGE_AMOUNT] [decimal](14, 2) NULL,
	[REC_TYPE] [varchar](6) NULL,
	[AR_DESCRIPTION] [varchar](max) NULL
	)

DECLARE @invoices TABLE (
	[ID] [int] identity,
	[AR_INV_NBR] [int] NOT NULL
	)

DECLARE @invoice_cnt int
DECLARE @current_invoice_row int
DECLARE @current_invoice_nbr int

INSERT INTO @assigned 
EXEC advsp_bcc_get_inv_assigned @billing_user_in;

INSERT INTO @invoices
SELECT DISTINCT AR_INV_NBR FROM @assigned

SELECT @invoice_cnt = COUNT(AR_INV_NBR) FROM @invoices

SET @current_invoice_row = 1

WHILE @current_invoice_row <= @invoice_cnt 
BEGIN

		SELECT @current_invoice_nbr = AR_INV_NBR FROM @invoices WHERE ID = @current_invoice_row

		--SELECT HRS_QTY, * FROM AR_SUMMARY WHERE AR_INV_NBR = @current_invoice_nbr ORDER BY ORDER_NBR, ORDER_LINE_NBR, AR_INV_SEQ /* DEBUG */

 		UPDATE A
		SET A.HRS_QTY = B.HRS_QTY
		FROM AR_SUMMARY A
			INNER JOIN (SELECT /**/
							[HRS_QTY] = CAST(TVDU.HRS AS decimal(18,2)),
							ARS.AR_INV_NBR,
							ARS.AR_INV_SEQ,
							ARS.ORDER_NBR,
							ARS.ORDER_LINE_NBR,
							TVDU.PRD_CODE

						FROM /**/
							(SELECT
									[HRS_QTY] = SUM(ARS.HRS_QTY),
									AR_INV_NBR,
									AR_INV_SEQ,
									AR_TYPE,
									ORDER_NBR,
									ORDER_LINE_NBR,
									PRD_CODE

								FROM		
									[dbo].[AR_SUMMARY] AS ARS
								WHERE 
									ARS.MEDIA_TYPE = 'T' AND
									ARS.AR_INV_NBR = @current_invoice_nbr -- AND ARS.AR_INV_SEQ = 1
								GROUP BY
									ARS.CL_CODE,
									ARS.DIV_CODE,
									ARS.PRD_CODE,
									ARS.OFFICE_CODE,
									ARS.ORDER_NBR,
									ARS.ORDER_LINE_NBR,
									ARS.MEDIA_TYPE,
									ARS.AR_INV_NBR,
									ARS.AR_INV_SEQ,
									ARS.AR_TYPE) AS ARS INNER JOIN 
 
							[dbo].[TV_DETAIL] AS TVD1 ON TVD1.ORDER_NBR = ARS.ORDER_NBR 
														AND TVD1.LINE_NBR = ARS.ORDER_LINE_NBR 
														AND TVD1.AR_INV_NBR = ARS.AR_INV_NBR 
														AND TVD1.AR_TYPE = ARS.AR_TYPE LEFT JOIN 


							/* Used in (advsp_invoice_printing_load_mediainvoicedetail) also for Draft invoices */
							(SELECT A.ORDER_NBR, A.LINE_NBR, A.PRD_CODE, SUM(A.UNITS) HRS 
								FROM [dbo].TV_DETAIL_UNITS A JOIN [dbo].TV_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REV_NBR = B.REV_NBR AND A.SEQ_NBR = B.SEQ_NBR
								WHERE B.AR_INV_NBR = @current_invoice_nbr
								GROUP BY A.ORDER_NBR, A.LINE_NBR, A.PRD_CODE) TVDU ON 
													TVD1.ORDER_NBR = TVDU.ORDER_NBR 
													AND TVD1.LINE_NBR = TVDU.LINE_NBR 
													AND ARS.PRD_CODE = TVDU.PRD_CODE

					WHERE /**/
						ARS.AR_INV_SEQ <> 99 AND TVDU.HRS IS NOT NULL) B ON 
						A.AR_INV_NBR = B.AR_INV_NBR AND
						A.AR_INV_SEQ = B.AR_INV_SEQ AND				
						A.ORDER_NBR = B.ORDER_NBR AND
						A.ORDER_LINE_NBR = B.ORDER_LINE_NBR AND 
						A.PRD_CODE = B.PRD_CODE
		WHERE A.COOP_CODE = 'units!' AND B.HRS_QTY IS NOT NULL

		--SELECT HRS_QTY, * FROM AR_SUMMARY WHERE AR_INV_NBR = @current_invoice_nbr ORDER BY ORDER_NBR, ORDER_LINE_NBR, AR_INV_SEQ /* DEBUG */

		SET @current_invoice_row = @current_invoice_row + 1

END

/* PJH 09/18/2019 - Update AR_SUMMARY with TV_UNIT split as needed - END */

-- ********************************************************************************************************************************
-- ****	CLEANUP *********************** Moved from below **************************************************************************
-- ********************************************************************************************************************************
/* PJH 02/23/2017 - 735-1-2666 - Check Void - There is no GL transaction for voided check */
IF ( @ret_val = 0 )
BEGIN
	UPDATE dbo.IDS 
	   SET IDSXACT = ( SELECT MAX( GLEHXACT ) FROM dbo.GLENTHDR )
	 WHERE IDSTABLE = 'GLENTHDR'

	SET @ret_val = @@ERROR
END

-- Clean up ASSIGN_NBR
IF ( @ret_val = 0 )
BEGIN
	 UPDATE dbo.ASSIGN_NBR 
	    SET [LAST_NBR] = ( SELECT MAX( AR_INV_NBR ) FROM dbo.ACCT_REC WHERE AR_INV_NBR < 900000 ), 
			[USER_ID] = NULL 
	  WHERE [COLUMNNAME] = 'AR_INV_NBR'
	    AND [USER_ID] = @billing_user_in
			
	SET @ret_val = @@ERROR		
END
ELSE
BEGIN
	-- If invoices were not assigned, just clear the billing user
	 UPDATE dbo.ASSIGN_NBR 
	    SET [USER_ID] = NULL 
	  WHERE [COLUMNNAME] = 'AR_INV_NBR'
	    AND [USER_ID] = @billing_user_in
			
	IF ( @ret_val = 0 )
		SET @ret_val = @@ERROR		
END
-- ******************************************************************************************************************************

IF ( @@TRANCOUNT > 0 )
BEGIN
	IF ( @ret_val = 0  )
		--ROLLBACK TRANSACTION update_billing;  /************* D E B U G ************/
		COMMIT TRANSACTION update_billing;
	ELSE
		ROLLBACK TRANSACTION update_billing; 
END		



--SET @ret_val = -12	/************* D E B U G ************/




---- ******************************************************************************************************************************
---- **** OUTPUT (FOR DEBUGGING) **************************************************************************************************
---- ******************************************************************************************************************************
----IF ( @ret_val = 0 AND @update_on = 1 )
----BEGIN
----	SELECT * FROM #JOB_LIST
----	SELECT * FROM @GL_ENTRY ORDER BY AR_INV_NBR, GLEXACT, ACCT_TYPE, GLETSEQ, CL_CODE, DIV_CODE, PRD_CODE
----	SELECT * FROM #PROD_DTL
----	SELECT * FROM @AR_SUMMARY
----	SELECT * FROM #INV_GLEXACT
----	SELECT * FROM #ORDER_LIST ORDER BY INV_BY ASC, ORDER_NBR ASC, LINE_NBR ASC
----END

-- ******************************************************************************************************************************
-- ****	CLEANUP *****************************************************************************************************************
-- ******************************************************************************************************************************
/* PJH 02/23/2017 - 735-1-2666 - Check Void - There is no GL transaction for voided check */
--Moved to above

IF ( @ret_val = 0 )
	IF @avatax_enabled = 1 
		SELECT DISTINCT 0 AS 'ReturnValue' , AR_INV_NBR AS 'ARInvoiceNumber'
		FROM @AR_SUMMARY
    ELSE 
		SELECT @ret_val AS 'ReturnValue'
ELSE
	IF @avatax_enabled = 1 
		SELECT @ret_val AS 'ReturnValue', 0 AS 'ARInvoiceNumber'
	ELSE
		SELECT @ret_val AS 'ReturnValue'

GO

GRANT EXECUTE ON [advsp_billing] TO PUBLIC AS dbo
