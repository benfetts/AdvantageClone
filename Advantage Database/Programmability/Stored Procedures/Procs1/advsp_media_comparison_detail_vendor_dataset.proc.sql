IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_media_comparison_detail_vendor_dataset]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_media_comparison_detail_vendor_dataset]
GO

CREATE PROCEDURE [dbo].[advsp_media_comparison_detail_vendor_dataset]  ( 	
	@order_status			varchar(1)		= 'A',						--A = all, O = open
	@start_date				datetime		= '1/1/1900',				--JP (2/8/2014)
	@start_month			int				= 1,
	@start_year				int				= 1900,
	@end_date				datetime		= '12/31/2100',				--JP (2/8/2014)
	@end_month				int				= 12,						--#17
	@end_year				int				= 2100,						--JP (2/8/2014)
	@include_internet		bit				= 1,
	@include_magazine		bit				= 1,
	@include_newspaper		bit				= 1,
	@include_outofhome		bit				= 1,
	@include_radio			bit				= 1,
	@include_television		bit				= 1,
	@OfficeCodeList  varchar(max)=null,
	@ClientCodeList varchar(max)=null,
	@ClientDivisionCodeList varchar(max)=null,
	@ClientDivisionProductCodeList varchar(max)=null,
	@user_id varchar(100) = NULL
	)

AS
BEGIN
SET NOCOUNT ON;

--#41 06/28/2019 - 735-2-3725 - (NEW Dataset) Dynamic Reports - Media Plan Comparison Detail by Vendor, add in order details to the dataset

/* IS USED IN .Net AT THIS POINT - \AdvantageFramework.BLogic\Reporting\Methods.vb(11896): MediaPlanComparisonDetailByVendors = ... */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

--=============================================================================
--A. NEW EXTRACTION SPROCS FOR MEDIA ORDER DETAIL DATA - FILTERS ON ORDER TYPE AND DATE RANGE	--#26
--=============================================================================	
--1. Print detail (dbo.advsp_media1_order_print_detail_active)
CREATE TABLE #print_detail(
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
 INSERT INTO #print_detail EXECUTE dbo.advsp_media1_order_print_detail_active @order_status, @start_date, @end_date,
	@include_internet, @include_magazine, @include_newspaper, @include_outofhome		
 --SELECT * FROM #print_detail 
 
 --2. Broadcast detail (new) (dbo.advsp_media1_order_bcst_detail2_active)
CREATE TABLE #bcst_new_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL, 
	ACTIVE_REV						smallint NULL,
	LINK_DETID						int NULL,
	BUY_TYPE						varchar(12) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[START_DATE]					smalldatetime NULL,
	END_DATE						smalldatetime NULL,
	MONTH_NBR						smallint NULL,
	YEAR_NBR						smallint NULL,
	DATE1							smalldatetime NULL,
	DATE2							smalldatetime NULL,
	DATE3							smalldatetime NULL,
	DATE4							smalldatetime NULL,
	DATE5							smalldatetime NULL,
	DATE6							smalldatetime NULL,
	DATE7							smalldatetime NULL,
	[DAYS]							varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SPOTS1							int NULL,
	SPOTS2							int NULL,
	SPOTS3							int NULL,
	SPOTS4							int NULL,
	SPOTS5							int NULL,
	SPOTS6							int NULL,
	SPOTS7							int NULL,
	TOTAL_SPOTS						int NULL,
	JOB_NUMBER						int NULL,
	JOB_COMPONENT_NBR				smallint NULL,
	START_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	END_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[LENGTH]						smallint NULL,
	CLOSE_DATE						smalldatetime NULL,
	MATL_CLOSE_DATE					smalldatetime NULL,   
	EXT_CLOSE_DATE					smalldatetime NULL,
	EXT_MATL_DATE					smalldatetime NULL,   
	MAT_COMP						smalldatetime NULL,   
	AD_NUMBER						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PROGRAMMING						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAG								varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	REMARKS							varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE							decimal(16,4) NULL,
	GROSS_RATE						decimal(16,4) NULL,
	NET_RATE						decimal(16,4) NULL,
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
	NETCHARGE						decimal(16,4) NULL,
	NCDESC							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADDL_CHARGE						decimal(14,2) NULL,
	ADDL_CHARGE_DESC				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL,
	NON_BILL_FLAG					smallint NULL,
	RECONCILE_FLAG					smallint NULL,
	DATE_TO_BILL					smalldatetime,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_TYPE							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_SEQ						smallint NULL,
	EST_NBR							int NULL,
	EST_LINE_NBR					smallint NULL,
	EST_REV_NBR						smallint NULL,
	MONDAY							smallint NULL,
	TUESDAY							smallint NULL,
	WEDNESDAY						smallint NULL,
	THURSDAY						smallint NULL,
	FRIDAY							smallint NULL,
	SATURDAY						smallint NULL,
	SUNDAY							smallint NULL,
	NETWORK_ID						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GRP								decimal(18,5) NULL,
	GROSS_IMPRESSIONS				decimal(18,5) NULL,
	MEDIA_DEMO_DESCRIPTION			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BOOKEND							bit NULL,
	VALUE_ADDED						bit NULL)
INSERT INTO #bcst_new_detail EXECUTE dbo.advsp_media1_order_bcst_detail2_active @order_status, 
	@start_month, @start_year, @end_month, @end_year, @include_radio, @include_television				
--SELECT * FROM #bcst_new_detail

--4. Broadcast comments (new) (dbo.advsp_media1_order_bcst_detail2)
CREATE TABLE #bcst_new_comments(
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	INSTRUCTIONS					text,
	ORDER_COPY						text,
	MATL_NOTES						text,
	POSITION_INFO					text, 
	CLOSE_INFO						text, 
	RATE_INFO						text, 
	MISC_INFO						text, 
	IN_HOUSE_CMTS					text)
INSERT INTO #bcst_new_comments EXECUTE dbo.advsp_media1_order_bcst_comments2 @user_id
--SELECT * FROM #bcst_new_comments

--=============================================================================
--B. CONSOLIDATE DETAIL DATA INTO TEMP TABLE #media_order_detail
--=============================================================================
CREATE TABLE #media_order_detail (
	[USER_ID]					varchar(100) NOT NULL,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR					int NOT NULL,
	LINE_NBR					smallint NOT NULL,
	REV_NBR						smallint NULL,
	SEQ_NBR						tinyint NULL,
	DATE_TYPE					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[MONTH]						tinyint NULL,
	[YEAR]						smallint NULL,
	INSERT_DATE					smalldatetime,
	END_DATE					smalldatetime,
	DATE_TO_BILL				smalldatetime,
	CLOSE_DATE					smalldatetime,
	MATL_CLOSE_DATE				smalldatetime,
	EXT_CLOSE_DATE				smalldatetime,
	EXT_MATL_DATE				smalldatetime,
	LINE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AD_SIZE						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EDITION_ISSUE				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SECTION						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MATERIAL					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PLACEMENT_1					varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#40
	PLACEMENT_2					varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#40
	REMARKS						text,
	PROJ_IMPRESSIONS			int NULL,													--#40
	ACT_IMPRESSIONS				int NULL,													--#40
	URL							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COPY_AREA					text,
	MATL_NOTES					text,
	POSITION_INFO				text,
	MISC_INFO					text,
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	COST_TYPE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE_TYPE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	PRINT_LINES					decimal(11,2) NULL,							--#13
	GUARANTEED_IMPRESS			int NULL,
	NON_BILL_FLAG				tinyint NULL DEFAULT 0,
	LINE_CANCELLED				tinyint NULL DEFAULT 0,
	BILLED_TYPE_FLAG			tinyint NULL DEFAULT 0,
	LINK_ID						int NULL,
	SPOTS						int NULL,
	PRINT_QUANTITY				decimal(14,3) NULL,											--#13
	CIRCULATION					int NULL,													--#18
	RATE_INFO					text,														--#18
	BUY_TYPE					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DATE1						smalldatetime,
	DATE2						smalldatetime,
	DATE3						smalldatetime,
	DATE4						smalldatetime,
	DATE5						smalldatetime,
	DATE6						smalldatetime,
	DATE7						smalldatetime,
	MONDAY						smallint NULL,
	TUESDAY						smallint NULL,
	WEDNESDAY					smallint NULL,
	THURSDAY					smallint NULL,
	FRIDAY						smallint NULL,
	SATURDAY					smallint NULL,
	SUNDAY						smallint NULL,
	SPOTS1						int NULL,
	SPOTS2						int NULL,
	SPOTS3						int NULL,
	SPOTS4						int NULL,
	SPOTS5						int NULL,
	SPOTS6						int NULL,
	SPOTS7						int NULL,
	AD_NUMBER					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MAT_COMP					smalldatetime,
	PROGRAMMING					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	START_TIME					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	END_TIME					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAG							varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	NETWORK_ID					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[DAYS]						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,														--#18
	IN_HOUSE_CMTS				text,	
	[LOCATION]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[CREATIVE_SIZE]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS
	)

	
--1. Print detail

--#41 - Internet
UPDATE A
SET A.REV_NBR = B.REV_NBR
FROM #print_detail A JOIN 
(SELECT A.ORDER_NBR, A.LINE_NBR, A.REV_NBR FROM INTERNET_DETAIL A JOIN #print_detail B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR 
	WHERE A.ACTIVE_REV = 1) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
--#41 - Outdoor
UPDATE A
SET A.REV_NBR = B.REV_NBR
FROM #print_detail A JOIN 
(SELECT A.ORDER_NBR, A.LINE_NBR, A.REV_NBR FROM OUTDOOR_DETAIL A JOIN #print_detail B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR 
	WHERE A.ACTIVE_REV = 1) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR

--SELECT * FROM #print_detail ORDER BY ORDER_NBR --#41

INSERT INTO #media_order_detail
	([USER_ID], ORDER_TYPE, ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, EXT_CLOSE_DATE, EXT_MATL_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS, PRINT_QUANTITY, CIRCULATION, RATE_INFO, IN_HOUSE_CMTS, AD_NUMBER,
	PLACEMENT_1, PLACEMENT_2, PROJ_IMPRESSIONS, ACT_IMPRESSIONS, [LOCATION], [CREATIVE_SIZE]) --#39 --40 --41
SELECT
	@user_id,
	d.ORDER_TYPE,
	d.ORDER_NBR, 
	d.LINE_NBR,
	d.REV_NBR, --0,
	0,
	'PRN',
	MONTH(d.[START_DATE]),
	YEAR(d.[START_DATE]),
	d.[START_DATE],
	d.END_DATE,
	d.DATE_TO_BILL,
	d.CLOSE_DATE,
	d.MATL_CLOSE_DATE,
	d.EXT_CLOSE_DATE, 
	d.EXT_MATL_DATE,
	d.HEADLINE,
	d.SIZE,
	d.EDITION_ISSUE,
	d.SECTION,
	d.MATERIAL,
	NULL,
	d.URL,
	d.COPY_AREA,
	d.MATL_NOTES,
	d.POSITION_INFO,
	d.MISC_INFO,
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	d.COST_TYPE,
	d.RATE_TYPE,
	d.PRINT_LINES,				
	d.GUARANTEED_IMPRESS,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	d.LINK_DETID,
	0,																						--#07 (SPOTS are not applicable for print)
	d.PRINT_QUANTITY,																		--#13
	d.CIRCULATION,																			--#18
	d.RATE_INFO,																			--#18
	d.IN_HOUSE_CMTS,
	d.AD_NUMBER,	
	d.PLACEMENT_1,																--#40
	d.PLACEMENT_2, 																--#40
	d.PROJ_IMPRESSIONS, 														--#40
	d.ACT_IMPRESSIONS,															--#40																				
	d.[LOCATION],										--#41	
	d.[CREATIVE_SIZE]									--#41
FROM #print_detail AS d
--SELECT * FROM #media_order_detail

--2. Broadcast detail (new)
INSERT INTO #media_order_detail
	([USER_ID], ORDER_TYPE, ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, EXT_CLOSE_DATE, EXT_MATL_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS, PRINT_QUANTITY, CIRCULATION, RATE_INFO, 
	BUY_TYPE, DATE1, DATE2, DATE3, DATE4, DATE5, DATE6, DATE7, MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY, 
	SPOTS1, SPOTS2, SPOTS3, SPOTS4, SPOTS5, SPOTS6, SPOTS7, AD_NUMBER, MAT_COMP, PROGRAMMING, START_TIME, END_TIME, TAG, NETWORK_ID, [DAYS])
SELECT
	@user_id,
	d.ORDER_TYPE, 
	d.ORDER_NBR,
	d.LINE_NBR,
	0,
	0,
	'BRD',
	d.MONTH_NBR,			--MONTH(d.[START_DATE]),										--#14
	d.YEAR_NBR,				--YEAR(d.[START_DATE]),											--#14
	d.[START_DATE],
	d.[END_DATE],
	d.DATE_TO_BILL,
	d.CLOSE_DATE,
	d.MATL_CLOSE_DATE,
	d.EXT_CLOSE_DATE,
	d.EXT_MATL_DATE,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	d.REMARKS,
	NULL,
	NULL,
	c.MATL_NOTES,
	c.POSITION_INFO,
	c.MISC_INFO,																			--#06
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	NULL,
	NULL,
	NULL,
	NULL,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	d.LINK_DETID,
	d.TOTAL_SPOTS,																			--#07
	NULL,																					--#13
	NULL,																					--#18
	c.RATE_INFO,																			--#18
	d.BUY_TYPE,
	d.DATE1,
	d.DATE2,
	d.DATE3,
	d.DATE4,
	d.DATE5,
	d.DATE6,
	d.DATE7,
	d.MONDAY,
	d.TUESDAY,
	d.WEDNESDAY,
	d.THURSDAY,
	d.FRIDAY,
	d.SATURDAY,
	d.SUNDAY,
	d.SPOTS1,
	d.SPOTS2,
	d.SPOTS3,
	d.SPOTS4,
	d.SPOTS5,
	d.SPOTS6,
	d.SPOTS7,
	d.AD_NUMBER,
	d.MAT_COMP,
	d.PROGRAMMING,
	d.START_TIME,
	d.END_TIME,
	d.TAG,
	d.NETWORK_ID,
	d.[DAYS]
FROM #bcst_new_detail AS d
LEFT JOIN #bcst_new_comments AS c
	ON d.ORDER_NBR = c.ORDER_NBR
	AND d.LINE_NBR = c.LINE_NBR	
--SELECT * FROM #media_order_detail ORDER BY ORDER_NBR	--WHERE DATE_TYPE = 'PRN' 

--=============================================================================
--C. POPULATE dbo.MEDIA_RPT_ORDERS BASED ON #media_order_detail
--=============================================================================
DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id)	--#35
INSERT INTO dbo.MEDIA_RPT_ORDERS
SELECT DISTINCT @user_id, d.ORDER_NBR, d.ORDER_TYPE
FROM #media_order_detail AS d
--SELECT * FROM dbo.MEDIA_RPT_ORDERS WHERE [USER_ID] = @user_id

--=============================================================================
--D. ORIGINAL EXTRACTION SPROCS FOR MEDIA ORDER HEADER DATA
--=============================================================================
--1. Print Header (dbo.advsp_media1_order_print_header)
CREATE TABLE #print_order_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	ORDER_DATE						smalldatetime NULL,
	MODIFIED_DATE					smalldatetime NULL,
	REVISED_FLAG					smallint NULL,
	ORDER_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_ID							int NULL,
	OFFICE_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER					int NULL,
	NET_GROSS						smallint NULL,
	ORD_PROCESS_CONTRL				smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_REF						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PUB								smallint NULL,
	VR_CODE							varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REP1							smallint NULL,
	VR_CODE2						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REP2							smallint NULL,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	PRINTED							smallint NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	UNITS							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_ACCEPTED					tinyint NULL)
