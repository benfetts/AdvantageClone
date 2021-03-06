CREATE VIEW [dbo].[CP_ALERTRECIPIENTLIST]
AS

	SELECT TOP 100 PERCENT CP_ALERT_RCPT.ALERT_ID,
		   CP_ALERT_RCPT.ALERT_RCPT_ID,
		   CP_ALERT_RCPT.CDP_CONTACT_ID,
		   CP_ALERT_RCPT.EMAIL_ADDRESS,
		   CP_ALERT_RCPT.PROCESSED,
		   CP_ALERT_RCPT.NEW_ALERT,
		   CP_ALERT_RCPT.READ_ALERT,
		   CDP_CONTACT_HDR.CONT_FML,
		   CDP_CONTACT_HDR.CONT_CODE,
		   ISNULL(CP_ALERT_RCPT.CURRENT_RCPT, 0) AS CURRENT_RCPT
	FROM   CP_ALERT_RCPT WITH(NOLOCK)
		   INNER JOIN CDP_CONTACT_HDR WITH(NOLOCK)
				ON  CP_ALERT_RCPT.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
	ORDER BY
		CONT_FML 


