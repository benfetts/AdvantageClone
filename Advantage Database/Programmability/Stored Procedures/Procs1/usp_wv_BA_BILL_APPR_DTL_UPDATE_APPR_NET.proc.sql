
CREATE PROCEDURE [dbo].[usp_wv_BA_BILL_APPR_DTL_UPDATE_APPR_NET] 
	@BA_DTL_ID AS INTEGER,
	@APPR_NET AS DECIMAL(14,2)
AS


	UPDATE BILL_APPR_DTL WITH(ROWLOCK)
	SET
		APPR_NET = @APPR_NET
	WHERE
		BA_DTL_ID = @BA_DTL_ID;
		
		
