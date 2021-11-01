



























CREATE PROCEDURE [dbo].[proc_EMAIL_GROUPInsert]
(
	@EMAIL_GR_CODE varchar(50),
	@EMP_CODE varchar(6),
	@INACTIVE_FLAG smallint = NULL,
	@PRIMARY_EMP smallint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [EMAIL_GROUP]
	(
		[EMAIL_GR_CODE],
		[EMP_CODE],
		[INACTIVE_FLAG],
		[PRIMARY_EMP]
	)
	VALUES
	(
		@EMAIL_GR_CODE,
		@EMP_CODE,
		@INACTIVE_FLAG,
		@PRIMARY_EMP
	)

	SET @Err = @@Error


	RETURN @Err
END



























