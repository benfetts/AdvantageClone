CREATE VIEW [dbo].[V_SERVICE_FEE_PRODUCTION_COMM]

AS

	SELECT 
		[ID] = ISNULL(ROW_NUMBER() OVER(ORDER BY (SELECT 1)), 0),
		[JobNumber] = JC.JOB_NUMBER,
		[ComponentNumber] = JC.JOB_COMPONENT_NBR, 
		[ClientCode] = J.CL_CODE,
		[ClientDescription] = C.CL_NAME,
		[DivisionCode] = J.DIV_CODE,
		[DivisionDescription] = D.DIV_NAME,
		[ProductCode] = J.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[SalesClassCode] = J.SC_CODE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[FunctionCode] = AP.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[PostPeriodCode] = AR.AR_POST_PERIOD,
		[ProductionCommissionAmount] = SUM(AP.EXT_MARKUP_AMT),
		[ServiceFeeTypeCode] = SFT.CODE  
	FROM 
		[dbo].[JOB_COMPONENT] AS JC INNER JOIN 
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[AP_PRODUCTION] AS AP ON AP.JOB_NUMBER = JC.JOB_NUMBER AND
									   AP.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
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
		[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID 
	WHERE 
		AP.AP_PROD_NOBILL_FLG <> 1
	GROUP BY 
		JC.JOB_NUMBER,
		JC.JOB_COMPONENT_NBR, 
		J.CL_CODE,
		C.CL_NAME, 
		J.DIV_CODE,
		D.DIV_NAME, 
		J.PRD_CODE, 
		P.PRD_DESCRIPTION,
		J.SC_CODE,
		SC.SC_DESCRIPTION,
		AP.FNC_CODE,
		F.FNC_DESCRIPTION,
		AR.AR_POST_PERIOD,
		SFT.CODE

GO


