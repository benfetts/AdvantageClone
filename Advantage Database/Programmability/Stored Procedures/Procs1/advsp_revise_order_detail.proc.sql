IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_revise_order_detail]') AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_revise_order_detail]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
***********************************************************************************************************
PJH 10/13/15 - Ad Size, Ad No, URL, Headline, Placement, INET & OOH Type, Job & Comp - verified
PJH 10/13/15 - Impressions, Comments - Verified
PJH 11/17/15 - Added TV processing
PJH 11/25/15 - Added RADIO processing & tested TV/Radio
PJH 11/30/15 - Set here for @date_to_bill calc
PJH 01/11/16 - Updated calls to advtf_med_calc_cost_rate
MJC 01/20/16 - broke out blocks of code into advsp_med_calc_print and advsp_med_calc_brdcast
PJH 01/25/16 - Commented code related to *_ORDER_STATUS
PJH 02/04/16 - Only get new dates if start date changes or key dates are null
PJH 02/12/16 - Added check for billing selection - Force revision
PJH 03/01/16 - Tweaking NEWSPAPER_OTH_CHGS logic
MJC 03/07/16 - Tweaking NEWSPAPER_OTH_CHGS logic - changed to insert when amount <> 0 rather than just > 0
MJC 03/22/16 - fixed updates to RADIO_DETAIL and TV_DETAIL to use @end_time and @buy_type
MJC 03/23/16 - keep @end_date passed in and when @override_rates = 1 keep matl_close_date and @close_date
MJC 04/07/16 - @date_to_bill not updating via parameter passed in - only set when null
MJC 05/06/16 - (Media Manager - Allow Actual Impressions to be editable) affected REVISE block
MJC 06/17/16 - added OUTDOOR_TYPE to UPDATE statement for OUTDOOR_DETAIL
PJH 03/13/17 - Added AD Server columns
PJH 08/18/17 - Added support for 'AW' imports - 'BROADCAST WORKSHEET'
PJH 08/18/17 - added new column LINK_LINE_NUMBER
PJH 12/12/17 - Update Internet Detail with PACKAGE_PARENT & PACKAGE_NAME
PJH 05/03/18 - Adding support for legacy imports (starting with Strata TV/Radio) - @@@@@@@@@@
PJH 08/14/18 - added check for previously cancelled lines
PJH 08/14/18 - tweaked logic for [BILL_CANCELLED] / @bill_cancelled
PJH 01/24/19 - Changed @bcc_id to int
PJH 03/22/19 - Added @guaranteed_impress=[IMPRESSIONS], @act_impressions=[ACTUAL_IMPRESSIONS]
PJH 06/05/20 - [STATION_ID] can only be added/updated through advsp_revise_order_detail
***********************************************************************************************************
*/

CREATE PROCEDURE [dbo].[advsp_revise_order_detail] 
@user_id varchar(100), @action varchar(10), @order_type varchar(2), @order_type_chg smallint, 
@rebate_amt_override smallint, @rebate_pct_override smallint, @markup_pct_override smallint, @comm_pct_override smallint,
--@addl_amt_override smallint, @nc_amt_override smallint,
@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT, 
--all
@order_nbr int,
@line_nbr smallint = NULL,
@rev_nbr smallint = NULL,
@seq_nbr smallint = NULL,
@active_rev smallint = NULL,
@link_detid int = NULL,
@start_date smalldatetime = NULL,
@end_date smalldatetime = NULL,
@close_date smalldatetime = NULL,
@matl_close_date smalldatetime = NULL,
@ext_close_date smalldatetime = NULL,
@ext_matl_date smalldatetime = NULL,

--tv/ra
@buy_type varchar (2) = NULL,
@month_nbr smallint = NULL,
@year_nbr smallint = NULL,
@date1 smalldatetime = NULL,
@date2 smalldatetime = NULL,
@date3 smalldatetime = NULL,
@date4 smalldatetime = NULL,
@date5 smalldatetime = NULL,
@date6 smalldatetime = NULL,
@date7 smalldatetime = NULL,
@monday smallint = NULL,
@tuesday smallint = NULL,
@wednesday smallint = NULL,
@thursday smallint = NULL,
@friday smallint = NULL,
@saturday smallint = NULL,
@sunday smallint = NULL,
@spots1 int = NULL,
@spots2 int = NULL,
@spots3 int = NULL,
@spots4 int = NULL,
@spots5 int = NULL,
@spots6 int = NULL,
@spots7 int = NULL,
@total_spots int = NULL,

--all
@job_number int = NULL,
@job_component_nbr smallint = NULL,
@quantity int = NULL,
@rate decimal (16, 4) = NULL,
@net_rate decimal (16, 4) = NULL,
@gross_rate decimal (16, 4) = NULL,
@ext_net_amt decimal (15, 2) = NULL,
@ext_gross_amt decimal (15, 2) = NULL,
@comm_amt decimal (14, 2) = NULL,
@rebate_amt decimal (14, 2) = NULL,
@discount_amt decimal (14, 2) = NULL,
@discount_desc varchar (30) = NULL,
@state_amt decimal (14, 2) = NULL,
@county_amt decimal (14, 2) = NULL,
@city_amt decimal (14, 2) = NULL,
@non_resale_amt decimal (14, 2) = NULL,
@netcharge decimal (14, 2) = NULL,
@ncdesc varchar (30) = NULL,
@addl_charge decimal (14, 2) = NULL,
@addl_charge_desc varchar (30) = NULL,
@line_total decimal (14, 2) = NULL,
--@line_cancelled smallint = NULL,
@date_to_bill smalldatetime = NULL,
--@billing_user varchar (100) = NULL,
--@ar_inv_nbr int = NULL,--@ar_type varchar (2) = NULL,--@ar_inv_seq smallint = NULL,--@glexact int = NULL,
--@gleseq_sales smallint = NULL,--@gleseq_cos smallint = NULL,--@gleseq_wip smallint = NULL,--@gleseq_state smallint = NULL,
--@gleseq_county smallint = NULL,--@gleseq_city smallint = NULL,--@glexact_def int = NULL,--@glacode_sales varchar (30) = NULL,
--@glacode_cos varchar (30) = NULL,--@glacode_wip varchar (30) = NULL,--@glacode_state varchar (30) = NULL,
--@glacode_county varchar (30) = NULL,--@glacode_city varchar (30) = NULL,
@non_bill_flag smallint = NULL,
@modified_by varchar (100) = NULL,
@modified_date smalldatetime = NULL,
@modified_comments varchar (254) = NULL,
@bill_type_flag smallint = NULL,
@comm_pct decimal (14, 6) = NULL,
@markup_pct decimal (14, 6) = NULL,
@rebate_pct decimal (14, 6) = NULL,
@discount_pct decimal (14, 6) = NULL,
@tax_code varchar (4) = NULL,
@tax_city_pct decimal (14, 6) = NULL,
@tax_county_pct decimal (14, 6) = NULL,
@tax_state_pct decimal (14, 6) = NULL,
@tax_resale smallint = NULL,
@taxapplyc smallint = NULL,
@taxapplyln smallint = NULL,
@taxapplynd smallint = NULL,
@taxapplync smallint = NULL,
@taxapplyr smallint = NULL,
@taxapplyai smallint = NULL,
@reconcile_flag smallint = NULL,
--@gleseq_sales_def smallint = NULL,--@gleseq_cos_def smallint = NULL,
--@glacode_sales_def varchar (30) = NULL,--@glacode_cos_def varchar (30) = NULL,
@billing_amt decimal (14, 2) = NULL,
--@bill_cancelled smallint = NULL,
@est_nbr int = NULL,
@est_line_nbr smallint = NULL,
@est_rev_nbr smallint = NULL,
@ad_number varchar (30) = NULL,		-- not MA
@mat_comp smalldatetime = NULL,
@units varchar(2),

--tv/ra
@cost_type varchar (3) = NULL,		-- +NP
@cost_rate decimal (16, 4) = NULL,	-- +NP
@net_base_rate decimal (16, 4) = NULL,
@gross_base_rate decimal (16, 4) = NULL,
@programming varchar (50) = NULL,
@start_time varchar (10) = NULL,
@end_time varchar (10) = NULL,
@length smallint = NULL,
@remarks varchar (254) = NULL,
@tag varchar (10) = NULL,
@network_id varchar (10) = NULL,

--all non-brdcast
@headline varchar (60) = NULL,

--ma/np
@size varchar (30) = NULL,
@edition_issue varchar (30) = NULL,
@material varchar (60) = NULL,
@section varchar (30) = NULL,
@rate_card_id int = NULL,
@rate_dtl_id smallint = NULL,
@contract_qty decimal (14, 4) = NULL,
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
@np_circulation int = NULL, --**added 05/04/15
@print_quantity decimal (14, 3) = NULL, --**added 05/04/15

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

--in/od
@o_type varchar (6) = NULL,		--internet_type / outdoor_type
@url_location varchar (60) = NULL,	--url / location
@copy_area varchar (40) = NULL,
@rate_card varchar (10) = NULL,
@rate_type varchar(3) = NULL,
@rate_desc varchar (10) = NULL,

--in/out
@proj_impressions int = NULL, 
@guaranteed_impress int = NULL, 
@act_impressions int = NULL,

--in
@target_audience varchar (60) = NULL, 
@creative_size varchar (60) = NULL,
@placement_1 varchar (256) = NULL,
@placement_2 varchar (160) = NULL,
@prc_status smallint = NULL,
@ad_server_placement_id bigint = NULL,	--PJH 03/13/17 - added
@ad_server_created_by varchar(100) = NULL,
@ad_server_created_datetime smalldatetime = NULL,
@ad_server_last_modified_by varchar(100) = NULL,
@ad_server_last_modified_datetime smalldatetime = NULL,
@ad_server_placement_manual bit = NULL, --MJC 04/25/17 - added
@package_parent bit,  --PJH 12/12/17 - added
@ad_server_placement_group_id bigint,

--PJH 08/18/17 - added new columns
--tv/ra
@cable_network_station_code varchar(10) = NULL, 
@daypart_id int = NULL,
@added_value bit = 0,
@bookend bit = 0,
--PJH 08/18/17 - added new column LINK_LINE_NUMBER
--tv/ra
@link_line_number int = NULL,

@is_quote varchar (max)  = NULL,
@override_non_resale_amt decimal (14, 2) = NULL,  -- if NULL, ignore, otherwise set to value
@override_rates bit = 0,

@ad_server_id smallint = NULL, --PJH 12/06/18 - Added @line_market_code, @ad_server_id
@line_market_code varchar(10) = NULL,

@strata_net_calc bit = 0,

@channel int = NULL, --PJH 02/14/20 - Added @channel & @tactic
@tactic int = NULL

AS

DECLARE @tv_detail_table TABLE (
	ORDER_NBR int,
	LINE_NBR smallint,
	REV_NBR smallint,
	SEQ_NBR smallint
)

/** MAIN VARS **/
DECLARE @table_prefix varchar(15), @table_name varchar(30)
DECLARE @billed smallint, @temp_cnt smallint, @rec_id smallint, @temp_nc_amt decimal(14,2), @temp_ac_amt decimal(14,2), @temp_cc_amt decimal(14,2)

SELECT @temp_nc_amt = 0, @temp_ac_amt = 0, @temp_cc_amt = 0, @temp_cnt = 0

/** OVERRIDE VARS **/
--@rebate_amt_override smallint, @rebate_pct_override smallint, @markup_pct_override smallint, @comm_pct_override smallint,
DECLARE @comm_pct_or decimal (14, 6), @markup_pct_or decimal (14, 6), @rebate_pct_or decimal (14, 6), @rebate_amt_or decimal (14, 2)

/** HEADER **/
DECLARE @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6), @office_code varchar(4), @cmp_code varchar(6), @vn_code varchar(6)
DECLARE @net_gross smallint, @locked varchar(1), @bcc_id int

DECLARE @line_cancelled smallint, @bill_cancelled smallint

DECLARE @sql varchar(500), @param_def varchar(500), @error_msg_w varchar(200), @units_w varchar(2)
DECLARE @date_time_w smalldatetime, @start_date_w smalldatetime
DECLARE @rr_msg_w varchar(100), @goto_id varchar(50)

/** Get the MAX REV & SEQ for a given ORDER/LINE **/
DECLARE @max_rev_nbr int, @max_seq_nbr int
DECLARE @offset_rev_nbr int, @offset_seq_nbr int
DECLARE @onset_rev_nbr int, @onset_seq_nbr int	

DECLARE @column_line_qty decimal (14, 3), @cpm int

/** CALC_PRINT vars **/
DECLARE @temp_net_gross varchar(2)
DECLARE @d_temp decimal(14,2), @ext_net_amt_override decimal(14,2)
DECLARE @g_charge decimal(14,2), @n_charge decimal(14,2)
DECLARE @state_rnd decimal(14,2), @county_rnd decimal(14,2), @city_rnd decimal(14,2), @ven_rnd decimal(14,2)		
DECLARE @state_ac decimal(14,4), @county_ac decimal(14,4), @city_ac decimal(14,4)
DECLARE @ven_tax decimal(14,4), @addl_charge_taxes decimal(14,4)
DECLARE @state_tax decimal(14,4), @county_tax decimal(14,4), @city_tax decimal(14,4)		
DECLARE @resale_tax_amt decimal (14, 4), @sales_tax_amt decimal (14, 4)
DECLARE @bill_amt decimal (14, 4)	
DECLARE @billing_user varchar(254), @ar_inv_nbr int

/** TV & RADIO **/
--DECLARE @station_id int

DECLARE @strata_4_week bit

/** PRODUCT **/
DECLARE @prd_bill_days int, @prd_bf_af int

/** VENDOR **/
DECLARE @overage_pct decimal(14,4)

DECLARE	@ErMessage nvarchar(2048),
					@ErSeverity int,
					@ErState int

DECLARE @DEBUG int

