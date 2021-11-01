



























CREATE PROCEDURE [dbo].[proc_ALERT_TYPELoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ALERT_TYPE_ID],
		[ALERT_TYPE_DESC]
	FROM [ALERT_TYPE]

	SET @Err = @@Error

	RETURN @Err
END



























