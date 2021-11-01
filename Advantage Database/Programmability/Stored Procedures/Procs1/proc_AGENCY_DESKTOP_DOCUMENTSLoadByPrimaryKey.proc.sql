



























CREATE PROCEDURE [dbo].[proc_AGENCY_DESKTOP_DOCUMENTSLoadByPrimaryKey]
(
	@DOCUMENT_ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[OFFICE_CODE],
		[DP_TM_CODE]
	FROM [AGENCY_DESKTOP_DOCUMENTS]
	WHERE
		([DOCUMENT_ID] = @DOCUMENT_ID)

	SET @Err = @@Error

	RETURN @Err
END



























