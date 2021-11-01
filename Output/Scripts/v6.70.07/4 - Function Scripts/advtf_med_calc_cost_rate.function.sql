/****** Object:  UserDefinedFunction [dbo].[advtf_advance_bill_by_job]    Script Date: 05/15/2015 16:07:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_calc_cost_rate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_calc_cost_rate]
GO

/****** Object:  UserDefinedFunction [dbo].[advtf_med_calc_cost_rate]    Script Date: 05/15/2015 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* 
SELECT * FROM INTERNET_HEADER WHERE ORDER_NBR > 700
SELECT TAX_CODE, BILL_TYPE_FLAG, * FROM INTERNET_HEADER WHERE TAX_CITY_PCT > 0 --ORDER_NBR > 700

SELECT * FROM SALES_TAX

SELECT * FROM NEWSPAPER_DETAIL WHERE ORDER_NBR = 712

SELECT * FROM advtf_med_calc_cost_rate (	
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
		@mu_pct, 
		@print_lines )

SELECT * FROM advtf_med_calc_cost_rate (	
		'NP', 
		1 , 
		'CPI', 
		40, 
		'STD',
		40, 
		47.0588,
		40, 
		47.0588,
		NULL, 
		NULL, 
		NULL, 
		15, 
		17.647, 
		132 )

RETURNS (COST_RATE, NET_RATE, GROSS_RATE, NET_BASE_RATE, GROSS_BASE_RATE, FLAT_NET, FLAT_GROSS)
		
*/

CREATE FUNCTION [dbo].advtf_med_calc_cost_rate (
		@order_type varchar(10), 
		@net_gross smallint, 
		@cost_type varchar (3),	
		@cost_rate decimal (16, 4),
		@rate_type varchar (3),
		@net_rate decimal (16, 4),
		@gross_rate decimal (16, 4),
		@flat_net decimal (16, 4),
		@flat_gross decimal (16, 4),		
		@proj_impressions int, 
		@guaranteed_impress int, 
		@act_impressions int,
		@comm_pct decimal (7, 3),
		@mu_pct decimal (7, 3),
		@print_lines decimal (11,2),
		@override_rates bit )

	RETURNS @cost_rates TABLE ( 
		COST_RATE DECIMAL (16, 4) NOT NULL,
		NET_RATE DECIMAL (16, 4) NOT NULL,
		GROSS_RATE DECIMAL (16, 4) NOT NULL,
		NET_BASE_RATE DECIMAL (16, 4) NOT NULL,
		GROSS_BASE_RATE DECIMAL (16, 4) NOT NULL,		
		FLAT_NET DECIMAL (16, 4) NOT NULL,
		FLAT_GROSS DECIMAL (16, 4) NOT NULL
		)
