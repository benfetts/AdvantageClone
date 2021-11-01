


CREATE PROCEDURE [dbo].[usp_wv_KillSleepingConnections] AS
/*
DECLARE connCount CURSOR 
FOR
	SELECT spid
	FROM master.dbo.sysprocesses 
	WHERE RTRIM(program_name) = 'Webvantage'  AND RTRIM(status)='sleeping'

OPEN connCount
DECLARE @myID int

FETCH NEXT FROM connCount INTO @myID

WHILE (@@fetch_status <> -1)

BEGIN
	EXEC ('KILL ' + @myID)
	FETCH NEXT FROM connCount INTO @myID
END

CLOSE connCount

DEALLOCATE connCount
*/
