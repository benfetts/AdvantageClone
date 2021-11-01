CREATE FUNCTION [dbo].[advtf_nielsen_program_get_by_week](
	@NIELSEN_TV_BOOK_ID int,
	@STATION_CODE int,
	@START_TIME smallint,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@ADJUST_MINUTES smallint
)
RETURNS @RETURN_TABLE TABLE (
	[program_name] varchar(29) NOT NULL,
	[week] int NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
/*
DECLARE
	@NIELSEN_TV_BOOK_ID int,
	@STATION_CODE int,
	@START_TIME smallint,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@ADJUST_MINUTES smallint

set	@NIELSEN_TV_BOOK_ID = 7
set @STATION_CODE = 5012
set @START_TIME = 1200
set @END_TIME = 1300
set @SUN = 1
set	@MON = 0
set @TUE = 0
set @WED = 0
set @THU = 0
set @FRI = 0
set @SAT = 0
set @ADJUST_MINUTES = 180
*/
	DECLARE @tt TABLE (
		[ProgramName] varchar(14) NOT NULL,
		[AdjustedStartHour] smallint NOT NULL,
		[NumberRows] int NOT NULL,
		PCT decimal(5,3) NOT NULL,
		[week] int NOT NULL
	)
	
	DECLARE @weeksum TABLE (
		NumberRows int NOT NULL,
		[week] int NOT NULL
	)

	INSERT INTO @tt
	SELECT	ProgramName,
			AdjustedStartHour = MIN(AdjustedStartHour),
			NumberRows = COUNT(1),
			PCT = 0,
			[week]
	FROM
		(
		SELECT 
			ProgramName= [PROGRAM_NAME],
			AdjustedStart = CAST(CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
								  	  CONVERT(char(10), DATEADD(dd, -1, QTR_HOUR_START_DATETIME), 101)
								 ELSE CONVERT(char(10), QTR_HOUR_START_DATETIME, 101)
								 END as smalldatetime),
			AdjustedStartHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
							  			  CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) + 2400
									 ELSE CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint)
									 END,
			AdjustedEndHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_END_DATETIME, 101), QTR_HOUR_END_DATETIME) < @ADJUST_MINUTES THEN 
										CAST(LEFT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint) + 2400
								   ELSE CAST(LEFT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint)
								   END,
			[week] = CASE
						WHEN a.QTR_HOUR_START_DATETIME BETWEEN b.START_DATETIME AND DATEADD(wk,-3,b.END_DATETIME) THEN 1
						WHEN a.QTR_HOUR_START_DATETIME BETWEEN DATEADD(wk,1,b.START_DATETIME) AND DATEADD(wk,-2,b.END_DATETIME) THEN 2
						WHEN a.QTR_HOUR_START_DATETIME BETWEEN DATEADD(wk,2,b.START_DATETIME) AND DATEADD(wk,-1,b.END_DATETIME) THEN 3
						WHEN a.QTR_HOUR_START_DATETIME BETWEEN DATEADD(wk,3,b.START_DATETIME) AND b.END_DATETIME THEN 4
					 END,
			b.NIELSEN_TV_BOOK_ID 
		FROM dbo.NIELSEN_TV_PROGRAM a
			INNER JOIN dbo.NIELSEN_TV_PROGRAM_BOOK pb ON a.NIELSEN_TV_PROGRAM_BOOK_ID = pb.NIELSEN_TV_PROGRAM_BOOK_ID 
			INNER JOIN dbo.NIELSEN_TV_BOOK b ON pb.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM AND pb.[YEAR] = b.[YEAR] AND pb.[MONTH] = b.[MONTH] AND 
				pb.REPORTING_SERVICE = b.REPORTING_SERVICE AND pb.EXCLUSION = b.EXCLUSION AND pb.ETHNICITY = b.ETHNICITY AND b.NIELSEN_TV_BOOK_ID = @NIELSEN_TV_BOOK_ID 
		WHERE a.STATION_CODE = @STATION_CODE
		) a
			INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.NIELSEN_TV_BOOK_ID = b.NIELSEN_TV_BOOK_ID 
		WHERE
			a.AdjustedStart >= b.START_DATETIME
		AND a.AdjustedStart <= b.END_DATETIME 
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
	GROUP BY ProgramName, [week]
	ORDER BY AdjustedStartHour 
	
	INSERT INTO @weeksum (NumberRows, [week])
	SELECT SUM(NumberRows) as NumberRows, [week]
	FROM @tt
	GROUP BY [week]

	--SELECT * FROM @weeksum

	UPDATE @tt SET PCT = CAST(t.NumberRows as decimal) / CAST( (SELECT SUM(NumberRows) FROM @weeksum WHERE [week] = t.[week]) as decimal)
	FROM @tt t
		INNER JOIN @weeksum w ON t.[week] = w.[week]

	DECLARE @WEEK int,
			@ProgramName varchar(29)

	SET @WEEK = 1

	WHILE @WEEK < 5
	BEGIN

		SET @ProgramName = NULL

		IF EXISTS(SELECT ProgramName FROM @tt WHERE PCT >= .65 AND [week] = @WEEK)
			INSERT INTO @RETURN_TABLE ([program_name], [week])
			SELECT ProgramName, [week] FROM @tt WHERE PCT >= .65 AND [week] = @WEEK
		ELSE IF NOT EXISTS(SELECT ProgramName FROM @tt WHERE PCT >= .34 AND [week] = @WEEK)
			INSERT INTO @RETURN_TABLE ([program_name], [week])
			SELECT 'Various*', @WEEK
		ELSE BEGIN	
			SELECT @ProgramName = COALESCE(@ProgramName + '/', '') + ProgramName
			FROM
				(
				SELECT TOP 2 ProgramName, PCT, AdjustedStartHour
				FROM @tt 
				WHERE [week] = @WEEK 
				ORDER BY PCT DESC, AdjustedStartHour ASC
				) res
			ORDER BY AdjustedStartHour ASC

			INSERT INTO @RETURN_TABLE ([program_name], [week]) VALUES (@ProgramName, @WEEK)

		END

		SET @WEEK = @WEEK + 1

	END

	RETURN 
END

GO