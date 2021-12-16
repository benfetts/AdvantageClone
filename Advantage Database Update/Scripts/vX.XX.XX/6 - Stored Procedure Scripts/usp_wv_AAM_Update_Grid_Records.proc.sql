﻿IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_AAM_Update_Grid_Records]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_AAM_Update_Grid_Records]
GO
CREATE PROCEDURE [dbo].[usp_wv_AAM_Update_Grid_Records]
@ALERT_ID VARCHAR(10),
@ALERT_CATEGORY_ID VARCHAR(10),
@USER_CODE VARCHAR(100),
@START_DATE VARCHAR(10) = NULL, -- WHY STRING?
@START_DATE_DIRTY BIT,
@DUE_DATE VARCHAR(10) = NULL, -- WHY STRING?
@DUE_DATE_DIRTY BIT,
@PRIORITY VARCHAR(5), -- WHY STRING?
@PRIORITY_DIRTY BIT
AS
BEGIN
/*=========== QUERY ===========*/
	DECLARE
		@SQL NVARCHAR(2500),
		@COMMENT VARCHAR(MAX),
		@CURRENT_START_DATE_AS_TEXT VARCHAR(30),
		@CURRENT_DUE_DATE_AS_TEXT VARCHAR(30),	
		@CURRENT_PRIORITY VARCHAR(5),
		@GENERATED_DATE VARCHAR(30),
		@CURRENT_START_DATE_AS_DATE SMALLDATETIME,
		@CURRENT_DUE_DATE_AS_DATE SMALLDATETIME,
		@CURRENT_PRIORITY_AS_SMALLINT INT,
		@NEW_START_DATE_AS_DATE SMALLDATETIME,
		@NEW_DUE_DATE_AS_DATE SMALLDATETIME,
		@NEW_PRIORITY_AS_SMALLINT INT,
		@CURRENT_PRIORITY_TEXT VARCHAR(30),
		@NEW_START_DATE_TEXT VARCHAR(30),
		@NEW_DUE_DATE_TEXT VARCHAR(30),
		@NEW_PRIORITY_TEXT VARCHAR(30),
		@ADD_COMMENT BIT
		;

	BEGIN
		SELECT
			@NEW_START_DATE_AS_DATE = CONVERT(DATETIME, @START_DATE),
			@NEW_DUE_DATE_AS_DATE = CONVERT(DATETIME, @DUE_DATE),
			@NEW_PRIORITY_AS_SMALLINT = CONVERT(SMALLINT, @PRIORITY),
			@ADD_COMMENT = 0
			;
		--	TRACK CHANGES SETTING
		SELECT 
			@ADD_COMMENT = CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
		FROM 
			AGY_SETTINGS WITH(NOLOCK) 
		WHERE 
			AGY_SETTINGS_CODE = 'ALRT_ASSGN_TRK_SD';
	END
	--	CHANGE DATA 
	IF @ALERT_CATEGORY_ID <> 71
	BEGIN	--	ASSIGNMENT (NOT TASK)	
		SELECT	
			@CURRENT_START_DATE_AS_TEXT =  CONVERT(VARCHAR(10), @CURRENT_START_DATE_AS_DATE, 101), 
			@CURRENT_DUE_DATE_AS_TEXT = CONVERT(VARCHAR(10), @CURRENT_DUE_DATE_AS_DATE, 101), 
			@CURRENT_PRIORITY = [PRIORITY],
			@CURRENT_START_DATE_AS_DATE = [START_DATE], 
			@CURRENT_DUE_DATE_AS_DATE = DUE_DATE, 
			@CURRENT_PRIORITY_AS_SMALLINT = [PRIORITY]
		FROM 
			ALERT WITH(NOLOCK)
		WHERE 
			ALERT_ID = @ALERT_ID
			;

		SET @SQL = 'UPDATE ALERT WITH(ROWLOCK) ';	
		SET	@SQL += 'SET ';

		IF @START_DATE_DIRTY = 1
		BEGIN
			IF LEN(@START_DATE) > 0
			BEGIN
				SET @SQL += 'START_DATE = CONVERT(DATETIME,''' + @START_DATE + '''), ';
			END
			ELSE
			BEGIN
				SET @SQL += 'START_DATE = NULL, ';
			END
		END
		IF @DUE_DATE_DIRTY = 1
		BEGIN
			IF LEN(@DUE_DATE) > 0
			BEGIN
				SET @SQL += 'DUE_DATE = CONVERT(DATETIME,''' + @DUE_DATE + '''), ';
			END
			ELSE
			BEGIN
				SET @SQL += 'DUE_DATE = NULL, ';
			END
		END
		IF @PRIORITY_DIRTY = 1
		BEGIN
			SET @SQL += 'PRIORITY = ' + @PRIORITY;
		END
		IF SUBSTRING(@SQL, LEN(@SQL), 1) = ','
		BEGIN
			SET @SQL = SUBSTRING(@SQL, 1, LEN(@SQL) - 1);
		END
	
		SET @SQL += ' WHERE ALERT_ID = ' + @ALERT_ID;
	
		EXEC(@SQL);	
		
	END
	ELSE
	BEGIN	--	TASK	
		IF @START_DATE_DIRTY = 1 OR @DUE_DATE_DIRTY = 1
		BEGIN
			DECLARE 
				@JOB_NUMBER VARCHAR(10),
				@JOB_COMPONENT_NBR VARCHAR(5),
				@TASK_SEQ_NBR VARCHAR(5)
				;
			SELECT	
				@CURRENT_START_DATE_AS_TEXT = CONVERT(VARCHAR(10), J.TASK_START_DATE, 101), 
				@CURRENT_DUE_DATE_AS_TEXT = CONVERT(VARCHAR(10), J.JOB_REVISED_DATE, 101), 
				@CURRENT_PRIORITY = A.[PRIORITY],
				@CURRENT_START_DATE_AS_DATE = J.TASK_START_DATE, 
				@CURRENT_DUE_DATE_AS_DATE = J.JOB_REVISED_DATE, 
				@CURRENT_PRIORITY_AS_SMALLINT = A.[PRIORITY],
				@JOB_NUMBER = A.JOB_NUMBER,
				@JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR,
				@TASK_SEQ_NBR = A.TASK_SEQ_NBR
			FROM 
				ALERT A WITH(NOLOCK)
				LEFT JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER
					AND J.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
					AND J.SEQ_NBR = A.TASK_SEQ_NBR
			WHERE 
				A.ALERT_ID = @ALERT_ID
				;

			SET @SQL = 'UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) ';	
			SET	@SQL += 'SET ';

			IF @START_DATE_DIRTY = 1
			BEGIN
				IF LEN(@START_DATE) > 0
				BEGIN
					SET @SQL += 'TASK_START_DATE = CONVERT(DATETIME,''' + @START_DATE + '''), ';
				END
				ELSE
				BEGIN
					SET @SQL += 'TASK_START_DATE = NULL, ';
				END
			END
			IF @DUE_DATE_DIRTY = 1
			BEGIN
				IF LEN(@DUE_DATE) > 0
				BEGIN
					SET @SQL += 'JOB_REVISED_DATE = CONVERT(DATETIME,''' + @DUE_DATE + '''), ';
				END
				ELSE
				BEGIN
					SET @SQL += 'JOB_REVISED_DATE = NULL, ';		
				END
			END
			IF SUBSTRING(@SQL, LEN(@SQL), 1) = ','
			BEGIN
				SET @SQL = SUBSTRING(@SQL, 1, LEN(@SQL) - 1);	
			END
				
			SET @SQL += ' WHERE JOB_NUMBER = ' + @JOB_NUMBER;
			SET @SQL += ' AND JOB_COMPONENT_NBR = ' + @JOB_COMPONENT_NBR;
			SET @SQL += ' AND SEQ_NBR = ' + @TASK_SEQ_NBR;
	
			EXEC(@SQL);		
			--PRINT @SQL;

		END
		IF @PRIORITY_DIRTY = 1
		BEGIN
			UPDATE ALERT WITH(ROWLOCK) SET [PRIORITY] = @NEW_PRIORITY_AS_SMALLINT WHERE ALERT_ID = @ALERT_ID;
		END				
	END	
	--	ADD COMMENT 
	IF @ADD_COMMENT = 1 AND (@START_DATE_DIRTY = 1 OR @DUE_DATE_DIRTY = 1 OR @PRIORITY_DIRTY = 1)
	BEGIN
		SELECT 
			@GENERATED_DATE = GETDATE(),
			@COMMENT = '';
		IF @START_DATE_DIRTY = 1		
		BEGIN
			SELECT
				@CURRENT_START_DATE_AS_TEXT = ISNULL(CONVERT(VARCHAR(10), @CURRENT_START_DATE_AS_DATE, 101), ''),
				@NEW_START_DATE_TEXT = ISNULL(CONVERT(VARCHAR(10), @NEW_START_DATE_AS_DATE, 101), '');

			IF LEN(@CURRENT_START_DATE_AS_TEXT) < 1 OR @CURRENT_START_DATE_AS_TEXT IS NULL OR @CURRENT_START_DATE_AS_DATE IS NULL
			BEGIN
				SET @CURRENT_START_DATE_AS_TEXT = 'no start date';
			END
			IF LEN(@NEW_START_DATE_TEXT) < 1 OR @NEW_START_DATE_TEXT IS NULL OR @NEW_START_DATE_AS_DATE IS NULL
			BEGIN
				SET @NEW_START_DATE_TEXT = 'no start date';
			END
			IF @CURRENT_START_DATE_AS_TEXT <> @NEW_START_DATE_TEXT
			BEGIN
				SET @COMMENT = @COMMENT + 'Start date changed from ' + @CURRENT_START_DATE_AS_TEXT + ' to ' + @NEW_START_DATE_TEXT + '.<br/>';
			END		
		END
		IF @DUE_DATE_DIRTY = 1		
		BEGIN
			SELECT
				@CURRENT_DUE_DATE_AS_TEXT = ISNULL(CONVERT(VARCHAR(10), @CURRENT_DUE_DATE_AS_DATE, 101), ''),
				@NEW_DUE_DATE_TEXT = ISNULL(CONVERT(VARCHAR(10), @NEW_DUE_DATE_AS_DATE, 101), '');
			IF LEN(@CURRENT_DUE_DATE_AS_TEXT) < 1 OR @CURRENT_DUE_DATE_AS_TEXT IS NULL OR @CURRENT_DUE_DATE_AS_DATE IS NULL
			BEGIN
				SET @CURRENT_DUE_DATE_AS_TEXT = 'no due date';
			END
			IF LEN(@NEW_DUE_DATE_TEXT) < 1 OR @NEW_DUE_DATE_TEXT IS NULL OR @NEW_DUE_DATE_AS_DATE IS NULL
			BEGIN
				SET @NEW_DUE_DATE_TEXT = 'no due date';
			END
			IF @CURRENT_DUE_DATE_AS_TEXT <> @NEW_DUE_DATE_TEXT
			BEGIN
				SET @COMMENT = @COMMENT + 'Due date changed from ' + @CURRENT_DUE_DATE_AS_TEXT + ' to ' + @NEW_DUE_DATE_TEXT + '.<br/>';
			END		
		END
		IF @PRIORITY_DIRTY = 1		
		BEGIN
			SELECT @CURRENT_PRIORITY_TEXT =	CASE
												WHEN CAST(@CURRENT_PRIORITY AS SMALLINT) = 5 THEN 'Lowest'
												WHEN CAST(@CURRENT_PRIORITY AS SMALLINT) = 4 THEN 'Low'
												WHEN CAST(@CURRENT_PRIORITY AS SMALLINT) = 3 THEN 'Normal'
												WHEN CAST(@CURRENT_PRIORITY AS SMALLINT) = 2 THEN 'High'
												WHEN CAST(@CURRENT_PRIORITY AS SMALLINT) = 1 THEN 'Highest'
												ELSE 'Normal'
											END;
			SELECT @NEW_PRIORITY_TEXT =		CASE
												WHEN CAST(@PRIORITY AS SMALLINT) = 5 THEN 'Lowest'
												WHEN CAST(@PRIORITY AS SMALLINT) = 4 THEN 'Low'
												WHEN CAST(@PRIORITY AS SMALLINT) = 3 THEN 'Normal'
												WHEN CAST(@PRIORITY AS SMALLINT) = 2 THEN 'High'
												WHEN CAST(@PRIORITY AS SMALLINT) = 1 THEN 'Highest'
												ELSE 'Normal'
											END;
			IF LEN(@CURRENT_PRIORITY) < 1 OR @CURRENT_PRIORITY IS NULL
			BEGIN
				SET @CURRENT_PRIORITY = 'Normal';
			END
            IF @CURRENT_PRIORITY_TEXT <> @NEW_PRIORITY_TEXT
            BEGIN
			    SET @COMMENT = @COMMENT + 'Priority changed from ' + @CURRENT_PRIORITY_TEXT + ' to ' + @NEW_PRIORITY_TEXT + '.';		
            END
		END
		INSERT INTO ALERT_COMMENT WITH(ROWLOCK) (ALERT_ID, USER_CODE, GENERATED_DATE, EMAILSENT, COMMENT) 
		VALUES  (@ALERT_ID, @USER_CODE, @GENERATED_DATE, 0, @COMMENT);
	END
/*=========== QUERY ===========*/
END