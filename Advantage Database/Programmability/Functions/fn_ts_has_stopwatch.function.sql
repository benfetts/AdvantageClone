--DROP FUNCTION [dbo].[fn_ts_has_stopwatch]
CREATE FUNCTION [dbo].[fn_ts_has_stopwatch] (@EMP_CODE VARCHAR(6),
											@START_DATE SMALLDATETIME,
											@END_DATE SMALLDATETIME)
RETURNS @STOPWATCH_DATA TABLE 
(
	HAS_STOPWATCH INT,
	STOPWATCH_ET_ID INT,
	STOPWATCH_ET_DTL_ID SMALLINT,
	STOPWATCH_START_TIME SMALLDATETIME,
	COMMENT VARCHAR(MAX),
	[DESCRIPTION] VARCHAR(60),
	TIME_TYPE VARCHAR(1),
	CURR_SERVER_TIME SMALLDATETIME
)
AS
BEGIN

/*=========== QUERY ===========*/
	DECLARE
		@HAS_STOPWATCH INT,
		@STOPWATCH_ET_ID INT,
		@STOPWATCH_ET_DTL_ID SMALLINT,
		@STOPWATCH_START_TIME SMALLDATETIME,
		@COMMENT VARCHAR(MAX),
		@DESCRIPTION VARCHAR(60),
		@JOB_NUMBER INT,
		@JOB_COMPONENT_NBR SMALLINT,
		@TIME_TYPE VARCHAR(1)
		
		
	IF (@START_DATE IS NULL OR @END_DATE IS NULL) 
		BEGIN
			SELECT @HAS_STOPWATCH = COUNT(1), @STOPWATCH_ET_ID = ET_ID, @STOPWATCH_ET_DTL_ID = STOP_WATCH_ET_DTL_ID, @STOPWATCH_START_TIME = STOP_WATCH_START_TIME 
			FROM EMP_TIME WITH(NOLOCK) 
			WHERE 
				EMP_CODE = @EMP_CODE
				AND NOT STOP_WATCH_START_TIME IS NULL
				AND NOT STOP_WATCH_ET_DTL_ID IS NULL
			GROUP BY
				ET_ID, STOP_WATCH_ET_DTL_ID, STOP_WATCH_START_TIME	
				;
		END	
	ELSE
		BEGIN
			SELECT @HAS_STOPWATCH = COUNT(1), @STOPWATCH_ET_ID = ET_ID, @STOPWATCH_ET_DTL_ID = STOP_WATCH_ET_DTL_ID, @STOPWATCH_START_TIME = STOP_WATCH_START_TIME 
			FROM EMP_TIME WITH(NOLOCK) 
			WHERE 
				EMP_CODE = @EMP_CODE
				AND NOT STOP_WATCH_START_TIME IS NULL
				AND EMP_DATE BETWEEN @START_DATE AND @END_DATE
			GROUP BY
				ET_ID, STOP_WATCH_ET_DTL_ID, STOP_WATCH_START_TIME	
				;
		END

	SET @HAS_STOPWATCH = ISNULL(@HAS_STOPWATCH, 0);
	SET @STOPWATCH_ET_ID = ISNULL(@STOPWATCH_ET_ID, 0);
	SET @STOPWATCH_ET_DTL_ID = ISNULL(@STOPWATCH_ET_DTL_ID, 0);
	SET @TIME_TYPE = 'D';

	IF @HAS_STOPWATCH > 0 AND @STOPWATCH_ET_ID > 0 AND @STOPWATCH_ET_DTL_ID > 0
	BEGIN
		SET @COMMENT = (SELECT TOP 1 CAST(EMP_COMMENT AS VARCHAR(MAX)) FROM EMP_TIME_DTL_CMTS WITH(NOLOCK) WHERE ET_ID = @STOPWATCH_ET_ID AND ET_DTL_ID = @STOPWATCH_ET_DTL_ID);

		SELECT    
			@JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER, 
			@JOB_COMPONENT_NBR = EMP_TIME_DTL.JOB_COMPONENT_NBR, 
			@DESCRIPTION = JOB_COMPONENT.JOB_COMP_DESC
		FROM         
			EMP_TIME_DTL WITH(NOLOCK) INNER JOIN
			JOB_COMPONENT WITH(NOLOCK) ON EMP_TIME_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
			EMP_TIME_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
		WHERE
			(EMP_TIME_DTL.ET_ID = @STOPWATCH_ET_ID)
			AND (EMP_TIME_DTL.ET_DTL_ID = @STOPWATCH_ET_DTL_ID);

			
		IF @JOB_NUMBER IS NULL OR @JOB_COMPONENT_NBR IS NULL
		BEGIN
			SELECT @DESCRIPTION = A.[DESCRIPTION]
			FROM (
				SELECT     
					TOP 1 ISNULL(TIME_CATEGORY.[DESCRIPTION], EMP_TIME_NP.CATEGORY) AS [DESCRIPTION]
				FROM         
					EMP_TIME_NP WITH(NOLOCK) LEFT OUTER JOIN
					TIME_CATEGORY WITH(NOLOCK) ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
				WHERE     
					(EMP_TIME_NP.ET_ID = @STOPWATCH_ET_ID) 
					AND (EMP_TIME_NP.ET_DTL_ID = @STOPWATCH_ET_DTL_ID)
			) AS [A];
			SET @TIME_TYPE = 'N';
		END	                      

	END
	
	INSERT INTO @STOPWATCH_DATA (HAS_STOPWATCH, STOPWATCH_ET_ID, STOPWATCH_ET_DTL_ID,STOPWATCH_START_TIME, COMMENT, [DESCRIPTION], TIME_TYPE, CURR_SERVER_TIME)
	VALUES (@HAS_STOPWATCH, @STOPWATCH_ET_ID, @STOPWATCH_ET_DTL_ID, @STOPWATCH_START_TIME, @COMMENT, @DESCRIPTION, @TIME_TYPE, GETDATE())
		
/*=========== QUERY ===========*/
		
RETURN

END