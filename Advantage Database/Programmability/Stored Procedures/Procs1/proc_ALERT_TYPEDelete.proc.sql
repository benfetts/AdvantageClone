



























CREATE PROCEDURE [dbo].[proc_ALERT_TYPEDelete]
(
	@ALERT_TYPE_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ALERT_TYPE]
	WHERE
		[ALERT_TYPE_ID] = @ALERT_TYPE_ID
	SET @Err = @@Error

	RETURN @Err
END



























