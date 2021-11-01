
CREATE PROCEDURE [dbo].[advsp_update_bill_sel_inv_pp] @billing_user varchar(100), @post_period varchar(6),
	@invoice_date smalldatetime, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

SELECT @ret_val = 0

 UPDATE dbo.BILLING 
    SET INV_DATE = @invoice_date, 
		POST_PERIOD = @post_period
  WHERE BILLING_USER = @billing_user

IF ( @@ERROR <> 0 )
	SELECT @ret_val = @@ERROR
