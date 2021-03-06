CREATE PROCEDURE [dbo].[advsp_comscore_cache_results]
	@COMSCORE_PRECACHE_MARKET_ID int
AS
BEGIN

	DECLARE @market_number int,
            @market_desc varchar(100)

	SELECT @market_number = m.COMSCORE_NEW_MARKET_NUMBER, @market_desc = m.MARKET_DESC
	FROM dbo.COMSCORE_PRECACHE_MARKET a
		INNER JOIN dbo.MARKET m on a.MARKET_CODE = m.MARKET_CODE 
	WHERE a.COMSCORE_PRECACHE_MARKET_ID = @COMSCORE_PRECACHE_MARKET_ID 

	SELECT 
		IsCached = CAST(CASE WHEN cch.COMSCORE_TV_BOOK_ID IS NOT NULL THEN 1 ELSE 0 END as bit),
        Market = @market_desc,
		[Year] = ctv.[YEAR],
		[Month] = ctv.[MONTH],
		[Stream] = ctv.[STREAM],
		[CallLetters] =cts.CALL_LETTERS,
		[StationName] = cts.[NAME],
		[Demographic] = md.[DESCRIPTION],
		[ComscoreCacheHeaderID] = cch.COMSCORE_CACHE_HEADER_ID,
		[Warning] = cch.WARNING
	INTO #precached
	FROM dbo.COMSCORE_PRECACHE_MARKET_BOOK cpmb
		INNER JOIN dbo.COMSCORE_TV_BOOK ctv ON cpmb.COMSCORE_PRECACHE_MARKET_ID = @COMSCORE_PRECACHE_MARKET_ID AND ctv.COMSCORE_TV_BOOK_ID = cpmb.COMSCORE_TV_BOOK_ID 
		INNER JOIN dbo.COMSCORE_PRECACHE_MARKET_STATION cpms ON cpms.COMSCORE_PRECACHE_MARKET_ID = cpmb.COMSCORE_PRECACHE_MARKET_ID 
		INNER JOIN dbo.COMSCORE_TV_STATION cts ON cts.NUMBER = cpms.STATION_NUMBER 
		INNER JOIN dbo.COMSCORE_PRECACHE_MARKET_DEMOGRAPHIC cpmd ON cpmd.COMSCORE_PRECACHE_MARKET_ID = cpmb.COMSCORE_PRECACHE_MARKET_ID 
		INNER JOIN dbo.MEDIA_DEMO md ON md.COMSCORE_DEMO_NUMBER = cpmd.COMSCORE_DEMO_NUMBER 
		LEFT OUTER JOIN dbo.COMSCORE_CACHE_HEADER cch ON cch.COMSCORE_TV_BOOK_ID = ctv.COMSCORE_TV_BOOK_ID AND cch.MARKET_NUMBER = @market_number 
													 AND cch.STATION_NUMBER = cts.NUMBER AND cch.DEMO_NUMBER = md.COMSCORE_DEMO_NUMBER 

	SELECT * FROM #precached 
	UNION ALL
	SELECT
		IsCached = CAST(1 as bit),
        Market = @market_desc,
		[Year] = ctv.[YEAR],
		[Month] = ctv.[MONTH],
		[Stream] = ctv.[STREAM],
		[CallLetters] =cts.CALL_LETTERS,
		[StationName] = cts.[NAME],
		[Demographic] = md.[DESCRIPTION],
		[ComscoreCacheHeaderID] = cch.COMSCORE_CACHE_HEADER_ID,
		[Warning] = cch.WARNING
	FROM dbo.COMSCORE_CACHE_HEADER cch
		INNER JOIN dbo.COMSCORE_TV_BOOK ctv ON cch.COMSCORE_TV_BOOK_ID = ctv.COMSCORE_TV_BOOK_ID
		INNER JOIN dbo.COMSCORE_TV_STATION cts ON cts.NUMBER = cch.STATION_NUMBER 
		INNER JOIN dbo.MEDIA_DEMO md ON md.COMSCORE_DEMO_NUMBER = cch.DEMO_NUMBER  
	WHERE cch.MARKET_NUMBER = @market_number 
	AND cch.COMSCORE_CACHE_HEADER_ID NOT IN (SELECT ComscoreCacheHeaderID FROM #precached WHERE ComscoreCacheHeaderID IS NOT NULL)
	ORDER BY 2 DESC, 3, 4, 5, 7 

    DROP TABLE #precached

END
GO
