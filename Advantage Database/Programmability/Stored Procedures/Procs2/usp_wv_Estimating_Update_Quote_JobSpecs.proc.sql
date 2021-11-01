﻿

CREATE PROCEDURE [dbo].[usp_wv_Estimating_Update_Quote_JobSpecs]
(
	@ESTIMATE_NUMBER INT,
	@EST_COMPONENT_NBR INT,
	@EST_QUOTE_NBR INT,
	@EST_REV_NBR INT,
	@SPEC_VER INT,
	@SPEC_REV INT,
	@SPEC_QTY_SEQ_NBR INT,
	@JOB_QTY INT,
	@USER_ID VARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT OFF
	DECLARE 
	@ERR INT,
	@NEXT_EST_NBR INT
	
    --SELECT @NEXT_EST_NBR = ISNULL(MAX(ESTIMATE_NUMBER),-1) + 1 FROM ESTIMATE_LOG 
    
    	
	UPDATE [ESTIMATE_REV]
	SET	[SPEC_VER] = @SPEC_VER,
		[SPEC_REV] = @SPEC_REV,
		[SPEC_QTY_SEQ_NBR] = @SPEC_QTY_SEQ_NBR,
		[JOB_QTY] = @JOB_QTY
	WHERE [ESTIMATE_NUMBER] = @ESTIMATE_NUMBER AND
		  [EST_COMPONENT_NBR] = @EST_COMPONENT_NBR AND
		  [EST_QUOTE_NBR] = @EST_QUOTE_NBR AND
		  [EST_REV_NBR] = @EST_REV_NBR
			
			
			

	SET @ERR = @@Error

	--RETURN @ERR
END

--SELECT @QTE_NUM = @NEXT_EST_NBR


