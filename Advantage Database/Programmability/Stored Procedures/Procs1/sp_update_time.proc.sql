
CREATE PROCEDURE [dbo].[sp_update_time] @et_id integer, @etd_id integer, @emp_code varchar(6), @emp_date smalldatetime, 
	@fnc_cat varchar(10), @emp_hrs decimal(9,3), @job_nbr integer, @job_cmp_nbr smallint, @dp_tm varchar(4),
	@start_time char(4), @end_time char(4),	@error_text varchar(254) OUTPUT
	
	AS

SET NOCOUNT ON

BEGIN TRANSACTION

DECLARE @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6), @ab_flag smallint, @return_value integer,
	@billing_rate decimal(9,2), @cost_rate decimal(9,2), @rate_from varchar(254), @tax_code varchar(6), 
	@state_pct decimal(9,2), @county_pct decimal(9,2), @city_pct decimal(9,2), @tax_comm smallint, 
	@tax_comm_only smallint, @comm decimal(9,2), @nobill smallint, @tax_flag smallint, @time_type char(1),
	@temp_id integer, @total_cost decimal(9,2), @total_bill decimal(9,2), @ext_markup_amt decimal(9,2),
	@state_tax decimal(9,3), @county_tax decimal(9,3), @city_tax decimal(9,3), @line_total decimal(9,2),
	@error_code integer, @limit_etf varchar(1), @fnc_dp_tm varchar(4), @freelance smallint, @officecode char(4),
	@start_end_active smallint, @fee_flag smallint

	DECLARE @SEC_USER_ID int

	SELECT 
		@SEC_USER_ID = SEC_USER_ID
	FROM 
		[dbo].[SEC_USER]
	WHERE 
		UPPER(EMP_CODE) = UPPER(@emp_code)
		
SELECT @error_code = 0

SELECT @start_end_active = ( SELECT START_END_TIME FROM AGENCY )

