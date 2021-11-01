



























CREATE PROCEDURE [dbo].[proc_ALERT_ATTACHMENTLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ATTACHMENT_ID],
		[ALERT_ID],
		[USER_CODE],
		[GENERATED_DATE],
		[EMAILSENT],
		[DOCUMENT_ID],
		[USER_CODE_CP]
	FROM [ALERT_ATTACHMENT]

	SET @Err = @@Error

	RETURN @Err
END



























