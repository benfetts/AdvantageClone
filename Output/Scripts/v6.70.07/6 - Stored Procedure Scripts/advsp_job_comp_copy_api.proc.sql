IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_comp_copy_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_comp_copy_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_job_comp_copy_api] 
	@user_id varchar(100), 
	@action varchar(10), 

	--@job_cli_ref varchar(30),
	@job_number_in int,
	@cl_code varchar(6), 
	@div_code varchar(6), 
	@prd_code varchar(6), 	
	@sales_class varchar(6), 
	@cmp_id integer = NULL, 
	@job_desc varchar(60), 
	@job_comment varchar(max), 
	@job_comp_desc varchar(60) = NULL, 
	@acct_exec varchar(6) = NULL, 
	@udv1_code varchar(10) = NULL,
	@udv2_code varchar(10) = NULL,
	@office_code varchar(10) = NULL, /* if blank, get from product */
	@send_email bit,
	@status varchar(6),
	@include_schedule bit,
	@include_task_employees bit,
	@include_task_comment bit,
	@include_task_due_date_comment bit,
	@include_task_start_and_due_dates bit,

	@JOB_NUMBER integer OUTPUT, 
	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT
AS

/*
PJH 12/22/17 - Created [[advsp_job_comp_copy_api]]
	o	Other rules and actions
		?	Alert Group from the current product will be copied.  If one does not exist, the Alert Group from the copy from job will be used.
		?	When the job and schedules are copied, anything not specified above will copy from the copy from job.
		?	Other than items above, copy all other data as is.
			•	Internal (AB Flag = 0)
		?	Status – required – 6 char – must exist in Advantage db.
			•	If blank, use the status from the copy from job. 
	o	Return
		?	Success or Failure
		?	Job Number
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

--DECLARE @validation_errors TABLE(
--	COLUMN_NAME varchar(32) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
--	INVALID_VALUE	varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS NULL )

DECLARE @job_component TABLE (
	[ROWID] [int] IDENTITY(1,1) NOT NULL,
	[JOB_NUMBER] [int] NOT NULL,
	[JOB_COMPONENT_NBR] [smallint] NOT NULL	
	)

DECLARE @job_traffic_role TABLE (
	[ROWID] [int] IDENTITY(1,1) NOT NULL,
	[JOB_NUMBER] [int] NOT NULL,
	[JOB_COMPONENT_NBR] [smallint] NOT NULL	
	)

DECLARE @row_count integer, 
	@tmp_count int,
	@cmp_code varchar(6)

DECLARE @add_comp bit, 
	@job_comp_nbr_in integer,
	@prd_office_code varchar(4),
	@prd_email_gr_code varchar(10)

DECLARE @list_str varchar(max)

SET @add_comp = 1
SET @office_code = NULL

--IF @job_number_in > 0
--	SET @JOB_NUMBER = @job_number_in

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

	IF @acct_exec IN ('', '*')
		SET @acct_exec = NULL

	IF @sales_class IN ('', '*')
		SET @sales_class = NULL

	IF @cmp_id IN (0) 
		SET @cmp_id = NULL

	IF @job_desc IN ('', '*')
		SET @job_desc = NULL

	IF @job_comment IN ('', '*')
		SET @job_comment = NULL

	IF @job_comp_desc IN ('', '*')
		SET @job_comp_desc = NULL

	IF @udv1_code IN ('', '*')
		SET @udv1_code = NULL

	IF @udv2_code IN ('', '*')
		SET @udv2_code = NULL

	IF @status IN ('', '*')
		SET @status = NULL	
		
	IF COALESCE(@job_number_in, 0) > 0
	BEGIN
		-- Validate Traffic Status
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.JOB_LOG WHERE JOB_NUMBER = @job_number_in )

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Status
			SET @error_msg_w = 'Invalid Job Number.'
			GOTO ERROR_MSG
		END	
	END			

	IF @status IS NOT NULL
	BEGIN
		-- Validate Traffic Status
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.TRAFFIC WHERE TRF_CODE = @status AND COALESCE(INACTIVE_FLAG, 0) = 0 )

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Status
			SET @error_msg_w = 'Invalid Traffic Status.'
			GOTO ERROR_MSG
		END	
	END

	BEGIN
		-- Validate Client
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.CLIENT WHERE CL_CODE = @cl_code AND ACTIVE_FLAG = 1 )

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Client
			SET @error_msg_w = 'Invalid Client Code.'
			GOTO ERROR_MSG
		END	
	END

	BEGIN
		-- Validate Division
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.DIVISION WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND ACTIVE_FLAG = 1 )

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Division
			SET @error_msg_w = 'Invalid Division Code.'
			GOTO ERROR_MSG
		END	
	END

	BEGIN
		-- Validate Product
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.PRODUCT WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code AND ACTIVE_FLAG = 1 )

		IF @row_count <> 1
		BEGIN
			PRINT @row_count
			-- Invalid/Closed Product
			SET @error_msg_w = 'Invalid Product Code.'
			GOTO ERROR_MSG
		END	
	END

	/* Set children to 0 is parent is 0 */
	IF @include_schedule = 0
	BEGIN
		SET @include_task_employees = 0
		SET @include_task_comment = 0
		SET @include_task_due_date_comment = 0
		SET @include_task_start_and_due_dates = 0
	END

	/**************  ADD - JOB  ***********************************/
	SET @job_number_in = COALESCE(@job_number_in, 0)

	IF ( @job_number_in <> 0 )
	BEGIN

		--SELECT 'Add Job' 'DESC'

		--BEGIN
		--	IF ( @office_code IS NULL ) -- Get the Office Code from the Product
		--		SELECT @office_code = ( SELECT OFFICE_CODE FROM dbo.PRODUCT WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code )
		
		--	-- Validate Office
		--	SELECT @row_count = ( SELECT COUNT(*) FROM dbo.OFFICE WHERE OFFICE_CODE = @office_code AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ))

		--	IF @row_count <> 1
		--	BEGIN
		--		-- Invalid/Closed Office
		--		INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'OFFICE_CODE', CAST( @office_code AS varchar(254) ))
		--		SET @error_msg_w = 'Invalid Office Code.'
		--		GOTO ERROR_MSG
		--	END	
		--END

		IF @sales_class IS NOT NULL
		BEGIN
			-- Validate Sales Class
			SELECT @row_count = ( SELECT COUNT(*) FROM dbo.SALES_CLASS WHERE SC_CODE = @sales_class AND ( COALESCE(INACTIVE_FLAG, 0) = 0 ))

			IF @row_count <> 1
			BEGIN
				-- Invalid/Closed Sales Class
				SET @error_msg_w = 'Invalid Sales Class Code.'
				GOTO ERROR_MSG
			END	
		END
		ELSE
			SELECT @sales_class = SC_CODE FROM dbo.JOB_LOG WHERE JOB_NUMBER = @job_number_in

		IF @job_desc IS NULL
			SELECT @job_desc = JOB_DESC + ' - (' + @cl_code + ')' FROM dbo.JOB_LOG WHERE JOB_NUMBER = @job_number_in

		--BEGIN
		--	-- Validate Job Desc
		--	IF ( @job_desc IS NULL )
		--	BEGIN
		--		-- Blank Job Description
		--		INSERT INTO @validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'JOB_DESC', CAST( @job_desc AS varchar(254) ))
		--		SET @error_msg_w = 'Invalid Job Description.'
		--		GOTO ERROR_MSG
		--	END	
		--END

		IF @cmp_id IS NOT  NULL
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
				SET @error_msg_w = 'Invalid Campaign ID.'
				GOTO ERROR_MSG
			END	

			SELECT @cmp_code = ( SELECT CMP_CODE FROM dbo.CAMPAIGN WHERE CMP_IDENTIFIER = @cmp_id )
		END

		BEGIN

			-- Get next Job Number

			SET @JOB_NUMBER = NULL

			BEGIN
				/* Copy Job */
				EXECUTE @RC = [dbo].[usp_wv_Job_Template_Copy_AddJob]
					 @job_number_in
					,@job_desc
					,@cl_code
					,@div_code
					,@prd_code
					,@sales_class
					,@user_id
					,@cmp_id
					,@cmp_code
					,@JOB_NUMBER OUTPUT
					,@date_time_w
			END

		END

		SET @JOB_NUMBER = COALESCE(@JOB_NUMBER, 0)

		DECLARE @row_id int
		DECLARE @JOB_COMPONENT_NBR int
		DECLARE @acct_exec_new varchar(6), @job_tmplt_code varchar(6), @default_ae int
		DECLARE @udv1_value varchar(10), @udv2_value varchar(10)
		DECLARE @udv_editable bit
		DECLARE @job_number_str varchar(20)

		SET @job_number_str = CAST(@JOB_NUMBER AS varchar(20))

		SELECT @job_number_str '@job_number_str'

		IF @udv1_code IS NOT NULL BEGIN
			SELECT @udv_editable = EDITABLE
			FROM UDV_LABEL
			WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV1'

			/* If not in lookup then add as data entry value */
			IF @udv_editable = 1 BEGIN
				SET @udv1_value = RIGHT('000000' + @job_number_str, 6)

				INSERT INTO JOB_LOG_UDV1 (UDV_CODE, UDV_DESC, INACTIVE_FLAG)
				VALUES (@udv1_value, @udv1_code, NULL)
			END
			ELSE BEGIN
				SELECT @udv1_value = UDV_CODE
				FROM JOB_LOG_UDV1
				WHERE UDV_CODE = @udv1_code
					AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)
			END

			IF @udv1_value IS NULL
			BEGIN
				SET @error_msg_w = 'Invalid User Defined Value1.'
				GOTO ERROR_MSG
			END	
		END

		IF @udv2_code IS NOT NULL BEGIN
			SELECT @udv_editable = EDITABLE
			FROM UDV_LABEL
			WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV2'

			/* If not in lookup then add as data entry value */
			IF @udv_editable = 1 BEGIN
				SET @udv2_value = RIGHT('000000' + @job_number_str, 6)

				INSERT INTO JOB_LOG_UDV2 (UDV_CODE, UDV_DESC, INACTIVE_FLAG)
				VALUES (@udv2_value, @udv2_code, NULL)
			END
			ELSE BEGIN
				SELECT @udv2_value = UDV_CODE
				FROM JOB_LOG_UDV2
				WHERE UDV_CODE = @udv2_code
					AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)
			END

			IF @udv2_value IS NULL
			BEGIN
				SET @error_msg_w = 'Invalid User Defined Value2.'
				GOTO ERROR_MSG
			END	
		END

		/* Update values specific to the API */
		/* PJH 06/20/19 - Added MODIFIED_BY, MODIFY_DATE*/
		BEGIN
			UPDATE JOB_LOG
			SET UDV1_CODE = @udv1_value,
				UDV2_CODE = @udv2_value,
				JOB_COMMENTS = @job_comment,
				MODIFIED_BY = UPPER(@user_id), 
				MODIFY_DATE = @date_time_w
			WHERE JOB_NUMBER = @JOB_NUMBER
		END

		SET @row_id = 1

		/* Copy Job Components */

		IF @JOB_NUMBER > 0 
		BEGIN

			IF @acct_exec IS NULL
			BEGIN
				SELECT @acct_exec_new = EMP_CODE
						FROM dbo.ACCOUNT_EXECUTIVE 
						WHERE CL_CODE = @cl_code
								AND DIV_CODE = @div_code
								AND PRD_CODE = @prd_code
								--AND EMP_CODE = @acct_exec
								AND ( COALESCE(INACTIVE_FLAG, 0) = 0 )
								AND DEFAULT_AE = 1

			END
			ELSE
			BEGIN
				SELECT @acct_exec_new = EMP_CODE
						FROM dbo.ACCOUNT_EXECUTIVE 
						WHERE CL_CODE = @cl_code
								AND DIV_CODE = @div_code
								AND PRD_CODE = @prd_code
								AND EMP_CODE = @acct_exec /* Exisiting */
								AND ( COALESCE(INACTIVE_FLAG, 0) = 0 )
								AND DEFAULT_AE = 1
			END

			--SELECT @acct_exec '@acct_exec'

			SELECT @prd_email_gr_code = EMAIL_GR_CODE, @prd_office_code = OFFICE_CODE
					FROM dbo.PRODUCT 
						WHERE CL_CODE = @cl_code 
						AND DIV_CODE = @div_code 
						AND PRD_CODE = @prd_code 

			IF ( @office_code IS NULL ) -- Get the Office Code from the Product
				SET @office_code = @prd_office_code 
			
			BEGIN
				-- Validate Office
				SELECT @row_count = ( SELECT COUNT(*) FROM dbo.OFFICE WHERE OFFICE_CODE = @office_code AND ( COALESCE(INACTIVE_FLAG, 0) = 0 ))

				IF @row_count <> 1
				BEGIN
					-- Invalid/Closed Office
					SET @error_msg_w = 'Invalid Office Code.'
					GOTO ERROR_MSG
				END	
			END

			BEGIN
				INSERT INTO @job_component
					SELECT JOB_NUMBER, JOB_COMPONENT_NBR FROM JOB_COMPONENT
					WHERE JOB_NUMBER = @job_number_in AND JOB_PROCESS_CONTRL NOT IN (6,12)

				SET @row_count = @@ROWCOUNT

				--SELECT @row_count '@row_count'

				WHILE @row_id <= @row_count
				BEGIN
			
					SELECT @job_comp_nbr_in = JOB_COMPONENT_NBR FROM @job_component
					WHERE ROWID = @row_id

					IF @DEBUG = 1
						SELECT @JOB_NUMBER '@job_number', @job_comp_nbr_in '@job_comp_nbr_in', @cl_code '@cl_code', @div_code '@div_code', @prd_code '@prd_code'

					/* Insert into Account Executive table for current product if it does not exist - where @acct_exec_new was copied from original */
					IF @acct_exec_new IS NULL
					BEGIN
						SELECT @acct_exec_new = EMP_CODE FROM dbo.JOB_COMPONENT WHERE JOB_NUMBER = @job_number_in AND JOB_COMPONENT_NBR = @job_comp_nbr_in

						--SELECT @acct_exec_new '@acct_exec_new'

						SELECT @tmp_count = COUNT(EMP_CODE) FROM dbo.ACCOUNT_EXECUTIVE A			
						WHERE A.CL_CODE = @cl_code AND A.DIV_CODE = @div_code AND A.PRD_CODE = @prd_code AND A.EMP_CODE = @acct_exec_new

						SELECT @default_ae = MAX(DEFAULT_AE) FROM dbo.ACCOUNT_EXECUTIVE A	
						WHERE A.CL_CODE = @cl_code AND A.DIV_CODE = @div_code AND A.PRD_CODE = @prd_code AND A.EMP_CODE <> @acct_exec_new

						IF @default_ae = 1
							SET @default_ae = 0
						ELSE
							SET @default_ae = 1

						IF @tmp_count = 0
							INSERT INTO ACCOUNT_EXECUTIVE (
									[CL_CODE]
								   ,[DIV_CODE]
								   ,[PRD_CODE]
								   ,[EMP_CODE]
								   ,[INACTIVE_FLAG]
								   ,[DEFAULT_AE]
								   ,[MGMT_LVL_ID])
							VALUES (
								   @cl_code, 
								   @div_code, 
								   @prd_code, 
								   @acct_exec_new, 
								   0, 
								   @default_ae, 
								   1)

						--SET @acct_exec = @acct_exec_new
					END
					--ELSE
					--	SET @acct_exec_new = @acct_exec

					SELECT @job_tmplt_code = JOB_TMPLT_CODE, @job_comp_desc = CASE WHEN @job_comp_desc IS NULL THEN JOB_COMP_DESC ELSE @job_comp_desc END
					FROM JOB_COMPONENT
					WHERE JOB_NUMBER = @job_number_in AND JOB_COMPONENT_NBR = @job_comp_nbr_in

					BEGIN
						/* Copy Job Component */
						EXECUTE @RC = [dbo].[usp_wv_Job_Template_Copy_AddJobComponent]
							 @JOB_NUMBER
							,@job_number_in
							,@job_comp_nbr_in
							,@job_comp_desc
							,@job_tmplt_code
							,@include_task_start_and_due_dates /* Include Dates */
							,NULL --JT_CODE
							,@acct_exec_new
							,@JOB_COMPONENT_NBR OUTPUT
							,@date_time_w
							,NULL
							,@user_id

					END

					/* Update values specific to the API */ 
					BEGIN		
						UPDATE dbo.JOB_COMPONENT 
						SET AB_FLAG = 0
						WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
					END

					/* PJH 06/20/19 - Added */
					BEGIN
						UPDATE JOB_COMPONENT
						SET	MODIFIED_BY = UPPER(@user_id), MODIFY_DATE = @date_time_w
						WHERE JOB_NUMBER = @JOB_NUMBER AND
								JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
					END

					BEGIN	
					/* Uses Row ID's to copy from */	
						SET @list_str = NULL				
						SELECT @list_str = COALESCE(@list_str+',' ,'') + CAST(ROWID AS varchar(20))
						FROM JOB_COMPONENT
						WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR

						IF @DEBUG = 1
							SELECT @list_str 'COMPONENT ROW ID''s', @JOB_NUMBER 'JOB', @JOB_COMPONENT_NBR 'COMP'
					END

					IF @list_str IS NOT NULL
						BEGIN
							EXECUTE @RC = [dbo].[usp_wv_Traffic_Schedule_CopyToJobComponents] 
							   @job_number_in
							  ,@job_comp_nbr_in 
							  ,@list_str
							  ,1 --@ADD_SCHEDULE_IF_SCHEDULE_DOESNT_EXIST
							  ,0 --@UPDATE_SCHEDULE_IF_EXIST
							  ,@include_schedule --@INCLUDE_SCHEDULE_HEADER_DATA
							  ,@include_schedule --@INCLUDE_SCHEDULE_DETAIL_DATA
							  ,@include_task_start_and_due_dates --@INCLUDE_SCHEDULE_DETAIL_SCHEDULE_DATES
							  ,@include_task_employees --@INCLUDE_SCHEDULE_DETAIL_EMPLOYEE_ASSIGNMENTS
							  ,@include_task_comment --@INCLUDE_SCHEDULE_DETAIL_TASK_COMMENTS
							  ,@include_task_due_date_comment --@INCLUDE_SCHEDULE_DETAIL_DUE_DATE_COMMENTS
							  /* PJH 03/08/18 - Added Revision Comments */
							  ,@include_task_comment --@INCLUDE_SCHEDULE_DETAIL_REVISION_COMMENTS
							  ,0 --@UPDATE_COMPONENT_BUDGET
							  ,@user_id
						END

					/* Update values specific to the API */ 
					IF @list_str IS NOT NULL AND @status IS NOT NULL
					BEGIN		
						UPDATE dbo.JOB_TRAFFIC 
						SET TRF_CODE = @status
						WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
					END

					SET @row_id = @row_id + 1

				END /* While */
			END
		END
	END/* Job Number > 0 */

	IF @@TRANCOUNT > 0
		IF @DEBUG = 1
		BEGIN
			SELECT 'DEBUG' 'DESC'
				,@JOB_NUMBER '@job_number'
				,@JOB_COMPONENT_NBR '@job_component_nbr'
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
	SELECT 'JOB_COMPONENT' 'SRC', * FROM JOB_COMPONENT WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_TRAFFIC' 'SRC', * FROM JOB_TRAFFIC WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_TRAFFIC_DET' 'SRC', * FROM JOB_TRAFFIC_DET WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_TRAFFIC_DET_PREDS' 'SRC', * FROM JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_TRAFFIC_DET_EMPS' 'SRC', * FROM JOB_TRAFFIC_DET_EMPS WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_TRAFFIC_DET_CMTS' 'SRC', * FROM JOB_TRAFFIC_DET_CMTS WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_TRAFFIC_DET_CNTS' 'SRC', * FROM JOB_TRAFFIC_DET_CNTS WHERE JOB_NUMBER = @job_number
	SELECT 'JOB_TRAFFIC_DET_DOCS' 'SRC', * FROM JOB_TRAFFIC_DET_DOCS WHERE JOB_NUMBER = @job_number
	SELECT 'ACCOUNT_EXECUTIVE' 'SRC', * 	FROM ACCOUNT_EXECUTIVE WHERE EMP_CODE = @acct_exec_new AND  CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code
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

GRANT EXECUTE ON [advsp_job_comp_copy_api] TO PUBLIC AS dbo
GO