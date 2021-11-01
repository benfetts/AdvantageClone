IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_add_assignment_from_task]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_add_assignment_from_task]
GO
CREATE PROCEDURE [dbo].[advsp_agile_add_assignment_from_task] /*WITH ENCRYPTION*/
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@TASK_SEQ_NBR SMALLINT,
@USER_CODE VARCHAR(100)
AS
/*=========== QUERY ===========*/
IF @JOB_NUMBER IS NOT NULL AND @JOB_COMPONENT_NBR IS NOT NULL AND @TASK_SEQ_NBR IS NOT NULL
BEGIN
	IF (EXISTS (SELECT 1 FROM JOB_TRAFFIC_DET JTD WITH(NOLOCK) WHERE JTD.JOB_NUMBER = @JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND JTD.SEQ_NBR = @TASK_SEQ_NBR))
	AND (NOT EXISTS (SELECT 1 FROM ALERT WITH(NOLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND TASK_SEQ_NBR = @TASK_SEQ_NBR AND ALERT_LEVEL = 'BRD'))
	BEGIN
		-- VARIABLES
		BEGIN
		   DECLARE 
			  @ALERT_ID INT,
			  @OFFICE_CODE VARCHAR(4),
			  @CL_CODE VARCHAR(6),
			  @DIV_CODE VARCHAR(6),
			  @PRD_CODE VARCHAR(6),
			  @JOB_COMP_DESC VARCHAR(60),
			  @ALERT_SEQ_NBR SMALLINT,
			  @ALERT_TYPE_ID INT,
			  @ALERT_CAT_ID INT,
			  @ALERT_LEVEL VARCHAR(3),
			  @SUBJECT VARCHAR(254),
			  @BODY VARCHAR(MAX),
			  @TASK_DESCRIPTION VARCHAR(40),
			  @TASK_HOURS DECIMAL(14,2),
			  @TASK_COMMENT VARCHAR(MAX),
			  @JOB_COMP_DISPLAY VARCHAR(MAX),
			  @TASK_DUE SMALLDATETIME,
			  @TASK_COMPLETED_DATE SMALLDATETIME
		END
		-- GET/SET SOME DATA
		BEGIN

		   SET @ALERT_TYPE_ID = 6; -- Board
		   SET @ALERT_LEVEL = 'BRD';
		   SET @ALERT_CAT_ID = 71; -- Task

		   SELECT
			  @JOB_COMP_DESC = JOB_COMP_DESC
		   FROM
			  JOB_COMPONENT WITH(NOLOCK)
		   WHERE
			  JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;

		   SELECT
			  @OFFICE_CODE = OFFICE_CODE,
			  @CL_CODE = CL_CODE,
			  @DIV_CODE = DIV_CODE,
			  @PRD_CODE = PRD_CODE
		   FROM
			  JOB_LOG WITH(NOLOCK)
		   WHERE
			  JOB_NUMBER = @JOB_NUMBER;

		   SELECT 
			  @TASK_DESCRIPTION = TASK_DESCRIPTION,
			  @TASK_HOURS = JOB_HRS,
			  @TASK_COMMENT = FNC_COMMENTS,
			  @TASK_DUE = COALESCE(JOB_REVISED_DATE, JOB_DUE_DATE),
			  @TASK_COMPLETED_DATE = JOB_COMPLETED_DATE
		   FROM JOB_TRAFFIC_DET WITH(NOLOCK) 
		   WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @TASK_SEQ_NBR;

		   IF NOT @TASK_DESCRIPTION IS NULL AND DATALENGTH(@TASK_DESCRIPTION) > 0
		   BEGIN
			  SET @BODY = @TASK_DESCRIPTION;
		   END
		   SET @JOB_COMP_DISPLAY = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), @JOB_NUMBER), 6) 
			  + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), @JOB_COMPONENT_NBR), 3) +
				 ' - ' + @JOB_COMP_DESC;

 		   IF NOT @TASK_DESCRIPTION IS NULL AND DATALENGTH(@TASK_DESCRIPTION) > 0
		   BEGIN
			  SET @SUBJECT = @TASK_DESCRIPTION;
		   END
		   ELSE
		   BEGIN
			  SET @SUBJECT = '[Blank task description]'  --@JOB_COMP_DISPLAY;
		   END

		END
		-- INSERT ALERT  
		BEGIN
		   SELECT @ALERT_ID = ISNULL(MAX(ALERT_ID) + 1, 0) FROM ALERT WITH(NOLOCK);
		   SELECT @ALERT_SEQ_NBR = (ISNULL(MAX(ALERT_SEQ_NBR),0) + 1) FROM ALERT WITH(NOLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
		   INSERT INTO ALERT WITH(ROWLOCK)	(
												ALERT_ID,
												ALERT_TYPE_ID, 
												ALERT_CAT_ID, 
												[SUBJECT], 
												--BODY, 
												--BODY_HTML, 
												[GENERATED], 
												[PRIORITY], 
												CL_CODE, 
												DIV_CODE, 
												PRD_CODE, 
												JOB_NUMBER, 
												JOB_COMPONENT_NBR, 
												ALERT_USER, 
												ALERT_LEVEL, 
												OFFICE_CODE, 
												TASK_SEQ_NBR, 
												DUE_DATE,
												IS_WORK_ITEM,
												ALERT_SEQ_NBR,
												ASSIGN_COMPLETED
											)
		   VALUES (
						@ALERT_ID, @ALERT_TYPE_ID, 
						@ALERT_CAT_ID,
						@SUBJECT,
						--@BODY,
						--@BODY,
						GETDATE(),
						3,
						@CL_CODE,
						@DIV_CODE,
						@PRD_CODE,
						@JOB_NUMBER,
						@JOB_COMPONENT_NBR,
						@USER_CODE,
						@ALERT_LEVEL,
						@OFFICE_CODE,
						@TASK_SEQ_NBR,
						@TASK_DUE,
						1,
						@ALERT_SEQ_NBR,
						CASE
							WHEN NOT @TASK_COMPLETED_DATE IS NULL THEN 1
							ELSE NULL
						END
				 );
		END
		-- RETURN
		BEGIN
			SELECT ISNULL(@ALERT_ID, 0) AS ALERT_ID;
		END
	END
	ELSE
	BEGIN
		SELECT CAST(-1 AS INT);
	END
END
/*=========== QUERY ===========*/
