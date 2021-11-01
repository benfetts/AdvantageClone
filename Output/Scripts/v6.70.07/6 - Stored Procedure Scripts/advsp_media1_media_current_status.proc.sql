--insert the next (3) statements at the top of the script while debugging
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_media_current_status]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_media1_media_current_status]
GO

CREATE PROCEDURE [dbo].[advsp_media1_media_current_status]
	@user_id varchar(100)

AS

-- Stored procedure to extract MEDIA ORDER DATA information (for Media Current Status Reports)
-- #00 08/20/12 - initial release
-- #01 10/24/12 - removed REBATE_AMT from LINE_TOTAL for old bcst
-- #02 10/26/12 - added RESALE_TAX to old bcst netcharges BILL_AMT
-- #03 10/26/12 - corrected calculation for RECNB_BILL_AMT for old bcst (removed REBATE_AMT)
-- #04 10/27/12 - added RESALE_TAX to old bcst netcharges BILLED_BILL_AMT
-- #05 11/01/12 - added [MONTH] and [YEAR] to old bcst AP - MEDIA_ORDER_AMOUNTS
-- #06 11/08/12 - added misc info to old/new bcst detail records
-- #07 12/05/12 - added SPOTS to DETAIL and AMOUNTS tables
-- #08 12/11/12 - added spots for AP amounts
-- #09 02/20/13 - added AP_PRINT_QUANTITY to #print_amounts_ap
-- #09 02/20/13 - populate separate columns in MEDIA_ORDER_AMOUNTS for ordered/billed/AP
-- #10 03/27/13 - Include column names in final INSERT statements (new cols added for invoice printing)
-- #11 02/05/14 - added SPOTS1-7 which had been added earlier to "dbo.advsp_media1_order_bcst_amounts2"
-- #11 02/05/14 - added BLACKPLT_VER1-2 which had been added earlier to "dbo.advsp_media1_order_print_detail"
-- #12 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371) - not used

BEGIN
SET NOCOUNT ON;

 /* NOT USED IN .Net AT THIS POINT */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

---- ==========================================================
---- SECONDARY TABLES
---- ==========================================================
-- Temp table #media_orders - stores table of orders to be processed
CREATE TABLE #media_orders(
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL,
	ORDER_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #media_orders
SELECT [USER_ID], ORDER_NBR, ORDER_TYPE
FROM dbo.MEDIA_RPT_ORDERS AS rd
WHERE UPPER(rd.[USER_ID]) = UPPER(@user_id)
--SELECT * FROM #media_orders

-- ======================================================================
-- SECTION A - EXTRACTION ROUTINES FROM STORED PROCEDURES FOR TEMP TABLES
-- NOTE: THE DETAIL TABLES ONLY EXTRACT DATA FOR THE ACTIVE REVISION
-- ======================================================================
--****************************************************************************************
--PRINT
--****************************************************************************************
--Print Header (dbo.advsp_media1_order_print_header)
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

--Print detail (dbo.advsp_media1_order_print_detail)-----------------------------------
CREATE TABLE #print_detail(
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
	BLACKPLT_VER1					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,		--#11
	BLACKPLT_VER2					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS)		--#11
 INSERT INTO #print_detail EXECUTE dbo.advsp_media1_order_print_detail @user_id
 --SELECT * FROM #print_detail
 
--Print amounts (dbo.advsp_media1_order_print_amounts)---------------------------
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

--Print amounts AP (advsp_media1_order_print_amounts_ap)-------------------------------
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
	AP_ADDL_CHARGE					decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
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
	AP_PRINT_QUANTITY				decimal(14,3) NULL)
INSERT INTO #print_amounts_ap EXECUTE advsp_media1_order_print_amounts_ap @user_id
--SELECT * FROM #print_amounts_ap

--Print amounts AP addl (advsp_media1_order_print_amounts_ap_addl)------------------------------
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

