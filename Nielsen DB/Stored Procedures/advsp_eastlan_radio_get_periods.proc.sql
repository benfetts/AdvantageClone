CREATE PROCEDURE [dbo].[advsp_eastlan_radio_get_periods]
AS 
BEGIN
	
	SELECT
		[NielsenRadioPeriodID] = b.NIELSEN_RADIO_PERIOD_ID,
		[NielsenRadioMarketNumber] = b.NIELSEN_RADIO_MARKET_NUMBER,
		[Year] = CAST( SUBSTRING(b.SHORT_NAME, 3, 4) as smallint),
		[Month] = CAST( SUBSTRING(b.SHORT_NAME, 1, 2) as smallint),
		[Source] = b.[SOURCE] 
	FROM dbo.NIELSEN_RADIO_PERIOD b
	WHERE b.[SOURCE] = 1

END
GO

GRANT EXEC ON [advsp_eastlan_radio_get_periods] TO PUBLIC
GO