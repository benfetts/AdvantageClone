IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_digital_results_comparison_report]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_digital_results_comparison_report]
GO


CREATE PROCEDURE [dbo].[advsp_digital_results_comparison_report]
	@order_status			varchar(1)		= 'A',						
	@start_date				datetime		= '1/1/1900',
	@end_date				datetime		= '12/31/2100',
	@OfficeCodeList			varchar(max)	= null,
	@ClientCodeList			varchar(max)	= null,
	@ClientDivisionCodeList varchar(max)	= null,
	@ClientDivisionProductCodeList varchar(max) = null,
	@broadcast_dates		bit				= 0,    --#31
	@user_id varchar(100)
AS 
BEGIN


-- Stored procedure to extract DIGITAL MEDIA ORDER DATA information
-- #31 06/28/19 - @broadcast_dates
--=============================================================================

 /* IS USED IN .Net AT THIS POINT - AdvantageFramework\Reporting\Database\Procedures\DigitalResultsComparisonReport.vb */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

/* Used for date calculation */   --#31
DECLARE @cutoff_start_dt smalldatetime
DECLARE @cutoff_end_dt smalldatetime
DECLARE @start_month smallint
DECLARE @start_year smallint
DECLARE @end_month smallint
DECLARE @end_year smallint

SET @start_month = MONTH(@start_date)
SET @start_year = YEAR(@start_date)
SET @end_month = MONTH(@end_date)
SET @end_year = YEAR(@end_date)


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

IF @broadcast_dates = 1 BEGIN			--#31

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

	--SELECT @start_date '@start_date', @end_date '@end_date'  --#31  --DEBUG

	/* Set Start and end dates to their broadcast equivelants */
	SELECT @start_date = MIN(BRD_WEEK_START) FROM @brdcast_weeks2 WHERE BRD_MONTH = @start_month AND BRD_YEAR = @start_year
	SELECT @end_date = MAX(BRD_WEEK_END) FROM @brdcast_weeks2 WHERE BRD_MONTH = @end_month AND BRD_YEAR = @end_year

	--SELECT @start_date '@start_date', @end_date '@end_date'  --#31  --DEBUG

END

--=============================================================================
--A. NEW EXTRACTION SPROCS FOR MEDIA ORDER DETAIL DATA - FILTERS ON ORDER TYPE AND DATE RANGE	--#26
--=============================================================================	
--1. Print detail (dbo.advsp_media1_order_print_detail_active)
CREATE TABLE #internet_detail(
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
	BLACKPLT_VER2					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_DETID						int NULL)
 INSERT INTO #internet_detail
	SELECT 
		'I' AS ORDER_TYPE, 
		NULL,											--h.MEDIA_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR, 
		d.SEQ_NBR,
		d.ACTIVE_REV,
		NULL,											--d.EXT_CLOSE_DATE, 
		d.[START_DATE],
		d.END_DATE, 
		d.DATE_TO_BILL,
		d.CLOSE_DATE, 
		d.MATL_CLOSE_DATE, 
		NULL,											--d.EXT_MATL_DATE,
		NULL,											--d.MAT_COMP,
		d.SIZE,											--d.SIZE AS SIZE_CODE, 
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
		d.PROJ_IMPRESSIONS,								
		d.GUARANTEED_IMPRESS,							--internet only
		d.ACT_IMPRESSIONS,								
		d.URL,											--internet only
		NULL,											--d.TARGET_AUDIENCE,								--internet only
		d.COPY_AREA,									--internet only
		NULL,											--d.CREATIVE_SIZE,								--internet only
		NULL,											--d.PLACEMENT_1,									--internet only
		NULL,											--d.PLACEMENT_2,									--internet only
		NULL,											--d.COST_RATE,									--internet only
		NULL,											--d.NET_BASE_RATE,								--internet only
		NULL,											--d.GROSS_BASE_RATE,								--internet only
		NULL,											--d.INTERNET_TYPE AS SUB_TYPE,					--internet only
		NULL,											--t.OD_DESC AS SUB_TYPE_DESC,	--internet/outdoor
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
		c.INSTRUCTIONS,
		c.ORDER_COPY,									
		NULL AS POSITION_INFO,							--magazine/newspaper 
		NULL AS RATE_INFO,								--magazine/newspaper 
		NULL,											--NULL AS CLOSE_INFO,								--magazine/newspaper 
		c.MISC_INFO, 
		c.MATL_NOTES, 
		NULL AS IN_HOUSE_CMTS,							--magazine/newspaper  
		NULL,											--d.AD_NUMBER,
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
		0,
		ISNULL(d.GUARANTEED_IMPRESS,0),
		NULL,
		NULL,
		d.LINK_DETID  
	FROM dbo.INTERNET_DETAIL AS d 
	JOIN dbo.INTERNET_HEADER AS h
		ON h.ORDER_NBR = d.ORDER_NBR 
	LEFT JOIN dbo.INTERNET_COMMENTS AS c 
		ON d.ORDER_NBR = c.ORDER_NBR 
		AND d.LINE_NBR = c.LINE_NBR
	WHERE d.ACTIVE_REV = 1 AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))		--#01
		AND d.[START_DATE] BETWEEN @start_date AND @end_date	
 --SELECT * FROM #internet_detail 
  
--=============================================================================
--B. CONSOLIDATE DETAIL DATA INTO TEMP TABLE #media_order_dtl
--=============================================================================
CREATE TABLE #media_order_dtl (
	[USER_ID]					varchar(100) NOT NULL,
	ORDER_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
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
	LINE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SIZE_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AD_SIZE						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EDITION_ISSUE				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SECTION						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MATERIAL					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REMARKS						text,
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
	GUARANTEED_IMPRESS			int NULL,							--#13
	PROJECTED_IMPRESS			int NULL,							--#13
	ACTUAL_IMPRESS				int NULL,
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
	[DAYS]						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COPY					text)
		
--1. Print detail
INSERT INTO #media_order_dtl
	([USER_ID], ORDER_TYPE, ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, LINE_DESC, SIZE_CODE, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, PROJECTED_IMPRESS, ACTUAL_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, 
	LINK_ID, SPOTS, PRINT_QUANTITY, CIRCULATION, RATE_INFO, ORDER_COPY)
SELECT
	@user_id,
	d.ORDER_TYPE,
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
	d.SIZE_CODE,
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
	d.PROJ_IMPRESSIONS,				
	d.ACT_IMPRESSIONS,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	d.LINK_DETID,
	0,
	d.PRINT_QUANTITY,
	d.CIRCULATION,
	d.RATE_INFO,
	d.ORDER_COPY
FROM #internet_detail AS d
--SELECT * FROM #media_order_dtl

--=============================================================================
--C. POPULATE dbo.MEDIA_RPT_ORDERS BASED ON #media_order_dtl
--=============================================================================
DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE [USER_ID] = @user_id
INSERT INTO dbo.MEDIA_RPT_ORDERS
SELECT DISTINCT @user_id, d.ORDER_NBR, d.ORDER_TYPE
FROM #media_order_dtl AS d
--SELECT * FROM dbo.MEDIA_RPT_ORDERS WHERE [USER_ID] = @user_id

--=============================================================================
--D. ORIGINAL EXTRACTION SPROCS FOR MEDIA ORDER HEADER DATA
--=============================================================================
--1. Print Header (dbo.advsp_media1_order_print_header)
CREATE TABLE #internet_order_header(
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
INSERT INTO #internet_order_header EXECUTE dbo.advsp_media1_order_print_header @user_id
--SELECT * FROM #internet_order_header	

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
	CLIENT_PO					varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_ID						int NULL,
	ADVAN_TYPE					tinyint NULL,
	ORDER_ACCEPTED				tinyint NULL,
	FISCAL_PERIOD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,			--#18
	BILL_COOP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)			--#19

--1. Print header
INSERT INTO #media_order_header
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED, FISCAL_PERIOD_CODE, BILL_COOP_CODE)
SELECT
	@user_id,
	'INT',
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
	ISNULL(h.ORDER_ACCEPTED,0),
	h.FISCAL_PERIOD_CODE,
	h.BILL_COOP_CODE
FROM #internet_order_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
WHERE
	h.ORDER_TYPE = 'I'	
--SELECT * FROM #media_order_header

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

DELETE FROM #print_amounts WHERE ORDER_TYPE <> 'I'
DELETE FROM #print_amounts_ap WHERE ORDER_TYPE <> 'I'
DELETE FROM #print_amounts_ap_addl WHERE ORDER_TYPE <> 'I'

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
		WHEN h.AP_INV_AMT = p.AP_PMT_AMT THEN 1												
		ELSE 2																				
	END AS AP_PMT_FLAG,
	p.AP_CHK_NBR,																			
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
	CR_CHECK_NBR						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #cash_receipts
SELECT
	d.AR_INV_NBR,
	SUM(ISNULL(d.CR_PAY_AMT,0)),
	SUM(ISNULL(d.CR_ADJ_AMT,0)),
	SUM(ISNULL(d.CR_PAY_AMT,0)) + SUM(ISNULL(d.CR_ADJ_AMT,0)),
	MAX(c.CR_CHECK_DATE),
	MAX(c.CR_DEP_DATE),
	dbo.advfn_ar_max_check_number(d.AR_INV_NBR, MAX(c.CR_CHECK_DATE))
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
	AR_INV_DATE				datetime NULL,
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
	AP_DISBURSED_AMT		decimal(15,2) NULL DEFAULT 0,
	AP_BILL_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_LINE_TOTAL			decimal(15,2) NULL DEFAULT 0,
	AP_SPOTS_QTY			int NULL DEFAULT 0,
	AP_INV_NBR				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE				datetime NULL,
	GLXACT_AP				int NULL,
	AP_ID					int NULL,
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
		ELSE 0
	END,
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NETCHARGE
		ELSE 0
	END,		
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN DISCOUNT_AMT
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN ADDL_CHARGE
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN COMM_AMT
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN REBATE_AMT
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NON_RESALE_AMT
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 AND ACTIVE_REV = 1 THEN CITY_AMT + COUNTY_AMT + STATE_AMT
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN LINE_TOTAL
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1  AND BILL_TYPE_FLAG <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
		ELSE 0
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN BILLING_AMT
		ELSE 0
	END,		
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	PRINT_QUANTITY
FROM #internet_detail

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
	AR_INV_DATE,
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
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
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
	a.AR_INV_DATE,
	a.AR_INV_SEQ,
	a.AR_TYPE,
	a.GLEXACT,
	a.PRINT_QUANTITY,
	p.CR_PAYMENT_FLAG,
	p.CR_CHECK_NBR,
	p.CR_CHECK_DATE,
	p.CR_DEP_DATE,
	CASE p.CR_PAYMENT_FLAG
		WHEN 1 THEN a.BILLING_AMT
		ELSE 0
	END		
FROM #print_amounts AS a
JOIN #internet_detail AS d
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
	AP_DISBURSED_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	AP_INV_DATE,
	GLXACT_AP,
	AP_SPOTS_QTY,
	AP_ID,
	AP_PAYMENT_FLAG,
	AP_CHK_NBR,
	AP_CHK_DATE,
	AP_PAYMENT_AMT)
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
	a.AP_NET_AMT,
	a.AP_NETCHARGES,
	a.AP_DISCOUNT_AMT,
	a.AP_COMM_AMT,
	a.AP_REBATE_AMT,
	a.AP_VENDOR_TAX,
	a.AP_STATE_TAX + a.AP_COUNTY_TAX + a.AP_CITY_TAX,
	a.AP_DISBURSED_AMT,
	a.AP_BILLING_AMT,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_INV_DATE,
	a.AP_GLEXACT,
	a.AP_PRINT_QUANTITY,
	a.AP_ID,
	f.AP_PMT_FLAG,
	f.AP_CHK_NBR,
	f.AP_CHK_DATE,
	CASE f.AP_PMT_FLAG
		WHEN 1 THEN a.AP_DISBURSED_AMT
		ELSE 0
	END		
