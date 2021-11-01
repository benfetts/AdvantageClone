
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.advsp_revise_order_process') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_revise_order_process]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_revise_order_process] 
	@user_id varchar(100), @action varchar(10), @order_type varchar(2), 
	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

/* FOR TESTING */
--DECLARE 	@user_id varchar(100), @action varchar(10), @order_type varchar(2), @ret_val integer , @ret_val_s varchar(max) 
--SELECT @user_id = 'SYSADM', @order_type = 'I'

/****************************************************************************************************

	advsp_revise_order_strata_ooh NEEDS TO BE REVIEWED FOR ANY CHANGE TO OUTDOOR_DETAIL PROCESSING 
	advsp_revise_order_media_mgr NEEDS TO BE REVIEWED FOR ANY CHANGES
	advsp_revise_order_process_legacy NEEDS TO BE REVIEWED FOR ANY CHANGES
	advsp_revise_order_copy NEEDS TO BE REVIEWED FOR ANY CHANGES

****************************************************************************************************/

/************************************************************************************************************
PJH 10/14/15 - Added update for PRINT_IMPORT_XREF.LAST_DATE_REVISED when exists
PJH 10/14/15 - Set Charge Descriptions as NULL if Charge Amt is NULL or Zero
PJH 10/19/15 - Verify @existing_vn_code = @vn_code before getting default reps
PJH 10/20/15 - Rebate PCT/AMT = 0 if Order Type is Net
PJH 11/17/15 - Added TV processing
PJH 11/25/15 - Added RADIO processing & tested TV/Radio
PJH 11/30/15 - Recalc Dates in case start date changes
PJH 12/01/15 - Fixed BRD_IMPORT_XREF references
PJH 01/11/16 - Updated calls to advtf_med_calc_cost_rate
PJH 01/19/16 - Added @sales_class_code to advtf_med_get_prd_defaults() parameters
					  Added /* uf_calc_comm_mu - Get reciprocal PCT */
PJH 01/22/16 - Added /* First date should be the Start Date */
PJH 01/26/16 - added --@remarks = CASE CAST([REMARKS] AS varchar (max)) WHEN '' THEN NULL ELSE [REMARKS] END - pending DB and media mgr mapping chnages
PJH 01/29/16 - Added COALESCE(PLAN VALUE, ORDER VALUE) to PLAN data assignments - If plan has value then use it
                    - Set @client_po = [CLIENT_PO] on New orders only
PJH 02/03/16 - Broke out SC from Product so it casn be last override
PJH 02/09/16 - @copy_area for OUTDOOR & INET, @o_type for OUTDOOR
PJH 03/10/16 - Changed @max_order_nbr from smallint to int
PJH 06/10/16 - @revised_flag based on existing Order/Line
PJH 07/14/16 - @ad_number - can only store 25 in Xref
PJH 08/24/16 - Change Print Hdr import for BUYER from PRINT_ORDER.[BUYER] to PRINT_ORDER.[BUYER_NAME]
MJC 11/22/16 - added missing where clause when setting @date4
PJH 12/30/16 - added @buyer_emp_code
PJH 01/09/17 - added [PRINT_ORDER].[UNITS] support for Newspaper in media planning
PJH 02/10/17 - added @buyer_emp_code to [advsp_revise_order_header] call
PJH 02/21/17 - Always calculate dates
PJH 03/03/17 - added @ad_number = [AD_NBR]
PJH 03/13/17 - Added AD Server columns
PJH 03/16/17 - 4674-1-25 - Lock certain fields on media order and line when Ad Server Placement ID exists on the order/line.
PJH 03/29/17 - Get New Vendor Markup so it casn be last override
PJH 08/18/17 - Added 'AW' - 'BROADCAST WORKSHEET'
PJH 09/15/17 - Changed @media_type_in to @media_interface_in IN SELECT
PJH 10/31/17 - Added update Worksheet LINE_NUMBER to TV/RADIO DETAIL table
PJH 12/12/17 - Update Internet Detail with PACKAGE_PARENT & PACKAGE_NAME
PJH 03/06/18 - Added VENDOR_ORDER_LINE to all BRDCAST plan related tables and SQL below
PJH 03/07/18 - Used to determine if a given date has ever been used for this order/line before clearing
PJH 04/02/18 - Adjust dates as needed - Clear if never any spots 
PJH 05/23/18 - Only set order_date = @date_time_w if header record does not exist (i.e. New Order)
PJH 05/03/18 - There is no support for legacy imports in this version
PJH 07/09/18 - clear remarks if empty string is passed 
PJH 09/07/18 - @modified_comments = @imported_from
PJH 11/19/18 - @line_nbr and @rev_nbr are set by Advantage
PJH 12/05/18 - Added INTERNET_PACKAGE_DETAIL table logic
PJH 12/06/18 - Added @line_market_code, @ad_server_id
PJH 03/06/19 - Added DISTINCT to @package_detail INSERT
PJH 03/06/19 - Updated CATCH error message
PJH 03/07/19 - Added [CIRCULATION] to PRINT_ORDER processing
PJH 03/22/19 - Added @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
PJH 04/13/19 - 261-1-1601 - Use Broadcast Week Start Date for @temp_date
PJH 06/01/20 - Added @channel = [MEDIA_CHANNEL_ID],	@tactic = [MEDIA_TACTIC_ID]
PJH 06/05/20 - Added AA.STATION_ID = C.STATION_ID for TV_DETAIL & RADIO_DETAIL
PJH 07/24/20 - Updated to use CSV for spots instead of space delimited 
PJH 08/14/20 - Added Placement Name and Addl Ad Size Codes to INTERNET_PACKAGE_DETAIL
PJH 01/26/21 - Expanded Rate and Pct precision
PJH 03/30/21 - Added 'MM' to all code with 'AW' (MEDIA_INTERFACE = 'AW' OR MEDIA_INTERFACE = 'MM')
************************************************************************************************************/

----all HEADER
--

DECLARE
	@order_nbr int,
	@order_desc varchar(40),
	@cl_code varchar(6),
	@div_code varchar(6),
	@prd_code varchar(6),
	@office_code varchar(4),
	@cmp_code varchar(6),
	@media_type varchar(6),
	@vn_code varchar(6),
	@vr_code varchar(4),
	@vr_code2 varchar(4),
	@client_po varchar(25),
	@client_ref varchar(60),
	@status varchar(3),
	@order_date smalldatetime,
	@buyer varchar(40),
	@order_comment varchar(MAX),
	@house_comment varchar(254),
	@pub_station smallint,
	@rep1 smallint,
	@rep2 smallint,
	@bill_coop_code varchar(6),
	@ord_process_contrl smallint,
	@market_code varchar(10),
	@start_date smalldatetime,
	@end_date smalldatetime,
	@units varchar(2),
	@nbr_of_units int,
	@net_gross smallint,
	@create_date smalldatetime,
	@cancelled smallint,
	@cancelled_by varchar(100),
	@cancelled_date smalldatetime,
	@modified_by_d varchar(100),
	@modified_date_d smalldatetime,
	@modified_comments_d varchar(254),
	@revised_flag smallint,
	@link_id int,
	@reconcile_flag smallint,
	@cmp_identifier int,
	@printed smallint,
	@order_accepted smallint,
	@fiscal_period_code varchar(6),
	@locked varchar(1),
	@locked_by varchar(100),
	@bcc_id int,
	@buyer_emp_code varchar(6),
	--@complete int = NULL

	--DETAIL

	--@order_nbr int,
	@line_nbr smallint,
	@rev_nbr smallint,
	@seq_nbr smallint,
	@active_rev smallint,
	@link_detid int,
	@start_date_d smalldatetime,
	@end_date_d smalldatetime,
	@close_date smalldatetime,
	@matl_close_date smalldatetime,
	@ext_close_date smalldatetime,
	@ext_matl_date smalldatetime,

	--tv/ra
	@buy_type varchar (2),
	@month_nbr smallint,
	@year_nbr smallint,
	@date1 smalldatetime,
	@date2 smalldatetime,
	@date3 smalldatetime,
	@date4 smalldatetime,
	@date5 smalldatetime,
	@date6 smalldatetime,
	@date7 smalldatetime,
	@monday smallint,
	@tuesday smallint,
	@wednesday smallint,
	@thursday smallint,
	@friday smallint,
	@saturday smallint,
	@sunday smallint,
	@spots1 int,
	@spots2 int,
	@spots3 int,
	@spots4 int,
	@spots5 int,
	@spots6 int,
	@spots7 int,
	@total_spots int,

	--all
	@job_number int,
	@job_component_nbr smallint,
	@quantity int,
	@rate decimal (16, 4),
	@net_rate decimal (16, 4),
	@gross_rate decimal (16, 4),
	@ext_net_amt decimal (15, 2),
	@ext_gross_amt decimal (15, 2),
	@comm_amt decimal (14, 2),
	@rebate_amt decimal (14, 2),
	@discount_amt decimal (14, 2),
	@discount_desc varchar (30),
	@state_amt decimal (14, 2),
	@county_amt decimal (14, 2),
	@city_amt decimal (14, 2),
	@non_resale_amt decimal (14, 2),
	@netcharge decimal (14, 2),
	@ncdesc varchar (30),
	@addl_charge decimal (14, 2),
	@addl_charge_desc varchar (30),
	@line_total decimal (14, 2),
	--@line_cancelled smallint,
	@date_to_bill smalldatetime,
	@non_bill_flag smallint,
	@modified_by varchar (100),
	@modified_date smalldatetime,
	@modified_comments varchar (254),
	@bill_type_flag smallint,
	@comm_pct decimal (14, 6),
	@markup_pct decimal (14, 6),
	@rebate_pct decimal (14, 6),
	@discount_pct decimal (14, 6),
	@tax_code varchar (4),
	@tax_city_pct decimal (14, 6),
	@tax_county_pct decimal (14, 6),
	@tax_state_pct decimal (14, 6),
	@tax_resale smallint,
	@taxapplyc smallint,
	@taxapplyln smallint,
	@taxapplynd smallint,
	@taxapplync smallint,
	@taxapplyr smallint,
	@taxapplyai smallint,
	@reconcile_flag_d smallint,
	@billing_amt decimal (14, 2),
	@est_nbr int,
	@est_line_nbr smallint,
	@est_rev_nbr smallint,
	@ad_number varchar (30),		-- not MA
	@mat_comp smalldatetime,
	@units_d varchar(2),

	--tv/ra
	@cost_type varchar (3),		-- +NP
	@cost_rate decimal (16, 4),	-- +NP
	@net_base_rate decimal (16, 4),
	@gross_base_rate decimal (16, 4),
	@programming varchar (50),
	@start_time varchar (10),
	@end_time varchar (10),
	@length smallint,
	@remarks varchar (254),
	@tag varchar (10),
	@network_id varchar (10),
	--PJH 08/18/17 - added new columns
	@cable_network_station_code varchar (10), 
	@daypart_id int,
	@added_value bit,
	@bookend bit,
	@link_line_number int,
	@vendor_order_line int,

	--all non-brdcast
	@headline varchar (60),

	--ma/np
	@size varchar (30),
	@edition_issue varchar (30),
	@material varchar (60),
	@section varchar (30),
	@rate_card_id int,
	@rate_dtl_id smallint,
	@contract_qty decimal (10, 2),
	@flat_net decimal (16, 4),
	@flat_gross decimal (16, 4),
	@prod_charge decimal (14, 4),
	@prod_desc varchar (30),
	@color_charge decimal (15, 4),
	@color_desc varchar (30),

	--np
	@print_columns decimal (6, 2),
	@print_inches decimal (6, 2),
	@print_lines decimal (11, 2),
	@np_circulation int, --**added 05/04/15
	@print_quantity decimal (14, 4), --**added 05/04/15

	--ma
	@bleed_pct decimal (14, 6),
	@bleed_amt decimal (14, 2),
	@position_pct decimal (14, 6),
	@position_amt decimal (14, 2),
	@premium_pct decimal (14, 6),
	@premium_amt decimal (14, 2),

	--ma/np
	@flat_netcharge decimal (15, 2),
	@flat_addl_charge decimal (15, 2),
	@flat_discount_amt decimal (15, 2),

	--ma
	@production_size varchar (30),
	@size_code varchar (6),
	@mg_circulation int,

	--in/od
	@o_type varchar (6),		--internet_type / outdoor_type
	@url_location varchar (60),	--url / location
	@copy_area varchar (40),
	@rate_card varchar (10),
	@rate_type varchar(3),
	@rate_desc varchar (10),

	--in/od
	@proj_impressions int, 
	@guaranteed_impress int, 
	@act_impressions int,

	--in
	@target_audience varchar (60), 
	@creative_size varchar (60),
	@placement_1 varchar (256),
	@placement_2 varchar (160),
		@ad_server_placement_id bigint,	--PJH 03/13/17 - added
	@ad_server_created_by varchar(100),
	@ad_server_created_datetime smalldatetime,
	@ad_server_last_modified_by varchar(100),
	@ad_server_last_modified_datetime smalldatetime,
	@ad_server_placement_manual bit,
	@package_parent bit, --PJH 12/12/17 - added
	@ad_server_placement_group_id bigint,

	@line_ad_server_id smallint, --PJH 12/06/18 - Added @line_market_code, @ad_server_id
	@line_market_code varchar(10),

	@channel int, --PJH 02/14/20 - Added @channel & @tactic
	@tactic int,

	--coments & status
	@is_quote smallint,
	@prc_status smallint,
	@instructions varchar(max),
	@order_copy varchar(max),
	@matl_notes varchar(max),
	@position_info varchar(max),
	@close_info varchar(max),
	@rate_info varchar(max),
	@misc_info varchar(max),
	@in_house_cmts varchar(max),

	--product defaults
	@prd_bill_type_flag smallint,

	--PRINT_ORDERS overrides
	@comm_pct_or decimal (14, 6),
	@markup_pct_or decimal (14, 6),
	@rebate_pct_or decimal (14, 6),
	@rebate_amt_or decimal (14, 2),
	@line_revised_date datetime

SELECT @line_revised_date = GETDATE()

DECLARE @tmp_orders TABLE (
	[RowID] [int] IDENTITY(1,1),
	[RECSEQ] [int],  
	[ACCT_ORD_NBR] [int] NOT NULL,
	[ITEM_NBR] [varchar](4) NULL,
	[MEDIA_TYPE] [varchar](3) NOT NULL,
	[TRADE] [int] NULL,
	[REV_NBR] [smallint] NOT NULL,
	[ADVERTISER_NAME] [varchar](30) NULL,
	[ADVERTISER_CODE] [varchar](20) NULL,
	[CAMP_DESC] [varchar](20) NULL,
	[CAMP_CODE] [varchar](6) NULL,
	[PROD_CODE] [varchar](6) NULL,
	[BRAND_CODE] [varchar](6) NULL,
	[VENDOR_NAME] [varchar](48) NULL,
	[VENDOR_CODE] [varchar](6) NULL,
	[INSERT_DATE] [smalldatetime] NOT NULL,
	[AD_SIZE] [varchar](66) NULL,
	[RATE_PER] [decimal](16, 4) NULL,
	[PREV_RATE_PER] [decimal](16, 4) NULL,
	[INSERT_STATUS] [varchar](1) NULL,
	[CAPTION] [varchar](60) NULL,
	[POS_REQUEST] [varchar](50) NULL,
	[MAT_CLOSE_DATE] [smalldatetime] NULL,
	[ESTIMATE_NUMBER] [varchar](16) NULL,
	[AGENCY_NET_RATE] [decimal](8, 4) NULL,
	[SPACE_CLOSE_DATE] [smalldatetime] NULL,
	[BUYER] [varchar](6) NULL,
	[ORDER_DESC] [varchar](50) NULL,
	[ORDER_COMMENT] [varchar](MAX) NULL,
	[MEDIA_INTERFACE] [varchar](2) NULL,
	[INTERFACE_SEQ_NBR] [int] NULL,
	[CLIENT_PO] [varchar](25) NULL,
	[IMPORT_YEAR] [smallint] NULL,
	[SECTION_ISSUE] [varchar](50) NULL,
	[ZONE] [varchar](60) NULL,
	[LOCATION] [varchar](254) NULL,
	[LINE_COMMENT] [varchar](254) NULL,
	[SALES_CLASS_CODE] [varchar](6) NOT NULL,
	[POST_FLAG] [smallint] NOT NULL,
	[PREMIUM_CHGS] [decimal](14, 2) NULL,
	[FLAT_NETCHARGE] [decimal](15, 2) NULL,
	[FLAT_ADDL_CHARGE] [decimal](15, 2) NULL,
	[FLAT_DISCOUNT_AMT] [decimal](15, 2) NULL,
	[MODIFIED_COMMENTS] [text] NULL,
	[REVISED_FLAG] [smallint] NULL,
	[DELETE_ORDER] [smallint] NULL,
	[JOB_NUMBER] [int] NULL,
	[JOB_COMPONENT_NBR] [smallint] NULL,
	[MARKET_CODE] [varchar](10) NULL,
	[MARKET_DESC] [varchar](40) NULL,
	[VR_CODE] [varchar](4) NULL,
	[VR_CODE2] [varchar](4) NULL,
	[BUYER_NAME] [varchar](40) NULL,
	[END_DATE] [smalldatetime] NULL,
	[SIZE_CODE] [varchar](6) NULL,
	[AD_NUMBER] [varchar](30) NULL,
	[AD_NUMBER_DESC] [varchar](60) NULL,
	[URL] [varchar](60) NULL,
	[CREATIVE_SIZE] [varchar](60) NULL,
	[PLACEMENT_2] [varchar](160) NULL,
	[INTERNET_TYPE] [varchar](6) NULL,
	[COST_TYPE] [varchar](3) NULL,
	[PROJ_IMPRESSIONS] [int] NULL,
	[GUARANTEED_IMPRESS] [int] NULL,
	[ACT_IMPRESSIONS] [int] NULL,
	[COST_RATE] [decimal](16, 4) NULL,
	[PRODUCTION_SIZE] [varchar](30) NULL,
	[MATERIAL] [varchar](60) NULL,
	[RATE_TYPE] [varchar](3) NULL,
	[OUTDOOR_TYPE] [varchar](6) NULL,
	[PRINT_COLUMNS] [decimal](6, 2) NULL,
	[PRINT_INCHES] [decimal](6, 2) NULL,
	[PRINT_LINES] [decimal](11, 2) NULL,
	[VN_CODE_XREF] [varchar](12) NULL,
	[NET_BASE_RATE] [decimal](16, 4) NULL,
	[GROSS_BASE_RATE] [decimal](16, 4) NULL,
	[NET_RATE] [decimal](16, 4) NULL,
	[GROSS_RATE] [decimal](16, 4) NULL,
	[MARKUP_PCT] [decimal](8, 4) NULL,
	[REBATE_PCT] [decimal](8, 4) NULL,
	[REBATE_AMT] [decimal](14, 2) NULL,
	[PLAN_IDS] [varchar](max) NULL,
	[COMM_PCT] [decimal](8, 4) NULL, 
	[IS_QUOTE] [smallint] NULL,
	[PRC_STATUS] [smallint] NULL,
	[INSTRUCTIONS] [text] NULL,
	[ORDER_COPY] [text] NULL,
	[MATL_NOTES] [text] NULL,
	[POSITION_INFO] [text] NULL,
	[CLOSE_INFO] [text] NULL,
	[RATE_INFO] [text] NULL,
	[MISC_INFO] [text] NULL,
	[IN_HOUSE_CMTS] [text] NULL,
	[BUYER_EMP_CODE] [varchar](6) NULL,
	[UNITS] [varchar](2) NULL,
	[LINE_MARKET_CODE] [varchar](10) NULL,
	[CIRCULATION] [int] NULL,
	[MEDIA_CHANNEL_ID] [int],
	[MEDIA_TACTIC_ID] [int]
	)

 DECLARE @tmp_orders2 TABLE (
	[RowID] [int] IDENTITY(1,1),
	[RECSEQ] [int] NOT NULL,
	[LINK_ID] [int] NOT NULL,
	[LINE_NBR] [varchar](8) NULL,
	[REV_NBR] [smallint] NOT NULL,
	[MEDIA_TYPE] [varchar](6) NOT NULL,
	[SALES_CLASS_CODE] [varchar](6) NOT NULL,
	[CL_CODE] [varchar](6) NOT NULL,
	[PRD_CODE] [varchar](6) NOT NULL,
	[VN_CODE] [varchar](6) NOT NULL,
	[LINE_FLIGHT_FROM] [smalldatetime] NOT NULL,
	[LINE_FLIGHT_TO] [smalldatetime] NOT NULL,
	[HDR_FLIGHT_FROM] [smalldatetime] NOT NULL,
	[HDR_FLIGHT_TO] [smalldatetime] NOT NULL,
	[FLIGHT_TYPE] [varchar](1) NOT NULL,
	[RATE] [decimal](14, 4) NOT NULL,
	[NET_RATE] [decimal](14, 4) NOT NULL,
	[GROSS_RATE] [decimal](14, 4) NOT NULL,
	[P1_52] [varchar](max) NOT NULL,
	[DIV_CODE] [varchar](6) NULL,
	[CMP_CODE] [varchar](6) NULL,
	[ORDER_DESC] [varchar](40) NULL,
	[MARKET_CODE] [varchar](10) NULL,
	[START_TIME] [varchar](10) NULL,
	[END_TIME] [varchar](10) NULL,
	[TOTAL_SPOTS] [int] NULL,
	[COMM_PCT] [decimal](6, 2) NULL,
	[DELETE_FLAG] [int] NULL,
	[BUYER] [varchar](40) NULL,
	[CLIENT_PO] [varchar](25) NULL,
	[LENGTH] [smallint] NULL,
	[PROGRAMMING] [varchar](50) NULL,
	[MONDAY] [smallint] NULL,
	[TUESDAY] [smallint] NULL,
	[WEDNESDAY] [smallint] NULL,
	[THURSDAY] [smallint] NULL,
	[FRIDAY] [smallint] NULL,
	[SATURDAY] [smallint] NULL,
	[SUNDAY] [smallint] NULL,
	[ORDER_COMMENT] [varchar](MAX) NULL,
	[LINE_COMMENT] [varchar](254) NULL,
	[CL_NAME] [varchar](40) NULL,
	[VN_NAME] [varchar](40) NULL,
	[MARKET_DESC] [varchar](40) NULL,
	[MEDIA_INTERFACE] [varchar](2) NULL,
	[POST_FLAG] [smallint] NOT NULL,
	[DELETE_ORDER] [smallint] NULL,
	[CNVT_IMPRT_LINE] [smallint] NULL,
	[POSSIBLE_DUPE] [smallint] NULL,
	[JOB_NUMBER] [int] NULL,
	[JOB_COMPONENT_NBR] [smallint] NULL,
	[VR_CODE] [varchar](4) NULL,
	[VR_CODE2] [varchar](4) NULL,
	[WEEKLY_COST] [decimal](14, 2) NULL,
	[NET_GROSS_FLAG] [smallint] NULL,
	[VN_CODE_XREF] [varchar](12) NULL,
	[AIR_DATE] [smalldatetime] NULL,
	[BC_WEEKS] [smallint] NULL,
	[NETWORK_ID] [varchar](10) NULL,
	[NETCHARGE] [decimal](14, 2) NULL,
	[ADDL_CHARGE] [decimal](14, 2) NULL,
	[DATE1] [smalldatetime] NULL,
	[DATE2] [smalldatetime] NULL,
	[DATE3] [smalldatetime] NULL,
	[DATE4] [smalldatetime] NULL,
	[DATE5] [smalldatetime] NULL,
	[DATE6] [smalldatetime] NULL,
	[BUY_MONTH] [smallint] NULL,
	[BUY_YEAR] [smallint] NULL,
	[REBATE_PCT] [decimal](8, 4) NULL,
	[REBATE_AMT] [decimal](14, 2) NULL,
	[MARKUP_PCT] [decimal](8, 4) NULL,
	[PLAN_IDS] [varchar](max) NULL,
	[CAL_TYPE] [varchar](2) NULL,
	[DAYPART_CODE] [varchar](6) NULL,
	[ESTIMATE_NBR] [varchar](30) NULL,
	[PACKAGE_NAME] [varchar](50) NULL,
	[USER_ID] [varchar](100) NULL,	
	[IS_QUOTE] [smallint] NULL,
	[PRC_STATUS] [smallint] NULL,
	[REMARKS] [text] NULL,	
	[ORDER_COPY] [text] NULL,
	[MATL_NOTES] [text] NULL,
	[POSITION_INFO] [text] NULL,
	[CLOSE_INFO] [text] NULL,
	[RATE_INFO] [text] NULL,
	[MISC_INFO] [text] NULL,
	[BUYER_EMP_CODE] [varchar](6) NULL,
	[AD_NBR] [varchar](30) NULL,
	[CABLE_NETWORK_STATION_CODE] [varchar](10) NULL,
	[DAY_PART_ID] [int] NULL,
	[ADDED_VALUE] [bit] NULL,
	[BOOKEND] [int] NULL,
	[VENDOR_ORDER_LINE] [int] NULL
	)

DECLARE @tmp_plan_ids TABLE (
	[RowID] [int] IDENTITY(1,1),
	[ACCT_ORD_NBR] [int] NOT NULL,
	[ITEM_NBR] [int] NOT NULL,
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [int] NOT NULL, 
	[VENDOR_ORDER_LINE] [int] NULL,
	[PLAN_ID_C] varchar(40) NOT NULL,
	[PLAN_ID] [int] NOT NULL,
	[AUTHORIZATION_FLAG] [int] NULL,
	[MEDIA_INTERFACE] [varchar](3))
 /* Media Plans */
DECLARE @tmp_plan_ids2 TABLE (
	--[RowID] [int],
	[ACCT_ORD_NBR] [int] NOT NULL,
	[ITEM_NBR] [int] NOT NULL,
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [int] NOT NULL, 
	[VENDOR_ORDER_LINE] [int] NULL,
	[PLAN_ID_C] varchar(40) NOT NULL,
	[PLAN_ID] [int] NOT NULL,
	[AUTHORIZATION_FLAG] [int] NULL,
	[MEDIA_INTERFACE] [varchar](3))
 /* Auth to Buy */
 DECLARE @tmp_plan_ids3 TABLE (
	--[RowID] [int],
	[ACCT_ORD_NBR] [int] NOT NULL,
	[ITEM_NBR] [int] NOT NULL,
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [int] NOT NULL, 
	[VENDOR_ORDER_LINE] [int] NULL,
	[PLAN_ID_C] varchar(40) NOT NULL,
	[PLAN_ID] [int] NOT NULL,
	[AUTHORIZATION_FLAG] [int] NULL,
	[MEDIA_INTERFACE] [varchar](3))

 /* Spots/Dates related to the given Order/Line */
DECLARE @bc_spots_table TABLE ( 
		BC_DATE1 SMALLDATETIME,
		BC_DATE2 SMALLDATETIME,
		BC_DATE3 SMALLDATETIME,
		BC_DATE4 SMALLDATETIME,
		BC_DATE5 SMALLDATETIME,
		BC_DATE6 SMALLDATETIME,
		BC_MMYYYY VARCHAR(6),
		BC_SPOTS1 INT,
		BC_SPOTS2 INT,
		BC_SPOTS3 INT,
		BC_SPOTS4 INT,
		BC_SPOTS5 INT,
		BC_SPOTS6 INT
	)

DECLARE @sql varchar(500), @param_def varchar(500), @error_msg_w varchar(500)
DECLARE @rr_msg_w varchar(100), @goto_id varchar(50), @s_temp varchar(250)
DECLARE @max_order_nbr int, @ok smallint, @table_prefix varchar(50)
DECLARE @date_time_w smalldatetime, @media_interface varchar(3), @media_interface_in varchar(3), @imported_from varchar(30)

