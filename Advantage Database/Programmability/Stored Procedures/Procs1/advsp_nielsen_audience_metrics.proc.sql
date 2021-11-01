CREATE PROCEDURE [dbo].[advsp_nielsen_audience_metrics]
	@MARKET_CODE varchar(10),
	@STATION_CODE int,
	@STREAM char(2),
	@NIELSEN_SERVICE char(1),
	@SAMPLE_TYPE char(1),
	@BOOK_MONTH smallint,
	@BOOK_YEAR smallint,
	@START_DATE smalldatetime,
	@END_DATE smalldatetime,
	@START_TIME smallint,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@ADJUST_MINUTES smallint,
	@SelectedMediaDemographicIDs varchar(max)
AS
BEGIN
/*
SET @MARKET_CODE = 'SND'
SET @STATION_CODE = 5771
SET @STREAM = 'L3'
SET	@NIELSEN_SERVICE = '1'
SET	@SAMPLE_TYPE = '1'
SET @BOOK_MONTH = 2
SET @BOOK_YEAR 2012
SET	@START_DATE = '2/2/2012'
SET	@END_DATE = '2/29/2012'
SET @START_TIME = 600
SET @END_TIME = 615
SET @SUN = 0
SET @MON = 0
SET @TUE = 0
SET @WED = 0
SET @THU = 1
SET @FRI = 0
SET @SAT = 0
SET @SelectedMediaDemographicIDs = '89'
*/

	DECLARE	@NIELSEN_MARKET_NUM int, @IS_METERED_MARKET bit, @NUMBER_DAYS smallint, @AUD_QHRS_COUNT int, @DAYSRANGE int

	SELECT @DAYSRANGE = DATEDIFF(d,@START_DATE, @END_DATE)
	
	SELECT @NIELSEN_MARKET_NUM = CAST(NIELSEN_TV_CODE as int)
	FROM dbo.MARKET
	WHERE MARKET_CODE = @MARKET_CODE

	SELECT @IS_METERED_MARKET = IS_METERED_MARKET 
	FROM dbo.NIELSEN_TV_UNIVERSE u
	WHERE u.NIELSEN_SERVICE = @NIELSEN_SERVICE 
	AND u.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
	AND u.[YEAR] = @BOOK_YEAR
	AND u.[MONTH] = @BOOK_MONTH
	AND u.SAMPLE_TYPE = @SAMPLE_TYPE 

	SET @NUMBER_DAYS = CAST(@SUN as smallint) + CAST(@MON as smallint) + CAST(@TUE as smallint) + CAST(@WED as smallint) + CAST(@THU as smallint) + CAST(@FRI as smallint) + CAST(@SAT as smallint) 

	DECLARE @AUD_METRICS TABLE (
		MEDIA_DEMO_ID	int NOT NULL,
		UE				bigint NOT NULL,
		AUDIENCE		bigint NOT NULL,
		HUT				decimal(21,2) NOT NULL,
		HUT_PCT			decimal(21,2) NOT NULL,
		INTAB			decimal(21,2) NOT NULL,
		IMPRESSIONS		bigint NOT NULL
	)

	DECLARE @AUDIENCE TABLE (
		[media_demo_id]	int NOT NULL,
		[audience]		bigint NOT NULL
	)

	DECLARE @HUTPUT_AVG TABLE (
		[media_demo_id]	int NOT NULL,
		[avg_hutput]	decimal(21,2) NOT NULL
	)

	DECLARE @INTAB_AVG TABLE (
		[media_demo_id]	int NOT NULL,
		[avg_intab]		decimal(21,2) NOT NULL
	)

	SELECT @AUD_QHRS_COUNT = COUNT(1)
	FROM (
		SELECT
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

	INSERT @AUD_METRICS (MEDIA_DEMO_ID, UE, AUDIENCE, HUT, HUT_PCT, INTAB, IMPRESSIONS)
	SELECT md.MEDIA_DEMO_ID, SUM(universe.ue), 0, 0, 0, 0, 0 
	FROM 
		dbo.MEDIA_DEMO md
		INNER JOIN dbo.MEDIA_DEMO_DETAIL mdd ON md.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT *
					FROM dbo.advtf_nielsen_universe_get(@NIELSEN_SERVICE, @NIELSEN_MARKET_NUM, @SAMPLE_TYPE, @BOOK_MONTH, @BOOK_YEAR)
					) universe ON nd.CODE = universe.nielsen_demo_code
	WHERE mdd.MEDIA_DEMO_ID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.MEDIA_DEMO_ID

