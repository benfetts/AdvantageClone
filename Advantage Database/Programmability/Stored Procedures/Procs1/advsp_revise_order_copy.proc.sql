IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_revise_order_copy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_revise_order_copy]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_revise_order_copy] 
	@user_id varchar(100), 
	@action varchar(10), 
	@cl_code_in varchar(6),
	@div_code_in varchar(6),
	@prd_code_in varchar(6),	
	@cmp_code_in varchar(6),
	@cmp_identifier_in integer,
	@job_number_in integer,
	@job_component_nbr_in integer,
	@order_type_in varchar(2), 	
	@cl_code_to varchar(6),
	@div_code_to varchar(6),
	@prd_code_to varchar(6),	
	@cmp_code_to varchar(6),
	@cmp_identifier_to integer,
	@job_number_to integer,
	@job_component_nbr_to integer,	
	@media_type_to varchar(6), 	
	@order_desc_to varchar(40), 	
	@date_adjust_amt integer,
	@date_adjust_type varchar(1),
	@hdr_status varchar(1),
	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT

AS


/*
***********************************************************************************************************
PJH 01/11/16 - Testing Newspaper
PJH 01/11/16 - Updated calls to advtf_med_calc_cost_rate
PJH 01/19/16 - Added @sales_class_code to advtf_med_get_prd_defaults() parameters
					  Added /* uf_calc_comm_mu - Get reciprocal PCT */
PJH 01/22/16 - Added /* First date should be the Start Date */
PJH 01/29/16 - Added Order Desc to Copy To options
PJH 02/03/16 - Broke out SC from Product so it casn be last override
PJH 02/06/16 - Fixed comments not coming over, fical period, and remarks
PJH 02/08/16 - Only adjust date in Brdcast if Daily Buy
PJH 02/09/16 - @o_type for OUTDOOR
PJH 03/10/16 - Changed @max_order_nbr from smallint to int
PJH 06/27/17 - 735-2-1155 - Media Orders - For the Copy To function, add the ability to select what order/lines to Copy To
PJH 07/25/17 - 735-1-3024 - Media Orders - Copy by Campaign or Job - Sales Class Override missed on first row that is copied
PJH 08/18/17 - added new columns for TV/Radio
PJH 10/31/18 - added new valuse to the advsp_revise_order_detail() call. Passed as NULL.
PJH 12/06/18 - Added @line_market_code, @ad_server_id
PJH 12/11/18 - Added INTERNET_PACKAGE_DETAIL
PJH 12/11/18 - Added @act_impressions
PJH 03/22/19 - Added @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
***********************************************************************************************************
*/


--all HEADER

DECLARE
	@order_nbr int,
	@order_desc varchar(40),
	@order_type varchar(2),
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
	@order_comment varchar(max),
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
	@prod_charge decimal (14, 3),
	@prod_desc varchar (30),
	@color_charge decimal (15, 4),
	@color_desc varchar (30),

	--np
	@print_columns decimal (6, 2),
	@print_inches decimal (6, 2),
	@print_lines decimal (11, 2),
	@np_circulation int, --**added 05/04/15
	@print_quantity decimal (14, 3), --**added 05/04/15

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

	--in
	@proj_impressions int, 
	@guaranteed_impress int, 
	@target_audience varchar (60), 
	@creative_size varchar (60),
	@placement_1 varchar (256),
	@placement_2 varchar (160),
	@act_impressions int,

	@line_market_code varchar(10), --PJH 12/06/18 - Added @line_market_code, @ad_server_id

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
	@rebate_amt_or decimal (14, 2)

DECLARE @tmp_orders TABLE (
	[RowID] [int] IDENTITY(1,1),
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [int] NOT NULL, 
	[MEDIA_TYPE] [varchar](3) NOT NULL
)
--PJH 06/27/17 - added
DECLARE @tmp_orders2 TABLE (
	[RowID] [int] IDENTITY(1,1),
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [int] NOT NULL, 
	[MEDIA_TYPE] [varchar](3) NOT NULL
)

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

DECLARE @sql nvarchar(1000), @where varchar(1000), @param_def varchar(500), @error_msg_w varchar(max)
DECLARE @rr_msg_w varchar(100), @goto_id varchar(50), @s_temp varchar(250)
DECLARE @max_order_nbr int, @ok smallint, @table_prefix varchar(50)
DECLARE @date_time_w smalldatetime, @media_interface varchar(3), @media_interface_in varchar(3), @imported_from varchar(30)

DECLARE @cnt int, @media_type_in varchar(2)
DECLARE @hdr_exists int, @dtl_exists int, @dtl_cmnt_exists int
DECLARE @copy_order_nbr int, @copy_line_nbr int, @copy_hdr int, @copy_detail int
DECLARE @copy_order_nbr_prev int, @copy_line_nbr_prev int
DECLARE @order_type_chg int
DECLARE @rebate_amt_override smallint, @rebate_pct_override smallint, @markup_pct_override smallint, @comm_pct_override smallint
DECLARE @sales_class_code varchar(10), @rev_nbr_import smallint

DECLARE @comm_pct_v decimal (14, 6), @markup_pct_v decimal (14, 6), @rebate_pct_v decimal (14, 6)

DECLARE @def_vr_code varchar(10), @def_vr_code2 varchar(10), @existing_vn_code varchar(10)

DECLARE @p1_52 varchar(254), @spots int, @line_comment varchar(254)--, @flight_type varchar(1)

DECLARE @delete_order int, @cal_type varchar(2), @air_date smalldatetime--, @net_gross_flag int

DECLARE @new_order_nbr int, @min_new_order_nbr int, @max_new_order_nbr int

--/* Used for date calculation */
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

--PJH 06/27/17 - added
DECLARE @filter int, @pos int
DECLARE @order_line varchar(50)
DECLARE @orders_to_copy varchar(max)
DECLARE @list TABLE (
	ORDER_NBR int,
	LINE_NBR int
	)
SELECT @ret_val_s '@ret_val_s'
IF LTRIM(@ret_val_s) > '' BEGIN
	SET @filter = 1
END
ELSE BEGIN
	SET @filter = 0
END
IF @filter = 1 BEGIN
	SET @orders_to_copy = RTRIM(@ret_val_s)
	WHILE LEN(@orders_to_copy) > 0 BEGIN
		SET @pos = CHARINDEX(',',@orders_to_copy, 0) - 1
		IF @pos = -1 SET @pos = LEN(@orders_to_copy)
		SET @order_line = LEFT(@orders_to_copy, @pos)
		INSERT INTO @list SELECT LEFT(@order_line, CHARINDEX('-',@order_line) - 1), RIGHT(@order_line, LEN(@order_line) - CHARINDEX('-',@order_line))
		IF LEN(@orders_to_copy) >= (@pos + 1)
			SET @orders_to_copy = RIGHT(@orders_to_copy, LEN(@orders_to_copy) - (@pos + 1))
		ELSE
			SET @orders_to_copy = ''
	END
END 

SET @cutoff_dt = '12/31/2010'

DECLARE @ROW_COUNT int, @ROW_ID int, @DEBUG int
DECLARE @RC int, @RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int

BEGIN TRY

/********/
--GOTO ERROR_MSG
/********/

IF @action = 'DEBUG'
	SET @DEBUG = 1
ELSE
	SET @DEBUG = 0

IF @DEBUG = 1 BEGIN
	SELECT @orders_to_copy '@orders_to_copy'
	SELECT * FROM @list
END
	
SET @order_type	 = @order_type_in

SELECT @date_time_w=GETDATE()

--SELECT @media_interface = 'AM
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

/* PJH 07/25/17 - 735-1-3024 - Only set dates for broadcast */
IF @order_type IN ('TV','RA') BEGIN
	GOTO SET_DATES
END
AFTER_SET_DATES:

SET NOCOUNT OFF

IF @cmp_identifier_in IS NOT NULL AND @cl_code_in IS NULL BEGIN
	SET @error_msg_w = 'Copy by Campaign - Missing Client Code'
	SET @ret_val_s = @error_msg_w
	SET @ret_val = 1
	GOTO ERROR_MSG	
END

IF @cmp_identifier_in IS NOT NULL BEGIN
	IF @order_type IN ('NP')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM NEWSPAPER_DETAIL A JOIN NEWSPAPER_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE B.CMP_IDENTIFIER = @cmp_identifier_in AND A.ACTIVE_REV = 1
			AND ( ( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in) ) OR
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (@prd_code_in IS NULL) ) OR 
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE IS NULL) AND (@prd_code_in IS NULL) ) )
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('MA')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM MAGAZINE_DETAIL A JOIN MAGAZINE_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE B.CMP_IDENTIFIER = @cmp_identifier_in AND A.ACTIVE_REV = 1
			AND ( ( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in) ) OR
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (@prd_code_in IS NULL) ) OR 
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE IS NULL) AND (@prd_code_in IS NULL) ) )
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('IN')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM INTERNET_DETAIL A JOIN INTERNET_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE B.CMP_IDENTIFIER = @cmp_identifier_in AND A.ACTIVE_REV = 1
			AND ( ( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in) ) OR
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (@prd_code_in IS NULL) ) OR 
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE IS NULL) AND (@prd_code_in IS NULL) ) ) 
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('OD')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM OUTDOOR_DETAIL A JOIN OUTDOOR_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE B.CMP_IDENTIFIER = @cmp_identifier_in AND A.ACTIVE_REV = 1
			AND ( ( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in) ) OR
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (@prd_code_in IS NULL) ) OR 
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE IS NULL) AND (@prd_code_in IS NULL) ) )	 
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('RA')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM RADIO_DETAIL A JOIN RADIO_HDR B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE B.CMP_IDENTIFIER = @cmp_identifier_in AND A.ACTIVE_REV = 1
			AND ( ( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in) ) OR
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (@prd_code_in IS NULL) ) OR 
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE IS NULL) AND (@prd_code_in IS NULL) ) )
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('TV')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM TV_DETAIL A JOIN TV_HDR B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE B.CMP_IDENTIFIER = @cmp_identifier_in AND A.ACTIVE_REV = 1
			AND ( ( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in) ) OR
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (@prd_code_in IS NULL) ) OR 
					( (B.CL_CODE = @cl_code_in) AND (DIV_CODE IS NULL) AND (@prd_code_in IS NULL) ) )
		ORDER BY A.ORDER_NBR, A. LINE_NBR		
END	

IF @job_number_in IS NOT NULL
	IF @cl_code_in IS NULL OR @cl_code_in IS NULL OR @cl_code_in IS NULL BEGIN
		SET @error_msg_w = 'Copy by Job - Missing Client, Division or Product Code'
		SET @ret_val_s = @error_msg_w
		SET @ret_val = 1
		GOTO ERROR_MSG	
	END

