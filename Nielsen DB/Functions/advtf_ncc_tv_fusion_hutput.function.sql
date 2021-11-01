CREATE FUNCTION [dbo].[advtf_ncc_tv_fusion_hutput](
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@NIELSEN_MARKET_NUM int,
	@BookIDs varchar(max),
	@StationCodes varchar(max)
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[avg_hutput] decimal(21,2) NOT NULL,
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
		[m12-14] decimal(21,2) NOT NULL, -- holds m15-17 by definition
		--[m15-17] decimal(21,2) NOT NULL,
		[m18-20] decimal(21,2) NOT NULL,
		[m21-24] decimal(21,2) NOT NULL,
		[m25-34] decimal(21,2) NOT NULL,
		[m35-49] decimal(21,2) NOT NULL,
		[m50-54] decimal(21,2) NOT NULL,
		[m55-64] decimal(21,2) NOT NULL,
		[m65P] decimal(21,2) NOT NULL,
		[f12-14] decimal(21,2) NOT NULL, -- holds f15-17 by definition
		--[f15-17] decimal(21,2) NOT NULL,
		[f18-20] decimal(21,2) NOT NULL,
		[f21-24] decimal(21,2) NOT NULL,
		[f25-34] decimal(21,2) NOT NULL,
		[f35-49] decimal(21,2) NOT NULL,
		[f50-54] decimal(21,2) NOT NULL,
		[f55-64] decimal(21,2) NOT NULL,
		[f65P] decimal(21,2) NOT NULL,
		[nielsen_tv_book_id] int NOT NULL,
		[media_spot_tv_research_daytime_id] INT NOT NULL
	)

	INSERT INTO @tt
	SELECT CAST (ROUND( CAST( SUM([hh] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([c2-5] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([c6-11] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m12-14] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m18-20] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m21-24] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m25-34] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m35-49] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m50-54] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m55-64] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([m65P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f12-14] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f18-20] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f21-24] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f25-34] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f35-49] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f50-54] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f55-64] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		CAST (ROUND( CAST( SUM([f65P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as bigint),
		[nielsen_tv_book_id],
		[media_spot_tv_research_daytime_id]
	FROM (
		SELECT
			[hh] = CAST(ROUND(AVG(CAST(a.HOUSEHOLD_HUT as decimal(20))),0) as bigint),
			[c2-5] = CAST(ROUND(AVG(CAST(a.CHILDREN_2TO5_PUT as decimal(20))),0) as bigint),
			[c6-11] = CAST(ROUND(AVG(CAST(a.CHILDREN_6TO11_PUT as decimal(20))),0) as bigint),
			[m12-14] = CAST(ROUND(AVG(CAST(a.MALES_12TO17_PUT as decimal(20))),0) as bigint),
			[m18-20] = CAST(ROUND(AVG(CAST(a.MALES_18TO20_PUT as decimal(20))),0) as bigint),
			[m21-24] = CAST(ROUND(AVG(CAST(a.MALES_21TO24_PUT as decimal(20))),0) as bigint),
			[m25-34] = CAST(ROUND(AVG(CAST(a.MALES_25TO34_PUT as decimal(20))),0) as bigint),
			[m35-49] = CAST(ROUND(AVG(CAST(a.MALES_35TO49_PUT as decimal(20))),0) as bigint),
			[m50-54] = CAST(ROUND(AVG(CAST(a.MALES_50TO54_PUT as decimal(20))),0) as bigint),
			[m55-64] = CAST(ROUND(AVG(CAST(a.MALES_55TO64_PUT as decimal(20))),0) as bigint),
			[m65P] = CAST(ROUND(AVG(CAST(a.MALES_65PLUS_PUT as decimal(20))),0) as bigint),
			[f12-14] = CAST(ROUND(AVG(CAST(a.FEMALES_12TO17_PUT as decimal(20))),0) as bigint),
			[f18-20] = CAST(ROUND(AVG(CAST(a.FEMALES_18TO20_PUT as decimal(20))),0) as bigint),
			[f21-24] = CAST(ROUND(AVG(CAST(a.FEMALES_21TO24_PUT as decimal(20))),0) as bigint),
			[f25-34] = CAST(ROUND(AVG(CAST(a.FEMALES_25TO34_PUT as decimal(20))),0) as bigint),
			[f35-49] = CAST(ROUND(AVG(CAST(a.FEMALES_35TO49_PUT as decimal(20))),0) as bigint),
			[f50-54] = CAST(ROUND(AVG(CAST(a.FEMALES_50TO54_PUT as decimal(20))),0) as bigint),
			[f55-64] = CAST(ROUND(AVG(CAST(a.FEMALES_55TO64_PUT as decimal(20))),0) as bigint),
			[f65P] = CAST(ROUND(AVG(CAST(a.FEMALES_65PLUS_PUT as decimal(20))),0) as bigint),
			[nielsen_tv_book_id] = a.NIELSEN_TV_BOOK_ID,
			[media_spot_tv_research_daytime_id] = a.ID,
			AdjustedHour,
			MINUTEPART 
		FROM
			(SELECT 
				HOUSEHOLD_HUT = CAST(HOUSEHOLD_HUT as decimal(21,2)),
				CHILDREN_2TO5_PUT = CAST(CHILDREN_2TO5_PUT as decimal(21,2)),
				CHILDREN_6TO11_PUT = CAST(CHILDREN_6TO11_PUT as decimal(21,2)),
				MALES_12TO17_PUT = CAST(MALES_12TO17_PUT as decimal(21,2)),
				MALES_18TO20_PUT = CAST(MALES_18TO20_PUT as decimal(21,2)),
				MALES_21TO24_PUT = CAST(MALES_21TO24_PUT as decimal(21,2)),
				MALES_25TO34_PUT = CAST(MALES_25TO34_PUT as decimal(21,2)),
				MALES_35TO49_PUT = CAST(MALES_35TO49_PUT as decimal(21,2)),
				MALES_50TO54_PUT = CAST(MALES_50TO54_PUT as decimal(21,2)),
				MALES_55TO64_PUT = CAST(MALES_55TO64_PUT as decimal(21,2)),
				MALES_65PLUS_PUT = CAST(MALES_65PLUS_PUT as decimal(21,2)),
				FEMALES_12TO17_PUT = CAST(FEMALES_12TO17_PUT as decimal(21,2)),
				FEMALES_18TO20_PUT = CAST(FEMALES_18TO20_PUT as decimal(21,2)),
				FEMALES_21TO24_PUT = CAST(FEMALES_21TO24_PUT as decimal(21,2)),
				FEMALES_25TO34_PUT = CAST(FEMALES_25TO34_PUT as decimal(21,2)),
				FEMALES_35TO49_PUT = CAST(FEMALES_35TO49_PUT as decimal(21,2)),
				FEMALES_50TO54_PUT = CAST(FEMALES_50TO54_PUT as decimal(21,2)),
				FEMALES_55TO64_PUT = CAST(FEMALES_55TO64_PUT as decimal(21,2)),
				FEMALES_65PLUS_PUT = CAST(FEMALES_65PLUS_PUT as decimal(21,2)),
				a.NIELSEN_TV_BOOK_ID,
				d.ID,
				MINUTEPART = CASE
								WHEN datediff(mi,a.AdjustedDateTime + CAST(d.StartTime as datetime),HUTPUT_DATETIME) between -15 and -1 THEN
										15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),HUTPUT_DATETIME) 
								WHEN datediff(mi,HUTPUT_DATETIME,CAST(a.HUTPUT_DATETIME as date) + CAST(d.EndTime as datetime)) between 1 and 14 THEN
										datediff(mi,HUTPUT_DATETIME,CAST(a.HUTPUT_DATETIME as date) + CAST(d.EndTime as datetime))
								ELSE 15 END,
				a.AdjustedDateTime,
				a.AdjustedHour
			FROM 
				(SELECT
					HOUSEHOLD_HUT,
					CHILDREN_2TO5_PUT,
					CHILDREN_6TO11_PUT,
					MALES_12TO17_PUT,
					MALES_18TO20_PUT,
					MALES_21TO24_PUT,
					MALES_25TO34_PUT,
					MALES_35TO49_PUT,
					MALES_50TO54_PUT,
					MALES_55TO64_PUT,
					MALES_65PLUS_PUT,
					FEMALES_12TO17_PUT,
					FEMALES_18TO20_PUT,
					FEMALES_21TO24_PUT,
					FEMALES_25TO34_PUT,
					FEMALES_35TO49_PUT,
					FEMALES_50TO54_PUT,
					FEMALES_55TO64_PUT,
					FEMALES_65PLUS_PUT,
					AdjustedDateTime = CASE WHEN DATEDIFF(mi, CAST(HUTPUT_DATETIME as date), HUTPUT_DATETIME) < @ADJUST_MINUTES THEN 
													CAST(DATEADD(dd, -1, HUTPUT_DATETIME) as date)
											    ELSE CAST(HUTPUT_DATETIME as date)
											    END,
					AdjustedHour = CASE WHEN DATEDIFF(mi, CAST(HUTPUT_DATETIME as date), HUTPUT_DATETIME) < @ADJUST_MINUTES THEN 
											DATEPART(hh, HUTPUT_DATETIME) * 100 + DATEPART(mi, HUTPUT_DATETIME) + 2400
									   ELSE DATEPART(hh, HUTPUT_DATETIME) * 100 + DATEPART(mi, HUTPUT_DATETIME)
									   END,
					b.NIELSEN_TV_BOOK_ID,
					a.HUTPUT_DATETIME,
					b.START_DATETIME,
					b.END_DATETIME 
				FROM dbo.NCC_TV_FUSION_HUTPUT a
					INNER JOIN dbo.NCC_TV_FUSION_UE u ON a.NCC_TV_FUSION_UE_ID = u.NCC_TV_FUSION_UE_ID AND u.VALIDATED = 1
					INNER JOIN dbo.NIELSEN_TV_BOOK b ON u.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM AND u.[YEAR] = b.[YEAR] AND u.[MONTH] = b.[MONTH]
														 AND ((b.STREAM = 'L7' AND u.STREAM = 'L7') OR (b.STREAM <> 'L7' AND u.STREAM = 'LS'))
														 AND b.NIELSEN_TV_BOOK_ID IN (SELECT items FROM dbo.udf_split_list_int(@BookIDs, ','))
														 AND b.REPORTING_SERVICE = '1' AND b.EXCLUSION = '' AND b.ETHNICITY = ''
				) a
					INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON d.ID > 0
				WHERE
					a.AdjustedHour >= d.StartHour
				AND a.AdjustedHour < d.EndHour
				AND	(
					(d.Sunday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
				OR	(d.Monday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
				OR	(d.Tuesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
				OR	(d.Wednesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
				OR	(d.Thursday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
				OR	(d.Friday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
				OR	(d.Saturday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
					)
				AND (
					d.ExactSpotDate IS NULL
				OR
					d.ExactSpotDate IS NOT NULL AND CAST(d.ExactSpotDate as date) = CAST(a.AdjustedDateTime as date) AND d.ExactSpotDate BETWEEN a.START_DATETIME AND a.END_DATETIME
				OR
					d.ExactSpotDate IS NOT NULL AND NOT (d.ExactSpotDate BETWEEN a.START_DATETIME AND a.END_DATETIME)
					)
			) a

		GROUP BY a.NIELSEN_TV_BOOK_ID, a.ID, AdjustedHour, MINUTEPART 
		HAVING AVG(a.HOUSEHOLD_HUT) IS NOT NULL

		) suma
	GROUP BY [nielsen_tv_book_id], [media_spot_tv_research_daytime_id]

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.avg_hutput, u.nielsen_tv_book_id, u.media_spot_tv_research_daytime_id
	FROM @tt
	UNPIVOT
	(
		avg_hutput
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64], [f65P])
	) u

	RETURN
END
GO

GRANT SELECT ON [advtf_ncc_tv_fusion_hutput] TO PUBLIC
GO
