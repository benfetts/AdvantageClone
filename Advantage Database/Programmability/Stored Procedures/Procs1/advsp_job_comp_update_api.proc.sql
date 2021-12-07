
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_comp_update_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_comp_update_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--

CREATE PROCEDURE [dbo].[advsp_job_comp_update_api] 
	@user_id varchar(100), 
	@action varchar(10), 

	@job_number int,
	@job_component_nbr int,
	@job_desc varchar(60), 
	@job_comments varchar(max), 
	@job_comp_desc varchar(60), 
	@job_comp_comments varchar(max),
	@job_cli_ref varchar(30),
	@job_process_contrl int,
	@job_type varchar(10),

	@non_bill_flag integer = NULL,
	@media_bill_date varchar(10) = NULL,

	@job_comp_budget_am decimal(14,2) = NULL,

	@job_tax_flag int = 0,

	@job_cl_po_nbr varchar(40) = NULL,
	@cmp_id integer = NULL,

	@service_fee_flag varchar(1) = '0',

	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT
AS

/*
PJH 07/20/18 - Created [advsp_job_comp_update_api]
					Update the following:
					Job Comment
					Job Component Comment
					Job Component Description
					Job Description
					Client Reference Number
					Job Processing Control  (This requires updating the processing control and inserting a field in the table. Limit to either 1 = All processing or ? = No processing for now)
PJH 08/27/18 - Added @non_bill_flag & @media_bill_date
PJH 10/10/18 - added -1 for @non_bill_flag to keep current value | Allow @media_bill_date = '*' to keep current date
PJH 01/21/18 - Allow @job_process_contrl 5 for Bill Only
PJH 01/27/20 - Added @job_comp_budget_am decimal
PJH 03/16/20 - Added @job_tax_flag
PJH 05/01/20 - Added 6 (closed) to @job_process_contrl NOT IN (0,1,2,5,6)
PJH 02/15/21 - Added @cmp_id, @cmp_code
PJH 12/03/21 - Added @@service_fee_flag
*/

SET NOCOUNT ON

DECLARE @error_msg_w varchar(200)
DECLARE @date_time_w smalldatetime

DECLARE @DEBUG INT
DECLARE @RC INT
	,@RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048)
	,@ErSeverity INT
	,@ErState INT

DECLARE @row_count integer, 
	@tmp_count int

--DECLARE @list_str varchar(max)

DECLARE @orig_job_cmts_html varchar(max)
DECLARE @orig_jc_cmts_html varchar(max)
DECLARE @orig_job_process_contrl int
DECLARE @orig_job_comp_budget_am decimal(14,2)
DECLARE @job_number_str varchar(20)
DECLARE @bcc_id int, @updt_process_ctrl bit = 0
DECLARE @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6)
DECLARE @prd_tax_code varchar(4)
DECLARE @cmp_code varchar(6)

DECLARE @jt_code varchar(10)

BEGIN TRAN

