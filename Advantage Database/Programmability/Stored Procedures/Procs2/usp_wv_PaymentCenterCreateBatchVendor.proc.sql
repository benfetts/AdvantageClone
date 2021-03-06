IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterCreateBatchVendor]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterCreateBatchVendor] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterCreateBatchVendor]	
	@BATCH_ID INT,
	@USER_CODE VARCHAR(6),
	@VENDOR_CODE VARCHAR(10)	

AS

BEGIN	

	--INSERT NEW RECORD
	BEGIN
		INSERT INTO PC_BATCH_VENDOR_SEL WITH(ROWLOCK)
		VALUES(@USER_CODE, @BATCH_ID, @VENDOR_CODE);
	END		
	
END
GO
