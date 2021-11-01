

















CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobCompEstimateCDP] 
@UserID VARCHAR(100),
@ClientCode VARCHAR(6) = '%', 
@DivisionCode VARCHAR(6) = '%', 
@ProductCode VARCHAR(6) = '%'
AS
DECLARE 
@Restrictions INT

SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

    IF @Restrictions > 0 
        BEGIN
                SELECT     RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) AS Code, 
                                      RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) 
                                      + ' | ' + REPLACE(JOB_COMPONENT.JOB_COMP_DESC,'''','') + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE
                                       AS Description
                        FROM         JOB_LOG INNER JOIN
                                              JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                                              SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                                              JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
                        WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_LOG.CL_CODE LIKE @ClientCode +'%') AND (JOB_LOG.DIV_CODE LIKE @DivisionCode+'%') AND 
                                              (JOB_LOG.PRD_CODE LIKE @ProductCode+'%')  AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND JOB_COMPONENT.ESTIMATE_NUMBER IS NOT NULL 
                                              --AND 
                                             -- (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
                        ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
        END
    ELSE
        BEGIN
                SELECT     RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) AS Code, 
                                      RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) 
                                      + ' | ' + REPLACE(JOB_COMPONENT.JOB_COMP_DESC,'''','') + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE
                                       AS Description

                        FROM         JOB_LOG INNER JOIN
                                              JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                        WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_LOG.CL_CODE LIKE @ClientCode +'%') AND (JOB_LOG.DIV_CODE LIKE @DivisionCode+'%') AND 
                                              (JOB_LOG.PRD_CODE LIKE @ProductCode+'%') AND JOB_COMPONENT.ESTIMATE_NUMBER IS NOT NULL  --AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
                        ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
        END



























