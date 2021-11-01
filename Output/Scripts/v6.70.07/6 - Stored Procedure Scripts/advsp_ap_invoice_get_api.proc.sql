IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_ap_invoice_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_ap_invoice_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_ap_invoice_get_api] 
	@vn_code varchar(6),				/* vendor code or NULL - NULL or * = all vendors */
	@start_date smalldatetime,	/* Date to Pay range Start */
	@end_date smalldatetime,		/* Date to Pay range End */
	@payment_status smallint,		/* 1 or 2 */

	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

DECLARE
	@DEBUG int

DECLARE
	@found int = 0

BEGIN TRY

SET NOCOUNT ON

SET @ret_val = 0
SET @ret_val_s = 'Success...'

IF @vn_code IN ('', '*')
	SET @vn_code = NULL

IF ISDATE(@start_date) <> 1 BEGIN
	SET @error_msg_w = 'Invalid Start Date.'
	GOTO ERROR_MSG
END

IF ISDATE(@end_date) <> 1 BEGIN
	SET @error_msg_w = 'Invalid End Date.'
	GOTO ERROR_MSG
END

IF @end_date < @start_date BEGIN
	SET @error_msg_w = 'The End Date can not be prior to the Start Date.'
	GOTO ERROR_MSG
END

IF @payment_status NOT IN (1,2) BEGIN
	SET @error_msg_w = 'Invalid Status indicator. The Status must be 1 (Unpaid) or 2 (Paid or Partially Paid).'
	GOTO ERROR_MSG
END

SET @found = 0

IF @vn_code IS NOT NULL
	SELECT @found = 1 FROM [dbo].[VENDOR] WHERE VN_CODE = @vn_code
Else
	SET @found = 1

IF @found < 1 BEGIN
	SET @error_msg_w = 'Invalid Vendor Code.'
	GOTO ERROR_MSG
END


/* PJH 04/13/18 - Added VCCStatus & PaymentStatus to return Dataset */
/* PJH 05/01/20 - Added InvoiceDescription */
IF @payment_status = 1 BEGIN
	/* Unpaid */
	SELECT A.AP_ID, 
	VN_FRL_EMP_CODE VendorCode, 
	AP_INV_VCHR InvoiceNumber, 
	CASE WHEN AP_DESC = '' THEN NULL ELSE AP_DESC END InvoiceDescription,
	AP_INV_AMT InvoiceAmount, 
	AP_INV_DATE InvoiceDate, 
	AP_DATE_PAY InvoiceDateToPay, 
	AP_SALES_TAX TaxAmount, 
	COALESCE(AP_DISC_PCT, 0) DiscountPercent, 
	A.VT_CODE TermsCode, 
	COALESCE(PAYMENT_HOLD, 0) HoldFlag ,
	C.VCC_STATUS VCCStatus,
	@payment_status PaymentStatus
	FROM AP_HEADER A
	LEFT JOIN (
			SELECT AP_ID FROM AP_PMT_HIST A 
			JOIN CHECK_REGISTER B ON A.AP_CHK_NBR = B.CHECK_NBR
			WHERE B.VOID_FLAG IS NULL
			GROUP BY AP_ID
	) B ON A.AP_ID = B.AP_ID
	JOIN VENDOR C ON A.VN_FRL_EMP_CODE = C.VN_CODE
	WHERE A.DELETE_FLAG IS NULL 
			AND (A.AP_DATE_PAY BETWEEN @start_date AND @end_date)
			AND (A.VN_FRL_EMP_CODE = @vn_code OR @vn_code IS NULL)
			AND B.AP_ID IS NULL
END
ELSE BEGIN
	/* Paid or Partially Paid */
	SELECT A.AP_ID,
	VN_FRL_EMP_CODE VendorCode, 
	AP_INV_VCHR InvoiceNumber, 
	CASE WHEN AP_DESC = '' THEN NULL ELSE AP_DESC END InvoiceDescription,
	AP_INV_AMT InvoiceAmount, 
	AP_INV_DATE InvoiceDate, 
	AP_DATE_PAY InvoiceDateToPay, 	
	AP_SALES_TAX TaxAmount, 
	COALESCE(AP_DISC_PCT, 0) DiscountPercent, 
	A.VT_CODE TermsCode, 
	COALESCE(PAYMENT_HOLD, 0) HoldFlag,
	C.VCC_STATUS VCCStatus,
	@payment_status PaymentStatus
	FROM AP_HEADER A
	JOIN (
			SELECT AP_ID FROM AP_PMT_HIST A 
			JOIN CHECK_REGISTER B ON A.AP_CHK_NBR = B.CHECK_NBR
			WHERE B.VOID_FLAG IS NULL
			GROUP BY AP_ID
	) B ON A.AP_ID = B.AP_ID
	JOIN VENDOR C ON A.VN_FRL_EMP_CODE = C.VN_CODE
	WHERE  A.DELETE_FLAG IS NULL 
			AND (A.AP_DATE_PAY BETWEEN @start_date AND @end_date)
			AND (A.VN_FRL_EMP_CODE = @vn_code OR @vn_code IS NULL)
END

GOTO ENDIT
  
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();

	IF @ErMessage IS NOT NULL BEGIN
		SET @ret_val = 1
		SET @ret_val_s = @ErMessage
	END

	SELECT 
	0 AP_ID, 
	NULL VendorCode, 
	@ret_val_s InvoiceNumber, 
	NULL InvoiceDescription,
	NULL InvoiceDate, 
	NULL InvoiceDateToPay, 
	0.00 InvoiceAmount, 
	0.00 TaxAmount, 
	0.00 DiscountPercent, 
	NULL TermsCode, 
	NULL HoldFlag,
	CAST(0 AS smallint) VCCStatus,
	@payment_status PaymentStatus 



END CATCH

RETURN
GO

GRANT EXECUTE ON [advsp_ap_invoice_get_api] TO PUBLIC AS dbo
GO