



























CREATE PROCEDURE [dbo].[proc_AP_DOCUMENTSUpdate]
(
	@DOCUMENT_ID int,
	@AP_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [AP_DOCUMENTS]
	SET
		[AP_ID] = @AP_ID
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID


	SET @Err = @@Error


	RETURN @Err
END



























