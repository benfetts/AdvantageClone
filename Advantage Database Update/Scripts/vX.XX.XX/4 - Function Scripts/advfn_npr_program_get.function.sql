CREATE FUNCTION [dbo].[advfn_npr_program_get](
	@NPR_STATION_ID int,
	@START_DATE smalldatetime,
	@END_DATE smalldatetime,
	@START_TIME smallint,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@ADJUST_MINUTES smallint,
	@SHOW_FULL_PROGRAM_NAMES as bit = 0
)
RETURNS varchar(30)
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @tt TABLE (
		[ProgramName] varchar(100) NOT NULL,
		[AdjustedStartHour] smallint NOT NULL,
		[NumberRows] int NOT NULL,
		PCT decimal(5,3) NOT NULL
	)

	DECLARE @ProgramName varchar(200),
			@TotalRows int

	IF @END_TIME = @START_TIME
		SET @END_TIME = @END_TIME + 1

	INSERT INTO @tt
	SELECT	ProgramName,
			AdjustedStartHour = MIN(AdjustedStartHour),
			NumberRows = COUNT(1),
			PCT = 0
	FROM
		(
		SELECT 
			ProgramName= [PROGRAM_NAME],
			AdjustedStart = CAST(CASE WHEN DATEDIFF(mi, CONVERT(char(10), [DATE], 101), [DATE]) < @ADJUST_MINUTES THEN 
								  	  CONVERT(char(10), DATEADD(dd, -1, [DATE]), 101)
								 ELSE CONVERT(char(10), [DATE], 101)
								 END as smalldatetime),
			AdjustedStartHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), [DATE], 101), [DATE]) < @ADJUST_MINUTES THEN 
							  			  CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint) + 2400
									 ELSE CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint)
									 END,
			--AdjustedEnd = CAST(CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_END_DATETIME, 101), QTR_HOUR_END_DATETIME) < @ADJUST_MINUTES THEN 
			--						CONVERT(char(10), DATEADD(dd, -1, QTR_HOUR_END_DATETIME), 101)
			--				   ELSE CONVERT(char(10), QTR_HOUR_END_DATETIME, 101)
			--				   END as smalldatetime),
			AdjustedEndHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), [DATE], 101), [DATE]) < @ADJUST_MINUTES THEN 
										CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint) + 2400
								   ELSE CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint)
								   END
		FROM dbo.NPR_AUDIENCE a
		WHERE a.NPR_STATION_ID = @NPR_STATION_ID
		) a
		WHERE
			a.AdjustedStart >= @START_DATE
		AND a.AdjustedStart <= @END_DATE
		AND		(
					(a.AdjustedStartHour BETWEEN @START_TIME AND @END_TIME AND a.AdjustedStartHour <> @END_TIME)
				OR
					(a.AdjustedEndHour BETWEEN @START_TIME AND @END_TIME AND a.AdjustedEndHour <> @START_TIME)
				OR
					(@START_TIME >= a.AdjustedStartHour AND @END_TIME <= a.AdjustedEndHour)
				)
		AND (
			(@SUN = 1 AND DATEPART(dw, AdjustedStart) = 1)
		OR	(@MON = 1 AND DATEPART(dw, AdjustedStart) = 2)
		OR	(@TUE = 1 AND DATEPART(dw, AdjustedStart) = 3)
		OR	(@WED = 1 AND DATEPART(dw, AdjustedStart) = 4)
		OR	(@THU = 1 AND DATEPART(dw, AdjustedStart) = 5)
		OR	(@FRI = 1 AND DATEPART(dw, AdjustedStart) = 6)
		OR	(@SAT = 1 AND DATEPART(dw, AdjustedStart) = 7)
			)
	GROUP BY ProgramName
	ORDER BY AdjustedStartHour 
	
	SELECT @TotalRows = SUM(NumberRows) FROM @tt

	UPDATE @tt SET PCT = CAST(NumberRows as decimal) / CAST(@TotalRows as decimal)
	
	--SELECT * FROM @tt

	IF EXISTS(SELECT ProgramName FROM @tt WHERE PCT >= .65)
		SELECT @ProgramName = ProgramName FROM @tt WHERE PCT >= .65
	ELSE IF NOT EXISTS(SELECT ProgramName FROM @tt WHERE PCT >= .34)
		SELECT @ProgramName = 'Various'
	ELSE
		SELECT @ProgramName = COALESCE(@ProgramName + '/', '') + ProgramName
		FROM
			(
			SELECT TOP 2 ProgramName, PCT, AdjustedStartHour
			FROM @tt 
			ORDER BY PCT DESC, AdjustedStartHour ASC
			) res
		ORDER BY AdjustedStartHour ASC

	--SELECT @ProgramName

	RETURN @ProgramName 
END
GO
