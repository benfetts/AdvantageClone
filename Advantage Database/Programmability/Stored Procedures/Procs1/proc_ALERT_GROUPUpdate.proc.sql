



























CREATE PROCEDURE [dbo].[proc_ALERT_GROUPUpdate]
(
	@E_GROUP varchar(50),
	@ALERT_CAT_ID int,
	@ACTIVE_FLAG smallint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ALERT_GROUP]
	SET
		[ACTIVE_FLAG] = @ACTIVE_FLAG
	WHERE
		[ALERT_CAT_ID] = @ALERT_CAT_ID
	AND	[E_GROUP] = @E_GROUP


	SET @Err = @@Error


	RETURN @Err
END



























