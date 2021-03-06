
CREATE PROCEDURE [dbo].[usp_wv_Employee_GetFromAddress] /*WITH ENCRYPTION*/
	@EMP_CODE VARCHAR(6)
AS
/*=========== QUERY ===========*/
	DECLARE 
		@SMTP_USE_EMP_LOGIN SMALLINT,
		@DEFAULT_SENDER_ADDRESS VARCHAR(50),
		@EMAIL_TO_USE VARCHAR(50),
		@RETURN_VALUE VARCHAR(1500)
		
	SELECT 
		@SMTP_USE_EMP_LOGIN = ISNULL(SMTP_USE_EMP_LOGIN,0), 
		@DEFAULT_SENDER_ADDRESS = SMTP_SENDER
	FROM   
		AGENCY WITH(NOLOCK);
	
	IF @SMTP_USE_EMP_LOGIN = 1 
	BEGIN
		SELECT  @EMAIL_TO_USE = COALESCE(EMPLOYEE.EMP_EMAIL, @DEFAULT_SENDER_ADDRESS) 
		FROM   EMPLOYEE WITH(NOLOCK)
		WHERE EMP_CODE = @EMP_CODE;
	END
	
	IF @SMTP_USE_EMP_LOGIN = 0
	BEGIN
		SET  @EMAIL_TO_USE = @DEFAULT_SENDER_ADDRESS;
	END
	
	
	SELECT @RETURN_VALUE = ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') 
			   + ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + @EMAIL_TO_USE
			   + '>' 
		FROM   EMPLOYEE WITH(NOLOCK)
		WHERE EMP_CODE = @EMP_CODE;
	
	SELECT @RETURN_VALUE;
/*=========== QUERY ===========*/
