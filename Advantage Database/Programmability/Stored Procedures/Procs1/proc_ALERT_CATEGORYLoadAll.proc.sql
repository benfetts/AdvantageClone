﻿



























CREATE PROCEDURE [dbo].[proc_ALERT_CATEGORYLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ALERT_CAT_ID],
		[ALERT_TYPE_ID],
		[ALERT_DESC],
		[PROMPT],
		[GROUP_LVL_SECURITY],
		[PDF_ATTACHMENT]
	FROM [ALERT_CATEGORY]

	SET @Err = @@Error

	RETURN @Err
END



























