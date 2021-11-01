CREATE PROC advsp_bcc_billing_worksheet_media 
	@incl_unbilled_only bit, @incl_zero_spots bit, @date_to_use smallint,
	@newspaper bit, @magazine bit, @internet bit, @out_of_home bit,
	@radio bit, @radio_daily bit, @radio_monthly bit, @television bit, @tv_daily bit, @tv_monthly bit,
	@m_start_date smalldatetime, @m_cutoff_date smalldatetime, @brdcast_date1 smalldatetime, @brdcast_date2 smalldatetime,
	@job_media_date_from smalldatetime, @job_media_date_to smalldatetime,
	@ClientCodeList varchar(max),
	@ClientDivisionCodeList varchar(max),
	@ClientDivisionProductCodeList varchar(max),
	@AECodeList varchar(max),
	@BillingCommandCenterID int,
	@user_code varchar(100),
	@omit_zero_unbilled_amounts bit,
	@debug bit = 0
AS

BEGIN

SET NOCOUNT ON;
SET ARITHABORT ON; --for OPTION (RECOMPILE)

DECLARE @selection TABLE (
	selection_id	int NOT NULL,
	ORDER_NBR		int NOT NULL,
	LINE_NBR		int NOT NULL,
	BCC_ID			int NULL,
	BRDCAST_YEAR	int NULL,
	BRDCAST_MONTH	int NULL,
	CMP_IDENTIFIER	int NULL,
	CL_CODE			varchar(6) NULL,
	DIV_CODE		varchar(6) NULL,
	PRD_CODE		varchar(6) NULL,
	ORDER_DESC		varchar(40) NULL,
	MEDIA_FROM		varchar(11) NULL,
	CLIENT_PO		varchar(25) NULL,
	MARKET_CODE		varchar(10) NULL
)

if @debug = 1 
	select getdate() 'AS START'

INSERT INTO @selection 
EXEC [advsp_bcc_get_media_available] NULL, NULL, 0, 
	@incl_unbilled_only, @incl_zero_spots, @date_to_use,
	@newspaper, @magazine, @internet, @out_of_home,
	@radio, @radio_daily, @radio_monthly, @television, @tv_daily, @tv_monthly,
	@m_start_date, @m_cutoff_date, @brdcast_date1, @brdcast_date2, 0,
	@job_media_date_from, @job_media_date_to

DECLARE @setup_active smallint

DECLARE @media_summary TABLE (
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	ORDER_NBR			integer NOT NULL,
	LINE_NBR			integer NOT NULL,
	OFFICE_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	CMP_IDENTIFIER		integer NULL,
	CMP_NAME			varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MARKET_CODE			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	VN_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	VN_NAME				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	LINK_ID				integer NULL,
	CLIENT_PO			varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	BUYER				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MAX_REV				integer NULL,
	ORDER_DESC			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_TYPE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_DESC				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_FROM			varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ORDER_DATE			smalldatetime NULL,
	INSERTION_DATE		smalldatetime NULL,
	BRDCAST_MONTH		smalldatetime NULL,
	CLOSE_DATE			smalldatetime NULL,
	DATE_TO_BILL		smalldatetime NULL,
	BILLING_USER		varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	NET_AMT				decimal(15,2) NULL,
	COMM_AMT			decimal(15,2) NULL,
	REBATE_AMT			decimal(15,2) NULL,
	ADDTL_CHARGES		decimal(15,2) NULL,
	DISCOUNT_AMT		decimal(15,2) NULL,
	NET_CHARGES			decimal(15,2) NULL,
	VENDOR_TAX			decimal(15,2) NULL,
	RESALE_TAX			decimal(15,2) NULL,
	BILLABLE_AMT		decimal(15,2) NULL,
	HAS_UNBILLED		bit NULL,
	BILLED_AMT			decimal(15,2) NULL,
	UNBILLED_AMT		decimal(15,2) NULL,
	AP_POSTED_AMT		decimal(15,2) NULL,
	SELECTED_AMT		decimal(15,2) NULL,
	BILL_STATUS			smallint NULL,
	BILL_TYPE			smallint NULL,
	ORDER_PROC_CTL		smallint NULL,
	SETUP_COMPLETE		smallint NULL,
	BILL_COOP_CODE		varchar(6) NULL,
	JOB_NUMBER			int NULL,
	JOB_COMPONENT_NBR	smallint NULL,
	LINK_DETID			int NULL,
	BILLED_RESALE_TAX	decimal(15,2) NULL,
	SPOTS				int NULL,
	[START_DATE]		smalldatetime NULL,
	END_DATE			smalldatetime NULL,
	FISCAL_PERIOD_CODE	varchar(6) NULL,
	HEADLINE			varchar(60) NULL,
	BILL_COOP_DESC		varchar(30) NULL,
	PROGRAMMING			varchar(50) NULL,
	JOB_MEDIA_BILL_DATE	smalldatetime NULL,
	UNITS				varchar(2) NULL,
	MonthNumber			smallint NULL,
	YearNumber			smallint NULL,
	MonthYear			varchar(8) NULL,
	BCC_ID				int NULL
)

SELECT @setup_active = COALESCE( BILL_MEDIA_TYPE, 0 )
FROM dbo.AGENCY

DECLARE @EmployeeCode varchar(6), @HasCDPLimits bit

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@user_code)

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@user_code)) > 0
	SET @HasCDPLimits = 1
