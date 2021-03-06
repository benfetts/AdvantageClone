CREATE FUNCTION [dbo].[advtf_nielsen_audience_tv_book_quarter_hour](
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@NIELSEN_MARKET_NUM int,
	@STATION_CODE int,
	@SHARE_BOOK_ID int
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[audience] bigint NOT NULL,
	[station_code] int NOT NULL,
	[nielsen_tv_book_id] int NOT NULL,
	[week] int NOT NULL,
	[media_spot_tv_research_daytime_id] int NOT NULL,
	[number_days] smallint NOT NULL,
	[MINUTEPART] int NOT NULL,
	[AdjustedDateTime] smalldatetime NOT NULL,
	[AdjustedHour] int NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
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
		[nielsen_tv_book_id] int NOT NULL,
		[week] int NOT NULL,
		[media_spot_tv_research_daytime_id] int NOT NULL,
		[number_days] smallint NOT NULL,
		[MINUTEPART] int NOT NULL,
		[AdjustedDateTime] smalldatetime NOT NULL,
		[AdjustedHour] int NOT NULL
	)

	INSERT INTO @tt
	SELECT CAST (ROUND( CAST( SUM([hh] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([c2-5] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([c6-11] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m12-14] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m15-17] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m18-20] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m21-24] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m25-34] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m35-49] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m50-54] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m55-64] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m65P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f12-14] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f15-17] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f18-20] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f21-24] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f25-34] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f35-49] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f50-54] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f55-64] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f65P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([ww] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		[station_code],
		[nielsen_tv_book_id],
		[week],
		[media_spot_tv_research_daytime_id],
		[number_days],
		[MINUTEPART],
		[AdjustedDateTime],
		[AdjustedHour] 
	FROM (
		SELECT
			[hh] = CAST(ROUND(AVG(CAST(a.HOUSEHOLD_AUD as decimal(20))),0) as bigint),
			[c2-5] = CAST(ROUND(AVG(CAST(a.CHILDREN_2TO5_AUD as decimal(20))),0) as bigint),
			[c6-11] = CAST(ROUND(AVG(CAST(a.CHILDREN_6TO11_AUD as decimal(20))),0) as bigint),
			[m12-14] = CAST(ROUND(AVG(CAST(a.MALES_12TO14_AUD as decimal(20))),0) as bigint),
			[m15-17] = CAST(ROUND(AVG(CAST(a.MALES_15TO17_AUD as decimal(20))),0) as bigint),
			[m18-20] = CAST(ROUND(AVG(CAST(a.MALES_18TO20_AUD as decimal(20))),0) as bigint),
			[m21-24] = CAST(ROUND(AVG(CAST(a.MALES_21TO24_AUD as decimal(20))),0) as bigint),
			[m25-34] = CAST(ROUND(AVG(CAST(a.MALES_25TO34_AUD as decimal(20))),0) as bigint),
			[m35-49] = CAST(ROUND(AVG(CAST(a.MALES_35TO49_AUD as decimal(20))),0) as bigint),
			[m50-54] = CAST(ROUND(AVG(CAST(a.MALES_50TO54_AUD as decimal(20))),0) as bigint),
			[m55-64] = CAST(ROUND(AVG(CAST(a.MALES_55TO64_AUD as decimal(20))),0) as bigint),
			[m65P] = CAST(ROUND(AVG(CAST(a.MALES_65PLUS_AUD as decimal(20))),0) as bigint),
			[f12-14] = CAST(ROUND(AVG(CAST(a.FEMALES_12TO14_AUD as decimal(20))),0) as bigint),
			[f15-17] = CAST(ROUND(AVG(CAST(a.FEMALES_15TO17_AUD as decimal(20))),0) as bigint),
			[f18-20] = CAST(ROUND(AVG(CAST(a.FEMALES_18TO20_AUD as decimal(20))),0) as bigint),
			[f21-24] = CAST(ROUND(AVG(CAST(a.FEMALES_21TO24_AUD as decimal(20))),0) as bigint),
			[f25-34] = CAST(ROUND(AVG(CAST(a.FEMALES_25TO34_AUD as decimal(20))),0) as bigint),
			[f35-49] = CAST(ROUND(AVG(CAST(a.FEMALES_35TO49_AUD as decimal(20))),0) as bigint),
			[f50-54] = CAST(ROUND(AVG(CAST(a.FEMALES_50TO54_AUD as decimal(20))),0) as bigint),
			[f55-64] = CAST(ROUND(AVG(CAST(a.FEMALES_55TO64_AUD as decimal(20))),0) as bigint),
			[f65P] = CAST(ROUND(AVG(CAST(a.FEMALES_65PLUS_AUD as decimal(20))),0) as bigint),
			[ww] = CAST(ROUND(AVG(CAST(a.WORKING_WOMEN_AUD as decimal(20))),0) as bigint),
			[station_code] = a.STATION_CODE,
			[nielsen_tv_book_id] = a.NIELSEN_TV_BOOK_ID,
			[week] = a.[week],
			[media_spot_tv_research_daytime_id] = a.ID,
			[number_days] = a.NUMBER_DAYS,
			MINUTEPART,
			AdjustedDateTime,
			AdjustedHour
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
				a.NIELSEN_TV_BOOK_ID,
				[week],
				d.ID,
				NUMBER_DAYS = CAST(d.Sunday as smallint) + CAST(d.Monday as smallint) + CAST(d.Tuesday as smallint) + CAST(d.Wednesday as smallint) + CAST(d.Thursday as smallint) + CAST(d.Friday as smallint) + CAST(d.Saturday as smallint),
				MINUTEPART = CASE
								WHEN datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),AUDIENCE_DATETIME) between -15 and -1 THEN
										15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),AUDIENCE_DATETIME) 
								WHEN datediff(mi,AUDIENCE_DATETIME,CAST(convert(char(10),a.AUDIENCE_DATETIME,110) + ' ' + d.EndTime as smalldatetime)) between 1 and 14 THEN
										datediff(mi,AUDIENCE_DATETIME,CAST(convert(char(10),a.AUDIENCE_DATETIME,110) + ' ' + d.EndTime as smalldatetime))
								ELSE 15 END,
				a.AdjustedDateTime,
				a.AdjustedHour
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
						a.AUDIENCE_DATETIME,
						AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
										CONVERT(char(10), DATEADD(dd, -1, AUDIENCE_DATETIME), 101)
								   ELSE CONVERT(char(10), AUDIENCE_DATETIME, 101)
								   END,
						AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
											CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) + 2400
									   ELSE CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint)
									   END,
						b.NIELSEN_TV_BOOK_ID,
						[week] = CASE
									WHEN a.AUDIENCE_DATETIME BETWEEN b.START_DATETIME AND DATEADD(wk,-3,b.END_DATETIME) THEN 1
									WHEN a.AUDIENCE_DATETIME BETWEEN DATEADD(wk,1,b.START_DATETIME) AND DATEADD(wk,-2,b.END_DATETIME) THEN 2
									WHEN a.AUDIENCE_DATETIME BETWEEN DATEADD(wk,2,b.START_DATETIME) AND DATEADD(wk,-1,b.END_DATETIME) THEN 3
									WHEN a.AUDIENCE_DATETIME BETWEEN DATEADD(wk,3,b.START_DATETIME) AND b.END_DATETIME THEN 4
								 END
					FROM dbo.NIELSEN_TV_AUDIENCE a
						INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.NIELSEN_TV_BOOK_ID = b.NIELSEN_TV_BOOK_ID AND a.AUDIENCE_DATETIME BETWEEN b.START_DATETIME AND b.END_DATETIME
														 AND b.NIELSEN_TV_BOOK_ID = @SHARE_BOOK_ID
					WHERE a.STATION_CODE = @STATION_CODE
				 ) a
					INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON d.ID > 0
				WHERE 
					a.AdjustedHour >= d.StartHour
					AND a.AdjustedHour <= d.EndHour
					AND (
						(d.Sunday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
					OR	(d.Monday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
					OR	(d.Tuesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
					OR	(d.Wednesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
					OR	(d.Thursday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
					OR	(d.Friday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
					OR	(d.Saturday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
						)
			) a
		
		GROUP BY a.NIELSEN_TV_BOOK_ID, [week], a.STATION_CODE, a.ID, a.NUMBER_DAYS, AdjustedHour, MINUTEPART, AdjustedDateTime 
		HAVING SUM(a.HOUSEHOLD_AUD) IS NOT NULL
		) suma
	GROUP BY [station_code], nielsen_tv_book_id, [week], [media_spot_tv_research_daytime_id], [number_days], AdjustedHour, MINUTEPART, AdjustedDateTime

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.audience, u.station_code, u.nielsen_tv_book_id, [week], u.media_spot_tv_research_daytime_id, u.number_days, MINUTEPART, AdjustedDateTime, AdjustedHour
	FROM @tt
	UNPIVOT
	(
		audience
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END
GO