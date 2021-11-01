CREATE PROC advsp_bcc_get_transfer_to_jobs @BillingUser as varchar(100), @ClientCode as varchar(6) = NULL, @DivisionCode as varchar(6) = NULL, @ProductCode as varchar(6) = NULL

AS

SELECT DISTINCT [Number] = JL.JOB_NUMBER, 
				[Description] = JL.JOB_DESC 
FROM JOB_LOG JL
	INNER JOIN JOB_COMPONENT JC ON JL.JOB_NUMBER = JC.JOB_NUMBER AND COALESCE(JC.AB_FLAG, 0) IN (0,2) AND (JC.BILLING_USER IS NULL OR JC.BILLING_USER = @BillingUser) 
								AND (JC.JOB_PROCESS_CONTRL <> 6 AND JC.JOB_PROCESS_CONTRL <> 12)
WHERE JL.SC_CODE IS NOT NULL
AND (@ClientCode IS NULL OR JL.CL_CODE = @ClientCode)
AND (@DivisionCode IS NULL OR JL.DIV_CODE = @DivisionCode)
AND (@ProductCode IS NULL OR JL.PRD_CODE = @ProductCode)
ORDER BY JL.JOB_NUMBER DESC
GO
