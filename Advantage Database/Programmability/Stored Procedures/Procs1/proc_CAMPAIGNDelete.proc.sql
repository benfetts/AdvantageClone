



























CREATE PROCEDURE [dbo].[proc_CAMPAIGNDelete]
(
	@CMP_IDENTIFIER int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [CAMPAIGN]
	WHERE
		[CMP_IDENTIFIER] = @CMP_IDENTIFIER
	SET @Err = @@Error

	RETURN @Err
END



