FROM #print_amounts_ap AS a
JOIN #internet_detail AS d
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
	0
FROM #print_amounts_ap_addl AS a
JOIN #internet_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR

DROP TABLE #internet_order_header
DROP TABLE #internet_detail
DROP TABLE #print_amounts
DROP TABLE #print_amounts_ap
DROP TABLE #print_amounts_ap_addl
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
--LEFT JOIN #media_order_dtl AS dt														--#26 can remove if old bcst is removed
--	ON d.ORDER_NBR = dt.ORDER_NBR
--	AND d.LINE_NBR = dt.LINE_NBR
GROUP BY d.[USER_ID], LEFT(d.ORDER_TYPE,1), d.ORDER_NBR, d.LINE_NBR, d.[MONTH], d.[YEAR],	--#26 dt.INSERT_DATE,	
	d.NON_BILL_FLAG, d.LINE_CANCELLED, d.BILL_TYPE_FLAG
--SELECT * FROM #media_order_amounts_sum ORDER BY ORDER_NBR, LINE_NBR

--=============================================================================
--I. LINK TABLES FOR COMPOSITE DATASET INTO TEMP TABLE #media_cur_status
--SEE ADRPTS MACRO "MedRpts OrderDetail"
--=============================================================================
CREATE TABLE #media_cur_status(     
	  [UserCode]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [OrderType]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [OrderNumber]						int NULL,
	  [RevisionNumber]					smallint NULL, 
	  [OfficeCode]						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [OfficeName]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ClientCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ClientName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionName]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ProductCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ProductDescription]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [OrderDescription]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [OrderComment]					text, 
	  [VendorCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [VendorRepCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [VendorRepName]					varchar(65) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorRepCode2]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorRepName2]					varchar(65) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CampaignCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CampaignID]						smallint NULL, 
	  [CampaignName]					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [MediaType]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [MediaTypeDescription]			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [PostBillFlag]					tinyint NULL, 
	  [NetGrossFlag]					tinyint NULL, 
	  [MarketCode]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [MarketDescription]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [OrderDate]						smalldatetime NULL, 
	  [OrderFlightFrom]					smalldatetime NULL, 
	  [OrderFlightTo]					smalldatetime NULL, 
	  [OrderProcessControl]				tinyint NULL,
	  [Buyer]							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ClientPO]						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [LinkID]							int NULL, 
	  [OrderAccepted]					tinyint NULL, 
	  [LineNumber]						smallint NULL, 
	  [LineRevisionNumber]				smallint NULL,
	  [LineSequenceNumber]				tinyint NULL, 
	  [OrderDateType]					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [OrderPeriod]						int NULL, 
	  [OrderMonth]						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Orderyear]						smallint NULL, 
	  [InsertionDate]					smalldatetime NULL, 
	  [OrderEndDate]					smalldatetime NULL, 
	  [DateToBill]						smalldatetime NULL, 
	  [CloseDate]						smalldatetime NULL, 
	  [MaterialCloseDate]				smalldatetime NULL, 
	  [LineDescription]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [AdSizeCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [AdSize]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [EditionIssue]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Section]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Material]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Remarks]							text, 
	  [URL]								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CopyArea]						text, 
	  [MaterialNotes]					text, 
	  [PositionInfo]					text, 
	  [MiscellaneousInfo]				text, 
	  [JobNumber]						int NULL, 
	  [JobDescription]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [JobComponentNumber]				smallint NULL, 
	  [JobComponentDescription]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [CostType]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [RateType]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [PrintQuantity]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [GuaranteedImpressions]			int NULL, 
	  [ProjectedImpressions]			int NULL, 
	  [ActualImpressions]				int NULL,
	  [LineLinkID]						int NULL, 
	  [OrderEntryType]					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [RecordType]						varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [ExtendedNetAmount]				decimal(15,2) NULL, 
	  [NetChargeAmount]					decimal(15,2) NULL, 
	  [DiscountAmount]					decimal(15,2) NULL, 
	  [AdditionalChargeAmount]			decimal(15,2) NULL, 
	  [CommissionAmount]				decimal(15,2) NULL, 
	  [RebateAmount]					decimal(15,2) NULL, 
	  [VendorTaxAmount]					decimal(15,2) NULL, 
	  [ResaleTaxAmount]					decimal(15,2) NULL, 
	  [LineTotalAmount]					decimal(15,2) NULL, 
	  [NetTotalAmount]					decimal(15,2) NULL, 
	  [VendorNetAmount]					decimal(15,2) NULL,
	  [BillAmount]						decimal(15,2) NULL, 
	  [ReconcileNo_BillBillAmount]		decimal(15,2) NULL, 
	  [ReconcileNo_BILLNetAmount]		decimal(15,2) NULL, 
	  [SpotsQuantity]					int NULL,				
	  [Non_billableFlag]				tinyint NULL, 
	  [LineCancelled]					tinyint NULL, 
	  [BillTypeFlag]					tinyint NULL,
	  [BilledExtendedNetAmount]			decimal(15,2) NULL, 
	  [BilledDiscountAmount]			decimal(15,2) NULL, 
	  [BilledNetChargeAmount]			decimal(15,2) NULL, 
	  [BilledVendorTaxAmount]			decimal(15,2) NULL, 
	  [BilledNetAmount]					decimal(15,2) NULL, 
	  [BilledAdditionalChargeAmount]	decimal(15,2) NULL, 
	  [BilledCommissionAmount]			decimal(15,2) NULL, 
	  [BilledRebateAmount]				decimal(15,2) NULL, 
	  [BilledResaleTaxAmount]			decimal(15,2) NULL, 
	  [BilledBillAmount]				decimal(15,2) NULL,
	  [BilledSpotsQuantity]				int NULL,	
	  [InvoiceNumber]					int NULL, 
	  [InvoiceSequenceNumber]			smallint NULL, 
	  [InvoiceType]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [GLBillingTransNumber]			int NULL,			
	  [APNetAmount]						decimal(15,2) NULL, 
	  [APNetChargeAmount]				decimal(15,2) NULL, 
	  [APDiscountAmount]				decimal(15,2) NULL, 
	  [APCommissionAmount]				decimal(15,2) NULL, 
	  [APRebateAmount]					decimal(15,2) NULL, 
	  [APVendorTaxAmount]				decimal(15,2) NULL, 
	  [APResaleTaxAmount]				decimal(15,2) NULL, 			
	  [APDisbursedAmount]				decimal(15,2) NULL,	
	  [APBillAmount]					decimal(15,2) NULL, 
	  [APLineTotal]						decimal(15,2) NULL,
	  [APSpotsQuantity]					int NULL,			
	  [APInvoiceNumber]					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [APGLTransNumber]					int NULL,
	  [AP_ID]							int NULL,
	  [APPaymentFlag]					tinyint NULL DEFAULT 0,
	  [APCheckNumber]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [APCheckDate]						datetime NULL,
	  [APPaymentAmount]					decimal(15,2) NULL DEFAULT 0,
	  [ARPaymentFlag]					tinyint NULL DEFAULT 0,
	  [ARCheckNumber]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ARCheckDate]						datetime NULL,
	  [ARDepositDate]					datetime NULL,
	  [ARPaymentAmount]					decimal(15,2) NULL DEFAULT 0,
	  [FiscalPeriodCode]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Circulation]						int NULL,
	  [RateInfo]						text,	
	  [BillCoopCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [BuyType]							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Date1]							smalldatetime,
	  [Date2]							smalldatetime,
	  [Date3]							smalldatetime,
	  [Date4]							smalldatetime,
	  [Date5]							smalldatetime,
	  [Date6]							smalldatetime,
	  [Date7]							smalldatetime,
	  [Monday]							smallint NULL,
	  [Tuesday]							smallint NULL,
	  [Wednesday]						smallint NULL,
	  [Thursday]						smallint NULL,
	  [Friday]							smallint NULL,
	  [Saturday]						smallint NULL,
	  [Sunday]							smallint NULL,
	  [Spots1]							int NULL,
	  [Spots2]							int NULL,
	  [Spots3]							int NULL,
	  [Spots4]							int NULL,
	  [Spots5]							int NULL,
	  [Spots6]							int NULL,
	  [Spots7]							int NULL,
	  [AdNumber]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [MaterialCompDate]				smalldatetime,
	  [Programming]						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [StartTime]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [EndTime]							varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Tag]								varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [NetworkID]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Days]							varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [AcctExecCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [AcctExecName]					varchar(62) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [CreateDate]						smalldatetime,	
	  [CreateUser]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	  [OrderCopy]						text)
	  							
