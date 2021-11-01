IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_revise_order_media_mgr]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_revise_order_media_mgr]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_revise_order_media_mgr] 
	@user_id varchar(100),
	@order_nbr_in integer,
	@line_nbr_in smallint,
	@order_type_in varchar(2),
	@new_amount decimal(16,4),
	@new_amt_source smallint, -- 0: Do Not Revise Amount, 1: Actual Amount Posted, 2: Vendor Collected
	@calculate_only bit,
	@new_addl_charge decimal(14,2),

	@force_revision bit,
	@new_order_description varchar(40),--h
	@new_client_po_number varchar(25),--h
	@new_buyer varchar(40),--h
	@new_buyer_emp_code varchar(6),--h
	@new_start_date smalldatetime,--h
	@new_end_date smalldatetime,--h
	@new_close_date smalldatetime,--d
	@new_matl_close_date smalldatetime,--d
	@new_ext_close_date smalldatetime,--d
	@new_ext_matl_date smalldatetime,--d
	@new_date_to_bill smalldatetime,--d
	@new_ad_number varchar(30),--d
	@new_campaign_id int,--h
	@new_job_number int,--d
	@new_job_component_nbr smallint,--d
	@new_market_code varchar(10),--h
	@new_markup_pct decimal(7,3), --d
	@new_rebate_pct decimal(7,3), --d
	--Broadcast Order Changes:
	@new_programming varchar(50), --d
	@new_remarks varchar(254), --d
	@new_start_time varchar(10), --d
	@new_end_time varchar(10), --d
	@new_length smallint, --d
	--Non Broadcast Order Changes (N, M, O, I)
	@new_headline varchar(60), --d
	@new_ad_size_code varchar(6), --d
	@new_material varchar(60), --d
	--@new_ad_size_description varchar(60), --d
	--Internet Order Changes
	@new_internet_placement1 varchar(256), --d
	@new_internet_placement2 varchar(160), --d
	@new_internet_type varchar(6), --d
	@new_url varchar(60), --d
	@new_target_audience varchar(60), --d
	--Magazine Order Changes
	@new_edition_issue varchar(30), --d NP ALSO
	@new_production_size varchar(30), --d NP ALSO
	@new_mg_circulation int, --d
	--Newspaper Order Changes
	@new_section varchar(30), --d
	@new_print_columns decimal(6,2), --d
	@new_print_inches decimal(6,2), --d
	@new_print_lines decimal(11,2), --d
	@new_rate_type varchar(3), --d
	@new_np_circulation int,
	--Out of Home Order Changes
	@new_copy_area varchar(40), --d
	@new_location varchar(60), --d
	@new_outdoor_type varchar(6), --d

	@new_rate decimal(16,4),  --(will be net or gross depending on the net/gross flag)
	@new_netcharge decimal(14,2), -- this is a production charge that is similar to Additional Amount in that it is not rate-related but changes the order total.  This is an amount due to the vendor.
	@new_bill_coop_code varchar(6),

	-- Quantities that will trigger changes to all amounts:
	--@new_spots smallint,  09-24-2019 MJC REMOVED!
	@new_cost_type varchar(3), --d  COST_TYPE
	@new_proj_impressions int, --d
	@new_guaranteed_impress int, --d
	@new_actual_impressions int, --d

	@new_mat_comp_date smalldatetime,--d

	@rate_out decimal(16,4) OUTPUT,
	@nonresale_tax_out decimal(16,2) OUTPUT,
	@rebate_amount_out decimal(16,2) OUTPUT,
	@commission_amount_out decimal(16,2) OUTPUT,
	@billable_amount_out decimal(16,2) OUTPUT,
	@unbilled_amount_out decimal(16,2) OUTPUT,
	@actual_impressions_out int OUTPUT,
	@net_amount_out decimal(16,2) OUTPUT,
	@gross_amount_out decimal(16,2) OUTPUT,
	@netcharge_out decimal(16,2) OUTPUT,
	@discount_out decimal(16,2) OUTPUT,
	@end_date_out smalldatetime OUTPUT,
	@ret_val integer OUTPUT,
	@ret_val_s varchar(max) OUTPUT,
	@debug bit = 0

AS

/*
PJH 03/10/16 - Changed @max_order_nbr from smallint to int
MJC 03/28/16 - when setting @is_billed, include ACTIVE_REV = 1
MJC 06/17/16 - when updating to vendor collected for Newspaper (@new_amt_source=2) that is CPI, set @SumQTY = COALESCE(@print_columns * @print_inches,0)
MJC 10/21/16 - we don't want to update the _COMMENTS tables
MJC 10/21/16 - updating rate to 0 for magazine was not setting the @flat_gross - it was setting @flat_net incorrectly
MJC 01/16/17 - added @new_buyer_emp_code
MJC 01/21/19 - change the way @net_amount gets set when order is gross
PJH 01/30/19 - Change how to calc net rate - @strata_net_calc
PJH 03/22/19 - Added @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
*/

--all HEADER

--SET @new_spots = COALESCE(@new_spots,1)
--IF @new_spots <= 0 SET @new_spots = 1

DECLARE
	@action varchar(10),
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
	@status varchar(3),
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
	@ad_server_placement_id bigint,
	@ad_server_created_by varchar(100),
	@ad_server_created_datetime smalldatetime,
	@ad_server_last_modified_by varchar(100),
	@ad_server_last_modified_datetime smalldatetime,
	@ad_server_placement_manual bit,
	--coments & status
	@is_quote smallint,
	@prc_status smallint,
	--@instructions varchar(max),
	--@order_copy varchar(max),
	--@matl_notes varchar(max),
	--@position_info varchar(max),
	--@close_info varchar(max),
	--@rate_info varchar(max),
	--@misc_info varchar(max),
	--@in_house_cmts varchar(max),

	--product defaults
	@prd_bill_type_flag smallint,

	--PRINT_ORDERS overrides
	@comm_pct_or decimal (14, 6),
	@markup_pct_or decimal (14, 6),
	@rebate_pct_or decimal (14, 6),
	@rebate_amt_or decimal (14, 2),

	@package_parent bit,
	@ad_server_placement_group_id bigint,
	@cable_network_station_code varchar(10), 
	@daypart_id int,
	@added_value bit,
	@bookend bit,
	@link_line_number int,
	@override_non_resale_amt decimal (14, 2),
	@override_rates bit = 0

DECLARE @tmp_orders TABLE (
	[RowID] [int] IDENTITY(1,1),
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [int] NOT NULL, 
	[MEDIA_TYPE] [varchar](3) NOT NULL
)

DECLARE @sql varchar(500), @param_def varchar(500), @error_msg_w varchar(max)
DECLARE @rr_msg_w varchar(100), @goto_id varchar(50), @s_temp varchar(250)
DECLARE @max_order_nbr int, @ok smallint, @table_prefix varchar(50)
DECLARE @media_interface varchar(3), @media_interface_in varchar(3), @imported_from varchar(30)

DECLARE @media_type_in varchar(2)
DECLARE @dtl_cmnt_exists int
DECLARE @copy_order_nbr int, @copy_line_nbr int, @copy_hdr int, @copy_detail int
DECLARE @copy_order_nbr_prev int, @copy_line_nbr_prev int
DECLARE @order_type_chg int
DECLARE @rebate_amt_override smallint, @rebate_pct_override smallint, @markup_pct_override smallint, @comm_pct_override smallint
DECLARE @sales_class_code varchar(10), @rev_nbr_import smallint

DECLARE @p1_52 varchar(254), @spots int, @line_comment varchar(254)--, @flight_type varchar(1)

DECLARE @delete_order int, @cal_type varchar(2), @air_date smalldatetime--, @net_gross_flag int

DECLARE @new_order_nbr int, @min_new_order_nbr int, @max_new_order_nbr int

DECLARE @ROW_COUNT int, @ROW_ID int
DECLARE @RC int, @RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int

DECLARE @SumQTY decimal(10,2),
		@ar_inv_nbr	int,
		@billed_amount decimal(18,2),
		@billed_amount_resale_tax decimal(18,2),
		@is_billed bit

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

DECLARE @strata_net_calc bit = 0

BEGIN TRY

/********/
--GOTO ERROR_MSG
/********/
	
SET @order_type	 = @order_type_in
SET @override_rates = 0
SET @is_billed = 0
SET @action = 'UPDATE'

AFTER_SET_DATES:

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

SET NOCOUNT OFF

IF @order_type = 'NP' BEGIN
	SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
			@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.NEWSPAPER_HEADER
	WHERE ORDER_NBR=@order_nbr_in;	
			
	--SELECT @line_cancelled = [LINE_CANCELLED] FROM dbo.NEWSPAPER_DETAIL
	--WHERE ORDER_NBR=@order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1;
END
ELSE IF @order_type = 'MA' BEGIN
	SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
			@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.MAGAZINE_HEADER
	WHERE ORDER_NBR=@order_nbr_in;	
END
ELSE IF @order_type = 'IN' BEGIN
	SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
			@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.INTERNET_HEADER
	WHERE ORDER_NBR=@order_nbr_in;	
END
ELSE IF @order_type = 'OD' BEGIN
	SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
			@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.OUTDOOR_HEADER
	WHERE ORDER_NBR=@order_nbr_in;	
END
ELSE IF @order_type = 'TV'BEGIN
	SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
			@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.TV_HDR
	WHERE ORDER_NBR=@order_nbr_in;	
END				
ELSE IF @order_type = 'RA' BEGIN
	SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
			@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.RADIO_HDR
	WHERE ORDER_NBR=@order_nbr_in;	
END

IF @order_nbr_in IS NOT NULL BEGIN
	IF @order_type IN ('NP')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM NEWSPAPER_DETAIL A JOIN NEWSPAPER_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr_in AND A.LINE_NBR = @line_nbr_in AND A.ACTIVE_REV = 1 AND COALESCE(A.LINE_CANCELLED, 0) = 0
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('MA')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM MAGAZINE_DETAIL A JOIN MAGAZINE_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr_in AND A.LINE_NBR = @line_nbr_in AND A.ACTIVE_REV = 1 AND COALESCE(A.LINE_CANCELLED, 0) = 0
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('IN')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM INTERNET_DETAIL A JOIN INTERNET_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr_in AND A.LINE_NBR = @line_nbr_in AND A.ACTIVE_REV = 1 AND COALESCE(A.LINE_CANCELLED, 0) = 0
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('OD')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM OUTDOOR_DETAIL A JOIN OUTDOOR_HEADER B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr_in AND A.LINE_NBR = @line_nbr_in AND A.ACTIVE_REV = 1 AND COALESCE(A.LINE_CANCELLED, 0) = 0
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('RA')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM RADIO_DETAIL A JOIN RADIO_HDR B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr_in AND A.LINE_NBR = @line_nbr_in AND A.ACTIVE_REV = 1 AND COALESCE(A.LINE_CANCELLED, 0) = 0
		ORDER BY A.ORDER_NBR, A. LINE_NBR
	ELSE IF @order_type IN ('TV')
		INSERT INTO @tmp_orders
		SELECT A.ORDER_NBR, A. LINE_NBR, @order_type
			   FROM TV_DETAIL A JOIN TV_HDR B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr_in AND A.LINE_NBR = @line_nbr_in AND A.ACTIVE_REV = 1 AND COALESCE(A.LINE_CANCELLED, 0) = 0
		ORDER BY A.ORDER_NBR, A. LINE_NBR		
END	

--IF @debug = 1 SELECT * FROM @tmp_orders /* DEBUG */	

SELECT * FROM @tmp_orders /* DEBUG */	

SET @ROW_COUNT = @@ROWCOUNT

IF @ROW_COUNT = 0 BEGIN
	SET @ret_val = -1
	SET @ret_val_s = 'Order/line ' + CAST(@order_nbr_in as varchar) + '/' + CAST(@line_nbr_in as varchar) + ' has already been cancelled, please refresh your data.'
	GOTO ENDIT
END

SET @order_type_chg = 0

SET NOCOUNT ON

IF @calculate_only = 0
	BEGIN TRAN --TP1

--'Order file(s) created, [Direct Post], use the Media Generic Import to finalize order creation.'

IF @order_type NOT IN ('NP','MA','IN','OD','TV','RA') BEGIN 
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

SET @order_nbr = @order_nbr_in 
SET @line_nbr = @line_nbr_in 
SET @copy_hdr = 1
SET @copy_detail = 1

