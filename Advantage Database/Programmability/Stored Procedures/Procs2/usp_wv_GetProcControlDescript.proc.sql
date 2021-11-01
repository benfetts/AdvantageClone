

















CREATE PROCEDURE [dbo].[usp_wv_GetProcControlDescript] 
@ProcControlID SmallInt
AS
SELECT 
	DISTINCT JOB_PROCESS_DESC
FROM 
	JOB_PROC_CONTROLS 
WHERE  
	JOB_PROCESS_CONTRL=@ProcControlID



















