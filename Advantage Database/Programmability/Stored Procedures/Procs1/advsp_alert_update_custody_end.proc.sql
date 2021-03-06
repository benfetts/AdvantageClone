IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_update_custody_end]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_alert_update_custody_end]
GO
CREATE PROCEDURE [dbo].[advsp_alert_update_custody_end] 
@ALERT_ID INT,
@CUSTODY_END_DATE SMALLDATETIME
AS
BEGIN

	DECLARE
		@CURR_ALRT_NOTIFY_HDR_ID INT,
		@CURR_ALERT_STATE_ID INT

	SELECT
		@CURR_ALRT_NOTIFY_HDR_ID = A.ALRT_NOTIFY_HDR_ID,
		@CURR_ALERT_STATE_ID = A.ALERT_STATE_ID
	FROM
		ALERT A WITH(NOLOCK)
	WHERE
		A.ALERT_ID = @ALERT_ID;

	UPDATE ALERT_COMMENT WITH(ROWLOCK)
	SET CUSTODY_END = @CUSTODY_END_DATE
	WHERE
		ALERT_ID = @ALERT_ID
		AND NOT ALRT_NOTIFY_HDR_ID IS NULL 
		AND NOT ALERT_STATE_ID IS NULL
		--AND ALRT_NOTIFY_HDR_ID <> @CURR_ALRT_NOTIFY_HDR_ID
		AND ALERT_STATE_ID <> @CURR_ALERT_STATE_ID
		AND NOT ASSIGNED_EMP_CODE IS NULL
		AND COMMENT NOT LIKE 'COMPLETED%'
		AND CUSTODY_END IS NULL;

END