INSERT INTO #print_order_header EXECUTE dbo.advsp_media1_order_print_header @user_id
--SELECT * FROM #print_order_header	

--2. Broadcast Header (new) (dbo.advsp_media1_order_bcst_header2)
CREATE TABLE #bcst_new_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	UNITS							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_NBR						int NOT NULL,
	MAX_REV							smallint NULL,
	LINK_ID							int NULL, 
	OFFICE_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DATE						smalldatetime NULL, 
	VN_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE							varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE2						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER					int NULL,
	NET_GROSS						smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORD_PROCESS_CONTRL				smallint NULL,
	STATION							smallint NULL,
	REP1							smallint NULL,
	REP2							smallint NULL,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	CREATE_DATE						smalldatetime NULL,
	[START_DATE]					smalldatetime NULL,
	END_DATE						smalldatetime NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_ACCEPTED					tinyint NULL)
INSERT INTO #bcst_new_header EXECUTE dbo.advsp_media1_order_bcst_header2 @user_id
--SELECT * FROM #bcst_new_header	

--=============================================================================
--E. CONSOLIDATE HEADER DATA INTO TEMP TABLE #media_order_header
--=============================================================================
CREATE TABLE #media_order_header (
	[USER_ID]					varchar(100) NOT NULL,
	[TYPE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	ORDER_NBR					int NOT NULL,
	REV_NBR						smallint NULL,
	OFFICE_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIDIVPRD					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT				text,
	VN_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VR_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VR_CODE2					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER				smallint NULL,
	CMP_NAME					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILL_TYPE_FLAG				tinyint NULL,
	POST_BILL					tinyint NULL,
	NET_GROSS					tinyint NULL,
	MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MARKET_DESC					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_DATE					smalldatetime NULL,
	FLIGHT_FROM					smalldatetime NULL,
	FLIGHT_TO					smalldatetime NULL,
	ORD_PROCESS_CONTRL			tinyint NULL,
	BUYER						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_PO					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_ID						int NULL,
	ADVAN_TYPE					tinyint NULL,
	ORDER_ACCEPTED				tinyint NULL,
	FISCAL_PERIOD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#18
	BILL_COOP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#19
	HOUSE_COMMENT				text)

--1. Print header
INSERT INTO #media_order_header
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED, FISCAL_PERIOD_CODE, BILL_COOP_CODE, HOUSE_COMMENT)
SELECT
	@user_id,
	CASE h.ORDER_TYPE
		WHEN 'I' THEN 'INT'
		WHEN 'M' THEN 'MAG'
		WHEN 'N' THEN 'NEWS'
		WHEN 'O' THEN 'OUT'
	END,
	h.ORDER_NBR,
	0,
	h.OFFICE_CODE,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	NULL,
	h.ORDER_DESC,
	h.ORDER_COMMENT,
	h.VN_CODE,
	h.VR_CODE,
	h.VR_CODE2,
	c.CMP_CODE,
	h.CMP_IDENTIFIER,
	c.CMP_NAME,
	h.MEDIA_TYPE,
	CASE
		WHEN p.PRD_MAG_COM_ONLY = 1 THEN 1
		WHEN p.PRD_MAG_BILL_NET = 1 THEN 2
		ELSE 3
	END,
	ISNULL(p.PRD_MAG_PRE_POST,0),
	h.NET_GROSS,
	h.MARKET_CODE,
	m.MARKET_DESC,
	h.ORDER_DATE,
	NULL,
	NULL,
	h.ORD_PROCESS_CONTRL,
	h.BUYER,
	CASE WHEN cp.CLIENT_PO_DESCRIPTION IS NOT NULL THEN cp.CLIENT_PO_DESCRIPTION ELSE h.CLIENT_PO END,
	h.LINK_ID,
	2,
	ISNULL(h.ORDER_ACCEPTED,0),			--h.ORDER_ACCEPTED in v6.60.03
	h.FISCAL_PERIOD_CODE,																	--#18	
	h.BILL_COOP_CODE,																		--#19	
	h.HOUSE_COMMENT																			
FROM #print_order_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
LEFT JOIN dbo.CLIENT_PO AS cp
	ON h.CLIENT_PO = cp.CLIENT_PO_NUMBER

--SELECT * FROM #media_order_header

--2. Broadcast header (new)
INSERT INTO #media_order_header
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED, FISCAL_PERIOD_CODE, BILL_COOP_CODE, HOUSE_COMMENT)
SELECT
	@user_id,	
	CASE h.ORDER_TYPE
		WHEN 'R' THEN 'RADIO'
		WHEN 'T' THEN 'TV'
	END,
	h.ORDER_NBR,
	0,
	h.OFFICE_CODE,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	NULL,
	h.ORDER_DESC,
	h.ORDER_COMMENT,
	h.VN_CODE,
	h.VR_CODE,
	h.VR_CODE2,
	c.CMP_CODE,
	h.CMP_IDENTIFIER,
	c.CMP_NAME,
	h.MEDIA_TYPE,
	CASE
		WHEN p.PRD_RADIO_COM_ONLY = 1 THEN 1
		WHEN p.PRD_RADIO_BILL_NET = 1 THEN 2
		ELSE 3
	END,
	ISNULL(p.PRD_RADIO_PRE_POST,0),
	h.NET_GROSS,
	h.MARKET_CODE,
	m.MARKET_DESC,
	h.ORDER_DATE,
	NULL,
	NULL,
	h.ORD_PROCESS_CONTRL,
	h.BUYER,
	CASE WHEN cp.CLIENT_PO_DESCRIPTION IS NOT NULL THEN cp.CLIENT_PO_DESCRIPTION ELSE h.CLIENT_PO END,
	h.LINK_ID,
	2,
	ISNULL(h.ORDER_ACCEPTED,0),				--h.ORDER_ACCEPTED in v6.60.03
	h.FISCAL_PERIOD_CODE,																	--#18	
	h.BILL_COOP_CODE,																		--#19	
	h.HOUSE_COMMENT																				
FROM #bcst_new_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
LEFT JOIN dbo.CLIENT_PO AS cp
	ON h.CLIENT_PO = cp.CLIENT_PO_NUMBER

--SELECT * FROM #media_order_header ORDER BY VN_CODE

--=============================================================================
--F. ORIGINAL EXTRACTION SPROCS FOR MEDIA ORDER AMOUNTS DATA (see Adrpts macro "MedRpts OrderDetail")
--=============================================================================
--1. Print amounts (dbo.advsp_media1_order_print_amounts)
 CREATE TABLE #print_amounts(
	REC_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
	ACTIVE_REV						smallint NULL,
	COLOR_CHARGE					decimal(15,4) NULL,
	COLOR_DESC						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BLEED_AMT						decimal(15,2) NULL,
	POSITION_AMT					decimal(15,2) NULL,
	PREMIUM_AMT						decimal(15,2) NULL,
	NON_BILL_FLAG					smallint NULL,
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL,								 
	FLAT_GROSS						decimal(15,2) NULL, 								 
	FLAT_NET						decimal(15,2) NULL,
	GROSS_RATE						decimal(16,4) NULL,
	NET_RATE						decimal(16,4) NULL,
	DISCOUNT_AMT					decimal(15,2) NULL,
	ADDL_CHARGE						decimal(15,2) NULL, 
	NETCHARGE						decimal(15,2) NULL, 
	NETCHARGE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	NON_RESALE_AMT					decimal(15,2) NULL, 
	STATE_AMT						decimal(15,2) NULL, 
	COUNTY_AMT						decimal(15,2) NULL, 
	CITY_AMT						decimal(15,2) NULL, 
	COMM_AMT						decimal(15,2) NULL, 
	REBATE_AMT						decimal(15,2) NULL, 
	EXT_NET_AMT						decimal(15,2) NULL, 
	EXT_GROSS_AMT					decimal(15,2) NULL, 
	LINE_TOTAL						decimal(15,2) NULL, 
	BILLING_AMT						decimal(15,2) NULL,
	PRINT_QUANTITY					decimal(14,3) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT							int NULL,
	AR_INV_DATE						smalldatetime,
	AR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #print_amounts EXECUTE dbo.advsp_media1_order_print_amounts @user_id
--SELECT * FROM #print_amounts

--2. Print amounts AP (advsp_media1_order_print_amounts_ap)
CREATE TABLE #print_amounts_ap(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, 
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_DISBURSED_AMT				decimal(15,2) NULL,	
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL,			
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT						int NULL,
	AP_INV_DATE						datetime NULL,
	AP_PAYMENT_HOLD					smallint NULL,
	AP_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_PRINT_QUANTITY				decimal(14,3) NULL,
	AP_ID							int NULL)												--#15
INSERT INTO #print_amounts_ap EXECUTE advsp_media1_order_print_amounts_ap @user_id
--SELECT * FROM #print_amounts_ap

--3. Print amounts AP addl (advsp_media1_order_print_amounts_ap_addl)
CREATE TABLE #print_amounts_ap_addl(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, 
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_DISBURSED_AMT				decimal(15,2) NULL,	
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL)
INSERT INTO #print_amounts_ap_addl EXECUTE advsp_media1_order_print_amounts_ap_addl @user_id
--SELECT * FROM #print_amounts_ap_addl 

--4. Broadcast amounts (new) (dbo.advsp_media1_order_bcst_amounts2)
CREATE TABLE #bcst_new_amounts(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL, 
	REV_NBR							smallint NULL, 
	SEQ_NBR							smallint NULL, 
	MONTH_IND						smallint NULL, 
	MONTH_SHORT						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	BRDCAST_YEAR					int NULL,
	BRDCAST_PER						int NULL, 
	SPOTS1							int NULL,
	SPOTS2							int NULL,
	SPOTS3							int NULL,
	SPOTS4							int NULL,
	SPOTS5							int NULL,
	SPOTS6							int NULL,
	SPOTS7							int NULL, 
	SPOTS							int NULL,
	LINE_NET						decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT						decimal(15,2) NULL,
	VENDOR_TAX						decimal(15,2) NULL,
	STATE_TAX						decimal(15,2) NULL,
	COUNTY_TAX						decimal(15,2) NULL,
	CITY_TAX						decimal(15,2) NULL,
	NETCHARGE						decimal(15,2) NULL,
	ADDL_CHARGE						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILL_TYPE_FLAG					smallint NULL,
	GRP								decimal(18,5) NULL,
	GROSS_IMPRESSIONS				decimal(18,5) NULL,
	MEDIA_DEMO_DESCRIPTION			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BOOKEND							bit NULL,
	VALUE_ADDED						bit NULL,
	GLEXACT							int NULL,
	AR_INV_DATE						smalldatetime,
	AR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #bcst_new_amounts EXECUTE dbo.advsp_media1_order_bcst_amounts2 @user_id
--SELECT * FROM #bcst_new_amounts

--5. Broadcast amounts AP (new) (advsp_media1_order_bcst_amounts_ap2)
CREATE TABLE #bcst_new_amounts_ap(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, 
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL,		
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT						int NULL,
	AP_INV_DATE						datetime NULL,
	AP_PAYMENT_HOLD					smallint NULL,
	AP_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TOTAL_SPOTS						int,
	AP_ID							int NULL)												--#15
INSERT INTO #bcst_new_amounts_ap EXECUTE advsp_media1_order_bcst_amounts_ap2 @user_id
--SELECT * FROM #bcst_new_amounts_ap

--6. Broadcast amounts AP addl (new) (advsp_media1_order_bcst_amounts_ap_addl2)
CREATE TABLE #bcst_new_amounts_ap_addl(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, 
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_DISBURSED_AMT				decimal(15,2) NULL,	
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL)
INSERT INTO #bcst_new_amounts_ap_addl EXECUTE advsp_media1_order_bcst_amounts_ap_addl2 @user_id
--SELECT * FROM #bcst_new_amounts_ap_addl

--=============================================================================
--G. POPULATE AP/AR PAYMENT FLAG TEMP TABLES #ap_payment_flag AND #ar_payment_flag
--=============================================================================
-- Accounts Payable------------------------------------------------------------				--#15
-- Temp table #media_apid to store media AP_ID's to process	
CREATE TABLE #media_apid(AP_ID int NOT NULL)
INSERT INTO #media_apid
SELECT DISTINCT AP_ID
FROM #print_amounts_ap	
WHERE AP_ID IS NOT NULL
INSERT INTO #media_apid
SELECT DISTINCT AP_ID
FROM #bcst_new_amounts_ap	
WHERE AP_ID IS NOT NULL
--SELECT * FROM #media_apid ORDER BY AP_ID

--1. AP header
CREATE TABLE #ap_header(AP_ID int NULL, AP_INV_AMT decimal(15,2) NULL) 
INSERT INTO #ap_header
SELECT
	h.AP_ID,
	SUM(ISNULL(h.AP_INV_AMT,0) + ISNULL(h.AP_SHIPPING,0) + ISNULL(h.AP_SALES_TAX,0))
FROM dbo.AP_HEADER AS h
JOIN #media_apid AS a
	ON h.AP_ID = a.AP_ID
GROUP BY h.AP_ID

--2. AP disbursements
CREATE TABLE #ap_disbursement(																
	AP_ID							int NULL, 
	AP_PMT_AMT						decimal(15,2) NULL, 
	AP_CHK_NBR						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,		--#20
	AP_CHK_DATE						datetime) 
INSERT INTO #ap_disbursement
SELECT
	p.AP_ID,
	SUM(ISNULL(p.AP_CHK_AMT,0) + ISNULL(p.AP_DISC_AMT,0)),
	dbo.advfn_ap_max_check_number(p.AP_ID, MAX(p.AP_CHK_DATE)),
	MAX(p.AP_CHK_DATE)
FROM dbo.AP_PMT_HIST AS p
JOIN #media_apid AS a
	ON p.AP_ID = a.AP_ID
GROUP BY p.AP_ID
--SELECT * FROM #ap_disbursement

--3. AP reconciliation and payment flag
CREATE TABLE #ap_payment_flag(
	AP_ID							int NULL, 
	AP_PMT_FLAG						tinyint NULL, 
	AP_CHK_NBR						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_CHK_DATE						datetime)
INSERT INTO #ap_payment_flag
SELECT
	h.AP_ID,
	CASE
		WHEN ISNULL(p.AP_PMT_AMT,0) = 0 THEN 0
		WHEN h.AP_INV_AMT = p.AP_PMT_AMT THEN 1												--#17
		ELSE 2																				--#17
	END AS AP_PMT_FLAG,
	p.AP_CHK_NBR,																			--#20, #22
	p.AP_CHK_DATE	
FROM #ap_header AS h
LEFT JOIN #ap_disbursement AS p
	ON h.AP_ID = p.AP_ID
--SELECT * FROM #ap_payment_flag ORDER BY AP_ID

--Accounts Receivable----------------------------------------------------------				--#16
--Temp table #ar_invoices to store list of invoices to process
CREATE TABLE #ar_invoices(AR_INV_NBR int NOT NULL)
INSERT INTO #ar_invoices
SELECT DISTINCT AR_INV_NBR
FROM #print_amounts
WHERE AR_INV_NBR IS NOT NULL
INSERT INTO #ar_invoices
SELECT DISTINCT AR_INV_NBR
FROM #bcst_new_amounts
WHERE AR_INV_NBR IS NOT NULL
--SELECT * FROM #ar_invoices ORDER BY AR_INV_NBR

