



























CREATE PROCEDURE [dbo].[proc_ALERT_TYPEUpdate]
(
	@ALERT_TYPE_ID int,
	@ALERT_TYPE_DESC varchar(40)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ALERT_TYPE]
	SET
		[ALERT_TYPE_DESC] = @ALERT_TYPE_DESC
	WHERE
		[ALERT_TYPE_ID] = @ALERT_TYPE_ID


	SET @Err = @@Error


	RETURN @Err
END



























