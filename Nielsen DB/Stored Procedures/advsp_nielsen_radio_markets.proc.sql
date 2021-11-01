CREATE PROCEDURE advsp_nielsen_radio_markets
	@ExcludeMarkets AS VARCHAR(MAX),
	@Ethnicity AS SMALLINT -- 0=Regular, 1=Hispanic, 2=Black
AS

SELECT
	Number = CAST(Number as int),
	[Name]
FROM (
	SELECT
		[Name] = MARKET_DESC,
		[Number] = NIELSEN_RADIO_CODE
	FROM dbo.NIELSEN_MARKET 
	WHERE (NIELSEN_RADIO_CODE IS NOT NULL AND NIELSEN_RADIO_CODE <> '')
	AND (@Ethnicity = 0 OR @Ethnicity IS NULL)

	UNION 

	SELECT
		[Name] = MARKET_DESC + ' - Black',
		[Number] = NIELSEN_BLACK_RADIO_CODE
	FROM dbo.NIELSEN_MARKET 
	WHERE (NIELSEN_BLACK_RADIO_CODE IS NOT NULL AND NIELSEN_BLACK_RADIO_CODE <> '')
	AND (@Ethnicity = 2 OR @Ethnicity IS NULL)

	UNION 

	SELECT
		[Name] = MARKET_DESC + ' - Hispanic',
		[Number] = NIELSEN_HISPANIC_RADIO_CODE
	FROM dbo.NIELSEN_MARKET 
	WHERE (NIELSEN_HISPANIC_RADIO_CODE IS NOT NULL AND NIELSEN_HISPANIC_RADIO_CODE <> '')
	AND (@Ethnicity = 1 OR @Ethnicity IS NULL)

) allmarkets
WHERE
	@ExcludeMarkets IS NULL
OR	(@ExcludeMarkets IS NOT NULL AND CAST(Number as int) NOT IN (SELECT items FROM dbo.udf_split_list(@ExcludeMarkets, ',')))
ORDER BY 2
GO

GRANT EXEC ON advsp_nielsen_radio_markets TO PUBLIC
GO