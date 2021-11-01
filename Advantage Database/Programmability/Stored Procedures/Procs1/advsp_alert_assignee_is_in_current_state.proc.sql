IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_alert_assignee_is_in_current_state]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_alert_assignee_is_in_current_state];
END
GO
CREATE PROCEDURE [dbo].[advsp_alert_assignee_is_in_current_state] 
@ALERT_ID INT,
@EMP_CODE VARCHAR(6)
AS
/*=========== QUERY ===========*/
BEGIN
	IF EXISTS (
		SELECT A.ALERT_ID 
		FROM ALERT A WITH(NOLOCK) INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON A.ALERT_ID = AR.ALERT_ID AND A.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AR.ALERT_STATE_ID 
		WHERE A.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND CURRENT_NOTIFY = 1
	)
	BEGIN
		SELECT CAST(1 AS BIT);
	END
	ELSE
	BEGIN
		SELECT CAST(0 AS BIT);
	END
END
/*=========== QUERY ===========*/
