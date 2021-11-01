CREATE PROCEDURE [dbo].[advsp_othercashreceipt_batch_report] @user_code varchar(100), @from_date smalldatetime, @to_date smalldatetime, @is_batch int

AS

BEGIN

	SET NOCOUNT ON
	
	DECLARE @TRANSACTIONS TABLE (
		GLEHXACT	int NOT NULL,
		GLEHDESC	varchar(100),
		REC_ID		int NOT NULL,
		SEQ_NBR		smallint NOT NULL
	)
	
	INSERT @TRANSACTIONS
	SELECT GH.GLEHXACT, GH.GLEHDESC, recs.REC_ID, recs.SEQ_NBR
	FROM
		(
		SELECT REC_ID, SEQ_NBR, GLEXACT
		FROM dbo.CR_OTHER_DTL
		UNION
		SELECT REC_ID, SEQ_NBR, GLEXACT
		FROM dbo.CR_OTHER
		) recs
		INNER JOIN [dbo].GLENTHDR GH ON recs.GLEXACT = GH.GLEHXACT
	WHERE
		UPPER(GH.GLEHUSER) = UPPER(@user_code)
	AND	GH.GLEHSOURCE = 'OR'
	AND	
		(
		(@is_batch = 0 AND GH.GLEHENTDATE between @from_date and @to_date)
		OR
		(@is_batch = 1 AND GH.BATCH_DATE = @from_date)
		)
	
	SELECT
			GLTransaction = T.GLEHXACT,
			OtherCashReceiptID = T.REC_ID,
			OtherCashReceiptSequenceNumber = T.SEQ_NBR,
			[Description] = H.CR_DESC,
			[Status] = CASE WHEN SUBSTRING(T.GLEHDESC, 1, 6) = 'Check:' THEN 'New Check'
							WHEN SUBSTRING(T.GLEHDESC, 1, 13) = 'Modify Check:' THEN 'Modified Check'
							WHEN SUBSTRING(T.GLEHDESC, 1, 15) = 'Check Reversal:' THEN 'Check Reversal'
			                ELSE '' END,
			CheckNumber = H.CR_CHECK_NBR,
			CheckDate = H.CR_CHECK_DATE,
			CheckAmount = H.CR_CHECK_AMT,
			DepositDate = H.CR_DEP_DATE,
			PostPeriodCode = GL.GLEHPP,
			Bank = B.BK_CODE + ' - ' + COALESCE(B.BK_DESCRIPTION,''),
			CashAccount = G.GLACODE + ' - ' + COALESCE(G.GLADESC,''),
			Office = O.OFFICE_CODE + ' - ' + COALESCE(O.OFFICE_NAME,''),
			BankCode = B.BK_CODE,
			CashAccountCode = G.GLACODE,
			PaymentTypeDescription = PT.[DESCRIPTION]
		FROM
			[dbo].CR_OTHER H
				INNER JOIN @TRANSACTIONS T ON T.REC_ID = H.REC_ID AND T.SEQ_NBR = H.SEQ_NBR 
				INNER JOIN [dbo].BANK B ON H.BK_CODE = B.BK_CODE 
				INNER JOIN [dbo].GLACCOUNT G ON H.GLACODE = G.GLACODE 
				INNER JOIN [dbo].OFFICE O ON H.OFFICE_CODE = O.OFFICE_CODE 
				INNER JOIN [dbo].GLENTHDR GL ON H.GLEXACT = GL.GLEHXACT 
				LEFT OUTER JOIN [dbo].CR_PAYMENT_TYPE PT ON H.CR_PAYMENT_TYPE_ID = PT.CR_PAYMENT_TYPE_ID
END
GO
