IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_GetAgencyTimeEntryOptions]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_GetAgencyTimeEntryOptions]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_GetAgencyTimeEntryOptions] /*WITH ENCRYPTION*/
AS
/*=========== QUERY ===========*/

	DECLARE
	@TS_MIN_TIME DECIMAL(7,2),
	@TS_ROUND_TO DECIMAL(7,2),
	@TS_STOP_MIN_TIME DECIMAL(7,2),
	@TS_STOP_ROUND_TO DECIMAL(7,2),
	@TS_REQ_CMT_APPR BIT,
	@TS_START_WEEK_ON SMALLINT,
	@TS_REQ_HRS_MET_APPR BIT,
	@TS_REQ_HRS_APPR_TYPE SMALLINT

		SELECT @TS_MIN_TIME = CONVERT(DECIMAL(7,2), ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_MIN_TIME';

		SELECT @TS_ROUND_TO = CONVERT(DECIMAL(7,2), ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_ROUND_TO';

		SELECT @TS_STOP_MIN_TIME = CONVERT(DECIMAL(7,2), ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_STOP_MIN_TIME';

		SELECT @TS_STOP_ROUND_TO = CONVERT(DECIMAL(7,2), ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_STOP_ROUND_TO';
		
		SELECT @TS_REQ_CMT_APPR = CONVERT(BIT, ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_REQ_CMT_APPR';

		SELECT @TS_START_WEEK_ON = CONVERT(SMALLINT, ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_START_WEEK_ON';

		SELECT @TS_REQ_HRS_MET_APPR = CONVERT(BIT, ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_REQ_HRS_MET_APPR';

		SELECT @TS_REQ_HRS_APPR_TYPE = CONVERT(SMALLINT, ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) 
		FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_REQ_HRS_APPR_TYPE';

		SELECT
			ISNULL(@TS_MIN_TIME, 0.00) AS TS_MIN_TIME,
			ISNULL(@TS_ROUND_TO, 0.00) AS TS_ROUND_TO,
			ISNULL(@TS_STOP_MIN_TIME, 0.00) AS TS_STOP_MIN_TIME,
			ISNULL(@TS_STOP_ROUND_TO, 0.00) AS TS_STOP_ROUND_TO,
			ISNULL(@TS_REQ_CMT_APPR, 0) AS TS_REQ_CMT_APPR,
			ISNULL(@TS_START_WEEK_ON, 0) AS TS_START_WEEK_ON,
			ISNULL(@TS_REQ_HRS_MET_APPR, 0) AS TS_REQ_HRS_MET_APPR,
			ISNULL(@TS_REQ_HRS_APPR_TYPE, 0) AS TS_REQ_HRS_APPR_TYPE;
			
/*=========== QUERY ===========*/
GO
