IF ( OBJECT_ID( N'[dbo].[advtf_get_billing_rate_ps]', 'TF' ) IS NOT NULL )
	DROP FUNCTION [dbo].[advtf_get_billing_rate_ps]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- BJL 02/20/07 - Added the job information, function type, and removed the tax flag output
-- BJL 03/20/07 - Make non-billable when fee flag is set
-- BJL 03/21/07 - Reworked job tax settings
-- BJL 03/22/07 - Eliminated option to not calculate non-billable rate
-- BJL 03/27/07 - If the markup check gets through the entire hierarchy and remains NULL, leave NULL (for estimating)
-- BJL 03/29/07 - If the tax check gets through the entire hierarchy and remains NULL, use tax code from Job when Agency option is on
-- BJL 03/29/07 - Remove non-billable setting when billing rate is NULL
-- KN  01/13/10 - Estimate Billing Rate overrides the structure if the Product record indicates
-- KN  01/22/10 - Estimate Billing Rate level changed to 9999
-- KN  02/18/10 - Additional changes for Estimate Billing Rate
-- KN  03/03/10 - Added blended time rate level
-- KN  04/07/10 - Corrected problem with returning the estimate bill rate regardless of setting in PRODUCT
-- BJL 05/06/10 - Added employee title as component in rate calculation
-- BJL 07/18/12 - If markup is NULL, default to 0
-- ST  05/27/14 - Merge with changes in sp_get_billing_rates that were not in this function (Kay's last 3 changes in this list)
-- AC  12/04/17 - Added employee title as parameter
-- MC  03/19/19 - consider INACTIVE rows in the BILLING_RATE table

CREATE FUNCTION [dbo].[advtf_get_billing_rate_ps] ( 
												@emp_code VARCHAR(6), 
												@eff_date SMALLDATETIME, 
												@fnc_code VARCHAR(6), 
												@cl_code VARCHAR(6),
												@div_code VARCHAR(6), 
												@prd_code VARCHAR(6),
												@sc_code VARCHAR(6), 
												@fnc_type VARCHAR(1), 
												@job_number INTEGER, 
												@job_component_nbr SMALLINT,
												@emp_title_id INTEGER = NULL
												)
RETURNS @billing_rate_table TABLE ( 
	BILLING_RATE			DECIMAL(10,3), 
	RATE_LEVEL				SMALLINT, 
	TAX_CODE				VARCHAR(4), 
	TAX_LEVEL				SMALLINT, 
	NOBILL_FLAG				SMALLINT, 
	NOBILL_LEVEL			SMALLINT, 
	COMM					DECIMAL(9,3), 
	COMM_LEVEL				SMALLINT, 
	TAX_COMM				SMALLINT,
	TAX_COMM_ONLY			SMALLINT, 
	TAX_COMM_FLAGS_LEVEL	SMALLINT, 
	FEE_TIME_FLAG			SMALLINT, 
	FEE_TIME_LEVEL			SMALLINT 
)
AS
BEGIN

	DECLARE 
		@billing_rate DECIMAL(10,3), 
		@rate_level SMALLINT, 
		@tax_code VARCHAR(4), 
		@tax_level SMALLINT,
		@nobill_flag SMALLINT, 
		@nobill_level SMALLINT, 
		@comm DECIMAL(9,3), 
		@comm_level SMALLINT, 
		@tax_comm SMALLINT,
		@tax_comm_flags_level SMALLINT, 
		@fee_time_flag SMALLINT, 
		@fee_time_level SMALLINT, 
		@tax_comm_only SMALLINT,
		@return_value INTEGER, 
		@inc_bill_rate SMALLINT, 
		@agency_tax_flag SMALLINT, 
		@tax_comm_flags SMALLINT,
		@job_tax_flag SMALLINT, 
		@job_tax_code VARCHAR(4), 
		@job_nobill_flag SMALLINT, 
		@job_comm DECIMAL(9,3),
		@prd_tax_code VARCHAR(4), 
		@prd_markup_pct DECIMAL(9,3), 
		@tax_flag SMALLINT, 
		@est_nbr INTEGER, 
		@est_comp_nbr SMALLINT,
		@use_est_rate SMALLINT, 
		@est_bill_rate DECIMAL(9,2), 
		@est_quote SMALLINT, 
		@est_rev SMALLINT, 
		--@emp_title_id INTEGER, 
		@est_blended_rate decimal(9,2);

	SELECT 
		@agency_tax_flag = FLAG_TAX_JOBS, 
		@inc_bill_rate = INC_BILL_RATE 
	FROM 
		AGENCY WITH(NOLOCK);
	   
	-- BJL 05/06/10
	IF ( @emp_code IS NOT NULL and @emp_title_id IS NULL )
	BEGIN

		SELECT 
			@emp_title_id = e.EMPLOYEE_TITLE_ID 
		FROM 
			EMPLOYEE e WITH(NOLOCK) 
		WHERE 
			e.EMP_CODE = @emp_code;

	END

	IF ( @job_number > 0 AND @job_component_nbr > 0 )
	BEGIN

		SELECT 
			@job_tax_flag = TAX_FLAG, 
			@job_tax_code = TAX_CODE, 
			@job_nobill_flag = NOBILL_FLAG, 
			@job_comm = JOB_MARKUP_PCT  
		FROM 
			JOB_COMPONENT WITH(NOLOCK)
		WHERE 
			JOB_NUMBER = @job_number
			AND JOB_COMPONENT_NBR = @job_component_nbr;

		IF ( @job_nobill_flag = 1 )
		BEGIN

			SELECT @nobill_flag = 1;
			SELECT @nobill_level = 0;

		END

		--get approved estimate
		SELECT 
			TOP 1 
			@est_nbr = ISNULL(ESTIMATE_NUMBER, 0), 
			@est_comp_nbr = EST_COMPONENT_NBR, 
			@est_quote = EST_QUOTE_NBR, 
			@est_rev = EST_REVISION_NBR
		FROM 
			ESTIMATE_APPROVAL WITH(NOLOCK)
		WHERE 
			JOB_NUMBER = @job_number
			AND JOB_COMPONENT_NBR = @job_component_nbr
		ORDER BY
			ESTIMATE_APPROVAL.ESTIMATE_NUMBER DESC,
			ESTIMATE_APPROVAL.EST_COMPONENT_NBR DESC,
			ESTIMATE_APPROVAL.EST_QUOTE_NBR DESC,
			ESTIMATE_APPROVAL.EST_REVISION_NBR DESC;

	END
	ELSE -- If there is no job data, cannot use the job settings
	BEGIN

		SELECT @agency_tax_flag = 0;

	END

	IF ( @cl_code IS NOT NULL ) AND ( @div_code IS NOT NULL ) AND ( @prd_code IS NOT NULL )
	BEGIN

		SELECT
			@prd_tax_code = PRD_PROD_TAX_CODE, 
			@prd_markup_pct = PRD_PROD_MARKUP, 
			@use_est_rate = USE_EST_BILL_RATE  
		FROM 
			PRODUCT WITH(NOLOCK) 
		WHERE 
			CL_CODE = @cl_code 
			AND DIV_CODE = @div_code
			AND PRD_CODE = @prd_code;

	END
	
	-- Find the billing rate
	SELECT 
		TOP 1 
		@billing_rate = BR.BILLING_RATE, 
		@rate_level = BRP.PRECEDENCE
	FROM 
		BILLING_RATE BR WITH(NOLOCK), 
		BILL_RATE_PREC BRP WITH(NOLOCK)
	WHERE 
		BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID
		AND (( BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code ) OR ( BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL AND (@fnc_type = 'E' OR @fnc_code IS NULL)))
		AND (( BRP.EMP_INCL = 1 AND (@fnc_type = 'E' OR @fnc_code IS NULL) AND BR.EMP_CODE = @emp_code ) OR ( BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL ))
		AND (( BRP.TITLE_INCL = 1 AND (@fnc_type = 'E' OR @fnc_code IS NULL) AND BR.EMPLOYEE_TITLE_ID = @emp_title_id ) OR ( BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL ))
		AND (( BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code ) OR ( BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL ))
		AND (( BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code ) OR ( BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL ))
		AND (( BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code ) OR ( BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL ))
		AND (( BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code ) OR ( BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL ))
		AND (( BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date ) OR ( BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL ))
		--AND ( BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL )
		AND ( BRP.INACTIVE_FLAG = 0 OR BRP.INACTIVE_FLAG IS NULL )
		AND BRP.BILL_RATE_INCL = 1
		AND BR.BILLING_RATE IS NOT NULL
	ORDER BY 
		BRP.PRECEDENCE DESC, 
		BR.EFFECTIVE_DATE DESC;

	--get the estimate billing rate if appropriate
	IF ( @use_est_rate = 1 ) AND ( @est_nbr > 0 ) AND ( @est_comp_nbr > 0 )
	BEGIN

		SELECT 
			TOP 1 
			@est_blended_rate = E.BLENDED_TIME_RATE
		FROM 
			dbo.ESTIMATE_REV E WITH(NOLOCK)
		WHERE 
			E.ESTIMATE_NUMBER = @est_nbr 
			AND E.EST_COMPONENT_NBR = @est_comp_nbr
			AND E.EST_QUOTE_NBR = @est_quote
			AND E.EST_REV_NBR = @est_rev
		ORDER BY
			E.ESTIMATE_NUMBER DESC,
			E.EST_COMPONENT_NBR DESC,
			E.EST_QUOTE_NBR DESC,
			E.EST_REV_NBR DESC;

		IF ( @emp_code IS NOT NULL ) AND ( @fnc_code IS NOT NULL )
		BEGIN

			SELECT 
				TOP 1 
				@est_bill_rate = E.EST_REV_RATE
			FROM 
				ESTIMATE_REV_DET E WITH(NOLOCK)
			WHERE 
				E.ESTIMATE_NUMBER = @est_nbr 
				AND E.EST_COMPONENT_NBR = @est_comp_nbr
				AND E.EST_QUOTE_NBR = @est_quote
				AND E.EST_REV_NBR = @est_rev
				AND E.EST_REV_SUP_BY_CDE = @emp_code
				AND E.FNC_CODE = @fnc_code
			ORDER BY
				E.ESTIMATE_NUMBER DESC,
				E.EST_COMPONENT_NBR DESC,
				E.EST_QUOTE_NBR DESC,
				E.EST_REV_NBR DESC;

			--Override structure bill rate
			IF ( @est_bill_rate IS NOT NULL )
			BEGIN

				SELECT @billing_rate = @est_bill_rate;
				SELECT @rate_level = 9999;

			END

		END	
		ELSE	--estimate may have the function with no employee code
		BEGIN

			IF ( @fnc_code IS NOT NULL )
			BEGIN
				
				SELECT 
					TOP 1 
					@est_bill_rate = E.EST_REV_RATE
				FROM 
					ESTIMATE_REV_DET E WITH(NOLOCK)
				WHERE 
					E.ESTIMATE_NUMBER = @est_nbr
					AND E.EST_COMPONENT_NBR = @est_comp_nbr
					AND E.EST_QUOTE_NBR = @est_quote
					AND E.EST_REV_NBR = @est_rev
					AND E.FNC_CODE = @fnc_code
				ORDER BY
					E.ESTIMATE_NUMBER DESC,
					E.EST_COMPONENT_NBR DESC,
					E.EST_QUOTE_NBR DESC,
					E.EST_REV_NBR DESC;

				IF ( @est_bill_rate IS NOT NULL )
				BEGIN

					SELECT @billing_rate = @est_bill_rate;
					SELECT @rate_level = 9999;

				END

			END
			ELSE
			BEGIN

				IF ( @emp_code IS NOT NULL )
				BEGIN

				  SELECT 
					TOP 1	
					@est_bill_rate = E.EST_REV_RATE
				  FROM 
					ESTIMATE_REV_DET E WITH (NOLOCK)
				  WHERE 
					E.ESTIMATE_NUMBER = @est_nbr 
					AND E.EST_COMPONENT_NBR = @est_comp_nbr
					AND E.EST_QUOTE_NBR = @est_quote
					AND E.EST_REV_NBR = @est_rev
					AND E.EST_REV_SUP_BY_CDE = @emp_code
				  ORDER BY
					E.ESTIMATE_NUMBER DESC,
					E.EST_COMPONENT_NBR DESC,
					E.EST_QUOTE_NBR DESC,
					E.EST_REV_NBR DESC;

					--Override structure bill rate
					IF ( @est_bill_rate IS NOT NULL )
					BEGIN

						SELECT @billing_rate = @est_bill_rate;
						SELECT @rate_level = 9999;

					END	

				END

			END

		END

	END

	--use the blended rate if appropriate
	IF ( @use_est_rate = 1 ) AND ( @est_nbr > 0 ) AND ( @est_comp_nbr > 0 ) AND ( @fnc_type = 'E' ) AND ( @est_bill_rate IS NULL ) AND ( @est_blended_rate IS NOT NULL )
	BEGIN

		SELECT @billing_rate = @est_blended_rate;
		SELECT @rate_level = 9999;

	END
	
	-- For employee time, when no rate is found in the entire structure, set the rate to 0
	IF ( @billing_rate IS NULL ) AND ( @fnc_type = 'E' )
	BEGIN

		SELECT @billing_rate = 0;

	END

	SET @tax_flag = NULL;

	IF @agency_tax_flag = 1
	BEGIN

		-- Check to see if the job is non-taxable
		IF ( @job_tax_flag = 0 OR @job_tax_flag IS NULL )
		BEGIN

			SELECT @tax_flag = 0;
			SELECT @tax_level = -1;

		END

	END

	IF ( @tax_flag IS NULL ) 
	BEGIN

		-- Get the tax code 
		SELECT 
			TOP 1 
			@tax_flag = BR.TAX_FLAG, 
			@tax_code = BR.TAX_CODE, 
			@tax_level = BRP.PRECEDENCE 	
		FROM 
			BILLING_RATE BR WITH(NOLOCK), 
			BILL_RATE_PREC BRP WITH(NOLOCK)
		WHERE 
			BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID 
			AND (( BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code ) OR ( BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL AND (@fnc_type = 'E' OR @fnc_code IS NULL) ))
			AND (( BRP.EMP_INCL = 1 AND BR.EMP_CODE = @emp_code AND (@fnc_type = 'E' OR @fnc_code IS NULL) ) OR ( BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL ))
			AND (( BRP.TITLE_INCL = 1 AND (@fnc_type = 'E' OR @fnc_code IS NULL) AND BR.EMPLOYEE_TITLE_ID = @emp_title_id ) OR ( BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL ))
			AND (( BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code ) OR ( BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL ))
			AND (( BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code ) OR ( BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL ))
			AND (( BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code ) OR ( BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL ))
			AND (( BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code ) OR ( BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL ))
			AND (( BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date ) OR ( BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL ))
			--AND ( BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL )
			AND ( BRP.INACTIVE_FLAG = 0 OR BRP.INACTIVE_FLAG IS NULL )
			AND BRP.TAX_INCL = 1
			AND BR.TAX_FLAG IS NOT NULL 
		ORDER BY 
			BRP.PRECEDENCE DESC, 
			BR.EFFECTIVE_DATE DESC;
	
		-- If the whole hierarchy was checked and no value was found, go back to job if option was turned on
		IF ( @tax_flag IS NULL ) AND ( @agency_tax_flag = 1 )
		BEGIN

			SELECT @tax_flag = 1;

		END

		IF ( @tax_flag = 1 )
		BEGIN

			IF ( @agency_tax_flag = 1 )
			BEGIN

				SELECT @tax_code = @job_tax_code;

			END
			ELSE
			BEGIN

				IF ( @tax_code IS NULL )
				BEGIN

					SELECT @tax_code = @prd_tax_code;

				END

			END

		END
		ELSE
		BEGIN

			SELECT @tax_flag = 0;
			SELECT @tax_code = NULL;

		END

	END

	IF ( @nobill_flag IS NULL )
	BEGIN

		-- Determine non-billable flag
		SELECT 
			TOP 1 
			@nobill_flag = BR.NOBILL_FLAG, 
			@nobill_level = BRP.PRECEDENCE 	
		FROM 
			BILLING_RATE BR WITH(NOLOCK), 
			BILL_RATE_PREC BRP WITH(NOLOCK)
		WHERE 
			BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID 
			AND (( BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code ) OR ( BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL AND (@fnc_type = 'E' OR @fnc_code IS NULL) ))
			AND (( BRP.EMP_INCL = 1 AND BR.EMP_CODE = @emp_code AND (@fnc_type = 'E' OR @fnc_code IS NULL) ) OR ( BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL ))
			AND (( BRP.TITLE_INCL = 1 AND (@fnc_type = 'E' OR @fnc_code IS NULL) AND BR.EMPLOYEE_TITLE_ID = @emp_title_id ) OR ( BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL ))			
			AND (( BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code ) OR ( BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL ))
			AND (( BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code ) OR ( BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL ))
			AND (( BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code ) OR ( BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL ))
			AND (( BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code ) OR ( BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL ))
			AND (( BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date ) OR ( BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL ))
			--AND ( BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL )
			AND ( BRP.INACTIVE_FLAG = 0 OR BRP.INACTIVE_FLAG IS NULL )
			AND BRP.NONBILL_INCL = 1
			AND BR.NOBILL_FLAG IS NOT NULL
		ORDER BY 
			BRP.PRECEDENCE DESC, 
			BR.EFFECTIVE_DATE DESC;

	END

	IF ( @nobill_level IS NULL )
	BEGIN

		SELECT @nobill_flag = 0;

	END

	-- BJL 03/22/07 - Eliminate ability to not calculate rate
	-- Clear the rate if non-billable and the AGENCY setting directs you to do so for employee time
	--IF ( @nobill_flag = 1 ) AND ( @fnc_type = 'E' ) AND ( @inc_bill_rate = 0 OR @inc_bill_rate IS NULL )	
	--	SELECT @billing_rate = 0

	--	Get the MU flags
	SELECT @tax_comm = 0;
	SELECT @tax_comm_only = 0;

	SELECT 
		TOP 1 
		@tax_comm_flags = BR.TAX_COMM_FLAGS, 
		@tax_comm_flags_level = BRP.PRECEDENCE
	FROM 
		BILLING_RATE BR WITH(NOLOCK), 
		BILL_RATE_PREC BRP WITH(NOLOCK)
	WHERE 
		BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID 
		AND (( BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code ) OR ( BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL AND (@fnc_type = 'E' OR @fnc_code IS NULL) ))
		AND (( BRP.EMP_INCL = 1 AND BR.EMP_CODE = @emp_code AND (@fnc_type = 'E' OR @fnc_code IS NULL) ) OR ( BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL ))
		AND (( BRP.TITLE_INCL = 1 AND (@fnc_type = 'E' OR @fnc_code IS NULL) AND BR.EMPLOYEE_TITLE_ID = @emp_title_id ) OR ( BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL ))
		AND (( BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code ) OR ( BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL ))
		AND (( BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code ) OR ( BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL ))
		AND (( BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code ) OR ( BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL ))
		AND (( BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code ) OR ( BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL ))
		AND (( BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date ) OR ( BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL ))
		--AND ( BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL )
		AND ( BRP.INACTIVE_FLAG = 0 OR BRP.INACTIVE_FLAG IS NULL )
		AND BRP.TAX_COMM_INCL = 1
		AND BR.TAX_COMM_FLAGS IS NOT NULL
	ORDER BY 
		BRP.PRECEDENCE DESC, 
		BR.EFFECTIVE_DATE DESC;

	IF ( @tax_comm_flags >= 1 )
	BEGIN

		SELECT @tax_comm = 1;

	END

	IF ( @tax_comm_flags = 2 )
	BEGIN

		SELECT @tax_comm_only = 1;

	END

	--	Get the markup
	SELECT 
		TOP 1 
		@comm = BR.COMMISSION, 
		@comm_level = BRP.PRECEDENCE
	FROM 
		BILLING_RATE BR WITH(NOLOCK), 
		BILL_RATE_PREC BRP WITH(NOLOCK)
	WHERE 
		BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID 
		AND (( BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code ) OR ( BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL AND (@fnc_type = 'E' OR @fnc_code IS NULL) ))
		AND (( BRP.EMP_INCL = 1 AND BR.EMP_CODE = @emp_code AND (@fnc_type = 'E' OR @fnc_code IS NULL) ) OR ( BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL ))
		AND (( BRP.TITLE_INCL = 1 AND (@fnc_type = 'E' OR @fnc_code IS NULL) AND BR.EMPLOYEE_TITLE_ID = @emp_title_id ) OR ( BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL ))
		AND (( BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code ) OR ( BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL ))
		AND (( BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code ) OR ( BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL ))
		AND (( BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code ) OR ( BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL ))
		AND (( BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code ) OR ( BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL ))
		AND (( BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date ) OR ( BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL ))
		--AND ( BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL )
		AND ( BRP.INACTIVE_FLAG = 0 OR BRP.INACTIVE_FLAG IS NULL )
		AND BRP.COMM_INCL = 1
		AND BR.COMMISSION IS NOT NULL
	ORDER BY 
		BRP.PRECEDENCE DESC, 
		BR.EFFECTIVE_DATE DESC;

	IF @comm IS NULL
	BEGIN

		SELECT @comm = @job_comm;		
		SELECT @comm_level = -1;

	END

	IF @comm IS NULL
	BEGIN

		SELECT @comm = @prd_markup_pct;
		SELECT @comm_level = -2;

	END	

	IF ( @comm IS NULL )
	BEGIN

		SELECT @comm = 0.000;
		SELECT @comm_level = NULL;

	END	

	-- Get the fee time setting
	IF ( @fnc_type = 'E' )
	BEGIN

		SELECT 
			TOP 1 
			@fee_time_flag = BR.FEE_TIME, 
			@fee_time_level = BRP.PRECEDENCE
		FROM 
			BILLING_RATE BR WITH(NOLOCK), 
			BILL_RATE_PREC BRP WITH(NOLOCK)
		WHERE 
			BR.BILL_RATE_PREC_ID = BRP.BILL_RATE_PREC_ID 
			AND (( BRP.FNC_INCL = 1 AND BR.FNC_CODE = @fnc_code ) OR ( BRP.FNC_INCL = 0 AND BR.FNC_CODE IS NULL ))
			AND (( BRP.EMP_INCL = 1 AND BR.EMP_CODE = @emp_code ) OR ( BRP.EMP_INCL = 0 AND BR.EMP_CODE IS NULL ))
			AND (( BRP.TITLE_INCL = 1 AND @fnc_type = 'E' AND BR.EMPLOYEE_TITLE_ID = @emp_title_id ) OR ( BRP.TITLE_INCL = 0 AND BR.EMPLOYEE_TITLE_ID IS NULL ))	 
			AND (( BRP.CL_INCL = 1 AND BR.CL_CODE = @cl_code ) OR ( BRP.CL_INCL = 0 AND BR.CL_CODE IS NULL ))
			AND (( BRP.DIV_INCL = 1 AND BR.DIV_CODE = @div_code ) OR ( BRP.DIV_INCL = 0 AND BR.DIV_CODE IS NULL ))
			AND (( BRP.PRD_INCL = 1 AND BR.PRD_CODE = @prd_code ) OR ( BRP.PRD_INCL = 0 AND BR.PRD_CODE IS NULL ))
			AND (( BRP.SC_INCL = 1 AND BR.SC_CODE = @sc_code ) OR ( BRP.SC_INCL = 0 AND BR.SC_CODE IS NULL ))
			AND (( BRP.EFF_DT_INCL = 1 AND BR.EFFECTIVE_DATE <= @eff_date ) OR ( BRP.EFF_DT_INCL = 0 AND BR.EFFECTIVE_DATE IS NULL ))
			--AND ( BR.INACTIVE_FLAG = 0 OR BR.INACTIVE_FLAG IS NULL )
			AND ( BRP.INACTIVE_FLAG = 0 OR BRP.INACTIVE_FLAG IS NULL )
			AND BRP.FEE_TIME_INCL = 1
			AND BR.FEE_TIME IS NOT NULL
		ORDER BY
			BRP.PRECEDENCE DESC, 
			BR.EFFECTIVE_DATE DESC;

		IF ( @fee_time_flag IS NULL )
		BEGIN

			SELECT @fee_time_flag = 0;

		END

		IF ( @fee_time_flag > 0 )
		BEGIN

			SELECT @nobill_flag = 1;

		END

	END

	INSERT INTO @billing_rate_table ( 
									 BILLING_RATE, 
									 RATE_LEVEL, 
									 TAX_CODE, 
									 TAX_LEVEL, 
									 NOBILL_FLAG, 
									 NOBILL_LEVEL, 
									 COMM, COMM_LEVEL,
									 TAX_COMM, 
									 TAX_COMM_ONLY, 
									 TAX_COMM_FLAGS_LEVEL, 
									 FEE_TIME_FLAG, 
									 FEE_TIME_LEVEL
									 ) 
									 VALUES ( 
									 @billing_rate, 
									 @rate_level, 
									 @tax_code, 
									 @tax_level, 
									 @nobill_flag, 
									 @nobill_level, 
									 @comm, 
									 @comm_level, 
									 @tax_comm,
									 @tax_comm_only, 
									 @tax_comm_flags_level, 
									 @fee_time_flag,
									 @fee_time_level
									 );	
				  	
	RETURN

END

GO

GRANT SELECT ON advtf_get_billing_rate TO PUBLIC AS dbo
GO