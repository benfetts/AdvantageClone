--DROP PROCEDURE [dbo].[usp_wv_Traffic_Schedule_SaveTask_Details]
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_SaveTask_Details]
(
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR SMALLINT,
	@SEQ_NBR SMALLINT,

	@FNC_CODE VARCHAR(10) = NULL, --Yes
	@FNC_EST VARCHAR(6) = NULL, --Yes
	@TASK_DESCRIPTION VARCHAR(40) = NULL,
	@TASK_START_DATE SMALLDATETIME = NULL, --Yes
	@JOB_REVISED_DATE SMALLDATETIME = NULL, --Yes, this is the modifiable due date
	@DUE_DATE_LOCK SMALLINT = NULL, --Yes
	@JOB_COMPLETED_DATE SMALLDATETIME = NULL, --Yes
	@JOB_ORDER SMALLINT = NULL, --Yes
	@JOB_DAYS SMALLINT = NULL, --Yes
	@FNC_COMMENTS TEXT = NULL, --Yes
	@DUE_DATE_COMMENTS TEXT = NULL, --Yes
	@REV_DATE_COMMENTS TEXT = NULL, --Yes
	@JOB_HRS DECIMAL(8,2) = NULL, --Yes
	@DUE_TIME VARCHAR(10) = NULL, --Yes
	@TASK_STATUS VARCHAR(1) = NULL, --Yes
	@MILESTONE SMALLINT = NULL, --Yes
	@TRAFFIC_PHASE_ID INT = NULL --Yes
)
AS
BEGIN

