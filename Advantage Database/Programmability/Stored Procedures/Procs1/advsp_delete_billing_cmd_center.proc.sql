
CREATE PROCEDURE [dbo].[advsp_delete_billing_cmd_center]
	@bill_user_in varchar(100),
	@ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @bcc_id integer, @ret_val_arg integer

SELECT @bcc_id = ( SELECT BCC_ID FROM dbo.BILLING_CMD_CENTER WHERE BILLING_USER = @bill_user_in )
SET @ret_val = @@ERROR

IF ( @ret_val = 0 )
BEGIN
	EXECUTE dbo.advsp_delete_billing_cmd_center_media @bill_user_in = @bill_user_in, @ret_val = @ret_val_arg OUTPUT
	SET @ret_val = @@ERROR
END	  

IF ( @ret_val = 0 )
BEGIN
	EXECUTE dbo.advsp_delete_billing_cmd_center_prod @bill_user_in = @bill_user_in, @ret_val = @ret_val_arg OUTPUT
	SET @ret_val = @@ERROR
END	

IF ( @ret_val = 0 )
BEGIN
	DELETE FROM dbo.BILLING_CMD_CENTER 
		  WHERE BCC_ID = @bcc_id
	SET @ret_val = @@ERROR
END
