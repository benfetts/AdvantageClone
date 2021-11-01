
CREATE PROCEDURE [dbo].[advsp_clear_temp_bill_hold] @bcc_id_in integer, @preserve bit, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

-- Set the job hold flag to 3 as a temporary marker so that the detail can be remarked later
-- or clear all
IF ( @preserve = 1 )
	 UPDATE dbo.JOB_COMPONENT
		SET JOB_BILL_HOLD = 3
	  WHERE ( JOB_BILL_HOLD = 0 OR JOB_BILL_HOLD IS NULL )
		AND BCC_ID = @bcc_id_in 
		AND EXISTS (
					SELECT ap.JOB_NUMBER, ap.JOB_COMPONENT_NBR 
					FROM dbo.AP_PRODUCTION ap 
					WHERE ap.AP_PROD_BILL_HOLD = 1
					AND ap.BCC_ID = @bcc_id_in 
					UNION
					SELECT etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR 
					FROM dbo.EMP_TIME_DTL etd 
					WHERE etd.BILL_HOLD_FLG = 1
					AND etd.BCC_ID = @bcc_id_in
					UNION
					SELECT ico.JOB_NUMBER, ico.JOB_COMPONENT_NBR 
					FROM dbo.INCOME_ONLY ico 
					WHERE ico.BILL_HOLD_FLAG = 1
					AND ico.BCC_ID = @bcc_id_in
					)
ELSE
BEGIN
	-- Clear header hold flags
	 UPDATE dbo.JOB_COMPONENT
		SET JOB_BILL_HOLD = 0
	  WHERE JOB_BILL_HOLD IN ( 1, 3 ) 
		AND BCC_ID = @bcc_id_in 
		                
	-- Clear the detail level flags		                
	 UPDATE dbo.AP_PRODUCTION
		SET AP_PROD_BILL_HOLD = 0
	  WHERE BCC_ID = @bcc_id_in 
		AND AP_PROD_BILL_HOLD = 1

	 UPDATE dbo.EMP_TIME_DTL
		SET BILL_HOLD_FLG = 0
	  WHERE BCC_ID = @bcc_id_in 
		AND BILL_HOLD_FLG = 1

	 UPDATE dbo.INCOME_ONLY
		SET BILL_HOLD_FLAG = 0
	  WHERE BCC_ID = @bcc_id_in 
		AND BILL_HOLD_FLAG = 1
END	
