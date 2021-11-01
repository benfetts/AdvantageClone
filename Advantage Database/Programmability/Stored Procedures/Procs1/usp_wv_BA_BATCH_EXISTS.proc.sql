﻿
CREATE PROCEDURE [dbo].[usp_wv_BA_BATCH_EXISTS] 
	@BA_BATCH_ID INT


AS

DECLARE
	@BATCH_EXISTS INT
	
	SELECT @BATCH_EXISTS = ISNULL(COUNT(1),0) FROM BILL_APPR_BATCH WITH(NOLOCK) WHERE BA_BATCH_ID = @BA_BATCH_ID;
	
IF @BATCH_EXISTS > 0
	BEGIN
		SELECT 1
	END
ELSE
	BEGIN
		SELECT 0
	END

