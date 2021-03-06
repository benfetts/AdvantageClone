IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterDeleteBatch]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterDeleteBatch] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterDeleteBatch]	
	@BATCH_ID INT,
	@USER_CODE VARCHAR(6)	
AS

BEGIN
	--Delete Batch Header Record
	BEGIN
		DELETE FROM PC_BATCH_HEADER WITH(ROWLOCK)
		WHERE USER_ID = @USER_CODE
			AND BATCH_ID = @BATCH_ID		
	END			

	--Delete All Batch Invoice records
	BEGIN
		DELETE FROM PC_BATCH_INVOICE WITH(ROWLOCK)
		WHERE USER_ID = @USER_CODE
			AND BATCH_ID = @BATCH_ID		
	END			

	--Delete All Account Selected records
	BEGIN
		DELETE FROM PC_BATCH_GL_SEL WITH(ROWLOCK)
		WHERE USER_ID = @USER_CODE
			AND BATCH_ID = @BATCH_ID		
	END			

	--Delete All Vendor Selected records
	BEGIN
		DELETE FROM PC_BATCH_VENDOR_SEL WITH(ROWLOCK)
		WHERE USER_ID = @USER_CODE
			AND BATCH_ID = @BATCH_ID		
	END			

	--Delete All Client Selected records
	BEGIN
		DELETE FROM PC_BATCH_CLIENT_SEL WITH(ROWLOCK)
		WHERE USER_ID = @USER_CODE
			AND BATCH_ID = @BATCH_ID		
	END			
END
