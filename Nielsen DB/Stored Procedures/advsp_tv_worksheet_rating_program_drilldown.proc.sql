CREATE PROCEDURE [dbo].[advsp_tv_worksheet_rating_program_drilldown]
	@NIELSEN_MARKET_NUM int,
	@SHARE_BOOK_ID int,
	@HPUT_BOOK_ID int,
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY, --primary and secondary MEDIA_DEMO_IDS
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY,
	@STATION_CODE int, --single station code
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@HOSTED_CLIENT_CODE varchar(6)
AS

DECLARE	@ADJUST_MINUTES smallint,
		@hutbookid int,
		@HPUTBookIDs varchar(max),
		@StationCodes varchar(max)

SET @ADJUST_MINUTES = 180 --start of day is 3am

IF @HPUT_BOOK_ID IS NULL BEGIN

	SET @HPUTBookIDs = @SHARE_BOOK_ID 
	SET @hutbookid = @SHARE_BOOK_ID

END ELSE BEGIN

	SET @HPUTBookIDs = @HPUT_BOOK_ID 
	SET @hutbookid = @HPUT_BOOK_ID
	
END

--select @hutbookid 
--select * from @MEDIA_DEMO_TYPE
--select * from @MEDIA_DEMO_DETAIL_TYPE
--select * from @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE

DECLARE @AUDIENCE TABLE (
		[media_demo_id]						int NOT NULL,
		[audience]							bigint NOT NULL,
		[station_code]						int NOT NULL,
		[nielsen_tv_book_id]				int NOT NULL,
		[week]								int NOT NULL,
		[media_spot_tv_research_daytime_id] int NOT NULL,
		[number_days]						smallint NOT NULL,
		is_metered_market					bit NOT NULL,
		share_ue							bigint NOT NULL,
		hut_ue								bigint NOT NULL,
		share_hut							decimal(21,2) NOT NULL,
		share_hut_pct						decimal(21,2) NOT NULL,
		intab								decimal(21,2) NOT NULL,
		impressions							bigint NOT NULL,
		hut_hut								decimal(21,2) NOT NULL,
		hut_hut_pct							decimal(21,2) NOT NULL,
		hut_tv_book_id						int NOT NULL
	)
	
DECLARE @AUD_METRICS TABLE (
	media_demo_id		int NOT NULL,
	ue					bigint NOT NULL,
	book_year			smallint NOT NULL,
	book_month			smallint NOT NULL,
	nielsen_tv_book_id	int NOT NULL,
	is_metered_market	bit NOT NULL
)

DECLARE @HUTPUT_AVG TABLE (
	[media_demo_id]						int NOT NULL,
	[avg_hutput]						decimal(21,2) NOT NULL,
	[nielsen_tv_book_id]				int NOT NULL,
	[media_spot_tv_research_daytime_id] int NOT NULL,
	[week]								int NOT NULL
)

DECLARE @INTAB_AVG TABLE (
	[media_demo_id]						int NOT NULL,
	[avg_intab]							decimal(21,2) NOT NULL,
	[nielsen_tv_book_id]				int NOT NULL,
	[media_spot_tv_research_daytime_id] int NOT NULL,
	[week]								int NOT NULL
)

INSERT INTO @AUDIENCE
SELECT md.ID, SUM(aud.audience), aud.station_code, aud.nielsen_tv_book_id, aud.[week], aud.media_spot_tv_research_daytime_id, aud.number_days, 0, 0, 0, 0, 0, 0, 0, 0, 0, @hutbookid
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID  
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_audience_tv_book_weeks(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @STATION_CODE, @SHARE_BOOK_ID)
				) aud ON nd.CODE = aud.nielsen_demo_code
GROUP BY md.ID, aud.station_code, aud.nielsen_tv_book_id, aud.[week], aud.media_spot_tv_research_daytime_id, aud.number_days

INSERT @AUD_METRICS (media_demo_id, ue, book_year, book_month, nielsen_tv_book_id, is_metered_market)
SELECT md.ID, SUM(universe.ue), universe.book_year, universe.book_month, universe.nielsen_tv_book_id, universe.is_metered_market
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT *
				FROM dbo.advtf_nielsen_universe_spot_tv_research(@NIELSEN_MARKET_NUM)
				) universe ON nd.CODE = universe.nielsen_demo_code
