
CREATE PROCEDURE [dbo].[usp_wv_BA_APPROVAL_JC_GET_BILLING_RATE] 
	@THIS_FNC_CODE AS VARCHAR(6),
	@THIS_JOB_NUMBER AS INT,
	@THIS_JOB_COMPONENT_NBR AS SMALLINT
AS

DECLARE
	@THIS_CL_CODE AS VARCHAR(6),
	@THIS_DIV_CODE AS VARCHAR(6),
	@THIS_PRD_CODE AS VARCHAR(6),
	@THIS_SC_CODE AS VARCHAR(6),
	@THIS_FNC_TYPE AS VARCHAR(1),
	@THIS_BILLING_RATE AS DECIMAL(9,2)
	
--GET DATA FOR SPROC:
	SELECT     
		@THIS_CL_CODE = CL_CODE, 
		@THIS_DIV_CODE = DIV_CODE, 
		@THIS_PRD_CODE = PRD_CODE, 
		@THIS_SC_CODE = SC_CODE
	FROM         
		JOB_LOG WITH(NOLOCK)
	WHERE
		JOB_NUMBER = @THIS_JOB_NUMBER;
	SELECT	
		@THIS_FNC_TYPE = FNC_TYPE
	FROM
		FUNCTIONS WITH(NOLOCK)
	WHERE
	    FNC_CODE = @THIS_FNC_CODE;		
			
	
EXECUTE dbo.sp_get_billing_rates
	@emp_code = NULL,
	@eff_date = NULL,
	@fnc_code = @THIS_FNC_CODE,
	@cl_code = @THIS_CL_CODE,
	@div_code = @THIS_DIV_CODE, 
	@prd_code = @THIS_PRD_CODE,
	@sc_code = @THIS_SC_CODE,
	@fnc_type = @THIS_FNC_TYPE, 
	@job_number = @THIS_JOB_NUMBER, 
	@job_component_nbr = @THIS_JOB_COMPONENT_NBR,
	@emp_title_id = NULL,
	@billing_rate = @THIS_BILLING_RATE OUTPUT,
	@rate_level = NULL,
	@tax_code = NULL,
	@tax_level = NULL,
	@nobill_flag = NULL,
	@nobill_level = NULL,
	@comm = NULL,
	@comm_level = NULL,
	@tax_comm = NULL,
	@tax_comm_only = NULL,
	@tax_comm_flags_level = NULL,
	@fee_time_flag = NULL,
	@fee_time_level = NULL;
	
SELECT ISNULL(@THIS_BILLING_RATE,0.00) AS BILLING_RATE;