DECLARE @cnt int, @media_type_in varchar(2)
DECLARE @hdr_exists int, @dtl_exists int, @dtl_cmnt_exists int
DECLARE @order_type_chg int
DECLARE @rebate_amt_override smallint, @rebate_pct_override smallint, @markup_pct_override smallint, @comm_pct_override smallint
DECLARE @sales_class_code varchar(10), @rev_nbr_import smallint

DECLARE @comm_pct_v decimal (14, 6), @markup_pct_v decimal (14, 6), @rebate_pct_v decimal (14, 6)

DECLARE @def_vr_code varchar(10), @def_vr_code2 varchar(10), @existing_vn_code varchar(10)

DECLARE @p1_52 varchar(max), @spots int, @line_comment varchar(254)--, @flight_type varchar(1)

DECLARE @delete_order int, @cal_type varchar(2), @air_date smalldatetime--, @net_gross_flag int

DECLARE @ad_server_id int
/* PJH 03/07/18 - Used to determine if a given date has ever been used for this order/line */
--DECLARE @date1_rev smalldatetime, @date2_rev smalldatetime, @date3_rev smalldatetime, @date4_rev smalldatetime, @date5_rev smalldatetime, @date6_rev smalldatetime, @date7_rev smalldatetime

/* Used for date calculation */
DECLARE @cutoff_dt varchar(10)
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

SET @cutoff_dt = '12/31/2010'

DECLARE @ROW_COUNT int, @ROW_ID int, @DEBUG int, @MAKEGOOD bit
DECLARE @RC int, @RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
			

BEGIN TRY

--RETURN  /*************** D E B U G ************************************************ COMMENT FOR LIVE PROCESSING ******************************************* D E B U G ***************/

IF @action = 'DEBUG'
	SET @DEBUG = 1
ELSE
	SET @DEBUG = 0

IF @action = 'MAKEGOOD'
	SET @MAKEGOOD = 1
ELSE
	SET @MAKEGOOD = 0

SELECT @date_time_w=GETDATE()

GOTO SET_DATES
AFTER_SET_DATES:

--SELECT @media_interface = 'AM'

IF @order_type NOT IN ('NP','MA','OD','IN','TV','RA') BEGIN
	SELECT @order_type = 
		CASE @order_type
			WHEN 'N' THEN 'NP'
			WHEN 'M' THEN 'MA'
			WHEN 'I' THEN 'IN'
			WHEN 'O' THEN 'OD'
			WHEN 'T' THEN 'TV'
			WHEN 'R' THEN 'RA'
			ELSE @order_type
		END
END	

SELECT @media_type_in = 
	CASE @order_type
		WHEN 'NP' THEN 'N'
		WHEN 'MA' THEN 'M'
		WHEN 'IN' THEN 'I'
		WHEN 'OD' THEN 'O'
		WHEN 'TV' THEN 'T'
		WHEN 'RA' THEN 'R'
		ELSE @order_type
	END

SET NOCOUNT OFF

--ZZZ SELECT @media_type_in '@media_type_in'

IF @order_type IN ('NP','MA','IN','OD')
	INSERT INTO @tmp_orders
	SELECT 
		[RECSEQ]
		,[ACCT_ORD_NBR]
		,[ITEM_NBR]
		,[MEDIA_TYPE]
		,[TRADE]
		,[REV_NBR]
		,[ADVERTISER_NAME]
		,[ADVERTISER_CODE]
		,[CAMP_DESC]
		,[CAMP_CODE]
		,[PROD_CODE]
		,[BRAND_CODE]
		,[VENDOR_NAME]
		,[VENDOR_CODE]
		,[INSERT_DATE]
		,[AD_SIZE]
		,[RATE_PER]
		,[PREV_RATE_PER]
		,[INSERT_STATUS]
		,[CAPTION]
		,[POS_REQUEST]
		,[MAT_CLOSE_DATE]
		,[ESTIMATE_NUMBER]
		,[AGENCY_NET_RATE]
		,[SPACE_CLOSE_DATE]
		,[BUYER]
		,[ORDER_DESC]
		,[ORDER_COMMENT]
		,[MEDIA_INTERFACE]
		,[INTERFACE_SEQ_NBR]
		,[CLIENT_PO]
		,[IMPORT_YEAR]
		,[SECTION_ISSUE]
		,[ZONE]
		,[LOCATION]
		,[LINE_COMMENT]
		,[SALES_CLASS_CODE]
		,[POST_FLAG]
		,[PREMIUM_CHGS]
		,[FLAT_NETCHARGE]
		,[FLAT_ADDL_CHARGE]
		,[FLAT_DISCOUNT_AMT]
		,[MODIFIED_COMMENTS]
		,[REVISED_FLAG]
		,[DELETE_ORDER]
		,[JOB_NUMBER]
		,[JOB_COMPONENT_NBR]
		,[MARKET_CODE]
		,[MARKET_DESC]
		,[VR_CODE]
		,[VR_CODE2]
		,[BUYER_NAME]
		,[END_DATE]
		,[SIZE_CODE]
		,[AD_NUMBER]
		,[AD_NUMBER_DESC]
		,[URL]
		,[CREATIVE_SIZE]
		,[PLACEMENT_2]
		,[INTERNET_TYPE]
		,[COST_TYPE]
		,[PROJ_IMPRESSIONS]
		,[GUARANTEED_IMPRESS]
		,[ACT_IMPRESSIONS]
		,[COST_RATE]
		,[PRODUCTION_SIZE]
		,[MATERIAL]
		,[RATE_TYPE]
		,[OUTDOOR_TYPE]
		,[PRINT_COLUMNS]
		,[PRINT_INCHES]
		,[PRINT_LINES]
		,[VN_CODE_XREF]
		,[NET_BASE_RATE]
		,[GROSS_BASE_RATE]
		,[NET_RATE]
		,[GROSS_RATE]
		,[MARKUP_PCT]
		,[REBATE_PCT]
		,[REBATE_AMT]
		,[PLAN_IDS]
		,[COMM_PCT] 
		,[IS_QUOTE]
		,[PRC_STATUS]
		,[INSTRUCTIONS] 
		,[ORDER_COPY] 
		,[MATL_NOTES] 
		,[POSITION_INFO]
		,[CLOSE_INFO]
		,[RATE_INFO] 
		,[MISC_INFO]
		,[IN_HOUSE_CMTS]
		,[BUYER_EMP_CODE]
		,[UNITS]
		,[LINE_MARKET_CODE]
		,[CIRCULATION]
		,[MEDIA_CHANNEL_ID]
		,[MEDIA_TACTIC_ID]
	FROM PRINT_ORDER
	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW','MM') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0 AND USER_ID = @user_id) OR
			(MEDIA_INTERFACE IN ('OT') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0 AND USER_ID = @user_id)
	ORDER BY ACCT_ORD_NBR, ITEM_NBR, [REV_NBR], [RECSEQ]
ELSE
	INSERT INTO @tmp_orders2
	SELECT 
		[RECSEQ]
		,[LINK_ID]
		,[LINE_NBR]
		,[REV_NBR]
		,[MEDIA_TYPE]
		,[SALES_CLASS_CODE]
		,[CL_CODE]
		,[PRD_CODE]
		,[VN_CODE]
		,[LINE_FLIGHT_FROM]
		,[LINE_FLIGHT_TO]
		,[HDR_FLIGHT_FROM]
		,[HDR_FLIGHT_TO]
		,[FLIGHT_TYPE]
		,[RATE]
		,[NET_RATE]
		,[GROSS_RATE]
		,[P1_52]
		,[DIV_CODE]
		,[CMP_CODE]
		,[ORDER_DESC]
		,[MARKET_CODE]
		,[START_TIME]
		,[END_TIME]
		,[TOTAL_SPOTS]
		,[COMM_PCT]
		,[DELETE_FLAG]
		,[BUYER]
		,[CLIENT_PO]
		,[LENGTH]
		,[PROGRAMMING]
		,[MONDAY]
		,[TUESDAY]
		,[WEDNESDAY]
		,[THURSDAY]
		,[FRIDAY]
		,[SATURDAY]
		,[SUNDAY]
		,[ORDER_COMMENT]
		,[LINE_COMMENT]
		,[CL_NAME]
		,[VN_NAME]
		,[MARKET_DESC]
		,[MEDIA_INTERFACE]
		,[POST_FLAG]
		,[DELETE_ORDER]
		,[CNVT_IMPRT_LINE]
		,[POSSIBLE_DUPE]
		,[JOB_NUMBER]
		,[JOB_COMPONENT_NBR]
		,[VR_CODE]
		,[VR_CODE2]
		,[WEEKLY_COST]
		,[NET_GROSS_FLAG]
		,[VN_CODE_XREF]
		,[AIR_DATE]
		,[BC_WEEKS]
		,[NETWORK_ID]
		,[NETCHARGE]
		,[ADDL_CHARGE]
		,[DATE1]
		,[DATE2]
		,[DATE3]
		,[DATE4]
		,[DATE5]
		,[DATE6]
		,[BUY_MONTH]
		,[BUY_YEAR]
		,[REBATE_PCT]
		,[REBATE_AMT]
		,[MARKUP_PCT]
		,[PLAN_IDS]
		,[CAL_TYPE]
		,[DAYPART_CODE]
		,[ESTIMATE_NBR]
		,[PACKAGE_NAME]
		,[USER_ID]
		,[IS_QUOTE]
		,[PRC_STATUS]
		,[REMARKS]
		,[ORDER_COPY] 
		,[MATL_NOTES] 
		,[POSITION_INFO]
		,[CLOSE_INFO]
		,[RATE_INFO] 
		,[MISC_INFO]
		,[BUYER_EMP_CODE] 	
		,[AD_NBR]
		,[CABLE_NETWORK_STATION_CODE]
		,[DAY_PART_ID]
		,[ADDED_VALUE]
		,[BOOKEND]
		,[VENDOR_ORDER_LINE]
	FROM BRDCAST_IMPORT
	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW','MM') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0 AND USER_ID = @user_id) OR
			(MEDIA_INTERFACE IN ('OT') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0 AND USER_ID = @user_id)
	ORDER BY LINK_ID, LINE_NBR, [REV_NBR], [RECSEQ]

SET @ROW_COUNT = @@ROWCOUNT

DECLARE @RetCount int

/* Verify the import order & line numbers are valid numbers */
IF @order_type IN ('NP','MA','IN','OD')
	SELECT @RetCount = COUNT(*) FROM @tmp_orders 
	WHERE POST_FLAG = 0 AND MEDIA_INTERFACE IN ('AB','AM','AP','AW','MM') AND MEDIA_TYPE = @media_type_in
		AND (ISNUMERIC(ACCT_ORD_NBR) = 0 OR ISNUMERIC(ITEM_NBR) = 0
		OR ACCT_ORD_NBR <= 0 OR CAST(ITEM_NBR AS int) <= 0)
ELSE
	SELECT @RetCount = COUNT(*) FROM @tmp_orders2 
	WHERE POST_FLAG = 0 AND MEDIA_INTERFACE IN ('AB','AM','AP','AW','MM') AND MEDIA_TYPE = @media_type_in
		AND (ISNUMERIC(LINK_ID) = 0 OR ISNUMERIC(LINE_NBR) = 0
		OR CAST(LINK_ID AS int) <= 0 OR CAST(LINE_NBR AS int) <= 0)

IF @RetCount > 0 BEGIN
	IF @order_type IN ('NP','MA','IN','OD')
		SET @error_msg_w = 'There are ' + CAST(@RetCount AS varchar(15)) + ' non-broadcast order lines related to this import that have invalid order or line numbers.'
	ELSE
		SET @error_msg_w = 'There are ' + CAST(@RetCount AS varchar(15)) + ' broadcast order lines related to this import that have invalid order or line numbers.'
	SET @ret_val_s = @error_msg_w
	SET @ret_val = 1
	GOTO ERROR_MSG	
END

SET @RetCount = 0

/* PJH 12/25/20 - Beg */
DECLARE @media_interface_search varchar(254)
IF @order_type IN ('NP','MA','IN','OD') BEGIN
	SET @media_interface_search = 'AB,AM,AP,AW'
END ELSE BEGIN
	SET @media_interface_search = 'AB,AM,AP,AW'
END
EXEC @RetCount = [dbo].[advsp_import_orders_selected_for_billing] @media_type_in, @media_interface_search
IF @RetCount > 0 BEGIN
	SET @error_msg_w = 'There are ' + CAST(@RetCount AS varchar(15)) + ' order lines related to this import that are currently selected for billing or media manager review.' + CHAR(10) + 'Please finish the billing process or clear the media selection and continue with the import..'
	SET @ret_val_s = @error_msg_w
	SET @ret_val = 1
	GOTO ERROR_MSG	
END
/* PJH 12/25/20 - End */

SET @ROW_ID = 1

SET @order_type_chg = 0

SET NOCOUNT ON

BEGIN TRAN TP1

--'Order file(s) created, [Direct Post], use the Media Generic Import to finalize order creation.'

IF @order_type NOT IN ('NP','MA','IN','OD','TV','RA') BEGIN 
	IF @order_type IN ('NP','MA','OD','IN','TV','RA')  
		SET @error_msg_w = 'Order file(s) created, [Direct Post], use the Media Generic Import to finalize order creation.'
	ELSE
		SET @error_msg_w = 'Invalid Order Type - Valid types are NP, MA, IN, OD, TV, or RA.'
	SET @ret_val_s = @error_msg_w
	SET @ret_val = 1
	GOTO ERROR_MSG	
END

/** Clear Posted rows from PRINT_ORDER table **/
IF @DEBUG = 1 BEGIN
	SELECT 'PRINT_ORDERS (Posted) to CLEAR' 'DESC', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM PRINT_ORDER
	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
	SELECT 'BRDCAST_ORDER (Posted) to CLEAR' 'DESC', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM BRDCAST_IMPORT
	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW','MM') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
END
ELSE BEGIN
	DELETE FROM PRINT_ORDER
	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
	DELETE FROM BRDCAST_IMPORT
	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW','MM') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
END

