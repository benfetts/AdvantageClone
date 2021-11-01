/****** Object:  UserDefinedFunction [dbo].[advtf_advance_bill_by_job]    Script Date: 05/15/2015 16:07:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_get_tax_info]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_get_tax_info]
GO
 
/****** Object:  UserDefinedFunction [dbo].[advtf_med_get_tax_info]    Script Date: 05/15/2015 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
***********************************************************************************************************
PJH 10/14/15 - IF @net_gross = 1 (Gross) Then @rebate_pct = @rebate_pct_p ELSE 0
PJH 04/07/17 - Added AND @comm_pct_v > 0 
***********************************************************************************************************
*/

/* 
SELECT * FROM MAGAZINE_HEADER WHERE ORDER_NBR > 700
SELECT TAX_CODE, BILL_TYPE_FLAG, * FROM MAGAZINE_DETAIL WHERE TAX_CITY_PCT > 0 --ORDER_NBR > 700

SELECT DEF_SALES_TAX, * FROM VENDOR WHERE VN_CATEGORY = 'T'
SELECT PRD_NEWS_TAX_CODE, * FROM PRODUCT

SELECT * FROM SALES_TAX

SELECT * FROM advtf_med_get_tax_info('MA', 'amer', 1, 'xyz', 'xyz', 'xyz', 3, '01-01-14', 'NEW')
SELECT * FROM advtf_med_get_tax_info('NP', 'indin', 1, 'xyz', 'xyz', 'xyz', 3, '01-01-14', 'NEW')
SELECT * FROM advtf_med_get_tax_info('TV', 'kdtv', 1, 'xyz', 'xyz', 'xyz', 3, '01-01-14', 'NEW')

--advtf_med_get_tax_info(@order_type, @vn_code, @net_gross, @cl_code, @div_code, @prd_code, @bill_type_flag, @start_date, @action)

@order_type ('NP', 'MA', 'TV', etc.)
@action = 'NEW', 'SETUP', 'COPY')
*/

CREATE FUNCTION [dbo].[advtf_med_get_tax_info] (
		@order_type varchar(10), 
		@vn_code varchar(6),
		@net_gross smallint, 
		@cl_code varchar(6), 
		@div_code varchar(6), 
		@prd_code varchar(6), 
		@bill_type_flag smallint , 
		@start_date smalldatetime,
		@action varchar(10))
	RETURNS @med_defaults TABLE ( 
		[TAX_CITY_PCT] [decimal](7, 3) NULL,
		[TAX_COUNTY_PCT] [decimal](7, 3) NULL,
		[TAX_STATE_PCT] [decimal](7, 3) NULL,
		[TAX_RESALE] [smallint] NULL,
		[TAXAPPLYC] [smallint] NULL,
		[TAXAPPLYLN] [smallint] NULL,
		[TAXAPPLYND] [smallint] NULL,
		[TAXAPPLYNC] [smallint] NULL,
		[TAXAPPLYR] [smallint] NULL,
		[TAXAPPLYAI] [smallint] NULL,
		[COMM_PCT] [decimal](7, 3) NULL,
		[MARKUP_PCT] [decimal](7, 3) NULL,
		[REBATE_PCT] [decimal](7, 3) NULL,
		[TAX_CODE] [varchar](4) )
