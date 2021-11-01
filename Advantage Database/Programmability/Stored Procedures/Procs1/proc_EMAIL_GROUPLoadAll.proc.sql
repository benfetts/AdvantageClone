



























CREATE PROCEDURE [dbo].[proc_EMAIL_GROUPLoadAll]
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

	SET @Err = @@Error

	RETURN @Err
END



























