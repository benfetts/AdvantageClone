CREATE PROCEDURE advsp_cr_import_select_details @ImportID AS int

AS

SELECT
	[ARInvoiceNumber] = D.AR_INV_NBR,
	[ARInvoiceSequence] = D.AR_INV_SEQ,
	[ClientCode] = C.CL_CODE,
	[ClientName] = C.CL_NAME,
	[PaymentAmount] = D.PAYMENT_AMT,
	[DetailID] = D.ID,
	[AltInvoiceNumber] = D.ALT_INV_NBR
FROM dbo.IMP_CR_DETAIL D
	LEFT OUTER JOIN dbo.ACCT_REC AR ON D.AR_INV_NBR = AR.AR_INV_NBR AND D.AR_INV_SEQ = AR.AR_INV_SEQ AND COALESCE(AR.VOID_FLAG, 0) <> 1
	LEFT OUTER JOIN dbo.CLIENT C ON AR.CL_CODE = C.CL_CODE
WHERE D.IMPORT_ID = @ImportID
GO