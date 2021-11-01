﻿SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_Traffic_Schedule_MarkTempComplete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_Traffic_Schedule_MarkTempComplete]
GO
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_MarkTempComplete] /*WITH ENCRYPTION*/
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT
AS
/*=========== QUERY ===========*/

	DECLARE
		@RUN TINYINT,
		@ALERT_NEXT_EMPLOYEES TINYINT

	DECLARE @SEQ_NBR_TO_UPDATE TABLE (
		SEQ_NBR SMALLINT
	)	
		
	SELECT 
		@RUN = CAST(AGY_SETTINGS_VALUE AS  TINYINT)
	FROM 
		AGY_SETTINGS WITH(NOLOCK)
	WHERE 
		AGY_SETTINGS_CODE = 'TRF_ACTIVE_NEXT_TASK';

	SELECT 
		@ALERT_NEXT_EMPLOYEES = CAST(AGY_SETTINGS_VALUE AS  TINYINT)
	FROM 
		AGY_SETTINGS WITH(NOLOCK)
	WHERE 
		AGY_SETTINGS_CODE = 'TRF_NXT_TSK_AUTO_EML';

	SET @RUN = ISNULL(@RUN, 0);
	SET @ALERT_NEXT_EMPLOYEES = ISNULL(@ALERT_NEXT_EMPLOYEES, 0);

	CREATE TABLE #TASKS_TO_PROCESS (
		[ID] [int] IDENTITY(1,1) NOT NULL,
		SEQ_NBR SMALLINT,
		TASK_STATUS VARCHAR(1),
		TEMP_COMP_DATE SMALLDATETIME
	);

	INSERT INTO #TASKS_TO_PROCESS
	SELECT SEQ_NBR, TASK_STATUS, TEMP_COMP_DATE 
	FROM JOB_TRAFFIC_DET
	WHERE 
		JOB_NUMBER = @JOB_NUMBER 
		AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR 
		AND (NOT (TEMP_COMP_DATE IS NULL))
		AND (JOB_COMPLETED_DATE IS NULL)
	ORDER BY 
		JOB_TRAFFIC_DET.TASK_START_DATE, 
		JOB_TRAFFIC_DET.JOB_REVISED_DATE, 
		JOB_TRAFFIC_DET.JOB_DUE_DATE, 
		JOB_TRAFFIC_DET.JOB_ORDER ASC, 
		JOB_TRAFFIC_DET.SEQ_NBR ASC;

	--SELECT * FROM #TASKS_TO_PROCESS;

	DECLARE
		@CURR_SEQ_NBR SMALLINT,
		@CURR_TASK_STATUS VARCHAR(1),
		@CURR_TEMP_COMP_DATE SMALLDATETIME

	DECLARE TASKS_TO_PROCESS_CURSOR CURSOR FOR

		SELECT SEQ_NBR, TASK_STATUS, TEMP_COMP_DATE
		FROM #TASKS_TO_PROCESS
		ORDER BY ID;

		OPEN TASKS_TO_PROCESS_CURSOR

		FETCH NEXT FROM TASKS_TO_PROCESS_CURSOR INTO @CURR_SEQ_NBR, @CURR_TASK_STATUS, @CURR_TEMP_COMP_DATE

		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
		
			--SELECT @CURR_SEQ_NBR, @CURR_TASK_STATUS, @CURR_TEMP_COMP_DATE;
			
			UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_COMPLETED_DATE = TEMP_COMP_DATE
			WHERE 
				JOB_NUMBER = @JOB_NUMBER 
				AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
				AND SEQ_NBR = @CURR_SEQ_NBR;	
			
			IF @RUN = 1
			BEGIN	
				
				INSERT INTO @SEQ_NBR_TO_UPDATE
				EXEC [dbo].[usp_wv_Traffic_Schedule_SetNextTaskActive] @JOB_NUMBER, @JOB_COMPONENT_NBR, @CURR_SEQ_NBR;
			
			END
			
			FETCH NEXT FROM TASKS_TO_PROCESS_CURSOR INTO  @CURR_SEQ_NBR, @CURR_TASK_STATUS, @CURR_TEMP_COMP_DATE
			
		END		
			
		CLOSE TASKS_TO_PROCESS_CURSOR
		DEALLOCATE TASKS_TO_PROCESS_CURSOR	

	DROP TABLE #TASKS_TO_PROCESS;

	IF @ALERT_NEXT_EMPLOYEES = 0
	BEGIN

		DELETE FROM @SEQ_NBR_TO_UPDATE;

	END

	SELECT * FROM @SEQ_NBR_TO_UPDATE;
	
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO