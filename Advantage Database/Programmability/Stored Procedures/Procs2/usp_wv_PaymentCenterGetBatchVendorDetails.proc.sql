IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetBatchVendorDetails]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetBatchVendorDetails]
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetBatchVendorDetails]

@USER_ID VARCHAR(100),
@BATCH_ID INTEGER,
@PAYMENT_MODULE VARCHAR(2)

AS

BEGIN
	IF @PAYMENT_MODULE != 'CW'
		SELECT V.VENDOR_CODE AS Code		
		FROM PC_BATCH_VENDOR_SEL V WITH (NOLOCK)
		WHERE USER_ID = @USER_ID
			AND BATCH_ID = @BATCH_ID
	ELSE
		SELECT PAY_TO_CODE AS Code
		FROM CHECK_REGISTER WITH (NOLOCK)
		WHERE GLEXACT = @BATCH_ID
END



GO
