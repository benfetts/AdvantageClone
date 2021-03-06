--insert the next statement at the top of the script while debugging
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_print_detail_active]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_media1_order_print_detail_active]
GO

CREATE PROCEDURE [dbo].[advsp_media1_order_print_detail_active] ( 
	@order_status					varchar(1) = 'A',						--A = all, O = open
	@start_date						datetime = '1/1/1900',									
	@end_date						datetime = '12/31/2100',
	@include_internet				bit	= 1,
	@include_magazine				bit	= 1,
	@include_newspaper				bit	= 1,
	@include_outofhome				bit	= 1,
	@revisions						bit	= 0		--#06
	)
	
-- advsp_media1_order_print_detail_active
-- extracts data for active revision only, within a specified date range
-- modified specifically for MCS advsp_media1_media_current_status1(_sum)
-- remarked out lines are remnants from advsp_media1_order_print_detail
-- #00 03/12/15 - original, copied from advsp_media1_order_print_detail (#05 03/20/14)
-- #01 03/21/15 - added ACTIVE_REV = 1 to WHERE clause
-- #02 05/12/15 - set unused fields for MCS to NULL, rather than taking time to populate them (735-1768)			
-- #03 06/26/17 - Dynamic Reports - Add Placement 1,  Projected Impressions and Actual Impressions to the Media Current Status & Media Current Status Summary reports (735-2-1132)
-- #04 02/13/19 - Changed from NULL to d.COPY_AREA (4894-1-15 )
-- #05 03/22/19 - Added @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
-- #06 07/16/19 - Optional include revisions flag - defaults to 0
	
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
	LINK_DETID						int NULL,
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
-- EXTRACTION ROUTINES
-- ==========================================================
IF @include_magazine = 1
BEGIN	
	INSERT INTO #order_detail
	SELECT 
		'M' AS ORDER_TYPE, 
		NULL,											--h.MEDIA_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR, 
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.LINK_DETID,
		d.EXT_CLOSE_DATE, 
		d.[START_DATE], 
		d.END_DATE,										--#04
		d.DATE_TO_BILL,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		NULL,											--d.MAT_COMP,
		NULL,											--d.SIZE_CODE, 
		d.EDITION_ISSUE,								--magazine/newspaper
		NULL AS SECTION,
		d.MATERIAL,										--magazine/newspaper
		d.[SIZE], 
		NULL,											--d.PRODUCTION_SIZE,								--magazine/newspaper
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
		NULL,											--d.RATE_CARD_ID AS RATE_CARD, 
		NULL,											--d.RATE_DTL_ID AS RATE_DESC, 
		d.JOB_NUMBER,
		NULL,											--jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		NULL,											--jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		0 AS RECONCILE_LINE,
		0 AS DO_NOT_BILL,
		NULL,											--c.INSTRUCTIONS, 
		NULL,											--c.ORDER_COPY, 
		c.POSITION_INFO,								--magazine/newspaper 
		c.RATE_INFO,									--magazine/newspaper 
		NULL,											--c.CLOSE_INFO,									--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		c.IN_HOUSE_CMTS,								--magazine/newspaper
		d.AD_NUMBER,											--d.AD_NUMBER,
		NULL,											--an.AD_NBR_DESC,
		NULL AS PRINTED,
		NULL,											--ISNULL(d.RATE,0),
		NULL,											--ISNULL(d.NET_RATE,0),
		NULL,											--ISNULL(d.GROSS_RATE,0),
		NULL,											--ISNULL(d.FLAT_NET,0),
		NULL,											--ISNULL(d.FLAT_GROSS,0),
		ISNULL(d.EXT_NET_AMT,0),
		NULL,											--ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		NULL,											--d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		NULL,											--d.NETCHARGE_DESC,
		ISNULL(d.ADDL_CHARGE,0),
		NULL,											--d.ADDL_CHARGE_DESC,
		NULL,											--ISNULL(d.PROD_CHARGE,0),
		NULL,											--d.PROD_DESC,
		NULL,											--ISNULL(d.COLOR_CHARGE,0),
		NULL,											--d.COLOR_DESC,
		NULL,											--ISNULL(d.BLEED_PCT,0),
		NULL,											--ISNULL(d.BLEED_AMT,0),
		NULL,											--ISNULL(d.POSITION_PCT,0),
		NULL,											--ISNULL(d.POSITION_AMT,0),
		NULL,											--ISNULL(d.PREMIUM_PCT,0),
		NULL,											--ISNULL(d.PREMIUM_AMT,0),
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.LINE_TOTAL,0),
		NULL,											--d.BILLING_USER,
		NULL,											--d.AR_INV_NBR,
		NULL,											--d.AR_TYPE,
		NULL,											--d.AR_INV_SEQ,
		NULL,											--ISNULL(d.MARKUP_PCT,0), 
		NULL,											--ISNULL(d.COMM_PCT,0), 
		NULL,											--ISNULL(d.REBATE_PCT,0),
		NULL,											--d.EST_NBR,
		NULL,											--d.EST_LINE_NBR,
		NULL,											--d.EST_REV_NBR,
		d.MG_CIRCULATION,
		0,
		NULL,
		NULL   
	FROM dbo.MAGAZINE_DETAIL AS d
	JOIN dbo.MAGAZINE_HEADER AS h
		ON h.ORDER_NBR = d.ORDER_NBR
	LEFT JOIN dbo.MAGAZINE_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	--LEFT JOIN dbo.JOB_LOG AS jl
	--	ON d.JOB_NUMBER = jl.JOB_NUMBER
	--LEFT JOIN dbo.JOB_COMPONENT AS jc
	--	ON d.JOB_NUMBER = jc.JOB_NUMBER
	--	AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	--LEFT JOIN dbo.AD_NUMBER AS an
	--	ON d.AD_NUMBER = an.AD_NBR
	WHERE (d.ACTIVE_REV = 1 OR @revisions = 1)  --#06
		AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))		--#01
		AND d.[START_DATE] BETWEEN @start_date AND @end_date
