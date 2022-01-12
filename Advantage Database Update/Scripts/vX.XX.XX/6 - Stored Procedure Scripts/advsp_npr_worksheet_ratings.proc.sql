CREATE PROCEDURE [dbo].[advsp_npr_worksheet_ratings]
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@NPR_STATION_ID int,
    @MEDIA_SPOT_TV_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_DAYTIME_TYPE READONLY,
    @PRIMARY_DEMO_ID int,
    @SECONDARY_DEMO_ID int,
	@debug bit = 0
AS
BEGIN

	DECLARE @ADJUST_MINUTES smallint,			
			@ShowProgramName bit,
            @SubtotalByWeekdayWeekend bit            
            			
	SET @ADJUST_MINUTES = 120 --start of day is 2am
	SET @ShowProgramName = 1
		
		
	DECLARE @AUD_METRICS TABLE (
		media_demo_id		int NOT NULL,
		ue					int NOT NULL,
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
	SELECT mdd.MEDIA_DEMO_ID, SUM(aud.audience), aud.npr_station_id, aud.media_spot_tv_research_daytime_id, aud.number_days, 0, 0, 0, 0, 0, 0, 0, 0, 0
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM [dbo].[advtf_npr_worksheet_audience](@MEDIA_SPOT_TV_DAYTIME_TYPE, @NPR_STATION_ID, @StartDate, @EndDate)
					) aud ON nd.CODE = aud.nielsen_demo_code
	GROUP BY mdd.MEDIA_DEMO_ID, aud.npr_station_id, aud.media_spot_tv_research_daytime_id, aud.number_days
	
IF @debug = 1 BEGIN
	select getdate() as 'after load @AUDIENCE'
    select * from @AUDIENCE
END
   
	INSERT @AUD_METRICS (media_demo_id, ue, media_spot_tv_research_daytime_id)
	SELECT mdd.MEDIA_DEMO_ID, SUM(universe.ue), universe.media_spot_tv_research_daytime_id
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT *
					FROM dbo.advtf_npr_worksheet_universe(@StartDate, @EndDate, @MEDIA_SPOT_TV_DAYTIME_TYPE)
					) universe ON nd.CODE = universe.nielsen_demo_code
	GROUP BY mdd.MEDIA_DEMO_ID, universe.media_spot_tv_research_daytime_id

IF @debug = 1 BEGIN
	select getdate() as 'after load @AUD_METRICS'
	select * from @AUD_METRICS
END

	UPDATE a SET a.share_ue = ROUND(h.ue,0)
	FROM @AUDIENCE a
		INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
	UPDATE a SET a.hut_ue = ROUND(h.ue,0)
	FROM @AUDIENCE a
		INNER JOIN @AUD_METRICS h ON a.media_demo_id = h.media_demo_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id

	INSERT INTO @HUTPUT_AVG 
	SELECT mdd.MEDIA_DEMO_ID, SUM(hutput.avg_hutput), hutput.media_spot_tv_research_daytime_id
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.[advtf_npr_worksheet_hutput](@MEDIA_SPOT_TV_DAYTIME_TYPE, @StartDate, @EndDate)
					) hutput ON nd.CODE = hutput.nielsen_demo_code 
	GROUP BY mdd.MEDIA_DEMO_ID, hutput.media_spot_tv_research_daytime_id
	
IF @debug = 1 BEGIN
	select getdate() as 'after load @HUTPUT_AVG'
	SELECT * FROM @HUTPUT_AVG 
END

	UPDATE a SET a.share_hut = h.avg_hutput 
	FROM @AUDIENCE a
		INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
	UPDATE a SET a.hut_hut = h.avg_hutput 
	FROM @AUDIENCE a
		INNER JOIN @HUTPUT_AVG h ON a.media_demo_id = h.media_demo_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id
		
IF @debug = 1 BEGIN
	select getdate() as 'after update @AUDIENCE FROM @HUTPUT_AVG'
	SELECT * FROM @AUDIENCE 
END

	UPDATE @AUDIENCE SET share_hut_pct = CAST(share_hut as decimal) / CAST(share_ue as decimal) * 100
	WHERE share_ue <> 0 
	
	UPDATE @AUDIENCE SET hut_hut_pct = CAST(hut_hut as decimal) / CAST(hut_ue as decimal) * 100
	WHERE hut_ue <> 0 
	
