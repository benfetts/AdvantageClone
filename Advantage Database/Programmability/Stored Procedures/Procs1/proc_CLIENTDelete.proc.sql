



























CREATE PROCEDURE [dbo].[proc_CLIENTDelete]
(
	@CL_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [CLIENT]
	WHERE
		[CL_CODE] = @CL_CODE
	SET @Err = @@Error

	RETURN @Err
END



























