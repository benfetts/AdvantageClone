CREATE FUNCTION [dbo].[advfn_bcc_get_advance_billing_id] (@JobNumber int, @JobComponentNumber smallint)
RETURNS int
AS
BEGIN
	DECLARE @AB_ID int
	
	SELECT @AB_ID = COALESCE(MAX(ABIDS.MAXID), 0)
	FROM (
		SELECT MAX(AB_ID) AS MAXID
		FROM dbo.ADVANCE_BILLING
		WHERE JOB_NUMBER = @JobNumber
		AND JOB_COMPONENT_NBR = @JobComponentNumber 
		AND	(AR_INV_VOID IS NULL OR AR_INV_VOID = 0)
		AND	FINAL_AB_ID IS NULL
		UNION
		SELECT MAX(AB_ID) 
		FROM dbo.INCOME_REC 
		WHERE JOB_NUMBER = @JobNumber
		AND JOB_COMPONENT_NBR = @JobComponentNumber 
		AND	(AR_INV_VOID IS NULL OR AR_INV_VOID = 0)
		AND	FINAL_FLAG IS NULL
		) ABIDS
		
	RETURN @AB_ID 
	
END