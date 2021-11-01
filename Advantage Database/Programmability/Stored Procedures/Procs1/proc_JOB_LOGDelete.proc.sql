



























CREATE PROCEDURE [dbo].[proc_JOB_LOGDelete]
(
	@JOB_NUMBER int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [JOB_LOG]
	WHERE
		[JOB_NUMBER] = @JOB_NUMBER
	SET @Err = @@Error

	RETURN @Err
END



























