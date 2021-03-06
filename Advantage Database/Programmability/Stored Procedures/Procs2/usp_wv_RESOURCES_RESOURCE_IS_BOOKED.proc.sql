
CREATE PROCEDURE [dbo].[usp_wv_RESOURCES_RESOURCE_IS_BOOKED] /*WITH ENCRYPTION*/
@RESOURCE_CODE      VARCHAR(6),
@EVENT_ID_NEEDED    INT,
@EVENT_DATE_NEEDED  SMALLDATETIME,
@START_TIME_NEEDED  SMALLDATETIME,
@END_TIME_NEEDED    SMALLDATETIME,
@RETURN_COUNT_ONLY  BIT
AS
/*=========== QUERY ===========*/
	IF @RETURN_COUNT_ONLY IS NULL
	BEGIN
		SET @RETURN_COUNT_ONLY = 0;
	END

	CREATE TABLE #DUPE_EVENT_LIST
	(
	EVENT_ID INT,
	EVENT_LABEL VARCHAR(50),
	EVENT_DATE SMALLDATETIME,
	START_TIME SMALLDATETIME,
	END_TIME SMALLDATETIME,
	RESOURCE_CODE VARCHAR(6)
	);

	INSERT INTO #DUPE_EVENT_LIST(EVENT_ID,EVENT_LABEL,EVENT_DATE,START_TIME,END_TIME,RESOURCE_CODE)
	SELECT 
	[EVENT].EVENT_ID, 
	[EVENT].EVENT_LABEL,
	[EVENT].EVENT_DATE,
	[EVENT].START_TIME,
	[EVENT].END_TIME,
	[RESOURCE].RESOURCE_CODE
	FROM   [EVENT] WITH(NOLOCK)
		   INNER JOIN RESOURCE WITH(NOLOCK)
				ON  [EVENT].RESOURCE_CODE = RESOURCE.RESOURCE_CODE
	WHERE  
			--(
			--	(RESOURCE.INACTIVE_FLAG IS NULL)
			--	OR (RESOURCE.INACTIVE_FLAG = 0)
			--) 
			--AND
			[RESOURCE].RESOURCE_CODE = @RESOURCE_CODE
			AND
			[EVENT].EVENT_DATE = @EVENT_DATE_NEEDED
			AND (
				   (
					   [EVENT].START_TIME <= @START_TIME_NEEDED
					   AND [EVENT].END_TIME >= @END_TIME_NEEDED
				   )
				   OR (
						  [EVENT].START_TIME <= @START_TIME_NEEDED
						  AND [EVENT].END_TIME BETWEEN @START_TIME_NEEDED AND @END_TIME_NEEDED
					  )
				   OR (
						  [EVENT].START_TIME BETWEEN @START_TIME_NEEDED AND @END_TIME_NEEDED
					  )
				   OR (
						  [EVENT].END_TIME BETWEEN @START_TIME_NEEDED AND @END_TIME_NEEDED
					  )
			)
			AND (
					[EVENT].END_TIME <> @START_TIME_NEEDED
					AND
					[EVENT].START_TIME <> @END_TIME_NEEDED
				)
		   AND [EVENT].EVENT_ID <> @EVENT_ID_NEEDED
		   ;
	   
	IF @RETURN_COUNT_ONLY = 1
		BEGIN
			SELECT COUNT(1) AS NUM_OVER_BOOKED_EVENTS FROM #DUPE_EVENT_LIST;
		END
	ELSE
		BEGIN
			SELECT * FROM #DUPE_EVENT_LIST;
		END
	   
	DROP TABLE #DUPE_EVENT_LIST	   
/*=========== QUERY ===========*/