IF @job_number_in IS NOT NULL BEGIN
	IF @order_type IN ('NP')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM NEWSPAPER_DETAIL A JOIN NEWSPAPER_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.JOB_NUMBER = @job_number_in AND A.JOB_COMPONENT_NBR = @job_component_nbr_in AND A.ACTIVE_REV = 1
			AND 	(B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in)	 
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('MA')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM MAGAZINE_DETAIL A JOIN MAGAZINE_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.JOB_NUMBER = @job_number_in AND A.JOB_COMPONENT_NBR = @job_component_nbr_in AND A.ACTIVE_REV = 1
			AND 	(B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in)	 
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('IN')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM INTERNET_DETAIL A JOIN INTERNET_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.JOB_NUMBER = @job_number_in AND A.JOB_COMPONENT_NBR = @job_component_nbr_in AND A.ACTIVE_REV = 1
			AND 	(B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in)	 
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('OD')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM OUTDOOR_DETAIL A JOIN OUTDOOR_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.JOB_NUMBER = @job_number_in AND A.JOB_COMPONENT_NBR = @job_component_nbr_in AND A.ACTIVE_REV = 1
			AND 	(B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in)	 
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('RA')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM RADIO_DETAIL A JOIN RADIO_HDR B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.JOB_NUMBER = @job_number_in AND A.JOB_COMPONENT_NBR = @job_component_nbr_in AND A.ACTIVE_REV = 1
			AND 	(B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in)	  
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('TV')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM TV_DETAIL A JOIN TV_HDR B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.JOB_NUMBER = @job_number_in AND A.JOB_COMPONENT_NBR = @job_component_nbr_in AND A.ACTIVE_REV = 1
			AND 	(B.CL_CODE = @cl_code_in) AND (DIV_CODE = @div_code_in) AND (PRD_CODE = @prd_code_in)	  
		ORDER BY A.ORDER_NBR, A. LINE_NBR		
END		

SELECT 'FULL LIST', * FROM @tmp_orders

--PJH 06/27/17 - added
IF @filter = 1 BEGIN
	DELETE FROM @tmp_orders WHERE ORDER_NBR NOT IN (SELECT ORDER_NBR FROM @list)
	DELETE	A
	FROM @tmp_orders A
	LEFT JOIN @list B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR
	WHERE B.LINE_NBR IS NULL
END
INSERT INTO @tmp_orders2 SELECT ORDER_NBR, LINE_NBR, MEDIA_TYPE FROM @tmp_orders
SELECT 'FILTERED LIST', * FROM @tmp_orders2

SET @ROW_COUNT = @@ROWCOUNT

SET @order_type_chg = 0

SET NOCOUNT ON

BEGIN TRAN --TP1

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

IF @ROW_COUNT > 0 BEGIN 
	SET @ROW_ID = 1
END
ELSE BEGIN
	SET @error_msg_w = 'No matching orders found.'
	SET @ret_val_s = @error_msg_w
	SET @ret_val = 1
	GOTO ERROR_MSG	
END

/** Clear Posted rows from PRINT_ORDER table **/
--IF @DEBUG = 1 BEGIN
--	SELECT 'PRINT_ORDERS (Posted) to CLEAR' 'DESC', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM PRINT_ORDER
--	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
--	SELECT 'BRDCAST_ORDER (Posted) to CLEAR' 'DESC', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM BRDCAST_IMPORT
--	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
--END
--ELSE BEGIN
--	DELETE FROM PRINT_ORDER
--	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
--	DELETE FROM BRDCAST_IMPORT
--	WHERE (MEDIA_INTERFACE IN ('AB','AM','AP') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 1)
--END

SET @order_nbr = 0
SET @line_nbr = 0
SET @copy_hdr = 1
SET @copy_detail = 1

