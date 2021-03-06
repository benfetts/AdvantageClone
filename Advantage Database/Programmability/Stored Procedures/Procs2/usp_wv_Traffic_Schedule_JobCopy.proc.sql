IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_Traffic_Schedule_JobCopy]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_Traffic_Schedule_JobCopy]
GO

CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_JobCopy] 
@JobNum Int,
@JobCompNum Int,
@JOB_NUM int,
@JOB_COMP int,
@TRF_CODE varchar(10),
@IncludeStartDate smallint,
@IncludeDueDate smallint,
@IncludeEmployees smallint,
@IncludeTaskComment smallint,
@IncludeDueDateComment smallint,
@TRAFFIC_MGR_CODE VARCHAR(6),
@ScheduleTemplate smallint,
@user_id varchar(100),
@IncludeTaskStatus smallint

AS

/* IS USED IN .Net AT THIS POINT - 
	\Webvantage\Webvantage\App_Code\cJobs.vb(4150): oSQL.ExecuteNonQuery ... 
	\AdvantageFramework.BLogic\Project Schedule\Methods.vb(5145): DbContext.Database.ExecuteSqlCommand ...
*/

IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

DECLARE @Restrictions Int, @NumberRecords int, @RowCount int,
	@JNum int,
	@JCNum int	

CREATE TABLE #ps(
	RowID int IDENTITY(1, 1), 
	JobNo int,
	JobCompNo int)
	
DECLARE @UserCode VARCHAR(100)

SELECT @UserCode = @user_id --dbo.fn_AdvanUser()

INSERT INTO #ps
        SELECT JOB_NUMBER, JOB_COMPONENT_NBR
        FROM       JOB_TRAFFIC
        WHERE     (JOB_NUMBER = @JobNum) AND (JOB_COMPONENT_NBR = @JobCompNum) 
         
		           
		           


SET @NumberRecords = @@ROWCOUNT
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @JNum = JobNo, @JCNum = JobCompNo
 FROM #ps
 WHERE RowID = @RowCount

 
 INSERT INTO JOB_TRAFFIC(JOB_NUMBER, JOB_COMPONENT_NBR, TRF_CODE, TRF_PRESET_CODE, TRF_COMMENTS, ASSIGN_1, ASSIGN_2, ASSIGN_3, ASSIGN_4, ASSIGN_5, COMPLETED_DATE, DATE_DELIVERED, DATE_SHIPPED, RECEIVED_BY, REFERENCE, LOCK_USER, SCHEDULE_CALC, IS_TEMPLATE)
 SELECT @JOB_NUM, @JOB_COMP, @TRF_CODE, TRF_PRESET_CODE, 
                      TRF_COMMENTS, ASSIGN_1, ASSIGN_2, 
                      ASSIGN_3, ASSIGN_4, ASSIGN_5, NULL, 
                      NULL, NULL, NULL, NULL, NULL, SCHEDULE_CALC, @ScheduleTemplate
           FROM  JOB_TRAFFIC 
				   WHERE JOB_NUMBER = @JNum AND JOB_COMPONENT_NBR = @JCNum 

IF NOT @TRAFFIC_MGR_CODE IS NULL
BEGIN
	EXEC usp_wv_Traffic_Schedule_UpdateManager @JOB_NUM, @JOB_COMP, @TRAFFIC_MGR_CODE;
