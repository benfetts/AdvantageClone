IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_alert_assignee_has_current_state_comment]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_alert_assignee_has_current_state_comment];
END
GO
CREATE PROCEDURE [dbo].[advsp_alert_assignee_has_current_state_comment] 
@ALERT_ID INT,
@EMP_CODE VARCHAR(6)
AS
/*=========== QUERY ===========*/
BEGIN
	IF EXISTS (
		SELECT A.ALERT_ID 
		FROM ALERT A WITH(NOLOCK) INNER JOIN ALERT_COMMENT AC WITH(NOLOCK) ON A.ALERT_ID = AC.ALERT_ID AND A.ALRT_NOTIFY_HDR_ID = AC.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AC.ALERT_STATE_ID 
		WHERE A.ALERT_ID = @ALERT_ID AND AC.ASSIGNED_EMP_CODE = @EMP_CODE AND AC.CUSTODY_END IS NULL
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
