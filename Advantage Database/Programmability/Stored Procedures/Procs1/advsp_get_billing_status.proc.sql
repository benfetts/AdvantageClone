CREATE PROCEDURE [dbo].[advsp_get_billing_status] @bill_user_in varchar(100)
AS

SET NOCOUNT ON

SELECT
	[IsAssigned] = COALESCE( INV_ASSIGN, 0 ),
	[IsPrinted] = COALESCE( INV_PRINT, 0 ),
	[IsProcessed] = INV_PROCESSED,
	[IsCoopSaved] = COOP_SAVED,
	[HasCoopJobs] = CAST(CASE WHEN (
						SELECT COUNT(1)
						FROM dbo.W_AR_FUNCTION 
						WHERE AR_INV_SEQ = 99
						AND JOB_NUMBER IS NOT NULL
						AND BILLING_USER = @bill_user_in) > 0 THEN 1 
					ELSE 0 END as bit)
FROM dbo.BILLING 
WHERE BILLING_USER = @bill_user_in