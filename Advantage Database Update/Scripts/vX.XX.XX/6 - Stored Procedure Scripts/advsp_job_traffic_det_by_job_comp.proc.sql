if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_traffic_det_by_job_comp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_traffic_det_by_job_comp]
GO

CREATE  PROCEDURE [dbo].[advsp_job_traffic_det_by_job_comp](@JOB_NUMBER AS INTEGER,
			@JOB_COMPONENT_NBR AS smallint)
AS
BEGIN

	SELECT [JOB_NUMBER] JobNumber
		  ,[JOB_COMPONENT_NBR] JobComponentNumber
		  ,[SEQ_NBR] SequenceNumber
		  ,[FNC_CODE] TaskCode
		  ,[FNC_EST] FuctionCode
		  ,[TASK_DESCRIPTION] Description
		  ,[TASK_START_DATE] StartDate
		  ,[JOB_DUE_DATE] OriginalDueDate
		  ,[JOB_REVISED_DATE] DueDate
		  ,[DUE_DATE_LOCK] IsDueDateLocked
		  ,[JOB_COMPLETED_DATE] CompletedDate
		  ,[JOB_ORDER] OrderNumber
		  ,[JOB_DAYS] Days
		  ,[PARENT_TASK] ParentTaskCode
		  ,[FNC_COMMENTS] Comment
		  ,[DUE_DATE_COMMENTS] OriginalDueDateComment
		  ,[REV_DATE_COMMENTS] DueDateComment
		  ,[JOB_HRS] Hours
		  ,[DUE_TIME] OriginalDueTime
		  ,[REVISED_DUE_TIME] DueTime
		  ,[TASK_STATUS] StatusCode
		  ,[MILESTONE] IsMilestone
		  ,[TRAFFIC_PHASE_ID] PhaseID
		  ,[ROWID] ID
		  ,[TEMP_SEQ] AltSequenceNumber
		  ,[TRF_ROLE] RoleCode
		  ,[HOURS_ASSIGNED] HoursAssigned
		  ,[EMP_CODE] EmployeeCode
		  ,[TEMP_COMP_DATE] TempCompletionDate
		  ,[PARENT_TASK_SEQ] ParentTaskSequenceNumber
		  ,[GRID_ORDER] GridOrder
		  --,[BOARD_ID]
		  --,[BOARD_COL_ID]
	  FROM [dbo].[JOB_TRAFFIC_DET]
		WHERE JOB_NUMBER = @JOB_NUMBER and @JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR

END