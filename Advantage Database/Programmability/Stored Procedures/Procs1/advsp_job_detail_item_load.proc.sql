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

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	DECLARE @TRAFFIC_MGR_COL varchar(20), @debug bit = 0	

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

	--if @DateOption = 'Current'
	--Begin
	--	if @Current_EndDate <> ''
	--	Begin
	--	 SET @et_date_cutoff = @Current_EndDate
	--	 SET @io_date_cutoff = @Current_EndDate
	--	End

	--	if @CURRENT_PERIOD <> ''
	--	Begin
	--	 SET @ap_pp_cutoff = @CURRENT_PERIOD
	--	End
	--End	

--SELECT @et_date_cutoff,@io_date_cutoff,@ap_pp_cutoff

	CREATE TABLE #JOB 
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[JobNumber] int,
		[JobComponentNumber] smallint,
		[OfficeCode] varchar(4),
		[OfficeDescription] varchar(30),
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientDescription] varchar(40),
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionDescription] varchar(40),
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6),
		[CampaignName] varchar(128),
		[BillingBudget] decimal(18, 2), 
		[IncomeBudget] decimal(18, 2), 
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
		[SalesClassFormatCode] varchar(8),
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
		[AccountNumberDescription] varchar(40),
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
		[BlackplateVersion2Code] varchar(6),
		[BlackplateVersion2Desc] varchar(60),
		[ClientContactCode] varchar(6),
		[ClientContactID] int,
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
		[ProductUDF4] varchar(50),
		[CompletedDate] smalldatetime,
		[JobProcessControlDate] smalldatetime,
		[ComplexityDescription] varchar(40)
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
		[FunctionCode] varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS,
		[FunctionDescription] varchar(30),
		[ItemID] int,
		[ItemSequenceNumber] int,
		[ItemDate] smalldatetime,
		[PostPeriodCode] varchar(8),
		[ItemCode] varchar(6),
		[ItemDescription] varchar(100),
		[ItemComment] varchar(MAX),
		[ItemExtra] varchar(20),
		[ItemDetailComment] varchar(max),
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
		[AccountsReceivableInvoiceType] varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[AdvanceBillFlagDetail] int,
		[IsNonBillable] int,
		[GlexActBill] int,
        [EstimateSuppliedByCode] varchar(10),
        [EstimateSuppliedBy] varchar(200),
		[EstimateHours] decimal(18, 2),
		[EstimateHoursAmount] decimal(18, 2),
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
		[BillingApprovalTotalAmount] int,
		[EmployeeDefaultDepartmentCode] varchar(4),
		[EmployeeDefaultDepartmentDescription] varchar(30),
		[EmployeeTimeDepartmentCode] varchar(4),
		[EmployeeTimeDepartmentDescription] varchar(30),
		[DateEntered] smalldatetime,
		[DefaultRoleCode] varchar(6),
		[DefaultRole] varchar(40),
		[EmployeeOfficeCode] varchar(4),
		[EmployeeOfficeDescription] varchar(30),
		[EmployeeTitle] varchar(50),
		[IsEmployeeFreelance] varchar(3),
		[IsActiveFreelance] varchar(3),
		[EmployeeRateFrom] varchar(254),
		[DirectHoursGoalPercent] decimal(7,4),
		[ProductCategoryCode] varchar(10),
		[ProductCategoryDescription] varchar(60),
		[AdvanceBilledTotal] decimal(15,2),
		[FlatIncomeRecognized] decimal(15,2),
		[AdvanceBilledAmount] decimal(15,2),
		[AdvanceBillingRetained] decimal(15,2)
	);

	SELECT 
		@TRAFFIC_MGR_COL = CAST(AGYS.AGY_SETTINGS_VALUE AS varchar(20)) 
	FROM 
		[dbo].[AGY_SETTINGS] AS AGYS
	WHERE 
		AGYS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL'	

