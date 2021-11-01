CREATE PROCEDURE [dbo].[advsp_nielsen_spot_tv_research_results]
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY,
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY,
	@MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE READONLY,
	@MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE READONLY,
	@MEDIA_SPOT_TV_RESEARCH_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_TYPE READONLY,
	@NIELSEN_MARKET_NUM int,
	@MARKET_DESCRIPTION varchar(40),
	@STATION_IDs varchar(max),
	@HOSTED_CLIENT_CODE varchar(6),
	@debug bit = 0
AS
BEGIN

	DECLARE @ADJUST_MINUTES smallint,
			@USE_LATEST bit,
			@LATEST_STREAM char(2),
			@BookIDs varchar(max),
			@HPUTBookIDs varchar(max),
			@ReportType smallint,
			@DominantProgramming bit,
			@ShowProgramName bit,
			@ShowSpill bit,
			@StationCodes varchar(max),
			@MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL dbo.MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE 
			
	SET @ADJUST_MINUTES = 180 --start of day is 3am
	
	SELECT @USE_LATEST = UseLatest, @LATEST_STREAM = LatestStream 
	FROM @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE
	
	INSERT @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL
	SELECT * FROM @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE

	SELECT @ReportType = ReportType, @DominantProgramming = DominantProgramming, @ShowProgramName = ShowProgramName, @ShowSpill = ShowSpill
	FROM @MEDIA_SPOT_TV_RESEARCH_TYPE
	
	SELECT @StationCodes = COALESCE(@StationCodes + ',', '') + CAST(ns.STATION_CODE as varchar)
	FROM dbo.NIELSEN_TV_STATION ns
	WHERE ns.NIELSEN_TV_STATION_ID IN (SELECT items FROM dbo.udf_split_list(@STATION_IDs, ','))
	
	IF @USE_LATEST = 1 BEGIN

		SELECT	@BookIDs = COALESCE(@BookIDs + ',', '') + CAST(nb.NIELSEN_TV_BOOK_ID as varchar),
				@HPUTBookIDs = COALESCE(@HPUTBookIDs + ',', '') + CAST(nb.NIELSEN_TV_BOOK_ID as varchar)
		FROM dbo.NIELSEN_TV_BOOK nb
			INNER JOIN (
						SELECT TOP 1 [YEAR] maxyear, [MONTH] maxmonth, STREAM, NIELSEN_MARKET_NUM
						FROM dbo.NIELSEN_TV_BOOK 
						WHERE NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
						AND STREAM = @LATEST_STREAM
						AND VALIDATED = 1
						AND (
								@HOSTED_CLIENT_CODE IS NULL
							OR
								(@HOSTED_CLIENT_CODE IS NOT NULL
								AND NIELSEN_TV_BOOK_ID IN  (SELECT NIELSEN_TV_BOOK_ID
															FROM dbo.V_HOSTED_TV_BOOKS
															WHERE CODE = @HOSTED_CLIENT_CODE 
															AND NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
															)
								)
							)
						ORDER BY [YEAR] DESC, [MONTH] DESC
						) YM ON nb.[YEAR] = YM.maxyear AND nb.[MONTH] = YM.maxmonth AND nb.STREAM = YM.STREAM AND nb.NIELSEN_MARKET_NUM = YM.NIELSEN_MARKET_NUM 

		UPDATE @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL SET ShareBookID = @BookIDs, HPUTBookID = @HPUTBookIDs

	END ELSE BEGIN		
	
		SELECT	@BookIDs = COALESCE(@BookIDs + ',', '') + CAST(NIELSEN_TV_BOOK_ID as varchar)
		FROM dbo.NIELSEN_TV_BOOK
		WHERE VALIDATED = 1
		AND (
				@HOSTED_CLIENT_CODE IS NULL
			OR
				(@HOSTED_CLIENT_CODE IS NOT NULL
				AND NIELSEN_TV_BOOK_ID IN  (SELECT NIELSEN_TV_BOOK_ID
											FROM dbo.V_HOSTED_TV_BOOKS
											WHERE CODE = @HOSTED_CLIENT_CODE 
											AND NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
											)
				)
			)
		AND NIELSEN_TV_BOOK_ID IN (
									SELECT DISTINCT ShareBookID as BookID
									FROM @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL
									)

		SELECT	@HPUTBookIDs = COALESCE(@HPUTBookIDs + ',', '') + CAST(NIELSEN_TV_BOOK_ID as varchar)
		FROM dbo.NIELSEN_TV_BOOK
		WHERE VALIDATED = 1
		AND (
				@HOSTED_CLIENT_CODE IS NULL
			OR
				(@HOSTED_CLIENT_CODE IS NOT NULL
				AND NIELSEN_TV_BOOK_ID IN  (SELECT NIELSEN_TV_BOOK_ID
											FROM dbo.V_HOSTED_TV_BOOKS
											WHERE CODE = @HOSTED_CLIENT_CODE 
											AND NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
											)
				)
			)
		AND NIELSEN_TV_BOOK_ID IN (
									SELECT DISTINCT COALESCE(HPUTBookID, ShareBookID) as BookID
									FROM @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL
									)

	END
	
	DECLARE @AUD_METRICS TABLE (
		media_demo_id		int NOT NULL,
		ue					bigint NOT NULL,
		book_year			smallint NOT NULL,
		book_month			smallint NOT NULL,
		nielsen_tv_book_id	int NOT NULL,
		is_metered_market	bit NOT NULL
	)

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
		hut_tv_book_id						int NOT NULL,
		show_intab_warning					bit NOT NULL
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

