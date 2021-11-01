CREATE PROCEDURE [dbo].[advsp_billing_rate_is_non_billable]( 
	@emp_code varchar(6), 
	@eff_date smalldatetime, 
	@fnc_code varchar(6), 
	@cl_code varchar(6),
	@div_code varchar(6), 
	@prd_code varchar(6), 
	@sc_code varchar(6), 
	@fnc_type varchar(1), 
	@job_number integer, 
	@job_component_nbr smallint )
AS
BEGIN

	DECLARE @nobill_flag smallint
	DECLARE @nobill_level smallint 
	DECLARE @job_nobill_flag smallint
	DECLARE @emp_title_id integer
	DECLARE @fee_time_flag smallint
	DECLARE @fee_time_level smallint

	IF @emp_code IS NOT NULL BEGIN   
		
		SELECT @emp_title_id = EMPLOYEE_TITLE_ID
		FROM dbo.EMPLOYEE WITH (NOLOCK)	
		WHERE EMP_CODE = @emp_code ;

	END

	IF @job_number > 0 AND @job_component_nbr > 0 BEGIN

		SELECT 
			@job_nobill_flag = JC.NOBILL_FLAG
		FROM 
			dbo.JOB_COMPONENT JC
		WHERE 
			JC.JOB_NUMBER = @job_number AND 
			JC.JOB_COMPONENT_NBR = @job_component_nbr

		IF @job_nobill_flag = 1 BEGIN
		
			SELECT @nobill_flag = 1
			SELECT @nobill_level = 0
			
		END

	END

	IF @nobill_flag IS NULL BEGIN

		SELECT 
			TOP 1 
			@nobill_flag = BR.NOBILL_FLAG, 
			@nobill_level = BRP.PRECEDENCE 	
		FROM 
			dbo.BILLING_RATE BR, 
			dbo.BILL_RATE_PREC BRP
		WHERE 
			BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID AND 
			((BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code) OR (BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL AND @fnc_type = 'E')) AND 
			((BRP.EMP_INCL = 1 AND BR.EMP_CODE = @emp_code AND @fnc_type = 'E') OR (BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL)) AND 
			((BRP.TITLE_INCL = 1 AND @fnc_type = 'E' AND BR.EMPLOYEE_TITLE_ID = @emp_title_id) OR (BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL)) AND 
			((BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code) OR (BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL)) AND 
			((BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code) OR (BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL)) AND 
			((BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code) OR (BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL)) AND 
			((BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code) OR (BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL)) AND 
			((BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date) OR (BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL)) AND 
			(BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL) AND 
			(BRP.INACTIVE_FLAG = 0 OR BRP.INACTIVE_FLAG IS NULL) AND 
			BRP.NONBILL_INCL = 1 AND 
			BR.NOBILL_FLAG IS NOT NULL
		ORDER BY 
			BRP.PRECEDENCE DESC, 
			BR.EFFECTIVE_DATE DESC

	END

	IF @nobill_level IS NULL BEGIN
	
		SELECT @nobill_flag = 0

	END
	
	IF @fnc_type = 'E' BEGIN

		SELECT 
			TOP 1 
			@fee_time_flag = BR.FEE_TIME, 
			@fee_time_level = BRP.PRECEDENCE
		FROM 
			dbo.BILLING_RATE BR, 
			dbo.BILL_RATE_PREC BRP
		WHERE 
			BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID AND 
			((BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code) OR (BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL AND @fnc_type = 'E')) AND 
			((BRP.EMP_INCL = 1 AND BR.EMP_CODE = @emp_code AND @fnc_type = 'E') OR (BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL)) AND 
			((BRP.TITLE_INCL = 1 AND @fnc_type = 'E' AND BR.EMPLOYEE_TITLE_ID = @emp_title_id) OR (BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL)) AND 
			((BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code) OR (BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL)) AND 
			((BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code) OR (BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL)) AND 
			((BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code) OR (BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL)) AND 
			((BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code) OR (BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL)) AND 
			((BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date) OR (BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL)) AND 
			(BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL) AND 
			BRP.FEE_TIME_INCL = 1 AND
			BR.FEE_TIME IS NOT NULL
		ORDER BY 
			BRP.PRECEDENCE DESC, 
			BR.EFFECTIVE_DATE DESC

		IF @fee_time_flag IS NULL BEGIN
		
			SELECT @fee_time_flag = 0

		END
			
		IF @fee_time_flag > 0 BEGIN
		
			SELECT @nobill_flag = 1
			
		END
		
	END

	SELECT
		[IsNoBill] = CAST(@nobill_flag AS bit)
		
END


GO


