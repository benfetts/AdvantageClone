DELETE dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CSCORE_USE_NEW_URL' AND DTYPE_ID = 16

IF NOT EXISTS(SELECT AGY_SETTINGS_CODE FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CSCORE_USE_NEW_URL') BEGIN

	INSERT INTO
		dbo.AGY_SETTINGS(AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, AGY_SETTINGS_ORDER, DTYPE_ID)
	VALUES
		('CSCORE_USE_NEW_URL', 'Use New URL Date', 0, 7, 8, 2, 21)

END
