



























CREATE PROCEDURE [dbo].[proc_ALERT_RCPTLoadByPrimaryKey]
(
	@ALERT_ID int,
	@ALERT_RCPT_ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ALERT_ID],
		[ALERT_RCPT_ID],
		[EMP_CODE],
		[EMAIL_ADDRESS],
		[PROCESSED],
		[NEW_ALERT],
		[READ_ALERT],
		[CURRENT_RCPT],[CURRENT_NOTIFY]
	FROM [ALERT_RCPT]
	WHERE
		([ALERT_ID] = @ALERT_ID) AND
		([ALERT_RCPT_ID] = @ALERT_RCPT_ID)

	SET @Err = @@Error

	RETURN @Err
END



























