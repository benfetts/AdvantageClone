SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_DaysByApprovalStatus]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_DaysByApprovalStatus]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_DaysByApprovalStatus] /*WITH ENCRYPTION*/
@START_DATE SMALLDATETIME,
@END_DATE SMALLDATETIME,
@EMP_CODE VARCHAR(6),
@STATUS SMALLINT
AS
/*=========== QUERY ===========*/
	CREATE TABLE #DATE_RANGE (THE_DATE SMALLDATETIME, 
								TOTAL_HOURS DECIMAL(9,2), 
								TIMESHEET_APPROVAL_TYPE SMALLINT, 
								PERCENT_OF_STD_HRS DECIMAL(9,2), 
								STD_HRS DECIMAL(9,2),
								POSTPERIOD_CLOSED INT,
								IS_HOLIDAY BIT,
								IS_ALL_DAY_HOLIDAY INT,
								HOLIDAY_HOURS DECIMAL(15,2)
							  );
	DECLARE 
		@DAY_COUNT INT, 
		@CURR_DATE SMALLDATETIME,
		@SUN_HRS DECIMAL(9, 3),
		@MON_HRS DECIMAL(9, 3),
		@TUE_HRS DECIMAL(9, 3),
		@WED_HRS DECIMAL(9, 3),
		@THU_HRS DECIMAL(9, 3),
		@FRI_HRS DECIMAL(9, 3),
		@SAT_HRS DECIMAL(9, 3),
		@EMP_WORK_DAYS VARCHAR(30),
		@CURR_PP_CLOSED INT,
		@CHECK_PP AS SMALLINT,
	    @TIME_APPR_ACTIVE AS BIT;

	SELECT @TIME_APPR_ACTIVE = [dbo].[advfn_timesheet_is_approval_active] (@EMP_CODE);
	SET @TIME_APPR_ACTIVE = ISNULL(@TIME_APPR_ACTIVE, 0);

	SELECT 
		@SUN_HRS = ISNULL(SUN_HRS, 0.00),
		@MON_HRS = ISNULL(MON_HRS, 0.00),
		@TUE_HRS = ISNULL(TUE_HRS, 0.00),
		@WED_HRS = ISNULL(WED_HRS, 0.00),
		@THU_HRS = ISNULL(THU_HRS, 0.00),
		@FRI_HRS = ISNULL(FRI_HRS, 0.00),
		@SAT_HRS = ISNULL(SAT_HRS, 0.00),
		@EMP_WORK_DAYS = UPPER(ISNULL(EMP_WORK_DAYS, ''))			 
	FROM EMPLOYEE WITH(NOLOCK) 
	WHERE EMP_CODE = @EMP_CODE;	

	SET @DAY_COUNT = DATEDIFF(d, @START_DATE, @END_DATE);

	SELECT @CHECK_PP = TS_PPERIOD_CHK FROM AGENCY WITH(NOLOCK);
	SET @CHECK_PP = ISNULL(@CHECK_PP, 0);

	DECLARE 
		@DAY_HOURS DECIMAL(9,3), 
		@IS_HOLIDAY BIT, 
		@IS_ALL_DAY_HOLIDAY INT, 
		@HOLIDAY_HOURS DECIMAL(15,2);

	WHILE (@DAY_COUNT >= 0)
	BEGIN
	
		SET @CURR_DATE = DATEADD(d, @DAY_COUNT, @START_DATE);
		SET @DAY_HOURS = 0.000;
		SELECT @DAY_HOURS = ISNULL(EMP_TIME.EMP_DTL_HRS, 0.000) FROM EMP_TIME WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE AND EMP_DATE = @CURR_DATE;

		IF EXISTS (SELECT 1 FROM EMP_NON_TASKS WITH(NOLOCK) WHERE [TYPE] = 'H' AND @CURR_DATE BETWEEN [START_DATE] AND [END_DATE])
		BEGIN
			SELECT @IS_HOLIDAY = 1, @HOLIDAY_HOURS = [HOURS], @IS_ALL_DAY_HOLIDAY = ALL_DAY FROM EMP_NON_TASKS WITH(NOLOCK) WHERE [TYPE] = 'H' AND @CURR_DATE BETWEEN [START_DATE] AND [END_DATE];
		END
		ELSE
		BEGIN
			SELECT @IS_HOLIDAY = 0, @HOLIDAY_HOURS = 0.00, @IS_ALL_DAY_HOLIDAY = 0;
		END

		IF ((CHARINDEX(UPPER(SUBSTRING(DATENAME(dw, @CURR_DATE), 0, 4)), @EMP_WORK_DAYS, 0) > 0) AND @IS_HOLIDAY = 0) OR @DAY_HOURS > 0.000
		BEGIN
	
			IF @CHECK_PP = 0
			BEGIN
				SET @CURR_PP_CLOSED = 0;
			END
			ELSE
			BEGIN
				DECLARE @PP_COUNT INT;
				
				SELECT @PP_COUNT = COUNT(*) 
				FROM POSTPERIOD WITH (NOLOCK)
				WHERE	PPSRTDATE <= @CURR_DATE
				AND	PPENDDATE >= @CURR_DATE
				AND (PPTECURMTH = 'C' OR PPTECURMTH IS NULL);
				
				IF @PP_COUNT = 0
				BEGIN
					SET @CURR_PP_CLOSED = 1;
				END
				ELSE
				BEGIN
					SET @CURR_PP_CLOSED = 0;
				END	
				
			END
			
			INSERT INTO #DATE_RANGE(THE_DATE, TOTAL_HOURS, TIMESHEET_APPROVAL_TYPE, POSTPERIOD_CLOSED, IS_HOLIDAY, IS_ALL_DAY_HOLIDAY, HOLIDAY_HOURS) 
			VALUES (@CURR_DATE, 0.00, NULL, @CURR_PP_CLOSED, @IS_HOLIDAY, @IS_ALL_DAY_HOLIDAY, @HOLIDAY_HOURS);
		
		END
		
		SET @DAY_COUNT = @DAY_COUNT - 1;
		
	END	
	
	UPDATE #DATE_RANGE 
	SET TOTAL_HOURS = EMP_TIME.EMP_TOT_HRS,
		TIMESHEET_APPROVAL_TYPE =
		CASE
			WHEN (ISNULL(APPR_FLAG, 0) = 0 AND ISNULL(APPR_PENDING, 0) = 1) THEN 1 -- PENDING
			WHEN (ISNULL(APPR_FLAG, 0) = 0 AND ISNULL(APPR_PENDING, 0) = 2) THEN 3 -- DENIED
			WHEN (ISNULL(APPR_FLAG, 0) = 1 AND (ISNULL(APPR_PENDING, 0) = 0 OR ISNULL(APPR_PENDING, 0) = 1)) THEN 2 -- APPROVED
			WHEN (EMP_TOT_HRS <> 0) AND (ISNULL(APPR_FLAG, 0) = 0 AND ISNULL(APPR_PENDING, 0) = 0) THEN 4 -- NOT SUBMITTED
			ELSE 0 -- OPEN AND EXISTS
		END
	FROM 
		EMP_TIME WITH(NOLOCK) INNER JOIN #DATE_RANGE ON EMP_TIME.EMP_DATE = #DATE_RANGE.THE_DATE
	WHERE 
		EMP_CODE = @EMP_CODE;
	
	UPDATE #DATE_RANGE SET TIMESHEET_APPROVAL_TYPE = 7 WHERE TIMESHEET_APPROVAL_TYPE IS NULL; --DOES NOT EXIST
	
	UPDATE #DATE_RANGE SET STD_HRS = @SUN_HRS WHERE DATEPART(dw, #DATE_RANGE.THE_DATE) = 1;
	UPDATE #DATE_RANGE SET STD_HRS = @MON_HRS WHERE DATEPART(dw, #DATE_RANGE.THE_DATE) = 2;
	UPDATE #DATE_RANGE SET STD_HRS = @TUE_HRS WHERE DATEPART(dw, #DATE_RANGE.THE_DATE) = 3;
	UPDATE #DATE_RANGE SET STD_HRS = @WED_HRS WHERE DATEPART(dw, #DATE_RANGE.THE_DATE) = 4;
	UPDATE #DATE_RANGE SET STD_HRS = @THU_HRS WHERE DATEPART(dw, #DATE_RANGE.THE_DATE) = 5;
	UPDATE #DATE_RANGE SET STD_HRS = @FRI_HRS WHERE DATEPART(dw, #DATE_RANGE.THE_DATE) = 6;
	UPDATE #DATE_RANGE SET STD_HRS = @SAT_HRS WHERE DATEPART(dw, #DATE_RANGE.THE_DATE) = 7;
	
	UPDATE #DATE_RANGE SET PERCENT_OF_STD_HRS = TOTAL_HOURS / STD_HRS WHERE STD_HRS <> 0.00;
	UPDATE #DATE_RANGE SET PERCENT_OF_STD_HRS = TOTAL_HOURS / (STD_HRS - HOLIDAY_HOURS) WHERE (STD_HRS - HOLIDAY_HOURS) <> 0.00 AND IS_HOLIDAY = 1 AND IS_ALL_DAY_HOLIDAY = 0;
	UPDATE #DATE_RANGE SET PERCENT_OF_STD_HRS = 1.000 WHERE PERCENT_OF_STD_HRS IS NULL;

	IF @TIME_APPR_ACTIVE = 0
	BEGIN

		UPDATE #DATE_RANGE SET TIMESHEET_APPROVAL_TYPE = 9 WHERE TIMESHEET_APPROVAL_TYPE = 4;

	END

	--SELECT * FROM #DATE_RANGE 

	IF @STATUS IN (1, 2, 3, 4, 9)
	BEGIN
		SELECT *
		FROM #DATE_RANGE 
		WHERE TIMESHEET_APPROVAL_TYPE = @STATUS
		ORDER BY THE_DATE ASC;
	END
	
	IF @STATUS = 5
	BEGIN
		SELECT *
		FROM #DATE_RANGE 
		WHERE TOTAL_HOURS < STD_HRS
		ORDER BY THE_DATE ASC;
	END

	IF @STATUS IN (0, 6)
	BEGIN
		SELECT *
		FROM #DATE_RANGE 
		ORDER BY THE_DATE ASC;
	END

	DROP TABLE #DATE_RANGE;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO