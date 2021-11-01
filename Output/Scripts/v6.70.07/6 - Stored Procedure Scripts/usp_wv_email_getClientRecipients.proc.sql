IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_email_getClientRecipients]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_email_getClientRecipients]
GO

CREATE PROCEDURE [dbo].[usp_wv_email_getClientRecipients] 
@IncludeAll int,
@Client VarChar(6),
@Name VarChar(100),
@CP INT,
@CPID INT,
@JobNumber INT,
@JobComponentNumber INT
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

If @CP = 1
Begin
	if @IncludeAll = 1
		SELECT @sql = 'SELECT CDP_CONTACT_HDR.CL_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') + COALESCE (CONT_LNAME, '''') AS FML, 
						  COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME
					   FROM dbo.CDP_CONTACT_HDR INNER JOIN
					   dbo.CLIENT ON dbo.CDP_CONTACT_HDR.CL_CODE = dbo.CLIENT.CL_CODE
					   WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) '
				if @Client <> '' 
					   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CL_CODE = @Client)'
				if @Client = '' AND @Name <> '' 
					   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name + '%'')'

	if @IncludeAll <> 1
		SELECT @sql = 'SELECT CDP_CONTACT_HDR.CL_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') + COALESCE (CONT_LNAME, '''') AS FML, 
						  COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME
					   FROM dbo.CDP_CONTACT_HDR INNER JOIN
					   dbo.CLIENT ON dbo.CDP_CONTACT_HDR.CL_CODE = dbo.CLIENT.CL_CODE
					   WHERE EMAIL_ADDRESS IS NOT NULL AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) '
				if @Client <> '' 
					   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CL_CODE = @Client)'
				if @Client = '' AND @Name <> '' 
					   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name+ '%'')'
End
Else
Begin
	if @IncludeAll = 1
		SELECT @sql = 'SELECT CDP_CONTACT_HDR.CL_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') + COALESCE (CONT_LNAME, '''') AS FML, 
						  COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME
					   FROM dbo.CDP_CONTACT_HDR INNER JOIN
					   dbo.CLIENT ON dbo.CDP_CONTACT_HDR.CL_CODE = dbo.CLIENT.CL_CODE
					   WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)'
				if @Client <> '' 
					   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CL_CODE = @Client)'
				if @Client = '' AND @Name <> '' 
					   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name + '%'')'

	if @IncludeAll <> 1
		SELECT @sql = 'SELECT CDP_CONTACT_HDR.CL_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') + COALESCE (CONT_LNAME, '''') AS FML, 
						  COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME
					   FROM dbo.CDP_CONTACT_HDR INNER JOIN
					   dbo.CLIENT ON dbo.CDP_CONTACT_HDR.CL_CODE = dbo.CLIENT.CL_CODE
					   WHERE EMAIL_ADDRESS IS NOT NULL AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)'
				if @Client <> '' 
					   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CL_CODE = @Client)'
				if @Client = '' AND @Name <> '' 
					   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name+ '%'')'
End



SELECT @paramlist = '@Client VarChar(6), @Name VarChar(100), @CPID INT'

EXEC sp_executesql @sql, @paramlist, @Client, @Name, @CPID
 



	
