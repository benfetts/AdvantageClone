
CREATE PROCEDURE [dbo].[advsp_media_order_print] ( @user_code varchar(100), @order_type varchar(1) )
-- @order_type m=magazine, n=newspaper, i=internet, o=outdoor

AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- Temp table #media_orders----------------------------------
CREATE TABLE #media_orders(
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL)
INSERT INTO #media_orders
SELECT
	[USER_ID],
	ORDER_NBR
FROM dbo.MEDIA_RPT_ORDERS AS rd
WHERE UPPER(rd.[USER_ID]) = UPPER(@user_code)
-- SELECT * FROM #media_orders

---- ==========================================================
---- Temp table #max_rev_seq----------------------------------
--CREATE TABLE #max_rev_seq(
--	ORDER_NBR				int NULL,
--	LINE_NBR				smallint NULL,
--	MAX_REV_NBR				smallint NULL,
--	MAX_SEQ_NBR				smallint)

-- ==========================================================
-- Magazine (new)--------------------------------------------
If UPPER(@order_type) = 'M'
BEGIN
	SELECT h.MEDIA_TYPE,
		h.ORDER_NBR,
		d.LINE_NBR, 
		d.REV_NBR,
		d.EXT_CLOSE_DATE, 
		d.START_DATE, 
		NULL AS END_DATE,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE, 
		d.EDITION_ISSUE,							--magazine/newspaper
		NULL AS SECTION,
		d.MATERIAL,									--magazine/newspaper
		d.[SIZE], 
		d.PRODUCTION_SIZE,							--magazine/newspaper
		d.HEADLINE,									--STARTS HERE 
		NULL AS PRINT_COLUMNS,							--newspaper only 
		NULL AS PRINT_INCHES,								--newspaper only
		NULL AS PRINT_LINES,								--newspaper only
		NULL AS COST_TYPE,								--newspaper/internet
		NULL AS PROJ_IMPRESSIONS,							--internet only
		NULL AS GUARANTEED_IMPRESS,						--internet only
		NULL AS ACT_IMPRESSIONS,						--internet only
		NULL AS URL,										--internet only
		NULL AS TARGET_AUDIENCE,							--internet only
		NULL AS COPY_AREA,								--internet/outdoor
		NULL AS CREATIVE_SIZE,							--internet only
		NULL AS PLACEMENT_1,								--internet only
		NULL AS PLACEMENT_2,								--internet only
		NULL AS COST_RATE,								--internet only
		NULL AS NET_BASE_RATE,							--internet only
		NULL AS GROSS_BASE_RATE,							--internet only
		NULL AS SUB_TYPE,				--internet/outdoor
		NULL AS SUB_TYPE_DESC,			--internet/outdoor
		NULL AS LOCATION,									--outdoor only
		IsNull(d.[COLOR_CHARGE],0) AS [COLOR_CHARGE],	--magazine/newspaper
		d.COLOR_DESC,								--magazine/newspaper
		IsNull(d.[BLEED_AMT],0) AS [BLEED_AMT],			--magazine only
		IsNull(d.[POSITION_AMT],0) AS [POSITION_AMT],	--magazine only
		IsNull(d.[PREMIUM_AMT],0) AS PREMIUM_AMT,		--magazine only
		h.NET_GROSS, 
		d.[FLAT_GROSS] AS FLAT_GROSS,
		d.[FLAT_NET] AS FLAT_NET,
		RATE = CASE h.[NET_GROSS]
			WHEN 1 THEN d.[FLAT_GROSS]
			ELSE d.[FLAT_NET]
		END, 
		UNIT_RATE = CASE h.[NET_GROSS]
			WHEN 1 THEN d.[GROSS_RATE]
			ELSE d.[NET_RATE]
		END, 
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT], 
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		d.NETCHARGE_DESC, 
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
		d.EXT_NET_AMT, 
		d.EXT_GROSS_AMT, 
		d.LINE_TOTAL, 
		d.RATE_CARD_ID AS RATE_CARD, 
		d.RATE_DTL_ID AS RATE_DESC, 
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		c.POSITION_INFO,							--magazine/newspaper 
		c.RATE_INFO,								--magazine/newspaper 
		c.CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		d.AD_NUMBER,
		an.AD_NBR_DESC
	FROM #media_orders AS o 
	JOIN dbo.MAGAZINE_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.MAGAZINE_DETAIL AS d
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.MAGAZINE_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	LEFT JOIN dbo.JOB_LOG AS jl
		ON d.JOB_NUMBER = jl.JOB_NUMBER
	LEFT JOIN dbo.JOB_COMPONENT AS jc
		ON d.JOB_NUMBER = jc.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	LEFT JOIN dbo.AD_NUMBER AS an
		ON d.AD_NUMBER = an.AD_NBR
	WHERE d.ACTIVE_REV = 1 
		AND IsNull(d.[LINE_CANCELLED],0) = 0