--4. Accounts receivable
CREATE TABLE #aged_ar (
	AR_INV_NBR							int NOT NULL,
	AR_INV_AMOUNT						decimal(15,2)) 
INSERT INTO #aged_ar
SELECT
	d.AR_INV_NBR,
	SUM(ISNULL(d.AR_INV_AMOUNT,0))
FROM dbo.ACCT_REC AS d
JOIN #ar_invoices AS i
	ON d.AR_INV_NBR = i.AR_INV_NBR
WHERE (d.AR_INV_SEQ = 0 OR d.AR_INV_SEQ = 99)
GROUP BY d.AR_INV_NBR
HAVING ABS(SUM(ISNULL(d.AR_INV_AMOUNT,0))) >= .01

--5. AR cash receipts
CREATE TABLE #cash_receipts (
	AR_INV_NBR							int NOT NULL,
	CR_PAY_AMT							decimal(15,2) NULL,
	CR_ADJ_AMT							decimal(15,2) NULL,
	CR_TOT_AMT							decimal(15,2) NULL,
	CR_CHECK_DATE						datetime,
	CR_DEP_DATE							datetime,
	CR_CHECK_NBR						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS)	--#20
INSERT INTO #cash_receipts
SELECT
	d.AR_INV_NBR,
	SUM(ISNULL(d.CR_PAY_AMT,0)),
	SUM(ISNULL(d.CR_ADJ_AMT,0)),
	SUM(ISNULL(d.CR_PAY_AMT,0)) + SUM(ISNULL(d.CR_ADJ_AMT,0)),
	MAX(c.CR_CHECK_DATE),
	MAX(c.CR_DEP_DATE),
	dbo.advfn_ar_max_check_number(d.AR_INV_NBR, MAX(c.CR_CHECK_DATE))						--#20
FROM dbo.CR_CLIENT_DTL AS d
JOIN dbo.CR_CLIENT AS c
	ON d.REC_ID = c.REC_ID
	AND d.SEQ_NBR = c.SEQ_NBR	
JOIN #aged_ar AS a
	ON d.AR_INV_NBR = a.AR_INV_NBR
GROUP BY d.AR_INV_NBR
--SELECT * FROM #cash_receipts

--6. AR reconciliation and payment flag
CREATE TABLE #ar_payment_flag(
	AR_INV_NBR						int NULL,
	CR_PAYMENT_FLAG					tinyint NULL,
	CR_CHECK_NBR					varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CR_CHECK_DATE					datetime,
	CR_DEP_DATE						datetime,
	BAL_AMOUNT						decimal(15,2) NULL)
INSERT INTO #ar_payment_flag
SELECT
	a.AR_INV_NBR,
	CASE
		WHEN ISNULL(c.CR_TOT_AMT,0) = 0 THEN 0
		WHEN a.AR_INV_AMOUNT - ISNULL(c.CR_TOT_AMT,0) = 0 THEN 1							--#17
		ELSE 2																				--#17
	END AS CR_PAYMENT_FLAG,	
	--dbo.advfn_ar_max_check_number(a.AR_INV_NBR, c.CR_CHECK_DATE),
	c.CR_CHECK_NBR,																			--#20
	c.CR_CHECK_DATE,
	c.CR_DEP_DATE,
	a.AR_INV_AMOUNT - ISNULL(c.CR_TOT_AMT,0) AS BAL_AMOUNT
FROM #aged_ar AS a
LEFT JOIN #cash_receipts AS c
	ON a.AR_INV_NBR = c.AR_INV_NBR	
--SELECT * FROM #ar_payment_flag

--=============================================================================
--H. CONSOLIDATE AMOUNTS DATA INTO TEMP TABLE #media_order_amounts
--=============================================================================
CREATE TABLE #media_order_amounts (
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REC_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL,
	LINE_NBR				smallint NULL,
	REV_NBR					tinyint NULL DEFAULT 0,
	SEQ_NBR					tinyint NULL DEFAULT 0,
	[MONTH]					tinyint NULL,
	[YEAR]					smallint NULL,
	EXT_NET_AMT				decimal(15,2) NULL DEFAULT 0,
	NETCHARGES				decimal(15,2) NULL DEFAULT 0,
	DISCOUNTS				decimal(15,2) NULL DEFAULT 0,
	ADDL_CHARGE				decimal(15,2) NULL DEFAULT 0,
	COMM_AMT				decimal(15,2) NULL DEFAULT 0,
	REBATE_AMT				decimal(15,2) NULL DEFAULT 0,
	VENDOR_TAX				decimal(15,2) NULL DEFAULT 0,
	RESALE_TAX				decimal(15,2) NULL DEFAULT 0,
	LINE_TOTAL				decimal(15,2) NULL DEFAULT 0,
	NET_TOTAL_AMT			decimal(15,2) NULL DEFAULT 0,
	VENDOR_NET_AMT			decimal(15,2) NULL DEFAULT 0,
	BILL_AMT				decimal(15,2) NULL DEFAULT 0,
	RECNB_BILL_AMT			decimal(15,2) NULL DEFAULT 0,
	RECNB_NET_AMT			decimal(15,2) NULL DEFAULT 0,
	SPOTS_QTY				int NULL DEFAULT 0,
	NON_BILL_FLAG			tinyint NULL DEFAULT 0,
	LINE_CANCELLED			tinyint NULL DEFAULT 0,
	BILL_TYPE_FLAG			tinyint NULL DEFAULT 0,
	BILLED_EXT_NET_AMT		decimal(15,2) NULL DEFAULT 0,
	BILLED_DISC_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_NC_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_VTAX_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_NET_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_ADDL_CHARGE		decimal(15,2) NULL DEFAULT 0,
	BILLED_COMM_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_REBATE_AMT		decimal(15,2) NULL DEFAULT 0,
	BILLED_RTAX_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_BILL_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_SPOTS_QTY		int NULL DEFAULT 0,
	AR_INV_NBR				int NULL,
	AR_INV_DATE				datetime NULL,													--#32
	AR_SEQ					smallint NULL,
	AR_TYPE					varchar(2) NULL,
	GLXACT_BILL				int NULL,
	AP_NET_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_NETCHARGES_AMT		decimal(15,2) NULL DEFAULT 0,
	AP_DISC_AMT_AMT			decimal(15,2) NULL DEFAULT 0,
	AP_COMM_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_REBATE_AMT			decimal(15,2) NULL DEFAULT 0,
	AP_VTAX_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_RTAX_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_DISBURSED_AMT		decimal(15,2) NULL DEFAULT 0,									--#30
	AP_BILL_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_LINE_TOTAL			decimal(15,2) NULL DEFAULT 0,
	AP_SPOTS_QTY			int NULL DEFAULT 0,
	AP_INV_NBR				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE				datetime NULL,													--#32
	GLXACT_AP				int NULL,
	AP_ID					int NULL,														--#15
	AP_PAYMENT_FLAG			tinyint NULL DEFAULT 0,
	AP_CHK_NBR				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_CHK_DATE				datetime NULL,
	AP_PAYMENT_AMT			decimal(15,2) NULL DEFAULT 0,
	CR_PAYMENT_FLAG			tinyint NULL DEFAULT 0,
	CR_CHECK_NBR			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CR_CHECK_DATE			datetime NULL,
	CR_DEP_DATE				datetime NULL,
	CR_PAYMENT_AMT			decimal(15,2) NULL DEFAULT 0)
	
--1. Print ORDER data - (see Adrpts query "MedRpts OrderDetail Print")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	EXT_NET_AMT,
	NETCHARGES,
	DISCOUNTS,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	RESALE_TAX,
	LINE_TOTAL,
	NET_TOTAL_AMT,
	VENDOR_NET_AMT,
	BILL_AMT,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	SPOTS_QTY)
SELECT
	@user_id,
	ORDER_TYPE,
	'O',
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT
		ELSE 0																				--#32
	END,
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NETCHARGE
		ELSE 0																				--#32
	END,		
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN DISCOUNT_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN ADDL_CHARGE
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN COMM_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN REBATE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NON_RESALE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 AND ACTIVE_REV = 1 THEN CITY_AMT + COUNTY_AMT + STATE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN LINE_TOTAL
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1  AND BILL_TYPE_FLAG <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN BILLING_AMT
		ELSE 0																				--#32
	END,		
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	CASE																					--#12
		WHEN ORDER_TYPE = 'I' THEN PRINT_QUANTITY											--#13, #27
		WHEN ORDER_TYPE = 'N' AND COST_TYPE = 'CPM' THEN PRINT_LINES						--#13
		ELSE 0
	END
FROM #print_detail

--2. Print BILLING data - (see Adrpts query "MedRpts BilledPrint")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	BILLED_EXT_NET_AMT,
	BILLED_DISC_AMT,
	BILLED_NC_AMT,
	BILLED_VTAX_AMT,
	BILLED_NET_AMT,
	BILLED_ADDL_CHARGE,
	BILLED_COMM_AMT,
	BILLED_REBATE_AMT,
	BILLED_RTAX_AMT,
	BILLED_BILL_AMT,
	AR_INV_NBR,
	AR_INV_DATE,																			--#32
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY,
	CR_PAYMENT_FLAG,
	CR_CHECK_NBR,
	CR_CHECK_DATE,
	CR_DEP_DATE,
	CR_PAYMENT_AMT)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'B',
	a.ORDER_NBR,
	a.LINE_NBR,
	ISNULL(d.NON_BILL_FLAG,0),																--#25
	d.LINE_CANCELLED,																		--#25
	d.BILL_TYPE_FLAG,																		--#25
	a.EXT_NET_AMT,
	a.DISCOUNT_AMT,
	a.NETCHARGE,
	a.NON_RESALE_AMT,
	CASE
		WHEN a.BILL_TYPE_FLAG = 2 OR a.BILL_TYPE_FLAG = 3 THEN 
		a.EXT_NET_AMT + a.NETCHARGE + a.DISCOUNT_AMT + a.NON_RESALE_AMT
	END,
	a.ADDL_CHARGE,
	a.COMM_AMT,
	a.REBATE_AMT,
	a.CITY_AMT + a.COUNTY_AMT + a.STATE_AMT,
	a.BILLING_AMT,
	a.AR_INV_NBR,
	a.AR_INV_DATE,																			--#32
	a.AR_INV_SEQ,
	a.AR_TYPE,
	a.GLEXACT,
	CASE																					--#12
		WHEN d.ORDER_TYPE = 'I' THEN a.PRINT_QUANTITY
		WHEN d.ORDER_TYPE = 'N' AND d.COST_TYPE = 'CPM' THEN a.PRINT_QUANTITY 
		ELSE 0
	END,
	p.CR_PAYMENT_FLAG,
	p.CR_CHECK_NBR,
	p.CR_CHECK_DATE,
	p.CR_DEP_DATE,
	CASE p.CR_PAYMENT_FLAG
		WHEN 1 THEN a.BILLING_AMT
		ELSE 0
	END		
FROM #print_amounts AS a
JOIN #print_detail AS d																		--#12
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
LEFT JOIN #ar_payment_flag AS p
	ON a.AR_INV_NBR = p.AR_INV_NBR	
WHERE a.AR_INV_NBR IS NOT NULL

--3. Broadcast ORDER data (new) - (see Adrpts query "MedRpts OrderDetail Bcst2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	EXT_NET_AMT,
	NETCHARGES,
	DISCOUNTS,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	RESALE_TAX,
	LINE_TOTAL,
	NET_TOTAL_AMT,
	VENDOR_NET_AMT,
	BILL_AMT,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	SPOTS_QTY)
SELECT
	@user_id,
	ORDER_TYPE + '2',
	'O',
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT
		ELSE 0																				--#32
	END,
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NETCHARGE
		ELSE 0																				--#32
	END,		
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN DISCOUNT_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN ADDL_CHARGE
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN COMM_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN REBATE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NON_RESALE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 AND ACTIVE_REV = 1 THEN CITY_AMT + COUNTY_AMT + STATE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN LINE_TOTAL
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1  AND BILL_TYPE_FLAG <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
		ELSE 0																				--#32
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN BILLING_AMT
		ELSE 0																				--#32
	END,		
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	TOTAL_SPOTS																				--#07
FROM #bcst_new_detail

--4. Broadcast BILLING data (new) - (see Adrpts query "MedRpts BilledBcst2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	BILLED_EXT_NET_AMT,
	BILLED_DISC_AMT,
	BILLED_NC_AMT,
	BILLED_VTAX_AMT,
	BILLED_NET_AMT,
	BILLED_ADDL_CHARGE,
	BILLED_COMM_AMT,
	BILLED_REBATE_AMT,
	BILLED_RTAX_AMT,
	BILLED_BILL_AMT,
	AR_INV_NBR,
	AR_INV_DATE,																			--#32
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY,
	CR_PAYMENT_FLAG,
	CR_CHECK_NBR,
	CR_CHECK_DATE,
	CR_DEP_DATE,
	CR_PAYMENT_AMT)
SELECT
	@user_id,
	a.ORDER_TYPE + '2',
	'B',
	a.ORDER_NBR,
	a.LINE_NBR,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.LINE_NET,
	a.DISCOUNT,
	a.NETCHARGE,
	a.VENDOR_TAX,
	CASE
		WHEN d.BILL_TYPE_FLAG = 2 OR d.BILL_TYPE_FLAG = 3 THEN 
		a.LINE_NET + a.NETCHARGE + a.DISCOUNT + a.VENDOR_TAX
	END,
	a.ADDL_CHARGE,
	a.COMM_AMT,
	a.REBATE_AMT,
	a.CITY_TAX + a.COUNTY_TAX + a.STATE_TAX,
	a.BILLING_AMT,
	a.AR_INV_NBR,
	a.AR_INV_DATE,																			--#32
	a.AR_INV_SEQ,
	a.AR_TYPE,
	a.GLEXACT,
	a.SPOTS,
	p.CR_PAYMENT_FLAG,
	p.CR_CHECK_NBR,
	p.CR_CHECK_DATE,
	p.CR_DEP_DATE,
	CASE p.CR_PAYMENT_FLAG
		WHEN 1 THEN a.BILLING_AMT
		ELSE 0
	END																						--#07	
FROM #bcst_new_amounts as a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
LEFT JOIN #ar_payment_flag AS p
	ON a.AR_INV_NBR = p.AR_INV_NBR
WHERE a.AR_INV_NBR IS NOT NULL		

--5. Print AP data - (see Adrpts query "MedRpts APPrint")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_DISBURSED_AMT,																		--#30
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	AP_INV_DATE,																			--#32
	GLXACT_AP,
	AP_SPOTS_QTY,
	AP_ID,
	AP_PAYMENT_FLAG,
	AP_CHK_NBR,
	AP_CHK_DATE,
	AP_PAYMENT_AMT)																			--#15
SELECT
	@user_id,
	a.ORDER_TYPE,
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_NET_AMT,																			--#30
	a.AP_NETCHARGES,																		--#29
	a.AP_DISCOUNT_AMT,																		--#29
	a.AP_COMM_AMT,																			--#29
	a.AP_REBATE_AMT,																		--#29
	a.AP_VENDOR_TAX,																		--#29
	a.AP_STATE_TAX + a.AP_COUNTY_TAX + a.AP_CITY_TAX,										--#29
	a.AP_DISBURSED_AMT,																		--#30
	a.AP_BILLING_AMT,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_INV_DATE,																			--#32
	a.AP_GLEXACT,
	CASE																					--#12
		WHEN d.ORDER_TYPE = 'I' THEN a.AP_PRINT_QUANTITY
		WHEN d.ORDER_TYPE = 'N' AND d.COST_TYPE = 'CPM' THEN a.AP_PRINT_QUANTITY 
		ELSE 0
	END,
	a.AP_ID,
	f.AP_PMT_FLAG,
	f.AP_CHK_NBR,
	f.AP_CHK_DATE,																			--#15
	CASE f.AP_PMT_FLAG
		WHEN 1 THEN a.AP_DISBURSED_AMT														--#30
		ELSE 0
	END		
