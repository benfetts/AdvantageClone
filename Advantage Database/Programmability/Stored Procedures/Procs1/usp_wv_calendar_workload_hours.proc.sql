

/*****************************************************************
Webvantage
This Stored Procedure gets the total number of employee work hours, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_workload_hours] 
@UserID VarChar(100),
@EmpCode Varchar(6),
@DeptCodes Varchar(4000), 
@ROLES VarChar(8000)

AS
Declare @RestrictionsEmp Int

Set NoCount On

If @DeptCodes IS NULL
	SET @DeptCodes = ''

If @EmpCode IS NULL
	SET @EmpCode = ''

If @ROLES IS NULL
	SET @ROLES = ''

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)


declare @sql varchar(4000)
declare @sql_from varchar(4000)
declare @sql_where varchar(4000)

SELECT @sql = ' SELECT EMPLOYEE.EMP_CODE, ISNULL(MON_HRS, 0.00) AS MON, ISNULL(TUE_HRS, 0.00) AS TUE, ISNULL(WED_HRS, 0.00) AS WED, 
		ISNULL(THU_HRS, 0.00)AS THU, ISNULL(FRI_HRS, 0.00) AS FRI, ISNULL(SAT_HRS, 0.00) AS SAT, ISNULL(SUN_HRS, 0.00) AS SUN '

SELECT @sql_from = 'FROM EMPLOYEE '

SELECT @sql_where = ' WHERE (EMPLOYEE.EMP_TERM_DATE IS NULL) ' 

If @RestrictionsEmp > 0 
    Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE '
    End

If @EmpCode <> '' 
	SELECT @sql_where = @sql_where + ' AND EMPLOYEE.EMP_CODE = ''' + @EmpCode + ''''

If @DeptCodes <> '' 
    Begin
	--SELECT @sql = @sql + ' , EMP_DP_TM.DP_TM_CODE, EMP_DP_TM.DP_TM_DESC '
	
    SELECT @sql_where = @sql_where + ' And EMPLOYEE.DP_TM_CODE IN (' + @DeptCodes + ') '
	
	--SELECT @sql_from = @sql_from + 'INNER JOIN EMP_DP_TM ON EMPLOYEE.EMP_CODE = EMP_DP_TM.EMP_CODE 
	--		JOIN charlist_to_table(' + @DeptCodes + ', DEFAULT) c ON EMP_DP_TM.DP_TM_CODE = c.vstr collate database_default '
    End

If @ROLES <> '' 
    Begin
	SELECT @sql_from = @sql_from + ' LEFT OUTER JOIN EMP_TRAFFIC_ROLE ON EMPLOYEE.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '	

	SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) '
	
    End


SELECT @sql = @sql + @sql_from + @sql_where

EXEC(@sql)

