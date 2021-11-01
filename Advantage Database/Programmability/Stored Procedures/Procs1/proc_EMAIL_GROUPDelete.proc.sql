



























CREATE PROCEDURE [dbo].[proc_EMAIL_GROUPDelete]
(
	@EMAIL_GR_CODE varchar(50),
	@EMP_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [EMAIL_GROUP]
	WHERE
		[EMAIL_GR_CODE] = @EMAIL_GR_CODE AND
		[EMP_CODE] = @EMP_CODE
	SET @Err = @@Error

	RETURN @Err
END



























