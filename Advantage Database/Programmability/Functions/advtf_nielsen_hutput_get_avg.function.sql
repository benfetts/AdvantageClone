CREATE FUNCTION [dbo].[advtf_nielsen_hutput_get_avg](
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@STREAM char(2),
	@SAMPLE_TYPE char(1),
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
	[avg_hutput] decimal(21,2) NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
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
		[ww] decimal(21,2) NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[hh] = AVG(a.HOUSEHOLD_HUT),
		[c2-5] = AVG(a.CHILDREN_2TO5_PUT),
		[c6-11] = AVG(a.CHILDREN_6TO11_PUT),
		[m12-14] = AVG(a.MALES_12TO14_PUT),
		[m15-17] = AVG(a.MALES_15TO17_PUT),
		[m18-20] = AVG(a.MALES_18TO20_PUT),
		[m21-24] = AVG(a.MALES_21TO24_PUT),
		[m25-34] = AVG(a.MALES_25TO34_PUT),
		[m35-49] = AVG(a.MALES_35TO49_PUT),
		[m50-54] = AVG(a.MALES_50TO54_PUT ),
		[m55-64] = AVG(a.MALES_55TO64_PUT),
		[m65P] = AVG(a.MALES_65PLUS_PUT),
		[f12-14] = AVG(a.FEMALES_12TO14_PUT),
		[f15-17] = AVG(a.FEMALES_15TO17_PUT),
		[f18-20] = AVG(a.FEMALES_18TO20_PUT),
		[f21-24] = AVG(a.FEMALES_21TO24_PUT),
		[f25-34] = AVG(a.FEMALES_25TO34_PUT),
		[f35-49] = AVG(a.FEMALES_35TO49_PUT),
		[f50-54] = AVG(a.FEMALES_50TO54_PUT),
		[f55-64] = AVG(a.FEMALES_55TO64_PUT),
		[f65P] = AVG(a.FEMALES_65PLUS_PUT),
		[ww] = AVG(a.WORKING_WOMEN_PUT)
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
			AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), HUTPUT_DATETIME, 101), HUTPUT_DATETIME) < @ADJUST_MINUTES THEN 
									CONVERT(char(10), DATEADD(dd, -1, HUTPUT_DATETIME), 101)
							   ELSE CONVERT(char(10), HUTPUT_DATETIME, 101)
							   END,
			AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), HUTPUT_DATETIME, 101), HUTPUT_DATETIME) < @ADJUST_MINUTES THEN 
								CAST(LEFT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint) + 2400
						   ELSE CAST(LEFT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), HUTPUT_DATETIME, 108),2) as smallint)
						   END 
		FROM dbo.NIELSEN_TV_HUTPUT a
		WHERE a.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
		AND a.STREAM = @STREAM
		AND a.SAMPLE_TYPE = @SAMPLE_TYPE
		AND a.NIELSEN_SERVICE = @NIELSEN_SERVICE
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
	HAVING AVG(a.HOUSEHOLD_HUT) IS NOT NULL

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.avg_hutput
	FROM @tt
	UNPIVOT
	(
		avg_hutput
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END