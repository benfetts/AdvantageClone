if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_ap_invoice_with_balance_aging_report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_ap_invoice_with_balance_aging_report]
GO


CREATE PROCEDURE [dbo].[advsp_ap_invoice_with_balance_aging_report] 
	@post_period_from varchar(6), 
	@post_period_to varchar(6),
	@aging_date smalldatetime, 
	@open_ap_only bit, 
	@aging_option_invoice_date bit,
	@record_source int
AS

BEGIN

DECLARE @APIDS TABLE  (
	AP_ID int NOT NULL,
	AP_SEQ int NULL,
	HDR_REC bit,
	POST_PERIOD_MIN varchar(6) NULL,
	POST_PERIOD_MAX varchar(6) NULL
)

DECLARE @payments TABLE (
	[AP_ID] int,
	[TotalPaid] decimal(14, 2),
	[DiscountTaken] decimal(14, 2),
	[VendorServiceTax] decimal(14, 2)
	)

DECLARE @client_amount TABLE (
	[SUM_NET_AMT] decimal(14, 2),
	[AP_ID] int
	)

SET NOCOUNT ON;

INSERT @APIDS
SELECT AP_ID, MIN(AP_SEQ), 1, MIN(POST_PERIOD), MAX(POST_PERIOD)
FROM dbo.AP_HEADER H
WHERE H.POST_PERIOD BETWEEN @post_period_from AND @post_period_to 
GROUP BY AP_ID

INSERT INTO @payments (AP_ID, TotalPaid, DiscountTaken, VendorServiceTax)
SELECT	A.AP_ID,
		[TotalPaid] = SUM(COALESCE(AP_CHK_AMT, 0)),
		[DiscountAmount] = SUM(COALESCE(AP_DISC_AMT,0)),
		[VendorServiceTax] = SUM(COALESCE(VENDOR_SERVICE_TAX,0))		
FROM dbo.AP_PMT_HIST A
WHERE A.POST_PERIOD BETWEEN @post_period_from AND @post_period_to  --<= @post_period_to 	
GROUP BY A.AP_ID

/* PJH 12/28/2020 - Only populate FROM AP_HEADER WHERE POST_PERIOD BETWEEN @post_period_from AND @post_period_to */
--INSERT @APIDS
--SELECT A.AP_ID, 0, 0, NULL, NULL
--FROM @payments A LEFT JOIN @APIDS B ON A.AP_ID = B.AP_ID
--WHERE B.AP_ID IS NULL AND TotalPaid <> 0

/* HDR_REC = 0 - Non Header source (i.e. payments) */

