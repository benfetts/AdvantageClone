CREATE FUNCTION [dbo].[advtf_nielsen_audience_spot_tv_research](
	@MEDIA_SPOT_TV_RESEARCH_ID int,
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@SAMPLE_TYPE char(1),
	@StationCodes varchar(max),
	@BookIDs varchar(max),
	@PROGRAM_NAME varchar(14)
) -- based on advtf_nielsen_audience_get
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[audience] bigint NOT NULL,
	[station_code] int NOT NULL,
	[stream] char(2) NOT NULL,
	[nielsen_tv_book_id] int NOT NULL,
	[media_spot_tv_research_daytime_id] int NOT NULL,
	[number_days] smallint NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
/*
DECLARE 
	@MEDIA_SPOT_TV_RESEARCH_ID int,
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@SAMPLE_TYPE char(1),
	@StationCodes varchar(max),
	@BookIDs varchar(max),
	@PROGRAM_NAME varchar(14)

	DECLARE @RETURN_TABLE TABLE (
				[nielsen_demo_code] varchar(6) NOT NULL,
				[audience] bigint NOT NULL,
				[station_code] int NOT NULL,
				[stream] char(2) NOT NULL,
				[nielsen_tv_book_id] int NOT NULL,
				[media_spot_tv_research_daytime_id] int NOT NULL,
				[number_days] smallint NOT NULL
			)

SET @MEDIA_SPOT_TV_RESEARCH_ID = 1
SET @NIELSEN_SERVICE = '1'
SET @NIELSEN_MARKET_NUM = 101
SET @SAMPLE_TYPE = '1'
SET @StationCodes = '5015'
SET @BookIDs = '1'
SET @PROGRAM_NAME = NULL
*/
	DECLARE @ADJUST_MINUTES smallint
	SET @ADJUST_MINUTES = 180

	DECLARE @tt TABLE (
		[hh] bigint NOT NULL,
		[c2-5] bigint NOT NULL,
		[c6-11] bigint NOT NULL,
		[m12-14] bigint NOT NULL,
		[m15-17] bigint NOT NULL,
		[m18-20] bigint NOT NULL,
		[m21-24] bigint NOT NULL,
		[m25-34] bigint NOT NULL,
		[m35-49] bigint NOT NULL,
		[m50-54] bigint NOT NULL,
		[m55-64] bigint NOT NULL,
		[m65P] bigint NOT NULL,
		[f12-14] bigint NOT NULL,
		[f15-17] bigint NOT NULL,
		[f18-20] bigint NOT NULL,
		[f21-24] bigint NOT NULL,
		[f25-34] bigint NOT NULL,
		[f35-49] bigint NOT NULL,
		[f50-54] bigint NOT NULL,
		[f55-64] bigint NOT NULL,
		[f65P] bigint NOT NULL,
		[ww] bigint NOT NULL,
		[station_code] int NOT NULL,
		[stream] char(2) NOT NULL,
		[nielsen_tv_book_id] int NOT NULL,
		[media_spot_tv_research_daytime_id] int NOT NULL,
		[number_days] smallint NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[hh] = SUM(a.HOUSEHOLD_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[c2-5] = SUM(a.CHILDREN_2TO5_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[c6-11] = SUM(a.CHILDREN_6TO11_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m12-14] = SUM(a.MALES_12TO14_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m15-17] = SUM(a.MALES_15TO17_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m18-20] = SUM(a.MALES_18TO20_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m21-24] = SUM(a.MALES_21TO24_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m25-34] = SUM(a.MALES_25TO34_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m35-49] = SUM(a.MALES_35TO49_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m50-54] = SUM(a.MALES_50TO54_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m55-64] = SUM(a.MALES_55TO64_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[m65P] = SUM(a.MALES_65PLUS_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f12-14] = SUM(a.FEMALES_12TO14_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f15-17] = SUM(a.FEMALES_15TO17_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f18-20] = SUM(a.FEMALES_18TO20_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f21-24] = SUM(a.FEMALES_21TO24_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f25-34] = SUM(a.FEMALES_25TO34_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f35-49] = SUM(a.FEMALES_35TO49_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f50-54] = SUM(a.FEMALES_50TO54_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f55-64] = SUM(a.FEMALES_55TO64_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[f65P] = SUM(a.FEMALES_65PLUS_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[ww] = SUM(a.WORKING_WOMEN_AUD) * SUM(MINUTEPART) / (COUNT(1) * 15),
		[station_code] = a.STATION_CODE,
		[stream] = a.STREAM,
		[nielsen_tv_book_id] = a.NIELSEN_TV_BOOK_ID,
		[media_spot_tv_research_daytime_id] = a.MEDIA_SPOT_TV_RESEARCH_DAYTIME_ID,
		[number_days] = a.NUMBER_DAYS
	FROM (
		SELECT
			HOUSEHOLD_AUD = CAST(HOUSEHOLD_AUD as bigint),
			CHILDREN_2TO5_AUD = CAST(CHILDREN_2TO5_AUD as bigint),
			CHILDREN_6TO11_AUD = CAST(CHILDREN_6TO11_AUD as bigint),
			MALES_12TO14_AUD = CAST(MALES_12TO14_AUD as bigint),
			MALES_15TO17_AUD = CAST(MALES_15TO17_AUD as bigint),
			MALES_18TO20_AUD = CAST(MALES_18TO20_AUD as bigint),
			MALES_21TO24_AUD = CAST(MALES_21TO24_AUD as bigint),
			MALES_25TO34_AUD = CAST(MALES_25TO34_AUD as bigint),
			MALES_35TO49_AUD = CAST(MALES_35TO49_AUD as bigint),
			MALES_50TO54_AUD = CAST(MALES_50TO54_AUD as bigint),
			MALES_55TO64_AUD = CAST(MALES_55TO64_AUD as bigint),
			MALES_65PLUS_AUD = CAST(MALES_65PLUS_AUD as bigint),
			FEMALES_12TO14_AUD = CAST(FEMALES_12TO14_AUD as bigint),
			FEMALES_15TO17_AUD = CAST(FEMALES_15TO17_AUD as bigint),
			FEMALES_18TO20_AUD = CAST(FEMALES_18TO20_AUD as bigint),
			FEMALES_21TO24_AUD = CAST(FEMALES_21TO24_AUD as bigint),
			FEMALES_25TO34_AUD = CAST(FEMALES_25TO34_AUD as bigint),
			FEMALES_35TO49_AUD = CAST(FEMALES_35TO49_AUD as bigint),
			FEMALES_50TO54_AUD = CAST(FEMALES_50TO54_AUD as bigint),
			FEMALES_55TO64_AUD = CAST(FEMALES_55TO64_AUD as bigint),
			FEMALES_65PLUS_AUD = CAST(FEMALES_65PLUS_AUD as bigint),
			WORKING_WOMEN_AUD = CAST(WORKING_WOMEN_AUD as bigint),
			a.STATION_CODE,
			a.STREAM,
			a.NIELSEN_TV_BOOK_ID,
			d.MEDIA_SPOT_TV_RESEARCH_DAYTIME_ID,
			NUMBER_DAYS = CAST(d.SUNDAY as smallint) + CAST(d.MONDAY as smallint) + CAST(d.TUESDAY as smallint) + CAST(d.WEDNESDAY as smallint) + CAST(d.THURSDAY as smallint) + CAST(d.FRIDAY as smallint) + CAST(d.SATURDAY as smallint),
			MINUTEPART = CASE
							WHEN datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.START_TIME as smalldatetime),AUDIENCE_DATETIME) between -15 and -1 THEN
									15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.START_TIME as smalldatetime),AUDIENCE_DATETIME) 
							WHEN datediff(mi,AUDIENCE_DATETIME,CAST(convert(char(10),a.AUDIENCE_DATETIME,110) + ' ' + d.END_TIME as smalldatetime)) between 1 and 14 THEN
									datediff(mi,AUDIENCE_DATETIME,CAST(convert(char(10),a.AUDIENCE_DATETIME,110) + ' ' + d.END_TIME as smalldatetime))
							ELSE 15 END
		FROM (
				SELECT
					a.HOUSEHOLD_AUD,
					a.CHILDREN_2TO5_AUD,
					a.CHILDREN_6TO11_AUD,
					a.MALES_12TO14_AUD,
					a.MALES_15TO17_AUD,
					a.MALES_18TO20_AUD,
					a.MALES_21TO24_AUD,
					a.MALES_25TO34_AUD,
					a.MALES_35TO49_AUD,
					a.MALES_50TO54_AUD,
					a.MALES_55TO64_AUD,
					a.MALES_65PLUS_AUD,
					a.FEMALES_12TO14_AUD,
					a.FEMALES_15TO17_AUD,
					a.FEMALES_18TO20_AUD,
					a.FEMALES_21TO24_AUD,
					a.FEMALES_25TO34_AUD,
					a.FEMALES_35TO49_AUD,
					a.FEMALES_50TO54_AUD,
					a.FEMALES_55TO64_AUD,
					a.FEMALES_65PLUS_AUD,
					a.WORKING_WOMEN_AUD,
					a.STATION_CODE,
					a.STREAM,
					a.AUDIENCE_DATETIME,
					AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
									CONVERT(char(10), DATEADD(dd, -1, AUDIENCE_DATETIME), 101)
							   ELSE CONVERT(char(10), AUDIENCE_DATETIME, 101)
							   END,
					AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
										CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) + 2400
								   ELSE CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint)
								   END,
					b.NIELSEN_TV_BOOK_ID
					--,p.[PROGRAM_NAME],
					--AdjustedStartDate = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
					--							CONVERT(char(10), DATEADD(dd, -1, QTR_HOUR_START_DATETIME), 101)
					--					ELSE CONVERT(char(10), QTR_HOUR_START_DATETIME, 101)
					--					END,
					--AdjustedStartHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HOUR_START_DATETIME, 101), QTR_HOUR_START_DATETIME) < @ADJUST_MINUTES THEN 
					--							CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) + 2400
			  --							ELSE CAST(LEFT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HOUR_START_DATETIME, 108),2) as smallint)
					--					END
				FROM dbo.NIELSEN_TV_AUDIENCE a
					INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM AND a.STREAM = b.STREAM AND a.AUDIENCE_DATETIME BETWEEN b.START_DATETIME AND b.END_DATETIME
													 AND b.NIELSEN_TV_BOOK_ID IN (SELECT items FROM dbo.udf_split_list(@BookIDs, ','))
					--INNER JOIN dbo.NIELSEN_TV_PROGRAM p ON p.NIELSEN_SERVICE = a.NIELSEN_SERVICE AND p.NIELSEN_MARKET_NUM = a.NIELSEN_MARKET_NUM AND p.STATION_CODE = a.STATION_CODE
					--									AND a.AUDIENCE_DATETIME = p.QTR_HOUR_START_DATETIME 
				WHERE a.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
				AND a.SAMPLE_TYPE = @SAMPLE_TYPE
				AND a.NIELSEN_SERVICE = @NIELSEN_SERVICE
				AND a.STATION_CODE IN (SELECT items FROM dbo.udf_split_list(@StationCodes, ','))
				--AND 
				--	(
				--		(@PROGRAM_NAME IS NULL)
				--	OR
				--		(@PROGRAM_NAME IS NOT NULL AND p.[PROGRAM_NAME] = @PROGRAM_NAME)
				--	)
			 ) a
				INNER JOIN dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME d ON d.MEDIA_SPOT_TV_RESEARCH_ID = @MEDIA_SPOT_TV_RESEARCH_ID 
			WHERE 
				a.AdjustedHour >= d.START_HOUR
				AND a.AdjustedHour < d.END_HOUR
				AND (
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
		
	GROUP BY a.STATION_CODE, a.STREAM, a.NIELSEN_TV_BOOK_ID, a.MEDIA_SPOT_TV_RESEARCH_DAYTIME_ID, a.NUMBER_DAYS
	HAVING SUM(a.HOUSEHOLD_AUD) IS NOT NULL

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.audience, u.station_code, u.stream, u.nielsen_tv_book_id, u.media_spot_tv_research_daytime_id, u.number_days
	FROM @tt
	UNPIVOT
	(
		audience
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END