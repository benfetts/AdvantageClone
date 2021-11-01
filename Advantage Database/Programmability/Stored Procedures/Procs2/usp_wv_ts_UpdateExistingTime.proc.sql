SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_UpdateExistingTime]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_UpdateExistingTime]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_UpdateExistingTime] /*WITH ENCRYPTION*/
@ET_ID INT,
@ET_DTL_ID INT,
@HOURS DECIMAL(9,3),
@START_TIME SMALLDATETIME,
@END_TIME SMALLDATETIME,
@TIME_TYPE VARCHAR(1),
@USER_CODE VARCHAR(100),
@CREATE_DATE SMALLDATETIME
AS
/*=========== QUERY ===========*/
	DECLARE
		@emp_code VARCHAR(6), 
		@emp_date SMALLDATETIME, 
		@fnc_cat VARCHAR(10), 
		@job_nbr INTEGER, 
		@job_cmp_nbr SMALLINT, 
		@dp_tm VARCHAR(4),
		@ProdCat VARCHAR(10), 
		@error_text VARCHAR(MAX),
		@GOT_UPDATE_DATA BIT,
		@CURRENT_HOURS DECIMAL(9,3),
		@TRF_CODE VARCHAR(10),
		@ALERT_ID INT

	SET @GOT_UPDATE_DATA = 0;

	IF @TIME_TYPE = 'D'
	BEGIN

		SELECT        
			@emp_code = EMP_TIME.EMP_CODE, 
			@emp_date =  EMP_TIME.EMP_DATE, 
			@fnc_cat = EMP_TIME_DTL.FNC_CODE, 
			@job_nbr = EMP_TIME_DTL.JOB_NUMBER, 
			@job_cmp_nbr = EMP_TIME_DTL.JOB_COMPONENT_NBR, 
			@dp_tm =  EMP_TIME_DTL.DP_TM_CODE, 
			@ProdCat =  EMP_TIME_DTL.PROD_CAT_CODE,
			@CURRENT_HOURS = EMP_TIME_DTL.EMP_HOURS,
			@TRF_CODE = EMP_TIME_DTL.TRF_CODE,
			@ALERT_ID = EMP_TIME_DTL.ALERT_ID
		FROM            
			EMP_TIME_DTL WITH(NOLOCK) INNER JOIN
			EMP_TIME WITH(NOLOCK) ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID
		WHERE
			EMP_TIME_DTL.ET_ID = @ET_ID
			AND EMP_TIME_DTL.ET_DTL_ID = @ET_DTL_ID;

		SET @GOT_UPDATE_DATA = 1;

	END

	IF @TIME_TYPE = 'N'
	BEGIN

		SELECT        
			@emp_code = EMP_TIME.EMP_CODE, 
			@emp_date =  EMP_TIME.EMP_DATE, 
			@fnc_cat = EMP_TIME_NP.CATEGORY, 
			@job_nbr = 0, 
			@job_cmp_nbr = 0, 
			@dp_tm =  EMP_TIME_NP.DP_TM_CODE,
			@CURRENT_HOURS = EMP_TIME_NP.EMP_HOURS
		FROM            
			EMP_TIME_NP WITH(NOLOCK) INNER JOIN
			EMP_TIME WITH(NOLOCK) ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID
		WHERE
			EMP_TIME_NP.ET_ID = @ET_ID
			AND EMP_TIME_NP.ET_DTL_ID = @ET_DTL_ID;

		SET @GOT_UPDATE_DATA = 1;

	END

	SET @CURRENT_HOURS = ISNULL(@CURRENT_HOURS, 0.00);

	IF @GOT_UPDATE_DATA = 1
	BEGIN

		SET @HOURS = @HOURS + @CURRENT_HOURS;

		EXEC usp_wv_ts_SaveTimeSheetDay @ET_ID,
										@ET_DTL_ID,
										@emp_code,
										@emp_date,
										@fnc_cat,
										@HOURS,
										@job_nbr,
										@job_cmp_nbr,
										@dp_tm,
										@START_TIME,
										@END_TIME,
										@ProdCat,
										@USER_CODE,
										NULL,
										@TRF_CODE,
										@error_text,
										@CREATE_DATE,
										@ALERT_ID,
										0;

	END

	SELECT @error_text;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


