IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_get_emp_rates]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_get_emp_rates]
GO

CREATE PROCEDURE [sp_get_emp_rates] 
@emp_code varchar(6), 
@emp_date smalldatetime, 
@fnc_code varchar(6), 
@cl_code varchar(6), 
@div_code varchar(6), 
@prd_code varchar(6), 
@job_nbr integer, 
@job_cmp_nbr smallint,
@billing_rate decimal(10,3) OUTPUT, 
@rate_from varchar(254) OUTPUT,	
@cost_rate decimal(9,2) OUTPUT, 
@tax smallint OUTPUT, 
@tax_code varchar(4) OUTPUT, 
@nobill smallint OUTPUT, 
@city_pct decimal(9,3) OUTPUT, 
@county_pct decimal(9,3) OUTPUT, 
@state_pct decimal(9,3) OUTPUT, 
@comm decimal(9,3) OUTPUT, 
@tax_comm smallint OUTPUT, 
@tax_comm_only smallint OUTPUT, 
@fee_time smallint OUTPUT
AS
/*=========== QUERY ===========*/
	SET NOCOUNT ON

	DECLARE 
	@return_value integer, 
	@rate_level smallint, 
	@fee_time_level smallint, 
	@comm_level smallint, 
	@comm_flag smallint, 
	@tax_level smallint, 
	@sc_code varchar(6), 
	@nobill_level smallint, 
	@tax_comm_flags_level smallint

	SELECT @sc_code =SC_CODE FROM JOB_LOG WHERE JOB_NUMBER = @job_nbr;

	EXECUTE sp_get_billing_rates 
				@emp_code = @emp_code, 
				@eff_date = @emp_date, 
				@fnc_code = @fnc_code,
				@cl_code = @cl_code, 
				@div_code = @div_code, 
				@prd_code = @prd_code, 
				@sc_code = @sc_code, 
				@fnc_type = 'E', 
				@job_number = @job_nbr, 
				@job_component_nbr = @job_cmp_nbr,
				@emp_title_id = NULL,
				@billing_rate = @billing_rate OUTPUT, 
				@rate_level =  @rate_level OUTPUT, 
				@tax_code = @tax_code OUTPUT, 
				@tax_level = @tax_level OUTPUT, 
				@nobill_flag = @nobill OUTPUT, 
				@nobill_level = @nobill_level OUTPUT, 
				@comm = @comm OUTPUT, 
				@comm_level = @comm_level OUTPUT, 
				@tax_comm = @tax_comm OUTPUT, 
				@tax_comm_only = @tax_comm_only OUTPUT, 
				@tax_comm_flags_level = @tax_comm_flags_level OUTPUT, 
				@fee_time_flag = @fee_time OUTPUT, 
				@fee_time_level = @fee_time_level OUTPUT;

	IF @rate_level IS NOT NULL
	BEGIN

		SELECT @rate_from = (
							 SELECT TOP 1 LEVEL_DESC 
							 FROM BILL_RATE_PREC 
							 WHERE PRECEDENCE = @rate_level AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
							 );


	END

	SELECT 
		@cost_rate = ISNULL(EMP_COST_RATE, 0) 
	FROM 
		EMPLOYEE WITH(NOLOCK)
	WHERE 
		EMP_CODE = @emp_code;

	IF @tax_code IS NOT NULL
	BEGIN

		SELECT @tax = 1;

		SELECT 
			@city_pct = TAX_CITY_PERCENT,
			@county_pct = TAX_COUNTY_PERCENT,
			@state_pct = TAX_STATE_PERCENT
		FROM 
			SALES_TAX WITH(NOLOCK)
		WHERE 
			TAX_CODE = @tax_code;

	END
	ELSE
	BEGIN

		SELECT @tax = 0;
		SELECT @county_pct = 0.00;
		SELECT @city_pct = 0.00;
		SELECT @state_pct = 0.00;

	END

end_tran:
/*=========== QUERY ===========*/

---- Uncomment for troubleshooting
-- Leaving this uncommented will mess up WV autosave and mobile
--SELECT @billing_rate AS BILLING_RATE, @rate_from AS RATE_FROM, @cost_rate AS COST_RATE, @tax AS TAXABLE, @tax_code AS TAX_CODE, 
--	@nobill AS NONBILLABLE, @city_pct AS CITY_PCT, @county_pct AS COUNTY_PCT, @state_pct AS STATE_PCT, @comm AS COMMISSION, 
--	@tax_comm AS TAX_COMM, @tax_comm_only AS TAX_COMM_ONLY, @fee_time AS FEE_TIME