ELSE
	SET @HasCDPLimits = 0

		INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
				OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
				LINK_ID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
				MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL, BILL_STATUS, SETUP_COMPLETE, BILL_COOP_CODE, JOB_NUMBER, JOB_COMPONENT_NBR,
				[START_DATE], END_DATE, FISCAL_PERIOD_CODE, BILL_COOP_DESC, JOB_MEDIA_BILL_DATE, UNITS, BCC_ID )
		 SELECT vmh.CL_CODE, vmh.DIV_CODE, vmh.PRD_CODE, vmomrs.ORDER_NBR, vmomrs.LINE_NBR, 
				p.OFFICE_CODE, vmh.CMP_IDENTIFIER, c.CMP_NAME, vmh.MARKET_CODE, vmh.VN_CODE,
				v.VN_NAME, vmh.LINK_ID, vmh.CLIENT_PO, vmh.BUYER, vmomrs.MAX_REV, vmh.ORDER_DESC, 
				vmh.MEDIA_TYPE, sc.SC_DESCRIPTION, vmh.MEDIA_FROM, vmh.ORDER_DATE, 
				vmh.ORD_PROCESS_CONTRL,
				CASE vmh.MEDIA_FROM
					WHEN 'Mag2' THEN COALESCE( p.PRD_MAG_PRE_POST, 1 )
					WHEN 'News2' THEN COALESCE( p.PRD_NEWS_PRE_POST, 1 )
					WHEN 'Internet' THEN COALESCE( p.PRD_MISC_PRE_POST, 1 ) 
					WHEN 'Outdoor' THEN COALESCE( p.PRD_OTDR_PRE_POST, 1 )
					WHEN 'Radio2' THEN COALESCE( p.PRD_RADIO_PRE_POST, 1 )
					WHEN 'TV2' THEN COALESCE( p.PRD_TV_PRE_POST, 1 )
				END,
				CASE 
					WHEN ( @setup_active = 1 AND vmh.MEDIA_FROM = 'Mag2' ) THEN COALESCE( p.MAG_SETUP_COMPLETE, 0 )
					WHEN ( @setup_active = 1 AND vmh.MEDIA_FROM = 'News2' ) THEN COALESCE( p.NEWS_SETUP_COMPLETE, 0 )
					WHEN ( @setup_active = 1 AND vmh.MEDIA_FROM = 'Internet' ) THEN COALESCE( p.INET_SETUP_COMPLETE, 0 )
					WHEN ( @setup_active = 1 AND vmh.MEDIA_FROM = 'Outdoor' ) THEN COALESCE( p.OOH_SETUP_COMPLETE, 0 )
					WHEN ( @setup_active = 1 AND vmh.MEDIA_FROM = 'Radio2' ) THEN COALESCE( p.RADIO_SETUP_COMPLETE, 0 )
					WHEN ( @setup_active = 1 AND vmh.MEDIA_FROM = 'TV2' ) THEN COALESCE( p.TV_SETUP_COMPLETE, 0 )
					ELSE NULL
				END,
				vmh.BILL_COOP_CODE, vmomrs.JOB_NUMBER, vmomrs.JOB_COMPONENT_NBR,
				vmh.[START_DATE], vmh.END_DATE, vmh.FISCAL_PERIOD_CODE, BC.BILL_COOP_DESC, jc.MEDIA_BILL_DATE, vmh.UNITS, bol.BCC_ID
		FROM dbo.V_BCC_MEDIA_ORDER_ACTIVE_REVISIONS vmomrs
			INNER JOIN dbo.V_BCC_MEDIA_HDR vmh ON ( vmomrs.ORDER_NBR = vmh.ORDER_NBR )
			INNER JOIN dbo.VENDOR v ON ( vmh.VN_CODE = v.VN_CODE )
			INNER JOIN dbo.PRODUCT p ON ( vmh.CL_CODE = p.CL_CODE AND vmh.DIV_CODE = p.DIV_CODE AND vmh.PRD_CODE = p.PRD_CODE )
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( vmh.MEDIA_TYPE = sc.SC_CODE )
			LEFT OUTER JOIN dbo.CAMPAIGN c ON ( vmh.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
			LEFT OUTER JOIN (
							SELECT DISTINCT BILL_COOP_CODE, BILL_COOP_DESC
							FROM dbo.BILLING_COOP
							) BC ON vmh.BILL_COOP_CODE = BC.BILL_COOP_CODE
			INNER JOIN @selection bol ON vmomrs.ORDER_NBR = bol.ORDER_NBR AND vmomrs.LINE_NBR = bol.LINE_NBR
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON vmomrs.JOB_NUMBER = jc.JOB_NUMBER AND vmomrs.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		WHERE vmh.MEDIA_FROM IN ( 'Mag2', 'News2', 'Internet', 'Outdoor', 'Radio2', 'TV2' )
		AND (
				( @HasCDPLimits = 1 AND EXISTS (
												SELECT 1
												FROM dbo.SEC_CLIENT sc
												WHERE UPPER(sc.[USER_ID]) = UPPER(@user_code)
												AND sc.CL_CODE = vmh.CL_CODE
												AND sc.DIV_CODE = vmh.DIV_CODE
												AND sc.PRD_CODE = vmh.PRD_CODE
												AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
											   ))
			OR
				( @HasCDPLimits = 0 AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)

if @debug = 1 
	select getdate(), count(1) from @media_summary

-- MAGAZINE
	UPDATE @media_summary
	   SET NET_AMT = 0.00,
		   VENDOR_TAX = 0.00,
		   RESALE_TAX = 0.00,
		   COMM_AMT = 0.00,
		   NET_CHARGES = 0.00,
		   DISCOUNT_AMT = 0.00,
		   ADDTL_CHARGES = 0.00,
		   REBATE_AMT = 0.00,
		   BILLABLE_AMT = 0.00,
		   SELECTED_AMT = 0.00,
		   HAS_UNBILLED = 0,
		   INSERTION_DATE = md.[START_DATE],
		   CLOSE_DATE = md.CLOSE_DATE,
		   BILL_TYPE = md.BILL_TYPE_FLAG,
		   DATE_TO_BILL = md.DATE_TO_BILL,
		   LINK_DETID = md.LINK_DETID,
		   HEADLINE = md.HEADLINE,
		   MonthYear = CASE WHEN md.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), md.[START_DATE], 0)) + ' ' + CAST(YEAR(md.[START_DATE]) as varchar(4)) ELSE NULL END
	  FROM @media_summary ms 
			INNER JOIN dbo.MAGAZINE_DETAIL md
					ON ( ms.ORDER_NBR = md.ORDER_NBR )
				   AND ( ms.LINE_NBR = md.LINE_NBR )
				   AND ( md.ACTIVE_REV = 1 )
				   AND ( ms.MEDIA_FROM = 'Mag' OR ms.MEDIA_FROM = 'Mag2' )

