


















CREATE PROCEDURE [dbo].[usp_wv_job_ClientGetsEmailOnNew] 
@EmailGroup VarChar(50)
AS
/* st, 20060623:
Will need to refactor this and the other "autoemailprompt" sproc's and the
code in cRequired to handle all the different switched in the AUTO_EMAIL_TYPES table.
for now, need to get it out the door 
*/
SET NOCOUNT ON
SELECT
	ISNULL(ACTIVE_FLAG,0)
FROM
	ALERT_GROUP
WHERE
	ALERT_CAT_ID=3 AND 
	E_GROUP=@EmailGroup


















