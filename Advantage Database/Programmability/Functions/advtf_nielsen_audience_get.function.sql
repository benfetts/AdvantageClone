CREATE FUNCTION [dbo].[advtf_nielsen_audience_get](
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@STREAM char(2),
	@SAMPLE_TYPE char(1),
	@STATION_CODE int,
	@START_DATE smalldatetime,
	@END_DATE smalldatetime,
	@START_TIME smallint,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@ADJUST_MINUTES smallint
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[audience] bigint NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
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
		[ww] bigint NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[hh] = SUM(a.HOUSEHOLD_AUD),
		[c2-5] = SUM(a.CHILDREN_2TO5_AUD),
		[c6-11] = SUM(a.CHILDREN_6TO11_AUD),
		[m12-14] = SUM(a.MALES_12TO14_AUD),
		[m15-17] = SUM(a.MALES_15TO17_AUD),
		[m18-20] = SUM(a.MALES_18TO20_AUD),
		[m21-24] = SUM(a.MALES_21TO24_AUD),
		[m25-34] = SUM(a.MALES_25TO34_AUD),
		[m35-49] = SUM(a.MALES_35TO49_AUD),
		[m50-54] = SUM(a.MALES_50TO54_AUD),
		[m55-64] = SUM(a.MALES_55TO64_AUD),
		[m65P] = SUM(a.MALES_65PLUS_AUD),
		[f12-14] = SUM(a.FEMALES_12TO14_AUD),
		[f15-17] = SUM(a.FEMALES_15TO17_AUD),
		[f18-20] = SUM(a.FEMALES_18TO20_AUD),
		[f21-24] = SUM(a.FEMALES_21TO24_AUD),
		[f25-34] = SUM(a.FEMALES_25TO34_AUD),
		[f35-49] = SUM(a.FEMALES_35TO49_AUD),
		[f50-54] = SUM(a.FEMALES_50TO54_AUD),
		[f55-64] = SUM(a.FEMALES_55TO64_AUD),
		[f65P] = SUM(a.FEMALES_65PLUS_AUD),
		[ww] = SUM(a.WORKING_WOMEN_AUD)
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
			AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
									CONVERT(char(10), DATEADD(dd, -1, AUDIENCE_DATETIME), 101)
							   ELSE CONVERT(char(10), AUDIENCE_DATETIME, 101)
							   END,
			AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < @ADJUST_MINUTES THEN 
								CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) + 2400
						   ELSE CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint)
						   END 
		FROM dbo.NIELSEN_TV_AUDIENCE a
		WHERE a.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
		AND a.STREAM = @STREAM
		AND a.SAMPLE_TYPE = @SAMPLE_TYPE
		AND a.NIELSEN_SERVICE = @NIELSEN_SERVICE
		AND a.STATION_CODE = @STATION_CODE
		) a
		WHERE 
			a.AdjustedDateTime between CONVERT(char(10), @START_DATE, 101) AND CONVERT(char(10), @END_DATE, 101)
		AND	a.AdjustedHour >= @START_TIME 
		AND a.AdjustedHour < @END_TIME
		AND (
			(@SUN = 1 AND DATEPART(dw, AdjustedDateTime) = 1)
		OR	(@MON = 1 AND DATEPART(dw, AdjustedDateTime) = 2)
		OR	(@TUE = 1 AND DATEPART(dw, AdjustedDateTime) = 3)
		OR	(@WED = 1 AND DATEPART(dw, AdjustedDateTime) = 4)
		OR	(@THU = 1 AND DATEPART(dw, AdjustedDateTime) = 5)
		OR	(@FRI = 1 AND DATEPART(dw, AdjustedDateTime) = 6)
		OR	(@SAT = 1 AND DATEPART(dw, AdjustedDateTime) = 7)
			)
	HAVING SUM(a.HOUSEHOLD_AUD) IS NOT NULL

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.audience
	FROM @tt
	UNPIVOT
	(
		audience
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END