















--NOT IN USE?


CREATE PROCEDURE [dbo].[usp_wv_traffic_update_detail] 
@RowID Int, 
@TaskStatus VarChar(6),
@EmpCode VarChar(6),
@StartDate VarChar(10),
@RevDateDue VarChar(10), 
@RevTimeDue VarChar(10), 
@CompDate VarChar(10), 
@TempDate VarChar(10),
@TrafficPhaseID Int
--@TaskComments nText
AS
Update JOB_TRAFFIC_DET
SET      TASK_STATUS = @TaskStatus, 
	--EMP_CODE =@EmpCode, 
	TASK_START_DATE = @StartDate,
	JOB_REVISED_DATE = @RevDateDue, 
	REVISED_DUE_TIME = @RevTimeDue, 
	JOB_COMPLETED_DATE = @CompDate, 
	--FNC_COMMENTS = @TaskComments,
	--TEMP_COMP_DATE = @TempDate,
	TRAFFIC_PHASE_ID = @TrafficPhaseID
Where ROWID = @RowID


















