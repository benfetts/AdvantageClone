/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetEmpCodesByRole]    Script Date: 12/9/2020 5:09:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




/*****************************************************************
Gets All EmpCodes, for a specific ROLE, for Drop Downs
exec usp_wv_dd_GetEmpCodesByRole 'ama',null,'estimate'
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetEmpCodesByRole] 
@UserID VarChar(100), 
@Role	VarChar(6),
@TaskCode VARCHAR(16) = null
AS
Declare @Restrictions Int

Set NoCount on

Select @Restrictions = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)

print @TaskCode

If @Restrictions > 0
BEGIN
	SELECT *
		INTO #Temp
		FROM (SELECT DISTINCT EMPLOYEE.EMP_CODE as Code,
					  EMPLOYEE.EMP_CODE + ' - ' + isnull(EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_CODE) + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') AS Description
					  ,EMPLOYEE.EMP_LNAME LastName
					  ,EMPLOYEE.EMP_MI MiddleInitial
					  ,EMPLOYEE.EMP_FNAME FirstName
					  ,EMPLOYEE.EMP_TITLE Title
			FROM         EMPLOYEE
				Inner JOIN [dbo].[advtf_sec_emp] (@UserID) AS SEC_EMP
				On EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE
				Inner JOIN (SELECT [EMP_CODE] ,[ROLE_CODE]
								FROM [EMP_TRAFFIC_ROLE]
								WHERE [ROLE_CODE] in (select ROLE_CODE from [dbo].[TASK_TRAFFIC_ROLE] where TRF_CODE = @TaskCode)
						union
							select [EMP_CODE],[ROLE_CODE] from EMP_TRAFFIC_ROLE WHERE ROLE_CODE = @Role) _ROLE
					ON EMPLOYEE.EMP_CODE = _ROLE.EMP_CODE
			Where (EMP_TERM_DATE IS NULL OR EMP_TERM_DATE > GETDATE())
			--AND EMP_TRAFFIC_ROLE.ROLE_CODE = @Role
			) a

			--Order By isnull(EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_CODE)

			select * from #Temp order by isnull(LastName,Code)
END
ELSE
BEGIN
	SELECT *
		INTO #Temp1
		FROM (SELECT DISTINCT   EMPLOYEE.EMP_CODE as Code,
		EMPLOYEE.EMP_CODE + ' - ' + isnull(EMP_LNAME, EMPLOYEE.EMP_CODE) + ', ' + isnull(EMP_FNAME, '') AS Description
		,EMPLOYEE.EMP_LNAME LastName
		,EMPLOYEE.EMP_MI MiddleInitial
		,EMPLOYEE.EMP_FNAME FirstName
		,EMPLOYEE.EMP_TITLE Title
	FROM   EMPLOYEE
		Inner JOIN (SELECT [EMP_CODE] ,[ROLE_CODE]
						FROM [EMP_TRAFFIC_ROLE]
						WHERE [ROLE_CODE] in (select ROLE_CODE from [dbo].[TASK_TRAFFIC_ROLE] where TRF_CODE = @TaskCode)
				union
					select [EMP_CODE],[ROLE_CODE] from EMP_TRAFFIC_ROLE WHERE ROLE_CODE = @Role) _ROLE
			ON EMPLOYEE.EMP_CODE = _ROLE.EMP_CODE			Where (EMP_TERM_DATE IS NULL OR EMP_TERM_DATE > GETDATE())
			 --AND EMPLOYEE.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
			--AND EMP_TRAFFIC_ROLE.ROLE_CODE = @Role
			) a

			select * from #Temp1 order by isnull(LastName,Code)
END
			--Order By isnull(EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_CODE)



GO


