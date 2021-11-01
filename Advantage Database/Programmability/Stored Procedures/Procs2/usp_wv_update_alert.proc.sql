



























/*****************************************************************
Webvantage
This Stored Procedure update the Alert Dismissed for a certain receipient
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_update_alert] 
@AlertID int, 
@AlertRcptID int,
@DisDate as datetime
AS

Update ALERT_RCPT
Set PROCESSED = @DisDate
Where ALERT_RCPT_ID = @AlertRcptID
and ALERT_ID = @AlertID

Return @@Error


