WHILE @ROW_ID <= @ROW_COUNT BEGIN

	SELECT @copy_order_nbr = [ORDER_NBR], @copy_line_nbr = [LINE_NBR]
	FROM @tmp_orders2
	WHERE RowID = @ROW_ID	
	
	--SELECT '*' '*', @copy_order_nbr_prev '@copy_order_nbr_prev', @copy_line_nbr_prev '@copy_line_nbr_prev', * FROM @tmp_orders WHERE RowID = @ROW_ID	 /* DEBUG */	
	
	SET @copy_hdr = 1
	SET @copy_detail = 1
	SET @dtl_cmnt_exists = 0
	
	IF @copy_order_nbr_prev = @copy_order_nbr BEGIN
		--SET @copy_hdr = 1
		SET @copy_hdr = 0
		IF @copy_line_nbr_prev = @copy_line_nbr BEGIN
			--SET @copy_detail = 1
			SET @copy_detail = 0
		END
	END
	
	SET @copy_order_nbr_prev = @copy_order_nbr 
	SET @copy_line_nbr_prev = @copy_line_nbr 
	
	--SELECT @copy_hdr '@copy_hdr', @copy_detail '@copy_detail', @media_interface '@media_interface', @media_type '@media_type', @link_id '@link_id', @link_detid '@link_detid' /** DEBUG **/

	SET @action = 'NEW'

	--SELECT @link_detid '@link_detid', @start_date '@start_date', @copy_hdr '@copy_hdr', @copy_detail '@copy_detail'  /* DEBUG */	

	SET @markup_pct_or = NULL
	SET @markup_pct_override = 0
	
	SET @rebate_pct_or = NULL
	SET @rebate_pct_override = 0
	
	SET @rebate_amt_or = NULL
	SET @rebate_amt_override = 0
	
	SET @comm_pct_or = NULL
	SET @comm_pct_override = 0
	
	IF @media_type_in = 'N' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			--SELECT 'GET HDR INFO FOR ORDER: ' + CAST(@order_nbr AS VARCHAR(20)) /** DEBUG **/
			SELECT
			   @order_desc   = [ORDER_DESC]
			  ,@cl_code   = [CL_CODE]
			  ,@div_code   = [DIV_CODE]
			  ,@prd_code   = [PRD_CODE]
			  ,@office_code   = [OFFICE_CODE]
			  ,@cmp_code   = [CMP_CODE]
			  ,@media_type   = [MEDIA_TYPE]
			  ,@vn_code   = [VN_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]
			  ,@client_ref   = [CLIENT_REF]
			  ,@status   = [STATUS]
			  ,@is_quote   = COALESCE(@hdr_status, '0') --[STATUS]
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
			  ,@start_date   = [START_DATE]
			  ,@end_date   = [END_DATE]
			  ,@units   = [UNITS]
			  ,@nbr_of_units   = [NBR_OF_UNITS]
			  ,@net_gross   = [NET_GROSS]
			  --,@create_date   = [CREATE_DATE]
			  --,@user_id   = [USER_ID]
			  --,@cancelled   = [CANCELLED]
			  --,@cancelled_by   = [CANCELLED_BY]
			  --,@cancelled_date   = [CANCELLED_DATE]
			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  --,@revised_flag   = [REVISED_FLAG]
			  --,@link_id   = [LINK_ID]
			  --,@reconcile_flag   = [RECONCILE_FLAG]
			  ,@cmp_identifier   = [CMP_IDENTIFIER]
			  --,@printed   = [PRINTED]
			  --,@order_accepted   = [ORDER_ACCEPTED]
			  ,@fiscal_period_code   = [FISCAL_PERIOD_CODE]
			  --,@locked   = [LOCKED]
			  --,@locked_by   = [LOCKED_BY]
			  --,@bcc_id   = [BCC_ID]
			FROM NEWSPAPER_HEADER
			WHERE ORDER_NBR = @copy_order_nbr	
			
			/* HEADER OVERRIDES */
			SET @cl_code = COALESCE(@cl_code_to, @cl_code)
			SET @div_code = COALESCE(@div_code_to, @div_code)
			SET @prd_code = COALESCE(@prd_code_to, @prd_code)
			SET @cmp_code = COALESCE(@cmp_code_to, @cmp_code)
			SET @cmp_identifier = COALESCE(@cmp_identifier_to, @cmp_identifier)
			SET @media_type = COALESCE(@media_type_to, @media_type) 

			SET @order_desc = COALESCE(@order_desc_to, @order_desc)
			
			--IF @date_adjust_type = 'D' BEGIN
			--	SET @order_date = DATEADD(dd, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'W' BEGIN
			--	SET @order_date = DATEADD(ww, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'M' BEGIN
			--	SET @order_date = DATEADD(mm, @date_adjust_amt, @order_date)
			--END			
			SET @order_date = @date_time_w
		END	
		
		IF @DEBUG = 1 SELECT @media_type '@media_type', @media_type_to '@media_type_to' /* DEBUG */
		
		IF @copy_detail = 1 BEGIN
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
					   @taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], --@reconcile_flag_d=[RECONCILE_FLAG],
					   ----[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
					   ----[GLACODE_COUNTY], [GLACODE_CITY], 
					   @non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS], 
					   @bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT],							   
					   ----[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
					   @billing_amt=[BILLING_AMT], --[BILL_CANCELLED],
					   --@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR], 
					   @flat_netcharge=[FLAT_NETCHARGE], @flat_addl_charge=[FLAT_ADDL_CHARGE], 
					   @flat_discount_amt=[FLAT_DISCOUNT_AMT], @production_size=[PRODUCTION_SIZE], @mat_comp=[MAT_COMP], @size_code=[SIZE_CODE], 
					   @cost_type=[COST_TYPE], @cost_rate=[COST_RATE], @rate_type=[RATE_TYPE], @np_circulation=[NP_CIRCULATION], @print_quantity=[PRINT_QUANTITY]
			FROM [dbo].[NEWSPAPER_DETAIL] 
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1	;		
		END
		
		/* DETAIL OVERRIDES */
		SET @job_number = COALESCE(@job_number_to, @job_number)		
		SET @job_component_nbr = COALESCE(@job_component_nbr_to, @job_component_nbr)		
		
		IF @date_adjust_type = 'D' BEGIN
			SET @start_date = DATEADD(dd, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(dd, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(dd, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(dd, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(dd, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(dd, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(dd, @date_adjust_amt, @date_to_bill)	
		END
		ELSE IF @date_adjust_type = 'W' BEGIN
			SET @start_date = DATEADD(ww, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(ww, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(ww, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(ww, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(ww, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(ww, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(ww, @date_adjust_amt, @date_to_bill)
		END
		ELSE IF @date_adjust_type = 'M' BEGIN
			SET @start_date = DATEADD(mm, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(mm, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(mm, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(mm, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(mm, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(mm, @date_adjust_amt, @ext_matl_date)
			SET @date_to_bill = DATEADD(mm, @date_adjust_amt, @date_to_bill)
		END		

		--SELECT @order_nbr = [ORDER_NBR], @line_nbr = [LINE_NBR]
		--FROM @tmp_orders
		--WHERE RowID = @ROW_ID

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @close_date=NULL, @matl_close_date=NULL, @ext_close_date=NULL, @ext_matl_date=NULL, @date_to_bill=NULL

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
		
		--SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
		
		IF @cost_type= 'CPM' BEGIN
			IF @units = 'D' BEGIN
				SET @units = 'W'
			END
		END
	END /* End NP */
	
	IF @media_type_in = 'M' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			--SELECT 'GET HDR INFO FOR ORDER: ' + CAST(@order_nbr AS VARCHAR(20)) /** DEBUG **/
			SELECT
			   @order_desc   = [ORDER_DESC]
			  ,@cl_code   = [CL_CODE]
			  ,@div_code   = [DIV_CODE]
			  ,@prd_code   = [PRD_CODE]
			  ,@office_code   = [OFFICE_CODE]
			  ,@cmp_code   = [CMP_CODE]
			  ,@media_type   = [MEDIA_TYPE]
			  ,@vn_code   = [VN_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]
			  ,@client_ref   = [CLIENT_REF]
			  ,@status   = [STATUS]
			  ,@is_quote   = COALESCE(@hdr_status, '0') --[STATUS]
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
			  ,@start_date   = [START_DATE]
			  ,@end_date   = [END_DATE]
			  ,@units   = [UNITS]
			  ,@nbr_of_units   = [NBR_OF_UNITS]
			  ,@net_gross   = [NET_GROSS]
			  --,@create_date   = [CREATE_DATE]
			  --,@user_id   = [USER_ID]
			  --,@cancelled   = [CANCELLED]
			  --,@cancelled_by   = [CANCELLED_BY]
			  --,@cancelled_date   = [CANCELLED_DATE]
			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  --,@revised_flag   = [REVISED_FLAG]
			  --,@link_id   = [LINK_ID]
			  --,@reconcile_flag   = [RECONCILE_FLAG]
			  ,@cmp_identifier   = [CMP_IDENTIFIER]
			  --,@printed   = [PRINTED]
			  --,@order_accepted   = [ORDER_ACCEPTED]
			  ,@fiscal_period_code   = [FISCAL_PERIOD_CODE]
			  --,@locked   = [LOCKED]
			  --,@locked_by   = [LOCKED_BY]
			  --,@bcc_id   = [BCC_ID]			  

			FROM MAGAZINE_HEADER
			WHERE ORDER_NBR = @copy_order_nbr	
			
			/* HEADER OVERRIDES */
			SET @cl_code = COALESCE(@cl_code_to, @cl_code)
			SET @div_code = COALESCE(@div_code_to, @div_code)
			SET @prd_code = COALESCE(@prd_code_to, @prd_code)
			SET @cmp_code = COALESCE(@cmp_code_to, @cmp_code)
			SET @cmp_identifier = COALESCE(@cmp_identifier_to, @cmp_identifier)
			SET @media_type = COALESCE(@media_type_to, @media_type)

			SET @order_desc = COALESCE(@order_desc_to, @order_desc)
			
			--IF @date_adjust_type = 'D' BEGIN
			--	SET @order_date = DATEADD(dd, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'W' BEGIN
			--	SET @order_date = DATEADD(ww, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'M' BEGIN
			--	SET @order_date = DATEADD(mm, @date_adjust_amt, @order_date)
			--END		
			SET @order_date = @date_time_w	
		END	

		IF @copy_detail = 1 BEGIN
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
							@taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], --@reconcile_flag_d=[RECONCILE_FLAG],
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
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1	;		
		END
		
		/* DETAIL OVERRIDES */
		SET @job_number = COALESCE(@job_number_to, @job_number)		
		SET @job_component_nbr = COALESCE(@job_component_nbr_to, @job_component_nbr)		
		
		IF @date_adjust_type = 'D' BEGIN
			SET @start_date = DATEADD(dd, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(dd, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(dd, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(dd, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(dd, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(dd, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(dd, @date_adjust_amt, @date_to_bill)	
		END
		ELSE IF @date_adjust_type = 'W' BEGIN
			SET @start_date = DATEADD(ww, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(ww, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(ww, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(ww, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(ww, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(ww, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(ww, @date_adjust_amt, @date_to_bill)
		END
		ELSE IF @date_adjust_type = 'M' BEGIN
			SET @start_date = DATEADD(mm, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(mm, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(mm, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(mm, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(mm, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(mm, @date_adjust_amt, @ext_matl_date)
			SET @date_to_bill = DATEADD(mm, @date_adjust_amt, @date_to_bill)
		END			

		--SELECT @order_nbr = [ORDER_NBR], @line_nbr = [LINE_NBR]
		--FROM @tmp_orders
		--WHERE RowID = @ROW_ID

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @close_date=NULL, @matl_close_date=NULL, @ext_close_date=NULL, @ext_matl_date=NULL, @date_to_bill=NULL

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
		
		--SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End MAG */
	
	IF @media_type_in = 'I' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]
			  ,@cl_code   = [CL_CODE]
			  ,@div_code   = [DIV_CODE]
			  ,@prd_code   = [PRD_CODE]
			  ,@office_code   = [OFFICE_CODE]
			  ,@cmp_code   = [CMP_CODE]
			  ,@media_type   = [MEDIA_TYPE]
			  ,@vn_code   = [VN_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]
			  ,@client_ref   = [CLIENT_REF]
			  ,@status   = [STATUS]
			  ,@is_quote   = COALESCE(@hdr_status, '0') --[STATUS]
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
			  ,@start_date   = [START_DATE]
			  ,@end_date   = [END_DATE]
			  ,@units   = [UNITS]
			 --,@nbr_of_units   = [NBR_OF_UNITS]
			  ,@net_gross   = [NET_GROSS]
			  --,@create_date   = [CREATE_DATE]
			  --,@user_id   = [USER_ID]
			  --,@cancelled   = [CANCELLED]
			  --,@cancelled_by   = [CANCELLED_BY]
			  --,@cancelled_date   = [CANCELLED_DATE]
			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  --,@revised_flag   = [REVISED_FLAG]
			  --,@link_id   = [LINK_ID]
			  --,@reconcile_flag   = [RECONCILE_FLAG]
			  ,@cmp_identifier   = [CMP_IDENTIFIER]
			  --,@printed   = [PRINTED]
			  --,@order_accepted   = [ORDER_ACCEPTED]
			  ,@fiscal_period_code   = [FISCAL_PERIOD_CODE]
			  --,@locked   = [LOCKED]
			  --,@locked_by   = [LOCKED_BY]
			  --,@bcc_id   = [BCC_ID]

			FROM INTERNET_HEADER
			WHERE ORDER_NBR = @copy_order_nbr	
			
			/* HEADER OVERRIDES */
			SET @cl_code = COALESCE(@cl_code_to, @cl_code)
			SET @div_code = COALESCE(@div_code_to, @div_code)
			SET @prd_code = COALESCE(@prd_code_to, @prd_code)
			SET @cmp_code = COALESCE(@cmp_code_to, @cmp_code)
			SET @cmp_identifier = COALESCE(@cmp_identifier_to, @cmp_identifier)
			SET @media_type = COALESCE(@media_type_to, @media_type)

			SET @order_desc = COALESCE(@order_desc_to, @order_desc)
			
			--IF @date_adjust_type = 'D' BEGIN
			--	SET @order_date = DATEADD(dd, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'W' BEGIN
			--	SET @order_date = DATEADD(ww, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'M' BEGIN
			--	SET @order_date = DATEADD(mm, @date_adjust_amt, @order_date)
			--END
			SET @order_date = @date_time_w			
		END	

		IF @copy_detail = 1 BEGIN
			SELECT @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
							@matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE], @size=[SIZE], 
							@ad_number=[AD_NUMBER], @headline=[HEADLINE], @o_type=[INTERNET_TYPE], 
							@proj_impressions=[PROJ_IMPRESSIONS], @guaranteed_impress=[GUARANTEED_IMPRESS], @act_impressions=[ACT_IMPRESSIONS],
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
							@taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], --@reconcile_flag_d=[RECONCILE_FLAG],
							----[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							----[GLACODE_COUNTY], [GLACODE_CITY], 
							@non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS], 
							@bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT],							   
							----[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							@billing_amt=[BILLING_AMT], --[BILL_CANCELLED],
							@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR],
							@mat_comp=[MAT_COMP],
							@cost_rate = [COST_RATE], 
							@net_base_rate = [NET_BASE_RATE], @gross_base_rate = [GROSS_BASE_RATE],
							@cost_type = [COST_TYPE], @rate_type = [RATE_TYPE],
							@creative_size = [CREATIVE_SIZE], @placement_1 = [PLACEMENT_1] ,@placement_2 = [PLACEMENT_2],
							@line_market_code = [MARKET_CODE],
							@channel = [MEDIA_CHANNEL_ID],
							@tactic = [MEDIA_TACTIC_ID]
			FROM [dbo].[INTERNET_DETAIL] 
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1	;		
		END
		
		/* DETAIL OVERRIDES */
		SET @job_number = COALESCE(@job_number_to, @job_number)		
		SET @job_component_nbr = COALESCE(@job_component_nbr_to, @job_component_nbr)		
		--PJH 12/11/18 - Added @act_impressions
		SET @act_impressions = NULL	

		
		IF @date_adjust_type = 'D' BEGIN
			SET @start_date = DATEADD(dd, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(dd, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(dd, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(dd, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(dd, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(dd, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(dd, @date_adjust_amt, @date_to_bill)	
		END
		ELSE IF @date_adjust_type = 'W' BEGIN
			SET @start_date = DATEADD(ww, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(ww, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(ww, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(ww, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(ww, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(ww, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(ww, @date_adjust_amt, @date_to_bill)
		END
		ELSE IF @date_adjust_type = 'M' BEGIN
			SET @start_date = DATEADD(mm, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(mm, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(mm, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(mm, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(mm, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(mm, @date_adjust_amt, @ext_matl_date)
			SET @date_to_bill = DATEADD(mm, @date_adjust_amt, @date_to_bill)
		END			

		--SELECT @order_nbr = [ORDER_NBR], @line_nbr = [LINE_NBR]
		--FROM @tmp_orders
		--WHERE RowID = @ROW_ID

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @close_date=NULL, @matl_close_date=NULL, @ext_close_date=NULL, @ext_matl_date=NULL, @date_to_bill=NULL

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END
		
		SELECT 'AFTER SELECT OLD' '-', @gross_rate '@gross_rate', @net_rate '@net_rate', @net_gross '@net_gross', @quantity '@quantity', @ext_net_amt '@ext_net_amt', @ext_gross_amt '@ext_gross_amt', @comm_pct '@comm_pct', @markup_pct '@markup_pct', @rebate_pct '@rebate_pct'        /* DEBUG */

		SET @addl_charge_desc = CASE WHEN (@addl_charge IS NULL OR @addl_charge = 0) THEN NULL ELSE 'Additional Charge' END
		SET @ncdesc = CASE WHEN (@netcharge IS NULL OR @netcharge = 0) THEN NULL ELSE 'Net Charge' END
		SET @color_desc = CASE WHEN (@color_charge IS NULL OR @color_charge = 0) THEN NULL ELSE 'Color Charge' END 
		
		--SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End INET */
	
	IF @media_type_in = 'O' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]
			  ,@cl_code   = [CL_CODE]
			  ,@div_code   = [DIV_CODE]
			  ,@prd_code   = [PRD_CODE]
			  ,@office_code   = [OFFICE_CODE]
			  ,@cmp_code   = [CMP_CODE]
			  ,@media_type   = [MEDIA_TYPE]
			  ,@vn_code   = [VN_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]
			  ,@client_ref   = [CLIENT_REF]
			  ,@status   = [STATUS]
			  ,@is_quote   = COALESCE(@hdr_status, '0') --[STATUS]
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
			  ,@start_date   = [START_DATE]
			  ,@end_date   = [END_DATE]
			  ,@units   = [UNITS]
			  ,@nbr_of_units   = [NBR_OF_UNITS]
			  ,@net_gross   = [NET_GROSS]
			  --,@create_date   = [CREATE_DATE]
			  --,@user_id   = [USER_ID]
			  --,@cancelled   = [CANCELLED]
			  --,@cancelled_by   = [CANCELLED_BY]
			  --,@cancelled_date   = [CANCELLED_DATE]
			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  --,@revised_flag   = [REVISED_FLAG]
			  --,@link_id   = [LINK_ID]
			  --,@reconcile_flag   = [RECONCILE_FLAG]
			  ,@cmp_identifier   = [CMP_IDENTIFIER]
			  --,@printed   = [PRINTED]
			  --,@order_accepted   = [ORDER_ACCEPTED]
			  ,@fiscal_period_code   = [FISCAL_PERIOD_CODE]
			  --,@locked   = [LOCKED]
			  --,@locked_by   = [LOCKED_BY]
			  --,@bcc_id   = [BCC_ID]
			FROM OUTDOOR_HEADER
			WHERE ORDER_NBR = @copy_order_nbr	
			
			/* HEADER OVERRIDES */
			SET @cl_code = COALESCE(@cl_code_to, @cl_code)
			SET @div_code = COALESCE(@div_code_to, @div_code)
			SET @prd_code = COALESCE(@prd_code_to, @prd_code)
			SET @cmp_code = COALESCE(@cmp_code_to, @cmp_code)
			SET @cmp_identifier = COALESCE(@cmp_identifier_to, @cmp_identifier)
			SET @media_type = COALESCE(@media_type_to, @media_type)

			SET @order_desc = COALESCE(@order_desc_to, @order_desc)
			
			--IF @date_adjust_type = 'D' BEGIN
			--	SET @order_date = DATEADD(dd, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'W' BEGIN
			--	SET @order_date = DATEADD(ww, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'M' BEGIN
			--	SET @order_date = DATEADD(mm, @date_adjust_amt, @order_date)
			--END		
			SET @order_date = @date_time_w	
		END	

		IF @copy_detail = 1 BEGIN
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
							@taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], --@reconcile_flag_d=[RECONCILE_FLAG],
							----[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							----[GLACODE_COUNTY], [GLACODE_CITY], 
							@non_bill_flag=[NON_BILL_FLAG], @modified_by=[MODIFIED_BY], @modified_date=[MODIFIED_DATE], @modified_comments=[MODIFIED_COMMENTS], 
							@bill_type_flag=[BILL_TYPE_FLAG], @comm_pct=[COMM_PCT],							   
							----[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							@billing_amt=[BILLING_AMT], --[BILL_CANCELLED],
							@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR], 
							@mat_comp=[MAT_COMP], @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
			FROM [dbo].[OUTDOOR_DETAIL] 
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1	;		
		END

	--SELECT 'GET DTL', @billing_amt '@billing_amt', @line_total '@line_total', @ext_net_amt '@ext_net_amt', @discount_amt '@discount_amt', @netcharge '@netcharge',   /* DEBUG */
	-- @addl_charge '@addl_charge', @comm_amt '@comm_amt', @rebate_amt '@rebate_amt'			
	 	
		/* DETAIL OVERRIDES */
		SET @job_number = COALESCE(@job_number_to, @job_number)		
		SET @job_component_nbr = COALESCE(@job_component_nbr_to, @job_component_nbr)		
		
		IF @date_adjust_type = 'D' BEGIN
			SET @start_date = DATEADD(dd, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(dd, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(dd, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(dd, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(dd, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(dd, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(dd, @date_adjust_amt, @date_to_bill)	
		END
		ELSE IF @date_adjust_type = 'W' BEGIN
			SET @start_date = DATEADD(ww, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(ww, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(ww, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(ww, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(ww, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(ww, @date_adjust_amt, @ext_matl_date)			
			SET @date_to_bill = DATEADD(ww, @date_adjust_amt, @date_to_bill)
		END
		ELSE IF @date_adjust_type = 'M' BEGIN
			SET @start_date = DATEADD(mm, @date_adjust_amt, @start_date)
			SET @end_date = DATEADD(mm, @date_adjust_amt, @end_date)
			SET @close_date = DATEADD(mm, @date_adjust_amt, @close_date)
			IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(mm, @date_adjust_amt, @matl_close_date)
			IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(mm, @date_adjust_amt, @ext_close_date)
			IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(mm, @date_adjust_amt, @ext_matl_date)
			SET @date_to_bill = DATEADD(mm, @date_adjust_amt, @date_to_bill)
		END			

		--SELECT @order_nbr = [ORDER_NBR], @line_nbr = [LINE_NBR]
		--FROM @tmp_orders
		--WHERE RowID = @ROW_ID

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @close_date=NULL, @matl_close_date=NULL, @ext_close_date=NULL, @ext_matl_date=NULL, @date_to_bill=NULL

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
		
		--SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End OOH */

	IF @media_type_in = 'T' BEGIN

		/** Get current Values if they exist **/

		IF @copy_hdr = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]
			  ,@cl_code   = [CL_CODE]
			  ,@div_code   = [DIV_CODE]
			  ,@prd_code   = [PRD_CODE]
			  ,@office_code   = [OFFICE_CODE]
			  ,@cmp_code   = [CMP_CODE]
			  ,@media_type   = [MEDIA_TYPE]
			  ,@vn_code   = [VN_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]
			  ,@client_ref   = [CLIENT_REF]
			  ,@status   = [STATUS]
			  ,@is_quote   = COALESCE(@hdr_status, '0') --[STATUS]
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
			  ,@start_date   = [START_DATE]
			  ,@end_date   = [END_DATE]
			  ,@units   = [UNITS]
			  --,@nbr_of_units   = [NBR_OF_UNITS]
			  ,@net_gross   = [NET_GROSS]
			  --,@create_date   = [CREATE_DATE]
			  --,@user_id   = [USER_ID]
			  --,@cancelled   = [CANCELLED]
			  --,@cancelled_by   = [CANCELLED_BY]
			  --,@cancelled_date   = [CANCELLED_DATE]
			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  --,@revised_flag   = [REVISED_FLAG]
			  --,@link_id   = [LINK_ID]
			  --,@reconcile_flag   = [RECONCILE_FLAG]
			  ,@cmp_identifier   = [CMP_IDENTIFIER]
			  --,@printed   = [PRINTED]
			  --,@order_accepted   = [ORDER_ACCEPTED]
			  ,@fiscal_period_code   = [FISCAL_PERIOD_CODE]
			  --,@locked   = [LOCKED]
			  --,@locked_by   = [LOCKED_BY]
			  --,@bcc_id   = [BCC_ID]
			FROM TV_HDR
			WHERE ORDER_NBR = @copy_order_nbr	
			
			/* HEADER OVERRIDES */
			SET @cl_code = COALESCE(@cl_code_to, @cl_code)
			SET @div_code = COALESCE(@div_code_to, @div_code)
			SET @prd_code = COALESCE(@prd_code_to, @prd_code)
			SET @cmp_code = COALESCE(@cmp_code_to, @cmp_code)
			SET @cmp_identifier = COALESCE(@cmp_identifier_to, @cmp_identifier)
			SET @media_type = COALESCE(@media_type_to, @media_type)

			SET @order_desc = COALESCE(@order_desc_to, @order_desc)
			
			--IF @date_adjust_type = 'D' BEGIN
			--	SET @order_date = DATEADD(dd, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'W' BEGIN
			--	SET @order_date = DATEADD(ww, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'M' BEGIN
			--	SET @order_date = DATEADD(mm, @date_adjust_amt, @order_date)
			--END	
			SET @order_date = @date_time_w		
		END	
		
		IF @copy_detail = 1 BEGIN
			SELECT --@order_nbr=[ORDER_NBR], @line_nbr=[LINE_NBR], @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @link_detid=[LINK_DETID]
				   @buy_type=[BUY_TYPE], @start_date=[START_DATE], @end_date=[END_DATE], @month_nbr=[MONTH_NBR], @year_nbr=[YEAR_NBR]
				  ,@close_date=[CLOSE_DATE], @matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE]
				  ,@date1=[DATE1], @date2=[DATE2], @date3=[DATE3], @date4=[DATE4], @date5=[DATE5], @date6=[DATE6], @date7=[DATE7]
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
				  --,@reconcile_flag_d=[RECONCILE_FLAG]    
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
			FROM [dbo].[TV_DETAIL]
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1;		
		END
		
		/* DETAIL OVERRIDES */
		SET @job_number = COALESCE(@job_number_to, @job_number)		
		SET @job_component_nbr = COALESCE(@job_component_nbr_to, @job_component_nbr)		
		
		--PJH 02/08/16 - Only adjust date in Brdcast if Daily Buy
		IF @units = 'DB' BEGIN
			SELECT @units '@units', @date_adjust_type '@date_adjust_type', @start_date '@start_date', @end_date '@end_date', @date_adjust_amt '@date_adjust_amt'   /* DEBUG */
			IF @date_adjust_type = 'D' BEGIN
				SET @start_date = DATEADD(dd, @date_adjust_amt, @start_date)
				SET @end_date = DATEADD(dd, @date_adjust_amt, @end_date)
				SET @close_date = DATEADD(dd, @date_adjust_amt, @close_date)
				IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(dd, @date_adjust_amt, @matl_close_date)
				IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(dd, @date_adjust_amt, @ext_close_date)
				IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(dd, @date_adjust_amt, @ext_matl_date)			
				SET @date_to_bill = DATEADD(dd, @date_adjust_amt, @date_to_bill)	
			END
			ELSE IF @date_adjust_type = 'W' BEGIN
				SET @start_date = DATEADD(ww, @date_adjust_amt, @start_date)
				SET @end_date = DATEADD(ww, @date_adjust_amt, @end_date)
				SET @close_date = DATEADD(ww, @date_adjust_amt, @close_date)
				IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(ww, @date_adjust_amt, @matl_close_date)
				IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(ww, @date_adjust_amt, @ext_close_date)
				IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(ww, @date_adjust_amt, @ext_matl_date)			
				SET @date_to_bill = DATEADD(ww, @date_adjust_amt, @date_to_bill)
			END
			ELSE IF @date_adjust_type = 'M' BEGIN
				SET @start_date = DATEADD(mm, @date_adjust_amt, @start_date)
				SET @end_date = DATEADD(mm, @date_adjust_amt, @end_date)
				SET @close_date = DATEADD(mm, @date_adjust_amt, @close_date)
				IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(mm, @date_adjust_amt, @matl_close_date)
				IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(mm, @date_adjust_amt, @ext_close_date)
				IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(mm, @date_adjust_amt, @ext_matl_date)
				SET @date_to_bill = DATEADD(mm, @date_adjust_amt, @date_to_bill)
			END		
			SELECT @units '@units', @date_adjust_type '@date_adjust_type', @start_date '@start_date', @end_date '@end_date'   /* DEBUG */
		END
		
		--IF @DEBUG = 1 SELECT @start_date '@start_date', @end_date '@end_date'      /* DEBUG */
		
		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @close_date=NULL, @matl_close_date=NULL, @ext_close_date=NULL, @ext_matl_date=NULL, @date_to_bill=NULL


		SET @cal_type = @units

		--IF ISDATE(@air_date) = 1 BEGIN
		--	SET @cal_type = 'DB'
		--END
		--ELSE BEGIN
		--	IF @cal_type IS NULL
		--		SET @cal_type = 'BM' 
		--END

		SET @buy_type = @cal_type

		--SET @remarks = @line_comment

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		--SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End TV */
	
	IF @media_type_in = 'R' BEGIN

		/** Get current Values if they exist **/

		--IF @
		
		IF @copy_hdr = 1 BEGIN
			SELECT
			   @order_desc   = [ORDER_DESC]
			  ,@cl_code   = [CL_CODE]
			  ,@div_code   = [DIV_CODE]
			  ,@prd_code   = [PRD_CODE]
			  ,@office_code   = [OFFICE_CODE]
			  ,@cmp_code   = [CMP_CODE]
			  ,@media_type   = [MEDIA_TYPE]
			  ,@vn_code   = [VN_CODE]
			  ,@existing_vn_code = [VN_CODE]
			  ,@vr_code   = [VR_CODE]
			  ,@vr_code2   = [VR_CODE2]
			  ,@client_po   = [CLIENT_PO]
			  ,@client_ref   = [CLIENT_REF]
			  ,@status   = [STATUS]
			  ,@is_quote   = COALESCE(@hdr_status, '0') --[STATUS]
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
			  ,@start_date   = [START_DATE]
			  ,@end_date   = [END_DATE]
			  ,@units   = [UNITS]
			  --,@nbr_of_units   = [NBR_OF_UNITS]
			  ,@net_gross   = [NET_GROSS]
			  --,@create_date   = [CREATE_DATE]
			  --,@user_id   = [USER_ID]
			  --,@cancelled   = [CANCELLED]
			  --,@cancelled_by   = [CANCELLED_BY]
			  --,@cancelled_date   = [CANCELLED_DATE]
			  ,@modified_by   = [MODIFIED_BY]
			  ,@modified_date   = [MODIFIED_DATE]
			  ,@modified_comments   = [MODIFIED_COMMENTS]
			  --,@revised_flag   = [REVISED_FLAG]
			  --,@link_id   = [LINK_ID]
			  --,@reconcile_flag   = [RECONCILE_FLAG]
			  ,@cmp_identifier   = [CMP_IDENTIFIER]
			  --,@printed   = [PRINTED]
			  --,@order_accepted   = [ORDER_ACCEPTED]
			  ,@fiscal_period_code   = [FISCAL_PERIOD_CODE]
			  --,@locked   = [LOCKED]
			  --,@locked_by   = [LOCKED_BY]
			  --,@bcc_id   = [BCC_ID]
			FROM RADIO_HDR
			WHERE ORDER_NBR = @copy_order_nbr	
			
			/* HEADER OVERRIDES */
			SET @cl_code = COALESCE(@cl_code_to, @cl_code)
			SET @div_code = COALESCE(@div_code_to, @div_code)
			SET @prd_code = COALESCE(@prd_code_to, @prd_code)
			SET @cmp_code = COALESCE(@cmp_code_to, @cmp_code)
			SET @cmp_identifier = COALESCE(@cmp_identifier_to, @cmp_identifier)
			SET @media_type = COALESCE(@media_type_to, @media_type)

			SET @order_desc = COALESCE(@order_desc_to, @order_desc)
			
			--IF @date_adjust_type = 'D' BEGIN
			--	SET @order_date = DATEADD(dd, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'W' BEGIN
			--	SET @order_date = DATEADD(ww, @date_adjust_amt, @order_date)
			--END
			--ELSE IF @date_adjust_type = 'M' BEGIN
			--	SET @order_date = DATEADD(mm, @date_adjust_amt, @order_date)
			--END			
			SET @order_date = @date_time_w
		END	

		IF @copy_detail = 1 BEGIN
			SELECT --@order_nbr=[ORDER_NBR], @line_nbr=[LINE_NBR], @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @link_detid=[LINK_DETID],
				   @buy_type=[BUY_TYPE], @start_date=[START_DATE], @end_date=[END_DATE], @month_nbr=[MONTH_NBR], @year_nbr=[YEAR_NBR]
				  ,@close_date=[CLOSE_DATE], @matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE]
				  ,@date1=[DATE1], @date2=[DATE2], @date3=[DATE3], @date4=[DATE4], @date5=[DATE5], @date6=[DATE6], @date7=[DATE7]
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
				  --,@reconcile_flag_d=[RECONCILE_FLAG]    
				  ,@billing_amt=[BILLING_AMT], @cost_type=[COST_TYPE], @cost_rate=[COST_RATE], @net_base_rate=[NET_BASE_RATE], @gross_base_rate=[GROSS_BASE_RATE]
				  --,[BILL_CANCELLED]
				  ,@est_nbr=[EST_NBR], @est_line_nbr=[EST_LINE_NBR], @est_rev_nbr=[EST_REV_NBR]
				  ,@ad_number=[AD_NUMBER], @mat_comp=[MAT_COMP], @programming=[PROGRAMMING]
				  ,@start_time=[START_TIME], @end_time=[END_TIME], @length=[LENGTH], @remarks=[REMARKS], @tag=[TAG]
				  ,@network_id=[NETWORK_ID]
				  --PJH 08/18/17 - added new columns
				 ,@daypart_id = [DAY_PART_ID]
				 ,@added_value = [ADDED_VALUE]
			FROM [dbo].[RADIO_DETAIL]
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1;		
		END
		
		/* DETAIL OVERRIDES */
		SET @job_number = COALESCE(@job_number_to, @job_number)		
		SET @job_component_nbr = COALESCE(@job_component_nbr_to, @job_component_nbr)		
		
		--PJH 02/08/16 - Only adjust date in Brdcast if Daily Buy
		IF @units = 'DB' BEGIN
			IF @date_adjust_type = 'D' BEGIN
				SET @start_date = DATEADD(dd, @date_adjust_amt, @start_date)
				SET @end_date = DATEADD(dd, @date_adjust_amt, @end_date)
				SET @close_date = DATEADD(dd, @date_adjust_amt, @close_date)
				IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(dd, @date_adjust_amt, @matl_close_date)
				IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(dd, @date_adjust_amt, @ext_close_date)
				IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(dd, @date_adjust_amt, @ext_matl_date)			
				SET @date_to_bill = DATEADD(dd, @date_adjust_amt, @date_to_bill)	
			END
			ELSE IF @date_adjust_type = 'W' BEGIN
				SET @start_date = DATEADD(ww, @date_adjust_amt, @start_date)
				SET @end_date = DATEADD(ww, @date_adjust_amt, @end_date)
				SET @close_date = DATEADD(ww, @date_adjust_amt, @close_date)
				IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(ww, @date_adjust_amt, @matl_close_date)
				IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(ww, @date_adjust_amt, @ext_close_date)
				IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(ww, @date_adjust_amt, @ext_matl_date)			
				SET @date_to_bill = DATEADD(ww, @date_adjust_amt, @date_to_bill)
			END
			ELSE IF @date_adjust_type = 'M' BEGIN
				SET @start_date = DATEADD(mm, @date_adjust_amt, @start_date)
				SET @end_date = DATEADD(mm, @date_adjust_amt, @end_date)
				SET @close_date = DATEADD(mm, @date_adjust_amt, @close_date)
				IF @matl_close_date IS NOT NULL SET @matl_close_date = DATEADD(mm, @date_adjust_amt, @matl_close_date)
				IF @ext_close_date IS NOT NULL SET @ext_close_date = DATEADD(mm, @date_adjust_amt, @ext_close_date)
				IF @ext_matl_date IS NOT NULL SET @ext_matl_date = DATEADD(mm, @date_adjust_amt, @ext_matl_date)
				SET @date_to_bill = DATEADD(mm, @date_adjust_amt, @date_to_bill)
			END	
		END		

		--SELECT @order_nbr = [ORDER_NBR], @line_nbr = [LINE_NBR]
		--FROM @tmp_orders
		--WHERE RowID = @ROW_ID

		/* PJH 11/30/15 - Recalc Dates in case start date changes */
		SELECT @close_date=NULL, @matl_close_date=NULL, @ext_close_date=NULL, @ext_matl_date=NULL, @date_to_bill=NULL
		
		SET @cal_type = @units

		--IF ISDATE(@air_date) = 1 BEGIN
		--	SET @cal_type = 'DB'
		--END
		--ELSE BEGIN
		--	IF @cal_type IS NULL
		--		SET @cal_type = 'BM' 
		--END
		
		SET @buy_type = @cal_type
		
		--SET @remarks = @line_comment

		IF @existing_vn_code = @vn_code OR @existing_vn_code IS NULL BEGIN
			SELECT	@def_vr_code = DEF_VN_REP1, @def_vr_code2 = DEF_VN_REP2
			FROM	VENDOR
			WHERE	VN_CODE = @vn_code
		
			IF @vr_code IS NULL SET @vr_code = @def_vr_code
			IF @vr_code2 IS NULL SET @vr_code2 = @def_vr_code2
		END

		--SET @status = COALESCE(@is_quote, 0) /** 0 = (order), 1 = (quote) **/
	END /* End RADIO */	
	
	--SELECT @units '@units', @media_type '@media_type'

	SELECT @ord_process_contrl = COALESCE(@ord_process_contrl, 1) --@pub_station = COALESCE(@pub_station,1),

	IF @cmp_identifier IS NULL
		SELECT @cmp_identifier  = CMP_IDENTIFIER FROM CAMPAIGN WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE= @prd_code AND CMP_CODE = @cmp_code	

	--IF @copy_detail = 1 BEGIN
	--	SET @action = 'REVISE'
	--END 
	--ELSE BEGIN
		SET @action = 'NEW'
	--END

	/* PJH 07/25/17 - 735-1-3024 - Moved from below */
	SET @sales_class_code = @media_type

	SELECT @ok = (SELECT 1 FROM SALES_CLASS WHERE SC_CODE = @sales_class_code)
	IF @ok <> 1 BEGIN
		SET @error_msg_w = 'Invalid Sales Class Code.'
		GOTO ERROR_MSG	
	END

	IF @copy_detail = 1 BEGIN
		--SELECT 'TAX INFO BEFORE' 'Desc', @cl_code '@cl_code'	, @div_code '@div_code'	, @prd_code'@prd_code'	 , @order_type '@order_type'
		--,@tax_code '@tax_code' ,@bill_type_flag '@bill_type_flag', @taxapplyln '@taxapplyln'		,@taxapplynd  '@taxapplynd'
		--,@taxapplync  '@taxapplync'		,@taxapplyai  '@taxapplyai'		,@taxapplyc '@taxapplyc'		,@taxapplyr '@taxapplyr'
		--,@vn_code '@vn_code', @net_gross '@net_gross', @bill_type_flag '@bill_type_flag', @start_date '@start_date'

		SELECT /* GET PRODUCT DEFAULTS */
				--@markup_pct = COALESCE([PRD_COMM],0) ,   --<<<<<<<<<<<< PRODUCT MARKUP
				--@rebate_pct = COALESCE([PRD_REBATE], 0) ,  --<<<<<<<<<<<< PRODUCT REBATE
				@discount_pct = COALESCE([PRD_VEN_DISC], 0) ,  --<<<<<<<<<<<< PRODUCT DISCOUNT
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


	--BILL_TYPE_FLAG = 1 = Comm Only, 2 = Net, 3 = Gross

		SELECT /* GET TAX INFO & VENDOR & PRODUCT */
					@tax_city_pct=TAX_CITY_PCT, @tax_county_pct=TAX_COUNTY_PCT, @tax_state_pct=TAX_STATE_PCT, @tax_resale=TAX_RESALE,
					@taxapplyc=TAXAPPLYC, @taxapplyln=TAXAPPLYLN, @taxapplynd=TAXAPPLYND, @taxapplync=TAXAPPLYNC, @taxapplyr=TAXAPPLYR, @taxapplyai=TAXAPPLYAI,
					@tax_code=TAX_CODE,  
					@comm_pct=COMM_PCT,  --<<<<<<<<<<<< VENDOR COMMISSION
					@markup_pct=MARKUP_PCT,  --<<<<<<<<<<<< PRODUCT MARKUP
					@rebate_pct=COALESCE(REBATE_PCT, @rebate_pct) --<<<<<<<<<<<< PRODUCT REBATE
		FROM advtf_med_get_tax_info(@order_type, @vn_code, @net_gross, @cl_code, @div_code, @prd_code, @bill_type_flag, @start_date, @action)	


	--PJH 02/03/16 - Broke out SC from Product so it casn be last override

		SELECT /* GET SC DEFAULTS */
				@markup_pct = COALESCE([SC_MARKUP], @markup_pct),  --<<<<<<<<<<<< MARKUP
				@rebate_pct = COALESCE([SC_REBATE], @rebate_pct)  --<<<<<<<<<<<< REBATE
		FROM [dbo].[advtf_med_get_sc_defaults] (
				@cl_code	,
				@div_code	,
				@prd_code	 ,
				@order_type ,
				@sales_class_code ) --@media_type , /* SC_CODE */		
		
		/* PJH 07/25/17 - 735-1-3024 - Added */		
		IF @net_gross = 0 /* Net */
			SET @rebate_pct = 0
	END

	/* uf_calc_comm_mu - Get reciprocal PCT */
	IF @net_gross = 1  BEGIN
		SELECT @markup_pct=MARKUP_PCT FROM advtf_med_calc_comm_mu( @net_gross, @comm_pct) --GROSS
	END
	ELSE BEGIN
		SELECT @comm_pct=COMM_PCT FROM advtf_med_calc_comm_mu( @net_gross, @markup_pct) --NET		
	END

	--IF @media_type_in =  'I'
	--	SET @table_prefix = 'INTERNET'
	--	SET @units = 'M'
	--IF @media_type_in =  'O'
	--	SET @table_prefix = 'OUTDOOR'
	--	SET @units = 'M'
	--IF @media_type_in =  'N'
	--	SET @table_prefix = 'NEWSPAPER'
	--	SET @units = 'D'
	--IF @media_type_in =  'M'
	--	SET @table_prefix = 'MAGAZINE'		
	--	SET @units = 'M'
	--IF @media_type_in =  'R'
	--	SET @table_prefix = 'RADIO'
	--	SET @units = @cal_type
	--IF @media_type_in =  'T'
	--	SET @table_prefix = 'TV'
	--	SET @units = @cal_type

	--IF @DEBUG = 1
	--	SELECT @rebate_pct '@rebate_pct - After - advtf_med_calc_comm_mu()', @markup_pct '@markup_pct', @comm_pct '@comm_pct'

	SELECT @ok = (SELECT 1 FROM VENDOR WHERE VN_CODE = @vn_code)
	IF @ok <> 1 BEGIN
		SET @error_msg_w = 'Invalid Vendor Code.'
		GOTO ERROR_MSG	
	END
	
	--SELECT @order_date '@order_date' /* DEBUG */

	IF @order_date IS NOT NULL
		IF ISDATE(@order_date) = 1 AND (@order_date BETWEEN '01/01/2005' AND '01/01/2079')
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
	--IF @markup_pct_or IS NOT NULL BEGIN
	--	SET @markup_pct = @markup_pct_or
	--	SET @markup_pct_override = 1
	--END
	--IF @net_gross = 1 BEGIN--Gross
	--	IF @rebate_pct_or IS NOT NULL BEGIN
	--		SET @rebate_pct = @rebate_pct_or
	--		SET @rebate_pct_override = 1
	--	END
	--	IF @rebate_amt_or IS NOT NULL BEGIN
	--		SET @rebate_amt = @rebate_amt_or
	--		SET @rebate_amt_override = 1
	--	END
	--END ELSE
	--	SET @rebate_pct = 0
	--	SET @rebate_amt = 0

	--IF @comm_pct_or IS NOT NULL BEGIN
	--	SET @comm_pct = @comm_pct_or
	--	SET @comm_pct_override = 1
	--END	
	
	SET @printed = NULL /** CLEAR PRINTED FLAG **/	
	SET @mat_comp = NULL
	
	SET @modified_by = @user_id /* Passed from calling Procedure */
	SET @modified_comments = 'Copied from ' + CAST(@copy_order_nbr AS varchar(20)) + '-' + CAST(@copy_line_nbr AS varchar(20))
	
	/* New Order Nbr for Copy To - Do this after other validation so we don't waste a number */
	IF @copy_hdr = 1 BEGIN
		--IF COALESCE(@order_nbr, 0) = 0 BEGIN
			SET @s_temp =  'ORDER_NBR'

			--SELECT @max_order_nbr = LAST_NBR + 1
			--FROM ASSIGN_NBR
			--WHERE COLUMNNAME = @s_temp;

			--UPDATE ASSIGN_NBR
			--	SET LAST_NBR = @max_order_nbr
			--	WHERE COLUMNNAME =@s_temp
			--	AND LAST_NBR = @max_order_nbr - 1;
				
			UPDATE ASSIGN_NBR
			SET @max_order_nbr = LAST_NBR + 1,
			LAST_NBR = LAST_NBR + 1
			FROM ASSIGN_NBR WHERE COLUMNNAME = @s_temp;
				
			IF @@ERROR > 0 BEGIN
				SELECT @@ERROR 'ERROR NO'
				RETURN
			END	
			
			SET @order_nbr = @max_order_nbr
			
			IF @new_order_nbr IS NULL SET @new_order_nbr = @max_order_nbr
			
			IF @ROW_ID = 1 SET @min_new_order_nbr = @order_nbr
			
			SET @max_new_order_nbr = @order_nbr
			
			--SELECT @order_nbr 'ORDER_NBR'  /*  DEBUG */
			
			IF COALESCE(@order_nbr, 0) = 0 BEGIN
				SET @error_msg_w = 'Error getting the next Order Number.'
				GOTO ERROR_MSG	
			END
		--END 
		--ELSE BEGIN
		--	SET @error_msg_w = 'A new order can''t be created with an existing Order Number.'
		--	GOTO ERROR_MSG	
		--END	

		--SELECT @house_comment = CAST(@link_id AS VARCHAR(20)) + ' imported from ' + @imported_from

		/* @status = original, @is_quote = new */

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

		--SELECT @ret_val '@ret_val' /* DEBUG */
		  
		IF @ret_val <> 0 BEGIN
			SET @error_msg_w = 'Error inserting Order Header values! ' + @ret_val_s
			GOTO ERROR_MSG
		END
		ELSE BEGIN
			SELECT @ret_val_s 'HDR RETURN MSG'
		END
	END
	
	--IF @DEBUG = 1
	--	SET @action = 'NEW'
	
	SET @action = 'NEW'

	IF @copy_detail = 1 BEGIN /* This line does not exist */
		--SET @line_nbr = 1
		SET @rev_nbr = 0
		SET @seq_nbr = 0
		SET @active_rev = 1
		
		--IF @copy_hdr = 1 BEGIN
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
			
			SET @line_nbr = COALESCE(@line_nbr, 1)
		--END
		SET @action = 'NEW'
	END	
	--ELSE BEGIN
	--	SET @active_rev = 1
	--	SET @action = 'REVISE'
	--END
	
	IF @DEBUG = 1
		SELECT 'FROM>>' 'DESC', @copy_order_nbr ORDER_NBR, @copy_line_nbr LINE_NBR, 'TO>>' 'DESC', @order_nbr ORDER_NBR, @line_nbr LINE_NBR /** DEBUG **/
		--SELECT 'TO INFO ' 'DESC', @order_nbr ORDER_NBR, @line_nbr LINE_NBR /** DEBUG **/		
	
	--SELECT @order_type '@order_type', @start_date '@start_date', @end_date '@end_date', @p1_52 '@spots', @cal_type '@cal_type', @units '@units'   /* DEBUG */

	/* TV, Radio Dates & Spots */
	IF @media_type_in IN ('T','R') BEGIN
	
		DECLARE @temp_date smalldatetime, @temp_mmyyyy varchar(6)

		SET @temp_date = @start_date
		
		--IF @DEBUG = 1 SELECT @start_date '<<@start_date', @end_date '@end_date', @cal_type '@cal_type', @date1 '@date1'      /* DEBUG */
		--SELECT @date1 = NULL, @date2 = NULL, @date3 = NULL, @date4 = NULL, @date5 = NULL, @date6 = NULL 
		
		--IF ISDATE(@date1) = 0 BEGIN /* Dates not provided so calculate */
			--PJH 02/06/16 - only allow for DB, skip if BM
			--IF @cal_type IN ('DB') BEGIN
				IF @DEBUG = 1 
					SELECT 'D1' '--', * FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 			
				SELECT @date1 = A.BRD_WEEK_START, @month_nbr = A.BRD_MONTH, @year_nbr = A.BRD_YEAR FROM @brdcast_weeks2 A
				WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
				IF ISDATE(@date1) = 1 SET @date1 = @temp_date /* First date should be the Start Date */

				IF @DEBUG = 1
					SELECT @date1 'Validated - @date1' 

				IF @date1 IS NOT NULL 
					SET @temp_date = DATEADD(d, 7, @temp_date)
				ELSE
					SET @spots1 = 0
				IF @temp_date <= @end_date BEGIN
					IF @DEBUG = 1 
						SELECT 'D2' '--', * FROM @brdcast_weeks2 A
						WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 	
					SELECT @date2 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END AND A.BRD_MONTH = @month_nbr
					IF @date2 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots2 = 0
				END
				IF @temp_date <= @end_date BEGIN
					IF @DEBUG = 1 
						SELECT'D3' '--', * FROM @brdcast_weeks2 A
						WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 	
					SELECT @date3 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END  AND A.BRD_MONTH = @month_nbr
					IF @date3 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots3 = 0
				END
				IF @temp_date <= @end_date BEGIN
					IF @DEBUG = 1 
						SELECT'D4 ' '--', * FROM @brdcast_weeks2 A
						WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 	
					SELECT @date4 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END  AND A.BRD_MONTH = @month_nbr
					IF @date4 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots4 = 0
				END
				IF @temp_date <= @end_date BEGIN
					IF @DEBUG = 1 
						SELECT'D5 ' '--', * FROM @brdcast_weeks2 A
						WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 	
					SELECT @date5 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END  AND A.BRD_MONTH = @month_nbr
					IF @date5 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots5 = 0
				END
				IF @temp_date <= @end_date BEGIN
					IF @DEBUG = 1 
						SELECT'D6' '--', * FROM @brdcast_weeks2 A
						WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 	
					SELECT @date6 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
					WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END  AND A.BRD_MONTH = @month_nbr
					IF @date6 IS NOT NULL 
						SET @temp_date = DATEADD(d, 7, @temp_date)
					ELSE
						SET @spots6 = 0
				END
			--END
		--END
		
		DELETE @bc_spots_table /* Clear any existing data */

		IF @DEBUG = 1 	SELECT 		@order_type '**@order_type',		@start_date '@start_date',		@end_date '@end_date',	 @month_nbr'@month_nbr', @year_nbr '@year_nbr' ,
		@date1 '@date1',		@date2 '@date2',		@date3 '@date3',		@date4 '@date4',		@date5 '@date5',		@date6 '@date6',		@p1_52 '@p1_52',		@cal_type '@cal_type'

		--INSERT INTO @bc_spots_table SELECT * FROM advtf_med_import_brdcast_weeks (
		--@order_type,
		--@start_date,
		--@end_date,
		--@date1,
		--@date2,
		--@date3,
		--@date4,
		--@date5,
		--@date6,
		--@p1_52,
		--@cal_type)

		/* Already have the values we need */
		SET @temp_mmyyyy = RIGHT('0' + CAST(@month_nbr AS varchar(2)), 2) + CAST(@year_nbr AS varchar(4))

		--SELECT @spots1 = BC_SPOTS1, @spots2 = BC_SPOTS2, @spots3 = BC_SPOTS3, @spots4 = BC_SPOTS4, @spots5 = BC_SPOTS5, @spots6 = BC_SPOTS6,
		--		@date1 = BC_DATE1, @date2 = BC_DATE2, @date3 = BC_DATE3, @date4 = BC_DATE4, @date5 = BC_DATE5, @date6 = BC_DATE6,
		--		@temp_mmyyyy = BC_MMYYYY
		--FROM @bc_spots_table

		IF @DEBUG = 1 SELECT * FROM @bc_spots_table  /* DEBUG */
		
		SET @spots7 = 0 /* 7 Not Used */	

		IF @cal_type IN ('BM','DB') BEGIN
			IF @DEBUG = 1
				SELECT @date1 'Validated - @spots w/@dates' 			
			IF COALESCE(@spots1, 0) = 0 SET @date1 = NULL
			IF COALESCE(@spots2, 0) = 0 SET @date2 = NULL
			IF COALESCE(@spots3, 0) = 0 SET @date3 = NULL
			IF COALESCE(@spots4, 0) = 0 SET @date4 = NULL
			IF COALESCE(@spots5, 0) = 0 SET @date5 = NULL
			IF COALESCE(@spots6, 0) = 0 SET @date6 = NULL
			IF COALESCE(@spots7, 0) = 0 SET @date7 = NULL

		END
		
		IF @cal_type = 'BM' BEGIN	
			SET @temp_date = @end_date
			
			SELECT @end_date = MAX(A.BRD_WEEK_END) FROM @brdcast_weeks2 A
			WHERE A.BRD_MONTH = @month_nbr AND A.BRD_YEAR = @year_nbr 
		END	

		IF @cal_type = 'DB' BEGIN	
			SET @month_nbr = @month_nbr
			SET @year_nbr = @year_nbr
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
	
	--SELECT 'BEG DET', @billing_amt '@billing_amt', @line_total '@line_total', @ext_net_amt '@ext_net_amt', @discount_amt '@discount_amt', @netcharge '@netcharge',   /* DEBUG */
	-- @addl_charge '@addl_charge', @comm_amt '@comm_amt', @rebate_amt '@rebate_amt'	
	 
	--IF @DEBUG = 1 	SELECT 		@order_type '***@order_type',		@start_date '@start_date',		@end_date '@end_date',	 @month_nbr'@month_nbr', @year_nbr '@year_nbr' ,
	--	@date1 '@date1',		@date2 '@date2',		@date3 '@date3',		@date4 '@date4',		@date5 '@date5',		@date6 '@date6',		@p1_52 '@p1_52',		@cal_type '@cal_type'		
			
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
		,@reconcile_flag_d  ,@billing_amt  ,@est_nbr  ,@est_line_nbr  ,@est_rev_nbr
		,@ad_number  ,@mat_comp  ,@units  ,@cost_type  ,@cost_rate  ,@net_base_rate  ,@gross_base_rate
		,@programming  ,@start_time  ,@end_time  ,@length  ,@remarks  ,@tag  ,@network_id
		,@headline  ,@size  ,@edition_issue  ,@material  ,@section  ,@rate_card_id  ,@rate_dtl_id
		,@contract_qty  ,@flat_net  ,@flat_gross  ,@prod_charge  ,@prod_desc  ,@color_charge  ,@color_desc
		,@print_columns  ,@print_inches  ,@print_lines  ,@np_circulation  ,@print_quantity
		,@bleed_pct  ,@bleed_amt  ,@position_pct  ,@position_amt  ,@premium_pct  ,@premium_amt
		,@flat_netcharge  ,@flat_addl_charge  ,@flat_discount_amt  ,@production_size  ,@size_code
		,@mg_circulation  ,@o_type  ,@url_location  ,@copy_area  ,@rate_card  ,@rate_type  ,@rate_desc
		,@proj_impressions  ,@guaranteed_impress ,@act_impressions  ,@target_audience  ,@creative_size
		,@placement_1  ,@placement_2 , @prc_status
		,NULL  
		,NULL  
		,NULL  
		,NULL  
		,NULL  
		,NULL
		,NULL --@package_parent
		,NULL --@ad_server_placement_group_id
		--PJH 08/18/17 - Added
		,@cable_network_station_code 
		,@daypart_id 
		,@added_value 
		,@bookend 
		,NULL --@link_line_number
		,NULL --@is_quote
		,NULL --@override_non_resale_amt
		,NULL --@override_rates

		--PJH 12/06/18 - Added @line_market_code, @ad_server_id
		,NULL --@line_ad_server_id
		,@line_market_code

		,0 --@strata_net_calc

		,@channel --PJH 02/14/20 - Added @channel & @tactic
		,@tactic

	IF @ret_val <> 0 BEGIN
		SET @error_msg_w = 'Error updating Order Detail values! ' + @ret_val_s
		GOTO ERROR_MSG
	END 

	--SELECT @air_date '@air_date', @instructions '@instructions', @order_copy '@order_copy', @matl_notes '@matl_notes', @position_info '@position_info',
	--@close_info '@close_info', @rate_info '@rate_info', @misc_info '@misc_info', @media_type_in '@media_type_in', @dtl_cmnt_exists '@dtl_cmnt_exists'        /* DEBUG */
	
	IF @media_type_in =  'N' BEGIN
		SELECT @dtl_cmnt_exists = 1 
					,@instructions = [INSTRUCTIONS]
					,@order_copy = [ORDER_COPY]
					,@matl_notes = [MATL_NOTES]
					,@position_info = [POSITION_INFO]
					,@close_info = [CLOSE_INFO]
					,@rate_info = [RATE_INFO]
					,@misc_info = [MISC_INFO]
					,@in_house_cmts = [IN_HOUSE_CMTS]
		FROM [dbo].[NEWSPAPER_COMMENTS] 
		WHERE [ORDER_NBR]= @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr
		
		IF @dtl_cmnt_exists = 1 BEGIN
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
		/* Remove any rows created by the revise detail procedure */
		DELETE FROM [dbo].[NEWSPAPER_OTH_CHGS] 
		WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		/* Copy all exisiting charges from the original order/line */
		INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
									([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
									,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
									,[REVISED_DATE], [REVISED_BY])
		SELECT @order_nbr, @line_nbr, [CHG_TYPE], [CHG_DESC]
									,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
									,[REVISED_DATE], [REVISED_BY]
		FROM [dbo].[NEWSPAPER_OTH_CHGS]
		WHERE [ORDER_NBR]= @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr
	END
	ELSE IF @media_type_in =  'M' BEGIN
		SELECT @dtl_cmnt_exists = 1 
					,@instructions = [INSTRUCTIONS]
					,@order_copy = [ORDER_COPY]
					,@matl_notes = [MATL_NOTES]
					,@position_info = [POSITION_INFO]
					,@close_info = [CLOSE_INFO]
					,@rate_info = [RATE_INFO]
					,@misc_info = [MISC_INFO]
					,@in_house_cmts = [IN_HOUSE_CMTS]		
		FROM [dbo].[MAGAZINE_COMMENTS] 
		WHERE [ORDER_NBR]=  @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr
		
		IF @dtl_cmnt_exists = 1 BEGIN
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
	END
	ELSE IF @media_type_in =  'I' BEGIN
		SELECT @dtl_cmnt_exists = 1 					
					,@instructions = [INSTRUCTIONS]
					,@order_copy = [ORDER_COPY]
					,@matl_notes = [MATL_NOTES]
					,@misc_info = [MISC_INFO]
		FROM [dbo].[INTERNET_COMMENTS] 
		WHERE [ORDER_NBR]= @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr
		
		IF @dtl_cmnt_exists = 1 BEGIN
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
		--PJH 01/15/21 - Do not copy forward
		--PJH 12/11/18 - Added INTERNET_PACKAGE_DETAIL
		--INSERT INTO INTERNET_PACKAGE_DETAIL
		--	  (ORDER_NBR
		--	  ,LINE_NBR
		--	  ,REV_NBR
		--	  ,SEQ_NBR
		--	  ,ACTIVE_REV
		--	  ,AD_SIZE_CODE
		--	  ,AD_SERVER_ID
		--	  ,AD_SERVER_PLACEMENT_ID
		--	  ,AD_SERVER_CREATED_BY
		--	  ,AD_SERVER_CREATED_DATETIME
		--	  ,AD_SERVER_LAST_MODIFIED_BY
		--	  ,AD_SERVER_LAST_MODIFIED_DATETIME)
		--SELECT @order_nbr
		--	  ,@line_nbr
		--	  ,0
		--	  ,0
		--	  ,ACTIVE_REV
		--	  ,AD_SIZE_CODE
		--	  ,NULL
		--	  ,NULL
		--	  ,NULL
		--	  ,NULL
		--	  ,NULL
		--	  ,NULL
		--FROM INTERNET_PACKAGE_DETAIL 
		--WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND ACTIVE_REV = 1
	END
	ELSE IF @media_type_in =  'O' BEGIN
		SELECT @dtl_cmnt_exists = 1 
					,@instructions = [INSTRUCTIONS]
					,@order_copy = [ORDER_COPY]
					,@matl_notes = [MATL_NOTES]
					,@misc_info = [MISC_INFO]
		FROM [dbo].[OUTDOOR_COMMENTS] 
		WHERE  [ORDER_NBR]= @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr
		
		IF @dtl_cmnt_exists = 1 BEGIN
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
	END
	ELSE IF @media_type_in =  'T' BEGIN
		SELECT @dtl_cmnt_exists = 1 
					,@instructions = [INSTRUCTIONS]
					,@order_copy = [ORDER_COPY]
					,@matl_notes = [MATL_NOTES]
					,@position_info = [POSITION_INFO]
					,@close_info = [CLOSE_INFO]
					,@rate_info = [RATE_INFO]
					,@misc_info = [MISC_INFO]
					,@in_house_cmts = [IN_HOUSE_CMTS]				
		FROM [dbo].[TV_COMMENTS] 
		WHERE  [ORDER_NBR]= @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr
				
		IF @dtl_cmnt_exists = 1 BEGIN
			INSERT INTO [dbo].[TV_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[POSITION_INFO]
					   ,[CLOSE_INFO]
					   ,[RATE_INFO]					   
					   ,[MATL_NOTES]
					   ,[MISC_INFO]
					   ,[IN_HOUSE_CMTS] )
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@position_info 
					,@close_info 
					,@rate_info 					
					,@matl_notes 
					,@misc_info
					,@in_house_cmts )
		END 
	END
	ELSE IF @media_type_in =  'R' BEGIN
		SELECT @dtl_cmnt_exists = 1 
					,@instructions = [INSTRUCTIONS]
					,@order_copy = [ORDER_COPY]
					,@matl_notes = [MATL_NOTES]
					,@position_info = [POSITION_INFO]
					,@close_info = [CLOSE_INFO]
					,@rate_info = [RATE_INFO]
					,@misc_info = [MISC_INFO]
					,@in_house_cmts = [IN_HOUSE_CMTS]				
		FROM [dbo].[RADIO_COMMENTS] 
		WHERE  [ORDER_NBR]= @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr
		
		IF @dtl_cmnt_exists = 1 BEGIN
			INSERT INTO [dbo].[RADIO_COMMENTS]
					   ([ORDER_NBR]
					   ,[LINE_NBR]
					   ,[INSTRUCTIONS]
					   ,[ORDER_COPY]
					   ,[POSITION_INFO]
					   ,[CLOSE_INFO]
					   ,[RATE_INFO]					   
					   ,[MATL_NOTES]
					   ,[MISC_INFO]
					   ,[IN_HOUSE_CMTS] )
				 VALUES (
					@order_nbr 
					,@line_nbr 
					,@instructions 
					,@order_copy 
					,@position_info 
					,@close_info 
					,@rate_info 					
					,@matl_notes 
					,@misc_info
					,@in_house_cmts )
		END 
	END

	NEXT_ROW:

	SET @ROW_ID = @ROW_ID + 1

END /* While */

IF @@TRANCOUNT > 0
	IF @DEBUG = 1 BEGIN
		SELECT 'ROLLBACK' 'DEBUG', @order_type '@order_type'
		
		SELECT '*' '-', * FROM  @brdcast_weeks2 WHERE BRD_YEAR = 2013

		IF @order_type = 'NP' BEGIN
			SELECT 'N-HEADER' 'DESC', *				
			FROM NEWSPAPER_HEADER A WHERE ORDER_NBR >= @new_order_nbr
			SELECT 'DETAIL' 'DESC', * FROM NEWSPAPER_DETAIL WHERE ORDER_NBR >= @new_order_nbr
			ORDER BY ORDER_NBR, LINE_NBR
			SELECT 'CMTS' 'DESC', * FROM NEWSPAPER_COMMENTS WHERE ORDER_NBR >= @new_order_nbr
		END
		IF @order_type = 'MA' BEGIN 
			SELECT 'M-HEADER' 'DESC', *
			FROM MAGAZINE_HEADER A WHERE ORDER_NBR >= @new_order_nbr
			SELECT 'DETAIL' 'DESC', * FROM MAGAZINE_DETAIL WHERE ORDER_NBR >= @new_order_nbr
			ORDER BY ORDER_NBR, LINE_NBR
		END
		IF @order_type = 'IN' BEGIN
			SELECT 'I-HEADER' 'DESC', *	 
			  FROM INTERNET_HEADER A WHERE ORDER_NBR >= @new_order_nbr
			SELECT 'DETAIL' 'DESC', * FROM INTERNET_DETAIL WHERE ORDER_NBR >= @new_order_nbr
			ORDER BY ORDER_NBR, LINE_NBR
		END
		IF @order_type = 'OD' BEGIN 
			SELECT 'O-HEADER' 'DESC', *	 
			  FROM OUTDOOR_HEADER A WHERE ORDER_NBR >= @new_order_nbr
			SELECT 'DETAIL' 'DESC', * FROM OUTDOOR_DETAIL WHERE ORDER_NBR >= @new_order_nbr
			ORDER BY ORDER_NBR, LINE_NBR
		END
		IF @order_type = 'TV' BEGIN 
			SELECT 'O-HEADER' 'DESC', *
			FROM TV_HDR WHERE ORDER_NBR >= @new_order_nbr
			SELECT 'DETAIL' 'DESC', * FROM TV_DETAIL WHERE ORDER_NBR >= @new_order_nbr
			ORDER BY ORDER_NBR, LINE_NBR
			SELECT 'CMTS' 'DESC', * FROM TV_COMMENTS WHERE ORDER_NBR >= @new_order_nbr
		END
		IF @order_type = 'RA' BEGIN 
			SELECT 'O-HEADER' 'DESC', *
			FROM RADIO_HDR A WHERE ORDER_NBR >= @new_order_nbr
			SELECT 'DETAIL' 'DESC', * FROM RADIO_DETAIL WHERE ORDER_NBR >= @new_order_nbr
			ORDER BY ORDER_NBR, LINE_NBR
			SELECT 'CMTS' 'DESC', * FROM RADIO_COMMENTS WHERE ORDER_NBR >= @new_order_nbr
		END
		--SELECT POST_FLAG, * FROM @tmp_orders
		--SELECT POST_FLAG, * FROM @tmp_orders2
		ROLLBACK TRAN --TP1
		SET @error_msg_w = ' DEBUG MODE: '
		SET @error_msg_w += CAST(@ROW_COUNT AS VARCHAR(10)) + ' Order/Lines copied. Minimum New Order Number (' + CAST(@min_new_order_nbr AS VARCHAR(10)) + '). Maximum New Order Number (' + CAST(@max_new_order_nbr AS VARCHAR(10)) + ').'
		GOTO ERROR_MSG
		--RETURN
	END
	ELSE
		COMMIT TRAN --TP1
		SET @ret_val_s = CAST(@ROW_COUNT AS VARCHAR(10)) + ' Order/Lines copied. Minimum New Order Number (' + CAST(@min_new_order_nbr AS VARCHAR(10)) + '). Maximum New Order Number (' + CAST(@max_new_order_nbr AS VARCHAR(10)) + ').'

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
			
			SET @ret_val_s = @error_msg_w
			
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		SELECT 'PROCESS ERROR ROLLBACK', @@TRANCOUNT '@@TRANCOUNT'  /* DEBUG */	
		ROLLBACK TRAN --TP1
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE(),
					@ret_val=ERROR_NUMBER();
					
	SET @ret_val_s = @ErMessage
	
	SELECT 	@ret_val 'ERROR_NBR', @ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */	

END CATCH

RETURN

GO

GRANT EXECUTE ON [advsp_revise_order_copy] TO PUBLIC
GO