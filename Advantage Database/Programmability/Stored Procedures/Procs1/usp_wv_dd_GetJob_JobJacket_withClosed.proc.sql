
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetJob_JobJacket_withClosed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetJob_JobJacket_withClosed]
GO


/* CHANGE LOG:
==========================================================
ST, 20060613:
	Following the pattern I see last dev was taking.
	This is a duplicate of the sproc with the same name except "timesheet" instead of "JobJacket" in the sproc name
	sproc's created to filter job lookup on jobjacket
	did not modify base sproc's; duplicated and changed name instead;still fearful of breaking something somewhere else
AC, 20160301
	Added Office security
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetJob_JobJacket_withClosed]
@UserID VarChar(100),
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6),
@OfficeCode VarChar(4),
@SalesClass VarChar(6),
@CP int,
@CPID int
AS
Declare @Restrictions Int
Declare @RestrictionsCP Int

Set NoCount On

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT @RestrictionsCP = COUNT(*)
 FROM CP_SEC_CLIENT 
 WHERE CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID


If @CP = 1
Begin
If @RestrictionsCP > 0
	SELECT DISTINCT
		JOB_LOG.JOB_NUMBER AS Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
		+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
	FROM         JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
	WHERE     -- (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) AND 
	 CP_SEC_CLIENT.CDP_CONTACT_ID = UPPER(@CPID)
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	AND  (JOB_LOG.CL_CODE Like @ClientCode) 
	AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
	AND (JOB_LOG.PRD_CODE Like @ProductCode)
	AND (JOB_LOG.OFFICE_CODE Like @OfficeCode)
	AND (JOB_LOG.SC_CODE Like @SalesClass)
	GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, CP_SEC_CLIENT.CDP_CONTACT_ID, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC
ELSE
	SELECT DISTINCT 
		JOB_LOG.JOB_NUMBER AS Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
		+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
	FROM         JOB_LOG 
			 INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
	WHERE     --(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	 --AND
	(JOB_LOG.CL_CODE Like @ClientCode) 
	AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
	AND (JOB_LOG.PRD_CODE Like @ProductCode)
	AND (JOB_LOG.OFFICE_CODE Like @OfficeCode)
	AND (JOB_LOG.SC_CODE Like @SalesClass)
	ORDER BY JOB_LOG.JOB_NUMBER DESC
End
Else
Begin
If @Restrictions > 0	
	IF @OfficeCount = 0
		Begin
			SELECT DISTINCT
				JOB_LOG.JOB_NUMBER AS Code, 
				STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
				+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
			FROM         JOB_LOG INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
								  SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
								  JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
			WHERE     -- (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) AND 
			(UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
			--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
			AND  (JOB_LOG.CL_CODE Like @ClientCode) 
			AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
			AND (JOB_LOG.PRD_CODE Like @ProductCode)
			AND (JOB_LOG.OFFICE_CODE Like @OfficeCode)
			AND (JOB_LOG.SC_CODE Like @SalesClass)
			GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, SEC_CLIENT.USER_ID, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
			ORDER BY JOB_LOG.JOB_NUMBER DESC
		End
	Else
		Begin
			SELECT DISTINCT
				JOB_LOG.JOB_NUMBER AS Code, 
				STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
				+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
			FROM         JOB_LOG INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
								  SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
								  JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
								  INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
									AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			WHERE     -- (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) AND 
			(UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
			--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
			AND  (JOB_LOG.CL_CODE Like @ClientCode) 
			AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
			AND (JOB_LOG.PRD_CODE Like @ProductCode)
			AND (JOB_LOG.OFFICE_CODE Like @OfficeCode)
			AND (JOB_LOG.SC_CODE Like @SalesClass)
			GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, SEC_CLIENT.USER_ID, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
			ORDER BY JOB_LOG.JOB_NUMBER DESC
		End		
	
ELSE	
	IF @OfficeCount = 0
		Begin
			SELECT DISTINCT 
				JOB_LOG.JOB_NUMBER AS Code, 
				STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
				+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
			FROM         JOB_LOG 
					 INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
			WHERE     --(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
			--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
			 --AND
			(JOB_LOG.CL_CODE Like @ClientCode) 
			AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
			AND (JOB_LOG.PRD_CODE Like @ProductCode)
			AND (JOB_LOG.OFFICE_CODE Like @OfficeCode)
			AND (JOB_LOG.SC_CODE Like @SalesClass)
			ORDER BY JOB_LOG.JOB_NUMBER DESC
		End
	Else
		Begin
			SELECT DISTINCT 
				JOB_LOG.JOB_NUMBER AS Code, 
				STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
				+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
			FROM         JOB_LOG 
					 INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
					 INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
									AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
			WHERE     --(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
			--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
			 --AND
			(JOB_LOG.CL_CODE Like @ClientCode) 
			AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
			AND (JOB_LOG.PRD_CODE Like @ProductCode)
			AND (JOB_LOG.OFFICE_CODE Like @OfficeCode)
			AND (JOB_LOG.SC_CODE Like @SalesClass)		
			ORDER BY JOB_LOG.JOB_NUMBER DESC
					
		End		
	
End


















