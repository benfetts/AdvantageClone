CREATE PROCEDURE [dbo].[advsp_bill_hold] 
	@job_number integer, @job_component_nbr smallint, @billing_user varchar(100), @hold_action smallint, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @orig_bill_hold smallint, @bcc_id integer 

SELECT @ret_val = 0

SELECT @bcc_id = ( SELECT BCC_ID FROM dbo.BILLING_CMD_CENTER WHERE BILLING_USER = @billing_user )

SELECT	@orig_bill_hold = jc.JOB_BILL_HOLD 
FROM	dbo.JOB_COMPONENT jc 
WHERE	jc.JOB_NUMBER = @job_number
AND		jc.JOB_COMPONENT_NBR = @job_component_nbr
	
IF ( @hold_action = -1 ) OR ( @hold_action > 0 AND @orig_bill_hold > 0 AND @hold_action <> @orig_bill_hold )
BEGIN
	IF( @ret_val = 0 )	
	BEGIN
		UPDATE dbo.AP_PRODUCTION 
		   SET AP_PROD_BILL_HOLD = 0 
		 WHERE JOB_NUMBER = @job_number 
		   AND JOB_COMPONENT_NBR = @job_component_nbr
		   
		SELECT @ret_val = @@ERROR
	END	

	IF( @ret_val = 0 )	   
	BEGIN	   
		UPDATE dbo.EMP_TIME_DTL 
		   SET BILL_HOLD_FLG = 0 
		 WHERE JOB_NUMBER = @job_number
		   AND JOB_COMPONENT_NBR = @job_component_nbr

		SELECT @ret_val = @@ERROR
	END
		   
	IF( @ret_val = 0 )	   
	BEGIN	   
		UPDATE dbo.INCOME_ONLY 
		   SET BILL_HOLD_FLAG = 0 
		 WHERE JOB_NUMBER = @job_number 
		   AND JOB_COMPONENT_NBR = @job_component_nbr
	   
		SELECT @ret_val = @@ERROR
	END
	
	IF( @ret_val = 0 )	   
	BEGIN	   
		UPDATE dbo.JOB_COMPONENT 
		   SET JOB_BILL_HOLD = 0 
		 WHERE JOB_NUMBER = @job_number
		   AND JOB_COMPONENT_NBR = @job_component_nbr
		
		SELECT @ret_val = @@ERROR
	END

END	   

IF ( @hold_action > 0 AND ( @hold_action <> @orig_bill_hold OR @orig_bill_hold IS NULL ))
BEGIN
	IF( @ret_val = 0 )	
	BEGIN
		UPDATE dbo.AP_PRODUCTION 
	       SET AP_PROD_BILL_HOLD = @hold_action
	     WHERE JOB_NUMBER = @job_number 
	       AND JOB_COMPONENT_NBR = @job_component_nbr 
	       AND ( AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0 )
	       AND AR_INV_NBR IS NULL
	       AND BCC_ID = @bcc_id  
		   
		SELECT @ret_val = @@ERROR
	END	

	IF( @ret_val = 0 )	   
	BEGIN	   
		UPDATE dbo.EMP_TIME_DTL 
	       SET BILL_HOLD_FLG = @hold_action
	     WHERE JOB_NUMBER = @job_number 
	       AND JOB_COMPONENT_NBR = @job_component_nbr 
		   AND ( EMP_NON_BILL_FLAG IS NULL OR EMP_NON_BILL_FLAG = 0 ) 
	       AND AR_INV_NBR IS NULL
	       AND BCC_ID = @bcc_id 
				
		SELECT @ret_val = @@ERROR
	END
		   
	IF( @ret_val = 0 )	   
	BEGIN	   
		UPDATE dbo.INCOME_ONLY 
		   SET BILL_HOLD_FLAG = @hold_action
	     WHERE JOB_NUMBER = @job_number 
		   AND JOB_COMPONENT_NBR = @job_component_nbr 
		   AND ( BILL_HOLD_FLAG IS NULL OR BILL_HOLD_FLAG = 0 )
	       AND AR_INV_NBR IS NULL
	       AND BCC_ID = @bcc_id 
	    	   
		SELECT @ret_val = @@ERROR
	END
	
	IF( @ret_val = 0 )	   
	BEGIN	   
		UPDATE dbo.JOB_COMPONENT 
		   SET JOB_BILL_HOLD = @hold_action 
		 WHERE JOB_NUMBER = @job_number
		   AND JOB_COMPONENT_NBR = @job_component_nbr
		   AND BCC_ID = @bcc_id
		    
		SELECT @ret_val = @@ERROR
	END
	
END	   
