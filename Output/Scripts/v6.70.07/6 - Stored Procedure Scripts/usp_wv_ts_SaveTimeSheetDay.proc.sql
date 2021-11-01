if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_ts_SaveTimeSheetDay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
    drop procedure [dbo].[usp_wv_ts_SaveTimeSheetDay]
GO

CREATE PROCEDURE [dbo].[usp_wv_ts_SaveTimeSheetDay] /*WITH ENCRYPTION*/
@et_id INTEGER, 
@etd_id INTEGER, 
@emp_code VARCHAR(6), 
@emp_date SMALLDATETIME, 
@fnc_cat VARCHAR(10), 
@emp_hrs DECIMAL(9,3), 
@job_nbr INTEGER, 
@job_cmp_nbr SMALLINT, 
@dp_tm VARCHAR(4),
@start_time char(4), 
@end_time char(4),	
@ProdCat VARCHAR(10), 
@USER_CODE VARCHAR(100), 
@comments NTEXT, 
@taskCode VARCHAR(10) = NULL,
@error_text VARCHAR(4000) OUTPUT,
@CREATE_DATE SMALLDATETIME,
@ALERT_ID INT = NULL,
@ALLOW_DUPLICATE BIT = 0
AS
BEGIN
/*=========== QUERY ===========*/

/*
	Custom Error Codes:
	0 = Success
	1002 = Success
	-2 = Invalid function
	-3 = Invalid time category
	-4 = Process control does not allow editing
	-5 = wvfn_ts_can_edit returns false
	-6 = No access to client
	-7 = No access to division
	-8 = No access to product
	-9 = No access to job
	-10 = No access due to process control
	-11 = Comment required
	-12 = [wvfn_ts_can_insert] returned false
	-13 = No dept team
	-14 = Approved estimate required but not found
	-15 = Actual hours plus this entry will exceed approved estimate, warn
	-16 = Actual hours plus this entry will exceed approved estimate, block
	-17 = Approved estimate required but not found, block
	-18 = Invalid task code
	-19 = Function has inactive dept/team
	-20 = Single entry exceeds 24 hours
*/

DECLARE 
    @error_code INTEGER, 
    @billing_rate DECIMAL(10,3), 
    @nobill SMALLINT, 
    @DB_HOURS DECIMAL (7,3),
	@TIME_UNIQUE_ROW BIT

--	INIT
BEGIN
	SET @error_code = 0;
	-- removes time from date 
	SET @emp_date = DATEADD(dd, DATEDIFF(dd, 0, @emp_date), 0);
END

BEGIN
	SELECT @TIME_UNIQUE_ROW = ISNULL(TIME_UNIQUE_ROW, 0) FROM AGENCY WITH(NOLOCK);
	IF EXISTS (SELECT 1 FROM APP_VARS WHERE USERID = @USER_CODE AND [APPLICATION] = 'NewTimesheet' AND VARIABLE_NAME = 'AddUniqueRowWhenComment')
	BEGIN
		SELECT 
			@TIME_UNIQUE_ROW =	CASE
									WHEN UPPER(VARIABLE_VALUE) = 'TRUE' THEN CAST(1 AS BIT)
									ELSE CAST(0 AS BIT)
								END
		FROM APP_VARS WHERE USERID = @USER_CODE AND [APPLICATION] = 'NewTimesheet' AND VARIABLE_NAME = 'AddUniqueRowWhenComment'
	END
	SET @TIME_UNIQUE_ROW = ISNULL(@TIME_UNIQUE_ROW, 0);
END

-- When @TIME_UNIQUE_ROW is false, add to existing comment.
-- When @TIME_UNIQUE_ROW is true, create a new row


--	See if there is an existing entry
IF (@et_id IS NULL OR @et_id = 0) AND (@etd_id IS NULL OR @etd_id = 0) AND (@TIME_UNIQUE_ROW = 0 OR @ALLOW_DUPLICATE = 0)
BEGIN
	IF @TIME_UNIQUE_ROW = 1 AND (NOT @comments IS NULL OR DATALENGTH(@comments) > 0)
	BEGIN
		SET @et_id = 0;
		SET @etd_id = 0;
	END
	ELSE
	BEGIN
		DECLARE
			@EXISTING_ET_ID INT,
			@EXISTING_ETD_ID INT,
			@EXISTING_HOURS DECIMAL (9,3),
			@EXISTING_COMMENT VARCHAR(MAX)

		IF (NOT @comments IS NULL OR DATALENGTH(@comments) > 0)
		BEGIN
			--	IF NEW ENTRY HAS A COMMENT, FIRST TRY TO FIND EXISTING ENTRY WITH A COMMENT
			SELECT 
				@EXISTING_ET_ID = ET_ID, 
				@EXISTING_ETD_ID = ETD_ID, 
				@EXISTING_HOURS = EMP_HOURS, 
				@EXISTING_COMMENT = COMMENT 
			FROM 
				[dbo].[advtf_find_open_time_entry] (@emp_code, @emp_date, @emp_hrs, @job_nbr, @job_cmp_nbr, @fnc_cat, @ALERT_ID, 1);
			--  IF NOT FOUND, LOOK FOR ONE WITHOUT A COMMENT
			IF (@EXISTING_ET_ID IS NULL OR @EXISTING_ET_ID = 0) OR (@EXISTING_ETD_ID IS NULL OR @EXISTING_ETD_ID = 0)
			BEGIN
				SELECT 
					@EXISTING_ET_ID = ET_ID, 
					@EXISTING_ETD_ID = ETD_ID, 
					@EXISTING_HOURS = EMP_HOURS, 
					@EXISTING_COMMENT = COMMENT 
				FROM 
					[dbo].[advtf_find_open_time_entry] (@emp_code, @emp_date, @emp_hrs, @job_nbr, @job_cmp_nbr, @fnc_cat, @ALERT_ID, 0);
			END
		END
		ELSE
		BEGIN
			--  IF NEW ENTRY DOES NOT HAVE A COMMENT, FIRST TRY TO FIND EXISTING ENTRY WITHOUT A COMMENT
			SELECT 
				@EXISTING_ET_ID = ET_ID, 
				@EXISTING_ETD_ID = ETD_ID, 
				@EXISTING_HOURS = EMP_HOURS, 
				@EXISTING_COMMENT = COMMENT 
			FROM 
				[dbo].[advtf_find_open_time_entry] (@emp_code, @emp_date, @emp_hrs, @job_nbr, @job_cmp_nbr, @fnc_cat, @ALERT_ID, 0);
			--  IF NOT FOUND, LOOK FOR ONE WITH A COMMENT
			IF (@EXISTING_ET_ID IS NULL OR @EXISTING_ET_ID = 0) OR (@EXISTING_ETD_ID IS NULL OR @EXISTING_ETD_ID = 0)
			BEGIN
				SELECT 
					@EXISTING_ET_ID = ET_ID, 
					@EXISTING_ETD_ID = ETD_ID, 
					@EXISTING_HOURS = EMP_HOURS, 
					@EXISTING_COMMENT = COMMENT 
				FROM 
					[dbo].[advtf_find_open_time_entry] (@emp_code, @emp_date, @emp_hrs, @job_nbr, @job_cmp_nbr, @fnc_cat, @ALERT_ID, 1);
			END
		END
		IF @EXISTING_ET_ID > 0 AND @EXISTING_ETD_ID > 0 
		BEGIN
			IF @EXISTING_HOURS + @emp_hrs > 24
			BEGIN
				--SET @error_code = -20;
				--SET @error_text = 'Single entry cannot exceed 24 hours.';
				SET @et_id = 0;
				SET @etd_id = 0;
			END
			ELSE
			BEGIN
				DECLARE @HAS_EXISTING_CMT BIT, @HAS_NEW_CMT BIT;
				SET @HAS_EXISTING_CMT = 0;
				SET @HAS_NEW_CMT = 0;
				SET @et_id = @EXISTING_ET_ID;
				SET @etd_id = @EXISTING_ETD_ID;
				SET @emp_hrs = @EXISTING_HOURS + @emp_hrs;
				IF ISNULL(CAST(@EXISTING_COMMENT AS VARCHAR(MAX)), '') = '' OR DATALENGTH(ISNULL(CAST(@EXISTING_COMMENT AS VARCHAR(MAX)), '')) = 0 OR LEN(RTRIM(LTRIM(REPLACE(CAST(@EXISTING_COMMENT AS VARCHAR(MAX)),CHAR(13)+CHAR(10),'')))) = 0
				BEGIN
					SET @HAS_EXISTING_CMT = 0;
				END
				ELSE
				BEGIN
					SET @HAS_EXISTING_CMT = 1;
				END
				IF ISNULL(CAST(@comments AS VARCHAR(MAX)), '') = '' OR DATALENGTH(ISNULL(CAST(@comments AS VARCHAR(MAX)), '')) = 0 OR LEN(RTRIM(LTRIM(REPLACE(CAST(@comments AS VARCHAR(MAX)),CHAR(13)+CHAR(10),'')))) = 0
				BEGIN
					SET @HAS_NEW_CMT = 0;
				END
				ELSE
				BEGIN
					SET @HAS_NEW_CMT = 1;
				END
				IF @HAS_EXISTING_CMT = 1 AND @HAS_NEW_CMT = 1
				BEGIN
					SET @comments = CAST( 
										ISNULL(CAST(@EXISTING_COMMENT AS VARCHAR(MAX)), '') + 
										CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 
										ISNULL(CAST(@comments AS VARCHAR(MAX)), '') 
									AS NTEXT);
				END
				IF @HAS_EXISTING_CMT = 1 AND @HAS_NEW_CMT = 0
				BEGIN
					SET @comments = CAST(ISNULL(CAST(@EXISTING_COMMENT AS VARCHAR(MAX)), '') AS NTEXT);
				END
				IF @HAS_EXISTING_CMT = 0 AND @HAS_NEW_CMT = 1
				BEGIN
					SET @comments = CAST(ISNULL(CAST(@comments AS VARCHAR(MAX)), '') AS NTEXT);
				END
			END
		END
	END
