



























CREATE PROCEDURE [dbo].[proc_ALERT_COMMENTDelete]
(
	@COMMENT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ALERT_COMMENT]
	WHERE
		[COMMENT_ID] = @COMMENT_ID
	SET @Err = @@Error

	RETURN @Err
END



























