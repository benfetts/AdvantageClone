



























CREATE PROCEDURE [dbo].[proc_ALERT_RCPTDelete]
(
	@ALERT_ID int,
	@ALERT_RCPT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ALERT_RCPT]
	WHERE
		[ALERT_ID] = @ALERT_ID AND
		[ALERT_RCPT_ID] = @ALERT_RCPT_ID
	SET @Err = @@Error

	RETURN @Err
END



