if @debug = 1 
	select getdate() AS 'after MAGAZINE update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( md.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( md.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( md.STATE_AMT, 0.00 ) + COALESCE( md.COUNTY_AMT, 0.00 ) + COALESCE( md.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( md.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( md.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( md.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( md.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( md.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( md.BILLING_AMT, 0.00 )
		   --BILLABLE_AMT = ( CASE md.BILL_TYPE_FLAG 
					--			WHEN 1 THEN COALESCE( md.COMM_AMT, 0.00 ) + COALESCE( md.REBATE_AMT, 0.00 ) 
					--			ELSE COALESCE( md.BILLING_AMT, 0.00 ) 
		   --                 END )
	  FROM @media_summary ms 
			INNER JOIN dbo.MAGAZINE_DETAIL md
					ON ( ms.ORDER_NBR = md.ORDER_NBR )
				   AND ( ms.LINE_NBR = md.LINE_NBR )
				   AND ( md.ACTIVE_REV = 1 )
  				   AND ( md.LINE_CANCELLED = 0 OR md.LINE_CANCELLED IS NULL )
				   AND ( ms.MEDIA_FROM = 'Mag' OR ms.MEDIA_FROM = 'Mag2' )

if @debug = 1 
	select getdate() AS 'after MAGAZINE update2'

 UPDATE @media_summary
    SET HAS_UNBILLED = 1
   FROM @media_summary ms
  WHERE EXISTS( SELECT 1
				  FROM dbo.MAGAZINE_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Mag2' )

if @debug = 1 
	select getdate() AS 'after MAGAZINE update3'

UPDATE @media_summary	 
	SET BILLED_AMT = (SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						FROM dbo.MAGAZINE_DETAIL d   
						WHERE ms.ORDER_NBR = d.ORDER_NBR
						AND ms.LINE_NBR = d.LINE_NBR
						AND d.AR_INV_NBR IS NOT NULL),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.MAGAZINE_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms
  WHERE	( ms.MEDIA_FROM = 'Mag2' )
--    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 ) 

if @debug = 1 
	select getdate() AS 'after MAGAZINE update4'

 --UPDATE @media_summary	 
 --   SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
	--					 FROM dbo.MAGAZINE_DETAIL d   
	--					WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
	--					  AND ( ms.LINE_NBR = d.LINE_NBR )
	--					  AND ( d.AR_INV_NBR IS NOT NULL ))
 --  FROM @media_summary ms
 -- WHERE	( ms.MEDIA_FROM = 'Mag2' )
 --   AND ( ms.BILL_TYPE = 1 ) 

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.DISBURSED_AMT, 0.00 )), 0.00 ) 
                            FROM dbo.AP_MAGAZINE ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
        BILLING_USER = ( SELECT TOP 1 BILLING_USER 
                           FROM MAGAZINE_DETAIL d
                          WHERE ms.ORDER_NBR = d.ORDER_NBR 
                            AND ms.LINE_NBR = d.LINE_NBR
                            AND d.BILLING_USER IS NOT NULL ),
		SELECTED_AMT = (  SELECT COALESCE( SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00 ) 
                            FROM MAGAZINE_DETAIL d
                          WHERE ms.ORDER_NBR = d.ORDER_NBR 
                            AND ms.LINE_NBR = d.LINE_NBR
                            AND d.BILLING_USER IS NOT NULL )
   FROM @media_summary ms                             
  WHERE MEDIA_FROM = 'Mag2'

if @debug = 1 
	select getdate() AS 'after MAGAZINE update6'

	UPDATE @media_summary
	   SET NET_AMT = 0.00,
		   VENDOR_TAX = 0.00,
		   RESALE_TAX = 0.00,
		   COMM_AMT = 0.00,
		   NET_CHARGES = 0.00,
		   DISCOUNT_AMT = 0.00,
		   ADDTL_CHARGES = 0.00,
		   REBATE_AMT = 0.00,
		   BILLABLE_AMT = 0.00,
		   SELECTED_AMT = 0.00,
		   HAS_UNBILLED = 0,
		   INSERTION_DATE = nd.[START_DATE],
		   CLOSE_DATE = nd.CLOSE_DATE,
		   BILLING_USER = nd.BILLING_USER,
		   BILL_TYPE = nd.BILL_TYPE_FLAG,
		   DATE_TO_BILL = nd.DATE_TO_BILL,
		   LINK_DETID = nd.LINK_DETID,
		   HEADLINE = nd.HEADLINE,
		   MonthYear = CASE WHEN nd.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), nd.[START_DATE], 0)) + ' ' + CAST(YEAR(nd.[START_DATE]) as varchar(4)) ELSE NULL END
	  FROM @media_summary ms 