IF @job_nbr IS NOT NULL AND @job_nbr > 0 -- A function is in use
	BEGIN
		SELECT @time_type = 'D'
		-- Default job component number to 1 if none entered
		SELECT @job_cmp_nbr = ( SELECT ISNULL( @job_cmp_nbr, 1 ))

		-- Validate job
		DECLARE job_cursor CURSOR FOR
			SELECT CL_CODE, DIV_CODE, PRD_CODE, AB_FLAG
				FROM JOB_COMPONENT jc, JOB_LOG jl
			 WHERE jc.JOB_NUMBER = jl.JOB_NUMBER
				 AND jc.JOB_NUMBER = @job_nbr
				 AND jc.JOB_COMPONENT_NBR = @job_cmp_nbr
				 AND JOB_PROCESS_CONTRL NOT IN ( 2, 3, 5, 6, 9, 10, 12 ) 
			FOR READ ONLY

		OPEN job_cursor

		FETCH job_cursor 
		 INTO @cl_code, @div_code, @prd_code, @ab_flag

		IF @@FETCH_STATUS <> 0
			BEGIN
				SELECT @error_code = -1 -- Invalid job
				SELECT @error_text = 'Error -1: Invalid job/component.'
			END
		ELSE -- Validate ab_flag
			BEGIN
				IF @ab_flag IN ( 1, 2 )
					SELECT @ab_flag = 2
				ELSE
					SELECT @ab_flag = 0
			END

		CLOSE job_cursor
		DEALLOCATE job_cursor

		-- Validate function
		IF @error_code = 0
			BEGIN
			
				IF EXISTS(SELECT * FROM [dbo].[SEC_USER_SETTING] WHERE SEC_USER_ID = @SEC_USER_ID AND SETTING_CODE = 'EMP_TS_FNC' AND STRING_VALUE = 'Y') BEGIN

					SET @limit_etf = 'Y'

				END

				IF @limit_etf = 'Y'
					SELECT @return_value = ( SELECT COUNT(*) 
											   FROM EMP_TS_FNC etf, FUNCTIONS f
											  WHERE f.FNC_CODE = @fnc_cat 
												AND f.FNC_CODE = etf.FNC_CODE
												AND EMP_CODE = @emp_code
												AND FNC_TYPE = 'E'
												AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 ))
				ELSE
					SELECT @return_value = ( SELECT COUNT(*) 
											   FROM FUNCTIONS 
											  WHERE FNC_CODE = @fnc_cat 
												AND FNC_TYPE = 'E'
												AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 ))
				IF @return_value = 0
					BEGIN
						SELECT @error_code = -2 -- Invalid function
						SELECT @error_text = 'Error -2: Invalid function.'
					END
			END				

		-- Check function for dept/team
		IF @error_code = 0
			BEGIN
				SELECT @dp_tm = COALESCE( ( SELECT DP_TM_CODE FROM FUNCTIONS WHERE FNC_CODE = @fnc_cat ), @dp_tm )
			END	 

		IF @error_code = 0 -- Call stored procedure to get rates
			BEGIN
				EXECUTE sp_get_emp_rates @emp_code, @emp_date, @fnc_cat, @cl_code, @div_code, @prd_code, @job_nbr,
					@job_cmp_nbr, @billing_rate OUTPUT, @rate_from OUTPUT, @cost_rate OUTPUT, @tax_flag OUTPUT, 
					@tax_code OUTPUT, @nobill OUTPUT, @city_pct OUTPUT, @county_pct OUTPUT, @state_pct OUTPUT, 
					@comm OUTPUT, @tax_comm OUTPUT, @tax_comm_only OUTPUT, @fee_flag OUTPUT

				SELECT @total_bill = ROUND( @billing_rate * @emp_hrs, 2 )
				SELECT @total_cost = ROUND( @cost_rate * @emp_hrs, 2 )
				SELECT @ext_markup_amt = ROUND( @total_bill * @comm / 100, 2 )

				-- Calculate taxes
				IF @tax_flag = 1
					BEGIN
						IF @tax_comm_only = 1
							BEGIN		
								EXECUTE sp_calc_prod_resale 0, @ext_markup_amt, @state_pct, @state_tax OUTPUT
								EXECUTE sp_calc_prod_resale 0, @ext_markup_amt, @county_pct, @county_tax OUTPUT
								EXECUTE sp_calc_prod_resale 0, @ext_markup_amt, @city_pct, @city_tax OUTPUT
							END
						ELSE		
							BEGIN
								IF @tax_comm = 1	
									BEGIN
										EXECUTE sp_calc_prod_resale @total_bill, @ext_markup_amt, @state_pct, @state_tax OUTPUT
										EXECUTE sp_calc_prod_resale @total_bill, @ext_markup_amt, @county_pct, @county_tax OUTPUT
										EXECUTE sp_calc_prod_resale @total_bill, @ext_markup_amt, @city_pct, @city_tax OUTPUT
									END
								ELSE
									BEGIN
										EXECUTE sp_calc_prod_resale @total_bill, 0, @state_pct, @state_tax OUTPUT
										EXECUTE sp_calc_prod_resale @total_bill, 0, @county_pct, @county_tax OUTPUT
										EXECUTE sp_calc_prod_resale @total_bill, 0, @city_pct, @city_tax OUTPUT
									END
							END	
					END
				ELSE
					BEGIN
						SELECT @state_tax = 0
						SELECT @county_tax = 0
						SELECT @city_tax = 0
					END

				SELECT @total_bill = ISNULL( @total_bill, 0 )
				SELECT @total_cost = ISNULL( @total_cost, 0 )
				SELECT @state_tax = ISNULL( @state_tax, 0 )
				SELECT @county_tax = ISNULL( @county_tax, 0 )
				SELECT @city_tax = ISNULL( @city_tax, 0 )
				SELECT @emp_hrs = ISNULL( @emp_hrs, 0 )
				SELECT @ext_markup_amt = ISNULL( @ext_markup_amt, 0 )
				SELECT @line_total = ISNULL( @total_bill + @ext_markup_amt + @state_tax + @county_tax + @city_tax, 0 )

				IF @et_id IS NOT NULL	AND @et_id > 0 -- This is an update of an existing record    
					BEGIN						
							  UPDATE EMP_TIME_DTL 
				  				 SET EMP_HOURS = @emp_hrs, 
									 EMP_BILL_RATE = @billing_rate, 
									 EMP_COST_RATE = @cost_rate, 
									 TAX_CODE = @tax_code, 
									 TAX_STATE_PCT = @state_pct, 
									 TAX_COUNTY_PCT = @county_pct, 
									 TAX_CITY_PCT = @city_pct,
									 TAX_COMM = @tax_comm,
									 TAX_COMM_ONLY = @tax_comm_only, 
									 EMP_COMM_PCT = @comm, 
									 EMP_NON_BILL_FLAG = @nobill, 
									 DATE_ENTERED = GETDATE(), 
									 EMP_RATE_FROM = @rate_from, 
									 AB_FLAG = @ab_flag, 
									 TOTAL_COST = @total_cost, 
									 TOTAL_BILL = @total_bill, 
									 EXT_MARKUP_AMT = @ext_markup_amt,
									 EXT_STATE_RESALE = @state_tax, 
									 EXT_COUNTY_RESALE = @county_tax, 
									 EXT_CITY_RESALE = @city_tax, 
									 LINE_TOTAL = @line_total,
									 FEE_TIME = @fee_flag
				 			   WHERE ET_ID = @et_id 
								 AND ET_DTL_ID = @etd_id

						IF @@ERROR <> 0
							BEGIN
								SELECT @error_code = @@ERROR
								SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Record update failed.'	
							END
					END

				ELSE -- This is an insert of a new record
					BEGIN
						-- See if there is already an ET_ID for this date
						SELECT @et_id = ( SELECT ET_ID 
																FROM EMP_TIME 
															 WHERE EMP_CODE = @emp_code
																 AND EMP_DATE = @emp_date ) 

						IF @et_id IS NULL -- Get the next ET_ID
							BEGIN
								SELECT @et_id = ( SELECT LAST_NBR FROM ASSIGN_NBR WHERE COLUMNNAME = 'ET_ID' ) + 1
								UPDATE ASSIGN_NBR SET LAST_NBR = @et_id WHERE COLUMNNAME = 'ET_ID'
								SELECT @etd_id = 1

								-- Get Freelance and Office Code
								Select @freelance = (Select FREELANCE FROM EMPLOYEE WHERE EMP_CODE = @emp_code)
								Select @officecode = (Select OFFICE_CODE FROM EMPLOYEE WHERE EMP_CODE = @emp_code)

								-- Insert the header record
								INSERT INTO EMP_TIME ( ET_ID, EMP_CODE, EMP_DATE, FREELANCE, OFFICE_CODE ) VALUES ( @et_id, @emp_code, @emp_date, @freelance, @officecode )
							END
						ELSE -- Get the max seq number between EMP_TIME_DTL & EMP_TIME_NP 
							BEGIN 	
								SELECT @etd_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_NP WHERE ET_ID = @et_id ), 1 )
								SELECT @temp_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_DTL WHERE ET_ID = @et_id ), 1 )
								IF @temp_id > @etd_id
									SELECT @etd_id = @temp_id
							END

						IF @@ERROR = 0
							BEGIN						
								INSERT INTO EMP_TIME_DTL ( ET_ID, SEQ_NBR, ET_DTL_ID, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, 
														   EMP_HOURS, EMP_BILL_RATE, EMP_COST_RATE, DP_TM_CODE, TAX_CODE, 
														   TAX_STATE_PCT, TAX_COUNTY_PCT, TAX_CITY_PCT, TAX_RESALE, TAX_COMM,
														   TAX_COMM_ONLY, EMP_COMM_PCT, EMP_NON_BILL_FLAG, DATE_ENTERED, 
														   USER_ID, EMP_RATE_FROM, AB_FLAG, TOTAL_COST, TOTAL_BILL, EXT_MARKUP_AMT,
														   EXT_STATE_RESALE, EXT_COUNTY_RESALE, EXT_CITY_RESALE, LINE_TOTAL, FEE_TIME ) 
								   VALUES ( @et_id, @etd_id, @etd_id, @job_nbr, @job_cmp_nbr, LEFT( @fnc_cat, 6 ), @emp_hrs, 
											@billing_rate, @cost_rate, @dp_tm, @tax_code, @state_pct, @county_pct, @city_pct, 
											1, @tax_comm, @tax_comm_only, @comm, @nobill, GETDATE(), USER, @rate_from, @ab_flag,	
											@total_cost, @total_bill, @ext_markup_amt, @state_tax, @county_tax, @city_tax, 
											@line_total, @fee_flag )
								IF @@ERROR <> 0
									BEGIN
										SELECT @error_code = @@ERROR
										SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Insert record failed.'
									END
							END
						ELSE
							BEGIN
								SELECT @error_code = @@ERROR
								SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Insert record failed.'
							END
					END
			END
	END
