CREATE PROCEDURE [dbo].[advsp_nielsen_audience_metrics]
	@NIELSEN_MARKET_NUM int,
	@STATION_CODE int,
	@STREAM char(2),
	@BOOK_MONTH smallint,
	@BOOK_YEAR smallint,
	@START_DATE smalldatetime,
	@END_DATE smalldatetime,
	@START_TIME smallint,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@ADJUST_MINUTES smallint,
	@SelectedMediaDemographicIDs varchar(max),
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY,
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY
AS
BEGIN
/*
SET @NIELSEN_MARKET_NUM = 101
SET @STATION_CODE = 5771
SET @STREAM = 'L3'
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

	DECLARE	@IS_METERED_MARKET bit, @NUMBER_DAYS smallint, @AUD_QHRS_COUNT int, @DAYSRANGE int, @NIELSEN_TV_BOOK_ID int

	SELECT @NIELSEN_TV_BOOK_ID = NIELSEN_TV_BOOK_ID 
	FROM dbo.NIELSEN_TV_BOOK
	WHERE NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
	AND [YEAR] = @BOOK_YEAR
	AND [MONTH] = @BOOK_MONTH
	AND STREAM = @STREAM

	SELECT @DAYSRANGE = DATEDIFF(d,@START_DATE, @END_DATE)
	
	SELECT @IS_METERED_MARKET = IS_METERED_MARKET 
	FROM dbo.NIELSEN_TV_UNIVERSE u
	WHERE u.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
	AND u.[YEAR] = @BOOK_YEAR
	AND u.[MONTH] = @BOOK_MONTH

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
		WHERE a.NIELSEN_TV_BOOK_ID = @NIELSEN_TV_BOOK_ID
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
	SELECT md.ID, SUM(universe.ue), 0, 0, 0, 0, 0 
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID  
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT *
					FROM dbo.advtf_nielsen_universe_get(@NIELSEN_MARKET_NUM, @BOOK_MONTH, @BOOK_YEAR)
					) universe ON nd.CODE = universe.nielsen_demo_code
	WHERE mdd.MediaDemographicID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.ID

--select * from @AUD_METRICS

	INSERT INTO @AUDIENCE
	SELECT md.ID, SUM(aud.audience) 
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_audience_get(@NIELSEN_TV_BOOK_ID, @STATION_CODE, @START_DATE, @END_DATE, @START_TIME,
											@END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES)
					) aud ON nd.CODE = aud.nielsen_demo_code 
	WHERE mdd.MediaDemographicID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.ID
	
--select * from @AUDIENCE

	UPDATE am SET am.AUDIENCE = h.audience 
	FROM @AUD_METRICS am
		INNER JOIN @AUDIENCE h ON am.MEDIA_DEMO_ID = h.media_demo_id 

	INSERT INTO @HUTPUT_AVG 
	SELECT md.ID, SUM(hutput.avg_hutput) 
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_hutput_get_avg(@NIELSEN_TV_BOOK_ID, @START_DATE, @END_DATE, @START_TIME,
											@END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES)
					) hutput ON nd.CODE = hutput.nielsen_demo_code 
	WHERE mdd.MediaDemographicID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.ID

--SELECT * FROM @HUTPUT_AVG 

	UPDATE am SET am.HUT = h.avg_hutput 
	FROM @AUD_METRICS am
		INNER JOIN @HUTPUT_AVG h ON am.MEDIA_DEMO_ID = h.media_demo_id 

	UPDATE @AUD_METRICS SET HUT_PCT = CAST(HUT as decimal) / CAST(UE as decimal) * 100
	WHERE UE <> 0 

	INSERT INTO @INTAB_AVG
	SELECT md.ID, SUM(intab.avg_intab) 
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_intab_get_avg(@NIELSEN_TV_BOOK_ID, @START_DATE,
											@END_DATE, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES)
					) intab ON nd.CODE = intab.nielsen_demo_code 
	WHERE mdd.MediaDemographicID IN (SELECT * FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	GROUP BY md.ID

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
		MediaDemoDescription = md.[Description],
		UniverseEstimate = UE,
		Impressions = IMPRESSIONS,
		Rating = CASE WHEN UE = 0 THEN CAST(0 as decimal) ELSE CAST(IMPRESSIONS as decimal) / CAST(UE as decimal) * 100 END,
		Share =  CASE WHEN HUT = 0 THEN CAST(0 as decimal) ELSE CAST(IMPRESSIONS as decimal) / CAST(HUT as decimal) * 100 END,
		HUT = HUT,
		HUT_PCT = HUT_PCT,
		Intab = INTAB,
		Program = dbo.advfn_nielsen_program_get(@NIELSEN_MARKET_NUM, @STATION_CODE, @START_DATE, @END_DATE, @START_TIME, @END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES, 0),
		Audience = AUDIENCE
	FROM @AUD_METRICS am
		INNER JOIN @MEDIA_DEMO_TYPE md ON am.MEDIA_DEMO_ID = md.ID 
END
GO

GRANT EXEC ON [advsp_nielsen_audience_metrics] TO PUBLIC
GO