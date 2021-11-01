CREATE PROCEDURE [dbo].[advsp_job_forecast_job_summary]
	@RevisionID int
AS
BEGIN
	
	Declare @JobNumber Int
	Declare @JobComponentNumber Smallint

	Declare @Actuals Table (JobNumber Int,
							JobComponentNumber Smallint,
							ActualBillableAmount Decimal(15,2))

	INSERT INTO @Actuals
		SELECT
			A.JobNumber,
			A.ComponentNumber,
			ActualBillableAmount = Sum(Case When A.FunctionType In ('E', 'I', 'V') Then ActualBillableAmount Else 0 End)
		FROM
			dbo.V_JOB_COMP_ACTUALS A
		INNER JOIN
			dbo.JF_JOB J ON A.JobNumber = J.JOB_NUMBER AND
							A.ComponentNumber = J.JOB_COMPONENT_NBR
		WHERE
			J.JF_REV_ID = @RevisionID
		GROUP BY
			A.JobNumber,
			A.ComponentNumber
	
	Select
		[JobForecastID] = fcComps.[JobForecastID],
		[JobForecastRevisionID] = fcComps.[JobForecastRevisionID],
		[JobForecastJobID] = fcComps.[JobForecastJobID],
		[ClientCode] = fcComps.[ClientCode],
		[ClientName] = fcComps.[ClientName],
		[SalesClassCode] = fcComps.[SalesClassCode],
		[SalesClassDescription] = fcComps.[SalesClassDescription],
		[JobNumber] = fcComps.[JobNumber],
		[JobDescription] = fcComps.[JobDescription],
		[JobComponentNumber] = fcComps.[JobComponentNumber],
		[JobComponentDescription] = fcComps.[JobComponentDescription],
		[Comments] = fcComps.[Comments],
		[ApprovedEstimateBillingAmount] = fcComps.[ApprovedEstimateBillingAmount],
		[ApprovedEstimateRevenueAmount] = fcComps.[ApprovedEstimateRevenueAmount],
		[ApprovedEstimateAmount] = fcComps.[ApprovedEstimateAmount],
		[Forecast] = fcComps.[Forecast],
		[Actual] = fcComps.[Actual],
		[Variance] = IsNull(fcComps.[Forecast],0) - IsNull(fcComps.[Actual],0),
		[Color] = fcComps.[Color]
	From
		(Select
			[JobForecastID] = JF_JOB.JF_ID,
			[JobForecastRevisionID] = JF_JOB.JF_REV_ID,
			[JobForecastJobID] = JF_JOB.JF_JOB_ID,
			[ClientCode] = V_JOB_COMPONENT.CL_CODE,
			[ClientName] = V_JOB_COMPONENT.CL_NAME,
			[SalesClassCode] = JOB_LOG.SC_CODE,
			[SalesClassDescription] = SALES_CLASS.SC_DESCRIPTION,
			[JobNumber] = JF_JOB.JOB_NUMBER,
			[JobDescription] = V_JOB_COMPONENT.JOB_DESC,
			[JobComponentNumber] = JF_JOB.JOB_COMPONENT_NBR,
			[JobComponentDescription] = V_JOB_COMPONENT.JOB_COMP_DESC,
			[Comments] = JF_JOB.JF_JOB_COMMENT,
			[ApprovedEstimateBillingAmount] = ApprovedEstimate.BillingTotal,
			[ApprovedEstimateRevenueAmount] = ApprovedEstimate.RevenueTotal,
			[ApprovedEstimateAmount] = ApprovedEstimate.Total,
			[Forecast] = Case When IsNull(JF_HDR.JF_TYPE, 0) In (0,2) Then detailSum.TotalBilling Else detailSum.TotalRevenue End,
			[Actual] = IsNull(actual.ActualBillableAmount, 0),
			[Color] = JF_JOB.COLOR
		From
			dbo.JF_JOB
		Join
			dbo.JF_HDR On JF_JOB.JF_ID = JF_HDR.JF_ID
		Join
			dbo.V_JOB_COMPONENT On JF_JOB.JOB_NUMBER = V_JOB_COMPONENT.JOB_NUMBER And
								   JF_JOB.JOB_COMPONENT_NBR = V_JOB_COMPONENT.JOB_COMPONENT_NBR
		Join
			dbo.JOB_LOG ON JF_JOB.JOB_NUMBER = JOB_LOG.JOB_NUMBER
		Left Outer Join
			dbo.SALES_CLASS ON JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE
		Left Outer Join
			(Select
				JF_JOB_ID,
				TotalBilling = Sum(BILLING_AMT),
				TotalRevenue = Sum(REVENUE_AMT)
			 From
				dbo.JF_JOB_DTL
			 Where
				JF_REV_ID = @RevisionID
			 Group By
				JF_JOB_ID) detailSum On JF_JOB.JF_JOB_ID = detailSum.JF_JOB_ID
		Left Outer Join
			@Actuals actual On JF_JOB.JOB_NUMBER = actual.JobNumber And
							   JF_JOB.JOB_COMPONENT_NBR = actual.JobComponentNumber
		Left Outer Join
			(Select
				[JobNumber] = EstimateInfo.JOB_NUMBER,
				[JobComponentNumber] = EstimateInfo.JOB_COMPONENT_NBR,
				[BillingTotal] = EstimateInfo.BillingTotal,
				[RevenueTotal] = EstimateInfo.RevenueTotal,
				[Total] = EstimateInfo.BillingTotal + EstimateInfo.RevenueTotal
			From
				(Select 
 					ESTIMATE_APPROVAL.JOB_NUMBER,
 					ESTIMATE_APPROVAL.JOB_COMPONENT_NBR,
 					[BillingTotal] = Sum(EST_REV_EXT_AMT) + Sum(EXT_MARKUP_AMT) + Sum(EXT_NONRESALE_TAX),
 					[RevenueTotal] = Sum(Case When EST_FNC_TYPE In ('I', 'E') Then IsNull(EST_REV_EXT_AMT, 0) + IsNull(EXT_MARKUP_AMT, 0) When EST_FNC_TYPE = 'V' Then IsNull(EXT_MARKUP_AMT, 0)Else 0 End)
				 From 
 					dbo.ESTIMATE_APPROVAL 
				 Join
 					dbo.ESTIMATE_REV_DET On ESTIMATE_APPROVAL.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER And
 											ESTIMATE_APPROVAL.EST_COMPONENT_NBR = ESTIMATE_REV_DET.EST_COMPONENT_NBR And
 											ESTIMATE_APPROVAL.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER And
 											ESTIMATE_APPROVAL.EST_QUOTE_NBR = ESTIMATE_REV_DET.EST_QUOTE_NBR And
 											ESTIMATE_APPROVAL.EST_REVISION_NBR = ESTIMATE_REV_DET.EST_REV_NBR
				 Group By
 					JOB_NUMBER,
 					JOB_COMPONENT_NBR,
 					ESTIMATE_APPROVAL.ESTIMATE_NUMBER,
 					ESTIMATE_APPROVAL.EST_COMPONENT_NBR,
 					ESTIMATE_APPROVAL.ESTIMATE_NUMBER,
 					ESTIMATE_APPROVAL.EST_QUOTE_NBR,
 					ESTIMATE_APPROVAL.EST_REVISION_NBR) EstimateInfo ) ApprovedEstimate On JF_JOB.JOB_NUMBER = ApprovedEstimate.JobNumber And
																		JF_JOB.JOB_COMPONENT_NBR = ApprovedEstimate.JobComponentNumber
		Where
			JF_JOB.JF_REV_ID = @RevisionID) fcComps
	
END
GO


