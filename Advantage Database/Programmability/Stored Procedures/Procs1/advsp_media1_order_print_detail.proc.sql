--insert the next (3) statements at the top of the script while debugging
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_print_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_media1_order_print_detail]
GO


CREATE PROCEDURE [dbo].[advsp_media1_order_print_detail] ( @user_code varchar(100), @app_type varchar(1) = 'O' )
-- advsp_media1_order_print_detail
-- #00 02/20/13 - version history lost (JP)
-- #01 02/20/13 - added PRINT_QUANTITY for internet and changed newspaper to PRINT_LINES
-- #02 06/04/13 - added blackplate info for newspaper
-- #03 06/20/13 - added code to bypass/streamline #order_inv_max_rev_seq as appropriate
-- #04 01/11/14 - populate END_DATE for newspaper (2265-1) and magazine
-- #05 03/20/14 - reverted PRINT_QUANTITY back for newspaper (see #01)
-- #06 03/17/15 - v670 - replaced ORDER_NBR (incorrect) with AR_INV_NBR in WHERE CLAUSE (draft uses @app_type = "O")
-- #07 07/31/15 - v670 - fixed outdoor join to table OUTDOOR_SIZE instead of AD_SIZE (3765-25)
-- #08 10/27/15 - v660 fixed #07, join should be to both AD_SIZE (new) and OUTDOOR_SIZE (old (735-1933 and 4041-1)

-- @app_type; Order = "O", Invoice = "I"

AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	ACTIVE_REV						smallint NULL,
	EXT_CLOSE_DATE					smalldatetime NULL, 
	[START_DATE]					smalldatetime NULL,
	END_DATE						smalldatetime NULL, 
	DATE_TO_BILL					smalldatetime NULL, 
	CLOSE_DATE						smalldatetime NULL, 
	MATL_CLOSE_DATE					smalldatetime NULL, 
	EXT_MATL_DATE					smalldatetime NULL, 
	MAT_COMP						datetime NULL,
	SIZE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EDITION_ISSUE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SECTION							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MATERIAL						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[SIZE]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRODUCTION_SIZE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	HEADLINE						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRINT_COLUMNS					decimal(6,2) NULL,
	PRINT_INCHES					decimal(6,2) NULL,
	PRINT_LINES						decimal(11,2) NULL,
	COST_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PROJ_IMPRESSIONS				int NULL,
	GUARANTEED_IMPRESS				int NULL,
	ACT_IMPRESSIONS					int NULL,
	URL								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TARGET_AUDIENCE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COPY_AREA						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CREATIVE_SIZE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PLACEMENT_1						varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PLACEMENT_2						varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COST_RATE						decimal(16,4) NULL,
	NET_BASE_RATE					decimal(16,4) NULL,
	GROSS_BASE_RATE					decimal(16,4) NULL,
	SUB_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SUB_TYPE_DESC					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LOCATION						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE_CARD						int NULL,
	RATE_DESC						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER						int NULL,
	JOB_DESC						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,	 
	JOB_COMPONENT_NBR				smallint NULL, 
	JOB_COMP_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL,
	NON_BILL_FLAG					smallint NULL,
	RECONCILE_LINE					smallint NULL,
	DO_NOT_BILL						smallint NULL,
	INSTRUCTIONS					text, 
	ORDER_COPY						text, 
	POSITION_INFO					text,
	RATE_INFO						text,
	CLOSE_INFO						text,
	MISC_INFO						text, 
	MATL_NOTES						text, 
	IN_HOUSE_CMTS					text,
	AD_NUMBER						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AD_NBR_DESC						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRINTED							smallint NULL,
	RATE							decimal(16,4) NULL,
	NET_RATE						decimal(16,4) NULL,
	GROSS_RATE						decimal(16,4) NULL,
	FLAT_NET						decimal(15,4) NULL, 
	FLAT_GROSS						decimal(15,4) NULL, 
	EXT_NET_AMT						decimal(15,2) NULL,
	EXT_GROSS_AMT					decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT_AMT					decimal(15,2) NULL,
	DISCOUNT_DESC					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	STATE_AMT						decimal(15,2) NULL,
	COUNTY_AMT						decimal(15,2) NULL,
	CITY_AMT						decimal(15,2) NULL,
	NON_RESALE_AMT					decimal(15,2) NULL,
	NETCHARGE						decimal(15,2) NULL,
	NETCHARGE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADDL_CHARGE						decimal(15,2) NULL,
	ADDL_CHARGE_DESC				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PROD_CHARGE						decimal(15,2) NULL,
	PROD_DESC						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COLOR_CHARGE					decimal(15,3) NULL,
	COLOR_DESC						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BLEED_PCT						decimal(7,3) NULL,
	BLEED_AMT						decimal(15,2) NULL,
	POSITION_PCT					decimal(7,3) NULL,
	POSITION_AMT					decimal(15,2) NULL,
	PREMIUM_PCT						decimal(7,3) NULL,
	PREMIUM_AMT						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_TYPE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_SEQ						smallint NULL,
	MARKUP_PCT						decimal(7,3) NULL, 
	COMM_PCT						decimal(7,3) NULL, 
	REBATE_PCT						decimal(7,3) NULL,
	EST_NBR							int NULL,
	EST_LINE_NBR					smallint NULL,
	EST_REV_NBR						smallint NULL,
	CIRCULATION						int NULL,
	PRINT_QUANTITY					decimal(14,3) NULL,
	BLACKPLT_VER1					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BLACKPLT_VER2					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- SECONDARY TABLES
