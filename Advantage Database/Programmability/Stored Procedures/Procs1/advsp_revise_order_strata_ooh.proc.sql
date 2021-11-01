CREATE PROCEDURE [dbo].[advsp_revise_order_strata_ooh] 
	@user_id varchar(100), @action varchar(10), @order_type varchar(2), 
	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS
/*
***********************************************************************************************************
PJH 02/19/17 - Ignore Xref LINK_DETID when revising - Link lines may move to different order detail lines on revision
PJH 02/19/17 - Remove rows marked for delete before processing
PJH 01/22/18 - New specs from Strata - only two cycles (4 wk periods) will be sent
                      If there is only one cyle then the cycle data will not be sent (use standard Net/Gross fields)
PJH 01/08/19 - Update code to handle bill-voided lines
PJH 03/22/19 - Added @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
***********************************************************************************************************
*/




--RETURN   /* Uncomment to leave converted rows in the staging table so you can test in Sql Mgt Studio */




--SET @action = 'DEBUG'

--all HEADER

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

	--all non-brdcast
	@headline varchar (60),

	--ma/np
	@size varchar (30),
	--@edition_issue varchar (30),
	--@material varchar (60),
	--@section varchar (30),

	--in/od
	@o_type varchar (6),		--internet_type / outdoor_type
	@url_location varchar (60),	--url / location
	@copy_area varchar (40),
	@rate_card varchar (10),
	@rate_type varchar(3),
	@rate_desc varchar (10),

	--in
	@proj_impressions int, 
	@guaranteed_impress int, 
	@act_impressions int,

	--in/od
	@target_audience varchar (60), 
	@creative_size varchar (60),
	@placement_1 varchar (160),
	@placement_2 varchar (160),	
	@ad_server_placement_id bigint,	--PJH 03/13/17 - added
	@ad_server_created_by varchar(100),
	@ad_server_created_datetime smalldatetime,
	@ad_server_last_modified_by varchar(100),
	@ad_server_last_modified_datetime smalldatetime,
	@ad_server_placement_manual bit,

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
	@rebate_amt_or decimal (14, 2)

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
	[AGENCY_NET_RATE] [decimal](6, 3) NULL,
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
	[MARKUP_PCT] [decimal](7, 3) NULL,
	[REBATE_PCT] [decimal](7, 3) NULL,
	[REBATE_AMT] [decimal](14, 2) NULL,
	[PLAN_IDS] [varchar](max) NULL,
	[COMM_PCT] [decimal](7, 3) NULL, 
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
	[LINE_CANCELLED] int,
	[CYCLE_1_GROSS_AMT] [decimal](14, 2) NULL,
	[CYCLE_1_NET_AMT] [decimal](14, 2) NULL,
	[CYCLE_2_GROSS_AMT] [decimal](14, 2) NULL,
	[CYCLE_2_NET_AMT] [decimal](14, 2) NULL
	)

DECLARE @print_xref TABLE (
	[RowID] [int] IDENTITY(1,1),
	[ORDER_NBR] [int] NULL,
	[LINE_NBR] [smallint] NULL,
	[LINK_ID] [int] NULL,
	[LINK_DETID] [smallint] NULL
	)

DECLARE @print_order TABLE (
	[RowID] [int] IDENTITY(1,1),
	[RECSEQ] [int] NOT NULL,
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
	[AGENCY_NET_RATE] [decimal](6, 3) NULL,
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
	[MARKUP_PCT] [decimal](7, 3) NULL,
	[REBATE_PCT] [decimal](7, 3) NULL,
	[REBATE_AMT] [decimal](14, 2) NULL,
	[PLAN_IDS] [varchar](max) NULL,
	[COMM_PCT] [decimal](7, 3) NULL,
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
	[USER_ID] [varchar](100) NULL,
	[BUYER_EMP_CODE] [varchar](6) NULL,
	[UNITS] [varchar](2) NULL,
	[LINE_CANCELLED] int,
	[CYCLE_1_GROSS_AMT] [decimal](14, 2) NULL,
	[CYCLE_1_NET_AMT] [decimal](14, 2) NULL,
	[CYCLE_2_GROSS_AMT] [decimal](14, 2) NULL,
	[CYCLE_2_NET_AMT] [decimal](14, 2) NULL,
	[CYCLE_NUMBER] int
	--[WEEKS] [int]
	)

DECLARE @orders TABLE (
	[RowID] [int] IDENTITY(1,1),
	[ORDER_NBR] [int] NULL
	)

DECLARE @order_lines TABLE (
	[RowID] [int] IDENTITY(1,1),
	[ORDER_NBR] [int] NULL,
	[LINE_NBR] [smallint] NULL,
	[ACTIVE_REV] [smallint] NULL,
	[AR_INV_NBR] [int] NULL
	)

DECLARE @sql varchar(500), @param_def varchar(500), @error_msg_w varchar(200)
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

--DECLARE @p1_52 varchar(254), @spots int
DECLARE @line_comment varchar(254)

DECLARE @delete_order int, @xref_exists bit, @insert_status varchar(1), @line_cancelled int

DECLARE @rowcount int--, @weeks int
DECLARE @recseq int, @lines int, @line_cnt int, @recseq_cnt int
DECLARE @insert_date_new smalldatetime, @end_date_new smalldatetime, @insert_date smalldatetime, @end_date_max smalldatetime

DECLARE @ad_server_id int, @cycle_number int

/* Unused Variables */
DECLARE
--tv/ra
@net_base_rate decimal (16, 4) = NULL,
@gross_base_rate decimal (16, 4) = NULL,
--ma
@bleed_pct decimal (14, 6) = NULL,
@bleed_amt decimal (14, 2) = NULL,
@position_pct decimal (14, 6) = NULL,
@position_amt decimal (14, 2) = NULL,
@premium_pct decimal (14, 6) = NULL,
@premium_amt decimal (14, 2) = NULL,

--ma/np
@flat_netcharge decimal (15, 2) = NULL,
@flat_addl_charge decimal (15, 2) = NULL,
@flat_discount_amt decimal (15, 2) = NULL,

--ma
@production_size varchar (30) = NULL,
@size_code varchar (6) = NULL,
@mg_circulation int = NULL,
--ma/np
--@size varchar (30) = NULL,
@edition_issue varchar (30) = NULL,
@material varchar (60) = NULL,
@section varchar (30) = NULL,
@rate_card_id int = NULL,
@rate_dtl_id smallint = NULL,
@contract_qty decimal (10, 2) = NULL,
@flat_net decimal (16, 4) = NULL,
@flat_gross decimal (16, 4) = NULL,
@prod_charge decimal (14, 3) = NULL,
@prod_desc varchar (30) = NULL,
@color_charge decimal (15, 4) = NULL,
@color_desc varchar (30) = NULL,
--np
@print_columns decimal (6, 2) = NULL,
@print_inches decimal (6, 2) = NULL,
@print_lines decimal (11, 2) = NULL,
@np_circulation int = NULL, 
@print_quantity decimal (14, 3) = NULL, 
@cost_type varchar (3) = NULL,
@cost_rate decimal (16, 4) = NULL,

