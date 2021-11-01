



























CREATE PROCEDURE [dbo].[proc_ALERT_GROUPLoadByPrimaryKey]
(
	@ALERT_CAT_ID int,
	@E_GROUP varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[E_GROUP],
		[ALERT_CAT_ID],
		[ACTIVE_FLAG]
	FROM [ALERT_GROUP]
	WHERE
		([ALERT_CAT_ID] = @ALERT_CAT_ID) AND
		([E_GROUP] = @E_GROUP)

	SET @Err = @@Error

	RETURN @Err
END



























