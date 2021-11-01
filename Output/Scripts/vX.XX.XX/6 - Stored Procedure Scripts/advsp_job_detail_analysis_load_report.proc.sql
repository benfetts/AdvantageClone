
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_detail_analysis_load_report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_detail_analysis_load_report]
GO


CREATE PROCEDURE [dbo].[advsp_job_detail_analysis_load_report](
	@OPEN_JOB_ONLY AS bit = 1,
	@EXCLUDE_NONBILL_HRS AS bit = 0,
	@OFFICE_LIST AS varchar(MAX) = NULL,
	@CLIENT_LIST AS varchar(MAX) = NULL,
	@DIVISION_LIST AS varchar(MAX) = NULL,
	@PRODUCT_LIST AS varchar(MAX) = NULL,
	@JOB_LIST AS varchar(MAX) = NULL,
	@ACCT_EXEC_LIST AS varchar(MAX) = NULL,
	@SALES_CLASS_LIST AS varchar(MAX) = NULL,
	@DATE_CUTOFF AS VARCHAR(6),
	@USER_CODE AS varchar(100), @debug bit = 0

)
AS
BEGIN

	DECLARE @TRAFFIC_MGR_COL varchar(20)				
	
	DECLARE @StartDate smalldatetime, @EndDate smalldatetime

	SELECT @StartDate = PPSRTDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @DATE_CUTOFF

	SELECT @EndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @DATE_CUTOFF	

	DECLARE @RESTRICTIONS INT
	
	SELECT @RESTRICTIONS = COUNT(*) FROM dbo.SEC_CLIENT WHERE SEC_CLIENT.[USER_ID] = @USER_CODE

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
		--[CampaignID] int,
		--[CampaignCode] varchar(6),
		--[CampaignName] varchar(60),
		--[BillingBudget] decimal(9, 2), 
		--[IncomeBudget] decimal(9, 2), 
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
		--[LabelFromUDFTable1] varchar(40),
		--[LabelFromUDFTable2] varchar(40),
		--[LabelFromUDFTable3] varchar(40),
		--[LabelFromUDFTable4] varchar(40),
		--[LabelFromUDFTable5] varchar(40),
		[JobOpen] varchar(3),
		[ComponentNumber] smallint,
		[JobComponent] varchar(20),
		[BillHold] varchar(3),
		[AccountExecutiveCode] varchar(6),
		[AccountExecutive] varchar(100),
		--[ManagerCode] varchar(6),
		--[Manager] varchar(100),
		[ComponentDateOpened] smalldatetime,
		[DueDate] smalldatetime,
		[StartDate] smalldatetime,
		--[Status] varchar(30),
		--[GutPercentComplete] decimal(7, 3),
		[AdSize] varchar(60),
		[DepartmentTeamCode] varchar(4),
		[DepartmentTeam] varchar(30),
		[MarkupPercent] decimal(7, 3),
		[CreativeInstructions] varchar(MAX),
		[JobProcessControlID] smallint,
		[JobProcessControl] varchar(40),
		[ComponentDescription] varchar(60),
		--[ComponentComments] varchar(MAX),
		[ComponentBudget] decimal(11, 2),
		[EstimateNumber] int,
		[EstimateComponentNumber] smallint,
		[BillingUser] varchar(100),
		[AdvanceBill] smallint,
		[AdvanceBillFlag] varchar(100),
		[DeliveryInstructions] varchar(MAX),
		[JobTypeCode] varchar(10),
		[JobTypeDescription] varchar(30),
		[Taxable] varchar(3),
		[TaxCode] varchar(4),
		--[TaxCodeDescription] varchar(30),
		[NonBillable] smallint,
		[AlertGroup] varchar(50),
		[AdNumber] varchar(30),
		[AccountNumber] varchar(30),
		[IncomeRecognitionMethod] varchar(30),
		--[MarketCode] varchar(10),
		--[MarketDescription] varchar(40),
		--[ServiceFeeJob] varchar(3),
		--[ServiceFeeTypeCode] varchar(6),
		--[ServiceFeeTypeDescription] varchar(30),
		[Archived] varchar(3),
		[TrafficScheduleRequired] varchar(3),
		[ClientPO] varchar(40),
		--[CompLabelFromUDFTable1] varchar(40),
		--[CompLabelFromUDFTable2] varchar(40),
		--[CompLabelFromUDFTable3] varchar(40),
		--[CompLabelFromUDFTable4] varchar(40),
		--[CompLabelFromUDFTable5] varchar(40),
		[JobTemplateCode] varchar(6),
		--[FiscalPeriodCode] varchar(6),
		--[FiscalPeriodDescription] varchar(30),
		[JobQuantity] int,
		[BlackplateVersionCode] varchar(6),
		[BlackplateVersionDesc] varchar(60),
		[BlackplateVersion2Code] varchar(6),
		[BlackplateVersion2Desc] varchar(60),
		--[ClientContactCode] varchar(6),
		--[ClientContactID] int,
		[BABatchID] int,
		--[ClientContact] varchar(100),
		[SelectedBABatchID] int,
		--[BillingCommandCenterID] int,
		--[AlertAssignmentTemplate] varchar(100),	
		[IsNewBusiness] smallint--,
		--[Agency] int,
		--[ProductUDF1] varchar(50),
		--[ProductUDF2] varchar(50),
		--[ProductUDF3] varchar(50),
		--[ProductUDF4] varchar(50),
		--[CompletedDate] smalldatetime--,
		--[JobProcessControlDate] smalldatetime
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
		[ItemLineNumber] int,
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
		[ProductCategoryDescription] varchar(60)
	);	

	SELECT 
		@TRAFFIC_MGR_COL = CAST(AGYS.AGY_SETTINGS_VALUE AS varchar(20)) 
	FROM 
		[dbo].[AGY_SETTINGS] AS AGYS
	WHERE 
		AGYS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL'	

	IF @debug = 1
	SELECT GETDATE() 'START'

	if @RESTRICTIONS > 0
	BEGIN
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
			--[CampaignID] = CAMP.CMP_IDENTIFIER,
			--[CampaignCode] = J.CMP_CODE, 
			--[CampaignName] = CAMP.CMP_NAME,
			--[BillingBudget] = CAMP.CMP_BILL_BUDGET, 
			--[IncomeBuget] = CAMP.CMP_INC_BUDGET, 
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
			--[LabelFromUDFTable1] = JUDV1.UDV_DESC,
			--[LabelFromUDFTable2] = JUDV2.UDV_DESC,
			--[LabelFromUDFTable3] = JUDV3.UDV_DESC,
			--[LabelFromUDFTable4] = JUDV4.UDV_DESC,
			--[LabelFromUDFTable5] = JUDV5.UDV_DESC,
			[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
			[ComponentNumber] = JC.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
			[BillHold] = JC.JOB_BILL_HOLD,
			[AccountExecutiveCode] = JC.EMP_CODE,
			[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
			--[ManagerCode] = PJM.MANAGER_CODE,
			--[Manager] = PJM.MANAGER,
			[ComponentDateOpened] = JC.JOB_COMP_DATE,
			[DueDate] = JC.JOB_FIRST_USE_DATE,
			[StartDate] = JC.[START_DATE],
			--[Status] = T.TRF_DESCRIPTION,
			--[GutPercentComplete] = JOBT.PERCENT_COMPLETE,
			[AdSize] = JC.JOB_AD_SIZE,
			[DepartmentTeamCode] = JC.DP_TM_CODE,
			[DepartmentTeam] = DT.DP_TM_DESC,
			[MarkupPercent] = JC.JOB_MARKUP_PCT,
			[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
			[JobProcessControlID] = JC.JOB_PROCESS_CONTRL,
			[JobProcessControl] = JPC.JOB_PROCESS_DESC,
			[ComponentDescription] = JC.JOB_COMP_DESC,
			--[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
			[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
			[EstimateNumber] = JC.ESTIMATE_NUMBER,
			[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
			[BillingUser] = JC.BILLING_USER,
			[AdvanceBill] = JC.AB_FLAG,
			[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
			[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
			[JobTypeCode] = JC.JT_CODE,
			[JobTypeDescription] = JT.JT_DESC,
			[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			[TaxCode] = JC.TAX_CODE,
			--[TaxCodeDescription] = ST.TAX_DESCRIPTION,
			[NonBillable] = JC.NOBILL_FLAG,
			[AlertGroup] = JC.EMAIL_GR_CODE,
			[AdNumber] = JC.AD_NBR,
			[AccountNumber] = JC.ACCT_NBR,
			[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
			--[MarketCode] = JC.MARKET_CODE,
			--[MarketDescription] = M.MARKET_DESC,
			--[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			--[ServiceFeeTypeCode] = SFT.CODE,
			--[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
			[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
			[ClientPO] = JC.JOB_CL_PO_NBR,
			--[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
			--[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
			--[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
			--[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
			--[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
			[JobTemplateCode] = JC.JOB_TMPLT_CODE,
			--[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
			--[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
			[JobQuantity] = JC.JOB_QTY,
			[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
			[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
			[BlackplateVersion2Code] = JC.BLACKPLT_VER2_CODE,
			[BlackplateVersion2Desc] = JC.BLACKPLT_VER2_DESC,
			--[ClientContactCode] = JC.PRD_CONT_CODE,
			--[ClientContactID] = JC.CDP_CONTACT_ID,
			[BABatchID] = JC.BA_BATCH_ID,
			--[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
			[SelectedBABatchID] = JC.SELECTED_BA_ID,
			--[BillingCommandCenterID] = JC.BCC_ID,
			--[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
			[IsNewBusiness] = C.NEW_BUSINESS--,
			--[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			--[ProductUDF1] = P.USER_DEFINED1,
			--[ProductUDF2] = P.USER_DEFINED2,
			--[ProductUDF3] = P.USER_DEFINED3,
			--[ProductUDF4] = P.USER_DEFINED4,
			--[CompletedDate] = JOBT.COMPLETED_DATE--,
			--[JobProcessControlDate] = JPL_DATE.PROCESS_DATE
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
			--[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
			[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN 
			(SELECT SEC_CLIENT.CL_CODE,
							SEC_CLIENT.DIV_CODE,
							SEC_CLIENT.PRD_CODE,
							SEC_CLIENT.[USER_ID],
							SEC_CLIENT.TIME_ENTRY 
					 FROM dbo.SEC_CLIENT WITH(NOLOCK)
					 WHERE SEC_CLIENT.[USER_ID] = @USER_CODE) AS SEC_CLIENT ON J.CL_CODE = SEC_CLIENT.CL_CODE AND
																			 J.DIV_CODE = SEC_CLIENT.DIV_CODE AND
																			 J.PRD_CODE = SEC_CLIENT.PRD_CODE --LEFT OUTER JOIN
			--[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
			--[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
			--[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE-- LEFT OUTER JOIN
			--[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
			--[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
			--(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
			--[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
			--[dbo].[JOB_TRAFFIC] AS JOBT ON JOBT.JOB_NUMBER = JC.JOB_NUMBER AND JOBT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
			--[dbo].[TRAFFIC] AS T ON T.TRF_CODE = JOBT.TRF_CODE --LEFT OUTER JOIN
			--(SELECT
			--		PM.JOB_NUMBER,
			--		PM.JOB_COMPONENT_NBR,
			--		PM.[MANAGER_CODE],
			--		[MANAGER] =  CASE WHEN PM.MANAGER_CODE IS NULL THEN NULL ELSE COALESCE((RTRIM(PEMP.EMP_FNAME) + ' '),'') + COALESCE((PEMP.EMP_MI + '. '),'') + COALESCE(PEMP.EMP_LNAME,'') END
			--	FROM
			--		(SELECT
			--			JT.JOB_NUMBER,
			--			JT.JOB_COMPONENT_NBR,
			--			[MANAGER_CODE] = CASE @TRAFFIC_MGR_COL  WHEN 'TR_TITLE1' THEN JT.ASSIGN_1   							
			--													WHEN 'TR_TITLE2' THEN JT.ASSIGN_2   							
			--													WHEN 'TR_TITLE3' THEN JT.ASSIGN_3  							
			--													WHEN 'TR_TITLE4' THEN JT.ASSIGN_4   							
			--													WHEN 'TR_TITLE5' THEN JT.ASSIGN_5  							
			--													ELSE NULL  END  					       
			--		FROM 
			--			[dbo].[JOB_TRAFFIC] AS JT) AS PM LEFT OUTER JOIN
			--			[dbo].[EMPLOYEE_CLOAK] AS PEMP ON PEMP.EMP_CODE = PM.[MANAGER_CODE]) AS PJM ON PJM.JOB_NUMBER = JC.JOB_NUMBER AND 
			--																						   PJM.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
			--(SELECT 
			--	JOB_NUMBER, 
			--	JOB_COMPONENT_NBR, 
			--	PROCESS_DATE = MAX(PROCESS_DATE) 
			-- FROM 
			--	dbo.JOB_PROCESS_LOG 
			-- GROUP BY 
			--	JOB_NUMBER, 
			--	JOB_COMPONENT_NBR) JPL_DATE ON JC.JOB_NUMBER = JPL_DATE.JOB_NUMBER AND
			--								   JC.JOB_COMPONENT_NBR = JPL_DATE.JOB_COMPONENT_NBR
		WHERE
			1 = CASE WHEN @RESTRICTIONS = 0 THEN 1 WHEN SEC_CLIENT.[USER_ID] = @USER_CODE AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0) THEN 1 ELSE 0 END AND
			1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JPC.JOB_PROCESS_DESC = 'Closed' OR JPC.JOB_PROCESS_DESC = 'Archive') THEN 0 ELSE 1 END AND
			--1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND C.[IsNonBillable] = 1 THEN 0 ELSE 1 END AND
			(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
			(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
			1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
			1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
			(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
			(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
			(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL)	
	END
	ELSE 
	BEGIN
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
			--[CampaignID] = CAMP.CMP_IDENTIFIER,
			--[CampaignCode] = J.CMP_CODE, 
			--[CampaignName] = CAMP.CMP_NAME,
			--[BillingBudget] = CAMP.CMP_BILL_BUDGET, 
			--[IncomeBuget] = CAMP.CMP_INC_BUDGET, 
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
			--[LabelFromUDFTable1] = JUDV1.UDV_DESC,
			--[LabelFromUDFTable2] = JUDV2.UDV_DESC,
			--[LabelFromUDFTable3] = JUDV3.UDV_DESC,
			--[LabelFromUDFTable4] = JUDV4.UDV_DESC,
			--[LabelFromUDFTable5] = JUDV5.UDV_DESC,
			[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
			[ComponentNumber] = JC.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
			[BillHold] = JC.JOB_BILL_HOLD,
			[AccountExecutiveCode] = JC.EMP_CODE,
			[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
			--[ManagerCode] = PJM.MANAGER_CODE,
			--[Manager] = PJM.MANAGER,
			[ComponentDateOpened] = JC.JOB_COMP_DATE,
			[DueDate] = JC.JOB_FIRST_USE_DATE,
			[StartDate] = JC.[START_DATE],
			--[Status] = T.TRF_DESCRIPTION,
			--[GutPercentComplete] = JOBT.PERCENT_COMPLETE,
			[AdSize] = JC.JOB_AD_SIZE,
			[DepartmentTeamCode] = JC.DP_TM_CODE,
			[DepartmentTeam] = DT.DP_TM_DESC,
			[MarkupPercent] = JC.JOB_MARKUP_PCT,
			[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
			[JobProcessControlID] = JC.JOB_PROCESS_CONTRL,
			[JobProcessControl] = JPC.JOB_PROCESS_DESC,
			[ComponentDescription] = JC.JOB_COMP_DESC,
			--[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
			[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
			[EstimateNumber] = JC.ESTIMATE_NUMBER,
			[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
			[BillingUser] = JC.BILLING_USER,
			[AdvanceBill] = JC.AB_FLAG,
			[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
			[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
			[JobTypeCode] = JC.JT_CODE,
			[JobTypeDescription] = JT.JT_DESC,
			[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			[TaxCode] = JC.TAX_CODE,
			--[TaxCodeDescription] = ST.TAX_DESCRIPTION,
			[NonBillable] = JC.NOBILL_FLAG,
			[AlertGroup] = JC.EMAIL_GR_CODE,
			[AdNumber] = JC.AD_NBR,
			[AccountNumber] = JC.ACCT_NBR,
			[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
			--[MarketCode] = JC.MARKET_CODE,
			--[MarketDescription] = M.MARKET_DESC,
			--[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			--[ServiceFeeTypeCode] = SFT.CODE,
			--[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
			[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
			[ClientPO] = JC.JOB_CL_PO_NBR,
			--[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
			--[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
			--[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
			--[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
			--[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
			[JobTemplateCode] = JC.JOB_TMPLT_CODE,
			--[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
			--[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
			[JobQuantity] = JC.JOB_QTY,
			[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
			[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
			[BlackplateVersion2Code] = JC.BLACKPLT_VER2_CODE,
			[BlackplateVersion2Desc] = JC.BLACKPLT_VER2_DESC,
			--[ClientContactCode] = JC.PRD_CONT_CODE,
			--[ClientContactID] = JC.CDP_CONTACT_ID,
			[BABatchID] = JC.BA_BATCH_ID,
			--[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
			[SelectedBABatchID] = JC.SELECTED_BA_ID,
			--[BillingCommandCenterID] = JC.BCC_ID,
			--[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
			[IsNewBusiness] = C.NEW_BUSINESS--,
			--[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			--[ProductUDF1] = P.USER_DEFINED1,
			--[ProductUDF2] = P.USER_DEFINED2,
			--[ProductUDF3] = P.USER_DEFINED3,
			--[ProductUDF4] = P.USER_DEFINED4,
			--[CompletedDate] = JOBT.COMPLETED_DATE--,
			--[JobProcessControlDate] = JPL_DATE.PROCESS_DATE
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
			--[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
			[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL --LEFT OUTER JOIN
			--[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
			--[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
			--[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE-- LEFT OUTER JOIN
			--[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
			--[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
			--[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
			--[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
			--(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN 
			--[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
			--[dbo].[JOB_TRAFFIC] AS JOBT ON JOBT.JOB_NUMBER = JC.JOB_NUMBER AND JOBT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
			--[dbo].[TRAFFIC] AS T ON T.TRF_CODE = JOBT.TRF_CODE --LEFT OUTER JOIN
			--(SELECT
			--		PM.JOB_NUMBER,
			--		PM.JOB_COMPONENT_NBR,
			--		PM.[MANAGER_CODE],
			--		[MANAGER] =  CASE WHEN PM.MANAGER_CODE IS NULL THEN NULL ELSE COALESCE((RTRIM(PEMP.EMP_FNAME) + ' '),'') + COALESCE((PEMP.EMP_MI + '. '),'') + COALESCE(PEMP.EMP_LNAME,'') END
			--	FROM
			--		(SELECT
			--			JT.JOB_NUMBER,
			--			JT.JOB_COMPONENT_NBR,
			--			[MANAGER_CODE] = CASE @TRAFFIC_MGR_COL  WHEN 'TR_TITLE1' THEN JT.ASSIGN_1   							
			--													WHEN 'TR_TITLE2' THEN JT.ASSIGN_2   							
			--													WHEN 'TR_TITLE3' THEN JT.ASSIGN_3  							
			--													WHEN 'TR_TITLE4' THEN JT.ASSIGN_4   							
			--													WHEN 'TR_TITLE5' THEN JT.ASSIGN_5  							
			--													ELSE NULL  END  					       
			--		FROM 
			--			[dbo].[JOB_TRAFFIC] AS JT) AS PM LEFT OUTER JOIN
			--			[dbo].[EMPLOYEE_CLOAK] AS PEMP ON PEMP.EMP_CODE = PM.[MANAGER_CODE]) AS PJM ON PJM.JOB_NUMBER = JC.JOB_NUMBER AND 
			--																						   PJM.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
			--(SELECT 
			--	JOB_NUMBER, 
			--	JOB_COMPONENT_NBR, 
			--	PROCESS_DATE = MAX(PROCESS_DATE) 
			-- FROM 
			--	dbo.JOB_PROCESS_LOG 
			-- GROUP BY 
			--	JOB_NUMBER, 
			--	JOB_COMPONENT_NBR) JPL_DATE ON JC.JOB_NUMBER = JPL_DATE.JOB_NUMBER AND
			--								   JC.JOB_COMPONENT_NBR = JPL_DATE.JOB_COMPONENT_NBR
		WHERE
			1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JPC.JOB_PROCESS_DESC = 'Closed' OR JPC.JOB_PROCESS_DESC = 'Archive') THEN 0 ELSE 1 END AND
			--1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND C.[IsNonBillable] = 1 THEN 0 ELSE 1 END AND
			(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
			(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
			1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
			1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
			(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
			(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
			(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL)	
	END	
	
	IF @debug = 1
	SELECT GETDATE() 'BEFORE AB'

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
		[ItemLineNumber] = 0,
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
		[ProductCategoryDescription] = null
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
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		--1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND C.[IsNonBillable] = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL) AND
		1 = CASE WHEN AR.AR_POST_PERIOD <= @DATE_CUTOFF THEN 1 ELSE 0 END

	IF @debug = 1
	SELECT GETDATE() 'BEFORE C'

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
		[ItemLineNumber] = 0,
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
		[ProductCategoryDescription] = null
	FROM 
		[dbo].[CLIENT_OOP] AS COOP INNER JOIN  
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = COOP.FNC_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = COOP.JOB_NUMBER AND
									   JC.JOB_COMPONENT_NBR = COOP.JOB_COMPONENT_NBR INNER JOIN
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
	WHERE
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		--1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND C.[IsNonBillable] = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL) AND
		1 = CASE WHEN COOP.INV_DATE <= CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END

IF @debug = 1
	SELECT GETDATE() 'BEFORE E'
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
		[ItemLineNumber] = ETD.SEQ_NBR,
		[ItemDescription] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
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
		[BillingApprovalTotalAmount] = 0,
		[EmployeeDefaultDepartmentCode] = NULL,
		[EmployeeDefaultDepartmentDescription] = NULL,
		[EmployeeTimeDepartmentCode] = NULL,
		[EmployeeTimeDepartmentDescription] = NULL,
		[DateEntered] = NULL,
		[DefaultRoleCode] = NULL,
		[DefaultRole] = NULL,
		[EmployeeOfficeCode] = EMP.OFFICE_CODE,
		[EmployeeOfficeDescription] = O.OFFICE_NAME,
		[EmployeeTitle] = NULL,
		[IsEmployeeFreelance] = NULL,
		[IsActiveFreelance] = NULL,
		[EmployeeRateFrom] = NULL,
		[DirectHoursGoalPercent] = NULL,
		[ProductCategoryCode] = CAST(NULL AS varchar(8)),--ETD.PROD_CAT_CODE,
		[ProductCategoryDescription] = CAST(NULL AS varchar(8))--PD.PROD_CAT_DESC
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
		[dbo].[OFFICE] AS O ON EMP.OFFICE_CODE = O.OFFICE_CODE --LEFT OUTER JOIN
		--[dbo].[PRODUCT_CATEGORY] PD ON J.CL_CODE = PD.CL_CODE AND
		--								J.DIV_CODE = PD.DIV_CODE AND
		--								J.PRD_CODE = PD.PRD_CODE AND 
		--								ETD.PROD_CAT_CODE = PD.PROD_CAT_CODE
	WHERE
		(ETD.EDIT_FLAG <> 1 OR ETD.EDIT_FLAG IS NULL) AND
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL) AND
		1 = CASE WHEN ET.EMP_DATE <= CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END AND ISNULL(ETD.EMP_HOURS, 0) <> 0 --AND ISNULL(ETD.LINE_TOTAL, 0) <> 0 

IF @debug = 1
	SELECT GETDATE() 'BEFORE EI'
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
		[ItemLineNumber] = 0,
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
		[ProductCategoryDescription] = null
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
	WHERE
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		--1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL) 

IF @debug = 1
	SELECT GETDATE() 'BEFORE ES'			
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
		[ItemLineNumber] = 0,
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
		[ProductCategoryDescription] = null
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
	WHERE
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		--1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL)

IF @debug = 1
	SELECT GETDATE() 'BEFORE I'
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
		[ItemLineNumber] = 0,
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
		[ProductCategoryDescription] = null
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
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL) AND
		1 = CASE WHEN [IO].IO_INV_DATE <= CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END

IF @debug = 1
	SELECT GETDATE() 'BEFORE PO'
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
		[ItemLineNumber] = 0,
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
		[ProductCategoryDescription] = null
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
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		--1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL([IO].NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL)  --AND
		--1 = CASE WHEN PO.PO_DATE <= CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END

IF @debug = 1
	SELECT GETDATE() 'BEFORE V'
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
		[ItemLineNumber] = APP.LINE_NUMBER,
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
		[ProductCategoryDescription] = null
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
	WHERE --(APP.MODIFY_DELETE IS NULL OR APP.MODIFY_DELETE = 0) AND
		1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
		1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL(APP.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE 1 END AND
		(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
		(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
		(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
		(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL)  AND
		1 = CASE WHEN APP.POST_PERIOD <= @DATE_CUTOFF THEN 1 ELSE 0 END

IF @debug = 1
	SELECT GETDATE() 'BEFORE MAIN'
	--SELECT *
	--FROM 
	--	#JOB AS J INNER JOIN 
	--	#JOB_DETAIL AS JD ON J.[JobNumber] = JD.[JobNumber] AND
	--						 J.[JobComponentNumber] = JD.[JobComponentNumber]
 --   WHERE J.JobNumber = 89653
	--SELECT * FROM (
	SELECT
		[ID] = ISNULL(NEWID(), NEWID()),
		[MarkupPercent] = JDA.[MarkupPercent],
		[JobComponent] = JDA.[JobComponent],
		[IsNonBillableJob] = JDA.[IsNonBillableJob],
		[IsNonBillable] = JDA.[IsNonBillable],
		[Hold] = JDA.[Hold],
		[AdvanceBillFlag] = JDA.[AdvanceBillFlag],
		[ClientCode] = JDA.[ClientCode],
		[ClientDescription] = JDA.[ClientDescription],
		[DivisionCode] = JDA.[DivisionCode],
		[DivisionDescription] = JDA.[DivisionDescription],
		[ProductCode] = JDA.[ProductCode],
		[ProductDescription] = JDA.[ProductDescription],
		[AccountExecutiveCode] = JDA.[AccountExecutiveCode],
		[AccountExecutive] = JDA.[AccountExecutive],
		[ClientReference] = JDA.[ClientReference],
		[JobNumber] = JDA.[JobNumber],
		[JobDescription] = JDA.[JobDescription],
		[SalesClassCode] = JDA.[SalesClassCode],
		[JobComponentNumber] = JDA.[JobComponentNumber],
		[ComponentDescription] = JDA.[ComponentDescription],
		[JobTypeCode] = JDA.[JobTypeCode],
		[FunctionTypeOrder] = JDA.[FunctionTypeOrder],
		[FunctionType] = JDA.[FunctionType],
		[FunctionTypeDescription] = JDA.[FunctionTypeDescription],
		[Order] = JDA.[Order],
		[FunctionCode] = JDA.[FunctionCode],
		[FunctionDescription] = JDA.[FunctionDescription],
		[ItemDescription] = JDA.[ItemDescription],
		[ItemDate] = JDA.[ItemDate],	
		[ItemCode] = JDA.[ItemCode],
		[ItemLineNumber] = JDA.[ItemLineNumber],
		[ClientPO] = JDA.[ClientPO],
		[StartDate] = JDA.[StartDate],
		[DueDate] = JDA.[DueDate],
		[SumOfEstimateHours] = SUM(JDA.[SumOfEstimateHours]),
		[SumOfEstimate] = SUM(JDA.[SumOfEstimate]),
		[SumOfEstimateCont] = SUM(JDA.[SumOfEstimateCont]),
		[SumOfEstimateNetCost] = SUM(JDA.[SumOfEstimateNetCost]),
		[SumOfEstimateNetAmount] = SUM(JDA.[SumOfEstimateNetAmount]),
		[SumOfEstimateExtMarkup] = SUM(JDA.[SumOfEstimateExtMarkup]),
		[SumOfEstimateVenTax] = SUM(JDA.[SumOfEstimateVenTax]),
		[SumOfEstimateResaleTax] = SUM(JDA.[SumOfEstimateResaleTax]),
		[SumOfIncomeOnly] = SUM(JDA.[SumOfIncomeOnly]),
		[SumOfBillEmpHours] = SUM(JDA.[SumOfBillEmpHours]),
		[SumOfTotalBill] = SUM(JDA.[SumOfTotalBill]),
		[SumOfAPQuantity] = SUM(JDA.[SumOfAPQuantity]),
		[SumOfAPNetCost] = SUM(JDA.[SumOfAPNetCost]),
		[SumOfExtMarkupAmount] = SUM(JDA.[SumOfExtMarkupAmount]),
		[SumOfVenTax] = SUM(JDA.[SumOfVenTax]),
		[SumOfResaleTax] = SUM(JDA.[SumOfResaleTax]),
		[SumOfResaleBilled] = SUM(JDA.[SumOfResaleBilled]),
		[SumOfOpenPOAmount] = SUM(JDA.[SumOfOpenPOAmount]),
		[SumOfLineTotal] = SUM(JDA.[SumOfLineTotal]),
		[SumOfNonBillableEmpHours] = SUM(JDA.[SumOfNonBillableEmpHours]),
		[SumOfNonBillableAmount] = SUM(JDA.[SumOfNonBillableAmount]),
		[SumOfBilledAmount] = SUM(JDA.[SumOfBilledAmount]),
		[SumOfAdvanceBilled] = SUM(JDA.[SumOfAdvanceBilled]),
		[SumOfAdvanceTotal] = SUM(JDA.[SumOfAdvanceTotal]),
		[SumOfAdvanceResale] = SUM(JDA.[SumOfAdvanceResale]),
		[SumOfAdvanceResaleBilled] = SUM(JDA.[SumOfAdvanceResaleBilled]),
		[SumOfAdvanceFinalBilled] = SUM(JDA.[SumOfAdvanceFinalBilled]),
		[SumOfBilledCost] = SUM(JDA.[SumOfBilledCost]),
		[SumOfUnbilled] = SUM(JDA.[SumOfUnbilled]),
		[ProcessDesc] = JDA.[ProcessDesc],
		[JobProcessControl] =  JDA.[JobProcessControl],
		--[Code] = CASE WHEN SUM(JDA.[SumOfEstimate]) = 0 AND SUM(JDA.[SumOfTotalBill]) = 0 AND SUM(JDA.[SumOfLineTotal]) = 0 AND 
		--				   SUM(JDA.[SumOfOpenPOAmount]) = 0 AND SUM(JDA.[SumOfAdvanceTotal]) = 0 AND SUM(JDA.[SumOfBilledAmount]) = 0 AND 
		--				   SUM(JDA.[SumOfAdvanceBilled]) = 0 AND SUM(JDA.[SumOfNonBillableAmount]) = 0 AND SUM(JDA.[SumOfBilledCost]) = 0 AND 
		--				   SUM(JDA.[SumOfBillEmpHours]) = 0 THEN 'X' ELSE NULL END,	
		[ZeroMU] = SUM(JDA.[ZeroMU]),
		[IsAdvanceBill] = ISNULL(JDA.[IsAdvanceBill],''),
		[EstimateNumber] = JDA.[EstimateNumber],
		[EstimateComponentNumber] = JDA.[EstimateComponentNumber]
	FROM
		(SELECT 
		[ID] = ISNULL(NEWID(), NEWID()),
		[MarkupPercent] = J.MarkupPercent,
		[JobComponent] = J.JobComponent,
		[IsNonBillableJob] = CASE J.NonBillable WHEN 1 THEN 'Non-Billable'
												   ELSE 'Billable' END,
		[IsNonBillable] = CASE JD.IsNonBillable WHEN 1 THEN 'Non-Billable'
												   ELSE 'Billable' END,
		[Hold] = CASE J.BillHold WHEN 1 THEN 'Temporary'
									   WHEN 2 THEN 'Permanent'
									   ELSE 'None' END,
		[AdvanceBillFlag] = J.AdvanceBill,
		[ClientCode] = J.[ClientCode],
		[ClientDescription] = J.[ClientDescription],
		[DivisionCode] = J.[DivisionCode],
		[DivisionDescription] = J.[DivisionDescription],
		[ProductCode] = J.[ProductCode],
		[ProductDescription] = J.[ProductDescription],
		[AccountExecutiveCode] = J.[AccountExecutiveCode],
		[AccountExecutive] = J.[AccountExecutive],
		[ClientReference] = J.[ClientReference],
		[JobNumber] = J.JobNumber,
		[JobDescription] = J.[JobDescription],
		[SalesClassCode] = J.[SalesClassCode],
		[JobComponentNumber] = J.JobComponentNumber,
		[ComponentDescription] = J.[ComponentDescription],
		[JobTypeCode] = J.[JobTypeCode],
		[FunctionTypeOrder] = CASE JD.FunctionType WHEN 'E' THEN 1
														WHEN 'V' THEN 2
														WHEN 'I' THEN 3 END,
		[FunctionType] = JD.FunctionType,
		[FunctionTypeDescription] = CASE JD.FunctionType WHEN 'E' THEN 'Employee Time'
													   WHEN 'V' THEN 'Vendor'
													   WHEN 'I' THEN ' Income Only' END,
		[Order] = CASE JD.[ResourceType] WHEN 'ES' THEN 1 WHEN 'AB' THEN 2 WHEN 'E' THEN 3 WHEN 'I' THEN 4 WHEN 'V' THEN 5 WHEN 'PO' THEN 6 END,
		[FunctionCode] = JD.FunctionCode,
		[FunctionDescription] = JD.[FunctionDescription],
		[ItemDescription] = JD.ItemDescription,
		[ItemDate] = CASE JD.[FunctionType] WHEN 'E' THEN JD.[ItemDate] WHEN 'V' THEN JD.[ItemDate] WHEN 'I' THEN JD.[ItemDate] ELSE NULL END,	
		[ItemCode] = CASE JD.[ResourceType] WHEN 'AB' THEN CAST(JD.[ItemID] AS varchar) WHEN 'E' THEN NULL WHEN 'I' THEN NULL WHEN 'V' THEN JD.[ItemExtra] WHEN 'PO' THEN 'PO #: ' + CAST(JD.[PurchaseOrderNumber] AS varchar) END,
		[ItemLineNumber] = JD.ItemLineNumber,
		[ClientPO] = J.[ClientPO],
		[StartDate] = J.[StartDate],
		[DueDate] = J.[DueDate],
		[SumOfEstimateHours] = CASE WHEN (JD.[ResourceType] IN('ES','EI') AND JD.[FunctionType] IN('V')) THEN JD.[EstimateQuantity] ELSE JD.[EstimateHours] END,
		[SumOfEstimate] = ISNULL(JD.[EstimateTotalAmount],0) + ISNULL(JD.[EstimateContTotalAmount],0),
		[SumOfEstimateCont] = JD.[EstimateContTotalAmount],
		[SumOfEstimateNetCost] = JD.[EstimateCostAmount],
		[SumOfEstimateNetAmount] = JD.[EstimateNetAmount],
		[SumOfEstimateExtMarkup] = JD.[EstimateMarkupAmount],
		[SumOfEstimateVenTax] = JD.[EstimateNonResaleTaxAmount],
		[SumOfEstimateResaleTax] = JD.[EstimateResaleTaxAmount],
		[SumOfIncomeOnly] = CASE WHEN JD.[ResourceType] = 'I' THEN JD.[Total] - JD.[ResaleTaxAmount] ELSE 0 END,
		[SumOfBillEmpHours] = CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 0 THEN JD.[Hours] ELSE 0 END,
		[SumOfTotalBill] = CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 0 THEN JD.[BillableLessResale] ELSE 0 END,
		[SumOfAPQuantity] = CASE JD.[ResourceType] WHEN 'V' THEN JD.[Quantity] ELSE 0 END,
		[SumOfAPNetCost] = CASE WHEN JD.[ResourceType] = 'V' OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[CostAmount] ELSE 0 END,
		[SumOfExtMarkupAmount] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN JD.[ExtMarkupAmount] ELSE 0 END,
		[SumOfVenTax] = CASE WHEN JD.[ResourceType] = 'V' AND JD.[IsNonBillable] = 0 AND (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) THEN JD.[NonResaleTaxAmount] ELSE 0 END,
		[SumOfResaleTax] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN JD.[ResaleTaxAmount] ELSE 0 END,
		[SumOfResaleBilled] = CASE WHEN (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) AND JD.[IsNonBillable] = 0  THEN JD.[ResaleTaxAmount] ELSE 0 END,
		[SumOfOpenPOAmount] = ISNULL(JD.[OpenPurchaseOrderAmount],0),
		[SumOfLineTotal] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN JD.[Total] ELSE 0 END,
		[SumOfNonBillableEmpHours] = CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 1 THEN JD.[Hours] ELSE 0 END,
		[SumOfNonBillableAmount] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 1 THEN JD.[Total] - JD.[ResaleTaxAmount] ELSE 0 END,
		[SumOfBilledAmount] = CASE WHEN JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[Total] ELSE 0 END,
		[SumOfAdvanceBilled] = CASE WHEN (JD.[ResourceType] = 'AB' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL) OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[BilledWithResale] ELSE 0 END,
		[SumOfAdvanceTotal] = CASE JD.[ResourceType] WHEN 'AB' THEN JD.[BilledAmount] ELSE 0 END,
		[SumOfAdvanceResale] = CASE JD.[ResourceType] WHEN 'AB' THEN JD.[ResaleTaxAmount] ELSE 0 END,
		[SumOfAdvanceResaleBilled] = CASE WHEN (JD.[ResourceType] = 'AB' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL) OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[ResaleTaxAmount] ELSE 0 END,
		[SumOfAdvanceFinalBilled] = CASE WHEN JD.[ResourceType] = 'AB' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL AND JD.[AdvanceBillFlagDetail] = 5 THEN JD.[BilledAmount] ELSE 0 END,
		[SumOfBilledCost] = CASE WHEN JD.[ResourceType] = 'V' AND JD.[IsNonBillable] = 0 AND (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) THEN JD.[CostAmount] + JD.[NonResaleTaxAmount] ELSE 0 END,
		[SumOfUnbilled] = CASE WHEN JD.[AccountsReceivableInvoiceNumber] IS NULL THEN JD.[UnbilledAmount] ELSE 0 END,
		[ProcessDesc] = J.[JobProcessControl],
		[JobProcessControl] =  J.[JobProcessControlID],
		--[Code] = CASE WHEN SUM(ISNULL(JD.[EstimateTotalAmount],0) + ISNULL(JD.[EstimateContTotalAmount],0)) = 0 AND CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 0 THEN SUM(JD.[BillableLessResale]) ELSE 0 END = 0 AND  CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN SUM(JD.[Total]) ELSE 0 END = 0 AND 
		--				   ISNULL(SUM(JD.[OpenPurchaseOrderAmount]),0) = 0 AND CASE JD.[ResourceType] WHEN 'AB' THEN SUM(JD.[BilledAmount]) ELSE 0 END = 0 AND CASE WHEN JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3 THEN SUM(JD.[Total]) ELSE 0 END = 0 AND 
		--				   CASE JD.[ResourceType] WHEN 'AB' THEN SUM(JD.[BilledAmount]) ELSE 0 END = 0 AND CASE WHEN JD.[ResourceType] IN('E','V') AND JD.[IsNonBillable] = 1 THEN SUM(JD.[Total]) - SUM(JD.[ResaleTaxAmount]) ELSE 0 END = 0 AND CASE WHEN JD.[ResourceType] = 'V' AND JD.[IsNonBillable] = 0 AND (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) THEN SUM(JD.[CostAmount]) + SUM(JD.[NonResaleTaxAmount]) ELSE 0 END = 0 AND 
		--				   CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 0 THEN SUM(JD.[Hours]) ELSE 0 END = 0 THEN 'X' ELSE NULL END,	
		[ZeroMU] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN JD.[ExtMarkupAmount] ELSE 0 END,
		[IsAdvanceBill] = CASE JD.[ResourceType] WHEN 'AB' THEN CASE WHEN JD.[BilledAmount] <> 0 THEN 'Y' ELSE '' END END,
		[EstimateNumber] = J.[EstimateNumber],
		[EstimateComponentNumber] = J.[EstimateComponentNumber]
	FROM 
		#JOB AS J INNER JOIN 
		#JOB_DETAIL AS JD ON J.[JobNumber] = JD.[JobNumber] AND
							 J.[JobComponentNumber] = JD.[JobComponentNumber] ) AS JDA 

	GROUP BY 
			JDA.JobNumber, 
			JDA.JobComponentNumber, 
			JDA.[Order], 
			JDA.FunctionType, 
			JDA.FunctionCode, 
			JDA.ItemDescription,
			JDA.[ItemDate], 
			JDA.ItemCode,
			JDA.ItemLineNumber,
			--JDA.ITEM_LINE,
			--JDA.BILL_PERIOD, 
			--JDA.NONAP_DATE, 
			--JDA.NB_FLAG,
			JDA.[JobProcessControl],
			JDA.[MarkupPercent],
			JDA.[ClientPO],
			JDA.[Hold],
			JDA.[AdvanceBillFlag],
			JDA.[ClientCode],
			JDA.[ClientDescription],
			JDA.[DivisionCode],
			JDA.[DivisionDescription],
			JDA.[ProductCode],
			JDA.[ProductDescription],
			JDA.[AccountExecutiveCode],
			JDA.[AccountExecutive],
			JDA.[ClientReference],
			JDA.[JobDescription],
			JDA.[SalesClassCode],
			JDA.[ComponentDescription],
			JDA.[JobTypeCode],
			JDA.[EstimateNumber],
			JDA.[EstimateComponentNumber],
			JDA.[JobComponent],
			JDA.[FunctionDescription],
			JDA.IsNonBillable,
			JDA.[IsNonBillableJob],
			JDA.[FunctionTypeOrder],
			JDA.[FunctionTypeDescription],
			JDA.[ProcessDesc],
			JDA.[IsAdvanceBill],
			JDA.[StartDate],
			JDA.[DueDate]
ORDER BY JDA.[ClientCode],JDA.[DivisionCode],JDA.[ProductCode],JDA.JobNumber,JDA.[JobComponentNumber]   OPTION (RECOMPILE)--) AS J
			--WHERE J.[Code] IS NULL


IF @debug = 1
	SELECT GETDATE() 'DONE'
	DROP TABLE #JOB
	DROP TABLE #JOB_DETAIL 

END
