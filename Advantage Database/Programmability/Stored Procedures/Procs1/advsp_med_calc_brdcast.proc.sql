IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_med_calc_brdcast]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_med_calc_brdcast]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_med_calc_brdcast] (
	@quantity int OUTPUT,
	@total_spots int OUTPUT,
	@bill_type_flag smallint OUTPUT,
	@tax_city_pct decimal (14, 6) OUTPUT,
	@tax_county_pct decimal (14, 6) OUTPUT,
	@tax_state_pct decimal (14, 6) OUTPUT,
	@comm_pct decimal (14, 6) OUTPUT,
	@markup_pct decimal (14, 6) OUTPUT,
	@rebate_pct decimal (14, 6) OUTPUT,
	@discount_pct decimal (14, 6) OUTPUT,
	@rebate_amt_override smallint OUTPUT,
	@rebate_pct_override smallint OUTPUT,
	@markup_pct_override smallint OUTPUT,
	@comm_pct_override smallint OUTPUT,
	@ext_net_amt_override decimal(14,2) OUTPUT,
	@comm_pct_or decimal (14, 6) OUTPUT,
	@markup_pct_or decimal (14, 6) OUTPUT,
	@rebate_pct_or decimal (14, 6) OUTPUT,
	@rebate_amt_or decimal (14, 2) OUTPUT,
	@net_rate decimal (16, 4) OUTPUT,
	@gross_rate decimal (16, 4) OUTPUT,
	@netcharge decimal (14, 2) OUTPUT,
	@addl_charge decimal (14, 2) OUTPUT,
	@net_gross smallint OUTPUT,
	@temp_net_gross char(1) OUTPUT,
	@cost_rate decimal (16, 4) OUTPUT,
	@g_charge decimal(14,2) OUTPUT,
	@n_charge decimal(14,2) OUTPUT,
	@ext_gross_amt decimal (15, 2) OUTPUT,
	@rate decimal (16, 4) OUTPUT,
	@comm_amt decimal (14, 2) OUTPUT,
	@ext_net_amt decimal (15, 2) OUTPUT,
	@rebate_amt decimal (14, 2) OUTPUT,
	@discount_amt decimal (14, 2) OUTPUT,
	@state_tax decimal(14,4) OUTPUT,
	@county_tax decimal(14,4) OUTPUT,
	@city_tax decimal(14,4) OUTPUT,
	@ven_tax decimal(14,4) OUTPUT,
	@taxapplyc smallint OUTPUT,
	@taxapplyln smallint OUTPUT,
	@taxapplynd smallint OUTPUT,
	@taxapplync smallint OUTPUT,
	@taxapplyr smallint OUTPUT,
	@taxapplyai smallint OUTPUT,
	@state_rnd decimal(14,2) OUTPUT,
	@county_rnd decimal(14,2) OUTPUT,
	@city_rnd decimal(14,2) OUTPUT,
	@ven_rnd decimal(14,2) OUTPUT,
	@tax_resale smallint OUTPUT,
	@state_ac decimal(14,4) OUTPUT,
	@county_ac decimal(14,4) OUTPUT,
	@city_ac decimal(14,4) OUTPUT,
	@addl_charge_taxes decimal(14,4) OUTPUT,
	@resale_tax_amt decimal (14, 4) OUTPUT,
	@sales_tax_amt decimal (14, 4) OUTPUT,
	@bill_amt decimal (14, 4) OUTPUT,
	@billing_amt decimal (14, 2) OUTPUT,
	@line_total decimal (14, 2) OUTPUT,
	@state_amt decimal (14, 2) OUTPUT,
	@county_amt decimal (14, 2) OUTPUT,
	@city_amt decimal (14, 2) OUTPUT,
	@non_resale_amt decimal (14, 2) OUTPUT,
	@error_msg_w varchar(200) OUTPUT,
	@override_non_resale_amt decimal (14, 2) = NULL,  -- if NULL, ignore, otherwise set to value
	@strata_net_calc bit = 0
)

AS

/* PJH 01/30/19 - Change how to calc net rate */

