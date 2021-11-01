CREATE PROCEDURE [dbo].[advsp_job_forecast_allocate]
	@RevisionID int,
	@ForecastJobID int, 
	@BillingAllocationAmount decimal(15,2),
	@RevenueAllocationAmount decimal(15,2),
	@UserCode varchar(100)
AS
BEGIN
		
	Declare @JobDetails Table (ForecastJobID int,
							   DetailID int,
							   PostPeriodCode varchar(6),
							   BillingAmount decimal(15,2),
							   RevenueAmount decimal(15,2))

	Declare @ForecastPostPeriods Table (PostPeriodCode varchar(6))

	Declare @PostPeriodStartDate smalldatetime,
			@PostPeriodEndDate smalldatetime,
			@PostPeriodEndCode varchar(6),
			@ForecastID int,
			@TotalForecastPostPeriods int,
			@BillingSplitAmount decimal(15,2),
			@RevenueSplitAmount decimal(15,2),
			@AllocateBilling bit,
			@AllocateRevenue bit,
			@Debug bit

	Set @Debug = 0
	
	Set @BillingAllocationAmount = IsNull(@BillingAllocationAmount, 0)
	Set @RevenueAllocationAmount = IsNull(@RevenueAllocationAmount, 0)

	Select
		@ForecastID = Rev.JF_ID,
		@PostPeriodStartDate = PPStart.PPSRTDATE,
		@PostPeriodEndDate = PPEnd.PPENDDATE,
		@PostPeriodEndCode = PPEnd.PPPERIOD,
		@AllocateBilling = Case When IsNull(Hdr.JF_TYPE, 0) In (0,2) Then 1 Else 0 End,
		@AllocateRevenue = Case When IsNull(Hdr.JF_TYPE, 0) In (1,2) Then 1 Else 0 End
	From
		dbo.JF_REV Rev 
	Join
		dbo.JF_HDR Hdr On Rev.JF_ID = Hdr.JF_ID 
	Join
		dbo.POSTPERIOD PPStart On Hdr.PPPERIOD_START = PPStart.PPPERIOD 
	Join
		dbo.POSTPERIOD PPEnd On Hdr.PPPERIOD_END = PPEnd.PPPERIOD
	Where
		Rev.JF_REV_ID = @RevisionID

	Insert Into 
		@ForecastPostPeriods
	Select
		PPPERIOD
	From
		dbo.POSTPERIOD
	Where
		PPSRTDATE >= @PostPeriodStartDate And
		PPENDDATE <= @PostPeriodEndDate And
		IsNull(PPGLMONTH, 99) <> 99
	
	Select 
		@TotalForecastPostPeriods = Count(*) 
	From 
		@ForecastPostPeriods 

	Set @BillingSplitAmount = Convert(decimal(15,2), @BillingAllocationAmount / @TotalForecastPostPeriods)
	Set @RevenueSplitAmount = Convert(decimal(15,2), @RevenueAllocationAmount / @TotalForecastPostPeriods)

	Insert Into	
		@JobDetails (ForecastJobID, DetailID, PostPeriodCode, BillingAmount, RevenueAmount)
	Select
		comp.JF_JOB_ID,
		dtl.JF_JOB_DTL_ID,
		pp.PostPeriodCode,
		[BillingAmount] = Case When @BillingSplitAmount <> 0 Then @BillingSplitAmount Else dtl.BILLING_AMT End, -- Prevents overwrite when only allocating Revenue in Billing & Revenue Forecast
		[RevenueAmount] = Case When @RevenueSplitAmount <> 0 Then @RevenueSplitAmount Else dtl.REVENUE_AMT End  -- Prevents overwrite when only allocating Billing in Billing & Revenue Forecast
	From
		@ForecastPostPeriods pp
	Join
		dbo.JF_JOB comp On 1 = 1
	Left Outer Join
		dbo.JF_JOB_DTL dtl On comp.JF_JOB_ID = dtl.JF_JOB_ID And
							  dtl.PPPERIOD = pp.PostPeriodCode
	Where
		comp.JF_REV_ID = @RevisionID And
		comp.JF_JOB_ID = @ForecastJobID

	If (@BillingSplitAmount * @TotalForecastPostPeriods) <> @BillingAllocationAmount
	Begin

		Update
			@JobDetails
		Set
			BillingAmount = @BillingSplitAmount - ((@BillingSplitAmount * @TotalForecastPostPeriods) - @BillingAllocationAmount)
		Where
			PostPeriodCode = @PostPeriodEndCode

	End

	If (@RevenueSplitAmount * @TotalForecastPostPeriods) <> @RevenueAllocationAmount
	Begin

		Update
			@JobDetails
		Set
			RevenueAmount = @RevenueSplitAmount - ((@RevenueSplitAmount * @TotalForecastPostPeriods) - @RevenueAllocationAmount)
		Where
			PostPeriodCode = @PostPeriodEndCode

	End

	If @Debug = 1
	Begin
		
		Select * From @ForecastPostPeriods
		Select * From @JobDetails

	End
	Else
	Begin

		If @AllocateBilling = 0
			Update
				@JobDetails
			Set	
				BillingAmount = Null

		If @AllocateRevenue = 0
			Update
				@JobDetails
			Set	
				RevenueAmount = Null
	
		Insert Into	
			dbo.JF_JOB_DTL (JF_JOB_ID, JF_REV_ID, JF_ID, PPPERIOD, BILLING_AMT, REVENUE_AMT, USER_CREATED, CREATED_DATE)
		Select
			dtl.ForecastJobID,
			@RevisionID,
			@ForecastID,
			dtl.PostPeriodCode,
			dtl.BillingAmount,
			dtl.RevenueAmount,
			@UserCode,
			GetDate()
		From	
			@JobDetails dtl
		Where
			DetailID Is Null

		Update
			JfJobDtl
		Set
			BILLING_AMT = dtl.BillingAmount,
			REVENUE_AMT = dtl.RevenueAmount,
			USER_MODIFIED = @UserCode,
			MODIFIED_DATE = GetDate()
		From
			dbo.JF_JOB_DTL JfJobDtl
		Join
			@JobDetails dtl On JfJobDtl.JF_JOB_DTL_ID = dtl.DetailID
		Where
			dtl.DetailID Is Not Null

		Update
			dbo.JF_REV
		Set
			USER_MODIFIED = @UserCode,
			MODIFIED_DATE = GetDate()
		Where
			JF_REV_ID = @RevisionID

		Update
			dbo.JF_HDR
		Set
			USER_MODIFIED = @UserCode,
			MODIFIED_DATE = GetDate()
		Where
			JF_ID = @ForecastID

	End

END