



























CREATE PROCEDURE [dbo].[proc_ALERT_RCPTLoadAll]
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

	SET @Err = @@Error

	RETURN @Err
END



