WHILE @ROW_ID <= @ROW_COUNT BEGIN

	--uf_generic_dtl - Field Mapping
	IF @order_type IN ('NP','MA','IN','OD')
		SELECT
			 @order_nbr = 0
			,@link_id		= [ACCT_ORD_NBR]	
			,@link_detid	= CAST([ITEM_NBR] AS INT)
			,@media_type	= [MEDIA_TYPE]
			,@media_interface_in = [MEDIA_INTERFACE]
			,@rev_nbr_import = [REV_NBR]
		FROM @tmp_orders
		WHERE RowID = @ROW_ID
	ELSE
		SELECT
			 @order_nbr = 0
			,@link_id		= [LINK_ID]	
			,@link_detid	= CAST([LINE_NBR] AS INT)
			,@media_type	= [MEDIA_TYPE]
			,@media_interface_in = [MEDIA_INTERFACE]
			,@rev_nbr_import = [REV_NBR]
		FROM @tmp_orders2
		WHERE RowID = @ROW_ID


	SET @hdr_exists = 0
	SET @dtl_exists = 0
	SET @dtl_cmnt_exists = 0
	SET @order_nbr = 0
	SET @line_nbr = 0

	--SELECT @hdr_exists '@hdr_exists', @dtl_exists '@dtl_exists', @media_interface_in '@media_interface', @media_type '@media_type', @link_id '@link_id', @link_detid '@link_detid' /** DEBUG **/
	IF @order_type IN ('NP','MA','IN','OD') BEGIN
		IF @media_interface_in = 'AM' OR @media_interface_in = 'AB' OR @media_interface_in = 'OT' OR @media_interface_in = 'AP' BEGIN
			SELECT @order_nbr = COALESCE(ORDER_NBR, 0), @line_nbr = COALESCE(LINE_NBR, 0)
			FROM   PRINT_IMPORT_XREF
			WHERE  IMPORT_ORDER_NBR = @link_id AND IMPORT_LINE_NBR = @link_detid AND (IMPORTED_FROM = @media_interface_in) AND (MEDIA_TYPE = @media_type); --AND (SALES_CLASS_CODE = @sales_class_code); 
		END
	END	
	ELSE BEGIN
        IF @media_interface_in = 'MM' BEGIN
            SELECT @order_nbr = COALESCE(ORDER_NBR, 0), @line_nbr = COALESCE(LINE_NBR, 0)
			FROM   BRD_IMPORT_XREF
			WHERE  IMPORT_ORDER_NBR = @link_id AND IMPORT_LINE_NBR = @link_detid AND (IMPORTED_FROM = 'AW') AND (MEDIA_TYPE = @media_type); --AND (SALES_CLASS_CODE = @sales_class_code); 
        END
		IF @media_interface_in = 'AM' OR @media_interface_in = 'AB' OR @media_interface_in = 'OT' OR @media_interface_in = 'AP' OR @media_interface_in = 'AW' BEGIN
			SELECT @order_nbr = COALESCE(ORDER_NBR, 0), @line_nbr = COALESCE(LINE_NBR, 0)
			FROM   BRD_IMPORT_XREF
			WHERE  IMPORT_ORDER_NBR = @link_id AND IMPORT_LINE_NBR = @link_detid AND (IMPORTED_FROM = @media_interface_in) AND (MEDIA_TYPE = @media_type); --AND (SALES_CLASS_CODE = @sales_class_code); 
		END	
	END
	SET @imported_from = 
		CASE @media_interface_in 
			WHEN 'AM' THEN 'MEDIA PLANNING'
			WHEN 'AB' THEN 'AUTHORIZATION TO BUY'
			WHEN 'OT' THEN 'GENERIC IMPORT'
			WHEN 'AP' THEN 'ACCOUNTS PAYABLE'
			WHEN 'AW' THEN 'BROADCAST WORKSHEET'
			WHEN 'MM' THEN 'BROADCAST WORKSHEET MM'
			ELSE 'N/A'
		END

	--SELECT @imported_from  /* DEBUG */

	IF @line_nbr > 0 BEGIN
		SET @dtl_exists = 1
		SET @hdr_exists = 1
	END
	ELSE BEGIN
		SET @dtl_exists = 0
	END

	IF @dtl_exists = 0 BEGIN
		IF @order_type IN ('NP','MA','IN','OD') BEGIN
			IF @media_interface_in = 'AM' OR @media_interface_in = 'AB' OR @media_interface_in = 'OT' OR @media_interface_in = 'AP' BEGIN /** DEBUG **/
				SELECT @order_nbr = COALESCE(ORDER_NBR, 0)
				FROM   PRINT_IMPORT_XREF
				WHERE  IMPORT_ORDER_NBR = @link_id AND (IMPORTED_FROM = @media_interface_in) AND (MEDIA_TYPE = @media_type); 
			END
		END	
		ELSE BEGIN
            IF @media_interface_in = 'MM' BEGIN /** DEBUG **/
				SELECT @order_nbr = COALESCE(ORDER_NBR, 0)
				FROM   BRD_IMPORT_XREF
				WHERE  IMPORT_ORDER_NBR = @link_id AND (IMPORTED_FROM = 'AW') AND (MEDIA_TYPE = @media_type); 
			END	
			IF @media_interface_in = 'AM' OR @media_interface_in = 'AB' OR @media_interface_in = 'OT' OR @media_interface_in = 'AP' OR @media_interface_in = 'AW' BEGIN /** DEBUG **/
				SELECT @order_nbr = COALESCE(ORDER_NBR, 0)
				FROM   BRD_IMPORT_XREF
				WHERE  IMPORT_ORDER_NBR = @link_id AND (IMPORTED_FROM = @media_interface_in) AND (MEDIA_TYPE = @media_type); 
			END	
		END
		IF @order_nbr > 0 BEGIN
			SET @hdr_exists = 1
		END
		ELSE BEGIN
			SET @hdr_exists = 0
		END
	END

	--SELECT @hdr_exists '@hdr_exists', @dtl_exists '@dtl_exists', @media_interface '@media_interface', @media_type '@media_type', @link_id '@link_id', @link_detid '@link_detid' /** DEBUG **/

	IF @dtl_exists = 1 OR @hdr_exists = 1 BEGIN
		SET @action = 'REVISE'
	END 
	ELSE BEGIN
		SET @action = 'NEW'
	END

	--SELECT @link_detid '@link_detid', @start_date '@start_date', @hdr_exists '@hdr_exists', @dtl_exists '@dtl_exists'  /* DEBUG */	

	/* Clear working Vars */

	SET @markup_pct_or = NULL
	SET @markup_pct_override = 0
	
	SET @rebate_pct_or = NULL
	SET @rebate_pct_override = 0
	
	SET @rebate_amt_or = NULL
	SET @rebate_amt_override = 0
	
	SET @comm_pct_or = NULL
	SET @comm_pct_override = 0

	SELECT 	
		--@order_nbr = NULL,
		@order_desc = NULL,
		@cl_code = NULL,
		@div_code = NULL,
		@prd_code = NULL,
		@office_code = NULL,
		@cmp_code = NULL,
		--@media_type = NULL,
		@vn_code = NULL,
		@vr_code = NULL,
		@vr_code2 = NULL,
		@client_po = NULL,
		@client_ref = NULL,
		@status = NULL,
		@order_date = NULL,
		@buyer = NULL,
		@order_comment = NULL,
		@house_comment = NULL,
		@pub_station = NULL,
		@rep1 = NULL,
		@rep2 = NULL,
		@bill_coop_code = NULL,
		@ord_process_contrl = NULL,
		@market_code = NULL,
		@start_date = NULL,
		@end_date = NULL,
		@units = NULL,
		@nbr_of_units = NULL,
		@net_gross = NULL,
		@create_date = NULL,
		@cancelled = NULL,
		@cancelled_by = NULL,
		@cancelled_date = NULL,
		@modified_by_d = NULL,
		@modified_date_d = NULL,
		@modified_comments_d = NULL,
		@revised_flag = NULL,
		--@link_id = NULL,
		@reconcile_flag = NULL,
		@cmp_identifier = NULL,
		@printed = NULL,
		@order_accepted = NULL,
		@fiscal_period_code = NULL,
		@locked = NULL,
		@locked_by = NULL,
		@bcc_id = NULL,
		@buyer_emp_code = NULL,
		--@complete = NULL = NULL

		--DETAIL
		--@line_nbr = NULL,
		@rev_nbr = NULL,
		@seq_nbr = NULL,
		@active_rev = NULL,
		--@link_detid = NULL,
		@start_date_d = NULL,
		@end_date_d = NULL,
		@close_date = NULL,
		@matl_close_date = NULL,
		@ext_close_date = NULL,
		@ext_matl_date = NULL,

		--tv/ra
		@buy_type = NULL,
		@month_nbr = NULL,
		@year_nbr = NULL,
		@date1 = NULL,
		@date2 = NULL,
		@date3 = NULL,
		@date4 = NULL,
		@date5 = NULL,
		@date6 = NULL,
		@date7 = NULL,
		@monday = NULL,
		@tuesday = NULL,
		@wednesday = NULL,
		@thursday = NULL,
		@friday = NULL,
		@saturday = NULL,
		@sunday = NULL,
		@spots1 = NULL,
		@spots2 = NULL,
		@spots3 = NULL,
		@spots4 = NULL,
		@spots5 = NULL,
		@spots6 = NULL,
		@spots7 = NULL,
		@total_spots = NULL,

		--all
		@job_number = NULL,
		@job_component_nbr = NULL,
		@quantity = NULL,
		@rate = NULL,
		@net_rate = NULL,
		@gross_rate = NULL,
		@ext_net_amt = NULL,
		@ext_gross_amt = NULL,
		@comm_amt = NULL,
		@rebate_amt = NULL,
		@discount_amt = NULL,
		@discount_desc = NULL,
		@state_amt = NULL,
		@county_amt = NULL,
		@city_amt = NULL,
		@non_resale_amt = NULL,
		@netcharge = NULL,
		@ncdesc = NULL,
		@addl_charge = NULL,
		@addl_charge_desc = NULL,
		@line_total = NULL,
		--@line_cancelled = NULL,
		@date_to_bill = NULL,
		@non_bill_flag = NULL,
		@modified_by = NULL,
		@modified_date = NULL,
		@modified_comments = NULL,
		@bill_type_flag = NULL,
		@comm_pct = NULL,
		@markup_pct = NULL,
		@rebate_pct = NULL,
		@discount_pct = NULL,
		@tax_code = NULL,
		@tax_city_pct = NULL,
		@tax_county_pct = NULL,
		@tax_state_pct = NULL,
		@tax_resale = NULL,
		@taxapplyc = NULL,
		@taxapplyln = NULL,
		@taxapplynd = NULL,
		@taxapplync = NULL,
		@taxapplyr = NULL,
		@taxapplyai = NULL,
		@reconcile_flag_d = NULL,
		@billing_amt = NULL,
		@est_nbr = NULL,
		@est_line_nbr = NULL,
		@est_rev_nbr = NULL,
		@ad_number = NULL,		
		@mat_comp = NULL,
		@units_d = NULL,

		--tv/ra
		@cost_type = NULL,	
		@cost_rate = NULL,	
		@net_base_rate = NULL,
		@gross_base_rate = NULL,
		@programming = NULL,
		@start_time = NULL,
		@end_time = NULL,
		@length = NULL,
		@remarks = NULL,
		@tag = NULL,
		@network_id = NULL,
		--PJH 08/18/17 - added new columns
		@cable_network_station_code = NULL,
		@daypart_id = NULL,
		@added_value = NULL,
		@bookend = NULL,
		@link_line_number = NULL,
		@vendor_order_line = NULL,

		--all non-brdcast
		@headline = NULL,

		--ma/np
		@size = NULL,
		@edition_issue = NULL,
		@material = NULL,
		@section = NULL,
		@rate_card_id = NULL,
		@rate_dtl_id = NULL,
		@contract_qty = NULL,
		@flat_net = NULL,
		@flat_gross = NULL,
		@prod_charge = NULL,
		@prod_desc = NULL,
		@color_charge = NULL,
		@color_desc = NULL,

		--np
		@print_columns = NULL,
		@print_inches = NULL,
		@print_lines = NULL,
		@np_circulation = NULL,
		@print_quantity = NULL,

		--ma
		@bleed_pct = NULL,
		@bleed_amt = NULL,
		@position_pct = NULL,
		@position_amt = NULL,
		@premium_pct = NULL,
		@premium_amt = NULL,

		--ma/np
		@flat_netcharge = NULL,
		@flat_addl_charge = NULL,
		@flat_discount_amt = NULL,

		--ma
		@production_size = NULL,
		@size_code = NULL,
		@mg_circulation = NULL,

		--in/od
		@o_type = NULL,	
		@url_location = NULL,	
		@copy_area = NULL,
		@rate_card = NULL,
		@rate_type = NULL,
		@rate_desc = NULL,

		--in
		@proj_impressions = NULL, 
		@guaranteed_impress = NULL, 
		@target_audience = NULL, 
		@creative_size = NULL,
		@placement_1 = NULL,
		@placement_2 = NULL,
		@act_impressions = NULL,
		@ad_server_placement_id = NULL,	
		@ad_server_created_by = NULL,
		@ad_server_created_datetime = NULL,
		@ad_server_last_modified_by = NULL,
		@ad_server_last_modified_datetime = NULL,
		@ad_server_placement_manual = NULL,
		@package_parent = NULL,
		@ad_server_placement_group_id = NULL,

		@line_ad_server_id = NULL,
		@line_market_code = NULL,

		--coments & status
		@is_quote = NULL,
		@prc_status = NULL,
		@instructions = NULL,
		@order_copy = NULL,
		@matl_notes = NULL,
		@position_info = NULL,
		@close_info = NULL,
		@rate_info = NULL,
		@misc_info = NULL,
		@in_house_cmts = NULL,

		--product defaults
		@prd_bill_type_flag = NULL,

		--Print_ORDERS overrides
		--@comm_pct_or = NULL,
		--@markup_pct_or = NULL,
		--@rebate_pct_or = NULL,
		--@rebate_amt_or = NULL,
	
		--OTHERS
		@air_date = NULL,
		@delete_order = NULL,
		@media_interface = NULL,
		@line_comment = NULL,
		@p1_52 = NULL,
		@existing_vn_code = NULL,
		@sales_class_code = NULL,
		@ad_server_id = NULL
				
	IF @media_type_in = 'N' BEGIN

		/** Get current Values if they exist **/
		
		IF @hdr_exists = 1
			--SELECT 'GET HDR INFO FOR ORDER: ' + CAST(@order_nbr AS VARCHAR(20)) /** DEBUG **/
			SELECT
			   @order_desc   = [ORDER_DESC]
			  ,@cmp_code   = [CMP_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]
			  ,@status   = [STATUS]
			  ,@order_date   = [ORDER_DATE]
			  ,@buyer   = [BUYER]
			  ,@order_comment   = [ORDER_COMMENT]
			  ,@house_comment   = [HOUSE_COMMENT]
			  ,@pub_station   = [PUB]
			  ,@rep1   = [REP1]
			  ,@rep2   = [REP2]
			  ,@bill_coop_code   = [BILL_COOP_CODE]
			  ,@ord_process_contrl   = [ORD_PROCESS_CONTRL]
			  ,@market_code   = [MARKET_CODE]
			  ,@units   = [UNITS]
			  ,@net_gross   = [NET_GROSS]
			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  ,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			  ,@buyer_emp_code = [BUYER_EMP_CODE]
			FROM NEWSPAPER_HEADER
			WHERE ORDER_NBR = @order_nbr	
		
		IF @dtl_exists = 1 BEGIN
			SELECT @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
					   @matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE], @size=[SIZE], 
					   @ad_number=[AD_NUMBER], @headline=[HEADLINE], @material=[MATERIAL], @edition_issue=[EDITION_ISSUE], @section = [SECTION],
					   @job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR], @rate_card_id=[RATE_CARD_ID], @rate_dtl_id=[RATE_DTL_ID],
					   @print_columns=[PRINT_COLUMNS], @print_inches=[PRINT_INCHES], @print_lines=[PRINT_LINES], @contract_qty=[CONTRACT_QTY],
					   @quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], @flat_net=[FLAT_NET], @flat_gross=[FLAT_GROSS], 
					   @ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT], @comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT],
					   @discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC], @state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], 
					   @non_resale_amt=[NON_RESALE_AMT], @netcharge=[NETCHARGE], @ncdesc=[NETCHARGE_DESC],
					   @addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], @prod_charge=[PROD_CHARGE], @prod_desc=[PROD_DESC], 
					   @color_charge=[COLOR_CHARGE], @color_desc=[COLOR_DESC], @line_total=[LINE_TOTAL], --[LINE_CANCELLED],
					   @date_to_bill=[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
					   @markup_pct=[MARKUP_PCT], @rebate_pct=[REBATE_PCT], @discount_pct=[DISCOUNT_PCT], @tax_code=[TAX_CODE], 
					   @tax_city_pct=[TAX_CITY_PCT], @tax_county_pct=[TAX_COUNTY_PCT], @tax_state_pct=[TAX_STATE_PCT], @tax_resale=[TAX_RESALE],
					   @taxapplyc=[TAXAPPLYC], @taxapplyln=[TAXAPPLYLN], @taxapplynd=[TAXAPPLYND], @taxapplync=[TAXAPPLYNC], 
					   @taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], @reconcile_flag=[RECONCILE_FLAG],
					   ----[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
					   ----[GLACODE_COUNTY], [GLACODE_CITY], 
					   @non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS], 
					   @bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT],							   
					   ----[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
					   @billing_amt=[BILLING_AMT], --[BILL_CANCELLED],
					   @est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR], @flat_netcharge=[FLAT_NETCHARGE], @flat_addl_charge=[FLAT_ADDL_CHARGE], 
					   @flat_discount_amt=[FLAT_DISCOUNT_AMT], @production_size=[PRODUCTION_SIZE], @mat_comp=[MAT_COMP], @size_code=[SIZE_CODE], 
					   @cost_type=[COST_TYPE], @cost_rate=[COST_RATE], @rate_type=[RATE_TYPE], @np_circulation=[NP_CIRCULATION], @print_quantity=[PRINT_QUANTITY]
			FROM [dbo].[NEWSPAPER_DETAIL] 
			WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1	;	
			
			/* PJH 02/04/16 - Added */
			SELECT @instructions = [INSTRUCTIONS], @order_copy = [ORDER_COPY], @matl_notes = [MATL_NOTES], @misc_info = [MISC_INFO], /***/
						@position_info = [POSITION_INFO], @close_info = [CLOSE_INFO], @rate_info = [RATE_INFO], @in_house_cmts = [IN_HOUSE_CMTS]
			FROM [dbo].[NEWSPAPER_COMMENTS] 
			WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr			
			
			--SELECT @netcharge = SUM([AMOUNT]) FROM [dbo].[NEWSPAPER_OTH_CHGS] WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'NC'
			--SELECT @color_charge = SUM([AMOUNT]) FROM [dbo].[NEWSPAPER_OTH_CHGS] WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'RC'
			--SELECT @addl_charge = SUM([AMOUNT]) FROM [dbo].[NEWSPAPER_OTH_CHGS] WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'AG'
				
		END		
		ELSE BEGIN  /* Set defaults to 0 if new line */
			SELECT @color_charge = 0, @flat_netcharge = 0, @netcharge = 0, @flat_addl_charge = 0, @addl_charge = 0
		END
		
		SELECT
			 @order_desc   = [ORDER_DESC]
			,@cl_code   = [ADVERTISER_CODE]
			,@div_code   = [BRAND_CODE]
			,@prd_code   = [PROD_CODE]
			,@cmp_code   = COALESCE([CAMP_CODE], @cmp_code)
			,@media_type   = [MEDIA_TYPE]
			,@sales_class_code   = COALESCE([SALES_CLASS_CODE], @sales_class_code)
			,@vn_code   = [VENDOR_CODE]
			,@vr_code   = COALESCE([VR_CODE], @vr_code)
			,@vr_code2   = COALESCE([VR_CODE2], @vr_code2)
			,@client_po = CASE @hdr_exists WHEN 1 THEN @client_po ELSE [CLIENT_PO] END /** Set on New only */
			--,@order_date   = @date_time_w
			,@buyer   = COALESCE([BUYER_NAME], @buyer)  --PJH 08/24/16 - Change BUYER to BUYER_NAME
			,@order_comment   = COALESCE([ORDER_COMMENT], @order_comment)
			,@rep1   = COALESCE([VR_CODE], @rep1)
			,@rep2   = COALESCE([VR_CODE2], @rep2)
			,@market_code   = COALESCE([MARKET_CODE], @market_code)
			,@start_date   = [INSERT_DATE]  /* MIN START DATE FOR LINES */
			,@end_date   = [END_DATE]  /* MAX END DATE FOR LINES */
			,@net_gross   = CASE [AGENCY_NET_RATE] WHEN 1 THEN 0 ELSE 1 END /* [NET_GROSS] */
			,@create_date   = @date_time_w
			--,@user_id   = @user_id
			--,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			,@link_id   = [ACCT_ORD_NBR]	
			--,@modified_by   = @user_id
			,@modified_date   = @date_time_w				
			
			/* DETAIL */
			,@link_detid = CAST([ITEM_NBR] AS INT)
			,@start_date = [INSERT_DATE]
			,@end_date = [END_DATE]
			,@size = COALESCE(LEFT([AD_SIZE], 30), @size)
			,@ad_number = COALESCE([AD_NUMBER], @ad_number)
			,@headline = COALESCE(CASE [CAPTION] WHEN '' THEN NULL ELSE [CAPTION] END, @headline)
			,@material = COALESCE([MATERIAL], @material)
			,@edition_issue = COALESCE([ZONE], @edition_issue)
			,@section = COALESCE([SECTION_ISSUE], @section)
			,@size_code = COALESCE([SIZE_CODE], @size_code)
			,@production_size = COALESCE([PRODUCTION_SIZE], @production_size)
			/**************/
			,@job_number = COALESCE([JOB_NUMBER], @job_number), @job_component_nbr = COALESCE([JOB_COMPONENT_NBR], @job_component_nbr)
			,@creative_size = COALESCE(CASE [CREATIVE_SIZE] WHEN '' THEN NULL ELSE [CREATIVE_SIZE] END, @creative_size)
			,@o_type =  COALESCE(CASE [INTERNET_TYPE] WHEN '' THEN NULL ELSE [INTERNET_TYPE] END, @o_type)
			,@url_location = COALESCE(CASE [URL] WHEN '' THEN NULL ELSE [URL] END, @url_location)
			,@placement_1 = COALESCE(CASE [LOCATION] WHEN '' THEN NULL ELSE [LOCATION] END, @placement_1)
			/**************/
			,@color_charge = COALESCE([PREMIUM_CHGS],@color_charge), @color_desc = NULL
			,@rate = [RATE_PER]
			,@net_rate = [RATE_PER], @gross_rate = [RATE_PER], @flat_net = [RATE_PER], @flat_gross = [RATE_PER]
			,@flat_netcharge = COALESCE([FLAT_NETCHARGE],@flat_netcharge) --
			,@netcharge = COALESCE([FLAT_NETCHARGE],@netcharge), @ncdesc = NULL
			,@flat_addl_charge  = COALESCE([FLAT_ADDL_CHARGE], @flat_addl_charge)
			,@addl_charge = COALESCE([FLAT_ADDL_CHARGE], @addl_charge), @addl_charge_desc = NULL
			,@print_columns = [PRINT_COLUMNS] , @print_inches = [PRINT_INCHES], @print_lines = [PRINT_LINES]
			,@cost_type = COALESCE([COST_TYPE], @cost_type)
			,@cost_rate = COALESCE([COST_RATE], @cost_rate)
			,@rate_type = COALESCE([RATE_TYPE], @rate_type)

			,@markup_pct_or = [MARKUP_PCT], @rebate_pct_or = [REBATE_PCT], @rebate_amt_or = [REBATE_AMT], @comm_pct_or = [COMM_PCT]

			,@is_quote = IS_QUOTE /* STATUS on Order Hdr */
			,@prc_status = PRC_STATUS
			,@instructions = COALESCE(CASE [LINE_COMMENT] WHEN '' THEN NULL ELSE [LINE_COMMENT] END, @instructions) /* INSTRUCTIONS */
			,@order_copy = COALESCE(CASE CAST([ORDER_COPY] AS varchar (max)) WHEN '' THEN NULL ELSE [ORDER_COPY] END, @order_copy) 
			,@matl_notes = COALESCE(CASE CAST([MATL_NOTES] AS varchar (max)) WHEN '' THEN NULL ELSE [MATL_NOTES] END, @matl_notes)
			,@position_info = COALESCE(CASE CAST([POSITION_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [POSITION_INFO] END, @position_info)
			,@close_info = COALESCE(CASE CAST([CLOSE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [CLOSE_INFO] END, @close_info)
			,@rate_info = COALESCE(CASE CAST([RATE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [RATE_INFO] END, @rate_info)
			,@misc_info = COALESCE(CASE CAST([MISC_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [MISC_INFO] END, @misc_info)
			,@in_house_cmts = COALESCE(CASE CAST([IN_HOUSE_CMTS] AS varchar (max)) WHEN '' THEN NULL ELSE [IN_HOUSE_CMTS] END, @in_house_cmts)
			,@buyer_emp_code = COALESCE([BUYER_EMP_CODE], @buyer_emp_code)
			,@units = COALESCE([UNITS], @units)
			,@np_circulation = COALESCE([CIRCULATION], @np_circulation)
		FROM @tmp_orders
		WHERE RowID = @ROW_ID

		--PJH 05/23/18 - Only set order_date = @date_time_w if header record does not exist (i.e. New Order)
		IF @hdr_exists = 0 
			SET @order_date   = @date_time_w

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @date_to_bill=NULL --@ext_close_date=NULL, @ext_matl_date=NULL, @close_date=NULL, @matl_close_date=NULL, 

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		SET @addl_charge_desc = CASE WHEN (@addl_charge IS NULL OR @addl_charge = 0) THEN NULL ELSE 'Additional Charge' END
		SET @ncdesc = CASE WHEN (@netcharge IS NULL OR @netcharge = 0) THEN NULL ELSE 'Net Charge' END
		SET @color_desc = CASE WHEN (@color_charge IS NULL OR @color_charge = 0) THEN NULL ELSE 'Color Charge' END 
		
		SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
		
		IF @cost_type= 'CPM' BEGIN
			IF @units = 'D' BEGIN
				SET @units = 'W'
			END
		END
	END /* End NP */
	
	IF @media_type_in = 'M' BEGIN

		/** Get current Values if they exist **/
		
		IF @hdr_exists = 1 BEGIN
			--SELECT 'GET HDR INFO FOR ORDER: ' + CAST(@order_nbr AS VARCHAR(20)) /** DEBUG **/
			SELECT
			   @order_desc   = [ORDER_DESC]

			  ,@cmp_code   = [CMP_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]

			  ,@status   = [STATUS]
			  ,@order_date   = [ORDER_DATE]
			  ,@buyer   = [BUYER]
			  ,@order_comment   = [ORDER_COMMENT]
			  ,@house_comment   = [HOUSE_COMMENT]
			  ,@pub_station   = [PUB]
			  ,@rep1   = [REP1]
			  ,@rep2   = [REP2]
			  ,@bill_coop_code   = [BILL_COOP_CODE]
			  ,@ord_process_contrl   = [ORD_PROCESS_CONTRL]
			  ,@market_code   = [MARKET_CODE]

			  ,@units   = [UNITS]

			  ,@net_gross   = [NET_GROSS]

			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  ,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			  ,@buyer_emp_code = [BUYER_EMP_CODE]
			FROM MAGAZINE_HEADER
			WHERE ORDER_NBR = @order_nbr	
		END

		IF @dtl_exists = 1 BEGIN
			SELECT @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
							@matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE], @size=[SIZE], 
							@ad_number=[AD_NUMBER], @headline=[HEADLINE], @material=[MATERIAL], @edition_issue=[EDITION_ISSUE], @section = [SECTION],
							@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR], @rate_card_id=[RATE_CARD_ID], @rate_dtl_id=[RATE_DTL_ID],							
							@contract_qty=[CONTRACT_QTY],
							@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], @flat_net=[FLAT_NET], @flat_gross=[FLAT_GROSS], 
							@ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT], @comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT],
							@discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC], @state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], 
							@non_resale_amt=[NON_RESALE_AMT], @netcharge=[NETCHARGE], @ncdesc=[NETCHARGE_DESC],
							@addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], @prod_charge=[PROD_CHARGE], @prod_desc=[PROD_DESC], 
							@color_charge=[COLOR_CHARGE], @color_desc=[COLOR_DESC], 
							@bleed_pct = [BLEED_PCT], @bleed_amt = [BLEED_AMT], @position_pct = [POSITION_PCT], @position_amt = [POSITION_AMT],
							@premium_pct = [PREMIUM_PCT], @premium_amt = [PREMIUM_AMT], @line_total=[LINE_TOTAL], --[LINE_CANCELLED],
							@date_to_bill=[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							@markup_pct=[MARKUP_PCT], @rebate_pct=[REBATE_PCT], @discount_pct=[DISCOUNT_PCT], @tax_code=[TAX_CODE], 
							@tax_city_pct=[TAX_CITY_PCT], @tax_county_pct=[TAX_COUNTY_PCT], @tax_state_pct=[TAX_STATE_PCT], @tax_resale=[TAX_RESALE],
							@taxapplyc=[TAXAPPLYC], @taxapplyln=[TAXAPPLYLN], @taxapplynd=[TAXAPPLYND], @taxapplync=[TAXAPPLYNC], 
							@taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], @reconcile_flag=[RECONCILE_FLAG],
							----[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							----[GLACODE_COUNTY], [GLACODE_CITY], 
							@non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS], 
							@bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT],							   
							----[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							@billing_amt=[BILLING_AMT], --[BILL_CANCELLED],
							@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR], @flat_netcharge=[FLAT_NETCHARGE], @flat_addl_charge=[FLAT_ADDL_CHARGE], 
							@flat_discount_amt=[FLAT_DISCOUNT_AMT], @production_size=[PRODUCTION_SIZE], @mat_comp=[MAT_COMP], @size_code=[SIZE_CODE], 
							@mg_circulation = [MG_CIRCULATION]
			FROM [dbo].[MAGAZINE_DETAIL] 
			WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1	;	
			
			/* PJH 02/04/16 - Added */
			SELECT @instructions = [INSTRUCTIONS], @order_copy = [ORDER_COPY], @matl_notes = [MATL_NOTES], @misc_info = [MISC_INFO], /***/
						@position_info = [POSITION_INFO], @close_info = [CLOSE_INFO], @rate_info = [RATE_INFO], @in_house_cmts = [IN_HOUSE_CMTS]
			FROM [dbo].[MAGAZINE_COMMENTS] 
			WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr			
		END
		ELSE BEGIN  /* Set defaults to 0 if new line */
			SELECT @color_charge = 0, @flat_netcharge = 0, @netcharge = 0, @flat_addl_charge = 0, @addl_charge = 0
		END

		SELECT
			 @order_desc   = [ORDER_DESC]
			,@cl_code   = [ADVERTISER_CODE]
			,@div_code   = [BRAND_CODE]
			,@prd_code   = [PROD_CODE]

			,@cmp_code   = COALESCE([CAMP_CODE], @cmp_code)
			,@media_type   = [MEDIA_TYPE]
			,@sales_class_code   = COALESCE([SALES_CLASS_CODE], @sales_class_code)
			,@vn_code   = [VENDOR_CODE]
			,@vr_code   = COALESCE([VR_CODE], @vr_code)
			,@vr_code2   = COALESCE([VR_CODE2], @vr_code2)
			,@client_po = CASE @hdr_exists WHEN 1 THEN @client_po ELSE [CLIENT_PO] END /** Set on New only */
			--,@order_date   = @date_time_w
			,@buyer   = COALESCE([BUYER_NAME], @buyer)  --PJH 08/24/16 - Change BUYER to BUYER_NAME
			,@order_comment   = COALESCE([ORDER_COMMENT], @order_comment)
			,@rep1   = COALESCE([VR_CODE], @rep1)
			,@rep2   = COALESCE([VR_CODE2], @rep2)
			,@market_code   = COALESCE([MARKET_CODE], @market_code)
			,@start_date   = [INSERT_DATE]  /* MIN START DATE FOR LINES */
			,@end_date   = [END_DATE]  /* MAX END DATE FOR LINES */
			,@net_gross   = CASE [AGENCY_NET_RATE] WHEN 1 THEN 0 ELSE 1 END /* [NET_GROSS] */
			,@create_date   = @date_time_w
			--,@user_id   = @user_id
			--,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			,@link_id   = [ACCT_ORD_NBR]	
			--,@modified_by   = @user_id
			,@modified_date   = @date_time_w				
		
			/* DETAIL */
			,@link_detid = CAST([ITEM_NBR] AS INT)
			,@start_date = [INSERT_DATE]
			,@end_date = [END_DATE]
			,@size = COALESCE(LEFT([AD_SIZE], 30), @size)
			,@ad_number = COALESCE([AD_NUMBER], @ad_number)
			,@headline = COALESCE(CASE [CAPTION] WHEN '' THEN NULL ELSE [CAPTION] END, @headline)
			,@material = COALESCE([MATERIAL], @material)
			,@edition_issue = COALESCE([SECTION_ISSUE], @edition_issue) --[ZONE] --
			,@section = COALESCE([SECTION_ISSUE], @section)
			,@size_code = COALESCE([SIZE_CODE], @size_code)
			,@production_size = COALESCE([PRODUCTION_SIZE], @production_size)
			/**************/
			,@job_number = COALESCE([JOB_NUMBER], @job_number), @job_component_nbr = COALESCE([JOB_COMPONENT_NBR], @job_component_nbr)
			,@creative_size = COALESCE(CASE [CREATIVE_SIZE] WHEN '' THEN NULL ELSE [CREATIVE_SIZE] END, @creative_size)
			,@o_type =  COALESCE(CASE [INTERNET_TYPE] WHEN '' THEN NULL ELSE [INTERNET_TYPE] END, @o_type)
			,@url_location = COALESCE(CASE [URL] WHEN '' THEN NULL ELSE [URL] END, @url_location)
			,@placement_1 = COALESCE(CASE [LOCATION] WHEN '' THEN NULL ELSE [LOCATION] END, @placement_1)
			/**************/
			,@color_charge = COALESCE([PREMIUM_CHGS],@color_charge), @color_desc = 'Color Charge' --
			,@rate = [RATE_PER]
			,@net_rate = [RATE_PER], @gross_rate = [RATE_PER], @flat_net = [RATE_PER], @flat_gross = [RATE_PER]

			,@flat_netcharge = COALESCE([FLAT_NETCHARGE],@flat_netcharge) --
			,@netcharge = COALESCE([FLAT_NETCHARGE],@netcharge), @ncdesc = 'Net Charge' --
			,@flat_addl_charge  = COALESCE([FLAT_ADDL_CHARGE], @flat_addl_charge) --
			,@addl_charge = COALESCE([FLAT_ADDL_CHARGE], @addl_charge), @addl_charge_desc =	'Additional Charge' 
			,@print_columns = [PRINT_COLUMNS] , @print_inches = [PRINT_INCHES], @print_lines = [PRINT_LINES]
			,@cost_type = COALESCE([COST_TYPE], @cost_type)
			,@cost_rate = COALESCE([COST_RATE], @cost_rate)
			,@rate_type = COALESCE([RATE_TYPE], @rate_type)	

			,@markup_pct_or = [MARKUP_PCT], @rebate_pct_or = [REBATE_PCT], @rebate_amt_or = [REBATE_AMT], @comm_pct_or = [COMM_PCT]

			,@is_quote = IS_QUOTE /* STATUS on Order Hdr */
			,@prc_status = PRC_STATUS
			,@instructions = COALESCE(CASE [LINE_COMMENT] WHEN '' THEN NULL ELSE [LINE_COMMENT] END, @instructions) /* INSTRUCTIONS */
			,@order_copy = COALESCE(CASE CAST([ORDER_COPY] AS varchar (max)) WHEN '' THEN NULL ELSE [ORDER_COPY] END, @order_copy)
			,@matl_notes = COALESCE(CASE CAST([MATL_NOTES] AS varchar (max)) WHEN '' THEN NULL ELSE [MATL_NOTES] END, @matl_notes)
			,@position_info = COALESCE(CASE CAST([POSITION_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [POSITION_INFO] END, @position_info)
			,@close_info = COALESCE(CASE CAST([CLOSE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [CLOSE_INFO] END, @close_info)
			,@rate_info = COALESCE(CASE CAST([RATE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [RATE_INFO] END, @rate_info)
			,@misc_info = COALESCE(CASE CAST([MISC_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [MISC_INFO] END, @misc_info)
			,@in_house_cmts = COALESCE(CASE CAST([IN_HOUSE_CMTS] AS varchar (max)) WHEN '' THEN NULL ELSE [IN_HOUSE_CMTS] END, @in_house_cmts)
			,@buyer_emp_code = COALESCE([BUYER_EMP_CODE], @buyer_emp_code)
			,@mg_circulation = COALESCE([CIRCULATION], @mg_circulation)
		FROM @tmp_orders
		WHERE RowID = @ROW_ID

		--PJH 05/23/18 - Only set order_date = @date_time_w if header record does not exist (i.e. New Order)
		IF @hdr_exists = 0 
			SET @order_date   = @date_time_w

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @date_to_bill=NULL --@ext_close_date=NULL, @ext_matl_date=NULL, , @close_date=NULL, @matl_close_date=NULL, 

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		SET @addl_charge_desc = CASE WHEN (@addl_charge IS NULL OR @addl_charge = 0) THEN NULL ELSE 'Additional Charge' END
		SET @ncdesc = CASE WHEN (@netcharge IS NULL OR @netcharge = 0) THEN NULL ELSE 'Net Charge' END
		SET @color_desc = CASE WHEN (@color_charge IS NULL OR @color_charge = 0) THEN NULL ELSE 'Color Charge' END 
		
		SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End MAG */
	
	IF @media_type_in = 'I' BEGIN

		/** Get current Values if they exist **/
		
		IF @hdr_exists = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]

			  ,@cmp_code   = [CMP_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]

			  ,@status   = [STATUS]
			  ,@order_date   = [ORDER_DATE]
			  ,@buyer   = [BUYER]
			  ,@order_comment   = [ORDER_COMMENT]
			  ,@house_comment   = [HOUSE_COMMENT]
			  ,@pub_station   = [PUB]
			  ,@rep1   = [REP1]
			  ,@rep2   = [REP2]
			  ,@bill_coop_code   = [BILL_COOP_CODE]
			  ,@ord_process_contrl   = [ORD_PROCESS_CONTRL]
			  ,@market_code   = [MARKET_CODE]

			  ,@units   = [UNITS]

			  ,@net_gross   = [NET_GROSS]

			  ,@modified_by   = [A].[MODIFIED_BY]
			  ,@modified_date   = [A].[MODIFIED_DATE]
			  ,@modified_comments   = [A].[MODIFIED_COMMENTS]
			  ,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			  ,@buyer_emp_code = [BUYER_EMP_CODE]
			  /* PJH 03/16/17 - 4674-1-25 - Lock certain fields on media order and line when Ad Server Placement ID exists on the order/line. */
			  ,@ad_server_id = [AD_SERVER_PLACEMENT_ID]
			  FROM INTERNET_HEADER A LEFT JOIN
				(SELECT MAX(COALESCE(AD_SERVER_PLACEMENT_ID, 0)) 'AD_SERVER_PLACEMENT_ID', MAX(ORDER_NBR) ORDER_NBR FROM INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr) B ON A.ORDER_NBR = B.ORDER_NBR
			WHERE A.ORDER_NBR = @order_nbr	

		END

		/*

		--, [INTERNET_TYPE], 
			, [INTERNET_TYPE] = CASE WHEN @ad_server_id > 0 THEN [INTERNET_TYPE] ELSE @o_type END

		*/

		IF @dtl_exists = 1 BEGIN
			SELECT @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
							@matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE], @size=[SIZE], 
							@ad_number=[AD_NUMBER], @headline=[HEADLINE], @o_type=[INTERNET_TYPE], 
							@proj_impressions=[PROJ_IMPRESSIONS], @guaranteed_impress=[GUARANTEED_IMPRESS], 
							@url_location=[URL], @target_audience=[TARGET_AUDIENCE], @copy_area=[COPY_AREA],
							@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR], @rate_card=[RATE_CARD], @rate_type=[RATE_TYPE], @rate_desc=[RATE_DESC],							
							@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE],  
							@ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT], @comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT],
							@discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC], @state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], 
							@non_resale_amt=[NON_RESALE_AMT], @netcharge=[NETCHARGE], @ncdesc=[NCDESC],
							@addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], 
							@line_total=[LINE_TOTAL], --[LINE_CANCELLED],
							@date_to_bill=[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							@markup_pct=[MARKUP_PCT], @rebate_pct=[REBATE_PCT], @discount_pct=[DISCOUNT_PCT], @tax_code=[TAX_CODE], 
							@tax_city_pct=[TAX_CITY_PCT], @tax_county_pct=[TAX_COUNTY_PCT], @tax_state_pct=[TAX_STATE_PCT], @tax_resale=[TAX_RESALE],
							@taxapplyc=[TAXAPPLYC], @taxapplyln=[TAXAPPLYLN], @taxapplynd=[TAXAPPLYND], @taxapplync=[TAXAPPLYNC], 
							@taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], @reconcile_flag=[RECONCILE_FLAG],
							----[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							----[GLACODE_COUNTY], [GLACODE_CITY], 
							@non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS], 
							@bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT],							   
							----[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							@billing_amt=[BILLING_AMT], --[BILL_CANCELLED],
							@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR],
							@mat_comp=[MAT_COMP], 
							@placement_1 = [PLACEMENT_1], @placement_2 = [PLACEMENT_2],  /***/
							@act_impressions=[ACT_IMPRESSIONS], @creative_size=[CREATIVE_SIZE],  /***/
						    @ad_server_placement_id = [AD_SERVER_PLACEMENT_ID],
						    @ad_server_created_by = [AD_SERVER_CREATED_BY],
						    @ad_server_created_datetime = [AD_SERVER_CREATED_DATETIME],
						    @ad_server_last_modified_by = [AD_SERVER_LAST_MODIFIED_BY],
						    @ad_server_last_modified_datetime = [AD_SERVER_LAST_MODIFIED_DATETIME],
							@ad_server_placement_manual = [AD_SERVER_PLACEMENT_MANUAL],
							@package_parent = [PACKAGE_PARENT],
							@ad_server_placement_group_id = [AD_SERVER_PLACEMENT_GROUP_ID],
							@line_ad_server_id = [AD_SERVER_ID], --PJH 12/06/18 - Added @line_market_code, @line_ad_server_id
							@line_market_code = [MARKET_CODE],
							@channel = [MEDIA_CHANNEL_ID],
							@tactic = [MEDIA_TACTIC_ID]
			FROM [dbo].[INTERNET_DETAIL] 
			WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1	;	
			
			/* PJH 02/04/16 - Added */
			SELECT @instructions = [INSTRUCTIONS], @order_copy = [ORDER_COPY], @matl_notes = [MATL_NOTES], @misc_info = [MISC_INFO] /***/
			FROM [dbo].[INTERNET_COMMENTS] 
			WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		END
		ELSE BEGIN  /* Set defaults to 0 if new line */
			SELECT @color_charge = 0, @flat_netcharge = 0, @netcharge = 0, @flat_addl_charge = 0, @addl_charge = 0
		END

		SELECT
			 @order_desc   = [ORDER_DESC]
			,@cl_code   = [ADVERTISER_CODE]
			,@div_code   = [BRAND_CODE]
			,@prd_code   = [PROD_CODE]
			 /* PJH 03/16/17 - 4674-1-25 - Lock certain fields on media order and line when Ad Server Placement ID exists on the order/line. */
			--,@cmp_code   = COALESCE([CAMP_CODE], @cmp_code) /***/
			,@cmp_code = CASE WHEN @ad_server_id > 0 --any line has id
									THEN @cmp_code --keep original
									ELSE (COALESCE([CAMP_CODE], @cmp_code))  
								END
			,@media_type   = [MEDIA_TYPE]
			,@sales_class_code   = COALESCE([SALES_CLASS_CODE], @sales_class_code)
			,@vn_code   = [VENDOR_CODE]
			,@vr_code   = COALESCE([VR_CODE], @vr_code)
			,@vr_code2   = COALESCE([VR_CODE2], @vr_code2)
			,@client_po = CASE @hdr_exists WHEN 1 THEN @client_po ELSE [CLIENT_PO] END /** Set on New only */
			--,@order_date   = @date_time_w
			,@buyer   = COALESCE([BUYER_NAME], @buyer)  --PJH 08/24/16 - Change BUYER to BUYER_NAME
			,@order_comment   = COALESCE([ORDER_COMMENT], @order_comment)
			,@rep1   = COALESCE([VR_CODE], @rep1)
			,@rep2   = COALESCE([VR_CODE2], @rep2)
			,@market_code   = COALESCE([MARKET_CODE], @market_code)
			,@start_date   = [INSERT_DATE]  /* MIN START DATE FOR LINES */
			,@end_date   = [END_DATE]  /* MAX END DATE FOR LINES */
			,@net_gross   = CASE [AGENCY_NET_RATE] WHEN 1 THEN 0 ELSE 1 END /* [NET_GROSS] */
			,@create_date   = @date_time_w
			--,@user_id   = @user_id
			--,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			,@link_id   = [ACCT_ORD_NBR]	
			--,@modified_by   = @user_id
			,@modified_date   = @date_time_w				
		
			/* DETAIL */
			,@link_detid = CAST([ITEM_NBR] AS INT)
			,@start_date = [INSERT_DATE]
			,@end_date = [END_DATE]
			,@size = COALESCE([SIZE_CODE], @size)
			,@ad_number = COALESCE([AD_NUMBER], @ad_number)
			,@headline = COALESCE(CASE [CAPTION] WHEN '' THEN NULL ELSE [CAPTION] END, @headline)
			,@material = COALESCE([MATERIAL], @material)
			,@edition_issue = COALESCE([SECTION_ISSUE], @edition_issue) --[ZONE] --
			,@section = COALESCE([SECTION_ISSUE], @section)
			,@size_code = COALESCE([SIZE_CODE], @size_code)
			,@production_size = COALESCE([PRODUCTION_SIZE], @production_size)
			/**************/
			,@job_number = COALESCE([JOB_NUMBER], @job_number), @job_component_nbr = COALESCE([JOB_COMPONENT_NBR], @job_component_nbr)
			,@creative_size = COALESCE(CASE [CREATIVE_SIZE] WHEN '' THEN NULL ELSE [CREATIVE_SIZE] END, @creative_size)
			/* @copy_area = INTENET Detail "File Size"- Not mapped from planning */
			--,@copy_area = COALESCE(CASE [CREATIVE_SIZE] WHEN '' THEN NULL ELSE [CREATIVE_SIZE] END, @creative_size) /***/
			--,@o_type =  COALESCE(CASE [INTERNET_TYPE] WHEN '' THEN NULL ELSE [INTERNET_TYPE] END, @o_type)
			/* PJH 03/16/17 - 4674-1-25 - Lock certain fields on media order and line when Ad Server Placement ID exists on the order/line. */
			,@o_type = CASE WHEN @ad_server_placement_id > 0 
									THEN @o_type --keep original
									ELSE (COALESCE(CASE [INTERNET_TYPE] WHEN '' THEN NULL ELSE [INTERNET_TYPE] END, @o_type))  
								END
			,@url_location = COALESCE(CASE [URL] WHEN '' THEN NULL ELSE [URL] END, @url_location)
			,@target_audience = COALESCE([ZONE], @target_audience)  /***/
			,@placement_1 = COALESCE(CASE [LOCATION] WHEN '' THEN NULL ELSE [LOCATION] END, @placement_1)
			,@proj_impressions = COALESCE([PROJ_IMPRESSIONS], @proj_impressions)
			,@guaranteed_impress = COALESCE([GUARANTEED_IMPRESS], @guaranteed_impress)
			/**************/
			,@color_charge = COALESCE([PREMIUM_CHGS],@color_charge), @color_desc = 'Color Charge' --
			,@rate = [RATE_PER]
			,@net_rate = [RATE_PER], @gross_rate = [RATE_PER], @flat_net = [RATE_PER], @flat_gross = [RATE_PER]

			,@flat_netcharge = COALESCE([FLAT_NETCHARGE],@flat_netcharge) --
			,@netcharge = COALESCE([FLAT_NETCHARGE],@netcharge), @ncdesc = 'Net Charge' --
			,@flat_addl_charge  = COALESCE([FLAT_ADDL_CHARGE], @flat_addl_charge) --
			,@addl_charge = COALESCE([FLAT_ADDL_CHARGE], @addl_charge), @addl_charge_desc =	'Additional Charge' 
			,@print_columns = [PRINT_COLUMNS] , @print_inches = [PRINT_INCHES], @print_lines = [PRINT_LINES]
			,@cost_type = COALESCE([COST_TYPE], @cost_type)
			,@cost_rate = COALESCE([COST_RATE], @cost_rate)
			,@rate_type = COALESCE([RATE_TYPE], @rate_type)		

			,@markup_pct_or = [MARKUP_PCT], @rebate_pct_or = [REBATE_PCT], @rebate_amt_or = [REBATE_AMT], @comm_pct_or = [COMM_PCT]

			,@is_quote = IS_QUOTE /* STATUS on Order Hdr */
			,@prc_status = PRC_STATUS
			,@instructions = COALESCE(CASE [LINE_COMMENT] WHEN '' THEN NULL ELSE [LINE_COMMENT] END, @instructions) /* INSTRUCTIONS */
			,@order_copy = COALESCE(CASE CAST([ORDER_COPY] AS varchar (max)) WHEN '' THEN NULL ELSE [ORDER_COPY] END, @order_copy)
			,@matl_notes = COALESCE(CASE CAST([MATL_NOTES] AS varchar (max)) WHEN '' THEN NULL ELSE [MATL_NOTES] END, @matl_notes)
			,@position_info = COALESCE(CASE CAST([POSITION_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [POSITION_INFO] END, @position_info)
			,@close_info = COALESCE(CASE CAST([CLOSE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [CLOSE_INFO] END, @close_info)
			,@rate_info = COALESCE(CASE CAST([RATE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [RATE_INFO] END, @rate_info)
			,@misc_info = COALESCE(CASE CAST([MISC_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [MISC_INFO] END, @misc_info)
			,@in_house_cmts = COALESCE(CASE CAST([IN_HOUSE_CMTS] AS varchar (max)) WHEN '' THEN NULL ELSE [IN_HOUSE_CMTS] END, @in_house_cmts)
			,@buyer_emp_code = COALESCE([BUYER_EMP_CODE], @buyer_emp_code)
			,@line_market_code   = COALESCE([LINE_MARKET_CODE], @line_market_code) --PJH 12/06/18 - Added market_code
			,@channel = COALESCE([MEDIA_CHANNEL_ID], @channel)
			,@tactic = COALESCE([MEDIA_TACTIC_ID], @tactic)
		FROM @tmp_orders
		WHERE RowID = @ROW_ID

		--PJH 05/23/18 - Only set order_date = @date_time_w if header record does not exist (i.e. New Order)
		IF @hdr_exists = 0 
			SET @order_date   = @date_time_w

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @date_to_bill=NULL  --@ext_close_date=NULL, @ext_matl_date=NULL, @close_date=NULL, @matl_close_date=NULL,  /***/

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		--IF @DEBUG = 1
		--	SELECT 'IN' 'IN', @order_nbr '@order_nbr', @line_nbr '@line_nbr', @existing_vn_code '@existing_vn_code', @vn_code '@vn_code', @vr_code2 'ORDER @vr_code2', @client_po '@client_po'	 		  /* DEBUG */

		SET @addl_charge_desc = CASE WHEN (@addl_charge IS NULL OR @addl_charge = 0) THEN NULL ELSE 'Additional Charge' END
		SET @ncdesc = CASE WHEN (@netcharge IS NULL OR @netcharge = 0) THEN NULL ELSE 'Net Charge' END
		SET @color_desc = CASE WHEN (@color_charge IS NULL OR @color_charge = 0) THEN NULL ELSE 'Color Charge' END 
		
		SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End INET */
	
	IF @media_type_in = 'O' BEGIN

		/** Get current Values if they exist **/
		
		IF @hdr_exists = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]

			  ,@cmp_code   = [CMP_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]

			  ,@status   = [STATUS]
			  ,@order_date   = [ORDER_DATE]
			  ,@buyer   = [BUYER]
			  ,@order_comment   = [ORDER_COMMENT]
			  ,@house_comment   = [HOUSE_COMMENT]
			  ,@pub_station   = [PUB]
			  ,@rep1   = [REP1]
			  ,@rep2   = [REP2]
			  ,@bill_coop_code   = [BILL_COOP_CODE]
			  ,@ord_process_contrl   = [ORD_PROCESS_CONTRL]
			  ,@market_code   = [MARKET_CODE]

			  ,@units   = [UNITS]

			  ,@net_gross   = [NET_GROSS]

			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  ,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			  ,@buyer_emp_code = [BUYER_EMP_CODE]
			FROM OUTDOOR_HEADER
			WHERE ORDER_NBR = @order_nbr	
		END

		IF @dtl_exists = 1 BEGIN
			SELECT @start_date=[POST_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
							@matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE], @size=[SIZE], 
							@ad_number=[AD_NUMBER], @headline=[HEADLINE], @url_location=[LOCATION], @copy_area=[COPY_AREA], @o_type=[OUTDOOR_TYPE], 
							@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR], @rate_card=[RATE_CARD], @rate_type=[RATE_TYPE], @rate_desc=[RATE_DESC],	
							@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], 
							@ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT], @comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT],
							@discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC], @state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], 
							@non_resale_amt=[NON_RESALE_AMT], @netcharge=[NETCHARGE], @ncdesc=[NCDESC],
							@addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], 
							@line_total=[LINE_TOTAL], --[LINE_CANCELLED],
							@date_to_bill=[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							@markup_pct=[MARKUP_PCT], @rebate_pct=[REBATE_PCT], @discount_pct=[DISCOUNT_PCT], @tax_code=[TAX_CODE], 
							@tax_city_pct=[TAX_CITY_PCT], @tax_county_pct=[TAX_COUNTY_PCT], @tax_state_pct=[TAX_STATE_PCT], @tax_resale=[TAX_RESALE],
							@taxapplyc=[TAXAPPLYC], @taxapplyln=[TAXAPPLYLN], @taxapplynd=[TAXAPPLYND], @taxapplync=[TAXAPPLYNC], 
							@taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], @reconcile_flag=[RECONCILE_FLAG],
							----[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							----[GLACODE_COUNTY], [GLACODE_CITY], 
							@non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS], 
							@bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT],							   
							----[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							@billing_amt=[BILLING_AMT], --[BILL_CANCELLED],
							@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR], 
							@mat_comp=[MAT_COMP], @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
			FROM [dbo].[OUTDOOR_DETAIL] 
			WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1	;	
			
			/* PJH 02/04/16 - Added */
			SELECT @instructions = [INSTRUCTIONS], @order_copy = [ORDER_COPY], @matl_notes = [MATL_NOTES], @misc_info = [MISC_INFO] /***/
			FROM [dbo].[OUTDOOR_COMMENTS] 
			WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr				
		END
		ELSE BEGIN  /* Set defaults to 0 if new line */
			SELECT @color_charge = 0, @flat_netcharge = 0, @netcharge = 0, @flat_addl_charge = 0, @addl_charge = 0
		END

		SELECT
			 @order_desc   = [ORDER_DESC]
			,@cl_code   = [ADVERTISER_CODE]
			,@div_code   = [BRAND_CODE]
			,@prd_code   = [PROD_CODE]

			,@cmp_code   = COALESCE([CAMP_CODE], @cmp_code)
			,@media_type   = [MEDIA_TYPE]
			,@sales_class_code   = COALESCE([SALES_CLASS_CODE], @sales_class_code)
			,@vn_code   = [VENDOR_CODE]
			,@vr_code   = COALESCE([VR_CODE], @vr_code)
			,@vr_code2   = COALESCE([VR_CODE2], @vr_code2)
			,@client_po = CASE @hdr_exists WHEN 1 THEN @client_po ELSE [CLIENT_PO] END /** Set on New only */
			--,@order_date   = @date_time_w
			,@buyer   = COALESCE([BUYER_NAME], @buyer)  --PJH 08/24/16 - Change BUYER to BUYER_NAME
			,@order_comment   = COALESCE([ORDER_COMMENT], @order_comment)
			,@rep1   = COALESCE([VR_CODE], @rep1)
			,@rep2   = COALESCE([VR_CODE2], @rep2)
			,@market_code   = COALESCE([MARKET_CODE], @market_code)
			,@start_date   = [INSERT_DATE]  /* MIN START DATE FOR LINES */
			,@end_date   = [END_DATE]  /* MAX END DATE FOR LINES */
			,@net_gross   = CASE [AGENCY_NET_RATE] WHEN 1 THEN 0 ELSE 1 END /* [NET_GROSS] */
			,@create_date   = @date_time_w
			--,@user_id   = @user_id
			--,@revised_flag   = [REVISED_FLAG]    /* PJH 06/10/16 */
			,@link_id   = [ACCT_ORD_NBR]	
			--,@modified_by   = @user_id
			,@modified_date   = @date_time_w				
		
			/* DETAIL */
			,@link_detid = CAST([ITEM_NBR] AS INT)
			,@start_date = [INSERT_DATE]
			,@end_date = [END_DATE]
			,@size = COALESCE([SIZE_CODE], @size)
			,@ad_number = COALESCE([AD_NUMBER], @ad_number)
			,@headline = COALESCE(CASE [CAPTION] WHEN '' THEN NULL ELSE [CAPTION] END, @headline)
			,@material = COALESCE([MATERIAL], @material)
			,@edition_issue = COALESCE([SECTION_ISSUE], @edition_issue) --[ZONE] --
			,@section = COALESCE([SECTION_ISSUE], @section)
			,@url_location = COALESCE(CASE [LOCATION] WHEN '' THEN NULL ELSE [LOCATION] END, @url_location) --CASE [URL] WHEN '' THEN NULL ELSE [URL] END
			,@size_code = COALESCE([SIZE_CODE], @size_code)
			,@production_size = COALESCE([PRODUCTION_SIZE], @production_size)
			/**************/
			,@job_number = COALESCE([JOB_NUMBER], @job_number), @job_component_nbr = COALESCE([JOB_COMPONENT_NBR], @job_component_nbr)
			,@creative_size = COALESCE(CASE [CREATIVE_SIZE] WHEN '' THEN NULL ELSE [CREATIVE_SIZE] END, @creative_size)
			,@o_type =  COALESCE(CASE [OUTDOOR_TYPE] WHEN '' THEN NULL ELSE [OUTDOOR_TYPE] END, @o_type)
			/* @copy_area - Not mapped from planning */
			--,@copy_area = COALESCE(CASE [CREATIVE_SIZE] WHEN '' THEN NULL ELSE [CREATIVE_SIZE] END, @creative_size)
			,@placement_1 = NULL, @placement_2 = NULL  --CASE [LOCATION] WHEN '' THEN NULL ELSE [LOCATION] END
			/**************/
			,@color_charge = COALESCE([PREMIUM_CHGS],0), @color_desc = 'Color Charge' --
			,@rate = [RATE_PER]
			,@net_rate = [RATE_PER], @gross_rate = [RATE_PER], @flat_net = [RATE_PER], @flat_gross = [RATE_PER]

			,@flat_netcharge = COALESCE([FLAT_NETCHARGE],@flat_netcharge) --
			,@netcharge = COALESCE([FLAT_NETCHARGE],@netcharge), @ncdesc = 'Net Charge' --
			,@flat_addl_charge  = COALESCE([FLAT_ADDL_CHARGE], @flat_addl_charge) --
			,@addl_charge = COALESCE([FLAT_ADDL_CHARGE], @addl_charge), @addl_charge_desc =	'Additional Charge' 
			,@print_columns = [PRINT_COLUMNS] , @print_inches = [PRINT_INCHES], @print_lines = [PRINT_LINES]
			,@cost_type = COALESCE([COST_TYPE], @cost_type)
			,@cost_rate = COALESCE([COST_RATE], @cost_rate)
			,@rate_type = COALESCE([RATE_TYPE], @rate_type)			

			,@markup_pct_or = [MARKUP_PCT], @rebate_pct_or = [REBATE_PCT], @rebate_amt_or = [REBATE_AMT], @comm_pct_or = [COMM_PCT]

			,@is_quote = IS_QUOTE /* STATUS on Order Hdr */
			,@prc_status = PRC_STATUS
			,@instructions = COALESCE(CASE [LINE_COMMENT] WHEN '' THEN NULL ELSE [LINE_COMMENT] END, @instructions) /* INSTRUCTIONS */
			,@order_copy = COALESCE(CASE CAST([ORDER_COPY] AS varchar (max)) WHEN '' THEN NULL ELSE [ORDER_COPY] END, @order_copy)
			,@matl_notes = COALESCE(CASE CAST([MATL_NOTES] AS varchar (max)) WHEN '' THEN NULL ELSE [MATL_NOTES] END, @matl_notes)
			,@position_info = COALESCE(CASE CAST([POSITION_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [POSITION_INFO] END, @position_info)
			,@close_info = COALESCE(CASE CAST([CLOSE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [CLOSE_INFO] END, @close_info)
			,@rate_info = COALESCE(CASE CAST([RATE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [RATE_INFO] END, @rate_info)
			,@misc_info = COALESCE(CASE CAST([MISC_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [MISC_INFO] END, @misc_info)
			,@in_house_cmts = COALESCE(CASE CAST([IN_HOUSE_CMTS] AS varchar (max)) WHEN '' THEN NULL ELSE [IN_HOUSE_CMTS] END, @in_house_cmts)
			,@buyer_emp_code = COALESCE([BUYER_EMP_CODE], @buyer_emp_code)
			,@guaranteed_impress = COALESCE([GUARANTEED_IMPRESS], @guaranteed_impress)
		FROM @tmp_orders
		WHERE RowID = @ROW_ID

		--PJH 05/23/18 - Only set order_date = @date_time_w if header record does not exist (i.e. New Order)
		IF @hdr_exists = 0 
			SET @order_date   = @date_time_w

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @date_to_bill=NULL --@close_date=NULL, @matl_close_date=NULL, @ext_close_date=NULL, @ext_matl_date=NULL, 

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		SET @addl_charge_desc = CASE WHEN (@addl_charge IS NULL OR @addl_charge = 0) THEN NULL ELSE 'Additional Charge' END
		SET @ncdesc = CASE WHEN (@netcharge IS NULL OR @netcharge = 0) THEN NULL ELSE 'Net Charge' END
		SET @color_desc = CASE WHEN (@color_charge IS NULL OR @color_charge = 0) THEN NULL ELSE 'Color Charge' END 
		
		SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End OOH */

	IF @media_type_in = 'T' BEGIN

		/** Get current Values if they exist **/

		IF @hdr_exists = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]

			  ,@cmp_code   = [CMP_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]

			  ,@status   = [STATUS]
			  ,@order_date   = [ORDER_DATE]
			  ,@buyer   = [BUYER]
			  ,@order_comment   = [ORDER_COMMENT]
			  ,@house_comment   = [HOUSE_COMMENT]
			  ,@pub_station   = [STATION]
			  ,@rep1   = [REP1]
			  ,@rep2   = [REP2]
			  ,@bill_coop_code   = [BILL_COOP_CODE]
			  ,@ord_process_contrl   = [ORD_PROCESS_CONTRL]
			  ,@market_code   = [MARKET_CODE]

			  ,@units   = [UNITS]

			  ,@net_gross   = [NET_GROSS]

			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  ,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			  ,@buyer_emp_code = [BUYER_EMP_CODE]
			FROM TV_HDR
			WHERE ORDER_NBR = @order_nbr	
		END
		
		IF @dtl_exists = 1 BEGIN
			SELECT --@order_nbr=[ORDER_NBR], @line_nbr=[LINE_NBR], @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @link_detid=[LINK_DETID]
				@buy_type=[BUY_TYPE], @start_date=[START_DATE], @end_date=[END_DATE], @month_nbr=[MONTH_NBR], @year_nbr=[YEAR_NBR]
				,@close_date=[CLOSE_DATE], @matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE]
				/* PJH 02/21/17 - Always calculate dates */
				--,@date1=[DATE1], @date2=[DATE2], @date3=[DATE3], @date4=[DATE4], @date5=[DATE5], @date6=[DATE6], @date7=[DATE7]
				,@monday=[MONDAY], @tuesday=[TUESDAY], @wednesday=[WEDNESDAY], @thursday=[THURSDAY], @friday=[FRIDAY], @saturday=[SATURDAY], @sunday=[SUNDAY]
				,@spots1=[SPOTS1], @spots2=[SPOTS2], @spots3=[SPOTS3], @spots4=[SPOTS4], @spots5=[SPOTS5], @spots6=[SPOTS6], @spots7=[SPOTS7], @total_spots=[TOTAL_SPOTS]
				,@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR]
				,@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], @ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT]
				,@comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT], @discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC]
				,@state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], @non_resale_amt=[NON_RESALE_AMT]      
				,@netcharge=[NETCHARGE], @ncdesc=[NCDESC], @addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], @line_total=[LINE_TOTAL]
				--,[LINE_CANCELLED]
				,@date_to_bill=[DATE_TO_BILL], @non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS]
				,@bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT], @markup_pct=[MARKUP_PCT], @rebate_pct=[REBATE_PCT], @discount_pct=[DISCOUNT_PCT]
				,@tax_code=[TAX_CODE], @tax_city_pct=[TAX_CITY_PCT], @tax_county_pct=[TAX_COUNTY_PCT], @tax_state_pct=[TAX_STATE_PCT], @tax_resale=[TAX_RESALE]
				,@taxapplyc=[TAXAPPLYC], @taxapplyln=[TAXAPPLYLN], @taxapplynd=[TAXAPPLYND], @taxapplync=[TAXAPPLYNC], @taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI]
				,@reconcile_flag=[RECONCILE_FLAG]    
				,@billing_amt=[BILLING_AMT], @cost_type=[COST_TYPE], @cost_rate=[COST_RATE], @net_base_rate=[NET_BASE_RATE], @gross_base_rate=[GROSS_BASE_RATE]
				--,[BILL_CANCELLED]
				,@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR]
				,@ad_number=[AD_NUMBER], @mat_comp=[MAT_COMP], @programming=[PROGRAMMING]
				,@start_time=[START_TIME], @end_time=[END_TIME], @length=[LENGTH], @remarks=[REMARKS], @tag=[TAG]
				,@network_id=[NETWORK_ID]		
				--PJH 08/18/17 - added new columns
				,@cable_network_station_code = [CABLE_NETWORK_STATION_CODE]
				,@daypart_id = [DAY_PART_ID]
				,@added_value = [ADDED_VALUE]
				,@bookend = [BOOKEND]
				,@link_line_number = [LINK_LINE_NUMBER]
				,@vendor_order_line = [VENDOR_ORDER_LINE]
			FROM [dbo].[TV_DETAIL]
			WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1;	
			
			/* PJH 02/04/16 - Added */
			SELECT @instructions = [INSTRUCTIONS], @order_copy = [ORDER_COPY], @matl_notes = [MATL_NOTES], @misc_info = [MISC_INFO], /***/
						@position_info = [POSITION_INFO], @close_info = [CLOSE_INFO], @rate_info = [RATE_INFO], @in_house_cmts = [IN_HOUSE_CMTS]
			FROM [dbo].[TV_COMMENTS] 
			WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr					
		END
		ELSE BEGIN  /* Set defaults to 0 if new line */
			SELECT @color_charge = 0, @flat_netcharge = 0, @netcharge = 0, @flat_addl_charge = 0, @addl_charge = 0
		END

		--IF @DEBUG = 1 SELECT @remarks '@remarks'
		
		SELECT
			@link_id=[LINK_ID],
			/* PJH 11/19/18 - These are set by Advantage */
			--@line_nbr=[LINE_NBR],
			--@rev_nbr=[REV_NBR],
			@media_type=[MEDIA_TYPE],
			@sales_class_code   = COALESCE([SALES_CLASS_CODE], @sales_class_code),
			@cl_code=[CL_CODE],
			@prd_code=[PRD_CODE],
			@vn_code=[VN_CODE],
			@start_date=[LINE_FLIGHT_FROM],
			@end_date=[LINE_FLIGHT_TO],
			--@hdr_flight_from=[HDR_FLIGHT_FROM],
			--@hdr_flight_to=[HDR_FLIGHT_TO],
			--@flight_type=[FLIGHT_TYPE],
			@rate=[RATE],
			@net_rate=[NET_RATE],@gross_rate=[GROSS_RATE],
			@p1_52=[P1_52],   /* 1-6 for API */
			@div_code=[DIV_CODE],
			@cmp_code=COALESCE([CMP_CODE],@cmp_code),
			@order_desc=COALESCE([ORDER_DESC],@order_desc),
			@market_code=COALESCE([MARKET_CODE],@market_code),
			@start_time=COALESCE([START_TIME], @start_time),
			@end_time=COALESCE([END_TIME], @end_time),
			@total_spots=[TOTAL_SPOTS],
			--@comm_pct=[COMM_PCT], /* PJH 02/16/17 - Commented */
			@buyer=COALESCE([BUYER],@buyer),
			@client_po = CASE @hdr_exists WHEN 1 THEN @client_po ELSE [CLIENT_PO] END, /** Set on New only */
			@length=COALESCE([LENGTH],@length),
			@programming=COALESCE([PROGRAMMING],@programming),
			@monday=COALESCE([MONDAY],@monday),
			@tuesday=COALESCE([TUESDAY],@tuesday),
			@wednesday=COALESCE([WEDNESDAY],@wednesday),
			@thursday=COALESCE([THURSDAY],@thursday),
			@friday=COALESCE([FRIDAY],@friday),
			@saturday=COALESCE([SATURDAY],@saturday),
			@sunday=COALESCE([SUNDAY],@sunday),
			@order_comment=COALESCE([ORDER_COMMENT],@order_comment),
			@line_comment=COALESCE([LINE_COMMENT],@line_comment),
			--@cl_name=[CL_NAME],
			--@vn_name=[VN_NAME],
			--@market_desc=[MARKET_DESC],
			@media_interface=COALESCE([MEDIA_INTERFACE],@media_interface),
			--@post_flag=[POST_FLAG],
			@delete_order=[DELETE_ORDER],
			--@cnvt_imprt_line=[CNVT_IMPRT_LINE],
			--@possible_dupe=[POSSIBLE_DUPE],
			@job_number=COALESCE([JOB_NUMBER],@job_number),
			@job_component_nbr=COALESCE([JOB_COMPONENT_NBR],@job_component_nbr),
			@vr_code=COALESCE([VR_CODE],@vr_code),
			@vr_code2=COALESCE([VR_CODE2],@vr_code2),
			--@weekly_cost=[WEEKLY_COST],
			@net_gross=[NET_GROSS_FLAG],
			--@vn_code_xref=[VN_CODE_XREF],
			@air_date=[AIR_DATE],  /* Overrides the Strat & End Dates - Indicates Daily Buy */
			--@bc_weeks=[BC_WEEKS],
			@network_id=COALESCE([NETWORK_ID],@network_id),
			@netcharge=COALESCE([NETCHARGE],@netcharge),
			@addl_charge=COALESCE([ADDL_CHARGE],@addl_charge),
			@date1=COALESCE([DATE1],@date1),
			@date2=COALESCE([DATE2],@date2),
			@date3=COALESCE([DATE3],@date3),
			@date4=COALESCE([DATE4],@date4),
			@date5=COALESCE([DATE5],@date5),
			@date6=COALESCE([DATE6],@date6),
			--@buy_month=[BUY_MONTH],
			--@buy_year=[BUY_YEAR],
			--@rebate_pct=[REBATE_PCT],
			--@rebate_amt=[REBATE_AMT],
			--@markup_pct=[MARKUP_PCT],
			@markup_pct_or = [MARKUP_PCT], @rebate_pct_or = [REBATE_PCT], @rebate_amt_or = [REBATE_AMT], @comm_pct_or = [COMM_PCT],
			--@plan_ids=[PLAN_IDS],
			@cal_type=COALESCE([CAL_TYPE],@cal_type),
			--@daypart_code=[DAYPART_CODE],
			@est_nbr=COALESCE([ESTIMATE_NBR],@est_nbr),
			--@package_name=[PACKAGE_NAME]
			@is_quote = IS_QUOTE, /* STATUS on Order Hdr */
			@prc_status = PRC_STATUS,
			@instructions = COALESCE(CASE [LINE_COMMENT] WHEN '' THEN NULL ELSE [LINE_COMMENT] END,@instructions), /* INSTRUCTIONS */
			/* PJH 07/09/18 - clear remarks if empty string is passed */
			--@remarks = COALESCE(CASE CAST([REMARKS] AS varchar (max)) WHEN '' THEN NULL ELSE [REMARKS] END, @remarks) ,
			@remarks = CASE CAST([REMARKS] AS varchar (max)) WHEN '' THEN NULL ELSE (CASE CAST([REMARKS] AS varchar (max)) WHEN NULL THEN @remarks ELSE [REMARKS] END) END,
			@order_copy = COALESCE(CASE CAST([ORDER_COPY] AS varchar (max)) WHEN '' THEN NULL ELSE [ORDER_COPY] END, @order_copy),
			@matl_notes = COALESCE(CASE CAST([MATL_NOTES] AS varchar (max)) WHEN '' THEN NULL ELSE [MATL_NOTES] END, @matl_notes),
			@position_info = COALESCE(CASE CAST([POSITION_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [POSITION_INFO] END, @position_info),
			@close_info = COALESCE(CASE CAST([CLOSE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [CLOSE_INFO] END, @close_info),
			@rate_info = COALESCE(CASE CAST([RATE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [RATE_INFO] END, @rate_info),
			@misc_info = COALESCE(CASE CAST([MISC_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [MISC_INFO] END, @misc_info),
			--@order_date   = @date_time_w ,
			@create_date   = @date_time_w ,
			@modified_date   = @date_time_w ,
			@buyer_emp_code = COALESCE([BUYER_EMP_CODE], @buyer_emp_code),
			@ad_number = COALESCE([AD_NBR], @ad_number), /* PJH 03/03/17 - added */
			--PJH 08/18/17 - added new columns
			@cable_network_station_code = COALESCE([CABLE_NETWORK_STATION_CODE], @cable_network_station_code),
			@daypart_id = COALESCE([DAY_PART_ID], @daypart_id),
			@added_value = COALESCE([ADDED_VALUE], @added_value),
			@bookend = COALESCE([BOOKEND], @bookend),
			@vendor_order_line = [VENDOR_ORDER_LINE]
		FROM @tmp_orders2
		WHERE RowID = @ROW_ID

		--PJH 05/23/18 - Only set order_date = @date_time_w if header record does not exist (i.e. New Order)
		IF @hdr_exists = 0 
			SET @order_date   = @date_time_w

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @date_to_bill=NULL --@ext_close_date=NULL, @ext_matl_date=NULL, , @close_date=NULL, @matl_close_date=NULL, 

		--SELECT @air_date '@air_date', @instructions '@instructions', @order_copy '@order_copy', @matl_notes '@matl_notes', @position_info '@position_info', @remarks '@remarks',
		--@close_info '@close_info', @rate_info '@rate_info', @misc_info '@misc_info'        /* DEBUG */

		IF ISDATE(@air_date) = 1 BEGIN
			SET @cal_type = 'DB'
		END
		ELSE BEGIN
			IF @cal_type IS NULL
				SET @cal_type = 'BM' 
		END

		--SET @remarks = @line_comment

		SET @buy_type = @cal_type

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End TV */
	
	IF @media_type_in = 'R' BEGIN

		/** Get current Values if they exist **/

		--IF @
		
		IF @hdr_exists = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]

			  ,@cmp_code   = [CMP_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]

			  ,@status   = [STATUS]
			  ,@order_date   = [ORDER_DATE]
			  ,@buyer   = [BUYER]
			  ,@order_comment   = [ORDER_COMMENT]
			  ,@house_comment   = [HOUSE_COMMENT]
			  ,@pub_station   = [STATION]
			  ,@rep1   = [REP1]
			  ,@rep2   = [REP2]
			  ,@bill_coop_code   = [BILL_COOP_CODE]
			  ,@ord_process_contrl   = [ORD_PROCESS_CONTRL]
			  ,@market_code   = [MARKET_CODE]

			  ,@units   = [UNITS]

			  ,@net_gross   = [NET_GROSS]

			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  ,@revised_flag   = [REVISED_FLAG]   /* PJH 06/10/16 */
			  ,@buyer_emp_code = [BUYER_EMP_CODE]
			FROM RADIO_HDR
			WHERE ORDER_NBR = @order_nbr	
		END

		IF @dtl_exists = 1 BEGIN
			SELECT --@order_nbr=[ORDER_NBR], @line_nbr=[LINE_NBR], @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @link_detid=[LINK_DETID],
				@buy_type=[BUY_TYPE], @start_date=[START_DATE], @end_date=[END_DATE], @month_nbr=[MONTH_NBR], @year_nbr=[YEAR_NBR]
				,@close_date=[CLOSE_DATE], @matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE]
				/* PJH 02/21/17 - Always calculate dates */
				--,@date1=[DATE1], @date2=[DATE2], @date3=[DATE3], @date4=[DATE4], @date5=[DATE5], @date6=[DATE6], @date7=[DATE7]
				,@monday=[MONDAY], @tuesday=[TUESDAY], @wednesday=[WEDNESDAY], @thursday=[THURSDAY], @friday=[FRIDAY], @saturday=[SATURDAY], @sunday=[SUNDAY]
				,@spots1=[SPOTS1], @spots2=[SPOTS2], @spots3=[SPOTS3], @spots4=[SPOTS4], @spots5=[SPOTS5], @spots6=[SPOTS6], @spots7=[SPOTS7], @total_spots=[TOTAL_SPOTS]
				,@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR]
				,@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], @ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT]
				,@comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT], @discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC]
				,@state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], @non_resale_amt=[NON_RESALE_AMT]      
				,@netcharge=[NETCHARGE], @ncdesc=[NCDESC], @addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], @line_total=[LINE_TOTAL]
				--,[LINE_CANCELLED]
				,@date_to_bill=[DATE_TO_BILL], @non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS]
				,@bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT], @markup_pct=[MARKUP_PCT], @rebate_pct=[REBATE_PCT], @discount_pct=[DISCOUNT_PCT]
				,@tax_code=[TAX_CODE], @tax_city_pct=[TAX_CITY_PCT], @tax_county_pct=[TAX_COUNTY_PCT], @tax_state_pct=[TAX_STATE_PCT], @tax_resale=[TAX_RESALE]
				,@taxapplyc=[TAXAPPLYC], @taxapplyln=[TAXAPPLYLN], @taxapplynd=[TAXAPPLYND], @taxapplync=[TAXAPPLYNC], @taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI]
				,@reconcile_flag=[RECONCILE_FLAG]    
				,@billing_amt=[BILLING_AMT], @cost_type=[COST_TYPE], @cost_rate=[COST_RATE], @net_base_rate=[NET_BASE_RATE], @gross_base_rate=[GROSS_BASE_RATE]
				--,[BILL_CANCELLED]
				,@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR]
				,@ad_number=[AD_NUMBER], @mat_comp=[MAT_COMP], @programming=[PROGRAMMING]
				,@start_time=[START_TIME], @end_time=[END_TIME], @length=[LENGTH], @remarks=[REMARKS], @tag=[TAG]
				,@network_id=[NETWORK_ID]
				--PJH 08/18/17 - added new columns
				,@daypart_id = [DAY_PART_ID]
				,@added_value = [ADDED_VALUE]
				,@link_line_number = [LINK_LINE_NUMBER]
				,@vendor_order_line = [VENDOR_ORDER_LINE]
			FROM [dbo].[RADIO_DETAIL]
			WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1;	
			
			/* PJH 02/04/16 - Added */
			SELECT @instructions = [INSTRUCTIONS], @order_copy = [ORDER_COPY], @matl_notes = [MATL_NOTES], @misc_info = [MISC_INFO], /***/
						@position_info = [POSITION_INFO], @close_info = [CLOSE_INFO], @rate_info = [RATE_INFO], @in_house_cmts = [IN_HOUSE_CMTS]
			FROM [dbo].[RADIO_COMMENTS] 
			WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr							
		END
		ELSE BEGIN  /* Set defaults to 0 if new line */
			SELECT @color_charge = 0, @flat_netcharge = 0, @netcharge = 0, @flat_addl_charge = 0, @addl_charge = 0
		END

		SELECT
			@link_id=[LINK_ID],
			/* PJH 11/19/18 - These are set by Advantage */
			--@line_nbr=[LINE_NBR],
			--@rev_nbr=[REV_NBR],
			@media_type=[MEDIA_TYPE],
			@sales_class_code   = COALESCE([SALES_CLASS_CODE], @sales_class_code),
			@cl_code=[CL_CODE],
			@prd_code=[PRD_CODE],
			@vn_code=[VN_CODE],
			@start_date=[LINE_FLIGHT_FROM],
			@end_date=[LINE_FLIGHT_TO],
			--@hdr_flight_from=[HDR_FLIGHT_FROM],
			--@hdr_flight_to=[HDR_FLIGHT_TO],
			--@flight_type=[FLIGHT_TYPE],
			@rate=[RATE],
			@net_rate=[NET_RATE],
			@gross_rate=[GROSS_RATE],
			@p1_52=[P1_52],   /* 1-6 for API */
			@div_code=[DIV_CODE],
			@cmp_code=COALESCE([CMP_CODE], @cmp_code),
			@order_desc=COALESCE([ORDER_DESC],@order_desc),
			@market_code=COALESCE([MARKET_CODE],@market_code),
			@start_time=COALESCE([START_TIME], @start_time),
			@end_time=COALESCE([END_TIME], @end_time),
			@total_spots=[TOTAL_SPOTS],
			--@comm_pct=[COMM_PCT], /* PJH 02/16/17 - Commented */
			@buyer=COALESCE([BUYER],@buyer),
			@client_po = CASE @hdr_exists WHEN 1 THEN @client_po ELSE [CLIENT_PO] END, /** Set on New only */
			@length=COALESCE([LENGTH],@length),
			@programming=COALESCE([PROGRAMMING],@programming),
			@monday=COALESCE([MONDAY],@monday),
			@tuesday=COALESCE([TUESDAY],@tuesday),
			@wednesday=COALESCE([WEDNESDAY],@wednesday),
			@thursday=COALESCE([THURSDAY],@thursday),
			@friday=COALESCE([FRIDAY],@friday),
			@saturday=COALESCE([SATURDAY],@saturday),
			@sunday=COALESCE([SUNDAY],@sunday),
			@order_comment=COALESCE([ORDER_COMMENT],@order_comment),
			@line_comment=COALESCE([LINE_COMMENT],@line_comment),
			--@cl_name=[CL_NAME],
			--@vn_name=[VN_NAME],
			--@market_desc=[MARKET_DESC],
			@media_interface=COALESCE([MEDIA_INTERFACE],@media_interface),
			--@post_flag=[POST_FLAG],
			@delete_order=[DELETE_ORDER],
			--@cnvt_imprt_line=[CNVT_IMPRT_LINE],
			--@possible_dupe=[POSSIBLE_DUPE],
			@job_number=COALESCE([JOB_NUMBER],@job_number),
			@job_component_nbr=COALESCE([JOB_COMPONENT_NBR],@job_component_nbr),
			@vr_code=COALESCE([VR_CODE],@vr_code),
			@vr_code2=COALESCE([VR_CODE2],@vr_code2),
			--@weekly_cost=[WEEKLY_COST],
			@net_gross=[NET_GROSS_FLAG],
			--@vn_code_xref=[VN_CODE_XREF],
			@air_date=[AIR_DATE],  /* Overrides the Strat & End Dates - Indicates Daily Buy */
			--@bc_weeks=[BC_WEEKS],
			@network_id=COALESCE([NETWORK_ID],@network_id),
			@netcharge=COALESCE([NETCHARGE],@netcharge),
			@addl_charge=COALESCE([ADDL_CHARGE],@addl_charge),
			@date1=COALESCE([DATE1],@date1),
			@date2=COALESCE([DATE2],@date2),
			@date3=COALESCE([DATE3],@date3),
			@date4=COALESCE([DATE4],@date4),
			@date5=COALESCE([DATE5],@date5),
			@date6=COALESCE([DATE6],@date6),
			--@buy_month=[BUY_MONTH],
			--@buy_year=[BUY_YEAR],
			--@rebate_pct=[REBATE_PCT],
			--@rebate_amt=[REBATE_AMT],
			--@markup_pct=[MARKUP_PCT],
			@markup_pct_or = [MARKUP_PCT], @rebate_pct_or = [REBATE_PCT], @rebate_amt_or = [REBATE_AMT], @comm_pct_or = [COMM_PCT],
			--@plan_ids=[PLAN_IDS],
			@cal_type=COALESCE([CAL_TYPE],@cal_type),
			--@daypart_code=[DAYPART_CODE],
			@est_nbr=COALESCE([ESTIMATE_NBR],@est_nbr),
			--@package_name=[PACKAGE_NAME]
			@is_quote = IS_QUOTE, /* STATUS on Order Hdr */
			@prc_status = PRC_STATUS,
			@instructions = COALESCE(CASE [LINE_COMMENT] WHEN '' THEN NULL ELSE [LINE_COMMENT] END,@instructions), /* INSTRUCTIONS */
			/* PJH 07/09/18 - clear remarks if empty string is passed */
			--@remarks = COALESCE(CASE CAST([REMARKS] AS varchar (max)) WHEN '' THEN NULL ELSE [REMARKS] END, @remarks) ,
			@remarks = CASE CAST([REMARKS] AS varchar (max)) WHEN '' THEN NULL ELSE (CASE CAST([REMARKS] AS varchar (max)) WHEN NULL THEN @remarks ELSE [REMARKS] END) END,
			@order_copy = COALESCE(CASE CAST([ORDER_COPY] AS varchar (max)) WHEN '' THEN NULL ELSE [ORDER_COPY] END, @order_copy),
			@matl_notes = COALESCE(CASE CAST([MATL_NOTES] AS varchar (max)) WHEN '' THEN NULL ELSE [MATL_NOTES] END, @matl_notes),
			@position_info = COALESCE(CASE CAST([POSITION_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [POSITION_INFO] END, @position_info),
			@close_info = COALESCE(CASE CAST([CLOSE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [CLOSE_INFO] END, @close_info),
			@rate_info = COALESCE(CASE CAST([RATE_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [RATE_INFO] END, @rate_info),
			@misc_info = COALESCE(CASE CAST([MISC_INFO] AS varchar (max)) WHEN '' THEN NULL ELSE [MISC_INFO] END, @misc_info),
			--@order_date   = @date_time_w ,
			@create_date   = @date_time_w ,
			@modified_date   = @date_time_w ,
			@buyer_emp_code = COALESCE([BUYER_EMP_CODE], @buyer_emp_code) ,
			@ad_number = COALESCE([AD_NBR], @ad_number), /* PJH 03/03/17 - added */
			--PJH 08/18/17 - added new columns
			--@cable_network_station_code = COALESCE([CABLE_NETWORK_STATION_CODE], @cable_network_station_code),
			@daypart_id = COALESCE([DAY_PART_ID], @daypart_id),
			@added_value = COALESCE([ADDED_VALUE], @added_value),
			--@bookend = COALESCE([BOOKEND], @bookend),
			@vendor_order_line = [VENDOR_ORDER_LINE]
			FROM @tmp_orders2
		WHERE RowID = @ROW_ID

		--PJH 05/23/18 - Only set order_date = @date_time_w if header record does not exist (i.e. New Order)
		IF @hdr_exists = 0 
			SET @order_date   = @date_time_w

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @date_to_bill=NULL --@ext_close_date=NULL, @ext_matl_date=NULL,, @close_date=NULL, @matl_close_date=NULL, 

		IF ISDATE(@air_date) = 1 BEGIN
			SET @cal_type = 'DB'
		END
		ELSE BEGIN
			IF @cal_type IS NULL
				SET @cal_type = 'BM' 
		END

		SET @buy_type = @cal_type
		
		--SET @remarks = @line_comment

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End RADIO */	

	IF @hdr_exists = 1 BEGIN
		IF @media_type_in = 'N' BEGIN
			SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE, @vn_code = VN_CODE, @ord_process_contrl = ORD_PROCESS_CONTRL
			FROM NEWSPAPER_HEADER
			WHERE ORDER_NBR = @order_nbr
		END
		ELSE IF @media_type_in = 'M' BEGIN
			SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE, @vn_code = VN_CODE, @ord_process_contrl = ORD_PROCESS_CONTRL
			FROM MAGAZINE_HEADER
			WHERE ORDER_NBR = @order_nbr
		END
		ELSE IF @media_type_in = 'I' BEGIN
			SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE, @vn_code = VN_CODE, @ord_process_contrl = ORD_PROCESS_CONTRL
			FROM INTERNET_HEADER
			WHERE ORDER_NBR = @order_nbr
		END
		ELSE IF @media_type_in = 'O' BEGIN
			SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE, @vn_code = VN_CODE, @ord_process_contrl = ORD_PROCESS_CONTRL
			FROM OUTDOOR_HEADER
			WHERE ORDER_NBR = @order_nbr
		END
		ELSE IF @media_type_in = 'T' BEGIN
			SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE, @vn_code = VN_CODE, @ord_process_contrl = ORD_PROCESS_CONTRL
			FROM TV_HDR
			WHERE ORDER_NBR = @order_nbr
		END
		ELSE IF @media_type_in = 'R' BEGIN
			SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE, @vn_code = VN_CODE, @ord_process_contrl = ORD_PROCESS_CONTRL
			FROM RADIO_HDR
			WHERE ORDER_NBR = @order_nbr
		END
	END
	ELSE BEGIN /* NEW ORDER - GET ADDL INFO */
		SELECT @pub_station = 1,
					@ord_process_contrl = 1,
					@cmp_identifier  = CMP_IDENTIFIER FROM CAMPAIGN WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE= @prd_code AND CMP_CODE = @cmp_code
	END

	IF @dtl_exists = 1 BEGIN
		SET @action = 'REVISE'
	END 
	ELSE BEGIN
		SET @action = 'NEW'
	END

	IF @dtl_exists = 0 BEGIN

		--SELECT 'TAX INFO BEFORE' 'Desc', @cl_code '@cl_code'	, @div_code '@div_code'	, @prd_code'@prd_code'	 , @order_type '@order_type'
		--,@tax_code '@tax_code' ,@bill_type_flag '@bill_type_flag', @taxapplyln '@taxapplyln'		,@taxapplynd  '@taxapplynd'
		--,@taxapplync  '@taxapplync'		,@taxapplyai  '@taxapplyai'		,@taxapplyc '@taxapplyc'		,@taxapplyr '@taxapplyr'
		--,@vn_code '@vn_code', @net_gross '@net_gross', @bill_type_flag '@bill_type_flag', @start_date '@start_date'

		SELECT /* GET PRODUCT DEFAULTS */
				--@markup_pct = [PRD_COMM] ,   
				--@rebate_pct = [PRD_REBATE] ,  
				@discount_pct = [PRD_VEN_DISC],  --<<<<<<<<<<<< PRODUCT DISCOUNT
				--@tax_code = [PRD_TAX_CODE] , 
				--@taxapplyln= [TAXAPPLYLN] ,
				--@taxapplynd = [TAXAPPLYND] ,
				--@taxapplync = [TAXAPPLYNC] ,
				--@taxapplyai = [TAXAPPLYAI] ,
				--@taxapplyc = [TAXAPPLYC] ,
				--@taxapplyr = [TAXAPPLYR] ,
				--[PRD_DAYS] ,
				--[PRD_PRE_POST] ,
				--[PRD_BF_AF] ,
				--[USE_TAX_FLAGS] ,
				@prd_bill_type_flag = [PRD_BILL_TYPE] ,   --<<<<<<<<<<<< PRODUCT BILL TYPE FLAG
				@office_code = [OFFICE_CODE]   --<<<<<<<<<<<< PRODUCT OFFICE
		FROM [dbo].[advtf_med_get_prd_defaults] (
				@cl_code	,
				@div_code	,
				@prd_code	 ,
				@order_type ,
				@sales_class_code, --@media_type , /* SC_CODE */
				'NEW' )
						
		IF COALESCE(@prd_bill_type_flag, 0 ) > 0 
			SET @bill_type_flag = @prd_bill_type_flag
	END

	--BILL_TYPE_FLAG = 1 = Comm Only, 2 = Net, 3 = Gross

	IF @dtl_exists = 0 BEGIN		
		SELECT /* GET TAX INFO & VENDOR & PRODUCT */
					@tax_city_pct=TAX_CITY_PCT, @tax_county_pct=TAX_COUNTY_PCT, @tax_state_pct=TAX_STATE_PCT, @tax_resale=TAX_RESALE,
					@taxapplyc=TAXAPPLYC, @taxapplyln=TAXAPPLYLN, @taxapplynd=TAXAPPLYND, @taxapplync=TAXAPPLYNC, @taxapplyr=TAXAPPLYR, @taxapplyai=TAXAPPLYAI,
					@tax_code=TAX_CODE,  
					@comm_pct=COMM_PCT,  --<<<<<<<<<<<< VENDOR COMMISSION
					@markup_pct=MARKUP_PCT,  --<<<<<<<<<<<< PRODUCT MARKUP
					@rebate_pct=COALESCE(REBATE_PCT, @rebate_pct) --<<<<<<<<<<<< PRODUCT REBATE
		FROM advtf_med_get_tax_info(@order_type, @vn_code, @net_gross, @cl_code, @div_code, @prd_code, @bill_type_flag, @start_date, @action)	
	END

	--PJH 02/03/16 - Broke out SC from Product so it casn be last override
	IF @dtl_exists = 0 BEGIN
		SELECT /* GET SC DEFAULTS */
				@markup_pct = COALESCE([SC_MARKUP], @markup_pct),  --<<<<<<<<<<<< MARKUP
				@rebate_pct = COALESCE([SC_REBATE], @rebate_pct)  --<<<<<<<<<<<< REBATE
		FROM [dbo].[advtf_med_get_sc_defaults] (
				@cl_code	,
				@div_code	,
				@prd_code	 ,
				@order_type ,
				@sales_class_code ) --@media_type , /* SC_CODE */				
	END

	--PJH 03/29/17 - Get New Vendor Markup so it casn be last override
	IF @dtl_exists = 0 BEGIN
		SELECT /* GET VN DEFAULTS */
				@markup_pct = COALESCE([VN_MARKUP], @markup_pct)  --<<<<<<<<<<<< MARKUP
		FROM [dbo].[VENDOR]
		WHERE VN_CODE = @vn_code;		
	END

	/* uf_calc_comm_mu - Get reciprocal PCT */
	IF @net_gross = 1  BEGIN
		SELECT @markup_pct=MARKUP_PCT FROM advtf_med_calc_comm_mu( @net_gross, @comm_pct) --GROSS
	END
	ELSE BEGIN
		SELECT @comm_pct=COMM_PCT FROM advtf_med_calc_comm_mu( @net_gross, @markup_pct) --NET		
	END

	--PJH 02/04/16 - Chk for existing
	IF @hdr_exists = 0 OR @units IS NULL BEGIN
		IF @media_type_in =  'I'
			SELECT @table_prefix = 'INTERNET', 
			@units = 'M'
		IF @media_type_in =  'O'
			SELECT @table_prefix = 'OUTDOOR',
			 @units = 'M'
		IF @media_type_in =  'N' BEGIN
			SELECT @table_prefix = 'NEWSPAPER',
			 @units = 'D'
			IF @media_interface_in = 'AM' /* Media Planning */
				 SET @units = 'W'
		END 
		IF @media_type_in =  'M'
			SELECT @table_prefix = 'MAGAZINE'	,	
			 @units = 'M'
		IF @media_type_in =  'R'
			SELECT @table_prefix = 'RADIO',
			 @units = @cal_type
		IF @media_type_in =  'T'
			SELECT @table_prefix = 'TV',
			 @units = @cal_type
	END
	
	/* For future reference - We could get default unit type from Vendor */ /*
		SELECT @units=DEF_UNITS
		FROM dbo.VENDOR
		WHERE VN_CODE=@vn_code;	
	*/

	--SELECT @hdr_exists '2 @hdr_exists', @units '@units', @media_type_in '@media_type_in'    /* DEBUG */

	--IF @DEBUG = 1
	--	SELECT @rebate_pct '@rebate_pct - After - advtf_med_calc_comm_mu()', @markup_pct '@markup_pct', @comm_pct '@comm_pct'

	SELECT @ok = (SELECT 1 FROM SALES_CLASS WHERE SC_CODE = @sales_class_code)
	IF @ok <> 1 BEGIN
		SET @error_msg_w = 'Invalid Sales Class Code.'
		GOTO ERROR_MSG	
	END

	SELECT @ok = (SELECT 1 FROM VENDOR WHERE VN_CODE = @vn_code)
	IF @ok <> 1 BEGIN
		SET @error_msg_w = 'Invalid Vendor Code.'
		GOTO ERROR_MSG	
	END

	IF @order_date IS NOT NULL
		IF ISDATE(@order_date) = 1 AND (@order_date BETWEEN '01/01/2010' AND '01/01/2079')
			--SELECT 'GOOD DATE'
			SET @error_msg_w = 'DO NOTHING'
		ELSE BEGIN
			SET @error_msg_w = 'Invalid Order Date.'
			GOTO ERROR_MSG	
		END
	ELSE
		SET @order_date = GETDATE()
		
	IF @order_desc IS NULL BEGIN
		SET @error_msg_w = 'Missing Order Description.'
		GOTO ERROR_MSG	
	END
	
	/* If overrides exist, use them and set override flags to pass to [advsp_revise_order_detail] */
	IF @markup_pct_or IS NOT NULL BEGIN
		SET @markup_pct = @markup_pct_or
		SET @markup_pct_override = 1
	END
	IF @net_gross = 1 BEGIN--Gross
		IF @rebate_pct_or IS NOT NULL BEGIN
			SET @rebate_pct = @rebate_pct_or
			SET @rebate_pct_override = 1
		END
		IF @rebate_amt_or IS NOT NULL BEGIN
			SET @rebate_amt = @rebate_amt_or
			SET @rebate_amt_override = 1
		END
	END 
	ELSE BEGIN
		SET @rebate_pct = 0
		SET @rebate_amt = 0
	END

	IF @comm_pct_or IS NOT NULL BEGIN
		SET @comm_pct = @comm_pct_or
		SET @comm_pct_override = 1
	END	
	
	SET @printed = NULL /** CLEAR PRINTED FLAG **/	
	
	SET @modified_by = @user_id /* Passed from calling Procedure */

	/* PJH 09/07/18 - @modified_comments = @imported_from */
	SET @modified_comments = @imported_from + ' modified by ' + @user_id + ' ' + CONVERT(varchar, @date_time_w, 101)

	--IF @DEBUG = 1
	--	SELECT 'HEADER INFO FOR ' 'DESC', @order_nbr ORDER_NBR, @line_nbr LINE_NBR, @link_id LINK_ID, @link_detid LINKE_DETID, @rev_nbr_import REV_NBR, @vn_code 'VN_CODE' /** DEBUG **/
	
	/* No Order Nbr - Do this after other validation so we don't waste a number */
	IF @hdr_exists = 0 BEGIN
		IF COALESCE(@order_nbr, 0) = 0 BEGIN
			SET @s_temp =  'ORDER_NBR'

			SELECT @max_order_nbr = LAST_NBR + 1
			FROM ASSIGN_NBR
			WHERE COLUMNNAME = @s_temp;

			UPDATE ASSIGN_NBR
				SET LAST_NBR = @max_order_nbr
				WHERE COLUMNNAME =@s_temp
				AND LAST_NBR = @max_order_nbr - 1;
				
			IF @@ERROR > 0 BEGIN
				SELECT @@ERROR 'ERROR NO'
				RETURN
			END	
			
			SET @order_nbr = @max_order_nbr
			
			--SELECT @order_nbr 'ORDER_NBR'  /*  DEBUG */
			
			IF COALESCE(@order_nbr, 0) = 0 BEGIN
				SET @error_msg_w = 'Error getting the next Order Number.'
				GOTO ERROR_MSG	
			END
		END 
		ELSE BEGIN
			SET @error_msg_w = 'A new order can''t be created with an existing Order Number.'
			GOTO ERROR_MSG	
		END	

		--DON'T SET ON IMPORT
		--SELECT @house_comment = CAST(@link_id AS VARCHAR(20)) + ' imported from ' + @imported_from

		SELECT @units '@units'    /* DEBUG */

		SET @revised_flag   = NULL   /* PJH 06/10/16 */
		
		EXECUTE @RC = [dbo].[advsp_revise_order_header] 
		@user_id
		,'NEW'
		,@order_type
		,@ret_val OUTPUT, @ret_val_s OUTPUT
		,@order_nbr, @order_desc, @cl_code, @div_code, @prd_code, @office_code, @cmp_code, @sales_class_code --,@media_type
		,@vn_code, @vr_code, @vr_code2, @client_po, @client_ref, @status, @order_date, @buyer
		,@order_comment, @house_comment, @pub_station, @rep1, @rep2, @bill_coop_code, @ord_process_contrl
		,@market_code, @start_date, @end_date, @units, @nbr_of_units, @net_gross, @create_date
		,@cancelled, @cancelled_by, @cancelled_date, @modified_by, @modified_date, @modified_comments
		,@revised_flag, @link_id, @reconcile_flag, @cmp_identifier, @printed, @order_accepted, @fiscal_period_code
		,@locked, @locked_by, @bcc_id
		,@is_quote /* STATUS on Order Hdr */
		,@buyer_emp_code

		--SELECT @ret_val '@ret_val' /* DEBUG */
		  
		IF @ret_val <> 0 BEGIN
			SET @error_msg_w = 'Error inserting Order Header values! ' + @ret_val_s
			GOTO ERROR_MSG
		END
		ELSE BEGIN
			SELECT @ret_val_s 'HDR RETURN MSG'
		END
	END
	ELSE BEGIN
		IF COALESCE(@order_nbr, 0) = 0 BEGIN
			SELECT 'HEADER INFO FOR xORDER: ' + CAST(@order_nbr AS VARCHAR(20)) + ' LINE: ' + CAST(@line_nbr AS VARCHAR(20))
			SET @error_msg_w = 'Invalid Order Number - Error updating Order Header values! ' + @ret_val_s
			GOTO ERROR_MSG
		END	

		--SELECT @house_comment = CAST(@link_id AS VARCHAR(20)) + ' imported from ' + @imported_from
		  
		  /* PJH 06/10/16 */
		IF @dtl_exists = 1 
			SET @revised_flag = 1
		ELSE
			SET @revised_flag = NULL

		EXECUTE @RC = [dbo].[advsp_revise_order_header] 
		@user_id
		,'UPDATE'
		,@order_type
		,@ret_val OUTPUT, @ret_val_s OUTPUT
		,@order_nbr, @order_desc, @cl_code, @div_code, @prd_code, @office_code, @cmp_code, @sales_class_code --,@media_type
		,@vn_code, @vr_code, @vr_code2, @client_po, @client_ref, @status, @order_date, @buyer
		,@order_comment, @house_comment, @pub_station, @rep1, @rep2, @bill_coop_code, @ord_process_contrl
		,@market_code, @start_date, @end_date, @units, @nbr_of_units, @net_gross, @create_date
		,@cancelled, @cancelled_by, @cancelled_date, @modified_by, @modified_date, @modified_comments
		,@revised_flag, @link_id, @reconcile_flag, @cmp_identifier, @printed, @order_accepted, @fiscal_period_code
		,@locked, @locked_by, @bcc_id
		,@is_quote /* STATUS on Order Hdr */
		,@buyer_emp_code
		--,@prc_status
		--,@instructions
		--,@order_copy
		--,@matl_notes
		--,@position_info
		--,@close_info
		--,@rate_info
		--,@misc_info
		--,@in_house_cmts
		
		IF @ret_val <> 0 BEGIN
			SET @error_msg_w = 'Error updating Order Header values! ' + @ret_val_s
			GOTO ERROR_MSG
		END

	END
	
	--IF @DEBUG = 1
	--	SELECT 'GET DETAIL INFO FOR ' 'DESC', @order_nbr ORDER_NBR, @line_nbr LINE_NBR, @link_id LINK_ID, @link_detid LINKE_DETID, @rev_nbr_import REV_NBR, @vn_code 'VN_CODE' /** DEBUG **/
	
	IF @dtl_exists = 1 BEGIN
		SET @action = 'REVISE'
	END 
	ELSE BEGIN
		SET @action = 'NEW'
	END

	IF @dtl_exists = 0 BEGIN /* This line does not exist */
		SET @line_nbr = 1
		SET @rev_nbr = 0
		SET @seq_nbr = 0
		SET @active_rev = 1
		
		IF @hdr_exists = 1 BEGIN
			IF @media_type_in =  'N' BEGIN
				SELECT @line_nbr = MAX(LINE_NBR) + 1 FROM [dbo].NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr
			END
			ELSE IF @media_type_in =  'M' BEGIN
				SELECT @line_nbr = MAX(LINE_NBR) + 1 FROM [dbo].MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr
			END
			ELSE IF @media_type_in =  'I' BEGIN
				SELECT @line_nbr = MAX(LINE_NBR) + 1 FROM [dbo].INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr
			END
			ELSE IF @media_type_in =  'O' BEGIN
				SELECT @line_nbr = MAX(LINE_NBR) + 1 FROM [dbo].OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr
			END
			ELSE IF @media_type_in =  'T' BEGIN
				SELECT @line_nbr = MAX(LINE_NBR) + 1 FROM [dbo].TV_DETAIL WHERE ORDER_NBR = @order_nbr
			END
			ELSE IF @media_type_in =  'R' BEGIN
				SELECT @line_nbr = MAX(LINE_NBR) + 1 FROM [dbo].RADIO_DETAIL WHERE ORDER_NBR = @order_nbr
			END
		END
		SET @action = 'NEW'
	END	
	ELSE BEGIN
		SET @active_rev = 1
		SET @action = 'REVISE'
	END

	/* PJH 03/09/18 - Added check for existing dates */	
	--IF @action = 'REVISE' BEGIN

		--SELECT @date1_rev = NULL, @date2_rev = NULL, @date3_rev = NULL, @date4_rev = NULL, @date5_rev = NULL, @date6_rev = NULL, @date7_rev = NULL 

		/* PJH 04/02/18 - Adjust dates after update */
		--IF @media_type_in =  'T' BEGIN
		--	SELECT @date1_rev = MAX(DATE1)
		--		,@date2_rev = MAX(DATE2)
		--		,@date3_rev = MAX(DATE3)
		--		,@date4_rev = MAX(DATE4)
		--		,@date5_rev = MAX(DATE5)
		--		,@date6_rev = MAX(DATE6)
		--		,@date7_rev = MAX(DATE7)			
		--	FROM [dbo].TV_DETAIL WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr
		--END
		--ELSE IF @media_type_in =  'R' BEGIN
		--	SELECT @date1_rev = MAX(DATE1)
		--		,@date2_rev = MAX(DATE2)
		--		,@date3_rev = MAX(DATE3)
		--		,@date4_rev = MAX(DATE4)
		--		,@date5_rev = MAX(DATE5)
		--		,@date6_rev = MAX(DATE6)
		--		,@date7_rev = MAX(DATE7)			
		--	FROM [dbo].RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr
		--END

	--END

	--SELECT 'DATES>>>' 'DESC', @date1_rev, @date2_rev, @date3_rev, @date4_rev, @date5_rev, @date6_rev, @date7_rev

	--SELECT @order_type '@order_type', @start_date '@start_date', @end_date '@end_date', @p1_52 '@spots', @cal_type '@cal_type', @units '@units'   /* DEBUG */

	/* TV, Radio Dates & Spots */
	IF @media_type_in IN ('T','R') BEGIN
	
		DECLARE @temp_date smalldatetime, @temp_mmyyyy varchar(6)

		SET @temp_date = @start_date

		IF ISDATE(@date1) = 0 BEGIN /* Dates not provided so calculate */
			IF @cal_type IN ('BM','DB') BEGIN
				/* PJH 04/13/19 - Use Broadcast Week Start Date for @temp_date */
				SELECT @date1 = A.BRD_WEEK_START, @month_nbr = A.BRD_MONTH, @year_nbr = A.BRD_YEAR FROM @brdcast_weeks2 A
				WHERE @start_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
				IF ISDATE(@date1) = 1 BEGIN
					SET @temp_date = @date1
					SET @date1 = @start_date /* First date should be the Start Date */
				END
				
				IF @DEBUG = 1
					SELECT @date1 'Validated - @date1' 

				IF @date1 IS NOT NULL 
					SET @temp_date = DATEADD(d, 7, @temp_date)
				ELSE
					SET @spots1 = 0
				IF @temp_date <= @end_date BEGIN
					SELECT @date2 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
					IF @date2 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots2 = 0
				END
				IF @temp_date <= @end_date BEGIN
					SELECT @date3 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
					IF @date3 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots3 = 0
				END
				IF @temp_date <= @end_date BEGIN
					SELECT @date4 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
					IF @date4 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots4 = 0
				END
				IF @temp_date <= @end_date BEGIN
					SELECT @date5 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
					IF @date5 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots5 = 0
				END
				IF @temp_date <= @end_date BEGIN
					SELECT @date6 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
				END
			END
		END
		
		--SELECT @start_date '@start_date' , @date1 '@date1', @date2 '@date2', @date3 '@date3', @date4 '@date4', @date5 '@date5', @date6 '@date6', @month_nbr'@month_nbr', @year_nbr '@year_nbr'  /* DEBUG */

		DELETE @bc_spots_table /* Clear any existing data */

		/* PJH 07/24/2020 - Updated to use CSV instead of space delimited */
		INSERT INTO @bc_spots_table SELECT * FROM advtf_med_import_brdcast_weeks_csv (
		@order_type,
		@start_date,
		@end_date,
		@date1,
		@date2,
		@date3,
		@date4,
		@date5,
		@date6,
		@p1_52,
		@cal_type)

		SELECT @spots1 = BC_SPOTS1, @spots2 = BC_SPOTS2, @spots3 = BC_SPOTS3, @spots4 = BC_SPOTS4, @spots5 = BC_SPOTS5, @spots6 = BC_SPOTS6,
				@date1 = BC_DATE1, @date2 = BC_DATE2, @date3 = BC_DATE3, @date4 = BC_DATE4, @date5 = BC_DATE5, @date6 = BC_DATE6,
				@temp_mmyyyy = BC_MMYYYY
		FROM @bc_spots_table	

		--IF @DEBUG = 1
		--	SELECT 'After advtf' '-',@start_date '@start_date' , @date1 '@date1', @date2 '@date2', @date3 '@date3', @date4 '@date4', @date5 '@date5', @date6 '@date6', @month_nbr'@month_nbr', @year_nbr '@year_nbr'  /* DEBUG */
		
		SET @spots7 = 0 /* 7 Not Used */		

		/* PJH 04/02/18 - Adjust Dates after Update */
		--IF @cal_type IN ('BM','DB') BEGIN
		--	--IF @DEBUG = 1
		--	--	SELECT @date1 'Validated - @spots w/@dates' 		
		--	/* PJH 03/09/18 - Added check for existing dates */			
		--	IF COALESCE(@spots1, 0) = 0 AND @date1_rev IS NULL SET @date1 = NULL
		--	IF COALESCE(@spots2, 0) = 0 AND @date2_rev IS NULL SET @date2 = NULL
		--	IF COALESCE(@spots3, 0) = 0 AND @date3_rev IS NULL SET @date3 = NULL
		--	IF COALESCE(@spots4, 0) = 0 AND @date4_rev IS NULL SET @date4 = NULL
		--	IF COALESCE(@spots5, 0) = 0 AND @date5_rev IS NULL SET @date5 = NULL
		--	IF COALESCE(@spots6, 0) = 0 AND @date6_rev IS NULL SET @date6 = NULL
		--	IF COALESCE(@spots7, 0) = 0 AND @date7_rev IS NULL SET @date7 = NULL
		--END
		
		/* PJH 04/02/18 - Adjust Dates after Update */
		--/* PJH 03/09/18 - Added check for existing dates */			
		--IF @date1_rev IS NOT NULL AND @date1 IS NULL SET @date1 = @date1_rev
		--IF @date2_rev IS NOT NULL AND @date2 IS NULL SET @date2 = @date2_rev
		--IF @date3_rev IS NOT NULL AND @date3 IS NULL SET @date3 = @date3_rev
		--IF @date4_rev IS NOT NULL AND @date4 IS NULL SET @date4 = @date4_rev
		--IF @date5_rev IS NOT NULL AND @date5 IS NULL SET @date5 = @date5_rev
		--IF @date6_rev IS NOT NULL AND @date6 IS NULL SET @date6 = @date6_rev
		--IF @date7_rev IS NOT NULL AND @date7 IS NULL SET @date7 = @date7_rev	
		
		--SELECT 'DATES>>>' 'DESC', @date1_rev, @date2_rev, @date3_rev, @date4_rev, @date5_rev, @date6_rev, @date7_rev	

		IF @cal_type = 'BM' BEGIN	
			SET @temp_date = @end_date
			
			SELECT @end_date = MAX(A.BRD_WEEK_END) FROM @brdcast_weeks2 A
			WHERE A.BRD_MONTH = @month_nbr AND A.BRD_YEAR = @year_nbr 
		END	

		IF @cal_type = 'DB' BEGIN	
			SET @month_nbr = @month_nbr
			SET @year_nbr = @year_nbr
		END

		IF @spots1+@spots2+@spots3+@spots4+@spots5+@spots6 > 2100000000 BEGIN
			SET @error_msg_w = 'Total spots exceeded the maximum allowed (2,100,000,000)! ' + @ret_val_s
			GOTO ERROR_MSG
		END

		SET @total_spots = @spots1+@spots2+@spots3+@spots4+@spots5+@spots6

		IF @total_spots <> (@spots1+@spots2+@spots3+@spots4+@spots5+@spots6) BEGIN
			SET @error_msg_w = 'Total spots is not equal to the sum of the spots by period! ' + @ret_val_s
			GOTO ERROR_MSG
		END 
		
		IF @cal_type = 'CM' BEGIN	
			SET @month_nbr = CAST(LEFT(@temp_mmyyyy,2) AS int)
			SET @year_nbr = CAST(RIGHT(@temp_mmyyyy,4) AS int)
		END	
	
	END		/* End TV, Radio Dates & Spots */											
	
	--SELECT 'BEF EXEC' '-', @gross_rate '@gross_rate', @net_rate '@net_rate', @net_gross '@net_gross', @quantity '@quantity', @ext_net_amt '@ext_net_amt', @ext_gross_amt '@ext_gross_amt'

	--IF @DEBUG = 1
	--	SELECT 'DETAIL INFO PASSED ' 'DESC', @order_nbr ORDER_NBR, @line_nbr LINE_NBR, @link_id LINK_ID, @link_detid LINKE_DETID, @rev_nbr_import REV_NBR, @vn_code 'VN_CODE', @remarks '@remarks'  /** DEBUG **/

	--IF @DEBUG = 1
	--	SELECT @start_date '@start_date' , @date1 '@date1', @date2 '@date2', @date3 '@date3', @date4 '@date4', @date5 '@date5', @date6 '@date6', @month_nbr'@month_nbr', @year_nbr '@year_nbr'  /* DEBUG */
			
	EXECUTE @RC = [dbo].[advsp_revise_order_detail] 
		@user_id  ,@action  ,@order_type  ,@order_type_chg   
		,@rebate_amt_override, @rebate_pct_override, @markup_pct_override, @comm_pct_override
		,@ret_val OUTPUT,@ret_val_s OUTPUT
		,@order_nbr  ,@line_nbr  ,@rev_nbr  ,@seq_nbr  ,@active_rev  ,@link_detid  
		,@start_date  ,@end_date  ,@close_date  ,@matl_close_date  ,@ext_close_date  ,@ext_matl_date
		,@buy_type  ,@month_nbr  ,@year_nbr
		,@date1  ,@date2  ,@date3  ,@date4  ,@date5  ,@date6  ,@date7
		,@monday  ,@tuesday  ,@wednesday  ,@thursday  ,@friday  ,@saturday  ,@sunday
		,@spots1  ,@spots2  ,@spots3  ,@spots4  ,@spots5  ,@spots6  ,@spots7  ,@total_spots
		,@job_number  ,@job_component_nbr  ,@quantity  ,@rate  ,@net_rate  ,@gross_rate
		,@ext_net_amt  ,@ext_gross_amt  ,@comm_amt  ,@rebate_amt  ,@discount_amt  ,@discount_desc
		,@state_amt  ,@county_amt  ,@city_amt  ,@non_resale_amt  ,@netcharge  ,@ncdesc  ,@addl_charge  ,@addl_charge_desc
		,@line_total  ,@date_to_bill  ,@non_bill_flag  ,@modified_by  ,@modified_date  ,@modified_comments
		,@bill_type_flag  ,@comm_pct  ,@markup_pct  ,@rebate_pct  ,@discount_pct
		,@tax_code  ,@tax_city_pct  ,@tax_county_pct  ,@tax_state_pct  ,@tax_resale
		,@taxapplyc  ,@taxapplyln  ,@taxapplynd  ,@taxapplync  ,@taxapplyr  ,@taxapplyai
		,@reconcile_flag  ,@billing_amt  ,@est_nbr  ,@est_line_nbr  ,@est_rev_nbr
		,@ad_number  ,@mat_comp  ,@units  ,@cost_type  ,@cost_rate  ,@net_base_rate  ,@gross_base_rate
		,@programming  ,@start_time  ,@end_time  ,@length  ,@remarks  ,@tag  ,@network_id
		,@headline  ,@size  ,@edition_issue  ,@material  ,@section  ,@rate_card_id  ,@rate_dtl_id
		,@contract_qty  ,@flat_net  ,@flat_gross  ,@prod_charge  ,@prod_desc  ,@color_charge  ,@color_desc
		,@print_columns  ,@print_inches  ,@print_lines  ,@np_circulation  ,@print_quantity
		,@bleed_pct  ,@bleed_amt  ,@position_pct  ,@position_amt  ,@premium_pct  ,@premium_amt
		,@flat_netcharge  ,@flat_addl_charge  ,@flat_discount_amt  ,@production_size  ,@size_code
		,@mg_circulation  ,@o_type  ,@url_location  ,@copy_area  ,@rate_card  ,@rate_type  ,@rate_desc
		,@proj_impressions  ,@guaranteed_impress ,@act_impressions  ,@target_audience  ,@creative_size
		,@placement_1  ,@placement_2, @prc_status
		,@ad_server_placement_id  
		,@ad_server_created_by  
		,@ad_server_created_datetime  
		,@ad_server_last_modified_by  
		,@ad_server_last_modified_datetime  
		,@ad_server_placement_manual
		,@package_parent --PJH 12/12/17 - added
		,@ad_server_placement_group_id
		--PJH 08/18/17 - Added
		,@cable_network_station_code 
		,@daypart_id 
		,@added_value 
		,@bookend 
		,@link_line_number

		,NULL --@is_quote
		,NULL --@override_non_resale_amt 
		,0 --@override_rates bit

		,@line_ad_server_id --PJH 12/06/18 - Added @line_market_code, @ad_server_id
		,@line_market_code

		,0 --@strata_net_calc

		,@channel --PJH 02/14/20 - Added @@channel & @tactic
		,@tactic

	IF @ret_val <> 0 BEGIN
		SET @error_msg_w = 'Error updating Order Detail values! ' + @ret_val_s
		GOTO ERROR_MSG
	END 

	--SELECT DATE1,DATE2,DATE3,DATE4,DATE5,DATE6,SPOTS1,SPOTS2,SPOTS3,SPOTS4,SPOTS5, SPOTS6, * /* DEBUG */
	--FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr 

	/* PJH 12/27/18 - Clear ACTIVE_REV flag for all previous REV's - Any current packages will be inserted later */
	IF @media_type_in IN ('I') AND @action = 'REVISE' BEGIN
		UPDATE INTERNET_PACKAGE_DETAIL
		SET [ACTIVE_REV] = 0
		WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr
	END

	IF @media_type_in IN ('T') BEGIN
		UPDATE TV_DETAIL SET [VENDOR_ORDER_LINE] = @vendor_order_line
		WHERE ORDER_NBR = @order_nbr  AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr  AND ACTIVE_REV = 1
	END
	ELSE IF @media_type_in IN ('R') BEGIN
		UPDATE RADIO_DETAIL SET [VENDOR_ORDER_LINE] = @vendor_order_line
		WHERE ORDER_NBR = @order_nbr  AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr  AND ACTIVE_REV = 1
	END

	--SELECT @air_date '@air_date', @instructions '@instructions', @order_copy '@order_copy', @matl_notes '@matl_notes', @position_info '@position_info',
	--@close_info '@close_info', @rate_info '@rate_info', @misc_info '@misc_info', @media_type_in '@media_type_in', @dtl_cmnt_exists '@dtl_cmnt_exists'        /* DEBUG */
	
	IF @media_type_in =  'N' BEGIN
		SELECT @dtl_cmnt_exists = 1 FROM [dbo].[NEWSPAPER_COMMENTS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
		IF @dtl_cmnt_exists = 0 BEGIN
			INSERT INTO [dbo].[NEWSPAPER_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[MATL_NOTES]
					   ,[POSITION_INFO]
					   ,[CLOSE_INFO]
					   ,[RATE_INFO]
					   ,[MISC_INFO]
					   ,[IN_HOUSE_CMTS])
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@matl_notes 
					,@position_info 
					,@close_info 
					,@rate_info 
					,@misc_info 
					,@in_house_cmts )
		END 
		ELSE BEGIN
			UPDATE [dbo].[NEWSPAPER_COMMENTS]
			SET	    [INSTRUCTIONS] = @instructions
					   ,[ORDER_COPY] = @order_copy
					   ,[MATL_NOTES] = @matl_notes
					   ,[POSITION_INFO] = @position_info
					   ,[CLOSE_INFO] = @close_info
					   ,[RATE_INFO] = @rate_info
					   ,[MISC_INFO] = @misc_info
					   ,[IN_HOUSE_CMTS] = @in_house_cmts
			WHERE [ORDER_NBR] = @order_nbr
				AND [LINE_NBR] = @line_nbr				   
		END
	END
	ELSE IF @media_type_in =  'M' BEGIN
		SELECT @dtl_cmnt_exists = 1 FROM [dbo].[MAGAZINE_COMMENTS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
		IF @dtl_cmnt_exists = 0 BEGIN
			INSERT INTO [dbo].[MAGAZINE_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[MATL_NOTES]
					   ,[POSITION_INFO]
					   ,[CLOSE_INFO]
					   ,[RATE_INFO]
					   ,[MISC_INFO]
					   ,[IN_HOUSE_CMTS])
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@matl_notes 
					,@position_info 
					,@close_info 
					,@rate_info 
					,@misc_info 
					,@in_house_cmts )
		END 
		ELSE BEGIN
			UPDATE [dbo].[MAGAZINE_COMMENTS]
			SET	    [INSTRUCTIONS] = @instructions
					   ,[ORDER_COPY] = @order_copy
					   ,[MATL_NOTES] = @matl_notes
					   ,[POSITION_INFO] = @position_info
					   ,[CLOSE_INFO] = @close_info
					   ,[RATE_INFO] = @rate_info
					   ,[MISC_INFO] = @misc_info
					   ,[IN_HOUSE_CMTS] = @in_house_cmts
			WHERE [ORDER_NBR] = @order_nbr
				AND [LINE_NBR] = @line_nbr				   
		END
	END
	ELSE IF @media_type_in =  'I' BEGIN
		SELECT @dtl_cmnt_exists = 1 FROM [dbo].[INTERNET_COMMENTS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
		IF @dtl_cmnt_exists = 0 BEGIN
			INSERT INTO [dbo].[INTERNET_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[MATL_NOTES]
					   ,[MISC_INFO] )
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@matl_notes 
					,@misc_info )
		END 
		ELSE BEGIN
			UPDATE [dbo].[INTERNET_COMMENTS]
			SET	    [INSTRUCTIONS] = @instructions
					   ,[ORDER_COPY] = @order_copy
					   ,[MATL_NOTES] = @matl_notes
					   ,[MISC_INFO] = @misc_info
			WHERE [ORDER_NBR] = @order_nbr
				AND [LINE_NBR] = @line_nbr				   
		END
	END
	ELSE IF @media_type_in =  'O' BEGIN
		SELECT @dtl_cmnt_exists = 1 FROM [dbo].[OUTDOOR_COMMENTS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
		IF @dtl_exists = 0 OR @dtl_cmnt_exists = 0 BEGIN
			INSERT INTO [dbo].[OUTDOOR_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[MATL_NOTES]
					   ,[MISC_INFO] )
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@matl_notes 
					,@misc_info )
		END 
		ELSE BEGIN
			UPDATE [dbo].[OUTDOOR_COMMENTS]
			SET	    [INSTRUCTIONS] = @instructions
					   ,[ORDER_COPY] = @order_copy
					   ,[MATL_NOTES] = @matl_notes
					   ,[MISC_INFO] = @misc_info
			WHERE [ORDER_NBR] = @order_nbr
				AND [LINE_NBR] = @line_nbr				   
		END
	END
	ELSE IF @media_type_in =  'T' BEGIN
		SELECT @dtl_cmnt_exists = 1 FROM [dbo].[TV_COMMENTS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
				
		IF @dtl_exists = 0 OR @dtl_cmnt_exists = 0 BEGIN
			INSERT INTO [dbo].[TV_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[POSITION_INFO]
					   ,[CLOSE_INFO]
					   ,[RATE_INFO]					   
					   ,[MATL_NOTES]
					   ,[MISC_INFO] )
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@position_info 
					,@close_info 
					,@rate_info 					
					,@matl_notes 
					,@misc_info )
		END 
		ELSE BEGIN
			UPDATE [dbo].[TV_COMMENTS]
			SET	    [INSTRUCTIONS] = @instructions
					   ,[ORDER_COPY] = @order_copy
					   ,[MATL_NOTES] = @matl_notes
					   ,[POSITION_INFO] = @position_info
					   ,[CLOSE_INFO] = @close_info
					   ,[RATE_INFO] = @rate_info					   
					   ,[MISC_INFO] = @misc_info
			WHERE [ORDER_NBR] = @order_nbr
				AND [LINE_NBR] = @line_nbr				   
		END
	END
	ELSE IF @media_type_in =  'R' BEGIN
		SELECT @dtl_cmnt_exists = 1 FROM [dbo].[RADIO_COMMENTS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
		IF @dtl_exists = 0 OR @dtl_cmnt_exists = 0 BEGIN
			INSERT INTO [dbo].[RADIO_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[POSITION_INFO]
					   ,[CLOSE_INFO]
					   ,[RATE_INFO]					   
					   ,[MATL_NOTES]
					   ,[MISC_INFO] )
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@position_info 
					,@close_info 
					,@rate_info 					
					,@matl_notes 
					,@misc_info )
		END 
		ELSE BEGIN
			UPDATE [dbo].[RADIO_COMMENTS]
			SET	    [INSTRUCTIONS] = @instructions
					   ,[ORDER_COPY] = @order_copy
					   ,[MATL_NOTES] = @matl_notes
					   ,[POSITION_INFO] = @position_info
					   ,[CLOSE_INFO] = @close_info
					   ,[RATE_INFO] = @rate_info					   
					   ,[MISC_INFO] = @misc_info
			WHERE [ORDER_NBR] = @order_nbr
				AND [LINE_NBR] = @line_nbr				   
		END
	END

	NEXT_ROW:

	/** Set Temp flag here **/
	UPDATE @tmp_orders SET POST_FLAG = 1
	WHERE RowID = @ROW_ID 	

	UPDATE @tmp_orders2 SET POST_FLAG = 1
	WHERE RowID = @ROW_ID 	

	IF @order_type IN ('NP','MA','IN','OD') BEGIN
		If @dtl_exists = 0 BEGIN
			INSERT INTO dbo.PRINT_IMPORT_XREF
					   (IMPORT_ORDER_NBR
					   ,ORDER_NBR
					   ,IMPORT_LINE_NBR
					   ,LINE_NBR
					   ,MEDIA_TYPE
					   ,IMPORTED_FROM
					   ,LAST_DATE_REVISED
					   ,LAST_USERID
					   ,IMPORT_SEQUENCE
					   ,IMPORT_AD_NUMBER
					   ,IMPORT_YEAR
					   ,SALES_CLASS_CODE)
				 VALUES (
						@link_id
					   ,@order_nbr
					   ,@link_detid
					   ,@line_nbr
					   ,@media_type
					   ,@media_interface_in
					   ,@modified_date
					   ,@user_id
					   ,NULL
					   ,LEFT(@ad_number, 25) /* PJH 07/14/16 - can only store 25 in Xref */
					   ,YEAR(@modified_date)
					   ,@sales_class_code	)
		END
		ELSE BEGIN
			UPDATE dbo.PRINT_IMPORT_XREF
				SET LAST_DATE_REVISED = @modified_date,
					LAST_USERID = @user_id
				WHERE IMPORT_ORDER_NBR = @link_id AND
						IMPORT_LINE_NBR = @link_detid AND
						ORDER_NBR = @order_nbr AND
						LINE_NBR = @line_nbr
		END
	END
	ELSE BEGIN
		If @dtl_exists = 0 BEGIN
			INSERT INTO dbo.BRD_IMPORT_XREF
					   (IMPORT_ORDER_NBR
					   ,ORDER_NBR
					   ,IMPORT_LINE_NBR
					   ,LINE_NBR
					   ,MEDIA_TYPE
					   ,IMPORTED_FROM
					   ,LAST_DATE_REVISED
					   ,LAST_USERID
						)
				 VALUES (
						@link_id
					   ,@order_nbr
					   ,@link_detid
					   ,@line_nbr
					   ,@media_type
					   ,@media_interface_in
					   ,@modified_date
					   ,@user_id
						)
		END
		ELSE BEGIN
			UPDATE dbo.BRD_IMPORT_XREF
				SET LAST_DATE_REVISED = @modified_date,
					LAST_USERID = @user_id
				WHERE IMPORT_ORDER_NBR = @link_id AND
						IMPORT_LINE_NBR = @link_detid AND
						ORDER_NBR = @order_nbr AND
						LINE_NBR = @line_nbr
		END
	END

	/* PJH 04/02/1/8 - Adjust dates as needed - Clear if never any spots */

	DECLARE @max_spots1 int, @max_spots2 int, @max_spots3 int, @max_spots4 int, @max_spots5 int, @max_spots6 int 

	SELECT @max_spots1 = MAX(SPOTS1), @max_spots2 = MAX(SPOTS2), @max_spots3 = MAX(SPOTS3), @max_spots4 =  MAX(SPOTS4), @max_spots5 = MAX(SPOTS5), @max_spots6 = MAX(SPOTS6)
	FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr
	GROUP BY ORDER_NBR, LINE_NBR

	--SELECT @order_nbr, @line_nbr, @max_spots1 , @max_spots2 , @max_spots3 , @max_spots4 , @max_spots5 , @max_spots6  

	UPDATE TV_DETAIL 
	SET DATE1 = CASE WHEN @max_spots1 > 0 THEN DATE1 ELSE NULL END,
			DATE2 = CASE WHEN @max_spots2 > 0 THEN DATE2 ELSE NULL END,
			DATE3 = CASE WHEN @max_spots3 > 0 THEN DATE3 ELSE NULL END,
			DATE4 = CASE WHEN @max_spots4 > 0 THEN DATE4 ELSE NULL END,
			DATE5 = CASE WHEN @max_spots5 > 0 THEN DATE5 ELSE NULL END,
			DATE6 = CASE WHEN @max_spots6 > 0 THEN DATE6 ELSE NULL END
	WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1

	SELECT @max_spots1 = MAX(SPOTS1), @max_spots2 = MAX(SPOTS2), @max_spots3 = MAX(SPOTS3), @max_spots4 =  MAX(SPOTS4), @max_spots5 = MAX(SPOTS5), @max_spots6 = MAX(SPOTS6)
	FROM RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr
	GROUP BY ORDER_NBR, LINE_NBR

	--SELECT @order_nbr, @line_nbr, @max_spots1 , @max_spots2 , @max_spots3 , @max_spots4 , @max_spots5 , @max_spots6  

	UPDATE RADIO_DETAIL 
	SET DATE1 = CASE WHEN @max_spots1 > 0 THEN DATE1 ELSE NULL END,
			DATE2 = CASE WHEN @max_spots2 > 0 THEN DATE2 ELSE NULL END,
			DATE3 = CASE WHEN @max_spots3 > 0 THEN DATE3 ELSE NULL END,
			DATE4 = CASE WHEN @max_spots4 > 0 THEN DATE4 ELSE NULL END,
			DATE5 = CASE WHEN @max_spots5 > 0 THEN DATE5 ELSE NULL END,
			DATE6 = CASE WHEN @max_spots6 > 0 THEN DATE6 ELSE NULL END
	WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1

	/** Store all related plan info to update at the end **/
	--PJH 03/06/18 - VENDOR_ORDER_LINE to all BRDCAST plan related SQL below
	IF @order_type IN ('NP','MA','OD','IN') BEGIN
		--PJH 09/15/17 - Changed @media_type_in to @media_interface_in IN SELECT
		INSERT INTO @tmp_plan_ids (ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, PLAN_ID_C, PLAN_ID, AUTHORIZATION_FLAG, MEDIA_INTERFACE)
		SELECT B.ACCT_ORD_NBR, B.ITEM_NBR, @order_nbr, @line_nbr, PLAN_ID_C, PLAN_ID, NULL, @media_interface_in
		FROM ( SELECT ACCT_ORD_NBR, ITEM_NBR, 
					 variable.a.value('.', 'VARCHAR(MAX)') AS PLAN_ID_C, 0 AS PLAN_ID
				 FROM  
				 ( SELECT ACCT_ORD_NBR, CAST(ITEM_NBR AS INT) AS ITEM_NBR, 
						 CAST ('<M>' + REPLACE(PLAN_IDS, ',', '</M><M>') + '</M>' AS XML) AS Data  
					 FROM  @tmp_orders WHERE ACCT_ORD_NBR = @link_id AND CAST(ITEM_NBR AS INT) = @link_detid AND MEDIA_TYPE = @media_type_in AND [MEDIA_INTERFACE] = @media_interface_in
				 ) AS A CROSS APPLY Data.nodes ('/M') AS variable(a) ) B
	END
	ELSE BEGIN /* 'TV','RA' */
		-- ZZZ SELECT 'PLANS - BRDCAST' ' -'
		INSERT INTO @tmp_plan_ids (ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, PLAN_ID_C, PLAN_ID, AUTHORIZATION_FLAG, MEDIA_INTERFACE, VENDOR_ORDER_LINE)
		SELECT B.ACCT_ORD_NBR, B.ITEM_NBR, @order_nbr, @line_nbr, PLAN_ID_C, PLAN_ID, NULL, @media_interface_in, VENDOR_ORDER_LINE
		FROM ( SELECT ACCT_ORD_NBR, ITEM_NBR, 
					 variable.a.value('.', 'VARCHAR(MAX)') AS PLAN_ID_C, 0 AS PLAN_ID, VENDOR_ORDER_LINE
				 FROM  
				 ( SELECT LINK_ID AS ACCT_ORD_NBR, CAST(LINE_NBR AS INT) AS ITEM_NBR, 
						 CAST ('<M>' + REPLACE(PLAN_IDS, ',', '</M><M>') + '</M>' AS XML) AS Data, VENDOR_ORDER_LINE
					 FROM  @tmp_orders2 WHERE LINK_ID = @link_id AND CAST(LINE_NBR AS INT) = @link_detid AND MEDIA_TYPE = @media_type_in AND [MEDIA_INTERFACE] = @media_interface_in
				 ) AS A CROSS APPLY Data.nodes ('/M') AS variable(a) ) B
	END

	SET @ROW_ID = @ROW_ID + 1

END /* While */

SELECT 'BEFORE PLANS'

--IF @DEBUG = 1 SELECT * FROM @tmp_plan_ids   /* DEBUG */

/** Update Temp Flag to PRINT_ORDER table **/
UPDATE A SET A.POST_FLAG = B.POST_FLAG
FROM PRINT_ORDER A INNER JOIN @tmp_orders B ON A.RECSEQ = B.RECSEQ
WHERE B.POST_FLAG = 1

/** Update Temp Flag to BRDCAST_IMPORT table **/
UPDATE A SET A.POST_FLAG = B.POST_FLAG
FROM BRDCAST_IMPORT A INNER JOIN @tmp_orders2 B ON A.RECSEQ = B.RECSEQ
WHERE B.POST_FLAG = 1

/** Reorder so latest record is used for update if duplicate PLAN_ID's **/
INSERT INTO @tmp_plan_ids2 (ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, PLAN_ID_C, PLAN_ID, AUTHORIZATION_FLAG, MEDIA_INTERFACE, VENDOR_ORDER_LINE )
SELECT ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, 'P', CAST(PLAN_ID_C AS int), AUTHORIZATION_FLAG, MEDIA_INTERFACE, VENDOR_ORDER_LINE
FROM @tmp_plan_ids WHERE LEFT(PLAN_ID_C, 1) <> 'A'
ORDER BY PLAN_ID, RowID DESC

--IF @DEBUG = 1 
--	SELECT ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, 'A', CAST(RIGHT(PLAN_ID_C, LEN(PLAN_ID_C) - 1) AS int), AUTHORIZATION_FLAG 
--	FROM @tmp_plan_ids WHERE LEFT(PLAN_ID_C, 1) = 'A'
--	ORDER BY PLAN_ID, RowID DESC
INSERT INTO @tmp_plan_ids2 (ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, PLAN_ID_C, PLAN_ID, AUTHORIZATION_FLAG, MEDIA_INTERFACE, VENDOR_ORDER_LINE )
SELECT ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, 'A', CAST(RIGHT(PLAN_ID_C, LEN(PLAN_ID_C) - 1) AS int), AUTHORIZATION_FLAG, MEDIA_INTERFACE, VENDOR_ORDER_LINE 
FROM @tmp_plan_ids WHERE LEFT(PLAN_ID_C, 1) = 'A'
ORDER BY PLAN_ID, RowID DESC

INSERT INTO @tmp_plan_ids3 (ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, PLAN_ID_C, PLAN_ID, AUTHORIZATION_FLAG, MEDIA_INTERFACE, VENDOR_ORDER_LINE)
SELECT DISTINCT ACCT_ORD_NBR, ITEM_NBR, ORDER_NBR, LINE_NBR, PLAN_ID_C, PLAN_ID, AUTHORIZATION_FLAG, MEDIA_INTERFACE, VENDOR_ORDER_LINE FROM @tmp_plan_ids2
ORDER BY ACCT_ORD_NBR, ITEM_NBR, PLAN_ID

/** Update Temp Data to plan tables **/
UPDATE @tmp_plan_ids3 SET AUTHORIZATION_FLAG = 1
WHERE PLAN_ID_C = 'A'

/** Update Plans **/
UPDATE A SET A.ORDER_ID = B.ACCT_ORD_NBR, ORDER_LINE_ID = B.ITEM_NBR, A.ORDER_NBR = B.ORDER_NBR, ORDER_LINE_NBR = B.LINE_NBR, A.HAS_PENDING_ORDERS = 0
FROM MEDIA_PLAN_DTL_LEVEL_LINE_DATA A INNER JOIN @tmp_plan_ids3 B ON A.MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID = B.PLAN_ID
WHERE B.AUTHORIZATION_FLAG IS NULL AND MEDIA_INTERFACE = 'AM'

--PJH 08/18/17 - Added Broadcast Worksheet
--PJH 03/06/18 - Added VENDOR_ORDER_LINE to update
/** Update Worksheet **/
UPDATE A SET A.LINK_ID = B.ACCT_ORD_NBR, LINK_LINE_ID = B.ITEM_NBR, A.ORDER_NBR = B.ORDER_NBR, ORDER_LINE_NBR = B.LINE_NBR, 
			VENDOR_ORDER_LINE = B.VENDOR_ORDER_LINE, A.MEDIA_BROADCAST_WORKSHEET_ORDER_STATUS_ID = 3
FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A INNER JOIN @tmp_plan_ids3 B ON A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE_ID = B.PLAN_ID
WHERE B.AUTHORIZATION_FLAG IS NULL AND (MEDIA_INTERFACE = 'AW' OR MEDIA_INTERFACE = 'MM')

--MJC temp table to put entries into TV_ORDER_STATUS/RADIO_ORDER_STATUS and MEDIA_MGR_GENERATED_REPORT_DETAIL
DECLARE @ORDER_LINE_PROCESS TABLE (
	ID int NOT NULL IDENTITY(1,1),
	ORDER_NBR int NOT NULL,
	LINE_NBR int NOT NULL,
	REV_NBR int NOT NULL
)
declare @olp_id int,
		@olp_order_nbr int,
		@olp_line_nbr int,
		@olp_rev_nbr int,
		@mmgr_ID int

--PJH 10/31/17 - Added update Worksheet LINE_NUMBER to TV/RADIO DETAIL table
IF @order_type = 'TV' BEGIN
	UPDATE AA SET AA.LINK_LINE_NUMBER = C.LINE_NUMBER--, AA.STATION_ID = C.STATION_ID
	FROM TV_DETAIL AA	
	INNER JOIN @tmp_plan_ids3 B ON AA.ORDER_NBR = B.ORDER_NBR AND AA.LINE_NBR = B.LINE_NBR
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A ON A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE_ID = B.PLAN_ID
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL C ON C.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	WHERE B.AUTHORIZATION_FLAG IS NULL AND (MEDIA_INTERFACE = 'AW' OR MEDIA_INTERFACE = 'MM') AND C.LINE_NUMBER IS NOT NULL AND AA.ACTIVE_REV = 1

	IF @MAKEGOOD = 1 BEGIN
		INSERT INTO @ORDER_LINE_PROCESS (ORDER_NBR, LINE_NBR, REV_NBR)
		SELECT DISTINCT AA.ORDER_NBR, AA.LINE_NBR, AA.REV_NBR
		FROM TV_DETAIL AA	
			INNER JOIN @tmp_plan_ids3 B ON AA.ORDER_NBR = B.ORDER_NBR AND AA.LINE_NBR = B.LINE_NBR
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A ON A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE_ID = B.PLAN_ID
		WHERE B.AUTHORIZATION_FLAG IS NULL AND (MEDIA_INTERFACE = 'AW' OR MEDIA_INTERFACE = 'MM') AND AA.ACTIVE_REV = 1

		WHILE EXISTS(SELECT 1 FROM @ORDER_LINE_PROCESS)
		BEGIN
			SELECT TOP 1 @olp_id = ID, @olp_order_nbr = ORDER_NBR, @olp_line_nbr = LINE_NBR, @olp_rev_nbr = REV_NBR
			FROM @ORDER_LINE_PROCESS 

			UPDATE os SET REVISED_DATE = @line_revised_date
			FROM dbo.TV_ORDER_STATUS os
				INNER JOIN
					(
					SELECT a.ORDER_NBR, a.LINE_NBR, a.REV_NBR 
					FROM dbo.TV_ORDER_STATUS a
						INNER JOIN (
									SELECT MAX(REV_NBR) as MAX_REV_NBR, LINE_NBR
									FROM dbo.TV_ORDER_STATUS a
									WHERE ORDER_NBR = @olp_order_nbr
									GROUP BY LINE_NBR
									) m ON a.LINE_NBR = m.LINE_NBR AND a.REV_NBR = m.MAX_REV_NBR 
						INNER JOIN (
									SELECT MAX(REVISED_DATE) as MAX_REVISED_DATE, LINE_NBR, MAX(REV_NBR) AS MAX_REV_NBR
									FROM dbo.TV_ORDER_STATUS 
									WHERE ORDER_NBR = @olp_order_nbr
									group by LINE_NBR, REV_NBR 
									) b ON a.LINE_NBR = b.LINE_NBR AND a.REV_NBR = b.MAX_REV_NBR AND a.REVISED_DATE = b.MAX_REVISED_DATE 
					WHERE a.ORDER_NBR = @olp_order_nbr
					AND a.[STATUS] = 18
					) dtl ON os.ORDER_NBR = dtl.ORDER_NBR AND os.LINE_NBR = dtl.LINE_NBR AND os.REV_NBR = dtl.REV_NBR AND os.[STATUS] = 5
		
			SELECT @mmgr_ID = MAX(MEDIA_MGR_GENERATED_REPORT_ID)
			FROM dbo.MEDIA_MGR_GENERATED_REPORT 
			WHERE ORDER_NBR = @olp_order_nbr
	
			IF NOT EXISTS(SELECT 1 FROM dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL mmgrd INNER JOIN dbo.TV_DETAIL td ON td.ORDER_NBR = @olp_order_nbr AND mmgrd.LINE_NBR = td.LINE_NBR AND td.LINE_NBR = @olp_line_nbr AND mmgrd.REV_NBR = td.REV_NBR AND td.REV_NBR = @olp_rev_nbr AND td.ACTIVE_REV = 1
						  WHERE mmgrd.MEDIA_MGR_GENERATED_REPORT_ID = @mmgr_ID AND mmgrd.LINE_NBR = @olp_line_nbr) AND EXISTS
						 (SELECT 1 FROM dbo.TV_DETAIL td INNER JOIN (
														SELECT DISTINCT td.[START_DATE], td.END_DATE 
														FROM dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL mmgrd
															INNER JOIN dbo.TV_DETAIL td ON td.ORDER_NBR = @olp_order_nbr AND mmgrd.LINE_NBR = td.LINE_NBR AND td.ACTIVE_REV = 1
														where MEDIA_MGR_GENERATED_REPORT_ID = @mmgr_ID
														) dtl ON td.[START_DATE] = dtl.[START_DATE] AND td.END_DATE = dtl.END_DATE 
						  WHERE td.ORDER_NBR = @olp_order_nbr
						  AND td.LINE_NBR = @olp_line_nbr
						  AND td.ACTIVE_REV = 1)
				INSERT INTO dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL(MEDIA_MGR_GENERATED_REPORT_ID, LINE_NBR, REV_NBR, IS_CANCELLED)
				SELECT @mmgr_ID, @olp_line_nbr, @olp_rev_nbr, 0
		
			IF @olp_rev_nbr > 0 AND NOT EXISTS(SELECT 1 FROM dbo.TV_ORDER_STATUS WHERE ORDER_NBR = @olp_order_nbr AND LINE_NBR = @olp_line_nbr AND REV_NBR = @olp_rev_nbr AND [STATUS] = 5)
				INSERT INTO dbo.TV_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME)
				SELECT ORDER_NBR, LINE_NBR, @olp_rev_nbr, 5, @line_revised_date, REVISED_BY, (SELECT REVISED_BY_NAME
																								FROM dbo.TV_ORDER_STATUS 
																								WHERE ORDER_NBR = @olp_order_nbr
																								AND LINE_NBR = @olp_line_nbr
																								AND REV_NBR = @olp_rev_nbr - 1
																								AND [STATUS] = 5)
				FROM dbo.TV_ORDER_STATUS 
				WHERE ORDER_NBR = @olp_order_nbr
				AND LINE_NBR = @olp_line_nbr
				AND REV_NBR = @olp_rev_nbr - 1
				AND [STATUS] = 18

			IF @olp_rev_nbr = 0 AND NOT EXISTS(SELECT 1 FROM dbo.TV_ORDER_STATUS WHERE ORDER_NBR = @olp_order_nbr AND LINE_NBR = @olp_line_nbr AND REV_NBR = @olp_rev_nbr AND [STATUS] = 5)
				INSERT INTO dbo.TV_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME)
				SELECT @olp_order_nbr, @olp_line_nbr, @olp_rev_nbr, 5, @line_revised_date, (SELECT TOP 1 REVISED_BY
																							FROM dbo.TV_ORDER_STATUS 
																							WHERE ORDER_NBR = @olp_order_nbr
																							AND [STATUS] = 5
																							ORDER BY REVISED_DATE DESC), (SELECT TOP 1 REVISED_BY_NAME
																															FROM dbo.TV_ORDER_STATUS 
																															WHERE ORDER_NBR = @olp_order_nbr
																															AND [STATUS] = 5
																															ORDER BY REVISED_DATE DESC)

			DELETE AA 
			FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE AA	
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL BB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID = BB.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON BB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
			WHERE AB.ORDER_NBR = @olp_order_nbr

			DELETE AA 
			FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL AA	
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
			WHERE AB.ORDER_NBR = @olp_order_nbr

			DELETE @ORDER_LINE_PROCESS WHERE ID = @olp_id 
		END
	END
END
ELSE IF @order_type = 'RA' BEGIN
	UPDATE AA SET AA.LINK_LINE_NUMBER = C.LINE_NUMBER--, AA.STATION_ID = C.STATION_ID
	FROM RADIO_DETAIL AA	
	INNER JOIN @tmp_plan_ids3 B ON AA.ORDER_NBR = B.ORDER_NBR AND AA.LINE_NBR = B.LINE_NBR
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A ON A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE_ID = B.PLAN_ID
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL C ON C.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	WHERE B.AUTHORIZATION_FLAG IS NULL AND (MEDIA_INTERFACE = 'AW' OR MEDIA_INTERFACE = 'MM') AND C.LINE_NUMBER IS NOT NULL AND AA.ACTIVE_REV = 1
	
	IF @MAKEGOOD = 1 BEGIN
		INSERT INTO @ORDER_LINE_PROCESS (ORDER_NBR, LINE_NBR, REV_NBR)
		SELECT DISTINCT AA.ORDER_NBR, AA.LINE_NBR, AA.REV_NBR
		FROM RADIO_DETAIL AA	
			INNER JOIN @tmp_plan_ids3 B ON AA.ORDER_NBR = B.ORDER_NBR AND AA.LINE_NBR = B.LINE_NBR
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A ON A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE_ID = B.PLAN_ID
		WHERE B.AUTHORIZATION_FLAG IS NULL AND (MEDIA_INTERFACE = 'AW' OR MEDIA_INTERFACE = 'MM') AND AA.ACTIVE_REV = 1

		WHILE EXISTS(SELECT 1 FROM @ORDER_LINE_PROCESS)
		BEGIN
			SELECT TOP 1 @olp_id = ID, @olp_order_nbr = ORDER_NBR, @olp_line_nbr = LINE_NBR, @olp_rev_nbr = REV_NBR
			FROM @ORDER_LINE_PROCESS 

			UPDATE os SET REVISED_DATE = @line_revised_date
			FROM dbo.RADIO_ORDER_STATUS os
				INNER JOIN
					(
					SELECT a.ORDER_NBR, a.LINE_NBR, a.REV_NBR 
					FROM dbo.RADIO_ORDER_STATUS a
						INNER JOIN (
									SELECT MAX(REV_NBR) as MAX_REV_NBR, LINE_NBR
									FROM dbo.RADIO_ORDER_STATUS a
									WHERE ORDER_NBR = @olp_order_nbr
									GROUP BY LINE_NBR
									) m ON a.LINE_NBR = m.LINE_NBR AND a.REV_NBR = m.MAX_REV_NBR 
						INNER JOIN (
									SELECT MAX(REVISED_DATE) as MAX_REVISED_DATE, LINE_NBR, MAX(REV_NBR) AS MAX_REV_NBR
									FROM dbo.RADIO_ORDER_STATUS 
									WHERE ORDER_NBR = @olp_order_nbr
									group by LINE_NBR, REV_NBR 
									) b ON a.LINE_NBR = b.LINE_NBR AND a.REV_NBR = b.MAX_REV_NBR AND a.REVISED_DATE = b.MAX_REVISED_DATE 
					WHERE a.ORDER_NBR = @olp_order_nbr
					AND a.[STATUS] = 18
					) dtl ON os.ORDER_NBR = dtl.ORDER_NBR AND os.LINE_NBR = dtl.LINE_NBR AND os.REV_NBR = dtl.REV_NBR AND os.[STATUS] = 5
		
			SELECT @mmgr_ID = MAX(MEDIA_MGR_GENERATED_REPORT_ID)
			FROM dbo.MEDIA_MGR_GENERATED_REPORT 
			WHERE ORDER_NBR = @olp_order_nbr
	
			IF NOT EXISTS(SELECT 1 FROM dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL mmgrd INNER JOIN dbo.RADIO_DETAIL td ON td.ORDER_NBR = @olp_order_nbr AND mmgrd.LINE_NBR = td.LINE_NBR AND td.LINE_NBR = @olp_line_nbr AND mmgrd.REV_NBR = td.REV_NBR AND td.REV_NBR = @olp_rev_nbr AND td.ACTIVE_REV = 1
						  WHERE mmgrd.MEDIA_MGR_GENERATED_REPORT_ID = @mmgr_ID AND mmgrd.LINE_NBR = @olp_line_nbr) AND EXISTS
						 (SELECT 1 FROM dbo.RADIO_DETAIL td INNER JOIN (
														SELECT DISTINCT td.[START_DATE], td.END_DATE 
														FROM dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL mmgrd
															INNER JOIN dbo.RADIO_DETAIL td ON td.ORDER_NBR = @olp_order_nbr AND mmgrd.LINE_NBR = td.LINE_NBR AND td.ACTIVE_REV = 1
														where MEDIA_MGR_GENERATED_REPORT_ID = @mmgr_ID
														) dtl ON td.[START_DATE] = dtl.[START_DATE] AND td.END_DATE = dtl.END_DATE 
						  WHERE td.ORDER_NBR = @olp_order_nbr
						  AND td.LINE_NBR = @olp_line_nbr
						  AND td.ACTIVE_REV = 1)
				INSERT INTO dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL(MEDIA_MGR_GENERATED_REPORT_ID, LINE_NBR, REV_NBR, IS_CANCELLED)
				SELECT @mmgr_ID, @olp_line_nbr, @olp_rev_nbr, 0
		
			IF @olp_rev_nbr > 0 AND NOT EXISTS(SELECT 1 FROM dbo.RADIO_ORDER_STATUS WHERE ORDER_NBR = @olp_order_nbr AND LINE_NBR = @olp_line_nbr AND REV_NBR = @olp_rev_nbr AND [STATUS] = 5)
				INSERT INTO dbo.RADIO_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME)
				SELECT ORDER_NBR, LINE_NBR, @olp_rev_nbr, 5, @line_revised_date, REVISED_BY, (SELECT REVISED_BY_NAME
																								FROM dbo.RADIO_ORDER_STATUS 
																								WHERE ORDER_NBR = @olp_order_nbr
																								AND LINE_NBR = @olp_line_nbr
																								AND REV_NBR = @olp_rev_nbr - 1
																								AND [STATUS] = 5)
				FROM dbo.RADIO_ORDER_STATUS 
				WHERE ORDER_NBR = @olp_order_nbr
				AND LINE_NBR = @olp_line_nbr
				AND REV_NBR = @olp_rev_nbr - 1
				AND [STATUS] = 18
			
			IF @olp_rev_nbr = 0 AND NOT EXISTS(SELECT 1 FROM dbo.RADIO_ORDER_STATUS WHERE ORDER_NBR = @olp_order_nbr AND LINE_NBR = @olp_line_nbr AND REV_NBR = @olp_rev_nbr AND [STATUS] = 5)
				INSERT INTO dbo.RADIO_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME)
				SELECT @olp_order_nbr, @olp_line_nbr, @olp_rev_nbr, 5, @line_revised_date, (SELECT TOP 1 REVISED_BY
																							FROM dbo.RADIO_ORDER_STATUS 
																							WHERE ORDER_NBR = @olp_order_nbr
																							AND [STATUS] = 5
																							ORDER BY REVISED_DATE DESC), (SELECT TOP 1 REVISED_BY_NAME
																															FROM dbo.RADIO_ORDER_STATUS 
																															WHERE ORDER_NBR = @olp_order_nbr
																															AND [STATUS] = 5
																															ORDER BY REVISED_DATE DESC)

			DELETE AA 
			FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE AA	
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL BB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID = BB.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON BB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
			WHERE AB.ORDER_NBR = @olp_order_nbr

			DELETE AA 
			FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL AA	
			INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
			WHERE AB.ORDER_NBR = @olp_order_nbr

			DELETE @ORDER_LINE_PROCESS WHERE ID = @olp_id 
		END
	END
END

--PJH 12/12/17 - Update Internet Detail with PACKAGE_PARENT & PACKAGE_NAME
--PJH 01/02/19 - Updated to use MAX() for Package Name to account for rows in plan that are not updated with the name
IF @order_type = 'IN' BEGIN
	UPDATE A SET A.PACKAGE_PARENT = D.PACKAGE_PARENT, PLACEMENT_2 = NULLIF(D.PACKAGE_NAME,'')
	FROM INTERNET_DETAIL A	
	INNER JOIN @tmp_plan_ids2 B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
	INNER JOIN MEDIA_PLAN_DTL_LEVEL_LINE_DATA C ON C.MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID = B.PLAN_ID
	INNER JOIN (SELECT MEDIA_PLAN_ID, MEDIA_PLAN_DTL_ID, ROW_INDEX, MAX(PACKAGE_NAME) PACKAGE_NAME, 0 PACKAGE_PARENT
		FROM MEDIA_PLAN_DTL_LEVEL_LINE
		GROUP BY MEDIA_PLAN_ID, MEDIA_PLAN_DTL_ID, ROW_INDEX) D ON C.MEDIA_PLAN_ID  = D.MEDIA_PLAN_ID AND C.MEDIA_PLAN_DTL_ID  = D.MEDIA_PLAN_DTL_ID AND C.ROW_INDEX  = D.ROW_INDEX
	WHERE MEDIA_INTERFACE = 'AM' AND A.ACTIVE_REV = 1
END

/* PJH 12/05/18 - Added INTERNET_PACKAGE_DETAIL table logic - Begin */
DECLARE @package_detail TABLE (
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL,
	[SEQ_NBR] [smallint] NOT NULL,
	[SIZE_CODE] [varchar](6) NOT NULL,
	[USER_CREATED] [varchar](100) NOT NULL,
	[CREATED_DATE] [smalldatetime] NOT NULL,
	[AD_SERVER_ID] [smallint] NULL,
	[AD_SERVER_PLACEMENT_ID] [bigint] NULL,
	[AD_SERVER_CREATED_BY] [varchar](100) NULL,
	[AD_SERVER_CREATED_DATETIME] [smalldatetime] NULL,
	[AD_SERVER_LAST_MODIFIED_BY] [varchar](100) NULL,
	[AD_SERVER_LAST_MODIFIED_DATETIME] [smalldatetime] NULL,
	[EXISITING_LINE] [bit],
	[PLACEMENT_NAME] varchar(255),
	[MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID] [int],
	[SIZE_CODES] varchar(max)
	)

DECLARE @size_codes TABLE (
MEDIA_PLAN_ID int,
MEDIA_PLAN_DTL_ID int,
ROW_INDEX int,
MEDIA_TYPE varchar (6),
PLACEMENT_NAME varchar (255),
SIZE_CODE varchar (40)
)

/* SAMPLE ROW */
--MEDIA_PLAN_ID	MEDIA_PLAN_DTL_ID	ROW_INDEX	MEDIA_TYPE	PLACEMENT_NAME	SIZE_CODE
--2054			3207				0			I			mike			120240

INSERT INTO @size_codes
SELECT DISTINCT F.MEDIA_PLAN_ID, F.MEDIA_PLAN_DTL_ID, F.ROW_INDEX, F.MEDIA_TYPE, F.PLACEMENT_NAME, MIN(F.SIZE_CODE) AS SIZE_CODE
FROM [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] A
	JOIN (SELECT MEDIA_PLAN_ID, MEDIA_PLAN_DTL_ID, ROW_INDEX, MEDIA_TYPE, SIZE_CODE FROM [dbo].[MEDIA_PLAN_DTL_PACKAGE_DETAIL]) B 
		ON A.MEDIA_PLAN_ID = B.MEDIA_PLAN_ID AND A.MEDIA_PLAN_DTL_ID = B.MEDIA_PLAN_DTL_ID AND A.ROW_INDEX = B.ROW_INDEX
	JOIN AD_SIZE C ON B.SIZE_CODE = C.SIZE_CODE
	JOIN @tmp_plan_ids2 D ON A.MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID = D.PLAN_ID
	--JOIN (SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REV_NBR) REV_NBR FROM INTERNET_DETAIL A
	--	JOIN @tmp_plan_ids2 B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
	--	GROUP BY A.ORDER_NBR, A.LINE_NBR) E ON D.ORDER_NBR = E.ORDER_NBR AND D.LINE_NBR = E.LINE_NBR
	LEFT JOIN (
			SELECT DISTINCT A.MEDIA_PLAN_ID, A.MEDIA_PLAN_DTL_ID, A.ROW_INDEX, MEDIA_TYPE, B.PLACEMENT_NAME, SIZE_CODE,
				STUFF
				(
					(
						SELECT ',' + SIZE_CODE
						FROM [MEDIA_PLAN_DTL_PACKAGE_DETAIL] SC
						WHERE A.MEDIA_PLAN_ID = SC.MEDIA_PLAN_ID AND A.MEDIA_PLAN_DTL_ID = SC.MEDIA_PLAN_DTL_ID AND A.ROW_INDEX = SC.ROW_INDEX AND A.SIZE_CODE <> SC.SIZE_CODE
						ORDER BY  A.MEDIA_PLAN_ID, A.MEDIA_PLAN_DTL_ID, A.ROW_INDEX
						FOR XML PATH('')
					), 1, 1, ''
				) AS ADDL_SIZE_CODES
			FROM [dbo].[MEDIA_PLAN_DTL_PACKAGE_DETAIL] A JOIN
				[dbo].[MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME] B ON A.MEDIA_PLAN_ID = B.MEDIA_PLAN_ID AND A.MEDIA_PLAN_DTL_ID = B.MEDIA_PLAN_DTL_ID AND A.ROW_INDEX = B.ROW_INDEX
	) F
		ON F.MEDIA_PLAN_ID = A.MEDIA_PLAN_ID AND F.MEDIA_PLAN_DTL_ID = A.MEDIA_PLAN_DTL_ID AND F.ROW_INDEX = A.ROW_INDEX
WHERE F.SIZE_CODE IS NOT NULL
GROUP BY F.MEDIA_PLAN_ID, F.MEDIA_PLAN_DTL_ID, F.ROW_INDEX, F.MEDIA_TYPE, F.PLACEMENT_NAME

/* PJH 03/06/19 - Added DISTINCT to @package_detail INSERT */
/* PJH 08/14/20 - Added Placement Name and Addl Ad Size Codes to INTERNET_PACKAGE_DETAIL */
INSERT INTO @package_detail
SELECT DISTINCT D.ORDER_NBR, D.LINE_NBR, E.REV_NBR, 0, COALESCE(F.SIZE_CODE, B.SIZE_CODE) , 'SYSADM', '12/10/2018', NULL, NULL, NULL, NULL, NULL, NULL, 0, F.PLACEMENT_NAME, F.MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID, F.ADDL_SIZE_CODES--, F.ROW_INDEX
FROM [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] A
	JOIN (SELECT MEDIA_PLAN_ID, MEDIA_PLAN_DTL_ID, ROW_INDEX, MEDIA_TYPE, SIZE_CODE FROM [dbo].[MEDIA_PLAN_DTL_PACKAGE_DETAIL]) B 
		ON A.MEDIA_PLAN_ID = B.MEDIA_PLAN_ID AND A.MEDIA_PLAN_DTL_ID = B.MEDIA_PLAN_DTL_ID AND A.ROW_INDEX = B.ROW_INDEX
	JOIN AD_SIZE C ON B.SIZE_CODE = C.SIZE_CODE
	JOIN @tmp_plan_ids2 D ON A.MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID = D.PLAN_ID
	JOIN (SELECT A.ORDER_NBR, A.LINE_NBR, MAX(REV_NBR) REV_NBR FROM INTERNET_DETAIL A
		JOIN @tmp_plan_ids2 B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
		GROUP BY A.ORDER_NBR, A.LINE_NBR) E ON D.ORDER_NBR = E.ORDER_NBR AND D.LINE_NBR = E.LINE_NBR
	LEFT JOIN (
			SELECT DISTINCT A.MEDIA_PLAN_ID, A.MEDIA_PLAN_DTL_ID, A.ROW_INDEX, A.MEDIA_TYPE, B.PLACEMENT_NAME, B.MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID, A.SIZE_CODE, 
				STUFF
				(
					(
						SELECT ',' + SIZE_CODE
						FROM [MEDIA_PLAN_DTL_PACKAGE_DETAIL] SC
						WHERE A.MEDIA_PLAN_ID = SC.MEDIA_PLAN_ID AND A.MEDIA_PLAN_DTL_ID = SC.MEDIA_PLAN_DTL_ID AND A.ROW_INDEX = SC.ROW_INDEX AND A.SIZE_CODE <> SC.SIZE_CODE
						ORDER BY  A.MEDIA_PLAN_ID, A.MEDIA_PLAN_DTL_ID, A.ROW_INDEX
						FOR XML PATH('')
					), 1, 1, ''
				) AS ADDL_SIZE_CODES
			FROM [dbo].[MEDIA_PLAN_DTL_PACKAGE_DETAIL] A JOIN
				[dbo].[MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME] B ON A.MEDIA_PLAN_ID = B.MEDIA_PLAN_ID AND A.MEDIA_PLAN_DTL_ID = B.MEDIA_PLAN_DTL_ID AND A.ROW_INDEX = B.ROW_INDEX JOIN
				@size_codes C ON A.MEDIA_PLAN_ID = C.MEDIA_PLAN_ID AND A.MEDIA_PLAN_DTL_ID = C.MEDIA_PLAN_DTL_ID AND A.ROW_INDEX = C.ROW_INDEX AND A.MEDIA_TYPE = C.MEDIA_TYPE AND B.PLACEMENT_NAME = C.PLACEMENT_NAME AND A.SIZE_CODE = C.SIZE_CODE
	) F
		ON F.MEDIA_PLAN_ID = A.MEDIA_PLAN_ID AND F.MEDIA_PLAN_DTL_ID = A.MEDIA_PLAN_DTL_ID AND F.ROW_INDEX = A.ROW_INDEX
WHERE COALESCE(F.SIZE_CODE, B.SIZE_CODE) IS NOT NULL

UPDATE A
SET A.EXISITING_LINE = 1
FROM @package_detail A 
JOIN [dbo].[INTERNET_PACKAGE_DETAIL] B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REV_NBR = B.REV_NBR

/* Get AD Server info from prior REV if exists */
UPDATE A
SET A.AD_SERVER_ID = B.AD_SERVER_ID, 
	A.AD_SERVER_PLACEMENT_ID = B.AD_SERVER_PLACEMENT_ID,
	A.AD_SERVER_CREATED_BY = B.AD_SERVER_CREATED_BY,
	A.AD_SERVER_CREATED_DATETIME = B.AD_SERVER_CREATED_DATETIME,
	A.AD_SERVER_LAST_MODIFIED_BY = B.AD_SERVER_LAST_MODIFIED_BY,
	A.AD_SERVER_LAST_MODIFIED_DATETIME = B.AD_SERVER_LAST_MODIFIED_DATETIME
FROM @package_detail A 
JOIN [dbo].[INTERNET_PACKAGE_DETAIL] B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND (A.REV_NBR - 1) = B.REV_NBR AND A.SIZE_CODE = B.AD_SIZE_CODE 
											AND ((A.MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID = B.MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID) OR (B.MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID IS NULL))
WHERE A.EXISITING_LINE = 0

INSERT INTO INTERNET_PACKAGE_DETAIL (
	[ORDER_NBR],
	[LINE_NBR],
	[REV_NBR],
	[SEQ_NBR],
	[ACTIVE_REV],
	[AD_SIZE_CODE],
	[AD_SERVER_ID],
	[AD_SERVER_PLACEMENT_ID],
	[AD_SERVER_CREATED_BY],
	[AD_SERVER_CREATED_DATETIME],
	[AD_SERVER_LAST_MODIFIED_BY] ,
	[AD_SERVER_LAST_MODIFIED_DATETIME],
	[PLACEMENT_NAME],
	[MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID],
	[ADDITIONAL_AD_SIZE_CODES])
SELECT
	[ORDER_NBR],
	[LINE_NBR],
	[REV_NBR],
	[SEQ_NBR],
	1, --ACTIVE_REV
	[SIZE_CODE],
	[AD_SERVER_ID],
	[AD_SERVER_PLACEMENT_ID],
	[AD_SERVER_CREATED_BY],
	[AD_SERVER_CREATED_DATETIME],
	[AD_SERVER_LAST_MODIFIED_BY] ,
	[AD_SERVER_LAST_MODIFIED_DATETIME],
	[PLACEMENT_NAME],
	[MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID],
	[SIZE_CODES]
FROM @package_detail
WHERE EXISITING_LINE = 0

/* PJH 12/27/18 - Clear ACTIVE_REV flag for all previous REV's - see above*/
--UPDATE A
--SET A.[ACTIVE_REV] = 0
--FROM INTERNET_PACKAGE_DETAIL A JOIN @package_detail B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REV_NBR < B.REV_NBR

/* PJH 12/05/18 - Added INTERNET_PACKAGE_DETAIL table logic - End*/

/** Update Authorizations **/
UPDATE A SET A.ORDER_ID = B.ACCT_ORD_NBR, ORDER_LINE_ID = B.ITEM_NBR, A.ORDER_NBR = B.ORDER_NBR, ORDER_LINE_NBR = B.LINE_NBR
FROM ATB_REV_DTL_ORDER A INNER JOIN @tmp_plan_ids3 B ON A.ATB_REV_DTL_ORDER_ID = B.PLAN_ID
WHERE B.AUTHORIZATION_FLAG = 1

SELECT 'BEFORE COMMIT'

IF @@TRANCOUNT > 0
	IF @DEBUG = 1 BEGIN
		SELECT 'ROLLBACK' 'DEBUG', @order_type '@order_type'

		IF @order_type = 'NP' BEGIN
			SELECT 'N-HEADER' 'DESC', *				
			FROM NEWSPAPER_HEADER A WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM NEWSPAPER_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			SELECT 'DETAIL' 'DESC', * FROM NEWSPAPER_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM NEWSPAPER_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			ORDER BY ORDER_NBR, LINE_NBR
			SELECT 'CMTS' 'DESC', * FROM NEWSPAPER_COMMENTS WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM NEWSPAPER_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
		END
		IF @order_type = 'MA' BEGIN 
			SELECT 'M-HEADER' 'DESC', *
			FROM MAGAZINE_HEADER A WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM MAGAZINE_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			SELECT 'DETAIL' 'DESC', * FROM MAGAZINE_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM MAGAZINE_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			ORDER BY ORDER_NBR, LINE_NBR
		END
		IF @order_type = 'IN' BEGIN
			SELECT 'I-HEADER' 'DESC', *	 
			  FROM INTERNET_HEADER A WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM INTERNET_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			SELECT 'DETAIL' 'DESC', * FROM INTERNET_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM INTERNET_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			ORDER BY ORDER_NBR, LINE_NBR
		END
		IF @order_type = 'OD' BEGIN 
			SELECT 'O-HEADER' 'DESC', *	 
			  FROM OUTDOOR_HEADER A WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM OUTDOOR_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			SELECT 'DETAIL' 'DESC', * FROM OUTDOOR_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM OUTDOOR_HEADER A JOIN @tmp_orders B ON A.LINK_ID = B.ACCT_ORD_NBR)
			ORDER BY ORDER_NBR, LINE_NBR
		END
		IF @order_type = 'TV' BEGIN 
			SELECT 'O-HEADER' 'DESC', *
			FROM TV_HDR WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM TV_HDR A JOIN @tmp_orders2 B ON A.LINK_ID = B.LINK_ID)
			SELECT 'DETAIL' 'DESC', * FROM TV_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM TV_HDR A JOIN @tmp_orders2 B ON A.LINK_ID = B.LINK_ID) OR ORDER_NBR = 699
			ORDER BY ORDER_NBR, LINE_NBR
			SELECT 'CMTS' 'DESC', * FROM TV_COMMENTS WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM TV_HDR A JOIN @tmp_orders2 B ON A.LINK_ID = B.LINK_ID) OR ORDER_NBR = 699
		END
		IF @order_type = 'RA' BEGIN 
			SELECT 'O-HEADER' 'DESC', *
			FROM RADIO_HDR A WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM RADIO_HDR A JOIN @tmp_orders2 B ON A.LINK_ID = B.LINK_ID)
			SELECT 'DETAIL' 'DESC', * FROM RADIO_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM RADIO_HDR A JOIN @tmp_orders2 B ON A.LINK_ID = B.LINK_ID)
			ORDER BY ORDER_NBR, LINE_NBR
			SELECT 'CMTS' 'DESC', * FROM RADIO_COMMENTS WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM RADIO_HDR A JOIN @tmp_orders2 B ON A.LINK_ID = B.LINK_ID)
		END
		SELECT POST_FLAG, * FROM @tmp_orders
		SELECT POST_FLAG, * FROM @tmp_orders2
		ROLLBACK TRAN TP1
	END
	ELSE
		COMMIT TRAN TP1

