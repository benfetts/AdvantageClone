IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_digital_results_rpt]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_digital_results_rpt]
GO

CREATE PROCEDURE [dbo].[advsp_digital_results_rpt]
	@START_DATE SMALLDATETIME,
	@END_DATE SMALLDATETIME,
	@CRITERIA SMALLINT,
	@OfficeCodeList varchar(max)=null,
	@ClientCodeList varchar(max)=null,
	@ClientDivisionCodeList varchar(max)=null,
	@ClientDivisionProductCodeList varchar(max)=null,
	@broadcast_dates bit=0,
	@user_id varchar(100)

AS
BEGIN

 /* NOT USED IN .Net AT THIS POINT */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

	/*
		Criteria 
		---------------
		0 = Start Date between
		1 = End Date between

	*/

	/* Used for date calculation */   --#41
	DECLARE @cutoff_start_dt smalldatetime
	DECLARE @cutoff_end_dt smalldatetime
	DECLARE @start_month smallint
	DECLARE @start_year smallint
	DECLARE @end_month smallint
	DECLARE @end_year smallint

	SET @start_month = MONTH(@START_DATE)
	SET @start_year = YEAR(@START_DATE)
	SET @end_month = MONTH(@END_DATE)
	SET @end_year = YEAR(@END_DATE)

	DECLARE @brdcast_weeks TABLE (
		BRD_YEAR int,
		BRD_WEEK_START smalldatetime,
		BRD_WEEK_END smalldatetime,
		MONTH_NAME varchar(3)
		)

	DECLARE @brdcast_weeks2 TABLE (
		BRD_YEAR int,
		BRD_MONTH int,
		BRD_WEEK_START smalldatetime,
		BRD_WEEK_END smalldatetime,
		MONTH_NAME varchar(3),
		WEEK_NBR int,
		MMYYYY varchar(6)
		)

	IF @broadcast_dates = 1 BEGIN

		SELECT @cutoff_start_dt = DATEADD(day, -7, @start_date) /* Start date minus 1 week to cover broadcast week start date */
		SELECT @cutoff_end_dt = DATEADD(day, 7, @end_date) /* End  date plus 1 week to cover broadcast week end date */

		/* Populate broadcast calendar for given period */
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK1, DATEADD(d, 6, JAN_WK1) JAN_WK1_END , LEFT('JAN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK1 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK2, DATEADD(d, 6, JAN_WK2) JAN_WK2_END , LEFT('JAN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK2 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK3, DATEADD(d, 6, JAN_WK3) JAN_WK3_END , LEFT('JAN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK3 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK4, DATEADD(d, 6, JAN_WK4) JAN_WK4_END , LEFT('JAN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK4 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JAN_WK5, DATEADD(d, 6, JAN_WK5) JAN_WK5_END , LEFT('JAN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JAN_WK5 > @cutoff_start_dt AND JAN_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK1, DATEADD(d, 6, FEB_WK1) FEB_WK1_END , LEFT('FEB_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK1 > @cutoff_start_dt AND FEB_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK2, DATEADD(d, 6, FEB_WK2) FEB_WK2_END , LEFT('FEB_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK2 > @cutoff_start_dt AND FEB_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK3, DATEADD(d, 6, FEB_WK3) FEB_WK3_END , LEFT('FEB_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK3 > @cutoff_start_dt AND FEB_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK4, DATEADD(d, 6, FEB_WK4) FEB_WK4_END , LEFT('FEB_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK4 > @cutoff_start_dt AND FEB_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, FEB_WK5, DATEADD(d, 6, FEB_WK5) FEB_WK5_END , LEFT('FEB_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE FEB_WK5 > @cutoff_start_dt AND FEB_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK1, DATEADD(d, 6, MAR_WK1) MAR_WK1_END , LEFT('MAR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK1 > @cutoff_start_dt AND MAR_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK2, DATEADD(d, 6, MAR_WK2) MAR_WK2_END , LEFT('MAR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK2 > @cutoff_start_dt AND MAR_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK3, DATEADD(d, 6, MAR_WK3) MAR_WK3_END , LEFT('MAR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK3 > @cutoff_start_dt AND MAR_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK4, DATEADD(d, 6, MAR_WK4) MAR_WK4_END , LEFT('MAR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK4 > @cutoff_start_dt AND MAR_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAR_WK5, DATEADD(d, 6, MAR_WK5) MAR_WK5_END , LEFT('MAR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAR_WK5 > @cutoff_start_dt AND MAR_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK1, DATEADD(d, 6, APR_WK1) APR_WK1_END , LEFT('APR_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK1 > @cutoff_start_dt AND APR_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK2, DATEADD(d, 6, APR_WK2) APR_WK2_END , LEFT('APR_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK2 > @cutoff_start_dt AND APR_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK3, DATEADD(d, 6, APR_WK3) APR_WK3_END , LEFT('APR_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK3 > @cutoff_start_dt AND APR_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK4, DATEADD(d, 6, APR_WK4) APR_WK4_END , LEFT('APR_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK4 > @cutoff_start_dt AND APR_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, APR_WK5, DATEADD(d, 6, APR_WK5) APR_WK5_END , LEFT('APR_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE APR_WK5 > @cutoff_start_dt AND APR_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK1, DATEADD(d, 6, MAY_WK1) MAY_WK1_END , LEFT('MAY_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK1 > @cutoff_start_dt AND MAY_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK2, DATEADD(d, 6, MAY_WK2) MAY_WK2_END , LEFT('MAY_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK2 > @cutoff_start_dt AND MAY_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK3, DATEADD(d, 6, MAY_WK3) MAY_WK3_END , LEFT('MAY_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK3 > @cutoff_start_dt AND MAY_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK4, DATEADD(d, 6, MAY_WK4) MAY_WK4_END , LEFT('MAY_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK4 > @cutoff_start_dt AND MAY_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, MAY_WK5, DATEADD(d, 6, MAY_WK5) MAY_WK5_END , LEFT('MAY_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE MAY_WK5 > @cutoff_start_dt AND MAY_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK1, DATEADD(d, 6, JUN_WK1) JUN_WK1_END , LEFT('JUN_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK1 > @cutoff_start_dt AND JUN_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK2, DATEADD(d, 6, JUN_WK2) JUN_WK2_END , LEFT('JUN_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK2 > @cutoff_start_dt AND JUN_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK3, DATEADD(d, 6, JUN_WK3) JUN_WK3_END , LEFT('JUN_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK3 > @cutoff_start_dt AND JUN_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK4, DATEADD(d, 6, JUN_WK4) JUN_WK4_END , LEFT('JUN_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK4 > @cutoff_start_dt AND JUN_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUN_WK5, DATEADD(d, 6, JUN_WK5) JUN_WK5_END , LEFT('JUN_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUN_WK5 > @cutoff_start_dt AND JUN_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK1, DATEADD(d, 6, JUL_WK1) JUL_WK1_END , LEFT('JUL_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK1 > @cutoff_start_dt AND JUL_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK2, DATEADD(d, 6, JUL_WK2) JUL_WK2_END , LEFT('JUL_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK2 > @cutoff_start_dt AND JUL_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK3, DATEADD(d, 6, JUL_WK3) JUL_WK3_END , LEFT('JUL_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK3 > @cutoff_start_dt AND JUL_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK4, DATEADD(d, 6, JUL_WK4) JUL_WK4_END , LEFT('JUL_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK4 > @cutoff_start_dt AND JUL_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, JUL_WK5, DATEADD(d, 6, JUL_WK5) JUL_WK5_END , LEFT('JUL_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE JUL_WK5 > @cutoff_start_dt AND JUL_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK1, DATEADD(d, 6, AUG_WK1) AUG_WK1_END , LEFT('AUG_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK1 > @cutoff_start_dt AND AUG_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK2, DATEADD(d, 6, AUG_WK2) AUG_WK2_END , LEFT('AUG_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK2 > @cutoff_start_dt AND AUG_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK3, DATEADD(d, 6, AUG_WK3) AUG_WK3_END , LEFT('AUG_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK3 > @cutoff_start_dt AND AUG_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK4, DATEADD(d, 6, AUG_WK4) AUG_WK4_END , LEFT('AUG_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK4 > @cutoff_start_dt AND AUG_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, AUG_WK5, DATEADD(d, 6, AUG_WK5) AUG_WK5_END , LEFT('AUG_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE AUG_WK5 > @cutoff_start_dt AND AUG_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK1, DATEADD(d, 6, SEP_WK1) SEP_WK1_END , LEFT('SEP_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK1 > @cutoff_start_dt AND SEP_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK2, DATEADD(d, 6, SEP_WK2) SEP_WK2_END , LEFT('SEP_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK2 > @cutoff_start_dt AND SEP_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK3, DATEADD(d, 6, SEP_WK3) SEP_WK3_END , LEFT('SEP_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK3 > @cutoff_start_dt AND SEP_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK4, DATEADD(d, 6, SEP_WK4) SEP_WK4_END , LEFT('SEP_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK4 > @cutoff_start_dt AND SEP_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, SEP_WK5, DATEADD(d, 6, SEP_WK5) SEP_WK5_END , LEFT('SEP_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE SEP_WK5 > @cutoff_start_dt AND SEP_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK1, DATEADD(d, 6, OCT_WK1) OCT_WK1_END , LEFT('OCT_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK1 > @cutoff_start_dt AND OCT_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK2, DATEADD(d, 6, OCT_WK2) OCT_WK2_END , LEFT('OCT_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK2 > @cutoff_start_dt AND OCT_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK3, DATEADD(d, 6, OCT_WK3) OCT_WK3_END , LEFT('OCT_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK3 > @cutoff_start_dt AND OCT_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK4, DATEADD(d, 6, OCT_WK4) OCT_WK4_END , LEFT('OCT_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK4 > @cutoff_start_dt AND OCT_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, OCT_WK5, DATEADD(d, 6, OCT_WK5) OCT_WK5_END , LEFT('OCT_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE OCT_WK5 > @cutoff_start_dt AND OCT_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK1, DATEADD(d, 6, NOV_WK1) NOV_WK1_END , LEFT('NOV_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK1 > @cutoff_start_dt AND NOV_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK2, DATEADD(d, 6, NOV_WK2) NOV_WK2_END , LEFT('NOV_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK2 > @cutoff_start_dt AND NOV_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK3, DATEADD(d, 6, NOV_WK3) NOV_WK3_END , LEFT('NOV_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK3 > @cutoff_start_dt AND NOV_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK4, DATEADD(d, 6, NOV_WK4) NOV_WK4_END , LEFT('NOV_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK4 > @cutoff_start_dt AND NOV_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, NOV_WK5, DATEADD(d, 6, NOV_WK5) NOV_WK5_END , LEFT('NOV_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE NOV_WK5 > @cutoff_start_dt AND NOV_WK5 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK1, DATEADD(d, 6, DEC_WK1) DEC_WK1_END , LEFT('DEC_WK1', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK1 > @cutoff_start_dt AND DEC_WK1 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK2, DATEADD(d, 6, DEC_WK2) DEC_WK2_END , LEFT('DEC_WK2', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK2 > @cutoff_start_dt AND DEC_WK2 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK3, DATEADD(d, 6, DEC_WK3) DEC_WK3_END , LEFT('DEC_WK3', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK3 > @cutoff_start_dt AND DEC_WK3 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK4, DATEADD(d, 6, DEC_WK4) DEC_WK4_END , LEFT('DEC_WK4', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK4 > @cutoff_start_dt AND DEC_WK4 < @cutoff_end_dt
		INSERT INTO @brdcast_weeks SELECT BRD_YEAR, DEC_WK5, DATEADD(d, 6, DEC_WK5) DEC_WK5_END , LEFT('DEC_WK5', 3) MONTH_NAME FROM BRDCAST_CAL WHERE DEC_WK5 > @cutoff_start_dt AND DEC_WK5 < @cutoff_end_dt

		INSERT INTO @brdcast_weeks2
		SELECT 
			BRD_YEAR, 
			MONTH(CAST(MONTH_NAME + ' 1 2001' AS smalldatetime)) BRD_MONTH, 
			BRD_WEEK_START, 
			BRD_WEEK_END, 
			MONTH_NAME, 
			RANK() OVER (PARTITION BY BRD_YEAR, MONTH_NAME 
						ORDER BY BRD_YEAR, BRD_WEEK_START) AS WEEK_NBR,
			RIGHT('00' + CAST(MONTH(CAST(MONTH_NAME + ' 1 2001' AS smalldatetime)) AS varchar(2)), 2) + CAST(BRD_YEAR AS varchar(4)) AS MMYYYY
		FROM @brdcast_weeks 
		ORDER BY BRD_YEAR, BRD_MONTH, BRD_WEEK_START

		--SELECT @START_DATE '@start_date', @END_DATE '@end_date'  --#41  --DEBUG

		/* Set Start and end dates to their broadcast equivelants */
		SELECT @START_DATE = MIN(BRD_WEEK_START) FROM @brdcast_weeks2 WHERE BRD_MONTH = @start_month AND BRD_YEAR = @start_year
		SELECT @END_DATE = MAX(BRD_WEEK_END) FROM @brdcast_weeks2 WHERE BRD_MONTH = @end_month AND BRD_YEAR = @end_year

		--SELECT @START_DATE '@start_date', @END_DATE '@end_date'  --#41  --DEBUG

	END

	DECLARE @END_TIME DATETIME

	SET	@END_TIME = CAST(CONVERT(VARCHAR, @END_DATE, 101) + ' 23:59:59' AS DATETIME)
	
	SELECT
		[ID] = NEWID(), 
		[MediaPlanID] = V_DIGITAL_RESULTS.MediaPlanID,
		[MediaPlanDescription] = V_DIGITAL_RESULTS.MediaPlanDescription,
		[ClientCode] = V_DIGITAL_RESULTS.ClientCode,
		[ClientName] = V_DIGITAL_RESULTS.ClientName,
		[DivisionCode] = V_DIGITAL_RESULTS.DivisionCode,
		[DivisionName] = V_DIGITAL_RESULTS.DivisionName,
		[ProductCode] = V_DIGITAL_RESULTS.ProductCode,
		[ProductName] = V_DIGITAL_RESULTS.ProductName,
		[JobNumber] = V_DIGITAL_RESULTS.JobNumber,
		[JobDescription] = V_DIGITAL_RESULTS.JobDescription,
		[JobComponentNumber] = V_DIGITAL_RESULTS.JobComponentNumber,
		[JobComponentDescription] = V_DIGITAL_RESULTS.JobComponentDescription,
		[EstimateID] = V_DIGITAL_RESULTS.EstimateID,
		[EstimateDescription] = V_DIGITAL_RESULTS.EstimateDescription,
		[MediaType] = V_DIGITAL_RESULTS.MediaType,
		[SalesClassCode] = V_DIGITAL_RESULTS.SalesClassCode,
		[SalesClassDescription] = V_DIGITAL_RESULTS.SalesClassDescription,
		[CampaignID] = V_DIGITAL_RESULTS.CampaignID,
		[CampaignCode] = V_DIGITAL_RESULTS.CampaignCode,
		[CampaignName] = V_DIGITAL_RESULTS.CampaignName,
		[VendorCode] = V_DIGITAL_RESULTS.VendorCode,
		[VendorName] = V_DIGITAL_RESULTS.VendorName,
		[MarketCode] = V_DIGITAL_RESULTS.MarketCode,
		[MarketDescription] = V_DIGITAL_RESULTS.MarketDescription,
		[AdSizeCode] = V_DIGITAL_RESULTS.AdSizeCode,
		[AdSizeDescription] = V_DIGITAL_RESULTS.AdSizeDescription,
		[AdNumber] = V_DIGITAL_RESULTS.AdNumber,
		[AdNumberDescription] = V_DIGITAL_RESULTS.AdNumberDescription,
		[InternetTypeCode] = V_DIGITAL_RESULTS.InternetTypeCode,
		[InternetTypeDescription] = V_DIGITAL_RESULTS.InternetTypeDescription,	
		[TargetAudience] = V_DIGITAL_RESULTS.TargetAudience,
		[Placement] = V_DIGITAL_RESULTS.Placement,
		[PlacementPixelSize] = V_DIGITAL_RESULTS.PlacementPixelSize,
		[PlacementURL] = V_DIGITAL_RESULTS.PlacementURL,
		[Creative] = V_DIGITAL_RESULTS.Creative,
		[Tactic] = V_DIGITAL_RESULTS.Tactic,
		[PagePositioning] = V_DIGITAL_RESULTS.PagePositioning,
		[StartDate] = V_DIGITAL_RESULTS.StartDate,
		[EndDate] = V_DIGITAL_RESULTS.EndDate,
		[NetGrossRate] = CASE WHEN V_DIGITAL_RESULTS.NetGrossRate = 0 THEN 'Net' WHEN V_DIGITAL_RESULTS.NetGrossRate = 1 THEN 'Gross' END,
		[Units] = V_DIGITAL_RESULTS.Units,
		[Impressions] = V_DIGITAL_RESULTS.Impressions,
		[ImpressionsViewable] = V_DIGITAL_RESULTS.ImpressionsViewable,
		[ImpressionsMeasurable] = V_DIGITAL_RESULTS.ImpressionsMeasurable,
		[Clicks] = V_DIGITAL_RESULTS.Clicks,
		[ClickRate] = V_DIGITAL_RESULTS.ClickRate,
		[TotalConversions] = V_DIGITAL_RESULTS.TotalConversions,
		[TotalConversionsB] = V_DIGITAL_RESULTS.TotalConversionsB,
		[TotalConversionsC] = V_DIGITAL_RESULTS.TotalConversionsC,
		[Rate] = V_DIGITAL_RESULTS.Rate,
		[NetDollars] = V_DIGITAL_RESULTS.NetDollars,
		[GrossDollars] = V_DIGITAL_RESULTS.GrossDollars,
		[ConversionRate] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(V_DIGITAL_RESULTS.Clicks, 0) <> 0 THEN ISNULL(V_DIGITAL_RESULTS.TotalConversions, 0) / ISNULL(V_DIGITAL_RESULTS.Clicks, 0) * 100 END),
		[ConversionRateB] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(V_DIGITAL_RESULTS.Clicks, 0) <> 0 THEN ISNULL(V_DIGITAL_RESULTS.TotalConversionsB, 0) / ISNULL(V_DIGITAL_RESULTS.Clicks, 0) * 100 END),
		[ConversionRateC] = CONVERT(DECIMAL(10,2), CASE WHEN ISNULL(V_DIGITAL_RESULTS.Clicks, 0) <> 0 THEN ISNULL(V_DIGITAL_RESULTS.TotalConversionsC, 0) / ISNULL(V_DIGITAL_RESULTS.Clicks, 0) * 100 END),
		[DaypartCode] = V_DIGITAL_RESULTS.DaypartCode,

		[Month] = CASE WHEN @broadcast_dates = 0 THEN MC.[MONTH] ELSE MC.BROADCAST_MONTH END,
		[MonthName] = CASE WHEN @broadcast_dates = 0 THEN CASE WHEN MC.[MONTH] = 1 THEN 'January'
																    WHEN MC.[MONTH] = 2 THEN 'February'
																    WHEN MC.[MONTH] = 3 THEN 'March'
																    WHEN MC.[MONTH] = 4 THEN 'April'
																    WHEN MC.[MONTH] = 5 THEN 'May'
																    WHEN MC.[MONTH] = 6 THEN 'June'
																    WHEN MC.[MONTH] = 7 THEN 'July'
																    WHEN MC.[MONTH] = 8 THEN 'August'
																    WHEN MC.[MONTH] = 9 THEN 'September'
																    WHEN MC.[MONTH] = 10 THEN 'October'
																    WHEN MC.[MONTH] = 11 THEN 'November'
																    WHEN MC.[MONTH] = 12 THEN 'December' END ELSE CASE WHEN MC.BROADCAST_MONTH = 1 THEN 'January'
																													   WHEN MC.BROADCAST_MONTH = 2 THEN 'February'
																													   WHEN MC.BROADCAST_MONTH = 3 THEN 'March'
																													   WHEN MC.BROADCAST_MONTH = 4 THEN 'April'
																													   WHEN MC.BROADCAST_MONTH = 5 THEN 'May'
																													   WHEN MC.BROADCAST_MONTH = 6 THEN 'June'
																													   WHEN MC.BROADCAST_MONTH = 7 THEN 'July'
																													   WHEN MC.BROADCAST_MONTH = 8 THEN 'August'
																													   WHEN MC.BROADCAST_MONTH = 9 THEN 'September'
																													   WHEN MC.BROADCAST_MONTH = 10 THEN 'October'
																													   WHEN MC.BROADCAST_MONTH = 11 THEN 'November'
																													   WHEN MC.BROADCAST_MONTH = 12 THEN 'December' END END,
		[Year] = CASE WHEN @broadcast_dates = 0 THEN MC.[YEAR] ELSE MC.BROADCAST_YEAR END
	INTO #tmp_media
	FROM
		dbo.V_DIGITAL_RESULTS LEFT JOIN 
		dbo.MEDIA_CALENDAR AS MC ON MC.[DATE] = V_DIGITAL_RESULTS.StartDate
	WHERE	
				(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND V_DIGITAL_RESULTS.[OfficeCode] IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND V_DIGITAL_RESULTS.[ClientCode] IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND V_DIGITAL_RESULTS.[ClientCode] + '|' + V_DIGITAL_RESULTS.[DivisionCode] IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND V_DIGITAL_RESULTS.[ClientCode] + '|' + V_DIGITAL_RESULTS.[DivisionCode] + '|' + V_DIGITAL_RESULTS.[ProductCode] IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))	
		AND
		1 = CASE 
				WHEN @CRITERIA = 0 AND V_DIGITAL_RESULTS.StartDate BETWEEN @START_DATE AND @END_TIME THEN 1
				WHEN @CRITERIA = 1 AND V_DIGITAL_RESULTS.EndDate BETWEEN @START_DATE AND @END_TIME THEN 1
				ELSE 0 
			END 

	/* PJH 09/30/2019 - Add CDP Security - BEG */

	DECLARE @Restrictions int

	SELECT
			@Restrictions = COUNT(*) 
	FROM 
		dbo.SEC_CLIENT
	WHERE 
		UPPER([USER_ID]) = UPPER(@user_id)
		
	CREATE TABLE #Orders([ID] varchar(max) NOT NULL)
	CREATE TABLE #UniqueProducts(CDPCode varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL)

	IF @Restrictions > 0 BEGIN /* Only allow valid CDP for current user */

		INSERT INTO #UniqueProducts(CDPCode)
		SELECT
			DISTINCT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE
		FROM
			dbo.SEC_CLIENT
		WHERE 
			UPPER([USER_ID]) = UPPER(@user_id)

		INSERT INTO #Orders
		SELECT [ID] FROM #tmp_media A  
		INNER JOIN #UniqueProducts AS B ON B.CDPCode = CAST(A.[ClientCode] + '|' + A.[DivisionCode] + '|' + A.[ProductCode] AS varchar(30))

	END
	ELSE BEGIN /* All Qualify */

		INSERT INTO #Orders
		SELECT DISTINCT [ID] FROM #tmp_media
	END

	/* PJH 09/30/2019 - Add CDP Security - END */

	SELECT A.* 
	FROM #tmp_media A JOIN #Orders B ON A.ID = B.ID


END


GO

GRANT EXECUTE ON [advsp_digital_results_rpt] TO PUBLIC AS dbo
GO