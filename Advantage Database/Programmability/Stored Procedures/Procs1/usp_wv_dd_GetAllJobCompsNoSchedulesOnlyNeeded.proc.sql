


CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobCompsNoSchedulesOnlyNeeded] 
@UserID VarChar(100),
@CL_CODE VARCHAR(6),
@DIV_CODE VARCHAR(6),
@PRD_CODE VARCHAR(6),
@JOB_NUMBER INT
AS
Declare @Rescrictions Int

CREATE TABLE #jobcomp(
	RowID int IDENTITY(1, 1), 
	Code varchar(1000),
	Description varchar(1000),
	job int,
	comp int)

Set NoCount On

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

IF @JOB_NUMBER = 0
    BEGIN
        IF @Rescrictions > 0
			INSERT INTO #jobcomp
            SELECT     Code, REPLACE(Description,'''','') AS Description, job, comp
            FROM         (SELECT     TOP 100 PERCENT LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code, 
                                                          LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description, JOB_LOG.JOB_NUMBER as job, JOB_COMPONENT.JOB_COMPONENT_NBR as comp
                                   FROM          JOB_LOG INNER JOIN
                                                          JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                                                          SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                                                          JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
                                   WHERE      (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2, 3, 5, 6, 9, 10, 12, 13)) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
                                                      AND (JOB_COMPONENT.TRF_SCHEDULE_REQ = 1)
                                                      AND (JOB_LOG.CL_CODE LIKE @CL_CODE+'%')
                                                      AND (JOB_LOG.DIV_CODE LIKE @DIV_CODE+'%')
                                                      AND (JOB_LOG.PRD_CODE LIKE @PRD_CODE+'%')
                                 ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC) AS A
            --WHERE     (Code NOT IN
            --                          (SELECT     LTRIM(STR(JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT_NBR)) AS Code
            --                            FROM          JOB_TRAFFIC))
        ELSE
			INSERT INTO #jobcomp
            SELECT     Code, REPLACE(Description,'''','') AS Description, job, comp
            FROM         (SELECT     TOP 100 PERCENT LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code, 
                                                          LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description, JOB_LOG.JOB_NUMBER as job, JOB_COMPONENT.JOB_COMPONENT_NBR as comp
                                   FROM          JOB_LOG INNER JOIN
                                                          JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                                   WHERE      (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2, 3, 5, 6, 9, 10, 12, 13))
                                                    AND (JOB_COMPONENT.TRF_SCHEDULE_REQ = 1)
                                                      AND (JOB_LOG.CL_CODE LIKE @CL_CODE+'%')
                                                      AND (JOB_LOG.DIV_CODE LIKE @DIV_CODE+'%')
                                                      AND (JOB_LOG.PRD_CODE LIKE @PRD_CODE+'%')
                                   ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC) AS A
            --WHERE     (Code NOT IN
            --                          (SELECT     LTRIM(STR(JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT_NBR)) AS Code
            --                            FROM          JOB_TRAFFIC))
    END
ELSE
    BEGIN
        IF @Rescrictions > 0
			INSERT INTO #jobcomp
            SELECT     Code, REPLACE(Description,'''','') AS Description, job, comp
            FROM         (SELECT     TOP 100 PERCENT LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code, 
                                                          LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description, JOB_LOG.JOB_NUMBER as job, JOB_COMPONENT.JOB_COMPONENT_NBR as comp
                                   FROM          JOB_LOG INNER JOIN
                                                          JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                                                          SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                                                          JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
                                   WHERE      (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2, 3, 5, 6, 9, 10, 12, 13)) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
                                                      AND (JOB_COMPONENT.TRF_SCHEDULE_REQ = 1) AND JOB_LOG.JOB_NUMBER = @JOB_NUMBER
                                                                              AND (JOB_LOG.CL_CODE LIKE @CL_CODE+'%')
                                                      AND (JOB_LOG.DIV_CODE LIKE @DIV_CODE+'%')
                                                      AND (JOB_LOG.PRD_CODE LIKE @PRD_CODE+'%')
         ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR DESC) AS A
            --WHERE     (Code NOT IN
            --                          (SELECT     LTRIM(STR(JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT_NBR)) AS Code
            --                            FROM          JOB_TRAFFIC))
        ELSE
			INSERT INTO #jobcomp
            SELECT     Code, REPLACE(Description,'''','') AS Description, job, comp
            FROM         (SELECT     TOP 100 PERCENT LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code, 
                                                          LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description, JOB_LOG.JOB_NUMBER as job, JOB_COMPONENT.JOB_COMPONENT_NBR as comp
                                   FROM          JOB_LOG INNER JOIN
                                                          JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                                   WHERE      (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2, 3, 5, 6, 9, 10, 12, 13))
                                                    AND (JOB_COMPONENT.TRF_SCHEDULE_REQ = 1) AND JOB_LOG.JOB_NUMBER = @JOB_NUMBER
                                                                  AND (JOB_LOG.CL_CODE LIKE @CL_CODE+'%')
                                                      AND (JOB_LOG.DIV_CODE LIKE @DIV_CODE+'%')
                                                      AND (JOB_LOG.PRD_CODE LIKE @PRD_CODE+'%')
                       ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR DESC) AS A
            --WHERE     (Code NOT IN
            --                          (SELECT     LTRIM(STR(JOB_NUMBER)) + '-' + LTRIM(STR(JOB_COMPONENT_NBR)) AS Code
            --                            FROM          JOB_TRAFFIC))
    END


SELECT #jobcomp.Code, #jobcomp.Description 
FROM #jobcomp LEFT OUTER JOIN JOB_TRAFFIC WITH(NOLOCK) ON #jobcomp.job = JOB_TRAFFIC.JOB_NUMBER AND #jobcomp.comp = JOB_TRAFFIC.JOB_COMPONENT_NBR
WHERE JOB_TRAFFIC.JOB_NUMBER IS NULL AND JOB_TRAFFIC.JOB_COMPONENT_NBR IS NULL
GROUP BY #jobcomp.Code, #jobcomp.Description, #jobcomp.job, #jobcomp.comp
ORDER BY #jobcomp.job DESC, #jobcomp.comp ASC




drop table #jobcomp






