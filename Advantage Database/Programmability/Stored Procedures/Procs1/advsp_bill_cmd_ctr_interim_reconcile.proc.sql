CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_interim_reconcile] @job_number integer, @job_component_nbr smallint, 
	@item_id integer, @line_number smallint, @ap_seq smallint, @fnc_code varchar(6), @fnc_type varchar(1), 
	@ab_id integer OUTPUT, @open_net_amt decimal(15,2), @markup_amt decimal(15,2), @state_amt decimal(15,2), 
	@county_amt decimal(15,2), @city_amt decimal(15,2), @nonresale_amt decimal(15,2), @open_amt decimal(15,2), 
	@sales_amt decimal(15,2), @method smallint, @glacode_state varchar(30), @glacode_county varchar(30), 
	@glacode_city varchar(30), @tax_code varchar(4), @bill_date smalldatetime, @billing_user varchar(100),
	@ret_val integer OUTPUT
AS

-- 09/25/15 MJC - changed to try to use an existing AB_ID rather than increment
-- 03/28/16 MJC - when getting the next seq_nbr wrapped with COALESCE to eliminate NULLs
-- 07/25/16 MJC - this stored procedure should not be setting any FINAL flags in Advance Billing commented that out
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
* -11	Job is set up for recognition upon initial billing
*/

DECLARE @seq_nbr int, @ab_max_seq int--, @ir_max_seq smallint
DECLARE @wip_amt decimal(15,2), @glacode_sales varchar(30), @job_ab_flag smallint
DECLARE @job_proc_control smallint, @job_nobill_flag smallint, @ab_flag smallint
DECLARE @job_billing_user varchar(100), @prd_ab_income smallint, @bcc_id integer
DECLARE @est_nbr integer, @est_cmp_nbr smallint, @est_qte_nbr smallint, @est_rev_nbr SMALLINT
DECLARE @bill_hold_count smallint, @pending_count smallint, @final_count smallint
	
SELECT @ret_val = 0

-- MJC 10/15/15 removed - this is always passed now
--IF ( @ret_val = 0 )
--BEGIN
--	IF ( @bill_date IS NULL )
--		SELECT @ret_val = -6
--END

-- MJC 10/15/15 removed
--IF ( @ret_val = 0 )
--BEGIN
--	DECLARE job_cursor CURSOR FOR
--	 SELECT jc.JOB_PROCESS_CONTRL, jc.NOBILL_FLAG, jc.BILLING_USER, ea.ESTIMATE_NUMBER, 
--			ea.EST_COMPONENT_NBR, ea.EST_QUOTE_NBR, ea.EST_REVISION_NBR, jc.PRD_AB_INCOME,
--			jc.AB_FLAG, jc.BCC_ID  
--	   FROM dbo.JOB_COMPONENT jc LEFT OUTER JOIN dbo.ESTIMATE_APPROVAL ea
--	     ON ( jc.JOB_NUMBER = ea.JOB_NUMBER )
--	    AND ( jc.JOB_COMPONENT_NBR = ea.JOB_COMPONENT_NBR ) 
--	  WHERE jc.JOB_NUMBER = @job_number
--	    AND jc.JOB_COMPONENT_NBR = @job_component_nbr
--	  FOR READ ONLY
	
--	OPEN job_cursor

--	FETCH job_cursor INTO @job_proc_control, @job_nobill_flag, @job_billing_user, @est_nbr, @est_cmp_nbr,
--		@est_qte_nbr, @est_rev_nbr, @prd_ab_income, @job_ab_flag, @bcc_id 
	
--	IF ( @@FETCH_STATUS = 0 )
--	BEGIN
--		-- BJL 09/25/09 - Check the nonbillable status, billing selection status and job process control
--		-- MJC 10/05/15 removed
--		--IF( @job_nobill_flag = 1 )
--		--	SELECT @ret_val = -2

