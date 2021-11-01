﻿
CREATE PROCEDURE [dbo].[usp_wv_BA_BILL_APPR_HDR_UPDATE] 
@BA_HDR_ID AS INTEGER,
@APPROVED_AMT AS DECIMAL(15,2),
@APPR_COMMENTS AS TEXT,
@CLIENT_COMMENTS AS TEXT,
@BILL_TYPE AS TINYINT,
@APPR_STATUS AS SMALLINT
AS			

--SET @APPR_STATUS = ISNULL(@APPR_STATUS,99)
IF @APPR_STATUS = 0
BEGIN
	SET @APPR_STATUS = NULL
END

IF @APPR_STATUS = 99 --DON'T CHANGE THE APPR_STATUS
	BEGIN
		UPDATE 
			BILL_APPR_HDR WITH(ROWLOCK)
		SET
			APPROVED_AMT = @APPROVED_AMT,
			APPR_COMMENTS = @APPR_COMMENTS,
			CLIENT_COMMENTS = @CLIENT_COMMENTS,
			BILL_TYPE = @BILL_TYPE
		WHERE
			BILL_APPR_HDR.BA_HDR_ID = @BA_HDR_ID;
	END
ELSE
	BEGIN
		UPDATE 
			BILL_APPR_HDR WITH(ROWLOCK)
		SET
			APPROVED_AMT = @APPROVED_AMT,
			APPR_COMMENTS = @APPR_COMMENTS,
			CLIENT_COMMENTS = @CLIENT_COMMENTS,
			BILL_TYPE = @BILL_TYPE,
			APPR_STATUS = @APPR_STATUS
		WHERE
			BILL_APPR_HDR.BA_HDR_ID = @BA_HDR_ID;
	END

	
	
