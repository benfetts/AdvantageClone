﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetJobCompEstimateAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetJobCompEstimateAll]
GO



CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobCompEstimateAll] 
@UserID VARCHAR(100)
AS
DECLARE 
@Restrictions INT

SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

IF @Restrictions > 0 
    BEGIN
		If @OfficeCount = 0
		Begin
			SELECT     RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) AS Code, 
                      RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) 
                      + ' | ' + REPLACE(JOB_COMPONENT.JOB_COMP_DESC,'''','') + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE
                       AS Description
			FROM         JOB_LOG INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
								  SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
								  JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
			WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12))  AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND JOB_COMPONENT.ESTIMATE_NUMBER IS NOT NULL
			--AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
			ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
		End
		Else
		Begin
			SELECT     RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) AS Code, 
                      RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) 
                      + ' | ' + REPLACE(JOB_COMPONENT.JOB_COMP_DESC,'''','') + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE
                       AS Description
			FROM         JOB_LOG INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
								  SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
								  JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
							INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12))  AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND JOB_COMPONENT.ESTIMATE_NUMBER IS NOT NULL
			--AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
			ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
		End
    END
ELSE
    BEGIN
		If @OfficeCount = 0
		Begin
			SELECT     RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) AS Code, 
                      RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) 
                      + ' | ' + REPLACE(JOB_COMPONENT.JOB_COMP_DESC,'''','') + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE
                       AS Description
			FROM         JOB_LOG INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
			WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND JOB_COMPONENT.ESTIMATE_NUMBER IS NOT NULL  --AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
			ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
		End
		Else
		Begin
			SELECT     RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) AS Code, 
                      RTRIM(LTRIM(STR(JOB_LOG.JOB_NUMBER))) + '-' + RTRIM(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))) 
                      + ' | ' + REPLACE(JOB_COMPONENT.JOB_COMP_DESC,'''','') + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE
                       AS Description
			FROM         JOB_LOG INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
							INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND JOB_COMPONENT.ESTIMATE_NUMBER IS NOT NULL  --AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
			ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
		End

    END
























