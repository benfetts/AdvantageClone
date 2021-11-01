
CREATE PROCEDURE [dbo].[advsp_bcc_in_use] ( @bcc_id integer, @setting bit, @ret_val smallint OUTPUT )
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE dbo.BILLING_CMD_CENTER 
	   SET IN_USE = @setting
	 WHERE BCC_ID = @bcc_id

	SET @ret_val = @@ERROR
END
