




CREATE PROCEDURE [dbo].[proc_CP_USERDelete]
(
	@USER_GUID uniqueidentifier
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [CP_USER]
	WHERE
		[USER_GUID] = @USER_GUID
	SET @Err = @@Error

	RETURN @Err
END