GROUP BY md.ID, universe.book_year, universe.book_month, universe.nielsen_tv_book_id, universe.is_metered_market

UPDATE a SET a.share_ue = h.ue, a.is_metered_market = h.is_metered_market
FROM @AUDIENCE a
	INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.nielsen_tv_book_id = h.nielsen_tv_book_id
		
UPDATE a SET a.hut_ue = h.ue
FROM @AUDIENCE a
	INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.hut_tv_book_id = h.nielsen_tv_book_id
	
INSERT INTO @HUTPUT_AVG 
SELECT md.ID, SUM(hutput.avg_hutput), hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id, hutput.[week]
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_hutput_tv_book_weeks(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @hutbookid, @STATION_CODE)
				) hutput ON nd.CODE = hutput.nielsen_demo_code 
GROUP BY md.ID, hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id, hutput.[week]
	
INSERT INTO @HUTPUT_AVG 
SELECT md.ID, SUM(hutput.avg_hutput), hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id, hutput.[week]
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_hutput_tv_book_weeks(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @SHARE_BOOK_ID, @STATION_CODE)
				) hutput ON nd.CODE = hutput.nielsen_demo_code 
GROUP BY md.ID, hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id, hutput.[week]

UPDATE a SET a.share_hut = h.avg_hutput 
FROM @AUDIENCE a
	INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND h.nielsen_tv_book_id = @SHARE_BOOK_ID  
								AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
								AND a.[week] = h.[week]
		
UPDATE a SET a.hut_hut = h.avg_hutput 
FROM @AUDIENCE a
	INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND h.nielsen_tv_book_id = @hutbookid 
								AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
								AND a.[week] = h.[week]

UPDATE @AUDIENCE SET share_hut_pct = CAST(share_hut as decimal) / CAST(share_ue as decimal) * 100
WHERE share_ue <> 0 
	
UPDATE @AUDIENCE SET hut_hut_pct = CAST(hut_hut as decimal) / CAST(hut_ue as decimal) * 100
WHERE hut_ue <> 0 

INSERT INTO @INTAB_AVG
SELECT md.ID, SUM(intab.avg_intab), intab.nielsen_tv_book_id, intab.media_spot_tv_research_daytime_id, intab.[week]
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_intab_tv_book_weeks(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @SHARE_BOOK_ID)
				) intab ON nd.CODE = intab.nielsen_demo_code 
GROUP BY md.ID, intab.nielsen_tv_book_id, intab.media_spot_tv_research_daytime_id, intab.[week]

UPDATE a SET
	a.intab = h.avg_intab,
	a.impressions = a.AUDIENCE
		--CASE 
		--	WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab < 50 THEN 0
		--	WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab >= 50 THEN a.AUDIENCE
		--	WHEN is_metered_market = 1 AND avg_intab < 50 THEN 0
		--	WHEN is_metered_market = 1 AND avg_intab >= 50 THEN a.AUDIENCE

		--	WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab < 90 THEN 0
		--	WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab >= 90 THEN a.AUDIENCE
		--	WHEN is_metered_market = 0 AND avg_intab < 50 THEN 0 
		--	WHEN is_metered_market = 0 AND avg_intab >= 50 THEN a.AUDIENCE
		--END
FROM @AUDIENCE a
	INNER JOIN @INTAB_AVG h ON a.media_demo_id = h.media_demo_id AND a.nielsen_tv_book_id = h.nielsen_tv_book_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
							AND a.[week] = h.[week]

DECLARE @START_TIME smallint,
		@END_TIME smallint,
		@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit

SELECT TOP 1 @START_TIME = StartHour, @END_TIME = EndHour, @SUN = Sunday, @SAT = Saturday, @MON = Monday, @TUE = Tuesday, @WED = Wednesday, @THU = Thursday, @FRI = Friday
FROM @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE

