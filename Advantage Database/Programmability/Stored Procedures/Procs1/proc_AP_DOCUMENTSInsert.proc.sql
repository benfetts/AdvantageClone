



























CREATE PROCEDURE [dbo].[proc_AP_DOCUMENTSInsert]
(
	@DOCUMENT_ID int,
	@AP_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [AP_DOCUMENTS]
	(
		[DOCUMENT_ID],
		[AP_ID]
	)
	VALUES
	(
		@DOCUMENT_ID,
		@AP_ID
	)

	SET @Err = @@Error


	RETURN @Err
END



























