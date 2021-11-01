



























CREATE PROCEDURE [dbo].[proc_DIVISIONDelete]
(
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [DIVISION]
	WHERE
		[CL_CODE] = @CL_CODE AND
		[DIV_CODE] = @DIV_CODE
	SET @Err = @@Error

	RETURN @Err
END



























