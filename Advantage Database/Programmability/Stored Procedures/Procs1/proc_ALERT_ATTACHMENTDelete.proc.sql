



























CREATE PROCEDURE [dbo].[proc_ALERT_ATTACHMENTDelete]
(
	@ATTACHMENT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ALERT_ATTACHMENT]
	WHERE
		[ATTACHMENT_ID] = @ATTACHMENT_ID
	SET @Err = @@Error

	RETURN @Err
END



