END

-- Newspaper (new)--------------------------------------------
If UPPER(@order_type) = 'N'
BEGIN
	SELECT h.MEDIA_TYPE, 
		h.ORDER_NBR,
		d.LINE_NBR, 
		d.REV_NBR,
		d.EXT_CLOSE_DATE, 
		d.START_DATE, 
		NULL AS END_DATE,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE, 
		d.EDITION_ISSUE,
		d.SECTION, 
		d.MATERIAL, 
		d.[SIZE], 
		d.PRODUCTION_SIZE, 
		d.HEADLINE, 
		d.PRINT_COLUMNS,				--newspaper only 
		d.PRINT_INCHES,					--newspaper only
		d.PRINT_LINES,					--newspaper only
		d.COST_TYPE,					--newspaper/internet
		NULL AS PROJ_IMPRESSIONS,							--internet only
		NULL AS GUARANTEED_IMPRESS,						--internet only
		NULL AS ACT_IMPRESSIONS,						--internet only
		NULL AS URL,										--internet only
		NULL AS TARGET_AUDIENCE,							--internet only
		NULL AS COPY_AREA,								--internet/outdoor
		NULL AS CREATIVE_SIZE,							--internet only
		NULL AS PLACEMENT_1,								--internet only
		NULL AS PLACEMENT_2,								--internet only
		NULL AS COST_RATE,								--internet only
		NULL AS NET_BASE_RATE,							--internet only
		NULL AS GROSS_BASE_RATE,							--internet only
		NULL AS SUB_TYPE,				--internet/outdoor
		NULL AS SUB_TYPE_DESC,			--internet/outdoor
		NULL AS LOCATION,									--outdoor only
		IsNull(d.[COLOR_CHARGE],0) AS [COLOR_CHARGE], 
		d.COLOR_DESC,
		0 AS [BLEED_AMT],			--magazine only
		0 AS [POSITION_AMT],	--magazine only
		0 AS [PREMIUM_AMT],		--magazine only
		h.NET_GROSS,
		ISNULL(d.[EXT_GROSS_AMT],0) AS FLAT_GROSS,
		ISNULL(d.[EXT_NET_AMT],0) - IsNull(d.[COLOR_CHARGE],0) AS FLAT_NET, 
		RATE = CASE h.[NET_GROSS]
			WHEN 1 THEN ISNULL(d.[EXT_GROSS_AMT],0)
			ELSE ISNULL(d.[EXT_NET_AMT],0) - IsNull(d.[COLOR_CHARGE],0)
		END, 
		UNIT_RATE = CASE h.[NET_GROSS]
			WHEN 1 THEN ISNULL(d.[GROSS_RATE],0)
			ELSE ISNULL(d.[NET_RATE],0) - IsNull(d.[COLOR_CHARGE],0)
		END, 
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT], 
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		d.NETCHARGE_DESC,
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
		d.EXT_NET_AMT, 
		d.EXT_GROSS_AMT, 
		d.LINE_TOTAL, 
		d.RATE_CARD_ID AS RATE_CARD, 
		d.RATE_DTL_ID AS RATE_DESC, 
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		c.POSITION_INFO, 
		c.RATE_INFO, 
		c.CLOSE_INFO, 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		d.AD_NUMBER,
		an.AD_NBR_DESC
	FROM #media_orders AS o 
	JOIN dbo.NEWSPAPER_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.NEWSPAPER_DETAIL AS d
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.NEWSPAPER_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	LEFT JOIN dbo.JOB_LOG AS jl
		ON d.JOB_NUMBER = jl.JOB_NUMBER
	LEFT JOIN dbo.JOB_COMPONENT AS jc
		ON d.JOB_NUMBER = jc.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	LEFT JOIN dbo.AD_NUMBER AS an
		ON d.AD_NUMBER = an.AD_NBR
	WHERE d.ACTIVE_REV = 1 
		AND IsNull(d.[LINE_CANCELLED],0) = 0