@temp_cnt smallint, 
--@rec_id smallint, 
@temp_nc_amt decimal(14,2), 
@temp_ac_amt decimal(14,2), 
@temp_cc_amt decimal(14,2),

/** CALC_PRINT vars **/
@temp_net_gross varchar(2),
@d_temp decimal(14,2), @ext_net_amt_override decimal(14,2),@g_charge decimal(14,2), @n_charge decimal(14,2),
@state_rnd decimal(14,2), @county_rnd decimal(14,2), @city_rnd decimal(14,2), @ven_rnd decimal(14,2)	,	
@state_ac decimal(14,4), @county_ac decimal(14,4), @city_ac decimal(14,4),@ven_tax decimal(14,4), @addl_charge_taxes decimal(14,4),
@state_tax decimal(14,4), @county_tax decimal(14,4), @city_tax decimal(14,4),@resale_tax_amt decimal (14, 4), @sales_tax_amt decimal (14, 4),
@bill_amt decimal (14, 4),@billing_user varchar(254), @ar_inv_nbr int,@overage_pct decimal(14,4),
@column_line_qty decimal (14, 3), @cpm int,@override_non_resale_amt decimal (14, 2),@override_rates bit = 0

/* Used for date calculation */
DECLARE @cutoff_dt varchar(10), @skip int

SET @cutoff_dt = '12/31/2010'

DECLARE @ROW_COUNT int, @ROW_ID int, @DEBUG int
DECLARE @ROW_COUNT_XREF int, @ROW_ID_XREF int
DECLARE @RC int, @RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
			

BEGIN TRY

  /*************** D E B U G ************************************************ COMMENT FOR LIVE PROCESSING ******************************************* D E B U G ***************/

--SET @DEBUG = 1

  /*************** D E B U G ************************************************ COMMENT FOR LIVE PROCESSING ******************************************* D E B U G ***************/

IF @action = 'DEBUG'
	SET @DEBUG = 1
ELSE
	SET @DEBUG = 0

SELECT @date_time_w=GETDATE()

--SELECT @media_interface = 'AM'

IF @order_type NOT IN ('OD') BEGIN
	SELECT @order_type = 
		CASE @order_type
			WHEN 'O' THEN 'OD'
			ELSE @order_type
		END
END	

SELECT @media_type_in = 
	CASE @order_type
		WHEN 'OD' THEN 'O'
		ELSE @order_type
	END

SET NOCOUNT OFF

IF @order_type IN ('OD')
	--PJH 02/19/17 - Remove rows marked for delete before processing
	DELETE 	FROM PRINT_ORDER
	WHERE MEDIA_INTERFACE IN ('ST','SX') 
		AND MEDIA_TYPE = @media_type_in 
		AND MEDIA_TYPE = 'O' 
		AND POST_FLAG = 0   
		AND (DELETE_ORDER = 1)

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
		,0
		,[CYCLE_1_GROSS_AMT] 
		,[CYCLE_1_NET_AMT]
		,[CYCLE_2_GROSS_AMT]
		,[CYCLE_2_NET_AMT]
	FROM PRINT_ORDER
	WHERE MEDIA_INTERFACE IN ('ST', 'SX') 
		AND MEDIA_TYPE = @media_type_in 
		AND MEDIA_TYPE = 'O' 
		AND POST_FLAG = 0   
		AND (DELETE_ORDER IS NULL OR DELETE_ORDER = 0)
		--AND END_DATE IS NOT NULL   --<<<<<<<<<<< STRATA 4 Week Only
		AND UPPER([USER_ID]) = UPPER(@user_id)
	ORDER BY ACCT_ORD_NBR, ITEM_NBR, [REV_NBR], [RECSEQ]

SET @ROW_COUNT = @@ROWCOUNT

SET @ROW_ID = 1

SET @order_type_chg = 0

--IF @DEBUG = 1 BEGIN
--	IF @order_type = 'OD' BEGIN 
--		SELECT 'PRINT_IMPORT_XREF' 'DESC', * FROM PRINT_IMPORT_XREF WHERE IMPORT_ORDER_NBR IN (
--		SELECT ACCT_ORD_NBR FROM PRINT_ORDER WHERE MEDIA_INTERFACE IN ('ST', 'SX'))
		
--		SELECT '1-DETAIL' 'DESC', * FROM OUTDOOR_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM PRINT_IMPORT_XREF WHERE IMPORT_ORDER_NBR IN (
--		SELECT ACCT_ORD_NBR FROM PRINT_ORDER WHERE MEDIA_INTERFACE IN ('ST', 'SX')))
--		ORDER BY ORDER_NBR, LINE_NBR;
--	END
--END

/* Skip cancelled order/lines */
--UPDATE A
--SET A.LINE_CANCELLED = 1
--FROM @tmp_orders A
--	INNER JOIN PRINT_IMPORT_XREF B ON A.ACCT_ORD_NBR = B.IMPORT_ORDER_NBR AND CAST(A.ITEM_NBR AS int) = B.IMPORT_LINE_NBR
--    INNER JOIN OUTDOOR_DETAIL C ON B.ORDER_NBR = C.ORDER_NBR AND B.LINE_NBR = C.LINE_NBR AND C.LINE_CANCELLED = 1

SET NOCOUNT ON

BEGIN TRAN

IF @order_type NOT IN ('OD') BEGIN 
	SET @error_msg_w = 'Invalid Order Type - Valid type is ("O" Outdoor)'
	SET @ret_val_s = @error_msg_w
	SET @ret_val = 1
	GOTO ERROR_MSG	
END

/** Clear Posted rows from PRINT_ORDER table **/
IF @DEBUG = 1 BEGIN
	SELECT 'PRINT_ORDERS (Posted) to CLEAR' 'DESC', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM PRINT_ORDER
	WHERE (MEDIA_INTERFACE IN ('ST', 'SX') AND MEDIA_TYPE = @media_type_in AND MEDIA_TYPE = 'O' AND POST_FLAG = 1);
END
ELSE BEGIN
	DELETE FROM PRINT_ORDER
	WHERE (MEDIA_INTERFACE IN ('ST', 'SX') AND MEDIA_TYPE = @media_type_in AND MEDIA_TYPE = 'O' AND POST_FLAG = 1);
END

IF @DEBUG = 1
	SELECT * FROM @tmp_orders

