CREATE FUNCTION [dbo].[advtf_npr_worksheet_audience](
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_DAYTIME_TYPE READONLY,
	@NPR_STATION_ID int,
    @START_DATE smalldatetime,
    @END_DATE smalldatetime
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(7) NOT NULL,
	[audience] int NOT NULL,
	[npr_station_id] int NOT NULL,
	[media_spot_tv_research_daytime_id] int NOT NULL,
	[number_days] smallint NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @ADJUST_MINUTES smallint
	SET @ADJUST_MINUTES = 120

	DECLARE @tt TABLE (
		[homes] int NOT NULL,
		[pp2P] int NOT NULL,
		[pm2P] int NOT NULL,
		[pm2-5] int NOT NULL,
		[pm6-11] int NOT NULL,
		[pm12-14] int NOT NULL,
		[pm15-17] int NOT NULL,
		[pm18-20] int NOT NULL,
		[pm21-24] int NOT NULL,
		[pm25-34] int NOT NULL,
		[pm35-44] int NOT NULL,
		[pm45-49] int NOT NULL,
		[pm50-54] int NOT NULL,
		[pm55-64] int NOT NULL,
		[pm65P] int NOT NULL,
		[pf2P] int NOT NULL,
		[pf2-5] int NOT NULL,
		[pf6-11] int NOT NULL,
		[pf12-14] int NOT NULL,
		[pf15-17] int NOT NULL,
		[pf18-20] int NOT NULL,
		[pf21-24] int NOT NULL,
		[pf25-34] int NOT NULL,
		[pf35-44] int NOT NULL,
		[pf45-49] int NOT NULL,
		[pf50-54] int NOT NULL,
		[pf55-64] int NOT NULL,
		[pf65P] int NOT NULL,
		[pww] int NOT NULL,
		[npr_station_id] int NOT NULL,
		[media_spot_tv_research_daytime_id] int NOT NULL,
		[number_days] smallint NOT NULL
	)

	INSERT INTO @tt
	SELECT CAST (ROUND( CAST( SUM([homes] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pp2P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm2P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm2-5] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
        CAST (ROUND( CAST( SUM([pm6-11] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
        CAST (ROUND( CAST( SUM([pm12-14] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm15-17] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm18-20] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm21-24] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm25-34] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm35-44] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
        CAST (ROUND( CAST( SUM([pm45-49] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm50-54] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm55-64] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pm65P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),		
        CAST (ROUND( CAST( SUM([pf2P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf2-5] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
        CAST (ROUND( CAST( SUM([pf6-11] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
        CAST (ROUND( CAST( SUM([pf12-14] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf15-17] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf18-20] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf21-24] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf25-34] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf35-44] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
        CAST (ROUND( CAST( SUM([pf45-49] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf50-54] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf55-64] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pf65P] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		CAST (ROUND( CAST( SUM([pww] * MINUTEPART) as decimal(20)) / CAST( SUM(MINUTEPART) as decimal(20)), 0) as int),
		[npr_station_id],
		[media_spot_tv_research_daytime_id],
		[number_days]
	FROM (
		SELECT
            [homes] = CAST(ROUND(AVG(CAST(HOMES_AUD as decimal(20))),0) as int),
		    [pp2P] = CAST(ROUND(AVG(CAST(PEOPLE_2PLUS_AUD as decimal(20))),0) as int),
		    [pm2P] = CAST(ROUND(AVG(CAST(MALES_2PLUS_AUD as decimal(20))),0) as int),
		    [pm2-5] = CAST(ROUND(AVG(CAST(MALES_2TO5_AUD as decimal(20))),0) as int),
		    [pm6-11] = CAST(ROUND(AVG(CAST(MALES_6TO11_AUD as decimal(20))),0) as int),
		    [pm12-14] = CAST(ROUND(AVG(CAST(MALES_12TO14_AUD as decimal(20))),0) as int),
		    [pm15-17] = CAST(ROUND(AVG(CAST(MALES_15TO17_AUD as decimal(20))),0) as int),
		    [pm18-20] = CAST(ROUND(AVG(CAST(MALES_18TO20_AUD as decimal(20))),0) as int),
		    [pm21-24] = CAST(ROUND(AVG(CAST(MALES_21TO24_AUD as decimal(20))),0) as int),
		    [pm25-34] = CAST(ROUND(AVG(CAST(MALES_25TO34_AUD as decimal(20))),0) as int),
		    [pm35-44] = CAST(ROUND(AVG(CAST(MALES_35TO44_AUD as decimal(20))),0) as int),
		    [pm45-49] = CAST(ROUND(AVG(CAST(MALES_45TO49_AUD as decimal(20))),0) as int),
		    [pm50-54] = CAST(ROUND(AVG(CAST(MALES_50TO54_AUD as decimal(20))),0) as int),
		    [pm55-64] = CAST(ROUND(AVG(CAST(MALES_55TO64_AUD as decimal(20))),0) as int),
		    [pm65P] = CAST(ROUND(AVG(CAST(MALES_65PLUS_AUD as decimal(20))),0) as int),            
		    [pf2P] = CAST(ROUND(AVG(CAST(FEMALES_2PLUS_AUD as decimal(20))),0) as int),
		    [pf2-5] = CAST(ROUND(AVG(CAST(FEMALES_2TO5_AUD as decimal(20))),0) as int),
		    [pf6-11] = CAST(ROUND(AVG(CAST(FEMALES_6TO11_AUD as decimal(20))),0) as int),
		    [pf12-14] = CAST(ROUND(AVG(CAST(FEMALES_12TO14_AUD as decimal(20))),0) as int),
		    [pf15-17] = CAST(ROUND(AVG(CAST(FEMALES_15TO17_AUD as decimal(20))),0) as int),
		    [pf18-20] = CAST(ROUND(AVG(CAST(FEMALES_18TO20_AUD as decimal(20))),0) as int),
		    [pf21-24] = CAST(ROUND(AVG(CAST(FEMALES_21TO24_AUD as decimal(20))),0) as int),
		    [pf25-34] = CAST(ROUND(AVG(CAST(FEMALES_25TO34_AUD as decimal(20))),0) as int),
		    [pf35-44] = CAST(ROUND(AVG(CAST(FEMALES_35TO44_AUD as decimal(20))),0) as int),
		    [pf45-49] = CAST(ROUND(AVG(CAST(FEMALES_45TO49_AUD as decimal(20))),0) as int),
		    [pf50-54] = CAST(ROUND(AVG(CAST(FEMALES_50TO54_AUD as decimal(20))),0) as int),
		    [pf55-64] = CAST(ROUND(AVG(CAST(FEMALES_55TO64_AUD as decimal(20))),0) as int),
		    [pf65P] = CAST(ROUND(AVG(CAST(FEMALES_65PLUS_AUD as decimal(20))),0) as int),
		    [pww] = CAST(ROUND(AVG(CAST(WORKING_WOMEN_AUD as decimal(20))),0) as int),		
			[npr_station_id] = NPR_STATION_ID,
			[media_spot_tv_research_daytime_id] = ID,
			[number_days] = NUMBER_DAYS,
			AdjustedHour,
			MINUTEPART 
		FROM (
			SELECT
				HOMES_AUD = CAST(HOMES_AUD as int),
				PEOPLE_2PLUS_AUD = CAST(PEOPLE_2PLUS_AUD as int),				
                MALES_2PLUS_AUD = CAST(MALES_2PLUS_AUD as int),
                MALES_2TO5_AUD = CAST(MALES_2TO5_AUD as int),
                MALES_6TO11_AUD = CAST(MALES_6TO11_AUD as int),
				MALES_12TO14_AUD = CAST(MALES_12TO14_AUD as int),
				MALES_15TO17_AUD = CAST(MALES_15TO17_AUD as int),
				MALES_18TO20_AUD = CAST(MALES_18TO20_AUD as int),
				MALES_21TO24_AUD = CAST(MALES_21TO24_AUD as int),
				MALES_25TO34_AUD = CAST(MALES_25TO34_AUD as int),
				MALES_35TO44_AUD = CAST(MALES_35TO44_AUD as int),
                MALES_45TO49_AUD = CAST(MALES_45TO49_AUD as int),
				MALES_50TO54_AUD = CAST(MALES_50TO54_AUD as int),
				MALES_55TO64_AUD = CAST(MALES_55TO64_AUD as int),
				MALES_65PLUS_AUD = CAST(MALES_65PLUS_AUD as int),
                FEMALES_2PLUS_AUD = CAST(FEMALES_2PLUS_AUD as int),
                FEMALES_2TO5_AUD = CAST(FEMALES_2TO5_AUD as int),
                FEMALES_6TO11_AUD = CAST(FEMALES_6TO11_AUD as int),
				FEMALES_12TO14_AUD = CAST(FEMALES_12TO14_AUD as int),
				FEMALES_15TO17_AUD = CAST(FEMALES_15TO17_AUD as int),
				FEMALES_18TO20_AUD = CAST(FEMALES_18TO20_AUD as int),
				FEMALES_21TO24_AUD = CAST(FEMALES_21TO24_AUD as int),
				FEMALES_25TO34_AUD = CAST(FEMALES_25TO34_AUD as int),
				FEMALES_35TO44_AUD = CAST(FEMALES_35TO44_AUD as int),
                FEMALES_45TO49_AUD = CAST(FEMALES_45TO49_AUD as int),
				FEMALES_50TO54_AUD = CAST(FEMALES_50TO54_AUD as int),
				FEMALES_55TO64_AUD = CAST(FEMALES_55TO64_AUD as int),
				FEMALES_65PLUS_AUD = CAST(FEMALES_65PLUS_AUD as int),
				WORKING_WOMEN_AUD = CAST(WORKING_WOMEN_AUD as int),
				a.NPR_STATION_ID,
				d.ID,
				NUMBER_DAYS = CAST(d.Sunday as smallint) + CAST(d.Monday as smallint) + CAST(d.Tuesday as smallint) + CAST(d.Wednesday as smallint) + CAST(d.Thursday as smallint) + CAST(d.Friday as smallint) + CAST(d.Saturday as smallint),
				MINUTEPART = CASE
								WHEN datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),AdjustedDateTime) between -15 and -1 THEN
										15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),AdjustedDateTime) 
								WHEN datediff(mi,AdjustedDateTime,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.EndTime as smalldatetime)) between 1 and 14 THEN
										datediff(mi,AdjustedDateTime,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.EndTime as smalldatetime))
								ELSE 15 END,
				a.AdjustedDateTime,
				a.AdjustedHour
			FROM (
					SELECT
						HOMES_AUD,
                        PEOPLE_2PLUS_AUD,
                        MALES_2PLUS_AUD,
                        MALES_2TO5_AUD,
                        MALES_6TO11_AUD,
						MALES_12TO14_AUD,
						MALES_15TO17_AUD,
						MALES_18TO20_AUD,
						MALES_21TO24_AUD,
						MALES_25TO34_AUD,
						MALES_35TO44_AUD,
                        MALES_45TO49_AUD,
						MALES_50TO54_AUD,
						MALES_55TO64_AUD,
						MALES_65PLUS_AUD,
						FEMALES_2PLUS_AUD,
                        FEMALES_2TO5_AUD,
                        FEMALES_6TO11_AUD,
						FEMALES_12TO14_AUD,
						FEMALES_15TO17_AUD,
						FEMALES_18TO20_AUD,
						FEMALES_21TO24_AUD,
						FEMALES_25TO34_AUD,
						FEMALES_35TO44_AUD,
                        FEMALES_45TO49_AUD,
						FEMALES_50TO54_AUD,
						FEMALES_55TO64_AUD,
						FEMALES_65PLUS_AUD,
						WORKING_WOMEN_AUD,
						NPR_STATION_ID,
						AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), [DATE], 101), [DATE]) < @ADJUST_MINUTES THEN 
										CONVERT(char(10), DATEADD(dd, -1, [DATE]), 101)
								   ELSE CONVERT(char(10), [DATE], 101)
								   END,
						AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), [DATE], 101), [DATE]) < @ADJUST_MINUTES THEN 
											CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint) + 2400
									   ELSE CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint)
									   END
					FROM dbo.NPR_AUDIENCE
					WHERE NPR_STATION_ID = @NPR_STATION_ID
                    AND [DATE] BETWEEN DATEADD(d,-1,@START_DATE) AND DATEADD(d,2,@END_DATE)
				 ) a
					INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON d.ID > 0
				WHERE 
					a.AdjustedHour >= d.StartHour  
					AND a.AdjustedHour < CASE WHEN d.EndHour = d.StartHour THEN d.EndHour + 15 ELSE d.EndHour END
                    AND a.AdjustedDateTime BETWEEN @START_DATE AND @END_DATE
					AND (
						(d.Sunday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
					OR	(d.Monday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
					OR	(d.Tuesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
					OR	(d.Wednesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
					OR	(d.Thursday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
					OR	(d.Friday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
					OR	(d.Saturday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
						)
			) aud
		
		GROUP BY aud.NPR_STATION_ID, aud.ID, aud.NUMBER_DAYS, AdjustedHour, MINUTEPART 

		) suma
	GROUP BY [npr_station_id], [media_spot_tv_research_daytime_id], [number_days]

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.audience, u.npr_station_id, u.media_spot_tv_research_daytime_id, u.number_days
	FROM @tt
	UNPIVOT
	(
		audience
		for nielsen_demo_code in ([homes],[pp2P],[pm2P],[pm2-5],[pm6-11],[pm12-14],[pm15-17],[pm18-20],[pm21-24],[pm25-34],[pm35-44],[pm45-49],[pm50-54],[pm55-64],[pm65P],
            [pf2P],[pf2-5],[pf6-11],[pf12-14],[pf15-17],[pf18-20],[pf21-24],[pf25-34],[pf35-44],[pf45-49],[pf50-54],[pf55-64],[pf65P],[pww])
	) u

	RETURN
END
GO


