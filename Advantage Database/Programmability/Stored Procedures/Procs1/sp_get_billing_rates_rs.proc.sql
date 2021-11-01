IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[sp_get_billing_rates_rs]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
	DROP PROCEDURE [dbo].[sp_get_billing_rates_rs]
GO

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS OFF 
GO

SET ANSI_PADDING OFF 
GO

-- BJL 02/15/12 - OBSOLETE - Use table function advtf_get_billing_rate(...)
CREATE PROCEDURE [dbo].[sp_get_billing_rates_rs] 
	@emp_code varchar(6), @eff_date smalldatetime, @fnc_code varchar(6), @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6), 
	@sc_code varchar(6), @fnc_type varchar(1), @job_number integer, @job_component_nbr smallint
AS

SET NOCOUNT ON

	 SELECT agbr.BILLING_RATE, 
			agbr.RATE_LEVEL, 
			agbr.TAX_CODE, 
			agbr.TAX_LEVEL, 
			agbr.NOBILL_FLAG, 
			agbr.NOBILL_LEVEL, 
			agbr.COMM, 
			agbr.COMM_LEVEL,
	        agbr.TAX_COMM, 
	        agbr.TAX_COMM_ONLY,
	        agbr.TAX_COMM_FLAGS_LEVEL, 
	        agbr.FEE_TIME_FLAG,
	        agbr.FEE_TIME_LEVEL
	   FROM dbo.advtf_get_billing_rate( @emp_code, @eff_date, @fnc_code, @cl_code, @div_code, @prd_code, @sc_code, @fnc_type, @job_number, @job_component_nbr, NULL ) agbr

end_tran:
GO

GRANT EXECUTE ON sp_get_billing_rates_rs TO PUBLIC AS dbo
GO	

