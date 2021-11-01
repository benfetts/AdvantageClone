if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Gross_Income]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Gross_Income]
GO

CREATE PROCEDURE [dbo].[usp_wv_Gross_Income] 
	@StartDate SMALLDATETIME,
	@EndDate SMALLDATETIME,
	@DateType int,
	@Standard int
AS

    SET ANSI_NULLS ON
    SET ANSI_WARNINGS OFF
    SET ARITHABORT OFF
    SET ARITHIGNORE ON
		DECLARE @Records int, @Count int, @Recordcomp int, @Countcomp int, @jNum int, @cNum int

		CREATE TABLE #GROSS_INCOME 
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[ResourceType] varchar(3),
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
			[CampaignDescription] varchar(128),
			[SalesClassCode] varchar(6),
			[SalesClassDescription] varchar(30),
			[UserCode] varchar(6),
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
			[ComplexityDescription] varchar(40),
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
			[ComponentDateOpened] smalldatetime,
			[DueDate] smalldatetime,
			[StartDate] smalldatetime,
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
			[ClientContactCode] varchar(6),
			[ClientContactID] int,
			[BABatchID] int,
			[ClientContact] varchar(100),
			[SelectedBABatchID] int,
			[BillingCommandCenterID] int,
			[AlertAssignmentTemplate] varchar(100),
			[FunctionType] varchar(1),
			[FunctionConsolidationCode] varchar(6),
			[FunctionConsolidation] varchar(30),
			[FunctionHeading] varchar(60),
			[FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[FunctionDescription] varchar(30),
			[ItemID] int,
			[ItemSequenceNumber] int,
			[ItemDate] smalldatetime,
			[PostPeriodCode] varchar(8),
			[ItemCode] varchar(6),
			[ItemDescription] varchar(100),
			[ItemComment] varchar(MAX),
			[ItemExtra] varchar(20),
			[FeeTime] smallint,
			[Hours] decimal(15, 2),
			[Quantity] decimal(15, 2),
			[BillableLessResale] decimal(14, 2),
			[BillableTotal] decimal(14, 2),
			[ExtMarkupAmount] decimal(14, 2),
			[NonResaleTaxAmount] decimal(14, 2),
			[ResaleTaxAmount] decimal(14, 2),
			[Total] decimal(14, 2),
			[CostAmount] decimal(14, 2),
			[NetAmount] decimal(14, 2),
			[AccountsReceivablePostPeriodCode] varchar(6),
			[AccountsReceivableInvoiceNumber] int,
			[AccountsReceivableInvoiceType] varchar(3),
			[AdvanceBillFlagDetail] smallint,
			[IsNonBillable] smallint,
			[GlexActBill] int,
			[EstimatedHours] decimal(15, 2),
			[EstimatedQuantity] decimal(15, 2),
			[EstimatedTotalAmount] decimal(15, 2),
			[EstimateContTotalAmount] decimal(15, 2),
			[EstimateNonResaleTaxAmount] decimal(15, 2),
			[EstimateResaleTaxAmount] decimal(15, 2),
			[EstimateMarkupAmount] decimal(15, 2),
			[EstimatedCostAmount] decimal(15, 2),
			[IsEstimateNonBillable] smallint,
			[EstimateFeeTime] decimal(15, 2),
			[EstimateNetAmount] decimal(15, 2),
			[BilledAmount] decimal(15, 2),
			[BilledWithResale] decimal(15, 2),
			[BilledHours] decimal(7, 2),
			[BilledQuantity] decimal(7, 2),
			[FeeTimeAmount] decimal(15, 2),
			[FeeTimeHours] decimal(7, 2),
			[NonBillableAmount] decimal(15, 2),
			[NonBillableHours] decimal(7, 2),
			[NonBillableQuantity] decimal(7, 2),
			[IsNewBusiness] smallint,
			[Agency] smallint,
			[ProductUDF1] varchar(50),
			[ProductUDF2] varchar(50),
			[ProductUDF3] varchar(50),
			[ProductUDF4] varchar(50),
			[EstimatedGrossIncome] decimal(15, 2),
			[EstimatedGrossIncomePercent] decimal(15, 2),
			[EstimatedIncome] decimal(15, 2),
			[EstimatedIncomePercent] decimal(15, 2),
			[EstimatedIncomeHist] decimal(15, 2),
			[EstimatedIncomePercentHist] decimal(15, 2),
			[PlannedHours] decimal(15, 2),
			[PlannedAmount] decimal(15, 2),
			[PlannedCostAmount] decimal(15, 2),
			[PlannedIncome] decimal(15, 2),
			[PlannedIncomePercent] decimal(15, 2),
			[ActualGrossIncome] decimal(15, 2),
			[ActualGrossIncomePercent] decimal(15, 2),
			[ActualIncome] decimal(15, 2),
			[ActualIncomePercent] decimal(15, 2),
			[SeqNbr] smallint,
			[EmployeeCode] varchar(6),
			[EmployeeName] varchar(63),
			[EstimatedCostAmountHist] decimal(15,2)
        );
		CREATE TABLE #JOB_INCOME 
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[ResourceType] varchar(3),
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
			[CampaignDescription] varchar(128),
			[SalesClassCode] varchar(6),
			[SalesClassDescription] varchar(30),
			[UserCode] varchar(6),
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
			[ComplexityDescription] varchar(40),
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
			[ComponentDateOpened] smalldatetime,
			[DueDate] smalldatetime,
			[StartDate] smalldatetime,
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
			[ClientContactCode] varchar(6),
			[ClientContactID] int,
			[BABatchID] int,
			[ClientContact] varchar(100),
			[SelectedBABatchID] int,
			[BillingCommandCenterID] int,
			[AlertAssignmentTemplate] varchar(100),	
			[IsNewBusiness] smallint,
			[Agency] smallint,
			[ProductUDF1] varchar(50),
			[ProductUDF2] varchar(50),
			[ProductUDF3] varchar(50),
			[ProductUDF4] varchar(50)
        );		
		CREATE TABLE #FUNC_INCOME 
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[ResourceType] varchar(3),
			[JobNumber] int,
			[JobComponentNumber] smallint,
			[FunctionType] varchar(1),
			[FunctionConsolidationCode] varchar(6),
			[FunctionConsolidation] varchar(30),
			[FunctionHeading] varchar(60),
			[FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[FunctionDescription] varchar(30),
			[ItemID] int,
			[ItemSequenceNumber] int,
			[ItemDate] smalldatetime,
			[PostPeriodCode] varchar(8),
			[ItemCode] varchar(6),
			[ItemDescription] varchar(100),
			[ItemComment] varchar(MAX),
			[ItemExtra] varchar(20),
			[FeeTime] smallint,
			[Hours] decimal(15, 2),
			[Quantity] decimal(15, 2),
			[BillableLessResale] decimal(14, 2),
			[BillableTotal] decimal(14, 2),
			[ExtMarkupAmount] decimal(14, 2),
			[NonResaleTaxAmount] decimal(14, 2),
			[ResaleTaxAmount] decimal(14, 2),
			[Total] decimal(14, 2),
			[CostAmount] decimal(14, 2),
			[NetAmount] decimal(14, 2),
			[AccountsReceivablePostPeriodCode] varchar(6),
			[AccountsReceivableInvoiceNumber] int,
			[AccountsReceivableInvoiceType] varchar(3),
			[AdvanceBillFlagDetail] smallint,
			[IsNonBillable] smallint,
			[GlexActBill] int,			
			[BilledAmount] decimal(15, 2),
			[BilledWithResale] decimal(15, 2),
			[BilledHours] decimal(7, 2),
			[BilledQuantity] decimal(7, 2),
			[FeeTimeAmount] decimal(15, 2),
			[FeeTimeHours] decimal(7, 2),
			[NonBillableAmount] decimal(15, 2),
			[NonBillableHours] decimal(7, 2),
			[NonBillableQuantity] decimal(7, 2),
			[EstimatedGrossIncome] decimal(15, 2),
			[EstimatedGrossIncomePercent] decimal(15, 2),
			[EstimatedIncome] decimal(15, 2),
			[EstimatedIncomePercent] decimal(15, 2),
			[EstimatedIncomeHist] decimal(15, 2),
			[EstimatedIncomePercentHist] decimal(15, 2),
			[PlannedHours] decimal(15, 2),
			[PlannedAmount] decimal(15, 2),
			[PlannedCostAmount] decimal(15, 2),
			[PlannedIncome] decimal(15, 2),
			[PlannedIncomePercent] decimal(15, 2),
			[ActualGrossIncome] decimal(15, 2),
			[ActualGrossIncomePercent] decimal(15, 2),
			[ActualIncome] decimal(15, 2),
			[ActualIncomePercent] decimal(15, 2),
			[SeqNbr] smallint,
			[EmployeeCode] varchar(6),
			[EmployeeName] varchar(63)
        );
		CREATE TABLE #EST_INCOME 
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[ResourceType] varchar(3),
			[JobNumber] int,
			[JobComponentNumber] smallint,
			[EstimateNumber] int,
			[EstimateComponentNumber] smallint,
			[FunctionType] varchar(1),
			[FunctionConsolidationCode] varchar(6),
			[FunctionConsolidation] varchar(30),
			[FunctionHeading] varchar(60),
			[FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[FunctionDescription] varchar(30),
			[ItemDescription] varchar(100),
			[EstimatedHours] decimal(15, 2),
			[EstimatedQuantity] decimal(15, 2),
			[EstimatedTotalAmount] decimal(15, 2),
			[EstimateContTotalAmount] decimal(15, 2),
			[EstimateNonResaleTaxAmount] decimal(15, 2),
			[EstimateResaleTaxAmount] decimal(15, 2),
			[EstimateMarkupAmount] decimal(15, 2),
			[EstimatedCostAmount] decimal(15, 2),
			[IsEstimateNonBillable] smallint,
			[EstimateFeeTime] decimal(15, 2),
			[EstimateNetAmount] decimal(15, 2),
			[EstimatedGrossIncome] decimal(15, 2),
			[EstimatedGrossIncomePercent] decimal(15, 2),
			[EstimatedIncome] decimal(15, 2),
			[EstimatedIncomePercent] decimal(15, 2),
			[EstimatedIncomeHist] decimal(15, 2),
			[EstimatedIncomePercentHist] decimal(15, 2),
			[PlannedHours] decimal(15, 2),
			[PlannedAmount] decimal(15, 2),
			[PlannedCostAmount] decimal(15, 2),
			[PlannedIncome] decimal(15, 2),
			[PlannedIncomePercent] decimal(15, 2),
			[ActualGrossIncome] decimal(15, 2),
			[ActualGrossIncomePercent] decimal(15, 2),
			[ActualIncome] decimal(15, 2),
			[ActualIncomePercent] decimal(15, 2),
			[SeqNbr] smallint,
			[EmployeeCode] varchar(6),
			[EmployeeName] varchar(63),
			[EstimatedCostAmountHist] decimal(15, 2)
        );
		CREATE TABLE #GROSS_INCOME_TOTAL --MASTER TABLE TO RETURN
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
			[CampaignDescription] varchar(128),
			[SalesClassCode] varchar(6),
			[SalesClassDescription] varchar(30),
			[UserCode] varchar(6),
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
			[ComplexityDescription] varchar(40),
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
			[ComponentDateOpened] smalldatetime,
			[DueDate] smalldatetime,
			[StartDate] smalldatetime,
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
			[ClientContactCode] varchar(6),
			[ClientContactID] int,
			[BABatchID] int,
			[ClientContact] varchar(100),
			[SelectedBABatchID] int,
			[BillingCommandCenterID] int,
			[AlertAssignmentTemplate] varchar(100),
			[FunctionType] varchar(1),
			[FunctionConsolidationCode] varchar(6),
			[FunctionConsolidation] varchar(30),
			[FunctionHeading] varchar(60),
			[FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[FunctionDescription] varchar(30),
			--[ItemID] int,
			--[ItemSequenceNumber] smallint,
			--[ItemDate] smalldatetime,
			--[PostPeriodCode] varchar(8),
			--[ItemCode] varchar(6),
			--[ItemDescription] varchar(100),
			--[ItemComment] varchar(MAX),
			--[ItemExtra] varchar(20),
			--[FeeTime] smallint,
			[Hours] decimal(15, 2),
			[Quantity] decimal(15, 2),
			[BillableAmount] decimal(14, 2),
			--[BillableTotal] decimal(14, 2),
			[ExtMarkupAmount] decimal(14, 2),
			--[NonResaleTaxAmount] decimal(14, 2),
			--[ResaleTaxAmount] decimal(14, 2),
			[Total] decimal(14, 2),
			[CostAmount] decimal(14, 2),
			[NetAmount] decimal(14, 2),
			--[AccountsReceivablePostPeriodCode] varchar(6),
			--[AccountsReceivableInvoiceNumber] int,
			--[AccountsReceivableInvoiceType] varchar(3),
			--[AdvanceBillFlagDetail] smallint,
			--[IsNonBillable] smallint,
			--[GlexActBill] int,
			[EstimatedHours] decimal(15, 2),
			[EstimatedQuantity] decimal(15, 2),
			[EstimatedTotalAmount] decimal(15, 2),
			--[EstimateContTotalAmount] decimal(15, 2),
			--[EstimateNonResaleTaxAmount] decimal(15, 2),
			--[EstimateResaleTaxAmount] decimal(15, 2),
			[EstimatedMarkupAmount] decimal(15, 2),
			[EstimatedCostAmount] decimal(15, 2),
			--[IsEstimateNonBillable] smallint,
			--[EstimateFeeTime] decimal(15, 2),
			[EstimatedNetAmount] decimal(15, 2),
			[BilledAmount] decimal(15, 2),
			--[BilledWithResale] decimal(15, 2),
			[BilledHours] decimal(7, 2),
			[BilledQuantity] decimal(7, 2),
			--[FeeTimeAmount] decimal(15, 2),
			--[FeeTimeHours] decimal(7, 2),
			[NonBillableAmount] decimal(15, 2),
			--[NonBillableHours] decimal(7, 2),
			--[NonBillableQuantity] decimal(7, 2),
			[IsNewBusiness] smallint,
			[Agency] smallint,
			[ProductUDF1] varchar(50),
			[ProductUDF2] varchar(50),
			[ProductUDF3] varchar(50),
			[ProductUDF4] varchar(50),
			[EstimatedGrossIncome] decimal(15, 2),
			[EstimatedGrossIncomePercent] decimal(15, 2),
			[EstimatedIncome] decimal(15, 2),
			[EstimatedIncomePercent] decimal(15, 2),
			[EstimatedIncomeHist] decimal(15, 2),
			[EstimatedIncomePercentHist] decimal(15, 2),
			[PlannedHours] decimal(15, 2),
			[PlannedAmount] decimal(15, 2),
			[PlannedCostAmount] decimal(15, 2),
			[PlannedIncome] decimal(15, 2),
			[PlannedIncomePercent] decimal(15, 2),
			[ActualGrossIncome] decimal(15, 2),
			[ActualGrossIncomePercent] decimal(15, 2),
			[ActualIncome] decimal(15, 2),
			[ActualIncomePercent] decimal(15, 2),
			[EmployeeCode] varchar(6),
			[EmployeeName] varchar(63),
			[EstimatedCostAmountHist] decimal(15,2)
        );
        CREATE TABLE #PROJECT_TASK_ADJ 
        (
	        [ROW_ID] [int] IDENTITY(1,1) NOT NULL,
			[JOB_NUMBER] int,
			[JOB_COMPONENT_NBR] smallint,
			[SEQ_NBR] smallint,
			[EST_FUNC] VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[ADJ_DATE] datetime,
			[ADJ_MONTH] int,
			[ADJ_YEAR] int,
	        [EMP_CODE] VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[WORK_DAYS] int,
			[ADJ_HOURS_ALLOWED] DECIMAL(15,2),
	        [BILL_RATE] DECIMAL(15,3),
			[IS_WORK_DAY] SMALLINT,
			[EMP_HOURS] DECIMAL(12,2),
			[HOURS_ALLOWED] DECIMAL(15,2)
        );
		CREATE TABLE #PROJECT_TASK_LIST 
        (
	        [ROW_ID] [int] IDENTITY(1,1) NOT NULL,
			[JOB_NUMBER] int,
			[JOB_COMPONENT_NBR] smallint,
			[SEQ_NBR] smallint,
			[EST_FUNC] VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[START_DATE] datetime,
			[END_DATE] datetime,
	        [EMP_CODE] VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	        [EMP_COST_RATE] DECIMAL(9,2),
			[HOURS_ALLOWED] DECIMAL(15,2),
			[ACTUAL_HOURS] DECIMAL(15,2),
			[ACTUAL_AMT] DECIMAL(15,2),
	        [BILL_RATE] DECIMAL(15,3),
        );
        CREATE TABLE #jobs
        (
	        [ROW_ID] [int] IDENTITY(1,1) NOT NULL,
			[JOB_NUMBER] int,
			[JOB_COMPONENT_NBR] smallint
        );

		--Get Jobs with schedules
		If @DateType = 1
		Begin
			INSERT INTO #jobs
			SELECT DISTINCT JOB_LOG.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
			FROM JOB_COMPONENT INNER JOIN
				 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
				JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
				JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			WHERE JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) AND JOB_LOG.CREATE_DATE BETWEEN @StartDate and @EndDate	
		End
		If @DateType = 2
		Begin
			INSERT INTO #jobs
			SELECT DISTINCT JOB_LOG.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
			FROM JOB_COMPONENT INNER JOIN
				 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
				JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
				JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			WHERE JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) AND JOB_COMPONENT.JOB_COMP_DATE BETWEEN @StartDate and @EndDate	
		End
		If @DateType = 3
		Begin
			INSERT INTO #jobs
			SELECT DISTINCT JOB_LOG.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
			FROM JOB_COMPONENT INNER JOIN
				 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
				JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
				JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			WHERE JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) AND JOB_COMPONENT.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate	
		End
		If @DateType = 4
		Begin
			INSERT INTO #jobs
			SELECT DISTINCT JOB_LOG.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
			FROM JOB_COMPONENT INNER JOIN
				 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
				JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
				JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			WHERE JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) AND JOB_COMPONENT.START_DATE BETWEEN @StartDate and @EndDate	
		End
		
		--Grab base info for Estimates
