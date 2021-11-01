IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_tv_worksheet_rating]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_tv_worksheet_rating]
GO

CREATE PROCEDURE [dbo].[advsp_tv_worksheet_rating]
	@NIELSEN_MARKET_NUM int,
	@BookIDs varchar(max),  --sharebook id
	@HPUTBookIDs varchar(max),  --hutputbook id
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY, --primary and secondary MEDIA_DEMO_IDS
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY,
	@StationCodes varchar(max), --single station code
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@HOSTED_CLIENT_CODE varchar(6)
AS
--Parameters
--1)      Market – Nielsen Market Num					101 - NEW YORK
--2)      Sharebook										25 - May 17 Live+3 (pass SHAREBOOK_NIELSEN_TV_BOOK_ID)
--3)      HUT/PUT - Optional							null  (pass HUTPUT_NIELSEN_TV_BOOK_ID)
--4)      PRIMARY Media Demo – MEDIA_DEMO table ID		ADULTS 18+   (pass MEDIA_DEMO_TYPE table)
--		  SECONDARY Media Demo – MEDIA_DEMO table ID	ADULTS 18+   (pass MEDIA_DEMO_TYPE table)
--5)      CABLE NETWORK STATION ID						2181 - NKJR (pass NIELSEN_TV_STATION_CODE instead)
--6)      Days											M-F 7am-9am
--7)      Start Time						x
--8)      End Time							x

--Output
--       Demo, Station, Days, Start Time, End Time  -> Rating, Share, HUT

--DECLARE @NIELSEN_MARKET_NUM int,
--		@BookIDs varchar(max),  --sharebook id
--		@HPUTBookIDs varchar(max),  --hutputbook id
--		@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE, --primary and secondary MEDIA_DEMO_IDS
--		@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE,
--		@StationCodes varchar(max), --single station code
--		@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE,

DECLARE	@ADJUST_MINUTES smallint,
		@hutbookid int

SET @ADJUST_MINUTES = 180 --start of day is 3am

IF ISNUMERIC(@BookIDs) = 1 AND @BookIDs NOT LIKE '%,%' BEGIN

	IF @HPUTBookIDs IS NOT NULL AND @HPUTBookIDs <> '' AND ISNUMERIC(@HPUTBookIDs) = 1 BEGIN

		SET @hutbookid = @HPUTBookIDs

	END ELSE BEGIN

		SET @hutbookid = @BookIDs

	END

END ELSE BEGIN

	SET @hutbookid = 0

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
	[media_spot_tv_research_daytime_id] int NOT NULL
)

DECLARE @INTAB_AVG TABLE (
	[media_demo_id]						int NOT NULL,
	[avg_intab]							decimal(21,2) NOT NULL,
	[nielsen_tv_book_id]				int NOT NULL,
	[media_spot_tv_research_daytime_id] int NOT NULL
)

INSERT INTO @AUDIENCE
SELECT md.ID, SUM(aud.audience), aud.station_code, aud.nielsen_tv_book_id, aud.media_spot_tv_research_daytime_id, aud.number_days, 0, 0, 0, 0, 0, 0, 0, 0, 0, CASE WHEN @hutbookid = 0 THEN aud.nielsen_tv_book_id ELSE @hutbookid END
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID  
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_audience_spot_tv_research(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @StationCodes, @BookIDs)
				) aud ON nd.CODE = aud.nielsen_demo_code
GROUP BY md.ID, aud.station_code, aud.nielsen_tv_book_id, aud.media_spot_tv_research_daytime_id, aud.number_days

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
SELECT md.ID, SUM(hutput.avg_hutput), hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_hutput_spot_tv_research(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @HPUTBookIDs, @StationCodes)
				) hutput ON nd.CODE = hutput.nielsen_demo_code 
GROUP BY md.ID, hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id
	
INSERT INTO @HUTPUT_AVG 
SELECT md.ID, SUM(hutput.avg_hutput), hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_hutput_spot_tv_research(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @BookIDs, @StationCodes)
				) hutput ON nd.CODE = hutput.nielsen_demo_code 
GROUP BY md.ID, hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id

UPDATE a SET a.share_hut = h.avg_hutput 
FROM @AUDIENCE a
	INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.nielsen_tv_book_id = h.nielsen_tv_book_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
UPDATE a SET a.hut_hut = h.avg_hutput 
FROM @AUDIENCE a
	INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.hut_tv_book_id = h.nielsen_tv_book_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
UPDATE @AUDIENCE SET share_hut_pct = CAST(share_hut as decimal) / CAST(share_ue as decimal) * 100
WHERE share_ue <> 0 
	
UPDATE @AUDIENCE SET hut_hut_pct = CAST(hut_hut as decimal) / CAST(hut_ue as decimal) * 100
WHERE hut_ue <> 0 

INSERT INTO @INTAB_AVG
SELECT md.ID, SUM(intab.avg_intab), intab.nielsen_tv_book_id, intab.media_spot_tv_research_daytime_id
FROM 
	@MEDIA_DEMO_TYPE md
	INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
	INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	INNER JOIN (
				SELECT * 
				FROM dbo.advtf_nielsen_intab_spot_tv_research(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @BookIDs)
				) intab ON nd.CODE = intab.nielsen_demo_code 