FROM #print_amounts_ap AS a
JOIN #print_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
LEFT JOIN #ap_payment_flag AS f
	ON a.AP_ID = f.AP_ID	
--SELECT * FROM #media_order_amounts							
	
--6. Print AP data additional - (see Adrpts query "MedRpts APPrint_addl")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	GLXACT_AP,
	AP_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_DISBURSED_AMT,
	0,
	0,
	0,
	0,
	0,
	0,
	a.AP_BILLING_AMT,
	a.AP_LINE_TOTAL,
	NULL,
	NULL,
	0																						--#08 spots not applicable for print AP additional
FROM #print_amounts_ap_addl AS a
JOIN #print_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR


--7. Broadcast AP data (new) - (see Adrpts query "MedRpts APBcst2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_DISBURSED_AMT,																		--#30
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	AP_INV_DATE,																			--#32
	GLXACT_AP,
	AP_SPOTS_QTY,
	AP_ID,
	AP_PAYMENT_FLAG,
	AP_CHK_NBR,
	AP_CHK_DATE,
	AP_PAYMENT_AMT)																			--#15
SELECT
	@user_id,
	a.ORDER_TYPE + '2',
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	a.[MONTH],																				--#05
	a.[YEAR],																				--#05
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_NET_AMT,																			--#30
	a.AP_NETCHARGES,																		--#29
	a.AP_DISCOUNT_AMT,																		--#29
	a.AP_COMM_AMT,																			--#29
	a.AP_REBATE_AMT,																		--#29
	a.AP_VENDOR_TAX,																		--#29
	a.AP_STATE_TAX + a.AP_COUNTY_TAX + a.AP_CITY_TAX,										--#29
	a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES,					--#30
	CASE
		WHEN BILL_TYPE_FLAG = 3 THEN a.AP_LINE_TOTAL
		ELSE a.AP_LINE_TOTAL -(a.AP_COMM_AMT + a.AP_REBATE_AMT)		
	END,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_INV_DATE,																			--#32
	a.AP_GLEXACT,
	a.TOTAL_SPOTS,																			--#08
	a.AP_ID,
	f.AP_PMT_FLAG,
	f.AP_CHK_NBR,
	f.AP_CHK_DATE,																			--#15
	CASE f.AP_PMT_FLAG
		WHEN 1 THEN a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES	--#30
		ELSE 0
	END																						--#15
FROM #bcst_new_amounts_ap AS a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
LEFT JOIN #ap_payment_flag AS f
	ON a.AP_ID = f.AP_ID	
	
--8. Broadcast AP data additional (new) - (see Adrpts query "MedRpts APBcst_addl2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	GLXACT_AP,
	AP_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE + '2',
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	[MONTH],																				--#05
	[YEAR],																					--#05
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES,
	0,
	0,
	0,
	0,
	0,
	0,
	a.AP_BILLING_AMT,
	a.AP_LINE_TOTAL,
	NULL,
	NULL,
	0																						--#08 spots not applicable for AP additional
FROM #bcst_new_amounts_ap_addl AS a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR																--#21																

--Prints temp tables for testing
--SELECT * FROM #media_order_header
--SELECT * FROM #media_order_detail
--SELECT * FROM #media_order_amounts
--SELECT * FROM #media_order_amounts WHERE ORDER_NBR = 82 
--SELECT * FROM #media_order_amounts WHERE REC_TYPE = 'A' AND ORDER_TYPE IN('M','N','I','O') ORDER BY ORDER_TYPE	--IN('M','N','I','O')	--IN('R','T','RN','TN','R2','T2')
--SELECT ma.ORDER_NBR, ma.LINE_NBR, ma.ORDER_TYPE, ma.YEAR, ma.MONTH, md.YEAR, md.MONTH  
	--FROM #media_order_amounts AS ma
	--JOIN #media_order_header AS mh
	--	ON ma.ORDER_NBR = mh.ORDER_NBR
	--JOIN #media_order_detail AS md
	--	ON ma.ORDER_NBR = md.ORDER_NBR
	--	AND ma.LINE_NBR = ma.LINE_NBR	
	--WHERE mh.ADVAN_TYPE = 1	
	----WHERE mh.ADVAN_TYPE = 2 AND md.DATE_TYPE = 'BRD'
--SELECT @user_id AS [USER_ID]

DROP TABLE #print_order_header
DROP TABLE #bcst_new_header
DROP TABLE #print_detail
DROP TABLE #bcst_new_detail
DROP TABLE #bcst_new_comments
DROP TABLE #print_amounts
DROP TABLE #print_amounts_ap
DROP TABLE #print_amounts_ap_addl
DROP TABLE #bcst_new_amounts
DROP TABLE #bcst_new_amounts_ap
DROP TABLE #bcst_new_amounts_ap_addl
DROP TABLE #aged_ar
DROP TABLE #ap_disbursement
DROP TABLE #ap_header
DROP TABLE #ap_payment_flag
DROP TABLE #ar_invoices
DROP TABLE #ar_payment_flag
DROP TABLE #cash_receipts
DROP TABLE #media_apid
--*****************************************************************************
--END OF SHARED CODE WITH advsp_media1_media_current_status1

--=============================================================================
--X. CREATES SUMMARY TABLE OF #media_order_amounts
--=============================================================================
CREATE TABLE #media_order_amounts_sum(
	  [USER_ID]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  ORDER_TYPE					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  ORDER_NBR						int NULL,
	  LINE_NBR						smallint NULL,
	  [MONTH]						tinyint NULL,
	  [YEAR]						smallint NULL,
	  EXT_NET_AMT					decimal(15,2) NULL, 
	  NETCHARGES					decimal(15,2) NULL,
	  DISCOUNTS						decimal(15,2) NULL,
	  ADDL_CHARGE					decimal(15,2) NULL, 
	  COMM_AMT						decimal(15,2) NULL,
	  REBATE_AMT					decimal(15,2) NULL,
	  VENDOR_TAX					decimal(15,2) NULL,
	  RESALE_TAX					decimal(15,2) NULL,
	  LINE_TOTAL					decimal(15,2) NULL, 
	  NET_TOTAL_AMT					decimal(15,2) NULL,
	  VENDOR_NET_AMT				decimal(15,2) NULL,
	  BILL_AMT						decimal(15,2) NULL,
	  RECNB_BILL_AMT				decimal(15,2) NULL, 
	  RECNB_NET_AMT					decimal(15,2) NULL,
	  SPOTS_QTY						int NULL,	
	  NON_BILL_FLAG					tinyint NULL,
	  LINE_CANCELLED				tinyint NULL,
	  BILL_TYPE_FLAG				tinyint NULL,
	  BILLED_EXT_NET_AMT			decimal(15,2) NULL, 
	  BILLED_DISC_AMT				decimal(15,2) NULL,
	  BILLED_NC_AMT					decimal(15,2) NULL,
	  BILLED_VTAX_AMT				decimal(15,2) NULL,
	  BILLED_NET_AMT				decimal(15,2) NULL,
	  BILLED_ADDL_CHARGE			decimal(15,2) NULL,
	  BILLED_COMM_AMT				decimal(15,2) NULL,
	  BILLED_REBATE_AMT				decimal(15,2) NULL,
	  BILLED_RTAX_AMT				decimal(15,2) NULL,
	  BILLED_BILL_AMT				decimal(15,2) NULL,
	  BILLED_SPOTS_QTY				int NULL,		  
	  AR_INV_NBR					int NULL,
	  AR_SEQ						tinyint NULL,
	  AR_TYPE						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  GLXACT_BILL					int NULL,
	  AP_NET_AMT					decimal(15,2) NULL,
	  AP_NETCHARGES_AMT				decimal(15,2) NULL, 
	  AP_DISC_AMT_AMT				decimal(15,2) NULL,
	  AP_COMM_AMT					decimal(15,2) NULL,
	  AP_REBATE_AMT					decimal(15,2) NULL,
	  AP_VTAX_AMT					decimal(15,2) NULL,
	  AP_RTAX_AMT					decimal(15,2) NULL,
	  AP_DISBURSED_AMT				decimal(15,2) NULL,										--#30
	  AP_BILL_AMT					decimal(15,2) NULL,
	  AP_LINE_TOTAL					decimal(15,2) NULL, 
	  AP_SPOTS_QTY					int NULL,			
	  AP_INV_NBR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  GLXACT_AP						int NULL,												--#15
	  AP_ID							int NULL,
	  AP_PAYMENT_FLAG				tinyint NULL DEFAULT 0,
	  AP_CHK_NBR					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  AP_CHK_DATE					datetime NULL,
	  AP_PAYMENT_AMT				decimal(15,2) NULL DEFAULT 0,
	  CR_PAYMENT_FLAG				tinyint NULL DEFAULT 0,
	  CR_CHECK_NBR					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  CR_CHECK_DATE					datetime NULL,
	  CR_DEP_DATE					datetime NULL,
	  CR_PAYMENT_AMT				decimal(15,2) NULL DEFAULT 0) 

--For all media effective with #21															--#21
INSERT INTO #media_order_amounts_sum
SELECT 
	  d.[USER_ID] AS [USER_ID],
	  LEFT(d.ORDER_TYPE,1) AS ORDER_TYPE,											
	  d.ORDER_NBR AS ORDER_NBR,
	  d.LINE_NBR AS LINE_NBR,
	  --CASE																				--#26
		 -- WHEN d.ORDER_TYPE IN('R','RN','T','TN') THEN d.[MONTH]
		 -- ELSE MONTH(dt.INSERT_DATE)
	  --END AS [MONTH],
	  --CASE
		 -- WHEN d.ORDER_TYPE IN('R','RN','T','TN') THEN d.[YEAR]
		 -- ELSE YEAR(dt.INSERT_DATE)
	  --END AS [YEAR],
	  d.[MONTH],			--COALESCE(MONTH(dt.INSERT_DATE), d.[MONTH]),					--#26
	  d.[YEAR],				--COALESCE(YEAR(dt.INSERT_DATE), d.[YEAR]),						--#26
	  SUM(d.EXT_NET_AMT) AS EXT_NET_AMT, 
	  SUM(d.NETCHARGES) AS NETCHARGES,
	  SUM(d.DISCOUNTS) AS DISCOUNTS,
	  SUM(d.ADDL_CHARGE) AS ADDL_CHARGE, 
	  SUM(d.COMM_AMT) AS COMM_AMT,
	  SUM(d.REBATE_AMT) AS REBATE_AMT,
	  SUM(d.VENDOR_TAX) AS VENDOR_TAX,
	  SUM(d.RESALE_TAX) AS RESALE_TAX,
	  SUM(d.LINE_TOTAL) AS LINE_TOTAL, 
	  SUM(d.NET_TOTAL_AMT) AS NET_TOTAL_AMT,
	  SUM(d.VENDOR_NET_AMT) AS VENDOR_NET_AMT,
	  SUM(d.BILL_AMT) AS BILL_AMT,
	  SUM(d.RECNB_BILL_AMT) AS RECNB_BILL_AMT, 
	  SUM(d.RECNB_NET_AMT) AS RECNB_NET_AMT,
	  SUM(d.SPOTS_QTY) AS SPOTS_QTY,	
	  d.NON_BILL_FLAG AS NON_BILL_FLAG,
	  d.LINE_CANCELLED AS LINE_CANCELLED,
	  d.BILL_TYPE_FLAG AS BILL_TYPE_FLAG,
	  SUM(d.BILLED_EXT_NET_AMT) AS BILLED_EXT_NET_AMT, 
	  SUM(d.BILLED_DISC_AMT) AS BILLED_DISC_AMT,
	  SUM(d.BILLED_NC_AMT) AS BILLED_NC_AMT,
	  SUM(d.BILLED_VTAX_AMT) AS BILLED_VTAX_AMT,
	  SUM(d.BILLED_NET_AMT) AS BILLED_NET_AMT,
	  SUM(d.BILLED_ADDL_CHARGE) AS BILLED_ADDL_CHARGE,
	  SUM(d.BILLED_COMM_AMT) AS BILLED_COMM_AMT,
	  SUM(d.BILLED_REBATE_AMT) AS BILLED_REBATE_AMT,
	  SUM(d.BILLED_RTAX_AMT) AS BILLED_RTAX_AMT,
	  SUM(d.BILLED_BILL_AMT) AS BILLED_BILL_AMT,
	  SUM(d.BILLED_SPOTS_QTY) AS BILLED_SPOTS_QTY,		  
	  NULL AS AR_INV_NBR,
	  NULL AS AR_SEQ,
	  NULL AS AR_TYPE,
	  NULL AS GLXACT_BILL,
	  SUM(d.AP_NET_AMT) AS AP_NET_AMT,
	  SUM(d.AP_NETCHARGES_AMT) AS AP_NETCHARGES_AMT, 
	  SUM(d.AP_DISC_AMT_AMT) AS AP_DISC_AMT_AMT,
	  SUM(d.AP_COMM_AMT) AS AP_COMM_AMT,
	  SUM(d.AP_REBATE_AMT) AS AP_REBATE_AMT,
	  SUM(d.AP_VTAX_AMT) AS AP_VTAX_AMT,
	  SUM(d.AP_RTAX_AMT) AS AP_RTAX_AMT,
	  SUM(d.AP_DISBURSED_AMT) AS AP_DISBURSED_AMT,											--#30
	  SUM(d.AP_BILL_AMT) AS AP_BILL_AMT,
	  SUM(d.AP_LINE_TOTAL) AS AP_LINE_TOTAL, 
	  SUM(d.AP_SPOTS_QTY) AS AP_SPOTS_QTY,			
	  NULL AS AP_INV_NBR,
	  NULL AS GLXACT_AP,
	  NULL AS AP_ID,
	  MAX(d.AP_PAYMENT_FLAG) AS AP_PAYMENT_FLAG,
	  --NULL AS AP_CHK_NBR,																		
	  (SELECT MAX(a.AP_CHK_NBR) FROM #media_order_amounts AS a WHERE d.ORDER_NBR = a.ORDER_NBR		
		AND d.LINE_NBR = a.LINE_NBR AND MAX(d.AP_CHK_DATE) = a.AP_CHK_DATE AND a.REC_TYPE ='A'),
	  MAX(d.AP_CHK_DATE) AS AP_CHK_DATE,																						
	  SUM(d.AP_PAYMENT_AMT),
	  MAX(d.CR_PAYMENT_FLAG) AS CR_PAYMENT_FLAG,
	  --NULL AS CR_CHECK_NBR,																														
	  (SELECT MAX(a.CR_CHECK_NBR) FROM #media_order_amounts AS a WHERE d.ORDER_NBR = a.ORDER_NBR 
		AND d.LINE_NBR = a.LINE_NBR AND MAX(d.CR_CHECK_DATE) = a.CR_CHECK_DATE AND a.REC_TYPE ='B'),	  
	  MAX(d.CR_CHECK_DATE) AS CR_CHECK_DATE,
	  MAX(d.CR_DEP_DATE) AS CR_DEP_DATE,
	  SUM(d.CR_PAYMENT_AMT)
