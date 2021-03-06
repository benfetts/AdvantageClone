CREATE VIEW [dbo].[V_DRPT_CRM_OPPORTUNITY_DETAIL]

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
		[LastActivityDate] = dbo.[advfn_crm_last_activity_date] (C.CL_CODE, C.DIV_CODE, C.PRD_CODE),
		[LastContactDate] = A.LAST_CONTACT_DATE,
		[Probability] = A.PROBABILITY,
		[RatingDescription] = R.[DESCRIPTION],
		[Code] = C.CONTRACT_CODE,
		[Description] = C.[DESCRIPTION],
		[StartDate] = C.[START_DATE],
		[EndDate] = C.END_DATE,
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
		[dbo].[RATING] AS R ON A.RATING_ID = R.RATING_ID LEFT OUTER JOIN
		[dbo].[ACCOUNT_EXECUTIVE] AE ON C.CL_CODE = AE.CL_CODE AND C.DIV_CODE = AE.DIV_CODE AND C.PRD_CODE = AE.PRD_CODE AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] E ON AE.EMP_CODE = E.EMP_CODE LEFT OUTER JOIN
		(SELECT SUM([HOURS]) AS FEEHOURS, CONTRACT_ID FROM dbo.[CONTRACT_FEES] GROUP BY CONTRACT_ID) FEES ON C.CONTRACT_ID = FEES.CONTRACT_ID 
		
	WHERE
			C.IS_CONTRACT = 0
	AND		C.INACTIVE_FLAG = 0
	AND		(P.INACTIVE IS NULL OR P.INACTIVE = 0)

GO
