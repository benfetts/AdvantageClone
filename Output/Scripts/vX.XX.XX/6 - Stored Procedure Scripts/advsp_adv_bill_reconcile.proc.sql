CREATE PROCEDURE [dbo].[advsp_adv_bill_reconcile] @job_number integer, @job_component_nbr smallint, @ab_id_in integer, 
	@bill_date smalldatetime, @rec_type tinyint, @billing_user varchar(100), @bcc_id int, @ret_val integer OUTPUT
AS

SET NOCOUNT ON

/* @ret_val Values
*  -2	Job is not billable
*  -3	Job process control does not allow final reconciliation
*  -4	Job is on bill hold
*  -5	Job is selected for billing by another user 
*  -6	Billing date not specified
*  -7	Reconciliation is already finalized for this job
*  -9	Billing is pending for this job
* -10	This is not an advance billed job  
*/

DECLARE @prior_billed decimal(15,2), @job_nobill_flag smallint, @job_proc_control smallint
DECLARE @bill_hold_count integer, @job_billing_user varchar(100), @contingency bit, @ab_id integer
DECLARE @est_nbr integer, @est_comp_nbr smallint, @est_qte_nbr smallint, @est_rev_nbr smallint
DECLARE @ab_id_next integer, @ab_seq int, @ab_seq_next int, @final_count integer
DECLARE @prd_ab_income smallint, @pending_count integer, @job_ab_flag smallint 
DECLARE @glacode_sales varchar(30), @glacode_def_sales varchar(30), @rec_amt decimal(15,2)
DECLARE @billed_flag bit, @reconciled bit, @bcc_flag smallint
DECLARE @ir_bcc_id int, @fnc_code varchar(6)

DECLARE @functions TABLE (
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AB_FLAG				smallint,
	SEQ_NBR				int,
	FROM_ACTUALS		smallint,
	FNC_TYPE			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ACTUAL_AMT			decimal(15,2),
	PO_AMT				decimal(15,2),
	PREV_AMT			decimal(15,2),
	ADV_AMT				decimal(15,2),
	ADV_MARKUP_PCT		decimal(9,3),
	ADV_TAX_CODE		varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADV_TOTAL			decimal(15,2),
	PREV_NET			decimal(15,2),
	ACTUAL_NET			decimal(15,2),
	MARKUP_AMT			decimal(15,2),
	STATE_AMT			decimal(15,2),
	COUNTY_AMT			decimal(15,2),
	CITY_AMT			decimal(15,2),
	NONRESALE_AMT		decimal(15,2),
	TAX_AMT				decimal(15,2),
	ACT_TO_BILL			decimal(15,2),
	ACT_TO_BILL_NET		decimal(15,2),
	ACT_TO_BILL_MU		decimal(15,2),
	ACT_TO_BILL_STATE	decimal(15,2),
	ACT_TO_BILL_COUNTY	decimal(15,2),
	ACT_TO_BILL_CITY	decimal(15,2),
	ACT_TO_BILL_NR		decimal(15,2),
	ACT_BILLED_AMT		decimal(15,2),
	ACT_BILLED_NET		decimal(15,2),
	ACT_BILLED_MU		decimal(15,2),
	ACT_BILLED_STATE	decimal(15,2),
	ACT_BILLED_COUNTY	decimal(15,2),
	ACT_BILLED_CITY		decimal(15,2),
	ACT_BILLED_NR		decimal(15,2),
	ADV_NET_AMT			decimal(15,2),
	ADV_MARKUP_AMT		decimal(15,2),
	ADV_STATE_AMT		decimal(15,2),
	ADV_COUNTY_AMT		decimal(15,2),
	ADV_CITY_AMT		decimal(15,2),
	ADV_NONRESALE_AMT	decimal(15,2),
	ADV_TAX_AMT			decimal(15,2),
	METHOD_TEXT			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADV_NONBILL_FLAG	smallint,
	ADV_MARKUP_FLAG		smallint,
	ADV_TAX_FLAG		smallint,
	ADV_TAX_MU			smallint,
	ADV_TAX_MU_ONLY		smallint,
	ADV_RESALE			smallint,
	ADV_STATE_PCT		decimal(8,4),
	ADV_COUNTY_PCT		decimal(8,4),
	ADV_CITY_PCT		decimal(8,4),
	ADV_BILLED_NET		decimal(15,2),
	ADV_BILLED_TOTAL	decimal(15,2),
	ADV_BILLED_STATE	decimal(15,2),
	ADV_BILLED_COUNTY	decimal(15,2),
	ADV_BILLED_CITY		decimal(15,2),
	ADV_BILLED_NR		decimal(15,2),
	ADV_BILLED_MU		decimal(15,2),
	FINAL_TOTAL			decimal(15,2),
	FINAL_NET			decimal(15,2),
	FINAL_MARKUP		decimal(15,2),
	FINAL_STATE			decimal(15,2),
	FINAL_COUNTY		decimal(15,2),
	FINAL_CITY			decimal(15,2),
	FINAL_NONRESALE		decimal(15,2),
	PO_NET_AMT			decimal(15,2),
	PO_STATE_AMT		decimal(15,2),
	PO_COUNTY_AMT		decimal(15,2),
	PO_CITY_AMT			decimal(15,2),
	PO_NONRESALE_AMT	decimal(15,2),
	PO_TAX_AMT			decimal(15,2),
	PO_RESALE			smallint,
	PO_STATE_PCT		decimal(8,4),
	PO_COUNTY_PCT		decimal(8,4),
	PO_CITY_PCT			decimal(8,4),
	PO_MARKUP_AMT		decimal(15,2),
	PO_MARKUP_PCT		decimal(9,3),
	PO_MARKUP_FLAG		smallint,
	PO_NONBILL_FLAG		smallint,
	PO_TAX_CODE			varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PO_TAX_FLAG			smallint,
	PO_TAX_MU			smallint,
	PO_TAX_MU_ONLY		smallint,
	QTE_NET				decimal(15,2),
	QTE_AMT				decimal(15,2),
	QTE_CITY_AMT		decimal(15,2),
	QTE_CITY_PCT		decimal(8,4),
	QTE_COUNTY_AMT		decimal(15,2),
	QTE_COUNTY_PCT		decimal(8,4),
	QTE_STATE_AMT		decimal(15,2),
	QTE_NONRESALE_AMT	decimal(15,2),
	QTE_MARKUP_AMT		decimal(15,2),
	QTE_MARKUP_FLAG		smallint,
	QTE_MARKUP_PCT		decimal(9,3),
	QTE_NONBILL_FLAG	smallint,
	QTE_RESALE			smallint,
	QTE_STATE_PCT		decimal(8,4),
	QTE_TAX_AMT			decimal(15,2),
	QTE_TAX_CODE		varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	QTE_TAX_FLAG		smallint,
	QTE_TAX_MU			smallint,
	QTE_TAX_MU_ONLY		smallint,
	QTE_CT_CITY_AMT		decimal(15,2),
	QTE_CT_COUNTY_AMT	decimal(15,2),
	QTE_CT_STATE_AMT	decimal(15,2),
	QTE_CT_NR_AMT		decimal(15,2),
	QTE_CT_MU_AMT		decimal(15,2),
	QTE_NOCT_CITY_AMT	decimal(15,2),
	QTE_NOCT_COUNTY_AMT	decimal(15,2),
	QTE_NOCT_STATE_AMT	decimal(15,2),
	QTE_NOCT_NR_AMT		decimal(15,2),
	QTE_NOCT_MU_AMT		decimal(15,2),
	CT_PCT				decimal(9,3),
	CT_AMT				decimal(15,2),
	CT_NET				decimal(15,2),
	NOCT_AMT			decimal(15,2),
	NOCT_NET			decimal(15,2),
	BA_AMT				decimal(15,2) )	

