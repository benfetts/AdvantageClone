



























CREATE PROCEDURE [dbo].[proc_AGENCY_DESKTOP_DOCUMENTSUpdate]
(
	@DOCUMENT_ID int,
	@OFFICE_CODE varchar(4),
	@DP_TM_CODE varchar(4)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [AGENCY_DESKTOP_DOCUMENTS]
	SET
		[OFFICE_CODE] = @OFFICE_CODE,
		[DP_TM_CODE] = @DP_TM_CODE
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID


	SET @Err = @@Error


	RETURN @Err
END



























