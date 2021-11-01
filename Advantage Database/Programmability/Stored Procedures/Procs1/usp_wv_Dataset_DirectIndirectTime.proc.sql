if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dataset_DirectIndirectTime.]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dataset_DirectIndirectTime.]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dataset_DirectIndirectTime.] 
(
@StartDate smalldatetime,
@EndDate smalldatetime,
@DateType int,
@ByType int
)
AS
  

  SELECT 
		[ID] = NEWID(),
		[EmployeeCode] = DIT.EmployeeCode,
		[Employee] = DIT.Employee,
		[DepartmentTeamCode] = DIT.DepartmentTeamCode,
		[DepartmentTeam] = DIT.DepartmentTeam,
		[ClientCode] = DIT.ClientCode,
		[ClientDescription] = DIT.ClientDescription,
		[DivisionCode] = DIT.DivisionCode,
		[DivisionDescription] = DIT.DivisionDescription,
		[ProductCode] = DIT.ProductCode,
		[ProductDescription] = DIT.ProductDescription,
		[ProductCategoryCode] = DIT.ProductCategoryCode,
		[ProductCategoryDescription] = DIT.ProductCategoryDescription,
		[SalesClassCode] = DIT.SalesClassCode,
		[CampaignCode] = DIT.CampaignCode,
		[CampaignName] = DIT.CampaignName,
		[JobNumber] = DIT.JobNumber,
		[JobDescription] = DIT.JobDescription,
		[JobComponentNumber] = DIT.JobComponentNumber,
		[JobComponentDescription] = DIT.JobComponentDescription,
		[AccountExecutiveCode] = DIT.AccountExecutiveCode,
		[JobTypeCode] = DIT.JobTypeCode,
		[FunctionCode] = DIT.FunctionCode,
		[FunctionDescription] = DIT.FunctionDescription,
		[Type] = DIT.[Type],
		[Date] = DIT.[Date],
		[DateEntered] = DIT.DateEntered,
		[TotalHoursWorked] = DIT.TotalHoursWorked,
		[ApprovalUserCode] = DIT.ApprovalUserCode,
		[ApprovalDate] = DIT.ApprovalDate,
		[PendingApproval] = DIT.PendingApproval,
		[Approved] = DIT.Approved,
		[Hours] = DIT.[Hours],
		[Amount] = DIT.Amount,
		[MarkupAmount] = DIT.MarkupAmount,
		[ResaleTax] = DIT.ResaleTax,
		[TotalAmount] = DIT.TotalAmount,
		[TotalAmountWithTax] = DIT.TotalAmountWithTax,
		[NonBillable] = DIT.NonBillable,
		[Billed] = DIT.Billed,
		[FunctionHeadingDescription] = DIT.FunctionHeadingDescription,
		[Comments] = DIT.Comments,
		[EmployeeOfficeCode] = DIT.EmployeeOfficeCode,
		[JobOfficeCode] = DIT.JobOfficeCode,
		[DefaultRoleCode] = DIT.DefaultRoleCode,
		[DefaultRole] = DIT.DefaultRole
	FROM
		(SELECT  
			[EmployeeCode] = ET.EMP_CODE, 
			[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
			[DepartmentTeamCode] = ET.DP_TM_CODE, 
			[DepartmentTeam] = DT.DP_TM_DESC, 
			[ClientCode] = J.CL_CODE, 
			[ClientDescription] = C.CL_NAME, 
			[DivisionCode] = J.DIV_CODE, 
			[DivisionDescription] = D.DIV_NAME, 
			[ProductCode] = J.PRD_CODE, 
			[ProductDescription] = P.PRD_DESCRIPTION, 
			[ProductCategoryCode] = ET.PROD_CAT_CODE, 
			[ProductCategoryDescription] = PC.PROD_CAT_DESC, 
			[SalesClassCode] = J.SC_CODE, 
			[CampaignCode] = J.CMP_CODE, 
			[CampaignName] = CAMPAIGN.CMP_NAME,
			[JobNumber] = ET.JOB_NUMBER, 
			[JobDescription] = J.JOB_DESC, 
			[JobComponentNumber] = ET.JOB_COMPONENT_NBR, 
			[JobComponentDescription] = JC.JOB_COMP_DESC, 
			[AccountExecutiveCode] = JC.EMP_CODE, 
			[JobTypeCode] = JC.JT_CODE, 
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
			[TotalAmountWithTax] = SUM(ET.TOTAL_BILL) + SUM(ET.EXT_MARKUP_AMT) + SUM(ET.EXT_STATE_RESALE) + SUM(ET.EXT_COUNTY_RESALE) + SUM(ET.EXT_CITY_RESALE),
			[NonBillable] = CASE WHEN ISNULL(ET.EMP_NON_BILL_FLAG, 0) = 1 THEN 'Yes' ELSE 'No' END, 
			[Billed] = CASE WHEN ISNUMERIC(ET.AR_INV_NBR) = 1 THEN 'Yes' ELSE 'No' END, 
			[FunctionHeadingDescription] = FH.FNC_HEADING_DESC, 
			[Comments] = CAST(ETDC.EMP_COMMENT AS varchar(4000)),
			[EmployeeOfficeCode] = EMP.OFFICE_CODE,
			[JobOfficeCode] = J.OFFICE_CODE,
			[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
			[DefaultRole] = R.ROLE_DESC	
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
				FEE_TIME = ISNULL(ETD.FEE_TIME, 0),
				ETD.EMP_HOURS,
				ETD.TOTAL_BILL, 
				ETD.EXT_MARKUP_AMT, 
				ETD.EXT_STATE_RESALE,
				ETD.EXT_COUNTY_RESALE,
				ETD.EXT_CITY_RESALE
			FROM 
				[dbo].[EMP_TIME] AS ET INNER JOIN 
				[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID LEFT OUTER JOIN
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
				 GROUP BY ET_ID) AS ETDH ON ETDH.ET_ID = ET.ET_ID) AS ET INNER JOIN 
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
			[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ET.ET_ID = ETDC.ET_ID AND 
												 ET.ET_DTL_ID = ETDC.ET_DTL_ID AND 
												 ETDC.ET_SOURCE = 'D' LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] ON J.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER LEFT OUTER JOIN
			[dbo].[TRAFFIC_ROLE] AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE
		WHERE EMP_HOURS <> 0 AND ET.EMP_DATE BETWEEN @StartDate And @EndDate
		GROUP BY 
			ET.EMP_CODE, 
			CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
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
			ET.JOB_COMPONENT_NBR, 
			JC.JOB_COMP_DESC, 
			JC.EMP_CODE, 
			JC.JT_CODE, 
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
			CAST(ETDC.EMP_COMMENT AS VARCHAR(4000)),
			J.CMP_CODE, CAMPAIGN.CMP_NAME, 
			EMP.OFFICE_CODE, 
			J.OFFICE_CODE,
			EMP.DEF_TRF_ROLE,
			R.ROLE_DESC	

		UNION

		SELECT  
			[EmployeeCode] = ET.EMP_CODE, 
			[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END,
			[DepartmentTeamCode] = ET.DP_TM_CODE, 
			[DepartmentTeam] = DT.DP_TM_DESC, 
			[ClientCode] = NULL,
			[ClientDescription] = NULL,
			[DivisionCode] = NULL,
			[DivisionDescription] = NULL,
			[ProductCode] = NULL, 
			[ProductDescription] = NULL,
			[ProductCategoryCode] = NULL,
			[ProductCategoryDescription] = NULL,
			[SalesClassCode] = NULL,
			[CampaignCode] = NULL,
			[CampaignName] = NULL,
			[JobNumber] = NULL,
			[JobDescription] = NULL,
			[JobComponentNumber] = NULL,
			[JobComponentDescription] = NULL,
			[AccountExecutiveCode] = NULL,
			[JobTypeCode] = NULL,
			[FunctionCode] = ET.CATEGORY, 
			[FunctionDescription] = TC.[DESCRIPTION],
			[Type] = CASE WHEN TCT.TYPE_DESC IS NULL THEN TC.[DESCRIPTION] ELSE TCT.TYPE_DESC END,
			[Date] = ET.EMP_DATE, 
			[DateEntered] = ET.DATE_ENTERED, 
			[TotalHoursWorked] = ET.EMP_TOT_HRS,
			[ApprovalUserCode] = ET.APPR_USER,
			[ApprovalDate] = ET.APPR_DATE,
			[PendingApproval] = CASE WHEN ET.APPR_PENDING = 1 THEN 'Yes' ELSE '' END,
			[Approved] = CASE WHEN ET.APPR_FLAG = 1 THEN 'Yes' ELSE '' END,
			[Hours] = SUM(ET.EMP_HOURS),
			[Amount] = 0, 
			[MarkupAmount] = 0,
			[ResaleTax] = 0, 
			[TotalAmount] = 0, 
			[TotalAmountWithTax] = 0, 
			[NonBillable] = NULL, 
			[Billed] = NULL, 
			[FunctionHeadingDescription] = NULL,
			[Comments] = CAST(ETDC.EMP_COMMENT AS varchar(4000)),
			[EmployeeOfficeCode] = EMP.OFFICE_CODE,
			[JobOfficeCode] = NULL,
			[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
			[DefaultRole] = R.ROLE_DESC
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
				ETN.CATEGORY,
				ETN.DP_TM_CODE,
				ETN.DATE_ENTERED,  
				ETN.EMP_HOURS, 
				ETN.ET_DTL_ID
			FROM 
				[dbo].[EMP_TIME] AS ET INNER JOIN 
				[dbo].[EMP_TIME_NP] AS ETN ON ETN.ET_ID = ET.ET_ID LEFT OUTER JOIN
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
				 GROUP BY ET_ID) AS ETDH ON ETDH.ET_ID = ET.ET_ID) AS ET INNER JOIN 
			[dbo].[EMPLOYEE_CLOAK] AS EMP ON ET.EMP_CODE = EMP.EMP_CODE INNER JOIN 
			[dbo].[DEPT_TEAM] AS DT ON ET.DP_TM_CODE = DT.DP_TM_CODE INNER JOIN				
			[dbo].[TIME_CATEGORY] AS TC ON ET.CATEGORY = TC.CATEGORY LEFT OUTER JOIN
			[dbo].[TIME_CATEGORY_TYPE] AS TCT ON TC.VAC_SICK_FLAG = TCT.[TYPE_ID] LEFT OUTER JOIN
			[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ET.ET_ID = ETDC.ET_ID AND 
												 ET.ET_DTL_ID = ETDC.ET_DTL_ID AND 
												 ETDC.ET_SOURCE = 'N' LEFT OUTER JOIN
			[dbo].[TRAFFIC_ROLE] AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE
			WHERE ET.EMP_DATE BETWEEN @StartDate And @EndDate
		GROUP BY 
			ET.EMP_CODE, 
			CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
			ET.DP_TM_CODE, 
			DT.DP_TM_DESC, 
			ET.CATEGORY, 
			TC.DESCRIPTION,
			TCT.TYPE_DESC,
			ET.EMP_DATE, 
			ET.DATE_ENTERED, 
			ET.EMP_TOT_HRS,
			ET.APPR_USER,
			ET.APPR_DATE,
			ET.APPR_PENDING,
			ET.APPR_FLAG,
			CAST(ETDC.EMP_COMMENT AS VARCHAR(4000)),
			EMP.OFFICE_CODE,
			EMP.DEF_TRF_ROLE,
			R.ROLE_DESC	
		) AS DIT





                
                
                
                
      



