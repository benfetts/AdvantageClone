





CREATE PROCEDURE [dbo].[proc_CP_USER_TABSInsert]
(
	@CDP_CONTACT_ID int,
	@TAB_ID int,
	@NAME varchar(50),
	@STATE text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [CP_USER_TABS]
	(
		[CDP_CONTACT_ID],
		[TAB_ID],
		[NAME],
		[STATE]
	)
	VALUES
	(
		@CDP_CONTACT_ID,
		@TAB_ID,
		@NAME,
		@STATE
	)

	SET @Err = @@Error


	RETURN @Err
END