IF @order_type IN ('OD') BEGIN

	WHILE @ROW_ID <= @ROW_COUNT
	BEGIN

		SET @order_nbr = 0

		SELECT
			@link_id		= [ACCT_ORD_NBR]	
			,@link_detid	= CAST([ITEM_NBR] AS INT)
			,@media_type	= [MEDIA_TYPE]
			,@media_interface_in = [MEDIA_INTERFACE]
			,@vn_code = [VENDOR_CODE]
			,@skip = [LINE_CANCELLED] /* Always 0 */
		FROM @tmp_orders
		WHERE RowID = @ROW_ID;

		--IF @skip = 1 
		--	GOTO SKIP

		IF @media_interface_in = 'ST' 
			SET @media_interface_in =  'SX'

		SELECT @order_nbr = COALESCE(A.ORDER_NBR, 0), @line_nbr = COALESCE(MIN(A.LINE_NBR), 0)
		FROM   PRINT_IMPORT_XREF A
		WHERE  A.IMPORT_ORDER_NBR = @link_id AND A.IMPORT_LINE_NBR = @link_detid AND A.IMPORTED_FROM = @media_interface_in AND A.MEDIA_TYPE = @media_type
		GROUP BY A.IMPORT_ORDER_NBR, A.IMPORT_LINE_NBR, A.ORDER_NBR

		IF @order_nbr > 0 BEGIN
			/* Get from exisiting  Header */
			SELECT @units = UNITS 
			FROM OUTDOOR_HEADER 
			WHERE ORDER_NBR = @order_nbr;
		END
		ELSE BEGIN
			/* Get default unit type from Vendor */
			SELECT @units=DEF_UNITS
			FROM dbo.VENDOR
			WHERE VN_CODE=@vn_code;	
		END

		IF @units = '4' BEGIN
	
			SELECT @order_nbr = ACCT_ORD_NBR, @line_nbr = ITEM_NBR, @insert_date = INSERT_DATE, @end_date_max = END_DATE
			FROM @tmp_orders 
			WHERE RowID = @ROW_ID AND MEDIA_INTERFACE IN ('ST', 'SX') AND MEDIA_TYPE = @media_type_in;
	
			SET @line_cnt = 1

			IF DATEADD(ww,4,@insert_date) - 1 < @end_date_max
				SET @lines = 2
			ELSE
				SET @lines = 1

			--IF @order_nbr_grp = @order_nbr AND @line_nbr_grp = @line_nbr
			IF COALESCE(@order_nbr, 0) > 0     --<<<<<<<<<<<<<<<<<<<<<<  DO WE WANT ALL ROWS or ONLY with default UNITS = 4 >>>>>>>>>>>>>>>
			BEGIN

				SET @recseq_cnt = 1

				WHILE @line_cnt <= @lines
				BEGIN
			
					IF @line_cnt = 1 BEGIN
						SET @end_date_new = DATEADD(ww,4,@insert_date) - 1

						IF @end_date_new > @end_date_max
							SET @end_date_new = @end_date_max

						SET @insert_date_new = @insert_date
					END
					ELSE BEGIN
						SET @end_date_new = DATEADD(ww,4,@insert_date_new) - 1

						IF @end_date_new > @end_date_max
							SET @end_date_new = @end_date_max
					END		
					
					SET @cycle_number = @line_cnt
																																																																																																																																																																																																					
					INSERT INTO @print_order
						([RECSEQ]
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
						,[LINE_CANCELLED]
				 		,[CYCLE_1_GROSS_AMT] 
						,[CYCLE_1_NET_AMT]
						,[CYCLE_2_GROSS_AMT]
						,[CYCLE_2_NET_AMT]
						,[CYCLE_NUMBER] ) 
						--,[WEEKS])
				SELECT [RECSEQ] --@recseq_cnt
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
					,@insert_date_new
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
					,@end_date_new
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
					,@units
					,[LINE_CANCELLED]
				 	,[CYCLE_1_GROSS_AMT] 
					,[CYCLE_1_NET_AMT]
					,[CYCLE_2_GROSS_AMT]
					,[CYCLE_2_NET_AMT]
					,@cycle_number 
				FROM @tmp_orders 
				WHERE RowID = @ROW_ID   --RECSEQ = @ROW_ID
				
					SET @line_cnt = @line_cnt + 1

					SET @recseq_cnt = @recseq_cnt + 1

					SET @insert_date_new = DATEADD(DD,1,@end_date_new)

				END		
			END
		END --@units

		SKIP:
	
		SET @ROW_ID = @ROW_ID + 1

	END

	/* Remove original rows so we can replace with the new (split) rows */
	--DELETE A FROM @tmp_orders A
	--INNER JOIN @print_order B  ON A.RECSEQ = B.RECSEQ

	SELECT @ROW_COUNT = COUNT(*) FROM @print_order

END

UPDATE @print_order
SET [RATE_PER] = CASE WHEN (AGENCY_NET_RATE < 1 AND [CYCLE_NUMBER] = 1 AND [CYCLE_1_GROSS_AMT] IS NOT NULL) THEN [CYCLE_1_GROSS_AMT]
									WHEN (AGENCY_NET_RATE < 1 AND [CYCLE_NUMBER] = 2 AND [CYCLE_2_GROSS_AMT] IS NOT NULL) THEN [CYCLE_2_GROSS_AMT]
									WHEN (AGENCY_NET_RATE = 1 AND [CYCLE_NUMBER] = 1 AND [CYCLE_1_NET_AMT] IS NOT NULL) THEN [CYCLE_1_NET_AMT]
									WHEN (AGENCY_NET_RATE = 1 AND [CYCLE_NUMBER] = 2 AND [CYCLE_2_NET_AMT] IS NOT NULL) THEN [CYCLE_2_NET_AMT]
									ELSE [RATE_PER]
							END


/************************************************/

--SELECT '@print_order' '-', * FROM @print_order

--ROLLBACK TRAN

--RETURN

/** Get the MAX REV & SEQ for a given ORDER/LINE **/
DECLARE @max_rev_nbr int, @max_seq_nbr int
DECLARE @offset_rev_nbr int, @offset_seq_nbr int
DECLARE @onset_rev_nbr int, @onset_seq_nbr int	

/************************************************/

DECLARE @link_id_prev	int,
			@link_detid_prev int,
			@order_nbr_prev	int,
			@line_nbr_prev int,
			@start_date_prev smalldatetime,
			@end_date_prev smalldatetime,
			@same_order_line bit,
			@max_rev_nbr_existing int,
			@process_this_line int

SET @link_id_prev = 0
SET @link_detid_prev = 0
SET @order_nbr_prev = 0
SET @line_nbr_prev = 0
SET @start_date_prev = '1/1/1900'
SET @end_date_prev = '1/1/1900'
SET @max_rev_nbr_existing = 0

SET @ROW_ID_XREF = 1

SET @ROW_ID = 1

