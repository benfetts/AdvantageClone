CREATE FUNCTION [dbo].[advfn_nielsen_program_get](
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@STATION_CODE int,
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
/*
DECLARE
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@STATION_CODE int,
	@START_DATE smalldatetime,
	@END_DATE smalldatetime,
	@START_TIME smallint,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@ADJUST_MINUTES smallint, 
	@SHOW_FULL_PROGRAM_NAMES bit

set	@NIELSEN_SERVICE = '1'
set	@NIELSEN_MARKET_NUM = 101
set @STATION_CODE = 5015
set @START_DATE = '10/27/2016'
set @END_DATE = '11/23/2016'
set @START_TIME = 700
set @END_TIME = 800
set @SUN = 0
set	@MON = 1
set @TUE = 1
set @WED = 1
set @THU = 1
set @FRI = 1
set @SAT = 0
set @ADJUST_MINUTES = 180
set SHOW_FULL_PROGRAM_NAMES = 0
*/
	DECLARE @tt TABLE (
		[ProgramName] varchar(14) NOT NULL,
		[AdjustedStartHour] smallint NOT NULL
	)

	DECLARE @ProgramName varchar(30)

	INSERT INTO @tt
	SELECT	ProgramName,
			AdjustedStartHour = MIN(AdjustedStartHour)  
	FROM
		(
		SELECT 
			ProgramName= [PROGRAM_NAME],
			AdjustedStart = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
								  	  CONVERT(char(10), DATEADD(dd, -1, QTR_HOUR_START_DATETIME), 101)
								 ELSE CONVERT(char(10), QTR_HOUR_START_DATETIME, 101)
								 END,
			AdjustedStartHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
							  			  CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) + 2400
									 ELSE CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint)
									 END,
			AdjustedEnd = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_END_DATETIME, 101), QTR_HOUR_END_DATETIME) < @ADJUST_MINUTES THEN 
									CONVERT(char(10), DATEADD(dd, -1, QTR_HOUR_END_DATETIME), 101)
							   ELSE CONVERT(char(10), QTR_HOUR_END_DATETIME, 101)
							   END,
			AdjustedEndHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_END_DATETIME, 101), QTR_HOUR_END_DATETIME) < @ADJUST_MINUTES THEN 
										CAST(LEFT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint) + 2400
								   ELSE CAST(LEFT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_END_DATETIME, 108),2) as smallint)
								   END 
		FROM dbo.NIELSEN_TV_PROGRAM a
		WHERE a.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
		AND a.NIELSEN_SERVICE = @NIELSEN_SERVICE
		AND a.STATION_CODE = @STATION_CODE
		) a
		WHERE
			a.AdjustedStart >= @START_DATE
		AND a.AdjustedEnd <= @END_DATE
		AND	a.AdjustedStartHour between @START_TIME AND @END_TIME
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

	IF (SELECT COUNT(1) FROM @tt) = 1
		SELECT @ProgramName = ProgramName FROM @tt
	ELSE IF (SELECT COUNT(1) FROM @tt) = 2 BEGIN
		IF @SHOW_FULL_PROGRAM_NAMES = 0 BEGIN
			SELECT TOP 1 @ProgramName = SUBSTRING(ProgramName, 1, 7) + '/' 
			FROM @tt 
			ORDER BY AdjustedStartHour ASC

			SELECT TOP 1 @ProgramName = @ProgramName + SUBSTRING(ProgramName, 1, 6)
			FROM @tt 
			ORDER BY AdjustedStartHour DESC
		END ELSE BEGIN
			SELECT TOP 1 @ProgramName = ProgramName
			FROM @tt 
			ORDER BY AdjustedStartHour ASC

			SELECT TOP 1 @ProgramName = @ProgramName + '/' + ProgramName
			FROM @tt 
			ORDER BY AdjustedStartHour DESC
		END
	END ELSE
		SELECT @ProgramName = 'Various'
		
	RETURN @ProgramName 
END