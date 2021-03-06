



























CREATE PROCEDURE [dbo].[proc_ALERT_RCPTUpdate]
(
	@ALERT_ID int,
	@ALERT_RCPT_ID int,
	@EMP_CODE varchar(6),
	@EMAIL_ADDRESS varchar(50) = NULL,
	@PROCESSED smalldatetime = NULL,
	@NEW_ALERT smallint,
	@READ_ALERT smallint,
	@CURRENT_RCPT smallint,
	@CURRENT_NOTIFY INT
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ALERT_RCPT]
	SET
		[EMP_CODE] = @EMP_CODE,
		[EMAIL_ADDRESS] = @EMAIL_ADDRESS,
		[PROCESSED] = @PROCESSED,
		[NEW_ALERT] = @NEW_ALERT,
		[READ_ALERT] = @READ_ALERT,
		[CURRENT_RCPT] = @CURRENT_RCPT,
		[CURRENT_NOTIFY] = @CURRENT_NOTIFY
	WHERE
		[ALERT_ID] = @ALERT_ID
	AND	[ALERT_RCPT_ID] = @ALERT_RCPT_ID


	SET @Err = @@Error


	RETURN @Err
END



