BEGIN TRY
	IF @action = 'DEBUG'
		SET @DEBUG = 1
	ELSE
		SET @DEBUG = 0

	IF @user_id IS NULL
	BEGIN
		SET @error_msg_w = 'Invalid User ID.'
		GOTO ERROR_MSG
	END

	SELECT @date_time_w = GETDATE()

	SET @ret_val = 0
	SET @ret_val_s = 'Success...'

	SET @job_number = COALESCE(@job_number, 0)

	SET @jt_code = @job_type

	IF @service_fee_flag NOT IN ('0', '1')
		SET @service_fee_flag = '0'
		
	IF @job_number > 0
	BEGIN
		-- Validate JOB_NUMBER
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.JOB_LOG WHERE JOB_NUMBER = @job_number )

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Status
			SET @error_msg_w = 'Invalid Job Number.'
			GOTO ERROR_MSG
		END	

		SET @job_process_contrl = COALESCE(@job_process_contrl,0)

		IF @job_process_contrl NOT IN (0,1,2,5,6)
		BEGIN
			-- Invalid Process Controll
			SET @error_msg_w = 'Invalid Job Process Control. The Process Control must be (1) "All Processing", (2) "No Processing", (5) "Billing Only", (6) "Closed", or (0) "Do not Update".'
			GOTO ERROR_MSG
		END	

		SELECT @orig_job_cmts_html = JOB_COMMENTS_HTML,
			@cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE														--PJH 03/12/2020 added tax
		FROM JOB_LOG
		WHERE JOB_NUMBER = @job_number

		SELECT @orig_jc_cmts_html = JC_COMMENTS_HTML, @orig_job_process_contrl = JOB_PROCESS_CONTRL, @bcc_id = COALESCE(BCC_ID, 0), @orig_job_comp_budget_am = JOB_COMP_BUDGET_AM
		FROM JOB_COMPONENT
		WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr

		IF @job_tax_flag = 1
			SELECT @prd_tax_code = PRD_PROD_TAX_CODE FROM dbo.PRODUCT 
			WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code											--PJH 03/12/2020 added tax

		--If 1 or 2 then check current status
		IF @job_process_contrl > 0
			IF @job_process_contrl <> @orig_job_process_contrl
				SET @updt_process_ctrl = 1

		IF @bcc_id > 0
		BEGIN
			-- Selected for billing
			SET @error_msg_w = 'Job/Comp is selected for billing.'
			GOTO ERROR_MSG
		END	

		IF @orig_job_process_contrl IN (6, 12)
		BEGIN
			-- Selected for billing
			SET @error_msg_w = 'Job/Comp is closed or archived.'
			GOTO ERROR_MSG
		END	

		IF @job_desc IN ('', '*','?')
			SET @job_desc = NULL

		IF @job_comments IN ('')
			SET @job_comments = NULL
		ELSE IF @job_comments IN ('*','?')
			SET @job_comments = '*'

		IF @job_comp_desc IN ('', '*','?')
			SET @job_comp_desc = NULL

		IF @job_comp_comments IN ('')
			SET @job_comp_comments = NULL
		ELSE IF @job_comp_comments IN ('*','?')
			SET @job_comp_comments = '*'

		IF @job_cli_ref IN ('', '*','?')
			SET @job_cli_ref = '*'

		IF @jt_code IN ('')
			SET @jt_code = NULL
		ELSE IF @jt_code IN ('*','?')
			SET @jt_code = '*' /* keep it */

		IF @job_cl_po_nbr IN ('')
			SET @job_cl_po_nbr = NULL
		ELSE IF @job_cl_po_nbr IN ('*','?')
			SET @job_cl_po_nbr = '*' /* keep it */

		IF @cmp_id = 0 
			SET @cmp_id = NULL

		/*PJH 10/10/18 - added -1 to keep current value */
		IF @non_bill_flag NOT IN (-1, 0, 1)
			BEGIN
				SET @error_msg_w = 'Invalid Non-Bill Flag.'
				GOTO ERROR_MSG
			END

		IF ISDATE(@media_bill_date) = 0 OR @media_bill_date = '1/1/1900'
			IF @media_bill_date <> '*'
				SET @media_bill_date = NULL

		IF @jt_code IS NOT NULL AND @jt_code <> '*'
		BEGIN
			SELECT @row_count = ( SELECT COUNT(*) FROM dbo.JOB_TYPE WHERE JT_CODE = @jt_code AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ) )

			IF @row_count <> 1
			BEGIN
				-- Invalid/Closed Status
				SET @error_msg_w = 'Invalid or Inactive Job Type.'
				GOTO ERROR_MSG
			END	
		END

		IF ( @ret_val = 0 AND @cmp_id > 0 )
		BEGIN
			-- Validate Campaign
			SELECT @row_count = ( SELECT COUNT(*) 
									FROM dbo.CAMPAIGN 
									WHERE CMP_IDENTIFIER = @cmp_id 
										AND CL_CODE = @cl_code
										AND (DIV_CODE = @div_code OR DIV_CODE IS NULL)
										AND (PRD_CODE = @prd_code OR PRD_CODE IS NULL)
										AND CMP_TYPE = 2	
										AND ( CMP_CLOSED IS NULL OR CMP_CLOSED = 0 ))

			IF @row_count <> 1
			BEGIN
				-- Invalid/Closed Campaign
				SET @error_msg_w = 'Invalid or Inactive Campaign ID.'
				GOTO ERROR_MSG
			END	

			SELECT @cmp_code = ( SELECT CMP_CODE FROM dbo.CAMPAIGN WHERE CMP_IDENTIFIER = @cmp_id )
		END

		IF @job_comp_budget_am = -1
			SET @job_comp_budget_am = @orig_job_comp_budget_am 

		--SET @job_number_str = CAST(@job_number AS varchar(20))

		--SELECT @job_number_str '@job_number_str'

		/* only update if html is not NULL */

		IF @job_comments IS NULL
			SET @orig_job_cmts_html = NULL
		ELSE
			IF @orig_job_cmts_html IS NOT NULL
				SET @orig_job_cmts_html = @job_comments

		IF @job_comp_comments IS NULL
			SET @orig_jc_cmts_html = NULL
		ELSE
			IF @orig_jc_cmts_html IS NOT NULL
				SET @orig_jc_cmts_html = @job_comp_comments

		--SELECT @job_comments '@job_comments', @job_comp_comments '@job_comp_comments'
		--SELECT @orig_job_cmts_html '@orig_job_cmts_html', @orig_jc_cmts_html '@orig_jc_cmts_html'

		/* Update values specific to the API */
		/* PJH 06/20/19 - Added MODIFIED_BY, MODIFY_DATE */
		UPDATE JOB_LOG
		SET JOB_DESC = COALESCE(@job_desc, JOB_DESC),
			JOB_COMMENTS = CASE WHEN @job_comments = '*' THEN JOB_COMMENTS ELSE @job_comments END,
			JOB_COMMENTS_HTML = CASE WHEN @orig_job_cmts_html = '*' THEN JOB_COMMENTS_HTML ELSE @orig_job_cmts_html END,
			JOB_CLI_REF = CASE WHEN @job_cli_ref = '*' THEN JOB_CLI_REF ELSE @job_cli_ref END,
			MODIFIED_BY = UPPER(@user_id), 
			MODIFY_DATE = @date_time_w,
			CMP_IDENTIFIER = CASE WHEN @cmp_id = -1 THEN CMP_IDENTIFIER ELSE @cmp_id END,
			CMP_CODE = CASE WHEN @cmp_id = -1 THEN CMP_CODE ELSE @cmp_code END
		WHERE JOB_NUMBER = @job_number

		/* PJH 06/20/19 - Added MODIFIED_BY, MODIFY_DATE */
		/* PJH 08/21/19 - Update Component level MODIFIED_BY, MODIFY_DATE for all components */	
		UPDATE JOB_COMPONENT
		SET JOB_COMP_DESC = COALESCE(@job_comp_desc, JOB_COMP_DESC), 
			JOB_COMP_COMMENTS = CASE WHEN @job_comp_comments = '*' THEN JOB_COMP_COMMENTS ELSE @job_comp_comments END,
			JC_COMMENTS_HTML = CASE WHEN @orig_jc_cmts_html = '*' THEN JC_COMMENTS_HTML ELSE @orig_jc_cmts_html END,
			JOB_PROCESS_CONTRL = CASE WHEN @job_process_contrl > 0 THEN @job_process_contrl ELSE JOB_PROCESS_CONTRL END,
			JT_CODE = CASE WHEN @jt_code = '*' THEN JT_CODE ELSE @jt_code END,
			NOBILL_FLAG = CASE WHEN @non_bill_flag = -1 THEN NOBILL_FLAG ELSE @non_bill_flag END,
			MEDIA_BILL_DATE = CASE WHEN @media_bill_date = '*' THEN MEDIA_BILL_DATE ELSE @media_bill_date END,
			MODIFIED_BY = UPPER(@user_id), 
			MODIFY_DATE = @date_time_w,
			JOB_COMP_BUDGET_AM = @job_comp_budget_am,
			TAX_CODE = CASE WHEN @job_tax_flag = 1 THEN @prd_tax_code ELSE TAX_CODE END, 						--PJH 03/12/2020 added tax
			JOB_CL_PO_NBR = CASE WHEN @job_cl_po_nbr = '*' THEN JOB_CL_PO_NBR ELSE @job_cl_po_nbr END,			--PJH 09/28/2020 added tax
			SERVICE_FEE_FLAG = CASE WHEN @service_fee_flag = '*' THEN SERVICE_FEE_FLAG ELSE @service_fee_flag END
		WHERE JOB_NUMBER = @job_number AND (JOB_COMPONENT_NBR = @job_component_nbr OR COALESCE(@job_component_nbr, 0) = 0)

		IF @updt_process_ctrl = 1
			INSERT INTO [dbo].[JOB_PROCESS_LOG]
					   ([JOB_NUMBER]
					   ,[JOB_COMPONENT_NBR]
					   ,[ORIG_PROCESS_CNTRL]
					   ,[NEW_PROCESS_CNTRL]
					   ,[PROCESS_DATE]
					   ,[PROCESS_USER]
					   ,[PROCESS_COMMENT]
					   ,[BCC_FLAG])
				 VALUES
						(@job_number,
						@job_component_nbr,
						@orig_job_process_contrl,
						@job_process_contrl,
						@date_time_w,
						@user_id,
						'Updated via Advantage API',
						0
						)

	END/* Job Number > 0 */

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
		SET @ret_val = - 1

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

	SELECT @ErMessage 'ERROR_MESSAGE'
		,@ErSeverity 'ERROR_SEVERITY'
		,@ErState 'ERROR_SATE' /* DEBUG */

	--IF @ret_val <> 0
	IF @ErMessage IS NOT NULL
	BEGIN
		SET @ret_val = 1
		SET @ret_val_s = @ErMessage
	END

END CATCH

IF @DEBUG = 1 
BEGIN
	SELECT 'JOB_LOG' 'SRC', * FROM JOB_LOG WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_COMPONENT' 'SRC', * FROM JOB_COMPONENT WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr
	SELECT 'JOB_PROCESS_LOG' 'SRC', * FROM JOB_PROCESS_LOG WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr
END

/**************************************************/
--ROLLBACK TRANSACTION - Handle in Calling process
/**************************************************/

IF @ret_val = 0
	COMMIT TRAN
ELSE
	ROLLBACK TRAN

RETURN

GO

GRANT EXECUTE ON [advsp_job_comp_update_api] TO PUBLIC AS dbo
GO
