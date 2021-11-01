if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetEmps]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetEmps]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetEmps]
(
	@DeptCode varchar(4000),
	@OfficeCode varchar(4000),
	@Include int,
	@Filter varchar(100),
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

if @Include = 1
Begin
	--if @Filter = ''
	--Begin
	--	SELECT @sql = 'SELECT TOP 100'
	--End
	--Else
	--Begin
	--	SELECT @sql = 'SELECT'
	--End
		
	SELECT @sql = 'SELECT EMPLOYEE.EMP_CODE, isnull(EMP_LNAME,'''') + '', '' + isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end AS EMP_DESC
					FROM EMPLOYEE'
			if @DeptCode <> '' AND @DeptCode <> 'All'
			Begin	
				SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@DeptCode, DEFAULT) d ON EMPLOYEE.DP_TM_CODE = d.vstr collate database_default'
			End
			if @OfficeCode <> '' AND @OfficeCode <> 'All'
			Begin	
				SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
			End			
			if @RestrictionsOffice > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
			End
			SELECT @sql = @sql + ' WHERE 1=1'				
			if @RestrictionsOffice > 0
		    Begin
				SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmpCode'
			End
	if @Filter <> ''
	Begin
		SELECT @sql = @sql + ' AND LOWER(EMP_LNAME) LIKE ''%'' + LOWER(@Filter) + ''%'' OR LOWER(EMP_FNAME) LIKE ''%'' + LOWER(@Filter) + ''%'' OR LOWER(EMP_MI) LIKE ''%'' + LOWER(@Filter) + ''%'''
	End	
	SELECT @sql = @sql + ' ORDER BY EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI'
	SELECT @paramlist = '@DeptCode varchar(4000), @OfficeCode varchar(4000), @Filter varchar(100), @EmpCode varchar(6)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @DeptCode, @OfficeCode, @Filter, @EmpCode
End
Else
Begin
	--if @Filter = ''
	--Begin
	--	SELECT @sql = 'SELECT TOP 100'
	--End
	--Else
	--Begin
	--	SELECT @sql = 'SELECT'
	--End
	SELECT @sql = 'SELECT EMPLOYEE.EMP_CODE, isnull(EMP_LNAME,'''') + '', '' + isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end AS EMP_DESC
					FROM EMPLOYEE'
			if @DeptCode <> '' AND @DeptCode <> 'All'
			Begin	
				SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@DeptCode, DEFAULT) d ON EMPLOYEE.DP_TM_CODE = d.vstr collate database_default'
			End
			if @OfficeCode <> '' AND @OfficeCode <> 'All'
			Begin	
				SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
			End		
			if @RestrictionsOffice > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
			End
			SELECT @sql = @sql + ' WHERE EMP_TERM_DATE IS NULL'				
			if @RestrictionsOffice > 0
		    Begin
				SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmpCode'
			End
	if @Filter <> ''
	Begin
		SELECT @sql = @sql + ' AND LOWER(EMP_LNAME) LIKE ''%'' + LOWER(@Filter) + ''%'' OR LOWER(EMP_FNAME) LIKE ''%'' + LOWER(@Filter) + ''%'' OR LOWER(EMP_MI) LIKE ''%'' + LOWER(@Filter) + ''%'''
	End
	SELECT @sql = @sql + ' ORDER BY EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI'
	SELECT @paramlist = '@DeptCode varchar(4000), @OfficeCode varchar(4000), @Filter varchar(100), @EmpCode varchar(6)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @DeptCode, @OfficeCode, @Filter, @EmpCode
End


