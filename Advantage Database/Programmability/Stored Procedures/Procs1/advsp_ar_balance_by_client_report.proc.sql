CREATE PROCEDURE [dbo].[advsp_ar_balance_by_client_report]
		@UserID VARCHAR(100),
		@post_period_to VARCHAR(6),
		@record_source INT
AS
BEGIN

	exec dbo.[advsp_acct_rec_amounts] @UserID, @post_period_to
	
	SELECT	
		[ID] = NEWID(),
		[ARGLAccount], 
		[ClientCode], 
		[ClientDescription], 
		[ClientStatementAddress1], 
		[ClientStatementAddress2], 
		[ClientStatementCityStateZip], 
		[ClientStatementCountry], 
		[ClientBillingAddress1], 
		[ClientBillingAddress2], 
		[ClientBillingCityStateZip], 
		[ClientBillingCountry], 
		[ClientBillingAttention], 
		[ClientARComment], 
		[TotalInvoiceAmount] = SUM([TotalInvoiceAmount]), 
		[CashReceipts] = SUM([CashReceipts]), 
		[CRAdjustments] = SUM([CRAdjustments]), 
		[TotalReceiptsAndAdjustments] = SUM([TotalReceiptsAndAdjustments]), 
		[InvoiceBalance] = SUM([InvoiceBalance]), 
		[OnAccountBalance] = SUM([OnAccountBalance]), 
		[InvoiceBalanceWithOA] = SUM([InvoiceBalanceWithOA]),
		[AbsoluteAmount] = SUM([InvoiceBalanceWithOA]) * CASE WHEN SUM([InvoiceBalanceWithOA]) < 0 THEN -1 ELSE 1 END,
		[DebitOrCredit] = CASE WHEN SUM([InvoiceBalanceWithOA]) < 0 THEN 'Credit' ELSE 'Debit' END,
		[MappedAccount],
		[TargetAccount]
	FROM
		(SELECT 
			[ARGLAccount] = amt.GLACODE,
			[ClientCode] = amt.CL_CODE,
			[ClientDescription] = c.CL_NAME,
			[ClientStatementAddress1] = c.CL_SADDRESS1,
			[ClientStatementAddress2] = c.CL_SADDRESS2, 
			[ClientStatementCityStateZip] = COALESCE((RTRIM(c.CL_CITY) + ' '),'') + COALESCE((RTRIM(c.CL_SSTATE) + ', '),'') + COALESCE((RTRIM(c.CL_SZIP)), ''),
			[ClientStatementCountry] = c.CL_SCOUNTRY,
			[ClientBillingAddress1] = c.CL_BADDRESS1,
			[ClientBillingAddress2] = c.CL_BADDRESS2, 
			[ClientBillingCityStateZip] = COALESCE((RTRIM(c.CL_BCITY) + ' '),'') + COALESCE((RTRIM(c.CL_BSTATE) + ', '),'') + COALESCE((RTRIM(c.CL_BZIP)), ''),
			[ClientBillingCountry] = c.CL_BCOUNTRY,
			[ClientBillingAttention] = c.CL_ATTENTION,
			[ClientARComment] = CONVERT(VARCHAR(MAX), c.CL_AR_COMMENT),
			[CashReceipts] = amt.CR_PAY_AMT,
			[TotalInvoiceAmount] = amt.AR_INV_AMOUNT,
			[CRAdjustments] = amt.CR_ADJ_AMT,
			[TotalReceiptsAndAdjustments] = amt.CR_TOT_AMT,
			[InvoiceBalance] = amt.AR_INV_AMOUNT - amt.CR_TOT_AMT,
			[OnAccountBalance] = amt.CR_OA_AMT,
			[InvoiceBalanceWithOA] = amt.AR_INV_AMOUNT - amt.CR_TOT_AMT + amt.CR_OA_AMT,
			[MappedAccount] = GLAX.SOURCE_GLACODE,
			[TargetAccount] = GLAEX.TARGET_GLACODE
	FROM 
		dbo.ACCT_REC_AMOUNTS AS amt
	LEFT JOIN 
		dbo.GLACCOUNT AS gl ON amt.GLACODE = gl.GLACODE	
	LEFT JOIN 
		dbo.CLIENT AS c ON amt.CL_CODE = c.CL_CODE
	LEFT OUTER JOIN
			(SELECT 
				GLACODE,
				SOURCE_GLACODE
			 FROM 
				[dbo].[GLACCOUNT_XREF] 
			 WHERE
				GLACCOUNT_XREF_ID IN (SELECT MAX(GLACCOUNT_XREF_ID) FROM [dbo].[GLACCOUNT_XREF] WHERE RECORD_SOURCE_ID = @record_source GROUP BY GLACODE)) AS GLAX ON GLAX.GLACODE = amt.GLACODE
		LEFT OUTER JOIN
			(SELECT 
				DTL.GLACODE,
				HDR.TARGET_GLACODE
			 FROM 
				[dbo].[GLACCOUNT_XREF_EXPORT] HDR
			 INNER JOIN	
				[dbo].[GLACCOUNT_XREF_EXPORT_DETAIL] DTL ON HDR.GLACCOUNT_XREF_EXPORT_ID = DTL.GLACCOUNT_XREF_EXPORT_ID  
			 WHERE
				RECORD_SOURCE_ID = @record_source) AS GLAEX ON GLAEX.GLACODE = amt.GLACODE

	WHERE 
		UPPER(amt.[USER_ID]) = UPPER(@UserID)) Dtl
	GROUP BY
		[ARGLAccount],
		[ClientCode],
		[ClientDescription],
		[ClientStatementAddress1],
		[ClientStatementAddress2],
		[ClientStatementCityStateZip],
		[ClientStatementCountry],
		[ClientBillingAddress1],
		[ClientBillingAddress2],
		[ClientBillingCityStateZip],
		[ClientBillingCountry],
		[ClientBillingAttention],
		[ClientARComment],
		[MappedAccount],
		[TargetAccount]

END