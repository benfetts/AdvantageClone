CREATE PROCEDURE [dbo].[advsp_media_spot_tv_stations]
	@NIELSEN_MARKET_NUM int,
	@NIELSEN_STATION_IDs varchar(max)
AS 
BEGIN
	
	SELECT
		stations.ID,
		stations.Station,
		stations.[Type],
		stations.Affiliation,
		stations.Channel,
		IsSelected = CAST(CASE WHEN IDs.items IS NULL THEN 0 ELSE 1 END as bit),
		stations.StationCode
	FROM
		(
		SELECT
			[ID] = NIELSEN_TV_STATION_ID,
			[Station] = CALL_LETTERS,
			[Type] = CASE WHEN SOURCE_TYPE = 'B' THEN 'Bcst'
						WHEN SOURCE_TYPE = 'C' THEN 'Cbl'
						END,
			[Affiliation] = CASE WHEN SOURCE_TYPE = 'B' THEN AFFILIATION 
							WHEN SOURCE_TYPE = 'C' THEN CABLE_NAME
							END,
			[Channel] = CASE WHEN SOURCE_TYPE = 'B' THEN CHANNEL_NUM END,
			[StationCode] = STATION_CODE
		FROM dbo.NIELSEN_TV_STATION 
		WHERE NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
		AND (
				HOME_MARKET_NUM IS NULL 
			OR 
				HOME_MARKET_NUM = @NIELSEN_MARKET_NUM
			)

		UNION

		SELECT
			[ID] = NIELSEN_TV_STATION_ID,
			[Station] = CALL_LETTERS,
			[Type] = 'Spill',
			[Affiliation] = AFFILIATION,
			[Channel] = NULL,
			[StationCode] = STATION_CODE
		FROM dbo.NIELSEN_TV_STATION 
		WHERE NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
		AND HOME_MARKET_NUM IS NOT NULL 
		AND HOME_MARKET_NUM <> @NIELSEN_MARKET_NUM
		
	) stations
		LEFT OUTER JOIN (SELECT items FROM dbo.udf_split_list(@NIELSEN_STATION_IDs, ',')) IDs ON stations.ID = IDs.items
	ORDER BY 3, 2
END
GO

GRANT EXEC ON [advsp_media_spot_tv_stations] TO PUBLIC
GO