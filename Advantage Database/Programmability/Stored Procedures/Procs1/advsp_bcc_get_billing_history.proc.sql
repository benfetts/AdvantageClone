CREATE PROCEDURE [dbo].[advsp_bcc_get_billing_history] @JobNumber int, @JobComponentNumber smallint

AS

SELECT
	[InvoiceNumber],
	[InvoiceType],
	[InvoiceDate],
	[PostingPeriod],
	SUM([HoursBilled]) AS [Hours],
	SUM([QTYBilled]) AS [QTY],
	SUM([Actual]) AS [Actual],
	SUM([AdvanceAmount]) AS [AdvanceAmount],
	SUM(COALESCE([RetainedAdvanceBilling],0)) AS RetainedAdvanceBilling,
	SUM([Actual] + [AdvanceAmount] + COALESCE([RetainedAdvanceBilling],0)) AS [Amount],
	SUM([ResaleTax]) AS [ResaleTax],
	SUM([InvoiceTotal]) AS [InvoiceTotal],
	SUM([IncomeRecognized]) AS IncomeRecognized,
	[HasDocuments],
	[ReconciledMethod] = method.METHOD_DESC,
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
		[HoursBilled] = CASE WHEN ARS.FNC_TYPE = 'E' THEN ARS.HRS_QTY ELSE NULL END,
		[QTYBilled] = CASE WHEN ARS.FNC_TYPE = 'I' OR ARS.FNC_TYPE = 'V' THEN ARS.HRS_QTY ELSE NULL END,
		[Actual] = COALESCE(ARS.EMP_TIME_AMT,0) + COALESCE(ARS.INC_ONLY_AMT,0) + COALESCE(ARS.COST_AMT,0) + COALESCE(ARS.NON_RESALE_AMT,0) + COALESCE(ARS.COMMISSION_AMT,0),
		[AdvanceAmount] = COALESCE(ARS.AB_COST_AMT,0) + COALESCE(ARS.AB_INC_AMT,0) + COALESCE(ARS.AB_COMMISSION_AMT,0) + COALESCE(ARS.AB_NONRESALE_AMT,0),
		[ResaleTax] = COALESCE(ARS.CITY_TAX_AMT,0) + COALESCE(ARS.CNTY_TAX_AMT,0) + COALESCE(ARS.STATE_TAX_AMT,0),
		[InvoiceTotal] = COALESCE(ARS.TOTAL_BILL,0),
		[RetainedAdvanceBilling] = CASE WHEN ARS.FNC_TYPE IS NULL OR ARS.FNC_TYPE <> 'R' THEN COALESCE(ARS.AB_SALE_AMT,0) ELSE NULL END,
		[IncomeRecognized] = CASE WHEN ARS.FNC_TYPE = 'R' THEN COALESCE(ARS.AB_SALE_AMT,0) ELSE NULL END,
		[HasDocuments] = CAST(CASE WHEN (SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = AR.AR_INV_NBR) = 0 THEN 0 ELSE 1 END AS bit),
		[GLTransaction] = ARS.GL_XACT,
		CurrencyCode = ARS.CURRENCY_CODE,
		CurrencyRate = ARS.CURRENCY_RATE,
		CurrencyAmount = CAST(CASE WHEN ARS.CURRENCY_RATE IS NOT NULL THEN ARS.CURRENCY_RATE * ARS.TOTAL_BILL ELSE 0 END as DECIMAL(15,2))
	FROM dbo.AR_SUMMARY ARS
		LEFT OUTER JOIN dbo.ACCT_REC AR ON ARS.AR_INV_NBR = AR.AR_INV_NBR AND ARS.AR_INV_SEQ = AR.AR_INV_SEQ AND ARS.AR_TYPE = AR.AR_TYPE
	WHERE
			ARS.JOB_NUMBER = @JobNumber
	AND		ARS.JOB_COMPONENT_NBR = @JobComponentNumber
	AND		ARS.AR_INV_SEQ <> 99) tablea
	LEFT OUTER JOIN (
					SELECT MAX(METHOD_DESC) AS METHOD_DESC, AR_INV_NBR 
					FROM dbo.ADVANCE_BILLING 
					WHERE FINAL_AB_ID IS NOT NULL
					AND JOB_NUMBER = @JobNumber
					AND JOB_COMPONENT_NBR = @JobComponentNumber
					GROUP BY AR_INV_NBR 
					) method ON tablea.InvoiceNumber = method.AR_INV_NBR
GROUP BY
	InvoiceNumber, InvoiceType, InvoiceDate, PostingPeriod, HasDocuments, method.METHOD_DESC, GLTransaction, CurrencyCode, CurrencyRate
ORDER BY InvoiceNumber 
GO