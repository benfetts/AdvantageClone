IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_load_active_states]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_load_active_states]
GO
CREATE PROCEDURE [dbo].[advsp_alert_load_active_states] 
AS
BEGIN

	SELECT 
		[ID] = ALS.ALERT_STATE_ID,
		[Name] = ALS.ALERT_STATE_NAME
	FROM
		ALERT_STATES AS ALS WITH(NOLOCK)
	WHERE
		ALS.ACTIVE_FLAG = 1
	ORDER BY
		ALS.SORT_ORDER;

END