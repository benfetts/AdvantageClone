if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetOfficeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetOfficeData]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetOfficeData]
(
	@OfficeCode varchar(4000),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@UserID varchar(100)
)
AS
Declare @Restrictions Int,
		@RestrictionsOffice Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000),
		@EmpCode varchar(6)

Select @EmpCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmpCode

 
SELECT @sql = 'SELECT EMPLOYEE.OFFICE_CODE, OFFICE.OFFICE_NAME, SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) AS DIRECT, SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS) AS NONDIRECT
				FROM OFFICE INNER JOIN
				EMPLOYEE ON OFFICE.OFFICE_CODE = EMPLOYEE.OFFICE_CODE INNER JOIN
				DASH_DATA_EMP_TIME ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
		if @RestrictionsOffice > 0
		    Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
			End
		if @OfficeCode <> '' and @OfficeCode <> 'All'
			Begin
				SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) c ON OFFICE.OFFICE_CODE = c.vstr collate database_default'
			End	
		SELECT @sql = @sql + ' WHERE 1=1'		
		if @StartDate <> '' and @EndDate <> ''
			Begin
				SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
			End	
		if @RestrictionsOffice > 0
		    Begin
				SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmpCode'
			End
		SELECT @sql = @sql + ' GROUP BY EMPLOYEE.OFFICE_CODE, OFFICE.OFFICE_NAME'

SELECT @paramlist = '@OfficeCode varchar(4000), @StartDate SmallDateTime, @EndDate SmallDateTime, @EmpCode varchar(6)'
PRINT @sql
EXEC sp_executesql @sql, @paramlist, @OfficeCode, @StartDate, @EndDate, @EmpCode

--SELECT DASH_DATA_EMP_TIME.OFFICE_CODE, OFFICE.OFFICE_NAME, SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) AS DIRECT, SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS) AS NONDIRECT
--FROM DASH_DATA_EMP_TIME  LEFT OUTER JOIN
--	 OFFICE ON DASH_DATA_EMP_TIME.OFFICE_CODE = OFFICE.OFFICE_NAME
--GROUP BY DASH_DATA_EMP_TIME.OFFICE_CODE, OFFICE.OFFICE_NAME



GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

