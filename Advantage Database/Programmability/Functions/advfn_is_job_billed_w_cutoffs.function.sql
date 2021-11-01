--DROP FUNCTION [dbo].[advfn_is_job_billed_w_cutoffs]
CREATE FUNCTION [dbo].[advfn_is_job_billed_w_cutoffs] ( @job_number integer, @job_component_nbr smallint, 
	@et_cutoff smalldatetime, @io_cutoff smalldatetime, @ap_pp_cutoff varchar(8) )
RETURNS bit
AS
BEGIN
	DECLARE @unbilled_count integer
		
	SELECT @unbilled_count = 0
	
	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.AP_PRODUCTION ap
									WHERE ap.JOB_NUMBER = @job_number
									  AND ap.JOB_COMPONENT_NBR = @job_component_nbr
									  AND ( ap.AR_INV_NBR IS NULL OR ap.AR_INV_NBR = 0 ) 
									  AND ( ap.AP_PROD_NOBILL_FLG = 0 OR ap.AP_PROD_NOBILL_FLG IS NULL )
									  AND ( ap.POST_PERIOD <= @ap_pp_cutoff )) 

	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.ADVANCE_BILLING
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL )
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ))

	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.INCOME_REC
									WHERE JOB_NUMBER = @job_number 
									  AND JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ))
		
	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.INCOME_ONLY inco
									WHERE inco.JOB_NUMBER = @job_number 
									  AND inco.JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( inco.AR_INV_NBR IS NULL OR inco.AR_INV_NBR = 0 ) 
									  AND ( inco.NON_BILL_FLAG = 0 OR inco.NON_BILL_FLAG IS NULL )
									  AND ( inco.IO_INV_DATE <= @io_cutoff ))

	IF ( @unbilled_count > 0 )
		RETURN 0
	ELSE	
		SELECT @unbilled_count = ( SELECT COUNT( * )
									 FROM dbo.EMP_TIME_DTL etd
							   INNER JOIN dbo.EMP_TIME et
							           ON et.ET_ID = etd.ET_ID
									WHERE etd.JOB_NUMBER = @job_number 
									  AND etd.JOB_COMPONENT_NBR = @job_component_nbr 
									  AND ( etd.AR_INV_NBR IS NULL OR etd.AR_INV_NBR = 0 ) 
									  AND ( etd.EMP_NON_BILL_FLAG = 0 OR etd.EMP_NON_BILL_FLAG IS NULL )
									  AND ( et.EMP_DATE <= @et_cutoff )
									  AND ( etd.EMP_HOURS > 0 ))

	IF ( @unbilled_count > 0 )
		RETURN 0

RETURN 1
END