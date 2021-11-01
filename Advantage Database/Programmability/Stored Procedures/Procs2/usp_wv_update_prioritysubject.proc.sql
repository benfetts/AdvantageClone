




/*****************************************************************
Webvantage
This Stored Procedure update the Alert Dismissed for a certain receipient
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_update_prioritysubject] 
@ALERTID int, 
@PRIORITY int,
@SUBJECT varchar(150)
AS

Update ALERT
Set PRIORITY = @PRIORITY,
SUBJECT = @SUBJECT
Where ALERT_ID = @ALERTID

Return @@Error