-- ==========================================================
-- Temp table #media_orders - stores table of orders to be processed
CREATE TABLE #media_orders(
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL,
	ORDER_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #media_orders
SELECT [USER_ID], ORDER_NBR, ORDER_TYPE
FROM dbo.MEDIA_RPT_ORDERS AS rd
WHERE UPPER(rd.[USER_ID]) = UPPER(@user_code)
-- SELECT * FROM #media_orders--------------------------------

-- Temp table #order_type-------------------------------------
CREATE TABLE #order_type(ORDER_TYPE varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #order_type
SELECT DISTINCT ORDER_TYPE 
FROM #media_orders
--SELECT * FROM #order_type

-- Temp table #order_inv_max_rev_seq - stores max rev and seq for each order invoice
CREATE TABLE #order_inv_max_rev_seq(
	ORDER_NBR				int NOT NULL,
	LINE_NBR				smallint NULL,
	REV_NBR					smallint NULL,
	SEQ_NBR					smallint NULL,
	AR_INV_NBR				int NULL)

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'M')
BEGIN
	-- Magazine (new)--------------------------------------------
	IF @app_type = 'I'							--#03
	BEGIN
		INSERT INTO #order_inv_max_rev_seq
		SELECT d.ORDER_NBR,
			d.LINE_NBR,
			d.REV_NBR,
			MAX(d.SEQ_NBR),
			d.AR_INV_NBR
		FROM dbo.MAGAZINE_DETAIL AS d		
		JOIN #media_orders AS o					--#03
			ON d.ORDER_NBR = o.ORDER_NBR
		WHERE d.AR_INV_NBR IS NOT NULL
			AND d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.MAGAZINE_DETAIL AS d2
			WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR
			AND d.AR_INV_NBR = d2.AR_INV_NBR)
		GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.AR_INV_NBR
	END	
	
	INSERT INTO #order_detail
	SELECT 'M' AS ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR, 
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.EXT_CLOSE_DATE, 
		d.START_DATE, 
		d.END_DATE,										--#04
		d.DATE_TO_BILL,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		d.MAT_COMP,
		d.SIZE_CODE, 
		d.EDITION_ISSUE,								--magazine/newspaper
		NULL AS SECTION,
		d.MATERIAL,										--magazine/newspaper
		d.[SIZE], 
		d.PRODUCTION_SIZE,								--magazine/newspaper
		d.HEADLINE,										--STARTS HERE 
		NULL AS PRINT_COLUMNS,							--newspaper only 
		NULL AS PRINT_INCHES,							--newspaper only
		NULL AS PRINT_LINES,							--newspaper only
		NULL AS COST_TYPE,								--newspaper/internet
		NULL AS RATE_TYPE,								--newspaper only
		NULL AS PROJ_IMPRESSIONS,						--internet only
		NULL AS GUARANTEED_IMPRESS,						--internet only
		NULL AS ACT_IMPRESSIONS,						--internet only
		NULL AS URL,									--internet only
		NULL AS TARGET_AUDIENCE,						--internet only
		NULL AS COPY_AREA,								--internet/outdoor
		NULL AS CREATIVE_SIZE,							--internet only
		NULL AS PLACEMENT_1,							--internet only
		NULL AS PLACEMENT_2,							--internet only
		NULL AS COST_RATE,								--internet only
		NULL AS NET_BASE_RATE,							--internet only
		NULL AS GROSS_BASE_RATE,						--internet only
		NULL AS SUB_TYPE,								--internet/outdoor
		NULL AS SUB_TYPE_DESC,							--internet/outdoor
		NULL AS LOCATION,								--outdoor only
		d.RATE_CARD_ID AS RATE_CARD, 
		d.RATE_DTL_ID AS RATE_DESC, 
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		0 AS RECONCILE_LINE,
		0 AS DO_NOT_BILL,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		c.POSITION_INFO,								--magazine/newspaper 
		c.RATE_INFO,									--magazine/newspaper 
		c.CLOSE_INFO,									--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		c.IN_HOUSE_CMTS,								--magazine/newspaper
		d.AD_NUMBER,
		an.AD_NBR_DESC,
		NULL AS PRINTED,
		ISNULL(d.RATE,0),
		ISNULL(d.NET_RATE,0),
		ISNULL(d.GROSS_RATE,0),
		ISNULL(d.FLAT_NET,0),
		ISNULL(d.FLAT_GROSS,0),
		ISNULL(d.EXT_NET_AMT,0),
		ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		d.NETCHARGE_DESC,
		ISNULL(d.ADDL_CHARGE,0),
		d.ADDL_CHARGE_DESC,
		ISNULL(d.PROD_CHARGE,0),
		d.PROD_DESC,
		ISNULL(d.COLOR_CHARGE,0),
		d.COLOR_DESC,
		ISNULL(d.BLEED_PCT,0),
		ISNULL(d.BLEED_AMT,0),
		ISNULL(d.POSITION_PCT,0),
		ISNULL(d.POSITION_AMT,0),
		ISNULL(d.PREMIUM_PCT,0),
		ISNULL(d.PREMIUM_AMT,0),
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.LINE_TOTAL,0),
		d.BILLING_USER,
		d.AR_INV_NBR,
		d.AR_TYPE,
		d.AR_INV_SEQ,
		ISNULL(d.MARKUP_PCT,0), 
		ISNULL(d.COMM_PCT,0), 
		ISNULL(d.REBATE_PCT,0),
		d.EST_NBR,
		d.EST_LINE_NBR,
		d.EST_REV_NBR,
		d.MG_CIRCULATION,
		0,
		NULL,
		NULL
	FROM #media_orders AS o 
	JOIN dbo.MAGAZINE_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.MAGAZINE_DETAIL AS d
		ON o.ORDER_NBR = d.ORDER_NBR
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
	LEFT JOIN #order_inv_max_rev_seq AS mrs
		ON d.ORDER_NBR = mrs.ORDER_NBR
		AND d.LINE_NBR = mrs.LINE_NBR
		AND d.REV_NBR = mrs.REV_NBR
		AND d.SEQ_NBR = mrs.SEQ_NBR
		AND d.AR_INV_NBR = mrs.AR_INV_NBR
	WHERE (@app_type = 'O' AND d.ACTIVE_REV = 1)
		OR @app_type = 'I' AND mrs.AR_INV_NBR IS NOT NULL			--#06

	DELETE #order_inv_max_rev_seq

