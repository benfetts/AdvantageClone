
CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_finish] 
	@billing_user_in varchar(100), @ba_batch_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @rowcount smallint, @finished smallint

SELECT @ret_val = 0

--PJH 07/29/13 - Added AR_COOP_TMP clear
DELETE FROM dbo.AR_COOP_TMP
	WHERE BILLING_USER = @billing_user_in
	IF @@ERROR <> 0 
    BEGIN
		SELECT @ret_val = @@ERROR
    END	

IF ( @ret_val = 0 )
BEGIN

DELETE FROM dbo.BILLING 
 WHERE INV_ASSIGN = 1
   AND BILLING_USER = @billing_user_in	

SET @rowcount = @@ROWCOUNT

IF ( @rowcount = 1 )
BEGIN
	IF ( @ba_batch_id_in > 0 )
	BEGIN
		SELECT @finished = ( SELECT FINISHED FROM dbo.BILL_APPR_BATCH WHERE BA_BATCH_ID = @ba_batch_id_in ) 
		SET @rowcount = @@ROWCOUNT
		IF ( @rowcount = 1 AND @finished = 0 )
		BEGIN
			EXECUTE dbo.usp_wv_BA_BATCH_FINISH @BA_BATCH_ID = @ba_batch_id_in
			SELECT @ret_val = @@ERROR
		END
	END
END
ELSE
	SELECT @ret_val = -1

END


GO
