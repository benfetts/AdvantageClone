IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetOpenInvoiceDetails]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetOpenInvoiceDetails]
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetOpenInvoiceDetails]
	@INVOICE_NUMBER VARCHAR(20),
	@BATCH_ID INT
	
AS	
BEGIN	    
	SELECT I.BATCH_ID AS BatchId, BH.BATCH_NAME AS BatchName, I.INVOICE_NUMBER AS InvoiceNumber, 
	BH.USER_ID AS UserId, dbo.advfn_get_emp_name(E.EMP_CODE, 'FML') AS UserName, BH.CREATION_DATE AS CreationDate, BH.LAST_UPDATE_DATE AS LastUpdateDate
	FROM PC_BATCH_INVOICE I WITH (NOLOCK)
		JOIN PC_BATCH_HEADER BH WITH (NOLOCK) ON I.BATCH_ID = BH.BATCH_ID
		JOIN SEC_USER S WITH (NOLOCK) ON S.USER_CODE = BH.USER_ID
		JOIN EMPLOYEE E WITH (NOLOCK) ON E.EMP_CODE = S.EMP_CODE
	WHERE I.INVOICE_NUMBER = @INVOICE_NUMBER
	AND I.BATCH_ID != @BATCH_ID
END