END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'N')
BEGIN
	-- Newspaper (new)--------------------------------------------	
	IF @app_type = 'I'							--#03
	BEGIN
		INSERT INTO #order_inv_max_rev_seq
		SELECT d.ORDER_NBR,
			d.LINE_NBR,
			d.REV_NBR,
			MAX(d.SEQ_NBR),
			d.AR_INV_NBR
		FROM dbo.NEWSPAPER_DETAIL AS d		
		JOIN #media_orders AS o					--#03
			ON d.ORDER_NBR = o.ORDER_NBR
		WHERE d.AR_INV_NBR IS NOT NULL
			AND d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.NEWSPAPER_DETAIL AS d2
			WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR
			AND d.AR_INV_NBR = d2.AR_INV_NBR)
		GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.AR_INV_NBR
	END	

	INSERT INTO #order_detail
	SELECT 'N' AS ORDER_TYPE,
		h.MEDIA_TYPE,  
		h.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.EXT_CLOSE_DATE, 
		d.START_DATE, 
		d.END_DATE,										--#04
		d.DATE_TO_BILL,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		d.MAT_COMP,
		d.SIZE_CODE, 
		d.EDITION_ISSUE,
		d.SECTION, 
		d.MATERIAL, 
		d.[SIZE], 
		d.PRODUCTION_SIZE, 
		d.HEADLINE, 
		d.PRINT_COLUMNS,								--newspaper only 
		d.PRINT_INCHES,									--newspaper only
		d.PRINT_LINES,									--newspaper only
		d.COST_TYPE,									--newspaper/internet
		d.RATE_TYPE,									--newspaper only
		NULL AS PROJ_IMPRESSIONS,						--internet only
		NULL AS GUARANTEED_IMPRESS,						--internet only
		NULL AS ACT_IMPRESSIONS,						--internet only
		NULL AS URL,									--internet only
		NULL AS TARGET_AUDIENCE,						--internet only
		NULL AS COPY_AREA,								--internet/outdoor
		NULL AS CREATIVE_SIZE,							--internet only
		NULL AS PLACEMENT_1,							--internet only
		NULL AS PLACEMENT_2,							--internet only
		NULL AS COST_RATE,								--internet only
		NULL AS NET_BASE_RATE,							--internet only
		NULL AS GROSS_BASE_RATE,						--internet only
		NULL AS SUB_TYPE,								--internet/outdoor
		NULL AS SUB_TYPE_DESC,							--internet/outdoor
		NULL AS LOCATION,								--outdoor only
		d.RATE_CARD_ID AS RATE_CARD, 
		d.RATE_DTL_ID AS RATE_DESC, 
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		0 AS RECONCILE_LINE,
		0 AS DO_NOT_BILL,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		c.POSITION_INFO, 
		c.RATE_INFO, 
		c.CLOSE_INFO, 
		c.MISC_INFO, 
		c.MATL_NOTES,
		c.IN_HOUSE_CMTS, 
		d.AD_NUMBER,
		an.AD_NBR_DESC,
		NULL AS PRINTED,
		ISNULL(d.RATE,0),
		ISNULL(d.NET_RATE,0) - ISNULL(d.COLOR_CHARGE,0),
		ISNULL(d.GROSS_RATE,0) - ISNULL(d.COLOR_CHARGE,0),
		ISNULL(d.FLAT_NET,0),
		ISNULL(d.FLAT_GROSS,0),
		ISNULL(d.EXT_NET_AMT,0),
		ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		d.NETCHARGE_DESC,
		ISNULL(d.ADDL_CHARGE,0),
		d.ADDL_CHARGE_DESC,
		ISNULL(d.PROD_CHARGE,0),
		d.PROD_DESC,
		ISNULL(d.COLOR_CHARGE,0),
		d.COLOR_DESC,
		0 AS BLEED_PCT,
		0 AS BLEED_AMT,
		0 AS POSITION_PCT,
		0 AS POSITION_AMT,
		0 AS PREMIUM_PCT,
		0 AS PREMIUM_AMT,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.LINE_TOTAL,0),
		d.BILLING_USER,
		d.AR_INV_NBR,
		d.AR_TYPE,
		d.AR_INV_SEQ,
		ISNULL(d.MARKUP_PCT,0), 
		ISNULL(d.COMM_PCT,0), 
		ISNULL(d.REBATE_PCT,0),
		d.EST_NBR,
		d.EST_LINE_NBR,
		d.EST_REV_NBR,
		d.NP_CIRCULATION,
		ISNULL(d.PRINT_QUANTITY,0),						--#05
		b.BLACKPLT_VER_DESC,
		b2.BLACKPLT_VER_DESC
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
	LEFT JOIN #order_inv_max_rev_seq AS mrs
		ON d.ORDER_NBR = mrs.ORDER_NBR
		AND d.LINE_NBR = mrs.LINE_NBR
		AND d.REV_NBR = mrs.REV_NBR
		AND d.SEQ_NBR = mrs.SEQ_NBR
		AND d.AR_INV_NBR = mrs.AR_INV_NBR
	LEFT JOIN dbo.BLACKPLT_VERSION AS b	
		ON an.DEF_BLKPLT_VER_CODE = b.BLACKPLT_VER_CODE
	LEFT JOIN dbo.BLACKPLT_VERSION AS b2	
		ON an.DEF_BLKPLT_VER2_CODE = b2.BLACKPLT_VER_CODE
	WHERE (@app_type = 'O' AND d.ACTIVE_REV = 1)
		OR @app_type = 'I' AND mrs.AR_INV_NBR IS NOT NULL			--#06

	DELETE #order_inv_max_rev_seq