WHILE @ROW_ID <= @ROW_COUNT BEGIN

	SET @order_nbr = 0
	SELECT
		@link_id		= [ACCT_ORD_NBR]	
		,@link_detid	= CAST([ITEM_NBR] AS INT)
		,@media_type	= [MEDIA_TYPE]
		,@media_interface_in = [MEDIA_INTERFACE]
		,@rev_nbr_import = [REV_NBR]
		--,@units = [UNITS]
		,@start_date = [INSERT_DATE]
		,@end_date = [END_DATE]
		,@vn_code = [VENDOR_CODE]
		,@insert_status = [INSERT_STATUS]
		,@skip = [LINE_CANCELLED]  /* Always 0 */
	FROM @print_order --@tmp_orders
	WHERE RowID = @ROW_ID

	IF @media_interface_in = 'ST'
		SET @media_interface_in =  'SX'

	SELECT @order_nbr = COALESCE(A.ORDER_NBR, 0), @line_nbr = COALESCE(MIN(A.LINE_NBR), 0)
	FROM   PRINT_IMPORT_XREF A --JOIN OUTDOOR_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
	WHERE  A.IMPORT_ORDER_NBR = @link_id AND A.IMPORT_LINE_NBR = @link_detid AND A.IMPORTED_FROM = @media_interface_in AND A.MEDIA_TYPE = @media_type
	GROUP BY A.IMPORT_ORDER_NBR, A.IMPORT_LINE_NBR, A.ORDER_NBR

	IF @order_nbr > 0 BEGIN
		/* Get from exisiting  Header */
		SELECT @units = UNITS 
		FROM OUTDOOR_HEADER 
		WHERE ORDER_NBR = @order_nbr;
	END
	ELSE BEGIN
		/* Get default unit type from Vendor */
		SELECT @units=DEF_UNITS
		FROM dbo.VENDOR
		WHERE VN_CODE=@vn_code;	
	END

	SET @process_this_line = 0

	IF @units = '4' AND @order_nbr > 0 BEGIN
		SELECT @process_this_line = 1 
		FROM OUTDOOR_DETAIL
		WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1 --AND LINE_CANCELLED IS NULL
	END

	/* Revise all matching Order/Lines */
	IF @units = '4' AND @order_nbr > 0 AND @process_this_line = 1 BEGIN 
		IF @link_id_prev <> @link_id OR @link_detid_prev <> @link_detid BEGIN

			/* PJH 01/08/19 - Update code to handle bill-voided lines */
			DELETE FROM @print_xref

			IF @link_id_prev <> @link_id OR @link_detid_prev <> @link_detid BEGIN
				INSERT INTO @print_xref
				SELECT COALESCE(A.ORDER_NBR, 0), COALESCE((A.LINE_NBR), 0), @link_id, @link_detid
				FROM   PRINT_IMPORT_XREF A --JOIN OUTDOOR_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
				WHERE  A.IMPORT_ORDER_NBR = @link_id AND A.IMPORT_LINE_NBR = @link_detid AND A.IMPORTED_FROM = @media_interface_in AND A.MEDIA_TYPE = @media_type
			END

			/* PJH 01/08/19 - Update code to handle bill-voided lines */
			SELECT @ROW_ID_XREF = COALESCE(MIN([RowID]), 1) FROM @print_xref
			SELECT @ROW_COUNT_XREF = COALESCE(MAX(RowID), 0) FROM @print_xref

			--SET @ROW_ID_XREF = 1

			WHILE @ROW_ID_XREF <= @ROW_COUNT_XREF BEGIN

				SELECT @order_nbr = ORDER_NBR, @line_nbr = LINE_NBR FROM @print_xref WHERE RowID = @ROW_ID_XREF

				--SELECT @order_nbr '@order_nbr', @line_nbr '@line_nbr', @ROW_ID_XREF '@ROW_ID_XREF'

				--SELECT '@print_xref2' '@DESC', * FROM @print_xref WHERE RowID = @ROW_ID_XREF

				IF @order_nbr_prev <> @order_nbr OR @line_nbr_prev <> @line_nbr BEGIN
					/*** Get the MAX REV & SEQ for a given ORDER/LINE ***/	
					SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
									@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
					FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)

					--IF @insert_status = 'C' 
					--	SET @line_cancelled = 1
					--ELSE
					--	SET @line_cancelled = NULL

					/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