--****************************************************************************************
--BROADCAST (OLD)
--****************************************************************************************
--Broadcast Header (old) (dbo.advsp_media1_order_bcst_header)
CREATE TABLE #bcst_old_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
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
	BILL_TYPE_FLAG					smallint NULL,
	NET_GROSS						smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FLIGHT_FROM						smalldatetime NULL, 
	FLIGHT_TO						smalldatetime NULL,
	BRD_YEAR1						smallint NULL,
	BRD_YEAR2						smallint NULL,
	FIRST_MTH_YR1					smallint NULL,
	LAST_MTH_YR1					smallint NULL,
	FIRST_MTH_YR2					smallint NULL,
	LAST_MTH_YR2					smallint NULL,
	ORD_PROCESS_CONTRL				smallint NULL,
	STATION							smallint NULL,
	REP1							smallint NULL,
	REP2							smallint NULL,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	CREATE_DATE						smalldatetime NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_ACCEPTED					tinyint NULL)	
INSERT INTO #bcst_old_header EXECUTE dbo.advsp_media1_order_bcst_header @user_id
--SELECT * FROM #bcst_old_header

 --Broadcast detail (old) (dbo.advsp_media1_order_bcst_detail)-----------------------------
CREATE TABLE #bcst_old_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL, 
	BRDCAST_YEAR					int NULL,
	DAYS							varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	START_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	END_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[LENGTH]						smallint NULL,
	CLOSE_DATE						smalldatetime NULL,
	MATL_CLOSE_DATE					smalldatetime NULL,   
	MAT_COMP						smalldatetime NULL,  
	PROGRAMMING						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAG								varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	REMARKS							varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GROSS_RATE						decimal(15,2) NULL,
	NET_RATE						decimal(15,2) NULL,
	JOB_NUMBER						int NULL,
	JOB_COMPONENT_NBR				smallint NULL, 
	LINE_CANCELLED					smallint NULL,
	NON_BILL_FLAG					smallint NULL,
	RECONCILE_LINE					smallint NULL,
	DO_NOT_BILL						smallint NULL,
	PRINTED							smallint NULL,
	ORDER_COMMENT					text, 
	POSITION_INFO					text, 
	RATE_INFO						text, 
	CLOSE_INFO						text, 
	MISC_INFO						text, 
	MATL_NOTES						text,
	HOUSE_COMMENT					text)
INSERT INTO #bcst_old_detail EXECUTE dbo.advsp_media1_order_bcst_detail @user_id
--SELECT * FROM #bcst_old_detail

--Broadcast amounts (old) (dbo.advsp_media1_order_bcst_amounts)-------------------------
CREATE TABLE #bcst_old_amounts(
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
	SPOTS							int NULL,
	LINE_NET						decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT						decimal(15,2) NULL,
	VENDOR_TAX						decimal(15,2) NULL,
	STATE_TAX						decimal(15,2) NULL,
	COUNTY_TAX						decimal(15,2) NULL,
	CITY_TAX						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT							int NULL,
	AR_INV_DATE						smalldatetime,
	AR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #bcst_old_amounts EXECUTE dbo.advsp_media1_order_bcst_amounts @user_id	
--SELECT * FROM #bcst_old_amounts

--Broadcast NC amounts (old) (dbo.advsp_media1_order_bcstnc_amounts)---------------------
CREATE TABLE #bcst_old_nc_amounts(
	REC_TYPE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR					int NOT NULL,
	LINE_NBR					int NOT NULL,
	REV_NBR						smallint NOT NULL,
	SEQ_NBR						smallint NOT NULL,
	BRDCAST_PER					int NULL,
	NETCHARGES					decimal(15,2) NULL,
	VENDOR_TAX_NC				decimal(15,2) NULL,
	STATE_TAX_NC				decimal(15,2) NULL,
	COUNTY_TAX_NC				decimal(15,2) NULL,
	CITY_TAX_NC					decimal(15,2) NULL,
	LINE_TOTAL_NC				decimal(15,2) NULL,
	BILLING_AMT_NC				decimal(15,2) NULL,
	AR_INV_NBR					int NULL,
	AR_INV_SEQ					smallint NULL,
	AR_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT						int NULL,
	AR_INV_DATE					smalldatetime,
	AR_POST_PERIOD				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #bcst_old_nc_amounts EXECUTE dbo.advsp_media1_order_bcstnc_amounts @user_id
--SELECT * FROM #bcst_old_nc_amounts