END

IF @include_newspaper = 1
BEGIN
	INSERT INTO #order_detail
	SELECT 
		'N' AS ORDER_TYPE,
		NULL,											--h.MEDIA_TYPE,  
		d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.LINK_DETID,
		d.EXT_CLOSE_DATE, 
		d.[START_DATE], 
		d.END_DATE,										--#04
		d.DATE_TO_BILL,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		NULL,											--d.MAT_COMP,
		NULL,											--d.SIZE_CODE, 
		d.EDITION_ISSUE,
		d.SECTION, 
		d.MATERIAL, 
		d.[SIZE], 
		NULL,											--d.PRODUCTION_SIZE, 
		d.HEADLINE, 
		NULL,											--d.PRINT_COLUMNS,								--newspaper only 
		NULL,											--d.PRINT_INCHES,									--newspaper only
		NULL,											--d.PRINT_LINES,									--newspaper only
		d.COST_TYPE,									--newspaper/internet
		d.RATE_TYPE,									--newspaper only
		NULL,											--NULL AS PROJ_IMPRESSIONS,						--internet only
		NULL AS GUARANTEED_IMPRESS,						--internet only
		NULL,											--NULL AS ACT_IMPRESSIONS,						--internet only
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
		NULL,											--d.RATE_CARD_ID AS RATE_CARD, 
		NULL,											--d.RATE_DTL_ID AS RATE_DESC, 
		d.JOB_NUMBER,
		NULL,											--jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		NULL,											--jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		NULL,											--0 AS RECONCILE_LINE,
		NULL,											--0 AS DO_NOT_BILL,
		NULL,											--c.INSTRUCTIONS, 
		NULL,											--c.ORDER_COPY, 
		c.POSITION_INFO, 
		c.RATE_INFO, 
		NULL,											--c.CLOSE_INFO, 
		c.MISC_INFO, 
		c.MATL_NOTES,
		c.IN_HOUSE_CMTS, 
		d.AD_NUMBER,											--d.AD_NUMBER,
		NULL,											--an.AD_NBR_DESC,
		NULL AS PRINTED,
		NULL,											--ISNULL(d.RATE,0),
		NULL,											--ISNULL(d.NET_RATE,0) - ISNULL(d.COLOR_CHARGE,0),
		NULL,											--ISNULL(d.GROSS_RATE,0) - ISNULL(d.COLOR_CHARGE,0),
		NULL,											--ISNULL(d.FLAT_NET,0),
		NULL,											--ISNULL(d.FLAT_GROSS,0),
		ISNULL(d.EXT_NET_AMT,0),
		NULL,											--ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		NULL,											--d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		NULL,											--d.NETCHARGE_DESC,
		ISNULL(d.ADDL_CHARGE,0),
		NULL,											--d.ADDL_CHARGE_DESC,
		ISNULL(d.PROD_CHARGE,0),
		NULL,											--d.PROD_DESC,
		NULL,											--ISNULL(d.COLOR_CHARGE,0),
		NULL,											--d.COLOR_DESC,
		NULL,											--0 AS BLEED_PCT,
		NULL,											--0 AS BLEED_AMT,
		NULL,											--0 AS POSITION_PCT,
		NULL,											--0 AS POSITION_AMT,
		NULL,											--0 AS PREMIUM_PCT,
		NULL,											--NULL,											--0 AS PREMIUM_AMT,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.LINE_TOTAL,0),
		NULL,											--d.BILLING_USER,
		NULL,											--d.AR_INV_NBR,
		NULL,											--d.AR_TYPE,
		NULL,											--d.AR_INV_SEQ,
		NULL,											--ISNULL(d.MARKUP_PCT,0), 
		NULL,											--ISNULL(d.COMM_PCT,0), 
		NULL,											--ISNULL(d.REBATE_PCT,0),
		NULL,											--d.EST_NBR,
		NULL,											--d.EST_LINE_NBR,
		NULL,											--d.EST_REV_NBR,
		ISNULL(d.NP_CIRCULATION,0),
		ISNULL(d.PRINT_QUANTITY,0),				
		NULL,											--b.BLACKPLT_VER_DESC,
		NULL											--b2.BLACKPLT_VER_DESC 
	FROM dbo.NEWSPAPER_DETAIL AS d
	JOIN dbo.NEWSPAPER_HEADER AS h
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.NEWSPAPER_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	--LEFT JOIN dbo.JOB_LOG AS jl
	--	ON d.JOB_NUMBER = jl.JOB_NUMBER
	--LEFT JOIN dbo.JOB_COMPONENT AS jc
	--	ON d.JOB_NUMBER = jc.JOB_NUMBER
	--	AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	--LEFT JOIN dbo.AD_NUMBER AS an
	--	ON d.AD_NUMBER = an.AD_NBR
	--LEFT JOIN dbo.BLACKPLT_VERSION AS b	
	--	ON an.DEF_BLKPLT_VER_CODE = b.BLACKPLT_VER_CODE
	--LEFT JOIN dbo.BLACKPLT_VERSION AS b2	
	--	ON an.DEF_BLKPLT_VER2_CODE = b2.BLACKPLT_VER_CODE
	WHERE (d.ACTIVE_REV = 1 OR @revisions = 1)  --#06 
		AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))		--#01
		AND d.[START_DATE] BETWEEN @start_date AND @end_date
