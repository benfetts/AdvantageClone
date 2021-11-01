


























/*****************************************************************
Webvantage Desktop 
Modication Description / Date / Developer
=============================================
This Stored Procedure gets the top 5 Alerts / 01-16-04 / Steve Moreno

******************************************************************/
CREATE PROCEDURE [dbo].[usp_dt_alerts_last5] 
@EmpCode Varchar(6)
AS

SET NOCOUNT ON

SELECT TOP 5 
	ALERT_RCPT.ALERT_ID AS AlertID, 
	ALERT_RCPT.ALERT_RCPT_ID AS AlertRcptID,
	ALERT.GENERATED AS Date, 
	ALERT.PRIORITY AS Priority, 
             ALERT.SUBJECT AS Subject
FROM   ALERT INNER JOIN
              ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
WHERE     (ALERT_RCPT.EMP_CODE = @EmpCode) 
	AND (ALERT_RCPT.PROCESSED IS NULL)
ORDER BY ALERT.GENERATED DESC

























