﻿IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_template_states_get]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_template_states_get]
GO
CREATE PROCEDURE [dbo].[advsp_alert_template_states_get]
@ALRT_NOTIFY_HDR_ID INT
AS
BEGIN

	SELECT 
		[ID] = HDR.ALERT_STATE_ID,
		[Name] = DTL.ALERT_STATE_NAME,
		[DefaultEmployeeCode] = HDR.DFLT_EMP_CODE,
		[IsDefault] = CONVERT(BIT, ISNULL(HDR.IS_DFLT, 0)),
		[IsCompleted] = CONVERT(BIT, ISNULL(HDR.IS_COMPLETED, 0))
	FROM
		ALERT_NOTIFY_STATES HDR WITH(NOLOCK)
	INNER JOIN
		ALERT_STATES DTL WITH(NOLOCK) ON HDR.ALERT_STATE_ID = DTL.ALERT_STATE_ID
	WHERE
		HDR.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID AND
		DTL.ACTIVE_FLAG = 1
	ORDER BY
		HDR.SORT_ORDER ASC;

END
