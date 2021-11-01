
CREATE PROCEDURE [dbo].[advsp_bcc_clear_billing_user] @bcc_id_in integer, @billing_user varchar(100), @prod bit, @media bit, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

SELECT @ret_val = 0

IF ( @prod = 1 )
BEGIN
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.AP_PRODUCTION
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user
		   AND EXISTS ( SELECT * 
						  FROM dbo.JOB_COMPONENT jc
						 WHERE jc.JOB_NUMBER = dbo.AP_PRODUCTION.JOB_NUMBER
						   AND jc.JOB_COMPONENT_NBR = dbo.AP_PRODUCTION.JOB_COMPONENT_NBR
						   AND ( jc.BILLING_USER = dbo.AP_PRODUCTION.BILLING_USER OR jc.BILLING_USER IS NULL )
						   AND ( jc.BCC_ID IS NULL OR jc.BCC_ID <> @bcc_id_in ))

		SELECT @ret_val = @@ERROR
	END	

	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.EMP_TIME_DTL
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user
		   AND EXISTS ( SELECT * 
						  FROM dbo.JOB_COMPONENT jc
						 WHERE jc.JOB_NUMBER = dbo.EMP_TIME_DTL.JOB_NUMBER
						   AND jc.JOB_COMPONENT_NBR = dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR
						   AND ( jc.BILLING_USER = dbo.EMP_TIME_DTL.BILLING_USER OR jc.BILLING_USER IS NULL )
						   AND ( jc.BCC_ID IS NULL OR jc.BCC_ID <> @bcc_id_in ))

		SELECT @ret_val = @@ERROR
	END	

	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.INCOME_ONLY
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user
		   AND EXISTS ( SELECT * 
						  FROM dbo.JOB_COMPONENT jc
						 WHERE jc.JOB_NUMBER = dbo.INCOME_ONLY.JOB_NUMBER
						   AND jc.JOB_COMPONENT_NBR = dbo.INCOME_ONLY.JOB_COMPONENT_NBR
						   AND ( jc.BILLING_USER = dbo.INCOME_ONLY.BILLING_USER OR jc.BILLING_USER IS NULL )
						   AND ( jc.BCC_ID IS NULL OR jc.BCC_ID <> @bcc_id_in ))

		SELECT @ret_val = @@ERROR
	END	

	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.ADVANCE_BILLING
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user
		   AND EXISTS ( SELECT * 
						  FROM dbo.JOB_COMPONENT jc
						 WHERE jc.JOB_NUMBER = dbo.ADVANCE_BILLING.JOB_NUMBER
						   AND jc.JOB_COMPONENT_NBR = dbo.ADVANCE_BILLING.JOB_COMPONENT_NBR
						   AND ( jc.BILLING_USER = dbo.ADVANCE_BILLING.BILLING_USER OR jc.BILLING_USER IS NULL )
						   AND ( jc.BCC_ID IS NULL OR jc.BCC_ID <> @bcc_id_in ))

		SELECT @ret_val = @@ERROR
	END	

	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.INCOME_REC
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user
		   AND EXISTS ( SELECT * 
						  FROM dbo.JOB_COMPONENT jc
						 WHERE jc.JOB_NUMBER = dbo.INCOME_REC.JOB_NUMBER
						   AND jc.JOB_COMPONENT_NBR = dbo.INCOME_REC.JOB_COMPONENT_NBR
						   AND ( jc.BILLING_USER = dbo.INCOME_REC.BILLING_USER OR jc.BILLING_USER IS NULL )
						   AND ( jc.BCC_ID IS NULL OR jc.BCC_ID <> @bcc_id_in ))

		SELECT @ret_val = @@ERROR
	END	

	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.JOB_COMPONENT
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user
		   AND ( BCC_ID IS NULL OR BCC_ID <> @bcc_id_in )
		
		SELECT @ret_val = @@ERROR
	END
END

IF ( @media = 1 )
BEGIN
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.RADIO_DETAIL1
		   SET BILLING_USER = NULL,
			   BILL_MONTHS = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.TV_DETAIL1
		   SET BILLING_USER = NULL,
			   BILL_MONTHS = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END		
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.NEWSPAPER_DETAIL
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END

	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.MAGAZINE_DETAIL
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END			
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.OUTDOOR_DETAIL
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.INTERNET_DETAIL
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.RADIO_DETAIL
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END
	
	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.TV_DETAIL
		   SET BILLING_USER = NULL
		 WHERE BILLING_USER = @billing_user

		SELECT @ret_val = @@ERROR
	END	
END

IF ( @ret_val = 0 )
	EXECUTE dbo.advsp_bill_select_delete @billing_user = @billing_user, @ret_val = @ret_val OUTPUT
