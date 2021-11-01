



























CREATE PROCEDURE [dbo].[proc_PRODUCTDelete]
(
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6),
	@PRD_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [PRODUCT]
	WHERE
		[CL_CODE] = @CL_CODE AND
		[DIV_CODE] = @DIV_CODE AND
		[PRD_CODE] = @PRD_CODE
	SET @Err = @@Error

	RETURN @Err
END



























