CREATE PROCEDURE [dbo].[advsp_bcc_get_media_billing_history]

	@OrderNumber int, @LineNumbers varchar(max)

AS

SELECT
	[InvoiceNumber],
	[InvoiceType],
	[InvoiceDate],
	[PostingPeriod],
	SUM([Amount]) AS [Amount],
	SUM([ResaleTax]) AS [ResaleTax],
	SUM([InvoiceTotal]) AS [InvoiceTotal],
	[HasDocuments],
	[GLTransaction],
	CurrencyCode,
	CurrencyRate,
	SUM(CurrencyAmount) AS CurrencyAmount
FROM (
	SELECT
		[InvoiceNumber] = ARS.AR_INV_NBR,
		[InvoiceType] = ARS.AR_TYPE,
		[InvoiceDate] = AR.AR_INV_DATE,
		[PostingPeriod] = AR.AR_POST_PERIOD,
		[Amount] = COALESCE(ARS.COST_AMT,0) + COALESCE(ARS.NON_RESALE_AMT,0) + COALESCE(ARS.COMMISSION_AMT,0),
		[ResaleTax] = COALESCE(ARS.CITY_TAX_AMT,0) + COALESCE(ARS.CNTY_TAX_AMT,0) + COALESCE(ARS.STATE_TAX_AMT,0),
		[InvoiceTotal] = COALESCE(ARS.TOTAL_BILL,0),
		[HasDocuments] = CAST(CASE WHEN (SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = AR.AR_INV_NBR) = 0 THEN 0 ELSE 1 END AS bit),
		[GLTransaction] = ARS.GL_XACT,
		CurrencyCode = ARS.CURRENCY_CODE,
		CurrencyRate = ARS.CURRENCY_RATE,
		CurrencyAmount = CAST(CASE WHEN ARS.CURRENCY_RATE IS NOT NULL THEN ARS.CURRENCY_RATE * ARS.TOTAL_BILL ELSE 0 END as DECIMAL(15,2))
	FROM dbo.AR_SUMMARY ARS
		LEFT OUTER JOIN dbo.ACCT_REC AR ON ARS.AR_INV_NBR = AR.AR_INV_NBR AND ARS.AR_INV_SEQ = AR.AR_INV_SEQ AND ARS.AR_TYPE = AR.AR_TYPE
	WHERE
			ARS.ORDER_NBR = @OrderNumber
	AND		ARS.ORDER_LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))) tablea
GROUP BY
	InvoiceNumber, InvoiceType, InvoiceDate, PostingPeriod, HasDocuments, GLTransaction, CurrencyCode, CurrencyRate
ORDER BY InvoiceNumber 
GO