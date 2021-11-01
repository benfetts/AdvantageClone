IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_campaign_job_media_summary_load]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_campaign_job_media_summary_load]
GO

CREATE PROCEDURE [dbo].[advsp_campaign_job_media_summary_load](
	@ClientCode AS varchar(6),
	@CampaignIDFrom AS int,	
	@CampaignIDTo AS int,
	@IncludeClosed AS int,
	@user_id varchar(100),
	@UseCampaignMasterJob as bit
	--@DATE_TYPE AS int,
	--@START_DATE AS smalldatetime,
	--@END_DATE AS smalldatetime,
	--@SHOW_JOBS_WO_DETAILS AS bit
)
AS
BEGIN

 /* IS USED IN .Net AT THIS POINT - AdvantageFramework\Reporting\Database\Procedures\DigitalResultsComparisonReport.vb */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

	CREATE TABLE #CMPIDS
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[CampaignID] int,
		Job INT,
		Comp INT,
		JobCompMaster varchar(10)
	);

	If @IncludeClosed = 1
	Begin
		INSERT INTO #CMPIDS
		SELECT CMP_IDENTIFIER, JOB_NUMBER, JOB_COMPONENT_NBR, CAST(JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(JOB_COMPONENT_NBR AS VARCHAR(10)) FROM CAMPAIGN
		WHERE CMP_IDENTIFIER BETWEEN @CampaignIDFrom AND @CampaignIDTo
	End
	Else
	Begin
		INSERT INTO #CMPIDS
		SELECT CMP_IDENTIFIER, JOB_NUMBER, JOB_COMPONENT_NBR, CAST(JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(JOB_COMPONENT_NBR AS VARCHAR(10)) FROM CAMPAIGN 
		WHERE CMP_CLOSED = 0 AND CMP_IDENTIFIER BETWEEN @CampaignIDFrom AND @CampaignIDTo
	End

	--SELECT * FROM #CMPIDS

	DECLARE @NumberRecords int, @RowCount int, @cmpid int, @CMPID_LIST varchar(8000)
	SELECT @NumberRecords = COUNT(*) FROM #CMPIDS
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN
	 SELECT @cmpid = CampaignID
	 FROM #CMPIDS
	 WHERE ID = @RowCount

		SELECT @CMPID_LIST = COALESCE( @CMPID_LIST, '' ) + CAST(@cmpid as Varchar(6))

		IF (@@FETCH_STATUS = 0)  	        	
			SELECT @CMPID_LIST = @CMPID_LIST + ', '

	 SET @RowCount = @RowCount + 1
	END

	--SELECT @CMPID_LIST

	--PRODUCTION
	DECLARE @TRAFFIC_MGR_COL varchar(20), @order_status	varchar(1)		

	SET @order_status = 'O'
	
	CREATE TABLE #CAMP
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[OfficeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientCity] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientState] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionCity] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionState] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		[ProductCity] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductState] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF1] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF2] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF3] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF4] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[AccountExecutiveCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[AccountExecutive] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[CampaignID] int,
		[CampaignCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[CampaignName] varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[BillingBudget] decimal(18, 2), 
		[IncomeBudget] decimal(18, 2),
		[MarketCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[MarketDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[FiscalPeriodCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[FiscalPeriodDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[SalesClassCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[SalesClassDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JobNumber] int,
		[JobComponentNumber] smallint,
		[JobComponent] varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JobDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		[ComponentDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[OrderNumber] int NULL,	
		[OrderDescription]	varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
		[ClientPO] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Hours] decimal(18, 2),
		[NetAmount] decimal(18, 2),
		[Commission] decimal(18, 2),
		[BillingAmountLessResale] decimal(18, 2),
		[BilledAmountLessResale] decimal(18, 2),	
		[BilledAmount] decimal(18, 2),	
		[BilledCost] decimal(18, 2),	
		[BilledIncome] decimal(18, 2),	
		[UnbilledAmountLessResale] decimal(18, 2),
		[UnbilledAmount] decimal(18, 2),
		[ResaleTaxAmount] decimal(18, 2),
		[Total] decimal(18, 2),
		[TotalLessResale] decimal(18, 2),
		[ClientBudgetBillingAmount] decimal(18, 2), 
		[ClientBudgetIncomeAmount] decimal(18, 2),
		[EstimateHours] decimal(18, 2),
		[EstimateQuantity] decimal(18, 2),
		[EstimateTotalAmount] decimal(18, 2),
		[EstimateContTotalAmount] decimal(18, 2),
		[EstimateNonResaleTaxAmount] decimal(18, 2),
		[EstimateResaleTaxAmount] decimal(18, 2),
		[EstimateMarkupAmount] decimal(18, 2),
		[EstimateCostAmount] decimal(18, 2),
		[EstimateNetAmount] decimal(18, 2),
		[Type] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
		[PostPeriodCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Year] smallint,
		[Month] varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JobCreatedDate] smalldatetime,
		[JobStartDate] smalldatetime,
		[JobDueDate] smalldatetime
		

	);	

	CREATE TABLE #CAMP_TOTAL
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[OfficeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientCity] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientState] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionCity] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionState] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		[ProductCity] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductState] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF1] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF2] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF3] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductUDF4] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[AccountExecutiveCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[AccountExecutive] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[CampaignID] int,
		[CampaignCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[CampaignName] varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[BillingBudget] decimal(18, 2), 
		[IncomeBudget] decimal(18, 2),
		[MarketCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[MarketDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[FiscalPeriodCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[FiscalPeriodDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[SalesClassCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[SalesClassDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JobNumber] int,
		[JobComponentNumber] smallint,
		[JobComponent] varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JobDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		[ComponentDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[OrderNumber] int NULL,	
		[OrderDescription]	varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
		[ClientPO] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Hours] decimal(18, 2),
		[NetAmount] decimal(18, 2),
		[Commission] decimal(18, 2),
		[BillingAmountLessResale] decimal(18, 2),
		[BilledAmountLessResale] decimal(18, 2),	
		[BilledAmount] decimal(18, 2),	
		[BilledCost] decimal(18, 2),	
		[BilledIncome] decimal(18, 2),	
		[UnbilledAmountLessResale] decimal(18, 2),
		[UnbilledAmount] decimal(18, 2),
		[ResaleTaxAmount] decimal(18, 2),
		[Total] decimal(18, 2),
		[TotalLessResale] decimal(18, 2),
		[ClientBudgetBillingAmount] decimal(18, 2), 
		[ClientBudgetIncomeAmount] decimal(18, 2),
		[EstimateHours] decimal(18, 2),
		[EstimateQuantity] decimal(18, 2),
		[EstimateTotalAmount] decimal(18, 2),
		[EstimateContTotalAmount] decimal(18, 2),
		[EstimateNonResaleTaxAmount] decimal(18, 2),
		[EstimateResaleTaxAmount] decimal(18, 2),
		[EstimateMarkupAmount] decimal(18, 2),
		[EstimateCostAmount] decimal(18, 2),
		[EstimateNetAmount] decimal(18, 2),
		[CampaignEstimateHours] decimal(18, 2),
		[CampaignEstimateQuantity] decimal(18, 2),
		[CampaignEstimateTotalAmount] decimal(18,2),
		[CampaignEstimateContTotalAmount] decimal(18, 2),
		[CampaignEstimateNonResaleTaxAmount] decimal(18, 2),
		[CampaignEstimateResaleTaxAmount] decimal(18, 2),
		[CampaignEstimateMarkupAmount] decimal(18, 2),
		[CampaignEstimateCostAmount] decimal(18, 2),
		[CampaignEstimateNetAmount] decimal(18, 2),
		[Type] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
		[PostPeriodCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Year] smallint,
		[Month] varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JobCreatedDate] smalldatetime,
		[JobStartDate] smalldatetime,
		[JobDueDate] smalldatetime
		

	);	

	CREATE TABLE #JOB 
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[JobNumber] int,
		[JobComponentNumber] smallint,
		[OfficeCode] varchar(4),
		[OfficeDescription] varchar(30),
		[ClientCode] varchar(6),
		[ClientDescription] varchar(40),
		[DivisionCode] varchar(6),
		[DivisionDescription] varchar(40),
		[ProductCode] varchar(6),
		[ProductDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6),
		[CampaignName] varchar(128),
		[BillingBudget] decimal(9, 2), 
		[IncomeBudget] decimal(9, 2), 
		[SalesClassCode] varchar(6),
		[SalesClassDescription] varchar(30),
		[UserCode] varchar(100),
		[JobCreateDate] smalldatetime,
		[JobDescription] varchar(60),			
		[JobDateOpened] smalldatetime,
		[RushChargesApproved] varchar(3),
		[ApprovedEstimateRequired] varchar(3),
		[Comment] varchar(MAX),
		[ClientReference] varchar(30),
		[BillingCoopCode] varchar(6),
		[SalesClassFormatCode] varchar(6),
		[ComplexityCode] varchar(8),
		[PromotionCode] varchar(8),
		[BillingComment] varchar(254),
		[LabelFromUDFTable1] varchar(40),
		[LabelFromUDFTable2] varchar(40),
		[LabelFromUDFTable3] varchar(40),
		[LabelFromUDFTable4] varchar(40),
		[LabelFromUDFTable5] varchar(40),
		[JobOpen] varchar(3),
		[ComponentNumber] smallint,
		[JobComponent] varchar(20),
		[BillHold] varchar(3),
		[AccountExecutiveCode] varchar(6),
		[AccountExecutive] varchar(100),
		[ManagerCode] varchar(6),
		[Manager] varchar(100),
		[ComponentDateOpened] smalldatetime,
		[DueDate] smalldatetime,
		[StartDate] smalldatetime,
		[Status] varchar(30),
		[GutPercentComplete] decimal(7, 3),
		[AdSize] varchar(60),
		[DepartmentTeamCode] varchar(4),
		[DepartmentTeam] varchar(30),
		[MarkupPercent] decimal(7, 3),
		[CreativeInstructions] varchar(MAX),
		[JobProcessControl] varchar(40),
		[ComponentDescription] varchar(60),
		[ComponentComments] varchar(MAX),
		[ComponentBudget] decimal(11, 2),
		[EstimateNumber] int,
		[EstimateComponentNumber] smallint,
		[BillingUser] varchar(100),
		[AdvanceBillFlag] varchar(100),
		[DeliveryInstructions] varchar(MAX),
		[JobTypeCode] varchar(10),
		[JobTypeDescription] varchar(30),
		[Taxable] varchar(3),
		[TaxCode] varchar(4),
		[TaxCodeDescription] varchar(30),
		[NonBillable] smallint,
		[AlertGroup] varchar(50),
		[AdNumber] varchar(30),
		[AccountNumber] varchar(30),
		[IncomeRecognitionMethod] varchar(30),
		[MarketCode] varchar(10),
		[MarketDescription] varchar(40),
		[ServiceFeeJob] varchar(3),
		[ServiceFeeTypeCode] varchar(6),
		[ServiceFeeTypeDescription] varchar(30),
		[Archived] varchar(3),
		[TrafficScheduleRequired] varchar(3),
		[ClientPO] varchar(40),
		[CompLabelFromUDFTable1] varchar(40),
		[CompLabelFromUDFTable2] varchar(40),
		[CompLabelFromUDFTable3] varchar(40),
		[CompLabelFromUDFTable4] varchar(40),
		[CompLabelFromUDFTable5] varchar(40),
		[JobTemplateCode] varchar(6),
		[FiscalPeriodCode] varchar(6),
		[FiscalPeriodDescription] varchar(30),
		[JobQuantity] int,
		[BlackplateVersionCode] varchar(6),
		[BlackplateVersionDesc] varchar(60),
		[ClientContactCode] int,
		[ClientContactID] varchar(6),
		[BABatchID] int,
		[ClientContact] varchar(100),
		[SelectedBABatchID] int,
		[BillingCommandCenterID] int,
		[AlertAssignmentTemplate] varchar(100),	
		[IsNewBusiness] smallint,
		[Agency] int,
		[ProductUDF1] varchar(50),
		[ProductUDF2] varchar(50),
		[ProductUDF3] varchar(50),
		[ProductUDF4] varchar(50)
	);	
		
	CREATE TABLE #JOB_DETAIL 
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[ResourceType] varchar(3),
		[JobNumber] int,
		[JobComponentNumber] smallint,
		[FunctionType] varchar(1),
		[FunctionConsolidationCode] varchar(6),
		[FunctionConsolidation] varchar(30),
		[FunctionHeading] varchar(60),
		[FunctionCode] varchar(6),
		[FunctionDescription] varchar(30),
		[ItemID] int,
		[ItemSequenceNumber] int,
		[ItemDate] smalldatetime,
		[PostPeriodCode] varchar(8),
		[ItemCode] varchar(6),
		[ItemDescription] varchar(100),
		[ItemComment] varchar(MAX),
		[ItemExtra] varchar(20),
		[FeeTime] int,
		[Hours] decimal(18, 2),
		[Quantity] decimal(18, 2),
		[BillableLessResale] decimal(18, 2),
		[BillableTotal] decimal(18, 2),
		[ExtMarkupAmount] decimal(18, 2),
		[NonResaleTaxAmount] decimal(18, 2),
		[ResaleTaxAmount] decimal(18, 2),
		[Total] decimal(18, 2),
		[CostAmount] decimal(18, 2),
		[NetAmount] decimal(18, 2),
		[AccountsReceivablePostPeriodCode] varchar(6),
		[AccountsReceivableInvoiceNumber] int,
		[AccountsReceivableInvoiceType] varchar(3),
		[AdvanceBillFlagDetail] int,
		[IsNonBillable] int,
		[GlexActBill] int,
		[EstimateHours] decimal(18, 2),
		[EstimateQuantity] decimal(18, 2),
		[EstimateTotalAmount] decimal(18, 2),
		[EstimateContTotalAmount] decimal(18, 2),
		[EstimateNonResaleTaxAmount] decimal(18, 2),
		[EstimateResaleTaxAmount] decimal(18, 2),
		[EstimateMarkupAmount] decimal(18, 2),
		[EstimateCostAmount] decimal(18, 2),
		[IsEstimateNonBillable] int,
		[EstimateFeeTime] int,
		[EstimateNetAmount] decimal(18, 2),
		[PurchaseOrderNumber] int,
		[OpenPurchaseOrderAmount] decimal(18, 2),
		[OpenPurchaseOrderGrossAmount] decimal(18, 2),
		[BilledAmount] decimal(18, 2),
		[BilledWithResale] decimal(18, 2),
		[BilledHours] decimal(18, 2),
		[BilledQuantity] decimal(18, 2),
		[FeeTimeAmount] decimal(18, 2),
		[FeeTimeHours] decimal(18, 2),
		[UnbilledAmount] decimal(18, 2),
		[UnbilledAmountLessResale] decimal(18, 2),
		[UnbilledHours] decimal(18, 2),
		[UnbilledQuantity] decimal(18, 2),
		[NonBillableAmount] decimal(18, 2),
		[NonBillableHours] decimal(18, 2),
		[NonBillableQuantity] decimal(18, 2),
		[BillingApprovalHours] int,
		[BillingApprovalCostAmount] int,
		[BillingApprovalExtNetAmount] int,
		[BillingApprovalTotalAmount] int	
	);

	SELECT 
		@TRAFFIC_MGR_COL = CAST(AGYS.AGY_SETTINGS_VALUE AS varchar(20)) 
	FROM 
		[dbo].[AGY_SETTINGS] AS AGYS
	WHERE 
		AGYS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL'	
			
	INSERT INTO #JOB
	SELECT
		[JobNumber] = JC.JOB_NUMBER,
		[JobComponentNumber] = JC.JOB_COMPONENT_NBR,
		[OfficeCode] = J.OFFICE_CODE,
		[OfficeDescription] = O.OFFICE_NAME,
		[ClientCode] = J.CL_CODE,
		[ClientDescription] = C.CL_NAME,
		[DivisionCode] = J.DIV_CODE,
		[DivisionDescription] = D.DIV_NAME,
		[ProductCode] = J.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[CampaignID] = J.CMP_IDENTIFIER,
		[CampaignCode] = CAMP.CMP_CODE, 
		[CampaignName] = CAMP.CMP_NAME,
		[BillingBudget] = CAMP.CMP_BILL_BUDGET, 
		[IncomeBuget] = CAMP.CMP_INC_BUDGET, 
		[SalesClassCode] = J.SC_CODE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[UserCode] = J.[USER_ID],
		[JobCreateDate] = J.CREATE_DATE,
		[JobDescription] = J.JOB_DESC,
		[JobDateOpened] = J.JOB_DATE_OPENED,
		[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
		[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
		[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
		[ClientReference] = J.JOB_CLI_REF,
		[BillingCoopCode] = J.BILL_COOP_CODE,
		[SalesClassFormatCode] = J.FORMAT_SC_CODE,
		[ComplexityCode] = J.COMPLEX_CODE,
		[PromotionCode] = J.PROMO_CODE,
		[BillingComment] = J.JOB_BILL_COMMENT,
		[LabelFromUDFTable1] = JUDV1.UDV_DESC,
		[LabelFromUDFTable2] = JUDV2.UDV_DESC,
		[LabelFromUDFTable3] = JUDV3.UDV_DESC,
		[LabelFromUDFTable4] = JUDV4.UDV_DESC,
		[LabelFromUDFTable5] = JUDV5.UDV_DESC,
		[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
		[ComponentNumber] = JC.JOB_COMPONENT_NBR,
		[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
		[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
		[AccountExecutiveCode] = JC.EMP_CODE,
		[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
		[ManagerCode] = PJM.MANAGER_CODE,
		[Manager] = PJM.MANAGER,
		[ComponentDateOpened] = JC.JOB_COMP_DATE,
		[DueDate] = JC.JOB_FIRST_USE_DATE,
		[StartDate] = JC.[START_DATE],
		[Status] = T.TRF_DESCRIPTION,
		[GutPercentComplete] = JOBT.PERCENT_COMPLETE,
		[AdSize] = JC.JOB_AD_SIZE,
		[DepartmentTeamCode] = JC.DP_TM_CODE,
		[DepartmentTeam] = DT.DP_TM_DESC,
		[MarkupPercent] = JC.JOB_MARKUP_PCT,
		[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
		[JobProcessControl] = JPC.JOB_PROCESS_DESC,
		[ComponentDescription] = JC.JOB_COMP_DESC,
		[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
		[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
		[EstimateNumber] = JC.ESTIMATE_NUMBER,
		[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
		[BillingUser] = JC.BILLING_USER,
		[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
		[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
		[JobTypeCode] = JC.JT_CODE,
		[JobTypeDescription] = JT.JT_DESC,
		[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
		[TaxCode] = JC.TAX_CODE,
		[TaxCodeDescription] = ST.TAX_DESCRIPTION,
		[NonBillable] = JC.NOBILL_FLAG,
		[AlertGroup] = JC.EMAIL_GR_CODE,
		[AdNumber] = JC.AD_NBR,
		[AccountNumber] = JC.ACCT_NBR,
		[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
		[MarketCode] = JC.MARKET_CODE,
		[MarketDescription] = M.MARKET_DESC,
		[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
		[ServiceFeeTypeCode] = SFT.CODE,
		[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
		[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
		[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
		[ClientPO] = JC.JOB_CL_PO_NBR,
		[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
		[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
		[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
		[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
		[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
		[JobTemplateCode] = JC.JOB_TMPLT_CODE,
		[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
		[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
		[JobQuantity] = JC.JOB_QTY,
		[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
		[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
		[ClientContactCode] = JC.CDP_CONTACT_ID,
		[ClientContactID] = JC.PRD_CONT_CODE,
		[BABatchID] = JC.BA_BATCH_ID,
		[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
		[SelectedBABatchID] = JC.SELECTED_BA_ID,
		[BillingCommandCenterID] = JC.BCC_ID,
		[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
		[IsNewBusiness] = C.NEW_BUSINESS,
		[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
		[ProductUDF1] = P.USER_DEFINED1,
		[ProductUDF2] = P.USER_DEFINED2,
		[ProductUDF3] = P.USER_DEFINED3,
		[ProductUDF4] = P.USER_DEFINED4
	FROM 
		[dbo].[JOB_COMPONENT] AS JC INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
								 D.DIV_CODE = J.DIV_CODE INNER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
								P.DIV_CODE = J.DIV_CODE AND
								P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
		[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
		[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
		[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
		[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
		[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
		[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
		[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
		[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
		[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
		[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
		[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
		[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
		(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
		[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
		[dbo].[JOB_TRAFFIC] AS JOBT ON JOBT.JOB_NUMBER = JC.JOB_NUMBER AND JOBT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
		[dbo].[TRAFFIC] AS T ON T.TRF_CODE = JOBT.TRF_CODE LEFT OUTER JOIN
		(SELECT
				PM.JOB_NUMBER,
				PM.JOB_COMPONENT_NBR,
				PM.[MANAGER_CODE],
				[MANAGER] =  CASE WHEN PM.MANAGER_CODE IS NULL THEN NULL ELSE COALESCE((RTRIM(PEMP.EMP_FNAME) + ' '),'') + COALESCE((PEMP.EMP_MI + '. '),'') + COALESCE(PEMP.EMP_LNAME,'') END
			FROM
				(SELECT
					JT.JOB_NUMBER,
					JT.JOB_COMPONENT_NBR,
					[MANAGER_CODE] = CASE @TRAFFIC_MGR_COL  WHEN 'TR_TITLE1' THEN JT.ASSIGN_1   							
															WHEN 'TR_TITLE2' THEN JT.ASSIGN_2   							
															WHEN 'TR_TITLE3' THEN JT.ASSIGN_3  							
															WHEN 'TR_TITLE4' THEN JT.ASSIGN_4   							
															WHEN 'TR_TITLE5' THEN JT.ASSIGN_5  							
															ELSE NULL  END  					       
				FROM 
					[dbo].[JOB_TRAFFIC] AS JT) AS PM LEFT OUTER JOIN
					[dbo].[EMPLOYEE_CLOAK] AS PEMP ON PEMP.EMP_CODE = PM.[MANAGER_CODE]) AS PJM ON PJM.JOB_NUMBER = JC.JOB_NUMBER AND 
																								   PJM.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
	WHERE (J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ','))) OR (CAST(JC.JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(JC.JOB_COMPONENT_NBR AS VARCHAR(10)) IN (SELECT JobCompMaster FROM #CMPIDS)) 
	--AB
	INSERT INTO #JOB_DETAIL
	SELECT
		[ResourceType] = 'AB',
		[JobNumber] = AB.JOB_NUMBER,
		[JobComponentNumber] = AB.JOB_COMPONENT_NBR,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = AB.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = AB.AB_ID,
		[ItemSequenceNumber] = AB.SEQ_NBR,
		[ItemDate] = AB.BILL_DATE,
		[PostPeriodCode] = CAST(NULL AS varchar(8)),
		[ItemCode] = CAST(NULL AS varchar(6)),
		[ItemDescription] = 'Advance Billing',
		[ItemComment] = CAST(NULL AS varchar(MAX)),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[FeeTime] = 0,
		[Hours] = 0,
		[Quantity] = 0,
		[BillableLessResale] = 0,
		[BillableTotal] = 0,
		[ExtMarkupAmount] = 0,
		[NonResaleTaxAmount] = 0,
		[ResaleTaxAmount] = 0,
		[Total] = 0,
		[CostAmount] = 0,
		[NetAmount] = 0,
		[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
		[AccountsReceivableInvoiceNumber] = AB.AR_INV_NBR,
		[AccountsReceivableInvoiceType] = AB.AR_TYPE,
		[AdvanceBillFlagDetail] = AB.AB_FLAG,
		[IsNonBillable] = 0,
		[GlexActBill] = AB.GLEXACT,
		[EstimateHours] = 0,
		[EstimateQuantity] = 0,
		[EstimateTotalAmount] = 0,
		[EstimateContTotalAmount] = 0,
		[EstimateNonResaleTaxAmount] = 0,
		[EstimateResaleTaxAmount] = 0,
		[EstimateMarkupAmount] = 0,
		[EstimateCostAmount] = 0,
		[IsEstimateNonBillable] = 0,
		[EstimateFeeTime] = 0,
		[EstimateNetAmount] = 0,
		[PurchaseOrderNumber] = 0,
		[OpenPurchaseOrderAmount] = 0,
		[OpenPurchaseOrderGrossAmount] = 0,
		[BilledAmount] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) ELSE 0 END,
		[BilledWithResale] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) ELSE 0 END,
		[BilledHours] = 0,
		[BilledQuantity] = 0,
		[FeeTimeAmount] = 0,
		[FeeTimeHours] = 0,
		[UnbilledAmount] = 0,
		[UnbilledAmountLessResale] = 0,
		[UnbilledHours] = 0,
		[UnbilledQuantity] = 0,
		[NonBillableAmount] = 0,
		[NonBillableHours] = 0,
		[NonBillableQuantity] = 0,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0
	FROM 
		[dbo].[ADVANCE_BILLING] AS AB INNER JOIN  
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = AB.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = AB.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		(SELECT 
			DISTINCT 
			AR.AR_POST_PERIOD,
			AR.AR_INV_NBR, 
			AR.AR_TYPE
		FROM 
			[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = AB.AR_INV_NBR AND 
											 AR.AR_TYPE = AB.AR_TYPE LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
	--C
	INSERT INTO #JOB_DETAIL
	SELECT
		[ResourceType] = 'C',
		[JobNumber] = COOP.JOB_NUMBER,
		[JobComponentNumber] = COOP.JOB_COMPONENT_NBR,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = COOP.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = 0,
		[ItemSequenceNumber] = 0,
		[ItemDate] = COOP.INV_DATE,
		[PostPeriodCode] = CAST(NULL AS varchar(8)),
		[ItemCode] = CAST(NULL AS varchar(6)),
		[ItemDescription] = COOP.[DESCRIPTION],
		[ItemComment] = CAST(NULL AS varchar(MAX)),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[FeeTime] = 0,
		[Hours] = 0,
		[Quantity] = 0,
		[BillableLessResale] = 0,
		[BillableTotal] = 0,
		[ExtMarkupAmount] = 0,
		[NonResaleTaxAmount] = 0,
		[ResaleTaxAmount] = 0,
		[Total] = ISNULL(COOP.AMOUNT, 0),
		[CostAmount] = ISNULL(COOP.AMOUNT, 0),
		[NetAmount] = 0,
		[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
		[AccountsReceivableInvoiceNumber] = 0,
		[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
		[AdvanceBillFlagDetail] = 0,
		[IsNonBillable] = 0,
		[GlexActBill] = 0,
		[EstimateHours] = 0,
		[EstimateQuantity] = 0,
		[EstimateTotalAmount] = 0,
		[EstimateContTotalAmount] = 0,
		[EstimateNonResaleTaxAmount] = 0,
		[EstimateResaleTaxAmount] = 0,
		[EstimateMarkupAmount] = 0,
		[EstimateCostAmount] = 0,
		[IsEstimateNonBillable] = 0,
		[EstimateFeeTime] = 0,
		[EstimateNetAmount] = 0,
		[PurchaseOrderNumber] = 0,
		[OpenPurchaseOrderAmount] = 0,
		[OpenPurchaseOrderGrossAmount] = 0,
		[BilledAmount] = 0,
		[BilledWithResale] = 0,
		[BilledHours] = 0,
		[BilledQuantity] = 0,
		[FeeTimeAmount] = 0,
		[FeeTimeHours] = 0,
		[UnbilledAmount] = 0,
		[UnbilledAmountLessResale] = 0,
		[UnbilledHours] = 0,
		[UnbilledQuantity] = 0,
		[NonBillableAmount] = 0,
		[NonBillableHours] = 0,
		[NonBillableQuantity] = 0,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0
	FROM 
		[dbo].[CLIENT_OOP] AS COOP INNER JOIN  
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = COOP.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = COOP.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = COOP.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
	--E
	INSERT INTO #JOB_DETAIL
	SELECT
		[ResourceType] = 'E',
		[JobNumber] = ETD.JOB_NUMBER,
		[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = ETD.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = ETD.ET_ID,
		[ItemSequenceNumber] = ETD.ET_DTL_ID,
		[ItemDate] = ET.EMP_DATE,
		[PostPeriodCode] = CAST(NULL AS varchar(8)),
		[ItemCode] = ET.EMP_CODE,
		[ItemDescription] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
		[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[FeeTime] = ISNULL(ETD.FEE_TIME, 0),
		[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
		[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
		[BillableLessResale] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END,
		[BillableTotal] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) END,
		[ExtMarkupAmount] = ISNULL(ETD.EXT_MARKUP_AMT, 0),
		[NonResaleTaxAmount] = 0,
		[ResaleTaxAmount] = ISNULL(ETD.EXT_STATE_RESALE, 0) + ISNULL(ETD.EXT_COUNTY_RESALE, 0) + ISNULL(ETD.EXT_CITY_RESALE, 0),
		[Total] = ISNULL(ETD.LINE_TOTAL, 0),
		[CostAmount] = 0,
		[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
		[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
		[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
		[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
		[AdvanceBillFlagDetail] = ETD.AB_FLAG,
		[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
		[GlexActBill] = ETD.GLEXACT_BILL,
		[EstimateHours] = 0,
		[EstimateQuantity] = 0,
		[EstimateTotalAmount] = 0,
		[EstimateContTotalAmount] = 0,
		[EstimateNonResaleTaxAmount] = 0,
		[EstimateResaleTaxAmount] = 0,
		[EstimateMarkupAmount] = 0,
		[EstimateCostAmount] = 0,
		[IsEstimateNonBillable] = 0,
		[EstimateFeeTime] = 0,
		[EstimateNetAmount] = 0,
		[PurchaseOrderNumber] = 0,
		[OpenPurchaseOrderAmount] = 0,
		[OpenPurchaseOrderGrossAmount] = 0,
		[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
		[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
		[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
		[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
		[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
		[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
		[UnbilledAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
		[UnbilledAmountLessResale] = CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
		[UnbilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
		[UnbilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
		[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
		[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
		[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0
	FROM 
		[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN
		[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		(SELECT 
			DISTINCT 
			AR.AR_POST_PERIOD,
			AR.AR_INV_NBR, 
			AR.AR_TYPE
		FROM 
			[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
											 AR.AR_TYPE = ETD.AR_TYPE LEFT JOIN 
		[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND
											 ETDC.ET_DTL_ID = ETD.ET_DTL_ID LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = ET.EMP_CODE
	WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 

	if @UseCampaignMasterJob = 1
	BEGIN
		--EI
		INSERT INTO #JOB_DETAIL
		SELECT
			[ResourceType] = 'EI',
			[JobNumber] = EIA.JOB_NUMBER,
			[JobComponentNumber] = EIA.JOB_COMPONENT_NBR,
			[FunctionType] = F.FNC_TYPE,
			[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionCode] = ERD.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = CAST(NULL AS smalldatetime),
			[PostPeriodCode] = CAST(NULL AS varchar(8)),
			[ItemCode] = CAST(NULL AS varchar(6)),
			[ItemDescription] = 'Estimate Amount',
			[ItemComment] = CAST(NULL AS varchar(MAX)),
			[ItemExtra] = CAST(NULL AS varchar(20)),
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0),
			[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
			[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
			[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
			[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.EST_REV_EXT_AMT, 0) ELSE 0 END,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			[dbo].[ESTIMATE_INT_APPR] AS EIA INNER JOIN 
			(SELECT
				EIA.ESTIMATE_NUMBER,
				EIA.EST_COMPONENT_NBR,
				EIA.EST_QUOTE_NBR,
				EIA.EST_REVISION_NBR
			FROM 
				[dbo].[ESTIMATE_INT_APPR] AS EIA LEFT JOIN 
				[dbo].[ESTIMATE_APPROVAL] AS EA ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER AND
												   EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR AND 
												   EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR AND 
												   EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR
			WHERE 
				EA.EST_APPR_BY IS NULL) AS EA ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER AND 
												 EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR AND 
												 EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR AND 
												 EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR INNER JOIN 
			[dbo].[ESTIMATE_REV_DET] AS ERD ON EIA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND 
											   EIA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR AND 
											   EIA.EST_QUOTE_NBR = ERD.EST_QUOTE_NBR AND 
											   EIA.EST_REVISION_NBR = ERD.EST_REV_NBR INNER JOIN   
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN 
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = EIA.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR INNER JOIN
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
		WHERE CAST(EIA.JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(EIA.JOB_COMPONENT_NBR AS VARCHAR(10)) IN (SELECT JobCompMaster FROM #CMPIDS) 
		--ES
		INSERT INTO #JOB_DETAIL
		SELECT
			[ResourceType] = 'ES',
			[JobNumber] = EA.JOB_NUMBER,
			[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
			[FunctionType] = F.FNC_TYPE,
			[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionCode] = ERD.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = CAST(NULL AS smalldatetime),
			[PostPeriodCode] = CAST(NULL AS varchar(8)),
			[ItemCode] = CAST(NULL AS varchar(6)),
			[ItemDescription] = 'Estimate Amount',
			[ItemComment] = CAST(NULL AS varchar(MAX)),
			[ItemExtra] = CAST(NULL AS varchar(20)),
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0),
			[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
			[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
			[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
			[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.EST_REV_EXT_AMT, 0) ELSE 0 END,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			[dbo].[ESTIMATE_APPROVAL] AS EA INNER JOIN 
			[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
											   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
											   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
											   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN  
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN 
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = EA.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR INNER JOIN
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
		WHERE CAST(EA.JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(EA.JOB_COMPONENT_NBR AS VARCHAR(10)) IN (SELECT JobCompMaster FROM #CMPIDS)
	END
	ELSE
	BEGIN
		--EI
		INSERT INTO #JOB_DETAIL
		SELECT
			[ResourceType] = 'EI',
			[JobNumber] = EIA.JOB_NUMBER,
			[JobComponentNumber] = EIA.JOB_COMPONENT_NBR,
			[FunctionType] = F.FNC_TYPE,
			[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionCode] = ERD.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = CAST(NULL AS smalldatetime),
			[PostPeriodCode] = CAST(NULL AS varchar(8)),
			[ItemCode] = CAST(NULL AS varchar(6)),
			[ItemDescription] = 'Estimate Amount',
			[ItemComment] = CAST(NULL AS varchar(MAX)),
			[ItemExtra] = CAST(NULL AS varchar(20)),
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0),
			[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
			[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
			[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
			[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.EST_REV_EXT_AMT, 0) ELSE 0 END,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			[dbo].[ESTIMATE_INT_APPR] AS EIA INNER JOIN 
			(SELECT
				EIA.ESTIMATE_NUMBER,
				EIA.EST_COMPONENT_NBR,
				EIA.EST_QUOTE_NBR,
				EIA.EST_REVISION_NBR
			FROM 
				[dbo].[ESTIMATE_INT_APPR] AS EIA LEFT JOIN 
				[dbo].[ESTIMATE_APPROVAL] AS EA ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER AND
												   EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR AND 
												   EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR AND 
												   EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR
			WHERE 
				EA.EST_APPR_BY IS NULL) AS EA ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER AND 
												 EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR AND 
												 EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR AND 
												 EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR INNER JOIN 
			[dbo].[ESTIMATE_REV_DET] AS ERD ON EIA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND 
											   EIA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR AND 
											   EIA.EST_QUOTE_NBR = ERD.EST_QUOTE_NBR AND 
											   EIA.EST_REVISION_NBR = ERD.EST_REV_NBR INNER JOIN   
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN 
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = EIA.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR INNER JOIN
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
		WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
		--ES
		INSERT INTO #JOB_DETAIL
		SELECT
			[ResourceType] = 'ES',
			[JobNumber] = EA.JOB_NUMBER,
			[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
			[FunctionType] = F.FNC_TYPE,
			[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionCode] = ERD.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = CAST(NULL AS smalldatetime),
			[PostPeriodCode] = CAST(NULL AS varchar(8)),
			[ItemCode] = CAST(NULL AS varchar(6)),
			[ItemDescription] = 'Estimate Amount',
			[ItemComment] = CAST(NULL AS varchar(MAX)),
			[ItemExtra] = CAST(NULL AS varchar(20)),
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0),
			[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
			[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
			[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
			[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.EST_REV_EXT_AMT, 0) ELSE 0 END,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			[dbo].[ESTIMATE_APPROVAL] AS EA INNER JOIN 
			[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
											   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
											   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
											   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN  
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN 
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = EA.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR INNER JOIN
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
		WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
	END
	
	--EC
	INSERT INTO #JOB_DETAIL
	SELECT DISTINCT
		[ResourceType] = 'EC',
		[JobNumber] = NULL,
		[JobComponentNumber] = NULL,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = ERD.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = EA.CMP_IDENTIFIER,
		[ItemSequenceNumber] = 0,
		[ItemDate] = CAST(NULL AS smalldatetime),
		[PostPeriodCode] = CAST(NULL AS varchar(8)),
		[ItemCode] = CAST(NULL AS varchar(6)),
		[ItemDescription] = 'Estimate Amount',
		[ItemComment] = CAST(NULL AS varchar(MAX)),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[FeeTime] = 0,
		[Hours] = 0,
		[Quantity] = 0,
		[BillableLessResale] = 0,
		[BillableTotal] = 0,
		[ExtMarkupAmount] = 0,
		[NonResaleTaxAmount] = 0,
		[ResaleTaxAmount] = 0,
		[Total] = 0,
		[CostAmount] = 0,
		[NetAmount] = 0,
		[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
		[AccountsReceivableInvoiceNumber] = 0,
		[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
		[AdvanceBillFlagDetail] = 0,
		[IsNonBillable] = 0,
		[GlexActBill] = 0,
		[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
		[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
		[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0),
		[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
		[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
		[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
		[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
		[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.EST_REV_EXT_AMT, 0) ELSE 0 END,
		[IsEstimateNonBillable] = 0,
		[EstimateFeeTime] = 0,
		[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
		[PurchaseOrderNumber] = 0,
		[OpenPurchaseOrderAmount] = 0,
		[OpenPurchaseOrderGrossAmount] = 0,
		[BilledAmount] = 0,
		[BilledWithResale] = 0,
		[BilledHours] = 0,
		[BilledQuantity] = 0,
		[FeeTimeAmount] = 0,
		[FeeTimeHours] = 0,
		[UnbilledAmount] = 0,
		[UnbilledAmountLessResale] = 0,
		[UnbilledHours] = 0,
		[UnbilledQuantity] = 0,
		[NonBillableAmount] = 0,
		[NonBillableHours] = 0,
		[NonBillableQuantity] = 0,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0
	FROM 
		[dbo].[EST_CAMP_APPROVAL] AS EA INNER JOIN 
		[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
										   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
										   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
										   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN  
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE EA.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
	--I
	INSERT INTO #JOB_DETAIL
	SELECT
		[ResourceType] = 'I',
		[JobNumber] = [IO].JOB_NUMBER,
		[JobComponentNumber] = [IO].JOB_COMPONENT_NBR,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = [IO].FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = [IO].IO_ID,
		[ItemSequenceNumber] = [IO].SEQ_NBR,
		[ItemDate] = [IO].IO_INV_DATE,
		[PostPeriodCode] = CAST(NULL AS varchar(8)),
		[ItemCode] = CAST(NULL AS varchar(6)),
		[ItemDescription] = [IO].IO_DESC,
		[ItemComment] = CAST([IO].IO_COMMENT AS varchar(MAX)),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[FeeTime] = 0,
		[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[BillableLessResale] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END,
		[BillableTotal] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL([IO].LINE_TOTAL, 0) END,
		[ExtMarkupAmount] = ISNULL([IO].EXT_MARKUP_AMT, 0),
		[NonResaleTaxAmount] = 0,
		[ResaleTaxAmount] = ISNULL([IO].EXT_STATE_RESALE, 0) + ISNULL([IO].EXT_COUNTY_RESALE, 0) + ISNULL([IO].EXT_CITY_RESALE, 0),
		[Total] = ISNULL([IO].LINE_TOTAL, 0),
		[CostAmount] = 0,			
		[NetAmount] = (ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)) - ISNULL([IO].EXT_MARKUP_AMT, 0),
		[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
		[AccountsReceivableInvoiceNumber] = [IO].AR_INV_NBR,
		[AccountsReceivableInvoiceType] = [IO].AR_TYPE,
		[AdvanceBillFlagDetail] = [IO].AB_FLAG,
		[IsNonBillable] = ISNULL([IO].NON_BILL_FLAG, 0),
		[GlexActBill] = [IO].GLEXACT_BILL,
		[EstimateHours] = 0,
		[EstimateQuantity] = 0,
		[EstimateTotalAmount] = 0,
		[EstimateContTotalAmount] = 0,
		[EstimateNonResaleTaxAmount] = 0,
		[EstimateResaleTaxAmount] = 0,
		[EstimateMarkupAmount] = 0,
		[EstimateCostAmount] = 0,
		[IsEstimateNonBillable] = 0,
		[EstimateFeeTime] = 0,
		[EstimateNetAmount] = 0,
		[PurchaseOrderNumber] = 0,
		[OpenPurchaseOrderAmount] = 0,
		[OpenPurchaseOrderGrossAmount] = 0,
		[BilledAmount] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
		[BilledWithResale] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
		[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[FeeTimeAmount] = 0,
		[FeeTimeHours] = 0,
		[UnbilledAmount] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
		[UnbilledAmountLessResale] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
		[UnbilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[UnbilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[NonBillableAmount] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
		[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0
	FROM 
		[dbo].[INCOME_ONLY] AS [IO] INNER JOIN  
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		(SELECT 
			DISTINCT 
			AR.AR_POST_PERIOD,
			AR.AR_INV_NBR, 
			AR.AR_TYPE
		FROM 
			[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = [IO].AR_INV_NBR AND 
											 AR.AR_TYPE = [IO].AR_TYPE LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
	--PO
	INSERT INTO #JOB_DETAIL
	SELECT
		[ResourceType] = 'PO',
		[JobNumber] = POD.JOB_NUMBER,
		[JobComponentNumber] = POD.JOB_COMPONENT_NBR,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = POD.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = 0,
		[ItemSequenceNumber] = 0,
		[ItemDate] = PO.PO_DATE,
		[PostPeriodCode] = CAST(NULL AS varchar(8)),
		[ItemCode] = PO.VN_CODE,
		[ItemDescription] = PO.VN_CODE,
		[ItemComment] = CAST(NULL AS varchar(MAX)),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[FeeTime] = 0,
		[Hours] = 0,
		[Quantity] = 0,
		[BillableLessResale] = 0,
		[BillableTotal] = 0,
		[ExtMarkupAmount] = 0,
		[NonResaleTaxAmount] = 0,
		[ResaleTaxAmount] = 0,
		[Total] = 0,
		[CostAmount] = 0,
		[NetAmount] = 0,
		[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
		[AccountsReceivableInvoiceNumber] = 0,
		[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
		[AdvanceBillFlagDetail] = 0,
		[IsNonBillable] = 0,
		[GlexActBill] = 0,
		[EstimateHours] = 0,
		[EstimateQuantity] = 0,
		[EstimateTotalAmount] = 0,
		[EstimateContTotalAmount] = 0,
		[EstimateNonResaleTaxAmount] = 0,
		[EstimateResaleTaxAmount] = 0,
		[EstimateMarkupAmount] = 0,
		[EstimateCostAmount] = 0,
		[IsEstimateNonBillable] = 0,
		[EstimateFeeTime] = 0,
		[EstimateNetAmount] = 0,
		[PurchaseOrderNumber] = PO.PO_NUMBER,
		[OpenPurchaseOrderAmount] = ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0),
		[OpenPurchaseOrderGrossAmount] = ISNULL(POD.PO_EXT_AMOUNT, 0) + ISNULL(POD.EXT_MARKUP_AMT, 0) - ISNULL(AP.AP_GROSS_AMT, 0),
		[BilledAmount] = 0,
		[BilledWithResale] = 0,
		[BilledHours] = 0,
		[BilledQuantity] = 0,
		[FeeTimeAmount] = 0,
		[FeeTimeHours] = 0,
		[UnbilledAmount] = 0,
		[UnbilledAmountLessResale] = 0,
		[UnbilledHours] = 0,
		[UnbilledQuantity] = 0,
		[NonBillableAmount] = 0,
		[NonBillableHours] = 0,
		[NonBillableQuantity] = 0,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0
	FROM 
		[dbo].[PURCHASE_ORDER] AS PO INNER JOIN 
		[dbo].[PURCHASE_ORDER_DET] AS POD ON POD.PO_NUMBER = PO.PO_NUMBER LEFT OUTER JOIN 
		(SELECT
			AP.PO_NUMBER,
			AP.PO_LINE_NUMBER,
			PO_COMPLETE = MAX(ISNULL(AP.PO_COMPLETE, 0)),
			AP_NET_AMT = SUM(AP.AP_PROD_EXT_AMT),
			AP_GROSS_AMT = SUM(AP.AP_PROD_EXT_AMT) + SUM(AP.EXT_MARKUP_AMT)
		FROM 
			[dbo].[AP_PRODUCTION] AS AP
		WHERE 
			ISNULL(AP.PO_NUMBER, 0) <> 0 AND 
			ISNULL(AP.DELETE_FLAG, 0) = 0 
		GROUP BY 
			AP.PO_NUMBER, 
			AP.PO_LINE_NUMBER 
		HAVING 
			SUM(AP.AP_PROD_EXT_AMT) <> 0) AS AP ON AP.PO_NUMBER = POD.PO_NUMBER AND 
												   AP.PO_LINE_NUMBER = POD.LINE_NUMBER INNER JOIN   
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = POD.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = POD.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = POD.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
	--V
	INSERT INTO #JOB_DETAIL
	SELECT
		[ResourceType] = 'V',
		[JobNumber] = APP.JOB_NUMBER,
		[JobComponentNumber] = APP.JOB_COMPONENT_NBR,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = APP.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = APP.AP_ID,
		[ItemSequenceNumber] = APP.AP_SEQ,
		[ItemDate] = APH.AP_INV_DATE,
		[PostPeriodCode] = APP.POST_PERIOD,
		[ItemCode] = APH.VN_FRL_EMP_CODE,
		[ItemDescription] = V.VN_NAME + ' (' + APH.VN_FRL_EMP_CODE + ')',
		[ItemComment] = CAST(APH.AP_DESC AS varchar(MAX)),
		[ItemExtra] = APH.AP_INV_VCHR,
		[FeeTime] = 0,
		[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[BillableLessResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) END,
		[BillableTotal] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(APP.LINE_TOTAL, 0) END,
		[ExtMarkupAmount] = ISNULL(APP.EXT_MARKUP_AMT, 0),
		[NonResaleTaxAmount] = ISNULL(APP.EXT_NONRESALE_TAX, 0),
		[ResaleTaxAmount] = ISNULL(APP.EXT_STATE_RESALE, 0) + ISNULL(APP.EXT_COUNTY_RESALE, 0) + ISNULL(APP.EXT_CITY_RESALE, 0),
		[Total] = ISNULL(APP.LINE_TOTAL, 0),
		[CostAmount] = APP.AP_PROD_EXT_AMT,
		[NetAmount] = (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - ISNULL(APP.EXT_MARKUP_AMT, 0),
		[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
		[AccountsReceivableInvoiceNumber] = APP.AR_INV_NBR,
		[AccountsReceivableInvoiceType] = APP.AR_TYPE,
		[AdvanceBillFlagDetail] = APP.AB_FLAG,
		[IsNonBillable] = ISNULL(APP.AP_PROD_NOBILL_FLG, 0),
		[GlexActBill] = APP.GLEXACT_BILL,
		[EstimateHours] = 0,
		[EstimateQuantity] = 0,
		[EstimateTotalAmount] = 0,
		[EstimateContTotalAmount] = 0,
		[EstimateNonResaleTaxAmount] = 0,
		[EstimateResaleTaxAmount] = 0,
		[EstimateMarkupAmount] = 0,
		[EstimateCostAmount] = 0,
		[IsEstimateNonBillable] = 0,
		[EstimateFeeTime] = 0,
		[EstimateNetAmount] = 0,
		[PurchaseOrderNumber] = 0,
		[OpenPurchaseOrderAmount] = 0,
		[OpenPurchaseOrderGrossAmount] = 0,
		[BilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
		[BilledWithResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
		[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[FeeTimeAmount] = 0,
		[FeeTimeHours] = 0,
		[UnbilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
		[UnbilledAmountLessResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
		[UnbilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[UnbilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[NonBillableAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
		[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0
	FROM 
		[dbo].[AP_PRODUCTION] AS APP INNER JOIN 
		[dbo].[AP_HEADER] AS APH ON APH.AP_ID = APP.AP_ID AND 
							   APH.AP_SEQ = APP.AP_SEQ INNER JOIN    
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = APP.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = APP.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = APP.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		(SELECT 
			DISTINCT 
			AR.AR_POST_PERIOD,
			AR.AR_INV_NBR, 
			AR.AR_TYPE
		FROM 
			[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = APP.AR_INV_NBR AND 
											 AR.AR_TYPE = APP.AR_TYPE INNER JOIN 
		[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE LEFT JOIN 
		[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = APP.AP_ID AND 
										   APC.LINE_NUMBER = APP.LINE_NUMBER LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 
			
	--IF @SHOW_JOBS_WO_DETAILS = 1 BEGIN
	--	--ND
	--	INSERT INTO #JOB_DETAIL
	--	SELECT
	--		[ResourceType] = 'ND',
	--		[JobNumber] = JC.JOB_NUMBER,
	--		[JobComponentNumber] = JC.JOB_COMPONENT_NBR,
	--		[FunctionType] = CAST(NULL AS varchar(1)),
	--		[FunctionConsolidationCode] = CAST(NULL AS varchar(6)),
	--		[FunctionConsolidation] = CAST(NULL AS varchar(30)),
	--		[FunctionHeading] = CAST(NULL AS varchar(60)),
	--		[FunctionCode] = CAST(NULL AS varchar(6)),
	--		[FunctionDescription] = CAST(NULL AS varchar(30)),
	--		[ItemID] = 0,
	--		[ItemSequenceNumber] = 0,
	--		[ItemDate] = CAST(NULL AS smalldatetime),
	--		[PostPeriodCode] = CAST(NULL AS varchar(8)),
	--		[ItemCode] = CAST(NULL AS varchar(6)),
	--		[ItemDescription] = 'No Details',
	--		[ItemComment] = CAST(NULL AS varchar(MAX)),
	--		[ItemExtra] = CAST(NULL AS varchar(20)),
	--		[FeeTime] = 0,
	--		[Hours] = 0,
	--		[Quantity] = 0,
	--		[BillableLessResale] = 0,
	--		[BillableTotal] = 0,
	--		[ExtMarkupAmount] = 0,
	--		[NonResaleTaxAmount] = 0,
	--		[ResaleTaxAmount] = 0,
	--		[Total] = 0,
	--		[CostAmount] = 0,
	--		[NetAmount] = 0,
	--		[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
	--		[AccountsReceivableInvoiceNumber] = CAST(NULL AS int),
	--		[AccountsReceivableInvoiceType] = NULL,
	--		[AdvanceBillFlagDetail] = CAST(0 AS smallint),
	--		[IsNonBillable] = 0,
	--		[GlexActBill] = CAST(0 AS int),
	--		[EstimateHours] = 0,
	--		[EstimateQuantity] = 0,
	--		[EstimateTotalAmount] = 0,
	--		[EstimateContTotalAmount] = 0,
	--		[EstimateNonResaleTaxAmount] = 0,
	--		[EstimateResaleTaxAmount] = 0,
	--		[EstimateMarkupAmount] = 0,
	--		[EstimateCostAmount] = 0,
	--		[IsEstimateNonBillable] = 0,
	--		[EstimateFeeTime] = 0,
	--		[EstimateNetAmount] = 0,
	--		[PurchaseOrderNumber] = 0,
	--		[OpenPurchaseOrderAmount] = 0,
	--		[OpenPurchaseOrderGrossAmount] = 0,
	--		[BilledAmount] = 0,
	--		[BilledWithResale] = 0,
	--		[BilledHours] = 0,
	--		[BilledQuantity] = 0,
	--		[FeeTimeAmount] = 0,
	--		[FeeTimeHours] = 0,
	--		[UnbilledAmount] = 0,
	--		[UnbilledAmountLessResale] = 0,
	--		[UnbilledHours] = 0,
	--		[UnbilledQuantity] = 0,
	--		[NonBillableAmount] = 0,
	--		[NonBillableHours] = 0,
	--		[NonBillableQuantity] = 0,
	--		[BillingApprovalHours] = 0, 
	--		[BillingApprovalCostAmount] = 0,  
	--		[BillingApprovalExtNetAmount] = 0,  
	--		[BillingApprovalTotalAmount] = 0
	--	FROM  
	--		[dbo].[JOB_COMPONENT] AS JC INNER JOIN
	--		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
	--		(SELECT 
	--			[JobNumber] = JOBTOTALS.[JobNumber],
	--			[ComponentNumber] = JOBTOTALS.[JobComponentNumber]
	--		FROM
	--			(SELECT
	--				[JobNumber] = AB.JOB_NUMBER,
	--				[JobComponentNumber] = AB.JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[ADVANCE_BILLING] AS AB
						
	--			UNION ALL

	--			SELECT
	--				[JobNumber] = COOP.JOB_NUMBER,
	--				[JobComponentNumber] = COOP.JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[CLIENT_OOP] AS COOP
							
	--			UNION ALL

	--			SELECT
	--				[JobNumber] = ETD.JOB_NUMBER,
	--				[JobComponentNumber] = ETD.JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[EMP_TIME_DTL] AS ETD
								
	--			UNION ALL

	--			SELECT
	--				[JobNumber] = EIA.JOB_NUMBER,
	--				[JobComponentNumber] = EIA.JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[ESTIMATE_INT_APPR] AS EIA
					
	--			UNION ALL

	--			SELECT
	--				[JobNumber] = EA.JOB_NUMBER,
	--				[JobComponentNumber] = EA.JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[ESTIMATE_APPROVAL] AS EA
					
	--			UNION ALL

	--			SELECT
	--				[JobNumber] = [IO].JOB_NUMBER,
	--				[JobComponentNumber] = [IO].JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[INCOME_ONLY] AS [IO]
						
	--			UNION ALL

	--			SELECT
	--				[JobNumber] = POD.JOB_NUMBER,
	--				[JobComponentNumber] = POD.JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[PURCHASE_ORDER] AS PO INNER JOIN 
	--				[dbo].[PURCHASE_ORDER_DET] AS POD ON POD.PO_NUMBER = PO.PO_NUMBER
							
	--			UNION ALL

	--			SELECT
	--				[JobNumber] = APP.JOB_NUMBER,
	--				[JobComponentNumber] = APP.JOB_COMPONENT_NBR
	--			FROM 
	--				[dbo].[AP_PRODUCTION] AS APP) AS JOBTOTALS
	--		GROUP BY
	--			JOBTOTALS.[JobNumber],
	--			JOBTOTALS.[JobComponentNumber]) AS JOBDTLS ON JOBDTLS.JobNumber = JC.JOB_NUMBER AND
	--														  JOBDTLS.ComponentNumber = JC.JOB_COMPONENT_NBR
	--	WHERE
	--		JOBDTLS.JobNumber IS NULL AND
	--		JOBDTLS.ComponentNumber IS NULL AND J.CMP_IDENTIFIER = @CampaignID
				
	--END


	--SELECT * FROM #JOB_DETAIL --WHERE CostAmount <> 0

		
		INSERT INTO #CAMP
		SELECT 		
			J.OfficeCode,
			J.OfficeDescription,
			J.ClientCode,
			J.ClientDescription,
			NULL,
			NULL,
			J.DivisionCode,
			J.DivisionDescription,
			NULL,
			NULL,
			J.ProductCode,
			J.ProductDescription,
			NULL,
			NULL,
			J.ProductUDF1,
			J.ProductUDF2,
			J.ProductUDF3,
			J.ProductUDF4,
			J.AccountExecutiveCode,
			J.AccountExecutive,
			J.CampaignID,
			J.CampaignCode,
			J.CampaignName,
			J.BillingBudget,
			J.IncomeBudget,
			J.MarketCode,
			J.MarketDescription,
			J.FiscalPeriodCode,
			J.FiscalPeriodDescription,
			J.SalesClassCode,
			J.SalesClassDescription,
			J.JobNumber,
			J.JobComponentNumber,
			J.JobComponent,
			J.JobDescription,
			J.ComponentDescription,
			NULL,
			NULL,
			J.ClientPO,
			JD.[Hours],
			JD.NetAmount,
			JD.ExtMarkupAmount,
			NULL,
			JD.BilledAmount,
			JD.BilledWithResale,
			CASE WHEN ResourceType = 'V' AND JD.BilledAmount <> 0 THEN JD.BilledAmount - JD.ExtMarkupAmount END,
			CASE WHEN ResourceType = 'E' OR ResourceType = 'I' THEN JD.BilledAmount
				 WHEN ResourceTYpe = 'V' AND JD.BilledAmount <> 0 THEN JD.ExtMarkupAmount END,
			JD.UnbilledAmountLessResale,
			JD.UnbilledAmount,
			JD.ResaleTaxAmount,
			NULL,
			NULL,
			NULL,
			NULL,
			JD.EstimateHours,
			JD.EstimateQuantity,
			JD.EstimateTotalAmount,
			JD.EstimateContTotalAmount,
			JD.EstimateNonResaleTaxAmount,
			JD.EstimateResaleTaxAmount,
			JD.EstimateMarkupAmount,
			JD.EstimateCostAmount,
			JD.EstimateNetAmount,
			'P',
			JD.PostPeriodCode,
			NULL,
			NULL,
			J.JobCreateDate,
			J.StartDate,
			J.DueDate
		FROM 
			#JOB AS J INNER JOIN 
			#JOB_DETAIL AS JD ON J.[JobNumber] = JD.[JobNumber] AND
								 J.[JobComponentNumber] = JD.[JobComponentNumber]
	
	

--SELECT * FROM #CAMP --WHERE CampaignID = 1

-- ==========================================================
-- MAIN DATA TABLE #media_current_status_sum
-- ==========================================================
CREATE TABLE #media_current_status_sum(     
	  [User Code]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Type]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Number]					int NULL,
	  [Revision Number]					smallint NULL, 
	  [Office Code]						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Office Name]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Client Code]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Client Name]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Division Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Division Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Product Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Product Description]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [Order Description]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Comment]					text, 
	  [Vendor Code]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Vendor Name]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Vendor Rep Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Vendor Rep Name]					varchar(65) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Vendor Rep Code2]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Vendor Rep Name2]				varchar(65) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Campaign Code]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Campaign ID]						smallint NULL, 
	  [Campaign Name]					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Media Type]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Media Type Description]			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Post Bill Flag]					tinyint NULL, 
	  [Net Gross Flag]					tinyint NULL, 
	  [Market Code]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Market Description]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order Date]						smalldatetime NULL, 
	  [Order Flight From]				smalldatetime NULL, 
	  [Order Flight To]					smalldatetime NULL, 
	  [Order Process Control]			tinyint NULL,
	  [Buyer]							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Client PO]						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Link ID]							int NULL, 
	  [Order Accepted]					tinyint NULL, 
	  [Line Number]						smallint NULL, 
	  [Line Revision Number]			smallint NULL,
	  [Line Sequence Number]			tinyint NULL, 
	  [Order Date Type]					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Order Period]					int NULL, 
	  [Order Month]						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Order year]						smallint NULL, 
	  [Insertion Date]					smalldatetime NULL, 
	  [Order End Date]					smalldatetime NULL, 
	  [Date To Bill]					smalldatetime NULL, 
	  [Close Date]						smalldatetime NULL, 
	  [Material Close Date]				smalldatetime NULL, 
	  [Line Description]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Ad Size]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Edition Issue]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Section]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Material]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Remarks]							text, 
	  [URL]								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Copy Area]						text, 
	  [Material Notes]					text, 
	  [Position Info]					text, 
	  [Miscellaneous Info]				text, 
	  [Job Number]						int NULL, 
	  [Job Description]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Job Component Number]			smallint NULL, 
	  [Job Component Description]		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  [Cost Type]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Rate Type]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Print Quantity]					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  [Guaranteed Impressions]			int NULL,
	  [Line Link ID]					int NULL, 
	  [Order Entry Type]				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  --[Record Type]						varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	  [Extended Net Amount]				decimal(15,2) NULL, 
	  [Net Charge Amount]				decimal(15,2) NULL, 
	  [Discount Amount]					decimal(15,2) NULL, 
	  [Additional Charge Amount]		decimal(15,2) NULL, 
	  [Commission Amount]				decimal(15,2) NULL, 
	  [Rebate Amount]					decimal(15,2) NULL, 
	  [Vendor Tax Amount]				decimal(15,2) NULL, 
	  [Resale Tax Amount]				decimal(15,2) NULL, 
	  [Line Total Amount]				decimal(15,2) NULL, 
	  [Net Total Amount]				decimal(15,2) NULL, 
	  [Vendor Net Amount]				decimal(15,2) NULL,
	  [Bill Amount]						decimal(15,2) NULL, 
	  [Reconcile No_Bill Bill Amount]	decimal(15,2) NULL, 
	  [Reconcile No_BILL Net Amount]	decimal(15,2) NULL, 
	  [Spots Quantity]					int NULL,				
	  --[Non_billable Flag]				tinyint NULL, 
	  --[Line Cancelled]					tinyint NULL, 
	  --[Bill Type Flag]					tinyint NULL,
	  [Billed Extended Net Amount]		decimal(15,2) NULL, 
	  [Billed Discount Amount]			decimal(15,2) NULL, 
	  [Billed Net Charge Amount]		decimal(15,2) NULL, 
	  [Billed Vendor Tax Amount]		decimal(15,2) NULL, 
	  [Billed Net Amount]				decimal(15,2) NULL, 
	  [Billed Additional Charge Amount]	decimal(15,2) NULL, 
	  [Billed Commission Amount]		decimal(15,2) NULL, 
	  [Billed Rebate Amount]			decimal(15,2) NULL, 
	  [Billed Resale Tax Amount]		decimal(15,2) NULL, 
	  [Billed Bill Amount]				decimal(15,2) NULL,
	  [Billed Spots Quantity]			int NULL,	
	  [Billed Cost Amount]				decimal(15,2) NULL,
	  --[Invoice Number]					int NULL, 
	  --[Invoice Sequence Number]			smallint NULL, 
	  --[Invoice Type]					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	  --[GL Billing Trans Number]			int NULL,			
	  [AP Net Amount]					decimal(15,2) NULL, 
	  [AP Net Charge Amount]			decimal(15,2) NULL, 
	  [AP Discount Amount]				decimal(15,2) NULL, 
	  [AP Commission Amount]			decimal(15,2) NULL, 
	  [AP Rebate Amount]				decimal(15,2) NULL, 
	  [AP Vendor Tax Amount]			decimal(15,2) NULL, 
	  [AP Resale Tax Amount]			decimal(15,2) NULL, 
	  [AP Bill Amount]					decimal(15,2) NULL, 
	  [AP Line Total]					decimal(15,2) NULL,
	  [AP Spots Quantity]				int NULL,
	  [FiscalPeriodCode]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)			
	

-- ==========================================================
-- SECONDARY TABLES
-- ==========================================================
-- Temp table #media_orders - stores a table of orders to be processed
-- Creates a list using all orders in the db filtered by @order_status
-- Cannot filter the sprocs that populate section (A) temptables by date
-- Filtering by @start_date and @start_period is done in the final select statements
--CREATE TABLE #media_orders(
--	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
--	ORDER_NBR				int NULL,
--	ORDER_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS)
	
DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE [USER_ID] = @user_id
	
--IF @include_internet = 1 BEGIN

	INSERT INTO dbo.MEDIA_RPT_ORDERS
	SELECT @user_id, h.ORDER_NBR, UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1))
	FROM dbo.V_MEDIA_HDR AS h
	WHERE (UPPER(@order_status) = 'A'
		OR (UPPER(@order_status) = 'O' AND h.ORD_PROCESS_CONTRL	NOT IN (6,12))) AND
		UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1)) = 'I'
		
--END

--IF @include_magazine = 1 BEGIN

	INSERT INTO dbo.MEDIA_RPT_ORDERS
	SELECT @user_id, h.ORDER_NBR, UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1))
	FROM dbo.V_MEDIA_HDR AS h
	WHERE (UPPER(@order_status) = 'A'
		OR (UPPER(@order_status) = 'O' AND h.ORD_PROCESS_CONTRL	NOT IN (6,12))) AND
		UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1)) = 'M'
		
--END

--IF @include_newspaper = 1 BEGIN

	INSERT INTO dbo.MEDIA_RPT_ORDERS
	SELECT @user_id, h.ORDER_NBR, UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1))
	FROM dbo.V_MEDIA_HDR AS h
	WHERE (UPPER(@order_status) = 'A'
		OR (UPPER(@order_status) = 'O' AND h.ORD_PROCESS_CONTRL	NOT IN (6,12))) AND
		UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1)) = 'N'
		
--END

--IF @include_outofhome = 1 BEGIN

	INSERT INTO dbo.MEDIA_RPT_ORDERS
	SELECT @user_id, h.ORDER_NBR, UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1))
	FROM dbo.V_MEDIA_HDR AS h
	WHERE (UPPER(@order_status) = 'A'
		OR (UPPER(@order_status) = 'O' AND h.ORD_PROCESS_CONTRL	NOT IN (6,12))) AND
		UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1)) = 'O'
		
--END

--IF @include_radio = 1 BEGIN

	INSERT INTO dbo.MEDIA_RPT_ORDERS
	SELECT @user_id, h.ORDER_NBR, UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1))
	FROM dbo.V_MEDIA_HDR AS h
	WHERE (UPPER(@order_status) = 'A'
		OR (UPPER(@order_status) = 'O' AND h.ORD_PROCESS_CONTRL	NOT IN (6,12))) AND
		UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1)) = 'R'
		
--END

--IF @include_television = 1 BEGIN

	INSERT INTO dbo.MEDIA_RPT_ORDERS
	SELECT @user_id, h.ORDER_NBR, UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1))
	FROM dbo.V_MEDIA_HDR AS h
	WHERE (UPPER(@order_status) = 'A'
		OR (UPPER(@order_status) = 'O' AND h.ORD_PROCESS_CONTRL	NOT IN (6,12))) AND
		UPPER(SUBSTRING(h.MEDIA_FROM, 1, 1)) = 'T'
		
--END

--SELECT * FROM #media_orders
-- Temp Table #media_order_header
CREATE TABLE #media_order_header (
	--MH_ID						integer identity(1, 1) NOT NULL,
	[USER_ID]					varchar(100) NOT NULL,
	[TYPE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	ORDER_NBR					int NOT NULL,
	REV_NBR						smallint NULL,
	OFFICE_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIDIVPRD					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT				text,
	VN_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VR_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VR_CODE2					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER				smallint NULL,
	CMP_NAME					varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILL_TYPE_FLAG				tinyint NULL,
	POST_BILL					tinyint NULL,
	NET_GROSS					tinyint NULL,
	MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MARKET_DESC					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_DATE					smalldatetime NULL,
	FLIGHT_FROM					smalldatetime NULL,
	FLIGHT_TO					smalldatetime NULL,
	ORD_PROCESS_CONTRL			tinyint NULL,
	BUYER						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_PO					varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_ID						int NULL,
	ADVAN_TYPE					tinyint NULL,
	ORDER_ACCEPTED				tinyint NULL,
	FISCAL_PERIOD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- Temp table #media_order_detail
CREATE TABLE #media_order_detail (
	--MD_ID						integer identity(1, 1) NOT NULL,
	[USER_ID]					varchar(100) NOT NULL,
	ORDER_NBR					int NOT NULL,
	LINE_NBR					smallint NOT NULL,
	REV_NBR						smallint NULL,
	SEQ_NBR						tinyint NULL,
	DATE_TYPE					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[MONTH]						tinyint NULL,
	[YEAR]						smallint NULL,
	INSERT_DATE					smalldatetime,
	END_DATE					smalldatetime,
	DATE_TO_BILL				smalldatetime,
	CLOSE_DATE					smalldatetime,
	MATL_CLOSE_DATE				smalldatetime,
	LINE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AD_SIZE						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EDITION_ISSUE				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SECTION						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MATERIAL					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REMARKS						text,
	URL							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COPY_AREA					text,
	MATL_NOTES					text,
	POSITION_INFO				text,
	MISC_INFO					text,
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	COST_TYPE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE_TYPE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRINT_LINES					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GUARANTEED_IMPRESS			int NULL,
	NON_BILL_FLAG				tinyint NULL DEFAULT 0,
	LINE_CANCELLED				tinyint NULL DEFAULT 0,
	BILLED_TYPE_FLAG			tinyint NULL DEFAULT 0,
	LINK_ID						int NULL,
	SPOTS						int NULL)
	
-- Temp table #media_order_amounts
CREATE TABLE #media_order_amounts (
	--MA_ID					integer identity(1, 1) NOT NULL,
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REC_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL,
	LINE_NBR				smallint NULL,
	REV_NBR					tinyint NULL DEFAULT 0,
	SEQ_NBR					tinyint NULL DEFAULT 0,
	[MONTH]					tinyint NULL,
	[YEAR]					smallint NULL,
	EXT_NET_AMT				decimal(15,2) NULL DEFAULT 0,
	NETCHARGES				decimal(15,2) NULL DEFAULT 0,
	DISCOUNTS				decimal(15,2) NULL DEFAULT 0,
	ADDL_CHARGE				decimal(15,2) NULL DEFAULT 0,
	COMM_AMT				decimal(15,2) NULL DEFAULT 0,
	REBATE_AMT				decimal(15,2) NULL DEFAULT 0,
	VENDOR_TAX				decimal(15,2) NULL DEFAULT 0,
	RESALE_TAX				decimal(15,2) NULL DEFAULT 0,
	LINE_TOTAL				decimal(15,2) NULL DEFAULT 0,
	NET_TOTAL_AMT			decimal(15,2) NULL DEFAULT 0,
	VENDOR_NET_AMT			decimal(15,2) NULL DEFAULT 0,
	BILL_AMT				decimal(15,2) NULL DEFAULT 0,
	RECNB_BILL_AMT			decimal(15,2) NULL DEFAULT 0,
	RECNB_NET_AMT			decimal(15,2) NULL DEFAULT 0,
	SPOTS_QTY				int NULL DEFAULT 0,
	NON_BILL_FLAG			tinyint NULL DEFAULT 0,
	LINE_CANCELLED			tinyint NULL DEFAULT 0,
	BILL_TYPE_FLAG			tinyint NULL DEFAULT 0,
	BILLED_EXT_NET_AMT		decimal(15,2) NULL DEFAULT 0,
	BILLED_DISC_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_NC_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_VTAX_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_NET_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_ADDL_CHARGE		decimal(15,2) NULL DEFAULT 0,
	BILLED_COMM_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_REBATE_AMT		decimal(15,2) NULL DEFAULT 0,
	BILLED_RTAX_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_BILL_AMT			decimal(15,2) NULL DEFAULT 0,
	BILLED_SPOTS_QTY		int NULL DEFAULT 0,
	AR_INV_NBR				int NULL,
	AR_SEQ					smallint NULL,
	AR_TYPE					varchar(2) NULL,
	GLXACT_BILL				int NULL,
	AP_NET_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_NETCHARGES_AMT		decimal(15,2) NULL DEFAULT 0,
	AP_DISC_AMT_AMT			decimal(15,2) NULL DEFAULT 0,
	AP_COMM_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_REBATE_AMT			decimal(15,2) NULL DEFAULT 0,
	AP_VTAX_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_RTAX_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_BILL_AMT				decimal(15,2) NULL DEFAULT 0,
	AP_LINE_TOTAL			decimal(15,2) NULL DEFAULT 0,
	AP_SPOTS_QTY			int NULL DEFAULT 0,
	AP_INV_NBR				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLXACT_AP				int NULL)

-- ======================================================================
-- SECTION A - EXTRACTION ROUTINES FROM STORED PROCEDURES FOR TEMP TABLES
-- NOTE: THE DETAIL TABLES ONLY EXTRACT DATA FOR THE ACTIVE REVISION
-- ======================================================================
--****************************************************************************************
--PRINT
--****************************************************************************************
--Print Header (dbo.advsp_media1_order_print_header)
CREATE TABLE #print_order_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	ORDER_DATE						smalldatetime NULL,
	MODIFIED_DATE					smalldatetime NULL,
	REVISED_FLAG					smallint NULL,
	ORDER_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_ID							int NULL,
	OFFICE_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER					int NULL,
	NET_GROSS						smallint NULL,
	ORD_PROCESS_CONTRL				smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_REF						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PUB								smallint NULL,
	VR_CODE							varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REP1							smallint NULL,
	VR_CODE2						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REP2							smallint NULL,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	PRINTED							smallint NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	UNITS							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_ACCEPTED					tinyint NULL)
INSERT INTO #print_order_header EXECUTE dbo.advsp_media1_order_print_header @user_id

--Print detail (dbo.advsp_media1_order_print_detail)-----------------------------------
CREATE TABLE #print_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	ACTIVE_REV						smallint NULL,
	EXT_CLOSE_DATE					smalldatetime NULL, 
	[START_DATE]					smalldatetime NULL,
	END_DATE						smalldatetime NULL, 
	DATE_TO_BILL					smalldatetime NULL, 
	CLOSE_DATE						smalldatetime NULL, 
	MATL_CLOSE_DATE					smalldatetime NULL, 
	EXT_MATL_DATE					smalldatetime NULL, 
	MAT_COMP						datetime NULL,
	SIZE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EDITION_ISSUE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SECTION							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MATERIAL						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[SIZE]							varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRODUCTION_SIZE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	HEADLINE						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRINT_COLUMNS					decimal(6,2) NULL,
	PRINT_INCHES					decimal(6,2) NULL,
	PRINT_LINES						decimal(11,2) NULL,
	COST_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PROJ_IMPRESSIONS				int NULL,
	GUARANTEED_IMPRESS				int NULL,
	ACT_IMPRESSIONS					int NULL,
	URL								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TARGET_AUDIENCE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COPY_AREA						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CREATIVE_SIZE					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PLACEMENT_1						varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PLACEMENT_2						varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COST_RATE						decimal(16,4) NULL,
	NET_BASE_RATE					decimal(16,4) NULL,
	GROSS_BASE_RATE					decimal(16,4) NULL,
	SUB_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SUB_TYPE_DESC					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LOCATION						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE_CARD						int NULL,
	RATE_DESC						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER						int NULL,
	JOB_DESC						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,	 
	JOB_COMPONENT_NBR				smallint NULL, 
	JOB_COMP_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL,
	NON_BILL_FLAG					smallint NULL,
	RECONCILE_LINE					smallint NULL,
	DO_NOT_BILL						smallint NULL,
	INSTRUCTIONS					text, 
	ORDER_COPY						text, 
	POSITION_INFO					text,
	RATE_INFO						text,
	CLOSE_INFO						text,
	MISC_INFO						text, 
	MATL_NOTES						text, 
	IN_HOUSE_CMTS					text,
	AD_NUMBER						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AD_NBR_DESC						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRINTED							smallint NULL,
	RATE							decimal(16,4) NULL,
	NET_RATE						decimal(16,4) NULL,
	GROSS_RATE						decimal(16,4) NULL,
	FLAT_NET						decimal(15,4) NULL, 
	FLAT_GROSS						decimal(15,4) NULL, 
	EXT_NET_AMT						decimal(15,2) NULL,
	EXT_GROSS_AMT					decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT_AMT					decimal(15,2) NULL,
	DISCOUNT_DESC					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	STATE_AMT						decimal(15,2) NULL,
	COUNTY_AMT						decimal(15,2) NULL,
	CITY_AMT						decimal(15,2) NULL,
	NON_RESALE_AMT					decimal(15,2) NULL,
	NETCHARGE						decimal(15,2) NULL,
	NETCHARGE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADDL_CHARGE						decimal(15,2) NULL,
	ADDL_CHARGE_DESC				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PROD_CHARGE						decimal(15,2) NULL,
	PROD_DESC						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COLOR_CHARGE					decimal(15,3) NULL,
	COLOR_DESC						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BLEED_PCT						decimal(7,3) NULL,
	BLEED_AMT						decimal(15,2) NULL,
	POSITION_PCT					decimal(7,3) NULL,
	POSITION_AMT					decimal(15,2) NULL,
	PREMIUM_PCT						decimal(7,3) NULL,
	PREMIUM_AMT						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_TYPE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_SEQ						smallint NULL,
	MARKUP_PCT						decimal(7,3) NULL, 
	COMM_PCT						decimal(7,3) NULL, 
	REBATE_PCT						decimal(7,3) NULL,
	EST_NBR							int NULL,
	EST_LINE_NBR					smallint NULL,
	EST_REV_NBR						smallint NULL,
	CIRCULATION						int NULL,
	PRINT_QUANTITY					decimal(14,3) NULL,
	BLACKPLT_VER1					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BLACKPLT_VER2					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS)
 INSERT INTO #print_detail EXECUTE dbo.advsp_media1_order_print_detail @user_id 
  
--Print amounts (dbo.advsp_media1_order_print_amounts)---------------------------
 CREATE TABLE #print_amounts(
	REC_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
	ACTIVE_REV						smallint NULL,
	COLOR_CHARGE					decimal(15,4) NULL,
	COLOR_DESC						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BLEED_AMT						decimal(15,2) NULL,
	POSITION_AMT					decimal(15,2) NULL,
	PREMIUM_AMT						decimal(15,2) NULL,
	NON_BILL_FLAG					smallint NULL,
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL,								 
	FLAT_GROSS						decimal(15,2) NULL, 								 
	FLAT_NET						decimal(15,2) NULL,
	GROSS_RATE						decimal(16,4) NULL,
	NET_RATE						decimal(16,4) NULL,
	DISCOUNT_AMT					decimal(15,2) NULL,
	ADDL_CHARGE						decimal(15,2) NULL, 
	NETCHARGE						decimal(15,2) NULL, 
	NETCHARGE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	NON_RESALE_AMT					decimal(15,2) NULL, 
	STATE_AMT						decimal(15,2) NULL, 
	COUNTY_AMT						decimal(15,2) NULL, 
	CITY_AMT						decimal(15,2) NULL, 
	COMM_AMT						decimal(15,2) NULL, 
	REBATE_AMT						decimal(15,2) NULL, 
	EXT_NET_AMT						decimal(15,2) NULL, 
	EXT_GROSS_AMT					decimal(15,2) NULL, 
	LINE_TOTAL						decimal(15,2) NULL, 
	BILLING_AMT						decimal(15,2) NULL,
	PRINT_QUANTITY					decimal(14,3) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT							int NULL,
	AR_INV_DATE						smalldatetime,
	AR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #print_amounts EXECUTE dbo.advsp_media1_order_print_amounts @user_id
--SELECT * FROM #print_amounts

--Print amounts AP (advsp_media1_order_print_amounts_ap)-------------------------------
CREATE TABLE #print_amounts_ap(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_DISBURSED_AMT				decimal(15,2) NULL,	
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL,			
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT						int NULL,
	AP_INV_DATE						datetime NULL,
	AP_PAYMENT_HOLD					smallint NULL,
	AP_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_PRINT_QUANTITY				decimal(14,3) NULL,
	AP_ID							int NULL)
INSERT INTO #print_amounts_ap EXECUTE advsp_media1_order_print_amounts_ap @user_id
--SELECT * FROM #print_amounts_ap

--Print amounts AP addl (advsp_media1_order_print_amounts_ap_addl)------------------------------
CREATE TABLE #print_amounts_ap_addl(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, 
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_DISBURSED_AMT				decimal(15,2) NULL,	
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL)
INSERT INTO #print_amounts_ap_addl EXECUTE advsp_media1_order_print_amounts_ap_addl @user_id
--SELECT * FROM #print_amounts_ap_addl

--****************************************************************************************
--BROADCAST (OLD)
--****************************************************************************************
--Broadcast Header (old) (dbo.advsp_media1_order_bcst_header)
CREATE TABLE #bcst_old_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_NBR						int NOT NULL,
	MAX_REV							smallint NULL,
	LINK_ID							int NULL, 
	OFFICE_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DATE						smalldatetime NULL, 
	VN_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE							varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE2						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER					int NULL,
	BILL_TYPE_FLAG					smallint NULL,
	NET_GROSS						smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FLIGHT_FROM						smalldatetime NULL, 
	FLIGHT_TO						smalldatetime NULL,
	BRD_YEAR1						smallint NULL,
	BRD_YEAR2						smallint NULL,
	FIRST_MTH_YR1					smallint NULL,
	LAST_MTH_YR1					smallint NULL,
	FIRST_MTH_YR2					smallint NULL,
	LAST_MTH_YR2					smallint NULL,
	ORD_PROCESS_CONTRL				smallint NULL,
	STATION							smallint NULL,
	REP1							smallint NULL,
	REP2							smallint NULL,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	CREATE_DATE						smalldatetime NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_ACCEPTED					tinyint NULL)	
INSERT INTO #bcst_old_header EXECUTE dbo.advsp_media1_order_bcst_header @user_id
--SELECT * FROM #bcst_old_header

 --Broadcast detail (old) (dbo.advsp_media1_order_bcst_detail)-----------------------------
CREATE TABLE #bcst_old_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL, 
	BRDCAST_YEAR					int NULL,
	DAYS							varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	START_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	END_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[LENGTH]						smallint NULL,
	CLOSE_DATE						smalldatetime NULL,
	MATL_CLOSE_DATE					smalldatetime NULL,   
	MAT_COMP						smalldatetime NULL,  
	PROGRAMMING						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAG								varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	REMARKS							varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GROSS_RATE						decimal(15,2) NULL,
	NET_RATE						decimal(15,2) NULL,
	JOB_NUMBER						int NULL,
	JOB_COMPONENT_NBR				smallint NULL, 
	LINE_CANCELLED					smallint NULL,
	NON_BILL_FLAG					smallint NULL,
	RECONCILE_LINE					smallint NULL,
	DO_NOT_BILL						smallint NULL,
	PRINTED							smallint NULL,
	ORDER_COMMENT					text, 
	POSITION_INFO					text, 
	RATE_INFO						text, 
	CLOSE_INFO						text, 
	MISC_INFO						text, 
	MATL_NOTES						text,
	HOUSE_COMMENT					text)
INSERT INTO #bcst_old_detail EXECUTE dbo.advsp_media1_order_bcst_detail @user_id
--SELECT * FROM #bcst_old_detail

--Broadcast amounts (old) (dbo.advsp_media1_order_bcst_amounts)-------------------------
CREATE TABLE #bcst_old_amounts(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL, 
	REV_NBR							smallint NULL, 
	SEQ_NBR							smallint NULL, 
	MONTH_IND						smallint NULL, 
	MONTH_SHORT						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	BRDCAST_YEAR					int NULL,
	BRDCAST_PER						int NULL, 
	SPOTS							int NULL,
	LINE_NET						decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT						decimal(15,2) NULL,
	VENDOR_TAX						decimal(15,2) NULL,
	STATE_TAX						decimal(15,2) NULL,
	COUNTY_TAX						decimal(15,2) NULL,
	CITY_TAX						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT							int NULL,
	AR_INV_DATE						smalldatetime,
	AR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #bcst_old_amounts EXECUTE dbo.advsp_media1_order_bcst_amounts @user_id	
--SELECT * FROM #bcst_old_amounts

--Broadcast NC amounts (old) (dbo.advsp_media1_order_bcstnc_amounts)---------------------
CREATE TABLE #bcst_old_nc_amounts(
	REC_TYPE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR					int NOT NULL,
	LINE_NBR					int NOT NULL,
	REV_NBR						smallint NOT NULL,
	SEQ_NBR						smallint NOT NULL,
	BRDCAST_PER					int NULL,
	NETCHARGES					decimal(15,2) NULL,
	VENDOR_TAX_NC				decimal(15,2) NULL,
	STATE_TAX_NC				decimal(15,2) NULL,
	COUNTY_TAX_NC				decimal(15,2) NULL,
	CITY_TAX_NC					decimal(15,2) NULL,
	LINE_TOTAL_NC				decimal(15,2) NULL,
	BILLING_AMT_NC				decimal(15,2) NULL,
	AR_INV_NBR					int NULL,
	AR_INV_SEQ					smallint NULL,
	AR_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT						int NULL,
	AR_INV_DATE					smalldatetime,
	AR_POST_PERIOD				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #bcst_old_nc_amounts EXECUTE dbo.advsp_media1_order_bcstnc_amounts @user_id
--SELECT * FROM #bcst_old_nc_amounts

--Broadcast amounts AP (old) (advsp_media1_order_bcst_amounts_ap )--------------------
CREATE TABLE #bcst_old_amounts_ap(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, 
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL,		
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT						int NULL,
	AP_INV_DATE						datetime NULL,
	AP_PAYMENT_HOLD					smallint NULL,
	AP_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TOTAL_SPOTS						smallint,
	AP_ID							int NULL)
INSERT INTO #bcst_old_amounts_ap EXECUTE advsp_media1_order_bcst_amounts_ap @user_id
--SELECT * FROM #bcst_old_amounts_ap

--****************************************************************************************
--BROADCAST (NEW)
--****************************************************************************************
--Broadcast Header (new) (dbo.advsp_media1_order_bcst_header2)
CREATE TABLE #bcst_new_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	UNITS							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_NBR						int NOT NULL,
	MAX_REV							smallint NULL,
	LINK_ID							int NULL, 
	OFFICE_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DATE						smalldatetime NULL, 
	VN_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE							varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE2						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER					int NULL,
	NET_GROSS						smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORD_PROCESS_CONTRL				smallint NULL,
	STATION							smallint NULL,
	REP1							smallint NULL,
	REP2							smallint NULL,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	CREATE_DATE						smalldatetime NULL,
	[START_DATE]					smalldatetime NULL,
	END_DATE						smalldatetime NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_ACCEPTED					tinyint NULL)
INSERT INTO #bcst_new_header EXECUTE dbo.advsp_media1_order_bcst_header2 @user_id
--SELECT * FROM #bcst_new_header	

--Broadcast detail (new) (dbo.advsp_media1_order_bcst_detail2)---------------------------
CREATE TABLE #bcst_new_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL, 
	ACTIVE_REV						smallint NULL,
	BUY_TYPE						varchar(12) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[START_DATE]					smalldatetime NULL,
	END_DATE						smalldatetime NULL,
	MONTH_NBR						smallint NULL,
	YEAR_NBR						smallint NULL,
	DATE1							smalldatetime NULL,
	DATE2							smalldatetime NULL,
	DATE3							smalldatetime NULL,
	DATE4							smalldatetime NULL,
	DATE5							smalldatetime NULL,
	DATE6							smalldatetime NULL,
	DATE7							smalldatetime NULL,
	[DAYS]							varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SPOTS1							int NULL,
	SPOTS2							int NULL,
	SPOTS3							int NULL,
	SPOTS4							int NULL,
	SPOTS5							int NULL,
	SPOTS6							int NULL,
	SPOTS7							int NULL,
	TOTAL_SPOTS						int NULL,
	JOB_NUMBER						int NULL,
	JOB_COMPONENT_NBR				smallint NULL,
	START_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	END_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[LENGTH]						smallint NULL,
	CLOSE_DATE						smalldatetime NULL,
	MATL_CLOSE_DATE					smalldatetime NULL,   
	MAT_COMP						smalldatetime NULL,   
	AD_NUMBER						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PROGRAMMING						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAG								varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	REMARKS							varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS,
	RATE							decimal(16,4) NULL,
	GROSS_RATE						decimal(16,4) NULL,
	NET_RATE						decimal(16,4) NULL,
	EXT_NET_AMT						decimal(15,2) NULL,
	EXT_GROSS_AMT					decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT_AMT					decimal(15,2) NULL,
	DISCOUNT_DESC					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	STATE_AMT						decimal(15,2) NULL,
	COUNTY_AMT						decimal(15,2) NULL,
	CITY_AMT						decimal(15,2) NULL,
	NON_RESALE_AMT					decimal(15,2) NULL,
	NETCHARGE						decimal(16,4) NULL,
	NCDESC							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADDL_CHARGE						decimal(14,2) NULL,
	ADDL_CHARGE_DESC				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL,
	NON_BILL_FLAG					smallint NULL,
	RECONCILE_FLAG					smallint NULL,
	DATE_TO_BILL					smalldatetime,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_TYPE							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_SEQ						smallint NULL,
	EST_NBR							int NULL,
	EST_LINE_NBR					smallint NULL,
	EST_REV_NBR						smallint NULL)
INSERT INTO #bcst_new_detail EXECUTE dbo.advsp_media1_order_bcst_detail2 @user_id
--SELECT * FROM #bcst_new_detail

----Broadcast comments (new) (dbo.advsp_media1_order_bcst_detail2)---------------------------
CREATE TABLE #bcst_new_comments(
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	INSTRUCTIONS					text,
	ORDER_COPY						text,
	MATL_NOTES						text,
	POSITION_INFO					text, 
	CLOSE_INFO						text, 
	RATE_INFO						text, 
	MISC_INFO						text, 
	IN_HOUSE_CMTS					text)
INSERT INTO #bcst_new_comments EXECUTE dbo.advsp_media1_order_bcst_comments2 @user_id
--SELECT * FROM #bcst_new_comments

--Broadcast amounts (new) (dbo.advsp_media1_order_bcst_amounts2)--------------------------
CREATE TABLE #bcst_new_amounts(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL, 
	REV_NBR							smallint NULL, 
	SEQ_NBR							smallint NULL, 
	MONTH_IND						smallint NULL, 
	MONTH_SHORT						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	BRDCAST_YEAR					int NULL,
	BRDCAST_PER						int NULL,  					
	SPOTS1							int NULL,					--#11
	SPOTS2							int NULL,					--#11
	SPOTS3							int NULL,					--#11
	SPOTS4							int NULL,					--#11
	SPOTS5							int NULL,					--#11
	SPOTS6							int NULL,					--#11
	SPOTS7							int NULL,					--#11
	SPOTS							int NULL,
	LINE_NET						decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT						decimal(15,2) NULL,
	VENDOR_TAX						decimal(15,2) NULL,
	STATE_TAX						decimal(15,2) NULL,
	COUNTY_TAX						decimal(15,2) NULL,
	CITY_TAX						decimal(15,2) NULL,
	NETCHARGE						decimal(15,2) NULL,
	ADDL_CHARGE						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILL_TYPE_FLAG					smallint NULL,
	GRP								decimal(18,5) NULL,
	GROSS_IMPRESSIONS				decimal(18,5) NULL,
	MEDIA_DEMO_DESCRIPTION			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BOOKEND							bit NULL,
	VALUE_ADDED						bit NULL,
	GLEXACT							int NULL,
	AR_INV_DATE						smalldatetime,
	AR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #bcst_new_amounts EXECUTE dbo.advsp_media1_order_bcst_amounts2 @user_id
--SELECT * FROM #bcst_new_amounts

--Broadcast amounts AP (new) (advsp_media1_order_bcst_amounts_ap2)----------------------
CREATE TABLE #bcst_new_amounts_ap(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL,		
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT						int NULL,
	AP_INV_DATE						datetime NULL,
	AP_PAYMENT_HOLD					smallint NULL,
	AP_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TOTAL_SPOTS						int,
	AP_ID							int NULL)
INSERT INTO #bcst_new_amounts_ap EXECUTE advsp_media1_order_bcst_amounts_ap2 @user_id
--SELECT * FROM #bcst_new_amounts_ap

--Broadcast amounts AP addl (new) (advsp_media1_order_bcst_amounts_ap_addl2)-------------------
CREATE TABLE #bcst_new_amounts_ap_addl(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_DISBURSED_AMT				decimal(15,2) NULL,	
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL)
INSERT INTO #bcst_new_amounts_ap_addl EXECUTE advsp_media1_order_bcst_amounts_ap_addl2 @user_id
--SELECT * FROM #bcst_new_amounts_ap_addl
-- END OF SECTION A

-- ==========================================================
-- SECTION B - POPULATE MEDIA ORDER HEADER TABLE #media_order_header
-- ==========================================================
---- Clears data records for this USER_ID from mh
--DELETE mh WHERE [USER_ID] = @user_id
----DELETE mh		--used for testing

--Print header------------------------------------------------------
INSERT INTO #media_order_header
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED, FISCAL_PERIOD_CODE)
SELECT
	@user_id,
	CASE h.ORDER_TYPE
		WHEN 'I' THEN 'INT'
		WHEN 'M' THEN 'MAG'
		WHEN 'N' THEN 'NEWS'
		WHEN 'O' THEN 'OUT'
	END,
	h.ORDER_NBR,
	0,
	h.OFFICE_CODE,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	NULL,
	h.ORDER_DESC,
	h.ORDER_COMMENT,
	h.VN_CODE,
	h.VR_CODE,
	h.VR_CODE2,
	c.CMP_CODE,
	h.CMP_IDENTIFIER,
	c.CMP_NAME,
	h.MEDIA_TYPE,
	CASE
		WHEN p.PRD_MAG_COM_ONLY = 1 THEN 1
		WHEN p.PRD_MAG_BILL_NET = 1 THEN 2
		ELSE 3
	END,
	ISNULL(p.PRD_MAG_PRE_POST,0),
	h.NET_GROSS,
	h.MARKET_CODE,
	m.MARKET_DESC,
	h.ORDER_DATE,
	NULL,
	NULL,
	h.ORD_PROCESS_CONTRL,
	h.BUYER,
	h.CLIENT_PO,
	h.LINK_ID,
	2,
	NULL,
	FISCAL_PERIOD_CODE
FROM #print_order_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
--SELECT * FROM mh

--Broadcast header (old)------------------------------------------------------
INSERT INTO #media_order_header
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED, FISCAL_PERIOD_CODE)
SELECT
	@user_id,	
	CASE h.ORDER_TYPE
		WHEN 'R' THEN 'RADIO'
		WHEN 'T' THEN 'TV'
	END,
	h.ORDER_NBR,
	0,
	h.OFFICE_CODE,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	NULL,
	h.ORDER_DESC,
	h.ORDER_COMMENT,
	h.VN_CODE,
	h.VR_CODE,
	h.VR_CODE2,
	c.CMP_CODE,
	h.CMP_IDENTIFIER,
	c.CMP_NAME,
	h.MEDIA_TYPE,
	h.BILL_TYPE_FLAG,
	ISNULL(p.PRD_RADIO_PRE_POST,0),
	h.NET_GROSS,
	h.MARKET_CODE,
	m.MARKET_DESC,
	h.ORDER_DATE,
	h.FLIGHT_FROM,
	h.FLIGHT_TO,
	h.ORD_PROCESS_CONTRL,
	h.BUYER,
	h.CLIENT_PO,
	h.LINK_ID,
	1,
	NULL, 
	FISCAL_PERIOD_CODE	
FROM #bcst_old_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
--SELECT * FROM mh			

--Broadcast header (new)------------------------------------------------------
INSERT INTO #media_order_header
	([USER_ID], [TYPE], ORDER_NBR, REV_NBR, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CLIDIVPRD, ORDER_DESC,
	ORDER_COMMENT, VN_CODE, VR_CODE, VR_CODE2, CMP_CODE, CMP_IDENTIFIER, CMP_NAME, MEDIA_TYPE, BILL_TYPE_FLAG,
	POST_BILL, NET_GROSS, MARKET_CODE, MARKET_DESC, ORDER_DATE, FLIGHT_FROM, FLIGHT_TO, ORD_PROCESS_CONTRL,
	BUYER, CLIENT_PO, LINK_ID, ADVAN_TYPE, ORDER_ACCEPTED, FISCAL_PERIOD_CODE)
SELECT
	@user_id,	
	CASE h.ORDER_TYPE
		WHEN 'R' THEN 'RADIO'
		WHEN 'T' THEN 'TV'
	END,
	h.ORDER_NBR,
	0,
	h.OFFICE_CODE,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	NULL,
	h.ORDER_DESC,
	h.ORDER_COMMENT,
	h.VN_CODE,
	h.VR_CODE,
	h.VR_CODE2,
	c.CMP_CODE,
	h.CMP_IDENTIFIER,
	c.CMP_NAME,
	h.MEDIA_TYPE,
	CASE
		WHEN p.PRD_RADIO_COM_ONLY = 1 THEN 1
		WHEN p.PRD_RADIO_BILL_NET = 1 THEN 2
		ELSE 3
	END,
	ISNULL(p.PRD_RADIO_PRE_POST,0),
	h.NET_GROSS,
	h.MARKET_CODE,
	m.MARKET_DESC,
	h.ORDER_DATE,
	NULL,
	NULL,
	h.ORD_PROCESS_CONTRL,
	h.BUYER,
	h.CLIENT_PO,
	h.LINK_ID,
	2,
	NULL,
	FISCAL_PERIOD_CODE		
FROM #bcst_new_header AS h
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
LEFT JOIN dbo.CAMPAIGN AS c
	ON h.CMP_IDENTIFIER = c.CMP_IDENTIFIER
LEFT JOIN dbo.MARKET AS m
	ON h.MARKET_CODE = m.MARKET_CODE
--SELECT * FROM #media_order_header
-- END OF SECTION B			

-- ==========================================================
-- SECTION C - POPULATE MEDIA ORDER DETAIL TABLE #media_order_detail
-- ==========================================================
---- Clears data records for this USER_ID from md
--DELETE md WHERE [USER_ID] = @user_id
----DELETE md		--used for testing

--Print detail------------------------------------------------------
INSERT INTO #media_order_detail
	([USER_ID], ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS)
SELECT
	@user_id,
	d.ORDER_NBR,
	d.LINE_NBR,
	0,
	0,
	'PRN',
	MONTH(d.[START_DATE]),
	YEAR(d.[START_DATE]),
	d.[START_DATE],
	d.END_DATE,
	d.DATE_TO_BILL,
	d.CLOSE_DATE,
	d.MATL_CLOSE_DATE,
	d.HEADLINE,
	d.SIZE,
	d.EDITION_ISSUE,
	d.SECTION,
	d.MATERIAL,
	NULL,
	d.URL,
	d.COPY_AREA,
	d.MATL_NOTES,
	d.POSITION_INFO,
	d.MISC_INFO,
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	d.COST_TYPE,
	d.RATE_TYPE,
	d.PRINT_LINES,
	d.GUARANTEED_IMPRESS,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	NULL,
	0							--#07 (SPOTS are not applicable for print)
FROM #print_detail AS d
--SELECT * FROM #media_order_detail

--Broadcast detail (old)------------------------------------------------------
INSERT INTO #media_order_detail
	([USER_ID], ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS)
SELECT
	@user_id,
	d.ORDER_NBR,
	d.LINE_NBR,		
	0,
	0,
	'BRD',
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	d.MATL_CLOSE_DATE,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	d.REMARKS,
	NULL,
	NULL,
	d.MATL_NOTES,
	d.POSITION_INFO,
	d.MISC_INFO,				--#06
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	NULL,
	NULL,
	NULL,
	NULL,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	h.BILL_TYPE_FLAG,
	NULL,
	0							--#07 (ordered SPOTS are not in the old detail table)
FROM #bcst_old_detail AS d
JOIN #bcst_old_header AS h
	ON d.ORDER_NBR = h.ORDER_NBR
--SELECT * FROM #media_order_detail

--Broadcast detail (new)------------------------------------------------------
INSERT INTO #media_order_detail
	([USER_ID], ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, DATE_TYPE, [MONTH], [YEAR], INSERT_DATE, END_DATE,DATE_TO_BILL,
	CLOSE_DATE, MATL_CLOSE_DATE, LINE_DESC, AD_SIZE, EDITION_ISSUE, SECTION, MATERIAL, REMARKS, URL, COPY_AREA,
	MATL_NOTES, POSITION_INFO, MISC_INFO, JOB_NUMBER, JOB_COMPONENT_NBR, COST_TYPE, RATE_TYPE	, PRINT_LINES,
	GUARANTEED_IMPRESS, NON_BILL_FLAG, LINE_CANCELLED, BILLED_TYPE_FLAG, LINK_ID, SPOTS)
SELECT
	@user_id,
	d.ORDER_NBR,
	d.LINE_NBR,
	0,
	0,
	'BRD',
	MONTH(d.[START_DATE]),		--NULL,
	YEAR(d.[START_DATE]),		--NULL,
	d.[START_DATE],
	NULL,
	NULL,
	NULL,
	d.MATL_CLOSE_DATE,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	d.REMARKS,
	NULL,
	NULL,
	c.MATL_NOTES,
	c.POSITION_INFO,
	c.MISC_INFO,				--#06
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	NULL,
	NULL,
	NULL,
	NULL,
	d.NON_BILL_FLAG,
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	NULL,
	d.TOTAL_SPOTS				--#07
FROM #bcst_new_detail AS d
LEFT JOIN #bcst_new_comments AS c
	ON d.ORDER_NBR = c.ORDER_NBR
	AND d.LINE_NBR = c.LINE_NBR
--SELECT * FROM #media_order_detail
-- END OF SECTION C

-- ==========================================================
-- SECTION D - POPULATE MEDIA_ORDER_AMOUNTS table #media_order_amounts
-- SEE ADRPTS MACRO "MedRpts OrderDetail"
-- ==========================================================
---- Clears data records for this USER_ID from the main data table
--DELETE ma WHERE [USER_ID] = @user_id
----DELETE ma		--used for testing

--1. Print ORDER data - (see Adrpts query "MedRpts OrderDetail Print")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	--[MONTH],
	--[YEAR],
	EXT_NET_AMT,
	NETCHARGES,
	DISCOUNTS,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	RESALE_TAX,
	LINE_TOTAL,
	NET_TOTAL_AMT,
	VENDOR_NET_AMT,
	BILL_AMT,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	SPOTS_QTY)
SELECT
	@user_id,
	ORDER_TYPE,
	'O',
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT
	END,
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NETCHARGE
	END,		
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN DISCOUNT_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN ADDL_CHARGE
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN COMM_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN REBATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 AND ACTIVE_REV = 1 THEN CITY_AMT + COUNTY_AMT + STATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN LINE_TOTAL
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1  AND BILL_TYPE_FLAG <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN BILLING_AMT
	END,		
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	PRINT_QUANTITY								--#09 (for newspaper and internet)
FROM #print_detail

--2. Print BILLING data - (see Adrpts query "MedRpts BilledPrint")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	BILLED_EXT_NET_AMT,
	BILLED_DISC_AMT,
	BILLED_NC_AMT,
	BILLED_VTAX_AMT,
	BILLED_NET_AMT,
	BILLED_ADDL_CHARGE,
	BILLED_COMM_AMT,
	BILLED_REBATE_AMT,
	BILLED_RTAX_AMT,
	BILLED_BILL_AMT,
	AR_INV_NBR,
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY)
SELECT
	@user_id,
	ORDER_TYPE,
	'B',
	ORDER_NBR,
	LINE_NBR,
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	EXT_NET_AMT,
	DISCOUNT_AMT,
	NETCHARGE,
	NON_RESALE_AMT,
	CASE
		WHEN BILL_TYPE_FLAG = 2 OR BILL_TYPE_FLAG = 3 THEN 
		EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	CITY_AMT + COUNTY_AMT + STATE_AMT,
	BILLING_AMT,
	AR_INV_NBR,
	AR_INV_SEQ,
	AR_TYPE,
	GLEXACT,
	PRINT_QUANTITY					--#09 (newspaper PRINT_LINES and internet GUARANTEED_IMPRESS)	
FROM #print_amounts
WHERE AR_INV_NBR IS NOT NULL

--3. Broadcast ORDER data (old) - (see Adrpts query "MedRpts OrderDetail Bcst")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	EXT_NET_AMT,
	NETCHARGES,
	DISCOUNTS,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	RESALE_TAX,
	LINE_TOTAL,
	NET_TOTAL_AMT,
	VENDOR_NET_AMT,
	BILL_AMT,
	RECNB_BILL_AMT,
	RECNB_NET_AMT,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'O',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.MONTH_IND,
	a.BRDCAST_YEAR,
	LINE_NET,
	0,
	DISCOUNT,
	0,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	CITY_TAX + COUNTY_TAX + STATE_TAX,
	LINE_NET + COMM_AMT + VENDOR_TAX + DISCOUNT,		--#01
	LINE_NET + DISCOUNT + VENDOR_TAX,
	CASE
		WHEN f.BILL_TYPE_FLAG <> 1 THEN LINE_NET + DISCOUNT + VENDOR_TAX
	END,
	BILLING_AMT,
	CASE
		WHEN d.DO_NOT_BILL = 1 AND f.BILL_TYPE_FLAG = 2 THEN LINE_NET + DISCOUNT + VENDOR_TAX			
		WHEN d.DO_NOT_BILL = 1 AND f.BILL_TYPE_FLAG = 3 THEN LINE_NET + DISCOUNT + VENDOR_TAX + COMM_AMT		--#03
		ELSE 0
	END,	
	CASE
		WHEN d.DO_NOT_BILL =1 THEN LINE_NET + DISCOUNT + VENDOR_TAX
	END,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	0									--#07 (ordered SPOTS are not in the old detail table)
FROM #bcst_old_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR	
	
--4. Broadcast BILLING data (old) - (see Adrpts query "MedRpts BilledBcst")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	BILLED_EXT_NET_AMT,
	BILLED_DISC_AMT,
	BILLED_NC_AMT,
	BILLED_VTAX_AMT,
	BILLED_NET_AMT,
	BILLED_ADDL_CHARGE,
	BILLED_COMM_AMT,
	BILLED_REBATE_AMT,
	BILLED_RTAX_AMT,
	BILLED_BILL_AMT,
	AR_INV_NBR,
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'B',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.MONTH_IND,
	a.BRDCAST_YEAR,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN LINE_NET
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN DISCOUNT
	END,	
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN VENDOR_TAX
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN LINE_NET + VENDOR_TAX + DISCOUNT
	END,
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 1 OR f.BILL_TYPE_FLAG = 3 THEN	COMM_AMT
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 1 OR f.BILL_TYPE_FLAG = 3 THEN	REBATE_AMT
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 or f.BILL_TYPE_FLAG =3 THEN CITY_TAX + COUNTY_TAX + STATE_TAX
	END,
	BILLING_AMT,
	AR_INV_NBR,
	AR_INV_SEQ,
	AR_TYPE,
	GLEXACT,
	0						--a.SPOTS							--#07
FROM #bcst_old_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR
WHERE a.AR_INV_NBR IS NOT NULL	

--5. Broadcast ORDER data (new) - (see Adrpts query "MedRpts OrderDetail Bcst2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	EXT_NET_AMT,
	NETCHARGES,
	DISCOUNTS,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	RESALE_TAX,
	LINE_TOTAL,
	NET_TOTAL_AMT,
	VENDOR_NET_AMT,
	BILL_AMT,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	SPOTS_QTY)
SELECT
	@user_id,
	ORDER_TYPE + '2',
	'O',
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT
	END,
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NETCHARGE
	END,		
	CASE 
		WHEN LINE_CANCELLED <> 1 THEN DISCOUNT_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN ADDL_CHARGE
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN COMM_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN REBATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 AND ACTIVE_REV = 1 THEN CITY_AMT + COUNTY_AMT + STATE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN LINE_TOTAL
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1  AND BILL_TYPE_FLAG <> 1 THEN EXT_NET_AMT + NETCHARGE + DISCOUNT_AMT + NON_RESALE_AMT
	END,		
	CASE
		WHEN LINE_CANCELLED <> 1 THEN BILLING_AMT
	END,		
	ISNULL(NON_BILL_FLAG,0),
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	TOTAL_SPOTS							--#07
FROM #bcst_new_detail

--6. Broadcast BILLING data (new) - (see Adrpts query "MedRpts BilledBcst2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	BILLED_EXT_NET_AMT,
	BILLED_DISC_AMT,
	BILLED_NC_AMT,
	BILLED_VTAX_AMT,
	BILLED_NET_AMT,
	BILLED_ADDL_CHARGE,
	BILLED_COMM_AMT,
	BILLED_REBATE_AMT,
	BILLED_RTAX_AMT,
	BILLED_BILL_AMT,
	AR_INV_NBR,
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL,
	BILLED_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE + '2',
	'B',
	a.ORDER_NBR,
	a.LINE_NBR,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.LINE_NET,
	a.DISCOUNT,
	a.NETCHARGE,
	a.VENDOR_TAX,
	CASE
		WHEN d.BILL_TYPE_FLAG = 2 OR d.BILL_TYPE_FLAG = 3 THEN 
		a.LINE_NET + a.NETCHARGE + a.DISCOUNT + a.VENDOR_TAX
	END,
	a.ADDL_CHARGE,
	a.COMM_AMT,
	a.REBATE_AMT,
	a.CITY_TAX + a.COUNTY_TAX + a.STATE_TAX,
	a.BILLING_AMT,
	a.AR_INV_NBR,
	a.AR_INV_SEQ,
	a.AR_TYPE,
	a.GLEXACT,
	a.SPOTS							--#07	
FROM #bcst_new_amounts as a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
WHERE a.AR_INV_NBR IS NOT NULL		
	
--7. Broadcast Netcharge ORDER data (old) - (see Adrpts query "MedRptsOrderDetail BcstNC")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	EXT_NET_AMT,
	NETCHARGES,
	DISCOUNTS,
	ADDL_CHARGE,
	COMM_AMT,
	REBATE_AMT,
	VENDOR_TAX,
	RESALE_TAX,
	LINE_TOTAL,
	NET_TOTAL_AMT,
	VENDOR_NET_AMT,
	BILL_AMT,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG)
SELECT
	@user_id,
	a.ORDER_TYPE + 'N',
	'O',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.BRDCAST_PER % 100,
	a.BRDCAST_PER / 100,
	0,
	NETCHARGES,
	0,
	0,
	0,
	0,
	VENDOR_TAX_NC,
	CITY_TAX_NC + COUNTY_TAX_NC + STATE_TAX_NC,
	NETCHARGES + VENDOR_TAX_NC,
	NETCHARGES + VENDOR_TAX_NC,
	CASE
		WHEN f.BILL_TYPE_FLAG <> 1 THEN NETCHARGES + VENDOR_TAX_NC		
	END,	
	CASE
		WHEN f.BILL_TYPE_FLAG <> 1 THEN NETCHARGES + VENDOR_TAX_NC + CITY_TAX_NC 
			+ COUNTY_TAX_NC + STATE_TAX_NC		--#02
	END,	
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG
FROM #bcst_old_nc_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR	
	
--8. Broadcast Netcharge BILLING data (old) - (see Adrpts query "MedRpts BilledBcstNC")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	BILLED_EXT_NET_AMT,
	BILLED_DISC_AMT,
	BILLED_NC_AMT,
	BILLED_VTAX_AMT,
	BILLED_NET_AMT,
	BILLED_ADDL_CHARGE,
	BILLED_COMM_AMT,
	BILLED_REBATE_AMT,
	BILLED_RTAX_AMT,
	BILLED_BILL_AMT,
	AR_INV_NBR,
	AR_SEQ,
	AR_TYPE,
	GLXACT_BILL)
SELECT
	@user_id,
	a.ORDER_TYPE + 'N',
	'B',
	a.ORDER_NBR,
	a.LINE_NBR,
	a.REV_NBR,
	a.SEQ_NBR,
	a.BRDCAST_PER % 100,
	a.BRDCAST_PER / 100,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	0,
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	NETCHARGES
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	VENDOR_TAX_NC
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	NETCHARGES + VENDOR_TAX_NC
	END,
	0,
	0,
	0,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	CITY_TAX_NC + COUNTY_TAX_NC + STATE_TAX_NC
	END,
	CASE
		WHEN f.BILL_TYPE_FLAG = 2 OR f.BILL_TYPE_FLAG = 3 THEN	NETCHARGES + VENDOR_TAX_NC 
			+ CITY_TAX_NC + COUNTY_TAX_NC + STATE_TAX_NC		--#04
	END,
	AR_INV_NBR,
	AR_INV_SEQ,
	AR_TYPE,
	GLEXACT
FROM #bcst_old_nc_amounts AS a
JOIN #bcst_old_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR	
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR
WHERE a.AR_INV_NBR IS NOT NULL

--9. Print AP data - (see Adrpts query "MedRpts APPrint")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	GLXACT_AP,
	AP_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_DISBURSED_AMT,
	0,
	0,
	0,
	0,
	0,
	0,
	a.AP_BILLING_AMT,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_GLEXACT,
	a.AP_PRINT_QUANTITY						--#09
FROM #print_amounts_ap AS a
JOIN #print_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
	
--10. Print AP data additional - (see Adrpts query "MedRpts APPrint_addl")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	GLXACT_AP,
	AP_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_DISBURSED_AMT,
	0,
	0,
	0,
	0,
	0,
	0,
	a.AP_BILLING_AMT,
	a.AP_LINE_TOTAL,
	NULL,
	NULL,
	0							--#08 spots not applicable for print AP additional
FROM #print_amounts_ap_addl AS a
JOIN #print_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR

--11. Broadcast AP data (old) - (see Adrpts query "MedRpts APBcst")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	GLXACT_AP,
	AP_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE,
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	a.[MONTH],				--#05			
	a.[YEAR],				--#05
	0,		--ISNULL(d.NON_BILL_FLAG,0),
	0,		--d.LINE_CANCELLED,
	f.BILL_TYPE_FLAG,
	a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES,
	a.AP_NETCHARGES,
	a.AP_DISCOUNT_AMT,
	a.AP_COMM_AMT,
	a.AP_REBATE_AMT,
	a.AP_VENDOR_TAX,
	a.AP_CITY_TAX + a.AP_COUNTY_TAX + a.AP_STATE_TAX,
	CASE
		WHEN BILL_TYPE_FLAG = 3 THEN a.AP_LINE_TOTAL
		ELSE a.AP_LINE_TOTAL -(a.AP_COMM_AMT + a.AP_REBATE_AMT)		
	END,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_GLEXACT,
	0					--a.TOTAL_SPOTS					--#08
FROM #bcst_old_amounts_ap AS a
JOIN #bcst_old_header AS f
	ON a.ORDER_NBR = f.ORDER_NBR	
	
--12. Broadcast AP data (new) - (see Adrpts query "MedRpts APBcst2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	GLXACT_AP,
	AP_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE + '2',
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	a.[MONTH],			--#05
	a.[YEAR],			--#05
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES,
	0,
	0,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	0,
	0,
	CASE
		WHEN BILL_TYPE_FLAG = 3 THEN a.AP_LINE_TOTAL
		ELSE a.AP_LINE_TOTAL -(a.AP_COMM_AMT + a.AP_REBATE_AMT)		
	END,
	a.AP_LINE_TOTAL,
	a.AP_INV_VCHR,
	a.AP_GLEXACT,
	a.TOTAL_SPOTS					--#08
FROM #bcst_new_amounts_ap AS a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR
	AND a.LINE_NBR = d.LINE_NBR
	
--13. Broadcast AP data additional (new) - (see Adrpts query "MedRpts APBcst_addl2")
INSERT INTO #media_order_amounts(
	[USER_ID],
	ORDER_TYPE,
	REC_TYPE,
	ORDER_NBR,
	LINE_NBR,
	REV_NBR,
	SEQ_NBR,
	[MONTH],
	[YEAR],
	NON_BILL_FLAG,
	LINE_CANCELLED,
	BILL_TYPE_FLAG,
	AP_NET_AMT,
	AP_NETCHARGES_AMT,
	AP_DISC_AMT_AMT,
	AP_COMM_AMT,
	AP_REBATE_AMT,
	AP_VTAX_AMT,
	AP_RTAX_AMT,
	AP_BILL_AMT,
	AP_LINE_TOTAL,
	AP_INV_NBR,
	GLXACT_AP,
	AP_SPOTS_QTY)
SELECT
	@user_id,
	a.ORDER_TYPE + '2',
	'A',
	a.ORDER_NBR,
	a.LINE_NBR,
	0,
	0,
	[MONTH],			--#05
	[YEAR],				--#05
	ISNULL(d.NON_BILL_FLAG,0),
	d.LINE_CANCELLED,
	d.BILL_TYPE_FLAG,
	a.AP_NET_AMT + a.AP_DISCOUNT_AMT + a.AP_VENDOR_TAX + a.AP_NETCHARGES,
	0,
	0,
	0,
	0,
	0,
	0,
	a.AP_BILLING_AMT,
	a.AP_LINE_TOTAL,
	NULL,
	NULL,
	0					--#08 spots not applicable for AP additional
FROM #bcst_new_amounts_ap_addl AS a
JOIN #bcst_new_detail AS d
	ON a.ORDER_NBR = d.ORDER_NBR	

--SELECT * FROM #media_order_header
--SELECT * FROM #media_order_detail
--SELECT * FROM #media_order_amounts
--SELECT @user_id AS [USER_ID]

-- ==========================================================
-- SECTION E - LINK TEMP TABLES AND OTHER TABLES FOR COMPOSITE DATASET
-- CREATES SUMMARY TABLE OF #media_order_amounts
-- ==========================================================

CREATE TABLE #media_order_amounts_sum(
	  [USER_ID]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  ORDER_TYPE					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  ORDER_NBR						int NULL,
	  LINE_NBR						smallint NULL,
	  [MONTH]						tinyint NULL,
	  [YEAR]						smallint NULL,
	  EXT_NET_AMT					decimal(15,2) NULL, 
	  NETCHARGES					decimal(15,2) NULL,
	  DISCOUNTS						decimal(15,2) NULL,
	  ADDL_CHARGE					decimal(15,2) NULL, 
	  COMM_AMT						decimal(15,2) NULL,
	  REBATE_AMT					decimal(15,2) NULL,
	  VENDOR_TAX					decimal(15,2) NULL,
	  RESALE_TAX					decimal(15,2) NULL,
	  LINE_TOTAL					decimal(15,2) NULL, 
	  NET_TOTAL_AMT					decimal(15,2) NULL,
	  VENDOR_NET_AMT				decimal(15,2) NULL,
	  BILL_AMT						decimal(15,2) NULL,
	  RECNB_BILL_AMT				decimal(15,2) NULL, 
	  RECNB_NET_AMT					decimal(15,2) NULL,
	  SPOTS_QTY						int NULL,	
	  NON_BILL_FLAG					tinyint NULL,
	  LINE_CANCELLED				tinyint NULL,
	  BILL_TYPE_FLAG				tinyint NULL,
	  BILLED_EXT_NET_AMT			decimal(15,2) NULL, 
	  BILLED_DISC_AMT				decimal(15,2) NULL,
	  BILLED_NC_AMT					decimal(15,2) NULL,
	  BILLED_VTAX_AMT				decimal(15,2) NULL,
	  BILLED_NET_AMT				decimal(15,2) NULL,
	  BILLED_ADDL_CHARGE			decimal(15,2) NULL,
	  BILLED_COMM_AMT				decimal(15,2) NULL,
	  BILLED_REBATE_AMT				decimal(15,2) NULL,
	  BILLED_RTAX_AMT				decimal(15,2) NULL,
	  BILLED_BILL_AMT				decimal(15,2) NULL,
	  BILLED_SPOTS_QTY				int NULL,		  
	  AR_INV_NBR					int NULL,
	  AR_SEQ						tinyint NULL,
	  AR_TYPE						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  GLXACT_BILL					int NULL,
	  AP_NET_AMT					decimal(15,2) NULL,
	  AP_NETCHARGES_AMT				decimal(15,2) NULL, 
	  AP_DISC_AMT_AMT				decimal(15,2) NULL,
	  AP_COMM_AMT					decimal(15,2) NULL,
	  AP_REBATE_AMT					decimal(15,2) NULL,
	  AP_VTAX_AMT					decimal(15,2) NULL,
	  AP_RTAX_AMT					decimal(15,2) NULL,
	  AP_BILL_AMT					decimal(15,2) NULL,
	  AP_LINE_TOTAL					decimal(15,2) NULL, 
	  AP_SPOTS_QTY					int NULL,			
	  AP_INV_NBR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	  GLXACT_AP						int NULL) 

--For print media (include line number)
INSERT INTO #media_order_amounts_sum
SELECT 
	  d.[USER_ID] AS [USER_ID],
	  d.ORDER_TYPE AS ORDER_TYPE,
	  d.ORDER_NBR AS ORDER_NBR,
	  d.LINE_NBR AS LINE_NBR,
	  MONTH(dt.INSERT_DATE) AS [MONTH],
	  YEAR(dt.INSERT_DATE) AS [YEAR],
	  SUM(d.EXT_NET_AMT) AS EXT_NET_AMT, 
	  SUM(d.NETCHARGES) AS NETCHARGES,
	  SUM(d.DISCOUNTS) AS DISCOUNTS,
	  SUM(d.ADDL_CHARGE) AS ADDL_CHARGE, 
	  SUM(d.COMM_AMT) AS COMM_AMT,
	  SUM(d.REBATE_AMT) AS REBATE_AMT,
	  SUM(d.VENDOR_TAX) AS VENDOR_TAX,
	  SUM(d.RESALE_TAX) AS RESALE_TAX,
	  SUM(d.LINE_TOTAL) AS LINE_TOTAL, 
	  SUM(d.NET_TOTAL_AMT) AS NET_TOTAL_AMT,
	  SUM(d.VENDOR_NET_AMT) AS VENDOR_NET_AMT,
	  SUM(d.BILL_AMT) AS BILL_AMT,
	  SUM(d.RECNB_BILL_AMT) AS RECNB_BILL_AMT, 
	  SUM(d.RECNB_NET_AMT) AS RECNB_NET_AMT,
	  SUM(d.SPOTS_QTY) AS SPOTS_QTY,	
	  NULL AS NON_BILL_FLAG,
	  NULL AS LINE_CANCELLED,
	  NULL AS BILL_TYPE_FLAG,
	  SUM(d.BILLED_EXT_NET_AMT) AS BILLED_EXT_NET_AMT, 
	  SUM(d.BILLED_DISC_AMT) AS BILLED_DISC_AMT,
	  SUM(d.BILLED_NC_AMT) AS BILLED_NC_AMT,
	  SUM(d.BILLED_VTAX_AMT) AS BILLED_VTAX_AMT,
	  SUM(d.BILLED_NET_AMT) AS BILLED_NET_AMT,
	  SUM(d.BILLED_ADDL_CHARGE) AS BILLED_ADDL_CHARGE,
	  SUM(d.BILLED_COMM_AMT) AS BILLED_COMM_AMT,
	  SUM(d.BILLED_REBATE_AMT) AS BILLED_REBATE_AMT,
	  SUM(d.BILLED_RTAX_AMT) AS BILLED_RTAX_AMT,
	  SUM(d.BILLED_BILL_AMT) AS BILLED_BILL_AMT,
	  SUM(d.BILLED_SPOTS_QTY) AS BILLED_SPOTS_QTY,		  
	  NULL AS AR_INV_NBR,
	  NULL AS AR_SEQ,
	  NULL AS AR_TYPE,
	  NULL AS GLXACT_BILL,
	  SUM(d.AP_NET_AMT) AS AP_NET_AMT,
	  SUM(d.AP_NETCHARGES_AMT) AS AP_NETCHARGES_AMT, 
	  SUM(d.AP_DISC_AMT_AMT) AS AP_DISC_AMT_AMT,
	  SUM(d.AP_COMM_AMT) AS AP_COMM_AMT,
	  SUM(d.AP_REBATE_AMT) AS AP_REBATE_AMT,
	  SUM(d.AP_VTAX_AMT) AS AP_VTAX_AMT,
	  SUM(d.AP_RTAX_AMT) AS AP_RTAX_AMT,
	  SUM(d.AP_BILL_AMT) AS AP_BILL_AMT,
	  SUM(d.AP_LINE_TOTAL) AS AP_LINE_TOTAL, 
	  SUM(d.AP_SPOTS_QTY) AS AP_SPOTS_QTY,			
	  NULL AS AP_INV_NBR,
	  NULL AS GLXACT_AP 
FROM  #media_order_amounts AS d
JOIN #media_order_detail AS dt
	ON d.ORDER_NBR = dt.ORDER_NBR
	AND d.LINE_NBR = dt.LINE_NBR
WHERE d.ORDER_TYPE NOT IN ('R', 'RN', 'R2', 'T', 'TN', 'T2')	
GROUP BY d.[USER_ID], d.ORDER_TYPE, d.ORDER_NBR, d.LINE_NBR, dt.INSERT_DATE

--For Broadcast media (no line number)
INSERT INTO #media_order_amounts_sum
SELECT 
	d.[USER_ID] AS [USER_ID],
	d.ORDER_TYPE AS ORDER_TYPE,
	d.ORDER_NBR AS ORDER_NBR,
	NULL,
	COALESCE(d.[MONTH], dt.[MONTH]) AS [MONTH],
	COALESCE(d.[YEAR], dt.[YEAR]) AS [YEAR],
	  SUM(d.EXT_NET_AMT) AS EXT_NET_AMT, 
	  SUM(d.NETCHARGES) AS NETCHARGES,
	  SUM(d.DISCOUNTS) AS DISCOUNTS,
	  SUM(d.ADDL_CHARGE) AS ADDL_CHARGE, 
	  SUM(d.COMM_AMT) AS COMM_AMT,
	  SUM(d.REBATE_AMT) AS REBATE_AMT,
	  SUM(d.VENDOR_TAX) AS VENDOR_TAX,
	  SUM(d.RESALE_TAX) AS RESALE_TAX,
	  SUM(d.LINE_TOTAL) AS LINE_TOTAL, 
	  SUM(d.NET_TOTAL_AMT) AS NET_TOTAL_AMT,
	  SUM(d.VENDOR_NET_AMT) AS VENDOR_NET_AMT,
	  SUM(d.BILL_AMT) AS BILL_AMT,
	  SUM(d.RECNB_BILL_AMT) AS RECNB_BILL_AMT, 
	  SUM(d.RECNB_NET_AMT) AS RECNB_NET_AMT,
	  SUM(d.SPOTS_QTY) AS SPOTS_QTY,	
	  NULL AS NON_BILL_FLAG,
	  NULL AS LINE_CANCELLED,
	  NULL AS BILL_TYPE_FLAG,
	  SUM(d.BILLED_EXT_NET_AMT) AS BILLED_EXT_NET_AMT, 
	  SUM(d.BILLED_DISC_AMT) AS BILLED_DISC_AMT,
	  SUM(d.BILLED_NC_AMT) AS BILLED_NC_AMT,
	  SUM(d.BILLED_VTAX_AMT) AS BILLED_VTAX_AMT,
	  SUM(d.BILLED_NET_AMT) AS BILLED_NET_AMT,
	  SUM(d.BILLED_ADDL_CHARGE) AS BILLED_ADDL_CHARGE,
	  SUM(d.BILLED_COMM_AMT) AS BILLED_COMM_AMT,
	  SUM(d.BILLED_REBATE_AMT) AS BILLED_REBATE_AMT,
	  SUM(d.BILLED_RTAX_AMT) AS BILLED_RTAX_AMT,
	  SUM(d.BILLED_BILL_AMT) AS BILLED_BILL_AMT,
	  SUM(d.BILLED_SPOTS_QTY) AS BILLED_SPOTS_QTY,		  
	  NULL AS AR_INV_NBR,
	  NULL AS AR_SEQ,
	  NULL AS AR_TYPE,
	  NULL AS GLXACT_BILL,
	  SUM(d.AP_NET_AMT) AS AP_NET_AMT,
	  SUM(d.AP_NETCHARGES_AMT) AS AP_NETCHARGES_AMT, 
	  SUM(d.AP_DISC_AMT_AMT) AS AP_DISC_AMT_AMT,
	  SUM(d.AP_COMM_AMT) AS AP_COMM_AMT,
	  SUM(d.AP_REBATE_AMT) AS AP_REBATE_AMT,
	  SUM(d.AP_VTAX_AMT) AS AP_VTAX_AMT,
	  SUM(d.AP_RTAX_AMT) AS AP_RTAX_AMT,
	  SUM(d.AP_BILL_AMT) AS AP_BILL_AMT,
	  SUM(d.AP_LINE_TOTAL) AS AP_LINE_TOTAL, 
	  SUM(d.AP_SPOTS_QTY) AS AP_SPOTS_QTY,			
	  NULL AS AP_INV_NBR,
	  NULL AS GLXACT_AP 
FROM  #media_order_amounts AS d
JOIN #media_order_detail AS dt
	ON d.ORDER_NBR = dt.ORDER_NBR
	AND d.LINE_NBR = dt.LINE_NBR
WHERE d.ORDER_TYPE IN ('R', 'RN', 'R2', 'T', 'TN', 'T2')	
GROUP BY d.[USER_ID], d.ORDER_TYPE, d.ORDER_NBR, d.[MONTH], d.[YEAR], dt.[MONTH], dt.[YEAR]

--For broadcast new media
INSERT INTO #media_order_amounts_sum
SELECT 
	  d.[USER_ID] AS [USER_ID],
	  d.ORDER_TYPE AS ORDER_TYPE,
	  d.ORDER_NBR AS ORDER_NBR,
	  d.LINE_NBR AS LINE_NBR,
	  MONTH(dt.INSERT_DATE) AS [MONTH],
	  YEAR(dt.INSERT_DATE) AS [YEAR],
	  SUM(d.EXT_NET_AMT) AS EXT_NET_AMT, 
	  SUM(d.NETCHARGES) AS NETCHARGES,
	  SUM(d.DISCOUNTS) AS DISCOUNTS,
	  SUM(d.ADDL_CHARGE) AS ADDL_CHARGE, 
	  SUM(d.COMM_AMT) AS COMM_AMT,
	  SUM(d.REBATE_AMT) AS REBATE_AMT,
	  SUM(d.VENDOR_TAX) AS VENDOR_TAX,
	  SUM(d.RESALE_TAX) AS RESALE_TAX,
	  SUM(d.LINE_TOTAL) AS LINE_TOTAL, 
	  SUM(d.NET_TOTAL_AMT) AS NET_TOTAL_AMT,
	  SUM(d.VENDOR_NET_AMT) AS VENDOR_NET_AMT,
	  SUM(d.BILL_AMT) AS BILL_AMT,
	  SUM(d.RECNB_BILL_AMT) AS RECNB_BILL_AMT, 
	  SUM(d.RECNB_NET_AMT) AS RECNB_NET_AMT,
	  SUM(d.SPOTS_QTY) AS SPOTS_QTY,	
	  NULL AS NON_BILL_FLAG,
	  NULL AS LINE_CANCELLED,
	  NULL AS BILL_TYPE_FLAG,
	  SUM(d.BILLED_EXT_NET_AMT) AS BILLED_EXT_NET_AMT, 
	  SUM(d.BILLED_DISC_AMT) AS BILLED_DISC_AMT,
	  SUM(d.BILLED_NC_AMT) AS BILLED_NC_AMT,
	  SUM(d.BILLED_VTAX_AMT) AS BILLED_VTAX_AMT,
	  SUM(d.BILLED_NET_AMT) AS BILLED_NET_AMT,
	  SUM(d.BILLED_ADDL_CHARGE) AS BILLED_ADDL_CHARGE,
	  SUM(d.BILLED_COMM_AMT) AS BILLED_COMM_AMT,
	  SUM(d.BILLED_REBATE_AMT) AS BILLED_REBATE_AMT,
	  SUM(d.BILLED_RTAX_AMT) AS BILLED_RTAX_AMT,
	  SUM(d.BILLED_BILL_AMT) AS BILLED_BILL_AMT,
	  SUM(d.BILLED_SPOTS_QTY) AS BILLED_SPOTS_QTY,		  
	  NULL AS AR_INV_NBR,
	  NULL AS AR_SEQ,
	  NULL AS AR_TYPE,
	  NULL AS GLXACT_BILL,
	  SUM(d.AP_NET_AMT) AS AP_NET_AMT,
	  SUM(d.AP_NETCHARGES_AMT) AS AP_NETCHARGES_AMT, 
	  SUM(d.AP_DISC_AMT_AMT) AS AP_DISC_AMT_AMT,
	  SUM(d.AP_COMM_AMT) AS AP_COMM_AMT,
	  SUM(d.AP_REBATE_AMT) AS AP_REBATE_AMT,
	  SUM(d.AP_VTAX_AMT) AS AP_VTAX_AMT,
	  SUM(d.AP_RTAX_AMT) AS AP_RTAX_AMT,
	  SUM(d.AP_BILL_AMT) AS AP_BILL_AMT,
	  SUM(d.AP_LINE_TOTAL) AS AP_LINE_TOTAL, 
	  SUM(d.AP_SPOTS_QTY) AS AP_SPOTS_QTY,			
	  NULL AS AP_INV_NBR,
	  NULL AS GLXACT_AP 
FROM  #media_order_amounts AS d
JOIN #media_order_detail AS dt
	ON d.ORDER_NBR = dt.ORDER_NBR
	AND d.LINE_NBR = dt.LINE_NBR
WHERE d.ORDER_TYPE IN ('R', 'RN', 'R2', 'T', 'TN', 'T2')	
GROUP BY d.[USER_ID], d.ORDER_TYPE, d.ORDER_NBR, d.LINE_NBR, dt.INSERT_DATE

-- ==========================================================
-- SECTION F - LINK TEMP TABLES AND OTHER TABLES FOR COMPOSITE DATASET
-- SEE ADRPTS MACRO "MedRpts OrderDetail"
-- ==========================================================

-- V_MEDIA_CURRENT_STATUS
-- #00 08/20/12 - initial version
-- #01 10/19/12 - revised REC_TYPE and added BILLED_TYPE_FLAG per jr request
-- #02 10/24/12 - added separate SELECT statement for AP records for old bcst (was dropping records)
-- #03 12/04/12 - changed field names as requested
-- #04 12/06/12 - changed (2) column labels
-- #05 02/20/13 - added separate columns for ordered/billed/AP spots_quantity
-- #06 04/11/13 - fixed join to vendor rep tables in 2nd query - was missing link to VN_CODE

--For all entries except AP entries for old bcst (where LINE_NBR does not exist)
INSERT INTO #media_current_status_sum
SELECT
	  mh.[USER_ID] AS [User Code],
	  mh.[TYPE] AS [Order Type], 
	  mh.ORDER_NBR AS [Order Number], 
	  mh.REV_NBR AS [Revision Number], 
	  mh.OFFICE_CODE AS [Office Code],
	  dbo.OFFICE.OFFICE_NAME AS [Office Name],
	  mh.CL_CODE AS [Client Code], 
	  dbo.CLIENT.CL_NAME AS [Client Name],
	  mh.DIV_CODE AS [Division Code],
	  dbo.DIVISION.DIV_NAME AS [Division Name], 
	  mh.PRD_CODE AS [Product Code],
	  dbo.PRODUCT.PRD_DESCRIPTION AS [Product Description],  
	  mh.ORDER_DESC AS [Order Description], 
	  mh.ORDER_COMMENT AS [Order Comment], 
	  mh.VN_CODE AS [Vendor Code],
	  dbo.VENDOR.VN_NAME AS [Vendor Name], 
	  mh.VR_CODE AS [Vendor Rep Code], 
	  ISNULL(dbo.VEN_REP.VR_FNAME,'') + ' ' + ISNULL(dbo.VEN_REP.VR_LNAME,'') AS [Vendor Rep Name],
	  mh.VR_CODE2 AS [Vendor Rep Code2],
	  ISNULL(vr2.VR_FNAME,'') + ' ' + ISNULL(vr2.VR_LNAME,'') AS [Vendor Rep Name2], 
	  mh.CMP_CODE AS [Campaign Code], 
	  mh.CMP_IDENTIFIER AS [Campaign ID], 
	  mh.CMP_NAME AS [Campaign Name], 
	  mh.MEDIA_TYPE AS [Media Type], 
	  SC.SC_DESCRIPTION AS [Media Type Description], 
	  mh.POST_BILL AS [Post Bill Flag], 
	  mh.NET_GROSS AS [Net Gross Flag], 
	  mh.MARKET_CODE AS [Market Code], 
	  mh.MARKET_DESC AS [Market Description], 
	  mh.ORDER_DATE AS [Order Date], 
	  mh.FLIGHT_FROM AS [Order Flight From], 
	  mh.FLIGHT_TO AS [Order Flight To],
	  mh.ORD_PROCESS_CONTRL AS [Order Process Control], 
	  mh.BUYER AS [Buyer], 
	  mh.CLIENT_PO AS [Client PO], 
	  mh.LINK_ID AS [Link ID], 
	  mh.ORDER_ACCEPTED AS [Order Accepted], 
	  CASE mh.ADVAN_TYPE
		WHEN 1 THEN 0
		ELSE md.LINE_NBR
	  END AS [Line Number], 
	  md.REV_NBR AS [Line Revision Number],
	  md.SEQ_NBR AS [Line Sequence Number], 
	  md.DATE_TYPE AS [Order Date Type],
	  COALESCE(md.[YEAR],ma.[YEAR]) * 100 +
			COALESCE(md.[MONTH],ma.[MONTH])AS [Order Period], 
	  CASE COALESCE(md.[MONTH],ma.[MONTH])
			WHEN 1 THEN 'Jan'
			WHEN 2 THEN 'Feb'
			WHEN 3 THEN 'Mar'
			WHEN 4 THEN 'Apr'
			WHEN 5 THEN 'May'
			WHEN 6 THEN 'Jun'
			WHEN 7 THEN 'Jul'
			WHEN 8 THEN 'Aug'
			WHEN 9 THEN 'Sep'
			WHEN 10 THEN 'Oct'
			WHEN 11 THEN 'Nov'
			WHEN 12 THEN 'Dec'	  
	  END AS [Order Month], 
	  COALESCE(md.[YEAR],ma.[YEAR]) AS [Order year], 
	  md.INSERT_DATE [Insertion Date], 
	  md.END_DATE AS [Order End Date], 
	  md.DATE_TO_BILL AS [Date To Bill], 
	  md.CLOSE_DATE AS [Close Date], 
	  md.MATL_CLOSE_DATE AS [Material Close Date], 
	  md.LINE_DESC AS [Line Description], 
	  md.AD_SIZE AS [Ad Size], 
	  md.EDITION_ISSUE AS [Edition Issue], 
	  md.SECTION AS [Section], 
	  md.MATERIAL AS [Material], 
	  md.REMARKS AS [Remarks], 
	  md.URL AS [URL], 
	  md.COPY_AREA AS [Copy Area], 
	  md.MATL_NOTES AS [Material Notes], 
	  md.POSITION_INFO AS [Position Info], 
	  md.MISC_INFO AS [Miscellaneous Info], 
	  md.JOB_NUMBER AS [Job Number], 
	  dbo.JOB_LOG.JOB_DESC AS [Job Description],
	  md.JOB_COMPONENT_NBR AS [Job Component Number], 
	  dbo.JOB_COMPONENT.JOB_COMP_DESC AS [Job Component Description],
	  md.COST_TYPE AS [Cost Type], 
	  md.RATE_TYPE AS [Rate Type], 
	  md.PRINT_LINES AS [Print Quantity], 
	  md.GUARANTEED_IMPRESS AS [Guaranteed Impressions],
	  md.LINK_ID AS [Line Link ID], 
	  ma.ORDER_TYPE AS [Order Entry Type],
	 -- CASE ma.REC_TYPE
		--WHEN 'O' THEN 'ORDER'
		--WHEN 'B' THEN 'BILLING'
		--WHEN 'A' THEN 'AP'
	 -- END AS [Record Type],
	  ma.EXT_NET_AMT AS [Extended Net Amount], 
	  ma.NETCHARGES AS [Net Charge Amount], 
	  ma.DISCOUNTS AS [Discount Amount], 
	  ma.ADDL_CHARGE AS [Additional Charge Amount], 
	  ma.COMM_AMT AS [Commission Amount], 
	  ma.REBATE_AMT AS [Rebate Amount], 
	  ma.VENDOR_TAX AS [Vendor Tax Amount], 
	  ma.RESALE_TAX AS [Resale Tax Amount], 
	  ma.LINE_TOTAL AS [Line Total Amount], 
	  ma.NET_TOTAL_AMT AS [Net Total Amount], 
	  ma.VENDOR_NET_AMT AS [Vendor Net Amount],
	  ma.BILL_AMT AS [Bill Amount], 
	  ma.RECNB_BILL_AMT AS [Reconcile No_Bill Bill Amount], 
	  ma.RECNB_NET_AMT AS [Reconcile No_BILL Net Amount], 
	  ma.SPOTS_QTY AS [Spots Quantity],				--#05
	  --ma.NON_BILL_FLAG AS [Non_billable Flag], 
	  --ma.LINE_CANCELLED AS [Line Cancelled], 
	  --ma.BILL_TYPE_FLAG AS [Bill Type Flag],
	  ma.BILLED_EXT_NET_AMT AS [Billed Extended Net Amount], 
	  ma.BILLED_DISC_AMT AS [Billed Discount Amount], 
	  ma.BILLED_NC_AMT AS [Billed Net Charge Amount], 
	  ma.BILLED_VTAX_AMT AS [Billed Vendor Tax Amount], 
	  ma.BILLED_NET_AMT AS [Billed Net Amount], 
	  ma.BILLED_ADDL_CHARGE AS [Billed Additional Charge Amount], 
	  ma.BILLED_COMM_AMT AS [Billed Commission Amount], 
	  ma.BILLED_REBATE_AMT AS [Billed Rebate Amount], 
	  ma.BILLED_RTAX_AMT AS [Billed Resale Tax Amount], 
	  ma.BILLED_BILL_AMT AS [Billed Bill Amount],
	  ma.BILLED_SPOTS_QTY AS [Billed Spots Quantity],0,		--#05
	  --ma.AR_INV_NBR AS [Invoice Number], 
	  --ma.AR_SEQ AS [Invoice Sequence Number], 
	  --ma.AR_TYPE AS [Invoice Type], 
	  --ma.GLXACT_BILL AS [GL Billing Trans Number],				--#04
	  ma.AP_NET_AMT AS [AP Net Amount], 
	  ma.AP_NETCHARGES_AMT AS [AP Net Charge Amount], 
	  ma.AP_DISC_AMT_AMT AS [AP Discount Amount], 
	  ma.AP_COMM_AMT AS [AP Commission Amount], 
	  ma.AP_REBATE_AMT AS [AP Rebate Amount], 
	  ma.AP_VTAX_AMT AS [AP Vendor Tax Amount], 
	  ma.AP_RTAX_AMT AS [AP Resale Tax Amount], 
	  ma.AP_BILL_AMT AS [AP Bill Amount], 
	  ma.AP_LINE_TOTAL AS [AP Line Total],
	  ma.AP_SPOTS_QTY AS [AP Spots Quantity],			--#05
	  --ma.AP_INV_NBR AS [AP Invoice Number], 
	  --ma.GLXACT_AP AS [AP GL Trans Number]			--#04
	  mh.FISCAL_PERIOD_CODE
FROM  #media_order_header AS mh 
INNER JOIN #media_order_detail AS md 
	ON mh.ORDER_NBR = md.ORDER_NBR
INNER JOIN #media_order_amounts_sum AS ma 
	ON md.ORDER_NBR = ma.ORDER_NBR 
	AND md.LINE_NBR = ma.LINE_NBR
JOIN dbo.OFFICE
	ON mh.OFFICE_CODE = dbo.OFFICE.OFFICE_CODE
INNER JOIN dbo.CLIENT
	ON mh.CL_CODE = dbo.CLIENT.CL_CODE	
INNER JOIN dbo.DIVISION
	ON mh.CL_CODE = dbo.DIVISION.CL_CODE	
	AND mh.DIV_CODE = dbo.DIVISION.DIV_CODE
INNER JOIN dbo.PRODUCT
	ON mh.CL_CODE = dbo.PRODUCT.CL_CODE	
	AND mh.DIV_CODE = dbo.PRODUCT.DIV_CODE
	AND mh.PRD_CODE = dbo.PRODUCT.PRD_CODE
INNER JOIN dbo.VENDOR
	ON mh.VN_CODE = dbo.VENDOR.VN_CODE
LEFT JOIN dbo.VEN_REP
	ON mh.VN_CODE = dbo.VEN_REP.VN_CODE
	AND mh.VR_CODE = dbo.VEN_REP.VR_CODE
LEFT JOIN dbo.VEN_REP AS vr2
	ON mh.VN_CODE = vr2.VN_CODE
	AND mh.VR_CODE = vr2.VR_CODE	
LEFT JOIN dbo.JOB_LOG
	ON md.JOB_NUMBER = dbo.JOB_LOG.JOB_NUMBER
LEFT JOIN dbo.JOB_COMPONENT
	ON md.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER
	AND md.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR  LEFT OUTER JOIN 
	dbo.SALES_CLASS AS SC ON SC.SC_CODE = mh.MEDIA_TYPE
WHERE 
	(mh.ADVAN_TYPE = 2 OR 
	 (mh.ADVAN_TYPE = 1 AND 
	  mh.[TYPE] NOT IN ('RADIO', 'TV'))) --AND
   --1 = CASE WHEN mh.ADVAN_TYPE = 2 AND md.DATE_TYPE = 'BRD' OR mh.ADVAN_TYPE = 1 THEN CASE WHEN ((md.[YEAR] > @start_year) OR (md.[YEAR] = @start_year AND md.[MONTH] >= @start_month)) AND 
			--																					((md.[YEAR] < @end_year) OR (md.[YEAR] = @end_year AND md.[MONTH] <= @end_month)) THEN 1 
			--																			   ELSE 0 END  
			--ELSE CASE WHEN md.INSERT_DATE >= @start_date AND md.INSERT_DATE <= @end_date THEN 1 ELSE 0 END END
	
--For all AP entries or old bcst where LINE_NBR does not exist (see WHERE clause)
INSERT INTO #media_current_status_sum
SELECT
	  mh.[USER_ID],
	  mh.[TYPE], 
	  mh.ORDER_NBR, 
	  mh.REV_NBR, 
	  mh.OFFICE_CODE, 
	  dbo.OFFICE.OFFICE_NAME, 
	  mh.CL_CODE,  
	  dbo.CLIENT.CL_NAME,
	  mh.DIV_CODE, 
	  dbo.DIVISION.DIV_NAME,
	  mh.PRD_CODE,
	  dbo.PRODUCT.PRD_DESCRIPTION,  
	  mh.ORDER_DESC, 
	  mh.ORDER_COMMENT, 
	  mh.VN_CODE,
	  dbo.VENDOR.VN_NAME, 
	  mh.VR_CODE, 
	  ISNULL(dbo.VEN_REP.VR_FNAME,'') + ' ' + ISNULL(dbo.VEN_REP.VR_LNAME,''), 
	  mh.VR_CODE2, 
	  ISNULL(vr2.VR_FNAME,'') + ' ' + ISNULL(vr2.VR_LNAME,''),
	  mh.CMP_CODE, 
	  mh.CMP_IDENTIFIER, 
	  mh.CMP_NAME, 
	  mh.MEDIA_TYPE, 
	  SC.SC_DESCRIPTION AS [Media Type Description], 
	  mh.POST_BILL, 
	  mh.NET_GROSS, 
	  mh.MARKET_CODE, 
	  mh.MARKET_DESC, 
	  mh.ORDER_DATE, 
	  mh.FLIGHT_FROM, 
	  mh.FLIGHT_TO, 
	  mh.ORD_PROCESS_CONTRL, 
	  mh.BUYER, 
	  mh.CLIENT_PO, 
	  mh.LINK_ID, 
	  mh.ORDER_ACCEPTED, 
	  0,		--md.LINE_NBR, 
	  0,		--md.REV_NBR AS LINE_REV_NBR,
	  0,		--md.SEQ_NBR, 
	  'BRD',	--md.DATE_TYPE,
	  ma.[YEAR] * 100 + ma.[MONTH], 
	  CASE ma.[MONTH]
			WHEN 1 THEN 'Jan'
			WHEN 2 THEN 'Feb'
			WHEN 3 THEN 'Mar'
			WHEN 4 THEN 'Apr'
			WHEN 5 THEN 'May'
			WHEN 6 THEN 'Jun'
			WHEN 7 THEN 'Jul'
			WHEN 8 THEN 'Aug'
			WHEN 9 THEN 'Sep'
			WHEN 10 THEN 'Oct'
			WHEN 11 THEN 'Nov'
			WHEN 12 THEN 'Dec'	  
	  END, 
	  ma.[YEAR], 
	  NULL,   --md.INSERT_DATE, 
	  NULL,   --md.END_DATE, 
	  NULL,   --md.DATE_TO_BILL, 
	  NULL,   --md.CLOSE_DATE, 
	  NULL,   --md.MATL_CLOSE_DATE, 
	  NULL,   --md.LINE_DESC, 
	  NULL,   --md.AD_SIZE, 
	  NULL,   --md.EDITION_ISSUE, 
	  NULL,   --md.SECTION, 
	  NULL,   --md.MATERIAL, 
	  NULL,   --md.REMARKS, 
	  NULL,   --md.URL, 
	  NULL,   --md.COPY_AREA, 
	  NULL,   --md.MATL_NOTES, 
	  NULL,   --md.POSITION_INFO, 
	  NULL,   --md.MISC_INFO, 
	  NULL,   --md.JOB_NUMBER,
	  NULL,   --dbo.JOB_LOG.JOB_DESC, 
	  NULL,   --md.JOB_COMPONENT_NBR, 
	  NULL,   --dbo.JOB_COMPONENT.JOB_COMP_DESC,
	  NULL,   --md.COST_TYPE, 
	  NULL,   --md.RATE_TYPE, 
	  NULL,   --md.PRINT_LINES, 
	  NULL,   --md.GUARANTEED_IMPRESS, 
	  NULL,   --md.LINK_ID AS LINE_LINK_ID, 
	  ma.ORDER_TYPE,
	 -- CASE ma.REC_TYPE
		--WHEN 'O' THEN 'ORDER'
		--WHEN 'B' THEN 'BILLING'
		--WHEN 'A' THEN 'AP'
	 -- END AS REC_TYPE,
	  ma.EXT_NET_AMT, 
	  ma.NETCHARGES, 
	  ma.DISCOUNTS, 
	  ma.ADDL_CHARGE, 
	  ma.COMM_AMT, 
	  ma.REBATE_AMT, 
	  ma.VENDOR_TAX, 
	  ma.RESALE_TAX, 
	  ma.LINE_TOTAL, 
	  ma.NET_TOTAL_AMT, 
	  ma.VENDOR_NET_AMT, 
	  ma.BILL_AMT, 
	  ma.RECNB_BILL_AMT, 
	  ma.RECNB_NET_AMT,
	  ma.SPOTS_QTY,				--#05
	  --ma.NON_BILL_FLAG, 
	  --ma.LINE_CANCELLED, 
	  --ma.BILL_TYPE_FLAG, 
	  ma.BILLED_EXT_NET_AMT, 
	  ma.BILLED_DISC_AMT, 
	  ma.BILLED_NC_AMT, 
	  ma.BILLED_VTAX_AMT, 
	  ma.BILLED_NET_AMT, 
	  ma.BILLED_ADDL_CHARGE, 
	  ma.BILLED_COMM_AMT, 
	  ma.BILLED_REBATE_AMT, 
	  ma.BILLED_RTAX_AMT, 
	  ma.BILLED_BILL_AMT,
	  ma.BILLED_SPOTS_QTY,0,			--#05  
	  --ma.AR_INV_NBR, 
	  --ma.AR_SEQ, 
	  --ma.AR_TYPE, 
	  --ma.GLXACT_BILL, 
	  ma.AP_NET_AMT, 
	  ma.AP_NETCHARGES_AMT, 
	  ma.AP_DISC_AMT_AMT, 
	  ma.AP_COMM_AMT, 
	  ma.AP_REBATE_AMT, 
	  ma.AP_VTAX_AMT, 
	  ma.AP_RTAX_AMT, 
	  ma.AP_BILL_AMT, 
	  ma.AP_LINE_TOTAL,	  
	  ma.AP_SPOTS_QTY,				--#05  
	  --ma.AP_INV_NBR,
	  --ma.GLXACT_AP
	  mh.FISCAL_PERIOD_CODE	  
FROM  #media_order_header AS mh 
INNER JOIN #media_order_amounts_sum AS ma 
	--ON mh.[USER_ID] = ma.[USER_ID]
	--AND mh.ORDER_NBR = ma.ORDER_NBR 
	ON mh.ORDER_NBR = ma.ORDER_NBR
JOIN dbo.OFFICE
	ON mh.OFFICE_CODE = dbo.OFFICE.OFFICE_CODE
INNER JOIN dbo.CLIENT
	ON mh.CL_CODE = dbo.CLIENT.CL_CODE	
INNER JOIN dbo.DIVISION
	ON mh.CL_CODE = dbo.DIVISION.CL_CODE	
	AND mh.DIV_CODE = dbo.DIVISION.DIV_CODE
INNER JOIN dbo.PRODUCT
	ON mh.CL_CODE = dbo.PRODUCT.CL_CODE	
	AND mh.DIV_CODE = dbo.PRODUCT.DIV_CODE
	AND mh.PRD_CODE = dbo.PRODUCT.PRD_CODE
INNER JOIN dbo.VENDOR
	ON mh.VN_CODE = dbo.VENDOR.VN_CODE
LEFT JOIN dbo.VEN_REP
	ON mh.VN_CODE = dbo.VEN_REP.VN_CODE
	AND mh.VR_CODE = dbo.VEN_REP.VR_CODE
LEFT JOIN dbo.VEN_REP AS vr2
	ON mh.VN_CODE = vr2.VN_CODE
	AND mh.VR_CODE = vr2.VR_CODE  LEFT OUTER JOIN 
	dbo.SALES_CLASS AS SC ON SC.SC_CODE = mh.MEDIA_TYPE	
--LEFT JOIN dbo.JOB_LOG
--	ON md.JOB_NUMBER = dbo.JOB_LOG.JOB_NUMBER
--LEFT JOIN dbo.JOB_COMPONENT
--	 ON md.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER
--	AND md.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR
WHERE  mh.ADVAN_TYPE = 1	
	AND mh.[TYPE] IN('RADIO', 'TV')	
	--((ma.[YEAR] > @start_year) OR (ma.[YEAR] = @start_year AND ma.[MONTH] >= @start_month)) AND 
 --((ma.[YEAR] < @end_year) OR (ma.[YEAR] = @end_year AND ma.[MONTH] <= @end_month))
	--AND

UPDATE #media_current_status_sum
SET [Billed Cost Amount] = (SELECT SUM(ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0)) FROM AR_SUMMARY AR WHERE #media_current_status_sum.[Order Number] = AR.ORDER_NBR AND #media_current_status_sum.[Line Number] = AR.ORDER_LINE_NBR)

--SELECT * FROM #media_current_status_sum WHERE [Order Number] = 1003 AND [Order Month] = 'Jan'

--SELECT * FROM #JOB_DETAIL

INSERT INTO #CAMP
SELECT	
	[OfficeCode] = MCS.[Office Code], 
	[OfficeName] = MCS.[Office Name], 
	[ClientCode] = MCS.[Client Code], 
	[ClientName] = MCS.[Client Name], 
	NULL,
	NULL,
	[DivisionCode] = MCS.[Division Code], 
	[DivisionName] = MCS.[Division Name], 
	NULL,
	NULL,
	[ProductCode] = MCS.[Product Code], 
	[ProductDescription] = MCS.[Product Description], 
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	[CampaignID] = MCS.[Campaign ID], 
	[CampaignCode] = MCS.[Campaign Code], 
	[CampaignName] = MCS.[Campaign Name], 
	NULL,
	NULL,
	[MarketCode] = MCS.[Market Code], 
	[MarketDescription] = MCS.[Market Description], 
	[FiscalPeriodCode] = MCS.[FiscalPeriodCode],
	NULL,
	[SalesClassCode] = MCS.[Media Type],
	[SalesClassDescription] = MCS.[Media Type Description],
	NULL,--[JobNumber] = MCS.[Job Number], 
	NULL,--[JobComponentNumber] = MCS.[Job Component Number], 
	NULL,
	NULL,--[JobDescription] = MCS.[Job Description], 
	NULL,--[JobComponentDescription] = MCS.[Job Component Description], 
	[OrderNumber] = MCS.[Order Number], 
	[OrderDescription] = MCS.[Order Description], 
	[ClientPO] = MCS.[Client PO], 
	NULL,
	[NetAmount] = MCS.[Net Total Amount], 
	[CommissionAmount] = MCS.[Commission Amount] + MCS.[Billed Rebate Amount], 
	[BillingAmountLessResale] = MCS.[Bill Amount] - MCS.[Resale Tax Amount], 
	[BilledAmountLessResale] = MCS.[Billed Bill Amount] - MCS.[Billed Resale Tax Amount], 
	[BilledAmount] = MCS.[Billed Bill Amount],
	[BilledCost] = MCS.[Billed Cost Amount],
	[BilledIncome] = MCS.[Billed Commission Amount] + MCS.[Billed Rebate Amount] + MCS.[Billed Additional Charge Amount],
	[UnbilledAmountLessResale] = (MCS.[Bill Amount] - MCS.[Resale Tax Amount]) - (MCS.[Billed Bill Amount] - MCS.[Billed Resale Tax Amount]),
	[UnbilledAmount] = MCS.[Bill Amount] - MCS.[Billed Bill Amount],
	[ResaleTax] = MCS.[Billed Resale Tax Amount],
	[Total] = MCS.[Bill Amount],
	[TotalLessResale] = MCS.[Bill Amount] - MCS.[Resale Tax Amount],
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	'M',
	[PostPeriodCode] = MCS.[Order Period],
	[Year] = MCS.[Order year],
	[Month] = MCS.[Order Month],
	NULL,
	NULL,
	NULL	
FROM 
	#media_current_status_sum AS MCS
WHERE MCS.[Campaign ID] IS NOT NULL AND MCS.[Campaign ID] IN (SELECT * FROM dbo.udf_split_list(@CMPID_LIST, ',')) 

--SELECT * FROM #CAMP

UPDATE #CAMP
SET [ClientCity] = CL_BCITY,
	[ClientState] = CL_BSTATE
FROM CLIENT 
WHERE CLIENT.CL_CODE = #CAMP.ClientCode --AND #CAMP.ClientCode IS NULL

UPDATE #CAMP
SET [DivisionCity] = DIV_BCITY,
	[DivisionState] = DIV_BSTATE
FROM DIVISION 
WHERE DIVISION.DIV_CODE = #CAMP.DivisionCode AND DIVISION.CL_CODE = #CAMP.ClientCode --AND #CAMP.DivisionCode IS NULL

UPDATE #CAMP
SET [ProductCity] = PRD_BILL_CITY,
	[ProductState] = PRD_BILL_STATE,
	[ProductUDF1] = USER_DEFINED1,
	[ProductUDF2] = USER_DEFINED2,
	[ProductUDF3] = USER_DEFINED3,
	[ProductUDF4] = USER_DEFINED4
FROM PRODUCT 
WHERE PRODUCT.PRD_CODE = #CAMP.ProductCode AND PRODUCT.CL_CODE = #CAMP.ClientCode AND PRODUCT.DIV_CODE = #CAMP.DivisionCode --AND #CAMP.ProductCode IS NULL

UPDATE #CAMP
SET [AccountExecutiveCode] = JC.EMP_CODE,
	[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
	[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
	[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
	[SalesClassCode] = J.SC_CODE,
	[SalesClassDescription] = SC.SC_DESCRIPTION,
	[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
	[JobCreatedDate] = J.CREATE_DATE,
	[JobDueDate] = JC.JOB_FIRST_USE_DATE,
	[JobStartDate] = JC.[START_DATE]
FROM JOB_COMPONENT JC INNER JOIN
	 JOB_LOG AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
	 EMPLOYEE_CLOAK AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
	 FISCAL_PERIOD AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
	 SALES_CLASS AS SC ON SC.SC_CODE = J.SC_CODE
WHERE JC.JOB_COMPONENT_NBR = #CAMP.JobComponentNumber AND JC.JOB_NUMBER = #CAMP.JobNumber-- AND #CAMP.AccountExecutiveCode IS NULL

UPDATE #CAMP
SET [AccountExecutiveCode] = AE.EMP_CODE,
	[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'')	
FROM ACCOUNT_EXECUTIVE AE INNER JOIN
	 EMPLOYEE_CLOAK AS EMP ON EMP.EMP_CODE = AE.EMP_CODE
WHERE AE.CL_CODE = #CAMP.ClientCode AND AE.DIV_CODE = #CAMP.DivisionCode AND AE.PRD_CODE = #CAMP.ProductCode AND #CAMP.AccountExecutiveCode IS NULL AND AE.DEFAULT_AE = 1 AND (AE.INACTIVE_FLAG IS NULL OR AE.INACTIVE_FLAG = 0)

UPDATE #CAMP
SET [PostPeriodCode] = (SELECT TOP 1 SALE_POST_PERIOD FROM AR_SUMMARY AR WHERE AR.ORDER_NBR = #CAMP.OrderNumber)
WHERE [Type] = 'M'

UPDATE #CAMP
SET [PostPeriodCode] = (SELECT TOP 1 SALE_POST_PERIOD FROM AR_SUMMARY AR WHERE AR.JOB_NUMBER = #CAMP.JobNumber AND AR.JOB_COMPONENT_NBR = #CAMP.JobComponentNumber ORDER BY AR_INV_NBR DESC)
WHERE [Type] = 'P'

UPDATE #CAMP
SET [FiscalPeriodDescription] = FISCAL_PERIOD_DESC
FROM FISCAL_PERIOD
WHERE FISCAL_PERIOD.FISCAL_PERIOD_CODE = #CAMP.FiscalPeriodCode

if @UseCampaignMasterJob = 1
BEGIN
	UPDATE #CAMP
	SET CampaignID = (SELECT CMP_IDENTIFIER FROM CAMPAIGN WHERE CAMPAIGN.JOB_NUMBER = #CAMP.JobNumber AND CAMPAIGN.JOB_COMPONENT_NBR = #CAMP.JobComponentNumber)
	WHERE CampaignID IS NULL

	UPDATE #CAMP
	SET CampaignCode = (SELECT CMP_CODE FROM CAMPAIGN WHERE CAMPAIGN.JOB_NUMBER = #CAMP.JobNumber AND CAMPAIGN.JOB_COMPONENT_NBR = #CAMP.JobComponentNumber)
	WHERE CampaignCode IS NULL

	UPDATE #CAMP
	SET CampaignName = (SELECT CMP_NAME FROM CAMPAIGN WHERE CAMPAIGN.JOB_NUMBER = #CAMP.JobNumber AND CAMPAIGN.JOB_COMPONENT_NBR = #CAMP.JobComponentNumber)
	WHERE CampaignName IS NULL
END



--SELECT * FROM #CAMP

INSERT INTO #CAMP_TOTAL
SELECT [OfficeCode],
		[OfficeDescription],
		[ClientCode],
		[ClientDescription],
		[ClientCity],
		[ClientState],
		[DivisionCode],
		[DivisionDescription],
		[DivisionCity],
		[DivisionState],
		[ProductCode],
		[ProductDescription],	
		[ProductCity],
		[ProductState],
		[ProductUDF1],
		[ProductUDF2],
		[ProductUDF3],
		[ProductUDF4],
		[AccountExecutiveCode],
		[AccountExecutive],
		[CampaignID],
		[CampaignCode],
		[CampaignName],
		SUM(ISNULL([BillingBudget],0)) AS [BillingBudget], 
		SUM(ISNULL([IncomeBudget],0)) AS [IncomeBudget],
		[MarketCode],
		[MarketDescription],
		[FiscalPeriodCode],
		[FiscalPeriodDescription],
		[SalesClassCode],
		[SalesClassDescription],
		[JobNumber],
		[JobComponentNumber],
		[JobComponent],
		[JobDescription],	
		[ComponentDescription],
		[OrderNumber],	
		[OrderDescription], 
		[ClientPO],
		SUM(ISNULL([Hours],0)) AS [Hours],
		--0,0,0,0,0,0,0,0,0,0,0,0,
		SUM(ISNULL([NetAmount],0)) AS [NetAmount],
		SUM(ISNULL([Commission],0)) AS [Commission],
		SUM(ISNULL([BillingAmountLessResale],0)) AS [BillingAmountLessResale],
		SUM(ISNULL([BilledAmountLessResale],0)) AS [BilledAmountLessResale],	
		SUM(ISNULL([BilledAmount],0)) AS [BilledAmount],	
		SUM(ISNULL([BilledCost],0)) AS [BilledCost],	
		SUM(ISNULL([BilledIncome],0)) AS [BilledIncome],	
		SUM(ISNULL([UnbilledAmountLessResale],0)) AS [UnbilledAmountLessResale],
		SUM(ISNULL([UnbilledAmount],0)) AS [UnbilledAmount],
		SUM(ISNULL([ResaleTaxAmount],0)) AS [ResaleTaxAmount],
		SUM(ISNULL([Total],0)) AS [Total],
		SUM(ISNULL([TotalLessResale],0)) AS [TotalLessResale],
		SUM(ISNULL([ClientBudgetBillingAmount],0)) AS [ClientBudgetBillingAmount], 
		SUM(ISNULL([ClientBudgetIncomeAmount],0)) AS [ClientBudgetIncomeAmount],
		SUM(ISNULL([EstimateHours],0)) AS [EstimateHours],
		SUM(ISNULL([EstimateQuantity],0)) AS [EstimateQuantity],
		SUM(ISNULL([EstimateTotalAmount],0)) AS [EstimateTotalAmount],
		SUM(ISNULL([EstimateContTotalAmount],0)) AS [EstimateContTotalAmount],
		SUM(ISNULL([EstimateNonResaleTaxAmount],0)) AS [EstimateNonResaleTaxAmount],
		SUM(ISNULL([EstimateResaleTaxAmount],0)) AS [EstimateResaleTaxAmount],
		SUM(ISNULL([EstimateMarkupAmount],0)) AS [EstimateMarkupAmount],
		SUM(ISNULL([EstimateCostAmount],0)) AS [EstimateCostAmount],
		SUM(ISNULL([EstimateNetAmount],0)) AS [EstimateNetAmount],0,0,0,0,0,0,0,0,0,
		[Type], 
		[PostPeriodCode],
		[Year],
		[Month],
		[JobCreatedDate],
		[JobStartDate],
		[JobDueDate]
FROM #CAMP
GROUP BY [CampaignID],
		[CampaignCode],
		[CampaignName], 
		[Type], 
		[OfficeCode],
		[OfficeDescription],
		[ClientCode],
		[ClientDescription],
		[ClientCity],
		[ClientState],
		[DivisionCode],
		[DivisionDescription],
		[DivisionCity],
		[DivisionState],
		[ProductCode],
		[ProductDescription],	
		[ProductCity],
		[ProductState],
		[ProductUDF1],
		[ProductUDF2],
		[ProductUDF3],
		[ProductUDF4],
		[AccountExecutiveCode],
		[AccountExecutive],
		[MarketCode],
		[MarketDescription],
		[FiscalPeriodCode],
		[FiscalPeriodDescription],
		[SalesClassCode],
		[SalesClassDescription],
		[JobNumber],
		[JobComponentNumber],
		[JobComponent],
		[JobDescription],	
		[ComponentDescription],
		[OrderNumber],	
		[OrderDescription], 
		[ClientPO],
		[PostPeriodCode],
		[Year],
		[Month],
		[JobCreatedDate],
		[JobStartDate],
		[JobDueDate]

UPDATE #CAMP_TOTAL
SET [ClientBudgetBillingAmount] = (SELECT ISNULL(SUM(BUDGET_VALUE),0)
		FROM BUDGET B INNER JOIN
		 V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR
		WHERE B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL AND CATEGORY_CODE <> 'S' AND BUDGET_VALUE > 0
			AND BD.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS)
			AND #CAMP_TOTAL.ClientCode = BD.CL_CODE AND #CAMP_TOTAL.DivisionCode = BD.DIV_CODE AND #CAMP_TOTAL.ProductCode = BD.PRD_CODE
			AND CATEGORY_CODE IN ('fee','lab','com','cos')),
	[ClientBudgetIncomeAmount] = (SELECT ISNULL(SUM(BUDGET_VALUE),0) 	  
		FROM BUDGET B INNER JOIN
		 V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR
		WHERE B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL AND CATEGORY_CODE <> 'S' AND BUDGET_VALUE > 0
			AND BD.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS)
			AND #CAMP_TOTAL.ClientCode = BD.CL_CODE AND #CAMP_TOTAL.DivisionCode = BD.DIV_CODE AND #CAMP_TOTAL.ProductCode = BD.PRD_CODE
			AND CATEGORY_CODE IN ('fee','lab','com'))

UPDATE #CAMP_TOTAL
SET [CampaignEstimateHours] = (SELECT ISNULL(SUM(EstimateHours),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),
    [CampaignEstimateQuantity] = (SELECT ISNULL(SUM(EstimateQuantity),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),
	[CampaignEstimateTotalAmount] = (SELECT ISNULL(SUM(EstimateTotalAmount),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),	
	[CampaignEstimateContTotalAmount] = (SELECT ISNULL(SUM(EstimateContTotalAmount),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),
	[CampaignEstimateNonResaleTaxAmount] = (SELECT ISNULL(SUM(EstimateNonResaleTaxAmount),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),
	[CampaignEstimateResaleTaxAmount] = (SELECT ISNULL(SUM(EstimateResaleTaxAmount),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),
	[CampaignEstimateMarkupAmount] = (SELECT ISNULL(SUM(EstimateMarkupAmount),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),
	[CampaignEstimateCostAmount] = (SELECT ISNULL(SUM(EstimateCostAmount),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID),
	[CampaignEstimateNetAmount] = (SELECT ISNULL(SUM(EstimateNetAmount),0) FROM #JOB_DETAIL WHERE ResourceType = 'EC' AND #JOB_DETAIL.ItemID = #CAMP_TOTAL.CampaignID)

UPDATE #CAMP_TOTAL
SET [BillingBudget] = ISNULL(CMP_BILL_BUDGET,0),
	[IncomeBudget] = ISNULL(CMP_INC_BUDGET,0)
FROM CAMPAIGN
WHERE CAMPAIGN.CMP_IDENTIFIER = #CAMP_TOTAL.CampaignID --AND BillingBudget IS NULL

if @UseCampaignMasterJob = 1
BEGIN
	SELECT [OfficeCode],
		[OfficeDescription],
		[ClientCode],
		[ClientDescription],
		[ClientCity],
		[ClientState],
		[DivisionCode],
		[DivisionDescription],
		[DivisionCity],
		[DivisionState],
		[ProductCode],
		[ProductDescription],	
		[ProductCity],
		[ProductState],
		[ProductUDF1],
		[ProductUDF2],
		[ProductUDF3],
		[ProductUDF4],
		[AccountExecutiveCode],
		[AccountExecutive],
		[CampaignID],
		[CampaignCode],
		[CampaignName],
		[BillingBudget], 
		[IncomeBudget],
		--[MarketCode],
		--[MarketDescription],
		--[FiscalPeriodCode],
		--[FiscalPeriodDescription],
		--[SalesClassCode],
		--[SalesClassDescription],
		[JobNumber] = C.JOB_NUMBER,
		[JobComponentNumber] = C.JOB_COMPONENT_NBR,
		[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), C.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), C.JOB_COMPONENT_NBR), 2),
		[JobDescription] = JL.JOB_DESC,	
		[ComponentDescription] = JC.JOB_COMP_DESC,
		--[OrderNumber],
		--[OrderDescription], 
		--[ClientPO],		
		SUM([Hours]) AS [Hours],
		SUM([NetAmount]) AS [NetAmount],
		SUM([Commission]) AS [Commission],
		SUM([BillingAmountLessResale]) AS [BillingAmountLessResale],
		SUM([BilledAmountLessResale]) AS [BilledAmountLessResale],	
		SUM([BilledAmount]) AS [BilledAmount],
		SUM([BilledCost]) AS [BilledCost],
		SUM([BilledIncome]) AS [BilledIncome],
		SUM([UnbilledAmountLessResale]) AS [UnbilledAmountLessResale],
		SUM([UnbilledAmount]) AS [UnbilledAmount],
		SUM([ResaleTaxAmount]) AS [ResaleTaxAmount],
		SUM([Total]) AS [Total],
		SUM([TotalLessResale]) AS [TotalLessResale],
		[ClientBudgetBillingAmount], 
		[ClientBudgetIncomeAmount],
		SUM([EstimateHours]) AS [EstimateHours],
		SUM([EstimateQuantity]) AS [EstimateQuantity],
		SUM([EstimateTotalAmount]) AS [EstimateTotalAmount],
		SUM([EstimateContTotalAmount]) AS [EstimateContTotalAmount],
		SUM([EstimateNonResaleTaxAmount]) AS [EstimateNonResaleTaxAmount],
		SUM([EstimateResaleTaxAmount]) AS [EstimateResaleTaxAmount],
		SUM([EstimateMarkupAmount]) AS [EstimateMarkupAmount],
		SUM([EstimateCostAmount]) AS [EstimateCostAmount],
		SUM([EstimateNetAmount]) AS [EstimateNetAmount],
		SUM([CampaignEstimateHours]) AS [CampaignEstimateHours],
		SUM([CampaignEstimateQuantity]) AS [CampaignEstimateQuantity],
		SUM([CampaignEstimateTotalAmount]) AS [CampaignEstimateTotalAmount],
		SUM([CampaignEstimateContTotalAmount]) AS [CampaignEstimateContTotalAmount],
		SUM([CampaignEstimateNonResaleTaxAmount]) AS [CampaignEstimateNonResaleTaxAmount],
		SUM([CampaignEstimateResaleTaxAmount]) AS [CampaignEstimateResaleTaxAmount],
		SUM([CampaignEstimateMarkupAmount]) AS [CampaignEstimateMarkupAmount],
		SUM([CampaignEstimateCostAmount]) AS [CampaignEstimateCostAmount],
		SUM([CampaignEstimateNetAmount]) AS [CampaignEstimateNetAmount],
		--[Type], 
		--[PostPeriodCode] AS [AccountsReceivablePostingPeriod],
		--[Year],
		--[Month],
		[JobCreatedDate] = JL.CREATE_DATE,
		[JobStartDate] = JC.[START_DATE],
		[JobDueDate] = JC.JOB_FIRST_USE_DATE
		FROM #CAMP_TOTAL INNER JOIN 
			 CAMPAIGN C ON C.CMP_IDENTIFIER = #CAMP_TOTAL.CampaignID LEFT OUTER JOIN
			 JOB_LOG JL ON JL.JOB_NUMBER = C.JOB_NUMBER LEFT OUTER JOIN
			 JOB_COMPONENT JC ON JC.JOB_NUMBER = C.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = C.JOB_COMPONENT_NBR
		GROUP BY [OfficeCode],
				[OfficeDescription],
				[ClientCode],
				[ClientDescription],
				[ClientCity],
				[ClientState],
				[DivisionCode],
				[DivisionDescription],
				[DivisionCity],
				[DivisionState],
				[ProductCode],
				[ProductDescription],	
				[ProductCity],
				[ProductState],
				[ProductUDF1],
				[ProductUDF2],
				[ProductUDF3],
				[ProductUDF4],
				[AccountExecutiveCode],
				[AccountExecutive],
				[CampaignID],
				[CampaignCode],
				[CampaignName],
				[BillingBudget], 
				[IncomeBudget],
				[ClientBudgetBillingAmount], 
				[ClientBudgetIncomeAmount],
				C.JOB_NUMBER,
				C.JOB_COMPONENT_NBR,
				JL.JOB_DESC,	
				JC.JOB_COMP_DESC,
				JL.CREATE_DATE,
				JC.[START_DATE],
				JC.JOB_FIRST_USE_DATE
END
ELSE
BEGIN
	SELECT [OfficeCode],
		[OfficeDescription],
		[ClientCode],
		[ClientDescription],
		[ClientCity],
		[ClientState],
		[DivisionCode],
		[DivisionDescription],
		[DivisionCity],
		[DivisionState],
		[ProductCode],
		[ProductDescription],	
		[ProductCity],
		[ProductState],
		[ProductUDF1],
		[ProductUDF2],
		[ProductUDF3],
		[ProductUDF4],
		[AccountExecutiveCode],
		[AccountExecutive],
		[CampaignID],
		[CampaignCode],
		[CampaignName],
		[BillingBudget], 
		[IncomeBudget],
		--[MarketCode],
		--[MarketDescription],
		--[FiscalPeriodCode],
		--[FiscalPeriodDescription],
		--[SalesClassCode],
		--[SalesClassDescription],
		--[JobNumber],
		--[JobComponentNumber],
		--[JobComponent],
		--[JobDescription],	
		--[ComponentDescription],
		--[OrderNumber],
		--[OrderDescription], 
		--[ClientPO],		
		SUM([Hours]) AS [Hours],
		SUM([NetAmount]) AS [NetAmount],
		SUM([Commission]) AS [Commission],
		SUM([BillingAmountLessResale]) AS [BillingAmountLessResale],
		SUM([BilledAmountLessResale]) AS [BilledAmountLessResale],	
		SUM([BilledAmount]) AS [BilledAmount],
		SUM([BilledCost]) AS [BilledCost],
		SUM([BilledIncome]) AS [BilledIncome],
		SUM([UnbilledAmountLessResale]) AS [UnbilledAmountLessResale],
		SUM([UnbilledAmount]) AS [UnbilledAmount],
		SUM([ResaleTaxAmount]) AS [ResaleTaxAmount],
		SUM([Total]) AS [Total],
		SUM([TotalLessResale]) AS [TotalLessResale],
		[ClientBudgetBillingAmount], 
		[ClientBudgetIncomeAmount],
		SUM([EstimateHours]) AS [EstimateHours],
		SUM([EstimateQuantity]) AS [EstimateQuantity],
		SUM([EstimateTotalAmount]) AS [EstimateTotalAmount],
		SUM([EstimateContTotalAmount]) AS [EstimateContTotalAmount],
		SUM([EstimateNonResaleTaxAmount]) AS [EstimateNonResaleTaxAmount],
		SUM([EstimateResaleTaxAmount]) AS [EstimateResaleTaxAmount],
		SUM([EstimateMarkupAmount]) AS [EstimateMarkupAmount],
		SUM([EstimateCostAmount]) AS [EstimateCostAmount],
		SUM([EstimateNetAmount]) AS [EstimateNetAmount],
		SUM([CampaignEstimateHours]) AS [CampaignEstimateHours],
		SUM([CampaignEstimateQuantity]) AS [CampaignEstimateQuantity],
		SUM([CampaignEstimateTotalAmount]) AS [CampaignEstimateTotalAmount],
		SUM([CampaignEstimateContTotalAmount]) AS [CampaignEstimateContTotalAmount],
		SUM([CampaignEstimateNonResaleTaxAmount]) AS [CampaignEstimateNonResaleTaxAmount],
		SUM([CampaignEstimateResaleTaxAmount]) AS [CampaignEstimateResaleTaxAmount],
		SUM([CampaignEstimateMarkupAmount]) AS [CampaignEstimateMarkupAmount],
		SUM([CampaignEstimateCostAmount]) AS [CampaignEstimateCostAmount],
		SUM([CampaignEstimateNetAmount]) AS [CampaignEstimateNetAmount]--,
		--[Type], 
		--[PostPeriodCode] AS [AccountsReceivablePostingPeriod],
		--[Year],
		--[Month],
		--[JobCreatedDate],
		--[JobStartDate],
		--[JobDueDate]
		FROM #CAMP_TOTAL --WHERE CampaignID = 1
		GROUP BY [OfficeCode],
				[OfficeDescription],
				[ClientCode],
				[ClientDescription],
				[ClientCity],
				[ClientState],
				[DivisionCode],
				[DivisionDescription],
				[DivisionCity],
				[DivisionState],
				[ProductCode],
				[ProductDescription],	
				[ProductCity],
				[ProductState],
				[ProductUDF1],
				[ProductUDF2],
				[ProductUDF3],
				[ProductUDF4],
				[AccountExecutiveCode],
				[AccountExecutive],
				[CampaignID],
				[CampaignCode],
				[CampaignName],
				[BillingBudget], 
				[IncomeBudget],
				[ClientBudgetBillingAmount], 
				[ClientBudgetIncomeAmount]
END




	DROP TABLE #JOB
	DROP TABLE #JOB_DETAIL 
	DROP TABLE #CAMP
	DROP TABLE #CAMP_TOTAL

END
GO

GRANT EXECUTE ON [advsp_campaign_job_media_summary_load] TO PUBLIC
GO