INSERT INTO #media_cur_status
SELECT
	  mh.[USER_ID] AS [UserCode],
	  mh.[TYPE] AS [OrderType], 
	  mh.ORDER_NBR AS [OrderNumber], 
	  mh.REV_NBR AS [RevisionNumber], 
	  mh.OFFICE_CODE AS [OfficeCode],
	  dbo.OFFICE.OFFICE_NAME AS [OfficeName],
	  mh.CL_CODE AS [ClientCode], 
	  dbo.CLIENT.CL_NAME AS [ClientName],
	  mh.DIV_CODE AS [DivisionCode],
	  dbo.DIVISION.DIV_NAME AS [DivisionName], 
	  mh.PRD_CODE AS [ProductCode],
	  dbo.PRODUCT.PRD_DESCRIPTION AS [ProductDescription],  
	  mh.ORDER_DESC AS [OrderDescription], 
	  mh.ORDER_COMMENT AS [OrderComment], 
	  mh.VN_CODE AS [VendorCode],
	  dbo.VENDOR.VN_NAME AS [VendorName], 
	  mh.VR_CODE AS [VendorRepCode], 
	  ISNULL(dbo.VEN_REP.VR_FNAME,'') + ' ' + ISNULL(dbo.VEN_REP.VR_LNAME,'') AS [VendorRepName],
	  mh.VR_CODE2 AS [VendorRepCode2],
	  ISNULL(vr2.VR_FNAME,'') + ' ' + ISNULL(vr2.VR_LNAME,'') AS [VendorRepName2], 
	  mh.CMP_CODE AS [CampaignCode], 
	  mh.CMP_IDENTIFIER AS [CampaignID], 
	  mh.CMP_NAME AS [CampaignName], 
	  mh.MEDIA_TYPE AS [MediaType], 
	  SC.SC_DESCRIPTION AS [MediaTypeDescription], 
	  mh.POST_BILL AS [PostBillFlag], 
	  mh.NET_GROSS AS [NetGrossFlag], 
	  mh.MARKET_CODE AS [MarketCode], 
	  mh.MARKET_DESC AS [MarketDescription], 
	  mh.ORDER_DATE AS [OrderDate], 
	  mh.FLIGHT_FROM AS [OrderFlightFrom], 
	  mh.FLIGHT_TO AS [OrderFlightTo],
	  mh.ORD_PROCESS_CONTRL AS [OrderProcessControl], 
	  mh.BUYER AS [Buyer], 
	  mh.CLIENT_PO AS [ClientPO], 
	  mh.LINK_ID AS [LinkID], 
	  mh.ORDER_ACCEPTED AS [OrderAccepted], 
	  CASE mh.ADVAN_TYPE
		WHEN 1 THEN 0
		ELSE md.LINE_NBR
	  END AS [LineNumber], 
	  md.REV_NBR AS [LineRevisionNumber],
	  md.SEQ_NBR AS [LineSequenceNumber], 
	  md.DATE_TYPE AS [OrderDateType],
	  COALESCE(md.[YEAR],ma.[YEAR]) * 100 + COALESCE(md.[MONTH],ma.[MONTH])AS [OrderPeriod], 
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
	  END AS [OrderMonth], 
	  COALESCE(md.[YEAR],ma.[YEAR]) AS [Orderyear], 
	  md.INSERT_DATE [InsertionDate], 
	  md.END_DATE AS [OrderEndDate], 
	  md.DATE_TO_BILL AS [DateToBill], 
	  md.CLOSE_DATE AS [CloseDate], 
	  md.MATL_CLOSE_DATE AS [MaterialCloseDate], 
	  md.LINE_DESC AS [LineDescription], 
	  md.SIZE_CODE AS [AdSizeCode], 
	  md.AD_SIZE AS [AdSize], 
	  md.EDITION_ISSUE AS [EditionIssue], 
	  md.SECTION AS [Section], 
	  md.MATERIAL AS [Material], 
	  md.REMARKS AS [Remarks], 
	  md.URL AS [URL], 
	  md.COPY_AREA AS [CopyArea], 
	  md.MATL_NOTES AS [MaterialNotes], 
	  md.POSITION_INFO AS [PositionInfo], 
	  md.MISC_INFO AS [MiscellaneousInfo], 
	  md.JOB_NUMBER AS [JobNumber], 
	  dbo.JOB_LOG.JOB_DESC AS [JobDescription],
	  md.JOB_COMPONENT_NBR AS [JobComponentNumber], 
	  dbo.JOB_COMPONENT.JOB_COMP_DESC AS [JobComponentDescription],
	  md.COST_TYPE AS [CostType], 
	  md.RATE_TYPE AS [RateType], 
	  md.PRINT_QUANTITY AS [PrintQuantity],												--#13
	  md.GUARANTEED_IMPRESS AS [GuaranteedImpressions],
	  md.PROJECTED_IMPRESS AS [ProjectedImpressions],
	  md.ACTUAL_IMPRESS AS [ActualImpressions],
	  md.LINK_ID AS [LineLinkID], 
	  ma.ORDER_TYPE AS [OrderEntryType],											
	  NULL AS [RecordType],
	  ma.EXT_NET_AMT AS [ExtendedNetAmount], 
	  ma.NETCHARGES AS [NetChargeAmount], 
	  ma.DISCOUNTS AS [DiscountAmount], 
	  ma.ADDL_CHARGE AS [AdditionalChargeAmount], 
	  ma.COMM_AMT AS [CommissionAmount], 
	  ma.REBATE_AMT AS [RebateAmount], 
	  ma.VENDOR_TAX AS [VendorTaxAmount], 
	  ma.RESALE_TAX AS [ResaleTaxAmount], 
	  ma.LINE_TOTAL AS [LineTotalAmount], 
	  ma.NET_TOTAL_AMT AS [NetTotalAmount], 
	  ma.VENDOR_NET_AMT AS [VendorNetAmount],
	  ma.BILL_AMT AS [BillAmount], 
	  ma.RECNB_BILL_AMT AS [ReconcileNo_BillBillAmount], 
	  ma.RECNB_NET_AMT AS [ReconcileNo_BILLNetAmount], 
	  ma.SPOTS_QTY AS [SpotsQuantity],				--#05
	  ma.NON_BILL_FLAG AS [Non_billableFlag], 
	  ma.LINE_CANCELLED AS [LineCancelled], 
	  ma.BILL_TYPE_FLAG AS [BillTypeFlag],
	  ma.BILLED_EXT_NET_AMT AS [BilledExtendedNetAmount], 
	  ma.BILLED_DISC_AMT AS [BilledDiscountAmount], 
	  ma.BILLED_NC_AMT AS [BilledNetChargeAmount], 
	  ma.BILLED_VTAX_AMT AS [BilledVendorTaxAmount], 
	  ma.BILLED_NET_AMT AS [BilledNetAmount], 
	  ma.BILLED_ADDL_CHARGE AS [BilledAdditionalChargeAmount], 
	  ma.BILLED_COMM_AMT AS [BilledCommissionAmount], 
	  ma.BILLED_REBATE_AMT AS [BilledRebateAmount], 
	  ma.BILLED_RTAX_AMT AS [BilledResaleTaxAmount], 
	  ma.BILLED_BILL_AMT AS [BilledBillAmount],
	  ma.BILLED_SPOTS_QTY AS [BilledSpotsQuantity],
	  ma.AR_INV_NBR AS [InvoiceNumber], 
	  ma.AR_SEQ AS [InvoiceSequenceNumber], 
	  ma.AR_TYPE AS [InvoiceType], 
	  ma.GLXACT_BILL AS [GLBillingTransNumber],
	  ma.AP_NET_AMT AS [APNetAmount], 
	  ma.AP_NETCHARGES_AMT AS [APNetChargeAmount], 
	  ma.AP_DISC_AMT_AMT AS [APDiscountAmount], 
	  ma.AP_COMM_AMT AS [APCommissionAmount], 
	  ma.AP_REBATE_AMT AS [APRebateAmount], 
	  ma.AP_VTAX_AMT AS [APVendorTaxAmount], 
	  ma.AP_RTAX_AMT AS [APResaleTaxAmount],
	  ma.AP_DISBURSED_AMT AS [APDisbursedAmount],  
	  ma.AP_BILL_AMT AS [APBillAmount], 
	  ma.AP_LINE_TOTAL AS [APLineTotal],
	  ma.AP_SPOTS_QTY AS [APSpotsQuantity],
	  ma.AP_INV_NBR AS [APInvoiceNumber], 
	  ma.GLXACT_AP AS [APGLTransNumber],
	  ma.AP_ID AS [AP_ID],
	  ma.AP_PAYMENT_FLAG AS [APPaymentFlag],
	  ma.AP_CHK_NBR AS [APCheckNumber],
	  ma.AP_CHK_DATE AS [APCheckDate],
	  ma.AP_PAYMENT_AMT AS [APPaymentAmount],
	  ma.CR_PAYMENT_FLAG AS [ARPaymentFlag],
	  ma.CR_CHECK_NBR AS [ARCheckNumber],
	  ma.CR_CHECK_DATE AS [ARCheckDate],
	  ma.CR_DEP_DATE AS [ARDepositDate],
	  ma.CR_PAYMENT_AMT AS [ARPaymentAmount],
	  mh.FISCAL_PERIOD_CODE,
	  md.CIRCULATION,
	  md.RATE_INFO,
	  mh.BILL_COOP_CODE,
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
	  md.MAT_COMP,
	  md.PROGRAMMING,
	  md.START_TIME,
	  md.END_TIME,
	  md.TAG,
	  md.NETWORK_ID,
	  md.[DAYS],
	  NULL,
	  NULL,
	  NULL,
	  NULL,
	  md.ORDER_COPY
FROM #media_order_amounts_sum AS ma
JOIN #media_order_header AS mh 
	ON ma.ORDER_NBR = mh.ORDER_NBR 
JOIN #media_order_dtl AS md 
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
--WHERE
--	(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND dbo.JOB_LOG.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
--	AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND dbo.CLIENT.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
--	AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND dbo.CLIENT.CL_CODE + '|' + dbo.DIVISION.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
--	AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND dbo.CLIENT.CL_CODE + '|' + dbo.DIVISION.DIV_CODE + '|' + dbo.PRODUCT.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))	

--SELECT * FROM #media_cur_status --ORDER BY [Order Period]

--#34
UPDATE A
SET A.[AcctExecCode] = B.EMP_CODE
FROM #media_cur_status A
    INNER JOIN ACCOUNT_EXECUTIVE B ON
        A.[ClientCode] = B.CL_CODE AND A.[DivisionCode] = B.DIV_CODE AND A.[ProductCode] = B.PRD_CODE
		AND B.DEFAULT_AE = 1 AND COALESCE(B.INACTIVE_FLAG, 0) = 0 
UPDATE A
SET A.[AcctExecName] = COALESCE(B.EMP_FNAME, '*') + ' ' + COALESCE(B.EMP_LNAME, '*')
FROM #media_cur_status A
    INNER JOIN EMPLOYEE B ON
        A.[AcctExecCode] = B.EMP_CODE
UPDATE A
SET A.[CreateDate] = B.CREATE_DATE, A.[CreateUser] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_cur_status A
    INNER JOIN NEWSPAPER_HEADER B ON
        A.[OrderNumber] = B.ORDER_NBR
UPDATE A
SET A.[CreateDate] = B.CREATE_DATE, A.[CreateUser] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_cur_status A
    INNER JOIN MAGAZINE_HEADER B ON
        A.[OrderNumber] = B.ORDER_NBR
UPDATE A
SET A.[CreateDate] = B.CREATE_DATE, A.[CreateUser] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_cur_status A
    INNER JOIN INTERNET_HEADER B ON
        A.[OrderNumber] = B.ORDER_NBR
UPDATE A
SET A.[CreateDate] = B.CREATE_DATE, A.[CreateUser] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_cur_status A
    INNER JOIN OUTDOOR_HEADER B ON
        A.[OrderNumber] = B.ORDER_NBR
UPDATE A
SET A.[CreateDate] = B.CREATE_DATE, A.[CreateUser] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_cur_status A
    INNER JOIN TV_HDR B ON
        A.[OrderNumber] = B.ORDER_NBR
UPDATE A
SET A.[CreateDate] = B.CREATE_DATE, A.[CreateUser] = COALESCE(B.[USER_ID], B.MODIFIED_BY)
FROM #media_cur_status A
    INNER JOIN RADIO_HDR B ON
        A.[OrderNumber] = B.ORDER_NBR

