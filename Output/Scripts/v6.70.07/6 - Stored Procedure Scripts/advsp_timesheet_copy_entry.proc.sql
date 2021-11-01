SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_timesheet_copy_entry]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_timesheet_copy_entry]
GO
CREATE PROCEDURE [dbo].[advsp_timesheet_copy_entry] /*WITH ENCRYPTION*/
@USER_CODE VARCHAR(100),
@SOURCE_ET_ID INT,
@SOURCE_ET_DTL_ID INT,
@SOURCE_TIME_TYPE VARCHAR(1),
@TARGET_DATE SMALLDATETIME,
@TARGET_EMP_CODE VARCHAR(6),
@COPY_HOURS BIT,
@CREATE_DATE_IN SMALLDATETIME
AS
/*=========== QUERY ===========*/
	--  INIT
	BEGIN
		DECLARE
			@JOB_NUMBER INT, 
			@JOB_COMPONENT_NBR SMALLINT, 
			@FUNCTION_CATEGORY_CODE VARCHAR(10), 
			@DP_TM_CODE VARCHAR(4),
			@HOURS DECIMAL(9,3), 
			@START_TIME CHAR(4), 
			@END_TIME CHAR(4),	
			@PROD_CAT_CODE VARCHAR(10), 
			@COMMENTS VARCHAR(MAX),   
			@TRF_CODE VARCHAR(10),
			@ALERT_ID_IN INT,
			@ERROR_MESSAGE VARCHAR(4000),
			@CAN_COPY BIT,
			@JOB_PROCESS_CONTRL SMALLINT
		;
		SELECT 
			@COPY_HOURS = ISNULL(@COPY_HOURS, 0),
			@JOB_NUMBER = ISNULL(@JOB_NUMBER, 0),
			@JOB_COMPONENT_NBR = ISNULL(@JOB_COMPONENT_NBR, 0),
			@HOURS = ISNULL(@HOURS, 0),
			@CAN_COPY = 1,
			@JOB_PROCESS_CONTRL = 0
			;
	END
	--GET DETAILS
	BEGIN
		IF @SOURCE_TIME_TYPE = 'D'
		BEGIN		
			SELECT TOP 1
				@JOB_NUMBER = JOB_NUMBER,
				@JOB_COMPONENT_NBR = JOB_COMPONENT_NBR,
				@FUNCTION_CATEGORY_CODE = FNC_CODE,
				@DP_TM_CODE = DP_TM_CODE,
				@PROD_CAT_CODE = PROD_CAT_CODE,
				@HOURS = EMP_HOURS,
				@START_TIME = START_TIME,
				@END_TIME = END_TIME,
				@TRF_CODE = TRF_CODE,
				@ALERT_ID_IN = ALERT_ID
			FROM 
				EMP_TIME_DTL WITH(NOLOCK) 
			WHERE 
				ET_ID = @SOURCE_ET_ID 
				AND ET_DTL_ID = @SOURCE_ET_DTL_ID;
			IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0
			BEGIN
				SELECT
					@JOB_PROCESS_CONTRL = ISNULL(JC.JOB_PROCESS_CONTRL, 0)
				FROM
					JOB_COMPONENT JC WITH(NOLOCK)
				WHERE
					JC.JOB_NUMBER = @JOB_NUMBER
					AND JC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
			END
			IF @JOB_PROCESS_CONTRL IN (2, 3, 5, 6, 9, 10, 12, 13)
			BEGIN
				SET @CAN_COPY = 0;
			END
		END
		IF @SOURCE_TIME_TYPE = 'N'
		BEGIN
			--  POST PERIOD CHECK FOR INDIRECT.  CHECK IS HANDLED ALREADY FOR DIRECT TIME
			BEGIN
				DECLARE
					@PP INT,
					@RET INT

				SELECT @PP = TS_PPERIOD_CHK FROM AGENCY WITH(NOLOCK);

				IF NOT @TARGET_DATE IS NULL
				BEGIN
					SELECT @TARGET_DATE = CAST(CONVERT(VARCHAR, @TARGET_DATE, 1) AS SMALLDATETIME);
				END
				IF @PP = 1 -- ZERO IS CLOSED, 
				BEGIN
					SELECT 
					   @RET = COUNT(1) 
					FROM 
					   POSTPERIOD WITH (NOLOCK)
					WHERE	
					   PPSRTDATE <= @TARGET_DATE
					   AND	PPENDDATE >= @TARGET_DATE
					   AND (PPTECURMTH = 'C' OR PPTECURMTH IS NULL);
				END
				ELSE
				BEGIN
					SET @RET = 1;
				END
				IF @RET = 0 -- CLOSED
				BEGIN
					SET @CAN_COPY = 0;
				END
			END
			IF @CAN_COPY = 1
			BEGIN
				SELECT TOP 1
					@FUNCTION_CATEGORY_CODE = CATEGORY,
					@DP_TM_CODE = DP_TM_CODE,
					@HOURS = EMP_HOURS,
					@START_TIME = START_TIME,
					@END_TIME = END_TIME
				FROM 
					EMP_TIME_NP WITH(NOLOCK) 
				WHERE 
					ET_ID = @SOURCE_ET_ID 
					AND ET_DTL_ID = @SOURCE_ET_DTL_ID;
			END
		END
	END
	--GET COMMENTS
	IF @CAN_COPY = 1
	BEGIN
		IF @COPY_HOURS = 1
		BEGIN
			SELECT TOP 1
				@COMMENTS = CAST(EMP_COMMENT AS VARCHAR(MAX))
			FROM
				EMP_TIME_DTL_CMTS WITH(NOLOCK)
			WHERE 
				ET_ID = @SOURCE_ET_ID 
				AND ET_DTL_ID = @SOURCE_ET_DTL_ID;
		END
	END
	-- SET HOURS
	IF @CAN_COPY = 1
	BEGIN
		IF @COPY_HOURS = 0
		BEGIN
			SET @HOURS = 0;
			SET @COMMENTS = NULL;
		END
	END
	--SAVE
	IF @CAN_COPY = 1
	BEGIN
		EXEC usp_wv_ts_SaveTimeSheetDay
				@et_id = 0,
				@etd_id = 0,
				@emp_code = @TARGET_EMP_CODE,
				@emp_date = @TARGET_DATE,
				@fnc_cat = @FUNCTION_CATEGORY_CODE,
				@emp_hrs = @HOURS,
				@job_nbr = @JOB_NUMBER,
				@job_cmp_nbr = @JOB_COMPONENT_NBR,
				@dp_tm = @DP_TM_CODE,
				@start_time = @START_TIME,
				@end_time = @END_TIME,
				@ProdCat = @PROD_CAT_CODE,
				@USER_CODE = @USER_CODE,
				@comments = @COMMENTS,
				@taskCode = @TRF_CODE,
				@error_text = @ERROR_MESSAGE,
				@CREATE_DATE = @CREATE_DATE_IN,
				@ALERT_ID = @ALERT_ID_IN,
				@ALLOW_DUPLICATE = 1
		;
	END;
/*=========== QUERY ===========*/