GOTO ENDIT
/*====================================================== END =============================================================*/

SET_DATES:

INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK1, DATEADD(d, 6, JAN_WK1) JAN_WK1_END , LEFT('JAN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK2, DATEADD(d, 6, JAN_WK2) JAN_WK2_END , LEFT('JAN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK3, DATEADD(d, 6, JAN_WK3) JAN_WK3_END , LEFT('JAN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK4, DATEADD(d, 6, JAN_WK4) JAN_WK4_END , LEFT('JAN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK5, DATEADD(d, 6, JAN_WK5) JAN_WK5_END , LEFT('JAN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK1, DATEADD(d, 6, FEB_WK1) FEB_WK1_END , LEFT('FEB_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK2, DATEADD(d, 6, FEB_WK2) FEB_WK2_END , LEFT('FEB_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK3, DATEADD(d, 6, FEB_WK3) FEB_WK3_END , LEFT('FEB_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK4, DATEADD(d, 6, FEB_WK4) FEB_WK4_END , LEFT('FEB_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK5, DATEADD(d, 6, FEB_WK5) FEB_WK5_END , LEFT('FEB_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK1, DATEADD(d, 6, MAR_WK1) MAR_WK1_END , LEFT('MAR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK2, DATEADD(d, 6, MAR_WK2) MAR_WK2_END , LEFT('MAR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK3, DATEADD(d, 6, MAR_WK3) MAR_WK3_END , LEFT('MAR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK4, DATEADD(d, 6, MAR_WK4) MAR_WK4_END , LEFT('MAR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK5, DATEADD(d, 6, MAR_WK5) MAR_WK5_END , LEFT('MAR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK1, DATEADD(d, 6, APR_WK1) APR_WK1_END , LEFT('APR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK2, DATEADD(d, 6, APR_WK2) APR_WK2_END , LEFT('APR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK3, DATEADD(d, 6, APR_WK3) APR_WK3_END , LEFT('APR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK4, DATEADD(d, 6, APR_WK4) APR_WK4_END , LEFT('APR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK5, DATEADD(d, 6, APR_WK5) APR_WK5_END , LEFT('APR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK1, DATEADD(d, 6, MAY_WK1) MAY_WK1_END , LEFT('MAY_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK2, DATEADD(d, 6, MAY_WK2) MAY_WK2_END , LEFT('MAY_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK3, DATEADD(d, 6, MAY_WK3) MAY_WK3_END , LEFT('MAY_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK4, DATEADD(d, 6, MAY_WK4) MAY_WK4_END , LEFT('MAY_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK5, DATEADD(d, 6, MAY_WK5) MAY_WK5_END , LEFT('MAY_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK1, DATEADD(d, 6, JUN_WK1) JUN_WK1_END , LEFT('JUN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK2, DATEADD(d, 6, JUN_WK2) JUN_WK2_END , LEFT('JUN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK3, DATEADD(d, 6, JUN_WK3) JUN_WK3_END , LEFT('JUN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK4, DATEADD(d, 6, JUN_WK4) JUN_WK4_END , LEFT('JUN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK5, DATEADD(d, 6, JUN_WK5) JUN_WK5_END , LEFT('JUN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK1, DATEADD(d, 6, JUL_WK1) JUL_WK1_END , LEFT('JUL_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK2, DATEADD(d, 6, JUL_WK2) JUL_WK2_END , LEFT('JUL_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK3, DATEADD(d, 6, JUL_WK3) JUL_WK3_END , LEFT('JUL_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK4, DATEADD(d, 6, JUL_WK4) JUL_WK4_END , LEFT('JUL_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK5, DATEADD(d, 6, JUL_WK5) JUL_WK5_END , LEFT('JUL_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK1, DATEADD(d, 6, AUG_WK1) AUG_WK1_END , LEFT('AUG_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK2, DATEADD(d, 6, AUG_WK2) AUG_WK2_END , LEFT('AUG_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK3, DATEADD(d, 6, AUG_WK3) AUG_WK3_END , LEFT('AUG_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK4, DATEADD(d, 6, AUG_WK4) AUG_WK4_END , LEFT('AUG_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK5, DATEADD(d, 6, AUG_WK5) AUG_WK5_END , LEFT('AUG_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK1, DATEADD(d, 6, SEP_WK1) SEP_WK1_END , LEFT('SEP_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK2, DATEADD(d, 6, SEP_WK2) SEP_WK2_END , LEFT('SEP_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK3, DATEADD(d, 6, SEP_WK3) SEP_WK3_END , LEFT('SEP_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK4, DATEADD(d, 6, SEP_WK4) SEP_WK4_END , LEFT('SEP_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK5, DATEADD(d, 6, SEP_WK5) SEP_WK5_END , LEFT('SEP_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK1, DATEADD(d, 6, OCT_WK1) OCT_WK1_END , LEFT('OCT_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK2, DATEADD(d, 6, OCT_WK2) OCT_WK2_END , LEFT('OCT_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK3, DATEADD(d, 6, OCT_WK3) OCT_WK3_END , LEFT('OCT_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK4, DATEADD(d, 6, OCT_WK4) OCT_WK4_END , LEFT('OCT_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK5, DATEADD(d, 6, OCT_WK5) OCT_WK5_END , LEFT('OCT_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK1, DATEADD(d, 6, NOV_WK1) NOV_WK1_END , LEFT('NOV_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK2, DATEADD(d, 6, NOV_WK2) NOV_WK2_END , LEFT('NOV_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK3, DATEADD(d, 6, NOV_WK3) NOV_WK3_END , LEFT('NOV_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK4, DATEADD(d, 6, NOV_WK4) NOV_WK4_END , LEFT('NOV_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK5, DATEADD(d, 6, NOV_WK5) NOV_WK5_END , LEFT('NOV_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK5 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK1, DATEADD(d, 6, DEC_WK1) DEC_WK1_END , LEFT('DEC_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK1 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK2, DATEADD(d, 6, DEC_WK2) DEC_WK2_END , LEFT('DEC_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK2 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK3, DATEADD(d, 6, DEC_WK3) DEC_WK3_END , LEFT('DEC_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK3 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK4, DATEADD(d, 6, DEC_WK4) DEC_WK4_END , LEFT('DEC_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK4 > @cutoff_dt
INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK5, DATEADD(d, 6, DEC_WK5) DEC_WK5_END , LEFT('DEC_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK5 > @cutoff_dt

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

--SELECT * FROM @brdcast_weeks2     /* DEBUG */

GOTO AFTER_SET_DATES

/**************************** END SET_DATES ************************************************************************/	
	
GOTO ENDIT		   
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			--ROLLBACK TRAN			
			--SELECT @error_msg_w as ErrorMessage;
			
			SELECT 'PROCESS ERROR CONTROL'  /* DEBUG */	
			
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		SELECT 'PROCESS ERROR ROLLBACK', @@TRANCOUNT '@@TRANCOUNT'  /* DEBUG */	
		ROLLBACK TRAN TP1
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */	
	
	/*PJH 03/06/19 - Updated CATCH error message */
	IF COALESCE(@ret_val, 0) = 0 BEGIN
		SET @ret_val = @ErState
		SET @ret_val_s = @ErMessage
	END	

END CATCH

RETURN

GO

GRANT EXECUTE ON [advsp_revise_order_process] TO PUBLIC AS dbo
GO