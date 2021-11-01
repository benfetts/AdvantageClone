



























CREATE PROCEDURE [dbo].[proc_ALERT_CATEGORYDelete]
(
	@ALERT_CAT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ALERT_CATEGORY]
	WHERE
		[ALERT_CAT_ID] = @ALERT_CAT_ID
	SET @Err = @@Error

	RETURN @Err
END



























