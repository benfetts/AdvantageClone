


















CREATE PROCEDURE [dbo].[usp_wv_agency_AlertNotifyQuery] 
@AlertNotify Integer OUTPUT
AS

SELECT @AlertNotify = ALERT_NOTIFY FROM AGENCY


