--select * from @AUD_METRICS

	INSERT INTO @AUDIENCE
	SELECT md.MEDIA_DEMO_ID, SUM(aud.audience) 
	FROM 
		dbo.MEDIA_DEMO md
		INNER JOIN dbo.MEDIA_DEMO_DETAIL mdd ON md.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_audience_get(@NIELSEN_SERVICE, @NIELSEN_MARKET_NUM, @STREAM, @SAMPLE_TYPE, @STATION_CODE, @START_DATE, @END_DATE, @START_TIME,
											@END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES)
					) aud ON nd.CODE = aud.nielsen_demo_code 
	WHERE mdd.MEDIA_DEMO_ID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.MEDIA_DEMO_ID
	
--select * from @AUDIENCE

	UPDATE am SET am.AUDIENCE = h.audience 
	FROM @AUD_METRICS am
		INNER JOIN @AUDIENCE h ON am.MEDIA_DEMO_ID = h.media_demo_id 

	INSERT INTO @HUTPUT_AVG 
	SELECT md.MEDIA_DEMO_ID, SUM(hutput.avg_hutput) 
	FROM 
		dbo.MEDIA_DEMO md
		INNER JOIN dbo.MEDIA_DEMO_DETAIL mdd ON md.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_hutput_get_avg(@NIELSEN_SERVICE, @NIELSEN_MARKET_NUM, @STREAM, @SAMPLE_TYPE, @START_DATE, @END_DATE, @START_TIME,
											@END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES)
					) hutput ON nd.CODE = hutput.nielsen_demo_code 
	WHERE mdd.MEDIA_DEMO_ID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.MEDIA_DEMO_ID

--SELECT * FROM @HUTPUT_AVG 

	UPDATE am SET am.HUT = h.avg_hutput 
	FROM @AUD_METRICS am
		INNER JOIN @HUTPUT_AVG h ON am.MEDIA_DEMO_ID = h.media_demo_id 

	UPDATE @AUD_METRICS SET HUT_PCT = CAST(HUT as decimal) / CAST(UE as decimal) * 100
	WHERE UE <> 0 

	INSERT INTO @INTAB_AVG
	SELECT md.MEDIA_DEMO_ID, SUM(intab.avg_intab) 
	FROM 
		dbo.MEDIA_DEMO md
		INNER JOIN dbo.MEDIA_DEMO_DETAIL mdd ON md.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_intab_get_avg(@NIELSEN_SERVICE, @NIELSEN_MARKET_NUM, @STREAM, @SAMPLE_TYPE, @START_DATE,
											@END_DATE, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES)
					) intab ON nd.CODE = intab.nielsen_demo_code 
	WHERE mdd.MEDIA_DEMO_ID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.MEDIA_DEMO_ID

