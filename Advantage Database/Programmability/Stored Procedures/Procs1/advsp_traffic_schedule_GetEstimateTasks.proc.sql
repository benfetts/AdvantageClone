CREATE PROCEDURE [dbo].[advsp_traffic_schedule_GetEstimateTasks]
	@EST_NUMBER INTEGER,
	@EST_COMP_NUMBER INTEGER,
	@QUOTE_NUMBER INTEGER,
	@REVISION_NUMBER INTEGER
AS 
BEGIN

	SELECT	FunctionCode = TRAFFIC_FNC.FNC_CODE,				
			EstimateFunctionCode = ESTIMATE_REV_DET.FNC_CODE, 				
			TaskCode = TRAFFIC_FNC.TRF_CODE, 				
			TaskDescription = TRAFFIC_FNC.TRF_DESC, 				
			TaskOrder = TRAFFIC_FNC.TRF_ORDER, 				
			DaysToComplete = TRAFFIC_FNC.TRF_DAYS, 				
			HoursAllowed = TRAFFIC_FNC.TRF_HRS, 				
			IsMilestone = TRAFFIC_FNC.MILESTONE, 				
			DefaultRole = TRAFFIC_FNC.DEF_TRF_ROLE,				
			DefaultStatus = TRAFFIC_FNC.DEF_STATUS, 				
			FunctionDescription = FUNCTIONS.FNC_DESCRIPTION, 				
			EstimateFunctionComment = ESTIMATE_REV_DET.EST_FNC_COMMENT, 				
			EmployeeCode = ESTIMATE_REV_DET.EST_REV_SUP_BY_CDE,				
			EmployeeName = dbo.udf_get_empl_name(ESTIMATE_REV_DET.EST_REV_SUP_BY_CDE, 'FML'),		
			EstimateRevisionSuppliedByCode = ESTIMATE_REV_DET.EST_REV_SUP_BY_NTE, 				
			EstimateRevisionQuantity = ESTIMATE_REV_DET.EST_REV_QUANTITY, 				
			EstimateRevisionRate = ESTIMATE_REV_DET.EST_REV_RATE,				
			EstimateRevisionExtendedAmount = ESTIMATE_REV_DET.EST_REV_EXT_AMT,				
			TaxCode = ESTIMATE_REV_DET.TAX_CODE, 				
			EstimateRevisionCommissionPercent = ESTIMATE_REV_DET.EST_REV_COMM_PCT, 				
			ExtendedMarkupAmount = ESTIMATE_REV_DET.EXT_MARKUP_AMT,				
			LineTotal = ESTIMATE_REV_DET.LINE_TOTAL, 				
			EstimateRevisionContingencyPercent = ESTIMATE_REV_DET.EST_REV_CONT_PCT, 				
			ExtendedContingency = ESTIMATE_REV_DET.EXT_CONTINGENCY,				
			IncludeCPU = ISNULL(ESTIMATE_REV_DET.INCL_CPU,0), 				
			TaxStatePercent = ISNULL(ESTIMATE_REV_DET.TAX_STATE_PCT, 0.00), 		
			TaxCountyPercent = ISNULL(ESTIMATE_REV_DET.TAX_COUNTY_PCT, 0.00),		
			TaxCityPercent = ISNULL(ESTIMATE_REV_DET.TAX_CITY_PCT, 0.00), 		
			TaxCommission = ESTIMATE_REV_DET.TAX_COMM, 				
			TaxCommissionOnly = ESTIMATE_REV_DET.TAX_COMM_ONLY,				
			TaxReslae = ESTIMATE_REV_DET.TAX_RESALE, 				
			ExtendedNonresaleTax = ESTIMATE_REV_DET.EXT_NONRESALE_TAX, 				
			ExtendedStateResale = ISNULL(ESTIMATE_REV_DET.EXT_STATE_RESALE,0.00), 		
			ExtendedCountyResale = ISNULL(ESTIMATE_REV_DET.EXT_COUNTY_RESALE,0.00), 		
			ExtendedCityResale = ISNULL(ESTIMATE_REV_DET.EXT_CITY_RESALE,0.00), 		
			ExtendedMarkupContingency = ESTIMATE_REV_DET.EXT_MU_CONT,				
			ExtendedStateContingency = ESTIMATE_REV_DET.EXT_STATE_CONT, 				
			ExtendedCountyContingency = ESTIMATE_REV_DET.EXT_COUNTY_CONT, 				
			ExtendedCityContingency = ESTIMATE_REV_DET.EXT_CITY_CONT, 				
			ExtendedNonresaleContingency = ESTIMATE_REV_DET.EXT_NR_CONT, 				
			LineTotalContingency = ESTIMATE_REV_DET.LINE_TOTAL_CONT, 				
			EstimateCPMFlag = ESTIMATE_REV_DET.EST_CPM_FLAG, 				
			EstimateFunctionType = ESTIMATE_REV_DET.EST_FNC_TYPE, 				
			EstimateCommissionFlag = ESTIMATE_REV_DET.EST_COMM_FLAG, 				
			EstimateTaxFlag = ESTIMATE_REV_DET.EST_TAX_FLAG, 				
			EstimateNonbillFlag = ESTIMATE_REV_DET.EST_NONBILL_FLAG, 				
			FeeTime = ESTIMATE_REV_DET.FEE_TIME, 				
			EmployeeTitleID = ESTIMATE_REV_DET.EMPLOYEE_TITLE_ID, 				
			FunctionType = FUNCTIONS.FNC_TYPE,				
			EstimatePhaseID = ESTIMATE_REV_DET.EST_PHASE_ID, 				
			EstimatePhaseDescription = ISNULL(ESTIMATE_REV_DET.EST_PHASE_DESC, ''), 				
			FunctionHeadingID = FNC_HEADING.FNC_HEADING_ID,				
			FunctionHeadingDescription = FNC_HEADING.FNC_HEADING_DESC, 				
			FunctionHeadingSequence = FNC_HEADING.FNC_HEADING_SEQ, 				
			FunctionConsolidation = ISNULL(FUNCTIONS.FNC_CONSOLIDATION, ''), 				
			FunctionConsolodationDescription = ISNULL(FUNCTIONS_2.FNC_DESCRIPTION, ''),				
			TaxStatePercent = SALES_TAX.TAX_STATE_PERCENT, 				
			TaxCountyPercent = SALES_TAX.TAX_COUNTY_PERCENT, 				
			TaxCityPercent = SALES_TAX.TAX_CITY_PERCENT, 				
			EmployeeTitle = ISNULL(EMPLOYEE.EMP_TITLE,'')				
	FROM dbo.ESTIMATE_QUOTE INNER JOIN
		 dbo.ESTIMATE_REV ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
							 ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
							 ESTIMATE_QUOTE.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
		dbo.ESTIMATE_COMPONENT ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER AND 
								  ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR INNER JOIN
		dbo.ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER INNER JOIN
		dbo.ESTIMATE_REV_DET ON ESTIMATE_REV.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER AND 
								ESTIMATE_REV.EST_COMPONENT_NBR = ESTIMATE_REV_DET.EST_COMPONENT_NBR AND 
								ESTIMATE_REV.EST_QUOTE_NBR = ESTIMATE_REV_DET.EST_QUOTE_NBR AND 
								ESTIMATE_REV.EST_REV_NBR = ESTIMATE_REV_DET.EST_REV_NBR INNER JOIN
		dbo.FUNCTIONS ON ESTIMATE_REV_DET.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
		dbo.JOB_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
						 ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR LEFT OUTER JOIN
		dbo.FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
		dbo.SALES_TAX ON ESTIMATE_REV_DET.TAX_CODE = SALES_TAX.TAX_CODE LEFT OUTER JOIN
		dbo.FUNCTIONS FUNCTIONS_2 ON FUNCTIONS.FNC_CONSOLIDATION = FUNCTIONS_2.FNC_CODE LEFT OUTER JOIN
		dbo.EMPLOYEE ON ESTIMATE_REV_DET.EST_REV_SUP_BY_CDE = EMPLOYEE.EMP_CODE INNER JOIN
		dbo.TRAFFIC_FNC ON TRAFFIC_FNC.FNC_CODE = ESTIMATE_REV_DET.FNC_CODE
	WHERE (ESTIMATE_QUOTE.ESTIMATE_NUMBER = @EST_NUMBER) AND (ESTIMATE_QUOTE.EST_COMPONENT_NBR = @EST_COMP_NUMBER) AND 
		  (ESTIMATE_QUOTE.EST_QUOTE_NBR = @QUOTE_NUMBER) AND (ESTIMATE_REV.EST_REV_NBR = @REVISION_NUMBER) AND 
		  (TRAFFIC_FNC.TRF_INACTIVE IS NULL OR TRAFFIC_FNC.TRF_INACTIVE = 0)
	ORDER BY ESTIMATE_REV_DET.FNC_CODE, TRAFFIC_FNC.TRF_ORDER

END