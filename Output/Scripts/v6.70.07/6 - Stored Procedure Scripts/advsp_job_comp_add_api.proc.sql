IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_comp_add_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_comp_add_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_job_comp_add_api] 
	@user_id varchar(100), 
	@action varchar(10), 

	@job_cli_ref varchar(30),
	@job_number_in int,
	@cl_code varchar(6), 
	@div_code varchar(6), 
	@prd_code varchar(6), 	
	@sales_class varchar(6), 
	@job_desc varchar(60), 
	@job_comment varchar(max), 
	@acct_exec varchar(6) = NULL, 
	@job_comp_desc varchar(60) = NULL, 
	@cmp_id integer = NULL, 
	@due_date smalldatetime = NULL, 
	@job_type varchar(10) = NULL,
	@client_discount_code varchar(6) = NULL,
	@billing_coop_code varchar(6) = NULL,

	@non_bill_flag integer = NULL,
	@media_bill_date varchar(10) = NULL,
	
	@job_process_contrl int = 1,
	@job_comp_comment varchar(max), 

	@job_comp_budget_am decimal(14,2) = NULL,

	@job_tax_flag int = 0,

	@job_cl_po_nbr varchar(40) = NULL,

	@job_number integer OUTPUT, 
	@job_comp_nbr integer OUTPUT, 
	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT
AS

/*
PJH 11/6/17 - Created [[advsp_job_comp_add_api]]
					 If @job_number_in is supplied, the SP will add a new component to that job. 
					 If @job_number_in is NOT supplied, the SP will add a new job & component using the supplied client, division, product, etc.
					 The SP will return the new job/component as output
PJH 08/27/18 - Added @non_bill_flag & @media_bill_date
PJH 01/21/18 - Added @job_process_contrl
PJH 01/27/20 - Added @job_comp_budget_am
PJH 03/16/20 - Added @job_tax_flag
*/

SET NOCOUNT ON

DECLARE @error_msg_w VARCHAR(200)
DECLARE @date_time_w SMALLDATETIME

DECLARE @DEBUG INT
DECLARE @RC INT
	,@RC_MSG VARCHAR(max)

DECLARE @ErMessage NVARCHAR(2048)
	,@ErSeverity INT
	,@ErState INT

DECLARE @validation_errors TABLE(
	COLUMN_NAME varchar(32) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	INVALID_VALUE	varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS NULL )

DECLARE @row_count integer, 
	@cmp_code varchar(6)

DECLARE @add_comp bit, 
	@office_code varchar(4),
	@prd_tax_code varchar(4)

SET @add_comp = 1
SET @office_code = NULL

