



























CREATE PROCEDURE [dbo].[proc_EMAIL_GROUPUpdate]
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

	UPDATE [EMAIL_GROUP]
	SET
		[INACTIVE_FLAG] = @INACTIVE_FLAG,
		[PRIMARY_EMP] = @PRIMARY_EMP
	WHERE
		[EMAIL_GR_CODE] = @EMAIL_GR_CODE
	AND	[EMP_CODE] = @EMP_CODE


	SET @Err = @@Error


	RETURN @Err
END



























