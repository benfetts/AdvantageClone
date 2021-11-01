CREATE PROCEDURE [dbo].[advsp_tv_worksheet_rating_cable]
	@NIELSEN_MARKET_NUM int,
	@BookIDs varchar(max),  --sharebook id
	@HPUTBookIDs varchar(max),  --hutputbook id
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY, --primary and secondary MEDIA_DEMO_IDS
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY,
	@StationCodes varchar(max), --single station code
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@NCCTVSyscodeID int,
	@HOSTED_CLIENT_CODE varchar(6)
AS
/*
DECLARE
	@NIELSEN_MARKET_NUM int,
	@BookIDs varchar(max),  --sharebook id
	@HPUTBookIDs varchar(max),  --hutputbook id
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE, --READONLY, --primary and secondary MEDIA_DEMO_IDS
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE, --READONLY,
	@StationCodes varchar(max), --single station code
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, --READONLY,
	@NCCTVSyscodeID smallint,
	@HOSTED_CLIENT_CODE varchar(6)

	set @NIELSEN_MARKET_NUM = 101
	set @BookIDs  = '31'
	set @HPUTBookIDs = '35'
	set @StationCodes = '6204'
	set @NCCTVSyscodeID  = 1832
	set @HOSTED_CLIENT_CODE = NULL

	insert into @MEDIA_DEMO_TYPE (ID, Description) values(72,N'Adults 18+')
			
	insert into @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE (ID, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, StartTime, EndTime, StartHour, EndHour, [Days], ExactSpotDate)
	values(1,1,1,1,1,1,0,0,N'08:00 PM',N'09:00 PM',2000,2100,N'M-F',NULL)

	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,15)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,6)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,16)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,7)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,17)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,8)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,18)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,9)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,19)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,10)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,20)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,11)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,21)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(72,12)

*/

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
	nielsen_tv_book_id	int NOT NULL
	--is_metered_market	bit NOT NULL
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

DECLARE @CARRIAGE TABLE (
	[nielsen_tv_book_id]				int NOT NULL,
	[station_code]						int NOT NULL,
	[hh_carriage_ue]					int NOT NULL
)

DECLARE @AIUE TABLE (
	[nielsen_tv_book_id]				int NOT NULL,
	[station_code]						int NOT NULL,
	[hh_aiue]							int NOT NULL
)

--IF (SELECT COUNT(1) FROM dbo.NCC_TV_LPM_MARKET WHERE NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM) = 0 BEGIN
--	INSERT INTO @AUDIENCE
--	SELECT md.ID, SUM(aud.audience), aud.station_code, aud.nielsen_tv_book_id, aud.media_spot_tv_research_daytime_id, aud.number_days, 0, 0, 0, 0, 0, 0, 0, 0, 0, CASE WHEN @hutbookid = 0 THEN aud.nielsen_tv_book_id ELSE @hutbookid END
--	FROM 
--		@MEDIA_DEMO_TYPE md
--		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID  
--		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
--		INNER JOIN (
--					SELECT * 
--					FROM dbo.advtf_ncc_tv_fusion_audience(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @StationCodes, @BookIDs)
--					) aud ON nd.CODE = aud.nielsen_demo_code
--	GROUP BY md.ID, aud.station_code, aud.nielsen_tv_book_id, aud.media_spot_tv_research_daytime_id, aud.number_days

--	INSERT @AUD_METRICS (media_demo_id, ue, book_year, book_month, nielsen_tv_book_id)
--	SELECT md.ID, SUM(universe.ue), universe.book_year, universe.book_month, universe.nielsen_tv_book_id
--	FROM 
--		@MEDIA_DEMO_TYPE md
--		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
--		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
--		INNER JOIN (
--					SELECT *
--					FROM dbo.advtf_ncc_tv_fusion_universe(@NIELSEN_MARKET_NUM)
--					) universe ON nd.CODE = universe.nielsen_demo_code
--	GROUP BY md.ID, universe.book_year, universe.book_month, universe.nielsen_tv_book_id
	
