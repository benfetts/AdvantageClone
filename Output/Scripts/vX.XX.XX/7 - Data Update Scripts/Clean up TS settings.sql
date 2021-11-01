IF NOT EXISTS (SELECT 1 FROM AGY_SETTINGS AG WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TS_AGY_OVRRDE')
BEGIN
	INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF)
	VALUES ('TS_AGY_OVRRDE', 'Agency settings override user settings', 0, 0);
END
IF EXISTS (SELECT TS_DAYS_PER_WK FROM AGENCY A WHERE TS_DAYS_PER_WK = 1 OR TS_DAYS_PER_WK = 0 OR TS_DAYS_PER_WK IS NULL)
BEGIN
	UPDATE AGENCY WITH(ROWLOCK) SET TS_DAYS_PER_WK = 5;
END
IF EXISTS (SELECT 1 FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TS_DAYS_TO_DISPLAY' AND (CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS SMALLINT) = 1 OR CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS SMALLINT) = 0 OR AGY_SETTINGS_VALUE IS NULL )   )
BEGIN
	UPDATE AGY_SETTINGS SET AGY_SETTINGS_VALUE = 5 WHERE AGY_SETTINGS_CODE = 'TS_DAYS_TO_DISPLAY';
END

