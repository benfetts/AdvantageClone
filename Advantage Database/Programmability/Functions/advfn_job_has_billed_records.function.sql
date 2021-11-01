
CREATE FUNCTION [dbo].[advfn_job_has_billed_records] ( @job_number integer, @job_component_nbr smallint )
RETURNS bit
AS
BEGIN
	DECLARE @billed_count integer
		
	SELECT @billed_count = 0
	
	IF ( @billed_count > 0 )
		RETURN 1
	ELSE
		SELECT @billed_count = (   SELECT COUNT( * )
									 FROM dbo.AP_PRODUCTION
									WHERE JOB_NUMBER = @job_number
									  AND JOB_COMPONENT_NBR = @job_component_nbr
									  AND ( AB_FLAG <> 3 )
									  AND ( AR_INV_NBR IS NOT NULL ) 
									  AND ( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL ))

	IF ( @billed_count > 0 )
		RETURN 1
	ELSE	
		SELECT @billed_count = (   SELECT COUNT( * )
									 FROM dbo.ADVANCE_BILLING
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 )
									  AND ( AR_INV_NBR IS NOT NULL ))
		
	IF ( @billed_count > 0 )
		RETURN 1
	ELSE	
		SELECT @billed_count = (   SELECT COUNT( * )
									 FROM dbo.INCOME_ONLY
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 ) 
									  AND ( AR_INV_NBR IS NOT NULL ) 
									  AND ( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL ))

	IF ( @billed_count > 0 )
		RETURN 1
	ELSE	
		SELECT @billed_count = (   SELECT COUNT( * )
									 FROM dbo.EMP_TIME_DTL
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 ) 
									  AND ( AR_INV_NBR IS NOT NULL ) 
									  AND ( EMP_NON_BILL_FLAG = 0 OR EMP_NON_BILL_FLAG IS NULL ))

RETURN 0
END
