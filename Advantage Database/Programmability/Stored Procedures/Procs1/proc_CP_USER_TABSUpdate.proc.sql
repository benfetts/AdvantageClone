





CREATE PROCEDURE [dbo].[proc_CP_USER_TABSUpdate]
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

	UPDATE [CP_USER_TABS]
	SET
		[NAME] = @NAME,
		[STATE] = @STATE
	WHERE
		[TAB_ID] = @TAB_ID
	AND	[CDP_CONTACT_ID] = @CDP_CONTACT_ID


	SET @Err = @@Error


	RETURN @Err
END





