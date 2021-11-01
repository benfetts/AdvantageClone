﻿

CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetEstimateTasks] 
@EstNo Int,
@EstCompNo Int,
@QuoteNo Int,
@RevNo Int
AS
DECLARE @Restrictions Int,
	@sql nvarchar(4000),
	@paramlist nvarchar(4000)

SELECT @sql = 'SELECT T.FNC_CODE,E.FNC_CODE AS EST_FNC_CODE, T.TRF_CODE, T.TRF_DESC, T.TRF_ORDER, T.TRF_DAYS, ISNULL(T.TRF_HRS,0) AS TRF_HRS, T.MILESTONE, T.DEF_TRF_ROLE,
					  T.DEF_STATUS, FUNCTIONS.FNC_DESCRIPTION, E.EST_FNC_COMMENT, E.EST_REV_SUP_BY_CDE AS EMP_CODE,
					  dbo.udf_get_empl_name(E.EST_REV_SUP_BY_CDE, ''FML'') AS EMP_NAME, 
                      E.EST_REV_SUP_BY_NTE, E.EST_REV_QUANTITY, E.EST_REV_RATE, 
                      E.EST_REV_EXT_AMT, E.TAX_CODE, E.EST_REV_COMM_PCT, E.EXT_MARKUP_AMT, 
                      E.LINE_TOTAL, E.EST_REV_CONT_PCT, E.EXT_CONTINGENCY,
					  ISNULL(E.INCL_CPU,0) AS INCL_CPU, ISNULL(E.TAX_STATE_PCT, 0.00) AS TAX_STATE_PCT, ISNULL(E.TAX_COUNTY_PCT, 0.00) AS TAX_COUNTY_PCT, 
                      ISNULL(E.TAX_CITY_PCT, 0.00) AS TAX_CITY_PCT, E.TAX_COMM, E.TAX_COMM_ONLY, 
                      E.TAX_RESALE, E.EXT_NONRESALE_TAX, ISNULL(E.EXT_STATE_RESALE,0.00) AS EXT_STATE_RESALE, 
                      ISNULL(E.EXT_COUNTY_RESALE,0.00) AS EXT_COUNTY_RESALE, ISNULL(E.EXT_CITY_RESALE,0.00) AS EXT_CITY_RESALE, E.EXT_MU_CONT, 
                      E.EXT_STATE_CONT, E.EXT_COUNTY_CONT, E.EXT_CITY_CONT, 
                      E.EXT_NR_CONT, E.LINE_TOTAL_CONT, E.EST_CPM_FLAG, 
                      E.EST_FNC_TYPE, E.EST_COMM_FLAG, E.EST_TAX_FLAG, 
                      E.EST_NONBILL_FLAG, E.FEE_TIME, E.EMPLOYEE_TITLE_ID, FUNCTIONS.FNC_TYPE,
					  E.EST_PHASE_ID, ISNULL(E.EST_PHASE_DESC, '''') as EST_PHASE_DESC, FNC_HEADING.FNC_HEADING_ID,
					  FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ, ISNULL(FUNCTIONS.FNC_CONSOLIDATION, '''') AS FNC_CONSOLIDATION, ISNULL(F.FNC_DESCRIPTION, '''') AS FNC_CONSOL_DESC,
				      SALES_TAX.TAX_STATE_PERCENT, SALES_TAX.TAX_COUNTY_PERCENT, SALES_TAX.TAX_CITY_PERCENT, ISNULL(EMPLOYEE.EMP_TITLE,'''') AS EMP_TITLE
FROM         ESTIMATE_QUOTE INNER JOIN
                      ESTIMATE_REV ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
                      ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
                      ESTIMATE_QUOTE.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
                      ESTIMATE_COMPONENT ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR INNER JOIN
                      ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER INNER JOIN
                      ESTIMATE_REV_DET E ON ESTIMATE_REV.ESTIMATE_NUMBER = E.ESTIMATE_NUMBER AND 
                      ESTIMATE_REV.EST_COMPONENT_NBR = E.EST_COMPONENT_NBR AND 
                      ESTIMATE_REV.EST_QUOTE_NBR = E.EST_QUOTE_NBR AND 
                      ESTIMATE_REV.EST_REV_NBR = E.EST_REV_NBR INNER JOIN
                      FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
                      JOB_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR LEFT OUTER JOIN
                      FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
                      SALES_TAX ON E.TAX_CODE = SALES_TAX.TAX_CODE LEFT OUTER JOIN
					  FUNCTIONS F ON FUNCTIONS.FNC_CONSOLIDATION = F.FNC_CODE LEFT OUTER JOIN
                      EMPLOYEE ON E.EST_REV_SUP_BY_CDE = EMPLOYEE.EMP_CODE INNER JOIN
                      TRAFFIC_FNC T ON T.FNC_CODE = E.FNC_CODE
WHERE     (ESTIMATE_QUOTE.ESTIMATE_NUMBER = @EstNo) AND (ESTIMATE_QUOTE.EST_COMPONENT_NBR = @EstCompNo) AND 
                      (ESTIMATE_QUOTE.EST_QUOTE_NBR = @QuoteNo) AND (ESTIMATE_REV.EST_REV_NBR = @RevNo) AND (T.TRF_INACTIVE IS NULL OR T.TRF_INACTIVE = 0)'

SELECT @sql = @sql + ' ORDER BY E.FNC_CODE, T.TRF_ORDER'

SELECT @paramlist = '@EstNo int, @EstCompNo int, @QuoteNo int, @RevNo int'
print @sql
EXEC sp_executesql @sql, @paramlist, @EstNo, @EstCompNo, @QuoteNo, @RevNo



















