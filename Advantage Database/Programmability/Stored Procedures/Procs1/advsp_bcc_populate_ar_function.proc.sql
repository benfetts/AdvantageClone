IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_bcc_populate_ar_function]' ) AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_bcc_populate_ar_function]
GO

CREATE PROCEDURE [dbo].[advsp_bcc_populate_ar_function] @billing_user_in varchar(100), @ret_val integer OUTPUT
AS

-- ************************************************************************************************************************
-- Inserts records for billing ("temp assign")
-- BJL 11/16/2012 - Added JOB_COMPONENT
-- BJL 01/05/2013 - Added adjustment/rounding code to end of procedure
-- BJL 01/24/2013 - Switched co-op to use office from product
-- BJL 02/04/2013 - Rewrote for more summarized table structure of W_AR_FUNCTION
-- BJL 02/20/2013 - Integrate media
-- BJL 04/05/2013 - Moved office level account gathering to later in process to avoid summarization issues (production)
-- BJL 04/19/2013 - Uncommented INV_BY in WHERE clauses, process master invoices only in loop, update co-op with AR_INV_NBR at end
-- BJL 04/19/2013 - Update the co-op items with the parent AR_INV_NBR
-- BJL 04/23/2013 - Added invoice tax
-- BJL 04/24/2013 - Multi-campaign to one job fix
-- BJL 05/20/2013 - Media co-op
-- BJL 06/24/2013 - Restoring income recognition: Adding as a new function type ("R"); does not get split for co-op
-- PJH 08/01/2013 - Use Office Code in AR_INV_NBR assignment 
-- BJL 08/08/2013 - Changed income recognition to populate the AB_INC_AMT column
-- BJL 09/17/2013 - MEDIA_MONTH, MEDIA_YEAR, SALE_POST_PERIOD columns
-- BJL 09/20/2013 - Assign by market fix - should be by product
-- BJL 09/27/2013 - NP_COOP_SPLIT error trapping
-- BJL 10/02/2013 - Fiscal year to PP conversion fix
-- BJL 10/04/2013 - Deferred PP fix
-- BJL 10/30/2013 - ACTIVE_REV / MAX( SEQ_NBR ) related fixes
-- BJL ** NOTE ** - We are favoring an approach that de-emphasizes specifying G/L accounts only when used to 
--					recording all available, whether or not entries were made
-- BJL 11/12/2013 - Use multiple rows in AR_FUNCTION when there are multiple tax codes for production
-- BJL 11/13/2013 - Break out vendor tax for production
-- BJL 11/20/2013 - Added AB_NONRESALE_AMT
-- BJL 11/21/2013 - Added SUMMARY_ROW_ID to assist with join challenges related to taxed rows for rounding (not editing)
-- BJL 11/25/2013 - Fixed AR_INV_SEQ for co-op (skip master seq)
-- EC  01/07/2014 - Fixed Invoice Assignment by Campaign to include product for both media and production. 
-- PJH 01/15/2014 - Changed ORDER BY in Production grouping
-- PJH 06/03/2014 - Changed grouping (OFFICE included for all except Job & Component), By Campaign default to Job if Campaign is null
-- PJH 02/26/2015 - Added EMP_HOURS <> 0 to EMP_TIME_DTL include criteria
-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
-- MJC 09/29/2015 - insert the new FNC_CODE column now in INCOME_REC
-- MJC 11/05/2015 - combo billing invoice number asignment changes
-- MJC 06/01/2016 - added multi currency
-- MJC 06/15/2016 - added client/division combo billing
-- MJC 04/06/2017 - add overrides for assign invoices by
-- MJC 08/28/2017 - 735-1-3005 - BCC:  Assign Inv Nbr skips one nbr after combo client
-- PJH 07/27/2018 - Unit Split will be an agency level setting!/?
-- PJH 09/17/2018 - Unit Split tweaked split logic
-- PJH 09/24/2018 - Get office and income rec flag here
-- PJH 12/04/2018 - Add check for cross-office coop
-- MJC 01/10/2019 - --ignore this block (TT) - PJH 03/01/2019 - Removed this temp code
-- PJH 03/01/2019 - Meant for limiting @AR_ORDER_UNIT_LIST not TV_DETAIL
-- PJH 03/07/2019 - Tweaked unit virtual coop grouping
-- PJH 09/26/2019 - Update TV Unit processing to use D.MEDIA_MONTH, D.MEDIA_YEAR
-- PJH 07/01/2021 - Added @unit_split check
-- ************************************************************************************************************************

SET ANSI_WARNINGS OFF
SET NOCOUNT ON

--	**** {0.1} DECLARATIONS *************************************************************************************************************************
CREATE TABLE #AR_JOB_LIST (
	AR_JOB_LIST_ID				integer identity(1,1) NOT NULL,
	INV_BY						smallint NULL,
	JOB_NUMBER					integer NOT NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	COOP_PCT					decimal(9,4) NULL,
	FOLD_COOP_PCT				decimal(9,4) NULL,
	NP_COOP_SPLIT				smallint NULL,
	AB_REC_FLAG					smallint NULL,
	AR_INV_NBR					integer NULL,
	AR_INV_SEQ					smallint NULL,
	AR_DESCRIPTION				varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	OFFICE_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,	
	SC_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,			
	CMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,			
	CMP_IDENTIFIER				integer NULL,												-- BJL 04/24/2013 - Multi-campaign to one job fix										
	JOB_CL_PO_NBR				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_AB_FLAG					tinyint NULL,
	INV_TAX_FLAG				bit NULL,
	RECONCILING_FLAG			bit NOT NULL DEFAULT 0,
	ADJUST_FLAG					bit NULL,
	REJECTED_BY_OFFICE			bit NOT NULL,												-- If the co-op job crosses offices, set flag to prevent job from billing 
	CDP_CMP						AS CAST( 
								   CAST( COALESCE( CL_CODE, '' ) AS char(6)) 
								 + CAST( COALESCE( DIV_CODE, '' ) AS char(6)) 
								 + CAST( COALESCE( PRD_CODE, '' ) AS char(6))				-- BJL 04/24/2013 - Multi-campaign to one job fix
								 + CAST( COALESCE( CMP_CODE, '' ) AS char(6)) AS char(24))
)	

CREATE TABLE #AR_INV_SEQ ( AR_LIST_ID integer NOT NULL, AR_INV_SEQ smallint NULL )

CREATE TABLE #AR_ORDER_LIST (
	AR_ORDER_LIST_ID			integer identity(1,1) NOT NULL,
	ORDER_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,	-- ORDER_TYPE preferred to avoid confusion with MEDIA_TYPE (Sales class)	
	ORDER_NBR					integer NOT NULL,
	LINE_NBR					smallint NULL,
	COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	COOP_PCT					decimal(18,8) NULL, --decimal(9,4) NULL,
	BILL_COMM_NET				smallint NULL,
	AR_INV_NBR					integer NULL,
	AR_INV_SEQ					smallint NULL,
	AR_DESCRIPTION				varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	OFFICE_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CMP_IDENTIFIER				integer NULL,
	MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CLIENT_PO					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	INV_BY						smallint NULL,
	INC_FLAG					smallint NULL,
	UNITS						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	NEW_MEDIA					bit NOT NULL DEFAULT 1,
	ADJUST_FLAG					bit NULL,
	REJECTED_BY_OFFICE			bit NOT NULL,												-- If the co-op order crosses offices, set flag to prevent order from billing
	UNIT						integer NULL,
	HRS_QTY						decimal(18,2) NULL,
	REC_SRC						varchar(3) NULL,
	REVERSAL					smallint NULL
)	
CREATE CLUSTERED INDEX ix_tempAR_ORDER_LIST ON #AR_ORDER_LIST (ORDER_NBR,LINE_NBR)

DECLARE @AR_ORDER_UNIT_LIST TABLE (
	ORDER_NBR			integer NOT NULL,
	LINE_NBR			smallint NOT NULL,
	REV_NBR				smallint NOT NULL,
	--SEQ_NBR				smallint NOT NULL,
	HRS_QTY				decimal(18,2) NULL,
	TV_UNIT_PRODUCT_SPLIT bit NOT NULL
)	

DECLARE @tv_detail_units_revisions TABLE (
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL,
	[SEQ_NBR] [smallint] NOT NULL,
	[UNIT_NBR] [smallint] NOT NULL,
	[PRD_CODE] [varchar](6) NOT NULL,
	[UNIT_DATE] [smalldatetime] NOT NULL,
	[LINK_UNITID] [int] NULL,
	[UNITS] [int] NOT NULL, 
	[COOP_PCT] [decimal](20,10) NOT NULL,
	UNIQUE 
	(	[ORDER_NBR] ASC,
		[LINE_NBR] ASC,
		[REV_NBR] ASC,
		[SEQ_NBR] ASC,
		[UNIT_NBR] ASC
	)
)

-- BJL 03/05/2013 - Removed columns for media (added #AR_ORDER_DTL below)
CREATE TABLE #AR_FUNCTION_DTL (
	AR_FUNCTION_DTL_ID			integer identity(1,1) NOT NULL,
	AR_JOB_LIST_ID				integer NOT NULL,
	FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	HRS_QTY						decimal(18,2) NULL,											-- Don't split for coop.
	EMP_TIME_AMT				decimal(18,2) NULL,											-- Employee Time plus its markup
	INC_ONLY_AMT				decimal(18,2) NULL,											-- Income Only plus its markup
	COMMISSION_AMT				decimal(18,2) NULL,											-- Commission for the vendor amount
	COST_AMT					decimal(18,2) NULL,											-- Cost Amount			-- BJL 11/13/2013 - vendor tax removed
	AB_COST_AMT					decimal(18,2) NULL,											-- AB Prod Cost Amount	-- BJL 11/13/2013 - vendor tax removed
	AB_INC_AMT					decimal(18,2) NULL,											-- AB Prod Income Amount (Time or Income Only plus their markup)
	AB_COMMISSION_AMT			decimal(18,2) NULL,											-- AB Prod Commission (for Vendor Functions)
	AB_SALE_AMT					decimal(18,2) NULL,											-- This will be for AB Flag of 5 entries only.  It will use the normal Sales Account.
	TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AB_NONRESALE_AMT			decimal(18,2) NULL,											-- BJL 11/20/2013 - Vendor tax
	NON_RESALE_AMT				decimal(18,2) NULL,											-- BJL 11/13/2013 - Vendor tax
	CITY_TAX_AMT				decimal(18,2) NULL,											-- Resale City
	CNTY_TAX_AMT				decimal(18,2) NULL,											-- Resale County 
	STATE_TAX_AMT				decimal(18,2) NULL,											-- Resale State
	TOTAL_BILL					decimal(18,2) NULL,											-- Total Billing Amount, should be all amounts totaled.
	RECONCILE_ROW				bit NULL,
	AB_FLAG						smallint NULL,
	SUMMARY_FLAG				bit NULL
)		

CREATE TABLE #AR_ORDER_DTL (
	AR_ORDER_DTL_ID				integer identity(1,1) NOT NULL,
	AR_ORDER_LIST_ID			integer NOT NULL,
	REV_NBR						smallint NULL,
	SEQ_NBR						smallint NULL,
	RUN_DATE					smalldatetime NULL,
	CLOSE_DATE					smalldatetime NULL,
	END_DATE					smalldatetime NULL,
	MEDIA_MONTH					tinyint NULL,
	MEDIA_YEAR					smallint NULL,
	SALE_POST_PERIOD			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- Use for media deferred only
	NON_BILL_FLAG				smallint NULL,
	TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	HRS_QTY						decimal(18,2) NULL,											-- Don't split for coop.
-- ******************************************************************************************************************************************************************************************	
	COST_AMT					decimal(18,2) NULL,											
	LINE_TOTAL					decimal(18,2) NULL,											
	REBATE_AMT					decimal(18,2) NULL,											--  Media Rebate
	COMMISSION_AMT				decimal(18,2) NULL,											--  Commission for the vendor amount
	NET_CHARGE_AMT				decimal(18,2) NULL,											--  Media Net Charge
	NON_RESALE_AMT				decimal(18,2) NULL,											
	DISCOUNT_AMT				decimal(18,2) NULL,											
	ADDITIONAL_AMT				decimal(18,2) NULL,											
	CITY_TAX_AMT				decimal(18,2) NULL,											
	CNTY_TAX_AMT				decimal(18,2) NULL,											
	STATE_TAX_AMT				decimal(18,2) NULL,											
-- ******************************************************************************************************************************************************************************************
	SUMMARY_FLAG				bit NULL
)	
CREATE CLUSTERED INDEX ix_tempAR_ORDER_DTL ON #AR_ORDER_DTL (AR_ORDER_LIST_ID)	

-- BJL 04/03/2013 - Added table to simplify dynamic SQL for media
CREATE TABLE #ORDER_TYPE ( 
	ORDER_TYPE_ID				tinyint identity(1,1) NOT NULL, 
	ORDER_TYPE					char(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
	HEADER_TBL					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
	DETAIL_TBL					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
	DATE_1_COL					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
	DATE_2_COL					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
	MEDIA_MONTH_COL				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 				
	MEDIA_YEAR_COL				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	HRS_QTY_COL					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	USER_FLAG					bit NULL 
)

DECLARE @row_ct integer, @ar_inv_nbr integer, @coop_master_seq smallint

DECLARE @curr_inv_by tinyint, @curr_job_nbr integer, @curr_job_cmp_nbr smallint
DECLARE @curr_cl_code varchar(6), @curr_div_code varchar(6), @curr_prd_code varchar(6)
DECLARE @curr_po_nbr varchar(40), @curr_sc_code varchar(6), @curr_cmp_id integer
DECLARE @curr_off_code varchar(4), @curr_coop_code varchar(6), @curr_seq_nbr smallint
DECLARE @curr_order_type varchar(1), @curr_market_code varchar(10), @curr_order_nbr integer 
DECLARE @curr_date_1_col varchar(20), @curr_date_2_col varchar(20), @fold_fnc_code varchar(6)
DECLARE @curr_media_mth_col varchar(20), @curr_media_yr_col varchar(20), @inv_tax_flag bit
DECLARE @assign_inv smallint, @first_inv integer, @last_inv integer, @magazine bit
DECLARE @media bit, @newspaper bit, @outdoor bit, @production bit, @radio bit, @curr_hrs_qty_col varchar(20)
DECLARE @service_fees smallint, @television bit, @adjust smallint, @internet bit
DECLARE @post_period varchar(6), @inv_date smalldatetime, @sql_exit tinyint, @curr_ord_type char(1)
DECLARE @sql_select varchar(4000), @header_tbl varchar(20), @detail_tbl varchar(30), @detail_tbl2 varchar(30)
DECLARE @job_row_ct int, @media_row_ct int
DECLARE @use_combo bit, @combo_inv_by_override smallint, @prod_inv_by_override smallint, @media_inv_by_override smallint
DECLARE @unit_split bit = 0 /* PJH 07/27/2018 - will be an agency level setting? */

--	**** {0.2} INITIALIZATIONS **********************************************************************************************************************
SET @ret_val = 0
SET @coop_master_seq = 99
SET @ar_inv_nbr = 0

-- BJL 04/03/2013 - #ORDER_TYPE table is used to help create dynamic SQL for media (to account for column name differences)
INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
	 VALUES ( 'M', 'MAGAZINE_HEADER', 'MAGAZINE_DETAIL', 'B.[START_DATE]', 'MONTH(B.START_DATE)', 'YEAR(B.START_DATE)', 'NULL' )
INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
	 VALUES ( 'N', 'NEWSPAPER_HEADER', 'NEWSPAPER_DETAIL', 'B.[START_DATE]', 'MONTH(B.START_DATE)', 'YEAR(B.START_DATE)', 'D.PRINT_LINES' )
INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
	 VALUES ( 'I', 'INTERNET_HEADER', 'INTERNET_DETAIL', 'B.[START_DATE]', 'MONTH(B.START_DATE)', 'YEAR(B.START_DATE)', 'D.GUARANTEED_IMPRESS' )
INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
	 VALUES ( 'O', 'OUTDOOR_HEADER', 'OUTDOOR_DETAIL', 'B.POST_DATE', 'MONTH(B.POST_DATE)', 'YEAR(B.POST_DATE)', 'NULL' )
--INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
--	 VALUES ( 'R', 'RADIO_HDR', 'RADIO_DETAIL', 'D.[START_DATE]', 'MONTH(D.START_DATE)', 'YEAR(D.START_DATE)', 'D.TOTAL_SPOTS' )
--INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
--	 VALUES ( 'T', 'TV_HDR', 'TV_DETAIL', 'D.[START_DATE]', 'MONTH(D.START_DATE)', 'YEAR(D.START_DATE)', 'D.TOTAL_SPOTS' )
INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
	 VALUES ( 'R', 'RADIO_HDR', 'RADIO_DETAIL', 'B.[START_DATE]', 'B.MONTH_NBR', 'B.YEAR_NBR', 'D.TOTAL_SPOTS' )
INSERT INTO #ORDER_TYPE ( ORDER_TYPE, HEADER_TBL, DETAIL_TBL, DATE_1_COL, MEDIA_MONTH_COL, MEDIA_YEAR_COL, HRS_QTY_COL ) 
	 VALUES ( 'T', 'TV_HDR', 'TV_DETAIL', 'B.[START_DATE]', 'B.MONTH_NBR', 'B.YEAR_NBR', 'D.TOTAL_SPOTS' )

--	**** {1.0} RETRIEVE BILLING TABLE ***************************************************************************************************************
IF ( @ret_val = 0 )
BEGIN
	-- BJL 02/28/2013 - Retrieve the BILLING table values
	 SELECT @assign_inv = b.INV_ASSIGN, @first_inv = b.FIRST_INV, @last_inv = b.LAST_INV, @magazine = b.MAGAZINE, @media = b.MEDIA, 
			@newspaper = b.NEWSPAPER, @outdoor = b.OUTDOOR, @production = b.PRODUCTION, @radio = b.RADIO, @service_fees = b.SERVICE_FEES, 
			@television = b.TELEVISION, @adjust = b.ADJUSTMENTS, @internet = b.INTERNET, @post_period = b.POST_PERIOD, @inv_date = b.INV_DATE,
			@inv_tax_flag = a.INV_TAX_FLAG, @use_combo = [USE_COMBO_BILLING_OVERRIDE], @combo_inv_by_override = [COMBO_INV_BY_OVERRIDE],
			@prod_inv_by_override = [CL_INV_BY_OVERRIDE], @media_inv_by_override = [CL_MINV_BY_OVERRIDE]
	   FROM dbo.BILLING b INNER JOIN dbo.AGENCY a 
	     ON ( b.BILLING_USER = @billing_user_in )
	  
	SET @row_ct = @@ROWCOUNT
	SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	IF ( @row_ct = 1 )
	BEGIN
		IF ( @assign_inv = 1 )
			SET @ret_val = -1																-- ! Invoices have already been assigned
	END
	ELSE
		SET @ret_val = -3																	-- ! No billing record exists for the current user
END

--	**** { } GET FOLD FUNCTION **********************************************************************************************************************
IF ( @ret_val = 0 )
BEGIN
	SELECT @fold_fnc_code = CAST( AGY_SETTINGS_VALUE AS varchar(6) )
	  FROM dbo.AGY_SETTINGS
	 WHERE AGY_SETTINGS_CODE = 'FOLD_FUNCTION'

	SET @ret_val = @@ERROR
END

--	**** {1.5} CLEAR W_AR_FUNCTION TABLE ************************************************************************************************************
EXECUTE [dbo].[advsp_delete_ar_function] @billing_user_in, @ret_val = @ret_val OUTPUT

--	**** {2.0} GATHER PRODUCTION JOBS ***************************************************************************************************************
IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	-- Populate production jobs selected by user
	INSERT INTO #AR_JOB_LIST ( 
				JOB_NUMBER, JOB_COMPONENT_NBR, COOP_CODE, CL_CODE, DIV_CODE, PRD_CODE, 
				AB_REC_FLAG, COOP_PCT, FOLD_COOP_PCT, NP_COOP_SPLIT, OFFICE_CODE, 
				SC_CODE, CMP_CODE, CMP_IDENTIFIER, JOB_CL_PO_NBR, JOB_AB_FLAG, INV_BY, 
				REJECTED_BY_OFFICE, AR_INV_SEQ )	
