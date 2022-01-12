CREATE PROCEDURE [dbo].[advsp_npr_spot_tv_puerto_rico_research_results]
    @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID int,
	@NPR_STATION_IDs varchar(max),
	@debug bit = 0
AS
BEGIN

	DECLARE @ADJUST_MINUTES smallint,
			@ReportType smallint,
			@ShowProgramName bit,
            @SubtotalByWeekdayWeekend bit,
            @StartDate smalldatetime,
            @EndDate smalldatetime
			
	SET @ADJUST_MINUTES = 120 --start of day is 2am
		
	SELECT @ReportType = REPORT_TYPE, @ShowProgramName = SHOW_PROGRAM_NAME, @SubtotalByWeekdayWeekend  = SUBTOTAL_BY_WEEKDAY_WEEKEND,
        @StartDate = SHARE_START_DATE, @EndDate = SHARE_END_DATE
	FROM MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH 
	WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID

	DECLARE @AUD_METRICS TABLE (
		media_demo_id		int NOT NULL,
		ue					decimal(15,5) NOT NULL,
        [media_spot_tv_research_daytime_id] int NOT NULL
	)

	DECLARE @AUDIENCE TABLE (
		[media_demo_id]						int NOT NULL,
		[audience]							int NOT NULL,
		[npr_station_id]					int NOT NULL,
		[media_spot_tv_research_daytime_id] int NOT NULL,
		[number_days]						smallint NOT NULL,
		share_ue							int NOT NULL,
		hut_ue								int NOT NULL,
		share_hut							decimal(21,2) NOT NULL,
		share_hut_pct						decimal(21,2) NOT NULL,
		intab								decimal(21,2) NOT NULL,
		impressions							int NOT NULL,
		hut_hut								decimal(21,2) NOT NULL,
		hut_hut_pct							decimal(21,2) NOT NULL,
		show_intab_warning					bit NOT NULL
	)

	DECLARE @HUTPUT_AVG TABLE (
		[media_demo_id]						int NOT NULL,
		[avg_hutput]						decimal(21,2) NOT NULL,
		[media_spot_tv_research_daytime_id] int NOT NULL
	)

	DECLARE @INTAB_AVG TABLE (
		[media_demo_id]						int NOT NULL,
		[avg_intab]							decimal(21,2) NOT NULL,
        [media_spot_tv_research_daytime_id] int NOT NULL
	)
          
	INSERT INTO @AUDIENCE
	SELECT rd.MEDIA_DEMO_ID, SUM(aud.audience), aud.npr_station_id, aud.media_spot_tv_research_daytime_id, aud.number_days, 0, 0, 0, 0, 0, 0, 0, 0, 0
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO rd ON rd.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[ORDER] = 1))
		INNER JOIN (
					SELECT * 
					FROM [dbo].[advtf_npr_audience_spot_tv_research](@MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID, @NPR_STATION_IDs, @StartDate, @EndDate)
					) aud ON nd.CODE = aud.nielsen_demo_code
    WHERE rd.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID
	GROUP BY rd.MEDIA_DEMO_ID, aud.npr_station_id, aud.media_spot_tv_research_daytime_id, aud.number_days
	
IF @debug = 1
	select * from @AUDIENCE

	INSERT @AUD_METRICS (media_demo_id, ue, [media_spot_tv_research_daytime_id])
	SELECT rd.MEDIA_DEMO_ID, SUM(universe.ue), [media_spot_tv_research_daytime_id]
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO rd ON rd.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[ORDER] = 1))
		INNER JOIN (
					SELECT *
					FROM dbo.advtf_npr_universe_spot_tv_research(@MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID, @StartDate, @EndDate)
					) universe ON nd.CODE = universe.nielsen_demo_code
    WHERE rd.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID
	GROUP BY rd.MEDIA_DEMO_ID, universe.[media_spot_tv_research_daytime_id]

IF @debug = 1
	select * from @AUD_METRICS

	UPDATE a SET a.share_ue = ROUND(h.ue,0)
	FROM @AUDIENCE a
		INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.[media_spot_tv_research_daytime_id] = h.[media_spot_tv_research_daytime_id]
		
	UPDATE a SET a.hut_ue = ROUND(h.ue,0)
	FROM @AUDIENCE a
		INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.[media_spot_tv_research_daytime_id] = h.[media_spot_tv_research_daytime_id]

	INSERT INTO @HUTPUT_AVG 
	SELECT rd.MEDIA_DEMO_ID, SUM(hutput.avg_hutput), hutput.media_spot_tv_research_daytime_id
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO rd ON rd.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[ORDER] = 1))
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_npr_hutput_spot_tv_research(@MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID, @StartDate, @EndDate)
					) hutput ON nd.CODE = hutput.nielsen_demo_code 
    WHERE rd.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID
	GROUP BY rd.MEDIA_DEMO_ID, hutput.media_spot_tv_research_daytime_id