IF @debug = 1 BEGIN
    select getdate() as 'after update @AUDIENCE hut_pcts'
	SELECT * FROM @AUDIENCE 
END

	INSERT INTO @INTAB_AVG
	SELECT mdd.MEDIA_DEMO_ID, SUM(intab.avg_intab), intab.media_spot_tv_research_daytime_id
	FROM 
		dbo.MEDIA_DEMO_DETAIL mdd
		INNER JOIN dbo.NIELSEN_DEMO nd ON mdd.NIELSEN_DEMO_ID = nd.NIELSEN_DEMO_ID 
		INNER JOIN (
					SELECT * 
					FROM dbo.advtf_npr_worksheet_intab(@StartDate, @EndDate, @MEDIA_SPOT_TV_DAYTIME_TYPE)
					) intab ON nd.CODE = intab.nielsen_demo_code 
	GROUP BY mdd.MEDIA_DEMO_ID, intab.media_spot_tv_research_daytime_id

IF @debug = 1 BEGIN
	select getdate() as 'after load @INTAB_AVG'
	SELECT * FROM @INTAB_AVG 
END

	UPDATE a SET
		a.intab = ROUND(h.avg_intab,0),
		a.impressions = a.audience,
		show_intab_warning = 
			CASE 
				WHEN avg_intab < 50 THEN 1
				ELSE 0
			END
	FROM @AUDIENCE a
		INNER JOIN @INTAB_AVG h ON a.media_demo_id = h.media_demo_id AND a.media_spot_tv_research_daytime_id = h.media_spot_tv_research_daytime_id

IF @debug = 1 BEGIN
	select getdate() as 'after update @AUDIENCE intab warnings'
END

	SELECT
		Share =  CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE       CAST(CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100 as decimal(21,2)) END,
		Rating = CASE WHEN share_hut = 0 THEN CAST(0 as decimal(21,2)) ELSE CAST( CAST(impressions as decimal) / CAST(CAST(round(share_hut,0) as int) as decimal) * 100 * hut_hut_pct / 100 as decimal(21,2)) END,
		Impressions = CAST(impressions as bigint), --CAST(ROUND(CAST(impressions as decimal) / CAST(1000 as decimal),0) as bigint),
		share_hut,
		hut_hut,
		hut_hut_pct,
		impressions,
		HPUT = ROUND(hut_hut_pct, 2),
		Intab = ROUND(intab, 0),
		Universe = CAST(share_ue as bigint),
		ProgramName = CASE WHEN @ShowProgramName = 1 THEN
								dbo.advfn_npr_program_get(npr_station_id, @StartDate, @EndDate, d.StartHour, d.EndHour,
									d.Sunday, d.Monday, d.Tuesday, d.Wednesday, d.Thursday, d.Friday, d.Saturday, @ADJUST_MINUTES, 1)
						ELSE NULL END,
		--Audience = audience,
		StationID = npr_station_id,
		Station = ns.[NAME],
		MediaBroadcastWorksheetMarketDetailID = a.media_spot_tv_research_daytime_id,
		--DemographicOrder = rd.[ORDER],
		DayStart = d.StartTime,
		DayEnd = d.EndTime,
		[Days] = d.[Days],
		Demographic = md.[DESCRIPTION],
		--Trend specific
		StartHour = d.StartHour,
		EndHour = d.EndHour,
        [ShowIntabWarning] = show_intab_warning,
        MediaDemoID = md.MEDIA_DEMO_ID 
	FROM @AUDIENCE a
        INNER JOIN dbo.MEDIA_DEMO md ON md.MEDIA_DEMO_ID = a.media_demo_id
		INNER JOIN @MEDIA_SPOT_TV_DAYTIME_TYPE d ON a.media_spot_tv_research_daytime_id = d.ID
		INNER JOIN dbo.NPR_STATION ns ON a.npr_station_id = ns.NPR_STATION_ID 
    WHERE
        md.MEDIA_DEMO_ID = @PRIMARY_DEMO_ID
    OR  md.MEDIA_DEMO_ID = @SECONDARY_DEMO_ID

IF @debug = 1 BEGIN
	select getdate() as 'done'
END

END
GO