FROM  #media_order_amounts AS d
--LEFT JOIN #media_order_detail AS dt														--#26 can remove if old bcst is removed
--	ON d.ORDER_NBR = dt.ORDER_NBR
--	AND d.LINE_NBR = dt.LINE_NBR
GROUP BY d.[USER_ID], LEFT(d.ORDER_TYPE,1), d.ORDER_NBR, d.LINE_NBR, d.[MONTH], d.[YEAR],	--#26 dt.INSERT_DATE,	
	d.NON_BILL_FLAG, d.LINE_CANCELLED, d.BILL_TYPE_FLAG
--SELECT * FROM #media_order_amounts_sum ORDER BY ORDER_NBR, LINE_NBR

--=============================================================================
--I. LINK TABLES FOR COMPOSITE DATASET INTO TEMP TABLE #media_current_status
--SEE ADRPTS MACRO "MedRpts OrderDetail"
--=============================================================================
CREATE TABLE #media_current_status(     
	  [User Code]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Type]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Number]					int NULL,
	  [Revision Number]					smallint NULL, 
	  [Office Code]						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Office Name]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Client Code]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Client Name]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Division Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Division Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Product Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Product Description]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [Order Description]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Comment]					text, 
	  [Vendor Code]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Vendor Name]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Vendor Rep Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Vendor Rep Name]					varchar(65) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Vendor Rep Code2]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Vendor Rep Name2]				varchar(65) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Campaign Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Campaign ID]						smallint NULL, 
	  [Campaign Name]					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Media Type]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Media Type Description]			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Post Bill Flag]					tinyint NULL, 
	  [Net Gross Flag]					tinyint NULL, 
	  [Market Code]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Market Description]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Date]						smalldatetime NULL, 
	  [Order Flight From]				smalldatetime NULL, 
	  [Order Flight To]					smalldatetime NULL, 
	  [Order Process Control]			tinyint NULL,
	  [Buyer]							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Client PO]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Link ID]							int NULL, 
	  [Order Accepted]					tinyint NULL, 
	  [Line Number]						smallint NULL, 
	  [Line Revision Number]			smallint NULL,
	  [Line Sequence Number]			tinyint NULL, 
	  [Order Date Type]					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Order Period]					int NULL, 
	  [Order Month]						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order year]						smallint NULL, 
	  [Insertion Date]					smalldatetime NULL, 
	  [Order End Date]					smalldatetime NULL, 
	  [Date To Bill]					smalldatetime NULL, 
	  [Close Date]						smalldatetime NULL, 
	  [Material Close Date]				smalldatetime NULL, 
	  [Extended Material Close Date]	smalldatetime NULL, 
	  [Extended Space Close Date]		smalldatetime NULL, 
	  [Line Description]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, --(headline)
	  [Ad Size]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Edition Issue]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Section]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Material]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Remarks]							text, 
	  [URL]								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Copy Area]						text, 
	  [Material Notes]					text, 
	  [Position Info]					text, 
	  [Miscellaneous Info]				text, 
	  [Job Number]						int NULL, 
	  [Job Description]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Job Component Number]			smallint NULL, 
	  [Job Component Description]		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Cost Type]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Rate Type]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Print Quantity]					decimal(14,3) NULL, 
	  [Guaranteed Impressions]			int NULL,
	  [Line Link ID]					int NULL, 
	  [Order Entry Type]				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Record Type]						varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [Extended Net Amount]				decimal(15,2) NULL, 
	  [Net Charge Amount]				decimal(15,2) NULL, 
	  [Discount Amount]					decimal(15,2) NULL, 
	  [Additional Charge Amount]		decimal(15,2) NULL, 
	  [Commission Amount]				decimal(15,2) NULL, 
	  [Rebate Amount]					decimal(15,2) NULL, 
	  [Vendor Tax Amount]				decimal(15,2) NULL, 
	  [Resale Tax Amount]				decimal(15,2) NULL, 
	  [Line Total Amount]				decimal(15,2) NULL, 
	  [Net Total Amount]				decimal(15,2) NULL, 
	  [Vendor Net Amount]				decimal(15,2) NULL,
	  [Bill Amount]						decimal(15,2) NULL, 
	  [Reconcile No_Bill Bill Amount]	decimal(15,2) NULL, 
	  [Reconcile No_BILL Net Amount]	decimal(15,2) NULL, 
	  [Spots Quantity]					int NULL,				
	  [Non_billable Flag]				tinyint NULL, 
	  [Line Cancelled]					tinyint NULL, 
	  [Bill Type Flag]					tinyint NULL,
	  [Billed Extended Net Amount]		decimal(15,2) NULL, 
	  [Billed Discount Amount]			decimal(15,2) NULL, 
	  [Billed Net Charge Amount]		decimal(15,2) NULL, 
	  [Billed Vendor Tax Amount]		decimal(15,2) NULL, 
	  [Billed Net Amount]				decimal(15,2) NULL, 
	  [Billed Additional Charge Amount]	decimal(15,2) NULL, 
	  [Billed Commission Amount]		decimal(15,2) NULL, 
	  [Billed Rebate Amount]			decimal(15,2) NULL, 
	  [Billed Resale Tax Amount]		decimal(15,2) NULL, 
	  [Billed Bill Amount]				decimal(15,2) NULL,
	  [Billed Spots Quantity]			int NULL,	
	  [Invoice Number]					int NULL, 
	  [Invoice Sequence Number]			smallint NULL, 
	  [Invoice Type]					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [GL Billing Trans Number]			int NULL,			
	  [AP Net Amount]					decimal(15,2) NULL, 
	  [AP Net Charge Amount]			decimal(15,2) NULL, 
	  [AP Discount Amount]				decimal(15,2) NULL, 
	  [AP Commission Amount]			decimal(15,2) NULL, 
	  [AP Rebate Amount]				decimal(15,2) NULL, 
	  [AP Vendor Tax Amount]			decimal(15,2) NULL, 
	  [AP Resale Tax Amount]			decimal(15,2) NULL, 			
	  [AP Disbursed Amount]				decimal(15,2) NULL,									--#30
	  [AP Bill Amount]					decimal(15,2) NULL, 
	  [AP Line Total]					decimal(15,2) NULL,
	  [AP Spots Quantity]				int NULL,			
	  [AP Invoice Number]				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [AP GL Trans Number]				int NULL,
	  [AP_ID]							int NULL,											--#15,
	  [AP Payment Flag]					tinyint NULL DEFAULT 0,
	  [AP Check Number]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [AP Check Date]					datetime NULL,
	  [AP Payment Amount]				decimal(15,2) NULL DEFAULT 0,
	  [AR Payment Flag]					tinyint NULL DEFAULT 0,
	  [AR Check Number]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [AR Check Date]					datetime NULL,
	  [AR Deposit Date]					datetime NULL,
	  [AR Payment Amount]				decimal(15,2) NULL DEFAULT 0,
	  [Fiscal Period Code]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#18
	  [Circulation]						int NULL,											--#18
	  [Rate Info]						text,												--#18
	  [Bill Coop Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#19
	  [Bill Coop Description]			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,		
	  [Buy Type]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Date 1]							smalldatetime,
	  [Date 2]							smalldatetime,
	  [Date 3]							smalldatetime,
	  [Date 4]							smalldatetime,
	  [Date 5]							smalldatetime,
	  [Date 6]							smalldatetime,
	  [Date 7]							smalldatetime,
	  [Monday]							smallint NULL,
	  [Tuesday]							smallint NULL,
	  [Wednesday]						smallint NULL,
	  [Thursday]						smallint NULL,
	  [Friday]							smallint NULL,
	  [Saturday]						smallint NULL,
	  [Sunday]							smallint NULL,
	  [Spots 1]							int NULL,
	  [Spots 2]							int NULL,
	  [Spots 3]							int NULL,
	  [Spots 4]							int NULL,
	  [Spots 5]							int NULL,
	  [Spots 6]							int NULL,
	  [Spots 7]							int NULL,
	  [Ad Number]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Ad Number Description]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Material Comp Date]				smalldatetime,
	  [Programming]						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Start Time]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [End Time]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Tag]								varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Network ID]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Days]							varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Acct Exec Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#34
	  [Acct Exec Name]					varchar(62) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#34
	  [Create Date]						smalldatetime,										--#34
	  [Create User]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#34
	  [Vendor Payment Method]           varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#35
	  [Job Type]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#35
	  [Job Type Description]            varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,	--#35
	  [House Comments]					text,
	  [Internet Type Code]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Internet Type Description]       varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Out of Home Type Code]			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Out of Home Type Description]    varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Rate]							decimal(15,2) NULL DEFAULT 0,
	  [Billed Posting Period]           varchar(6),
	  [Placement 1]						varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#40
	  [Placement 2]						varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#40
	  [Projected Impressions]		    int NULL,													--#40
	  [Actual Impressions]				int NULL,	  
	  [Location]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#40

	  [Target Audience]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,		--#41
	  [Line Market Code]				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 		--#41
	  [Line Market Description]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,		--#41
	  [Creative Size]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,		--#41
	  [EstimateID] int,																			--#41
	  [EstimateName] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,							--#41
	  [EstimateBudget] decimal(19,2)															--#41
	  )
	  
--Left join to #media_order detail excludes detail for old bcst where the line is always 0	--#20
--Modified to inner join with the removal of old bcst										--#26
INSERT INTO #media_current_status
SELECT
	  mh.[USER_ID] AS [User Code],
	  mh.[TYPE] AS [Order Type], 
	  mh.ORDER_NBR AS [Order Number], 
	  md.REV_NBR AS [Revision Number], --41 changed from mh.
	  mh.OFFICE_CODE AS [Office Code],
	  dbo.OFFICE.OFFICE_NAME AS [Office Name],
	  mh.CL_CODE AS [Client Code], 
	  dbo.CLIENT.CL_NAME AS [Client Name],
	  mh.DIV_CODE AS [Division Code],
	  dbo.DIVISION.DIV_NAME AS [Division Name], 
	  mh.PRD_CODE AS [Product Code],
	  dbo.PRODUCT.PRD_DESCRIPTION AS [Product Description],  
	  mh.ORDER_DESC AS [Order Description], 
	  mh.ORDER_COMMENT AS [Order Comment], 
	  mh.VN_CODE AS [Vendor Code],
	  dbo.VENDOR.VN_NAME AS [Vendor Name], 
	  mh.VR_CODE AS [Vendor Rep Code], 
	  ISNULL(dbo.VEN_REP.VR_FNAME,'') + ' ' + ISNULL(dbo.VEN_REP.VR_LNAME,'') AS [Vendor Rep Name],
	  mh.VR_CODE2 AS [Vendor Rep Code2],
	  ISNULL(vr2.VR_FNAME,'') + ' ' + ISNULL(vr2.VR_LNAME,'') AS [Vendor Rep Name2], 
	  mh.CMP_CODE AS [Campaign Code], 
	  mh.CMP_IDENTIFIER AS [Campaign ID], 
	  mh.CMP_NAME AS [Campaign Name], 
	  mh.MEDIA_TYPE AS [Media Type], 
	  SC.SC_DESCRIPTION AS [Media Type Description], 
	  mh.POST_BILL AS [Post Bill Flag], 
	  mh.NET_GROSS AS [Net Gross Flag], 
	  mh.MARKET_CODE AS [Market Code], 
	  mh.MARKET_DESC AS [Market Description], 
	  mh.ORDER_DATE AS [Order Date], 
	  mh.FLIGHT_FROM AS [Order Flight From], 
	  mh.FLIGHT_TO AS [Order Flight To],
	  mh.ORD_PROCESS_CONTRL AS [Order Process Control], 
	  mh.BUYER AS [Buyer], 
	  mh.CLIENT_PO AS [Client PO], 
	  mh.LINK_ID AS [Link ID], 
	  mh.ORDER_ACCEPTED AS [Order Accepted], 
	  CASE mh.ADVAN_TYPE
		WHEN 1 THEN 0
		ELSE md.LINE_NBR
	  END AS [Line Number], 
	  md.REV_NBR AS [Line Revision Number],
	  md.SEQ_NBR AS [Line Sequence Number], 
	  md.DATE_TYPE AS [Order Date Type],
	  COALESCE(md.[YEAR],ma.[YEAR]) * 100 + COALESCE(md.[MONTH],ma.[MONTH])AS [Order Period], 
	  CASE COALESCE(md.[MONTH],ma.[MONTH])
			WHEN 1 THEN 'Jan'
			WHEN 2 THEN 'Feb'
			WHEN 3 THEN 'Mar'
			WHEN 4 THEN 'Apr'
			WHEN 5 THEN 'May'
			WHEN 6 THEN 'Jun'
			WHEN 7 THEN 'Jul'
			WHEN 8 THEN 'Aug'
			WHEN 9 THEN 'Sep'
			WHEN 10 THEN 'Oct'
			WHEN 11 THEN 'Nov'
			WHEN 12 THEN 'Dec'	  
	  END AS [Order Month], 
	  COALESCE(md.[YEAR],ma.[YEAR]) AS [Order year], 
	  md.INSERT_DATE [Insertion Date], 
	  md.END_DATE AS [Order End Date], 
	  md.DATE_TO_BILL AS [Date To Bill], 
	  md.CLOSE_DATE AS [Close Date], 
	  md.MATL_CLOSE_DATE AS [Material Close Date], 
	  md.EXT_CLOSE_DATE AS [Extended Material Close Date], 
	  md.EXT_MATL_DATE AS [Extended Space Close Date], 
	  md.LINE_DESC AS [Line Description], 
	  md.AD_SIZE AS [Ad Size], 
	  md.EDITION_ISSUE AS [Edition Issue], 
	  md.SECTION AS [Section], 
	  md.MATERIAL AS [Material], 
	  md.REMARKS AS [Remarks], 
	  md.URL AS [URL], 
	  md.COPY_AREA AS [Copy Area], 
	  md.MATL_NOTES AS [Material Notes], 
	  md.POSITION_INFO AS [Position Info], 
	  md.MISC_INFO AS [Miscellaneous Info], 
	  md.JOB_NUMBER AS [Job Number], 
	  dbo.JOB_LOG.JOB_DESC AS [Job Description],
	  md.JOB_COMPONENT_NBR AS [Job Component Number], 
	  dbo.JOB_COMPONENT.JOB_COMP_DESC AS [Job Component Description],
	  md.COST_TYPE AS [Cost Type], 
	  md.RATE_TYPE AS [Rate Type], 
	  md.PRINT_QUANTITY AS [Print Quantity],												--#13
	  md.GUARANTEED_IMPRESS AS [Guaranteed Impressions],
	  md.LINK_ID AS [Line Link ID], 
	  ma.ORDER_TYPE AS [Order Entry Type],											
	 -- CASE ma.REC_TYPE
		--WHEN 'O' THEN 'ORDER'
		--WHEN 'B' THEN 'BILLING'
		--WHEN 'A' THEN 'AP'
	 -- END AS [Record Type],
	  NULL AS [Record Type],
	  ma.EXT_NET_AMT AS [Extended Net Amount], 
	  ma.NETCHARGES AS [Net Charge Amount], 
	  ma.DISCOUNTS AS [Discount Amount], 
	  ma.ADDL_CHARGE AS [Additional Charge Amount], 
	  ma.COMM_AMT AS [Commission Amount], 
	  ma.REBATE_AMT AS [Rebate Amount], 
	  ma.VENDOR_TAX AS [Vendor Tax Amount], 
	  ma.RESALE_TAX AS [Resale Tax Amount], 
	  ma.LINE_TOTAL AS [Line Total Amount], 
	  ma.NET_TOTAL_AMT AS [Net Total Amount], 
	  ma.VENDOR_NET_AMT AS [Vendor Net Amount],
	  ma.BILL_AMT AS [Bill Amount], 
	  ma.RECNB_BILL_AMT AS [Reconcile No_Bill Bill Amount], 
	  ma.RECNB_NET_AMT AS [Reconcile No_BILL Net Amount], 
	  ma.SPOTS_QTY AS [Spots Quantity],				--#05
	  ma.NON_BILL_FLAG AS [Non_billable Flag], 
	  ma.LINE_CANCELLED AS [Line Cancelled], 
	  ma.BILL_TYPE_FLAG AS [Bill Type Flag],
	  ma.BILLED_EXT_NET_AMT AS [Billed Extended Net Amount], 
	  ma.BILLED_DISC_AMT AS [Billed Discount Amount], 
	  ma.BILLED_NC_AMT AS [Billed Net Charge Amount], 
	  ma.BILLED_VTAX_AMT AS [Billed Vendor Tax Amount], 
	  ma.BILLED_NET_AMT AS [Billed Net Amount], 
	  ma.BILLED_ADDL_CHARGE AS [Billed Additional Charge Amount], 
	  ma.BILLED_COMM_AMT AS [Billed Commission Amount], 
	  ma.BILLED_REBATE_AMT AS [Billed Rebate Amount], 
	  ma.BILLED_RTAX_AMT AS [Billed Resale Tax Amount], 
	  ma.BILLED_BILL_AMT AS [Billed Bill Amount],
	  ma.BILLED_SPOTS_QTY AS [Billed Spots Quantity],										--#05
	  ma.AR_INV_NBR AS [Invoice Number], 
	  ma.AR_SEQ AS [Invoice Sequence Number], 
	  ma.AR_TYPE AS [Invoice Type], 
	  ma.GLXACT_BILL AS [GL Billing Trans Number],											--#04
	  ma.AP_NET_AMT AS [AP Net Amount], 
	  ma.AP_NETCHARGES_AMT AS [AP Net Charge Amount], 
	  ma.AP_DISC_AMT_AMT AS [AP Discount Amount], 
	  ma.AP_COMM_AMT AS [AP Commission Amount], 
	  ma.AP_REBATE_AMT AS [AP Rebate Amount], 
	  ma.AP_VTAX_AMT AS [AP Vendor Tax Amount], 
	  ma.AP_RTAX_AMT AS [AP Resale Tax Amount],
	  ma.AP_DISBURSED_AMT AS [AP Disbursed Amount],											--#30  
	  ma.AP_BILL_AMT AS [AP Bill Amount], 
	  ma.AP_LINE_TOTAL AS [AP Line Total],
	  ma.AP_SPOTS_QTY AS [AP Spots Quantity],												--#05
	  ma.AP_INV_NBR AS [AP Invoice Number], 
	  ma.GLXACT_AP AS [AP GL Trans Number],													--#04
	  ma.AP_ID AS [AP_ID],																	--#15
	  ma.AP_PAYMENT_FLAG AS [AP Payment Flag],
	  ma.AP_CHK_NBR AS [AP Check Number],
	  ma.AP_CHK_DATE AS [AP Check Date],
	  ma.AP_PAYMENT_AMT AS [AP Payment Amount],												--#28, #31
	  ma.CR_PAYMENT_FLAG AS [AR Payment Flag],
	  ma.CR_CHECK_NBR AS [AR Check Number],
	  ma.CR_CHECK_DATE AS [AR Check Date],
	  ma.CR_DEP_DATE AS [AR Deposit Date],
	  ma.CR_PAYMENT_AMT AS [AR Payment Amount],
	  mh.FISCAL_PERIOD_CODE,																--#18
	  md.CIRCULATION,																		--#18
	  md.RATE_INFO,																			--#18
	  mh.BILL_COOP_CODE,																	--#19
	  NULL,
	  md.BUY_TYPE,
	  md.DATE1,
	  md.DATE2,
	  md.DATE3,
	  md.DATE4,
	  md.DATE5,
	  md.DATE6,
	  md.DATE7,
	  md.MONDAY,
	  md.TUESDAY,
	  md.WEDNESDAY,
	  md.THURSDAY,
	  md.FRIDAY,
	  md.SATURDAY,
	  md.SUNDAY,
	  md.SPOTS1,
	  md.SPOTS2,
	  md.SPOTS3,
	  md.SPOTS4,
	  md.SPOTS5,
	  md.SPOTS6,
	  md.SPOTS7,
	  md.AD_NUMBER,
	  NULL,																					--#39 
	  md.MAT_COMP,
	  md.PROGRAMMING,
	  md.START_TIME,
	  md.END_TIME,
	  md.TAG,
	  md.NETWORK_ID,
	  md.[DAYS],
	  NULL,																					--#34 Acct Exec Code
	  NULL,																					--#34 Acct Exec Name
	  NULL,																					--#34 Create Date
	  NULL,																					--#34 Create User
	  CASE WHEN ISNULL(SEND_VCC_WITH_MEDIA_ORDER,0) = 1 THEN 'Virtual CC' ELSE 'Check' END,  --#35 Vendor Payment Method
	  NULL,																					--#36 Job Type
	  NULL,																					--#36 Job Type		
	  mh.HOUSE_COMMENT,																		--#39 
	  NULL,																					--#39 
	  NULL,																					--#39 
	  NULL,																					--#39 
	  NULL,																					--#39 
	  NULL,																					--#39 
	  NULL,																					--#39 															
	  md.PLACEMENT_1 AS [Placement 1],										--#40
	  md.PLACEMENT_2 AS [Placement 2],										--#40
	  md.PROJ_IMPRESSIONS AS [Projected Impressions],						--#40
	  md.ACT_IMPRESSIONS AS [Actual Impressions],							--#40
	  md.[LOCATION],
	  NULL,
	  NULL,
	  NULL,
	  md.[CREATIVE_SIZE],
	  MPDLLD.MEDIA_PLAN_DTL_ID,
	  MPD.NAME,
	  ISNULL(MPD.GROSS_BUDGET_AMT,0)
