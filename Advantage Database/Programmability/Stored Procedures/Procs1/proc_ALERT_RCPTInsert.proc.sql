



























CREATE PROCEDURE [dbo].[proc_ALERT_RCPTInsert]
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

	INSERT
	INTO [ALERT_RCPT]
	(
		[ALERT_ID],
		[ALERT_RCPT_ID],
		[EMP_CODE],
		[EMAIL_ADDRESS],
		[PROCESSED],
		[NEW_ALERT],
		[READ_ALERT],
		[CURRENT_RCPT],
		[CURRENT_NOTIFY]
	)
	VALUES
	(
		@ALERT_ID,
		@ALERT_RCPT_ID,
		@EMP_CODE,
		@EMAIL_ADDRESS,
		@PROCESSED,
		@NEW_ALERT,
		@READ_ALERT,
		@CURRENT_RCPT,
		@CURRENT_NOTIFY
	)

	SET @Err = @@Error


	RETURN @Err
END



























