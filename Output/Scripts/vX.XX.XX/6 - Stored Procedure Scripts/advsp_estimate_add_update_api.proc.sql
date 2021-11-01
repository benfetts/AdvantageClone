IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_estimate_add_update_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_estimate_add_update_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_estimate_add_update_api] 
	@user_id varchar(100), 
	@action varchar(10), 
	@job_number int,
	@job_component_nbr smallint,
	@FunctionTable AS ESTIMATE_REV_DET_API_TYPE READONLY,
	@create_revision bit,
	@auto_approve int,
	@client_discount_code varchar(6),
	--@cmp_indentifier int = 0,
	@est_nbr_new int OUTPUT,
	@comp_nbr_new int OUTPUT,
	@quote_nbr_new int OUTPUT,
	@rev_nbr_new int OUTPUT,
	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT,
	@cmp_indentifier varchar(10) = NULL,
	@sales_class varchar(6) = NULL

AS

/*
PJH 09/22/17 - Created [advsp_estimate_add_update_api]
PJH 12/18/17 - Changed to always calc amt &/or rate based on the following
PJH 01/19/18 - Must drop & re-add when updating ESTIMATE_REV_DET_API_TYPE 
PJH 04/16/18 - Auto approve and Est/Comp Descriptions
PJH 04/17/18 - New Est Component logic - Added MAX
PJH 04/19/18 - Always use @billing_comm_pct unless user overrides via API
PJH 04/19/18 - Added ability to update by SEQ_NBR if provided, else update row with max SEQ_NBR with the given FNC_CODE
PJH 04/19/18 - Changed to -1 if error, 0 if ok, > 0 if returning new seq nbr
PJH 05/11/18 - Tweaked code for existing function roes
PJH 07/14/18 - Added ability to send [EST_REV_COMM_AMT] via ESTIMATE_REV_DET_API_TYPE
PJH 07/31/18 - Allow RATE, QTY, AMT to be anything sent - Per EC
*/

SET NOCOUNT ON

DECLARE @error_msg_w varchar(1024)
DECLARE @date_time_w SMALLDATETIME

DECLARE @DEBUG int
DECLARE @RC int
	,@RC_MSG varchar(max)

DECLARE @ErMessage Nvarchar(2048)
	,@ErSeverity int
	,@ErState int

DECLARE @EST_NUM_NEW int
	,@EST_COMPONENT_NBR smallint

/* Priduct Level */
DECLARE @prd_comm_pct decimal(9, 3)

/* Funtion Levele Table */
DECLARE @estimate_rev_det_api_type AS TABLE(
	[ID] [int] identity(1,1),
	[SEQ_NBR] [int],
	[FNC_CODE] [varchar](6) NULL,
	[EST_REV_COMM_PCT] [decimal](9, 3) NULL,
	[EST_REV_COMM_AMT] [decimal](15, 2) NULL,
	[EST_REV_QUANTITY] [decimal](15, 2) NULL,
	[EST_REV_RATE] [decimal](15, 4) NULL,
	[EST_REV_EXT_AMT] [decimal](15, 2) NULL,
	[EST_FNC_COMMENT] [varchar] (255)
)
/* Job Level */
DECLARE @cl_code varchar(6)
	,@div_code varchar(6)
	,@prd_code varchar(6)
	,@job_process_contrl smallint
	,@sc_code varchar(6)
	,@job_comm_pct decimal(9, 3)

DECLARE @estimate_nbr_existing int
	,@est_component_nbr_existing smallint

DECLARE @fnc_code varchar(6)
	,@est_rev_comm_pct decimal(9,3)
	,@est_rev_comm_amt decimal(15,2)
	,@est_rev_quantity decimal(15,2)
	,@est_rev_rate decimal(15,4)
	,@est_rev_ext_amt decimal(15,2)

DECLARE @fnc_inactive smallint
	,@fnc_type varchar(1)
	,@sc_inactive smallint
	,@tax_code varchar(6)
	,@tax_code_inactive smallint
	,@tax_resale smallint
	,@est_tax_flag smallint
	,@fnc_cpm_flag smallint
	,@comm_flag smallint
	,@prd_active smallint
	,@div_active smallint
	,@cl_active smallint

DECLARE @emp_code varchar(6)
	,@eff_date SMALLDATETIME
	,@billing_rate decimal(10, 3)
	,@rate_level smallint
	,@tax_level smallint
	,@nobill_flag smallint
	,@nobill_level smallint
	,@est_comm_pct decimal(9, 3)
	,@comm_level smallint
	,@tax_comm smallint
	,@tax_comm_only smallint
	,@tax_comm_flags_level smallint
	,@fee_time_flag smallint
	,@fee_time_level smallint
	,@city_tax_pct decimal(10, 3)
	,@county_tax_pct decimal(10, 3)
	,@state_tax_pct decimal(10, 3)
	,@emp_cost_rate decimal(10, 3)
	,@tax_jobs_flag smallint
	,@comm_amt decimal(15, 2)
	,@city_tax_amt decimal(15, 2)
	,@county_tax_amt decimal(15, 2)
	,@state_tax_amt decimal(15, 2)
	,@nonresale_tax_amt decimal(15, 2)
	,@line_total_amt decimal(15, 2)
	--,@cont_pct decimal(9, 3)
	,@est_rev_ext_amt_cont decimal(15, 2)
	,@est_rev_rate_cont decimal(15, 4)
	,@comm_amt_cont decimal(15, 2)
	,@city_tax_amt_cont decimal(15, 2)
	,@county_tax_amt_cont decimal(15, 2)
	,@state_tax_amt_cont decimal(15, 2)
	,@nonresale_tax_amt_cont decimal(15, 2)
	,@line_total_amt_cont decimal(15, 2)
	,@est_rev_sup_by_cde varchar(6)
	,@est_rev_sup_by_nte varchar(max)
	,@est_fnc_comment varchar(max)
	,@incl_cpu smallint
	,@fee_time smallint

DECLARE 	@prd_cont_pct decimal(9, 3)
DECLARE 	@est_rev_cont_pct decimal(9, 3)

DECLARE @billing_comm_pct decimal(9,3)
	,@est_seq_nbr int

DECLARE @approval_new int
	--,@est_desc varchar(255)

DECLARE @next_quote_nbr int
	,@next_rev_nbr int
	,@next_seq_nbr int
	,@next_rev_nbr_rev_dtl int

DECLARE @fnc_cnt int
	,@row int
	,@quote_exists bit
	,@fnc_exists bit
	,@new_est bit
	,@new_est_rev bit
	,@int_approval_exists bit
	,@cli_approval_exists bit
	,@cnt int
	,@auto_approve_int int
	,@auto_approve_client int
	,@temp_amt decimal(15, 2)

DECLARE @job_number_existing int
	,@job_component_nbr_existing smallint
	,@job_desc varchar(60)
	,@job_component_desc varchar(60)
	,@cmp_name varchar(60)

DECLARE @single_func_seq int

DECLARE @cmp_indentifier_n int

DECLARE @use_job_comp bit

INSERT into @estimate_rev_det_api_type
SELECT	
	[ID],
	[FNC_CODE],
	[EST_REV_COMM_PCT],
	[EST_REV_COMM_AMT],
	[EST_REV_QUANTITY],
	[EST_REV_RATE],
	[EST_REV_EXT_AMT],
	[EST_FNC_COMMENT]
FROM @FunctionTable

If @@ROWCOUNT = 1
	SET @single_func_seq = 1
ELSE
	SET @single_func_seq = 0

--SELECT '@FunctionTable' 'DESC', * FROM @FunctionTable