END

IF @include_internet = 1
BEGIN
	INSERT INTO #order_detail
	SELECT 
		'I' AS ORDER_TYPE, 
		NULL,											--h.MEDIA_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR, 
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.LINK_DETID,
		d.EXT_CLOSE_DATE, 
		d.[START_DATE],
		d.END_DATE, 
		d.DATE_TO_BILL,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		NULL,											--d.MAT_COMP,
		NULL,											--d.SIZE AS SIZE_CODE, 
		NULL AS EDITION_ISSUE,
		NULL AS SECTION,
		NULL AS MATERIAL,
		d.CREATIVE_SIZE AS [SIZE],
		NULL AS PRODUCTION_SIZE,
		d.HEADLINE,
		NULL AS PRINT_COLUMNS,				--newspaper only 
		NULL AS PRINT_INCHES,					--newspaper only
		NULL AS PRINT_LINES,					--newspaper only
		d.COST_TYPE,								--newspaper/internet
		NULL AS RATE_TYPE,						--newspaper only
		d.PROJ_IMPRESSIONS,					--d.PROJ_IMPRESSIONS,							--internet only #03
		d.GUARANTEED_IMPRESS,				--internet only
		d.ACT_IMPRESSIONS,					--d.ACT_IMPRESSIONS,							--internet only #03
		d.URL,											--internet only
		NULL,											--d.TARGET_AUDIENCE,							--internet only
		d.COPY_AREA,								--internet only
		NULL,											--d.CREATIVE_SIZE,								--internet only
		d.PLACEMENT_1,							--d.PLACEMENT_1,									--internet only #03
		d.PLACEMENT_2,							--d.PLACEMENT_2,									--internet only #03
		NULL,											--d.COST_RATE,										--internet only
		NULL,											--d.NET_BASE_RATE,								--internet only
		NULL,											--d.GROSS_BASE_RATE,							--internet only
		NULL,											--d.INTERNET_TYPE AS SUB_TYPE,			--internet only
		NULL,											--t.OD_DESC AS SUB_TYPE_DESC,			--internet/outdoor
		NULL AS LOCATION,								--outdoor only
		NULL,											--d.RATE_CARD,
		NULL,											--d.RATE_DESC,
		d.JOB_NUMBER,
		NULL,											--jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		NULL,											--jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		0 AS RECONCILE_LINE,
		0 AS DO_NOT_BILL,
		NULL,											--c.INSTRUCTIONS, 
		NULL,											--c.ORDER_COPY, 
		NULL AS POSITION_INFO,							--magazine/newspaper 
		NULL AS RATE_INFO,								--magazine/newspaper 
		NULL,											--NULL AS CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		NULL AS IN_HOUSE_CMTS,							--magazine/newspaper  
		d.AD_NUMBER,											--d.AD_NUMBER,
		NULL,											--an.AD_NBR_DESC,
		NULL AS PRINTED,
		NULL,											--ISNULL(d.RATE,0),
		NULL,											--ISNULL(d.NET_RATE,0),
		NULL,											--ISNULL(d.GROSS_RATE,0),
		NULL,											--0 AS FLAT_NET,
		NULL,											--0 AS FLAT_GROSS,
		ISNULL(d.EXT_NET_AMT,0),
		ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		NULL,											--d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		NULL,											--d.NCDESC,
		ISNULL(d.ADDL_CHARGE,0),
		NULL,											--d.ADDL_CHARGE_DESC,
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
		NULL,											--d.BILLING_USER,
		NULL,											--d.AR_INV_NBR,
		NULL,											--d.AR_TYPE,
		NULL,											--d.AR_INV_SEQ,
		NULL,											--ISNULL(d.MARKUP_PCT,0), 
		NULL,											--ISNULL(d.COMM_PCT,0), 
		NULL,											--ISNULL(d.REBATE_PCT,0),
		NULL,											--d.EST_NBR,
		NULL,											--d.EST_LINE_NBR,
		NULL,											--d.EST_REV_NBR,
		0,
		ISNULL(d.GUARANTEED_IMPRESS,0),		--internet only
		NULL,
		NULL  
	FROM dbo.INTERNET_DETAIL AS d 
	JOIN dbo.INTERNET_HEADER AS h
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.INTERNET_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	--LEFT JOIN dbo.INTERNET_TYPE AS t
	--	ON d.INTERNET_TYPE = t.OD_CODE
	--LEFT JOIN dbo.JOB_LOG AS jl
	--	ON d.JOB_NUMBER = jl.JOB_NUMBER
	--LEFT JOIN dbo.JOB_COMPONENT AS jc
	--	ON d.JOB_NUMBER = jc.JOB_NUMBER
	--	AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	--LEFT JOIN dbo.AD_NUMBER AS an
	--	ON d.AD_NUMBER = an.AD_NBR
	WHERE (d.ACTIVE_REV = 1 OR @revisions = 1)  --#06
		AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))		--#01
		AND d.[START_DATE] BETWEEN @start_date AND @end_date
