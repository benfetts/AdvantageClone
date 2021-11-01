IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_email_getInternalRecipients]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_email_getInternalRecipients]
GO

CREATE PROCEDURE [dbo].[usp_wv_email_getInternalRecipients] 
@IncludeAll int,
@EmpCode varchar(6),
@Name varchar(100),
@CP INT,
@CPID INT,
@JobNumber INT,
@JobComponentNumber INT
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @AlertGroupCode varchar(50)
Set NoCount On



If @CP = 1
Begin
	SELECT @AlertGroupCode = ISNULL(EMAIL_GR_CODE,'') FROM JOB_COMPONENT WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber

	if @AlertGroupCode = ''
	Begin
		SELECT @AlertGroupCode = ALERT_GROUP_CODE FROM CP_USER WHERE CDP_CONTACT_ID = @CPID
	End	
	
	if @IncludeAll = 1
		SELECT @sql = 'SELECT EMP_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
							  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
							  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, ISNULL(EMP_EMAIL,'''') AS EMAIL
					   FROM         dbo.EMPLOYEE
					   WHERE     ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE())) AND EMP_CODE IN (SELECT EMP_CODE FROM EMAIL_GROUP WHERE EMAIL_GR_CODE = ''' + @AlertGroupCode + ''')'
				if @EmpCode <> '' 
					   SELECT @sql = @sql + ' AND (EMP_CODE = @EmpCode)'
				if @EmpCode = '' and @Name <> ''
					   SELECT @sql = @sql + ' AND (EMP_FNAME LIKE ''%' + @Name + '%'' OR EMP_MI LIKE ''%' + @Name + '%'' or EMP_LNAME LIKE ''%' + @Name + '%'')'

					   SELECT @sql = @sql + ' UNION

					   SELECT AGENCY_CONTACT_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
							  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
							  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, ISNULL(EMP_EMAIL,'''') AS EMAIL
					   FROM CP_USER INNER JOIN EMPLOYEE ON CP_USER.AGENCY_CONTACT_CODE = EMPLOYEE.EMP_CODE
					   WHERE ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE())) AND CP_USER.CDP_CONTACT_ID = @CPID'


	if @IncludeAll <> 1
		SELECT @sql = 'SELECT EMP_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
							  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
							  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, ISNULL(EMP_EMAIL,'''') AS EMAIL
					   FROM         dbo.EMPLOYEE
					   WHERE     ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE())) AND EMP_EMAIL IS NOT NULL AND EMP_CODE IN (SELECT EMP_CODE FROM EMAIL_GROUP WHERE EMAIL_GR_CODE = ''' + @AlertGroupCode + ''')'
				if @EmpCode <> '' 
					   SELECT @sql = @sql + ' AND (EMP_CODE = @EmpCode)'
				if @EmpCode = '' and @Name <> ''
					   SELECT @sql = @sql + ' AND (EMP_FNAME LIKE ''%' + @Name + '%'' OR EMP_MI LIKE ''%' + @Name + '%'' or EMP_LNAME LIKE ''%' + @Name + '%'')'

					   SELECT @sql = @sql + ' UNION

					   SELECT AGENCY_CONTACT_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
							  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
							  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, ISNULL(EMP_EMAIL,'''') AS EMAIL
					   FROM CP_USER INNER JOIN EMPLOYEE ON CP_USER.AGENCY_CONTACT_CODE = EMPLOYEE.EMP_CODE
					   WHERE ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE())) AND CP_USER.CDP_CONTACT_ID = @CPID'

End
Else
Begin
	if @IncludeAll = 1
		SELECT @sql = 'SELECT EMP_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
							  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
							  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, ISNULL(EMP_EMAIL,'''') AS EMAIL
					   FROM         dbo.EMPLOYEE
					   WHERE     ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE()))'
				if @EmpCode <> '' 
					   SELECT @sql = @sql + ' AND (EMP_CODE = @EmpCode)'
				if @EmpCode = '' and @Name <> ''
					   SELECT @sql = @sql + ' AND (EMP_FNAME LIKE ''%' + @Name + '%'' OR EMP_MI LIKE ''%' + @Name + '%'' or EMP_LNAME LIKE ''%' + @Name + '%'')'

	if @IncludeAll <> 1
		SELECT @sql = 'SELECT EMP_CODE AS CODE, COALESCE (RTRIM(EMP_FNAME) + '' '', '''') + COALESCE (EMP_MI + ''. '', '''') + COALESCE (EMP_LNAME, '''') AS FML, 
							  COALESCE (EMP_LNAME + '', '', '''') + COALESCE (RTRIM(EMP_FNAME), '''') AS LF, COALESCE (LEFT(EMP_FNAME, 1) + ''. '', '''') 
							  + COALESCE (EMP_LNAME, '''') AS EMP_FIL, ISNULL(EMP_EMAIL,'''') AS EMAIL
					   FROM         dbo.EMPLOYEE
					   WHERE     ((EMP_TERM_DATE IS NULL) OR (EMP_TERM_DATE > GETDATE())) AND EMP_EMAIL IS NOT NULL'
				if @EmpCode <> '' 
					   SELECT @sql = @sql + ' AND (EMP_CODE = @EmpCode)'
				if @EmpCode = '' and @Name <> ''
					   SELECT @sql = @sql + ' AND (EMP_FNAME LIKE ''%' + @Name + '%'' OR EMP_MI LIKE ''%' + @Name + '%'' or EMP_LNAME LIKE ''%' + @Name + '%'')'
End

print(@sql)

SELECT @paramlist = '@EmpCode VarChar(6), @Name VarChar(100), @CPID INT'

EXEC sp_executesql @sql, @paramlist, @EmpCode, @Name, @CPID 
 



	