END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'I')
BEGIN
	-- Internet -----------------------------------------------	
	IF @app_type = 'I'							--#03
	BEGIN
		INSERT INTO #order_inv_max_rev_seq
		SELECT d.ORDER_NBR,
			d.LINE_NBR,
			d.REV_NBR,
			MAX(d.SEQ_NBR),
			d.AR_INV_NBR
		FROM dbo.INTERNET_DETAIL AS d		
		JOIN #media_orders AS o					--#03
			ON d.ORDER_NBR = o.ORDER_NBR
		WHERE d.AR_INV_NBR IS NOT NULL
			AND d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.INTERNET_DETAIL AS d2
			WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR
			AND d.AR_INV_NBR = d2.AR_INV_NBR)
		GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.AR_INV_NBR
	END	

	INSERT INTO #order_detail
	SELECT 'I' AS ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR, 
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.EXT_CLOSE_DATE, 
		d.START_DATE,
		d.END_DATE, 
		d.DATE_TO_BILL,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		d.MAT_COMP,
		d.SIZE AS SIZE_CODE, 
		NULL AS EDITION_ISSUE,
		NULL AS SECTION,
		NULL AS MATERIAL,
		d.CREATIVE_SIZE AS [SIZE],
		NULL AS PRODUCTION_SIZE,
		d.HEADLINE,
		NULL AS PRINT_COLUMNS,							--newspaper only 
		NULL AS PRINT_INCHES,							--newspaper only
		NULL AS PRINT_LINES,							--newspaper only
		d.COST_TYPE,									--newspaper/internet
		NULL AS RATE_TYPE,								--newspaper only
		d.PROJ_IMPRESSIONS,								--internet only
		d.GUARANTEED_IMPRESS,							--internet only
		d.ACT_IMPRESSIONS,								--internet only
		d.URL,											--internet only
		d.TARGET_AUDIENCE,								--internet only
		d.COPY_AREA,									--internet only
		d.CREATIVE_SIZE,								--internet only
		d.PLACEMENT_1,									--internet only
		d.PLACEMENT_2,									--internet only
		d.COST_RATE,									--internet only
		d.NET_BASE_RATE,								--internet only
		d.GROSS_BASE_RATE,								--internet only
		d.INTERNET_TYPE AS SUB_TYPE,					--internet only
		t.OD_DESC AS SUB_TYPE_DESC,						--internet/outdoor
		NULL AS LOCATION,								--outdoor only
		d.RATE_CARD,
		d.RATE_DESC,
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		0 AS RECONCILE_LINE,
		0 AS DO_NOT_BILL,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		NULL AS POSITION_INFO,							--magazine/newspaper 
		NULL AS RATE_INFO,								--magazine/newspaper 
		NULL AS CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		NULL AS IN_HOUSE_CMTS,							--magazine/newspaper  
		d.AD_NUMBER,
		an.AD_NBR_DESC,
		NULL AS PRINTED,
		ISNULL(d.RATE,0),
		ISNULL(d.NET_RATE,0),
		ISNULL(d.GROSS_RATE,0),
		0 AS FLAT_NET,
		0 AS FLAT_GROSS,
		ISNULL(d.EXT_NET_AMT,0),
		ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		d.NCDESC,
		ISNULL(d.ADDL_CHARGE,0),
		d.ADDL_CHARGE_DESC,
		NULL AS PROD_CHARGE,
		NULL AS PROD_DESC,
		NULL AS COLOR_CHARGE,
		NULL AS COLOR_DESC,
		NULL AS BLEED_PCT,
		NULL AS BLEED_AMT,
		NULL AS POSITION_PCT,
		NULL AS POSITION_AMT,
		NULL AS PREMIUM_PCT,
		NULL AS PREMIUM_AMT,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.LINE_TOTAL,0),
		d.BILLING_USER,
		d.AR_INV_NBR,
		d.AR_TYPE,
		d.AR_INV_SEQ,
		ISNULL(d.MARKUP_PCT,0), 
		ISNULL(d.COMM_PCT,0), 
		ISNULL(d.REBATE_PCT,0),
		d.EST_NBR,
		d.EST_LINE_NBR,
		d.EST_REV_NBR,
		NULL,
		ISNULL(d.GUARANTEED_IMPRESS,0),
		NULL,
		NULL
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
	LEFT JOIN #order_inv_max_rev_seq AS mrs
		ON d.ORDER_NBR = mrs.ORDER_NBR
		AND d.LINE_NBR = mrs.LINE_NBR
		AND d.REV_NBR = mrs.REV_NBR
		AND d.SEQ_NBR = mrs.SEQ_NBR
		AND d.AR_INV_NBR = mrs.AR_INV_NBR
	WHERE (@app_type = 'O' AND d.ACTIVE_REV = 1)
		OR @app_type = 'I' AND mrs.AR_INV_NBR IS NOT NULL			--#06

	DELETE #order_inv_max_rev_seq

