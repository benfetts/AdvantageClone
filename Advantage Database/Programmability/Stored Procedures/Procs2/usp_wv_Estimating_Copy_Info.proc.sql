






















CREATE PROCEDURE [dbo].[usp_wv_Estimating_Copy_Info] 
@EstNo Integer
AS
SELECT     ESTIMATE_LOG.ESTIMATE_NUMBER, ESTIMATE_LOG.EST_LOG_DESC, ESTIMATE_COMPONENT.EST_COMPONENT_NBR, 
                      ESTIMATE_COMPONENT.EST_COMP_DESC, JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, 
                      JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ESTIMATE_QUOTE.EST_QUOTE_NBR, 
                      ESTIMATE_QUOTE.EST_QUOTE_DESC, ESTIMATE_LOG.SC_CODE, SALES_CLASS.SC_DESCRIPTION, ESTIMATE_LOG.CL_CODE, 
                      CLIENT.CL_NAME, ESTIMATE_LOG.DIV_CODE, DIVISION.DIV_NAME, ESTIMATE_LOG.PRD_CODE, 
                      PRODUCT.PRD_DESCRIPTION, JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC
FROM         ESTIMATE_QUOTE INNER JOIN
                      ESTIMATE_COMPONENT INNER JOIN
                      ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER ON 
                      ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR LEFT OUTER JOIN
                      JOB_LOG INNER JOIN
                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER ON 
                      ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR INNER JOIN
                      SALES_CLASS ON dbo.ESTIMATE_LOG.SC_CODE = SALES_CLASS.SC_CODE INNER JOIN
					  PRODUCT ON PRODUCT.CL_CODE = dbo.ESTIMATE_LOG.CL_CODE AND PRODUCT.DIV_CODE =ESTIMATE_LOG.DIV_CODE AND 
                      PRODUCT.PRD_CODE = dbo.ESTIMATE_LOG.PRD_CODE INNER JOIN
					  DIVISION ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = dbo.PRODUCT.DIV_CODE INNER JOIN
					  CLIENT ON CLIENT.CL_CODE = DIVISION.CL_CODE LEFT OUTER JOIN JOB_TYPE ON JOB_TYPE.JT_CODE = JOB_COMPONENT.JT_CODE
WHERE ESTIMATE_LOG.ESTIMATE_NUMBER = @EstNo






