--	INSERT INTO @HUTPUT_AVG 
--	SELECT md.ID, SUM(hutput.avg_hutput), hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id
--	FROM 
--		@MEDIA_DEMO_TYPE md
--		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
--		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
--		INNER JOIN (
--					SELECT * 
--					FROM dbo.advtf_ncc_tv_fusion_hutput(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @HPUTBookIDs, @StationCodes)
--					) hutput ON nd.CODE = hutput.nielsen_demo_code 
--	GROUP BY md.ID, hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id

--	INSERT INTO @HUTPUT_AVG 
--	SELECT md.ID, SUM(hutput.avg_hutput), hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id
--	FROM 
--		@MEDIA_DEMO_TYPE md
--		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
--		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
--		INNER JOIN (
--					SELECT * 
--					FROM dbo.advtf_ncc_tv_fusion_hutput(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @BookIDs, @StationCodes)
--					) hutput ON nd.CODE = hutput.nielsen_demo_code 
--	GROUP BY md.ID, hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id

--END ELSE BEGIN
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
	
	INSERT @AUD_METRICS (media_demo_id, ue, book_year, book_month, nielsen_tv_book_id)
	SELECT md.ID, SUM(universe.ue), universe.book_year, universe.book_month, universe.nielsen_tv_book_id
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT *
					FROM dbo.advtf_nielsen_universe_spot_tv_research(@NIELSEN_MARKET_NUM)
					) universe ON nd.CODE = universe.nielsen_demo_code
	GROUP BY md.ID, universe.book_year, universe.book_month, universe.nielsen_tv_book_id
	
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

--END

INSERT INTO @CARRIAGE 
SELECT b.NIELSEN_TV_BOOK_ID, u.STATION_CODE, HH_CARRIAGE_UE 
FROM dbo.NCC_TV_CARRIAGE_UE u
	INNER JOIN dbo.NCC_TV_CARRIAGE_UE_LOG cl ON u.NCC_TV_CARRIAGE_UE_LOG_ID = cl.NCC_TV_CARRIAGE_UE_LOG_ID AND cl.VALIDATED = 1
	INNER JOIN dbo.NIELSEN_TV_BOOK b ON cl.[YEAR] = b.[YEAR] AND cl.[MONTH] = b.[MONTH]
WHERE u.STATION_CODE IN (SELECT items FROM dbo.udf_split_list_int(@StationCodes, ','))
AND u.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
AND b.NIELSEN_TV_BOOK_ID IN (SELECT items FROM dbo.udf_split_list_int(@BookIDs, ','))
AND b.REPORTING_SERVICE = '1' AND b.ETHNICITY = '' AND b.EXCLUSION = ''

INSERT INTO @AIUE
SELECT b.NIELSEN_TV_BOOK_ID, u.STATION_CODE, HH_AIUE
FROM dbo.NCC_TV_AI_UE u
	INNER JOIN dbo.NCC_TV_AI_UE_LOG ul ON u.NCC_TV_AI_UE_LOG_ID = ul.NCC_TV_AI_UE_LOG_ID AND ul.VALIDATED = 1
	INNER JOIN dbo.NCC_TV_SYSCODE ts ON u.SYSCODE = ts.SYSCODE AND ts.NCC_TV_SYSCODE_ID = @NCCTVSyscodeID
	INNER JOIN dbo.NIELSEN_TV_BOOK b ON ul.[YEAR] = b.[YEAR] AND ul.[MONTH] = b.[MONTH]
WHERE
	(u.STATION_CODE = 0 OR u.STATION_CODE IN (SELECT items FROM dbo.udf_split_list_int(@StationCodes, ',')))
AND b.NIELSEN_TV_BOOK_ID IN (SELECT items FROM dbo.udf_split_list_int(@BookIDs, ','))
AND b.REPORTING_SERVICE = '1' AND b.ETHNICITY = '' AND b.EXCLUSION = ''

UPDATE a SET a.share_ue = h.ue
FROM @AUDIENCE a
	INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.nielsen_tv_book_id = h.nielsen_tv_book_id
		
