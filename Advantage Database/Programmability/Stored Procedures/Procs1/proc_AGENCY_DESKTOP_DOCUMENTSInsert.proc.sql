



























CREATE PROCEDURE [dbo].[proc_AGENCY_DESKTOP_DOCUMENTSInsert]
(
	@DOCUMENT_ID int,
	@OFFICE_CODE varchar(4),
	@DP_TM_CODE varchar(4)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [AGENCY_DESKTOP_DOCUMENTS]
	(
		[DOCUMENT_ID],
		[OFFICE_CODE],
		[DP_TM_CODE]
	)
	VALUES
	(
		@DOCUMENT_ID,
		@OFFICE_CODE,
		@DP_TM_CODE
	)

	SET @Err = @@Error


	RETURN @Err
END



























