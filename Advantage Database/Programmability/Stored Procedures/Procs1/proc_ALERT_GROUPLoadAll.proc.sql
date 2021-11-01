



























CREATE PROCEDURE [dbo].[proc_ALERT_GROUPLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[E_GROUP],
		[ALERT_CAT_ID],
		[ACTIVE_FLAG]
	FROM [ALERT_GROUP]

	SET @Err = @@Error

	RETURN @Err
END



