--Broadcast amounts AP (old) (advsp_media1_order_bcst_amounts_ap )--------------------
CREATE TABLE #bcst_old_amounts_ap(
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
	TOTAL_SPOTS						smallint)
INSERT INTO #bcst_old_amounts_ap EXECUTE advsp_media1_order_bcst_amounts_ap @user_id
--SELECT * FROM #bcst_old_amounts_ap

--****************************************************************************************
--BROADCAST (NEW)
--****************************************************************************************
--Broadcast Header (new) (dbo.advsp_media1_order_bcst_header2)
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

--Broadcast detail (new) (dbo.advsp_media1_order_bcst_detail2)---------------------------
CREATE TABLE #bcst_new_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL, 
	ACTIVE_REV						smallint NULL,
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
	EST_REV_NBR						smallint NULL)
INSERT INTO #bcst_new_detail EXECUTE dbo.advsp_media1_order_bcst_detail2 @user_id
--SELECT * FROM #bcst_new_detail

----Broadcast comments (new) (dbo.advsp_media1_order_bcst_detail2)---------------------------
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

--Broadcast amounts (new) (dbo.advsp_media1_order_bcst_amounts2)--------------------------
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
	SPOTS1							int NULL,					--#11
	SPOTS2							int NULL,					--#11
	SPOTS3							int NULL,					--#11
	SPOTS4							int NULL,					--#11
	SPOTS5							int NULL,					--#11
	SPOTS6							int NULL,					--#11
	SPOTS7							int NULL,					--#11
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

--Broadcast amounts AP (new) (advsp_media1_order_bcst_amounts_ap2)----------------------
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
	AP_ADDL_CHARGE					decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
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
	TOTAL_SPOTS						smallint)
INSERT INTO #bcst_new_amounts_ap EXECUTE advsp_media1_order_bcst_amounts_ap2 @user_id
--SELECT * FROM #bcst_new_amounts_ap

--Broadcast amounts AP addl (new) (advsp_media1_order_bcst_amounts_ap_addl2)-------------------
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
	AP_ADDL_CHARGE					decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
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
-- END OF SECTION A

-- ==========================================================
-- SECTION B - POPULATE MEDIA ORDER HEADER TABLE dbo.MEDIA_ORDER_HEADER
-- ==========================================================
-- Clears data records for this USER_ID from dbo.MEDIA_ORDER_HEADER
DELETE dbo.MEDIA_ORDER_HEADER WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id)	--#12
--DELETE dbo.MEDIA_ORDER_HEADER		--used for testing

--Print header------------------------------------------------------
INSERT INTO dbo.MEDIA_ORDER_HEADER
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED)
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
	h.CLIENT_PO,
	h.LINK_ID,
	2,
	h.ORDER_ACCEPTED		
FROM #print_order_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
--SELECT * FROM dbo.MEDIA_ORDER_HEADER

--Broadcast header (old)------------------------------------------------------
INSERT INTO dbo.MEDIA_ORDER_HEADER
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED)
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
	h.BILL_TYPE_FLAG,
	ISNULL(p.PRD_RADIO_PRE_POST,0),
	h.NET_GROSS,
	h.MARKET_CODE,
	m.MARKET_DESC,
	h.ORDER_DATE,
	h.FLIGHT_FROM,
	h.FLIGHT_TO,
	h.ORD_PROCESS_CONTRL,
	h.BUYER,
	h.CLIENT_PO,
	h.LINK_ID,
	1,
	h.ORDER_ACCEPTED		
FROM #bcst_old_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
--SELECT * FROM dbo.MEDIA_ORDER_HEADER			

--Broadcast header (new)------------------------------------------------------
INSERT INTO dbo.MEDIA_ORDER_HEADER
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED)
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
	h.CLIENT_PO,
	h.LINK_ID,
	2,
	h.ORDER_ACCEPTED		
FROM #bcst_new_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
--SELECT * FROM dbo.MEDIA_ORDER_HEADER
-- END OF SECTION B			

-- ==========================================================
-- SECTION C - POPULATE MEDIA ORDER DETAIL TABLE dbo.MEDIA_ORDER_DETAIL
-- ==========================================================
-- Clears data records for this USER_ID from dbo.MEDIA_ORDER_DETAIL
DELETE dbo.MEDIA_ORDER_DETAIL WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id)	--#12
--DELETE dbo.MEDIA_ORDER_DETAIL		--used for testing