IF @debug = 1 BEGIN
	SELECT @BookIDs, @HPUTBookIDs
	SELECT * FROM @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL
END

	INSERT INTO @AUDIENCE
	SELECT md.ID, SUM(aud.audience), aud.station_code, aud.nielsen_tv_book_id, aud.media_spot_tv_research_daytime_id, aud.number_days, 0, 0, 0, 0, 0, 0, 0, 0, 0, COALESCE(b.HPUTBookID, b.ShareBookID), 0
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID  
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE rd ON rd.MediaDemoID = mdd.MediaDemographicID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[Order] = 1))
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_audience_spot_tv_research(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @StationCodes, @BookIDs)
					) aud ON nd.CODE = aud.nielsen_demo_code
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL b ON b.ShareBookID = aud.nielsen_tv_book_id
	GROUP BY md.ID, aud.station_code, aud.nielsen_tv_book_id, aud.media_spot_tv_research_daytime_id, aud.number_days, b.HPUTBookID, b.ShareBookID
	
IF @debug = 1
	select * from @AUDIENCE

	INSERT @AUD_METRICS (media_demo_id, ue, book_year, book_month, nielsen_tv_book_id, is_metered_market)
	SELECT md.ID, SUM(universe.ue), universe.book_year, universe.book_month, universe.nielsen_tv_book_id, universe.is_metered_market
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE rd ON rd.MediaDemoID = mdd.MediaDemographicID
														 AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[Order] = 1))
		INNER JOIN (
					SELECT *
					FROM dbo.advtf_nielsen_universe_spot_tv_research(@NIELSEN_MARKET_NUM)
					) universe ON nd.CODE = universe.nielsen_demo_code
	GROUP BY md.ID, universe.book_year, universe.book_month, universe.nielsen_tv_book_id, universe.is_metered_market

IF @debug = 1
	select * from @AUD_METRICS

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
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE rd ON rd.MediaDemoID = mdd.MediaDemographicID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[Order] = 1))
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
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE rd ON rd.MediaDemoID = mdd.MediaDemographicID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[Order] = 1))
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_hutput_spot_tv_research(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @BookIDs, @StationCodes)
					) hutput ON nd.CODE = hutput.nielsen_demo_code 
	GROUP BY md.ID, hutput.nielsen_tv_book_id, hutput.media_spot_tv_research_daytime_id

IF @debug = 1
	SELECT * FROM @HUTPUT_AVG 

	UPDATE a SET a.share_hut = h.avg_hutput 
	FROM @AUDIENCE a
		INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.nielsen_tv_book_id = h.nielsen_tv_book_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
	UPDATE a SET a.hut_hut = h.avg_hutput 
	FROM @AUDIENCE a
		INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.hut_tv_book_id = h.nielsen_tv_book_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
