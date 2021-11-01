Create Procedure [dbo].[advsp_job_forecast_actualize]
	@RevisionID int,
	@ForecastJobList varchar(max) = NULL, -- optional. Omit to actualize entire forecast.
	@RollFowardBalance bit,
	@RollFowardNextMonthOnly bit,
	@PostPeriodCutoff varchar(6),
	@UserCode varchar(100)
As
Begin

	SET NOCOUNT ON

	Declare @Debug bit

	Set @Debug = 0

	/*
		Variables
	*/
	Declare @ForecastDetailRecords Table (JobForecastJobID int,
										  JobNumber int,
										  JobComponentNumber smallint,
										  JobForecastJobDetailID int,
										  PostPeriodCode varchar(6),
										  PostPeriodStartDate smalldatetime,
										  PostPeriodEndDate smalldatetime,
										  BillingAmount decimal(15,2),
										  RevenueAmount decimal(15,2),
										  IsCutoff bit)

	Declare @Totals Table (JobForecastJobID int,
						   OriginalBillingTotal decimal(15,2),
						   OriginalRevenueTotal decimal(15,2),
						   NewBillingTotal decimal(15,2),
						   NewRevenueTotal decimal(15,2))

	Declare @ForecastJobs Table (JobForecastJobID int)

	Declare @ForecastID int,
			@PostPeriodStartDate smalldatetime,
			@PostPeriodEndDate smalldatetime,
			@PostPeriodCutoffDate smalldatetime,
			@DoBilling bit,
			@DoRevenue bit,
			@CutoffPostPeriodCount smallint,
			@JobNumber int,
			@JobComponentNumber int,
			@NextPostPeriod varchar(6)
			
	Select
		@ForecastID = JF_REV.JF_ID,
		@PostPeriodStartDate = PP_START.PPSRTDATE,
		@PostPeriodEndDate = PP_END.PPENDDATE,
		@DoBilling = Case When ISNULL(JF_HDR.JF_TYPE, 0) IN (0, 2) Then 1 Else 0 End,
		@DoRevenue = Case When ISNULL(JF_HDR.JF_TYPE, 0) IN (1, 2) Then 1 Else 0 End
	From
		dbo.JF_REV JOIN
		dbo.JF_HDR ON JF_REV.JF_ID = JF_HDR.JF_ID JOIN
		dbo.POSTPERIOD PP_START ON JF_HDR.PPPERIOD_START = PP_START.PPPERIOD JOIN
		dbo.POSTPERIOD PP_END ON JF_HDR.PPPERIOD_END = PP_END.PPPERIOD
	Where
		JF_REV.JF_REV_ID = @RevisionID

	Select
		@PostPeriodCutoffDate = PPENDDATE
	From
		dbo.POSTPERIOD 
	Where
		PPPERIOD = @PostPeriodCutoff

	If IsNull(@ForecastJobList, '') <> ''
	Begin

		Insert Into 
			@ForecastJobs
		Select 
			Convert(int, items)
		From
			dbo.udf_split_list(@ForecastJobList, ',')

	End
	Else
	Begin

		Insert Into 
			@ForecastJobs
		Select 
			JF_JOB.JF_JOB_ID
		From
			dbo.JF_JOB
		Where
			JF_REV_ID = @RevisionID

	End

	Insert Into
		@ForecastDetailRecords (JobForecastJobID, JobNumber, JobComponentNumber, JobForecastJobDetailID, PostPeriodCode, PostPeriodStartDate, PostPeriodEndDate, BillingAmount, RevenueAmount, IsCutoff)
	Select
		[JobForecastJobID] = comps.JF_JOB_ID,
		[JobNumber] = comps.JOB_NUMBER,
		[JobComponentNumber] = comps.JOB_COMPONENT_NBR,
		[JobForecastJobDetailID] = dtl.JF_JOB_DTL_ID,
		[PostPeriodCode] = pp.PPPERIOD,
		[PostPeriodStartDate] = pp.PPSRTDATE,
		[PostPeriodEndDate] = pp.PPENDDATE,
		[BillingAmount] = dtl.BILLING_AMT,
		[RevenueAmount] = dtl.REVENUE_AMT,
		[IsCutoff] = Case When pp.PPENDDATE <= @PostPeriodCutoffDate Then 0 Else 1 End
	From
		dbo.POSTPERIOD pp Join
		dbo.JF_JOB comps On 1 = 1 Left Outer Join
		dbo.JF_JOB_DTL dtl On comps.JF_JOB_ID = dtl.JF_JOB_ID And
							  dtl.PPPERIOD = pp.PPPERIOD Join
		@ForecastJobs FilteredJobs On comps.JF_JOB_ID = FilteredJobs.JobForecastJobID
	Where
		pp.PPSRTDATE >= @PostPeriodStartDate And
		pp.PPENDDATE <= @PostPeriodEndDate And
		pp.PPGLMONTH Is Not Null And
		pp.PPGLMONTH <> 99 And
		comps.JF_REV_ID = @RevisionID And
		1 = Case When @RollFowardBalance = 1 Then 1 When pp.PPENDDATE <= @PostPeriodCutoffDate Then 1 Else 0 End

	Insert Into 
		@Totals (JobForecastJobID, OriginalBillingTotal, OriginalRevenueTotal)
	Select
		JobForecastJobID,
		[OriginalBillingTotal] = Case When @DoBilling = 1 Then Sum(IsNull(BillingAmount, 0)) Else 0 End,
		[OriginalRevenueTotal] = Case When @DoRevenue = 1 Then Sum(IsNull(RevenueAmount, 0)) Else 0 End
	FROM
		@ForecastDetailRecords
	Group By
		JobForecastJobID

	Update
		dtl
	Set
		dtl.BillingAmount = Case 
								When @DoBilling = 1 Then (Select
															IsNull(Sum(IsNull(a.ActualBillableAmount, 0)), 0)
														  From
															dbo.V_JOB_COMP_ACTUALS a
														  Where
															a.JobNumber = dtl.JobNumber And
															a.ComponentNumber = dtl.JobComponentNumber And
															a.FunctionType In ('E', 'I', 'V') And
															a.ItemDate >= dtl.PostPeriodStartDate And
															a.ItemDate <= dtl.PostPeriodEndDate) 
								Else Null 
							End,
		dtl.RevenueAmount = Case 
								When @DoRevenue = 1 Then (Select
															IsNull(Sum(IsNull(a.ActualRevenueAmount, 0)), 0)
														  From
															dbo.V_JOB_COMP_ACTUALS a
														  Where
															a.JobNumber = dtl.JobNumber And
															a.ComponentNumber = dtl.JobComponentNumber And
															a.FunctionType In ('E', 'I', 'V') And
															a.ItemDate >= dtl.PostPeriodStartDate And
															a.ItemDate <= dtl.PostPeriodEndDate) 
								Else Null 
							End
	From
		@ForecastDetailRecords dtl
	Where
		dtl.IsCutoff = 0

	If @RollFowardBalance = 1
	Begin

		Update
			totals
		Set
			NewBillingTotal = Case When @DoBilling = 1 Then dtl.BillingTotal Else 0 End,
			NewRevenueTotal = Case When @DoRevenue = 1 Then dtl.RevenueTotal Else 0 End
		From	
			@Totals totals join
			(Select	
				JobForecastJobID,
				[BillingTotal] = Sum(IsNull(BillingAmount, 0)),
				[RevenueTotal] = Sum(Isnull(RevenueAmount, 0))
			 From
				@ForecastDetailRecords
			 Group By
				JobForecastJobID) dtl On totals.JobForecastJobID = dtl.JobForecastJobID
		
		If @RollFowardNextMonthOnly = 1
		Begin

			Select Top 1 @NextPostPeriod = PPPERIOD From dbo.POSTPERIOD Where PPSRTDATE > @PostPeriodCutoffDate Order By PPSRTDATE Asc

			If Not ISNULL(@NextPostPeriod, '') = ''
				Select @CutoffPostPeriodCount = 1
			Else
				Select @CutoffPostPeriodCount = 0

		End
		Else
		Begin
			
			Select
				@CutoffPostPeriodCount = Count(Distinct PostPeriodCode)
			From	
				@ForecastDetailRecords
			Where
				IsCutoff = 1
		
		End
	
		If @CutoffPostPeriodCount > 0 
		Begin

			Update
				dtl
			Set 
				dtl.BillingAmount = Case When @DoBilling = 1 Then Convert(decimal(15,2), (totals.OriginalBillingTotal - totals.NewBillingTotal) / @CutoffPostPeriodCount) + IsNull(dtl.BillingAmount, 0) Else Null End,
				dtl.RevenueAmount = Case When @DoRevenue = 1 Then Convert(decimal(15,2), (totals.OriginalRevenueTotal - totals.NewRevenueTotal) / @CutoffPostPeriodCount) + IsNull(dtl.RevenueAmount, 0) Else Null End
			From
				@ForecastDetailRecords dtl Join
				@Totals totals On dtl.JobForecastJobID = totals.JobForecastJobID
			Where
				1 = Case 
						When @RollFowardNextMonthOnly = 1 And dtl.PostPeriodCode = @NextPostPeriod Then 1
						When @RollFowardNextMonthOnly = 0 And dtl.IsCutoff = 1 Then 1
						Else 0
					End

		End
			
		Update
			totals
		Set
			NewBillingTotal = Case When @DoBilling = 1 Then dtl.BillingTotal Else 0 End,
			NewRevenueTotal = Case When @DoRevenue = 1 Then dtl.RevenueTotal Else 0 End
		From	
			@Totals totals join
			(Select	
				JobForecastJobID,
				[BillingTotal] = Sum(IsNull(BillingAmount, 0)),
				[RevenueTotal] = Sum(Isnull(RevenueAmount, 0))
			 From
				@ForecastDetailRecords
			 Group By
				JobForecastJobID) dtl On totals.JobForecastJobID = dtl.JobForecastJobID
	
		/*
			Fix any rounding errors
		*/	
		Update
			dtl
		Set 
			dtl.BillingAmount = Case When @DoBilling = 1 Then dtl.BillingAmount - (totals.NewBillingTotal - totals.OriginalBillingTotal) Else Null End,
			dtl.RevenueAmount = Case When @DoRevenue = 1 Then dtl.RevenueAmount - (totals.NewRevenueTotal - totals.OriginalRevenueTotal) Else Null End
		From
			@ForecastDetailRecords dtl Join
			(Select Top 1
				JobForecastJobID,
				PostPeriodCode
			 From	
				@ForecastDetailRecords
			 Where
				IsCutoff = 1
			 Order By
				PostPeriodEndDate Desc) maxDtl On dtl.JobForecastJobID = maxDtl.JobForecastJobID And
												  dtl.PostPeriodCode = maxDtl.PostPeriodCode Join
			@Totals totals On dtl.JobForecastJobID = totals.JobForecastJobID
		Where
			dtl.IsCutoff = 1

	End

	If @Debug = 1
	Begin

		Select
			[DoBilling] = @DoBilling,
			[DoRevenue] = @DoRevenue,
			[CutoffPostPeriodCount] = @CutoffPostPeriodCount

		Select * From @Totals
		Select * From @ForecastDetailRecords Order By JobNumber Desc, JobComponentNumber Desc, PostPeriodStartDate Asc
		
	End
	Else
	Begin

		/*
			Update Exisiting Records
		*/
		Update
			JF_JOB_DTL
		Set 
			BILLING_AMT = Case When @DoBilling = 1 Then dtl.BillingAmount Else Null End,
			REVENUE_AMT = Case When @DoRevenue = 1 Then dtl.RevenueAmount Else Null End,
			USER_MODIFIED = @UserCode,
			MODIFIED_DATE = GetDate()
		From
			dbo.JF_JOB_DTL Join
			@ForecastDetailRecords dtl On JF_JOB_DTL.JF_JOB_DTL_ID = dtl.JobForecastJobDetailID 
		Where
			dtl.JobForecastJobDetailID Is Not Null

		/*
			Insert Any Missing
		*/
		Insert Into
			dbo.JF_JOB_DTL (JF_JOB_ID, JF_REV_ID, JF_ID, PPPERIOD, BILLING_AMT, REVENUE_AMT, USER_CREATED, CREATED_DATE)
		Select 
			dtl.JobForecastJobID,
			@RevisionID,
			@ForecastID,
			dtl.PostPeriodCode,
			Case When @DoBilling = 1 Then dtl.BillingAmount Else Null End,
			Case When @DoRevenue = 1 Then dtl.RevenueAmount Else Null End,
			@UserCode,
			GetDate()
		From
			@ForecastDetailRecords dtl
		Where
			dtl.JobForecastJobDetailID Is Null And
			1 = Case
					When @DoBilling = 1 And dtl.BillingAmount Is Not Null Then 1 
					When @DoRevenue = 1 And dtl.RevenueAmount Is Not Null Then 1
					Else 0 
				End

		/*
			Set Modified Flags on Job
		*/
		Update 
			dbo.JF_JOB
		Set
			USER_MODIFIED = @UserCode,
			MODIFIED_DATE = GetDate()
		Where
			JF_JOB_ID IN (Select Distinct 
							JobForecastJobID
						  From 
							 @ForecastDetailRecords)

		/*
			Set Modified Flags on Revision
		*/
		Update 
			dbo.JF_REV
		Set
			USER_MODIFIED = @UserCode,
			MODIFIED_DATE = GetDate()
		Where
			JF_REV_ID = @RevisionID
		
		/*
			Set Modified Flags on Header
		*/	
		Update 
			dbo.JF_HDR
		Set
			USER_MODIFIED = @UserCode,
			MODIFIED_DATE = GetDate()
		Where
			JF_ID = @ForecastID

	End

End
GO


