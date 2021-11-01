

















CREATE PROCEDURE [dbo].[usp_wv_job_AutoEmailPromptOnUpdate] 
AS
/* st, 20060623:
Will need to refactor this and the other "autoemailprompt" sproc's and the
code in cRequired to handle all the different switched in the AUTO_EMAIL_TYPES table.
for now, need to get it out the door 
*/
SELECT
	ISNULL(PROMPT,0)
FROM
	ALERT_CATEGORY
WHERE
	ALERT_CAT_ID=4

















