CREATE PROCEDURE [dbo].[advsp_clientcashreceipt_import_batch_report] @batch_name varchar(50)

AS

BEGIN
	
	SET NOCOUNT ON
	
	SELECT
			GLTransaction = H.GLEXACT,
			ClientCashReceiptID = H.REC_ID,
			ClientCashReceiptSequenceNumber = H.SEQ_NBR,
			[Status] = 'New Check',
			CheckNumber = H.CR_CHECK_NBR,
			CheckDate = H.CR_CHECK_DATE,
			CheckAmount = H.CR_CHECK_AMT,
			DepositDate = H.CR_DEP_DATE,
			PostPeriodCode = GL.GLEHPP,
			Client = C.CL_CODE + ' - ' + COALESCE(C.CL_NAME,''),
			Bank = B.BK_CODE + ' - ' + COALESCE(B.BK_DESCRIPTION,''),
			CashAccount = G.GLACODE + ' - ' + COALESCE(G.GLADESC,''),
			Office = O.OFFICE_CODE + ' - ' + COALESCE(O.OFFICE_NAME,''),
			BankCode = B.BK_CODE,
			CashAccountCode = G.GLACODE,
			PaymentTypeDescription = PT.[DESCRIPTION]
		FROM
			[dbo].CR_CLIENT H
				INNER JOIN [dbo].CLIENT C ON H.CL_CODE = C.CL_CODE 
				INNER JOIN [dbo].BANK B ON H.BK_CODE = B.BK_CODE 
				INNER JOIN [dbo].GLACCOUNT G ON H.GLACODE = G.GLACODE 
				INNER JOIN [dbo].OFFICE O ON H.OFFICE_CODE = O.OFFICE_CODE 
				INNER JOIN [dbo].GLENTHDR GL ON H.GLEXACT = GL.GLEHXACT
				LEFT OUTER JOIN [dbo].CR_PAYMENT_TYPE PT ON H.CR_PAYMENT_TYPE_ID = PT.CR_PAYMENT_TYPE_ID
		WHERE
			H.BATCH_NAME = @batch_name 
		ORDER BY GLTransaction 
END
GO