--SELECT * FROM @INTAB_AVG 

	--select @AUD_QHRS_COUNT 
 
	UPDATE am SET
		am.INTAB = h.avg_intab,
		am.IMPRESSIONS = 
			CASE 
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND (@DAYSRANGE <= 7 AND avg_intab < 90) THEN 0
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND (@DAYSRANGE <= 7 AND avg_intab >= 90) AND @AUD_QHRS_COUNT = 0 THEN 0
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND (@DAYSRANGE <= 7 AND avg_intab >= 90) THEN CONVERT(int,ROUND(CAST( am.AUDIENCE as decimal) / CAST( @AUD_QHRS_COUNT as decimal),0,0),0)
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND (@DAYSRANGE > 7 AND @DAYSRANGE <= 14) AND (avg_intab < 55) THEN 0
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND (@DAYSRANGE > 7 AND @DAYSRANGE <= 14) AND (avg_intab >= 55) AND @AUD_QHRS_COUNT = 0 THEN 0
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND (@DAYSRANGE > 7 AND @DAYSRANGE <= 14) AND (avg_intab >= 55) THEN CONVERT(int,ROUND(CAST( am.AUDIENCE as decimal) / CAST( @AUD_QHRS_COUNT as decimal),0,0),0)
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND avg_intab < 50 THEN 0
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND avg_intab >= 50 AND @AUD_QHRS_COUNT = 0 THEN 0
				WHEN @IS_METERED_MARKET = 1 AND @NUMBER_DAYS = 1 AND avg_intab >= 50 THEN CONVERT(int,ROUND(CAST( am.AUDIENCE as decimal) / CAST( @AUD_QHRS_COUNT as decimal),0,0),0)
				WHEN @IS_METERED_MARKET = 1 AND avg_intab < 50 THEN 0
				WHEN @IS_METERED_MARKET = 1 AND avg_intab >= 50 AND @AUD_QHRS_COUNT = 0 THEN 0
				WHEN @IS_METERED_MARKET = 1 AND avg_intab >= 50 THEN CONVERT(int,ROUND(CAST( am.AUDIENCE as decimal) / CAST( @AUD_QHRS_COUNT as decimal),0,0),0)

				WHEN @IS_METERED_MARKET = 0 AND @NUMBER_DAYS = 1 AND h.avg_intab < 90 THEN 0
				WHEN @IS_METERED_MARKET = 0 AND @NUMBER_DAYS = 1 AND h.avg_intab >= 90 AND @AUD_QHRS_COUNT = 0 THEN 0
				WHEN @IS_METERED_MARKET = 0 AND @NUMBER_DAYS = 1 AND h.avg_intab >= 90 THEN CONVERT(int,ROUND(CAST( am.AUDIENCE as decimal) / CAST( @AUD_QHRS_COUNT as decimal),0,0),0)
				WHEN @IS_METERED_MARKET = 0 AND avg_intab < 50 THEN 0 
				WHEN @IS_METERED_MARKET = 0 AND avg_intab >= 50 AND @AUD_QHRS_COUNT = 0 THEN 0
				WHEN @IS_METERED_MARKET = 0 AND avg_intab >= 50 THEN CONVERT(int,ROUND(CAST( am.AUDIENCE as decimal) / CAST( @AUD_QHRS_COUNT as decimal),0,0),0)
			END
	FROM @AUD_METRICS am
		INNER JOIN @INTAB_AVG h ON am.MEDIA_DEMO_ID = h.media_demo_id 
		
	SELECT
		MediaDemoDescription = md.[DESCRIPTION],
		UniverseEstimate = UE,
		Impressions = IMPRESSIONS,
		Rating = CASE WHEN UE = 0 THEN CAST(0 as decimal) ELSE CAST(IMPRESSIONS as decimal) / CAST(UE as decimal) * 100 END,
		Share =  CASE WHEN HUT = 0 THEN CAST(0 as decimal) ELSE CAST(IMPRESSIONS as decimal) / CAST(HUT as decimal) * 100 END,
		HUT = HUT,
		HUT_PCT = HUT_PCT,
		Intab = INTAB,
		Program = dbo.advfn_nielsen_program_get(@NIELSEN_SERVICE, @NIELSEN_MARKET_NUM, @STATION_CODE, @START_DATE, @END_DATE, @START_TIME, @END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES, 0),
		Audience = AUDIENCE
	FROM @AUD_METRICS am
		INNER JOIN dbo.MEDIA_DEMO md ON am.MEDIA_DEMO_ID = md.MEDIA_DEMO_ID 
END
GO