--					UPDATE [dbo].[OUTDOOR_DETAIL] SET ACTIVE_REV = NULL--, LINE_CANCELLED = NULL --CASE WHEN @line_cancelled IS NULL THEN NULL ELSE 1 END
--					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND LINE_CANCELLED IS NULL AND ACTIVE_REV = 1
					--AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr;
					/* OFFSET */

					--/* Clear any cancelled rows matching this line. We will reset cancelled lines after we process the changes. */
					--UPDATE [dbo].[OUTDOOR_DETAIL] SET LINE_CANCELLED = NULL, BILL_CANCELLED = NULL
					--WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr

					/* Hold the order for cancel logic later. */
					INSERT INTO @orders SELECT @order_nbr WHERE NOT EXISTS (SELECT ORDER_NBR FROM @orders WHERE ORDER_NBR = @order_nbr)

					INSERT INTO [dbo].[OUTDOOR_DETAIL]
						([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV]
						,[LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						,[LOCATION], [COPY_AREA]
						,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
						,[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
						,[ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL] ,[LINE_CANCELLED]
						,[DATE_TO_BILL]
						--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
						--,[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
						--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
						,[NON_BILL_FLAG]
						,[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG]
						,[COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
						,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
						,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
						--,[RECONCILE_FLAG], [GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
						,[BILLING_AMT] , [BILL_CANCELLED]
						,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [IMPRESSIONS], [ACTUAL_IMPRESSIONS])
					SELECT
						@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, CASE WHEN @line_cancelled IS NULL THEN NULL ELSE 1 END --[ACTIVE_REV]
						,[LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						,[LOCATION], [COPY_AREA]
						,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						,[QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1
						,[DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NCDESC]
						,[ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [LINE_TOTAL] * -1 , @line_cancelled
						,[DATE_TO_BILL]
						--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
						--,[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
						--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
						,[NON_BILL_FLAG]
						,[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG]
						,[COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
						,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
						,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
						--,[RECONCILE_FLAG], [GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
						,[BILLING_AMT] * -1 , CASE WHEN ([AR_INV_NBR] IS NULL OR @line_cancelled IS NULL) THEN NULL ELSE 1 END /** Set on billed only */--, [BILL_CANCELLED]
						,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [IMPRESSIONS], [ACTUAL_IMPRESSIONS]
					FROM  [dbo].[OUTDOOR_DETAIL] A 
					WHERE A.[ORDER_NBR] =  @order_nbr AND A.[LINE_NBR] = @line_nbr AND A.[REV_NBR] = @max_rev_nbr AND A.[SEQ_NBR] =  @max_seq_nbr	
								AND ACTIVE_REV = 1 AND (LINE_CANCELLED IS NULL) /* Do not offset rows that are cancelled and billed */

					--SELECT '*****' '-------',
					--	@order_nbr '@order_nbr', @line_nbr '@line_nbr', @offset_rev_nbr '@offset_rev_nbr', @offset_seq_nbr '@offset_seq_nbr', CASE WHEN @line_cancelled IS NULL THEN NULL ELSE 1 END '[ACTIVE_REV]'

					/* Clear any cancelled rows matching this line. We will reset cancelled lines after we process the changes. */
					UPDATE [dbo].[OUTDOOR_DETAIL] SET LINE_CANCELLED = NULL, BILL_CANCELLED = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr

					UPDATE [dbo].[OUTDOOR_DETAIL] SET ACTIVE_REV = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr
				END

				SET @ROW_ID_XREF = @ROW_ID_XREF + 1

				SET @order_nbr_prev = @order_nbr
				SET @line_nbr_prev = @line_nbr

				SET @link_id_prev = @link_id
				SET @link_detid_prev = @link_detid

			END --XREF While
		END
	END --Revise all matching Order/Lines

	SET @ROW_ID = @ROW_ID + 1

END

IF @DEBUG = 1 BEGIN
	IF @order_type = 'OD' BEGIN 
		SELECT '2-DETAIL' 'DESC', * FROM OUTDOOR_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM PRINT_IMPORT_XREF WHERE IMPORT_ORDER_NBR IN (
		SELECT ACCT_ORD_NBR FROM PRINT_ORDER WHERE MEDIA_INTERFACE IN ('ST', 'SX')))
		ORDER BY ORDER_NBR, LINE_NBR;
	END
END

/**** FINISHED REVERSAL ROWS ****/

SET @order_nbr = 0
SET @line_nbr = 0

SET @order_nbr_prev = 0
SET @line_nbr_prev = 0

SET @link_id_prev = 0
SET @link_detid_prev = 0

SET @ROW_ID = 1

DELETE @print_xref

--SELECT '@print_order' '-x-', * FROM @print_order

/*********** [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[ - After reversals - HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE ]]]]]]]]]]]]]]]]]]]]]]]]]]]]]] ***********/

WHILE @ROW_ID <= @ROW_COUNT BEGIN

	--uf_generic_dtl - Field Mapping
	IF @order_type IN ('OD')
		SELECT
			@link_id		= [ACCT_ORD_NBR]	
			,@link_detid	= CAST([ITEM_NBR] AS INT)
			,@media_type	= [MEDIA_TYPE]
			,@media_interface_in = [MEDIA_INTERFACE]
			,@rev_nbr_import = [REV_NBR]
			--,@units = [UNITS]
			,@start_date = [INSERT_DATE]
			,@end_date = [END_DATE]
			,@insert_status = [INSERT_STATUS]
			--,@skip = [LINE_CANCELLED]
		FROM @print_order --@tmp_orders
		WHERE RowID = @ROW_ID

	SET @hdr_exists = 0
	SET @dtl_exists = 0
	SET @dtl_cmnt_exists = 0
	--SET @order_nbr = 0
	--SET @line_nbr = 0

	--IF @insert_status = 'C' OR @skip = 1  /* Cancel - So skip new insert */
	--	GOTO NEXT_ROW

	IF @media_interface_in = 'ST'
		SET @media_interface_in =  'SX'

	--PJH 02/19/17 - Ignore Xref LINK_DETID when revising - Link lines may move to different order detail lines on revision
	IF @order_type IN ('OD') BEGIN
		--SELECT @order_nbr = COALESCE(A.ORDER_NBR, 0), @line_nbr = COALESCE(MIN(A.LINE_NBR), 0)
		--FROM   PRINT_IMPORT_XREF A --JOIN OUTDOOR_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
		--WHERE  A.IMPORT_ORDER_NBR = @link_id AND A.IMPORT_LINE_NBR = @link_detid AND A.IMPORTED_FROM = @media_interface_in AND A.MEDIA_TYPE = @media_type
		--GROUP BY A.IMPORT_ORDER_NBR, A.IMPORT_LINE_NBR, A.ORDER_NBR

		--IF @@ROWCOUNT = 0 BEGIN
			SELECT @order_nbr = COALESCE(ORDER_NBR, 0)
			FROM   PRINT_IMPORT_XREF
			WHERE  IMPORT_ORDER_NBR = @link_id AND (IMPORTED_FROM = @media_interface_in) AND (MEDIA_TYPE = @media_type) AND (MEDIA_TYPE = 'O')

			IF @@ROWCOUNT = 0 BEGIN
				SET @order_nbr = 0
				SET @line_nbr = 0
			END
		--END
	END	

	/* If it does not find a match IE link id 2 bit link id is good, then keep line nbr else clear */
	--IF @order_nbr_prev <> @order_nbr OR @line_nbr_prev <> @line_nbr BEGIN
	--	IF @line_nbr > 0 BEGIN --AND @same_order_line = 0
	--		SET @dtl_exists = 1
	--		SET @hdr_exists = 1
	--	END
	--	ELSE BEGIN

	--		IF @order_nbr > 0 BEGIN
	--			SET @hdr_exists = 1
	--		END
	--		ELSE BEGIN
	--			SET @hdr_exists = 0
	--			SET @line_nbr = 0
	--			SET @dtl_exists = 0
	--			SET @rev_nbr = 0
	--			SET @seq_nbr = 0
	--		END
	--		--SET @same_order_line = 0
	--	END
	--END
	--ELSE	
	IF @order_nbr > 0 BEGIN
		SET @hdr_exists = 1
	END
	ELSE BEGIN
		SET @hdr_exists = 0
		SET @line_nbr = 0
		SET @dtl_exists = 0
		SET @rev_nbr = 0
		SET @seq_nbr = 0
	END

	IF @hdr_exists = 1 BEGIN
		/* Get from exisiting  Header */
		SELECT @units = UNITS 
		FROM OUTDOOR_HEADER 
		WHERE ORDER_NBR = @order_nbr;
	END
	ELSE BEGIN
		/* Get default unit type from Vendor */
		SELECT @units=DEF_UNITS
		FROM dbo.VENDOR
		WHERE VN_CODE=@vn_code;	
	END

	IF @hdr_exists = 1 BEGIN

		IF @link_id_prev = 0 AND @link_id > 0 OR @link_id_prev = @link_id BEGIN
			/* Keep Order Nbr */
			SET @line_nbr = @line_nbr + 1
			SET @same_order_line = 1
		END
		ELSE BEGIN
			SET @line_nbr = 1
		END

	END
	ELSE BEGIN
		SET @order_nbr = 0
		SET @line_nbr = 0
		SET @same_order_line = 0
	END

	SET @imported_from = 
		CASE @media_interface_in 
			WHEN 'ST' THEN 'STRATA'
			WHEN 'SX' THEN 'STRATA'
			ELSE 'N/A'
		END

	--SELECT @hdr_exists '@hdr_exists', @dtl_exists '@dtl_exists', @media_interface '@media_interface', @media_type '@media_type', @link_id '@link_id', @link_detid '@link_detid' /** DEBUG **/

	SET @action = 'NEW'

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
		--@units = NULL,
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
		--@rev_nbr = NULL,
		--@seq_nbr = NULL,
		--@active_rev = NULL,
		--@link_detid = NULL,
		@start_date_d = NULL,
		@end_date_d = NULL,
		@close_date = NULL,
		@matl_close_date = NULL,
		@ext_close_date = NULL,
		@ext_matl_date = NULL,

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

		--all non-brdcast
		@headline = NULL,

		--ma/np
		@size = NULL,

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
		@delete_order = NULL,
		@media_interface = NULL,
		@line_comment = NULL,
		@existing_vn_code = NULL,
		@sales_class_code = NULL,
		@ad_server_id = NULL
				
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

		BEGIN  /* Set defaults to 0 if new line */
			--SELECT @color_charge = 0, @flat_netcharge = 0, @netcharge = 0, @flat_addl_charge = 0, @addl_charge = 0
			SELECT @netcharge = 0, @addl_charge = 0
		END

		/*
		,[CYCLE_1_GROSS_AMT] 
		,[CYCLE_1_NET_AMT]
		,[CYCLE_2_GROSS_AMT]
		,[CYCLE_2_NET_AMT] 
		*/

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
			,@order_date   = @date_time_w
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
			--,@material = COALESCE([MATERIAL], @material)
			--,@edition_issue = COALESCE([SECTION_ISSUE], @edition_issue) --[ZONE] --
			--,@section = COALESCE([SECTION_ISSUE], @section)
			,@url_location = COALESCE(CASE [LOCATION] WHEN '' THEN NULL ELSE [LOCATION] END, @url_location) --CASE [URL] WHEN '' THEN NULL ELSE [URL] END
			--,@size_code = COALESCE([SIZE_CODE], @size_code)
			--,@production_size = COALESCE([PRODUCTION_SIZE], @production_size)
			/**************/
			,@job_number = COALESCE([JOB_NUMBER], @job_number), @job_component_nbr = COALESCE([JOB_COMPONENT_NBR], @job_component_nbr)
			,@creative_size = COALESCE(CASE [CREATIVE_SIZE] WHEN '' THEN NULL ELSE [CREATIVE_SIZE] END, @creative_size)
			,@o_type =  COALESCE(CASE [OUTDOOR_TYPE] WHEN '' THEN NULL ELSE [OUTDOOR_TYPE] END, @o_type)
			/* @copy_area - Not mapped from planning */
			,@copy_area = [AD_SIZE]
			,@placement_1 = NULL, @placement_2 = NULL  --CASE [LOCATION] WHEN '' THEN NULL ELSE [LOCATION] END
			/**************/
			--,@color_charge = COALESCE([PREMIUM_CHGS],0), @color_desc = 'Color Charge' --
			,@rate = [RATE_PER]
			,@net_rate = [RATE_PER], @gross_rate = [RATE_PER] 
			--@flat_net = [RATE_PER], @flat_gross = [RATE_PER]
			--,@flat_netcharge = COALESCE([FLAT_NETCHARGE],@flat_netcharge) --
			,@netcharge = COALESCE([FLAT_NETCHARGE],@netcharge), @ncdesc = 'Net Charge' --
			--,@flat_addl_charge  = COALESCE([FLAT_ADDL_CHARGE], @flat_addl_charge) --
			,@addl_charge = COALESCE([FLAT_ADDL_CHARGE], @addl_charge), @addl_charge_desc =	'Additional Charge' 
			--,@print_columns = [PRINT_COLUMNS] , @print_inches = [PRINT_INCHES], @print_lines = [PRINT_LINES]
			--,@cost_type = COALESCE([COST_TYPE], @cost_type)
			--,@cost_rate = COALESCE([COST_RATE], @cost_rate)
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
		FROM @print_order --@tmp_orders
		WHERE RowID = @ROW_ID

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
		--SET @color_desc = CASE WHEN (@color_charge IS NULL OR @color_charge = 0) THEN NULL ELSE 'Color Charge' END 
		
		SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End OOH */
	ELSE
		GOTO NEXT_ROW

	IF @hdr_exists = 1 BEGIN
		IF @media_type_in = 'O' BEGIN
			SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE, @vn_code = VN_CODE, @ord_process_contrl = ORD_PROCESS_CONTRL
			FROM OUTDOOR_HEADER
			WHERE ORDER_NBR = @order_nbr
		END
	END
	ELSE BEGIN /* NEW ORDER - GET ADDL INFO */
		SELECT @pub_station = 1,
					@ord_process_contrl = 1
		SELECT @cmp_identifier  = CMP_IDENTIFIER FROM CAMPAIGN WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE= @prd_code AND CMP_CODE = @cmp_code
	END

	SET @action = 'NEW'

	--IF @dtl_exists = 1 BEGIN
	--	SET @action = 'REVISE'
	--END 
	--ELSE BEGIN
	--	SET @action = 'NEW'
	--END

	--IF @dtl_exists = 0 BEGIN
		SELECT /* GET PRODUCT DEFAULTS */
				@discount_pct = [PRD_VEN_DISC],  --<<<<<<<<<<<< PRODUCT DISCOUNT
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

		SELECT /* GET TAX INFO & VENDOR & PRODUCT */
					@tax_city_pct=TAX_CITY_PCT, @tax_county_pct=TAX_COUNTY_PCT, @tax_state_pct=TAX_STATE_PCT, @tax_resale=TAX_RESALE,
					@taxapplyc=TAXAPPLYC, @taxapplyln=TAXAPPLYLN, @taxapplynd=TAXAPPLYND, @taxapplync=TAXAPPLYNC, @taxapplyr=TAXAPPLYR, @taxapplyai=TAXAPPLYAI,
					@tax_code=TAX_CODE,  
					@comm_pct=COMM_PCT,  --<<<<<<<<<<<< VENDOR COMMISSION
					@markup_pct=MARKUP_PCT,  --<<<<<<<<<<<< PRODUCT MARKUP
					@rebate_pct=COALESCE(REBATE_PCT, @rebate_pct) --<<<<<<<<<<<< PRODUCT REBATE
		FROM advtf_med_get_tax_info(@order_type, @vn_code, @net_gross, @cl_code, @div_code, @prd_code, @bill_type_flag, @start_date, @action)	

		SELECT /* GET SC DEFAULTS */
				@markup_pct = COALESCE([SC_MARKUP], @markup_pct),  --<<<<<<<<<<<< MARKUP
				@rebate_pct = COALESCE([SC_REBATE], @rebate_pct)  --<<<<<<<<<<<< REBATE
		FROM [dbo].[advtf_med_get_sc_defaults] (
				@cl_code	,
				@div_code	,
				@prd_code	 ,
				@order_type ,
				@sales_class_code ) --@media_type , /* SC_CODE */	

		SELECT /* GET VN DEFAULTS */
				@markup_pct = COALESCE([VN_MARKUP], @markup_pct)  --<<<<<<<<<<<< MARKUP
		FROM [dbo].[VENDOR]
		WHERE VN_CODE = @vn_code;	

	--BILL_TYPE_FLAG = 1 = Comm Only, 2 = Net, 3 = Gross

	/* uf_calc_comm_mu - Get reciprocal PCT */
	IF @net_gross = 1  BEGIN
		SELECT @markup_pct=MARKUP_PCT FROM advtf_med_calc_comm_mu( @net_gross, @comm_pct) --GROSS
	END
	ELSE BEGIN
		SELECT @comm_pct=COMM_PCT FROM advtf_med_calc_comm_mu( @net_gross, @markup_pct) --NET		
	END

	--PJH 02/04/16 - Chk for existing
	IF @hdr_exists = 0 BEGIN
		IF @media_type_in =  'O'
			SELECT @table_prefix = 'OUTDOOR'
	END

	IF @units IS NULL BEGIN
		IF @media_type_in =  'O'
			SELECT @units = 'M'
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
	END ELSE
		SET @rebate_pct = 0
		SET @rebate_amt = 0

	IF @comm_pct_or IS NOT NULL BEGIN
		SET @comm_pct = @comm_pct_or
		SET @comm_pct_override = 1
	END	
	
	SET @printed = NULL /** CLEAR PRINTED FLAG **/	
	
	SET @modified_by = @user_id /* Passed from calling Procedure */

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

		--SET ON NEW
		IF @house_comment IS NULL
			SELECT @house_comment = CAST(@link_id AS VARCHAR(20)) + ' imported from ' + @imported_from

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
			--SELECT 'HEADER INFO FOR xORDER: ' + CAST(@order_nbr AS VARCHAR(20)) + ' LINE: ' + CAST(@line_nbr AS VARCHAR(20))
			SET @error_msg_w = 'Invalid Order Number - Error updating Order Header values! ' + @ret_val_s
			GOTO ERROR_MSG
		END	

		IF @link_id_prev <> @link_id BEGIN
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
	END

	/* Hold the order for cancel logic later. */
	INSERT INTO @orders SELECT @order_nbr WHERE NOT EXISTS (SELECT ORDER_NBR FROM @orders WHERE ORDER_NBR = @order_nbr)
	
	/* Always NEW detail - Revise all to nothing then re-add */

	SET @action = 'NEW'

	IF @dtl_exists = 0 BEGIN /* This line does not exist */
		IF  @same_order_line <> 1 BEGIN
			SET @line_nbr = 1
			SET @rev_nbr = 0
			SET @seq_nbr = 0
		END
		SET @active_rev = 1		
	END	

	--IF @DEBUG = 1
	--	SELECT 'DETAIL INFO PASSED ' 'DESC', @order_nbr ORDER_NBR, @line_nbr LINE_NBR, @link_id LINK_ID, @link_detid LINKE_DETID, @rev_nbr_import REV_NBR, @vn_code 'VN_CODE', @remarks '@remarks'  /** DEBUG **/
	
	IF @action IN ('NEW') BEGIN

		/*** Get the MAX REV & SEQ for a given ORDER/LINE ***/	
		--SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
		--				@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
		--FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)

		SET @max_rev_nbr = NULL

		SELECT @max_rev_nbr = REV_NBR FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr

		IF @max_rev_nbr IS NULL 
			SET @max_rev_nbr = 0

		SET @max_seq_nbr = NULL

		SELECT @max_seq_nbr = SEQ_NBR FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND REV_NBR = @max_rev_nbr

		SET @max_seq_nbr = COALESCE(@max_seq_nbr, 0)

		/* Already offset so use next revision nbr */
		IF @max_seq_nbr > 0 BEGIN  /* PJH 01/08/19 - Changed from = 1 */
			SET @max_rev_nbr = @max_rev_nbr + 1
			SET @max_seq_nbr = 0
		END
		ELSE
			SET @max_seq_nbr = @max_seq_nbr + 1

		SET @active_rev = 1			

		--GOTO AAA

		EXECUTE @RC = [dbo].[advsp_revise_order_detail] 
			@user_id  ,'NEW4'  ,@order_type  ,@order_type_chg   
			,@rebate_amt_override, @rebate_pct_override, @markup_pct_override, @comm_pct_override
			,@ret_val OUTPUT,@ret_val_s OUTPUT
			,@order_nbr  ,@line_nbr  ,@max_rev_nbr  ,@max_seq_nbr  ,@active_rev  ,@link_detid  
			,@start_date  ,@end_date  ,@close_date  ,@matl_close_date  ,@ext_close_date  ,@ext_matl_date
			--,@buy_type  ,@month_nbr  ,@year_nbr
			--,@date1  ,@date2  ,@date3  ,@date4  ,@date5  ,@date6  ,@date7
			--,@monday  ,@tuesday  ,@wednesday  ,@thursday  ,@friday  ,@saturday  ,@sunday
			--,@spots1  ,@spots2  ,@spots3  ,@spots4  ,@spots5  ,@spots6  ,@spots7  ,@total_spots
			,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL

			,@job_number  ,@job_component_nbr  ,@quantity  ,@rate  ,@net_rate  ,@gross_rate
			,@ext_net_amt  ,@ext_gross_amt  ,@comm_amt  ,@rebate_amt  ,@discount_amt  ,@discount_desc
			,@state_amt  ,@county_amt  ,@city_amt  ,@non_resale_amt  ,@netcharge  ,@ncdesc  ,@addl_charge  ,@addl_charge_desc
			,@line_total  ,@date_to_bill  ,@non_bill_flag  ,@modified_by  ,@modified_date  ,@modified_comments
			,@bill_type_flag  ,@comm_pct  ,@markup_pct  ,@rebate_pct  ,@discount_pct
			,@tax_code  ,@tax_city_pct  ,@tax_county_pct  ,@tax_state_pct  ,@tax_resale
			,@taxapplyc  ,@taxapplyln  ,@taxapplynd  ,@taxapplync  ,@taxapplyr  ,@taxapplyai
			,@reconcile_flag  ,@billing_amt  ,@est_nbr  ,@est_line_nbr  ,@est_rev_nbr
			,@ad_number  ,@mat_comp  ,@units  ,
			--@cost_type  ,@cost_rate  ,@net_base_rate  ,@gross_base_rate
			--,@programming  ,@start_time  ,@end_time  ,@length  ,@remarks  ,@tag  ,@network_id
			--,@headline  ,@size  ,@edition_issue  ,@material  ,@section  ,@rate_card_id  ,@rate_dtl_id
			--,@contract_qty  ,@flat_net  ,@flat_gross  ,@prod_charge  ,@prod_desc  ,@color_charge  ,@color_desc
			--,@print_columns  ,@print_inches  ,@print_lines  ,@np_circulation  ,@print_quantity
			--,@bleed_pct  ,@bleed_amt  ,@position_pct  ,@position_amt  ,@premium_pct  ,@premium_amt
			--,@flat_netcharge  ,@flat_addl_charge  ,@flat_discount_amt  ,@production_size  ,@size_code
			--,@mg_circulation  ,
			NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,@headline  ,@size  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,NULL  ,NULL  ,NULL  ,NULL
			,NULL  ,
			@o_type  ,@url_location  ,@copy_area  ,@rate_card  ,@rate_type  ,@rate_desc
			,@proj_impressions  ,@guaranteed_impress ,@act_impressions ,@target_audience  ,@creative_size
			,@placement_1  ,@placement_2, @prc_status
			,@ad_server_placement_id  
			,@ad_server_created_by  
			,@ad_server_created_datetime  
			,@ad_server_last_modified_by  
			,@ad_server_last_modified_datetime  
			,@ad_server_placement_manual
			--PJH 08/18/17 - Added
			--,@cable_network_station_code 
			--,@daypart_id 
			--,@added_value 
			--,@bookend 
			--,@link_line_number
			,NULL 
			,NULL 
			,NULL 
			,NULL 
			,NULL

		IF @ret_val <> 0 BEGIN
			SET @error_msg_w = 'Error updating Order Detail values! ' + @ret_val_s
			GOTO ERROR_MSG
		END

		SET @order_nbr_prev = @order_nbr
		SET @line_nbr_prev = @line_nbr

		GOTO AAA
		AAA: 

	END --END REVISE

	--SELECT @air_date '@air_date', @instructions '@instructions', @order_copy '@order_copy', @matl_notes '@matl_notes', @position_info '@position_info',
	--@close_info '@close_info', @rate_info '@rate_info', @misc_info '@misc_info', @media_type_in '@media_type_in', @dtl_cmnt_exists '@dtl_cmnt_exists'        /* DEBUG */
	
	IF @media_type_in =  'O' BEGIN
		SELECT @dtl_cmnt_exists = 1 FROM [dbo].[OUTDOOR_COMMENTS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
		IF @dtl_cmnt_exists = 0 BEGIN
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

	NEXT_ROW:

	/** Set Temp flag here **/
	UPDATE @print_order SET POST_FLAG = 1
	WHERE RowID = @ROW_ID 	

	SET @xref_exists = 0
	SELECT @xref_exists = 1 FROM PRINT_IMPORT_XREF
	WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND IMPORT_ORDER_NBR = @link_id --AND IMPORT_LINE_NBR = @link_detid

	IF @order_type IN ('OD') BEGIN
		If @xref_exists = 0 BEGIN
		--IF 1 = 1 BEGIN
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

				--INSERT INTO @print_xref
				--SELECT @order_nbr, @line_nbr, @link_id, @link_detid
		END
		ELSE BEGIN
			UPDATE dbo.PRINT_IMPORT_XREF
				SET LAST_DATE_REVISED = @modified_date,
					LAST_USERID = @user_id,
					IMPORT_LINE_NBR = @link_detid
				WHERE ORDER_NBR = @order_nbr 
						AND LINE_NBR = @line_nbr
						AND IMPORT_ORDER_NBR = @link_id 
						--AND IMPORT_LINE_NBR = @link_detid 
		END
	END
	
	SET @ROW_ID = @ROW_ID + 1

	SET @link_id_prev = @link_id
	SET @link_detid_prev = @link_detid
	SET @start_date_prev = @start_date
	SET @end_date_prev = @end_date

END /* While */

/* Set cancelled line flags here if needed. */
BEGIN

	IF @DEBUG = 1
		SELECT '@orders' '@orders', * FROM @orders

	SELECT @ROW_COUNT = COUNT(*) FROM @orders
	SELECT @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN
		SELECT @order_nbr = ORDER_NBR FROM @orders WHERE RowID = @ROW_ID

		INSERT INTO @order_lines SELECT ORDER_NBR, LINE_NBR, MAX(COALESCE(ACTIVE_REV, 0)), MAX(COALESCE(AR_INV_NBR, 0)) FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr GROUP BY ORDER_NBR, LINE_NBR

		SET @ROW_ID = @ROW_ID + 1
	END

	IF @DEBUG = 1
		SELECT '@order_lines' '@order_lines', * FROM @order_lines

	SELECT @ROW_COUNT = COUNT(*) FROM @order_lines
	SELECT @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN		
		SELECT @order_nbr = 0, @line_nbr = 0, @ar_inv_nbr = 0

		SELECT @order_nbr = ORDER_NBR, @line_nbr = LINE_NBR, @ar_inv_nbr = AR_INV_NBR FROM @order_lines WHERE RowID = @ROW_ID AND ACTIVE_REV = 0

		IF COALESCE(@order_nbr, 0) > 0 BEGIN

			/*** Get the MAX REV & SEQ for a given ORDER/LINE ***/	
			SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR
			FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)

			UPDATE [dbo].[OUTDOOR_DETAIL] SET ACTIVE_REV = 1
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND REV_NBR = @max_rev_nbr AND SEQ_NBR = @max_seq_nbr	

			UPDATE [dbo].[OUTDOOR_DETAIL] SET LINE_CANCELLED = 1
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
			
			IF COALESCE(@ar_inv_nbr, 0) > 0 BEGIN
				UPDATE [dbo].[OUTDOOR_DETAIL] SET BILL_CANCELLED = 1
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND AR_INV_NBR IS NULL		
			END
		END

		SET @ROW_ID = @ROW_ID + 1
	END
END

/* Update as posted */
UPDATE A
SET A.POST_FLAG = B.POST_FLAG, A.UNITS = B.UNITS
FROM PRINT_ORDER A
    INNER JOIN @print_order B ON
        A.ACCT_ORD_NBR = B.ACCT_ORD_NBR	AND 
		A.ITEM_NBR = B.ITEM_NBR;

/* Update as posted order/lines that are cancelled and processed */
UPDATE A
SET A.POST_FLAG = 1
FROM PRINT_ORDER A 
     INNER JOIN @tmp_orders B ON
        A.ACCT_ORD_NBR = B.ACCT_ORD_NBR	AND 
		A.ITEM_NBR = B.ITEM_NBR AND
		B.LINE_CANCELLED = 1;

--SELECT '**' '--', LINE_CANCELLED, * FROM @tmp_orders

SELECT 'BEFORE COMMIT' '-', @DEBUG '@DEBUG'

IF @@TRANCOUNT > 0
	IF @DEBUG = 1 BEGIN
		SELECT 'ROLLBACK' 'DEBUG', @order_type '@order_type'

		IF @order_type = 'OD' BEGIN 
			SELECT 'O-HEADER' 'DESC', *	 
			  FROM OUTDOOR_HEADER A WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM PRINT_IMPORT_XREF WHERE IMPORT_ORDER_NBR IN (
									SELECT ACCT_ORD_NBR FROM @print_order WHERE MEDIA_INTERFACE IN ('ST', 'SX')))

			SELECT '1-DETAIL' 'DESC', * FROM OUTDOOR_DETAIL WHERE ORDER_NBR IN (SELECT ORDER_NBR FROM PRINT_IMPORT_XREF WHERE IMPORT_ORDER_NBR IN (
									SELECT ACCT_ORD_NBR FROM @print_order WHERE MEDIA_INTERFACE IN ('ST', 'SX')))
			ORDER BY ORDER_NBR, LINE_NBR;

		END

		SELECT POST_FLAG, * FROM PRINT_ORDER --@tmp_orders

		SELECT 'PRINT_IMPORT_XREF' 'DESC', * FROM PRINT_IMPORT_XREF WHERE IMPORT_ORDER_NBR IN (
		SELECT ACCT_ORD_NBR FROM @print_order WHERE MEDIA_INTERFACE IN ('ST', 'SX'))

		ROLLBACK TRAN
	END
	ELSE
		COMMIT TRAN

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
		ROLLBACK TRAN
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */	
	
	IF @ret_val IS NULL BEGIN
		SET @ret_val = @ErState
		SET @ret_val_s = @ErMessage
	END	

END CATCH

RETURN

GO