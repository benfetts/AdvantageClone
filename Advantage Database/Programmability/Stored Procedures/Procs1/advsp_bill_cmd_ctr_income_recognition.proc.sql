
CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_income_recognition] @job_number integer, @job_component_nbr smallint, @billing_user varchar(100), 
	@bill_date smalldatetime, @ab_balance_amt decimal(15,2), @recognition_amt decimal(15,2), @ret_val integer OUTPUT
AS

SET NOCOUNT ON

/* @ret_val Values
*  -1	There is nothing to recognize for this job
*  -2	Job is not billable
*  -3	Job process control does not allow income recognition
*  -4	Job is on bill hold
*  -5	Job is selected for billing by another user 
*  -6	Billing date not specified
*  -7	Reconciliation is finalized for this job
*  -9	Advance billing is pending for this job
* -10	This is not an advance billed job
* -11	Job is set up for recognition upon initial billing
* -12	Job has no advance bill balance amount
*/

DECLARE @seq_nbr int, @ab_max_seq int, @job_ab_flag smallint
DECLARE @wip_amt decimal(15,2), @glacode_def_sales varchar(30), @glacode_sales varchar(30)
DECLARE @job_proc_control smallint, @job_nobill_flag smallint, @ab_flag smallint
DECLARE @job_billing_user varchar(100), @prd_ab_income smallint, @ab_id integer
DECLARE @bcc_id integer, @bill_hold smallint, @pending_count smallint, @final_count smallint
	
SELECT @ret_val = 0

IF ( @ret_val = 0 )
BEGIN
	IF ( @bill_date IS NULL )
		SELECT @ret_val = -6
END

IF ( @ret_val = 0 )
BEGIN
	IF ( @recognition_amt IS NULL OR @recognition_amt = 0.00 )
		SELECT @ret_val = -1
	ELSE
	BEGIN	
		IF ( @ab_balance_amt = 0.00 OR @ab_balance_amt IS NULL )
			SELECT @ret_val = -12
	END			
END

IF ( @ret_val = 0 )
BEGIN
	DECLARE job_cursor CURSOR FOR
	 SELECT JOB_PROCESS_CONTRL, NOBILL_FLAG, BILLING_USER, 
			PRD_AB_INCOME, AB_FLAG, JOB_BILL_HOLD, BCC_ID  
	   FROM dbo.JOB_COMPONENT
	  WHERE JOB_NUMBER = @job_number
	    AND JOB_COMPONENT_NBR = @job_component_nbr
	  FOR READ ONLY
	
	OPEN job_cursor

	FETCH job_cursor INTO @job_proc_control, @job_nobill_flag, @job_billing_user, @prd_ab_income, @job_ab_flag, @bill_hold, @bcc_id 
	
	IF ( @@FETCH_STATUS = 0 )
	BEGIN
		-- BJL 09/25/09 - Check the nonbillable status, billing selection status and job process control
		IF( @job_nobill_flag = 1 )
			SELECT @ret_val = -2
			
		IF ( @ret_val = 0 ) AND ( @job_proc_control NOT IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ))
			SELECT @ret_val = -3
			
		IF ( @ret_val = 0 ) AND ( @bill_hold = 2 ) 
			SELECT @ret_val = -4	

		IF ( @ret_val = 0 ) AND ( @job_billing_user IS NOT NULL ) AND ( @job_billing_user <> @billing_user )
			SELECT @ret_val = -5
		
		IF ( @ret_val = 0 ) AND ( @prd_ab_income IS NULL OR @prd_ab_income <> 1 )
			SELECT @ret_val = -11
			
		IF ( @ret_val = 0 ) AND ( @job_ab_flag NOT IN ( 1, 2 ) OR @job_ab_flag IS NULL )
			SELECT @ret_val = -10
	END	
	
	CLOSE job_cursor
	DEALLOCATE job_cursor	