END

-- Internet -----------------------------------------------
If UPPER(@order_type) = 'I'
BEGIN
	SELECT h.MEDIA_TYPE, 
		h.ORDER_NBR,
		d.LINE_NBR, 
		d.REV_NBR,
		d.EXT_CLOSE_DATE, 
		d.START_DATE,
		d.END_DATE, 
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE, 
		NULL AS EDITION_ISSUE,
		NULL AS SECTION,
		NULL AS MATERIAL,
		NULL AS [SIZE],						--d.[CREATIVE_SIZE] AS [SIZE],
		NULL AS PRODUCTION_SIZE,
		d.HEADLINE,
		NULL AS PRINT_COLUMNS,							--newspaper only 
		NULL AS PRINT_INCHES,								--newspaper only
		NULL AS PRINT_LINES,								--newspaper only
		d.COST_TYPE,								--newspaper/internet
		d.PROJ_IMPRESSIONS,					--internet only
		d.GUARANTEED_IMPRESS,				--internet only
		d.ACT_IMPRESSIONS,					--internet only
		d.URL,								--internet only
		d.TARGET_AUDIENCE,					--internet only
		d.COPY_AREA,						--internet only
		d.CREATIVE_SIZE,					--internet only
		d.PLACEMENT_1,						--internet only
		d.PLACEMENT_2,						--internet only
		d.COST_RATE,						--internet only
		d.NET_BASE_RATE,					--internet only
		d.GROSS_BASE_RATE,					--internet only
		d.INTERNET_TYPE AS SUB_TYPE,					--internet only
		t.OD_DESC AS SUB_TYPE_DESC,						--internet/outdoor
		NULL AS LOCATION,									--outdoor only
		0 AS [COLOR_CHARGE],	--magazine/newspaper
		NULL AS COLOR_DESC,								--magazine/newspaper
		0 AS BLEED_AMT,			--magazine only
		0 AS [POSITION_AMT],	--magazine only
		0 AS [PREMIUM_AMT],		--magazine only
		h.NET_GROSS, 
		d.[GROSS_RATE] AS FLAT_GROSS,
		d.[NET_RATE] AS FLAT_NET, 
		RATE = CASE h.[NET_GROSS]
			WHEN 1 THEN d.[GROSS_RATE]
			ELSE d.[NET_RATE]
		END, 
		NULL AS UNIT_RATE,
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT], 
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		NULL AS NETCHARGE_DESC, 
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
		d.EXT_NET_AMT, 
		d.EXT_GROSS_AMT, 
		d.LINE_TOTAL,
		d.RATE_CARD,
		d.RATE_DESC,
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		NULL AS POSITION_INFO,							--magazine/newspaper 
		NULL AS RATE_INFO,								--magazine/newspaper 
		NULL AS CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		d.AD_NUMBER,
		an.AD_NBR_DESC
	FROM #media_orders AS o 
	JOIN dbo.INTERNET_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.INTERNET_DETAIL AS d
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.INTERNET_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	LEFT JOIN dbo.INTERNET_TYPE AS t
		ON d.INTERNET_TYPE = t.OD_CODE
	LEFT JOIN dbo.JOB_LOG AS jl
		ON d.JOB_NUMBER = jl.JOB_NUMBER
	LEFT JOIN dbo.JOB_COMPONENT AS jc
		ON d.JOB_NUMBER = jc.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	LEFT JOIN dbo.AD_NUMBER AS an
		ON d.AD_NUMBER = an.AD_NBR
	WHERE d.ACTIVE_REV = 1 
		AND IsNull(d.[LINE_CANCELLED],0) = 0
