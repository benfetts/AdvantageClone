
CREATE PROCEDURE [dbo].[advsp_delete_bill_select]
	@bill_user_in varchar(100),
	@ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @errcode integer

SELECT @errcode = 0

IF @errcode = 0
BEGIN
	UPDATE dbo.EMP_TIME_DTL
	   SET BILLING_USER = NULL
	 WHERE BILLING_USER = @bill_user_in
	 
	SELECT @errcode = @@ERROR	
END

IF @errcode = 0
BEGIN
	UPDATE dbo.AP_PRODUCTION 
	   SET BILLING_USER = NULL
	 WHERE BILLING_USER = @bill_user_in
	 
	SELECT @errcode = @@ERROR
END

IF @errcode = 0
BEGIN
	UPDATE dbo.INCOME_ONLY 
	   SET BILLING_USER = NULL
	 WHERE BILLING_USER = @bill_user_in
	 
	SELECT @errcode = @@ERROR
END	

IF @errcode = 0
BEGIN
	UPDATE dbo.ADVANCE_BILLING 
	   SET BILLING_USER = NULL
	 WHERE BILLING_USER = @bill_user_in
	 
	SELECT @errcode = @@ERROR
END	

IF @errcode = 0
BEGIN
	UPDATE dbo.INCOME_REC 
	   SET BILLING_USER = NULL
	 WHERE BILLING_USER = @bill_user_in
	 
	SELECT @errcode = @@ERROR
END	

IF @errcode = 0
BEGIN
	UPDATE dbo.JOB_COMPONENT 
	   SET BILLING_USER = NULL
	 WHERE BILLING_USER = @bill_user_in
	 
	SELECT @errcode = @@ERROR
END	

IF @errcode = 0
BEGIN
	DELETE FROM dbo.BILLING 
	 WHERE BILLING_USER = @bill_user_in
	
	SELECT @errcode = @@ERROR
END	