/**************************************************/
--INSERT intO @estimate_rev_det_api_type(	[FNC_CODE], [EST_REV_COMM_PCT],	[EST_REV_QUANTITY], [EST_REV_RATE], [EST_REV_EXT_AMT])
--VALUES ('design', 10, 10, 1, 10)
--INSERT intO @estimate_rev_det_api_type(	[FNC_CODE], [EST_REV_COMM_PCT],	[EST_REV_QUANTITY], [EST_REV_RATE], [EST_REV_EXT_AMT])
--VALUES ('copies', 5, 10, NULL, 100)
--INSERT intO @estimate_rev_det_api_type(	[FNC_CODE], [EST_REV_COMM_PCT],	[EST_REV_QUANTITY], [EST_REV_RATE], [EST_REV_EXT_AMT])
--VALUES ('hand', 25, 10, 0, 1000)
--INSERT intO @estimate_rev_det_api_type(	[FNC_CODE], [EST_REV_COMM_PCT],	[EST_REV_QUANTITY], [EST_REV_RATE], [EST_REV_EXT_AMT])
--VALUES ('prod', 50, 10, 1000, 10000)
/**************************************************/

SELECT @fnc_cnt = COUNT(1) FROM @estimate_rev_det_api_type

/**************************************************/
--BEGIN TRANSACTION
/**************************************************/

BEGIN TRAN

