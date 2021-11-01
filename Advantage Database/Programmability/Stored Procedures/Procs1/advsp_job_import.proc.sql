IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_import]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_import]
GO

CREATE PROCEDURE [dbo].[advsp_job_import] @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6), @office_code varchar(4) = NULL,
	@sales_class varchar(6), @job_desc varchar(60), @acct_exec varchar(6), @job_comp_desc varchar(60) = NULL, @cli_ref varchar(30) = NULL,
	@cmp_id integer = NULL, @complex_code varchar(8) = NULL, @job_type varchar(10) = NULL, @dp_tm_code varchar(4) = NULL, 
	@due_date smalldatetime = NULL, @job_number integer OUTPUT, @add_comp bit = 0, @ret_val integer OUTPUT, @user_id varchar(100) = NULL
AS

  /* NOT USED IN .Net AT THIS POINT */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

SET NOCOUNT ON

PRINT @job_number

CREATE TABLE #validation_errors(
	COLUMN_NAME		varchar(32) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	INVALID_VALUE	varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS NULL )

DECLARE @row_count integer, @cmp_code varchar(6), @job_comp_nbr integer

BEGIN TRANSACTION

SELECT @ret_val = 0

IF @ret_val = 0
BEGIN
	-- Validate Client
	SELECT @row_count = ( SELECT COUNT(*) FROM dbo.CLIENT WHERE CL_CODE = @cl_code AND ACTIVE_FLAG = 1 )

	IF @row_count <> 1
	BEGIN
		-- Invalid/Closed Client
		SELECT @ret_val = -2
		INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'CL_CODE', CAST( @cl_code AS varchar(254) ))
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
		INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'DIV_CODE', CAST( @div_code AS varchar(254) ))
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
		INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'PRD_CODE', CAST( @prd_code AS varchar(254) ))
	END	
END

IF ( @add_comp = 0 )
BEGIN

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
			INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'OFFICE_CODE', CAST( @office_code AS varchar(254) ))
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
			INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'SC_CODE', CAST( @sales_class AS varchar(254) ))
		END	
	END

	IF ( @ret_val = 0 )
	BEGIN
		-- Validate Job Desc
		IF ( @job_desc IS NULL )
		BEGIN
			-- Blank Job Description
			SELECT @ret_val = -7
			INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'JOB_DESC', CAST( @job_desc AS varchar(254) ))
		END	
	END

	IF ( @ret_val = 0 AND @cmp_id > 0 )
	BEGIN
		-- Validate Campaign
		SELECT @row_count = ( SELECT COUNT(*) 
								FROM dbo.CAMPAIGN 
							   WHERE CMP_IDENTIFIER = @cmp_id 
								 AND CL_CODE = @cl_code
								 AND DIV_CODE = @div_code
								 AND PRD_CODE = @prd_code
								 AND CMP_TYPE = 2	
								 AND ( CMP_CLOSED IS NULL OR CMP_CLOSED = 0 ))

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Campaign
			SELECT @ret_val = -8
			INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'CMP_IDENTIFIER', CAST( @cmp_id AS varchar(254) ))
		END	

		SELECT @cmp_code = ( SELECT CMP_CODE FROM dbo.CAMPAIGN WHERE CMP_IDENTIFIER = @cmp_id )
	END

	IF ( @ret_val = 0 AND @complex_code IS NOT NULL )
	BEGIN
		-- Validate Complexity
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.COMPLEXITY WHERE COMPLEX_CODE = @complex_code AND ( ACTIVE = 1 OR ACTIVE IS NULL ))

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Complexity
			SELECT @ret_val = -9
			INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'COMPLEX_CODE', CAST( @complex_code AS varchar(254) ))
		END	
	END

	-- *******************************************************************************************************************************************
	IF @ret_val = 0
	BEGIN
		-- Get next Job Number
		SELECT @job_number = ( SELECT LAST_NBR + 1 FROM dbo.ASSIGN_NBR  WHERE COLUMNNAME = 'JOB_NUMBER' )
 
		IF ( @job_number > 99999999 ) OR ( @job_number IS NULL )
			SELECT @job_number = 1

		UPDATE dbo.ASSIGN_NBR SET LAST_NBR = @job_number WHERE COLUMNNAME = 'JOB_NUMBER'

		IF ( @@ERROR <> 0 ) 
			SELECT @ret_val = -14		
		ELSE
			-- Insert new Job
			INSERT INTO dbo.JOB_LOG ( 
					JOB_NUMBER, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, SC_CODE, [USER_ID], 
					CREATE_DATE, JOB_DESC, JOB_DATE_OPENED, JOB_RUSH_CHARGES, JOB_CLI_REF, COMPLEX_CODE, CMP_IDENTIFIER, 
					JOB_ESTIMATE_REQ )
				 SELECT @job_number, @office_code, @cl_code, @div_code, @prd_code, @cmp_code, @sales_class, dbo.fn_AdvanUser(), 
						GETDATE(), @job_desc, CONVERT( varchar(10), GETDATE(), 101 ), 0, @cli_ref, @complex_code, @cmp_id, 
						COALESCE( PRD_PROD_ESTIMATE, APPR_EST_REQ )
				   FROM dbo.PRODUCT, dbo.AGENCY
				  WHERE CL_CODE = @cl_code
				    AND DIV_CODE = @div_code
				    AND PRD_CODE = @prd_code
					
		IF ( @@ERROR <> 0 ) 
			SELECT @ret_val = -14		
	END
