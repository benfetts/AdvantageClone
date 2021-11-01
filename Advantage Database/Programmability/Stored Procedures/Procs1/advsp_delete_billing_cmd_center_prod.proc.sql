CREATE PROCEDURE [dbo].[advsp_delete_billing_cmd_center_prod] @bill_user_in varchar(100), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @bcc_id integer

SELECT @bcc_id = ( SELECT BCC_ID FROM dbo.BILLING_CMD_CENTER WHERE BILLING_USER = @bill_user_in )

 UPDATE dbo.AP_PRODUCTION
    SET BCC_ID = NULL
  WHERE BCC_ID = @bcc_id    

 UPDATE dbo.EMP_TIME_DTL
    SET BCC_ID = NULL
  WHERE BCC_ID = @bcc_id
 
 UPDATE dbo.INCOME_ONLY
    SET BCC_ID = NULL
  WHERE BCC_ID = @bcc_id   
 
 UPDATE dbo.ADVANCE_BILLING
    SET BCC_ID = NULL
  WHERE BCC_ID = @bcc_id    

 UPDATE dbo.INCOME_REC
    SET BCC_ID = NULL
  WHERE BCC_ID = @bcc_id
 
 UPDATE dbo.JOB_COMPONENT
    SET BCC_ID = NULL,
		SELECTED_BA_ID = NULL
  WHERE BCC_ID = @bcc_id    