BEGIN TRY

	IF @cmp_indentifier IS NULL
		SET @cmp_indentifier_n = 0
	ELSE
		SET @cmp_indentifier_n = CASE WHEN ISNUMERIC(@cmp_indentifier) = 1 THEN CAST(@cmp_indentifier AS Int) ELSE 0 END

	/* PJH 04/12/18 - Added this to only get the job level data */
	/* PJH 04/16/18 - Use Desc from Job/Comp */
	/* PJH 04/17/18 - New Est Component logic - Added MAX */

	/* PJH 09/29/20 - Allow create estimate by campaign */

	IF ISNULL(@job_number, 0) > 0 AND ISNULL(@job_component_nbr, 0) > 0 
	BEGIN

		SET @cmp_indentifier_n = 0

		SET @use_job_comp = 1

		SELECT TOP 1 @cl_code = MAX(jl.CL_CODE)
			,@div_code = MAX(jl.DIV_CODE)
			,@prd_code = MAX(jl.PRD_CODE)
			--,@job_process_contrl = jc.JOB_PROCESS_CONTRL
			,@estimate_nbr_existing = MAX(COALESCE(jc.ESTIMATE_NUMBER, 0))
			--,@est_component_nbr_existing = COALESCE(jc.EST_COMPONENT_NBR, 0)
			,@sc_code = MAX(jl.SC_CODE)
			,@job_number_existing = MAX(jl.JOB_NUMBER)
			--,@job_component_nbr_existing = jc.JOB_COMPONENT_NBR
			,@job_desc = MAX(jl.JOB_DESC)
		FROM JOB_COMPONENT jc
		INNER JOIN JOB_LOG jl ON jc.JOB_NUMBER = jl.JOB_NUMBER
		WHERE (
				jc.JOB_NUMBER = @job_number
				--AND JOB_COMPONENT_NBR = @job_component_nbr
				);

		/* PJH 04/12/18 - Added this to get the component level data */
		SELECT 
			 @job_process_contrl = jc.JOB_PROCESS_CONTRL
			,@est_component_nbr_existing = COALESCE(jc.EST_COMPONENT_NBR, 0)
			,@job_component_nbr_existing = jc.JOB_COMPONENT_NBR
			,@job_component_desc = jc.JOB_COMP_DESC
		FROM JOB_COMPONENT jc
		INNER JOIN JOB_LOG jl ON jc.JOB_NUMBER = jl.JOB_NUMBER
		WHERE (
				jc.JOB_NUMBER = @job_number
				AND JOB_COMPONENT_NBR = @job_component_nbr
				);

		SELECT @est_component_nbr_existing '@est_component_nbr_existing', @job_component_nbr_existing '@job_component_nbr_existing'

		IF @prd_code IS NOT NULL
			SELECT @prd_comm_pct = COALESCE(p.PRD_PROD_MARKUP,0), @prd_cont_pct = COALESCE(p.PRD_CONT_PCT,0),
						@cl_active = c.ACTIVE_FLAG, @div_active = d.ACTIVE_FLAG, @prd_active = p.ACTIVE_FLAG
				FROM CLIENT c, DIVISION d, PRODUCT p
				WHERE p.CL_CODE = @cl_code
				AND p.DIV_CODE = @div_code
				AND p.PRD_CODE = @prd_code
				AND c.CL_CODE = d.CL_CODE
				AND c.CL_CODE = p.CL_CODE
				AND d.CL_CODE = p.CL_CODE
				AND d.DIV_CODE = p.DIV_CODE;

		SELECT @cl_code '@cl_code', @div_code '@div_code', @prd_code '@prd_code', @prd_cont_pct '@prd_cont_pct'
	
		/* PJH 05/11/18 */
		SET @prd_comm_pct = COALESCE(@prd_comm_pct, 0)
		SET @prd_cont_pct = COALESCE(@prd_cont_pct, 0)

		/* Can't revise if not exists for the Job/Comp */
		IF @est_component_nbr_existing = 0
		BEGIN
			SET @create_revision = 0
		END

		SET @new_est = 0
		IF @estimate_nbr_existing = 0
			SET @new_est = 1

		SELECT JOB_NUMBER
		FROM JOB_COMPONENT
		WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr

		IF @@ROWCOUNT = 0
		BEGIN
			SET @error_msg_w = 'Invalid Job or Component Number.'

			GOTO ERROR_MSG
		END

		IF ISNUMERIC(@job_number) = 0
		BEGIN
			SET @error_msg_w = 'Invalid Job Number.'

			GOTO ERROR_MSG
		END

		IF ISNUMERIC(@job_component_nbr) = 0
		BEGIN
			SET @error_msg_w = 'Invalid Job Component Number.'

			GOTO ERROR_MSG
		END

		IF @job_component_nbr_existing > 0
			SET @job_component_nbr_existing = @job_component_nbr_existing
		ELSE BEGIN
			SET @error_msg_w = 'Invalid Job or Component Number.'

			GOTO ERROR_MSG
		END

		IF @job_process_contrl IN (6,12) 
		BEGIN
			SET @error_msg_w = 'Job/Component is closed.'

			GOTO ERROR_MSG
		END

	END /* Job & Comp Estimate */
	ELSE
	BEGIN /* Campaign Estimate */

		SET @use_job_comp = 0

		SELECT TOP 1 @cl_code = CL_CODE
			,@div_code = DIV_CODE
			,@prd_code = PRD_CODE
			,@estimate_nbr_existing = NULL
			,@cmp_name = CMP_NAME
		FROM CAMPAIGN
		WHERE (
				CMP_IDENTIFIER = @cmp_indentifier_n
				AND PRD_CODE IS NOT NULL
				);
		/* No matching campaign with C/D/P */
		IF @@ROWCOUNT = 0
			SET @cmp_indentifier_n = 0

		IF @cmp_indentifier_n = 0
		BEGIN
			SET @error_msg_w = 'Invalid Campaign.'

			GOTO ERROR_MSG
		END

		SET @sc_code = NULL

		SELECT @sc_code = SC_CODE FROM SALES_CLASS WHERE INACTIVE_FLAG = 0 AND SC_TYPE = 'P' AND SC_CODE = @sales_class;

		IF @sc_code IS NULL
		BEGIN
			SET @error_msg_w = 'Invalid Sales Class.'

			GOTO ERROR_MSG
		END

	END /* Campaing Estimate */

	IF @action = 'DEBUG'
		SET @DEBUG = 1
	ELSE
		SET @DEBUG = 0

	IF @user_id IS NULL
	BEGIN
		SET @error_msg_w = 'Invalid User ID.'

		GOTO ERROR_MSG
	END

	IF @use_job_comp = 1 
	BEGIN
		IF @fnc_cnt = 0
		BEGIN
			SET @error_msg_w = 'No Detail (Function) Data Provided.'

			GOTO ERROR_MSG
		END
	END

	SET @auto_approve_client = 0
	SET @auto_approve_int = 0

	IF @auto_approve IN (1,3)
		SET @auto_approve_client = 1

	IF @auto_approve IN (2,3)
		SET @auto_approve_int = 1

	IF @use_job_comp = 1
	BEGIN

		SELECT @cnt = COUNT(1) FROM ESTIMATE_APPROVAL 
			WHERE ESTIMATE_NUMBER = @estimate_nbr_existing AND EST_COMPONENT_NBR = @est_component_nbr_existing AND EST_QUOTE_NBR = 1 --AND EST_REVISION_NBR = @next_rev_nbr
			SET @cli_approval_exists = 0
		IF @cnt > 0 BEGIN
			SELECT 'Client approval exist for this Estimate!' 'Message'
			DELETE FROM ESTIMATE_APPROVAL WHERE ESTIMATE_NUMBER = @estimate_nbr_existing AND EST_COMPONENT_NBR = @est_component_nbr_existing AND EST_QUOTE_NBR = 1 --AND EST_REVISION_NBR = @cnt
			IF @auto_approve IN (1,3)
				SET @auto_approve_client = 1 
		END

		SELECT @cnt = COUNT(1) FROM ESTIMATE_INT_APPR 
			WHERE ESTIMATE_NUMBER = @estimate_nbr_existing AND EST_COMPONENT_NBR = @est_component_nbr_existing AND EST_QUOTE_NBR = 1 --AND EST_REVISION_NBR = @next_rev_nbr
			SET @int_approval_exists = 0
		IF @cnt > 0 BEGIN
			SELECT 'Internal approval exist for this Estimate!' 'Message'
			DELETE FROM ESTIMATE_INT_APPR WHERE ESTIMATE_NUMBER = @estimate_nbr_existing AND EST_COMPONENT_NBR = @est_component_nbr_existing AND EST_QUOTE_NBR = 1 --AND EST_REVISION_NBR = @cnt
			IF @auto_approve IN (2,3)
				SET @auto_approve_int = 1
		END

	END

	--IF @DEBUG = 1
	--	SELECT * FROM @estimate_rev_det_api_type

	SELECT @date_time_w = GETDATE()

	SET @eff_date = @date_time_w

	SET @ret_val = 0
	SET @ret_val_s = 'Success...'

	SET @row = 1

	SET @sc_inactive = 0
	SET @fnc_inactive = 0
	SET @tax_code_inactive = 0

	SELECT @est_nbr_new = NULL
		,@comp_nbr_new = NULL
		,@quote_nbr_new = NULL
		,@rev_nbr_new = NULL
		,@approval_new = NULL
		--,@est_desc = NULL
		,@new_est_rev = NULL

	IF @use_job_comp = 0
	BEGIN

		SELECT @prd_comm_pct = PRD_PROD_MARKUP FROM PRODUCT WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code

		BEGIN
			/* Adds new ESTIMATE_LOG & ESTIMATE_COMPONENT, Updates Job/Comp with Estimate reference */
			EXECUTE @RC = [dbo].[usp_wv_Estimating_AddNew_AddEstimate] @cl_code
				,@div_code
				,@prd_code
				,@sales_class
				,@prd_comm_pct
				,@user_id
				,@date_time_w
				,@cmp_name --@est_desc
				,@cmp_name --@est_comp_desc
				,0
				,0
				,NULL
				,@cmp_indentifier_n
				,@EST_NUM_NEW OUTPUT

		END

		SET @estimate_nbr_existing = @EST_NUM_NEW
		SET @est_nbr_new = 1

		IF @est_nbr_new = 1 BEGIN
			SELECT @sc_inactive = INACTIVE_FLAG
			FROM SALES_CLASS
			WHERE SC_CODE = @sc_code;

			IF @@ROWCOUNT > 0
			BEGIN
				IF @sc_inactive = 1
				BEGIN
					SET @error_msg_w = 'Inactive sales class code.'

					GOTO ERROR_MSG
				END
			END
			ELSE
			BEGIN
				SET @error_msg_w = 'Invalid sales class code.'

				GOTO ERROR_MSG
			END
		END

		SELECT
			@est_nbr_new = @estimate_nbr_existing,
			@comp_nbr_new = 1, --New Est/Comp
			@quote_nbr_new = 0,
			@rev_nbr_new = 0

		GOTO CAMPAIGN_ONLY

	END

	WHILE @row <= @fnc_cnt BEGIN

		/* PJH 04/16/18 - Use Desc from Job/Comp */
		--SET @est_desc = 'Job/Comp:' + CAST(@job_number AS varchar(10)) + '-' + CAST(@job_component_nbr AS varchar(4))

		--SELECT @fnc_cnt '@fnc_cnt'

		SELECT @fnc_inactive = NULL
			,@sc_inactive = NULL
			,@tax_code = NULL
			,@tax_code_inactive = NULL
			,@tax_resale = NULL
			,@comm_flag = NULL
			--,@prd_active = NULL
			--,@div_active = NULL
			--,@cl_active = NULL
			,@billing_rate = NULL
			,@rate_level = NULL
			,@tax_level = NULL
			,@nobill_level = NULL
			,@billing_comm_pct = NULL
			,@comm_level = NULL
			,@tax_comm = NULL
			,@tax_comm_only = NULL
			,@tax_comm_flags_level = NULL
			,@fee_time_flag = NULL
			,@fee_time_level = NULL
			,@est_rev_sup_by_cde = NULL
			,@est_rev_sup_by_nte = NULL
			--,@prd_comm_pct = NULL
			--,@est_rev_cont_pct = NULL
			,@est_comm_pct = NULL
			,@est_rev_quantity = NULL
			,@est_rev_rate = NULL
			,@est_rev_ext_amt = NULL
			,@est_fnc_comment = NULL
			,@comm_amt = NULL
			,@est_rev_ext_amt_cont = NULL
			,@incl_cpu = NULL
			--,@user_id = NULL
			,@fnc_type = NULL
			,@fnc_cpm_flag = NULL
			,@state_tax_pct = NULL
			,@county_tax_pct = NULL
			,@city_tax_pct = NULL
			,@est_tax_flag = NULL
			,@nobill_flag = NULL
			,@nonresale_tax_amt = NULL
			,@state_tax_amt = NULL
			,@county_tax_amt = NULL
			,@city_tax_amt = NULL
			,@comm_amt_cont = NULL
			,@state_tax_amt_cont = NULL
			,@county_tax_amt_cont = NULL
			,@city_tax_amt_cont = NULL
			,@nonresale_tax_amt_cont = NULL
			,@line_total_amt = NULL
			,@fee_time  = NULL
			,@tax_code_inactive = NULL
			,@city_tax_pct = 0
			,@county_tax_pct = 0
			,@state_tax_pct = 0
			,@tax_resale= 0

		/* Use Job or Product level for the estimate comm pct if they exist */
		/* PJH 04/19/18 - Use billing heiarchy */
		--IF COALESCE(@job_comm_pct, 0 ) = 0
		--	IF COALESCE(@prd_comm_pct, 0) > 0
		--		SET @est_comm_pct = @prd_comm_pct
		--ELSE
		--	SET @est_comm_pct = @job_comm_pct

		IF @estimate_nbr_existing = 0
		BEGIN

			/* Adds new ESTIMATE_LOG & ESTIMATE_COMPONENT, Updates Job/Comp with Estimate reference */
			EXECUTE @RC = [dbo].[usp_wv_Estimating_AddNew_AddEstimate] @cl_code
				,@div_code
				,@prd_code
				,@sc_code
				,@est_comm_pct
				,@user_id
				,@date_time_w
				,@job_desc --@est_desc
				,@job_desc --@est_desc
				,@job_number
				,@job_component_nbr
				,NULL
				,NULL
				,@EST_NUM_NEW OUTPUT

			SET @estimate_nbr_existing = @EST_NUM_NEW
			SET @est_nbr_new = 1
		END

		IF @est_nbr_new = 1 BEGIN
			SELECT @sc_inactive = INACTIVE_FLAG
			FROM SALES_CLASS
			WHERE SC_CODE = @sc_code;

			IF @@ROWCOUNT > 0
			BEGIN
				IF @sc_inactive = 1
				BEGIN
					SET @error_msg_w = 'Inactive sales class code.'

					GOTO ERROR_MSG
				END
			END
			ELSE
			BEGIN
				SET @error_msg_w = 'Invalid sales class code.'

				GOTO ERROR_MSG
			END
		END

		IF @auto_approve NOT IN (0,1,2,3)
		BEGIN
			SET @error_msg_w = 'Invalid auto approval code. Must be 0, 1, 2, or 3.'

			GOTO ERROR_MSG
		END

		/*
		@CDP_CONTACT_ID, @CMP_IDENTIFIER
		*/
		/* PJH 04/12/18 - Add Est Comp as needed */
		IF @est_nbr_new IS NULL AND @est_component_nbr_existing = 0
		BEGIN
			EXECUTE @RC = [dbo].[usp_wv_Estimating_AddNew_AddEstimateComponent] 
				 @estimate_nbr_existing
				,@job_component_desc --@est_desc
				,NULL
				,@EST_COMPONENT_NBR OUTPUT

			SET @est_component_nbr_existing = @EST_COMPONENT_NBR
			SET @comp_nbr_new = 1
			SET @new_est_rev = 1 /* PJH 04/12/18 - Added */

			UPDATE JOB_COMPONENT
			SET ESTIMATE_NUMBER = @estimate_nbr_existing, EST_COMPONENT_NBR = @est_component_nbr_existing
			WHERE JOB_NUMBER = @job_number
					AND JOB_COMPONENT_NBR = @job_component_nbr

		END 

		/* Get function level data from table parameter */
		SELECT @fnc_code = FNC_CODE
			,@est_rev_comm_pct = EST_REV_COMM_PCT
			,@est_rev_comm_amt = EST_REV_COMM_AMT
			,@est_rev_quantity = EST_REV_QUANTITY
			,@est_rev_rate = EST_REV_RATE
			,@est_rev_ext_amt = EST_REV_EXT_AMT
			,@est_seq_nbr = SEQ_NBR --ID /* <<< SEQ_NBR to update or 0 to use FNC_CODE only >>> */
			,@est_fnc_comment = EST_FNC_COMMENT
		FROM @estimate_rev_det_api_type
		WHERE ID = @row

		IF @DEBUG = 1
			SELECT @fnc_code '@fnc_code', @est_rev_comm_pct '@est_rev_comm_pct', @est_rev_comm_amt '@est_rev_comm_amt', @est_rev_quantity '@est_rev_quantity', @est_rev_rate '@est_rev_rate', 
						@est_rev_ext_amt 'est_rev_ext_amt', @est_fnc_comment '@est_fnc_comment', @est_seq_nbr '@est_seq_nbr'
	
		SET @row = @row + 1

		SET @cnt = 0

		/* Check existing row */
		SELECT @cnt = COUNT(FNC_CODE)
		FROM ESTIMATE_REV_DET A 
		WHERE 	A.ESTIMATE_NUMBER = @estimate_nbr_existing
			AND A.EST_COMPONENT_NBR = @est_component_nbr_existing
			AND A.FNC_CODE = @fnc_code
			/* PJH 04/19/18 - Added ability to update by SEQ_NBR if provided, else update row with max SEQ_NBR with the given FNC_CODE */
			AND (A.SEQ_NBR = @est_seq_nbr OR @est_seq_nbr = 0);

		IF @DEBUG = 1
			SELECT @estimate_nbr_existing '**@estimate_nbr_existing', @est_component_nbr_existing '@est_component_nbr_existing', 
						@fnc_code '@fnc_code', @est_seq_nbr '@est_seq_nbr', @cnt '@cnt'

		IF @cnt = 0
			SET @fnc_exists = 0
		ELSE
			SET @fnc_exists = 1

		IF @fnc_exists = 0
			IF @est_seq_nbr > 0
			BEGIN
				SET @error_msg_w = 'Invalid function [ID]. The function [ID] is only valid when updating an exisitng function detail row. Please use -1 for the [ID] to force add (even if the function already exists) or 0 (zero) to add a unique function or update the last entered row containing the function.'

				GOTO ERROR_MSG
			END
		
		/* Get function defaults if new */
		BEGIN
			IF @fnc_exists = 0	BEGIN
				SELECT @fnc_type = FNC_TYPE
					,@fnc_inactive = FNC_INACTIVE
					,@fnc_cpm_flag = FNC_CPM_FLAG
				FROM FUNCTIONS
				WHERE FNC_CODE = @fnc_code;

				IF @@ROWCOUNT > 0
				BEGIN
					IF @fnc_inactive = 1
					BEGIN
						SET @error_msg_w = 'Inactive function code.'

						GOTO ERROR_MSG
					END
				END
				ELSE
				BEGIN
					SET @error_msg_w = 'Invalid function code.'

					GOTO ERROR_MSG
				END
			END
		END

		--PJH 12/18/17 - Changed to always calc amt &/or rate based on the following
		SET @est_rev_ext_amt = COALESCE(@est_rev_ext_amt, 0)
		SET @est_rev_rate = COALESCE(@est_rev_rate, 0)
		SET @est_rev_quantity = COALESCE(@est_rev_quantity, 0)

		--PJH 07/31/18 - Allow RATE, QTY, AMT to be anything sent - Per EC
		--IF @est_rev_rate <> 0 AND @est_rev_quantity <> 0
		--	SET @est_rev_ext_amt = @est_rev_rate * @est_rev_quantity
		--ELSE
		--	IF @est_rev_ext_amt <> 0
		--		IF @est_rev_quantity = 0
		--			SET @est_rev_rate = NULL
		--		ELSE
		--			SET @est_rev_rate = @est_rev_ext_amt / @est_rev_quantity
		--	ELSE
		--		SET @est_rev_rate = 0

		--IF @action = 'DEBUG'
		--	SELECT @est_seq_nbr, @fnc_code, @est_rev_comm_pct, @est_rev_quantity, @est_rev_rate, @est_rev_ext_amt

		--Get Function settings from Rate Hierarchy
		IF @fnc_exists = 0 BEGIN
			EXECUTE @RC = [dbo].[sp_get_billing_rates] @emp_code
				,@eff_date
				,@fnc_code
				,@cl_code
				,@div_code
				,@prd_code
				,@sc_code
				,@fnc_type
				,@job_number
				,@job_component_nbr
				,NULL
				,@billing_rate OUTPUT /*Not Used*/
				,@rate_level OUTPUT /*Not Used*/
				,@tax_code OUTPUT
				,@tax_level OUTPUT /*Not Used*/
				,@nobill_flag OUTPUT
				,@nobill_level OUTPUT /*Not Used*/
				,@billing_comm_pct OUTPUT
				,@comm_level OUTPUT /*Not Used*/
				,@tax_comm OUTPUT
				,@tax_comm_only OUTPUT
				,@tax_comm_flags_level OUTPUT  /*Not Used*/
				,@fee_time_flag OUTPUT  /*??*/
				,@fee_time_level OUTPUT;  /*Not Used*/
			/* PJH 04/19/18 - Always use @billing_comm_pct */
			IF @rate_level > 0 --AND COALESCE(@billing_comm_pct, 0) > 0
			BEGIN
				SET @est_comm_pct = @billing_comm_pct
			END
		END

		IF @fnc_exists = 0 BEGIN
			SELECT @tax_resale = TAX_RESALE
				,@tax_code_inactive = INACTIVE_FLAG
				,@city_tax_pct = COALESCE(TAX_CITY_PERCENT, 0)
				,@county_tax_pct = COALESCE(TAX_COUNTY_PERCENT, 0)
				,@state_tax_pct = COALESCE(TAX_STATE_PERCENT, 0)
				,@tax_resale = COALESCE(TAX_RESALE, 0)
			FROM SALES_TAX
			WHERE TAX_CODE = @tax_code;

			IF @@ROWCOUNT > 0
			BEGIN
				IF @tax_code_inactive = 1
				BEGIN
					SET @error_msg_w = 'Inactive tax code.'

					GOTO ERROR_MSG
				END
			END
			ELSE IF @tax_code IS NOT NULL
			BEGIN
				SET @error_msg_w = 'Invalid tax code.'

				GOTO ERROR_MSG
			END

			--SELECT @emp_cost_rate = COALESCE(EMP_COST_RATE, 0)
			--FROM EMPLOYEE
			--WHERE EMP_CODE = @emp_code;

			--SELECT @est_rev_cont_pct = COALESCE(PRD_CONT_PCT, 0)
			--FROM PRODUCT
			--WHERE PRD_CODE = @prd_code;

			--SELECT @tax_jobs_flag = FLAG_TAX_JOBS
			--FROM AGENCY;

			SET @est_rev_cont_pct = @prd_cont_pct

		END
		ELSE /* Function row exists - use current flags, etc. */
		BEGIN
			/* PJH 04/19/18 - Allow for user passed seq */
			IF @est_seq_nbr = 0 BEGIN /* Use max seq for given function */
				SELECT @fnc_type = (EST_FNC_TYPE)
					,@fnc_cpm_flag = (EST_CPM_FLAG)
					,@fnc_inactive = 0
					,@est_comm_pct = (COALESCE(EST_REV_COMM_PCT,0))
					,@est_rev_cont_pct = (COALESCE(EST_REV_CONT_PCT,0))
					,@tax_resale = (TAX_RESALE)
					,@tax_code_inactive = 0
					,@tax_code = (TAX_CODE)
					,@city_tax_pct = (COALESCE(TAX_CITY_PCT, 0))
					,@county_tax_pct = (COALESCE(TAX_COUNTY_PCT, 0))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
					,@state_tax_pct = (COALESCE(TAX_STATE_PCT, 0))
					,@tax_resale = (COALESCE(TAX_RESALE, 0))
					,@tax_comm = (COALESCE(TAX_COMM,0))
					,@tax_comm_only = (COALESCE(TAX_COMM_ONLY, 0))
					,@est_rev_sup_by_cde = (EST_REV_SUP_BY_CDE)
					,@est_rev_sup_by_nte = (EST_REV_SUP_BY_NTE)
					,@est_fnc_comment = COALESCE(@est_fnc_comment, EST_FNC_COMMENT) /* Use user comment if provided */
					,@incl_cpu = (INCL_CPU)
					,@fee_time = (FEE_TIME)
					,@comm_flag = (EST_COMM_FLAG)
					,@nobill_flag = (EST_NONBILL_FLAG)
					,@next_seq_nbr = (B.SEQ_NBR)
				FROM ESTIMATE_REV_DET  A 
				JOIN (SELECT A.ESTIMATE_NUMBER, A.EST_COMPONENT_NBR, A.EST_QUOTE_NBR, A.EST_REV_NBR, MAX(SEQ_NBR) SEQ_NBR
							FROM ESTIMATE_REV_DET  A 
						JOIN (SELECT ESTIMATE_NUMBER, EST_COMPONENT_NBR, MIN(EST_QUOTE_NBR) EST_QUOTE_NBR, MAX(EST_REV_NBR) EST_REV_NBR
									FROM ESTIMATE_REV_DET
									WHERE 	ESTIMATE_NUMBER = @estimate_nbr_existing
										AND EST_COMPONENT_NBR = @est_component_nbr_existing
									GROUP BY ESTIMATE_NUMBER, EST_COMPONENT_NBR) B 
						ON A.ESTIMATE_NUMBER = B.ESTIMATE_NUMBER 
							AND A.EST_COMPONENT_NBR = B.EST_COMPONENT_NBR
							AND A.EST_QUOTE_NBR = B.EST_QUOTE_NBR 
							AND A.EST_REV_NBR = B.EST_REV_NBR
							AND FNC_CODE = @fnc_code
							GROUP BY A.ESTIMATE_NUMBER, A.EST_COMPONENT_NBR, A.EST_QUOTE_NBR, A.EST_REV_NBR) B
				ON A.ESTIMATE_NUMBER = B.ESTIMATE_NUMBER 
						AND A.EST_COMPONENT_NBR = B.EST_COMPONENT_NBR
						AND A.EST_QUOTE_NBR = B.EST_QUOTE_NBR 
						AND A.EST_REV_NBR = B.EST_REV_NBR
						AND A.SEQ_NBR = B.SEQ_NBR
						AND FNC_CODE = @fnc_code
					WHERE 	A.ESTIMATE_NUMBER = @estimate_nbr_existing
						AND A.EST_COMPONENT_NBR = @est_component_nbr_existing
						AND FNC_CODE = @fnc_code;
			END
			/* PJH 05/11/18 - Use the user provided seq & function */
			ELSE BEGIN
				SELECT @fnc_type = (EST_FNC_TYPE)
					,@fnc_cpm_flag = (EST_CPM_FLAG)
					,@fnc_inactive = 0
					,@est_comm_pct = (COALESCE(EST_REV_COMM_PCT,0))
					,@est_rev_cont_pct = (COALESCE(EST_REV_CONT_PCT,0))
					,@tax_resale = (TAX_RESALE)
					,@tax_code_inactive = 0
					,@tax_code = (TAX_CODE)
					,@city_tax_pct = (COALESCE(TAX_CITY_PCT, 0))
					,@county_tax_pct = (COALESCE(TAX_COUNTY_PCT, 0))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
					,@state_tax_pct = (COALESCE(TAX_STATE_PCT, 0))
					,@tax_resale = (COALESCE(TAX_RESALE, 0))
					,@tax_comm = (COALESCE(TAX_COMM,0))
					,@tax_comm_only = (COALESCE(TAX_COMM_ONLY, 0))
					,@est_rev_sup_by_cde = (EST_REV_SUP_BY_CDE)
					,@est_rev_sup_by_nte = (EST_REV_SUP_BY_NTE)
					,@est_fnc_comment = COALESCE(@est_fnc_comment, EST_FNC_COMMENT) /* Use user comment if provided */
					,@incl_cpu = (INCL_CPU)
					,@fee_time = (FEE_TIME)
					,@comm_flag = (EST_COMM_FLAG)
					,@nobill_flag = (EST_NONBILL_FLAG)
					,@next_seq_nbr = (A.SEQ_NBR)
				FROM ESTIMATE_REV_DET  A 
				JOIN (SELECT A.ESTIMATE_NUMBER, A.EST_COMPONENT_NBR, A.EST_QUOTE_NBR, A.EST_REV_NBR /*, SEQ_NBR */
							FROM ESTIMATE_REV_DET  A 
						JOIN (SELECT ESTIMATE_NUMBER, EST_COMPONENT_NBR, MIN(EST_QUOTE_NBR) EST_QUOTE_NBR, MAX(EST_REV_NBR) EST_REV_NBR
									FROM ESTIMATE_REV_DET
									WHERE 	ESTIMATE_NUMBER = @estimate_nbr_existing
										AND EST_COMPONENT_NBR = @est_component_nbr_existing
									GROUP BY ESTIMATE_NUMBER, EST_COMPONENT_NBR) B 
						ON A.ESTIMATE_NUMBER = B.ESTIMATE_NUMBER 
							AND A.EST_COMPONENT_NBR = B.EST_COMPONENT_NBR
							AND A.EST_QUOTE_NBR = B.EST_QUOTE_NBR 
							AND A.EST_REV_NBR = B.EST_REV_NBR
							AND A.FNC_CODE = @fnc_code
							AND A.SEQ_NBR = @est_seq_nbr
							GROUP BY A.ESTIMATE_NUMBER, A.EST_COMPONENT_NBR, A.EST_QUOTE_NBR, A.EST_REV_NBR) B
				ON A.ESTIMATE_NUMBER = B.ESTIMATE_NUMBER 
						AND A.EST_COMPONENT_NBR = B.EST_COMPONENT_NBR
						AND A.EST_QUOTE_NBR = B.EST_QUOTE_NBR 
						AND A.EST_REV_NBR = B.EST_REV_NBR
						--AND A.SEQ_NBR = B.SEQ_NBR
						AND A.FNC_CODE = @fnc_code
						AND A.SEQ_NBR = @est_seq_nbr
					WHERE 	A.ESTIMATE_NUMBER = @estimate_nbr_existing
						AND A.EST_COMPONENT_NBR = @est_component_nbr_existing
						AND FNC_CODE = @fnc_code
						AND (A.SEQ_NBR = @est_seq_nbr);
			END
		END
		
		/* PJH 05/11/18 */
		SET @est_comm_pct = COALESCE(@est_comm_pct, 0)
		SET @est_rev_cont_pct = COALESCE(@est_rev_cont_pct, 0)

		/* This is not needed for the API. We will use there values as they are sent as long as Rate * Qty = Amt */
		--IF @fnc_cpm_flag = 1 BEGIN
		--	SET @est_rev_ext_amt = @est_rev_ext_amt / 1000
		--END

		IF (@fnc_type = 'E' OR @fnc_type = 'I')
			IF @tax_code IS NOT NULL
				SET @tax_resale = 1

		IF @tax_code IS NOT NULL
			SET @est_tax_flag = 1
		ELSE
			SET @est_tax_flag = 0

		/* Use Markup settings from Rate Hierarchy if not provided by API (0 or NULL?) */
		/* PJH 04/19/18 - Override @billing_comm_pct if provided via API */
		IF ISNUMERIC(@est_rev_comm_pct) = 1 AND @est_rev_comm_pct > 0 /* User API value? */
			SET @est_comm_pct = @est_rev_comm_pct 

		SET @est_comm_pct = COALESCE(@est_comm_pct, 0)
		SET @create_revision = COALESCE(@create_revision, 0)
		--SET @auto_approve = COALESCE(@auto_approve, 0)

		/* PJH  07/10/18 - added comm amt override */
		SET @est_rev_comm_amt = COALESCE(@est_rev_comm_amt, 0)
		SET @comm_flag = 0

		IF @est_rev_comm_amt > 0
		BEGIN
			--Calculate Commission, Tax, etc.
			SET @comm_amt = @est_rev_comm_amt
			SET @comm_flag = 1
		END
		ELSE
		BEGIN
			--Calculate Commission, Tax, etc.
			IF @est_comm_pct > 0
			BEGIN
				SET @comm_amt = ROUND((@est_rev_ext_amt) * (@est_comm_pct / 100), 2)
				SET @comm_flag = 1
			END
		END

		IF @tax_comm_only = 1
		BEGIN
			SET @state_tax_amt = ROUND((@comm_amt) * (@state_tax_pct / 100), 2)
			SET @county_tax_amt = ROUND((@comm_amt) * (@county_tax_pct / 100), 2)
			SET @city_tax_amt = ROUND((@comm_amt) * (@city_tax_pct / 100), 2)
		END
		ELSE
		BEGIN
			IF @tax_resale = 1
			BEGIN /* Resale Tax */
				IF @tax_comm = 1
				BEGIN
					SET @state_tax_amt = ROUND((@est_rev_ext_amt + @comm_amt) * (@state_tax_pct / 100), 2)
					SET @county_tax_amt = ROUND((@est_rev_ext_amt + @comm_amt) * (@county_tax_pct / 100), 2)
					SET @city_tax_amt = ROUND((@est_rev_ext_amt + @comm_amt) * (@city_tax_pct / 100), 2)
				END
				ELSE
				BEGIN
					SET @state_tax_amt = ROUND((@est_rev_ext_amt) * (@state_tax_pct / 100), 2)
					SET @county_tax_amt = ROUND((@est_rev_ext_amt) * (@county_tax_pct / 100), 2)
					SET @city_tax_amt = ROUND((@est_rev_ext_amt) * (@city_tax_pct / 100), 2)
				END
			END
			ELSE
			BEGIN /* Vendor Tax */
				IF @tax_comm = 1
				BEGIN
					SET @state_tax_amt = ROUND((@comm_amt) * (@state_tax_pct / 100), 2)
					SET @county_tax_amt = ROUND((@comm_amt) * (@county_tax_pct / 100), 2)
					SET @city_tax_amt = ROUND((@comm_amt) * (@city_tax_pct / 100), 2)
				END

				SET @nonresale_tax_amt = ROUND(@est_rev_ext_amt * (@state_tax_pct / 100), 2) + ROUND(@est_rev_ext_amt * (@county_tax_pct / 100), 2) + ROUND(@est_rev_ext_amt * (@city_tax_pct / 100), 2)
			END
		END

		SET @est_rev_ext_amt = COALESCE(@est_rev_ext_amt, 0)
		SET @comm_amt = COALESCE(@comm_amt,0)
		SET @state_tax_amt = COALESCE(@state_tax_amt, 0)
		SET @county_tax_amt = COALESCE(@county_tax_amt, 0)
		SET @city_tax_amt = COALESCE(@city_tax_amt, 0)
		SET @nonresale_tax_amt = COALESCE(@nonresale_tax_amt, 0)
		SET @line_total_amt = @est_rev_ext_amt + @comm_amt + @nonresale_tax_amt + @state_tax_amt + @county_tax_amt + @city_tax_amt

		--Contingency Calculation
		IF @est_rev_cont_pct > 0
		BEGIN --<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			SET @est_rev_ext_amt_cont = ROUND(@est_rev_ext_amt * (@est_rev_cont_pct  / 100), 2)

			IF @est_rev_quantity > 0
			BEGIN
				SET @est_rev_rate_cont = ROUND(@est_rev_ext_amt_cont / @est_rev_quantity, 2)
			END
			ELSE
			BEGIN
				SET @est_rev_rate_cont = @est_rev_ext_amt_cont
			END

			IF @est_comm_pct > 0
			BEGIN
				SET @comm_amt_cont = ROUND((@est_rev_ext_amt_cont) * (@est_comm_pct / 100), 2)
			END

			IF @tax_comm_only = 1
			BEGIN
				SET @state_tax_amt_cont = ROUND((@comm_amt_cont) * (@state_tax_pct / 100), 2)
				SET @county_tax_amt_cont = ROUND((@comm_amt_cont) * (@county_tax_pct / 100), 2)
				SET @city_tax_amt_cont = ROUND((@comm_amt_cont) * (@city_tax_pct / 100), 2)
			END
			ELSE
			BEGIN
				IF @tax_resale = 1
				BEGIN /* Resale Tax */
					IF @tax_comm = 1
					BEGIN
						SET @state_tax_amt_cont = ROUND((@est_rev_ext_amt_cont + @comm_amt_cont) * (@state_tax_pct / 100), 2)
						SET @county_tax_amt_cont = ROUND((@est_rev_ext_amt_cont + @comm_amt_cont) * (@county_tax_pct / 100), 2)
						SET @city_tax_amt_cont = ROUND((@est_rev_ext_amt_cont + @comm_amt_cont) * (@city_tax_pct / 100), 2)
					END
					ELSE
					BEGIN
						SET @state_tax_amt_cont = ROUND((@est_rev_ext_amt_cont) * (@state_tax_pct / 100), 2)
						SET @county_tax_amt_cont = ROUND((@est_rev_ext_amt_cont) * (@county_tax_pct / 100), 2)
						SET @city_tax_amt_cont = ROUND((@est_rev_ext_amt_cont) * (@city_tax_pct / 100), 2)
					END
				END
				ELSE
				BEGIN /* Vendor Tax */
					IF @tax_comm = 1
					BEGIN
						SET @state_tax_amt_cont = ROUND((@comm_amt_cont) * (@state_tax_pct / 100), 2)
						SET @county_tax_amt_cont = ROUND((@comm_amt_cont) * (@county_tax_pct / 100), 2)
						SET @city_tax_amt_cont = ROUND((@comm_amt_cont) * (@city_tax_pct / 100), 2)
					END

					SET @nonresale_tax_amt_cont = ROUND(@est_rev_ext_amt_cont * (@state_tax_pct / 100), 2) + ROUND(@est_rev_ext_amt_cont * (@county_tax_pct / 100), 2) + ROUND(@est_rev_ext_amt_cont * (@city_tax_pct / 100), 2)
				END
			END
		END

		SET @est_rev_ext_amt_cont = COALESCE(@est_rev_ext_amt_cont, 0)
		SET @comm_amt_cont = COALESCE(@comm_amt_cont, 0)
		SET @state_tax_amt_cont = COALESCE(@state_tax_amt_cont, 0)
		SET @county_tax_amt_cont = COALESCE(@county_tax_amt_cont, 0)
		SET @city_tax_amt_cont = COALESCE(@city_tax_amt_cont, 0)
		SET @nonresale_tax_amt_cont = COALESCE(@nonresale_tax_amt_cont, 0)
		SET @line_total_amt_cont = @est_rev_ext_amt_cont + @comm_amt_cont + @nonresale_tax_amt_cont + @state_tax_amt_cont + @county_tax_amt_cont + @city_tax_amt_cont

		IF @est_component_nbr_existing = 0
			SELECT @est_component_nbr_existing = MAX(EST_COMPONENT_NBR)
			FROM [ESTIMATE_COMPONENT]
			WHERE ESTIMATE_NUMBER = @estimate_nbr_existing;

		SELECT @next_quote_nbr = MIN(EST_QUOTE_NBR)
		FROM ESTIMATE_QUOTE
		WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
			AND EST_COMPONENT_NBR = @est_component_nbr_existing;

		SELECT @next_rev_nbr = COALESCE(MAX(EST_REV_NBR), 0)
		FROM ESTIMATE_REV
		WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
			AND EST_COMPONENT_NBR = @est_component_nbr_existing
			AND EST_QUOTE_NBR = @next_quote_nbr;

		SELECT @next_rev_nbr_rev_dtl = COALESCE(MAX(EST_REV_NBR), 0)
		FROM ESTIMATE_REV_DET
		WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
			AND EST_COMPONENT_NBR = @est_component_nbr_existing
			AND EST_QUOTE_NBR = @next_quote_nbr;

		IF @next_rev_nbr <> @next_rev_nbr_rev_dtl
		BEGIN
			SET @error_msg_w = 'Mismatched ESTIMATE_REV & ESTIMATE_REV_DET revisions.'

			GOTO ERROR_MSG
		END

		IF @create_revision = 1
		BEGIN
			/* Get next rev nbr */
			SET @next_rev_nbr = ISNULL(@next_rev_nbr, - 1) + 1
		END

		IF @next_quote_nbr IS NULL BEGIN 
			SET @next_rev_nbr = 0
			SET @next_quote_nbr = 1
			SET @create_revision = 0
			EXECUTE @RC = [dbo].[usp_wv_Estimating_AddNew_AddQuote] 
				@estimate_nbr_existing
				,@est_component_nbr_existing
				,@next_quote_nbr
				,@next_rev_nbr
		END

		/* See if Revision exists */
		BEGIN
			SELECT @cnt = COUNT(1)
			FROM ESTIMATE_REV
			WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
				AND EST_COMPONENT_NBR = @est_component_nbr_existing
				AND EST_QUOTE_NBR = @next_quote_nbr
				AND EST_REV_NBR = @next_rev_nbr;
		END

		/* PHJ 04/12/18 - Only create revision if @create_revision = 1 */
		IF @create_revision = 1 BEGIN--OR @cnt = 0 
			EXECUTE @RC = [dbo].[usp_wv_Estimating_AddNewRevision] 
				@estimate_nbr_existing
				,@est_component_nbr_existing
				,@next_quote_nbr
				,@next_rev_nbr
				,NULL
				,NULL
				,NULL
				,NULL

			SET @new_est_rev = 1 /* PJH 04/12/18 - Added */
		END

		IF @create_revision = 1 
		EXECUTE @RC = [dbo].[usp_wv_Estimating_Quote_Revise] 
				@estimate_nbr_existing
				,@est_component_nbr_existing
				,@next_quote_nbr
				,@next_rev_nbr

		/* Get next seq nbr for new function */
		IF @fnc_exists = 0 BEGIN
			SELECT @next_seq_nbr = ISNULL(MAX(SEQ_NBR), - 1) + 1
			FROM ESTIMATE_REV_DET
			WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
				AND EST_COMPONENT_NBR = @est_component_nbr_existing
				AND EST_QUOTE_NBR = @next_quote_nbr
				AND EST_REV_NBR = @next_rev_nbr;
		END

		IF @next_seq_nbr = 0
		BEGIN
			SET @next_seq_nbr = 1
		END

		--IF @create_revision = 1

		--SELECT @fnc_code '@fnc_code', @est_rev_comm_pct '@est_rev_comm_pct', @est_rev_quantity '@est_rev_quantity', @est_rev_rate '@est_rev_rate', 
		--	@est_rev_ext_amt 'est_rev_ext_amt', @est_fnc_comment '@est_fnc_comment'

		IF @fnc_exists = 0 BEGIN

			SELECT @fnc_exists 'Fnc Exists'

			IF @single_func_seq = 1
				SET @single_func_seq = @next_seq_nbr

			EXECUTE @RC = [dbo].[usp_wv_Estimating_AddNew_AddFunction] 
				@estimate_nbr_existing
				,@est_component_nbr_existing
				,@next_quote_nbr
				,@next_rev_nbr
				,@next_seq_nbr
				,@fnc_code
				,@est_comm_pct
				,@est_rev_cont_pct
				,@est_rev_quantity
				,@est_rev_rate
				,@est_rev_sup_by_cde
				,@est_rev_sup_by_nte
				,@est_rev_ext_amt
				,@tax_code
				,@est_fnc_comment
				,@comm_amt
				,@est_rev_ext_amt_cont
				,@line_total_amt
				,1 --@incl_cpu
				,@user_id
				,@fnc_type
				,@fnc_cpm_flag
				,@state_tax_pct
				,@county_tax_pct
				,@city_tax_pct
				,@tax_comm
				,@tax_comm_only
				,@tax_resale
				,@comm_flag
				,@est_tax_flag
				,@nobill_flag
				,@nonresale_tax_amt
				,@state_tax_amt
				,@county_tax_amt
				,@city_tax_amt
				,@comm_amt_cont
				,@state_tax_amt_cont
				,@county_tax_amt_cont
				,@city_tax_amt_cont
				,@nonresale_tax_amt_cont
				,@line_total_amt_cont
				,@fee_time_flag -- @fee_time 
				,NULL --@EMPLOYEE_TITLE_ID
		END
		ELSE BEGIN

			SELECT @fnc_exists 'Fnc Exists', @est_seq_nbr '@est_seq_nbr'

			/* PJH 04/19/18 - Added ability to update by SEQ_NBR if provided, else update row with max SEQ_NBR with the given FNC_CODE */
			IF @est_seq_nbr > 0 
				SET @next_seq_nbr = @est_seq_nbr

			EXECUTE @RC = [dbo].[usp_wv_Estimating_Update_Function] 
				@estimate_nbr_existing
				,@est_component_nbr_existing
				,@next_quote_nbr
				,@next_rev_nbr
				,@next_seq_nbr
				,@fnc_code
				,@est_comm_pct
				,@est_rev_cont_pct
				,@est_rev_quantity
				,@est_rev_rate
				,@est_rev_sup_by_cde
				,@est_rev_sup_by_nte
				,@est_rev_ext_amt
				,@tax_code
				,@est_fnc_comment
				,@comm_amt
				,@est_rev_ext_amt_cont
				,@line_total_amt
				,@incl_cpu
				,@user_id
				,@fnc_type
				,@fnc_cpm_flag
				,@state_tax_pct
				,@county_tax_pct
				,@city_tax_pct
				,@tax_comm
				,@tax_comm_only
				,@tax_resale
				,@comm_flag
				,@est_tax_flag
				,@nobill_flag
				,@nonresale_tax_amt
				,@state_tax_amt
				,@county_tax_amt
				,@city_tax_amt
				,@comm_amt_cont
				,@state_tax_amt_cont
				,@county_tax_amt_cont
				,@city_tax_amt_cont
				,@nonresale_tax_amt_cont
				,@line_total_amt_cont
				,@fee_time
		END

		SELECT @estimate_nbr_existing '@estimate_nbr_existing'
					,@est_component_nbr_existing '@est_component_nbr_existing'
					,@next_quote_nbr '@next_quote_nbr'
					,@next_rev_nbr '@next_rev_nbr'
					,@next_seq_nbr '@next_seq_nbr'
					,@fnc_code '@fnc_code'
					,@est_comm_pct '@est_comm_pct'
					,@est_rev_cont_pct '@est_rev_cont_pct'
					,@est_rev_quantity '@est_rev_quantity'
					,@est_rev_rate '@est_rev_rate'
					,@est_rev_ext_amt '@est_rev_ext_amt'
					,@TAX_CODE '@TAX_CODE'
		
		/* Ony one revision per call */
		IF @create_revision = 1 BEGIN
			SET @create_revision = 0
		END

	END /* While Loop */

	SELECT
		@est_nbr_new = @estimate_nbr_existing,
		@comp_nbr_new = @est_component_nbr_existing,
		@quote_nbr_new = @next_quote_nbr,
		@rev_nbr_new = @next_rev_nbr

	/* PJH 04/12/18 - Added "@create_revision = 1" */
	/* PJH 04/16/18 - (removed) "@create_revision = 1" */
	IF @auto_approve_int = 1 BEGIN
		EXECUTE @RC = [dbo].[usp_wv_Estimating_AddInternalApproval] 
			@job_number
			,@job_component_nbr
			,@estimate_nbr_existing
			,@est_component_nbr_existing
			,@next_quote_nbr
			,@next_rev_nbr
			,@user_id --@EST_APPR_BY
			,@eff_date --@EST_APPR_DATE
			,@user_id --@CREATE_USER
			,@eff_date --@CREATE_DATE
			,'Auto approved via API' --@APPR_NOTES	
	END	

	/* PJH 04/12/18 - Added "@create_revision = 1" */
	/* PJH 04/16/18 - (removed) "@create_revision = 1" */
	IF @auto_approve_client = 1 BEGIN
		EXECUTE @RC = [dbo].[usp_wv_Estimating_AddApproval] 
			@job_number
			,@job_component_nbr
			,@estimate_nbr_existing
			,@est_component_nbr_existing
			,@next_quote_nbr
			,@next_rev_nbr
			,@user_id --@EST_APPR_BY
			,@eff_date --@EST_APPR_DATE
			,NULL --@EST_APPR_CL_PO_NBR
			,@user_id --@CREATE_USER
			,@eff_date --@CREATE_DATE
			,'Auto approved via API' --@APPR_NOTES	
	END

	IF ISNULL(@client_discount_code, '') <> '*' BEGIN

		IF ISNULL(@client_discount_code, '')  = '' BEGIN

			UPDATE 
				dbo.JOB_COMPONENT
			SET
				CLIENT_DISCOUNT_CODE = NULL
			WHERE
				JOB_NUMBER = @job_number 
				AND JOB_COMPONENT_NBR = @job_component_nbr

		END ELSE BEGIN

			IF EXISTS(SELECT CLIENT_DISCOUNT_CODE FROM dbo.CLIENT_DISCOUNT WHERE CLIENT_DISCOUNT_CODE = @client_discount_code) BEGIN
			
				UPDATE 
					dbo.JOB_COMPONENT
				SET
					CLIENT_DISCOUNT_CODE = @client_discount_code
				WHERE
					JOB_NUMBER = @job_number 
					AND JOB_COMPONENT_NBR = @job_component_nbr

			END

		END

	END

	/* PJH 04/19/18 - Return new function row sequence number */
	IF @fnc_exists = 0
		IF @single_func_seq > 0
			SET @ret_val = @single_func_seq
	ELSE
		SET @ret_val = 0

	CAMPAIGN_ONLY:

	IF @@TRANCOUNT > 0
		IF @DEBUG = 1
		BEGIN
			SELECT 'DEBUG' 'DESC'
				,@job_number '@job_number'
				,@job_component_nbr '@job_component_nbr'
				,@user_id '@user_id'
				,@date_time_w '@date_time_w'

			SET @error_msg_w = 'DEBUG - ROLLBACK'

			GOTO ERROR_MSG
		END
	GOTO ENDIT

	/**************************** ERROR PROCESSING ***************************/
	ERROR_MSG:

	BEGIN
		SET @ret_val = -1
		SET @ret_val_s = @error_msg_w

		RAISERROR (
				@error_msg_w
				,16
				,1
				)
	END

	ENDIT: --Do Nothing