DECLARE @actuals TABLE (
	RECORD_ID			integer,
	SEQ_NBR				int,
	SEQ_NBR1			int,
	TABLE_FROM			smallint,
	INV_NBR				integer,
	INV_SEQ				smallint,
	FNC_TYPE			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_DESC			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OPEN_NET_AMT		decimal(15,2),
	OPEN_AMT			decimal(15,2),
	APPR_AMT			decimal(15,2),
	BILLED_TOTAL		decimal(15,2),
	BILLED_NET			decimal(15,2),
	FINAL_TOTAL			decimal(15,2),
	FINAL_NET			decimal(15,2),
	TAX_CODE			varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAX_MU				smallint,
	TAX_MU_ONLY			smallint,
	RESALE				smallint,
	STATE_PCT			decimal(8,4),
	COUNTY_PCT			decimal(8,4),
	CITY_PCT			decimal(8,4),
	STATE_AMT			decimal(15,2),
	COUNTY_AMT			decimal(15,2),
	CITY_AMT			decimal(15,2),
	NONRESALE_AMT		decimal(15,2),
	MARKUP_PCT			decimal(9,3),
	CONT_PCT			decimal(6,3),
	CONT_AMT			decimal(15,2),
	CONT_NET			decimal(15,2),
	CONT_STATE			decimal(15,2),
	CONT_COUNTY			decimal(15,2),
	CONT_CITY			decimal(15,2),
	CONT_NONRESALE		decimal(15,2),
	CONT_MARKUP			decimal(15,2),
	NO_CONT_AMT			decimal(15,2),
	NO_CONT_NET			decimal(15,2),
	METHOD				smallint,
	CALC_PCT			decimal(9,3),
	BILL_DATE			smalldatetime,
	AB_ID				integer,
	AB_SEQ				integer,
	AB_FLAG				smallint,
	FINAL_TYPE			smallint,
	SALES_AMT			decimal(15,2),
	WIP_AMT				decimal(15,2),
	GLACODE_WIP			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_SALES		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_CITY		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_COUNTY		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_STATE		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	GLACODE_COS			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLESEQ_WIP			smallint,
	GLESEQ_SALES		smallint,
	GLESEQ_STATE		smallint,
	GLESEQ_CNTY			smallint,
	GLESEQ_CITY			smallint,
	GLESEQ_COS			smallint,		
	METHOD_TEXT			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MARKUP_AMT			decimal(15,2) )
	
SELECT @ret_val = 0
SELECT @contingency = 0
SELECT @reconciled = 0
SELECT @billing_user = LTRIM( RTRIM( @billing_user ))
-- MJC 06/22/15 - remove these checks they should not happen
--IF ( @ret_val = 0 )
--BEGIN
--	IF ( @rec_type <> 3 ) 
--	BEGIN
--		IF ( @bill_date IS NULL )
--			SELECT @ret_val = -6
--	END
--END
IF ( @ret_val = 0 )
BEGIN
	 SELECT @job_proc_control = jc.JOB_PROCESS_CONTRL,
			@job_nobill_flag = jc.NOBILL_FLAG,
			@job_billing_user = jc.BILLING_USER,
			@est_nbr = ea.ESTIMATE_NUMBER, 
			@est_comp_nbr = ea.EST_COMPONENT_NBR,
			@est_qte_nbr = ea.EST_QUOTE_NBR,
			@est_rev_nbr = ea.EST_REVISION_NBR,
			@prd_ab_income = jc.PRD_AB_INCOME,
			@job_ab_flag = jc.AB_FLAG 
	   FROM dbo.JOB_COMPONENT jc LEFT OUTER JOIN ESTIMATE_APPROVAL ea
	     ON ( jc.JOB_NUMBER = ea.JOB_NUMBER )
	    AND ( jc.JOB_COMPONENT_NBR = ea.JOB_COMPONENT_NBR ) 
	  WHERE jc.JOB_NUMBER = @job_number
	    AND jc.JOB_COMPONENT_NBR = @job_component_nbr
