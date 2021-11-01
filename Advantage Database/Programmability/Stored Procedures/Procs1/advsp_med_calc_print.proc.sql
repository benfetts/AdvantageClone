CREATE PROCEDURE [dbo].[advsp_med_calc_print] (
		@order_type varchar(10) OUTPUT,
		@units varchar(2) OUTPUT,
		@start_date smalldatetime OUTPUT,
		@end_date smalldatetime OUTPUT,
		@tax_city_pct decimal (14, 6) OUTPUT,
		@tax_county_pct decimal (14, 6) OUTPUT,
		@tax_state_pct decimal (14, 6) OUTPUT,
		@tax_resale smallint OUTPUT,
		@taxapplyc smallint OUTPUT,
		@taxapplyln smallint OUTPUT,
		@taxapplynd smallint OUTPUT,
		@taxapplync smallint OUTPUT,
		@taxapplyr smallint OUTPUT,
		@taxapplyai smallint OUTPUT,
		@comm_pct decimal (14, 6) OUTPUT,
		@markup_pct decimal (14, 6) OUTPUT,
		@rebate_pct decimal (14, 6) OUTPUT,
		@discount_pct decimal (14, 6) OUTPUT,
		@net_gross smallint OUTPUT, 
		@cost_type varchar (3) OUTPUT,	
		@cost_rate decimal (16, 4) OUTPUT,
		@rate_type varchar (3) OUTPUT,
		@rate decimal (16, 4) OUTPUT,
		@net_rate decimal (16, 4) OUTPUT,
		@gross_rate decimal (16, 4) OUTPUT,
		@ext_net_amt decimal (15, 2) OUTPUT,
		@ext_gross_amt decimal (15, 2) OUTPUT,
		@comm_amt decimal (14, 2) OUTPUT,
		@rebate_amt decimal (14, 2) OUTPUT,
		@discount_amt decimal (14, 2) OUTPUT,
		@discount_desc varchar (30) OUTPUT,
		@state_amt decimal (14, 2) OUTPUT,
		@county_amt decimal (14, 2) OUTPUT,
		@city_amt decimal (14, 2) OUTPUT,
		@non_resale_amt decimal (14, 2) OUTPUT,
		@netcharge decimal (14, 2) OUTPUT,
		@ncdesc varchar (30) OUTPUT,
		@addl_charge decimal (14, 2) OUTPUT,
		@addl_charge_desc varchar (30) OUTPUT,
		@rebate_amt_override smallint OUTPUT,
		@rebate_pct_override smallint OUTPUT,
		@markup_pct_override smallint OUTPUT,
		@comm_pct_override smallint OUTPUT,
		@ext_net_amt_override decimal(14,2) OUTPUT,
		@comm_pct_or decimal (14, 6) OUTPUT,
		@markup_pct_or decimal (14, 6) OUTPUT,
		@rebate_pct_or decimal (14, 6) OUTPUT,
		@rebate_amt_or decimal (14, 2) OUTPUT,
		@temp_cc_amt decimal(14,2) OUTPUT,  --NEWSPAPER_OTH_CHGS
		@temp_nc_amt decimal(14,2) OUTPUT,  --NEWSPAPER_OTH_CHGS
		@temp_ac_amt decimal(14,2) OUTPUT,  --NEWSPAPER_OTH_CHGS
		@quantity DECIMAL (16, 4) OUTPUT,
		@print_columns decimal (6, 2) OUTPUT,
		@print_inches decimal (6, 2) OUTPUT,
		@print_lines decimal (11, 2) OUTPUT,
		@np_circulation int OUTPUT,
		@print_quantity decimal (14, 3) OUTPUT,
		@state_tax decimal(14,4) OUTPUT,
		@county_tax decimal(14,4) OUTPUT,
		@city_tax decimal(14,4) OUTPUT,
		@billing_amt decimal (14, 2) OUTPUT,
		@line_total decimal (14, 2) OUTPUT,
		@column_line_qty decimal (14, 3) OUTPUT,
		@cpm int OUTPUT,
		@overage_pct decimal(14,4) OUTPUT,
		@bill_type_flag smallint OUTPUT,
		@temp_net_gross char(1) OUTPUT,
		@g_charge decimal(14,2) OUTPUT,
		@n_charge decimal(14,2) OUTPUT,
		@d_temp decimal(14,2) OUTPUT,
		@proj_impressions int OUTPUT,
		@guaranteed_impress int OUTPUT,
		@target_audience varchar (60) OUTPUT,
		@creative_size varchar (60) OUTPUT,
		@placement_1 varchar (256) OUTPUT,
		@placement_2 varchar (160) OUTPUT,
		@act_impressions int OUTPUT,
		@prc_status smallint OUTPUT,
		@size varchar (30) OUTPUT,
		@edition_issue varchar (30) OUTPUT,
		@material varchar (60) OUTPUT,
		@section varchar (30) OUTPUT,
		@rate_card_id int OUTPUT,
		@rate_dtl_id smallint OUTPUT,
		@contract_qty decimal (14, 4) OUTPUT,
		@flat_net decimal (16, 4) OUTPUT,
		@flat_gross decimal (16, 4) OUTPUT,
		@prod_charge decimal (14, 3) OUTPUT,
		@prod_desc varchar (30) OUTPUT,
		@color_charge decimal (15, 4) OUTPUT,
		@color_desc varchar (30) OUTPUT,
		@flat_netcharge decimal (15, 2) OUTPUT,
		@flat_addl_charge decimal (15, 2) OUTPUT,
		@flat_discount_amt decimal (15, 2) OUTPUT,
		@bleed_pct decimal (14, 6) OUTPUT,
		@bleed_amt decimal (14, 2) OUTPUT,
		@position_pct decimal (14, 6) OUTPUT,
		@position_amt decimal (14, 2) OUTPUT,
		@premium_pct decimal (14, 6) OUTPUT,
		@premium_amt decimal (14, 2) OUTPUT,
		@net_base_rate decimal (16, 4) OUTPUT,
		@gross_base_rate decimal (16, 4) OUTPUT,
		@state_rnd decimal(14,2) OUTPUT,
		@county_rnd decimal(14,2) OUTPUT,
		@city_rnd decimal(14,2) OUTPUT,
		@ven_rnd decimal(14,2) OUTPUT,
		@state_ac decimal(14,4) OUTPUT,
		@county_ac decimal(14,4) OUTPUT,
		@city_ac decimal(14,4) OUTPUT,
		@ven_tax decimal(14,4) OUTPUT,
		@addl_charge_taxes decimal(14,4) OUTPUT,
		@resale_tax_amt decimal (14, 4) OUTPUT,
		@sales_tax_amt decimal (14, 4) OUTPUT,
		@bill_amt decimal (14, 4) OUTPUT,
		@error_msg_w varchar(200) OUTPUT,
		@override_non_resale_amt decimal (14, 2) = NULL,  -- if NULL, ignore, otherwise set to value
		@override_rates smallint = 0,
		@strata_net_calc smallint = 0
	)