END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
		SELECT 'PROCESS ERROR ROLLBACK'
			,@@TRANCOUNT '@@TRANCOUNT' /* DEBUG */
	END

	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	SELECT @ErMessage = ERROR_MESSAGE()
		,@ErSeverity = ERROR_SEVERITY()
		,@ErState = ERROR_STATE();

	IF @ErMessage IS NOT NULL
	BEGIN
		 /* PJH 04/19/18 - Changed to -1 if error, 0 if ok, > 0 if returning new seq nbr */
		SET @ret_val = -1
		SET @ret_val_s = @ErMessage

	END

	SELECT @ErMessage 'ERROR_MESSAGE'
		,@ErSeverity 'ERROR_SEVERITY'
		,@ret_val 'ERROR_SATE' /* DEBUG */

END CATCH

IF @DEBUG = 1 BEGIN
	SELECT 'ESTIMATE_LOG' 'SRC', * FROM ESTIMATE_LOG WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
	SELECT 'ESTIMATE_COMPONENT' 'SRC', * FROM ESTIMATE_COMPONENT WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
	SELECT 'ESTIMATE_QUOTE' 'SRC', * FROM ESTIMATE_QUOTE WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
	SELECT 'ESTIMATE_INT_APPR' 'SRC', * FROM ESTIMATE_INT_APPR WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
	SELECT 'ESTIMATE_APPROVAL' 'SRC', * FROM ESTIMATE_APPROVAL WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
	SELECT 'ESTIMATE_REV' 'SRC', * FROM ESTIMATE_REV WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
	--SELECT 'ESTIMATE_REV_DET' 'SRC', EST_FNC_COMMENT, EST_FNC_TYPE, * FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = @estimate_nbr_existing
END

SELECT 'ESTIMATE_REV_DET' 'SRC', EST_FNC_COMMENT, EST_FNC_TYPE, * FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = @estimate_nbr_existing

/**************************************************/
--ROLLBACK TRANSACTION
/**************************************************/

IF @ret_val >= 0
	COMMIT TRAN
ELSE
	ROLLBACK TRAN

RETURN
GO

GRANT EXECUTE ON [advsp_estimate_add_update_api] TO PUBLIC AS dbo
GO

