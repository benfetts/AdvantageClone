﻿CREATE PROCEDURE [dbo].[advsp_radio_worksheet_rating]
	@NIELSEN_RADIO_MARKET_NUMBER int,
	@NIELSEN_RADIO_PERIOD_IDs varchar(max),
	@GEO_INDICATOR smallint,
	@STATION_COMBO_IDs varchar(max),
	@SelectedMediaDemographicIDs varchar(max),
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY, --primary and secondary MEDIA_DEMO_IDS
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY,
	@HOSTED_CLIENT_CODE varchar(6)
AS
BEGIN

	DECLARE @NIELSEN_RADIO_SEGMENT_PARENT_IDs	varchar(max),
			@NIELSEN_RADIO_QUALITATIVE_ID		int,
			@LISTENING_LOCATION					char(1),
			@STATION_COMBO_TYPE					smallint,
			@AVG_POP							bigint

	SET @NIELSEN_RADIO_QUALITATIVE_ID = 1 -- all
	SET @LISTENING_LOCATION = '1' --total
	SET @STATION_COMBO_TYPE = 1 -- individual station
	
	DECLARE @POPULATION TABLE (
		[Population] bigint NOT NULL,
		[NIELSEN_RADIO_SEGMENT_PARENT_ID] int NOT NULL
	)
	
	DECLARE @AQH TABLE (
		[AQH] bigint NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL,
		MEDIA_DEMO_ID int NOT NULL,
		ID int NOT NULL
	)
	
	DECLARE @CUME TABLE (
		[CUME] bigint NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL,
		MEDIA_DEMO_ID int NOT NULL,
		ID int NOT NULL
	)
	
	DECLARE @CLIENT_PERIODS TABLE (
		NielsenRadioPeriodID int NOT NULL,
		NielsenRadioMarketNumber int NOT NULL,
		[Year] smallint NOT NULL, 
		[Month] smallint NOT NULL
	)

	IF @HOSTED_CLIENT_CODE IS NOT NULL
		INSERT @CLIENT_PERIODS 
		EXEC advsp_nielsen_spot_radio_get_client_periods @HOSTED_CLIENT_CODE

	SELECT @NIELSEN_RADIO_SEGMENT_PARENT_IDs = COALESCE(@NIELSEN_RADIO_SEGMENT_PARENT_IDs + ',', '') + CAST(NIELSEN_RADIO_SEGMENT_PARENT_ID as varchar)
	FROM dbo.NIELSEN_RADIO_SEGMENT_PARENT nrsp
		INNER JOIN dbo.NIELSEN_RADIO_PERIOD nrp ON nrsp.NIELSEN_RADIO_PERIOD_ID = nrp.NIELSEN_RADIO_PERIOD_ID AND nrp.VALIDATED = 1
	WHERE nrp.NIELSEN_RADIO_PERIOD_ID IN (SELECT items FROM dbo.udf_split_list(@NIELSEN_RADIO_PERIOD_IDs, ','))
	AND GEO_INDICATOR = @GEO_INDICATOR
	AND NIELSEN_RADIO_QUALITATIVE_ID = 1
	AND (
			@HOSTED_CLIENT_CODE IS NULL
		OR
			(@HOSTED_CLIENT_CODE IS NOT NULL
			AND nrp.NIELSEN_RADIO_PERIOD_ID IN (SELECT NielsenRadioPeriodID 
												FROM @CLIENT_PERIODS
												WHERE NielsenRadioMarketNumber = @NIELSEN_RADIO_MARKET_NUMBER
												)
			)
		)
		
	INSERT INTO @POPULATION ([Population], [NIELSEN_RADIO_SEGMENT_PARENT_ID])
	SELECT SUM([POPULATION]), [NIELSEN_RADIO_SEGMENT_PARENT_ID]
	FROM dbo.[advtf_nielsen_radio_universe_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_QUALITATIVE_ID) U
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = U.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID
	GROUP BY [NIELSEN_RADIO_SEGMENT_PARENT_ID]
	
	INSERT INTO @AQH (AQH, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_STATION_COMBO_ID, MEDIA_DEMO_ID, ID)
	SELECT SUM(AQH), AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID, AQH.MEDIA_DEMO_ID, AQH.ID
	FROM dbo.[advtf_nielsen_radio_audience_get_aqh](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @LISTENING_LOCATION, @STATION_COMBO_TYPE, @SelectedMediaDemographicIDs, @MEDIA_DEMO_DETAIL_TYPE, @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) AQH
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = AQH.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID
	WHERE AQH.NIELSEN_RADIO_STATION_COMBO_ID IN (SELECT items FROM dbo.udf_split_list(@STATION_COMBO_IDs, ','))
	GROUP BY AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID, AQH.MEDIA_DEMO_ID, AQH.ID
	
	INSERT INTO @CUME (CUME, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_STATION_COMBO_ID, MEDIA_DEMO_ID, ID)
	SELECT SUM(CUME), CUME.NIELSEN_RADIO_SEGMENT_PARENT_ID, CUME.NIELSEN_RADIO_STATION_COMBO_ID, CUME.MEDIA_DEMO_ID, CUME.ID
	FROM dbo.[advtf_nielsen_radio_audience_get_cume](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @LISTENING_LOCATION, @STATION_COMBO_TYPE, 
												     @SelectedMediaDemographicIDs, @MEDIA_DEMO_DETAIL_TYPE, 
													 @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @STATION_COMBO_IDs) CUME
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = CUME.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID
	WHERE CUME.NIELSEN_RADIO_STATION_COMBO_ID IN (SELECT items FROM dbo.udf_split_list(@STATION_COMBO_IDs, ','))
	GROUP BY CUME.NIELSEN_RADIO_SEGMENT_PARENT_ID, CUME.NIELSEN_RADIO_STATION_COMBO_ID, CUME.MEDIA_DEMO_ID, ID

	SELECT @AVG_POP = AVG([Population]) FROM @POPULATION
	--select * from @CUME
	--select * from @AQH
	
	SELECT
		[MediaDemoID] = md.ID,
		[Demographic] = md.[Description],
      --[AQHRating] = ISNULL(CASE WHEN @AVG_POP = 0 THEN 0 ELSE ROUND( CAST( ROUND(AQH, -2) / 100 as decimal) / CAST( @AVG_POP / 100 as decimal) * 100, 1) END, 0),
		[AQHRating] = ISNULL(CASE WHEN @AVG_POP = 0 THEN 0 ELSE CAST( AQH / 100 as decimal) / CAST( @AVG_POP / 100 as decimal) * 100 END, 0),
		[AQH] = ISNULL([AQH], 0),
		[CumeRating] = ISNULL(CASE WHEN @AVG_POP = 0 THEN 0 ELSE ROUND( CAST( ROUND([CUME], -2) / 100 as decimal) / CAST( @AVG_POP / 100 as decimal) * 100, 1) END, 0),
		[CUME] = ISNULL([CUME], 0),
		[NielsenRadioStationComboID] = AQH.NIELSEN_RADIO_STATION_COMBO_ID,
		[Population] = @AVG_POP,
		[NielsenRadioPeriodID] = NRSP.NIELSEN_RADIO_PERIOD_ID,
		[MediaBroadcastWorksheetMarketDetailID] = d.ID
	FROM (
		SELECT
			--[AQH] = ROUND( AVG(AQH.[AQH]), -2) / 100,
			[AQH] = AVG(AQH.[AQH]),
			AQH.NIELSEN_RADIO_STATION_COMBO_ID,  
			AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID,
			AQH.MEDIA_DEMO_ID,
			ID
		FROM @AQH AQH
		GROUP BY AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID, AQH.MEDIA_DEMO_ID, ID
		) AQH 

		LEFT OUTER JOIN
		(
		SELECT
			--[CUME] = ROUND( AVG([CUME]), -2) / 100,
			[CUME] =  AVG([CUME]),
			CUME.NIELSEN_RADIO_STATION_COMBO_ID, 
			CUME.NIELSEN_RADIO_SEGMENT_PARENT_ID,
			CUME.MEDIA_DEMO_ID,
			ID
		FROM @CUME CUME 
		GROUP BY CUME.NIELSEN_RADIO_SEGMENT_PARENT_ID, CUME.NIELSEN_RADIO_STATION_COMBO_ID, CUME.MEDIA_DEMO_ID, ID
		) CUME ON CUME.NIELSEN_RADIO_STATION_COMBO_ID = AQH.NIELSEN_RADIO_STATION_COMBO_ID 
				  AND CUME.NIELSEN_RADIO_SEGMENT_PARENT_ID = AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID 
				  AND CUME.ID = AQH.ID
		INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON d.ID = AQH.ID
		INNER JOIN @MEDIA_DEMO_TYPE md ON md.ID = AQH.MEDIA_DEMO_ID 
		INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_PARENT NRSP ON NRSP.NIELSEN_RADIO_SEGMENT_PARENT_ID = AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID

END
GO