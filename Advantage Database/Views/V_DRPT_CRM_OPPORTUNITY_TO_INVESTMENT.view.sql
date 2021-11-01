CREATE VIEW [dbo].[V_DRPT_CRM_OPPORTUNITY_TO_INVESTMENT]

WITH SCHEMABINDING 
AS
	
	SELECT
		[ID] = NEWID(),
		ClientCode,
		ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductName,
		NewBusiness,
		LastActivityDate,
		LastContactDate,
		Probability,
		RatingDescription,
		SUM(FeeRetainer) AS TotalFeeRetainer,
		SUM(FeeHours) AS TotalFeeHours,
		SUM(FeeIncentiveBonus) AS TotalFeeIncentiveBonus,
		SUM(FeeRoyalty) AS TotalFeeRoyalty,
		SUM(ProjectHourlyTotal) AS TotalProjectHourlyTotal,
		SUM(ProjectHours) AS TotalProjectHours,
		SUM(MediaCommission) AS TotalMediaCommission,
		SUM(ProductionCommission) AS TotalProductionCommission,
		SUM(TotalValue) AS TotalOpportunityValue,
		SUM(MonthlyValue) AS TotalMonthlyValue,
		SUM(TotalInvestment) AS TotalInvestment,
		[RecoupMonths] = CASE WHEN SUM(MonthlyValue) <> 0 THEN CAST(SUM(TotalInvestment) / SUM(MonthlyValue) AS DECIMAL(18,2))
						 ELSE 0 END,
		ContractEndDate,
		DefaultAECode,
		DefaultAEName,
		SoldDate,
		LostDate
		
	FROM (
		SELECT 
			[ClientCode] = C.CL_CODE,
			[ClientName] = CL.CL_NAME,
			[DivisionCode] = C.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = C.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[NewBusiness] = CASE WHEN CL.NEW_BUSINESS = 1 THEN 'Y' ELSE 'N' END,
			[LastActivityDate] = dbo.[advfn_crm_last_activity_date] (C.CL_CODE, C.DIV_CODE, C.PRD_CODE),
			[LastContactDate] = A.LAST_CONTACT_DATE,
			[Probability] = A.PROBABILITY,
			[RatingDescription] = R.[DESCRIPTION],
			[FeeRetainer] = ISNULL(C.FEE_RETAINER,0),
			[FeeHours] = ISNULL((SELECT SUM([HOURS]) FROM dbo.[CONTRACT_FEES] WHERE CONTRACT_ID = C.CONTRACT_ID),0),
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
			[TotalInvestment] = ISNULL(ED.EMPTOTAL, 0) + ISNULL(PROD.PRODCHARGES, 0),
			[ContractEndDate] = C.END_DATE,
			[DefaultAECode] = AE.EMP_CODE,
			[DefaultAEName] = COALESCE((RTRIM(EMP_FNAME) + ' '),'') + COALESCE((EMP_MI + '. '),'') + COALESCE(EMP_LNAME,''),
			[SoldDate] = A.SOLD_DATE,
			[LostDate] = A.LOST_DATE

		FROM
			[dbo].[CONTRACT] AS C INNER JOIN 
			[dbo].[CLIENT] AS CL ON C.CL_CODE = CL.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON C.CL_CODE = D.CL_CODE AND C.DIV_CODE = D.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON C.CL_CODE = P.CL_CODE AND C.DIV_CODE = P.DIV_CODE AND C.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
			[dbo].[ACTIVITY] AS A ON C.CL_CODE = A.CL_CODE AND C.DIV_CODE = A.DIV_CODE AND C.PRD_CODE = A.PRD_CODE LEFT OUTER JOIN
			[dbo].[ACCOUNT_EXECUTIVE] AE ON C.CL_CODE = AE.CL_CODE AND C.DIV_CODE = AE.DIV_CODE AND C.PRD_CODE = AE.PRD_CODE AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			[dbo].[EMPLOYEE_CLOAK] E ON AE.EMP_CODE = E.EMP_CODE LEFT OUTER JOIN
			[dbo].[RATING] AS R ON A.RATING_ID = R.RATING_ID LEFT OUTER JOIN
			(SELECT SUM(ISNULL(LINE_TOTAL,0) - (ISNULL(EXT_STATE_RESALE,0) + ISNULL(EXT_COUNTY_RESALE,0) + ISNULL(EXT_CITY_RESALE,0))) AS EMPTOTAL,
					J.CL_CODE, J.DIV_CODE, J.PRD_CODE
				FROM dbo.[EMP_TIME_DTL] AS E INNER JOIN dbo.[JOB_LOG] AS J ON E.JOB_NUMBER = J.JOB_NUMBER
				WHERE E.EMP_NON_BILL_FLAG = 1
				AND (E.FEE_TIME IS NULL OR E.FEE_TIME = 0)
				GROUP BY J.CL_CODE, J.DIV_CODE, J.PRD_CODE) AS ED ON C.CL_CODE = ED.CL_CODE AND C.DIV_CODE = ED.DIV_CODE AND C.PRD_CODE = ED.PRD_CODE
			LEFT OUTER JOIN
			(SELECT SUM(ISNULL(AP_PROD_EXT_AMT,0) + ISNULL(EXT_NONRESALE_TAX ,0)) AS PRODCHARGES, J.CL_CODE, J.DIV_CODE, J.PRD_CODE
			 FROM dbo.[AP_PRODUCTION] AS P INNER JOIN dbo.[JOB_LOG] AS J ON P.JOB_NUMBER = J.JOB_NUMBER
			 WHERE AP_PROD_NOBILL_FLG=1
			 AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
			 GROUP BY J.CL_CODE, J.DIV_CODE, J.PRD_CODE) AS PROD ON C.CL_CODE = PROD.CL_CODE AND C.DIV_CODE = PROD.DIV_CODE AND C.PRD_CODE = PROD.PRD_CODE

		WHERE
				C.IS_CONTRACT = 0
		AND		C.INACTIVE_FLAG = 0
		AND		(P.INACTIVE IS NULL OR P.INACTIVE = 0)) DETAIL
		
	GROUP BY
		ClientCode,
		ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductName,
		NewBusiness,
		LastActivityDate,
		LastContactDate,
		Probability,
		RatingDescription,
		ContractEndDate,
		DefaultAECode,
		DefaultAEName,
		SoldDate,
		LostDate
GO