INNER JOIN dbo.NEWSPAPER_DETAIL nd
	    ON ( ms.ORDER_NBR = nd.ORDER_NBR )
	   AND ( ms.LINE_NBR = nd.LINE_NBR )
	   AND ( nd.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'News' OR ms.MEDIA_FROM = 'News2' ) 

if @debug = 1 
	select getdate() AS 'after NEWS update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( nd.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( nd.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( nd.STATE_AMT, 0.00 ) + COALESCE( nd.COUNTY_AMT, 0.00 ) + COALESCE( nd.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( nd.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( nd.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( nd.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( nd.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( nd.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( nd.BILLING_AMT, 0.00 )
		   --BILLABLE_AMT = ( CASE nd.BILL_TYPE_FLAG 
					--			WHEN 1 THEN COALESCE( nd.COMM_AMT, 0.00 ) + COALESCE( nd.REBATE_AMT, 0.00 ) 
					--			ELSE COALESCE( nd.BILLING_AMT, 0.00 ) 
		   --                 END )
	  FROM @media_summary ms 
INNER JOIN dbo.NEWSPAPER_DETAIL nd
	    ON ( ms.ORDER_NBR = nd.ORDER_NBR )
	   AND ( ms.LINE_NBR = nd.LINE_NBR )
	   AND ( nd.ACTIVE_REV = 1 )
  	   AND ( nd.LINE_CANCELLED = 0 OR nd.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'News' OR ms.MEDIA_FROM = 'News2' )

if @debug = 1 
	select getdate() AS 'after NEWS update2'

 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT 1
				  FROM dbo.NEWSPAPER_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'News2' )

if @debug = 1 
	select getdate() AS 'after NEWS update3'

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.NEWSPAPER_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.NEWSPAPER_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'News2' )
--    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )

if @debug = 1 
	select getdate() AS 'after NEWS update4'

 --UPDATE @media_summary	 
 --   SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
	--					 FROM dbo.NEWSPAPER_DETAIL d   
	--					WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
	--					  AND ( ms.LINE_NBR = d.LINE_NBR )
	--					  AND ( d.AR_INV_NBR IS NOT NULL ))
 --  FROM @media_summary ms 
 -- WHERE	( ms.MEDIA_FROM = 'News2' )
 --   AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.DISBURSED_AMT, 0.00 )), 0.00 ) 
                            FROM dbo.AP_NEWSPAPER ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
        BILLING_USER = ( SELECT TOP 1 BILLING_USER 
                           FROM NEWSPAPER_DETAIL d
                          WHERE ms.ORDER_NBR = d.ORDER_NBR 
                            AND ms.LINE_NBR = d.LINE_NBR 
							AND d.BILLING_USER IS NOT NULL ),
		SELECTED_AMT = (  SELECT COALESCE( SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00 ) 
                            FROM NEWSPAPER_DETAIL d
                           WHERE ms.ORDER_NBR = d.ORDER_NBR 
                             AND ms.LINE_NBR = d.LINE_NBR
                             AND d.BILLING_USER IS NOT NULL ) 
   FROM @media_summary ms 
  WHERE MEDIA_FROM = 'News2'

if @debug = 1 
	select getdate() AS 'after NEWS update6'

	UPDATE @media_summary
	   SET NET_AMT = 0.00,
		   VENDOR_TAX = 0.00,
		   RESALE_TAX = 0.00,
		   COMM_AMT = 0.00,
		   NET_CHARGES = 0.00,
		   DISCOUNT_AMT = 0.00,
		   ADDTL_CHARGES = 0.00,
		   REBATE_AMT = 0.00,
		   BILLABLE_AMT = 0.00,
		   SELECTED_AMT = 0.00,
		   INSERTION_DATE = id.[START_DATE],
		   CLOSE_DATE = id.CLOSE_DATE,
		   BILLING_USER = id.BILLING_USER,
		   BILL_TYPE = id.BILL_TYPE_FLAG,
		   DATE_TO_BILL = id.DATE_TO_BILL,
		   LINK_DETID = id.LINK_DETID,
		   HEADLINE = id.HEADLINE,
		   MonthYear = CASE WHEN id.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), id.[START_DATE], 0)) + ' ' + CAST(YEAR(id.[START_DATE]) as varchar(4)) ELSE NULL END
	  FROM @media_summary ms 
INNER JOIN dbo.INTERNET_DETAIL id
	    ON ( ms.ORDER_NBR = id.ORDER_NBR )
	   AND ( ms.LINE_NBR = id.LINE_NBR )
	   AND ( id.ACTIVE_REV = 1 )	  
	   AND ( ms.MEDIA_FROM = 'Internet' ) 

if @debug = 1 
	select getdate() AS 'after INTERNET update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( id.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( id.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( id.STATE_AMT, 0.00 ) + COALESCE( id.COUNTY_AMT, 0.00 ) + COALESCE( id.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( id.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( id.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( id.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( id.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( id.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( id.BILLING_AMT, 0.00 )
		   --BILLABLE_AMT = ( CASE id.BILL_TYPE_FLAG 
					--			WHEN 1 THEN COALESCE( id.COMM_AMT, 0.00 ) + COALESCE( id.REBATE_AMT, 0.00 ) 
					--			ELSE COALESCE( id.BILLING_AMT, 0.00 ) 
		   --                 END )
	  FROM @media_summary ms 
