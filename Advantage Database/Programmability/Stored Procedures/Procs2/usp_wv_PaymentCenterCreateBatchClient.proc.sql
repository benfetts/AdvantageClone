IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterCreateBatchClient]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterCreateBatchClient] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterCreateBatchClient]	
	@BATCH_ID INT,
	@USER_CODE VARCHAR(6)	

AS

	--INSERT NEW RECORD
	BEGIN
		INSERT INTO PC_BATCH_CLIENT_SEL WITH(ROWLOCK)
			SELECT DISTINCT @USER_CODE, @BATCH_ID, CL_CODE FROM (
			SELECT DISTINCT H.CL_CODE
			FROM AP_INTERNET AP WITH (NOLOCK) JOIN PC_BATCH_INVOICE I WITH (NOLOCK) ON AP.AP_ID = I.AP_ID
			JOIN INTERNET_HEADER H WITH (NOLOCK) ON H.ORDER_NBR = AP.ORDER_NBR
			UNION
			SELECT DISTINCT H.CL_CODE
			FROM AP_NEWSPAPER AP WITH (NOLOCK) JOIN PC_BATCH_INVOICE I WITH (NOLOCK) ON AP.AP_ID = I.AP_ID
			JOIN NEWSPAPER_HEADER H WITH (NOLOCK) ON H.ORDER_NBR = AP.ORDER_NBR
			UNION
			SELECT DISTINCT H.CL_CODE
			FROM AP_MAGAZINE AP WITH (NOLOCK) JOIN PC_BATCH_INVOICE I WITH (NOLOCK) ON AP.AP_ID = I.AP_ID
			JOIN MAGAZINE_HEADER H WITH (NOLOCK) ON H.ORDER_NBR = AP.ORDER_NBR
			UNION
			SELECT DISTINCT H.CL_CODE
			FROM AP_RADIO AP WITH (NOLOCK) JOIN PC_BATCH_INVOICE I WITH (NOLOCK) ON AP.AP_ID = I.AP_ID
			JOIN RADIO_HDR H WITH (NOLOCK) ON H.ORDER_NBR = AP.ORDER_NBR
			--RADIO_HEADER IS A LEGACY TABLE
			UNION
			SELECT DISTINCT H.CL_CODE
			FROM AP_TV AP WITH (NOLOCK) JOIN PC_BATCH_INVOICE I WITH (NOLOCK) ON AP.AP_ID = I.AP_ID
			JOIN TV_HDR H WITH (NOLOCK) ON H.ORDER_NBR = AP.ORDER_NBR
			--TV_HEADER IS A LEGACY TABLE
			UNION
			SELECT DISTINCT H.CL_CODE
			FROM AP_OUTDOOR AP WITH (NOLOCK) JOIN PC_BATCH_INVOICE I WITH (NOLOCK) ON AP.AP_ID = I.AP_ID
			JOIN OUTDOOR_HEADER H ON H.ORDER_NBR = AP.ORDER_NBR
			UNION
			SELECT DISTINCT J.CL_CODE
			FROM AP_PRODUCTION AP WITH (NOLOCK) JOIN PC_BATCH_INVOICE I WITH (NOLOCK) ON AP.AP_ID = I.AP_ID
			JOIN AP_HEADER H WITH (NOLOCK) ON H.AP_ID = AP.AP_ID
			JOIN JOB_LOG J WITH (NOLOCK) ON J.JOB_NUMBER = AP.JOB_NUMBER) A
	END			
