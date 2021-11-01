if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_detail_item_load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_detail_item_load]
GO

CREATE PROCEDURE [dbo].[advsp_job_detail_item_load](
	@DATE_TYPE AS int,
	@START_DATE AS smalldatetime,
	@END_DATE AS smalldatetime,
	@SHOW_JOBS_WO_DETAILS AS bit,
	@INCLUDE_CLOSED AS bit,
	@et_date_cutoff smalldatetime,
	@io_date_cutoff smalldatetime, 
	@ap_pp_cutoff varchar(6), 	
	@ClientCodeList varchar(max),
	@ClientDivisionCodeList varchar(max),
	@ClientDivisionProductCodeList varchar(max),
	@AECodeList varchar(max),
	@CampaignIDList varchar(max),
	@IncludeBilledRange bit,
	@BILLED_START_PERIOD varchar(6),
	@BILLED_END_PERIOD varchar(6),
	@DateOption varchar(10),
	@Current_StartDate smalldatetime,
	@Current_EndDate smalldatetime,
	@CURRENT_PERIOD varchar(6),
	@JobTypeList varchar(max)
)
AS
BEGIN

	DECLARE @CurrentPeriodStartDate smalldatetime, @CurrentPeriodEndDate smalldatetime, @PriorStartDate smalldatetime, @PriorEndDate smalldatetime, @PriorPeriod varchar(6), @Year int

	SELECT @Year = PPGLYEAR - 1
	FROM POSTPERIOD
	WHERE PPPERIOD = @CURRENT_PERIOD

	SELECT @PriorPeriod = CAST(@Year AS VARCHAR(4)) + '12'
	SELECT @PriorEndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @PriorPeriod

	--SELECT @PriorPeriod,@PriorEndDate

	SELECT @CurrentPeriodStartDate = PPSRTDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @CURRENT_PERIOD

	SELECT @CurrentPeriodEndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @CURRENT_PERIOD	

	--SELECT @ClientDivisionProductCodeList
	--SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ',')

	SELECT 
        [ID] = ID,
		ResourceType,
		JobNumber,
		JobComponentNumber,
		OfficeCode,
		OfficeDescription,
		ClientCode,
		ClientDescription,
		DivisionCode,
		DivisionDescription,
		ProductCode,
		ProductDescription,
		CampaignID,
		CampaignCode,
		CampaignName,
		BillingBudget,
		IncomeBudget,
		SalesClassCode,
		SalesClassDescription,
		UserCode,
		JobCreateDate,
		JobDescription,
		JobDateOpened,
		RushChargesApproved,
		ApprovedEstimateRequired,
		Comment,
		ClientReference,
		BillingCoopCode,
		SalesClassFormatCode,
		ComplexityCode,
		PromotionCode,
		BillingComment,
		LabelFromUDFTable1,
		LabelFromUDFTable2,
		LabelFromUDFTable3,
		LabelFromUDFTable4,
		LabelFromUDFTable5,
		JobOpen,
		JobComponent,
		BillHold,
		AccountExecutiveCode,
		AccountExecutive,
		ManagerCode,
		Manager,
		ComponentDateOpened,
		DueDate,
		StartDate,
		[Status],
		GutPercentComplete,
		CompletedDate,
		AdSize,
		DepartmentTeamCode,
		DepartmentTeam,
		MarkupPercent,
		CreativeInstructions,
		JobProcessControl,
		JobProcessControlDate,
		ComponentDescription,
		ComponentComments,
		ComponentBudget,
		EstimateNumber,
		EstimateComponentNumber,
		[ClientApproved],
		[ClientApprovalDate],
		[ClientApprovedBy],
		[InternallyApproved],
		[InternalApprovalDate],
		[InternallyApprovedBy],
		BillingUser,
		AdvanceBillFlag,
		DeliveryInstructions,
		JobTypeCode,
		JobTypeDescription,
		Taxable,
		TaxCode,
		TaxCodeDescription,
		NonBillable,
		AlertGroup,
		AdNumber,
		AccountNumber,
		AccountNumberDescription,
		IncomeRecognitionMethod,
		MarketCode,
		MarketDescription,
		ServiceFeeJob,
		ServiceFeeTypeCode,
		ServiceFeeTypeDescription,
		Archived,
		TrafficScheduleRequired,
		ClientPO,
		CompLabelFromUDFTable1,
		CompLabelFromUDFTable2,
		CompLabelFromUDFTable3,
		CompLabelFromUDFTable4,
		CompLabelFromUDFTable5,
		JobTemplateCode,
		FiscalPeriodCode,
		FiscalPeriodDescription,
		JobQuantity,
		BlackplateVersionCode,
		BlackplateVersionDesc,
		BlackplateVersion2Code,
		BlackplateVersion2Desc,		
		ClientContactCode,
		ClientContactID,
		BABatchID,
		ClientContact,
		SelectedBABatchID,
		BillingCommandCenterID,
		AlertAssignmentTemplate,
		FunctionType,
		FunctionConsolidationCode,
		FunctionConsolidation,
		FunctionHeading,
		FunctionCode,
		FunctionDescription,
		ItemID,
		ItemSequenceNumber,
		ItemDate,
		PostPeriodCode,
		ItemCode,
		ItemDescription,
		ItemComment,
		ItemExtra,
		ItemDetailComment,
		[Hours],
		Quantity,
		NetAmount,
		CostAmount,
		ExtMarkupAmount,
		NonResaleTaxAmount,
		ResaleTaxAmount,
		Total,
		BillableLessResale,
		BillableTotal,
		FeeTime,
		FeeTimeHours,
		FeeTimeAmount,
		NonBillableHours,
		NonBillableQuantity,
		NonBillableAmount,
		BilledHours =  CASE WHEN @IncludeBilledRange = 1 THEN
						   CASE WHEN ResourceType IN ('E','I','V') AND AccountsReceivablePostPeriodCode BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN BilledHours ELSE 0 END
						 ELSE BilledHours END,
		BilledQuantity = CASE WHEN @IncludeBilledRange = 1 THEN
						   CASE WHEN ResourceType IN ('E','I','V') AND AccountsReceivablePostPeriodCode BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN BilledQuantity ELSE 0 END
						 ELSE BilledQuantity END,		
		BilledAmount = CASE WHEN @IncludeBilledRange = 1 THEN
						   CASE WHEN ResourceType IN ('AB','E','I','V') AND AccountsReceivablePostPeriodCode BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN BilledAmount ELSE 0 END
						 ELSE BilledAmount END,
		BilledWithResale = CASE WHEN @IncludeBilledRange = 1 THEN
							   CASE WHEN ResourceType IN ('AB','E','I','V') AND AccountsReceivablePostPeriodCode BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN BilledWithResale ELSE 0 END
							 ELSE BilledWithResale END,
		AccountsReceivablePostPeriodCode,
		AccountsReceivableInvoiceNumber,
		AccountsReceivableInvoiceType,
		UnbilledHours,
		UnbilledQuantity,
		UnbilledAmount,
		UnbilledAmountLessResale,
		AdvanceBillFlagDetail,
		IsNonBillable,
		GlexActBill,
		EstimateHours,
		EstimateHoursAmount,
		EstimateQuantity,
		EstimateTotalAmount,
		EstimateContTotalAmount,
		EstimateNonResaleTaxAmount,
		EstimateResaleTaxAmount,
		EstimateMarkupAmount,
		EstimateCostAmount,
		IsEstimateNonBillable,
		EstimateFeeTime,
		EstimateNetAmount,
		PurchaseOrderNumber,
		OpenPurchaseOrderAmount,
		OpenPurchaseOrderGrossAmount,
		IsNewBusiness,
		Agency,
		BillingApprovalHours,
		BillingApprovalCostAmount,
		BillingApprovalExtNetAmount,
		BillingApprovalTotalAmount,
		ProductUDF1,
		ProductUDF2,
		ProductUDF3,
		ProductUDF4,
		EmployeeDefaultDepartmentCode,
		EmployeeDefaultDepartmentDescription,
		EmployeeTimeDepartmentCode,
		EmployeeTimeDepartmentDescription,
		DateEntered,
		DefaultRoleCode,
		DefaultRole,
		EmployeeOfficeCode,
		EmployeeOfficeDescription,
		EmployeeTitle,
		IsEmployeeFreelance,
		IsActiveFreelance,
		EmployeeRateFrom,
		ProductCategoryCode,
		ProductCategoryDescription,
		DirectHoursGoalPercent,		
		[ClientType1Code],
		[ClientType1Description],
		[ClientType2Code],
		[ClientType2Description],
		[ClientType3Code],
		[ClientType3Description],
		[CurrentHours] = CASE WHEN ResourceType = 'E' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN [Hours] ELSE 0 END,		
		[CurrentHoursAmount] = CASE WHEN ResourceType = 'E' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN Total ELSE 0 END,
		[CurrentIncomeOnlyCharges] = CASE WHEN ResourceType = 'I' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN Total ELSE 0 END,		
		[CurrentVendorCharges] = CASE WHEN ResourceType = 'V' AND PostPeriodCode = @CURRENT_PERIOD THEN Total ELSE 0 END,		
		[CurrentTotal] = (CASE WHEN ResourceType = 'E' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN Total ELSE 0 END) +
						 (CASE WHEN ResourceType = 'I' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN Total ELSE 0 END) +
						 (CASE WHEN ResourceType = 'V' AND PostPeriodCode = @CURRENT_PERIOD THEN Total ELSE 0 END),
		[PriorHours] = CASE WHEN ResourceType = 'E' AND ItemDate < @Current_StartDate THEN [Hours] ELSE 0 END,		
		[PriorHoursAmount] = CASE WHEN ResourceType = 'E' AND ItemDate < @Current_StartDate THEN Total ELSE 0 END,
		[PriorIncomeOnlyCharges] = CASE WHEN ResourceType = 'I' AND ItemDate < @Current_StartDate THEN Total ELSE 0 END,		
		[PriorVendorCharges] = CASE WHEN ResourceType = 'V' AND PostPeriodCode < @CURRENT_PERIOD THEN Total ELSE 0 END,		
		[PriorTotal] = (CASE WHEN ResourceType = 'E' AND ItemDate < @Current_StartDate THEN Total ELSE 0 END) +
					   (CASE WHEN ResourceType = 'I' AND ItemDate < @Current_StartDate THEN Total ELSE 0 END) +
					   (CASE WHEN ResourceType = 'V' AND PostPeriodCode < @CURRENT_PERIOD THEN Total ELSE 0 END),
		[TotalToDateHours] = CASE WHEN ResourceType = 'E' THEN [Hours] ELSE 0 END,
		[TotalToDateHoursAmount] = CASE WHEN ResourceType = 'E' THEN Total ELSE 0 END,
		[TotalToDateIncomeOnlyCharges] = CASE WHEN ResourceType = 'I' THEN Total ELSE 0 END,
		[TotalToDateVendorCharges] = CASE WHEN ResourceType = 'V' THEN Total ELSE 0 END,
		[TotalToDate] = (CASE WHEN ResourceType = 'E' THEN Total ELSE 0 END) +
									 (CASE WHEN ResourceType = 'I' THEN Total ELSE 0 END) +
									 (CASE WHEN ResourceType = 'V' THEN Total ELSE 0 END),
		[PriorYearHours] = CASE WHEN ResourceType = 'E' AND ItemDate < @PriorEndDate THEN [Hours] ELSE 0 END,		
		[PriorYearHoursAmount] = CASE WHEN ResourceType = 'E' AND ItemDate < @PriorEndDate THEN Total ELSE 0 END,
		[PriorYearIncomeOnlyCharges] = CASE WHEN ResourceType = 'I' AND ItemDate < @PriorEndDate THEN Total ELSE 0 END,		
		[PriorYearVendorCharges] = CASE WHEN ResourceType = 'V' AND PostPeriodCode < @PriorPeriod THEN Total ELSE 0 END,		
		[PriorYearTotal] = (CASE WHEN ResourceType = 'E' AND ItemDate < @PriorEndDate THEN Total ELSE 0 END) +
					   (CASE WHEN ResourceType = 'I' AND ItemDate < @PriorEndDate THEN Total ELSE 0 END) +
					   (CASE WHEN ResourceType = 'V' AND PostPeriodCode < @PriorPeriod THEN Total ELSE 0 END),
		[EstimateIncomeOnlyCharges] = CASE WHEN ((ResourceType = 'EI' OR ResourceType = 'ES') AND ResourceType = 'I') THEN EstimateTotalAmount ELSE 0 END,
		[BilledIncomeOnlyCharges] = CASE WHEN ResourceType = 'I' THEN BilledAmount ELSE 0 END