INNER JOIN dbo.INTERNET_DETAIL id
	    ON ( ms.ORDER_NBR = id.ORDER_NBR )
	   AND ( ms.LINE_NBR = id.LINE_NBR )
	   AND ( id.ACTIVE_REV = 1 )	  
  	   AND ( id.LINE_CANCELLED = 0 OR id.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Internet' ) 

if @debug = 1 
	select getdate() AS 'after INTERNET update2'

 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT 1
				  FROM dbo.INTERNET_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Internet' )

if @debug = 1 
	select getdate() AS 'after INTERNET update3'

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.INTERNET_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.INTERNET_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Internet' )
    --AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )

if @debug = 1 
	select getdate() AS 'after INTERNET update4'

 --UPDATE @media_summary	 
 --   SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
	--					 FROM dbo.INTERNET_DETAIL d   
	--					WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
	--					  AND ( ms.LINE_NBR = d.LINE_NBR )
	--					  AND ( d.AR_INV_NBR IS NOT NULL ))
 --  FROM @media_summary ms 
 -- WHERE	( ms.MEDIA_FROM = 'Internet' )
 --   AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISCOUNT_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_INTERNET ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
        BILLING_USER = ( SELECT TOP 1 BILLING_USER 
                           FROM INTERNET_DETAIL d
                          WHERE ms.ORDER_NBR = d.ORDER_NBR 
                            AND ms.LINE_NBR = d.LINE_NBR
                            AND d.BILLING_USER IS NOT NULL ),
		SELECTED_AMT = (  SELECT COALESCE( SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00 ) 
                            FROM INTERNET_DETAIL d
                           WHERE ms.ORDER_NBR = d.ORDER_NBR 
                             AND ms.LINE_NBR = d.LINE_NBR
                             AND d.BILLING_USER IS NOT NULL )
   FROM @media_summary ms 
  WHERE MEDIA_FROM = 'Internet'

if @debug = 1 
	select getdate() AS 'after INTERNET update6'

	UPDATE @media_summary
	   SET NET_AMT = 0.00,
		   VENDOR_TAX = 0.00,
		   RESALE_TAX = 0.00,
		   COMM_AMT = 0.00,
		   NET_CHARGES = 0.00,
		   DISCOUNT_AMT = 0.00,
		   ADDTL_CHARGES = 0.00,
		   REBATE_AMT = 0.00,
		   BILLABLE_AMT = 0.00,
		   SELECTED_AMT = 0.00,
		   INSERTION_DATE = od.POST_DATE,
		   CLOSE_DATE = od.CLOSE_DATE,
		   BILLING_USER = od.BILLING_USER,
		   BILL_TYPE = od.BILL_TYPE_FLAG,
		   DATE_TO_BILL = od.DATE_TO_BILL,
		   LINK_DETID = od.LINK_DETID,
		   HEADLINE = od.HEADLINE,
		   MonthYear = CASE WHEN od.[POST_DATE] IS NOT NULL THEN UPPER(convert(char(3), od.[POST_DATE], 0)) + ' ' + CAST(YEAR(od.[POST_DATE]) as varchar(4)) ELSE NULL END
	  FROM @media_summary ms 
INNER JOIN dbo.OUTDOOR_DETAIL od
	    ON ( ms.ORDER_NBR = od.ORDER_NBR )
	   AND ( ms.LINE_NBR = od.LINE_NBR )
	   AND ( od.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'Outdoor' ) 

if @debug = 1 
	select getdate() AS 'after OUTDOOR update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( od.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( od.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( od.STATE_AMT, 0.00 ) + COALESCE( od.COUNTY_AMT, 0.00 ) + COALESCE( od.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( od.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( od.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( od.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( od.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( od.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( od.BILLING_AMT, 0.00 )
		   --BILLABLE_AMT = ( CASE od.BILL_TYPE_FLAG 
					--			WHEN 1 THEN COALESCE( od.COMM_AMT, 0.00 ) 
					--			ELSE COALESCE( od.BILLING_AMT, 0.00 ) 
		   --                 END )
	  FROM @media_summary ms 
INNER JOIN dbo.OUTDOOR_DETAIL od
	    ON ( ms.ORDER_NBR = od.ORDER_NBR )
	   AND ( ms.LINE_NBR = od.LINE_NBR )
	   AND ( od.ACTIVE_REV = 1 )
  	   AND ( od.LINE_CANCELLED = 0 OR od.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Outdoor' ) 

if @debug = 1 
	select getdate() AS 'after OUTDOOR update2'


 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT 1
				  FROM dbo.OUTDOOR_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Outdoor' )

if @debug = 1 
	select getdate() AS 'after OUTDOOR update3'


 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.OUTDOOR_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.OUTDOOR_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Outdoor' )
    --AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )

if @debug = 1 
	select getdate() AS 'after OUTDOOR update4'


 --UPDATE @media_summary	 
 --   SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
	--					 FROM dbo.OUTDOOR_DETAIL d   
	--					WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
	--					  AND ( ms.LINE_NBR = d.LINE_NBR )
	--					  AND ( d.AR_INV_NBR IS NOT NULL ))
 --  FROM @media_summary ms 
 -- WHERE	( ms.MEDIA_FROM = 'Outdoor' )
 --   AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISCOUNT_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_OUTDOOR ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
        BILLING_USER = ( SELECT TOP 1 BILLING_USER 
                           FROM OUTDOOR_DETAIL d
                          WHERE ms.ORDER_NBR = d.ORDER_NBR 
                            AND ms.LINE_NBR = d.LINE_NBR
                            AND d.BILLING_USER IS NOT NULL ),
		SELECTED_AMT = (  SELECT COALESCE( SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00 ) 
                            FROM OUTDOOR_DETAIL d
                           WHERE ms.ORDER_NBR = d.ORDER_NBR 
                             AND ms.LINE_NBR = d.LINE_NBR
                             AND d.BILLING_USER IS NOT NULL )
   FROM @media_summary ms 
  WHERE MEDIA_FROM = 'Outdoor'

