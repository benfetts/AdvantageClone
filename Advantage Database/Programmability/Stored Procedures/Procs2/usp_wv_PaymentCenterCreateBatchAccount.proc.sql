IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterCreateBatchAccount]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterCreateBatchAccount] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterCreateBatchAccount]	
	@BATCH_ID INT,
	@USER_CODE VARCHAR(6),
	@GL_CODE VARCHAR(10)	

AS

BEGIN	

	--INSERT NEW RECORD
	BEGIN
		INSERT INTO PC_BATCH_GL_SEL WITH(ROWLOCK)
		VALUES(@USER_CODE, @BATCH_ID, @GL_CODE);
	END		
	
END
GO