IF @debug = 1
	SELECT * FROM @AUDIENCE 

	UPDATE @AUDIENCE SET share_hut_pct = CAST(share_hut as decimal) / CAST(share_ue as decimal) * 100
	WHERE share_ue <> 0 
	
	UPDATE @AUDIENCE SET hut_hut_pct = CAST(hut_hut as decimal) / CAST(hut_ue as decimal) * 100
	WHERE hut_ue <> 0 
	
IF @debug = 1 BEGIN
	SELECT * FROM @AUDIENCE 
	SELECT * FROM @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL
END

	INSERT INTO @INTAB_AVG
	SELECT md.ID, SUM(intab.avg_intab), intab.nielsen_tv_book_id, intab.media_spot_tv_research_daytime_id
	FROM 
		@MEDIA_DEMO_TYPE md
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON md.ID = mdd.MediaDemographicID 
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE rd ON rd.MediaDemoID = mdd.MediaDemographicID
														 AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[Order] = 1))
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_nielsen_intab_spot_tv_research(@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @NIELSEN_MARKET_NUM, @BookIDs)
					) intab ON nd.CODE = intab.nielsen_demo_code 
	GROUP BY md.ID, intab.nielsen_tv_book_id, intab.media_spot_tv_research_daytime_id

IF @debug = 1
	SELECT * FROM @INTAB_AVG 

	UPDATE a SET
		a.intab = h.avg_intab,
		a.impressions = a.AUDIENCE,
		show_intab_warning = 
			CASE 
				WHEN is_metered_market = 1 AND number_days = 1 AND avg_intab < 50 THEN 1
				WHEN is_metered_market = 1 AND avg_intab < 50 THEN 1

				WHEN is_metered_market = 0 AND number_days = 1 AND h.avg_intab < 90 THEN 1
				WHEN is_metered_market = 0 AND avg_intab < 50 THEN 1

				ELSE 0
			END
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
		Share =  CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE       CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) END,
		Rating = CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE CAST( CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) * hut_hut_pct / 100 as decimal(21,2)) END,
		Impressions = CASE WHEN hut_tv_book_id <> nielsen_tv_book_id THEN 
							CASE WHEN share_hut = 0 THEN CAST(0 as bigint) 
							ELSE						  	  CAST( ROUND ( CAST( CAST(ROUND(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100, 2) as decimal(21,2)) * hut_hut_pct / 100 as decimal(21,2)) * share_ue / 100, 0) as bigint)
							END
					  ELSE impressions
					  END,
		share_hut,
		hut_hut,
		hut_hut_pct,
		impressions,
		hut_tv_book_id,
		nielsen_tv_book_id,
		HPUT = ROUND(hut_hut_pct, 2),
		Intab = ROUND(intab, 0),
		Universe = share_ue,
		ProgramName = CASE WHEN @ShowProgramName = 1 THEN
								dbo.advfn_nielsen_program_get(@NIELSEN_MARKET_NUM, station_code, b.START_DATETIME, b.END_DATETIME, d.StartHour, d.EndHour,
									d.Sunday, d.Monday, d.Tuesday, d.Wednesday, d.Thursday, d.Friday, d.Saturday, @ADJUST_MINUTES, 1, b.REPORTING_SERVICE, b.EXCLUSION, b.ETHNICITY)
						ELSE NULL END,
		--Audience = audience,
		StationCode = station_code,
		Station = ns.CALL_LETTERS,
		DaytimeID = a.media_spot_tv_research_daytime_id,
		DemographicStream = md.[Description] + ' / ' + SUBSTRING(DateName( month , DateAdd( month , b.[MONTH] , 0 ) - 1 ), 1, 3) + ' ' + SUBSTRING(CAST(b.[YEAR] as varchar), 3, 2) + ' ' +
							CASE 
								WHEN b.STREAM = 'LO' THEN 'Live'
								WHEN b.STREAM = 'LS' THEN 'Live Same Day'
								WHEN b.STREAM = 'L1' THEN 'Live+1'
								WHEN b.STREAM = 'L3' THEN 'Live+3'
								WHEN b.STREAM = 'L7' THEN 'Live+7'
								ELSE ''
							END + 
							CASE WHEN rb.HPUTBookID IS NOT NULL AND @USE_LATEST = 0 THEN ' / ' + SUBSTRING(DateName( month , DateAdd( month , b2.[MONTH] , 0 ) - 1 ), 1, 3) + ' ' + SUBSTRING(CAST(b2.[YEAR] as varchar), 3, 2) + ' ' +
								CASE 
									WHEN b2.STREAM = 'LO' THEN 'Live'
									WHEN b2.STREAM = 'LS' THEN 'Live Same Day'
									WHEN b2.STREAM = 'L1' THEN 'Live+1'
									WHEN b2.STREAM = 'L3' THEN 'Live+3'
									WHEN b2.STREAM = 'L7' THEN 'Live+7'
									ELSE ''
								END
							ELSE ''
							END,
		DemographicOrder = rd.[Order],
		DayStart = d.StartTime,
		DayEnd = d.EndTime,
		[Days] = d.[Days],
		IsSpill = CAST(CASE WHEN COALESCE(ns.HOME_MARKET_NUM,0) <> ns.NIELSEN_MARKET_NUM AND ns.NIELSEN_TV_STATION_ID IS NOT NULL AND ns.SOURCE_TYPE = 'B' THEN 1 ELSE 0 END as bit),
		ShowSpill = @ShowSpill,
		BookID = b.NIELSEN_TV_BOOK_ID,
		HPUTBookID = rb.HPUTBookID,
		Demographic = md.[Description],
		MarketDescription = @MARKET_DESCRIPTION,
		Books = SUBSTRING(DateName( month , DateAdd( month , b.[MONTH] , 0 ) - 1 ), 1, 3) + ' ' + SUBSTRING(CAST(b.[YEAR] as varchar), 3, 2) + ' ' +
							CASE 
								WHEN b.STREAM = 'LO' THEN 'Live'
								WHEN b.STREAM = 'LS' THEN 'Live Same Day'
								WHEN b.STREAM = 'L1' THEN 'Live+1'
								WHEN b.STREAM = 'L3' THEN 'Live+3'
								WHEN b.STREAM = 'L7' THEN 'Live+7'
								ELSE ''
							END + 
							CASE WHEN rb.HPUTBookID IS NOT NULL AND @USE_LATEST = 0 THEN ' / ' + SUBSTRING(DateName( month , DateAdd( month , b2.[MONTH] , 0 ) - 1 ), 1, 3) + ' ' + SUBSTRING(CAST(b2.[YEAR] as varchar), 3, 2) + ' ' +
								CASE 
									WHEN b2.STREAM = 'LO' THEN 'Live'
									WHEN b2.STREAM = 'LS' THEN 'Live Same Day'
									WHEN b2.STREAM = 'L1' THEN 'Live+1'
									WHEN b2.STREAM = 'L3' THEN 'Live+3'
									WHEN b2.STREAM = 'L7' THEN 'Live+7'
									ELSE ''
								END
							ELSE ''
							END,
		NielsenTVStationID = ns.NIELSEN_TV_STATION_ID,
		--Trend specific
		Stream = b.STREAM,
		[StreamYear] = b.[YEAR],
		[StreamMonth] =b.[MONTH],
		d.StartHour,
		[MediaSpotTVResearchBookID] = rb2.ID,
		[ShowIntabWarning] = show_intab_warning
	FROM @AUDIENCE a
		INNER JOIN @MEDIA_DEMO_TYPE md ON a.media_demo_id = md.ID
		INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.nielsen_tv_book_id = b.NIELSEN_TV_BOOK_ID
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON a.media_spot_tv_research_daytime_id = d.ID
		INNER JOIN dbo.NIELSEN_TV_STATION ns ON a.station_code = ns.STATION_CODE AND ns.NIELSEN_MARKET_NUM= @NIELSEN_MARKET_NUM
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE rd ON md.ID = rd.MediaDemoID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[Order] = 1))
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL rb2 ON rb2.ShareBookID = a.nielsen_tv_book_id AND COALESCE(rb2.HPUTBookID, rb2.ShareBookID) = a.hut_tv_book_id
		LEFT OUTER JOIN @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE_LOCAL rb ON rb.ShareBookID = a.nielsen_tv_book_id AND COALESCE(rb.HPUTBookID, 0) = COALESCE(hut_tv_book_id, 0)
		LEFT OUTER JOIN dbo.NIELSEN_TV_BOOK b2 ON rb.HPUTBookID = b2.NIELSEN_TV_BOOK_ID
END
GO