ELSE -- A time category is in use
	BEGIN
		SELECT @time_type = 'N'
		-- Validate time category
		SELECT @return_value = ( SELECT COUNT(*)
								   FROM TIME_CATEGORY
		   						  WHERE CATEGORY = @fnc_cat
									AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ))

		IF @return_value = 0
			BEGIN
				SELECT @error_code = -3 -- Invalid time category
				SELECT @error_text = 'Error -3: Invalid time category. Category may no longer be active.'
			END

		-- Get the cost rate
		IF @error_code = 0
		BEGIN
			SELECT @cost_rate = ( SELECT EMP_COST_RATE FROM EMPLOYEE WHERE EMP_CODE = @emp_code )
			SELECT @total_cost = ROUND( @cost_rate * @emp_hrs, 2 )

			IF @et_id > 0 -- This is an update of an existing record    
	 	  	BEGIN
					UPDATE EMP_TIME_NP
					   SET EMP_HOURS = @emp_hrs,
						   COST_RATE = @cost_rate,
						   TOTAL_COST = @total_cost,
						   DATE_ENTERED = GETDATE()
					 WHERE ET_ID = @et_id
					   AND ET_DTL_ID = @etd_id

					IF @@ERROR <> 0
						BEGIN
							SELECT @error_code = @@ERROR
							SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Update record failed.'
						END
				END
			ELSE
				BEGIN
					-- See if there is already an ET_ID for this date
					SELECT @et_id = ( SELECT ET_ID 
										FROM EMP_TIME 
									   WHERE EMP_CODE = @emp_code
										 AND EMP_DATE = @emp_date ) 
	
					IF @et_id IS NULL -- Get the next ET_ID
						BEGIN
							SELECT @et_id = ( SELECT LAST_NBR FROM ASSIGN_NBR WHERE COLUMNNAME = 'ET_ID' ) + 1
							UPDATE ASSIGN_NBR SET LAST_NBR = @et_id WHERE COLUMNNAME = 'ET_ID'
							SELECT @etd_id = 1

							-- Get Freelance and Office Code
							Select @freelance = (Select FREELANCE FROM EMPLOYEE WHERE EMP_CODE = @emp_code)
							Select @officecode = (Select OFFICE_CODE FROM EMPLOYEE WHERE EMP_CODE = @emp_code)

							-- Insert the header record
							INSERT INTO EMP_TIME ( ET_ID, EMP_CODE, EMP_DATE, FREELANCE, OFFICE_CODE ) VALUES ( @et_id, @emp_code, @emp_date, @freelance, @officecode )
						END
					ELSE -- Get the max seq number between EMP_TIME_DTL & EMP_TIME_NP 
						BEGIN 	
							SELECT @etd_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_NP WHERE ET_ID = @et_id ), 1 )
							SELECT @temp_id = ISNULL(( SELECT MAX( SEQ_NBR ) + 1 FROM EMP_TIME_DTL WHERE ET_ID = @et_id ), 1 )
							IF @temp_id > @etd_id
								SELECT @etd_id = @temp_id
						END

					IF @@ERROR = 0
						BEGIN						
							INSERT INTO EMP_TIME_NP ( ET_ID, SEQ_NBR, ET_DTL_ID, CATEGORY, EMP_HOURS, COST_RATE, DP_TM_CODE, 
																				DATE_ENTERED, USER_ID, TOTAL_COST ) 
									   VALUES ( @et_id, @etd_id, @etd_id, @fnc_cat, @emp_hrs, @cost_rate, @dp_tm, GETDATE(), USER, 
															@total_cost )
							IF @@ERROR <> 0
								BEGIN
									SELECT @error_code = @@ERROR
									SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Insert record failed.'
								END
						END
					ELSE
						BEGIN
							SELECT @error_code = @@ERROR
							SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Insert record failed.'
						END
				END
		END
END 

IF @error_code = 0
	BEGIN
	  EXECUTE sp_update_header_hours @emp_code, @emp_date
	  IF @start_end_active = 1 AND @start_time >= '0000' AND @end_time >= '0000'
		  EXECUTE sp_update_time_comment @et_id, @etd_id, @time_type, @start_time, @end_time
	  COMMIT
	END
ELSE
	ROLLBACK

SELECT @error_text