--		If @DateType = 1
--		Begin			
--			--Estimate data based on an existing estimate approval
--			INSERT INTO #GROSS_INCOME
--				SELECT [ResourceType] = 'ES',
--				[JobNumber] = EA.JOB_NUMBER,
--				[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
--				[OfficeCode] = J.OFFICE_CODE,
--				[OfficeDescription] = O.OFFICE_NAME,
--				[ClientCode] = J.CL_CODE,
--				[ClientDescription] = C.CL_NAME,
--				[DivisionCode] = J.DIV_CODE,
--				[DivisionDescription] = D.DIV_NAME,
--				[ProductCode] = J.PRD_CODE,
--				[ProductDescription] = P.PRD_DESCRIPTION,
--				[CampaignID] = CAMP.CMP_IDENTIFIER,
--				[CampaignCode] = J.CMP_CODE, 
--				[CampaignName] = CAMP.CMP_NAME,
--				[SalesClassCode] = J.SC_CODE,
--				[SalesClassDescription] = SC.SC_DESCRIPTION,
--				[UserCode] = J.[USER_ID],
--				[JobCreateDate] = J.CREATE_DATE,
--				[JobDescription] = J.JOB_DESC,
--				[JobDateOpened] = J.JOB_DATE_OPENED,
--				[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
--				[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
--				[ClientReference] = J.JOB_CLI_REF,
--				[BillingCoopCode] = J.BILL_COOP_CODE,
--				[SalesClassFormatCode] = J.FORMAT_SC_CODE,
--				[ComplexityCode] = J.COMPLEX_CODE,
--				[PromotionCode] = J.PROMO_CODE,
--				[BillingComment] = J.JOB_BILL_COMMENT,
--				[LabelFromUDFTable1] = JUDV1.UDV_DESC,
--				[LabelFromUDFTable2] = JUDV2.UDV_DESC,
--				[LabelFromUDFTable3] = JUDV3.UDV_DESC,
--				[LabelFromUDFTable4] = JUDV4.UDV_DESC,
--				[LabelFromUDFTable5] = JUDV5.UDV_DESC,
--				[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
--				[ComponentNumber] = JC.JOB_COMPONENT_NBR,
--				[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
--				[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
--				[AccountExecutiveCode] = JC.EMP_CODE,
--				[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
--				[ComponentDateOpened] = JC.JOB_COMP_DATE,
--				[DueDate] = JC.JOB_FIRST_USE_DATE,
--				[StartDate] = JC.[START_DATE],
--				[AdSize] = JC.JOB_AD_SIZE,
--				[DepartmentTeamCode] = JC.DP_TM_CODE,
--				[DepartmentTeam] = DT.DP_TM_DESC,
--				[MarkupPercent] = JC.JOB_MARKUP_PCT,
--				[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
--				[JobProcessControl] = JPC.JOB_PROCESS_DESC,
--				[ComponentDescription] = JC.JOB_COMP_DESC,
--				[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
--				[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
--				[EstimateNumber] = JC.ESTIMATE_NUMBER,
--				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
--				[BillingUser] = JC.BILLING_USER,
--				[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
--				[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
--				[JobTypeCode] = JC.JT_CODE,
--				[JobTypeDescription] = JT.JT_DESC,
--				[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TaxCode] = JC.TAX_CODE,
--				[TaxCodeDescription] = ST.TAX_DESCRIPTION,
--				[NonBillable] = JC.NOBILL_FLAG,
--				[AlertGroup] = JC.EMAIL_GR_CODE,
--				[AdNumber] = JC.AD_NBR,
--				[AccountNumber] = JC.ACCT_NBR,
--				[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
--				[MarketCode] = JC.MARKET_CODE,
--				[MarketDescription] = M.MARKET_DESC,
--				[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[ServiceFeeTypeCode] = SFT.CODE,
--				[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
--				[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[ClientPO] = JC.JOB_CL_PO_NBR,
--				[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
--				[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
--				[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
--				[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
--				[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
--				[JobTemplateCode] = JC.JOB_TMPLT_CODE,
--				[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
--				[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
--				[JobQuantity] = JC.JOB_QTY,
--				[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
--				[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
--				[ClientContactCode] = JC.PRD_CONT_CODE,
--				[ClientContactID] = JC.CDP_CONTACT_ID,
--				[BABatchID] = JC.BA_BATCH_ID,
--				[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
--				[SelectedBABatchID] = JC.SELECTED_BA_ID,
--				[BillingCommandCenterID] = JC.BCC_ID,
--				[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
--				[FunctionType] = F.FNC_TYPE,
--				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
--				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
--				[FunctionHeading] = FH.FNC_HEADING_DESC,
--				[FunctionCode] = ERD.FNC_CODE,
--				[FunctionDescription] = F.FNC_DESCRIPTION,
--				[ItemID] = 0,
--				[ItemSequenceNumber] = 0,
--				[ItemDate] = CAST(NULL AS smalldatetime),
--				[PostPeriodCode] = CAST(NULL AS varchar(8)),
--				[ItemCode] = CAST(NULL AS varchar(6)),
--				[ItemDescription] = 'Estimate Amount',
--				[ItemComment] = CAST(NULL AS varchar(MAX)),
--				[ItemExtra] = CAST(NULL AS varchar(20)),
--				[FeeTime] = 0,
--				[Hours] = 0,
--				[Quantity] = 0,
--				[BillableLessResale] = 0,
--				[BillableTotal] = 0,
--				[ExtMarkupAmount] = 0,
--				[NonResaleTaxAmount] = 0,
--				[ResaleTaxAmount] = 0,
--				[Total] = 0,
--				[CostAmount] = 0,
--				[NetAmount] = 0,
--				[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
--				[AccountsReceivableInvoiceNumber] = 0,
--				[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
--				[AdvanceBillFlagDetail] = 0,
--				[IsNonBillable] = 0,
--				[GlexActBill] = 0,
--				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
--				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
--				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
--				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
--				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
--				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
--				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
--				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
--										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
--											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
--				[IsEstimateNonBillable] = 0,
--				[EstimateFeeTime] = 0,
--				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
--				[BilledAmount] = 0,
--				[BilledWithResale] = 0,
--				[BilledHours] = 0,
--				[BilledQuantity] = 0,
--				[FeeTimeAmount] = 0,
--				[FeeTimeHours] = 0,
--				[NonBillableAmount] = 0,
--				[NonBillableHours] = 0,
--				[NonBillableQuantity] = 0,
--				[IsNewBusiness] = C.NEW_BUSINESS,
--				[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
--				[ProductUDF1] = P.USER_DEFINED1,
--				[ProductUDF2] = P.USER_DEFINED2,
--				[ProductUDF3] = P.USER_DEFINED3,
--				[ProductUDF4] = P.USER_DEFINED4,
--				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
--										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
--											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
--				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
--										             WHEN F.FNC_TYPE = 'E' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
--													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
--				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
--										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
--											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
--				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
--										             WHEN F.FNC_TYPE = 'E' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
--													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
--				0,0,0,0,0,0,0,0,0,0
--			FROM 
--				[dbo].[ESTIMATE_APPROVAL] AS EA INNER JOIN 
--				[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
--												   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
--												   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
--												   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN 
--				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN 
--				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = EA.JOB_NUMBER INNER JOIN
--				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EA.JOB_NUMBER AND
--											JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR LEFT OUTER JOIN
--				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
--				[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
--				[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
--										 D.DIV_CODE = J.DIV_CODE INNER JOIN
--				[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
--										P.DIV_CODE = J.DIV_CODE AND
--										P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
--				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
--				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
--				[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
--				[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
--				[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
--				[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
--				[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
--				[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
--				[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
--				[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
--				[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
--				(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
--				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
--				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
--				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
--				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE
--			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
--			--Estimate data based on as existing internal estimate approval
--			INSERT INTO #GROSS_INCOME
--			SELECT
--				[ResourceType] = 'EI',
--				[JobNumber] = EIA.JOB_NUMBER,
--				[JobComponentNumber] = EIA.JOB_COMPONENT_NBR,
--				[OfficeCode] = J.OFFICE_CODE,
--				[OfficeDescription] = O.OFFICE_NAME,
--				[ClientCode] = J.CL_CODE,
--				[ClientDescription] = C.CL_NAME,
--				[DivisionCode] = J.DIV_CODE,
--				[DivisionDescription] = D.DIV_NAME,
--				[ProductCode] = J.PRD_CODE,
--				[ProductDescription] = P.PRD_DESCRIPTION,
--				[CampaignID] = CAMP.CMP_IDENTIFIER,
--				[CampaignCode] = J.CMP_CODE, 
--				[CampaignName] = CAMP.CMP_NAME,
--				[SalesClassCode] = J.SC_CODE,
--				[SalesClassDescription] = SC.SC_DESCRIPTION,
--				[UserCode] = J.[USER_ID],
--				[JobCreateDate] = J.CREATE_DATE,
--				[JobDescription] = J.JOB_DESC,
--				[JobDateOpened] = J.JOB_DATE_OPENED,
--				[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
--				[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
--				[ClientReference] = J.JOB_CLI_REF,
--				[BillingCoopCode] = J.BILL_COOP_CODE,
--				[SalesClassFormatCode] = J.FORMAT_SC_CODE,
--				[ComplexityCode] = J.COMPLEX_CODE,
--				[PromotionCode] = J.PROMO_CODE,
--				[BillingComment] = J.JOB_BILL_COMMENT,
--				[LabelFromUDFTable1] = JUDV1.UDV_DESC,
--				[LabelFromUDFTable2] = JUDV2.UDV_DESC,
--				[LabelFromUDFTable3] = JUDV3.UDV_DESC,
--				[LabelFromUDFTable4] = JUDV4.UDV_DESC,
--				[LabelFromUDFTable5] = JUDV5.UDV_DESC,
--				[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
--				[ComponentNumber] = JC.JOB_COMPONENT_NBR,
--				[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
--				[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
--				[AccountExecutiveCode] = JC.EMP_CODE,
--				[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
--				[ComponentDateOpened] = JC.JOB_COMP_DATE,
--				[DueDate] = JC.JOB_FIRST_USE_DATE,
--				[StartDate] = JC.[START_DATE],
--				[AdSize] = JC.JOB_AD_SIZE,
--				[DepartmentTeamCode] = JC.DP_TM_CODE,
--				[DepartmentTeam] = DT.DP_TM_DESC,
--				[MarkupPercent] = JC.JOB_MARKUP_PCT,
--				[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
--				[JobProcessControl] = JPC.JOB_PROCESS_DESC,
--				[ComponentDescription] = JC.JOB_COMP_DESC,
--				[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
--				[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
--				[EstimateNumber] = JC.ESTIMATE_NUMBER,
--				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
--				[BillingUser] = JC.BILLING_USER,
--				[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
--				[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
--				[JobTypeCode] = JC.JT_CODE,
--				[JobTypeDescription] = JT.JT_DESC,
--				[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TaxCode] = JC.TAX_CODE,
--				[TaxCodeDescription] = ST.TAX_DESCRIPTION,
--				[NonBillable] = JC.NOBILL_FLAG,
--				[AlertGroup] = JC.EMAIL_GR_CODE,
--				[AdNumber] = JC.AD_NBR,
--				[AccountNumber] = JC.ACCT_NBR,
--				[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
--				[MarketCode] = JC.MARKET_CODE,
--				[MarketDescription] = M.MARKET_DESC,
--				[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[ServiceFeeTypeCode] = SFT.CODE,
--				[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
--				[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[ClientPO] = JC.JOB_CL_PO_NBR,
--				[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
--				[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
--				[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
--				[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
--				[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
--				[JobTemplateCode] = JC.JOB_TMPLT_CODE,
--				[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
--				[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
--				[JobQuantity] = JC.JOB_QTY,
--				[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
--				[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
--				[ClientContactCode] = JC.PRD_CONT_CODE,
--				[ClientContactID] = JC.CDP_CONTACT_ID,
--				[BABatchID] = JC.BA_BATCH_ID,
--				[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
--				[SelectedBABatchID] = JC.SELECTED_BA_ID,
--				[BillingCommandCenterID] = JC.BCC_ID,
--				[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
--				[FunctionType] = F.FNC_TYPE,
--				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
--				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
--				[FunctionHeading] = FH.FNC_HEADING_DESC,
--				[FunctionCode] = ERD.FNC_CODE,
--				[FunctionDescription] = F.FNC_DESCRIPTION,
--				[ItemID] = 0,
--				[ItemSequenceNumber] = 0,
--				[ItemDate] = CAST(NULL AS smalldatetime),
--				[PostPeriodCode] = CAST(NULL AS varchar(8)),
--				[ItemCode] = CAST(NULL AS varchar(6)),
--				[ItemDescription] = 'Estimate Amount',
--				[ItemComment] = CAST(NULL AS varchar(MAX)),
--				[ItemExtra] = CAST(NULL AS varchar(20)),
--				[FeeTime] = 0,
--				[Hours] = 0,
--				[Quantity] = 0,
--				[BillableLessResale] = 0,
--				[BillableTotal] = 0,
--				[ExtMarkupAmount] = 0,
--				[NonResaleTaxAmount] = 0,
--				[ResaleTaxAmount] = 0,
--				[Total] = 0,
--				[CostAmount] = 0,
--				[NetAmount] = 0,
--				[AccountsReceivablePostPeriodCode] = CAST(NULL AS varchar(6)),
--				[AccountsReceivableInvoiceNumber] = 0,
--				[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
--				[AdvanceBillFlagDetail] = 0,
--				[IsNonBillable] = 0,
--				[GlexActBill] = 0,
--				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
--				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
--				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
--				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
--				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
--				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
--				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
--				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
--										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
--											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
--				[IsEstimateNonBillable] = 0,
--				[EstimateFeeTime] = 0,
--				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
--				[BilledAmount] = 0,
--				[BilledWithResale] = 0,
--				[BilledHours] = 0,
--				[BilledQuantity] = 0,
--				[FeeTimeAmount] = 0,
--				[FeeTimeHours] = 0,
--				[NonBillableAmount] = 0,
--				[NonBillableHours] = 0,
--				[NonBillableQuantity] = 0,
--				[IsNewBusiness] = C.NEW_BUSINESS,
--				[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
--				[ProductUDF1] = P.USER_DEFINED1,
--				[ProductUDF2] = P.USER_DEFINED2,
--				[ProductUDF3] = P.USER_DEFINED3,
--				[ProductUDF4] = P.USER_DEFINED4,
--				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
--										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
--											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
--				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
--										             WHEN F.FNC_TYPE = 'E' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
--													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
--				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
--										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
--											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
--				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
--										             WHEN F.FNC_TYPE = 'E' THEN 
--														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
--															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
--													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
--				0,0,0,0,0,0,0,0,0,0
--			FROM 
--				[dbo].[ESTIMATE_INT_APPR] AS EIA INNER JOIN 
--				(SELECT
--					EIA.ESTIMATE_NUMBER,
--					EIA.EST_COMPONENT_NBR,
--					EIA.EST_QUOTE_NBR,
--					EIA.EST_REVISION_NBR
--				FROM 
--					[dbo].[ESTIMATE_INT_APPR] AS EIA LEFT JOIN 
--					[dbo].[ESTIMATE_APPROVAL] AS EA ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER AND
--													   EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR AND 
--													   EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR AND 
--													   EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR
--				WHERE 
--					EA.EST_APPR_BY IS NULL) AS EA ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER AND 
--													 EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR AND 
--													 EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR AND 
--													 EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR INNER JOIN 
--				[dbo].[ESTIMATE_REV_DET] AS ERD ON EIA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND 
--												   EIA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR AND 
--												   EIA.EST_QUOTE_NBR = ERD.EST_QUOTE_NBR AND 
--												   EIA.EST_REVISION_NBR = ERD.EST_REV_NBR INNER JOIN 
--				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN 
--				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = EIA.JOB_NUMBER INNER JOIN
--				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EIA.JOB_NUMBER AND
--											JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR LEFT OUTER JOIN
--				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
--				[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
--				[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
--										 D.DIV_CODE = J.DIV_CODE INNER JOIN
--				[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
--										P.DIV_CODE = J.DIV_CODE AND
--										P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
--				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
--				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
--				[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
--				[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
--				[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
--				[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
--				[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
--				[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
--				[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
--				[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
--				[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
--				(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
--				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
--				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
--				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
--				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE
--			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
--			--Actual data 
--			INSERT INTO #GROSS_INCOME
--			SELECT
--				[ResourceType] = 'E',
--				[JobNumber] = ETD.JOB_NUMBER,
--				[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
--				[OfficeCode] = J.OFFICE_CODE,
--				[OfficeDescription] = O.OFFICE_NAME,
--				[ClientCode] = J.CL_CODE,
--				[ClientDescription] = C.CL_NAME,
--				[DivisionCode] = J.DIV_CODE,
--				[DivisionDescription] = D.DIV_NAME,
--				[ProductCode] = J.PRD_CODE,
--				[ProductDescription] = P.PRD_DESCRIPTION,
--				[CampaignID] = CAMP.CMP_IDENTIFIER,
--				[CampaignCode] = J.CMP_CODE, 
--				[CampaignName] = CAMP.CMP_NAME,
--				[SalesClassCode] = J.SC_CODE,
--				[SalesClassDescription] = SC.SC_DESCRIPTION,
--				[UserCode] = J.[USER_ID],
--				[JobCreateDate] = J.CREATE_DATE,
--				[JobDescription] = J.JOB_DESC,
--				[JobDateOpened] = J.JOB_DATE_OPENED,
--				[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
--				[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
--				[ClientReference] = J.JOB_CLI_REF,
--				[BillingCoopCode] = J.BILL_COOP_CODE,
--				[SalesClassFormatCode] = J.FORMAT_SC_CODE,
--				[ComplexityCode] = J.COMPLEX_CODE,
--				[PromotionCode] = J.PROMO_CODE,
--				[BillingComment] = J.JOB_BILL_COMMENT,
--				[LabelFromUDFTable1] = JUDV1.UDV_DESC,
--				[LabelFromUDFTable2] = JUDV2.UDV_DESC,
--				[LabelFromUDFTable3] = JUDV3.UDV_DESC,
--				[LabelFromUDFTable4] = JUDV4.UDV_DESC,
--				[LabelFromUDFTable5] = JUDV5.UDV_DESC,
--				[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
--				[ComponentNumber] = JC.JOB_COMPONENT_NBR,
--				[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
--				[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
--				[AccountExecutiveCode] = JC.EMP_CODE,
--				[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
--				[ComponentDateOpened] = JC.JOB_COMP_DATE,
--				[DueDate] = JC.JOB_FIRST_USE_DATE,
--				[StartDate] = JC.[START_DATE],
--				[AdSize] = JC.JOB_AD_SIZE,
--				[DepartmentTeamCode] = JC.DP_TM_CODE,
--				[DepartmentTeam] = DT.DP_TM_DESC,
--				[MarkupPercent] = JC.JOB_MARKUP_PCT,
--				[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
--				[JobProcessControl] = JPC.JOB_PROCESS_DESC,
--				[ComponentDescription] = JC.JOB_COMP_DESC,
--				[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
--				[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
--				[EstimateNumber] = JC.ESTIMATE_NUMBER,
--				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
--				[BillingUser] = JC.BILLING_USER,
--				[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
--				[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
--				[JobTypeCode] = JC.JT_CODE,
--				[JobTypeDescription] = JT.JT_DESC,
--				[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TaxCode] = JC.TAX_CODE,
--				[TaxCodeDescription] = ST.TAX_DESCRIPTION,
--				[NonBillable] = JC.NOBILL_FLAG,
--				[AlertGroup] = JC.EMAIL_GR_CODE,
--				[AdNumber] = JC.AD_NBR,
--				[AccountNumber] = JC.ACCT_NBR,
--				[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
--				[MarketCode] = JC.MARKET_CODE,
--				[MarketDescription] = M.MARKET_DESC,
--				[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[ServiceFeeTypeCode] = SFT.CODE,
--				[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
--				[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[ClientPO] = JC.JOB_CL_PO_NBR,
--				[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
--				[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
--				[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
--				[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
--				[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
--				[JobTemplateCode] = JC.JOB_TMPLT_CODE,
--				[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
--				[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
--				[JobQuantity] = JC.JOB_QTY,
--				[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
--				[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
--				[ClientContactCode] = JC.PRD_CONT_CODE,
--				[ClientContactID] = JC.CDP_CONTACT_ID,
--				[BABatchID] = JC.BA_BATCH_ID,
--				[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
--				[SelectedBABatchID] = JC.SELECTED_BA_ID,
--				[BillingCommandCenterID] = JC.BCC_ID,
--				[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
--				[FunctionType] = F.FNC_TYPE,
--				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
--				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
--				[FunctionHeading] = FH.FNC_HEADING_DESC,
--				[FunctionCode] = ETD.FNC_CODE,
--				[FunctionDescription] = F.FNC_DESCRIPTION,
--				[ItemID] = ETD.ET_ID,
--				[ItemSequenceNumber] = ETD.ET_DTL_ID,
--				[ItemDate] = CASE WHEN ET.EMP_DATE IS NOT NULL THEN ET.EMP_DATE ELSE NULL END,
--				[PostPeriodCode] = CAST(NULL AS varchar(8)),
--				[ItemCode] = ET.EMP_CODE,
--				[ItemDescription] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,''),
--				[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
--				[ItemExtra] = CAST(NULL AS varchar(20)),
--				[FeeTime] = ISNULL(ETD.FEE_TIME, 0),
--				[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
--				[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
--				[BillableLessResale] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END,
--				[BillableTotal] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) END,
--				[ExtMarkupAmount] = ISNULL(ETD.EXT_MARKUP_AMT, 0),
--				[NonResaleTaxAmount] = 0,
--				[ResaleTaxAmount] = ISNULL(ETD.EXT_STATE_RESALE, 0) + ISNULL(ETD.EXT_COUNTY_RESALE, 0) + ISNULL(ETD.EXT_CITY_RESALE, 0),
--				[Total] = ISNULL(ETD.LINE_TOTAL, 0),
--				[CostAmount] = ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0),
--				[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
--				[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
--				[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
--				[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
--				[AdvanceBillFlagDetail] = ETD.AB_FLAG,
--				[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
--				[GlexActBill] = ETD.GLEXACT_BILL,
--				[EstimateHours] = 0,
--				[EstimateQuantity] = 0,
--				[EstimateTotalAmount] = 0,
--				[EstimateContTotalAmount] = 0,
--				[EstimateNonResaleTaxAmount] = 0,
--				[EstimateResaleTaxAmount] = 0,
--				[EstimateMarkupAmount] = 0,
--				[EstimateCostAmount] = 0,
--				[IsEstimateNonBillable] = 0,
--				[EstimateFeeTime] = 0,
--				[EstimateNetAmount] = 0,
--				[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
--				[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
--				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
--				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
--				[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
--				[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
--				[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
--				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
--				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
--				[IsNewBusiness] = C.NEW_BUSINESS,
--				[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
--				[ProductUDF1] = P.USER_DEFINED1,
--				[ProductUDF2] = P.USER_DEFINED2,
--				[ProductUDF3] = P.USER_DEFINED3,
--				[ProductUDF4] = P.USER_DEFINED4,
--				0,0,0,0,0,0,0,0,0,
--				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
--						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) END,
--				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
--						ELSE 
--						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
--								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
--				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 - (ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0))
--						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - (ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0)) END,
--				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
--						ELSE 
--						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
--								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - (ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
--				0
--			FROM 
--				[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN 
--				[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
--				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
--				[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
--				[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND
--													 ETDC.ET_DTL_ID = ETD.ET_DTL_ID INNER JOIN 
--				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = ETD.JOB_NUMBER LEFT OUTER JOIN
--				(SELECT 
--					DISTINCT 
--					AR.AR_POST_PERIOD,
--					AR.AR_INV_NBR, 
--					AR.AR_TYPE
--				FROM 
--					[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
--													 AR.AR_TYPE = ETD.AR_TYPE INNER JOIN
--				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
--											JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR LEFT OUTER JOIN
--				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
--				[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
--				[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
--										 D.DIV_CODE = J.DIV_CODE INNER JOIN
--				[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
--										P.DIV_CODE = J.DIV_CODE AND
--										P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
--				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
--				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
--				[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
--				[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
--				[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
--				[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
--				[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
--				[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
--				[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
--				[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
--				[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
--				(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
--				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
--				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
--				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID
--			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
----			INSERT INTO #GROSS_INCOME
----			SELECT
----				[ResourceType] = 'E',
----				[JobNumber] = JC.JOB_NUMBER,
----				[JobComponentNumber] = JC.JOB_COMPONENT_NBR,
----				[OfficeCode] = JC.OFFICE_CODE,
----				[OfficeDescription] = JC.OFFICE_NAME,
----				[ClientCode] = JC.CL_CODE,
----				[ClientDescription] = JC.CL_NAME,
----				[DivisionCode] = JC.DIV_CODE,
----				[DivisionDescription] = JC.DIV_NAME,
----				[ProductCode] = JC.PRD_CODE,
----				[ProductDescription] = JC.PRD_DESCRIPTION,
----				[CampaignID] = JC.CMP_IDENTIFIER,
----				[CampaignCode] = JC.CMP_CODE, 
----				[CampaignName] = JC.CMP_NAME,
----				[SalesClassCode] = JC.SC_CODE,
----				[SalesClassDescription] = JC.SC_DESCRIPTION,
----				[UserCode] = JC.[USER_ID],
----				[JobCreateDate] = JC.CREATE_DATE,
----				[JobDescription] = JC.JOB_DESC,
----				[JobDateOpened] = JC.JOB_DATE_OPENED,
----				[RushChargesApproved] = JC.JOB_RUSH_CHARGES,
----				[ApprovedEstimateRequired] = JC.JOB_ESTIMATE_REQ,
----				[Comment] = JC.JOB_COMMENTS,
----				[ClientReference] = JC.JOB_CLI_REF,
----				[BillingCoopCode] = JC.BILL_COOP_CODE,
----				[SalesClassFormatCode] = JC.FORMAT_SC_CODE,
----				[ComplexityCode] = JC.COMPLEX_CODE,
----				[PromotionCode] = JC.PROMO_CODE,
----				[BillingComment] = JC.JOB_BILL_COMMENT,
----				[LabelFromUDFTable1] = JC.JUDV_DESC1,
----				[LabelFromUDFTable2] = JC.JUDV_DESC2,
----				[LabelFromUDFTable3] = JC.JUDV_DESC3,
----				[LabelFromUDFTable4] = JC.JUDV_DESC4,
----				[LabelFromUDFTable5] = JC.JUDV_DESC5,
----				[JobOpen] = JC.JOB_PROCESS_CONTRL,
----				[ComponentNumber] = JC.JOB_COMPONENT_NBR,
----				[JobComponent] = JC.JOB_COMP,
----				[BillHold] = JC.JOB_BILL_HOLD,
----				[AccountExecutiveCode] = JC.EMP_CODE,
----				[AccountExecutive] = JC.EMP_NAME,
----				[ComponentDateOpened] = JC.JOB_COMP_DATE,
----				[DueDate] = JC.JOB_FIRST_USE_DATE,
----				[StartDate] = JC.[START_DATE],
----				[AdSize] = JC.JOB_AD_SIZE,
----				[DepartmentTeamCode] = JC.DP_TM_CODE,
----				[DepartmentTeam] = JC.DP_TM_DESC,
----				[MarkupPercent] = JC.JOB_MARKUP_PCT,
----				[CreativeInstructions] = JC.CREATIVE_INSTR,
----				[JobProcessControl] = JC.JOB_PROCESS_DESC,
----				[ComponentDescription] = JC.JOB_COMP_DESC,
----				[ComponentComments] = JC.JOB_COMP_COMMENTS,
----				[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
----				[EstimateNumber] = JC.ESTIMATE_NUMBER,
----				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
----				[BillingUser] = JC.BILLING_USER,
----				[AdvanceBillFlag] = JC.AB_FLAG,
----				[DeliveryInstructions] = JC.JOB_DEL_INSTRUCT,
----				[JobTypeCode] = JC.JT_CODE,
----				[JobTypeDescription] = JC.JT_DESC,
----				[Taxable] = JC.TAX_FLAG,
----				[TaxCode] = JC.TAX_CODE,
----				[TaxCodeDescription] = JC.TAX_DESCRIPTION,
----				[NonBillable] = JC.NOBILL_FLAG,
----				[AlertGroup] = JC.EMAIL_GR_CODE,
----				[AdNumber] = JC.AD_NBR,
----				[AccountNumber] = JC.ACCT_NBR,
----				[IncomeRecognitionMethod] = JC.PRD_AB_INCOME,
----				[MarketCode] = JC.MARKET_CODE,
----				[MarketDescription] = JC.MARKET_DESC,
----				[ServiceFeeJob] = JC.SERVICE_FEE_FLAG,
----				[ServiceFeeTypeCode] = JC.CODE,
----				[ServiceFeeTypeDescription] = JC.[DESCRIPTION],
----				[Archived] = JC.ARCHIVE_FLAG,
----				[TrafficScheduleRequired] = JC.TRF_SCHEDULE_REQ,
----				[ClientPO] = JC.JOB_CL_PO_NBR,
----				[CompLabelFromUDFTable1] = JC.UDV_DESC1,
----				[CompLabelFromUDFTable2] = JC.UDV_DESC2,
----				[CompLabelFromUDFTable3] = JC.UDV_DESC3,
----				[CompLabelFromUDFTable4] = JC.UDV_DESC4,
----				[CompLabelFromUDFTable5] = JC.UDV_DESC5,
----				[JobTemplateCode] = JC.JOB_TMPLT_CODE,
----				[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
----				[FiscalPeriodDescription] = JC.FISCAL_PERIOD_DESC,
----				[JobQuantity] = JC.JOB_QTY,
----				[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
----				[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
--					[ClientContactCode] = JC.CONT_CODE,
--					[ClientContactID] = JC.CDP_CONTACT_ID,
----				[BABatchID] = JC.BA_BATCH_ID,
----				[ClientContact] = JC.CONT_NAME,
----				[SelectedBABatchID] = JC.SELECTED_BA_ID,
----				[BillingCommandCenterID] = JC.BCC_ID,
----				[AlertAssignmentTemplate] = JC.ALERT_NOTIFY_NAME,
----				[FunctionType] = ETD.FNC_TYPE,
----				[FunctionConsolidationCode] = ETD.FNC_CONSOLIDATION,
----				[FunctionConsolidation] = ETD.FNC_DESCRIPTION,
----				[FunctionHeading] = ETD.FNC_HEADING_DESC,
----				[FunctionCode] = ETD.FNC_CODE,
----				[FunctionDescription] = ETD.FNC_DESCRIPTION,
----				[ItemID] = ETD.ET_ID,
----				[ItemSequenceNumber] = ETD.ET_DTL_ID,
----				[ItemDate] = CASE WHEN ETD.EMP_DATE IS NOT NULL THEN ETD.EMP_DATE ELSE NULL END,
----				[PostPeriodCode] = CAST(NULL AS varchar(8)),
----				[ItemCode] = ETD.EMP_CODE,
----				[ItemDescription] = COALESCE((RTRIM(ETD.EMP_FNAME) + ' '),'') + COALESCE((ETD.EMP_MI + '. '),'') + COALESCE(ETD.EMP_LNAME,''),
----				[ItemComment] = CAST(ETD.EMP_COMMENT AS varchar(MAX)),
----				[ItemExtra] = CAST(NULL AS varchar(20)),
----				[FeeTime] = ISNULL(ETD.FEE_TIME, 0),
----				[Hours] = CASE WHEN ETD.FNC_TYPE = 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
----				[Quantity] = CASE WHEN ETD.FNC_TYPE <> 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
----				[BillableLessResale] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END,
----				[BillableTotal] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) END,
----				[ExtMarkupAmount] = ISNULL(ETD.EXT_MARKUP_AMT, 0),
----				[NonResaleTaxAmount] = 0,
----				[ResaleTaxAmount] = ISNULL(ETD.EXT_STATE_RESALE, 0) + ISNULL(ETD.EXT_COUNTY_RESALE, 0) + ISNULL(ETD.EXT_CITY_RESALE, 0),
----				[Total] = ISNULL(ETD.LINE_TOTAL, 0),
----				[CostAmount] = ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ETD.EMP_COST_RATE,0),
----				[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
----				[AccountsReceivablePostPeriodCode] = ISNULL(ETD.AR_POST_PERIOD, ''),
----				[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
----				[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
----				[AdvanceBillFlagDetail] = ETD.AB_FLAG,
----				[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
----				[GlexActBill] = ETD.GLEXACT_BILL,
----				[EstimateHours] = 0,
----				[EstimateQuantity] = 0,
----				[EstimateTotalAmount] = 0,
----				[EstimateContTotalAmount] = 0,
----				[EstimateNonResaleTaxAmount] = 0,
----				[EstimateResaleTaxAmount] = 0,
----				[EstimateMarkupAmount] = 0,
----				[EstimateCostAmount] = 0,
----				[IsEstimateNonBillable] = 0,
----				[EstimateFeeTime] = 0,
----				[EstimateNetAmount] = 0,
----				[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
----				[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
----				[BilledHours] = CASE WHEN ETD.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
----				[BilledQuantity] = CASE WHEN ETD.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
----				[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
----				[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
----				[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
----				[NonBillableHours] = CASE WHEN ETD.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
----				[NonBillableQuantity] = CASE WHEN ETD.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
----				[IsNewBusiness] = JC.NEW_BUSINESS,
----				[Agency] = CASE WHEN JC.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
----				[ProductUDF1] = JC.USER_DEFINED1,
----				[ProductUDF2] = JC.USER_DEFINED2,
----				[ProductUDF3] = JC.USER_DEFINED3,
----				[ProductUDF4] = JC.USER_DEFINED4,
----				0,0,0,0,0,0,0,0,0,
----				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
----						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) END,
----				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
----						ELSE 
----						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
----								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
----				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 - (ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ETD.EMP_COST_RATE,0))
----						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - (ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ETD.EMP_COST_RATE,0)) END,
----				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
----						ELSE 
----						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
----								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - (ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ETD.EMP_COST_RATE,0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
----				0
----FROM 
----	(SELECT 
----		JC.JOB_NUMBER,                            
----		JC.JOB_COMPONENT_NBR,                            
----		J.OFFICE_CODE,                            
----		O.OFFICE_NAME,                            
----		J.CL_CODE,                            
----		C.CL_NAME,                            
----		J.DIV_CODE,                            
----		D.DIV_NAME,                            
----		J.PRD_CODE,                            
----		P.PRD_DESCRIPTION,                            
----		CAMP.CMP_IDENTIFIER,                            
----		J.CMP_CODE,                            
----		CAMP.CMP_NAME,                            
----		J.SC_CODE,                            
----		SC.SC_DESCRIPTION,                            
----		J.[USER_ID],                            
----		J.CREATE_DATE,                            
----		J.JOB_DESC,                            
----		J.JOB_DATE_OPENED,                            
----		JOB_RUSH_CHARGES = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,                   
----		JOB_ESTIMATE_REQ = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,                   
----		JOB_COMMENTS = CAST(J.JOB_COMMENTS AS varchar(MAX)),                          
----		J.JOB_CLI_REF,                            
----		J.BILL_COOP_CODE,                            
----		J.FORMAT_SC_CODE,                            
----		J.COMPLEX_CODE,                            
----		J.PROMO_CODE,                            
----		J.JOB_BILL_COMMENT,                            
----		JUDV_DESC1 = JUDV1.UDV_DESC,                            
----		JUDV_DESC2 = JUDV2.UDV_DESC,                            
----		JUDV_DESC3 = JUDV3.UDV_DESC,                            
----		JUDV_DESC4 = JUDV4.UDV_DESC,                            
----		JUDV_DESC5 = JUDV5.UDV_DESC,                            
----		JOB_PROCESS_CONTRL = CASE WHEN JC.JOB_PROCESS_CONTRL <> 6 AND JC.JOB_PROCESS_CONTRL <> 12 THEN 'No' ELSE 'Yes' END,                                          
----		JOB_COMP = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),              
----		JOB_BILL_HOLD = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,              
----		JC.EMP_CODE,                            
----		EMP_NAME = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),                  
----		JC.JOB_COMP_DATE,                            
----		JC.JOB_FIRST_USE_DATE,                            
----		JC.[START_DATE],                            
----		JC.JOB_AD_SIZE,                            
----		JC.DP_TM_CODE,                            
----		DT.DP_TM_DESC,                            
----		JC.JOB_MARKUP_PCT,                            
----		CREATIVE_INSTR = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),                          
----		JPC.JOB_PROCESS_DESC,                            
----		JC.JOB_COMP_DESC,                            
----		JOB_COMP_COMMENTS = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),                          
----		JC.JOB_COMP_BUDGET_AM,                            
----		JC.ESTIMATE_NUMBER,                            
----		JC.EST_COMPONENT_NBR,                            
----		JC.BILLING_USER,                            
----		AB_FLAG = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,        
----		JOB_DEL_INSTRUCT = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),                          
----		JC.JT_CODE,                            
----		JT.JT_DESC,                            
----		TAX_FLAG = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,                   
----		JC.TAX_CODE,                            
----		ST.TAX_DESCRIPTION,                            
----		JC.NOBILL_FLAG,                            
----		JC.EMAIL_GR_CODE,                            
----		JC.AD_NBR,                            
----		JC.ACCT_NBR,                            
----		PRD_AB_INCOME = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,           
----		JC.MARKET_CODE,                            
----		M.MARKET_DESC,                            
----		SERVICE_FEE_FLAG = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,                   
----		SFT.CODE,                            
----		SFT.[DESCRIPTION],                            
----		ARCHIVE_FLAG = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,                   
----		TRF_SCHEDULE_REQ = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,                   
----		JC.JOB_CL_PO_NBR,                            
----		UDV_DESC1 = JCUDV1.UDV_DESC,                            
----		UDV_DESC2 = JCUDV2.UDV_DESC,                            
----		UDV_DESC3 = JCUDV3.UDV_DESC,                            
----		UDV_DESC4 = JCUDV4.UDV_DESC,                            
----		UDV_DESC5 = JCUDV5.UDV_DESC,                            
----		JC.JOB_TMPLT_CODE,                            
----		JC.FISCAL_PERIOD_CODE,                            
----		FP.FISCAL_PERIOD_DESC,                            
----		JC.JOB_QTY,                            
----		JC.BLACKPLT_VER_CODE,                            
----		JC.BLACKPLT_VER_DESC,                            
----		JC.CDP_CONTACT_ID,                            
----		CC.CONT_CODE,                            
----		JC.BA_BATCH_ID,                            
----		[CONT_NAME] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
----		JC.SELECTED_BA_ID,                            
----		JC.BCC_ID,                            
----		AA.ALERT_NOTIFY_NAME,                            
----		C.NEW_BUSINESS,                            
----		[ACL_CL_CODE] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,                           
----		P.USER_DEFINED1,                            
----		P.USER_DEFINED2,                            
----		P.USER_DEFINED3,                            
----		P.USER_DEFINED4
----	FROM
----		[dbo].[JOB_COMPONENT] AS JC INNER JOIN
----		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
----		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
----								P.DIV_CODE = J.DIV_CODE AND
----								P.PRD_CODE = J.PRD_CODE INNER JOIN
----		[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND
----								 D.DIV_CODE = P.DIV_CODE INNER JOIN
----		[dbo].[CLIENT] AS C ON C.CL_CODE = D.CL_CODE INNER JOIN
----		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
----		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE LEFT OUTER JOIN
----		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE LEFT OUTER JOIN
----		[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
----		[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
----		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
----		[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
----		[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE  LEFT OUTER JOIN
----		[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
----		[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
----		[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
----		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
----		(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
----		[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
----				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
----				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
----				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
----				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
----				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
----				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
----				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
----				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
----				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
----				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE
----	WHERE
----		J.CREATE_DATE >= @StartDate AND J.CREATE_DATE <= @EndDate) AS JC INNER JOIN
----	(SELECT
----		ETD.JOB_NUMBER,
----		ETD.JOB_COMPONENT_NBR,
----		F.FNC_CONSOLIDATION,
----		ETD.FNC_CODE,
----		F.FNC_DESCRIPTION,
----		ETD.ET_ID,
----		ETD.ET_DTL_ID,
----		ET.EMP_CODE,
----		ETD.EXT_STATE_RESALE,
----		ETD.EXT_COUNTY_RESALE,
----		ETD.EXT_CITY_RESALE,
----		ETD.EXT_MARKUP_AMT,
----		ETD.AR_INV_NBR,
----		ETD.AR_TYPE,
----		ETD.AB_FLAG,
----		ETD.EMP_NON_BILL_FLAG,
----		ETD.GLEXACT_BILL,
----		ETD.LINE_TOTAL,
----		F.FNC_TYPE,
----		ETD.FEE_TIME,
----		ETD.EMP_HOURS,
----		ET.EMP_DATE,
----		FH.FNC_HEADING_DESC,
----		FNC_DESCRIPTION_CF = CF.FNC_DESCRIPTION,
----		ET_EMP.EMP_FNAME,
----		ET_EMP.EMP_MI,
----		ET_EMP.EMP_LNAME,
----		ETDC.EMP_COMMENT,
----		AR.AR_POST_PERIOD,
----		ET_EMP.EMP_COST_RATE		
----	 FROM
----		[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN
----		[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
----		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
----		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
----									   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN
----		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
----		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
----		[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
----		[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID LEFT OUTER JOIN
----				(SELECT 
----					DISTINCT 
----					AR.AR_POST_PERIOD,
----					AR.AR_INV_NBR, 
----					AR.AR_TYPE
----				FROM 
----					[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
----													 AR.AR_TYPE = ETD.AR_TYPE LEFT OUTER JOIN
----		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
----	WHERE
----		J.CREATE_DATE >= @StartDate AND J.CREATE_DATE <= @EndDate) AS ETD ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
----																				   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR
--			--Actuals for Income only
--			INSERT INTO #GROSS_INCOME
--			SELECT [ResourceType] = 'I',
--				[JobNumber] = [IO].JOB_NUMBER,
--				[JobComponentNumber] = [IO].JOB_COMPONENT_NBR,
--				[OfficeCode] = J.OFFICE_CODE,
--				[OfficeDescription] = O.OFFICE_NAME,
--				[ClientCode] = J.CL_CODE,
--				[ClientDescription] = C.CL_NAME,
--				[DivisionCode] = J.DIV_CODE,
--				[DivisionDescription] = D.DIV_NAME,
--				[ProductCode] = J.PRD_CODE,
--				[ProductDescription] = P.PRD_DESCRIPTION,
--				[CampaignID] = CAMP.CMP_IDENTIFIER,
--				[CampaignCode] = J.CMP_CODE, 
--				[CampaignName] = CAMP.CMP_NAME,
--				[SalesClassCode] = J.SC_CODE,
--				[SalesClassDescription] = SC.SC_DESCRIPTION,
--				[UserCode] = J.[USER_ID],
--				[JobCreateDate] = J.CREATE_DATE,
--				[JobDescription] = J.JOB_DESC,
--				[JobDateOpened] = J.JOB_DATE_OPENED,
--				[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
--				[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
--				[ClientReference] = J.JOB_CLI_REF,
--				[BillingCoopCode] = J.BILL_COOP_CODE,
--				[SalesClassFormatCode] = J.FORMAT_SC_CODE,
--				[ComplexityCode] = J.COMPLEX_CODE,
--				[PromotionCode] = J.PROMO_CODE,
--				[BillingComment] = J.JOB_BILL_COMMENT,
--				[LabelFromUDFTable1] = JUDV1.UDV_DESC,
--				[LabelFromUDFTable2] = JUDV2.UDV_DESC,
--				[LabelFromUDFTable3] = JUDV3.UDV_DESC,
--				[LabelFromUDFTable4] = JUDV4.UDV_DESC,
--				[LabelFromUDFTable5] = JUDV5.UDV_DESC,
--				[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
--				[ComponentNumber] = JC.JOB_COMPONENT_NBR,
--				[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
--				[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
--				[AccountExecutiveCode] = JC.EMP_CODE,
--				[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
--				[ComponentDateOpened] = JC.JOB_COMP_DATE,
--				[DueDate] = JC.JOB_FIRST_USE_DATE,
--				[StartDate] = JC.[START_DATE],
--				[AdSize] = JC.JOB_AD_SIZE,
--				[DepartmentTeamCode] = JC.DP_TM_CODE,
--				[DepartmentTeam] = DT.DP_TM_DESC,
--				[MarkupPercent] = JC.JOB_MARKUP_PCT,
--				[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
--				[JobProcessControl] = JPC.JOB_PROCESS_DESC,
--				[ComponentDescription] = JC.JOB_COMP_DESC,
--				[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
--				[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
--				[EstimateNumber] = JC.ESTIMATE_NUMBER,
--				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
--				[BillingUser] = JC.BILLING_USER,
--				[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
--				[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
--				[JobTypeCode] = JC.JT_CODE,
--				[JobTypeDescription] = JT.JT_DESC,
--				[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TaxCode] = JC.TAX_CODE,
--				[TaxCodeDescription] = ST.TAX_DESCRIPTION,
--				[NonBillable] = JC.NOBILL_FLAG,
--				[AlertGroup] = JC.EMAIL_GR_CODE,
--				[AdNumber] = JC.AD_NBR,
--				[AccountNumber] = JC.ACCT_NBR,
--				[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
--				[MarketCode] = JC.MARKET_CODE,
--				[MarketDescription] = M.MARKET_DESC,
--				[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[ServiceFeeTypeCode] = SFT.CODE,
--				[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
--				[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[ClientPO] = JC.JOB_CL_PO_NBR,
--				[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
--				[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
--				[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
--				[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
--				[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
--				[JobTemplateCode] = JC.JOB_TMPLT_CODE,
--				[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
--				[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
--				[JobQuantity] = JC.JOB_QTY,
--				[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
--				[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
--				[ClientContactCode] = JC.PRD_CONT_CODE,
--				[ClientContactID] = JC.CDP_CONTACT_ID,
--				[BABatchID] = JC.BA_BATCH_ID,
--				[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
--				[SelectedBABatchID] = JC.SELECTED_BA_ID,
--				[BillingCommandCenterID] = JC.BCC_ID,
--				[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
--				[FunctionType] = F.FNC_TYPE,
--				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
--				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
--				[FunctionHeading] = FH.FNC_HEADING_DESC,
--				[FunctionCode] = [IO].FNC_CODE,
--				[FunctionDescription] = F.FNC_DESCRIPTION,
--				[ItemID] = [IO].IO_ID,
--				[ItemSequenceNumber] = [IO].SEQ_NBR,
--				[ItemDate] = [IO].IO_INV_DATE,
--				[PostPeriodCode] = CAST(NULL AS varchar(8)),
--				[ItemCode] = CAST(NULL AS varchar(6)),
--				[ItemDescription] = [IO].IO_DESC,
--				[ItemComment] = CAST([IO].IO_COMMENT AS varchar(MAX)),
--				[ItemExtra] = CAST(NULL AS varchar(20)),
--				[FeeTime] = 0,
--				[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
--				[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
--				[BillableLessResale] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END,
--				[BillableTotal] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL([IO].LINE_TOTAL, 0) END,
--				[ExtMarkupAmount] = ISNULL([IO].EXT_MARKUP_AMT, 0),
--				[NonResaleTaxAmount] = 0,
--				[ResaleTaxAmount] = ISNULL([IO].EXT_STATE_RESALE, 0) + ISNULL([IO].EXT_COUNTY_RESALE, 0) + ISNULL([IO].EXT_CITY_RESALE, 0),
--				[Total] = ISNULL([IO].LINE_TOTAL, 0),
--				[CostAmount] = 0,			
--				[NetAmount] = (ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)) - ISNULL([IO].EXT_MARKUP_AMT, 0),
--				[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
--				[AccountsReceivableInvoiceNumber] = [IO].AR_INV_NBR,
--				[AccountsReceivableInvoiceType] = [IO].AR_TYPE,
--				[AdvanceBillFlagDetail] = [IO].AB_FLAG,
--				[IsNonBillable] = ISNULL([IO].NON_BILL_FLAG, 0),
--				[GlexActBill] = [IO].GLEXACT_BILL,
--				[EstimateHours] = 0,
--				[EstimateQuantity] = 0,
--				[EstimateTotalAmount] = 0,
--				[EstimateContTotalAmount] = 0,
--				[EstimateNonResaleTaxAmount] = 0,
--				[EstimateResaleTaxAmount] = 0,
--				[EstimateMarkupAmount] = 0,
--				[EstimateCostAmount] = 0,
--				[IsEstimateNonBillable] = 0,
--				[EstimateFeeTime] = 0,
--				[EstimateNetAmount] = 0,
--				[BilledAmount] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
--				[BilledWithResale] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
--				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
--				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
--				[FeeTimeAmount] = 0,
--				[FeeTimeHours] = 0,
--				[NonBillableAmount] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
--				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
--				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
--				[IsNewBusiness] = C.NEW_BUSINESS,
--				[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
--				[ProductUDF1] = P.USER_DEFINED1,
--				[ProductUDF2] = P.USER_DEFINED2,
--				[ProductUDF3] = P.USER_DEFINED3,
--				[ProductUDF4] = P.USER_DEFINED4,
--				0,0,0,0,0,0,0,0,0,
--				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
--						ELSE (ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)) END,
--				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
--						ELSE 
--						CASE WHEN ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) > 0 THEN
--								(((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) / ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
--				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
--						ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END,				
--				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
--						ELSE 100 END,
--				0
--			FROM 
--				[dbo].[INCOME_ONLY] AS [IO] INNER JOIN 
--				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE  INNER JOIN 
--				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = [IO].JOB_NUMBER LEFT OUTER JOIN
--				(SELECT 
--					DISTINCT 
--					AR.AR_POST_PERIOD,
--					AR.AR_INV_NBR, 
--					AR.AR_TYPE
--				FROM 
--					[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = [IO].AR_INV_NBR AND 
--													 AR.AR_TYPE = [IO].AR_TYPE INNER JOIN
--				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
--											JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR LEFT OUTER JOIN
--				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
--				[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
--				[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
--										 D.DIV_CODE = J.DIV_CODE INNER JOIN
--				[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
--										P.DIV_CODE = J.DIV_CODE AND
--										P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
--				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
--				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
--				[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
--				[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
--				[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
--				[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
--				[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
--				[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
--				[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
--				[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
--				[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
--				(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
--				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
--				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
--				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID
--			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
--			--Acutals for Vendors
--			INSERT INTO #GROSS_INCOME
--			SELECT [ResourceType] = 'V',
--				[JobNumber] = APP.JOB_NUMBER,
--				[JobComponentNumber] = APP.JOB_COMPONENT_NBR,
--				[OfficeCode] = J.OFFICE_CODE,
--				[OfficeDescription] = O.OFFICE_NAME,
--				[ClientCode] = J.CL_CODE,
--				[ClientDescription] = C.CL_NAME,
--				[DivisionCode] = J.DIV_CODE,
--				[DivisionDescription] = D.DIV_NAME,
--				[ProductCode] = J.PRD_CODE,
--				[ProductDescription] = P.PRD_DESCRIPTION,
--				[CampaignID] = CAMP.CMP_IDENTIFIER,
--				[CampaignCode] = J.CMP_CODE, 
--				[CampaignName] = CAMP.CMP_NAME,
--				[SalesClassCode] = J.SC_CODE,
--				[SalesClassDescription] = SC.SC_DESCRIPTION,
--				[UserCode] = J.[USER_ID],
--				[JobCreateDate] = J.CREATE_DATE,
--				[JobDescription] = J.JOB_DESC,
--				[JobDateOpened] = J.JOB_DATE_OPENED,
--				[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
--				[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
--				[ClientReference] = J.JOB_CLI_REF,
--				[BillingCoopCode] = J.BILL_COOP_CODE,
--				[SalesClassFormatCode] = J.FORMAT_SC_CODE,
--				[ComplexityCode] = J.COMPLEX_CODE,
--				[PromotionCode] = J.PROMO_CODE,
--				[BillingComment] = J.JOB_BILL_COMMENT,
--				[LabelFromUDFTable1] = JUDV1.UDV_DESC,
--				[LabelFromUDFTable2] = JUDV2.UDV_DESC,
--				[LabelFromUDFTable3] = JUDV3.UDV_DESC,
--				[LabelFromUDFTable4] = JUDV4.UDV_DESC,
--				[LabelFromUDFTable5] = JUDV5.UDV_DESC,
--				[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
--				[ComponentNumber] = JC.JOB_COMPONENT_NBR,
--				[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
--				[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
--				[AccountExecutiveCode] = JC.EMP_CODE,
--				[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
--				[ComponentDateOpened] = JC.JOB_COMP_DATE,
--				[DueDate] = JC.JOB_FIRST_USE_DATE,
--				[StartDate] = JC.[START_DATE],
--				[AdSize] = JC.JOB_AD_SIZE,
--				[DepartmentTeamCode] = JC.DP_TM_CODE,
--				[DepartmentTeam] = DT.DP_TM_DESC,
--				[MarkupPercent] = JC.JOB_MARKUP_PCT,
--				[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
--				[JobProcessControl] = JPC.JOB_PROCESS_DESC,
--				[ComponentDescription] = JC.JOB_COMP_DESC,
--				[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
--				[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
--				[EstimateNumber] = JC.ESTIMATE_NUMBER,
--				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
--				[BillingUser] = JC.BILLING_USER,
--				[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
--				[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
--				[JobTypeCode] = JC.JT_CODE,
--				[JobTypeDescription] = JT.JT_DESC,
--				[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TaxCode] = JC.TAX_CODE,
--				[TaxCodeDescription] = ST.TAX_DESCRIPTION,
--				[NonBillable] = JC.NOBILL_FLAG,
--				[AlertGroup] = JC.EMAIL_GR_CODE,
--				[AdNumber] = JC.AD_NBR,
--				[AccountNumber] = JC.ACCT_NBR,
--				[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
--				[MarketCode] = JC.MARKET_CODE,
--				[MarketDescription] = M.MARKET_DESC,
--				[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[ServiceFeeTypeCode] = SFT.CODE,
--				[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
--				[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
--				[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
--				[ClientPO] = JC.JOB_CL_PO_NBR,
--				[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
--				[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
--				[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
--				[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
--				[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
--				[JobTemplateCode] = JC.JOB_TMPLT_CODE,
--				[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
--				[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
--				[JobQuantity] = JC.JOB_QTY,
--				[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
--				[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
--				[ClientContactCode] = JC.PRD_CONT_CODE,
--				[ClientContactID] = JC.CDP_CONTACT_ID,
--				[BABatchID] = JC.BA_BATCH_ID,
--				[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
--				[SelectedBABatchID] = JC.SELECTED_BA_ID,
--				[BillingCommandCenterID] = JC.BCC_ID,
--				[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
--				[FunctionType] = F.FNC_TYPE,
--				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
--				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
--				[FunctionHeading] = FH.FNC_HEADING_DESC,
--				[FunctionCode] = APP.FNC_CODE,
--				[FunctionDescription] = F.FNC_DESCRIPTION,
--				[ItemID] = APP.AP_ID,
--				[ItemSequenceNumber] = APP.AP_SEQ,
--				[ItemDate] = APH.AP_INV_DATE,
--				[PostPeriodCode] = APP.POST_PERIOD,
--				[ItemCode] = APH.VN_FRL_EMP_CODE,
--				[ItemDescription] = V.VN_NAME + ' (' + APH.VN_FRL_EMP_CODE + ')',
--				[ItemComment] = CAST(NULL AS varchar(MAX)),
--				[ItemExtra] = APH.AP_INV_VCHR,
--				[FeeTime] = 0,
--				[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
--				[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
--				[BillableLessResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) END,
--				[BillableTotal] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(APP.LINE_TOTAL, 0) END,
--				[ExtMarkupAmount] = ISNULL(APP.EXT_MARKUP_AMT, 0),
--				[NonResaleTaxAmount] = ISNULL(APP.EXT_NONRESALE_TAX, 0),
--				[ResaleTaxAmount] = ISNULL(APP.EXT_STATE_RESALE, 0) + ISNULL(APP.EXT_COUNTY_RESALE, 0) + ISNULL(APP.EXT_CITY_RESALE, 0),
--				[Total] = ISNULL(APP.LINE_TOTAL, 0),
--				[CostAmount] = APP.AP_PROD_EXT_AMT,
--				[NetAmount] = (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - ISNULL(APP.EXT_MARKUP_AMT, 0),
--				[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
--				[AccountsReceivableInvoiceNumber] = APP.AR_INV_NBR,
--				[AccountsReceivableInvoiceType] = APP.AR_TYPE,
--				[AdvanceBillFlagDetail] = APP.AB_FLAG,
--				[IsNonBillable] = ISNULL(APP.AP_PROD_NOBILL_FLG, 0),
--				[GlexActBill] = APP.GLEXACT_BILL,
--				[EstimateHours] = 0,
--				[EstimateQuantity] = 0,
--				[EstimateTotalAmount] = 0,
--				[EstimateContTotalAmount] = 0,
--				[EstimateNonResaleTaxAmount] = 0,
--				[EstimateResaleTaxAmount] = 0,
--				[EstimateMarkupAmount] = 0,
--				[EstimateCostAmount] = 0,
--				[IsEstimateNonBillable] = 0,
--				[EstimateFeeTime] = 0,
--				[EstimateNetAmount] = 0,
--				[BilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
--				[BilledWithResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
--				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
--				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
--				[FeeTimeAmount] = 0,
--				[FeeTimeHours] = 0,
--				[NonBillableAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
--				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
--				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
--				[IsNewBusiness] = C.NEW_BUSINESS,
--				[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
--				[ProductUDF1] = P.USER_DEFINED1,
--				[ProductUDF2] = P.USER_DEFINED2,
--				[ProductUDF3] = P.USER_DEFINED3,
--				[ProductUDF4] = P.USER_DEFINED4,
--				0,0,0,0,0,0,0,0,0,
--				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
--						ELSE (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0)) END,
--				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
--						ELSE 
--						CASE WHEN ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0))) > 0 THEN
--								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
--				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 - ISNULL(APP.AP_PROD_EXT_AMT, 0)
--						ELSE ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - (ISNULL(APP.AP_PROD_EXT_AMT, 0)) END,
--				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0
--						ELSE
--						CASE WHEN (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) > 0 THEN
--								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.AP_PROD_EXT_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,						
--				0
--			FROM 
--				[dbo].[AP_PRODUCTION] AS APP INNER JOIN 
--				[dbo].[AP_HEADER] AS APH ON APH.AP_ID = APP.AP_ID AND 
--									   APH.AP_SEQ = APP.AP_SEQ INNER JOIN 
--				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = APP.FNC_CODE INNER JOIN 
--				[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE LEFT JOIN 
--				[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = APP.AP_ID AND 
--												   APC.LINE_NUMBER = APP.LINE_NUMBER INNER JOIN 
--				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = APP.JOB_NUMBER LEFT OUTER JOIN
--				(SELECT 
--					DISTINCT 
--					AR.AR_POST_PERIOD,
--					AR.AR_INV_NBR, 
--					AR.AR_TYPE
--				FROM 
--					[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = APP.AR_INV_NBR AND 
--													 AR.AR_TYPE = APP.AR_TYPE INNER JOIN
--				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = APP.JOB_NUMBER AND
--											JC.JOB_COMPONENT_NBR = APP.JOB_COMPONENT_NBR LEFT OUTER JOIN
--				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
--				[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
--				[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
--										 D.DIV_CODE = J.DIV_CODE INNER JOIN
--				[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
--										P.DIV_CODE = J.DIV_CODE AND
--										P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
--				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
--				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
--				[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
--				[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
--				[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
--				[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
--				[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
--				[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
--				[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
--				[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
--				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
--				[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
--				(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
--				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
--				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
--				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID
--			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
--		End
		If @DateType = 1
		Begin						
			--Get Job data for dateType
			INSERT INTO #JOB_INCOME
			SELECT
				[ResourceType] = 'E',
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
				[CampaignID] = CAMP.CMP_IDENTIFIER,
				[CampaignCode] = J.CMP_CODE, 
				[CampaignName] = CAMP.CMP_NAME,
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
				[SalesClassFormatCode] = J.FORMAT_CODE,
				[ComplexityCode] = J.COMPLEX_CODE,
				[ComplexityDescription] = CMPL.COMPLEX_DESC,
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
				[ComponentDateOpened] = JC.JOB_COMP_DATE,
				[DueDate] = JC.JOB_FIRST_USE_DATE,
				[StartDate] = JC.[START_DATE],
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
				[Taxable] = CASE WHEN JC.TAX_FLAG IS NULL THEN ''
								 WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
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
				[ClientContactCode] = JC.PRD_CONT_CODE,
				[ClientContactID] = JC.CDP_CONTACT_ID,
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
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
								P.DIV_CODE = J.DIV_CODE AND
								P.PRD_CODE = J.PRD_CODE INNER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND
								 D.DIV_CODE = P.DIV_CODE INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = D.CL_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE LEFT OUTER JOIN
		[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
		[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
		[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
		[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE  LEFT OUTER JOIN
		[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
		[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
		[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
		[dbo].[COMPLEXITY] AS CMPL ON J.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN
		(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
		[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE
			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
			--Estimate data based on an existing estimate approval				
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'ES',
				[JobNumber] = EA.JOB_NUMBER,
				[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
			FROM 
				[dbo].[ESTIMATE_APPROVAL] AS EA INNER JOIN 
				[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
												   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
												   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
												   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'ES',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber
			--Estimate data based on as existing internal estimate approval	
			DELETE FROM #EST_INCOME		
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'EI',
				[JobNumber] = EIA.JOB_NUMBER,
				[JobComponentNumber] = EIA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
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
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EIA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'EI',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber		
			--Actual data--
			--Employee data
			INSERT INTO #FUNC_INCOME
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
				[ItemDate] = CASE WHEN ET.EMP_DATE IS NOT NULL THEN ET.EMP_DATE ELSE NULL END,
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = ET.EMP_CODE,
				[ItemDescription] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,''),
				--[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
				[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
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
				[CostAmount] = CASE WHEN @Standard = 1 THEN ISNULL(ETD.TOTAL_COST,0) ELSE ISNULL(ETD.ALT_COST_AMT,0) END,  --ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0),
				[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
				[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
				[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
				[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
				[AdvanceBillFlagDetail] = ETD.AB_FLAG,
				[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
				[GlexActBill] = ETD.GLEXACT_BILL,
				[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
				[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN  
						CASE WHEN @Standard = 1 THEN 0 - ISNULL(ETD.TOTAL_COST,0) ELSE 0 - ISNULL(ETD.ALT_COST_AMT,0) END
						ELSE 
							CASE WHEN @Standard = 1 THEN (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0) 
								ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0) END
							  END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
							CASE WHEN @Standard = 1 THEN (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 
							ELSE (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 END
						ELSE 0 END
				END,
				0,
				[EmployeeCode] = ET.EMP_CODE,
				[EmployeeName] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,'')
			FROM 
				[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN
				[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
				[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
				--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND ETDC.SEQ_NBR = ETD.SEQ_NBR LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
															 AR.AR_TYPE = ETD.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate				
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = FI.ResourceType,
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Vendor data
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[ItemComment] = CAST(NULL AS varchar(MAX)),
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
				[BilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 - ISNULL(APP.AP_PROD_EXT_AMT, 0)
						ELSE ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - (ISNULL(APP.AP_PROD_EXT_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0
						ELSE
						CASE WHEN (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.AP_PROD_EXT_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,						
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[AP_PRODUCTION] AS APP INNER JOIN 
				[dbo].[AP_HEADER] AS APH ON APH.AP_ID = APP.AP_ID AND 
									   APH.AP_SEQ = APP.AP_SEQ INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = APP.FNC_CODE INNER JOIN 
				[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = APP.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = APP.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT JOIN 
				[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = APP.AP_ID AND 
												   APC.LINE_NUMBER = APP.LINE_NUMBER LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = APP.AR_INV_NBR AND 
															 AR.AR_TYPE = APP.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'V',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Actuals for Income only
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) / ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END,				
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 100 END,
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[INCOME_ONLY] AS [IO] INNER JOIN  
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = [IO].AR_INV_NBR AND 
															 AR.AR_TYPE = [IO].AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'I',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Advance BIlling
			DELETE FROM #FUNC_INCOME	
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[ADVANCE_BILLING] AS AB INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = AB.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = AB.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = AB.AR_INV_NBR AND 
															 AR.AR_TYPE = AB.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE J.CREATE_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'AB',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber									
		End
		If @DateType = 2
		Begin			
			--Get Job data for dateType
			INSERT INTO #JOB_INCOME
			SELECT
				[ResourceType] = 'E',
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
				[CampaignID] = CAMP.CMP_IDENTIFIER,
				[CampaignCode] = J.CMP_CODE, 
				[CampaignName] = CAMP.CMP_NAME,
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
				[SalesClassFormatCode] = J.FORMAT_CODE,
				[ComplexityCode] = J.COMPLEX_CODE,
				[ComplexityDescription] = CMPL.COMPLEX_DESC,
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
				[ComponentDateOpened] = JC.JOB_COMP_DATE,
				[DueDate] = JC.JOB_FIRST_USE_DATE,
				[StartDate] = JC.[START_DATE],
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
				[ClientContactCode] = JC.PRD_CONT_CODE,
				[ClientContactID] = JC.CDP_CONTACT_ID,
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
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
								P.DIV_CODE = J.DIV_CODE AND
								P.PRD_CODE = J.PRD_CODE INNER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND
								 D.DIV_CODE = P.DIV_CODE INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = D.CL_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE LEFT OUTER JOIN
		[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
		[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
		[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
		[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE  LEFT OUTER JOIN
		[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
		[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
		[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
		[dbo].[COMPLEXITY] AS CMPL ON J.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN
		(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE
			WHERE JC.JOB_COMP_DATE BETWEEN @StartDate and @EndDate	
			--Estimate data based on an existing estimate approval				
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'ES',
				[JobNumber] = EA.JOB_NUMBER,
				[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
			FROM 
				[dbo].[ESTIMATE_APPROVAL] AS EA INNER JOIN 
				[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
												   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
												   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
												   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE JC.JOB_COMP_DATE BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'ES',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber
			--Estimate data based on as existing internal estimate approval	
			DELETE FROM #EST_INCOME		
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'EI',
				[JobNumber] = EIA.JOB_NUMBER,
				[JobComponentNumber] = EIA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
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
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EIA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE JC.JOB_COMP_DATE BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'EI',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber		
			--Actual data--
			--Employee data
			INSERT INTO #FUNC_INCOME
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
				[ItemDate] = CASE WHEN ET.EMP_DATE IS NOT NULL THEN ET.EMP_DATE ELSE NULL END,
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = ET.EMP_CODE,
				[ItemDescription] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,''),
				--[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
				[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
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
				[CostAmount] = CASE WHEN @Standard = 1 THEN ISNULL(ETD.TOTAL_COST,0) ELSE ISNULL(ETD.ALT_COST_AMT,0) END,  --ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0),
				[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
				[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
				[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
				[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
				[AdvanceBillFlagDetail] = ETD.AB_FLAG,
				[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
				[GlexActBill] = ETD.GLEXACT_BILL,
				[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
				[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN  
						CASE WHEN @Standard = 1 THEN 0 - ISNULL(ETD.TOTAL_COST,0) ELSE 0 - ISNULL(ETD.ALT_COST_AMT,0) END
						ELSE 
							CASE WHEN @Standard = 1 THEN (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0) 
								ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0) END
							  END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
							CASE WHEN @Standard = 1 THEN (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 
							ELSE (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 END
						ELSE 0 END
				END,
				0,
				[EmployeeCode] = ET.EMP_CODE,
				[EmployeeName] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,'')
			FROM 
				[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN
				[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
				[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
				--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND ETDC.SEQ_NBR = ETD.SEQ_NBR LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
															 AR.AR_TYPE = ETD.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_COMP_DATE BETWEEN @StartDate and @EndDate				
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = FI.ResourceType,
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Vendor data
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[ItemComment] = CAST(NULL AS varchar(MAX)),
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
				[BilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 - ISNULL(APP.AP_PROD_EXT_AMT, 0)
						ELSE ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - (ISNULL(APP.AP_PROD_EXT_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0
						ELSE
						CASE WHEN (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.AP_PROD_EXT_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,						
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[AP_PRODUCTION] AS APP INNER JOIN 
				[dbo].[AP_HEADER] AS APH ON APH.AP_ID = APP.AP_ID AND 
									   APH.AP_SEQ = APP.AP_SEQ INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = APP.FNC_CODE INNER JOIN 
				[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = APP.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = APP.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT JOIN 
				[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = APP.AP_ID AND 
												   APC.LINE_NUMBER = APP.LINE_NUMBER LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = APP.AR_INV_NBR AND 
															 AR.AR_TYPE = APP.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_COMP_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'V',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Actuals for Income only
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) / ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END,				
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 100 END,
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[INCOME_ONLY] AS [IO] INNER JOIN  
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = [IO].AR_INV_NBR AND 
															 AR.AR_TYPE = [IO].AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_COMP_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'I',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Advance BIlling
			DELETE FROM #FUNC_INCOME	
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[ADVANCE_BILLING] AS AB INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = AB.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = AB.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = AB.AR_INV_NBR AND 
															 AR.AR_TYPE = AB.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_COMP_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'AB',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber		
		End
		If @DateType = 3
		Begin			
			--Get Job data for dateType
			INSERT INTO #JOB_INCOME
			SELECT
				[ResourceType] = 'E',
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
				[CampaignID] = CAMP.CMP_IDENTIFIER,
				[CampaignCode] = J.CMP_CODE, 
				[CampaignName] = CAMP.CMP_NAME,
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
				[SalesClassFormatCode] = J.FORMAT_CODE,
				[ComplexityCode] = J.COMPLEX_CODE,
				[ComplexityDescription] = CMPL.COMPLEX_DESC,
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
				[ComponentDateOpened] = JC.JOB_COMP_DATE,
				[DueDate] = JC.JOB_FIRST_USE_DATE,
				[StartDate] = JC.[START_DATE],
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
				[Taxable] = CASE WHEN JC.TAX_FLAG IS NULL THEN ''
								 WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
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
				[ClientContactCode] = JC.PRD_CONT_CODE,
				[ClientContactID] = JC.CDP_CONTACT_ID,
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
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
								P.DIV_CODE = J.DIV_CODE AND
								P.PRD_CODE = J.PRD_CODE INNER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND
								 D.DIV_CODE = P.DIV_CODE INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = D.CL_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE LEFT OUTER JOIN
		[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
		[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
		[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
		[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE  LEFT OUTER JOIN
		[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
		[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
		[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
		[dbo].[COMPLEXITY] AS CMPL ON J.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN
		(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE
			WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate	
			--Estimate data based on an existing estimate approval				
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'ES',
				[JobNumber] = EA.JOB_NUMBER,
				[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
			FROM 
				[dbo].[ESTIMATE_APPROVAL] AS EA INNER JOIN 
				[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
												   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
												   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
												   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'ES',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber
			--Estimate data based on as existing internal estimate approval	
			DELETE FROM #EST_INCOME		
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'EI',
				[JobNumber] = EIA.JOB_NUMBER,
				[JobComponentNumber] = EIA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
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
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EIA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'EI',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber		
			--Actual data--
			--Employee data
			INSERT INTO #FUNC_INCOME
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
				[ItemDate] = CASE WHEN ET.EMP_DATE IS NOT NULL THEN ET.EMP_DATE ELSE NULL END,
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = ET.EMP_CODE,
				[ItemDescription] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,''),
				--[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
				[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
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
				[CostAmount] = CASE WHEN @Standard = 1 THEN ISNULL(ETD.TOTAL_COST,0) ELSE ISNULL(ETD.ALT_COST_AMT,0) END,  --ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0),
				[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
				[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
				[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
				[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
				[AdvanceBillFlagDetail] = ETD.AB_FLAG,
				[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
				[GlexActBill] = ETD.GLEXACT_BILL,
				[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
				[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN  
						CASE WHEN @Standard = 1 THEN 0 - ISNULL(ETD.TOTAL_COST,0) ELSE 0 - ISNULL(ETD.ALT_COST_AMT,0) END
						ELSE 
							CASE WHEN @Standard = 1 THEN (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0) 
								ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0) END
							  END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
							CASE WHEN @Standard = 1 THEN (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 
							ELSE (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 END
						ELSE 0 END
				END,
				0,
				[EmployeeCode] = ET.EMP_CODE,
				[EmployeeName] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,'')
			FROM 
				[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN
				[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
				[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
				--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND ETDC.SEQ_NBR = ETD.SEQ_NBR LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
															 AR.AR_TYPE = ETD.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate				
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = FI.ResourceType,
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Vendor data
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[ItemComment] = CAST(NULL AS varchar(MAX)),
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
				[BilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 - ISNULL(APP.AP_PROD_EXT_AMT, 0)
						ELSE ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - (ISNULL(APP.AP_PROD_EXT_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0
						ELSE
						CASE WHEN (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.AP_PROD_EXT_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,						
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[AP_PRODUCTION] AS APP INNER JOIN 
				[dbo].[AP_HEADER] AS APH ON APH.AP_ID = APP.AP_ID AND 
									   APH.AP_SEQ = APP.AP_SEQ INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = APP.FNC_CODE INNER JOIN 
				[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = APP.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = APP.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT JOIN 
				[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = APP.AP_ID AND 
												   APC.LINE_NUMBER = APP.LINE_NUMBER LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = APP.AR_INV_NBR AND 
															 AR.AR_TYPE = APP.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'V',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Actuals for Income only
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) / ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END,				
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 100 END,
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[INCOME_ONLY] AS [IO] INNER JOIN  
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = [IO].AR_INV_NBR AND 
															 AR.AR_TYPE = [IO].AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'I',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Advance BIlling
			DELETE FROM #FUNC_INCOME	
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[ADVANCE_BILLING] AS AB INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = AB.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = AB.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = AB.AR_INV_NBR AND 
															 AR.AR_TYPE = AB.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate and @EndDate		
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'AB',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
		End
		If @DateType = 4
		Begin			
			--Get Job data for dateType
			INSERT INTO #JOB_INCOME
			SELECT
				[ResourceType] = 'E',
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
				[CampaignID] = CAMP.CMP_IDENTIFIER,
				[CampaignCode] = J.CMP_CODE, 
				[CampaignName] = CAMP.CMP_NAME,
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
				[SalesClassFormatCode] = J.FORMAT_CODE,
				[ComplexityCode] = J.COMPLEX_CODE,
				[ComplexityDescription] = CMPL.COMPLEX_DESC,
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
				[ComponentDateOpened] = JC.JOB_COMP_DATE,
				[DueDate] = JC.JOB_FIRST_USE_DATE,
				[StartDate] = JC.[START_DATE],
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
				[Taxable] = CASE WHEN JC.TAX_FLAG IS NULL THEN ''
								 WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
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
				[ClientContactCode] = JC.PRD_CONT_CODE,
				[ClientContactID] = JC.CDP_CONTACT_ID,
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
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
								P.DIV_CODE = J.DIV_CODE AND
								P.PRD_CODE = J.PRD_CODE INNER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND
								 D.DIV_CODE = P.DIV_CODE INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = D.CL_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE LEFT OUTER JOIN
		[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
		[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
		[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
		[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE  LEFT OUTER JOIN
		[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
		[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
		[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
		[dbo].[COMPLEXITY] AS CMPL ON J.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN
		(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
				[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
				[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE
			WHERE JC.[START_DATE] BETWEEN @StartDate and @EndDate	
			--Estimate data based on an existing estimate approval				
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'ES',
				[JobNumber] = EA.JOB_NUMBER,
				[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
			FROM 
				[dbo].[ESTIMATE_APPROVAL] AS EA INNER JOIN 
				[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER AND 
												   ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
												   ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
												   ERD.EST_REV_NBR = EA.EST_REVISION_NBR INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ERD.FNC_CODE INNER JOIN
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE JC.[START_DATE] BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'ES',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber
			--Estimate data based on as existing internal estimate approval	
			DELETE FROM #EST_INCOME		
			INSERT INTO #EST_INCOME
				SELECT [ResourceType] = 'EI',
				[JobNumber] = EIA.JOB_NUMBER,
				[JobComponentNumber] = EIA.JOB_COMPONENT_NBR,
				[EstimateNumber] = JC.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
				[FunctionType] = F.FNC_TYPE,
				[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
				[FunctionConsolidation] = CF.FNC_DESCRIPTION,
				[FunctionHeading] = FH.FNC_HEADING_DESC,
				[FunctionCode] = ERD.FNC_CODE,
				[FunctionDescription] = F.FNC_DESCRIPTION,
				[ItemDescription] = 'Estimate Amount',
				[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
				[EstimateTotalAmount] = ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateContTotalAmount] = ISNULL(ERD.LINE_TOTAL_CONT, 0),
				[EstimateNonResaleTaxAmount] = ISNULL(ERD.EXT_NONRESALE_TAX, 0),
				[EstimateResaleTaxAmount] = ISNULL(ERD.EXT_STATE_RESALE, 0) + ISNULL(ERD.EXT_COUNTY_RESALE, 0) + ISNULL(ERD.EXT_CITY_RESALE, 0),
				[EstimateMarkupAmount] = ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimateCostAmount] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END,
				[IsEstimateNonBillable] = 0,
				[EstimateFeeTime] = 0,
				[EstimateNetAmount] = (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0),
				[EstimatedGrossIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))  
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedGrossIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncome] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercent] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				[EstimatedIncomeHist] = CASE WHEN F.FNC_TYPE = 'V' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))  
										    WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0)) 
											WHEN F.FNC_TYPE = 'I' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) ELSE 0 END,
				[EstimatedIncomePercentHist] = CASE WHEN F.FNC_TYPE = 'V' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END  
										             WHEN F.FNC_TYPE = 'E' THEN 
														CASE WHEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) > 0 THEN 
															(((ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - (ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0))) / (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0))) * 100 ELSE 0 END														 
													 WHEN F.FNC_TYPE = 'I' THEN 100 ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = CASE WHEN F.FNC_TYPE = 'E' THEN ERD.EST_REV_SUP_BY_CDE ELSE NULL END,
				[EmployeeName] = COALESCE((RTRIM(EMP1.EMP_FNAME) + ' '),'') + COALESCE((EMP1.EMP_MI + '. '),'') + COALESCE(EMP1.EMP_LNAME,''),
				[EstimatedCostAmountHist] = CASE WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
										    WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * COALESCE(ERH.COST_RATE,EMP1.EMP_COST_RATE,0) 
											WHEN F.FNC_TYPE = 'I' THEN 0 ELSE 0 END
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
				[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = EIA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR INNER JOIN 
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
				[dbo].EMPLOYEE_CLOAK EMP1 ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE LEFT OUTER JOIN
				[dbo].V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER AND
											VEA.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].EMP_RATE_HISTORY ERH ON ERH.EMP_CODE = EMP1.EMP_CODE AND
											  VEA.CL_EST_APPR_DATE BETWEEN ERH.[START_DATE] AND ERH.END_DATE
			WHERE JC.[START_DATE] BETWEEN @StartDate and @EndDate			
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'EI',
				[JobNumber] = EI.JobNumber,
				[JobComponentNumber] = EI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = EI.FunctionType,
				[FunctionConsolidationCode] = EI.FunctionConsolidationCode,
				[FunctionConsolidation] = EI.FunctionConsolidation,
				[FunctionHeading] = EI.FunctionHeading,
				[FunctionCode] = EI.FunctionCode,
				[FunctionDescription] = EI.FunctionDescription,
				[ItemID] = 0,
				[ItemSequenceNumber] = 0,
				[ItemDate] = CAST(NULL AS smalldatetime),
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = CAST(NULL AS varchar(6)),
				[ItemDescription] = EI.ItemDescription,
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
				[EstimateHours] = EI.EstimatedHours,
				[EstimateQuantity] = EI.EstimatedQuantity,
				[EstimateTotalAmount] = EI.EstimatedTotalAmount,
				[EstimateContTotalAmount] = EI.EstimateContTotalAmount,
				[EstimateNonResaleTaxAmount] = EI.EstimateNonResaleTaxAmount,
				[EstimateResaleTaxAmount] = EI.EstimateResaleTaxAmount,
				[EstimateMarkupAmount] = EI.EstimateMarkupAmount,
				[EstimateCostAmount] = EI.EstimatedCostAmount,
				[IsEstimateNonBillable] = EI.IsEstimateNonBillable,
				[EstimateFeeTime] = EI.EstimateFeeTime,
				[EstimateNetAmount] = EI.EstimateNetAmount,
				[BilledAmount] = 0,
				[BilledWithResale] = 0,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				[EstimatedGrossIncome] = EI.EstimatedGrossIncome,
				[EstimatedGrossIncomePercent] = EI.EstimatedGrossIncomePercent,
				[EstimatedIncome] = EI.EstimatedIncome,
				[EstimatedIncomePercent] = EI.EstimatedIncomePercent,
				[EstimatedIncomeHist] = EI.EstimatedIncomeHist,
				[EstimatedIncomePercentHist] = EI.EstimatedIncomePercentHist,
				0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = EI.EmployeeCode,
				[EmployeeName] = EI.EmployeeName,
				[EstimatedCostAmountHist] = EI.EstimatedCostAmountHist 
			FROM 
				#EST_INCOME EI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = EI.JobNumber 
														 AND JI.JobComponentNumber = EI.JobComponentNumber		
			--Actual data--
			--Employee data
			INSERT INTO #FUNC_INCOME
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
				[ItemDate] = CASE WHEN ET.EMP_DATE IS NOT NULL THEN ET.EMP_DATE ELSE NULL END,
				[PostPeriodCode] = CAST(NULL AS varchar(8)),
				[ItemCode] = ET.EMP_CODE,
				[ItemDescription] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,''),
				--[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
				[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
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
				[CostAmount] = CASE WHEN @Standard = 1 THEN ISNULL(ETD.TOTAL_COST,0) ELSE ISNULL(ETD.ALT_COST_AMT,0) END,  --ISNULL(ETD.EMP_HOURS, 0) * ISNULL(ET_EMP.EMP_COST_RATE,0),
				[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
				[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
				[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
				[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
				[AdvanceBillFlagDetail] = ETD.AB_FLAG,
				[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
				[GlexActBill] = ETD.GLEXACT_BILL,
				[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
				[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN  
						CASE WHEN @Standard = 1 THEN 0 - ISNULL(ETD.TOTAL_COST,0) ELSE 0 - ISNULL(ETD.ALT_COST_AMT,0) END
						ELSE 
							CASE WHEN @Standard = 1 THEN (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0) 
								ELSE (ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0) END
							  END,
				CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0))) > 0 THEN
							CASE WHEN @Standard = 1 THEN (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.TOTAL_COST,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 
							ELSE (((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)) - ISNULL(ETD.ALT_COST_AMT,0)) / ((ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0)))) * 100 END
						ELSE 0 END
				END,
				0,
				[EmployeeCode] = ET.EMP_CODE,
				[EmployeeName] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,'')
			FROM 
				[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN
				[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
				[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
				--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND ETDC.SEQ_NBR = ETD.SEQ_NBR LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
															 AR.AR_TYPE = ETD.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.[START_DATE] BETWEEN @StartDate and @EndDate				
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = FI.ResourceType,
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Vendor data
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[ItemComment] = CAST(NULL AS varchar(MAX)),
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
				[BilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - ISNULL(APP.EXT_MARKUP_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 - ISNULL(APP.AP_PROD_EXT_AMT, 0)
						ELSE ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) - (ISNULL(APP.AP_PROD_EXT_AMT, 0)) END,
				CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0
						ELSE
						CASE WHEN (ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) > 0 THEN
								(((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)) - (ISNULL(APP.AP_PROD_EXT_AMT, 0))) / ((ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,						
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[AP_PRODUCTION] AS APP INNER JOIN 
				[dbo].[AP_HEADER] AS APH ON APH.AP_ID = APP.AP_ID AND 
									   APH.AP_SEQ = APP.AP_SEQ INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = APP.FNC_CODE INNER JOIN 
				[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = APP.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = APP.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT JOIN 
				[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = APP.AP_ID AND 
												   APC.LINE_NUMBER = APP.LINE_NUMBER LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = APP.AR_INV_NBR AND 
															 AR.AR_TYPE = APP.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.[START_DATE] BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'V',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Actuals for Income only
			DELETE FROM #FUNC_INCOME
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
				[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
				0,0,0,0,0,0,0,0,0,0,0,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE (ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)) END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 
						CASE WHEN ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) > 0 THEN
								(((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0))) / ((ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)))) * 100 ELSE 0 END END,
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END,				
				CASE WHEN ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 
						ELSE 100 END,
				0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[INCOME_ONLY] AS [IO] INNER JOIN  
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = [IO].AR_INV_NBR AND 
															 AR.AR_TYPE = [IO].AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.[START_DATE] BETWEEN @StartDate and @EndDate	
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'I',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
			--Advance BIlling
			DELETE FROM #FUNC_INCOME	
			INSERT INTO #FUNC_INCOME
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
				[BilledAmount] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) ELSE 0 END,
				[BilledWithResale] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) ELSE 0 END,
				[BilledHours] = 0,
				[BilledQuantity] = 0,
				[FeeTimeAmount] = 0,
				[FeeTimeHours] = 0,
				[NonBillableAmount] = 0,
				[NonBillableHours] = 0,
				[NonBillableQuantity] = 0,
				0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
				[EmployeeCode] = null,
				[EmployeeName] = null
			FROM 
				[dbo].[ADVANCE_BILLING] AS AB INNER JOIN 
				[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE INNER JOIN 
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = AB.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = AB.JOB_COMPONENT_NBR INNER JOIN
				[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = AB.AR_INV_NBR AND 
															 AR.AR_TYPE = AB.AR_TYPE LEFT OUTER JOIN
				[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
			WHERE JC.[START_DATE] BETWEEN @StartDate and @EndDate		
			INSERT INTO #GROSS_INCOME
			SELECT
				[ResourceType] = 'AB',
				[JobNumber] = FI.JobNumber,
				[JobComponentNumber] = FI.JobComponentNumber,
				[OfficeCode] = JI.OfficeCode,
				[OfficeDescription] = JI.OfficeDescription,
				[ClientCode] = JI.ClientCode,
				[ClientDescription] = JI.ClientDescription,
				[DivisionCode] = JI.DivisionCode,
				[DivisionDescription] = JI.DivisionDescription,
				[ProductCode] = JI.ProductCode,
				[ProductDescription] = JI.ProductDescription,
				[CampaignID] = JI.CampaignID,
				[CampaignCode] = JI.CampaignCode, 
				[CampaignName] = JI.CampaignDescription,
				[SalesClassCode] = JI.SalesClassCode,
				[SalesClassDescription] = JI.SalesClassDescription,
				[UserCode] = JI.UserCode,
				[JobCreateDate] = JI.JobCreateDate,
				[JobDescription] = JI.JobDescription,
				[JobDateOpened] = JI.JobDateOpened,
				[RushChargesApproved] = JI.RushChargesApproved,
				[ApprovedEstimateRequired] = JI.ApprovedEstimateRequired,
				[Comment] = JI.Comment,
				[ClientReference] = JI.ClientReference,
				[BillingCoopCode] = JI.BillingCoopCode,
				[SalesClassFormatCode] = JI.SalesClassFormatCode,
				[ComplexityCode] = JI.ComplexityCode,
				[ComplexityDescription] = JI.ComplexityDescription,
				[PromotionCode] = JI.PromotionCode,
				[BillingComment] = JI.BillingComment,
				[LabelFromUDFTable1] = JI.LabelFromUDFTable1,
				[LabelFromUDFTable2] = JI.LabelFromUDFTable2,
				[LabelFromUDFTable3] = JI.LabelFromUDFTable3,
				[LabelFromUDFTable4] = JI.LabelFromUDFTable4,
				[LabelFromUDFTable5] = JI.LabelFromUDFTable5,
				[JobOpen] = JI.JobOpen,
				[ComponentNumber] = JI.ComponentNumber,
				[JobComponent] = JI.JobComponent,
				[BillHold] = JI.BillHold,
				[AccountExecutiveCode] = JI.AccountExecutiveCode,
				[AccountExecutive] = JI.AccountExecutive,
				[ComponentDateOpened] = JI.ComponentDateOpened,
				[DueDate] = JI.DueDate,
				[StartDate] = JI.StartDate,
				[AdSize] = JI.AdSize,
				[DepartmentTeamCode] = JI.DepartmentTeamCode,
				[DepartmentTeam] = JI.DepartmentTeam,
				[MarkupPercent] = JI.MarkupPercent,
				[CreativeInstructions] = JI.CreativeInstructions,
				[JobProcessControl] = JI.JobProcessControl,
				[ComponentDescription] = JI.ComponentDescription,
				[ComponentComments] = JI.ComponentComments,
				[ComponentBudget] = JI.ComponentBudget,
				[EstimateNumber] = JI.EstimateNumber,
				[EstimateComponentNumber] = JI.EstimateComponentNumber,
				[BillingUser] = JI.BillingUser,
				[AdvanceBillFlag] = JI.AdvanceBillFlag,
				[DeliveryInstructions] = JI.DeliveryInstructions,
				[JobTypeCode] = JI.JobTypeCode,
				[JobTypeDescription] = JI.JobTypeDescription,
				[Taxable] = JI.Taxable,
				[TaxCode] = JI.TaxCode,
				[TaxCodeDescription] = JI.TaxCodeDescription,
				[NonBillable] = JI.NonBillable,
				[AlertGroup] = JI.AlertGroup,
				[AdNumber] = JI.AdNumber,
				[AccountNumber] = JI.AccountNumber,
				[IncomeRecognitionMethod] = JI.IncomeRecognitionMethod,
				[MarketCode] = JI.MarketCode,
				[MarketDescription] = JI.MarketDescription,
				[ServiceFeeJob] = JI.ServiceFeeJob,
				[ServiceFeeTypeCode] = JI.ServiceFeeTypeCode,
				[ServiceFeeTypeDescription] = JI.ServiceFeeTypeDescription,
				[Archived] = JI.Archived,
				[TrafficScheduleRequired] = JI.TrafficScheduleRequired,
				[ClientPO] = JI.ClientPO,
				[CompLabelFromUDFTable1] = JI.CompLabelFromUDFTable1,
				[CompLabelFromUDFTable2] = JI.CompLabelFromUDFTable2,
				[CompLabelFromUDFTable3] = JI.CompLabelFromUDFTable3,
				[CompLabelFromUDFTable4] = JI.CompLabelFromUDFTable4,
				[CompLabelFromUDFTable5] = JI.CompLabelFromUDFTable5,
				[JobTemplateCode] = JI.JobTemplateCode,
				[FiscalPeriodCode] = JI.FiscalPeriodCode,
				[FiscalPeriodDescription] = JI.FiscalPeriodDescription,
				[JobQuantity] = JI.JobQuantity,
				[BlackplateVersionCode] = JI.BlackplateVersionCode,
				[BlackplateVersionDesc] = JI.BlackplateVersionDesc,
				[ClientContactCode] = JI.ClientContactCode,
				[ClientContactID] = JI.ClientContactID,
				[BABatchID] = JI.BABatchID,
				[ClientContact] = JI.ClientContact,
				[SelectedBABatchID] = JI.SelectedBABatchID,
				[BillingCommandCenterID] = JI.BillingCommandCenterID,
				[AlertAssignmentTemplate] = JI.AlertAssignmentTemplate,
				[FunctionType] = FI.FunctionType,
				[FunctionConsolidationCode] = FI.FunctionConsolidationCode,
				[FunctionConsolidation] = FI.FunctionConsolidation,
				[FunctionHeading] = FI.FunctionHeading,
				[FunctionCode] = FI.FunctionCode,
				[FunctionDescription] = FI.FunctionDescription,
				[ItemID] = FI.ItemID,
				[ItemSequenceNumber] = FI.ItemSequenceNumber,
				[ItemDate] = FI.ItemDate,
				[PostPeriodCode] = FI.PostPeriodCode,
				[ItemCode] = FI.ItemCode,
				[ItemDescription] = FI.ItemDescription,
				[ItemComment] = FI.ItemComment,
				[ItemExtra] = FI.ItemExtra,
				[FeeTime] = FI.FeeTime,
				[Hours] = FI.[Hours],
				[Quantity] = FI.Quantity,
				[BillableLessResale] = FI.BillableLessResale,
				[BillableTotal] = FI.BillableTotal,
				[ExtMarkupAmount] = FI.ExtMarkupAmount,
				[NonResaleTaxAmount] = FI.NonResaleTaxAmount,
				[ResaleTaxAmount] = FI.ResaleTaxAmount,
				[Total] = FI.Total,
				[CostAmount] = FI.CostAmount,
				[NetAmount] = FI.NetAmount,
				[AccountsReceivablePostPeriodCode] = FI.AccountsReceivablePostPeriodCode,
				[AccountsReceivableInvoiceNumber] = FI.AccountsReceivableInvoiceNumber,
				[AccountsReceivableInvoiceType] = FI.AccountsReceivableInvoiceType,
				[AdvanceBillFlagDetail] = FI.AdvanceBillFlagDetail,
				[IsNonBillable] = FI.IsNonBillable,
				[GlexActBill] = FI.GlexActBill,
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
				[BilledAmount] = FI.BilledAmount,
				[BilledWithResale] = FI.BilledWithResale,
				[BilledHours] = FI.BilledHours,
				[BilledQuantity] = FI.BilledQuantity,
				[FeeTimeAmount] = FI.FeeTimeAmount,
				[FeeTimeHours] = FI.FeeTimeHours,
				[NonBillableAmount] = FI.NonBillableAmount,
				[NonBillableHours] = FI.NonBillableHours,
				[NonBillableQuantity] = FI.NonBillableQuantity,
				[IsNewBusiness] = JI.IsNewBusiness,
				[Agency] = JI.Agency,
				[ProductUDF1] = JI.ProductUDF1,
				[ProductUDF2] = JI.ProductUDF2,
				[ProductUDF3] = JI.ProductUDF3,
				[ProductUDF4] = JI.ProductUDF4,
				0,0,0,0,0,0,0,0,0,0,0,
				FI.ActualGrossIncome,
				FI.ActualGrossIncomePercent,
				FI.ActualIncome,
				FI.ActualIncomePercent,
				FI.SeqNbr,
				FI.EmployeeCode,
				FI.EmployeeName,
				[EstimatedCostAmountHist] = 0
			FROM 
				#FUNC_INCOME FI LEFT OUTER JOIN #JOB_INCOME JI ON JI.JobNumber = FI.JobNumber 
														 AND JI.JobComponentNumber = FI.JobComponentNumber	
		End
        

		INSERT INTO #PROJECT_TASK_LIST
		SELECT  V_JOB_TRAFFIC_DET.JOB_NUMBER, V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, V_JOB_TRAFFIC_DET.SEQ_NBR, V_JOB_TRAFFIC_DET.FNC_EST,
		 V_JOB_TRAFFIC_DET.TASK_START_DATE, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, V_JOB_TRAFFIC_DET.EMP_CODE, ISNULL(E.EMP_COST_RATE,0), ISNULL(V_JOB_TRAFFIC_DET.JOB_HRS,0), 0, 0, 0
		FROM   V_JOB_TRAFFIC_DET INNER JOIN JOB_COMPONENT ON V_JOB_TRAFFIC_DET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
				INNER JOIN #jobs ON V_JOB_TRAFFIC_DET.JOB_NUMBER = #jobs.JOB_NUMBER AND V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = #jobs.JOB_COMPONENT_NBR LEFT OUTER JOIN
				EMPLOYEE E ON E.EMP_CODE = V_JOB_TRAFFIC_DET.EMP_CODE
		WHERE   JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)
		ORDER BY V_JOB_TRAFFIC_DET.TASK_START_DATE

		----TEST
        DECLARE @DAY_COUNT      AS INTEGER,
				@DAY_INCREMENT  AS INTEGER,
				@ADJ_HOURS AS DECIMAL(15,2),
				@IS_WORK_DAY AS INTEGER,
				@WORK_DAYS_TODAY AS DECIMAL(15,5),
				@WORK_DAYS_TOTAL AS DECIMAL(15,5)
        DECLARE @CURR_JOB_NUMBER AS INT,
	        @CURR_JOB_COMPONENT_NBR     INT,
	        @CURR_SEQ_NBR     INT,
	        @CURR_EST_FUNC     VARCHAR(6),
	        @CURR_START_DATE     SMALLDATETIME,
	        @CURR_END_DATE     SMALLDATETIME,
	        @CURR_EMP_CODE     VARCHAR(6),
	        @CURR_HOURS_ALLOWED     DECIMAL(15,2),
			@CURR_ACTUAL_HOURS     DECIMAL(15,2),
			@CURR_ACTUAL_AMT     DECIMAL(15,4),
			@SUM_ACTUAL_HOURS     DECIMAL(15,2),
	        @CURR_BILL_RATE     DECIMAL(15,3),
			@CURR_ROW_ID		INT,
	        @CURR_CL_CODE   VARCHAR(6),
	        @CURR_DIV_CODE     VARCHAR(6),
	        @CURR_PRD_CODE     VARCHAR(6),
	        @CURR_SC_CODE     VARCHAR(6),
			@CURR_DAY_OF_WEEK SMALLINT,	
			@CURR_EMP_COST_RATE  DECIMAL(9,2),		
			@ROW_BILLING_RATE  DECIMAL(9,2),
			@ROW_RATE_LEVEL  SMALLINT,
			@ROW_TAX_CODE  VARCHAR(4),
			@ROW_TAX_LEVEL SMALLINT,
			@ROW_NOBILL_FLAG SMALLINT,
			@ROW_NOBILL_LEVEL SMALLINT,
			@ROW_COMM DECIMAL(9,3),
			@ROW_COMM_LEVEL SMALLINT,
			@ROW_TAX_COMM SMALLINT,
			@ROW_TAX_COMM_ONLY SMALLINT,
			@ROW_TAX_COMM_FLAGS_LEVEL SMALLINT,
			@ROW_FEE_TIME_FLAG SMALLINT,
			@ROW_FEE_TIME_LEVEL SMALLINT
			;
        DECLARE MY_ROWS                         CURSOR  
        FOR
	        SELECT ROW_ID
	        FROM   #PROJECT_TASK_LIST
        ;
        OPEN MY_ROWS;
        FETCH NEXT FROM MY_ROWS INTO @CURR_ROW_ID;
        WHILE @@FETCH_STATUS = 0
        BEGIN
	        SELECT @CURR_JOB_NUMBER = JOB_NUMBER, @CURR_JOB_COMPONENT_NBR = JOB_COMPONENT_NBR,
	        @CURR_SEQ_NBR = SEQ_NBR, 
	        @CURR_EST_FUNC = EST_FUNC,
	        @CURR_START_DATE = [START_DATE], 
	        @CURR_END_DATE = END_DATE,
	        @CURR_EMP_CODE = EMP_CODE,
	        @CURR_EMP_COST_RATE = EMP_COST_RATE, 
	        @CURR_HOURS_ALLOWED = HOURS_ALLOWED FROM #PROJECT_TASK_LIST WHERE ROW_ID = @CURR_ROW_ID;
			SET @CURR_ACTUAL_HOURS = 0
			SELECT @CURR_CL_CODE = CL_CODE, @CURR_DIV_CODE = DIV_CODE, @CURR_PRD_CODE = PRD_CODE, @CURR_SC_CODE = SC_CODE
			FROM JOB_LOG 
			WHERE JOB_NUMBER = @CURR_JOB_NUMBER
			-- GET DAYS (LOOP)
					--=================================================================================================
								                
					SET @DAY_INCREMENT = -1;
					--SELECT @DAY_COUNT = DATEDIFF(dd, @CURR_START_DATE, @CURR_END_DATE) + 1;
			        --SET @ADJ_HOURS = @CURR_HOURS_ALLOWED / [dbo].[wvfn_get_emp_workday_count](@CURR_EMP_CODE,@CURR_START_DATE,@CURR_END_DATE,1)
					EXECUTE dbo.usp_wv_Estimating_GetBillingRates
									@THIS_FNC_CODE = @CURR_EST_FUNC,
									@THIS_JOB_NUMBER = @CURR_JOB_NUMBER,
									@THIS_JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR,
									@THIS_CL_CODE = @CURR_CL_CODE,
									@THIS_DIV_CODE = @CURR_DIV_CODE,
									@THIS_PRD_CODE = @CURR_PRD_CODE,
									@THIS_SC_CODE = @CURR_SC_CODE,
									@THIS_EMP_CODE = @CURR_EMP_CODE,
									@THIS_EMP_TITLE_ID = NULL,  
									@THIS_BILLING_RATE = @ROW_BILLING_RATE OUTPUT,
									@THIS_RATE_LEVEL = @ROW_RATE_LEVEL OUTPUT,
									@THIS_TAX_CODE = @ROW_TAX_CODE OUTPUT,
									@THIS_TAX_LEVEL = @ROW_TAX_LEVEL OUTPUT,
									@THIS_NOBILL_FLAG = @ROW_NOBILL_FLAG OUTPUT,
									@THIS_NOBILL_LEVEL = @ROW_NOBILL_LEVEL OUTPUT,
									@THIS_COMM = @ROW_COMM OUTPUT,
									@THIS_COMM_LEVEL = @ROW_COMM_LEVEL OUTPUT,
									@THIS_TAX_COMM = @ROW_TAX_COMM OUTPUT,
									@THIS_TAX_COMM_ONLY = @ROW_TAX_COMM_ONLY OUTPUT,
									@THIS_TAX_COMM_FLAGS_LEVEL = @ROW_TAX_COMM_FLAGS_LEVEL OUTPUT,
									@THIS_FEE_TIME_FLAG = @ROW_FEE_TIME_FLAG OUTPUT,
									@THIS_FEE_TIME_LEVEL = @ROW_FEE_TIME_LEVEL OUTPUT;
						
			SELECT @CURR_ACTUAL_HOURS = ISNULL(SUM(EMP_TIME_DTL.EMP_HOURS),0),
			 @CURR_ACTUAL_AMT = SUM(ISNULL(EMP_TIME_DTL.LINE_TOTAL, 0) - ISNULL(EMP_TIME_DTL.EXT_STATE_RESALE, 0) - ISNULL(EMP_TIME_DTL.EXT_COUNTY_RESALE, 0) - ISNULL(EMP_TIME_DTL.EXT_CITY_RESALE, 0))
			FROM EMP_TIME_DTL INNER JOIN
                 EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID INNER JOIN
                 V_JOB_TRAFFIC_DET ON EMP_TIME_DTL.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER AND 
                 EMP_TIME_DTL.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND 
                 EMP_TIME_DTL.FNC_CODE = V_JOB_TRAFFIC_DET.FNC_EST AND EMP_TIME.EMP_CODE = V_JOB_TRAFFIC_DET.EMP_CODE
			WHERE (V_JOB_TRAFFIC_DET.JOB_NUMBER = @CURR_JOB_NUMBER) AND (V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR)
				  AND (V_JOB_TRAFFIC_DET.SEQ_NBR = @CURR_SEQ_NBR) AND (EMP_TIME.EMP_CODE = @CURR_EMP_CODE) AND (EMP_TIME_DTL.EMP_HOURS <> 0)

			UPDATE #PROJECT_TASK_LIST SET ACTUAL_HOURS = @CURR_ACTUAL_HOURS, ACTUAL_AMT = @CURR_ACTUAL_AMT, BILL_RATE = @ROW_BILLING_RATE
			WHERE (JOB_NUMBER = @CURR_JOB_NUMBER) AND (JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR)
				  AND (SEQ_NBR = @CURR_SEQ_NBR) AND (EMP_CODE = @CURR_EMP_CODE)		

	        --GO TO NEXT EVENT
	        FETCH NEXT FROM MY_ROWS INTO @CURR_ROW_ID;
        END
        CLOSE MY_ROWS;
        DEALLOCATE MY_ROWS;
		--SELECT * FROM #PROJECT_TASK_LIST
  		--Quoted Hours
		DECLARE @HAS_EST_APPR   AS INTEGER,
				@HAS_EST_INT_APPR  AS INTEGER,
				@QUOTED_HOURS AS DECIMAL(15,2),
				@FORECAST_HOURS AS DECIMAL(15,2),
				@FORECAST_AMT AS DECIMAL(15,2),
				@FORECAST_HOURS_AE AS DECIMAL(15,2),
				@FORECAST_AMT_AE AS DECIMAL(15,2),
				@NumberRecords int, @RowCount int, @jn int, @jcn int, @client varchar(40), @ae varchar(6), @sd datetime, @ed datetime, @jcd varchar(60), @status varchar(30), @perc_schedule decimal(15,5),
				@CURR_DATE         SMALLDATETIME,
				@CTR               INT,
				@WORKING_DAYS      DECIMAL(15,2),
				@TOTAL_DAYS		   DECIMAL(15,2), @perc_comp decimal(7,3)
						
		INSERT INTO #GROSS_INCOME 
		SELECT  'PS', PTL.JOB_NUMBER, PTL.JOB_COMPONENT_NBR, JL.OFFICE_CODE AS OfficeCode, O.OFFICE_NAME AS OfficeDescription, JL.CL_CODE AS ClientCode,C.CL_NAME AS ClientDescription,JL.DIV_CODE AS DivisionCode,D.DIV_NAME AS DivisionDescription,JL.PRD_CODE AS ProductCode,
				P.PRD_DESCRIPTION AS ProductDescription,CMP.CMP_IDENTIFIER AS CampaignID, JL.CMP_CODE AS CampaignCode, CMP.CMP_NAME AS CampaignName, 
                    JL.SC_CODE AS SalesClassCode, SC.SC_DESCRIPTION AS SalesClassDescription, JL.[USER_ID] AS UserCode, JL.CREATE_DATE AS JobCreateDate,JL.JOB_DESC AS JobDescription, JL.JOB_DATE_OPENED AS JobDateOpened,
					[RushChargesApproved] = CASE WHEN JL.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
					[ApprovedEstimateRequired] = CASE WHEN JL.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
					[Comment] = CAST(JL.JOB_COMMENTS AS varchar(MAX)),
					[ClientReference] = JL.JOB_CLI_REF,
					[BillingCoopCode] = JL.BILL_COOP_CODE,
					[SalesClassFormatCode] = JL.FORMAT_CODE,
					[ComplexityCode] = JL.COMPLEX_CODE,
					[ComplexityDescription] = CMPL.COMPLEX_DESC,
					[PromotionCode] = JL.PROMO_CODE,
					[BillingComment] = JL.JOB_BILL_COMMENT,
					[LabelFromUDFTable1] = JUDV1.UDV_DESC,
					[LabelFromUDFTable2] = JUDV2.UDV_DESC,
					[LabelFromUDFTable3] = JUDV3.UDV_DESC,
					[LabelFromUDFTable4] = JUDV4.UDV_DESC,
					[LabelFromUDFTable5] = JUDV5.UDV_DESC,
					[JobOpen] = CASE WHEN JL.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
					[ComponentNumber] = PTL.JOB_COMPONENT_NBR,
					[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), PTL.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), PTL.JOB_COMPONENT_NBR), 2),
					[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,		
					JC.EMP_CODE AS AccountExecutiveCode, COALESCE (RTRIM(EMP.EMP_FNAME) + ' ', '') + COALESCE (EMP.EMP_MI + '. ', '') + COALESCE (EMP.EMP_LNAME, '') AS AccountExecutive,  
					[ComponentDateOpened] = JC.JOB_COMP_DATE,JC.JOB_FIRST_USE_DATE AS DueDate,
					[StartDate] = JC.[START_DATE],
					[AdSize] = JC.JOB_AD_SIZE,
					[DepartmentTeamCode] = JC.DP_TM_CODE,
					[DepartmentTeam] = DT.DP_TM_DESC,
					[MarkupPercent] = JC.JOB_MARKUP_PCT,
					[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
					[JobProcessControl] = JPC.JOB_PROCESS_DESC, 
					JC.JOB_COMP_DESC AS ComponentDescription,
					[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
					[ComponentBudget] = JC.JOB_COMP_BUDGET_AM, JC.ESTIMATE_NUMBER, JC.EST_COMPONENT_NBR,
					[BillingUser] = JC.BILLING_USER,
					[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
					[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
					[JobTypeCode] = JC.JT_CODE,
					[JobTypeDescription] = JT.JT_DESC,
					[Taxable] = CASE WHEN JC.TAX_FLAG IS NULL THEN ''
								     WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
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
					[ClientContactCode] = JC.PRD_CONT_CODE,
					[ClientContactID] = JC.CDP_CONTACT_ID,
					[BABatchID] = JC.BA_BATCH_ID,
					[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
					[SelectedBABatchID] = JC.SELECTED_BA_ID,
					[BillingCommandCenterID] = JC.BCC_ID,
					[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
					F.FNC_TYPE, F.FNC_CONSOLIDATION, CF.FNC_DESCRIPTION, FH.FNC_HEADING_DESC, PTL.EST_FUNC, F.FNC_DESCRIPTION,
					[ItemID] = 0,
					[ItemSequenceNumber] = 0,
					[ItemDate] = CAST(NULL AS smalldatetime),
					[PostPeriodCode] = CAST(NULL AS varchar(8)),
					[ItemCode] = CAST(NULL AS varchar(6)),
					[ItemDescription] = 'PS Amount',
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
					[BilledAmount] = 0,
					[BilledWithResale] = 0,
					[BilledHours] = 0,
					[BilledQuantity] = 0,
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
					[NonBillableQuantity] = 0,
					[IsNewBusiness] = C.NEW_BUSINESS,
					[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
					[ProductUDF1] = P.USER_DEFINED1,
					[ProductUDF2] = P.USER_DEFINED2,
					[ProductUDF3] = P.USER_DEFINED3,
					[ProductUDF4] = P.USER_DEFINED4,
                    0,0,0,0, SUM(PTL.HOURS_ALLOWED), SUM(PTL.HOURS_ALLOWED * PTL.BILL_RATE), SUM(PTL.HOURS_ALLOWED * PTL.EMP_COST_RATE),
					CASE WHEN SUM(PTL.HOURS_ALLOWED * PTL.BILL_RATE) > 0 THEN SUM(PTL.HOURS_ALLOWED * PTL.BILL_RATE) - SUM(PTL.HOURS_ALLOWED * PTL.EMP_COST_RATE) ELSE 0 END,
					CASE WHEN SUM(PTL.HOURS_ALLOWED * PTL.BILL_RATE) > 0 THEN ((SUM(PTL.HOURS_ALLOWED * PTL.BILL_RATE) - SUM(PTL.HOURS_ALLOWED * PTL.EMP_COST_RATE)) / SUM(PTL.HOURS_ALLOWED * PTL.BILL_RATE)) * 100 ELSE 0 END,
                    0,0,0,0,0,0,0,
					[EmployeeCode] = null,
					[EmployeeName] = null,
					[EstimatedCostAmountHist] = 0
	    FROM #PROJECT_TASK_LIST PTL INNER JOIN
			 JOB_COMPONENT AS JC ON JC.JOB_NUMBER = PTL.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = PTL.JOB_COMPONENT_NBR INNER JOIN
			 JOB_LOG AS JL ON JL.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
			 PRODUCT AS P ON JL.PRD_CODE = P.PRD_CODE AND JL.DIV_CODE = P.DIV_CODE AND JL.CL_CODE = P.CL_CODE INNER JOIN
			 DIVISION AS D ON JL.DIV_CODE = D.DIV_CODE AND JL.CL_CODE = D.CL_CODE INNER JOIN
			 CLIENT AS C ON JL.CL_CODE = C.CL_CODE INNER JOIN
			 SALES_CLASS AS SC ON JL.SC_CODE = SC.SC_CODE INNER JOIN
			 EMPLOYEE_CLOAK AS EMP ON JC.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN
			 CAMPAIGN AS CMP ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER INNER JOIN
			 FUNCTIONS AS F ON PTL.EST_FUNC = F.FNC_CODE LEFT OUTER JOIN
			 FNC_HEADING AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			 OFFICE AS O ON O.OFFICE_CODE = JL.OFFICE_CODE LEFT OUTER JOIN
		     DEPT_TEAM AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
		     CDP_CONTACT_HDR AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
		     JOB_PROC_CONTROLS AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
		     JOB_TYPE AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
		     SALES_TAX AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
		     MARKET AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
		     FISCAL_PERIOD AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
		     ALERT_NOTIFY_HDR AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
			 JOB_LOG_UDV1 AS JUDV1 ON JUDV1.UDV_CODE = JL.UDV1_CODE LEFT OUTER JOIN
			 JOB_LOG_UDV2 AS JUDV2 ON JUDV2.UDV_CODE = JL.UDV2_CODE LEFT OUTER JOIN
			 JOB_LOG_UDV3 AS JUDV3 ON JUDV3.UDV_CODE = JL.UDV3_CODE LEFT OUTER JOIN
			 JOB_LOG_UDV4 AS JUDV4 ON JUDV4.UDV_CODE = JL.UDV4_CODE LEFT OUTER JOIN
			 JOB_LOG_UDV5 AS JUDV5 ON JUDV5.UDV_CODE = JL.UDV5_CODE LEFT OUTER JOIN
			 JOB_CMP_UDV1 AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
			 JOB_CMP_UDV2 AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
			 JOB_CMP_UDV3 AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
			 JOB_CMP_UDV4 AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
			 JOB_CMP_UDV5 AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN
			 COMPLEXITY AS CMPL ON JL.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN 
		     SERVICE_FEE_TYPE AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
			 (SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
		     FUNCTIONS AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
		GROUP BY PTL.JOB_NUMBER, PTL.JOB_COMPONENT_NBR, PTL.EST_FUNC, F.FNC_DESCRIPTION, JL.OFFICE_CODE, O.OFFICE_NAME,JL.CL_CODE,C.CL_NAME,JL.DIV_CODE,D.DIV_NAME,JL.PRD_CODE,
				P.PRD_DESCRIPTION,CMP.CMP_IDENTIFIER, JL.CMP_CODE, CMP.CMP_NAME, JL.SC_CODE, SC.SC_DESCRIPTION, JL.[USER_ID], JL.CREATE_DATE,JL.JOB_DESC, JL.JOB_DATE_OPENED,
					JL.JOB_RUSH_CHARGES,
					JL.JOB_ESTIMATE_REQ,
					CAST(JL.JOB_COMMENTS AS varchar(MAX)),
					JL.JOB_CLI_REF,
					JL.BILL_COOP_CODE,
					JL.FORMAT_CODE,
					JL.COMPLEX_CODE,
					CMPL.COMPLEX_DESC,
					JL.PROMO_CODE,
					JL.JOB_BILL_COMMENT,
					JUDV1.UDV_DESC,
					JUDV2.UDV_DESC,
					JUDV3.UDV_DESC,
					JUDV4.UDV_DESC,
					JUDV5.UDV_DESC,
					JL.COMP_OPEN,										
					JC.JOB_BILL_HOLD,		
					JC.EMP_CODE, EMP.EMP_FNAME,EMP.EMP_MI,EMP.EMP_LNAME,  
					JC.JOB_COMP_DATE,JC.JOB_FIRST_USE_DATE,
					JC.[START_DATE],
					JC.JOB_AD_SIZE,
					JC.DP_TM_CODE,
					DT.DP_TM_DESC,
					JC.JOB_MARKUP_PCT,
					CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
					JPC.JOB_PROCESS_DESC, 
					JC.JOB_COMP_DESC,
					CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
					JC.JOB_COMP_BUDGET_AM, JC.ESTIMATE_NUMBER, JC.EST_COMPONENT_NBR,
					JC.BILLING_USER,
					JC.AB_FLAG,
					CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
					JC.JT_CODE,
					JT.JT_DESC,
					JC.TAX_FLAG ,
					JC.TAX_CODE,
					ST.TAX_DESCRIPTION,
					JC.NOBILL_FLAG,
					JC.EMAIL_GR_CODE,
					JC.AD_NBR,
					JC.ACCT_NBR,
					JC.PRD_AB_INCOME,
					JC.MARKET_CODE,
					M.MARKET_DESC,
					JC.SERVICE_FEE_FLAG,
					SFT.CODE,
					SFT.[DESCRIPTION],
					JC.ARCHIVE_FLAG,
					JC.TRF_SCHEDULE_REQ,
					JC.JOB_CL_PO_NBR,
					JCUDV1.UDV_DESC,
					JCUDV2.UDV_DESC,
					JCUDV3.UDV_DESC,
					JCUDV4.UDV_DESC,
					JCUDV5.UDV_DESC,
					JC.JOB_TMPLT_CODE,
					JC.FISCAL_PERIOD_CODE,
					FP.FISCAL_PERIOD_DESC,
					JC.JOB_QTY,
					JC.BLACKPLT_VER_CODE,
					JC.BLACKPLT_VER_DESC,
					JC.CDP_CONTACT_ID,
					JC.PRD_CONT_CODE,
					JC.BA_BATCH_ID,
					CC.CONT_MI,CC.CONT_FNAME,CC.CONT_LNAME,
					JC.SELECTED_BA_ID,
					JC.BCC_ID,
					AA.ALERT_NOTIFY_NAME,
					F.FNC_TYPE, F.FNC_CONSOLIDATION, CF.FNC_DESCRIPTION, FH.FNC_HEADING_DESC,
					C.NEW_BUSINESS,
					ACL.CL_CODE,
					P.USER_DEFINED1,
					P.USER_DEFINED2,
					P.USER_DEFINED3,
					P.USER_DEFINED4
		
		INSERT INTO #GROSS_INCOME_TOTAL
				SELECT [JobNumber]
				  ,[JobComponentNumber]
				  ,[OfficeCode]
				  ,[OfficeDescription]
				  ,[ClientCode]
				  ,[ClientDescription]
				  ,[DivisionCode]
				  ,[DivisionDescription]
				  ,[ProductCode]
				  ,[ProductDescription]
				  ,[CampaignID]
				  ,[CampaignCode]
				  ,[CampaignDescription]
				  ,[SalesClassCode]
				  ,[SalesClassDescription]
				  ,[UserCode]
				  ,[JobCreateDate]
				  ,[JobDescription]
				  ,[JobDateOpened]
				  ,[RushChargesApproved]
				  ,[ApprovedEstimateRequired]
				  ,[Comment]
				  ,[ClientReference]
				  ,[BillingCoopCode]
				  ,[SalesClassFormatCode]
				  ,[ComplexityCode]
				  ,[ComplexityDescription]
				  ,[PromotionCode]
				  ,[BillingComment]
				  ,[LabelFromUDFTable1]
				  ,[LabelFromUDFTable2]
				  ,[LabelFromUDFTable3]
				  ,[LabelFromUDFTable4]
				  ,[LabelFromUDFTable5]
				  ,[JobOpen]
				  ,[ComponentNumber]
				  ,[JobComponent]
				  ,[BillHold]
				  ,[AccountExecutiveCode]
				  ,[AccountExecutive]
				  ,[ComponentDateOpened]
				  ,[DueDate]
				  ,[StartDate]
				  ,[AdSize]
				  ,[DepartmentTeamCode]
				  ,[DepartmentTeam]
				  ,[MarkupPercent]
				  ,[CreativeInstructions]
				  ,[JobProcessControl]
				  ,[ComponentDescription]
				  ,[ComponentComments]
				  ,[ComponentBudget]
				  ,[EstimateNumber]
				  ,[EstimateComponentNumber]
				  ,[BillingUser]
				  ,[AdvanceBillFlag]
				  ,[DeliveryInstructions]
				  ,[JobTypeCode]
				  ,[JobTypeDescription]
				  ,[Taxable]
				  ,[TaxCode]
				  ,[TaxCodeDescription]
				  ,[NonBillable]
				  ,[AlertGroup]
				  ,[AdNumber]
				  ,[AccountNumber]
				  ,[IncomeRecognitionMethod]
				  ,[MarketCode]
				  ,[MarketDescription]
				  ,[ServiceFeeJob]
				  ,[ServiceFeeTypeCode]
				  ,[ServiceFeeTypeDescription]
				  ,[Archived]
				  ,[TrafficScheduleRequired]
				  ,[ClientPO]
				  ,[CompLabelFromUDFTable1]
				  ,[CompLabelFromUDFTable2]
				  ,[CompLabelFromUDFTable3]
				  ,[CompLabelFromUDFTable4]
				  ,[CompLabelFromUDFTable5]
				  ,[JobTemplateCode]
				  ,[FiscalPeriodCode]
				  ,[FiscalPeriodDescription]
				  ,[JobQuantity]
				  ,[BlackplateVersionCode]
				  ,[BlackplateVersionDesc]
				  ,[ClientContactCode]
				  ,[ClientContactID]
				  ,[BABatchID]
				  ,[ClientContact]
				  ,[SelectedBABatchID]
				  ,[BillingCommandCenterID]
				  ,[AlertAssignmentTemplate]
				  ,[FunctionType]
				  ,[FunctionConsolidationCode]
				  ,[FunctionConsolidation]
				  ,[FunctionHeading]
				  ,[FunctionCode]
				  ,[FunctionDescription]
				  --,[ItemID]
				  --,[ItemSequenceNumber]
				  --,[ItemDate]
				  --,[PostPeriodCode]
				  --,[ItemCode]
				  --,[ItemDescription]
				  --,[ItemComment]
				  --,[ItemExtra]
				  --,SUM([FeeTime])
				  ,SUM([Hours])
				  ,SUM([Quantity])
				  ,SUM([BillableLessResale])
				  --,SUM([BillableTotal])
				  ,SUM([ExtMarkupAmount])
				  --,SUM([NonResaleTaxAmount])
				  --,SUM([ResaleTaxAmount])
				  ,SUM([Total])
				  ,SUM([CostAmount])
				  ,SUM([NetAmount])
				  --,[AccountsReceivablePostPeriodCode]
				  --,[AccountsReceivableInvoiceNumber]
				  --,[AccountsReceivableInvoiceType]
				  --,[AdvanceBillFlagDetail]
				  --,[IsNonBillable]
				  --,[GlexActBill]
				  ,SUM([EstimatedHours])
				  ,SUM([EstimatedQuantity])
				  ,SUM([EstimatedTotalAmount])
				  --,SUM([EstimateContTotalAmount])
				  --,SUM([EstimateNonResaleTaxAmount])
				  --,SUM([EstimateResaleTaxAmount])
				  ,SUM([EstimateMarkupAmount])
				  ,SUM([EstimatedCostAmount])
				  --,[IsEstimateNonBillable]
				  --,SUM([EstimateFeeTime])
				  ,SUM([EstimateNetAmount])
				  ,SUM([BilledAmount])
				  --,SUM([BilledWithResale])
				  ,SUM([BilledHours])
				  ,SUM([BilledQuantity])
				  --,SUM([FeeTimeAmount])
				  --,SUM([FeeTimeHours])
				  ,SUM([NonBillableAmount])
				  --,SUM([NonBillableHours])
				  --,SUM([NonBillableQuantity])
				  ,[IsNewBusiness]
				  ,[Agency]
				  ,[ProductUDF1]
				  ,[ProductUDF2]
				  ,[ProductUDF3]
				  ,[ProductUDF4]
				  ,SUM([EstimatedGrossIncome])
				  ,SUM([EstimatedGrossIncomePercent])
				  ,SUM([EstimatedIncome])
				  ,SUM([EstimatedIncomePercent])
				  ,SUM([EstimatedIncomeHist])
				  ,SUM([EstimatedIncomePercentHist])
				  ,SUM([PlannedHours])
				  ,SUM([PlannedAmount])
				  ,SUM([PlannedCostAmount])
				  ,SUM([PlannedIncome])
				  ,SUM([PlannedIncomePercent])
				  ,SUM([ActualGrossIncome])
				  ,CASE WHEN SUM([BillableLessResale]) > 0 THEN (SUM([ActualGrossIncome]) / SUM([BillableLessResale])) * 100 ELSE 0 END				  
				  ,SUM([ActualIncome])
				  ,CASE WHEN SUM([BillableLessResale]) > 0 THEN (SUM([ActualIncome]) / SUM([BillableLessResale])) * 100 ELSE 0 END
			      ,[EmployeeCode]
				  ,[EmployeeName]
				  ,SUM([EstimatedCostAmountHist])
		FROM #GROSS_INCOME
		GROUP BY [JobNumber]
				  ,[JobComponentNumber]
				  ,[FunctionCode]
				  ,[FunctionDescription]
				  ,[OfficeCode]
				  ,[OfficeDescription]
				  ,[ClientCode]
				  ,[ClientDescription]
				  ,[DivisionCode]
				  ,[DivisionDescription]
				  ,[ProductCode]
				  ,[ProductDescription]
				  ,[CampaignID]
				  ,[CampaignCode]
				  ,[CampaignDescription]
				  ,[SalesClassCode]
				  ,[SalesClassDescription]
				  ,[UserCode]
				  ,[JobCreateDate]
				  ,[JobDescription]
				  ,[JobDateOpened]
				  ,[RushChargesApproved]
				  ,[ApprovedEstimateRequired]
				  ,[Comment]
				  ,[ClientReference]
				  ,[BillingCoopCode]
				  ,[SalesClassFormatCode]
				  ,[ComplexityCode]
				  ,[ComplexityDescription]
				  ,[PromotionCode]
				  ,[BillingComment]
				  ,[LabelFromUDFTable1]
				  ,[LabelFromUDFTable2]
				  ,[LabelFromUDFTable3]
				  ,[LabelFromUDFTable4]
				  ,[LabelFromUDFTable5]
				  ,[JobOpen]
				  ,[ComponentNumber]
				  ,[JobComponent]
				  ,[BillHold]
				  ,[AccountExecutiveCode]
				  ,[AccountExecutive]
				  ,[ComponentDateOpened]
				  ,[DueDate]
				  ,[StartDate]
				  ,[AdSize]
				  ,[DepartmentTeamCode]
				  ,[DepartmentTeam]
				  ,[MarkupPercent]
				  ,[CreativeInstructions]
				  ,[JobProcessControl]
				  ,[ComponentDescription]
				  ,[ComponentComments]
				  ,[ComponentBudget]
				  ,[EstimateNumber]
				  ,[EstimateComponentNumber]
				  ,[BillingUser]
				  ,[AdvanceBillFlag]
				  ,[DeliveryInstructions]
				  ,[JobTypeCode]
				  ,[JobTypeDescription]
				  ,[Taxable]
				  ,[TaxCode]
				  ,[TaxCodeDescription]
				  ,[NonBillable]
				  ,[AlertGroup]
				  ,[AdNumber]
				  ,[AccountNumber]
				  ,[IncomeRecognitionMethod]
				  ,[MarketCode]
				  ,[MarketDescription]
				  ,[ServiceFeeJob]
				  ,[ServiceFeeTypeCode]
				  ,[ServiceFeeTypeDescription]
				  ,[Archived]
				  ,[TrafficScheduleRequired]
				  ,[ClientPO]
				  ,[CompLabelFromUDFTable1]
				  ,[CompLabelFromUDFTable2]
				  ,[CompLabelFromUDFTable3]
				  ,[CompLabelFromUDFTable4]
				  ,[CompLabelFromUDFTable5]
				  ,[JobTemplateCode]
				  ,[FiscalPeriodCode]
				  ,[FiscalPeriodDescription]
				  ,[JobQuantity]
				  ,[BlackplateVersionCode]
				  ,[BlackplateVersionDesc]
				  ,[ClientContactCode]
				  ,[ClientContactID]
				  ,[BABatchID]
				  ,[ClientContact]
				  ,[SelectedBABatchID]
				  ,[BillingCommandCenterID]
				  ,[AlertAssignmentTemplate]
				  ,[FunctionType]
				  ,[FunctionConsolidationCode]
				  ,[FunctionConsolidation]
				  ,[FunctionHeading]				  
				  --,[ItemID]
				  --,[ItemSequenceNumber]
				  --,[ItemDate]
				  --,[PostPeriodCode]
				  --,[ItemCode]
				  --,[ItemDescription]
				  --,[ItemComment]
				  --,[ItemExtra]
				  --,[AccountsReceivablePostPeriodCode]
				  --,[AccountsReceivableInvoiceNumber]
				  --,[AccountsReceivableInvoiceType]
				  --,[AdvanceBillFlagDetail]
				  --,[IsNonBillable]
				  --,[GlexActBill]
				  --,[IsEstimateNonBillable]
				  ,[IsNewBusiness]
				  ,[Agency]
				  ,[ProductUDF1]
				  ,[ProductUDF2]
				  ,[ProductUDF3]
				  ,[ProductUDF4]
				  ,[EmployeeCode]
				  ,[EmployeeName]
SELECT
	GIT.*,
	[ClientApproved] = CASE WHEN VEA.CL_EST_APPR_DATE IS NOT NULL THEN 'Yes' ELSE 'No' END,
	[ClientApprovalDate] = VEA.CL_EST_APPR_DATE,
	[InternallyApproved] = CASE WHEN VEA.IN_EST_APPR_DATE IS NOT NULL THEN 'Yes' ELSE 'No' END,
	[InternalApprovalDate] = VEA.IN_EST_APPR_DATE 
FROM #GROSS_INCOME_TOTAL GIT
	LEFT OUTER JOIN dbo.V_ESTIMATEAPPR VEA ON VEA.ESTIMATE_NUMBER = GIT.EstimateNumber AND
											  VEA.EST_COMPONENT_NBR = GIT.EstimateComponentNumber 	
				
        DROP TABLE #PROJECT_TASK_LIST;
        DROP TABLE #PROJECT_TASK_ADJ;
		DROP TABLE #GROSS_INCOME;
		DROP TABLE #GROSS_INCOME_TOTAL;
		DROP TABLE #JOB_INCOME;
		DROP TABLE #EST_INCOME;
		DROP TABLE #FUNC_INCOME;
		DROP TABLE #jobs;
GO

GRANT EXECUTE ON [usp_wv_Gross_Income] TO PUBLIC
GO