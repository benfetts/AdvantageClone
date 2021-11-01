if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_direct_time_cost_load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_direct_time_cost_load]
GO

CREATE PROCEDURE [dbo].[advsp_direct_time_cost_load] 
	@DATE_TYPE AS int,
	@START_DATE AS smalldatetime,
	@END_DATE AS smalldatetime,
	@UserID varchar(100)
AS
    
	DECLARE @StartDate smalldatetime, @EndDate smalldatetime,@StdHours as decimal(9,3)
	DECLARE @paramlist nvarchar(4000)
	DECLARE @sql 		nvarchar(4000)
	DECLARE @sql_from 	nvarchar(4000)
	DECLARE @sql_where	nvarchar(4000)
	DECLARE @sql_groupby nvarchar(4000)

				
DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)

INSERT INTO W_EMP_STD_HOURS (USERID, START_DATE, END_DATE)
VALUES(UPPER(@UserID), @START_DATE, @END_DATE)		

--SELECT SUM(STD_HRS)
--FROM W_EMP_STD_HOURS_DTL WS
--WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = @EmpCode AND WS.WORK_DATE >= @START_DATE AND WS.WORK_DATE <= @END_DATE
	
	CREATE TABLE #DT 
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[EmployeeCode] varchar(6), 
		[Employee] varchar(80), 
		[EmployeeFirstName] varchar(30),
		[EmployeeLastName] varchar(30),
		[EmployeeLastFirst] varchar(100),
		[EmployeeTitle] varchar(50),
		[EmployeeAccountNumber] varchar(30),
		[EmployeeCategory] varchar(50),
		[IsEmployeeFreelance] varchar(3),
		[IsActiveFreelance] varchar(3),
		[DirectHoursGoalPercent] decimal(7, 4),
		[BillableHoursGoal] decimal(9, 3),
		[DepartmentTeamCode] varchar(6), 		
		[DepartmentTeam] varchar(30),
		[SupervisorCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Supervisor] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,--CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END,
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientDescription] varchar(40),
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionDescription] varchar(40),
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ProductDescription] varchar(40),
		[ProductCategoryCode] varchar(10), 
		[ProductCategoryDescription] varchar(60), 
		[SalesClassCode] varchar(6), 
		[SalesClassDescription] varchar(30), 
		[CampaignID] int,
		[CampaignCode] varchar(6), 
		[CampaignName] varchar(128),
		[JobNumber] int,
		[JobDescription] varchar(60), 
		[JobComponentNumber] smallint,
		[JobComponentDescription] varchar(60), 
		[JobComponent] varchar(60),
		[AccountExecutiveCode] varchar(6),
		[AccountExecutive] varchar(80),
		[JobTypeCode] varchar(10),
		[JobTypeDescription] varchar(30),
		[LabelFromUDFTable1] varchar(40),
		[LabelFromUDFTable2] varchar(40),
		[LabelFromUDFTable3] varchar(40),
		[LabelFromUDFTable4] varchar(40),
		[LabelFromUDFTable5] varchar(40), 
		[FunctionCode] varchar(6), 
		[FunctionDescription] varchar(30), 
		[Type] varchar(10),
		[Date] smalldatetime, 
		[DateEntered] smalldatetime,
		[TotalHoursWorked] decimal(9, 2),
		[ApprovalUserCode] varchar(100),
		[ApprovalDate] smalldatetime,
		[PendingApproval] varchar(4),
		[Approved] varchar(4),
		[Hours] decimal(9, 2),
		[Amount] decimal(14, 2), 
		[MarkupAmount] decimal(14, 2), 
		[ResaleTax] decimal(14, 2), 
		[TotalAmount] decimal(14, 2), 
		[TotalBilled] decimal(14, 2), 
		[TotalAmountWithTax] decimal(14, 2),
		[TotalBilledWithTax] decimal(14, 2), 
		[NonBillable] varchar(4), 
		[Billed] varchar(4), 
		[CostAmount] decimal(14, 2),
		[AlternateCostAmount] decimal(14, 2),
		[FunctionHeadingDescription] varchar(60), 
		[Comments] varchar(MAX),
		[EmployeeOfficeCode] varchar(4),
		[JobOfficeCode] varchar(4),
		[IsFeeTime] varchar(4),
		[DefaultRoleCode] varchar(6),
		[DefaultRole] varchar(40),
		[Status] varchar(12),
		[EmployeeRateFrom] varchar(254),
		[AdjustmentComments] varchar(MAX),
		[ARPostPeriod] varchar(6),
		[StandardHours]  decimal(14, 2),
		[UserID] varchar(100),
		[FunctionConsolidationCode] varchar(6),
		[FunctionConsolidationDescription] varchar(30),
		[CmpBeginDate] smalldatetime,
		[CmpEndDate] smalldatetime,
		[ClientPO] varchar(40),
		[ARInvoiceNumber] int,
		[Terminated] varchar(1),
		[TerminatedDate] smalldatetime
	);	

	INSERT INTO #DT
    SELECT  
		--[ID] = NEWID(),
		[EmployeeCode] = ET.EMP_CODE, 
		[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		[EmployeeFirstName] = EMP.EMP_FNAME,
		[EmployeeLastName] = EMP.EMP_LNAME,
		[EmployeeLastFirst] = EMP.EMP_LNAME + ', ' + EMP.EMP_FNAME,
		[EmployeeTitle] = ET.EMPLOYEE_TITLE,
		[EmployeeAccountNumber] = EMP.EMP_ACCOUNT_NBR,
		[EmployeeCategory] = ET.EMPLOYEE_CATEGORY,
		[IsEmployeeFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[IsActiveFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN CASE WHEN EMP.IS_ACTIVE_FREELANCE = 1 THEN 'Yes' ELSE 'No' END ELSE 'No' END,
		[DirectHoursGoalPercent] = EMP.DIRECT_HRS_PER,
		[BillableHoursGoal] = EMP.MTH_HRS_GOAL,
		[DepartmentTeamCode] = ET.DP_TM_CODE, 
		[DepartmentTeam] = DT.DP_TM_DESC, 
		[SupervisorCode] = EMP.SUPERVISOR_CODE,
		[Supervisor] = '',
		[ClientCode] = J.CL_CODE, 
		[ClientDescription] = C.CL_NAME, 
		[DivisionCode] = J.DIV_CODE, 
		[DivisionDescription] = D.DIV_NAME, 
		[ProductCode] = J.PRD_CODE, 
		[ProductDescription] = P.PRD_DESCRIPTION, 
		[ProductCategoryCode] = ET.PROD_CAT_CODE, 
		[ProductCategoryDescription] = PC.PROD_CAT_DESC, 
		[SalesClassCode] = J.SC_CODE, 
		[SalesClassDescription] = SC.SC_DESCRIPTION, 
		[CampaignID] = CAMP.CMP_IDENTIFIER,
		[CampaignCode] = J.CMP_CODE, 
		[CampaignName] = CAMP.CMP_NAME,
		[JobNumber] = ET.JOB_NUMBER, 
		[JobDescription] = J.JOB_DESC, 
		[JobComponentNumber] = ET.JOB_COMPONENT_NBR, 
		[JobComponentDescription] = JC.JOB_COMP_DESC, 
		[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), ET.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), ET.JOB_COMPONENT_NBR), 3),
		[AccountExecutiveCode] = JC.EMP_CODE,
		[AccountExecutive] = CASE WHEN AEEMP.EMP_MI IS NULL OR AEEMP.EMP_MI = '' THEN RTRIM(LTRIM(ISNULL(AEEMP.EMP_FNAME, '') + ' ' + ISNULL(AEEMP.EMP_LNAME, ''))) ELSE AEEMP.EMP_FNAME + ' ' + AEEMP.EMP_MI + '. ' + AEEMP.EMP_LNAME END,
		[JobTypeCode] = JC.JT_CODE,
		[JobTypeDescription] = JT.JT_DESC, 
		[LabelFromUDFTable1] = JUDV1.UDV_DESC,
		[LabelFromUDFTable2] = JUDV2.UDV_DESC,
		[LabelFromUDFTable3] = JUDV3.UDV_DESC,
		[LabelFromUDFTable4] = JUDV4.UDV_DESC,
		[LabelFromUDFTable5] = JUDV5.UDV_DESC, 
		[FunctionCode] = ET.FNC_CODE, 
		[FunctionDescription] = F.FNC_DESCRIPTION, 
		[Type] = 'Direct',
		[Date] = ET.EMP_DATE, 
		[DateEntered] = ET.DATE_ENTERED,
		[TotalHoursWorked] = ET.EMP_TOT_HRS,
		[ApprovalUserCode] = ET.APPR_USER,
		[ApprovalDate] = ET.APPR_DATE,
		[PendingApproval] = CASE WHEN ET.APPR_PENDING = 1 THEN 'Yes' ELSE '' END,
		[Approved] = CASE WHEN ET.APPR_FLAG = 1 THEN 'Yes' ELSE '' END,
		[Hours] = SUM(ET.EMP_HOURS),
		[Amount] = SUM(ET.TOTAL_BILL), 
		[MarkupAmount] = SUM(ET.EXT_MARKUP_AMT), 
		[ResaleTax] = SUM(ET.EXT_STATE_RESALE) + SUM(ET.EXT_COUNTY_RESALE) + SUM(ET.EXT_CITY_RESALE), 
		[TotalAmount] = SUM(ET.TOTAL_BILL) + SUM(ET.EXT_MARKUP_AMT), 
		[TotalBilled] = CASE WHEN ISNUMERIC(ET.AR_INV_NBR) = 1 THEN SUM(ET.TOTAL_BILL) + SUM(ET.EXT_MARKUP_AMT) ELSE 0.0 END, 
		[TotalAmountWithTax] = SUM(ET.TOTAL_BILL) + SUM(ET.EXT_MARKUP_AMT) + SUM(ET.EXT_STATE_RESALE) + SUM(ET.EXT_COUNTY_RESALE) + SUM(ET.EXT_CITY_RESALE),
		[TotalBilledWithTax] = CASE WHEN ISNUMERIC(ET.AR_INV_NBR) = 1 THEN SUM(ET.TOTAL_BILL) + SUM(ET.EXT_MARKUP_AMT) + SUM(ET.EXT_STATE_RESALE) + SUM(ET.EXT_COUNTY_RESALE) + SUM(ET.EXT_CITY_RESALE) ELSE 0.0 END, 
		[NonBillable] = CASE WHEN ISNULL(ET.EMP_NON_BILL_FLAG, 0) = 1 THEN 'Yes' ELSE 'No' END, 
		[Billed] = CASE WHEN ISNUMERIC(ET.AR_INV_NBR) = 1 THEN 'Yes' ELSE 'No' END, 
		[CostAmount] = SUM(ET.TOTAL_COST),
		[AlternateCostAmount] = SUM(ET.ALT_COST_AMT),
		[FunctionHeadingDescription] = FH.FNC_HEADING_DESC, 
		[Comments] = CAST(ET.EMP_COMMENT AS varchar(4000)),
		[EmployeeOfficeCode] = EMP.OFFICE_CODE,
		[JobOfficeCode] = J.OFFICE_CODE,
		[IsFeeTime] = CASE WHEN ISNULL(ET.FEE_TIME, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
		[DefaultRole] = R.ROLE_DESC,
		[Status] = CASE WHEN EMP.[STATUS] = 0 THEN 'N/A'
			            WHEN EMP.[STATUS] = 1 THEN 'Exempt'
						WHEN EMP.[STATUS] = 2 THEN 'Non-Exempt'
						ELSE 'N/A' END,
		[EmployeeRateFrom] = ET.EMP_RATE_FROM,
		[AdjustmentComments] = CAST(ET.ADJ_COMMENTS AS varchar(4000)),
		[ARPostPeriod] = AR.AR_POST_PERIOD,
		[StandardHours] = (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS
							WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ET.EMP_CODE AND WS.WORK_DATE >= ET.EMP_DATE AND WS.WORK_DATE <= ET.EMP_DATE),
		[UserID] = ET.[USER_ID],
		[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
		[FunctionConsolidation] = CF.FNC_DESCRIPTION,
		[CmpBeginDate] = CAMP.CMP_BEG_DATE,
		[CmpEndDate] = CAMP.CMP_END_DATE,
		[ClientPO] = JC.JOB_CL_PO_NBR,
		[ARInvoiceNumber] = ET.AR_INV_NBR,
		[Terminated] = CASE WHEN EMP.EMP_TERM_DATE IS NULL THEN 'N' ELSE 'Y' END,
		[TerminatedDate] = EMP.EMP_TERM_DATE
	FROM 
		(SELECT 
			ET.ET_ID,
			ET.EMP_CODE,
			ET.EMP_DATE,
			EMP_TOT_HRS = ETDH.EMP_HOURS,
			ET.APPR_USER,
			ET.APPR_DATE,
			ET.APPR_PENDING,
			ET.APPR_FLAG,
			ETD.SEQ_NBR,
			ETD.ET_DTL_ID,
			ETD.DP_TM_CODE,  
			ETD.PROD_CAT_CODE, 
			ETD.JOB_NUMBER, 
			ETD.JOB_COMPONENT_NBR,
			ETD.FNC_CODE, 
			ETD.DATE_ENTERED,
			ETD.EMP_NON_BILL_FLAG,
			ETD.AR_INV_NBR, 
			ETD.AR_TYPE,
			FEE_TIME = ISNULL(ETD.FEE_TIME, 0),
			ETD.EMP_HOURS,
			ETD.TOTAL_BILL, 
			ETD.EXT_MARKUP_AMT, 
			ETD.EXT_STATE_RESALE,
			ETD.EXT_COUNTY_RESALE,
			ETD.EXT_CITY_RESALE,
			TOTAL_COST = ISNULL(ETD.TOTAL_COST, 0),
			ALT_COST_AMT = ISNULL(ETD.ALT_COST_AMT, 0),
			EMPT.EMPLOYEE_TITLE,
			EMPC.EMPLOYEE_CATEGORY,
			ETD.EMP_RATE_FROM,
			ETD.ADJ_COMMENTS,
			ETD.[USER_ID],
			ETD.EDIT_FLAG,
			EMP_COMMENT = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(4000))	FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC)
		FROM 
			[dbo].[EMP_TIME] AS ET INNER JOIN 
			[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID LEFT OUTER JOIN 
			[dbo].[EMPLOYEE_TITLE] AS EMPT ON EMPT.EMPLOYEE_TITLE_ID = ETD.EMPLOYEE_TITLE_ID  LEFT OUTER JOIN
			[dbo].[EMPLOYEE_CATEGORY] AS EMPC ON EMPC.EMPLOYEE_CATEGORY_ID = EMPT.EMPLOYEE_CATEGORY_ID LEFT OUTER JOIN
			(SELECT 
				ET_ID, 
				EMP_HOURS = SUM(EMP_HOURS) 
			 FROM
				(SELECT ET_ID, EMP_HOURS = SUM(EMP_HOURS) 
				 FROM dbo.EMP_TIME_DTL
				 GROUP BY ET_ID
				 
				 UNION ALL
				 
				 SELECT ET_ID, EMP_HOURS = SUM(EMP_HOURS) 
				 FROM dbo.EMP_TIME_NP 
				 GROUP BY ET_ID) AS ETH
			 GROUP BY ET_ID) AS ETDH ON ETDH.ET_ID = ET.ET_ID) AS ET LEFT OUTER JOIN
		(SELECT 
			DISTINCT 
			AR.AR_POST_PERIOD,
			AR.AR_INV_NBR, 
			AR.AR_TYPE
		FROM 
			[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ET.AR_INV_NBR AND 
											 AR.AR_TYPE = ET.AR_TYPE INNER JOIN 
		[dbo].[JOB_LOG] AS J ON ET.JOB_NUMBER = J.JOB_NUMBER INNER JOIN 
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON ET.EMP_CODE = EMP.EMP_CODE INNER JOIN 
		[dbo].[CLIENT] AS C ON J.CL_CODE = C.CL_CODE INNER JOIN 
		[dbo].[DIVISION] AS D ON J.CL_CODE = D.CL_CODE AND 
								 J.DIV_CODE = D.DIV_CODE INNER JOIN 
		[dbo].[PRODUCT] AS P ON J.CL_CODE = P.CL_CODE AND 
								J.DIV_CODE = P.DIV_CODE AND 
								J.PRD_CODE = P.PRD_CODE INNER JOIN 
		[dbo].[DEPT_TEAM] AS DT ON ET.DP_TM_CODE = DT.DP_TM_CODE INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON ET.JOB_NUMBER = JC.JOB_NUMBER AND 
									   ET.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR INNER JOIN 
		[dbo].[FUNCTIONS] AS F ON ET.FNC_CODE = F.FNC_CODE LEFT OUTER JOIN 
		[dbo].[PRODUCT_CATEGORY] AS PC ON J.CL_CODE = PC.CL_CODE AND 
										  J.DIV_CODE = PC.DIV_CODE AND 
										  J.PRD_CODE = PC.PRD_CODE AND 
										  ET.PROD_CAT_CODE = PC.PROD_CAT_CODE LEFT OUTER JOIN 
		[dbo].[FNC_HEADING] AS FH ON F.FNC_HEADING_ID = FH.FNC_HEADING_ID LEFT OUTER JOIN 
		--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ET.ET_ID = ETDC.ET_ID AND 
		--									 ET.ET_DTL_ID = ETDC.ET_DTL_ID AND 
		--									 --ET.SEQ_NBR = ETDC.SEQ_NBR AND 
		--									 ETDC.ET_SOURCE = 'D' LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN 
		[dbo].[SALES_CLASS] AS SC ON J.SC_CODE = SC.SC_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS AEEMP ON JC.EMP_CODE = AEEMP.EMP_CODE LEFT OUTER JOIN
		[dbo].[JOB_TYPE] AS JT ON JC.JT_CODE = JT.JT_CODE LEFT OUTER JOIN
		[dbo].[TRAFFIC_ROLE] AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
		[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE	LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION		--PJH 05/20/2016 - Added
	
	WHERE EMP_HOURS <> 0 AND
		1 = CASE WHEN @DATE_TYPE = 0 THEN CASE WHEN ET.EMP_DATE >= @START_DATE AND ET.EMP_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 1 THEN CASE WHEN ET.DATE_ENTERED >= @START_DATE AND ET.DATE_ENTERED <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 2 THEN CASE WHEN ET.APPR_DATE >= @START_DATE AND ET.APPR_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) THEN 1 ELSE 0 END 
				 WHEN @DATE_TYPE = 3 THEN 1 END  AND (ET.EDIT_FLAG IS NULL OR ET.EDIT_FLAG = 0)
	GROUP BY 
		ET.EMP_CODE, 
		CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		EMP.EMP_FNAME,
		EMP.EMP_LNAME,
		ET.EMPLOYEE_TITLE,
		EMP.EMP_ACCOUNT_NBR,
		ET.EMPLOYEE_CATEGORY,
		ISNULL(EMP.FREELANCE, 0),
		EMP.IS_ACTIVE_FREELANCE,
		EMP.DIRECT_HRS_PER,
		EMP.MTH_HRS_GOAL,
		ET.DP_TM_CODE, 
		DT.DP_TM_DESC, 
		J.CL_CODE, 
		C.CL_NAME, 
		J.DIV_CODE, 
		D.DIV_NAME, 
		J.PRD_CODE, 
		P.PRD_DESCRIPTION, 
		ET.PROD_CAT_CODE, 
		PC.PROD_CAT_DESC, 
		ET.JOB_NUMBER, 
		J.JOB_DESC, 
		J.SC_CODE, 
		SC.SC_DESCRIPTION, 
		ET.JOB_COMPONENT_NBR, 
		JC.JOB_COMP_DESC, 
		JC.EMP_CODE, 
		CASE WHEN AEEMP.EMP_MI IS NULL OR AEEMP.EMP_MI = '' THEN RTRIM(LTRIM(ISNULL(AEEMP.EMP_FNAME, '') + ' ' + ISNULL(AEEMP.EMP_LNAME, ''))) ELSE AEEMP.EMP_FNAME + ' ' + AEEMP.EMP_MI + '. ' + AEEMP.EMP_LNAME END,
		JC.JT_CODE, 
		JT.JT_DESC,
		F.FNC_CONSOLIDATION,
		CF.FNC_DESCRIPTION,		
		ET.FNC_CODE, 
		F.FNC_DESCRIPTION, 
		ET.EMP_DATE,
		ET.DATE_ENTERED,
		ET.EMP_TOT_HRS,
		ET.APPR_USER,
		ET.APPR_DATE,
		ET.APPR_PENDING,
		ET.APPR_FLAG,
		ET.EMP_NON_BILL_FLAG,
		ISNUMERIC(ET.AR_INV_NBR), 
		FH.FNC_HEADING_DESC, 
		CAST(ET.EMP_COMMENT AS VARCHAR(4000)),
		CAMP.CMP_IDENTIFIER,
		J.CMP_CODE, 
		CAMP.CMP_NAME, 
		EMP.OFFICE_CODE, 
		J.OFFICE_CODE,
		ISNULL(ET.FEE_TIME, 0),
		EMP.DEF_TRF_ROLE,
		R.ROLE_DESC,
		EMP.[STATUS],
		ET.EMP_RATE_FROM,
		JUDV1.UDV_DESC,
		JUDV2.UDV_DESC,
		JUDV3.UDV_DESC,
		JUDV4.UDV_DESC,
		JUDV5.UDV_DESC,
		CAST(ET.ADJ_COMMENTS AS VARCHAR(4000)),
		AR.AR_POST_PERIOD,
		ET.AR_INV_NBR,
		ET.[USER_ID],
		CAMP.CMP_BEG_DATE,
		CAMP.CMP_END_DATE,    
		F.FNC_CONSOLIDATION,
		CF.FNC_DESCRIPTION,
		EMP.SUPERVISOR_CODE,
		JC.JOB_CL_PO_NBR,
		EMP.EMP_TERM_DATE


    UPDATE #DT
	SET Supervisor = (SELECT CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END
								FROM [dbo].[EMPLOYEE_CLOAK] AS SUP WHERE SUP.EMP_CODE = #DT.SupervisorCode)

	SELECT * FROM #DT		
	
	DROP TABLE #DT