SELECT
		[Book] = CONVERT(char(3), CAST(CAST(b.MONTH AS char(2)) + '/1/' + 
								 CAST(b.YEAR AS char(4)) AS smalldatetime), 0) +
				 RIGHT(CAST(b.YEAR AS char(4)), 2) + '-' +
				 CASE WHEN b.STREAM = 'LO' THEN 'L' 
						WHEN b.STREAM = 'LS' THEN 'LS' 
						WHEN b.STREAM = 'L1' THEN 'L1' 
						WHEN b.STREAM = 'L3' THEN 'L3' 
						WHEN b.STREAM = 'L7' THEN 'L7' END + CASE WHEN b.REPORTING_SERVICE = '7' THEN '-IM' ELSE '' END  +
						CASE
							WHEN UPPER(b.ETHNICITY) = 'HISP' THEN '-H'
							WHEN UPPER(b.ETHNICITY) = 'AF-AM' THEN '-B'
							WHEN UPPER(b.ETHNICITY) = 'ASIAN' THEN '-A'
							ELSE ''
						END +
						CASE
							WHEN UPPER(b.EXCLUSION) = 'EX' THEN '-OL'
							ELSE ''
						END + ' - Week ' + CAST(a.[week] AS char(1)), 
		[Program] = prg.[program_name],
		Share =  CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE       CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) END,
		Rating = CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE CAST( CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) * hut_hut_pct / 100 as decimal(21,2)) END,
		HPUT = ROUND(hut_hut_pct, 2),
		a.[week],
		Impressions = CASE WHEN hut_tv_book_id <> nielsen_tv_book_id THEN 
							CASE WHEN share_hut = 0 THEN CAST(0 as bigint) 
							ELSE CAST( ROUND ( CAST( CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) * hut_hut_pct / 100 as decimal(21,2)) * share_ue / 100, 0) as bigint)
							END
					  ELSE impressions
					  END,
		Universe = share_ue,
		StationCode = station_code,
		MediaBroadcastWorksheetMarketDetailID = a.media_spot_tv_research_daytime_id,
		MediaDemoID = a.media_demo_id,
		DayStart = d.StartTime,
		DayEnd = d.EndTime,
		[Days] = d.[Days],
		BookID = b.NIELSEN_TV_BOOK_ID,
		Demographic = md.[Description]
	FROM @AUDIENCE a
		INNER JOIN @MEDIA_DEMO_TYPE md ON a.media_demo_id = md.ID
		INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.nielsen_tv_book_id = b.NIELSEN_TV_BOOK_ID AND b.VALIDATED = 1
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON a.media_spot_tv_research_daytime_id = d.ID
		INNER JOIN dbo.NIELSEN_TV_STATION ns ON a.station_code = ns.STATION_CODE AND ns.NIELSEN_MARKET_NUM= @NIELSEN_MARKET_NUM
		INNER JOIN dbo.NIELSEN_TV_PROGRAM_BOOK pb ON pb.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM AND pb.[YEAR] = b.[YEAR] AND pb.[MONTH] = b.[MONTH] AND pb.VALIDATED = 1 AND
			pb.REPORTING_SERVICE = b.REPORTING_SERVICE AND pb.EXCLUSION = b.EXCLUSION AND pb.ETHNICITY = b.ETHNICITY
		INNER JOIN dbo.[advtf_nielsen_program_get_by_week](@SHARE_BOOK_ID, @STATION_CODE, @START_TIME, @END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, 180) prg ON a.[week] = prg.[week]
	WHERE
			(
				@HOSTED_CLIENT_CODE IS NULL
			OR
				(@HOSTED_CLIENT_CODE IS NOT NULL
				AND b.NIELSEN_TV_BOOK_ID IN  
											(SELECT NIELSEN_TV_BOOK_ID
						     				FROM dbo.V_HOSTED_TV_BOOKS
											WHERE CODE = @HOSTED_CLIENT_CODE 
											AND NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
											)
				)
			)
--OPTION (RECOMPILE)
GO

GRANT EXEC ON [advsp_tv_worksheet_rating_program_drilldown] TO PUBLIC
GO