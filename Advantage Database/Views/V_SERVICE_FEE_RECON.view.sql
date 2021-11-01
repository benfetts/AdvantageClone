CREATE VIEW [dbo].[V_SERVICE_FEE_RECON]

AS

	SELECT 
		[ID] = ISNULL(ROW_NUMBER() OVER(ORDER BY (SELECT 1)), 0),
		[JobNumber] = SFR.[JobNumber],
		[ClientCode] = SFR.[ClientCode],
		[ClientDescription] = SFR.[ClientDescription],
		[DivisionCode] = SFR.[DivisionCode],
		[DivisionDescription] = SFR.[DivisionDescription],
		[ProductCode] = SFR.[ProductCode],
		[ProductDescription] = SFR.[ProductDescription],
		[CampaignCode] = SFR.[CampaignCode],
		[CampaignName] = SFR.[CampaignName],
		[SalesClassCode] = SFR.[SalesClassCode],
		[SalesClassDescription] = SFR.[SalesClassDescription],
		[JobDescription] = SFR.[JobDescription],
		[ComponentNumber] = SFR.[ComponentNumber],
		[JobComponent] = SFR.[JobComponent],
		[ComponentDescription] = SFR.[ComponentDescription],
		[FunctionCode] = SFR.[FunctionCode],
		[FunctionDescription] = SFR.[FunctionDescription],
		[FunctionType] = SFR.[FunctionType],
		[FunctionOrderNumber] = SFR.[FunctionOrderNumber],
		[FeeQuantity] = SFR.[FeeQuantity],
		[FeeAmount] = SFR.[FeeAmount],
		[ReconciledHours] = SFR.[ReconciledHours],
		[ReconciledAmount] = SFR.[ReconciledAmount],
		[UnreconciledHours] = SFR.[UnreconciledHours],
		[UnreconciledAmount] = SFR.[UnreconciledAmount],
		[TotalHours] = SFR.[TotalHours],
		[TotalAmount] = SFR.[TotalAmount],
		[FeeTimeType] = SFR.[FeeTimeType],
		[IsServiceFeeJob] = ISNULL(CAST(SFR.[IsServiceFeeJob] AS bit), 0),
		[FeeDate] = SFR.[FeeDate],
		[Description] = SFR.[Description],
		[Comment] = SFR.[Comment],
		[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode] = SFR.[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode],
		[JobServiceFeeTypeCode] = SFR.[JobServiceFeeTypeCode],
		[EmployeeDepartmentTeamServiceFeeTypeCode] = SFR.[EmployeeDepartmentTeamServiceFeeTypeCode],
		[Reconcile] = ISNULL(CAST(0 AS bit), 0),
		[MediaType] = SFR.[MediaType], 
		[PostPeriodCode] = SFR.[PostPeriodCode],
		[FunctionHeading] = SFR.[FunctionHeading],
		[FunctionHeadingOrderNumber] = SFR.[FunctionHeadingOrderNumber],
		[FunctionConsolidation] = SFR.[FunctionConsolidation],
		[FunctionConsolidationType] = SFR.[FunctionConsolidationType],
		[FunctionConsolidationOrderNumber] = SFR.[FunctionConsolidationOrderNumber]
	FROM
		(SELECT 
			[JobNumber] = JC.JOB_NUMBER,
			[ClientCode] = J.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = J.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = J.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignCode] = CAMP.CMP_CODE, 
			[CampaignName] = CAMP.CMP_NAME,
			[SalesClassCode] = J.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobDescription] = J.JOB_DESC,
			[ComponentNumber] = JC.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
			[ComponentDescription] = JC.JOB_COMP_DESC, 
			[FunctionCode] = [IO].FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE,
			[FunctionOrderNumber] = F.FNC_ORDER,
			[FeeQuantity] = [IO].IO_QTY,
			[FeeAmount] = [IO].IO_AMOUNT + [IO].EXT_MARKUP_AMT,
			[ReconciledHours] = 0,
			[ReconciledAmount] = 0,
			[UnreconciledHours] = 0,
			[UnreconciledAmount] = 0,
			[TotalHours] = 0,
			[TotalAmount] = 0,
			[FeeTimeType] = 'Standard Billed',
			[IsServiceFeeJob] = JC.SERVICE_FEE_FLAG,
			[FeeDate] = [IO].IO_INV_DATE,
			[Description] = [IO].IO_DESC,
			[Comment] = [IO].IO_COMMENT,
			[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode] = SFT.CODE,
			[JobServiceFeeTypeCode] = SFT.CODE,
			[EmployeeDepartmentTeamServiceFeeTypeCode] = SFT.CODE,
			[MediaType] = NULL, 
			[PostPeriodCode] = AR.AR_POST_PERIOD,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionHeadingOrderNumber] = FH.FNC_HEADING_SEQ,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionConsolidationType] = CF.FNC_TYPE,
			[FunctionConsolidationOrderNumber] = CF.FNC_ORDER
		FROM 
			[dbo].[INCOME_ONLY] AS [IO] LEFT OUTER JOIN 
			[dbo].[ACCT_REC] AS AR ON [IO].AR_INV_NBR = AR.AR_INV_NBR AND 
									  [IO].AR_INV_SEQ = AR.AR_INV_SEQ AND 
									  [IO].AR_TYPE = AR.AR_TYPE INNER JOIN
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR INNER JOIN
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = [IO].JOB_NUMBER INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
									 D.DIV_CODE = J.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
									P.DIV_CODE = J.DIV_CODE AND
									P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = J.CMP_IDENTIFIER INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE LEFT OUTER JOIN
			[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION

		UNION ALL
			
		SELECT 
			[JobNumber] = JC.JOB_NUMBER,
			[ClientCode] = J.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = J.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = J.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignCode] = CAMP.CMP_CODE, 
			[CampaignName] = CAMP.CMP_NAME,
			[SalesClassCode] = J.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobDescription] = J.JOB_DESC,
			[ComponentNumber] = JC.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
			[ComponentDescription] = JC.JOB_COMP_DESC, 
			[FunctionCode] = AP.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE,
			[FunctionOrderNumber] = F.FNC_ORDER,
			[FeeQuantity] = ISNULL(AP.AP_PROD_QUANTITY, 0),
			[FeeAmount] = AP.EXT_MARKUP_AMT,
			[ReconciledHours] = 0,
			[ReconciledAmount] = 0,
			[UnreconciledHours] = 0,
			[UnreconciledAmount] = 0,
			[TotalHours] = 0,
			[TotalAmount] = 0,
			[FeeTimeType] = 'Production Billed',
			[IsServiceFeeJob] = 0,
			[FeeDate] = APH.AP_INV_DATE,
			[Description] = APH.AP_DESC,
			[Comment] = NULL,
			[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode] = SFT.CODE,
			[JobServiceFeeTypeCode] = SFT.CODE,
			[EmployeeDepartmentTeamServiceFeeTypeCode] = SFT.CODE,
			[MediaType] = NULL, 
			[PostPeriodCode] = AR.AR_POST_PERIOD,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionHeadingOrderNumber] = FH.FNC_HEADING_SEQ,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionConsolidationType] = CF.FNC_TYPE,
			[FunctionConsolidationOrderNumber] = CF.FNC_ORDER
		FROM 
			[dbo].[JOB_COMPONENT] AS JC INNER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
			[dbo].[AP_PRODUCTION] AS AP ON AP.JOB_NUMBER = JC.JOB_NUMBER AND
										   AP.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR INNER JOIN 
			[dbo].[AP_HEADER] AS APH ON APH.AP_ID = AP.AP_ID AND 
										APH.AP_SEQ = AP.AP_SEQ LEFT OUTER JOIN 
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = AP.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = AP.AR_INV_SEQ AND 
									  AR.AR_TYPE = AP.AR_TYPE INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
									 D.DIV_CODE = J.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
									P.DIV_CODE = J.DIV_CODE AND
									P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AP.FNC_CODE LEFT OUTER JOIN
			[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = J.CMP_IDENTIFIER LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION
		WHERE 
			AP.AP_PROD_NOBILL_FLG <> 1
			
		UNION ALL
			
		SELECT 
			[JobNumber] = JC.JOB_NUMBER,
			[ClientCode] = AR.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = AR.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = AR.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignCode] = CAMP.CMP_CODE, 
			[CampaignName] = CAMP.CMP_NAME,
			[SalesClassCode] = AR.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobDescription] = CASE WHEN J.JOB_DESC IS NULL THEN 'Media Commissions' ELSE J.JOB_DESC END,
			[ComponentNumber] = JC.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
			[ComponentDescription] = JC.JOB_COMP_DESC, 
			[FunctionCode] = NULL,
			[FunctionDescription] = 'Media Commissions',
			[FunctionType] = NULL,
			[FunctionOrderNumber] = NULL,
			[FeeQuantity] = 0,
			[FeeAmount] = AR.AR_COMM_AMT,
			[ReconciledHours] = 0,
			[ReconciledAmount] = 0,
			[UnreconciledHours] = 0,
			[UnreconciledAmount] = 0,
			[TotalHours] = 0,
			[TotalAmount] = 0,
			[FeeTimeType] = 'Media Billed',
			[IsServiceFeeJob] = 0,
			[FeeDate] = AR.AR_INV_DATE,
			[Description] = 'Media Commissions',
			[Comment] = NULL,
			[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode] = SFT.CODE,
			[JobServiceFeeTypeCode] = SFT.CODE,
			[EmployeeDepartmentTeamServiceFeeTypeCode] = SFT.CODE,
			[MediaType] = AR.REC_TYPE, 
			[PostPeriodCode] = AR.AR_POST_PERIOD,
			[FunctionHeading] = 'Media Commissions',
			[FunctionHeadingOrderNumber] = NULL,
			[FunctionConsolidation] = 'Media Commissions',
			[FunctionConsolidationType] = NULL,
			[FunctionConsolidationOrderNumber] = NULL
		FROM  
			[dbo].[ACCT_REC] AR INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = AR.CL_CODE AND
									 D.DIV_CODE = AR.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = AR.CL_CODE AND
									P.DIV_CODE = AR.DIV_CODE AND
									P.PRD_CODE = AR.PRD_CODE LEFT OUTER JOIN
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = AR.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = AR.JOB_COMPONENT_NBR  LEFT OUTER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_CODE = AR.CMP_CODE
		WHERE 
			(AR.AR_INV_SEQ = 0 OR 
			 AR.AR_INV_SEQ = 99) AND 
			(AR.MANUAL_INV = 0 OR 
			 AR.MANUAL_INV IS NULL)
			 
		UNION ALL
	
		SELECT 
			[JobNumber] = E2.JOB_NUMBER,
			[ClientCode] = E2.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = E2.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = E2.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignCode] = CAMP.CMP_CODE, 
			[CampaignName] = CAMP.CMP_NAME,
			[SalesClassCode] = E2.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobDescription] = E2.JOB_DESC,
			[ComponentNumber] = E2.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), E2.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), E2.JOB_COMPONENT_NBR), 2),
			[ComponentDescription] = E2.JOB_COMP_DESC, 
			[FunctionCode] = E2.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE,
			[FunctionOrderNumber] = F.FNC_ORDER,
			[FeeQuantity] = 0,
			[FeeAmount] = 0,
			[ReconciledHours] = SUM(E2.REC),
			[ReconciledAmount] = SUM(E2.RECTOTAL),
			[UnreconciledHours] = SUM(E2.UNREC),
			[UnreconciledAmount] = SUM(E2.UNRECTOTAL),
			[TotalHours] = SUM(E2.UNREC) + SUM(E2.REC),
			[TotalAmount] = SUM(E2.UNRECTOTAL) + SUM(E2.RECTOTAL),
			[FeeTimeType] = CASE WHEN E2.FEE_TIME = 1 THEN 'Standard' 
								 WHEN E2.FEE_TIME = 2 THEN 'Production' 
								 ELSE 'Media' END,
			[IsServiceFeeJob] = E2.SERVICE_FEE_FLAG,
			[FeeDate] = E2.EMP_DATE,
			[Description] = EMP.EmployeeName,
			[Comment] = E2.EMP_COMMENT,
			[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode] = E2.[ETD_DT_SFT_CODE],
			[JobServiceFeeTypeCode] = E2.[JC_SFT_CODE],
			[EmployeeDepartmentTeamServiceFeeTypeCode] = E2.[E_DT_SFT_CODE],
			[MediaType] = NULL, 
			[PostPeriodCode] = NULL,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionHeadingOrderNumber] = FH.FNC_HEADING_SEQ,
			[FunctionConsolidation] = CF.FNC_DESCRIPTION,
			[FunctionConsolidationType] = CF.FNC_TYPE,
			[FunctionConsolidationOrderNumber] = CF.FNC_ORDER
		FROM
			(SELECT
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				REC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')),      
				RECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')), 	
				UNREC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 	
				UNRECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE]
			FROM
				(SELECT 
					J.CL_CODE, 
					J.DIV_CODE, 
					J.PRD_CODE,  
					JC.JOB_NUMBER,
					J.JOB_DESC,  
					JC.JOB_COMPONENT_NBR,
					JC.JOB_COMP_DESC, 
					J.CMP_IDENTIFIER, 
					J.SC_CODE,
					ETD.FNC_CODE,   
					ETD.FEE_REC_FLAG,  
					ETD.EMP_HOURS,      
					[TOTAL_BILL] = ISNULL(ETD.TOTAL_BILL, 0), 
					[EXT_MARKUP_AMT] = ISNULL(ETD.EXT_MARKUP_AMT, 0), 	
					ETD.FEE_TIME,
					ET.EMP_CODE,
					[EMP_COMMENT] = CAST(ETD.EMP_COMMENT AS varchar(MAX)),
					ET.EMP_DATE,
					[SERVICE_FEE_FLAG] = CAST(ISNULL(JC.SERVICE_FEE_FLAG, 0) AS bit),
					[ETD_DT_SFT_CODE] = ETD_DT.SERVICE_FEE_TYPE_CODE,
					[JC_SFT_CODE] = SFT.CODE,
					[E_DT_SFT_CODE] = E_DT.SERVICE_FEE_TYPE_CODE
				FROM  
					[dbo].[EMP_TIME] AS ET INNER JOIN 
					[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID INNER JOIN 
					[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND 
												   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN 
					[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
					[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS ETD_DT ON ETD_DT.DP_TM_CODE = ETD.DP_TM_CODE LEFT OUTER JOIN 
					[dbo].[EMPLOYEE] AS E ON E.EMP_CODE = ET.EMP_CODE LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS E_DT ON E_DT.DP_TM_CODE = E.DP_TM_CODE
				WHERE 
					ETD.EMP_NON_BILL_FLAG = 1 AND 
					ETD.FEE_TIME IN (1, 2, 3)) AS E
			GROUP BY 
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE]
			HAVING 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0) AS E2 INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = E2.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = E2.CL_CODE AND
									 D.DIV_CODE = E2.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = E2.CL_CODE AND
									P.DIV_CODE = E2.DIV_CODE AND
									P.PRD_CODE = E2.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = E2.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = E2.CMP_IDENTIFIER INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = E2.FNC_CODE LEFT OUTER JOIN 
			[dbo].[advtf_emp_names]() AS EMP ON EMP.EmployeeCode = E2.EMP_CODE LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION 
		GROUP BY
			E2.JOB_NUMBER,
			E2.CL_CODE,
			C.CL_NAME,
			E2.DIV_CODE,
			D.DIV_NAME,
			E2.PRD_CODE,
			P.PRD_DESCRIPTION,
			CAMP.CMP_IDENTIFIER,
			CAMP.CMP_CODE, 
			CAMP.CMP_NAME,
			E2.SC_CODE,
			SC.SC_DESCRIPTION,
			E2.JOB_DESC,
			E2.JOB_COMPONENT_NBR,
			E2.JOB_COMP_DESC, 
			E2.FNC_CODE,
			F.FNC_DESCRIPTION,
			F.FNC_TYPE,
			F.FNC_ORDER,
			E2.FEE_TIME,
			E2.EMP_DATE,
			EMP.EmployeeName,
			E2.EMP_COMMENT,
			E2.SERVICE_FEE_FLAG,
			E2.[ETD_DT_SFT_CODE],
			E2.[JC_SFT_CODE],
			E2.[E_DT_SFT_CODE],
			FH.FNC_HEADING_DESC,
			FH.FNC_HEADING_SEQ,
			CF.FNC_DESCRIPTION,
			CF.FNC_TYPE,
			CF.FNC_ORDER) AS SFR

GO


