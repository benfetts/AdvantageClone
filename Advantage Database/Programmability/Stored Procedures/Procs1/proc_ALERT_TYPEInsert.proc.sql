



























CREATE PROCEDURE [dbo].[proc_ALERT_TYPEInsert]
(
	@ALERT_TYPE_ID int,
	@ALERT_TYPE_DESC varchar(40)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ALERT_TYPE]
	(
		[ALERT_TYPE_ID],
		[ALERT_TYPE_DESC]
	)
	VALUES
	(
		@ALERT_TYPE_ID,
		@ALERT_TYPE_DESC
	)

	SET @Err = @@Error


	RETURN @Err
END



