BEGIN

	DECLARE @tmp_pct decimal(14,6)
	
	SET @quantity = @total_spots
	SET @quantity = COALESCE(@quantity, 0)	
	/* PJH 04/05/18 - Changed from IF @quantity <= 0 */  --@@@@@@@@@@@@@@@@@@@@@
	--IF @quantity <= 0
	--	SET @quantity = 1
	IF @quantity < 0
		SET @quantity = 0	
					
	IF COALESCE(@bill_type_flag, 0) = 0 
		BEGIN
			SET @error_msg_w = 'Invalid Bill Type flag...'
			GOTO GETOUT
		END	
				
	--SELECT @tax_city_pct=@tax_city_pct/100, @tax_county_pct=@tax_county_pct/100, @tax_state_pct=@tax_state_pct/100
	--SELECT @comm_pct=@comm_pct/100, @markup_pct=@markup_pct/100, @rebate_pct=@rebate_pct/100, @discount_pct=@discount_pct/100
			
	--SELECT @tax_city_pct 'TAX_CITY_PCT', @tax_county_pct 'TAX_COUNTY_PCT', @tax_state_pct 'TAX_STATE_PCT', @tax_resale 'TAX_RESALE',
	--			@taxapplyc 'TAXAPPLYC', @taxapplyln 'TAXAPPLYLN', @taxapplynd 'TAXAPPLYND', @taxapplync 'TAXAPPLYNC', @taxapplyr 'TAXAPPLYR', @taxapplyai 'TAXAPPLYAI',  /* DEBUG */	
	--			@comm_pct 'COMM_PCT', @markup_pct 'MARKUP_PCT', @rebate_pct 'REBATE_PCT', @tax_code 'TAX_CODE'	
			
	--SET @flat_discount_amt = ABS(@flat_discount_amt) * -1
			
	--SET @flat_netcharge = COALESCE(@flat_netcharge, 0)
	--SET @flat_addl_charge = COALESCE(@flat_addl_charge, 0)
	--SET @flat_discount_amt = COALESCE(@flat_discount_amt, 0)
			
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

	/* 
	SELECT * FROM advtf_med_calc_comm_mu( 1, 15) --GROSS
	SELECT * FROM advtf_med_calc_comm_mu( 0, 17.647) --NET
	*/			
			
	SET @net_rate = COALESCE(@net_rate, 0)
	SET @gross_rate = COALESCE(@gross_rate, 0)
	SET @netcharge = COALESCE(@netcharge, 0)
	SET @addl_charge = COALESCE(@addl_charge, 0)

	--SELECT '3' '-', @gross_rate '@gross_rate', @net_rate '@net_rate', @net_gross '@net_gross', @quantity '@quantity', @ext_net_amt '@ext_net_amt', @ext_gross_amt '@ext_gross_amt',
	--				@flat_net '@flat_net', @flat_gross '@flat_gross'

	/* PJH 01/30/19 - Net rate calculated below */
	IF	@net_gross = 1 BEGIN  --Gross
		SET @temp_net_gross = 'G'
	END
	ELSE BEGIN
		SET @temp_net_gross = 'N'
	END		
	
	--IF	@net_gross = 1 BEGIN  --Gross
	--	SET @temp_net_gross = 'G'
	--	--calc net rate from gross
	--	SET @net_rate = @gross_rate - (@gross_rate * @comm_pct/100)
	--	SET @net_rate = ROUND( @net_rate, 4 )
	--END
	--ELSE BEGIN
	--	SET @temp_net_gross = 'N'
	--	--calc gross rate from net
	--	SET @gross_rate = @net_rate + (@net_rate * @markup_pct/100)
	--	SET @gross_rate = ROUND( @gross_rate, 4 )					
	--END		
			
	--IF	@net_gross = 1 BEGIN  --Gross
	--	SET @temp_net_gross = 'G'
	--	--calc net rate from gross
	--	SET @flat_net = @flat_gross - (@flat_gross * @comm_pct/100)
	--	SET @flat_net = ROUND( @flat_net, 4 )
	--END
	--ELSE BEGIN
	--	SET @temp_net_gross = 'N'
	--	--calc gross rate from net
	--	SET @flat_gross = @flat_net + (@flat_net * @markup_pct/100)
	--	SET @flat_gross = ROUND( @flat_gross, 4 )					
	--END			
				
	--SET @cost_rate = COALESCE(@cost_rate, 0)
	--SET @net_rate = COALESCE(@net_rate, 0)
	--SET @gross_rate = COALESCE(@gross_rate, 0)
	--SET @net_base_rate = COALESCE(@net_base_rate, 0)
	--SET @gross_base_rate = COALESCE(@gross_base_rate, 0)
	--SET @flat_net = COALESCE(@flat_net, 0)
	--SET @flat_gross = COALESCE(@flat_gross, 0)
			
	/* Rates start out equal to flat rates */
	--SET @net_rate = @flat_net 
	--SET @gross_rate = @flat_gross

	SET @g_charge = 0
	SET @n_charge = 0

	SET @g_charge = ROUND(@g_charge, 4)
	SET @n_charge = ROUND(@n_charge, 4)
			
	--SELECT @g_charge '@g_charge', @n_charge '@n_charge' /* DEBUG */
			
	--SET @netcharge = ROUND(@flat_netcharge * @quantity, 2) + @temp_nc_amt
	--SET @discount_amt = ROUND(@flat_discount_amt * @quantity, 2)
	--SET @addl_charge = ROUND(@flat_addl_charge * @quantity, 2) + @temp_ac_amt

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
			
	SET @quantity = COALESCE(@quantity, 1)		
		
	IF	@net_gross = 1 BEGIN  --Gross
		SET @ext_gross_amt = ROUND(@gross_rate * @quantity, 2)
		SET @rate = @gross_rate			
		
		/* PJH 01/30/19 - Change how to calc net rate */
		IF @strata_net_calc = 1 BEGIN
			SET @tmp_pct = 100 - @comm_pct
			SET @net_rate = ROUND(@gross_rate * @tmp_pct/100, 4)
		END
		ELSE BEGIN
			SET @net_rate = @gross_rate - ROUND(@gross_rate * @comm_pct/100, 4)
		END
											
		/* PJH 01/30/19 - Change how to calc net amt - (i.e. instead of 15 x Gross = Comm */	
		IF @strata_net_calc = 1 BEGIN
			--calc comm_amt from gross_amt & comm_pct	
			SET @ext_net_amt = ROUND(@ext_gross_amt * @tmp_pct/100, 2)	
			SET @comm_amt = @ext_gross_amt - @ext_net_amt
		END
		ELSE BEGIN
			--calc comm_amt from gross_amt & comm_pct
			SET @comm_amt = ROUND(@comm_pct/100 * @ext_gross_amt, 2)
			SET @ext_net_amt = @ext_gross_amt - @comm_amt			
		END
	END
	ELSE BEGIN	--Net
		SET @ext_net_amt = ROUND(@net_rate * @quantity, 2) --
		SET @rate = @net_rate
		SET @gross_rate = @net_rate + ROUND(@net_rate * @markup_pct/100, 4)
				
		--calc comm_amt from gross_amt & comm_pct
		--Per EC do not include discount (AP has been changed to reflect this)
		--@comm_amt = @mu_pct * (@ext_net_amt + @discount_amt)
		SET @comm_amt = ROUND(@markup_pct/100 * @ext_net_amt, 2) --
		SET @ext_gross_amt = @ext_net_amt + @comm_amt
	END	

	--SELECT @gross_rate '@gross_rate', @net_rate '@net_rate', @net_gross '@net_gross', @quantity '@quantity', @ext_net_amt '@ext_net_amt', @ext_gross_amt '@ext_gross_amt'
			
	--Gross - Use @gross_rate for rebate calc
	--Added 'IF @rebate_pct <> 0' to use override amt when imported
	IF	@net_gross = 1 BEGIN
		IF @rebate_pct <> 0 
			--for newspaper rebate should be based on gross amt which is not always the
			--same as gross rate because the quantity can be > 1
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
			
	--SELECT @ext_net_amt '@ext_net_amt', @comm_amt '@comm_amt', @rebate_amt '@rebate_amt'   /* DEBUG */	
			
	--SELECT @tax_state_pct '@tax_state_pct', @tax_county_pct '@tax_county_pct', @tax_city_pct '@tax_city_pct', @tax_resale '@tax_resale', @bill_type_flag '@bill_type_flag'   /* DEBUG */	
			
	--Calc tax amounts - round each intermediate value cause Sue does
	IF @taxapplyln = 1 BEGIN	-- + Line Net
		SET @state_rnd = ROUND( @tax_state_pct/100 * @ext_net_amt, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @ext_net_amt, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @ext_net_amt, 2 )
		SET @ven_rnd = @state_rnd + @county_rnd + @city_rnd
		IF @tax_resale = 1 BEGIN
			SET @state_tax = @state_tax + @state_rnd
			SET @county_tax = @county_tax  + @county_rnd
			SET @city_tax = @city_tax + @city_rnd
		END
		ELSE
			SET @ven_tax = @ven_tax + @ven_rnd
	END
	IF @taxapplynd = 1 BEGIN -- + Net Discount
		SET @state_rnd = ROUND( @tax_state_pct/100 * @discount_amt, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @discount_amt, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @discount_amt, 2 )
		SET @ven_rnd = @state_rnd +	 @county_rnd + @city_rnd
		IF @tax_resale = 1 BEGIN
			SET @state_tax = @state_tax + @state_rnd
			SET @county_tax = @county_tax  + @county_rnd
			SET @city_tax = @city_tax + @city_rnd
		END
		ELSE
			SET @ven_tax = @ven_tax + @ven_rnd
	END
	IF @taxapplync = 1 BEGIN -- + Net Charge
		SET @state_rnd = ROUND( @tax_state_pct/100 * @netcharge, 2 )
		SET @county_rnd = ROUND( @tax_county_pct/100 * @netcharge, 2 )
		SET @city_rnd = ROUND( @tax_city_pct/100 * @netcharge, 2 )
		SET @ven_rnd = @state_rnd +	 @county_rnd + @city_rnd
		IF @tax_resale = 1 BEGIN
			SET @state_tax = @state_tax + @state_rnd
			SET @county_tax = @county_tax  + @county_rnd
			SET @city_tax = @city_tax + @city_rnd
		END
		ELSE
			SET @ven_tax = @ven_tax + @ven_rnd
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
		SELECT @bill_type_flag 'GROSS'
		SET @bill_amt = ( @sales_tax_amt + @addl_charge_taxes + @ext_net_amt + @netcharge + @discount_amt + @addl_charge + @comm_amt + @rebate_amt )
		END
	ELSE BEGIN
		SET @error_msg_w = 'Missing bill type flag.'
		GOTO GETOUT
	END
			
	--SELECT @bill_type_flag '@bill_type_flag', @net_gross '@net_gross', @sales_tax_amt '@sales_tax_amt', @addl_charge_taxes '@addl_charge_taxes', 
	--@ext_net_amt '@ext_net_amt', @netcharge '@netcharge', @discount_amt '@discount_amt', @addl_charge '@addl_charge', @comm_amt '@comm_amt', @rebate_amt '@rebate_amt'  /* DEBUG */	

	SET @billing_amt = @bill_amt
			
	--Don't include @addl_charge or it's taxes - it is added to commission during billing
	--Net + Comm (if gross order) + Discount + NetChrg +
	SET @line_total = ( @ext_net_amt + @discount_amt + @netcharge + @ven_tax )

	IF	@net_gross = 1 BEGIN  --Gross
		SET @line_total = @line_total + @comm_amt 
	END
			
	SET @line_total = COALESCE(@line_total, 0)
			
	--SELECT @billing_amt '@billing_amt', @line_total '@line_total', @ext_net_amt '@ext_net_amt', @discount_amt '@discount_amt', @netcharge '@netcharge', @ven_tax '@ven_tax', /* DEBUG */
	--			@sales_tax_amt '@sales_tax_amt', @addl_charge_taxes '@addl_charge_taxes', @addl_charge '@addl_charge', @comm_amt '@comm_amt', @rebate_amt '@rebate_amt'			

	--Add these into the totals for taxes
	SET @state_tax = @state_tax + @state_ac
	SET @county_tax = @county_tax  + @county_ac
	SET @city_tax = @city_tax + @city_ac

	SET @non_resale_amt = @ven_tax
	--@state_tax 
	SET @state_amt = @state_tax
	SET @county_amt = @county_tax
	SET @city_amt = @city_tax
			
	--SELECT @state_amt '@state_tax', @county_amt '@county_tax', @city_amt '@city_tax', @non_resale_amt '@ven_tax'	 /* DEBUG */	
			
	SET @non_resale_amt= COALESCE(@non_resale_amt, 0)
	SET @state_amt= COALESCE(@state_amt, 0)
	SET @county_amt= COALESCE(@county_amt, 0)
	SET @city_amt= COALESCE(@city_amt, 0)	
			
	SET @rate= COALESCE(@rate, 0)
	SET @ext_gross_amt = COALESCE(@ext_gross_amt, 0)
	SET @discount_amt = COALESCE(@discount_amt, 0)
	SET @netcharge = COALESCE(@netcharge, 0)
	SET @addl_charge = COALESCE(@addl_charge, 0)
	--SET @flat_discount_amt = COALESCE(@flat_discount_amt, 0)
	--SET @flat_addl_charge = COALESCE(@flat_addl_charge, 0)
	--SET @flat_netcharge = COALESCE(@flat_netcharge, 0)
	SET @net_rate = COALESCE(@net_rate, 0)
	SET @gross_rate = COALESCE(@gross_rate, 0)
	--SET @flat_net = COALESCE(@flat_net, 0)
	--SET @flat_gross = COALESCE(@flat_gross, 0)

	/* RESET QUANTITY TO 1 - was set to TOTAL_SPOTS above */
	IF @quantity > 0 SET @quantity = 1

	SET @cost_rate = @rate
	
	GETOUT:

	RETURN

END
GO

GRANT EXECUTE ON [advsp_med_calc_brdcast] TO PUBLIC AS dbo
GO