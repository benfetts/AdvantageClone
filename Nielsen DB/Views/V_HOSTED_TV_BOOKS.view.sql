CREATE VIEW [dbo].[V_HOSTED_TV_BOOKS]
WITH SCHEMABINDING
AS
SELECT DISTINCT c.CODE, b.NIELSEN_MARKET_NUM, b.NIELSEN_TV_BOOK_ID 
FROM dbo.CLIENT c
	INNER JOIN dbo.CLIENT_ORDER co ON c.CLIENT_ID = co.CLIENT_ID AND co.IS_SUSPENDED = 0
	LEFT OUTER JOIN dbo.CLIENT_ORDER_MARKET com ON co.CLIENT_ORDER_ID = com.CLIENT_ORDER_ID
	INNER JOIN dbo.NIELSEN_TV_BOOK b ON b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR
WHERE co.ORDER_TYPE = 'T'
AND (
		co.ALL_MARKETS = 1 
	OR 
		(
			(co.ALL_MARKETS = 0 AND com.MARKET_NUMBER = b.NIELSEN_MARKET_NUM)
		AND
			(
				(com.SEPTEMBER = 1 AND b.[MONTH] = 9 AND b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1)
			OR	(com.OCTOBER = 1 AND b.[MONTH] = 10 AND b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1)
			OR	(com.NOVEMBER = 1 AND b.[MONTH] = 11 AND b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1)
			OR	(com.DECEMBER = 1 AND b.[MONTH] = 12 AND b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1)
			OR	(com.JANUARY = 1 AND b.[MONTH] = 1 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			OR	(com.FEBRUARY = 1 AND b.[MONTH] = 2 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			OR	(com.MARCH = 1 AND b.[MONTH] = 3 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			OR	(com.APRIL = 1 AND b.[MONTH] = 4 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			OR	(com.MAY = 1 AND b.[MONTH] = 5 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			OR	(com.JUNE = 1 AND b.[MONTH] = 6 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			OR	(com.JULY = 1 AND b.[MONTH] = 7 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			OR	(com.AUGUST = 1 AND b.[MONTH] = 8 AND b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR)
			) 
		)
	)
AND (
			(UPPER(b.ETHNICITY) = '' AND co.ETHNICITY = 0)
		OR	(UPPER(b.ETHNICITY) = 'HISP' AND co.ETHNICITY = 1)
		OR	(UPPER(b.ETHNICITY) = 'AF-AM' AND co.ETHNICITY = 2)
		OR	(UPPER(b.ETHNICITY) = 'ASIAN' AND co.ETHNICITY = 3)
		)
	AND (
			(UPPER(b.EXCLUSION) = '' AND co.IS_OLYMPIC = 0)
		OR	(UPPER(b.EXCLUSION) = 'EX' AND co.IS_OLYMPIC = 1)
		)