END

-- Validate Job
IF ( @ret_val = 0 )
BEGIN
	SELECT @row_count = ( SELECT COUNT(*) 
							FROM dbo.JOB_LOG
						   WHERE JOB_NUMBER = @job_number )

	IF @row_count <> 1
	BEGIN
		-- Invalid Job
		SELECT @ret_val = -1
		INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'JOB_NUMBER', CAST( @job_number AS varchar(254) ))
	END	
END

IF ( @ret_val = 0 )
BEGIN
	-- Validate Job Comp Desc
	IF ( @job_comp_desc IS NULL )
		SELECT @job_comp_desc = ( SELECT JOB_DESC FROM dbo.JOB_LOG WHERE JOB_NUMBER = @job_number )
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
		INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'ACCOUNT_EXECUTIVE', CAST( @acct_exec AS varchar(254) ))
	END	
END

IF ( @ret_val = 0 AND @job_type IS NOT NULL )
BEGIN
	-- Validate Job Type
	SELECT @row_count = ( SELECT COUNT(*) FROM dbo.JOB_TYPE WHERE JT_CODE = @job_type AND ( INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL ))

	IF ( @row_count <> 1 )
	BEGIN
		-- Invalid/Inactive Job Type
		SELECT @ret_val = -99
		INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'JOB_TYPE_CODE', CAST( @job_type AS varchar(254) ))
	END	
END

IF ( @ret_val = 0 AND @dp_tm_code IS NOT NULL )
BEGIN
	-- Validate Dept/Team
	SELECT @row_count = ( SELECT COUNT(*) FROM dbo.DEPT_TEAM WHERE DP_TM_CODE = @dp_tm_code AND ( INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL ))

	IF @row_count <> 1
	BEGIN
		-- Invalid/Inactive Dept/Team
		SELECT @ret_val = -13
		INSERT INTO #validation_errors ( COLUMN_NAME, INVALID_VALUE ) VALUES ( 'DP_TM_CODE', CAST( @dp_tm_code AS varchar(254) ))
	END	
END

IF ( @ret_val = 0 )
BEGIN
	-- Get next Job Comp Number
	SELECT @job_comp_nbr = ( SELECT COALESCE( MAX( JOB_COMPONENT_NBR ), 0 ) + 1 FROM dbo.JOB_COMPONENT WHERE JOB_NUMBER = @job_number )

	-- Insert new Job Component
	INSERT INTO dbo.JOB_COMPONENT ( 
			JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, JOB_COMP_DATE, JOB_FIRST_USE_DATE, JOB_SPEC_TYPE, DP_TM_CODE, JOB_PROCESS_CONTRL,
			JOB_COMP_DESC, AB_FLAG, JT_CODE, NOBILL_FLAG, JOB_MARKUP_PCT, EMAIL_GR_CODE )
		 SELECT TOP 1 @job_number, @job_comp_nbr, @acct_exec, CONVERT( varchar(10), GETDATE(), 101 ), @due_date, 0, @dp_tm_code, 1, 
			@job_comp_desc, 0, @job_type, 0, PRD_PROD_MARKUP, EMAIL_GR_CODE
		   FROM dbo.PRODUCT
		  WHERE CL_CODE = @cl_code
		    AND DIV_CODE = @div_code
		    AND PRD_CODE = @prd_code
			
	IF ( @@ERROR <> 0 ) 
		SELECT @ret_val = -15		
END

IF ( @ret_val = 0 )
BEGIN
	IF ( @add_comp = 0 )
		SELECT @ret_val = @job_number
	ELSE
		SELECT @ret_val = @job_comp_nbr
		
	COMMIT TRANSACTION	
END
ELSE
	ROLLBACK TRANSACTION

SELECT * FROM #validation_errors

GO

GRANT EXECUTE ON [advsp_job_import] TO PUBLIC
GO