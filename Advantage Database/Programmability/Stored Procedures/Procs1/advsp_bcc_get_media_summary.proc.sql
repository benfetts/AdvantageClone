if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_bcc_get_media_summary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_bcc_get_media_summary]
GO

CREATE PROC [advsp_bcc_get_media_summary] @BillingCommandCenterID int, @debug bit = 0

AS

BEGIN

DECLARE @bypass_legacy bit

set @bypass_legacy = 1

--CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_media_summary] @order_number_in integer, @line_number_in smallint, 
--	@incl_unbilled_only bit, @ret_val integer OUTPUT
--AS

SET NOCOUNT ON

if @debug = 1 
	select getdate() 'AS START'

DECLARE @setup_active smallint

DECLARE @media_summary TABLE (
	CL_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	ORDER_NBR		integer NOT NULL,
	LINE_NBR		integer NOT NULL,
	OFFICE_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	CMP_IDENTIFIER	integer NULL,
	CMP_NAME		varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MARKET_CODE		varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	VN_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	VN_NAME			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	LINK_ID			integer NULL,
	CLIENT_PO		varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	BUYER			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MAX_REV			integer NULL,
	ORDER_DESC		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_TYPE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_DESC			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_FROM		varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ORDER_DATE		smalldatetime NULL,
	INSERTION_DATE	smalldatetime NULL,
	BRDCAST_MONTH	smalldatetime NULL,
	CLOSE_DATE		smalldatetime NULL,
	DATE_TO_BILL	smalldatetime NULL,
	BILLING_USER	varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	NET_AMT			decimal(15,2) NULL,
	COMM_AMT		decimal(15,2) NULL,
	REBATE_AMT		decimal(15,2) NULL,
	ADDTL_CHARGES	decimal(15,2) NULL,
	DISCOUNT_AMT	decimal(15,2) NULL,
	NET_CHARGES		decimal(15,2) NULL,
	VENDOR_TAX		decimal(15,2) NULL,
	RESALE_TAX		decimal(15,2) NULL,
	BILLABLE_AMT	decimal(15,2) NULL,
	HAS_UNBILLED	bit NULL,
	BILLED_AMT		decimal(15,2) NULL,
	UNBILLED_AMT	decimal(15,2) NULL,
	AP_POSTED_AMT	decimal(15,2) NULL,
	SELECTED_AMT	decimal(15,2) NULL,
	BILL_STATUS		smallint NULL,
	BILL_TYPE		smallint NULL,
	ORDER_PROC_CTL	smallint NULL,
	SETUP_COMPLETE	smallint NULL,
	BILL_COOP_CODE	varchar(6) NULL,
	JOB_NUMBER			int NULL,
	JOB_COMPONENT_NBR	smallint NULL,
	LINK_DETID			int NULL,
	BILLED_RESALE_TAX	decimal(15,2) NULL,
	SPOTS				int NULL,
	HEADLINE			varchar(60) NULL,
	PROGRAMMING			varchar(50) NULL,
	JOB_MEDIA_BILL_DATE	smalldatetime NULL,
	JobDescription		varchar(60) NULL,
	CompDescription		varchar(60) NULL,
	MonthYear			varchar(8) NULL
)

SELECT @setup_active = COALESCE( BILL_MEDIA_TYPE, 0 )
FROM dbo.AGENCY

		INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
				OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
				LINK_ID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
				MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL, BILL_STATUS, SETUP_COMPLETE, BILL_COOP_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, JOB_MEDIA_BILL_DATE,
				JobDescription, CompDescription )
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
				vmh.BILL_COOP_CODE, vmomrs.JOB_NUMBER, vmomrs.JOB_COMPONENT_NBR, jc.MEDIA_BILL_DATE,
				jl.JOB_DESC, jc.JOB_COMP_DESC
		   FROM dbo.V_BCC_MEDIA_ORDER_ACTIVE_REVISIONS vmomrs
	 INNER JOIN dbo.V_BCC_MEDIA_HDR vmh ON ( vmomrs.ORDER_NBR = vmh.ORDER_NBR )
	 INNER JOIN dbo.VENDOR v ON ( vmh.VN_CODE = v.VN_CODE )
	 INNER JOIN dbo.PRODUCT p ON ( vmh.CL_CODE = p.CL_CODE AND vmh.DIV_CODE = p.DIV_CODE AND vmh.PRD_CODE = p.PRD_CODE )
LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( vmh.MEDIA_TYPE = sc.SC_CODE )
LEFT OUTER JOIN dbo.CAMPAIGN c ON ( vmh.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON vmomrs.JOB_NUMBER = jc.JOB_NUMBER AND vmomrs.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
LEFT OUTER JOIN dbo.JOB_LOG jl ON vmomrs.JOB_NUMBER = jl.JOB_NUMBER
	 INNER JOIN dbo.BCC_ORDER_LINE bol ON vmomrs.ORDER_NBR = bol.ORDER_NBR AND vmomrs.LINE_NBR = bol.LINE_NBR AND bol.BCC_ID = @BillingCommandCenterID 
		  WHERE vmh.MEDIA_FROM IN ( 'Mag2', 'News2', 'Internet', 'Outdoor', 'Radio2', 'TV2' )

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
		   HEADLINE = md.HEADLINE 
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
		   HEADLINE = nd.HEADLINE 
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
		   HEADLINE = id.HEADLINE 
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
		   HEADLINE = od.HEADLINE 
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
		   MonthYear = SUBSTRING(UPPER(DateName( month , DateAdd( month , rd.MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(rd.YEAR_NBR as varchar(4))
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
		   MonthYear = SUBSTRING(UPPER(DateName( month , DateAdd( month , td.MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(td.YEAR_NBR as varchar(4))
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

--CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_brdcast_summary] @order_number_in integer, @rt_flag_in varchar(10), @brdcast_month_in varchar(10), 
IF @bypass_legacy = 0
BEGIN

	DECLARE @brdcast_summary TABLE (
		ROW_TYPE		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CL_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
		DIV_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
		PRD_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
		ORDER_NBR		integer NOT NULL,
		BRDCAST_MONTH	smalldatetime NULL,
		LINE_NBR		integer NULL,
		REV_NBR			smallint NULL,
		OFFICE_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_IDENTIFIER	integer NULL,
		CMP_NAME		varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MARKET_CODE		varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		VN_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
		VN_NAME			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
		LINK_ID			integer NULL,
		CLIENT_PO		varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		BUYER			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MAX_REV			integer NULL,
		ORDER_DESC		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MEDIA_TYPE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		SC_DESC			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MEDIA_FROM		varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		ORDER_DATE		smalldatetime NULL,
		INSERTION_DATE	smalldatetime NULL,
		CLOSE_DATE		smalldatetime NULL,
		DATE_TO_BILL	smalldatetime NULL,
		BILLING_USER	varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		NET_AMT			decimal(15,2) NULL,
		COMM_AMT		decimal(15,2) NULL,
		REBATE_AMT		decimal(15,2) NULL,
		ADDTL_CHARGES	decimal(15,2) NULL,
		DISCOUNT_AMT	decimal(15,2) NULL,
		NET_CHARGES		decimal(15,2) NULL,
		VENDOR_TAX		decimal(15,2) NULL,
		RESALE_TAX		decimal(15,2) NULL,
		BILLABLE_AMT	decimal(15,2) NULL,
		BILLED_AMT		decimal(15,2) NULL,
		UNBILLED_AMT	decimal(15,2) NULL,
		AP_POSTED_AMT	decimal(15,2) NULL,
		SELECTED_AMT	decimal(15,2) NULL,
		BILL_STATUS		smallint NULL,
		BILL_TYPE		smallint NULL,
		ORDER_PROC_CTL	smallint NULL,
		SETUP_COMPLETE	smallint NULL,
		JOB_NUMBER			int NULL,
		JOB_COMPONENT_NBR	smallint NULL,
		LINK_DETID			int NULL,
		BILL_COOP_CODE		varchar(6) NULL
	)

	INSERT INTO @brdcast_summary ( ROW_TYPE, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR, REV_NBR, 
		BRDCAST_MONTH, OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, LINK_ID, 
		CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, MEDIA_FROM, ORDER_DATE, 
		ORDER_PROC_CTL, BILL_STATUS, SETUP_COMPLETE, BILLING_USER, BILL_TYPE, CLOSE_DATE, 
		NET_AMT, COMM_AMT, REBATE_AMT, DISCOUNT_AMT, NET_CHARGES, VENDOR_TAX, RESALE_TAX, 
		BILLABLE_AMT, BILLED_AMT, UNBILLED_AMT, SELECTED_AMT, AP_POSTED_AMT, JOB_NUMBER, JOB_COMPONENT_NBR, LINK_DETID, BILL_COOP_CODE )
	SELECT 'D', rh.CL_CODE, rh.DIV_CODE, rh.PRD_CODE, rh.ORDER_NBR, vrd.LINE_NBR, vrd.REV_NBR, 
		CAST( CAST( vrd.MONTH_IND AS varchar(2)) + '/01/' + CAST( vrd.BRDCAST_YEAR AS varchar(4)) AS smalldatetime ),
		p.OFFICE_CODE, rh.CMP_IDENTIFIER, c.CMP_NAME, rh.MARKET_CODE, rh.VN_CODE, v.VN_NAME, rh.LINK_ID, 
		rh.CLIENT_PO, rh.BUYER, NULL AS MAX_REV, rh.ORDER_DESC, rh.MEDIA_TYPE, sc.SC_DESCRIPTION, 
		'Radio', rh.ORDER_DATE, rh.ORD_PROCESS_CONTRL, COALESCE( p.PRD_RADIO_PRE_POST, 1 ), 
		CASE WHEN ( @setup_active = 1 ) THEN COALESCE( p.RADIO_SETUP_COMPLETE, 0 ) ELSE NULL END,
		rd.BILLING_USER, rh.BILL_TYPE_FLAG, rd.CLOSE_DATE, COALESCE( vrd.LINE_NET, 0.00 ), 
		COALESCE( vrd.COMM_AMT, 0.00 ), COALESCE( vrd.REBATE_AMT, 0.00 ), COALESCE( vrd.DISCOUNT, 0.00 ), 
		COALESCE( rd.NETCHARGES, 0.00 ), COALESCE( vrd.VENDOR_TAX, 0.00 ), 
		COALESCE( vrd.STATE_TAX , 0.00 ) + COALESCE( vrd.COUNTY_TAX, 0.00 ) + COALESCE( vrd.CITY_TAX, 0.00 ),
		COALESCE( vrd.BILLING_AMT, 0.00 ), 
		CASE WHEN vrd.AR_INV_NBR IS NULL THEN 0.00 ELSE COALESCE( vrd.BILLING_AMT, 0.00 ) END,
		CASE WHEN vrd.AR_INV_NBR IS NULL THEN COALESCE( vrd.BILLING_AMT, 0.00 ) ELSE 0.00 END,
		CASE WHEN vrd.BILLING_USER IS NULL THEN 0.00 ELSE COALESCE( rd.LINE_TOTAL, 0.00 ) END,
		( SELECT COALESCE( SUM( COALESCE( ap.LINE_TOTAL, 0.00 )), 0.00 ) 
			FROM dbo.AP_RADIO ap
			WHERE ap.ORDER_NBR = vrd.ORDER_NBR
				AND ap.BRDCAST_MONTH = vrd.MONTH_SHORT
				AND ap.BRDCAST_YEAR = vrd.BRDCAST_YEAR
				AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
		rd.JOB_NUMBER,
		rd.JOB_COMPONENT_NBR,
		rd.LINK_DETID,
		rh.BILL_COOP_CODE
	FROM dbo.V_RADIO_DETAIL1 vrd
		INNER JOIN dbo.RADIO_DETAIL1 rd ON vrd.ORDER_NBR = rd.ORDER_NBR 
										AND vrd.LINE_NBR = rd.LINE_NBR
										AND vrd.REV_NBR = rd.REV_NBR
										AND vrd.SEQ_NBR = rd.SEQ_NBR
										AND vrd.BRDCAST_YEAR = rd.BRDCAST_YEAR
		INNER JOIN dbo.RADIO_HEADER rh ON ( vrd.ORDER_NBR = rh.ORDER_NBR ) AND ( vrd.REV_NBR = rh.REV_NBR )
		INNER JOIN dbo.VENDOR v ON ( rh.VN_CODE = v.VN_CODE )
		INNER JOIN dbo.PRODUCT p ON ( rh.CL_CODE = p.CL_CODE AND rh.DIV_CODE = p.DIV_CODE AND rh.PRD_CODE = p.PRD_CODE )
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( rh.MEDIA_TYPE = sc.SC_CODE )
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( rh.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
		INNER JOIN dbo.BCC_ORDER_BRDCAST bob ON bob.ORDER_NBR = vrd.ORDER_NBR AND bob.BRDCAST_YEAR = vrd.BRDCAST_YEAR 
											AND bob.BRDCAST_MONTH = vrd.MONTH_IND AND bob.BCC_ID = @BillingCommandCenterID 

	if @debug = 1 
		select getdate() AS 'after 1st legacy insert'
		
	INSERT INTO @brdcast_summary ( ROW_TYPE, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR, REV_NBR, 
		BRDCAST_MONTH, OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, LINK_ID, 
		CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, MEDIA_FROM, ORDER_DATE, 
		ORDER_PROC_CTL, BILL_STATUS, SETUP_COMPLETE, BILLING_USER, BILL_TYPE, CLOSE_DATE, 
		NET_AMT, COMM_AMT, REBATE_AMT, DISCOUNT_AMT, NET_CHARGES, VENDOR_TAX, RESALE_TAX, 
		BILLABLE_AMT, BILLED_AMT, UNBILLED_AMT, SELECTED_AMT, AP_POSTED_AMT, JOB_NUMBER, JOB_COMPONENT_NBR, LINK_DETID, BILL_COOP_CODE )
		SELECT 'D', th.CL_CODE, th.DIV_CODE, th.PRD_CODE, th.ORDER_NBR, vtd.LINE_NBR, vtd.REV_NBR, 
		CAST( CAST( vtd.MONTH_IND AS varchar(2)) + '/01/' + CAST( vtd.BRDCAST_YEAR AS varchar(4)) AS smalldatetime ),
		p.OFFICE_CODE, th.CMP_IDENTIFIER, c.CMP_NAME, th.MARKET_CODE, th.VN_CODE, v.VN_NAME, th.LINK_ID, 
		th.CLIENT_PO, th.BUYER, NULL AS MAX_REV, th.ORDER_DESC, th.MEDIA_TYPE, sc.SC_DESCRIPTION, 
		'TV', th.ORDER_DATE, th.ORD_PROCESS_CONTRL, COALESCE( p.PRD_TV_PRE_POST, 1 ), 
		CASE WHEN ( @setup_active = 1 ) THEN COALESCE( p.TV_SETUP_COMPLETE, 0 ) ELSE NULL END,
		td.BILLING_USER, th.BILL_TYPE_FLAG, td.CLOSE_DATE, COALESCE( vtd.LINE_NET, 0.00 ), 
		COALESCE( vtd.COMM_AMT, 0.00 ), COALESCE( vtd.REBATE_AMT, 0.00 ), COALESCE( vtd.DISCOUNT, 0.00 ), 
		COALESCE( td.NETCHARGES, 0.00 ), COALESCE( vtd.VENDOR_TAX, 0.00 ), 
		COALESCE( vtd.STATE_TAX , 0.00 ) + COALESCE( vtd.COUNTY_TAX, 0.00 ) + COALESCE( vtd.CITY_TAX, 0.00 ),
		COALESCE( vtd.BILLING_AMT, 0.00 ), 
		CASE WHEN vtd.AR_INV_NBR IS NULL THEN 0.00 ELSE COALESCE( vtd.BILLING_AMT, 0.00 ) END,
		CASE WHEN vtd.AR_INV_NBR IS NULL THEN COALESCE( vtd.BILLING_AMT, 0.00 ) ELSE 0.00 END,
		CASE WHEN vtd.BILLING_USER IS NULL THEN 0.00 ELSE COALESCE( td.LINE_TOTAL, 0.00 ) END,
		( SELECT COALESCE( SUM( COALESCE( ap.LINE_TOTAL, 0.00 )), 0.00 ) 
			FROM dbo.AP_TV ap 
			WHERE ap.ORDER_NBR = vtd.ORDER_NBR
			AND ap.BRDCAST_MONTH = vtd.MONTH_SHORT
			AND ap.BRDCAST_YEAR = vtd.BRDCAST_YEAR
			AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )),
		td.JOB_NUMBER,
		td.JOB_COMPONENT_NBR,
		td.LINK_DETID,
		th.BILL_COOP_CODE
	FROM dbo.V_TV_DETAIL1 vtd
		INNER JOIN dbo.TV_DETAIL1 td ON vtd.ORDER_NBR = td.ORDER_NBR 
									AND vtd.LINE_NBR = td.LINE_NBR 
									AND vtd.REV_NBR = td.REV_NBR		
									AND vtd.SEQ_NBR = td.SEQ_NBR
									AND vtd.BRDCAST_YEAR = td.BRDCAST_YEAR
		INNER JOIN dbo.TV_HEADER th ON ( vtd.ORDER_NBR = th.ORDER_NBR ) AND ( vtd.REV_NBR = th.REV_NBR )
		INNER JOIN dbo.VENDOR v ON ( th.VN_CODE = v.VN_CODE ) 
		INNER JOIN dbo.PRODUCT p ON ( th.CL_CODE = p.CL_CODE AND th.DIV_CODE = p.DIV_CODE AND th.PRD_CODE = p.PRD_CODE ) 
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( th.MEDIA_TYPE = sc.SC_CODE ) 
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( th.CMP_IDENTIFIER = c.CMP_IDENTIFIER ) 
		INNER JOIN dbo.BCC_ORDER_BRDCAST bob ON bob.ORDER_NBR = vtd.ORDER_NBR AND bob.BRDCAST_YEAR = vtd.BRDCAST_YEAR 
						AND bob.BRDCAST_MONTH = vtd.MONTH_IND AND bob.BCC_ID = @BillingCommandCenterID                        

	if @debug = 1 
		select getdate() AS 'after 2nd legacy insert'
		      
--	-- Summarized by order, broadcast month
	INSERT INTO @brdcast_summary ( ROW_TYPE, CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR, BRDCAST_MONTH, MEDIA_FROM, 
		VN_CODE, VN_NAME, BILL_STATUS, SETUP_COMPLETE, OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, 
		LINK_ID, CLIENT_PO, BUYER, ORDER_DESC, MEDIA_TYPE, SC_DESC, ORDER_DATE, ORDER_PROC_CTL, BILLING_USER, 
		BILL_TYPE, CLOSE_DATE, NET_CHARGES, NET_AMT, COMM_AMT, REBATE_AMT, DISCOUNT_AMT, VENDOR_TAX, RESALE_TAX, 
		BILLABLE_AMT, BILLED_AMT, UNBILLED_AMT, SELECTED_AMT, AP_POSTED_AMT, JOB_NUMBER, JOB_COMPONENT_NBR, LINK_DETID, BILL_COOP_CODE )
	SELECT 'S', BS.CL_CODE, BS.DIV_CODE, BS.PRD_CODE, BS.ORDER_NBR, BS.LINE_NBR, BS.BRDCAST_MONTH, BS.MEDIA_FROM, 
		( SELECT TOP 1 VN_CODE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC ),
		( SELECT TOP 1 VN_NAME FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC ),
		BS.BILL_STATUS, BS.SETUP_COMPLETE, 
		( SELECT TOP 1 OFFICE_CODE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 CMP_IDENTIFIER FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 CMP_NAME FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 MARKET_CODE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 LINK_ID FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 CLIENT_PO FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 BUYER FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 ORDER_DESC FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 MEDIA_TYPE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 SC_DESC FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 ORDER_DATE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 ORDER_PROC_CTL FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 BILLING_USER FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 BILL_TYPE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 CLOSE_DATE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),										
		( SELECT TOP 1 NET_CHARGES FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		COALESCE( SUM( BS.NET_AMT ), 0.00 ), COALESCE( SUM( BS.COMM_AMT ), 0.00 ), COALESCE( SUM( BS.REBATE_AMT ), 0.00 ), COALESCE( SUM( BS.DISCOUNT_AMT ), 0.00 ), 
		COALESCE( SUM( BS.VENDOR_TAX ), 0.00 ), COALESCE( SUM( BS.RESALE_TAX ), 0.00 ), COALESCE( SUM( BS.BILLABLE_AMT ), 0.00 ), 
		COALESCE( SUM( BS.BILLED_AMT ), 0.00 ), COALESCE( SUM( BS.UNBILLED_AMT ), 0.00 ), COALESCE( SUM( BS.SELECTED_AMT ), 0.00 ),
		( SELECT TOP 1 AP_POSTED_AMT FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 JOB_NUMBER FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 JOB_COMPONENT_NBR FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 LINK_DETID FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC ),
		( SELECT TOP 1 BILL_COOP_CODE FROM @brdcast_summary WHERE ROW_TYPE = 'D' AND ORDER_NBR = BS.ORDER_NBR AND LINE_NBR = BS.LINE_NBR ORDER BY ORDER_NBR DESC, REV_NBR DESC, LINE_NBR DESC, BRDCAST_MONTH DESC )
	FROM @brdcast_summary BS
	WHERE BS.ROW_TYPE = 'D'
	GROUP BY BS.CL_CODE, BS.DIV_CODE, BS.PRD_CODE, BS.ORDER_NBR, BS.LINE_NBR, BS.BRDCAST_MONTH, BS.MEDIA_FROM, BS.BILL_STATUS, BS.SETUP_COMPLETE 

	if @debug = 1 
		select getdate() AS 'after legacy sum'
END

	 SELECT [ClientCode] = ms.CL_CODE,
			[DivisionCode] = ms.DIV_CODE,
			[ProductCode] = ms.PRD_CODE,
			[OrderNumber] = ms.ORDER_NBR,
			[LineNumber] = ms.LINE_NBR,
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
							--WHEN 'Mag' THEN 'Magazine (Legacy)'
							--WHEN 'News' THEN 'Newspaper (Legacy)'
							--WHEN 'Radio' THEN 'Radio (Legacy)'
							--WHEN 'TV' THEN 'TV (Legacy)'
							END,
			[OrderDate] = ORDER_DATE,
			[InsertionDate] = INSERTION_DATE,
			[BroadcastMonth] = BRDCAST_MONTH,
			[CloseDate] = CLOSE_DATE,
			[DateToBill] = DATE_TO_BILL,
			[BillingUser] = BILLING_USER,
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
			[BillStatus] = CAST(COALESCE(BILL_STATUS, 1) as int),
			[IsSetupComplete] = SETUP_COMPLETE,
			[OrderProcessControl] = JPC.JOB_PROCESS_DESC,
			[MonthYear] = CASE WHEN MEDIA_FROM IN ('Radio2','TV2') THEN ms.MonthYear
							   WHEN INSERTION_DATE IS NOT NULL THEN UPPER(convert(char(3), INSERTION_DATE, 0)) + ' ' + CAST(YEAR(INSERTION_DATE) as varchar(4))
							   ELSE NULL END,
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
			[Headline] = ms.HEADLINE,
			[Programming] = ms.PROGRAMMING,
			[JobMediaDateToBill] = ms.JOB_MEDIA_BILL_DATE,
			[JobDescription] = ms.JobDescription,
			[CompDescription] = ms.CompDescription,
			[HasBillingApprovalStatus] = CASE WHEN os.[ApprovedDateBy] IS NOT NULL THEN CAST(1 as bit) ELSE CAST(0 as bit) END,
			[BillingApprovedDateBy] = os.[ApprovedDateBy]
	   FROM @media_summary ms
			INNER JOIN dbo.JOB_PROC_CONTROLS JPC ON ms.ORDER_PROC_CTL = JPC.JOB_PROCESS_CONTRL 
			LEFT OUTER JOIN dbo.OFFICE O ON ms.OFFICE_CODE = O.OFFICE_CODE
			LEFT OUTER JOIN dbo.CLIENT C ON ms.CL_CODE = C.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION D ON ms.CL_CODE = D.CL_CODE AND ms.DIV_CODE = D.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT P ON ms.CL_CODE = P.CL_CODE AND ms.DIV_CODE = P.DIV_CODE AND ms.PRD_CODE = P.PRD_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN CMP ON ms.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.MARKET M ON ms.MARKET_CODE = M.MARKET_CODE
			LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.INTERNET_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.MAGAZINE_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.NEWSPAPER_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.OUTDOOR_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.RADIO_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.TV_ORDER_STATUS
						) os ON os.ORDER_NBR = ms.ORDER_NBR AND os.LINE_NBR = ms.LINE_NBR AND ms.MAX_REV = os.REV_NBR AND os.[STATUS] = 11
			OPTION (RECOMPILE)
			
--UNION
			
-- SELECT bs.CL_CODE, bs.DIV_CODE, bs.PRD_CODE, bs.ORDER_NBR, bs.LINE_NBR, bs.REV_NBR,
--		bs.OFFICE_CODE, 
--		bs.CMP_IDENTIFIER, bs.CMP_NAME, bs.MEDIA_TYPE, bs.SC_DESC, bs.MARKET_CODE, bs.VN_CODE, bs.VN_NAME,
--		bs.LINK_ID, bs.CLIENT_PO, bs.BILL_COOP_CODE, bs.BUYER, bs.MAX_REV, bs.ORDER_DESC,
--		[MediaFrom] = CASE bs.MEDIA_FROM
--							WHEN 'Mag2' THEN 'Magazine'
--							WHEN 'News2' THEN 'Newspaper'
--							WHEN 'Internet' THEN 'Internet'
--							WHEN 'Outdoor' THEN 'Out of Home'
--							WHEN 'Radio2' THEN 'Radio'
--							WHEN 'TV2' THEN 'TV'
--							WHEN 'Mag' THEN 'Magazine (Legacy)'
--							WHEN 'News' THEN 'Newspaper (Legacy)'
--							WHEN 'Radio' THEN 'Radio (Legacy)'
--							WHEN 'TV' THEN 'TV (Legacy)'
--							END,
--		bs.ORDER_DATE, bs.INSERTION_DATE,
--		bs.BRDCAST_MONTH, bs.CLOSE_DATE, bs.DATE_TO_BILL, bs.BILLING_USER, bs.NET_AMT, bs.COMM_AMT, bs.REBATE_AMT,
--		bs.ADDTL_CHARGES, bs.DISCOUNT_AMT, bs.NET_CHARGES, bs.VENDOR_TAX, bs.RESALE_TAX, bs.BILLABLE_AMT, bs.BILLED_AMT,
--		CAST(0 as bit) AS HAS_UNBILLED, bs.UNBILLED_AMT, bs.AP_POSTED_AMT, bs.SELECTED_AMT,
--		CASE WHEN COALESCE(bs.UNBILLED_AMT, 0) < 0 THEN CAST(1 as int) ELSE CAST(COALESCE(BILL_STATUS, 1) as int) END, 
--		bs.SETUP_COMPLETE,
--		JPC.JOB_PROCESS_DESC,
--		CASE WHEN BRDCAST_MONTH IS NOT NULL THEN UPPER(convert(char(3), bs.BRDCAST_MONTH, 0)) + ' ' + CAST(YEAR(BRDCAST_MONTH) as varchar(4)) ELSE NULL END,
--		CASE BILL_TYPE 
--			WHEN 1 THEN 'Comm Only'
--			WHEN 2 THEN 'Net'
--			WHEN 3 THEN 'Gross'
--			ELSE '' END,
--		[OfficeDescription] = O.OFFICE_NAME,
--		[ClientName] = C.CL_NAME,
--		[DivisionName] = D.DIV_NAME,
--		[ProductDescription] = P.PRD_DESCRIPTION,
--		[CampaignCode] = CMP.CMP_CODE,
--		[MarketDescription] = M.MARKET_DESC,
--		[JobNumber] = bs.JOB_NUMBER,
--		[JobComponentNumber] = bs.JOB_COMPONENT_NBR,
--		[LinkLineID] = bs.LINK_DETID
--   FROM @brdcast_summary bs
--	INNER JOIN dbo.JOB_PROC_CONTROLS JPC ON bs.ORDER_PROC_CTL = JPC.JOB_PROCESS_CONTRL 
--	LEFT OUTER JOIN dbo.OFFICE O ON bs.OFFICE_CODE = O.OFFICE_CODE
--	LEFT OUTER JOIN dbo.CLIENT C ON bs.CL_CODE = C.CL_CODE
--	LEFT OUTER JOIN dbo.DIVISION D ON bs.CL_CODE = D.CL_CODE AND bs.DIV_CODE = D.DIV_CODE
--	LEFT OUTER JOIN dbo.PRODUCT P ON bs.CL_CODE = P.CL_CODE AND bs.DIV_CODE = P.DIV_CODE AND bs.PRD_CODE = P.PRD_CODE
--	LEFT OUTER JOIN dbo.CAMPAIGN CMP ON bs.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER
--	LEFT OUTER JOIN dbo.MARKET M ON bs.MARKET_CODE = M.MARKET_CODE
--  WHERE bs.ROW_TYPE = 'S' OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'finish'
		
END