BEGIN TRY

	--SAVE TRAN TD1

	IF @action = 'NEW4' OR @action = 'REVISE4' BEGIN
		SET @strata_4_week = 1
		SET @action = LEFT(@action, LEN(@action) - 1) --'NEW'
	END

	IF @action = 'DEBUG'
		SET @DEBUG = 1
	ELSE
		SET @DEBUG = 0
	
	SET @ret_val = 0
	
	SET @billing_amt = COALESCE(@billing_amt, 0)		
	SET @line_total = COALESCE(@line_total, 0)	
	SET @ext_net_amt = COALESCE(@ext_net_amt, 0)	
	SET @discount_amt = COALESCE(@discount_amt, 0)	
	SET @netcharge = COALESCE(@netcharge, 0)	
	SET @ven_tax = COALESCE(@ven_tax, 0)	
	SET @sales_tax_amt = COALESCE(@sales_tax_amt, 0)	
	SET @addl_charge_taxes = COALESCE(@addl_charge_taxes, 0)					
	SET @addl_charge = COALESCE(@addl_charge, 0)		
	SET @comm_amt = COALESCE(@comm_amt, 0)		
	SET @rebate_amt = COALESCE(@rebate_amt, 0)	
	
	/** Check Overrides **/
	IF @comm_pct_override = 1 			
		SET @comm_pct_or = COALESCE(@comm_pct, 0)
	IF @markup_pct_override = 1 	
		SET @markup_pct_or = COALESCE(@markup_pct, 0)
	IF @rebate_pct_override = 1 	
		SET @rebate_pct_or = COALESCE(@rebate_pct, 0)	
	IF @rebate_amt_override = 1 	
		SET @rebate_amt_or = COALESCE(@rebate_amt, 0)	
		
	IF @prc_status IS NULL SET @prc_status = 0 /* Default to 0 */		
	
	--SELECT 'BEG AMTS', @billing_amt '@billing_amt', @line_total '@line_total', @ext_net_amt '@ext_net_amt', @discount_amt '@discount_amt', @netcharge '@netcharge', @ven_tax '@ven_tax',  /* DEBUG */
	--	@sales_tax_amt '@sales_tax_amt', @addl_charge_taxes '@addl_charge_taxes', @addl_charge '@addl_charge', @comm_amt '@comm_amt', @rebate_amt '@rebate_amt'		
	
	SET @modified_date = GETDATE() -- CURDATE()

	IF @order_type =  'IN'
		SET @table_prefix = 'INTERNET'
	IF @order_type =  'OD'
		SET @table_prefix = 'OUTDOOR'
	IF @order_type =  'NP'
		SET @table_prefix = 'NEWSPAPER'
	IF @order_type =  'MA'
		SET @table_prefix = 'MAGAZINE'		
	IF @order_type =  'RA'
		SET @table_prefix = 'RADIO'
	IF @order_type =  'TV'
		SET @table_prefix = 'TV'

	--PJH 02/04/16 - add @start_date_w = [START_DATE] to all and @line_cancelled = [LINE_CANCELLED] to all but NP (already there)
	IF @order_type = 'NP' BEGIN
		SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
				@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.NEWSPAPER_HEADER
		WHERE ORDER_NBR=@order_nbr;	
			
		SELECT @line_cancelled = [LINE_CANCELLED], @start_date_w = [START_DATE], @billing_user = [BILLING_USER], @ar_inv_nbr = AR_INV_NBR FROM dbo.NEWSPAPER_DETAIL
		WHERE ORDER_NBR=@order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1;
	END
	ELSE IF @order_type = 'MA' BEGIN
		SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
				@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.MAGAZINE_HEADER
		WHERE ORDER_NBR=@order_nbr;	
			
		SELECT @line_cancelled = [LINE_CANCELLED], @start_date_w = [START_DATE], @billing_user = [BILLING_USER], @ar_inv_nbr = AR_INV_NBR FROM dbo.MAGAZINE_DETAIL
		WHERE ORDER_NBR=@order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1;
	END
	ELSE IF @order_type = 'IN' BEGIN
		SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
				@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.INTERNET_HEADER
		WHERE ORDER_NBR=@order_nbr;	
			
		SELECT @line_cancelled = [LINE_CANCELLED], @start_date_w = [START_DATE], @billing_user = [BILLING_USER], @ar_inv_nbr = AR_INV_NBR FROM dbo.INTERNET_DETAIL
		WHERE ORDER_NBR=@order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1;
	END
	ELSE IF @order_type = 'OD' BEGIN
		SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
				@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.OUTDOOR_HEADER
		WHERE ORDER_NBR=@order_nbr;	
			
		SELECT @line_cancelled = [LINE_CANCELLED], @start_date_w = [POST_DATE], @billing_user = [BILLING_USER], @ar_inv_nbr = AR_INV_NBR FROM dbo.OUTDOOR_DETAIL
		WHERE ORDER_NBR=@order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1;
	END
	ELSE IF @order_type = 'TV'BEGIN
		SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
				@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.TV_HDR
		WHERE ORDER_NBR=@order_nbr;	
			
		SELECT @line_cancelled = [LINE_CANCELLED], @start_date_w = [START_DATE], @billing_user = [BILLING_USER], @ar_inv_nbr = AR_INV_NBR FROM dbo.TV_DETAIL
		WHERE ORDER_NBR=@order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1;
	END				
	ELSE IF @order_type = 'RA' BEGIN
		SELECT @cl_code=CL_CODE, @div_code=DIV_CODE, @prd_code=PRD_CODE, @office_code=OFFICE_CODE, @cmp_code=CMP_CODE, 
				@vn_code=VN_CODE, @net_gross=NET_GROSS, @locked=LOCKED, @bcc_id=BCC_ID, @units = UNITS FROM dbo.RADIO_HDR
		WHERE ORDER_NBR=@order_nbr;	
			
		SELECT @line_cancelled = [LINE_CANCELLED], @start_date_w = [START_DATE], @billing_user = [BILLING_USER], @ar_inv_nbr = AR_INV_NBR FROM dbo.RADIO_DETAIL
		WHERE ORDER_NBR=@order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1;
	END				

	--@units_w for NEWSPAPER_HEADER only
	
	SELECT @overage_pct = OVERAGE_PCT FROM VENDOR WHERE VN_CODE = @vn_code

	/* 
	RECALC, CANCEL, UNCANCEL, COPY, REVISE
	*/

	SET @error_msg_w = 'No error'
	SELECT @date_time_w=GETDATE()

	--IF (@action = 'RECALC' AND (@ar_inv_nbr IS NOT NULL))-
	--	BEGIN 
	--		SET @error_msg_w = 'Can''t modify a billed line.'
	--		GOTO ERROR_MSG
	--	END
		
	--DEBUG
	--SET @error_msg_w = 'Can''t modify a billed line.'
	--GOTO ERROR_MSG
		
	IF (@active_rev = NULL OR @active_rev = 0) BEGIN 
		SET @error_msg_w = 'Not an active revision line..'
		GOTO ERROR_MSG
	END	

	IF ((@action = 'CANCEL' OR @action = 'REVISE' OR @action = 'RECALC') AND @line_cancelled = 1) BEGIN 
		SET @error_msg_w = 'Can''t modify a cancelled line.'
		GOTO ERROR_MSG
	END
		
	IF (@action = 'RESTORE' AND (@line_cancelled = 0 OR @line_cancelled IS NULL)) BEGIN 
		SET @error_msg_w = 'Can''t restore a line that is not cancelled.'
		GOTO ERROR_MSG
	END	

	--PJH 02/12/16 - Added check for billing selection - Force revision
	IF @billing_user IS NOT NULL
		IF @action = 'UPDATE' OR @action = 'REVISE'
			SET @action = 'REVISE' /* Force Revision */
		ELSE BEGIN
			SET @error_msg_w = 'Can''t modify a line that is selected for billing.'
			GOTO ERROR_MSG
		END

	IF @ar_inv_nbr IS NOT NULL
		IF @action = 'UPDATE' OR @action = 'REVISE'
			SET @action = 'REVISE' /* Force Revision */
		ELSE BEGIN
			/* PJH 08/14/18 - added check for previously cancelled lines */
			IF @action <> 'CANCEL' BEGIN
				SET @error_msg_w = 'Can''t modify a line that has been billed.'
				GOTO ERROR_MSG
			END
		END

	--IF @DEBUG = 1
	--	SELECT @line_nbr 'LINE_NBR', @end_date '@end_date', @matl_close_date '@matl_close_date', @close_date '@close_date', @start_date_w '@start_date_w', @start_date '@start_date' /* DEBUG */
	
	IF @end_date IS NULL OR @matl_close_date IS NULL OR @close_date IS NULL OR @start_date_w <> @start_date
		IF @end_date IS NULL OR @start_date_w <> @start_date
			SELECT /*@start_date = [START_DATE],*/ @end_date = CASE WHEN @end_date IS NULL THEN [END_DATE] ELSE @end_date END, 
			@matl_close_date = CASE 
									WHEN @override_rates = 1 THEN @matl_close_date
									WHEN @matl_close_date IS NULL OR @start_date_w <> @start_date THEN [MATL_CLOSE_DATE] 
									ELSE @matl_close_date 
							   END,
			@close_date = CASE 
									WHEN @override_rates = 1 THEN @close_date
									WHEN @close_date IS NULL OR @start_date_w <> @start_date THEN [SPACE_CLOSE_DATE] 
									ELSE @close_date 
						  END
			FROM [advtf_med_set_dates](@order_type, @start_date, @rate_card_id, @net_gross, @vn_code, @action, NULL)
		ELSE	
			--PJH 02/04/16 - only call if a new start date
			SELECT
				@matl_close_date = CASE WHEN @override_rates = 1 THEN @matl_close_date ELSE [MATL_CLOSE_DATE] END,
				@close_date = CASE WHEN @override_rates = 1 THEN @close_date ELSE [SPACE_CLOSE_DATE] END
			FROM [advtf_med_set_dates](@order_type, @start_date, @rate_card_id, @net_gross, @vn_code, @action, NULL)
	
	--IF @DEBUG = 1
	--	SELECT @line_nbr 'LINE_NBR', @end_date '@end_date', @matl_close_date '@matl_close_date', @close_date '@close_date', @start_date_w '@start_date_w', @start_date '@start_date' /* DEBUG */
	
	IF @date_to_bill IS NULL 
		/* PJH 11/30/15 - Set here for @date_to_bill calc */
		SELECT @prd_bill_days = [PRD_DAYS], @prd_bf_af = [PRD_BF_AF] FROM [dbo].[advtf_med_get_prd_defaults] (
							@cl_code	,
							@div_code	,
							@prd_code	 ,
							@order_type ,
							'N/A' ,  --@media_type  or SC_CODE
							@action )	
							
	/* 12/22/15 - Added */
	DECLARE @tmp_date smalldatetime
	
	IF @prd_bf_af = 3 SET @tmp_date = @close_date
	ELSE SET @tmp_date = @start_date
	/* 12/22 */

	-- MJC 04/07/16 - @date_to_bill not updating via parameter passed in - only set when null
	IF @date_to_bill IS NULL
		SELECT @date_to_bill = DATE_TO_BILL
		FROM [advtf_get_date_to_bill](@tmp_date, @prd_bill_days, @prd_bf_af)
	
	IF @action = 'NEW' BEGIN
		IF @line_nbr > 0 BEGIN
		
			IF @order_type IN ('NP','MA','IN','OD') BEGIN
				SET @goto_id = 'CALC_PRINT_NEW'
				GOTO CALC_PRINT		
				AFTER_CALC_PRINT_NEW:	
			END
			ELSE BEGIN
				SET @goto_id = 'CALC_BRDCAST_NEW'
				GOTO CALC_BRDCAST		
				AFTER_CALC_BRDCAST_NEW:	
			END	
				
			SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
							@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
			FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
				
		
			IF @order_type = 'NP' BEGIN
				/* Check for exisiting Order/Line */
				SELECT @temp_cnt = COUNT(1) FROM [dbo].[NEWSPAPER_DETAIL] WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
				IF @temp_cnt > 0 BEGIN
					SET @error_msg_w = 'The order-line (' + CAST(@order_nbr AS varchar(20)) + '-' + CAST(@line_nbr AS varchar(20)) + ') already exists.'
					GOTO ERROR_MSG					
				END
					
				INSERT INTO [dbo].[NEWSPAPER_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [PRINT_COLUMNS], [PRINT_INCHES], [PRINT_LINES], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], --[BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [COST_TYPE], [COST_RATE], [RATE_TYPE], [NP_CIRCULATION], [PRINT_QUANTITY])
						VALUES
							(@order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @active_rev, @link_detid, @start_date, @end_date, @close_date,
							@matl_close_date, @ext_close_date, @ext_matl_date, @size, @ad_number, @headline, @material, @edition_issue, @section,
							@job_number, @job_component_nbr, @rate_card_id, @rate_dtl_id, @print_columns, @print_inches, @print_lines, @contract_qty,
							@quantity, @rate, @net_rate, @gross_rate, @flat_net, @flat_gross, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt,
							@discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc,
							@addl_charge, @addl_charge_desc, @prod_charge, @prod_desc, @color_charge, @color_desc, @line_total, --@line_cancelled,
							@date_to_bill, 
							-- @billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip,
							@markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale,
							@taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag,
							--@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, @glacode_state,
							--@glacode_county, @glacode_city, 
							@non_bill_flag, 
							@modified_by, @modified_date, @modified_comments, @bill_type_flag, @comm_pct, 							   
							--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
							@billing_amt, --@bill_cancelled,
							@est_nbr, @est_line_nbr, @est_rev_nbr, @flat_netcharge, @flat_addl_charge, @flat_discount_amt, @production_size,
							@mat_comp, @size_code, @cost_type, @cost_rate, @rate_type, @np_circulation, @print_quantity)
				IF	 COALESCE(@netcharge, 0) <> 0 BEGIN
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'NC', @ncdesc,
							1, @netcharge, @netcharge, @rate_type, 
							@modified_date, @modified_by)
				END
				IF	 COALESCE(@color_charge, 0) <> 0 BEGIN
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'RC', @color_desc,
							1, @color_charge, @color_charge, @rate_type, 
							@modified_date, @modified_by)
				END		
				IF	 COALESCE(@addl_charge, 0) <> 0 BEGIN
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'AF', @addl_charge_desc,
							1, @addl_charge, @addl_charge, @rate_type, 
							@modified_date, @modified_by)
				END	
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[NEWSPAPER_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 	
			END
			ELSE IF @order_type = 'MA' BEGIN
				/* Check for exisiting Order/Line */
				SELECT @temp_cnt = COUNT(1) FROM [dbo].[MAGAZINE_DETAIL] WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
				IF @temp_cnt > 0 BEGIN
					SET @error_msg_w = 'The order-line (' + CAST(@order_nbr AS varchar(20)) + '-' + CAST(@line_nbr AS varchar(20)) + ') already exists.'
					GOTO ERROR_MSG					
				END					
				INSERT INTO [dbo].[MAGAZINE_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
							[BLEED_PCT], [BLEED_AMT], [POSITION_PCT], [POSITION_AMT], [PREMIUM_PCT], [PREMIUM_AMT],
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], --[BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [MG_CIRCULATION])
						VALUES
							(@order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @active_rev, @link_detid, @start_date, @end_date, @close_date,
							@matl_close_date, @ext_close_date, @ext_matl_date, @size, @ad_number, @headline, @material, @edition_issue, @section,
							@job_number, @job_component_nbr, @rate_card_id, @rate_dtl_id, @contract_qty,
							@quantity, @rate, @net_rate, @gross_rate, @flat_net, @flat_gross, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt,
							@discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc,
							@addl_charge, @addl_charge_desc, @prod_charge, @prod_desc, @color_charge, @color_desc, @line_total, --@line_cancelled,
							@bleed_pct, @bleed_amt, @position_pct, @position_amt, @premium_pct, @premium_amt, 
							@date_to_bill, 
							--@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip,
							@markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale,
							@taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag,
							--@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, @glacode_state,
							--@glacode_county, @glacode_city, 
							@non_bill_flag, 
							@modified_by, @modified_date, @modified_comments, @bill_type_flag, @comm_pct,								
							--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
							@billing_amt, --@bill_cancelled,
							@est_nbr, @est_line_nbr, @est_rev_nbr, @flat_netcharge, @flat_addl_charge, @flat_discount_amt, @production_size,
							@mat_comp, @size_code, @mg_circulation)
			END
			ELSE IF @order_type = 'IN' BEGIN
				/* Check for exisiting Order/Line */
				
				IF @DEBUG = 1
					SELECT 'INSERT to NEW' '-', @gross_rate '@gross_rate', @net_rate '@net_rate', @net_gross '@net_gross', @quantity '@quantity', @ext_net_amt '@ext_net_amt', @ext_gross_amt '@ext_gross_amt'        /* DEBUG */
				
				SELECT @temp_cnt = COUNT(1) FROM [dbo].[INTERNET_DETAIL] WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
				IF @temp_cnt > 0 BEGIN
					SET @error_msg_w = 'The order-line (' + CAST(@order_nbr AS varchar(20)) + '-' + CAST(@line_nbr AS varchar(20)) + ') already exists.'
					GOTO ERROR_MSG					
				END				
				--PJH 12/06/18 - Added @line_market_code, @ad_server_id	
				INSERT INTO [dbo].[INTERNET_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE]
							, [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [INTERNET_TYPE], [SIZE], [PROJ_IMPRESSIONS], [GUARANTEED_IMPRESS]
							, [URL], [TARGET_AUDIENCE], [COPY_AREA]
							, [JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
							, [QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
							, [DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
							, [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]           --,[LINE_CANCELLED]
							, [DATE_TO_BILL]
							--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
							--,[GLESEQ_STAE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
							--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
							, [NON_BILL_FLAG]
							, [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG]
							, [CREATIVE_SIZE], [PLACEMENT_1], [PLACEMENT_2]
							, [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
							, [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
							, [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
							--,[RECONCILE_FLAG]
							, [ACT_IMPRESSIONS]
							--,[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
							, [BILLING_AMT], [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE] --,[BILL_CANCELLED]
							, [EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP]
						    , [AD_SERVER_PLACEMENT_ID]
						    , [AD_SERVER_CREATED_BY]
						    , [AD_SERVER_CREATED_DATETIME]
						    , [AD_SERVER_LAST_MODIFIED_BY]
						    , [AD_SERVER_LAST_MODIFIED_DATETIME]
							, [AD_SERVER_PLACEMENT_MANUAL]	
							, [PACKAGE_PARENT]
							, [AD_SERVER_PLACEMENT_GROUP_ID]
							, [AD_SERVER_ID]
							, [MARKET_CODE]
							, [MEDIA_CHANNEL_ID]
							, [MEDIA_TACTIC_ID] )
					VALUES
							(@order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @active_rev, @link_detid, @start_date, @end_date, @close_date
							, @matl_close_date, @ext_close_date, @ext_matl_date, @headline, @o_type, @size, @proj_impressions, @guaranteed_impress
							, @url_location, @target_audience, @copy_area
							, @job_number, @job_component_nbr, @rate_card, @rate_type, @rate_desc
							, @quantity, @rate, @net_rate, @gross_rate, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt
							, @discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc
							, @addl_charge, @addl_charge_desc, @line_total           --,@line_cancelled
							, @date_to_bill
							--,@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip
							--,@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip
							--,@glacode_state, @glacode_county, @glacode_city
							, @non_bill_flag
							, @modified_by, @modified_date, @modified_comments, @bill_type_flag
							, @creative_size, @placement_1, @placement_2
							, @comm_pct, @markup_pct, @rebate_pct, @discount_pct
							, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale
							, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai
							--,@reconcile_flag
							,@act_impressions
							--,@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def
							, @billing_amt, @cost_type, @cost_rate, @net_base_rate, @gross_base_rate --,@bill_cancelled
							, @est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp
							, @ad_server_placement_id 
							, @ad_server_created_by 
							, @ad_server_created_datetime 
							, @ad_server_last_modified_by 
							, @ad_server_last_modified_datetime 
							, @ad_server_placement_manual
							, @package_parent
							, @ad_server_placement_group_id
							, @ad_server_id
							, @line_market_code
							, @channel
							, @tactic )
			END
			ELSE IF @order_type = 'OD' BEGIN
				/* Check for exisiting Order/Line */
				IF @strata_4_week = 1 BEGIN
					SET @temp_cnt = 0
				END ELSE BEGIN
					SELECT @temp_cnt = COUNT(1) FROM [dbo].[OUTDOOR_DETAIL] WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
				END
				IF @temp_cnt > 0 BEGIN
					SET @error_msg_w = 'The order-line (' + CAST(@order_nbr AS varchar(20)) + '-' + CAST(@line_nbr AS varchar(20)) + ') already exists.'
					GOTO ERROR_MSG					
				END					
				INSERT INTO [dbo].[OUTDOOR_DETAIL]
						   ([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						   ,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						   ,[LOCATION], [COPY_AREA]
						   ,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						   ,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
						   ,[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
						   ,[ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL] --,[LINE_CANCELLED]
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
						   ,[BILLING_AMT] --, [BILL_CANCELLED]
						   ,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [IMPRESSIONS], [ACTUAL_IMPRESSIONS])
					VALUES
							(@order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @active_rev, @link_detid, @start_date, @end_date, @close_date
							, @matl_close_date, @ext_close_date, @ext_matl_date, @headline, @o_type, @size
							, @url_location, @copy_area
							, @job_number, @job_component_nbr, @rate_card, @rate_type, @rate_desc
							, @quantity, @rate, @net_rate, @gross_rate, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt
							, @discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc
							, @addl_charge, @addl_charge_desc, @line_total --,@line_cancelled
							, @date_to_bill
							--,@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip
							--,@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip
							--,@glacode_state, @glacode_county, @glacode_city
							, @non_bill_flag
							, @modified_by, @modified_date, @modified_comments, @bill_type_flag
							, @comm_pct, @markup_pct, @rebate_pct, @discount_pct
							, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale
							, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai
							--,@reconcile_flag, @gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def
							, @billing_amt --,@bill_cancelled
							, @est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp, @guaranteed_impress, @act_impressions)
			END
			ELSE IF @order_type = 'TV' BEGIN
				/* Check for exisiting Order/Line */
				SELECT @temp_cnt = COUNT(1) FROM [dbo].[TV_DETAIL] WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
				IF @temp_cnt > 0 BEGIN
					SET @error_msg_w = 'The order-line (' + CAST(@order_nbr AS varchar(20)) + '-' + CAST(@line_nbr AS varchar(20)) + ') already exists.'
					GOTO ERROR_MSG					
				END							
				INSERT INTO [dbo].[TV_DETAIL] (
							[ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], 
							[BUY_TYPE], [MONTH_NBR], [YEAR_NBR], [DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7], [MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY], 
							[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS], [JOB_NUMBER], [JOB_COMPONENT_NBR], [QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], 
							[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], 
							[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL], 
							--[LINE_CANCELLED], 
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], 
							--[GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP], [GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], 
							--[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], 
							[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], 
							[TAX_RESALE], [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG], 
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], --[BILL_CANCELLED], 
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE], 
							[PROGRAMMING], [START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID],
							--PJH 08/18/17 - added new columns
							[CABLE_NETWORK_STATION_CODE], [DAY_PART_ID], [ADDED_VALUE], [BOOKEND], [LINK_LINE_NUMBER])
				VALUES
							(@order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @active_rev, @link_detid, @start_date, @end_date, @close_date, @matl_close_date, @ext_close_date, @ext_matl_date, 
							@buy_type, @month_nbr, @year_nbr, @date1, @date2, @date3, @date4, @date5, @date6, @date7, @monday, @tuesday, @wednesday, @thursday, @friday, @saturday, @sunday, 
							@spots1, @spots2, @spots3, @spots4, @spots5, @spots6, @spots7, @total_spots, @job_number, @job_component_nbr, @quantity, @rate, @net_rate, @gross_rate, 
							@ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt, @discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, 
							@netcharge, @ncdesc, @addl_charge, @addl_charge_desc, @line_total, 
							--@line_cancelled, 
							@date_to_bill, 
							--@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, 
							--@glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip, @gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, 
							--@glacode_state, @glacode_county, @glacode_city, 
							@non_bill_flag, 
							@modified_by, @modified_date, @modified_comments, 
							@bill_type_flag, @comm_pct, @markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, 
							@tax_resale, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag, 
							--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
							@billing_amt, --@bill_cancelled, 
							@est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp, @cost_type, @cost_rate, @net_base_rate, @gross_base_rate, 
							@programming, @start_time, @end_time, @length, @remarks, @tag, @network_id,
							@cable_network_station_code, @daypart_id, @added_value, @bookend, @link_line_number)
			END
			ELSE IF @order_type = 'RA' BEGIN
				/* Check for exisiting Order/Line */
				SELECT @temp_cnt = COUNT(1) FROM [dbo].[RADIO_DETAIL] WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
				IF @temp_cnt > 0 BEGIN
					SET @error_msg_w = 'The order-line (' + CAST(@order_nbr AS varchar(20)) + '-' + CAST(@line_nbr AS varchar(20)) + ') already exists.'
					GOTO ERROR_MSG					
				END							
				INSERT INTO [dbo].[RADIO_DETAIL] (
							[ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], 
							[BUY_TYPE], [MONTH_NBR], [YEAR_NBR], [DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7], [MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY], 
							[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS], [JOB_NUMBER], [JOB_COMPONENT_NBR], [QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], 
							[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], 
							[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL], 
							--[LINE_CANCELLED], 
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], 
							--[GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP], [GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], 
							--[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], 
							[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], 
							[TAX_RESALE], [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG], 
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], --[BILL_CANCELLED], 
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE], 
							[PROGRAMMING], [START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID],
							--PJH 08/18/17 - added new columns
							[DAY_PART_ID], [ADDED_VALUE], [LINK_LINE_NUMBER])
				VALUES
							(@order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @active_rev, @link_detid, @start_date, @end_date, @close_date, @matl_close_date, @ext_close_date, @ext_matl_date, 
							@buy_type, @month_nbr, @year_nbr, @date1, @date2, @date3, @date4, @date5, @date6, @date7, @monday, @tuesday, @wednesday, @thursday, @friday, @saturday, @sunday, 
							@spots1, @spots2, @spots3, @spots4, @spots5, @spots6, @spots7, @total_spots, @job_number, @job_component_nbr, @quantity, @rate, @net_rate, @gross_rate, 
							@ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt, @discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, 
							@netcharge, @ncdesc, @addl_charge, @addl_charge_desc, @line_total, 
							--@line_cancelled, 
							@date_to_bill, 
							--@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, 
							--@glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip, @gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, 
							--@glacode_state, @glacode_county, @glacode_city, 
							@non_bill_flag, 
							@modified_by, @modified_date, @modified_comments, 
							@bill_type_flag, @comm_pct, @markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, 
							@tax_resale, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag, 
							--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
							@billing_amt, --@bill_cancelled, 
							@est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp, @cost_type, @cost_rate, @net_base_rate, @gross_base_rate, 
							@programming, @start_time, @end_time, @length, @remarks, @tag, @network_id,
							@daypart_id, @added_value, @link_line_number)
			END	
		END
	END --@action = 'NEW'
	
	/* BEGIN UPDATE Non-Billed */
	IF @action = 'UPDATE' BEGIN
		IF @line_nbr > 0 BEGIN
			PRINT 'UPDATE'
			IF @order_type = 'NP' BEGIN						
					
				--IF	 COALESCE(@flat_netcharge, 0) <> 0 BEGIN
				--	--IF COALESCE(@cost_rate, 'STD') = 'CPM'
				--	--	BEGIN
				--	--		SET @netcharge = @netcharge
				--	--	END
				--	SELECT @rec_id = MAX(REC_ID) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'NC'
				--	SELECT @temp_nc_amt = COALESCE(SUM([AMOUNT]),0) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'NC' AND REC_ID <> @rec_id
				--END
				--IF	 COALESCE(@color_charge, 0) <> 0 BEGIN
				--	SELECT @rec_id = MAX(REC_ID) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'RC'
				--	SELECT @temp_cc_amt = COALESCE(SUM([AMOUNT]),0) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'RC' AND REC_ID <> @rec_id
				--END		
				--IF	 COALESCE(@flat_addl_charge, 0) <> 0 BEGIN
				--	SELECT @rec_id = MAX(REC_ID) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'AF'
				--	SELECT @temp_ac_amt = COALESCE(SUM([AMOUNT]),0) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'AF' AND REC_ID <> @rec_id
				--END						
					
				SET @goto_id = 'CALC_PRINT_UPDATE'
				GOTO CALC_PRINT		
				AFTER_CALC_PRINT_UPDATE:				
					
				--SELECT @billing_amt '@billing_amt', @line_total '@line_total', @ext_net_amt '@ext_net_amt', @discount_amt '@discount_amt', @netcharge '@netcharge', @ven_tax '@ven_tax', /* DEBUG */
				--	@sales_tax_amt '@sales_tax_amt', @addl_charge_taxes '@addl_charge_taxes', @addl_charge '@addl_charge', @comm_amt '@comm_amt', @rebate_amt '@rebate_amt'								
					
				UPDATE [dbo].[NEWSPAPER_DETAIL] SET
							--[REV_NBR] = @rev_nbr, [SEQ_NBR] = @seq_nbr, [ACTIVE_REV] = @active_rev, --[LINK_DETID] = @link_detid, 
							[START_DATE] = @start_date, [END_DATE] = @end_date, [CLOSE_DATE] = @close_date,							   
							[MATL_CLOSE_DATE] = @matl_close_date, [EXT_CLOSE_DATE] = @ext_close_date, [EXT_MATL_DATE] = @ext_matl_date, [SIZE] = @size, 
							[AD_NUMBER] = @ad_number, [HEADLINE] = @headline, [MATERIAL] = @material, [EDITION_ISSUE] = @edition_issue, [SECTION] = @section,
							[JOB_NUMBER] = @job_number, [JOB_COMPONENT_NBR] = @job_component_nbr, [RATE_CARD_ID] = @rate_card_id, [RATE_DTL_ID] = @rate_dtl_id, 
							[PRINT_COLUMNS]= @print_columns, [PRINT_INCHES] = @print_inches, [PRINT_LINES] = @print_lines, [CONTRACT_QTY] = @contract_qty,
							[QUANTITY] = @quantity, [RATE] = @rate, [NET_RATE] = @net_rate, [GROSS_RATE] = @gross_rate, [FLAT_NET] = @flat_net, [FLAT_GROSS] = @flat_gross, 
							[EXT_NET_AMT] = @ext_net_amt, [EXT_GROSS_AMT] = @ext_gross_amt, [COMM_AMT] = @comm_amt, [REBATE_AMT] = @rebate_amt,
							[DISCOUNT_AMT] = @discount_amt, [DISCOUNT_DESC] = @discount_desc, [STATE_AMT] = @state_amt, [COUNTY_AMT] = @county_amt, 
							[CITY_AMT] = @city_amt, [NON_RESALE_AMT] = @non_resale_amt, [NETCHARGE] = @netcharge, [NETCHARGE_DESC] = @ncdesc,
							[ADDL_CHARGE] = @addl_charge, [ADDL_CHARGE_DESC] = @addl_charge_desc, [PROD_CHARGE] = @prod_charge, [PROD_DESC] = @prod_desc, 
							[COLOR_CHARGE] = @color_charge, [COLOR_DESC] = @color_desc, [LINE_TOTAL] = @line_total, 
							--[LINE_CANCELLED] = @line_cancelled, 
							[DATE_TO_BILL] = @date_to_bill, 
							--[BILLING_USER] = @billing_user, --[AR_INV_NBR] = @ar_inv_nbr, [AR_TYPE] = @ar_type, [AR_INV_SEQ] = @ar_inv_seq, 
							--[GLEXACT] = @glexact, [GLESEQ_SALES] = @gleseq_sales, [GLESEQ_COS] = @gleseq_cos, [GLESEQ_WIP] = @gleseq_wip,
							--[GLESEQ_STATE] = @gleseq_state, [GLESEQ_COUNTY] = @gleseq_county, [GLESEQ_CITY] = @gleseq_city, [GLEXACT_DEF] = @glexact_def,
							--[GLACODE_SALES] = @glacode_sales, [GLACODE_COS] = @glacode_cos, [GLACODE_WIP] = @glacode_wip,
							--[GLACODE_STATE] = @glacode_state, [GLACODE_COUNTY] = @glacode_county, [GLACODE_CITY] = @glacode_city,
							--[GLESEQ_SALES_DEF] = @gleseq_sales_def, [GLESEQ_COS_DEF] = @gleseq_cos_def, [GLACODE_SALES_DEF] = @glacode_sales_def, [GLACODE_COS_DEF] = @glacode_cos_def,										   
							[NON_BILL_FLAG] = @non_bill_flag, 
							[MODIFIED_BY] = @modified_by, [MODIFIED_DATE] = @modified_date, [MODIFIED_COMMENTS] = @modified_comments, 
							[BILL_TYPE_FLAG] = @bill_type_flag, 
							[COMM_PCT] = @comm_pct, [MARKUP_PCT] = @markup_pct, [REBATE_PCT] = @rebate_pct, [DISCOUNT_PCT] = @discount_pct, [TAX_CODE] = @tax_code, 
							[TAX_CITY_PCT] = @tax_city_pct, [TAX_COUNTY_PCT] = @tax_county_pct, [TAX_STATE_PCT] = @tax_state_pct, [TAX_RESALE] = @tax_resale,
							[TAXAPPLYC] = @taxapplyc, [TAXAPPLYLN] = @taxapplyln, [TAXAPPLYND] = @taxapplynd, [TAXAPPLYNC] = @taxapplync, 
							[TAXAPPLYR] = @taxapplyr, [TAXAPPLYAI] = @taxapplyai, --[RECONCILE_FLAG] = @reconcile_flag,
							[BILLING_AMT] = @billing_amt, --[BILL_CANCELLED] = @bill_cancelled,
							[EST_NBR] = @est_nbr, [EST_LINE_NBR] = @est_line_nbr, [EST_REV_NBR] = @est_rev_nbr, [FLAT_NETCHARGE] = @flat_netcharge, 
							[FLAT_ADDL_CHARGE] = @flat_addl_charge, [FLAT_DISCOUNT_AMT] = @flat_discount_amt, 
							[PRODUCTION_SIZE] = @production_size, [MAT_COMP] = @mat_comp, [SIZE_CODE] = @size_code, [COST_TYPE] = @cost_type, [COST_RATE] = @cost_rate, 
							[RATE_TYPE] = @rate_type, [NP_CIRCULATION] = @np_circulation, [PRINT_QUANTITY] = @print_quantity
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1

				--SELECT @temp_cnt = COUNT(1), @rec_id = MAX(REC_ID) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'NC'							
				--IF @temp_cnt > 0 
				DELETE FROM [dbo].[NEWSPAPER_OTH_CHGS]
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr

				IF	 COALESCE(@netcharge, 0) <> 0 BEGIN
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'NC', @ncdesc,
							1, @netcharge, @netcharge, @rate_type, 
							@modified_date, @modified_by)
				END

				IF	 COALESCE(@color_charge, 0) <> 0 BEGIN						
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'RC', @color_desc,
							1, @color_charge, @color_charge, @rate_type, 
							@modified_date, @modified_by)
				END		

				IF	 COALESCE(@addl_charge, 0) <> 0 BEGIN							
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'AF', @addl_charge_desc,
							1, @addl_charge, @addl_charge, @rate_type, 
							@modified_date, @modified_by)
				END		
			END
			ELSE IF @order_type = 'MA'BEGIN

				SET @goto_id = 'CALC_PRINT_UPDATE2'
				GOTO CALC_PRINT		
				AFTER_CALC_PRINT_UPDATE2:	

				UPDATE [dbo].[MAGAZINE_DETAIL] SET 
							--[REV_NBR] = @rev_nbr, [SEQ_NBR] = @seq_nbr, [ACTIVE_REV] = @active_rev, --,[LINK_DETID] = @link_detid
							[START_DATE] = @start_date, [END_DATE] = @end_date, [CLOSE_DATE] = @close_date,
							[MATL_CLOSE_DATE] = @matl_close_date, [EXT_CLOSE_DATE] = @ext_close_date, [EXT_MATL_DATE] = @ext_matl_date,
							[SIZE] = @size, [AD_NUMBER] = @ad_number, [HEADLINE] = @headline, [MATERIAL] = @material, [EDITION_ISSUE] = @edition_issue, [SECTION] = @section,
							[JOB_NUMBER] = @job_number, [JOB_COMPONENT_NBR] = @job_component_nbr, [RATE_CARD_ID] = @rate_card_id, [RATE_DTL_ID] = @rate_dtl_id,
							[CONTRACT_QTY] = @contract_qty, [QUANTITY] = @quantity, [RATE] = @rate, [NET_RATE] = @net_rate, [GROSS_RATE] = @gross_rate,
							[FLAT_NET] = @flat_net, [FLAT_GROSS] = @flat_gross, [EXT_NET_AMT] = @ext_net_amt, [EXT_GROSS_AMT] = @ext_gross_amt, [COMM_AMT] = @comm_amt,
							[REBATE_AMT] = @rebate_amt, [DISCOUNT_AMT] = @discount_amt, [DISCOUNT_DESC] = @discount_desc,
							[STATE_AMT] = @state_amt, [COUNTY_AMT] = @county_amt, [CITY_AMT] = @city_amt, [NON_RESALE_AMT] = @non_resale_amt,
							[NETCHARGE] = @netcharge, [NETCHARGE_DESC] = @ncdesc, [ADDL_CHARGE] = @addl_charge, [ADDL_CHARGE_DESC] = @addl_charge_desc,
							[PROD_CHARGE] = @prod_charge, [PROD_DESC] = @prod_desc, [COLOR_CHARGE] = @color_charge, [COLOR_DESC] = @color_desc,
							[BLEED_PCT] = @bleed_pct, [BLEED_AMT] = @bleed_amt, [POSITION_PCT] = @position_pct, [POSITION_AMT] = @position_amt,
							[PREMIUM_PCT] = @premium_pct, [PREMIUM_AMT] = @premium_amt, [LINE_TOTAL] = @line_total, 
							--[LINE_CANCELLED] = @line_cancelled,
							[DATE_TO_BILL] = @date_to_bill, 
							--[BILLING_USER] = @billing_user, [AR_INV_NBR] = @ar_inv_nbr, [AR_TYPE] = @ar_type, [AR_INV_SEQ] = @ar_inv_seq,
							--[GLEXACT] = @glexact, [GLESEQ_SALES] = @gleseq_sales, [GLESEQ_COS] = @gleseq_cos, [GLESEQ_WIP] = @gleseq_wip,
							--[GLESEQ_STATE] = @gleseq_state, [GLESEQ_COUNTY] = @gleseq_county, [GLESEQ_CITY] = @gleseq_city, [GLEXACT_DEF] = @glexact_def,
							--[GLACODE_SALES] = @glacode_sales, [GLACODE_COS] = @glacode_cos, [GLACODE_WIP] = @glacode_wip,
							--[GLACODE_STATE] = @glacode_state, [GLACODE_COUNTY] = @glacode_county, [GLACODE_CITY] = @glacode_city,
							--[GLESEQ_SALES_DEF] = @gleseq_sales_def, [GLESEQ_COS_DEF] = @gleseq_cos_def, [GLACODE_SALES_DEF] = @glacode_sales_def, [GLACODE_COS_DEF] = @glacode_cos_def,						  
							[NON_BILL_FLAG] = @non_bill_flag, 
							[MODIFIED_BY] = @modified_by, [MODIFIED_DATE] = @modified_date, [MODIFIED_COMMENTS] = @modified_comments,
							[BILL_TYPE_FLAG] = @bill_type_flag, [COMM_PCT] = @comm_pct, [MARKUP_PCT] = @markup_pct, [REBATE_PCT] = @rebate_pct, [DISCOUNT_PCT] = @discount_pct,
							[TAX_CODE] = @tax_code, 
							[TAX_CITY_PCT] = @tax_city_pct, [TAX_COUNTY_PCT] = @tax_county_pct, [TAX_STATE_PCT] = @tax_state_pct, [TAX_RESALE] = @tax_resale ,     
							[TAXAPPLYC] = @taxapplyc, [TAXAPPLYLN] = @taxapplyln, [TAXAPPLYND] = @taxapplynd, [TAXAPPLYNC] = @taxapplync, [TAXAPPLYR] = @taxapplyr, [TAXAPPLYAI] = @taxapplyai,
							[RECONCILE_FLAG] = @reconcile_flag, [BILLING_AMT] = @billing_amt, --[BILL_CANCELLED] = @bill_cancelled,
							[EST_NBR] = @est_nbr, [EST_LINE_NBR] = @est_line_nbr, [EST_REV_NBR] = @est_rev_nbr,
							[FLAT_NETCHARGE] = @flat_netcharge, [FLAT_ADDL_CHARGE] = @flat_addl_charge, [FLAT_DISCOUNT_AMT] = @flat_discount_amt,
							[PRODUCTION_SIZE] = @production_size, [MAT_COMP] = @mat_comp, [SIZE_CODE] = @size_code, [MG_CIRCULATION] = @mg_circulation
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1
			END
			ELSE IF @order_type = 'IN'BEGIN

				SET @goto_id = 'CALC_PRINT_UPDATE3'
				GOTO CALC_PRINT		
				AFTER_CALC_PRINT_UPDATE3:	

				--PJH 12/06/18 - Added @line_market_code, @ad_server_id
				UPDATE [dbo].[INTERNET_DETAIL] SET
							--[REV_NBR] = @rev_nbr, [SEQ_NBR] = @seq_nbr, [ACTIVE_REV] = @active_rev, --[LINK_DETID] = @link_detid, 
							[START_DATE] = @start_date, [END_DATE] = @end_date, [CLOSE_DATE] = @close_date,							   
							[MATL_CLOSE_DATE] = @matl_close_date, [EXT_CLOSE_DATE] = @ext_close_date, [EXT_MATL_DATE] = @ext_matl_date, [SIZE] = @size, 
							[AD_NUMBER] = @ad_number, [HEADLINE] = @headline, [URL] = @url_location, [TARGET_AUDIENCE] = @target_audience, [COPY_AREA] = @copy_area,
							[INTERNET_TYPE] = @o_type, [PROJ_IMPRESSIONS] = @proj_impressions, [GUARANTEED_IMPRESS] = @guaranteed_impress, [ACT_IMPRESSIONS] = @act_impressions,
							[JOB_NUMBER] = @job_number, [JOB_COMPONENT_NBR] = @job_component_nbr, [RATE_CARD] = @rate_card, [RATE_TYPE] = @rate_type, [RATE_DESC] = @rate_desc,
							[QUANTITY] = @quantity, [RATE] = @rate, [NET_RATE] = @net_rate, [GROSS_RATE] = @gross_rate,  
							[EXT_NET_AMT] = @ext_net_amt, [EXT_GROSS_AMT] = @ext_gross_amt, [COMM_AMT] = @comm_amt, [REBATE_AMT] = @rebate_amt,
							[DISCOUNT_AMT] = @discount_amt, [DISCOUNT_DESC] = @discount_desc, [STATE_AMT] = @state_amt, [COUNTY_AMT] = @county_amt, 
							[CITY_AMT] = @city_amt, [NON_RESALE_AMT] = @non_resale_amt, [NETCHARGE] = @netcharge, [NCDESC] = @ncdesc,
							[ADDL_CHARGE] = @addl_charge, [ADDL_CHARGE_DESC] = @addl_charge_desc, [LINE_TOTAL] = @line_total, 
							--[LINE_CANCELLED] = @line_cancelled, 
							[DATE_TO_BILL] = @date_to_bill, 
							--[BILLING_USER] = @billing_user, --[AR_INV_NBR] = @ar_inv_nbr, [AR_TYPE] = @ar_type, [AR_INV_SEQ] = @ar_inv_seq, 
							--[GLEXACT] = @glexact, [GLESEQ_SALES] = @gleseq_sales, [GLESEQ_COS] = @gleseq_cos, [GLESEQ_WIP] = @gleseq_wip,
							--[GLESEQ_STATE] = @gleseq_state, [GLESEQ_COUNTY] = @gleseq_county, [GLESEQ_CITY] = @gleseq_city, [GLEXACT_DEF] = @glexact_def,
							--[GLACODE_SALES] = @glacode_sales, [GLACODE_COS] = @glacode_cos, [GLACODE_WIP] = @glacode_wip,
							--[GLACODE_STATE] = @glacode_state, [GLACODE_COUNTY] = @glacode_county, [GLACODE_CITY] = @glacode_city,
							--[GLESEQ_SALES_DEF] = @gleseq_sales_def, [GLESEQ_COS_DEF] = @gleseq_cos_def, [GLACODE_SALES_DEF] = @glacode_sales_def, [GLACODE_COS_DEF] = @glacode_cos_def,										   
							[NON_BILL_FLAG] = @non_bill_flag, 
							[MODIFIED_BY] = @modified_by, [MODIFIED_DATE] = @modified_date, [MODIFIED_COMMENTS] = @modified_comments, 
							[BILL_TYPE_FLAG] = @bill_type_flag, [CREATIVE_SIZE] = @creative_size, [PLACEMENT_1] = @placement_1, [PLACEMENT_2] = @placement_2,
							[COMM_PCT] = @comm_pct, [MARKUP_PCT] = @markup_pct, [REBATE_PCT] = @rebate_pct, [DISCOUNT_PCT] = @discount_pct, [TAX_CODE] = @tax_code, 
							[TAX_CITY_PCT] = @tax_city_pct, [TAX_COUNTY_PCT] = @tax_county_pct, [TAX_STATE_PCT] = @tax_state_pct, [TAX_RESALE] = @tax_resale,
							[TAXAPPLYC] = @taxapplyc, [TAXAPPLYLN] = @taxapplyln, [TAXAPPLYND] = @taxapplynd, [TAXAPPLYNC] = @taxapplync, 
							[TAXAPPLYR] = @taxapplyr, [TAXAPPLYAI] = @taxapplyai, --[RECONCILE_FLAG] = @reconcile_flag,
							[BILLING_AMT] = @billing_amt, --[BILL_CANCELLED] = @bill_cancelled,
							[EST_NBR] = @est_nbr, [EST_LINE_NBR] = @est_line_nbr, [EST_REV_NBR] = @est_rev_nbr,
							[MAT_COMP] = @mat_comp, [COST_TYPE] = @cost_type, [COST_RATE] = @cost_rate, 
							[NET_BASE_RATE] = @net_base_rate, [GROSS_BASE_RATE] = @gross_base_rate,
						    [AD_SERVER_PLACEMENT_ID] = @ad_server_placement_id,
						    [AD_SERVER_CREATED_BY] = @ad_server_created_by,
						    [AD_SERVER_CREATED_DATETIME] = @ad_server_created_datetime,
						    [AD_SERVER_LAST_MODIFIED_BY] = @ad_server_last_modified_by,
						    [AD_SERVER_LAST_MODIFIED_DATETIME] = @ad_server_last_modified_datetime,
							[AD_SERVER_PLACEMENT_MANUAL] = @ad_server_placement_manual,
							[PACKAGE_PARENT] = @package_parent,
							[AD_SERVER_PLACEMENT_GROUP_ID] = @ad_server_placement_group_id,
							[AD_SERVER_ID] = @ad_server_id,
							[MARKET_CODE] = @line_market_code,
							[MEDIA_CHANNEL_ID] = @channel,
							[MEDIA_TACTIC_ID] = @tactic 
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1
			END
			ELSE IF @order_type = 'OD'BEGIN

				SET @goto_id = 'CALC_PRINT_UPDATE4'
				GOTO CALC_PRINT		
				AFTER_CALC_PRINT_UPDATE4:	

				UPDATE [dbo].[OUTDOOR_DETAIL] SET 
							--[REV_NBR] = @rev_nbr, [SEQ_NBR] = @seq_nbr, [ACTIVE_REV] = @active_rev, --,[LINK_DETID] = @link_detid
							[POST_DATE] = @start_date, [END_DATE] = @end_date, [CLOSE_DATE] = @close_date,
							[MATL_CLOSE_DATE] = @matl_close_date, [EXT_CLOSE_DATE] = @ext_close_date, [EXT_MATL_DATE] = @ext_matl_date,
							[SIZE] = @size, [AD_NUMBER] = @ad_number, [HEADLINE] = @headline, [OUTDOOR_TYPE] = @o_type, [LOCATION] = @url_location, [COPY_AREA] = @copy_area,
							[JOB_NUMBER] = @job_number, [JOB_COMPONENT_NBR] = @job_component_nbr, [RATE_CARD] = @rate_card, [RATE_TYPE] = @rate_type, [RATE_DESC] = @rate_desc,
							[QUANTITY] = @quantity, [RATE] = @rate, [NET_RATE] = @net_rate, [GROSS_RATE] = @gross_rate,
							[EXT_NET_AMT] = @ext_net_amt, [EXT_GROSS_AMT] = @ext_gross_amt, [COMM_AMT] = @comm_amt,
							[REBATE_AMT] = @rebate_amt, [DISCOUNT_AMT] = @discount_amt, [DISCOUNT_DESC] = @discount_desc,
							[STATE_AMT] = @state_amt, [COUNTY_AMT] = @county_amt, [CITY_AMT] = @city_amt, [NON_RESALE_AMT] = @non_resale_amt,
							[NETCHARGE] = @netcharge, [NCDESC] = @ncdesc, [ADDL_CHARGE] = @addl_charge, [ADDL_CHARGE_DESC] = @addl_charge_desc,
							[LINE_TOTAL] = @line_total, --[LINE_CANCELLED] = @line_cancelled,
							[DATE_TO_BILL] = @date_to_bill, 
							--[BILLING_USER] = @billing_user, [AR_INV_NBR] = @ar_inv_nbr, [AR_TYPE] = @ar_type, [AR_INV_SEQ] = @ar_inv_seq,
							--[GLEXACT] = @glexact, [GLESEQ_SALES] = @gleseq_sales, [GLESEQ_COS] = @gleseq_cos, [GLESEQ_WIP] = @gleseq_wip,
							--[GLESEQ_STATE] = @gleseq_state, [GLESEQ_COUNTY] = @gleseq_county, [GLESEQ_CITY] = @gleseq_city, [GLEXACT_DEF] = @glexact_def,
							--[GLACODE_SALES] = @glacode_sales, [GLACODE_COS] = @glacode_cos, [GLACODE_WIP] = @glacode_wip,
							--[GLACODE_STATE] = @glacode_state, [GLACODE_COUNTY] = @glacode_county, [GLACODE_CITY] = @glacode_city,
							--[GLESEQ_SALES_DEF] = @gleseq_sales_def, [GLESEQ_COS_DEF] = @gleseq_cos_def, [GLACODE_SALES_DEF] = @glacode_sales_def, [GLACODE_COS_DEF] = @glacode_cos_def,						  
							[NON_BILL_FLAG] = @non_bill_flag, 
							[MODIFIED_BY] = @modified_by, [MODIFIED_DATE] = @modified_date, [MODIFIED_COMMENTS] = @modified_comments,
							[BILL_TYPE_FLAG] = @bill_type_flag, [COMM_PCT] = @comm_pct, [MARKUP_PCT] = @markup_pct, [REBATE_PCT] = @rebate_pct, [DISCOUNT_PCT] = @discount_pct,
							[TAX_CODE] = @tax_code, 
							[TAX_CITY_PCT] = @tax_city_pct, [TAX_COUNTY_PCT] = @tax_county_pct, [TAX_STATE_PCT] = @tax_state_pct, [TAX_RESALE] = @tax_resale ,     
							[TAXAPPLYC] = @taxapplyc, [TAXAPPLYLN] = @taxapplyln, [TAXAPPLYND] = @taxapplynd, [TAXAPPLYNC] = @taxapplync, [TAXAPPLYR] = @taxapplyr, [TAXAPPLYAI] = @taxapplyai,
							--[RECONCILE_FLAG] = @reconcile_flag, 
							[BILLING_AMT] = @billing_amt, --[BILL_CANCELLED] = @bill_cancelled,
							[EST_NBR] = @est_nbr, [EST_LINE_NBR] = @est_line_nbr, [EST_REV_NBR] = @est_rev_nbr,
							[MAT_COMP] = @mat_comp, [IMPRESSIONS] = @guaranteed_impress, [ACTUAL_IMPRESSIONS] = @act_impressions
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1
			END
			ELSE IF @order_type = 'TV'BEGIN

				SET @goto_id = 'CALC_BRDCAST_UPDATE'
				GOTO CALC_BRDCAST		
				AFTER_CALC_BRDCAST_UPDATE:	

				UPDATE [dbo].[TV_DETAIL] SET 
							--[REV_NBR] = @rev_nbr, [SEQ_NBR] = @seq_nbr, [ACTIVE_REV] = @active_rev, --,[LINK_DETID] = @link_detid
							[START_DATE] = @start_date, [END_DATE] = @end_date, [CLOSE_DATE] = @close_date,
							[MATL_CLOSE_DATE] = @matl_close_date, [EXT_CLOSE_DATE] = @ext_close_date, [EXT_MATL_DATE] = @ext_matl_date,
							[BUY_TYPE] = @buy_type, [MONTH_NBR] = @month_nbr, [YEAR_NBR] = @year_nbr, 
							[DATE1] = @date1, [DATE2] = @date2, [DATE3] = @date3, [DATE4] = @date4, [DATE5] = @date5, [DATE6] = @date6, [DATE7] = @date7,
							[MONDAY]=@monday, [TUESDAY]=@tuesday, [WEDNESDAY]=@wednesday, [THURSDAY]=@thursday, [FRIDAY]=@friday, [SATURDAY]=@saturday, [SUNDAY]=@sunday,
							[SPOTS1]=@spots1, [SPOTS2]=@spots2, [SPOTS3]=@spots3, [SPOTS4]=@spots4, [SPOTS5]=@spots5, [SPOTS6]=@spots6, [SPOTS7]=@spots7, [TOTAL_SPOTS]=@total_spots,
							[JOB_NUMBER] = @job_number, [JOB_COMPONENT_NBR] = @job_component_nbr, 
							[QUANTITY] = @quantity, [RATE] = @rate, [NET_RATE] = @net_rate, [GROSS_RATE] = @gross_rate,
							[EXT_NET_AMT] = @ext_net_amt, [EXT_GROSS_AMT] = @ext_gross_amt, [COMM_AMT] = @comm_amt,
							[REBATE_AMT] = @rebate_amt, [DISCOUNT_AMT] = @discount_amt, [DISCOUNT_DESC] = @discount_desc,
							[STATE_AMT] = @state_amt, [COUNTY_AMT] = @county_amt, [CITY_AMT] = @city_amt, [NON_RESALE_AMT] = @non_resale_amt,
							[NETCHARGE] = @netcharge, [NCDESC] = @ncdesc, [ADDL_CHARGE] = @addl_charge, [ADDL_CHARGE_DESC] = @addl_charge_desc,
							[LINE_TOTAL] = @line_total, --[LINE_CANCELLED] = @line_cancelled,
							[DATE_TO_BILL] = @date_to_bill, 
							[NON_BILL_FLAG] = @non_bill_flag, 
							[MODIFIED_BY] = @modified_by, [MODIFIED_DATE] = @modified_date, [MODIFIED_COMMENTS] = @modified_comments,
							[BILL_TYPE_FLAG] = @bill_type_flag, [COMM_PCT] = @comm_pct, [MARKUP_PCT] = @markup_pct, [REBATE_PCT] = @rebate_pct, [DISCOUNT_PCT] = @discount_pct,
							[TAX_CODE] = @tax_code, 
							[TAX_CITY_PCT] = @tax_city_pct, [TAX_COUNTY_PCT] = @tax_county_pct, [TAX_STATE_PCT] = @tax_state_pct, [TAX_RESALE] = @tax_resale ,     
							[TAXAPPLYC] = @taxapplyc, [TAXAPPLYLN] = @taxapplyln, [TAXAPPLYND] = @taxapplynd, [TAXAPPLYNC] = @taxapplync, [TAXAPPLYR] = @taxapplyr, [TAXAPPLYAI] = @taxapplyai,
							--[RECONCILE_FLAG] = @reconcile_flag, 
							[BILLING_AMT] = @billing_amt, [COST_TYPE]=@cost_type, [COST_RATE]=@cost_rate, [NET_BASE_RATE]=@net_base_rate, [GROSS_BASE_RATE]=@gross_base_rate,
							--[BILL_CANCELLED] = @bill_cancelled,
							[EST_NBR] = @est_nbr, [EST_LINE_NBR] = @est_line_nbr, [EST_REV_NBR] = @est_rev_nbr,
							[AD_NUMBER]=@ad_number, [MAT_COMP] = @mat_comp, [PROGRAMMING]=@programming,
							[START_TIME]=@start_time, [END_TIME]=@end_time, [LENGTH]=@length, [REMARKS]=@remarks, [TAG]=@tag,
							[NETWORK_ID]=@network_id,
							--PJH 08/18/17 - added new columns
							[CABLE_NETWORK_STATION_CODE] = @cable_network_station_code, [DAY_PART_ID] = @daypart_id, 
							[ADDED_VALUE] = @added_value, [BOOKEND] = @bookend
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1
			END
			ELSE IF @order_type = 'RA'BEGIN

				SET @goto_id = 'CALC_BRDCAST_UPDATE2'
				GOTO CALC_BRDCAST		
				AFTER_CALC_BRDCAST_UPDATE2:	

				UPDATE [dbo].[RADIO_DETAIL] SET 
							--[REV_NBR] = @rev_nbr, [SEQ_NBR] = @seq_nbr, [ACTIVE_REV] = @active_rev, --,[LINK_DETID] = @link_detid
							[START_DATE] = @start_date, [END_DATE] = @end_date, [CLOSE_DATE] = @close_date,
							[MATL_CLOSE_DATE] = @matl_close_date, [EXT_CLOSE_DATE] = @ext_close_date, [EXT_MATL_DATE] = @ext_matl_date,
							[BUY_TYPE] = @buy_type, [MONTH_NBR] = @month_nbr, [YEAR_NBR] = @year_nbr, 
							[DATE1] = @date1, [DATE2] = @date2, [DATE3] = @date3, [DATE4] = @date4, [DATE5] = @date5, [DATE6] = @date6, [DATE7] = @date7,
							[MONDAY]=@monday, [TUESDAY]=@tuesday, [WEDNESDAY]=@wednesday, [THURSDAY]=@thursday, [FRIDAY]=@friday, [SATURDAY]=@saturday, [SUNDAY]=@sunday,
							[SPOTS1]=@spots1, [SPOTS2]=@spots2, [SPOTS3]=@spots3, [SPOTS4]=@spots4, [SPOTS5]=@spots5, [SPOTS6]=@spots6, [SPOTS7]=@spots7, [TOTAL_SPOTS]=@total_spots,
							[JOB_NUMBER] = @job_number, [JOB_COMPONENT_NBR] = @job_component_nbr, 
							[QUANTITY] = @quantity, [RATE] = @rate, [NET_RATE] = @net_rate, [GROSS_RATE] = @gross_rate,
							[EXT_NET_AMT] = @ext_net_amt, [EXT_GROSS_AMT] = @ext_gross_amt, [COMM_AMT] = @comm_amt,
							[REBATE_AMT] = @rebate_amt, [DISCOUNT_AMT] = @discount_amt, [DISCOUNT_DESC] = @discount_desc,
							[STATE_AMT] = @state_amt, [COUNTY_AMT] = @county_amt, [CITY_AMT] = @city_amt, [NON_RESALE_AMT] = @non_resale_amt,
							[NETCHARGE] = @netcharge, [NCDESC] = @ncdesc, [ADDL_CHARGE] = @addl_charge, [ADDL_CHARGE_DESC] = @addl_charge_desc,
							[LINE_TOTAL] = @line_total, --[LINE_CANCELLED] = @line_cancelled,
							[DATE_TO_BILL] = @date_to_bill, 
							[NON_BILL_FLAG] = @non_bill_flag, 
							[MODIFIED_BY] = @modified_by, [MODIFIED_DATE] = @modified_date, [MODIFIED_COMMENTS] = @modified_comments,
							[BILL_TYPE_FLAG] = @bill_type_flag, [COMM_PCT] = @comm_pct, [MARKUP_PCT] = @markup_pct, [REBATE_PCT] = @rebate_pct, [DISCOUNT_PCT] = @discount_pct,
							[TAX_CODE] = @tax_code, 
							[TAX_CITY_PCT] = @tax_city_pct, [TAX_COUNTY_PCT] = @tax_county_pct, [TAX_STATE_PCT] = @tax_state_pct, [TAX_RESALE] = @tax_resale ,     
							[TAXAPPLYC] = @taxapplyc, [TAXAPPLYLN] = @taxapplyln, [TAXAPPLYND] = @taxapplynd, [TAXAPPLYNC] = @taxapplync, [TAXAPPLYR] = @taxapplyr, [TAXAPPLYAI] = @taxapplyai,
							--[RECONCILE_FLAG] = @reconcile_flag, 
							[BILLING_AMT] = @billing_amt, [COST_TYPE]=@cost_type, [COST_RATE]=@cost_rate, [NET_BASE_RATE]=@net_base_rate, [GROSS_BASE_RATE]=@gross_base_rate,
							--[BILL_CANCELLED] = @bill_cancelled,
							[EST_NBR] = @est_nbr, [EST_LINE_NBR] = @est_line_nbr, [EST_REV_NBR] = @est_rev_nbr,
							[AD_NUMBER]=@ad_number, [MAT_COMP] = @mat_comp, [PROGRAMMING]=@programming,
							[START_TIME]=@start_time, [END_TIME]=@end_time, [LENGTH]=@length, [REMARKS]=@remarks, [TAG]=@tag,
							[NETWORK_ID]=@network_id,
							--PJH 08/18/17 - added new columns
							[DAY_PART_ID] = @daypart_id, [ADDED_VALUE] = @added_value
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [ACTIVE_REV] = 1

				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[RADIO_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 
			END
		END
	END --@action = 'UPDATE'
	/* END UPDATE Non-Billed */

	IF @action = 'REVISE' BEGIN	
		IF @line_nbr > 0 BEGIN
			--SELECT  'REVISE' --DEBUG
				
			--SELECT @order_nbr '@order_nbr', @line_nbr '@line_nbr', @order_type '@order_type' /* DEBUG */

			/*** Get the MAX REV & SEQ for a given ORDER/LINE ***/	
			SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
							@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
			FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
				
			--SELECT @max_rev_nbr '@max_rev_nbr', @max_seq_nbr '@max_seq_nbr', @offset_rev_nbr '@offset_rev_nbr', @offset_seq_nbr '@offset_seq_nbr',  /* DEBUG */	
			--			@onset_rev_nbr '@onset_rev_nbr', @onset_seq_nbr '@onset_seq_nbr', @order_type '@order_type'							
				
			IF @order_type = 'NP' BEGIN
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[NEWSPAPER_DETAIL] SET ACTIVE_REV = NULL
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
				/* OFFSET */
				INSERT INTO [dbo].[NEWSPAPER_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [PRINT_COLUMNS], [PRINT_INCHES], [PRINT_LINES], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], [LINE_CANCELLED],
							[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], [BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [COST_TYPE], [COST_RATE], [RATE_TYPE], [NP_CIRCULATION], [PRINT_QUANTITY])
						SELECT --DATE_TO_BILL, NON_BILL_FLAG??
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr,  NULL, [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [PRINT_COLUMNS], [PRINT_INCHES], [PRINT_LINES] * -1, [CONTRACT_QTY] * -1,
							[QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1,
							[DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NETCHARGE_DESC],
							[ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [PROD_CHARGE] * -1, [PROD_DESC], [COLOR_CHARGE] * -1, [COLOR_DESC], [LINE_TOTAL] * -1, [LINE_CANCELLED],
							[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT]  * -1, [BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE] * -1, [FLAT_ADDL_CHARGE] * -1, [FLAT_DISCOUNT_AMT] * -1, [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [COST_TYPE], [COST_RATE], [RATE_TYPE], [NP_CIRCULATION], [PRINT_QUANTITY] * -1
					FROM  [dbo].[NEWSPAPER_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */	
				SET @goto_id = 'CALC_PRINT_REVISE'
				GOTO CALC_PRINT	
				AFTER_CALC_PRINT_REVISE:			
					
				--SELECT @link_detid '@link_detid'	 /* DEBUG */	
					
				INSERT INTO [dbo].[NEWSPAPER_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [PRINT_COLUMNS], [PRINT_INCHES], [PRINT_LINES], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
							[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], --[BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [COST_TYPE], [COST_RATE], [RATE_TYPE], [NP_CIRCULATION], [PRINT_QUANTITY])
						VALUES
							(@order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1, @link_detid, @start_date, @end_date, @close_date,
							@matl_close_date, @ext_close_date, @ext_matl_date, @size, @ad_number, @headline, @material, @edition_issue, @section,
							@job_number, @job_component_nbr, @rate_card_id, @rate_dtl_id, @print_columns, @print_inches, @print_lines, @contract_qty,
							@quantity, @rate, @net_rate, @gross_rate, @flat_net, @flat_gross, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt,
							@discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc,
							@addl_charge, @addl_charge_desc, @prod_charge, @prod_desc, @color_charge, @color_desc, @line_total, --@line_cancelled,
							@date_to_bill, --@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip,
							@markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale,
							@taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag,
							--@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, @glacode_state,
							--@glacode_county, @glacode_city, 
							@non_bill_flag, @modified_by, @modified_date, @modified_comments, @bill_type_flag, @comm_pct, 							   
							--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
							@billing_amt, --@bill_cancelled,
							@est_nbr, @est_line_nbr, @est_rev_nbr, @flat_netcharge, @flat_addl_charge, @flat_discount_amt, @production_size,
							@mat_comp, @size_code, @cost_type, @cost_rate, @rate_type, @np_circulation, @print_quantity)	

				--SELECT @temp_cnt = COUNT(1), @rec_id = MAX(REC_ID) FROM NEWSPAPER_OTH_CHGS WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [CHG_TYPE] = 'NC'							
				--IF @temp_cnt > 0 
				DELETE FROM [dbo].[NEWSPAPER_OTH_CHGS]
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr

				IF	 COALESCE(@netcharge, 0) <> 0 BEGIN
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'NC', @ncdesc,
							1, @netcharge, @netcharge, @rate_type, 
							@modified_date, @modified_by)
				END

				IF	 COALESCE(@color_charge, 0) <> 0 BEGIN						
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'RC', @color_desc,
							1, @color_charge, @color_charge, @rate_type, 
							@modified_date, @modified_by)
				END		

				IF	 COALESCE(@addl_charge, 0) <> 0 BEGIN							
					INSERT INTO [dbo].[NEWSPAPER_OTH_CHGS]
							([ORDER_NBR], [LINE_NBR], [CHG_TYPE], [CHG_DESC]
							,[QUANTITY], [RATE], [AMOUNT], [RATE_TYPE]
							,[REVISED_DATE], [REVISED_BY])			
					VALUES			
							(@order_nbr, @line_nbr,'AF', @addl_charge_desc,
							1, @addl_charge, @addl_charge, @rate_type, 
							@modified_date, @modified_by)
				END								   
			END 
			ELSE IF @order_type = 'MA' BEGIN
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[MAGAZINE_DETAIL] SET ACTIVE_REV = NULL
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
				/* OFFSET */
				INSERT INTO [dbo].[MAGAZINE_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
							[BLEED_PCT], [BLEED_AMT], [POSITION_PCT], [POSITION_AMT], [PREMIUM_PCT], [PREMIUM_AMT],
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], [BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [MG_CIRCULATION])
						SELECT
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [CONTRACT_QTY] * -1,
							[QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1,
							[DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NETCHARGE_DESC],
							[ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [PROD_CHARGE] * -1, [PROD_DESC], [COLOR_CHARGE] * -1, [COLOR_DESC], [LINE_TOTAL] * -1, --[LINE_CANCELLED],
							[BLEED_PCT], [BLEED_AMT] * -1, [POSITION_PCT], [POSITION_AMT] * -1, [PREMIUM_PCT], [PREMIUM_AMT] * -1,
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT] * -1, [BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE] * -1, [FLAT_ADDL_CHARGE] * -1, [FLAT_DISCOUNT_AMT] * -1, [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [MG_CIRCULATION]
					FROM  [dbo].[MAGAZINE_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
	
				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */	
				SET @goto_id = 'CALC_PRINT_REVISE2'
				GOTO CALC_PRINT	
				AFTER_CALC_PRINT_REVISE2:			
					
				--SELECT @link_detid '@link_detid'	 /* DEBUG */	

				INSERT INTO [dbo].[MAGAZINE_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
							[BLEED_PCT], [BLEED_AMT], [POSITION_PCT], [POSITION_AMT], [PREMIUM_PCT], [PREMIUM_AMT],
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], --[BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [MG_CIRCULATION])
						VALUES
							(@order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1, @link_detid, @start_date, @end_date, @close_date,
							@matl_close_date, @ext_close_date, @ext_matl_date, @size, @ad_number, @headline, @material, @edition_issue, @section,
							@job_number, @job_component_nbr, @rate_card_id, @rate_dtl_id, @contract_qty,
							@quantity, @rate, @net_rate, @gross_rate, @flat_net, @flat_gross, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt,
							@discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc,
							@addl_charge, @addl_charge_desc, @prod_charge, @prod_desc, @color_charge, @color_desc, @line_total, --@line_cancelled,
							@bleed_pct, @bleed_amt, @position_pct, @position_amt, @premium_pct, @premium_amt, 
							@date_to_bill, 
							--@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip,
							@markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale,
							@taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag,
							--@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, @glacode_state,
							--@glacode_county, @glacode_city, 
							@non_bill_flag, 
							@modified_by, @modified_date, @modified_comments, @bill_type_flag, @comm_pct,								
							--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
							@billing_amt, --@bill_cancelled,
							@est_nbr, @est_line_nbr, @est_rev_nbr, @flat_netcharge, @flat_addl_charge, @flat_discount_amt, @production_size,
							@mat_comp, @size_code, @mg_circulation)
					
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[MAGAZINE_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @onset_rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 					
			END 
			ELSE IF @order_type = 'IN' BEGIN
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[INTERNET_DETAIL] SET ACTIVE_REV = NULL
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
				/* OFFSET */
				--PJH 12/06/18 - Added @line_market_code, @ad_server_id
				INSERT INTO [dbo].[INTERNET_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE]
							, [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [INTERNET_TYPE], [SIZE], [PROJ_IMPRESSIONS], [GUARANTEED_IMPRESS]
							, [URL], [TARGET_AUDIENCE], [COPY_AREA]
							, [JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
							, [QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
							, [DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
							, [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]           --,[LINE_CANCELLED]
							, [DATE_TO_BILL]
							--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
							--,[GLESEQ_STAE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
							--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
							, [NON_BILL_FLAG]
							, [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG]
							, [CREATIVE_SIZE], [PLACEMENT_1], [PLACEMENT_2]
							, [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
							, [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
							, [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
							--,[RECONCILE_FLAG], [ACT_IMPRESSIONS]
							--,[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
							, [BILLING_AMT], [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE] ,[BILL_CANCELLED]
							, [EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP]
						    , [AD_SERVER_PLACEMENT_ID]
						    , [AD_SERVER_CREATED_BY]
						    , [AD_SERVER_CREATED_DATETIME]
						    , [AD_SERVER_LAST_MODIFIED_BY]
						    , [AD_SERVER_LAST_MODIFIED_DATETIME]
							, [AD_SERVER_PLACEMENT_MANUAL]
							, [PACKAGE_PARENT]
							, [AD_SERVER_PLACEMENT_GROUP_ID]
							, [AD_SERVER_ID] 
							, [MARKET_CODE]
							, [MEDIA_CHANNEL_ID]
							, [MEDIA_TACTIC_ID]	)
						SELECT
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE]
							, [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [INTERNET_TYPE], [SIZE], [PROJ_IMPRESSIONS], [GUARANTEED_IMPRESS]
							, [URL], [TARGET_AUDIENCE], [COPY_AREA]
							, [JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
							, [QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT] * -1_, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1
							, [DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NCDESC]
							, [ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [LINE_TOTAL] * -1           --,[LINE_CANCELLED]
							, [DATE_TO_BILL]
							--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
							--,[GLESEQ_STAE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
							--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
							, [NON_BILL_FLAG]
							, [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG]
							, [CREATIVE_SIZE], [PLACEMENT_1], [PLACEMENT_2]
							, [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
							, [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
							, [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
							--,[RECONCILE_FLAG], [ACT_IMPRESSIONS]
							--,[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
							, [BILLING_AMT] * -1, [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE] ,[BILL_CANCELLED]
							, [EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP]
						    , [AD_SERVER_PLACEMENT_ID]
						    , [AD_SERVER_CREATED_BY]
						    , [AD_SERVER_CREATED_DATETIME]
						    , [AD_SERVER_LAST_MODIFIED_BY]
						    , [AD_SERVER_LAST_MODIFIED_DATETIME]
							, [AD_SERVER_PLACEMENT_MANUAL]
							, [PACKAGE_PARENT]
							, [AD_SERVER_PLACEMENT_GROUP_ID]
							, [AD_SERVER_ID] 
							, [MARKET_CODE]
							, [MEDIA_CHANNEL_ID]
							, [MEDIA_TACTIC_ID]	
					FROM  [dbo].[INTERNET_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
	
				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */	
				SET @goto_id = 'CALC_PRINT_REVISE3'
				GOTO CALC_PRINT	
				AFTER_CALC_PRINT_REVISE3:			
					
				--SELECT @link_detid '@link_detid'	 /* DEBUG */	

				--MJC 05/06/16 - (Media Manager - Allow Actual Impressions to be editable) affected REVISE block
				--PJH 12/06/18 - Added @line_market_code, @ad_server_id
				INSERT INTO [dbo].[INTERNET_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE]
							, [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [INTERNET_TYPE], [SIZE], [PROJ_IMPRESSIONS], [GUARANTEED_IMPRESS]
							, [URL], [TARGET_AUDIENCE], [COPY_AREA]
							, [JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
							, [QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
							, [DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
							, [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]           --,[LINE_CANCELLED]
							, [DATE_TO_BILL]
							--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
							--,[GLESEQ_STAE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
							--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
							, [NON_BILL_FLAG]
							, [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG]
							, [CREATIVE_SIZE], [PLACEMENT_1], [PLACEMENT_2]
							, [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
							, [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
							, [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
							--,[RECONCILE_FLAG],
							, [ACT_IMPRESSIONS]
							--,[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
							, [BILLING_AMT], [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE] --,[BILL_CANCELLED]
							, [EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP]
						    , [AD_SERVER_PLACEMENT_ID]
						    , [AD_SERVER_CREATED_BY]
						    , [AD_SERVER_CREATED_DATETIME]
						    , [AD_SERVER_LAST_MODIFIED_BY]
						    , [AD_SERVER_LAST_MODIFIED_DATETIME]
							, [AD_SERVER_PLACEMENT_MANUAL]
							, [PACKAGE_PARENT]
							, [AD_SERVER_PLACEMENT_GROUP_ID]
							, [AD_SERVER_ID] 
							, [MARKET_CODE]
							, [MEDIA_CHANNEL_ID]
							, [MEDIA_TACTIC_ID]
							)
						VALUES
							(@order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1, @link_detid, @start_date, @end_date, @close_date
							, @matl_close_date, @ext_close_date, @ext_matl_date, @headline, @o_type, @size, @proj_impressions, @guaranteed_impress
							, @url_location, @target_audience, @copy_area
							, @job_number, @job_component_nbr, @rate_card, @rate_type, @rate_desc
							, @quantity, @rate, @net_rate, @gross_rate, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt
							, @discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc
							, @addl_charge, @addl_charge_desc, @line_total           --,@line_cancelled
							, @date_to_bill
							--,@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip
							--,@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip
							--,@glacode_state, @glacode_county, @glacode_city
							, @non_bill_flag
							, @modified_by, @modified_date, @modified_comments, @bill_type_flag
							, @creative_size, @placement_1, @placement_2
							, @comm_pct, @markup_pct, @rebate_pct, @discount_pct
							, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale
							, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai
							--,@reconcile_flag,
							, @act_impressions
							--,@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def
							, @billing_amt, @cost_type, @cost_rate, @net_base_rate, @gross_base_rate --,@bill_cancelled
							, @est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp
							, @ad_server_placement_id 
							, @ad_server_created_by 
							, @ad_server_created_datetime 
							, @ad_server_last_modified_by 
							, @ad_server_last_modified_datetime 	
							, @ad_server_placement_manual	
							, @package_parent
							, @ad_server_placement_group_id
							, @ad_server_id
							, @line_market_code	
							, @channel
							, @tactic					
							)
					
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[INTERNET_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @onset_rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 					
			END 
			ELSE IF @order_type = 'OD' BEGIN
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[OUTDOOR_DETAIL] SET ACTIVE_REV = NULL
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
				/* OFFSET */
				INSERT INTO [dbo].[OUTDOOR_DETAIL]
						   ([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						   ,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						   ,[LOCATION], [COPY_AREA]
						   ,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						   ,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
						   ,[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
						   ,[ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL] --,[LINE_CANCELLED]
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
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, [ACTIVE_REV], [LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						   ,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						   ,[LOCATION], [COPY_AREA]
						   ,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						   ,[QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1
						   ,[DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NCDESC]
						   ,[ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [LINE_TOTAL] * -1 --,[LINE_CANCELLED]
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
						   ,[BILLING_AMT] * -1 , [BILL_CANCELLED]
						   ,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [IMPRESSIONS], [ACTUAL_IMPRESSIONS]
					FROM  [dbo].[OUTDOOR_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
	
				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */	
				SET @goto_id = 'CALC_PRINT_REVISE4'
				GOTO CALC_PRINT	
				AFTER_CALC_PRINT_REVISE4:			
					
				--SELECT @link_detid '@link_detid'	 /* DEBUG */	

				INSERT INTO [dbo].[OUTDOOR_DETAIL]
						   ([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						   ,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						   ,[LOCATION], [COPY_AREA]
						   ,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						   ,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
						   ,[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
						   ,[ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL] --,[LINE_CANCELLED]
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
						   ,[BILLING_AMT] --, [BILL_CANCELLED]
						   ,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [IMPRESSIONS], [ACTUAL_IMPRESSIONS])
				VALUES
   							(@order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1, @link_detid, @start_date, @end_date, @close_date
							, @matl_close_date, @ext_close_date, @ext_matl_date, @headline, @o_type, @size
							, @url_location, @copy_area
							, @job_number, @job_component_nbr, @rate_card, @rate_type, @rate_desc
							, @quantity, @rate, @net_rate, @gross_rate, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt
							, @discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc
							, @addl_charge, @addl_charge_desc, @line_total --,@line_cancelled
							, @date_to_bill
							--,@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip
							--,@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip
							--,@glacode_state, @glacode_county, @glacode_city
							, @non_bill_flag
							, @modified_by, @modified_date, @modified_comments, @bill_type_flag
							, @comm_pct, @markup_pct, @rebate_pct, @discount_pct
							, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale
							, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai
							--,@reconcile_flag, @gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def
							, @billing_amt --,@bill_cancelled
							, @est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp, @guaranteed_impress, @act_impressions)
					
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[OUTDOOR_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @onset_rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 					
			END 
			ELSE IF @order_type = 'TV' BEGIN
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[TV_DETAIL] SET ACTIVE_REV = NULL
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
				/* PJH 06/05/20 - added */
				--SELECT @station_id = STATION_ID FROM [dbo].[TV_DETAIL]
				--WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr

				/* OFFSET */
				INSERT INTO [dbo].[TV_DETAIL]
					([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS]
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC]
					,[STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT]
					,[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT], [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID]
					--PJH 08/18/17 - added new columns
					,[CABLE_NETWORK_STATION_CODE], [DAY_PART_ID], [ADDED_VALUE], [BOOKEND], [LINK_LINE_NUMBER]
					--,[STATION_ID]
					)
				SELECT
					@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1]*-1, [SPOTS2]*-1, [SPOTS3]*-1, [SPOTS4]*-1, [SPOTS5]*-1, [SPOTS6]*-1, [SPOTS7]*-1, [TOTAL_SPOTS]*-1
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY]*-1, [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT]*-1, [EXT_GROSS_AMT]*-1, [COMM_AMT]*-1, [REBATE_AMT]*-1, [DISCOUNT_AMT]*-1, [DISCOUNT_DESC]
					,[STATE_AMT]*-1, [COUNTY_AMT]*-1, [CITY_AMT]*-1, [NON_RESALE_AMT]*-1
					,[NETCHARGE]*-1, [NCDESC], [ADDL_CHARGE]*-1, [ADDL_CHARGE_DESC], [LINE_TOTAL]*-1
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT]*-1, [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID]
					--PJH 08/18/17 - added new columns
					,[CABLE_NETWORK_STATION_CODE], [DAY_PART_ID], [ADDED_VALUE], [BOOKEND], [LINK_LINE_NUMBER]
					--,[STATION_ID]
				FROM  [dbo].[TV_DETAIL]
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
	
				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */	
				SET @goto_id = 'CALC_BRDCAST_REVISE'
				GOTO CALC_BRDCAST	
				AFTER_CALC_BRDCAST_REVISE:			
					
				--SELECT @link_detid '@link_detid'	 /* DEBUG */	

				--IF @DEBUG = 1
				--SELECT '1' '-', @start_date '@start_date' , @date1 '@date1', @date2 '@date2', @date3 '@date3', @date4 '@date4', @date5 '@date5', @date6 '@date6', @month_nbr'@month_nbr', @year_nbr '@year_nbr'  /* DEBUG */

				INSERT INTO [dbo].[TV_DETAIL]
					([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS]
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC]
					,[STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT]
					,[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]
					--,[LINE_CANCELLED]
					,[DATE_TO_BILL]
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT], [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           --,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID]
					--PJH 08/18/17 - added new columns
					,[CABLE_NETWORK_STATION_CODE], [DAY_PART_ID], [ADDED_VALUE], [BOOKEND], [LINK_LINE_NUMBER]
					--,[STATION_ID]
					)
				VALUES		( @order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1
					, @link_detid, @buy_type, @start_date, @end_date, @month_nbr, @year_nbr
					, @close_date, @matl_close_date, @ext_close_date, @ext_matl_date
					, @date1, @date2, @date3, @date4, @date5, @date6, @date7
					, @monday, @tuesday, @wednesday, @thursday, @friday, @saturday, @sunday
					, @spots1, @spots2, @spots3, @spots4, @spots5, @spots6, @spots7, @total_spots
					, @job_number, @job_component_nbr --@rate_card, @rate_type, @rate_desc
					, @quantity, @rate, @net_rate, @gross_rate
					, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt, @discount_amt, @discount_desc
					, @state_amt, @county_amt, @city_amt, @non_resale_amt
					, @netcharge, @ncdesc, @addl_charge, @addl_charge_desc, @line_total 
					--,@line_cancelled
					, @date_to_bill
					, @non_bill_flag, @modified_by, @modified_date, @modified_comments
					, @bill_type_flag, @comm_pct, @markup_pct, @rebate_pct, @discount_pct
					, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale
					, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai
					--,@reconcile_flag
					, @billing_amt, @cost_type, @cost_rate 
					, @net_base_rate, @gross_base_rate   --,@bill_cancelled
					, @est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp, @programming
					, @start_time, @end_time, @length, @remarks, @tag, @network_id
					,@cable_network_station_code, @daypart_id, @added_value, @bookend, @link_line_number
					--,@station_id
					)
					
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[TV_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @onset_rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 					
			END 
			ELSE IF @order_type = 'RA' BEGIN
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[RADIO_DETAIL] SET ACTIVE_REV = NULL
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
				/* PJH 06/05/20 - added */
				--SELECT @station_id = STATION_ID FROM [dbo].[TV_DETAIL]
				--WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr

				/* OFFSET */
				INSERT INTO [dbo].[RADIO_DETAIL]
					([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS]
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC]
					,[STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT]
					,[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT], [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID], [LINK_LINE_NUMBER]
					--PJH 08/18/17 - added new columns
					,[DAY_PART_ID], [ADDED_VALUE]
					--,[STATION_ID]
					)
				SELECT
					@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1]*-1, [SPOTS2]*-1, [SPOTS3]*-1, [SPOTS4]*-1, [SPOTS5]*-1, [SPOTS6]*-1, [SPOTS7]*-1, [TOTAL_SPOTS]*-1
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY]*-1, [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT]*-1, [EXT_GROSS_AMT]*-1, [COMM_AMT]*-1, [REBATE_AMT]*-1, [DISCOUNT_AMT]*-1, [DISCOUNT_DESC]
					,[STATE_AMT]*-1, [COUNTY_AMT]*-1, [CITY_AMT]*-1, [NON_RESALE_AMT]*-1
					,[NETCHARGE]*-1, [NCDESC], [ADDL_CHARGE]*-1, [ADDL_CHARGE_DESC], [LINE_TOTAL]*-1
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT]*-1, [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID], [LINK_LINE_NUMBER]
					--PJH 08/18/17 - added new columns
					,[DAY_PART_ID], [ADDED_VALUE]
					--,[STATION_ID]
				FROM  [dbo].[RADIO_DETAIL]
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
	
				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */	
				SET @goto_id = 'CALC_BRDCAST_REVISE2'
				GOTO CALC_BRDCAST	
				AFTER_CALC_BRDCAST_REVISE2:			
					
				--SELECT @link_detid '@link_detid'	 /* DEBUG */	

				--SELECT '1' '-', @start_date '@start_date' , @date1 '@date1', @date2 '@date2', @date3 '@date3', @date4 '@date4', @date5 '@date5', @date6 '@date6', @month_nbr'@month_nbr', @year_nbr '@year_nbr'  /* DEBUG */

				INSERT INTO [dbo].[RADIO_DETAIL]
					([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS]
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC]
					,[STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT]
					,[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]
					--,[LINE_CANCELLED]
					,[DATE_TO_BILL]
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT], [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           --,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID]
					--PJH 08/18/17 - added new columns
					,[DAY_PART_ID], [ADDED_VALUE], [LINK_LINE_NUMBER]
					--,[STATION_ID]
					)
				VALUES		( @order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1
					, @link_detid, @buy_type, @start_date, @end_date, @month_nbr, @year_nbr
					, @close_date, @matl_close_date, @ext_close_date, @ext_matl_date
					, @date1, @date2, @date3, @date4, @date5, @date6, @date7
					, @monday, @tuesday, @wednesday, @thursday, @friday, @saturday, @sunday
					, @spots1, @spots2, @spots3, @spots4, @spots5, @spots6, @spots7, @total_spots
					, @job_number, @job_component_nbr --@rate_card, @rate_type, @rate_desc
					, @quantity, @rate, @net_rate, @gross_rate
					, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt, @discount_amt, @discount_desc
					, @state_amt, @county_amt, @city_amt, @non_resale_amt
					, @netcharge, @ncdesc, @addl_charge, @addl_charge_desc, @line_total 
					--,@line_cancelled
					, @date_to_bill
					, @non_bill_flag, @modified_by, @modified_date, @modified_comments
					, @bill_type_flag, @comm_pct, @markup_pct, @rebate_pct, @discount_pct
					, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale
					, @taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai
					--,@reconcile_flag
					, @billing_amt, @cost_type, @cost_rate 
					, @net_base_rate, @gross_base_rate   --,@bill_cancelled
					, @est_nbr, @est_line_nbr, @est_rev_nbr, @ad_number, @mat_comp, @programming
					, @start_time, @end_time, @length, @remarks, @tag, @network_id
					,@daypart_id, @added_value, @link_line_number
					--,@station_id
					)
					
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[RADIO_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @onset_rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 					
			END 
		END
	END --@action = 'REVISE'
	
	IF @action = 'CANCEL' BEGIN	
		IF @line_nbr > 0 BEGIN
			IF @DEBUG = 1
				SELECT 'CANCEL' '**BLOCK'	  /* DEBUG */	
			/*PJH 05/03/18 - @@@@@@@@@@ */
			/*** Get the MAX REV & SEQ for a given ORDER/LINE ***/	
			SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
							@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
			FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)				
				
			IF @order_type = 'NP' BEGIN
				SET @line_cancelled = 1
				SELECT @bill_cancelled = BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[NEWSPAPER_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = @line_cancelled
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr --AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr	
				/* REVISIONS ON THIS LINE WITH NO AR_INV */
				IF @bill_cancelled > 0
					SET @bill_cancelled = 1
				ELSE
					SET @bill_cancelled = NULL
				IF @bill_cancelled = 1
					UPDATE NEWSPAPER_DETAIL
					SET	BILL_CANCELLED = 1
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND (AR_INV_NBR IS NULL)	
				/* OFFSET */
				INSERT INTO [dbo].[NEWSPAPER_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [PRINT_COLUMNS], [PRINT_INCHES], [PRINT_LINES], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], [LINE_CANCELLED],
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], [BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [COST_TYPE], [COST_RATE], [RATE_TYPE], [NP_CIRCULATION], [PRINT_QUANTITY])
						SELECT --DATE_TO_BILL, NON_BILL_FLAG??
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr,  1, [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [PRINT_COLUMNS], [PRINT_INCHES], [PRINT_LINES] * -1, [CONTRACT_QTY] * -1,
							[QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1,
							[DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NETCHARGE_DESC],
							[ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [PROD_CHARGE] * -1, [PROD_DESC], [COLOR_CHARGE] * -1, [COLOR_DESC], [LINE_TOTAL] * -1, @line_cancelled,
							[DATE_TO_BILL], 
							--NULL, NULL, NULL, NULL, [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,
							--NULL, NULL, 
							[NON_BILL_FLAG], @modified_by, @modified_date, @modified_comments, [BILL_TYPE_FLAG], [COMM_PCT],							   
							--NULL, NULL, NULL, NULL, 
							[BILLING_AMT] * -1, @bill_cancelled,
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE] * -1, [FLAT_ADDL_CHARGE] * -1, [FLAT_DISCOUNT_AMT] * -1, [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [COST_TYPE], [COST_RATE], [RATE_TYPE], [NP_CIRCULATION], [PRINT_QUANTITY] * -1
					FROM  [dbo].[NEWSPAPER_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr

				UPDATE NEWSPAPER_OTH_CHGS
				SET RATE = RATE * -1, AMOUNT = AMOUNT * -1 
				WHERE ORDER_NBR =  @order_nbr AND LINE_NBR = @line_nbr		
						
			END 
			ELSE IF @order_type = 'MA' BEGIN
				SET @line_cancelled = 1
				SELECT @bill_cancelled = BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[MAGAZINE_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = @line_cancelled
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr --AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr	
				/* REVISIONS ON THIS LINE WITH NO AR_INV */
				IF @bill_cancelled = 1
					UPDATE [MAGAZINE_DETAIL]
					SET	BILL_CANCELLED = 1
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND (AR_INV_NBR IS NULL)	
				/* OFFSET */
				INSERT INTO [dbo].[MAGAZINE_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
							[BLEED_PCT], [BLEED_AMT], [POSITION_PCT], [POSITION_AMT], [PREMIUM_PCT], [PREMIUM_AMT],
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], [BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [MG_CIRCULATION])
						SELECT
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, 1, [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [CONTRACT_QTY] * -1,
							[QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1,
							[DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NETCHARGE_DESC],
							[ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [PROD_CHARGE] * -1, [PROD_DESC], [COLOR_CHARGE] * -1, [COLOR_DESC], [LINE_TOTAL] * -1, --[LINE_CANCELLED],
							[BLEED_PCT], [BLEED_AMT] * -1, [POSITION_PCT], [POSITION_AMT] * -1, [PREMIUM_PCT], [PREMIUM_AMT] * -1,
							[DATE_TO_BILL], 
							--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], 
							@modified_by, @modified_date, @modified_comments, [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT] * -1, @bill_cancelled,
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE] * -1, [FLAT_ADDL_CHARGE] * -1, [FLAT_DISCOUNT_AMT] * -1, [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [MG_CIRCULATION]
					FROM  [dbo].[MAGAZINE_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
						
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[MAGAZINE_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @offset_rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 								   
			END 
			ELSE IF @order_type = 'IN' BEGIN
				SET @line_cancelled = 1
				SELECT @bill_cancelled = BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[INTERNET_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = @line_cancelled
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr --AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr	
				/* REVISIONS ON THIS LINE WITH NO AR_INV */
				IF @bill_cancelled > 0
					SET @bill_cancelled = 1
				ELSE
					SET @bill_cancelled = NULL
				IF @bill_cancelled = 1
					UPDATE [INTERNET_DETAIL]
					SET	BILL_CANCELLED = 1
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND (AR_INV_NBR IS NULL)	
				/* OFFSET */
				--PJH 12/06/18 - Added @line_market_code, @ad_server_id
				INSERT INTO [dbo].[INTERNET_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE]
							, [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [INTERNET_TYPE], [SIZE], [PROJ_IMPRESSIONS], [GUARANTEED_IMPRESS]
							, [URL], [TARGET_AUDIENCE], [COPY_AREA]
							, [JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
							, [QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
							, [DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
							, [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]           --,[LINE_CANCELLED]
							, [DATE_TO_BILL]
							--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
							--,[GLESEQ_STAE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
							--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
							, [NON_BILL_FLAG]
							, [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG]
							, [CREATIVE_SIZE], [PLACEMENT_1], [PLACEMENT_2]
							, [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
							, [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
							, [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
							--,[RECONCILE_FLAG], [ACT_IMPRESSIONS]
							--,[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
							, [BILLING_AMT], [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE] ,[BILL_CANCELLED]
							, [EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP]
							, [AD_SERVER_ID]
							, [MARKET_CODE]
							, [MEDIA_CHANNEL_ID]
							, [MEDIA_TACTIC_ID] )
						SELECT
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, 1, [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE]
							, [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [INTERNET_TYPE], [SIZE], [PROJ_IMPRESSIONS], [GUARANTEED_IMPRESS]
							, [URL], [TARGET_AUDIENCE], [COPY_AREA]
							, [JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
							, [QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1
							, [DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NCDESC]
							, [ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [LINE_TOTAL] * -1 --,[LINE_CANCELLED]
							, [DATE_TO_BILL]
							--,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
							--,[GLESEQ_STAE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
							--,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
							, [NON_BILL_FLAG]
							, @modified_by, @modified_date, @modified_comments, [BILL_TYPE_FLAG]
							, [CREATIVE_SIZE], [PLACEMENT_1], [PLACEMENT_2]
							, [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
							, [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
							, [TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
							--,[RECONCILE_FLAG], [ACT_IMPRESSIONS]
							--,[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
							, [BILLING_AMT] * -1, [COST_TYPE], [COST_RATE], [NET_BASE_RATE], [GROSS_BASE_RATE] ,@bill_cancelled
							, [EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP]
							, [AD_SERVER_ID]
							, [MARKET_CODE]
							, [MEDIA_CHANNEL_ID]
							, [MEDIA_TACTIC_ID]
					FROM  [dbo].[INTERNET_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
						
				--IF COALESCE(@prc_status,99) <> 99 BEGIN
				--	INSERT INTO [dbo].[INTERNET_ORDER_STATUS]
				--			([ORDER_NBR]
				--			,[LINE_NBR]
				--			,[REV_NBR]
				--			,[STATUS]
				--			,[REVISED_DATE]
				--			,[REVISED_BY])
				--		VALUES (@order_nbr, @line_nbr, @offset_rev_nbr, @prc_status, @modified_date, @modified_by)
				--END 								   
			END 
			ELSE IF @order_type = 'OD' BEGIN
				SET @line_cancelled = 1
				SELECT @bill_cancelled = BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[OUTDOOR_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = @line_cancelled
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr --AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr	
				/* REVISIONS ON THIS LINE WITH NO AR_INV */
				IF @bill_cancelled > 0
					SET @bill_cancelled = 1
				ELSE
					SET @bill_cancelled = NULL
				IF @bill_cancelled = 1
					UPDATE [OUTDOOR_DETAIL]
					SET	BILL_CANCELLED = 1
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND (AR_INV_NBR IS NULL)	
				/* OFFSET */
				INSERT INTO [dbo].[OUTDOOR_DETAIL]
						   ([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						   ,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						   ,[LOCATION], [COPY_AREA]
						   ,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						   ,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT]
						   ,[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NCDESC]
						   ,[ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL] --,[LINE_CANCELLED]
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
							@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, 1, [LINK_DETID], [POST_DATE], [END_DATE], [CLOSE_DATE]
						   ,[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [HEADLINE], [OUTDOOR_TYPE], [SIZE]
						   ,[LOCATION], [COPY_AREA]
						   ,[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD], [RATE_TYPE], [RATE_DESC]
						   ,[QUANTITY] * -1, [RATE], [NET_RATE], [GROSS_RATE], [EXT_NET_AMT] * -1, [EXT_GROSS_AMT] * -1, [COMM_AMT] * -1, [REBATE_AMT] * -1
						   ,[DISCOUNT_AMT] * -1, [DISCOUNT_DESC], [STATE_AMT] * -1, [COUNTY_AMT] * -1, [CITY_AMT] * -1, [NON_RESALE_AMT] * -1, [NETCHARGE] * -1, [NCDESC]
						   ,[ADDL_CHARGE] * -1, [ADDL_CHARGE_DESC], [LINE_TOTAL] * -1 --,[LINE_CANCELLED]
						   ,[DATE_TO_BILL]
						   --,[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP]
						   --,[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP]
						   --,[GLACODE_STATE], [GLACODE_COUNTY], [GLACODE_CITY]
						   ,[NON_BILL_FLAG]
						   ,@modified_by, @modified_date, @modified_comments, [BILL_TYPE_FLAG]
						   ,[COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
						   ,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
						   ,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
						   --,[RECONCILE_FLAG], [GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF]
						   ,[BILLING_AMT] * -1 , @bill_cancelled
						   ,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [IMPRESSIONS], [ACTUAL_IMPRESSIONS]
					FROM  [dbo].[OUTDOOR_DETAIL]
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr							   
			END 
			ELSE IF @order_type = 'TV' BEGIN
			
				IF @DEBUG = 1
					SELECT @action '@action', 'TV Cancel Line' 'Desc', @order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr
		
				SET @line_cancelled = 1
				SELECT @bill_cancelled = BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[TV_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = @line_cancelled
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr --AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr	
				/* REVISIONS ON THIS LINE WITH NO AR_INV */
				IF @bill_cancelled > 0
					SET @bill_cancelled = 1
				ELSE
					SET @bill_cancelled = NULL
				IF @bill_cancelled = 1
					UPDATE TV_DETAIL
					SET	BILL_CANCELLED = 1
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND (AR_INV_NBR IS NULL)	
				/* OFFSET */				

				INSERT INTO [dbo].[TV_DETAIL]
					([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS]
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC]
					,[STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT]
					,[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT], [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID]
					--PJH 08/18/17 - added new columns
					,[CABLE_NETWORK_STATION_CODE], [DAY_PART_ID], [ADDED_VALUE], [BOOKEND], [LINK_LINE_NUMBER]
					--,[STATION_ID]
					)
				SELECT
					@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, 1
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1]*-1, [SPOTS2]*-1, [SPOTS3]*-1, [SPOTS4]*-1, [SPOTS5]*-1, [SPOTS6]*-1, [SPOTS7]*-1, [TOTAL_SPOTS]*-1
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY]*-1, [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT]*-1, [EXT_GROSS_AMT]*-1, [COMM_AMT]*-1, [REBATE_AMT]*-1, [DISCOUNT_AMT]*-1, [DISCOUNT_DESC]
					,[STATE_AMT]*-1, [COUNTY_AMT]*-1, [CITY_AMT]*-1, [NON_RESALE_AMT]*-1
					,[NETCHARGE]*-1, [NCDESC], [ADDL_CHARGE]*-1, [ADDL_CHARGE_DESC], [LINE_TOTAL]*-1
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], @modified_by, @modified_date, @modified_comments
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT]*-1, [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,@bill_cancelled
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID]
					--PJH 08/18/17 - added new columns
					,[CABLE_NETWORK_STATION_CODE], [DAY_PART_ID], [ADDED_VALUE], [BOOKEND], [LINK_LINE_NUMBER]
					--,[STATION_ID]
				FROM  [dbo].[TV_DETAIL]
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
			END	
			ELSE IF @order_type = 'RA' BEGIN
				SET @line_cancelled = 1
				SELECT @bill_cancelled = BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				UPDATE [dbo].[RADIO_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = @line_cancelled
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr --AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr	
				/* REVISIONS ON THIS LINE WITH NO AR_INV */
				IF @bill_cancelled > 0
					SET @bill_cancelled = 1
				ELSE
					SET @bill_cancelled = NULL
				IF @bill_cancelled = 1
					UPDATE RADIO_DETAIL
					SET	BILL_CANCELLED = 1
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND (AR_INV_NBR IS NULL)	
				/* OFFSET */	
				INSERT INTO [dbo].[RADIO_DETAIL]
					([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV]
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1], [SPOTS2], [SPOTS3], [SPOTS4], [SPOTS5], [SPOTS6], [SPOTS7], [TOTAL_SPOTS]
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT], [DISCOUNT_AMT], [DISCOUNT_DESC]
					,[STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT]
					,[NETCHARGE], [NCDESC], [ADDL_CHARGE], [ADDL_CHARGE_DESC], [LINE_TOTAL]
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS]
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT], [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,[BILL_CANCELLED]
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID], [LINK_LINE_NUMBER]
					--PJH 08/18/17 - added new columns
					,[DAY_PART_ID], [ADDED_VALUE]
					--,[STATION_ID]
					)
				SELECT
					@order_nbr, @line_nbr, @offset_rev_nbr, @offset_seq_nbr, 1
					,[LINK_DETID], [BUY_TYPE], [START_DATE], [END_DATE], [MONTH_NBR], [YEAR_NBR]
					,[CLOSE_DATE], [MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE]
					,[DATE1], [DATE2], [DATE3], [DATE4], [DATE5], [DATE6], [DATE7]
					,[MONDAY], [TUESDAY], [WEDNESDAY], [THURSDAY], [FRIDAY], [SATURDAY], [SUNDAY]
					,[SPOTS1]*-1, [SPOTS2]*-1, [SPOTS3]*-1, [SPOTS4]*-1, [SPOTS5]*-1, [SPOTS6]*-1, [SPOTS7]*-1, [TOTAL_SPOTS]*-1
					,[JOB_NUMBER], [JOB_COMPONENT_NBR]
					,[QUANTITY]*-1, [RATE], [NET_RATE], [GROSS_RATE]
					,[EXT_NET_AMT]*-1, [EXT_GROSS_AMT]*-1, [COMM_AMT]*-1, [REBATE_AMT]*-1, [DISCOUNT_AMT]*-1, [DISCOUNT_DESC]
					,[STATE_AMT]*-1, [COUNTY_AMT]*-1, [CITY_AMT]*-1, [NON_RESALE_AMT]*-1
					,[NETCHARGE]*-1, [NCDESC], [ADDL_CHARGE]*-1, [ADDL_CHARGE_DESC], [LINE_TOTAL]*-1
					,[LINE_CANCELLED], [DATE_TO_BILL] --, [BILLING_USER] 
					,[NON_BILL_FLAG], @modified_by, @modified_date, @modified_comments
					,[BILL_TYPE_FLAG], [COMM_PCT], [MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT]
					,[TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE]
					,[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI]
					--,[RECONCILE_FLAG]
					,[BILLING_AMT]*-1, [COST_TYPE], [COST_RATE]
					,[NET_BASE_RATE], [GROSS_BASE_RATE]           ,@bill_cancelled
					,[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [AD_NUMBER], [MAT_COMP], [PROGRAMMING]
					,[START_TIME], [END_TIME], [LENGTH], [REMARKS], [TAG], [NETWORK_ID], [LINK_LINE_NUMBER]
					--PJH 08/18/17 - added new columns
					,[DAY_PART_ID], [ADDED_VALUE]
					--,[STATION_ID]
				FROM  [dbo].[RADIO_DETAIL]
				WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr
			END			
		END
	END --@action = 'CANCEL'	
	
	IF @action = 'RESTORE'
	BEGIN	
		IF @line_nbr > 0
			BEGIN
				IF @DEBUG = 1 
					SELECT 'RESTORE' 'BLOCK'  /* DEBUG */	
				/*PJH 05/03/18 - @@@@@@@@@@ */
				/*** Get the MAX REV & SEQ for a given ORDER/LINE ***/	
				SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
								@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
				FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)		
							
				IF @order_type = 'NP' BEGIN
					SELECT @billed=BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
					IF @billed > 0
						BEGIN
							SET @error_msg_w = 'This is a billed line and cannot be restored.'
							GOTO ERROR_MSG
						END						
					/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
					DELETE FROM [dbo].[NEWSPAPER_DETAIL] 
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr		
						AND [LINE_CANCELLED] = 1
					/* Get max after delete */	
					SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
									@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
					FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
						
					--SELECT 'Restore' 'Desc', @max_rev_nbr, @max_seq_nbr, @offset_rev_nbr, @offset_seq_nbr, @onset_rev_nbr, @onset_seq_nbr, @order_type /* DEBUG */		
										
					/* UPDATE ORIGINAL REV/SEQ TO ACTIVE, NOT CANCELED */
					UPDATE [dbo].[NEWSPAPER_DETAIL] SET ACTIVE_REV = 1, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr				
						
					/* UPDATE OTHER REV/SEQ TO NOT CANCELED, etc. */
					UPDATE [dbo].[NEWSPAPER_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] <> @max_rev_nbr AND [SEQ_NBR] <>  @max_seq_nbr	
						
					UPDATE NEWSPAPER_OTH_CHGS
					SET RATE = RATE * -1, AMOUNT = AMOUNT * -1 
					WHERE ORDER_NBR =  @order_nbr AND LINE_NBR = @line_nbr	
					
				END 
				ELSE IF @order_type = 'MA' BEGIN
					SELECT @billed=BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
					IF @billed > 0
						BEGIN
							SET @error_msg_w = 'This is a billed line and cannot be restored.'
							GOTO ERROR_MSG
						END						
					/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
					DELETE FROM [dbo].[MAGAZINE_DETAIL] 
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr		
						AND [LINE_CANCELLED] = 1
					/* Get max after delete */	
					SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
									@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
					FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
						
					--SELECT 'Restore' 'Desc', @max_rev_nbr, @max_seq_nbr, @offset_rev_nbr, @offset_seq_nbr, @onset_rev_nbr, @onset_seq_nbr, @order_type /* DEBUG */		
										
					/* UPDATE ORIGINAL REV/SEQ TO ACTIVE, NOT CANCELED */
					UPDATE [dbo].[MAGAZINE_DETAIL] SET ACTIVE_REV = 1, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr				
						
					/* UPDATE OTHER REV/SEQ TO NOT CANCELED, etc. */
					UPDATE [dbo].[MAGAZINE_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] <> @max_rev_nbr AND [SEQ_NBR] <>  @max_seq_nbr	
						
					--IF COALESCE(@prc_status,99) <> 99 BEGIN
					--	INSERT INTO [dbo].[MAGAZINE_ORDER_STATUS]
					--		([ORDER_NBR]
					--		,[LINE_NBR]
					--		,[REV_NBR]
					--		,[STATUS]
					--		,[REVISED_DATE]
					--		,[REVISED_BY])
					--	VALUES (@order_nbr, @line_nbr, @max_rev_nbr, @prc_status, @modified_date, @modified_by)
					--END 									
				END 
				ELSE IF @order_type = 'IN' BEGIN
					SELECT @billed=BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
					IF @billed > 0
						BEGIN
							SET @error_msg_w = 'This is a billed line and cannot be restored.'
							GOTO ERROR_MSG
						END						
					/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
					DELETE FROM [dbo].[INTERNET_DETAIL] 
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr		
						AND [LINE_CANCELLED] = 1
					/* Get max after delete */	
					SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
									@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
					FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
						
					--SELECT 'Restore' 'Desc', @max_rev_nbr, @max_seq_nbr, @offset_rev_nbr, @offset_seq_nbr, @onset_rev_nbr, @onset_seq_nbr, @order_type /* DEBUG */		
										
					/* UPDATE ORIGINAL REV/SEQ TO ACTIVE, NOT CANCELED */
					UPDATE [dbo].[INTERNET_DETAIL] SET ACTIVE_REV = 1, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr				
						
					/* UPDATE OTHER REV/SEQ TO NOT CANCELED, etc. */
					UPDATE [dbo].[INTERNET_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] <> @max_rev_nbr AND [SEQ_NBR] <>  @max_seq_nbr	
						
					--IF COALESCE(@prc_status,99) <> 99 BEGIN
					--	INSERT INTO [dbo].[INTERNET_ORDER_STATUS]
					--		([ORDER_NBR]
					--		,[LINE_NBR]
					--		,[REV_NBR]
					--		,[STATUS]
					--		,[REVISED_DATE]
					--		,[REVISED_BY])
					--	VALUES (@order_nbr, @line_nbr, @max_rev_nbr, @prc_status, @modified_date, @modified_by)
					--END 									
				END 
				ELSE IF @order_type = 'OD' BEGIN
					SELECT @billed=BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
					IF @billed > 0
						BEGIN
							SET @error_msg_w = 'This is a billed line and cannot be restored.'
							GOTO ERROR_MSG
						END						
					/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
					DELETE FROM [dbo].[OUTDOOR_DETAIL] 
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr		
						AND [LINE_CANCELLED] = 1
					/* Get max after delete */	
					SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
									@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
					FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
						
					--SELECT 'Restore' 'Desc', @max_rev_nbr, @max_seq_nbr, @offset_rev_nbr, @offset_seq_nbr, @onset_rev_nbr, @onset_seq_nbr, @order_type /* DEBUG */		
										
					/* UPDATE ORIGINAL REV/SEQ TO ACTIVE, NOT CANCELED */
					UPDATE [dbo].[OUTDOOR_DETAIL] SET ACTIVE_REV = 1, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr				
						
					/* UPDATE OTHER REV/SEQ TO NOT CANCELED, etc. */
					UPDATE [dbo].[OUTDOOR_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] <> @max_rev_nbr AND [SEQ_NBR] <>  @max_seq_nbr	
						
					--IF COALESCE(@prc_status,99) <> 99 BEGIN
					--	INSERT INTO [dbo].[OUTDOOR_ORDER_STATUS]
					--		([ORDER_NBR]
					--		,[LINE_NBR]
					--		,[REV_NBR]
					--		,[STATUS]
					--		,[REVISED_DATE]
					--		,[REVISED_BY])
					--	VALUES (@order_nbr, @line_nbr, @max_rev_nbr, @prc_status, @modified_date, @modified_by)
					--END 									
				END 
				ELSE IF @order_type = 'TV' BEGIN
					--SELECT @billed=BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
					--IF @billed > 0
					--	BEGIN
					--		SET @error_msg_w = 'This is a billed line and cannot be restored.'
					--		GOTO ERROR_MSG
					--	END	
					
					SELECT @billed=COUNT(1) FROM TV_DETAIL A 
					LEFT JOIN (
							SELECT ORDER_NBR, LINE_NBR, REV_NBR, AR_INV_NBR FROM TV_DETAIL
							WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr
							AND (AR_INV_NBR IS NOT NULL) AND AR_TYPE = 'VO' ) B
						ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REV_NBR = B.REV_NBR AND A.AR_INV_NBR = B.AR_INV_NBR
					WHERE A.ORDER_NBR = @order_nbr AND A.LINE_NBR = @line_nbr AND A.REV_NBR = @max_rev_nbr AND A.AR_INV_NBR IS NOT NULL
						AND B.ORDER_NBR IS NULL											
					/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
					DELETE FROM [dbo].[TV_DETAIL] 
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr		
						AND [LINE_CANCELLED] = 1
				
					/* Get max after delete */	
					SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
									@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
					FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
						
					/* UPDATE ORIGINAL REV/SEQ TO ACTIVE, NOT CANCELED */
					UPDATE [dbo].[TV_DETAIL] SET ACTIVE_REV = 1, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr				
						
					/* UPDATE OTHER REV/SEQ TO NOT CANCELED, etc. */
					UPDATE [dbo].[TV_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] <> @max_rev_nbr AND [SEQ_NBR] <>  @max_seq_nbr	
					
				END		
				ELSE IF @order_type = 'RA' BEGIN
					SELECT @billed=BILLED FROM advtf_med_line_billed(@order_nbr, @line_nbr, @order_type)
					IF @billed > 0
						BEGIN
							SET @error_msg_w = 'This is a billed line and cannot be restored.'
							GOTO ERROR_MSG
						END						
					/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
					DELETE FROM [dbo].[RADIO_DETAIL] 
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr		
						AND [LINE_CANCELLED] = 1
					/* Get max after delete */	
					SELECT @max_rev_nbr = MAX_REV_NBR, @max_seq_nbr = MAX_SEQ_NBR, @offset_rev_nbr = OFFSET_REV_NBR, @offset_seq_nbr = OFFSET_SEQ_NBR, 
									@onset_rev_nbr = ONSET_REV_NBR, @onset_seq_nbr = ONSET_SEQ_NBR, @order_type = ORDER_TYPE
					FROM advtf_med_get_max_rev_seq(@order_nbr, @line_nbr, @order_type)
						
					/* UPDATE ORIGINAL REV/SEQ TO ACTIVE, NOT CANCELED */
					UPDATE [dbo].[RADIO_DETAIL] SET ACTIVE_REV = 1, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] = @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] = @max_rev_nbr AND [SEQ_NBR] =  @max_seq_nbr				
						
					/* UPDATE OTHER REV/SEQ TO NOT CANCELED, etc. */
					UPDATE [dbo].[RADIO_DETAIL] SET ACTIVE_REV = NULL, [LINE_CANCELLED] = NULL, [BILL_CANCELLED] = NULL
					WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr AND [REV_NBR] <> @max_rev_nbr AND [SEQ_NBR] <>  @max_seq_nbr	
				END							
			END
	END --@action = 'RESTORE'		
	
	IF @action = 'COPY' BEGIN	
		IF @line_nbr > 0 BEGIN
			IF @DEBUG = 1
				SELECT 'COPY' '*BLOCK'	 /* DEBUG */	
			IF @order_type = 'NP' BEGIN
				SELECT @line_nbr=[LINE_NBR], @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
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

				SELECT @onset_rev_nbr = 0, @onset_seq_nbr = 0
					
				--SELECT @onset_rev_nbr, @onset_seq_nbr, @order_type, '@onset_rev_nbr, @onset_seq_nbr, @order_type' /* DEBUG */					
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				SELECT @line_nbr = MAX(LINE_NBR)+1 FROM [dbo].[NEWSPAPER_DETAIL] 
				WHERE [ORDER_NBR] =  @order_nbr

				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */
				SET @goto_id = 'CALC_PRINT_COPY'
				GOTO CALC_PRINT		
				AFTER_CALC_PRINT_COPY:
					
				INSERT INTO [dbo].[NEWSPAPER_DETAIL]
							([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
							[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
							[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [PRINT_COLUMNS], [PRINT_INCHES], [PRINT_LINES], [CONTRACT_QTY],
							[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
							[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
							[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
							[DATE_TO_BILL], --[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
							[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
							[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
							--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
							--[GLACODE_COUNTY], [GLACODE_CITY], 
							[NON_BILL_FLAG], [MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
							--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
							[BILLING_AMT], --[BILL_CANCELLED],
							[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
							[MAT_COMP], [SIZE_CODE], [COST_TYPE], [COST_RATE], [RATE_TYPE], [NP_CIRCULATION], [PRINT_QUANTITY])
						VALUES
							(@order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1, NULL, @start_date, @end_date, @close_date,
							@matl_close_date, @ext_close_date, @ext_matl_date, @size, @ad_number, @headline, @material, @edition_issue, @section,
							@job_number, @job_component_nbr, @rate_card_id, @rate_dtl_id, @print_columns, @print_inches, @print_lines, @contract_qty,
							@quantity, @rate, @net_rate, @gross_rate, @flat_net, @flat_gross, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt,
							@discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc,
							@addl_charge, @addl_charge_desc, @prod_charge, @prod_desc, @color_charge, @color_desc, @line_total, --@line_cancelled,
							@date_to_bill, --@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip,
							@markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale,
							@taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag,
							--@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, @glacode_state,
							--@glacode_county, @glacode_city, 
							@non_bill_flag, @modified_by, @modified_date, @modified_comments, @bill_type_flag, @comm_pct, 							   
							--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
							@billing_amt, --@bill_cancelled,
							@est_nbr, @est_line_nbr, @est_rev_nbr, @flat_netcharge, @flat_addl_charge, @flat_discount_amt, @production_size,
							@mat_comp, @size_code, @cost_type, @cost_rate, @rate_type, @np_circulation, @print_quantity)			
			END 
			ELSE IF @order_type = 'MA' BEGIN
				SELECT @line_nbr=[LINE_NBR], @start_date=[START_DATE], @end_date=[END_DATE], @close_date=[CLOSE_DATE],
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

				SELECT @onset_rev_nbr = 0, @onset_seq_nbr = 0
					
				--SELECT @onset_rev_nbr, @onset_seq_nbr, @order_type, '@onset_rev_nbr, @onset_seq_nbr, @order_type' /* DEBUG */					
					
				/* REMOVE ACTIVE REV FLAG FROM ORIGINAL LINE */
				SELECT @line_nbr = MAX(LINE_NBR)+1 FROM [dbo].[MAGAZINE_DETAIL] 
				WHERE [ORDER_NBR] =  @order_nbr

				/* ONSET */
				/* uf_get_rates_and_tax */
				/* uf_get_rates_and_tax... uf_calc_print */
				SET @goto_id = 'CALC_PRINT_COPY2'
				GOTO CALC_PRINT		
				AFTER_CALC_PRINT_COPY2:
					
				INSERT INTO [dbo].[MAGAZINE_DETAIL]
					([ORDER_NBR], [LINE_NBR], [REV_NBR], [SEQ_NBR], [ACTIVE_REV], [LINK_DETID], [START_DATE], [END_DATE], [CLOSE_DATE],
						[MATL_CLOSE_DATE], [EXT_CLOSE_DATE], [EXT_MATL_DATE], [SIZE], [AD_NUMBER], [HEADLINE], [MATERIAL], [EDITION_ISSUE], [SECTION],
						[JOB_NUMBER], [JOB_COMPONENT_NBR], [RATE_CARD_ID], [RATE_DTL_ID], [CONTRACT_QTY],
						[QUANTITY], [RATE], [NET_RATE], [GROSS_RATE], [FLAT_NET], [FLAT_GROSS], [EXT_NET_AMT], [EXT_GROSS_AMT], [COMM_AMT], [REBATE_AMT],
						[DISCOUNT_AMT], [DISCOUNT_DESC], [STATE_AMT], [COUNTY_AMT], [CITY_AMT], [NON_RESALE_AMT], [NETCHARGE], [NETCHARGE_DESC],
						[ADDL_CHARGE], [ADDL_CHARGE_DESC], [PROD_CHARGE], [PROD_DESC], [COLOR_CHARGE], [COLOR_DESC], [LINE_TOTAL], --[LINE_CANCELLED],
						[BLEED_PCT], [BLEED_AMT], [POSITION_PCT], [POSITION_AMT], [PREMIUM_PCT], [PREMIUM_AMT],
						[DATE_TO_BILL], 
						--[BILLING_USER], [AR_INV_NBR], [AR_TYPE], [AR_INV_SEQ], [GLEXACT], [GLESEQ_SALES], [GLESEQ_COS], [GLESEQ_WIP],
						[MARKUP_PCT], [REBATE_PCT], [DISCOUNT_PCT], [TAX_CODE], [TAX_CITY_PCT], [TAX_COUNTY_PCT], [TAX_STATE_PCT], [TAX_RESALE],
						[TAXAPPLYC], [TAXAPPLYLN], [TAXAPPLYND], [TAXAPPLYNC], [TAXAPPLYR], [TAXAPPLYAI], [RECONCILE_FLAG],
						--[GLESEQ_STATE], [GLESEQ_COUNTY], [GLESEQ_CITY], [GLEXACT_DEF], [GLACODE_SALES], [GLACODE_COS], [GLACODE_WIP], [GLACODE_STATE],
						--[GLACODE_COUNTY], [GLACODE_CITY], 
						[NON_BILL_FLAG], 
						[MODIFIED_BY], [MODIFIED_DATE], [MODIFIED_COMMENTS], [BILL_TYPE_FLAG], [COMM_PCT],							   
						--[GLESEQ_SALES_DEF], [GLESEQ_COS_DEF], [GLACODE_SALES_DEF], [GLACODE_COS_DEF], 
						[BILLING_AMT], --[BILL_CANCELLED],
						[EST_NBR], [EST_LINE_NBR], [EST_REV_NBR], [FLAT_NETCHARGE], [FLAT_ADDL_CHARGE], [FLAT_DISCOUNT_AMT], [PRODUCTION_SIZE],
						[MAT_COMP], [SIZE_CODE], [MG_CIRCULATION])
				VALUES
					(@order_nbr, @line_nbr, @onset_rev_nbr, @onset_seq_nbr, 1, NULL, @start_date, @end_date, @close_date,
						@matl_close_date, @ext_close_date, @ext_matl_date, @size, @ad_number, @headline, @material, @edition_issue, @section,
						@job_number, @job_component_nbr, @rate_card_id, @rate_dtl_id, @contract_qty,
						@quantity, @rate, @net_rate, @gross_rate, @flat_net, @flat_gross, @ext_net_amt, @ext_gross_amt, @comm_amt, @rebate_amt,
						@discount_amt, @discount_desc, @state_amt, @county_amt, @city_amt, @non_resale_amt, @netcharge, @ncdesc,
						@addl_charge, @addl_charge_desc, @prod_charge, @prod_desc, @color_charge, @color_desc, @line_total, --@line_cancelled,
						@bleed_pct, @bleed_amt, @position_pct, @position_amt, @premium_pct, @premium_amt, 
						@date_to_bill, 
						--@billing_user, @ar_inv_nbr, @ar_type, @ar_inv_seq, @glexact, @gleseq_sales, @gleseq_cos, @gleseq_wip,
						@markup_pct, @rebate_pct, @discount_pct, @tax_code, @tax_city_pct, @tax_county_pct, @tax_state_pct, @tax_resale,
						@taxapplyc, @taxapplyln, @taxapplynd, @taxapplync, @taxapplyr, @taxapplyai, @reconcile_flag,
						--@gleseq_state, @gleseq_county, @gleseq_city, @glexact_def, @glacode_sales, @glacode_cos, @glacode_wip, @glacode_state,
						--@glacode_county, @glacode_city, 
						@non_bill_flag, 
						@modified_by, @modified_date, @modified_comments, @bill_type_flag, @comm_pct,								
						--@gleseq_sales_def, @gleseq_cos_def, @glacode_sales_def, @glacode_cos_def, 
						@billing_amt, --@bill_cancelled,
						@est_nbr, @est_line_nbr, @est_rev_nbr, @flat_netcharge, @flat_addl_charge, @flat_discount_amt, @production_size,
						@mat_comp, @size_code, @mg_circulation)			
			END 
		END
	END --@action = 'COPY'	
	
	IF @order_type = 'NP'
		UPDATE H 
		SET H.START_DATE = D.START_DATE, H.END_DATE = D.END_DATE, PRINTED = NULL
		FROM NEWSPAPER_HEADER  H
			INNER JOIN 
			(SELECT MAX(ORDER_NBR) ORDER_NBR, MIN(START_DATE) START_DATE, MAX(END_DATE) END_DATE 
				FROM NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1) D
			ON H.ORDER_NBR = D.ORDER_NBR
	ELSE IF @order_type = 'MA'
		UPDATE H 
		SET H.START_DATE = D.START_DATE, H.END_DATE = D.END_DATE, PRINTED = NULL
		FROM MAGAZINE_HEADER  H
			INNER JOIN 
			(SELECT MAX(ORDER_NBR) ORDER_NBR, MIN(START_DATE) START_DATE, MAX(END_DATE) END_DATE 
				FROM MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1) D
			ON H.ORDER_NBR = D.ORDER_NBR
	ELSE IF @order_type = 'RA'
		UPDATE H 
		SET H.START_DATE = D.START_DATE, H.END_DATE = D.END_DATE, PRINTED = NULL
		FROM RADIO_HDR  H
			INNER JOIN 
			(SELECT MAX(ORDER_NBR) ORDER_NBR, MIN(START_DATE) START_DATE, MAX(END_DATE) END_DATE 
				FROM RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1) D
			ON H.ORDER_NBR = D.ORDER_NBR
	ELSE IF @order_type = 'TV'
		UPDATE H 
		SET H.START_DATE = D.START_DATE, H.END_DATE = D.END_DATE, PRINTED = NULL
		FROM TV_HDR  H
			INNER JOIN 
			(SELECT MAX(ORDER_NBR) ORDER_NBR, MIN(START_DATE) START_DATE, MAX(END_DATE) END_DATE 
				FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1) D
			ON H.ORDER_NBR = D.ORDER_NBR
	ELSE IF @order_type = 'IN'
		UPDATE H 
		SET H.START_DATE = D.START_DATE, H.END_DATE = D.END_DATE, PRINTED = NULL
		FROM INTERNET_HEADER  H
			INNER JOIN 
			(SELECT MAX(ORDER_NBR) ORDER_NBR, MIN(START_DATE) START_DATE, MAX(END_DATE) END_DATE 
				FROM INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1) D
			ON H.ORDER_NBR = D.ORDER_NBR
	ELSE IF @order_type = 'OD'
		UPDATE H 
		SET H.START_DATE = D.START_DATE, H.END_DATE = D.END_DATE, PRINTED = NULL
		FROM OUTDOOR_HEADER  H
			INNER JOIN 
			(SELECT MAX(ORDER_NBR) ORDER_NBR, MIN(POST_DATE) START_DATE, MAX(END_DATE) END_DATE 
				FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1) D
			ON H.ORDER_NBR = D.ORDER_NBR

	--COMMIT TRAN TD1
	
	--IF @@TRANCOUNT > 0 BEGIN
	--	SELECT 'DETAIL COMMIT'
	--	--COMMIT TRAN TD1
	--END	
	
	/*================================================================= END =====================================================================*/
		
	GOTO ENDIT
	
	CALC_PRINT:
		
		SET @error_msg_w = ''
		
		/* PJH 01/30/19 - Change how to calc net rate for Strata - Added @strata_net_calc */

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

		IF @error_msg_w <> ''
			GOTO ERROR_MSG


		IF @goto_id = 'CALC_PRINT_NEW' GOTO AFTER_CALC_PRINT_NEW 
		IF @goto_id = 'CALC_PRINT_COPY' GOTO AFTER_CALC_PRINT_COPY /* NP */
		IF @goto_id = 'CALC_PRINT_COPY2' GOTO AFTER_CALC_PRINT_COPY2 /* MA */
		--IF @goto_id = 'CALC_PRINT_COPY3' GOTO AFTER_CALC_PRINT_COPY3 /* IN */
		--IF @goto_id = 'CALC_PRINT_COPY4' GOTO AFTER_CALC_PRINT_COPY4 /* OD */
		IF @goto_id = 'CALC_PRINT_REVISE' GOTO AFTER_CALC_PRINT_REVISE /* NP */
		IF @goto_id = 'CALC_PRINT_REVISE2' GOTO AFTER_CALC_PRINT_REVISE2 /* MA */
		IF @goto_id = 'CALC_PRINT_REVISE3' GOTO AFTER_CALC_PRINT_REVISE3 /* IN */
		IF @goto_id = 'CALC_PRINT_REVISE4' GOTO AFTER_CALC_PRINT_REVISE4 /* OD */
		IF @goto_id = 'CALC_PRINT_UPDATE' GOTO AFTER_CALC_PRINT_UPDATE /* NP */
		IF @goto_id = 'CALC_PRINT_UPDATE2' GOTO AFTER_CALC_PRINT_UPDATE2 /* MA */
		IF @goto_id = 'CALC_PRINT_UPDATE3' GOTO AFTER_CALC_PRINT_UPDATE3 /* IN */
		IF @goto_id = 'CALC_PRINT_UPDATE4' GOTO AFTER_CALC_PRINT_UPDATE4 /* OD */

	CALC_BRDCAST:
		
		SET @error_msg_w = ''
		
		/* PJH 01/30/19 - Change how to calc net rate for Strata - Added @strata_net_calc */
		
		exec dbo.advsp_med_calc_brdcast @quantity  OUTPUT, @total_spots  OUTPUT, @bill_type_flag  OUTPUT, @tax_city_pct  OUTPUT, @tax_county_pct  OUTPUT, @tax_state_pct  OUTPUT, @comm_pct  OUTPUT, @markup_pct  OUTPUT, 
			@rebate_pct  OUTPUT, @discount_pct  OUTPUT, @rebate_amt_override  OUTPUT, @rebate_pct_override  OUTPUT, @markup_pct_override  OUTPUT, @comm_pct_override  OUTPUT, @ext_net_amt_override  OUTPUT, @comm_pct_or  OUTPUT, 
			@markup_pct_or  OUTPUT, @rebate_pct_or  OUTPUT, @rebate_amt_or  OUTPUT, @net_rate  OUTPUT, @gross_rate  OUTPUT, @netcharge  OUTPUT, @addl_charge  OUTPUT, @net_gross  OUTPUT, @temp_net_gross  OUTPUT, @cost_rate  OUTPUT, 
			@g_charge  OUTPUT, @n_charge  OUTPUT, @ext_gross_amt  OUTPUT, @rate  OUTPUT, @comm_amt  OUTPUT, @ext_net_amt  OUTPUT, @rebate_amt  OUTPUT, @discount_amt  OUTPUT, @state_tax  OUTPUT, @county_tax  OUTPUT, @city_tax  OUTPUT, 
			@ven_tax  OUTPUT, @taxapplyc  OUTPUT, @taxapplyln  OUTPUT, @taxapplynd  OUTPUT, @taxapplync  OUTPUT, @taxapplyr  OUTPUT, @taxapplyai  OUTPUT, @state_rnd  OUTPUT, @county_rnd  OUTPUT, @city_rnd  OUTPUT, @ven_rnd  OUTPUT, 
			@tax_resale  OUTPUT, @state_ac  OUTPUT, @county_ac  OUTPUT, @city_ac  OUTPUT, @addl_charge_taxes  OUTPUT, @resale_tax_amt  OUTPUT, @sales_tax_amt  OUTPUT, @bill_amt  OUTPUT, @billing_amt  OUTPUT, @line_total  OUTPUT, 
			@state_amt  OUTPUT, @county_amt  OUTPUT, @city_amt  OUTPUT, @non_resale_amt  OUTPUT, @error_msg_w  OUTPUT, @override_non_resale_amt, @strata_net_calc

		IF @error_msg_w <> ''
			GOTO ERROR_MSG

		IF @goto_id = 'CALC_BRDCAST_NEW' GOTO AFTER_CALC_BRDCAST_NEW 
		--IF @goto_id = 'CALC_BRDCAST_COPY' GOTO AFTER_CALC_PRINT_COPY /* TV */
		--IF @goto_id = 'CALC_BRDCAST_COPY2' GOTO AFTER_CALC_PRINT_COPY2 /* RA */
		IF @goto_id = 'CALC_BRDCAST_REVISE' GOTO AFTER_CALC_BRDCAST_REVISE /* TV */
		IF @goto_id = 'CALC_BRDCAST_REVISE2' GOTO AFTER_CALC_BRDCAST_REVISE2 /* RA */
		IF @goto_id = 'CALC_BRDCAST_UPDATE' GOTO AFTER_CALC_BRDCAST_UPDATE /* TV */
		IF @goto_id = 'CALC_BRDCAST_UPDATE2' GOTO AFTER_CALC_BRDCAST_UPDATE2 /* RA */


/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		

			--SELECT @error_msg_w as ErrorMessage;
			
			SELECT 'DETAIL ERROR CONTROL'
			
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
		SET @ret_val_s = 'No Error from Dtl'

END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		SELECT 'DETAIL ERROR ROLLBACK'
		--ROLLBACK TRAN TD1
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'   /* DEBUG */	
	
	SET @ret_val = -1
	SET @ret_val_s = @ErMessage

END CATCH

RETURN

SELECT 'HELP - How did I get here??'
GO

GRANT EXECUTE ON [advsp_revise_order_detail] TO PUBLIC AS dbo
GO

