CREATE PROC advsp_bcc_select_billing_approval_batches @IncludeFinished bit

AS

SET NOCOUNT ON;
-- MJC 08/02/2106 Webvantage batches not being marked as finished when some jobs are placed on bill hold
IF ( @IncludeFinished = 1 )
	SELECT
		[ID] = BA_BATCH_ID,
		[Description] = BA_BATCH_DESC
	FROM dbo.BILL_APPR_BATCH BAB
	WHERE
			APPROVED = 1
	AND		EXISTS( SELECT * FROM dbo.BILL_APPR WHERE BA_BATCH_ID = BA_BATCH_ID )
	AND		EXISTS( SELECT 1 FROM dbo.BILL_APPR_BATCH bab
  							LEFT OUTER JOIN dbo.BILL_APPR ba ON ( bab.BA_BATCH_ID = ba.BA_BATCH_ID )
  							LEFT OUTER JOIN dbo.BILL_APPR_HDR bah ON ( ba.BA_ID = bah.BA_ID )
  							WHERE bab.BA_BATCH_ID = BAB.BA_BATCH_ID AND bah.PROCESSED = 0 )
	ORDER BY BA_BATCH_ID DESC
ELSE
	SELECT
		[ID] = BA_BATCH_ID,
		[Description] = BA_BATCH_DESC
	FROM dbo.BILL_APPR_BATCH BAB
	WHERE
			APPROVED = 1
	AND		FINISHED = 0
	AND		EXISTS( SELECT * FROM dbo.BILL_APPR WHERE BA_BATCH_ID = BA_BATCH_ID )
	AND		EXISTS( SELECT 1 FROM dbo.BILL_APPR_BATCH bab
  							LEFT OUTER JOIN dbo.BILL_APPR ba ON ( bab.BA_BATCH_ID = ba.BA_BATCH_ID )
  							LEFT OUTER JOIN dbo.BILL_APPR_HDR bah ON ( ba.BA_ID = bah.BA_ID )
  							WHERE bab.BA_BATCH_ID = BAB.BA_BATCH_ID AND bah.PROCESSED = 0 )
  	ORDER BY BA_BATCH_ID DESC
GO