UPDATE a SET a.hut_ue = h.ue
FROM @AUDIENCE a
	INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.hut_tv_book_id = h.nielsen_tv_book_id
	
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
			WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab < 50 THEN a.audience
			WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab >= 50 THEN a.audience
			WHEN is_metered_market = 1 AND avg_intab < 50 THEN a.audience
			WHEN is_metered_market = 1 AND avg_intab >= 50 THEN a.audience

			WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab < 90 THEN a.audience
			WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab >= 90 THEN a.audience
			WHEN is_metered_market = 0 AND avg_intab < 50 THEN a.audience
			WHEN is_metered_market = 0 AND avg_intab >= 50 THEN a.audience
		END
	--a.impressions = 
	--	CASE 
	--		WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab < 50 THEN 0
	--		WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab >= 50 THEN a.audience
	--		WHEN is_metered_market = 1 AND avg_intab < 50 THEN 0
	--		WHEN is_metered_market = 1 AND avg_intab >= 50 THEN a.audience

	--		WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab < 90 THEN 0
	--		WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab >= 90 THEN a.audience
	--		WHEN is_metered_market = 0 AND avg_intab < 50 THEN 0 
	--		WHEN is_metered_market = 0 AND avg_intab >= 50 THEN a.audience
	--	END
FROM @AUDIENCE a
	INNER JOIN @INTAB_AVG h ON a.media_demo_id = h.media_demo_id AND a.nielsen_tv_book_id = h.nielsen_tv_book_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
--SELECT * FROM @AUDIENCE
--SELECT * FROM @CARRIAGE
--SELECT * FROM @AIUE
--SELECT * FROM @HUTPUT_AVG

SELECT
	MediaBroadcastWorksheetMarketDetailID,
	DMARating = ROUND(ISNULL(Rating, 0),2),
	Share,
	HPUT,
	ProgramName,
	--Impressions,
	Universe = ISNULL(Universe, 0),
	CumeImpressions = ISNULL(CumeImpressions, 0),
	BookID,
	MediaDemoID,
	StationCode,
	DMADemoRating = ROUND(Share * HPUT / 100.00, 2),
	DMADemoImps = ROUND(Share * HPUT / 100.00 * CAST(share_ue as decimal) / 100, 0),
	Impressions = CASE WHEN NULLIF(@HPUTBookIDs,'') IS NULL THEN Impressions ELSE CAST(ROUND(Share * HPUT / 100.00 * CAST(share_ue as decimal) / 100 * CDMADemoUEFactor, 0) as bigint) END,
	Rating = ROUND(Share * HPUT / 100.00 * CAST(share_ue as decimal) / 100 * CDMADemoUEFactor / CDMADemoUE * 100, 2),
	CDMADemoUE