DECLARE
	@HAS_ORIGINAL_DUE_DATE SMALLDATETIME,
	@HAS_ORIGINAL_DUE_TIME VARCHAR(10)
	
    SELECT 
        @HAS_ORIGINAL_DUE_DATE = JOB_DUE_DATE, 
        @HAS_ORIGINAL_DUE_TIME = DUE_TIME 
    FROM 
        JOB_TRAFFIC_DET
    WHERE
        [JOB_NUMBER] = @JOB_NUMBER 
        AND [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR 
        AND [SEQ_NBR] = @SEQ_NBR
        
        -- BOTH NULL
	    IF (@HAS_ORIGINAL_DUE_DATE IS NULL) AND (@HAS_ORIGINAL_DUE_TIME IS NULL)
            BEGIN
	            UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK)
	            SET
		            [FNC_CODE] = @FNC_CODE,
		            [FNC_EST] = @FNC_EST,
		            [TASK_DESCRIPTION] = @TASK_DESCRIPTION,
		            [TASK_START_DATE] = @TASK_START_DATE,
		            [JOB_DUE_DATE] = @JOB_REVISED_DATE,
				    [JOB_REVISED_DATE] = @JOB_REVISED_DATE,
                    [DUE_DATE_LOCK] = @DUE_DATE_LOCK,
		            [JOB_COMPLETED_DATE] = @JOB_COMPLETED_DATE,
		            [JOB_ORDER] = @JOB_ORDER,
		            [JOB_DAYS] = @JOB_DAYS,
		            [FNC_COMMENTS] = @FNC_COMMENTS,
		            [DUE_DATE_COMMENTS] = @DUE_DATE_COMMENTS,
		            [REV_DATE_COMMENTS] = @REV_DATE_COMMENTS,
		            [JOB_HRS] = @JOB_HRS,
		            [DUE_TIME] = @DUE_TIME,
		            [REVISED_DUE_TIME] = @DUE_TIME,
		            [TASK_STATUS] = @TASK_STATUS,
		            [MILESTONE] = @MILESTONE,
		            [TRAFFIC_PHASE_ID] = @TRAFFIC_PHASE_ID
	            WHERE
		            [JOB_NUMBER] = @JOB_NUMBER AND 
		            [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR AND
		            [SEQ_NBR] = @SEQ_NBR
            END

        -- DATE NULL
	    IF (@HAS_ORIGINAL_DUE_DATE IS NULL) AND (NOT(@HAS_ORIGINAL_DUE_TIME IS NULL))
            BEGIN
	            UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK)
	            SET
		            [FNC_CODE] = @FNC_CODE,
		            [FNC_EST] = @FNC_EST,
		            [TASK_DESCRIPTION] = @TASK_DESCRIPTION,
		            [TASK_START_DATE] = @TASK_START_DATE,
		            [JOB_DUE_DATE] = @JOB_REVISED_DATE,
		          	[JOB_REVISED_DATE] = @JOB_REVISED_DATE,
                    [DUE_DATE_LOCK] = @DUE_DATE_LOCK,
		            [JOB_COMPLETED_DATE] = @JOB_COMPLETED_DATE,
		            [JOB_ORDER] = @JOB_ORDER,
		            [JOB_DAYS] = @JOB_DAYS,
		            [FNC_COMMENTS] = @FNC_COMMENTS,
		            [DUE_DATE_COMMENTS] = @DUE_DATE_COMMENTS,
		            [REV_DATE_COMMENTS] = @REV_DATE_COMMENTS,
		            [JOB_HRS] = @JOB_HRS,
		            [REVISED_DUE_TIME] = @DUE_TIME,
		            [TASK_STATUS] = @TASK_STATUS,
		            [MILESTONE] = @MILESTONE,
		            [TRAFFIC_PHASE_ID] = @TRAFFIC_PHASE_ID
	            WHERE
		            [JOB_NUMBER] = @JOB_NUMBER AND 
		            [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR AND
		            [SEQ_NBR] = @SEQ_NBR
            END

        --TIME NULL
	    IF (NOT(@HAS_ORIGINAL_DUE_DATE IS NULL)) AND (@HAS_ORIGINAL_DUE_TIME IS NULL)
            BEGIN
	            UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK)
	            SET
		            [FNC_CODE] = @FNC_CODE,
		            [FNC_EST] = @FNC_EST,
		            [TASK_DESCRIPTION] = @TASK_DESCRIPTION,
		            [TASK_START_DATE] = @TASK_START_DATE,
		            [JOB_REVISED_DATE] = @JOB_REVISED_DATE,
		            [DUE_DATE_LOCK] = @DUE_DATE_LOCK,
		            [JOB_COMPLETED_DATE] = @JOB_COMPLETED_DATE,
		            [JOB_ORDER] = @JOB_ORDER,
		            [JOB_DAYS] = @JOB_DAYS,
		            [FNC_COMMENTS] = @FNC_COMMENTS,
		            [DUE_DATE_COMMENTS] = @DUE_DATE_COMMENTS,
		            [REV_DATE_COMMENTS] = @REV_DATE_COMMENTS,
		            [JOB_HRS] = @JOB_HRS,
		            [DUE_TIME] = @DUE_TIME,
		            [REVISED_DUE_TIME] = @DUE_TIME,
		            [TASK_STATUS] = @TASK_STATUS,
		            [MILESTONE] = @MILESTONE,
		            [TRAFFIC_PHASE_ID] = @TRAFFIC_PHASE_ID
	            WHERE
		            [JOB_NUMBER] = @JOB_NUMBER AND 
		            [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR AND
		            [SEQ_NBR] = @SEQ_NBR
            END

        --NONE NULL
	    IF (NOT(@HAS_ORIGINAL_DUE_DATE IS NULL)) AND (NOT(@HAS_ORIGINAL_DUE_TIME IS NULL))
            BEGIN
	            UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK)
	            SET
		            [FNC_CODE] = @FNC_CODE,
		            [FNC_EST] = @FNC_EST,
		            [TASK_DESCRIPTION] = @TASK_DESCRIPTION,
		            [TASK_START_DATE] = @TASK_START_DATE,
		            [JOB_REVISED_DATE] = @JOB_REVISED_DATE,
		            [DUE_DATE_LOCK] = @DUE_DATE_LOCK,
		            [JOB_COMPLETED_DATE] = @JOB_COMPLETED_DATE,
		            [JOB_ORDER] = @JOB_ORDER,
		            [JOB_DAYS] = @JOB_DAYS,
		            [FNC_COMMENTS] = @FNC_COMMENTS,
		            [DUE_DATE_COMMENTS] = @DUE_DATE_COMMENTS,
		            [REV_DATE_COMMENTS] = @REV_DATE_COMMENTS,
		            [JOB_HRS] = @JOB_HRS,
		            [REVISED_DUE_TIME] = @DUE_TIME,
		            [TASK_STATUS] = @TASK_STATUS,
		            [MILESTONE] = @MILESTONE,
		            [TRAFFIC_PHASE_ID] = @TRAFFIC_PHASE_ID
	            WHERE
		            [JOB_NUMBER] = @JOB_NUMBER AND 
		            [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR AND
		            [SEQ_NBR] = @SEQ_NBR
            END


		EXEC [dbo].[usp_wv_Traffic_Schedule_UpdateTaskAlertsDueDate] @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR;




END

