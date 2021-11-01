
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'[dbo].[advsp_ap_pmt_hist_base]')
			AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE [dbo].[advsp_ap_pmt_hist_base]
GO


CREATE PROCEDURE [dbo].[advsp_ap_pmt_hist_base] 
	 @bk_code VARCHAR(4)
	,@ap_chk_nbr INT
	,@ap_id INT
	,@ap_chk_date SMALLDATETIME
AS
BEGIN

/*
PJH 03/20/2020 - added COALESCE(APD.VENDOR_SERVICE_TAX, 0)

*/
	DECLARE @multi_crncy SMALLINT
	DECLARE @ok SMALLINT

	SELECT @multi_crncy = MULTI_CRNCY
	FROM AGENCY

	SET @ok = 1

	--SELECT @multi_crncy '@multi_crncy' 
	/* No Check Nbr without Bank Code */
	IF @bk_code IS NULL
		SET @ap_chk_nbr = NULL

	IF @ap_id IS NULL AND (@bk_code IS NULL OR @ap_chk_nbr IS NULL)
		SET @ok = 0

	IF @ok = 1 BEGIN
		SELECT [ID] = IDENTITY(int, 1,1)
			,[APIdentifier] = APD.AP_ID
			,[APSequence] = APD.AP_SEQ
			,[BankCode] = APD.BK_CODE
			,[CheckNumber] = APD.AP_CHK_NBR
			,[CheckDate] = APD.AP_CHK_DATE
			,[GLAccountCodeCash] = APD.GLACODE_CASH
			,[GLAccountCodeAP] = APD.GLACODE_AP
			,[GLAccountCodeDiscount] = APD.GLACODE_DISC
			,[GLAccountCodeWithholding] = APD.GLACODE_WH
			,[GLAccountCodeExchange] = APD.GLACODE_CRNCY_UNREALIZED
			,[APCheckAmount] = COALESCE(APD.AP_CHK_AMT, 0)
			,[APDiscountAmount] = COALESCE(APD.AP_DISC_AMT, 0)
			,[VendorServiceTaxAmount] = COALESCE(APD.VENDOR_SERVICE_TAX, 0)
			,[CurrencyExchangeAmount] = (
				CASE 
					WHEN @multi_crncy = 1
						THEN (
								CASE 
									WHEN (APD.BANK_CURRENCY_CODE = APD.AP_CURRENCY_CODE) AND (APD.BANK_CURRENCY_CODE <> APD.HOME_CURRENCY_CODE)
										THEN (APD.AP_CHK_AMT) * COALESCE(APH.CURRENCY_RATE, 1)
									ELSE (APD.AP_CHK_AMT)
									END
								)
					ELSE 
						COALESCE(APD.AP_CHK_AMT, 0)
					END
				) 
			--COALESCE(APD.EXCHANGE_AMOUNT_APPLIED, 0)
			,[HomeCurrencyCode] = APD.HOME_CURRENCY_CODE
			,[BankCurrencyCode] = APD.BANK_CURRENCY_CODE
			,[APCurrencyCode] = APD.AP_CURRENCY_CODE
			,[APCurrencyRate] = COALESCE(APH.CURRENCY_RATE, 0)
			,[PaymentPostingPeriod] = APD.POST_PERIOD
			,[APGLXact] = APD.GLEXACT
			,[APGLSeqCash] = APD.GLESEQ_CASH
			,[APGLSeqAP] = APD.GLESEQ_AP
			,[APGLSeqDISC] = APD.GLESEQ_DISC
			,[APGLSeqWithholding] = APD.GLESEQ_WH
			,[ManualCheck] = APD.AP_CHK_MAN
			,[PaymentEntryDate] = APD.CREATE_DATE
			,[APPaymentAmount] = (
				CASE 
					WHEN @multi_crncy = 1
						THEN (
								CASE 
									WHEN (APD.BANK_CURRENCY_CODE = APD.AP_CURRENCY_CODE) AND (APD.BANK_CURRENCY_CODE <> APD.HOME_CURRENCY_CODE)
										THEN (APD.AP_CHK_AMT) 
									ELSE APD.AP_CHK_AMT
									END
								)
					ELSE 
						COALESCE(APD.AP_CHK_AMT, 0)
					END
				) + (COALESCE(APD.AP_DISC_AMT, 0)) + COALESCE(APD.VENDOR_SERVICE_TAX, 0)						--PJH 03/20/2020 - added COALESCE(APD.VENDOR_SERVICE_TAX, 0)
			,[ExchangeDiscountApplied] = (
				CASE 
					WHEN @multi_crncy = 1
						THEN (
								CASE 
									WHEN (APD.BANK_CURRENCY_CODE = APD.AP_CURRENCY_CODE) AND (APD.BANK_CURRENCY_CODE <> APD.HOME_CURRENCY_CODE)
										THEN COALESCE(APD.EXCHANGE_DISC_AMOUNT, 0)
									ELSE 0
									END
								)
					ELSE 
						COALESCE(APD.AP_DISC_AMT, 0)
					END
				) 
			,[ExchangeAmountApplied] = (
				CASE 
					WHEN @multi_crncy = 1
						THEN (
								CASE 
									WHEN (APD.BANK_CURRENCY_CODE = APD.AP_CURRENCY_CODE) AND (APD.BANK_CURRENCY_CODE <> APD.HOME_CURRENCY_CODE)
										THEN 1
									ELSE 
										0
									END
								)
					ELSE 
						0
					END
				),
				[CurrencyRate] = APH.CURRENCY_RATE
		INTO #NewTable
		FROM AP_PMT_HIST APD
		INNER JOIN AP_HEADER APH ON APD.AP_ID = APH.AP_ID
		WHERE (
				APD.BK_CODE = @bk_code
				OR @bk_code IS NULL
				)
			AND (
				APD.AP_ID = @ap_id
				OR @ap_id IS NULL
				)
			AND (
				APD.AP_CHK_NBR = @ap_chk_nbr
				OR @ap_chk_nbr IS NULL
				)
			AND ( 
				MODIFY_FLAG IS NULL 
				)

			SELECT * FROM #NewTable

			DROP TABLE #NewTable
	END
	ELSE
		SELECT 0,0,0,'ERR'

END

GO