IF @job_number_in > 0
	SET @job_number = @job_number_in

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

	SELECT @ret_val = 0

	IF @cmp_id = 0 
		SET @cmp_id = NULL

	IF @acct_exec = ''
		SET @acct_exec = NULL
		
	IF @job_type = ''
		SET @job_type = NULL
		
	IF @client_discount_code = ''
		SET @client_discount_code = NULL
		
	IF @billing_coop_code = ''
		SET @billing_coop_code = NULL

	IF @job_cli_ref = '' OR @job_cli_ref = '?'
		SET @job_cli_ref = NULL

	IF ISDATE(@due_date) = 0 OR @due_date = '1/1/1900'
		SET @due_date = NULL


	IF @non_bill_flag IS NULL
		SET @non_bill_flag = 0

	IF ISDATE(@media_bill_date) = 0 OR @media_bill_date = '1/1/1900'
		SET @media_bill_date = NULL

	IF @job_comp_budget_am = -1
		SET @job_comp_budget_am = NULL	
		
	IF @job_number_in IS NULL
	BEGIN	

		IF @ret_val = 0
		BEGIN
			-- Validate Client
			SELECT @row_count = ( SELECT COUNT(*) FROM dbo.CLIENT WHERE CL_CODE = @cl_code AND ACTIVE_FLAG = 1 )

			IF @row_count <> 1
			BEGIN
				-- Invalid/Closed Client
				SELECT @ret_val = -2
				INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'CL_CODE', CAST( @cl_code AS varchar(254) ))
				SET @error_msg_w = 'Invalid Client Code.'
				GOTO ERROR_MSG
			END	
		END

		IF @ret_val = 0
		BEGIN
			-- Validate Division
			SELECT @row_count = ( SELECT COUNT(*) FROM dbo.DIVISION WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND ACTIVE_FLAG = 1 )

			IF @row_count <> 1
			BEGIN
				-- Invalid/Closed Division
				SELECT @ret_val = -3
				INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'DIV_CODE', CAST( @div_code AS varchar(254) ))
				SET @error_msg_w = 'Invalid Division Code.'
				GOTO ERROR_MSG
			END	
		END

		IF @ret_val = 0
		BEGIN
			-- Validate Product
			SELECT @row_count = ( SELECT COUNT(*) FROM dbo.PRODUCT WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code AND ACTIVE_FLAG = 1 )

			IF @row_count <> 1
			BEGIN
				PRINT @row_count
				-- Invalid/Closed Product
				SELECT @ret_val = -4
				INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'PRD_CODE', CAST( @prd_code AS varchar(254) ))
				SET @error_msg_w = 'Invalid Product Code.'
				GOTO ERROR_MSG
			END	
		END

	END
	ELSE
	BEGIN

		SELECT @cl_code = CL_CODE, @div_code = DIV_CODE, @prd_code = PRD_CODE														--Get Current
		FROM JOB_LOG
		WHERE JOB_NUMBER = @job_number

	END
	
	IF ( @ret_val = 0 ) AND @billing_coop_code IS NOT NULL AND ISNULL(@billing_coop_code, '') <> '*'
	BEGIN
		-- Validate Billing Coop
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.BILLING_COOP WHERE BILL_COOP_CODE = @billing_coop_code AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ))

		IF @row_count = 0
		BEGIN
			-- Invalid/Closed Billing Coop
			SELECT @ret_val = -14
			INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'BILL_COOP_CODE', CAST( @billing_coop_code AS varchar(6) ))
			SET @error_msg_w = 'Invalid Billing Coop Code.'
			GOTO ERROR_MSG
		END	
	END

	IF ( @ret_val = 0 )
	BEGIN
		SELECT @prd_tax_code = CASE WHEN @job_tax_flag = 1 THEN PRD_PROD_TAX_CODE ELSE NULL END FROM dbo.PRODUCT 
		WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code																					--PJH 03/12/2020 added tax
	END
		

	IF ( @ret_val = 0 ) BEGIN
		/**************  ADD - JOB  ***********************************/
		SET @job_number = COALESCE(@job_number, 0)

		IF ( @job_number = 0 ) BEGIN

			SELECT 'Add Job' 'DESC'

			IF ( @ret_val = 0 )
			BEGIN
				IF ( @office_code IS NULL ) -- Get the Office Code from the Product
					SELECT @office_code = ( SELECT OFFICE_CODE FROM dbo.PRODUCT WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code )

				-- Validate Office
				SELECT @row_count = ( SELECT COUNT(*) FROM dbo.OFFICE WHERE OFFICE_CODE = @office_code AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ))

				IF @row_count <> 1
				BEGIN
					-- Invalid/Closed Office
					SELECT @ret_val = -5
					INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'OFFICE_CODE', CAST( @office_code AS varchar(254) ))
					SET @error_msg_w = 'Invalid Office Code.'
					GOTO ERROR_MSG
				END	

			END

			IF ( @ret_val = 0 )
			BEGIN
				-- Validate Sales Class
				SELECT @row_count = ( SELECT COUNT(*) FROM dbo.SALES_CLASS WHERE SC_CODE = @sales_class AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ))

				IF @row_count <> 1
				BEGIN
					-- Invalid/Closed Sales Class
					SELECT @ret_val = -6
					INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'SC_CODE', CAST( @sales_class AS varchar(254) ))
					SET @error_msg_w = 'Invalid Sales Class Code.'
					GOTO ERROR_MSG
				END	
			END

			IF ( @ret_val = 0 )
			BEGIN
				-- Validate Job Desc
				IF ( @job_desc IS NULL )
				BEGIN
					-- Blank Job Description
					SELECT @ret_val = -7
					INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'JOB_DESC', CAST( @job_desc AS varchar(254) ))
					SET @error_msg_w = 'Invalid Job Description.'
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
					SELECT @ret_val = -8
					INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'CMP_IDENTIFIER', CAST( @cmp_id AS varchar(254) ))
					SET @error_msg_w = 'Invalid Campaign ID.'
					GOTO ERROR_MSG
				END	

				SELECT @cmp_code = ( SELECT CMP_CODE FROM dbo.CAMPAIGN WHERE CMP_IDENTIFIER = @cmp_id )
			END

			--IF ( @ret_val = 0 AND @complex_code IS NOT NULL )
			--BEGIN
			--	-- Validate Complexity
			--	SELECT @row_count = ( SELECT COUNT(*) FROM dbo.COMPLEXITY WHERE COMPLEX_CODE = @complex_code AND ( ACTIVE = 1 OR ACTIVE IS NULL ))

			--	IF @row_count <> 1
			--	BEGIN
			--		-- Invalid/Closed Complexity
			--		SELECT @ret_val = -9
			--		INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'COMPLEX_CODE', CAST( @complex_code AS varchar(254) ))
			--		SET @error_msg_w = 'Invalid Clint Code.'
			--		GOTO ERROR_MSG
			--	END	
			--END

			--IF @ret_val = 0
			--BEGIN
			--	SELECT @row_count = COUNT(*) FROM dbo.JOB_LOG WHERE JOB_CLI_REF = @job_cli_ref 
			--	IF @row_count > 0 BEGIN
			--		SELECT @ret_val = -9
			--		SET @error_msg_w = 'Client Reference ID already exists.'
			--		GOTO ERROR_MSG				
			--	END
			--END
			
			SET @job_process_contrl = COALESCE(@job_process_contrl,0)

			IF @job_process_contrl NOT IN (1,2,5)
			BEGIN
				-- Invalid Process Controll
				SET @error_msg_w = 'Invalid Job Process Control. The Process Control must be (1) "All Processing" or (2) "No Processing" or (5) "Billing Only".'
				GOTO ERROR_MSG
			END		
			
			IF @DEBUG = 1
				SELECT @ret_val '@ret_val'

			IF @ret_val = 0
			BEGIN
				-- Get next Job Number
			
				SELECT 'Get Next Job' 'DESC'

				SELECT @job_number = ( SELECT LAST_NBR + 1 FROM dbo.ASSIGN_NBR  WHERE COLUMNNAME = 'JOB_NUMBER' )
 
				IF ( @job_number > 99999999 ) OR ( @job_number IS NULL )
					SELECT @job_number = 1

				UPDATE dbo.ASSIGN_NBR SET LAST_NBR = @job_number WHERE COLUMNNAME = 'JOB_NUMBER'

				IF ( @@ERROR <> 0 ) 
					SELECT @ret_val = -14		
				ELSE
					-- Insert new Job
					INSERT INTO dbo.JOB_LOG ( 
							JOB_NUMBER, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, SC_CODE, [USER_ID], JOB_COMMENTS,
							CREATE_DATE, JOB_DESC, JOB_DATE_OPENED, JOB_RUSH_CHARGES, JOB_CLI_REF, COMPLEX_CODE, CMP_IDENTIFIER, 
							JOB_ESTIMATE_REQ, BILL_COOP_CODE, MODIFIED_BY, MODIFY_DATE )
						 SELECT @job_number, @office_code, @cl_code, @div_code, @prd_code, @cmp_code, @sales_class, UPPER(@user_id), @job_comment,
								GETDATE(), @job_desc, CONVERT( varchar(10), GETDATE(), 101 ), 0, 
								@job_cli_ref, NULL, -- @cli_ref, @complex_code, 
								@cmp_id, 
								COALESCE( PRD_PROD_ESTIMATE, APPR_EST_REQ ), 
								@billing_coop_code,	UPPER(@user_id), @date_time_w
						   FROM dbo.PRODUCT, dbo.AGENCY
						  WHERE CL_CODE = @cl_code
							AND DIV_CODE = @div_code
							AND PRD_CODE = @prd_code
					
				IF ( @@ERROR <> 0 ) 
					SELECT @ret_val = -14		
			END

		END ELSE BEGIN

			IF ISNULL(@billing_coop_code, '') <> '*' BEGIN
			
				UPDATE dbo.JOB_LOG
				SET BILL_COOP_CODE = @billing_coop_code
				WHERE JOB_NUMBER = @job_number

			END 

		END

	END

	/**************  ADD - JOB - COMPONENT  ***********************************/
	IF ( @add_comp = 1 )
		BEGIN
		-- Validate Job
		IF ( @ret_val = 0 )
		BEGIN
			IF @DEBUG = 1
				SELECT @job_number '@job_number'

			SELECT @row_count = ( SELECT COUNT(*) 
									FROM dbo.JOB_LOG
								   WHERE JOB_NUMBER = @job_number )

			IF @row_count <> 1
			BEGIN
				-- Invalid Job
				SELECT @ret_val = -1
				INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'JOB_NUMBER', CAST( @job_number AS varchar(254) ))
				SET @error_msg_w = 'Invalid Job Numnber for Job Component creation.'
				GOTO ERROR_MSG
			END	
		END

		IF ( @ret_val = 0 )
		BEGIN
			-- Validate Job Comp Desc
			IF ( @job_comp_desc IS NULL )
				SELECT @job_comp_desc = ( SELECT JOB_DESC FROM dbo.JOB_LOG WHERE JOB_NUMBER = @job_number )
		END

		IF ( @ret_val = 0 ) AND @acct_exec IS NULL
		BEGIN
			SELECT @acct_exec = EMP_CODE
								FROM dbo.ACCOUNT_EXECUTIVE 
								WHERE CL_CODE = @cl_code
									 AND DIV_CODE = @div_code
									 AND PRD_CODE = @prd_code
									 AND ( INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL )
									 AND DEFAULT_AE = 1
		END

		IF ( @ret_val = 0 )
		BEGIN
			-- Validate A/E
			SELECT @row_count = ( SELECT COUNT(*) 
									FROM dbo.ACCOUNT_EXECUTIVE 
									WHERE EMP_CODE = @acct_exec 
									 AND CL_CODE = @cl_code
									 AND DIV_CODE = @div_code
									 AND PRD_CODE = @prd_code
									 AND ( INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL ))

			IF @row_count <> 1
			BEGIN
				-- Invalid/Inactive Account Executive
				SELECT @ret_val = -11
				INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'ACCOUNT_EXECUTIVE', CAST( @acct_exec AS varchar(254) ))
				SET @error_msg_w = 'Invalid Account Executive.'
				GOTO ERROR_MSG
			END	
		END

		IF ( @ret_val = 0 ) AND @job_type IS NOT NULL
		BEGIN
			-- Validate Job Type
			SELECT @row_count = ( SELECT COUNT(*) FROM dbo.JOB_TYPE WHERE JT_CODE = @job_type AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ))

			IF @row_count <> 1
			BEGIN
				-- Invalid/Closed Job Type
				SELECT @ret_val = -12
				INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'JT_CODE', CAST( @job_type AS varchar(10) ))
				SET @error_msg_w = 'Invalid Job Type Code.'
				GOTO ERROR_MSG
			END	
		END
		
		IF ( @ret_val = 0 ) AND @client_discount_code IS NOT NULL
		BEGIN
			-- Validate Client Discount
			SELECT @row_count = ( SELECT COUNT(*) FROM dbo.CLIENT_DISCOUNT WHERE CLIENT_DISCOUNT_CODE = @client_discount_code AND ( IS_INACTIVE = 0 ))

			IF @row_count <> 1
			BEGIN
				-- Invalid/Closed Client Discount
				SELECT @ret_val = -13
				INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'CLIENT_DISCOUNT_CODE', CAST( @client_discount_code AS varchar(6) ))
				SET @error_msg_w = 'Invalid Client Discount Code.'
				GOTO ERROR_MSG
			END	
		END

		IF ( @ret_val = 0 )
		BEGIN
			-- Get next Job Comp Number
			SELECT @job_comp_nbr = ( SELECT COALESCE( MAX( JOB_COMPONENT_NBR ), 0 ) + 1 FROM dbo.JOB_COMPONENT WHERE JOB_NUMBER = @job_number )

			-- Insert new Job Component
			INSERT INTO dbo.JOB_COMPONENT ( 
					JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, JOB_COMP_DATE, JOB_FIRST_USE_DATE, JOB_SPEC_TYPE, DP_TM_CODE, JOB_PROCESS_CONTRL,
					JOB_COMP_DESC, AB_FLAG, JT_CODE, NOBILL_FLAG, JOB_MARKUP_PCT, EMAIL_GR_CODE, CLIENT_DISCOUNT_CODE, MEDIA_BILL_DATE, JOB_COMP_COMMENTS,
					JOB_COMP_BUDGET_AM,
					MODIFIED_BY, MODIFY_DATE,
					TAX_CODE, JOB_CL_PO_NBR )
				 SELECT TOP 1 @job_number, @job_comp_nbr, @acct_exec, CONVERT( varchar(10), GETDATE(), 101 ), @due_date, 0, 
					NULL, --@dp_tm_code, 
					@job_process_contrl, 
					@job_comp_desc, 0, 
					@job_type, 
					@non_bill_flag, PRD_PROD_MARKUP, EMAIL_GR_CODE, @client_discount_code, @media_bill_date, @job_comp_comment,
					@job_comp_budget_am,
					UPPER(@user_id), @date_time_w,
					@prd_tax_code, @job_cl_po_nbr
				   FROM dbo.PRODUCT
				  WHERE CL_CODE = @cl_code
					AND DIV_CODE = @div_code
					AND PRD_CODE = @prd_code
			
			IF ( @@ERROR <> 0 ) 
				SELECT @ret_val = -15		
		END
	END

	IF @@TRANCOUNT > 0
		IF @DEBUG = 1
		BEGIN
			SELECT 'DEBUG' 'DESC'
				,@job_number '@job_number'
				,@job_comp_nbr '@job_component_nbr'
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
		SET @ret_val = @ErState
		SET @ret_val_s = @ErMessage
	END

END CATCH

IF @DEBUG = 1 BEGIN
	SELECT 'ESTIMATE_LOG' 'SRC', * FROM JOB_LOG WHERE JOB_NUMBER = @job_number
	SELECT 'ESTIMATE_COMPONENT' 'SRC', * FROM JOB_COMPONENT WHERE JOB_NUMBER = @job_number
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

GRANT EXECUTE ON [advsp_job_comp_add_api] TO PUBLIC AS dbo
GO