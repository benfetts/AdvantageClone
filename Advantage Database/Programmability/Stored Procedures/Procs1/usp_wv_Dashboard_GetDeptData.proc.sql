if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetDeptData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetDeptData]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetDeptData]
(
	@OfficeCode varchar(4000),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@DeptCode varchar(4000),
	@UserID varchar(100)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000),
		@RestrictionsOffice Int,
		@EmpCode varchar(6)

Select @EmpCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmpCode

SELECT @sql = ' SELECT DASH_DATA_EMP_TIME.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC, SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) AS DIRECT, SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS) AS NONDIRECT
				FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				DEPT_TEAM ON DASH_DATA_EMP_TIME.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE INNER JOIN
				EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
		if @OfficeCode <> '' and @OfficeCode <> 'All'
			Begin
				SELECT @sql = @sql + '  INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
			End
		if @RestrictionsOffice > 0
		    Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
			End
		if @DeptCode <> '' and @DeptCode <> 'All'
			Begin
				SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@DeptCode, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
			End	
		SELECT @sql = @sql + ' WHERE ((DEPT_TEAM.INACTIVE_FLAG IS NULL) OR (DEPT_TEAM.INACTIVE_FLAG = 0)) AND DASH_DATA_EMP_TIME.DP_TM_CODE IS NOT NULL'			
		if @StartDate <> '' and @EndDate <> ''
			Begin
				SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
			End	
		if @RestrictionsOffice > 0
		    Begin
				SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmpCode'
			End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC'
		SELECT @sql = @sql + ' ORDER BY DASH_DATA_EMP_TIME.DP_TM_CODE'

SELECT @paramlist = '@OfficeCode varchar(4000), @StartDate SmallDateTime, @EndDate SmallDateTime, @DeptCode varchar(4000), @EmpCode varchar(6)'

EXEC sp_executesql @sql, @paramlist, @OfficeCode, @StartDate, @EndDate, @DeptCode, @EmpCode

--if @OfficeCode <> '' AND @OfficeCode <> 'All'
--Begin
--	SELECT DASH_DATA_EMP_TIME.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC, SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) AS DIRECT, SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS) AS NONDIRECT
--	FROM DASH_DATA_EMP_TIME  LEFT OUTER JOIN
--		 DEPT_TEAM ON DASH_DATA_EMP_TIME.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE INNER JOIN
--		EMPLOYEE ON EMPLOYEE.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE INNER JOIN
--		OFFICE ON EMPLOYEE.OFFICE_CODE = OFFICE.OFFICE_CODE 
--	WHERE OFFICE.OFFICE_CODE = @OfficeCode
--	GROUP BY DASH_DATA_EMP_TIME.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC
--End
--Else
--Begin
--	SELECT DASH_DATA_EMP_TIME.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC, SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) AS DIRECT, SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS) AS NONDIRECT
--	FROM DASH_DATA_EMP_TIME  LEFT OUTER JOIN
--		 DEPT_TEAM ON DASH_DATA_EMP_TIME.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE 
--	GROUP BY DASH_DATA_EMP_TIME.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC
--End




GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