-- **** Single client jobs **************************************************************************************************							
		 SELECT B.JOB_NUMBER, B.JOB_COMPONENT_NBR, 
				CASE A.NP_COOP_SPLIT WHEN 1 THEN '******' ELSE A.BILL_COOP_CODE END, 
				A.CL_CODE, 
				A.DIV_CODE, 
				A.PRD_CODE, 
				B.PRD_AB_INCOME, 
				CASE WHEN ( A.BILL_COOP_CODE IS NOT NULL OR A.NP_COOP_SPLIT = 1 ) THEN NULL ELSE 100.000 END, 
				CASE WHEN ( A.BILL_COOP_CODE IS NOT NULL OR A.NP_COOP_SPLIT = 1 ) THEN NULL ELSE 100.000 END, 
				A.NP_COOP_SPLIT, 
				A.OFFICE_CODE, 
				A.SC_CODE, 
				cmp.CMP_CODE,																-- BJL 04/24/2013 - Multi-campaign to one job fix
				A.CMP_IDENTIFIER, 
				B.JOB_CL_PO_NBR, 
				B.AB_FLAG, 
				CASE WHEN COALESCE(C.COMBO_INV_BY, 0) <> 0 THEN C.COMBO_INV_BY ELSE C.CL_INV_BY END, 
				0,
				CASE WHEN ( A.BILL_COOP_CODE IS NOT NULL OR A.NP_COOP_SPLIT = 1 ) THEN @coop_master_seq ELSE 0 END
		   FROM dbo.JOB_LOG A 
	 INNER JOIN dbo.JOB_COMPONENT B 
			 ON ( A.JOB_NUMBER = B.JOB_NUMBER )
	 INNER JOIN dbo.CLIENT C 
			 ON ( A.CL_CODE = C.CL_CODE )
	 INNER JOIN dbo.PRODUCT E 
			 ON ( A.CL_CODE = E.CL_CODE ) 
			AND ( A.DIV_CODE = E.DIV_CODE ) 
			AND ( A.PRD_CODE = E.PRD_CODE )
LEFT OUTER JOIN dbo.CAMPAIGN cmp															-- BJL 04/24/2013 - Multi-campaign to one job fix
		     ON ( A.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER )
		  WHERE ( B.BILLING_USER = @billing_user_in )
		    AND	( B.JOB_BILL_HOLD IS NULL OR B.JOB_BILL_HOLD = 0 )
	  UNION ALL	
-- **** Co-op jobs (regular) ************************************************************************************************
		 SELECT B.JOB_NUMBER, 
				B.JOB_COMPONENT_NBR, 
				G.BILL_COOP_CODE, 
				G.CL_CODE, 
				G.DIV_CODE, 
				G.PRD_CODE, 
				B.PRD_AB_INCOME, 
				G.COOP_PCT, 
				NULL, 
				0, 
				E.OFFICE_CODE, 
				A.SC_CODE, 
				cmp.CMP_CODE,																-- BJL 04/24/2013 - Multi-campaign to one job fix
				A.CMP_IDENTIFIER, 
				B.JOB_CL_PO_NBR, 
				B.AB_FLAG, 
				CASE WHEN COALESCE(C.COMBO_INV_BY, 0) <> 0 THEN C.COMBO_INV_BY ELSE C.CL_INV_BY END,
				0, 
				NULL
		   FROM dbo.JOB_LOG A 
	 INNER JOIN dbo.JOB_COMPONENT B 
			 ON ( A.JOB_NUMBER = B.JOB_NUMBER )
LEFT OUTER JOIN dbo.BILLING_COOP G
			 ON ( A.BILL_COOP_CODE = G.BILL_COOP_CODE )
LEFT OUTER JOIN dbo.CLIENT C
			 ON ( G.CL_CODE = C.CL_CODE ) 
LEFT OUTER JOIN dbo.PRODUCT E 
			 ON ( G.CL_CODE = E.CL_CODE ) 
			AND ( G.DIV_CODE = E.DIV_CODE ) 
			AND ( G.PRD_CODE = E.PRD_CODE )	
LEFT OUTER JOIN dbo.CAMPAIGN cmp															-- BJL 04/24/2013 - Multi-campaign to one job fix
		     ON ( A.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER )
		  WHERE	( A.BILL_COOP_CODE IS NOT NULL )
		    AND ( A.NP_COOP_SPLIT = 0 OR A.NP_COOP_SPLIT IS NULL )
		    AND ( B.BILLING_USER = @billing_user_in )
		    AND	( B.JOB_BILL_HOLD IS NULL OR B.JOB_BILL_HOLD = 0 )
	  UNION ALL		    
-- **** Co-op campaigns (from AR_COOP_TMP) **********************************************************************************
		 SELECT B.JOB_NUMBER, 
				B.JOB_COMPONENT_NBR, 
				'******',																	-- One-time use co-op code
				H.CL_CODE, 
				H.DIV_CODE, 
				H.PRD_CODE, 
				B.PRD_AB_INCOME, 
				H.COOP_PCT, 
				H.FOLD_PCT, 
				1, 
				COALESCE( E.OFFICE_CODE, '****' ), 
				A.SC_CODE, 
				cmp.CMP_CODE,																-- BJL 04/24/2013 - Multi-campaign to one job fix
				H.CMP_IDENTIFIER, 
				B.JOB_CL_PO_NBR, 
				B.AB_FLAG, 
				CASE WHEN COALESCE(C.COMBO_INV_BY, 0) <> 0 THEN C.COMBO_INV_BY ELSE C.CL_INV_BY END,
				0, 
				NULL
		   FROM dbo.JOB_LOG A 
	 INNER JOIN dbo.JOB_COMPONENT B 
			 ON ( A.JOB_NUMBER = B.JOB_NUMBER )
LEFT OUTER JOIN dbo.AR_COOP_TMP H
			 ON ( A.JOB_NUMBER = H.JOB_NUMBER )
			AND ( B.JOB_COMPONENT_NBR = H.JOB_COMPONENT_NBR )
LEFT OUTER JOIN dbo.CLIENT C
			 ON ( H.CL_CODE = C.CL_CODE ) 
LEFT OUTER JOIN dbo.PRODUCT E 
			 ON ( H.CL_CODE = E.CL_CODE ) 
			AND ( H.DIV_CODE = E.DIV_CODE ) 
			AND ( H.PRD_CODE = E.PRD_CODE )		