AS
BEGIN
	DECLARE 	@tax_city_pct decimal (7, 3) ,
		@tax_county_pct decimal (7, 3) ,
		@tax_state_pct decimal (7, 3) ,
		@tax_resale smallint 
			
	DECLARE @dec_n_base_rate decimal (16, 4), @dec_g_base_rate decimal (16, 4)	
	DECLARE @dec_n_flat_rate decimal (16, 4), @dec_g_flat_rate decimal (16, 4)	
	DECLARE @s_cost_type varchar (3), @s_rate_type varchar (3), @dec_cost_rate decimal (16, 4)
	DECLARE @cpm int
	DECLARE @dec_rate decimal (20, 4), @dec_qty decimal (20, 4), @dec_temp decimal (20, 4), @decimal_places smallint

	IF @override_rates = 1
		SET @decimal_places = 2
	ELSE
		SET @decimal_places = 4

	SET @dec_cost_rate = @cost_rate
	SET @s_cost_type = @cost_type
	SET @s_rate_type = @rate_type

	/* Original  g_flat_rate OR n_flat_rate */
	IF @net_gross = 1   --Gross
		SET @dec_rate = @flat_gross 
	ELSE   --Net
		SET @dec_rate = @flat_net 		

	IF @order_type = 'IN' BEGIN
		IF @s_cost_type = 'NA' BEGIN
			SET @dec_qty = 1
			IF @net_gross = 1   --Gross
				SET @dec_cost_rate = @gross_rate
			ELSE
				SET @dec_cost_rate = @net_rate
			IF @dec_cost_rate IS NULL 
				SET @dec_cost_rate = @cost_rate
		END 
		ELSE BEGIN
			SET @dec_cost_rate = @cost_rate
			--PJH 09-26/07 - added
			IF @act_impressions > 0 
				SET @dec_qty = @act_impressions
			ELSE
				SET @dec_qty = @guaranteed_impress
		END	

		SET @cpm = 1
		IF (@dec_qty IS NULL) OR @dec_qty = 0 BEGIN
			SET @cpm = 0 --No CPM IF 0 impressions
			SET @dec_qty = 1	
		END		

		IF (@dec_cost_rate IS NULL) 
			SET @dec_cost_rate = 0

		IF (@dec_cost_rate IS NOT NULL) AND (@dec_qty IS NOT NULL) AND @dec_cost_rate <> 0 AND @dec_qty <> 0 BEGIN
			SET @dec_rate = @dec_cost_rate * @dec_qty
			IF @cost_type = 'CPM' 
				IF @cpm = 1  
					SET @dec_rate = @dec_rate/1000  --Cost per thousAND
			IF @net_gross = 1 BEGIN  --Gross
				SET @dec_g_base_rate = @dec_cost_rate
				SET @dec_temp = ROUND(@dec_cost_rate * (@comm_pct/100), @decimal_places)
				SET @dec_n_base_rate = @dec_g_base_rate - @dec_temp
			END 
			ELSE IF @net_gross = 0 BEGIN  --Net
				SET @dec_n_base_rate = @dec_cost_rate
				SET @dec_temp = ROUND(@dec_cost_rate * (@mu_pct/100), @decimal_places)
				SET @dec_g_base_rate = @dec_n_base_rate + @dec_temp
			END
		END	

		--SET @dec_n_base_rate = COALESCE(@dec_n_base_rate, 0)
		--SET @dec_g_base_rate = COALESCE(@dec_g_base_rate, 0)
		--SET @dec_cost_rate = COALESCE(@dec_cost_rate, 0)
		
		--SET @net_rate = COALESCE(@net_rate, 0)
		--SET @gross_rate = COALESCE(@gross_rate, 0)
		
	END ELSE IF @order_type = 'NP' BEGIN
		/* calculate a cost rate fOR newspaper when the  rate is CPM */

		SET @dec_qty = @print_lines
		IF (@dec_qty IS NULL) OR @dec_qty = 0 
			SET @dec_qty = 1

		SET @s_rate_type = @rate_type
		IF (@s_rate_type IS NULL OR @s_rate_type = '')  
			SET @s_rate_type = 'STD'
		IF @net_gross = 1   --Gross
			SET @dec_cost_rate = @flat_gross	--user supplied
		ELSE
			SET @dec_cost_rate = @flat_net	--user supplied

		IF (@dec_cost_rate IS NULL) 
			SET @dec_cost_rate = 0

		IF (@dec_cost_rate IS NOT NULL) AND (@dec_qty IS NOT NULL) AND @dec_cost_rate <> 0 AND @dec_qty <> 0 BEGIN
			SET @dec_rate = @dec_cost_rate * @dec_qty
			IF @rate_type = 'CPM' 
				SET @dec_rate = @dec_rate/1000  --Cost per thousAND
			
			IF @net_gross = 1 BEGIN  --Gross
				SET @dec_g_base_rate = @dec_cost_rate
				SET @dec_temp = ROUND(@dec_cost_rate * (@comm_pct/100), @decimal_places)
				SET @dec_n_base_rate = @dec_g_base_rate - @dec_temp
			END ELSE IF @net_gross = 0 BEGIN  --Net
				SET @dec_n_base_rate = @dec_cost_rate
				SET @dec_temp = ROUND(@dec_cost_rate * (@mu_pct/100), @decimal_places)
				SET @dec_g_base_rate = @dec_n_base_rate + @dec_temp
			END
		END

		--SET @net_rate = COALESCE(@dec_n_base_rate, 0)
		--SET @gross_rate = COALESCE(@dec_g_base_rate, 0)
		--SET @dec_cost_rate = COALESCE(@dec_cost_rate, 0)		
		
		--SET @dec_n_base_rate = COALESCE(@dec_n_base_rate, 0)
		--SET @dec_g_base_rate = COALESCE(@dec_g_base_rate, 0)
		--SET @dec_cost_rate = COALESCE(@dec_cost_rate, 0)
		
		--SET @dec_n_flat_rate = @dec_n_base_rate
		--SET @dec_g_flat_rate = @dec_g_base_rate				
		
		--SET @net_rate = COALESCE(@net_rate, 0)
		--SET @gross_rate = COALESCE(@gross_rate, 0)		
				
	END

	SET @net_rate = COALESCE(@dec_n_base_rate, 0)
	SET @gross_rate = COALESCE(@dec_g_base_rate, 0)
	SET @dec_cost_rate = COALESCE(@dec_cost_rate, 0)		
		
	SET @dec_n_base_rate = COALESCE(@dec_n_base_rate, 0)
	SET @dec_g_base_rate = COALESCE(@dec_g_base_rate, 0)
	SET @dec_cost_rate = COALESCE(@dec_cost_rate, 0)
		
	SET @dec_n_flat_rate = @dec_n_base_rate
	SET @dec_g_flat_rate = @dec_g_base_rate				
		
	SET @net_rate = COALESCE(@net_rate, 0) 
	SET @gross_rate = COALESCE(@gross_rate, 0) 
	
	--PJH 01/14/16
	--PJH 05/22/20 - Add reciprical rate calc
	IF @net_gross = 1 BEGIN--Gross
		SET @gross_rate = COALESCE(@dec_rate, 0)  --@dec_rate
		SET @dec_temp = ROUND(@gross_rate * (@comm_pct/100), @decimal_places)
		SET @net_rate = @gross_rate - @dec_temp
	END
	ELSE BEGIN
		SET @net_rate = COALESCE(@dec_rate, 0) --@dec_rate
		SET @dec_temp = ROUND(@net_rate * (@mu_pct/100), @decimal_places)
		SET @gross_rate = @net_rate + @dec_temp
	END

	/*
	Internet only uses (@cost_rate, @net_base_rate, @gross_base_rate)
	*/
		
	INSERT INTO @cost_rates VALUES ( 
			@dec_cost_rate,
			@net_rate,
			@gross_rate,
			@dec_n_base_rate, 
			@dec_g_base_rate,
			@dec_n_flat_rate,
			@dec_g_flat_rate)
	
	RETURN
	
END
GO

