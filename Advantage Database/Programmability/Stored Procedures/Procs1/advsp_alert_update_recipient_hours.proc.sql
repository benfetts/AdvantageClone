IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_update_recipient_hours]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_alert_update_recipient_hours]
GO
CREATE PROCEDURE [dbo].[advsp_alert_update_recipient_hours]
@ALERT_ID INT,
@HRS_ALLOWED DECIMAL(7, 2),
@EMP_CODE VARCHAR(6)
AS
/*=========== QUERY ===========*/
BEGIN	
	IF @EMP_CODE IS NULL OR RTRIM(LTRIM(@EMP_CODE)) = '' OR DATALENGTH(@EMP_CODE) = 0
	BEGIN
		UPDATE ALERT_RCPT SET HOURS_ALLOWED = @HRS_ALLOWED 
		WHERE
			ALERT_RCPT.ALERT_ID = @ALERT_ID
			AND ALERT_RCPT.CURRENT_NOTIFY = 1;
		--UPDATE ALERT_RCPT_DISMISSED SET HOURS_ALLOWED = @HRS_ALLOWED 
		--WHERE
		--	ALERT_RCPT_DISMISSED.ALERT_ID = @ALERT_ID
		--	AND ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 1;

		UPDATE JOB_TRAFFIC_DET_EMPS  SET JOB_TRAFFIC_DET_EMPS.HOURS_ALLOWED  = @HRS_ALLOWED 
			from JOB_TRAFFIC_DET_EMPS
		JOIN ALERT on ALERT.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR
		WHERE 
		ALERT.ALERT_ID = @ALERT_ID

	END
	ELSE
	BEGIN
		UPDATE ALERT_RCPT SET HOURS_ALLOWED = @HRS_ALLOWED 
		WHERE
			ALERT_RCPT.ALERT_ID = @ALERT_ID
			AND ALERT_RCPT.CURRENT_NOTIFY = 1
			AND ALERT_RCPT.EMP_CODE = @EMP_CODE;
		--UPDATE ALERT_RCPT_DISMISSED SET HOURS_ALLOWED = @HRS_ALLOWED 
		--WHERE
		--	ALERT_RCPT_DISMISSED.ALERT_ID = @ALERT_ID
		--	AND ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 1
		--	AND ALERT_RCPT_DISMISSED.EMP_CODE = @EMP_CODE;

		UPDATE JOB_TRAFFIC_DET_EMPS  SET JOB_TRAFFIC_DET_EMPS.HOURS_ALLOWED  = @HRS_ALLOWED 
			from JOB_TRAFFIC_DET_EMPS
		JOIN ALERT on ALERT.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR
		WHERE 
		ALERT.ALERT_ID = @ALERT_ID AND 
		JOB_TRAFFIC_DET_EMPS.EMP_CODE = @EMP_CODE

	END
END
/*=========== QUERY ===========*/
GO