END
-- MJC 06/22/15 - remove these checks they should not happen
--		-- BJL 09/25/09 - Check the nonbillable status, billing selection status and job process control
--		IF( @job_nobill_flag = 1 )
--			SELECT @ret_val = -2
			
--		IF @job_proc_control NOT IN	( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
--			SELECT @ret_val = -3
			
--		IF ( @job_billing_user IS NOT NULL ) AND ( @job_billing_user <> @billing_user )
--			SELECT @ret_val = -5

IF ( @ret_val = 0 )
BEGIN
	SELECT @final_count = ( SELECT COUNT(*) 
	                          FROM dbo.ADVANCE_BILLING 
	                         WHERE ( ( AB_FLAG = 3 ) OR 
								   ( ( AR_INV_NBR IS NULL ) AND ( AB_FLAG IN ( 4, 5 )) ) OR 
								   ( ( AR_INV_NBR IS NOT NULL ) AND ( AB_FLAG IN ( 4, 5 )) AND ( AR_INV_VOID IS NULL OR AR_INV_VOID = 0 ) ) )
							   AND JOB_NUMBER = @job_number
							   AND JOB_COMPONENT_NBR = @job_component_nbr )
 
	IF ( @final_count > 0 )
		SELECT @ret_val = -7
	
END

IF ( @ret_val = 0 )
BEGIN
	SELECT @bill_hold_count = ( SELECT COUNT(*) 
								  FROM dbo.JOB_COMPONENT
								 WHERE JOB_NUMBER = @job_number
								   AND JOB_COMPONENT_NBR = @job_component_nbr
								   AND JOB_BILL_HOLD = 2 )
		
	IF ( @bill_hold_count = 0 )
		SELECT @bill_hold_count = ( SELECT COUNT(*)
									  FROM dbo.AP_PRODUCTION
									 WHERE JOB_NUMBER = @job_number
									   AND JOB_COMPONENT_NBR = @job_component_nbr
									   AND AP_PROD_BILL_HOLD = 2 )
	ELSE
		SELECT @ret_val = -4
		
	IF ( @bill_hold_count = 0 )	
		SELECT @bill_hold_count = ( SELECT COUNT(*)
									  FROM dbo.EMP_TIME_DTL 
									 WHERE JOB_NUMBER = @job_number
									   AND JOB_COMPONENT_NBR = @job_component_nbr
									   AND BILL_HOLD_FLG = 2 )
	ELSE
		SELECT @ret_val = -4

	IF ( @bill_hold_count = 0 )		
		SELECT @bill_hold_count = ( SELECT COUNT(*)
									  FROM dbo.INCOME_ONLY
									 WHERE JOB_NUMBER = @job_number
									   AND JOB_COMPONENT_NBR = @job_component_nbr
									   AND BILL_HOLD_FLAG = 2 )
	ELSE
		SELECT @ret_val = -4
END

IF ( @ret_val = 0 )
BEGIN
	-- Check to see if anything is pending
	SELECT @pending_count = ( SELECT COUNT(*) 
								FROM dbo.ADVANCE_BILLING 
							   WHERE ( AR_INV_NBR IS NULL )
								 AND ( AB_FLAG <> 3 )
								 AND JOB_NUMBER = @job_number
								 AND JOB_COMPONENT_NBR = @job_component_nbr )
 
	IF ( @pending_count > 0 )
		SELECT @ret_val = -9
	
END

IF ( @ret_val = 0 )
BEGIN
	-- Check to see if anything is pending
	SELECT @pending_count = ( SELECT COUNT(*) 
								FROM dbo.INCOME_REC 
							   WHERE ( AR_INV_NBR IS NULL )
								 AND ( AB_FLAG <> 3 )
								 AND JOB_NUMBER = @job_number
								 AND JOB_COMPONENT_NBR = @job_component_nbr )
 
	IF ( @pending_count > 0 )
		SELECT @ret_val = -9
	
END

IF ( @ret_val = 0 )
BEGIN
	IF ( @job_ab_flag = 0 ) AND ( @rec_type = 1 )
		SELECT @ret_val = -10	
END

IF ( @ret_val = 0 )
BEGIN
	-- If there is nothing to reconcile
	SELECT @billed_flag = ( SELECT dbo.advfn_job_has_billed_records( @job_number, @job_component_nbr ))
	IF ( @billed_flag = 0 )
		SELECT @ret_val = -1
END

IF ( @ret_val = 0 )
BEGIN
	INSERT INTO @functions( FNC_CODE, AB_FLAG, SEQ_NBR, FROM_ACTUALS, FNC_TYPE, ACTUAL_AMT, PO_AMT, PREV_AMT, ADV_AMT, ADV_MARKUP_PCT,
	                        ADV_TAX_CODE, ADV_TOTAL, PREV_NET, ACTUAL_NET, MARKUP_AMT, STATE_AMT, COUNTY_AMT, CITY_AMT,
	                        NONRESALE_AMT, TAX_AMT, ACT_TO_BILL, ACT_TO_BILL_NET, ACT_TO_BILL_MU, ACT_TO_BILL_STATE, ACT_TO_BILL_COUNTY,
	                        ACT_TO_BILL_CITY, ACT_TO_BILL_NR, ACT_BILLED_AMT, ACT_BILLED_NET, ACT_BILLED_MU, ACT_BILLED_STATE,
	                        ACT_BILLED_COUNTY, ACT_BILLED_CITY, ACT_BILLED_NR, ADV_NET_AMT, ADV_MARKUP_AMT, ADV_STATE_AMT,
	                        ADV_COUNTY_AMT, ADV_CITY_AMT, ADV_NONRESALE_AMT, ADV_TAX_AMT, METHOD_TEXT, ADV_NONBILL_FLAG,
	                        ADV_MARKUP_FLAG, ADV_TAX_FLAG, ADV_TAX_MU, ADV_TAX_MU_ONLY, ADV_RESALE, ADV_STATE_PCT,
	                        ADV_COUNTY_PCT, ADV_CITY_PCT, ADV_BILLED_NET, ADV_BILLED_TOTAL, ADV_BILLED_STATE, ADV_BILLED_COUNTY,
	                        ADV_BILLED_CITY, ADV_BILLED_NR, ADV_BILLED_MU, FINAL_TOTAL, FINAL_NET, FINAL_MARKUP, FINAL_STATE,
	                        FINAL_COUNTY, FINAL_CITY, FINAL_NONRESALE, PO_NET_AMT, PO_STATE_AMT, PO_COUNTY_AMT, PO_CITY_AMT,
	                        PO_NONRESALE_AMT, PO_TAX_AMT, PO_RESALE, PO_STATE_PCT, PO_COUNTY_PCT, PO_CITY_PCT, PO_MARKUP_AMT,
	                        PO_MARKUP_PCT, PO_MARKUP_FLAG, PO_NONBILL_FLAG, PO_TAX_CODE, PO_TAX_FLAG, PO_TAX_MU, PO_TAX_MU_ONLY,
	                        QTE_NET, QTE_AMT, QTE_CITY_AMT, QTE_CITY_PCT, QTE_COUNTY_AMT, QTE_COUNTY_PCT, QTE_STATE_AMT,
	                        QTE_NONRESALE_AMT, QTE_MARKUP_AMT, QTE_MARKUP_FLAG, QTE_MARKUP_PCT, QTE_NONBILL_FLAG, QTE_RESALE,
	                        QTE_STATE_PCT, QTE_TAX_AMT, QTE_TAX_CODE, QTE_TAX_FLAG, QTE_TAX_MU, QTE_TAX_MU_ONLY, QTE_CT_CITY_AMT,
	                        QTE_CT_COUNTY_AMT, QTE_CT_STATE_AMT, QTE_CT_NR_AMT, QTE_CT_MU_AMT, QTE_NOCT_CITY_AMT, QTE_NOCT_COUNTY_AMT,
	                        QTE_NOCT_STATE_AMT, QTE_NOCT_NR_AMT, QTE_NOCT_MU_AMT, CT_PCT, CT_AMT, CT_NET, NOCT_AMT, NOCT_NET, BA_AMT )
	EXECUTE advsp_adv_bill_functions @job_number = @job_number, @job_component_nbr = @job_component_nbr, @est_nbr = @est_nbr,
		@est_comp_nbr = @est_comp_nbr, @est_qte_nbr = @est_qte_nbr, @est_rev_nbr = @est_rev_nbr, @ab_id = @ab_id, 
		@contingency = @contingency, @ret_val = @ret_val OUTPUT	                        

	-- BJL 09/24/09 - If there is no prior amount, then no reconciliation takes place. Return with code -1.
	SELECT @prior_billed = ( SELECT SUM( COALESCE( PREV_AMT, 0.00 )) FROM @functions )
	
--	IF ( @prior_billed = 0.00 )
--		SELECT @ret_val = -1
		
END

IF ( @ret_val = 0 )
BEGIN
	-- BJL 09/24/09 - Add Advance Billing reversal entries		   
	INSERT INTO @actuals( TABLE_FROM, RECORD_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, FINAL_TYPE, 
			OPEN_NET_AMT, MARKUP_AMT, STATE_AMT, COUNTY_AMT, CITY_AMT, TAX_MU, TAX_MU_ONLY, RESALE, 
			NONRESALE_AMT, OPEN_AMT, SALES_AMT, WIP_AMT, MARKUP_PCT, TAX_CODE, 
			GLACODE_SALES, GLACODE_COS, GLACODE_WIP, GLACODE_CITY, GLACODE_COUNTY, GLACODE_STATE,
			STATE_PCT, COUNTY_PCT, CITY_PCT )
	 SELECT 58, AB_ID, A.SEQ_NBR, FNC_CODE, FNC_TYPE, 4, 
			-(ADV_BILL_NET_AMT), -(EXT_MARKUP_AMT), -(EXT_STATE_RESALE), -(EXT_COUNTY_RESALE), -(EXT_CITY_RESALE), 
			TAX_COMM, TAX_COMM_ONLY, TAX_RESALE, -(EXT_NONRESALE_TAX), -(LINE_TOTAL),
			COALESCE( COALESCE( ADV_BILL_NET_AMT, 0.00 ) + COALESCE( EXT_NONRESALE_TAX, 0.00 ) + COALESCE( EXT_MARKUP_AMT, 0.00 ), 0.00 ), 
			CASE FNC_TYPE 
				WHEN 'V' THEN COALESCE( COALESCE( ADV_BILL_NET_AMT, 0.00 ) + COALESCE( EXT_NONRESALE_TAX, 0.00 ), 0.00 )
				ELSE NULL
			END, 
			COMMISSION_PCT, TAX_CODE,
			A.GLACODE_SALES,
			CASE FNC_TYPE 
				WHEN 'V' THEN A.GLACODE_COS
				ELSE NULL
			END, 
			CASE FNC_TYPE 
				WHEN 'V' THEN A.GLACODE_ACC_AP
				ELSE NULL
			END, 
			CASE 
				WHEN EXT_STATE_RESALE IS NULL THEN NULL
				ELSE A.GLACODE_CITY
			END, 
			CASE 
				WHEN EXT_STATE_RESALE IS NULL THEN NULL
				ELSE A.GLACODE_CNTY
			END, 
			CASE 
				WHEN EXT_STATE_RESALE IS NULL THEN NULL
				ELSE A.GLACODE_STATE 
			END, 
			CASE 
				WHEN TAX_CODE IS NULL THEN NULL
				ELSE TAX_STATE_PCT
			END, 
			CASE 
				WHEN TAX_CODE IS NULL THEN NULL
				ELSE TAX_COUNTY_PCT
			END, 
			CASE 
				WHEN TAX_CODE IS NULL THEN NULL
				ELSE TAX_CITY_PCT
			END
	   FROM dbo.ADVANCE_BILLING A, ACCT_REC B 
	  WHERE A.JOB_NUMBER = @job_number
		AND A.JOB_COMPONENT_NBR = @job_component_nbr
		AND A.AR_INV_NBR IS NOT NULL 
		AND A.AR_INV_NBR = B.AR_INV_NBR 
		AND A.AR_INV_SEQ = B.AR_INV_SEQ
		AND (B.VOID_FLAG IS NULL OR B.VOID_FLAG = 0)
		AND A.AR_INV_VOID IS NULL		   
		AND AB_FLAG <> 3

END		

IF ( @ret_val = 0 ) AND ( @rec_type IN ( 2, 4 ) )
BEGIN

	IF ( @rec_type = 2 ) --FINAL_RECON_TO_QUOTE
	BEGIN

		 UPDATE @functions
		    SET ADV_NET_AMT = COALESCE( QTE_NET, 0.00 ) - COALESCE( ACTUAL_NET, 0.00 ),
				ADV_MARKUP_AMT = COALESCE( QTE_MARKUP_AMT, 0.00 ) - COALESCE( MARKUP_AMT, 0.00 ),
				ADV_STATE_AMT = COALESCE( QTE_STATE_AMT, 0.00 ) - COALESCE( STATE_AMT, 0.00 ),
				ADV_COUNTY_AMT = COALESCE( QTE_COUNTY_AMT, 0.00 ) - COALESCE( COUNTY_AMT, 0.00 ),
				ADV_CITY_AMT = COALESCE( QTE_CITY_AMT, 0.00 ) - COALESCE( CITY_AMT, 0.00 ),
				ADV_NONRESALE_AMT = ( COALESCE( QTE_NONRESALE_AMT, 0.00 ) - COALESCE( NONRESALE_AMT, 0.00 )),
				ADV_TAX_AMT = ( COALESCE( QTE_STATE_AMT, 0.00 ) - COALESCE( STATE_AMT, 0.00 )
							  + COALESCE( QTE_COUNTY_AMT, 0.00 ) - COALESCE( COUNTY_AMT, 0.00 )
							  + COALESCE( QTE_CITY_AMT, 0.00 ) - COALESCE( CITY_AMT, 0.00 )
							  + COALESCE( QTE_NONRESALE_AMT, 0.00 ) - COALESCE( NONRESALE_AMT, 0.00 )),
				ADV_TOTAL = ( COALESCE( QTE_NET, 0.00 ) - COALESCE( ACTUAL_NET, 0.00 )
							+ COALESCE( QTE_MARKUP_AMT, 0.00 ) - COALESCE( MARKUP_AMT, 0.00 )
							+ COALESCE( QTE_STATE_AMT, 0.00 ) - COALESCE( STATE_AMT, 0.00 )
							+ COALESCE( QTE_COUNTY_AMT, 0.00 ) - COALESCE( COUNTY_AMT, 0.00 )
							+ COALESCE( QTE_CITY_AMT, 0.00 ) - COALESCE( CITY_AMT, 0.00 )
							+ COALESCE( QTE_NONRESALE_AMT, 0.00 ) - COALESCE( NONRESALE_AMT, 0.00 )) 
		  WHERE ( COALESCE( QTE_AMT, 0.00 ) - COALESCE( ACTUAL_AMT, 0.00 ) + COALESCE( QTE_NONRESALE_AMT, 0.00 ) - COALESCE( NONRESALE_AMT, 0.00 ) <> 0.00 ) 
		  
		 INSERT INTO @actuals( FINAL_TYPE, FNC_CODE, FNC_TYPE, TABLE_FROM, OPEN_AMT, OPEN_NET_AMT, MARKUP_AMT, STATE_AMT, COUNTY_AMT, CITY_AMT, NONRESALE_AMT, METHOD_TEXT )
			 SELECT 5, FNC_CODE, FNC_TYPE, 58, ADV_TOTAL, ADV_NET_AMT, ADV_MARKUP_AMT, ADV_STATE_AMT, ADV_COUNTY_AMT, ADV_CITY_AMT, ADV_NONRESALE_AMT, METHOD_TEXT
			   FROM	@functions 		  
			  WHERE ( COALESCE( QTE_AMT, 0.00 ) - COALESCE( ACTUAL_AMT, 0.00 ) + COALESCE( QTE_NONRESALE_AMT, 0.00 ) - COALESCE( NONRESALE_AMT, 0.00 ) <> 0.00 )
		   			
	END

	IF ( @rec_type = 4 ) --FINAL_RECON_TO_BILLED
	BEGIN

		 UPDATE @functions
		    SET ADV_NET_AMT = ( COALESCE( ADV_BILLED_NET, 0.00 ) + COALESCE( ACT_BILLED_NET, 0.00 ) - COALESCE( ACTUAL_NET, 0.00 )
							  + COALESCE( ADV_BILLED_NR, 0.00 ) + COALESCE( ACT_BILLED_NR, 0.00 ) - COALESCE( NONRESALE_AMT, 0.00 )),
				ADV_MARKUP_AMT = ( COALESCE( ADV_BILLED_MU, 0.00 ) + COALESCE( ACT_BILLED_MU, 0.00 ) - COALESCE( MARKUP_AMT, 0.00 )),
				ADV_STATE_AMT = ( COALESCE( ADV_BILLED_STATE, 0.00 ) + COALESCE( ACT_BILLED_STATE, 0.00 ) - COALESCE( STATE_AMT, 0.00 )),
				ADV_COUNTY_AMT = ( COALESCE( ADV_BILLED_COUNTY, 0.00 ) + COALESCE( ACT_BILLED_COUNTY, 0.00 ) - COALESCE( COUNTY_AMT, 0.00 )),
				ADV_CITY_AMT = ( COALESCE( ADV_BILLED_CITY, 0.00 ) + COALESCE( ACT_BILLED_CITY, 0.00 ) - COALESCE( CITY_AMT, 0.00 )), 
				ADV_TAX_AMT = ( COALESCE( ADV_BILLED_STATE, 0.00 ) + COALESCE( ACT_BILLED_STATE, 0.00 ) - COALESCE( STATE_AMT, 0.00 )
							  + COALESCE( ADV_BILLED_COUNTY, 0.00 ) + COALESCE( ACT_BILLED_COUNTY, 0.00 ) - COALESCE( COUNTY_AMT, 0.00 )
							  + COALESCE( ADV_BILLED_CITY, 0.00 ) + COALESCE( ACT_BILLED_CITY, 0.00 ) - COALESCE( CITY_AMT, 0.00 )),
				ADV_TOTAL = ( COALESCE( ADV_BILLED_NET, 0.00 ) + COALESCE( ACT_BILLED_NET, 0.00 ) - COALESCE( ACTUAL_NET, 0.00 )
							+ COALESCE( ADV_BILLED_NR, 0.00 ) + COALESCE( ACT_BILLED_NR, 0.00 ) - COALESCE( NONRESALE_AMT, 0.00 )
							+ COALESCE( ADV_BILLED_STATE, 0.00 ) + COALESCE( ACT_BILLED_STATE, 0.00 ) - COALESCE( STATE_AMT, 0.00 )
							+ COALESCE( ADV_BILLED_COUNTY, 0.00 ) + COALESCE( ACT_BILLED_COUNTY, 0.00 ) - COALESCE( COUNTY_AMT, 0.00 )
							+ COALESCE( ADV_BILLED_CITY, 0.00 ) + COALESCE( ACT_BILLED_CITY, 0.00 ) - COALESCE( CITY_AMT, 0.00 )
							+ COALESCE( ADV_BILLED_MU, 0.00 ) + COALESCE( ACT_BILLED_MU, 0.00 ) - COALESCE( MARKUP_AMT, 0.00 ))
		  WHERE ( COALESCE( ACT_BILLED_AMT, 0.00 ) + COALESCE( ADV_BILLED_TOTAL, 0.00 ) - COALESCE( ACTUAL_AMT, 0.00 ) <> 0.00 )
		  
		 INSERT INTO @actuals ( FINAL_TYPE, FNC_CODE, FNC_TYPE, TABLE_FROM, OPEN_AMT, OPEN_NET_AMT, MARKUP_AMT, STATE_AMT, COUNTY_AMT, CITY_AMT, NONRESALE_AMT, METHOD_TEXT )
			 SELECT 5, FNC_CODE, FNC_TYPE, 58, ADV_TOTAL, ADV_NET_AMT, ADV_MARKUP_AMT, ADV_STATE_AMT, ADV_COUNTY_AMT, ADV_CITY_AMT, 0, METHOD_TEXT
			   FROM @functions  
			  WHERE ( COALESCE( ACT_BILLED_AMT, 0.00 ) + COALESCE( ADV_BILLED_TOTAL, 0.00 ) - COALESCE( ACTUAL_AMT, 0.00 ) <> 0.00 )

	END
	
	 UPDATE @actuals
	    SET GLACODE_STATE = (	  SELECT TOP 1 ab.GLACODE_STATE 
									FROM dbo.ADVANCE_BILLING ab INNER JOIN @functions f
									  ON ab.FNC_CODE = f.FNC_CODE 
								   WHERE ab.JOB_NUMBER = @job_number
									 AND ab.JOB_COMPONENT_NBR = @job_component_nbr
									 AND ab.AB_FLAG <> 3
									 AND ab.AR_INV_VOID IS NULL
									 AND ab.AR_INV_NBR IS NOT NULL
								ORDER BY AB_ID, ab.SEQ_NBR DESC ),
			GLACODE_COUNTY = (	  SELECT TOP 1 ab.GLACODE_CNTY 
									FROM dbo.ADVANCE_BILLING ab INNER JOIN @functions f
									  ON ab.FNC_CODE = f.FNC_CODE 
								   WHERE ab.JOB_NUMBER = @job_number
									 AND ab.JOB_COMPONENT_NBR = @job_component_nbr
									 AND ab.AB_FLAG <> 3
									 AND ab.AR_INV_VOID IS NULL
									 AND ab.AR_INV_NBR IS NOT NULL
								ORDER BY AB_ID, ab.SEQ_NBR DESC ),
			GLACODE_CITY = (	  SELECT TOP 1 ab.GLACODE_CITY 
									FROM dbo.ADVANCE_BILLING ab INNER JOIN @functions f
									  ON ab.FNC_CODE = f.FNC_CODE 
								   WHERE ab.JOB_NUMBER = @job_number
									 AND ab.JOB_COMPONENT_NBR = @job_component_nbr
									 AND ab.AB_FLAG <> 3
									 AND ab.AR_INV_VOID IS NULL
									 AND ab.AR_INV_NBR IS NOT NULL
								ORDER BY AB_ID, ab.SEQ_NBR DESC ),
			TAX_CODE = (	  SELECT TOP 1 TAX_CODE 
									FROM dbo.ADVANCE_BILLING ab INNER JOIN @functions f
									  ON ab.FNC_CODE = f.FNC_CODE 
								   WHERE ab.JOB_NUMBER = @job_number
									 AND ab.JOB_COMPONENT_NBR = @job_component_nbr
									 AND ab.AB_FLAG <> 3
									 AND ab.AR_INV_VOID IS NULL
									 AND ab.AR_INV_NBR IS NOT NULL
								ORDER BY AB_ID, ab.SEQ_NBR DESC )
	  WHERE (( STATE_AMT <> 0.00 AND STATE_AMT IS NOT NULL ) OR ( COUNTY_AMT <> 0.00 AND COUNTY_AMT IS NOT NULL ) OR ( CITY_AMT <> 0.00 AND CITY_AMT IS NOT NULL ))
	    AND FINAL_TYPE = 5
	    		
END


IF ( @ret_val = 0 )
BEGIN
	IF ( @rec_type <> 3 )
	BEGIN
		-- BJL 09/24/09 - Add Income Recognition reversal entries
		DECLARE ir_cursor CURSOR FOR
		 SELECT AB_ID, GLACODE_SALES, GLACODE_DEF_SALES, -(REC_AMT), BCC_ID, FNC_CODE
		   FROM dbo.INCOME_REC ir
		  WHERE JOB_NUMBER = @job_number
			AND JOB_COMPONENT_NBR = @job_component_nbr
			AND ( AR_INV_NBR IS NOT NULL )
			AND ( AR_INV_VOID IS NULL OR AR_INV_VOID = 0 )
			AND ( AB_FLAG IS NULL OR AB_FLAG <> 3 )
		FOR READ ONLY
		
		OPEN ir_cursor	

		FETCH ir_cursor INTO @ab_id, @glacode_sales, @glacode_def_sales, @rec_amt, @ir_bcc_id, @fnc_code
		
		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
			SELECT @ab_seq = ( SELECT MAX( SEQ_NBR ) + 1 FROM dbo.INCOME_REC ir2 WHERE ir2.AB_ID = @ab_id )
			
			INSERT INTO dbo.INCOME_REC ( AB_ID, SEQ_NBR, AB_FLAG, JOB_NUMBER, JOB_COMPONENT_NBR, 
					BILL_DATE, GLACODE_SALES, GLACODE_DEF_SALES, REC_AMT, FINAL_FLAG, CREATE_DATE,
					[USER_ID], BCC_ID, FNC_CODE )
				 VALUES ( @ab_id, @ab_seq, 7, @job_number, @job_component_nbr, @bill_date,
					 @glacode_sales, @glacode_def_sales, @rec_amt, 1, CAST( convert(varchar(10),getdate(),101) AS smalldatetime), @billing_user, @ir_bcc_id, @fnc_code )
			
			SELECT @reconciled = 1
			
			FETCH ir_cursor INTO @ab_id, @glacode_sales, @glacode_def_sales, @rec_amt, @ir_bcc_id, @fnc_code
		END
		
		CLOSE ir_cursor
		DEALLOCATE ir_cursor
							
		-- BJL 09/24/09 - Update the final flag	on original row
		UPDATE dbo.INCOME_REC 
		   SET FINAL_FLAG = 1
		 WHERE JOB_NUMBER = @job_number
		   AND JOB_COMPONENT_NBR = @job_component_nbr
		   AND ( AR_INV_NBR IS NOT NULL )
		   AND ( AR_INV_VOID IS NULL OR AR_INV_VOID = 0 )
		   AND ( AB_FLAG IS NULL OR AB_FLAG <> 3 )

		-- MJC 08/25/15 - don't increment AB_ID 
		SELECT @ab_id_next = [dbo].[advfn_bcc_get_advance_billing_id] (@job_number, @job_component_nbr)

		SELECT @ab_seq_next = COALESCE(MAX(SEQ_NBR),0) + 1
		FROM dbo.ADVANCE_BILLING
		WHERE AB_ID = @ab_id_next 

		IF @ab_id_next = 0
		BEGIN
			-- Update the Advance Billing records with the sequence number
			EXECUTE dbo.advsp_get_next_nbr @column_name = 'AB_ID', @next_nbr = @ab_id_next OUTPUT
		
			--PRINT @ab_id_next
		
			SELECT @ab_seq_next = 1 
		END

		DECLARE ab_cursor CURSOR FOR
		 SELECT AB_ID, AB_SEQ
		   FROM @actuals

		OPEN ab_cursor

		FETCH ab_cursor INTO @ab_id, @ab_seq  

		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
			 UPDATE @actuals 
			    SET AB_ID = @ab_id_next, 
					AB_SEQ = @ab_seq_next
			 WHERE CURRENT OF ab_cursor
			 
			FETCH ab_cursor INTO @ab_id, @ab_seq
			SELECT @ab_seq_next = ( @ab_seq_next + 1 )			 
		END	

		CLOSE ab_cursor
		DEALLOCATE ab_cursor		
		
		INSERT INTO dbo.ADVANCE_BILLING( AB_ID, SEQ_NBR, FNC_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, 
				FINAL_SEQ_NBR, ADV_BILL_NET_AMT, CREATE_DATE, ESTIMATE_NUMBER, EST_COMPONENT_NBR, 
				EST_QUOTE_NBR, EST_REVISION_NBR, FINAL_AB_ID, FINAL_DATE, FINAL_USER, FNC_TYPE, 
				GLACODE_ACC_AP, GLACODE_CITY, GLACODE_CNTY, GLACODE_COS, GLACODE_SALES, GLACODE_STATE, 
				GLESEQ_ACC_AP, GLESEQ_CITY, GLESEQ_CNTY, GLESEQ_COS, GLESEQ_SALES, GLESEQ_STATE, 
				GLEXACT, TAX_CITY_PCT, TAX_CODE, TAX_COMM, TAX_COMM_ONLY, TAX_COUNTY_PCT, TAX_RESALE, 
				TAX_STATE_PCT, USER_ID, AB_FLAG, CALC_METHOD, COMMISSION_PCT, LINE_TOTAL, EXT_MARKUP_AMT, 
				EXT_STATE_RESALE, EXT_COUNTY_RESALE, EXT_CITY_RESALE, EXT_NONRESALE_TAX, BILL_DATE, METHOD_DESC, BCC_ID )
		 SELECT AB_ID, AB_SEQ, FNC_CODE, @job_number, @job_component_nbr, AB_SEQ, OPEN_NET_AMT,
				CONVERT( varchar(10), GETDATE(), 101 ), @est_nbr, @est_comp_nbr, @est_qte_nbr, 
				@est_rev_nbr, AB_ID, CONVERT( varchar(10), GETDATE(), 101 ), @billing_user, --dbo.78( ),
				FNC_TYPE, GLACODE_WIP, GLACODE_CITY, GLACODE_COUNTY, GLACODE_COS, GLACODE_SALES,
				GLACODE_STATE, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CITY_PCT, TAX_CODE, TAX_MU, 
				TAX_MU_ONLY, COUNTY_PCT, RESALE, STATE_PCT, @billing_user, /*dbo.78( ),*/ FINAL_TYPE,
				NULL, MARKUP_PCT, OPEN_AMT, MARKUP_AMT, STATE_AMT, COUNTY_AMT, CITY_AMT, 
				NONRESALE_AMT, @bill_date,
				CASE @rec_type
					WHEN 1 THEN 'Reconcile to actual'
					WHEN 2 THEN 'Reconcile to quote'
					WHEN 4 THEN 'Reconcile to billed'
					ELSE 'Reconcile no bill'
				END, @bcc_id
		   FROM @actuals
		   
		IF ( @@ROWCOUNT > 0 )
			SELECT @reconciled = 1
				
		 UPDATE dbo.ADVANCE_BILLING
		    SET FINAL_AB_ID = A.AB_ID,
				FINAL_SEQ_NBR = A.AB_SEQ,
				FINAL_DATE = CONVERT( varchar(10), GETDATE(), 101 ),
				FINAL_USER = @billing_user --dbo.78( )
		   FROM @actuals A INNER JOIN dbo.ADVANCE_BILLING
		     ON ( A.RECORD_ID = dbo.ADVANCE_BILLING.AB_ID )
		    AND ( A.SEQ_NBR = dbo.ADVANCE_BILLING.SEQ_NBR )	
		    
		IF ( @reconciled = 1 )
		BEGIN
			SELECT @bcc_flag = ( SELECT TOP 1 BCC_FLAG 
								   FROM dbo.JOB_PROCESS_LOG 
								  WHERE JOB_NUMBER = @job_number
									AND JOB_COMPONENT_NBR = @job_component_nbr 
							   ORDER BY JOB_PROCESS_LOG_ID DESC )     

			IF ( @bcc_flag = 1 )
				SELECT @bcc_flag = @bcc_flag
			ELSE	
				INSERT INTO dbo.JOB_PROCESS_LOG ( JOB_NUMBER, JOB_COMPONENT_NBR, ORIG_PROCESS_CNTRL, 
							NEW_PROCESS_CNTRL, PROCESS_DATE, PROCESS_USER, PROCESS_COMMENT, BCC_FLAG )
					 SELECT @job_number, @job_component_nbr, jc.JOB_PROCESS_CONTRL, 5, GETDATE( ),
							@billing_user, 'Final Reconciled - Billing Pending', 1
					   FROM dbo.JOB_COMPONENT jc  
					  WHERE jc.JOB_NUMBER = @job_number
						AND jc.JOB_COMPONENT_NBR = @job_component_nbr
		END
		
		 UPDATE dbo.JOB_COMPONENT 
			SET AB_FLAG = 1,
				JOB_PROCESS_CONTRL = ( CASE @reconciled WHEN 1 THEN 5 ELSE JOB_PROCESS_CONTRL END ) 
		  WHERE JOB_NUMBER = @job_number 
			AND JOB_COMPONENT_NBR = @job_component_nbr
			
		 UPDATE dbo.AP_PRODUCTION 
			SET AB_FLAG = 1
		  WHERE JOB_NUMBER = @job_number 
			AND JOB_COMPONENT_NBR = @job_component_nbr 
			AND AR_INV_NBR IS NULL 
			AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL )
			AND (AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0) --MJC 10/02/15 skip non-billable rows

		 UPDATE dbo.EMP_TIME_DTL 
			SET AB_FLAG = 1 
		  WHERE JOB_NUMBER = @job_number 
			AND JOB_COMPONENT_NBR = @job_component_nbr 
			AND AR_INV_NBR IS NULL 
			AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL )
			AND (EMP_NON_BILL_FLAG IS NULL OR EMP_NON_BILL_FLAG = 0) --MJC 10/02/15 skip non-billable rows

		 UPDATE dbo.INCOME_ONLY 
			SET AB_FLAG = 1 
		  WHERE JOB_NUMBER = @job_number 
			AND JOB_COMPONENT_NBR = @job_component_nbr 
			AND AR_INV_NBR IS NULL	
			AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL )								                   	   
		    AND (NON_BILL_FLAG IS NULL OR NON_BILL_FLAG = 0) --MJC 10/02/15 skip non-billable rows

	END	
END

SELECT * FROM @functions
