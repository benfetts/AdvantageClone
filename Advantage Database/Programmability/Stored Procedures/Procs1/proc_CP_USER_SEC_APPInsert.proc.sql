






CREATE PROCEDURE [dbo].[proc_CP_USER_SEC_APPInsert]
(
	@CDP_CONTACT_ID int,
	@APPID int
	
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	
	INSERT
	INTO [CP_USER_SEC_APP]
	(
		[CDP_CONTACT_ID],
		[APPID]
	)
	VALUES
	(
		@CDP_CONTACT_ID,
		@APPID
	)

	SET @Err = @@Error


	RETURN @Err
END




