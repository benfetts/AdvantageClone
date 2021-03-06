





CREATE PROCEDURE [dbo].[usp_wv_alert_GetMaxAlertRecipientID] 
@AlertID int
AS

	DECLARE @RETURN_ID                 AS INT,
			@MAX_ALERT_RCPT_ID         AS INT,
			@MAX_ALERT_RCPT_DISMISSED  AS INT
	
	SELECT @MAX_ALERT_RCPT_ID = ISNULL(MAX(ALERT_RCPT_ID), 0)
	FROM   ALERT_RCPT WITH(NOLOCK)
	WHERE  (ALERT_ID = @AlertID);

	SELECT @MAX_ALERT_RCPT_DISMISSED = ISNULL(MAX(ALERT_RCPT_ID), 0)
	FROM   ALERT_RCPT_DISMISSED WITH(NOLOCK)
	WHERE  (ALERT_ID = @AlertID);


	IF @MAX_ALERT_RCPT_ID > @MAX_ALERT_RCPT_DISMISSED
	BEGIN
		SET @RETURN_ID = @MAX_ALERT_RCPT_ID;
	END

	IF @MAX_ALERT_RCPT_DISMISSED > @MAX_ALERT_RCPT_ID
	BEGIN
		SET @RETURN_ID = @MAX_ALERT_RCPT_DISMISSED;
	END

	SELECT ISNULL(@RETURN_ID, 0);

