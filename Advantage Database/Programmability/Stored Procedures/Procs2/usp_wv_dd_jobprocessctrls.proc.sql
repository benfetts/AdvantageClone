
























CREATE PROCEDURE [dbo].[usp_wv_dd_jobprocessctrls] 

AS
SELECT JOB_PROCESS_CONTRL as code, JOB_PROCESS_DESC as description
FROM JOB_PROC_CONTROLS
WHERE JOB_PROCESS_CONTRL <> 13





















