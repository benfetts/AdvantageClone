
CREATE PROCEDURE [dbo].[sp_ar_invoice_dates] 
AS
BEGIN
	SET NOCOUNT ON;

	CREATE TABLE #ar_invoice_dates(
		[AR_INV_NBR] int NOT NULL,
		[AR_TYPE] varchar(3) NULL,
		[AR_POST_PERIOD] varchar(6) NULL,
		[AR_INV_DATE] smalldatetime NULL)

	INSERT INTO #ar_invoice_dates
	SELECT ar.AR_INV_NBR,
		ar.AR_TYPE,
		ar.AR_POST_PERIOD,
		ar.AR_INV_DATE
	FROM dbo.ACCT_REC ar
	GROUP BY 
		ar.AR_INV_NBR,
		ar.AR_TYPE,
		ar.AR_POST_PERIOD,
		ar.AR_INV_DATE
END

SELECT * FROM #ar_invoice_dates
