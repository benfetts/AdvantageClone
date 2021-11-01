/****** Object:  UserDefinedFunction [dbo].[advtf_med_set_dates]    Script Date: 05/15/2015 16:07:12 ******/
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_set_dates]')
			AND type IN (N'FN', N'IF', N'TF', N'FS', N'FT')
		)
	DROP FUNCTION [dbo].[advtf_med_set_dates]
GO

/****** Object:  UserDefinedFunction [dbo].[advtf_med_set_dates]    Script Date: 05/15/2015 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[advtf_med_set_dates] (
	@order_type VARCHAR(10)
	,@start_date SMALLDATETIME
	,@rate_card_id INT
	,@net_gross INT
	,@vn_code VARCHAR(6)
	,@action VARCHAR(10)
	,@units VARCHAR(2)
	)
RETURNS @med_dates TABLE (
	[START_DATE] SMALLDATETIME NULL
	,END_DATE SMALLDATETIME NULL
	,MATL_CLOSE_DATE SMALLDATETIME NULL
	,SPACE_CLOSE_DATE SMALLDATETIME NULL
	)
AS

--@order_type ('NP', 'MA', 'TV', etc.)
--@start_date (user entered)
--@rate_card_id (user selected)
--@net_gross (user selected at Header)
--@vn_code (user selected)
--@action (NEW. UPDATE, REVISE. CANCEL, RESTORE, etc.)
--@units
--SELECT * FROM advtf_med_set_dates('NP', '04-01-2015', NULL, 0, 'advoat', 'UPDATE')

--PJH 03/23/17 - (Material Close & Space Close) skip weekends and holidays when calculating using the deadline settings
--PJH 03/29/17 - "+ (1)" to account for the -1 call to fn_get_nth_workday
--PJH 04/24/17 - Added @matl_close_days_w & @space_close_days_w Not NULL or 0

BEGIN
	DECLARE @adv_bill BIT
		,@calc_method SMALLINT
	/*VENDOR DEFAULTS*/
	DECLARE @default SMALLINT
		,@use_tax_flags_v SMALLINT
		,@issues_v SMALLINT
	DECLARE @matl_close_days_v SMALLINT
		,@space_close_days_v SMALLINT
		,@net_gross_v SMALLINT
		,@sunday_circ_v INT
		,@daily_circ_v INT
	DECLARE @taxapplyln_v SMALLINT
		,@taxapplynd_v SMALLINT
		,@taxapplync_v SMALLINT
		,@taxapplyai_v SMALLINT
		,@taxapplyc_v SMALLINT
		,@taxapplyr_v SMALLINT
	DECLARE @sales_tax_v VARCHAR(6)
		,@office_code_v VARCHAR(6)
		,@mkt_code_v VARCHAR(10)
	DECLARE @cycle_v VARCHAR(3)
		,@def_rep1_v VARCHAR(4)
		,@def_rep2_v VARCHAR(4)
		,@def_size_v VARCHAR(10)
		,@category_v VARCHAR(1)
	DECLARE @comm_pct_v DECIMAL(7, 3)
		,@tax_code_v VARCHAR(4)
		,@units_v VARCHAR(2)
	DECLARE @overage_pct_v DECIMAL(7, 3)
		,@column_size_v DECIMAL(14, 4)
	DECLARE @matl_close_days_w SMALLINT
		,@space_close_days_w SMALLINT
	DECLARE @date_time_w SMALLDATETIME
	DECLARE @end_date SMALLDATETIME
		,@matl_close_date SMALLDATETIME
		,@space_close_date SMALLDATETIME
	DECLARE @temp_int INT
	DECLARE @matl_close_days SMALLINT
		,@space_close_days SMALLINT
	DECLARE @dec_rate_card_comm DECIMAL(7, 3)
	DECLARE @temp_dt SMALLDATETIME

	--If @order_type = 'NP' OR @order_type = 'MA' Then
	--	@rate_card_id = ???_DETAIL.RATE_CARD_ID
	--End If		
	IF (@rate_card_id IS NOT NULL)
	BEGIN
		SELECT @dec_rate_card_comm = COMM_PCT
			,@matl_close_days = MATL_CLOSE
			,@space_close_days = SPACE_CLOSE
		FROM RATE_CARD_HDR
		WHERE (RATE_CARD_HDR.RATE_CARD_ID = @rate_card_id)

		-- Null means ignore at this level, any other value will be used
		IF (@dec_rate_card_comm IS NULL)
		BEGIN
			IF @net_gross = 0 --Net
				SET @dec_rate_card_comm = NULL
		END
	END

	BEGIN
		SELECT @comm_pct_v = VN_COMM
			,@tax_code_v = DEF_SALES_TAX
			,@use_tax_flags_v = USE_TAX_FLAGS
			,@taxapplyc_v = TAXAPPLYC
			,@taxapplyln_v = TAXAPPLYLN
			,@taxapplynd_v = TAXAPPLYND
			,@taxapplync_v = TAXAPPLYNC
			,@taxapplyr_v = TAXAPPLYR
			,@taxapplyai_v = TAXAPPLYAI
			,@office_code_v = OFFICE_CODE
			,@units_v = COALESCE(@units, DEF_UNITS)
			,@daily_circ_v = DAILY_CIRC
			,@sunday_circ_v = SUNDAY_CIRC
			,@net_gross = DEF_NET_GROSS
			,@matl_close_days_v = MATL_CLOSE
			,@space_close_days_v = SPACE_CLOSE
			,@mkt_code_v = MARKET_CODE
			,@column_size_v = COLUMN_SIZE
			,@issues_v = ISSUES
			,@cycle_v = CYCLE
			,@def_rep1_v = DEF_VN_REP1
			,@def_rep2_v = DEF_VN_REP2
			,@def_size_v = DEF_SIZE
			,@overage_pct_v = OVERAGE_PCT
			,@category_v = VN_CATEGORY
		FROM dbo.VENDOR
		WHERE VN_CODE = @vn_code;
	END

	IF (@matl_close_days IS NULL)
		OR (@rate_card_id IS NULL) --DEBUG - verify later
		SET @matl_close_days_w = @matl_close_days_v
	ELSE
		SET @matl_close_days_w = @matl_close_days

	IF (@space_close_days IS NULL)
		OR (@rate_card_id IS NULL) --DEBUG - verify later
		SET @space_close_days_w = @space_close_days_v
	ELSE
		SET @space_close_days_w = @space_close_days

	SET @matl_close_days_w = COALESCE(@matl_close_days_w, 0)
	SET @space_close_days_w = COALESCE(@space_close_days_w, 0)

	--KN do not adj the dates when copying a media order and the dates have already been adjusted
	IF @action <> 'COPY'
	BEGIN
		IF (
				@order_type = 'MA'
				OR @order_type = 'NP'
				)
			AND @units_v <> 'D'
			SET @end_date = @start_date
		ELSE
		BEGIN
			SET @temp_int = DATEPART(WEEKDAY, @start_date)

			IF @units_v = 'W'
				SET @end_date = DATEADD(dd, - 1, DATEADD(dd, 7, @start_date))
			ELSE IF @units_v = 'M'
				--ld_new_date = Date(f_add_months(ld_orig_date, 1))
				--ld_end_date = RelativeDate(ld_new_date, -1)
				SET @end_date = DATEADD(dd, - 1, DATEADD(mm, 1, @start_date))
			ELSE IF @units_v = 'D'
				--ld_new_date = RelativeDate(ld_orig_date, 1)
				--ld_end_date = RelativeDate(ld_new_date, -1)
				SET @end_date = DATEADD(dd, - 1, DATEADD(dd, 1, @start_date))
			ELSE IF @units_v = 'BM'
			BEGIN
				--calendar month
				--ld_end_date = uf_get_end_date_bc( ld_orig_date )
				--get the end date of a broadcast month given a start date. The start date could be any date - it does not have to be
				--the start of a bc week. Broadcast weeks run from Monday through Sunday
				IF DATEPART(weekday, @start_date) = 1
					--Sunday so it is also the first end date
					SET @end_date = @start_date
				ELSE
					--go to the Sunday folling the start date to get the first end date
					--ld_end_date = RelativeDate(ad_start_date, (7 - li_dd) + 1)				
					SET @end_date = DATEADD(dd, (7 - @temp_int) + 1, @start_date)

				--we now have the first end date relative to the start date (the first Sunday following the start date OR the end date is the start date if the start date is on a Sunday)
				WHILE 1 = 1
				BEGIN
					--find the next Sunday
					SET @date_time_w = DATEADD(dd, 7, @end_date)

					IF DATEPART(mm, @date_time_w) = DATEPART(mm, @end_date)
						AND DATEPART(yy, @date_time_w) = DATEPART(yy, @end_date)
					BEGIN
						--still in the same broadcast month
						SET @end_date = @date_time_w

						CONTINUE
					END
					ELSE
						--the broadcast month changed because the Sunday of the temp end date is in a different month (Sunday determines the bc month)
						BREAK
				END
			END
			ELSE IF @units_v = 'CM'
			BEGIN
				--broadcast month
				--get the end of the broadcast month in relation to the start date
				IF DATEPART(mm, @start_date) = 12
				BEGIN
					SET @temp_int = DATEPART(yy, @start_date) + 1
					SET @date_time_w = CAST('1/1/' + CAST(@temp_int AS VARCHAR(4)) AS DATETIME)
				END
				ELSE
					--li_temp_mm = Month(ad_start_date) + 1
					--li_temp_yy = Year(ad_start_date)
					--ld_temp_end_date = Date(String(li_temp_mm) + "/1/" + String(li_temp_yy))
					SET @date_time_w = CAST(CAST(DATEPART(mm, @start_date) AS VARCHAR(2)) + '/1/' + CAST(DATEPART(yy, @start_date) AS VARCHAR(4)) AS DATETIME)

				SET @end_date = DATEADD(dd, - 1, @date_time_w)
			END
			ELSE IF @units_v = 'DB'
			BEGIN
				--	//daily by broadcast week
				IF DATEPART(mm, @start_date) = 1
					--		//Sunday so it is also the end of the broadcast week
					--		ld_end_date = ad_start_date
					SET @end_date = @start_date
				ELSE
					--		//go to the Sunday following the start date to get the first end date
					--		ld_end_date = RelativeDate(ad_start_date, (7 - @temp_int) + 1)
					SET @end_date = DATEADD(dd, (7 - @temp_int) + 1, @start_date)
			END
		END
	END

	IF (@start_date IS NOT NULL)
	BEGIN

		/* PJH 03/29/17 - "+ (1)" to account for the -1 call to fn_get_nth_workday */
		--SET @matl_close_date = DATEADD(dd, - (@matl_close_days_w) + (1) , @start_date)
		--SET @space_close_date = DATEADD(dd, - (@space_close_days_w) + (1), @start_date)

		/* PJH 03/23/17 - (Material Close & Space Close) skip weekends and holidays when calculating using the deadline settings */

		/* If holiday or weekday then find previous workday */
		/* PJH 04/24/17 - Added @matl_close_days_w & @space_close_days_w Not NULL or 0 */
		IF @matl_close_days_w IS NOT NULL AND @matl_close_days_w <> 0
			SET @matl_close_date = [dbo].[fn_get_nth_workday](@start_date, - @matl_close_days_w)
		ELSE
			SET @matl_close_date = @start_date

		/* If holiday or weekday then find previous workday */
		/* PJH 04/24/17 - Added @matl_close_days_w & @space_close_days_w Not NULL or 0 */
		IF @space_close_days_w IS NOT NULL AND @space_close_days_w <> 0
			SET @space_close_date = [dbo].[fn_get_nth_workday](@start_date, - @space_close_days_w)
		ELSE
			SET @space_close_date = @start_date

	END

	INSERT INTO @med_dates
	VALUES (
		@start_date
		,@end_date
		,@matl_close_date
		,@space_close_date
		)

	RETURN
END
GO