if @debug = 1 
	select getdate() AS 'after OUTDOOR update6'


-- BEGIN NEW RADIO
	UPDATE @media_summary
	   SET NET_AMT = 0.00,
		   VENDOR_TAX = 0.00,
		   RESALE_TAX = 0.00,
		   COMM_AMT = 0.00,
		   NET_CHARGES = 0.00,
		   DISCOUNT_AMT = 0.00,
		   ADDTL_CHARGES = 0.00,
		   REBATE_AMT = 0.00,
		   BILLABLE_AMT = 0.00,
		   SELECTED_AMT = 0.00,
		   INSERTION_DATE = rd.[START_DATE],
		   CLOSE_DATE = rd.CLOSE_DATE, 
		   BRDCAST_MONTH = ( CAST( CAST( rd.MONTH_NBR AS varchar(2)) + '/01/' + CAST( rd.YEAR_NBR AS varchar(4)) AS smalldatetime )),
		   BILLING_USER = rd.BILLING_USER,
		   BILL_TYPE = rd.BILL_TYPE_FLAG,
		   DATE_TO_BILL = rd.DATE_TO_BILL,
		   LINK_DETID = rd.LINK_DETID,
		   SPOTS = rd.TOTAL_SPOTS,
		   PROGRAMMING = rd.PROGRAMMING,
		   MonthNumber = rd.MONTH_NBR,
		   YearNumber = rd.YEAR_NBR,
		   MonthYear = CASE WHEN ms.UNITS IN ('BM', 'CM') THEN SUBSTRING(UPPER(DateName( month , DateAdd( month , MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(YEAR_NBR as varchar(4))
						ELSE CASE WHEN rd.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), rd.[START_DATE], 0)) + ' ' + CAST(YEAR(rd.[START_DATE]) as varchar(4)) ELSE NULL END
					   END
	  FROM @media_summary ms 
INNER JOIN dbo.RADIO_DETAIL rd
	    ON ( ms.ORDER_NBR = rd.ORDER_NBR )
	   AND ( ms.LINE_NBR = rd.LINE_NBR )
	   AND ( rd.ACTIVE_REV = 1 )	  
	   AND ( ms.MEDIA_FROM = 'Radio2' ) 

if @debug = 1 
	select getdate() AS 'after Radio update1'
	
	UPDATE @media_summary
	   SET NET_AMT = COALESCE( rd.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( rd.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( rd.STATE_AMT, 0.00 ) + COALESCE( rd.COUNTY_AMT, 0.00 ) + COALESCE( rd.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( rd.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( rd.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( rd.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( rd.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( rd.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( rd.BILLING_AMT, 0.00 )
		   --BILLABLE_AMT = ( CASE rd.BILL_TYPE_FLAG 
					--			WHEN 1 THEN COALESCE( rd.COMM_AMT, 0.00 ) + COALESCE( rd.REBATE_AMT, 0.00 ) 
					--			ELSE COALESCE( rd.BILLING_AMT, 0.00 ) 
		   --                 END )
	  FROM @media_summary ms 
INNER JOIN dbo.RADIO_DETAIL rd
	    ON ( ms.ORDER_NBR = rd.ORDER_NBR )
	   AND ( ms.LINE_NBR = rd.LINE_NBR )
	   AND ( rd.ACTIVE_REV = 1 )	  
  	   AND ( rd.LINE_CANCELLED = 0 OR rd.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Radio2' ) 

if @debug = 1 
	select getdate() AS 'after Radio update2'
	
 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT 1
				  FROM dbo.RADIO_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Radio2' )

if @debug = 1 
	select getdate() AS 'after Radio update3'
	
 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.RADIO_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.RADIO_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Radio2' )
    --AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )

if @debug = 1 
	select getdate() AS 'after Radio update4'
	
 --UPDATE @media_summary	 
 --   SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
	--					 FROM dbo.RADIO_DETAIL d   
	--					WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
	--					  AND ( ms.LINE_NBR = d.LINE_NBR )
	--					  AND ( d.AR_INV_NBR IS NOT NULL ))
 --  FROM @media_summary ms 
 -- WHERE	( ms.MEDIA_FROM = 'Radio2' )
 --   AND ( ms.BILL_TYPE = 1 )
	
 UPDATE @media_summary
	SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.EXT_NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISC_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_RADIO ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
        BILLING_USER = ( SELECT TOP 1 BILLING_USER 
                           FROM RADIO_DETAIL d
                          WHERE ms.ORDER_NBR = d.ORDER_NBR 
                            AND ms.LINE_NBR = d.LINE_NBR
                            AND d.BILLING_USER IS NOT NULL ),
		SELECTED_AMT = (  SELECT COALESCE( SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00 ) 
                            FROM RADIO_DETAIL d
                           WHERE ms.ORDER_NBR = d.ORDER_NBR 
                             AND ms.LINE_NBR = d.LINE_NBR
                             AND d.BILLING_USER IS NOT NULL )
   FROM @media_summary ms 
  WHERE MEDIA_FROM = 'Radio2'

if @debug = 1 
	select getdate() AS 'after Radio update6'
	
-- BEGIN NEW TV
	UPDATE @media_summary
	   SET NET_AMT = 0.00,
		   VENDOR_TAX = 0.00,
		   RESALE_TAX = 0.00,
		   COMM_AMT = 0.00,
		   NET_CHARGES = 0.00,
		   DISCOUNT_AMT = 0.00,
		   ADDTL_CHARGES = 0.00,
		   REBATE_AMT = 0.00,
		   BILLABLE_AMT = 0.00,
		   SELECTED_AMT = 0.00,
		   INSERTION_DATE = td.[START_DATE],
		   BRDCAST_MONTH = ( CAST( CAST( td.MONTH_NBR AS varchar(2)) + '/01/' + CAST( td.YEAR_NBR AS varchar(4)) AS smalldatetime )),
		   CLOSE_DATE = td.CLOSE_DATE,
		   BILLING_USER = td.BILLING_USER,
		   BILL_TYPE = td.BILL_TYPE_FLAG,
		   DATE_TO_BILL = td.DATE_TO_BILL,
		   LINK_DETID = td.LINK_DETID,
		   SPOTS = td.TOTAL_SPOTS,
		   PROGRAMMING = td.PROGRAMMING,
		   MonthNumber = td.MONTH_NBR,
		   YearNumber = td.YEAR_NBR,
		   MonthYear = CASE WHEN ms.UNITS IN ('BM', 'CM') THEN SUBSTRING(UPPER(DateName( month , DateAdd( month , MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(YEAR_NBR as varchar(4))
						ELSE CASE WHEN td.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), td.[START_DATE], 0)) + ' ' + CAST(YEAR(td.[START_DATE]) as varchar(4)) ELSE NULL END
					   END
	  FROM @media_summary ms 
INNER JOIN dbo.TV_DETAIL td
	    ON ( ms.ORDER_NBR = td.ORDER_NBR )
	   AND ( ms.LINE_NBR = td.LINE_NBR )
	   AND ( td.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'TV2' ) 

if @debug = 1 
	select getdate() AS 'after TV update1'
	
	UPDATE @media_summary
	   SET NET_AMT = COALESCE( td.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( td.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( td.STATE_AMT, 0.00 ) + COALESCE( td.COUNTY_AMT, 0.00 ) + COALESCE( td.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( td.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( td.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( td.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( td.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( td.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( td.BILLING_AMT, 0.00 )
		   --BILLABLE_AMT = ( CASE td.BILL_TYPE_FLAG 
					--			WHEN 1 THEN COALESCE( td.COMM_AMT, 0.00 ) + COALESCE( td.REBATE_AMT, 0.00 ) 
					--			ELSE COALESCE( td.BILLING_AMT, 0.00 ) 
		   --                 END )
	  FROM @media_summary ms 
INNER JOIN dbo.TV_DETAIL td
	    ON ( ms.ORDER_NBR = td.ORDER_NBR )
	   AND ( ms.LINE_NBR = td.LINE_NBR )
	   AND ( td.ACTIVE_REV = 1 )
  	   AND ( td.LINE_CANCELLED = 0 OR td.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'TV2' ) 

if @debug = 1 
	select getdate() AS 'after TV update2'
	
 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT 1
				  FROM dbo.TV_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'TV2' )

if @debug = 1 
	select getdate() AS 'after TV update3'
	
 UPDATE @media_summary
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.TV_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.TV_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'TV2' )
    --AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )

if @debug = 1 
	select getdate() AS 'after TV update4'
	
 --UPDATE @media_summary	 
 --   SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
	--					 FROM dbo.TV_DETAIL d   
	--					WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
	--					  AND ( ms.LINE_NBR = d.LINE_NBR )
	--					  AND ( d.AR_INV_NBR IS NOT NULL ))
 --  FROM @media_summary ms 
 -- WHERE	( ms.MEDIA_FROM = 'TV2' )
 --   AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.EXT_NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISC_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_TV ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
        BILLING_USER = ( SELECT TOP 1 BILLING_USER 
                           FROM TV_DETAIL d
                          WHERE ms.ORDER_NBR = d.ORDER_NBR 
                            AND ms.LINE_NBR = d.LINE_NBR
                            AND d.BILLING_USER IS NOT NULL ),
		SELECTED_AMT = (  SELECT COALESCE( SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00 ) 
                            FROM TV_DETAIL d
                           WHERE ms.ORDER_NBR = d.ORDER_NBR 
                             AND ms.LINE_NBR = d.LINE_NBR
                             AND d.BILLING_USER IS NOT NULL ) 
   FROM @media_summary ms 
  WHERE MEDIA_FROM = 'TV2'

if @debug = 1 
	select getdate() AS 'after TV update6'
	
 UPDATE @media_summary	 
    SET UNBILLED_AMT = COALESCE( BILLABLE_AMT - BILLED_AMT, 0.00 )
	
if @debug = 1 
	select getdate() AS 'after last MS update'

	 SELECT [ClientCode] = ms.CL_CODE,
			[DivisionCode] = ms.DIV_CODE,
			[ProductCode] = ms.PRD_CODE,
			[OrderNumber] = ORDER_NBR,
			[LineNumber] = LINE_NBR,
			[RevisionNumber] = CAST( NULL AS integer ),
			[OfficeCode] = ms.OFFICE_CODE,
			[CampaignID] = ms.CMP_IDENTIFIER,
			[CampaignName] = ms.CMP_NAME,
			[SalesClassCode] = MEDIA_TYPE,
			[SalesClassDescription] = SC_DESC,
			[MarketCode] = ms.MARKET_CODE,
			[VendorCode] = VN_CODE,
			[VendorName] = VN_NAME,
			[LinkID] = LINK_ID,
			[ClientPO] = CLIENT_PO,
			[BillingCoopCode] = BILL_COOP_CODE,
			[BillingCoopDescription] = BILL_COOP_DESC,
			[Buyer] = BUYER,
			[MaxRevision] = MAX_REV,
			[OrderDescription] = ORDER_DESC,
			[MediaFrom] = CASE MEDIA_FROM
							WHEN 'Mag2' THEN 'Magazine'
							WHEN 'News2' THEN 'Newspaper'
							WHEN 'Internet' THEN 'Internet'
							WHEN 'Outdoor' THEN 'Out of Home'
							WHEN 'Radio2' THEN 'Radio'
							WHEN 'TV2' THEN 'TV'
							END,
			[OrderDate] = ORDER_DATE,
			[InsertionDate] = INSERTION_DATE,
			[BroadcastMonth] = BRDCAST_MONTH,
			[CloseDate] = CLOSE_DATE,
			[DateToBill] = DATE_TO_BILL,
			[BillingUser] = ms.BILLING_USER,
			[NetAmount] = NET_AMT,
			[CommissionAmount] = COMM_AMT,
			[RebateAmount] = REBATE_AMT,
			[AdditionalChargeAmount] = ADDTL_CHARGES,
			[DiscountAmount] = DISCOUNT_AMT,
			[NetChargeAmount] = NET_CHARGES,
			[VendorTaxAmount] = VENDOR_TAX,
			[ResaleTaxAmount] = RESALE_TAX,
			[BillableTotal] = BILLABLE_AMT, -- already includes resale tax
			[BilledTotal] = BILLED_AMT, -- already includes resale tax
			[HasUnbilled] = HAS_UNBILLED,
			[UnbilledTotal] = UNBILLED_AMT,
			[APPostedAmount] = AP_POSTED_AMT,
			[AmountSelectedforBilling] = SELECTED_AMT,
			[BillStatus] = CASE COALESCE(BILL_STATUS, 1)
							WHEN 1 THEN 'Prebill'
							WHEN 2 THEN 'Post Bill'
							END,
			[IsSetupComplete] = SETUP_COMPLETE,
			[OrderProcessControl] = JPC.JOB_PROCESS_DESC,
			[MonthYear] = ms.MonthYear,
			[BillType] = CASE BILL_TYPE
							WHEN 1 THEN 'Comm Only'
							WHEN 2 THEN 'Net'
							WHEN 3 THEN 'Gross'
							ELSE '' END,
			[OfficeDescription] = O.OFFICE_NAME,
			[ClientName] = C.CL_NAME,
			[DivisionName] = D.DIV_NAME,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignCode] = CMP.CMP_CODE,
			[MarketDescription] = M.MARKET_DESC,
			[JobNumber] = ms.JOB_NUMBER,
			[JobComponentNumber] = ms.JOB_COMPONENT_NBR,
			[LinkLineID] = ms.LINK_DETID,
			[BilledResaleTax] = ms.BILLED_RESALE_TAX,
			[Spots] = ms.SPOTS,
			[FiscalPeriod] = FISCAL_PERIOD_CODE,
            [StartDate] = [START_DATE],
            [EndDate] = END_DATE,
			[Headline] = HEADLINE,
			[AECode] = AE.EMP_CODE,
			[AEFirstName] = AE.EMP_FNAME,
			[AELastName] = AE.EMP_LNAME,
			[AccountExecutive] = AE.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(AE.EMP_MI, '') + ' ') + AE.EMP_LNAME,
			[Programming] = PROGRAMMING,
			[JobMediaDateToBill] = ms.JOB_MEDIA_BILL_DATE,
			[Units] = ms.UNITS,
			[MonthNumber] = ms.MonthNumber,
			[YearNumber] = ms.YearNumber,
			[BillingBatchName] = BCC.BATCH_NAME
	   FROM @media_summary ms
			INNER JOIN dbo.JOB_PROC_CONTROLS JPC ON ms.ORDER_PROC_CTL = JPC.JOB_PROCESS_CONTRL 
			LEFT OUTER JOIN dbo.OFFICE O ON ms.OFFICE_CODE = O.OFFICE_CODE
			LEFT OUTER JOIN dbo.CLIENT C ON ms.CL_CODE = C.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION D ON ms.CL_CODE = D.CL_CODE AND ms.DIV_CODE = D.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT P ON ms.CL_CODE = P.CL_CODE AND ms.DIV_CODE = P.DIV_CODE AND ms.PRD_CODE = P.PRD_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN CMP ON ms.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.MARKET M ON ms.MARKET_CODE = M.MARKET_CODE 
			LEFT OUTER JOIN (
							SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_LNAME, E.EMP_MI
							FROM dbo.ACCOUNT_EXECUTIVE AE
								INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
							WHERE AE.DEFAULT_AE  = 1
							AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
							) AE ON ms.CL_CODE = AE.CL_CODE AND ms.DIV_CODE = AE.DIV_CODE AND ms.PRD_CODE = AE.PRD_CODE
			LEFT OUTER JOIN dbo.BILLING_CMD_CENTER BCC ON BCC.BCC_ID = ms.BCC_ID
		WHERE
				(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND ms.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND ms.CL_CODE + '|' + ms.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND ms.CL_CODE + '|' + ms.DIV_CODE + '|' + ms.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		AND		(@AECodeList IS NULL OR (@AECodeList IS NOT NULL AND AE.EMP_CODE IN (SELECT * from dbo.udf_split_list(@AECodeList, ','))))
		AND		(@BillingCommandCenterID IS NULL OR (@BillingCommandCenterID IS NOT NULL AND ms.BCC_ID = @BillingCommandCenterID))
		AND		(
					(@omit_zero_unbilled_amounts = 1 AND UNBILLED_AMT <> 0)
				OR
					(@omit_zero_unbilled_amounts = 0)
				)
		OPTION (RECOMPILE)
if @debug = 1 
	select getdate() AS 'finish'
		
END