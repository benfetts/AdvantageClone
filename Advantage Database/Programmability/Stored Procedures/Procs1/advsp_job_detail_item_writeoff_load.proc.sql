
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_detail_item_writeoff_load]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_detail_item_writeoff_load]
GO

CREATE PROCEDURE [dbo].[advsp_job_detail_item_writeoff_load](
	@StartPeriod varchar(6),
	@EndPeriod varchar(6),
	@IncludeEmployeeTime bit,
	@IncludeVendor bit,
	@IncludeIncomeOnly bit,
	@GroupByJob bit
)
AS
BEGIN

	DECLARE @TRAFFIC_MGR_COL varchar(20)			

	DECLARE @JOB TABLE  
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
		[BlackplateVersion2Code] varchar(6),
		[BlackplateVersion2Desc] varchar(60),		
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
		
	DECLARE @JOB_DETAIL TABLE  
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[ResourceType] varchar(3),
		[JobNumber] int,
		[JobComponentNumber] smallint,
		[ClientCode] varchar(6),
		[ClientDescription] varchar(40),
		[DivisionCode] varchar(6),
		[DivisionDescription] varchar(40),
		[ProductCode] varchar(6),
		[ProductDescription] varchar(40),
		[FunctionType] varchar(1),
		[FunctionConsolidationCode] varchar(6),
		[FunctionConsolidation] varchar(30),
		[FunctionHeading] varchar(60),
		[FunctionCode] varchar(6),
		[FunctionDescription] varchar(MAX),
		[ItemID] int,
		[ItemSequenceNumber] int,
		[ItemDate] smalldatetime,
		[PostPeriodCode] varchar(8),
		[ItemCode] varchar(MAX),
		[ItemDescription] varchar(MAX),
		[ItemComment] varchar(MAX),
		[ItemExtra] varchar(20),
		[ItemAdjComments] varchar(MAX),
		[GLXact] int,
		[GLCodeExpense] varchar(30),
		[GLDescriptionExpense] varchar(75),
		[VendorNetWriteoffAmount] decimal(18, 2),
		[VendorGrossWriteoffAmount] decimal(18, 2),
		[TimeBeforeAdjustmentAmount] decimal(18, 2),
		[TimeMarkupAmount] decimal(18, 2),
		[TimeMarkdownAmount] decimal(18, 2),
		[TimeAfterAdjustmentAmount] decimal(18, 2),
		[IncomeOnlyBeforeAdjustmentAmount] decimal(18, 2),
		[IncomeOnlyMarkupAmount] decimal(18, 2),
		[IncomeOnlyMarkdownAmount] decimal(18, 2),
		[IncomeOnlyAfterAdjustmentAmount] decimal(18, 2),
		[TotalWriteoffAdjustmentAmount] decimal(18, 2),
		[VendorDEAmount] decimal(18, 2),
		[GLDEAmount] decimal(18, 2),
		[TotalDEAmount] decimal(18, 2)

	
	);

	SELECT 
		@TRAFFIC_MGR_COL = CAST(AGYS.AGY_SETTINGS_VALUE AS varchar(20)) 
	FROM 
		[dbo].[AGY_SETTINGS] AS AGYS
	WHERE 
		AGYS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL'	
			
	INSERT INTO @JOB
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
		[dbo].[COMPLEXITY] AS CMPL ON J.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN
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

	INSERT INTO @JOB (JobNumber, JobComponentNumber)
	VALUES (0,0)	
	--E
	if @IncludeEmployeeTime = 1
	Begin
		INSERT INTO @JOB_DETAIL
		SELECT
			[ResourceType] = 'E',
			[JobNumber] = ETD.JOB_NUMBER,
			[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
			[ClientCode] = NULL,
			[ClientDescription] = NULL,
			[DivisionCode] = NULL,
			[DivisionDescription] = NULL,
			[ProductCode] = NULL,
			[ProductDescription] = NULL,
			[FunctionType] = F.FNC_TYPE,
			[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionCode] = ETD.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[ItemID] = ETD.ET_ID,
			[ItemSequenceNumber] = ETD.ET_DTL_ID,
			[ItemDate] = ET.EMP_DATE,
			[PostPeriodCode] = GL.GLEHPP,
			[ItemCode] = ET.EMP_CODE,
			[ItemDescription] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
			[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
			--[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
			[ItemExtra] = CAST(NULL AS varchar(20)),
			[ItemAdjComments] = ETD.ADJ_COMMENTS,
			[GLXact] = NULL,
			[GLCodeExpense] = CAST(NULL AS varchar(30)),
			[GLDescriptionExpense] = CAST(NULL AS varchar(75)),
			[VendorNetWriteoffAmount] = 0,
			[VendorGrossWriteoffAmount] = 0,
			[TimeBeforeAdjustmentAmount] = ISNULL(ETD.TOTAL_BILL,0),
			[TimeMarkupAmount] = CASE WHEN ISNULL(ETD.EXT_MARKUP_AMT,0) > 0 THEN ISNULL(ETD.EXT_MARKUP_AMT,0) ELSE 0 END,
			[TimeMarkdownAmount] = CASE WHEN ISNULL(ETD.EXT_MARKUP_AMT,0) < 0 THEN ISNULL(ETD.EXT_MARKUP_AMT,0) ELSE 0 END,
			[TimeAfterAdjustmentAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0),
			[IncomeOnlyBeforeAdjustmentAmount] = 0,
			[IncomeOnlyMarkupAmount] = 0,
			[IncomeOnlyMarkdownAmount] = 0,
			[IncomeOnlyAfterAdjustmentAmount] = 0,
			[TotalWriteoffAdjustmentAmount] = (CASE WHEN ISNULL(ETD.EXT_MARKUP_AMT,0) > 0 THEN ISNULL(ETD.EXT_MARKUP_AMT,0) ELSE 0 END) + (CASE WHEN ISNULL(ETD.EXT_MARKUP_AMT,0) < 0 THEN ISNULL(ETD.EXT_MARKUP_AMT,0) ELSE 0 END),
			[VendorDEAmount] = 0,
			[GLDEAmount] = 0,
			[TotalDEAmount] = 0
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
			--									 ETDC.ET_SOURCE = 'D' LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN 
			[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = ET.EMP_CODE INNER JOIN
			[dbo].[GLENTHDR] AS GL ON GL.GLEHXACT = ETD.GLEXACT_BILL
		WHERE
			GL.GLEHPP BETWEEN @StartPeriod and @EndPeriod AND ETD.EXT_MARKUP_AMT <> 0	
	End
	--I
	if @IncludeIncomeOnly = 1
	Begin
		INSERT INTO @JOB_DETAIL
		SELECT
			[ResourceType] = 'I',
			[JobNumber] = [IO].JOB_NUMBER,
			[JobComponentNumber] = [IO].JOB_COMPONENT_NBR,
			[ClientCode] = NULL,
			[ClientDescription] = NULL,
			[DivisionCode] = NULL,
			[DivisionDescription] = NULL,
			[ProductCode] = NULL,
			[ProductDescription] = NULL,
			[FunctionType] = F.FNC_TYPE,
			[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionCode] = [IO].FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[ItemID] = [IO].IO_ID,
			[ItemSequenceNumber] = [IO].SEQ_NBR,
			[ItemDate] = [IO].IO_INV_DATE,
			[PostPeriodCode] =  GL.GLEHPP,
			[ItemCode] = CAST(NULL AS varchar(6)),
			[ItemDescription] = [IO].IO_DESC,
			[ItemComment] = CAST([IO].IO_COMMENT AS varchar(MAX)),
			[ItemExtra] = CAST(NULL AS varchar(20)),		
			[ItemAdjComments] = [IO].ADJ_COMMENTS,
			[GLXact] = NULL,
			[GLCodeExpense] = CAST(NULL AS varchar(30)),
			[GLDescriptionExpense] = CAST(NULL AS varchar(75)),
			[VendorNetWriteoffAmount] = 0,
			[VendorGrossWriteoffAmount] = 0,
			[TimeBeforeAdjustmentAmount] = 0,
			[TimeMarkupAmount] = 0,
			[TimeMarkdownAmount] = 0,
			[TimeAfterAdjustmentAmount] = 0,
			[IncomeOnlyBeforeAdjustmentAmount] = ISNULL([IO].IO_AMOUNT,0),
			[IncomeOnlyMarkupAmount] = CASE WHEN ISNULL([IO].EXT_MARKUP_AMT,0) > 0 THEN ISNULL([IO].EXT_MARKUP_AMT,0) ELSE 0 END,
			[IncomeOnlyMarkdownAmount] = CASE WHEN ISNULL([IO].EXT_MARKUP_AMT,0) < 0 THEN ISNULL([IO].EXT_MARKUP_AMT,0) ELSE 0 END,
			[IncomeOnlyAfterAdjustmentAmount] = ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0),
			[TotalWriteoffAdjustmentAmount] = (CASE WHEN ISNULL([IO].EXT_MARKUP_AMT,0) > 0 THEN ISNULL([IO].EXT_MARKUP_AMT,0) ELSE 0 END) + (CASE WHEN ISNULL([IO].EXT_MARKUP_AMT,0) < 0 THEN ISNULL([IO].EXT_MARKUP_AMT,0) ELSE 0 END) 		,
			[VendorDEAmount] = 0,
			[GLDEAmount] = 0,
			[TotalDEAmount] = 0
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
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN
			[dbo].[GLENTHDR] AS GL ON GL.GLEHXACT = [IO].GLEXACT_BILL
		WHERE
			GL.GLEHPP BETWEEN @StartPeriod and @EndPeriod AND [IO].EXT_MARKUP_AMT <> 0	
	End
	--V
	if @IncludeVendor = 1
	Begin
		INSERT INTO @JOB_DETAIL
		SELECT
			[ResourceType] = 'V',
			[JobNumber] = APP.JOB_NUMBER,
			[JobComponentNumber] = APP.JOB_COMPONENT_NBR,
			[ClientCode] = NULL,
			[ClientDescription] = NULL,
			[DivisionCode] = NULL,
			[DivisionDescription] = NULL,
			[ProductCode] = NULL,
			[ProductDescription] = NULL,
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
			[ItemAdjComments] = APP.ADJ_COMMENTS,
			[GLXact] = APP.GLEXACT,
			[GLCodeExpense] = APP.GLACODE,
			[GLDescriptionExpense] = GL.GLADESC,
			[VendorNetWriteoffAmount] = ISNULL(APP.AP_PROD_EXT_AMT,0) + ISNULL(APP.EXT_NONRESALE_TAX,0),
			[VendorGrossWriteoffAmount] = ISNULL(APP.LINE_TOTAL, 0) - ISNULL(APP.EXT_STATE_RESALE, 0) - ISNULL(APP.EXT_COUNTY_RESALE, 0) - ISNULL(APP.EXT_CITY_RESALE, 0),
			[TimeBeforeAdjustmentAmount] = 0,
			[TimeMarkupAmount] = 0,
			[TimeMarkdownAmount] = 0,
			[TimeAfterAdjustmentAmount] = 0,
			[IncomeOnlyBeforeAdjustmentAmount] = 0,
			[IncomeOnlyMarkupAmount] = 0,
			[IncomeOnlyMarkdownAmount] = 0,
			[IncomeOnlyAfterAdjustmentAmount] = 0,
			[TotalWriteoffAdjustmentAmount] = ISNULL(APP.AP_PROD_EXT_AMT,0) + ISNULL(APP.EXT_NONRESALE_TAX,0),
			[VendorDEAmount] = 0,
			[GLDEAmount] = 0,
			[TotalDEAmount] = 0
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
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
			[dbo].[GLACCOUNT] AS GL ON GL.GLACODE = APP.GLACODE
		WHERE
			 APP.POST_PERIOD BETWEEN @StartPeriod and @EndPeriod AND APP.WRITE_OFF = 1	
		--Vendor Direct Expense
		INSERT INTO @JOB_DETAIL
		SELECT
			[ResourceType] = 'V',
			[JobNumber] = APP.JOB_NUMBER,
			[JobComponentNumber] = APP.JOB_COMPONENT_NBR,
			[ClientCode] = NULL,
			[ClientDescription] = NULL,
			[DivisionCode] = NULL,
			[DivisionDescription] = NULL,
			[ProductCode] = NULL,
			[ProductDescription] = NULL,
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
			[ItemAdjComments] = APP.ADJ_COMMENTS,
			[GLXact] = APP.GLEXACT,
			[GLCodeExpense] = APP.GLACODE,
			[GLDescriptionExpense] = GL.GLADESC,
			[VendorNetWriteoffAmount] = 0,
			[VendorGrossWriteoffAmount] = 0,
			[TimeBeforeAdjustmentAmount] = 0,
			[TimeMarkupAmount] = 0,
			[TimeMarkdownAmount] = 0,
			[TimeAfterAdjustmentAmount] = 0,
			[IncomeOnlyBeforeAdjustmentAmount] = 0,
			[IncomeOnlyMarkupAmount] = 0,
			[IncomeOnlyMarkdownAmount] = 0,
			[IncomeOnlyAfterAdjustmentAmount] = 0,
			[TotalWriteoffAdjustmentAmount] = 0,
			[VendorDEAmount] = ISNULL(APP.AP_PROD_EXT_AMT,0) + ISNULL(APP.EXT_NONRESALE_TAX,0),
			[GLDEAmount] = 0,
			[TotalDEAmount] = 0 		
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
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN
			[dbo].[GLACCOUNT] AS GL ON GL.GLACODE = APP.GLACODE
		WHERE
			 APP.POST_PERIOD BETWEEN @StartPeriod and @EndPeriod AND ISNULL(APP.WRITE_OFF,0) = 0 AND AP_PROD_NOBILL_FLG = 1	
		--GL Entry Direct Expense	
		INSERT INTO @JOB_DETAIL
		SELECT
			[ResourceType] = 'G',
			[JobNumber] = 0,
			[JobComponentNumber] = 0,
			[ClientCode] = ISNULL(GLENTTRL.CL_CODE,''),    
			[ClientDescription] = ISNULL(CLIENT.CL_NAME,''),
			[DivisionCode] = ISNULL(GLENTTRL.DIV_CODE,''), 
			[DivisionDescription] = ISNULL(DIVISION.DIV_NAME,''),
			[ProductCode] = ISNULL(GLENTTRL.PRD_CODE,''),
			[ProductDescription] = ISNULL(PRODUCT.PRD_DESCRIPTION,''),
			[FunctionType] = 'G',
			[FunctionConsolidationCode] = NULL,
			[FunctionConsolidation] = NULL,
			[FunctionHeading] = NULL,
			[FunctionCode] = ISNULL(GLENTTRL.GLETSOURCE,''),
			[FunctionDescription] = ISNULL(GLSOURCE.GLSRDESC,''),
			[ItemID] = GLENTTRL.GLETXACT,
			[ItemSequenceNumber] = GLENTTRL.GLETSEQ,
			[ItemDate] = NULL,
			[PostPeriodCode] = GLENTHDR.GLEHPP,
			[ItemCode] = ISNULL(GLENTTRL.GLETCODE,''),
			[ItemDescription] = ISNULL(GLENTTRL.GLETREM,''),
			[ItemComment] = NULL,
			[ItemExtra] = NULL,
			[ItemAdjComments] = NULL,
			[GLXact] = GLENTHDR.GLEHXACT,
			[GLCodeExpense] = GLACCOUNT.GLACODE,
			[GLDescriptionExpense] = GLACCOUNT.GLADESC,
			[VendorNetWriteoffAmount] = 0,
			[VendorGrossWriteoffAmount] = 0,
			[TimeBeforeAdjustmentAmount] = 0,
			[TimeMarkupAmount] = 0,
			[TimeMarkdownAmount] = 0,
			[TimeAfterAdjustmentAmount] = 0,
			[IncomeOnlyBeforeAdjustmentAmount] = 0,
			[IncomeOnlyMarkupAmount] = 0,
			[IncomeOnlyMarkdownAmount] = 0,
			[IncomeOnlyAfterAdjustmentAmount] = 0,
			[TotalWriteoffAdjustmentAmount] = 0,
			[VendorDEAmount] = 0,
			[GLDEAmount] = SUM(GLENTTRL.GLETAMT),
			[TotalDEAmount] = 0	
		FROM GLENTTRL INNER JOIN 
			 GLENTHDR ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT INNER JOIN 
			 GLACCOUNT ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE INNER JOIN 
			 POSTPERIOD ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD INNER JOIN 
			 GLSOURCE ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE LEFT JOIN 
			 AGENCY_CLIENTS ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 CLIENT ON GLENTTRL.CL_CODE = CLIENT.CL_CODE INNER JOIN 
			 DIVISION ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE) AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE) AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE) AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
			 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE 
		WHERE (((GLENTTRL.GLETSOURCE) In ('JE','RJ')) AND ((GLACCOUNT.GLATYPE)='14') AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null) AND ((AGENCY_CLIENTS.CL_CODE) Is Null))
				AND (GLENTHDR.GLEHPP BETWEEN @StartPeriod AND @EndPeriod)
		GROUP BY GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, GLENTHDR.GLEHPP, GLENTHDR.GLEHXACT, GLACCOUNT.GLACODE,GLACCOUNT.GLADESC,GLENTTRL.GLETXACT,GLENTTRL.
				GLETSEQ,GLENTTRL.GLETREM,GLENTTRL.GLETCODE,GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, PRODUCT.PRD_DESCRIPTION		
		
		
	End

	--SELECT * FROM @JOB_DETAIL
		
	if @GroupByJob = 1
	Begin
		SELECT 
			[ID] = NEWID(),
			JD.ResourceType,
			J.JobNumber,
			J.JobComponentNumber,
			J.OfficeCode,
			J.OfficeDescription,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ClientCode ELSE J.ClientCode END AS ClientCode,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ClientDescription ELSE J.ClientDescription END AS ClientDescription,
			CASE WHEN JD.ResourceType = 'G' THEN JD.DivisionCode ELSE J.DivisionCode END AS DivisionCode,
			CASE WHEN JD.ResourceType = 'G' THEN JD.DivisionDescription ELSE J.DivisionDescription END AS DivisionDescription,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ProductCode ELSE J.ProductCode END AS ProductCode,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ProductDescription ELSE J.ProductDescription END AS ProductDescription,
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
			J.AdSize,
			J.DepartmentTeamCode,
			J.DepartmentTeam,
			J.MarkupPercent,
			J.CreativeInstructions,
			J.JobProcessControl,
			J.ComponentDescription,
			J.ComponentComments,
			J.ComponentBudget,
			J.EstimateNumber,
			J.EstimateComponentNumber,
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
			'' AS FunctionType,
			'' AS FunctionConsolidationCode,
			'' AS FunctionConsolidation,
			'' AS FunctionHeading,
			'' AS FunctionCode,
			'' AS FunctionDescription,
			0 AS ItemID,
			0 AS ItemSequenceNumber,
			NULL AS ItemDate,
			'' AS PostPeriodCode,
			'' AS ItemCode,
			'' AS ItemDescription,
			'' AS ItemComment,
			'' AS ItemExtra,		
			J.IsNewBusiness,
			J.Agency,
			J.ProductUDF1,
			J.ProductUDF2,
			J.ProductUDF3,
			J.ProductUDF4,
			'' AS [ItemAdjComments],
			JD.[GLXact],
			JD.[GLCodeExpense],
			JD.[GLDescriptionExpense],
			SUM(JD.[VendorNetWriteoffAmount]) AS [VendorNetWriteoffAmount],
			SUM(JD.[VendorGrossWriteoffAmount]) AS [VendorGrossWriteoffAmount],
			SUM(JD.[TimeBeforeAdjustmentAmount]) AS [TimeBeforeAdjustmentAmount],
			SUM(JD.[TimeMarkupAmount]) AS [TimeMarkupAmount],
			SUM(JD.[TimeMarkdownAmount]) AS [TimeMarkdownAmount],
			SUM(JD.[TimeAfterAdjustmentAmount]) AS [TimeAfterAdjustmentAmount],
			SUM(JD.[IncomeOnlyBeforeAdjustmentAmount]) AS [IncomeOnlyBeforeAdjustmentAmount],
			SUM(JD.[IncomeOnlyMarkupAmount]) AS [IncomeOnlyMarkupAmount],
			SUM(JD.[IncomeOnlyMarkdownAmount]) AS [IncomeOnlyMarkdownAmount],
			SUM(JD.[IncomeOnlyAfterAdjustmentAmount]) AS [IncomeOnlyAfterAdjustmentAmount],
			SUM(JD.[TotalWriteoffAdjustmentAmount]) AS [TotalWriteoffAdjustmentAmount],
			SUM(JD.[VendorDEAmount]) AS [VendorDEAmount],
			SUM(JD.[GLDEAmount]) AS [GLDEAmount],
			[TotalDEAmount] = SUM(JD.[VendorNetWriteoffAmount]) + SUM(JD.[VendorDEAmount]) + SUM(JD.[GLDEAmount])
		FROM 
			@JOB AS J INNER JOIN 
			@JOB_DETAIL AS JD ON J.[JobNumber] = JD.[JobNumber] AND
								 J.[JobComponentNumber] = JD.[JobComponentNumber]
		GROUP BY JD.ResourceType,
			J.JobNumber,
			J.JobComponentNumber,
			J.OfficeCode,
			J.OfficeDescription,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ClientCode ELSE J.ClientCode END,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ClientDescription ELSE J.ClientDescription END,
			CASE WHEN JD.ResourceType = 'G' THEN JD.DivisionCode ELSE J.DivisionCode END,
			CASE WHEN JD.ResourceType = 'G' THEN JD.DivisionDescription ELSE J.DivisionDescription END,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ProductCode ELSE J.ProductCode END,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ProductDescription ELSE J.ProductDescription END,
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
			J.AdSize,
			J.DepartmentTeamCode,
			J.DepartmentTeam,
			J.MarkupPercent,
			J.CreativeInstructions,
			J.JobProcessControl,
			J.ComponentDescription,
			J.ComponentComments,
			J.ComponentBudget,
			J.EstimateNumber,
			J.EstimateComponentNumber,
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
			J.IsNewBusiness,
			J.Agency,
			J.ProductUDF1,
			J.ProductUDF2,
			J.ProductUDF3,
			J.ProductUDF4,
			JD.[GLXact],
			JD.[GLCodeExpense],
			JD.[GLDescriptionExpense]
	End
	Else
	Begin
		SELECT 
			[ID] = NEWID(),
			JD.ResourceType,
			J.JobNumber,
			J.JobComponentNumber,
			J.OfficeCode,
			J.OfficeDescription,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ClientCode ELSE J.ClientCode END AS ClientCode,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ClientDescription ELSE J.ClientDescription END AS ClientDescription,
			CASE WHEN JD.ResourceType = 'G' THEN JD.DivisionCode ELSE J.DivisionCode END AS DivisionCode,
			CASE WHEN JD.ResourceType = 'G' THEN JD.DivisionDescription ELSE J.DivisionDescription END AS DivisionDescription,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ProductCode ELSE J.ProductCode END AS ProductCode,
			CASE WHEN JD.ResourceType = 'G' THEN JD.ProductDescription ELSE J.ProductDescription END AS ProductDescription,
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
			J.AdSize,
			J.DepartmentTeamCode,
			J.DepartmentTeam,
			J.MarkupPercent,
			J.CreativeInstructions,
			J.JobProcessControl,
			J.ComponentDescription,
			J.ComponentComments,
			J.ComponentBudget,
			J.EstimateNumber,
			J.EstimateComponentNumber,
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
			J.IsNewBusiness,
			J.Agency,
			J.ProductUDF1,
			J.ProductUDF2,
			J.ProductUDF3,
			J.ProductUDF4,
			JD.[ItemAdjComments],
			JD.[GLXact],
			JD.[GLCodeExpense],
			JD.[GLDescriptionExpense],
			JD.[VendorNetWriteoffAmount],
			JD.[VendorGrossWriteoffAmount],
			JD.[TimeBeforeAdjustmentAmount],
			JD.[TimeMarkupAmount],
			JD.[TimeMarkdownAmount],
			JD.[TimeAfterAdjustmentAmount],
			JD.[IncomeOnlyBeforeAdjustmentAmount],
			JD.[IncomeOnlyMarkupAmount],
			JD.[IncomeOnlyMarkdownAmount],
			JD.[IncomeOnlyAfterAdjustmentAmount],
			JD.[TotalWriteoffAdjustmentAmount],
			JD.[VendorDEAmount],
			JD.[GLDEAmount],
			[TotalDEAmount] = JD.[VendorNetWriteoffAmount] + JD.[VendorDEAmount] + JD.[GLDEAmount]
		FROM 
			@JOB AS J INNER JOIN 
			@JOB_DETAIL AS JD ON J.[JobNumber] = JD.[JobNumber] AND
								 J.[JobComponentNumber] = JD.[JobComponentNumber]
		
	End

	

	--DROP TABLE @JOB
	--DROP TABLE @JOB_DETAIL 

END
GO

GRANT EXECUTE ON [advsp_job_detail_item_writeoff_load] TO PUBLIC
GO