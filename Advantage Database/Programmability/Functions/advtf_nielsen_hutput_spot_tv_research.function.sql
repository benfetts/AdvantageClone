CREATE FUNCTION [dbo].[advtf_nielsen_hutput_spot_tv_research](
	@MEDIA_SPOT_TV_RESEARCH_ID int,
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@BookIDs varchar(max),
	@SAMPLE_TYPE char(1),
	@PROGRAM_NAME varchar(14),
	@StationCodes varchar(max)
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[avg_hutput] decimal(21,2) NOT NULL,
	[stream] varchar(2) NOT NULL,
	[nielsen_tv_book_id] int NOT NULL,
	[media_spot_tv_research_daytime_id] INT NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @ADJUST_MINUTES smallint
	SET @ADJUST_MINUTES = 180

	DECLARE @tt TABLE (
		[hh] decimal(21,2) NOT NULL,
		[c2-5] decimal(21,2) NOT NULL,
		[c6-11] decimal(21,2) NOT NULL,
		[m12-14] decimal(21,2) NOT NULL,
		[m15-17] decimal(21,2) NOT NULL,
		[m18-20] decimal(21,2) NOT NULL,
		[m21-24] decimal(21,2) NOT NULL,
		[m25-34] decimal(21,2) NOT NULL,
		[m35-49] decimal(21,2) NOT NULL,
		[m50-54] decimal(21,2) NOT NULL,
		[m55-64] decimal(21,2) NOT NULL,
		[m65P] decimal(21,2) NOT NULL,
		[f12-14] decimal(21,2) NOT NULL,
		[f15-17] decimal(21,2) NOT NULL,
		[f18-20] decimal(21,2) NOT NULL,
		[f21-24] decimal(21,2) NOT NULL,
		[f25-34] decimal(21,2) NOT NULL,
		[f35-49] decimal(21,2) NOT NULL,
		[f50-54] decimal(21,2) NOT NULL,
		[f55-64] decimal(21,2) NOT NULL,
		[f65P] decimal(21,2) NOT NULL,
		[ww] decimal(21,2) NOT NULL,
		[stream] varchar(2) NOT NULL,
		[nielsen_tv_book_id] int NOT NULL,
		[media_spot_tv_research_daytime_id] INT NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[hh] = AVG(a.HOUSEHOLD_HUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[c2-5] = AVG(a.CHILDREN_2TO5_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[c6-11] = AVG(a.CHILDREN_6TO11_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m12-14] = AVG(a.MALES_12TO14_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m15-17] = AVG(a.MALES_15TO17_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m18-20] = AVG(a.MALES_18TO20_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m21-24] = AVG(a.MALES_21TO24_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m25-34] = AVG(a.MALES_25TO34_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m35-49] = AVG(a.MALES_35TO49_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m50-54] = AVG(a.MALES_50TO54_PUT ) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m55-64] = AVG(a.MALES_55TO64_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m65P] = AVG(a.MALES_65PLUS_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f12-14] = AVG(a.FEMALES_12TO14_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f15-17] = AVG(a.FEMALES_15TO17_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f18-20] = AVG(a.FEMALES_18TO20_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f21-24] = AVG(a.FEMALES_21TO24_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f25-34] = AVG(a.FEMALES_25TO34_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f35-49] = AVG(a.FEMALES_35TO49_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f50-54] = AVG(a.FEMALES_50TO54_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f55-64] = AVG(a.FEMALES_55TO64_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f65P] = AVG(a.FEMALES_65PLUS_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[ww] = AVG(a.WORKING_WOMEN_PUT) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[stream] = a.STREAM,
		[nielsen_tv_book_id] = a.NIELSEN_TV_BOOK_ID,
		[media_spot_tv_research_daytime_id] = a.MEDIA_SPOT_TV_RESEARCH_DAYTIME_ID
	FROM
		(SELECT 
			HOUSEHOLD_HUT = CAST(HOUSEHOLD_HUT as decimal(21,2)),
			CHILDREN_2TO5_PUT = CAST(CHILDREN_2TO5_PUT as decimal(21,2)),
			CHILDREN_6TO11_PUT = CAST(CHILDREN_6TO11_PUT as decimal(21,2)),
			MALES_12TO14_PUT = CAST(MALES_12TO14_PUT as decimal(21,2)),
			MALES_15TO17_PUT = CAST(MALES_15TO17_PUT as decimal(21,2)),
			MALES_18TO20_PUT = CAST(MALES_18TO20_PUT as decimal(21,2)),
			MALES_21TO24_PUT = CAST(MALES_21TO24_PUT as decimal(21,2)),
			MALES_25TO34_PUT = CAST(MALES_25TO34_PUT as decimal(21,2)),
			MALES_35TO49_PUT = CAST(MALES_35TO49_PUT as decimal(21,2)),
			MALES_50TO54_PUT = CAST(MALES_50TO54_PUT as decimal(21,2)),
			MALES_55TO64_PUT = CAST(MALES_55TO64_PUT as decimal(21,2)),
			MALES_65PLUS_PUT = CAST(MALES_65PLUS_PUT as decimal(21,2)),
			FEMALES_12TO14_PUT = CAST(FEMALES_12TO14_PUT as decimal(21,2)),
			FEMALES_15TO17_PUT = CAST(FEMALES_15TO17_PUT as decimal(21,2)),
			FEMALES_18TO20_PUT = CAST(FEMALES_18TO20_PUT as decimal(21,2)),
			FEMALES_21TO24_PUT = CAST(FEMALES_21TO24_PUT as decimal(21,2)),
			FEMALES_25TO34_PUT = CAST(FEMALES_25TO34_PUT as decimal(21,2)),
			FEMALES_35TO49_PUT = CAST(FEMALES_35TO49_PUT as decimal(21,2)),
			FEMALES_50TO54_PUT = CAST(FEMALES_50TO54_PUT as decimal(21,2)),
			FEMALES_55TO64_PUT = CAST(FEMALES_55TO64_PUT as decimal(21,2)),
			FEMALES_65PLUS_PUT = CAST(FEMALES_65PLUS_PUT as decimal(21,2)),
			WORKING_WOMEN_PUT = CAST(WORKING_WOMEN_PUT as decimal(21,2)),
			a.STREAM,
			a.NIELSEN_TV_BOOK_ID,
			d.MEDIA_SPOT_TV_RESEARCH_DAYTIME_ID,
			MINUTEPART = CASE
							WHEN datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.START_TIME as smalldatetime),HUTPUT_DATETIME) between -15 and -1 THEN
									15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.START_TIME as smalldatetime),HUTPUT_DATETIME) 
							WHEN datediff(mi,HUTPUT_DATETIME,CAST(convert(char(10),a.HUTPUT_DATETIME,110) + ' ' + d.END_TIME as smalldatetime)) between 1 and 14 THEN
									datediff(mi,HUTPUT_DATETIME,CAST(convert(char(10),a.HUTPUT_DATETIME,110) + ' ' + d.END_TIME as smalldatetime))
							ELSE 15 END
		FROM 
			(SELECT
				HOUSEHOLD_HUT,
				CHILDREN_2TO5_PUT,
				CHILDREN_6TO11_PUT,
				MALES_12TO14_PUT,
				MALES_15TO17_PUT,
				MALES_18TO20_PUT,
				MALES_21TO24_PUT,
				MALES_25TO34_PUT,
				MALES_35TO49_PUT,
				MALES_50TO54_PUT,
				MALES_55TO64_PUT,
				MALES_65PLUS_PUT,
				FEMALES_12TO14_PUT,
				FEMALES_15TO17_PUT,
				FEMALES_18TO20_PUT,
				FEMALES_21TO24_PUT,
				FEMALES_25TO34_PUT,
				FEMALES_35TO49_PUT,
				FEMALES_50TO54_PUT,
				FEMALES_55TO64_PUT,
				FEMALES_65PLUS_PUT,
				WORKING_WOMEN_PUT,
				AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), HUTPUT_DATETIME, 101), HUTPUT_DATETIME) < @ADJUST_MINUTES THEN 
										CONVERT(char(10), DATEADD(dd, -1, HUTPUT_DATETIME), 101)
								   ELSE CONVERT(char(10), HUTPUT_DATETIME, 101)
								   END,
				AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), HUTPUT_DATETIME, 101), HUTPUT_DATETIME) < @ADJUST_MINUTES THEN 
									CAST(LEFT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint) + 2400
							   ELSE CAST(LEFT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint)
							   END,
				a.STREAM,
				b.NIELSEN_TV_BOOK_ID,
				a.HUTPUT_DATETIME
				--,p.[PROGRAM_NAME],
				--AdjustedStartDate = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
				--							CONVERT(char(10), DATEADD(dd, -1, QTR_HOUR_START_DATETIME), 101)
				--					ELSE CONVERT(char(10), QTR_HOUR_START_DATETIME, 101)
				--					END,
				--AdjustedStartHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
				--							CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) + 2400
			 -- 						ELSE CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint)
				--					END
			FROM dbo.NIELSEN_TV_HUTPUT a
				INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM 
												 AND b.NIELSEN_TV_BOOK_ID IN (SELECT items FROM dbo.udf_split_list(@BookIDs, ','))
												 AND a.STREAM = b.STREAM 
												 AND a.HUTPUT_DATETIME BETWEEN b.START_DATETIME AND b.END_DATETIME
				--INNER JOIN dbo.NIELSEN_TV_PROGRAM p ON p.NIELSEN_SERVICE = a.NIELSEN_SERVICE 
				--									AND p.NIELSEN_MARKET_NUM = a.NIELSEN_MARKET_NUM 
				--									AND a.HUTPUT_DATETIME = p.QTR_HOUR_START_DATETIME 
				--									AND p.STATION_CODE IN (SELECT items FROM dbo.udf_split_list(@StationCodes, ','))
			WHERE a.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
			AND a.SAMPLE_TYPE = @SAMPLE_TYPE
			AND a.NIELSEN_SERVICE = @NIELSEN_SERVICE
			) a
				INNER JOIN dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME d ON d.MEDIA_SPOT_TV_RESEARCH_ID = @MEDIA_SPOT_TV_RESEARCH_ID 
			WHERE
				a.AdjustedHour >= d.START_HOUR
			AND a.AdjustedHour < d.END_HOUR
			AND	(
				(d.SUNDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
			OR	(d.MONDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
			OR	(d.TUESDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
			OR	(d.WEDNESDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
			OR	(d.THURSDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
			OR	(d.FRIDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
			OR	(d.SATURDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
				)
			--AND	(
			--		(@PROGRAM_NAME IS NULL)
			--	OR
			--		(@PROGRAM_NAME IS NOT NULL AND a.[PROGRAM_NAME] = @PROGRAM_NAME AND a.AdjustedDateTime = a.AdjustedStartDate AND a.AdjustedHour = a.AdjustedStartHour)
			--	)
		) a

	GROUP BY a.STREAM, a.NIELSEN_TV_BOOK_ID, a.MEDIA_SPOT_TV_RESEARCH_DAYTIME_ID
	HAVING AVG(a.HOUSEHOLD_HUT) IS NOT NULL

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.avg_hutput, u.stream, u.nielsen_tv_book_id, u.media_spot_tv_research_daytime_id
	FROM @tt
	UNPIVOT
	(
		avg_hutput
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END