
CREATE FUNCTION [dbo].[advfn_get_prod_sel_amt] ( @job_number integer, @job_component_nbr smallint )
RETURNS decimal(18,2)
AS
BEGIN
	DECLARE @et_amt decimal(15,2), @io_amt decimal(15,2), @ap_amt decimal(15,2), @ab_amt decimal(15,2)

	SELECT @et_amt = (  COALESCE(( SELECT SUM( LINE_TOTAL ) 
									 FROM dbo.EMP_TIME_DTL
									WHERE JOB_NUMBER = @job_number
									  AND JOB_COMPONENT_NBR = @job_component_nbr
									  AND ( BILL_HOLD_FLG IS NULL OR BILL_HOLD_FLG = 0 )
									  AND BILLING_USER IS NOT NULL ), 0.00 ))
	   
	SELECT @io_amt = (  COALESCE(( SELECT SUM( LINE_TOTAL ) 
									 FROM dbo.INCOME_ONLY
									WHERE JOB_NUMBER = @job_number
									  AND JOB_COMPONENT_NBR = @job_component_nbr
									  AND ( BILL_HOLD_FLAG IS NULL OR BILL_HOLD_FLAG = 0 )
									  AND BILLING_USER IS NOT NULL ), 0.00 ))
	   
	SELECT @ap_amt = (  COALESCE(( SELECT SUM( LINE_TOTAL ) 
									 FROM dbo.AP_PRODUCTION
									WHERE JOB_NUMBER = @job_number
									  AND JOB_COMPONENT_NBR = @job_component_nbr
									  AND ( AP_PROD_BILL_HOLD IS NULL OR AP_PROD_BILL_HOLD = 0 ) 
									  AND BILLING_USER IS NOT NULL ), 0.00 ))   
	   
	SELECT @ab_amt = (  COALESCE(( SELECT SUM( LINE_TOTAL )
									 FROM dbo.ADVANCE_BILLING ab
									WHERE JOB_NUMBER = @job_number
									  AND JOB_COMPONENT_NBR = @job_component_nbr
									  AND BILLING_USER IS NOT NULL ), 0.00 ))
	   
RETURN ( @et_amt + @io_amt + @ap_amt + @ab_amt )
END