--Print detail------------------------------------------------------
INSERT INTO dbo.MEDIA_ORDER_DETAIL
	([USER_ID], ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS)
SELECT
	@user_id,
	d.ORDER_NBR,
	d.LINE_NBR,
	0,
	0,
	'PRN',
	MONTH(d.[START_DATE]),
	YEAR(d.[START_DATE]),
	d.[START_DATE],
	d.END_DATE,
	d.DATE_TO_BILL,
	d.CLOSE_DATE,
	d.MATL_CLOSE_DATE,
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
	NULL,
	0							--#07 (SPOTS are not applicable for print)
FROM #print_detail AS d
--SELECT * FROM dbo.MEDIA_ORDER_DETAIL

--Broadcast detail (old)------------------------------------------------------
INSERT INTO dbo.MEDIA_ORDER_DETAIL
	([USER_ID], ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS)
SELECT
	@user_id,
	d.ORDER_NBR,
	d.LINE_NBR,		
	0,
	0,
	'BRD',
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	d.MATL_CLOSE_DATE,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	d.REMARKS,
	NULL,
	NULL,
	d.MATL_NOTES,
	d.POSITION_INFO,
	d.MISC_INFO,				--#06
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	NULL,
	NULL,
	NULL,
	NULL,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	h.BILL_TYPE_FLAG,
	NULL,
	0							--#07 (ordered SPOTS are not in the old detail table)
FROM #bcst_old_detail AS d
JOIN #bcst_old_header AS h
	ON d.ORDER_NBR = h.ORDER_NBR
--SELECT * FROM dbo.MEDIA_ORDER_DETAIL

--Broadcast detail (new)------------------------------------------------------
INSERT INTO dbo.MEDIA_ORDER_DETAIL
	([USER_ID], ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS)
SELECT
	@user_id,
	d.ORDER_NBR,
	d.LINE_NBR,
	0,
	0,
	'BRD',
	MONTH(d.[START_DATE]),		--NULL,
	YEAR(d.[START_DATE]),		--NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	d.MATL_CLOSE_DATE,
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
	c.MISC_INFO,				--#06
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	NULL,
	NULL,
	NULL,
	NULL,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	NULL,
	d.TOTAL_SPOTS				--#07
FROM #bcst_new_detail AS d
LEFT JOIN #bcst_new_comments AS c
	ON d.ORDER_NBR = c.ORDER_NBR
	AND d.LINE_NBR = c.LINE_NBR
--SELECT * FROM dbo.MEDIA_ORDER_DETAIL
-- END OF SECTION C

-- ==========================================================
-- SECTION D - POPULATE MEDIA_ORDER_AMOUNTS table dbo.MEDIA_ORDER_AMOUNTS
-- SEE ADRPTS MACRO "MedRpts OrderDetail"
-- ==========================================================
-- Clears data records for this USER_ID from the main data table
DELETE dbo.MEDIA_ORDER_AMOUNTS WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id)	--#12
--DELETE dbo.MEDIA_ORDER_AMOUNTS		--used for testing

--1. Print ORDER data - (see Adrpts query "MedRpts OrderDetail Print")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	--[MONTH],
	--[YEAR],
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
	END,
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NETCHARGE
	END,		
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN DISCOUNT_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN ADDL_CHARGE
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN COMM_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN REBATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 AND ACTIVE_REV = 1 THEN CITY_AMT + COUNTY_AMT + STATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN LINE_TOTAL
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1  AND BILL_TYPE_FLAG <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN BILLING_AMT
	END,		
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	PRINT_QUANTITY								--#09 (for newspaper and internet)
FROM #print_detail

--2. Print BILLING data - (see Adrpts query "MedRpts BilledPrint")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY)
SELECT
	@user_id,
	ORDER_TYPE,
	'B',
	ORDER_NBR,
	LINE_NBR,
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	EXT_NET_AMT,
	DISCOUNT_AMT,
	NETCHARGE,
	NON_RESALE_AMT,
	CASE
		WHEN BILL_TYPE_FLAG = 2 OR BILL_TYPE_FLAG = 3 THEN 
		EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	CITY_AMT + COUNTY_AMT + STATE_AMT,
	BILLING_AMT,
	AR_INV_NBR,
	AR_INV_SEQ,
	AR_TYPE,
	GLEXACT,
	PRINT_QUANTITY					--#09 (newspaper PRINT_LINES and internet GUARANTEED_IMPRESS)	