FROM #media_order_amounts_sum AS ma
JOIN #media_order_header AS mh 
	ON ma.ORDER_NBR = mh.ORDER_NBR 
JOIN #media_order_detail AS md 
	ON ma.ORDER_NBR = md.ORDER_NBR
	AND ma.LINE_NBR = md.LINE_NBR  
JOIN dbo.OFFICE
	ON mh.OFFICE_CODE = dbo.OFFICE.OFFICE_CODE
JOIN dbo.CLIENT
	ON mh.CL_CODE = dbo.CLIENT.CL_CODE	
JOIN dbo.DIVISION
	ON mh.CL_CODE = dbo.DIVISION.CL_CODE	
	AND mh.DIV_CODE = dbo.DIVISION.DIV_CODE
JOIN dbo.PRODUCT
	ON mh.CL_CODE = dbo.PRODUCT.CL_CODE	
	AND mh.DIV_CODE = dbo.PRODUCT.DIV_CODE
	AND mh.PRD_CODE = dbo.PRODUCT.PRD_CODE
JOIN dbo.VENDOR
	ON mh.VN_CODE = dbo.VENDOR.VN_CODE
LEFT JOIN dbo.VEN_REP
	ON mh.VN_CODE = dbo.VEN_REP.VN_CODE
	AND mh.VR_CODE = dbo.VEN_REP.VR_CODE
LEFT JOIN dbo.VEN_REP AS vr2
	ON mh.VN_CODE = vr2.VN_CODE
	AND mh.VR_CODE = vr2.VR_CODE	
LEFT JOIN dbo.JOB_LOG
	ON md.JOB_NUMBER = dbo.JOB_LOG.JOB_NUMBER
LEFT JOIN dbo.JOB_COMPONENT
	ON md.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER
	AND md.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR  
LEFT JOIN dbo.SALES_CLASS AS SC 
	ON SC.SC_CODE = mh.MEDIA_TYPE
LEFT JOIN [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] AS MPDLLD  --#41
	ON MPDLLD.ORDER_NBR = md.ORDER_NBR 
	AND MPDLLD.ORDER_LINE_NBR = md.LINE_NBR
LEFT JOIN [dbo].[MEDIA_PLAN_DTL] AS MPD 
	ON MPD.MEDIA_PLAN_ID = MPDLLD.MEDIA_PLAN_ID 
	AND MPD.MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID

--SELECT '#media_current_status' '-', EstimateID, * FROM #media_current_status ORDER BY [Order Number] --#41

--#34
UPDATE A
SET A.[Acct Exec Code] = B.EMP_CODE
FROM #media_current_status A
    INNER JOIN ACCOUNT_EXECUTIVE B ON
        A.[Client Code] = B.CL_CODE AND A.[Division Code] = B.DIV_CODE AND A.[Product Code] = B.PRD_CODE
		AND B.DEFAULT_AE = 1 AND COALESCE(B.INACTIVE_FLAG, 0) = 0 
UPDATE A
SET A.[Acct Exec Name] = COALESCE(B.EMP_FNAME, '*') + ' ' + COALESCE(B.EMP_LNAME, '*')
FROM #media_current_status A
    INNER JOIN EMPLOYEE B ON
        A.[Acct Exec Code] = B.EMP_CODE
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_current_status A
    INNER JOIN NEWSPAPER_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_current_status A
    INNER JOIN MAGAZINE_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_current_status A
    INNER JOIN INTERNET_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_current_status A
    INNER JOIN OUTDOOR_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_current_status A
    INNER JOIN TV_HDR B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_current_status A
    INNER JOIN RADIO_HDR B ON
        A.[Order Number] = B.ORDER_NBR

UPDATE A
SET A.[Job Type] = B.JT_CODE, A.[Job Type Description] = JT.JT_DESC
FROM #media_current_status A
    INNER JOIN JOB_COMPONENT B ON A.[Job Number] = B.JOB_NUMBER AND A.[Job Component Number] = B.JOB_COMPONENT_NBR
	INNER JOIN JOB_TYPE JT ON B.JT_CODE = JT.JT_CODE

--#39 --#41

--SELECT '#media_current_status' '#media_current_status', * FROM #media_current_status

UPDATE A
SET A.[Internet Type Code] = B.INTERNET_TYPE, 
	A.[Internet Type Description] = IT.OD_DESC,
	A.[Target Audience] = B.TARGET_AUDIENCE,
	A.[Line Market Code] = B.MARKET_CODE,
	A.[Line Market Description] = m.MARKET_DESC,
	A.[Ad Size] = B.SIZE,
	A.[Creative Size] = CASE WHEN B.CREATIVE_SIZE IS NOT NULL THEN B.CREATIVE_SIZE ELSE AD.SIZE_DESC END
FROM #media_current_status A
    INNER JOIN INTERNET_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR
	LEFT JOIN INTERNET_TYPE IT ON B.INTERNET_TYPE = IT.OD_CODE
	LEFT JOIN dbo.MARKET AS m ON B.MARKET_CODE = m.MARKET_CODE
	LEFT JOIN AD_SIZE AD ON B.SIZE = AD.SIZE_CODE
--#41
UPDATE A
SET A.[Out of Home Type Code] = B.OUTDOOR_TYPE, 
	A.[Out of Home Type Description] = OT.OD_DESC,
	A.[Ad Size] = B.SIZE,
	A.[Creative Size] = AD.SIZE_DESC
FROM #media_current_status A
    INNER JOIN OUTDOOR_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR
	LEFT JOIN OUTDOOR_TYPE OT ON B.OUTDOOR_TYPE = OT.OD_CODE
	LEFT JOIN AD_SIZE AD ON B.SIZE = AD.SIZE_CODE

--#41 moved below - A.[Ad Number Description]

UPDATE A
SET A.[Bill Coop Description] = B.BILL_COOP_DESC
FROM #media_current_status A
    INNER JOIN BILLING_COOP B ON A.[Bill Coop Code] = B.BILL_COOP_CODE

UPDATE A
SET A.[Billed Posting Period] = B.AR_POST_PERIOD
FROM #media_current_status A
	LEFT OUTER JOIN ACCT_REC B ON A.[Invoice Number] = B.AR_INV_NBR AND A.[Invoice Sequence Number] = B.AR_INV_SEQ AND A.[Invoice Type] = B.AR_TYPE
WHERE B.AR_TYPE <> 'VO'

UPDATE A
SET A.[Rate]= B.RATE
FROM #media_current_status A
    INNER JOIN MAGAZINE_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR AND A.[Line Sequence Number] = B.SEQ_NBR

UPDATE A
SET A.[Rate]= B.RATE
FROM #media_current_status A
    INNER JOIN NEWSPAPER_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR AND A.[Line Sequence Number] = B.SEQ_NBR

UPDATE A
SET A.[Rate]= B.RATE
FROM #media_current_status A
    INNER JOIN INTERNET_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR AND A.[Line Sequence Number] = B.SEQ_NBR

UPDATE A
SET A.[Rate]= B.RATE
FROM #media_current_status A
    INNER JOIN OUTDOOR_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR AND A.[Line Sequence Number] = B.SEQ_NBR

UPDATE A
SET A.[Rate]= B.RATE
FROM #media_current_status A
    INNER JOIN RADIO_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR AND A.[Line Sequence Number] = B.SEQ_NBR

UPDATE A
SET A.[Rate]= B.RATE
FROM #media_current_status A
    INNER JOIN TV_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND A.[Line Revision Number] = B.REV_NBR AND A.[Line Sequence Number] = B.SEQ_NBR

--#41 moved from above
UPDATE A
SET A.[Ad Number Description] = an.AD_NBR_DESC
FROM #media_current_status A
	LEFT JOIN dbo.AD_NUMBER AS an ON A.[Ad Number] = an.AD_NBR


--SELECT * FROM #media_current_status

CREATE TABLE #media_plan_data(     	  
	  [OfficeCode]						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [OfficeName]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ClientCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ClientName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionName]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ProductCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ProductDescription]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [VendorCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [PlanID]  int,
	  [PlanDescription] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ClientContact] varchar(200) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [PlanStartDate] smalldatetime,
	  [PlanEndDate] smalldatetime,
	  [GrossBudget] decimal(19, 2),
	  [CreatedByUserCode] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [CreatedDate] smalldatetime,
	  [ModifiedByUserCode] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ModifiedDate] smalldatetime,
	  [MediaType]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [SalesClassCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [SalesClassDescription]			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CampaignCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CampaignName]					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [StartDate] smalldatetime,
	  [EndDate] smalldatetime,
	  [Month] int,
	  [Quarter] int,
	  [Year] int,
	  [Demo1] decimal(10, 2),
	  [Demo2] decimal(10, 2),
	  [Units] decimal(10, 2),
	  [Impressions] decimal(10, 2),
	  [Clicks] decimal(10, 2),
	  [Rate] decimal(10, 4),
	  [Dollars] decimal(19, 2),
	  [AgencyFee] decimal(19, 2),
	  [BillAmount] decimal(19, 2),
	  [PlanQuantity] decimal(10, 2),
	  [PlanNetAmount] decimal(10, 2),
	  [PlanCommission] decimal(10, 2),
	  [IsApproved] bit,
	  [ApprovedBy] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ApprovedDate] smalldatetime,
	  [MasterPlanID] int,
	  [MasterPlanName] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [EstimateID] int,
	  [EstimateName] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [EstimateBudget] decimal(19,2),
	  [OrderNumber] int,
	  [OrderLineNumber] smallint)			

