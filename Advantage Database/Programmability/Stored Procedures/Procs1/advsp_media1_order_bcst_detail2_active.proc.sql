
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_bcst_detail2_active]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_media1_order_bcst_detail2_active]
GO

CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_detail2_active] (
	@order_status					varchar(1) = 'A',				--A = all, O = open
	@start_month					int	= 1,
	@start_year						int	= 1900,
	@end_month						int	= 12,						
	@end_year						int	= 2100,						 
	@include_radio					bit	= 1,
	@include_television				bit	= 1,
	@revisions						bit	= 0		--#04
	)								
	
-- advsp_media1_order_bcst_detail2_active
-- extracts data for active revision only, within a specified date range
-- modified specifically for advsp_media1_media_current_status1(_sum)
-- #00 03/12/15 - original, copied from advsp_media1_order_bcst_detail2 (#04 06/20/13)
-- #01 03/21/15 - added ACTIVE_REV = 1 to WHERE clause
-- #02 05/12/15 - set unused fields for MCS to NULL, rather than taking time to populate them (735-1768)
-- #03 01/18/16 - add new fields for API
-- #04 07/16/19 - Optional include revisions flag - defaults to 0

AS
BEGIN
	SET NOCOUNT ON;

-- Calculate @start_period																	
DECLARE @start_period int
SELECT @start_period = @start_year * 100 + @start_month

-- Calculate @end_period
DECLARE @end_period int
SELECT @end_period = @end_year * 100 + @end_month	

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_detail(
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

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
IF @include_radio = 1	
BEGIN
	INSERT INTO #order_detail
	SELECT 
		'R' AS ORDER_TYPE, 
		d.ORDER_NBR, 
		d.LINE_NBR,
		CASE WHEN @revisions = 0 THEN 0 ELSE d.REV_NBR END,												--d.REV_NBR,
		CASE WHEN @revisions = 0 THEN 0 ELSE d.SEQ_NBR END,												--d.SEQ_NBR,
		d.ACTIVE_REV,
		d.LINK_DETID,
		d.BUY_TYPE,										
		d.[START_DATE],
		d.END_DATE,
		d.MONTH_NBR,
		d.YEAR_NBR,
		d.DATE1,										
		d.DATE2,										
		d.DATE3,										
		d.DATE4,										
		d.DATE5,										
		d.DATE6,										
		d.DATE7,										
		[DAYS] = RTRIM(CASE WHEN d.MONDAY = 1 THEN 'M ' ELSE '' END +
					   CASE WHEN d.TUESDAY = 1 THEN 'TU ' ELSE '' END +
					   CASE WHEN d.WEDNESDAY = 1 THEN 'W ' ELSE '' END +
					   CASE WHEN d.THURSDAY = 1 THEN 'TH ' ELSE '' END +
					   CASE WHEN d.FRIDAY = 1 THEN 'F ' ELSE '' END +
					   CASE WHEN d.SATURDAY = 1 THEN 'S ' ELSE '' END +
					   CASE WHEN d.SUNDAY = 1 THEN 'SU' ELSE '' END),
		d.SPOTS1,										
		d.SPOTS2,										
		d.SPOTS3,										
		d.SPOTS4,										
		d.SPOTS5,										
		d.SPOTS6,										
		d.SPOTS7,										
		d.TOTAL_SPOTS,
		d.JOB_NUMBER, 
		d.JOB_COMPONENT_NBR,		
		ISNULL(d.START_TIME,NULL),						
		ISNULL(d.END_TIME,NULL),							
		NULL,											--ISNULL(d.[LENGTH],NULL),		
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE,
		d.EXT_CLOSE_DATE,
		d.EXT_MATL_DATE,
		d.MAT_COMP,
		ISNULL(d.AD_NUMBER,''),							
		ISNULL(d.PROGRAMMING,''),						
		ISNULL(d.TAG,''),								
		ISNULL(d.REMARKS,''),
		NULL,											--ISNULL(d.RATE,0),
		NULL,											--d.GROSS_RATE,
		NULL,											--d.NET_RATE,
		d.EXT_NET_AMT,
		NULL,											--d.EXT_GROSS_AMT,
		d.COMM_AMT,
		d.REBATE_AMT,
		d.DISCOUNT_AMT,
		NULL,											--d.DISCOUNT_DESC,
		d.STATE_AMT,
		d.COUNTY_AMT,
		d.CITY_AMT,
		d.NON_RESALE_AMT,
		d.NETCHARGE,
		NULL,											--d.NCDESC,
		d.ADDL_CHARGE,
		NULL,											--d.ADDL_CHARGE_DESC,
		d.LINE_TOTAL,
		d.BILLING_AMT,
		d.BILL_TYPE_FLAG,
		ISNULL(d.LINE_CANCELLED,0),
		d.NON_BILL_FLAG,
		NULL,											--d.RECONCILE_FLAG,
		d.DATE_TO_BILL,
		NULL,											--d.BILLING_USER,
		NULL,											--d.AR_INV_NBR,
		NULL,											--d.AR_TYPE,
		NULL,											--d.AR_INV_SEQ,
		NULL,											--d.EST_NBR,
		NULL,											--d.EST_LINE_NBR,
		NULL,											--d.EST_REV_NBR
		d.MONDAY,
		d.TUESDAY,
		d.WEDNESDAY,
		d.THURSDAY,
		d.FRIDAY,
		d.SATURDAY,
		d.SUNDAY,
		ISNULL(d.NETWORK_ID, ''),
		GRP = MBW.GRP,
		GROSS_IMPRESSIONS = MBW.GROSS_IMPRESSIONS,
		MEDIA_DEMO_DESCRIPTION = MBW.MEDIA_DEMO_DESCRIPTION,
		BOOKEND = MBW.BOOKEND,
		VALUE_ADDED = MBW.VALUE_ADDED
	FROM dbo.RADIO_DETAIL AS d
		JOIN dbo.RADIO_HDR AS h ON h.ORDER_NBR = d.ORDER_NBR 
		LEFT OUTER JOIN (SELECT
								a.ORDER_NBR,
								LINE_NBR = a.ORDER_LINE_NBR, 
								GRP = SUM(a.GRP),
								GROSS_IMPRESSIONS =SUM(a.GROSS_IMPRESSIONS),
								a.MEDIA_DEMO_DESCRIPTION,
								a.BOOKEND,
								a.VALUE_ADDED
							FROM
								(SELECT 
										ORDER_NBR, 
										ORDER_LINE_NBR, 
										GRP = MBWMDD.SPOTS * MBWMD.PRIMARY_AQH_RATING,
										GROSS_IMPRESSIONS = MBWMDD.SPOTS * MBWMD.PRIMARY_AQH,
										MEDIA_DEMO_DESCRIPTION = md.[DESCRIPTION],
										MBWMD.BOOKEND,
										MBWMD.VALUE_ADDED
									FROM 
										dbo.MEDIA_BROADCAST_WORKSHEET MBW
										INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID
										INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
										INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
										INNER JOIN dbo.MEDIA_DEMO md ON md.MEDIA_DEMO_ID = MBW.PRIMARY_MEDIA_DEMO_ID
									WHERE 
										ORDER_NBR IS NOT NULL AND MBWMD.REVISION_NUMBER IN (SELECT MAX(REVISION_NUMBER) FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID GROUP BY MEDIA_BROADCAST_WORKSHEET_MARKET_ID)) AS a
							GROUP BY
								a.ORDER_NBR,
								a.ORDER_LINE_NBR,
								a.MEDIA_DEMO_DESCRIPTION,
								a.BOOKEND,
								a.VALUE_ADDED) AS MBW ON MBW.ORDER_NBR = d.ORDER_NBR AND MBW.LINE_NBR = d.LINE_NBR AND d.ACTIVE_REV = 1
	WHERE (d.ACTIVE_REV = 1 OR @revisions = 1) --#04
		AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))		--#01
		AND d.YEAR_NBR *100 + d.MONTH_NBR BETWEEN @start_period AND @end_period
