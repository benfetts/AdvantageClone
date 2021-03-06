IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterClientExistsForInvoice]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterClientExistsForInvoice] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterClientExistsForInvoice]	
	@INVOICE_TYPE VARCHAR(50),
	@AP_ID INT,
	@CLIENT_CODE VARCHAR(6)

AS

DECLARE @CLIENT_EXISTS AS INTEGER

BEGIN
	IF @INVOICE_TYPE = 'Production'
		BEGIN
			SELECT DISTINCT @CLIENT_EXISTS = 1
			FROM AP_PRODUCTION AP WITH (NOLOCK) JOIN AP_HEADER H WITH (NOLOCK) ON AP.AP_ID = H.AP_ID
			JOIN JOB_LOG J ON J.JOB_NUMBER = AP.JOB_NUMBER
			WHERE AP.AP_ID = @AP_ID
			AND J.CL_CODE = @CLIENT_CODE
		END
	IF @INVOICE_TYPE = 'Internet'
		BEGIN
			SELECT DISTINCT @CLIENT_EXISTS = 1
			FROM AP_INTERNET AP WITH (NOLOCK) JOIN INTERNET_HEADER H WITH (NOLOCK) ON AP.ORDER_NBR = H.ORDER_NBR			
			WHERE AP.AP_ID = @AP_ID
			AND H.CL_CODE = @CLIENT_CODE
		END
	IF @INVOICE_TYPE = 'Newspaper'
		BEGIN
			SELECT DISTINCT @CLIENT_EXISTS = 1
			FROM AP_NEWSPAPER AP WITH (NOLOCK) JOIN NEWSPAPER_HEADER H WITH (NOLOCK) ON AP.ORDER_NBR = H.ORDER_NBR			
			WHERE AP.AP_ID = @AP_ID
			AND H.CL_CODE = @CLIENT_CODE
		END
	IF @INVOICE_TYPE = 'Magazine'
		BEGIN
			SELECT DISTINCT @CLIENT_EXISTS = 1
			FROM AP_MAGAZINE AP WITH (NOLOCK) JOIN MAGAZINE_HEADER H WITH (NOLOCK) ON AP.ORDER_NBR = H.ORDER_NBR			
			WHERE AP.AP_ID = @AP_ID
			AND H.CL_CODE = @CLIENT_CODE
		END
	IF @INVOICE_TYPE = 'Radio'
		BEGIN
			SELECT DISTINCT @CLIENT_EXISTS = 1
			FROM AP_RADIO AP WITH (NOLOCK) JOIN RADIO_HEADER H WITH (NOLOCK) ON AP.ORDER_NBR = H.ORDER_NBR			
			WHERE AP.AP_ID = @AP_ID
			AND H.CL_CODE = @CLIENT_CODE
		END
	IF @INVOICE_TYPE = 'Television'
		BEGIN
			SELECT DISTINCT @CLIENT_EXISTS = 1
			FROM AP_TV AP WITH (NOLOCK) JOIN TV_HEADER H WITH (NOLOCK) ON AP.ORDER_NBR = H.ORDER_NBR			
			WHERE AP.AP_ID = @AP_ID
			AND H.CL_CODE = @CLIENT_CODE
		END
	IF @INVOICE_TYPE = 'Outdoor'
		BEGIN
			SELECT DISTINCT @CLIENT_EXISTS = 1
			FROM AP_OUTDOOR AP WITH (NOLOCK) JOIN OUTDOOR_HEADER H WITH (NOLOCK) ON AP.ORDER_NBR = H.ORDER_NBR			
			WHERE AP.AP_ID = @AP_ID
			AND H.CL_CODE = @CLIENT_CODE
		END

	SELECT COALESCE(@CLIENT_EXISTS, 0) AS CLIENT_EXISTS
END		
GO