INSERT INTO #media_plan_data
SELECT 		
		[OfficeCode] = P.OFFICE_CODE,
		[OfficeName] = O.OFFICE_NAME,
		[ClientCode] = MP.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = MP.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = MP.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[VendorCode] = MPVN.VendorCode,
		[VendorName] = V.VN_NAME,
		[PlanID] = MP.MEDIA_PLAN_ID,
		[PlanDescription] = MP.[DESCRIPTION],
		[ClientContact] = COALESCE((RTRIM(CC.CONT_FNAME) + ' '),'') + COALESCE((CC.CONT_MI + '. '),'') + COALESCE(CC.CONT_LNAME,''),
		[PlanStartDate] = MP.[START_DATE],
		[PlanEndDate] = MP.END_DATE,
		[GrossBudget] = MP.GROSS_BUDGET_AMT,
		[CreatedByUserCode] = MP.USER_CREATED,
		[CreatedDate] = MP.CREATED_DATE,
		[ModifiedByUserCode] = MP.USER_MODIFIED,
		[ModifiedDate] = MP.MODIFIED_DATE,
		[MediaType] = MPD.SC_TYPE,
		[SalesClassCode] = MPD.SC_CODE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[CampaignCode] = CASE WHEN CAMP.CMP_CODE IS NULL THEN MPCMP.CampaignCode ELSE CAMP.CMP_CODE END, 
		[CampaignName] = CASE WHEN CAMP.CMP_NAME IS NULL THEN MPCMP.CampaignName ELSE CAMP.CMP_NAME END,
		[StartDate] = MPDLLD.[START_DATE],
		[EndDate] = MPDLLD.[END_DATE],		
		[Month] = CASE WHEN MPD.IS_CALENDAR_MONTH = 1 THEN MC.[MONTH] ELSE MC.BROADCAST_MONTH END,
		[Quarter] = CASE WHEN MPD.IS_CALENDAR_MONTH = 1 THEN MC.[QUARTER] ELSE MC.BROADCAST_QUARTER END,
		[Year] = CASE WHEN MPD.IS_CALENDAR_MONTH = 1 THEN MC.[YEAR] ELSE MC.BROADCAST_YEAR END,
		[Demo1] = MPDLLD.DEMO1,
		[Demo2] = MPDLLD.DEMO2,
		[Units] = MPDLLD.UNITS,
		[Impressions] = MPDLLD.IMPRESSIONS,
		[Clicks] = MPDLLD.CLICKS,
		[Rate] = MPDLLD.RATE,
		[Dollars] = MPDLLD.DOLLARS,
		[AgencyFee] = MPDLLD.AGENCY_FEE,
		[BillAmount] = MPDLLD.BILL_AMOUNT,
		[PlanQuantity] = CAST(COALESCE(MPDLLD.UNITS, 0) + COALESCE(MPDLLD.IMPRESSIONS, 0) + COALESCE(MPDLLD.CLICKS, 0) AS DECIMAL(10,2)),
		[PlanNetAmount] = CAST(CASE WHEN MPD.IS_ESTIMATE_GROSS = 1 THEN (COALESCE(MPDLLD.DOLLARS,0) * .85) ELSE COALESCE(MPDLLD.DOLLARS,0) END AS DECIMAL(10,2)) +
							CAST(COALESCE(NET_CHARGE,0) AS DECIMAL(10,2)),
		[PlanCommission] = CAST(CASE WHEN MPD.IS_ESTIMATE_GROSS = 0 THEN COALESCE(MPDLLD.BILL_AMOUNT,0) - (COALESCE(MPDLLD.DOLLARS,0) + COALESCE(NET_CHARGE,0))
								WHEN MPD.IS_ESTIMATE_GROSS = 1 AND MPDS.NUMERIC_VALUE IS NOT NULL AND MPDS.NUMERIC_VALUE <> 0 THEN (MPDLLD.DOLLARS * .15) - (MPDLLD.DOLLARS * MPDS.NUMERIC_VALUE / 100) 
								WHEN MPD.IS_ESTIMATE_GROSS = 1 THEN (MPDLLD.DOLLARS * .15) END AS DECIMAL(10,2)),
		[IsApproved] = MPD.APPROVED,
		[ApprovedBy] = MPD.APPROVED_BY,
		[ApprovedDate] = MPD.APPROVED_DATE,
		[MasterPlanID] = MPMP.MEDIA_PLAN_MASTER_PLAN_ID,
		[MasterPlanName] = MPMP.[DESCRIPTION],
		[EstimateID] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), MPD.MEDIA_PLAN_DTL_ID), 6),
		[EstimateName] = MPD.NAME,
		[EstimateBudget] = ISNULL(MPD.GROSS_BUDGET_AMT,0),
		[OrderNumber] = MPDLLD.ORDER_NBR,
		[OrderLineNumber] = MPDLLD.ORDER_LINE_NBR
	FROM 
		[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] AS MPDLLD INNER JOIN
		[dbo].[MEDIA_CALENDAR] AS MC ON MC.[DATE] = MPDLLD.[START_DATE] INNER JOIN
		[dbo].[MEDIA_PLAN] AS MP ON MP.MEDIA_PLAN_ID = MPDLLD.MEDIA_PLAN_ID INNER JOIN 
		[dbo].[MEDIA_PLAN_DTL] AS MPD ON MPD.MEDIA_PLAN_ID = MPDLLD.MEDIA_PLAN_ID AND
										 MPD.MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = MP.CL_CODE LEFT OUTER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = MP.CL_CODE AND
								 D.DIV_CODE = MP.DIV_CODE LEFT OUTER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = MP.CL_CODE AND
								P.DIV_CODE = MP.DIV_CODE AND
								P.PRD_CODE = MP.PRD_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = P.OFFICE_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = MP.CDP_CONTACT_ID LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = MPD.SC_CODE LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = MPD.CMP_IDENTIFIER LEFT OUTER JOIN
		[dbo].[MEDIA_PLAN_DTL_SETTING] MPDS ON MP.MEDIA_PLAN_ID = MPDS.MEDIA_PLAN_ID AND MPD.MEDIA_PLAN_DTL_ID = MPDS.MEDIA_PLAN_DTL_ID AND SETTING = 'ProductRebateAmount' LEFT OUTER JOIN
		[dbo].[MEDIA_PLAN_MASTER_PLAN_DETAIL] MPMPD ON MPMPD.MEDIA_PLAN_ID = MP.MEDIA_PLAN_ID LEFT OUTER JOIN
		[dbo].[MEDIA_PLAN_MASTER_PLAN] MPMP ON MPMP.MEDIA_PLAN_MASTER_PLAN_ID = MPMPD.MEDIA_PLAN_MASTER_PLAN_ID LEFT OUTER JOIN
		(SELECT 
 			[MediaPlanID] = MPDL.MEDIA_PLAN_ID,
 			[EstimateID] = MPDL.MEDIA_PLAN_DTL_ID,
 			[VendorColumnName] = MPDL.[DESCRIPTION], 
 			[RowIndex] = MPDLL.ROW_INDEX,
 			[VendorColumnValue] = MPDLL.[DESCRIPTION], 
 			[VendorCode] = MPDLLT.VN_CODE
		 FROM
 			dbo.MEDIA_PLAN_DTL_LEVEL MPDL INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_ID = MPDL.MEDIA_PLAN_DTL_LEVEL_ID INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG MPDLLT ON MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID
		 WHERE
 			MPDL.TAG_TYPE = 2) MPVN ON MPDLLD.MEDIA_PLAN_ID = MPVN.MediaPlanID AND
										MPDLLD.MEDIA_PLAN_DTL_ID = MPVN.EstimateID AND
										MPDLLD.ROW_INDEX = MPVN.RowIndex LEFT OUTER JOIN 
			VENDOR V ON V.VN_CODE = MPVN.VendorCode LEFT OUTER JOIN
		(SELECT 
 			[MediaPlanID] = MPDL.MEDIA_PLAN_ID,
 			[EstimateID] = MPDL.MEDIA_PLAN_DTL_ID,
 			[RowIndex] = MPDLL.ROW_INDEX,
			[CampaignCode] = C.CMP_CODE,
			[CampaignName] = C.CMP_NAME
		 FROM
 			dbo.MEDIA_PLAN_DTL_LEVEL MPDL INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_ID = MPDL.MEDIA_PLAN_DTL_LEVEL_ID INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG MPDLLT ON MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID LEFT OUTER JOIN
			dbo.CAMPAIGN C ON C.CMP_IDENTIFIER = MPDLLT.CMP_IDENTIFIER
		 WHERE
 			MPDL.TAG_TYPE = 11) MPCMP ON MPDLLD.MEDIA_PLAN_ID = MPCMP.MediaPlanID AND
										MPDLLD.MEDIA_PLAN_DTL_ID = MPCMP.EstimateID AND
										MPDLLD.ROW_INDEX = MPCMP.RowIndex
	--WHERE MPDLLD.[START_DATE] >= @start_date AND MPDLLD.[END_DATE] <= @end_date AND MPD.APPROVED = 1
	WHERE MPDLLD.[START_DATE] >= @start_date AND MPDLLD.[START_DATE] <= @end_date AND MPD.APPROVED = 1  /* PJH 04/06/20 - Only compare START_DATE */

--SELECT * FROM #media_plan_data 

--	WHERE MPDLLD.[START_DATE] >= @start_date AND MPDLLD.[START_DATE] <= @end_date AND MPD.APPROVED = 1  AND ORDER_NBR = 207339

CREATE TABLE #media_total(     	  
	  [OfficeCode]						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [OfficeName]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ClientCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ClientName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionName]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ProductCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ProductDescription]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [CampaignCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CampaignName]					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [MediaType]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [SalesClassCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [SalesClassDescription]			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [VendorCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Month]					int,
	  [MonthName]				varchar(20),
	  [Year]					int,
	  [MasterPlanID]			int,
	  [MasterPlanName]			varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [EstimateID]				int,
	  [EstimateName]			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [EstimateBudget] 			decimal(19,2),			
	  [PlanUnits] 				decimal(10, 2),
	  [PlanImpressions] 		decimal(10, 2),
	  [PlanClicks] 				decimal(10, 2),
	  [PlanDemo1] 				decimal(10, 2),
	  [PlanDemo2] 				decimal(10, 2),
	  [PlanQuantity] 			decimal(10, 2),
	  [PlanNetAmount] 			decimal(19, 2),
	  [PlanCommission] 			decimal(10, 2),
	  [PlanAgencyFee] 			decimal(19, 2),
	  [PlanBillAmount] 			decimal(19, 2),
	  OrderQuantity 			decimal(19, 2),
      OrderNetAmount			decimal(19, 2),
      OrderCommission 			decimal(19, 2),
      OrderAgencyFee 			decimal(19, 2),
      OrderBillAmount			decimal(19, 2),
      OrderResaleTax			decimal(19, 2),
      OrderVendorTax			decimal(19, 2),
      BilledQuantity 			decimal(19, 2),
      BilledCommissionAmount		decimal(19, 2),
      BilledAgencyFee 				decimal(19, 2),
      BilledNetAmount 				decimal(19, 2),
      BilledBillAmount 				decimal(19, 2),
      BilledResaleTax			decimal(19, 2),
      BilledVendorTax			decimal(19, 2),
      APQuantity 					decimal(19, 2),
      APNetAmount 					decimal(19, 2),
      PlanBillToOrderedBillVariance 	decimal(19, 2),
      PlanBillToBilledVariance 			decimal(19, 2),
      OrderedToBilledVariance 			decimal(19, 2),
      OrderedToAPVariance 				decimal(19, 2),
	  --#41
	  [Job Number]						int NULL,													--#41
	  [Job Description]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Job Component Number]			smallint, 
	  [Job Component Description]		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,

	  [Ad Size]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Edition Issue]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Section]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Material]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Remarks]							varchar(max), 
	  [URL]								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 

	  [Internet Type Code]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Internet Type Description]		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Out of Home Type Code]			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Out of Home Type Description]    varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Placement 1]						varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,			
	  [Placement 2]						varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,			
	  [Location]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,			
	  [Line Market Code]				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#41
	  [Line Market Description]			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#41	  
	  [OrderNumber]						int,														--#41
	  [OrderLineNumber]					smallint,													--#41
	  [Line Description]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#41
	  [Target Audience]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#41
	  [Ad Number]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#41
	  [Ad Number Description]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#41
	  [Creative Size]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS			--#41

	  )			
	  
--SELECT * FROM #media_current_status --WHERE VendorCode = 'hartct' AND Month = 10

INSERT INTO #media_total
		([OfficeCode],
		[OfficeName],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[CampaignCode],
		[CampaignName],
		[MediaType],
		[SalesClassCode],
		[SalesClassDescription],
		[VendorCode],
		[VendorName],
		[Month],
		[MonthName],
		[Year],
		[MasterPlanID],
		[MasterPlanName],
		[EstimateID],
		[EstimateName],
		[EstimateBudget],
		[PlanUnits],
		[PlanImpressions],
		[PlanClicks],
		[PlanDemo1],
		[PlanDemo2],
		[PlanQuantity],
		[PlanNetAmount],
		[PlanCommission],
		[PlanAgencyFee],
		[PlanBillAmount],
		OrderQuantity,
		OrderNetAmount,
		OrderCommission,
		OrderAgencyFee,
		OrderBillAmount,
        OrderResaleTax,
        OrderVendorTax,
		BilledQuantity,
		BilledCommissionAmount,
		BilledAgencyFee,
		BilledNetAmount,
		BilledBillAmount,
        BilledResaleTax,
        BilledVendorTax,
		APQuantity,
		APNetAmount,
		PlanBillToOrderedBillVariance,
		PlanBillToBilledVariance,
		OrderedToBilledVariance,
		OrderedToAPVariance,
		--#41
		[OrderNumber],
		[OrderLineNumber],
		[Job Number],
		[Job Description],
		[Job Component Number],
		[Job Component Description],

		[Ad Size],
		[Edition Issue],
		[Section],
		[Material],
		[Remarks],
		[URL],

		[Internet Type Code],
		[Internet Type Description],
		[Out of Home Type Code],
		[Out of Home Type Description],
		[Placement 1],
		[Placement 2],
		[Location],
		[Line Market Code],
		[Line Market Description],
		[Line Description],
		[Target Audience],
		[Ad Number],
		[Ad Number Description],
		[Creative Size]
		)