END

IF @include_outofhome = 1
BEGIN
	INSERT INTO #order_detail
	SELECT 
		'O' AS ORDER_TYPE, 
		NULL,											--h.MEDIA_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR, 
		d.SEQ_NBR,
		d.ACTIVE_REV,
		d.LINK_DETID,
		d.EXT_CLOSE_DATE, 
		d.POST_DATE AS [START_DATE],
		d.END_DATE,
		d.DATE_TO_BILL, 
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		d.EXT_MATL_DATE,
		NULL,											--d.MAT_COMP,
		NULL,											--d.SIZE AS SIZE_CODE, 
		NULL AS EDITION_ISSUE,
		NULL AS SECTION,
		NULL AS MATERIAL, 
		ad.[SIZE_DESC] AS [SIZE],
		NULL AS PRODUCTION_SIZE,
		d.HEADLINE,
		NULL AS PRINT_COLUMNS,							--newspaper only 
		NULL AS PRINT_INCHES,							--newspaper only
		NULL AS PRINT_LINES,							--newspaper only
		NULL AS COST_TYPE,								--newspaper/internet
		NULL AS RATE_TYPE,								--newspaper only
		NULL AS PROJ_IMPRESSIONS,						--internet only
		d.[IMPRESSIONS] AS GUARANTEED_IMPRESS,				--internet only --added outdoor
		d.[ACTUAL_IMPRESSIONS] AS ACT_IMPRESSIONS,			--internet only --added outdoor
		NULL AS URL,									--internet only
		NULL AS TARGET_AUDIENCE,						--internet only
		d.COPY_AREA,											--d.COPY_AREA,					--internet/outdoor  --#04 02/13/19 - Changed from NULL to d.COPY_AREA
		NULL AS CREATIVE_SIZE,							--internet only
		NULL AS PLACEMENT_1,							--internet only
		NULL AS PLACEMENT_2,							--internet only
		NULL AS COST_RATE,								--internet only
		NULL AS NET_BASE_RATE,							--internet only
		NULL AS GROSS_BASE_RATE,						--internet only
		NULL,											--d.OUTDOOR_TYPE AS SUB_TYPE,		--internet/outdoor
		NULL,											--t.OD_DESC AS SUB_TYPE_DESC,	--internet/outdoor
		d.LOCATION,										--outdoor only 
		NULL,											--d.RATE_CARD,
		NULL,											--d.RATE_DESC,
		d.JOB_NUMBER,
		NULL,											--jl.JOB_DESC, 
		d.JOB_COMPONENT_NBR, 
		NULL,											--jc.JOB_COMP_DESC,
		ISNULL(d.BILL_TYPE_FLAG,0),
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.NON_BILL_FLAG,0),
		NULL,											--0 AS RECONCILE_LINE,
		NULL,											--0 AS DO_NOT_BILL,
		NULL,											--c.INSTRUCTIONS, 
		NULL,											--c.ORDER_COPY, 
		NULL AS POSITION_INFO,							--magazine/newspaper 
		NULL AS RATE_INFO,								--magazine/newspaper 
		NULL AS CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		NULL AS IN_HOUSE_CMTS,							--magazine/newspaper 
		d.AD_NUMBER,											--d.AD_NUMBER,
		NULL,											--an.AD_NBR_DESC,
		NULL AS PRINTED,
		NULL,											--ISNULL(d.RATE,0),
		NULL,											--ISNULL(d.NET_RATE,0),
		NULL,											--ISNULL(d.GROSS_RATE,0),
		NULL,											--0 AS FLAT_NET,
		NULL,											--0 AS FLAT_GROSS,
		ISNULL(d.EXT_NET_AMT,0),
		NULL,											--ISNULL(d.EXT_GROSS_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.REBATE_AMT,0),
		ISNULL(d.DISCOUNT_AMT,0),
		NULL,											--d.DISCOUNT_DESC,
		ISNULL(d.STATE_AMT,0),
		ISNULL(d.COUNTY_AMT,0),
		ISNULL(d.CITY_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.NETCHARGE,0),
		NULL,											--d.NCDESC,
		ISNULL(d.ADDL_CHARGE,0),
		NULL,											--d.ADDL_CHARGE_DESC,
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
		NULL,											--d.BILLING_USER,
		NULL,											--d.AR_INV_NBR,
		NULL,											--d.AR_TYPE,
		NULL,											--d.AR_INV_SEQ,
		NULL,											--ISNULL(d.MARKUP_PCT,0), 
		NULL,											--ISNULL(d.COMM_PCT,0), 
		NULL,											--ISNULL(d.REBATE_PCT,0),
		NULL,											--d.EST_NBR,
		NULL,											--d.EST_LINE_NBR,
		NULL,											--d.EST_REV_NBR,
		0,
		0,
		NULL,
		NULL  
	FROM dbo.OUTDOOR_DETAIL AS d 
	JOIN dbo.OUTDOOR_HEADER AS h
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.OUTDOOR_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	--LEFT JOIN dbo.OUTDOOR_TYPE AS t
	--	ON d.OUTDOOR_TYPE = t.OD_CODE
	LEFT JOIN dbo.AD_SIZE AS ad
		ON 'O' = ad.MEDIA_TYPE
		AND d.[SIZE] = ad.SIZE_CODE
	--LEFT JOIN dbo.JOB_LOG AS jl
	--	ON d.JOB_NUMBER = jl.JOB_NUMBER
	--LEFT JOIN dbo.JOB_COMPONENT AS jc
	--	ON d.JOB_NUMBER = jc.JOB_NUMBER
	--	AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	--LEFT JOIN dbo.AD_NUMBER AS an
	--	ON d.AD_NUMBER = an.AD_NBR
	WHERE (d.ACTIVE_REV = 1 OR @revisions = 1)  --#06 
		AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))		--#01
		AND d.[POST_DATE] BETWEEN @start_date AND @end_date
END

SELECT * FROM #order_detail

END