FROM #print_amounts
WHERE AR_INV_NBR IS NOT NULL

--3. Broadcast ORDER data (old) - (see Adrpts query "MedRpts OrderDetail Bcst")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
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
	RECNB_BILL_AMT,
	RECNB_NET_AMT,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'O',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.MONTH_IND,
	a.BRDCAST_YEAR,
	LINE_NET,
	0,
	DISCOUNT,
	0,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	CITY_TAX + COUNTY_TAX + STATE_TAX,
	LINE_NET + COMM_AMT + VENDOR_TAX + DISCOUNT,		--#01
	LINE_NET + DISCOUNT + VENDOR_TAX,
	CASE
		WHEN f.BILL_TYPE_FLAG <> 1 THEN LINE_NET + DISCOUNT + VENDOR_TAX
	END,
	BILLING_AMT,
	CASE
		WHEN d.DO_NOT_BILL = 1 AND f.BILL_TYPE_FLAG = 2 THEN LINE_NET + DISCOUNT + VENDOR_TAX			
		WHEN d.DO_NOT_BILL = 1 AND f.BILL_TYPE_FLAG = 3 THEN LINE_NET + DISCOUNT + VENDOR_TAX + COMM_AMT		--#03
		ELSE 0
	END,	
	CASE
		WHEN d.DO_NOT_BILL =1 THEN LINE_NET + DISCOUNT + VENDOR_TAX
	END,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	0									--#07 (ordered SPOTS are not in the old detail table)
FROM #bcst_old_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR	
	
--4. Broadcast BILLING data (old) - (see Adrpts query "MedRpts BilledBcst")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'B',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.MONTH_IND,
	a.BRDCAST_YEAR,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN LINE_NET
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN DISCOUNT
	END,	
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN VENDOR_TAX
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN LINE_NET + VENDOR_TAX + DISCOUNT
	END,
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 1 OR f.BILL_TYPE_FLAG = 3 THEN	COMM_AMT
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 1 OR f.BILL_TYPE_FLAG = 3 THEN	REBATE_AMT
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN CITY_TAX + COUNTY_TAX + STATE_TAX
	END,
	BILLING_AMT,
	AR_INV_NBR,
	AR_INV_SEQ,
	AR_TYPE,
	GLEXACT,
	0						--a.SPOTS							--#07
FROM #bcst_old_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR
WHERE a.AR_INV_NBR IS NOT NULL	

--5. Broadcast ORDER data (new) - (see Adrpts query "MedRpts OrderDetail Bcst2")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	END,
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NETCHARGE
	END,		
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN DISCOUNT_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN ADDL_CHARGE
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN COMM_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN REBATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 AND ACTIVE_REV = 1 THEN CITY_AMT + COUNTY_AMT + STATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN LINE_TOTAL
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1  AND BILL_TYPE_FLAG <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN BILLING_AMT
	END,		
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	TOTAL_SPOTS							--#07
FROM #bcst_new_detail

--6. Broadcast BILLING data (new) - (see Adrpts query "MedRpts BilledBcst2")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY)
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
	a.AR_INV_SEQ,
	a.AR_TYPE,
	a.GLEXACT,
	a.SPOTS							--#07	
FROM #bcst_new_amounts as a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
WHERE a.AR_INV_NBR IS NOT NULL		
	
--7. Broadcast Netcharge ORDER data (old) - (see Adrpts query "MedRptsOrderDetail BcstNC")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
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
	BILL_TYPE_FLAG)