IF @debug = 1
	SELECT * FROM @HUTPUT_AVG 

	UPDATE a SET a.share_hut = h.avg_hutput 
	FROM @AUDIENCE a
		INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
	UPDATE a SET a.hut_hut = h.avg_hutput 
	FROM @AUDIENCE a
		INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
IF @debug = 1
	SELECT * FROM @AUDIENCE 

	UPDATE @AUDIENCE SET share_hut_pct = CAST(share_hut as decimal) / CAST(share_ue as decimal) * 100
	WHERE share_ue <> 0 
	
	UPDATE @AUDIENCE SET hut_hut_pct = CAST(hut_hut as decimal) / CAST(hut_ue as decimal) * 100
	WHERE hut_ue <> 0 
	
IF @debug = 1 BEGIN
	SELECT * FROM @AUDIENCE 
END

	INSERT INTO @INTAB_AVG
	SELECT rd.MEDIA_DEMO_ID, SUM(intab.avg_intab), [media_spot_tv_research_daytime_id]
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO rd ON rd.MEDIA_DEMO_ID = mdd.MEDIA_DEMO_ID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[ORDER] = 1))
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_npr_intab_spot_tv_research(@MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID, @StartDate, @EndDate)
					) intab ON nd.CODE = intab.nielsen_demo_code 
    WHERE rd.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID
	GROUP BY rd.MEDIA_DEMO_ID, intab.[media_spot_tv_research_daytime_id]

IF @debug = 1
	SELECT * FROM @INTAB_AVG 

	UPDATE a SET
		a.intab = ROUND(h.avg_intab,0),
		a.impressions = a.audience,
		show_intab_warning = 
			CASE 
				WHEN avg_intab < 50 THEN 1
				ELSE 0
			END
	FROM @AUDIENCE a
		INNER JOIN @INTAB_AVG h ON a.media_demo_id = h.media_demo_id AND a.[media_spot_tv_research_daytime_id] = h.[media_spot_tv_research_daytime_id]
		
	SELECT
		Share =  CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE       CAST(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100 as decimal(21,2)) END,
		Rating = CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE CAST( CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100 * hut_hut_pct / 100 as decimal(21,2)) END,
		Impressions = CAST(impressions as decimal) / CAST(1000 as decimal),
		share_hut,
		hut_hut,
		hut_hut_pct,
		impressions,
		HPUT = ROUND(hut_hut_pct, 2),
		Intab = ROUND(intab, 0),
		Universe = share_ue,
		ProgramName = CASE WHEN @ShowProgramName = 1 THEN
								dbo.advfn_npr_program_get(npr_station_id, @StartDate, @EndDate, d.START_HOUR, d.END_HOUR,
									d.SUNDAY, d.MONDAY, d.TUESDAY, d.WEDNESDAY, d.THURSDAY, d.FRIDAY, d.SATURDAY, @ADJUST_MINUTES, 1)
						ELSE NULL END,
		--Audience = audience,
		StationID = npr_station_id,
		Station = ns.[NAME],
		DaytimeID = a.media_spot_tv_research_daytime_id,
		DemographicOrder = rd.[ORDER],
		DayStart = d.START_TIME,
		DayEnd = d.END_TIME,
		[Days] = d.[DAYS],
		Demographic = md.[DESCRIPTION],
		--Trend specific
		StartHour = d.START_HOUR,
		EndHour = d.END_HOUR,
        [ShowIntabWarning] = show_intab_warning		
	FROM @AUDIENCE a
        INNER JOIN dbo.MEDIA_DEMO md ON md.MEDIA_DEMO_ID = a.media_demo_id
		INNER JOIN dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO rd ON rd.MEDIA_DEMO_ID = md.MEDIA_DEMO_ID
													  AND (@ReportType = 1 OR (@ReportType IN (2, 3) AND rd.[ORDER] = 1))
		INNER JOIN MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME d ON a.media_spot_tv_research_daytime_id = d.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID
		INNER JOIN dbo.NPR_STATION ns ON a.npr_station_id = ns.NPR_STATION_ID 
    WHERE rd.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID
END
GO
