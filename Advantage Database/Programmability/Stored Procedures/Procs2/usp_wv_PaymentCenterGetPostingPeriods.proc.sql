IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetPostingPeriods]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetPostingPeriods]
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetPostingPeriods]

AS

BEGIN

SELECT PPPERIOD AS 'PostingPeriodCode', PPGLYEAR + ' - ' + PPDESC AS 'PostingPeriodDescription'
FROM POSTPERIOD WITH (NOLOCK)
WHERE (PPAPCURMTH IS NULL) OR ( NOT (('X' = PPAPCURMTH) AND (PPAPCURMTH IS NOT NULL))) 
ORDER BY PPGLYEAR DESC, PPGLMONTH DESC

END
GO