--		-- MJC 10/15/15 removed
--		--IF @job_proc_control NOT IN	( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
--		--	SELECT @ret_val = -3
			
--		--IF ( @job_billing_user IS NOT NULL ) AND ( @job_billing_user <> @billing_user )
--		--	SELECT @ret_val = -5
		
--		--IF ( @prd_ab_income = 2 )
--		--	SELECT @ret_val = -11
--	END	
	
--	CLOSE job_cursor
--	DEALLOCATE job_cursor	
--END

--IF ( @ret_val = 0 )
--BEGIN
--	SELECT @final_count = ( SELECT COUNT(*) 
--	                          FROM dbo.ADVANCE_BILLING 
--	                         WHERE ( ( AB_FLAG = 3 ) OR 
--								   ( ( AR_INV_NBR IS NULL ) AND ( AB_FLAG IN ( 4, 5 )) ) OR 
--								   ( ( AR_INV_NBR IS NOT NULL ) AND ( AB_FLAG IN ( 4, 5 )) AND ( AR_INV_VOID IS NULL OR AR_INV_VOID = 0 ) ) )
--							   AND JOB_NUMBER = @job_number
--							   AND JOB_COMPONENT_NBR = @job_component_nbr )
 
--	IF ( @final_count > 0 )
--		SELECT @ret_val = -7
	
--END

--IF ( @ret_val = 0 )
--BEGIN
--	SELECT @bill_hold_count = ( SELECT COUNT(*) 
--								  FROM dbo.JOB_COMPONENT
--								 WHERE JOB_NUMBER = @job_number
--								   AND JOB_COMPONENT_NBR = @job_component_nbr
--								   AND JOB_BILL_HOLD = 2 )
		
--	IF ( @bill_hold_count = 0 )
--		SELECT @bill_hold_count = ( SELECT COUNT(*)
--									  FROM dbo.AP_PRODUCTION
--									 WHERE JOB_NUMBER = @job_number
--									   AND JOB_COMPONENT_NBR = @job_component_nbr
--									   AND AP_PROD_BILL_HOLD = 2 )
--	ELSE
--		SELECT @ret_val = -4
		
--	IF ( @bill_hold_count = 0 )	
--		SELECT @bill_hold_count = ( SELECT COUNT(*)
--									  FROM dbo.EMP_TIME_DTL 
--									 WHERE JOB_NUMBER = @job_number
--									   AND JOB_COMPONENT_NBR = @job_component_nbr
--									   AND BILL_HOLD_FLG = 2 )
--	ELSE
--		SELECT @ret_val = -4

--	IF ( @bill_hold_count = 0 )		
--		SELECT @bill_hold_count = ( SELECT COUNT(*)
--									  FROM dbo.INCOME_ONLY
--									 WHERE JOB_NUMBER = @job_number
--									   AND JOB_COMPONENT_NBR = @job_component_nbr
--									   AND BILL_HOLD_FLAG = 2 )
--	ELSE
--		SELECT @ret_val = -4
--END

--IF ( @ret_val = 0 )
--BEGIN
--	-- Check to see if anything is pending
--	SELECT @pending_count = ( SELECT COUNT(*) 
--								FROM dbo.ADVANCE_BILLING ab INNER JOIN dbo.JOB_COMPONENT jc
--								  ON ( ab.JOB_NUMBER = jc.JOB_NUMBER )
--								 AND ( ab.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
--								 AND ( ab.BCC_ID IS NULL OR ab.BCC_ID <> jc.BCC_ID )
--							   WHERE ab.JOB_NUMBER = @job_number
--								 AND ab.JOB_COMPONENT_NBR = @job_component_nbr
--								 AND ( ab.AB_FLAG <> 3 )
--								 AND ( ab.AR_INV_NBR IS NULL ))
 
--	IF ( @pending_count > 0 )
--		SELECT @ret_val = -9
	
--END

--IF ( @ret_val = 0 )
--BEGIN
--	-- Check to see if anything is pending
--	SELECT @pending_count = ( SELECT COUNT(*) 
--								FROM dbo.INCOME_REC ir INNER JOIN dbo.JOB_COMPONENT jc
--								  ON ( ir.JOB_NUMBER = jc.JOB_NUMBER )
--								 AND ( ir.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
--								 AND ( ir.BCC_ID IS NULL OR ir.BCC_ID <> jc.BCC_ID ) 
--							   WHERE ir.JOB_NUMBER = @job_number
--								 AND ir.JOB_COMPONENT_NBR = @job_component_nbr
--								 AND ( ir.AB_FLAG <> 3 )
--								 AND ( ir.AR_INV_NBR IS NULL ))
 
--	IF ( @pending_count > 0 )
--		SELECT @ret_val = -9
	
--END

IF ( @ret_val = 0 )
BEGIN
	-- If the AB_ID is null, get the next ID
	IF ( @ab_id IS NULL )
	BEGIN
		-- MJC 09/25/15 - use existing AB_ID if possible
		SELECT @ab_id = [dbo].[advfn_bcc_get_advance_billing_id] (@job_number, @job_component_nbr)

		IF @ab_id = 0
		BEGIN
			EXECUTE dbo.advsp_get_next_nbr @column_name = 'AB_ID', @next_nbr = @ab_id OUTPUT
			SELECT @seq_nbr = 1
		END
	END
	IF @seq_nbr IS NULL
	BEGIN
		-- Get the next seq number
		-- 03/28/16 MJC - when getting the next seq_nbr wrapped with COALESCE to eliminate NULLs
		SELECT @seq_nbr = ( SELECT COALESCE(MAX( SEQ_NBR ), 0)
							  FROM dbo.ADVANCE_BILLING 
							 WHERE AB_ID = @ab_id )
							  
		--SELECT @ir_max_seq = ( SELECT COALESCE(MAX( SEQ_NBR ), 0)
		--						 FROM dbo.INCOME_REC 
		--						WHERE AB_ID = @ab_id )
		
		--IF( @ir_max_seq > @seq_nbr )
		--	SELECT @seq_nbr = @ir_max_seq
			
		SELECT @seq_nbr = @seq_nbr + 1	
			
	END
END

IF ( @ret_val = 0 )
BEGIN
	IF ( @fnc_type = 'V' )
		SELECT @wip_amt = -( COALESCE( @open_net_amt, 0.00 ) + COALESCE( @nonresale_amt, 0.00 ))
		
	SELECT @glacode_sales = ( SELECT PGLACODE_DEF_SALES 
								FROM dbo.JOB_LOG jl INNER JOIN dbo.OFFICE o 
								  ON jl.OFFICE_CODE = o.OFFICE_CODE
							   WHERE JOB_NUMBER = @job_number )
	
	SELECT @ret_val = @@ERROR
		                           	  
	IF ( @state_amt IS NULL AND @county_amt IS NULL AND @city_amt IS NULL )
		SELECT @tax_code = NULL

	IF ( @state_amt = 0.00 OR @state_amt IS NULL )
		SELECT @glacode_state = NULL

	IF ( @county_amt = 0.00 OR @county_amt IS NULL )
		SELECT @glacode_county = NULL

	IF ( @city_amt = 0.00 OR @city_amt IS NULL )
		SELECT @glacode_city = NULL
END

-- MJC 10/15/15 - removed - these will already be set!
--IF ( @ret_val = 0 )
--BEGIN
--	IF ( @fnc_type = 'V' )
--		UPDATE dbo.AP_PRODUCTION 
--   		   SET AB_FLAG = 6
-- 		 WHERE AP_ID = @item_id 
--   		   AND LINE_NUMBER = @line_number 
--   		   AND AP_SEQ = @ap_seq

--	IF ( @fnc_type = 'E' )
--		UPDATE dbo.EMP_TIME_DTL 
--   		   SET AB_FLAG = 6
-- 		 WHERE ET_ID = @item_id 
--   		   AND SEQ_NBR = @line_number
	   	   
--	IF ( @fnc_type = 'I' )
--		UPDATE dbo.INCOME_ONLY 
--   		   SET AB_FLAG = 6
-- 		 WHERE IO_ID = @item_id 
--   		   AND SEQ_NBR = @line_number
   		   
--	SELECT @ret_val = @@ERROR   		   
--END

IF ( @ret_val = 0 )
BEGIN
	SELECT @method = ( SELECT TOP 1 CALC_METHOD 
						 FROM dbo.ADVANCE_BILLING 
						WHERE JOB_NUMBER = @job_number
						  AND JOB_COMPONENT_NBR = @job_component_nbr
						  AND ( AR_INV_VOID IS NULL OR AR_INV_VOID = 0 )
					 ORDER BY AB_ID DESC, SEQ_NBR DESC )

	SELECT @ret_val = @@ERROR					 
END

IF ( @ret_val = 0 )
BEGIN
	INSERT INTO dbo.ADVANCE_BILLING ( 
				AB_ID, SEQ_NBR, FNC_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, ADV_BILL_NET_AMT, CREATE_DATE, 
				ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, EST_REVISION_NBR, FNC_TYPE, 
				GLACODE_CITY, GLACODE_CNTY, GLACODE_STATE, GLACODE_SALES, TAX_CODE, [USER_ID], AB_FLAG, 
				CALC_METHOD, LINE_TOTAL, EXT_MARKUP_AMT, EXT_STATE_RESALE, EXT_COUNTY_RESALE, 
				EXT_CITY_RESALE, EXT_NONRESALE_TAX, BILL_DATE, BCC_ID ) 
	   VALUES ( @ab_id, @seq_nbr, @fnc_code, @job_number, @job_component_nbr, -( @open_net_amt ), 
				CONVERT( varchar(10), GETDATE(), 101 ), @est_nbr, @est_cmp_nbr, @est_qte_nbr, @est_rev_nbr,
				@fnc_type, @glacode_city, @glacode_county, @glacode_state, @glacode_sales, @tax_code,
				@billing_user, 6, @method, -( @open_amt ), -( @markup_amt ), -( @state_amt ), 
				-( @county_amt ), -( @city_amt ), -( @nonresale_amt ), @bill_date, @bcc_id )
				
	SELECT @ret_val = @@ERROR				
END

-- 07/25/16 MJC - this stored procedure should not be setting any FINAL flags in Advance Billing commented that out
--IF ( @ret_val = 0 )
--BEGIN	   
--	 UPDATE dbo.ADVANCE_BILLING 
--		SET FINAL_AB_ID = @ab_id, 
--			FINAL_SEQ_NBR = @seq_nbr, 
--			FINAL_DATE = CONVERT( varchar(10), GETDATE(), 101 ), 
--			FINAL_USER = @billing_user 
--	  WHERE AB_ID = @item_id 
--		AND SEQ_NBR = @line_number
		
--	SELECT @ret_val = @@ERROR
--END
