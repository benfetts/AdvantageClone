IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[sp_get_billing_rates]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
	DROP PROCEDURE [dbo].[sp_get_billing_rates]
GO

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS OFF 
GO

SET ANSI_PADDING OFF 
GO

-- BJL 02/15/12 - OBSOLETE - Use table function advtf_get_billing_rate(...)
CREATE PROCEDURE [dbo].[sp_get_billing_rates] 
	@emp_code varchar(6), @eff_date smalldatetime, @fnc_code varchar(6), @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6), 
	@sc_code varchar(6), @fnc_type varchar(1), @job_number integer, @job_component_nbr smallint, @emp_title_id integer = NULL,
	@billing_rate decimal(10,3) OUTPUT, @rate_level smallint OUTPUT, @tax_code varchar(4) OUTPUT, @tax_level smallint OUTPUT, 
	@nobill_flag smallint OUTPUT, @nobill_level smallint OUTPUT, @comm decimal(9,3) OUTPUT, @comm_level smallint OUTPUT, 
	@tax_comm smallint OUTPUT, @tax_comm_only smallint OUTPUT, @tax_comm_flags_level smallint OUTPUT, @fee_time_flag smallint OUTPUT, 
	@fee_time_level smallint OUTPUT
AS

SET NOCOUNT ON

	 SELECT @billing_rate = agbr.BILLING_RATE, 
			@rate_level = agbr.RATE_LEVEL, 
			@tax_code = agbr.TAX_CODE, 
			@tax_level = agbr.TAX_LEVEL, 
			@nobill_flag = agbr.NOBILL_FLAG, 
			@nobill_level = agbr.NOBILL_LEVEL, 
			@comm = agbr.COMM, 
			@comm_level = agbr.COMM_LEVEL,
	        @tax_comm = agbr.TAX_COMM, 
	        @tax_comm_only = agbr.TAX_COMM_ONLY, 
	        @tax_comm_flags_level = agbr.TAX_COMM_FLAGS_LEVEL, 
	        @fee_time_flag = agbr.FEE_TIME_FLAG,
	        @fee_time_level = agbr.FEE_TIME_LEVEL
	   FROM dbo.advtf_get_billing_rate( @emp_code, @eff_date, @fnc_code, @cl_code, @div_code, @prd_code, @sc_code, @fnc_type, @job_number, @job_component_nbr, @emp_title_id ) agbr

end_tran:
GO

GRANT EXECUTE ON sp_get_billing_rates TO PUBLIC AS dbo
GO	