LEFT OUTER JOIN dbo.CAMPAIGN cmp															-- BJL 04/24/2013 - Multi-campaign to one job fix
		     ON ( H.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER )
		  WHERE	( A.NP_COOP_SPLIT = 1 )
		    AND ( B.BILLING_USER = @billing_user_in )
		    AND	( B.JOB_BILL_HOLD IS NULL OR B.JOB_BILL_HOLD = 0 )
	   ORDER BY 1 ASC, 2 ASC, 7 ASC, 3 ASC, 4 ASC, 5 ASC

	SET @ret_val = @@ERROR

	-- BJL 05/24/2013 - Validate co-op pcts sum to 100%
	IF ( @ret_val = 0 )
	BEGIN
		--SELECT '#AR_JOB_LIST' '#AR_JOB_LIST', * FROM #AR_JOB_LIST
		IF EXISTS(SELECT 1 FROM #AR_JOB_LIST WHERE NULLIF(COOP_CODE,'') IS NOT NULL AND COOP_CODE NOT IN (select BILL_COOP_CODE from dbo.BILLING_COOP))
			SET @ret_val = -5

		ELSE IF EXISTS(SELECT 1 FROM #AR_JOB_LIST WHERE NULLIF(COOP_CODE,'') IS NOT NULL)
			IF EXISTS( SELECT 1
							  FROM #AR_JOB_LIST jl 
						INNER JOIN dbo.BILLING_COOP bc 
								ON ( jl.COOP_CODE = bc.BILL_COOP_CODE )
							 WHERE ( bc.INACTIVE_FLAG IS NULL OR bc.INACTIVE_FLAG = 0 )
							   AND ( jl.AR_INV_SEQ NOT IN ( @coop_master_seq, 0 ))
						  GROUP BY bc.BILL_COOP_CODE, jl.JOB_NUMBER, jl.JOB_COMPONENT_NBR
							HAVING ( SUM( bc.COOP_PCT ) <> 100 ))
				SET @ret_val = -5

	END
	
	-- BJL 09/27/2013 - Trap invalid office
	IF ( @ret_val = 0 )
	BEGIN
		SELECT @ret_val = ( SELECT DISTINCT -6
							  FROM #AR_JOB_LIST 
							 WHERE ( OFFICE_CODE = '****' ))
							
		IF ( @ret_val IS NULL OR @ret_val = 0 )
			SET @ret_val = @@ERROR
		
	END

	-- BJL 02/05/2012 - Flag co-op jobs with cross-offices
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE JL
		   SET REJECTED_BY_OFFICE = 1
		  FROM #AR_JOB_LIST JL
		 WHERE (( 	SELECT COUNT( DISTINCT jl.OFFICE_CODE ) 
					  FROM #AR_JOB_LIST jl 
					 WHERE jl.JOB_NUMBER = JL.JOB_NUMBER
					   AND jl.JOB_COMPONENT_NBR = JL.JOB_COMPONENT_NBR			
					   AND jl.COOP_PCT IS NOT NULL ) > 1 )
		   AND COOP_PCT IS NOT NULL 
		
		SET @ret_val = @@ERROR		
	END	

	-- BJL 01/05/2013 - This statement flags one co-op client to apply rounding differences later
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE #AR_JOB_LIST
		   SET ADJUST_FLAG = 1
		 WHERE NOT EXISTS ( SELECT * 
							  FROM #AR_JOB_LIST jl 
							 WHERE jl.JOB_NUMBER = #AR_JOB_LIST.JOB_NUMBER
							   AND jl.JOB_COMPONENT_NBR = #AR_JOB_LIST.JOB_COMPONENT_NBR			
							   AND jl.AR_JOB_LIST_ID > #AR_JOB_LIST.AR_JOB_LIST_ID
							   AND jl.COOP_PCT IS NOT NULL )
		   AND ( COOP_PCT IS NOT NULL )
							   
		SET @ret_val = @@ERROR 							   
	END	
	
END

--	**** {3.0} GATHER MEDIA ORDERS ******************************************************************************************************************
IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	-- BJL 04/03/2013 - Modified to use dynamic SQL - cuts down on duplication of code
	UPDATE #ORDER_TYPE SET USER_FLAG = 0

	/* PJH 07/27/2018 - will be an agency level setting? */
	SELECT @unit_split = COALESCE(MIN(ID),0) FROM TV_DETAIL_UNITS u JOIN TV_DETAIL d ON u.ORDER_NBR = d.ORDER_NBR AND d.BILLING_USER = @billing_user_in

	IF @unit_split > 0 SET @unit_split = 1

	--SET @unit_split = 0 /* Set to 0 turn unit split off for testing */
		
	WHILE ( @ret_val = 0 )
	BEGIN
		SET @curr_ord_type = NULL
		SET @header_tbl = NULL
		SET @detail_tbl = NULL 
		SET @detail_tbl2 = NULL 
		
		SELECT TOP 1 @curr_ord_type = ORDER_TYPE, @header_tbl = HEADER_TBL, @detail_tbl = DETAIL_TBL
		  FROM #ORDER_TYPE
		 WHERE USER_FLAG = 0
 		   AND ( HEADER_TBL IS NOT NULL )
		   AND ( DETAIL_TBL IS NOT NULL )
	  ORDER BY ORDER_TYPE_ID ASC
	  
		IF @curr_ord_type IN ( 'M', 'N', 'I', 'O', 'R', 'T' )
		BEGIN

			/* PJH 07/27/2018 - will be an client level setting */
			IF @curr_ord_type <> 'T' --OR @unit_split = 0  --ignore this block
			BEGIN		
				SELECT @sql_select = ''
				SELECT @sql_select = @sql_select + CHAR(13) + '			INSERT INTO #AR_ORDER_LIST ( '
				SELECT @sql_select = @sql_select + CHAR(13) + '					ORDER_NBR, ORDER_TYPE, LINE_NBR, COOP_CODE, BILL_COMM_NET, COOP_PCT, ' 
				SELECT @sql_select = @sql_select + CHAR(13) + '					NEW_MEDIA, CL_CODE, DIV_CODE, PRD_CODE, REJECTED_BY_OFFICE, INC_FLAG, '
				SELECT @sql_select = @sql_select + CHAR(13) + '					OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, INV_BY, CLIENT_PO, MARKET_CODE, AR_INV_SEQ ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '			 SELECT DISTINCT '
				SELECT @sql_select = @sql_select + CHAR(13) + '					d.ORDER_NBR, ''' + @curr_ord_type + ''', d.LINE_NBR, h.BILL_COOP_CODE, d.BILL_TYPE_FLAG, '
				SELECT @sql_select = @sql_select + CHAR(13) + '					CASE WHEN h.BILL_COOP_CODE IS NOT NULL THEN NULL ELSE 100.000 END, '
				SELECT @sql_select = @sql_select + CHAR(13) + '					1, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, 0, o.MED_AB_INCOME, h.OFFICE_CODE, '
				SELECT @sql_select = @sql_select + CHAR(13) + '					h.MEDIA_TYPE, h.CMP_IDENTIFIER, CASE WHEN COALESCE(c.COMBO_INV_BY, 0) <> 0 THEN c.COMBO_INV_BY ELSE c.CL_MINV_BY END, h.CLIENT_PO, h.MARKET_CODE, ' 
				SELECT @sql_select = @sql_select + CHAR(13) + '					CASE WHEN h.BILL_COOP_CODE IS NOT NULL THEN ' + CAST( @coop_master_seq AS varchar(3)) + ' ELSE 0 END ' 
				SELECT @sql_select = @sql_select + CHAR(13) + '			   FROM dbo.' + @header_tbl + ' h '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.' + @detail_tbl + ' d ON ( h.ORDER_NBR = d.ORDER_NBR ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.CLIENT c  ON ( h.CL_CODE = c.CL_CODE ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN	dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN	dbo.OFFICE o ON ( h.OFFICE_CODE = o.OFFICE_CODE ) '
				SELECT @sql_select = @sql_select + CHAR(13) + ' LEFT OUTER JOIN dbo.CAMPAIGN cmp  ON ( h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '			  WHERE ( d.BILLING_USER = ''' + @billing_user_in + ''' ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( d.AR_INV_NBR IS NULL ) '
				SELECT @sql_select = @sql_select + CHAR(13) + ' UNION ALL '
				SELECT @sql_select = @sql_select + CHAR(13) + '			 SELECT DISTINCT '
				SELECT @sql_select = @sql_select + CHAR(13) + '					d.ORDER_NBR, ''' + @curr_ord_type + ''', d.LINE_NBR, h.BILL_COOP_CODE, d.BILL_TYPE_FLAG, '
				SELECT @sql_select = @sql_select + CHAR(13) + '					bc.COOP_PCT, 1, bc.CL_CODE, bc.DIV_CODE, bc.PRD_CODE, 0, o.MED_AB_INCOME, p.OFFICE_CODE, '
				SELECT @sql_select = @sql_select + CHAR(13) + '					h.MEDIA_TYPE, h.CMP_IDENTIFIER, CASE WHEN COALESCE(c.COMBO_INV_BY, 0) <> 0 THEN c.COMBO_INV_BY ELSE c.CL_MINV_BY END, h.CLIENT_PO, h.MARKET_CODE, NULL ' 
				SELECT @sql_select = @sql_select + CHAR(13) + '			   FROM dbo.' + @header_tbl + ' h '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.' + @detail_tbl + ' d ON ( h.ORDER_NBR = d.ORDER_NBR ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN	dbo.BILLING_COOP bc ON ( h.BILL_COOP_CODE = bc.BILL_COOP_CODE ) '			
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.CLIENT c  ON ( bc.CL_CODE = c.CL_CODE ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN	dbo.PRODUCT p ON ( bc.CL_CODE = p.CL_CODE AND bc.DIV_CODE = p.DIV_CODE AND bc.PRD_CODE = p.PRD_CODE ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN	dbo.OFFICE o ON ( p.OFFICE_CODE = o.OFFICE_CODE ) '
				SELECT @sql_select = @sql_select + CHAR(13) + ' LEFT OUTER JOIN dbo.CAMPAIGN cmp  ON ( h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '			  WHERE ( d.BILLING_USER = ''' + @billing_user_in + ''' ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( d.AR_INV_NBR IS NULL ) '
				SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( h.BILL_COOP_CODE IS NOT NULL ) '
			
				IF ( @ret_val = 0 )
				BEGIN
					EXECUTE ( @sql_select )
					SELECT @ret_val = @@ERROR, @row_ct = @@ROWCOUNT
				END
			END

			/* PJH 07/27/2018 - will be an agency level setting? */

			IF @curr_ord_type = 'T' --ignore this block
			BEGIN

				-- PJH 09/17/2018 - Unit Split tweaked split logic
				/* Sums units/spots by order/line = total spot to split */
				INSERT INTO @AR_ORDER_UNIT_LIST ( 
						ORDER_NBR, LINE_NBR, REV_NBR, HRS_QTY, TV_UNIT_PRODUCT_SPLIT ) 
					SELECT DISTINCT 
						/* PJH 03/01/2018 - added ABS for Units, added d.REV_NBR = u.REV_NBR */
						d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, SUM(ABS(u.UNITS)) 'HRS_QTY', c.TV_UNIT_PRODUCT_SPLIT
					FROM dbo.TV_HDR h 
							 INNER JOIN dbo.TV_DETAIL d ON ( h.ORDER_NBR = d.ORDER_NBR ) 
							 INNER JOIN	dbo.TV_DETAIL_UNITS u ON ( d.ORDER_NBR = u.ORDER_NBR AND d.LINE_NBR = u.LINE_NBR AND d.REV_NBR = u.REV_NBR ) 
							 INNER JOIN dbo.CLIENT c  ON ( h.CL_CODE = c.CL_CODE ) 
							 INNER JOIN	dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE ) 
							 INNER JOIN	dbo.OFFICE o ON ( p.OFFICE_CODE = o.OFFICE_CODE ) 
					 LEFT OUTER JOIN dbo.CAMPAIGN cmp  ON ( h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER ) 
								  WHERE ( d.BILLING_USER =  @billing_user_in )
									AND ( d.AR_INV_NBR IS NULL ) AND (d.ACTIVE_REV = 1) --h.BILL_COOP_CODE = 'units' AND
					GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, c.TV_UNIT_PRODUCT_SPLIT

				/* Coop master (99) record */
				INSERT INTO #AR_ORDER_LIST ( 
						ORDER_NBR, ORDER_TYPE, LINE_NBR, 
						COOP_CODE, 
						BILL_COMM_NET, COOP_PCT, 
						NEW_MEDIA, CL_CODE, DIV_CODE, PRD_CODE, REJECTED_BY_OFFICE, INC_FLAG, 
						OFFICE_CODE, SC_CODE, CMP_IDENTIFIER, INV_BY, CLIENT_PO, MARKET_CODE, AR_INV_SEQ, UNIT, HRS_QTY, REC_SRC ) 
					SELECT DISTINCT 
						d.ORDER_NBR, @curr_ord_type, d.LINE_NBR, 
						CASE WHEN ( e.TV_UNIT_PRODUCT_SPLIT = 1 AND h.BILL_COOP_CODE IS NULL AND e.ORDER_NBR IS NOT NULL) THEN 'units!' ELSE h.BILL_COOP_CODE END, --h.BILL_COOP_CODE, 
						d.BILL_TYPE_FLAG, 
						CASE WHEN h.BILL_COOP_CODE IS NOT NULL OR (e.TV_UNIT_PRODUCT_SPLIT = 1 AND h.BILL_COOP_CODE IS NULL) THEN NULL ELSE 100.000 END, 1, 
						h.CL_CODE, h.DIV_CODE, h.PRD_CODE, 0, o.MED_AB_INCOME, p.OFFICE_CODE, 
						h.MEDIA_TYPE, h.CMP_IDENTIFIER, CASE WHEN COALESCE(c.COMBO_INV_BY, 0) <> 0 THEN c.COMBO_INV_BY ELSE c.CL_MINV_BY END, h.CLIENT_PO, h.MARKET_CODE, 
						/* PJH 03/01/2019 - removed d.TOTAL_SPOTS - Set later */
						CASE WHEN h.BILL_COOP_CODE IS NOT NULL OR ( h.BILL_COOP_CODE IS NULL AND c.TV_UNIT_PRODUCT_SPLIT = 1 ) THEN CAST( @coop_master_seq AS varchar(3)) ELSE 0 END, NULL, 0 /*d.TOTAL_SPOTS*/, '99' 
					FROM dbo.TV_HDR h 
						 INNER JOIN dbo.TV_DETAIL d ON ( h.ORDER_NBR = d.ORDER_NBR ) 
						 INNER JOIN dbo.CLIENT c  ON ( h.CL_CODE = c.CL_CODE ) 
						 INNER JOIN	dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE ) 
						 INNER JOIN	dbo.OFFICE o ON ( p.OFFICE_CODE = o.OFFICE_CODE ) 
						LEFT OUTER JOIN @AR_ORDER_UNIT_LIST e ON ( d.ORDER_NBR = e.ORDER_NBR AND d.LINE_NBR = e.LINE_NBR ) 
						LEFT OUTER JOIN dbo.CAMPAIGN cmp  ON ( h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER ) 
							  WHERE ( d.BILLING_USER = @billing_user_in ) 
								AND ( d.AR_INV_NBR IS NULL ) --AND (d.ACTIVE_REV = 1)  -- PJH 03/01/2019 - Meant for limiting @AR_ORDER_UNIT_LIST not #AR_ORDER_LIST

				 UNION ALL
					/* Original code for coop split */
					SELECT DISTINCT 
						d.ORDER_NBR, @curr_ord_type , d.LINE_NBR, h.BILL_COOP_CODE, d.BILL_TYPE_FLAG, 
						bc.COOP_PCT, 1, bc.CL_CODE, bc.DIV_CODE, bc.PRD_CODE, 0, o.MED_AB_INCOME, p.OFFICE_CODE,
						h.MEDIA_TYPE, h.CMP_IDENTIFIER, CASE WHEN COALESCE(c.COMBO_INV_BY, 0) <> 0 THEN c.COMBO_INV_BY ELSE c.CL_MINV_BY END 'INV_BY', h.CLIENT_PO, h.MARKET_CODE, NULL, NULL, NULL, 'ORG'
					FROM dbo.TV_HDR h 
							 INNER JOIN dbo.TV_DETAIL d ON ( h.ORDER_NBR = d.ORDER_NBR ) 
							 INNER JOIN	dbo.BILLING_COOP bc ON ( h.BILL_COOP_CODE = bc.BILL_COOP_CODE )
							 INNER JOIN dbo.CLIENT c  ON ( bc.CL_CODE = c.CL_CODE ) 
							 INNER JOIN	dbo.PRODUCT p ON ( bc.CL_CODE = p.CL_CODE AND bc.DIV_CODE = p.DIV_CODE AND bc.PRD_CODE = p.PRD_CODE ) 
							 INNER JOIN	dbo.OFFICE o ON ( p.OFFICE_CODE = o.OFFICE_CODE ) 
						LEFT OUTER JOIN dbo.CAMPAIGN cmp  ON ( h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER ) 
						--LEFT OUTER JOIN @AR_ORDER_UNIT_LIST e ON ( d.ORDER_NBR = e.ORDER_NBR AND d.LINE_NBR = e.LINE_NBR ) 
								  WHERE ( d.BILLING_USER =  @billing_user_in )
									AND ( d.AR_INV_NBR IS NULL ) AND ( h.BILL_COOP_CODE IS NOT NULL ) --AND ( e.TV_UNIT_PRODUCT_SPLIT IS NULL OR e.TV_UNIT_PRODUCT_SPLIT = 0)

				 UNION ALL
					/* New code for unit split */
					/* There can be multiple revisions billed at one time */

					--INSERT INTO @tv_detail_units_revisions
					--SELECT ORDER_NBR, ORDER_TYPE, LINE_NBR, 
					--	COOP_CODE, 
					--	BILL_COMM_NET, COOP_PCT, 
					--	NEW_MEDIA, CL_CODE, DIV_CODE, PRD_CODE, REJECTED_BY_OFFICE, INC_FLAG, OFFICE_CODE,
					--	SC_CODE, CMP_IDENTIFIER, INV_BY, CLIENT_PO, MARKET_CODE, AR_INV_SEQ, UNIT, HRS_QTY, REC_SRC
					--FROM #AR_ORDER_LIST O

					SELECT DISTINCT 
						d.ORDER_NBR, @curr_ord_type , d.LINE_NBR, 
						CASE WHEN (  x.TV_UNIT_PRODUCT_SPLIT = 1 ) THEN 'units!' ELSE h.BILL_COOP_CODE END, --h.BILL_COOP_CODE, 
						d.BILL_TYPE_FLAG, 
						--CAST(CAST(u.UNITS AS decimal(18,2)) / CAST(d.TOTAL_SPOTS AS decimal(18,2)) * 100 AS decimal(18,8)) 'COOP_PCT', 1, 
						CAST(CAST(u.UNITS AS decimal(18,2)) / CAST(x.HRS_QTY AS decimal(18,2)) * 100 AS decimal(18,8)) 'COOP_PCT', 1, 
						h.CL_CODE, h.DIV_CODE, u.PRD_CODE, 0, NULL, NULL, --o.MED_AB_INCOME, p.OFFICE_CODE, 
						-- PJH 03/07/2019 - Tweaked unit virtual coop grouping
						h.MEDIA_TYPE, h.CMP_IDENTIFIER, CASE WHEN COALESCE(c.COMBO_INV_BY, 0) <> 0 THEN c.COMBO_INV_BY ELSE c.CL_MINV_BY END 'INV_BY', 
						h.CLIENT_PO, h.MARKET_CODE, NULL, 0 /*u.UNIT_NBR*/, u.UNITS, 'DTL'
					FROM dbo.TV_HDR h 
							 INNER JOIN dbo.TV_DETAIL d ON ( h.ORDER_NBR = d.ORDER_NBR ) 
								INNER JOIN (
									SELECT  U.ORDER_NBR, U.LINE_NBR, U.PRD_CODE, SUM(UNITS) AS UNITS --U.UNIT_NBR, UNITS -- PJH 03/07/2019 - Tweaked unit virtual coop grouping
									FROM dbo.TV_DETAIL_UNITS U GROUP BY U.ORDER_NBR, U.LINE_NBR, U.PRD_CODE
									UNION ALL
									SELECT D.ORDER_NBR, D.LINE_NBR, H.PRD_CODE, D.TOTAL_SPOTS --1, D.TOTAL_SPOTS  -- PJH 03/07/2019 - Tweaked unit virtual coop grouping
										FROM TV_DETAIL D
										JOIN TV_HDR H ON D.ORDER_NBR = H.ORDER_NBR
										LEFT JOIN TV_DETAIL_UNITS U ON D.ORDER_NBR = U.ORDER_NBR AND D.LINE_NBR = U.LINE_NBR
										WHERE U.ORDER_NBR IS NULL 
									) u ON ( d.ORDER_NBR = u.ORDER_NBR AND d.LINE_NBR = u.LINE_NBR )
							 INNER JOIN dbo.CLIENT c  ON ( h.CL_CODE = c.CL_CODE ) 
							 INNER JOIN @AR_ORDER_UNIT_LIST x ON ( d.ORDER_NBR = x.ORDER_NBR AND d.LINE_NBR = x.LINE_NBR ) 
						LEFT OUTER JOIN dbo.CAMPAIGN cmp  ON ( h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER ) 
								  WHERE ( d.BILLING_USER =  @billing_user_in )
									AND ( d.AR_INV_NBR IS NULL ) AND ( x.TV_UNIT_PRODUCT_SPLIT = 1 ) AND ( h.BILL_COOP_CODE IS NULL )

				IF ( @ret_val = 0 )
				BEGIN
					SELECT @ret_val = @@ERROR, @row_ct = @@ROWCOUNT
				END

				/* PJH 03/01/2019 - Unit code */
				UPDATE A
				SET A.AR_INV_SEQ = 0
				FROM #AR_ORDER_LIST A 
				LEFT JOIN (
					SELECT DISTINCT U.ORDER_NBR, U.LINE_NBR FROM TV_DETAIL_UNITS U
					JOIN TV_HDR H ON U.ORDER_NBR = H.ORDER_NBR
					JOIN BILLING_CMD_CENTER B ON H.BCC_ID = B.BCC_ID
					WHERE B.BILLING_USER = @billing_user_in
					) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
				WHERE 	--B.ORDER_NBR IS NULL /** No matching unit detail **/
					COOP_PCT IS NOT NULL
					AND COOP_CODE IS NULL
					AND A.AR_INV_SEQ = 99

				/* Clear temp seq that came from unit number */
				UPDATE #AR_ORDER_LIST
				SET AR_INV_SEQ = NULL, UNITS = NULL WHERE (AR_INV_SEQ <> 99 OR AR_INV_SEQ IS NULL) AND UNIT IS NOT NULL

				/* Get office and income rec flag here */
				UPDATE A
				SET A.OFFICE_CODE = B.OFFICE_CODE, A.INC_FLAG = C.MED_AB_INCOME
				FROM #AR_ORDER_LIST A
					INNER JOIN PRODUCT B ON ( A.CL_CODE = B.CL_CODE AND A.DIV_CODE = B.DIV_CODE AND A.PRD_CODE = B.PRD_CODE ) 
					INNER JOIN dbo.OFFICE C ON ( B.OFFICE_CODE = C.OFFICE_CODE ) 
				WHERE COOP_CODE = 'units!'

				/* PJH 03/01/2019 - Update Hrs here */
				UPDATE A
				SET A.HRS_QTY = B.HRS_QTY
				FROM #AR_ORDER_LIST A
					INNER JOIN (
					SELECT ORDER_NBR, LINE_NBR, SUM(HRS_QTY) HRS_QTY FROM @AR_ORDER_UNIT_LIST 
					GROUP BY ORDER_NBR, LINE_NBR
					) B ON ( A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR ) 
				WHERE A.COOP_CODE = 'units!' AND A.AR_INV_SEQ = 99  /* <<<<<<<<<<< */

				/* For reversal entries */
				--UPDATE #AR_ORDER_LIST
				--SET COOP_PCT = CASE WHEN HRS_QTY < 0 THEN COOP_PCT * -1 ELSE COOP_PCT END
				
				--/* @@@@@@@@@@ */
				--SELECT '@AR_ORDER_UNIT_LIST', * FROM @AR_ORDER_UNIT_LIST /** DEBUG **/ 
				--SELECT '#AR_ORDER_LIST' 'SRC', * FROM #AR_ORDER_LIST /** DEBUG **/

			END /* TV Unit Split */

			IF ( @ret_val = 0 )
			BEGIN
				UPDATE #ORDER_TYPE SET USER_FLAG = 1 WHERE ORDER_TYPE = @curr_ord_type
				SET @ret_val = @@ERROR
			END		
			
			IF ( @ret_val = 0 )	SET /* NoOp */ @ret_val = 0 ELSE BREAK	
		END
		ELSE BREAK
	
	END
	
	-- BJL 05/24/2013 - Validate co-op pcts sum to 100%
	-- PJH 07/27/2018 - Added @unit_split check - Then moved it below
	IF ( @ret_val = 0 ) --AND ( @unit_split = 0 )
	BEGIN
		--SELECT '#AR_ORDER_LIST' '#AR_ORDER_LIST', * FROM #AR_ORDER_LIST WHERE NULLIF(COOP_CODE,'') IS NOT NULL AND COOP_CODE NOT IN (select BILL_COOP_CODE from dbo.BILLING_COOP)
		-- PJH 07/01/2021 - Added @unit_split check
		IF @unit_split = 0 AND EXISTS(SELECT 1 FROM #AR_ORDER_LIST WHERE NULLIF(COOP_CODE,'') IS NOT NULL AND COOP_CODE NOT IN (select BILL_COOP_CODE from dbo.BILLING_COOP))
			SET @ret_val = -5

		ELSE IF EXISTS(SELECT 1 FROM #AR_ORDER_LIST WHERE NULLIF(COOP_CODE,'') IS NOT NULL)
			IF EXISTS(SELECT 1
							  FROM #AR_ORDER_LIST ol 
						INNER JOIN dbo.BILLING_COOP bc 
								ON ( ol.COOP_CODE = bc.BILL_COOP_CODE )
							 WHERE ( bc.INACTIVE_FLAG IS NULL OR bc.INACTIVE_FLAG = 0 )
 							   AND ( ol.AR_INV_SEQ NOT IN ( @coop_master_seq, 0 ))
							   AND ( BILL_COOP_CODE <> 'units' )
						  GROUP BY bc.BILL_COOP_CODE, ol.ORDER_NBR, ol.LINE_NBR
							HAVING ( SUM( bc.COOP_PCT ) <> 100 ))
				SET @ret_val = -5
	END	

	-- BJL 03/06/2013 - Validate offices
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE #AR_ORDER_LIST
		   SET COOP_CODE = NULL
		 WHERE 1 < ( SELECT COUNT( DISTINCT p.OFFICE_CODE )
				       FROM dbo.BILLING_COOP bc
			     INNER JOIN dbo.PRODUCT p
					     ON ( bc.CL_CODE = p.CL_CODE ) 
						AND ( bc.DIV_CODE = p.DIV_CODE ) 
						AND ( bc.PRD_CODE = p.PRD_CODE )
					  WHERE ( bc.BILL_COOP_CODE = #AR_ORDER_LIST.COOP_CODE )
						AND ( bc.CL_CODE = #AR_ORDER_LIST.CL_CODE )
						AND ( bc.DIV_CODE = #AR_ORDER_LIST.DIV_CODE )
						AND ( bc.PRD_CODE = #AR_ORDER_LIST.PRD_CODE ))
						 
		SET @ret_val = @@ERROR						
	END	
	
	-- {6.11.4}
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE #AR_ORDER_LIST
		   SET COOP_CODE = NULL
		 WHERE 0 < ( SELECT	COUNT(*)
					   FROM dbo.BILLING_COOP bc
				 INNER JOIN dbo.PRODUCT p
						 ON ( bc.CL_CODE = p.CL_CODE ) 
						AND ( bc.DIV_CODE = p.DIV_CODE ) 
						AND ( bc.PRD_CODE = p.PRD_CODE )
					  WHERE	( bc.BILL_COOP_CODE = #AR_ORDER_LIST.COOP_CODE )
						AND ( bc.CL_CODE = #AR_ORDER_LIST.CL_CODE )
						AND ( bc.DIV_CODE = #AR_ORDER_LIST.DIV_CODE )
						AND ( bc.PRD_CODE = #AR_ORDER_LIST.PRD_CODE )
					    AND ( p.OFFICE_CODE <> #AR_ORDER_LIST.OFFICE_CODE )) 
						 
		SET @ret_val = @@ERROR						
	END			
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE #AR_ORDER_LIST
		   SET AR_INV_SEQ = 0 
		 WHERE ( AR_INV_SEQ IS NULL )
		   AND ( COOP_PCT IS NULL )
		   
		SET @ret_val = @@ERROR		
	END

	-- PJH 12/04/2018 - Add check for cross-office coop
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE OL
		   SET REJECTED_BY_OFFICE = 1
		  FROM #AR_ORDER_LIST OL
		 WHERE (( 	SELECT COUNT( DISTINCT ol.OFFICE_CODE ) 
					  FROM #AR_ORDER_LIST ol 
					 WHERE ol.ORDER_NBR = OL.ORDER_NBR
					   AND ol.COOP_PCT IS NOT NULL ) > 1 )
		   AND COOP_PCT IS NOT NULL 
		
		SET @ret_val = @@ERROR		
	END
	
	-- {6.11.5}
--	IF ( @ret_val = 0 )
--	BEGIN
--		 UPDATE #AR_ORDER_LIST
--		    SET AR_INV_SEQ = @coop_master_seq
----				INV_BY = 4		 
--		  WHERE AR_INV_SEQ IS NULL 
--		    AND COOP_CODE IS NOT NULL
		   
--		SET @ret_val = @@ERROR		
--	END

	-- BJL 04/17/2013 - Commented out per 809|1|
	--IF ( @ret_val = 0 )
	--BEGIN
	--	 UPDATE #AR_ORDER_LIST
	--	    SET INV_BY = 1		 
	--	  WHERE ( INV_BY = 2 AND CLIENT_PO IS NULL )
	--	     OR ( INV_BY = 3 AND MARKET_CODE IS NULL )
	--	     OR ( INV_BY = 5 AND CMP_IDENTIFIER IS NULL )
		   
	--	SET @ret_val = @@ERROR		
	--END
	
	-- BJL 05/23/2013 - This statement flags one co-op client to apply rounding differences later
	IF ( @ret_val = 0 )
	BEGIN
		-- @@@@@@@@@@
		--SELECT 'Adjustment Row' 'Src', * FROM #AR_ORDER_LIST
		--		 WHERE NOT EXISTS ( SELECT * 
		--					  FROM #AR_ORDER_LIST ol 
		--					 WHERE ol.ORDER_NBR = #AR_ORDER_LIST.ORDER_NBR
		--					   AND ol.LINE_NBR = #AR_ORDER_LIST.LINE_NBR
		--					   AND ol.AR_ORDER_LIST_ID > #AR_ORDER_LIST.AR_ORDER_LIST_ID
		--					   AND ol.COOP_PCT IS NOT NULL )
		--   AND ( COOP_PCT IS NOT NULL )

		UPDATE #AR_ORDER_LIST
		   SET ADJUST_FLAG = 1
		 WHERE NOT EXISTS ( SELECT * 
							  FROM #AR_ORDER_LIST ol 
							 WHERE ol.ORDER_NBR = #AR_ORDER_LIST.ORDER_NBR
							   AND ol.LINE_NBR = #AR_ORDER_LIST.LINE_NBR
							   AND ol.AR_ORDER_LIST_ID > #AR_ORDER_LIST.AR_ORDER_LIST_ID
							   AND ol.COOP_PCT IS NOT NULL )
		   AND ( COOP_PCT IS NOT NULL )
		   AND ( REVERSAL = 0 )  /* PJH 04/23/19 Added */
							   
		SET @ret_val = @@ERROR 							   
	END	
		
END

UPDATE #AR_JOB_LIST SET INV_BY = COALESCE(@combo_inv_by_override, @prod_inv_by_override, INV_BY)

UPDATE #AR_ORDER_LIST SET INV_BY = COALESCE(@combo_inv_by_override, @media_inv_by_override, INV_BY)

-- MJC 11/05/2015 Process Combo billing first
IF ( @ret_val = 0 ) AND ( EXISTS (SELECT 1 FROM #AR_JOB_LIST WHERE INV_BY >= 21) OR EXISTS (SELECT 1 FROM #AR_ORDER_LIST WHERE INV_BY >= 21) )
BEGIN
	
	WHILE ( 1 = 1 )
	BEGIN

		SET @curr_seq_nbr = 0
		
		 SELECT TOP 1 
				@curr_inv_by = INV_BY,
				@curr_off_code = OFFICE_CODE, @curr_coop_code = COOP_CODE, @curr_cmp_id = CMP_IDENTIFIER, 
				@curr_cl_code = CL_CODE, @curr_div_code = DIV_CODE, @curr_prd_code = PRD_CODE
		   FROM (
		 SELECT INV_BY, OFFICE_CODE, COOP_CODE, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE
		   FROM #AR_JOB_LIST j 
		  WHERE ( j.AR_INV_NBR IS NULL )
		    AND ( j.AR_INV_SEQ = 0 OR j.AR_INV_SEQ = @coop_master_seq )
			AND ( j.INV_BY >= 21 )
		  UNION ALL
	     SELECT INV_BY, OFFICE_CODE, COOP_CODE, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE
		   FROM #AR_ORDER_LIST o
		  WHERE ( o.AR_INV_NBR IS NULL )
		    AND	( o.AR_INV_SEQ = 0 OR o.AR_INV_SEQ = @coop_master_seq )
			AND ( o.INV_BY >= 21 )
				) joborders
	     ORDER BY CL_CODE ASC, DIV_CODE ASC, PRD_CODE ASC, OFFICE_CODE ASC, COOP_CODE ASC, CMP_IDENTIFIER ASC, INV_BY ASC

		SET @row_ct = @@ROWCOUNT
		SET @ret_val = @@ERROR
			   
		IF ( @ret_val = 0 )
		BEGIN
			IF ( @row_ct = 1 ) 
			BEGIN
				SET @ar_inv_nbr = @ar_inv_nbr + 1
				IF ( @curr_inv_by = 21 )			-- by client
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( OFFICE_CODE = @curr_off_code )
					    
					 SET @job_row_ct = @@ROWCOUNT
					 SET @ret_val = @@ERROR

					 IF ( @ret_val = 0 )
					 BEGIN
						 UPDATE #AR_ORDER_LIST
							SET AR_INV_NBR = @ar_inv_nbr
						  WHERE ( AR_INV_NBR IS NULL )
							AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
							AND ( INV_BY = @curr_inv_by )
							AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
							AND ( CL_CODE = @curr_cl_code )
							AND ( OFFICE_CODE = @curr_off_code )

						SET @media_row_ct = @@ROWCOUNT
						SET @ret_val = @@ERROR
					 END
					 ELSE BREAK

					 IF ( @ret_val = 0 ) AND ( (@job_row_ct + @media_row_ct) > 0 ) 
						CONTINUE
					 ELSE
						BREAK	

				END
				
				-- MJC 06/15/2016 - added client/division combo billing
				IF ( @curr_inv_by = 25 )			-- by client division
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code )
						AND ( OFFICE_CODE = @curr_off_code )
						
					 SET @job_row_ct = @@ROWCOUNT
					 SET @ret_val = @@ERROR

					 IF ( @ret_val = 0 )
					 BEGIN
						 UPDATE #AR_ORDER_LIST
							SET AR_INV_NBR = @ar_inv_nbr
						  WHERE ( AR_INV_NBR IS NULL )
							AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
							AND ( INV_BY = @curr_inv_by )
							AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
							AND ( CL_CODE = @curr_cl_code )
							AND ( DIV_CODE = @curr_div_code ) 
							AND ( OFFICE_CODE = @curr_off_code )

						SET @media_row_ct = @@ROWCOUNT
						SET @ret_val = @@ERROR
					 END
					 ELSE BREAK
					 
					 IF ( @ret_val = 0 ) AND ( (@job_row_ct + @media_row_ct) > 0 ) 
						CONTINUE
					 ELSE
						BREAK	

				END
				
				IF ( @curr_inv_by = 22 )			-- by client division product
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code )
					    AND ( PRD_CODE = @curr_prd_code )
						AND ( OFFICE_CODE = @curr_off_code )
						
					 SET @job_row_ct = @@ROWCOUNT
					 SET @ret_val = @@ERROR

					 IF ( @ret_val = 0 )
					 BEGIN
						 UPDATE #AR_ORDER_LIST
							SET AR_INV_NBR = @ar_inv_nbr
						  WHERE ( AR_INV_NBR IS NULL )
							AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
							AND ( INV_BY = @curr_inv_by )
							AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
							AND ( CL_CODE = @curr_cl_code )
							AND ( DIV_CODE = @curr_div_code ) 
							AND ( PRD_CODE = @curr_prd_code )
							AND ( OFFICE_CODE = @curr_off_code )

						SET @media_row_ct = @@ROWCOUNT
						SET @ret_val = @@ERROR
					 END
					 ELSE BREAK
					 
					 IF ( @ret_val = 0 ) AND ( (@job_row_ct + @media_row_ct) > 0 ) 
						CONTINUE
					 ELSE
						BREAK	

				END
				
				IF ( @curr_inv_by = 23 )			-- by client campaign
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( CMP_IDENTIFIER = @curr_cmp_id OR ( CMP_IDENTIFIER IS NULL AND @curr_cmp_id IS NULL ))
						AND ( OFFICE_CODE = @curr_off_code )
						
					 SET @job_row_ct = @@ROWCOUNT
					 SET @ret_val = @@ERROR

					 IF ( @ret_val = 0 )
					 BEGIN
						 UPDATE #AR_ORDER_LIST
							SET AR_INV_NBR = @ar_inv_nbr
						  WHERE ( AR_INV_NBR IS NULL )
							AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
							AND ( INV_BY = @curr_inv_by )
							AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
							AND ( CL_CODE = @curr_cl_code )
							AND ( CMP_IDENTIFIER = @curr_cmp_id OR ( CMP_IDENTIFIER IS NULL AND @curr_cmp_id IS NULL ))
							AND ( OFFICE_CODE = @curr_off_code )

						SET @media_row_ct = @@ROWCOUNT
						SET @ret_val = @@ERROR
					 END
					 ELSE BREAK
					 
					 IF ( @ret_val = 0 ) AND ( (@job_row_ct + @media_row_ct) > 0 ) 
						CONTINUE
					 ELSE
						BREAK	

				END
				
				IF ( @curr_inv_by = 24 )			-- by client division product campaign
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
					    AND ( CL_CODE = @curr_cl_code )
						AND ( DIV_CODE = @curr_div_code )
					    AND ( PRD_CODE = @curr_prd_code )
					    AND ( CMP_IDENTIFIER = @curr_cmp_id OR ( CMP_IDENTIFIER IS NULL AND @curr_cmp_id IS NULL ))
						AND ( OFFICE_CODE = @curr_off_code )
						
					 SET @job_row_ct = @@ROWCOUNT
					 SET @ret_val = @@ERROR

					 IF ( @ret_val = 0 )
					 BEGIN
						 UPDATE #AR_ORDER_LIST
							SET AR_INV_NBR = @ar_inv_nbr
						  WHERE ( AR_INV_NBR IS NULL )
							AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
							AND ( INV_BY = @curr_inv_by )
							AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
							AND ( CL_CODE = @curr_cl_code )
							AND ( DIV_CODE = @curr_div_code )
							AND ( PRD_CODE = @curr_prd_code )
							AND ( CMP_IDENTIFIER = @curr_cmp_id OR ( CMP_IDENTIFIER IS NULL AND @curr_cmp_id IS NULL ))
							AND ( OFFICE_CODE = @curr_off_code )
						
						SET @media_row_ct = @@ROWCOUNT
						SET @ret_val = @@ERROR
					 END
					 ELSE BREAK
					 
					 IF ( @ret_val = 0 ) AND ( (@job_row_ct + @media_row_ct) > 0 ) 
						CONTINUE
					 ELSE
						BREAK	

				END
				
			END
			ELSE			-- if @row_ct <> 1
				BREAK
		END
		ELSE				-- if @ret_val <> 0
			BREAK
					
	END	-- WHILE 

END	

--	**** {4.0} INVOICE GROUPING (PRODUCTION) **************************************************************************************************************
-- BJL 02/28/2013 - Production and media are processed separately now, but there are specs to be implemented for combining the two later
-- BJL 04/19/2013 - Uncommented INV_BY in WHERE clauses, process master invoices only in loop, update co-op with AR_INV_NBR at end
-- PJH 01/15/2014 - Changed ORDER BY from  j.JOB_NUMBER ASC, j.JOB_COMPONENT_NBR ASC, j.COOP_CODE ASC, j.CMP_IDENTIFIER ASC, j.JOB_CL_PO_NBR ASC, 
--								j.SC_CODE ASC, j.CL_CODE ASC, j.DIV_CODE ASC, j.PRD_CODE ASC, j.OFFICE_CODE ASC, j.INV_BY ASC
IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	
	WHILE ( 1 = 1 )
	BEGIN
		-- {5.3} 
		SET @curr_seq_nbr = 0
		
		 SELECT TOP 1 
				@curr_inv_by = j.INV_BY, @curr_job_nbr = j.JOB_NUMBER, @curr_job_cmp_nbr = j.JOB_COMPONENT_NBR, 
				@curr_off_code = j.OFFICE_CODE, @curr_coop_code = j.COOP_CODE, @curr_cmp_id = j.CMP_IDENTIFIER, 
				@curr_po_nbr = j.JOB_CL_PO_NBR, @curr_sc_code = j.SC_CODE, @curr_cl_code = j.CL_CODE, 
				@curr_div_code = j.DIV_CODE, @curr_prd_code = j.PRD_CODE 
		   FROM #AR_JOB_LIST j 
		  WHERE ( j.AR_INV_NBR IS NULL )
		    AND ( j.AR_INV_SEQ = 0 OR j.AR_INV_SEQ = @coop_master_seq )
			AND ( j.INV_BY < 21 )
	   ORDER BY j.CL_CODE ASC, j.DIV_CODE ASC, j.PRD_CODE ASC, j.OFFICE_CODE ASC, j.JOB_NUMBER ASC, j.JOB_COMPONENT_NBR ASC, 
						 j.COOP_CODE ASC, j.CMP_IDENTIFIER ASC, j.JOB_CL_PO_NBR ASC, j.SC_CODE ASC, j.INV_BY ASC
	   
		SET @row_ct = @@ROWCOUNT
		SET @ret_val = @@ERROR
			   
		IF ( @ret_val = 0 )
		BEGIN
			IF ( @row_ct = 1 ) 
			BEGIN
				-- {5.6.3}
				IF ( @curr_inv_by = 1 )			-- by job 
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					  	AND ( JOB_NUMBER = @curr_job_nbr )
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END
				
				IF ( @curr_inv_by = 2 )			-- by component
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					  	AND ( JOB_NUMBER = @curr_job_nbr )
						AND ( JOB_COMPONENT_NBR = @curr_job_cmp_nbr )
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END

				-- {5.6.4}
				IF ( @curr_inv_by = 3 )			-- by product, sales class
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code )
					    AND ( PRD_CODE = @curr_prd_code )
					    AND ( SC_CODE = @curr_sc_code )
					    AND ( OFFICE_CODE = @curr_off_code )	-- PJH 06/03/2014 added
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK
				END
				
				-- {5.6.5}
				-- EC 01/07/2014
				IF ( @curr_inv_by = 4 )			-- by campaign (campaign / product)
				BEGIN
					--PJH 06/03/2014 - Use Job if Campaign Is Null
					--PJH 06/03/2014 - Comment DIV/PRD
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					    AND ( CL_CODE = @curr_cl_code )
					    --AND ( DIV_CODE = @curr_div_code ) -- EC 01/07/2014 Added to group by CDP  --PJH 06/03/2014 - Commented
					    --AND ( PRD_CODE = @curr_prd_code ) -- EC 01/07/2014 Added to group by CDP  --PJH 06/03/2014 - Commented
					    AND ( CMP_IDENTIFIER = @curr_cmp_id OR ( CMP_IDENTIFIER IS NULL AND JOB_NUMBER = @curr_job_nbr ))--OR ( CMP_IDENTIFIER IS NULL AND @curr_cmp_id IS NULL )) --PJH 06/03/2014 - Commented
						AND ( OFFICE_CODE = @curr_off_code )	-- PJH 08/01/2013 added

					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK
				END
				
				-- {5.6.6}
				IF ( @curr_inv_by = 5 )			-- by product, client PO, office
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code )
					    AND ( PRD_CODE = @curr_prd_code )
					    AND ( JOB_CL_PO_NBR = @curr_po_nbr OR ( JOB_CL_PO_NBR IS NULL AND @curr_po_nbr IS NULL ))
					    AND ( OFFICE_CODE = @curr_off_code )	-- PJH 06/03/2014 Uncommented
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK
				END
				
				-- {5.6.7}
				IF ( @curr_inv_by = 6 )			-- by client, office
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					    AND ( CL_CODE = @curr_cl_code )
						AND ( OFFICE_CODE = @curr_off_code )  -- PJH 08/01/2013 Uncommented
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK
				END
				
				-- {5.6.8}
				IF ( @curr_inv_by = 7 )			-- by division, office
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code )
						AND ( OFFICE_CODE = @curr_off_code )  -- PJH 08/01/2013 Uncommented
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
											
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK
				END					
				
				-- {5.6.9}
				IF ( @curr_inv_by = 8 )			-- by product, office
				BEGIN
					 UPDATE #AR_JOB_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					  	AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))		-- BJL 04/23/2013					    
					    AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code )
					    AND ( PRD_CODE = @curr_prd_code )
						AND ( OFFICE_CODE = @curr_off_code )	-- PJH 06/03/2014 Uncommented
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
											
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK
				END					
			END
			ELSE			-- if @row_ct <> 1
				BREAK
		END
		ELSE				-- if @ret_val <> 0
			BREAK
					
	END	-- WHILE 

	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 04/19/2013 - Update the co-op items with the parent AR_INV_NBR
			UPDATE JL1
			   SET AR_INV_NBR = JL2.AR_INV_NBR
			  FROM #AR_JOB_LIST JL1
		INNER JOIN #AR_JOB_LIST JL2
				ON ( JL1.JOB_NUMBER = JL2.JOB_NUMBER )
			   AND ( JL1.JOB_COMPONENT_NBR = JL2.JOB_COMPONENT_NBR )
			   AND ( JL1.COOP_CODE = JL2.COOP_CODE )
			 WHERE ( JL1.AR_INV_NBR IS NULL )
			   AND ( JL1.AR_INV_SEQ IS NULL )
			   AND ( JL2.AR_INV_NBR IS NOT NULL )
			   AND ( JL2.AR_INV_SEQ = @coop_master_seq )

		SET @ret_val = @@ERROR 
	END

	IF ( @ret_val = 0 ) DELETE FROM #AR_INV_SEQ 
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 04/04/2013 - This statement groups and seeds the AR_INV_SEQ
		INSERT INTO #AR_INV_SEQ ( AR_LIST_ID, AR_INV_SEQ )
		   --SELECT AR_JOB_LIST_ID, DENSE_RANK() OVER ( ORDER BY CDP_CMP ASC )		-- BJL 04/24/2013 - Multi-campaign to one job fix		
			 SELECT AR_JOB_LIST_ID, DENSE_RANK() OVER ( PARTITION BY AR_INV_NBR ORDER BY CDP_CMP ASC )		
			   FROM #AR_JOB_LIST
			  WHERE ( AR_INV_SEQ IS NULL )
				AND ( COOP_CODE IS NOT NULL )

		SET @ret_val = @@ERROR 
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 11/25/2013 - Skips the co-op master sequence (production)
		UPDATE #AR_INV_SEQ 
		   SET AR_INV_SEQ = ( AR_INV_SEQ + 1 ) 
		 WHERE ( AR_INV_SEQ >= @coop_master_seq )
				
		SET @ret_val = @@ERROR 
	END

	IF ( @ret_val = 0 )
	BEGIN
			UPDATE J
			   SET AR_INV_SEQ = S.AR_INV_SEQ
			  FROM #AR_JOB_LIST J
		INNER JOIN #AR_INV_SEQ S
				ON ( J.AR_JOB_LIST_ID = S.AR_LIST_ID )			   
			 WHERE ( J.AR_INV_SEQ IS NULL )
			   AND ( J.COOP_CODE IS NOT NULL )

		SET @ret_val = @@ERROR 
	END	
END	

-- PJH DEBUG CODE - Comment when finished debugging
--SELECT * FROM #AR_JOB_LIST

--	**** {4.0} INVOICE GROUPING (MEDIA) *******************************************************************************************************************
-- BJL 02/28/2013 - Production and media are processed separately now, but there are specs to be implemented for combining the two later
IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	
	WHILE ( 1 = 1 )
	BEGIN
		-- { }
		SET @curr_seq_nbr = 0
		
		-- { }
		 SELECT TOP 1 
				@curr_inv_by = o.INV_BY, @curr_cl_code = o.CL_CODE, @curr_div_code = o.DIV_CODE, @curr_prd_code = o.PRD_CODE, 
		        @curr_sc_code = o.SC_CODE, @curr_order_type = o.ORDER_TYPE, @curr_po_nbr = o.CLIENT_PO, 
		        @curr_market_code = o.MARKET_CODE, @curr_order_nbr = o.ORDER_NBR, @curr_cmp_id = o.CMP_IDENTIFIER,
		        @curr_coop_code = o.COOP_CODE, @curr_off_code = o.OFFICE_CODE
		   FROM #AR_ORDER_LIST o
		  WHERE ( o.AR_INV_NBR IS NULL )
		    AND	( o.AR_INV_SEQ = 0 OR o.AR_INV_SEQ = @coop_master_seq )
			AND ( o.INV_BY < 21 )
	   ORDER BY o.ORDER_NBR ASC, o.LINE_NBR ASC, o.ORDER_TYPE ASC, o.COOP_CODE ASC, o.CMP_IDENTIFIER ASC, o.CLIENT_PO ASC, 
				o.SC_CODE ASC, o.MARKET_CODE ASC, o.CL_CODE ASC, o.DIV_CODE ASC, o.PRD_CODE ASC, o.OFFICE_CODE ASC, o.INV_BY ASC
	   
		SET @row_ct = @@ROWCOUNT
		SET @ret_val = @@ERROR
		
		IF ( @ret_val = 0 )
		BEGIN
			IF ( @row_ct = 1 ) 
			BEGIN
				-- { }
				IF ( @curr_inv_by = 1 )			-- by product, sales class
				BEGIN
					 UPDATE #AR_ORDER_LIST
						SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					    AND ( ORDER_TYPE = @curr_order_type )
					    AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
						AND ( CL_CODE = @curr_cl_code )
						AND ( DIV_CODE = @curr_div_code )
						AND ( PRD_CODE = @curr_prd_code )
						AND ( SC_CODE = @curr_sc_code )
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END						
				
				-- { }
				IF ( @curr_inv_by = 2 )			-- by product, client PO
				BEGIN
					 UPDATE #AR_ORDER_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					    AND ( ORDER_TYPE = @curr_order_type )
					    AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
						AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code ) 
					    AND ( PRD_CODE = @curr_prd_code )
					    AND ( ( CLIENT_PO = @curr_po_nbr )
						   OR ( CLIENT_PO IS NULL AND @curr_po_nbr IS NULL ))
							
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END
				
				-- { }
				IF ( @curr_inv_by = 3 )			-- by product, market
				BEGIN
					 UPDATE #AR_ORDER_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					    AND ( ORDER_TYPE = @curr_order_type )
					    AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
						AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code ) 
					    AND ( PRD_CODE = @curr_prd_code )
					    AND ( ( MARKET_CODE = @curr_market_code ) 
					       OR ( MARKET_CODE IS NULL AND @curr_market_code IS NULL ))
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END
				
				-- { }
				IF ( @curr_inv_by = 4 )			-- by order
				BEGIN
					 UPDATE #AR_ORDER_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					    AND ( ORDER_TYPE = @curr_order_type )
					    AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
					    AND ( ORDER_NBR = @curr_order_nbr )
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END
				
				-- { }
				-- EC 01/07/2014
				IF ( @curr_inv_by = 5 )			-- by campaign (Campaign / Product)
				BEGIN
					 UPDATE #AR_ORDER_LIST
					    SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					    AND ( ORDER_TYPE = @curr_order_type )
					    AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
						AND ( CL_CODE = @curr_cl_code )
					    AND ( DIV_CODE = @curr_div_code ) -- EC 01/07/2014 Added to group by CDP
					    AND ( PRD_CODE = @curr_prd_code ) -- EC 01/07/2014 Added to group by CDP
					    AND ( ( CMP_IDENTIFIER = @curr_cmp_id )
						   OR ( CMP_IDENTIFIER IS NULL AND @curr_cmp_id IS NULL ))
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END		
						
				IF ( @curr_inv_by = 6 )			-- by media type
				BEGIN
					 UPDATE #AR_ORDER_LIST
						SET AR_INV_NBR = @ar_inv_nbr + 1
					  WHERE ( AR_INV_NBR IS NULL )
					    AND ( AR_INV_SEQ = 0 OR AR_INV_SEQ = @coop_master_seq )
					    AND ( INV_BY = @curr_inv_by )
					    AND ( ORDER_TYPE = @curr_order_type )
					    AND ( COOP_CODE = @curr_coop_code OR ( COOP_CODE IS NULL AND @curr_coop_code IS NULL ))
						AND ( CL_CODE = @curr_cl_code )
						AND ( OFFICE_CODE = @curr_off_code )
					    
					SET @row_ct = @@ROWCOUNT
					SET @ret_val = @@ERROR
					
					IF ( @ret_val = 0 ) AND ( @row_ct > 0 ) BEGIN
						SET @ar_inv_nbr = @ar_inv_nbr + 1
						CONTINUE
					END ELSE
						BREAK	
				END
			END
			ELSE			-- if @row_ct <> 1
				BREAK	
		END
		ELSE				-- if @ret_val <> 0
			BREAK

	END -- WHILE
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 05/22/2013 - Update the co-op items with the parent AR_INV_NBR
			UPDATE OL1
			   SET AR_INV_NBR = OL2.AR_INV_NBR
			  FROM #AR_ORDER_LIST OL1
		INNER JOIN #AR_ORDER_LIST OL2
				ON ( OL1.ORDER_NBR = OL2.ORDER_NBR )
			   AND ( OL1.LINE_NBR = OL2.LINE_NBR )
			   AND ( OL1.COOP_CODE = OL2.COOP_CODE )
			 WHERE ( OL1.AR_INV_NBR IS NULL )
			   AND ( OL1.AR_INV_SEQ IS NULL )
			   AND ( OL2.AR_INV_NBR IS NOT NULL )
			   AND ( OL2.AR_INV_SEQ = @coop_master_seq )

		SET @ret_val = @@ERROR 
	END
	
	IF ( @ret_val = 0 ) DELETE FROM #AR_INV_SEQ 
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 05/22/2013 - This statement groups and seeds the AR_INV_SEQ
		INSERT INTO #AR_INV_SEQ ( AR_LIST_ID, AR_INV_SEQ )
			 SELECT AR_ORDER_LIST_ID, DENSE_RANK() OVER ( PARTITION BY AR_INV_NBR ORDER BY REVERSAL ASC, CL_CODE ASC, DIV_CODE ASC, PRD_CODE ASC ) /* PJH 04/23/19 - Added REVERSAL ASC */
			   FROM #AR_ORDER_LIST
			  WHERE ( AR_INV_SEQ IS NULL )
				AND ( COOP_CODE IS NOT NULL )

		SET @ret_val = @@ERROR 
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 11/25/2013 - Skips the co-op master sequence (media)
		UPDATE #AR_INV_SEQ 
		   SET AR_INV_SEQ = ( AR_INV_SEQ + 1 ) 
		 WHERE ( AR_INV_SEQ >= @coop_master_seq )
				
		SET @ret_val = @@ERROR 
	END	
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE O
		   SET AR_INV_SEQ = S.AR_INV_SEQ
		  FROM #AR_ORDER_LIST O
	INNER JOIN #AR_INV_SEQ S
			ON ( O.AR_ORDER_LIST_ID = S.AR_LIST_ID )
		 WHERE ( O.AR_INV_SEQ IS NULL )
		   AND ( O.COOP_CODE IS NOT NULL )
	     
		SET @ret_val = @@ERROR 
	END
	
END 	

--	**** {5.0} PRODUCTION DETAIL (AMOUNTS) ***************************************************************************************************
IF ( @ret_val = 0 AND @production = 1 )
BEGIN

	IF ( @ret_val = 0 )
	BEGIN
		-- EMP_TIME_DTL 
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, HRS_QTY, 
					EMP_TIME_AMT, STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, TOTAL_BILL, TAX_CODE, SUMMARY_FLAG )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'E', 
					CASE A.AR_INV_SEQ WHEN 0 THEN SUM( COALESCE( D.EMP_HOURS, 0.000 )) ELSE NULL END,
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.TOTAL_BILL, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 ), 
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_STATE_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_COUNTY_RESALE, 0.00 ))) / 100, 2 ),				
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) 
						* ( COALESCE( D.TOTAL_BILL, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 ) 
						  + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_STATE_RESALE, 0.00 ))) / 100, 2 ),
					D.TAX_CODE, 0
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.EMP_TIME_DTL D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
			  WHERE ( A.COOP_PCT IS NOT NULL )
			    AND ( D.BILL_HOLD_FLG = 0 OR D.BILL_HOLD_FLG IS NULL )
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.TOTAL_BILL, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 
				  -- OR COALESCE( D.EMP_HOURS, 0.00 ) <> 0.00 ) PJH 02/26/2015 - added EMP_HOURS
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, A.OFFICE_CODE, A.SC_CODE, D.TAX_CODE, A.AR_INV_SEQ

		SET @ret_val = @@ERROR	   
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- INCOME_ONLY 
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, HRS_QTY, 
					INC_ONLY_AMT, STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, TOTAL_BILL, TAX_CODE, SUMMARY_FLAG )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'I', 
			 		CASE A.AR_INV_SEQ WHEN 0 THEN SUM( COALESCE( D.IO_QTY, 0.000 )) ELSE NULL END,
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.IO_AMOUNT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 ), 
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_STATE_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_COUNTY_RESALE, 0.00 ))) / 100, 2 ),				
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) 
						* ( COALESCE( D.IO_AMOUNT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_STATE_RESALE, 0.00 )
						  + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					D.TAX_CODE, 0
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.INCOME_ONLY D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
			  WHERE ( A.COOP_PCT IS NOT NULL )
			    AND ( D.BILL_HOLD_FLAG = 0 OR D.BILL_HOLD_FLAG IS NULL )
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.IO_AMOUNT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 ) 
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, A.OFFICE_CODE, A.SC_CODE, D.TAX_CODE, A.AR_INV_SEQ
		   
		SET @ret_val = @@ERROR	   
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- AP_PRODUCTION - Fold function only
		-- EC  03/31/2013 - Added Markup Amount to Total Bill
		-- BJL 11/13/2013 - Broke out vendor tax
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, HRS_QTY, COST_AMT, COMMISSION_AMT, 
					STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, NON_RESALE_AMT, TOTAL_BILL, TAX_CODE, SUMMARY_FLAG )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'V', 
					CASE A.AR_INV_SEQ WHEN 0 THEN SUM( COALESCE( D.AP_PROD_QUANTITY, 0.000 )) ELSE NULL END,
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ))) / 100, 2 ),	
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_STATE_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_COUNTY_RESALE, 0.00 ))) / 100, 2 ),				
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) 
						* ( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) 
						  + COALESCE( D.EXT_STATE_RESALE, 0.00 ) + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ), 
					D.TAX_CODE, 0
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.AP_PRODUCTION D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
					-- BJL 04/12/2013
			  WHERE ( A.FOLD_COOP_PCT IS NOT NULL )
			    AND ( D.AP_PROD_BILL_HOLD = 0 OR D.AP_PROD_BILL_HOLD IS NULL )
			    AND ( A.NP_COOP_SPLIT = 1 )
			    AND ( D.FNC_CODE = @fold_fnc_code )
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ) <> 0.00
				   -- OR COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 )
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, A.OFFICE_CODE, A.SC_CODE, D.TAX_CODE, A.AR_INV_SEQ

		SET @ret_val = @@ERROR	  
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- AP_PRODUCTION - Non-fold functions
		-- EC  03/31/2013 - Added Markup Amount to Total Bill
		-- BJL 11/13/2013 - Broke out vendor tax
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, HRS_QTY, COST_AMT, COMMISSION_AMT, 
					STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, NON_RESALE_AMT, TOTAL_BILL, TAX_CODE, SUMMARY_FLAG )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'V', 
					CASE A.AR_INV_SEQ WHEN 0 THEN SUM( COALESCE( D.AP_PROD_QUANTITY, 0.000 )) ELSE NULL END,
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ))) / 100, 2 ),	
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_STATE_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_COUNTY_RESALE, 0.00 ))) / 100, 2 ),				
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) 
						* ( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) 
						  + COALESCE( D.EXT_STATE_RESALE, 0.00 ) + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ), 
					D.TAX_CODE, 0
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.AP_PRODUCTION D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
			  WHERE ( A.COOP_PCT IS NOT NULL )
				AND ( D.AP_PROD_BILL_HOLD = 0 OR D.AP_PROD_BILL_HOLD IS NULL )
					-- BJL 04/12/2013
			    AND (( A.NP_COOP_SPLIT = 0 ) OR ( A.NP_COOP_SPLIT IS NULL ) OR (( A.NP_COOP_SPLIT = 1 ) AND ( D.FNC_CODE <> @fold_fnc_code )))
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ) <> 0.00
				   -- OR COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 )
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, A.OFFICE_CODE, A.SC_CODE, D.TAX_CODE, A.AR_INV_SEQ

		SET @ret_val = @@ERROR	  
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		-- ADVANCE_BILLING - Fold function only
		-- BJL 11/20/2013 - Broke out vendor tax
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, AB_COST_AMT, AB_INC_AMT, AB_COMMISSION_AMT, 
					AB_SALE_AMT, STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, AB_NONRESALE_AMT, TOTAL_BILL, TAX_CODE, SUMMARY_FLAG, RECONCILE_ROW )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, F.FNC_TYPE, 
					CASE -- Cost
						WHEN ( D.AB_FLAG = 5 ) THEN NULL 
						WHEN ( F.FNC_TYPE = 'V' ) THEN 
							ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ))) / 100, 2 )
						ELSE NULL
					END,	
					CASE -- Income 
						WHEN ( D.AB_FLAG = 5 ) THEN NULL
						WHEN ( F.FNC_TYPE = 'V' ) THEN NULL
						ELSE 
							ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 )
					END,	
					CASE -- Commission
						WHEN ( D.AB_FLAG = 5 ) THEN NULL				
						WHEN ( F.FNC_TYPE = 'V' ) THEN 
							ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 )
						ELSE NULL
					END,	
					CASE -- AB Sales - for AB_FLAG of 5 only - 
						 -- BJL 04/18/2013 - Added nonresale tax
						WHEN ( D.AB_FLAG = 5 ) THEN 
							ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) 
							   * ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))) / 100, 2 )
						ELSE NULL
					END,	
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_STATE_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_COUNTY_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					-- AB_NONRESALE_AMT
					CASE 
						WHEN ( D.AB_FLAG = 5 ) THEN NULL 
						WHEN ( F.FNC_TYPE = 'V' ) THEN 
							ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * ( COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))) / 100, 2 )
						ELSE NULL
					END,						
					ROUND( SUM(( COALESCE( A.FOLD_COOP_PCT, 0 )) * 
						 ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) 
						 + COALESCE( D.EXT_STATE_RESALE, 0.00 ) + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					D.TAX_CODE, 0, 
					CASE A.JOB_AB_FLAG WHEN 0 THEN 0 WHEN 2 THEN 0 ELSE 1 END
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.ADVANCE_BILLING D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
		 INNER JOIN	dbo.FUNCTIONS F
				 ON ( D.FNC_CODE = F.FNC_CODE )
			  WHERE ( A.FOLD_COOP_PCT IS NOT NULL )
			    AND ( A.NP_COOP_SPLIT = 1 )
			    AND ( D.FNC_CODE = @fold_fnc_code )
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 )
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, F.FNC_TYPE, D.TAX_CODE, D.AB_FLAG, A.OFFICE_CODE, A.SC_CODE, A.AB_REC_FLAG, A.JOB_AB_FLAG 

		SET @ret_val = @@ERROR	   
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- ADVANCE_BILLING - Non-fold functions
		-- BJL 11/20/2013 - Broke out vendor tax
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, AB_COST_AMT, AB_INC_AMT, AB_COMMISSION_AMT, 
					AB_SALE_AMT, STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, AB_NONRESALE_AMT, TOTAL_BILL, TAX_CODE, SUMMARY_FLAG, RECONCILE_ROW )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, F.FNC_TYPE, 
					CASE -- Cost
						WHEN ( D.AB_FLAG = 5 ) THEN NULL 
						WHEN ( F.FNC_TYPE = 'V' ) THEN 
							ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ))) / 100, 2 )
						ELSE NULL
					END,	
					CASE -- Income 
						WHEN ( D.AB_FLAG = 5 ) THEN NULL
						WHEN ( F.FNC_TYPE = 'V' ) THEN NULL
						ELSE 
							ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 )
					END,	
					CASE -- Commission
						WHEN ( D.AB_FLAG = 5 ) THEN NULL				
						WHEN ( F.FNC_TYPE = 'V' ) THEN 
							ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_MARKUP_AMT, 0.00 ))) / 100, 2 )
						ELSE NULL
					END,	
					--CASE -- AB Sales - for AB_FLAG of 5 only - 
					--	 -- BJL 04/18/2013 - Added nonresale tax
					--	WHEN ( D.AB_FLAG = 5 ) THEN 
					--		ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) 
					--		   * ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))) / 100, 2 )
					--	ELSE NULL
					--END,	
					CASE -- AB Sales - for AB_FLAG of 5 only - 
						 -- BJL 04/18/2013 - Added nonresale tax
						WHEN ( D.AB_FLAG = 5 ) THEN 
							ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) 
							   * ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 )) / 100 ), 2 ) + 
							ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) 
							   * ( COALESCE( D.EXT_MARKUP_AMT, 0.00 )) / 100 ), 2 ) + 
							ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) 
							   * ( COALESCE( D.EXT_NONRESALE_TAX, 0.00 )) / 100 ), 2 ) 
						ELSE NULL
					END,						
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_STATE_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_COUNTY_RESALE, 0.00 ))) / 100, 2 ),
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					-- AB_NONRESALE_AMT
					CASE 
						WHEN ( D.AB_FLAG = 5 ) THEN NULL 
						WHEN ( F.FNC_TYPE = 'V' ) THEN 
							ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * ( COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))) / 100, 2 )
						ELSE NULL
					END,						
					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 )) * 
						 ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) 
						 + COALESCE( D.EXT_STATE_RESALE, 0.00 ) + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 ))) / 100, 2 ),
					D.TAX_CODE, 0, 
					CASE A.JOB_AB_FLAG WHEN 0 THEN 0 WHEN 2 THEN 0 ELSE 1 END
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.ADVANCE_BILLING D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
		 INNER JOIN	dbo.FUNCTIONS F
				 ON ( D.FNC_CODE = F.FNC_CODE )
			  WHERE ( A.COOP_PCT IS NOT NULL )
					-- BJL 04/12/2013
			    AND (( A.NP_COOP_SPLIT = 0 ) OR ( A.NP_COOP_SPLIT IS NULL ) OR (( A.NP_COOP_SPLIT = 1 ) AND ( D.FNC_CODE <> @fold_fnc_code )))
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 )
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, F.FNC_TYPE, D.TAX_CODE, D.AB_FLAG, A.OFFICE_CODE, A.SC_CODE, A.AB_REC_FLAG, A.JOB_AB_FLAG 

		SET @ret_val = @@ERROR	   
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- INCOME RECOGNITION
		-- BJL 06/24/2013 - Income recognition items do not get split for co-op or have tax applied
		-- MJC 09/29/2015 - insert the new FNC_CODE column now in INCOME_REC
		INSERT INTO #AR_FUNCTION_DTL ( 
					AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, AB_SALE_AMT, AB_INC_AMT, TOTAL_BILL, SUMMARY_FLAG, RECONCILE_ROW )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'R', SUM( COALESCE( D.REC_AMT, 0.00 )), SUM( COALESCE( -D.REC_AMT, 0.00 )), 0.00, 
					0, 0
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.INCOME_REC D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
				AND ( A.AR_INV_SEQ IN ( 0, @coop_master_seq ))	
		   GROUP BY A.AR_JOB_LIST_ID, D.AB_FLAG, D.FNC_CODE

		SET @ret_val = @@ERROR	   
	END

	-- BJL 01/02/2013 - CO-OP SUMMARY ROWS ARE USED FOR ROUNDING PURPOSES
	IF ( @ret_val = 0 )
	BEGIN
		-- EMP_TIME_DTL (co-op summary)
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, TAX_CODE, SUMMARY_FLAG,
					HRS_QTY, EMP_TIME_AMT, STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, TOTAL_BILL )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'E', D.TAX_CODE, 1,
					SUM( COALESCE( D.EMP_HOURS, 0.000 )),
					SUM(( COALESCE( D.TOTAL_BILL, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ))),
					SUM( COALESCE( D.EXT_STATE_RESALE, 0.00 )), 
					SUM( COALESCE( D.EXT_COUNTY_RESALE, 0.00 )), 
					SUM( COALESCE( D.EXT_CITY_RESALE, 0.00 )), 
					SUM(( COALESCE( D.TOTAL_BILL, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 ) 
						+ COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_STATE_RESALE, 0.00 )))
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.EMP_TIME_DTL D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
			  WHERE ( A.COOP_PCT IS NULL )
			    AND ( D.BILL_HOLD_FLG = 0 OR D.BILL_HOLD_FLG IS NULL )
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.TOTAL_BILL, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 
				  -- OR COALESCE( D.EMP_HOURS, 0.00 ) <> 0.00 ) /* PJH 02/26/2015 - added EMP_HOURS */
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, D.TAX_CODE
		   
		SET @ret_val = @@ERROR	   
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		-- INCOME_ONLY (co-op summary)
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, TAX_CODE, SUMMARY_FLAG, 
					HRS_QTY, INC_ONLY_AMT, STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, TOTAL_BILL )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'I', D.TAX_CODE, 1,
					SUM( COALESCE( D.IO_QTY, 0.000 )),
					SUM(( COALESCE( D.IO_AMOUNT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ))),
					SUM( COALESCE( D.EXT_STATE_RESALE, 0.00 )),
					SUM( COALESCE( D.EXT_COUNTY_RESALE, 0.00 )),
					SUM( COALESCE( D.EXT_CITY_RESALE, 0.00 )),
					SUM(( COALESCE( D.IO_AMOUNT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_STATE_RESALE, 0.00 ) 
						+ COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 )))
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.INCOME_ONLY D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
			  WHERE ( A.COOP_PCT IS NULL )
			    AND ( D.BILL_HOLD_FLAG = 0 OR D.BILL_HOLD_FLAG IS NULL )
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.IO_AMOUNT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 )
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, D.TAX_CODE
		   
		SET @ret_val = @@ERROR	   
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- AP_PRODUCTION (co-op summary)
		-- BJL 03/29/2013 - Changed ACC_AP to WIP
		-- BJL 11/13/2013 - Broke out vendor tax
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, TAX_CODE, SUMMARY_FLAG, HRS_QTY, COST_AMT, COMMISSION_AMT, 
					STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, NON_RESALE_AMT, TOTAL_BILL )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, 'V', D.TAX_CODE, 1,
					SUM( COALESCE( D.AP_PROD_QUANTITY, 0.000 )),
					SUM( COALESCE( D.AP_PROD_EXT_AMT, 0.00 )),	
					SUM( COALESCE( D.EXT_MARKUP_AMT, 0.00 )),
					SUM( COALESCE( D.EXT_STATE_RESALE, 0.00 )),
					SUM( COALESCE( D.EXT_COUNTY_RESALE, 0.00 )),
					SUM( COALESCE( D.EXT_CITY_RESALE, 0.00 )),
					SUM( COALESCE( D.EXT_NONRESALE_TAX, 0.00 )),
					SUM(( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 )
						+ COALESCE( D.EXT_STATE_RESALE, 0.00 ) + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 )))
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.AP_PRODUCTION D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
			  WHERE ( A.COOP_PCT IS NULL )
			    AND ( D.AP_PROD_BILL_HOLD = 0 OR AP_PROD_BILL_HOLD IS NULL )
				-- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.AP_PROD_EXT_AMT, 0.00 ) <> 0.00
				   -- OR COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 )
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, D.TAX_CODE
		   
		SET @ret_val = @@ERROR	   
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- ADVANCE_BILLING (co-op summary)
		-- BJL 11/13/2013 - Broke out vendor tax		
		INSERT INTO #AR_FUNCTION_DTL ( AR_JOB_LIST_ID, FNC_CODE, FNC_TYPE, TAX_CODE, SUMMARY_FLAG, 
					AB_FLAG, RECONCILE_ROW, AB_COST_AMT, AB_INC_AMT, AB_COMMISSION_AMT, AB_SALE_AMT,
					STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, AB_NONRESALE_AMT, TOTAL_BILL )
			 SELECT A.AR_JOB_LIST_ID, D.FNC_CODE, F.FNC_TYPE, D.TAX_CODE, 1, D.AB_FLAG,
					CASE A.JOB_AB_FLAG WHEN 0 THEN 0 WHEN 2 THEN 0 ELSE 1 END, 
					CASE -- AB_COST_AMT
						WHEN ( D.AB_FLAG = 5 ) THEN NULL 
						WHEN ( F.FNC_TYPE = 'V' ) THEN SUM( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ))
						ELSE NULL
					END,	
					CASE -- AB_INC_AMT
						WHEN ( D.AB_FLAG = 5 ) THEN NULL
						WHEN ( F.FNC_TYPE = 'V' ) THEN NULL
						ELSE SUM( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ))
					END,	
					CASE -- AB_COMMISSION_AMT
						WHEN ( D.AB_FLAG = 5 ) THEN NULL				
						WHEN ( F.FNC_TYPE IN ( 'V' )) THEN SUM( COALESCE( D.EXT_MARKUP_AMT, 0.00 ))
						ELSE NULL
					END,	
					CASE 
						-- AB_SALE_AMT - for AB_FLAG of 5 only
						WHEN ( D.AB_FLAG = 5 ) THEN 
							SUM( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))
						ELSE NULL
					END,	
					SUM( COALESCE( D.EXT_STATE_RESALE, 0.00 )),
					SUM( COALESCE( D.EXT_COUNTY_RESALE, 0.00 )),
					SUM( COALESCE( D.EXT_CITY_RESALE, 0.00 )),
					CASE -- AB_NONRESALE_AMT
						WHEN ( D.AB_FLAG = 5 ) THEN NULL 
						WHEN ( F.FNC_TYPE = 'V' ) THEN SUM( COALESCE( D.EXT_NONRESALE_TAX, 0.00 ))
						ELSE NULL
					END,						
					-- TOTAL_BILL
					SUM(( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) + COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) + COALESCE( D.EXT_MARKUP_AMT, 0.00 ) 
						+ COALESCE( D.EXT_STATE_RESALE, 0.00 ) + COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( D.EXT_CITY_RESALE, 0.00 )))
			   FROM #AR_JOB_LIST A 
		 INNER JOIN dbo.ADVANCE_BILLING D
				 ON ( A.JOB_NUMBER = D.JOB_NUMBER )
				AND ( A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR )
				AND ( D.BILLING_USER = @billing_user_in )
		 INNER JOIN dbo.FUNCTIONS F
				 ON ( D.FNC_CODE = F.FNC_CODE ) 
			  WHERE ( A.COOP_PCT IS NULL )
			  -- PJH 03/06/2015 - Don't Exclude 0 (zero) records
				-- AND ( COALESCE( D.ADV_BILL_NET_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_NONRESALE_TAX, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_MARKUP_AMT, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_STATE_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_COUNTY_RESALE, 0.00 ) <> 0.00 
				   -- OR COALESCE( D.EXT_CITY_RESALE, 0.00 ) <> 0.00 )
		   GROUP BY A.AR_JOB_LIST_ID, D.FNC_CODE, F.FNC_TYPE, D.TAX_CODE, D.AB_FLAG, A.JOB_AB_FLAG
	   
		SET @ret_val = @@ERROR	   
	END
	
END

--	**** MEDIA DETAIL (AMOUNTS) ********************************************************************************************************
IF ( @ret_val = 0 AND @media = 1 )
BEGIN
	
	-- BJL 04/03/2013 - Modified to use dynamic SQL - cuts down on duplication of code
	UPDATE #ORDER_TYPE SET USER_FLAG = 0
		
	WHILE ( @ret_val = 0 )
	BEGIN
		SET @curr_ord_type = NULL
		SET @header_tbl = NULL
		SET @detail_tbl = NULL 
		SET @detail_tbl2 = NULL 
		SET @curr_date_1_col = NULL

		SELECT TOP 1 
			   @curr_ord_type = ORDER_TYPE, @header_tbl = HEADER_TBL, @detail_tbl = DETAIL_TBL, 
			   @curr_date_1_col = DATE_1_COL, @curr_media_mth_col = MEDIA_MONTH_COL, 
			   @curr_media_yr_col = MEDIA_YEAR_COL, @curr_hrs_qty_col = HRS_QTY_COL
		  FROM #ORDER_TYPE
		 WHERE USER_FLAG = 0
		   AND ( HEADER_TBL IS NOT NULL )
		   AND ( DETAIL_TBL IS NOT NULL )
		   AND ( DATE_1_COL IS NOT NULL )
	  ORDER BY ORDER_TYPE_ID ASC


/***************************************************************************************/

		SET @detail_tbl2 = @detail_tbl
		
		IF @curr_ord_type = 'T' BEGIN

			--DECLARE @tv_detail_unit_splits 
			CREATE TABLE #tv_detail_unit_splits  (
					ORDER_NBR					int NULL,
					LINE_NBR					int NULL,
					REV_NBR						smallint NULL,
					SEQ_NBR						smallint NULL,
					CL_CODE						varchar(6) NOT NULL,
					DIV_CODE					varchar(6) NOT NULL,
					PRD_CODE					varchar(6) NOT NULL,
					TOTAL_SPOTS					int NULL,
					EXT_NET_AMT					decimal(18,2) NULL,											
					LINE_TOTAL					decimal(18,2) NULL,											
					REBATE_AMT					decimal(18,2) NULL,											--  Media Rebate
					COMM_AMT					decimal(18,2) NULL,											--  Commission for the vendor amount
					NETCHARGE					decimal(18,2) NULL,											--  Media Net Charge
					NON_RESALE_AMT				decimal(18,2) NULL,											
					DISCOUNT_AMT				decimal(18,2) NULL,											
					ADDL_CHARGE					decimal(18,2) NULL,											
					CITY_AMT					decimal(18,2) NULL,											
					COUNTY_AMT					decimal(18,2) NULL,											
					STATE_AMT					decimal(18,2) NULL,
					BILLING_USER				varchar(100) NULL,
					AR_INV_NBR					int NULL,
					TAX_CODE					varchar(10) NULL,
					NON_BILL_FLAG				int NULL,
					REVERSAL					smallint NULL,
					COOP_PCT_CALC				decimal(20,10) NULL,
					[START_DATE]				smalldatetime NULL,
					[END_DATE]					smalldatetime NULL,
					[CLOSE_DATE]				smalldatetime NULL,
					MEDIA_MONTH					tinyint NULL,
					MEDIA_YEAR					smallint NULL,
					SUMMARY_ROW					bit NULL
				)	
				CREATE CLUSTERED INDEX ix_temp_tv_detail_unit_splits ON #tv_detail_unit_splits (ORDER_NBR,LINE_NBR,REV_NBR,SEQ_NBR)

			INSERT INTO #tv_detail_unit_splits
			SELECT D.ORDER_NBR, D.LINE_NBR, D.REV_NBR, D.SEQ_NBR, H.CL_CODE, H.DIV_CODE, CASE WHEN U.ORDER_NBR IS NULL THEN H.PRD_CODE ELSE U.PRD_CODE END,
					CASE WHEN U.ORDER_NBR IS NULL THEN D.TOTAL_SPOTS ELSE U.UNITS END, 
					D.EXT_NET_AMT, D.LINE_TOTAL, D.REBATE_AMT, D.COMM_AMT, D.NETCHARGE, 
					D.NON_RESALE_AMT, D.DISCOUNT_AMT, D.ADDL_CHARGE, D.CITY_AMT, D.COUNTY_AMT, D.STATE_AMT,
					D.BILLING_USER, NULL /*D.AR_INV_NBR*/, D.TAX_CODE, D.NON_BILL_FLAG, CASE WHEN D.ACTIVE_REV = 1 THEN 0 ELSE 1 END, 
					NULL, NULL, NULL, NULL, NULL, NULL, CASE WHEN U.ORDER_NBR IS NULL THEN 1 ELSE 0 END
			FROM	TV_DETAIL D 
					JOIN TV_HDR H ON D.ORDER_NBR = H.ORDER_NBR
					LEFT JOIN TV_DETAIL_UNITS U ON D.ORDER_NBR = U.ORDER_NBR AND D.LINE_NBR = U.LINE_NBR AND D.REV_NBR = U.REV_NBR AND D.SEQ_NBR = U.SEQ_NBR
			WHERE	D.BILLING_USER = @billing_user_in AND D.AR_INV_NBR IS NULL

			INSERT INTO #tv_detail_unit_splits
			SELECT D.ORDER_NBR, D.LINE_NBR, MAX(D.REV_NBR), 0 /*D.SEQ_NBR*/, H.CL_CODE, H.DIV_CODE, H.PRD_CODE,
					SUM(D.TOTAL_SPOTS), 
					SUM(D.EXT_NET_AMT), SUM(D.LINE_TOTAL), SUM(D.REBATE_AMT), SUM(D.COMM_AMT), SUM(D.NETCHARGE), 
					SUM(D.NON_RESALE_AMT), SUM(D.DISCOUNT_AMT), SUM(D.ADDL_CHARGE), SUM(D.CITY_AMT), SUM(D.COUNTY_AMT), SUM(D.STATE_AMT),
					D.BILLING_USER, NULL, MAX(D.TAX_CODE), MAX(D.NON_BILL_FLAG), 0, 
					NULL, NULL, NULL, NULL, NULL, NULL, 1 
			FROM	TV_DETAIL D 
					JOIN TV_HDR H ON D.ORDER_NBR = H.ORDER_NBR
					--LEFT JOIN #tv_detail_unit_splits U ON D.ORDER_NBR = U.ORDER_NBR AND D.LINE_NBR = U.LINE_NBR AND D.REV_NBR = U.REV_NBR AND D.SEQ_NBR = U.SEQ_NBR
					--	AND ( H.CL_CODE = U.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) AND ( H.DIV_CODE = U.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) AND (H.PRD_CODE = U.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS)
			WHERE	D.BILLING_USER = @billing_user_in AND D.AR_INV_NBR IS NULL
			GROUP BY D.ORDER_NBR, D.LINE_NBR, H.CL_CODE, H.DIV_CODE, H.PRD_CODE, D.BILLING_USER

			UPDATE A
			SET A.COOP_PCT_CALC = B.TOTAL_SPOTS
			FROM #tv_detail_unit_splits A 
			JOIN (SELECT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, SUM(TOTAL_SPOTS) TOTAL_SPOTS FROM #tv_detail_unit_splits WHERE SUMMARY_ROW = 0
					GROUP BY ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REV_NBR = B.REV_NBR AND A.SEQ_NBR = B.SEQ_NBR

			--UPDATE A
			--SET A.TOTAL_SPOTS = B.TOTAL_SPOTS, 
			--	A.EXT_NET_AMT = B.EXT_NET_AMT, A.LINE_TOTAL = B.LINE_TOTAL, A.REBATE_AMT = B.REBATE_AMT, A.COMM_AMT = B.COMM_AMT, A.NETCHARGE = B.NETCHARGE, A.NON_RESALE_AMT = B.NON_RESALE_AMT, 
			--	A.DISCOUNT_AMT = B.DISCOUNT_AMT, A.ADDL_CHARGE = B.ADDL_CHARGE, A.CITY_AMT = B.CITY_AMT, A.COUNTY_AMT = B.COUNTY_AMT, A.STATE_AMT = B.STATE_AMT--, SUMMARY_FLAG 
			--FROM #tv_detail_unit_splits A
			--JOIN (SELECT A.ORDER_NBR, A.LINE_NBR, SUM(A.TOTAL_SPOTS) TOTAL_SPOTS, 
			--	SUM(A.EXT_NET_AMT) EXT_NET_AMT, SUM(A.LINE_TOTAL) LINE_TOTAL, SUM(A.REBATE_AMT) REBATE_AMT, SUM(A.COMM_AMT) COMM_AMT, SUM(A.NETCHARGE) NETCHARGE, SUM(A.NON_RESALE_AMT) NON_RESALE_AMT, 
			--	SUM(A.DISCOUNT_AMT) DISCOUNT_AMT, SUM(A.ADDL_CHARGE) ADDL_CHARGE, SUM(A.CITY_AMT) CITY_AMT, SUM(A.COUNTY_AMT) COUNTY_AMT, SUM(A.STATE_AMT) STATE_AMT--, SUMMARY_FLAG 
			--	FROM #tv_detail_unit_splits A 
			--	WHERE SUMMARY_ROW = 0
			--	GROUP BY ORDER_NBR, LINE_NBR
			--	) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND SUMMARY_ROW = 1

			UPDATE A
			SET A.START_DATE = B.START_DATE, A.END_DATE = B.END_DATE, A.CLOSE_DATE = B.CLOSE_DATE, A.MEDIA_MONTH = B.MONTH_NBR, A.MEDIA_YEAR = B.YEAR_NBR
			FROM #tv_detail_unit_splits A 
			JOIN TV_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND  B.ACTIVE_REV = 1

			UPDATE #tv_detail_unit_splits
			SET COOP_PCT_CALC = TOTAL_SPOTS / COOP_PCT_CALC

			--UPDATE #tv_detail_unit_splits
			--SET EXT_NET_AMT = EXT_NET_AMT * COOP_PCT_CALC, LINE_TOTAL = LINE_TOTAL * COOP_PCT_CALC, REBATE_AMT = REBATE_AMT * COOP_PCT_CALC, COMM_AMT = COMM_AMT * COOP_PCT_CALC,
			--	NETCHARGE = NETCHARGE * COOP_PCT_CALC, NON_RESALE_AMT = NON_RESALE_AMT * COOP_PCT_CALC, DISCOUNT_AMT = DISCOUNT_AMT * COOP_PCT_CALC, ADDL_CHARGE = ADDL_CHARGE * COOP_PCT_CALC,
			--	CITY_AMT = CITY_AMT * COOP_PCT_CALC, COUNTY_AMT = COUNTY_AMT * COOP_PCT_CALC, STATE_AMT = STATE_AMT * COOP_PCT_CALC

			--SELECT '#tv_detail_unit_splits' 'DESC', * FROM #tv_detail_unit_splits

		END

	  
		IF @curr_ord_type IN ( 'M', 'N', 'I', 'O', 'R', 'T' ) /* PJH 07/27/2018 - @@@@@@@@@@ - Split by rate * spots */
		BEGIN
			/* Unit split rows excluded */
			SELECT @sql_select = ''
			SELECT @sql_select = @sql_select + CHAR(13) + '			INSERT INTO #AR_ORDER_DTL ( '
			SELECT @sql_select = @sql_select + CHAR(13) + '					AR_ORDER_LIST_ID, REV_NBR, SEQ_NBR, RUN_DATE, MEDIA_MONTH, MEDIA_YEAR, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					CLOSE_DATE, END_DATE, TAX_CODE, NON_BILL_FLAG, SALE_POST_PERIOD, HRS_QTY, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					COST_AMT, LINE_TOTAL, REBATE_AMT, COMMISSION_AMT, NET_CHARGE_AMT, NON_RESALE_AMT, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					DISCOUNT_AMT, ADDITIONAL_AMT, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, SUMMARY_FLAG ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '			 SELECT A.AR_ORDER_LIST_ID, D.REV_NBR, D.SEQ_NBR, ' + @curr_date_1_col + ', ' 
			SELECT @sql_select = @sql_select + CHAR(13)	+ '				    ' + @curr_media_mth_col + ', ' + @curr_media_yr_col + ', '
			SELECT @sql_select = @sql_select + CHAR(13) + '					B.CLOSE_DATE, B.END_DATE, D.TAX_CODE, D.NON_BILL_FLAG, '
																			-- SALE_POST_PERIOD
			SELECT @sql_select = @sql_select + CHAR(13) + '					CASE '
			SELECT @sql_select = @sql_select + CHAR(13) + '						WHEN ( CHARINDEX( ''' + @curr_ord_type + ''', ''MNIO'' ) > 0 AND ( A.INC_FLAG = 2 OR A.INC_FLAG = 3 )) '
			SELECT @sql_select = @sql_select + CHAR(13) + '						THEN [dbo].[advfn_get_deferred_media_period] ( ' + @curr_date_1_col + ', ''' + @post_period + ''' ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '						WHEN ( CHARINDEX( ''' + @curr_ord_type + ''', ''RT'' ) > 0 AND ( A.INC_FLAG = 2 OR A.INC_FLAG = 3 )) '
			SELECT @sql_select = @sql_select + CHAR(13) + '						THEN [dbo].[advfn_get_deferred_media_period] ( '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		CAST( ' + @curr_media_yr_col + ' AS varchar(4) ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		+ ''-'' + '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		CAST( ' + @curr_media_mth_col + ' AS varchar(2) ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		+ ''-01'' + '''', ''' + @post_period + ''' '
			SELECT @sql_select = @sql_select + CHAR(13) + '																	  ) '	
			SELECT @sql_select = @sql_select + CHAR(13) + '						ELSE NULL '
			SELECT @sql_select = @sql_select + CHAR(13) + '					END, '
																			-- HRS_QTY
			SELECT @sql_select = @sql_select + CHAR(13) + '					SUM( COALESCE( ' + @curr_hrs_qty_col + ', 0 )), '
																			-- COST_AMT											
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.EXT_NET_AMT, 0.00 ))), 2 ), '
			-- BJL 04/17/2013 - 809|1|84									-- LINE_TOTAL
--			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.LINE_TOTAL, 0.00 )), 0.00 ) + COALESCE( SUM( COALESCE( D.ADDL_CHARGE, 0.00 )), 0.00 ), '	
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.LINE_TOTAL, 0.00 ))), 2 ), '	
																			-- REBATE_AMT																	
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.REBATE_AMT, 0.00 ))), 2 ), '
																			-- COMMISSION_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.COMM_AMT, 0.00 ))), 2 ), '
																			-- NET_CHARGE_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.NETCHARGE, 0.00 ))), 2 ), '
																			-- NON_RESALE_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.NON_RESALE_AMT, 0.00 ))), 2 ), '
																			-- DISCOUNT_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.DISCOUNT_AMT, 0.00 ))), 2 ), '	
																			-- ADDITIONAL_AMT																	
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.ADDL_CHARGE, 0.00 ))), 2 ), '
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.CITY_AMT, 0.00 ))), 2 ), '
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.COUNTY_AMT, 0.00 ))), 2 ), '
			SELECT @sql_select = @sql_select + CHAR(13) + '					ROUND( SUM(( COALESCE( A.COOP_PCT, 0 ) / 100 ) * ( COALESCE( D.STATE_AMT, 0.00 ))), 2 ), '																		
			SELECT @sql_select = @sql_select + CHAR(13) + '					0 '
			SELECT @sql_select = @sql_select + CHAR(13) + '			   FROM #AR_ORDER_LIST A INNER JOIN dbo.' + @header_tbl + ' H  ON ( A.ORDER_NBR = H.ORDER_NBR ) '

			--IF @curr_ord_type = 'T' BEGIN
			--	SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN #tv_detail_unit_splits D ON ( H.ORDER_NBR = D.ORDER_NBR ) AND ( A.LINE_NBR = D.LINE_NBR ) '
			--	SELECT @sql_select = @sql_select + CHAR(13) + '		 AND ( A.CL_CODE = D.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS) AND ( A.DIV_CODE = D.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS) AND (A.PRD_CODE = D.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS) '
			--	SELECT @sql_select = @sql_select + CHAR(13) + '		 AND ( A.REVERSAL = D.REVERSAL ) '
			--END 
			--ELSE
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.' + @detail_tbl + ' D ON ( H.ORDER_NBR = D.ORDER_NBR ) AND ( A.LINE_NBR = D.LINE_NBR ) '

			-- BJL 10/30/13
			SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.' + @detail_tbl + ' B ON ( D.ORDER_NBR = B.ORDER_NBR ) AND ( D.LINE_NBR = B.LINE_NBR ) AND ( B.ACTIVE_REV = 1 ) '			
			SELECT @sql_select = @sql_select + CHAR(13) + '			  WHERE ( D.BILLING_USER = ''' + @billing_user_in + ''' ) '																		
			SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( D.AR_INV_NBR IS NULL ) '	
			SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( A.COOP_PCT IS NOT NULL ) '

			SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( A.COOP_CODE IS NULL OR A.COOP_CODE <> ''units!'' ) '

			SELECT @sql_select = @sql_select + CHAR(13) + '		   GROUP BY A.AR_ORDER_LIST_ID, D.REV_NBR, D.SEQ_NBR, ' + @curr_date_1_col + ', '
			SELECT @sql_select = @sql_select + CHAR(13) + '					B.CLOSE_DATE, B.END_DATE, D.TAX_CODE, D.NON_BILL_FLAG, A.INC_FLAG, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					A.BILL_COMM_NET, A.INC_FLAG, A.OFFICE_CODE, A.SC_CODE '

			IF ( @curr_media_mth_col <> 'NULL' ) OR ( @curr_media_yr_col <> 'NULL' ) 
				SELECT @sql_select = @sql_select + CHAR(13) + '				    , ' + @curr_media_mth_col + ', ' + @curr_media_yr_col

			IF ( @ret_val = 0 )
			BEGIN
				EXECUTE ( @sql_select )
				SELECT @ret_val = @@ERROR, @row_ct = @@ROWCOUNT
			END
			ELSE
				PRINT @sql_select -- DEBUG

			/* Unit split rows only */
			IF @curr_ord_type = 'T' BEGIN

				INSERT INTO #AR_ORDER_DTL ( 
						AR_ORDER_LIST_ID, REV_NBR, SEQ_NBR, RUN_DATE, MEDIA_MONTH, MEDIA_YEAR, 
						CLOSE_DATE, END_DATE, TAX_CODE, NON_BILL_FLAG, SALE_POST_PERIOD, HRS_QTY, 
						COST_AMT, LINE_TOTAL, REBATE_AMT, COMMISSION_AMT, NET_CHARGE_AMT, NON_RESALE_AMT, 
						DISCOUNT_AMT, ADDITIONAL_AMT, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, SUMMARY_FLAG ) 
				 SELECT A.AR_ORDER_LIST_ID, D.REV_NBR, D.SEQ_NBR, D.[START_DATE], 
						--MONTH(D.START_DATE), YEAR(D.START_DATE), 
						D.MEDIA_MONTH, D.MEDIA_YEAR,  --PJH 09/26/2019
						D.CLOSE_DATE, D.END_DATE, D.TAX_CODE, D.NON_BILL_FLAG, 
						CASE 
							WHEN ( A.INC_FLAG = 2 OR A.INC_FLAG = 3 )
							THEN [dbo].[advfn_get_deferred_media_period] ( 
								 			CAST( D.MEDIA_YEAR AS varchar(4) )					--PJH 09/26/2019
								 			+ '-' + 
								 			CAST( D.MEDIA_MONTH AS varchar(2) )					--PJH 09/26/2019
								 			+ '-01' + '', @post_period   ) 
							ELSE NULL 
						END, 
						--SUM( COALESCE( A.HRS_QTY, 0 )), 
						CASE WHEN MAX(A.AR_INV_SEQ) = 99 THEN SUM( COALESCE( A.HRS_QTY, 0 )) ELSE SUM( COALESCE( D.TOTAL_SPOTS, 0 )) END, 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.EXT_NET_AMT, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.LINE_TOTAL, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.REBATE_AMT, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.COMM_AMT, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.NETCHARGE, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.NON_RESALE_AMT, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.DISCOUNT_AMT, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.ADDL_CHARGE, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.CITY_AMT, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.COUNTY_AMT, 0.00 ))), 2 ), 
						ROUND( SUM(( COALESCE( D.COOP_PCT_CALC, 0 ) ) * ( COALESCE( D.STATE_AMT, 0.00 ))), 2 ), 
						D.SUMMARY_ROW
				FROM #AR_ORDER_LIST A INNER JOIN dbo.TV_HDR H  ON ( A.ORDER_NBR = H.ORDER_NBR ) 
				INNER JOIN #tv_detail_unit_splits D ON ( A.ORDER_NBR = D.ORDER_NBR ) AND ( A.LINE_NBR = D.LINE_NBR ) 
						AND ( A.CL_CODE = D.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) AND ( A.DIV_CODE = D.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) AND (A.PRD_CODE = D.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS)
				--INNER JOIN dbo.TV_DETAIL B ON ( D.ORDER_NBR = B.ORDER_NBR ) AND ( D.LINE_NBR = B.LINE_NBR ) AND ( B.ACTIVE_REV = 1 ) 
				  WHERE --( D.BILLING_USER = @billing_user_in ) AND ( D.AR_INV_NBR IS NULL ) --Limited Above
						( D.COOP_PCT_CALC IS NOT NULL ) 
					AND ( A.COOP_CODE = 'units!' )
					AND (( D.SUMMARY_ROW = 1 AND A.AR_INV_SEQ = 99 ) OR ( D.SUMMARY_ROW = 0 AND A.AR_INV_SEQ <> 99 ))
			   GROUP BY A.AR_ORDER_LIST_ID, D.REV_NBR, D.SEQ_NBR, D.[START_DATE], 
						D.CLOSE_DATE, D.END_DATE, D.TAX_CODE, D.NON_BILL_FLAG, A.INC_FLAG, 
						A.BILL_COMM_NET, A.INC_FLAG, A.OFFICE_CODE, A.SC_CODE,								D.SUMMARY_ROW,
						--MONTH(D.START_DATE), YEAR(D.START_DATE)
						D.MEDIA_MONTH, D.MEDIA_YEAR			--PJH 09/26/2019

				/* Set 99 (summary) record to sum of detail since we are using detail split to calc % */
				UPDATE A
				SET  A.HRS_QTY = B.HRS_QTY, 
					A.COST_AMT = B.COST_AMT, A.LINE_TOTAL = B.LINE_TOTAL, A.REBATE_AMT = B.REBATE_AMT, A.COMMISSION_AMT = B.COMMISSION_AMT, A.NET_CHARGE_AMT = B.NET_CHARGE_AMT, A.NON_RESALE_AMT = B.NON_RESALE_AMT, 
					A.DISCOUNT_AMT = B.DISCOUNT_AMT, A.ADDITIONAL_AMT = B.ADDITIONAL_AMT, A.CITY_TAX_AMT = B.CITY_TAX_AMT, A.CNTY_TAX_AMT = B.CNTY_TAX_AMT, A.STATE_TAX_AMT = B.STATE_TAX_AMT
				FROM #AR_ORDER_DTL A JOIN #AR_ORDER_LIST C ON A.AR_ORDER_LIST_ID = C.AR_ORDER_LIST_ID
				JOIN (SELECT B.ORDER_NBR, B.LINE_NBR, SUM(A.HRS_QTY) HRS_QTY, 
					SUM(COST_AMT) COST_AMT, SUM(LINE_TOTAL) LINE_TOTAL, SUM(REBATE_AMT) REBATE_AMT, SUM(COMMISSION_AMT) COMMISSION_AMT, SUM(NET_CHARGE_AMT) NET_CHARGE_AMT, SUM(NON_RESALE_AMT) NON_RESALE_AMT, 
					SUM(DISCOUNT_AMT) DISCOUNT_AMT, SUM(ADDITIONAL_AMT) ADDITIONAL_AMT, SUM(CITY_TAX_AMT) CITY_TAX_AMT, SUM(CNTY_TAX_AMT) CNTY_TAX_AMT, SUM(STATE_TAX_AMT) STATE_TAX_AMT
					FROM #AR_ORDER_DTL A 
						JOIN #AR_ORDER_LIST B ON A.AR_ORDER_LIST_ID = B.AR_ORDER_LIST_ID
					WHERE SUMMARY_FLAG = 0 AND COOP_CODE = 'units!'
					GROUP BY B.ORDER_NBR, B.LINE_NBR
					) B ON C.ORDER_NBR = B.ORDER_NBR AND C.LINE_NBR = B.LINE_NBR AND A.SUMMARY_FLAG = 1

				--SELECT '#AR_ORDER_DTL' '#AR_ORDER_DTL', B.ORDER_NBR, B.LINE_NBR, A.* FROM #AR_ORDER_DTL A JOIN #AR_ORDER_LIST B ON A.AR_ORDER_LIST_ID = B.AR_ORDER_LIST_ID

			END

				
			-- Summary rows (for rounding)
			SELECT @sql_select = ''
			SELECT @sql_select = @sql_select + CHAR(13) + '			INSERT INTO #AR_ORDER_DTL ( '
			SELECT @sql_select = @sql_select + CHAR(13) + '					AR_ORDER_LIST_ID, REV_NBR, SEQ_NBR, RUN_DATE, MEDIA_MONTH, MEDIA_YEAR, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					CLOSE_DATE, END_DATE, TAX_CODE, NON_BILL_FLAG, SALE_POST_PERIOD, HRS_QTY, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					COST_AMT, LINE_TOTAL, REBATE_AMT, COMMISSION_AMT, NET_CHARGE_AMT, NON_RESALE_AMT, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					DISCOUNT_AMT, ADDITIONAL_AMT, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, SUMMARY_FLAG ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '			 SELECT A.AR_ORDER_LIST_ID, D.REV_NBR, D.SEQ_NBR, ' + @curr_date_1_col + ', ' 
			SELECT @sql_select = @sql_select + CHAR(13)	+ '				    ' + @curr_media_mth_col + ', ' + @curr_media_yr_col + ', '
			SELECT @sql_select = @sql_select + CHAR(13) + '					B.CLOSE_DATE, B.END_DATE, D.TAX_CODE, D.NON_BILL_FLAG, '
																			-- SALE_POST_PERIOD
			SELECT @sql_select = @sql_select + CHAR(13) + '					CASE '
			SELECT @sql_select = @sql_select + CHAR(13) + '						WHEN ( CHARINDEX( ''' + @curr_ord_type + ''', ''MNIO'' ) > 0 AND ( A.INC_FLAG = 2 OR A.INC_FLAG = 3 )) '
			SELECT @sql_select = @sql_select + CHAR(13) + '						THEN [dbo].[advfn_get_deferred_media_period] ( ' + @curr_date_1_col + ', ''' + @post_period + ''' ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '						WHEN ( CHARINDEX( ''' + @curr_ord_type + ''', ''RT'' ) > 0 AND ( A.INC_FLAG = 2 OR A.INC_FLAG = 3 )) '
			SELECT @sql_select = @sql_select + CHAR(13) + '						THEN [dbo].[advfn_get_deferred_media_period] ( '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		CAST( ' + @curr_media_yr_col + ' AS varchar(4) ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		+ ''-'' + '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		CAST( ' + @curr_media_mth_col + ' AS varchar(2) ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '								 		+ ''-01'' + '''', ''' + @post_period + ''' '
			SELECT @sql_select = @sql_select + CHAR(13) + '																	  ) '	
			SELECT @sql_select = @sql_select + CHAR(13) + '						ELSE NULL '
			SELECT @sql_select = @sql_select + CHAR(13) + '					END, '
																			-- HRS_QTY
			SELECT @sql_select = @sql_select + CHAR(13) + '					SUM( COALESCE( ' + @curr_hrs_qty_col + ', 0 )), '
																			-- COST_AMT											
			SELECT @sql_select = @sql_select + CHAR(13) + '					SUM( COALESCE( D.EXT_NET_AMT, 0.00 )), '
			-- BJL 04/17/2013 - 809|1|84									-- LINE_TOTAL
--			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.LINE_TOTAL, 0.00 )), 0.00 ) + COALESCE( SUM( COALESCE( D.ADDL_CHARGE, 0.00 )), 0.00 ), '	
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.LINE_TOTAL, 0.00 )), 0.00 ), '	
																			-- REBATE_AMT																	
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.REBATE_AMT, 0.00 )), 0.00 ), '
																			-- COMMISSION_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.COMM_AMT, 0.00 )), 0.00 ), '
																			-- NET_CHARGE_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.NETCHARGE, 0.00 )), 0.00 ), '
																			-- NON_RESALE_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.NON_RESALE_AMT, 0.00 )), 0.00 ), '
																			-- DISCOUNT_AMT
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.DISCOUNT_AMT, 0.00 )), 0.00 ), '	
																			-- ADDITIONAL_AMT																	
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.ADDL_CHARGE, 0.00 )), 0.00 ), '
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.CITY_AMT, 0.00 )), 0.00 ), '
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.COUNTY_AMT, 0.00 )), 0.00 ), '
			SELECT @sql_select = @sql_select + CHAR(13) + '					COALESCE( SUM( COALESCE( D.STATE_AMT, 0.00 )), 0.00 ), '																		
			SELECT @sql_select = @sql_select + CHAR(13) + '					1 '
			SELECT @sql_select = @sql_select + CHAR(13) + '			   FROM #AR_ORDER_LIST A INNER JOIN dbo.' + @header_tbl + ' H  ON ( A.ORDER_NBR = H.ORDER_NBR ) '

			--IF @curr_ord_type = 'T' BEGIN
			--	SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN #tv_detail_unit_splits D ON ( H.ORDER_NBR = D.ORDER_NBR ) AND ( A.LINE_NBR = D.LINE_NBR ) '
			--	SELECT @sql_select = @sql_select + CHAR(13) + '		 AND ( A.CL_CODE = D.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) AND ( A.DIV_CODE = D.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) AND (A.PRD_CODE = D.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS) '
			--	SELECT @sql_select = @sql_select + CHAR(13) + '		 AND ( A.REVERSAL = D.REVERSAL ) '
			--END 
			--ELSE
				SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.' + @detail_tbl + ' D ON ( H.ORDER_NBR = D.ORDER_NBR ) AND ( A.LINE_NBR = D.LINE_NBR ) '

			-- BJL 10/30/13
			SELECT @sql_select = @sql_select + CHAR(13) + '		 INNER JOIN dbo.' + @detail_tbl + ' B ON ( D.ORDER_NBR = B.ORDER_NBR ) AND ( D.LINE_NBR = B.LINE_NBR ) AND ( B.ACTIVE_REV = 1 ) '			
			SELECT @sql_select = @sql_select + CHAR(13) + '			  WHERE ( D.BILLING_USER = ''' + @billing_user_in + ''' ) '																		
			SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( D.AR_INV_NBR IS NULL ) '
			SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( A.COOP_PCT IS NULL ) '	
			
			SELECT @sql_select = @sql_select + CHAR(13) + '				AND ( A.COOP_CODE IS NULL OR A.COOP_CODE <> ''units!'' ) '			
																				
			SELECT @sql_select = @sql_select + CHAR(13) + '		   GROUP BY A.AR_ORDER_LIST_ID, D.REV_NBR, D.SEQ_NBR, ' + @curr_date_1_col + ', '
			SELECT @sql_select = @sql_select + CHAR(13) + '					B.CLOSE_DATE, B.END_DATE, D.TAX_CODE, D.NON_BILL_FLAG, A.INC_FLAG, '
			SELECT @sql_select = @sql_select + CHAR(13) + '					A.BILL_COMM_NET, A.INC_FLAG, A.OFFICE_CODE, A.SC_CODE '
			IF ( @curr_media_mth_col <> 'NULL' ) OR ( @curr_media_yr_col <> 'NULL' ) 
				SELECT @sql_select = @sql_select + CHAR(13) + '				    , ' + @curr_media_mth_col + ', ' + @curr_media_yr_col

			IF ( @ret_val = 0 )
			BEGIN
				EXECUTE ( @sql_select )
				SELECT @ret_val = @@ERROR, @row_ct = @@ROWCOUNT
			END
			ELSE
				PRINT @sql_select -- DEBUG

			-- End of loop processing
			IF ( @ret_val = 0 )
			BEGIN
				UPDATE #ORDER_TYPE SET USER_FLAG = 1 WHERE ORDER_TYPE = @curr_ord_type
				SET @ret_val = @@ERROR
			END		
			--ELSE
			--	PRINT @sql_select -- DEBUG
			
			IF ( @ret_val = 0 )	SET /* NoOp */ @ret_val = 0 ELSE BREAK	
		END
		ELSE BREAK

	END
	
	IF ( @ret_val = 0 ) 
		-- BJL 03/27/2013 - Added invalid deferred posting period check
		SELECT @ret_val = COALESCE(( SELECT TOP 1 -10 FROM #AR_ORDER_DTL WHERE SALE_POST_PERIOD = '******' ), 0 )

	IF ( @ret_val = 0 ) 
	BEGIN
		-- BJL 04/17/2013 - 809|1|84
		UPDATE d 
		   SET ADDITIONAL_AMT = 0.00 
		  FROM #AR_ORDER_DTL d INNER JOIN #AR_ORDER_LIST o
			ON ( d.AR_ORDER_LIST_ID = o.AR_ORDER_LIST_ID )
		 WHERE ( o.BILL_COMM_NET = 1 )

		SET @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 ) 
	BEGIN
		-- BJL 04/17/2013 - 809|1|84
		UPDATE d 
		   SET LINE_TOTAL = ( COALESCE( d.LINE_TOTAL, 0.00 ) + COALESCE( d.ADDITIONAL_AMT, 0.00 ))
		  FROM #AR_ORDER_DTL d INNER JOIN #AR_ORDER_LIST o
			ON ( d.AR_ORDER_LIST_ID = o.AR_ORDER_LIST_ID )

		SET @ret_val = @@ERROR
	END	

END

--	**** INSERT PRODUCTION DETAILS INTO W_AR_FUNCTION ***********************************************************************************************
IF ( @ret_val = 0 AND @production = 1 )
BEGIN
	INSERT INTO dbo.W_AR_FUNCTION ( 
				BILLING_USER,					--<-- GROUP BY
				COOP_CODE,						--<-- GROUP BY
				COOP_PCT,						--<-- GROUP BY
				MANUAL_FLAG,					--<-- constant
				INV_BY,							--<-- GROUP BY
				JOB_NUMBER,						--<-- GROUP BY
				JOB_COMPONENT_NBR,				--<-- GROUP BY
				JOB_AB_FLAG,					--<-- GROUP BY
				CL_CODE,						--<-- GROUP BY
				DIV_CODE,						--<-- GROUP BY
				PRD_CODE,						--<-- GROUP BY
				OFFICE_CODE,					--<-- GROUP BY
				SC_CODE,						--<-- GROUP BY
				CMP_IDENTIFIER,					--<-- GROUP BY
				CLIENT_PO,						--<-- GROUP BY
				FNC_CODE,						--<-- GROUP BY
				FNC_TYPE,						--<-- GROUP BY
				INV_TAX_FLAG,					--<-- constant
				AB_REC_FLAG,					--<-- GROUP BY 
				TAX_CODE,						--<-- GROUP BY			
				HRS_QTY,						--<-- SUM
				EMP_TIME_AMT,					--<-- SUM
				INC_ONLY_AMT,					--<-- SUM
				COMMISSION_AMT,					--<-- SUM
				COST_AMT,						--<-- SUM
				AB_COST_AMT,					--<-- SUM
				AB_INC_AMT,						--<-- SUM
				AB_COMMISSION_AMT,				--<-- SUM
				AB_SALE_AMT,					--<-- SUM
				AB_NONRESALE_AMT,				--<-- SUM						-- BJL 11/20/2013				
				CITY_TAX_AMT,					--<-- SUM
				CNTY_TAX_AMT,					--<-- SUM
				STATE_TAX_AMT,					--<-- SUM
				NON_RESALE_AMT,					--<-- SUM						-- BJL 11/13/2013
				TOTAL_BILL,						--<-- SUM
				SUMMARY_FLAG,					--<-- GROUP BY
				MODIFIED_FLAG,					--<-- constant
				AR_INV_NBR,						--<-- GROUP BY
				AR_INV_SEQ,						--<-- GROUP BY
				REJECTED_BY_OFFICE )			--<-- GROUP BY
		 SELECT @billing_user_in, j.COOP_CODE, 
				CASE WHEN ( j.NP_COOP_SPLIT = 1 AND f.FNC_CODE = @fold_fnc_code ) THEN j.FOLD_COOP_PCT ELSE j.COOP_PCT END, 
				0, j.INV_BY, j.JOB_NUMBER, j.JOB_COMPONENT_NBR, j.JOB_AB_FLAG, j.CL_CODE, j.DIV_CODE, j.PRD_CODE, 
				j.OFFICE_CODE, j.SC_CODE, j.CMP_IDENTIFIER, j.JOB_CL_PO_NBR, f.FNC_CODE, f.FNC_TYPE, 
				-- BJL 04/25/2013 - Changed default to allow for recalculation
				--CASE WHEN MAX( f.TAX_CODE ) IS NULL THEN @inv_tax_flag ELSE 0 END, 
				0, j.AB_REC_FLAG, 
				f.TAX_CODE,	--MAX( f.TAX_CODE ),								-- BJL 11/12/2013
				COALESCE( SUM( COALESCE( f.HRS_QTY, 0.000 )), 0.000 ), 
				COALESCE( SUM( COALESCE( f.EMP_TIME_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.INC_ONLY_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.COMMISSION_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.COST_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.AB_COST_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.AB_INC_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.AB_COMMISSION_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.AB_SALE_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.AB_NONRESALE_AMT, 0.00 )), 0.00 ),	-- BJL 11/20/2013
				COALESCE( SUM( COALESCE( f.CITY_TAX_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.CNTY_TAX_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.STATE_TAX_AMT, 0.00 )), 0.00 ), 
				COALESCE( SUM( COALESCE( f.NON_RESALE_AMT, 0.00 )), 0.00 ),		-- BJL 11/13/2013
				COALESCE( SUM( COALESCE( f.TOTAL_BILL, 0.00 )), 0.00 ), 
				f.SUMMARY_FLAG, 
				CASE f.SUMMARY_FLAG WHEN 1 THEN NULL ELSE 0 END, 
				j.AR_INV_NBR, j.AR_INV_SEQ, j.REJECTED_BY_OFFICE
		   FROM #AR_JOB_LIST j 
	 INNER JOIN #AR_FUNCTION_DTL f
			 ON ( j.AR_JOB_LIST_ID = f.AR_JOB_LIST_ID )
	   GROUP BY j.COOP_CODE, 
				j.COOP_PCT, 
				j.INV_BY, 
				j.JOB_NUMBER, 
				j.JOB_COMPONENT_NBR, 
				j.JOB_AB_FLAG, 
				j.CL_CODE, 
				j.DIV_CODE, 
				j.PRD_CODE, 
				j.OFFICE_CODE, 
				j.SC_CODE, 
				j.CMP_IDENTIFIER, 
				j.JOB_CL_PO_NBR, 
				f.FNC_CODE, 
				f.FNC_TYPE, 
				j.AB_REC_FLAG, 
				f.SUMMARY_FLAG, 
				j.REJECTED_BY_OFFICE, 
				j.AR_INV_NBR, 
				j.AR_INV_SEQ, 
				j.FOLD_COOP_PCT, 
				j.NP_COOP_SPLIT,
				f.TAX_CODE														-- BJL 11/12/2013
--				SUMMARY_ROW_ID													-- BJL 11/21/2013
				
	SET @ret_val = @@ERROR	     
	
	-- BJL 11/21/2013
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE detail_to_update
		   SET SUMMARY_ROW_ID = summary.AR_FUNCTION_ID
		  FROM dbo.W_AR_FUNCTION detail_to_update 
	INNER JOIN dbo.W_AR_FUNCTION summary
			ON ( detail_to_update.SUMMARY_FLAG = 0 )
		   AND ( summary.SUMMARY_FLAG = 1 )
		   AND ( detail_to_update.JOB_NUMBER = summary.JOB_NUMBER )
		   AND ( detail_to_update.JOB_COMPONENT_NBR = summary.JOB_COMPONENT_NBR )
		   AND ( detail_to_update.FNC_TYPE = summary.FNC_TYPE )
		   AND (( detail_to_update.FNC_CODE = summary.FNC_CODE ) OR ( detail_to_update.FNC_TYPE = 'R' AND summary.FNC_TYPE = 'R' ))
		   AND (( detail_to_update.RECONCILE_ROW = summary.RECONCILE_ROW ) OR ( detail_to_update.RECONCILE_ROW IS NULL AND summary.RECONCILE_ROW IS NULL ))
		   AND (( detail_to_update.TAX_CODE = summary.TAX_CODE ) OR ( detail_to_update.TAX_CODE IS NULL AND summary.TAX_CODE IS NULL ))
		 WHERE ( detail_to_update.BILLING_USER = @billing_user_in )
		
		SET @ret_val = @@ERROR	   
	END
	
	IF ( @ret_val = 0 ) AND ( @inv_tax_flag = 1 )
		-- BJL 04/23/2013 - Execute new stored procedure
		EXECUTE [dbo].[advsp_billing_inv_tax] @billing_user_in = @billing_user_in, @ret_val = @ret_val OUTPUT
		
END

--	**** INSERT MEDIA DETAILS INTO W_AR_FUNCTION ****************************************************************************************************
IF ( @ret_val = 0 AND @media = 1 )
BEGIN

----@@@@@@@@@@@@
--SELECT '#AR_ORDER_LIST' '#AR_ORDER_LIST', * FROM #AR_ORDER_LIST o 
--SELECT '#AR_ORDER_DTL' '#AR_ORDER_DTL', * FROM  #AR_ORDER_DTL d
----@@@@@@@@@@@@


	INSERT INTO dbo.W_AR_FUNCTION ( 
				BILLING_USER,							--<-- GROUP BY 
				COOP_CODE,								--<-- GROUP BY 
				COOP_PCT,								--<-- constant
				MANUAL_FLAG,							--<-- GROUP BY 
				INV_BY,									--<-- GROUP BY 
				ORDER_NBR,								--<-- GROUP BY 
				ORDER_LINE_NBR,							--<-- GROUP BY 
				MEDIA_TYPE,								--<-- GROUP BY 
				CL_CODE,								--<-- GROUP BY 
				DIV_CODE,								--<-- GROUP BY 
				PRD_CODE,								--<-- GROUP BY 
				OFFICE_CODE,							--<-- GROUP BY 
				SC_CODE,								--<-- GROUP BY 
				CMP_IDENTIFIER,							--<-- GROUP BY 
				CLIENT_PO,								--<-- GROUP BY 
				SALE_POST_PERIOD,						--<-- GROUP BY 
				INV_TAX_FLAG,							--<-- constant
				MED_REC_FLAG,							--<-- GROUP BY 
				BILL_COMM_NET,							--<-- GROUP BY 
				TAX_CODE,								--<-- GROUP BY 
				HRS_QTY,								--<-- SUM
				TOTAL_BILL,								--<-- SUM
				COST_AMT,								--<-- SUM
				REBATE_AMT,								--<-- SUM
				COMMISSION_AMT,							--<-- SUM
				NET_CHARGE_AMT,							--<-- SUM
				NON_RESALE_AMT,							--<-- SUM
				DISCOUNT_AMT,							--<-- SUM
				ADDITIONAL_AMT,							--<-- SUM
				CITY_TAX_AMT,							--<-- SUM
				CNTY_TAX_AMT,							--<-- SUM
				STATE_TAX_AMT,							--<-- SUM
				SUMMARY_FLAG,							--<-- GROUP BY
				MODIFIED_FLAG,							--<-- constant
				AR_INV_NBR,								--<-- GROUP BY
				AR_INV_SEQ,								--<-- GROUP BY
				[START_DATE],							--<-- GROUP BY
				[END_DATE],								--<-- GROUP BY
				MARKET_CODE,							--<-- GROUP BY
				MEDIA_MONTH,							--<-- GROUP BY
				MEDIA_YEAR,								--<-- GROUP BY
				REJECTED_BY_OFFICE )					--<-- GROUP BY
		 SELECT @billing_user_in, 
				o.COOP_CODE, o.COOP_PCT, 0, o.INV_BY, o.ORDER_NBR, o.LINE_NBR, o.ORDER_TYPE, 
				o.CL_CODE, o.DIV_CODE, o.PRD_CODE, o.OFFICE_CODE, o.SC_CODE, o.CMP_IDENTIFIER, 
				o.CLIENT_PO, d.SALE_POST_PERIOD, 0, o.INC_FLAG, o.BILL_COMM_NET, d.TAX_CODE, 
				--COALESCE( SUM( COALESCE( d.HRS_QTY, 0.000 )), 0.000 ), /* @@@@@@@@@@ ORIG */
				/* PJH 03/01/2019 - HRS_QTY is slpit via the TV_DETAIL_UNITS breakout. If it sums here and there are multiple revisions it would inflate the value. */
				CASE WHEN o.ORDER_TYPE =  'T' AND o.COOP_CODE = 'units!' THEN MAX( COALESCE( d.HRS_QTY, 0.000 )) ELSE SUM( COALESCE( d.HRS_QTY, 0.000 )) END,
				CASE o.BILL_COMM_NET 
					WHEN 1 THEN COALESCE( SUM( COALESCE( d.COMMISSION_AMT, 0.00 )), 0.00 )
							  + COALESCE( SUM( COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )										
							  + COALESCE( SUM( COALESCE( d.CITY_TAX_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.CNTY_TAX_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.STATE_TAX_AMT, 0.00 )), 0.00 )
					WHEN 2 THEN COALESCE( SUM( COALESCE( d.COST_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.NET_CHARGE_AMT, 0.00 )), 0.00 )
							  + COALESCE( SUM( COALESCE( d.NON_RESALE_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.DISCOUNT_AMT, 0.00 )), 0.00 )
							  + COALESCE( SUM( COALESCE( d.ADDITIONAL_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.CITY_TAX_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.CNTY_TAX_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.STATE_TAX_AMT, 0.00 )), 0.00 )
					WHEN 3 THEN COALESCE( SUM( COALESCE( d.COST_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.NET_CHARGE_AMT, 0.00 )), 0.00 )
							  + COALESCE( SUM( COALESCE( d.COMMISSION_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
							  + COALESCE( SUM( COALESCE( d.NON_RESALE_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.DISCOUNT_AMT, 0.00 )), 0.00 )
							  + COALESCE( SUM( COALESCE( d.ADDITIONAL_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.CITY_TAX_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.CNTY_TAX_AMT, 0.00 )), 0.00 ) 
							  + COALESCE( SUM( COALESCE( d.STATE_TAX_AMT, 0.00 )), 0.00 )
					ELSE 0.00
				END,				
				CASE o.BILL_COMM_NET WHEN 1 THEN 0.00 ELSE COALESCE( SUM( COALESCE( d.COST_AMT, 0.00 )), 0.00 ) END,							--  2
				CASE o.BILL_COMM_NET WHEN 2 THEN 0.00 ELSE COALESCE( SUM( COALESCE( d.REBATE_AMT, 0.00 )), 0.00 ) END,							--  3
				CASE o.BILL_COMM_NET WHEN 2 THEN 0.00 ELSE COALESCE( SUM( COALESCE( d.COMMISSION_AMT, 0.00 )), 0.00 ) END,						--  4
				CASE o.BILL_COMM_NET WHEN 1 THEN 0.00 ELSE COALESCE( SUM( COALESCE( d.NET_CHARGE_AMT, 0.00 )), 0.00 ) END,						--  5
				CASE o.BILL_COMM_NET WHEN 1 THEN 0.00 ELSE COALESCE( SUM( COALESCE( d.NON_RESALE_AMT, 0.00 )), 0.00 ) END,						--  6									
				CASE o.BILL_COMM_NET WHEN 1 THEN 0.00 ELSE COALESCE( SUM( COALESCE( d.DISCOUNT_AMT, 0.00 )), 0.00 ) END,						--  7									
				COALESCE( SUM( COALESCE( d.ADDITIONAL_AMT, 0.00 )), 0.00 ),																		--  8										
				COALESCE( SUM( COALESCE( d.CITY_TAX_AMT, 0.00 )), 0.00 ),																		-- 10
				COALESCE( SUM( COALESCE( d.CNTY_TAX_AMT, 0.00 )), 0.00 ),																		-- 11
				COALESCE( SUM( COALESCE( d.STATE_TAX_AMT, 0.00 )), 0.00 ),																		-- 12
				d.SUMMARY_FLAG, 
				CASE d.SUMMARY_FLAG WHEN 1 THEN NULL ELSE 0 END, 
				o.AR_INV_NBR, o.AR_INV_SEQ, d.RUN_DATE, d.END_DATE, o.MARKET_CODE, 
				d.MEDIA_MONTH, d.MEDIA_YEAR, o.REJECTED_BY_OFFICE
		   FROM #AR_ORDER_LIST o 
	 INNER JOIN #AR_ORDER_DTL d
			 ON ( o.AR_ORDER_LIST_ID = d.AR_ORDER_LIST_ID )
	   GROUP BY o.COOP_CODE, o.COOP_PCT, o.INV_BY, o.ORDER_NBR, o.LINE_NBR, d.SALE_POST_PERIOD,
				o.CL_CODE, o.DIV_CODE, o.PRD_CODE, o.OFFICE_CODE, o.SC_CODE, o.CMP_IDENTIFIER, 
				o.CLIENT_PO, o.ORDER_TYPE, o.BILL_COMM_NET, o.INC_FLAG, d.SUMMARY_FLAG, 
				o.REJECTED_BY_OFFICE, o.AR_INV_NBR, o.AR_INV_SEQ, d.RUN_DATE, d.END_DATE, 
				o.MARKET_CODE, d.MEDIA_MONTH, d.MEDIA_YEAR, d.TAX_CODE

				--,o.REVERSAL

	SET @ret_val = @@ERROR	

	--/* PJH 03/07/2019 - Update Hrs here - Grouped by Unit/CDP split */ /* <<<<<< Need to force a different AR_INV_SEQ above */
	--IF ( @ret_val = 0 )
	--	UPDATE A
	--	SET A.HRS_QTY = CASE WHEN ABS(A.HRS_QTY) > 1 THEN A.HRS_QTY/2 ELSE A.HRS_QTY END  --A.HRS_QTY = (B.HRS_QTY)
	--	FROM W_AR_FUNCTION A
	--		INNER JOIN (
	--			SELECT AR_INV_NBR, AR_INV_SEQ, ORDER_NBR, LINE_NBR, SUM(HRS_QTY) HRS_QTY FROM #AR_ORDER_LIST
	--			GROUP BY AR_INV_NBR, AR_INV_SEQ, ORDER_NBR, LINE_NBR) B 
	--		ON ( A.AR_INV_NBR = B.AR_INV_NBR AND A.AR_INV_SEQ = B.AR_INV_SEQ AND A.ORDER_NBR = B.ORDER_NBR AND A.ORDER_LINE_NBR = B.LINE_NBR ) 
	--	WHERE A.COOP_CODE = 'units!' 

	--SET @ret_val = @@ERROR	

END

--	**** ROUND ADJUSTMENTS (PRODUCTION) *************************************************************************************************************
IF ( @production = 1 )
BEGIN

	IF ( @ret_val = 0 )
	BEGIN
	
		 UPDATE af
			SET EMP_TIME_AMT = ( af.EMP_TIME_AMT + COALESCE( gbfv.EMP_TIME_AMT, 0.00 )),
				INC_ONLY_AMT = ( af.INC_ONLY_AMT + COALESCE( gbfv.INC_ONLY_AMT, 0.00 )),
				COMMISSION_AMT = ( af.COMMISSION_AMT + COALESCE( gbfv.COMMISSION_AMT, 0.00 )),
				COST_AMT = ( af.COST_AMT + COALESCE( gbfv.COST_AMT, 0.00 )),
				AB_COST_AMT = ( af.AB_COST_AMT + COALESCE( gbfv.AB_COST_AMT, 0.00 )),
				AB_INC_AMT = ( af.AB_INC_AMT + COALESCE( gbfv.AB_INC_AMT, 0.00 )),
				AB_COMMISSION_AMT = ( af.AB_COMMISSION_AMT + COALESCE( gbfv.AB_COMMISSION_AMT, 0.00 )),
				AB_SALE_AMT = ( af.AB_SALE_AMT + COALESCE( gbfv.AB_SALE_AMT, 0.00 )),
				-- BJL 11/20/2013
				AB_NONRESALE_AMT = ( af.AB_NONRESALE_AMT + COALESCE( gbfv.AB_NONRESALE_AMT, 0.00 )),
				-- BJL 05/13/2013 - Changed taxes to be adjusted for rounding only when invoice tax is NOT used
				STATE_TAX_AMT = CASE af.INV_TAX_FLAG WHEN 1 THEN af.STATE_TAX_AMT ELSE ( af.STATE_TAX_AMT + COALESCE( gbfv.STATE_TAX_AMT, 0.00 )) END,
				CNTY_TAX_AMT = CASE af.INV_TAX_FLAG WHEN 1 THEN af.CNTY_TAX_AMT ELSE ( af.CNTY_TAX_AMT + COALESCE( gbfv.CNTY_TAX_AMT, 0.00 )) END,
				CITY_TAX_AMT = CASE af.INV_TAX_FLAG WHEN 1 THEN af.CITY_TAX_AMT ELSE ( af.CITY_TAX_AMT + COALESCE( gbfv.CITY_TAX_AMT, 0.00 )) END,
				-- BJL 11/13/2013
				NON_RESALE_AMT = ( af.NON_RESALE_AMT + COALESCE( gbfv.NON_RESALE_AMT, 0.00 ))
				-- BJL 03/31/2013 - TOTAL_BILL should always be calculated across, not adjusted
	--			TOTAL_BILL = ( af.TOTAL_BILL + COALESCE( gbfv.TOTAL_BILL, 0.00 ))
		   FROM dbo.W_AR_FUNCTION af
	 INNER JOIN	#AR_JOB_LIST jl			     
			 ON ( af.JOB_NUMBER = jl.JOB_NUMBER )
			AND ( af.JOB_COMPONENT_NBR = jl.JOB_COMPONENT_NBR )
			AND ( af.CL_CODE = jl.CL_CODE )
			AND ( af.DIV_CODE = jl.DIV_CODE )
			AND ( af.PRD_CODE = jl.PRD_CODE )
			AND ( af.CMP_IDENTIFIER = jl.CMP_IDENTIFIER OR ( af.CMP_IDENTIFIER IS NULL AND jl.CMP_IDENTIFIER IS NULL ))					-- BJL 04/24/2013 - Multi-campaign to one job fix
	 INNER JOIN [dbo].[advtf_get_billing_function_var] ( @billing_user_in ) gbfv
			 ON ( af.JOB_NUMBER = gbfv.JOB_NUMBER )
			AND ( af.JOB_COMPONENT_NBR = gbfv.JOB_COMPONENT_NBR )
			AND ( af.FNC_CODE = gbfv.FNC_CODE )
			AND (( af.TAX_CODE = gbfv.TAX_CODE ) OR ( af.TAX_CODE IS NULL AND gbfv.TAX_CODE IS NULL ) OR ( af.INV_TAX_FLAG = 1 ))
		  WHERE ( af.BILLING_USER = @billing_user_in )
			AND ( af.SUMMARY_FLAG = 0 )
			AND ( jl.ADJUST_FLAG = 1 )
				
		SET @ret_val = @@ERROR								   
	
	END	

	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 11/20/2013 - Added AB_NONRESALE_AMT
		-- BJL 11/13/2013 - Added NON_RESALE_AMT
		-- BJL 05/13/2013 - This recalculation occurs after the invoice tax is applied
		-- BJL 03/31/2013 - TOTAL_BILL should always be calculated across, not adjusted
		 UPDATE af 
			SET TOTAL_BILL = ( COALESCE( af.EMP_TIME_AMT, 0.00 )) + ( COALESCE( af.INC_ONLY_AMT, 0.00 )) 
						   + ( COALESCE( af.COMMISSION_AMT, 0.00 )) + ( COALESCE( af.COST_AMT, 0.00 )) 
						   + ( COALESCE( af.AB_COST_AMT, 0.00 )) + ( COALESCE( af.AB_INC_AMT, 0.00 )) + ( COALESCE( af.AB_NONRESALE_AMT, 0.00 ))
						   + ( COALESCE( af.AB_COMMISSION_AMT, 0.00 )) + ( COALESCE( af.AB_SALE_AMT, 0.00 )) + ( COALESCE( af.NON_RESALE_AMT, 0.00 ))  
						   + ( COALESCE( af.STATE_TAX_AMT, 0.00 )) + ( COALESCE( af.CNTY_TAX_AMT, 0.00 )) + ( COALESCE( af.CITY_TAX_AMT, 0.00 ))
		   FROM dbo.W_AR_FUNCTION af
		  WHERE ( af.BILLING_USER = @billing_user_in )
			AND ( af.FNC_TYPE IS NOT NULL AND af.FNC_TYPE <> 'R' ) 
		  --AND ( af.SUMMARY_FLAG = 0 )
				
		SET @ret_val = @@ERROR								   
	END

END	

--	**** ROUND ADJUSTMENTS (MEDIA) ******************************************************************************************************************
IF ( @media = 1 )
BEGIN

	IF ( @ret_val = 0 )
	BEGIN

		--SELECT '**' 'SRC', * FROM W_AR_FUNCTION
		--SELECT 'Adjustment' 'Src', @billing_user_in '@billing_user_in'
		--SELECT * FROM [advtf_get_billing_order_line_var] ( @billing_user_in )

	     UPDATE af
			SET COST_AMT = ( af.COST_AMT + COALESCE( gbolv.COST_AMT, 0.00 )),
				REBATE_AMT = ( af.REBATE_AMT + COALESCE( gbolv.REBATE_AMT, 0.00 )),
				COMMISSION_AMT = ( af.COMMISSION_AMT + COALESCE( gbolv.COMMISSION_AMT, 0.00 )),
				NET_CHARGE_AMT = ( af.NET_CHARGE_AMT + COALESCE( gbolv.NET_CHARGE_AMT, 0.00 )),
				NON_RESALE_AMT = ( af.NON_RESALE_AMT + COALESCE( gbolv.NON_RESALE_AMT, 0.00 )),
				DISCOUNT_AMT = ( af.DISCOUNT_AMT + COALESCE( gbolv.DISCOUNT_AMT, 0.00 )),
				ADDITIONAL_AMT = ( af.ADDITIONAL_AMT + COALESCE( gbolv.ADDITIONAL_AMT, 0.00 )),
				STATE_TAX_AMT = ( af.STATE_TAX_AMT + COALESCE( gbolv.STATE_TAX_AMT, 0.00 )),
				CNTY_TAX_AMT = ( af.CNTY_TAX_AMT + COALESCE( gbolv.CNTY_TAX_AMT, 0.00 )),
				CITY_TAX_AMT = ( af.CITY_TAX_AMT + COALESCE( gbolv.CITY_TAX_AMT, 0.00 ))
				-- BJL 05/22/2013 - TOTAL_BILL should always be calculated across, not adjusted
		   FROM dbo.W_AR_FUNCTION af
	 INNER JOIN	#AR_ORDER_LIST ol			     
			 ON ( af.ORDER_NBR = ol.ORDER_NBR )
			AND ( af.ORDER_LINE_NBR = ol.LINE_NBR )
			AND ( af.CL_CODE = ol.CL_CODE )
			AND ( af.DIV_CODE = ol.DIV_CODE )
			AND ( af.PRD_CODE = ol.PRD_CODE )
	 INNER JOIN [dbo].[advtf_get_billing_order_line_var] ( @billing_user_in ) gbolv
			 ON ( af.ORDER_NBR = gbolv.ORDER_NBR )
			AND ( af.ORDER_LINE_NBR = gbolv.LINE_NBR )
			AND ( af.MEDIA_TYPE = gbolv.MEDIA_TYPE )
			AND (( af.TAX_CODE = gbolv.TAX_CODE ) OR ( af.TAX_CODE IS NULL AND gbolv.TAX_CODE IS NULL ) OR ( af.INV_TAX_FLAG = 1 ))
		  WHERE ( af.BILLING_USER = @billing_user_in )
			AND ( af.SUMMARY_FLAG = 0 )
			AND ( ol.ADJUST_FLAG = 1 )
				
		SET @ret_val = @@ERROR								   
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		-- BJL 05/22/2013 - TOTAL_BILL should always be calculated across, not adjusted

		 UPDATE af 
			SET TOTAL_BILL = ( COALESCE( af.COST_AMT, 0.00 )) + ( COALESCE( af.REBATE_AMT, 0.00 )) 
						   + ( COALESCE( af.COMMISSION_AMT, 0.00 )) + ( COALESCE( af.NET_CHARGE_AMT, 0.00 ))
						   + ( COALESCE( af.NON_RESALE_AMT, 0.00 )) + ( COALESCE( af.DISCOUNT_AMT, 0.00 )) 
						   + ( COALESCE( af.ADDITIONAL_AMT, 0.00 )) + ( COALESCE( af.STATE_TAX_AMT, 0.00 )) 
						   + ( COALESCE( af.CNTY_TAX_AMT, 0.00 )) + ( COALESCE( af.CITY_TAX_AMT, 0.00 ))
		   FROM dbo.W_AR_FUNCTION af
		  WHERE ( af.BILLING_USER = @billing_user_in )
			AND ( af.FNC_TYPE IS NULL ) 
		  --AND ( af.SUMMARY_FLAG = 0 )
				
		SET @ret_val = @@ERROR								   
	END	
	
END	

-- MJC 06/01/2016 - added multi currency
IF ( @ret_val = 0 )
BEGIN
	IF (SELECT MULTI_CRNCY FROM dbo.AGENCY) = 1 BEGIN
		UPDATE af 
			SET af.CURRENCY_CODE = c.CURRENCY_CODE,
				af.CURRENCY_RATE = (SELECT TOP 1 RECIPROCAL_EXCHANGE_RATE
									FROM dbo.CURRENCY_DETAIL 
									WHERE CURRENCY_CODE = c.CURRENCY_CODE 
									AND CURRENCY_CODE_COMPARISON = (SELECT HOME_CRNCY FROM dbo.AGENCY)
									ORDER BY EXCHANGE_DATE DESC)
		FROM dbo.W_AR_FUNCTION af
			INNER JOIN dbo.CLIENT c ON af.CL_CODE = c.CL_CODE
		WHERE af.BILLING_USER = @billing_user_in

		SET @ret_val = @@ERROR
	END
END

-- PJH 07/27/2018 - Unit Split - Clear 99 record for orders that have no unit split if any exist
IF ( @ret_val = 0 )
BEGIN
	DELETE A
	FROM W_AR_FUNCTION A 
	JOIN (
		SELECT AR_INV_NBR, COOP_CODE, ORDER_NBR, ORDER_LINE_NBR FROM W_AR_FUNCTION 
		WHERE BILLING_USER = @billing_user_in
		AND COOP_CODE = 'units!'
		AND COOP_PCT = 100) B ON A.AR_INV_NBR = B.AR_INV_NBR AND A.COOP_CODE = B.COOP_CODE AND A.ORDER_NBR = B.ORDER_NBR AND A.ORDER_LINE_NBR = B.ORDER_LINE_NBR
	WHERE A.AR_INV_SEQ = 99

	UPDATE A
	SET A.AR_INV_SEQ = 0, COOP_CODE = NULL
	FROM W_AR_FUNCTION A 
	JOIN (
		SELECT AR_INV_NBR, COOP_CODE, ORDER_NBR, ORDER_LINE_NBR FROM W_AR_FUNCTION 
		WHERE BILLING_USER = @billing_user_in
		AND COOP_CODE = 'units!'
		AND COOP_PCT = 100) B ON A.AR_INV_NBR = B.AR_INV_NBR AND A.COOP_CODE = B.COOP_CODE AND A.ORDER_NBR = B.ORDER_NBR AND A.ORDER_LINE_NBR = B.ORDER_LINE_NBR
	WHERE A.AR_INV_SEQ = 1
END

GO

GRANT EXECUTE ON [advsp_bcc_populate_ar_function] TO PUBLIC
G