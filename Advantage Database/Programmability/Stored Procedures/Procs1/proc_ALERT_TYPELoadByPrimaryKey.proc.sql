



























CREATE PROCEDURE [dbo].[proc_ALERT_TYPELoadByPrimaryKey]
(
	@ALERT_TYPE_ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ALERT_TYPE_ID],
		[ALERT_TYPE_DESC]
	FROM [ALERT_TYPE]
	WHERE
		([ALERT_TYPE_ID] = @ALERT_TYPE_ID)

	SET @Err = @@Error

	RETURN @Err
END



























