



























CREATE PROCEDURE [dbo].[proc_ALERT_GROUPInsert]
(
	@E_GROUP varchar(50),
	@ALERT_CAT_ID int,
	@ACTIVE_FLAG smallint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ALERT_GROUP]
	(
		[E_GROUP],
		[ALERT_CAT_ID],
		[ACTIVE_FLAG]
	)
	VALUES
	(
		@E_GROUP,
		@ALERT_CAT_ID,
		@ACTIVE_FLAG
	)

	SET @Err = @@Error


	RETURN @Err
END



























