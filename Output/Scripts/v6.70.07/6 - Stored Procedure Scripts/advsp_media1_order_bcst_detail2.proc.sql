IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_bcst_detail2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_media1_order_bcst_detail2]
GO

CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_detail2] ( @user_code varchar(100), @app_type varchar(1) = 'O', @draft_option tinyint = 0 )
--Stored procedure to extract broadcast NEW DETAIL information
-- #00 07/06/11 - initial release
-- #01 08/01/11 - added @app_type (and WHERE), BILL_TYPE_FLAG
-- #02 09/13/11 - added join to max rev and max seq
-- #03 07/20/12 - added new columns EST_NBR -> EST_REV_NBR
-- #04 06/20/13 - added code to bypass/streamline #order_inv_max_rev_seq as appropriate
-- #05 03/17/15 - copied from v660 to v670. v670 appears to have had the same script, but without these comments

-- @app_type; Order = "O", Invoice = "I"
-- @draft_option; Regular Invoice = 0, Draft Invoice = 1

AS
BEGIN
	SET NOCOUNT ON;

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
	REV_NBR					tinyint NULL,
	SEQ_NBR					tinyint NULL,
	AR_INV_NBR				int NULL)
	
-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	IF @app_type = 'I' AND @draft_option = 0	--#04
	BEGIN
		INSERT INTO #order_inv_max_rev_seq
		SELECT d.ORDER_NBR,
			d.LINE_NBR,
			d.REV_NBR,
			MAX(d.SEQ_NBR),
			d.AR_INV_NBR
		FROM dbo.RADIO_DETAIL AS d			
		JOIN #media_orders AS o					--#04
			ON d.ORDER_NBR = o.ORDER_NBR
		WHERE d.AR_INV_NBR IS NOT NULL
			AND d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.RADIO_DETAIL AS d2
			WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR
			AND d.AR_INV_NBR = d2.AR_INV_NBR)
		GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.AR_INV_NBR
		--SELECT * FROM #order_inv_max_rev_seq
	END	
	
	INSERT INTO #order_detail
	SELECT 'R' AS ORDER_TYPE, 
		d.ORDER_NBR, 
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.ACTIVE_REV,
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
		CASE
			WHEN d.MONDAY = 1 AND d.TUESDAY = 1 AND d.WEDNESDAY = 1 AND d.THURSDAY = 1 AND d.FRIDAY = 1 AND d.SATURDAY = 1 AND  d.SUNDAY = 1 THEN 'M-Su'
			WHEN d.MONDAY = 1 AND d.TUESDAY = 1 AND d.WEDNESDAY = 1 AND d.THURSDAY = 1 AND d.FRIDAY = 1 AND d.SATURDAY = 1 THEN 'M-Sa'
			WHEN d.MONDAY = 1 AND d.TUESDAY = 1 AND d.WEDNESDAY = 1 AND d.THURSDAY = 1 AND d.FRIDAY = 1 THEN 'M-F'
			ELSE
				CASE d.MONDAY
					WHEN 1 THEN 'M'
					ELSE ''
				END +
				CASE d.TUESDAY
					WHEN 1 THEN 'Tu'
					ELSE ''
				END +
				CASE d.WEDNESDAY
					WHEN 1 THEN 'W'
					ELSE ''
				END +
				CASE d.THURSDAY
					WHEN 1 THEN 'Th'
					ELSE ''
				END +
				CASE d.FRIDAY
					WHEN 1 THEN 'F'
					ELSE ''
				END +
				CASE d.SATURDAY
					WHEN 1 THEN 'Sa'
					ELSE ''
				END +
				CASE d.SUNDAY
					WHEN 1 THEN 'Su'
					ELSE ''
				END
			END AS DAYS,
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
		ISNULL(d.START_TIME,NULL),		--new 8/2/11
		ISNULL(d.END_TIME,NULL),		--new 8/2/11
		ISNULL(d.[LENGTH],NULL),		--new 8/2/11
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE,
		d.MAT_COMP,
		ISNULL(d.AD_NUMBER,''),   
		ISNULL(d.PROGRAMMING,''),
		ISNULL(d.TAG,''), 
		ISNULL(d.REMARKS,''),
		ISNULL(d.RATE,0),
		d.GROSS_RATE,
		d.NET_RATE,
		d.EXT_NET_AMT,
		d.EXT_GROSS_AMT,
		d.COMM_AMT,
		d.REBATE_AMT,
		d.DISCOUNT_AMT,
		d.DISCOUNT_DESC,
		d.STATE_AMT,
		d.COUNTY_AMT,
		d.CITY_AMT,
		d.NON_RESALE_AMT,
		d.NETCHARGE,
		d.NCDESC,
		d.ADDL_CHARGE,
		d.ADDL_CHARGE_DESC,
		d.LINE_TOTAL,
		d.BILLING_AMT,
		d.BILL_TYPE_FLAG,
		ISNULL(d.LINE_CANCELLED,0),
		d.NON_BILL_FLAG,
		d.RECONCILE_FLAG,
		d.DATE_TO_BILL,
		d.BILLING_USER,
		d.AR_INV_NBR,
		d.AR_TYPE,
		d.AR_INV_SEQ,
		d.EST_NBR,
		d.EST_LINE_NBR,
		d.EST_REV_NBR
	FROM dbo.RADIO_DETAIL AS d 
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	LEFT JOIN #order_inv_max_rev_seq AS mrs
		ON d.ORDER_NBR = mrs.ORDER_NBR
		AND d.LINE_NBR = mrs.LINE_NBR
		AND d.REV_NBR = mrs.REV_NBR
		AND d.SEQ_NBR = mrs.SEQ_NBR
		AND d.AR_INV_NBR = mrs.AR_INV_NBR
	WHERE ((@app_type = 'O' AND d.ACTIVE_REV = 1)										
		OR (@app_type = 'I' AND @draft_option = 0 AND mrs.AR_INV_NBR IS NOT NULL)		
		OR (@app_type = 'I' AND @draft_option = 1 AND d.ACTIVE_REV = 1))				
		
	DELETE #order_inv_max_rev_seq