--=============================================================================
--J. FINAL SELECT STATEMENT FOR DATASET	
--=============================================================================
DECLARE @MediaCurrentStatusSummary TABLE(
	  [OrderNumber]						int NULL,
	  [LineNumber]						smallint NULL, 
	  [OfficeCode]						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [OfficeName]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ClientCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ClientName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [DivisionName]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [ProductCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ProductDescription]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CampaignID]						smallint NULL, 
	  [CampaignCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [CampaignName]					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [MediaType]						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [SalesClassCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [SalesClassDescription]			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [OrderDescription]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [OrderComment]					text,  
	  [OrderDate]						smalldatetime NULL,  
	  [ClientPO]						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [LinkID]							int NULL, 
	  [LineLinkID]						int NULL, 
	  [OrderDateType]					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [InsertionDate]					smalldatetime NULL, 
	  [OrderEndDate]					smalldatetime NULL, 
	  [OrderMonth]						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [OrderYear]						smallint NULL, 
	  [JobNumber]						int NULL, 
	  [JobDescription]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [JobComponentNumber]				smallint NULL, 
	  [JobComponentDescription]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [CostType]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [ProjectedImpressions]			int NULL,  
	  [GuaranteedImpressions]			int NULL, 
	  [ActualImpressions]				int NULL,
	  [LineDescription]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [MiscellaneousInfo]				text, 	
	  [OrderCopy]						text, 
	  [MaterialNotes]					text,
	  [Month]							int,
	  [Year]							int,
	  [AdSizeCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [VendorNetAmount]					decimal(15,2) NULL,
	  [CommissionAmount]				decimal(15,2), 
	  [AdditionalChargeAmount]			decimal(15,2),
	  [BillAmount]						decimal(15,2), 
	  [BilledSpotsQuantity]				int, 
	  [BilledCommissionAmount]			decimal(15,2), 
	  [BilledAdditionalChargeAmount]	decimal(15,2), 
	  [BilledNetAmount]					decimal(15,2),
	  [BilledBillAmount]				decimal(15,2),
	  [APSpotsQuantity]					int,
	  [APNetAmount]						decimal(15,2))

INSERT INTO @MediaCurrentStatusSummary 
	([OrderNumber], [LineNumber], [OfficeCode], [OfficeName], [ClientCode], [ClientName], [DivisionCode], 
	 [DivisionName], [ProductCode], [ProductDescription], [CampaignID], [CampaignCode], [CampaignName], 
	 [MediaType], [SalesClassCode], [SalesClassDescription], [VendorCode], [VendorName], [OrderDescription], 
	 [OrderComment], [OrderDate], [ClientPO], [LinkID], [LineLinkID], [OrderDateType], [InsertionDate], 
	 [OrderEndDate], [OrderMonth], [OrderYear], [JobNumber], [JobDescription], [JobComponentNumber], 
	 [JobComponentDescription], [CostType], [ProjectedImpressions], [GuaranteedImpressions], [ActualImpressions], 
	 [LineDescription], [MiscellaneousInfo], [OrderCopy], [MaterialNotes], [Month], [Year], [AdSizeCode],
	 [VendorNetAmount], [CommissionAmount], [AdditionalChargeAmount], [BillAmount], [BilledSpotsQuantity],
	 [BilledCommissionAmount], [BilledAdditionalChargeAmount], [BilledNetAmount], [BilledBillAmount], 
	 [APSpotsQuantity], [APNetAmount])
SELECT
			MCS.[OrderNumber],
			MCS.[LineNumber],
			MCS.OfficeCode,
			MCS.OfficeName,
			MCS.ClientCode,
			MCS.ClientName,
			MCS.DivisionCode,
			MCS.DivisionName,
			MCS.ProductCode,
			MCS.ProductDescription,
			MCS.CampaignID,
			MCS.CampaignCode,
			MCS.CampaignName,
			[MediaType] = CASE WHEN ISNULL(MCS.OrderType, '') <> '' THEN UPPER(SUBSTRING(MCS.OrderType, 1, 1))  ELSE '' END,
			[SalesClassCode] = MCS.MediaType,
			[SalesClassDescription] = MCS.MediaTypeDescription,
			MCS.[VendorCode],
			MCS.[VendorName],
			MCS.[OrderDescription],
			MCS.[OrderComment],
			MCS.[OrderDate],
			MCS.[ClientPO],
			MCS.[LinkID],
			MCS.[LineLinkID],
			MCS.[OrderDateType],
			MCS.[InsertionDate],
			MCS.[OrderEndDate],
			MCS.[OrderMonth],
			[OrderYear] = MCS.[Orderyear],
			MCS.[JobNumber],
			MCS.[JobDescription],
			MCS.[JobComponentNumber],
			MCS.[JobComponentDescription],
			MCS.[CostType],
			MCS.[ProjectedImpressions],
			MCS.[GuaranteedImpressions],
			MCS.[ActualImpressions],
			MCS.[LineDescription],
			MCS.[MiscellaneousInfo],
			MCS.[OrderCopy],
			MCS.[MaterialNotes],
			[Month] = SUBSTRING(CONVERT(VARCHAR(10), ISNULL(MCS.OrderPeriod, 190001)), 5, 10),
  			[Year] = SUBSTRING(CONVERT(VARCHAR(10), ISNULL(MCS.OrderPeriod, 190001)), 1, 4),
			MCS.[AdSizeCode],
			MCS.[VendorNetAmount],
			MCS.[CommissionAmount], 
			MCS.[AdditionalChargeAmount],
			MCS.[BillAmount], 
			MCS.[BilledSpotsQuantity], 
			MCS.[BilledCommissionAmount], 
			MCS.[BilledAdditionalChargeAmount], 
			MCS.[BilledNetAmount],
			MCS.[BilledBillAmount],
			MCS.[APSpotsQuantity],
			MCS.[APNetAmount]	
		FROM
			#media_cur_status AS MCS

DECLARE @MediaPlanComparisonSummary TABLE (
	[OfficeCode]						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OfficeName]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[ClientCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[ClientName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[DivisionCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[DivisionName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[ProductCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[ProductDescription]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[CampaignID]						int, 
	[CampaignCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[CampaignName]						varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[MediaType]							varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[SalesClassCode]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[SalesClassDescription]				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[VendorCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[VendorName]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AdSizeCode]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Month]								int, 
	[Year]								int, 
	[PlanUnits]							decimal(19,2), --PJH 07/02/19 - chg from 10,2
	[PlanImpressions]					decimal(19,2),
	[PlanClicks]						decimal(19,2),
	[PlanDemo1]							decimal(19,2),
	[PlanDemo2]							decimal(19,2),
	[PlanQuantity]						decimal(19,2),
	[PlanNetAmount]						decimal(19,2),
	[PlanCommission]					decimal(19,2),
	[PlanAgencyFee]						decimal(19,2),
	[PlanBillAmount]					decimal(19,2), 
	[OrderQuantity]						int,
	[OrderNetAmount]					decimal(19,2), 
	[OrderCommission]					decimal(19,2), 
	[OrderAgencyFee]					decimal(19,2), 
	[OrderBillAmount]					decimal(19,2), 
	[BilledQuantity]					int,
	[BilledCommissionAmount]			decimal(19,2), 
	[BilledAgencyFee]					decimal(19,2), 
	[BilledNetAmount]					decimal(19,2), 
	[BilledBillAmount]					decimal(19,2), 
	[APQuantity]						int,
	[APNetAmount]						decimal(19,2), 
	[PlanBillToOrderedBillVariance]		decimal(19,2), 
	[PlanBillToBilledVariance]			decimal(19,2), 
	[OrderedToBilledVariance]			decimal(19,2), 
	[OrderedToAPVariance]				decimal(19,2), 
	[PlanCPI]							decimal(19,4),
	[PlanRate]							decimal(19,4),
	[PlanCTR]							decimal(19,4),
	[PlanConversionRatePercent]			decimal(19,4)
)

INSERT INTO @MediaPlanComparisonSummary 
	([OfficeCode], [OfficeName], [ClientCode], [ClientName], [DivisionCode], [DivisionName], [ProductCode], 
	 [ProductDescription], [CampaignID], [CampaignCode], [CampaignName], [MediaType], [SalesClassCode], 
	 [SalesClassDescription], [VendorCode], [VendorName], [AdSizeCode], [Month], [Year], [PlanUnits], 
	 [PlanImpressions], [PlanClicks], [PlanDemo1], [PlanDemo2], [PlanQuantity], [PlanNetAmount], 
	 [PlanCommission], [PlanAgencyFee], [PlanBillAmount], [OrderQuantity], [OrderNetAmount], [OrderCommission], 
	 [OrderAgencyFee], [OrderBillAmount], [BilledQuantity], [BilledCommissionAmount], [BilledAgencyFee], 
	 [BilledNetAmount], [BilledBillAmount], [APQuantity], [APNetAmount], [PlanBillToOrderedBillVariance], [PlanBillToBilledVariance], 
	 [OrderedToBilledVariance], [OrderedToAPVariance], [PlanRate], [PlanCPI], [PlanCTR], [PlanConversionRatePercent])
SELECT
	[OfficeCode],
	[OfficeName],
	[ClientCode],
	[ClientName],
	[DivisionCode],
	[DivisionName],
	[ProductCode],
	[ProductDescription],
	[CampaignID],
	[CampaignCode],
	[CampaignName],
	[MediaType],
	[SalesClassCode],
	[SalesClassDescription],
	[VendorCode],
	[VendorName],
	[AdSizeCode],
	[Month],
	[Year],
	[PlanUnits] = SUM(ISNULL(MPCS.PlanUnits, 0)),
 	[PlanImpressions] = SUM(ISNULL(MPCS.PlanImpressions, 0)),
 	[PlanClicks] = SUM(ISNULL(MPCS.PlanClicks, 0)),
 	[PlanDemo1] = SUM(ISNULL(MPCS.PlanDemo1, 0)),
 	[PlanDemo2] = SUM(ISNULL(MPCS.PlanDemo2, 0)),
 	[PlanQuantity] = SUM(ISNULL(MPCS.PlanQuantity, 0)),
 	[PlanNetAmount] = SUM(ISNULL(MPCS.PlanNetAmount, 0)),
 	[PlanCommission] = SUM(ISNULL(MPCS.PlanCommission, 0)),
 	[PlanAgencyFee] = SUM(ISNULL(MPCS.PlanAgencyFee, 0)),
 	[PlanBillAmount] = SUM(ISNULL(MPCS.PlanBillAmount, 0)),
 	[OrderQuantity] = SUM(ISNULL(MPCS.OrderQuantity, 0)),
 	[OrderNetAmount] = SUM(ISNULL(MPCS.OrderNetAmount, 0)),
 	[OrderCommission] = SUM(ISNULL(MPCS.OrderCommission, 0)),
 	[OrderAgencyFee] = SUM(ISNULL(MPCS.OrderAgencyFee, 0)),
 	[OrderBillAmount] = SUM(ISNULL(MPCS.OrderBillAmount, 0)),
 	[BilledQuantity] = SUM(ISNULL(MPCS.BilledQuantity, 0)),
 	[BilledCommissionAmount] = SUM(ISNULL(MPCS.BilledCommissionAmount, 0)),
 	[BilledAgencyFee] = SUM(ISNULL(MPCS.BilledAgencyFee, 0)),
 	[BilledNetAmount] = SUM(ISNULL(MPCS.BilledNetAmount, 0)),
 	[BilledBillAmount] = SUM(ISNULL(MPCS.BilledBillAmount, 0)),
 	[APQuantity] = SUM(ISNULL(MPCS.APQuantity, 0)),
 	[APNetAmount] = SUM(ISNULL(MPCS.APNetAmount, 0)),
 	[PlanBillToOrderedBillVariance] = SUM(ISNULL(MPCS.OrderBillAmount, 0)) - SUM(ISNULL(MPCS.PlanBillAmount, 0)),
 	[PlanBillToBilledVariance] = SUM(ISNULL(MPCS.BilledBillAmount, 0)) - SUM(ISNULL(MPCS.PlanBillAmount, 0)),
 	[OrderedToBilledVariance] = SUM(ISNULL(MPCS.BilledBillAmount, 0)) - SUM(ISNULL(MPCS.OrderBillAmount, 0)),
 	[OrderedToAPVariance] = SUM(ISNULL(MPCS.APNetAmount, 0)) - SUM(ISNULL(MPCS.OrderNetAmount, 0)),
	[PlanRate] = CASE WHEN COUNT(CASE WHEN MPCS.PlanRate IS NOT NULL THEN 1 END) > 0 THEN SUM(ISNULL(MPCS.PlanRate, 0)) / COUNT(CASE WHEN MPCS.PlanRate IS NOT NULL THEN 1 END) ELSE 0 END,
	[PlanCPI] = CASE WHEN COUNT(CASE WHEN MPCS.PlanCPI IS NOT NULL THEN 1 END) > 0 THEN SUM(MPCS.PlanCPI) / COUNT(CASE WHEN MPCS.PlanCPI IS NOT NULL THEN 1 END) ELSE NULL END,
	[PlanCTR] = CASE WHEN SUM(MPCS.PlanImpressions) <> 0 THEN SUM(MPCS.PlanClicks) / SUM(MPCS.PlanImpressions) ELSE 0 END,
	[PlanConversionRatePercent] = CASE WHEN SUM(MPCS.PlanClicks) <> 0 THEN SUM(MPCS.PlanUnits) / SUM(MPCS.PlanClicks) ELSE 0 END
FROM
 	(SELECT 		
  		[OfficeCode] = MCS.OfficeCode,
  		[OfficeName] = MCS.OfficeName,
  		[ClientCode] = MCS.ClientCode,
  		[ClientName] = MCS.ClientName,
  		[DivisionCode] = MCS.DivisionCode,
  		[DivisionName] = MCS.DivisionName,
  		[ProductCode] = MCS.ProductCode,
  		[ProductDescription] = MCS.ProductDescription,
  		[CampaignID] = MCS.CampaignID,
  		[CampaignCode] = MCS.CampaignCode,
  		[CampaignName] = MCS.CampaignName,
  		[MediaType] = MCS.MediaType,
  		[SalesClassCode] = MCS.SalesClassCode,
  		[SalesClassDescription] = MCS.SalesClassDescription,
  		[VendorCode] = MCS.VendorCode,
  		[VendorName] = MCS.VendorName,
  		[AdSizeCode] = MCS.AdSizeCode,
  		[Month] = MCS.[Month],
  		[Year] = MCS.[Year],
  		[PlanUnits] = NULL,
  		[PlanImpressions] = NULL,
  		[PlanClicks] = NULL,
  		[PlanDemo1] = NULL,
  		[PlanDemo2] = NULL,
  		[PlanQuantity] = NULL,
  		[PlanNetAmount] = NULL,
  		[PlanCommission] = NULL,
  		[PlanAgencyFee] = NULL,
  		[PlanBillAmount] = NULL,
  		[OrderQuantity] = ISNULL(MCS.GuaranteedImpressions, 0),
  		[OrderNetAmount] = MCS.VendorNetAmount,
  		[OrderCommission] = MCS.CommissionAmount,
  		[OrderAgencyFee] = MCS.AdditionalChargeAmount,
  		[OrderBillAmount] = MCS.BillAmount,
  		[BilledQuantity] = MCS.BilledSpotsQuantity,
 		[BilledCommissionAmount] = MCS.BilledCommissionAmount,
 		[BilledAgencyFee] = MCS.BilledAdditionalChargeAmount,
 		[BilledNetAmount] = MCS.BilledNetAmount,
 		[BilledBillAmount] = MCS.BilledBillAmount,
 		[APQuantity] = MCS.APSpotsQuantity,
 		[APNetAmount] = MCS.APNetAmount,
 		[PlanBillToOrderedBillVariance] = NULL,
 		[PlanBillToBilledVariance] = NULL,
 		[OrderedToBilledVariance] = NULL,
 		[OrderedToAPVariance] = NULL,
		[PlanCPI] = NULL,
		[PlanRate] = NULL										
 	FROM @MediaCurrentStatusSummary AS MCS
 	UNION ALL
 	SELECT
		[OfficeCode] = P.OFFICE_CODE,
  		[OfficeName] = O.OFFICE_NAME,
  		[ClientCode] = MP.CL_CODE,
  		[ClientName] = C.CL_NAME,
  		[DivisionCode] = MP.DIV_CODE,
  		[DivisionName] = D.DIV_NAME,
  		[ProductCode] = MP.PRD_CODE,
  		[ProductDescription] = P.PRD_DESCRIPTION,
		[CampaignID] = CM.CMP_IDENTIFIER,
  		[CampaignCode] = CM.CMP_CODE,
  		[CampaignName] = CM.CMP_NAME,
  		[MediaType] = MPD.SC_TYPE,
  		[SalesClassCode] = MPD.SC_CODE,
  		[SalesClassDescription] = S.SC_DESCRIPTION,
  		[VendorCode] = V.VN_CODE,
  		[VendorName] = V.VN_NAME,
		[AdSizeCode] = MPAD.AdSizeCode,
  		[Month] = CASE WHEN MPD.IS_CALENDAR_MONTH = 1 THEN MC.[MONTH] ELSE MC.BROADCAST_MONTH END,
  		[Year] = CASE WHEN MPD.IS_CALENDAR_MONTH = 1 THEN MC.[YEAR] ELSE MC.BROADCAST_YEAR END,
  		[PlanUnits] = MPDLLD.UNITS,
  		[PlanImpressions] = MPDLLD.IMPRESSIONS,
  		[PlanClicks] = MPDLLD.CLICKS,
  		[PlanDemo1] = MPDLLD.DEMO1,
  		[PlanDemo2] = MPDLLD.DEMO2,
  		[PlanQuantity] = CAST(COALESCE(MPDLLD.UNITS, 0) + COALESCE(MPDLLD.IMPRESSIONS, 0) + COALESCE(MPDLLD.CLICKS, 0) AS DECIMAL(10,2)),
  		[PlanNetAmount] = CAST(CASE WHEN MPD.IS_ESTIMATE_GROSS = 1 THEN (MPDLLD.DOLLARS * .85) ELSE MPDLLD.DOLLARS END AS DECIMAL(10,2)),
  		[PlanCommission] = CAST(CASE WHEN MPD.IS_ESTIMATE_GROSS = 0 THEN MPDLLD.BILL_AMOUNT - MPDLLD.DOLLARS
									WHEN MPD.IS_ESTIMATE_GROSS = 1 AND MPDS.NUMERIC_VALUE IS NOT NULL AND MPDS.NUMERIC_VALUE <> 0 THEN (MPDLLD.DOLLARS * .15) - (MPDLLD.DOLLARS * MPDS.NUMERIC_VALUE / 100) 
									WHEN MPD.IS_ESTIMATE_GROSS = 1 THEN (MPDLLD.DOLLARS * .15) END AS DECIMAL(10,2)),
  		[PlanAgencyFee] = MPDLLD.AGENCY_FEE,
  		[PlanBillAmount] = MPDLLD.BILL_AMOUNT,
  		[OrderQuantity] = NULL,
  		[OrderNetAmount] = NULL,
  		[OrderCommission] = NULL,
  		[OrderAgencyFee] = NULL,
  		[OrderBillAmount] = NULL,
  		[BilledQuantity] = NULL,
  		[BilledCommissionAmount] = NULL,
  		[BilledAgencyFee] = NULL,
  		[BilledNetAmount] = NULL,
  		[BilledBillAmount] = NULL,
  		[APQuantity] = NULL,
  		[APNetAmount] = NULL,
  		[PlanBillToOrderedBillVariance] = NULL,
  		[PlanBillToBilledVariance] = NULL,
  		[OrderedToBilledVariance] = NULL,
  		[OrderedToAPVariance] = NULL,
		[PlanCPI] = CASE WHEN ISNULL(MPDLLD.IMPRESSIONS, 0) <> 0 THEN (CASE WHEN MPD.IS_ESTIMATE_GROSS = 1 THEN .85 ELSE 1 END * ISNULL(MPDLLD.DOLLARS, 0)) / CASE WHEN MPDS2.BOOLEAN_VALUE = 1 THEN (ISNULL(MPDLLD.IMPRESSIONS, 0) / 1000) ELSE ISNULL(MPDLLD.IMPRESSIONS, 0) END ELSE NULL END,
		[PlanRate] = MPDLLD.RATE
	FROM
		dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA MPDLLD INNER JOIN
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
										MPDLLD.ROW_INDEX = MPVN.RowIndex INNER JOIN
		(SELECT 
 			[MediaPlanID] = MPDL.MEDIA_PLAN_ID,
 			[EstimateID] = MPDL.MEDIA_PLAN_DTL_ID,
 			[VendorColumnName] = MPDL.[DESCRIPTION], 
 			[RowIndex] = MPDLL.ROW_INDEX,
 			[AdSizeColumnValue] = MPDLL.[DESCRIPTION], 
 			[AdSizeCode] = MPDLLT.SIZE_CODE 
		 FROM
 			dbo.MEDIA_PLAN_DTL_LEVEL MPDL INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_ID = MPDL.MEDIA_PLAN_DTL_LEVEL_ID INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG MPDLLT ON MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID
		 WHERE
 			MPDL.TAG_TYPE = 3) MPAD ON MPDLLD.MEDIA_PLAN_ID = MPAD.MediaPlanID AND
										MPDLLD.MEDIA_PLAN_DTL_ID = MPAD.EstimateID AND
										MPDLLD.ROW_INDEX = MPAD.RowIndex INNER JOIN
		dbo.MEDIA_PLAN MP ON MPDLLD.MEDIA_PLAN_ID = MP.MEDIA_PLAN_ID INNER JOIN
		dbo.MEDIA_PLAN_DTL MPD ON MPDLLD.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND
									MPDLLD.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID INNER JOIN
		dbo.CLIENT C ON MP.CL_CODE = C.CL_CODE LEFT OUTER JOIN
		dbo.DIVISION D ON MP.CL_CODE = D.CL_CODE AND
							MP.DIV_CODE = D.DIV_CODE LEFT OUTER JOIN
		dbo.PRODUCT P ON MP.CL_CODE = P.CL_CODE AND
							MP.DIV_CODE = P.DIV_CODE AND
							MP.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
		dbo.OFFICE O ON P.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN
		dbo.VENDOR V ON MPVN.VendorCode = V.VN_CODE LEFT OUTER JOIN
		dbo.CAMPAIGN CM ON MPD.CMP_IDENTIFIER = CM.CMP_IDENTIFIER LEFT OUTER JOIN
		dbo.SALES_CLASS S ON MPD.SC_CODE = S.SC_CODE AND
								MPD.SC_TYPE = S.SC_TYPE INNER JOIN
		[dbo].[MEDIA_CALENDAR] MC ON MC.[DATE] = MPDLLD.[START_DATE]  LEFT OUTER JOIN
		[dbo].[MEDIA_PLAN_DTL_SETTING] MPDS ON MP.MEDIA_PLAN_ID = MPDS.MEDIA_PLAN_ID AND MPD.MEDIA_PLAN_DTL_ID = MPDS.MEDIA_PLAN_DTL_ID AND MPDS.SETTING = 'ProductRebateAmount' LEFT OUTER JOIN
		[dbo].[MEDIA_PLAN_DTL_SETTING] MPDS2 ON MP.MEDIA_PLAN_ID = MPDS2.MEDIA_PLAN_ID AND MPD.MEDIA_PLAN_DTL_ID = MPDS2.MEDIA_PLAN_DTL_ID AND MPDS2.SETTING = 'IsImpressionsCPM'
	WHERE
		MPD.APPROVED = 1 AND
		NOT (MP.[START_DATE] > @end_date OR
			 MP.[END_DATE] < @start_date) AND
		MPD.SC_TYPE = 'I') MPCS
GROUP BY
 	[OfficeCode],
  	[OfficeName],
  	[ClientCode],
  	[ClientName],
  	[DivisionCode],
  	[DivisionName],
  	[ProductCode],
  	[ProductDescription],
  	[CampaignID],
  	[CampaignCode],
  	[CampaignName],
  	[MediaType],
  	[SalesClassCode],
  	[SalesClassDescription],
  	[VendorCode],
  	[VendorName],
  	[AdSizeCode],
  	[Month],
  	[Year]

IF @broadcast_dates = 1 BEGIN	--Update the Month/Year columns based on their broadcast date equivelants		--#31

	--SELECT [OrderNumber], [LineNumber], [OrderYear], [OrderMonth], [Year], [Month] FROM @MediaCurrentStatusSummary  --#31

	UPDATE A
	SET A.[Year] = B.BRD_YEAR, 
		A.[Month] = B.BRD_MONTH,
		A.[OrderYear] = B.BRD_YEAR, 
		A.[OrderMonth] = CASE B.BRD_MONTH
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
	FROM @MediaCurrentStatusSummary A  --@MediaCurrentStatusSummary
		INNER JOIN @brdcast_weeks2 B ON
			A.[InsertionDate] BETWEEN B.BRD_WEEK_START AND B.BRD_WEEK_END
			AND (A.[Year] <> B.BRD_YEAR OR A.[Month] <> B.BRD_MONTH)

	--SELECT @@ROWCOUNT 'Updated Dates'  --#31 DEBUG

	--SELECT [OrderNumber], [LineNumber], [OrderYear], [OrderMonth], [Year], [Month] FROM @MediaCurrentStatusSummary  --#31

END

SELECT
	[ID] = NEWID(),
	[MediaPlanID] = DR.MEDIA_PLAN_ID,
	[MediaPlanDescription] = MP.[DESCRIPTION],
	[ClientCode] = DR.CL_CODE,
	[ClientName] = CASE WHEN DR.CL_CODE IS NULL THEN DR.CL_NAME ELSE CL.CL_NAME END,
	[DivisonCode] = DR.DIV_CODE,
	[DivisionName] = DIV.DIV_NAME,
	[ProductCode] = DR.PRD_CODE,
	[ProductName] = PRD.PRD_DESCRIPTION,
	--[JobNumber] = DR.JOB_NUMBER,
	--[JobDescription] = CASE WHEN DR.JOB_NUMBER IS NULL THEN DR.JOB_DESC ELSE JOB.JOB_DESC END,
	--[JobComponentNumber] = DR.JOB_COMPONENT_NBR,
	--[JobComponentDescription] = CASE WHEN DR.JOB_COMPONENT_NBR IS NULL THEN DR.JOB_COMP_DESC ELSE COMP.JOB_COMP_DESC END,
	[EstimateID] = DR.MEDIA_PLAN_DTL_ID,
	[EstimateDescription] = MPD.NAME,
	[MediaType] = DR.MEDIA_TYPE,
	[SalesClassCode] = DR.SC_CODE,
	[SalesClassDescription] = SC.SC_DESCRIPTION,
	[CampaignID] = DR.CMP_IDENTIFIER,
	[CampaignCode] = CASE WHEN DR.CMP_IDENTIFIER IS NULL THEN DR.CMP_CODE ELSE CMP.CMP_CODE END,
	[CampaignName] =  CASE WHEN DR.CMP_IDENTIFIER IS NULL THEN DR.CMP_NAME ELSE CMP.CMP_NAME END,
	[VendorCode] = DR.VN_CODE,
	[VendorName] = CASE WHEN DR.VN_CODE IS NULL THEN DR.VN_NAME ELSE VN.VN_NAME END,
	[MarketCode] = DR.MARKET_CODE,
	[MarketDescription] = CASE WHEN DR.MARKET_CODE IS NULL THEN DR.MARKET_DESC ELSE MARKET.MARKET_DESC END,
	[AdSizeCode] = DR.AD_SIZE_CODE,
	[AdSizeDescription] = CASE WHEN DR.AD_SIZE_CODE IS NULL THEN DR.AD_SIZE_DESC ELSE AD_SIZE.SIZE_DESC END,
	[AdNumber] = DR.AD_NBR,
	[AdNumberDescription] = CASE WHEN DR.AD_NBR IS NULL THEN DR.AD_NBR_DESC ELSE AD_NUMBER.AD_NBR_DESC END,
	[InternetTypeCode] = DR.INTERNET_TYPE_CODE,
	[InternetTypeDescription] = CASE WHEN DR.INTERNET_TYPE_CODE IS NULL THEN DR.OD_DESC ELSE IT.OD_DESC END,
	[Placement] = DR.PLACEMENT,
	[PlacementPixelSize] = DR.PLACEMENT_PX_SIZE,
	[PlacementPixelURL] = DR.PLACEMENT_URL,
	[Creative] = DR.CREATIVE,
	[Tactic] = DR.TACTIC,
	[PagePositioning] = DR.PAGE_POSITIONING,
	[StartDate] = DR.RESULT_DATE,
	[EndDate] = DR.END_DATE,
	[NetGrossRate] = CASE WHEN ISNULL(DR.NET_GROSS_RATE, 0) = 0 THEN 'Net' WHEN DR.NET_GROSS_RATE = 1 THEN 'Gross' END,
	[Units] = DR.UNITS,
	[Impressions] = DR.IMPRESSIONS,
	[Clicks] = DR.CLICKS,
	[ClickRate] = DR.CLICK_RATE,
	[TotalConversions] = DR.TOTAL_CONVERSIONS,
	[Rate] = DR.RATE,
	[NetDollars] = DR.NET_DOLLARS,
	[GrossDollars] = DR.GROSS_DOLLARS,
	[TargetAudience] = DR.TARGET_AUDIENCE,
	[ImpressionsViewable] = DR.IMPRESSIONS_VIEWABLE,
	[ImpressionsMeasurable] = DR.IMPRESSIONS_MEASUREABLE,
	[TotalConversionsB] = DR.TOTAL_CONVERSIONS_B,
	[TotalConversionsC] = DR.TOTAL_CONVERSIONS_C,
	[ConversionRate] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(DR.CLICKS, 0) <> 0 THEN ISNULL(DR.TOTAL_CONVERSIONS, 0) / ISNULL(DR.CLICKS, 0) * 100 END),
	[ConversionRateB] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(DR.CLICKS, 0) <> 0 THEN ISNULL(DR.TOTAL_CONVERSIONS_B, 0) / ISNULL(DR.CLICKS, 0) * 100 END),
	[ConversionRateC] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(DR.CLICKS, 0) <> 0 THEN ISNULL(DR.TOTAL_CONVERSIONS_C, 0) / ISNULL(DR.CLICKS, 0) * 100 END),
	[OfficeCode] = MPCS.[OfficeCode],
	[OfficeName] = MPCS.[OfficeName],
	[Month] = MPCS.[Month],
	[Year] = MPCS.[Year],
	[PlanUnits] = MPCS.PlanUnits,
	[PlanImpressions] = MPCS.PlanImpressions,
	[PlanClicks] = MPCS.PlanClicks,
	[PlanDemo1] = MPCS.PlanDemo1,
	[PlanDemo2] = MPCS.PlanDemo2,
	[PlanQuantity] = MPCS.PlanQuantity,
	[PlanNetAmount] = MPCS.PlanNetAmount,
	[PlanCommission] = MPCS.PlanCommission,
	[PlanAgencyFee] = MPCS.PlanAgencyFee,
	[PlanBillAmount] = MPCS.PlanBillAmount,
	[PlanRate] = OMPV.Rate, -- MPCS.PlanRate,
	[PlanCPI] = CASE WHEN ISNULL(MPCS.PlanImpressions, 0) <> 0 THEN MPCS.PlanNetAmount / MPCS.PlanImpressions ELSE NULL END, -- OMPV.CPI, -- MPCS.PlanCPI,
	[PlanCTR] = CASE WHEN ISNULL(MPCS.PlanImpressions, 0) <> 0 THEN (MPCS.PlanClicks / MPCS.PlanImpressions) * 100 ELSE NULL END, -- MPCS.PlanCTR,
	[PlanConversionRatePercent] = CASE WHEN ISNULL(MPCS.PlanClicks, 0) <> 0 THEN (MPCS.PlanUnits / MPCS.PlanClicks) * 100 ELSE NULL END, -- MPCS.PlanConversionRatePercent,
	[OrderQuantity] = MPCS.OrderQuantity,
	[OrderNetAmount] = MPCS.OrderNetAmount,
	[OrderCommission] = MPCS.OrderCommission,
	[OrderAgencyFee] = MPCS.OrderAgencyFee,
	[OrderBillAmount] = MPCS.OrderBillAmount,
	[BilledQuantity] = MPCS.BilledQuantity,
	[BilledCommissionAmount] = MPCS.BilledCommissionAmount,
	[BilledAgencyFee] = MPCS.BilledAgencyFee,
	[BilledNetAmount] = MPCS.BilledNetAmount,
	[BilledBillAmount] = MPCS.BilledBillAmount,
	[APQuantity] = MPCS.APQuantity,
	[APNetAmount] = MPCS.APNetAmount,
	[PlanBillToOrderedBillVariance] = MPCS.PlanBillToOrderedBillVariance,
	[PlanBillToBilledVariance] = MPCS.PlanBillToBilledVariance,
	[OrderedToBilledVariance] = MPCS.OrderedToBilledVariance,
	[OrderedToAPVariance] = MPCS.OrderedToAPVariance,
	[OrderNumber] = OMPV.[OrderNumber],
	[LineNumber] = OMPV.[LineNumber],
	--MPFS.[VendorCode],
	--MPFS.[VendorName],
	[OrderDescription] = OMPV.[OrderDescription],
	[OrderComment] = OMPV.[OrderComment],
	[OrderDate] = OMPV.[OrderDate],
	[ClientPO] = OMPV.[ClientPO],
	[LinkID] = OMPV.[LinkID],
	[LineLinkID] = OMPV.[LineLinkID],
	[OrderDateType] = OMPV.[OrderDateType],
	[InsertionDate] = OMPV.[InsertionDate],
	[OrderEndDate] = OMPV.[OrderEndDate],
	[OrderMonth] = OMPV.[OrderMonth],
	[OrderYear] = OMPV.[OrderYear],
	[JobNumber] = OMPV.[JobNumber],
	[JobDescription] = OMPV.[JobDescription],
	[JobComponentNumber] = OMPV.[JobComponentNumber],
	[JobComponentDescription] = OMPV.[JobComponentDescription],
	[CostType] = OMPV.[CostType],
	[ProjectedImpressions] = OMPV.[ProjectedImpressions],
	[GuaranteedImpressions] = OMPV.[GuaranteedImpressions],
	[ActualImpressions] = OMPV.[ActualImpressions],
	[LineDescription] = OMPV.[LineDescription],
	[MiscellaneousInfo] = OMPV.[MiscellaneousInfo],
	[OrderCopy] = OMPV.[OrderCopy],
	[MaterialNotes] = OMPV.[MaterialNotes],
	[DaypartCode] = DR.[DAY_PART_CODE]
FROM
	dbo.DIGITAL_RESULTS DR LEFT OUTER JOIN
	dbo.MEDIA_PLAN MP ON DR.MEDIA_PLAN_ID = MP.MEDIA_PLAN_ID LEFT OUTER JOIN
	dbo.MEDIA_PLAN_DTL MPD ON DR.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND
							  DR.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID LEFT OUTER JOIN
	dbo.CLIENT CL ON DR.CL_CODE = CL.CL_CODE LEFT OUTER JOIN
	dbo.DIVISION DIV ON DR.CL_CODE = DIV.CL_CODE AND
						DR.DIV_CODE = DIV.DIV_CODE LEFT OUTER JOIN
	dbo.PRODUCT PRD ON DR.CL_CODE = PRD.CL_CODE AND
					   DR.DIV_CODE = PRD.DIV_CODE AND
					   DR.PRD_CODE = PRD.PRD_CODE LEFT OUTER JOIN
	dbo.JOB_LOG JOB ON DR.JOB_NUMBER = JOB.JOB_NUMBER LEFT OUTER JOIN
	dbo.JOB_COMPONENT COMP ON DR.JOB_NUMBER = COMP.JOB_NUMBER AND
							  DR.JOB_COMPONENT_NBR = COMP.JOB_COMPONENT_NBR LEFT OUTER JOIN
	dbo.CAMPAIGN CMP ON DR.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER LEFT OUTER JOIN
	dbo.SALES_CLASS SC ON DR.SC_CODE = SC.SC_CODE AND
						  DR.MEDIA_TYPE = SC.SC_TYPE LEFT OUTER JOIN
	dbo.VENDOR VN ON DR.VN_CODE = VN.VN_CODE LEFT OUTER JOIN
	dbo.MARKET ON DR.MARKET_CODE = MARKET.MARKET_CODE LEFT OUTER JOIN
	dbo.AD_SIZE ON DR.AD_SIZE_CODE = AD_SIZE.SIZE_CODE AND
				   DR.MEDIA_TYPE = AD_SIZE.MEDIA_TYPE LEFT OUTER JOIN
	dbo.AD_NUMBER ON DR.AD_NBR = AD_NUMBER.AD_NBR LEFT OUTER JOIN
	dbo.INTERNET_TYPE IT ON DR.INTERNET_TYPE_CODE = IT.OD_CODE LEFT OUTER JOIN
	(SELECT	
		OMPV1.*,
		MCS.[OrderNumber],
		MCS.[LineNumber],
		MCS.[OrderDescription],
		MCS.[OrderComment],
		MCS.[OrderDate],
		MCS.[ClientPO],
		MCS.[LinkID],
		MCS.[LineLinkID],
		MCS.[OrderDateType],
		MCS.[InsertionDate],
		MCS.[OrderEndDate],
		MCS.[OrderMonth],
		MCS.[OrderYear],
		MCS.[JobNumber],
		MCS.[JobDescription],
		MCS.[JobComponentNumber],
		MCS.[JobComponentDescription],
		MCS.[CostType],
		MCS.[ProjectedImpressions],
		MCS.[GuaranteedImpressions],
		MCS.[ActualImpressions],
		MCS.[LineDescription],
		MCS.[MiscellaneousInfo],
		MCS.[OrderCopy],
		MCS.[MaterialNotes]
	 FROM
		(SELECT
			 *
		 FROM
			 dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA MPDLLD INNER JOIN
			 (SELECT 
					 [MediaPlanID] = MPDL.MEDIA_PLAN_ID,
					 [EstimateID] = MPDL.MEDIA_PLAN_DTL_ID,
					 [ColumnName] = MPDL.[DESCRIPTION], 
					 [RowIndex] = MPDLL.ROW_INDEX,
					 [ColumnValue] = MPDLL.[DESCRIPTION], 
					 [VendorCode] = MPDLLT.VN_CODE 
			 FROM
					 dbo.MEDIA_PLAN_DTL_LEVEL MPDL INNER JOIN
					 dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_ID = MPDL.MEDIA_PLAN_DTL_LEVEL_ID INNER JOIN
					 dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG MPDLLT ON MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID
			 WHERE
					 MPDL.TAG_TYPE = 2) AS VT ON MPDLLD.MEDIA_PLAN_ID = VT.MediaPlanID AND
												 MPDLLD.MEDIA_PLAN_DTL_ID = VT.EstimateID AND
												 MPDLLD.ROW_INDEX = VT.[RowIndex] INNER JOIN
			 (SELECT 
					 [AdSizeMediaPlanID] = MPDL.MEDIA_PLAN_ID,
					 [AdSizeEstimateID] = MPDL.MEDIA_PLAN_DTL_ID,
					 [AdSizeColumnName] = MPDL.[DESCRIPTION], 
					 [AdSizeRowIndex] = MPDLL.ROW_INDEX,
					 [AdSizeColumnValue] = MPDLL.[DESCRIPTION], 
					 [AdSizeCode] = MPDLLT.SIZE_CODE 
			 FROM
					 dbo.MEDIA_PLAN_DTL_LEVEL MPDL INNER JOIN
					 dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_ID = MPDL.MEDIA_PLAN_DTL_LEVEL_ID INNER JOIN
					 dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG MPDLLT ON MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID
			 WHERE
					 MPDL.TAG_TYPE = 3) AS ADSZ ON MPDLLD.MEDIA_PLAN_ID = ADSZ.AdSizeMediaPlanID AND
												   MPDLLD.MEDIA_PLAN_DTL_ID = ADSZ.AdSizeEstimateID AND
												   MPDLLD.ROW_INDEX = ADSZ.[AdSizeRowIndex] INNER JOIN
			(SELECT
				[MediaPlanDetailID] = MPTOTALS.MEDIA_PLAN_DTL_ID,
				[RowIdx] = MPTOTALS.ROW_INDEX,
				[Rate] = CASE WHEN COUNT(CASE WHEN MPTOTALS.RATE IS NOT NULL THEN 1 END) > 0 THEN SUM(ISNULL(MPTOTALS.RATE, 0)) / COUNT(CASE WHEN MPTOTALS.RATE IS NOT NULL THEN 1 END) ELSE 0 END,
				[CPI] = CASE WHEN COUNT(CASE WHEN MPTOTALS.CPI IS NOT NULL THEN 1 END) > 0 THEN SUM(MPTOTALS.CPI) / COUNT(CASE WHEN MPTOTALS.CPI IS NOT NULL THEN 1 END) ELSE NULL END,
				[CTR] = CASE WHEN SUM(MPTOTALS.IMPRESSIONS) <> 0 THEN SUM(MPTOTALS.CLICKS) / SUM(MPTOTALS.IMPRESSIONS) ELSE 0 END,
				[ConversionRate] = CASE WHEN SUM(MPTOTALS.CLICKS) <> 0 THEN SUM(MPTOTALS.UNITS) / SUM(MPTOTALS.CLICKS) ELSE 0 END
			FROM
				(SELECT
 					[MEDIA_PLAN_DTL_ID] = MPDLLD.MEDIA_PLAN_DTL_ID,
 					[ROW_INDEX] = MPDLLD.ROW_INDEX,
 					[IMPRESSIONS] = MPDLLD.IMPRESSIONS,
 					[CLICKS] = MPDLLD.CLICKS,
 					[UNITS] = MPDLLD.UNITS,
 					[NET_DOLLARS] = MPDLLD.NET_DOLLARS,
 					[RATE] = MPDLLD.RATE,
					[CPI] = CASE WHEN MPDLLD.IMPRESSIONS <> 0 THEN MPDLLD.NET_DOLLARS / CASE WHEN MPIMPSET.BOOLEAN_VALUE = 1 THEN (IMPRESSIONS / 1000) ELSE IMPRESSIONS END ELSE NULL END
				 FROM
 					(SELECT 
   						MEDIA_PLAN_DTL_LEVEL_LINE_DATA.MEDIA_PLAN_DTL_ID,
   						MEDIA_PLAN_DTL_LEVEL_LINE_DATA.ROW_INDEX,
   						[IMPRESSIONS] = ISNULL(IMPRESSIONS, 0),
   						[CLICKS] = ISNULL(CLICKS, 0),
  						[UNITS] = ISNULL(UNITS, 0),
  						[NET_DOLLARS] = CASE WHEN MEDIA_PLAN_DTL.IS_ESTIMATE_GROSS = 1 THEN .85 ELSE 1 END * ISNULL(DOLLARS, 0),
  						[RATE] = RATE
 					 FROM 
   						dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA JOIN
  						dbo.MEDIA_PLAN_DTL ON MEDIA_PLAN_DTL_LEVEL_LINE_DATA.MEDIA_PLAN_DTL_ID = MEDIA_PLAN_DTL.MEDIA_PLAN_DTL_ID) MPDLLD LEFT OUTER JOIN
					(SELECT
						*
					 FROM
						dbo.MEDIA_PLAN_DTL_SETTING 
					 WHERE
						SETTING = 'IsImpressionsCPM') MPIMPSET ON MPDLLD.MEDIA_PLAN_DTL_ID = MPIMPSET.MEDIA_PLAN_DTL_ID) MPTOTALS
			GROUP BY
				MPTOTALS.MEDIA_PLAN_DTL_ID,
				MPTOTALS.ROW_INDEX) PLANTOTALS ON MPDLLD.MEDIA_PLAN_DTL_ID = PLANTOTALS.MediaPlanDetailID AND
												  MPDLLD.ROW_INDEX = PLANTOTALS.RowIdx) OMPV1 LEFT OUTER JOIN
		@MediaCurrentStatusSummary MCS ON OMPV1.ORDER_NBR = MCS.OrderNumber AND
										  OMPV1.ORDER_LINE_NBR = MCS.LineNumber AND
										  OMPV1.VendorCode = MCS.VendorCode AND
										  OMPV1.[START_DATE] = MCS.InsertionDate) OMPV ON DR.MEDIA_PLAN_ID = OMPV.MEDIA_PLAN_ID AND
																						  DR.MEDIA_PLAN_DTL_ID = OMPV.MEDIA_PLAN_DTL_ID AND
																						  DR.VN_CODE = OMPV.VendorCode AND
																						  DR.AD_SIZE_CODE = OMPV.AdSizeCode AND
																						  DR.RESULT_DATE BETWEEN OMPV.[START_DATE] AND OMPV.OrderEndDate LEFT OUTER JOIN
	--@MediaCurrentStatusSummary MCS ON OMPV.ORDER_NBR = MCS.OrderNumber AND
	--								  OMPV.ORDER_LINE_NBR = MCS.LineNumber AND
	--								  OMPV.VendorCode = MCS.VendorCode AND
	--								  OMPV.[START_DATE] = MCS.[InsertionDate] LEFT OUTER JOIN
	@MediaPlanComparisonSummary MPCS ON DR.CL_CODE = MPCS.ClientCode AND
										DR.DIV_CODE = MPCS.DivisionCode AND
										DR.PRD_CODE = MPCS.ProductCode AND
										CMP.CMP_CODE = MPCS.CampaignCode AND
										DR.SC_CODE = MPCS.SalesClassCode AND
										DR.VN_CODE = MPCS.VendorCode AND
										DR.AD_SIZE_CODE = MPCS.AdSizeCode AND
										MONTH(DR.RESULT_DATE) = MPCS.[Month] AND
										YEAR(DR.RESULT_DATE) = MPCS.[Year] 
	WHERE
		DR.RESULT_DATE >= @start_date AND
		DR.RESULT_DATE <= @end_date AND
		DR.MEDIA_PLAN_ID IS NOT NULL AND
		DR.MEDIA_PLAN_DTL_ID IS NOT NULL AND DR.MEDIA_TYPE = 'I'
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND JOB.[OFFICE_CODE] IN (SELECT items FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND CL.CL_CODE IN (SELECT items FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND CL.CL_CODE + '|' + DIV.DIV_CODE IN (SELECT items FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND CL.CL_CODE + '|' + DIV.DIV_CODE + '|' + PRD.PRD_CODE IN (SELECT items FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))	

UNION ALL
SELECT
	[ID] = NEWID(),
	[MediaPlanID] = DR.MEDIA_PLAN_ID,
	[MediaPlanDescription] = MP.[DESCRIPTION],
	[ClientCode] = DR.CL_CODE,
	[ClientName] = CASE WHEN DR.CL_CODE IS NULL THEN DR.CL_NAME ELSE CL.CL_NAME END,
	[DivisonCode] = DR.DIV_CODE,
	[DivisionName] = DIV.DIV_NAME,
	[ProductCode] = DR.PRD_CODE,
	[ProductName] = PRD.PRD_DESCRIPTION,
	--[JobNumber] = DR.JOB_NUMBER,
	--[JobDescription] = CASE WHEN DR.JOB_NUMBER IS NULL THEN DR.JOB_DESC ELSE JOB.JOB_DESC END,
	--[JobComponentNumber] = DR.JOB_COMPONENT_NBR,
	--[JobComponentDescription] = CASE WHEN DR.JOB_COMPONENT_NBR IS NULL THEN DR.JOB_COMP_DESC ELSE COMP.JOB_COMP_DESC END,
	[EstimateID] = DR.MEDIA_PLAN_DTL_ID,
	[EstimateDescription] = MPD.NAME,
	[MediaType] = DR.MEDIA_TYPE,
	[SalesClassCode] = DR.SC_CODE,
	[SalesClassDescription] = SC.SC_DESCRIPTION,
	[CampaignID] = DR.CMP_IDENTIFIER,
	[CampaignCode] = CASE WHEN DR.CMP_IDENTIFIER IS NULL THEN DR.CMP_CODE ELSE CMP.CMP_CODE END,
	[CampaignName] =  CASE WHEN DR.CMP_IDENTIFIER IS NULL THEN DR.CMP_NAME ELSE CMP.CMP_NAME END,
	[VendorCode] = DR.VN_CODE,
	[VendorName] = CASE WHEN DR.VN_CODE IS NULL THEN DR.VN_NAME ELSE VN.VN_NAME END,
	[MarketCode] = DR.MARKET_CODE,
	[MarketDescription] = CASE WHEN DR.MARKET_CODE IS NULL THEN DR.MARKET_DESC ELSE MARKET.MARKET_DESC END,
	[AdSizeCode] = DR.AD_SIZE_CODE,
	[AdSizeDescription] = CASE WHEN DR.AD_SIZE_CODE IS NULL THEN DR.AD_SIZE_DESC ELSE AD_SIZE.SIZE_DESC END,
	[AdNumber] = DR.AD_NBR,
	[AdNumberDescription] = CASE WHEN DR.AD_NBR IS NULL THEN DR.AD_NBR_DESC ELSE AD_NUMBER.AD_NBR_DESC END,
	[InternetTypeCode] = DR.INTERNET_TYPE_CODE,
	[InternetTypeDescription] = CASE WHEN DR.INTERNET_TYPE_CODE IS NULL THEN DR.OD_DESC ELSE IT.OD_DESC END,
	[Placement] = DR.PLACEMENT,
	[PlacementPixelSize] = DR.PLACEMENT_PX_SIZE,
	[PlacementPixelURL] = DR.PLACEMENT_URL,
	[Creative] = DR.CREATIVE,
	[Tactic] = DR.TACTIC,
	[PagePositioning] = DR.PAGE_POSITIONING,
	[StartDate] = DR.RESULT_DATE,
	[EndDate] = DR.END_DATE,
	[NetGrossRate] = CASE WHEN ISNULL(DR.NET_GROSS_RATE, 0) = 0 THEN 'Net' WHEN DR.NET_GROSS_RATE = 1 THEN 'Gross' END,
	[Units] = DR.UNITS,
	[Impressions] = DR.IMPRESSIONS,
	[Clicks] = DR.CLICKS,
	[ClickRate] = DR.CLICK_RATE,
	[TotalConversions] = DR.TOTAL_CONVERSIONS,
	[Rate] = DR.RATE,
	[NetDollars] = DR.NET_DOLLARS,
	[GrossDollars] = DR.GROSS_DOLLARS,
	[TargetAudience] = DR.TARGET_AUDIENCE,
	[ImpressionsViewable] = DR.IMPRESSIONS_VIEWABLE,
	[ImpressionsMeasurable] = DR.IMPRESSIONS_MEASUREABLE,
	[TotalConversionsB] = DR.TOTAL_CONVERSIONS_B,
	[TotalConversionsC] = DR.TOTAL_CONVERSIONS_C,
	[ConversionRate] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(DR.CLICKS, 0) <> 0 THEN ISNULL(DR.TOTAL_CONVERSIONS, 0) / ISNULL(DR.CLICKS, 0) * 100 END),
	[ConversionRateB] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(DR.CLICKS, 0) <> 0 THEN ISNULL(DR.TOTAL_CONVERSIONS_B, 0) / ISNULL(DR.CLICKS, 0) * 100 END),
	[ConversionRateC] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(DR.CLICKS, 0) <> 0 THEN ISNULL(DR.TOTAL_CONVERSIONS_C, 0) / ISNULL(DR.CLICKS, 0) * 100 END),
	[OfficeCode] = CMPMPCS.[OfficeCode],
	[OfficeName] = CMPMPCS.[OfficeName],
	[Month] = CMPMPCS.[Month],
	[Year] = CMPMPCS.[Year],
	[PlanUnits] = NULL, --CMPMPCS.PlanUnits,
	[PlanImpressions] = NULL, --CMPMPCS.PlanImpressions,
	[PlanClicks] = NULL, --CMPMPCS.PlanClicks,
	[PlanDemo1] = NULL, --CMPMPCS.PlanDemo1,
	[PlanDemo2] = NULL, --CMPMPCS.PlanDemo2,
	[PlanQuantity] = NULL, --CMPMPCS.PlanQuantity,
	[PlanNetAmount] = NULL, --CMPMPCS.PlanNetAmount,
	[PlanCommission] = NULL, --CMPMPCS.PlanCommission,
	[PlanAgencyFee] = NULL, --CMPMPCS.PlanAgencyFee,
	[PlanBillAmount] = NULL, --CMPMPCS.PlanBillAmount,
	[PlanRate] = NULL, --OMPV.Rate, -- MPCS.PlanRate,
	[PlanCPI] = NULL, --CASE WHEN ISNULL(CMPMPCS.PlanImpressions, 0) <> 0 THEN CMPMPCS.PlanNetAmount / CMPMPCS.PlanImpressions ELSE NULL END, -- OMPV.CPI, -- MPCS.PlanCPI,
	[PlanCTR] = NULL, --CASE WHEN ISNULL(CMPMPCS.PlanImpressions, 0) <> 0 THEN (CMPMPCS.PlanClicks / CMPMPCS.PlanImpressions) * 100 ELSE NULL END, -- MPCS.PlanCTR,
	[PlanConversionRatePercent] = NULL, --CASE WHEN ISNULL(CMPMPCS.PlanClicks, 0) <> 0 THEN (CMPMPCS.PlanUnits / CMPMPCS.PlanClicks) * 100 ELSE NULL END, -- MPCS.PlanConversionRatePercent,
	[OrderQuantity] = CMPMPCS.OrderQuantity,
	[OrderNetAmount] = CMPMPCS.OrderNetAmount,
	[OrderCommission] = CMPMPCS.OrderCommission,
	[OrderAgencyFee] = CMPMPCS.OrderAgencyFee,
	[OrderBillAmount] = CMPMPCS.OrderBillAmount,
	[BilledQuantity] = CMPMPCS.BilledQuantity,
	[BilledCommissionAmount] = CMPMPCS.BilledCommissionAmount,
	[BilledAgencyFee] = CMPMPCS.BilledAgencyFee,
	[BilledNetAmount] = CMPMPCS.BilledNetAmount,
	[BilledBillAmount] = CMPMPCS.BilledBillAmount,
	[APQuantity] = CMPMPCS.APQuantity,
	[APNetAmount] = CMPMPCS.APNetAmount,
	[PlanBillToOrderedBillVariance] = NULL, --CMPMPCS.PlanBillToOrderedBillVariance,
	[PlanBillToBilledVariance] = NULL, --CMPMPCS.PlanBillToBilledVariance,
	[OrderedToBilledVariance] = CMPMPCS.OrderedToBilledVariance,
	[OrderedToAPVariance] = CMPMPCS.OrderedToAPVariance,
	[OrderNumber] = CMPMCS.[OrderNumber],
	[LineNumber] = CMPMCS.[LineNumber],
	--MPFS.[VendorCode],
	--MPFS.[VendorName],
	[OrderDescription] = CMPMCS.[OrderDescription],
	[OrderComment] =CMPMCS.[OrderComment],
	[OrderDate] = CMPMCS.[OrderDate],
	[ClientPO] = CMPMCS.[ClientPO],
	[LinkID] = CMPMCS.[LinkID],
	[LineLinkID] = CMPMCS.[LineLinkID],
	[OrderDateType] = CMPMCS.[OrderDateType],
	[InsertionDate] = CMPMCS.[InsertionDate],
	[OrderEndDate] = CMPMCS.[OrderEndDate],
	[OrderMonth] = CMPMCS.[OrderMonth],
	[OrderYear] = CMPMCS.[OrderYear],
	[JobNumber] = CMPMCS.[JobNumber],
	[JobDescription] = CMPMCS.[JobDescription],
	[JobComponentNumber] = CMPMCS.[JobComponentNumber],
	[JobComponentDescription] = CMPMCS.[JobComponentDescription],
	[CostType] = CMPMCS.[CostType],
	[ProjectedImpressions] = CMPMCS.[ProjectedImpressions],
	[GuaranteedImpressions] = CMPMCS.[GuaranteedImpressions],
	[ActualImpressions] = CMPMCS.[ActualImpressions],
	[LineDescription] = CMPMCS.[LineDescription],
	[MiscellaneousInfo] = CMPMCS.[MiscellaneousInfo],
	[OrderCopy] = CMPMCS.[OrderCopy],
	[MaterialNotes] = CMPMCS.[MaterialNotes],
	[DaypartCode] = DR.[DAY_PART_CODE]
FROM
	dbo.DIGITAL_RESULTS DR LEFT OUTER JOIN
	dbo.MEDIA_PLAN MP ON DR.MEDIA_PLAN_ID = MP.MEDIA_PLAN_ID LEFT OUTER JOIN
	dbo.MEDIA_PLAN_DTL MPD ON DR.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND
							  DR.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID LEFT OUTER JOIN
	dbo.CLIENT CL ON DR.CL_CODE = CL.CL_CODE LEFT OUTER JOIN
	dbo.DIVISION DIV ON DR.CL_CODE = DIV.CL_CODE AND
						DR.DIV_CODE = DIV.DIV_CODE LEFT OUTER JOIN
	dbo.PRODUCT PRD ON DR.CL_CODE = PRD.CL_CODE AND
					   DR.DIV_CODE = PRD.DIV_CODE AND
					   DR.PRD_CODE = PRD.PRD_CODE LEFT OUTER JOIN
	dbo.JOB_LOG JOB ON DR.JOB_NUMBER = JOB.JOB_NUMBER LEFT OUTER JOIN
	dbo.JOB_COMPONENT COMP ON DR.JOB_NUMBER = COMP.JOB_NUMBER AND
							  DR.JOB_COMPONENT_NBR = COMP.JOB_COMPONENT_NBR LEFT OUTER JOIN
	dbo.CAMPAIGN CMP ON DR.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER LEFT OUTER JOIN
	dbo.SALES_CLASS SC ON DR.SC_CODE = SC.SC_CODE AND
						  DR.MEDIA_TYPE = SC.SC_TYPE LEFT OUTER JOIN
	dbo.VENDOR VN ON DR.VN_CODE = VN.VN_CODE LEFT OUTER JOIN
	dbo.MARKET ON DR.MARKET_CODE = MARKET.MARKET_CODE LEFT OUTER JOIN
	dbo.AD_SIZE ON DR.AD_SIZE_CODE = AD_SIZE.SIZE_CODE AND
				   DR.MEDIA_TYPE = AD_SIZE.MEDIA_TYPE LEFT OUTER JOIN
	dbo.AD_NUMBER ON DR.AD_NBR = AD_NUMBER.AD_NBR LEFT OUTER JOIN
	dbo.INTERNET_TYPE IT ON DR.INTERNET_TYPE_CODE = IT.OD_CODE LEFT OUTER JOIN
	@MediaCurrentStatusSummary CMPMCS ON DR.CMP_IDENTIFIER = CMPMCS.CampaignID AND
										 DR.VN_CODE = CMPMCS.VendorCode AND
										 DR.AD_SIZE_CODE = CMPMCS.AdSizeCode AND
										 DR.RESULT_DATE BETWEEN CMPMCS.InsertionDate AND CMPMCS.OrderEndDate LEFT OUTER JOIN
										 --MONTH(DR.RESULT_DATE) = CMPMCS.[Month] AND
										 --YEAR(DR.RESULT_DATE) = CMPMCS.[Year] LEFT OUTER JOIN
	@MediaPlanComparisonSummary CMPMPCS ON DR.CMP_IDENTIFIER = CMPMPCS.CampaignID AND
										   DR.VN_CODE = CMPMPCS.VendorCode AND
										   DR.AD_SIZE_CODE = CMPMPCS.AdSizeCode AND
										   MONTH(DR.RESULT_DATE) = CMPMPCS.[Month] AND
										   YEAR(DR.RESULT_DATE) = CMPMPCS.[Year] AND
										   DR.MEDIA_PLAN_ID IS NULL AND
										   DR.MEDIA_PLAN_DTL_ID IS NULL
	WHERE
		DR.RESULT_DATE >= @start_date AND
		DR.RESULT_DATE <= @end_date AND
		DR.MEDIA_PLAN_ID IS NULL AND
		DR.MEDIA_PLAN_DTL_ID IS NULL AND DR.MEDIA_TYPE = 'I'
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND JOB.[OFFICE_CODE] IN (SELECT items FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND CL.CL_CODE IN (SELECT items FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND CL.CL_CODE + '|' + DIV.DIV_CODE IN (SELECT items FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND CL.CL_CODE + '|' + DIV.DIV_CODE + '|' + PRD.PRD_CODE IN (SELECT items FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))	

DROP TABLE #media_cur_status

END

GO

GRANT EXECUTE ON [advsp_digital_results_comparison_report] TO PUBLIC
GO
