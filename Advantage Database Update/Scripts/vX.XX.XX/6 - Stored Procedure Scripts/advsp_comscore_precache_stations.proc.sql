CREATE PROCEDURE [dbo].[advsp_comscore_precache_stations]
	@COMSCORE_PRECACHE_MARKET_ID int,
	@PRIMARY_MARKET_NUMBER int
AS

SELECT 
	IsSelected = CAST(CASE WHEN c.COMSCORE_PRECACHE_MARKET_STATION_ID IS NOT NULL THEN 1 ELSE 0 END as bit),
	Number = a.NUMBER,
    CallLetters = a.CALL_LETTERS,
    [Name] = a.[NAME],
    IsCable = CAST(CASE WHEN PRIMARY_MARKET_NUMBER IS NULL THEN 1 ELSE 0 END as bit),
    MarketStationID = c.COMSCORE_PRECACHE_MARKET_STATION_ID
FROM dbo.COMSCORE_TV_STATION a
	INNER JOIN (
				select MIN(NUMBER) as NUMBER, NETWORK_NUMBER 
				from COMSCORE_TV_STATION
				where PRIMARY_MARKET_NUMBER = @PRIMARY_MARKET_NUMBER OR PRIMARY_MARKET_NUMBER is null
				GROUP BY NETWORK_NUMBER) b ON a.NUMBER = b.NUMBER
	LEFT OUTER JOIN dbo.COMSCORE_PRECACHE_MARKET_STATION c ON c.COMSCORE_PRECACHE_MARKET_ID = @COMSCORE_PRECACHE_MARKET_ID AND a.NUMBER = c.STATION_NUMBER 
ORDER BY PRIMARY_MARKET_NUMBER DESC, CALL_LETTERS 
