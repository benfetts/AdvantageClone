CREATE FUNCTION [dbo].[advtf_nielsen_universe_spot_tv_research](
	@NIELSEN_MARKET_NUM int
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[ue] bigint NOT NULL,
	[book_year] smallint NOT NULL,
	[book_month] smallint NOT NULL,
	[nielsen_tv_book_id] int NOT NULL,
	[is_metered_market] bit NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @tt TABLE (
		[hh] bigint NOT NULL,
		[c2-5] bigint NOT NULL,
		[c6-11] bigint NOT NULL,
		[m12-14] bigint NOT NULL,
		[m15-17] bigint NOT NULL,
		[m18-20] bigint NOT NULL,
		[m21-24] bigint NOT NULL,
		[m25-34] bigint NOT NULL,
		[m35-49] bigint NOT NULL,
		[m50-54] bigint NOT NULL,
		[m55-64] bigint NOT NULL,
		[m65P] bigint NOT NULL,
		[f12-14] bigint NOT NULL,
		[f15-17] bigint NOT NULL,
		[f18-20] bigint NOT NULL,
		[f21-24] bigint NOT NULL,
		[f25-34] bigint NOT NULL,
		[f35-49] bigint NOT NULL,
		[f50-54] bigint NOT NULL,
		[f55-64] bigint NOT NULL,
		[f65P] bigint NOT NULL,
		[ww] bigint NOT NULL,
		[book_year] smallint NOT NULL,
		[book_month] smallint NOT NULL,
		[nielsen_tv_book_id] int NOT NULL,
		[is_metered_market] bit NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[hh] = a.HOUSEHOLD_UE,
		[c2-5] = a.CHILDREN_2TO5_UE,
		[c6-11] = a.CHILDREN_6TO11_UE,
		[m12-14] = a.MALES_12TO14_UE,
		[m15-17] = a.MALES_15TO17_UE,
		[m18-20] = a.MALES_18TO20_UE,
		[m21-24] = a.MALES_21TO24_UE,
		[m25-34] = a.MALES_25TO34_UE,
		[m35-49] = a.MALES_35TO49_UE,
		[m50-54] = a.MALES_50TO54_UE,
		[m55-64] = a.MALES_55TO64_UE,
		[m65P] = a.MALES_65PLUS_UE,
		[f12-14] = a.FEMALES_12TO14_UE,
		[f15-17] = a.FEMALES_15TO17_UE,
		[f18-20] = a.FEMALES_18TO20_UE,
		[f21-24] = a.FEMALES_21TO24_UE,
		[f25-34] = a.FEMALES_25TO34_UE,
		[f35-49] = a.FEMALES_35TO49_UE,
		[f50-54] = a.FEMALES_50TO54_UE,
		[f55-64] = a.FEMALES_55TO64_UE,
		[f65P] = a.FEMALES_65PLUS_UE,
		[ww] = a.WORKING_WOMEN_UE,
		[book_year] = a.[YEAR],
		[book_month] = a.[MONTH],
		[nielsen_tv_book_id] = b.NIELSEN_TV_BOOK_ID,
		[is_metered_market] = a.IS_METERED_MARKET
	FROM dbo.NIELSEN_TV_UNIVERSE a
		INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM AND a.[YEAR] = b.[YEAR] AND a.[MONTH] = b.[MONTH] 
			AND a.REPORTING_SERVICE = b.REPORTING_SERVICE AND a.EXCLUSION = b.EXCLUSION AND a.ETHNICITY = b.ETHNICITY
			--AND (
			--	(b.COLLECTION_METHOD <> '60' AND CAST(a.[YEAR] as char(4)) + RIGHT('0' + CAST(a.[MONTH] as varchar),2) < '202001')
			--	OR
			--	(CAST(a.[YEAR] as char(4)) + RIGHT('0' + CAST(a.[MONTH] as varchar),2) >= '202001')
			--	)

	WHERE a.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
	
	--INSERT INTO @tt
	--SELECT
	--	[hh] = HOUSEHOLD_INTAB,
	--	[c2-5] = CHILDREN_2TO5_INTAB,
	--	[c6-11] = CHILDREN_6TO11_INTAB,
	--	[m12-14] = MALES_12TO14_INTAB,
	--	[m15-17] = MALES_15TO17_INTAB,
	--	[m18-20] = MALES_18TO20_INTAB,
	--	[m21-24] = MALES_21TO24_INTAB,
	--	[m25-34] = MALES_25TO34_INTAB,
	--	[m35-49] = MALES_35TO49_INTAB,
	--	[m50-54] = MALES_50TO54_INTAB,
	--	[m55-64] = MALES_55TO64_INTAB,
	--	[m65P] = MALES_65PLUS_INTAB,
	--	[f12-14] = FEMALES_12TO14_INTAB,
	--	[f15-17] = FEMALES_15TO17_INTAB,
	--	[f18-20] = FEMALES_18TO20_INTAB,
	--	[f21-24] = FEMALES_21TO24_INTAB,
	--	[f25-34] = FEMALES_25TO34_INTAB,
	--	[f35-49] = FEMALES_35TO49_INTAB,
	--	[f50-54] = FEMALES_50TO54_INTAB,
	--	[f55-64] = FEMALES_55TO64_INTAB,
	--	[f65P] = FEMALES_65PLUS_INTAB,
	--	[ww] = WORKING_WOMEN_INTAB,
	--	[book_year] = [YEAR],
	--	[book_month] = [MONTH],
	--	[nielsen_tv_book_id] = NIELSEN_TV_BOOK_ID,
	--	[is_metered_market] = IS_METERED_MARKET
	--FROM
	--	(
	--	SELECT
	--		HOUSEHOLD_INTAB,
	--		CHILDREN_2TO5_INTAB,
	--		CHILDREN_6TO11_INTAB,
	--		MALES_12TO14_INTAB,
	--		MALES_15TO17_INTAB,
	--		MALES_18TO20_INTAB,
	--		MALES_21TO24_INTAB,
	--		MALES_25TO34_INTAB,
	--		MALES_35TO49_INTAB,
	--		MALES_50TO54_INTAB,
	--		MALES_55TO64_INTAB,
	--		MALES_65PLUS_INTAB,
	--		FEMALES_12TO14_INTAB,
	--		FEMALES_15TO17_INTAB,
	--		FEMALES_18TO20_INTAB,
	--		FEMALES_21TO24_INTAB,
	--		FEMALES_25TO34_INTAB,
	--		FEMALES_35TO49_INTAB,
	--		FEMALES_50TO54_INTAB,
	--		FEMALES_55TO64_INTAB,
	--		FEMALES_65PLUS_INTAB,
	--		WORKING_WOMEN_INTAB,
	--		b.[YEAR],
	--		b.[MONTH],
	--		b.NIELSEN_TV_BOOK_ID,
	--		IS_METERED_MARKET = 0
	--	FROM dbo.NIELSEN_TV_BOOK b 
	--		INNER JOIN dbo.NIELSEN_TV_INTAB i ON b.NIELSEN_TV_BOOK_ID = i.NIELSEN_TV_BOOK_ID
	--		INNER JOIN (
	--					SELECT MIN(INTAB_DATE) as MinDate, NIELSEN_TV_BOOK_ID 
	--					FROM dbo.NIELSEN_TV_INTAB
	--					GROUP BY NIELSEN_TV_BOOK_ID
	--					) MinIntab ON i.INTAB_DATE = MinIntab.MinDate AND i.NIELSEN_TV_BOOK_ID = MinIntab.NIELSEN_TV_BOOK_ID 
	--	WHERE b.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM
	--	AND (b.COLLECTION_METHOD = '60' AND CAST(b.[YEAR] as char(4)) + RIGHT('0' + CAST(b.[MONTH] as varchar),2) < '202001')
	--	GROUP BY 
	--		HOUSEHOLD_INTAB,
	--		CHILDREN_2TO5_INTAB,
	--		CHILDREN_6TO11_INTAB,
	--		MALES_12TO14_INTAB,
	--		MALES_15TO17_INTAB,
	--		MALES_18TO20_INTAB,
	--		MALES_21TO24_INTAB,
	--		MALES_25TO34_INTAB,
	--		MALES_35TO49_INTAB,
	--		MALES_50TO54_INTAB,
	--		MALES_55TO64_INTAB,
	--		MALES_65PLUS_INTAB,
	--		FEMALES_12TO14_INTAB,
	--		FEMALES_15TO17_INTAB,
	--		FEMALES_18TO20_INTAB,
	--		FEMALES_21TO24_INTAB,
	--		FEMALES_25TO34_INTAB,
	--		FEMALES_35TO49_INTAB,
	--		FEMALES_50TO54_INTAB,
	--		FEMALES_55TO64_INTAB,
	--		FEMALES_65PLUS_INTAB,
	--		WORKING_WOMEN_INTAB,
	--		b.[YEAR],
	--		b.[MONTH],
	--		b.NIELSEN_TV_BOOK_ID
	--	) a
	
	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.ue, u.book_year, u.book_month, u.nielsen_tv_book_id, u.is_metered_market
	FROM @tt
	UNPIVOT
	(
		ue
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END
GO
