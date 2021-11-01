

CREATE PROCEDURE [dbo].[usp_wv_DocumentManager_AddAdNumberDocument]
@AD_NBR VARCHAR(30),
@DOCUMENT_ID INT
AS

    UPDATE 
        AD_NUMBER WITH(ROWLOCK)
    SET
        DOCUMENT_ID = @DOCUMENT_ID
    WHERE 
		(AD_NBR = @AD_NBR)



