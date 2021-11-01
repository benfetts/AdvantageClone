CREATE PROCEDURE [dbo].[advsp_delete_ar_function] @bill_user_in varchar(100), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DELETE FROM dbo.W_AR_FUNCTION WHERE BILLING_USER = @bill_user_in
SET @ret_val = @@ERROR

GO
