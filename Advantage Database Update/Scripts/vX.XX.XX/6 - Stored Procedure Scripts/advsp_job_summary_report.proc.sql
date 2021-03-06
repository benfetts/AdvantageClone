IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_job_summary_report]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_job_summary_report]
GO

CREATE PROCEDURE [dbo].[advsp_job_summary_report]
	@SelectedDate as varchar(20),
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@IncludeClosedJobs bit,
	@ClientCodes varchar(max),
	@AECodes varchar(max),
	@SalesClassCodes varchar(max),
	@JobTypeCodes varchar(max)
AS

CREATE TABLE #Jobs (
	JOB_NUMBER int NOT NULL,
	JOB_COMPONENT_NBR smallint NOT NULL,
	IS_OPEN bit DEFAULT(0)
)

IF @SelectedDate = 'JobCreateDate' --J.CREATE_DATE,
	INSERT INTO #Jobs (JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT JL.JOB_NUMBER, JC.JOB_COMPONENT_NBR 
	FROM dbo.JOB_LOG JL INNER JOIN dbo.JOB_COMPONENT JC ON JL.JOB_NUMBER = JC.JOB_NUMBER 
	WHERE CREATE_DATE BETWEEN @StartDate AND @EndDate
ELSE IF @SelectedDate = 'ComponentDateOpened' --JC.JOB_COMP_DATE,
	INSERT INTO #Jobs (JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR 
	FROM dbo.JOB_COMPONENT JC
	WHERE JC.JOB_COMP_DATE BETWEEN @StartDate AND @EndDate
ELSE IF @SelectedDate = 'DueDate' --JC.JOB_FIRST_USE_DATEjobopen
	INSERT INTO #Jobs (JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR 
	FROM dbo.JOB_COMPONENT JC
	WHERE JC.JOB_FIRST_USE_DATE BETWEEN @StartDate AND @EndDate
ELSE IF @SelectedDate = 'StartDate' --JC.[START_DATE],
	INSERT INTO #Jobs (JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR 
	FROM dbo.JOB_COMPONENT JC
	WHERE JC.[START_DATE] BETWEEN @StartDate AND @EndDate


UPDATE J SET IS_OPEN = 1 
FROM #Jobs J
	INNER JOIN (
				SELECT DISTINCT JOB_NUMBER, JOB_COMPONENT_NBR
				FROM dbo.JOB_COMPONENT
				WHERE JOB_PROCESS_CONTRL NOT IN (6, 12)
				) JobOpen ON J.JOB_NUMBER = JobOpen.JOB_NUMBER AND J.JOB_COMPONENT_NBR = JobOpen.JOB_COMPONENT_NBR
				
SELECT
		[ID] = NEWID(),
		[JobNumber] = JC.JOB_NUMBER,
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
		[DefSalesClassFormatCode] = DSC.FORMAT_CODE,
		[ComplexityCode] = J.COMPLEX_CODE,
		[ComplexityDescription] = CMPL.COMPLEX_DESC,
		[PromotionCode] = J.PROMO_CODE,
		[BillingComment] = J.JOB_BILL_COMMENT,
		[LabelFromUDFTable1] = JUDV1.UDV_DESC,
		[LabelFromUDFTable2] = JUDV2.UDV_DESC,
		[LabelFromUDFTable3] = JUDV3.UDV_DESC,
		[LabelFromUDFTable4] = JUDV4.UDV_DESC,
		[LabelFromUDFTable5] = JUDV5.UDV_DESC,
		[JobOpen] = CASE WHEN jobs.IS_OPEN = 1 THEN 'Yes' ELSE 'No' END,
		[ComponentNumber] = JC.JOB_COMPONENT_NBR,
		[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3),
		[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
		[AccountExecutiveCode] = JC.EMP_CODE,
		[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
		[ComponentDateOpened] = JC.JOB_COMP_DATE,
		[DueDate] = JC.JOB_FIRST_USE_DATE,
		[StartDate] = JC.[START_DATE],
		[ClosedDate] = CASE WHEN JC.JOB_PROCESS_CONTRL IN (6,12) THEN JPL_DATE.PROCESS_DATE ELSE NULL END,
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
		[ClientContactCode] = JC.CDP_CONTACT_ID,
		[ClientContactID] = JC.PRD_CONT_CODE,
		[BABatchID] = JC.BA_BATCH_ID,
		[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
		[SelectedBABatchID] = JC.SELECTED_BA_ID,
		[BillingCommandCenterID] = JC.BCC_ID,
		[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
		[JobProcessControlDate] = JPL_DATE.PROCESS_DATE,
        [JobProcessControlChangedByUser] = (SELECT PROCESS_USER FROM JOB_PROCESS_LOG JJ WHERE JC.JOB_NUMBER = JJ.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JJ.JOB_COMPONENT_NBR AND JOB_PROCESS_LOG_ID IN (SELECT MAX(JOB_PROCESS_LOG_ID) FROM JOB_PROCESS_LOG GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR))
	FROM
		[dbo].[JOB_COMPONENT] AS JC INNER JOIN 
		#Jobs jobs ON jobs.JOB_NUMBER = JC.JOB_NUMBER AND jobs.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR AND ( (@IncludeClosedJobs = 0 AND jobs.IS_OPEN = 1) OR (@IncludeClosedJobs = 1)) INNER JOIN 
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
		[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
		[dbo].[ACCT_NUMBER] AS AN ON AN.ACCT_NBR = JC.ACCT_NBR LEFT OUTER JOIN
		[dbo].[COMPLEXITY] AS CMPL ON J.COMPLEX_CODE = CMPL.COMPLEX_CODE LEFT OUTER JOIN
		(SELECT 
			JOB_NUMBER, 
			JOB_COMPONENT_NBR, 
			PROCESS_DATE = MAX(PROCESS_DATE) 
		 FROM 
			dbo.JOB_PROCESS_LOG 
		 GROUP BY 
			JOB_NUMBER, 
			JOB_COMPONENT_NBR) JPL_DATE ON JC.JOB_NUMBER = JPL_DATE.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = JPL_DATE.JOB_COMPONENT_NBR LEFT OUTER JOIN
		(SELECT	
			SC_CODE,
			FORMAT_CODE = MIN(FORMAT_CODE)
		 FROM
			dbo.SC_FORMAT
		 WHERE
			ACTIVE = 1
		 GROUP BY
			SC_CODE) AS DSC ON J.SC_CODE = DSC.SC_CODE
WHERE
	(@ClientCodes IS NULL OR (@ClientCodes IS NOT NULL AND J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodes, ','))))
AND (@AECodes IS NULL OR (@AECodes IS NOT NULL AND JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AECodes, ','))))
AND (@SalesClassCodes IS NULL OR (@SalesClassCodes IS NOT NULL AND J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SalesClassCodes, ','))))
AND (@JobTypeCodes IS NULL OR (@JobTypeCodes IS NOT NULL AND JC.JT_CODE IN (SELECT * FROM dbo.udf_split_list(@JobTypeCodes, ','))))
GO

GRANT EXECUTE ON [advsp_job_summary_report] TO PUBLIC
GO