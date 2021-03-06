
CREATE FUNCTION dbo.wvfn_resource_is_booked
(
	@RESOURCE_CODE      VARCHAR(6),
	@EVENT_ID_NEEDED    INT,
	@EVENT_DATE_NEEDED  SMALLDATETIME,
	@START_TIME_NEEDED  SMALLDATETIME,
	@END_TIME_NEEDED    SMALLDATETIME
)

RETURNS TINYINT
AS
BEGIN

	DECLARE @IS_BOOKED INT

	DECLARE @DUPE_EVENT_LIST TABLE
	(
	EVENT_ID INT,
	EVENT_LABEL VARCHAR(50),
	EVENT_DATE SMALLDATETIME,
	START_TIME SMALLDATETIME,
	END_TIME SMALLDATETIME,
	RESOURCE_CODE VARCHAR(6)
	);

	INSERT INTO @DUPE_EVENT_LIST(EVENT_ID,EVENT_LABEL,EVENT_DATE,START_TIME,END_TIME,RESOURCE_CODE)
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
	   


	SELECT @IS_BOOKED = COUNT(1) FROM @DUPE_EVENT_LIST;
	
	RETURN @IS_BOOKED;
	
END

