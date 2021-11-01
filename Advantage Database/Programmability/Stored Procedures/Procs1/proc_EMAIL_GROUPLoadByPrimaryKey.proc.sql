



























CREATE PROCEDURE [dbo].[proc_EMAIL_GROUPLoadByPrimaryKey]
(
	@EMAIL_GR_CODE varchar(50),
	@EMP_CODE varchar(6)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[EMAIL_GR_CODE],
		[EMP_CODE],
		[INACTIVE_FLAG],
		[PRIMARY_EMP]
	FROM [EMAIL_GROUP]
	WHERE
		([EMAIL_GR_CODE] = @EMAIL_GR_CODE) AND
		([EMP_CODE] = @EMP_CODE)

	SET @Err = @@Error

	RETURN @Err
END



























