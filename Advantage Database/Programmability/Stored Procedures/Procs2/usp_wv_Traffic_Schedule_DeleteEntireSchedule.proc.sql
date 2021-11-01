﻿
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_DeleteEntireSchedule] 
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT
AS

DECLARE @DELETE_ALERTS BIT
DECLARE @TASK_ALERTS TABLE(ALERT_ID INT)

SELECT @DELETE_ALERTS = CONVERT(BIT, ISNULL(AGY_SETTINGS_VALUE, 0)) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_DEL_TSK_ALRT'

IF @DELETE_ALERTS = 1 
BEGIN 

	INSERT INTO @TASK_ALERTS
		SELECT 
			ALERT_ID 
		FROM 
			dbo.ALERT JOIN
			dbo.JOB_TRAFFIC_DET ON ALERT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND
								   ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND
								   ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR 
		WHERE 
			ALERT.JOB_NUMBER = @JOB_NUMBER AND 
			ALERT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND
			ALERT.TASK_SEQ_NBR IS NOT NULL

	DELETE FROM dbo.CP_ALERT_RCPT_DISMISSED WHERE ALERT_ID IN (SELECT ALERT_ID FROM @TASK_ALERTS)
	DELETE FROM dbo.CP_ALERT_RCPT WHERE ALERT_ID IN (SELECT ALERT_ID FROM @TASK_ALERTS)
	DELETE FROM dbo.ALERT_RCPT_DISMISSED WHERE ALERT_ID IN (SELECT ALERT_ID FROM @TASK_ALERTS)
	DELETE FROM dbo.ALERT_RCPT WHERE ALERT_ID IN (SELECT ALERT_ID FROM @TASK_ALERTS)
	DELETE FROM dbo.ALERT_COMMENT WHERE ALERT_ID IN (SELECT ALERT_ID FROM @TASK_ALERTS)
	DELETE FROM dbo.ALERT_ATTACHMENT WHERE ALERT_ID IN (SELECT ALERT_ID FROM @TASK_ALERTS)
	DELETE FROM dbo.ALERT WHERE ALERT_ID IN (SELECT ALERT_ID FROM @TASK_ALERTS)

END

DELETE FROM JOB_TRAFFIC_DET_PREDS WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
DELETE FROM JOB_TRAFFIC_DET_DOCS WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
DELETE FROM JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
DELETE FROM JOB_TRAFFIC_DET_CNTS WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
DELETE FROM JOB_TRAFFIC_DET WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
DELETE FROM JOB_TRAFFIC WITH(ROWLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;

