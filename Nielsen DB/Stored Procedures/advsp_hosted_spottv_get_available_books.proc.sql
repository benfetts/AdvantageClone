CREATE PROCEDURE [dbo].[advsp_hosted_spottv_get_available_books]
	@CLIENT_CODE varchar(6)
AS
BEGIN
	SELECT DISTINCT 
		[NielsenMarketNumber] = b.NIELSEN_MARKET_NUM,
		[Year] = b.[YEAR], 
		[MonthName] = DateName( month , DateAdd( month , b.[MONTH] , -1 ) ),
		[Stream] = b.STREAM,
		[Month] = b.[MONTH],
		[ReportingService] = b.REPORTING_SERVICE
	FROM dbo.CLIENT c
		INNER JOIN dbo.CLIENT_ORDER co ON c.CLIENT_ID = co.CLIENT_ID AND co.IS_SUSPENDED = 0
		LEFT OUTER JOIN dbo.CLIENT_ORDER_MARKET com ON co.CLIENT_ORDER_ID = com.CLIENT_ORDER_ID
		INNER JOIN dbo.NIELSEN_TV_BOOK b ON b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR AND b.VALIDATED = 1
	WHERE co.ORDER_TYPE = 'T'
	AND c.CODE = @CLIENT_CODE
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
END
GO
