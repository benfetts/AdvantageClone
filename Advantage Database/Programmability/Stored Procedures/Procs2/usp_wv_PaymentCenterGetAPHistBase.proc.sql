IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetAPHistBase]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetAPHistBase] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetAPHistBase]		
	@USER_CODE VARCHAR(6),
	@BATCH_ID INT		
AS	

BEGIN		

	SELECT BI.AP_ID                                AS APId,	
		   CONVERT(INT, MAX(AH.AP_SEQ))                          AS APSequence,
		   BH.BANK_CODE                            AS BankCode, 
--		   [dbo].udf_get_next_check_nbr (BH.BANK_CODE, BI.PAYMENT_TYPE, 'EXT')                          AS APCheckNumber,		   
		   GETDATE()                               AS APCheckDate, 
		   SUM(BI.APPROVED_AMOUNT)                 AS APAmount, 
		   SUM(DISC_APPROVED_AMOUNT)               AS APDiscountAmount, 
		   B.GLACODE_AP_CASH                       AS APCashAccount, 
		   AH.GLACODE                              AS GLAccountCode, 
		   BH.POSTING_PERIOD                       AS PostingPeriod, 
		   SUM(COALESCE(VENDOR_TAXABLE_AMOUNT, 0)) AS VendorTaxableAmount,		   
		   COALESCE(VST.RATE / 100, 0)             AS VendorServiceTaxAmount,
		   BI.PAYMENT_TYPE						   AS PaymentType,
		   0									   AS CheckSequence
	FROM   PC_BATCH_INVOICE BI WITH (NOLOCK) 
		   JOIN AP_HEADER AH WITH (NOLOCK) 
			 ON BI.AP_ID = AH.AP_ID 
		   JOIN PC_BATCH_HEADER BH WITH (NOLOCK) 
			 ON BI.BATCH_ID = BH.BATCH_ID 
				AND BI.USER_ID = BH.USER_ID 
		   JOIN BANK B WITH (NOLOCK) 
			 ON BH.BANK_CODE = B.BK_CODE 
		   JOIN VENDOR V WITH (NOLOCK) 
			 ON V.VN_CODE = AH.VN_FRL_EMP_CODE 
		   LEFT JOIN VENDOR_SERVICE_TAX VST WITH (NOLOCK) 
				  ON VST.VENDOR_SERVICE_TAX_ID = V.VENDOR_SERVICE_TAX_ID 
	WHERE  BI.BATCH_ID = @BATCH_ID 
		   AND BI.USER_ID = @USER_CODE 
	GROUP  BY BI.AP_ID, 
			  BI.PAYMENT_TYPE,
			  BH.BANK_CODE, 
			  B.GLACODE_AP_CASH, 
			  AH.GLACODE, 
			  BH.POSTING_PERIOD, 
			  BI.USER_ID, 
			  COALESCE(VST.RATE / 100, 0),
			  BI.PAYMENT_TYPE
	ORDER  BY BI.PAYMENT_TYPE, AH.GLACODE 
	
END