END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'O')
BEGIN
	-- Outdoor -----------------------------------------------	
	IF @app_type = 'I'							--#03
	BEGIN
		INSERT INTO #order_inv_max_rev_seq
		SELECT d.ORDER_NBR,
			d.LINE_NBR,
			d.REV_NBR,
			MAX(d.SEQ_NBR),
			d.AR_INV_NBR
		FROM dbo.OUTDOOR_DETAIL AS d		
		JOIN #media_orders AS o					--#03
			ON d.ORDER_NBR = o.ORDER_NBR
		WHERE d.AR_INV_NBR IS NOT NULL
			AND d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.OUTDOOR_DETAIL AS d2
			WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR
			AND d.AR_INV_NBR = d2.AR_INV_NBR)
		GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.AR_INV_NBR
	END	

	INSERT INTO #order_detail
	SELECT 'O' AS ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR, 
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.EXT_CLOSE_DATE, 
		d.POST_DATE AS [START_DATE],
		d.END_DATE,
		d.DATE_TO_BILL, 
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		d.MAT_COMP,
		d.SIZE AS SIZE_CODE, 
		NULL AS EDITION_ISSUE,
		NULL AS SECTION,
		NULL AS MATERIAL, 
		ISNULL(ad.SIZE_DESC, os.OD_DESC) AS [SIZE],		--#07, #08
		NULL AS PRODUCTION_SIZE,
		d.HEADLINE,
		NULL AS PRINT_COLUMNS,							--newspaper only 
		NULL AS PRINT_INCHES,							--newspaper only
		NULL AS PRINT_LINES,							--newspaper only
		NULL AS COST_TYPE,								--newspaper/internet
		NULL AS RATE_TYPE,								--newspaper only
		NULL AS PROJ_IMPRESSIONS,						--internet only
		NULL AS GUARANTEED_IMPRESS,						--internet only
		NULL AS ACT_IMPRESSIONS,						--internet only
		NULL AS URL,									--internet only
		NULL AS TARGET_AUDIENCE,						--internet only
		d.COPY_AREA,									--internet/outdoor
		NULL AS CREATIVE_SIZE,							--internet only
		NULL AS PLACEMENT_1,							--internet only
		NULL AS PLACEMENT_2,							--internet only
		NULL AS COST_RATE,								--internet only
		NULL AS NET_BASE_RATE,							--internet only
		NULL AS GROSS_BASE_RATE,						--internet only
		d.OUTDOOR_TYPE AS SUB_TYPE,						--internet/outdoor
		t.OD_DESC AS SUB_TYPE_DESC,						--internet/outdoor
		d.LOCATION,										--outdoor only 
		d.RATE_CARD,
		d.RATE_DESC,
		d.JOB_NUMBER,
		jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		0 AS RECONCILE_LINE,
		0 AS DO_NOT_BILL,
		c.INSTRUCTIONS, 
		c.ORDER_COPY, 
		NULL AS POSITION_INFO,							--magazine/newspaper 
		NULL AS RATE_INFO,								--magazine/newspaper 
		NULL AS CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		NULL AS IN_HOUSE_CMTS,							--magazine/newspaper 
		d.AD_NUMBER,
		an.AD_NBR_DESC,
		NULL AS PRINTED,
		ISNULL(d.RATE,0),
		ISNULL(d.NET_RATE,0),
		ISNULL(d.GROSS_RATE,0),
		0 AS FLAT_NET,
		0 AS FLAT_GROSS,
		ISNULL(d.EXT_NET_AMT,0),
		ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		d.NCDESC,
		ISNULL(d.ADDL_CHARGE,0),
		d.ADDL_CHARGE_DESC,
		NULL AS PROD_CHARGE,
		NULL AS PROD_DESC,
		NULL AS COLOR_CHARGE,
		NULL AS COLOR_DESC,
		NULL AS BLEED_PCT,
		NULL AS BLEED_AMT,
		NULL AS POSITION_PCT,
		NULL AS POSITION_AMT,
		NULL AS PREMIUM_PCT,
		NULL AS PREMIUM_AMT,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.LINE_TOTAL,0),
		d.BILLING_USER,
		d.AR_INV_NBR,
		d.AR_TYPE,
		d.AR_INV_SEQ,
		ISNULL(d.MARKUP_PCT,0), 
		ISNULL(d.COMM_PCT,0), 
		ISNULL(d.REBATE_PCT,0),
		d.EST_NBR,
		d.EST_LINE_NBR,
		d.EST_REV_NBR,
		NULL,
		0,
		NULL,
		NULL
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
	LEFT JOIN dbo.AD_SIZE AS ad							--#08
		ON d.[SIZE] = ad.SIZE_CODE
		AND ad.MEDIA_TYPE = 'O'			
	LEFT JOIN dbo.OUTDOOR_SIZE AS os					--#07, #08
		ON d.[SIZE] = os.OD_CODE			
	LEFT JOIN dbo.JOB_LOG AS jl
		ON d.JOB_NUMBER = jl.JOB_NUMBER
	LEFT JOIN dbo.JOB_COMPONENT AS jc
		ON d.JOB_NUMBER = jc.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	LEFT JOIN dbo.AD_NUMBER AS an
		ON d.AD_NUMBER = an.AD_NBR
	LEFT JOIN #order_inv_max_rev_seq AS mrs
		ON d.ORDER_NBR = mrs.ORDER_NBR
		AND d.LINE_NBR = mrs.LINE_NBR
		AND d.REV_NBR = mrs.REV_NBR
		AND d.SEQ_NBR = mrs.SEQ_NBR
		AND d.AR_INV_NBR = mrs.AR_INV_NBR
	WHERE (@app_type = 'O' AND d.ACTIVE_REV = 1)
		OR @app_type = 'I' AND mrs.AR_INV_NBR IS NOT NULL			--#06

	DELETE #order_inv_max_rev_seq

END

SELECT * FROM #order_detail

END

GO


