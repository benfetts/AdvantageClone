CREATE PROCEDURE [dbo].[advsp_load_drpt_direct_time]

AS
BEGIN

	DELETE FROM [dbo].[DRPT_DIRECT_TIME]
	
	DBCC CHECKIDENT (DRPT_DIRECT_TIME, reseed, 0)
	
	INSERT INTO [dbo].[DRPT_DIRECT_TIME]
	SELECT 
		[EmployeeCode] = ET.EMP_CODE, 
		[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		[EmployeeTitle] = ETITLE.EMPLOYEE_TITLE,
		[IsEmployeeFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[DirectHoursGoalPercent] = EMP.DIRECT_HRS_PER,
		[BillableHoursGoal] = EMP.MTH_HRS_GOAL,
		[DepartmentTeamCode] = ETD.DP_TM_CODE, 
		[DepartmentTeam] = DT.DP_TM_DESC, 
		[ClientCode] = J.CL_CODE, 
		[ClientDescription] = C.CL_NAME, 
		[DivisionCode] = J.DIV_CODE, 
		[DivisionDescription] = D.DIV_NAME, 
		[ProductCode] = J.PRD_CODE, 
		[ProductDescription] = P.PRD_DESCRIPTION, 
		[ProductCategoryCode] = ETD.PROD_CAT_CODE, 
		[ProductCategoryDescription] = PC.PROD_CAT_DESC, 
		[SalesClassCode] = J.SC_CODE, 
		[SalesClassDescription] = SC.SC_DESCRIPTION, 
		[CampaignID] = CAMP.CMP_IDENTIFIER,
		[CampaignCode] = J.CMP_CODE, 
		[CampaignName] = CAMP.CMP_NAME,
		[JobNumber] = ETD.JOB_NUMBER, 
		[JobDescription] = J.JOB_DESC, 
		[JobComponentNumber] = ETD.JOB_COMPONENT_NBR, 
		[JobComponentDescription] = JC.JOB_COMP_DESC, 
		[AccountExecutiveCode] = JC.EMP_CODE,
		[AccountExecutive] = CASE WHEN AEEMP.EMP_MI IS NULL OR AEEMP.EMP_MI = '' THEN RTRIM(LTRIM(ISNULL(AEEMP.EMP_FNAME, '') + ' ' + ISNULL(AEEMP.EMP_LNAME, ''))) ELSE AEEMP.EMP_FNAME + ' ' + AEEMP.EMP_MI + '. ' + AEEMP.EMP_LNAME END,
		[JobTypeCode] = JC.JT_CODE,
		[JobTypeDescription] = JT.JT_DESC, 
		[FunctionCode] = ETD.FNC_CODE, 
		[FunctionDescription] = F.FNC_DESCRIPTION, 
		[Date] = ET.EMP_DATE, 
		[DateEntered] = ETD.DATE_ENTERED,
		[TotalHoursWorked] = ET.EMP_TOT_HRS,
		[ApprovalUserCode] = ET.APPR_USER,
		[ApprovalDate] = ET.APPR_DATE,
		[PendingApproval] = CASE WHEN ET.APPR_PENDING = 1 THEN 'Yes' ELSE '' END,
		[Approved] = CASE WHEN ET.APPR_FLAG = 1 THEN 'Yes' ELSE '' END,
		[Hours] = SUM(ETD.EMP_HOURS),
		[Amount] = SUM(ETD.TOTAL_BILL), 
		[MarkupAmount] = SUM(ETD.EXT_MARKUP_AMT), 
		[ResaleTax] = SUM(ETD.EXT_STATE_RESALE) + SUM(ETD.EXT_COUNTY_RESALE) + SUM(ETD.EXT_CITY_RESALE), 
		[TotalAmount] = SUM(ETD.TOTAL_BILL) + SUM(ETD.EXT_MARKUP_AMT), 
		[TotalBilled] = CASE WHEN ISNUMERIC(ETD.AR_INV_NBR) = 1 THEN SUM(ETD.TOTAL_BILL) + SUM(ETD.EXT_MARKUP_AMT) ELSE 0.0 END, 
		[TotalAmountWithTax] = SUM(ETD.TOTAL_BILL) + SUM(ETD.EXT_MARKUP_AMT) + SUM(ETD.EXT_STATE_RESALE) + SUM(ETD.EXT_COUNTY_RESALE) + SUM(ETD.EXT_CITY_RESALE),
		[TotalBilledWithTax] = CASE WHEN ISNUMERIC(ETD.AR_INV_NBR) = 1 THEN SUM(ETD.TOTAL_BILL) + SUM(ETD.EXT_MARKUP_AMT) + SUM(ETD.EXT_STATE_RESALE) + SUM(ETD.EXT_COUNTY_RESALE) + SUM(ETD.EXT_CITY_RESALE) ELSE 0.0 END, 
		[NonBillable] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 'Yes' ELSE 'No' END, 
		[Billed] = CASE WHEN ISNUMERIC(ETD.AR_INV_NBR) = 1 THEN 'Yes' ELSE 'No' END, 
		[FunctionHeadingDescription] = FH.FNC_HEADING_DESC, 
		[Comments] = CAST(ETDC.EMP_COMMENT AS varchar(4000)),
		[EmployeeOfficeCode] = EMP.OFFICE_CODE,
		[JobOfficeCode] = J.OFFICE_CODE,
		[IsFeeTime] = CASE WHEN ISNULL(ETD.FEE_TIME, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
		[DefaultRole] = R.ROLE_DESC
	FROM 
		[dbo].[EMP_TIME] AS ET INNER JOIN 
		[dbo].[EMP_TIME_DTL] AS ETD ON ET.ET_ID = ETD.ET_ID INNER JOIN 
		[dbo].[JOB_LOG] AS J ON ETD.JOB_NUMBER = J.JOB_NUMBER INNER JOIN 
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON ET.EMP_CODE = EMP.EMP_CODE INNER JOIN 
		[dbo].[CLIENT] AS C ON J.CL_CODE = C.CL_CODE INNER JOIN 
		[dbo].[DIVISION] AS D ON J.CL_CODE = D.CL_CODE AND 
								 J.DIV_CODE = D.DIV_CODE INNER JOIN 
		[dbo].[PRODUCT] AS P ON J.CL_CODE = P.CL_CODE AND 
								J.DIV_CODE = P.DIV_CODE AND 
								J.PRD_CODE = P.PRD_CODE INNER JOIN 
		[dbo].[DEPT_TEAM] AS DT ON ETD.DP_TM_CODE = DT.DP_TM_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON ETD.JOB_NUMBER = JC.JOB_NUMBER AND 
									   ETD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR INNER JOIN 
		[dbo].[FUNCTIONS] AS F ON ETD.FNC_CODE = F.FNC_CODE LEFT OUTER JOIN 
		[dbo].[PRODUCT_CATEGORY] AS PC ON J.CL_CODE = PC.CL_CODE AND 
										  J.DIV_CODE = PC.DIV_CODE AND 
										  J.PRD_CODE = PC.PRD_CODE AND 
										  ETD.PROD_CAT_CODE = PC.PROD_CAT_CODE LEFT OUTER JOIN 
		[dbo].[FNC_HEADING] AS FH ON F.FNC_HEADING_ID = FH.FNC_HEADING_ID LEFT OUTER JOIN 
		[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETD.ET_ID = ETDC.ET_ID AND 
											 ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND 
											 ETDC.ET_SOURCE = 'D' LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN 
		[dbo].[EMPLOYEE_TITLE] AS ETITLE ON EMP.EMPLOYEE_TITLE_ID = ETITLE.EMPLOYEE_TITLE_ID LEFT OUTER JOIN 
		[dbo].[SALES_CLASS] AS SC ON J.SC_CODE = SC.SC_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS AEEMP ON JC.EMP_CODE = AEEMP.EMP_CODE LEFT OUTER JOIN
		[dbo].[JOB_TYPE] AS JT ON JC.JT_CODE = JT.JT_CODE LEFT OUTER JOIN
		[dbo].[TRAFFIC_ROLE] AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE
	GROUP BY 
		ET.EMP_CODE, 
		CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		ETITLE.EMPLOYEE_TITLE,
		ISNULL(EMP.FREELANCE, 0),
		EMP.DIRECT_HRS_PER,
		EMP.MTH_HRS_GOAL,
		ETD.DP_TM_CODE, 
		DT.DP_TM_DESC, 
		J.CL_CODE, 
		C.CL_NAME, 
		J.DIV_CODE, 
		D.DIV_NAME, 
		J.PRD_CODE, 
		P.PRD_DESCRIPTION, 
		ETD.PROD_CAT_CODE, 
		PC.PROD_CAT_DESC, 
		ETD.JOB_NUMBER, 
		J.JOB_DESC, 
		J.SC_CODE, 
		SC.SC_DESCRIPTION, 
		ETD.JOB_COMPONENT_NBR, 
		JC.JOB_COMP_DESC, 
		JC.EMP_CODE, 
		CASE WHEN AEEMP.EMP_MI IS NULL OR AEEMP.EMP_MI = '' THEN RTRIM(LTRIM(ISNULL(AEEMP.EMP_FNAME, '') + ' ' + ISNULL(AEEMP.EMP_LNAME, ''))) ELSE AEEMP.EMP_FNAME + ' ' + AEEMP.EMP_MI + '. ' + AEEMP.EMP_LNAME END,
		JC.JT_CODE, 
		JT.JT_DESC,
		ETD.FNC_CODE, 
		F.FNC_DESCRIPTION, 
		ET.EMP_DATE,
		ETD.DATE_ENTERED,
		ET.EMP_TOT_HRS,
		ET.APPR_USER,
		ET.APPR_DATE,
		ET.APPR_PENDING,
		ET.APPR_FLAG,
		ETD.EMP_NON_BILL_FLAG,
		ISNUMERIC(ETD.AR_INV_NBR), 
		FH.FNC_HEADING_DESC, 
		CAST(ETDC.EMP_COMMENT AS VARCHAR(4000)),
		CAMP.CMP_IDENTIFIER,
		J.CMP_CODE, 
		CAMP.CMP_NAME, 
		EMP.OFFICE_CODE, 
		J.OFFICE_CODE,
		ISNULL(ETD.FEE_TIME, 0),
		EMP.DEF_TRF_ROLE,
		R.ROLE_DESC

END		

