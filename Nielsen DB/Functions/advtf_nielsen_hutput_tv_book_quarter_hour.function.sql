CREATE FUNCTION [dbo].[advtf_nielsen_hutput_tv_book_quarter_hour](
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@NIELSEN_MARKET_NUM int,
	@NIELSEN_TV_BOOK_ID int,
	@STATION_CODE int
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[avg_hutput] decimal(21,2) NOT NULL,
	[nielsen_tv_book_id] int NOT NULL,
	[media_spot_tv_research_daytime_id] INT NOT NULL,
	[week] int NOT NULL,
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
		[nielsen_tv_book_id] int NOT NULL,
		[media_spot_tv_research_daytime_id] INT NOT NULL,
		[week] int NOT NULL,
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
		[nielsen_tv_book_id],
		[media_spot_tv_research_daytime_id],
		[week],
		[MINUTEPART],
		[AdjustedDateTime],
		[AdjustedHour]
	FROM (
		SELECT
			[hh] = CAST(ROUND(AVG(CAST(a.HOUSEHOLD_HUT as decimal(20))),0) as bigint),
			[c2-5] = CAST(ROUND(AVG(CAST(a.CHILDREN_2TO5_PUT as decimal(20))),0) as bigint),
			[c6-11] = CAST(ROUND(AVG(CAST(a.CHILDREN_6TO11_PUT as decimal(20))),0) as bigint),
			[m12-14] = CAST(ROUND(AVG(CAST(a.MALES_12TO14_PUT as decimal(20))),0) as bigint),
			[m15-17] = CAST(ROUND(AVG(CAST(a.MALES_15TO17_PUT as decimal(20))),0) as bigint),
			[m18-20] = CAST(ROUND(AVG(CAST(a.MALES_18TO20_PUT as decimal(20))),0) as bigint),
			[m21-24] = CAST(ROUND(AVG(CAST(a.MALES_21TO24_PUT as decimal(20))),0) as bigint),
			[m25-34] = CAST(ROUND(AVG(CAST(a.MALES_25TO34_PUT as decimal(20))),0) as bigint),
			[m35-49] = CAST(ROUND(AVG(CAST(a.MALES_35TO49_PUT as decimal(20))),0) as bigint),
			[m50-54] = CAST(ROUND(AVG(CAST(a.MALES_50TO54_PUT as decimal(20))),0) as bigint),
			[m55-64] = CAST(ROUND(AVG(CAST(a.MALES_55TO64_PUT as decimal(20))),0) as bigint),
			[m65P] = CAST(ROUND(AVG(CAST(a.MALES_65PLUS_PUT as decimal(20))),0) as bigint),
			[f12-14] = CAST(ROUND(AVG(CAST(a.FEMALES_12TO14_PUT as decimal(20))),0) as bigint),
			[f15-17] = CAST(ROUND(AVG(CAST(a.FEMALES_15TO17_PUT as decimal(20))),0) as bigint),
			[f18-20] = CAST(ROUND(AVG(CAST(a.FEMALES_18TO20_PUT as decimal(20))),0) as bigint),
			[f21-24] = CAST(ROUND(AVG(CAST(a.FEMALES_21TO24_PUT as decimal(20))),0) as bigint),
			[f25-34] = CAST(ROUND(AVG(CAST(a.FEMALES_25TO34_PUT as decimal(20))),0) as bigint),
			[f35-49] = CAST(ROUND(AVG(CAST(a.FEMALES_35TO49_PUT as decimal(20))),0) as bigint),
			[f50-54] = CAST(ROUND(AVG(CAST(a.FEMALES_50TO54_PUT as decimal(20))),0) as bigint),
			[f55-64] = CAST(ROUND(AVG(CAST(a.FEMALES_55TO64_PUT as decimal(20))),0) as bigint),
			[f65P] = CAST(ROUND(AVG(CAST(a.FEMALES_65PLUS_PUT as decimal(20))),0) as bigint),
			[ww] = CAST(ROUND(AVG(CAST(a.WORKING_WOMEN_PUT as decimal(20))),0) as bigint),
			[nielsen_tv_book_id] = a.[nielsen_tv_book_id],
			[media_spot_tv_research_daytime_id] = a.ID,
			MINUTEPART,
			AdjustedDateTime,
			AdjustedHour,
			[week]
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
				[nielsen_tv_book_id] = NIELSEN_TV_BOOK_ID,
				d.ID,
				MINUTEPART = CASE
								WHEN datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),HUTPUT_DATETIME) between -15 and -1 THEN
										15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),HUTPUT_DATETIME) 
								WHEN datediff(mi,HUTPUT_DATETIME,CAST(convert(char(10),a.HUTPUT_DATETIME,110) + ' ' + d.EndTime as smalldatetime)) between 1 and 14 THEN
										datediff(mi,HUTPUT_DATETIME,CAST(convert(char(10),a.HUTPUT_DATETIME,110) + ' ' + d.EndTime as smalldatetime))
								ELSE 15 END,
				a.AdjustedDateTime,
				a.AdjustedHour,
				a.[week]
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
					a.HUTPUT_DATETIME,
					a.NIELSEN_TV_BOOK_ID,
					[week] = CASE
								WHEN a.HUTPUT_DATETIME BETWEEN b.START_DATETIME AND DATEADD(wk,-3,b.END_DATETIME) THEN 1
								WHEN a.HUTPUT_DATETIME BETWEEN DATEADD(wk,1,b.START_DATETIME) AND DATEADD(wk,-2,b.END_DATETIME) THEN 2
								WHEN a.HUTPUT_DATETIME BETWEEN DATEADD(wk,2,b.START_DATETIME) AND DATEADD(wk,-1,b.END_DATETIME) THEN 3
								WHEN a.HUTPUT_DATETIME BETWEEN DATEADD(wk,3,b.START_DATETIME) AND b.END_DATETIME THEN 4
							 END
				FROM dbo.NIELSEN_TV_HUTPUT a
					INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.NIELSEN_TV_BOOK_ID = b.NIELSEN_TV_BOOK_ID
													 AND b.NIELSEN_TV_BOOK_ID = @NIELSEN_TV_BOOK_ID
													 AND a.HUTPUT_DATETIME BETWEEN b.START_DATETIME AND b.END_DATETIME
				) a
					INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON d.ID > 0
				WHERE
					a.AdjustedHour >= d.StartHour
				AND a.AdjustedHour <= d.EndHour
				AND	(
					(d.Sunday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
				OR	(d.Monday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
				OR	(d.Tuesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
				OR	(d.Wednesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
				OR	(d.Thursday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
				OR	(d.Friday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
				OR	(d.Saturday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
					)
			) a

		GROUP BY a.nielsen_tv_book_id, a.[week], a.ID, AdjustedHour, MINUTEPART, AdjustedDateTime 
		HAVING AVG(a.HOUSEHOLD_HUT) IS NOT NULL

		) suma
	GROUP BY nielsen_tv_book_id, [week], [media_spot_tv_research_daytime_id], AdjustedHour, MINUTEPART, AdjustedDateTime

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.avg_hutput, u.nielsen_tv_book_id, u.media_spot_tv_research_daytime_id, u.[week], MINUTEPART, AdjustedDateTime, AdjustedHour
	FROM @tt
	UNPIVOT
	(
		avg_hutput
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END
GO