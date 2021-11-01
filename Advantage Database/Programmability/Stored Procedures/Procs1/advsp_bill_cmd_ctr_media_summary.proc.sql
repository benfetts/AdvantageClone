CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_media_summary] @order_number_in integer, @line_number_in smallint, 
	@incl_unbilled_only bit, @ret_val integer OUTPUT
AS

SET NOCOUNT ON

DECLARE @link_id integer, @insertion_date smalldatetime, @brdcast_month smalldatetime, @close_date smalldatetime
DECLARE @bill_status smallint, @bill_type smallint, @media_from varchar(8), @setup_active smallint
DECLARE @net_amt decimal(15,2), @comm_amt decimal(15,2), @rebate_amt decimal(15,2), @addtl_charges decimal(15,2)
DECLARE @discount_amt decimal(15,2), @net_charges decimal(15,2), @vendor_tax decimal(15,2), @resale_tax decimal(15,2)
DECLARE @billable_amt decimal(15,2), @billed_amt decimal(15,2), @unbilled_amt decimal(15,2), @ap_posted_amt decimal(15,2)
DECLARE @billing_coop_code varchar(6)

SELECT @ret_val = 0

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
	BILL_COOP_CODE	varchar(6) NULL )

	SELECT @setup_active = ( SELECT COALESCE( BILL_MEDIA_TYPE, 0 )  
	                           FROM dbo.AGENCY )   
	
		INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
				OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
				LINK_ID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
				MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL, BILL_STATUS, SETUP_COMPLETE, BILL_COOP_CODE )
		 SELECT vmh2.CL_CODE, vmh2.DIV_CODE, vmh2.PRD_CODE, vmomrs.ORDER_NBR, vmomrs.LINE_NBR, 
				p.OFFICE_CODE, vmh2.CMP_IDENTIFIER, c.CMP_NAME, vmh2.MARKET_CODE, vmh2.VN_CODE,
				v.VN_NAME, vmh.LINK_ID, vmh2.CLIENT_PO, vmh2.BUYER, vmomrs.MAX_REV, vmh.ORDER_DESC, 
				vmh2.MEDIA_TYPE, sc.SC_DESCRIPTION, vmh.MEDIA_FROM, vmh2.ORDER_DATE, 
				vmh2.ORD_PROCESS_CONTRL,
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
				vmh2.BILL_COOP_CODE 
		   FROM dbo.V_MEDIA_ORDER_MAX_REV_SEQ vmomrs 
	 INNER JOIN dbo.V_MEDIA_HDR vmh ON ( vmomrs.ORDER_NBR = vmh.ORDER_NBR ) 
	 INNER JOIN dbo.V_MEDIA_HDR2 vmh2 ON ( vmomrs.ORDER_NBR = vmh2.ORDER_NBR )
	 INNER JOIN dbo.VENDOR v ON ( vmh.VN_CODE = v.VN_CODE ) 
	 INNER JOIN dbo.PRODUCT p ON ( vmh.CL_CODE = p.CL_CODE AND vmh.DIV_CODE = p.DIV_CODE AND vmh.PRD_CODE = p.PRD_CODE ) 
LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( vmh2.MEDIA_TYPE = sc.SC_CODE ) 
LEFT OUTER JOIN dbo.CAMPAIGN c ON ( vmh2.CMP_IDENTIFIER = c.CMP_IDENTIFIER )		 
		  WHERE vmomrs.ORDER_NBR = @order_number_in
			AND vmomrs.LINE_NBR = @line_number_in
			AND vmh.MEDIA_FROM IN ( 'Mag2', 'News2', 'Internet', 'Outdoor', 'Radio2', 'TV2' )   

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
		   DATE_TO_BILL = md.DATE_TO_BILL
	  FROM @media_summary ms 
			INNER JOIN dbo.MAGAZINE_DETAIL md
					ON ( ms.ORDER_NBR = md.ORDER_NBR )
				   AND ( ms.LINE_NBR = md.LINE_NBR )
				   AND ( md.ACTIVE_REV = 1 )
				   AND ( ms.MEDIA_FROM = 'Mag' OR ms.MEDIA_FROM = 'Mag2' )
	   
	UPDATE @media_summary
	   SET NET_AMT = COALESCE( md.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( md.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( md.STATE_AMT, 0.00 ) + COALESCE( md.COUNTY_AMT, 0.00 ) + COALESCE( md.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( md.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( md.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( md.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( md.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( md.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = ( CASE md.BILL_TYPE_FLAG 
								WHEN 1 THEN COALESCE( md.COMM_AMT, 0.00 ) + COALESCE( md.REBATE_AMT, 0.00 ) 
								ELSE COALESCE( md.BILLING_AMT, 0.00 ) 
		                    END )
	  FROM @media_summary ms 
			INNER JOIN dbo.MAGAZINE_DETAIL md
					ON ( ms.ORDER_NBR = md.ORDER_NBR )
				   AND ( ms.LINE_NBR = md.LINE_NBR )
				   AND ( md.ACTIVE_REV = 1 )
  				   AND ( md.LINE_CANCELLED = 0 OR md.LINE_CANCELLED IS NULL )
				   AND ( ms.MEDIA_FROM = 'Mag' OR ms.MEDIA_FROM = 'Mag2' )

 UPDATE @media_summary
    SET HAS_UNBILLED = 1
   FROM @media_summary ms
  WHERE EXISTS( SELECT * 
				  FROM dbo.MAGAZINE_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Mag2' )

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.MAGAZINE_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms
  WHERE	( ms.MEDIA_FROM = 'Mag2' )
    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 ) 

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
						 FROM dbo.MAGAZINE_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms
  WHERE	( ms.MEDIA_FROM = 'Mag2' )
    AND ( ms.BILL_TYPE = 1 ) 

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )), 0.00 ) 
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
		   DATE_TO_BILL = nd.DATE_TO_BILL
	  FROM @media_summary ms 
INNER JOIN dbo.NEWSPAPER_DETAIL nd
	    ON ( ms.ORDER_NBR = nd.ORDER_NBR )
	   AND ( ms.LINE_NBR = nd.LINE_NBR )
	   AND ( nd.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'News' OR ms.MEDIA_FROM = 'News2' ) 

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( nd.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( nd.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( nd.STATE_AMT, 0.00 ) + COALESCE( nd.COUNTY_AMT, 0.00 ) + COALESCE( nd.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( nd.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( nd.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( nd.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( nd.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( nd.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = ( CASE nd.BILL_TYPE_FLAG 
								WHEN 1 THEN COALESCE( nd.COMM_AMT, 0.00 ) + COALESCE( nd.REBATE_AMT, 0.00 ) 
								ELSE COALESCE( nd.BILLING_AMT, 0.00 ) 
		                    END )
	  FROM @media_summary ms 
INNER JOIN dbo.NEWSPAPER_DETAIL nd
	    ON ( ms.ORDER_NBR = nd.ORDER_NBR )
	   AND ( ms.LINE_NBR = nd.LINE_NBR )
	   AND ( nd.ACTIVE_REV = 1 )
  	   AND ( nd.LINE_CANCELLED = 0 OR nd.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'News' OR ms.MEDIA_FROM = 'News2' )
	   
 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT * 
				  FROM dbo.NEWSPAPER_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'News2' )

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.NEWSPAPER_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'News2' )
    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )
    
 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
						 FROM dbo.NEWSPAPER_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'News2' )
    AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )), 0.00 ) 
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
		   DATE_TO_BILL = id.DATE_TO_BILL
	  FROM @media_summary ms 
INNER JOIN dbo.INTERNET_DETAIL id
	    ON ( ms.ORDER_NBR = id.ORDER_NBR )
	   AND ( ms.LINE_NBR = id.LINE_NBR )
	   AND ( id.ACTIVE_REV = 1 )	  
	   AND ( ms.MEDIA_FROM = 'Internet' ) 

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( id.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( id.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( id.STATE_AMT, 0.00 ) + COALESCE( id.COUNTY_AMT, 0.00 ) + COALESCE( id.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( id.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( id.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( id.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( id.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( id.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = ( CASE id.BILL_TYPE_FLAG 
								WHEN 1 THEN COALESCE( id.COMM_AMT, 0.00 ) + COALESCE( id.REBATE_AMT, 0.00 ) 
								ELSE COALESCE( id.BILLING_AMT, 0.00 ) 
		                    END )
	  FROM @media_summary ms 
INNER JOIN dbo.INTERNET_DETAIL id
	    ON ( ms.ORDER_NBR = id.ORDER_NBR )
	   AND ( ms.LINE_NBR = id.LINE_NBR )
	   AND ( id.ACTIVE_REV = 1 )	  
  	   AND ( id.LINE_CANCELLED = 0 OR id.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Internet' ) 

 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT * 
				  FROM dbo.INTERNET_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Internet' )

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.INTERNET_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Internet' )
    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )
  
 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
						 FROM dbo.INTERNET_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Internet' )
    AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )), 0.00 ) 
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
		   DATE_TO_BILL = od.DATE_TO_BILL
	  FROM @media_summary ms 
INNER JOIN dbo.OUTDOOR_DETAIL od
	    ON ( ms.ORDER_NBR = od.ORDER_NBR )
	   AND ( ms.LINE_NBR = od.LINE_NBR )
	   AND ( od.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'Outdoor' ) 
	 
	UPDATE @media_summary
	   SET NET_AMT = COALESCE( od.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( od.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( od.STATE_AMT, 0.00 ) + COALESCE( od.COUNTY_AMT, 0.00 ) + COALESCE( od.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( od.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( od.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( od.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( od.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( od.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = ( CASE od.BILL_TYPE_FLAG 
								WHEN 1 THEN COALESCE( od.COMM_AMT, 0.00 ) 
								ELSE COALESCE( od.BILLING_AMT, 0.00 ) 
		                    END )
	  FROM @media_summary ms 
INNER JOIN dbo.OUTDOOR_DETAIL od
	    ON ( ms.ORDER_NBR = od.ORDER_NBR )
	   AND ( ms.LINE_NBR = od.LINE_NBR )
	   AND ( od.ACTIVE_REV = 1 )
  	   AND ( od.LINE_CANCELLED = 0 OR od.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Outdoor' ) 

 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT * 
				  FROM dbo.OUTDOOR_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Outdoor' )

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.OUTDOOR_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Outdoor' )
    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )
      
 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
						 FROM dbo.OUTDOOR_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Outdoor' )
    AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )), 0.00 ) 
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
		   DATE_TO_BILL = rd.DATE_TO_BILL
	  FROM @media_summary ms 
INNER JOIN dbo.RADIO_DETAIL rd
	    ON ( ms.ORDER_NBR = rd.ORDER_NBR )
	   AND ( ms.LINE_NBR = rd.LINE_NBR )
	   AND ( rd.ACTIVE_REV = 1 )	  
	   AND ( ms.MEDIA_FROM = 'Radio2' ) 

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( rd.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( rd.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( rd.STATE_AMT, 0.00 ) + COALESCE( rd.COUNTY_AMT, 0.00 ) + COALESCE( rd.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( rd.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( rd.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( rd.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( rd.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( rd.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = ( CASE rd.BILL_TYPE_FLAG 
								WHEN 1 THEN COALESCE( rd.COMM_AMT, 0.00 ) + COALESCE( rd.REBATE_AMT, 0.00 ) 
								ELSE COALESCE( rd.BILLING_AMT, 0.00 ) 
		                    END )
	  FROM @media_summary ms 
INNER JOIN dbo.RADIO_DETAIL rd
	    ON ( ms.ORDER_NBR = rd.ORDER_NBR )
	   AND ( ms.LINE_NBR = rd.LINE_NBR )
	   AND ( rd.ACTIVE_REV = 1 )	  
  	   AND ( rd.LINE_CANCELLED = 0 OR rd.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Radio2' ) 

 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT * 
				  FROM dbo.RADIO_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'Radio2' )

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.RADIO_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Radio2' )
    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )
  
 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
						 FROM dbo.RADIO_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'Radio2' )
    AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
	SET AP_POSTED_AMT = 0.00 /*( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )), 0.00 ) 
							FROM dbo.AP_RADIO ap 
						   WHERE #media_summary.ORDER_NBR = ap.ORDER_NBR
							 AND #media_summary.LINE_NBR = ap.ORDER_LINE_NBR
							 AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 ))*/,
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
		   DATE_TO_BILL = td.DATE_TO_BILL
	  FROM @media_summary ms 
INNER JOIN dbo.TV_DETAIL td
	    ON ( ms.ORDER_NBR = td.ORDER_NBR )
	   AND ( ms.LINE_NBR = td.LINE_NBR )
	   AND ( td.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'TV2' ) 
	 
	UPDATE @media_summary
	   SET NET_AMT = COALESCE( td.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( td.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( td.STATE_AMT, 0.00 ) + COALESCE( td.COUNTY_AMT, 0.00 ) + COALESCE( td.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( td.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( td.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( td.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( td.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( td.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = ( CASE td.BILL_TYPE_FLAG 
								WHEN 1 THEN COALESCE( td.COMM_AMT, 0.00 ) 
								ELSE COALESCE( td.BILLING_AMT, 0.00 ) 
		                    END )
	  FROM @media_summary ms 
INNER JOIN dbo.TV_DETAIL td
	    ON ( ms.ORDER_NBR = td.ORDER_NBR )
	   AND ( ms.LINE_NBR = td.LINE_NBR )
	   AND ( td.ACTIVE_REV = 1 )
  	   AND ( td.LINE_CANCELLED = 0 OR td.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'TV2' ) 

 UPDATE @media_summary	 
    SET HAS_UNBILLED = 1
   FROM @media_summary ms 
  WHERE EXISTS( SELECT * 
				  FROM dbo.TV_DETAIL d 
				 WHERE d.ORDER_NBR = ms.ORDER_NBR 
				   AND d.LINE_NBR = ms.LINE_NBR
				   AND d.AR_INV_NBR IS NULL 
				   AND ( d.LINE_CANCELLED = 0 OR d.LINE_CANCELLED IS NULL ))
    AND	( ms.MEDIA_FROM = 'TV2' )

 UPDATE @media_summary
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.TV_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'TV2' )
    AND ( ms.BILL_TYPE IS NULL OR ms.BILL_TYPE <> 1 )
      
 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( COALESCE( d.COMM_AMT, 0.00 ) + COALESCE( d.REBATE_AMT, 0.00 )), 0.00 )
						 FROM dbo.TV_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL ))
   FROM @media_summary ms 
  WHERE	( ms.MEDIA_FROM = 'TV2' )
    AND ( ms.BILL_TYPE = 1 )

 UPDATE @media_summary
    SET AP_POSTED_AMT = 0.00 /*( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )), 0.00 ) 
                            FROM dbo.AP_TV ap 
                           WHERE #media_summary.ORDER_NBR = ap.ORDER_NBR
                             AND #media_summary.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 ))*/,
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


 UPDATE @media_summary	 
    SET UNBILLED_AMT = COALESCE( BILLABLE_AMT - BILLED_AMT, 0.00 )
							 
	 SELECT CAST( '' AS varchar(1)) AS cc_row_hdr, CAST( '' AS varchar(1)) AS cc_row_type, 
			CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR, CAST( NULL AS integer ) AS REV_NBR,
			OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, SC_DESC, MARKET_CODE, VN_CODE, VN_NAME, 
			LINK_ID, CLIENT_PO, BUYER, MAX_REV,	ORDER_DESC, MEDIA_FROM, ORDER_DATE, INSERTION_DATE, 
			BRDCAST_MONTH, CLOSE_DATE, DATE_TO_BILL, BILLING_USER, NET_AMT, COMM_AMT, REBATE_AMT, 
			ADDTL_CHARGES, DISCOUNT_AMT, NET_CHARGES, VENDOR_TAX, RESALE_TAX, BILLABLE_AMT,	BILLED_AMT, 
			HAS_UNBILLED, UNBILLED_AMT, AP_POSTED_AMT, SELECTED_AMT, BILL_STATUS, SETUP_COMPLETE, BILL_TYPE, ORDER_PROC_CTL, 
			CAST( NULL AS integer ) AS cc_retrieved, CAST( '' AS varchar(100) ) AS cc_dummy2, 
			CAST( NULL AS integer ) AS cc_dummy3, CAST( NULL AS integer ) AS cc_dummy4,
			BILL_COOP_CODE 
	   FROM @media_summary
   GROUP BY CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR, OFFICE_CODE,
			CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, LINK_ID, CLIENT_PO,
			BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, MEDIA_FROM, ORDER_DATE,
			INSERTION_DATE, BRDCAST_MONTH, CLOSE_DATE, DATE_TO_BILL, BILLING_USER,
			NET_AMT, COMM_AMT, REBATE_AMT, ADDTL_CHARGES, DISCOUNT_AMT, NET_CHARGES,
			VENDOR_TAX, RESALE_TAX, BILLABLE_AMT, BILLED_AMT, HAS_UNBILLED, UNBILLED_AMT,
			AP_POSTED_AMT, SELECTED_AMT, BILL_STATUS, BILL_TYPE, ORDER_PROC_CTL, SETUP_COMPLETE, BILL_COOP_CODE 

IF ( @@ROWCOUNT <> 1 )
	SELECT @ret_val = -1

GO
