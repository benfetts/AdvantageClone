CREATE FUNCTION [dbo].[advtf_ncc_tv_fusion_audience_postbuy](
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@NIELSEN_MARKET_NUM int,
	@StationCodes varchar(max),
	@BookIDs varchar(max)
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[audience] bigint NOT NULL,
	[station_code] int NOT NULL,
	[nielsen_tv_book_id] int NOT NULL,
	[media_spot_tv_research_daytime_id] int NOT NULL,
	[number_days] smallint NOT NULL
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
		[m12-14] bigint NOT NULL, -- holds m15-17 by definition
		--[m15-17] bigint NOT NULL,
		[m18-20] bigint NOT NULL,
		[m21-24] bigint NOT NULL,
		[m25-34] bigint NOT NULL,
		[m35-49] bigint NOT NULL,
		[m50-54] bigint NOT NULL,
		[m55-64] bigint NOT NULL,
		[m65P] bigint NOT NULL,
		[f12-14] bigint NOT NULL, -- holds f15-17 by definition
		--[f15-17] bigint NOT NULL,
		[f18-20] bigint NOT NULL,
		[f21-24] bigint NOT NULL,
		[f25-34] bigint NOT NULL,
		[f35-49] bigint NOT NULL,
		[f50-54] bigint NOT NULL,
		[f55-64] bigint NOT NULL,
		[f65P] bigint NOT NULL,
		[station_code] int NOT NULL,
		[nielsen_tv_book_id] int NOT NULL,
		[media_spot_tv_research_daytime_id] int NOT NULL,
		[number_days] smallint NOT NULL
	)

	DECLARE @RESULTS TABLE (
		HOUSEHOLD_AUD bigint NOT NULL,
		CHILDREN_2TO5_AUD bigint NOT NULL,
		CHILDREN_6TO11_AUD bigint NOT NULL,
		MALES_12TO17_AUD bigint NOT NULL,
		MALES_18TO20_AUD bigint NOT NULL,
		MALES_21TO24_AUD bigint NOT NULL,
		MALES_25TO34_AUD bigint NOT NULL,
		MALES_35TO49_AUD bigint NOT NULL,
		MALES_50TO54_AUD bigint NOT NULL,
		MALES_55TO64_AUD bigint NOT NULL,
		MALES_65PLUS_AUD bigint NOT NULL,
		FEMALES_12TO17_AUD bigint NOT NULL,
		FEMALES_18TO20_AUD bigint NOT NULL,
		FEMALES_21TO24_AUD bigint NOT NULL,
		FEMALES_25TO34_AUD bigint NOT NULL,
		FEMALES_35TO49_AUD bigint NOT NULL,
		FEMALES_50TO54_AUD bigint NOT NULL,
		FEMALES_55TO64_AUD bigint NOT NULL,
		FEMALES_65PLUS_AUD bigint NOT NULL,
		STATION_CODE int NOT NULL,
		NIELSEN_TV_BOOK_ID int NOT NULL,
		ID int NOT NULL,
		NUMBER_DAYS smallint NOT NULL,
		MINUTEPART smallint NOT NULL,
		AdjustedDateTime smalldatetime NOT NULL,
		AdjustedHour smallint NOT NULL,
		[MATCH] int NOT NULL
	)

	INSERT INTO @RESULTS
	SELECT
		HOUSEHOLD_AUD = CAST(HOUSEHOLD_AUD as bigint),
		CHILDREN_2TO5_AUD = CAST(CHILDREN_2TO5_AUD as bigint),
		CHILDREN_6TO11_AUD = CAST(CHILDREN_6TO11_AUD as bigint),
		MALES_12TO17_AUD = CAST(MALES_12TO17_AUD as bigint),
		MALES_18TO20_AUD = CAST(MALES_18TO20_AUD as bigint),
		MALES_21TO24_AUD = CAST(MALES_21TO24_AUD as bigint),
		MALES_25TO34_AUD = CAST(MALES_25TO34_AUD as bigint),
		MALES_35TO49_AUD = CAST(MALES_35TO49_AUD as bigint),
		MALES_50TO54_AUD = CAST(MALES_50TO54_AUD as bigint),
		MALES_55TO64_AUD = CAST(MALES_55TO64_AUD as bigint),
		MALES_65PLUS_AUD = CAST(MALES_65PLUS_AUD as bigint),
		FEMALES_12TO17_AUD = CAST(FEMALES_12TO17_AUD as bigint),
		FEMALES_18TO20_AUD = CAST(FEMALES_18TO20_AUD as bigint),
		FEMALES_21TO24_AUD = CAST(FEMALES_21TO24_AUD as bigint),
		FEMALES_25TO34_AUD = CAST(FEMALES_25TO34_AUD as bigint),
		FEMALES_35TO49_AUD = CAST(FEMALES_35TO49_AUD as bigint),
		FEMALES_50TO54_AUD = CAST(FEMALES_50TO54_AUD as bigint),
		FEMALES_55TO64_AUD = CAST(FEMALES_55TO64_AUD as bigint),
		FEMALES_65PLUS_AUD = CAST(FEMALES_65PLUS_AUD as bigint),
		a.STATION_CODE,
		a.NIELSEN_TV_BOOK_ID,
		d.ID,
		NUMBER_DAYS = CAST(d.Sunday as smallint) + CAST(d.Monday as smallint) + CAST(d.Tuesday as smallint) + CAST(d.Wednesday as smallint) + CAST(d.Thursday as smallint) + CAST(d.Friday as smallint) + CAST(d.Saturday as smallint),
		MINUTEPART = CASE
						WHEN datediff(mi,a.AdjustedDateTime + CAST(d.StartTime as datetime),AUDIENCE_DATETIME) between -15 and -1 THEN
								15 + datediff(mi,CAST(a.AdjustedDateTime as date) + CAST(d.StartTime as datetime), AUDIENCE_DATETIME) 
						WHEN datediff(mi,AUDIENCE_DATETIME,CAST(a.AUDIENCE_DATETIME as date) + CAST(d.EndTime as datetime)) between 1 and 14 THEN
								datediff(mi,AUDIENCE_DATETIME,CAST(a.AUDIENCE_DATETIME as date) + CAST(d.EndTime as datetime))
						ELSE 15 END,
		a.AdjustedDateTime,
		a.AdjustedHour,
		[MATCH] = CAST(CASE WHEN d.Sunday = 1 AND DP = 1 THEN 1
			WHEN d.Monday = 1 AND DP = 2 THEN 2
			WHEN d.Tuesday = 1 AND DP = 3 THEN 3
			WHEN d.Wednesday = 1 AND DP = 4 THEN 4
			WHEN d.Thursday = 1 AND DP = 5 THEN 5
			WHEN d.Friday = 1 AND DP = 6 THEN 6
			WHEN d.Saturday = 1 AND DP = 7 THEN 7
			ELSE 0
			END as int)
	FROM (
		SELECT
			a.HOUSEHOLD_AUD,
			a.CHILDREN_2TO5_AUD,
			a.CHILDREN_6TO11_AUD,
			a.MALES_12TO17_AUD,
			a.MALES_18TO20_AUD,
			a.MALES_21TO24_AUD,
			a.MALES_25TO34_AUD,
			a.MALES_35TO49_AUD,
			a.MALES_50TO54_AUD,
			a.MALES_55TO64_AUD,
			a.MALES_65PLUS_AUD,
			a.FEMALES_12TO17_AUD,
			a.FEMALES_18TO20_AUD,
			a.FEMALES_21TO24_AUD,
			a.FEMALES_25TO34_AUD,
			a.FEMALES_35TO49_AUD,
			a.FEMALES_50TO54_AUD,
			a.FEMALES_55TO64_AUD,
			a.FEMALES_65PLUS_AUD,
			a.STATION_CODE,
			a.AUDIENCE_DATETIME,
			AdjustedDateTime = CASE WHEN DATEDIFF(mi, CAST(AUDIENCE_DATETIME as date), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
										CAST(DATEADD(dd, -1, AUDIENCE_DATETIME) as date)
									ELSE CAST(AUDIENCE_DATETIME as date)
									END,
			AdjustedHour = CASE WHEN DATEDIFF(mi, CAST(AUDIENCE_DATETIME as date), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
								DATEPART(hh, AUDIENCE_DATETIME) * 100 + DATEPART(mi, AUDIENCE_DATETIME) + 2400
							ELSE DATEPART(hh, AUDIENCE_DATETIME) * 100 + DATEPART(mi, AUDIENCE_DATETIME)
							END,
			b.NIELSEN_TV_BOOK_ID,
			DP = DATEPART(dw, CASE WHEN DATEDIFF(mi, CAST(AUDIENCE_DATETIME as date), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
										CAST(DATEADD(dd, -1, AUDIENCE_DATETIME) as date)
									ELSE CAST(AUDIENCE_DATETIME as date)
									END),
			b.START_DATETIME,
			b.END_DATETIME 
		FROM dbo.NCC_TV_FUSION_AUDIENCE a
			INNER JOIN dbo.NCC_TV_FUSION_UE u ON a.NCC_TV_FUSION_UE_ID = u.NCC_TV_FUSION_UE_ID AND u.VALIDATED = 1 AND a.STATION_CODE IN (SELECT items FROM dbo.udf_split_list_int(@StationCodes, ','))
			INNER JOIN dbo.NIELSEN_TV_BOOK b ON u.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM AND u.[YEAR] = b.[YEAR] AND u.[MONTH] = b.[MONTH]
												AND ((b.STREAM = 'L7' AND u.STREAM = 'L7') OR (b.STREAM <> 'L7' AND u.STREAM = 'LS'))
												AND b.NIELSEN_TV_BOOK_ID IN (SELECT items FROM dbo.udf_split_list_int(@BookIDs, ','))
												AND b.REPORTING_SERVICE = '1' AND b.EXCLUSION = '' AND b.ETHNICITY = ''
			) a
					INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON d.ID > 0
				WHERE 
					a.AdjustedHour >= d.StartHour
					AND a.AdjustedHour < d.EndHour
					AND (
						d.ExactSpotDate IS NULL
					OR
						d.ExactSpotDate IS NOT NULL AND CAST(d.ExactSpotDate as date) = CAST(a.AdjustedDateTime as date) AND d.ExactSpotDate BETWEEN a.START_DATETIME AND a.END_DATETIME
					OR
						d.ExactSpotDate IS NOT NULL AND NOT (d.ExactSpotDate BETWEEN a.START_DATETIME AND a.END_DATETIME)
						)

	INSERT INTO @tt
	SELECT AVG([hh]),
		AVG([c2-5]),
		AVG([c6-11]),
		AVG([m12-14]),
		AVG([m18-20]),
		AVG([m21-24]),
		AVG([m25-34]),
		AVG([m35-49]),
		AVG([m50-54]),
		AVG([m55-64]),
		AVG([m65P]),
		AVG([f12-14]),
		AVG([f18-20]),
		AVG([f21-24]),
		AVG([f25-34]),
		AVG([f35-49]),
		AVG([f50-54]),
		AVG([f55-64]),
		AVG([f65P]),
		[station_code],
		[nielsen_tv_book_id],
		[media_spot_tv_research_daytime_id],
		[number_days]
	FROM (
		SELECT
			[hh] = CAST(ROUND(AVG(CAST(a.HOUSEHOLD_AUD as decimal(20))),0) as bigint),
			[c2-5] = CAST(ROUND(AVG(CAST(a.CHILDREN_2TO5_AUD as decimal(20))),0) as bigint),
			[c6-11] = CAST(ROUND(AVG(CAST(a.CHILDREN_6TO11_AUD as decimal(20))),0) as bigint),
			[m12-14] = CAST(ROUND(AVG(CAST(a.MALES_12TO17_AUD as decimal(20))),0) as bigint),
			[m18-20] = CAST(ROUND(AVG(CAST(a.MALES_18TO20_AUD as decimal(20))),0) as bigint),
			[m21-24] = CAST(ROUND(AVG(CAST(a.MALES_21TO24_AUD as decimal(20))),0) as bigint),
			[m25-34] = CAST(ROUND(AVG(CAST(a.MALES_25TO34_AUD as decimal(20))),0) as bigint),
			[m35-49] = CAST(ROUND(AVG(CAST(a.MALES_35TO49_AUD as decimal(20))),0) as bigint),
			[m50-54] = CAST(ROUND(AVG(CAST(a.MALES_50TO54_AUD as decimal(20))),0) as bigint),
			[m55-64] = CAST(ROUND(AVG(CAST(a.MALES_55TO64_AUD as decimal(20))),0) as bigint),
			[m65P] = CAST(ROUND(AVG(CAST(a.MALES_65PLUS_AUD as decimal(20))),0) as bigint),
			[f12-14] = CAST(ROUND(AVG(CAST(a.FEMALES_12TO17_AUD as decimal(20))),0) as bigint),
			[f18-20] = CAST(ROUND(AVG(CAST(a.FEMALES_18TO20_AUD as decimal(20))),0) as bigint),
			[f21-24] = CAST(ROUND(AVG(CAST(a.FEMALES_21TO24_AUD as decimal(20))),0) as bigint),
			[f25-34] = CAST(ROUND(AVG(CAST(a.FEMALES_25TO34_AUD as decimal(20))),0) as bigint),
			[f35-49] = CAST(ROUND(AVG(CAST(a.FEMALES_35TO49_AUD as decimal(20))),0) as bigint),
			[f50-54] = CAST(ROUND(AVG(CAST(a.FEMALES_50TO54_AUD as decimal(20))),0) as bigint),
			[f55-64] = CAST(ROUND(AVG(CAST(a.FEMALES_55TO64_AUD as decimal(20))),0) as bigint),
			[f65P] = CAST(ROUND(AVG(CAST(a.FEMALES_65PLUS_AUD as decimal(20))),0) as bigint),
			[station_code] = a.STATION_CODE,
			[nielsen_tv_book_id] = a.NIELSEN_TV_BOOK_ID,
			[media_spot_tv_research_daytime_id] = a.ID,
			[number_days] = a.NUMBER_DAYS,
			AdjustedHour,
			MINUTEPART 
		FROM @RESULTS a
		WHERE [MATCH] > 0
		GROUP BY a.NIELSEN_TV_BOOK_ID, a.STATION_CODE, a.ID, a.NUMBER_DAYS, AdjustedHour , MINUTEPART 
		HAVING SUM(a.HOUSEHOLD_AUD) IS NOT NULL
		) suma
	GROUP BY [station_code], [nielsen_tv_book_id], [media_spot_tv_research_daytime_id], [number_days]

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.audience, u.station_code, u.nielsen_tv_book_id, u.media_spot_tv_research_daytime_id, u.number_days
	FROM @tt
	UNPIVOT
	(
		audience
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64], [f65P])
	) u

	RETURN
END
GO

GRANT SELECT ON [advtf_ncc_tv_fusion_audience_postbuy] TO PUBLIC
GO
