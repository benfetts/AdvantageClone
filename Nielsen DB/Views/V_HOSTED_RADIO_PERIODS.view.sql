CREATE VIEW [dbo].[V_HOSTED_RADIO_PERIODS]
WITH SCHEMABINDING
AS

SELECT c.CODE, com.MARKET_NUMBER, b.NIELSEN_RADIO_PERIOD_ID
FROM dbo.NIELSEN_RADIO_PERIOD b
	INNER JOIN dbo.CLIENT_ORDER co ON SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR AND co.IS_SUSPENDED = 0
	LEFT OUTER JOIN dbo.CLIENT_ORDER_MARKET com ON co.CLIENT_ORDER_ID = com.CLIENT_ORDER_ID AND com.MARKET_NUMBER = b.NIELSEN_RADIO_MARKET_NUMBER
	INNER JOIN dbo.CLIENT c ON co.CLIENT_ID = c.CLIENT_ID
WHERE co.ORDER_TYPE = 'R'
AND (
		co.ALL_MARKETS = 1
	OR
		co.ALL_MARKETS = 0 AND com.MARKET_NUMBER = b.NIELSEN_RADIO_MARKET_NUMBER)
AND
	(
	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND SUBSTRING(b.SHORT_NAME, 1, 2) = '09' AND com.SEPTEMBER = 1)
OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND SUBSTRING(b.SHORT_NAME, 1, 2) = '10' AND com.OCTOBER = 1)
OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND SUBSTRING(b.SHORT_NAME, 1, 2) = '11' AND com.NOVEMBER = 1)
OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND SUBSTRING(b.SHORT_NAME, 1, 2) = '12' AND com.DECEMBER = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND SUBSTRING(b.SHORT_NAME, 1, 2) = '23' AND com.DECEMBER = 1) --Holiday is driven by Decemeber
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '01' AND com.JANUARY = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '02' AND com.FEBRUARY = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '03' AND com.MARCH = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '04' AND com.APRIL = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '05' AND com.MAY = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '06' AND com.JUNE = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '07' AND com.JULY = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '08' AND com.AUGUST = 1)

OR  (SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND SUBSTRING(b.SHORT_NAME, 1, 2) = '16' AND com.FALL_QUARTERLY = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '13' AND com.WINTER_QUARTERLY = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '14' AND com.SPRING_QUARTERLY = 1)
OR	(SUBSTRING(b.SHORT_NAME, 3, 4) BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND SUBSTRING(b.SHORT_NAME, 1, 2) = '15' AND com.SUMMER_QUARTERLY = 1)
	)

