



















/* CHANGE LOG:
==========================================================
ST:
When JOB_CLI_REF_R is checked in tbl: AGENCY, all values must be unique for the 
JOB_CLI_REF in tbl: JOB_LOG and in tbl: JOB_CLIENT_REF.
Since the JOB_CLIENT_REF table only gets built if the flag is set; the main
table to check for unique vals, imho, should be JOB_LOG because JOB_CLIENT_REF might not exist.
Can have the logic only use this sproc only if the required flag is set and only on insert of new job_log entry.

ST, 20050505:
	- created this sproc to check if client is unique in JOB_LOG
ST, 20050508:
	- modified
*/

CREATE PROCEDURE [dbo].[usp_wv_isUniqueJobClient]
@JobClientRef VarChar(30),
@JobNumber VarChar(6)
AS 
IF EXISTS(
	SELECT 
		DISTINCT JOB_CLI_REF
	FROM 
		JOB_CLIENT_REF
	WHERE 
		JOB_CLI_REF = @JobClientRef
)
	SELECT 0 --0 = False, it was found in the table and exists, and isn't unique
ELSE
	
	IF EXISTS(
		SELECT
			DISTINCT JOB_NUMBER
		FROM
			JOB_CLIENT_REF
		WHERE
			JOB_NUMBER = @JobNumber
	)	
	--UPDATE	
	UPDATE JOB_CLIENT_REF SET JOB_CLI_REF = @JobClientRef WHERE JOB_NUMBER = @JobNumber
	--SELECT 1
	ELSE
		INSERT JOB_CLIENT_REF(JOB_CLI_REF,JOB_NUMBER) VALUES(@JobClientRef,@JobNumber)
SELECT 1 --1 = True, it is unique and doesn't exist, got updated/inserted
	




















