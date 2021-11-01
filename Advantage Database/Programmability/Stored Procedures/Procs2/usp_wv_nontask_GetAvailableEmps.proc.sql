IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_nontask_GetAvailableEmps]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_nontask_GetAvailableEmps]
GO

CREATE PROCEDURE [dbo].[usp_wv_nontask_GetAvailableEmps] 
@IncludeAll int,
@EmpCode varchar(6),
@ROLE_CODE VARCHAR(6),
@EMAIL_GR_CODE VARCHAR(50),
@TaskNo int,
@USER_CODE VARCHAR(100)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

	DECLARE @OfficeRestrictions AS INTEGER	
	DECLARE @EMP_CODE AS varchar(6),@EmpRestrictions SMALLINT

	SELECT @EmpRestrictions = ISNULL(COUNT(1),0) FROM SEC_EMP WHERE UPPER(USER_ID) = UPPER(@USER_CODE)

	SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@USER_CODE)
	SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

Set NoCount On

if @IncludeAll = 1
Begin
	SELECT @sql = 'SELECT EMPLOYEE.EMP_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
						  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
						  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, EMPLOYEE.EMP_CODE + ''|'' + ISNULL(EMP_EMAIL,'''') AS EMAIL
				   FROM         dbo.EMPLOYEE'
			If @OfficeRestrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
				End
			If @EmpRestrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE'
				End
			SELECT @sql = @sql + ' WHERE     ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE()))'			
			If @EmpRestrictions > 0
				Begin
					SELECT @sql = @sql + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' + @USER_CODE + ''')'
				End
			if @EmpCode <> '' 
				   SELECT @sql = @sql + ' AND (EMPLOYEE.EMP_CODE = @EmpCode)'
			if @ROLE_CODE <> ''
				   SELECT @sql = @sql + ' AND EMPLOYEE.EMP_CODE IN (SELECT DISTINCT EMP_CODE
								FROM   EMP_TRAFFIC_ROLE WITH(NOLOCK)
								WHERE  ROLE_CODE = @ROLE_CODE)'
			if @EMAIL_GR_CODE <> ''
				   SELECT @sql = @sql + ' AND EMPLOYEE.EMP_CODE IN (SELECT DISTINCT EMP_CODE
								FROM   EMAIL_GROUP
								WHERE  EMAIL_GR_CODE = @EMAIL_GR_CODE
									   AND (
											   EMAIL_GROUP.INACTIVE_FLAG IS NULL
											   OR EMAIL_GROUP.INACTIVE_FLAG = 0
										   )
									   )'
			if @TaskNo > 0
				   SELECT @sql = @sql + ' AND (EMPLOYEE.EMP_CODE NOT IN (SELECT EMP_CODE FROM EMP_NON_TASKS_EMPS WHERE NON_TASK_ID = @TaskNo))'
End

if @IncludeAll <> 1
Begin
	SELECT @sql = 'SELECT EMPLOYEE.EMP_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
						  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
						  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, EMPLOYEE.EMP_CODE + ''|'' + ISNULL(EMP_EMAIL,'''') AS EMAIL
				   FROM         dbo.EMPLOYEE'
			If @OfficeRestrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
				End
			If @EmpRestrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE'
				End
			SELECT @sql = @sql + ' WHERE ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE())) AND EMP_EMAIL IS NOT NULL'			
			If @EmpRestrictions > 0
				Begin
					SELECT @sql = @sql + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' + @USER_CODE + ''')'
				End
			if @EmpCode <> '' 
				   SELECT @sql = @sql + ' AND (EMPLOYEE.EMP_CODE = @EmpCode)'
			if @ROLE_CODE <> ''
				   SELECT @sql = @sql + ' AND EMPLOYEE.EMP_CODE IN (SELECT DISTINCT EMP_CODE
								FROM   EMP_TRAFFIC_ROLE WITH(NOLOCK)
								WHERE  ROLE_CODE = @ROLE_CODE)'
			if @EMAIL_GR_CODE <> ''
				   SELECT @sql = @sql + ' AND EMPLOYEE.EMP_CODE IN (SELECT DISTINCT EMP_CODE
								FROM   EMAIL_GROUP
								WHERE  EMAIL_GR_CODE = @EMAIL_GR_CODE
									   AND (
											   EMAIL_GROUP.INACTIVE_FLAG IS NULL
											   OR EMAIL_GROUP.INACTIVE_FLAG = 0
										   )
									   )'
			if @TaskNo > 0
				   SELECT @sql = @sql + ' AND (EMPLOYEE.EMP_CODE NOT IN (SELECT EMP_CODE FROM EMP_NON_TASKS_EMPS WHERE NON_TASK_ID = @TaskNo))'
End

SELECT @sql = @sql + ' ORDER BY EMP_FNAME,EMP_MI,EMP_LNAME'
SELECT @paramlist = '@EmpCode VarChar(6), @ROLE_CODE VARCHAR(6), @EMAIL_GR_CODE VARCHAR(50),@TaskNo int'

EXEC sp_executesql @sql, @paramlist, @EmpCode, @ROLE_CODE ,@EMAIL_GR_CODE,@TaskNo
 



	
