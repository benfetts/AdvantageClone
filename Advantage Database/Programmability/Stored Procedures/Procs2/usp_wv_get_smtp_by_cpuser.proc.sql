CREATE PROCEDURE [dbo].[usp_wv_get_smtp_by_cpuser] 
	@UserID as Varchar(100) 
AS

	DECLARE @SMTP_SERVER         VARCHAR(40),
			@SMTP_SENDER         VARCHAR(50),
			@EMAIL_USERNAME      VARCHAR(50),
			@EMAIL_PWD           VARCHAR(50),
			@SMTP_AUTH_METHOD    SMALLINT,
			@SMTP_PORT_NUMBER    SMALLINT,
			@EMAIL_REPLY_TO      VARCHAR(50),
			@SMTP_SECURE_TYPE    SMALLINT,
			@SMTP_USE_EMP_FROM   SMALLINT,
			@USE_SMTP_FOR_PDF    SMALLINT,
			@MB_KEY              VARCHAR(50),
			@SMTP_USE_EMP_LOGIN  SMALLINT,
			@POP3_SERVER         VARCHAR(40),
			@POP3_USERNAME       VARCHAR(50),
			@POP3_PWD            VARCHAR(25),
			@POP3_REPLY_TO       VARCHAR(50)

	SELECT @SMTP_SERVER = ISNULL(SMTP_SERVER, ''),
		   @SMTP_SENDER = ISNULL(SMTP_SENDER, ''),
		   @EMAIL_USERNAME = ISNULL(EMAIL_USERNAME, ''),
		   @EMAIL_PWD = ISNULL(EMAIL_PWD, ''),
		   @SMTP_AUTH_METHOD = CASE WHEN SMTP_AUTH_METHOD IS NULL THEN 16
									WHEN SMTP_AUTH_METHOD = 0 THEN 0
									WHEN SMTP_AUTH_METHOD = 1 THEN 16
									WHEN SMTP_AUTH_METHOD = 2 THEN 8
									WHEN SMTP_AUTH_METHOD = 3 THEN 32
									WHEN SMTP_AUTH_METHOD = 4 THEN 128
									WHEN SMTP_AUTH_METHOD = 5 THEN 256 ELSE 1 END,
		   @SMTP_PORT_NUMBER = ISNULL(SMTP_PORT_NUMBER, 0),
		   @EMAIL_REPLY_TO = ISNULL(EMAIL_REPLY_TO, ''),
		   @SMTP_SECURE_TYPE = ISNULL(SMTP_SECURE_TYPE, 0),
		   @SMTP_USE_EMP_FROM = ISNULL(SMTP_USE_EMP_FROM, 0),
		   @USE_SMTP_FOR_PDF = ISNULL(USE_SMTP_FOR_PDF, 0),
		   @MB_KEY = MB_KEY,
		   @SMTP_USE_EMP_LOGIN = ISNULL(SMTP_USE_EMP_LOGIN, 0),
		   @POP3_SERVER = POP3_SERVER,
		   @POP3_USERNAME = POP3_USERNAME,
		   @POP3_PWD = POP3_PWD,
		   @POP3_REPLY_TO = POP3_REPLY_TO
	FROM   AGENCY WITH(NOLOCK);



	DECLARE @EMP_EMAIL_REPLY_TO 	VARCHAR(50)

	SELECT 
		@EMP_EMAIL_REPLY_TO =  CDPC.EMAIL_ADDRESS
	FROM 
		dbo.CP_USER CP INNER JOIN 
		dbo.CDP_CONTACT_HDR CDPC ON CDPC.CDP_CONTACT_ID =  CP.CDP_CONTACT_ID
	WHERE 
		CP.[USER_NAME] = @UserID

	IF @POP3_SERVER IS NOT NULL AND 
		@POP3_USERNAME IS NOT NULL AND 
		@POP3_PWD IS NOT NULL BEGIN
		--USING LISTENER ACCOUNT
		SET @EMAIL_REPLY_TO = @POP3_REPLY_TO;
		
	END ELSE BEGIN 
				
		IF @EMP_EMAIL_REPLY_TO IS NOT NULL BEGIN

			SET @EMAIL_REPLY_TO = @EMP_EMAIL_REPLY_TO
			
		END

	END

	SELECT  
		@SMTP_SERVER AS SMTP_SERVER, 
		@SMTP_SENDER AS SMTP_SENDER, 
		@EMAIL_USERNAME AS EMAIL_USERNAME, 
		@EMAIL_PWD AS EMAIL_PWD, 
		@SMTP_AUTH_METHOD AS SMTP_AUTH_METHOD, 
		@SMTP_PORT_NUMBER AS SMTP_PORT_NUMBER,
		@EMAIL_REPLY_TO AS EMAIL_REPLY_TO, 
		@SMTP_SECURE_TYPE AS SMTP_SECURE_TYPE,
		@SMTP_USE_EMP_FROM AS SMTP_USE_EMP_FROM, 
		@USE_SMTP_FOR_PDF AS USE_SMTP_FOR_PDF,
		@MB_KEY AS MB_KEY,
		@SMTP_USE_EMP_LOGIN AS SMTP_USE_EMP_LOGIN
		
GO


