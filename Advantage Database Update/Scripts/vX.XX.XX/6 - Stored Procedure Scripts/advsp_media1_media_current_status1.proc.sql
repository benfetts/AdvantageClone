IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_media1_media_current_status1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_media1_media_current_status1]
GO

CREATE PROCEDURE [dbo].[advsp_media1_media_current_status1]  ( 	
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
	@OfficeCodeList			varchar(max)=null,
	@ClientCodeList			varchar(max)=null,
	@ClientDivisionCodeList varchar(max)=null,
	@ClientDivisionProductCodeList varchar(max)=null,
	@broadcast_dates		bit				= 0,	--#41
	@revisions				bit				= 0,	--#42
	@user_id varchar(100),
	@VendorCodeList  varchar(max)			=null,
	@MarketCodeList  varchar(max)			=null
	)

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
-- #10 03/27/13 - Include column names in final INSERT  (new cols added for invoice printing)
-- #11 04/22/13 - Substitute temp tables for Advantage tables and add code from view 
-- #12 03/01/14 - Changed newspaper quantity to consistently use PRINT_LINES when COST_TYPE = "CPM", else 0 (see section D)
-- #13 04/04/14 - added PRINT_QUANTITY to #media_order_detail and remapped PRINT_LINES
-- #14 08/12/14 - fixed year/month for broadcast in #media_order_detail (735-1341)
-- #15 12/20/14 - (v670) added AP payment info (3388-1)
-- #16 12/24/14 - (v670) added AR payment info (3388-2)
-- #17 01/16/15 - (v670) fixes (note this is based on v660.03, updates will need to be made later based on v6.60.04 mods below)
-- #18 01/19/15 - added FISCAL_PERIOD_CODE (hdr), CIRCULATION (dtl), and RATE_INFO (cmts2) (from v6.60.04 #14 07/14/14)
-- #19 01/24/15 - (v670) added BILL_COOP_CODE (hdr) (3388-3)
-- #20 02/05/15 - (v670) modificactions for consistency with advsp_media1_media_current_status1_sum
-- #21 02/12/15 - added missing join based on LINE_NBR (from v6.60.04 #16 01/10/15)
-- #22 02/18/15 - (v670) fixes and enhancements for AP/AR payment flag info
-- #23 02/24/15 - (v670) filter old bcst based on start and and end periods (may omit old bcst later)
-- #24 02/24/15 - (v670) reset MEDIA_RPT_ORDERS for faster processing
-- #25 03/11/15 - (v670) move AP/AR payment processing to detail section for consistency with summary version
-- #26 03/18/15 - (v670) removed old bcst, new links to advsp_media1_order_print_detail_active (bcst_detail2_active)
-- #27 03/20/15 - (v670) changed PRINT_LINES to PRINT_QUANTITY for ordered internet in #media_order_amounts
-- #28 03/30/15 - (v670) include net charges, vendor tax and discount in AP payment amount
-- #29 04/06/15 - (v670) populate AP amounts columns in #media_order_amounts
-- #30 04/08/15 - (v670) fix AP Payment Amount calculation and add [APDisbursedAmount]
-- #31 04/13/15 - (v670) fix AP Payment Amount calculation
-- #32 05/12/15 - (v670) add AR invoice date and AP invoice date, also convert nulls to 0 in order amounts - same as v660 #19 (735-1768)
-- #33 01/18/16 - (v670) add new fields for API
-- #34 04/13/16 - (v670) Add the default AE name and code (emp code) to the dataset based on the default for the CDP on the order. (735-2-846)
-- #34 04/13/16 - (v670) Add Create User and Create Date from media header. (735-2-846)
-- #35 06/14/16 - (v670) Add Vendor Payment Method.  (2130-1-410)
-- #36 10/15/16 - (v670) removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)
-- #37 11/22/16 - (v67001) add the Client PO description from the client po maintenance application  (735-2-999)
-- #38 02/20/17 - {v67001} add new data set columns  (4077-1-12)
-- #39 06/26/17 - Dynamic Reports - Add Placement 1,  Projected Impressions and Actual Impressions to the Media Current Status & Media Current Status Summary reports (735-2-1132)
-- #40 06/26/18 - Added office and CDP filters
-- #41 06/28/19 - @broadcast_dates
-- #42 07/01/19 - @revisions
-- #43 07/26/19 - 735-1-3936 - Order Flight From and Order Flight To data fields are blank, 735-2-3758 - Add Headline, 4077-1-42 - Adding Shipping City Field
-- #44 09/18/19 - 735-2-3743 - Dynamic Reports - Add a Source column for Media reports that show ratings and impressions from the worksheet
-- #45 08/26/20 - 735-1-4504 - Dynamic Reports, Current Media Status dataset - Order Accepted column shows 0 for all status
-- #46 09/17/20 - Changed AND mh.VR_CODE = vr2.VR_CODE to AND mh.[VR_CODE2] = vr2.VR_CODE'
-- #47 08/26/21 - BC WS ID/Name
--START OF SHARED CODE WITH advsp_media1_media_current_status1_sum
--*****************************************************************************
AS
BEGIN
SET NOCOUNT ON;

 /* IS USED IN .Net AT THIS POINT - \AdvantageFramework.BLogic\Reporting\Methods.vb(9191): MediaCurrentStatusReports = ... */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END


/* Used for date calculation */   --#41
DECLARE @cutoff_start_dt smalldatetime
DECLARE @cutoff_end_dt smalldatetime
DECLARE @brdcast_weeks TABLE (
	BRD_YEAR int,
	BRD_WEEK_START smalldatetime,
	BRD_WEEK_END smalldatetime,
	MONTH_NAME varchar(3)
	)

DECLARE @brdcast_weeks2 TABLE (
	BRD_YEAR int,
	BRD_MONTH int,
	BRD_WEEK_START smalldatetime,
	BRD_WEEK_END smalldatetime,
	MONTH_NAME varchar(3),
	WEEK_NBR int,
	MMYYYY varchar(6)
	)

