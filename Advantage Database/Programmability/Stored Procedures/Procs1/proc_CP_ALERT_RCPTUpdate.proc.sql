﻿




CREATE PROCEDURE [dbo].[proc_CP_ALERT_RCPTUpdate]
(
	@ALERT_ID int,
	@ALERT_RCPT_ID int,
	@CDP_CONTACT_ID int,
	@EMAIL_ADDRESS varchar(50) = NULL,
	@PROCESSED smalldatetime = NULL,
	@NEW_ALERT smallint,
	@READ_ALERT smallint,
	@CURRENT_RCPT smallint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [CP_ALERT_RCPT]
	SET
		[CDP_CONTACT_ID] = @CDP_CONTACT_ID,
		[EMAIL_ADDRESS] = @EMAIL_ADDRESS,
		[PROCESSED] = @PROCESSED,
		[NEW_ALERT] = @NEW_ALERT,
		[READ_ALERT] = @READ_ALERT,
		[CURRENT_RCPT] = @CURRENT_RCPT
	WHERE
		[ALERT_ID] = @ALERT_ID
	AND	[ALERT_RCPT_ID] = @ALERT_RCPT_ID


	SET @Err = @@Error


	RETURN @Err
END





