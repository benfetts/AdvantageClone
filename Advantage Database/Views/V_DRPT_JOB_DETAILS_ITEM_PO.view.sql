if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_DRPT_JOB_DETAILS_ITEM_PO]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[V_DRPT_JOB_DETAILS_ITEM_PO]
GO

CREATE VIEW [dbo].[V_DRPT_JOB_DETAILS_ITEM_PO]

WITH SCHEMABINDING 
AS

	SELECT
		[ID] = NEWID(),
		[ResourceType] = 'PO',
		[JobNumber] = POD.JOB_NUMBER,
		[JobComponentNumber] = POD.JOB_COMPONENT_NBR,
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
		[EstimateDescription] = EL.EST_LOG_DESC,
		[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
		[EstimateComponentDescription] = EC.EST_COMP_DESC,
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
		[FunctionType] = F.FNC_TYPE,
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[FunctionHeading] = FH.FNC_HEADING_DESC,
		[FunctionCode] = POD.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[ItemID] = 0,
		[ItemSequenceNumber] = 0,
		[ItemLineNumber] = 0,
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
		[EstimateQuoteNumber] = 0,
		[EstimateRevisionNumber] = 0,
		[PurchaseOrderNumber] = PO.PO_NUMBER,
		[OpenPurchaseOrderAmount] = CASE WHEN AP.PO_COMPLETE = 1 THEN 0 ELSE ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0) END,
		[OpenPurchaseOrderGrossAmount] = CASE WHEN AP.PO_COMPLETE = 1 THEN 0 ELSE ISNULL(POD.PO_EXT_AMOUNT, 0) + ISNULL(POD.EXT_MARKUP_AMT, 0) - ISNULL(AP.AP_GROSS_AMT, 0) END,
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
		[IsNewBusiness] = C.NEW_BUSINESS,
		[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
		[BillingApprovalHours] = 0, 
		[BillingApprovalCostAmount] = 0,  
		[BillingApprovalExtNetAmount] = 0,  
		[BillingApprovalTotalAmount] = 0,
		[ProductUDF1] = P.USER_DEFINED1,
		[ProductUDF2] = P.USER_DEFINED2,
		[ProductUDF3] = P.USER_DEFINED3,
		[ProductUDF4] = P.USER_DEFINED4,
		[TransferAdjustmentUserCode] = CAST(NULL AS varchar(6))
	FROM 
		[dbo].[PURCHASE_ORDER] AS PO INNER JOIN 
		[dbo].[PURCHASE_ORDER_DET] AS POD ON POD.PO_NUMBER = PO.PO_NUMBER LEFT JOIN 
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
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = POD.JOB_NUMBER INNER JOIN
		[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = POD.JOB_NUMBER AND
									JC.JOB_COMPONENT_NBR = POD.JOB_COMPONENT_NBR LEFT OUTER JOIN
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
		[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
		[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
		[dbo].[ESTIMATE_LOG] AS EL ON EL.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER LEFT OUTER JOIN
		[dbo].[ESTIMATE_COMPONENT] AS EC ON EC.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER AND
									EC.EST_COMPONENT_NBR = JC.EST_COMPONENT_NBR
	WHERE
		POD.JOB_NUMBER IS NOT NULL AND
		POD.JOB_COMPONENT_NBR IS NOT NULL AND
		POD.FNC_CODE IS NOT NULL AND 
		(POD.PO_COMPLETE IS NULL OR 
		 POD.PO_COMPLETE = 0) AND 
		(PO.VOID_FLAG IS NULL OR 
		 PO.VOID_FLAG = 0) AND
		(ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0)) <> 0
		
GO