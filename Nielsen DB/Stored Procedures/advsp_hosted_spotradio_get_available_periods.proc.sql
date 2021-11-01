CREATE PROCEDURE [dbo].[advsp_hosted_spotradio_get_available_periods]
	@CLIENT_CODE varchar(6)
AS
BEGIN
	SELECT DISTINCT
		[NielsenRadioMarketNumber] = b.NIELSEN_RADIO_MARKET_NUMBER,
		[Year] = CAST( SUBSTRING(b.SHORT_NAME, 3, 4) as smallint),
		[Month] = CAST( SUBSTRING(b.SHORT_NAME, 1, 2) as smallint),
		[Source] = b.[SOURCE],
		[Name] = b.[NAME]
	FROM dbo.NIELSEN_RADIO_PERIOD b
		INNER JOIN dbo.CLIENT_ORDER co ON SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND co.ALL_MARKETS = 0 AND co.IS_SUSPENDED = 0 AND b.SOURCE IN (0, 1) AND b.VALIDATED = 1
		INNER JOIN dbo.CLIENT_ORDER_MARKET com ON co.CLIENT_ORDER_ID = com.CLIENT_ORDER_ID AND com.MARKET_NUMBER = b.NIELSEN_RADIO_MARKET_NUMBER
		INNER JOIN dbo.CLIENT c ON co.CLIENT_ID = c.CLIENT_ID AND c.CODE = @CLIENT_CODE
	WHERE 
		(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '09' AND com.SEPTEMBER = 1)
		OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '10' AND com.OCTOBER = 1)
		OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '11' AND com.NOVEMBER = 1)
		OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '12' AND com.DECEMBER = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '23' AND com.DECEMBER = 1) --Holiday is driven by Decemeber
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '01' AND com.JANUARY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '02' AND com.FEBRUARY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '03' AND com.MARCH = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '04' AND com.APRIL = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '05' AND com.MAY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '06' AND com.JUNE = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '07' AND com.JULY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '08' AND com.AUGUST = 1)

		OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '16' AND com.FALL_QUARTERLY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '13' AND com.WINTER_QUARTERLY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '14' AND com.SPRING_QUARTERLY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '15' AND com.SUMMER_QUARTERLY = 1)
		--?	waiting on Nielsen for these -- 05/02/2018 made our own assumptions as to which 'shortnames' these correspond
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '17' AND com.SPRING_QUARTERLY = 1) --AND com.WINTER_SPRING_ETHNIC_QUARTERLY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '18' AND com.SPRING_QUARTERLY = 1) --AND com.FALL_WINTER_SPRING_ETHNIC_QUARTERLY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '19' AND com.SUMMER_QUARTERLY = 1) --AND com.SUMMER_FALL_ETHNIC_SURVEY = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '21' AND com.SPRING_QUARTERLY = 1) --AND com.SPRING_SMALL_MARKET = 1)
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '22' AND com.FALL_QUARTERLY = 1) --AND com.FALL_SMALL_MARKET = 1)

	UNION

	SELECT
		[NielsenRadioMarketNumber] = b.NIELSEN_RADIO_MARKET_NUMBER,
		[Year] = CAST( SUBSTRING(b.SHORT_NAME, 3, 4) as smallint),
		[Month] = CAST( SUBSTRING(b.SHORT_NAME, 1, 2) as smallint),
		[Source] = b.[SOURCE],
		[Name] = b.[NAME]
	FROM dbo.NIELSEN_RADIO_PERIOD b
		INNER JOIN dbo.CLIENT_ORDER co ON SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND co.ALL_MARKETS = 1 AND co.IS_SUSPENDED = 0 AND b.SOURCE IN (0, 1) AND b.VALIDATED = 1
		INNER JOIN dbo.CLIENT c ON co.CLIENT_ID = c.CLIENT_ID AND c.CODE = @CLIENT_CODE
	WHERE 
		(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND CAST( SUBSTRING(b.SHORT_NAME, 1, 2) as smallint) IN (9, 10, 11, 12, 23, 16, 22))
		OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND CAST( SUBSTRING(b.SHORT_NAME, 1, 2) as smallint) IN (1, 2, 3, 4, 5, 6, 7, 8, 13, 14, 15, 17, 18, 19, 21))
	
END
GO
