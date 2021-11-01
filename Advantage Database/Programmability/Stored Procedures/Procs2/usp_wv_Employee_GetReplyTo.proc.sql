﻿
CREATE PROCEDURE [dbo].[usp_wv_Employee_GetReplyTo] /*WITH ENCRYPTION*/
@EMP_CODE VARCHAR(6)
AS
/*=========== QUERY ===========*/
	DECLARE @LISTENER_ADDRESS VARCHAR(50), @SMTP_SENDER VARCHAR(50), @SMTP_REPLY_TO VARCHAR(50)

	SELECT @LISTENER_ADDRESS = POP3_USERNAME, @SMTP_SENDER = SMTP_SENDER, @SMTP_REPLY_TO = EMAIL_REPLY_TO
	FROM   AGENCY WITH(NOLOCK);

	SELECT ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') 
		   + ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + COALESCE(COALESCE(COALESCE(COALESCE(@LISTENER_ADDRESS, EMPLOYEE.EMAIL_REPLY_TO), EMPLOYEE.EMP_EMAIL),@SMTP_REPLY_TO),@SMTP_SENDER)
		   + '>' AS MAILBEE_TITLE
		   --,  COALESCE(@LISTENER_ADDRESS, EMPLOYEE.EMP_EMAIL) AS EMAIL
	FROM   EMPLOYEE WITH(NOLOCK)
	WHERE  EMP_CODE = @EMP_CODE;
/*=========== QUERY ===========*/
