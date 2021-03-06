CREATE VIEW [dbo].[V_ESTIMATE_FUNCTION_COMMENT]
WITH SCHEMABINDING
AS

	SELECT 
		[EstimateNumber] = EL.ESTIMATE_NUMBER,
		[EstimateDesc] = EL.EST_LOG_DESC,
		[EstimateComponentNumber] = EC.EST_COMPONENT_NBR,
		[EstimateCompDesc] = EC.EST_COMP_DESC,
		[QuoteNumber] = EQ.EST_QUOTE_NBR,
		[QuoteDesc] = EQ.EST_QUOTE_DESC,
		[RevisionNumber] = ED.EST_REV_NBR,
		[FunctionCode] = ED.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[Comment] = ED.EST_FNC_COMMENT,
		[SuppliedByNotes] = ED.EST_REV_SUP_BY_NTE
	FROM 
		[dbo].ESTIMATE_COMPONENT EC INNER JOIN
		[dbo].ESTIMATE_LOG EL ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN
		[dbo].ESTIMATE_QUOTE EQ ON EC.ESTIMATE_NUMBER = EQ.ESTIMATE_NUMBER AND 
		EC.EST_COMPONENT_NBR = EQ.EST_COMPONENT_NBR INNER JOIN
		[dbo].ESTIMATE_REV_DET ED ON ED.ESTIMATE_NUMBER = EQ.ESTIMATE_NUMBER AND 
		ED.EST_COMPONENT_NBR = EQ.EST_COMPONENT_NBR AND
		ED.EST_QUOTE_NBR = EQ.EST_QUOTE_NBR LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ED.FNC_CODE  LEFT OUTER JOIN
	    [dbo].JOB_COMPONENT JC ON JC.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR AND JC.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER
	WHERE 
		(JC.[JOB_PROCESS_CONTRL] NOT IN (6,12) OR JC.ESTIMATE_NUMBER IS NULL)
	
GO