END				   


 INSERT INTO JOB_TRAFFIC_DET
 (
	JOB_NUMBER,
	JOB_COMPONENT_NBR,
	SEQ_NBR,
	FNC_CODE,
	FNC_EST,
	TASK_DESCRIPTION,
	TASK_START_DATE,
	JOB_DUE_DATE,
	JOB_REVISED_DATE,
	DUE_DATE_LOCK,
	JOB_COMPLETED_DATE,
	JOB_ORDER,
	JOB_DAYS,
	PARENT_TASK,
	FNC_COMMENTS,
	DUE_DATE_COMMENTS,
	REV_DATE_COMMENTS,
	JOB_HRS,
	DUE_TIME,
	REVISED_DUE_TIME,
	TASK_STATUS,
	MILESTONE,
	TRAFFIC_PHASE_ID,
	TRF_ROLE,
	GRID_ORDER,
	PARENT_TASK_SEQ
)
 SELECT 
	@JOB_NUM, 
	@JOB_COMP, 
	SEQ_NBR, 
	FNC_CODE, 
	FNC_EST, 
	TASK_DESCRIPTION, 
	CASE WHEN @IncludeStartDate = 1 THEN TASK_START_DATE ELSE NULL END, 
	CASE WHEN @IncludeDueDate = 1 THEN JOB_DUE_DATE ELSE NULL END, 
	CASE WHEN @IncludeDueDate = 1 THEN JOB_REVISED_DATE ELSE NULL END, 
	NULL, 
	NULL,
	JOB_ORDER, 
	JOB_DAYS, 
	PARENT_TASK, 
	CASE WHEN @IncludeTaskComment = 1 THEN FNC_COMMENTS ELSE NULL END, 
	CASE WHEN @IncludeDueDateComment = 1 THEN DUE_DATE_COMMENTS ELSE NULL END, 
	NULL, 
	JOB_HRS, 
	DUE_TIME, 
	REVISED_DUE_TIME, 
	CASE WHEN @IncludeTaskStatus = 1 THEN TASK_STATUS ELSE 'P' END, 
	MILESTONE,
	TRAFFIC_PHASE_ID, 
	NULL, 
	GRID_ORDER, 
	PARENT_TASK_SEQ
FROM  
	dbo.JOB_TRAFFIC_DET 
WHERE 
	JOB_NUMBER = @JNum AND 
	JOB_COMPONENT_NBR = @JCNum 

DECLARE @CUR_SEQ SMALLINT

DECLARE 
	DETAIL_CURSOR 
CURSOR FOR
SELECT
	SEQ_NBR
FROM
	dbo.JOB_TRAFFIC_DET
WHERE
	JOB_NUMBER = @JOB_NUM AND
	JOB_COMPONENT_NBR = @JOB_COMP

OPEN DETAIL_CURSOR
FETCH NEXT FROM DETAIL_CURSOR INTO @CUR_SEQ

WHILE @@FETCH_STATUS = 0
BEGIN

	EXEC dbo.advsp_agile_add_assignment_from_task @JOB_NUM, @JOB_COMP, @CUR_SEQ, @UserCode

	FETCH NEXT FROM DETAIL_CURSOR INTO @CUR_SEQ

END

CLOSE DETAIL_CURSOR
DEALLOCATE DETAIL_CURSOR
	
If @IncludeEmployees = 1
BEGIN

	INSERT INTO JOB_TRAFFIC_DET_EMPS
		SELECT 
			@JOB_NUM, @JOB_COMP, SEQ_NBR, EMP_CODE, HOURS_ALLOWED, NULL, NULL, NULL, NULL, NULL
		FROM  
			dbo.JOB_TRAFFIC_DET_EMPS 
		WHERE 
			JOB_NUMBER = @JNum AND 
			JOB_COMPONENT_NBR = @JCNum 

END

 INSERT INTO JOB_TRAFFIC_DET_PREDS
 SELECT @JOB_NUM, @JOB_COMP, SEQ_NBR, PREDECESSOR_SEQ_NBR
           FROM  JOB_TRAFFIC_DET_PREDS 
				   WHERE JOB_NUMBER = @JNum AND JOB_COMPONENT_NBR = @JCNum 
		
 SET @RowCount = @RowCount + 1
END

	if @ScheduleTemplate = 1
	BEGIN
		UPDATE JOB_TRAFFIC
		SET IS_TEMPLATE = 1 
		WHERE JOB_NUMBER = @JOB_NUM
	END

DROP TABLE #ps

GO

GRANT EXECUTE ON [usp_wv_Traffic_Schedule_JobCopy] TO PUBLIC AS dbo
GO