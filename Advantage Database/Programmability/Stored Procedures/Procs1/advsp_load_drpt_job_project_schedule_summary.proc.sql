CREATE PROCEDURE [dbo].[advsp_load_drpt_job_project_schedule_summary]

AS
BEGIN

	DELETE FROM [dbo].[DRPT_JOB_PROJECT_SCHEDULE_SUMMARY]
	
	DBCC CHECKIDENT (DRPT_JOB_PROJECT_SCHEDULE_SUMMARY, reseed, 0)
	
	INSERT INTO [dbo].[DRPT_JOB_PROJECT_SCHEDULE_SUMMARY]
	SELECT 
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
		[Comment] = J.JOB_COMMENTS,
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
		[AccountExecutive] = EMP.EmployeeName,
		[ComponentDateOpened] = JC.JOB_COMP_DATE,
		[DueDate] = JC.JOB_FIRST_USE_DATE,
		[StartDate] = JC.[START_DATE],
		[AdSize] = JC.JOB_AD_SIZE,
		[DepartmentTeamCode] = JC.DP_TM_CODE,
		[DepartmentTeam] = DT.DP_TM_DESC,
		[MarkupPercent] = JC.JOB_MARKUP_PCT,
		[CreativeInstructions] = JC.CREATIVE_INSTR,
		[JobProcessControl] = JPC.JOB_PROCESS_DESC,
		[ComponentDescription] = JC.JOB_COMP_DESC,
		[ComponentComments] = JC.JOB_COMP_COMMENTS,
		[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
		[EstimateNumber] = JC.ESTIMATE_NUMBER,
		[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
		[BillingUser] = JC.BILLING_USER,
		[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
		[DeliveryInstructions] = JC.JOB_DEL_INSTRUCT,
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
		[JobCycleTime] = DATEDIFF(day, JC.[START_DATE], JC.JOB_FIRST_USE_DATE),
		[StatusCode] = JOBT.TRF_CODE,
		[Status] = T.TRF_DESCRIPTION,
		[Comments] = JOBT.TRF_COMMENTS,
		[LabelAssign1] = EMPLA1.EmployeeName,
		[LabelAssign2] = EMPLA2.EmployeeName,
		[LabelAssign3] = EMPLA3.EmployeeName,
		[LabelAssign4] = EMPLA4.EmployeeName,
		[LabelAssign5] = EMPLA5.EmployeeName,
		[CompletedDate] = JOBT.COMPLETED_DATE,
		[JobEarlyOrLate] = DATEDIFF(day, JC.JOB_FIRST_USE_DATE, JOBT.COMPLETED_DATE),
		[DateDelivered] = JOBT.DATE_DELIVERED,
		[DateShipped] = JOBT.DATE_SHIPPED,
		[ReceivedBy] = JOBT.RECEIVED_BY,
		[Reference] = JOBT.REFERENCE,
		[ManagerCode] = JOBT.MGR_EMP_CODE,
		[Manager] = MEMP.EmployeeName,
		[TaskSequence] = JOBTD.SEQ_NBR,
		[TaskCode] = JOBTD.FNC_CODE,
		[EstimateFunctionCode] = JOBTD.FNC_EST,
		[TaskDescription] = JOBTD.TASK_DESCRIPTION,
		[TaskStartDate] = JOBTD.TASK_START_DATE,
		[TaskOriginalDueDate] = JOBTD.JOB_DUE_DATE,
		[TaskRevisedDueDate] = JOBTD.JOB_REVISED_DATE,
		[TaskCycleTime] = ABS(DATEDIFF(day, JOBTD.TASK_START_DATE, JOBTD.JOB_REVISED_DATE)),
		[TaskEarlyOrLate] = DATEDIFF(day, JOBTD.JOB_REVISED_DATE, JOBTD.JOB_COMPLETED_DATE),
		[Locked] = CASE WHEN JOBTD.DUE_DATE_LOCK = 1 THEN 'Yes' ELSE 'No' END,
		[TaskCompletedDate] = JOBTD.JOB_COMPLETED_DATE,
		[TaskOrder] = JOBTD.JOB_ORDER,
		[TaskDays] = JOBTD.JOB_DAYS,
		[TaskComments] = JOBTD.FNC_COMMENTS,
		[DueDateComments] = JOBTD.DUE_DATE_COMMENTS,
		[RevDueDateComments] = JOBTD.REV_DATE_COMMENTS,
		[DefaultHoursAllowed] = JOBTD.JOB_HRS,
		[TimeDue] = JOBTD.DUE_TIME,
		[RevisedTimeDue] = JOBTD.REVISED_DUE_TIME,
		[TaskStatus] = JOBTD.TASK_STATUS,
		[Milestone] = CASE WHEN JOBTD.MILESTONE = 1 THEN 'Yes' ELSE 'No' END,
		[Phase] = TP.PHASE_DESC,
		[HoursAllowed] = JOBTD.HOURS_ASSIGNED,
		[Employee] = JOBTD.EMP_CODE,
		[Employees] = JOBTDEMP.EMP_LFI_LIST,
		[TempCompleteDate] = JOBTD.TEMP_COMP_DATE
	FROM
		[dbo].[JOB_COMPONENT] AS JC INNER JOIN 
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[JOB_TRAFFIC] AS JOBT ON JOBT.JOB_NUMBER = JC.JOB_NUMBER AND
							   JOBT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
								 D.DIV_CODE = J.DIV_CODE INNER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
								P.DIV_CODE = J.DIV_CODE AND
								P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
		[dbo].[advtf_emp_names]() AS EMP ON EMP.EmployeeCode = JC.EMP_CODE LEFT OUTER JOIN
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
		[dbo].[advtf_emp_names]() AS EMPLA1 ON EMPLA1.EmployeeCode = JOBT.ASSIGN_1 LEFT OUTER JOIN
		[dbo].[advtf_emp_names]() AS EMPLA2 ON EMPLA2.EmployeeCode = JOBT.ASSIGN_2 LEFT OUTER JOIN
		[dbo].[advtf_emp_names]() AS EMPLA3 ON EMPLA3.EmployeeCode = JOBT.ASSIGN_3 LEFT OUTER JOIN
		[dbo].[advtf_emp_names]() AS EMPLA4 ON EMPLA4.EmployeeCode = JOBT.ASSIGN_4 LEFT OUTER JOIN
		[dbo].[advtf_emp_names]() AS EMPLA5 ON EMPLA5.EmployeeCode = JOBT.ASSIGN_5 LEFT OUTER JOIN 
		[dbo].[JOB_TRAFFIC_DET] AS JOBTD ON JOBTD.JOB_NUMBER = JC.JOB_NUMBER AND
											JOBTD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
		[dbo].[TRAFFIC_PHASE] AS TP ON TP.TRAFFIC_PHASE_ID = JOBTD.TRAFFIC_PHASE_ID LEFT OUTER JOIN
	    [dbo].[V_JOB_TRAFFIC_DET_EMPS] AS JOBTDEMP ON JOBTDEMP.JOB_NUMBER = JOBTD.JOB_NUMBER AND 
													  JOBTDEMP.JOB_COMPONENT_NBR = JOBTD.JOB_COMPONENT_NBR AND 
													  JOBTDEMP.SEQ_NBR = JOBTD.SEQ_NBR LEFT OUTER JOIN
		[dbo].[TRAFFIC] AS T ON T.TRF_CODE = JOBT.TRF_CODE LEFT OUTER JOIN
		[dbo].[advtf_emp_names]() AS MEMP ON MEMP.EmployeeCode = JOBT.MGR_EMP_CODE

END	

