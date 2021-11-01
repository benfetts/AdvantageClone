CREATE FUNCTION [dbo].[advfn_bcc_is_job_closeable] ( @job_number integer, @job_component_nbr smallint )
RETURNS bit
AS
BEGIN
	DECLARE @amt decimal(20,2)
	
	IF ( SELECT COALESCE(AB_FLAG, 0) FROM dbo.JOB_COMPONENT WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr ) > 0 
		RETURN 0
	ELSE
		SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
						FROM dbo.AP_PRODUCTION
						WHERE JOB_NUMBER = @job_number
						AND JOB_COMPONENT_NBR = @job_component_nbr
						AND ( AB_FLAG <> 3 )
						AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
						AND ( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL ))

	IF ( @amt > 0 )
		RETURN 0
	ELSE	
		SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
						FROM dbo.ADVANCE_BILLING
						WHERE JOB_NUMBER = @job_number 
						AND JOB_COMPONENT_NBR = @job_component_nbr 
						AND ( AB_FLAG <> 3 )
						AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ))
		
	IF ( @amt > 0 )
		RETURN 0
	ELSE	
		SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
						FROM dbo.INCOME_ONLY
						WHERE JOB_NUMBER = @job_number 
						AND JOB_COMPONENT_NBR = @job_component_nbr 
						AND ( AB_FLAG <> 3 ) 
						AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
						AND ( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL ))

	IF ( @amt > 0 )
		RETURN 0
	ELSE	
		SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
						FROM dbo.EMP_TIME_DTL
						WHERE JOB_NUMBER = @job_number 
						AND JOB_COMPONENT_NBR = @job_component_nbr 
						AND ( AB_FLAG <> 3 ) 
						AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
						AND ( EMP_NON_BILL_FLAG = 0 OR EMP_NON_BILL_FLAG IS NULL ))

	IF ( @amt > 0 )
		RETURN 0
	ELSE
		IF EXISTS(
                    SELECT COALESCE(SUM(AP_PROD_EXT_AMT),0) as APTotal, dtl.PO_NUMBER, dtl.LINE_NUMBER, dtl.POTotal
			        FROM 
				        (SELECT  SUM(PO_EXT_AMOUNT) POTotal, PO.PO_NUMBER, POD.LINE_NUMBER
				        FROM dbo.PURCHASE_ORDER_DET POD
					        INNER JOIN dbo.PURCHASE_ORDER PO ON PO.PO_NUMBER = POD.PO_NUMBER 
				        WHERE JOB_NUMBER = @job_number
				        AND JOB_COMPONENT_NBR = @job_component_nbr
				        AND ( PO.VOID_FLAG IS NULL OR PO.VOID_FLAG = 0 ) 
				        AND ( POD.PO_COMPLETE IS NULL OR POD.PO_COMPLETE = 0 )
				        GROUP BY PO.PO_NUMBER, POD.LINE_NUMBER) dtl
					        LEFT OUTER JOIN dbo.AP_PRODUCTION p ON p.PO_NUMBER = dtl.PO_NUMBER AND p.PO_LINE_NUMBER = dtl.LINE_NUMBER 
			        GROUP BY dtl.PO_NUMBER, dtl.LINE_NUMBER, dtl.POTotal
			        HAVING POTotal > COALESCE(SUM(AP_PROD_EXT_AMT),0))
		RETURN 0

	IF EXISTS(SELECT 1 
				FROM dbo.AP_PRODUCTION a
					INNER JOIN dbo.FUNCTIONS b ON a.FNC_CODE = b.FNC_CODE AND b.FNC_TYPE = 'V'
				WHERE JOB_NUMBER = @job_number
				AND JOB_COMPONENT_NBR = @job_component_nbr
				AND COALESCE(AP_PROD_NOBILL_FLG, 0) = 0
				AND AR_INV_NBR IS NULL)
		RETURN 0

RETURN 1
END

GO