END

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
	-- Check to see if anything is pending
	SELECT @pending_count = ( SELECT COUNT(*) 
								FROM dbo.ADVANCE_BILLING ab INNER JOIN dbo.JOB_COMPONENT jc
								  ON ( ab.JOB_NUMBER = jc.JOB_NUMBER )
								 AND ( ab.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
								 AND ( ab.BCC_ID IS NULL OR ab.BCC_ID <> jc.BCC_ID )
							   WHERE ab.JOB_NUMBER = @job_number
								 AND ab.JOB_COMPONENT_NBR = @job_component_nbr
								 AND ( ab.AB_FLAG <> 3 )
								 AND ( ab.AR_INV_NBR IS NULL ))
 
	IF ( @pending_count > 0 )
		SELECT @ret_val = -9
	
END

IF ( @ret_val = 0 )
BEGIN
	-- Check to see if anything is pending
	SELECT @pending_count = ( SELECT COUNT(*) 
								FROM dbo.INCOME_REC ir INNER JOIN dbo.JOB_COMPONENT jc
								  ON ( ir.JOB_NUMBER = jc.JOB_NUMBER )
								 AND ( ir.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
								 AND ( ir.BCC_ID IS NULL OR ir.BCC_ID <> jc.BCC_ID ) 
							   WHERE ir.JOB_NUMBER = @job_number
								 AND ir.JOB_COMPONENT_NBR = @job_component_nbr
								 AND ( ir.AB_FLAG <> 3 )
								 AND ( ir.AR_INV_NBR IS NULL ))
 
	IF ( @pending_count > 0 )
		SELECT @ret_val = -9
	
END

IF ( @ret_val = 0 )
BEGIN
	-- If the AB_ID is null, get the next ID
	IF ( @ab_id IS NULL )
	BEGIN
		EXECUTE dbo.advsp_get_next_nbr @column_name = 'AB_ID', @next_nbr = @ab_id OUTPUT
		SELECT @seq_nbr = 1
	END
	ELSE
	BEGIN
		-- Get the next seq number
		--SELECT @seq_nbr = ( SELECT MAX( SEQ_NBR )
		--					  FROM dbo.ADVANCE_BILLING 
		--					 WHERE AB_ID = @ab_id )
							  
		SELECT @seq_nbr = ( SELECT MAX( SEQ_NBR )
								 FROM dbo.INCOME_REC 
								WHERE AB_ID = @ab_id )
		
		IF @seq_nbr IS NULL
			SET @seq_nbr = 0

		SELECT @seq_nbr = @seq_nbr + 1	
			
	END
END

IF ( @ret_val = 0 )
BEGIN

	SELECT @glacode_sales = ( SELECT COALESCE( osa.PGLACODE_SALES, o.PGLACODE_SALES ) 
								FROM dbo.JOB_LOG jl 
						  INNER JOIN dbo.OFFICE o 
								  ON ( jl.OFFICE_CODE = o.OFFICE_CODE )
					 LEFT OUTER JOIN dbo.OFF_SC_ACCTS osa 
								  ON ( jl.OFFICE_CODE = osa.OFFICE_CODE )
								 AND ( jl.SC_CODE = osa.SC_CODE ) 
							   WHERE JOB_NUMBER = @job_number )
	
	SELECT @ret_val = @@ERROR

	SELECT @glacode_def_sales = ( SELECT PGLACODE_DEF_SALES 
									FROM dbo.JOB_LOG jl 
							  INNER JOIN dbo.OFFICE o 
									  ON ( jl.OFFICE_CODE = o.OFFICE_CODE )
								   WHERE JOB_NUMBER = @job_number )
								   
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	INSERT INTO dbo.INCOME_REC (
				AB_ID, SEQ_NBR, JOB_NUMBER, JOB_COMPONENT_NBR, CREATE_DATE, [USER_ID], 
				AB_FLAG, BILL_DATE, REC_AMT, GLACODE_SALES, GLACODE_DEF_SALES, BCC_ID ) 
		VALUES( @ab_id, @seq_nbr, @job_number, @job_component_nbr, getdate( ), @billing_user, 
				6, @bill_date, @recognition_amt, @glacode_sales, @glacode_def_sales, @bcc_id )

	SELECT @ret_val = @@ERROR				
END
