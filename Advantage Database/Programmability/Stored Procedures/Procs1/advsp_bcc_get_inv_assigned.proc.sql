CREATE PROCEDURE [dbo].[advsp_bcc_get_inv_assigned] @bill_user_in varchar(100)
AS

SET NOCOUNT ON

SELECT
	[ARInvoiceNumber] = ar.AR_INV_NBR,
	[ARInvoiceSequence] = ar.AR_INV_SEQ,
	[ARInvoiceDate] = ar.AR_INV_DATE,
	[ARInvoiceAmount] = ar.AR_INV_AMOUNT,
	[CurrencyCode] = ar.CURRENCY_CODE,
	[CurrencyRate] = ar.CURRENCY_RATE,
	[CurrencyAmount] = CASE WHEN ar.EXCHANGE_AMOUNT IS NOT NULL THEN ar.AR_INV_AMOUNT + ar.EXCHANGE_AMOUNT ELSE NULL END,
	[RecordType] = CASE ar.REC_TYPE
					WHEN 'P' THEN 'Production'
					WHEN 'N' THEN 'Newspaper'
					WHEN 'M' THEN 'Magazine'
					WHEN 'I' THEN 'Internet'
					WHEN 'O' THEN 'Out of Home'
					WHEN 'R' THEN 'Radio'
					WHEN 'T' THEN 'TV'
					WHEN 'C' THEN 'Combo'
					END,
	[AssignBy] = ar.AR_DESCRIPTION
FROM dbo.ACCT_REC ar 
	INNER JOIN dbo.BILLING b ON ( b.BILLING_USER = @bill_user_in ) AND ( b.INV_ASSIGN = 1 )
WHERE ( ar.AR_INV_NBR BETWEEN b.FIRST_INV AND b.LAST_INV )
AND ( ar.AR_TYPE = 'IN' )
AND ( ar.AR_INV_SEQ <> 99 )
ORDER BY ar.AR_INV_NBR, ar.AR_INV_SEQ, ar.AR_INV_DATE

GO


