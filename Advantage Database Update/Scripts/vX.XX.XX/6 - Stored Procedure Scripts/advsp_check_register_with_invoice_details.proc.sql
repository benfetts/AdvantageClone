IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_check_register_with_invoice_details]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_check_register_with_invoice_details]
GO

CREATE PROCEDURE [dbo].[advsp_check_register_with_invoice_details](
	@BANK_LIST varchar(MAX) = NULL,
	--@OFFICE_LIST varchar(MAX) = NULL,
	--@CLIENT_LIST varchar(MAX) = NULL,
	@start_date			datetime = '01/01/1951',
	@end_date			datetime = '12/31/2199',
	@IncludeComputerChecks bit,
	@IncludeManualChecks bit,
	@IncludeComments bit,
	@LimitVoidedChecks bit,
	@LimitOutstandingChecks bit,
	@LimitClearedChecks bit,
	@PostPeriodStart varchar(6),
	@PostPeriodEnd varchar(6),
	@VENDOR_LIST varchar(MAX) = NULL,
	@UsePayToVendorCode bit
	)
AS

--Stored procedure to extract check register information
-- #00 12/06/17 - initial release
-- #01 11/16/20 - 735-1-4422 - debit GL and credit GL account appear to be mislabeled. When a check is written, the journal entry is a debit to the AP account and a credit to cash
-- #02 10/19/21 - use CHECK_REGISTER check amount

