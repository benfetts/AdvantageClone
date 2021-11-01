



























CREATE PROCEDURE [dbo].[proc_ALERT_GROUPDelete]
(
	@ALERT_CAT_ID int,
	@E_GROUP varchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ALERT_GROUP]
	WHERE
		[ALERT_CAT_ID] = @ALERT_CAT_ID AND
		[E_GROUP] = @E_GROUP
	SET @Err = @@Error

	RETURN @Err
END



