AS
BEGIN
		DECLARE @adv_bill bit, @calc_method smallint
		
		/*VENDOR DEFAULTS*/
		DECLARE @default smallint, @use_tax_flags_v smallint, @issues_v smallint
		DECLARE @matl_close_days_v smallint, @space_close_days_v smallint, @net_gross_v smallint, @sunday_circ_v int, @daily_circ_v int
		DECLARE @taxapplyln_v smallint, @taxapplynd_v smallint, @taxapplync_v smallint, @taxapplyai_v smallint, @taxapplyc_v smallint, @taxapplyr_v smallint
		DECLARE @sales_tax_v varchar(6), @office_code_v varchar(6), @mkt_code_v varchar(10)
		DECLARE @cycle_v varchar(3), @def_rep1_v varchar(4), @def_rep2_v varchar(4), @def_size_v varchar(10), @category_v varchar(1)
		DECLARE @comm_pct_v decimal(7, 3), @tax_code_v varchar(4), @units_v varchar(2)
		DECLARE @overage_pct_v decimal(7, 3), @column_size_v decimal(14, 4)		
		
		DECLARE @end_date smalldatetime, @matl_close_date smalldatetime, @space_close_date smalldatetime

		DECLARE 	
			@tax_code varchar (4) ,
			@tax_city_pct decimal (7, 3) ,
			@tax_county_pct decimal (7, 3) ,
			@tax_state_pct decimal (7, 3) ,
			@tax_resale smallint ,
			@taxapplyc smallint ,
			@taxapplyln smallint ,
			@taxapplynd smallint ,
			@taxapplync smallint ,
			@taxapplyr smallint ,
			@taxapplyai smallint ,
			@comm_pct decimal (7, 3) ,
			@markup_pct decimal (7, 3) ,
			@rebate_pct decimal (7, 3) = NULL
									
		DECLARE @net_w decimal (15, 2) = 0,  @gross_w decimal (15, 2) = 0, @comm_w decimal (15, 2) = 0

		DECLARE @taxapplyln_p smallint, @taxapplynd_p smallint, @taxapplync_p smallint, @taxapplyai_p smallint, @taxapplyc_p smallint, @taxapplyr_p smallint
		DECLARE @comm_pct_p decimal(7, 3), @rebate_pct_p decimal(7, 3) 
		DECLARE @prd_bill_days smallint, @prd_bf_af smallint
		DECLARE @tax_code_p varchar(4), @use_tax_flags_p smallint, @sales_tax_p varchar(6)			

		DECLARE @tax_resale_w smallint, @use_tax_flags_w smallint, @set_defaults_w smallint = 1					
		
		-- 'TAX DEFAULTS-BEG'

		SET @use_tax_flags_w = 0

		/* Get Vendor info */
		BEGIN
			SELECT @comm_pct_v=VN_COMM, @tax_code_v=DEF_SALES_TAX, @use_tax_flags_v=USE_TAX_FLAGS, @taxapplyc_v=TAXAPPLYC, 
					@taxapplyln_v=TAXAPPLYLN, @taxapplynd_v=TAXAPPLYND, @taxapplync_v=TAXAPPLYNC, @taxapplyr_v=TAXAPPLYR, @taxapplyai_v=TAXAPPLYAI,
					@office_code_v=OFFICE_CODE, @units_v=DEF_UNITS, @daily_circ_v=DAILY_CIRC, @sunday_circ_v=SUNDAY_CIRC, @net_gross_v=DEF_NET_GROSS, 
					@matl_close_days_v=MATL_CLOSE, @space_close_days_v=SPACE_CLOSE, @mkt_code_v=MARKET_CODE, @column_size_v=COLUMN_SIZE, @issues_v=ISSUES, @cycle_v=CYCLE,
					@def_rep1_v=DEF_VN_REP1, @def_rep2_v=DEF_VN_REP2, @def_size_v=DEF_SIZE, @overage_pct_v=OVERAGE_PCT, @category_v=VN_CATEGORY
			FROM dbo.VENDOR
			WHERE VN_CODE=@vn_code;	
		END
		/* Get Product info */
		IF @order_type = 'NP' BEGIN
			SELECT @tax_code_p=PRD_NEWS_TAX_CODE, @comm_pct_p=PRD_NEWS_COMM, @rebate_pct_p=PRD_NEWS_REBATE, @use_tax_flags_p=USE_TAX_FLAGS_N, @taxapplyc_p=TAXAPPLYC_N, 
					@taxapplyln_p=TAXAPPLYLN_N, @taxapplynd_p=TAXAPPLYND_N, @taxapplync_p=TAXAPPLYNC_N, @taxapplyr_p=TAXAPPLYR_N, @taxapplyai_p=TAXAPPLYAI_N,
					@prd_bill_days=PRD_NEWS_DAYS, @prd_bf_af=PRD_NEWS_BF_AF
			FROM dbo.PRODUCT
			WHERE CL_CODE=@cl_code AND DIV_CODE=@div_code AND PRD_CODE=@prd_code;		
		END		
		ELSE IF @order_type = 'MA' BEGIN
			SELECT @tax_code_p=PRD_MAG_TAX_CODE, @comm_pct_p=PRD_MAG_COMM, @rebate_pct_p=PRD_MAG_REBATE, @use_tax_flags_p=USE_TAX_FLAGS_M, @taxapplyc_p=TAXAPPLYC_M, 
					@taxapplyln_p=TAXAPPLYLN_M, @taxapplynd_p=TAXAPPLYND_M, @taxapplync_p=TAXAPPLYNC_M, @taxapplyr_p=TAXAPPLYR_M, @taxapplyai_p=TAXAPPLYAI_M,
					@prd_bill_days=PRD_MAG_DAYS, @prd_bf_af=PRD_MAG_BF_AF
			FROM dbo.PRODUCT
			WHERE CL_CODE=@cl_code AND DIV_CODE=@div_code AND PRD_CODE=@prd_code;		
		END		
		ELSE IF @order_type = 'IN' BEGIN
			SELECT @tax_code_p=PRD_MISC_TAX_CODE, @comm_pct_p=PRD_MISC_COMM, @rebate_pct_p=PRD_MISC_REBATE, @use_tax_flags_p=USE_TAX_FLAGS_I, @taxapplyc_p=TAXAPPLYC_I, 
					@taxapplyln_p=TAXAPPLYLN_I, @taxapplynd_p=TAXAPPLYND_I, @taxapplync_p=TAXAPPLYNC_I, @taxapplyr_p=TAXAPPLYR_I, @taxapplyai_p=TAXAPPLYAI_I,
					@prd_bill_days=PRD_MISC_DAYS, @prd_bf_af=PRD_MISC_BF_AF
			FROM dbo.PRODUCT
			WHERE CL_CODE=@cl_code AND DIV_CODE=@div_code AND PRD_CODE=@prd_code;		
		END		
		ELSE IF @order_type = 'OD' BEGIN
			SELECT @tax_code_p=PRD_OTDR_TAX_CODE, @comm_pct_p=PRD_OTDR_COMM, @rebate_pct_p=PRD_OTDR_REBATE, @use_tax_flags_p=USE_TAX_FLAGS_O, @taxapplyc_p=TAXAPPLYC_O, 
					@taxapplyln_p=TAXAPPLYLN_O, @taxapplynd_p=TAXAPPLYND_O, @taxapplync_p=TAXAPPLYNC_O, @taxapplyr_p=TAXAPPLYR_O, @taxapplyai_p=TAXAPPLYAI_O,
					@prd_bill_days=PRD_OTDR_DAYS, @prd_bf_af=PRD_OTDR_BF_AF
			FROM dbo.PRODUCT
			WHERE CL_CODE=@cl_code AND DIV_CODE=@div_code AND PRD_CODE=@prd_code;		
		END						
		ELSE IF @order_type = 'TV' BEGIN
			SELECT @tax_code_p=PRD_TV_TAX_CODE, @comm_pct_p=PRD_TV_COMM, @rebate_pct_p=PRD_TV_REBATE, @use_tax_flags_p=USE_TAX_FLAGS_T, @taxapplyc_p=TAXAPPLYC_T, 
					@taxapplyln_p=TAXAPPLYLN_T, @taxapplynd_p=TAXAPPLYND_T, @taxapplync_p=TAXAPPLYNC_T, @taxapplyr_p=TAXAPPLYR_T, @taxapplyai_p=TAXAPPLYAI_T,
					@prd_bill_days=PRD_TV_DAYS, @prd_bf_af=PRD_TV_BF_AF
			FROM dbo.PRODUCT
			WHERE CL_CODE=@cl_code AND DIV_CODE=@div_code AND PRD_CODE=@prd_code;		
		END
		ELSE IF @order_type = 'RA' BEGIN
			SELECT @tax_code_p=PRD_RADIO_TAX_CODE, @comm_pct_p=PRD_RADIO_COMM, @rebate_pct_p=PRD_RADIO_REBATE, @use_tax_flags_p=USE_TAX_FLAGS_R, @taxapplyc_p=TAXAPPLYC_R, 
					@taxapplyln_p=TAXAPPLYLN_R, @taxapplynd_p=TAXAPPLYND_R, @taxapplync_p=TAXAPPLYNC_R, @taxapplyr_p=TAXAPPLYR_R, @taxapplyai_p=TAXAPPLYAI_R,
					@prd_bill_days=PRD_RADIO_DAYS, @prd_bf_af=PRD_RADIO_BF_AF
			FROM dbo.PRODUCT
			WHERE CL_CODE=@cl_code AND DIV_CODE=@div_code AND PRD_CODE=@prd_code;		
		END		
		
		/* If NEW/SETUP/COPY Get default from Ven/Prd */
		IF (@action = 'NEW' OR @action = 'SETUP' OR @action = 'COPY') BEGIN
			SET @taxapplyln = 0
			SET @taxapplynd = 0
			SET @taxapplync = 0
			SET @taxapplyai = 0
			SET @taxapplyc = 0
			SET @taxapplyr =  0
			IF (@tax_code_v) IS NOT NULL BEGIN
				SET @tax_code = @tax_code_v
				IF @use_tax_flags_v = 1 BEGIN  --Use flags from vendor if exists
					SET @use_tax_flags_w = @use_tax_flags_v
					SET @taxapplyln = @taxapplyln_v
					SET @taxapplynd = @taxapplynd_v
					SET @taxapplync = @taxapplync_v
					SET @taxapplyai = @taxapplyai_v
					SET @taxapplyc = @taxapplyc_v
					SET @taxapplyr =  @taxapplyr_v
				END	
				ELSE BEGIN
					IF @use_tax_flags_p = 1 BEGIN  --Else use from product if exists
						SET @use_tax_flags_w = @use_tax_flags_p
						SET @taxapplyln = @taxapplyln_p
						SET @taxapplynd = @taxapplynd_p
						SET @taxapplync = @taxapplync_p
						SET @taxapplyai = @taxapplyai_p
						SET @taxapplyc = @taxapplyc_p
						SET @taxapplyr =  @taxapplyr_p
					END
					ELSE BEGIN  --default all flags on
						SET @use_tax_flags_w = 1
						SET @taxapplyln = 1
						SET @taxapplynd = 1
						SET @taxapplync = 1
						SET @taxapplyai = 1
						SET @taxapplyc = 1
						SET @taxapplyr =  1	
					END
				END				
			END		
			ELSE BEGIN
				SET @tax_code = @tax_code_p
				IF @use_tax_flags_p = 1	BEGIN
					SET @use_tax_flags_w = @use_tax_flags_p
					SET @taxapplyln = @taxapplyln_p
					SET @taxapplynd = @taxapplynd_p
					SET @taxapplync = @taxapplync_p
					SET @taxapplyai = @taxapplyai_p
					SET @taxapplyc = @taxapplyc_p
					SET @taxapplyr =  @taxapplyr_p	
				END	
				ELSE BEGIN  --default all flags on
					SET @use_tax_flags_w = 1
					SET @taxapplyln = 1
					SET @taxapplynd = 1
					SET @taxapplync = 1
					SET @taxapplyai = 1
					SET @taxapplyc = 1
					SET @taxapplyr =  1	
				END				
			END
		END		

		--SET @tax_code = NULL

		IF (@action = 'NEW' OR @action = 'SETUP' OR @action = 'COPY') BEGIN
			IF @tax_code_v  IS NOT NULL SET @tax_code = @tax_code_v
			ELSE IF @tax_code_p IS NOT NULL SET @tax_code = @tax_code_p
		END
		
		IF @tax_code = ''
			SET @tax_code = NULL
	
		IF @tax_code IS NOT NULL BEGIN			
			SELECT	 @tax_city_pct=TAX_CITY_PCT, @tax_county_pct=TAX_COUNTY_PCT,
						@tax_state_pct=TAX_STATE_PCT, @tax_resale=TAX_RESALE
			FROM	 dbo.advtf_med_get_tax_pcts(@tax_code) /* table-valued function */
			WHERE	 TAX_CODE=@tax_code;		
		END
		ELSE BEGIN
			SET @tax_city_pct = 0
			SET @tax_county_pct = 0
			SET @tax_state_pct = 0
			SET @tax_resale = 0 
		END

		--Sales tax table has null when tax is not resale so lets make sure we get a
		IF (@tax_resale) IS NULL
			SET @tax_resale = 0

		--If @action = 'NEW' OR @action = 'SETUP' OR @action = 'COPY' 

		IF @bill_type_flag = 2  --Net
			BEGIN
				SET @taxapplyc = 0
				SET @taxapplyr = 0							
			END
		ELSE
			IF @bill_type_flag = 1  --Comm Only
				BEGIN
					SET @taxapplyln = 0
					SET @taxapplynd = 0
					SET @taxapplync = 0
					SET @taxapplyai = 0			
				END

		/* uf_get_rates_and_tax */
		
		/* PJH 04/07/17 - Added AND @@comm_pct_v > 0 	*/
		IF @comm_pct_v IS NOT NULL AND @comm_pct_v > 0
			SET @comm_pct = @comm_pct_v
		Else 
			SET @comm_pct = 15
		
		IF @net_gross = 1 --Gross
			SET @rebate_pct = @rebate_pct_p
		ELSE
			SET @rebate_pct = 0

		SET @markup_pct = COALESCE(@comm_pct_p,0) /* from Product */
		SET @comm_pct = COALESCE(@comm_pct,0)
		SET @rebate_pct = COALESCE(@rebate_pct,0)
		SET @tax_state_pct = COALESCE(@tax_state_pct,0)
		SET @tax_county_pct = COALESCE(@tax_county_pct,0)
		SET @tax_city_pct = COALESCE(@tax_city_pct,0)
		
		/* uf_calc_comm_mu - Get reciprocal PCT */
		IF @net_gross = 1 --Gross
			SELECT @markup_pct=MARKUP_PCT FROM advtf_med_calc_comm_mu( @net_gross, @comm_pct) --GROSS
		ELSE
			SELECT @comm_pct=COMM_PCT FROM advtf_med_calc_comm_mu( @net_gross, @markup_pct) --NET		
			
		INSERT INTO @med_defaults
		VALUES (@tax_city_pct ,
			@tax_county_pct ,
			@tax_state_pct ,
			@tax_resale ,
			@taxapplyc ,
			@taxapplyln ,
			@taxapplynd ,
			@taxapplync ,
			@taxapplyr ,
			@taxapplyai ,
			@comm_pct , 
			@markup_pct ,
			@rebate_pct ,
			@tax_code )

RETURN
END

GO