END

-- Outdoor -----------------------------------------------
If UPPER(@order_type) = 'O'
BEGIN
	SELECT h.MEDIA_TYPE, 
		h.ORDER_NBR,
		d.LINE_NBR, 
		d.REV_NBR,
		d.EXT_CLOSE_DATE, 
		d.POST_DATE AS START_DATE,
		d.END_DATE, 
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		NULL AS EDITION_ISSUE,
		NULL AS SECTION,
		NULL AS MATERIAL, 
		ad.[SIZE_DESC] AS [SIZE],
		NULL AS PRODUCTION_SIZE,
		d.HEADLINE,
		NULL AS PRINT_COLUMNS,							--newspaper only 
		NULL AS PRINT_INCHES,								--newspaper only
		NULL AS PRINT_LINES,								--newspaper only
		NULL AS COST_TYPE,								--newspaper/internet
		NULL AS PROJ_IMPRESSIONS,							--internet only
		NULL AS GUARANTEED_IMPRESS,						--internet only
		NULL AS ACT_IMPRESSIONS,						--internet only
		NULL AS URL,										--internet only
		NULL AS TARGET_AUDIENCE,							--internet only
		d.COPY_AREA,								--internet/outdoor
		NULL AS CREATIVE_SIZE,							--internet only
		NULL AS PLACEMENT_1,								--internet only
		NULL AS PLACEMENT_2,								--internet only
		NULL AS COST_RATE,								--internet only
		NULL AS NET_BASE_RATE,							--internet only
		NULL AS GROSS_BASE_RATE,							--internet only
		d.OUTDOOR_TYPE AS SUB_TYPE,				--internet/outdoor
		t.OD_DESC AS SUB_TYPE_DESC,						--internet/outdoor
		d.LOCATION,									--outdoor only 
		0 AS [COLOR_CHARGE],	--magazine/newspaper
		NULL AS COLOR_DESC,								--magazine/newspaper
		0 AS [BLEED_AMT],			--magazine only
		0 AS [POSITION_AMT],	--magazine only
		0 AS [PREMIUM_AMT],		--magazine only
		h.NET_GROSS, 
		d.[GROSS_RATE] AS FLAT_GROSS,
		d.[NET_RATE] AS FLAT_NET, 
		RATE = CASE h.[NET_GROSS]
			WHEN 1 THEN d.[GROSS_RATE]
			ELSE d.[NET_RATE]
		END,
		NULL AS UNIT_RATE, 
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT], 
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		NULL AS NETCHARGE_DESC,
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
		d.EXT_NET_AMT, 
		d.EXT_GROSS_AMT, 
		d.LINE_TOTAL,
		d.RATE_CARD,
		d.RATE_DESC,
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		NULL AS POSITION_INFO,							--magazine/newspaper 
		NULL AS RATE_INFO,								--magazine/newspaper 
		NULL AS CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		d.AD_NUMBER,
		an.AD_NBR_DESC
	FROM #media_orders AS o 
	JOIN dbo.OUTDOOR_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.OUTDOOR_DETAIL AS d
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.OUTDOOR_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	LEFT JOIN dbo.OUTDOOR_TYPE AS t
		ON d.OUTDOOR_TYPE = t.OD_CODE
	LEFT JOIN dbo.AD_SIZE AS ad
		ON @order_type = ad.MEDIA_TYPE
		AND d.[SIZE] = ad.SIZE_CODE
	LEFT JOIN dbo.JOB_LOG AS jl
		ON d.JOB_NUMBER = jl.JOB_NUMBER
	LEFT JOIN dbo.JOB_COMPONENT AS jc
		ON d.JOB_NUMBER = jc.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	LEFT JOIN dbo.AD_NUMBER AS an
		ON d.AD_NUMBER = an.AD_NBR
	WHERE d.ACTIVE_REV = 1 
		AND IsNull(d.[LINE_CANCELLED],0) = 0
END


END