FROM (
	SELECT 
		MediaBroadcastWorksheetMarketDetailID = tableb.media_spot_tv_research_daytime_id,
		Rating = 
				CASE WHEN media_demo_id = 1 THEN 
					CASE WHEN nz = 0 THEN 0
					ELSE CAST(Impressions as decimal)/ CAST(nz as decimal) * 100
					END
				ELSE
					CASE WHEN nielsendatahhue = 0 OR nz = 0 OR nielsendata.ue = 0 THEN 0
					ELSE CAST(Impressions as decimal) / ((CAST(nz as decimal) / CAST(nielsendatahhue as decimal)) * nielsendata.ue) * 100
					END
				END, --cDMARating
		Share =  CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE       CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) END,
		HPUT = ROUND(hut_hut_pct, 2),
		ProgramName,
		Impressions,
		Universe = CAST(tableb.share_ue * CDMAAdjustmentFactor as bigint), 
		CumeImpressions = CAST(NTCI.CUME_IMPRESSIONS * CDMAAdjustmentFactor as bigint),
		BookID = tableb.nielsen_tv_book_id,
		MediaDemoID = tableb.media_demo_id,
		StationCode = tableb.station_code,
		share_ue,
		CDMAAdjustmentFactor,
		CDMADemoUEFactor,
		CDMADemoUE = CDMAAdjustmentFactor * share_ue
	FROM (
		SELECT
			tablea.hh_aiue,
			d.media_demo_id,
			d.impressions,
			Impressions = CAST(ROUND(tablea.UEFactor * d.impressions,0) as bigint),
			d.share_hut,
			d.hut_hut_pct,
			d.media_spot_tv_research_daytime_id,
			d.share_ue,
			ProgramName = dbo.advfn_nielsen_program_get(@NIELSEN_MARKET_NUM, d.station_code, b.START_DATETIME, b.END_DATETIME, dt.StartHour, dt.EndHour,
										dt.Sunday, dt.Monday, dt.Tuesday, dt.Wednesday, dt.Thursday, dt.Friday, dt.Saturday, @ADJUST_MINUTES, 1, b.REPORTING_SERVICE, b.EXCLUSION, b.ETHNICITY),
			CDMAAdjustmentFactor = CAST(nz as decimal) / CAST(nielsendatahh.ue as decimal),
			nielsendatahhue = nielsendatahh.ue,
			tablea.nielsen_tv_book_id,
			tablea.station_code,
			tablea.nz,
			CDMADemoUEFactor = UEFactor
		FROM (
				SELECT
					a.nielsen_tv_book_id,
					a.hh_aiue,
					c.hh_carriage_ue,
					a.station_code,
					UEFactor = CASE WHEN c.hh_carriage_ue = 0 THEN 0 ELSE CAST(a.hh_aiue as decimal) / CAST(c.hh_carriage_ue as decimal) END,
					nz = (SELECT hh_aiue FROM @AIUE WHERE station_code = 0 and nielsen_tv_book_id = a.nielsen_tv_book_id)
				FROM @AIUE a
					INNER JOIN @CARRIAGE c ON a.nielsen_tv_book_id = c.nielsen_tv_book_id AND a.station_code = c.station_code 
			 ) tablea
				INNER JOIN @AUDIENCE d ON tablea.nielsen_tv_book_id = d.nielsen_tv_book_id 
				INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dt ON d.media_spot_tv_research_daytime_id = dt.ID
				INNER JOIN dbo.NIELSEN_TV_BOOK b ON tablea.nielsen_tv_book_id = b.NIELSEN_TV_BOOK_ID AND b.VALIDATED = 1
				LEFT OUTER JOIN 
				(
					SELECT ue.ue, ue.nielsen_tv_book_id 
					FROM dbo.advtf_nielsen_universe_spot_tv_research(@NIELSEN_MARKET_NUM) ue
					WHERE ue.nielsen_demo_code = 'hh'
				) nielsendatahh on b.NIELSEN_TV_BOOK_ID = nielsendatahh.nielsen_tv_book_id
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
		) tableb
		LEFT OUTER JOIN 
			(
				SELECT md.ID, SUM(ue.ue) as ue, ue.nielsen_tv_book_id
				FROM 
					@MEDIA_DEMO_TYPE md
					INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID  
					INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
					INNER JOIN (
								SELECT * 
								FROM dbo.advtf_nielsen_universe_spot_tv_research(@NIELSEN_MARKET_NUM)
								) ue ON nd.CODE = ue.nielsen_demo_code
				GROUP BY md.ID, ue.nielsen_tv_book_id
			) nielsendata on tableb.nielsen_tv_book_id = nielsendata.nielsen_tv_book_id
		LEFT OUTER JOIN (
						SELECT CUME_IMPRESSIONS = SUM(TFN.CUME_IMPRESSIONS), TFN.MEDIA_DEMO_ID, TFN.NIELSEN_TV_BOOK_ID, TFN.STATION_CODE , TFN.ID
						FROM dbo.advtf_nielsen_tv_cume_impressions(@NIELSEN_MARKET_NUM, @BookIDs, @MEDIA_DEMO_TYPE, 
																@MEDIA_DEMO_DETAIL_TYPE, @StationCodes, 
																@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) TFN
						GROUP BY TFN.MEDIA_DEMO_ID, TFN.NIELSEN_TV_BOOK_ID, TFN.STATION_CODE, TFN.ID) AS NTCI ON NTCI.MEDIA_DEMO_ID = tableb.media_demo_id 
																										AND NTCI.NIELSEN_TV_BOOK_ID = tableb.nielsen_tv_book_id
																										AND NTCI.STATION_CODE = tableb.station_code
																										AND NTCI.ID  = tableb.media_spot_tv_research_daytime_id 
	) results
GO