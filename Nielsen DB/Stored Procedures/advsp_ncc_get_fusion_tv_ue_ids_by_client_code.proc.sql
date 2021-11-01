CREATE PROCEDURE [dbo].[advsp_ncc_get_fusion_tv_ue_ids_by_client_code]
	@CLIENT_CODE varchar(6)
AS 
BEGIN
	
	SELECT DISTINCT
		[ID] = b.NCC_TV_FUSION_UE_ID,
        [NielsenMarketNumber] = b.NIELSEN_MARKET_NUM,
        [Year] = b.[YEAR],
        [Month] = b.[MONTH],
        [Geo] = b.GEO,
        [Stream] = b.STREAM,
        [Household] = b.HOUSEHOLD_UE,
        [Children2to5] = b.CHILDREN_2TO5_UE,
        [Children6to11] = b.CHILDREN_6TO11_UE,
        [Males12to17] = b.MALES_12TO17_UE,
        [Males18to20] = b.MALES_18TO20_UE,
        [Males21to24] = b.MALES_21TO24_UE,
        [Males25to34] = b.MALES_21TO24_UE,
        [Males35to49] = b.MALES_35TO49_UE,
        [Males50to54] = b.MALES_50TO54_UE,
        [Males55to64] = b.MALES_55TO64_UE,
        [Males65Plus] = b.MALES_65PLUS_UE,
        [Females12to17] = b.FEMALES_12TO17_UE,
        [Females18to20] = b.FEMALES_18TO20_UE,
        [Females21to24] = b.FEMALES_21TO24_UE,
        [Females25to34] = b.FEMALES_25TO34_UE,
        [Females35to49] = b.FEMALES_35TO49_UE,
        [Females50to54] = b.FEMALES_50TO54_UE,
        [Females55to64] = b.FEMALES_55TO64_UE,
        [Females65Plus] = b.FEMALES_65PLUS_UE 
	FROM dbo.NCC_TV_FUSION_UE b
		INNER JOIN dbo.CLIENT_ORDER co ON b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR AND co.ALL_MARKETS = 0 AND co.IS_SUSPENDED = 0
		INNER JOIN dbo.CLIENT_ORDER_MARKET com ON co.CLIENT_ORDER_ID = com.CLIENT_ORDER_ID AND com.MARKET_NUMBER = b.NIELSEN_MARKET_NUM
		INNER JOIN dbo.CLIENT c ON co.CLIENT_ID = c.CLIENT_ID AND c.CODE = @CLIENT_CODE AND c.IS_NCC_SUBSCRIBED = 1
	WHERE 
		((b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND b.[MONTH] = 9 AND com.SEPTEMBER = 1)
	OR  (b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND b.[MONTH] = 10 AND com.OCTOBER = 1)
	OR  (b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND b.[MONTH] = 11 AND com.NOVEMBER = 1)
	OR  (b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND b.[MONTH] = 12 AND com.DECEMBER = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 1 AND com.JANUARY = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 2 AND com.FEBRUARY = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 3 AND com.MARCH = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 4 AND com.APRIL = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 5 AND com.MAY = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 6 AND com.JUNE = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 7 AND com.JULY = 1)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] = 8 AND com.AUGUST = 1))
	AND
		(
			(c.FUSION_DIARY_MARKETS = 1 AND EXISTS(SELECT 1 FROM dbo.NIELSEN_TV_BOOK ntb 
													WHERE ntb.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM
													AND ntb.[MONTH] = b.[MONTH]
													AND ntb.[YEAR] = b.[YEAR]
													AND ntb.COLLECTION_METHOD NOT IN ('2','3')
													AND ntb.REPORTING_SERVICE = '1' AND ntb.EXCLUSION = '' AND ntb.ETHNICITY = ''))
		OR
			(c.FUSION_METERED_MARKETS = 1 AND EXISTS(SELECT 1 FROM dbo.NIELSEN_TV_BOOK ntb 
													WHERE ntb.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM
													AND ntb.[MONTH] = b.[MONTH]
													AND ntb.[YEAR] = b.[YEAR]
													AND ntb.COLLECTION_METHOD IN ('2','3')
													AND ntb.REPORTING_SERVICE = '1' AND ntb.EXCLUSION = '' AND ntb.ETHNICITY = ''))
		)

	UNION

	SELECT
		[ID] = b.NCC_TV_FUSION_UE_ID,
        [NielsenMarketNumber] = b.NIELSEN_MARKET_NUM,
        [Year] = b.[YEAR],
        [Month] = b.[MONTH],
        [Geo] = b.GEO,
        [Stream] = b.STREAM,
        [Household] = b.HOUSEHOLD_UE,
        [Children2to5] = b.CHILDREN_2TO5_UE,
        [Children6to11] = b.CHILDREN_6TO11_UE,
        [Males12to17] = b.MALES_12TO17_UE,
        [Males18to20] = b.MALES_18TO20_UE,
        [Males21to24] = b.MALES_21TO24_UE,
        [Males25to34] = b.MALES_21TO24_UE,
        [Males35to49] = b.MALES_35TO49_UE,
        [Males50to54] = b.MALES_50TO54_UE,
        [Males55to64] = b.MALES_55TO64_UE,
        [Males65Plus] = b.MALES_65PLUS_UE,
        [Females12to17] = b.FEMALES_12TO17_UE,
        [Females18to20] = b.FEMALES_18TO20_UE,
        [Females21to24] = b.FEMALES_21TO24_UE,
        [Females25to34] = b.FEMALES_25TO34_UE,
        [Females35to49] = b.FEMALES_35TO49_UE,
        [Females50to54] = b.FEMALES_50TO54_UE,
        [Females55to64] = b.FEMALES_55TO64_UE,
        [Females65Plus] = b.FEMALES_65PLUS_UE 
	FROM dbo.NCC_TV_FUSION_UE b
		INNER JOIN dbo.CLIENT_ORDER co ON b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR AND co.ALL_MARKETS = 1 AND co.IS_SUSPENDED = 0
		INNER JOIN dbo.CLIENT c ON co.CLIENT_ID = c.CLIENT_ID AND c.CODE = @CLIENT_CODE AND c.IS_NCC_SUBSCRIBED = 1
	WHERE 
		((b.[YEAR] BETWEEN co.START_YEAR AND co.END_YEAR - 1 AND b.[MONTH] >= 9)
	OR	(b.[YEAR] BETWEEN co.START_YEAR + 1 AND co.END_YEAR AND b.[MONTH] <= 8))
	AND
		(
			(c.FUSION_DIARY_MARKETS = 1 AND EXISTS(SELECT 1 FROM dbo.NIELSEN_TV_BOOK ntb 
													WHERE ntb.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM
													AND ntb.[MONTH] = b.[MONTH]
													AND ntb.[YEAR] = b.[YEAR]
													AND ntb.COLLECTION_METHOD NOT IN ('2','3')
													AND ntb.REPORTING_SERVICE = '1' AND ntb.EXCLUSION = '' AND ntb.ETHNICITY = ''))
		OR
			(c.FUSION_METERED_MARKETS = 1 AND EXISTS(SELECT 1 FROM dbo.NIELSEN_TV_BOOK ntb 
													WHERE ntb.NIELSEN_MARKET_NUM = b.NIELSEN_MARKET_NUM
													AND ntb.[MONTH] = b.[MONTH]
													AND ntb.[YEAR] = b.[YEAR]
													AND ntb.COLLECTION_METHOD IN ('2','3')
													AND ntb.REPORTING_SERVICE = '1' AND ntb.EXCLUSION = '' AND ntb.ETHNICITY = ''))
		)
	
END
GO
