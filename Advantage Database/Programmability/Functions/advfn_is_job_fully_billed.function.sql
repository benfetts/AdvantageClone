
CREATE FUNCTION [dbo].[advfn_is_job_fully_billed] ( @job_number integer, @job_component_nbr smallint )
RETURNS bit
AS
BEGIN
	DECLARE @unbilled_count integer
	DECLARE @open_po decimal(18,2)
		
	SELECT @unbilled_count = 0
	
	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.AP_PRODUCTION
									WHERE JOB_NUMBER = @job_number
									  AND JOB_COMPONENT_NBR = @job_component_nbr
									  AND ( AB_FLAG <> 3 )
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
									  AND ( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL ))

	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.ADVANCE_BILLING
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 )
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ))
		
	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.INCOME_ONLY
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 ) 
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
									  AND ( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL ))

	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.EMP_TIME_DTL
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 ) 
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
									  AND ( EMP_NON_BILL_FLAG = 0 OR EMP_NON_BILL_FLAG IS NULL ))

	IF ( @unbilled_count > 0 )
		RETURN 0
	--ELSE	
	--	SELECT @open_po = ( SELECT SUM( ABS( PO_EXT_AMOUNT ))
	--						  FROM dbo.PURCHASE_ORDER_DET POD INNER JOIN dbo.PURCHASE_ORDER PO
	--							ON POD.PO_NUMBER = PO.PO_NUMBER
	--						 WHERE JOB_NUMBER = @job_number 
	--						   AND JOB_COMPONENT_NBR = @job_component_nbr
	--						   AND ( PO.VOID_FLAG IS NULL OR PO.VOID_FLAG = 0 ) 
	--					       AND ( POD.PO_COMPLETE IS NULL OR POD.PO_COMPLETE = 0 )
	--					       AND NOT EXISTS (	SELECT PO_NUMBER 
	--									      	  FROM dbo.AP_PRODUCTION AP
	--											 WHERE AP.PO_NUMBER = POD.PO_NUMBER
	--											   AND AP.PO_LINE_NUMBER = POD.LINE_NUMBER ))

	--IF ( @open_po > 0.00 )
	--	RETURN 0

RETURN 1
END
