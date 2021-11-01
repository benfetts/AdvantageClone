



























CREATE PROCEDURE [dbo].[proc_ALERTDelete]
(
	@ALERT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ALERT]
	WHERE
		[ALERT_ID] = @ALERT_ID
	SET @Err = @@Error

	RETURN @Err
END



