WHILE @ROW_ID <= @ROW_COUNT BEGIN

	SELECT @copy_order_nbr = [ORDER_NBR], @copy_line_nbr = [LINE_NBR]
	FROM @tmp_orders
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
			SELECT
				@order_desc = [ORDER_DESC], @cl_code = [CL_CODE], @div_code = [DIV_CODE], @prd_code = [PRD_CODE],
				@office_code = [OFFICE_CODE], @cmp_code = [CMP_CODE], @vn_code = [VN_CODE],	@vr_code = [VR_CODE], @vr_code2 = [VR_CODE2],
				@client_po = [CLIENT_PO], @client_ref = [CLIENT_REF], @status = [STATUS], @order_date = [ORDER_DATE], @buyer = [BUYER],
				@order_comment = [ORDER_COMMENT], @house_comment = [HOUSE_COMMENT],	@pub_station = [PUB], @rep1 = [REP1], @rep2 = [REP2],
				@bill_coop_code = [BILL_COOP_CODE], @ord_process_contrl = [ORD_PROCESS_CONTRL], @market_code = [MARKET_CODE],
				@start_date = [START_DATE], @end_date = [END_DATE],	@units = [UNITS], @nbr_of_units = [NBR_OF_UNITS], @net_gross = [NET_GROSS],
				@create_date = [CREATE_DATE], @cancelled = [CANCELLED], @cancelled_by = [CANCELLED_BY], @cancelled_date = [CANCELLED_DATE],
				@modified_by = [MODIFIED_BY], @modified_date = [MODIFIED_DATE], @modified_comments = [MODIFIED_COMMENTS], 
				@revised_flag = [REVISED_FLAG], @link_id = [LINK_ID], @reconcile_flag = [RECONCILE_FLAG], @cmp_identifier = [CMP_IDENTIFIER],
				@printed = [PRINTED], @order_accepted = [ORDER_ACCEPTED], @fiscal_period_code = [FISCAL_PERIOD_CODE], @locked = [LOCKED],
				@locked_by = [LOCKED_BY], @bcc_id = [BCC_ID], @buyer_emp_code = BUYER_EMP_CODE
			FROM NEWSPAPER_HEADER
			WHERE ORDER_NBR = @copy_order_nbr	
		END	

		IF @copy_detail = 1 BEGIN
			SELECT @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @active_rev=[ACTIVE_REV], @link_detid=[LINK_DETID],@start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
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
					   @date_to_bill=[DATE_TO_BILL], --[BILLING_USER], 
					   @ar_inv_nbr = [AR_INV_NBR], --[AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
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
					   @flat_netcharge=[FLAT_NETCHARGE], @flat_addl_charge=[FLAT_ADDL_CHARGE], 
					   @flat_discount_amt=[FLAT_DISCOUNT_AMT], @production_size=[PRODUCTION_SIZE], @mat_comp=[MAT_COMP], @size_code=[SIZE_CODE], 
					   @cost_type=[COST_TYPE], @cost_rate=[COST_RATE], @rate_type=[RATE_TYPE], @np_circulation=[NP_CIRCULATION], @print_quantity=[PRINT_QUANTITY]
			FROM [dbo].[NEWSPAPER_DETAIL] 
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1
		END
		
		SELECT @billed_amount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ),
			@billed_amount_resale_tax = COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
		FROM dbo.[NEWSPAPER_DETAIL] d   
		WHERE d.ORDER_NBR = @copy_order_nbr 
		AND d.LINE_NBR = @copy_line_nbr 
		AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.NEWSPAPER_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND AR_INV_NBR IS NOT NULL AND ACTIVE_REV = 1)
			SET @is_billed = 1
		
		/* DETAIL OVERRIDES */
		SET @color_charge = 0  -- we ALWAYS need to do this since we are eliminating the rate charges from NEWSPAPER_OTH_CHGS and calculating the rate on the way in

		IF @force_revision = 1 OR (@is_billed = 1 AND (@cost_rate <> @new_rate 
														OR @netcharge <> @new_netcharge 
														OR @cost_type <> @new_cost_type 
														OR @addl_charge <> @new_addl_charge
														OR @rate_type <> @new_rate_type
														OR (@cost_type = 'CPI' AND (@print_columns <> @new_print_columns OR @print_inches <> @new_print_inches))
														OR (@cost_type = 'CPL' AND @print_lines <> @new_print_lines)
														OR (@cost_type = 'CPM' AND @print_lines <> @new_print_lines)
														))
			SET @action = 'REVISE'
		
		SET @addl_charge = @new_addl_charge
		SET @flat_addl_charge = @new_addl_charge

		SET @netcharge = @new_netcharge  -- this is a production charge that is similar to Additional Amount in that it is not rate-related but changes the order total.  This is an amount due to the vendor.
		SET @flat_netcharge = @new_netcharge

		SET @close_date = @new_close_date
		set @matl_close_date = @new_matl_close_date
		SET @ext_close_date = @new_ext_close_date
		SET @ext_matl_date = @new_ext_matl_date
		SET @date_to_bill = @new_date_to_bill
		SET @mat_comp = @new_mat_comp_date

		SET @ad_number = @new_ad_number
		SET @job_number = @new_job_number
		SET @job_component_nbr = @new_job_component_nbr
		SET @markup_pct = @new_markup_pct
		SET @rebate_pct = @new_rebate_pct
		
		--Non Broadcast Order Changes (N, M, O, I)
		SET @headline = @new_headline
		SET @size_code = @new_ad_size_code
		SET @material = @new_material

		IF @new_ad_size_code IS NOT NULL
			SELECT @size = SIZE_DESC
			FROM dbo.AD_SIZE 
			WHERE MEDIA_TYPE = 'N'
			AND SIZE_CODE = @new_ad_size_code

		--SET @size = @new_ad_size_description

		--Newspaper Order Changes
		SET @edition_issue = @new_edition_issue
		SET @production_size = @new_production_size
		SET @section = @new_section
		SET @print_columns = @new_print_columns
		SET @print_inches = @new_print_inches
		SET @print_lines = @new_print_lines
		SET @rate_type = @new_rate_type
		SET @np_circulation = @new_np_circulation

		SET @cost_type = @new_cost_type  --d  COST_TYPE (I,N)

		IF @new_amt_source <> 0 BEGIN -- back calc rate
			
			SET @override_rates = 1

			IF @new_amt_source = 1 BEGIN
				SELECT @SumQTY = SUM(PRINT_LINES)
				FROM dbo.AP_NEWSPAPER 
				WHERE ORDER_NBR = @order_nbr_in 
				AND ORDER_LINE_NBR = @line_nbr_in 
				AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
				AND EXISTS(SELECT 1 FROM dbo.NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr_in AND LINE_NBR = @line_nbr_in AND COST_TYPE <> 'CPI' AND COST_TYPE <> 'NA')

				IF COALESCE(@SumQTY, 0) = 0
					IF @print_lines <> 0 
						SET @SumQTY = @print_lines
		
				IF COALESCE(@SumQTY, 0) = 0 
					SET @SumQTY = 1

				IF @cost_type <> 'CPI'
					SET @print_lines = @SumQTY 

				SELECT
					--when @net_gross=1 (gross order) set @new_amount = EXT_NET_AMT * 17.647 %
					--@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( GROSS_AMT, 0.00 )), 0.00 ) END
					@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) + 
					((SELECT COALESCE(MARKUP_PCT / 100, .17647) FROM dbo.NEWSPAPER_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND ACTIVE_REV = 1) * COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ) END
				FROM dbo.AP_NEWSPAPER
				WHERE ORDER_NBR = @copy_order_nbr
				AND ORDER_LINE_NBR = @copy_line_nbr
				AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

				IF @net_gross = 0 
					IF @cost_type <> 'NA' BEGIN
						IF @cost_type = 'CPM' AND @rate_type = 'CPM' BEGIN
							SET @flat_net = @new_amount / @SumQTY * 1000
							SET @cost_rate = @new_amount / @SumQTY * 1000
						END ELSE BEGIN
							SET @flat_net = @new_amount / @SumQTY
							SET @cost_rate = @new_amount / @SumQTY
						END
					END ELSE BEGIN
						SET @flat_net = @new_amount
					END
			
				ELSE
					IF @cost_type <> 'NA' BEGIN
						IF @cost_type = 'CPM' AND @rate_type = 'CPM' BEGIN
							SET @flat_gross = ROUND( @new_amount / @SumQTY * 1000, 2)
							SET @cost_rate = ROUND( @new_amount / @SumQTY * 1000, 2)
						END ELSE BEGIN
							SET @flat_gross = ROUND( @new_amount / @SumQTY, 2)
							SET @cost_rate = ROUND( @new_amount / @SumQTY, 2)
						END
					END ELSE BEGIN
						SET @flat_gross = ROUND(@new_amount, 2)
					END
			END ELSE BEGIN -- @new_amt_source = 2
				--MJC 06/17/16 - when updating to vendor collected for Newspaper (@new_amt_source=2) that is CPI, set @SumQTY = COALESCE(@print_columns * @print_inches,0)
				IF @cost_type = 'CPI'
					SET @SumQTY = COALESCE(@print_columns * @print_inches,0)
				ELSE
					SET @SumQTY = COALESCE(@print_lines, 0)

				IF @SumQTY = 0 
					SET @SumQTY = 1
		
				IF @cost_type <> 'NA' BEGIN
					IF @cost_type = 'CPM' AND @rate_type = 'CPM' BEGIN
						SET @flat_net = @new_amount / @SumQTY * 1000
						SET @cost_rate = @new_amount / @SumQTY * 1000
					END ELSE BEGIN
						SET @flat_net = @new_amount / @SumQTY
						SET @cost_rate = @new_amount / @SumQTY
					END
				END ELSE BEGIN
					SET @flat_net = @new_amount
				END
				SET @flat_gross = ROUND( @flat_net + (@flat_net * @markup_pct/100), 2)
			END
		END ELSE BEGIN --set rate (will be net or gross depending on the net/gross flag)
			SET @cost_rate = @new_rate
			IF @net_gross = 0 
				SET @flat_net = @new_rate
			ELSE
				SET @flat_gross = @new_rate
		END

		IF @new_amt_source = 1 BEGIN
			
			SET @color_charge = 0
			SET @prod_charge = 0

			SELECT
				@flat_netcharge = COALESCE( SUM( COALESCE( NETCHARGES, 0.00 )), 0.00 ),
				@flat_discount_amt = COALESCE( SUM( COALESCE( DISCOUNT_LN, 0.00 )), 0.00 ),
				@override_non_resale_amt = COALESCE( SUM( COALESCE( VENDOR_TAX, 0.00 )), 0.00 )
			FROM dbo.AP_NEWSPAPER
			WHERE ORDER_NBR = @copy_order_nbr
			AND ORDER_LINE_NBR = @copy_line_nbr
			AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

		END

		IF @new_amt_source = 2 BEGIN

			SET @override_non_resale_amt = 0
			SET @flat_netcharge = 0
			SET @flat_discount_amt = 0

		END

	END /* End NP */
	
	IF @media_type_in = 'M' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			SELECT
				@order_desc = [ORDER_DESC], @cl_code = [CL_CODE], @div_code = [DIV_CODE], @prd_code = [PRD_CODE],
				@office_code = [OFFICE_CODE], @cmp_code = [CMP_CODE], @vn_code = [VN_CODE],	@vr_code = [VR_CODE], @vr_code2 = [VR_CODE2],
				@client_po = [CLIENT_PO], @client_ref = [CLIENT_REF], @status = [STATUS], @order_date = [ORDER_DATE], @buyer = [BUYER],
				@order_comment = [ORDER_COMMENT], @house_comment = [HOUSE_COMMENT],	@pub_station = [PUB], @rep1 = [REP1], @rep2 = [REP2],
				@bill_coop_code = [BILL_COOP_CODE], @ord_process_contrl = [ORD_PROCESS_CONTRL], @market_code = [MARKET_CODE],
				@start_date = [START_DATE], @end_date = [END_DATE],	@units = [UNITS], @nbr_of_units = [NBR_OF_UNITS], @net_gross = [NET_GROSS],
				@create_date = [CREATE_DATE], @cancelled = [CANCELLED], @cancelled_by = [CANCELLED_BY], @cancelled_date = [CANCELLED_DATE],
				@modified_by = [MODIFIED_BY], @modified_date = [MODIFIED_DATE], @modified_comments = [MODIFIED_COMMENTS], 
				@revised_flag = [REVISED_FLAG], @link_id = [LINK_ID], @reconcile_flag = [RECONCILE_FLAG], @cmp_identifier = [CMP_IDENTIFIER],
				@printed = [PRINTED], @order_accepted = [ORDER_ACCEPTED], @fiscal_period_code = [FISCAL_PERIOD_CODE], @locked = [LOCKED],
				@locked_by = [LOCKED_BY], @bcc_id = [BCC_ID], @buyer_emp_code = BUYER_EMP_CODE
			FROM MAGAZINE_HEADER
			WHERE ORDER_NBR = @copy_order_nbr	
		END	

		IF @copy_detail = 1 BEGIN
			SELECT @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @active_rev=[ACTIVE_REV], @link_detid=[LINK_DETID], @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
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
							@date_to_bill=[DATE_TO_BILL], --[BILLING_USER], 
							@ar_inv_nbr = [AR_INV_NBR], 
							--[AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
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
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1		
		END
		
		SELECT @billed_amount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ),
			@billed_amount_resale_tax = COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
		FROM dbo.[MAGAZINE_DETAIL] d   
		WHERE d.ORDER_NBR = @copy_order_nbr 
		AND d.LINE_NBR = @copy_line_nbr 
		AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.MAGAZINE_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND AR_INV_NBR IS NOT NULL AND ACTIVE_REV = 1)
			SET @is_billed = 1
				
		/* DETAIL OVERRIDES */
		IF @force_revision = 1 OR (@is_billed = 1 AND (@rate <> @new_rate 
														OR @netcharge <> @new_netcharge 
														OR @addl_charge <> @new_addl_charge))
			SET @action = 'REVISE'
		
		SET @addl_charge = @new_addl_charge
		SET @flat_addl_charge = @new_addl_charge

		SET @netcharge = @new_netcharge  -- this is a production charge that is similar to Additional Amount in that it is not rate-related but changes the order total.  This is an amount due to the vendor.
		SET @flat_netcharge = @new_netcharge

		SET @close_date = @new_close_date
		set @matl_close_date = @new_matl_close_date
		SET @ext_close_date = @new_ext_close_date
		SET @ext_matl_date = @new_ext_matl_date
		SET @date_to_bill = @new_date_to_bill
		SET @mat_comp = @new_mat_comp_date

		SET @ad_number = @new_ad_number
		SET @job_number = @new_job_number
		SET @job_component_nbr = @new_job_component_nbr
		SET @markup_pct = @new_markup_pct
		SET @rebate_pct = @new_rebate_pct

		--Non Broadcast Order Changes (N, M, O, I)
		SET @headline = @new_headline
		SET @size_code = @new_ad_size_code
		SET @material = @new_material

		IF @new_ad_size_code IS NOT NULL
			SELECT @size = SIZE_DESC
			FROM dbo.AD_SIZE 
			WHERE MEDIA_TYPE = 'M'
			AND SIZE_CODE = @new_ad_size_code

		--SET @size = @new_ad_size_description
		--Magazine Order Changes
		SET @edition_issue = @new_edition_issue
		SET @production_size = @new_production_size
		SET @mg_circulation = @new_mg_circulation

		IF @new_amt_source <> 0 BEGIN -- back calc rate
			SET @override_rates = 1
			IF @new_amt_source = 1 
				SELECT
					--when @net_gross=1 (gross order) set @new_amount = EXT_NET_AMT * 17.647 %
					--@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( GROSS_AMT, 0.00 )), 0.00 ) END,
					@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) + 
						((SELECT COALESCE(MARKUP_PCT / 100, .17647) FROM dbo.MAGAZINE_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND ACTIVE_REV = 1) * COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 )) END,
					@color_charge = CASE WHEN @net_gross = 0 THEN 
										COALESCE( SUM( COALESCE( COLOR_NET_AMT, 0.00 )), 0.00 )
									ELSE
										COALESCE( SUM( COALESCE( COLOR_GROSS_AMT, 0.00 )), 0.00 )
									END,
					@bleed_amt = CASE WHEN @net_gross = 0 THEN 
									COALESCE( SUM( COALESCE( BLEED_NET_AMT, 0.00 )), 0.00 )
								 ELSE
									COALESCE( SUM( COALESCE( BLEED_GROSS_AMT, 0.00 )), 0.00 )
								 END,
					@bleed_pct = CASE WHEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) <> 0 AND COALESCE( SUM( COALESCE( BLEED_NET_AMT, 0.00 )), 0.00 ) <> 0 THEN
											COALESCE( SUM( COALESCE( BLEED_NET_AMT, 0.00 )), 0.00 ) / COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) * 100
									  ELSE 0 
									  END,
					@position_amt = CASE WHEN @net_gross = 0 THEN 
										COALESCE( SUM( COALESCE( POSITION_NET_AMT, 0.00 )), 0.00 )
									ELSE
										COALESCE( SUM( COALESCE( POSITION_GROSS_AMT, 0.00 )), 0.00 )
									END,
					@position_pct = CASE WHEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) <> 0 AND COALESCE( SUM( COALESCE( POSITION_NET_AMT, 0.00 )), 0.00 ) <> 0 THEN
											COALESCE( SUM( COALESCE( POSITION_NET_AMT, 0.00 )), 0.00 ) / COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) * 100
										 ELSE 0 
										 END,
					@premium_amt = CASE WHEN @net_gross = 0 THEN 
										COALESCE( SUM( COALESCE( PREMIUM_NET_AMT, 0.00 )), 0.00 )
								   ELSE
										COALESCE( SUM( COALESCE( PREMIUM_GROSS_AMT, 0.00 )), 0.00 )
								   END,
					@premium_pct = CASE WHEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) <> 0 AND COALESCE( SUM( COALESCE( PREMIUM_NET_AMT, 0.00 )), 0.00 ) <> 0 THEN
											COALESCE( SUM( COALESCE( PREMIUM_NET_AMT, 0.00 )), 0.00 ) / COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) * 100
										ELSE 0 
										END
				FROM dbo.AP_MAGAZINE
				WHERE ORDER_NBR = @copy_order_nbr
				AND ORDER_LINE_NBR = @copy_line_nbr
				AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

			IF @net_gross = 0
				SET @flat_net = @new_amount 
			ELSE
				SET @flat_gross = @new_amount 
		END ELSE BEGIN --set rate (will be net or gross depending on the net/gross flag)
		
			IF @net_gross = 0 BEGIN
				IF @new_rate <> 0 BEGIN
					SET @bleed_amt = @flat_net / @new_rate * (@new_rate * COALESCE(@bleed_pct, 0) / 100)
					SET @position_amt = @flat_net / @new_rate * (@new_rate * COALESCE(@position_pct, 0) / 100)
					SET @premium_amt = @flat_net / @new_rate * (@new_rate * COALESCE(@premium_pct, 0) / 100)
					SET @flat_net = @new_rate - @bleed_amt - @position_amt - @premium_amt - @color_charge
				END ELSE BEGIN
					SET @bleed_amt = 0
					SET @position_amt = 0
					SET @premium_amt = 0
					SET @flat_net = 0
				END
			END ELSE BEGIN
				IF @new_rate <> 0 BEGIN
					SET @bleed_amt = @flat_gross / @new_rate * (@new_rate * COALESCE(@bleed_pct, 0) / 100)
					SET @position_amt = @flat_gross / @new_rate * (@new_rate * COALESCE(@position_pct, 0) / 100)
					SET @premium_amt = @flat_gross / @new_rate * (@new_rate * COALESCE(@premium_pct, 0) / 100)
					SET @flat_gross = @new_rate - @bleed_amt - @position_amt - @premium_amt - @color_charge
				END ELSE BEGIN
					SET @bleed_amt = 0
					SET @position_amt = 0
					SET @premium_amt = 0
					SET @flat_gross = 0
				END
			END

		END
		
		IF @new_amt_source = 1 BEGIN
			
			SELECT
				@flat_netcharge = COALESCE( SUM( COALESCE( NETCHARGES, 0.00 )), 0.00 ),
				@flat_discount_amt = COALESCE( SUM( COALESCE( DISCOUNT_LN, 0.00 )), 0.00 ),
				@override_non_resale_amt = COALESCE( SUM( COALESCE( VENDOR_TAX, 0.00 )), 0.00 )
			FROM dbo.AP_MAGAZINE
			WHERE ORDER_NBR = @copy_order_nbr
			AND ORDER_LINE_NBR = @copy_line_nbr
			AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

		END

		IF @new_amt_source = 2 BEGIN
			SET @override_non_resale_amt = 0
			SET @flat_netcharge = 0
			SET @flat_discount_amt = 0
			SET @color_charge = 0
			SET @bleed_pct = 0
			SET @bleed_amt = 0
			SET @position_pct = 0
			SET @position_amt = 0
			SET @premium_pct = 0
			SET @premium_amt = 0

			SET @flat_net = @new_amount
			SET @flat_gross = ROUND( @flat_net + (@flat_net * @markup_pct/100), 2)

		END

	END /* End MAG */
	
	IF @media_type_in = 'I' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			SELECT
				@order_desc = [ORDER_DESC], @cl_code = [CL_CODE], @div_code = [DIV_CODE], @prd_code = [PRD_CODE],
				@office_code = [OFFICE_CODE], @cmp_code = [CMP_CODE], @vn_code = [VN_CODE],	@vr_code = [VR_CODE], @vr_code2 = [VR_CODE2],
				@client_po = [CLIENT_PO], @client_ref = [CLIENT_REF], @status = [STATUS], @order_date = [ORDER_DATE], @buyer = [BUYER],
				@order_comment = [ORDER_COMMENT], @house_comment = [HOUSE_COMMENT],	@pub_station = [PUB], @rep1 = [REP1], @rep2 = [REP2],
				@bill_coop_code = [BILL_COOP_CODE], @ord_process_contrl = [ORD_PROCESS_CONTRL], @market_code = [MARKET_CODE],
				@start_date = [START_DATE], @end_date = [END_DATE],	@units = [UNITS], @net_gross = [NET_GROSS],
				@create_date = [CREATE_DATE], @cancelled = [CANCELLED], @cancelled_by = [CANCELLED_BY], @cancelled_date = [CANCELLED_DATE],
				@modified_by = [MODIFIED_BY], @modified_date = [MODIFIED_DATE], @modified_comments = [MODIFIED_COMMENTS], 
				@revised_flag = [REVISED_FLAG], @link_id = [LINK_ID], @reconcile_flag = [RECONCILE_FLAG], @cmp_identifier = [CMP_IDENTIFIER],
				@printed = [PRINTED], @order_accepted = [ORDER_ACCEPTED], @fiscal_period_code = [FISCAL_PERIOD_CODE], @locked = [LOCKED],
				@locked_by = [LOCKED_BY], @bcc_id = [BCC_ID], @buyer_emp_code = BUYER_EMP_CODE
			FROM INTERNET_HEADER
			WHERE ORDER_NBR = @copy_order_nbr		
		END	

		IF @copy_detail = 1 BEGIN
			SELECT @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @active_rev=[ACTIVE_REV], @link_detid=[LINK_DETID], @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
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
							@taxapplyr=[TAXAPPLYR], @taxapplyai=[TAXAPPLYAI], @reconcile_flag=[RECONCILE_FLAG],
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
							@placement_1 = [PLACEMENT_1], @placement_2 = [PLACEMENT_2],  /***/
							@creative_size=[CREATIVE_SIZE],
							@ad_server_placement_id = [AD_SERVER_PLACEMENT_ID],
							@ad_server_created_by = [AD_SERVER_CREATED_BY],
							@ad_server_created_datetime = [AD_SERVER_CREATED_DATETIME],
							@ad_server_last_modified_by = [AD_SERVER_LAST_MODIFIED_BY],
							@ad_server_last_modified_datetime = [AD_SERVER_LAST_MODIFIED_DATETIME],
							@ad_server_placement_manual = [AD_SERVER_PLACEMENT_MANUAL],
							@package_parent = PACKAGE_PARENT,
							@ad_server_placement_group_id = AD_SERVER_PLACEMENT_GROUP_ID
			FROM [dbo].[INTERNET_DETAIL] 
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1
		END
		
		SELECT @billed_amount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ),
			@billed_amount_resale_tax = COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
		FROM dbo.[INTERNET_DETAIL] d   
		WHERE d.ORDER_NBR = @copy_order_nbr 
		AND d.LINE_NBR = @copy_line_nbr 
		AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND AR_INV_NBR IS NOT NULL AND ACTIVE_REV = 1)
			SET @is_billed = 1
		
		/* DETAIL OVERRIDES */
		IF @force_revision = 1 OR (@is_billed = 1 AND (@cost_rate <> @new_rate 
														OR @netcharge <> @new_netcharge 
														OR @cost_type <> @new_cost_type 
														OR @proj_impressions <> @new_proj_impressions 
														OR @guaranteed_impress <> @new_guaranteed_impress
														OR @addl_charge <> @new_addl_charge
														OR @act_impressions <> @new_actual_impressions))
			SET @action = 'REVISE'

		SET @addl_charge = @new_addl_charge
		
		SET @netcharge = @new_netcharge  -- this is a production charge that is similar to Additional Amount in that it is not rate-related but changes the order total.  This is an amount due to the vendor.

		SET @close_date = @new_close_date
		set @matl_close_date = @new_matl_close_date
		SET @ext_close_date = @new_ext_close_date
		SET @ext_matl_date = @new_ext_matl_date
		SET @date_to_bill = @new_date_to_bill
		SET @mat_comp = @new_mat_comp_date

		SET @ad_number = @new_ad_number
		SET @job_number = @new_job_number
		SET @job_component_nbr = @new_job_component_nbr
		SET @markup_pct = @new_markup_pct
		SET @rebate_pct = @new_rebate_pct

		--Non Broadcast Order Changes (N, M, O, I)
		SET @headline = @new_headline
		SET @size = @new_ad_size_code

		IF @new_ad_size_code IS NOT NULL
			SELECT @creative_size = SIZE_DESC
			FROM dbo.AD_SIZE 
			WHERE MEDIA_TYPE = 'I'
			AND SIZE_CODE = @new_ad_size_code

		--SET @creative_size = @new_ad_size_description
		--Internet Order Changes
		SET @placement_1 = @new_internet_placement1
		SET @placement_2 = @new_internet_placement2
		SET @o_type = @new_internet_type
		SET @url_location = @new_url
		SET @target_audience = @new_target_audience

		SET @cost_type = @new_cost_type  --d  COST_TYPE (I,N)
		SET @proj_impressions = @new_proj_impressions  --d  (I)
		SET @guaranteed_impress = @new_guaranteed_impress --d (I)
		SET @act_impressions = @new_actual_impressions --d (I)

		IF @new_amt_source <> 0 BEGIN -- back calc rate
			SET @override_rates = 1
			SELECT @SumQTY = SUM(IMPRESSIONS)
			FROM dbo.AP_INTERNET
			WHERE ORDER_NBR = @order_nbr_in 
			AND ORDER_LINE_NBR = @line_nbr_in 
			AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

			IF COALESCE(@SumQTY, 0) = 0
				IF @act_impressions <> 0 
					SET @SumQTY = @act_impressions 
				ELSE
					SET @SumQTY = @guaranteed_impress 
		
			IF COALESCE(@SumQTY, 0) = 0 
				SET @SumQTY = 1

			IF @new_amt_source = 1 
				SELECT
					--when @net_gross=1 (gross order) set @new_amount = EXT_NET_AMT * 17.647 %
					--@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( NET_AMT, 0.00 ) + COALESCE( COMM_AMT, 0.00 ) ), 0.00 ) END
					@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( NET_AMT, 0.00)), 0.00) + 
					((SELECT COALESCE(MARKUP_PCT / 100, .17647) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND ACTIVE_REV = 1) * COALESCE( SUM( COALESCE( NET_AMT, 0.00)), 0.00)) END
				FROM dbo.AP_INTERNET
				WHERE ORDER_NBR = @copy_order_nbr
				AND ORDER_LINE_NBR = @copy_line_nbr
				AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )
			ELSE
				SET @SumQTY = @guaranteed_impress

			IF COALESCE(@SumQTY, 0) = 0 
				SET @SumQTY = 1

			SET @act_impressions = @SumQTY 

			IF @net_gross = 0 
				IF @cost_type <> 'NA' BEGIN
					IF @cost_type = 'CPM' BEGIN
						SET @net_rate = @new_amount / @SumQTY * 1000
						SET @cost_rate = @new_amount / @SumQTY * 1000
					END ELSE BEGIN
						SET @net_rate = @new_amount / @SumQTY
						SET @cost_rate = @new_amount / @SumQTY
					END
				END ELSE BEGIN
					SET @net_rate = @new_amount
				END
			
			ELSE
				IF @cost_type <> 'NA' BEGIN
					IF @cost_type = 'CPM' BEGIN
						SET @gross_rate = ROUND( @new_amount / @SumQTY * 1000, 2)
						SET @cost_rate = ROUND( @new_amount / @SumQTY * 1000, 2)
					END ELSE BEGIN
						SET @gross_rate = ROUND( @new_amount / @SumQTY, 2)
						SET @cost_rate = ROUND( @new_amount / @SumQTY, 2)
					END
				END ELSE BEGIN
					SET @gross_rate = ROUND( @new_amount, 2)
				END
		END ELSE BEGIN --set rate (will be net or gross depending on the net/gross flag)
			IF @net_gross = 0 BEGIN
				SET @net_rate = @new_rate
				SET @cost_rate = @new_rate
			END ELSE BEGIN
				SET @gross_rate = @new_rate
				SET @cost_rate = @new_rate
			END
		END
		
		IF @new_amt_source = 1 BEGIN
			
			SELECT
				@netcharge = COALESCE( SUM( COALESCE( NETCHARGES, 0.00 )), 0.00 ),
				@discount_amt = COALESCE( SUM( COALESCE( DISCOUNT_AMT, 0.00 )), 0.00 ),
				@override_non_resale_amt = COALESCE( SUM( COALESCE( VENDOR_TAX, 0.00 )), 0.00 )
			FROM dbo.AP_INTERNET
			WHERE ORDER_NBR = @copy_order_nbr
			AND ORDER_LINE_NBR = @copy_line_nbr
			AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

		END

		IF @new_amt_source = 2 BEGIN

			SET @override_non_resale_amt = 0
			SET @netcharge = 0
			SET @discount_amt = 0

			IF @cost_type <> 'NA'
				IF @cost_type = 'CPM' 
					SET @net_rate = @new_amount / @SumQTY * 1000
				ELSE
					SET @net_rate = @new_amount / @SumQTY
			ELSE
				SET @net_rate = @new_amount

			SET @gross_rate = ROUND( @net_rate + (@net_rate * @markup_pct/100), 2)

			IF @net_gross = 0
				SET @cost_rate = @net_rate
			ELSE
				SET @cost_rate = @gross_rate
		END

	END /* End INET */
	
	IF @media_type_in = 'O' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			SELECT
				@order_desc = [ORDER_DESC], @cl_code = [CL_CODE], @div_code = [DIV_CODE], @prd_code = [PRD_CODE],
				@office_code = [OFFICE_CODE], @cmp_code = [CMP_CODE], @vn_code = [VN_CODE],	@vr_code = [VR_CODE], @vr_code2 = [VR_CODE2],
				@client_po = [CLIENT_PO], @client_ref = [CLIENT_REF], @status = [STATUS], @order_date = [ORDER_DATE], @buyer = [BUYER],
				@order_comment = [ORDER_COMMENT], @house_comment = [HOUSE_COMMENT],	@pub_station = [PUB], @rep1 = [REP1], @rep2 = [REP2],
				@bill_coop_code = [BILL_COOP_CODE], @ord_process_contrl = [ORD_PROCESS_CONTRL], @market_code = [MARKET_CODE],
				@start_date = [START_DATE], @end_date = [END_DATE],	@units = [UNITS], @nbr_of_units = [NBR_OF_UNITS], @net_gross = [NET_GROSS],
				@create_date = [CREATE_DATE], @cancelled = [CANCELLED], @cancelled_by = [CANCELLED_BY], @cancelled_date = [CANCELLED_DATE],
				@modified_by = [MODIFIED_BY], @modified_date = [MODIFIED_DATE], @modified_comments = [MODIFIED_COMMENTS], 
				@revised_flag = [REVISED_FLAG], @link_id = [LINK_ID], @reconcile_flag = [RECONCILE_FLAG], @cmp_identifier = [CMP_IDENTIFIER],
				@printed = [PRINTED], @order_accepted = [ORDER_ACCEPTED], @fiscal_period_code = [FISCAL_PERIOD_CODE], @locked = [LOCKED],
				@locked_by = [LOCKED_BY], @bcc_id = [BCC_ID], @buyer_emp_code = BUYER_EMP_CODE
			FROM OUTDOOR_HEADER
			WHERE ORDER_NBR = @copy_order_nbr	
			
		END	

		IF @copy_detail = 1 BEGIN
			SELECT @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @active_rev=[ACTIVE_REV], @link_detid=[LINK_DETID], @start_date=[POST_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
							@matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE], @size=[SIZE], 
							@ad_number=[AD_NUMBER], @headline=[HEADLINE], @url_location=[LOCATION], @copy_area=[COPY_AREA], 
							@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR], @rate_card=[RATE_CARD], @rate_type=[RATE_TYPE], @rate_desc=[RATE_DESC],	
							@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], 
							@ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT], @comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT],
							@discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC], @state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], 
							@non_resale_amt=[NON_RESALE_AMT], @netcharge=[NETCHARGE], @ncdesc=[NCDESC],
							@addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], 
							@line_total=[LINE_TOTAL], --[LINE_CANCELLED],
							@date_to_bill=[DATE_TO_BILL], --[BILLING_USER], 
							@ar_inv_nbr = [AR_INV_NBR],
							--[AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
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
							@mat_comp=[MAT_COMP], @o_type=[OUTDOOR_TYPE], @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
			FROM [dbo].[OUTDOOR_DETAIL] 
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1
		END
		
		SELECT @billed_amount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ),
			@billed_amount_resale_tax = COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
		FROM dbo.[OUTDOOR_DETAIL] d   
		WHERE d.ORDER_NBR = @copy_order_nbr 
		AND d.LINE_NBR = @copy_line_nbr 
		AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.OUTDOOR_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND AR_INV_NBR IS NOT NULL AND ACTIVE_REV = 1)
			SET @is_billed = 1
		
		/* DETAIL OVERRIDES */
		IF @force_revision = 1 OR (@is_billed = 1 AND (@rate <> @new_rate 
														OR @netcharge <> @new_netcharge 
														OR @addl_charge <> @new_addl_charge 
														OR @guaranteed_impress <> @new_guaranteed_impress 
														OR @act_impressions <> @new_actual_impressions))
			SET @action = 'REVISE'
		
		SET @addl_charge = @new_addl_charge
		
		SET @netcharge = @new_netcharge  -- this is a production charge that is similar to Additional Amount in that it is not rate-related but changes the order total.  This is an amount due to the vendor.

		SET @close_date = @new_close_date
		set @matl_close_date = @new_matl_close_date
		SET @ext_close_date = @new_ext_close_date
		SET @ext_matl_date = @new_ext_matl_date
		SET @date_to_bill = @new_date_to_bill
		SET @mat_comp = @new_mat_comp_date

		SET @ad_number = @new_ad_number
		SET @job_number = @new_job_number
		SET @job_component_nbr = @new_job_component_nbr
		SET @markup_pct = @new_markup_pct
		SET @rebate_pct = @new_rebate_pct
		
		--Non Broadcast Order Changes (N, M, O, I)
		SET @headline = @new_headline
		SET @size = @new_ad_size_code

		/* PJH 03/22/19 - Added */
		SET @guaranteed_impress = @new_guaranteed_impress --d (O)
		SET @act_impressions = @new_actual_impressions --d (O)

		SET @copy_area = @new_copy_area
		SET @url_location = @new_location
		SET @o_type = @new_outdoor_type

		IF @new_amt_source <> 0 BEGIN -- back calc rate
			SET @override_rates = 1
			IF @new_amt_source = 1 
				SELECT
					--when @net_gross=1 (gross order) set @new_amount = EXT_NET_AMT * 17.647 %
					--@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( NET_AMT, 0.00 ) + COALESCE( COMM_AMT, 0.00 ) ), 0.00 ) END
					@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00) + 
					((SELECT COALESCE(MARKUP_PCT / 100, .17647) FROM dbo.OUTDOOR_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND ACTIVE_REV = 1) * COALESCE( SUM( COALESCE( NET_AMT, 0.00 )), 0.00)) END
				FROM dbo.AP_OUTDOOR
				WHERE ORDER_NBR = @copy_order_nbr
				AND ORDER_LINE_NBR = @copy_line_nbr
				AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

			IF @net_gross = 0
				SET @net_rate = @new_amount 
			ELSE
				SET @gross_rate = @new_amount 
		END ELSE BEGIN --set rate (will be net or gross depending on the net/gross flag)
			IF @net_gross = 0
				SET @net_rate = @new_rate
			ELSE 
				SET @gross_rate = @new_rate
		END
		
		IF @new_amt_source = 1 BEGIN
			
			SELECT
				@netcharge = COALESCE( SUM( COALESCE( NETCHARGES, 0.00 )), 0.00 ),
				@discount_amt = COALESCE( SUM( COALESCE( DISCOUNT_AMT, 0.00 )), 0.00 ),
				@override_non_resale_amt = COALESCE( SUM( COALESCE( VENDOR_TAX, 0.00 )), 0.00 )
			FROM dbo.AP_OUTDOOR
			WHERE ORDER_NBR = @copy_order_nbr
			AND ORDER_LINE_NBR = @copy_line_nbr
			AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

		END

		IF @new_amt_source = 2 BEGIN

			SET @override_non_resale_amt = 0
			SET @netcharge = 0
			SET @discount_amt = 0

			SET @net_rate = @new_amount 
			SET @gross_rate = ROUND( @net_rate + (@net_rate * @markup_pct/100), 2)

		END

	END /* End OOH */

	IF @media_type_in = 'T' BEGIN

		/** Get current Values if they exist **/

		IF @copy_hdr = 1 BEGIN
			SELECT
				@order_desc = [ORDER_DESC], @cl_code = [CL_CODE], @div_code = [DIV_CODE], @prd_code = [PRD_CODE],
				@office_code = [OFFICE_CODE], @cmp_code = [CMP_CODE], @vn_code = [VN_CODE],	@vr_code = [VR_CODE], @vr_code2 = [VR_CODE2],
				@client_po = [CLIENT_PO], @client_ref = [CLIENT_REF], @status = [STATUS], @order_date = [ORDER_DATE], @buyer = [BUYER],
				@order_comment = [ORDER_COMMENT], @house_comment = [HOUSE_COMMENT],	@pub_station = [STATION], @rep1 = [REP1], @rep2 = [REP2],
				@bill_coop_code = [BILL_COOP_CODE], @ord_process_contrl = [ORD_PROCESS_CONTRL], @market_code = [MARKET_CODE],
				@start_date = [START_DATE], @end_date = [END_DATE],	@units = [UNITS], @net_gross = [NET_GROSS],
				@create_date = [CREATE_DATE], @cancelled = [CANCELLED], @cancelled_by = [CANCELLED_BY], @cancelled_date = [CANCELLED_DATE],
				@modified_by = [MODIFIED_BY], @modified_date = [MODIFIED_DATE], @modified_comments = [MODIFIED_COMMENTS], 
				@revised_flag = [REVISED_FLAG], @link_id = [LINK_ID], @reconcile_flag = [RECONCILE_FLAG], @cmp_identifier = [CMP_IDENTIFIER],
				@printed = [PRINTED], @order_accepted = [ORDER_ACCEPTED], @fiscal_period_code = [FISCAL_PERIOD_CODE], @locked = [LOCKED],
				@locked_by = [LOCKED_BY], @bcc_id = [BCC_ID], @buyer_emp_code = BUYER_EMP_CODE
			FROM TV_HDR
			WHERE ORDER_NBR = @copy_order_nbr
			
		END	
		
		IF @copy_detail = 1 BEGIN
			SELECT @rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @active_rev=[ACTIVE_REV], @link_detid=[LINK_DETID],
				   @buy_type=[BUY_TYPE], @start_date=[START_DATE], @end_date=[END_DATE], @month_nbr=[MONTH_NBR], @year_nbr=[YEAR_NBR]
				  ,@close_date=[CLOSE_DATE], @matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE]
				  ,@date1=[DATE1], @date2=[DATE2], @date3=[DATE3], @date4=[DATE4], @date5=[DATE5], @date6=[DATE6], @date7=[DATE7]
				  ,@monday=[MONDAY], @tuesday=[TUESDAY], @wednesday=[WEDNESDAY], @thursday=[THURSDAY], @friday=[FRIDAY], @saturday=[SATURDAY], @sunday=[SUNDAY]
				  ,@spots1=[SPOTS1], @spots2=[SPOTS2], @spots3=[SPOTS3], @spots4=[SPOTS4], @spots5=[SPOTS5], @spots6=[SPOTS6], @spots7=[SPOTS7], @total_spots=[TOTAL_SPOTS]
				  ,@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR]
				  ,@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], @ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT]
				  ,@comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT], @discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC]
				  ,@state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], @non_resale_amt=[NON_RESALE_AMT]      
				  ,@netcharge=[NETCHARGE], @ncdesc=[NCDESC], @addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], @line_total=[LINE_TOTAL], @ar_inv_nbr = [AR_INV_NBR]
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
				  ,@daypart_id=[DAY_PART_ID]
				  ,@cable_network_station_code = CABLE_NETWORK_STATION_CODE
				  ,@added_value = ADDED_VALUE
				  ,@bookend = BOOKEND
				  ,@link_line_number = LINK_LINE_NUMBER
			FROM [dbo].[TV_DETAIL]
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1
		END
		
		SELECT @billed_amount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ),
			@billed_amount_resale_tax = COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
		FROM dbo.[TV_DETAIL] d   
		WHERE d.ORDER_NBR = @copy_order_nbr 
		AND d.LINE_NBR = @copy_line_nbr 
		AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.TV_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND AR_INV_NBR IS NOT NULL AND ACTIVE_REV = 1)
			SET @is_billed = 1
		
		/* DETAIL OVERRIDES */
		IF @force_revision = 1 OR (@is_billed = 1 AND (@rate <> @new_rate 
														OR @netcharge <> @new_netcharge 
														OR @addl_charge <> @new_addl_charge))
			SET @action = 'REVISE'
		
		SET @addl_charge = @new_addl_charge
		
		SET @netcharge = @new_netcharge  -- this is a production charge that is similar to Additional Amount in that it is not rate-related but changes the order total.  This is an amount due to the vendor.

		SET @close_date = @new_close_date
		set @matl_close_date = @new_matl_close_date
		SET @ext_close_date = @new_ext_close_date
		SET @ext_matl_date = @new_ext_matl_date
		SET @date_to_bill = @new_date_to_bill
		SET @mat_comp = @new_mat_comp_date

		SET @ad_number = @new_ad_number
		SET @job_number = @new_job_number
		SET @job_component_nbr = @new_job_component_nbr
		SET @markup_pct = @new_markup_pct
		SET @rebate_pct = @new_rebate_pct
		
		--Broadcast Order Changes:
		SET @programming = @new_programming
		SET @remarks = @new_remarks
		SET @start_time = @new_start_time
		SET @end_time = @new_end_time
		SET @length = @new_length

		--IF @new_spots <> @total_spots BEGIN
		--	SET @spots1 = @new_spots
		--	SET @spots2 = 0
		--	SET @spots3 = 0
		--	SET @spots4 = 0
		--	SET @spots5 = 0
		--	SET @spots6 = 0
		--	SET @spots7 = 0
		--	SET @total_spots = @new_spots
		--END

		IF @new_amt_source <> 0 BEGIN -- back calc rate
			SET @override_rates = 1
			--SELECT @SumQTY = SUM(TOTAL_SPOTS)
			--FROM dbo.AP_TV
			--WHERE ORDER_NBR = @order_nbr_in 
			--AND ORDER_LINE_NBR = @line_nbr_in 
			--AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

			--IF COALESCE(@SumQTY, 0) = 0
			--	IF @total_spots <> 0 
					SET @SumQTY = @total_spots
		
			IF COALESCE(@SumQTY, 0) = 0 
				SET @SumQTY = 1
			
			IF @new_amt_source = 1 
				SELECT
					--when @net_gross=1 (gross order) set @new_amount = EXT_NET_AMT * 17.647 %
					--@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) + COALESCE( SUM( COALESCE( COMM_AMT, 0.00 )), 0.00 ) END
					@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) + 
					((SELECT COALESCE(MARKUP_PCT / 100, .17647) FROM dbo.TV_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND ACTIVE_REV = 1) * COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 )) END
				FROM dbo.AP_TV
				WHERE ORDER_NBR = @copy_order_nbr
				AND ORDER_LINE_NBR = @copy_line_nbr
				AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )
			ELSE
				SET @SumQTY = 1
			
			SET @total_spots = @SumQTY 

			IF @net_gross = 0
				SET @net_rate = @new_amount / @SumQTY 
			ELSE
				SET @gross_rate = @new_amount / @SumQTY 
		END ELSE BEGIN --set rate (will be net or gross depending on the net/gross flag)
			IF @net_gross = 0
				SET @net_rate = @new_rate
			ELSE 
				SET @gross_rate = @new_rate
		END

		IF @new_amt_source = 1 BEGIN
		
			SELECT
				@netcharge = COALESCE( SUM( COALESCE( NETCHARGES, 0.00 )), 0.00 ),
				@discount_amt = COALESCE( SUM( COALESCE( DISC_AMT, 0.00 )), 0.00 ),
				@override_non_resale_amt = COALESCE( SUM( COALESCE( VENDOR_TAX, 0.00 )), 0.00 )
			FROM dbo.AP_TV
			WHERE ORDER_NBR = @copy_order_nbr
			AND ORDER_LINE_NBR = @copy_line_nbr
			AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

		END

		IF @new_amt_source = 2 BEGIN

			SET @override_non_resale_amt = 0
			SET @netcharge = 0
			SET @discount_amt = 0

			SET @net_rate = @new_amount / @SumQTY 
			SET @gross_rate = ROUND( @net_rate + (@net_rate * @markup_pct/100), 2)

		END

	END /* End TV */
	
	IF @media_type_in = 'R' BEGIN

		/** Get current Values if they exist **/
		
		IF @copy_hdr = 1 BEGIN
			SELECT
				@order_desc = [ORDER_DESC], @cl_code = [CL_CODE], @div_code = [DIV_CODE], @prd_code = [PRD_CODE],
				@office_code = [OFFICE_CODE], @cmp_code = [CMP_CODE], @vn_code = [VN_CODE],	@vr_code = [VR_CODE], @vr_code2 = [VR_CODE2],
				@client_po = [CLIENT_PO], @client_ref = [CLIENT_REF], @status = [STATUS], @order_date = [ORDER_DATE], @buyer = [BUYER],
				@order_comment = [ORDER_COMMENT], @house_comment = [HOUSE_COMMENT],	@pub_station = [STATION], @rep1 = [REP1], @rep2 = [REP2],
				@bill_coop_code = [BILL_COOP_CODE], @ord_process_contrl = [ORD_PROCESS_CONTRL], @market_code = [MARKET_CODE],
				@start_date = [START_DATE], @end_date = [END_DATE],	@units = [UNITS], @net_gross = [NET_GROSS],
				@create_date = [CREATE_DATE], @cancelled = [CANCELLED], @cancelled_by = [CANCELLED_BY], @cancelled_date = [CANCELLED_DATE],
				@modified_by = [MODIFIED_BY], @modified_date = [MODIFIED_DATE], @modified_comments = [MODIFIED_COMMENTS], 
				@revised_flag = [REVISED_FLAG], @link_id = [LINK_ID], @reconcile_flag = [RECONCILE_FLAG], @cmp_identifier = [CMP_IDENTIFIER],
				@printed = [PRINTED], @order_accepted = [ORDER_ACCEPTED], @fiscal_period_code = [FISCAL_PERIOD_CODE], @locked = [LOCKED],
				@locked_by = [LOCKED_BY], @bcc_id = [BCC_ID], @buyer_emp_code = BUYER_EMP_CODE
			FROM RADIO_HDR
			WHERE ORDER_NBR = @copy_order_nbr
			
		END	

		IF @copy_detail = 1 BEGIN
			SELECT 
					@rev_nbr=[REV_NBR], @seq_nbr=[SEQ_NBR], @active_rev=[ACTIVE_REV], @link_detid=[LINK_DETID],
				   @buy_type=[BUY_TYPE], @start_date=[START_DATE], @end_date=[END_DATE], @month_nbr=[MONTH_NBR], @year_nbr=[YEAR_NBR]
				  ,@close_date=[CLOSE_DATE], @matl_close_date=[MATL_CLOSE_DATE], @ext_close_date=[EXT_CLOSE_DATE], @ext_matl_date=[EXT_MATL_DATE]
				  ,@date1=[DATE1], @date2=[DATE2], @date3=[DATE3], @date4=[DATE4], @date5=[DATE5], @date6=[DATE6], @date7=[DATE7]
				  ,@monday=[MONDAY], @tuesday=[TUESDAY], @wednesday=[WEDNESDAY], @thursday=[THURSDAY], @friday=[FRIDAY], @saturday=[SATURDAY], @sunday=[SUNDAY]
				  ,@spots1=[SPOTS1], @spots2=[SPOTS2], @spots3=[SPOTS3], @spots4=[SPOTS4], @spots5=[SPOTS5], @spots6=[SPOTS6], @spots7=[SPOTS7], @total_spots=[TOTAL_SPOTS]
				  ,@job_number=[JOB_NUMBER], @job_component_nbr=[JOB_COMPONENT_NBR]
				  ,@quantity=[QUANTITY], @rate=[RATE], @net_rate=[NET_RATE], @gross_rate=[GROSS_RATE], @ext_net_amt=[EXT_NET_AMT], @ext_gross_amt=[EXT_GROSS_AMT]
				  ,@comm_amt=[COMM_AMT], @rebate_amt=[REBATE_AMT], @discount_amt=[DISCOUNT_AMT], @discount_desc=[DISCOUNT_DESC]
				  ,@state_amt=[STATE_AMT], @county_amt=[COUNTY_AMT], @city_amt=[CITY_AMT], @non_resale_amt=[NON_RESALE_AMT]      
				  ,@netcharge=[NETCHARGE], @ncdesc=[NCDESC], @addl_charge=[ADDL_CHARGE], @addl_charge_desc=[ADDL_CHARGE_DESC], @line_total=[LINE_TOTAL], @ar_inv_nbr = [AR_INV_NBR]
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
				  ,@daypart_id=[DAY_PART_ID]
				  ,@added_value = ADDED_VALUE
				  ,@link_line_number = LINK_LINE_NUMBER
			FROM [dbo].[RADIO_DETAIL]
			WHERE [ORDER_NBR] = @copy_order_nbr AND [LINE_NBR] = @copy_line_nbr AND [ACTIVE_REV] = 1
		END
		
		SELECT @billed_amount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ),
			@billed_amount_resale_tax = COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
		FROM dbo.[RADIO_DETAIL] d   
		WHERE d.ORDER_NBR = @copy_order_nbr 
		AND d.LINE_NBR = @copy_line_nbr 
		AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND AR_INV_NBR IS NOT NULL AND ACTIVE_REV = 1)
			SET @is_billed = 1
		
		/* DETAIL OVERRIDES */
		IF @force_revision = 1 OR (@is_billed = 1 AND (@rate <> @new_rate 
														OR @netcharge <> @new_netcharge 
														OR @addl_charge <> @new_addl_charge))
			SET @action = 'REVISE'
		
		SET @addl_charge = @new_addl_charge
		
		SET @netcharge = @new_netcharge  -- this is a production charge that is similar to Additional Amount in that it is not rate-related but changes the order total.  This is an amount due to the vendor.

		SET @close_date = @new_close_date
		set @matl_close_date = @new_matl_close_date
		SET @ext_close_date = @new_ext_close_date
		SET @ext_matl_date = @new_ext_matl_date
		SET @date_to_bill = @new_date_to_bill
		SET @mat_comp = @new_mat_comp_date

		SET @ad_number = @new_ad_number
		SET @job_number = @new_job_number
		SET @job_component_nbr = @new_job_component_nbr
		SET @markup_pct = @new_markup_pct
		SET @rebate_pct = @new_rebate_pct
		
		--Broadcast Order Changes:
		SET @programming = @new_programming
		SET @remarks = @new_remarks
		SET @start_time = @new_start_time
		SET @end_time = @new_end_time
		SET @length = @new_length

		--IF @new_spots <> @total_spots BEGIN
		--	SET @spots1 = @new_spots
		--	SET @spots2 = 0
		--	SET @spots3 = 0
		--	SET @spots4 = 0
		--	SET @spots5 = 0
		--	SET @spots6 = 0
		--	SET @spots7 = 0
		--	SET @total_spots = @new_spots
		--END

		IF @new_amt_source <> 0 BEGIN -- back calc rate
			SET @override_rates = 1
			--SELECT @SumQTY = SUM(TOTAL_SPOTS)
			--FROM dbo.AP_RADIO
			--WHERE ORDER_NBR = @order_nbr_in 
			--AND ORDER_LINE_NBR = @line_nbr_in 
			--AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

			--IF COALESCE(@SumQTY, 0) = 0
			--	IF @total_spots <> 0 
					SET @SumQTY = @total_spots
		
			IF COALESCE(@SumQTY, 0) = 0 
				SET @SumQTY = 1

			IF @new_amt_source = 1 
				SELECT
					--when @net_gross=1 (gross order) set @new_amount = EXT_NET_AMT * 17.647 %
					--@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) + COALESCE( SUM( COALESCE( COMM_AMT, 0.00 )), 0.00 ) END
					@new_amount = CASE WHEN @net_gross = 0 THEN COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) ELSE COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 ) + 
					((SELECT COALESCE(MARKUP_PCT / 100, .17647) FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @copy_order_nbr AND LINE_NBR = @copy_line_nbr AND ACTIVE_REV = 1) * COALESCE( SUM( COALESCE( EXT_NET_AMT, 0.00 )), 0.00 )) END
				FROM dbo.AP_RADIO
				WHERE ORDER_NBR = @copy_order_nbr
				AND ORDER_LINE_NBR = @copy_line_nbr
				AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )
			ELSE
				SET @SumQTY = 1
			
			SET @total_spots = @SumQTY 

			IF @net_gross = 0
				SET @net_rate = @new_amount / @SumQTY 
			ELSE
				SET @gross_rate = @new_amount / @SumQTY 
		END ELSE BEGIN --set rate (will be net or gross depending on the net/gross flag)
			IF @net_gross = 0
				SET @net_rate = @new_rate
			ELSE 
				SET @gross_rate = @new_rate
		END

		IF @new_amt_source = 1 BEGIN
		
			SELECT
				@netcharge = COALESCE( SUM( COALESCE( NETCHARGES, 0.00 )), 0.00 ),
				@discount_amt = COALESCE( SUM( COALESCE( DISC_AMT, 0.00 )), 0.00 ),
				@override_non_resale_amt = COALESCE( SUM( COALESCE( VENDOR_TAX, 0.00 )), 0.00 )
			FROM dbo.AP_RADIO
			WHERE ORDER_NBR = @copy_order_nbr
			AND ORDER_LINE_NBR = @copy_line_nbr
			AND ( DELETE_FLAG IS NULL OR DELETE_FLAG = 0 )

		END

		IF @new_amt_source = 2 BEGIN

			SET @override_non_resale_amt = 0
			SET @netcharge = 0
			SET @discount_amt = 0

			SET @net_rate = @new_amount / @SumQTY 
			SET @gross_rate = ROUND( @net_rate + (@net_rate * @markup_pct/100), 2)

		END

	END /* End RADIO */

	SET @ar_inv_nbr = NULL

	SET @sales_class_code = @media_type

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
	
	SET @printed = NULL /** CLEAR PRINTED FLAG **/	
	--SET @mat_comp = NULL
	
	SET @modified_by = @user_id /* Passed from calling Procedure */

	IF @action = 'UPDATE'
		SET @modified_comments = LTRIM(COALESCE(@modified_comments, '') + ' Media Manager modified by ' + @user_id + ' ' + CONVERT(varchar(10), getdate(), 101)) + ';'
	ELSE IF @action = 'REVISE'
		SET @modified_comments = 'Media Manager modified by ' + @user_id + ' ' + CONVERT(varchar(10), getdate(), 101) + ';'
	
	IF @debug = 1
		SELECT 'FROM>>' 'DESC', @copy_order_nbr ORDER_NBR, @copy_line_nbr LINE_NBR, 'TO>>' 'DESC', @order_nbr ORDER_NBR, @line_nbr LINE_NBR /** DEBUG **/
	
	IF @debug = 1
		SELECT 'BEF EXEC' '-', @gross_rate '@gross_rate', @net_rate '@net_rate', @net_gross '@net_gross', @quantity '@quantity', 
			@ext_net_amt '@ext_net_amt', @ext_gross_amt '@ext_gross_amt', @flat_net 'flat_net', @flat_gross 'flat_gross'        /* DEBUG */
	
	DECLARE @ext_net_amt_override decimal(14,2), @temp_cc_amt decimal(14,2), @temp_nc_amt decimal(14,2), @temp_ac_amt decimal(14,2), @state_tax decimal(14,4),
		@county_tax decimal(14,4), @city_tax decimal(14,4), @column_line_qty decimal (14, 3), @cpm int,@overage_pct decimal(14,4), @temp_net_gross char(1),
		@g_charge decimal(14,2), @n_charge decimal(14,2), @d_temp decimal(14,2), @state_rnd decimal(14,2),
		@county_rnd decimal(14,2), @city_rnd decimal(14,2), @ven_rnd decimal(14,2),	@state_ac decimal(14,4), @county_ac decimal(14,4), @city_ac decimal(14,4),
		@ven_tax decimal(14,4), @addl_charge_taxes decimal(14,4), @resale_tax_amt decimal (14, 4), @sales_tax_amt decimal (14, 4), @bill_amt decimal (14, 4)

	SET @error_msg_w = ''

	IF (@order_type = 'TV' OR @order_type = 'RA') BEGIN

		exec dbo.advsp_med_calc_brdcast @quantity  OUTPUT, @total_spots  OUTPUT, @bill_type_flag  OUTPUT, @tax_city_pct  OUTPUT, @tax_county_pct  OUTPUT, @tax_state_pct  OUTPUT, @comm_pct  OUTPUT, @markup_pct  OUTPUT, 
			@rebate_pct  OUTPUT, @discount_pct  OUTPUT, @rebate_amt_override  OUTPUT, @rebate_pct_override  OUTPUT, @markup_pct_override  OUTPUT, @comm_pct_override  OUTPUT, @ext_net_amt_override  OUTPUT, @comm_pct_or  OUTPUT, 
			@markup_pct_or  OUTPUT, @rebate_pct_or  OUTPUT, @rebate_amt_or  OUTPUT, @net_rate  OUTPUT, @gross_rate  OUTPUT, @netcharge  OUTPUT, @addl_charge  OUTPUT, @net_gross  OUTPUT, @temp_net_gross  OUTPUT, 
			@cost_rate  OUTPUT, @g_charge  OUTPUT, @n_charge  OUTPUT, @ext_gross_amt  OUTPUT, @rate  OUTPUT, @comm_amt  OUTPUT, @ext_net_amt  OUTPUT, @rebate_amt  OUTPUT, @discount_amt  OUTPUT, @state_tax  OUTPUT, 
			@county_tax  OUTPUT, @city_tax  OUTPUT, @ven_tax  OUTPUT, @taxapplyc  OUTPUT, @taxapplyln  OUTPUT, @taxapplynd  OUTPUT, @taxapplync  OUTPUT, @taxapplyr  OUTPUT, @taxapplyai  OUTPUT, @state_rnd  OUTPUT, @county_rnd  OUTPUT, 
			@city_rnd  OUTPUT, @ven_rnd  OUTPUT, @tax_resale  OUTPUT, @state_ac  OUTPUT, @county_ac  OUTPUT, @city_ac  OUTPUT, @addl_charge_taxes  OUTPUT, @resale_tax_amt  OUTPUT, @sales_tax_amt  OUTPUT, @bill_amt  OUTPUT, 
			@billing_amt  OUTPUT, @line_total  OUTPUT, @state_amt  OUTPUT, @county_amt  OUTPUT, @city_amt  OUTPUT, @non_resale_amt  OUTPUT, @error_msg_w  OUTPUT,
			@override_non_resale_amt, @strata_net_calc

		IF @new_end_date IS NULL
			SELECT @new_end_date = END_DATE
			FROM advtf_med_set_dates(@order_type, @new_start_date, NULL, @net_gross, @vn_code, 'UPDATE', @units)

	END ELSE BEGIN

		SET @temp_cc_amt = 0
		SET @temp_nc_amt = 0 
		SET @temp_ac_amt = 0

		exec dbo.advsp_med_calc_print @order_type  OUTPUT, @units  OUTPUT, @start_date  OUTPUT, @end_date  OUTPUT, @tax_city_pct  OUTPUT, @tax_county_pct  OUTPUT, @tax_state_pct  OUTPUT, 
			@tax_resale  OUTPUT, @taxapplyc  OUTPUT, @taxapplyln  OUTPUT, @taxapplynd  OUTPUT, @taxapplync  OUTPUT, @taxapplyr  OUTPUT, @taxapplyai  OUTPUT, @comm_pct  OUTPUT, 
			@markup_pct  OUTPUT, @rebate_pct  OUTPUT, @discount_pct  OUTPUT, @net_gross  OUTPUT, @cost_type  OUTPUT, @cost_rate  OUTPUT, @rate_type  OUTPUT, @rate  OUTPUT, @net_rate  OUTPUT, 
			@gross_rate  OUTPUT, @ext_net_amt  OUTPUT, @ext_gross_amt  OUTPUT, @comm_amt  OUTPUT, @rebate_amt  OUTPUT, @discount_amt  OUTPUT, @discount_desc  OUTPUT, @state_amt  OUTPUT, 
			@county_amt  OUTPUT, @city_amt  OUTPUT, @non_resale_amt  OUTPUT, @netcharge  OUTPUT, @ncdesc  OUTPUT, @addl_charge  OUTPUT, @addl_charge_desc  OUTPUT, @rebate_amt_override  OUTPUT, 
			@rebate_pct_override  OUTPUT, @markup_pct_override  OUTPUT, @comm_pct_override  OUTPUT, @ext_net_amt_override  OUTPUT, @comm_pct_or  OUTPUT, @markup_pct_or  OUTPUT, @rebate_pct_or  OUTPUT, 
			@rebate_amt_or  OUTPUT, @temp_cc_amt  OUTPUT, @temp_nc_amt  OUTPUT, @temp_ac_amt  OUTPUT, @quantity  OUTPUT, @print_columns  OUTPUT, @print_inches  OUTPUT, @print_lines  OUTPUT, 
			@np_circulation  OUTPUT, @print_quantity  OUTPUT, @state_tax  OUTPUT, @county_tax  OUTPUT, @city_tax  OUTPUT, @billing_amt  OUTPUT, @line_total  OUTPUT, @column_line_qty  OUTPUT, 
			@cpm  OUTPUT, @overage_pct  OUTPUT, @bill_type_flag  OUTPUT, @temp_net_gross  OUTPUT, @g_charge  OUTPUT, @n_charge  OUTPUT, @d_temp  OUTPUT, @proj_impressions  OUTPUT, @guaranteed_impress  OUTPUT, 
			@target_audience  OUTPUT, @creative_size  OUTPUT, @placement_1  OUTPUT, @placement_2  OUTPUT, @act_impressions  OUTPUT, @prc_status  OUTPUT, @size  OUTPUT, @edition_issue  OUTPUT, 
			@material  OUTPUT, @section  OUTPUT, @rate_card_id  OUTPUT, @rate_dtl_id  OUTPUT, @contract_qty  OUTPUT, @flat_net  OUTPUT, @flat_gross  OUTPUT, @prod_charge  OUTPUT, @prod_desc  OUTPUT, 
			@color_charge  OUTPUT, @color_desc  OUTPUT, @flat_netcharge  OUTPUT, @flat_addl_charge  OUTPUT, @flat_discount_amt  OUTPUT, @bleed_pct  OUTPUT, @bleed_amt  OUTPUT, @position_pct  OUTPUT, 
			@position_amt  OUTPUT, @premium_pct  OUTPUT, @premium_amt  OUTPUT, @net_base_rate  OUTPUT, @gross_base_rate  OUTPUT, @state_rnd  OUTPUT, @county_rnd  OUTPUT, @city_rnd  OUTPUT, @ven_rnd  OUTPUT, 
			@state_ac  OUTPUT, @county_ac  OUTPUT, @city_ac  OUTPUT, @ven_tax  OUTPUT, @addl_charge_taxes  OUTPUT, @resale_tax_amt  OUTPUT, @sales_tax_amt  OUTPUT, @bill_amt  OUTPUT, @error_msg_w  OUTPUT,
			@override_non_resale_amt, @override_rates, @strata_net_calc
		
	END
		
	IF @debug = 1
		SELECT 'AFT EXEC' '-', @gross_rate '@gross_rate', @net_rate '@net_rate', @net_gross '@net_gross', @quantity '@quantity', 
			@ext_net_amt '@ext_net_amt', @ext_gross_amt '@ext_gross_amt', @flat_net 'flat_net', @flat_gross 'flat_gross', @addl_charge '@addl_charge', @net_base_rate '@net_base_rate'       /* DEBUG */
	
	IF @error_msg_w <> '' BEGIN

		GOTO ERROR_MSG
		SET @ret_val = 1

	END ELSE BEGIN

		SET @ret_val = 0

	END
			
	IF @net_gross = 1
		SET @rate_out = @gross_rate 
	ELSE BEGIN
	IF @order_type_in = 'I'
		SET @rate_out = @net_base_rate
	ELSE
		SET @rate_out = @net_rate 
	END

	SET @gross_amount_out = @ext_gross_amt	
	SET @net_amount_out = @ext_net_amt
	SET @nonresale_tax_out = @non_resale_amt
	SET @rebate_amount_out = @rebate_amt
	SET @commission_amount_out = @comm_amt
	SET @billable_amount_out = @billing_amt - @resale_tax_amt - @addl_charge_taxes
	SET @unbilled_amount_out = @billing_amt - @resale_tax_amt - @addl_charge_taxes - @billed_amount - @billed_amount_resale_tax
	SET @actual_impressions_out = @act_impressions
	SET @netcharge_out = @netcharge
	SET @discount_out = @discount_amt
	SET @end_date_out = @new_end_date

	IF @calculate_only = 1
		GOTO ENDIT

	SET @is_quote = @status

	SET @order_desc = @new_order_description
	SET @client_po = @new_client_po_number
	SET @buyer = @new_buyer
	SET @buyer_emp_code = @new_buyer_emp_code
	SET @start_date = @new_start_date
	SET @end_date = @new_end_date
	SET @cmp_identifier = @new_campaign_id
	SET @market_code = @new_market_code

	IF @cmp_identifier IS NULL
		SET @cmp_code = NULL
	ELSE
		SELECT @cmp_code = CMP_CODE FROM dbo.CAMPAIGN WHERE CMP_IDENTIFIER = @cmp_identifier
	
	/* TV, Radio Dates & Spots */

	-- 09-24-2019 MJC - we do not need this from MM!
	--IF @media_type_in IN ('T','R') BEGIN
	
	--	SET @cal_type = @buy_type

	--	SELECT @month_nbr=null, @year_nbr=null, @date1=null, @date2=null, @date3=null, @date4=null, @date5=null, @date6=null, @date7=null

	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK1, DATEADD(d, 6, JAN_WK1) JAN_WK1_END , LEFT('JAN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK2, DATEADD(d, 6, JAN_WK2) JAN_WK2_END , LEFT('JAN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK3, DATEADD(d, 6, JAN_WK3) JAN_WK3_END , LEFT('JAN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK4, DATEADD(d, 6, JAN_WK4) JAN_WK4_END , LEFT('JAN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK5, DATEADD(d, 6, JAN_WK5) JAN_WK5_END , LEFT('JAN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK1, DATEADD(d, 6, FEB_WK1) FEB_WK1_END , LEFT('FEB_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK2, DATEADD(d, 6, FEB_WK2) FEB_WK2_END , LEFT('FEB_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK3, DATEADD(d, 6, FEB_WK3) FEB_WK3_END , LEFT('FEB_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK4, DATEADD(d, 6, FEB_WK4) FEB_WK4_END , LEFT('FEB_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK5, DATEADD(d, 6, FEB_WK5) FEB_WK5_END , LEFT('FEB_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK1, DATEADD(d, 6, MAR_WK1) MAR_WK1_END , LEFT('MAR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK2, DATEADD(d, 6, MAR_WK2) MAR_WK2_END , LEFT('MAR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK3, DATEADD(d, 6, MAR_WK3) MAR_WK3_END , LEFT('MAR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK4, DATEADD(d, 6, MAR_WK4) MAR_WK4_END , LEFT('MAR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK5, DATEADD(d, 6, MAR_WK5) MAR_WK5_END , LEFT('MAR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK1, DATEADD(d, 6, APR_WK1) APR_WK1_END , LEFT('APR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK2, DATEADD(d, 6, APR_WK2) APR_WK2_END , LEFT('APR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK3, DATEADD(d, 6, APR_WK3) APR_WK3_END , LEFT('APR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK4, DATEADD(d, 6, APR_WK4) APR_WK4_END , LEFT('APR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK5, DATEADD(d, 6, APR_WK5) APR_WK5_END , LEFT('APR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK1, DATEADD(d, 6, MAY_WK1) MAY_WK1_END , LEFT('MAY_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK2, DATEADD(d, 6, MAY_WK2) MAY_WK2_END , LEFT('MAY_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK3, DATEADD(d, 6, MAY_WK3) MAY_WK3_END , LEFT('MAY_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK4, DATEADD(d, 6, MAY_WK4) MAY_WK4_END , LEFT('MAY_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK5, DATEADD(d, 6, MAY_WK5) MAY_WK5_END , LEFT('MAY_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK1, DATEADD(d, 6, JUN_WK1) JUN_WK1_END , LEFT('JUN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK2, DATEADD(d, 6, JUN_WK2) JUN_WK2_END , LEFT('JUN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK3, DATEADD(d, 6, JUN_WK3) JUN_WK3_END , LEFT('JUN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK4, DATEADD(d, 6, JUN_WK4) JUN_WK4_END , LEFT('JUN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK5, DATEADD(d, 6, JUN_WK5) JUN_WK5_END , LEFT('JUN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK1, DATEADD(d, 6, JUL_WK1) JUL_WK1_END , LEFT('JUL_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK2, DATEADD(d, 6, JUL_WK2) JUL_WK2_END , LEFT('JUL_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK3, DATEADD(d, 6, JUL_WK3) JUL_WK3_END , LEFT('JUL_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK4, DATEADD(d, 6, JUL_WK4) JUL_WK4_END , LEFT('JUL_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK5, DATEADD(d, 6, JUL_WK5) JUL_WK5_END , LEFT('JUL_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK1, DATEADD(d, 6, AUG_WK1) AUG_WK1_END , LEFT('AUG_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK2, DATEADD(d, 6, AUG_WK2) AUG_WK2_END , LEFT('AUG_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK3, DATEADD(d, 6, AUG_WK3) AUG_WK3_END , LEFT('AUG_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK4, DATEADD(d, 6, AUG_WK4) AUG_WK4_END , LEFT('AUG_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK5, DATEADD(d, 6, AUG_WK5) AUG_WK5_END , LEFT('AUG_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK1, DATEADD(d, 6, SEP_WK1) SEP_WK1_END , LEFT('SEP_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK2, DATEADD(d, 6, SEP_WK2) SEP_WK2_END , LEFT('SEP_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK3, DATEADD(d, 6, SEP_WK3) SEP_WK3_END , LEFT('SEP_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK4, DATEADD(d, 6, SEP_WK4) SEP_WK4_END , LEFT('SEP_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK5, DATEADD(d, 6, SEP_WK5) SEP_WK5_END , LEFT('SEP_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK1, DATEADD(d, 6, OCT_WK1) OCT_WK1_END , LEFT('OCT_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK2, DATEADD(d, 6, OCT_WK2) OCT_WK2_END , LEFT('OCT_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK3, DATEADD(d, 6, OCT_WK3) OCT_WK3_END , LEFT('OCT_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK4, DATEADD(d, 6, OCT_WK4) OCT_WK4_END , LEFT('OCT_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK5, DATEADD(d, 6, OCT_WK5) OCT_WK5_END , LEFT('OCT_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK1, DATEADD(d, 6, NOV_WK1) NOV_WK1_END , LEFT('NOV_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK2, DATEADD(d, 6, NOV_WK2) NOV_WK2_END , LEFT('NOV_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK3, DATEADD(d, 6, NOV_WK3) NOV_WK3_END , LEFT('NOV_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK4, DATEADD(d, 6, NOV_WK4) NOV_WK4_END , LEFT('NOV_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK5, DATEADD(d, 6, NOV_WK5) NOV_WK5_END , LEFT('NOV_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK5 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK1, DATEADD(d, 6, DEC_WK1) DEC_WK1_END , LEFT('DEC_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK1 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK2, DATEADD(d, 6, DEC_WK2) DEC_WK2_END , LEFT('DEC_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK2 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK3, DATEADD(d, 6, DEC_WK3) DEC_WK3_END , LEFT('DEC_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK3 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK4, DATEADD(d, 6, DEC_WK4) DEC_WK4_END , LEFT('DEC_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK4 > @cutoff_dt
	--	INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK5, DATEADD(d, 6, DEC_WK5) DEC_WK5_END , LEFT('DEC_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK5 > @cutoff_dt

	--	INSERT INTO @brdcast_weeks2
	--	SELECT 
	--		BRD_YEAR, 
	--		MONTH(CAST(MONTH_NAME + ' 1 2001' AS smalldatetime)) BRD_MONTH, 
	--		BRD_WEEK_START, 
	--		BRD_WEEK_END, 
	--		MONTH_NAME, 
	--		RANK() OVER (PARTITION BY BRD_YEAR, MONTH_NAME 
	--					ORDER BY BRD_YEAR, BRD_WEEK_START) AS WEEK_NBR,
	--		RIGHT('00' + CAST(MONTH(CAST(MONTH_NAME + ' 1 2001' AS smalldatetime)) AS varchar(2)), 2) + CAST(BRD_YEAR AS varchar(4)) AS MMYYYY
	--	FROM @brdcast_weeks 
	--	ORDER BY BRD_YEAR, BRD_MONTH, BRD_WEEK_START

	--	DECLARE @temp_date smalldatetime, @temp_mmyyyy varchar(6)

	--	SET @temp_date = @start_date

	--	IF ISDATE(@date1) = 0 BEGIN /* Dates not provided so calculate */
	--		IF @cal_type IN ('BM','DB') BEGIN
	--			SELECT @date1 = A.BRD_WEEK_START, @month_nbr = A.BRD_MONTH, @year_nbr = A.BRD_YEAR FROM @brdcast_weeks2 A
	--			WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
	--			IF ISDATE(@date1) = 1 SET @date1 = @temp_date /* First date should be the Start Date */
				
	--			IF @DEBUG = 1
	--				SELECT @date1 'Validated - @date1' 

	--			IF @date1 IS NOT NULL 
	--				SET @temp_date = DATEADD(d, 7, @temp_date)
	--			ELSE
	--				SET @spots1 = 0
	--			IF @temp_date <= @end_date BEGIN
	--				SELECT @date2 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
	--				WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
	--				IF @date2 IS NOT NULL 
	--					SET @temp_date = DATEADD(d, 7, @temp_date)
	--				ELSE
	--					SET @spots2 = 0
	--			END
	--			IF @temp_date <= @end_date BEGIN
	--				SELECT @date3 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
	--				WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
	--				IF @date3 IS NOT NULL 
	--					SET @temp_date = DATEADD(d, 7, @temp_date)
	--				ELSE
	--					SET @spots3 = 0
	--			END
	--			IF @temp_date <= @end_date BEGIN
	--				SELECT @date4 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
	--				WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
	--				IF @date4 IS NOT NULL 
	--					SET @temp_date = DATEADD(d, 7, @temp_date)
	--				ELSE
	--					SET @spots4 = 0
	--			END
	--			IF @temp_date <= @end_date BEGIN
	--				SELECT @date5 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
	--				WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
	--				IF @date5 IS NOT NULL 
	--					SET @temp_date = DATEADD(d, 7, @temp_date)
	--				ELSE
	--					SET @spots5 = 0
	--			END
	--			IF @temp_date <= @end_date BEGIN
	--				SELECT @date6 = A.BRD_WEEK_START FROM @brdcast_weeks2 A
	--				WHERE @temp_date BETWEEN A.BRD_WEEK_START AND A.BRD_WEEK_END 
	--			END
	--		END
	--	END
		
	--	--SELECT @start_date '@start_date' , @date1 '@date1', @date2 '@date2', @date3 '@date3', @date4 '@date4', @date5 '@date5', @date6 '@date6', @month_nbr'@month_nbr', @year_nbr '@year_nbr'  /* DEBUG */

	--	DELETE @bc_spots_table /* Clear any existing data */

	--	SET @p1_52 = RIGHT('   ' + cast(@new_spots as varchar), 3)

	--	INSERT INTO @bc_spots_table SELECT * FROM advtf_med_import_brdcast_weeks (
	--	@order_type,
	--	@start_date,
	--	@end_date,
	--	@date1,
	--	@date2,
	--	@date3,
	--	@date4,
	--	@date5,
	--	@date6,
	--	@p1_52,
	--	@cal_type)

	--	SELECT @spots1 = BC_SPOTS1, @spots2 = BC_SPOTS2, @spots3 = BC_SPOTS3, @spots4 = BC_SPOTS4, @spots5 = BC_SPOTS5, @spots6 = BC_SPOTS6,
	--			@date1 = BC_DATE1, @date2 = BC_DATE2, @date3 = BC_DATE3, @date4 = BC_DATE4, @date5 = BC_DATE5, @date6 = BC_DATE6,
	--			@temp_mmyyyy = BC_MMYYYY
	--	FROM @bc_spots_table	

	--	--IF @DEBUG = 1
	--	--	SELECT @date1 'After advtf_med_import_brdcast_weeks() - @date1' 

	--	----SELECT @start_date '@start_date' , @date1 '@date1', @date2 '@date2', @date3 '@date3', @date4 '@date4', @date5 '@date5', @date6 '@date6', @month_nbr'@month_nbr', @year_nbr '@year_nbr'  /* DEBUG */
		
	--	SET @spots7 = 0 /* 7 Not Used */		

	--	--IF @cal_type IN ('BM','DB') BEGIN
	--	--	IF @DEBUG = 1
	--	--		SELECT @date1 'Validated - @spots w/@dates' 			
	--	--	IF COALESCE(@spots1, 0) = 0 SET @date1 = NULL
	--	--	IF COALESCE(@spots2, 0) = 0 SET @date2 = NULL
	--	--	IF COALESCE(@spots3, 0) = 0 SET @date3 = NULL
	--	--	IF COALESCE(@spots4, 0) = 0 SET @date4 = NULL
	--	--	IF COALESCE(@spots5, 0) = 0 SET @date5 = NULL
	--	--	IF COALESCE(@spots6, 0) = 0 SET @date6 = NULL
	--	--	IF COALESCE(@spots7, 0) = 0 SET @date7 = NULL

	--	--END
		
	--	IF @cal_type = 'BM' BEGIN	
	--		SET @temp_date = @end_date
			
	--		SELECT @end_date = MAX(A.BRD_WEEK_END) FROM @brdcast_weeks2 A
	--		WHERE A.BRD_MONTH = @month_nbr AND A.BRD_YEAR = @year_nbr 
	--	END	

	--	IF @cal_type = 'DB' BEGIN	
	--		SET @month_nbr = @month_nbr
	--		SET @year_nbr = @year_nbr
	--	END

	--	SET @total_spots = @spots1+@spots2+@spots3+@spots4+@spots5+@spots6

	--	IF @total_spots <> (@spots1+@spots2+@spots3+@spots4+@spots5+@spots6) BEGIN
	--		SET @error_msg_w = 'Total spots is not equal to the sum of the spots by period! ' + @ret_val_s
	--		GOTO ERROR_MSG
	--	END 
		
	--	IF @cal_type = 'CM' BEGIN	
	--		SET @month_nbr = CAST(LEFT(@temp_mmyyyy,2) AS int)
	--		SET @year_nbr = CAST(RIGHT(@temp_mmyyyy,4) AS int)
	--	END	
	
	--END		/* End TV, Radio Dates & Spots */											
	
	EXECUTE @RC = [dbo].[advsp_revise_order_detail] @user_id, @action, @order_type, @order_type_chg   
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
		,@proj_impressions  ,@guaranteed_impress,  @act_impressions, @target_audience  ,@creative_size
		,@placement_1  ,@placement_2, @prc_status
		,@ad_server_placement_id, @ad_server_created_by, @ad_server_created_datetime, @ad_server_last_modified_by, @ad_server_last_modified_datetime, @ad_server_placement_manual,
		@package_parent,
		@ad_server_placement_group_id,
		@cable_network_station_code, 
		@daypart_id,
		@added_value,
		@bookend,
		@link_line_number,
		NULL, --@is_quote
		@override_non_resale_amt,
		@override_rates = 1
		
	IF @ret_val <> 0 BEGIN
		SET @error_msg_w = 'Error updating Order Detail values! ' + @ret_val_s
		GOTO ERROR_MSG
	END 

	IF @order_type_in = 'I'
		SELECT @start_date = MIN([START_DATE]), @end_date = MAX(END_DATE) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1
	IF @order_type_in = 'M'
		SELECT @start_date = MIN([START_DATE]), @end_date = MAX(END_DATE) FROM dbo.MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1
	IF @order_type_in = 'N'
		SELECT @start_date = MIN([START_DATE]), @end_date = MAX(END_DATE) FROM dbo.NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1
	IF @order_type_in = 'O'
		SELECT @start_date = MIN(POST_DATE), @end_date = MAX(END_DATE) FROM dbo.OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1
	IF @order_type_in = 'R'
		SELECT @start_date = MIN([START_DATE]), @end_date = MAX(END_DATE) FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1
	IF @order_type_in = 'T'
		SELECT @start_date = MIN([START_DATE]), @end_date = MAX(END_DATE) FROM dbo.TV_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1
	
	SET @bill_coop_code = @new_bill_coop_code

	EXECUTE [advsp_revise_order_header] @user_id, 'UPDATE', @order_type, @ret_val OUTPUT, @ret_val_s OUTPUT, 
		@order_nbr, @order_desc, @cl_code, @div_code, @prd_code, @office_code, @cmp_code, @media_type, @vn_code,
		@vr_code, @vr_code2, @client_po, @client_ref, @status,
		@order_date, @buyer, @order_comment, @house_comment,
		@pub_station, @rep1, @rep2, @bill_coop_code, @ord_process_contrl, @market_code, @start_date, @end_date,
		@units, @nbr_of_units, @net_gross, @create_date, @cancelled, @cancelled_by, @cancelled_date, @modified_by,
		@modified_date, @modified_comments, @revised_flag, @link_id, @reconcile_flag, @cmp_identifier, @printed,
		@order_accepted, @fiscal_period_code, @locked, @locked_by, @bcc_id, @is_quote, @new_buyer_emp_code

	IF @ret_val <> 0 BEGIN
		SET @error_msg_w = 'Error updating Order Header values! ' + @ret_val_s
		GOTO ERROR_MSG
	END 

	--IF @media_type_in =  'N' BEGIN
	--	SELECT @dtl_cmnt_exists = 1 FROM [dbo].[NEWSPAPER_COMMENTS] 
	--	WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
	--	IF @dtl_cmnt_exists = 0 BEGIN
	--		INSERT INTO [dbo].[NEWSPAPER_COMMENTS]
	--				   ([ORDER_NBR]
	--				   ,[LINE_NBR]
	--				   ,[INSTRUCTIONS]
	--				   ,[ORDER_COPY]
	--				   ,[MATL_NOTES]
	--				   ,[POSITION_INFO]
	--				   ,[CLOSE_INFO]
	--				   ,[RATE_INFO]
	--				   ,[MISC_INFO]
	--				   ,[IN_HOUSE_CMTS])
	--			 VALUES (
	--				@order_nbr 
	--				,@line_nbr 
	--				,@instructions 
	--				,@order_copy 
	--				,@matl_notes 
	--				,@position_info 
	--				,@close_info 
	--				,@rate_info 
	--				,@misc_info 
	--				,@in_house_cmts )
	--	END 
	--	ELSE BEGIN
	--		UPDATE [dbo].[NEWSPAPER_COMMENTS]
	--		SET	    [INSTRUCTIONS] = @instructions
	--				   ,[ORDER_COPY] = @order_copy
	--				   ,[MATL_NOTES] = @matl_notes
	--				   ,[POSITION_INFO] = @position_info
	--				   ,[CLOSE_INFO] = @close_info
	--				   ,[RATE_INFO] = @rate_info
	--				   ,[MISC_INFO] = @misc_info
	--				   ,[IN_HOUSE_CMTS] = @in_house_cmts
	--		WHERE [ORDER_NBR] = @order_nbr
	--			AND [LINE_NBR] = @line_nbr				   
	--	END
	--END
	--ELSE IF @media_type_in =  'M' BEGIN
	--	SELECT @dtl_cmnt_exists = 1 FROM [dbo].[MAGAZINE_COMMENTS] 
	--	WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
	--	IF @dtl_cmnt_exists = 0 BEGIN
	--		INSERT INTO [dbo].[MAGAZINE_COMMENTS]
	--				   ([ORDER_NBR]
	--				   ,[LINE_NBR]
	--				   ,[INSTRUCTIONS]
	--				   ,[ORDER_COPY]
	--				   ,[MATL_NOTES]
	--				   ,[POSITION_INFO]
	--				   ,[CLOSE_INFO]
	--				   ,[RATE_INFO]
	--				   ,[MISC_INFO]
	--				   ,[IN_HOUSE_CMTS])
	--			 VALUES (
	--				@order_nbr 
	--				,@line_nbr 
	--				,@instructions 
	--				,@order_copy 
	--				,@matl_notes 
	--				,@position_info 
	--				,@close_info 
	--				,@rate_info 
	--				,@misc_info 
	--				,@in_house_cmts )
	--	END 
	--	ELSE BEGIN
	--		UPDATE [dbo].[MAGAZINE_COMMENTS]
	--		SET	    [INSTRUCTIONS] = @instructions
	--				   ,[ORDER_COPY] = @order_copy
	--				   ,[MATL_NOTES] = @matl_notes
	--				   ,[POSITION_INFO] = @position_info
	--				   ,[CLOSE_INFO] = @close_info
	--				   ,[RATE_INFO] = @rate_info
	--				   ,[MISC_INFO] = @misc_info
	--				   ,[IN_HOUSE_CMTS] = @in_house_cmts
	--		WHERE [ORDER_NBR] = @order_nbr
	--			AND [LINE_NBR] = @line_nbr				   
	--	END
	--END
	--ELSE IF @media_type_in =  'I' BEGIN
	--	SELECT @dtl_cmnt_exists = 1 FROM [dbo].[INTERNET_COMMENTS] 
	--	WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
	--	IF @dtl_cmnt_exists = 0 BEGIN
	--		INSERT INTO [dbo].[INTERNET_COMMENTS]
	--				   ([ORDER_NBR]
	--				   ,[LINE_NBR]
	--				   ,[INSTRUCTIONS]
	--				   ,[ORDER_COPY]
	--				   ,[MATL_NOTES]
	--				   ,[MISC_INFO] )
	--			 VALUES (
	--				@order_nbr 
	--				,@line_nbr 
	--				,@instructions 
	--				,@order_copy 
	--				,@matl_notes 
	--				,@misc_info )
	--	END 
	--	ELSE BEGIN
	--		UPDATE [dbo].[INTERNET_COMMENTS]
	--		SET	    [INSTRUCTIONS] = @instructions
	--				   ,[ORDER_COPY] = @order_copy
	--				   ,[MATL_NOTES] = @matl_notes
	--				   ,[MISC_INFO] = @misc_info
	--		WHERE [ORDER_NBR] = @order_nbr
	--			AND [LINE_NBR] = @line_nbr				   
	--	END
	--END
	--ELSE IF @media_type_in =  'O' BEGIN
	--	SELECT @dtl_cmnt_exists = 1 FROM [dbo].[OUTDOOR_COMMENTS] 
	--	WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
	--	IF @copy_detail = 0 OR @dtl_cmnt_exists = 0 BEGIN
	--		INSERT INTO [dbo].[OUTDOOR_COMMENTS]
	--				   ([ORDER_NBR]
	--				   ,[LINE_NBR]
	--				   ,[INSTRUCTIONS]
	--				   ,[ORDER_COPY]
	--				   ,[MATL_NOTES]
	--				   ,[MISC_INFO] )
	--			 VALUES (
	--				@order_nbr 
	--				,@line_nbr 
	--				,@instructions 
	--				,@order_copy 
	--				,@matl_notes 
	--				,@misc_info )
	--	END 
	--	ELSE BEGIN
	--		UPDATE [dbo].[OUTDOOR_COMMENTS]
	--		SET	    [INSTRUCTIONS] = @instructions
	--				   ,[ORDER_COPY] = @order_copy
	--				   ,[MATL_NOTES] = @matl_notes
	--				   ,[MISC_INFO] = @misc_info
	--		WHERE [ORDER_NBR] = @order_nbr
	--			AND [LINE_NBR] = @line_nbr				   
	--	END
	--END
	--ELSE IF @media_type_in =  'T' BEGIN
	--	SELECT @dtl_cmnt_exists = 1 FROM [dbo].[TV_COMMENTS] 
	--	WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
				
	--	IF @copy_detail = 0 OR @dtl_cmnt_exists = 0 BEGIN
	--		INSERT INTO [dbo].[TV_COMMENTS]
	--				   ([ORDER_NBR]
	--				   ,[LINE_NBR]
	--				   ,[INSTRUCTIONS]
	--				   ,[ORDER_COPY]
	--				   ,[POSITION_INFO]
	--				   ,[CLOSE_INFO]
	--				   ,[RATE_INFO]					   
	--				   ,[MATL_NOTES]
	--				   ,[MISC_INFO] )
	--			 VALUES (
	--				@order_nbr 
	--				,@line_nbr 
	--				,@instructions 
	--				,@order_copy 
	--				,@position_info 
	--				,@close_info 
	--				,@rate_info 					
	--				,@matl_notes 
	--				,@misc_info )
	--	END 
	--	ELSE BEGIN
	--		UPDATE [dbo].[TV_COMMENTS]
	--		SET	    [INSTRUCTIONS] = @instructions
	--				   ,[ORDER_COPY] = @order_copy
	--				   ,[MATL_NOTES] = @matl_notes
	--				   ,[POSITION_INFO] = @position_info
	--				   ,[CLOSE_INFO] = @close_info
	--				   ,[RATE_INFO] = @rate_info					   
	--				   ,[MISC_INFO] = @misc_info
	--		WHERE [ORDER_NBR] = @order_nbr
	--			AND [LINE_NBR] = @line_nbr				   
	--	END
	--END
	--ELSE IF @media_type_in =  'R' BEGIN
	--	SELECT @dtl_cmnt_exists = 1 FROM [dbo].[RADIO_COMMENTS] 
	--	WHERE [ORDER_NBR]= @order_nbr AND [LINE_NBR] = @line_nbr
		
	--	IF @copy_detail = 0 OR @dtl_cmnt_exists = 0 BEGIN
	--		INSERT INTO [dbo].[RADIO_COMMENTS]
	--				   ([ORDER_NBR]
	--				   ,[LINE_NBR]
	--				   ,[INSTRUCTIONS]
	--				   ,[ORDER_COPY]
	--				   ,[POSITION_INFO]
	--				   ,[CLOSE_INFO]
	--				   ,[RATE_INFO]					   
	--				   ,[MATL_NOTES]
	--				   ,[MISC_INFO] )
	--			 VALUES (
	--				@order_nbr 
	--				,@line_nbr 
	--				,@instructions 
	--				,@order_copy 
	--				,@position_info 
	--				,@close_info 
	--				,@rate_info 					
	--				,@matl_notes 
	--				,@misc_info )
	--	END 
	--	ELSE BEGIN
	--		UPDATE [dbo].[RADIO_COMMENTS]
	--		SET	    [INSTRUCTIONS] = @instructions
	--				   ,[ORDER_COPY] = @order_copy
	--				   ,[MATL_NOTES] = @matl_notes
	--				   ,[POSITION_INFO] = @position_info
	--				   ,[CLOSE_INFO] = @close_info
	--				   ,[RATE_INFO] = @rate_info					   
	--				   ,[MISC_INFO] = @misc_info
	--		WHERE [ORDER_NBR] = @order_nbr
	--			AND [LINE_NBR] = @line_nbr				   
	--	END
	--END

	NEXT_ROW:

	SET @ROW_ID = @ROW_ID + 1

END /* While */

IF @@TRANCOUNT > 0
	IF @debug = 1 BEGIN
		SELECT 'ROLLBACK' 'DEBUG', @order_type '@order_type'

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

/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			--ROLLBACK TRAN			
			--SELECT @error_msg_w as ErrorMessage
			
			SELECT 'PROCESS ERROR CONTROL'  /* DEBUG */	
			
			SET @ret_val_s = @error_msg_w
			
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH
	DECLARE @xstate int
	SELECT @xstate = XACT_STATE()

	IF @xstate = -1
		ROLLBACK TRAN
	IF @xstate = 1 AND @@TRANCOUNT > 0 BEGIN
		SELECT 'PROCESS ERROR ROLLBACK', @@TRANCOUNT '@@TRANCOUNT'  /* DEBUG */	
		ROLLBACK TRAN --TP1
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage
	
	SELECT @ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE(),
					@ret_val=ERROR_NUMBER()
	SET @ret_val_s = @ErMessage
	
	SELECT 	@ret_val 'ERROR_NBR', @ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */	

END CATCH

RETURN

GO

GRANT EXECUTE ON [advsp_revise_order_media_mgr] TO PUBLIC
GO