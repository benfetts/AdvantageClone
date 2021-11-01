

















CREATE PROCEDURE [dbo].[usp_wv_add_alert_recipient]

@ALERTID int, 
@RCPTID int, 
@EMP_CODE Varchar(6),
@EMAIL_ADDRESS Varchar(50)

AS


INSERT INTO ALERT_RCPT (ALERT_ID, ALERT_RCPT_ID, EMP_CODE, EMAIL_ADDRESS)
Values(@ALERTID, @RCPTID, @EMP_CODE, @EMAIL_ADDRESS)

















