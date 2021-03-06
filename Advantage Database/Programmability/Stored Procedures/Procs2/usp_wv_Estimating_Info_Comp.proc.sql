






















CREATE PROCEDURE [dbo].[usp_wv_Estimating_Info_Comp] 
@EstNo Int,
@EstComp Int

AS
SELECT     ESTIMATE_LOG.ESTIMATE_NUMBER, ESTIMATE_LOG.EST_LOG_DESC, ESTIMATE_COMPONENT.EST_COMPONENT_NBR, 
                      ESTIMATE_COMPONENT.EST_COMP_DESC, ESTIMATE_LOG.CL_CODE, CLIENT.CL_NAME, ESTIMATE_LOG.DIV_CODE, 
                      DIVISION.DIV_NAME, ESTIMATE_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER, 
                      JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC
FROM         JOB_LOG INNER JOIN
                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER RIGHT OUTER JOIN
                      ESTIMATE_COMPONENT INNER JOIN
                      ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER INNER JOIN
                      PRODUCT ON ESTIMATE_LOG.CL_CODE = PRODUCT.CL_CODE AND ESTIMATE_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
                      ESTIMATE_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE ON 
                      JOB_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER AND 
                      JOB_COMPONENT.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR
WHERE ESTIMATE_LOG.ESTIMATE_NUMBER = @EstNo AND ESTIMATE_COMPONENT.EST_COMPONENT_NBR = @EstComp






















