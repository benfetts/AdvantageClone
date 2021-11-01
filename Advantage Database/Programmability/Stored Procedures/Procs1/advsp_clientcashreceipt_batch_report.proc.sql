CREATE PROCEDURE [dbo].[advsp_clientcashreceipt_batch_report] @user_code varchar(100), @from_date smalldatetime, @to_date smalldatetime, @is_batch int

AS

BEGIN
	
	SET NOCOUNT ON
	
	DECLARE @TRANSACTIONS TABLE (
		GLEHXACT int NOT NULL,
		GLEHDESC varchar(100)
	)
	
	DECLARE @HEADER_RECORDS TABLE (
		REC_ID int NOT NULL,
		SEQ_NBR smallint NOT NULL,
		GLEHDESC varchar(100),
		GLEHXACT int NOT NULL
	)
	
	INSERT @TRANSACTIONS
	SELECT
		GLEHXACT, GLEHDESC 
	FROM
		[dbo].GLENTHDR
	WHERE
		UPPER(GLEHUSER) = UPPER(@user_code)
	AND	GLEHSOURCE = 'CR'
	AND	
		((@is_batch = 0 AND GLEHENTDATE between @from_date and @to_date)
		OR
		(@is_batch = 1 AND BATCH_DATE = @from_date))
	
	INSERT @HEADER_RECORDS 
	SELECT REC_ID, MAX(SEQ_NBR), GLEHDESC, GLEHXACT 
	FROM
		(SELECT REC_ID, SEQ_NBR, T.GLEHDESC, T.GLEHXACT 
		FROM [dbo].CR_CLIENT CC
			INNER JOIN @TRANSACTIONS T ON CC.GLEXACT = T.GLEHXACT 
		UNION
		SELECT REC_ID, SEQ_NBR, T.GLEHDESC, T.GLEHXACT 
		FROM [dbo].CR_ON_ACCT COA
			INNER JOIN @TRANSACTIONS T ON COA.GLEXACT = T.GLEHXACT
		UNION
		SELECT REC_ID, SEQ_NBR, T.GLEHDESC, T.GLEHXACT 
		FROM dbo.CR_CLIENT_DTL CCD
			INNER JOIN @TRANSACTIONS T ON CCD.GLEXACT = T.GLEHXACT
		) records
	GROUP BY REC_ID, GLEHDESC, GLEHXACT
	
	SELECT
			GLTransaction = HR.GLEHXACT,
			ClientCashReceiptID = H.REC_ID,
			ClientCashReceiptSequenceNumber = H.SEQ_NBR,
			[Status] = CASE WHEN CHARINDEX('Modify Check', HR.GLEHDESC) <> 0 THEN 'Modified Check'
							WHEN CHARINDEX('Reverse Check', HR.GLEHDESC) <> 0 THEN 'Check Reversal'
			                ELSE 'New Check' END,
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
				INNER JOIN @HEADER_RECORDS HR ON HR.REC_ID = H.REC_ID AND HR.SEQ_NBR = H.SEQ_NBR 
				INNER JOIN [dbo].CLIENT C ON H.CL_CODE = C.CL_CODE 
				INNER JOIN [dbo].BANK B ON H.BK_CODE = B.BK_CODE 
				INNER JOIN [dbo].GLACCOUNT G ON H.GLACODE = G.GLACODE 
				INNER JOIN [dbo].OFFICE O ON H.OFFICE_CODE = O.OFFICE_CODE 
				INNER JOIN [dbo].GLENTHDR GL ON H.GLEXACT = GL.GLEHXACT
				LEFT OUTER JOIN [dbo].CR_PAYMENT_TYPE PT ON H.CR_PAYMENT_TYPE_ID = PT.CR_PAYMENT_TYPE_ID
		ORDER BY GLTransaction 
END
GO