GROUP BY md.ID, intab.nielsen_tv_book_id, intab.media_spot_tv_research_daytime_id

UPDATE a SET
	a.intab = h.avg_intab,
	a.impressions = 
		CASE 
			WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab < 50 THEN a.AUDIENCE
			WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab >= 50 THEN a.AUDIENCE
			WHEN is_metered_market = 1 AND avg_intab < 50 THEN a.AUDIENCE
			WHEN is_metered_market = 1 AND avg_intab >= 50 THEN a.AUDIENCE

			WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab < 90 THEN a.AUDIENCE
			WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab >= 90 THEN a.AUDIENCE
			WHEN is_metered_market = 0 AND avg_intab < 50 THEN a.AUDIENCE
			WHEN is_metered_market = 0 AND avg_intab >= 50 THEN a.AUDIENCE
		END
	--a.impressions = 
	--	CASE 
	--		WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab < 50 THEN 0
	--		WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab >= 50 THEN a.AUDIENCE
	--		WHEN is_metered_market = 1 AND avg_intab < 50 THEN 0
	--		WHEN is_metered_market = 1 AND avg_intab >= 50 THEN a.AUDIENCE

	--		WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab < 90 THEN 0
	--		WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab >= 90 THEN a.AUDIENCE
	--		WHEN is_metered_market = 0 AND avg_intab < 50 THEN 0 
	--		WHEN is_metered_market = 0 AND avg_intab >= 50 THEN a.AUDIENCE
	--	END
FROM @AUDIENCE a
	INNER JOIN @INTAB_AVG h ON a.media_demo_id = h.media_demo_id AND a.nielsen_tv_book_id = h.nielsen_tv_book_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
SELECT
		MediaDemoID = a.media_demo_id,
		Share =  CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE       CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) END,
		Rating = CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE CAST( CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) * hut_hut_pct / 100 as decimal(21,2)) END,
		Impressions = CASE WHEN hut_tv_book_id <> nielsen_tv_book_id THEN 
							CASE WHEN share_hut = 0 THEN CAST(0 as bigint) 
							ELSE CAST( ROUND ( CAST( CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) * hut_hut_pct / 100 as decimal(21,2)) * share_ue / 100, 0) as bigint)
							END
					  ELSE impressions
					  END,
		--share_hut,
		--hut_hut,
		--hut_hut_pct,
		--impressions,
		--hut_tv_book_id,
		--nielsen_tv_book_id,
		HPUT = ROUND(hut_hut_pct, 2),
		--Intab = ROUND(intab, 0),
		Universe = share_ue,
		ProgramName = dbo.advfn_nielsen_program_get(@NIELSEN_MARKET_NUM, station_code, b.START_DATETIME, b.END_DATETIME, d.StartHour, d.EndHour,
									d.Sunday, d.Monday, d.Tuesday, d.Wednesday, d.Thursday, d.Friday, d.Saturday, @ADJUST_MINUTES, 1),
		--Audience = audience,
		StationCode = station_code,
		--Station = ns.CALL_LETTERS,
		MediaBroadcastWorksheetMarketDetailID = a.media_spot_tv_research_daytime_id,
		
		DayStart = d.StartTime,
		DayEnd = d.EndTime,
		[Days] = d.[Days],
		BookID = b.NIELSEN_TV_BOOK_ID,
		Demographic = md.[Description],
		CumeImpressions = NTCI.CUME_IMPRESSIONS
	FROM @AUDIENCE a
		INNER JOIN @MEDIA_DEMO_TYPE md ON a.media_demo_id = md.ID
		INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.nielsen_tv_book_id = b.NIELSEN_TV_BOOK_ID AND b.VALIDATED = 1
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON a.media_spot_tv_research_daytime_id = d.ID
		INNER JOIN dbo.NIELSEN_TV_STATION ns ON a.station_code = ns.STATION_CODE AND ns.NIELSEN_MARKET_NUM= @NIELSEN_MARKET_NUM
		LEFT OUTER JOIN (SELECT CUME_IMPRESSIONS = SUM(TFN.CUME_IMPRESSIONS), TFN.MEDIA_DEMO_ID, TFN.NIELSEN_TV_BOOK_ID, TFN.STATION_CODE , TFN.ID
						 FROM dbo.advtf_nielsen_tv_cume_impressions(@NIELSEN_MARKET_NUM, @BookIDs, @MEDIA_DEMO_TYPE, 
																	@MEDIA_DEMO_DETAIL_TYPE, @StationCodes, 
																	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) TFN
						 GROUP BY TFN.MEDIA_DEMO_ID, TFN.NIELSEN_TV_BOOK_ID, TFN.STATION_CODE, TFN.ID) AS NTCI ON NTCI.MEDIA_DEMO_ID = a.media_demo_id 
																										  AND NTCI.NIELSEN_TV_BOOK_ID = b.NIELSEN_TV_BOOK_ID
																										  AND NTCI.STATION_CODE = a.station_code
																										  AND d.ID = NTCI.ID
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

GRANT EXEC ON [advsp_tv_worksheet_rating] TO PUBLIC
GO