END	

IF @include_television = 1	
BEGIN
	INSERT INTO #order_detail
	SELECT 
		'T' AS ORDER_TYPE, 
		d.ORDER_NBR, 
		d.LINE_NBR,
		CASE WHEN @revisions = 0 THEN 0 ELSE d.REV_NBR END,												--d.REV_NBR,
		CASE WHEN @revisions = 0 THEN 0 ELSE d.SEQ_NBR END,												--d.SEQ_NBR,
		d.ACTIVE_REV,
		d.LINK_DETID,
		d.BUY_TYPE,										
		d.[START_DATE],
		d.END_DATE,
		d.MONTH_NBR,
		d.YEAR_NBR,
		d.DATE1,										
		d.DATE2,										
		d.DATE3,										
		d.DATE4,										
		d.DATE5,										
		d.DATE6,										
		d.DATE7,										
		[DAYS] = RTRIM(CASE WHEN d.MONDAY = 1 THEN 'M ' ELSE '' END +
					   CASE WHEN d.TUESDAY = 1 THEN 'TU ' ELSE '' END +
					   CASE WHEN d.WEDNESDAY = 1 THEN 'W ' ELSE '' END +
					   CASE WHEN d.THURSDAY = 1 THEN 'TH ' ELSE '' END +
					   CASE WHEN d.FRIDAY = 1 THEN 'F ' ELSE '' END +
					   CASE WHEN d.SATURDAY = 1 THEN 'S ' ELSE '' END +
					   CASE WHEN d.SUNDAY = 1 THEN 'SU' ELSE '' END),
		d.SPOTS1,										
		d.SPOTS2,											
		d.SPOTS3,										
		d.SPOTS4,											
		d.SPOTS5,										
		d.SPOTS6,										
		d.SPOTS7,										
		d.TOTAL_SPOTS,
		d.JOB_NUMBER, 
		d.JOB_COMPONENT_NBR,			
		ISNULL(d.START_TIME,NULL),								
		ISNULL(d.END_TIME,NULL),								
		NULL,											--ISNULL(d.[LENGTH],NULL),		
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE,
		d.EXT_CLOSE_DATE,
		d.EXT_MATL_DATE,
		d.MAT_COMP,										
		ISNULL(d.AD_NUMBER,''),							  
		ISNULL(d.PROGRAMMING,''),						
		ISNULL(d.TAG,''),								
		ISNULL(d.REMARKS,''),
		NULL,											--ISNULL(d.RATE,0),
		NULL,											--d.GROSS_RATE,
		NULL,											--d.NET_RATE,
		d.EXT_NET_AMT,
		NULL,											--d.EXT_GROSS_AMT,
		d.COMM_AMT,
		d.REBATE_AMT,
		d.DISCOUNT_AMT,
		NULL,											--d.DISCOUNT_DESC,
		d.STATE_AMT,
		d.COUNTY_AMT,
		d.CITY_AMT,
		d.NON_RESALE_AMT,
		d.NETCHARGE,
		NULL,											--d.NCDESC,
		d.ADDL_CHARGE,
		NULL,											--d.ADDL_CHARGE_DESC,
		d.LINE_TOTAL,
		d.BILLING_AMT,
		d.BILL_TYPE_FLAG,
		ISNULL(d.LINE_CANCELLED,0),
		d.NON_BILL_FLAG,
		NULL,											--d.RECONCILE_FLAG,
		d.DATE_TO_BILL,
		NULL,											--d.BILLING_USER,
		NULL,											--d.AR_INV_NBR,
		NULL,											--d.AR_TYPE,
		NULL,											--d.AR_INV_SEQ,
		NULL,											--d.EST_NBR,
		NULL,											--d.EST_LINE_NBR,
		NULL,											--d.EST_REV_NBR
		d.MONDAY,
		d.TUESDAY,
		d.WEDNESDAY,
		d.THURSDAY,
		d.FRIDAY,
		d.SATURDAY,
		d.SUNDAY,
		ISNULL(d.NETWORK_ID, ''),
		GRP = MBW.GRP,
		GROSS_IMPRESSIONS = MBW.GROSS_IMPRESSIONS,
		MEDIA_DEMO_DESCRIPTION = MBW.MEDIA_DEMO_DESCRIPTION,
		BOOKEND = MBW.BOOKEND,
		VALUE_ADDED = MBW.VALUE_ADDED
	FROM dbo.TV_DETAIL AS d 
		JOIN dbo.TV_HDR AS h ON h.ORDER_NBR = d.ORDER_NBR
		LEFT OUTER JOIN (SELECT
								a.ORDER_NBR,
								LINE_NBR = a.ORDER_LINE_NBR, 
								GRP = SUM(a.GRP),
								GROSS_IMPRESSIONS =SUM(a.GROSS_IMPRESSIONS),
								a.MEDIA_DEMO_DESCRIPTION,
								a.BOOKEND,
								a.VALUE_ADDED
							FROM
								(SELECT 
										ORDER_NBR, 
										ORDER_LINE_NBR, 
										GRP = MBWMDD.SPOTS * MBWMD.PRIMARY_RATING,
										GROSS_IMPRESSIONS = MBWMDD.SPOTS * MBWMD.PRIMARY_IMPRESSIONS,
										MEDIA_DEMO_DESCRIPTION = md.[DESCRIPTION],
										MBWMD.BOOKEND,
										MBWMD.VALUE_ADDED
									FROM 
										dbo.MEDIA_BROADCAST_WORKSHEET MBW
										INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID
										INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
										INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
										INNER JOIN dbo.MEDIA_DEMO md ON md.MEDIA_DEMO_ID = MBW.PRIMARY_MEDIA_DEMO_ID
									WHERE 
										ORDER_NBR IS NOT NULL AND MBWMD.REVISION_NUMBER IN (SELECT MAX(REVISION_NUMBER) FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID GROUP BY MEDIA_BROADCAST_WORKSHEET_MARKET_ID)) AS a
							GROUP BY
								a.ORDER_NBR,
								a.ORDER_LINE_NBR,
								a.MEDIA_DEMO_DESCRIPTION,
								a.BOOKEND,
								a.VALUE_ADDED) AS MBW ON MBW.ORDER_NBR = d.ORDER_NBR AND MBW.LINE_NBR = d.LINE_NBR AND d.ACTIVE_REV = 1
	WHERE (d.ACTIVE_REV = 1 OR @revisions = 1) --#04 
		AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))		--#01
		AND d.YEAR_NBR *100 + d.MONTH_NBR BETWEEN @start_period AND @end_period
END

SELECT * FROM #order_detail

END
GO
