--
CREATE FUNCTION [dbo].[advfn_comscore_program_get](
	@MARKET_NUMBER int,
	@SHARE_BOOK_ID int,
	@STATION_CODE int,
	@PRIMARY_DEMO_NUMBER int,
	@StartHour int,
	@EndHour int,
	@Sunday bit,
	@Monday bit,
	@Tuesday bit,
	@Wednesday bit,
	@Thursday bit,
	@Friday bit,
	@Saturday bit
)
RETURNS varchar(100)
WITH SCHEMABINDING
AS
BEGIN
/*
DECLARE @MARKET_NUMBER int,
	@SHARE_BOOK_ID int,
	@STATION_CODE int,
	@PRIMARY_DEMO_NUMBER int,
	@StartHour int,
	@EndHour int,
	@Sunday bit,
	@Monday bit,
	@Tuesday bit,
	@Wednesday bit,
	@Thursday bit,
	@Friday bit,
	@Saturday bit

	set @MARKET_NUMBER=510
	set @SHARE_BOOK_ID=51
	set @STATION_CODE=4625
	set @PRIMARY_DEMO_NUMBER=652
	set @StartHour = 2100
	set @EndHour = 2200
	set @Sunday = 0
	set @Monday = 0
	set @Tuesday = 0
	set @Wednesday = 0
	set @Thursday = 0
	set @Friday = 0
	set @Saturday = 1
*/
	DECLARE @ADJUST_MINUTES smallint,
			@PROGRAM_NAME varchar(100)
	SET @ADJUST_MINUTES = 180	
	
	DECLARE @prg TABLE (
		SERIES_NAME varchar(141) NOT NULL,
		--COMSCORE_TV_BOOK_ID int NOT NULL,
		--DEMO_NUMBER int NOT NULL,
		--STATION_NUMBER int NOT NULL,
		QTR_HR smalldatetime NOT NULL
	)
	
	INSERT INTO @prg
	SELECT
		a.SERIES_NAME,
		--a.COMSCORE_TV_BOOK_ID,
		--a.DEMO_NUMBER,
		--a.STATION_NUMBER,
		MIN(a.QTR_HR)
	FROM (
			SELECT

				AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HR, 101), QTR_HR) < @ADJUST_MINUTES THEN 
										CONVERT(char(10), DATEADD(dd, -1, QTR_HR), 101)
									ELSE CONVERT(char(10), QTR_HR, 101)
									END,
				AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HR, 101), QTR_HR) < @ADJUST_MINUTES THEN 
									CAST(LEFT(CONVERT(char(5), QTR_HR, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HR, 108),2) as smallint) + 2400
								ELSE CAST(LEFT(CONVERT(char(5), QTR_HR, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HR, 108),2) as smallint)
								END,
				b.COMSCORE_TV_BOOK_ID,
				h.DEMO_NUMBER,
				d.SERIES_NAME,
				h.STATION_NUMBER,
				d.QTR_HR 
			FROM dbo.COMSCORE_CACHE_DETAIL d
				INNER JOIN dbo.COMSCORE_CACHE_HEADER h ON d.COMSCORE_CACHE_HEADER_ID = h.COMSCORE_CACHE_HEADER_ID 
				INNER JOIN dbo.COMSCORE_TV_BOOK b ON d.QTR_HR BETWEEN b.START_DATETIME AND b.END_DATETIME
													AND b.COMSCORE_TV_BOOK_ID = @SHARE_BOOK_ID
			WHERE h.MARKET_NUMBER = @MARKET_NUMBER
			AND h.STATION_NUMBER = @STATION_CODE
			AND h.DEMO_NUMBER = @PRIMARY_DEMO_NUMBER
			) a
		WHERE 
			a.AdjustedHour >= @StartHour 
			AND a.AdjustedHour < @EndHour 
			AND (
					(@Sunday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
				OR	(@Monday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
				OR	(@Tuesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
				OR	(@Wednesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
				OR	(@Thursday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
				OR	(@Friday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
				OR	(@Saturday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
				)
	GROUP BY a.SERIES_NAME
		--a.COMSCORE_TV_BOOK_ID,
		--a.DEMO_NUMBER,
		--a.STATION_NUMBER

	IF(SELECT COUNT(1) FROM @prg) > 2
		SET @PROGRAM_NAME = 'Various'
	ELSE
		SELECT @PROGRAM_NAME = COALESCE(@PROGRAM_NAME + '/', '') + SERIES_NAME
		FROM @prg
		ORDER BY QTR_HR 

	--select @PROGRAM_NAME

	RETURN SUBSTRING(@PROGRAM_NAME,1,100)
END
GO