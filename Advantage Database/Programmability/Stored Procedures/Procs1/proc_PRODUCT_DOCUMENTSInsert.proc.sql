



















CREATE PROCEDURE [dbo].[proc_PRODUCT_DOCUMENTSInsert]
(
	@DOCUMENT_ID int,
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6),
	@PRD_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [PRODUCT_DOCUMENTS]
	(
		[DOCUMENT_ID],
		[CL_CODE],
		[DIV_CODE],
		[PRD_CODE]
	)
	VALUES
	(
		@DOCUMENT_ID,
		@CL_CODE,
		@DIV_CODE,
		@PRD_CODE
	)

	SET @Err = @@Error


	RETURN @Err
END



