FROM [dbo].[DS_JOB_DETAIL_ITEM]
	WHERE 
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN JobCreateDate >= @START_DATE AND JobCreateDate <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN ComponentDateOpened >= @START_DATE AND ComponentDateOpened <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN DueDate >= @START_DATE AND DueDate <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN StartDate >= @START_DATE AND StartDate <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END 
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN ItemDate >= @START_DATE AND ItemDate <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END 
		AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JobProcessControl = 'Closed' OR JobProcessControl = 'Archive') THEN 0 ELSE 1 END
		AND	(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND ClientCode IN (SELECT items FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND	(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode IN (SELECT items FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND	(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode + '|' + ProductCode IN (SELECT items FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND	(@AECodeList IS NULL OR (@AECodeList IS NOT NULL AND AccountExecutiveCode IN (SELECT items from dbo.udf_split_list(@AECodeList, ','))))
		AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND CampaignID IN (SELECT items FROM dbo.udf_split_list(@CampaignIDList, ','))))
		AND (@JobTypeList IS NULL OR (@JobTypeList IS NOT NULL AND JobTypeCode IN (SELECT items FROM dbo.udf_split_list(@JobTypeList, ','))))
		AND 1 = CASE WHEN ResourceType = 'E' AND ItemDate <= @et_date_cutoff THEN 1 
		             WHEN ResourceType = 'V' AND PostPeriodCode <= @ap_pp_cutoff THEN 1
					 WHEN ResourceType = 'I' AND ItemDate <= @io_date_cutoff THEN 1
					 WHEN ResourceType IN ('AB','C','EI','ES','PO','ND') THEN 1 ELSE 0 END
		AND 1 = CASE WHEN @SHOW_JOBS_WO_DETAILS = 1 AND ResourceType = 'ND' THEN 1
		             WHEN @SHOW_JOBS_WO_DETAILS = 0 AND ResourceType <> 'ND' THEN 1 ELSE 0 END
		

END