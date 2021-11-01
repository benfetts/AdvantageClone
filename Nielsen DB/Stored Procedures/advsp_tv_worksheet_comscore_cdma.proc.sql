CREATE PROCEDURE [dbo].[advsp_tv_worksheet_comscore_cdma] (
	@NIELSEN_MARKET_NUM int,
	@ComscoreStationCode int,
	@NCCTVSyscodeID int,
	@Year smallint,
	@Month smallint)
AS
BEGIN

	DECLARE @RATINGS_AIUE int
	DECLARE @STATION_CODE int

	CREATE TABLE #CARRIAGE (
		[station_code]						int NOT NULL,
		[hh_carriage_ue]					int NOT NULL
	)

	CREATE TABLE #AIUE (
		[station_code]						int NOT NULL,
		[hh_aiue]					int NOT NULL
	)
	
	SELECT
		@STATION_CODE = ISNULL(NCCTC.STATION_CODE, 0)
	FROM
		dbo.NCC_TV_CABLENET NCCTC
	WHERE
		NCCTC.COMSCORE_STATION_CODE = @ComscoreStationCode

	INSERT INTO #CARRIAGE 
	SELECT 
		u.STATION_CODE, HH_CARRIAGE_UE 
	FROM 
		dbo.NCC_TV_CARRIAGE_UE u
		INNER JOIN dbo.NCC_TV_CARRIAGE_UE_LOG cl ON u.NCC_TV_CARRIAGE_UE_LOG_ID = cl.NCC_TV_CARRIAGE_UE_LOG_ID 
													AND cl.VALIDATED = 1
	WHERE 
		cl.[YEAR] = @Year 
		AND cl.[MONTH] = @Month
		AND u.STATION_CODE = @STATION_CODE
		AND u.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM

	INSERT INTO #AIUE
	SELECT 
		u.STATION_CODE, HH_AIUE
	FROM 
		dbo.NCC_TV_AI_UE u
		INNER JOIN dbo.NCC_TV_AI_UE_LOG ul ON u.NCC_TV_AI_UE_LOG_ID = ul.NCC_TV_AI_UE_LOG_ID 
											  AND ul.VALIDATED = 1
		INNER JOIN dbo.NCC_TV_SYSCODE ts ON u.SYSCODE = ts.SYSCODE 
											AND ts.NCC_TV_SYSCODE_ID = @NCCTVSyscodeID
	WHERE
		ul.[YEAR] = @Year 
		AND ul.[MONTH] = @Month
		AND  u.STATION_CODE = @STATION_CODE

	SELECT 
		@RATINGS_AIUE = HH_AIUE
	FROM 
		dbo.NCC_TV_AI_UE u
		INNER JOIN dbo.NCC_TV_AI_UE_LOG ul ON u.NCC_TV_AI_UE_LOG_ID = ul.NCC_TV_AI_UE_LOG_ID 
											  AND ul.VALIDATED = 1
		INNER JOIN dbo.NCC_TV_SYSCODE ts ON u.SYSCODE = ts.SYSCODE 
											AND ts.NCC_TV_SYSCODE_ID = @NCCTVSyscodeID
	WHERE
		ul.[YEAR] = @Year 
		AND ul.[MONTH] = @Month
		AND u.STATION_CODE = 0 

	SELECT
		StationCode = ISNULL(a.station_code, 0),
		AIUE = ISNULL(a.hh_aiue, 0),
		CarraigeUE = ISNULL(c.hh_carriage_ue, 0),
		UEFactor = ISNULL(CASE WHEN c.hh_carriage_ue = 0 THEN 0 ELSE CAST(a.hh_aiue as decimal) / CAST(c.hh_carriage_ue as decimal) END, 0),
		RatingsAIUE = ISNULL(@RATINGS_AIUE, 0)
	FROM 
		#AIUE a
		LEFT OUTER JOIN #CARRIAGE c ON a.station_code = c.station_code

	DROP TABLE #CARRIAGE
	DROP TABLE #AIUE

END
GO