AS

/* PJH 01/30/19 - Change how to calc net rate */

BEGIN
--SELECT @override_rates '@override_rates MIKE!'
	DECLARE @decimal_places smallint
	DECLARE @tmp_pct decimal(14,6)
	DECLARE @print_lines_alt decimal(11, 4)

	SET @print_lines_alt = 0

	IF @error_msg_w = 'STRATA'
		SET @strata_net_calc = 1

	IF @override_rates = 1
		SET @decimal_places = 2
	ELSE
		SET @decimal_places = 4

	IF @order_type = 'NP'	BEGIN

		IF @units = 'D'
			SET @quantity = DATEDIFF(day, @start_date, @end_date) + 1
		ELSE
			SET @quantity = 1
					
		SET @print_columns = COALESCE(@print_columns, 0)
		SET @print_inches = COALESCE(@print_inches, 0)
		SET @print_lines = COALESCE(@print_lines, 0)
		SET @quantity = COALESCE(@quantity, 0)
		
		IF @print_lines <= 0 BEGIN
			SET @print_lines_alt = @print_columns * @print_inches
			SET @print_lines = @print_columns * @print_inches
		END

		SET @cpm = 1	
		IF @print_lines > 0 BEGIN

			IF @print_lines_alt = 0 BEGIN
			
				SET @print_lines_alt = @print_lines

			END

			SET @column_line_qty = @print_lines_alt

		END ELSE BEGIN
			SET @column_line_qty = 1
			SET @print_lines = 0
			SET @cpm = 0
		END

		SET @contract_qty = dbo.advfn_med_calc_contract_qty(@quantity, @print_columns, @print_inches, @print_lines_alt, @order_type, @rate_type)
				
		--SELECT @contract_qty '@contract_qty', @comm_pct '@comm_pct', @markup_pct '@markup_pct', @print_lines '@print_lines', @print_quantity '@print_quantity' /* DEBUG */	
				
		IF @rate_type = 'CPM' BEGIN
			IF COALESCE(@overage_pct, -1) > 0 BEGIN
				SET @print_quantity = @print_lines + (ROUND(@print_lines * (@overage_pct / 100), 0))
				--SELECT @print_lines '@print_lines', @overage_pct / 100 '@overage_pct / 100', @print_quantity '@print_quantity'
			END
			ELSE
				SET @print_quantity = @print_lines
		END
				
		--SELECT @contract_qty '@contract_qty', @comm_pct '@comm_pct', @markup_pct '@markup_pct', @print_lines '@print_lines', @print_quantity '@print_quantity' /* DEBUG */	
				
	END
	ELSE IF @order_type = 'MA'
		SET @contract_qty = 1		
		
	--ib_rate_override = FALSE
	SET @quantity = COALESCE(@quantity, 0)			
	IF @quantity <= 0
		SET @quantity = 1
				
	SET @contract_qty = COALESCE(@contract_qty, 0)			
	IF @contract_qty <= 0
		SET @contract_qty = 1				

	SET @column_line_qty = COALESCE(@column_line_qty, 0)			
	IF @column_line_qty <= 0
		SET @column_line_qty = 1						
		
	IF COALESCE(@bill_type_flag, 0) = 0 
		BEGIN
			SET @error_msg_w = 'Invalid Bill Type flag...'
			GOTO GETOUT
		END	
				
	--SELECT @tax_city_pct=@tax_city_pct/100, @tax_county_pct=@tax_county_pct/100, @tax_state_pct=@tax_state_pct/100
	--SELECT @comm_pct=@comm_pct/100, @markup_pct=@markup_pct/100, @rebate_pct=@rebate_pct/100, @discount_pct=@discount_pct/100
			
	SET @flat_discount_amt = ABS(@flat_discount_amt) * -1
			
	SET @flat_netcharge = COALESCE(@flat_netcharge, 0)
	SET @flat_addl_charge = COALESCE(@flat_addl_charge, 0)
	SET @flat_discount_amt = COALESCE(@flat_discount_amt, 0)
			
	SET @tax_city_pct = COALESCE(@tax_city_pct, 0)
	SET @tax_county_pct = COALESCE(@tax_county_pct, 0)
	SET @tax_state_pct = COALESCE(@tax_state_pct, 0)
	SET @comm_pct = COALESCE(@comm_pct, 0)
	SET @markup_pct = COALESCE(@markup_pct, 0)
	SET @rebate_pct = COALESCE(@rebate_pct, 0)
	SET @discount_pct = COALESCE(@discount_pct, 0)		
			
	/** Check Overrides **/
	IF @comm_pct_override = 1 			
		SET @comm_pct = COALESCE(@comm_pct_or, 0)
	IF @markup_pct_override = 1 	
		SET @markup_pct = COALESCE(@markup_pct_or, 0)
	IF @rebate_pct_override = 1 	
		SET @rebate_pct = COALESCE(@rebate_pct_or, 0)
			
	SET @net_rate = COALESCE(@net_rate, 0)
	SET @gross_rate = COALESCE(@gross_rate, 0)
	SET @netcharge = COALESCE(@netcharge, 0)
	SET @addl_charge = COALESCE(@addl_charge, 0)
			
	IF @order_type IN ('NP', 'IN') BEGIN
		IF @net_gross = 1
			SET @temp_net_gross = 'G'
		ELSE
			SET @temp_net_gross = 'N'
			
		--uf_calc_cost_rate
		IF @order_type IN ('NP')
			SELECT @cost_rate=COST_RATE, 
					@net_rate=NET_RATE, 
					@gross_rate=GROSS_RATE, 
					--@net_base_rate=NET_BASE_RATE, 
					--@gross_base_rate=GROSS_BASE_RATE, 
					@flat_net=FLAT_NET, 
					@flat_gross=FLAT_GROSS 
			FROM advtf_med_calc_cost_rate (	
					@order_type, 
					@net_gross , 
					@cost_type, 
					@cost_rate , 
					@rate_type,
					@net_rate, 
					@gross_rate,
					@flat_net, 
					@flat_gross, 
					@proj_impressions, 
					@guaranteed_impress, 
					@act_impressions, 
					@comm_pct, 
					@markup_pct, 
					@print_lines_alt,
					@override_rates )
		IF @order_type IN ('IN')
			SELECT @cost_rate=COST_RATE, 
					@net_base_rate=NET_BASE_RATE, 
					@gross_base_rate=GROSS_BASE_RATE,
					@net_rate=NET_RATE, 
					@gross_rate=GROSS_RATE,
					@flat_net=NET_RATE, 
					@flat_gross=GROSS_RATE
			FROM advtf_med_calc_cost_rate (	
					@order_type, 
					@net_gross , 
					@cost_type, 
					@cost_rate , 
					@rate_type,
					@net_rate, 
					@gross_rate,
					@flat_net, 
					@flat_gross, 
					@proj_impressions, 
					@guaranteed_impress, 
					@act_impressions, 
					@comm_pct, 
					@markup_pct, 
					@print_lines,
					@override_rates )
	END
	ELSE BEGIN

		IF @order_type IN ('OD') BEGIN
			SELECT @flat_net '@flat_net', @flat_gross '@flat_gross', @net_rate '@net_rate', @net_base_rate '@net_base_rate', @gross_rate '@gross_rate', @gross_base_rate '@gross_base_rate'
			SET @flat_net = @net_rate
			SET @flat_gross = @gross_rate
		END

		IF	@net_gross = 1 BEGIN  --Gross
			SET @temp_net_gross = 'G'
			--calc net rate from gross
			SET @flat_net = @flat_gross - (@flat_gross * @comm_pct/100)
			SET @flat_net = ROUND( @flat_net, @decimal_places )
		END
		ELSE BEGIN
			SET @temp_net_gross = 'N'
			--calc gross rate from net
			SET @flat_gross = @flat_net + (@flat_net * @markup_pct/100)
			SET @flat_gross = ROUND( @flat_gross, @decimal_places )					
		END			
	END
	
	SET @flat_net = COALESCE(@flat_net, 0)
	SET @flat_gross = COALESCE(@flat_gross, 0)
	SET @cost_rate = COALESCE(@cost_rate, 0)
	SET @net_rate = COALESCE(@net_rate, 0)
	SET @gross_rate = COALESCE(@gross_rate, 0)
	SET @net_base_rate = COALESCE(@net_base_rate, 0)
	SET @gross_base_rate = COALESCE(@gross_base_rate, 0)
			
	/* Rates start out equal to flat rates */
	SET @net_rate = @flat_net 
	SET @gross_rate = @flat_gross

	SET @g_charge = 0
	SET @n_charge = 0
			
	SET @prod_charge = ROUND( @prod_charge, 2 )
	SET @color_charge = ROUND( @color_charge, 2 ) + @temp_cc_amt
	
	IF @color_charge > 0
		IF @temp_net_gross = 'N'
			SET @n_charge = @n_charge + @color_charge
		ELSE
			SET @g_charge = @g_charge + @color_charge
					
	----IF AP Reconciliation use current from AP
	--IF ib_reconcile BEGIN
	--	IF is_table = 'MAGAZINE' BEGIN
	--		@temp = adw_dtl.Object.BLEED_AMT
	--		IF @temp <> 0 AND Not IsNull(@temp) BEGIN
	--			IF @s_temp = 'N' BEGIN
	--				@n_charge = @n_charge + @temp
	--			ELSEIF @s_temp = 'G' BEGIN
	--				@g_charge = @g_charge + @temp
	--			END
	--		END
				
	--		@temp = adw_dtl.Object.POSITION_AMT 
	--		IF @temp <> 0 AND Not IsNull(@temp) BEGIN
	--			IF @s_temp = 'N' BEGIN
	--				@n_charge = @n_charge + @temp
	--			ELSEIF @s_temp = 'G' BEGIN
	--				@g_charge = @g_charge + @temp
	--			END
	--		END
						
	--		@temp = adw_dtl.Object.PREMIUM_AMT 
	--		IF @temp <> 0 AND Not IsNull(@temp) BEGIN
	--			IF @s_temp = 'N' BEGIN
	--				@n_charge = @n_charge + @temp
	--			ELSEIF @s_temp = 'G' BEGIN
	--				@g_charge = @g_charge + @temp
	--			END
	--		END
	--	END			
			
	/* ELSE Not Reconcile */		
	
	IF @override_rates = 1 BEGIN
		IF @order_type = 'MA' BEGIN
			SET @d_temp = @bleed_pct / 100
			IF @d_temp <> 0 AND (@d_temp IS NOT NULL) BEGIN
				IF @temp_net_gross = 'N' BEGIN /* Net */
					SET @d_temp = @bleed_amt
					SET @n_charge = @n_charge + @d_temp
				END
				ELSE BEGIN /* Gross */
					SET @d_temp = @bleed_amt
					SET @g_charge = @g_charge + @d_temp
				END
			END
			ELSE
				SET @d_temp = 0

			SET @bleed_amt = @d_temp
							
			SET @d_temp = @position_pct / 100
			IF @d_temp <> 0 AND (@d_temp IS NOT NULL) BEGIN
				IF @temp_net_gross = 'N' BEGIN
					SET @d_temp = @position_amt
					SET @n_charge = @n_charge + @d_temp
				END
				ELSE BEGIN
					SET @d_temp = @position_amt
					SET @g_charge = @g_charge + @d_temp
				END
			END
			ELSE
				SET @d_temp = 0		

			SET @position_amt = @d_temp
					
			SET @d_temp = @premium_pct / 100
			IF @d_temp <> 0 AND (@d_temp IS NOT NULL) BEGIN
				IF @temp_net_gross = 'N' BEGIN
					SET @d_temp = @premium_amt
					SET @n_charge = @n_charge + @d_temp
				END
				ELSE BEGIN
					SET @d_temp = @premium_amt
					SET @g_charge = @g_charge + @d_temp
				END
			END
			ELSE
				SET @d_temp = 0		

			SET @premium_amt = @d_temp
		END			
	END ELSE BEGIN 
		IF @order_type = 'MA' BEGIN
			SET @d_temp = @bleed_pct / 100
			IF @d_temp <> 0 AND (@d_temp IS NOT NULL) BEGIN
				IF @temp_net_gross = 'N' BEGIN /* Net */
					SET @d_temp = ROUND(@flat_net * @d_temp, 2) 
					SET @n_charge = @n_charge + @d_temp
				END
				ELSE BEGIN /* Gross */
					SET @d_temp = ROUND(@flat_gross * @d_temp, 2) 
					SET @g_charge = @g_charge + @d_temp
				END
			END
			ELSE
				SET @d_temp = 0

			SET @bleed_amt = @d_temp
							
			SET @d_temp = @position_pct / 100
			IF @d_temp <> 0 AND (@d_temp IS NOT NULL) BEGIN
				IF @temp_net_gross = 'N' BEGIN
					SET @d_temp = ROUND(@flat_net * @d_temp, 2) 
					SET @n_charge = @n_charge + @d_temp
				END
				ELSE BEGIN
					SET @d_temp = ROUND(@flat_gross * @d_temp, 2) 
					SET @g_charge = @g_charge + @d_temp
				END
			END
			ELSE
				SET @d_temp = 0		

			SET @position_amt = @d_temp
					
			SET @d_temp = @premium_pct / 100
			IF @d_temp <> 0 AND (@d_temp IS NOT NULL) BEGIN
				IF @temp_net_gross = 'N' BEGIN
					SET @d_temp = ROUND(@flat_net * @d_temp, 2) 
					SET @n_charge = @n_charge + @d_temp
				END
				ELSE BEGIN
					SET @d_temp = ROUND(@flat_gross * @d_temp, 2) 
					SET @g_charge = @g_charge + @d_temp
				END
			END
			ELSE
				SET @d_temp = 0		

			SET @premium_amt = @d_temp
		END			
	END

	SET @g_charge = ROUND(@g_charge, @decimal_places)
	SET @n_charge = ROUND(@n_charge, @decimal_places)
			
	IF @order_type = 'IN' OR @order_type = 'OD' BEGIN
		--Make amt entered a negative amt
		SET @discount_amt = ABS(@discount_amt) * (-1)	
	END
	ELSE BEGIN
		SET @netcharge = ROUND(@flat_netcharge * @quantity, 2) + @temp_nc_amt
		SET @discount_amt = ROUND(@flat_discount_amt * @quantity, 2)
		SET @addl_charge = ROUND(@flat_addl_charge * @quantity, 2) + @temp_ac_amt
	END

	--SELECT @discount_amt '@discount_amt', @flat_discount_amt '@flat_discount_amt' /* DEBUG */

	/*  Flat Charge per line */
	--IF ib_addl_amt_override AND NOT IsNull(@addl_amt_override) THEN
	--	@addl_charge = @addl_amt_override
	--	--adw_dtl.SetItem( al_row, 'addl_charge', @addl_charge )
	--END IF
	--IF ib_nc_amt_override AND NOT IsNull(@nc_amt_override) THEN
	--	@netcharge = @nc_amt_override
	--	--adw_dtl.SetItem( al_row, 'netcharge',  @netcharge )
	--END IF
			
	/*  Use AP amt here to prevent rounding variations (table only stores 2 dec for flat amts) */
	--IF ib_reconcile BEGIN --Leave as is
	--@netcharge = 
	--@discount_amt = 
	--ELSE --Calculated
	--	adw_dtl.SetItem( al_row, 'netcharge', @netcharge )
	--	adw_dtl.SetItem( al_row, 'discount_amt', @discount_amt )	
	--END			
		
	IF	@net_gross = 1 BEGIN  --Gross
		/* calc gross_amt from qty & rate (@contract_qty accounts for qty)*/
		SET @ext_gross_amt = ROUND(@flat_gross * @contract_qty, 2)
		--PJH 02/26/06 calc before additional rate charges
		SET @rate = @gross_rate * @column_line_qty	

		/* PJH 01/30/19 - Change how to calc net amt - (i.e. instead of 15 x Gross = Comm */
		SET @tmp_pct = 100 - @comm_pct
		
		/* Add other charges */				
		SET @prod_charge = COALESCE(@prod_charge, 0)
				
		SET @ext_gross_amt = @ext_gross_amt + @prod_charge
				
		--New rate includes other charges
		SET @g_charge = COALESCE(@g_charge, 0)
		SET @gross_rate = @flat_gross + @g_charge
		--Calc net rate, 4 decimals
		
		/* PJH 01/30/19 - Change how to calc net rate */
		IF @strata_net_calc = 1
			SET @net_rate = ROUND(@gross_rate * @tmp_pct/100, @decimal_places)			
		ELSE
			SET @net_rate = @gross_rate - ROUND(@gross_rate * @comm_pct/100, @decimal_places)
				
		SET @quantity = COALESCE(@quantity, 1)
											
		--PJH 07/18/07
		--IF ib_reconcile BEGIN
		--	--Use amounts from AP
		--	SET @ext_gross_amt = ROUND(@rate, 2)  + ROUND(@g_charge * @quantity, 2) --rate charges --
		--ELSE
			--Add charges x qty
			SET @ext_gross_amt = @ext_gross_amt + ROUND(@g_charge * @quantity, 2) --rate charges --
		--END

		/* PJH 01/30/19 - Change how to calc net amt - (i.e. instead of 15 x Gross = Comm */	
		IF @strata_net_calc = 1 BEGIN
			--calc comm_amt from gross_amt & net_amt	
			SET @ext_net_amt = ROUND(@ext_gross_amt * @tmp_pct/100, 2)	
			SET @comm_amt = @ext_gross_amt - @ext_net_amt	
		END 
		ELSE BEGIN
			--normal calc
			--calc comm_amt from gross_amt & comm_pct
			SET @comm_amt = ROUND(@comm_pct/100 * @ext_gross_amt, 2) 
			SET @ext_net_amt = @ext_gross_amt - @comm_amt	
		END		
	END
	ELSE BEGIN	--Net
		--SELECT 'CALC EXT NET/GROSS', @ext_gross_amt '@ext_gross_amt', @quantity '@quantity', @prod_charge '@prod_charge', @contract_qty '@contract_qty'  /* DEBUG */	
		--calc gross_amt from qty & rate (@contract_qty accounts for qty)
		SET @contract_qty = COALESCE(@contract_qty, 1)
		SET @ext_net_amt = ROUND(@flat_net * @contract_qty, 2) --
		--PJH 02/26/06 calc before additional rate charges
		SET @rate = @net_rate * @column_line_qty
				
		SET @prod_charge = COALESCE(@prod_charge, 0)
				
		SET @ext_net_amt = @ext_net_amt + @prod_charge
				
		--New rate includes other charges
		SET @n_charge = COALESCE(@n_charge, 0)
		SET @net_rate = @flat_net + @n_charge
		--Calc net rate, 4 decimals
		SET @gross_rate = @net_rate + ROUND(@net_rate * @markup_pct/100, @decimal_places)
				
		SET @quantity = COALESCE(@quantity, 1)
				
		--IF ib_reconcile BEGIN
		--	--Use amounts from AP
		--	SET @ext_net_amt = ROUND(@reconcile_rate, 2)   + ROUND (@n_charge * @quantity, 2) --rate charges --
		--ELSE	
			--Add charges x qty
			SET @ext_net_amt = @ext_net_amt + ROUND (@n_charge * @quantity, 2) --rate charges --
		--END

		--calc comm_amt from gross_amt & comm_pct
		--Per EC do not include discount (AP has been changed to reflect this)
		--@comm_amt = @mu_pct * (@ext_net_amt + @discount_amt)
		SET @comm_amt = ROUND(@markup_pct/100 * @ext_net_amt, 2) --
		SET @ext_gross_amt = @ext_net_amt + @comm_amt
	END	

	IF @order_type = 'NP' BEGIN
		IF @rate_type = 'CPM' 
			IF @cpm = 1
				SET @rate = @rate / 1000

		SET @ext_net_amt_override = @rate
	END
			
	--Gross - Use @gross_rate for rebate calc
	--Added 'IF @rebate_pct <> 0' to use override amt when imported
	IF	@net_gross = 1 BEGIN
		IF @rebate_pct <> 0 
			--for newspaper rebate should be based on gross amt which is not always the
			--same as gross rate because the quantity can be >1
			SET @rebate_amt = ROUND(@rebate_pct/100 * @ext_gross_amt * (-1), 2) --
		ELSE BEGIN
			--IF ib_data_entry_edit  = 1 /* User edit vs Imported */
				SET @rebate_amt = 0
			--ELSE BEGIN
			--	SET @rebate_amt = @rebate_amt
			--	IF @rebate_amt > 0 
			--		SET @rebate_amt = @rebate_amt *-1
			--END
		END
				
		/** Check Override **/
		IF @rebate_amt_override = 1 			
			SET @rebate_amt = COALESCE(@rebate_amt_or, 0)				
				
	END
	ELSE
		SET @rebate_amt = 0  --clear when net


	/* From AP for Reconcile - PJH 11/21/14 */
	--SET @reconcile_net_amt = COALESCE(@reconcile_net_amt, 0)
	--SET @reconcile_COLOR_NET_AMT = COALESCE(@reconcile_COLOR_NET_AMT, 0)
	--SET @reconcile_BLEED_NET_AMT = COALESCE(@reconcile_BLEED_NET_AMT, 0)
	--SET @reconcile_POSITION_NET_AMT = COALESCE(@reconcile_POSITION_NET_AMT, 0)
	--SET @reconcile_PREMIUM_NET_AMT = COALESCE(@reconcile_PREMIUM_NET_AMT, 0)
	--SET @reconcile_comm_amt = COALESCE(@reconcile_comm_amt, 0)

	/* From AP for Reconcile - PJH 11/21/14 */
	--IF ib_reconcile THEN
	--	@ext_net_amt = @reconcile_net_amt	
	--	@ext_net_amt = @ext_net_amt + @reconcile_COLOR_NET_AMT
	--	@ext_net_amt = @ext_net_amt + @reconcile_BLEED_NET_AMT
	--	@ext_net_amt = @ext_net_amt + @reconcile_POSITION_NET_AMT	
	--	@ext_net_amt = @ext_net_amt + @reconcile_PREMIUM_NET_AMT
	--	@ext_gross_amt = @reconcile_net_amt + @reconcile_comm_amt
	--	@comm_amt = @reconcile_comm_amt
	--	--@netcharge = @reconcile_netchg
	--	--@discount_amt = @reconcile_disc
	--	--@ven_tax = @reconcile_vntax
	--END IF
			
	SET @ext_gross_amt = COALESCE(@ext_gross_amt, 0)
	SET @ext_net_amt = COALESCE(@ext_net_amt, 0)
	SET @comm_amt = COALESCE(@comm_amt, 0)
	SET @discount_amt = COALESCE(@discount_amt, 0)
	SET @rebate_amt = COALESCE(@rebate_amt, 0)
	SET @netcharge = COALESCE(@netcharge, 0)
	SET @addl_charge = COALESCE(@addl_charge, 0)
	SET @tax_state_pct = COALESCE(@tax_state_pct, 0)
	SET @tax_county_pct = COALESCE(@tax_county_pct, 0)
	SET @tax_city_pct = COALESCE(@tax_city_pct, 0)
	SET @g_charge = COALESCE(@g_charge, 0)
	SET @n_charge = COALESCE(@n_charge, 0)
			
	SET @state_tax = COALESCE(@state_tax, 0)
	SET @county_tax = COALESCE(@county_tax, 0)
	SET @city_tax = COALESCE(@city_tax, 0)
	SET @ven_tax = COALESCE(@ven_tax, 0)
			
	--Calc tax amounts - round each intermediate value cause Sue does
	IF @taxapplyln = 1 BEGIN	-- + Line Net
		SET @state_rnd = ROUND( @tax_state_pct/100 * @ext_net_amt, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @ext_net_amt, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @ext_net_amt, 2 )
		IF @tax_resale = 1 BEGIN
			SET @state_tax = @state_tax + @state_rnd
			SET @county_tax = @county_tax  + @county_rnd
			SET @city_tax = @city_tax + @city_rnd
		END
		ELSE
			SET @ven_tax = @ven_tax + @state_rnd + @county_rnd + @city_rnd
	END
	IF @taxapplynd = 1 BEGIN -- + Net Discount
		SET @state_rnd = ROUND( @tax_state_pct/100 * @discount_amt, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @discount_amt, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @discount_amt, 2 )
		IF @tax_resale = 1 BEGIN
			SET @state_tax = @state_tax + @state_rnd
			SET @county_tax = @county_tax  + @county_rnd
			SET @city_tax = @city_tax + @city_rnd
		END
		ELSE
			SET @ven_tax = @ven_tax + @state_rnd + @county_rnd + @city_rnd
	END
	IF @taxapplync = 1 BEGIN -- + Net Charge
		SET @state_rnd = ROUND( @tax_state_pct/100 * @netcharge, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @netcharge, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @netcharge, 2 )
		IF @tax_resale = 1 BEGIN
			SET @state_tax = @state_tax + @state_rnd
			SET @county_tax = @county_tax  + @county_rnd
			SET @city_tax = @city_tax + @city_rnd
		END
		ELSE
			SET @ven_tax = @ven_tax + @state_rnd + @county_rnd + @city_rnd
	END
	IF @taxapplyc = 1 BEGIN -- + Comm
		SET @state_rnd = ROUND( @tax_state_pct/100 * @comm_amt, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @comm_amt, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @comm_amt, 2 )
		SET @state_tax = @state_tax + @state_rnd
		SET @county_tax = @county_tax  + @county_rnd
		SET @city_tax = @city_tax + @city_rnd
	END
	IF @taxapplyr = 1 BEGIN	-- + Rebate
		SET @state_rnd = ROUND( @tax_state_pct/100 * @rebate_amt, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @rebate_amt, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @rebate_amt, 2 )
		SET @state_tax = @state_tax + @state_rnd
		SET @county_tax = @county_tax  + @county_rnd
		SET @city_tax = @city_tax + @city_rnd
	END
			
	--SELECT @state_tax '@state_tax', @county_tax '@county_tax', @city_tax '@city_tax', @ven_tax '@ven_tax'  /* DEBUG */	

	SET @addl_charge_taxes = 0
	IF @taxapplyai = 1 BEGIN	-- + Addl Charge
		SET @state_ac = ROUND( @tax_state_pct/100 * @addl_charge, 2 )
		SET @county_ac = ROUND( @tax_county_pct/100 * @addl_charge, 2 )
		SET @city_ac = ROUND( @tax_city_pct/100 * @addl_charge, 2 )
		--PJH 06/16/04 - add these in later using @addl_charge_taxes
		--	@state_tax = @state_tax + @state_rnd
		--	@county_tax = @county_tax  + @county_rnd
		--	@city_tax = @city_tax + @city_rnd
	END

	IF @override_non_resale_amt IS NOT NULL
		SET @ven_tax = @override_non_resale_amt

	--Fix null amounts for later calc
				
	SET @ext_gross_amt = COALESCE(@ext_gross_amt, 0)
	SET @ext_net_amt = COALESCE(@ext_net_amt, 0)
	SET @comm_amt = COALESCE(@comm_amt, 0)
	SET @discount_amt = COALESCE(@discount_amt, 0)
	SET @rebate_amt = COALESCE(@rebate_amt, 0)
			
	SET @ven_tax = COALESCE(@ven_tax, 0)			
	SET @state_tax = COALESCE(@state_tax, 0)
	SET @tax_state_pct = COALESCE(@tax_state_pct, 0)
	SET @county_tax = COALESCE(@county_tax, 0)
	SET @state_ac = COALESCE(@state_ac, 0)
	SET @county_ac = COALESCE(@county_ac, 0)
	SET @city_ac = COALESCE(@city_ac, 0)

	--ROUND amounts for later calc
	SET @ext_gross_amt = ROUND( @ext_gross_amt, 2 )

	--PJH 04/16/08 - Force to AP Amts - move from above to make sure last thing
	--IF ib_reconcile BEGIN
	--	--Use amounts from AP
	--	IF is_units  = 'D'  BEGIN
	--		SET @reconcile_rate = @reconcile_rate / @quantity
	--	END
	--	SET @rate = ROUND(@reconcile_rate, 4)
	--	--Vendor Tax from AP
	--	SET @ven_tax = @reconcile_vntax
	--ELSE
		SET @ven_tax = ROUND( @ven_tax, 2 )
	--END

	SET @ext_net_amt = ROUND( @ext_net_amt, 2 )

	SET @comm_amt = ROUND( @comm_amt, 2 )
	SET @discount_amt = ROUND( @discount_amt, 2 )
	SET @rebate_amt = ROUND( @rebate_amt, 2 )

	SET @state_tax = ROUND( @state_tax, 2 )
	SET @county_tax = ROUND( @county_tax, 2 )
	SET @city_tax = ROUND( @city_tax, 2 )
	--Addl Chargs
	SET @state_ac = ROUND( @state_ac, 2 )
	SET @county_ac = ROUND( @county_ac, 2 )
	SET @city_ac = ROUND( @city_ac, 2 )
			
	SET @resale_tax_amt = ( @state_tax + @county_tax + @city_tax )
	SET @resale_tax_amt = COALESCE(@resale_tax_amt, 0)

	SET @sales_tax_amt = @resale_tax_amt + @ven_tax

	--PJH 06/16/04 - add these in to the totals later
	SET @addl_charge_taxes = (@state_ac + @county_ac + @city_ac)

	--PJH 03/03/04 - New
	IF	@bill_type_flag = 1  --Comm Only
		--PJH 09/27/04 - added @resale_tax_amt
		SET @bill_amt = ( @comm_amt + @rebate_amt ) + @resale_tax_amt
	ELSE IF @bill_type_flag = 2  --Net
		SET @bill_amt = ( @ext_net_amt + @netcharge + @sales_tax_amt + @addl_charge_taxes + @addl_charge + @discount_amt )
	ELSE IF @bill_type_flag = 3  --Gross
		BEGIN
			SET @bill_amt = ( @sales_tax_amt + @addl_charge_taxes + @ext_net_amt + @netcharge + @discount_amt + @addl_charge + @comm_amt + @rebate_amt )
		END
	ELSE BEGIN
		SET @error_msg_w = 'Missing bill type flag.'
		GOTO GETOUT
	END

	SET @billing_amt = @bill_amt
	
	--Don't include @addl_charge or it's taxes - it is added to commission during billing
	--Net + Comm (if gross order) + Discount + NetChrg +
	SET @line_total = ( @ext_net_amt + @discount_amt + @netcharge + @ven_tax )

	IF	@net_gross = 1 BEGIN  --Gross
		SET @line_total = @line_total + @comm_amt 
	END
	
	SET @line_total = COALESCE(@line_total, 0)
	
		--Add these into the totals for taxes
	SET @state_tax = @state_tax + @state_ac
	SET @county_tax = @county_tax  + @county_ac
	SET @city_tax = @city_tax + @city_ac


	SET @non_resale_amt = @ven_tax
	--@state_tax 
	SET @state_amt = @state_tax
	SET @county_amt = @county_tax
	SET @city_amt = @city_tax
	--@line_total 		
			
	SET @non_resale_amt= COALESCE(@non_resale_amt, 0)
	SET @state_amt= COALESCE(@state_amt, 0)
	SET @county_amt= COALESCE(@county_amt, 0)
	SET @city_amt= COALESCE(@city_amt, 0)	
			
	SET @rate= COALESCE(@rate, 0)
	SET @ext_gross_amt = COALESCE(@ext_gross_amt, 0)
	SET @discount_amt = COALESCE(@discount_amt, 0)
	SET @netcharge = COALESCE(@netcharge, 0)
	SET @addl_charge = COALESCE(@addl_charge, 0)
	SET @flat_discount_amt = COALESCE(@flat_discount_amt, 0)
	SET @flat_addl_charge = COALESCE(@flat_addl_charge, 0)
	SET @flat_netcharge = COALESCE(@flat_netcharge, 0)
	SET @prod_charge = COALESCE(@prod_charge, 0)
	SET @color_charge = COALESCE(@color_charge, 0)
	IF @order_type = 'MA' BEGIN
		SET @bleed_pct = COALESCE(@bleed_pct, 0)
		SET @bleed_amt = COALESCE(@bleed_amt, 0)
		SET @position_pct = COALESCE(@position_pct, 0)
		SET @position_amt = COALESCE(@position_amt, 0)
		SET @premium_pct = COALESCE(@premium_pct, 0)
		SET @premium_amt = COALESCE(@premium_amt, 0)
	END
	SET @net_rate = COALESCE(@net_rate, 0)
	SET @gross_rate = COALESCE(@gross_rate, 0)
	SET @flat_net = COALESCE(@flat_net, 0)
	SET @flat_gross = COALESCE(@flat_gross, 0)
	
	GETOUT:

	RETURN

END
GO