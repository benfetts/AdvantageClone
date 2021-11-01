





















CREATE PROCEDURE [dbo].[usp_cp_alert_checkforduplicates]
@AlertID Int, 
@CDP_ID Int
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT CDP_CONTACT_ID
FROM CP_ALERT_RCPT
WHERE ALERT_ID = @AlertID AND CDP_CONTACT_ID = @CDP_ID
)
	 select 1
Else
	select  0





















