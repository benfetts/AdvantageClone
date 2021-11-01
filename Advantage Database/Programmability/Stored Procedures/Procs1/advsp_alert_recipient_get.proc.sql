CREATE PROCEDURE [dbo].[advsp_alert_recipient_get]
	@ALERT_ID INT
AS
BEGIN

	SELECT * FROM [dbo].[advtf_alert_recipient_get](@ALERT_ID);
		
END