END	

-- Television-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	IF @app_type = 'I' AND @draft_option = 0	--#04
	BEGIN
		INSERT INTO #order_inv_max_rev_seq
		SELECT d.ORDER_NBR,
			d.LINE_NBR,
			d.REV_NBR,
			MAX(d.SEQ_NBR),
			d.AR_INV_NBR
		FROM dbo.TV_DETAIL AS d					
		JOIN #media_orders AS o					--#04
			ON d.ORDER_NBR = o.ORDER_NBR
		WHERE d.AR_INV_NBR IS NOT NULL
			AND d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.TV_DETAIL AS d2
			WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR
			AND d.AR_INV_NBR = d2.AR_INV_NBR)
		GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.AR_INV_NBR
		--SELECT * FROM #order_inv_max_rev_seq
	END	
	
	INSERT INTO #order_detail
	SELECT 'T' AS ORDER_TYPE, 
		d.ORDER_NBR, 
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.ACTIVE_REV,
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
		CASE
			WHEN d.MONDAY = 1 AND d.TUESDAY = 1 AND d.WEDNESDAY = 1 AND d.THURSDAY = 1 AND d.FRIDAY = 1 AND d.SATURDAY = 1 AND  d.SUNDAY = 1 THEN 'M-Su'
			WHEN d.MONDAY = 1 AND d.TUESDAY = 1 AND d.WEDNESDAY = 1 AND d.THURSDAY = 1 AND d.FRIDAY = 1 AND d.SATURDAY = 1 THEN 'M-Sa'
			WHEN d.MONDAY = 1 AND d.TUESDAY = 1 AND d.WEDNESDAY = 1 AND d.THURSDAY = 1 AND d.FRIDAY = 1 THEN 'M-F'
			ELSE
				CASE d.MONDAY
					WHEN 1 THEN 'M'
					ELSE ''
				END +
				CASE d.TUESDAY
					WHEN 1 THEN 'Tu'
					ELSE ''
				END +
				CASE d.WEDNESDAY
					WHEN 1 THEN 'W'
					ELSE ''
				END +
				CASE d.THURSDAY
					WHEN 1 THEN 'Th'
					ELSE ''
				END +
				CASE d.FRIDAY
					WHEN 1 THEN 'F'
					ELSE ''
				END +
				CASE d.SATURDAY
					WHEN 1 THEN 'Sa'
					ELSE ''
				END +
				CASE d.SUNDAY
					WHEN 1 THEN 'Su'
					ELSE ''
				END
			END AS DAYS,
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
		ISNULL(d.START_TIME,NULL),		--new 8/2/11
		ISNULL(d.END_TIME,NULL),		--new 8/2/11
		ISNULL(d.[LENGTH],NULL),		--new 8/2/11
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE,
		d.MAT_COMP, 
		ISNULL(d.AD_NUMBER,''),  
		ISNULL(d.PROGRAMMING,''),
		ISNULL(d.TAG,''), 
		ISNULL(d.REMARKS,''),
		ISNULL(d.RATE,0),
		d.GROSS_RATE,
		d.NET_RATE,
		d.EXT_NET_AMT,
		d.EXT_GROSS_AMT,
		d.COMM_AMT,
		d.REBATE_AMT,
		d.DISCOUNT_AMT,
		d.DISCOUNT_DESC,
		d.STATE_AMT,
		d.COUNTY_AMT,
		d.CITY_AMT,
		d.NON_RESALE_AMT,
		d.NETCHARGE,
		d.NCDESC,
		d.ADDL_CHARGE,
		d.ADDL_CHARGE_DESC,
		d.LINE_TOTAL,
		d.BILLING_AMT,
		d.BILL_TYPE_FLAG,
		ISNULL(d.LINE_CANCELLED,0),
		d.NON_BILL_FLAG,
		d.RECONCILE_FLAG,
		d.DATE_TO_BILL,
		d.BILLING_USER,
		d.AR_INV_NBR,
		d.AR_TYPE,
		d.AR_INV_SEQ,
		d.EST_NBR,
		d.EST_LINE_NBR,
		d.EST_REV_NBR
	FROM dbo.TV_DETAIL AS d 
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	LEFT JOIN #order_inv_max_rev_seq AS mrs
		ON d.ORDER_NBR = mrs.ORDER_NBR
		AND d.LINE_NBR = mrs.LINE_NBR
		AND d.REV_NBR = mrs.REV_NBR
		AND d.SEQ_NBR = mrs.SEQ_NBR
		AND d.AR_INV_NBR = mrs.AR_INV_NBR
	WHERE ((@app_type = 'O' AND d.ACTIVE_REV = 1)										
		OR (@app_type = 'I' AND @draft_option = 0 AND mrs.AR_INV_NBR IS NOT NULL)		
		OR (@app_type = 'I' AND @draft_option = 1 AND d.ACTIVE_REV = 1))				
		
	DELETE #order_inv_max_rev_seq
END

SELECT * FROM #order_detail	
	
END
GO

IF ( @@ERROR = 0 )
	GRANT EXECUTE ON [advsp_media1_order_bcst_detail2] TO PUBLIC AS dbo
GO	