BEGIN
	SET NOCOUNT ON;

	-- ==========================================================
	-- AP_ID MAX SEQ TEMP TABLE
	-- ==========================================================
	CREATE TABLE #ap_id_max_seq (
		AP_ID				int NOT NULL,
		AP_SEQ				smallint NOT NULL,
		AP_INV_AMT			decimal(14,2) NOT NULL
		)

	INSERT INTO #ap_id_max_seq
	SELECT a.AP_ID,
		MAX(a.AP_SEQ) AS AP_SEQ,
		SUM(ISNULL(AP_INV_AMT, 0))
	FROM dbo.AP_HEADER AS a
	GROUP BY a.AP_ID	

	--SELECT AP_CHK_NBR, C.AP_INV_AMT, B.BK_CODE, A.* FROM #ap_id_max_seq A JOIN AP_PMT_HIST B ON A.AP_ID = B.AP_ID JOIN AP_HEADER C ON A.AP_ID = C.AP_ID AND AP_CHK_NBR IN (100302)
	--WHERE (B.BK_CODE IN (SELECT * FROM dbo.udf_split_list(@BANK_LIST, ',')) OR @BANK_LIST IS NULL)
	--ORDER BY AP_CHK_NBR

	--SELECT * FROM AP_HEADER WHERE AP_ID IN (853)
	--SELECT * FROM BANK WHERE BK_CODE = 'op'
	--SELECT * FROM AP_PMT_HIST WHERE AP_CHK_NBR IN (100302)
	--SELECT * FROM CHECK_REGISTER WHERE CHECK_NBR IN (100302)

	IF @PostPeriodStart = '' SET @PostPeriodStart = NULL
	IF @PostPeriodEnd = '' SET @PostPeriodEnd = NULL
	IF @start_date = '' SET @start_date = NULL
	IF @end_date = '' SET @end_date = NULL

	-- ==========================================================
	-- EXTRACTION ROUTINE
	-- ==========================================================

	IF @UsePayToVendorCode = 1 /* Use Vendor Pay To Code */
	BEGIN
		IF @IncludeComments = 1
		BEGIN
			SELECT 
				[ID] = NEWID(),
				[VendorCode]			= v.VN_CODE,
				[VendorName]			= v.VN_NAME,
				[VendorAddress1]		= v.VN_ADDRESS1,
				[VendorAddress2]		= v.VN_ADDRESS2,
				[VendorCity]			= v.VN_CITY,
				[VendorCounty]			= v.VN_COUNTY,
				[VendorState]			= v.VN_STATE,
				[VendorCountry]		= v.VN_COUNTRY,
				[VendorZip]			= v.VN_ZIP,	
				[VendorPayToName]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_NAME,v2.VN_NAME)
												ELSE v.VN_PAY_TO_NAME
											END,	
				[VendorPayToAddress1] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS1,v2.VN_ADDRESS1)
												ELSE v.VN_PAY_TO_ADDRESS1
											END,
				[VendorPayToAddress2] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS2,v2.VN_ADDRESS2)
												ELSE v.VN_PAY_TO_ADDRESS2
											END,
				[VendorPayToCity]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_CITY,v2.VN_CITY)
												ELSE v.VN_PAY_TO_CITY
											END,
				[VendorPayToCounty]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTY,v2.VN_COUNTY)
												ELSE v.VN_PAY_TO_COUNTY
											END,
				[VendorPayToState]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_STATE,v2.VN_STATE)
												ELSE v.VN_PAY_TO_STATE
											END,
				[VendorPayToCountry] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTRY,v2.VN_COUNTRY)
												ELSE v.VN_PAY_TO_COUNTRY
											END,
				[VendorPayToZip]		=	CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ZIP,v2.VN_ZIP)
												ELSE v.VN_PAY_TO_ZIP
											END,
				[VendorEmailAddress]	=	v.VN_EMAIL,
				[VendorActiveFlag]	= CASE WHEN v.VN_ACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[VendorCategory]		= v.VN_CATEGORY,
				[VendorTaxID]			= v.VN_TAX_ID,
				[VendorAccountNumber] = v.VN_ACCT_NBR,
				[VendorNotes]			= v.VN_NOTES,

				[InvoiceNumber]		= h.AP_INV_VCHR,
				[InvoiceDate]		= h.AP_INV_DATE,
				[InvoiceAmount]		= h.AP_INV_AMT, --m.AP_INV_AMT,
				[InvoiceAmountPaid] = p.AP_CHK_AMT,

				[CheckNumber]		= p.AP_CHK_NBR,
				[CheckDate]			= p.AP_CHK_DATE,
				[CheckPostPeriod]   = r.POST_PERIOD,
				[CheckAmount]		= CASE WHEN r.VOID_FLAG = 1 THEN 0.00 ELSE r.CHECK_AMT END, --p.AP_CHK_AMT, #02
				[DiscountAmount]	= r.DISC_AMT, --#02
				[CheckVoided]		    = CASE WHEN r.VOID_FLAG = 1 THEN 'Yes' ELSE 'No' END,
                [VoidedCheckAmount]     = CASE WHEN r.VOID_FLAG = 1 THEN r.CHECK_AMT ELSE 0.00 END,
				[VoidComments]			= r.VO_COMMENT,
				[CheckManualFlag]		= CASE WHEN r.[MANUAL] = 1 THEN 'Yes' ELSE 'No' END,

				[DebitGLAccount]		= p.GLACODE_CASH,
				[CreditGLAccount]		= p.GLACODE_AP,

				[CheckCleared]			= CASE WHEN r.CLEARED = 1 THEN 'Yes' ELSE 'No' END,
				[BankCode]				= b.BK_CODE,
				[BankDescription]		= b.BK_DESCRIPTION,
				[BankInactiveFlag]	= CASE WHEN b.INACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[BankAccountNumber]	= b.BK_ACCOUNT_NO,
				[BankRoutingNumber]	= b.BK_ROUTING_NBR,
				[ACHCompanyID]		= b.ACH_COMPANY_ID,
				[BankOfficeCode]		= b.OFFICE_CODE,

				[ARCashAccount]		= b.GLACODE_AR_CASH,
				[APCashAccount]		= b.GLACODE_AP_CASH,
				[APDiscountAccount]	= b.GLACODE_AP_DISC,
				[ServiceChargeAccount] = b.GLACODE_SC,
				[InterestEarnedAccount] = b.GLACODE_IE,

				[VendorPayToCode] = v.VN_PAY_TO_CODE,
				[VoidPostPeriod]   = r.VOID_POST_PERIOD,

				/* Add Descriptions */
				[DebitGLDescription] = g1.GLADESC,
				[CreditGLDescription] = g2.GLADESC,
				[ARCashDescription] = g3.GLADESC,
				[APCashDescription] = g4.GLADESC,
				[APDiscountDescription] = g5.GLADESC,
				[ServiceChargeDescription] = g6.GLADESC,
				[InterestEarnedDescription] = g7.GLADESC
		
			FROM dbo.AP_HEADER AS h
			JOIN #ap_id_max_seq AS m
				ON h.AP_ID = m.AP_ID
				AND h.AP_SEQ = m.AP_SEQ
			JOIN dbo.AP_PMT_HIST AS p
				ON h.AP_ID = p.AP_ID AND p.CHK_SEQ = 0 --#02
			JOIN dbo.VENDOR AS v
				ON h.VN_FRL_EMP_CODE = v.VN_CODE
			LEFT JOIN dbo.VENDOR AS v2
				ON v.VN_PAY_TO_CODE = v2.VN_CODE
			JOIN dbo.BANK AS b
				ON p.BK_CODE = b.BK_CODE
			JOIN dbo.CHECK_REGISTER AS r
				ON p.BK_CODE = r.BK_CODE
				AND p.AP_CHK_NBR = r.CHECK_NBR
				--AND p.CHK_SEQ = r.CHK_SEQ
			LEFT JOIN dbo.GLACCOUNT g1 ON p.GLACODE_CASH = g1.GLACODE
			LEFT JOIN dbo.GLACCOUNT g2 ON p.GLACODE_AP = g2.GLACODE
			LEFT JOIN dbo.GLACCOUNT g3 ON b.GLACODE_AR_CASH = g3.GLACODE
			LEFT JOIN dbo.GLACCOUNT g4 ON b.GLACODE_AP_CASH = g4.GLACODE
			LEFT JOIN dbo.GLACCOUNT g5 ON b.GLACODE_AP_DISC = g5.GLACODE
			LEFT JOIN dbo.GLACCOUNT g6 ON b.GLACODE_SC = g6.GLACODE
			LEFT JOIN dbo.GLACCOUNT g7 ON b.GLACODE_IE = g7.GLACODE
			WHERE (b.BK_CODE IN (SELECT * FROM dbo.udf_split_list(@BANK_LIST, ',')) OR @BANK_LIST IS NULL) 
					AND (v.VN_PAY_TO_CODE IN (SELECT * FROM dbo.udf_split_list(@VENDOR_LIST, ',')) OR @VENDOR_LIST IS NULL)
					AND ((p.AP_CHK_DATE BETWEEN @start_date AND @end_date) OR @start_date IS NULL)
					AND ((p.POST_PERIOD BETWEEN @PostPeriodStart AND @PostPeriodEnd) OR @PostPeriodStart IS NULL) /* Use Pmt History Post Period - Covers both Checks and Voids */
					AND 1 = CASE WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 1) THEN 1
								 WHEN (@IncludeComputerChecks = 0 AND @IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 
								 WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 0 AND (r.[MANUAL] = 0 OR r.[MANUAL] IS NULL)) THEN 1 ELSE 0 END
					--AND 1 = CASE WHEN (@IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitVoidedChecks = 1 AND r.VOID_FLAG = 1) OR @LimitVoidedChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitOutstandingChecks = 1 AND (r.CLEARED = 0 OR r.CLEARED IS NULL)) OR @LimitOutstandingChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitClearedChecks = 1 AND r.CLEARED = 1) OR @LimitClearedChecks = 0 THEN 1 ELSE 0 END
			ORDER BY v.VN_CODE, b.BK_CODE, p.AP_CHK_NBR, h.AP_INV_VCHR
		END
		ELSE
		BEGIN
			SELECT 
				[ID] = NEWID(),
				[VendorCode]			= v.VN_CODE,
				[VendorName]			= v.VN_NAME,
				[VendorAddress1]		= v.VN_ADDRESS1,
				[VendorAddress2]		= v.VN_ADDRESS2,
				[VendorCity]			= v.VN_CITY,
				[VendorCounty]			= v.VN_COUNTY,
				[VendorState]			= v.VN_STATE,
				[VendorCountry]		= v.VN_COUNTRY,
				[VendorZip]			= v.VN_ZIP,	
				[VendorPayToName]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_NAME,v2.VN_NAME)
												ELSE v.VN_PAY_TO_NAME
											END,	
				[VendorPayToAddress1] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS1,v2.VN_ADDRESS1)
												ELSE v.VN_PAY_TO_ADDRESS1
											END,
				[VendorPayToAddress2] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS2,v2.VN_ADDRESS2)
												ELSE v.VN_PAY_TO_ADDRESS2
											END,
				[VendorPayToCity]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_CITY,v2.VN_CITY)
												ELSE v.VN_PAY_TO_CITY
											END,
				[VendorPayToCounty]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTY,v2.VN_COUNTY)
												ELSE v.VN_PAY_TO_COUNTY
											END,
				[VendorPayToState]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_STATE,v2.VN_STATE)
												ELSE v.VN_PAY_TO_STATE
											END,
				[VendorPayToCountry] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTRY,v2.VN_COUNTRY)
												ELSE v.VN_PAY_TO_COUNTRY
											END,
				[VendorPayToZip]		=	CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ZIP,v2.VN_ZIP)
												ELSE v.VN_PAY_TO_ZIP
											END,
				[VendorEmailAddress]	=	v.VN_EMAIL,
				[VendorActiveFlag]	= CASE WHEN v.VN_ACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[VendorCategory]		= v.VN_CATEGORY,
				[VendorTaxID]			= v.VN_TAX_ID,
				[VendorAccountNumber] = v.VN_ACCT_NBR,
				[VendorNotes]			= v.VN_NOTES,

				[InvoiceNumber]		= h.AP_INV_VCHR,
				[InvoiceDate]		= h.AP_INV_DATE,
				[InvoiceAmount]		= h.AP_INV_AMT, --m.AP_INV_AMT,
				[InvoiceAmountPaid] = p.AP_CHK_AMT,

				[CheckNumber]		= p.AP_CHK_NBR,
				[CheckDate]			= p.AP_CHK_DATE,
				[CheckPostPeriod]   = r.POST_PERIOD,
				[CheckAmount]		= CASE WHEN r.VOID_FLAG = 1 THEN 0.00 ELSE r.CHECK_AMT END, --p.AP_CHK_AMT, #02
				[DiscountAmount]	= r.DISC_AMT, --#02
				[CheckVoided]		    = CASE WHEN r.VOID_FLAG = 1 THEN 'Yes' ELSE 'No' END,
                [VoidedCheckAmount]     = CASE WHEN r.VOID_FLAG = 1 THEN r.CHECK_AMT ELSE 0.00 END,
				[VoidComments]			= NULL,
				[CheckManualFlag]		= CASE WHEN r.[MANUAL] = 1 THEN 'Yes' ELSE 'No' END,

				[DebitGLAccount]		= p.GLACODE_CASH,
				[CreditGLAccount]		= p.GLACODE_AP,

				[CheckCleared]			= CASE WHEN r.CLEARED = 1 THEN 'Yes' ELSE 'No' END,
				[BankCode]				= b.BK_CODE,
				[BankDescription]		= b.BK_DESCRIPTION,
				[BankInactiveFlag]	= CASE WHEN b.INACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[BankAccountNumber]	= b.BK_ACCOUNT_NO,
				[BankRoutingNumber]	= b.BK_ROUTING_NBR,
				[ACHCompanyID]		= b.ACH_COMPANY_ID,
				[BankOfficeCode]		= b.OFFICE_CODE,

				[ARCashAccount]		= b.GLACODE_AR_CASH,
				[APCashAccount]		= b.GLACODE_AP_CASH,
				[APDiscountAccount]	= b.GLACODE_AP_DISC,
				[ServiceChargeAccount] = b.GLACODE_SC,
				[InterestEarnedAccount] = b.GLACODE_IE,

				[VendorPayToCode] = v.VN_PAY_TO_CODE,
				[VoidPostPeriod]   = r.VOID_POST_PERIOD, 

				/* Add Descriptions */
				[DebitGLDescription] = g1.GLADESC,
				[CreditGLDescription] = g2.GLADESC,
				[ARCashDescription] = g3.GLADESC,
				[APCashDescription] = g4.GLADESC,
				[APDiscountDescription] = g5.GLADESC,
				[ServiceChargeDescription] = g6.GLADESC,
				[InterestEarnedDescription] = g7.GLADESC
		
			FROM dbo.AP_HEADER AS h
			JOIN #ap_id_max_seq AS m
				ON h.AP_ID = m.AP_ID
				AND h.AP_SEQ = m.AP_SEQ
			JOIN dbo.AP_PMT_HIST AS p
				ON h.AP_ID = p.AP_ID AND p.CHK_SEQ = 0 --#02
			JOIN dbo.VENDOR AS v
				ON h.VN_FRL_EMP_CODE = v.VN_CODE
			LEFT JOIN dbo.VENDOR AS v2
				ON v.VN_PAY_TO_CODE = v2.VN_CODE
			JOIN dbo.BANK AS b
				ON p.BK_CODE = b.BK_CODE
			JOIN dbo.CHECK_REGISTER AS r
				ON p.BK_CODE = r.BK_CODE
				AND p.AP_CHK_NBR = r.CHECK_NBR
				--AND p.CHK_SEQ = r.CHK_SEQ
			LEFT JOIN dbo.GLACCOUNT g1 ON p.GLACODE_CASH = g1.GLACODE
			LEFT JOIN dbo.GLACCOUNT g2 ON p.GLACODE_AP = g2.GLACODE
			LEFT JOIN dbo.GLACCOUNT g3 ON b.GLACODE_AR_CASH = g3.GLACODE
			LEFT JOIN dbo.GLACCOUNT g4 ON b.GLACODE_AP_CASH = g4.GLACODE
			LEFT JOIN dbo.GLACCOUNT g5 ON b.GLACODE_AP_DISC = g5.GLACODE
			LEFT JOIN dbo.GLACCOUNT g6 ON b.GLACODE_SC = g6.GLACODE
			LEFT JOIN dbo.GLACCOUNT g7 ON b.GLACODE_IE = g7.GLACODE
			WHERE (b.BK_CODE IN (SELECT * FROM dbo.udf_split_list(@BANK_LIST, ',')) OR @BANK_LIST IS NULL) 
					AND (v.VN_PAY_TO_CODE IN (SELECT * FROM dbo.udf_split_list(@VENDOR_LIST, ',')) OR @VENDOR_LIST IS NULL)
					AND ((p.AP_CHK_DATE BETWEEN @start_date AND @end_date) OR @start_date IS NULL)
					AND ((p.POST_PERIOD BETWEEN @PostPeriodStart AND @PostPeriodEnd) OR @PostPeriodStart IS NULL)
					AND 1 = CASE WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 1) THEN 1
								 WHEN (@IncludeComputerChecks = 0 AND @IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 
								 WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 0 AND (r.[MANUAL] = 0 OR r.[MANUAL] IS NULL)) THEN 1 ELSE 0 END
					--AND 1 = CASE WHEN (@IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitVoidedChecks = 1 AND r.VOID_FLAG = 1) OR @LimitVoidedChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitOutstandingChecks = 1 AND (r.CLEARED = 0 OR r.CLEARED IS NULL)) OR @LimitOutstandingChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitClearedChecks = 1 AND r.CLEARED = 1) OR @LimitClearedChecks = 0 THEN 1 ELSE 0 END
			ORDER BY v.VN_CODE, b.BK_CODE, p.AP_CHK_NBR, h.AP_INV_VCHR
		END
	END
	ELSE /* Use Vendor Code */
	BEGIN
		IF @IncludeComments = 1
		BEGIN
			SELECT 
				[ID] = NEWID(),
				[VendorCode]			= v.VN_CODE,
				[VendorName]			= v.VN_NAME,
				[VendorAddress1]		= v.VN_ADDRESS1,
				[VendorAddress2]		= v.VN_ADDRESS2,
				[VendorCity]			= v.VN_CITY,
				[VendorCounty]			= v.VN_COUNTY,
				[VendorState]			= v.VN_STATE,
				[VendorCountry]		= v.VN_COUNTRY,
				[VendorZip]			= v.VN_ZIP,	
				[VendorPayToName]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_NAME,v2.VN_NAME)
												ELSE v.VN_PAY_TO_NAME
											END,	
				[VendorPayToAddress1] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS1,v2.VN_ADDRESS1)
												ELSE v.VN_PAY_TO_ADDRESS1
											END,
				[VendorPayToAddress2] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS2,v2.VN_ADDRESS2)
												ELSE v.VN_PAY_TO_ADDRESS2
											END,
				[VendorPayToCity]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_CITY,v2.VN_CITY)
												ELSE v.VN_PAY_TO_CITY
											END,
				[VendorPayToCounty]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTY,v2.VN_COUNTY)
												ELSE v.VN_PAY_TO_COUNTY
											END,
				[VendorPayToState]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_STATE,v2.VN_STATE)
												ELSE v.VN_PAY_TO_STATE
											END,
				[VendorPayToCountry] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTRY,v2.VN_COUNTRY)
												ELSE v.VN_PAY_TO_COUNTRY
											END,
				[VendorPayToZip]		=	CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ZIP,v2.VN_ZIP)
												ELSE v.VN_PAY_TO_ZIP
											END,
				[VendorEmailAddress]	=	v.VN_EMAIL,
				[VendorActiveFlag]	= CASE WHEN v.VN_ACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[VendorCategory]		= v.VN_CATEGORY,
				[VendorTaxID]			= v.VN_TAX_ID,
				[VendorAccountNumber] = v.VN_ACCT_NBR,
				[VendorNotes]			= v.VN_NOTES,

				[InvoiceNumber]		= h.AP_INV_VCHR,
				[InvoiceDate]		= h.AP_INV_DATE,
				[InvoiceAmount]		= h.AP_INV_AMT, --m.AP_INV_AMT,
				[InvoiceAmountPaid] = p.AP_CHK_AMT,

				[CheckNumber]		= p.AP_CHK_NBR,
				[CheckDate]			= p.AP_CHK_DATE,
				[CheckPostPeriod]   = r.POST_PERIOD,
				[CheckAmount]		= CASE WHEN r.VOID_FLAG = 1 THEN 0.00 ELSE r.CHECK_AMT END, --p.AP_CHK_AMT, #02
				[DiscountAmount]	= r.DISC_AMT, --#02
				[CheckVoided]		    = CASE WHEN r.VOID_FLAG = 1 THEN 'Yes' ELSE 'No' END,
                [VoidedCheckAmount]     = CASE WHEN r.VOID_FLAG = 1 THEN r.CHECK_AMT ELSE 0.00 END,
				[VoidComments]			= r.VO_COMMENT,
				[CheckManualFlag]		= CASE WHEN r.[MANUAL] = 1 THEN 'Yes' ELSE 'No' END,

				[DebitGLAccount]		= p.GLACODE_CASH,
				[CreditGLAccount]		= p.GLACODE_AP,

				[CheckCleared]			= CASE WHEN r.CLEARED = 1 THEN 'Yes' ELSE 'No' END,
				[BankCode]				= b.BK_CODE,
				[BankDescription]		= b.BK_DESCRIPTION,
				[BankInactiveFlag]	= CASE WHEN b.INACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[BankAccountNumber]	= b.BK_ACCOUNT_NO,
				[BankRoutingNumber]	= b.BK_ROUTING_NBR,
				[ACHCompanyID]		= b.ACH_COMPANY_ID,
				[BankOfficeCode]		= b.OFFICE_CODE,

				[ARCashAccount]		= b.GLACODE_AR_CASH,
				[APCashAccount]		= b.GLACODE_AP_CASH,
				[APDiscountAccount]	= b.GLACODE_AP_DISC,
				[ServiceChargeAccount] = b.GLACODE_SC,
				[InterestEarnedAccount] = b.GLACODE_IE,

				[VendorPayToCode] = v.VN_PAY_TO_CODE,
				[VoidPostPeriod]   = r.VOID_POST_PERIOD,

				/* Add Descriptions */
				[DebitGLDescription] = g1.GLADESC,
				[CreditGLDescription] = g2.GLADESC,
				[ARCashDescription] = g3.GLADESC,
				[APCashDescription] = g4.GLADESC,
				[APDiscountDescription] = g5.GLADESC,
				[ServiceChargeDescription] = g6.GLADESC,
				[InterestEarnedDescription] = g7.GLADESC
		
			FROM dbo.AP_HEADER AS h
			JOIN #ap_id_max_seq AS m
				ON h.AP_ID = m.AP_ID
				AND h.AP_SEQ = m.AP_SEQ
			JOIN dbo.AP_PMT_HIST AS p
				ON h.AP_ID = p.AP_ID AND p.CHK_SEQ = 0 --#02
			JOIN dbo.VENDOR AS v
				ON h.VN_FRL_EMP_CODE = v.VN_CODE
			LEFT JOIN dbo.VENDOR AS v2
				ON v.VN_PAY_TO_CODE = v2.VN_CODE
			JOIN dbo.BANK AS b
				ON p.BK_CODE = b.BK_CODE
			JOIN dbo.CHECK_REGISTER AS r
				ON p.BK_CODE = r.BK_CODE
				AND p.AP_CHK_NBR = r.CHECK_NBR
				--AND p.CHK_SEQ = r.CHK_SEQ
			LEFT JOIN dbo.GLACCOUNT g1 ON p.GLACODE_CASH = g1.GLACODE
			LEFT JOIN dbo.GLACCOUNT g2 ON p.GLACODE_AP = g2.GLACODE
			LEFT JOIN dbo.GLACCOUNT g3 ON b.GLACODE_AR_CASH = g3.GLACODE
			LEFT JOIN dbo.GLACCOUNT g4 ON b.GLACODE_AP_CASH = g4.GLACODE
			LEFT JOIN dbo.GLACCOUNT g5 ON b.GLACODE_AP_DISC = g5.GLACODE
			LEFT JOIN dbo.GLACCOUNT g6 ON b.GLACODE_SC = g6.GLACODE
			LEFT JOIN dbo.GLACCOUNT g7 ON b.GLACODE_IE = g7.GLACODE
			WHERE (b.BK_CODE IN (SELECT * FROM dbo.udf_split_list(@BANK_LIST, ',')) OR @BANK_LIST IS NULL) 
					AND (h.VN_FRL_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@VENDOR_LIST, ',')) OR @VENDOR_LIST IS NULL)
					AND ((p.AP_CHK_DATE BETWEEN @start_date AND @end_date) OR @start_date IS NULL)
					AND ((p.POST_PERIOD BETWEEN @PostPeriodStart AND @PostPeriodEnd) OR @PostPeriodStart IS NULL)
					AND 1 = CASE WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 1) THEN 1
								 WHEN (@IncludeComputerChecks = 0 AND @IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 
								 WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 0 AND (r.[MANUAL] = 0 OR r.[MANUAL] IS NULL)) THEN 1 ELSE 0 END
					--AND 1 = CASE WHEN (@IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitVoidedChecks = 1 AND r.VOID_FLAG = 1) OR @LimitVoidedChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitOutstandingChecks = 1 AND (r.CLEARED = 0 OR r.CLEARED IS NULL)) OR @LimitOutstandingChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitClearedChecks = 1 AND r.CLEARED = 1) OR @LimitClearedChecks = 0 THEN 1 ELSE 0 END
			ORDER BY v.VN_CODE, b.BK_CODE, p.AP_CHK_NBR, h.AP_INV_VCHR
		END
		ELSE
		BEGIN
			SELECT 
				[ID] = NEWID(),
				[VendorCode]			= v.VN_CODE,
				[VendorName]			= v.VN_NAME,
				[VendorAddress1]		= v.VN_ADDRESS1,
				[VendorAddress2]		= v.VN_ADDRESS2,
				[VendorCity]			= v.VN_CITY,
				[VendorCounty]			= v.VN_COUNTY,
				[VendorState]			= v.VN_STATE,
				[VendorCountry]		= v.VN_COUNTRY,
				[VendorZip]			= v.VN_ZIP,	
				[VendorPayToName]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_NAME,v2.VN_NAME)
												ELSE v.VN_PAY_TO_NAME
											END,	
				[VendorPayToAddress1] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS1,v2.VN_ADDRESS1)
												ELSE v.VN_PAY_TO_ADDRESS1
											END,
				[VendorPayToAddress2] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ADDRESS2,v2.VN_ADDRESS2)
												ELSE v.VN_PAY_TO_ADDRESS2
											END,
				[VendorPayToCity]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_CITY,v2.VN_CITY)
												ELSE v.VN_PAY_TO_CITY
											END,
				[VendorPayToCounty]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTY,v2.VN_COUNTY)
												ELSE v.VN_PAY_TO_COUNTY
											END,
				[VendorPayToState]	=		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_STATE,v2.VN_STATE)
												ELSE v.VN_PAY_TO_STATE
											END,
				[VendorPayToCountry] =		CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_COUNTRY,v2.VN_COUNTRY)
												ELSE v.VN_PAY_TO_COUNTRY
											END,
				[VendorPayToZip]		=	CASE 
												WHEN (v.VN_PAY_TO_CODE IS NOT NULL) THEN ISNULL(v2.VN_PAY_TO_ZIP,v2.VN_ZIP)
												ELSE v.VN_PAY_TO_ZIP
											END,
				[VendorEmailAddress]	=	v.VN_EMAIL,
				[VendorActiveFlag]	= CASE WHEN v.VN_ACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[VendorCategory]		= v.VN_CATEGORY,
				[VendorTaxID]			= v.VN_TAX_ID,
				[VendorAccountNumber] = v.VN_ACCT_NBR,
				[VendorNotes]			= v.VN_NOTES,

				[InvoiceNumber]		= h.AP_INV_VCHR,
				[InvoiceDate]		= h.AP_INV_DATE,
				[InvoiceAmount]		= h.AP_INV_AMT, --m.AP_INV_AMT,
				[InvoiceAmountPaid] = p.AP_CHK_AMT,

				[CheckNumber]		= p.AP_CHK_NBR,
				[CheckDate]			= p.AP_CHK_DATE,
				[CheckPostPeriod]   = r.POST_PERIOD, --r.POST_PERIOD
				[CheckAmount]		= CASE WHEN r.VOID_FLAG = 1 THEN 0.00 ELSE r.CHECK_AMT END, --p.AP_CHK_AMT, #02
				[DiscountAmount]	= r.DISC_AMT, --#02
				[CheckVoided]		    = CASE WHEN r.VOID_FLAG = 1 THEN 'Yes' ELSE 'No' END,
                [VoidedCheckAmount]     = CASE WHEN r.VOID_FLAG = 1 THEN r.CHECK_AMT ELSE 0.00 END,
				[VoidComments]			= NULL,
				[CheckManualFlag]		= CASE WHEN r.[MANUAL] = 1 THEN 'Yes' ELSE 'No' END,

				[DebitGLAccount]		= p.GLACODE_AP, --#01 p.GLACODE_CASH, 
				[CreditGLAccount]		= p.GLACODE_CASH, --#01 p.GLACODE_AP,

				[CheckCleared]			= CASE WHEN r.CLEARED = 1 THEN 'Yes' ELSE 'No' END,
				[BankCode]				= b.BK_CODE,
				[BankDescription]		= b.BK_DESCRIPTION,
				[BankInactiveFlag]	= CASE WHEN b.INACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
				[BankAccountNumber]	= b.BK_ACCOUNT_NO,
				[BankRoutingNumber]	= b.BK_ROUTING_NBR,
				[ACHCompanyID]		= b.ACH_COMPANY_ID,
				[BankOfficeCode]		= b.OFFICE_CODE,

				[ARCashAccount]		= b.GLACODE_AR_CASH,
				[APCashAccount]		= b.GLACODE_AP_CASH,
				[APDiscountAccount]	= b.GLACODE_AP_DISC,
				[ServiceChargeAccount] = b.GLACODE_SC,
				[InterestEarnedAccount] = b.GLACODE_IE,

				[VendorPayToCode] = v.VN_PAY_TO_CODE,
				[VoidPostPeriod]   = r.VOID_POST_PERIOD,

				/* Add Descriptions */
				[DebitGLDescription] = g2.GLADESC, --#01 from g1 to g2
				[CreditGLDescription] = g1.GLADESC, --#01 from g2 to g1
				[ARCashDescription] = g3.GLADESC,
				[APCashDescription] = g4.GLADESC,
				[APDiscountDescription] = g5.GLADESC,
				[ServiceChargeDescription] = g6.GLADESC,
				[InterestEarnedDescription] = g7.GLADESC
		
			FROM dbo.AP_HEADER AS h
			JOIN #ap_id_max_seq AS m
				ON h.AP_ID = m.AP_ID
				AND h.AP_SEQ = m.AP_SEQ
			JOIN dbo.AP_PMT_HIST AS p
				ON h.AP_ID = p.AP_ID AND p.CHK_SEQ = 0 --#02
			JOIN dbo.VENDOR AS v
				ON h.VN_FRL_EMP_CODE = v.VN_CODE
			LEFT JOIN dbo.VENDOR AS v2
				ON v.VN_PAY_TO_CODE = v2.VN_CODE
			JOIN dbo.BANK AS b
				ON p.BK_CODE = b.BK_CODE
			JOIN dbo.CHECK_REGISTER AS r
				ON p.BK_CODE = r.BK_CODE
				AND p.AP_CHK_NBR = r.CHECK_NBR
				--AND p.CHK_SEQ = r.CHK_SEQ
			LEFT JOIN dbo.GLACCOUNT g1 ON p.GLACODE_CASH = g1.GLACODE
			LEFT JOIN dbo.GLACCOUNT g2 ON p.GLACODE_AP = g2.GLACODE
			LEFT JOIN dbo.GLACCOUNT g3 ON b.GLACODE_AR_CASH = g3.GLACODE
			LEFT JOIN dbo.GLACCOUNT g4 ON b.GLACODE_AP_CASH = g4.GLACODE
			LEFT JOIN dbo.GLACCOUNT g5 ON b.GLACODE_AP_DISC = g5.GLACODE
			LEFT JOIN dbo.GLACCOUNT g6 ON b.GLACODE_SC = g6.GLACODE
			LEFT JOIN dbo.GLACCOUNT g7 ON b.GLACODE_IE = g7.GLACODE
			WHERE (b.BK_CODE IN (SELECT * FROM dbo.udf_split_list(@BANK_LIST, ',')) OR @BANK_LIST IS NULL) 
					AND (h.VN_FRL_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@VENDOR_LIST, ',')) OR @VENDOR_LIST IS NULL)
					AND ((p.AP_CHK_DATE BETWEEN @start_date AND @end_date) OR @start_date IS NULL)
					AND ((p.POST_PERIOD BETWEEN @PostPeriodStart AND @PostPeriodEnd) OR @PostPeriodStart IS NULL)
					AND 1 = CASE WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 1) THEN 1
								 WHEN (@IncludeComputerChecks = 0 AND @IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 
								 WHEN (@IncludeComputerChecks = 1 AND @IncludeManualChecks = 0 AND (r.[MANUAL] = 0 OR r.[MANUAL] IS NULL)) THEN 1 ELSE 0 END
					--AND 1 = CASE WHEN (@IncludeManualChecks = 1 AND r.[MANUAL] = 1) THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitVoidedChecks = 1 AND r.VOID_FLAG = 1) OR @LimitVoidedChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitOutstandingChecks = 1 AND (r.CLEARED = 0 OR r.CLEARED IS NULL)) OR @LimitOutstandingChecks = 0 THEN 1 ELSE 0 END
					AND 1 = CASE WHEN (@LimitClearedChecks = 1 AND r.CLEARED = 1) OR @LimitClearedChecks = 0 THEN 1 ELSE 0 END

			ORDER BY v.VN_CODE, b.BK_CODE, p.AP_CHK_NBR, h.AP_INV_VCHR
		END
	END

END

GO

GRANT EXECUTE ON [advsp_check_register_with_invoice_details] TO PUBLIC
GO