END

IF @error_code = 0
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
        BEGIN TRANSACTION
            DECLARE 
			 @cl_code VARCHAR(6), 
			 @div_code VARCHAR(6), 
			 @prd_code VARCHAR(6), 
			 @ab_flag SMALLINT, 
			 @return_value INTEGER,
			 @cost_rate DECIMAL(9,2), 
			 @rate_from VARCHAR(300), 
			 @tax_code VARCHAR(6), 
			 @state_pct DECIMAL(9,3), 
			 @county_pct DECIMAL(9,3), 
			 @city_pct DECIMAL(9,3), 
			 @tax_comm SMALLINT, 
			 @tax_comm_only SMALLINT, 
			 @comm DECIMAL(9,3), 
			 @tax_flag SMALLINT, 
			 @time_type char(1),
			 @temp_id INTEGER, 
			 @total_cost DECIMAL(14,3), 
			 @total_bill DECIMAL(14,3), 
			 @ext_markup_amt DECIMAL(14,3),
			 @state_tax DECIMAL(14,3), 
			 @county_tax DECIMAL(14,3), 
			 @city_tax DECIMAL(14,3), 
			 @line_total DECIMAL(14,3),
			 @limit_etf VARCHAR(1), 
			 @fnc_dp_tm VARCHAR(4),
			 @freelance SMALLINT, 
			 @officecode char(4),
			 @start_end_active SMALLINT, 
			 @temp_dp_tm VARCHAR(4), 
			 @fee_time SMALLINT,
			 @EMPLOYEE_TITLE_ID INT,
			 @SEC_USER_ID INT,
			 @HAS_COMMENT BIT,
			 @FN_INACTIVE_DEPT BIT,
			 @CURR_FNC_CODE VARCHAR(10),
             @CURR_DP_TM VARCHAR(10),
			 @CURR_CAT_CODE VARCHAR(10),
			 @FUNCTION_DEPT_TEAM VARCHAR(10)

            IF RTRIM(LTRIM(@ProdCat)) = '' OR DATALENGTH(RTRIM(LTRIM(@ProdCat))) = 0
            BEGIN
                SET @ProdCat = NULL;
            END
            IF RTRIM(LTRIM(@taskCode)) = '' OR DATALENGTH(RTRIM(LTRIM(@taskCode))) = 0
            BEGIN
                SET @taskCode = NULL;
            END
			IF @ALERT_ID = 0
			BEGIN
				SET @ALERT_ID = NULL;
			END

			--IF DATALENGTH(@comments) > 0
			--BEGIN
			--	SET @HAS_COMMENT = 1;
			--END
			--ELSE
			--BEGIN
			--	SET @HAS_COMMENT = 0;
			--END

            SELECT @EMPLOYEE_TITLE_ID = EMPLOYEE_TITLE_ID FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = @emp_code;
            SELECT @start_end_active = ( SELECT START_END_TIME FROM AGENCY  WITH (NOLOCK));
			SELECT @FN_INACTIVE_DEPT = 0;

			-- Set minimum and rounding options
			SELECT @emp_hrs = dbo.wvfn_ts_minimum_time_entry (@emp_hrs, 1);
			SELECT @emp_hrs = dbo.wvfn_ts_round_up_time_entry (@emp_hrs, 1);

			-- DIRECT TIME:
			IF @job_nbr IS NOT NULL AND @job_nbr > 0 
			BEGIN

				DECLARE 
					@EST_CHECK_CAN_MODIFY_TIME BIT,
					@EST_EXCEED_OPTION SMALLINT, -- 0 = YES (ALLOW, NO MESSAGE NEEDED), 1 = WARN (ALLOW BUT SHOW WARNING MESSAGE), 2 = NO  (DON'T ALLOW, SHOW MESSAGE)
					@SUM_ACTUAL DECIMAL(32,2),
					@SUM_APPROVED DECIMAL (32,2),
					@APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND BIT,
					@IS_OVER_ESTIMATE_AMOUNT BIT,
					@SEQ_NBR SMALLINT,
					@SUMMARIZED_REC_COUNT INT;

					SET @EST_CHECK_CAN_MODIFY_TIME = 0;
					SET @EST_EXCEED_OPTION = 0;
					SET @SEQ_NBR = NULL;

				-- CHECK IF SUMMARIZED
				BEGIN
					SELECT @SUMMARIZED_REC_COUNT = COUNT(1)
					FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
					WHERE  etd.ET_ID = @et_id
							AND etd.ET_DTL_ID = @etd_id;						
					IF @SUMMARIZED_REC_COUNT > 1
					BEGIN
						SELECT @SEQ_NBR = MAX(SEQ_NBR) FROM EMP_TIME_DTL WITH(NOLOCK) WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id AND (EDIT_FLAG = 0 OR EDIT_FLAG IS NULL);
						--  IF NO OPEN SEQ FOUND, TREAT AS NEW ENTRY
						IF @SEQ_NBR IS NULL 
						BEGIN
							IF @et_id > 0 OR @etd_id > 0
							BEGIN
								SELECT
									@et_id = 0,
									@etd_id = 0;
							END
						END
					END
				END
				-- SET TIME TYPE
				BEGIN
					SELECT @time_type = 'D';
				END
				-- SET DEFAULT JOB_COMPONENT_NBR IF NOT SUPPLIED
				BEGIN
					SELECT @job_cmp_nbr = ( SELECT ISNULL( @job_cmp_nbr, 1 ));
				END
				-- CHECK COMMENT REQ
				BEGIN
					DECLARE @COMMENT_REQUIRED_TABLE TABLE (REQ_TIME_COMMENT BIT);
					DECLARE @comment_req BIT;				
					INSERT INTO @COMMENT_REQUIRED_TABLE
					EXEC [dbo].[usp_wv_ts_DetailRequireComment] @job_nbr, @et_id, @etd_id;
					SELECT @comment_req = ISNULL(REQ_TIME_COMMENT, 0) FROM @COMMENT_REQUIRED_TABLE;
					IF @comment_req = 1 AND  DATALENGTH(  RTRIM(LTRIM(CAST(@comments AS VARCHAR(MAX))))  ) = 0
					BEGIN
						SET @error_code = -11;
						SET @error_text = 'Comment required';
					END
				END
				-- CHECK PROCESS CONTROL
				IF @error_code = 0
				BEGIN
					IF EXISTS(SELECT 1 
							  FROM JOB_COMPONENT WITH(NOLOCK) 
							  WHERE JOB_NUMBER = @job_nbr 
							  AND JOB_COMPONENT_NBR = @job_cmp_nbr
							  AND JOB_PROCESS_CONTRL IN ( 2, 3, 5, 6, 9, 10, 12, 13 ))
					BEGIN

						SET @error_code = -4;
						SET @error_text = 'Cannot edit due to Job Processing Control';

					END
				END
				-- GET JOB INFO
				IF @error_code = 0
				BEGIN

					SELECT 
						@cl_code = CL_CODE, 
						@div_code = DIV_CODE, 
						@prd_code = PRD_CODE, 
						@ab_flag = AB_FLAG
					FROM 
						JOB_COMPONENT AS jc WITH (NOLOCK), JOB_LOG AS jl  WITH (NOLOCK)
					WHERE 
						jc.JOB_NUMBER = jl.JOB_NUMBER
						AND jc.JOB_NUMBER = @job_nbr
						AND jc.JOB_COMPONENT_NBR = @job_cmp_nbr
						AND JOB_PROCESS_CONTRL NOT IN ( 2, 3, 5, 6, 9, 10, 12, 13 );

				END
				-- SET AB FLAG
				IF @error_code = 0
				BEGIN
					IF @ab_flag IN ( 1, 2 )
					BEGIN
						SELECT @ab_flag = 2;
					END
					ELSE
					BEGIN
						SELECT @ab_flag = 0;
					END
				END
				-- VALIDATE FUNCTION
				IF @et_id IS NOT NULL AND @et_id > 0  
				BEGIN
					IF @time_type = 'D'
					BEGIN
						SELECT 
							@CURR_FNC_CODE = FNC_CODE, 
							@CURR_DP_TM = DP_TM_CODE 
						FROM 
							EMP_TIME_DTL 
						WHERE 
							ET_ID = @et_id 
							AND ET_DTL_ID = @etd_id;
						IF @fnc_cat IS NULL OR @fnc_cat = '' OR DATALENGTH(@fnc_cat) = 0
						BEGIN
							SET @fnc_cat = @CURR_FNC_CODE
						END
						IF @dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0
						BEGIN
							SET @dp_tm = @CURR_DP_TM
						END
					END
					ELSE
					BEGIN
						SELECT 
							@CURR_CAT_CODE = CATEGORY, 
							@CURR_DP_TM = DP_TM_CODE 
						FROM 
							EMP_TIME_NP 
						WHERE 
							ET_ID = @et_id 
							AND ET_DTL_ID = @etd_id;
						IF @fnc_cat IS NULL OR @fnc_cat = '' OR DATALENGTH(@fnc_cat) = 0
						BEGIN
							SET @fnc_cat = @CURR_CAT_CODE
						END
						IF @dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0
						BEGIN
							SET @dp_tm = @CURR_DP_TM
						END
					END

				END
				IF @error_code = 0
				BEGIN

					SELECT @SEC_USER_ID = SEC_USER_ID FROM [dbo].[SEC_USER] WITH(NOLOCK) WHERE UPPER(EMP_CODE) = UPPER(@emp_code);
		
					IF EXISTS(SELECT * FROM [dbo].[SEC_USER_SETTING] WHERE SEC_USER_ID = @SEC_USER_ID AND SETTING_CODE = 'EMP_TS_FNC' AND STRING_VALUE = 'Y') 
					BEGIN

						SET @limit_etf = 'Y';

					END
						
					IF @limit_etf = 'Y'
					BEGIN

						SELECT @return_value = (SELECT COUNT(1) 
						FROM EMP_TS_FNC AS etf WITH (NOLOCK), FUNCTIONS AS f  WITH (NOLOCK)
						WHERE f.FNC_CODE = @fnc_cat 
						AND f.FNC_CODE = etf.FNC_CODE
						AND EMP_CODE = @emp_code
						AND FNC_TYPE = 'E'
						AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 ));

					END
					ELSE
					BEGIN

						SELECT @return_value = (SELECT COUNT(1) 
						FROM FUNCTIONS  WITH (NOLOCK)
						WHERE FNC_CODE = @fnc_cat 
						AND FNC_TYPE = 'E'
						AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 ));

					END

					IF @return_value = 0
					BEGIN

						SELECT @error_code = -2; -- Invalid function
						SELECT @error_text = 'Invalid function';

					END

					IF @error_code = 0
					BEGIN

						DECLARE @LIMIT_FN_BILLING BIT

						SELECT @LIMIT_FN_BILLING = ISNULL(LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY, 0) FROM CLIENT WHERE CL_CODE = @cl_code;
						
						IF NOT @LIMIT_FN_BILLING IS NULL AND @LIMIT_FN_BILLING = 1
						BEGIN

							IF EXISTS (SELECT 1 FROM BILLING_RATE WHERE FNC_CODE = @fnc_cat AND CL_CODE = @cl_code)
							BEGIN

								SET @error_code = 0;

							END
							ELSE
							BEGIN

								SELECT @error_code = -2; -- Invalid function
								SELECT @error_text = 'Invalid function';

							END

						END

					END

				END				
				-- CHECK FUNCTION FOR DEPT/TEAM CODE
				IF @error_code = 0
				BEGIN
					SELECT @temp_dp_tm = DP_TM_CODE FROM FUNCTIONS  WITH (NOLOCK) WHERE FNC_CODE = @fnc_cat;
					IF (NOT @temp_dp_tm IS NULL) AND (RTRIM(LTRIM(@temp_dp_tm)) <> '')
					BEGIN
						IF (SELECT COUNT(1) FROM DEPT_TEAM WITH(NOLOCK) WHERE DP_TM_CODE = @temp_dp_tm AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)) > 0
						BEGIN
							SELECT	@dp_tm = @temp_dp_tm; --	override only if the function's dept team is inactive
							SELECT @FUNCTION_DEPT_TEAM = @temp_dp_tm;
						END
						ELSE
						BEGIN
							-- Function has inactive dept/team
							SET @FN_INACTIVE_DEPT = 1;
						END
					END 
				END	 
				-- VALIDATE TASK CODE
				IF @error_code = 0
				BEGIN					
					IF EXISTS (SELECT * FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TS_TASK_ONLY' AND AGY_SETTINGS_VALUE = 1)
					BEGIN					
						IF @taskCode IS NULL OR NOT EXISTS (SELECT * FROM dbo.TRAFFIC_FNC WHERE TRF_CODE = @taskCode) 
						BEGIN
							SELECT @error_code = -18;
							SELECT @error_text = 'Invalid task code';									
						END
						IF @error_code = 0
						BEGIN							
							DECLARE @CheckInactiveTaskCode AS BIT
							SET @CheckInactiveTaskCode = 0
							IF @et_id <> 0 AND @etd_id <> 0
							BEGIN
								IF NOT EXISTS (SELECT * FROM dbo.EMP_TIME_DTL WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id AND TRF_CODE = @taskCode) -- record exists but task code changed, check for inactive
								BEGIN									
									SET @CheckInactiveTaskCode = 1;
								END
							END
							ELSE
							BEGIN
								SET @CheckInactiveTaskCode = 1 -- new record, must be active task
							END
							IF @CheckInactiveTaskCode = 1 
							BEGIN
								IF NOT EXISTS (SELECT * FROM dbo.TRAFFIC_FNC WHERE TRF_CODE = @taskCode AND ISNULL(TRF_INACTIVE, 0) = 0)
								BEGIN								
									SELECT @error_code = -18;
									SELECT @error_text = 'Invalid task code';										
								END
							END
						END
					END
					ELSE
					BEGIN

						SET @taskCode = null;

					END
				END
				-- UPDATE/INSERT DIRECT TIME
				IF @error_code = 0 
			    BEGIN					
					-- GET EMPLOYEE BILLING RATES
					BEGIN
						BEGIN TRANSACTION tranSetEmpRates
						
							-- SUPPRESS THE TEST DATA SO THAT PROCEDURE RETURNS ONLY ONE TABLE (THE SUCCESS/FAIL MESSAGE)
							DECLARE @RATES TABLE (BILLING_RATE DECIMAL(9,3), 
												  RATE_FROM VARCHAR(254),
												  COST_RATE DECIMAL(9,2), 
												  TAXABLE SMALLINT, 
												  TAX_CODE VARCHAR(4), 
												  NONBILLABLE SMALLINT,
												  CITY_PCT DECIMAL(9,3), 
												  COUNTY_PCT DECIMAL(9,3), 
												  STATE_PCT DECIMAL(9,3),
												  COMMISSION DECIMAL(9,3),
												  TAX_COM SMALLINT, 
												  TAX_COMM_ONLY SMALLINT,
												  FEE_TIME SMALLINT)

							INSERT INTO @RATES
							EXECUTE sp_get_emp_rates @emp_code, @emp_date, @fnc_cat, @cl_code, @div_code, @prd_code, @job_nbr, @job_cmp_nbr, 
													 @billing_rate OUTPUT, @rate_from OUTPUT, @cost_rate OUTPUT, @tax_flag OUTPUT, 
													 @tax_code OUTPUT, @nobill OUTPUT, @city_pct OUTPUT, @county_pct OUTPUT, @state_pct OUTPUT, 
													 @comm OUTPUT, @tax_comm OUTPUT, @tax_comm_only OUTPUT, @fee_time OUTPUT;

						COMMIT TRANSACTION tranSetEmpRates
					END
					-- SET NULL NUMBERS TO ZERO FOR MATH
			        BEGIN    
						SELECT @total_bill = ROUND( @billing_rate * @emp_hrs, 3 );
						SELECT @total_cost = ROUND( @cost_rate * @emp_hrs, 3 );
						SELECT @ext_markup_amt = ROUND( @total_bill * @comm / 100, 3 );
				    END					
					-- SET APPROVED ESTIMATE RATE TEXT    
					IF @rate_from IS NULL
					BEGIN
						SET @rate_from = 'Approved Estimate';
					END
					-- CHECK AGENCY "Apply Tax Upon Billing"
					-- Values here are trying to match results from pre-.NET ADV time sheet:
					BEGIN
						DECLARE 
							@APPLY_TAX_UPON_BILLING BIT,
							@TAX_RESALE SMALLINT;

						SELECT @APPLY_TAX_UPON_BILLING = ISNULL(INV_TAX_FLAG, 0) FROM AGENCY WITH (NOLOCK);
						SET @TAX_RESALE = 1;

						IF @APPLY_TAX_UPON_BILLING = 1
						BEGIN

							SET @tax_flag = 0;
							SET @tax_code = NULL;
							SET @tax_comm = 0;
							SET @TAX_RESALE = NULL;
							SET @city_pct = 0;
							SET @county_pct = 0;
							SET @state_pct = 0;
							SET @state_tax = 0;
							SET @county_tax = 0;
							SET @city_tax = 0;

						END
					END
				    -- CALCULATE TAX
				    IF @tax_flag = 1
					BEGIN

						IF @tax_comm_only = 1
						BEGIN	
															
							EXECUTE usp_wv_ts_calc_prod_resale 0, @ext_markup_amt, @state_pct, @state_tax OUTPUT;
							EXECUTE usp_wv_ts_calc_prod_resale 0, @ext_markup_amt, @county_pct, @county_tax OUTPUT;
							EXECUTE usp_wv_ts_calc_prod_resale 0, @ext_markup_amt, @city_pct, @city_tax OUTPUT;

						END
						ELSE		
						BEGIN

							IF @tax_comm = 1	
							BEGIN

								EXECUTE usp_wv_ts_calc_prod_resale @total_bill, @ext_markup_amt, @state_pct, @state_tax OUTPUT;
								EXECUTE usp_wv_ts_calc_prod_resale @total_bill, @ext_markup_amt, @county_pct, @county_tax OUTPUT;
								EXECUTE usp_wv_ts_calc_prod_resale @total_bill, @ext_markup_amt, @city_pct, @city_tax OUTPUT;

							END
							ELSE
							BEGIN

								EXECUTE usp_wv_ts_calc_prod_resale @total_bill, 0, @state_pct, @state_tax OUTPUT;
								EXECUTE usp_wv_ts_calc_prod_resale @total_bill, 0, @county_pct, @county_tax OUTPUT;
								EXECUTE usp_wv_ts_calc_prod_resale @total_bill, 0, @city_pct, @city_tax OUTPUT;

							END

						END	

					END
				    ELSE
					BEGIN

						SELECT @state_tax = 0;
						SELECT @county_tax = 0;
						SELECT @city_tax = 0;

					END
					-- SET NULL NUMBERS TO ZERO FOR MATH
					BEGIN
						SELECT @total_bill = ISNULL( @total_bill, 0.000 );
						SELECT @total_cost = ISNULL( @total_cost, 0.000 );
						SELECT @state_tax = ISNULL( @state_tax, 0.000 );
						SELECT @county_tax = ISNULL( @county_tax, 0.000 );
						SELECT @city_tax = ISNULL( @city_tax, 0.000 );
						SELECT @emp_hrs = ISNULL( @emp_hrs, 0.000 );
						SELECT @ext_markup_amt = ISNULL( @ext_markup_amt, 0.000 );
						SELECT @comm = ISNULL(@comm, 0.000);
						SELECT @state_pct = ISNULL(@state_pct, 0.000);
						SELECT @county_pct = ISNULL(@county_pct, 0.000);
						SELECT @city_pct = ISNULL(@city_pct, 0.000);
					END
					-- LINE TOTAL
					BEGIN
						SELECT @line_total = ISNULL(ROUND(@total_bill, 2) + ROUND(@ext_markup_amt, 2) + ROUND(@state_tax, 2) + ROUND(@county_tax, 2) + ROUND(@city_tax, 2), 0.00 );
					END
					-- UPDATE DIRECT TIME RECORD:
				    IF @et_id IS NOT NULL AND @et_id > 0  
					BEGIN	
						DECLARE 
							@CAN_EDIT_THIS SMALLINT,
							@EDIT_MESSAGE_THIS VARCHAR(MAX),
							@DB_HOURS_BEFORE DECIMAL(7,3),
							@DB_TRF_CODE VARCHAR(10),
							@FNC_CODE_BEFORE VARCHAR(10),
							@ALERT_ID_BEFORE INT
						SELECT 
							@DB_HOURS_BEFORE = ISNULL(EMP_HOURS, 0.00), 
							@DB_TRF_CODE = TRF_CODE, 
							@FNC_CODE_BEFORE = FNC_CODE, 
							@ALERT_ID_BEFORE = ALERT_ID 
						FROM EMP_TIME_DTL WITH(NOLOCK)
						WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id;
						
						-- ONLY RUN UPDATE IF HOURS ENTERED IS NOT THE SAME AS CURRENT HOURS
						-- OR IF ONLY TRF_CODE IS BEING UPDATED
						IF (@DB_HOURS_BEFORE <> @emp_hrs) OR (@taskCode <> @DB_TRF_CODE) OR (@fnc_cat <> @FNC_CODE_BEFORE) OR (@ALERT_ID <> @ALERT_ID_BEFORE)
						BEGIN

							--GET EDIT STATUS
							BEGIN
								SELECT @CAN_EDIT_THIS = CAN_EDIT, @EDIT_MESSAGE_THIS = RETURN_MESSAGE 
								FROM [dbo].[wvfn_ts_can_edit] (@emp_code, @et_id, @etd_id, @SEQ_NBR);
								SET @CAN_EDIT_THIS = ISNULL(@CAN_EDIT_THIS, 0);

								IF @CAN_EDIT_THIS = 0
								BEGIN
									SELECT @error_code = -5;
									SELECT @error_text = @EDIT_MESSAGE_THIS;
								END
							END
							-- CHECK ESTIMATE APPROVAL SETTINGS
							BEGIN
								IF @CAN_EDIT_THIS = 1 AND @emp_hrs <> 0
								BEGIN

									DECLARE
										@EST_HRS_TO_CHECK DECIMAL(9, 3);

									IF NOT @emp_hrs IS NULL AND NOT @DB_HOURS_BEFORE IS NULL
									BEGIN
										IF @emp_hrs > @DB_HOURS_BEFORE
										BEGIN
											SELECT @EST_HRS_TO_CHECK = @emp_hrs;
										END
										IF @emp_hrs < @DB_HOURS_BEFORE
										BEGIN
											SELECT @EST_HRS_TO_CHECK = @emp_hrs - @DB_HOURS_BEFORE;
										END
									END
									SET @EST_HRS_TO_CHECK = ISNULL(@EST_HRS_TO_CHECK, @emp_hrs);

									SELECT 
										@EST_CHECK_CAN_MODIFY_TIME = EST_CHECK_CAN_MODIFY_TIME,
										@EST_EXCEED_OPTION = EXCEED_OPTION,
										@EDIT_MESSAGE_THIS = DISPLAY_MSG,
										@APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND = APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND,
										@SUM_ACTUAL = SUM_ACTUAL,
										@SUM_APPROVED = SUM_APPROVED,
										@IS_OVER_ESTIMATE_AMOUNT = IS_OVER
									FROM 
										[dbo].[advtf_timesheet_approved_estimate_check] (@job_nbr, @job_cmp_nbr, @EST_HRS_TO_CHECK, @fnc_cat);
									
									IF @APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND = 1 -- BLOCK
									BEGIN
										SET @CAN_EDIT_THIS = 0;
										SET @error_code = -17;
										SET @error_text = @EDIT_MESSAGE_THIS;
									END
									ELSE
									BEGIN
										IF @IS_OVER_ESTIMATE_AMOUNT = 1
										BEGIN
											IF @EST_EXCEED_OPTION = 1 -- WARN
											BEGIN
												SET @CAN_EDIT_THIS = 1;
												SET @error_code = -15;
												SET @error_text = @EDIT_MESSAGE_THIS;
											END
											IF @EST_EXCEED_OPTION = 2 -- BLOCK
											BEGIN
												SET @CAN_EDIT_THIS = 0;
												SET @error_code = -16;
												SET @error_text = @EDIT_MESSAGE_THIS;
											END
										END
									END

								END
							END

							-- UPDATE THE ENTRY
							IF @CAN_EDIT_THIS = 1
							BEGIN

								BEGIN TRANSACTION updateEmpTimeDtl

									IF @SUMMARIZED_REC_COUNT > 1 AND NOT @SEQ_NBR IS NULL
									BEGIN
										--	GET DEPT AGAIN ONLY IF NULL
										BEGIN
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN
												SELECT @dp_tm = DP_TM_CODE
												FROM 
													EMP_TIME_DTL WITH(NOLOCK)
		 										WHERE 
													ET_ID = @et_id 
		   											AND ET_DTL_ID = @etd_id
													AND SEQ_NBR = @SEQ_NBR;
											END
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN

												SELECT
													@dp_tm = EMPLOYEE.DP_TM_CODE
												FROM
													EMPLOYEE
												WHERE        
													(EMPLOYEE.EMP_CODE = @emp_code);

											END
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN
							
												SELECT @dp_tm = (
													SELECT TOP 1
														EMP_DP_TM.DP_TM_CODE
													FROM
														EMP_DP_TM INNER JOIN
														DEPT_TEAM ON EMP_DP_TM.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
													WHERE        
														(EMP_DP_TM.EMP_CODE = @emp_code)
													);

											END
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN

												SELECT
													@dp_tm = EMPLOYEE.DP_TM_CODE
												FROM
													EMPLOYEE INNER JOIN
													DEPT_TEAM ON EMPLOYEE.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
												WHERE        
													(EMPLOYEE.EMP_CODE = @emp_code);

											END
										END
										UPDATE EMP_TIME_DTL  WITH (ROWLOCK)
			  								SET    
												EMP_HOURS = ISNULL(@emp_hrs,0.00), 
												EMP_BILL_RATE = ISNULL(@billing_rate,0.000), 
												EMP_COST_RATE = ISNULL(@cost_rate,0.000), 
												TAX_CODE = @tax_code, 
												TAX_STATE_PCT = ISNULL(@state_pct,0.000), 
												TAX_COUNTY_PCT = ISNULL(@county_pct,0.000), 
												TAX_CITY_PCT = ISNULL(@city_pct,0.000),
												TAX_COMM = ISNULL(@tax_comm,0.000),
												TAX_COMM_ONLY = @tax_comm_only, 
												EMP_COMM_PCT = ISNULL(@comm,0.000), 
												EMP_NON_BILL_FLAG = @nobill, 
												EMP_RATE_FROM = @rate_from, 
												AB_FLAG = @ab_flag, 
												TOTAL_COST = ISNULL(@total_cost,0.000), 
												TOTAL_BILL = ISNULL(@total_bill,0.000), 
												EXT_MARKUP_AMT = ISNULL(@ext_markup_amt,0.000),
												EXT_STATE_RESALE = ISNULL(@state_tax,0.000), 
												EXT_COUNTY_RESALE = ISNULL(@county_tax,0.000), 
												EXT_CITY_RESALE = ISNULL(@city_tax,0.000), 
												TAX_RESALE = @TAX_RESALE,
												LINE_TOTAL = ISNULL(@line_total,0.000),
												FEE_TIME = @fee_time,
												TRF_CODE = @taskCode,
												FNC_CODE = @fnc_cat,
												DP_TM_CODE = @dp_tm
		 									WHERE ET_ID = @et_id 
		   									AND ET_DTL_ID = @etd_id
											AND SEQ_NBR = @SEQ_NBR
											AND (EDIT_FLAG IS NULL OR EDIT_FLAG = 0)
									END
									ELSE
									BEGIN
										--	GET DEPT AGAIN ONLY IF NULL
										BEGIN
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN
												SELECT @dp_tm = DP_TM_CODE
												FROM 
													EMP_TIME_DTL WITH(NOLOCK)
		 										WHERE 
													ET_ID = @et_id 
		   											AND ET_DTL_ID = @etd_id;
											END
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN

												SELECT
													@dp_tm = EMPLOYEE.DP_TM_CODE
												FROM
													EMPLOYEE
												WHERE        
													(EMPLOYEE.EMP_CODE = @emp_code);

											END
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN
							
												SELECT @dp_tm = (
													SELECT TOP 1
														EMP_DP_TM.DP_TM_CODE
													FROM
														EMP_DP_TM INNER JOIN
														DEPT_TEAM ON EMP_DP_TM.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
													WHERE        
														(EMP_DP_TM.EMP_CODE = @emp_code)
													);

											END
											IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
											BEGIN

												SELECT
													@dp_tm = EMPLOYEE.DP_TM_CODE
												FROM
													EMPLOYEE INNER JOIN
													DEPT_TEAM ON EMPLOYEE.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
												WHERE        
													(EMPLOYEE.EMP_CODE = @emp_code);

											END
										END
										UPDATE EMP_TIME_DTL  WITH (ROWLOCK)
			  								SET    EMP_HOURS = ISNULL(@emp_hrs,0.00), 
												EMP_BILL_RATE = ISNULL(@billing_rate,0.000), 
												EMP_COST_RATE = ISNULL(@cost_rate,0.000), 
												TAX_CODE = @tax_code, 
												TAX_STATE_PCT = ISNULL(@state_pct,0.000), 
												TAX_COUNTY_PCT = ISNULL(@county_pct,0.000), 
												TAX_CITY_PCT = ISNULL(@city_pct,0.000),
												TAX_COMM = ISNULL(@tax_comm,0.000),
												TAX_COMM_ONLY = @tax_comm_only, 
												EMP_COMM_PCT = ISNULL(@comm,0.000), 
												EMP_NON_BILL_FLAG = @nobill, 
												EMP_RATE_FROM = @rate_from, 
												AB_FLAG = @ab_flag, 
												TOTAL_COST = ISNULL(@total_cost,0.000), 
												TOTAL_BILL = ISNULL(@total_bill,0.000), 
												EXT_MARKUP_AMT = ISNULL(@ext_markup_amt,0.000),
												EXT_STATE_RESALE = ISNULL(@state_tax,0.000), 
												EXT_COUNTY_RESALE = ISNULL(@county_tax,0.000), 
												EXT_CITY_RESALE = ISNULL(@city_tax,0.000), 
												TAX_RESALE = @TAX_RESALE,
												LINE_TOTAL = ISNULL(@line_total,0.000),
												FEE_TIME = @fee_time,
												TRF_CODE = @taskCode,
												FNC_CODE = @fnc_cat,
												DP_TM_CODE = @dp_tm
		 									WHERE 
												ET_ID = @et_id 
		   										AND ET_DTL_ID = @etd_id
												AND (EDIT_FLAG IS NULL OR EDIT_FLAG = 0);
									END

		   						COMMIT TRANSACTION  updateEmpTimeDtl

								SELECT @DB_HOURS = ISNULL(EMP_HOURS, 0.00) FROM EMP_TIME_DTL WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id;
								IF @@ERROR <> 0 OR (@error_code = -16 OR @error_code = -17)
								BEGIN
								
									IF (@error_code = -16 OR @error_code = -17)
									BEGIN
										SET @error_code = @error_code;
									END
									ELSE
									BEGIN
										SELECT @error_code = @@ERROR;
									END
									SELECT @error_text = 'UPDATE_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
														 + '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
														 + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));

								END

								IF @@ERROR = 0
								BEGIN
									IF @error_code > 0
									BEGIN
										SET @error_code = 1002;
									END
									SET @error_text = 'UPDATE_SUCCESS' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
													  + '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR)
													  + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));

								END     

							END
							ELSE
							BEGIN

								SELECT @DB_HOURS = ISNULL(EMP_HOURS, 0.00) FROM EMP_TIME_DTL WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id;

								IF @@ERROR <> 0 OR (@error_code = -16 OR @error_code = -17)
								BEGIN
								
									IF (@error_code = -16 OR @error_code = -17)
									BEGIN
										SET @error_code = @error_code;
									END
									ELSE
									BEGIN
										SELECT @error_code = @@ERROR;
									END
									SELECT @error_text = 'UPDATE_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
														 + '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
														 + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));

								END

							END

						END
						ELSE
						BEGIN
							IF @error_code > 0
							BEGIN
								SET @error_code = 1002;
							END
							SET @error_text = 'NO_CHANGE' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
												+ '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR)
												+ '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));
						END													
					END
				    ELSE -- INSERT NEW DIRECT TIME RECORD:
					BEGIN

						DECLARE 
							@RESTRICTED INT,
							@CAN_INSERT_THIS SMALLINT,
							@INSERT_MESSAGE_THIS VARCHAR(150);

						-- CHECK CDP SECURITY
						BEGIN

							SELECT @RESTRICTED = COUNT(1) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@USER_CODE);
							SET @RESTRICTED = ISNULL(@RESTRICTED, 0);
							IF @RESTRICTED > 0
							BEGIN

								DECLARE
									@CLIENT_CT INT,
									@DIVISION_CT INT,
									@PRODUCT_CT INT

								-- CLIENT
								BEGIN

									SELECT @CLIENT_CT = COUNT(1) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@USER_CODE) AND CL_CODE = @cl_code;
									SET @CLIENT_CT = ISNULL(@CLIENT_CT, 0);
									IF @CLIENT_CT = 0
									BEGIN

										SELECT @error_code = -6;
										SELECT @error_text = 'No access to client';

									END

								END
								-- DIVISION
								IF @error_code = 0
								BEGIN

									SELECT @DIVISION_CT = COUNT(1) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@USER_CODE) AND CL_CODE = @cl_code AND DIV_CODE = @div_code;
									SET @DIVISION_CT = ISNULL(@DIVISION_CT, 0);
									IF @DIVISION_CT = 0
									BEGIN

										SELECT @error_code = -7;
										SELECT @error_text = 'No access to division';

									END

								END
								-- PRODUCT/JOB COMPONENT
								IF @error_code = 0
								BEGIN

									SELECT @PRODUCT_CT = COUNT(1) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@USER_CODE) AND CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code;
									SET @PRODUCT_CT = ISNULL(@PRODUCT_CT, 0);
									IF @PRODUCT_CT = 0
									BEGIN

										SELECT @error_code = -8;
										SELECT @error_text = 'No access to product';

									END

								END

							END

						END

						IF @FN_INACTIVE_DEPT = 1
						BEGIN
							SELECT @error_code = -19; -- Function has inactive dept/team
							SELECT @error_text = 'Function has inactive department/team.  Please contact your administrator to make the department active or remove the department from the function.';
							SET @CAN_INSERT_THIS = 0;
						END

						-- CHECK INSERT STATUS
						IF @error_code = 0
						BEGIN

							SELECT @CAN_INSERT_THIS = CAN_EDIT, @INSERT_MESSAGE_THIS = RETURN_MESSAGE 
							FROM [dbo].[wvfn_ts_can_insert] (@emp_code, @emp_date, @job_nbr, @job_cmp_nbr);

							SET @CAN_INSERT_THIS = ISNULL(@CAN_INSERT_THIS, 0);

							IF @CAN_INSERT_THIS = 0
							BEGIN
								SELECT @error_code = -12;
								SELECT @error_text = @INSERT_MESSAGE_THIS;
							END

						END

						-- CHECK ESTIMATE APPROVAL SETTINGS
						BEGIN
							IF @CAN_INSERT_THIS = 1 
							BEGIN

								SELECT 
									@EST_CHECK_CAN_MODIFY_TIME = EST_CHECK_CAN_MODIFY_TIME,
									@EST_EXCEED_OPTION = EXCEED_OPTION,
									@EDIT_MESSAGE_THIS = DISPLAY_MSG,
									@APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND = APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND,
									@SUM_ACTUAL = SUM_ACTUAL,
									@SUM_APPROVED = SUM_APPROVED,
									@IS_OVER_ESTIMATE_AMOUNT = IS_OVER
								FROM 
									[dbo].[advtf_timesheet_approved_estimate_check] (@job_nbr, @job_cmp_nbr, @emp_hrs, @fnc_cat);
									
								IF @APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND = 1 -- BLOCK
								BEGIN
									SET @CAN_INSERT_THIS = 0;
									SET @error_code = -17;
									SET @error_text = @EDIT_MESSAGE_THIS;
								END
								ELSE
								BEGIN
									IF @IS_OVER_ESTIMATE_AMOUNT = 1
									BEGIN
										IF @EST_EXCEED_OPTION = 1 -- WARN
										BEGIN
											SET @CAN_INSERT_THIS = 1;
											SET @error_code = -15;
											SET @error_text = @EDIT_MESSAGE_THIS;
										END
										IF @EST_EXCEED_OPTION = 2 -- BLOCK
										BEGIN
											SET @CAN_INSERT_THIS = 0;
											SET @error_code = -16;
											SET @error_text = @EDIT_MESSAGE_THIS;
										END
									END
								END
							END
							IF @CAN_INSERT_THIS = 0 AND @error_code IN (-15,-16,-17)
							BEGIN

								SET @error_text = 'INSERT_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
													+ '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
													+ '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));


							END

						END

						-- INSERT RECORD
						IF @CAN_INSERT_THIS = 1
						BEGIN
							-- See if there is already an ET_ID for this date
							SELECT @et_id = (SELECT ET_ID
											 FROM EMP_TIME  WITH (NOLOCK)
											 WHERE EMP_CODE = @emp_code
											 AND EMP_DATE = @emp_date);

							IF @et_id IS NULL -- Get the next ET_ID
							BEGIN

								SELECT @et_id = (SELECT LAST_NBR FROM ASSIGN_NBR WITH (UPDLOCK) WHERE COLUMNNAME = 'ET_ID' ) + 1;
								        
								BEGIN TRANSACTION updatedAssignNumber

									UPDATE ASSIGN_NBR  WITH (ROWLOCK) SET LAST_NBR = @et_id WHERE COLUMNNAME = 'ET_ID';

								COMMIT TRANSACTION updatedAssignNumber
								        
								SELECT @etd_id = 1;

								-- Get Freelance and Office Code
								SELECT @freelance = (SELECT FREELANCE FROM EMPLOYEE  WITH (NOLOCK) WHERE EMP_CODE = @emp_code);
								SELECT @officecode = (SELECT OFFICE_CODE FROM EMPLOYEE  WITH (NOLOCK) WHERE EMP_CODE = @emp_code);

								-- Insert the header record
								BEGIN TRANSACTION insertEmpTime

									INSERT INTO EMP_TIME  WITH (ROWLOCK) ( ET_ID, EMP_CODE, EMP_DATE, FREELANCE, OFFICE_CODE ) VALUES ( @et_id, @emp_code, @emp_date, @freelance, @officecode );

								COMMIT TRANSACTION insertEmpTime

							END
							ELSE -- Get the max seq number between EMP_TIME_DTL & EMP_TIME_NP 
							BEGIN 	

								SELECT @etd_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_NP  WITH (NOLOCK) WHERE ET_ID = @et_id ), 1 );
								SELECT @temp_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_DTL  WITH (NOLOCK) WHERE ET_ID = @et_id ), 1 );

								IF @temp_id > @etd_id
								BEGIN

									SELECT @etd_id = @temp_id;

								END

							END

							IF @@ERROR = 0
							BEGIN	

								--	GET DEPT IF MISSING WHEN INSERT
								BEGIN

									--IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
									--BEGIN

										SELECT
											@dp_tm = EMPLOYEE.DP_TM_CODE
										FROM
											EMPLOYEE
										WHERE        
											(EMPLOYEE.EMP_CODE = @emp_code);

									--END
									IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
									BEGIN
							
										SELECT @dp_tm = (
											SELECT TOP 1
												EMP_DP_TM.DP_TM_CODE
											FROM
												EMP_DP_TM INNER JOIN
												DEPT_TEAM ON EMP_DP_TM.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
											WHERE        
												(EMP_DP_TM.EMP_CODE = @emp_code)
											);

									END
									IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
									BEGIN

										SELECT
											@dp_tm = EMPLOYEE.DP_TM_CODE
										FROM
											EMPLOYEE INNER JOIN
											DEPT_TEAM ON EMPLOYEE.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
										WHERE        
											(EMPLOYEE.EMP_CODE = @emp_code);

									END
									IF NOT @FUNCTION_DEPT_TEAM IS NULL
									BEGIN
										SELECT @dp_tm = @FUNCTION_DEPT_TEAM;
									END

								END

								BEGIN TRANSACTION insertIntoEmpTimeDtl	
										
									INSERT INTO EMP_TIME_DTL WITH (ROWLOCK)( 
																			ET_ID, 
																			SEQ_NBR, 
																			ET_DTL_ID, 
																			JOB_NUMBER, 
																			JOB_COMPONENT_NBR, 
																			FNC_CODE, 
																			EMP_HOURS, 
																			EMP_BILL_RATE, 
																			EMP_COST_RATE, 
																			DP_TM_CODE, 
																			PROD_CAT_CODE, 
																			TAX_CODE, 
																			TAX_STATE_PCT, 
																			TAX_COUNTY_PCT, 
																			TAX_CITY_PCT, 
																			TAX_RESALE, 
																			TAX_COMM,
																			TAX_COMM_ONLY, 
																			EMP_COMM_PCT, 
																			EMP_NON_BILL_FLAG, 
																			DATE_ENTERED, 
																			USER_ID, 
																			EMP_RATE_FROM, 
																			AB_FLAG, 
																			TOTAL_COST, 
																			TOTAL_BILL, 
																			EXT_MARKUP_AMT,
																			EXT_STATE_RESALE, 
																			EXT_COUNTY_RESALE, 
																			EXT_CITY_RESALE, 
																			LINE_TOTAL,
																			FEE_TIME,
																			EMPLOYEE_TITLE_ID,
																			TRF_CODE,
																			ALERT_ID
																			) 
																			VALUES ( 
																				@et_id, 
																				@etd_id, 
																				@etd_id, 
																				@job_nbr, 
																				@job_cmp_nbr, 
																				LEFT( @fnc_cat, 6 ), 
																				ISNULL(@emp_hrs,0.00), 
																				ISNULL(@billing_rate,0.000), 
																				ISNULL(@cost_rate,0.000), 
																				@dp_tm, 
																				@ProdCat, 
																				@tax_code, 
																				ISNULL(@state_pct,0.000), 
																				ISNULL(@county_pct,0.000), 
																				ISNULL(@city_pct,0.000), 
																				@TAX_RESALE, 
																				@tax_comm, 
																				@tax_comm_only, 
																				ISNULL(@comm,0.000), 
																				@nobill, 
																				@CREATE_DATE, 
																				@USER_CODE, 
																				@rate_from, 
																				@ab_flag,	
																				ISNULL(@total_cost,0.000), 
																				ISNULL(@total_bill,0.000), 
																				ISNULL(@ext_markup_amt,0.000), 
																				ISNULL(@state_tax,0.000), 
																				ISNULL(@county_tax,0.000), 
																				ISNULL(@city_tax,0.000), 
																				ISNULL(@line_total,0.000),
																				@fee_time,
																				@EMPLOYEE_TITLE_ID,
																				@taskCode,
																				@ALERT_ID
																				);
							    
								COMMIT TRANSACTION insertIntoEmpTimeDtl		
									
								SELECT @DB_HOURS = ISNULL(EMP_HOURS, 0.00) FROM EMP_TIME_DTL WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id;
							        
								IF @@ERROR <> 0 OR (@error_code = -16 OR @error_code = -17)
								BEGIN

								IF (@error_code = -16 OR @error_code = -17)
								BEGIN
									SET @error_code = @error_code;
								END
								ELSE
								BEGIN
									SELECT @error_code = @@ERROR;
								END
									SET @error_text = 'INSERT_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
									                  + '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
													  + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));

								END

								IF @@ERROR = 0
								BEGIN

									IF @error_code > 0
									BEGIN
										SET @error_code = 1002;
									END
									SET @error_text = 'INSERT_SUCCESS' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
									                  + '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
													  + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));

								END     

							END
							ELSE
							BEGIN

								SELECT @error_code = @@ERROR;
								SET @error_text = 'INSERT_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
									                + '|' + CAST(ISNULL(@billing_rate, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
													+ '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR(MAX));

							END
						END

					END
			    END
	    END
        ELSE -- INDIRECT (NP) TIME:
	    BEGIN

		    SELECT @time_type = 'N';

		    -- Validate time category
		    SELECT @return_value = (SELECT COUNT(*)
								    FROM TIME_CATEGORY WITH (NOLOCK) 
		   						    WHERE CATEGORY = @fnc_cat);

		    IF @return_value = 0
			BEGIN

				SELECT @error_code = -3; -- Invalid time category
				SELECT @error_text = 'Invalid time category';

			END

		    -- Get the cost rate
		    IF @error_code = 0
		    BEGIN

			    SELECT @cost_rate = ( SELECT EMP_COST_RATE FROM EMPLOYEE  WITH (NOLOCK) WHERE EMP_CODE = @emp_code );
			    SELECT @total_cost = ROUND( @cost_rate * @emp_hrs, 2 );

			    IF @et_id > 0 -- This is an update of an existing record    
	 	  	    BEGIN

	 	  			BEGIN TRANSACTION updateEmpTimeNP		
						
							UPDATE EMP_TIME_NP WITH (ROWLOCK)
						       SET EMP_HOURS = ISNULL(@emp_hrs,0.00),
								   COST_RATE = ISNULL(@cost_rate,0.000),
								   TOTAL_COST = ISNULL(@total_cost,0.000)
						  	 WHERE ET_ID = @et_id
								   AND ET_DTL_ID = @etd_id;

	 	  			COMMIT TRANSACTION updateEmpTimeNP

					SELECT @DB_HOURS = ISNULL(EMP_HOURS, 0.00) FROM EMP_TIME_NP WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id;
								
					IF @@ERROR <> 0
					BEGIN

						SELECT @error_code = @@ERROR;
						SET @error_text = 'UPDATE_NP_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
						                  + '|' + CAST(ISNULL(0, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
										  + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR);

					END
					IF @@ERROR = 0
					BEGIN

						SET @error_code = 1002;
						SET @error_text = 'UPDATE_NP_SUCCESS' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
						                  + '|' + CAST(ISNULL(0, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
										  + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR);

					END     

				END
			    ELSE
				BEGIN

					SELECT @return_value = (SELECT COUNT(*)
											FROM TIME_CATEGORY WITH (NOLOCK) 
											WHERE CATEGORY = @fnc_cat AND INACTIVE_FLAG = 1);

					IF @return_value > 0
					BEGIN

						SELECT @error_code = -3; -- Invalid time category
						SELECT @error_text = 'Invalid time category';

					END

					-- See if there is already an ET_ID for this date
					SELECT @et_id = ( SELECT ET_ID FROM EMP_TIME  WITH (NOLOCK) WHERE EMP_CODE = @emp_code AND EMP_DATE = @emp_date );

        			IF @et_id IS NULL -- Get the next ET_ID
					BEGIN

						SELECT @et_id = ( SELECT LAST_NBR FROM ASSIGN_NBR  WITH (UPDLOCK) WHERE COLUMNNAME = 'ET_ID' ) + 1;

						BEGIN TRANSACTION updateNextAssignNbr

							UPDATE ASSIGN_NBR  WITH (ROWLOCK) SET LAST_NBR = @et_id WHERE COLUMNNAME = 'ET_ID';

						COMMIT TRANSACTION updateNextAssignNbr

						SELECT @etd_id = 1;

						-- Get Freelance and Office Code
						SELECT @freelance = (SELECT FREELANCE FROM EMPLOYEE  WITH (NOLOCK) WHERE EMP_CODE = @emp_code);
						SELECT @officecode = (SELECT OFFICE_CODE FROM EMPLOYEE  WITH (NOLOCK) WHERE EMP_CODE = @emp_code);

						-- Insert the header record
						BEGIN TRANSACTION insertHeaderRecord

							INSERT INTO EMP_TIME  WITH (ROWLOCK)( ET_ID, EMP_CODE, EMP_DATE, FREELANCE, OFFICE_CODE ) VALUES ( @et_id, @emp_code, @emp_date, @freelance, @officecode );
													
						COMMIT TRANSACTION insertHeaderRecord

					END
					ELSE -- Get the max seq number between EMP_TIME_DTL & EMP_TIME_NP 
					BEGIN 
						
						SELECT @etd_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_NP  WITH (NOLOCK) WHERE ET_ID = @et_id ), 1 );
						SELECT @temp_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_DTL  WITH (NOLOCK) WHERE ET_ID = @et_id ), 1 );

						IF @temp_id > @etd_id
						BEGIN

							SELECT @etd_id = @temp_id;

						END

					END

					IF @error_code = 0
					BEGIN		
							
						--	GET DEPT IF MISSING WHEN INSERT
						BEGIN

							--IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
							--BEGIN

								SELECT
									@dp_tm = EMPLOYEE.DP_TM_CODE
								FROM
									EMPLOYEE
								WHERE        
									(EMPLOYEE.EMP_CODE = @emp_code);

							--END
							IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
							BEGIN
							
								SELECT @dp_tm = (
									SELECT TOP 1
										EMP_DP_TM.DP_TM_CODE
									FROM
										EMP_DP_TM INNER JOIN
										DEPT_TEAM ON EMP_DP_TM.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
									WHERE        
										(EMP_DP_TM.EMP_CODE = @emp_code)
									);

							END
							IF (@dp_tm IS NULL OR @dp_tm = '' OR DATALENGTH(@dp_tm) = 0)
							BEGIN

								SELECT
									@dp_tm = EMPLOYEE.DP_TM_CODE
								FROM
									EMPLOYEE INNER JOIN
									DEPT_TEAM ON EMPLOYEE.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
								WHERE        
									(EMPLOYEE.EMP_CODE = @emp_code);

							END

						END
						BEGIN TRANSACTION insertIntoEmpTimeNP
										
							INSERT INTO EMP_TIME_NP  WITH (ROWLOCK)( ET_ID, SEQ_NBR, ET_DTL_ID, CATEGORY, EMP_HOURS, COST_RATE, DP_TM_CODE, 
																				DATE_ENTERED, USER_ID, TOTAL_COST ) 
									    VALUES ( @et_id, @etd_id, @etd_id, @fnc_cat, @emp_hrs, @cost_rate, @dp_tm, @CREATE_DATE, @USER_CODE, 
															@total_cost );

						COMMIT TRANSACTION insertIntoEmpTimeNP		
							
						SELECT @DB_HOURS = ISNULL(EMP_HOURS, 0.00) FROM EMP_TIME_NP WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id;

						IF @@ERROR <> 0
						BEGIN

							SELECT @error_code = @@ERROR;
							SET @error_text = 'INSERT_NP_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
							                  + '|' + CAST(ISNULL(0, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
											  + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR);

						END

						IF @@ERROR = 0
						BEGIN

							SET @error_code = 1002;
							SET @error_text = 'INSERT_NP_SUCCESS' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
							                  + '|' + CAST(ISNULL(0, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR)
											  + '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR);

						END     
								        
					END
					ELSE
					BEGIN

						SELECT @error_code = @@ERROR;
						SET @error_text = 'INSERT_NP_FAIL' + '|' + CAST(ISNULL(@et_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@etd_id,0) AS VARCHAR) + '|' + CAST(ISNULL(@DB_HOURS, 0) AS VARCHAR) 
							                + '|' + CAST(ISNULL(0, 0) AS VARCHAR) + '|' + CAST(ISNULL(@nobill,0) AS VARCHAR) 
											+ '|' + CAST(ISNULL(@error_code, 0) AS VARCHAR) + '|' + CAST(ISNULL(@error_text, '') AS VARCHAR);

					END
					
				END

		    END

		END 

		-- COMMIT OR ROLLBACK 
		IF @error_code = 0 OR @error_code = 1002 OR @error_code = -15
		BEGIN
			
			COMMIT;

		END
		ELSE
		BEGIN

			ROLLBACK;

		END

		-- UPDATE COMMENTS
		IF @et_id > 0 AND @etd_id > 0 
		BEGIN

			BEGIN TRANSACTION updateComments

				EXECUTE usp_wv_comments_update_emptime @time_type, @et_id, @etd_id, @comments, 0;

			COMMIT TRANSACTION updateComments

		END

END

SELECT @error_text AS RETURN_MESSAGE;		

/*=========== QUERY ===========*/
END

