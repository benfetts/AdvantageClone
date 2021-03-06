






















/* CHANGE LOG:
==========================================================
BJL, 20060502:
	Added ORDER BY clauses
*/



CREATE PROCEDURE [dbo].[usp_wv_dd_GetJob] 
@UserID VarChar(100),
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	SELECT     JOB_LOG.JOB_NUMBER AS Code, STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') AS Description
	FROM         JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	AND  (JOB_LOG.CL_CODE Like @ClientCode) 
	AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
	AND (JOB_LOG.PRD_CODE Like @ProductCode)
	GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, SEC_CLIENT.USER_ID
	ORDER BY JOB_LOG.JOB_NUMBER DESC
ELSE
	SELECT     JOB_LOG.JOB_NUMBER as Code, str(JOB_LOG.JOB_NUMBER) + ' - ' + isnull(JOB_LOG.JOB_DESC, '') as Description
	FROM         JOB_LOG 
			 INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
	WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,6,9,10,12,13)) 
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	AND(JOB_LOG.CL_CODE Like @ClientCode) 
	AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
	AND (JOB_LOG.PRD_CODE Like @ProductCode)
	ORDER BY JOB_LOG.JOB_NUMBER DESC


