IF @debug = 1 SELECT getdate() 'before JOB'		
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
		[CampaignID] = CAMP.CMP_IDENTIFIER,
		[CampaignCode] = J.CMP_CODE, 
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
		[SalesClassFormatCode] = J.FORMAT_CODE,
		[ComplexityCode] = J.COMPLEX_CODE,
		[PromotionCode] = J.PROMO_CODE,
		[BillingComment] = J.JOB_BILL_COMMENT,
		[LabelFromUDFTable1] = JUDV1.UDV_DESC,
		[LabelFromUDFTable2] = JUDV2.UDV_DESC,
		[LabelFromUDFTable3] = JUDV3.UDV_DESC,
		[LabelFromUDFTable4] = JUDV4.UDV_DESC,
		[LabelFromUDFTable5] = JUDV5.UDV_DESC,
		[JobOpen] = CASE WHEN COMPOPEN.JOB_NUMBER IS NULL THEN 'No' ELSE 'Yes' END,
		[ComponentNumber] = JC.JOB_COMPONENT_NBR,
		[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3),
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
		[Taxable] = CASE WHEN JC.TAX_FLAG IS NULL THEN ''
						 WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
		[TaxCode] = JC.TAX_CODE,
		[TaxCodeDescription] = ST.TAX_DESCRIPTION,
		[NonBillable] = JC.NOBILL_FLAG,
		[AlertGroup] = JC.EMAIL_GR_CODE,
		[AdNumber] = JC.AD_NBR,
		[AccountNumber] = JC.ACCT_NBR,
		[AccountNumberDescription] = AN.ACCT_NBR_DESC,
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
		[BlackplateVersion2Code] = JC.BLACKPLT_VER2_CODE,
		[BlackplateVersion2Desc] = JC.BLACKPLT_VER2_DESC,
		[ClientContactCode] = CC.CONT_CODE,
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
		[ProductUDF4] = P.USER_DEFINED4,
		[CompletedDate] = JOBT.COMPLETED_DATE,
		[JobProcessControlDate] = JPL_DATE.PROCESS_DATE,
		[ComplexityDescription] = CMPL.COMPLEX_DESC
	FROM 
		[dbo].[JOB_COMPONENT] AS JC INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		(SELECT	DISTINCT
			JOB_NUMBER
		 FROM
			dbo.JOB_COMPONENT
		 WHERE
			JOB_PROCESS_CONTRL NOT IN (6, 12)) COMPOPEN ON J.JOB_NUMBER = COMPOPEN.JOB_NUMBER LEFT OUTER JOIN
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
		[dbo].[ACCT_NUMBER] AS AN ON AN.ACCT_NBR = JC.ACCT_NBR LEFT OUTER JOIN
		(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
		[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
		[dbo].[JOB_TRAFFIC] AS JOBT ON JOBT.JOB_NUMBER = JC.JOB_NUMBER AND JOBT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
		[dbo].[TRAFFIC] AS T ON T.TRF_CODE = JOBT.TRF_CODE LEFT OUTER JOIN
		[dbo].[COMPLEXITY] AS CMPL ON J.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN
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
																								   PJM.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
		(SELECT 
			JOB_NUMBER, 
			JOB_COMPONENT_NBR, 
			PROCESS_DATE = MAX(PROCESS_DATE) 
		 FROM 
			dbo.JOB_PROCESS_LOG 
		 GROUP BY 
			JOB_NUMBER, 
			JOB_COMPONENT_NBR) JPL_DATE ON JC.JOB_NUMBER = JPL_DATE.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = JPL_DATE.JOB_COMPONENT_NBR
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END 
				 WHEN @DATE_TYPE = 5 THEN 1 ElSE 1 END
		AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JPC.JOB_PROCESS_DESC = 'Closed' OR JPC.JOB_PROCESS_DESC = 'Archive') THEN 0 ELSE 1 END
		AND	(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND	(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND J.CL_CODE + '|' + J.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND	(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		AND	(@AECodeList IS NULL OR (@AECodeList IS NOT NULL AND JC.EMP_CODE IN (SELECT * from dbo.udf_split_list(@AECodeList, ','))))
		AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND J.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
		AND (@JobTypeList IS NULL OR (@JobTypeList IS NOT NULL AND JC.JT_CODE IN (SELECT * FROM dbo.udf_split_list(@JobTypeList, ','))))
OPTION (RECOMPILE)
IF @debug = 1 SELECT getdate() 'after JOB'
	
	--IR
	INSERT INTO #JOB_DETAIL
	SELECT
		[ResourceType] = 'IR',
		[JobNumber] = IR.JOB_NUMBER,
		[JobComponentNumber] = IR.JOB_COMPONENT_NBR,
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = IR.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = IR.AB_ID,
		[ItemSequenceNumber] = IR.SEQ_NBR,
		[ItemDate] = IR.BILL_DATE,
		[PostPeriodCode] = CAST(NULL AS varchar(8)),
		[ItemCode] = CAST(NULL AS varchar(6)),
		[ItemDescription] = 'Income Rec',
		[ItemComment] = CAST(NULL AS varchar(MAX)),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
		[AccountsReceivableInvoiceNumber] = IR.AR_INV_NBR,
		[AccountsReceivableInvoiceType] = IR.AR_TYPE,
		[AdvanceBillFlagDetail] = IR.AB_FLAG,
		[IsNonBillable] = 0,
		[GlexActBill] = IR.GLEXACT,
        [EstimateSuppliedByCode] = '',
        [EstimateSuppliedBy] = '',
		[EstimateHours] = 0,
		[EstimateHoursAmount] = 0,
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
		--[BilledAmount] = CASE WHEN @IncludeBilledRange = 1 THEN 
		--					  CASE WHEN IR.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(IR.LINE_TOTAL, 0) - ISNULL(IR.EXT_CITY_RESALE, 0) - ISNULL(IR.EXT_STATE_RESALE, 0) - ISNULL(IR.EXT_COUNTY_RESALE, 0)
		--							ELSE 0 END
		--					  ELSE CASE WHEN IR.AR_INV_NBR IS NOT NULL THEN ISNULL(IR.LINE_TOTAL, 0) - ISNULL(IR.EXT_CITY_RESALE, 0) - ISNULL(IR.EXT_STATE_RESALE, 0) - ISNULL(IR.EXT_COUNTY_RESALE, 0) ELSE 0 END END,
		--[BilledWithResale] = CASE WHEN @IncludeBilledRange = 1 THEN 
		--					  CASE WHEN IR.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(IR.LINE_TOTAL, 0)
		--							ELSE 0 END
		--					  ELSE CASE WHEN IR.AR_INV_NBR IS NOT NULL THEN ISNULL(IR.LINE_TOTAL, 0) ELSE 0 END END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = IR.CREATE_DATE,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = CASE WHEN IR.AR_INV_NBR IS NOT NULL THEN COALESCE(IR.REC_AMT, 0) ELSE 0 END,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
	FROM 
		[dbo].[INCOME_REC] AS IR LEFT OUTER JOIN  
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = IR.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = IR.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = IR.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		(SELECT 
			DISTINCT 
			AR.AR_POST_PERIOD,
			AR.AR_INV_NBR, 
			AR.AR_TYPE
		FROM 
			[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = IR.AR_INV_NBR AND 
											 AR.AR_TYPE = IR.AR_TYPE LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END      
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN IR.BILL_DATE >= @START_DATE AND IR.BILL_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END 
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
			--AND 1 = CASE WHEN @IncludeBilledRange = 1 AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN 1 
			--			 WHEN @IncludeBilledRange = 0 THEN 1 ELSE 0 END

IF @debug = 1 SELECT getdate() 'after IR'

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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
        [EstimateSuppliedByCode] = '',
        [EstimateSuppliedBy] = '',
		[EstimateHours] = 0,
		[EstimateHoursAmount] = 0,
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
		--[BilledAmount] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) ELSE 0 END,
		--[BilledWithResale] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) ELSE 0 END,
		[BilledAmount] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN AB.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0)
									ELSE 0 END
							  ELSE CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) ELSE 0 END END,
		[BilledWithResale] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN AB.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(AB.LINE_TOTAL, 0)
									ELSE 0 END
							  ELSE CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN ISNULL(AB.LINE_TOTAL, 0) ELSE 0 END END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = AB.CREATE_DATE,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = CASE WHEN AB.AR_INV_NBR IS NOT NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = CASE WHEN AB.AR_INV_NBR IS NOT NULL AND AB.AB_FLAG <> 5 THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
		[AdvanceBillingRetained] = CASE WHEN AB.AR_INV_NBR IS NOT NULL AND AB.AB_FLAG = 5 THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END
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
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END      
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN AB.BILL_DATE >= @START_DATE AND AB.BILL_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END 
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
			--AND 1 = CASE WHEN @IncludeBilledRange = 1 AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN 1 
			--			 WHEN @IncludeBilledRange = 0 THEN 1 ELSE 0 END

IF @debug = 1 SELECT getdate() 'after AB'
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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
        [EstimateSuppliedByCode] = '',
        [EstimateSuppliedBy] = '',
		[EstimateHours] = 0,
		[EstimateHoursAmount] = 0,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = null,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
	FROM 
		[dbo].[CLIENT_OOP] AS COOP INNER JOIN  
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = COOP.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = COOP.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = COOP.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END     
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN COOP.INV_DATE >= @START_DATE AND COOP.INV_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
IF @debug = 1 SELECT getdate() 'after C'
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
		[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
		[ItemExtra] = CAST(NULL AS varchar(20)),
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
        [EstimateSuppliedByCode] = '',
        [EstimateSuppliedBy] = '',
		[EstimateHours] = 0,
		[EstimateHoursAmount] = 0,
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
		[BilledAmount] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN ETD.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) 
									ELSE 0 END
							  ELSE CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END END,
		[BilledWithResale] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN ETD.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(ETD.LINE_TOTAL, 0)
									ELSE 0 END
							  ELSE CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END END,
		[BilledHours] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(ETD.EMP_HOURS, 0)
									ELSE 0 END ELSE 0 END
							  ELSE CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END END,
		[BilledQuantity] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(ETD.EMP_HOURS, 0)
									ELSE 0 END ELSE 0 END
							  ELSE CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END END,
		--[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
		--[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
		--[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
		--[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = DEF_DEPT.DP_TM_CODE,
		[EmployeeDefaultDepartmentDescription] = DEF_DEPT.DP_TM_DESC,
		[EmployeeTimeDepartmentCode] = ETD_DEPT.DP_TM_CODE,
		[EmployeeTimeDepartmentDescription] = ETD_DEPT.DP_TM_DESC,
		[DateEntered] = ETD.DATE_ENTERED,
		[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
		[DefaultRole] = TRF_ROLE.ROLE_DESC,
		[EmployeeOfficeCode] = EMP.OFFICE_CODE,
		[EmployeeOfficeDescription] = O.OFFICE_NAME,
		[EmployeeTitle] = EMP.EMP_TITLE,
		[IsEmployeeFreelance] = CASE WHEN EMP.FREELANCE = 1 THEN 'Yes' ELSE 'No' END,
		[IsActiveFreelance] = CASE WHEN EMP.IS_ACTIVE_FREELANCE = 1 THEN 'Yes' ELSE 'No' END,
		[EmployeeRateFrom] = ETD.EMP_RATE_FROM,
		[DirectHoursGoalPercent] = EMP.DIRECT_HRS_PER,
		[ProductCategoryCode] = ETD.PROD_CAT_CODE,
		[ProductCategoryDescription] = PD.PROD_CAT_DESC,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
		--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND
		--									 ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND 
		--										 ETDC.ET_SOURCE = 'D' LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
		[dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = ET.EMP_CODE LEFT OUTER JOIN
		[dbo].[DEPT_TEAM] AS DEF_DEPT ON EMP.DP_TM_CODE = DEF_DEPT.DP_TM_CODE INNER JOIN
		[dbo].[DEPT_TEAM] AS ETD_DEPT ON ETD.DP_TM_CODE = ETD_DEPT.DP_TM_CODE LEFT OUTER JOIN
		[dbo].[TRAFFIC_ROLE] AS TRF_ROLE ON EMP.DEF_TRF_ROLE = TRF_ROLE.ROLE_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON EMP.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN
		[dbo].[PRODUCT_CATEGORY] PD ON J.CL_CODE = PD.CL_CODE AND
										J.DIV_CODE = PD.DIV_CODE AND
										J.PRD_CODE = PD.PRD_CODE AND 
										ETD.PROD_CAT_CODE = PD.PROD_CAT_CODE
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END    
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN ET.EMP_DATE >= @START_DATE AND ET.EMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END
				  AND ET.EMP_DATE <= @et_date_cutoff
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
			--AND 1 = CASE WHEN @IncludeBilledRange = 1 AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN 1 
			--			 WHEN @IncludeBilledRange = 0 THEN 1 ELSE 0 END

IF @debug = 1 SELECT getdate() 'after E'

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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
        [EstimateSuppliedByCode] = '',
        [EstimateSuppliedBy] = '',
		[EstimateHours] = 0,
		[EstimateHoursAmount] = 0,
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
		[BilledAmount] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN [IO].AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0)
									ELSE 0 END
							  ELSE CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END END,
		[BilledWithResale] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN [IO].AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL([IO].LINE_TOTAL, 0)
									ELSE 0 END
							  ELSE CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END END,
		[BilledHours] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL([IO].IO_QTY, 0)
									ELSE 0 END
							  ELSE CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END END,
		[BilledQuantity] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL([IO].IO_QTY, 0)
									ELSE 0 END
							  ELSE CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END END,
		--[BilledAmount] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) ELSE 0 END,
		--[BilledWithResale] = CASE WHEN [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].LINE_TOTAL, 0) ELSE 0 END,
		--[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
		--[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL([IO].NON_BILL_FLAG, 0) <> 1 AND [IO].AR_INV_NBR IS NOT NULL THEN ISNULL([IO].IO_QTY, 0) ELSE 0 END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = [IO].IO_INV_DATE,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END   
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN [IO].IO_INV_DATE >= @START_DATE AND [IO].IO_INV_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END
				  AND IO_INV_DATE <= @io_date_cutoff
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
			--AND 1 = CASE WHEN @IncludeBilledRange = 1 AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN 1 
			--			 WHEN @IncludeBilledRange = 0 THEN 1 ELSE 0 END
IF @debug = 1 SELECT getdate() 'after I'
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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
        [EstimateSuppliedByCode] = '',
        [EstimateSuppliedBy] = '',
		[EstimateHours] = 0,
		[EstimateHoursAmount] = 0,
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
		[OpenPurchaseOrderAmount] = CASE WHEN (POD.PO_COMPLETE = 1 OR PO.VOID_FLAG = 1) THEN 0 ELSE CASE WHEN (ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0)) < 0 THEN 0 ELSE ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0) END END,
		[OpenPurchaseOrderGrossAmount] = CASE WHEN (POD.PO_COMPLETE = 1 OR PO.VOID_FLAG = 1) THEN 0 ELSE CASE WHEN (ISNULL(POD.PO_EXT_AMOUNT, 0) + ISNULL(POD.EXT_MARKUP_AMT, 0) - ISNULL(AP.AP_GROSS_AMT, 0)) < 0 THEN 0 ELSE ISNULL(POD.PO_EXT_AMOUNT, 0) + ISNULL(POD.EXT_MARKUP_AMT, 0) - ISNULL(AP.AP_GROSS_AMT, 0) END END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = null,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
			ISNULL(AP.DELETE_FLAG, 0) = 0 AND 
			ISNULL(AP.MODIFY_DELETE, 0) = 0
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
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END  
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN PO.PO_DATE >= @START_DATE AND PO.PO_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
IF @debug = 1 SELECT getdate() 'after PO'
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
		[ItemDetailComment] = CAST(APC.AP_COMMENT AS varchar(MAX)),
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
        [EstimateSuppliedByCode] = '',
        [EstimateSuppliedBy] = '',
		[EstimateHours] = 0,
		[EstimateHoursAmount] = 0,
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
		[BilledAmount] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0)
									ELSE 0 END
							  ELSE CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END END,
		[BilledWithResale] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(APP.LINE_TOTAL, 0)
									ELSE 0 END
							  ELSE CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END END,
		[BilledHours] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(APP.AP_PROD_QUANTITY, 0)
									ELSE 0 END
							  ELSE CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END END,
		[BilledQuantity] = CASE WHEN @IncludeBilledRange = 1 THEN 
							  CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN ISNULL(APP.AP_PROD_QUANTITY, 0)
									ELSE 0 END
							  ELSE CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END END,
		--[BilledAmount] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0) ELSE 0 END,
		--[BilledWithResale] = CASE WHEN ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.LINE_TOTAL, 0) ELSE 0 END,
		--[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
		--[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) <> 1 AND APP.AR_INV_NBR IS NOT NULL THEN ISNULL(APP.AP_PROD_QUANTITY, 0) ELSE 0 END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = APP.CREATE_DATE,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
										   APC.LINE_NUMBER = APP.LINE_NUMBER
												AND APC.JOB_NUMBER = APP.JOB_NUMBER 
												AND APC.JOB_COMPONENT_NBR = APP.JOB_COMPONENT_NBR 
												AND APC.FNC_CODE = APP.FNC_CODE LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END 
				 WHEN @DATE_TYPE = 5 THEN CASE WHEN APH.AP_INV_DATE >= @START_DATE AND APH.AP_INV_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END ElSE 1 END
				  AND APP.POST_PERIOD <= @ap_pp_cutoff
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
			--AND 1 = CASE WHEN @IncludeBilledRange = 1 AND AR.AR_POST_PERIOD BETWEEN @BILLED_START_PERIOD AND @BILLED_END_PERIOD THEN 1 
			--			 WHEN @IncludeBilledRange = 0 THEN 1 ELSE 0 END
IF @debug = 1 SELECT getdate() 'after V'

IF @DATE_TYPE = 5
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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
		[AccountsReceivablePostPeriodCode] = CAST('' AS varchar(6)),
		[AccountsReceivableInvoiceNumber] = 0,
		[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
		[AdvanceBillFlagDetail] = 0,
		[IsNonBillable] = 0,
		[GlexActBill] = 0,
        [EstimateSuppliedByCode] = ERD.EST_REV_SUP_BY_CDE,
        [EstimateSuppliedBy] = CASE WHEN F.FNC_TYPE = 'E' THEN COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') WHEN F.FNC_TYPE = 'V' THEN V.VN_NAME END,
		[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
		[EstimateHoursAmount] = CASE WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0) ELSE 0 END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = null,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
        [dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'E' LEFT OUTER JOIN
        [dbo].[VENDOR] AS V ON V.VN_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'V' 
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 1 END    
				 WHEN @DATE_TYPE = 5 THEN 1 ElSE 1 END
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END AND J.JOB_NUMBER IN (SELECT [JobNumber] FROM #JOB_DETAIL)
	IF @debug = 1 SELECT getdate() 'after EI'
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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
		[AccountsReceivablePostPeriodCode] = CAST('' AS varchar(6)),
		[AccountsReceivableInvoiceNumber] = 0,
		[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
		[AdvanceBillFlagDetail] = 0,
		[IsNonBillable] = 0,
		[GlexActBill] = 0,
        [EstimateSuppliedByCode] = ERD.EST_REV_SUP_BY_CDE,
        [EstimateSuppliedBy] = CASE WHEN F.FNC_TYPE = 'E' THEN COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') WHEN F.FNC_TYPE = 'V' THEN V.VN_NAME END,
		[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,		
		[EstimateHoursAmount] = CASE WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0) ELSE 0 END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = null,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
        [dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'E' LEFT OUTER JOIN
        [dbo].[VENDOR] AS V ON V.VN_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'V'
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 1 END    
				 WHEN @DATE_TYPE = 5 THEN 1 ElSE 1 END
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END AND J.JOB_NUMBER IN (SELECT [JobNumber] FROM #JOB_DETAIL)
	IF @debug = 1 SELECT getdate() 'after ES'
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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
		[AccountsReceivablePostPeriodCode] = CAST('' AS varchar(6)),
		[AccountsReceivableInvoiceNumber] = 0,
		[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
		[AdvanceBillFlagDetail] = 0,
		[IsNonBillable] = 0,
		[GlexActBill] = 0,
        [EstimateSuppliedByCode] = ERD.EST_REV_SUP_BY_CDE,
        [EstimateSuppliedBy] = CASE WHEN F.FNC_TYPE = 'E' THEN COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') WHEN F.FNC_TYPE = 'V' THEN V.VN_NAME END,
		[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,
		[EstimateHoursAmount] = CASE WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0) ELSE 0 END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = null,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
        [dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'E' LEFT OUTER JOIN
        [dbo].[VENDOR] AS V ON V.VN_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'V'
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 1 END    
				 WHEN @DATE_TYPE = 5 THEN 1 ElSE 1 END
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
	IF @debug = 1 SELECT getdate() 'after EI'
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
		[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
		[AccountsReceivablePostPeriodCode] = CAST('' AS varchar(6)),
		[AccountsReceivableInvoiceNumber] = 0,
		[AccountsReceivableInvoiceType] = CAST(NULL AS varchar(3)),
		[AdvanceBillFlagDetail] = 0,
		[IsNonBillable] = 0,
		[GlexActBill] = 0,
        [EstimateSuppliedByCode] = ERD.EST_REV_SUP_BY_CDE,
        [EstimateSuppliedBy] = CASE WHEN F.FNC_TYPE = 'E' THEN COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') WHEN F.FNC_TYPE = 'V' THEN V.VN_NAME END,
		[EstimateHours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) ELSE 0 END,		
		[EstimateHoursAmount] = CASE WHEN F.FNC_TYPE = 'E' THEN (ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0)) - ISNULL(ERD.EXT_MARKUP_AMT, 0) ELSE 0 END,
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = null,
		[EmployeeDefaultDepartmentDescription] = null,
		[EmployeeTimeDepartmentCode] = null,
		[EmployeeTimeDepartmentDescription] = null,
		[DateEntered] = null,
		[DefaultRoleCode] = null,
		[DefaultRole] = null,
		[EmployeeOfficeCode] = null,
		[EmployeeOfficeDescription] = null,
		[EmployeeTitle] = null,
		[IsEmployeeFreelance] = null,
		[IsActiveFreelance] = null,
		[EmployeeRateFrom] = null,
		[DirectHoursGoalPercent] = null,
		[ProductCategoryCode] = null,
		[ProductCategoryDescription] = null,
		[AdvanceBilledTotal] = null,
		[FlatIncomeRecognized] = null,
		[AdvanceBilledAmount] = null,
		[AdvanceBillingRetained] = null
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
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
        [dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'E' LEFT OUTER JOIN
        [dbo].[VENDOR] AS V ON V.VN_CODE = ERD.EST_REV_SUP_BY_CDE AND F.FNC_TYPE = 'V' 
	WHERE
		1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 1 END    
				 WHEN @DATE_TYPE = 5 THEN 1 ElSE 1 END
			AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL IN (6,12)) THEN 0 ELSE 1 END
	IF @debug = 1 SELECT getdate() 'after ES' 
END
			
	IF @SHOW_JOBS_WO_DETAILS = 1 BEGIN
		--ND
		INSERT INTO #JOB_DETAIL
		SELECT
			[ResourceType] = 'ND',
			[JobNumber] = JC.JOB_NUMBER,
			[JobComponentNumber] = JC.JOB_COMPONENT_NBR,
			[FunctionType] = CAST(NULL AS varchar(1)),
			[FunctionConsolidationCode] = CAST(NULL AS varchar(6)),
			[FunctionConsolidation] = CAST(NULL AS varchar(30)),
			[FunctionHeading] = CAST(NULL AS varchar(60)),
			[FunctionCode] = CAST(NULL AS varchar(6)),
			[FunctionDescription] = CAST(NULL AS varchar(30)),
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = CAST(NULL AS smalldatetime),
			[PostPeriodCode] = CAST(NULL AS varchar(8)),
			[ItemCode] = CAST(NULL AS varchar(6)),
			[ItemDescription] = 'No Details',
			[ItemComment] = CAST(NULL AS varchar(MAX)),
			[ItemExtra] = CAST(NULL AS varchar(20)),
			[ItemDetailComment] = CAST(NULL AS varchar(MAX)),
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
			[AccountsReceivableInvoiceNumber] = CAST(NULL AS int),
			[AccountsReceivableInvoiceType] = NULL,
			[AdvanceBillFlagDetail] = CAST(0 AS smallint),
			[IsNonBillable] = 0,
			[GlexActBill] = CAST(0 AS int),
            [EstimateSuppliedByCode] = '',
            [EstimateSuppliedBy] = '',
			[EstimateHours] = 0,
		    [EstimateHoursAmount] = 0,
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
			[BillingApprovalTotalAmount] = 0,
			[EmployeeDefaultDepartmentCode] = null,
			[EmployeeDefaultDepartmentDescription] = null,
			[EmployeeTimeDepartmentCode] = null,
			[EmployeeTimeDepartmentDescription] = null,
			[DateEntered] = null,
			[DefaultRoleCode] = null,
			[DefaultRole] = null,
			[EmployeeOfficeCode] = null,
			[EmployeeOfficeDescription] = null,
			[EmployeeTitle] = null,
			[IsEmployeeFreelance] = null,
			[IsActiveFreelance] = null,
			[EmployeeRateFrom] = null,
			[DirectHoursGoalPercent] = null,
			[ProductCategoryCode] = null,
			[ProductCategoryDescription] = null,
			[AdvanceBilledTotal] = null,
			[FlatIncomeRecognized] = null,
			[AdvanceBilledAmount] = null,
			[AdvanceBillingRetained] = null
		FROM  
			[dbo].[JOB_COMPONENT] AS JC INNER JOIN
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
			(SELECT 
				[JobNumber] = JOBTOTALS.[JobNumber],
				[ComponentNumber] = JOBTOTALS.[JobComponentNumber]
			FROM
				(SELECT
					[JobNumber] = AB.JOB_NUMBER,
					[JobComponentNumber] = AB.JOB_COMPONENT_NBR
				FROM 
					[dbo].[ADVANCE_BILLING] AS AB
						
				UNION ALL

				SELECT
					[JobNumber] = COOP.JOB_NUMBER,
					[JobComponentNumber] = COOP.JOB_COMPONENT_NBR
				FROM 
					[dbo].[CLIENT_OOP] AS COOP
							
				UNION ALL

				SELECT
					[JobNumber] = ETD.JOB_NUMBER,
					[JobComponentNumber] = ETD.JOB_COMPONENT_NBR
				FROM 
					[dbo].[EMP_TIME_DTL] AS ETD
								
				UNION ALL

				SELECT
					[JobNumber] = EIA.JOB_NUMBER,
					[JobComponentNumber] = EIA.JOB_COMPONENT_NBR
				FROM 
					[dbo].[ESTIMATE_INT_APPR] AS EIA
					
				UNION ALL

				SELECT
					[JobNumber] = EA.JOB_NUMBER,
					[JobComponentNumber] = EA.JOB_COMPONENT_NBR
				FROM 
					[dbo].[ESTIMATE_APPROVAL] AS EA
					
				UNION ALL

				SELECT
					[JobNumber] = [IO].JOB_NUMBER,
					[JobComponentNumber] = [IO].JOB_COMPONENT_NBR
				FROM 
					[dbo].[INCOME_ONLY] AS [IO]
						
				UNION ALL

				SELECT
					[JobNumber] = POD.JOB_NUMBER,
					[JobComponentNumber] = POD.JOB_COMPONENT_NBR
				FROM 
					[dbo].[PURCHASE_ORDER] AS PO INNER JOIN 
					[dbo].[PURCHASE_ORDER_DET] AS POD ON POD.PO_NUMBER = PO.PO_NUMBER
							
				UNION ALL

				SELECT
					[JobNumber] = APP.JOB_NUMBER,
					[JobComponentNumber] = APP.JOB_COMPONENT_NBR
				FROM 
					[dbo].[AP_PRODUCTION] AS APP) AS JOBTOTALS
			GROUP BY
				JOBTOTALS.[JobNumber],
				JOBTOTALS.[JobComponentNumber]) AS JOBDTLS ON JOBDTLS.JobNumber = JC.JOB_NUMBER AND
															  JOBDTLS.ComponentNumber = JC.JOB_COMPONENT_NBR
		WHERE
			JOBDTLS.JobNumber IS NULL AND
			JOBDTLS.ComponentNumber IS NULL AND
			1 = CASE WHEN @DATE_TYPE = 1 THEN CASE WHEN J.CREATE_DATE >= @START_DATE AND J.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
					 WHEN @DATE_TYPE = 2 THEN CASE WHEN JC.JOB_COMP_DATE >= @START_DATE AND JC.JOB_COMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
					 WHEN @DATE_TYPE = 3 THEN CASE WHEN JC.JOB_FIRST_USE_DATE >= @START_DATE AND JC.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
					 WHEN @DATE_TYPE = 4 THEN CASE WHEN JC.[START_DATE] >= @START_DATE AND JC.[START_DATE] <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
					 WHEN @DATE_TYPE = 5 THEN 1 ElSE 1 END
		    AND 1 = CASE WHEN @INCLUDE_CLOSED = 0 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END
IF @debug = 1 SELECT getdate() 'after ND'
				
	END
	
	SELECT 
		[ID] = NEWID(),
		JD.ResourceType,
		J.JobNumber,
		J.JobComponentNumber,
		J.OfficeCode,
		J.OfficeDescription,
		J.ClientCode,
		J.ClientDescription,
		J.DivisionCode,
		J.DivisionDescription,
		J.ProductCode,
		J.ProductDescription,
		J.CampaignID,
		J.CampaignCode,
		J.CampaignName,
		J.BillingBudget,
		J.IncomeBudget,
		J.SalesClassCode,
		J.SalesClassDescription,
		J.UserCode,
		J.JobCreateDate,
		J.JobDescription,
		J.JobDateOpened,
		J.RushChargesApproved,
		J.ApprovedEstimateRequired,
		J.Comment,
		J.ClientReference,
		J.BillingCoopCode,
		J.SalesClassFormatCode,
		J.ComplexityCode,
		J.ComplexityDescription,
		J.PromotionCode,
		J.BillingComment,
		J.LabelFromUDFTable1,
		J.LabelFromUDFTable2,
		J.LabelFromUDFTable3,
		J.LabelFromUDFTable4,
		J.LabelFromUDFTable5,
		J.JobOpen,
		J.JobComponent,
		J.BillHold,
		J.AccountExecutiveCode,
		J.AccountExecutive,
		J.ManagerCode,
		J.Manager,
		J.ComponentDateOpened,
		J.DueDate,
		J.StartDate,
		J.[Status],
		J.GutPercentComplete,
		J.CompletedDate,
		J.AdSize,
		J.DepartmentTeamCode,
		J.DepartmentTeam,
		J.MarkupPercent,
		J.CreativeInstructions,
		J.JobProcessControl,
		J.JobProcessControlDate,
		J.ComponentDescription,
		J.ComponentComments,
		J.ComponentBudget,
		J.EstimateNumber,
		J.EstimateComponentNumber,
		[ClientApproved] = CASE WHEN VEA.CL_EST_APPR_DATE IS NOT NULL THEN 'Yes' ELSE 'No' END,
		[ClientApprovalDate] = VEA.CL_EST_APPR_DATE,
		[ClientApprovedBy] = VEA.CL_EST_APPR_BY,
		[InternallyApproved] = CASE WHEN VEA.IN_EST_APPR_DATE IS NOT NULL THEN 'Yes' ELSE 'No' END,
		[InternalApprovalDate] = VEA.IN_EST_APPR_DATE,
		[InternallyApprovedBy] = VEA.IN_EST_APPR_BY,
		J.BillingUser,
		J.AdvanceBillFlag,
		J.DeliveryInstructions,
		J.JobTypeCode,
		J.JobTypeDescription,
		J.Taxable,
		J.TaxCode,
		J.TaxCodeDescription,
		J.NonBillable,
		J.AlertGroup,
		J.AdNumber,
		J.AccountNumber,
		J.AccountNumberDescription,
		J.IncomeRecognitionMethod,
		J.MarketCode,
		J.MarketDescription,
		J.ServiceFeeJob,
		J.ServiceFeeTypeCode,
		J.ServiceFeeTypeDescription,
		J.Archived,
		J.TrafficScheduleRequired,
		J.ClientPO,
		J.CompLabelFromUDFTable1,
		J.CompLabelFromUDFTable2,
		J.CompLabelFromUDFTable3,
		J.CompLabelFromUDFTable4,
		J.CompLabelFromUDFTable5,
		J.JobTemplateCode,
		J.FiscalPeriodCode,
		J.FiscalPeriodDescription,
		J.JobQuantity,
		J.BlackplateVersionCode,
		J.BlackplateVersionDesc,
		J.BlackplateVersion2Code,
		J.BlackplateVersion2Desc,		
		J.ClientContactCode,
		J.ClientContactID,
		J.BABatchID,
		J.ClientContact,
		J.SelectedBABatchID,
		J.BillingCommandCenterID,
		J.AlertAssignmentTemplate,
		JD.FunctionType,
		JD.FunctionConsolidationCode,
		JD.FunctionConsolidation,
		JD.FunctionHeading,
		JD.FunctionCode,
		JD.FunctionDescription,
		JD.ItemID,
		JD.ItemSequenceNumber,
		JD.ItemDate,
		JD.PostPeriodCode,
		JD.ItemCode,
		JD.ItemDescription,
		JD.ItemComment,
		JD.ItemExtra,
		JD.ItemDetailComment,
		JD.[Hours],
		JD.Quantity,
		JD.NetAmount,
		JD.CostAmount,
		JD.ExtMarkupAmount,
		JD.NonResaleTaxAmount,
		JD.ResaleTaxAmount,
		JD.Total,
		JD.BillableLessResale,
		JD.BillableTotal,
		JD.FeeTime,
		JD.FeeTimeHours,
		JD.FeeTimeAmount,
		JD.NonBillableHours,
		JD.NonBillableQuantity,
		JD.NonBillableAmount,
		JD.BilledHours,
		JD.BilledQuantity,
		JD.BilledAmount,
		JD.BilledWithResale,
		JD.AccountsReceivablePostPeriodCode,
		JD.AccountsReceivableInvoiceNumber,
		JD.AccountsReceivableInvoiceType,
		JD.UnbilledHours,
		JD.UnbilledQuantity,
		JD.UnbilledAmount,
		JD.UnbilledAmountLessResale,
		JD.AdvanceBillFlagDetail,
		JD.IsNonBillable,
		JD.GlexActBill,
        JD.EstimateSuppliedByCode,
        JD.EstimateSuppliedBy,
		JD.EstimateHours,
		JD.EstimateHoursAmount,
		JD.EstimateQuantity,
		JD.EstimateTotalAmount,
		JD.EstimateContTotalAmount,
		JD.EstimateNonResaleTaxAmount,
		JD.EstimateResaleTaxAmount,
		JD.EstimateMarkupAmount,
		JD.EstimateCostAmount,
		JD.IsEstimateNonBillable,
		JD.EstimateFeeTime,
		JD.EstimateNetAmount,
		JD.PurchaseOrderNumber,
		JD.OpenPurchaseOrderAmount,
		JD.OpenPurchaseOrderGrossAmount,
		J.IsNewBusiness,
		J.Agency,
		JD.BillingApprovalHours,
		JD.BillingApprovalCostAmount,
		JD.BillingApprovalExtNetAmount,
		JD.BillingApprovalTotalAmount,
		J.ProductUDF1,
		J.ProductUDF2,
		J.ProductUDF3,
		J.ProductUDF4,
		JD.EmployeeDefaultDepartmentCode,
		JD.EmployeeDefaultDepartmentDescription,
		JD.EmployeeTimeDepartmentCode,
		JD.EmployeeTimeDepartmentDescription,
		JD.DateEntered,
		JD.DefaultRoleCode,
		JD.DefaultRole,
		JD.EmployeeOfficeCode,
		JD.EmployeeOfficeDescription,
		JD.EmployeeTitle,
		JD.IsEmployeeFreelance,
		JD.IsActiveFreelance,
		JD.EmployeeRateFrom,
		JD.ProductCategoryCode,
		JD.ProductCategoryDescription,
		JD.DirectHoursGoalPercent,
		[ClientType1Code] = CP.CLIENT_TYPE1_ID,
		[ClientType1Description] = CT1.[DESCRIPTION],
		[ClientType2Code] = CP.CLIENT_TYPE2_ID,
		[ClientType2Description] = CT2.[DESCRIPTION],
		[ClientType3Code] = CP.CLIENT_TYPE3_ID,
		[ClientType3Description] = CT3.[DESCRIPTION],
		[CurrentHours] = CASE WHEN JD.ResourceType = 'E' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN JD.[Hours] ELSE 0 END,		
		[CurrentHoursAmount] = CASE WHEN JD.ResourceType = 'E' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN JD.[Total] ELSE 0 END,
		[CurrentIncomeOnlyCharges] = CASE WHEN JD.ResourceType = 'I' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN JD.[Total] ELSE 0 END,		
		[CurrentVendorCharges] = CASE WHEN JD.ResourceType = 'V' AND PostPeriodCode = @CURRENT_PERIOD THEN JD.[Total] ELSE 0 END,		
		[CurrentTotal] = (CASE WHEN JD.ResourceType = 'E' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN JD.[Total] ELSE 0 END) +
						 (CASE WHEN JD.ResourceType = 'I' AND ItemDate BETWEEN @Current_StartDate AND @Current_EndDate THEN JD.[Total] ELSE 0 END) +
						 (CASE WHEN JD.ResourceType = 'V' AND PostPeriodCode = @CURRENT_PERIOD THEN JD.[Total] ELSE 0 END),
		[PriorHours] = CASE WHEN JD.ResourceType = 'E' AND ItemDate < @Current_StartDate THEN JD.[Hours] ELSE 0 END,		
		[PriorHoursAmount] = CASE WHEN JD.ResourceType = 'E' AND ItemDate < @Current_StartDate THEN JD.[Total] ELSE 0 END,
		[PriorIncomeOnlyCharges] = CASE WHEN JD.ResourceType = 'I' AND ItemDate < @Current_StartDate THEN JD.[Total] ELSE 0 END,		
		[PriorVendorCharges] = CASE WHEN JD.ResourceType = 'V' AND PostPeriodCode < @CURRENT_PERIOD THEN JD.[Total] ELSE 0 END,		
		[PriorTotal] = (CASE WHEN JD.ResourceType = 'E' AND ItemDate < @Current_StartDate THEN JD.[Total] ELSE 0 END) +
					   (CASE WHEN JD.ResourceType = 'I' AND ItemDate < @Current_StartDate THEN JD.[Total] ELSE 0 END) +
					   (CASE WHEN JD.ResourceType = 'V' AND PostPeriodCode < @CURRENT_PERIOD THEN JD.[Total] ELSE 0 END),
		[TotalToDateHours] = CASE WHEN JD.ResourceType = 'E' THEN JD.[Hours] ELSE 0 END,
		[TotalToDateHoursAmount] = CASE WHEN JD.ResourceType = 'E' THEN JD.[Total] ELSE 0 END,
		[TotalToDateIncomeOnlyCharges] = CASE WHEN JD.ResourceType = 'I' THEN JD.[Total] ELSE 0 END,
		[TotalToDateVendorCharges] = CASE WHEN JD.ResourceType = 'V' THEN JD.[Total] ELSE 0 END,
		[TotalToDate] = (CASE WHEN JD.ResourceType = 'E' THEN JD.[Total] ELSE 0 END) +
									 (CASE WHEN JD.ResourceType = 'I' THEN JD.[Total] ELSE 0 END) +
									 (CASE WHEN JD.ResourceType = 'V' THEN JD.[Total] ELSE 0 END),
		[PriorYearHours] = CASE WHEN JD.ResourceType = 'E' AND ItemDate < @PriorEndDate THEN JD.[Hours] ELSE 0 END,		
		[PriorYearHoursAmount] = CASE WHEN JD.ResourceType = 'E' AND ItemDate < @PriorEndDate THEN JD.[Total] ELSE 0 END,
		[PriorYearIncomeOnlyCharges] = CASE WHEN JD.ResourceType = 'I' AND ItemDate < @PriorEndDate THEN JD.[Total] ELSE 0 END,		
		[PriorYearVendorCharges] = CASE WHEN JD.ResourceType = 'V' AND PostPeriodCode < @PriorPeriod THEN JD.[Total] ELSE 0 END,		
		[PriorYearTotal] = (CASE WHEN JD.ResourceType = 'E' AND ItemDate < @PriorEndDate THEN JD.[Total] ELSE 0 END) +
					   (CASE WHEN JD.ResourceType = 'I' AND ItemDate < @PriorEndDate THEN JD.[Total] ELSE 0 END) +
					   (CASE WHEN JD.ResourceType = 'V' AND PostPeriodCode < @PriorPeriod THEN JD.[Total] ELSE 0 END),
		[EstimateIncomeOnlyCharges] = CASE WHEN ((JD.ResourceType = 'EI' OR JD.ResourceType = 'ES') AND JD.FunctionType = 'I') THEN JD.EstimateTotalAmount ELSE 0 END,
		[BilledIncomeOnlyCharges] = CASE WHEN JD.ResourceType = 'I' THEN JD.BilledAmount ELSE 0 END,
		JD.[AdvanceBilledTotal],
		JD.[FlatIncomeRecognized],
		JD.[AdvanceBilledAmount],
		JD.[AdvanceBillingRetained]
	FROM 
		#JOB AS J INNER JOIN 
		#JOB_DETAIL AS JD ON J.[JobNumber] = JD.[JobNumber] AND
							 J.[JobComponentNumber] = JD.[JobComponentNumber] LEFT OUTER JOIN 
		dbo.V_ESTIMATEAPPR VEA ON J.EstimateNumber = VEA.ESTIMATE_NUMBER AND
								  J.EstimateComponentNumber  = VEA.EST_COMPONENT_NBR LEFT OUTER JOIN
		dbo.COMPANY_PROFILE CP ON CP.PRD_CODE = J.ProductCode AND CP.DIV_CODE = J.DivisionCode AND CP.CL_CODE = J.ClientCode LEFT OUTER JOIN
		dbo.CLIENT_TYPE1 CT1 ON CT1.CLIENT_TYPE1_ID = CP.CLIENT_TYPE1_ID LEFT OUTER JOIN
		dbo.CLIENT_TYPE2 CT2 ON CT2.CLIENT_TYPE2_ID = CP.CLIENT_TYPE2_ID LEFT OUTER JOIN
		dbo.CLIENT_TYPE3 CT3 ON CT3.CLIENT_TYPE3_ID = CP.CLIENT_TYPE3_ID
OPTION (RECOMPILE)
IF @debug = 1 SELECT getdate() 'after END'

	DROP TABLE #JOB
	DROP TABLE #JOB_DETAIL 

END


GO