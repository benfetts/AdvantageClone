



























CREATE PROCEDURE [dbo].[proc_ALERT_CATEGORYInsert]
(
	@ALERT_CAT_ID int,
	@ALERT_TYPE_ID int,
	@ALERT_DESC varchar(40),
	@PROMPT smallint = NULL,
	@GROUP_LVL_SECURITY smallint = NULL,
	@PDF_ATTACHMENT smallint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ALERT_CATEGORY]
	(
		[ALERT_CAT_ID],
		[ALERT_TYPE_ID],
		[ALERT_DESC],
		[PROMPT],
		[GROUP_LVL_SECURITY],
		[PDF_ATTACHMENT]
	)
	VALUES
	(
		@ALERT_CAT_ID,
		@ALERT_TYPE_ID,
		@ALERT_DESC,
		@PROMPT,
		@GROUP_LVL_SECURITY,
		@PDF_ATTACHMENT
	)

	SET @Err = @@Error


	RETURN @Err
END



























