/****** Object:  StoredProcedure [dbo].[advsp_billing_inv_tax]    Script Date: 02/04/2014 10:02:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_billing_inv_tax]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_billing_inv_tax]
GO

CREATE PROCEDURE [dbo].[advsp_billing_inv_tax] @billing_user_in varchar(100), @ret_val integer OUTPUT
AS

-- *********************************************************************************************************************************************
-- BJL 04/22/2013 - Created
-- BJL 04/23/2013 - Modified to operate on W_AR_FUNCTION instead of #AR_SUMMARY	as part of move to call from advsp_bcc_populate_ar_function
-- BJL 04/25/2013 - Added capability for amounts to be reclaculated without going back to hierarchy (after splits are modified)
-- BJL 05/10/2013 - Always update INV_TAX_FLAG to 1
-- BJL 06/21/2013 - Allow nonresale tax codes (for resale calculation purposes)
-- BJL 08/08/2013 - Fix WHERE clause to exclude income recognition
-- BJL 08/12/2013 - Added code to bypass tax calculations for rows where AB_SALE offsets all other amount columns
-- BJL 11/19/2013 - Nonresale tax split from cost
-- BJL 11/22/2013 - Removed nonresale amount as a condition for clearing columns to eliminate confusion between resale and vendor tax
-- PJH 02/04/2014 - ( @ab_sale_amt = 0.00 ) - Always get billing rates if INV_TAX_FLAG
-- *********************************************************************************************************************************************

-- *********************************************************************************************************************************************
--	TO DO
-- *********************************************************************************************************************************************

SET ANSI_WARNINGS OFF
SET NOCOUNT ON

DECLARE @fnc_code varchar(6), @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6) 
DECLARE @sc_code varchar(6), @fnc_type varchar(1), @job_number integer, @job_component_nbr smallint, @tax_resale smallint
DECLARE @tax_code varchar(4), @tax_level smallint, @tax_comm smallint, @tax_comm_only smallint, @tax_comm_flags_level smallint
DECLARE @state_pct decimal(9,4), @county_pct decimal(9,4), @city_pct decimal(9,4), @ab_sale_amt decimal(18,2)
DECLARE @coop_master_seq tinyint, @inv_tax_flag bit, @row_ct integer, @ar_inv_seq smallint 

SET @ret_val = 0
SET @coop_master_seq = 99				

IF ( @ret_val = 0 )
BEGIN

	DECLARE inv_tax_cursor CURSOR FOR
		 SELECT AR_INV_SEQ, FNC_CODE, CL_CODE, DIV_CODE, PRD_CODE, SC_CODE, FNC_TYPE, JOB_NUMBER, JOB_COMPONENT_NBR, INV_TAX_FLAG,
				TAX_CODE, TAX_STATE_PCT, TAX_COUNTY_PCT, TAX_CITY_PCT, TAX_COMM, TAX_COMM_ONLY, COALESCE( AB_SALE_AMT, 0.00 ) 
		   FROM dbo.W_AR_FUNCTION 
		  WHERE ( FNC_TYPE IN ( 'E','I','V' ))
		  --AND ( FNC_TYPE IS NOT NULL )
		    AND ( BILLING_USER = @billing_user_in )
		    -- BJL 05/13/2013
		    AND ( SUMMARY_FLAG = 0 )
		FOR UPDATE OF INV_TAX_FLAG, TAX_CODE, STATE_TAX_AMT, CNTY_TAX_AMT, CITY_TAX_AMT, 
					  TAX_STATE_PCT, TAX_COUNTY_PCT, TAX_CITY_PCT, TAX_COMM, TAX_COMM_ONLY;

	OPEN inv_tax_cursor;

	FETCH NEXT FROM inv_tax_cursor INTO @ar_inv_seq, @fnc_code, @cl_code, @div_code, @prd_code, @sc_code, @fnc_type, @job_number, @job_component_nbr, 
		@inv_tax_flag, @tax_code, @state_pct, @county_pct, @city_pct, @tax_comm, @tax_comm_only, @ab_sale_amt ;

	WHILE ( @@FETCH_STATUS = 0 )
	BEGIN

		SET @inv_tax_flag = COALESCE( @inv_tax_flag, 0 )
		
		IF ( @inv_tax_flag = 0 )
		BEGIN

			SET @tax_code = NULL
			SET @tax_level = NULL
			SET @tax_comm = NULL
			SET @tax_comm_only = NULL
			SET @tax_comm_flags_level = NULL
			SET @state_pct = NULL
			SET @county_pct = NULL
			SET @city_pct = NULL
			
			-- BJL 08/13/2013
			IF ( 0 = 0 )  --PJH 02/04/2014 - ( @ab_sale_amt = 0.00 ) - Always get billing rates if INV_TAX_FLAG
			BEGIN
				   SELECT @tax_code = gbr.TAX_CODE, 
						  @tax_level = gbr.TAX_LEVEL, 
						  @tax_comm = gbr.TAX_COMM, 
						  @tax_comm_only = gbr.TAX_COMM_ONLY, 
						  @tax_comm_flags_level = gbr.TAX_COMM_FLAGS_LEVEL, 
						  @tax_resale = tax.TAX_RESALE,
						  @state_pct = tax.TAX_STATE_PERCENT, 
						  @county_pct = tax.TAX_COUNTY_PERCENT, 
						  @city_pct = tax.TAX_CITY_PERCENT
					 FROM dbo.advtf_get_billing_rate( NULL, NULL, @fnc_code, @cl_code, @div_code, @prd_code, @sc_code, @fnc_type, @job_number, @job_component_nbr, NULL ) gbr
			   INNER JOIN dbo.SALES_TAX tax 
					   ON ( gbr.TAX_CODE = tax.TAX_CODE );
			   
			   IF ( @@ROWCOUNT = 1 ) SET @inv_tax_flag = 1 ELSE SET @inv_tax_flag = 0
			END				
			ELSE
				SET @inv_tax_flag = 0

		END

		IF ( @inv_tax_flag = 0 OR @ar_inv_seq = @coop_master_seq )
		BEGIN
			-- W_AR_FUNCTION.INV_TAX_FLAG set means tax has been "considered", not necessarily "applied"
			UPDATE dbo.W_AR_FUNCTION
			   SET INV_TAX_FLAG = 1,
				   -- BJL 11/22/2013 
				   TAX_CODE = NULL,
				   STATE_TAX_AMT = 0.00, 
				   CNTY_TAX_AMT = 0.00, 
				   CITY_TAX_AMT = 0.00,
				   TAX_STATE_PCT = NULL,				   
				   TAX_COUNTY_PCT = NULL,
				   TAX_CITY_PCT = NULL,
				   TAX_COMM = NULL,
				   TAX_COMM_ONLY = NULL
			 WHERE CURRENT OF inv_tax_cursor;
			 
		END
		ELSE
		BEGIN
			IF ( @tax_resale = 1 )
			BEGIN
				UPDATE dbo.W_AR_FUNCTION
				   SET INV_TAX_FLAG = 1, 
					   TAX_CODE = @tax_code,
					   STATE_TAX_AMT =	CASE 
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 0 ) THEN [dbo].[advfn_calc_prod_resale]( 
												COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + COALESCE( AB_SALE_AMT, 0.00 ) + 
												COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 ) + COALESCE( AB_COST_AMT, 0.00 ), 
												COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @state_pct )
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 1 ) THEN [dbo].[advfn_calc_prod_resale]( 
												0.00, COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @state_pct )
											ELSE [dbo].[advfn_calc_prod_resale]( COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 ) + 
												COALESCE( AB_COST_AMT, 0.00 ), 0.00, @state_pct )
										END,
					   CNTY_TAX_AMT =   CASE 
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 0 ) THEN [dbo].[advfn_calc_prod_resale]( 
												COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + COALESCE( AB_SALE_AMT, 0.00 ) + 
												COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 ) + COALESCE( AB_COST_AMT, 0.00 ), 
												COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @county_pct )
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 1 ) THEN [dbo].[advfn_calc_prod_resale]( 
												0.00, COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @county_pct )
											ELSE [dbo].[advfn_calc_prod_resale]( COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 ) + 
												COALESCE( AB_COST_AMT, 0.00 ), 0.00, @county_pct )
										END,
					   CITY_TAX_AMT =   CASE 
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 0 ) THEN [dbo].[advfn_calc_prod_resale]( 
												COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + COALESCE( AB_SALE_AMT, 0.00 ) + 
												COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 ) + COALESCE( AB_COST_AMT, 0.00 ), 
												COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @city_pct )
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 1 ) THEN [dbo].[advfn_calc_prod_resale](  
												0.00, COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @city_pct )
											ELSE [dbo].[advfn_calc_prod_resale]( COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 ) + 
												COALESCE( AB_COST_AMT, 0.00 ), 0.00, @city_pct )
										END,
					   TAX_STATE_PCT = @state_pct,
					   TAX_COUNTY_PCT = @county_pct,
					   TAX_CITY_PCT = @city_pct,
					   TAX_COMM = @tax_comm,
					   TAX_COMM_ONLY = @tax_comm_only
				 WHERE CURRENT OF inv_tax_cursor;
			END
			ELSE
			BEGIN
				UPDATE dbo.W_AR_FUNCTION
				   SET INV_TAX_FLAG = 1, 
					   TAX_CODE = @tax_code,
					   STATE_TAX_AMT =	CASE 
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 0 ) THEN [dbo].[advfn_calc_prod_resale]( 
												COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ), 
												COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @state_pct )
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 1 ) THEN [dbo].[advfn_calc_prod_resale]( 
												0.00, COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @state_pct )
											ELSE [dbo].[advfn_calc_prod_resale]( COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ), 0.00, @state_pct )
										END,
					   CNTY_TAX_AMT =   CASE 
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 0 ) THEN [dbo].[advfn_calc_prod_resale]( 
												COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ), 
												COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @county_pct )
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 1 ) THEN [dbo].[advfn_calc_prod_resale]( 
												0.00, COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @county_pct )
											ELSE [dbo].[advfn_calc_prod_resale]( COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ), 0.00, @county_pct )
										END,
					   CITY_TAX_AMT =   CASE 
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 0 ) THEN [dbo].[advfn_calc_prod_resale]( 
												COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ), 
												COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @city_pct )
											WHEN ( COALESCE( @tax_comm, 0 ) = 1 AND COALESCE( @tax_comm_only, 0 ) = 1 ) THEN [dbo].[advfn_calc_prod_resale](  
												0.00, COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ), @city_pct )
											ELSE [dbo].[advfn_calc_prod_resale]( COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + 
												COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ), 0.00, @city_pct )
										END,
					   TAX_STATE_PCT = @state_pct,
					   TAX_COUNTY_PCT = @county_pct,
					   TAX_CITY_PCT = @city_pct,
					   TAX_COMM = @tax_comm,
					   TAX_COMM_ONLY = @tax_comm_only
				 WHERE CURRENT OF inv_tax_cursor;
			END
		END
							
		FETCH NEXT FROM inv_tax_cursor INTO @ar_inv_seq, @fnc_code, @cl_code, @div_code, @prd_code, @sc_code, @fnc_type, @job_number, @job_component_nbr, 
			@inv_tax_flag, @tax_code, @state_pct, @county_pct, @city_pct, @tax_comm, @tax_comm_only, @ab_sale_amt ;
		
	END

	CLOSE inv_tax_cursor;
	DEALLOCATE inv_tax_cursor;

	UPDATE waf
	   SET INV_TAX_FLAG = 1,
		   STATE_TAX_AMT = ( SELECT COALESCE( SUM( COALESCE( waf2.STATE_TAX_AMT, 0.00 )), 0.00 )
							   FROM dbo.W_AR_FUNCTION waf2
							  WHERE ( waf2.AR_INV_NBR = waf.AR_INV_NBR )
							    AND ( waf2.JOB_NUMBER = waf.JOB_NUMBER )
							    AND ( waf2.JOB_COMPONENT_NBR = waf.JOB_COMPONENT_NBR )
								AND ( waf2.FNC_CODE = waf.FNC_CODE )
								AND (( waf2.RECONCILE_ROW = waf.RECONCILE_ROW ) OR ( waf2.RECONCILE_ROW IS NULL AND waf.RECONCILE_ROW IS NULL )) 
								AND ( waf2.SUMMARY_FLAG = 0 )),
		   CNTY_TAX_AMT = (  SELECT COALESCE( SUM( COALESCE( waf2.CNTY_TAX_AMT, 0.00 )), 0.00 )
							   FROM dbo.W_AR_FUNCTION waf2
							  WHERE ( waf2.AR_INV_NBR = waf.AR_INV_NBR )
							    AND ( waf2.JOB_NUMBER = waf.JOB_NUMBER )
							    AND ( waf2.JOB_COMPONENT_NBR = waf.JOB_COMPONENT_NBR )
								AND ( waf2.FNC_CODE = waf.FNC_CODE )
								AND (( waf2.RECONCILE_ROW = waf.RECONCILE_ROW ) OR ( waf2.RECONCILE_ROW IS NULL AND waf.RECONCILE_ROW IS NULL )) 
								AND ( waf2.SUMMARY_FLAG = 0 )),
		   CITY_TAX_AMT = (  SELECT COALESCE( SUM( COALESCE( waf2.CITY_TAX_AMT, 0.00 )), 0.00 )
							   FROM dbo.W_AR_FUNCTION waf2
							  WHERE ( waf2.AR_INV_NBR = waf.AR_INV_NBR )
							    AND ( waf2.JOB_NUMBER = waf.JOB_NUMBER )
							    AND ( waf2.JOB_COMPONENT_NBR = waf.JOB_COMPONENT_NBR )
								AND ( waf2.FNC_CODE = waf.FNC_CODE )
								AND (( waf2.RECONCILE_ROW = waf.RECONCILE_ROW ) OR ( waf2.RECONCILE_ROW IS NULL AND waf.RECONCILE_ROW IS NULL )) 
								AND ( waf2.SUMMARY_FLAG = 0 ))
	  FROM dbo.W_AR_FUNCTION waf
	 WHERE ( SUMMARY_FLAG = 1 )
		 
END
GO

GRANT EXECUTE ON [advsp_billing_inv_tax] TO PUBLIC AS dbo
GO
