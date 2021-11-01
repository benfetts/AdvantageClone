



















CREATE PROCEDURE [dbo].[usp_wv_alert_add_cprecipient]
@ALERTID as Integer,
@CDPID as Int,
@EMAIL_ADDRESS as VarChar(100)
AS

Declare @RCPTID as Int

SET NOCOUNT ON

If Exists(
	Select ALERT_RCPT_ID
	from CP_ALERT_RCPT
	Where ALERT_ID = @ALERTID)
Begin 
	Select @RCPTID = max(ALERT_RCPT_ID)  + 1
	from CP_ALERT_RCPT
	Where ALERT_ID = @ALERTID
End 
Else
Begin 
	Set @RCPTID = 1
End


INSERT INTO CP_ALERT_RCPT (ALERT_ID, ALERT_RCPT_ID, CDP_CONTACT_ID, EMAIL_ADDRESS)
Values(@ALERTID, @RCPTID, @CDPID, @EMAIL_ADDRESS)



















