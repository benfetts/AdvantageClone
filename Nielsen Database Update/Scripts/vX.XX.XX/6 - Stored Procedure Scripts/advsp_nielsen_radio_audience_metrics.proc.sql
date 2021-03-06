IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_nielsen_radio_audience_metrics]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_nielsen_radio_audience_metrics]
GO

CREATE PROCEDURE [dbo].[advsp_nielsen_radio_audience_metrics]
	@NIELSEN_RADIO_MARKET_NUMBER int,
	@NIELSEN_RADIO_PERIOD_ID int,
	@GEO_INDICATOR smallint,
	@STATION_COMBO_ID int,
	@SelectedMediaDemographicIDs varchar(max),
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY,
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY
AS
BEGIN

	DECLARE @NIELSEN_RADIO_SEGMENT_PARENT_IDs	varchar(max),
			@NIELSEN_RADIO_QUALITATIVE_ID		int,
			@LISTENING_LOCATION					char(1),
			@STATION_COMBO_TYPE					smallint

	SET @NIELSEN_RADIO_QUALITATIVE_ID = 1 -- all
	SET @LISTENING_LOCATION = '1' --total
	SET @STATION_COMBO_TYPE = 1 -- individual station

	SELECT @NIELSEN_RADIO_SEGMENT_PARENT_IDs = COALESCE(@NIELSEN_RADIO_SEGMENT_PARENT_IDs + ',', '') + CAST(NIELSEN_RADIO_SEGMENT_PARENT_ID as varchar)
	FROM dbo.NIELSEN_RADIO_SEGMENT_PARENT 
	WHERE NIELSEN_RADIO_PERIOD_ID = @NIELSEN_RADIO_PERIOD_ID
	AND GEO_INDICATOR = @GEO_INDICATOR
	AND NIELSEN_RADIO_QUALITATIVE_ID = 1
	
	--select * from dbo.[advtf_nielsen_radio_audience_get_aqh](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @LISTENING_LOCATION, @STATION_COMBO_TYPE, @SelectedMediaDemographicIDs, @MEDIA_DEMO_DETAIL_TYPE, @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) AQH

	SELECT
		[MediaDemoID] = md.ID,
		[Demographic] = md.[Description],
		[AQHRating] = CASE WHEN [Population] = 0 THEN 0 ELSE ROUND( CAST( AQH as decimal) / CAST( [Population] / 100 as decimal) * 100, 1) END,
		[AQH],
		[CumeRating] = CASE WHEN [Population] = 0 THEN 0 ELSE ROUND( CAST( [CUME] as decimal) / CAST( [Population] / 100 as decimal) * 100, 1) END,
		[CUME]
	FROM (
		SELECT
			AQH.NIELSEN_DEMO_CODE,
			[Population] = U.[POPULATION],
			[AQH] = AQH.AQH,
			[CUME] = CUME.CUME,
			AQH.MEDIA_DEMO_ID,
			AQH.NIELSEN_RADIO_STATION_COMBO_ID
		FROM dbo.[advtf_nielsen_radio_audience_get_aqh](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @LISTENING_LOCATION, @STATION_COMBO_TYPE, @SelectedMediaDemographicIDs, @MEDIA_DEMO_DETAIL_TYPE, @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) AQH
			INNER JOIN dbo.[advtf_nielsen_radio_universe_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_QUALITATIVE_ID) U
				ON AQH.NIELSEN_DEMO_CODE = U.NIELSEN_DEMO_CODE 
			INNER JOIN dbo.[advtf_nielsen_radio_audience_get_cume](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @LISTENING_LOCATION, @STATION_COMBO_TYPE, @SelectedMediaDemographicIDs, @MEDIA_DEMO_DETAIL_TYPE, @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) CUME
				ON AQH.NIELSEN_DEMO_CODE = CUME.NIELSEN_DEMO_CODE AND AQH.NIELSEN_RADIO_STATION_COMBO_ID = CUME.NIELSEN_RADIO_STATION_COMBO_ID
		WHERE AQH.NIELSEN_RADIO_STATION_COMBO_ID = @STATION_COMBO_ID
		) radiodata
		INNER JOIN @MEDIA_DEMO_TYPE md
			ON radiodata.MEDIA_DEMO_ID = md.ID 
		INNER JOIN dbo.NIELSEN_RADIO_STATION NRS
			ON NRS.NIELSEN_RADIO_MARKET_NUMBER = @NIELSEN_RADIO_MARKET_NUMBER AND NRS.COMBO_ID = radiodata.NIELSEN_RADIO_STATION_COMBO_ID
	--GROUP BY 
	--	md.[Description], NRS.NAME
END
GO

GRANT EXEC ON [advsp_nielsen_radio_audience_metrics] TO PUBLIC
GO