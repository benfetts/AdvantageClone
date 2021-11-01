


/*****************************************************************
Gets All Supervisor EmpCodes for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetSupervisors] 
@USER_ID VarChar(100) 
AS
Declare @Restrictions Int

Set NoCount on

Select @Restrictions = Count(*) 
FROM SEC_EMP
Where UPPER(USER_ID) = UPPER(@USER_ID)

If @Restrictions > 0

	SELECT DISTINCT  SUPERVISOR_CODE as Code, SUPERVISOR_CODE + ' - ' + dbo.udf_get_empl_name(SUPERVISOR_CODE, '') AS Description
	FROM   EMPLOYEE
	Inner JOIN [dbo].[advtf_sec_emp] (@USER_ID) AS SEC_EMP
		On SUPERVISOR_CODE = SEC_EMP.EMP_CODE
	Where EMP_TERM_DATE is NULL
	  AND SUPERVISOR_CODE IS NOT NULL

ELSE
	SELECT DISTINCT  SUPERVISOR_CODE as Code, SUPERVISOR_CODE + ' - ' + dbo.udf_get_empl_name(SUPERVISOR_CODE, '') AS Description
	FROM   EMPLOYEE
	Where EMP_TERM_DATE is NULL
	AND SUPERVISOR_CODE IS NOT NULL