IF @broadcast_dates = 1 BEGIN			--#41

	SELECT @cutoff_start_dt = DATEADD(day, -7, @start_date) /* Start date minus 1 week to cover broadcast week start date */
	SELECT @cutoff_end_dt = DATEADD(day, 7, @end_date) /* End  date plus 1 week to cover broadcast week end date */

	/* Populate broadcast calendar for given period */
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK1, DATEADD(d, 6, JAN_WK1) JAN_WK1_END , LEFT('JAN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK1 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK2, DATEADD(d, 6, JAN_WK2) JAN_WK2_END , LEFT('JAN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK2 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK3, DATEADD(d, 6, JAN_WK3) JAN_WK3_END , LEFT('JAN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK3 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK4, DATEADD(d, 6, JAN_WK4) JAN_WK4_END , LEFT('JAN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK4 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK5, DATEADD(d, 6, JAN_WK5) JAN_WK5_END , LEFT('JAN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK5 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK1, DATEADD(d, 6, FEB_WK1) FEB_WK1_END , LEFT('FEB_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK1 > @cutoff_start_dt AND FEB_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK2, DATEADD(d, 6, FEB_WK2) FEB_WK2_END , LEFT('FEB_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK2 > @cutoff_start_dt AND FEB_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK3, DATEADD(d, 6, FEB_WK3) FEB_WK3_END , LEFT('FEB_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK3 > @cutoff_start_dt AND FEB_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK4, DATEADD(d, 6, FEB_WK4) FEB_WK4_END , LEFT('FEB_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK4 > @cutoff_start_dt AND FEB_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK5, DATEADD(d, 6, FEB_WK5) FEB_WK5_END , LEFT('FEB_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK5 > @cutoff_start_dt AND FEB_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK1, DATEADD(d, 6, MAR_WK1) MAR_WK1_END , LEFT('MAR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK1 > @cutoff_start_dt AND MAR_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK2, DATEADD(d, 6, MAR_WK2) MAR_WK2_END , LEFT('MAR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK2 > @cutoff_start_dt AND MAR_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK3, DATEADD(d, 6, MAR_WK3) MAR_WK3_END , LEFT('MAR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK3 > @cutoff_start_dt AND MAR_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK4, DATEADD(d, 6, MAR_WK4) MAR_WK4_END , LEFT('MAR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK4 > @cutoff_start_dt AND MAR_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK5, DATEADD(d, 6, MAR_WK5) MAR_WK5_END , LEFT('MAR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK5 > @cutoff_start_dt AND MAR_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK1, DATEADD(d, 6, APR_WK1) APR_WK1_END , LEFT('APR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK1 > @cutoff_start_dt AND APR_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK2, DATEADD(d, 6, APR_WK2) APR_WK2_END , LEFT('APR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK2 > @cutoff_start_dt AND APR_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK3, DATEADD(d, 6, APR_WK3) APR_WK3_END , LEFT('APR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK3 > @cutoff_start_dt AND APR_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK4, DATEADD(d, 6, APR_WK4) APR_WK4_END , LEFT('APR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK4 > @cutoff_start_dt AND APR_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK5, DATEADD(d, 6, APR_WK5) APR_WK5_END , LEFT('APR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK5 > @cutoff_start_dt AND APR_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK1, DATEADD(d, 6, MAY_WK1) MAY_WK1_END , LEFT('MAY_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK1 > @cutoff_start_dt AND MAY_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK2, DATEADD(d, 6, MAY_WK2) MAY_WK2_END , LEFT('MAY_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK2 > @cutoff_start_dt AND MAY_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK3, DATEADD(d, 6, MAY_WK3) MAY_WK3_END , LEFT('MAY_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK3 > @cutoff_start_dt AND MAY_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK4, DATEADD(d, 6, MAY_WK4) MAY_WK4_END , LEFT('MAY_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK4 > @cutoff_start_dt AND MAY_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK5, DATEADD(d, 6, MAY_WK5) MAY_WK5_END , LEFT('MAY_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK5 > @cutoff_start_dt AND MAY_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK1, DATEADD(d, 6, JUN_WK1) JUN_WK1_END , LEFT('JUN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK1 > @cutoff_start_dt AND JUN_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK2, DATEADD(d, 6, JUN_WK2) JUN_WK2_END , LEFT('JUN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK2 > @cutoff_start_dt AND JUN_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK3, DATEADD(d, 6, JUN_WK3) JUN_WK3_END , LEFT('JUN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK3 > @cutoff_start_dt AND JUN_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK4, DATEADD(d, 6, JUN_WK4) JUN_WK4_END , LEFT('JUN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK4 > @cutoff_start_dt AND JUN_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK5, DATEADD(d, 6, JUN_WK5) JUN_WK5_END , LEFT('JUN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK5 > @cutoff_start_dt AND JUN_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK1, DATEADD(d, 6, JUL_WK1) JUL_WK1_END , LEFT('JUL_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK1 > @cutoff_start_dt AND JUL_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK2, DATEADD(d, 6, JUL_WK2) JUL_WK2_END , LEFT('JUL_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK2 > @cutoff_start_dt AND JUL_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK3, DATEADD(d, 6, JUL_WK3) JUL_WK3_END , LEFT('JUL_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK3 > @cutoff_start_dt AND JUL_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK4, DATEADD(d, 6, JUL_WK4) JUL_WK4_END , LEFT('JUL_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK4 > @cutoff_start_dt AND JUL_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK5, DATEADD(d, 6, JUL_WK5) JUL_WK5_END , LEFT('JUL_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK5 > @cutoff_start_dt AND JUL_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK1, DATEADD(d, 6, AUG_WK1) AUG_WK1_END , LEFT('AUG_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK1 > @cutoff_start_dt AND AUG_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK2, DATEADD(d, 6, AUG_WK2) AUG_WK2_END , LEFT('AUG_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK2 > @cutoff_start_dt AND AUG_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK3, DATEADD(d, 6, AUG_WK3) AUG_WK3_END , LEFT('AUG_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK3 > @cutoff_start_dt AND AUG_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK4, DATEADD(d, 6, AUG_WK4) AUG_WK4_END , LEFT('AUG_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK4 > @cutoff_start_dt AND AUG_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK5, DATEADD(d, 6, AUG_WK5) AUG_WK5_END , LEFT('AUG_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK5 > @cutoff_start_dt AND AUG_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK1, DATEADD(d, 6, SEP_WK1) SEP_WK1_END , LEFT('SEP_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK1 > @cutoff_start_dt AND SEP_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK2, DATEADD(d, 6, SEP_WK2) SEP_WK2_END , LEFT('SEP_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK2 > @cutoff_start_dt AND SEP_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK3, DATEADD(d, 6, SEP_WK3) SEP_WK3_END , LEFT('SEP_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK3 > @cutoff_start_dt AND SEP_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK4, DATEADD(d, 6, SEP_WK4) SEP_WK4_END , LEFT('SEP_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK4 > @cutoff_start_dt AND SEP_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK5, DATEADD(d, 6, SEP_WK5) SEP_WK5_END , LEFT('SEP_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK5 > @cutoff_start_dt AND SEP_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK1, DATEADD(d, 6, OCT_WK1) OCT_WK1_END , LEFT('OCT_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK1 > @cutoff_start_dt AND OCT_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK2, DATEADD(d, 6, OCT_WK2) OCT_WK2_END , LEFT('OCT_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK2 > @cutoff_start_dt AND OCT_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK3, DATEADD(d, 6, OCT_WK3) OCT_WK3_END , LEFT('OCT_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK3 > @cutoff_start_dt AND OCT_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK4, DATEADD(d, 6, OCT_WK4) OCT_WK4_END , LEFT('OCT_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK4 > @cutoff_start_dt AND OCT_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK5, DATEADD(d, 6, OCT_WK5) OCT_WK5_END , LEFT('OCT_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK5 > @cutoff_start_dt AND OCT_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK1, DATEADD(d, 6, NOV_WK1) NOV_WK1_END , LEFT('NOV_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK1 > @cutoff_start_dt AND NOV_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK2, DATEADD(d, 6, NOV_WK2) NOV_WK2_END , LEFT('NOV_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK2 > @cutoff_start_dt AND NOV_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK3, DATEADD(d, 6, NOV_WK3) NOV_WK3_END , LEFT('NOV_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK3 > @cutoff_start_dt AND NOV_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK4, DATEADD(d, 6, NOV_WK4) NOV_WK4_END , LEFT('NOV_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK4 > @cutoff_start_dt AND NOV_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK5, DATEADD(d, 6, NOV_WK5) NOV_WK5_END , LEFT('NOV_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK5 > @cutoff_start_dt AND NOV_WK5 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK1, DATEADD(d, 6, DEC_WK1) DEC_WK1_END , LEFT('DEC_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK1 > @cutoff_start_dt AND DEC_WK1 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK2, DATEADD(d, 6, DEC_WK2) DEC_WK2_END , LEFT('DEC_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK2 > @cutoff_start_dt AND DEC_WK2 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK3, DATEADD(d, 6, DEC_WK3) DEC_WK3_END , LEFT('DEC_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK3 > @cutoff_start_dt AND DEC_WK3 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK4, DATEADD(d, 6, DEC_WK4) DEC_WK4_END , LEFT('DEC_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK4 > @cutoff_start_dt AND DEC_WK4 < @cutoff_end_dt
	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK5, DATEADD(d, 6, DEC_WK5) DEC_WK5_END , LEFT('DEC_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK5 > @cutoff_start_dt AND DEC_WK5 < @cutoff_end_dt

	INSERT INTO @brdcast_weeks2
	SELECT 
		BRD_YEAR, 
		MONTH(CAST(MONTH_NAME + ' 1 2001' AS smalldatetime)) BRD_MONTH, 
		BRD_WEEK_START, 
		BRD_WEEK_END, 
		MONTH_NAME, 
		RANK() OVER (PARTITION BY BRD_YEAR, MONTH_NAME 
					ORDER BY BRD_YEAR, BRD_WEEK_START) AS WEEK_NBR,
		RIGHT('00' + CAST(MONTH(CAST(MONTH_NAME + ' 1 2001' AS smalldatetime)) AS varchar(2)), 2) + CAST(BRD_YEAR AS varchar(4)) AS MMYYYY
	FROM @brdcast_weeks 
	ORDER BY BRD_YEAR, BRD_MONTH, BRD_WEEK_START

	--SELECT @start_date '@start_date', @end_date '@end_date'  --#41  --DEBUG

	/* Set Start and end dates to their broadcast equivelants */
	SELECT @start_date = MIN(BRD_WEEK_START) FROM @brdcast_weeks2 WHERE BRD_MONTH = @start_month AND BRD_YEAR = @start_year
	SELECT @end_date = MAX(BRD_WEEK_END) FROM @brdcast_weeks2 WHERE BRD_MONTH = @end_month AND BRD_YEAR = @end_year

	--SELECT @start_date '@start_date', @end_date '@end_date'  --#41  --DEBUG

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
	@include_internet, @include_magazine, @include_newspaper, @include_outofhome, @revisions		
 
 --SELECT '#print_detail' '#print_detail',  * FROM #print_detail /* <<<<<<<<<<<<<<<<< DEBUG */
 
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
	@start_month, @start_year, @end_month, @end_year, @include_radio, @include_television, @revisions				

--SELECT '#bcst_new_detail' '#bcst_new_detail', * FROM #bcst_new_detail /* <<<<<<<<<<<<<<<<< DEBUG */

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
	[USER_ID]						varchar(100) NOT NULL,
	ORDER_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR					int NOT NULL,
	LINE_NBR						smallint NOT NULL,
	REV_NBR						smallint NULL,
	SEQ_NBR						tinyint NULL,
	DATE_TYPE					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[MONTH]						tinyint NULL,
	[YEAR]							smallint NULL,
	INSERT_DATE				smalldatetime,
	END_DATE						smalldatetime,
	DATE_TO_BILL				smalldatetime,
	CLOSE_DATE					smalldatetime,
	MATL_CLOSE_DATE		smalldatetime,
	EXT_CLOSE_DATE				smalldatetime,
	EXT_MATL_DATE				smalldatetime,
	LINE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AD_SIZE						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EDITION_ISSUE				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SECTION						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MATERIAL						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PLACEMENT_1				varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#39
	PLACEMENT_2				varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#39
	REMARKS						text,
	PROJ_IMPRESSIONS		int NULL,																				--#39
	ACT_IMPRESSIONS		int NULL,																				--#39
	URL								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COPY_AREA					text,
	MATL_NOTES					text,
	POSITION_INFO				text,
	MISC_INFO					text,
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR	smallint NULL,
	COST_TYPE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE_TYPE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	PRINT_LINES					decimal(11,2) NULL,							--#13
	GUARANTEED_IMPRESS	int NULL,
	NON_BILL_FLAG				tinyint NULL DEFAULT 0,
	LINE_CANCELLED			tinyint NULL DEFAULT 0,
	BILLED_TYPE_FLAG		tinyint NULL DEFAULT 0,
	LINK_ID						int NULL,
	SPOTS							int NULL,
	PRINT_QUANTITY			decimal(14,3) NULL,											--#13
	CIRCULATION				int NULL,													--#18
	RATE_INFO					text,														--#18
	IN_HOUSE_CMTS			text,	
	[LOCATION]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GRP								decimal(18,5) NULL,
	GROSS_IMPRESSIONS				decimal(18,5) NULL,
	MEDIA_DEMO_DESCRIPTION			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BOOKEND							bit NULL,
	VALUE_ADDED						bit NULL)														
	
--1. Print detail
INSERT INTO #media_order_detail
	([USER_ID], ORDER_TYPE, ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, EXT_CLOSE_DATE, EXT_MATL_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS, PRINT_QUANTITY, CIRCULATION, RATE_INFO, IN_HOUSE_CMTS,
	PLACEMENT_1, PLACEMENT_2, PROJ_IMPRESSIONS, ACT_IMPRESSIONS, [LOCATION]) --#39
SELECT
	@user_id,
	d.ORDER_TYPE,
	d.ORDER_NBR, 
	d.LINE_NBR,
	CASE WHEN @revisions = 0 THEN 0 ELSE d.REV_NBR END,												--0,	--#42
	CASE WHEN @revisions = 0 THEN 0 ELSE d.SEQ_NBR END,												--0,	--#42
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
	d.PRINT_QUANTITY,															--#13
	d.CIRCULATION,																--#18
	d.RATE_INFO,																	--#18
	d.IN_HOUSE_CMTS	,
	d.PLACEMENT_1,																--#39
	d.PLACEMENT_2, 																--#39
	d.PROJ_IMPRESSIONS, 														--#39
	d.ACT_IMPRESSIONS,															--#39																				
	d.[LOCATION]																
FROM #print_detail AS d

--SELECT '#media_order_detail' '#media_order_detail', * FROM #media_order_detail WHERE DATE_TYPE = 'PRN' /* <<<<<<<<<<<<<<<<< DEBUG */

--2. Broadcast detail (new)
INSERT INTO #media_order_detail
	([USER_ID], ORDER_TYPE, ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, EXT_CLOSE_DATE, EXT_MATL_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS, PRINT_QUANTITY, CIRCULATION, RATE_INFO, IN_HOUSE_CMTS,
	GRP, GROSS_IMPRESSIONS, MEDIA_DEMO_DESCRIPTION, BOOKEND, VALUE_ADDED)
SELECT
	@user_id,
	d.ORDER_TYPE, 
	d.ORDER_NBR,
	d.LINE_NBR,
	CASE WHEN @revisions = 0 THEN 0 ELSE d.REV_NBR END,												--0,	--#42
	CASE WHEN @revisions = 0 THEN 0 ELSE d.SEQ_NBR END,												--0,	--#42
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
	c.IN_HOUSE_CMTS,
	d.GRP,
	d.GROSS_IMPRESSIONS,
	d.MEDIA_DEMO_DESCRIPTION,
	d.BOOKEND,
	d.VALUE_ADDED 
FROM #bcst_new_detail AS d
LEFT JOIN #bcst_new_comments AS c
	ON d.ORDER_NBR = c.ORDER_NBR
	AND d.LINE_NBR = c.LINE_NBR	

--SELECT '#media_order_detail' '#media_order_detail', * FROM #media_order_detail WHERE DATE_TYPE = 'BRD' /* <<<<<<<<<<<<<<<<< DEBUG */

--=============================================================================
--C. POPULATE dbo.MEDIA_RPT_ORDERS BASED ON #media_order_detail
--=============================================================================
DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id)	--#36
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
	ON h.CLIENT_PO = cp.CLIENT_PO_NUMBER AND h.CL_CODE = cp.CL_CODE AND h.DIV_CODE = cp.DIV_CODE AND h.PRD_CODE = cp.PRD_CODE

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
	ON h.CLIENT_PO = cp.CLIENT_PO_NUMBER AND h.CL_CODE = cp.CL_CODE AND h.DIV_CODE = cp.DIV_CODE AND h.PRD_CODE = cp.PRD_CODE

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

--SELECT * FROM #print_amounts /* <<<<<<<<<<<<<<<<< DEBUG */

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

--SELECT * FROM #print_amounts_ap  /* <<<<<<<<<<<<<<<<< DEBUG */

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

--SELECT * FROM #print_amounts_ap_addl /* <<<<<<<<<<<<<<<<< DEBUG */

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

--SELECT * FROM #bcst_new_amounts /* <<<<<<<<<<<<<<<<< DEBUG */

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

--SELECT * FROM #bcst_new_amounts_ap /* <<<<<<<<<<<<<<<<< DEBUG */

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

--SELECT * FROM #bcst_new_amounts_ap_addl /* <<<<<<<<<<<<<<<<< DEBUG */

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
UNION
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
	CR_PAYMENT_AMT			decimal(15,2) NULL DEFAULT 0,
	GRP						decimal(18,5) NULL,
	GROSS_IMPRESSIONS		decimal(18,5) NULL,
	MEDIA_DEMO_DESCRIPTION	varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BOOKEND					bit NULL,
	VALUE_ADDED				bit NULL)
	
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

--SELECT * FROM #print_detail  /* <<<<<<<<<<<<<<<<< DEBUG */

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
	--AND (a.REV_NBR = d.REV_NBR OR @revisions = 0)
	--AND (a.SEQ_NBR = d.SEQ_NBR OR @revisions = 0)
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
	CR_PAYMENT_AMT,
	GRP,
	GROSS_IMPRESSIONS,
	MEDIA_DEMO_DESCRIPTION,
	BOOKEND,
	VALUE_ADDED)
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
	END,
	a.GRP,
	a.GROSS_IMPRESSIONS,
	a.MEDIA_DEMO_DESCRIPTION,
	a.BOOKEND,
	a.VALUE_ADDED
FROM #bcst_new_amounts as a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
	AND (a.REV_NBR = d.REV_NBR OR @revisions = 0)
	AND (a.SEQ_NBR = d.SEQ_NBR OR @revisions = 0)
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
	AND (a.REV_NBR = d.REV_NBR OR @revisions = 0)
	AND (a.SEQ_NBR = d.SEQ_NBR OR @revisions = 0)
LEFT JOIN #ap_payment_flag AS f
	ON a.AP_ID = f.AP_ID	

--SELECT * FROM #media_order_amounts  /* <<<<<<<<<<<<<<<<< DEBUG */						
	
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
--SELECT * FROM #media_order_detail					/* DEBUG */
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
--END OF SHARED CODE WITH advsp_media1_media_current_status1_sum

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
	  [Line Market Code]				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Line Market Description]			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Date Type]					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Order Period]					int NULL, 
	  [Order Month]						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Year]						smallint NULL, 
	  [Insertion Date]					smalldatetime NULL, 
	  [Order End Date]					smalldatetime NULL, 
	  [Date To Bill]					smalldatetime NULL, 
	  [Close Date]						smalldatetime NULL, 
	  [Material Close Date]				smalldatetime NULL, 
	  [Extended Material Close Date]	smalldatetime NULL, 
	  [Extended Space Close Date]		smalldatetime NULL, 
	  [Line Description]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
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
	  [AR Invoice Date]					datetime NULL,										--#32
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
	  [AP Disbursed Amount]				decimal(15,2) NULL, 
	  [AP Bill Amount]					decimal(15,2) NULL, 
	  [AP Line Total]					decimal(15,2) NULL,
	  [AP Spots Quantity]				int NULL,			
	  [AP Invoice Number]				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [AP Invoice Date]					datetime NULL,										--#32
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
	  [Ad Number]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Ad Number Description]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Rate]							decimal(15,2) NULL DEFAULT 0,
	  [Billed Posting Period]           varchar(6),
	  [Placement 1]						varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#39
	  [Placement 2]						varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#39
	  [Projected Impressions]			int NULL,													--#39
	  [Actual Impressions]				int NULL,	  
	  [Location]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  GRP								decimal(18,5) NULL,
	  GROSS_IMPRESSIONS					decimal(18,5) NULL,
	  MEDIA_DEMO_DESCRIPTION			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  BOOKEND							bit NULL,
	  VALUE_ADDED						bit NULL,
	  [Vendor Shipping City]			varchar(25) NULL,											--#43
	  [Headline]						varchar(60) NULL,											--#43
	  [Rating Source]					varchar(40) NULL,			-- #44
	  [Broadcast Worksheet ID]			int NULL,			        -- #47
	  [Broadcast Worksheet Name]		varchar(100) NULL)			-- #47										

--Left join to #media_order detail excludes detail for old bcst where the line is always 0	--#20
--Modified to inner join with the removal of old bcst										--#26
INSERT INTO #media_current_status
SELECT
	  mh.[USER_ID] AS [User Code],
	  mh.[TYPE] AS [Order Type], 
	  mh.ORDER_NBR AS [Order Number], 
	  mh.REV_NBR AS [Revision Number], 
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
      '' AS [Line Market Code],
      '' AS [Line Market Description],
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
	  CASE ma.REC_TYPE
		WHEN 'O' THEN 'ORDER'
		WHEN 'B' THEN 'BILLING'
		WHEN 'A' THEN 'AP'
	  END AS [Record Type],
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
	  ma.AR_INV_DATE AS [AR Invoice Date],													--#32
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
	  ma.AP_INV_DATE AS [AP Invoice Date],													--#32
	  ma.GLXACT_AP AS [AP GL Trans Number],													--#04
	  ma.AP_ID AS [AP_ID],																	--#15
	  ma.AP_PAYMENT_FLAG AS [AP Payment Flag],
	  ma.AP_CHK_NBR AS [AP Check Number],
	  ma.AP_CHK_DATE AS [AP Check Date],
	  ma.AP_PAYMENT_AMT	 AS [AP Payment Amount],											--#28, #31
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
	  NULL,																					--#34 Acct Exec Code
	  NULL,																					--#34 Acct Exec Name
	  NULL,																					--#34 Create Date
	  NULL,																					--#34 Create User
	  CASE WHEN ISNULL(SEND_VCC_WITH_MEDIA_ORDER,0) = 1 THEN 'Virtual CC' ELSE 'Check' END,  --#35 Vendor Payment Method
	  NULL,																					--#36 Job Type
	  NULL,																					--#36 Job Type
	  mh.HOUSE_COMMENT,
	  NULL,
	  NULL,
	  NULL,
	  NULL,
	  NULL,
	  NULL,
	  NULL,
	  NULL,
	  md.PLACEMENT_1 AS [Placement 1],									--#39
	  md.PLACEMENT_2 AS [Placement 2],									--#39
	  md.PROJ_IMPRESSIONS AS [Projected Impressions],					--#39
	  md.ACT_IMPRESSIONS AS [Actual Impressions],						--#40
	  md.[LOCATION],
	  CASE ma.REC_TYPE
		WHEN 'O' THEN md.GRP
		ELSE 0
	  END AS GRP,
	  CASE ma.REC_TYPE
		WHEN 'O' THEN md.GROSS_IMPRESSIONS
		ELSE 0
	  END AS GROSS_IMPRESSIONS,
	  md.MEDIA_DEMO_DESCRIPTION,
	  md.BOOKEND,
	  md.VALUE_ADDED,
	  dbo.VENDOR.SHIP_CITY AS [Vendor Shipping City],					--#43
	  NULL,																--#43	
	  NULL,                                                             --#44
	  NULL,
	  NULL																
FROM #media_order_amounts AS ma
JOIN #media_order_header AS mh 
	ON ma.ORDER_NBR = mh.ORDER_NBR 
JOIN #media_order_detail AS md																--#26
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
	AND mh.VR_CODE2 = vr2.VR_CODE					-- #46
LEFT JOIN dbo.JOB_LOG
	ON md.JOB_NUMBER = dbo.JOB_LOG.JOB_NUMBER
LEFT JOIN dbo.JOB_COMPONENT
	ON md.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER
	AND md.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR  
LEFT JOIN dbo.SALES_CLASS AS SC 
	ON SC.SC_CODE = mh.MEDIA_TYPE	


--SELECT * FROM #media_current_status --ORDER BY [Order Period]						/* DEBUG */

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
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY), A.[Order Flight From] = B.[START_DATE], A.[Order Flight To] = B.[END_DATE]
FROM #media_current_status A
    INNER JOIN NEWSPAPER_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY), A.[Order Flight From] = B.[START_DATE], A.[Order Flight To] = B.[END_DATE]
FROM #media_current_status A
    INNER JOIN MAGAZINE_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY), A.[Order Flight From] = B.[START_DATE], A.[Order Flight To] = B.[END_DATE]
FROM #media_current_status A
    INNER JOIN INTERNET_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY), A.[Order Flight From] = B.[START_DATE], A.[Order Flight To] = B.[END_DATE]
FROM #media_current_status A
    INNER JOIN OUTDOOR_HEADER B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY), A.[Order Flight From] = B.[START_DATE], A.[Order Flight To] = B.[END_DATE]
FROM #media_current_status A
    INNER JOIN TV_HDR B ON
        A.[Order Number] = B.ORDER_NBR
UPDATE A
SET A.[Create Date] = B.CREATE_DATE, A.[Create User] = COALESCE(B.[USER_ID], B.MODIFIED_BY), A.[Order Flight From] = B.[START_DATE], A.[Order Flight To] = B.[END_DATE]
FROM #media_current_status A
    INNER JOIN RADIO_HDR B ON
        A.[Order Number] = B.ORDER_NBR

UPDATE A
SET A.[Job Type] = B.JT_CODE, A.[Job Type Description] = JT.JT_DESC
FROM #media_current_status A
    INNER JOIN JOB_COMPONENT B ON A.[Job Number] = B.JOB_NUMBER AND A.[Job Component Number] = B.JOB_COMPONENT_NBR
	INNER JOIN JOB_TYPE JT ON B.JT_CODE = JT.JT_CODE

--#38
UPDATE A
SET A.[Internet Type Code] = B.INTERNET_TYPE, A.[Internet Type Description] = IT.OD_DESC
FROM #media_current_status A
    INNER JOIN INTERNET_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1--A.[Line Revision Number] = B.REV_NBR
	LEFT JOIN INTERNET_TYPE IT ON B.INTERNET_TYPE = IT.OD_CODE

UPDATE A
SET A.[Line Market Code] = B.MARKET_CODE, A.[Line Market Description] = MARKET.MARKET_DESC
FROM #media_current_status A
    INNER JOIN INTERNET_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR--AND B.ACTIVE_REV = 1   
	--INNER JOIN INTERNET_TYPE IT ON B.INTERNET_TYPE = IT.OD_CODE
    LEFT OUTER JOIN MARKET ON B.MARKET_CODE = MARKET.MARKET_CODE

UPDATE A
SET A.[Out of Home Type Code] = B.OUTDOOR_TYPE, A.[Out of Home Type Description] = OT.OD_DESC
FROM #media_current_status A
    INNER JOIN OUTDOOR_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1
	LEFT JOIN OUTDOOR_TYPE OT ON B.OUTDOOR_TYPE = OT.OD_CODE

UPDATE A
SET A.[Ad Number]= B.AD_NUMBER, A.[Ad Number Description] = an.AD_NBR_DESC, A.[Headline] = B.HEADLINE
FROM #media_current_status A
    INNER JOIN MAGAZINE_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1
	LEFT JOIN dbo.AD_NUMBER AS an ON B.AD_NUMBER = an.AD_NBR

UPDATE A
SET A.[Ad Number]= B.AD_NUMBER, A.[Ad Number Description] = an.AD_NBR_DESC, A.[Headline] = B.HEADLINE
FROM #media_current_status A
    INNER JOIN NEWSPAPER_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1
	LEFT JOIN dbo.AD_NUMBER AS an ON B.AD_NUMBER = an.AD_NBR

UPDATE A
SET A.[Ad Number]= B.AD_NUMBER, A.[Ad Number Description] = an.AD_NBR_DESC, A.[Headline] = B.HEADLINE--, A.[Market Code] = B.MARKET_CODE, A.[Market Description] = C.MARKET_DESC
FROM #media_current_status A
    INNER JOIN INTERNET_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1
	LEFT JOIN dbo.AD_NUMBER AS an ON B.AD_NUMBER = an.AD_NBR
	LEFT JOIN MARKET C ON B.MARKET_CODE = C.MARKET_CODE

UPDATE A
SET A.[Ad Number]= B.AD_NUMBER, A.[Ad Number Description] = an.AD_NBR_DESC, A.[Headline] = B.HEADLINE
FROM #media_current_status A
    INNER JOIN OUTDOOR_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1
	LEFT JOIN dbo.AD_NUMBER AS an ON B.AD_NUMBER = an.AD_NBR

UPDATE A
SET A.[Ad Number]= B.AD_NUMBER, A.[Ad Number Description] = an.AD_NBR_DESC
FROM #media_current_status A
    INNER JOIN RADIO_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1
	LEFT JOIN dbo.AD_NUMBER AS an ON B.AD_NUMBER = an.AD_NBR

UPDATE A
SET A.[Ad Number]= B.AD_NUMBER, A.[Ad Number Description] = an.AD_NBR_DESC
FROM #media_current_status A
    INNER JOIN TV_DETAIL B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.LINE_NBR AND B.ACTIVE_REV = 1
	LEFT JOIN dbo.AD_NUMBER AS an ON B.AD_NUMBER = an.AD_NBR

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

--#44
UPDATE A
SET A.[Rating Source] = B.RATING_SOURCE
FROM #media_current_status A
    INNER JOIN (
		SELECT DISTINCT MBWMDD.ORDER_NBR, MBWMDD.ORDER_LINE_NBR, CASE MBWM.EXTERNAL_RADIO_SOURCE WHEN 0 THEN 'Nielsen' WHEN 1 THEN 'Eastlan' WHEN 2 THEN 'NielsenCounty' ELSE 'N/A' END RATING_SOURCE
		FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID AND MEDIA_TYPE_CODE = 'R'	
	) B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.ORDER_LINE_NBR

--#44
UPDATE A
SET A.[Rating Source] = B.RATING_SOURCE
FROM #media_current_status A
    INNER JOIN (
		SELECT DISTINCT MBWMDD.ORDER_NBR, MBWMDD.ORDER_LINE_NBR, MBRS.NAME RATING_SOURCE
		FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID AND MEDIA_TYPE_CODE = 'T'	
			INNER JOIN dbo.RATINGS_SERVICE MBRS ON MBRS.RATINGS_SERVICE_ID = MBW.RATINGS_SERVICE_ID	
	) B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.ORDER_LINE_NBR

--#47
UPDATE A
SET A.[Broadcast Worksheet ID] = B.MEDIA_BROADCAST_WORKSHEET_ID, A.[Broadcast Worksheet Name] = B.[NAME]
FROM #media_current_status A
    INNER JOIN (
		SELECT DISTINCT MBW.MEDIA_BROADCAST_WORKSHEET_ID, MBW.[NAME], MBWMDD.ORDER_NBR, MBWMDD.ORDER_LINE_NBR
		FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID AND MEDIA_TYPE_CODE = 'R'	
			INNER JOIN dbo.RATINGS_SERVICE MBRS ON MBRS.RATINGS_SERVICE_ID = MBW.RATINGS_SERVICE_ID	
	) B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.ORDER_LINE_NBR

--#47
UPDATE A
SET A.[Broadcast Worksheet ID] = B.MEDIA_BROADCAST_WORKSHEET_ID, A.[Broadcast Worksheet Name] = B.[NAME]
FROM #media_current_status A
    INNER JOIN (
		SELECT DISTINCT MBW.MEDIA_BROADCAST_WORKSHEET_ID, MBW.[NAME], MBWMDD.ORDER_NBR, MBWMDD.ORDER_LINE_NBR
		FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID AND MEDIA_TYPE_CODE = 'T'	
			INNER JOIN dbo.RATINGS_SERVICE MBRS ON MBRS.RATINGS_SERVICE_ID = MBW.RATINGS_SERVICE_ID	
	) B ON A.[Order Number] = B.ORDER_NBR AND A.[Line Number] = B.ORDER_LINE_NBR


--#45
UPDATE A
SET A.[Order Accepted] = CASE WHEN B.[STATUS] = 5 THEN 1 ELSE 0 END
FROM #media_current_status A
    INNER JOIN (
	SELECT A.ORDER_NBR, B.LINE_NBR, [STATUS] FROM NEWSPAPER_ORDER_STATUS A JOIN 
		( SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REC_ID) REC_ID FROM NEWSPAPER_ORDER_STATUS A JOIN 
			( SELECT ORDER_NBR , LINE_NBR , MAX(REVISED_DATE) REVISED_DATE FROM NEWSPAPER_ORDER_STATUS A
				GROUP BY ORDER_NBR, LINE_NBR 
			) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REVISED_DATE = B.REVISED_DATE 
		GROUP BY A.ORDER_NBR, A.LINE_NBR
		) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.REC_ID = A.REC_ID 
	) B ON B.ORDER_NBR = A.[Order Number] AND B.LINE_NBR = A.[Line Number] AND A.[Order Type] = 'NEWS'

UPDATE A
SET A.[Order Accepted] = CASE WHEN B.[STATUS] = 5 THEN 1 ELSE 0 END
FROM #media_current_status A
    INNER JOIN (
	SELECT A.ORDER_NBR, B.LINE_NBR, [STATUS] FROM MAGAZINE_ORDER_STATUS A JOIN 
		( SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REC_ID) REC_ID FROM MAGAZINE_ORDER_STATUS A JOIN 
			( SELECT ORDER_NBR , LINE_NBR , MAX(REVISED_DATE) REVISED_DATE FROM MAGAZINE_ORDER_STATUS A
				GROUP BY ORDER_NBR, LINE_NBR 
			) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REVISED_DATE = B.REVISED_DATE 
		GROUP BY A.ORDER_NBR, A.LINE_NBR
		) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.REC_ID = A.REC_ID 
	) B ON B.ORDER_NBR = A.[Order Number] AND B.LINE_NBR = A.[Line Number] AND A.[Order Type] = 'MAG'

UPDATE A
SET A.[Order Accepted] = CASE WHEN B.[STATUS] = 5 THEN 1 ELSE 0 END
FROM #media_current_status A
    INNER JOIN (
	SELECT A.ORDER_NBR, B.LINE_NBR, [STATUS] FROM INTERNET_ORDER_STATUS A JOIN 
		( SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REC_ID) REC_ID FROM INTERNET_ORDER_STATUS A JOIN 
			( SELECT ORDER_NBR , LINE_NBR , MAX(REVISED_DATE) REVISED_DATE FROM INTERNET_ORDER_STATUS A
				GROUP BY ORDER_NBR, LINE_NBR 
			) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REVISED_DATE = B.REVISED_DATE 
		GROUP BY A.ORDER_NBR, A.LINE_NBR
		) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.REC_ID = A.REC_ID 
	) B ON B.ORDER_NBR = A.[Order Number] AND B.LINE_NBR = A.[Line Number] AND A.[Order Type] = 'INT'

UPDATE A
SET A.[Order Accepted] = CASE WHEN B.[STATUS] = 5 THEN 1 ELSE 0 END
FROM #media_current_status A
    INNER JOIN (
	SELECT A.ORDER_NBR, B.LINE_NBR, [STATUS] FROM OUTDOOR_ORDER_STATUS A JOIN 
		( SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REC_ID) REC_ID FROM OUTDOOR_ORDER_STATUS A JOIN 
			( SELECT ORDER_NBR , LINE_NBR , MAX(REVISED_DATE) REVISED_DATE FROM OUTDOOR_ORDER_STATUS A
				GROUP BY ORDER_NBR, LINE_NBR 
			) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REVISED_DATE = B.REVISED_DATE 
		GROUP BY A.ORDER_NBR, A.LINE_NBR
		) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.REC_ID = A.REC_ID 
	) B ON B.ORDER_NBR = A.[Order Number] AND B.LINE_NBR = A.[Line Number] AND A.[Order Type] = 'OUT'

UPDATE A
SET A.[Order Accepted] = CASE WHEN B.[STATUS] = 5 THEN 1 ELSE 0 END
FROM #media_current_status A
    INNER JOIN (
	SELECT A.ORDER_NBR, B.LINE_NBR, [STATUS] FROM TV_ORDER_STATUS A JOIN 
		( SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REC_ID) REC_ID FROM TV_ORDER_STATUS A JOIN 
			( SELECT ORDER_NBR , LINE_NBR , MAX(REVISED_DATE) REVISED_DATE FROM TV_ORDER_STATUS A
				GROUP BY ORDER_NBR, LINE_NBR 
			) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REVISED_DATE = B.REVISED_DATE 
		GROUP BY A.ORDER_NBR, A.LINE_NBR
		) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.REC_ID = A.REC_ID 
	) B ON B.ORDER_NBR = A.[Order Number] AND B.LINE_NBR = A.[Line Number] AND A.[Order Type] = 'TV'

UPDATE A
SET A.[Order Accepted] = CASE WHEN B.[STATUS] = 5 THEN 1 ELSE 0 END
FROM #media_current_status A
    INNER JOIN (
	SELECT A.ORDER_NBR, B.LINE_NBR, [STATUS] FROM RADIO_ORDER_STATUS A JOIN 
		( SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REC_ID) REC_ID FROM RADIO_ORDER_STATUS A JOIN 
			( SELECT ORDER_NBR , LINE_NBR , MAX(REVISED_DATE) REVISED_DATE FROM RADIO_ORDER_STATUS A
				GROUP BY ORDER_NBR, LINE_NBR 
			) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REVISED_DATE = B.REVISED_DATE 
		GROUP BY A.ORDER_NBR, A.LINE_NBR
		) B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.REC_ID = A.REC_ID 
	) B ON B.ORDER_NBR = A.[Order Number] AND B.LINE_NBR = A.[Line Number] AND A.[Order Type] = 'RADIO'

IF @broadcast_dates = 1 BEGIN	--Update the Month/Year columns based on their broadcast date equivelants	--#41

	--SELECT [Order Number], [Line Number], [Order Year], [Order Month Nbr] FROM #media_current_status		--#41

	UPDATE A
	SET A.[Order Year] = B.BRD_YEAR, 
		A.[Order Period] = CAST(B.BRD_YEAR AS varchar(4)) + RIGHT('00' + CAST(B.BRD_MONTH AS varchar (2)), 2),
		A.[Order Month] = CASE B.BRD_MONTH
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
			END  
	FROM #media_current_status A
		INNER JOIN @brdcast_weeks2 B ON
			A.[Insertion Date] BETWEEN B.BRD_WEEK_START AND B.BRD_WEEK_END

	--SELECT @@ROWCOUNT 'Updated Rows'

	--SELECT [Order Number], [Line Number], [Order Year], [Order Month Nbr] FROM #media_current_status		--#41

END

/* PJH 09/30/2019 - Add CDP Security - BEG */

DECLARE @Restrictions int

SELECT
		@Restrictions = COUNT(*) 
FROM 
	dbo.SEC_CLIENT
WHERE 
	UPPER([USER_ID]) = UPPER(@user_id)
		
CREATE TABLE #Orders(OrderNumber int NOT NULL)
CREATE TABLE #UniqueProducts(CDPCode varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL)

IF @Restrictions > 0 BEGIN /* Only allow valid CDP for current user */

	INSERT INTO #UniqueProducts(CDPCode)
	SELECT
		DISTINCT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE
	FROM
		dbo.SEC_CLIENT
	WHERE 
		UPPER([USER_ID]) = UPPER(@user_id)

	INSERT INTO #Orders
	SELECT DISTINCT [Order Number] FROM #media_current_status A  
	INNER JOIN #UniqueProducts AS B ON B.CDPCode = CAST(A.[Client Code] + '|' + A.[Division Code] + '|' + A.[Product Code] AS varchar(30))

END
ELSE BEGIN /* All Qualify */

	INSERT INTO #Orders
	SELECT DISTINCT [Order Number] FROM #media_current_status
END

/* PJH 09/30/2019 - Add CDP Security - END */

--=============================================================================
--J. FINAL SELECT STATEMENT FOR DATASET	
--=============================================================================
SELECT 		
	[ID] = NEWID(),
	[UserCode] = MCS.[User Code],
	[RecordType] = MCS.[Record Type], 
	[OrderType] = MCS.[Order Type], 
	[OrderNumber] = MCS.[Order Number], 
	[RevisionNumber] = MCS.[Revision Number], 
	[OfficeCode] = MCS.[Office Code], 
	[OfficeName] = MCS.[Office Name], 
	[ClientCode] = MCS.[Client Code], 
	[ClientName] = MCS.[Client Name], 
	[DivisionCode] = MCS.[Division Code], 
	[DivisionName] = MCS.[Division Name], 
	[ProductCode] = MCS.[Product Code], 
	[ProductDescription] = MCS.[Product Description], 
	[OrderDescription] = MCS.[Order Description], 
	[OrderComment] = MCS.[Order Comment], 
	[VendorCode] = MCS.[Vendor Code], 
	[VendorName] = MCS.[Vendor Name], 
	[VendorRepCode] = MCS.[Vendor Rep Code], 
	[VendorRepName] = MCS.[Vendor Rep Name], 
	[VendorRepCode2] = MCS.[Vendor Rep Code2], 
	[VendorRepName2] = MCS.[Vendor Rep Name2], 
	[CampaignCode] = MCS.[Campaign Code], 
	[CampaignID] = MCS.[Campaign ID], 
	[CampaignName] = MCS.[Campaign Name], 
	[MediaType] = MCS.[Media Type], 
	[MediaTypeDescription] = MCS.[Media Type Description], 
	[PostBillFlag] = MCS.[Post Bill Flag], 
	[NetGrossFlag] = MCS.[Net Gross Flag], 
	[MarketCode] = MCS.[Market Code], 
	[MarketDescription] = MCS.[Market Description], 
	[OrderDate] = MCS.[Order Date], 
	[OrderFlightFrom] = MCS.[Order Flight From], 
	[OrderFlightTo] = MCS.[Order Flight To], 
	[OrderProcessControl] = MCS.[Order Process Control], 
	[Buyer] = MCS.[Buyer], 
	[ClientPO] = MCS.[Client PO], 
	[LinkID] = MCS.[Link ID], 
	[OrderAccepted] = MCS.[Order Accepted], 
	[LineNumber] = MCS.[Line Number], 
	[LineRevisionNumber] = MCS.[Line Revision Number], 
	[LineSequenceNumber] = CAST(MCS.[Line Sequence Number] AS smallint), 
    [LineMarketCode] = MCS.[Line Market Code],
    [LineMarketDescription] = MCS.[Line Market Description],
	[OrderDateType] = MCS.[Order Date Type], 
	[OrderPeriod] = MCS.[Order Period], 
	[OrderMonth] = MCS.[Order Month], 
	[OrderYear] = MCS.[Order year], 
	[InsertionDate] = MCS.[Insertion Date], 
	[OrderEndDate] = MCS.[Order End Date], 
	[DateToBill] = MCS.[Date To Bill], 
	[CloseDate] = MCS.[Close Date], 
	[MaterialCloseDate] = MCS.[Material Close Date], 
	[ExtendedMaterialCloseDate] = MCS.[Extended Material Close Date], 
	[ExtendedSpaceCloseDate] = MCS.[Extended Space Close Date],
	[LineDescription] = MCS.[Line Description], 
	[AdSize] = MCS.[Ad Size], 
	[EditionIssue] = MCS.[Edition Issue], 
	[Section] = MCS.[Section], 
	[Material] = MCS.[Material], 
	[Remarks] = MCS.[Remarks], 
	[URL] = MCS.[URL], 
	[CopyArea] = MCS.[Copy Area], 
	[MaterialNotes] = MCS.[Material Notes], 
	[PositionInfo] = MCS.[Position Info], 
	[MiscellaneousInfo] = MCS.[Miscellaneous Info], 
	[JobNumber] = MCS.[Job Number], 
	[JobDescription] = MCS.[Job Description], 
	[JobComponentNumber] = MCS.[Job Component Number], 
	[JobComponentDescription] = MCS.[Job Component Description], 
	[CostType] = MCS.[Cost Type], 
	[RateType] = MCS.[Rate Type], 
	[PrintQuantity] = MCS.[Print Quantity], 
	[GuaranteedImpressions] = MCS.[Guaranteed Impressions], 
	[LineLinkID] = MCS.[Line Link ID], 
	[OrderEntryType] = MCS.[Order Entry Type], 
	[ExtendedNetAmount] = MCS.[Extended Net Amount], 
	[NetChargeAmount] = MCS.[Net Charge Amount], 
	[DiscountAmount] = MCS.[Discount Amount], 
	[AdditionalChargeAmount] = MCS.[Additional Charge Amount], 
	[CommissionAmount] = MCS.[Commission Amount], 
	[RebateAmount] = MCS.[Rebate Amount], 
	[VendorTaxAmount] = MCS.[Vendor Tax Amount], 
	[ResaleTaxAmount] = MCS.[Resale Tax Amount], 
	[LineTotalAmount] = MCS.[Line Total Amount], 
	[NetTotalAmount] = MCS.[Net Total Amount], 
	[VendorNetAmount] = MCS.[Vendor Net Amount], 
	[BillAmount] = MCS.[Bill Amount], 
	[ReconcileNoBillBillAmount] = MCS.[Reconcile No_Bill Bill Amount], 
	[ReconcileNoBillNetAmount] = MCS.[Reconcile No_BILL Net Amount], 
	[SpotsQuantity] = MCS.[Spots Quantity], 
	[NonBillableFlag] = MCS.[Non_billable Flag], 
	[LineCancelled] = MCS.[Line Cancelled], 
	[BillTypeFlag] = MCS.[Bill Type Flag], 
	[BilledExtendedNetAmount] = MCS.[Billed Extended Net Amount], 
	[BilledDiscountAmount] = MCS.[Billed Discount Amount], 
	[BilledNetChargeAmount] = MCS.[Billed Net Charge Amount], 
	[BilledVendorTaxAmount] = MCS.[Billed Vendor Tax Amount], 
	[BilledNetAmount] = MCS.[Billed Net Amount], 
	[BilledAdditionalChargeAmount] = MCS.[Billed Additional Charge Amount], 
	[BilledCommissionAmount] = MCS.[Billed Commission Amount], 
	[BilledRebateAmount] = MCS.[Billed Rebate Amount], 
	[BilledResaleTaxAmount] = MCS.[Billed Resale Tax Amount], 
	[BilledBillAmount] = MCS.[Billed Bill Amount], 
	[BilledSpotsQuantity] = MCS.[Billed Spots Quantity], 
	[InvoiceNumber] = MCS.[Invoice Number],
	[ARInvoiceDate] = MCS.[AR Invoice Date],												--#32 
	[InvoiceSequenceNumber] = MCS.[Invoice Sequence Number], 
	[InvoiceType] = MCS.[Invoice Type], 
	[GLBillingTransNumber] = MCS.[GL Billing Trans Number], 
	[APNetAmount] = MCS.[AP Net Amount], 
	[APNetChargeAmount] = MCS.[AP Net Charge Amount], 
	[APDiscountAmount] = MCS.[AP Discount Amount], 
	[APCommissionAmount] = MCS.[AP Commission Amount], 
	[APRebateAmount] = MCS.[AP Rebate Amount], 
	[APVendorTaxAmount] = MCS.[AP Vendor Tax Amount], 
	[APResaleTaxAmount] = MCS.[AP Resale Tax Amount], 
	[APDisbursedAmount] = MCS.[AP Disbursed Amount],										--#30
	[APBillAmount] = MCS.[AP Bill Amount], 
	[APLineTotal] = MCS.[AP Line Total], 
	[APSpotsQuantity] = MCS.[AP Spots Quantity], 
	[APInvoiceNumber] = MCS.[AP Invoice Number],
	[APInvoiceDate] = MCS.[AP Invoice Date],												--#32 
	[APGLTransNumber] = MCS.[AP GL Trans Number],
	[AP_ID]	= MCS.[AP_ID],																	--#15
	[APPaymentFlag] = CASE WHEN MCS.[AP Payment Flag] = 0 THEN 'No Payment' 
	                       WHEN MCS.[AP Payment Flag] = 1 THEN 'Full Payment' 
						   WHEN MCS.[AP Payment Flag] = 2 THEN 'Partial Payment' 
						   ELSE '' END,													--#15
	[APLastCheckNumber] = MCS.[AP Check Number],											--#15
	[APLastCheckDate] = MCS.[AP Check Date],												--#15
	[APPaymentAmount] = MCS.[AP Payment Amount],											--#15
	[ARPaymentFlag] = CASE WHEN MCS.[AR Payment Flag] = 0 THEN 'No Payment' 
	                       WHEN MCS.[AR Payment Flag] = 1 THEN 'Full Payment' 
						   WHEN MCS.[AR Payment Flag] = 2 THEN 'Partial Payment' 
						   ELSE '' END,															--#16
	[ARLastCheckNumber] = MCS.[AR Check Number],											--#16
	[ARLastCheckDate] = MCS.[AR Check Date],												--#16
	[ARLastDepositDate] = MCS.[AR Deposit Date],											--#17
	[ARPaymentAmount] = MCS.[AR Payment Amount],											--#16
	[FiscalPeriodCode] = MCS.[Fiscal Period Code],											--#18
	[Circulation] = MCS.[Circulation],														--#18
	[RateInfo] = MCS.[Rate Info],															--#18
	[BillCoopCode] = MCS.[Bill Coop Code],													--#19
	[BillCoopDescription] = [Bill Coop Description],
	[AcctExecCode] = MCS.[Acct Exec Code],										--#34	
	[AcctExecName] = MCS.[Acct Exec Name],										--#34
	[CreateDate] = MCS.[Create Date],											--#34
	[CreateUser] = MCS.[Create User],											--#34	
	[VendorPaymentMethod] = MCS.[Vendor Payment Method],						--#35		
	[JobType] = MCS.[Job Type],												--#36
	[JobTypeDescription] = MCS.[Job Type Description],							--#36	
	[HouseComments] = MCS.[House Comments],										--#38	
	[InternetTypeCode] = MCS.[Internet Type Code],								--#38
	[InternetTypeDescription] = MCS.[Internet Type Description],				--#38
	[OutofHomeTypeCode] = MCS.[Out of Home Type Code],							--#38
	[OutofHomeTypeDescription] = MCS.[Out of Home Type Description],			--#38
	[AdNumber] = MCS.[Ad Number],												--#38
	[AdNumberDescription] = MCS.[Ad Number Description],						--#38
	[BilledPostingPeriod] = MCS.[Billed Posting Period],						--#38
	[Rate] = MCS.[Rate],														--#38
	[Placement1] = CASE MCS.[Placement 1]					--#39
		WHEN '' THEN NULL
		ELSE MCS.[Placement 1]
	END,
	[Placement2] = CASE MCS.[Placement 2]					--#39
		WHEN '' THEN NULL
		ELSE MCS.[Placement 2]
	END,
	[ProjectedImpressions] = MCS.[Projected Impressions],	--#39
	[ActualImpressions] = MCS.[Actual Impressions],			--#39		
	[Location] = MCS.[Location],
	[GRP] = MCS.GRP,
	[GrossImpressions] = MCS.GROSS_IMPRESSIONS,
	[PrimaryDemo] = MCS.MEDIA_DEMO_DESCRIPTION,
	[Bookend] = ISNULL(MCS.BOOKEND, 0),
	[AddedValue] = ISNULL(MCS.VALUE_ADDED, 0),
	[VendorShippingCity] = [Vendor Shipping City],			--#43
	[Headline],												--#43
	[RatingSource] = MCS.[Rating Source],                   --#44
    [BroadcastWorksheetID] = MCS.[Broadcast Worksheet ID],        --#47
    [BroadcastWorksheetName] = MCS.[Broadcast Worksheet Name]     --#47					
FROM #media_current_status AS MCS JOIN #Orders ORD ON MCS.[Order Number] = ORD.OrderNumber
	WHERE
				(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND MCS.[Office Code] IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND MCS.[Client Code] IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND MCS.[Client Code] + '|' + MCS.[Division Code] IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND MCS.[Client Code] + '|' + MCS.[Division Code] + '|' + MCS.[Product Code] IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))	
        AND     (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND MCS.[Vendor Code] IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
        AND     (@MarketCodeList IS NULL OR (@MarketCodeList IS NOT NULL AND (MCS.[Market Code] IN (SELECT * FROM dbo.udf_split_list(@MarketCodeList, ',')))))

 ----For testing========================================================================	
--WHERE [Record Type]	= 'ORDER'
--	AND [Line Total Amount] = 0
--	AND [Bill Amount] = 0

--WHERE [Record Type]	= 'BILLING'
--	AND [Billed Bill Amount] = 0
		
--WHERE [Record Type]	= 'AP'
	--AND [AP Line Total] = 0	
	--AND [AP Bill Amount] = 0

--ORDER BY MCS.[Order Number]

END

GO

GRANT EXECUTE ON [advsp_media1_media_current_status1] TO PUBLIC AS dbo
GO