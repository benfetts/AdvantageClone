IF NOT EXISTS(SELECT 1 FROM [dbo].[ALERT_CATEGORY] WHERE [ALERT_CAT_ID] = 75)
	INSERT INTO dbo.ALERT_CATEGORY (ALERT_CAT_ID, ALERT_TYPE_ID, ALERT_DESC, PROMPT, GROUP_LVL_SECURITY, PDF_ATTACHMENT, IS_USER_DEFINED, IS_INACTIVE) VALUES
	(75, 5, 'Media Traffic Generated', NULL, 0, NULL, 0, 0)