SELECT [Office Code],
       [Office Name],
       [Client Code],
       [Client Name],
       [Division Code],
       [Division Name],
       [Product Code],
       [Product Description],
       [Campaign Code],
       [Campaign Name],
       SUBSTRING([Order Type],1,1),
       [Media Type],
       [Media Type Description],
	   [Vendor Code],
	   [Vendor Name],
       SUBSTRING(CAST([Order Period] AS VARCHAR(6)),5,2),
	   NULL,
       SUBSTRING(CAST([Order Period] AS VARCHAR(6)),1,4),
       NULL,
       NULL,
       EstimateID,					--#41 from NULL
       EstimateName,				--#41 from NULL
       EstimateBudget,				--#41 from NULL
       PlanUnits = 0,
       PlanImpressions = 0,
       PlanClicks = 0,
       PlanDemo1 = 0,
       PlanDemo2 = 0,
       PlanQuantity = 0,
       PlanNetAmount = 0,
       PlanCommission = 0,
       PlanAgencyFee = 0,
       PlanBillAmount = 0,
       OrderQuantity = CASE WHEN [Order Type] = 'INT' THEN ISNULL([Guaranteed Impressions],0) ELSE ISNULL([Print Quantity],0) END,
       OrderNetAmount = [Vendor Net Amount],
       OrderCommission = [Commission Amount],
       OrderAgencyFee = [Additional Charge Amount],
       OrderBillAmount = [Bill Amount],
       OrderResaleTax = [Resale Tax Amount],
       OrderVendorTax = [Vendor Tax Amount],
       BilledQuantity = [Billed Spots Quantity],
       BilledCommissionAmount = [Billed Commission Amount],
       BilledAgencyFee = [Billed Additional Charge Amount],
       BilledNetAmount = [Billed Net Amount],
       BilledBillAmount = [Billed Bill Amount],
       BilledResaleTax = [Billed Resale Tax Amount],
       BilledVendorTax = [Billed Vendor Tax Amount],
       APQuantity = [AP Spots Quantity],
       APNetAmount = [AP Net Amount],
       PlanBillToOrderedBillVariance = 0,
       PlanBillToBilledVariance = 0,
       OrderedToBilledVariance = 0,
       OrderedToAPVariance = 0,
	   --#41
	  [Order Number],
	  [Line Number],
	  [Job Number],
	  [Job Description],
	  [Job Component Number],
	  [Job Component Description],
	
	  [Ad Size],
	  [Edition Issue],
	  [Section],
	  [Material],
	  [Remarks],
	  [URL],
	
	  [Internet Type Code],
	  [Internet Type Description],
	  [Out of Home Type Code],
	  [Out of Home Type Description],
	  [Placement 1],
	  [Placement 2],
	  [Location],
	  [Line Market Code],
	  [Line Market Description],
	  [Line Description],
	  [Target Audience],
	  [Ad Number],
	  [Ad Number Description],
	  [Creative Size]

	FROM #media_current_status

INSERT INTO #media_total
SELECT OfficeCode,
       OfficeName,
       ClientCode,
       ClientName,
       DivisionCode,
       DivisionName,
       ProductCode,
       ProductDescription,
       CampaignCode,
       CampaignName,
       MediaType,
       SalesClassCode,
       SalesClassDescription,
	   VendorCode,
	   VendorName,
       [Month],
	   NULL,
       [Year],
       MasterPlanID,
       MasterPlanName,
       EstimateID,
       EstimateName,
       EstimateBudget,
       PlanUnits = ISNULL(Units,0),
       PlanImpressions = ISNULL(Impressions,0),
       PlanClicks = ISNULL(Clicks,0),
       PlanDemo1 = ISNULL(Demo1,0),
       PlanDemo2 = ISNULL(Demo2,0),
       PlanQuantity = ISNULL(PlanQuantity,0),
       PlanNetAmount = ISNULL(PlanNetAmount,0),
       PlanCommission = ISNULL(PlanCommission,0),
       PlanAgencyFee = ISNULL(AgencyFee,0),
       PlanBillAmount = ISNULL(BillAmount,0),
       OrderQuantity = 0,
       OrderNetAmount = 0,
       OrderCommission = 0,
       OrderAgencyFee = 0,
       OrderBillAmount = 0,
       OrderResaleTax = 0,
       OrderVendorTax = 0,
       BilledQuantity = 0,
       BilledCommissionAmount = 0,
       BilledAgencyFee = 0,
       BilledNetAmount = 0,
       BilledBillAmount = 0,
       BilledResaleTax = 0,
       BilledVendorTax = 0,
       APQuantity = 0,
       APNetAmount = 0,
       PlanBillToOrderedBillVariance = 0,
       PlanBillToBilledVariance = 0,
       OrderedToBilledVariance = 0,
       OrderedToAPVariance = 0,
	   --#41
		[OrderNumber],
		[OrderLineNumber],
		NULL,
		NULL,
		NULL,
		NULL,
	
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
	
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL,
		NULL

	FROM #media_plan_data

	UPDATE #media_total
	SET MasterPlanID = (SELECT Top 1 MasterPlanID FROM #media_total mt WHERE mt.ClientCode = #media_total.ClientCode AND mt.DivisionCode = #media_total.DivisionCode AND mt.ProductCode = #media_total.ProductCode AND mt.SalesClassCode = #media_total.SalesClassCode AND mt.MediaType = #media_total.MediaType AND mt.CampaignCode = #media_total.CampaignCode AND mt.[Month] = #media_total.[Month] AND mt.VendorCode = #media_total.VendorCode AND MasterPlanID IS NOT NULL)
	WHERE MasterPlanID IS NULL

	UPDATE #media_total
	SET MasterPlanName = (SELECT Top 1 MasterPlanName FROM #media_total mt WHERE mt.ClientCode = #media_total.ClientCode AND mt.DivisionCode = #media_total.DivisionCode AND mt.ProductCode = #media_total.ProductCode AND mt.SalesClassCode = #media_total.SalesClassCode AND mt.MediaType = #media_total.MediaType AND mt.CampaignCode = #media_total.CampaignCode AND mt.[Month] = #media_total.[Month] AND mt.VendorCode = #media_total.VendorCode AND MasterPlanName IS NOT NULL)
	WHERE MasterPlanName IS NULL

	UPDATE #media_total
	SET EstimateID = (SELECT Top 1 EstimateID FROM #media_total mt WHERE mt.ClientCode = #media_total.ClientCode AND mt.DivisionCode = #media_total.DivisionCode AND mt.ProductCode = #media_total.ProductCode AND mt.SalesClassCode = #media_total.SalesClassCode AND mt.MediaType = #media_total.MediaType AND (mt.CampaignCode = #media_total.CampaignCode OR CampaignCode IS NULL) AND mt.[Month] = #media_total.[Month] AND mt.[Year] = #media_total.[Year] AND mt.VendorCode = #media_total.VendorCode AND mt.EstimateID IS NOT NULL)
	WHERE EstimateID IS NULL

	UPDATE #media_total
	SET EstimateName = (SELECT Top 1 EstimateName FROM #media_total mt WHERE mt.ClientCode = #media_total.ClientCode AND mt.DivisionCode = #media_total.DivisionCode AND mt.ProductCode = #media_total.ProductCode AND mt.SalesClassCode = #media_total.SalesClassCode AND mt.MediaType = #media_total.MediaType AND (mt.CampaignCode = #media_total.CampaignCode OR CampaignCode IS NULL) AND mt.[Month] = #media_total.[Month] AND mt.VendorCode = #media_total.VendorCode AND mt.EstimateName IS NOT NULL)
	WHERE EstimateName IS NULL

	UPDATE #media_total
	SET EstimateBudget = (SELECT Top 1 EstimateBudget FROM #media_total mt WHERE mt.ClientCode = #media_total.ClientCode AND mt.DivisionCode = #media_total.DivisionCode AND mt.ProductCode = #media_total.ProductCode AND mt.SalesClassCode = #media_total.SalesClassCode AND mt.MediaType = #media_total.MediaType AND (mt.CampaignCode = #media_total.CampaignCode OR CampaignCode IS NULL) AND mt.[Month] = #media_total.[Month] AND mt.VendorCode = #media_total.VendorCode AND mt.EstimateBudget IS NOT NULL)
	WHERE EstimateBudget IS NULL

	UPDATE #media_total
	SET [MonthName] = CASE WHEN [Month] = 1 THEN 'January'
						   WHEN [Month] = 2 THEN 'February'
						   WHEN [Month] = 3 THEN 'March'
						   WHEN [Month] = 4 THEN 'April'
						   WHEN [Month] = 5 THEN 'May'
						   WHEN [Month] = 6 THEN 'June'
						   WHEN [Month] = 7 THEN 'July'
						   WHEN [Month] = 8 THEN 'August'
						   WHEN [Month] = 9 THEN 'September'
						   WHEN [Month] = 10 THEN 'October'
						   WHEN [Month] = 11 THEN 'November'
						   WHEN [Month] = 12 THEN 'December' END

--SELECT '#media_total', * FROM #media_total WHERE OrderNumber = 207339
--SELECT '#media_plan_data', * FROM #media_plan_data WHERE OrderNumber = 207339

	--#41
	UPDATE A
	SET    	A.MasterPlanID = B.MasterPlanID,
			A.MasterPlanName = B.MasterPlanName,
		   A.PlanUnits = ISNULL(B.Units,0),
		   A.PlanImpressions = ISNULL(B.Impressions,0),
		   A.PlanClicks = ISNULL(B.Clicks,0),
		   A.PlanDemo1 = ISNULL(B.Demo1,0),
		   A.PlanDemo2 = ISNULL(B.Demo2,0),
		   A.PlanQuantity = ISNULL(B.PlanQuantity,0),
		   A.PlanNetAmount = ISNULL(B.PlanNetAmount,0),
		   A.PlanCommission = ISNULL(B.PlanCommission,0),
		   A.PlanAgencyFee = ISNULL(B.AgencyFee,0),
		   A.PlanBillAmount = ISNULL(B.BillAmount,0),
			A.PlanBillToOrderedBillVariance = 0,
			A.PlanBillToBilledVariance = 0
	FROM #media_total A
		INNER JOIN #media_plan_data B ON
			A.EstimateID = B.EstimateID AND A.VendorCode = B.VendorCode AND 
			A.ClientCode = B.ClientCode AND A.DivisionCode = B.DivisionCode AND A.ProductCode = B.ProductCode AND
			A.SalesClassCode = B.SalesClassCode AND A.MediaType = B.MediaType AND  
			--PJH 12/26/2019 - For all except Internet
			A.OrderNumber = B.OrderNumber AND A.OrderLineNumber = B.OrderLineNumber AND  /* PJH 04/06/20 - Added orderNumber AND LineNumber */
			A.MediaType <> 'I'

--SELECT * FROM #media_total WHERE OrderNumber = 207339

	UPDATE A
	SET    	A.MasterPlanID = B.MasterPlanID,
			A.MasterPlanName = B.MasterPlanName,
		   A.PlanUnits = ISNULL(B.Units,0),
		   A.PlanImpressions = ISNULL(B.Impressions,0),
		   A.PlanClicks = ISNULL(B.Clicks,0),
		   A.PlanDemo1 = ISNULL(B.Demo1,0),
		   A.PlanDemo2 = ISNULL(B.Demo2,0),
		   A.PlanQuantity = ISNULL(B.PlanQuantity,0),
		   A.PlanNetAmount = ISNULL(B.PlanNetAmount,0),
		   A.PlanCommission = ISNULL(B.PlanCommission,0),
		   A.PlanAgencyFee = ISNULL(B.AgencyFee,0),
		   A.PlanBillAmount = ISNULL(B.BillAmount,0),
			A.PlanBillToOrderedBillVariance = 0,
			A.PlanBillToBilledVariance = 0
	FROM #media_total A
		INNER JOIN #media_plan_data B ON
			A.EstimateID = B.EstimateID AND A.VendorCode = B.VendorCode AND 
			A.ClientCode = B.ClientCode AND A.DivisionCode = B.DivisionCode AND A.ProductCode = B.ProductCode AND
			A.SalesClassCode = B.SalesClassCode AND A.MediaType = B.MediaType AND
			--PJH 12/26/2019 - Needed to group by Line Market Code - Only for Internet
			A.OrderNumber = B.OrderNumber AND A.OrderLineNumber = B.OrderLineNumber AND  
			A.MediaType = 'I'
	--#41
	DELETE FROM #media_total WHERE OrderNumber IS NULL AND EstimateID IS NOT NULL

	Select [ID] = NEWID(),
			--#41
			OrderNumber = [OrderNumber],
			OrderLineNumber = [OrderLineNumber],
			Headline = [Line Description], --(headline)
			OfficeCode,
			OfficeName,
			ClientCode,
			ClientName,
			DivisionCode,
			DivisionName,
			ProductCode,
			ProductDescription,
			VendorCode,
			VendorName,
			CampaignCode,
			CampaignName,
			MediaType,
			SalesClassCode,
			SalesClassDescription,
			[Month],
			[MonthName],
			[Year],
			MasterPlanID,
			MasterPlanName,
			EstimateID,
			EstimateName,
			EstimateBudget,
			(PlanUnits) AS PlanUnits,
			(PlanImpressions) AS PlanImpressions,
			(PlanClicks) AS PlanClicks,
			(PlanDemo1) AS PlanDemo1,
			(PlanDemo2) AS PlanDemo2,
			(PlanQuantity) AS PlanQuantity,
			(PlanNetAmount) AS PlanNetAmount,
			(PlanCommission) AS PlanCommission,
			(PlanAgencyFee) AS PlanAgencyFee,
			(PlanBillAmount) AS PlanBillAmount,
			(OrderQuantity) AS OrderQuantity,
			(OrderNetAmount) AS OrderNetAmount,
			(OrderCommission) AS OrderCommission,
			(OrderAgencyFee) AS OrderAgencyFee,
			(OrderBillAmount) AS OrderBillAmount,
            (OrderResaleTax) AS OrderResaleTax,
            (OrderVendorTax) AS OrderVendorTax,
			(BilledQuantity) AS BilledQuantity,
			(BilledCommissionAmount) AS BilledCommissionAmount,
			(BilledAgencyFee) AS BilledAgencyFee,
			(BilledNetAmount) AS BilledNetAmount,
			(BilledBillAmount) AS BilledBillAmount,
            (BilledResaleTax) AS BilledResaleTax,
            (BilledVendorTax) AS BilledVendorTax,
			(APQuantity) AS APQuantity,
			(APNetAmount) AS APNetAmount,
			PlanBillToOrderedBillVariance = (OrderBillAmount) - (PlanBillAmount),
			PlanBillToBilledVariance = (BilledBillAmount) - (PlanBillAmount),
			OrderedToBilledVariance = (BilledBillAmount) - (OrderBillAmount),
			OrderedToAPVariance = (APNetAmount) - (OrderNetAmount),
			PlanEstBudgetToPlanBillVariance = (EstimateBudget - (PlanBillAmount)),
			PlanEstBudgetToOrderBillVariance = (EstimateBudget - (OrderBillAmount)),
			--#41
			JobNumber = ([Job Number]),
			JobDescription = ([Job Description]),
			JobComponentNumber = ([Job Component Number]),
			JobComponentDescription = ([Job Component Description]),
	
			AdSize = ([Ad Size]),
			EditionIssue = ([Edition Issue]),
			Section = ([Section]),
			Material = ([Material]),
			Remarks = ([Remarks]),
			URL = ([URL]),
	
			InternetTypeCode = ([Internet Type Code]),
			InternetTypeDescription = ([Internet Type Description]),
			OutOfHomeTypeCode = ([Out of Home Type Code]),
			OutOfHomeTypeDescription = ([Out of Home Type Description]),
			Placement = ([Placement 1]),
			PackageName = ([Placement 2]),
			Location = ([Location]),
			LineMarketCode = ([Line Market Code]),
			LineMarketDescription = ([Line Market Description]),
			TargetAudience = ([Target Audience]),
			AdSizeDescription = ([Creative Size]),
			AdNumber = [Ad Number],
			AdNumberDescription = [Ad Number Description]
   FROM #media_total
   WHERE
			(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND [OfficeCode] IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
			AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND [ClientCode] IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND [ClientCode] + '|' + [DivisionCode] IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND [ClientCode] + '|' + [DivisionCode] + '|' + [ProductCode] IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))	

	ORDER BY OrderNumber,
			OrderLineNumber


END
GO

/* For testing local */
--DROP TABLE #media_plan_data
--DROP TABLE #media_total
--DROP TABLE #media_order_detail
--DROP TABLE #media_order_header
--DROP TABLE #media_order_amounts_sum
--DROP TABLE #media_current_status
--DROP TABLE #media_order_amounts

--RETURN

GRANT EXECUTE ON [advsp_media_comparison_detail_vendor_dataset] TO PUBLIC AS dbo
GO