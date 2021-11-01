



















CREATE PROCEDURE [dbo].[proc_DIVISION_DOCUMENTSUpdate]
(
	@DOCUMENT_ID int,
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [DIVISION_DOCUMENTS]
	SET
		[CL_CODE] = @CL_CODE,
		[DIV_CODE] = @DIV_CODE
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID


	SET @Err = @@Error


	RETURN @Err
END



















