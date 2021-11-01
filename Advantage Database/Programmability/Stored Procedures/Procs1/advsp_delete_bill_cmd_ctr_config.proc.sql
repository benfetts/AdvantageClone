
CREATE PROCEDURE [dbo].[advsp_delete_bill_cmd_ctr_config]
	@bill_user_in varchar(100),
	@ret_val integer OUTPUT 
AS

SET NOCOUNT ON

	DELETE FROM dbo.BILL_CMD_CTR_CONFIG 
		  WHERE BILLING_USER = @bill_user_in
	  
