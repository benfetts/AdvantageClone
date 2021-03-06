if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_DRPT_CRM_CLIENT_CONTRACTS]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[V_DRPT_CRM_CLIENT_CONTRACTS]
GO

CREATE VIEW [dbo].[V_DRPT_CRM_CLIENT_CONTRACTS]

WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
		[ClientCode] = C.CL_CODE,
		[ClientName] = CL.CL_NAME,
		[DivisionCode] = C.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = C.PRD_CODE,
		[ProductName] = P.PRD_DESCRIPTION,
		[NewBusiness] = CASE WHEN CL.NEW_BUSINESS = 1 THEN 'Y' ELSE 'N' END,
		[Code] = C.CONTRACT_CODE,
		[Description] = C.[DESCRIPTION],
		[ContractStartDate] = C.[START_DATE],
		[ContractEndDate] = C.END_DATE,
		[BlendedBillingRate] = C.BLENDED_HOURLY_RATE,
		[FeeRetainer] = ISNULL(C.FEE_RETAINER,0),
		[FeeHours] = ISNULL(FEEHOURS,0),
		[FeeIncentiveBonus] = ISNULL(C.FEE_INCENTIVE_BONUS,0),
		[FeeRoyalty] = ISNULL(C.FEE_ROYALTY,0),
		[ProjectHourlyTotal] = ISNULL(C.FEE_PROJECT_HOURLY,0),
		[ProjectHours] = ISNULL(C.[HOURS],0),
		[MediaCommission] = ISNULL(C.MEDIA_COMMISSION,0),
		[ProductionCommission] = ISNULL(C.PRODUCTION_COMMISSION,0),
		[TotalValue] = dbo.[advfn_crm_total_contract_value] (C.CONTRACT_ID),
		[MonthlyValue] = CASE WHEN (DATEDIFF(m,[START_DATE],END_DATE) + 1) <> 0 THEN
								CAST(dbo.[advfn_crm_total_contract_value] (C.CONTRACT_ID) / (DATEDIFF(m,[START_DATE],END_DATE) + 1) AS DECIMAL(18,2))
						 ELSE 0 END,
		[MonthlyHours] = CASE WHEN (DATEDIFF(m,[START_DATE],END_DATE) + 1) <> 0 THEN
								CAST((ISNULL(C.[HOURS],0) + ISNULL(FEEHOURS,0)) / (DATEDIFF(m,[START_DATE],END_DATE) + 1) AS DECIMAL(18,2))
						 ELSE 0 END,
		[ReportingRequirements] = CASE ISNULL(RC.REPORTCOUNT,0) WHEN 0 THEN 'N' ELSE 'Y' END,
		[ValueAdded] = CASE ISNULL(VA.VALUEADDEDCOUNT,0) WHEN 0 THEN 'N' ELSE 'Y' END,
		[DefaultAECode] = AE.EMP_CODE,
		[DefaultAEName] = COALESCE((RTRIM(EMP_FNAME) + ' '),'') + COALESCE((EMP_MI + '. '),'') + COALESCE(EMP_LNAME,''),
		[ValueAddedAmountTotal] = VA.SUM_VA_AMOUNT,
		[Industry] = ISNULL(I.[DESCRIPTION],''),
		[Specialty] = ISNULL(S.[DESCRIPTION],''),
		[RegionCode] = ISNULL(CP.REGION_CODE,''),
		[Region] = ISNULL(R.REGION_DESC,''),
		[Revenue] = ISNULL(CP.REVENUE,0),
		[NumberOfEmployees] = CP.NUM_EMPLOYEES,
		[CaseStudyDone] = CASE ISNULL(CP.CASE_STUDY,0) WHEN 0 THEN 'N' ELSE 'Y' END,
		[UseAsReference] = CASE ISNULL(CP.REFERENCE,0) WHEN 0 THEN 'N' ELSE 'Y' END,
		[TurnoverPercent] = ISNULL(CP.TURNOVER_PERCENT,0),
		[ClientType1Code] = CP.CLIENT_TYPE1_ID,
		[ClientType1Description] = CT1.[DESCRIPTION],
		[ClientType2Code] = CP.CLIENT_TYPE2_ID,
		[ClientType2Description] = CT2.[DESCRIPTION],
		[ClientType3Code] = CP.CLIENT_TYPE3_ID,
		[ClientType3Description] = CT3.[DESCRIPTION],
		[Notes] = ISNULL(NOTES,'')
		
	FROM
		[dbo].[CONTRACT] AS C LEFT OUTER JOIN
		[dbo].[CLIENT] AS CL ON C.CL_CODE = CL.CL_CODE LEFT OUTER JOIN
		[dbo].[DIVISION] AS D ON C.CL_CODE = D.CL_CODE AND C.DIV_CODE = D.DIV_CODE LEFT OUTER JOIN
		[dbo].[PRODUCT] AS P ON C.CL_CODE = P.CL_CODE AND C.DIV_CODE = P.DIV_CODE AND C.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
		(SELECT COUNT(1) AS REPORTCOUNT, CONTRACT_ID FROM [dbo].[CONTRACT_REPORT] GROUP BY CONTRACT_ID) RC ON C.CONTRACT_ID = RC.CONTRACT_ID LEFT OUTER JOIN
		(SELECT COUNT(1) AS VALUEADDEDCOUNT, SUM(VA_AMOUNT) AS SUM_VA_AMOUNT, CONTRACT_ID FROM [dbo].[CONTRACT_VALUE_ADDED] GROUP BY CONTRACT_ID) VA ON C.CONTRACT_ID = VA.CONTRACT_ID LEFT OUTER JOIN
		[dbo].ACCOUNT_EXECUTIVE AE ON C.CL_CODE = AE.CL_CODE AND C.DIV_CODE = AE.DIV_CODE AND C.PRD_CODE = AE.PRD_CODE AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		[dbo].EMPLOYEE_CLOAK E ON AE.EMP_CODE = E.EMP_CODE LEFT OUTER JOIN
		(SELECT SUM([HOURS]) AS FEEHOURS, CONTRACT_ID FROM dbo.[CONTRACT_FEES] GROUP BY CONTRACT_ID) FEES ON C.CONTRACT_ID = FEES.CONTRACT_ID LEFT OUTER JOIN
		[dbo].COMPANY_PROFILE CP ON CP.PRD_CODE = P.PRD_CODE AND CP.DIV_CODE = P.DIV_CODE AND CP.CL_CODE = P.CL_CODE LEFT OUTER JOIN
		[dbo].INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
		[dbo].SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
		[dbo].REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
		[dbo].CLIENT_TYPE1 CT1 ON CT1.CLIENT_TYPE1_ID = CP.CLIENT_TYPE1_ID LEFT OUTER JOIN
		[dbo].CLIENT_TYPE2 CT2 ON CT2.CLIENT_TYPE2_ID = CP.CLIENT_TYPE2_ID LEFT OUTER JOIN
		[dbo].CLIENT_TYPE3 CT3 ON CT3.CLIENT_TYPE3_ID = CP.CLIENT_TYPE3_ID
		
	WHERE
			C.IS_CONTRACT = 1
	AND		C.INACTIVE_FLAG = 0
	AND		(P.INACTIVE IS NULL OR P.INACTIVE = 0)
	
GO
