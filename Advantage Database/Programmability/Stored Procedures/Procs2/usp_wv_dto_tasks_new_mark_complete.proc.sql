IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dto_tasks_new_mark_complete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dto_tasks_new_mark_complete]
GO
CREATE PROCEDURE [dbo].[usp_wv_dto_tasks_new_mark_complete] 
@UserID		Varchar(100),
@EmpCode	Varchar(140),	--NS: Updated to accommodate multiple Employees and Roles for the new AAM.
@Role		Varchar(140),	--NS: Updated to accommodate multiple Employees and Roles for the new AAM.
@StartDate	Datetime,
@DueDate	Datetime,
@ManagerCode Varchar(6),
@Office		varchar(4),
@TaskStatus Varchar(10),
@Search as Varchar(500)
AS
BEGIN



    CREATE TABLE #TASKS --MASTER TABLE TO RETURN
    (
		[CDP]              VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[JobData]          VARCHAR(4000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[Task]             VARCHAR(1000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[TaskComment]      TEXT ,
		[StartDate]        SMALLDATETIME ,
		[DueDate]          SMALLDATETIME ,
		[DueTime]          VARCHAR(2000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[JobNo]            INT NULL ,
		[JobComp]          SMALLINT NULL ,
		[HoursAllowed]     DECIMAL(18 , 2) NULL ,
		[SeqNo]            INT NULL ,
		[TempCompleteDate] SMALLDATETIME NULL ,
		[Employee]         VARCHAR(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[EmpCode]          VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[OFFICE_CODE]      VARCHAR(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[IS_EVENT]         SMALLINT NULL ,
		[EVENT_TASK_ID]    INT NULL ,
		[TASK_STATUS]      VARCHAR(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[JOB_DESC]         VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[JOB_COMP_DESC]    VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[JOB_COMP]         VARCHAR(4000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
		[HAS_DOCUMENTS]    BIT ,
		[HAS_CHILDREN]     BIT ,
		ALERT_ID			 INT NULL,
		SPRINT_ID			 INT NULL,
		[PRIORITY]	INT NULL
    )	

	INSERT INTO #TASKS
	EXEC [dbo].[usp_wv_dto_tasks_new] @UserID,
	@EmpCode,
	@Role,
	@StartDate,
	@DueDate,
	@ManagerCode,
	@Office,
	@TaskStatus,
	@Search

	--SELECT #TASKS.JobNo,#TASKS.JobComp,#TASKS.SeqNo,#TASKS.TempCompleteDate,
	SELECT #TASKS.JobNo, #TASKS.JobComp, #TASKS.SeqNo
	FROM #TASKS INNER JOIN JOB_TRAFFIC_DET ON #TASKS.JobNo = JOB_TRAFFIC_DET.JOB_NUMBER AND #TASKS.JobComp = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
	AND #TASKS.SeqNo = JOB_TRAFFIC_DET.SEQ_NBR
	WHERE (NOT(JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL));

	UPDATE JOB_TRAFFIC_DET
	SET
		JOB_TRAFFIC_DET.JOB_COMPLETED_DATE = #TASKS.TempCompleteDate
	FROM #TASKS INNER JOIN JOB_TRAFFIC_DET ON #TASKS.JobNo = JOB_TRAFFIC_DET.JOB_NUMBER AND #TASKS.JobComp = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
	AND #TASKS.SeqNo = JOB_TRAFFIC_DET.SEQ_NBR
	WHERE (NOT(JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL));

	DROP TABLE #TASKS;

END
