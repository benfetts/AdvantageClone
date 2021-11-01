﻿
CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobsSoftwareVersion] /*WITH ENCRYPTION*/
@UserID      VARCHAR(100),
@VERSION_ID  INT
AS
/*=========== QUERY ===========*/
DECLARE @Restrictions INT
	
SET NOCOUNT ON
	
SELECT @Restrictions = COUNT(*)
FROM   SEC_CLIENT WITH(NOLOCK)
WHERE  UPPER(USER_ID) = UPPER(@UserID);

DECLARE @OfficeRestrictions AS INTEGER	
DECLARE @EMP_CODE AS varchar(6)

SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

IF @Restrictions > 0
Begin
	if @OfficeRestrictions > 0
	Begin
		SELECT JOB_LOG.JOB_NUMBER AS code,
			   LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') AS DESCRIPTION,
			   JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE AS CDP,
			   JOB_LOG.JOB_NUMBER,
			   0 AS JOB_COMPONENT_NBR,
			   (
				   SELECT COUNT(1)
				   FROM   SOFTWARE_LEVEL WITH (NOLOCK)
				   WHERE  (JOB_NUMBER = JOB_LOG.JOB_NUMBER)
						  AND (JOB_COMPONENT_NBR IS NULL)
						  AND SOFTWARE_LEVEL.VERSION_ID = @VERSION_ID
			   ) AS ACTIVE_ON_THIS_VERSION
		FROM   JOB_LOG WITH (NOLOCK)
			   INNER JOIN SEC_CLIENT WITH (NOLOCK)
					ON  JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE
					AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE
					AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
				 INNER JOIN
						EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		WHERE  (JOB_LOG.COMP_OPEN = 1)
			   AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
			   AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		GROUP BY
			   JOB_LOG.JOB_NUMBER,
			   JOB_LOG.JOB_DESC,
			   SEC_CLIENT.USER_ID,
			   JOB_LOG.CL_CODE,
			   JOB_LOG.DIV_CODE,
			   JOB_LOG.PRD_CODE
		ORDER BY
			   code DESC
	End
	Else
	Begin
		SELECT JOB_LOG.JOB_NUMBER AS code,
			   LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') AS DESCRIPTION,
			   JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE AS CDP,
			   JOB_LOG.JOB_NUMBER,
			   0 AS JOB_COMPONENT_NBR,
			   (
				   SELECT COUNT(1)
				   FROM   SOFTWARE_LEVEL WITH (NOLOCK)
				   WHERE  (JOB_NUMBER = JOB_LOG.JOB_NUMBER)
						  AND (JOB_COMPONENT_NBR IS NULL)
						  AND SOFTWARE_LEVEL.VERSION_ID = @VERSION_ID
			   ) AS ACTIVE_ON_THIS_VERSION
		FROM   JOB_LOG WITH (NOLOCK)
			   INNER JOIN SEC_CLIENT WITH (NOLOCK)
					ON  JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE
					AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE
					AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
		WHERE  (JOB_LOG.COMP_OPEN = 1)
			   AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
			   AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		GROUP BY
			   JOB_LOG.JOB_NUMBER,
			   JOB_LOG.JOB_DESC,
			   SEC_CLIENT.USER_ID,
			   JOB_LOG.CL_CODE,
			   JOB_LOG.DIV_CODE,
			   JOB_LOG.PRD_CODE
		ORDER BY
			   code DESC
	End
    
End
ELSE
Begin
	if @OfficeRestrictions > 0
	Begin
		SELECT JOB_LOG.JOB_NUMBER AS code,
			   LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') AS DESCRIPTION,
			   JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE AS CDP,
			   JOB_LOG.JOB_NUMBER,
			   0 AS JOB_COMPONENT_NBR,
			   (
				   SELECT COUNT(1)
				   FROM   SOFTWARE_LEVEL WITH (NOLOCK)
				   WHERE  SOFTWARE_LEVEL.JOB_NUMBER = JOB_LOG.JOB_NUMBER
						  AND (SOFTWARE_LEVEL.JOB_COMPONENT_NBR IS NULL)
						  AND SOFTWARE_LEVEL.VERSION_ID = @VERSION_ID
			   ) AS ACTIVE_ON_THIS_VERSION
		FROM   JOB_LOG WITH (NOLOCK)
				 INNER JOIN
						EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		WHERE  (JOB_LOG.COMP_OPEN = 1)
		ORDER BY
			   code DESC
	End
	Else
	Begin
		SELECT JOB_LOG.JOB_NUMBER AS code,
			   LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') AS DESCRIPTION,
			   JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE AS CDP,
			   JOB_LOG.JOB_NUMBER,
			   0 AS JOB_COMPONENT_NBR,
			   (
				   SELECT COUNT(1)
				   FROM   SOFTWARE_LEVEL WITH (NOLOCK)
				   WHERE  SOFTWARE_LEVEL.JOB_NUMBER = JOB_LOG.JOB_NUMBER
						  AND (SOFTWARE_LEVEL.JOB_COMPONENT_NBR IS NULL)
						  AND SOFTWARE_LEVEL.VERSION_ID = @VERSION_ID
			   ) AS ACTIVE_ON_THIS_VERSION
		FROM   JOB_LOG WITH (NOLOCK)
		WHERE  (JOB_LOG.COMP_OPEN = 1)
		ORDER BY
			   code DESC
	End
    
End          
/*=========== QUERY ===========*/