SELECT
	@user_id,
	a.ORDER_TYPE + 'N',
	'O',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.BRDCAST_PER % 100,
	a.BRDCAST_PER / 100,
	0,
	NETCHARGES,
	0,
	0,
	0,
	0,
	VENDOR_TAX_NC,
	CITY_TAX_NC + COUNTY_TAX_NC + STATE_TAX_NC,
	NETCHARGES + VENDOR_TAX_NC,
	NETCHARGES + VENDOR_TAX_NC,
	CASE
		WHEN f.BILL_TYPE_FLAG <> 1 THEN NETCHARGES + VENDOR_TAX_NC		
	END,	
	CASE
		WHEN f.BILL_TYPE_FLAG <> 1 THEN NETCHARGES + VENDOR_TAX_NC + CITY_TAX_NC 
			+ COUNTY_TAX_NC + STATE_TAX_NC		--#02
	END,	
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG
FROM #bcst_old_nc_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR	
	
--8. Broadcast Netcharge BILLING data (old) - (see Adrpts query "MedRpts BilledBcstNC")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL)
SELECT
	@user_id,
	a.ORDER_TYPE + 'N',
	'B',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.BRDCAST_PER % 100,
	a.BRDCAST_PER / 100,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	0,
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	NETCHARGES
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	VENDOR_TAX_NC
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	NETCHARGES + VENDOR_TAX_NC
	END,
	0,
	0,
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	CITY_TAX_NC + COUNTY_TAX_NC + STATE_TAX_NC
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	NETCHARGES + VENDOR_TAX_NC 
			+ CITY_TAX_NC + COUNTY_TAX_NC + STATE_TAX_NC		--#04
	END,
	AR_INV_NBR,
	AR_INV_SEQ,
	AR_TYPE,
	GLEXACT
FROM #bcst_old_nc_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR
WHERE a.AR_INV_NBR IS NOT NULL

--9. Print AP data - (see Adrpts query "MedRpts APPrint")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	a.AP_INV_VCHR,
	a.AP_GLEXACT,
	a.AP_PRINT_QUANTITY						--#09
FROM #print_amounts_ap AS a
JOIN #print_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
	
--10. Print AP data additional - (see Adrpts query "MedRpts APPrint_addl")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	0							--#08 spots not applicable for print AP additional
FROM #print_amounts_ap_addl AS a
JOIN #print_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR

--11. Broadcast AP data (old) - (see Adrpts query "MedRpts APBcst")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	a.ORDER_TYPE,
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	a.[MONTH],				--#05			
	a.[YEAR],				--#05
	0,		--ISNULL(d.NON_BILL_FLAG,0),
	0,		--d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES,
	a.AP_NETCHARGES,
	a.AP_DISCOUNT_AMT,
	a.AP_COMM_AMT,
	a.AP_REBATE_AMT,
	a.AP_VENDOR_TAX,
	a.AP_CITY_TAX + a.AP_COUNTY_TAX + a.AP_STATE_TAX,
	CASE
		WHEN BILL_TYPE_FLAG = 3 THEN a.AP_LINE_TOTAL
		ELSE a.AP_LINE_TOTAL -(a.AP_COMM_AMT + a.AP_REBATE_AMT)		
	END,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_GLEXACT,
	0					--a.TOTAL_SPOTS					--#08
FROM #bcst_old_amounts_ap AS a
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR	
	
--12. Broadcast AP data (new) - (see Adrpts query "MedRpts APBcst2")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	a.[MONTH],			--#05
	a.[YEAR],			--#05
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES,
	0,
	0,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	0,
	0,
	CASE
		WHEN BILL_TYPE_FLAG = 3 THEN a.AP_LINE_TOTAL
		ELSE a.AP_LINE_TOTAL -(a.AP_COMM_AMT + a.AP_REBATE_AMT)		
	END,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_GLEXACT,
	a.TOTAL_SPOTS					--#08
FROM #bcst_new_amounts_ap AS a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
	
--13. Broadcast AP data additional (new) - (see Adrpts query "MedRpts APBcst_addl2")
INSERT INTO dbo.MEDIA_ORDER_AMOUNTS(
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
	[MONTH],			--#05
	[YEAR],				--#05
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
	0					--#08 spots not applicable for AP additional
FROM #bcst_new_amounts_ap_addl AS a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR	

--SELECT * FROM dbo.MEDIA_ORDER_HEADER
--SELECT * FROM dbo.MEDIA_ORDER_DETAIL
--SELECT * FROM dbo.MEDIA_ORDER_AMOUNTS
--SELECT @user_id AS [USER_ID]

END

GO


