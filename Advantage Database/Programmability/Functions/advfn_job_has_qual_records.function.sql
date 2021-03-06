
CREATE FUNCTION [dbo].[advfn_job_has_qual_records] ( @job_number integer, @job_component_nbr smallint,
	 @et_cutoff smalldatetime, @io_cutoff smalldatetime, @ap_pp_cutoff varchar(8) )
RETURNS bit
AS
BEGIN
	DECLARE @unbilled_count integer, @est_appr integer
	DECLARE @open_po decimal(18,2), @ab_job smallint
		
	SELECT @unbilled_count = 0
	
	SELECT @ab_job = ( SELECT COUNT(*)
	                     FROM dbo.JOB_COMPONENT
	                    WHERE JOB_NUMBER = @job_number
	                      AND JOB_COMPONENT_NBR = @job_component_nbr
	                      AND ( AB_FLAG <> 0 AND AB_FLAG IS NOT NULL ))	
		
	IF ( @ab_job > 0 )
		RETURN 1 
	ELSE
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.AP_PRODUCTION
									WHERE JOB_NUMBER = @job_number
									  AND JOB_COMPONENT_NBR = @job_component_nbr
									  AND ( AB_FLAG <> 3 )
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
									  AND ( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL )
									  AND ( POST_PERIOD <= @ap_pp_cutoff ))

	IF ( @unbilled_count > 0 )
		RETURN 1
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.ADVANCE_BILLING
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 )
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ))
		
	IF ( @unbilled_count > 0 )
		RETURN 1
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.INCOME_ONLY
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 ) 
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
									  AND ( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL )
									  AND ( IO_INV_DATE <= @io_cutoff ))

	IF ( @unbilled_count > 0 )
		RETURN 1
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.EMP_TIME_DTL
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 ) 
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
									  AND ( EMP_NON_BILL_FLAG = 0 OR EMP_NON_BILL_FLAG IS NULL )
									  AND EXISTS ( SELECT *  
													 FROM dbo.EMP_TIME et 
													WHERE et.ET_ID = dbo.EMP_TIME_DTL.ET_ID 
													  AND et.EMP_DATE <= @et_cutoff ))

	IF ( @unbilled_count > 0 )
		RETURN 1
	ELSE	
		SELECT @open_po = ( SELECT SUM( ABS( PO_EXT_AMOUNT ))
							  FROM dbo.PURCHASE_ORDER_DET POD INNER JOIN dbo.PURCHASE_ORDER PO
								ON POD.PO_NUMBER = PO.PO_NUMBER
							 WHERE JOB_NUMBER = @job_number 
							   AND JOB_COMPONENT_NBR = @job_component_nbr
							   AND ( PO.VOID_FLAG IS NULL OR PO.VOID_FLAG = 0 ) 
						       AND ( POD.PO_COMPLETE IS NULL OR POD.PO_COMPLETE = 0 )
						       AND NOT EXISTS (	SELECT PO_NUMBER 
										      	  FROM dbo.AP_PRODUCTION AP
												 WHERE AP.PO_NUMBER = POD.PO_NUMBER
												   AND AP.PO_LINE_NUMBER = POD.LINE_NUMBER ))

	IF ( @open_po > 0.00 )
		RETURN 1
	ELSE
		SELECT @est_appr = ( SELECT COUNT( * ) 
							   FROM dbo.ESTIMATE_APPROVAL
							  WHERE JOB_NUMBER = @job_number 
							    AND JOB_COMPONENT_NBR = @job_component_nbr )
	IF ( @est_appr > 0 )
		RETURN 1

RETURN 0
END
