CREATE VIEW [dbo].[V_DRPT_PROJECT_HOURS_USED_LIVE]

WITH SCHEMABINDING 
AS

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
		[SalesClassFormatCode] = J.FORMAT_CODE,
		[ComplexityCode] = J.COMPLEX_CODE,
		[PromotionCode] = J.PROMO_CODE,
		[LabelFromUDFTable1] = JUDV1.UDV_DESC,
		[LabelFromUDFTable2] = JUDV2.UDV_DESC,
		[LabelFromUDFTable3] = JUDV3.UDV_DESC,
		[LabelFromUDFTable4] = JUDV4.UDV_DESC,
		[LabelFromUDFTable5] = JUDV5.UDV_DESC,
		[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
		[ComponentNumber] = JC.JOB_COMPONENT_NBR,
		[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
		[AccountExecutiveCode] = JC.EMP_CODE,
		[AccountExecutive] =  COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
		[ComponentDateOpened] = JC.JOB_COMP_DATE,
		[DueDate] = JC.JOB_FIRST_USE_DATE,
		[StartDate] = JC.[START_DATE],
		[JobCycleTime] = DATEDIFF(day, JC.[START_DATE], JC.JOB_FIRST_USE_DATE),
		[AdSize] = JC.JOB_AD_SIZE,
		[DepartmentTeamCode] = JC.DP_TM_CODE,
		[DepartmentTeam] = DT.DP_TM_DESC,
		[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
		[JobProcessControl] = JPC.JOB_PROCESS_DESC,
		[ComponentDescription] = JC.JOB_COMP_DESC,
		[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
		[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
		[EstimateNumber] = JC.ESTIMATE_NUMBER,
		[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
		[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
		[JobTypeCode] = JC.JT_CODE,
		[JobTypeDescription] = JT.JT_DESC,
		[AlertGroup] = JC.EMAIL_GR_CODE,
		[AdNumber] = JC.AD_NBR,
		[MarketCode] = JC.MARKET_CODE,
		[MarketDescription] = M.MARKET_DESC,
		[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
		[ClientPO] = JC.JOB_CL_PO_NBR,
		[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
		[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
		[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
		[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
		[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
		[ClientContactCode] = JC.PRD_CONT_CODE,
		[ClientContactID] = JC.CDP_CONTACT_ID,
		[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN RTRIM(LTRIM(ISNULL(CC.CONT_FNAME, '') + ' ' + ISNULL(CC.CONT_LNAME, ''))) ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
		[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
		[StatusCode] = JOBT.TRF_CODE,
		[Status] = T.TRF_DESCRIPTION,
		[GutPercentComplete] = JOBT.PERCENT_COMPLETE,
		[Comments] = CAST(JOBT.TRF_COMMENTS AS varchar(MAX)),
		[LabelAssign1] = COALESCE((RTRIM(EMPLA1.EMP_FNAME) + ' '),'') + COALESCE((EMPLA1.EMP_MI + '. '),'') + COALESCE(EMPLA1.EMP_LNAME,''),
		[LabelAssign2] = COALESCE((RTRIM(EMPLA2.EMP_FNAME) + ' '),'') + COALESCE((EMPLA2.EMP_MI + '. '),'') + COALESCE(EMPLA2.EMP_LNAME,''),
		[LabelAssign3] = COALESCE((RTRIM(EMPLA3.EMP_FNAME) + ' '),'') + COALESCE((EMPLA3.EMP_MI + '. '),'') + COALESCE(EMPLA3.EMP_LNAME,''),
		[LabelAssign4] = COALESCE((RTRIM(EMPLA4.EMP_FNAME) + ' '),'') + COALESCE((EMPLA4.EMP_MI + '. '),'') + COALESCE(EMPLA4.EMP_LNAME,''),
		[LabelAssign5] = COALESCE((RTRIM(EMPLA5.EMP_FNAME) + ' '),'') + COALESCE((EMPLA5.EMP_MI + '. '),'') + COALESCE(EMPLA5.EMP_LNAME,''),
		[CompletedDate] = JOBT.COMPLETED_DATE,
		[JobEarlyOrLate] = DATEDIFF(day, JC.JOB_FIRST_USE_DATE, JOBT.COMPLETED_DATE),
		[DateDelivered] = JOBT.DATE_DELIVERED,
		[DateShipped] = JOBT.DATE_SHIPPED,
		[ReceivedBy] = JOBT.RECEIVED_BY,
		[Reference] = JOBT.REFERENCE,
		[ManagerCode] = JOBT.MGR_EMP_CODE,
		[Manager] = COALESCE((RTRIM(MEMP.EMP_FNAME) + ' '),'') + COALESCE((MEMP.EMP_MI + '. '),'') + COALESCE(MEMP.EMP_LNAME,''),
		[EmployeeCode] = JOBTDE.EMP_CODE,
		[Employee] = COALESCE((RTRIM(JOBTDEMP.EMP_FNAME) + ' '),'') + COALESCE((JOBTDEMP.EMP_MI + '. '),'') + COALESCE(JOBTDEMP.EMP_LNAME,''),
		[HoursAllowed] = MAX(ISNULL(HA.HoursAllowed, 0)),
		[HoursPosted] = MAX(ISNULL(HP.HoursPosted, 0))
	FROM
		[dbo].[JOB_COMPONENT] AS JC INNER JOIN 
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[JOB_TRAFFIC] AS JOBT ON JOBT.JOB_NUMBER = JC.JOB_NUMBER AND
									   JOBT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR INNER JOIN
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
		[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
		[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID INNER JOIN
		[dbo].[TRAFFIC] AS T ON T.TRF_CODE = JOBT.TRF_CODE LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS MEMP ON MEMP.EMP_CODE = JOBT.MGR_EMP_CODE LEFT OUTER JOIN
		[dbo].[JOB_TRAFFIC_DET_EMPS] AS JOBTDE ON JOBTDE.JOB_NUMBER = JOBT.JOB_NUMBER AND
												  JOBTDE.JOB_COMPONENT_NBR = JOBT.JOB_COMPONENT_NBR LEFT OUTER JOIN
		(SELECT 
			[JobNumber] = ETD.JOB_NUMBER, 
			[ComponentNumber] = ETD.JOB_COMPONENT_NBR,
			[EmployeeCode] = ET.EMP_CODE, 
			[HoursPosted] = SUM(ETD.EMP_HOURS)
		FROM 
			[dbo].[EMP_TIME] AS ET INNER JOIN 
			[dbo].[EMP_TIME_DTL] AS ETD ON ET.ET_ID = ETD.ET_ID INNER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = ETD.JOB_NUMBER
		GROUP BY 
			ET.EMP_CODE, 
			ETD.JOB_NUMBER, 
			ETD.JOB_COMPONENT_NBR) AS HP ON HP.JobNumber = JOBTDE.JOB_NUMBER AND
											HP.ComponentNumber = JOBTDE.JOB_COMPONENT_NBR  AND
											HP.EmployeeCode = JOBTDE.EMP_CODE INNER JOIN
		(SELECT 
			[JobNumber] = JOBT.JOB_NUMBER, 
			[ComponentNumber] = JOBT.JOB_COMPONENT_NBR, 
			[EmployeeCode] = JOBDTE.EMP_CODE,
			[HoursAllowed] = SUM(JOBDTE.HOURS_ALLOWED)
		FROM 
			[dbo].[JOB_TRAFFIC] AS JOBT INNER JOIN 
			[dbo].[JOB_TRAFFIC_DET_EMPS] AS JOBDTE ON JOBDTE.JOB_COMPONENT_NBR = JOBT.JOB_COMPONENT_NBR AND 
													  JOBDTE.JOB_NUMBER = JOBT.JOB_NUMBER INNER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JOBT.JOB_NUMBER
		GROUP BY 
			JOBT.JOB_NUMBER, 
			JOBT.JOB_COMPONENT_NBR, 
			JOBDTE.EMP_CODE) AS HA ON HA.JobNumber = JOBTDE.JOB_NUMBER AND
									  HA.ComponentNumber = JOBTDE.JOB_COMPONENT_NBR AND
									  HA.EmployeeCode = JOBTDE.EMP_CODE LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS JOBTDEMP ON JOBTDEMP.EMP_CODE = JOBTDE.EMP_CODE LEFT OUTER JOIN
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
		[dbo].[EMPLOYEE_CLOAK] AS EMPLA1 ON EMPLA1.EMP_CODE = JOBT.ASSIGN_1 LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMPLA2 ON EMPLA2.EMP_CODE = JOBT.ASSIGN_2 LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMPLA3 ON EMPLA3.EMP_CODE = JOBT.ASSIGN_3 LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMPLA4 ON EMPLA4.EMP_CODE = JOBT.ASSIGN_4 LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMPLA5 ON EMPLA5.EMP_CODE = JOBT.ASSIGN_5 LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER
	GROUP BY
		JC.JOB_NUMBER,
		JC.JOB_COMPONENT_NBR,
		JOBTDE.EMP_CODE,
		COALESCE((RTRIM(JOBTDEMP.EMP_FNAME) + ' '),'') + COALESCE((JOBTDEMP.EMP_MI + '. '),'') + COALESCE(JOBTDEMP.EMP_LNAME,''),
		J.OFFICE_CODE,
		O.OFFICE_NAME,
		J.CL_CODE,
		C.CL_NAME,
		J.DIV_CODE,
		D.DIV_NAME,
		J.PRD_CODE,
		P.PRD_DESCRIPTION,
		CAMP.CMP_IDENTIFIER,
		J.CMP_CODE, 
		CAMP.CMP_NAME,
		J.SC_CODE,
		SC.SC_DESCRIPTION,
		J.[USER_ID],
		J.CREATE_DATE,
		J.JOB_DESC,
		J.JOB_DATE_OPENED,
		CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
		CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
		CAST(J.JOB_COMMENTS AS varchar(MAX)),
		J.JOB_CLI_REF,
		J.FORMAT_CODE,
		J.COMPLEX_CODE,
		J.PROMO_CODE,
		JUDV1.UDV_DESC,
		JUDV2.UDV_DESC,
		JUDV3.UDV_DESC,
		JUDV4.UDV_DESC,
		JUDV5.UDV_DESC,
		CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
		RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
		JC.EMP_CODE,
		COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
		JC.JOB_COMP_DATE,
		JC.JOB_FIRST_USE_DATE,
		JC.[START_DATE],
		DATEDIFF(day, JC.[START_DATE], JC.JOB_FIRST_USE_DATE),
		JC.JOB_AD_SIZE,
		JC.DP_TM_CODE,
		DT.DP_TM_DESC,
		CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
		JPC.JOB_PROCESS_DESC,
		JC.JOB_COMP_DESC,
		CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
		JC.JOB_COMP_BUDGET_AM,
		JC.ESTIMATE_NUMBER,
		JC.EST_COMPONENT_NBR,
		CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
		JC.JT_CODE,
		JT.JT_DESC,
		JC.EMAIL_GR_CODE,
		JC.AD_NBR,
		JC.MARKET_CODE,
		M.MARKET_DESC,
		CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
		JC.JOB_CL_PO_NBR,
		JCUDV1.UDV_DESC,
		JCUDV2.UDV_DESC,
		JCUDV3.UDV_DESC,
		JCUDV4.UDV_DESC,
		JCUDV5.UDV_DESC,
		JC.CDP_CONTACT_ID,
		JC.PRD_CONT_CODE,
		CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN RTRIM(LTRIM(ISNULL(CC.CONT_FNAME, '') + ' ' + ISNULL(CC.CONT_LNAME, ''))) ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
		AA.ALERT_NOTIFY_NAME,
		JOBT.TRF_CODE,
		T.TRF_DESCRIPTION,
		JOBT.PERCENT_COMPLETE,
		CAST(JOBT.TRF_COMMENTS AS varchar(MAX)),
		COALESCE((RTRIM(EMPLA1.EMP_FNAME) + ' '),'') + COALESCE((EMPLA1.EMP_MI + '. '),'') + COALESCE(EMPLA1.EMP_LNAME,''),
		COALESCE((RTRIM(EMPLA2.EMP_FNAME) + ' '),'') + COALESCE((EMPLA2.EMP_MI + '. '),'') + COALESCE(EMPLA2.EMP_LNAME,''),
		COALESCE((RTRIM(EMPLA3.EMP_FNAME) + ' '),'') + COALESCE((EMPLA3.EMP_MI + '. '),'') + COALESCE(EMPLA3.EMP_LNAME,''),
		COALESCE((RTRIM(EMPLA4.EMP_FNAME) + ' '),'') + COALESCE((EMPLA4.EMP_MI + '. '),'') + COALESCE(EMPLA4.EMP_LNAME,''),
		COALESCE((RTRIM(EMPLA5.EMP_FNAME) + ' '),'') + COALESCE((EMPLA5.EMP_MI + '. '),'') + COALESCE(EMPLA5.EMP_LNAME,''),
		JOBT.COMPLETED_DATE,
		DATEDIFF(day, JC.JOB_FIRST_USE_DATE, JOBT.COMPLETED_DATE),
		JOBT.DATE_DELIVERED,
		JOBT.DATE_SHIPPED,
		JOBT.RECEIVED_BY,
		JOBT.REFERENCE,
		JOBT.MGR_EMP_CODE,
		COALESCE((RTRIM(MEMP.EMP_FNAME) + ' '),'') + COALESCE((MEMP.EMP_MI + '. '),'') + COALESCE(MEMP.EMP_LNAME,'')
		