INSERT INTO @client_amount
SELECT SUM(NET) AS SUM_NET_AMT, AP_ID
FROM (
		-- PJH 03/23/2020 - added  WHERE POST_PERIOD BETWEEN @post_period_from AND @post_period_to
		SELECT SUM(COALESCE(NET_AMT, 0) + COALESCE(DISCOUNT_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, A.AP_ID
		FROM dbo.AP_INTERNET A JOIN @APIDS B ON A.AP_ID = B.AP_ID WHERE (B.HDR_REC = 0 OR POST_PERIOD BETWEEN @post_period_from AND @post_period_to)
		GROUP BY A.AP_ID UNION ALL

		SELECT SUM(COALESCE(DISBURSED_AMT, 0)) AS NET, A.AP_ID
		FROM dbo.AP_MAGAZINE A JOIN @APIDS B ON A.AP_ID = B.AP_ID WHERE (B.HDR_REC = 0 OR POST_PERIOD BETWEEN @post_period_from AND @post_period_to)
		GROUP BY A.AP_ID UNION ALL

		SELECT SUM(COALESCE(DISBURSED_AMT, 0)) AS NET, A.AP_ID
		FROM dbo.AP_NEWSPAPER A JOIN @APIDS B ON A.AP_ID = B.AP_ID WHERE (B.HDR_REC = 0 OR POST_PERIOD BETWEEN @post_period_from AND @post_period_to)
		GROUP BY A.AP_ID UNION ALL

		SELECT SUM(COALESCE(NET_AMT, 0) + COALESCE(DISCOUNT_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, A.AP_ID
		FROM dbo.AP_OUTDOOR A JOIN @APIDS B ON A.AP_ID = B.AP_ID WHERE (B.HDR_REC = 0 OR POST_PERIOD BETWEEN @post_period_from AND @post_period_to)
		GROUP BY A.AP_ID UNION ALL

		SELECT SUM(COALESCE(EXT_NET_AMT, 0) + COALESCE(DISC_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, A.AP_ID
		FROM dbo.AP_RADIO A JOIN @APIDS B ON A.AP_ID = B.AP_ID WHERE (B.HDR_REC = 0 OR POST_PERIOD BETWEEN @post_period_from AND @post_period_to)
		GROUP BY A.AP_ID UNION ALL

		SELECT SUM(COALESCE(EXT_NET_AMT, 0) + COALESCE(DISC_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, A.AP_ID
		FROM dbo.AP_TV A JOIN @APIDS B ON A.AP_ID = B.AP_ID WHERE (B.HDR_REC = 0 OR POST_PERIOD BETWEEN @post_period_from AND @post_period_to)
		GROUP BY A.AP_ID UNION ALL

		SELECT SUM(COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0)) AS NET, A.AP_ID
		FROM dbo.AP_PRODUCTION A JOIN @APIDS B ON A.AP_ID = B.AP_ID WHERE (B.HDR_REC = 0 OR POST_PERIOD BETWEEN @post_period_from AND @post_period_to)
		GROUP BY A.AP_ID

	) ClientTotal
GROUP BY AP_ID

SELECT 
	[ID] = NEWID(),
	[VendorCode],
	[VendorName],
	[VendorAddress1],
	[VendorAddress2],
	[VendorAddress3],
	[VendorCity],
	[VendorCounty],
	[VendorState],
	[VendorZip],
	[VendorCountry],
	[VendorPhone],
	[VendorPhoneExt],
	[VendorFaxNumber],
	[VendorFaxExt],
	[VendorEmail],
	[VendorPayToCode],
	[VendorPayToName],
	[VendorPayToAddress1],
	[VendorPayToAddress2],
	[VendorPayToAddress3],
	[VendorPayToCity],
	[VendorPayToCounty],
	[VendorPayToState],
	[VendorPayToZip],
	[VendorPayToCountry],
	[VendorPayToPhone],
	[VendorPayToPhoneExt],
	[VendorPayToFax],
	[VendorPayToFaxExt],
	[VendorPayToEmail],
	[VendorDefaultCategory],
	[VendorOfficeCode],
	[VendorOfficeName],
	[VendorVCCStatus],
	[VendorBankCode],
	[VendorBankName],
	[VendorSpecialTerms],
	[VendorNotes],
	[VendorServiceTaxCode] ,
	[VendorServiceTaxDescription],
	[EmployeeVendor],
	[SubjectToVST],
	[APIdentifier],
	[APType],
	[InvoiceNumber],
	[APDescription],
	[EntryDate],
	[PostedToSummary],
	[InvoiceDate],
	[DateToPay],
	[PostingPeriod],
	[InvoiceAmount],
	[TaxAmount],
	[APTotalAmount],
	[DiscountPercentage],
	[DiscountAmount],
	[APTotalDue],
	[DisbursedClientTotal],
	[DisbursedNonClientTotal],
	[VendorTermsCode],
	[VendorTermsDesc],
	[APGLXact],
	[APGLSequenceNumber],
	[APGLAccountCode],
	[APGLAccountDescription],
	[MappedAccount],
	[TargetAccount],
	[CurrencyCode],
	[CurrencyDescription],
	[CurrencyRate],
	[ExchangeGLAccountCode],
	[ExchangeGLAccountDescription],
	[OnPaymentHold],
	[Is1099Invoice],
	[PaidToVendor],
	[VendorServiceTaxAmount],
	[TotalPaidToVendor],
	[BalanceDue],
	[DiscountTaken],
	[LastCheckNumber],
	[LastCheckDate],
	[APTotalDueUnpaid],
	[AbsoluteAmount] = [APTotalDueUnpaid] * CASE WHEN [APTotalDueUnpaid] < 0 THEN -1 ELSE 1 END,
	[DebitOrCredit] = CASE WHEN [APTotalDueUnpaid] > 0 THEN 'Credit' ELSE 'Debit' END,
	[Age],
	[APTotalDueUnpaidCurrent] = CASE WHEN [Age] <= 0 THEN [APTotalDueUnpaid] ELSE CAST(0 AS decimal(16,2)) END,
	[APTotalDueUnpaid1to30Days] = CASE WHEN [Age] >= 1 AND [Age] <= 30 THEN [APTotalDueUnpaid] ELSE CAST(0 AS decimal(16,2)) END,
	[APTotalDueUnpaid31to60Days] = CASE WHEN [Age] >= 31 AND [Age] <= 60 THEN [APTotalDueUnpaid] ELSE CAST(0 AS decimal(16,2)) END,
	[APTotalDueUnpaid61to90Days] = CASE WHEN [Age] >= 61 AND [Age] <= 90 THEN [APTotalDueUnpaid] ELSE CAST(0 AS decimal(16,2)) END,
	[APTotalDueUnpaid91to120Days] = CASE WHEN [Age] >= 91 AND [Age] <= 120 THEN [APTotalDueUnpaid] ELSE CAST(0 AS decimal(16,2)) END,
	[APTotalDueUnpaid120PlusDays] = CASE WHEN [Age] >= 121 THEN [APTotalDueUnpaid] ELSE CAST(0 AS decimal(16,2)) END,
	[DaysToPayment]
FROM (
	SELECT
			[ID] = NEWID(),
			[VendorCode] = H.VN_FRL_EMP_CODE,
			[VendorName],
			[VendorAddress1],
			[VendorAddress2],
			[VendorAddress3],
			[VendorCity],
			[VendorCounty],
			[VendorState],
			[VendorZip],
			[VendorCountry],
			[VendorPhone],
			[VendorPhoneExt],
			[VendorFaxNumber],
			[VendorFaxExt],
			[VendorEmail],
			[VendorPayToCode],
			[VendorPayToName],
			[VendorPayToAddress1],
			[VendorPayToAddress2],
			[VendorPayToAddress3],
			[VendorPayToCity],
			[VendorPayToCounty],
			[VendorPayToState],
			[VendorPayToZip],
			[VendorPayToCountry],
			[VendorPayToPhone],
			[VendorPayToPhoneExt],
			[VendorPayToFax],
			[VendorPayToFaxExt],
			[VendorPayToEmail],
			[VendorDefaultCategory],
			[VendorOfficeCode],
			[VendorOfficeName],
			[VendorVCCStatus],
			[VendorBankCode],
			[VendorBankName],
			[VendorSpecialTerms],
			[VendorNotes],
			[VendorServiceTaxCode] = VST.CODE,
			[VendorServiceTaxDescription] = VST.[DESCRIPTION],
			[EmployeeVendor] = CASE WHEN EMP_VENDOR = 1 THEN 'Yes' ELSE 'No' END,
			[SubjectToVST] = CASE WHEN ISNULL(H.SERVICE_TAX_ENABLED,0) = 0 THEN 'No' ELSE 'Yes' END,
			[APIdentifier] = H.AP_ID,
			[APType] = CASE WHEN EMP_VENDOR = 1 THEN 'E' ELSE H.AP_TYPE END,
			[InvoiceNumber] = H.AP_INV_VCHR,
			[APDescription] = H.AP_DESC,
			[EntryDate] = H.CREATE_DATE,
			[InvoiceDate] = H.AP_INV_DATE,
			[DateToPay] = H.AP_DATE_PAY,
			[PostingPeriod] = H.POST_PERIOD,
			[InvoiceAmount] = CAST(COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) AS decimal(16,2)),
			[TaxAmount] = CAST(COALESCE(H.AP_SALES_TAX, 0) AS decimal(16,2)),
			[APTotalAmount] = CAST(COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0) AS decimal(16,2)),
			[DiscountPercentage] = H.AP_DISC_PCT,
			[DiscountAmount] = CASE WHEN @aging_date <= H.AP_DATE_PAY THEN CAST((COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)) * COALESCE(H.AP_DISC_PCT, 0) / 100 AS decimal(16,2))
									ELSE 0 END,
			[APTotalDue] = CASE WHEN @aging_date <= H.AP_DATE_PAY THEN CAST((COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)) - ((COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)) * COALESCE(H.AP_DISC_PCT, 0) / 100) AS decimal(16,2))
								ELSE CAST((COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)) as decimal(16,2)) END,
			[DisbursedClientTotal] = CAST(COALESCE(Client.SUM_NET_AMT, 0) AS decimal(16,2)),
			[DisbursedNonClientTotal] = CAST(COALESCE(NonClient.DisbursedNonClientTotal, 0) AS decimal(16,2)),
			[VendorTermsCode] = H.VT_CODE,
			[VendorTermsDesc] = VT.VT_DESCRIPTION,
			[APGLXact] = H.GLEXACT,
			[APGLSequenceNumber] = H.GLESEQ,
			[APGLAccountCode] = H.GLACODE,
			[APGLAccountDescription] = G.GLADESC,
			[CurrencyCode] = H.CURRENCY_CODE,
			[CurrencyDescription] = CC.CURRENCY_DESC,
			[CurrencyRate] = H.CURRENCY_RATE,
			[ExchangeGLAccountCode] = H.AP_GLACODE_XCHG,
			[ExchangeGLAccountDescription] = G1.GLADESC,
			[OnPaymentHold] = CAST(COALESCE(H.PAYMENT_HOLD, 0) AS bit),
			[Is1099Invoice] = CAST(COALESCE(H.FLAG_1099, 0) AS bit),
			[PaidToVendor] = CAST(COALESCE(Payment.TotalPaid, 0) AS decimal(16,2)),
			[VendorServiceTaxAmount] = COALESCE(Payment.VendorServiceTax, 0),
		    [TotalPaidToVendor] = COALESCE(Payment.TotalPaid, 0) + COALESCE(Payment.VendorServiceTax, 0),
			[BalanceDue] = CAST(COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0) AS decimal(16,2)) - (COALESCE(Payment.TotalPaid, 0) + COALESCE(Payment.VendorServiceTax, 0) + COALESCE(Payment.DiscountTaken, 0)),
			[DiscountTaken] = CAST(COALESCE(Payment.DiscountTaken, 0) AS decimal(16,2)),
			[LastCheckNumber] = APH.AP_CHK_NBR,
			[LastCheckDate] = APH.AP_CHK_DATE,
			[APTotalDueUnpaid] = CAST((COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)) - COALESCE(Payment.TotalPaid, 0) - COALESCE(Payment.DiscountTaken, 0) - COALESCE(Payment.VendorServiceTax, 0) AS decimal(16,2)),
			[Age] = CASE WHEN @aging_option_invoice_date = 1 THEN DATEDIFF(d, H.AP_INV_DATE, @aging_date)
						 WHEN @aging_option_invoice_date = 0 THEN DATEDIFF(d, H.AP_DATE_PAY, @aging_date) END,
			[DaysToPayment] = CAST(CASE WHEN APH.AP_CHK_DATE IS NULL THEN DateDiff(d, GETDATE(), H.AP_DATE_PAY) ELSE NULL END AS int),
			[MappedAccount] = GLAX.MappedAccount,
			[TargetAccount] = GLAEX.TARGET_GLACODE,
			[PostedToSummary] = GLEH.GLEHPOSTSUM
	FROM --dbo.AP_HEADER H
		(SELECT	H.AP_ID,
		--	MAX(H.VN_FRL_EMP_CODE) VN_FRL_EMP_CODE,
		--	MAX(CAST(H.SERVICE_TAX_ENABLED AS int)) SERVICE_TAX_ENABLED,
		--	MAX(H.AP_TYPE) AP_TYPE,
		--	MAX(H.AP_INV_VCHR) AP_INV_VCHR,
		--	MAX(H.AP_DESC) AP_DESC,
		--	MAX(H.CREATE_DATE) CREATE_DATE,
		--	MAX(H.AP_INV_DATE) AP_INV_DATE,
		--	MAX(H.AP_DATE_PAY) AP_DATE_PAY,
		--	MAX(H.POST_PERIOD) POST_PERIOD,
		--	SUM(COALESCE(H.AP_INV_AMT, 0)) AP_INV_AMT, 
		--	SUM(COALESCE(H.AP_SHIPPING, 0)) AP_SHIPPING,
		--	SUM(COALESCE(H.AP_SALES_TAX, 0)) AP_SALES_TAX,
		--	MAX(COALESCE(H.AP_DISC_PCT, 0)) AP_DISC_PCT,
		--	MAX(H.VT_CODE) VT_CODE,
		--	MAX(H.GLEXACT) GLEXACT,
		--	MAX(H.GLESEQ) GLESEQ,
		--	MAX(H.GLACODE) GLACODE,
		--	MAX(H.CURRENCY_CODE) CURRENCY_CODE,
		--	MAX(H.CURRENCY_RATE) CURRENCY_RATE,
		--	MAX(H.AP_GLACODE_XCHG) AP_GLACODE_XCHG,
		--	MAX(COALESCE(H.PAYMENT_HOLD, 0)) PAYMENT_HOLD,
		--	MAX(COALESCE(H.FLAG_1099, 0)) FLAG_1099,
		--	MAX(VENDOR_SERVICE_TAX_ID) VENDOR_SERVICE_TAX_ID
		--FROM dbo.AP_HEADER H JOIN
			(H.VN_FRL_EMP_CODE) VN_FRL_EMP_CODE,
			(CAST(H.SERVICE_TAX_ENABLED AS int)) SERVICE_TAX_ENABLED,
			(H.AP_TYPE) AP_TYPE,
			(H.AP_INV_VCHR) AP_INV_VCHR,
			(H.AP_DESC) AP_DESC,
			(H.CREATE_DATE) CREATE_DATE,
			(H.AP_INV_DATE) AP_INV_DATE,
			(H.AP_DATE_PAY) AP_DATE_PAY,
			(H.POST_PERIOD) POST_PERIOD,
			(HH.AP_INV_AMT) AP_INV_AMT, 
			(HH.AP_SHIPPING) AP_SHIPPING, 
			(HH.AP_SALES_TAX) AP_SALES_TAX, 
			(COALESCE(H.AP_DISC_PCT, 0)) AP_DISC_PCT,
			(H.VT_CODE) VT_CODE,
			(H.GLEXACT) GLEXACT,
			(H.GLESEQ) GLESEQ,
			(H.GLACODE) GLACODE,
			(H.CURRENCY_CODE) CURRENCY_CODE,
			(H.CURRENCY_RATE) CURRENCY_RATE,
			(H.AP_GLACODE_XCHG) AP_GLACODE_XCHG,
			(COALESCE(H.PAYMENT_HOLD, 0)) PAYMENT_HOLD,
			(COALESCE(H.FLAG_1099, 0)) FLAG_1099,
			(H.VENDOR_SERVICE_TAX_ID) VENDOR_SERVICE_TAX_ID
		FROM dbo.AP_HEADER H JOIN
			(SELECT AP_ID, MAX(AP_SEQ) AP_SEQ, 			
					SUM(COALESCE(AP_INV_AMT, 0)) AP_INV_AMT, 
					SUM(COALESCE(AP_SHIPPING, 0)) AP_SHIPPING,
					SUM(COALESCE(AP_SALES_TAX, 0)) AP_SALES_TAX 
			FROM dbo.AP_HEADER GROUP BY AP_ID) HH ON HH.AP_ID = H.AP_ID AND HH.AP_SEQ = H.AP_SEQ JOIN
			@APIDS APH ON H.AP_ID = APH.AP_ID
		WHERE (APH.HDR_REC = 0 OR H.POST_PERIOD BETWEEN APH.POST_PERIOD_MIN AND APH.POST_PERIOD_MAX) --@post_period_from AND @post_period_to  
		--GROUP BY H.AP_ID
		) H

		LEFT OUTER JOIN dbo.VTERMS VT ON H.VT_CODE = VT.VT_CODE 
		LEFT OUTER JOIN dbo.CURRENCY_CODES CC ON H.CURRENCY_CODE = CC.CURRENCY_CODE 
		LEFT OUTER JOIN dbo.VENDOR_SERVICE_TAX VST ON H.VENDOR_SERVICE_TAX_ID = VST.VENDOR_SERVICE_TAX_ID
		INNER JOIN (
					SELECT
							[VendorName] = V.VN_NAME,
							[VendorAddress1] = V.VN_ADDRESS1,
							[VendorAddress2] = V.VN_ADDRESS2,
							[VendorAddress3] = V.VN_ADDRESS3,
							[VendorCity] = V.VN_CITY,
							[VendorCounty] = V.VN_COUNTY,
							[VendorState] = V.VN_STATE,
							[VendorZip] = V.VN_ZIP,
							[VendorCountry] = V.VN_COUNTRY,
							[VendorPhone] = V.VN_PHONE,
							[VendorPhoneExt] = V.VN_PHONE_EXT,
							[VendorFaxNumber] = V.VN_FAX_NUMBER,
							[VendorFaxExt] = V.VN_FAX_EXTENTION,
							[VendorEmail] = V.VN_EMAIL,
							[VendorDefaultCategory] = V.VN_CATEGORY,
							--[VendorAccountNumber] = V.VN_ACCT_NBR,
							[VendorOfficeCode] = V.OFFICE_CODE,
							[VendorOfficeName] = O.OFFICE_NAME,
							[VendorPayToCode] = V.VN_PAY_TO_CODE,
							V.VN_CODE,
							[VendorPayToName] = V1.VN_PAY_TO_NAME,
							[VendorPayToAddress1] = V1.VN_PAY_TO_ADDRESS1,
							[VendorPayToAddress2] = V1.VN_PAY_TO_ADDRESS2,
							[VendorPayToAddress3] = V1.VN_PAY_TO_ADDRESS3,
							[VendorPayToCity] = V1.VN_PAY_TO_CITY,
							[VendorPayToCounty] = V1.VN_PAY_TO_COUNTY,
							[VendorPayToState] = V1.VN_PAY_TO_STATE,
							[VendorPayToZip] = V1.VN_PAY_TO_ZIP,
							[VendorPayToCountry] = V1.VN_PAY_TO_COUNTRY,
							[VendorPayToPhone] = V1.VN_PAY_TO_PHONE,
							[VendorPayToPhoneExt] = V1.VN_PAY_TO_EXT,
							[VendorPayToFax] = V1.VN_PAY_TO_FAX_NBR,
							[VendorPayToFaxExt] = V1.VN_PAY_TO_FAX_EXT,
							[VendorPayToEmail] = V1.VN_PAY_TO_EMAIL,
							EMP_VENDOR = COALESCE(V.EMP_VENDOR, 0),
							[VendorVCCStatus] = CASE WHEN ISNULL(V.VCC_STATUS, 0) = 0 THEN 'Open'
													 WHEN V.VCC_STATUS = 1 THEN 'Accepted'
													 WHEN V.VCC_STATUS = 2 THEN 'Declined'
												END,
							[VendorBankCode] = V.BK_CODE,
							[VendorBankName] = B.BK_DESCRIPTION,
							[VendorSpecialTerms] = CASE WHEN V.HAS_SPECIAL_TERMS = 1 THEN 'Y' ELSE 'N' END,
							[VendorNotes] = V.VN_NOTES
					FROM dbo.VENDOR V
						LEFT OUTER JOIN dbo.OFFICE O ON V.OFFICE_CODE = O.OFFICE_CODE
						LEFT OUTER JOIN dbo.VENDOR V1 ON V.VN_PAY_TO_CODE = V1.VN_CODE  
						LEFT OUTER JOIN dbo.BANK B ON V.BK_CODE = B.BK_CODE
					) V ON H.VN_FRL_EMP_CODE = V.VN_CODE 
		LEFT OUTER JOIN dbo.GLACCOUNT G ON H.GLACODE = G.GLACODE 
		LEFT OUTER JOIN dbo.GLACCOUNT G1 ON H.AP_GLACODE_XCHG = G1.GLACODE 
		LEFT OUTER JOIN (
						SELECT [DisbursedNonClientTotal] = SUM(AP_GL_AMT), AP_ID
						FROM dbo.AP_GL_DIST WHERE POST_PERIOD BETWEEN @post_period_from AND @post_period_to
						GROUP BY AP_ID
						) NonClient ON NonClient.AP_ID = H.AP_ID 
		LEFT OUTER JOIN 
						@payments Payment ON Payment.AP_ID = H.AP_ID 
							
		LEFT OUTER JOIN (
						SELECT	[MaxGLEXACT] = MAX(APH.GLEXACT),
								AP_ID
						FROM dbo.AP_PMT_HIST APH
							INNER JOIN dbo.CHECK_REGISTER CR ON APH.BK_CODE = CR.BK_CODE AND APH.AP_CHK_NBR = CR.CHECK_NBR AND APH.CHK_SEQ = CR.CHK_SEQ 
						WHERE	APH.POST_PERIOD <= @post_period_to --(VOID_FLAG IS NULL OR VOID_FLAG = 0) AND APH.POST_PERIOD <= @post_period_to 	/* PJH 03/04/2020 */
						GROUP BY AP_ID
						) LastCheck ON LastCheck.AP_ID = H.AP_ID
		LEFT OUTER JOIN dbo.AP_PMT_HIST APH ON LastCheck.AP_ID = APH.AP_ID AND LastCheck.MaxGLEXACT = APH.GLEXACT 
		LEFT OUTER JOIN 
						@client_amount Client ON Client.AP_ID = H.AP_ID
		LEFT OUTER JOIN
			(SELECT 
				[GLACode] = GLACODE,
				[MappedAccount] = SOURCE_GLACODE
			 FROM 
				[dbo].[GLACCOUNT_XREF] 
			 WHERE
				GLACCOUNT_XREF_ID IN (SELECT MAX(GLACCOUNT_XREF_ID) FROM [dbo].[GLACCOUNT_XREF] WHERE RECORD_SOURCE_ID = @record_source GROUP BY GLACODE)) AS GLAX ON H.GLACODE = GLAX.GLACode
		LEFT OUTER JOIN
			(SELECT 
				DTL.GLACODE,
				HDR.TARGET_GLACODE
			 FROM 
				[dbo].[GLACCOUNT_XREF_EXPORT] HDR
			 INNER JOIN	
				[dbo].[GLACCOUNT_XREF_EXPORT_DETAIL] DTL ON HDR.GLACCOUNT_XREF_EXPORT_ID = DTL.GLACCOUNT_XREF_EXPORT_ID  
			 WHERE
				RECORD_SOURCE_ID = @record_source) AS GLAEX ON GLAEX.GLACODE = H.GLACODE
		LEFT OUTER JOIN	
			dbo.GLENTHDR GLEH ON H.GLEXACT = GLEH.GLEHXACT 
	WHERE ((@open_ap_only = 1 AND COALESCE(Payment.TotalPaid, 0) <> (COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)))
				OR (@open_ap_only = 0))
	--WHERE
	--		H.MODIFY_FLAG IS NULL
	----AND		ISNULL(H.DELETE_FLAG, 0) = 0
	--AND		H.AP_SEQ = 0
	--AND		H.POST_PERIOD BETWEEN @post_period_from AND @post_period_to 
	--AND		((@open_ap_only = 1 AND COALESCE(Payment.TotalPaid, 0) <> (COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)))
	--		OR
	--		(@open_ap_only = 0))
) Results

END

GO

GRANT EXECUTE ON [advsp_ap_invoice_with_balance_aging_report] TO PUBLIC AS dbo
GO